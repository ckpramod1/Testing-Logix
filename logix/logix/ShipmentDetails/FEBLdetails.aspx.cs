using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
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
using System.Text.RegularExpressions;
using System.Runtime.Remoting;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using DataAccess.BondedTrucking;


namespace logix.ShipmentDetails
{
    public partial class FEBLdetails : System.Web.UI.Page
    {
        public static Boolean btndelete;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        string datcro;
        string type;
        DataAccess.Masters.MasterCargo cargoobj = new DataAccess.Masters.MasterCargo();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterVessel vesselobj = new DataAccess.Masters.MasterVessel();
        DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
        string str_FornName = "", str_Uiid = "", base1, strvolume, strntweight, strchgweight, strgrosswght, sizecount;
        double rate, exrate, amount, unit, cbmAmt, mtAmt;
        int back, limit20, limit40, limit240, Refno, refnodebitOs, Refno1;
        DataTable obj_dt = new DataTable();
        DataAccess.Masters.MasterPackages obj_da_packages = new DataAccess.Masters.MasterPackages();
        DataTable dtcont = new DataTable();
        DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.ForwardingExports.JobInfo obj_da_Job = new DataAccess.ForwardingExports.JobInfo();
        bool invgen, invgen1;
        DataTable dtinv = new DataTable();
        DataAccess.Accounts.ProfomaInvoice ProINVobj = new DataAccess.Accounts.ProfomaInvoice();
        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        //DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
        DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
        //DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
        //DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.ForwardingExports.JobInfo obj_da_Jobinfo = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterPort obj_da_Port = new DataAccess.Masters.MasterPort();
        DataAccess.ForwardingExports.JobInfo obj_da_FEJobinfo = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.Accounts.Invoice obj_inv = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
        DataAccess.ForwardingExports.BLDetailsWOJob obj_da_BLwojob = new DataAccess.ForwardingExports.BLDetailsWOJob();
        DataAccess.ForwardingImports.BLDetails obj_da_BLImport = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.Reportasp objRpt = new DataAccess.Reportasp();
        DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataAccess.AirImportExports.AIEJobInfo objaej = new DataAccess.AirImportExports.AIEJobInfo();
        string str_BL = "", str_booking;
        DataTable dtsupply = new DataTable();
        Boolean blnerrUinno = false;
        Boolean blnerrGstin = false;
        Boolean blnerrUinnoGstin = false;
        Boolean blnerr = false;
        string StrScript = "";
        Boolean bolcuststat = false;
        Boolean bolcuststat1 = false;
        bool DebitOS, CreditOS;
        string famount;
        string strTranType;

        DataTable DtBLNO = new DataTable();
        DataAccess.Accounts.DCAdvise DAdvise = new DataAccess.Accounts.DCAdvise();
        DataAccess.ForwardingExports.BLDetailsWOJob obj_da_BLWojob = new DataAccess.ForwardingExports.BLDetailsWOJob();
        //DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
        string mblno;
        int fd;
        Double douvolume, volume, wt;
        int sizecount1;
        int refnocreditOs;
        DataTable dtcust = new DataTable();
        Boolean ContVerify = false;
        string Miscontsize = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                cargoobj.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                vesselobj.GetDataBase(Ccode);
                da_obj_Port.GetDataBase(Ccode);
                obj_da_packages.GetDataBase(Ccode);
                objbu.GetDataBase(Ccode);
                obj_da_Job.GetDataBase(Ccode);
                ProINVobj.GetDataBase(Ccode);
                obj_da_Invoice.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);

                DAdvise.GetDataBase(Ccode);
                //obj_da_jobinfo.GetDataBase(Ccode);
                obj_MasterPort.GetDataBase(Ccode);
                obj_da_jobinfo.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);
                obj_da_BL.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                obj_da_BLWojob.GetDataBase(Ccode);
                obj_da_Jobinfo.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                obj_da_Port.GetDataBase(Ccode);
                obj_da_FEJobinfo.GetDataBase(Ccode);
                obj_da_FEBL.GetDataBase(Ccode);
                obj_inv.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                DCAdviseObj.GetDataBase(Ccode);
                obj_da_BLwojob.GetDataBase(Ccode);
                obj_da_BLImport.GetDataBase(Ccode);
                objRpt.GetDataBase(Ccode);
                da_obj_logobj.GetDataBase(Ccode);
                da_obj_OSDNCN.GetDataBase(Ccode);
                objaej.GetDataBase(Ccode);
                //quotobj.GetDataBase(Ccode);
                //STufobj.GetDataBase(Ccode);
                //quotobj.GetDataBase(Ccode);

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Btn_save);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Btn_cancel);

            string str_CtrlLists, str_MsgLists, str_DataType;
            //string str_FornName = "", str_Uiid = "";
            try
            {




                if (!IsPostBack)
                {
                    if (Request.QueryString.ToString().Contains("type"))
                    {
                        type = Request.QueryString["type"].ToString();

                    }
                    txt_cbm.Text = "0";
                    txt_orignalbl.Text = "3";
                    hid_reuse.Value = "";
                    Session["type"] = type;
                    UserRights();
                    lnkfrght.Visible = false;
                    chk_agent.Enabled = false;
                    if (hid_chaid.Value != "")
                    {
                        int chaid = Convert.ToInt32(hid_chaid.Value);
                    }

                    if (Session["blnofife"] != null)
                    {
                        txt_bl.Text = Session["blnofife"].ToString();
                        BLTYPE.SelectedItem.Text = type;
                        BLTYPE_SelectedIndexChanged(sender, e);
                        if (type == "Our BL")
                        {
                            lbl_header.Text = "Our BL";
                            div_vessel.Visible = false;
                            Chk_DG.Enabled = false;
                        }
                        else if (type == "Liner BL")
                        {
                            lbl_header.Text = "Direct Bill of Lading (Liner)";
                            div_vessel.Visible = false;
                            Chk_DG.Enabled = false;
                        }

                        obj_dt = obj_da_packages.GetPackagenames();

                        ddl_unit.Items.Clear();
                        ddl_unit.Items.Add("");
                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            ddl_unit.Items.Add(obj_dt.Rows[i].ItemArray[0].ToString());
                        }
                        txt_bl_TextChanged(sender, e);
                        txt_orignalbl.Text = "3";
                        Session["blnofife"] = null;
                        Session["type"] = null;
                        return;
                    }
                    BLTYPE.SelectedIndex = 1;
                    type = BLTYPE.Text;
                    //if (BLTYPE.SelectedIndex == 0)
                    //{
                    //    type = "Our BL";
                    //}

                    obj_dt = obj_da_packages.GetPackagenames();
                    /* if (obj_dt.Rows.Count > 0)
                     {
                         ddl_unit.DataSource = obj_dt;
                         ddl_unit.DataTextField = "descn";
                         ddl_unit.DataBind();
                     }*/
                    ddl_unit.Items.Clear();
                    ddl_unit.Items.Add("");
                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        ddl_unit.Items.Add(obj_dt.Rows[i].ItemArray[0].ToString());
                    }


                    string BL_No = Request.QueryString["BL_No"];

                    if (BL_No != null)
                    {
                        //menu_itm.Visible = true;
                        txt_bl.Text = BL_No;
                        lbl_header.Text = "Our BL";
                        txt_bl_TextChanged(sender, e);
                        Btn_delete.Visible = false;
                        Btn_save.Visible = false;
                        Btn_reuse.Visible = false;
                        btn_blrelease.Visible = false;
                        procrednote.Visible = false;
                        Proinvoic.Visible = false;

                    }

                    //str_CtrlLists = "txt_job~txt_booking~txt_bl~txt_issued~hid_issued~ddl_freight~txt_shipper~hid_shipperid~txt_consignee~hid_consigneeid~txt_notify~hid_notifyid~txt_agent~txt_receipt~hid_receiptid~txt_loading~hid_loadingid~txt_discharge~hid_dischargeid~txt_destination~hid_destinationid~txt_mark~txt_description~txt_cbm~txt_wt~txt_netweight~txt_volume~txt_package~ddl_unit~txt_cha~hid_chaid~txt_commotity~hid_cargoid~ddl_shipment~Chk_DG";
                    //str_MsgLists = "Job~Booking~BL #~Issuedat~Issuedat~Freight~Shipper~Shipper~Consignee~Consignee~Notify~Notify~Agent~PORT OF RECEIPT~PORT~PORT OF LOADING~PORT~PORT OF DISCHARGE~PORT~PORT OF DESTINATION~PORT~Mark~Descripition~CBM~GROSS WEIGHT~NET WEIGHT~VOLUME~NUMBER OF PACKAGE~PACKAGE TYPE~CHA~CHA~Commotity~Commotity~Shipment~Container";
                    //str_DataType = "String~String~String~String~AutoComplete~ddl~String~AutoComplete~String~AutoComplete~String~AutoComplete~String~String~AutoComplete~String~AutoComplete~String~AutoComplete~String~AutoComplete~String~AutoComplete~String~String~String~String~String~String~String~ddl~String~AutoComplete~String~AutoComplete~String~String";

                    //Btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && IsDate('txt_issuedon') && CheckSamePort_BL('txt_loading','txt_discharge','Port of Loading','Port of Discharge')&& CheckSamePort_BL('txt_receipt','txt_discharge','Receipt at','Port of Discharge')&& CheckSamePort_BL('txt_loading','txt_destination','Port of Loading','Place of Delivery') &&CheckSamePort_BL('ddl_shipment','Chk_DG','Shipment','Container')");
                    //str_CtrlLists = "~ddl_shipment~Chk_DG";
                    //str_MsgLists = "Shipment~Container";
                    //str_DataType = "String~String";
                    //Btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') CheckSamePort_BL('ddl_shipment','Chk_DG','Shipment','Container')");

                    txt_job.Attributes.Add("OnKeypress", "return IntegerCheck(event);");

                    txt_orignalbl.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    txt_cbm.Attributes.Add("OnKeypress", "return validateFloatKeyPress(this,event,'CBM')");
                    txt_grwt.Attributes.Add("OnKeypress", "return validateFloatKeyPress(this,event,'Gross Weight')");
                    txt_pkgs.Attributes.Add("OnKeypress", "return IntegerCheck(event);");

                    txt_ntwt.Attributes.Add("OnKeypress", "return validateFloatKeyPress(this,event,'Net Weight')");
                    //txtRateid.Attributes.Add("onkeypress", "return IntegerCheck(event,'Rate ID')");
                    //txtRate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Rate')");
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        HeaderLabel1.InnerText = "OceanExports";
                    }

                    if (type == "Our BL")
                    {
                        lbl_header.Text = "Our BL";
                        div_vessel.Visible = false;
                        Chk_DG.Enabled = false;
                        txt_job.Focus();

                        str_CtrlLists = "txt_job~txt_detail~txt_booking~txt_bl~txt_issued~txt_issuedon~txt_shipper~txt_shipperaddress~txt_consignee~txt_consigneeaddress~txt_notify~txt_notifyaddress~txt_agent~txt_agentaddress~txt_receipt~txt_loading~txt_discharge~txt_destination~txt_mark~txt_commotity~txt_cbm~txt_grwt~txt_ntwt~txt_pkgs";
                        str_MsgLists = "Job~JOB DETAILS~Booking~BL~ISSUED AT~ISSUED ON~Shipper~ShipperAddress~Consignee~ConsigneeAddress~NOTIFY PARTY~NOTIFY PARTYAddress~Agent~AgentAddress~PORT OF RECEIPT~PORT OF LOADING~PORT OF DISCHARGE~Place of Delivery~Marks&Numbers~Commodity~CUBIC METER~GROSS WEIGHT KGS~NET WEIGHT KGS~NUMBER OF PACKAGES~CUSTOMER HOUSE AGENT";
                        str_DataType = "String~String~String~String~String~String~String~AutoComplete~String~AutoComplete~String~AutoComplete~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String";

                        Btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && CheckSamePort_BL('txt_loading','txt_discharge','Port of Loading','Port of Discharge')&& CheckSamePort_BL('txt_receipt','txt_discharge','Receipt at','Port of Discharge')&& CheckSamePort_BL('txt_loading','txt_destination','Port of Loading','Place of Delivery') &&CheckSamePort_BL('ddl_shipment','Chk_DG','Shipment','Container')");
                    }
                    else if (type == "Liner BL")
                    {
                        txt_bl.ReadOnly = true;
                        //  lbl_header.Text = "Our BL";
                        str_CtrlLists = "txt_job~txt_detail~txt_booking~txt_bl~txt_issued~txt_issuedon~txt_shipper~txt_shipperaddress~txt_consignee~txt_consigneeaddress~txt_notify~txt_notifyaddress~txt_agent~txt_agentaddress~txt_receipt~txt_loading~txt_discharge~txt_destination~txt_mark~txt_commotity~txt_cbm~txt_grwt~txt_ntwt~txt_pkgs";
                        str_MsgLists = "Job~JOB DETAILS~Booking~BL~ISSUED AT~ISSUED ON~Shipper~ShipperAddress~Consignee~ConsigneeAddress~NOTIFY PARTY~NOTIFY PARTYAddress~Agent~AgentAddress~PORT OF RECEIPT~PORT OF LOADING~PORT OF DISCHARGE~Place of Delivery~Marks&Numbers~Commodity~CUBIC METER~GROSS WEIGHT KGS~NET WEIGHT KGS~NUMBER OF PACKAGES~CUSTOMER HOUSE AGENT";
                        str_DataType = "String~String~String~String~String~String~String~AutoComplete~String~AutoComplete~String~AutoComplete~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String";

                        Btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && CheckSamePort_BL('txt_loading','txt_discharge','Port of Loading','Port of Discharge')&& CheckSamePort_BL('txt_receipt','txt_discharge','Receipt at','Port of Discharge')&& CheckSamePort_BL('txt_loading','txt_destination','Port of Loading','Place of Delivery') &&CheckSamePort_BL('ddl_shipment','Chk_DG','Shipment','Container')");
                        lbl_header.Text = "Direct Bill of Lading (Liner)";
                        div_vessel.Visible = false;
                        Chk_DG.Enabled = false;
                        //txt_job.Focus();

                    }



                    //else if (type == "BL Details WOJ")
                    //{
                    //    menu.InnerText = "Utility";
                    //    str_CtrlLists = "txt_vessel~txt_voyage~txt_container~txt_bl~txt_issued~txt_issuedon~txt_shipper~txt_shipperaddress~txt_consignee~txt_consigneeaddress~txt_notify~txt_notifyaddress~txt_agent~txt_agentaddress~txt_receipt~txt_loading~txt_discharge~txt_destination~txt_mark~txt_commotity~txt_cbm~txt_grwt~txt_ntwt~txt_pkgs~txt_cha";
                    //    str_MsgLists = "Vessel~Voyage~Container~BL~ISSUED AT~ISSUED ON~Shipper~ShipperAddress~Consignee~ConsigneeAddress~NOTIFY PARTY~NOTIFY PARTYAddress~Agent~AgentAddress~PORT OF RECEIPT~PORT OF LOADING~PORT OF DISCHARGE~Place of Delivery~Marks&Numbers~Commotity~CUBIC METER~GROSS WEIGHT KGS~NET WEIGHT KGS~NUMBER OF PACKAGES~CUSTOMER HOUSE AGENT";
                    //    str_DataType = "String~String~String~String~String~String~String~AutoComplete~String~AutoComplete~String~AutoComplete~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String";

                    //    Btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && CheckSamePort_BL('txt_loading','txt_discharge','Port of Loading','Port of Discharge')&& CheckSamePort_BL('txt_receipt','txt_discharge','Receipt at','Port of Discharge')&& CheckSamePort_BL('txt_loading','txt_destination','Port of Loading','Place of Delivery') &&CheckSamePort_BL('ddl_shipment','Chk_DG','Shipment','Container')");
                    //    lbl_header.Text = "BILL OF LADING WOJ";
                    //    LoadBooking();
                    //    div_vessel.Visible = true;
                    //    lnk_job.Visible = false;
                    //    txt_job.Visible = false;
                    //    txt_detail.Visible = false;
                    //    lnk_booking.Visible = false;
                    //    txt_booking.Visible = false;
                    //    txt_vessel.Focus();
                    //}

                    hid_date.Value = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    txt_issuedon.Text = hid_date.Value.ToString();
                    etd.Text = hid_date.Value.ToString();
                    eta.Text = hid_date.Value.ToString();
                    //Btn_cancel.Text = "Cancel";

                    Btn_cancel.ToolTip = "Cancel";
                    Btn_cancel1.Attributes["class"] = "btn ico-cancel";

                    headerlable.InnerText = lbl_header.Text;
                    if (lbl_header.Text == "Our BL")
                    {
                        headerlable.InnerText = "Bill of Ladding";
                    }
                    if (Request.QueryString.ToString().Contains("BLDetails"))
                    {

                        //BLTYPE_SelectedIndexChanged(sender, e);
                        // BLTYPE.Enabled = false;
                        txt_job.Text = Request.QueryString["jobno"].ToString();
                        txt_booking.Text = Request.QueryString["bookingno"].ToString();
                        type = Request.QueryString["BLDetails"].ToString();
                        if (type == "Our BL")
                        {
                            lbl_header.Text = "Our BL";
                            div_vessel.Visible = false;
                            Chk_DG.Enabled = false;
                            txt_job.Focus();
                            BLTYPE.SelectedIndex = 1;
                            txt_bl.ReadOnly = true;

                            if (txt_booking.Text != "")
                            {
                                txt_bl.Text = txt_booking.Text;
                            }

                        }
                        else if (type == "Liner BL")
                        {
                            // lbl_header.Text = "Our BL";
                            txt_bl.ReadOnly = false;
                            lbl_header.Text = "Direct Bill of Lading (Liner)";
                            div_vessel.Visible = false;
                            Chk_DG.Enabled = false;
                            BLTYPE.SelectedIndex = 2;
                            txt_bl.Text = "";


                        }
                        txt_job_TextChanged(sender, e);
                        bookingdetails();
                        if (hid_intcustomerid.Value != "")
                        {
                            dtcust = obj_da_BL.GetCreditApprovalFromCustomer(Convert.ToInt32(hid_intcustomerid.Value));
                        }
                        //if(dtcust.Rows.Count>0) --as per nambi sir instruction hided on 18july2022
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                        //    Btn_save.Visible = false;
                        //    return;

                        //}

                    }
                    if (Request.QueryString.ToString().Contains("blno"))
                    {

                        txt_bl.Text = Request.QueryString["blno"].ToString();
                        if (Request.QueryString.ToString().Contains("type"))
                        {
                            type = Request.QueryString["type"].ToString();

                            if (type == "Our BL")
                            {
                                lbl_header.Text = "Our BL";
                                div_vessel.Visible = false;
                                Chk_DG.Enabled = false;
                                txt_job.Focus();
                                BLTYPE.SelectedIndex = 1;
                                txt_bl.ReadOnly = true;

                                if (txt_booking.Text != "")
                                {
                                    txt_bl.Text = txt_booking.Text;
                                }

                            }
                            else if (type == "Liner BL")
                            {
                                // lbl_header.Text = "Our BL";
                                txt_bl.ReadOnly = false;
                                lbl_header.Text = "Direct Bill of Lading (Liner)";
                                div_vessel.Visible = false;
                                Chk_DG.Enabled = false;
                                BLTYPE.SelectedIndex = 2;
                                txt_bl.Text = "";


                            }

                        }
                        txt_bl_TextChanged(sender, e);
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
                if (type == "Our BL")
                {
                    lbl_header.Text = "Our BL";
                    str_CtrlLists = "txt_job~txt_detail~txt_booking~txt_bl~txt_issued~txt_issuedon~txt_shipper~txt_shipperaddress~txt_consignee~txt_consigneeaddress~txt_notify~txt_notifyaddress~txt_agent~txt_agentaddress~txt_receipt~txt_loading~txt_discharge~txt_destination~txt_mark~txt_commotity~txt_cbm~txt_grwt~txt_ntwt~txt_pkgs";
                    str_MsgLists = "Job~JOB DETAILS~Booking~BL~ISSUED AT~ISSUED ON~Shipper~ShipperAddress~Consignee~ConsigneeAddress~NOTIFY PARTY~NOTIFY PARTYAddress~Agent~AgentAddress~PORT OF RECEIPT~PORT OF LOADING~PORT OF DISCHARGE~Place of Delivery~Marks&Numbers~Commotity~CUBIC METER~GROSS WEIGHT KGS~NET WEIGHT KGS~NUMBER OF PACKAGES~CUSTOMER HOUSE AGENT";
                    str_DataType = "String~String~String~String~String~String~String~AutoComplete~String~AutoComplete~String~AutoComplete~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String";

                    Btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && CheckSamePort_BL('txt_loading','txt_discharge','Port of Loading','Port of Discharge')&& CheckSamePort_BL('txt_receipt','txt_discharge','Receipt at','Port of Discharge')&& CheckSamePort_BL('txt_loading','txt_destination','Port of Loading','Place of Delivery') &&CheckSamePort_BL('ddl_shipment','Chk_DG','Shipment','Container')");
                }
                else if (type == "Liner BL")
                {
                    //lbl_header.Text = "Our BL";
                    str_CtrlLists = "txt_job~txt_detail~txt_booking~txt_bl~txt_issued~txt_issuedon~txt_shipper~txt_shipperaddress~txt_consignee~txt_consigneeaddress~txt_notify~txt_notifyaddress~txt_agent~txt_agentaddress~txt_receipt~txt_loading~txt_discharge~txt_destination~txt_mark~txt_commotity~txt_cbm~txt_grwt~txt_ntwt~txt_pkgs";
                    str_MsgLists = "Job~JOB DETAILS~Booking~BL~ISSUED AT~ISSUED ON~Shipper~ShipperAddress~Consignee~ConsigneeAddress~NOTIFY PARTY~NOTIFY PARTYAddress~Agent~AgentAddress~PORT OF RECEIPT~PORT OF LOADING~PORT OF DISCHARGE~Place of Delivery~Marks&Numbers~Commotity~CUBIC METER~GROSS WEIGHT KGS~NET WEIGHT KGS~NUMBER OF PACKAGES~CUSTOMER HOUSE AGENT";
                    str_DataType = "String~String~String~String~String~String~String~AutoComplete~String~AutoComplete~String~AutoComplete~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String~String";

                    Btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && CheckSamePort_BL('txt_loading','txt_discharge','Port of Loading','Port of Discharge')&& CheckSamePort_BL('txt_receipt','txt_discharge','Receipt at','Port of Discharge')&& CheckSamePort_BL('txt_loading','txt_destination','Port of Loading','Place of Delivery') &&CheckSamePort_BL('ddl_shipment','Chk_DG','Shipment','Container')");
                    lbl_header.Text = "Direct Bill of Lading (Liner)";
                    //txt_job.Focus();

                }
                if (txt_bl.Text != "")
                {
                    Btn_delete.Attributes["onClick"] = "return confirm('Are you sure you want to delete this Details?');";
                }
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

        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {
                    //Boolean btn_delete;
                    str_FornName = Request.QueryString["type"].ToString();
                    if (Request.QueryString.ToString().Contains("uiid"))
                    {
                        str_Uiid = Request.QueryString["uiid"].ToString();
                        Utility.Fn_CheckUserRights(str_Uiid, Btn_save, btn_view, Btn_delete);
                        DataTable obj_Dtuser = new DataTable();
                        obj_Dtuser = (DataTable)Session["dt_UserRights"];
                        DataView obj_dtview = new DataView(obj_Dtuser);
                        obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                        obj_Dtuser = obj_dtview.ToTable();
                        //
                    }
                    else
                    {
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

        [WebMethod]
        public static List<string> GetPort(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_Port.GetDataBase(Ccode);
            obj_dt = da_obj_Port.GetLikePort(prefix.ToUpper().Trim());
            List_Result = Utility.Fn_DatatableToList(obj_dt, "portname", "portid");
            return List_Result;
        }

        protected void lnk_job_Click(object sender, EventArgs e)
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
            try
            {


                Grd_Job.Visible = true;
                Grd_Booking.Visible = false;
                //DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_jobinfo.GetJobNoList(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                if (obj_dt.Rows.Count <= 0)
                {
                    ScriptManager.RegisterStartupScript(lnk_job, typeof(LinkButton), "BLDetails", "alertify.alert('Job Not Available');", true);
                    return;
                }
                else
                {
                    this.popup_Grd.Show();
                    Grd_Job.DataSource = obj_dt;
                    Grd_Job.DataBind();

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }






        protected void Grd_Job_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                popup_Grd.Hide();
                if (hid_reuse.Value != "Reuse")
                {
                    Fn_Clear();
                }

                txt_job.Text = Grd_Job.SelectedRow.Cells[0].Text;
                //txt_detail.Text = Grd_Job.SelectedRow.Cells[1].Text + " , " + Grd_Job.SelectedRow.Cells[2].Text + " , " + Grd_Job.SelectedRow.Cells[3].Text + " , " + Grd_Job.SelectedRow.Cells[4].Text + " , " + Grd_Job.SelectedRow.Cells[5].Text + " , " + Grd_Job.SelectedRow.Cells[6].Text + " , " + Grd_Job.SelectedRow.Cells[7].Text+" , " + Grd_Job.SelectedRow.Cells[8].Text;
                txt_detail.Text = Grd_Job.SelectedRow.Cells[1].Text + " , " + ((Label)Grd_Job.SelectedRow.Cells[2].FindControl("vessel")).Text + " , " + Grd_Job.SelectedRow.Cells[4].Text + " , " + ((Label)Grd_Job.SelectedRow.Cells[6].FindControl("mlo")).Text + " , " + Grd_Job.SelectedRow.Cells[3].Text + " , " + Grd_Job.SelectedRow.Cells[7].Text + " , " + Grd_Job.SelectedRow.Cells[8].Text + " , " + Grd_Job.SelectedRow.Cells[5].Text;
                //DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_jobinfo.GetFEJobInfo(int.Parse(txt_job.Text), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                if (obj_dt.Rows.Count > 0)
                {
                    hid_jobtype.Value = obj_dt.Rows[0]["jobtype"].ToString();
                    if (obj_dt.Rows[0]["jobclosedate"].ToString().Trim().Length > 0)
                    {
                        TextBox1.Text = obj_dt.Rows[0]["jobclosedate"].ToString();
                    }
                    hid_intcustomeropsid.Value = obj_dt.Rows[0]["mloid"].ToString();
                }
                obj_dt = obj_da_jobinfo.GetContainerDetails(int.Parse(txt_job.Text), txt_job.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                if (obj_dt.Rows.Count > 0)
                {
                    chk_containerlist.Items.Clear();
                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        chk_containerlist.Items.Add(obj_dt.Rows[i]["containerno"].ToString());
                    }
                }
                else
                {

                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Container Not Available');", true);
                    return;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            // Btn_cancel.Text = "Cancel";


            Btn_cancel.ToolTip = "Cancel";
            Btn_cancel1.Attributes["class"] = "btn ico-cancel";
            UserRights();
        }

        protected void lnk_booking_Click(object sender, EventArgs e)
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
            try
            {


                Grd_Job.Visible = false;
                Grd_Booking.Visible = true;
                //Btn_cancel.Text = "Cancel";

                Btn_cancel.ToolTip = "Cancel";
                Btn_cancel1.Attributes["class"] = "btn ico-cancel";
                //DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
                //DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
                DataTable dt = new DataTable();

                //if (txt_job.Text == "")
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job# cannot be Blank');", true);
                //    return;
                //}
                //obj_dt = obj_da_BL.Bookingdetailsnew(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), Convert.ToInt32(txt_job.Text));

                //if (obj_dt.Rows.Count > 0)
                //{
                //    this.popup_Grd1.Show();
                //    Grd_Booking.DataSource = obj_dt;
                //    Grd_Booking.DataBind();
                //}

                dt = objbu.selpendingBookcustomeridwise(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), 0);
                DataTable dtemptyfree = new DataTable();

                dtemptyfree.Columns.Add("S#");
                dtemptyfree.Columns.Add("Booking#");

                dtemptyfree.Columns.Add("Booking Date");
                dtemptyfree.Columns.Add("PoR");
                dtemptyfree.Columns.Add("PoL");
                dtemptyfree.Columns.Add("PoD");
                dtemptyfree.Columns.Add("PlD");
                dtemptyfree.Columns.Add("Job#");
                dtemptyfree.Columns.Add("Job Type");
                DataRow dr = dtemptyfree.NewRow();
                if (dt.Rows.Count > 0)
                {
                    this.popup_Grd1.Show();
                    pop_up.Hide();
                    //Grd_Booking.Visible = true;
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {

                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["S#"] = dt.Rows[j]["SI"].ToString();
                        dtemptyfree.Rows[j]["Booking#"] = dt.Rows[j]["shiprefno"].ToString();
                        dtemptyfree.Rows[j]["Booking Date"] = dt.Rows[j]["bookingdate"].ToString();
                        dtemptyfree.Rows[j]["PoR"] = dt.Rows[j]["por"].ToString();
                        dtemptyfree.Rows[j]["PoL"] = dt.Rows[j]["pol"].ToString();
                        dtemptyfree.Rows[j]["PoD"] = dt.Rows[j]["pod"].ToString();
                        dtemptyfree.Rows[j]["PlD"] = dt.Rows[j]["fd"].ToString();
                        dtemptyfree.Rows[j]["Job#"] = dt.Rows[j]["job"].ToString();
                        dtemptyfree.Rows[j]["Job Type"] = dt.Rows[j]["jobtype"].ToString();
                    }

                    Grd_Booking.DataSource = dtemptyfree;
                    Grd_Booking.DataBind();


                    ViewState["Grd_Booking"] = dtemptyfree;

                }
                else
                {
                    ScriptManager.RegisterStartupScript(lnk_booking, typeof(LinkButton), "BLDetails", "alertify.alert('Booking Not Avaliable');", true);
                    return;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }


        /*public void bookingdetails()
        {
            DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
            DataAccess.ForwardingExports.BLDetailsWOJob obj_da_BLWojob = new DataAccess.ForwardingExports.BLDetailsWOJob();
            DataAccess.ForwardingExports.JobInfo obj_da_Job = new DataAccess.ForwardingExports.JobInfo();
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dt = new DataTable();
            int countryid; 
            obj_dt = obj_da_BL.GetBookingDt(txt_booking.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));


            if (obj_dt.Rows.Count > 0)
            {
                countryid = Convert.ToInt32(obj_dt.Rows[0]["countryid"].ToString());
                if (obj_dt.Rows[0]["approved"].ToString() == "Y" && countryid==10)
                {
                    ScriptManager.RegisterStartupScript(lnk_booking, typeof(LinkButton), "BLDetails", "alertify.alert('For Agentina Booking kindly get the Approval  from SONIA MAM');", true);

                    return;
                }

                if (lbl_header.Text == "Bill of Lading WOJ" || lbl_header.Text == "Direct Bill of Lading (Liner)")
                {
                    txt_bl.Text = "";
                    txt_bl.ReadOnly = false;
                    //  countryid = Convert.ToInt32(obj_dt.Rows[0]["countryid"].ToString());
                    //if (lbl_header.Text == "Direct Bill of Lading (Liner)")
                    //{
                    //    txt_bl.Text = "";
                    //}
                }
                else
                {
                    //txt_bl.Enabled = false;
                    //txt_bl.Text = obj_dt.Rows[0]["shiprefno"].ToString();
                    //txt_bl.Text = txt_bl.Text.ToUpper();


                    if (countryid == 233)
                    {
                        txt_bl.ReadOnly = true;
                        txt_bl.Text = obj_dt.Rows[0]["shiprefno"].ToString().Remove(4, 4);
                        txt_bl.Text = txt_bl.Text.ToUpper();
                    }
                    else
                    {
                        txt_bl.ReadOnly = true;
                        txt_bl.Text = obj_dt.Rows[0]["shiprefno"].ToString();
                        txt_bl.Text = txt_bl.Text.ToUpper();
                    }

                }

                hid_quto.Value = obj_dt.Rows[0]["quotno"].ToString();
                hid_buyingno.Value = obj_dt.Rows[0]["buyingno"].ToString();
                txt_receipt.Text = obj_dt.Rows[0]["por"].ToString();
                txt_loading.Text = obj_dt.Rows[0]["pol"].ToString();
                txt_discharge.Text = obj_dt.Rows[0]["pod"].ToString();
                txt_destination.Text = obj_dt.Rows[0]["fd"].ToString();
                hid_receiptid.Value = obj_dt.Rows[0]["porid"].ToString();
                hid_loadingid.Value = obj_dt.Rows[0]["polid"].ToString();
                hid_dischargeid.Value = obj_dt.Rows[0]["podid"].ToString();
                hid_destinationid.Value = obj_dt.Rows[0]["fdid"].ToString();
                hid_salesid.Value = obj_dt.Rows[0]["salesid"].ToString();
                if (obj_dt.Rows[0]["customertype"].ToString() == "C")
                {
                    txt_shipper.Text = obj_dt.Rows[0]["shipper"].ToString();
                    txt_shipperaddress.Text = txt_shipper.Text +System.Environment.NewLine + obj_dt.Rows[0]["shipperaddress"].ToString();
                    hid_shipperid.Value = obj_dt.Rows[0]["customerid"].ToString();
                    hid_intcustomerid.Value = hid_shipperid.Value;
                }
                else
                {
                    txt_shipper.Text = "";
                    txt_shipperaddress.Text = "";
                    hid_shipperid.Value = "0";
                }
                txt_description.Text = obj_dt.Rows[0]["descn"].ToString();
                if (obj_dt.Rows[0]["hazardous"].ToString() == "1")
                {
                    Chk_DG.Checked = true;
                }
                else
                {
                    Chk_DG.Checked = false;
                }
                if (obj_dt.Rows[0]["Business"].ToString() == "A")
                {
                    chk_agent.Checked = true;
                    chk_agent.Enabled = false;
                }
                else
                {
                    chk_agent.Checked = false;
                    chk_agent.Enabled = false;
                }
                //Btn_cancel.Text = "Cancel";

                Btn_cancel.ToolTip = "Cancel";
                Btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            else
            {
                txt_receipt.Text = "";
                txt_loading.Text = "";
                txt_discharge.Text = "";
                txt_destination.Text = "";
                txt_description.Text = "";
                hid_receiptid.Value = "0";
                hid_loadingid.Value = "0";
                hid_dischargeid.Value = "0";
                hid_destinationid.Value = "0";
                txt_shipper.Text = "";
                txt_shipperaddress.Text = "";
                hid_shipperid.Value = "0";
            }
            obj_dt = null;

            obj_dt = obj_da_BL.GetPOnoFromBookingno(txt_booking.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
            string str_temp = "";
            if (obj_dt.Rows.Count > 0)
            {
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    str_temp = str_temp + obj_dt.Rows[i]["pono"].ToString().Trim();
                }
                txt_description.Text = str_temp;
            }
            obj_dt = null;

            if (txt_bl.Text.Trim().Length > 0)
            {
                //if (lbl_Header.Text == "Our BL" || lbl_Header.Text == "Direct Bill of Lading (Liner)")
                if (lbl_header.Text == "Our BL" || lbl_header.Text == "Direct Bill of Lading (Liner)")
                {
                    obj_dt = obj_da_BLWojob.GeBLDetailsWOJ(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    DataView obj_dtview = new DataView(obj_dt);
                    obj_dtview.RowFilter = "blno='" + txt_bl.Text + "'";
                    obj_dt = obj_dtview.ToTable();
                    if (obj_dt.Rows.Count > 0)
                    {
                        hid_WojBLno.Value = txt_bl.Text.ToUpper();
                        Fn_GetWojBLdetail();
                        //Btn_save.Text = "Save";

                        Btn_save.ToolTip = "Save";
                        Btn_save1.Attributes["class"] = "btn ico-save";
                        return;
                    }
                    Fn_GetBLdetail();
                    obj_dt = null;
                    obj_dt = obj_da_BL.GetBLDetails1(txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_job.Text = obj_dt.Rows[0][0].ToString();
                        hid_job.Value = txt_job.Text;
                    }
                    if (txt_job.Text.Trim().Length > 0)
                    {
                        if (hid_job.Value.ToString() == txt_job.Text)
                        {
                            chk_containerlist.Items.Clear();
                            DataTable obj_dttemp = new DataTable();
                            obj_dt = obj_da_Job.GetContainerDetails(int.Parse(txt_job.Text), txt_job.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                            obj_dttemp = obj_da_Job.GetContainerDetails(int.Parse(txt_job.Text), txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                            {
                                chk_containerlist.Items.Add(obj_dt.Rows[i][0].ToString());
                                for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                                {
                                    if (obj_dt.Rows[i][0].ToString() == obj_dttemp.Rows[j][0].ToString())
                                    {
                                        chk_containerlist.Items[i].Selected = true;
                                    }
                                }
                            }

                        }
                    }

                    //if (btndelete == true)
                    //{
                    //    if (txt_bl.Text.Trim().Length > 0)
                    //    {
                    //        Btn_delete_Click(sender, e);
                    //    }
                    //}
                }
                else
                {
                    Fn_GetWojBLdetail();
                    txt_vessel.Focus();
                }
            }
            //txt_bl.Focus();
            UserRights();
        }

        */

        public void bookingdetails()
        {
            //DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
            //DataAccess.ForwardingExports.BLDetailsWOJob obj_da_BLWojob = new DataAccess.ForwardingExports.BLDetailsWOJob();
            //DataAccess.ForwardingExports.JobInfo obj_da_Job = new DataAccess.ForwardingExports.JobInfo();
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dt = new DataTable();
            int countryid;
            obj_dt = obj_da_BL.GetBookingDt(txt_booking.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));


            if (obj_dt.Rows.Count > 0)
            {
                countryid = Convert.ToInt32(obj_dt.Rows[0]["countryid"].ToString());
                if (lbl_header.Text == "Bill of Lading WOJ" || lbl_header.Text == "Direct Bill of Lading (Liner)")
                {
                    txt_bl.Text = "";
                    txt_bl.ReadOnly = false;
                    //  countryid = Convert.ToInt32(obj_dt.Rows[0]["countryid"].ToString());
                    //if (lbl_header.Text == "Direct Bill of Lading (Liner)")
                    //{
                    //    txt_bl.Text = "";
                    //}
                }
                else
                {
                    //txt_bl.Enabled = false;
                    //txt_bl.Text = obj_dt.Rows[0]["shiprefno"].ToString();
                    //txt_bl.Text = txt_bl.Text.ToUpper();


                    /* if (countryid == 233)
                     {
                         txt_bl.ReadOnly = true;
                         txt_bl.Text = obj_dt.Rows[0]["shiprefno"].ToString().Remove(4, 4);
                         txt_bl.Text = txt_bl.Text.ToUpper();
                     }
                     else
                     {
                         txt_bl.ReadOnly = true;
                         txt_bl.Text = obj_dt.Rows[0]["shiprefno"].ToString();
                         txt_bl.Text = txt_bl.Text.ToUpper();
                     }*/


                    txt_bl.ReadOnly = true;
                    txt_bl.Text = obj_dt.Rows[0]["shiprefno"].ToString();
                    txt_bl.Text = txt_bl.Text.ToUpper();

                }

                hid_quto.Value = obj_dt.Rows[0]["quotno"].ToString();
                hid_buyingno.Value = obj_dt.Rows[0]["buyingno"].ToString();
                txt_receipt.Text = obj_dt.Rows[0]["por"].ToString();
                txt_loading.Text = obj_dt.Rows[0]["pol"].ToString();
                txt_discharge.Text = obj_dt.Rows[0]["pod"].ToString();
                txt_destination.Text = obj_dt.Rows[0]["fd"].ToString();
                hid_receiptid.Value = obj_dt.Rows[0]["porid"].ToString();
                hid_loadingid.Value = obj_dt.Rows[0]["polid"].ToString();
                hid_dischargeid.Value = obj_dt.Rows[0]["podid"].ToString();
                hid_destinationid.Value = obj_dt.Rows[0]["fdid"].ToString();
                hid_salesid.Value = obj_dt.Rows[0]["salesid"].ToString();
                ddl_freight.SelectedValue = obj_dt.Rows[0]["fstatus"].ToString();
                DataTable dt;
                //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                dt = obj_MasterPort.SelPortName4typepadimg(txt_destination.Text.ToUpper(), Session["StrTranType"].ToString());
                fdflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                dt = obj_MasterPort.SelPortName4typepadimg(txt_receipt.Text.ToUpper(), Session["StrTranType"].ToString());
                porflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                dt = obj_MasterPort.SelPortName4typepadimg(txt_discharge.Text.ToUpper(), Session["StrTranType"].ToString());
                podflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                dt = obj_MasterPort.SelPortName4typepadimg(txt_loading.Text.ToUpper(), Session["StrTranType"].ToString());
                flagimg.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                //dt = obj_MasterPort.SelPortName4typepadimg(txt_issued.Text.ToUpper(), Session["StrTranType"].ToString());
                //issuedflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                if (obj_dt.Rows[0]["customertype"].ToString() == "C")
                {
                    txt_shipper.Text = obj_dt.Rows[0]["shipper"].ToString();
                    txt_shipperaddress.Text = txt_shipper.Text + System.Environment.NewLine + obj_dt.Rows[0]["shipperaddress"].ToString();
                    hid_shipperid.Value = obj_dt.Rows[0]["customerid"].ToString();
                    hid_intcustomerid.Value = hid_shipperid.Value;
                }
                else
                {
                    txt_shipper.Text = "";
                    txt_shipperaddress.Text = "";
                    hid_shipperid.Value = "0";
                }
                txt_commotity.Text = obj_dt.Rows[0]["cargotype"].ToString();
                hid_cargoid.Value = obj_dt.Rows[0]["cargoid"].ToString();

                if (obj_dt.Rows[0]["agentcustomertype"].ToString() == "P")
                {
                    txt_agent.Text = obj_dt.Rows[0]["agent"].ToString();
                    txt_agentaddress.Text = txt_agent.Text + System.Environment.NewLine + obj_dt.Rows[0]["agentaddress"].ToString();
                    hid_agentid.Value = obj_dt.Rows[0]["agentid"].ToString();

                }
                else
                {
                    txt_agent.Text = "";
                    txt_agentaddress.Text = "";
                    hid_agentid.Value = "0";
                }


                if (obj_dt.Rows[0]["consigneecustomertype"].ToString() == "C")
                {
                    txt_consignee.Text = obj_dt.Rows[0]["consignee"].ToString();
                    txt_consigneeaddress.Text = txt_consignee.Text + System.Environment.NewLine + obj_dt.Rows[0]["consigneeaddress"].ToString();
                    hid_consigneeid.Value = obj_dt.Rows[0]["consigneeid"].ToString();

                }
                else
                {
                    txt_consignee.Text = "";
                    txt_consigneeaddress.Text = "";
                    hid_consigneeid.Value = "0";
                }



                txt_description.Text = obj_dt.Rows[0]["descn"].ToString();
                if (obj_dt.Rows[0]["hazardous"].ToString() == "1")
                {
                    Chk_DG.Checked = true;
                }
                else
                {
                    Chk_DG.Checked = false;
                }
                if (obj_dt.Rows[0]["Business"].ToString() == "A")
                {
                    chk_agent.Checked = true;
                    chk_agent.Enabled = false;
                }
                else
                {
                    chk_agent.Checked = false;
                    chk_agent.Enabled = false;
                }
                //Btn_cancel.Text = "Cancel";
                if (obj_dt.Rows[0]["movetype"].ToString() != "")
                {
                    ddl_move.SelectedValue = obj_dt.Rows[0]["movetype"].ToString();
                }


                Btn_cancel.ToolTip = "Cancel";
                Btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            else
            {
                txt_receipt.Text = "";
                txt_loading.Text = "";
                txt_discharge.Text = "";
                txt_destination.Text = "";
                txt_description.Text = "";
                hid_receiptid.Value = "0";
                hid_loadingid.Value = "0";
                hid_dischargeid.Value = "0";
                hid_destinationid.Value = "0";
                txt_shipper.Text = "";
                txt_shipperaddress.Text = "";
                hid_shipperid.Value = "0";
            }
            obj_dt = null;

            obj_dt = obj_da_BL.GetPOnoFromBookingno(txt_booking.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
            string str_temp = "";
            if (obj_dt.Rows.Count > 0)
            {
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    str_temp = str_temp + obj_dt.Rows[i]["pono"].ToString().Trim();
                }
                txt_description.Text = str_temp;
            }
            obj_dt = null;

            if (txt_bl.Text.Trim().Length > 0)
            {
                //if (lbl_Header.Text == "Our BL" || lbl_Header.Text == "Direct Bill of Lading (Liner)")
                if (lbl_header.Text == "Our BL" || lbl_header.Text == "Direct Bill of Lading (Liner)")
                {
                    obj_dt = obj_da_BLWojob.GeBLDetailsWOJ(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    DataView obj_dtview = new DataView(obj_dt);
                    obj_dtview.RowFilter = "blno='" + txt_bl.Text + "'";
                    obj_dt = obj_dtview.ToTable();
                    if (obj_dt.Rows.Count > 0)
                    {
                        hid_WojBLno.Value = txt_bl.Text.ToUpper();
                        Fn_GetWojBLdetail();
                        //Btn_save.Text = "Save";

                        Btn_save.ToolTip = "Save";
                        Btn_save1.Attributes["class"] = "btn ico-save";
                        return;
                    }
                    Fn_GetBLdetail();
                    obj_dt = null;
                    obj_dt = obj_da_BL.GetBLDetails1(txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_job.Text = obj_dt.Rows[0][0].ToString();
                        hid_job.Value = txt_job.Text;
                    }
                    if (txt_job.Text.Trim().Length > 0)
                    {
                        if (hid_job.Value.ToString() == txt_job.Text)
                        {
                            chk_containerlist.Items.Clear();
                            DataTable obj_dttemp = new DataTable();
                            obj_dt = obj_da_Job.GetContainerDetails(int.Parse(txt_job.Text), txt_job.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                            obj_dttemp = obj_da_Job.GetContainerDetails(int.Parse(txt_job.Text), txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                            {
                                chk_containerlist.Items.Add(obj_dt.Rows[i][0].ToString());
                                for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                                {
                                    if (obj_dt.Rows[i][0].ToString() == obj_dttemp.Rows[j][0].ToString())
                                    {
                                        chk_containerlist.Items[i].Selected = true;
                                    }
                                }
                            }

                        }
                    }

                    //if (btndelete == true)
                    //{
                    //    if (txt_bl.Text.Trim().Length > 0)
                    //    {
                    //        Btn_delete_Click(sender, e);
                    //    }
                    //}

                }
                else
                {
                    Fn_GetWojBLdetail();
                    txt_vessel.Focus();
                }
            }
            //txt_bl.Focus();
            UserRights();
        }


        protected void txt_cbm_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double check1 = 0;
                if (double.TryParse(txt_cbm.Text, out check1))
                {

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please enter Numeric value');", true);
                    txt_cbm.Text = "";
                    txt_cbm.Focus();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please enter Numeric');", true);
            }
        }



        protected void txt_grwt_TextChanged(object sender, EventArgs e)
        {
            double check12 = 0;
            if (double.TryParse(txt_grwt.Text, out check12))
            {
                txt_ntwt.Text = txt_grwt.Text;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please enter Numeric value');", true);
                txt_grwt.Text = "";
                txt_grwt.Focus();
            }

        }


        protected void Grd_Booking_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                popup_Grd1.Hide();
                txt_booking.Text = Grd_Booking.SelectedRow.Cells[1].Text;
                bookingdetails();
                if (Grd_Booking.SelectedRow.Cells[7].Text != "0")
                {

                    txt_job.Text = Grd_Booking.SelectedRow.Cells[7].Text;
                    //DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                    DataTable obj_dt = new DataTable();
                    obj_dt = obj_da_jobinfo.GetFEJobInfo(int.Parse(Grd_Booking.SelectedRow.Cells[7].Text), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    if (obj_dt.Rows.Count > 0)
                    {
                        vessel.Text = obj_dt.Rows[0]["vessel"].ToString();


                        eta.Text = obj_dt.Rows[0]["eta"].ToString();
                        eta.Text = Convert.ToDateTime(eta.Text).ToString("dd/MM/yyyy");
                        etd.Text = obj_dt.Rows[0]["etd"].ToString();
                        etd.Text = Convert.ToDateTime(etd.Text).ToString("dd/MM/yyyy");
                        mlo.Text = obj_dt.Rows[0]["mlo"].ToString();
                        mbl.Text = obj_dt.Rows[0]["mblno"].ToString();
                        pol.Text = obj_dt.Rows[0]["pol"].ToString();
                        pod.Text = obj_dt.Rows[0]["pod"].ToString();
                        carrier.Text = obj_dt.Rows[0]["carrier"].ToString();
                        txtcontract.Text = obj_dt.Rows[0]["con"].ToString();
                        if (obj_dt.Rows[0]["mblstatus"].ToString() == "R")
                        {
                            mblstatus.Text = "Release";
                        }
                        else if (obj_dt.Rows[0]["mblstatus"].ToString() == "B")
                        {
                            mblstatus.Text = "SeaWayBill";
                        }
                        else if (obj_dt.Rows[0]["mblstatus"].ToString() == "S")
                        {
                            mblstatus.Text = "Surrendered";
                        }


                        if (obj_dt.Rows[0]["jobtype"].ToString() == "1")
                        {
                            txt_jobtype.Text = "Consol";
                        }
                        else if (obj_dt.Rows[0]["jobtype"].ToString() == "2")
                        {
                            txt_jobtype.Text = "LCL";
                        }
                        else if (obj_dt.Rows[0]["jobtype"].ToString() == "3")
                        {
                            txt_jobtype.Text = "FCL";
                        }
                        else if (obj_dt.Rows[0]["jobtype"].ToString() == "4")
                        {
                            txt_jobtype.Text = "MCC";
                        }
                        else if (obj_dt.Rows[0]["jobtype"].ToString() == "5")
                        {
                            txt_jobtype.Text = "Buyer Consol";
                        }
                        //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                        txt_agent.Text = obj_dt.Rows[0]["agent"].ToString();
                        hid_agentid.Value = obj_dt.Rows[0]["agentid"].ToString();
                        txt_agentaddress.Text = txt_agent.Text + System.Environment.NewLine + obj_da_Customer.GetCustomerAddress(txt_agent.Text, "Agent", obj_da_Customer.GetCustlocation(int.Parse(hid_agentid.Value.ToString()))).ToString();
                        txt_detail.Text = obj_dt.Rows[0]["vessel"].ToString() + " , " + obj_dt.Rows[0]["sd"].ToString() + " , " + obj_dt.Rows[0]["mlo"].ToString() + " , " + obj_dt.Rows[0]["voyage"].ToString() + " , " + obj_dt.Rows[0]["etd"].ToString() + " , " + obj_dt.Rows[0]["eta"].ToString() + " , " + obj_dt.Rows[0]["mblno"].ToString();
                        hid_jobtype.Value = obj_dt.Rows[0]["jobtype"].ToString();
                        hid_intcustomeropsid.Value = obj_dt.Rows[0]["mloid"].ToString();
                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Select Atleast One Container');", true);
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job Not Available');", true);
                        return;
                    }
                    obj_dt = obj_da_jobinfo.GetContainerDetails(int.Parse(txt_job.Text), txt_job.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    if (obj_dt.Rows.Count > 0)
                    {
                        chk_containerlist.Items.Clear();
                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            chk_containerlist.Items.Add(obj_dt.Rows[i]["containerno"].ToString());
                        }
                    }
                    else
                    {

                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Container Not Available');", true);
                        return;
                    }
                    if (hid_intcustomerid.Value != "")
                    {
                        dtcust = obj_da_BL.GetCreditApprovalFromCustomer(Convert.ToInt32(hid_intcustomerid.Value));
                    }
                    //if (dtcust.Rows.Count > 0) --as per nambi sir instruction hided on 18july2022
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                    //    Btn_save.Visible = false;
                    //    return;

                    //}
                    if (txt_bl.Text.Trim().Length > 0)
                    {
                        if (lbl_header.Text == "Bill of Lading" || lbl_header.Text == "Direct Bill of Lading (Liner)")
                        {
                            if (btndelete == true)
                            {
                                if (txt_bl.Text.Trim().Length > 0)
                                {
                                    Btn_delete_Click(sender, e);
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

        [WebMethod]
        public static List<string> GetBLdetail(string prefix)
        {

            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_BL.GetDataBase(Ccode);
            //DataAccess.ForwardingExports.BLDetailsWOJob obj_da_BLWojob = new DataAccess.ForwardingExports.BLDetailsWOJob();
            //if (HttpContext.Current.Session["FromName"].ToString() == "BILL OF LADING WOJ")
            //{
            //    obj_dt = obj_da_BLWojob.GetLikeBLDetailsWOJ(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            //}
            //else
            //{
            obj_dt = obj_da_BL.GetLikeBLDetails(prefix.ToUpper().Trim(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            //}
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "blno");
            return List_Result;
        }

        private void Fn_GetWojBLdetail()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                //DataAccess.ForwardingExports.BLDetailsWOJob obj_da_BLWojob = new DataAccess.ForwardingExports.BLDetailsWOJob();
                //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                obj_dt = obj_da_BLWojob.GetBLDetWOJob(txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                if (obj_dt.Rows.Count > 0)
                {
                    txt_issued.Text = obj_dt.Rows[0]["blissuedat"].ToString();
                    txt_issuedon.Text = obj_dt.Rows[0]["bldateweb"].ToString();
                    txt_shipperaddress.Text = obj_dt.Rows[0]["saddress"].ToString();
                    txt_consigneeaddress.Text = obj_dt.Rows[0]["caddress"].ToString();
                    txt_notifyaddress.Text = obj_dt.Rows[0]["naddress"].ToString();
                    txt_mark.Text = obj_dt.Rows[0]["marks"].ToString();
                    txt_description.Text = obj_dt.Rows[0]["descn"].ToString();
                    txt_grwt.Text = obj_dt.Rows[0]["grweight"].ToString();
                    txt_ntwt.Text = obj_dt.Rows[0]["ntweight"].ToString();
                    txt_cbm.Text = obj_dt.Rows[0]["cbm"].ToString();
                    hid_cbm.Value = obj_dt.Rows[0]["cbm"].ToString();
                    txt_pkgs.Text = obj_dt.Rows[0]["noofpkgs"].ToString();
                    hid_cbm.Value = obj_dt.Rows[0]["cbm"].ToString();
                    ddl_unit.SelectedValue = obj_dt.Rows[0]["unit"].ToString();
                    txt_receipt.Text = obj_dt.Rows[0]["por"].ToString();
                    txt_loading.Text = obj_dt.Rows[0]["pol"].ToString();
                    txt_discharge.Text = obj_dt.Rows[0]["pod"].ToString();
                    txt_destination.Text = obj_dt.Rows[0]["fd"].ToString();
                    txt_remark.Text = obj_dt.Rows[0]["remarks"].ToString();
                    if (string.IsNullOrEmpty(obj_dt.Rows[0]["cargoname"].ToString()) == false)
                    {
                        txt_commotity.Text = obj_dt.Rows[0]["cargoname"].ToString();
                        hid_cargoid.Value = (cargoobj.GetCargoid(txt_commotity.Text)).ToString();
                    }
                    string str_vessel = obj_dt.Rows[0]["vessvoy"].ToString();
                    txt_vessel.Text = str_vessel.Substring(0, str_vessel.IndexOf("V."));

                    txt_voyage.Text = str_vessel.Substring(str_vessel.IndexOf(" V. ") + 4, str_vessel.Length - (str_vessel.IndexOf(" V. ") + 4));
                    //txt_container.Text = obj_dt.Rows[0]["container"].ToString();
                    txt_agent.Text = obj_dt.Rows[0]["agent"].ToString();
                    hid_shipperid.Value = obj_dt.Rows[0]["shipperid"].ToString();
                    txt_shipper.Text = obj_dt.Rows[0]["shippername"].ToString();
                    txt_consignee.Text = obj_dt.Rows[0]["consignename"].ToString();
                    txt_notify.Text = obj_dt.Rows[0]["notifyname"].ToString();
                    hid_agentid.Value = obj_dt.Rows[0]["deliveryagent"].ToString();
                    txt_agentaddress.Text = txt_agent.Text + System.Environment.NewLine + obj_da_Customer.GetCustomerAddress(txt_agent.Text, "Agent", obj_da_Customer.GetCustlocation(int.Parse(hid_agentid.Value.ToString()))).ToString();
                    txt_cha.Text = obj_dt.Rows[0]["cnfname"].ToString();
                    hid_chaid.Value = obj_dt.Rows[0]["cnf"].ToString();
                    hid_issued.Value = obj_dt.Rows[0]["blissuedat1"].ToString();
                    hid_receiptid.Value = obj_dt.Rows[0]["porid"].ToString();
                    hid_loadingid.Value = obj_dt.Rows[0]["polid"].ToString();
                    hid_dischargeid.Value = obj_dt.Rows[0]["podid"].ToString();
                    hid_destinationid.Value = obj_dt.Rows[0]["fdid"].ToString();
                    ddl_freight.SelectedValue = obj_dt.Rows[0]["freight"].ToString();
                    ddl_shipment.SelectedValue = obj_dt.Rows[0]["shipment"].ToString();
                    hid_shipperid.Value = obj_dt.Rows[0]["shipperid"].ToString();
                    hid_consigneeid.Value = obj_dt.Rows[0]["consigneeid"].ToString();
                    hid_notifyid.Value = obj_dt.Rows[0]["notifypartyid"].ToString();
                    hid_agentid.Value = obj_dt.Rows[0]["deliveryagent"].ToString();
                    if (obj_dt.Rows[0]["dgcargo"].ToString() == "Y")
                    {
                        Chk_DG.Checked = true;
                    }
                    else
                    {
                        Chk_DG.Checked = false;
                    }
                    if (obj_dt.Rows[0]["ourbl"].ToString() == "Y")
                    {
                        BLTYPE.SelectedIndex = 1;
                    }
                    else if (obj_dt.Rows[0]["ourbl"].ToString() == "N")
                    {
                        BLTYPE.SelectedIndex = 2;
                    }

                    if (obj_dt.Rows[0]["nomination"].ToString() == "N")
                    {
                        chk_agent.Checked = true;
                    }
                    else
                    {
                        chk_agent.Checked = false;
                    }
                    ddl_BLsignatory.SelectedValue = obj_dt.Rows[0]["sign"].ToString();
                    if (obj_dt.Rows[0]["surrendered"].ToString() == "S" || obj_dt.Rows[0]["surrendered"].ToString() == "B")
                    {
                        ddl_HTS.SelectedValue = obj_dt.Rows[0]["surrendered"].ToString();
                    }
                    else
                    {
                        ddl_HTS.SelectedValue = "R";
                    }
                    //Btn_save.Text = "Update";

                    Btn_save.ToolTip = "Update";
                    Btn_save1.Attributes["class"] = "btn ico-update";
                    // Btn_cancel.Text = "Cancel";
                    Btn_cancel.ToolTip = "Cancel";
                    Btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    // Fn_Clear_Bltxt();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void Fn_GetBLdetail()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                //DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
                //DataAccess.ForwardingExports.JobInfo obj_da_Jobinfo = new DataAccess.ForwardingExports.JobInfo();
                //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();

                // obj_dt = obj_da_BL.GetBLDetails1(txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                obj_dt = obj_da_BL.GetBLDetails(txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                if (obj_dt.Rows.Count > 0)
                {
                    txt_job.Text = obj_dt.Rows[0]["jobno"].ToString();
                    txt_issued.Text = obj_dt.Rows[0]["issuedat"].ToString();
                    
                    
                    txt_issuedon.Text = (Convert.ToDateTime(obj_dt.Rows[0]["issuedon"])).ToString("dd/MM/yyyy");

                    txt_shipper.Text = obj_dt.Rows[0]["sname"].ToString();
                    txt_shipperaddress.Text = obj_dt.Rows[0]["sadd"].ToString();
                    txt_consignee.Text = obj_dt.Rows[0]["conname"].ToString();
                    txt_consigneeaddress.Text = obj_dt.Rows[0]["cadd"].ToString();
                    txt_notify.Text = obj_dt.Rows[0]["nname"].ToString();
                    txt_notifyaddress.Text = obj_dt.Rows[0]["nadd"].ToString();
                    txt_mark.Text = obj_dt.Rows[0]["marks"].ToString();
                    txt_description.Text = obj_dt.Rows[0]["descn"].ToString();
                    txt_grwt.Text = obj_dt.Rows[0]["grweight"].ToString();
                    txt_ntwt.Text = obj_dt.Rows[0]["netw"].ToString();
                    txt_cbm.Text = obj_dt.Rows[0]["cbm"].ToString();
                    hid_cbm.Value = obj_dt.Rows[0]["cbm"].ToString();
                    txt_pkgs.Text = obj_dt.Rows[0]["noofpkgs"].ToString();
                    hid_cbm.Value = obj_dt.Rows[0]["cbm"].ToString();

                    txt_receipt.Text = obj_dt.Rows[0]["por"].ToString();
                    txt_loading.Text = obj_dt.Rows[0]["pol"].ToString();
                    txt_discharge.Text = obj_dt.Rows[0]["pod"].ToString();
                    txt_destination.Text = obj_dt.Rows[0]["fd"].ToString();

                    DataTable dt;
                    //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                    dt = obj_MasterPort.SelPortName4typepadimg(txt_destination.Text.ToUpper(), Session["StrTranType"].ToString());
                    fdflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    dt = obj_MasterPort.SelPortName4typepadimg(txt_receipt.Text.ToUpper(), Session["StrTranType"].ToString());
                    porflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    dt = obj_MasterPort.SelPortName4typepadimg(txt_discharge.Text.ToUpper(), Session["StrTranType"].ToString());
                    podflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    dt = obj_MasterPort.SelPortName4typepadimg(txt_loading.Text.ToUpper(), Session["StrTranType"].ToString());
                    flagimg.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    dt = obj_MasterPort.SelPortName4typepadimg(txt_issued.Text.ToUpper(), Session["StrTranType"].ToString());
                    issuedflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";


                    txt_remark.Text = obj_dt.Rows[0]["remarks"].ToString();
                    txt_orignalbl.Text = obj_dt.Rows[0]["oribls"].ToString();
                    if (!string.IsNullOrEmpty(obj_dt.Rows[0]["movetype"].ToString()))
                    {
                        ddl_move.SelectedValue = obj_dt.Rows[0]["movetype"].ToString();
                    }
                    if ((obj_dt.Rows[0]["cargoid"].ToString()) != "")
                    {
                        //  txt_commotity.Text = obj_dt.Rows[0]["cargoname"].ToString();
                        int IntCOMMODITY = Convert.ToInt32(obj_dt.Rows[0]["cargoid"].ToString());
                        txt_commotity.Text = cargoobj.GetCargoname(IntCOMMODITY);
                    }



                    txt_agent.Text = obj_dt.Rows[0]["agent"].ToString();
                    hid_shipperid.Value = obj_dt.Rows[0]["shipperid"].ToString();
                    // txt_shipper.Text = obj_dt.Rows[0]["shippername"].ToString();
                    //  txt_consignee.Text = obj_dt.Rows[0]["consignename"].ToString();
                    int intnotifyid = Convert.ToInt32(obj_dt.Rows[0]["notIFypartyid"].ToString());
                    txt_notify.Text = customerobj.GetCustomername(intnotifyid);
                    hid_agentid.Value = obj_dt.Rows[0]["deliveryagent"].ToString();
                    txt_agentaddress.Text = txt_agent.Text + System.Environment.NewLine + obj_da_Customer.GetCustomerAddress(txt_agent.Text, "Agent", obj_da_Customer.GetCustlocation(int.Parse(hid_agentid.Value.ToString()))).ToString();
                    txt_cha.Text = obj_dt.Rows[0]["cha"].ToString();
                    hid_chaid.Value = obj_dt.Rows[0]["cnf"].ToString();
                    hid_cargoid.Value = obj_dt.Rows[0]["cargoid"].ToString();
                    hid_issued.Value = obj_dt.Rows[0]["blissuedat"].ToString();
                    hid_receiptid.Value = obj_dt.Rows[0]["porid"].ToString();
                    hid_loadingid.Value = obj_dt.Rows[0]["polid"].ToString();
                    hid_dischargeid.Value = obj_dt.Rows[0]["podid"].ToString();
                    hid_destinationid.Value = obj_dt.Rows[0]["fdid"].ToString();
                    ddl_freight.SelectedValue = obj_dt.Rows[0]["freight"].ToString();
                    ddl_shipment.SelectedValue = obj_dt.Rows[0]["shipment"].ToString();
                    hid_branchid.Value = obj_dt.Rows[0]["branchid"].ToString();
                    hid_shipperid.Value = obj_dt.Rows[0]["shipperid"].ToString();
                    hid_consigneeid.Value = obj_dt.Rows[0]["consigneeid"].ToString();
                    hid_notifyid.Value = obj_dt.Rows[0]["notifypartyid"].ToString();
                    hid_agentid.Value = obj_dt.Rows[0]["deliveryagent"].ToString();
                    //new
                    if (!string.IsNullOrEmpty(obj_dt.Rows[0]["agentaddress"].ToString()))
                    {
                        txt_agentaddress.Text = obj_dt.Rows[0]["agentaddress"].ToString();
                    }
                    if (obj_dt.Rows[0]["ourbl"].ToString() == "Y")
                    {
                        BLTYPE.SelectedIndex = 2;
                        BLTYPE.Enabled = false;
                        lbl_header.Text = "Direct Bill of Lading (Liner)";
                    }
                    else if (obj_dt.Rows[0]["ourbl"].ToString() == "N")
                    {
                        BLTYPE.SelectedIndex = 1;
                        BLTYPE.Enabled = false;
                        lbl_header.Text = "Our BL";
                    }
                    if (obj_dt.Rows[0]["dgcargo"].ToString() == "Y")
                    {
                        Chk_DG.Checked = true;
                    }
                    else
                    {
                        Chk_DG.Checked = false;
                    }

                    if (obj_dt.Rows[0]["nomination"].ToString() == "N")
                    {
                        chk_agent.Checked = true;
                    }
                    else
                    {
                        chk_agent.Checked = false;
                    }
                    ddl_BLsignatory.SelectedValue = obj_dt.Rows[0]["sign"].ToString();
                    ddl_unit.SelectedValue = obj_dt.Rows[0]["units"].ToString();
                    if (obj_dt.Rows[0]["surrendered"].ToString() == "S" || obj_dt.Rows[0]["surrendered"].ToString() == "B")
                    {
                        ddl_HTS.SelectedValue = obj_dt.Rows[0]["surrendered"].ToString();
                    }
                    else
                    {
                        ddl_HTS.SelectedValue = "R";
                    }

                    obj_dt = null;
                    obj_dt = obj_da_Jobinfo.GetFEJobInfo(int.Parse(txt_job.Text), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_detail.Text = obj_dt.Rows[0]["vessel"].ToString() + " , " + obj_dt.Rows[0]["sd"].ToString() + " , " + obj_dt.Rows[0]["mlo"].ToString() + " , " + obj_dt.Rows[0]["voyage"].ToString() + " , " + obj_dt.Rows[0]["etd"].ToString() + " , " + obj_dt.Rows[0]["eta"].ToString() + " , " + obj_dt.Rows[0]["mblno"].ToString();
                        hid_jobtype.Value = obj_dt.Rows[0]["jobtype"].ToString();
                    }
                    txt_booking.Text = obj_da_BL.GetBookinkNo(txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_dt = null;
                    obj_dt = obj_da_BL.GetBookingDt(txt_booking.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    if (obj_dt.Rows.Count > 0)
                    {
                        hid_salesid.Value = obj_dt.Rows[0]["salesid"].ToString();
                        hid_intcustomerid.Value = obj_dt.Rows[0][13].ToString();
                        if (obj_dt.Rows[0]["hazardous"].ToString() == "1")
                        {
                            Chk_DG.Checked = true;
                        }
                        else
                        {
                            Chk_DG.Checked = false;
                        }
                    }

                    // Btn_save.Text = "Update";
                    // Btn_cancel.Text = "Cancel";

                    Btn_save.ToolTip = "Update";
                    Btn_save1.Attributes["class"] = "btn ico-update";

                    Btn_cancel.ToolTip = "Cancel";
                    Btn_cancel1.Attributes["class"] = "btn ico-cancel";

                    obj_dt = null;
                    int i;
                    for (i = 0; i <= 6; i++)
                    {
                        obj_dt = obj_da_Invoice.CheckIPDCWBL(txt_bl.Text, "FE", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["Vouyear"].ToString()), i, "CBM");
                        if (obj_dt.Rows.Count > 0)
                        {
                            txt_cbm.Enabled = false;
                            return;
                        }
                        else
                        {
                            txt_cbm.Enabled = true;
                        }
                    }
                    for (i = 0; i <= 6; i++)
                    {
                        obj_dt = obj_da_Invoice.CheckIPDCWBL(txt_bl.Text, "FE", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["Vouyear"].ToString()), i, "MT");
                        if (obj_dt.Rows.Count > 0)
                        {
                            txt_grwt.Enabled = false;
                            txt_ntwt.Enabled = false;
                            return;
                        }
                        else
                        {
                            txt_grwt.Enabled = true;
                            txt_ntwt.Enabled = true;
                        }
                    }

                }
                else
                {
                    if (txt_receipt.Text.Length > 0 && txt_consignee.Text.Length > 0 && txt_issued.Text.Length > 0 && txt_destination.Text.Length > 0)
                    {
                        Fn_Clear_Bltxt();
                    }
                    txt_issued.Focus();
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }






        private void Fn_GetBLdetailreuse()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                //DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
                //DataAccess.ForwardingExports.JobInfo obj_da_Jobinfo = new DataAccess.ForwardingExports.JobInfo();
                //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();

                // obj_dt = obj_da_BL.GetBLDetails1(txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                obj_dt = obj_da_BL.GetBLDetails(txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                if (obj_dt.Rows.Count > 0)
                {
                    //txt_job.Text = obj_dt.Rows[0]["jobno"].ToString();
                    txt_issued.Text = obj_dt.Rows[0]["issuedat"].ToString();
                    txt_issuedon.Text = (Convert.ToDateTime(obj_dt.Rows[0]["issuedon"])).ToString("dd/MM/yyyy");

                    txt_shipper.Text = obj_dt.Rows[0]["sname"].ToString();
                    txt_shipperaddress.Text = obj_dt.Rows[0]["sadd"].ToString();
                    txt_consignee.Text = obj_dt.Rows[0]["conname"].ToString();
                    txt_consigneeaddress.Text = obj_dt.Rows[0]["cadd"].ToString();
                    txt_notify.Text = obj_dt.Rows[0]["nname"].ToString();
                    txt_notifyaddress.Text = obj_dt.Rows[0]["nadd"].ToString();
                    txt_mark.Text = obj_dt.Rows[0]["marks"].ToString();
                    txt_description.Text = obj_dt.Rows[0]["descn"].ToString();
                    txt_grwt.Text = obj_dt.Rows[0]["grweight"].ToString();
                    txt_ntwt.Text = obj_dt.Rows[0]["netw"].ToString();
                    txt_cbm.Text = obj_dt.Rows[0]["cbm"].ToString();
                    hid_cbm.Value = obj_dt.Rows[0]["cbm"].ToString();
                    txt_pkgs.Text = obj_dt.Rows[0]["noofpkgs"].ToString();
                    hid_cbm.Value = obj_dt.Rows[0]["cbm"].ToString();

                    txt_receipt.Text = obj_dt.Rows[0]["por"].ToString();
                    txt_loading.Text = obj_dt.Rows[0]["pol"].ToString();
                    txt_discharge.Text = obj_dt.Rows[0]["pod"].ToString();
                    txt_destination.Text = obj_dt.Rows[0]["fd"].ToString();
                    txt_remark.Text = obj_dt.Rows[0]["remarks"].ToString();
                    txt_orignalbl.Text = obj_dt.Rows[0]["oribls"].ToString();

                    if ((obj_dt.Rows[0]["cargoid"].ToString()) != "")
                    {
                        //  txt_commotity.Text = obj_dt.Rows[0]["cargoname"].ToString();
                        int IntCOMMODITY = Convert.ToInt32(obj_dt.Rows[0]["cargoid"].ToString());
                        txt_commotity.Text = cargoobj.GetCargoname(IntCOMMODITY);
                    }



                    txt_agent.Text = obj_dt.Rows[0]["agent"].ToString();
                    hid_shipperid.Value = obj_dt.Rows[0]["shipperid"].ToString();
                    // txt_shipper.Text = obj_dt.Rows[0]["shippername"].ToString();
                    //  txt_consignee.Text = obj_dt.Rows[0]["consignename"].ToString();
                    int intnotifyid = Convert.ToInt32(obj_dt.Rows[0]["notIFypartyid"].ToString());
                    txt_notify.Text = customerobj.GetCustomername(intnotifyid);
                    hid_agentid.Value = obj_dt.Rows[0]["deliveryagent"].ToString();
                    txt_agentaddress.Text = txt_agent.Text + System.Environment.NewLine + obj_da_Customer.GetCustomerAddress(txt_agent.Text, "Agent", obj_da_Customer.GetCustlocation(int.Parse(hid_agentid.Value.ToString()))).ToString();
                    txt_cha.Text = obj_dt.Rows[0]["cha"].ToString();
                    hid_chaid.Value = obj_dt.Rows[0]["cnf"].ToString();
                    hid_cargoid.Value = obj_dt.Rows[0]["cargoid"].ToString();
                    hid_issued.Value = obj_dt.Rows[0]["blissuedat"].ToString();
                    hid_receiptid.Value = obj_dt.Rows[0]["porid"].ToString();
                    hid_loadingid.Value = obj_dt.Rows[0]["polid"].ToString();
                    hid_dischargeid.Value = obj_dt.Rows[0]["podid"].ToString();
                    hid_destinationid.Value = obj_dt.Rows[0]["fdid"].ToString();
                    ddl_freight.SelectedValue = obj_dt.Rows[0]["freight"].ToString();
                    ddl_shipment.SelectedValue = obj_dt.Rows[0]["shipment"].ToString();
                    hid_branchid.Value = obj_dt.Rows[0]["branchid"].ToString();
                    hid_shipperid.Value = obj_dt.Rows[0]["shipperid"].ToString();
                    hid_consigneeid.Value = obj_dt.Rows[0]["consigneeid"].ToString();
                    hid_notifyid.Value = obj_dt.Rows[0]["notifypartyid"].ToString();
                    hid_agentid.Value = obj_dt.Rows[0]["deliveryagent"].ToString();
                    if (obj_dt.Rows[0]["ourbl"].ToString() == "Y")
                    {
                        BLTYPE.SelectedIndex = 2;
                        BLTYPE.Enabled = false;
                    }
                    else if (obj_dt.Rows[0]["ourbl"].ToString() == "N")
                    {
                        BLTYPE.SelectedIndex = 1;
                        BLTYPE.Enabled = false;
                    }
                    if (obj_dt.Rows[0]["dgcargo"].ToString() == "Y")
                    {
                        Chk_DG.Checked = true;
                    }
                    else
                    {
                        Chk_DG.Checked = false;
                    }

                    if (obj_dt.Rows[0]["nomination"].ToString() == "N")
                    {
                        chk_agent.Checked = true;
                    }
                    else
                    {
                        chk_agent.Checked = false;
                    }
                    ddl_BLsignatory.SelectedValue = obj_dt.Rows[0]["sign"].ToString();
                    ddl_unit.SelectedValue = obj_dt.Rows[0]["units"].ToString();
                    if (obj_dt.Rows[0]["surrendered"].ToString() == "S" || obj_dt.Rows[0]["surrendered"].ToString() == "B")
                    {
                        ddl_HTS.SelectedValue = obj_dt.Rows[0]["surrendered"].ToString();
                    }
                    else
                    {
                        ddl_HTS.SelectedValue = "R";
                    }

                    obj_dt = null;
                    obj_dt = obj_da_Jobinfo.GetFEJobInfo(int.Parse(txt_job.Text), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_detail.Text = obj_dt.Rows[0]["vessel"].ToString() + " , " + obj_dt.Rows[0]["sd"].ToString() + " , " + obj_dt.Rows[0]["mlo"].ToString() + " , " + obj_dt.Rows[0]["voyage"].ToString() + " , " + obj_dt.Rows[0]["etd"].ToString() + " , " + obj_dt.Rows[0]["eta"].ToString() + " , " + obj_dt.Rows[0]["mblno"].ToString();
                        hid_jobtype.Value = obj_dt.Rows[0]["jobtype"].ToString();
                    }
                    txt_booking.Text = obj_da_BL.GetBookinkNo(txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_dt = null;
                    obj_dt = obj_da_BL.GetBookingDt(txt_booking.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    if (obj_dt.Rows.Count > 0)
                    {
                        hid_salesid.Value = obj_dt.Rows[0]["salesid"].ToString();
                        hid_intcustomerid.Value = obj_dt.Rows[0][13].ToString();
                        if (obj_dt.Rows[0]["hazardous"].ToString() == "1")
                        {
                            Chk_DG.Checked = true;
                        }
                        else
                        {
                            Chk_DG.Checked = false;
                        }
                    }

                    // Btn_save.Text = "Save";

                    Btn_save.ToolTip = "Save";
                    Btn_save1.Attributes["class"] = "btn ico-save";

                    //Btn_cancel.Text = "Cancel";


                    Btn_cancel.ToolTip = "Cancel";
                    Btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    obj_dt = null;
                    int i;
                    for (i = 0; i <= 6; i++)
                    {
                        obj_dt = obj_da_Invoice.CheckIPDCWBL(txt_bl.Text, "FE", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["Vouyear"].ToString()), i, "CBM");
                        if (obj_dt.Rows.Count > 0)
                        {
                            txt_cbm.Enabled = false;
                            return;
                        }
                        else
                        {
                            txt_cbm.Enabled = true;
                        }
                    }
                    for (i = 0; i <= 6; i++)
                    {
                        obj_dt = obj_da_Invoice.CheckIPDCWBL(txt_bl.Text, "FE", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["Vouyear"].ToString()), i, "MT");
                        if (obj_dt.Rows.Count > 0)
                        {
                            txt_grwt.Enabled = false;
                            txt_ntwt.Enabled = false;
                            return;
                        }
                        else
                        {
                            txt_grwt.Enabled = true;
                            txt_ntwt.Enabled = true;
                        }
                    }

                }
                else
                {
                    if (txt_receipt.Text.Length > 0 && txt_consignee.Text.Length > 0 && txt_issued.Text.Length > 0 && txt_destination.Text.Length > 0)
                    {
                        Fn_Clear_Bltxt();
                    }
                    txt_issued.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Fn_Clear()
        {
            txt_agent.Text = "";
            txt_agentaddress.Text = "";
            txt_bl.Text = "";
            txt_booking.Text = "";
            txt_cbm.Text = "0";
            txt_cha.Text = "";
            txt_commotity.Text = "";
            txt_consignee.Text = "";
            txt_consigneeaddress.Text = "";
            txt_container.Text = "";
            txt_description.Text = "";
            txt_destination.Text = "";
            txt_detail.Text = "";
            txt_discharge.Text = "";
            txt_grwt.Text = "";
            txt_issued.Text = "";
            txt_issuedon.Text = hid_date.Value.ToString();
            txt_job.Text = "";
            txt_loading.Text = "";
            txt_mark.Text = "";
            txt_notify.Text = "";
            txt_notifyaddress.Text = "";
            txt_ntwt.Text = "";
            txt_orignalbl.Text = "3";
            txt_pkgs.Text = "";
            txt_receipt.Text = "";
            txt_remark.Text = "";
            txt_shipper.Text = "";
            txt_shipperaddress.Text = "";
            txt_vessel.Text = "";
            txt_voyage.Text = "";
            ddl_BLsignatory.SelectedIndex = 0;
            ddl_freight.SelectedIndex = 0;
            ddl_HTS.SelectedIndex = 0;
            ddl_shipment.SelectedIndex = 0;
            ddl_unit.SelectedIndex = 0;

            vessel.Text = "";
            txt_jobtype.Text = "";
            eta.Text = hid_date.Value.ToString();
            etd.Text = hid_date.Value.ToString();
            mlo.Text = "";
            mbl.Text = "";
            pol.Text = "";
            pod.Text = "";
            mblstatus.Text = "";
            carrier.Text = "";
            //  Btn_save.Text = "Save";
            Btn_save.ToolTip = "Save";
            Btn_save1.Attributes["class"] = "btn ico-save";

            issuedflag.ImageUrl = "";
            flagimg.ImageUrl = "";
            porflag.ImageUrl = "";
            podflag.ImageUrl = "";
            fdflag.ImageUrl = "";
            chk_containerlist.Items.Clear();
            hid_SupplyTo.Value = "0";
            UserRights();

        }
        private void Fn_Clear_Bltxt()
        {
            txt_agent.Text = "";
            txt_agentaddress.Text = "";
            txt_cbm.Text = "0";
            txt_cha.Text = "";
            txt_commotity.Text = "";
            txt_consignee.Text = "";
            txt_consigneeaddress.Text = "";
            txt_container.Text = "";
            txt_description.Text = "";
            txt_detail.Text = "";
            txt_discharge.Text = "";
            txt_grwt.Text = "";
            txt_mark.Text = "";
            txt_notify.Text = "";
            txt_notifyaddress.Text = "";
            txt_ntwt.Text = "";
            txt_pkgs.Text = "";
            txt_remark.Text = "";
            txt_vessel.Text = "";
            txt_voyage.Text = "";
            ddl_BLsignatory.SelectedIndex = 0;
            ddl_freight.SelectedIndex = 0;
            ddl_HTS.SelectedIndex = 0;
            ddl_shipment.SelectedIndex = 0;
            ddl_unit.SelectedIndex = 0;
            chk_containerlist.Items.Clear();
            UserRights();
        }


        protected void Btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_bl.Text == "")
                {
                    return;
                }
                //DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                //ScriptManager.RegisterClientScriptBlock(Btn_delete, typeof(Button), "", "Confirm();", true);
                obj_da_BL.DelBLdt(txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 2, 4, int.Parse(Session["LoginBranchid"].ToString()), txt_bl.Text + " " + "FE-BLDel");
                Fn_Clear();
                ScriptManager.RegisterStartupScript(Btn_delete, typeof(Button), "BL", "alertify.alert('Details Delete');", true);
                // Btn_cancel.Text = "Cancel";


                Btn_cancel.ToolTip = "Cancel";
                Btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_bl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lnkfrght.Visible = true;
                //DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
                //DataAccess.ForwardingExports.BLDetailsWOJob obj_da_BLWojob = new DataAccess.ForwardingExports.BLDetailsWOJob();
                //DataAccess.ForwardingExports.JobInfo obj_da_Job = new DataAccess.ForwardingExports.JobInfo();
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                DataTable obj_dt = new DataTable();

                if (lbl_header.Text == "Our BL" || lbl_header.Text == "Direct Bill of Lading (Liner)")
                {

                    if (txt_bl.Text.Trim().Length > 0)
                    {
                        obj_dt = obj_da_Job.GetFEJobInfoMBL(txt_bl.Text.ToUpper(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                        DataView obj_dtview = new DataView(obj_dt);
                        obj_dtview.RowFilter = "mblno='" + txt_bl.Text.ToUpper() + "'";
                        obj_dt = obj_dtview.ToTable();
                        if (obj_dt.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(txt_bl, typeof(TextBox), "BL", "alertify.alert('BL # and MBL # should not Same,kindly change MBL # in Job screen');", true);
                            txt_bl.Focus();
                            return;
                        }
                        obj_dt = obj_da_BLWojob.GeBLDetailsWOJ(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                        obj_dtview = new DataView(obj_dt);
                        obj_dtview.RowFilter = "blno='" + txt_bl.Text + "'";
                        obj_dt = obj_dtview.ToTable();
                        if (obj_dt.Rows.Count > 0)
                        {
                            hid_WojBLno.Value = txt_bl.Text;
                            Fn_GetWojBLdetail();
                            //Btn_save.Text = "Save";
                            Btn_save.ToolTip = "Save";
                            Btn_save1.Attributes["class"] = "btn ico-save";


                            return;
                        }
                        Fn_GetBLdetail();
                        //DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();

                        obj_dt = obj_da_jobinfo.GetFEJobInfo(int.Parse(txt_job.Text), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                        if (obj_dt.Rows.Count > 0)
                        {
                            vessel.Text = obj_dt.Rows[0]["vessel"].ToString();

                            txtcontract.Text = obj_dt.Rows[0]["con"].ToString();
                            eta.Text = obj_dt.Rows[0]["eta"].ToString();
                            eta.Text = Convert.ToDateTime(eta.Text).ToString("dd/MM/yyyy");
                            etd.Text = obj_dt.Rows[0]["etd"].ToString();
                            etd.Text = Convert.ToDateTime(etd.Text).ToString("dd/MM/yyyy");
                            mlo.Text = obj_dt.Rows[0]["mlo"].ToString();
                            mbl.Text = obj_dt.Rows[0]["mblno"].ToString();
                            pol.Text = obj_dt.Rows[0]["pol"].ToString();
                            pod.Text = obj_dt.Rows[0]["pod"].ToString();
                            carrier.Text = obj_dt.Rows[0]["carrier"].ToString();
                            if (obj_dt.Rows[0]["mblstatus"].ToString() == "R")
                            {
                                mblstatus.Text = "Release";
                            }
                            else if (obj_dt.Rows[0]["mblstatus"].ToString() == "B")
                            {
                                mblstatus.Text = "SeaWayBill";
                            }
                            else if (obj_dt.Rows[0]["mblstatus"].ToString() == "S")
                            {
                                mblstatus.Text = "Surrendered";
                            }


                            if (obj_dt.Rows[0]["jobtype"].ToString() == "1")
                            {
                                txt_jobtype.Text = "Consol";
                            }
                            else if (obj_dt.Rows[0]["jobtype"].ToString() == "2")
                            {
                                txt_jobtype.Text = "LCL";
                            }
                            else if (obj_dt.Rows[0]["jobtype"].ToString() == "3")
                            {
                                txt_jobtype.Text = "FCL";
                            }
                            else if (obj_dt.Rows[0]["jobtype"].ToString() == "4")
                            {
                                txt_jobtype.Text = "MCC";
                            }
                            else if (obj_dt.Rows[0]["jobtype"].ToString() == "5")
                            {
                                txt_jobtype.Text = "Buyer Consol";
                            }
                        }
                        obj_dt = null;
                        //  obj_dt = obj_da_BL.GetBLDetails1(txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                        obj_dt = obj_da_BL.GetBLDetails(txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                        if (obj_dt.Rows.Count > 0)
                        {
                            txt_job.Text = obj_dt.Rows[0][0].ToString();
                            hid_job.Value = txt_job.Text;
                        }
                        if (txt_job.Text.Trim().Length > 0)
                        {
                            if (hid_job.Value.ToString() == txt_job.Text)
                            {
                                chk_containerlist.Items.Clear();
                                DataTable obj_dttemp = new DataTable();
                                obj_dt = obj_da_Job.GetContainerDetails(int.Parse(txt_job.Text), txt_job.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                                obj_dttemp = obj_da_Job.GetContainerDetails(int.Parse(txt_job.Text), txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                {
                                    chk_containerlist.Items.Add(obj_dt.Rows[i][0].ToString());
                                    for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                                    {
                                        if (obj_dt.Rows[i][0].ToString() == obj_dttemp.Rows[j][0].ToString())
                                        {
                                            chk_containerlist.Items[i].Selected = true;
                                        }
                                    }
                                }

                            }
                        }

                        if (btndelete == true)
                        {
                            if (txt_bl.Text.Trim().Length > 0)
                            {
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 2, 4, Convert.ToInt32(Session["LoginBranchid"]), "FE-BLDel");
                                Btn_delete_Click(sender, e);
                            }
                        }

                    }
                }
                else
                {
                    Fn_GetWojBLdetail();
                    txt_vessel.Focus();
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
                lnkfrght.Visible = true;
                //DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
                //DataAccess.ForwardingExports.BLDetailsWOJob obj_da_BLWojob = new DataAccess.ForwardingExports.BLDetailsWOJob();
                //DataAccess.ForwardingExports.JobInfo obj_da_Job = new DataAccess.ForwardingExports.JobInfo();
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                DataTable obj_dt = new DataTable();

                if (lbl_header.Text == "Our BL" || lbl_header.Text == "Direct Bill of Lading (Liner)")
                {

                    if (txt_bl.Text.Trim().Length > 0)
                    {
                        obj_dt = obj_da_Job.GetFEJobInfoMBL(txt_bl.Text.ToUpper(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                        DataView obj_dtview = new DataView(obj_dt);
                        obj_dtview.RowFilter = "mblno='" + txt_bl.Text.ToUpper() + "'";
                        obj_dt = obj_dtview.ToTable();
                        if (obj_dt.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(txt_bl, typeof(TextBox), "BL", "alertify.alert('BL # and MBL # should not Same,kindly change MBL # in Job screen');", true);
                            txt_bl.Focus();
                            return;
                        }
                        obj_dt = obj_da_BLWojob.GeBLDetailsWOJ(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                        obj_dtview = new DataView(obj_dt);
                        obj_dtview.RowFilter = "blno='" + txt_bl.Text + "'";
                        obj_dt = obj_dtview.ToTable();
                        if (obj_dt.Rows.Count > 0)
                        {
                            hid_WojBLno.Value = txt_bl.Text;
                            Fn_GetWojBLdetail();
                            //Btn_save.Text = "Save";

                            Btn_save.ToolTip = "Save";
                            Btn_save1.Attributes["class"] = "btn ico-save";
                            return;
                        }
                        Fn_GetBLdetailreuse();
                        obj_dt = null;
                        //  obj_dt = obj_da_BL.GetBLDetails1(txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                        obj_dt = obj_da_BL.GetBLDetails(txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                        if (obj_dt.Rows.Count > 0)
                        {
                            txt_job.Text = obj_dt.Rows[0][0].ToString();
                            hid_job.Value = txt_job.Text;
                        }
                        if (txt_job.Text.Trim().Length > 0)
                        {
                            if (hid_job.Value.ToString() == txt_job.Text)
                            {
                                chk_containerlist.Items.Clear();
                                DataTable obj_dttemp = new DataTable();
                                obj_dt = obj_da_Job.GetContainerDetails(int.Parse(txt_job.Text), txt_job.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                                obj_dttemp = obj_da_Job.GetContainerDetails(int.Parse(txt_job.Text), txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                {
                                    chk_containerlist.Items.Add(obj_dt.Rows[i][0].ToString());
                                    for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                                    {
                                        if (obj_dt.Rows[i][0].ToString() == obj_dttemp.Rows[j][0].ToString())
                                        {
                                            chk_containerlist.Items[i].Selected = true;
                                        }
                                    }
                                }

                            }
                        }

                        if (btndelete == true)
                        {
                            if (txt_bl.Text.Trim().Length > 0)
                            {
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 2, 4, Convert.ToInt32(Session["LoginBranchid"]), "FE-BLDel");

                            }
                        }
                        //txt_job.Text = "";
                        //txt_detail.Text = "";
                        txt_bl.Text = "";
                        txt_booking.Text = "";
                        chk_containerlist.Items.Clear();
                        hid_reuse.Value = "Reuse";
                    }
                }
                else
                {

                    Fn_GetWojBLdetail();
                    txt_vessel.Focus();
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            if (Btn_cancel.ToolTip == "Cancel")
            {
                Session["BLDetails"] = "";
                if (Session["BLDetails"] != null)
                {

                    if (Session["BLDetails"].ToString() == "BLDetails")
                    {
                        LoadBooking();
                        Session["BLDetails"] = "";
                        // Btn_cancel.Text = "Cancel";


                        Btn_cancel.ToolTip = "Cancel";
                        Btn_cancel1.Attributes["class"] = "btn ico-cancel";
                        lnkfrght.Visible = false;
                        // BLTYPE.SelectedIndex = 0;
                    }
                    Fn_Clear();
                    ddl_move.SelectedIndex = 0;
                    hid_reuse.Value = "";
                    // BLTYPE.SelectedIndex = 0;
                    BLTYPE.SelectedIndex = 1;
                    type = BLTYPE.Text;
                    txt_bl.Focus();
                    //  txt_bl.ReadOnly = false;
                    BLTYPE.Enabled = true;
                    BLTYPE_SelectedIndexChanged(sender, e);
                    lnkfrght.Visible = false;
                    txt_bl.Focus();
                    txt_bl.ReadOnly = false;
                    chk_agent.Enabled = false;
                    txt_cbm.Enabled = true;
                    // Btn_cancel.Text = "Back";
                    Btn_cancel.ToolTip = "Back";
                    Btn_cancel1.Attributes["class"] = "btn ico-back";
                    UserRights();
                    txtcontract.Text = "";
                }
            }
            else
            {
                if (Request.QueryString.ToString().Contains("BLDetails"))
                {
                    Response.Redirect("../Home/OEOpsAndDocs.aspx");
                }
                else
                {
                    this.Response.End();
                }
            }
        }


        protected void Btn_save_Click(object sender, EventArgs e)
        {
            //try
            //{
            back = 0;
            checkdata();
            if (back == 1)
            {
                return;
            }
            double cbm = Double.Parse(txt_cbm.Text);
            //if (cbm > 100.00)
            //{
            //    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('CBM SHOULD NOT BE GREATER THAN 100');", true);
            //    txt_cbm.Focus();
            //    return;
            //}
            if (ddl_shipment.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Select Shipment Type');", true);
                ddl_shipment.Focus();
                return;
            }
            if (ddl_freight.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Select Freight Type');", true);
                ddl_freight.Focus();
                return;
            }
            if (ddl_BLsignatory.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Select BLSignatory Type');", true);
                ddl_BLsignatory.Focus();
                return;
            }
            if (ddl_HTS.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Select BL Status Type');", true);
                ddl_HTS.Focus();
                return;
            }

            if (ddl_unit.SelectedValue == "0" || ddl_unit.SelectedIndex == 0 || ddl_unit.Text == "")
            {
                ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Select Unit Type');", true);
                return;
            }

            if (ddl_move.SelectedIndex == 0 || ddl_move.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Select Move Type');", true);
                return;
            }
            //DataAccess.Masters.MasterPort obj_da_Port = new DataAccess.Masters.MasterPort();
            //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            //DataAccess.ForwardingExports.JobInfo obj_da_Job = new DataAccess.ForwardingExports.JobInfo();
            //DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
            //DataAccess.ForwardingImports.BLDetails obj_da_BLImport = new DataAccess.ForwardingImports.BLDetails();
            //DataAccess.ForwardingExports.BLDetailsWOJob obj_da_BLwojob = new DataAccess.ForwardingExports.BLDetailsWOJob();
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            DataTable obj_dt = new DataTable();
            int int_podid = 0, int_fdid = 0, int_agentid = 0;
            obj_dt = obj_da_Port.RetrievePortnameDetails(txt_discharge.Text.Trim());
            if (obj_dt.Rows.Count > 0)
            {
                int_podid = int.Parse(obj_dt.Rows[0]["countryid"].ToString());
            }
            obj_dt = null;
            obj_dt = obj_da_Port.RetrievePortnameDetails(txt_destination.Text.Trim());
            if (obj_dt.Rows.Count > 0)
            {
                int_fdid = int.Parse(obj_dt.Rows[0]["countryid"].ToString());
            }
            obj_dt = null;
            obj_dt = obj_da_Port.RetrievePortnameDetails(obj_da_Customer.GetCustlocation(int.Parse(hid_agentid.Value.ToString())).ToString());
            if (obj_dt.Rows.Count > 0)
            {
                int_agentid = int.Parse(obj_dt.Rows[0]["countryid"].ToString());
            }
            if ((int_podid != int_agentid) && (int_fdid != int_agentid))
            {
                this.PopUpService.Show();
                return;
            }


            //Elengo
            //save();
            ContSizeVerifyQuataionandjob();
            if (ContVerify == true)
            {
                save();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Quotation had the sizetype " + Miscontsize + ". But You have not added container " + Miscontsize + " in Jobinfo. kindly add container " + Miscontsize + " in jobinfo Screen');", true);
                return;
            }


            if (back == 1)
            {
                return;
            }
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}
        }

        private void Fn_InsContainer()
        {
            try
            {
                int count = 0;

                DataTable obj_dt = new DataTable();

                obj_da_BL.DelContainerDetails(int.Parse(txt_job.Text), txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                for (int i = 0; i <= chk_containerlist.Items.Count - 1; i++)
                {
                    if (chk_containerlist.Items[i].Selected == true)
                    {
                        count = 1;
                        obj_dt = obj_da_Job.GetContDetails(int.Parse(txt_job.Text), chk_containerlist.Items[i].Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                        if (obj_dt.Rows.Count > 0)
                        {
                            if (Server.HtmlDecode(obj_dt.Rows[0]["crodate"].ToString()) == "")
                            {
                                datcro = Utility.fn_ConvertDatetime(hid_date.Value.ToString());
                            }
                            else
                            {
                                datcro = obj_dt.Rows[0]["crodate"].ToString();
                            }
                        }
                        if (obj_dt.Rows.Count > 0)
                        {
                            obj_da_Job.InsContDetail(int.Parse(txt_job.Text), chk_containerlist.Items[i].Text, obj_dt.Rows[0]["sizetype"].ToString(), obj_dt.Rows[0]["sealno"].ToString(), txt_bl.Text.ToUpper(), int.Parse(obj_dt.Rows[0]["pkgs"].ToString()), double.Parse(obj_dt.Rows[0]["wt"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(datcro));
                        }
                    }
                    if (count == 0)
                    {
                        back = 1;
                    }
                    else
                    {
                        back = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void Fn_UpdateContainer()
        {
            try
            {
                //DataAccess.ForwardingExports.ShippingBill obj_da_FEShippingbill = new DataAccess.ForwardingExports.ShippingBill();
                //DataAccess.ForwardingExports.JobInfo obj_da_FEJobinfo = new DataAccess.ForwardingExports.JobInfo();
                //DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                DataTable obj_dt = new DataTable();


                for (int i = 0; i <= chk_containerlist.Items.Count - 1; i++)
                {
                    DataTable obj_dttemp = new DataTable();
                    obj_dttemp = obj_da_FEJobinfo.GetContDetails(int.Parse(txt_job.Text), chk_containerlist.Items[i].Text.ToString(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    if (chk_containerlist.Items[i].Selected == true)
                    {
                        if (obj_dttemp.Rows.Count > 0)
                        {

                            if (Server.HtmlDecode(obj_dttemp.Rows[0]["crodate"].ToString()) == "")
                            {
                                datcro = Utility.fn_ConvertDatetime(hid_date.Value.ToString());
                                //obj_da_FEJobinfo.InsContDetail(int.Parse(txt_job.Text), chk_containerlist.Items[i].Text.ToString(), obj_dttemp.Rows[0]["sizetype"].ToString(), obj_dttemp.Rows[0]["sealno"].ToString(), txt_bl.Text, int.Parse(obj_dttemp.Rows[0]["pkgs"].ToString()), double.Parse(obj_dttemp.Rows[0]["wt"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(datcro)));
                            }
                            else
                            {
                                datcro = obj_dttemp.Rows[0]["crodate"].ToString();
                            }
                            obj_da_FEJobinfo.InsContDetail(int.Parse(txt_job.Text), chk_containerlist.Items[i].Text.ToString(), obj_dttemp.Rows[0]["sizetype"].ToString(), obj_dttemp.Rows[0]["sealno"].ToString(), txt_bl.Text.ToUpper(), int.Parse(obj_dttemp.Rows[0]["pkgs"].ToString()), double.Parse(obj_dttemp.Rows[0]["wt"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), Convert.ToDateTime((datcro)));
                        }
                    }

                    else
                    {
                        obj_da_FEBL.DelContDetails(int.Parse(txt_job.Text), txt_bl.Text, chk_containerlist.Items[i].Text.ToString(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    }

                    //obj_dt = obj_da_FEJobinfo.GetContDetails(int.Parse(txt_job.Text), txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

                    //if (chk_containerlist.Items[i].Selected == true)
                    //{
                    //    if (obj_dt.Rows.Count > 0)
                    //    {
                    //        //obj_da_FEBL.DelContDetails(int.Parse(txt_job.Text), txt_bl.Text, chk_containerlist.Items[i].Text.ToString(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    //        for (int j = 0; j <= obj_dt.Rows.Count - 1; j++)
                    //        {
                    //            if (chk_containerlist.Items[i].Text.ToString() == obj_dt.Rows[0]["containerno"].ToString())
                    //            {
                    //                //obj_da_FEBL.DelContDetails(int.Parse(txt_job.Text), txt_bl.Text, chk_containerlist.Items[i].Text.ToString(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    //                DataTable obj_dttemp = new DataTable();
                    //                obj_dttemp = obj_da_FEJobinfo.GetContDetails(int.Parse(txt_job.Text), chk_containerlist.Items[i].Text.ToString(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    //                if (obj_dttemp.Rows.Count > 0)
                    //                {
                    //                    obj_da_FEJobinfo.InsContDetail(int.Parse(txt_job.Text), chk_containerlist.Items[i].Text.ToString(), obj_dttemp.Rows[0]["sizetype"].ToString(), obj_dttemp.Rows[0]["sealno"].ToString(), txt_bl.Text, int.Parse(obj_dttemp.Rows[0]["pkgs"].ToString()), double.Parse(obj_dttemp.Rows[0]["wt"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(datcro)));
                    //                }
                    //            }
                    //            else
                    //            {
                    //                DataTable obj_dttemp = new DataTable();
                    //                obj_dttemp = obj_da_FEJobinfo.GetContDetails(int.Parse(txt_job.Text), chk_containerlist.Items[i].Text.ToString(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    //                if (obj_dttemp.Rows.Count > 0)
                    //                {
                    //                    obj_da_FEJobinfo.InsContDetail(int.Parse(txt_job.Text), chk_containerlist.Items[i].Text.ToString(), obj_dttemp.Rows[0]["sizetype"].ToString(), obj_dttemp.Rows[0]["sealno"].ToString(), txt_bl.Text, int.Parse(obj_dttemp.Rows[0]["pkgs"].ToString()), double.Parse(obj_dttemp.Rows[0]["wt"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(datcro)));
                    //                }
                    //            }

                    //        }
                    //    }
                    //    else
                    //    {
                    //        //obj_da_FEBL.DelContDetails(int.Parse(txt_job.Text), txt_bl.Text, chk_containerlist.Items[i].Text.ToString(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

                    //    }
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_job_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txt_job.Text.Trim().Length > 0)
                {
                    /*  DataAccess.ForwardingExports.JobInfo obj_da_Job = new DataAccess.ForwardingExports.JobInfo();
                      DataTable obj_dt = new DataTable();
                      DataTable obj_dtt = new DataTable();
                      obj_dt = obj_da_Job.GetFEJobInfo(int.Parse(txt_job.Text), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                      if (obj_dt.Rows.Count > 0)
                      {
                          txt_detail.Text = obj_dt.Rows[0]["vessel"].ToString() + " , " + obj_dt.Rows[0]["sd"].ToString() + " , " + obj_dt.Rows[0]["mlo"].ToString() + " , " + obj_dt.Rows[0]["voyage"].ToString() + " , " + obj_dt.Rows[0]["etd"].ToString() + " , " + obj_dt.Rows[0]["eta"].ToString() + " , " + obj_dt.Rows[0]["mblno"].ToString();
                          hid_jobtype.Value = obj_dt.Rows[0]["jobtype"].ToString();
                          chk_containerlist.Items.Clear();
                          obj_dtt = obj_da_Job.GetContainerDetails(int.Parse(txt_job.Text), txt_job.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                          for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                          {
                              chk_containerlist.Items.Add(obj_dtt.Rows[i]["containerno"].ToString());
                          }
                      }
                      else
                      {
                          ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('No Job Available');", true);
                          return;
                      }
                      Btn_cancel.Text = "Cancel";*/
                    //txt_job.Text = Grd_Job.SelectedRow.Cells[0].Text;

                    // txt_detail.Text = Grd_Job.SelectedRow.Cells[1].Text + " , " + ((Label)Grd_Job.SelectedRow.Cells[2].FindControl("vessel")).Text + " , " + Grd_Job.SelectedRow.Cells[4].Text + " , " + ((Label)Grd_Job.SelectedRow.Cells[6].FindControl("mlo")).Text + " , " + Grd_Job.SelectedRow.Cells[3].Text + " , " + Grd_Job.SelectedRow.Cells[7].Text + " , " + Grd_Job.SelectedRow.Cells[8].Text + " , " + Grd_Job.SelectedRow.Cells[5].Text;
                    //DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                    DataTable obj_dt = new DataTable();
                    obj_dt = obj_da_jobinfo.GetFEJobInfo(int.Parse(txt_job.Text), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    if (obj_dt.Rows.Count > 0)
                    {
                        vessel.Text = obj_dt.Rows[0]["vessel"].ToString();


                        eta.Text = obj_dt.Rows[0]["eta"].ToString();
                        eta.Text = Convert.ToDateTime(eta.Text).ToString("dd/MM/yyyy");
                        etd.Text = obj_dt.Rows[0]["etd"].ToString();
                        etd.Text = Convert.ToDateTime(etd.Text).ToString("dd/MM/yyyy");
                        mlo.Text = obj_dt.Rows[0]["mlo"].ToString();
                        mbl.Text = obj_dt.Rows[0]["mblno"].ToString();
                        pol.Text = obj_dt.Rows[0]["pol"].ToString();
                        pod.Text = obj_dt.Rows[0]["pod"].ToString();
                        carrier.Text = obj_dt.Rows[0]["carrier"].ToString();
                        if (obj_dt.Rows[0]["mblstatus"].ToString() == "R")
                        {
                            mblstatus.Text = "Release";
                        }
                        else if (obj_dt.Rows[0]["mblstatus"].ToString() == "B")
                        {
                            mblstatus.Text = "SeaWayBill";
                        }
                        else if (obj_dt.Rows[0]["mblstatus"].ToString() == "S")
                        {
                            mblstatus.Text = "Surrendered";
                        }


                        if (obj_dt.Rows[0]["jobtype"].ToString() == "1")
                        {
                            txt_jobtype.Text = "Consol";
                        }
                        else if (obj_dt.Rows[0]["jobtype"].ToString() == "2")
                        {
                            txt_jobtype.Text = "LCL";
                        }
                        else if (obj_dt.Rows[0]["jobtype"].ToString() == "3")
                        {
                            txt_jobtype.Text = "FCL";
                        }
                        else if (obj_dt.Rows[0]["jobtype"].ToString() == "4")
                        {
                            txt_jobtype.Text = "MCC";
                        }
                        else if (obj_dt.Rows[0]["jobtype"].ToString() == "5")
                        {
                            txt_jobtype.Text = "Buyer Consol";
                        }


                        txt_detail.Text = obj_dt.Rows[0]["vessel"].ToString() + " , " + obj_dt.Rows[0]["sd"].ToString() + " , " + obj_dt.Rows[0]["mlo"].ToString() + " , " + obj_dt.Rows[0]["voyage"].ToString() + " , " + obj_dt.Rows[0]["etd"].ToString() + " , " + obj_dt.Rows[0]["eta"].ToString() + " , " + obj_dt.Rows[0]["mblno"].ToString();
                        hid_jobtype.Value = obj_dt.Rows[0]["jobtype"].ToString();
                        hid_intcustomeropsid.Value = obj_dt.Rows[0]["mloid"].ToString();
                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Select Atleast One Container');", true);
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job Not Available');", true);
                        return;
                    }
                    obj_dt = obj_da_jobinfo.GetContainerDetails(int.Parse(txt_job.Text), txt_job.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    if (obj_dt.Rows.Count > 0)
                    {
                        chk_containerlist.Items.Clear();
                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            chk_containerlist.Items.Add(obj_dt.Rows[i]["containerno"].ToString());
                        }
                    }
                    else
                    {

                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Container Not Available');", true);
                        return;
                    }

                    // txt_booking.Focus();
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            //Btn_cancel.Text = "Cancel";

            Btn_cancel.ToolTip = "Cancel";
            Btn_cancel1.Attributes["class"] = "btn ico-cancel";

        }

        private string[] Fn_Contsize(string str_blno, int jobtype)
        {


            string[] Str_Contsize = new string[] { "0", "0" };
            try
            {
                //DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
                Str_Contsize[0] = obj_da_BL.GetCont2040(str_blno, 20, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString())).ToString();
                Str_Contsize[1] = obj_da_BL.GetCont2040(str_blno, 40, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString())).ToString();
                dtcont = obj_da_BL.GetCBMLimt4cont();
                if (dtcont.Rows.Count > 0)
                {
                    if (Convert.ToInt32(Str_Contsize[0]) > 0 && Convert.ToInt32(Str_Contsize[1]) == 0)
                    {
                        limit20 = Convert.ToInt32(dtcont.Rows[0][0]) * Convert.ToInt32(Str_Contsize[0]);
                    }
                    if (Convert.ToInt32(Str_Contsize[1]) > 0 && Convert.ToInt32(Str_Contsize[0]) == 0)
                    {
                        limit40 = Convert.ToInt32(dtcont.Rows[0][1]) * Convert.ToInt32(Str_Contsize[1]);
                    }
                    if (Convert.ToInt32(Str_Contsize[0]) > 0 && Convert.ToInt32(Str_Contsize[1]) > 0)
                    {
                        limit240 = (Convert.ToInt32(dtcont.Rows[0][0]) * Convert.ToInt32(Str_Contsize[0]) + (Convert.ToInt32(dtcont.Rows[0][1]) * Convert.ToInt32(Str_Contsize[1])));
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Container Limit Not Exists...Pls Check with IT Dept.');", true);
                    back = 1;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            return Str_Contsize;
        }

        //protected void lnk_freight_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        popup_Grd.Hide();
        //        popup_Grd1.Hide();
        //        //iframecost.Attributes["src"] = "../FE/BLPrinting.aspx?BLNO=" + txt_bl.Text;
        //        //ModalPopupExtender1.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}

        protected void Grd_Job_RowDataBound(object sender, GridViewRowEventArgs e)
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

                    Label lblCustomer = (Label)e.Row.FindControl("mlo");
                    string tooltip = lblCustomer.Text;
                    e.Row.Cells[6].Attributes.Add("title", tooltip);

                    Label lblCustomer1 = (Label)e.Row.FindControl("vessel");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[2].Attributes.Add("title", tooltip1);


                    Label lblCustomer2 = (Label)e.Row.FindControl("sd");
                    string tooltip2 = lblCustomer2.Text;
                    e.Row.Cells[4].Attributes.Add("title", tooltip2);

                    Label lblCustomer3 = (Label)e.Row.FindControl("mblno");
                    string tooltip3 = lblCustomer3.Text;
                    e.Row.Cells[5].Attributes.Add("title", tooltip3);




                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Job, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Booking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Label lblCustomer = (Label)e.Row.FindControl("CustomerName");
                    //string tooltip = lblCustomer.Text;
                    //e.Row.Cells[1].Attributes.Add("title", tooltip);
                    //Label lblCustomer1 = (Label)e.Row.FindControl("POL");
                    //string tooltip1 = lblCustomer1.Text;
                    //e.Row.Cells[2].Attributes.Add("title", tooltip1);
                    //Label lblCustomer2 = (Label)e.Row.FindControl("POD");
                    //string tooltip2 = lblCustomer2.Text;
                    //e.Row.Cells[3].Attributes.Add("title", tooltip2);
                    //Label lblCustomer3 = (Label)e.Row.FindControl("bookingdate");
                    //string tooltip3 = lblCustomer3.Text;
                    //e.Row.Cells[4].Attributes.Add("title", tooltip3);
                    //Label lblCustomer4 = (Label)e.Row.FindControl("fstatus");
                    //string tooltip4 = lblCustomer4.Text;
                    //e.Row.Cells[5].Attributes.Add("title", tooltip4);

                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Booking, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
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
            //Elengo
            //save();
            ContSizeVerifyQuataionandjob();
            if (ContVerify == true)
            {
                save();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Quotation had the sizetype " + Miscontsize + ". But You have not added container " + Miscontsize + " in Jobinfo. kindly add container " + Miscontsize + " in jobinfo Screen');", true);
                return;
            }

            if (back == 1)
            {
                return;
            }
        }

        protected void AutoInvoice()
        {
            try
            {

                //DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
                //DataAccess.ForwardingExports.BLDetailsWOJob obj_da_BLWojob = new DataAccess.ForwardingExports.BLDetailsWOJob();
                //DataAccess.ForwardingExports.JobInfo obj_da_Job = new DataAccess.ForwardingExports.JobInfo();
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                DataTable obj_dt = new DataTable();
                string txtVendorRefno = "";
                //DataAccess.Accounts.Invoice obj_inv = new DataAccess.Accounts.Invoice();
                DataTable dtref = obj_inv.Getcusrefnofromquot4rpt(Convert.ToInt32(Session["LoginBranchId"].ToString()), Session["StrTranType"].ToString(), txt_bl.Text.ToUpper(), "Profoma");
                if (dtref.Rows.Count > 0)
                {
                    txtVendorRefno = dtref.Rows[0]["cuspono"].ToString().ToUpper();
                }
                obj_dt = obj_da_BL.GetBookingDt(txt_booking.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                if (hid_quto.Value == "" || hid_quto.Value == "0")
                {
                    if (obj_dt.Rows.Count > 0)
                    {
                        hid_quto.Value = obj_dt.Rows[0]["quotno"].ToString();
                    }
                }
                dtinv = obj_da_BL.GetQuotchgs4Inv(Convert.ToInt32(hid_quto.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_booking.Text);
                if (dtinv.Rows.Count > 0)
                {
                    try
                    {

                        //Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Logobj.GetDate()), "FE", Convert.ToInt32(txt_job.Text),
                        //    Convert.ToInt32(hid_intcustomerid.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                        //    "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                        //    "Profoma Invoice", "", 0);





                        //Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Logobj.GetDate()), "FE", Convert.ToInt32(txt_job.Text),
                        //   Convert.ToInt32(hid_intcustomerid.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                        //   "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                        //   "Profoma Invoice", "", 0, Convert.ToInt32(hid_SupplyTo.Value));

                        Refno = ProINVobj.InsProLVhead(Convert.ToDateTime(Logobj.GetDate()), "OE", Convert.ToInt32(txt_job.Text),
                                Convert.ToInt32(hid_intcustomerid.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                               "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), 1, txtVendorRefno.ToString(),
                               0, Convert.ToInt32(hid_SupplyTo.Value), Convert.ToDateTime(Logobj.GetDate()));


                        invgen = true;
                        for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                        {
                            base1 = dtinv.Rows[i]["base"].ToString();
                            rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                            exrate = obj_da_Invoice.GetExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(Logobj.GetDate()), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                            amount = checkbase(base1, rate, exrate);
                            ProINVobj.InsertProLVDetails(Refno, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
                                exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                                , "C", "OE", 1, "Y", unit);

                            //ProINVobj.InsertProInvoiceDetails(Refno, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
                            //    exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                            //    , "C", "FE", "Profoma Invoice", "Y", unit);

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



        //protected void Autocnops4negativeQuotation()
        //{
        //    try
        //    {
        //        //dtinv = obj_da_BL.GetQuotchgs4Inv(Convert.ToInt32(hid_quto.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_booking.Text);
        //        if (hid_buyingno.Value == "")
        //        {
        //            hid_buyingno.Value = "0";

        //        }

        //        if (hid_buyingno.Value != "0")
        //        {
        //            hid_intcustomeropsid.Value = hid_intcustomeropsid.Value;
        //            hid_SupplyTo1.Value = hid_intcustomeropsid.Value;
        //        }
        //        else
        //        {
        //            hid_intcustomeropsid.Value = hid_intcustomerid.Value;
        //            hid_SupplyTo1.Value = hid_intcustomerid.Value;
        //        }
        //        Double amt = 0.00;
        //        if (Session["StrTranType"] != null)
        //        {

        //            //dtinv = obj_da_BL.GetBuyingchgs4debitcredit(Convert.TsessoInt32(hid_buyingno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_booking.Text, Session["StrTranType"].ToString());
        //            string trantype=Session["StrTranType"].ToString();
        //            dtinv = obj_da_Invoice.InvChargeFrombuyinginvoiceAllTrantype(Convert.ToInt32(hid_quto.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_booking.Text, trantype);

        //        }

        //        if (dtinv.Rows.Count > 0)
        //        {
        //            try
        //            {

        //                //Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Logobj.GetDate()), "FE", Convert.ToInt32(txt_job.Text),
        //                //    Convert.ToInt32(hid_intcustomerid.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
        //                //    "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
        //                //    "Profoma Invoice", "", 0);
        //                if (hid_SupplyTo1.Value == "" || hid_SupplyTo1.Value == "0")
        //                {
        //                    hid_SupplyTo1.Value = hid_intcustomeropsid.Value;
        //                }
        //                // hid_intcustomeropsid add customerid
        //                Refno1 = ProINVobj.InsertProInvoiceHeadnew(Convert.ToDateTime(Logobj.GetDate()), "FE", Convert.ToInt32(txt_job.Text),
        //                   Convert.ToInt32(hid_intcustomerid.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
        //                   "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
        //                   "Profoma Payment Advise", "", 0, Convert.ToInt32(hid_SupplyTo1.Value), Convert.ToDateTime(Logobj.GetDate()));

        //                invgen1 = true;
        //                for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
        //                {
        //                    base1 = dtinv.Rows[i]["base"].ToString();
        //                    rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
        //                    exrate = obj_da_Invoice.GetExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(Logobj.GetDate()), "R");
        //                    amount = checkbase(base1, rate, exrate);
        //                    ProINVobj.InsertProInvoiceDetails(Refno1, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
        //                        exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
        //                        , "C", "FE", "Profoma Payment Advise", "Y", unit);

        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                //   Utility.SendMail(Session["usermailid"].ToString(), "", "bl pRO.iNV", ex.ToString(), "", Session["usermailpwd"].ToString(), "", "");
        //            }
        //        }
        //        else
        //        {
        //            invgen1 = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}
        //// end 


        protected void Autocnops()
        {
            try
            {
                //dtinv = obj_da_BL.GetQuotchgs4Inv(Convert.ToInt32(hid_quto.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_booking.Text);
                if (hid_buyingno.Value == "")
                {
                    hid_buyingno.Value = "0";

                }

                if (hid_buyingno.Value != "0")
                {
                    hid_intcustomeropsid.Value = hid_intcustomeropsid.Value;
                    hid_SupplyTo1.Value = hid_intcustomeropsid.Value;
                }
                else
                {
                    hid_intcustomeropsid.Value = hid_intcustomerid.Value;
                    hid_SupplyTo1.Value = hid_intcustomerid.Value;
                }
                Double amt = 0.00;
                if (Session["StrTranType"] != null)
                {

                    //dtinv = obj_da_BL.GetBuyingchgs4debitcredit(Convert.ToInt32(hid_buyingno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_booking.Text, Session["StrTranType"].ToString());
                    dtinv = obj_da_Invoice.GetChargeFrombuyinginvoicenew(txt_bl.Text, Convert.ToInt32(Session["Loginbranchid"]));

                }

                if (dtinv.Rows.Count > 0)
                {
                    try
                    {

                        //Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Logobj.GetDate()), "FE", Convert.ToInt32(txt_job.Text),
                        //    Convert.ToInt32(hid_intcustomerid.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                        //    "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                        //    "Profoma Invoice", "", 0);
                        if (hid_SupplyTo1.Value == "" || hid_SupplyTo1.Value == "0")
                        {
                            hid_SupplyTo1.Value = hid_intcustomeropsid.Value;
                        }

                        //Refno1 = ProINVobj.InsertProInvoiceHeadnew(Convert.ToDateTime(Logobj.GetDate()), "FE", Convert.ToInt32(txt_job.Text),
                        //   Convert.ToInt32(hid_intcustomeropsid.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                        //   "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                        //   "Profoma Payment Advise", "", 0, Convert.ToInt32(hid_SupplyTo1.Value), Convert.ToDateTime(Logobj.GetDate()));


                        Refno1 = ProINVobj.InsProLVhead(Convert.ToDateTime(Logobj.GetDate()), "OE", Convert.ToInt32(txt_job.Text),
                                Convert.ToInt32(hid_intcustomeropsid.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                               "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), 2, "",
                               0, Convert.ToInt32(hid_SupplyTo1.Value), Convert.ToDateTime(Logobj.GetDate()));


                        invgen1 = true;
                        for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                        {
                            base1 = dtinv.Rows[i]["base"].ToString();
                            rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                            exrate = obj_da_Invoice.GetExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(Logobj.GetDate()), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                            amount = checkbase(base1, rate, exrate);
                            ProINVobj.InsertProLVDetails(Refno1, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
                                exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                                , "C", "OE", 2, "Y", unit);



                            //ProINVobj.InsertProInvoiceDetails(Refno1, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
                            //    exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                            //    , "C", "FE", "Profoma Payment Advise", "Y", unit);

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
        public double checkbase(string base1, double rate, double exrate)
        {
            try
            { 
                if (Session["StrTranType"].ToString() == "FE")
                {
                    if (base1.ToUpper() == "BL")
                    {
                        amount = rate * exrate;
                        unit = 1;
                    }
                    else if (base1.ToUpper() == "CBM")
                    {
                        strvolume = obj_da_Invoice.GetVolume(txt_bl.Text, "FE", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
                        amount = rate * exrate * Convert.ToDouble(strvolume);
                        unit = Convert.ToDouble(strvolume);
                    }
                    else if (base1.ToUpper() == "CBM" || base1.ToUpper() == "MT")
                    {
                        if (base1.ToUpper() == "MT")
                        {
                            //strntweight = obj_da_Invoice.GetWeight(txt_bl.Text, "FE", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
                            // amount = rate * exrate * (Convert.ToDouble(strntweight) / 1000);
                            strntweight = obj_da_Invoice.GetWeightnew(txt_bl.Text, "FE", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
                            amount = rate * exrate * (Convert.ToDouble(strntweight));
                            unit = Convert.ToDouble(strntweight);
                        }
                        strvolume = obj_da_Invoice.GetVolume(txt_bl.Text, "FE", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
                        cbmAmt = rate * exrate * Convert.ToDouble(strvolume);
                        //strntweight = obj_da_Invoice.GetWeight(txt_bl.Text, "FE", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
                        //mtAmt = rate * exrate * (Convert.ToDouble(strntweight) / 1000);
                        strntweight = obj_da_Invoice.GetWeightnew(txt_bl.Text, "FE", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
                        mtAmt = rate * exrate * (Convert.ToDouble(strntweight));

                        if (cbmAmt < mtAmt)
                        {
                            base1 = "MT";
                            amount = mtAmt;
                            unit = Convert.ToDouble(strntweight); //strntweight
                        }
                        else
                        {
                            base1 = "CBM";
                            amount = cbmAmt;
                            unit = Convert.ToDouble(strvolume);
                        }
                    }
                    else if (base1.ToUpper() == "KGS")
                    {
                        if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                        {
                            strchgweight = obj_da_Invoice.GetChargeWeight(txt_bl.Text, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
                            amount = rate * exrate * Convert.ToDouble(strchgweight);
                            unit = Convert.ToDouble(strchgweight);
                        }
                        else
                        {
                            strgrosswght = obj_da_Invoice.GetGrossWeight(txt_bl.Text, Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
                            amount = rate * exrate * Convert.ToDouble(strgrosswght);
                            unit = Convert.ToDouble(strgrosswght);
                        }
                    }
                    else if (base1.ToUpper() == "SB")
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            sizecount = obj_da_Invoice.GetSBillCount(txt_bl.Text, Convert.ToInt32(txt_job.Text), "BL", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
                            amount = rate * exrate * Convert.ToDouble(sizecount);
                            unit = Convert.ToDouble(sizecount);
                        }
                    }
                    else if (base1.ToUpper() == "VOLUME")
                    {
                        strgrosswght = obj_da_Invoice.GetVolumeQty(txt_bl.Text, Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
                        amount = rate * exrate * Convert.ToDouble(strgrosswght);
                        unit = Convert.ToDouble(strgrosswght);
                    }
                    else
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            sizecount = obj_da_Invoice.GetBaseCount(txt_bl.Text, base1, Session["StrTranType"].ToString(), "BL", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
                            amount = rate * exrate * Convert.ToDouble(sizecount);
                            unit = Convert.ToDouble(sizecount);
                        }
                        else
                        {
                            sizecount = obj_da_Invoice.GetBaseCount(txt_bl.Text, base1, Session["StrTranType"].ToString(), "BL", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
                            amount = rate * exrate * Convert.ToDouble(sizecount);
                            unit = Convert.ToDouble(sizecount);
                        }
                    }
                    //DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                    hid_fd.Value = DCAdviseObj.GetFDFromBLNO(txt_bl.Text, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), "H");
                    hid_douvolume.Value = unit.ToString();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

            return amount;
        }

        protected void save()
        {

            //DataAccess.ForwardingExports.BLDetailsWOJob obj_da_BLwojob = new DataAccess.ForwardingExports.BLDetailsWOJob();
            //DataAccess.Masters.MasterPort obj_da_Port = new DataAccess.Masters.MasterPort();
            //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();

            //DataAccess.ForwardingExports.JobInfo obj_da_Job = new DataAccess.ForwardingExports.JobInfo();
            //DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
            //DataAccess.ForwardingImports.BLDetails obj_da_BLImport = new DataAccess.ForwardingImports.BLDetails();

            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dt = new DataTable();
            //if (Session["LoginBranchid"].ToString() == "4")
            //{
            //    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Alert1');", true);
            //}
            //try
            //{
            //if (Session["LoginBranchid"].ToString() == "4")
            //{
            //    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Alert3');", true);
            //}
            if ((txt_notify.Text.Trim().Length > 0) && (txt_agent.Text.Trim().Length > 0))
            {
                if (hid_notifyid.Value.ToString() == hid_agentid.Value.ToString())
                {
                    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Notify Party and Agent Should not Same');", true);
                    txt_notify.Focus();
                    back = 1;
                    return;
                }
            }
            //if (Session["LoginBranchid"].ToString() == "4")
            //{
            //    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Alert2');", true);
            //}
            char Ourbl = 'N', Nomin = 'F';
            char OurblDG = 'N';
            if (Chk_DG.Checked == true)
                OurblDG = 'Y';
            if (BLTYPE.Text == "Our BL")
            {
                Ourbl = 'N';
            }
            else if (BLTYPE.Text == "Liner BL")
            {
                Ourbl = 'Y';
            }
            if (chk_agent.Checked == true)
                Nomin = 'N';
            string str_conttype;
            //if (Session["LoginBranchid"].ToString() == "4")
            //{
            //    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Alert3');", true);
            //}
            obj_dt = obj_da_Job.GetFEJobInfo(Convert.ToInt32(txt_job.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (obj_dt.Rows.Count > 0)
            {
                str_conttype = obj_dt.Rows[0]["jobtype"].ToString();
            }


            //if (lbl_Header.Text == "Our BL" || lbl_Header.Text == "Direct Bill of Lading (Liner)")
            if (lbl_header.Text == "Our BL" || lbl_header.Text == "Direct Bill of Lading (Liner)")
            {
                if (txt_orignalbl.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Enter Original BL');", true);
                    txt_orignalbl.Focus();
                    back = 1;
                    return;
                }
                else if (Convert.ToInt32(txt_orignalbl.Text) >= 5)
                {
                    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('No Of Original(s) should be lesser than or equal to Five');", true);
                    txt_orignalbl.Focus();
                    back = 1;
                    return;
                }
                bool Check = false;
                for (int i = 0; i <= chk_containerlist.Items.Count - 1; i++)
                {
                    if (chk_containerlist.Items[i].Selected == true)
                    {
                        Check = true;
                        break;
                    }
                }
                if (Check == false)
                {
                    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Select Atleast One Container');", true);
                    chk_containerlist.Focus();
                    back = 1;
                    return;
                }
                if (txt_orignalbl.Text.Trim().Length == 0)
                    txt_orignalbl.Text = "0";

                if (hid_jobtype.Value.ToString() != "3")
                {
                    if (Convert.ToDouble(txt_cbm.Text) == 0.0)
                    {
                        ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('CBM must greater than Zero');", true);
                        txt_cbm.Focus();
                        back = 1;
                        return;
                    }
                }
                if (txt_job.Text.Trim().Length > 0)
                    if (obj_da_Invoice.CheckClosedJobs("FE", int.Parse(txt_job.Text), int.Parse(Session["LoginBranchid"].ToString())) == 1)
                    {
                        ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Job has Closed Already You Can not Update the BL Details.');", true);
                        back = 1;
                        return;
                    }



                if (Btn_save.ToolTip == "Save")
                {
                    obj_dt = obj_da_Job.GetFEJobInfoMBL(txt_bl.Text.ToUpper(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    DataView obj_dtview = new DataView(obj_dt);
                    obj_dtview.RowFilter = "mblno='" + txt_bl.Text.ToUpper() + "'";
                    obj_dt = obj_dtview.ToTable();
                    if (obj_dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(txt_bl, typeof(TextBox), "BL", "alertify.alert('BL # and MBL # should not Same,kindly change MBL # in Job screen');", true);
                        txt_bl.Focus();
                        back = 1;
                        return;
                    }
                    obj_dt = obj_da_BLwojob.GeBLDetailsWOJ(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_dtview = new DataView(obj_dt);
                    obj_dtview.RowFilter = "blno='" + txt_bl.Text + "'";
                    obj_dt = obj_dtview.ToTable();
                    if (obj_dt.Rows.Count > 0)
                    {
                        hid_WojBLno.Value = txt_bl.Text;
                        Fn_GetWojBLdetail();
                        //Btn_save.Text = "Save";
                        Btn_save.ToolTip = "Save";
                        Btn_save1.Attributes["class"] = "btn ico-save";
                        back = 1;

                        return;
                    }

                    if (txt_booking.Text.Trim().Length == 0)
                    {
                        ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Select the correct Booking Number');", true);
                        txt_booking.Focus();
                        back = 1;
                        return;
                    }

                    //if (Session["LoginBranchid"].ToString() == "4")
                    //{
                    //    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Alert4');", true);
                    //}
                    Fn_InsContainer();
                    //if (Session["LoginBranchid"].ToString() == "4")
                    //{
                    //    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Alert5');", true);
                    //}
                    if (back == 1)
                    {
                        return;
                    }
                    string str_cont20 = "0", str_cont40 = "0";
                    string[] str_cont2040 = Fn_Contsize(txt_bl.Text, int.Parse(hid_jobtype.Value.ToString()));
                    if (back == 1)
                    {
                        return;
                    }
                    if (str_cont2040.Length > 1)
                        str_cont20 = str_cont2040[0].ToString();
                    str_cont40 = str_cont2040[1].ToString();
                    if (Convert.ToInt32(str_cont20) > 0 && Convert.ToInt32(str_cont40) == 0)
                    {
                        if (Convert.ToDouble(txt_cbm.Text) > limit20)
                        {
                            ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit20 + " ...Since " + str_cont20 + " X 20 Feet Container(s) was selected.');", true);
                            obj_da_BL.DelContainerDetails(int.Parse(txt_job.Text), txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                            txt_cbm.Focus();
                            back = 1;
                            return;
                        }

                    }
                    else if (Convert.ToInt32(str_cont40) > 0 && Convert.ToInt32(str_cont20) == 0)
                    {
                        if (Convert.ToDouble(txt_cbm.Text) > limit40)
                        {
                            ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit40 + " ...Since " + str_cont40 + " X 40 Feet Container(s) was selected.');", true);
                            obj_da_BL.DelContainerDetails(int.Parse(txt_job.Text), txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                            txt_cbm.Focus();
                            back = 1;
                            return;
                        }

                    }
                    else if (Convert.ToInt32(str_cont40) > 0 && Convert.ToInt32(str_cont20) > 0)
                    {
                        if (Convert.ToDouble(txt_cbm.Text) > limit240)
                        {
                            ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit240 + " ...Since " + str_cont20 + " X 20 Feet  and " + str_cont40 + " X 40 Feet Container(s) was selected.');", true);
                            obj_da_BL.DelContainerDetails(int.Parse(txt_job.Text), txt_bl.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                            txt_cbm.Focus();
                            back = 1;
                            return;
                        }

                    }

                    //if (Session["LoginBranchid"].ToString() == "4")
                    //{
                    //    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Alert6');", true);
                    //}
                    obj_da_BL.InsBLDetails(
                       Convert.ToInt32(txt_job.Text),
                        txt_bl.Text.Trim().ToUpper(),
                        Convert.ToDateTime(Utility.fn_ConvertDate(txt_issuedon.Text)),
                        Convert.ToInt32(hid_issued.Value.ToString()),
                         Convert.ToInt32(hid_shipperid.Value.ToString()),
                        txt_shipper.Text,
                        txt_shipperaddress.Text,
                        Convert.ToInt32(hid_consigneeid.Value),
                        txt_consignee.Text,
                        txt_consigneeaddress.Text,
                         Convert.ToInt32(hid_notifyid.Value),
                        txt_notify.Text,
                        txt_notifyaddress.Text,
                         Convert.ToInt32(hid_agentid.Value),
                         Convert.ToInt32(hid_chaid.Value),
                        txt_mark.Text.ToUpper(),
                        txt_description.Text.ToUpper(),
                        double.Parse(txt_grwt.Text),
                        double.Parse(txt_ntwt.Text),
                        double.Parse(txt_cbm.Text),
                        Convert.ToInt32(txt_pkgs.Text),
                        ddl_unit.SelectedItem.Text,
                        Convert.ToInt32(hid_receiptid.Value),
                        Convert.ToInt32(hid_loadingid.Value),
                         Convert.ToInt32(hid_dischargeid.Value),
                         Convert.ToInt32(hid_destinationid.Value),
                        ddl_freight.SelectedValue.ToString(),
                         Convert.ToInt32(ddl_shipment.SelectedValue.ToString()),
                        Nomin.ToString(),
                        Ourbl.ToString(),
                        ddl_HTS.SelectedValue.ToString(),
                         Convert.ToInt32(str_cont20),
                         Convert.ToInt32(str_cont40),
                         Convert.ToInt32(Session["LoginBranchid"].ToString()),
                         Convert.ToInt32(txt_orignalbl.Text),
                        Session["LoginBranchName"].ToString(),
                        Session["LoginDivisionName"].ToString(),
                        txt_remark.Text.ToUpper(),
                        short.Parse(ddl_BLsignatory.SelectedValue.ToString()),
                        OurblDG,
                         Convert.ToInt32(hid_salesid.Value),
                         Convert.ToInt32(Session["LoginEmpId"].ToString()),
                         Convert.ToInt32(hid_cargoid.Value),
                         Convert.ToInt32(Session["LoginDivisionId"].ToString()));


                    //DataAccess.Reportasp objRpt = new DataAccess.Reportasp();

                    objRpt.InsOEeventdetailsTask(Convert.ToInt32(txt_job.Text), txt_booking.Text.ToString(), "", "SI Updation",
                  Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), 0, "",6);




                    obj_da_BL.UpdateBLDetails4BLPrint(txt_bl.Text.Trim().ToUpper(), txt_receipt.Text, txt_loading.Text, txt_discharge.Text, txt_destination.Text, txt_pkgs.Text, txt_container.Text.ToUpper(), txt_grwt.Text, txt_ntwt.Text, txt_cbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_da_BL.UpdateAgentaddress(txt_bl.Text.Trim().ToUpper(), txt_agentaddress.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_da_BLImport.UpdateBooking(txt_booking.Text.ToUpper(), txt_bl.Text.Trim().ToUpper(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_da_Job.UpdateFEEventjobblno(int.Parse(txt_job.Text), txt_booking.Text, txt_bl.Text.Trim(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_da_BL.updmovetypeinbl(txt_bl.Text.Trim().ToUpper(), int.Parse(Session["LoginBranchid"].ToString()), Convert.ToInt32(ddl_move.SelectedValue));

                    // ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Saved for BL# " + txt_bl.Text + "');", true);
                    if (txt_bl.Text == hid_WojBLno.Value.ToString())
                    {
                        obj_da_BLwojob.UpdBLDetailsInvCostWOJ(hid_WojBLno.Value.ToString().ToUpper(), int.Parse(txt_job.Text), int.Parse(hid_agentid.Value.ToString()), int.Parse(hid_jobtype.Value), int.Parse(str_cont20), int.Parse(str_cont40), int.Parse(Session["LoginBranchid"].ToString()));
                        obj_da_BLwojob.DelBLDetailsWOJ(hid_WojBLno.Value.ToString().ToUpper(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

                        //ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Saved for BL# " + txt_bl.Text + "');", true);
                        //Fn_Clear();
                    }
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 2, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_bl.Text + "/S");
                    if (Convert.ToDateTime(Logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                    {

                        if (Session["StrTranType"] != null)
                        {

                            obj_dt = obj_da_BLImport.ShowBLDetails(txt_bl.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            if (obj_dt.Rows.Count > 0)
                            {
                                str_BL = obj_dt.Rows[0]["splitbl"].ToString();

                            }
                            str_booking = obj_da_BLImport.GetBookinkNo(txt_bl.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            if (str_booking == "0" && Session["StrTranType"].ToString() == "FI")
                            {
                                str_booking = obj_da_BLImport.GetBookinkNo(str_BL, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            }

                            if (str_booking != "0")
                            {
                                dtsupply = obj_da_BL.GetBookingDt(str_booking, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
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



                    AutoInvoice();

                    Autocnops();

                    autodebitOS();
                    autocreditOS();

                    //if(invgen==false)
                    //{
                    //    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Saved for BL# " + txt_bl.Text + "');", true);
                    //}else
                    //{
                    //    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Saved for BL# " + txt_bl.Text + " and System Auto-generated Proforma Invoice # " + Refno +"');", true);
                    //}


                    string supplyto = customerobj.GetCustomername(Convert.ToInt32(hid_SupplyTo.Value));
                    ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), supplyto);



                    //if (invgen == false)
                    //{
                    //    // ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Saved for BL# " + txt_bl.Text + "');", true);
                    //    StrScript += " Details Saved for BL# " + txt_bl.Text;
                    //}
                    //else
                    //{
                    //    // ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Saved for BL# " + txt_bl.Text + " and System Auto-generated Proforma Invoice # " + Refno + "');", true);

                    //    StrScript += " Details Saved for BL#" + txt_bl.Text + "and System Auto-generated Proforma Invoice #" + Refno;

                    //}


                    StrScript += " Details Saved for BL# " + txt_bl.Text;
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
                        StrScript += ". System Auto-generated Proforma OSDN # " + refnodebitOs;
                    }
                    if (refnocreditOs != 0)
                    {
                        StrScript += ". System Auto-generated Proforma OSCN # " + refnocreditOs;
                    }

                    if (bolcuststat == true)
                    {
                        StrScript += " State Name not Updated in Master,Kindly update Master Customer " + supplyto + ",GST NOT Calculated Propertly";
                    }
                    if (bolcuststat1 == true)
                    {
                        StrScript += " Kindly update SUPPLY TO Name " + supplyto + ",GST NOT Calculated Propertly";
                    }
                    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('" + StrScript + "');", true);

                }
                else if (Btn_save.ToolTip == "Update")
                {
                    if (Session["LoginBranchid"].ToString() == hid_branchid.Value.ToString())
                    {
                        if (txt_booking.Text.Trim().Length == 0)
                        {
                            ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Select the correct Booking Number');", true);
                            txt_booking.Focus();
                            back = 1;
                            return;
                        }
                    }
                    Fn_UpdateContainer();
                    string str_cont20 = "0", str_cont40 = "0";
                    string[] str_cont2040 = Fn_Contsize(txt_bl.Text, int.Parse(hid_jobtype.Value.ToString()));
                    if (str_cont2040.Length > 1)
                        str_cont20 = str_cont2040[0].ToString();
                    str_cont40 = str_cont2040[1].ToString();
                    obj_da_BL.UpdateBLDetails(
                        txt_bl.Text.Trim().ToUpper(),
                        Convert.ToDateTime(Utility.fn_ConvertDate(txt_issuedon.Text)),
                         Convert.ToInt32(hid_issued.Value.ToString()),
                         Convert.ToInt32(hid_shipperid.Value.ToString()),
                        txt_shipper.Text,
                        txt_shipperaddress.Text,
                         Convert.ToInt32(hid_consigneeid.Value),
                        txt_consignee.Text,
                        txt_consigneeaddress.Text,
                         Convert.ToInt32(hid_notifyid.Value),
                        txt_notify.Text,
                        txt_notifyaddress.Text,
                         Convert.ToInt32(hid_agentid.Value),
                         Convert.ToInt32(hid_chaid.Value),
                        txt_mark.Text.ToUpper(),
                        txt_description.Text.ToUpper(),
                        decimal.Parse(txt_grwt.Text),
                         double.Parse(txt_ntwt.Text),
                        double.Parse(txt_cbm.Text),
                         Convert.ToInt32(txt_pkgs.Text),
                        ddl_unit.SelectedItem.Text,
                         Convert.ToInt32(hid_receiptid.Value),
                         Convert.ToInt32(hid_loadingid.Value),
                         Convert.ToInt32(hid_dischargeid.Value),
                         Convert.ToInt32(hid_destinationid.Value),
                        ddl_freight.SelectedValue.ToString(),
                        Convert.ToInt32(ddl_shipment.SelectedValue.ToString()),
                        Nomin.ToString(),
                        Ourbl.ToString(),
                        ddl_HTS.SelectedValue.ToString(),
                         Convert.ToInt32(str_cont20),
                         Convert.ToInt32(str_cont40),
                         //Convert.ToInt32(hid_job.Value.ToString()),  //Convert.ToDouble(hid_cbm.Value.ToString()),
                         Convert.ToInt32(txt_job.Text),
                        double.Parse(txt_cbm.Text),

                         Convert.ToInt32(txt_orignalbl.Text),
                        txt_remark.Text.ToUpper(),
                        short.Parse(ddl_BLsignatory.SelectedValue.ToString()),
                        OurblDG,
                         Convert.ToInt32(hid_salesid.Value),
                         Convert.ToInt32(hid_cargoid.Value),
                         Convert.ToInt32(Session["LoginBranchid"].ToString()),
                         Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    obj_da_BL.UpdateBLDetails4BLPrint(txt_bl.Text.Trim().ToUpper(), txt_receipt.Text, txt_loading.Text, txt_discharge.Text, txt_destination.Text, txt_pkgs.Text, txt_container.Text.ToUpper(), txt_grwt.Text, txt_ntwt.Text, txt_cbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_da_BL.UpdateAgentaddress(txt_bl.Text.Trim().ToUpper(), txt_agentaddress.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_da_BL.updmovetypeinbl(txt_bl.Text.Trim().ToUpper(), int.Parse(Session["LoginBranchid"].ToString()), Convert.ToInt32(ddl_move.SelectedValue));
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 2, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_bl.Text.ToUpper() + "/U");
                    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Update for BL# " + txt_bl.Text + "');", true);
                    // Fn_Clear();

                    /*   if (Convert.ToDateTime(Logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                       {

                           if (Session["StrTranType"] != null)
                           {

                               obj_dt = obj_da_BLImport.ShowBLDetails(txt_bl.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                               if (obj_dt.Rows.Count > 0)
                               {
                                   str_BL = obj_dt.Rows[0]["splitbl"].ToString();

                               }
                               str_booking = obj_da_BLImport.GetBookinkNo(txt_bl.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                               if (str_booking == "0" && Session["StrTranType"].ToString() == "FI")
                               {
                                   str_booking = obj_da_BLImport.GetBookinkNo(str_BL, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                               }

                               if (str_booking != "0")
                               {
                                   dtsupply = obj_da_BL.GetBookingDt(str_booking, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
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

                       Autocnops();
                       AutoInvoice();*/

                }
            }
            else if (lbl_header.Text == "BILL OF LADING WOJ")
            {
                if (txt_vessel.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('VESSEL CANNOT BE BLANK');", true);
                    txt_vessel.Focus();
                    back = 1;
                    return;
                }
                else if (vesselobj.GetVesselid(txt_vessel.Text) == 0)
                {
                    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('INVALID VESSEL NAME');", true);
                    txt_vessel.Focus();
                    back = 1;
                    return;
                }
                if (txt_voyage.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('VOYAGE CANNOT BE BLANK');", true);
                    txt_voyage.Focus();
                    back = 1;
                    return;
                }
                if (txt_container.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('CONTAINER VESSEL NAME');", true);
                    txt_container.Focus();
                    back = 1;
                    return;
                }
                if (Btn_save.ToolTip == "Save")
                {
                    obj_da_BLwojob.InsBLWOJobDet(
                            txt_bl.Text.Trim().ToUpper(),
                            Convert.ToDateTime(Utility.fn_ConvertDate(txt_issuedon.Text)),
                             Convert.ToInt32(hid_issued.Value.ToString()),
                             Convert.ToInt32(hid_shipperid.Value.ToString()),
                            txt_shipper.Text,
                            txt_shipperaddress.Text,
                             Convert.ToInt32(hid_consigneeid.Value),
                            txt_consignee.Text,
                            txt_consigneeaddress.Text,
                             Convert.ToInt32(hid_notifyid.Value),
                            txt_notify.Text,
                            txt_notifyaddress.Text,
                             Convert.ToInt32(hid_agentid.Value),
                             Convert.ToInt32(hid_chaid.Value),
                            txt_mark.Text.ToUpper(),
                            txt_description.Text.ToUpper(),
                            double.Parse(txt_grwt.Text),
                            double.Parse(txt_ntwt.Text),
                            double.Parse(txt_cbm.Text),
                             Convert.ToInt32(txt_pkgs.Text),
                            ddl_unit.SelectedItem.Text,
                             Convert.ToInt32(hid_receiptid.Value),
                             Convert.ToInt32(hid_loadingid.Value),
                             Convert.ToInt32(hid_dischargeid.Value),
                             Convert.ToInt32(hid_destinationid.Value),
                            ddl_freight.SelectedValue.ToString(),
                             Convert.ToInt32(ddl_shipment.SelectedValue.ToString()),
                            Nomin.ToString(),
                            Ourbl.ToString(),
                            ddl_HTS.SelectedValue.ToString(),
                            txt_vessel.Text.ToUpper() + " V. " + txt_voyage.Text.ToUpper(),
                            txt_container.Text.ToUpper(),
                            txt_remark.Text.ToUpper(),
                            short.Parse(ddl_BLsignatory.SelectedValue.ToString()),
                            OurblDG,
                             Convert.ToInt32(Session["LoginBranchid"].ToString()),
                             Convert.ToInt32(Session["LoginDivisionId"].ToString()),
                             Convert.ToInt32(hid_cargoid.Value));
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 86, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_bl.Text.ToUpper() + "/WOJS");
                    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Saved for BL# " + txt_bl.Text.ToUpper() + "');", true);
                    //Fn_Clear_Bltxt();
                }
                else if (Btn_save.ToolTip == "Update")
                {
                    obj_da_BLwojob.UpdBLWOJobDet(
                                txt_bl.Text.Trim().ToUpper(),
                                Convert.ToDateTime(Utility.fn_ConvertDate(txt_issuedon.Text)),
                                 Convert.ToInt32(hid_issued.Value.ToString()),
                                 Convert.ToInt32(hid_shipperid.Value.ToString()),
                                txt_shipper.Text,
                                txt_shipperaddress.Text,
                                 Convert.ToInt32(hid_consigneeid.Value),
                                txt_consignee.Text,
                                txt_consigneeaddress.Text,
                                Convert.ToInt32(hid_notifyid.Value),
                                txt_notify.Text,
                                txt_notifyaddress.Text,
                                 Convert.ToInt32(hid_agentid.Value),
                                 Convert.ToInt32(hid_chaid.Value),
                                txt_mark.Text.ToUpper(),
                                txt_description.Text.ToUpper(),
                                double.Parse(txt_grwt.Text),
                                double.Parse(txt_ntwt.Text),
                                double.Parse(txt_cbm.Text),
                                 Convert.ToInt32(txt_pkgs.Text),
                                ddl_unit.SelectedItem.Text,
                                 Convert.ToInt32(hid_receiptid.Value),
                                 Convert.ToInt32(hid_loadingid.Value),
                                 Convert.ToInt32(hid_dischargeid.Value),
                                 Convert.ToInt32(hid_destinationid.Value),
                                ddl_freight.SelectedValue.ToString(),
                                 Convert.ToInt32(ddl_shipment.SelectedValue.ToString()),
                                Nomin.ToString(),
                                Ourbl.ToString(),
                                ddl_HTS.SelectedValue.ToString(),
                                txt_vessel.Text.ToUpper() + " V. " + txt_voyage.Text.ToUpper(),
                                txt_container.Text,
                                txt_remark.Text.ToUpper(),
                                short.Parse(ddl_BLsignatory.SelectedValue.ToString()),
                                OurblDG,
                                 Convert.ToInt32(Session["LoginBranchid"].ToString()),
                                 Convert.ToInt32(Session["LoginDivisionId"].ToString()),
                                 Convert.ToInt32(hid_cargoid.Value));






                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 86, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_bl.Text.ToUpper() + "/WOJU");
                    ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('Details Update for BL# " + txt_bl.Text.ToUpper() + "');", true);
                    //Fn_Clear_Bltxt();
                }

            }
            // Btn_save.Text = "Update";
            Btn_save.ToolTip = "Update";
            Btn_save1.Attributes["class"] = "btn ico-update";
            // Btn_cancel.Text = "Cancel";
            Btn_cancel.ToolTip = "Cancel";
            Btn_cancel1.Attributes["class"] = "btn ico-cancel";
            UserRights();
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    if (Session["LoginBranchid"].ToString() == "4")
            //    {
            //        ScriptManager.RegisterStartupScript(Btn_save, typeof(Button), "BL", "alertify.alert('RAJA');", true);
            //    }
            //    //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}
        }

        protected void btn_no_Click(object sender, EventArgs e)
        {
            return;
        }

        protected void Grd_Booking_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grd_Booking.PageIndex = e.NewPageIndex;
                LoadBooking();
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
                Grd_Job.PageIndex = e.NewPageIndex;
                LoadJob();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                if (lbl_header.Text == "Direct Bill of Lading (Liner)")
                {
                    if (txt_job.Text != "" && txt_bl.Text == "")
                    {
                        if (txt_bl.Text == "")
                        {
                            str_RptName = "FEBLDetails.rpt";
                            str_sf = "{FEBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FEBLDetails.jobno}=" + txt_job.Text;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "FEBL", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                    }
                    else
                    {
                        if (txt_bl.Text == "")
                        {
                            str_RptName = "FEBLDetails.rpt";
                            str_sf = "{FEBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]);
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "FEBL", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                    }
                }
                else
                {
                    str_RptName = "FEBL4PLWOJ.rpt";
                    Session["str_sfs"] = "{FEBLDetailsWOJob.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FEBLDetailsWOJob.jobno}='" + txt_bl.Text + "'";
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "FEBL", str_Script, true);
                    //Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                }
                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 2, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_bl.Text + "FE");
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

                Session["blnofi"] = txt_bl.Text;
                // Session["StrTranType"] = strtrantype;
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

        protected void txt_vessel_TextChanged(object sender, EventArgs e)
        {
            int vesselid = vesselobj.GetVesselid(txt_vessel.Text.ToUpper());
            if (vesselid != 0)
            {
                hid_vesselid.Value = vesselid.ToString();
                txt_vessel.Focus();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Vessel');", true);
                txt_vessel.Text = "";
                txt_vessel.Focus();
                return;
            }
        }

        protected void txt_issued_TextChanged(object sender, EventArgs e)
        {
            int port = da_obj_Port.GetNPortid(txt_issued.Text.ToUpper());
            if (port == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid ISSUEDAT NAME');", true);
                txt_issued.Text = "";
                txt_issued.Focus();
                return;
            }
            else
            {
                DataTable dt;
                //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                dt = obj_MasterPort.SelPortName4typepadimg(txt_issued.Text.ToUpper(), Session["StrTranType"].ToString());
                issuedflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                hid_issued.Value = port.ToString();
                txt_issued.Focus();
            }

        }

        protected void txt_shipper_TextChanged(object sender, EventArgs e)
        {
            obj_dt = customerobj.GetexactCustomer(txt_shipper.Text.ToUpper(), "C");
            if (obj_dt.Rows.Count > 0)
            {
                txt_consignee.Focus();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Shipper');", true);
                txt_shipper.Text = "";
                txt_shipperaddress.Text = "";
                txt_shipper.Focus();
                return;
            }
        }

        protected void txt_consignee_TextChanged(object sender, EventArgs e)
        {
            obj_dt = customerobj.GetexactCustomer(txt_consignee.Text.ToUpper(), "C");
            if (obj_dt.Rows.Count > 0)
            {
                txt_notify.Focus();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Consignee');", true);
                txt_consignee.Text = "";
                txt_consigneeaddress.Text = "";
                txt_consignee.Focus();
                return;
            }
        }

        protected void amendbl_Click(object sender, EventArgs e)
        {

        }

        protected void txt_notify_TextChanged(object sender, EventArgs e)
        {
            obj_dt = customerobj.GetexactCustomer(txt_notify.Text.ToUpper(), "C");
            if (obj_dt.Rows.Count > 0)
            {
                txt_agent.Focus();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid NOTIFY PARTY');", true);
                txt_notify.Text = "";
                txt_notifyaddress.Text = "";
                txt_notify.Focus();
                return;
            }
        }

        protected void txt_agent_TextChanged(object sender, EventArgs e)
        {
            //int customer = customerobj.GetCustomerid(txt_agent.Text.ToUpper());
            obj_dt = customerobj.GetexactCustomer(txt_agent.Text.ToUpper(), "P");
            if (obj_dt.Rows.Count > 0 && hid_agentid.Value != "0")
            {
                txt_receipt.Focus();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid AGENT');", true);
                txt_agent.Text = "";
                txt_agentaddress.Text = "";
                txt_agent.Focus();
                return;
            }
        }

        protected void txt_receipt_TextChanged(object sender, EventArgs e)
        {
            if (da_obj_Port.GetNPortid(txt_receipt.Text.ToUpper()) == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid PLACE OF RECEIPT');", true);
                txt_receipt.Text = "";
                txt_receipt.Focus();
                return;
            }
            else
            {
                //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                DataTable dtflag;
                dtflag = obj_MasterPort.SelPortName4typepadimg(txt_receipt.Text.ToUpper(), Session["StrTranType"].ToString());
                porflag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";
                txt_loading.Focus();
            }
        }

        protected void txt_loading_TextChanged(object sender, EventArgs e)
        {
            if (da_obj_Port.GetNPortid(txt_loading.Text.ToUpper()) == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid PORT OF LOADING');", true);
                txt_loading.Text = "";
                txt_loading.Focus();
                return;
            }
            else
            {
                //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                DataTable dtflag;
                dtflag = obj_MasterPort.SelPortName4typepadimg(txt_loading.Text.ToUpper(), Session["StrTranType"].ToString());
                flagimg.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";
                txt_discharge.Focus();
            }
        }

        protected void txt_discharge_TextChanged(object sender, EventArgs e)
        {
            if (da_obj_Port.GetNPortid(txt_discharge.Text.ToUpper()) == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid PORT OF DISCHARGE');", true);
                txt_discharge.Text = "";
                txt_discharge.Focus();
                return;
            }
            else
            {
                //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                DataTable dtflag;
                dtflag = obj_MasterPort.SelPortName4typepadimg(txt_discharge.Text.ToUpper(), Session["StrTranType"].ToString());
                podflag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";
                txt_destination.Focus();
            }
        }

        protected void txt_destination_TextChanged(object sender, EventArgs e)
        {
            if (da_obj_Port.GetNPortid(txt_destination.Text.ToUpper()) == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Place of Delivery');", true);
                txt_destination.Text = "";
                txt_destination.Focus();
                return;
            }
            else
            {
                //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                DataTable dtflag;
                dtflag = obj_MasterPort.SelPortName4typepadimg(txt_destination.Text.ToUpper(), Session["StrTranType"].ToString());
                fdflag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";
                txt_mark.Focus();
            }
        }

        protected void txt_cha_TextChanged(object sender, EventArgs e)
        {
            obj_dt = customerobj.GetexactCustomer(txt_cha.Text.ToUpper(), "F");
            if (obj_dt.Rows.Count > 0 && hid_chaid.Value != "0")
            {
                txt_cha.Focus();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid CUSTOM HOUSE AGENT');", true);
                txt_cha.Text = "";
                txt_cha.Focus();
                return;
            }
        }

        protected void txt_commotity_TextChanged(object sender, EventArgs e)
        {
            if (cargoobj.GetCargoid(txt_commotity.Text) == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid COMMODITY');", true);
                txt_commotity.Text = "";
                txt_commotity.Focus();
                return;
            }
            else
            {
                txt_description.Focus();
            }
        }

        //protected void txt_grwt_TextChanged(object sender, EventArgs e)
        //{
        //    txt_ntwt.Text = txt_grwt.Text;
        //}
        public void checkdata()
        {
            int port = da_obj_Port.GetNPortid(txt_issued.Text.ToUpper());
            if (Convert.ToInt32(hid_issued.Value) != 0 || hid_issued.Value == "")
            {
                hid_issued.Value = port.ToString();
                txt_issued.Focus();

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid ISSUED AT NAME');", true);
                txt_issued.Text = "";
                txt_issued.Focus();
                back = 1;
                return;
            }
            obj_dt = customerobj.GetexactCustomer(txt_shipper.Text.ToUpper(), "C");
            if (obj_dt.Rows.Count > 0 && hid_shipperid.Value != "0")
            {

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Shipper');", true);
                txt_shipper.Text = "";
                txt_shipperaddress.Text = "";
                txt_shipper.Focus();
                back = 1;
                return;
            }
            obj_dt = customerobj.GetexactCustomer(txt_consignee.Text.ToUpper(), "C");
            if (obj_dt.Rows.Count > 0 && hid_consigneeid.Value != "0")
            {

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Consignee');", true);
                txt_consignee.Text = "";
                txt_consigneeaddress.Text = "";
                txt_consignee.Focus();
                back = 1;
                return;
            }
            obj_dt = customerobj.GetexactCustomer(txt_notify.Text.ToUpper(), "C");
            if (obj_dt.Rows.Count > 0 && hid_notifyid.Value != "0")
            {

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid NOTIFY PARTY');", true);
                txt_notify.Text = "";
                txt_notifyaddress.Text = "";
                txt_notify.Focus();
                back = 1;
                return;
            }
            obj_dt = customerobj.GetexactCustomer(txt_agent.Text.ToUpper(), "P");
            if (obj_dt.Rows.Count > 0 && hid_agentid.Value != "0")
            {

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid AGENT');", true);
                txt_agent.Text = "";
                txt_agentaddress.Text = "";
                txt_agent.Focus();
                back = 1;
                return;
            }
            if (da_obj_Port.GetNPortid(txt_receipt.Text.ToUpper()) == 0 || hid_receiptid.Value == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid PLACE OF RECEIPT');", true);
                txt_receipt.Text = "";
                txt_receipt.Focus();
                back = 1;
                return;
            }
            if (da_obj_Port.GetNPortid(txt_loading.Text.ToUpper()) == 0 || hid_loadingid.Value == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid PORT OF LOADING');", true);
                txt_loading.Text = "";
                txt_loading.Focus();
                back = 1;
                return;
            }
            if (da_obj_Port.GetNPortid(txt_discharge.Text.ToUpper().Trim()) == 0 || hid_dischargeid.Value == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid PORT OF DISCHARGE');", true);
                txt_discharge.Text = "";
                txt_discharge.Focus();
                back = 1;
                return;
            }
            if (da_obj_Port.GetNPortid(txt_destination.Text.ToUpper().Trim()) == 0 || hid_destinationid.Value == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Place of Delivery');", true);
                txt_destination.Text = "";
                txt_destination.Focus();
                back = 1;
                return;
            }
            if (cargoobj.GetCargoid(txt_commotity.Text) == 0 || hid_cargoid.Value == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid COMMODITY');", true);
                txt_commotity.Text = "";
                txt_commotity.Focus();
                back = 1;
                return;
            }
            obj_dt = customerobj.GetexactCustomer(txt_cha.Text.ToUpper(), "F");
            if (obj_dt.Rows.Count > 0 && hid_chaid.Value != "0")
            {

            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid CUSTOM HOUSE AGENT');", true);
                //txt_cha.Text = "";
                //txt_cha.Focus();
                //back = 1;
                //return;
            }
        }

        protected void BLTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = BLTYPE.SelectedItem.Text;

            if (type == "Our BL")
            {
                lbl_header.Text = "Our BL";
                div_vessel.Visible = false;
                Chk_DG.Enabled = false;
                txt_job.Focus();
                BLTYPE.SelectedIndex = 1;
                if (txt_booking.Text != "")
                {
                    txt_bl.ReadOnly = true;
                    txt_bl.Text = txt_booking.Text;
                }
                txt_bl.ToolTip = "Our BL";
                txt_bl.Attributes.Add("placeholder", "Our BL");
            }
            else if (type == "Liner BL")
            {

                // lbl_header.Text = "Our BL";
                txt_bl.ReadOnly = false;
                lbl_header.Text = "Direct Bill of Lading (Liner)";
                div_vessel.Visible = false;
                Chk_DG.Enabled = false;
                BLTYPE.SelectedIndex = 2;
                txt_bl.Text = "";
                txt_bl.ToolTip = "Liner BL";
                txt_bl.Attributes.Add("placeholder", "Liner BL");
                //txt_job.Focus();

            }
            bookingdetails();
            if (hid_intcustomerid.Value != "")
            {
                dtcust = obj_da_BL.GetCreditApprovalFromCustomer(Convert.ToInt32(hid_intcustomerid.Value));
            }
            //if (dtcust.Rows.Count > 0) --as per nambi sir instruction hided on 18july2022
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
            //    Btn_save.Visible = false;
            //    return;

            //}
        }

        protected void Proinvoic_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1013, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_bl.Text != "")
                    {
                        string feblno = txt_bl.Text;
                        string appfbl = "Proforma Sales Invoice";
                        //Response.Redirect("../Accounts/ProfomaInvoice.aspx?app1=" + app2);
                        Response.Redirect("../Accounts/ProformaLV.aspx?appfbl=" + appfbl + "&feblno=" + feblno);
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

        protected void procrednote_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1014, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_bl.Text != "")
                    {
                        string feblno = txt_bl.Text;
                        string appfbl = "Proforma Purchase Invoice";
                        //Response.Redirect("../Accounts/ProfomaInvoice.aspx?app1=" + app2);
                        Response.Redirect("../Accounts/ProformaLV.aspx?appfbl=" + appfbl + "&feblno=" + feblno);
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



        protected void txt_cbm_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                double check1 = 0;
                if (double.TryParse(txt_cbm.Text, out check1))
                {

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please enter Numeric value');", true);
                    txt_cbm.Text = "";
                    txt_cbm.Focus();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please enter Numeric');", true);
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
            Panel2.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 2, "BL", txt_bl.Text, txt_bl.Text, Session["StrTranType"].ToString());
            if (txt_bl.Text != "")
            {
                JobInput.Text = txt_bl.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void autodebitOS()
        {
            int vouyear;
            if (hid_quto.Value == "")
            {
                hid_quto.Value = "0";

            }
            Double amt = 0.00;
            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "FE")
                {
                    if (txt_booking.Text != "")
                    {
                        dtinv = obj_da_BL.GetQuotchgs4debitcreditFE(Convert.ToInt32(hid_quto.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_booking.Text);
                    }
                }

            }


            //DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
            //DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
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
                //DataAccess.AirImportExports.AIEJobInfo objaej = new DataAccess.AirImportExports.AIEJobInfo();
                dtd = objaej.GetAIagentid(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(txt_job.Text));

                DebitOS = true;


                refnodebitOs = da_obj_OSDNCN.InsproOSvouchershead(Convert.ToDateTime(dtdate), "OE", Convert.ToDouble(amount),
                                        Convert.ToInt32(txt_job.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value),
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
                        HIDMAWBLNO.Value = txt_bl.Text.ToUpper();
                    }



                    base1 = dtinv.Rows[i]["base"].ToString();
                    rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                    exrate = obj_da_Invoice.GetOSExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(da_obj_logobj.GetDate()), "C", Convert.ToInt32(Session["LoginDivisionId"]));
                    famount = checkbase(base1, Convert.ToDouble(rate), Convert.ToDouble(exrate)).ToString();
                    string osamount = Convert.ToDecimal(famount).ToString("#,0.00");
                    actual = actual + Convert.ToDouble(osamount);
                    fd = Convert.ToInt32(hid_fd.Value);
                    unit = Convert.ToInt32(hid_douvolume.Value);

                    DAdvise.InsOSVdetails(Convert.ToInt32(txt_job.Text), "OE", HIDMAWBLNO.Value.ToUpper(),
                      Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate),
                       base1, Convert.ToDouble(osamount), 5, Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, unit, Convert.ToInt32(hid_SupplyTo.Value),
                       "Y", Convert.ToInt32(hid_SupplyTo.Value), "N", refnodebitOs, Convert.ToInt32(vouyear));
                    //if (unit == 0)
                    //{
                    //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Amount is calculated as 0 ,Base Unit details not calculated properly,Kindly Update the charges once again in proforma screen..);", true);

                    //}
                }
                //for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                //{
                //    if (dtinv.Rows[i]["agentid"].ToString() != "")
                //    {
                //        hid_intagent.Value = dtinv.Rows[0]["agentid"].ToString();
                //        hid_SupplyTo.Value = hid_intagent.Value;
                //    }
                //    else
                //    {
                //        if (dtd.Rows[0]["agent"].ToString() != "")
                //        {
                //            hid_intagent.Value = dtd.Rows[0]["agent"].ToString();
                //            hid_SupplyTo.Value = hid_intagent.Value;
                //        }
                //    }
                //    if (dtd.Rows[0]["mawblno"].ToString() != "")
                //    {
                //        // HIDMAWBLNO.Value = dtd.Rows[0]["mawblno"].ToString();
                //        HIDMAWBLNO.Value = txt_bl.Text.ToUpper();
                //    }

                //    base1 = dtinv.Rows[i]["base"].ToString();
                //    rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                //    exrate = obj_da_Invoice.GetOSExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(da_obj_logobj.GetDate()), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                //    famount = CheckBaseosdn(base1, Convert.ToDouble(rate), Convert.ToDouble(exrate)).ToString();
                //    string osamount = Convert.ToDecimal(famount).ToString("#,0.00");
                //    actual = actual + Convert.ToDouble(osamount);

                //    DAdvise.InsDCAdviseForGstOSV(Convert.ToInt32(txt_job.Text), "OE", HIDMAWBLNO.Value.ToUpper(),
                //       Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate),
                //       base1, Convert.ToDouble(osamount), 5, Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, unit, Convert.ToInt32(hid_SupplyTo.Value),
                //       "Y", Convert.ToInt32(hid_intagent.Value));


                //}
                //DataAccess.AirImportExports.AIEBLDetails objae = new DataAccess.AirImportExports.AIEBLDetails();

                //refnodebitOs = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), "OE", Convert.ToDouble(amount),
                //                                   Convert.ToInt32(txt_job.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value),
                //                                   Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual,
                //                                   Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate, 5);
                DataTable dttn = new DataTable();
                dttn = da_obj_OSDNCN.Getupdacdebitfcamt(refnodebitOs, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(txt_job.Text));
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
                //da_obj_OSDNCN.Getupdacosdnproupdnew(refnodebitOs, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]),
                //    Convert.ToInt32(vouyear), Convert.ToInt32(txt_job.Text), fcamt1);

                da_obj_OSDNCN.Getupdacosdnproupdnew(refnodebitOs, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]),
                    Convert.ToInt32(vouyear), Convert.ToInt32(txt_job.Text), fcamt1, "DebitAdvise");

            }
            else
            {
                DebitOS = false;
            }

        }

        public double CheckBaseosdn(string strbase, double rate, double exrate)
        {
            strTranType = Session["StrTranType"].ToString();
            DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txt_job.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
            if (DtBLNO.Rows.Count > 0)
            {
                mblno = DtBLNO.Rows[0][0].ToString();
            }
            if (strbase == "BL" || strbase == "HWBL" || strbase == "DOC")
            {
                if (txt_bl.Text == mblno)
                {
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                }
                else
                {
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                }
                douvolume = 1;
                amount = rate * exrate;
                //---------------------------------------------

            }
            else if (strbase == "CBM" || strbase == "MT")
            {
                if (strbase == "CBM")
                {
                    if (strTranType == "FE")
                    {
                        if (txt_bl.Text == mblno)
                        {
                            volume = obj_da_Invoice.GetSumofVolume(txt_job.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            douvolume = volume;
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                            amount = rate * exrate * volume;
                        }
                        else
                        {
                            volume = obj_da_Invoice.GetVolume(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                            douvolume = volume;
                            amount = rate * exrate * volume;
                        }
                    }
                    else
                    {
                        if (txt_bl.Text == mblno)
                        {
                            volume = obj_da_Invoice.GetSumofVolume(txt_job.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
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
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                        }
                        else
                        {
                            volume = obj_da_Invoice.GetVolume(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
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
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                        }
                    }
                }
                else
                {
                    if (strbase == "MT")
                    {
                        if (strTranType == "FE" || strTranType == "FI")
                        {
                            if (txt_bl.Text == mblno)
                            {
                                // wt = obj_da_Invoice.GetSumofWeight(txt_job.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                // amount = rate * exrate * (wt / 1000);

                                wt = obj_da_Invoice.GetSumofWeightnew(txt_job.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                amount = rate * exrate * (wt);
                                douvolume = wt;
                                fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                            }
                            else
                            {
                                //wt = obj_da_Invoice.GetWeight(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                //amount = rate * exrate * (wt / 1000);

                                wt = obj_da_Invoice.GetWeightnew(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                amount = rate * exrate * (wt);
                                douvolume = wt;
                                fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
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
                    if (txt_bl.Text == mblno)
                    {
                        wt = obj_da_Invoice.GetSumofChargeWght(Convert.ToInt32(txt_job.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * wt;
                        douvolume = wt;
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                    }
                    else
                    {
                        wt = obj_da_Invoice.GetChargeWeight(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * wt;
                        douvolume = wt;
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                    }

                }
                else
                {
                    wt = obj_da_Invoice.GetGrossWeight(txt_bl.Text, Convert.ToInt32(Session["LoginBranchid"]));
                    amount = rate * exrate * wt;
                    douvolume = wt;
                }
            }

            else if (strbase == "PKG")
            {
                //DataAccess.Accounts.Invoice objinv = new DataAccess.Accounts.Invoice();
                //DataTable dtn = new DataTable();
                //dtn = objinv.CheckIPDCWBLShipperinvoiceget(cmbbl.SelectedItem.Text, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                //int shiperinv = dtn.Rows.Count;
                amount = rate * exrate * Convert.ToInt32(Session["noofpks"]);
                douvolume = Convert.ToInt32(Session["noofpks"]);
            }

            //---------------------------------------------------------------------------------------------------------

            else
            {
                DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txt_job.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                if (DtBLNO.Rows.Count > 0)
                {
                    mblno = DtBLNO.Rows[0][0].ToString();
                }
                if (txt_bl.Text != mblno)
                {
                    sizecount1 = obj_da_Invoice.GetBaseCount(txt_bl.Text, strbase, strTranType, "BL", Convert.ToInt32(Session["LoginBranchid"]));
                    amount = rate * exrate * sizecount1;
                    douvolume = sizecount1;
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                }

                else
                {
                    sizecount1 = obj_da_Invoice.GetBaseCount(txt_job.Text, strbase, strTranType, "MBL", Convert.ToInt32(Session["LoginBranchid"]));
                    amount = rate * exrate * sizecount1;
                    douvolume = sizecount1;
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_bl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                }
            }

            hid_douvolume.Value = douvolume.ToString();
            hid_fd.Value = fd.ToString();
            return amount;
        }

        protected void autocreditOS()
        {
            int vouyear;

            if (hid_buyingno.Value == "")
            {
                hid_buyingno.Value = "0";

            }

            Double amt = 0.00;
            if (Session["StrTranType"] != null)
            {
                if (txt_booking.Text != "")
                {
                    dtinv = obj_da_BL.GetBuyingchgs4debitcredit(Convert.ToInt32(hid_buyingno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_booking.Text, Session["StrTranType"].ToString());
                }
            }

            //DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
            //DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
            DateTime dtdate = da_obj_logobj.GetDate();
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
                //DataAccess.AirImportExports.AIEJobInfo objaej = new DataAccess.AirImportExports.AIEJobInfo();
                dtd = objaej.GetAIagentid(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(txt_job.Text));

                CreditOS = true;



                refnodebitOs = da_obj_OSDNCN.InsproOSvouchershead(Convert.ToDateTime(dtdate), "OE", Convert.ToDouble(amount),
                                        Convert.ToInt32(txt_job.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value),
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
                        HIDMAWBLNO.Value = txt_bl.Text.ToUpper();
                    }



                    base1 = dtinv.Rows[i]["base"].ToString();
                    rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                    exrate = obj_da_Invoice.GetOSExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(da_obj_logobj.GetDate()), "C", Convert.ToInt32(Session["LoginDivisionId"]));
                    famount = checkbase(base1, Convert.ToDouble(rate), Convert.ToDouble(exrate)).ToString();
                    string osamount = Convert.ToDecimal(famount).ToString("#,0.00");
                    actual = actual + Convert.ToDouble(osamount);
                    fd=Convert.ToInt32(hid_fd.Value);
                    unit= Convert.ToInt32(hid_douvolume.Value);

                    DAdvise.InsOSVdetails(Convert.ToInt32(txt_job.Text), "OE", HIDMAWBLNO.Value.ToUpper(),
                      Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate),
                       base1, Convert.ToDouble(osamount), 6, Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, unit, Convert.ToInt32(hid_SupplyTo.Value),
                       "Y", Convert.ToInt32(hid_SupplyTo.Value), "N", refnodebitOs, Convert.ToInt32(vouyear));
                    //if (unit == 0)
                    //{
                    //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Amount is calculated as 0 ,Base Unit details not calculated properly,Kindly Update the charges once again in proforma screen..);", true);

                    //}

                    //DAdvise.InsDCAdviseForGstOSV(Convert.ToInt32(txt_job.Text), "OE", HIDMAWBLNO.Value.ToUpper(),
                    //    Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate),
                    //    base1, Convert.ToDouble(osamount), 6, Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, unit, Convert.ToInt32(hid_SupplyTo.Value),
                    //    "Y", Convert.ToInt32(hid_intagent.Value));

                }

                //DataAccess.AirImportExports.AIEBLDetails objae = new DataAccess.AirImportExports.AIEBLDetails();
                //refnodebitOs = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), "OE", Convert.ToDouble(amount),
                //                                  Convert.ToInt32(txt_job.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent),
                //                                  Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual,
                //                                  Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate,6);
                DataTable dttn = new DataTable();
                dttn = da_obj_OSDNCN.Getupdacdebitfcamt(refnodebitOs, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(txt_job.Text));
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
                da_obj_OSDNCN.Getupdacosdnproupdnew(refnodebitOs, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(txt_job.Text), fcamt1, "CreditAdvise");




            }
            else
            {
                CreditOS = false;
            }

        }

        protected void txt_orignalbl_TextChanged(object sender, EventArgs e)
        {
            if (txt_orignalbl.Text != "")
            {

                //if (System.Text.RegularExpressions.Regex.IsMatch(txt_orignalbl.Text, "  ^ [0-9]"))
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CreditExemptionList", "alertify.alert('Enter Number Only');", true);
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Enter Number Only');", true);
                //    txt_orignalbl.Focus();

                //    txt_orignalbl.Text = "";
                //}


                if (!System.Text.RegularExpressions.Regex.IsMatch("^[0-9]", txt_orignalbl.Text))
                    if (!Regex.IsMatch(txt_orignalbl.Text, @"(^([0-9]*|\d*\d{1}?\d*)$)"))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('Enter Number Only');", true);
                        txt_orignalbl.Text = "";
                        txt_orignalbl.Focus();
                        return;
                    }
            }
        }



        /*protected void InsFillFromBookingOnlyMinusFigureExports()
        {
            DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
            string strTranType = Session["StrTranType"].ToString();
            DataTable dt = new DataTable();
            DateTime dat;
            DataTable tempdt = new DataTable();
            dat = Logobj.GetDate();
            dt = INVOICEobj.GetChargeFromQuotationOnlyMinusFigure(txt_bl.Text, dat, Convert.ToInt32(Session["Loginbranchid"]));
            if (dt.Rows.Count > 0)
            {
                Refno1 = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Logobj.GetDate()), "FE", Convert.ToInt32(txt_job.Text),
                            Convert.ToInt32(hid_intcustomerid.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                            "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                            "Profoma Payment Advise", "", 0, Convert.ToInt32(hid_SupplyTo.Value));
                if (lbl_header.Text == "Our BL")
                {

                    Logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 2, 1, int.Parse(Session["LoginBranchid"].ToString()), "BL-" + txt_bl.Text.ToUpper() + "/Profoma Payment Advise-" + Refno1 + "/AutoPA");

                }
                else if (lbl_header.Text == "Direct Bill of Lading (Liner)")
                {

                    Logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 179, 1, int.Parse(Session["LoginBranchid"].ToString()), "BL-" + txt_bl.Text.ToUpper() + "/Profoma Payment Advise-" + Refno1 + "/AutoPA");

                }

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    //SMS AS Per Manoj instructions , bl charges and surrender charges base directly pass
                    /*if (dt.Rows[i]["chargeid"].ToString() == "1" || dt.Rows[i]["chargeid"].ToString() == "92")
                    {
                        base1 = "BL";
                    }
                    else
                    {
                        base1 = dt.Rows[i]["base"].ToString();
                    }
                    rate = Convert.ToDouble(dt.Rows[i]["rate"].ToString());
                    // exrate = obj_da_Invoice.GetExRate(dt.Rows[i]["curr"].ToString(), Convert.ToDateTime(Logobj.GetDate()), "R");
                    //   exrate = Convert.ToDouble(txtOutPut.Text);
                    if (dt.Rows[i]["curr"].ToString().ToUpper() == "INR")
                    {
                        exrate = 1;
                    }
                    else
                    {
                        exrate = Convert.ToDouble(txtOutPut.Text);
                    }

                    base1 = dtinv.Rows[i]["base"].ToString();
                    rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                    exrate = obj_da_Invoice.GetExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(Logobj.GetDate()), "R");
                    amount = checkbase(base1, rate, exrate);
                    ProINVobj.InsertProInvoiceDetails(Refno1, Convert.ToInt32(dt.Rows[i]["chargeid"]), dt.Rows[i]["curr"].ToString(), rate,
                        exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                        , "C", "FE", "Profoma Payment Advise", "Y", unit);
                    DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                    string chargename = "";
                    chargename = chargeobj.GetChargeName(Convert.ToInt32(dt.Rows[i]["chargeid"]));
                    if (lbl_header.Text == "Our BL")
                    {
                        Logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 2, 1, int.Parse(Session["LoginBranchid"].ToString()), "BL-" + txt_bl.Text.ToUpper() + "/Profoma Payment Advise-" + Refno + "/Chargename:" + chargename + "/Curr:" + dt.Rows[i]["curr"].ToString() + "/Rate:" + rate + "/Exrate:" + exrate + "/Base:" + base1 + "/Amount:" + amount + "/Charge_AutoPA");

                    }
                    else if (lbl_header.Text == "Direct Bill of Lading (Liner)")
                    {

                        Logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 179, 1, int.Parse(Session["LoginBranchid"].ToString()), "BL-" + txt_bl.Text.ToUpper() + "/Profoma Payment Advise-" + Refno + "/Chargename:" + chargename + "/Curr:" + dt.Rows[i]["curr"].ToString() + "/Rate:" + rate + "/Exrate:" + exrate + "/Base:" + base1 + "/Amount:" + amount + "/Charge_AutoPA");

                    }
                }
            }
        }
        */

        //Quatation and job check container size same or not
        public void ContSizeVerifyQuataionandjob()
        {
            Miscontsize = obj_da_BL.ContSizeverifyquataionandjob(txt_booking.Text, Convert.ToInt32(txt_job.Text), Convert.ToInt32(Session["LoginBranchId"]));
            if (Miscontsize != "0")
            {
                ContVerify = false;
            }
            else
            {
                ContVerify = true;
            }
        }
        protected void btn_job_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../ForwardExports/JobInfo.aspx?back=yes"+"&job="+txt_job.Text);
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
        }

        protected void btn_blrelease_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1014, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_bl.Text != "")
                    {
                        string feblno = txt_bl.Text;
                        Response.Redirect("../ShipmentDetails/BLRelease.aspx?BLReleaseNO=" + feblno + "&blba=yes" + "&ddl_HTS=" + ddl_HTS.SelectedValue);
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
        protected void Btnamendbl_Click(object sender, EventArgs e)
        {
            DataTable dtuser;
            if (Session["StrTranType"].ToString() == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(93, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_job.Text != "")
                    {
                        iframecost.Attributes["src"] = "../ForwardExports/AmendBL.aspx?jobno=" + txt_job.Text;
                        pop_up.Show();
                        this.popup_Grd1.Hide();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('BL # cannot be Empty!');", true);
                        txt_bl.Focus();
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            else if (Session["StrTranType"].ToString() == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(94, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_job.Text != "")
                    {
                        iframecost.Attributes["src"] = "../ForwardExports/AmendBL.aspx?jobno=" + txt_job.Text;
                        pop_up.Show();
                        this.popup_Grd1.Hide();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('BL # cannot be Empty!');", true);
                        txt_bl.Focus();
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            if (Session["StrTranType"].ToString() == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(96, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_job.Text != "")
                    {
                        iframecost.Attributes["src"] = "../ForwardExports/AmendBL.aspx?jobno=" + txt_job.Text;
                        pop_up.Show();
                        this.popup_Grd1.Hide();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('BL # cannot be Empty!');", true);
                        txt_bl.Focus();
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            if (Session["StrTranType"].ToString() == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(95, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_job.Text != "")
                    {
                        iframecost.Attributes["src"] = "../ForwardExports/AmendBL.aspx?jobno=" + txt_job.Text;
                        pop_up.Show();
                        this.popup_Grd1.Hide();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('BL # cannot be Empty!');", true);
                        txt_bl.Focus();
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
}