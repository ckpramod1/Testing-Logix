//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Data;
//using System.Web.UI.HtmlControls;
//using System.Web.Services;
//using System.Configuration;
//using System.Web.UI.WebControls.WebParts;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.html;
//using iTextSharp.text.html.simpleparser;
//using System.Web.UI.DataVisualization.Charting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Collections;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.DataVisualization.Charting;
using ClosedXML.Excel;
using System.Net;
using DataAccess.HR;
using logix.CRMNew;
using System.ComponentModel;
using System.Web.Services.Description;

namespace logix.ForwardExports
{
    public partial class BL_Print : System.Web.UI.Page
    {
        DataAccess.Accounts.Invoice Invobj = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.ProfomaInvoice ProINVobj = new DataAccess.Accounts.ProfomaInvoice();
        DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.ForwardingExports.BLDetailsWOJob obj_da_BLWojob = new DataAccess.ForwardingExports.BLDetailsWOJob();
        DataAccess.ForwardingExports.JobInfo obj_da_Job = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        string str_RptName = "", str_RptName1 = "", str_RptName2 = "";
        DataTable dtrecptchk = new DataTable();
        string str_sp = "", str_sp1 = "", str_sp2 = "";
        string str_sf = "", str_sf1 = "", str_sf2 = "";
        string str_Script = ""; string str_Script1 = "", str_Script2 = "";
        DataAccess.NVOCC_Imports.BLDetails objbl = new DataAccess.NVOCC_Imports.BLDetails();
        DataAccess.ForwardingImports.JobInfo da_obj_FIJobobj = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.ForwardingExports.BLPrinting obj_da_FEBL = new DataAccess.ForwardingExports.BLPrinting();
        DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
        DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingExports.Confirmation obj_da_confirm = new DataAccess.ForwardingExports.Confirmation();
        DataAccess.ForwardingExports.BLPrinting obj_da_BLPrint = new DataAccess.ForwardingExports.BLPrinting();
        DataAccess.Corporate obj_da_Corporate = new DataAccess.Corporate();
       
        DataAccess.ForwardingImports.BLDetails obj_da_FIBL = new DataAccess.ForwardingImports.BLDetails();
       
        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();

        DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.CostingDetails objcos = new DataAccess.CostingDetails();

        DataAccess.CreditException Crexobj = new DataAccess.CreditException();
        DataAccess.Accounts.Approval appobj = new DataAccess.Accounts.Approval();
        DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();

        DataTable dtu = new DataTable();
        int quotno;
        string sendqry;
        string Filename;
        string ftpFullPath;
        string str_subject;
        string mailid;
        string ccmail;
        string username = "";
        string password = "";
        string ip = "";
        string dbname = "";
        double rate, exrate, amount, unit, cbmAmt, mtAmt;
        Double douvolume, volume, wt;
        string str_FornName = "", str_Uiid = "", base1, strvolume, strntweight, strchgweight, strgrosswght, sizecount;
        string strtrantype;
        protected string DBCS;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);



            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Invobj.GetDataBase(Ccode);
                ProINVobj.GetDataBase(Ccode);
                obj_da_BL.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                obj_da_BLWojob.GetDataBase(Ccode);
                obj_da_Job.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                obj_da_Invoice.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                objbl.GetDataBase(Ccode);

                da_obj_FIJobobj.GetDataBase(Ccode);
                obj_da_FEBL.GetDataBase(Ccode);
                obj_MasterPort.GetDataBase(Ccode);
                obj_da_jobinfo.GetDataBase(Ccode);
                obj_da_confirm.GetDataBase(Ccode);
                obj_da_BLPrint.GetDataBase(Ccode);
                obj_da_Corporate.GetDataBase(Ccode);
                obj_da_FIBL.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);
                FIBLobj.GetDataBase(Ccode);
                objcos.GetDataBase(Ccode);
                Crexobj.GetDataBase(Ccode);
                appobj.GetDataBase(Ccode);
                chargeobj.GetDataBase(Ccode);
              
            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/'_top');", true);
            }

            try
            {
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_excel);
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Btn_cancel);
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                string str_FornName = "", str_Uiid = "";
                if (Session["blno"] != null)
                {
                    txt_bl.Text = Session["blno"].ToString();
                    // Session["StrTranType"] = Session["StrTranType"];
                    lnk_back.Visible = false;
                    btn_DO.Visible = false;btn_DO_id.Visible = false;
                    btn_DOsale.Visible = false;dosale_id.Visible = false;
                    Fn_Getvalue();
                    Session["blno"] = null;
                    Btn_cancel.Enabled = false;
                    Headerlable.InnerText = lbl_header.Text;
                    txt_doday.Visible = false;
                    //txt_cfs.Visible = false;
                    btn_new_pending.Visible = false;btn_new_pending_id.Visible = false;
                    return;
                }

                if (Request.QueryString.ToString().Contains("type"))
                {
                    str_FornName = Request.QueryString["type"].ToString();
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    //Utility.Fn_CheckUserRights(str_Uiid, null, Btn_Print, null);
                }
                if (Request.QueryString.ToString().Contains("trantype"))
                {
                    string type = Request.QueryString["trantype"].ToString();
                    str_FornName = "BLPrint";
                    lbl_header.Text = str_FornName;
                    Session["StrTranType"] = type;
                    Session["blno"] = null;
                }

                if (!IsPostBack)
                {

                    if (Request.QueryString.ToString().Contains("BLNumber"))
                    {
                        //lblblPrint.Visible = false;
                        //crumbslbl.Attributes["class"] = "crumbslbl";
                        txt_bl.Text = Request.QueryString["BLNumber"].ToString();
                        //lbl_header.Text = str_FornName;
                        txt_bl_TextChanged(sender, e);
                        return;

                    }

                    if (Request.QueryString.ToString().Contains("DOissue"))
                    {

                        txt_bl.Text = Request.QueryString["bookingno"].ToString();
                        str_FornName = Request.QueryString["DOissue"].ToString();
                        lbl_header.Text = str_FornName;
                        txt_bl_TextChanged(sender, e);
                        return;
                    }
                    Grd_Invoice.Visible = false;
                    Grd_DN.Visible = false;
                    Grd_receipt.Visible = false;
                    Grd_DN.DataSource = new DataTable();
                    Grd_DN.DataBind();

                    // Grd_freightdetail.DataSource = new DataTable();
                    //   Grd_freightdetail.DataBind();

                    Grd_receipt.DataSource = new DataTable();
                    Grd_receipt.DataBind();

                    Grd_Invoice.DataSource = new DataTable();
                    Grd_Invoice.DataBind();
                    if (Request.QueryString.ToString().Contains("DODetails"))
                    {
                        headerlable1.InnerText = "Operating Accounts";
                        if (Request.QueryString["trantype"].ToString() == "FE")
                        {
                            headerlable2.InnerText = "Utility";
                        }
                        else if (Request.QueryString["trantype"].ToString() == "FI")
                        {
                            headerlable2.InnerText = "Utility";
                        }

                    }
                    if (str_FornName == "D.O. Issue")
                    {
                        str_FornName = "DODetails";
                        Session["blno"] = null;
                    }

                    if (Session["blnosales"] != null)
                    {
                        txt_bl.Text = Session["blnosales"].ToString();
                        // Session["StrTranType"] = Session["StrTranType"];
                        lnk_back.Visible = true;
                        btn_DO.Visible = false;btn_DO_id.Visible = false;
                        btn_DOsale.Visible = false;dosale_id.Visible = false;
                        Fn_Getvaluesale();
                        Session["blnosales"] = null;
                        Btn_cancel.Enabled = false;
                        Headerlable.InnerText = lbl_header.Text;
                        txt_doday.Visible = false;
                        txt_cfs.Visible = false;
                        lblCFS.Visible = false;
                        btn_new_pending.Visible = false;btn_new_pending_id.Visible = false;
                        return;
                    }
                    else if (Session["blnofi"] != null)
                    {
                        txt_bl.Text = Session["blnofi"].ToString();
                        // Session["StrTranType"] = Session["StrTranType"];
                        lbl_header.Text = "Freight Details";
                        btn_DO.Visible = false;btn_DO_id.Visible = false;
                        btn_DOsale.Visible = false;dosale_id.Visible = false;
                        Fn_Getvaluefi();
                        lnk_bl.Visible = false;
                        lnk_blfreight.Visible = false;
                        lnk_back.Visible = true;
                        lnk_blvoucher_Click(sender, e);
                        //lnk_blvoucher.Attributes.Add("class", "lnk_blnew");
                        div_lnk_blvoucher.Attributes["class"] = "lnk_blnew";
                        Session["blnofi"] = null;
                        Session["blnofife"] = txt_bl.Text;
                        Headerlable.InnerText = lbl_header.Text;
                        Btn_cancel.Enabled = false;
                        return;
                    }

                    if (Request.QueryString.ToString().Contains("BLNO"))
                    {
                        txt_bl.Text = Request.QueryString["BLNO"].ToString();
                        Fn_Getvalue();
                        lnk_bl.Text = "";
                        lnk_blfreight.Text = "";
                        lnk_bl.Visible = false;
                        lnk_blfreight.Visible = false;
                        div_BLDetails.Visible = false;
                        div_BLfreigthdetail.Visible = false;
                        btn_DO.Visible = true;btn_DO_id.Visible = true;
                        btn_DOsale.Visible = true;dosale_id.Visible = true;
                    }
                    if (str_FornName == "Booking")
                    {
                        lbl_header.Text = "Booking #";
                        txt_bl.Enabled = false;
                        txt_book.ReadOnly = false;
                        txt_book.Focus();
                        txt_cfs.Visible = false;
                        lblCFS.Visible = false;
                        //lbl_cfs.Text = "";
                        div_cha.Attributes["class"] = "div_cha_visible";
                        //doday.Visible = false;
                        dodaytxt.Visible = false;
                        btn_DOsale.Visible = false;dosale_id.Visible = false;
                        btn_DO.Visible = false;btn_DO_id.Visible = false;
                        Btn_Print.Visible = false;Btn_Print_id.Visible = false;
                        btn_DO.Visible = true;btn_DO_id.Visible = true;
                        btn_DOsale.Visible = true;dosale_id.Visible = true;
                    }
                    else if (str_FornName == "DODetails")
                    {
                        lbl_header.Text = "DODetails";
                        txt_bl.Enabled = true;
                        txt_book.ReadOnly = true;
                        div_cha.Attributes["class"] = "div_cha_visible";
                        //doday.Visible = false;
                        dodaytxt.Visible = false;
                        btn_DOsale.Visible = true;dosale_id.Visible = true;
                        btn_DO.Visible = true;btn_DO_id.Visible = true;
                        Btn_Print.Visible = true; Btn_Print_id.Visible = true;
                        btn_DO.Visible = true;btn_DO_id.Visible = true;
                        btn_DOsale.Visible = true;dosale_id.Visible = true;

                        //  Session["blno"] = txt_bl.Text;
                        lnk_back.Visible = false;
                        txt_cfs.Visible = false;
                        lblCFS.Visible = false;
                    }
                    else if (str_FornName == "D.O. Issue")
                    {
                        lnk_back.Visible = false;
                        Btn_Print.Enabled = false;
                        Btn_Print.ForeColor = System.Drawing.Color.Gray;

                        // Session["blno"] = txt_bl.Text;
                        lbl_header.Text = "DODetails";

                    }
                    else if (str_FornName == "BLPrint")
                    {

                        // Session["StrTranType"] = Session["StrTranType"];
                        lnk_back.Visible = true;
                        btn_DO.Visible = false;btn_DO_id.Visible = false;
                        btn_DOsale.Visible = false;dosale_id.Visible = false;

                        //  Session["blno"] = null;

                        Headerlable.InnerText = lbl_header.Text;
                        lnk_back.Visible = false;
                        txt_doday.Visible = false;
                        txt_cfs.Visible = false;
                        lblCFS.Visible = false;
                        btn_new_pending.Visible = false;btn_new_pending_id.Visible = false;
                    }
                    else
                    {

                        //btn_DO.Visible = false;btn_DO_id.Visible = false;
                        //btn_DOsale.Visible = false;dosale_id.Visible = false;
                        //div_cha.Attributes["class"] = "div_cha_visible";
                        //doday.Visible = false;
                        dodaytxt.Visible = false;
                        txt_cfs.Visible = false;
                        lblCFS.Visible = false;
                        btn_new_pending.Visible = false;btn_new_pending_id.Visible = false;
                        // lnk_back.Visible = false;
                        //btn_DOsale.Visible = false;dosale_id.Visible = false;
                        //btn_DO.Visible = false;btn_DO_id.Visible = false;
                        //Btn_Print.Visible = true;

                        //lbl_cfs.Text = "";
                    }
                    if (Request.QueryString.ToString().Contains("BLReleaseNO"))
                    {
                        lbl_header.Text = "DODetails";
                        txt_bl.Text = Request.QueryString["BLReleaseNO"].ToString();
                        txt_bl_TextChanged(sender, e);
                       
                    }
                }
                //Session["blno"] = "";
                Headerlable.InnerText = lbl_header.Text;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            // Headerlable.InnerText=l
        }

        protected void txt_bl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_bl.Text.Trim().Length > 0)
                {
                    chk_container.Items.Clear();
                    Fn_Clear();
                    Btn_cancel.Text = "Cancel";
                    Session["blno"] = null;
                    Fn_Getvalue();

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            Btn_cancel.Text = "Cancel";
        }

        protected void lnk_bl_Click(object sender, EventArgs e)
        {
            try
            {
                div_BLDetails.Visible = true;
                div_BLvoucherdetail.Visible = false;
                div_BLfreigthdetail.Visible = false;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_blvoucher_Click(object sender, EventArgs e)
        {
            try
            {
                div_BLDetails.Visible = false;
                div_BLvoucherdetail.Visible = true;
                div_BLfreigthdetail.Visible = false;

                Grd_Invoice.Visible = true;
                Grd_DN.Visible = true;
                Grd_receipt.Visible = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_blfreight_Click(object sender, EventArgs e)
        {
            try
            {
                div_BLDetails.Visible = false;
                div_BLvoucherdetail.Visible = false;
                div_BLfreigthdetail.Visible = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void Fn_Getvalue()
        {

            try
            {

                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                chk_container.Items.Clear();
                string blno;
                string str_BL = "";
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
               // DataAccess.ForwardingExports.BLPrinting obj_da_FEBL = new DataAccess.ForwardingExports.BLPrinting();
                string Ccode = Convert.ToString(Session["Ccode"]);
                obj_da_BL.GetDataBase(Ccode);
                if (txt_bl.Text != "")
                {
                    blno = txt_bl.Text;
                }
                else
                {
                    blno = Session["blno"].ToString();
                }

                obj_dt = obj_da_BL.ShowBLDetails(blno, int_bid, int_divisionid);
                if (obj_dt.Rows.Count > 0)
                {
                    str_BL = obj_dt.Rows[0]["splitbl"].ToString();
                    hid_split.Value = str_BL;
                }
                /*else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alertify.alert('Select Correct Bl #')", true);
                    txt_bl.Focus();
                    txt_bl.Text = "";
                    return;
                }*/
                if (str_BL.Trim().Length > 0)
                {
                    //lbl_cfs.Text = "Forward BL";
                    txt_cfs.Visible = true;
                    lblCFS.Visible = true;
                    btn_FBL.Visible = true;
                    txt_cfs.Enabled = true;
                    txt_cha.ReadOnly = false;
                    txt_cfs.Text = obj_dt.Rows[0]["splitbl"].ToString();
                    txt_cfs.Attributes.Add("Forward BL", "placeholder");
                    txt_cfs.ToolTip = "Forward BL";
                    Fn_GetDetailsSplit();
                    hid_BL.Value = "false";
                    obj_dttemp = obj_da_FEBL.GetBLFreightDetails(txt_bl.Text, Session["StrTranType"].ToString(), int_bid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        Grd_freightdetail.DataSource = obj_dttemp;
                        Grd_freightdetail.DataBind();
                    }
                    return;
                }
                else
                {
                    Fn_GetDetails();
                    obj_dttemp = obj_da_FEBL.getMothervslDtls(hid_BookingNo.Value.ToString(), int_bid, int_divisionid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        txt_mvessel.Text = obj_dttemp.Rows[0]["vessel"].ToString();
                        txt_destuff.Text = obj_dttemp.Rows[0]["mvoyage"].ToString();
                        txt_mpol.Text = obj_dttemp.Rows[0]["pol"].ToString();
                        txt_mpod.Text = obj_dttemp.Rows[0]["pod"].ToString();
                        txt_meta.Text = obj_dttemp.Rows[0]["eta"].ToString();
                        txt_metd.Text = obj_dttemp.Rows[0]["etd"].ToString();
                        DataTable dt;
                       // DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                        if (txt_mpol.Text != "0" && txt_mpol.Text!="")
                        {
                            dt = obj_MasterPort.SelPortName4typepadimg(txt_mpol.Text.ToUpper(), Session["StrTranType"].ToString());
                            mpolflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                        }
                        if (txt_mpod.Text != "0" && txt_mpod.Text != "")
                        {
                            dt = obj_MasterPort.SelPortName4typepadimg(txt_mpod.Text.ToUpper(), Session["StrTranType"].ToString());
                            mpodflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                        }
                    }
                    obj_dttemp = obj_da_FEBL.GetBLFreightDetails(txt_bl.Text, Session["StrTranType"].ToString(), int_bid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        Grd_freightdetail.DataSource = obj_dttemp;
                        Grd_freightdetail.DataBind();
                    }
                    return;
                } //Session["blno"] = null;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Fn_Getvaluefi()
        {
            try
            {

                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                chk_container.Items.Clear();
                string str_BL = "";
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
                //DataAccess.ForwardingExports.BLPrinting obj_da_FEBL = new DataAccess.ForwardingExports.BLPrinting();
                string Ccode = Convert.ToString(Session["Ccode"]);
                obj_da_BL.GetDataBase(Ccode);
                string blno = Session["blnofi"].ToString();
                obj_dt = obj_da_BL.ShowBLDetails(blno, int_bid, int_divisionid);
                if (obj_dt.Rows.Count > 0)
                {
                    str_BL = obj_dt.Rows[0]["splitbl"].ToString();
                    hid_split.Value = str_BL;
                }
                if (str_BL.Trim().Length > 0)
                {
                    //lbl_cfs.Text = "Forward BL";
                    txt_cfs.Visible = true;
                    lblCFS.Visible = true;
                    btn_FBL.Visible = true;
                    txt_cfs.Text = obj_dt.Rows[0]["splitbl"].ToString();
                    txt_cfs.Attributes.Add("Forward BL", "Placeholder");
                    txt_cfs.ToolTip = "Forward BL";
                    Fn_GetDetailsSplit();
                    hid_BL.Value = "false";
                    obj_dttemp = obj_da_FEBL.GetBLFreightDetails(txt_bl.Text, Session["StrTranType"].ToString(), int_bid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        Grd_freightdetail.DataSource = obj_dttemp;
                        Grd_freightdetail.DataBind();
                    }
                }
                else
                {
                    Fn_GetDetails();
                    obj_dttemp = obj_da_FEBL.getMothervslDtls(hid_BookingNo.Value.ToString(), int_bid, int_divisionid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        txt_mvessel.Text = obj_dttemp.Rows[0]["vessel"].ToString();
                        txt_destuff.Text = obj_dttemp.Rows[0]["mvoyage"].ToString();
                        txt_mpol.Text = obj_dttemp.Rows[0]["pol"].ToString();
                        txt_mpod.Text = obj_dttemp.Rows[0]["pod"].ToString();
                        txt_meta.Text = obj_dttemp.Rows[0]["eta"].ToString();
                        txt_metd.Text = obj_dttemp.Rows[0]["etd"].ToString();
                    }
                    obj_dttemp = obj_da_FEBL.GetBLFreightDetails(txt_bl.Text, Session["StrTranType"].ToString(), int_bid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        Grd_freightdetail.DataSource = obj_dttemp;
                        Grd_freightdetail.DataBind();
                    }
                } //Session["blno"] = null;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Fn_Getvaluesale()
        {
            try
            {
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                chk_container.Items.Clear();
                string str_BL = "";
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
               // DataAccess.ForwardingExports.BLPrinting obj_da_FEBL = new DataAccess.ForwardingExports.BLPrinting();
                string Ccode = Convert.ToString(Session["Ccode"]);
                obj_da_BL.GetDataBase(Ccode);
                string blno = Session["blnosales"].ToString();
                obj_dt = obj_da_BL.ShowBLDetails(blno, int_bid, int_divisionid);
                if (obj_dt.Rows.Count > 0)
                {
                    str_BL = obj_dt.Rows[0]["splitbl"].ToString();
                    hid_split.Value = str_BL;
                }
                if (str_BL.Trim().Length > 0)
                {
                    //lbl_cfs.Text = "Forward BL";
                    txt_cfs.Visible = true;
                    lblCFS.Visible = true;
                    btn_FBL.Visible = true;
                    txt_cfs.Text = obj_dt.Rows[0]["splitbl"].ToString();
                    txt_cfs.Attributes.Add("Forward BL", "Placeholder");
                    txt_cfs.ToolTip = "Forward BL";
                    Fn_GetDetailsSplit();
                    hid_BL.Value = "false";
                    obj_dttemp = obj_da_FEBL.GetBLFreightDetails(txt_bl.Text, Session["StrTranType"].ToString(), int_bid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        Grd_freightdetail.DataSource = obj_dttemp;
                        Grd_freightdetail.DataBind();
                    }
                }
                else
                {
                    Fn_GetDetails();
                    obj_dttemp = obj_da_FEBL.getMothervslDtls(hid_BookingNo.Value.ToString(), int_bid, int_divisionid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        txt_mvessel.Text = obj_dttemp.Rows[0]["vessel"].ToString();
                        txt_destuff.Text = obj_dttemp.Rows[0]["mvoyage"].ToString();
                        txt_mpol.Text = obj_dttemp.Rows[0]["pol"].ToString();
                        txt_mpod.Text = obj_dttemp.Rows[0]["pod"].ToString();
                        txt_meta.Text = obj_dttemp.Rows[0]["eta"].ToString();
                        txt_metd.Text = obj_dttemp.Rows[0]["etd"].ToString();
                    }
                    obj_dttemp = obj_da_FEBL.GetBLFreightDetails(txt_bl.Text, Session["StrTranType"].ToString(), int_bid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        Grd_freightdetail.DataSource = obj_dttemp;
                        Grd_freightdetail.DataBind();
                    }
                } //Session["blno"] = null;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Fn_GetDetailsSplit()
        {
            try
            {
                DataTable dtnew = new DataTable();
                string agentid = "";
                string yearnew = "";
                int jobno1 = 0;
                int txtagentid = 0;
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                string str_Nomination = "", str_CustomerName = "", str_CustomerNameagent = "";
                chk_container.Items.Clear();
                int cnf = 0;

                DataTable obj_dt = new DataTable();
                DataAccess.ForwardingExports.BLPrinting obj_da_BL = new DataAccess.ForwardingExports.BLPrinting();
               DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                DataAccess.ForwardingImports.BLDetails obj_da_FIBL = new DataAccess.ForwardingImports.BLDetails();
                DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                string Ccode = Convert.ToString(Session["Ccode"]);
                obj_da_BL.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);
                obj_da_FEBL.GetDataBase(Ccode);
                obj_da_FIBL.GetDataBase(Ccode);
                if (Logobj.GetDate().Month < 4)
                {
                    yearnew = (Logobj.GetDate().Year - 1).ToString();
                }
                else
                {
                    yearnew = Logobj.GetDate().Year.ToString();
                }
                if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                {
                    obj_dt = obj_da_BL.GetBLPrintingDt(txt_bl.Text, Session["StrTranType"].ToString(), int_bid, int_divisionid);
                }
                if (obj_dt.Rows.Count > 0)
                {
                    txt_date.Text = obj_dt.Rows[0]["bldate"].ToString();
                    txt_issued.Text = obj_dt.Rows[0]["issuedat"].ToString();
                    txt_shipper.Text = obj_dt.Rows[0]["shipper"].ToString();
                    txt_consignee.Text = obj_dt.Rows[0]["consignee"].ToString();
                    hid_consign.Value = obj_dt.Rows[0]["consigneeid"].ToString();
                    txt_notify.Text = obj_dt.Rows[0]["notify"].ToString();
                    txt_remark.Text = obj_dt.Rows[0]["remarks"].ToString();
                    if (!string.IsNullOrEmpty(obj_dt.Rows[0].ItemArray[5].ToString()))
                    {
                        str_CustomerName = obj_da_Customer.GetCustomername(int.Parse(obj_dt.Rows[0].ItemArray[5].ToString()));
                        int cfs = Convert.ToInt32(obj_dt.Rows[0].ItemArray[5]);

                    }
                    if (Session["StrTranType"].ToString() != "FE")
                    {
                        txt_mvessel.Text = obj_dt.Rows[0]["mvessel"].ToString();
                        txt_destuff.Text = obj_dt.Rows[0]["mvoy"].ToString() + " & " + str_CustomerName;
                        if (obj_dt.Rows[0]["blsurrendered"].ToString() == "Y")
                        {
                            txt_hbl.Text = "SURRENDERED";
                        }
                        else
                        {
                            txt_hbl.Text = "NOT SURRENDERED";
                        }

                        if (hid_BL.Value.ToString() == "false")
                        {
                            txt_job.Text = obj_dt.Rows[0]["jobno"].ToString();
                            jobno1 = Convert.ToInt32(obj_dt.Rows[0]["jobno1"].ToString());
                            txt_line.Text = obj_dt.Rows[0]["linenumber"].ToString();
                            hid_job.Value = obj_dt.Rows[0]["intjobno"].ToString();
                        }
                    }
                    else
                    {
                        if (obj_dt.Rows[0]["surrendered"].ToString() == "S")
                        {
                            txt_hbl.Text = "SURRENDERED";
                        }
                        else if (obj_dt.Rows[0]["surrendered"].ToString() == "B")
                        {
                            txt_hbl.Text = "SEAWAY BILL";
                        }
                        else
                        {
                            txt_hbl.Text = "RELEASE";
                        }

                        if (obj_dt.Rows[0]["mblstatus"].ToString() == "S")
                        {
                            txt_mblstatus.Text = "SURRENDERED";
                        }
                        else if (obj_dt.Rows[0]["surrendered"].ToString() == "B")
                        {
                            txt_mblstatus.Text = "SEAWAY BILL";
                        }
                        else
                        {
                            txt_mblstatus.Text = "RELEASE";
                        }

                        txt_freight.Text = obj_dt.Rows[0]["surrendered"].ToString();
                        txt_job.Text = obj_dt.Rows[0]["jobno"].ToString();
                        jobno1 = Convert.ToInt32(obj_dt.Rows[0]["jobno1"].ToString());
                        hid_job.Value = obj_dt.Rows[0]["intjobno"].ToString();
                    }

                    DataTable obj_dttemp = new DataTable();
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        txt_cha.Text = str_CustomerName;
                        Btn_Print.Text = "Update";
                        //     DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                        obj_dttemp = obj_da_jobinfo.GetContainerDetails(int.Parse(hid_job.Value.ToString()), txt_bl.Text, int_bid, int_divisionid);
                        for (int i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                        {
                            chk_container.Items.Add(obj_dttemp.Rows[i][0].ToString() + "/" + obj_dttemp.Rows[i][1].ToString() + "/" + obj_dttemp.Rows[i][2].ToString());
                            if (i == 0)
                            {
                                hid_contno.Value = obj_dttemp.Rows[i][0].ToString();
                            }
                            else
                            {
                                hid_contno.Value = hid_contno.Value.ToString() + "/" + obj_dttemp.Rows[i][0].ToString();
                            }
                        }
                    }
                    else
                    {

                        obj_dttemp = obj_da_FIBL.GetContainerDetail(int.Parse(hid_job.Value.ToString()), txt_bl.Text, int_bid, int_divisionid);
                        for (int i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                        {
                            chk_container.Items.Add(obj_dttemp.Rows[i][0].ToString() + "/" + obj_dttemp.Rows[i][1].ToString() + "/" + obj_dttemp.Rows[i][2].ToString());
                            if (i == 0)
                            {
                                hid_contno.Value = obj_dttemp.Rows[i][0].ToString();
                            }
                            else
                            {
                                hid_contno.Value = hid_contno.Value.ToString() + "/" + obj_dttemp.Rows[i][0].ToString();
                            }
                        }
                    }
                    if (lbl_header.Text == "DODetails")
                    {

                        //lbl_cfs.Enabled = true;

                        txt_cfs.Enabled = true;
                        txt_cha.ReadOnly = false;
                        txt_cfs.Attributes.Add("Forward BL", "placeholder");
                        txt_cfs.ToolTip = "Forward BL";
                        //txt_cfs.Text = str_CustomerName;

                        //txt_cha.Text = obj_da_Customer.GetCustomername(int.Parse(obj_dt.Rows[0].ItemArray[5].ToString()));
                        //cnf = Convert.ToInt32(obj_dt.Rows[0].ItemArray[5]);
                        if (obj_dt.Rows[0].ItemArray[27].ToString() == "")
                        {
                            txt_cha.Text = "";
                        }
                        else
                        {
                            txt_cha.ReadOnly = false;
                            cnf = Convert.ToInt32(obj_dt.Rows[0].ItemArray[27].ToString());
                            txt_cha.Text = (obj_da_Customer.GetCustomername(cnf));
                            hid_cha.Value = cnf.ToString();
                        }
                        //if (str_CustomerName.Trim().Length > 0)
                        //{
                        //    txt_cha.ReadOnly = false;
                        //}

                        //DataTable dt = new DataTable();
                        //DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
                        //dt = Appobj.checkblstatus(txt_bl.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        //if (dt.Rows.Count > 0)
                        //{
                        //    if (dt.Rows[0]["blstatus"].ToString() == "R")
                        //    {
                        //        Btn_Print.Text = "Update";
                        //        Btn_Print.Enabled = true;
                        //    }
                        //    else if (dt.Rows[0]["blstatus"].ToString() == "H")
                        //    {
                        //        Btn_Print.Text = "Update";
                        //        Btn_Print.Enabled = false;
                        //    }
                        //}
                        Btn_Print.Text = "Update";
                    }

                    else
                    {
                        txt_cha.Visible = true;
                        txt_cha.Enabled = true;
                        if (obj_dt.Rows[0].ItemArray[27].ToString() == "")
                        {
                            txt_cha.Text = "";
                        }
                        else
                        {
                            txt_cha.ReadOnly = false;
                            cnf = Convert.ToInt32(obj_dt.Rows[0].ItemArray[27].ToString());
                            txt_cha.Text = (obj_da_Customer.GetCustomername(cnf));
                            hid_cha.Value = cnf.ToString();
                        }
                        //txt_cha.Text = (obj_da_Customer.GetCustomername(cnf));
                        Btn_Print.Text = "Print";
                        txt_cha.ReadOnly = true;
                    }

                    txt_agent.Text = obj_dt.Rows[0]["agent"].ToString();

                    txtagentid = Convert.ToInt32(obj_dt.Rows[0]["jobagent"].ToString());
                    str_CustomerNameagent = obj_da_Customer.GetCustomername(txtagentid);

                    txt_mlo.Text = obj_dt.Rows[0]["mlo"].ToString();
                    txt_POR.Text = obj_dt.Rows[0]["por"].ToString();
                    txt_POL.Text = obj_dt.Rows[0]["pol"].ToString();
                    txt_POD.Text = obj_dt.Rows[0]["pod"].ToString();
                    txt_FD.Text = obj_dt.Rows[0]["fd"].ToString();
                    txt_mark.Text = obj_dt.Rows[0]["marks"].ToString();
                    txt_cargo.Text = obj_dt.Rows[0]["descn"].ToString();
                    txt_kgs.Text = obj_dt.Rows[0]["ntweight"].ToString();
                    txt_volume.Text = obj_dt.Rows[0]["cbm"].ToString();
                    txt_packages.Text = obj_dt.Rows[0]["noofpkgs"].ToString() + " " + obj_dt.Rows[0]["package"].ToString();
                    txt_vessel.Text = obj_dt.Rows[0]["fvessel"].ToString();
                    txt_voyage.Text = obj_dt.Rows[0]["fvoy"].ToString();
                    txt_fpol.Text = obj_dt.Rows[0]["fpol"].ToString();
                    txt_fpod.Text = obj_dt.Rows[0]["fpod"].ToString();
                    txt_feta.Text = obj_dt.Rows[0]["feta"].ToString();
                    txt_fetd.Text = obj_dt.Rows[0]["fetd"].ToString();
                    txt_freight.Text = obj_dt.Rows[0]["freight"].ToString();
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        txt_mbl.Text = obj_dt.Rows[0]["mblno"].ToString();
                    }
                    else
                    {
                        txt_mbl.Text = obj_dt.Rows[0]["mblno"].ToString() + " & " + obj_dt.Rows[0]["mbldateweb"].ToString();
                    }
                    txt_jobtype.Text = obj_dt.Rows[0]["type"].ToString();
                    txt_dodate.Text = obj_dt.Rows[0]["doissuedon"].ToString();
                    txt_remark.Text = obj_dt.Rows[0]["remarks"].ToString();
                    str_Nomination = obj_dt.Rows[0]["nomination"].ToString();
                    hid_nomination.Value = obj_dt.Rows[0]["nomination"].ToString();
                    if (Session["StrTranType"].ToString() != "FE")
                    {

                    }
                    DataTable dd = new DataTable();

                    dd = obj_da_BL.getsp_salespersonget(txt_bl.Text);
                    if (dd.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dd.Rows[0]["empname"].ToString()))
                        {
                            txt_marketed.Text = dd.Rows[0]["empname"].ToString();
                        }
                        if (!string.IsNullOrEmpty(dd.Rows[0]["shiprefno"].ToString()))
                        {
                            txt_book.Text = dd.Rows[0]["shiprefno"].ToString();
                        }
                        if (!string.IsNullOrEmpty(dd.Rows[0]["quotno"].ToString()))
                        {
                            txt_Quotation.Text = dd.Rows[0]["quotno"].ToString();
                        }

                    }

                    if (txt_Quotation.Text != "")
                    {
                        dtu = objbl.getcreditdaygroupname(Convert.ToInt32(txt_Quotation.Text), int_bid);
                        if (dtu.Rows.Count > 0)
                        {
                            txt_creditgroupcus.Text = dtu.Rows[0]["groupname"].ToString() + "/" + dtu.Rows[0]["creditdays"].ToString() + "/" + dtu.Rows[0]["creditamt"].ToString();
                        }
                    }

                   // DataAccess.ForwardingExports.Confirmation obj_da_confirm = new DataAccess.ForwardingExports.Confirmation();
                    obj_dttemp = obj_da_confirm.GetConfirmDetails(txt_bl.Text, "C", int_bid, int_divisionid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        txt_mvessel.Text = obj_dttemp.Rows[0][1].ToString();
                        txt_destuff.Text = obj_dttemp.Rows[0][4].ToString();
                    }
                    else
                    {
                        obj_dttemp = obj_da_confirm.GetConfirmDetails(txt_bl.Text, "T", int_bid, int_divisionid);
                        if (obj_dttemp.Rows.Count > 0)
                        {
                            txt_mvessel.Text = obj_dttemp.Rows[0][1].ToString();
                            txt_destuff.Text = obj_dttemp.Rows[0][4].ToString();
                        }
                    }

                    if (lbl_header.Text == "DODetails" && Session["StrTranType"].ToString() == "FI")
                    {
                        int int_DoDay = 0;
                        int_DoDay = obj_da_FIBL.GetPendingDODays(txt_bl.Text, int_bid, int_divisionid);
                        if (int_DoDay > 0)
                        {
                            btn_DOsale.Visible = true;dosale_id.Visible = true;
                            btn_DO.Visible = true;btn_DO_id.Visible = true;
                            div_cha.Attributes["class"] = "div_cha";
                            // div_cfstxt.Attributes["class"] = "div_cfs";
                            //doday.Visible = false;
                            dodaytxt.Visible = true;
                            txt_doday.Text = int_DoDay.ToString();
                        }
                        else
                        {
                            btn_DOsale.Visible = false;dosale_id.Visible = false;
                            btn_DO.Visible = false;btn_DO_id.Visible = false;
                            div_cha.Attributes["class"] = "div_cha_visible";
                            //doday.Visible = false;
                            dodaytxt.Visible = false;
                        }

                    }
                }
                else
                {
                    Fn_Clear();
                }
                // txt_bl.Text = hid_split.Value;
                // Session["blno"] = txt_bl.Text;

                obj_dt = obj_da_BL.GetBLPrintInvDt(txt_bl.Text, Session["StrTranType"].ToString(), int_bid);
                if (obj_dt.Rows.Count > 0)
                {
                    Grd_Invoice.DataSource = obj_dt;
                    Grd_Invoice.DataBind();
                }
                obj_dt = obj_da_BL.GetBLPrintDNDt(txt_bl.Text, Session["StrTranType"].ToString(), int_bid);
                if (obj_dt.Rows.Count > 0)
                {
                    Grd_DN.DataSource = obj_dt;
                    Grd_DN.DataBind();
                }
                string str_booking = "";
                int int_customeridDO = 0;
                str_booking = obj_da_FIBL.GetBookinkNo(txt_cfs.Text, int_bid, int_divisionid);
                hid_BookingNo.Value = str_booking;
                obj_dt = obj_da_FEBL.GetBookingDt(str_booking, int_bid, int_divisionid);
                if (obj_dt.Rows.Count > 0)
                {
                    int_customeridDO = int.Parse(obj_dt.Rows[0]["customerid"].ToString());
                    hid_customer.Value = obj_dt.Rows[0]["shipper"].ToString();
                }

                 // DataAccess.ForwardingExports.BLPrinting obj_da_BLPrint = new DataAccess.ForwardingExports.BLPrinting();
                obj_dt = obj_da_BLPrint.GetBLPrintRcptDt(txt_bl.Text, int_bid);
                if (obj_dt.Rows.Count > 0)
                {
                    Grd_receipt.DataSource = obj_dt;
                    Grd_receipt.DataBind();
                }
              //  DataAccess.Accounts.OSDNCN obj_da_OSDN = new DataAccess.Accounts.OSDNCN();
                obj_dt = obj_da_BLPrint.GetBLPrintInvDt(txt_bl.Text, "FI", int_bid);
                /*  if (obj_dt.Rows.Count == 0)
                  {
                      if (obj_da_Customer.CheckCreditException(txt_bl.Text, "FI", int_bid).Trim().Length > 0)
                      {
                          ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('There is No Invoice for this Shipment');", true);
                          Btn_Print.Enabled = false;
                          Btn_Print.ForeColor = System.Drawing.Color.Gray;
                          return;
                      }
                      else
                      {
                          Btn_Print.Enabled = true;
                          Btn_Print.ForeColor = System.Drawing.Color.White;
                          return;
                      }

                  }*/
                DataTable dtinvc = new DataTable();
                dtinvc = obj_da_BLPrint.GetBLPrintInvDtCHK(txt_bl.Text, Session["StrTranType"].ToString(), int_bid);
                if (dtinvc.Rows.Count > 0)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('There is No Invoice for this Shipment');", true);
                    Btn_Print.Enabled = false;
                    Btn_Print.ForeColor = System.Drawing.Color.Gray;
                    return;
                }

                if (str_Nomination == "N")
                {
                    if (str_booking != "0")
                    {
                      //  DataAccess.Corporate obj_da_Corporate = new DataAccess.Corporate();
                        if (obj_da_Corporate.GetGroupID(int_customeridDO, int_divisionid) != 0)
                        {
                            if (obj_da_Customer.CheckCreditException(txt_bl.Text, "FI", int_bid).Trim().Length == 0)
                            {
                             //   if (obj_da_Customer.CheckCreditAmount(int_customeridDO, int_bid, int_divisionid) < 0)
                                if (obj_da_Customer.CheckCreditAmount4product(int_customeridDO, int_bid, int_divisionid, "FI", txt_bl.Text) < 0)
                                {

                                    //dtnew = obj_da_Customer.CheckCreditAmountnew(int_customeridDO, int_bid, int_divisionid);
                                    //if (dtnew.Rows.Count > 0)
                                    //{

                                    //    agentid = dtnew.Rows[0]["customertype"].ToString();
                                    //    if (agentid == "Y")
                                    //    {
                                    string str_Message = hid_customer.Value.ToString() + " has already reached the credit limit rupees " + obj_da_Customer.GetCreditAmount(int_customeridDO, int_divisionid) + " This Shipment has been blocked, Hence you cannot print Bill of Lading";
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + str_Message + "');", true);
                                    Btn_Print.Enabled = false;
                                    Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                    //Elengo
                                    CreatDetails(int_customeridDO);
                                    return;
                                    //    }
                                    //}
                                }
                                else
                                {
                                    //if (obj_da_Customer.CheckCreditDays4Customer(int_customeridDO, int_divisionid) < 0) //hided on 17082022
                                    //string datatrantype = Session["StrTranType"].ToString();
                                    if (obj_da_Customer.CheckCreditDays4Customer4product(int_customeridDO, int_divisionid, int_bid, "FI", txt_bl.Text) < 0)
                                    {
                                        //if (obj_da_Customer.GetCreditAmount(int_customeridDO, int_divisionid) > obj_da_Customer.CheckCreditAmount(int_customeridDO, int_bid, int_divisionid))
                                        if (obj_da_Customer.GetCreditAmount(int_customeridDO, int_divisionid) > obj_da_Customer.CheckCreditAmount4product(int_customeridDO, int_bid, int_divisionid, "FI", txt_bl.Text))
                                      
                                        {
                                            //dtnew = obj_da_Customer.CheckCreditAmountnew(int_customeridDO, int_bid, int_divisionid);
                                            //if (dtnew.Rows.Count > 0)
                                            //{

                                            //    agentid = dtnew.Rows[0]["customertype"].ToString();
                                            //    if (agentid == "Y")
                                            //    {
                                            string str_Message = hid_customer.Value.ToString() + " has already reached the credit limit Rs. " + obj_da_Customer.GetCreditAmount(int_customeridDO, int_divisionid) + "/" + obj_da_Customer.GetCreditDays(int_customeridDO, int_divisionid) + " Days." + " This Shipment has been blocked, Hence you cannot print Bill of Lading";
                                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + str_Message + "');", true);
                                            Btn_Print.Enabled = false;
                                            Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                            //Elengo
                                            CreatDetails(int_customeridDO);
                                            return;
                                            //    }
                                            //}
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (obj_da_Customer.CheckCreditException(txt_bl.Text, "FI", int_bid).Trim().Length == 0)
                            {
                                dtrecptchk = obj_da_BL.GetBLPrintRcptDtchk(txt_bl.Text, int_bid);

                                //if (Grd_receipt.Rows.Count > 0)
                                if (dtrecptchk.Rows.Count > 0)
                                {
                                    Btn_Print.Enabled = true;
                                    Btn_Print.ForeColor = System.Drawing.Color.White;
                                }
                                else
                                {
                                    Btn_Print.Enabled = false;
                                    Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('We have not received the Payment for this shipment Please Check with Accounts Department');", true);
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        obj_dt = obj_da_BLPrint.GetBLPrintRcptDt(txt_bl.Text, int_bid);
                        if (obj_dt.Rows.Count > 0)
                        {
                            Grd_receipt.DataSource = obj_dt;
                            Grd_receipt.DataBind();
                        }
                        if (Grd_Invoice.Rows.Count > 0)
                        {
                            dtrecptchk = obj_da_BL.GetBLPrintRcptDtchk(txt_bl.Text, int_bid);

                            //if (Grd_receipt.Rows.Count > 0)
                            if (dtrecptchk.Rows.Count > 0)
                            {
                                Btn_Print.Enabled = true;
                                Btn_Print.ForeColor = System.Drawing.Color.White;
                            }
                            else
                            {
                                if (Grd_Invoice.Rows.Count > 0)
                                {
                                    if (obj_da_Customer.CheckCreditException(txt_bl.Text, "FI", int_bid).Trim().Length == 0)
                                    {
                                     //   DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                                        obj_dt = obj_da_Invoice.ShowIPHead(int.Parse(Grd_Invoice.Rows[0].Cells[0].Text), "FI", "Invoice", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                        if (obj_dt.Rows.Count > 0)
                                        {
                                            if (obj_dt.Rows[0]["billtype"].ToString() == "I")
                                            {
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Btn_Print.Enabled = true;
                                        Btn_Print.ForeColor = System.Drawing.Color.White;
                                        return;
                                    }
                                }
                                Btn_Print.Enabled = false;
                                Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                txt_cha.Focus();
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('We have not received the Payment for this freehand shipment Please Check with Accounts Department');", true);
                                return;
                            }
                        }

                    }
                }
                else if (str_Nomination == "F")
                {

                    //------------------------------------NEW-------------------
                   // DataAccess.Corporate obj_da_Corporate = new DataAccess.Corporate();
                    if (txtagentid != 0)
                    {
                        if (obj_da_Corporate.GetGroupID(txtagentid, int_divisionid) != 0)
                        {
                            if (obj_da_Customer.CheckCreditException(txt_bl.Text, "FI", int_bid).Trim().Length == 0)
                            {
                                //newly added on 21082022
                                int status = 0;
                                double creditappamt = 0.00;
                                int creditappdays = 0;
                                DataTable dtprod = new DataTable();
                                // need to check creditstatus
                                dtprod = obj_da_Customer.GetCreditAmount4product(int_customeridDO, int_divisionid, int_bid, "FI", txt_bl.Text);
                                if (dtprod.Rows.Count > 0)
                                {
                                    status = Convert.ToInt32(dtprod.Rows[0]["status"].ToString());
                                    creditappamt = Convert.ToDouble(dtprod.Rows[0]["appAmount"].ToString());
                                    creditappdays = Convert.ToInt32(dtprod.Rows[0]["appdays"].ToString());
                                }

                                if (status == 0)
                                {
                                    string str_ErrMsg = dtprod.Rows[0]["creditstatus"].ToString();
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + str_ErrMsg + "');", true);
                                    Btn_Print.Enabled = false;
                                    Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                    CreatDetails(int_customeridDO);
                                    return;
                                   
                                }
                                else
                                {

                                    //end
                                    //if (obj_da_Customer.CheckCreditAmount(txtagentid, int_bid, int_divisionid) < 0)
                                    if (obj_da_Customer.CheckCreditOSAmount(int_bid, Convert.ToInt32(yearnew), txtagentid, jobno1, int_divisionid) < 0.0)
                                    {

                                        //string str_Message = str_CustomerNameagent + " has already reached the credit limit rupees " + obj_da_Customer.GetCreditAmount(txtagentid, int_divisionid) + " This Shipment has been blocked, Hence you cannot print Bill of Lading";

                                        string str_Message = str_CustomerNameagent + " has already reached the credit limit rupees " + creditappamt + " This Shipment has been blocked, Hence you cannot print Bill of Lading";
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + str_Message + "');", true);
                                        Btn_Print.Enabled = false;
                                        Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                        return;

                                    }
                                    else
                                    {
                                        //  if (obj_da_Customer.CheckCreditDays4Customer(txtagentid, int_divisionid) < 0)
                                        if (obj_da_Customer.CheckCreditDays4Customer4product(txtagentid, int_divisionid, int_bid, "FI", txt_bl.Text) < 0)
                                        {
                                            if (obj_da_Customer.GetCreditAmount(txtagentid, int_divisionid) > obj_da_Customer.CheckCreditOSAmount(int_bid, Convert.ToInt32(yearnew), txtagentid, jobno1, int_divisionid))
                                            {
                                                //string str_Message = str_CustomerNameagent + " has already reached the credit limit Rs. " + obj_da_Customer.GetCreditAmount(int_customeridDO, int_divisionid) + "/" + obj_da_Customer.GetCreditDays(txtagentid, int_divisionid) + " Days." + " This Shipment has been blocked, Hence you cannot print Bill of Lading";

                                                string str_Message = str_CustomerNameagent + " has already reached the credit limit Rs. " + creditappamt + "/" + creditappdays + " Days." + " This Shipment has been blocked, Hence you cannot print Bill of Lading";
                                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + str_Message + "');", true);
                                                Btn_Print.Enabled = false;
                                                Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                                //Elengo
                                                CreatDetails(int_customeridDO);
                                            }
                                        }
                                    }
                                }//newly added line 21082022

                            }
                        }
                    }

                    //------------------------------------NEW-------------------

                    obj_dt = obj_da_BLPrint.GetBLPrintRcptDt(txt_bl.Text, int_bid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        Grd_receipt.DataSource = obj_dt;
                        Grd_receipt.DataBind();
                    }
                    if (Grd_Invoice.Rows.Count > 0)
                    {
                        dtrecptchk = obj_da_BL.GetBLPrintRcptDtchk(txt_bl.Text, int_bid);

                        //if (Grd_receipt.Rows.Count > 0)
                        if (dtrecptchk.Rows.Count > 0)
                        {
                            Btn_Print.Enabled = true;
                            Btn_Print.ForeColor = System.Drawing.Color.White;
                        }
                        else
                        {
                            if (Grd_Invoice.Rows.Count > 0)
                            {
                                if (obj_da_Customer.CheckCreditException(txt_bl.Text, "FI", int_bid).Trim().Length == 0)
                                {
                                  //  DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                                    obj_dt = obj_da_Invoice.ShowIPHead(int.Parse(Grd_Invoice.Rows[0].Cells[0].Text), "FI", "Invoice", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        if (obj_dt.Rows[0]["billtype"].ToString() == "I")
                                        {
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    Btn_Print.Enabled = true;
                                    Btn_Print.ForeColor = System.Drawing.Color.White;
                                    return;
                                }
                            }
                            Btn_Print.Enabled = false;
                            Btn_Print.ForeColor = System.Drawing.Color.Gray;
                            txt_cha.Focus();
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('We have not received the Payment for this freehand shipment Please Check with Accounts Department');", true);
                            return;
                        }

                    }

                }

                //newly added 22082022--------------
                int status1 = 0;
                double creditappamt1 = 0.00;
                int creditappdays1 = 0;
                string creditstatus = "";
                DataTable dtprodtype = new DataTable();
                dtprodtype = obj_da_Customer.GetCreditAmount4product(int_customeridDO, int_divisionid, int_bid, "FI", txt_bl.Text);
                if (dtprodtype.Rows.Count > 0)
                {
                    status1 = Convert.ToInt32(dtprodtype.Rows[0]["status"].ToString());
                    creditstatus = dtprodtype.Rows[0]["creditstatus"].ToString();
                    creditappamt1 = Convert.ToDouble(dtprodtype.Rows[0]["appAmount"].ToString());
                    creditappdays1 = Convert.ToInt32(dtprodtype.Rows[0]["appdays"].ToString());
                    if (txt_Quotation.Text != "")
                    {
                       if( dtu.Rows.Count>0)
                       {
                           txt_creditgroupcus.Text = dtu.Rows[0]["groupname"].ToString() + " / App Days : " + creditappdays1 + " / App Amt : " + creditappamt1 + " / " + creditstatus;

                       //    txt_creditgroupcus.Text = dtu.Rows[0]["groupname"].ToString() + "/" + creditappdays1 + "/" + creditappamt1 + "/" + creditstatus;

                       }
                    }
                }
                //end-------------
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void Fn_GetDetails()
        {
            try
            {
                double osamt = 0.00;
                DataTable dtnew = new DataTable();
                string agentid = "";
                int txtagentid = 0;
                int JOBNO = 0;
                int year;
                string yearnew;
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                string str_Nomination = "", str_CustomerName = "";
                int cnf = 0;
                int cfs = 0;
                chk_container.Items.Clear();
                DataTable obj_dt = new DataTable();

                DataAccess.ForwardingExports.BLPrinting obj_da_BL = new DataAccess.ForwardingExports.BLPrinting();
                DataAccess.ForwardingImports.BLDetails obj_da_FIBL = new DataAccess.ForwardingImports.BLDetails();
                DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                string Ccode = Convert.ToString(Session["Ccode"]);
                obj_da_BL.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);
                obj_da_FEBL.GetDataBase(Ccode);
                obj_da_FIBL.GetDataBase(Ccode);
                if (Logobj.GetDate().Month < 4)
                {
                    yearnew = (Logobj.GetDate().Year - 1).ToString();
                }
                else
                {
                    yearnew = Logobj.GetDate().Year.ToString();
                }
                if (hid_BL.Value.ToString() == "false")
                {
                    if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                    {
                        obj_dt = obj_da_BL.GetBLPrintingDt(txt_bl.Text, Session["StrTranType"].ToString(), int_bid, int_divisionid);
                    }
                }
                else
                {
                    obj_dt = obj_da_BL.GetBLPrintingDt(txt_bl.Text, "F", int_bid, int_divisionid);
                }
                if (obj_dt.Rows.Count != 0)
                {
                    //txt_date.Text = obj_dt.Rows[0]["bldate"].ToString();
                    //txt_issued.Text = obj_dt.Rows[0]["issuedat"].ToString();
                    //txt_shipper.Text = obj_dt.Rows[0]["shipper"].ToString();
                    //txt_consignee.Text = obj_dt.Rows[0]["consignee"].ToString();
                    //txt_notify.Text = obj_dt.Rows[0]["notify"].ToString();
                    //txt_remark.Text = obj_dt.Rows[0]["remarks"].ToString();
                    txt_date.Text = obj_dt.Rows[0][0].ToString();

                    txt_issued.Text = obj_dt.Rows[0][1].ToString();
                    txt_shipper.Text = obj_dt.Rows[0][2].ToString();
                    txt_consignee.Text = obj_dt.Rows[0]["consignee"].ToString();
                    hid_consign.Value = obj_dt.Rows[0]["consigneeid"].ToString();
                    txt_notify.Text = obj_dt.Rows[0]["notify"].ToString();
                    txt_remark.Text = obj_dt.Rows[0]["remarks"].ToString();

                    //if (!string.IsNullOrEmpty(obj_dt.Rows[0].ItemArray[5].ToString()))
                    //{
                    //    str_CustomerName = obj_da_Customer.GetCustomername(int.Parse(obj_dt.Rows[0].ItemArray[5].ToString()));
                    //    cfs = Convert.ToInt32(obj_dt.Rows[0].ItemArray[5]);
                    //}
                    if (Session["StrTranType"].ToString() != "FE")
                    {

                        txt_cfs.Text = obj_da_Customer.GetCustomername(int.Parse(obj_dt.Rows[0].ItemArray[5].ToString()));
                        cfs = Convert.ToInt32(obj_dt.Rows[0].ItemArray[5]);
                        txt_cfs.Text = obj_da_Customer.GetCustomername(cfs);
                        txt_mvessel.Text = obj_dt.Rows[0]["mvessel"].ToString();
                        //txt_voyage.Text = obj_dt.Rows[0]["mvoy"].ToString();
                        str_Nomination = obj_dt.Rows[0]["nomination"].ToString();
                        hid_nomination.Value = obj_dt.Rows[0]["nomination"].ToString();
                        if (hid_BL.Value.ToString() == "false")
                        {
                            if (obj_dt.Rows[0]["blsurrendered"].ToString() == "Y")
                            {
                                txt_hbl.Text = "SURRENDERED";
                            }
                            else
                            {
                                txt_hbl.Text = "NOT SURRENDERED";
                            }
                        }
                        if (hid_BL.Value.ToString() == "true")
                        {
                            txt_cfs.Text = obj_dt.Rows[0]["cfsid"].ToString();
                            txt_destuff.Text = obj_dt.Rows[0]["mvoy"].ToString() + "&" + obj_da_Customer.GetCustomername(cfs);
                        }
                        else
                        {
                            //txt_hbl.Text = "";
                            txt_destuff.Text = obj_dt.Rows[0]["mvoy"].ToString();
                        }
                        if (hid_BL.Value.ToString() == "false")
                        {
                            txt_job.Text = obj_dt.Rows[0]["jobno"].ToString();
                            JOBNO = Convert.ToInt32(obj_dt.Rows[0]["jobno1"].ToString());
                            txt_line.Text = obj_dt.Rows[0]["linenumber"].ToString();
                            hid_job.Value = obj_dt.Rows[0]["intjobno"].ToString();
                            txt_destuff.Text = obj_dt.Rows[0]["mvoy"].ToString();
                        }
                        else
                        {
                            txt_destuff.Text = obj_dt.Rows[0]["mvoy"].ToString() + " & " + cfs;
                        }
                        txt_freight.Text = obj_dt.Rows[0]["freight"].ToString();
                    }
                    else
                    {
                        txt_freight.Text = obj_dt.Rows[0]["freight"].ToString();
                        txt_line.Text = "NOT APPLICABLE";
                        txt_job.Text = obj_dt.Rows[0]["jobno"].ToString();
                        JOBNO = Convert.ToInt32(obj_dt.Rows[0]["jobno1"].ToString());
                        hid_job.Value = obj_dt.Rows[0]["intjobno"].ToString();

                        if (obj_dt.Rows[0]["surrendered"].ToString() == "S")
                        {
                            txt_hbl.Text = "SURRENDERED";
                        }
                        else if (obj_dt.Rows[0]["surrendered"].ToString() == "B")
                        {
                            txt_hbl.Text = "SEAWAY BILL";
                        }
                        else
                        {
                            txt_hbl.Text = "RELEASE";
                        }

                        if (obj_dt.Rows[0]["mblstatus"].ToString() == "S")
                        {
                            txt_mblstatus.Text = "SURRENDERED";
                        }
                        else if (obj_dt.Rows[0]["surrendered"].ToString() == "B")
                        {
                            txt_mblstatus.Text = "SEAWAY BILL";
                        }
                        else
                        {
                            txt_mblstatus.Text = "RELEASE";
                        }

                    }
                    DataTable obj_dttemp = new DataTable();
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        txt_cha.Text = obj_da_Customer.GetCustomername(int.Parse(obj_dt.Rows[0].ItemArray[5].ToString()));
                        cnf = Convert.ToInt32(obj_dt.Rows[0].ItemArray[5]);
                        txt_cha.Text = obj_da_Customer.GetCustomername(Convert.ToInt32(cnf));
                        Btn_Print.Text = "Print";
                       // DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                        obj_dttemp = obj_da_jobinfo.GetContainerDetails(int.Parse(hid_job.Value.ToString()), txt_bl.Text, int_bid, int_divisionid);
                        for (int i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                        {
                            chk_container.Items.Add(obj_dttemp.Rows[i][0].ToString() + "/" + obj_dttemp.Rows[i][1].ToString() + "/" + obj_dttemp.Rows[i][2].ToString());
                            if (i == 0)
                            {
                                hid_contno.Value = obj_dttemp.Rows[i][0].ToString();
                            }
                            else
                            {
                                hid_contno.Value = hid_contno.Value.ToString() + "/" + obj_dttemp.Rows[i][0].ToString();
                            }
                        }
                    }
                    else
                    {
                        txt_cha.Text = obj_da_Customer.GetCustomername(int.Parse(obj_dt.Rows[0].ItemArray[5].ToString()));
                        cnf = Convert.ToInt32(obj_dt.Rows[0].ItemArray[5]);
                        obj_dttemp = obj_da_FIBL.GetContainerDetail(int.Parse(hid_job.Value.ToString()), txt_bl.Text, int_bid, int_divisionid);
                        for (int i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                        {
                            chk_container.Items.Add(obj_dttemp.Rows[i][0].ToString() + "/" + obj_dttemp.Rows[i][1].ToString() + "/" + obj_dttemp.Rows[i][2].ToString());
                            if (i == 0)
                            {
                                hid_contno.Value = obj_dttemp.Rows[i][0].ToString();
                            }
                            else
                            {
                                hid_contno.Value = hid_contno.Value.ToString() + "/" + obj_dttemp.Rows[i][0].ToString();
                            }
                        }
                    }
                    if (hid_BL.Value == "false")
                    {
                        if (lbl_header.Text == "DODetails")
                        {

                            txt_cfs.Enabled = true;
                            txt_cfs.Visible = true;
                            lblCFS.Visible = true;
                            txt_cha.Enabled = true;
                            txt_cha.ReadOnly = false;
                            txt_cfs.Attributes.Add("CFS", "Placeholder");
                            txt_cfs.ToolTip = "Container Fright Station";
                            //DataTable dt = new DataTable();
                            //DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
                            //dt = Appobj.checkblstatus(txt_bl.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            //if (dt.Rows.Count > 0)
                            //{
                            //    if (dt.Rows[0]["blstatus"].ToString() == "R")
                            //    {
                            //        Btn_Print.Text = "Update";
                            //        Btn_Print.Enabled = true;
                            //    }
                            //    else if (dt.Rows[0]["blstatus"].ToString() == "H")
                            //    {
                            //        Btn_Print.Text = "Update";
                            //        Btn_Print.Enabled = false;
                            //    }
                            //}
                            Btn_Print.Text = "Update";
                            txt_cfs.Text = obj_da_Customer.GetCustomername(int.Parse(obj_dt.Rows[0].ItemArray[5].ToString()));
                            cnf = Convert.ToInt32(obj_dt.Rows[0].ItemArray[5]);

                            if (obj_dt.Rows[0].ItemArray[27].ToString() == "")
                            {
                                txt_cha.Text = "";
                            }
                            else
                            {
                                txt_cha.ReadOnly = false;
                                cnf = Convert.ToInt32(obj_dt.Rows[0].ItemArray[27].ToString());
                                txt_cfs.Text = (obj_da_Customer.GetCustomername(cnf));
                                hid_cha.Value = cnf.ToString();
                                //if (dt.Rows.Count > 0)
                                //{
                                //    if (dt.Rows[0]["blstatus"].ToString() == "R")
                                //    {
                                //        Btn_Print.Text = "Update";
                                //        Btn_Print.Enabled = true;
                                //    }
                                //    else if (dt.Rows[0]["blstatus"].ToString() == "H")
                                //    {
                                //        Btn_Print.Text = "Update";
                                //        Btn_Print.Enabled = false;
                                //    }
                                //}
                                Btn_Print.Text = "Update";
                            }
                            //if (txt_cha.Text.Trim().Length > 0)
                            //{
                            //    txt_cha.ReadOnly = false;
                            //}

                        }
                        else
                        {
                            if (obj_dt.Rows[0].ItemArray[27].ToString() == "")
                            {
                                txt_cha.Text = "";
                            }
                            else
                            {
                                cnf = Convert.ToInt32(obj_dt.Rows[0].ItemArray[5]);
                                hid_cha.Value = cnf.ToString();
                                Btn_Print.Text = "Print";
                                txt_cha.ReadOnly = true;
                                txt_cfs.Visible = false;
                                txt_cha.Text = (obj_da_Customer.GetCustomername(cnf));

                            }
                            //txt_cha.Text = obj_da_Customer.GetCustomername(int.Parse(obj_dt.Rows[0].ItemArray[5].ToString()));

                        }
                    }
                    else
                    {
                        txt_cha.ReadOnly = true;
                        Btn_Print.Text = "Print";
                        txt_cfs.ReadOnly = false;
                        txt_cfs.Enabled = false;
                        txt_cfs.Text = obj_da_Customer.GetCustomername(int.Parse(obj_dt.Rows[0].ItemArray[5].ToString()));
                        hid_BL.Value = "false";
                    }
                    txt_agent.Text = obj_dt.Rows[0]["agent"].ToString();
                    txtagentid = Convert.ToInt32(obj_dt.Rows[0]["jobagent"].ToString());

                    str_CustomerName = obj_da_Customer.GetCustomername(txtagentid);

                    txt_mlo.Text = obj_dt.Rows[0]["mlo"].ToString();
                    txt_POR.Text = obj_dt.Rows[0]["por"].ToString();
                    txt_POL.Text = obj_dt.Rows[0]["pol"].ToString();
                    txt_POD.Text = obj_dt.Rows[0]["pod"].ToString();
                    txt_FD.Text = obj_dt.Rows[0]["fd"].ToString();
                    txt_mark.Text = obj_dt.Rows[0]["marks"].ToString();
                    txt_cargo.Text = obj_dt.Rows[0]["descn"].ToString();
                    txt_kgs.Text = obj_dt.Rows[0]["ntweight"].ToString();
                    txt_volume.Text = obj_dt.Rows[0]["cbm"].ToString();
                    txt_packages.Text = obj_dt.Rows[0]["noofpkgs"].ToString() + " " + obj_dt.Rows[0]["package"].ToString();
                    txt_vessel.Text = obj_dt.Rows[0]["fvessel"].ToString();
                    txt_voyage.Text = obj_dt.Rows[0]["fvoy"].ToString();
                    txt_fpol.Text = obj_dt.Rows[0]["fpol"].ToString();
                    txt_fpod.Text = obj_dt.Rows[0]["fpod"].ToString();

                    DataTable dt;
                   // DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                    dt = obj_MasterPort.SelPortName4typepadimg(txt_fpol.Text.ToUpper(), Session["StrTranType"].ToString());
                    fpolflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    dt = obj_MasterPort.SelPortName4typepadimg(txt_fpod.Text.ToUpper(), Session["StrTranType"].ToString());
                    fpodflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    txt_feta.Text = obj_dt.Rows[0]["feta"].ToString();
                    txt_fetd.Text = obj_dt.Rows[0]["fetd"].ToString();
                    txt_freight.Text = obj_dt.Rows[0]["freight"].ToString();
                   
                    dt = obj_MasterPort.SelPortName4typepadimg(txt_FD.Text.ToUpper(), Session["StrTranType"].ToString());
                    fdflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    dt = obj_MasterPort.SelPortName4typepadimg(txt_POR.Text.ToUpper(), Session["StrTranType"].ToString());
                    porflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    dt = obj_MasterPort.SelPortName4typepadimg(txt_POD.Text.ToUpper(), Session["StrTranType"].ToString());
                    podflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    dt = obj_MasterPort.SelPortName4typepadimg(txt_POL.Text.ToUpper(), Session["StrTranType"].ToString());
                    flagimg.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";


                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        txt_mbl.Text = obj_dt.Rows[0]["mblno"].ToString();
                    }
                    else
                    {
                        txt_mbl.Text = obj_dt.Rows[0]["mblno"].ToString() + " & " + obj_dt.Rows[0]["mbldateweb"].ToString();
                    }
                    txt_jobtype.Text = obj_dt.Rows[0]["type"].ToString();
                    txt_dodate.Text = obj_dt.Rows[0]["doissuedon"].ToString();
                    txt_remark.Text = obj_dt.Rows[0]["remarks"].ToString();

                  //  DataAccess.ForwardingExports.Confirmation obj_da_confirm = new DataAccess.ForwardingExports.Confirmation();
                    obj_dttemp = obj_da_confirm.GetConfirmDetails(txt_bl.Text, "C", int_bid, int_divisionid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        txt_mvessel.Text = obj_dttemp.Rows[0][1].ToString();
                        txt_destuff.Text = obj_dttemp.Rows[0][4].ToString();
                    }
                    else
                    {
                        obj_dttemp = obj_da_confirm.GetConfirmDetails(txt_bl.Text, "T", int_bid, int_divisionid);
                        if (obj_dttemp.Rows.Count > 0)
                        {
                            txt_mvessel.Text = obj_dttemp.Rows[0][1].ToString();
                            txt_destuff.Text = obj_dttemp.Rows[0][4].ToString();
                        }
                    }

                }
                else
                {
                    Fn_Clear();
                }

                obj_dt = obj_da_BL.GetBLPrintInvDt(txt_bl.Text, Session["StrTranType"].ToString(), int_bid);
                if (obj_dt.Rows.Count > 0)
                {
                    Grd_Invoice.DataSource = obj_dt;
                    Grd_Invoice.DataBind();
                }
                obj_dt = obj_da_BL.GetBLPrintDNDt(txt_bl.Text, Session["StrTranType"].ToString(), int_bid);
                if (obj_dt.Rows.Count > 0)
                {
                    Grd_DN.DataSource = obj_dt;
                    Grd_DN.DataBind();
                }

                if (lbl_header.Text == "DODetails" && Session["StrTranType"].ToString() == "FI")
                {
                    int int_DoDay = 0;
                    int_DoDay = obj_da_FIBL.GetPendingDODays(txt_bl.Text, int_bid, int_divisionid);
                    if (int_DoDay > 0)
                    {
                        btn_DOsale.Visible = true;dosale_id.Visible = true;
                        btn_DO.Visible = true;btn_DO_id.Visible = true;
                        div_cha.Attributes["class"] = "div_chanew";
                        //doday.Visible = false;
                        dodaytxt.Visible = true;
                        txt_doday.Text = int_DoDay.ToString();
                    }
                    else
                    {
                        btn_DOsale.Visible = false;dosale_id.Visible = false;
                        btn_DO.Visible = false;btn_DO_id.Visible = false;
                        div_cha.Attributes["class"] = "div_cha_visible";
                        //doday.Visible = false;
                        dodaytxt.Visible = false;
                    }

                }
                string str_booking = "";
                int int_customeridDO = 0;
                str_booking = obj_da_FIBL.GetBookinkNo(txt_bl.Text, int_bid, int_divisionid);
                hid_BookingNo.Value = str_booking;
                obj_dt = obj_da_FEBL.GetBookingDt(str_booking, int_bid, int_divisionid);
                if (obj_dt.Rows.Count > 0)
                {
                    int_customeridDO = int.Parse(obj_dt.Rows[0]["customerid"].ToString());
                    hid_customer.Value = obj_dt.Rows[0]["shipper"].ToString();
                }
              //  DataAccess.ForwardingExports.BLPrinting obj_da_BLPrint = new DataAccess.ForwardingExports.BLPrinting();
                obj_dt = obj_da_BLPrint.GetBLPrintRcptDt(txt_bl.Text, int_bid);
                if (obj_dt.Rows.Count > 0)
                {
                    Grd_receipt.DataSource = obj_dt;
                    Grd_receipt.DataBind();
                }

                if (str_booking != "0")
                {
                    if (Session["StrTranType"].ToString() == "FI")
                    {
                        if (str_Nomination == "N")
                        {
                            obj_dt = obj_da_FIBL.GetBookingDtls(str_booking, Session["StrTranType"].ToString(), int_bid, int_divisionid);
                            if (obj_dt.Rows.Count > 0)
                            {
                                txt_book.Text = str_booking + " & " + obj_dt.Rows[0]["bookingdate"].ToString();
                                Session["booking"] = str_booking;
                                txt_Quotation.Text = obj_dt.Rows[0]["quotno"].ToString() + " & " + obj_dt.Rows[0]["quotdate"].ToString();
                                quotno = Convert.ToInt32(obj_dt.Rows[0]["quotno"]);
                                Session["Quo"] = obj_dt.Rows[0]["quotno"].ToString();
                                txt_marketed.Text = obj_dt.Rows[0]["marketedbyName"].ToString();
                                Session["quotno"] = obj_dt.Rows[0]["quotno"].ToString();
                                obj_dt = obj_da_BLPrint.GetBLPrintRcptDt(txt_bl.Text, int_bid);
                                if (obj_dt.Rows.Count > 0)
                                {
                                    Grd_receipt.DataSource = obj_dt;
                                    Grd_receipt.DataBind();
                                }
                                if (txt_Quotation.Text != "")
                                {
                                    dtu = objbl.getcreditdaygroupname(quotno, int_bid);
                                    if (dtu.Rows.Count > 0)
                                    {
                                        txt_creditgroupcus.Text = dtu.Rows[0]["groupname"].ToString() + "/" + dtu.Rows[0]["creditdays"].ToString() + "/" + dtu.Rows[0]["creditamt"].ToString();
                                    }
                                }
                            }
                            else
                            {
                                txt_book.Text = "";
                                txt_Quotation.Text = "";
                                txt_marketed.Text = "";
                            }

                        }

                        obj_dt = obj_da_BLPrint.GetBLPrintRcptDt(txt_bl.Text, int_bid);
                        if (obj_dt.Rows.Count > 0)
                        {
                            Grd_receipt.DataSource = obj_dt;
                            Grd_receipt.DataBind();
                        }

                    }
                    else
                    {
                        obj_dt = obj_da_FIBL.GetBookingDtls(str_booking, Session["StrTranType"].ToString(), int_bid, int_divisionid);
                        if (obj_dt.Rows.Count > 0)
                        {
                            txt_book.Text = str_booking + " & " + obj_dt.Rows[0]["bookingdate"].ToString();
                            Session["booking"] = str_booking;
                            txt_Quotation.Text = obj_dt.Rows[0]["quotno"].ToString() + " & " + obj_dt.Rows[0]["quotdate"].ToString();
                            quotno = Convert.ToInt32(obj_dt.Rows[0]["quotno"]);
                            Session["Quo"] = obj_dt.Rows[0]["quotno"].ToString();
                            txt_marketed.Text = obj_dt.Rows[0]["marketedbyName"].ToString();
                            Session["quotno"] = obj_dt.Rows[0]["quotno"].ToString();
                            // Session["queryQuotno"] = obj_dt.Rows[0]["quotno"].ToString();

                            obj_dt = obj_da_BLPrint.GetBLPrintRcptDt(txt_bl.Text, int_bid);
                            if (obj_dt.Rows.Count > 0)
                            {
                                Grd_receipt.DataSource = obj_dt;
                                Grd_receipt.DataBind();
                            }
                            if (txt_Quotation.Text != "")
                            {
                                dtu = objbl.getcreditdaygroupname(quotno, int_bid);
                                if (dtu.Rows.Count > 0)
                                {
                                    txt_creditgroupcus.Text = dtu.Rows[0]["groupname"].ToString() + "/" + dtu.Rows[0]["creditdays"].ToString() + "/" + dtu.Rows[0]["creditamt"].ToString();
                                }
                            }
                        }
                        else
                        {
                            txt_book.Text = "";
                            txt_Quotation.Text = "";
                            txt_marketed.Text = "";
                        }
                        obj_dt = obj_da_BLPrint.GetBLPrintRcptDt(txt_bl.Text, int_bid);
                        if (obj_dt.Rows.Count > 0)
                        {
                            Grd_receipt.DataSource = obj_dt;
                            Grd_receipt.DataBind();
                        }
                    }

                }
                else
                {
                    txt_book.Text = "";
                    txt_Quotation.Text = "";
                    txt_marketed.Text = "";
                    obj_dt = obj_da_BLPrint.GetBLPrintRcptDt(txt_bl.Text, int_bid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        Grd_receipt.DataSource = obj_dt;
                        Grd_receipt.DataBind();
                    }
                }
                if (lbl_header.Text == "DODetails")
                {

                    //DataTable dtinvc=new DataTable();

                    //dtinvc = obj_da_BLPrint.GetBLPrintInvDtCHK(txt_bl.Text, Session["StrTranType"].ToString(), int_bid);
                    //if (dtinvc.Rows.Count>0)
                    //{

                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('There is No Invoice for this Shipment');", true);
                    //    Btn_Print.Enabled = false;
                    //    Btn_Print.ForeColor = System.Drawing.Color.Gray;
                    //    return;
                    //}
                    DataTable dtcontstuff = new DataTable();  // 04-02-2022  
                    //dtcontstuff = obj_da_BLPrint.GetBLContDesuffOtNot(txt_bl.Text, Session["StrTranType"].ToString(), int_bid);
                    //if (dtcontstuff.Rows.Count > 0)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('Please update desutff date to relese the DO');", true);
                    //    Btn_Print.Enabled = false;
                    //    Btn_Print.ForeColor = System.Drawing.Color.Gray;
                    //    return;
                    //}
                    if (int_customeridDO != 0)
                    {
                        if (str_Nomination == "N")
                        {
                          //  DataAccess.Corporate obj_da_Corporate = new DataAccess.Corporate();
                            if (obj_da_Corporate.GetGroupID(int_customeridDO, int_divisionid) != 0)
                            {
                                if (obj_da_Customer.CheckCreditException(txt_bl.Text, "FI", int_bid).Trim().Length == 0)
                                {
                                    int status = 0;
                                    double creditappamt = 0.00;
                                    int creditappdays = 0;
                                    DataTable dtprod =new DataTable();
                                    // need to check creditstatus
                                    dtprod = obj_da_Customer.GetCreditAmount4product(int_customeridDO, int_divisionid, int_bid,"FI", txt_bl.Text);
                                    if (dtprod.Rows.Count > 0)
                                    {
                                        status = Convert.ToInt32(dtprod.Rows[0]["status"].ToString());
                                        creditappamt = Convert.ToDouble(dtprod.Rows[0]["appAmount"].ToString());
                                        creditappdays = Convert.ToInt32(dtprod.Rows[0]["appdays"].ToString());
                                    }

                                    if (status == 0)
                                    {
                                        string str_ErrMsg = dtprod.Rows[0]["creditstatus"].ToString();                                                                             
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + str_ErrMsg + "');", true);
                                        Btn_Print.Enabled = false;
                                        Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                        CreatDetails(int_customeridDO);
                                        return;
                                        
                                    }
                                    else
                                    {
                                        //if (obj_da_Customer.CheckCreditAmount(int_customeridDO, int_bid, int_divisionid) < 0)
                                        if (obj_da_Customer.CheckCreditAmount4product(int_customeridDO, int_bid, int_divisionid, "FI", txt_bl.Text) < 0)
                                        {
                                            //dtnew = obj_da_Customer.CheckCreditAmountnew(int_customeridDO, int_bid, int_divisionid);
                                            //if (dtnew.Rows.Count > 0)
                                            //{

                                            //    agentid = dtnew.Rows[0]["customertype"].ToString();
                                            //    if (agentid == "Y")
                                            //    {
                                            //  string str_Message = hid_customer.Value.ToString() + " has already reached the credit limit rupees " + obj_da_Customer.GetCreditAmount(int_customeridDO, int_divisionid) + " This Shipment has been blocked, Hence you cannot print Bill of Lading";
                                            string str_Message = hid_customer.Value.ToString() + " has already reached the credit limit rupees " + creditappamt + " This Shipment has been blocked, Hence you cannot print Bill of Lading";
                                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + str_Message + "');", true);
                                            Btn_Print.Enabled = false;
                                            Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                            CreatDetails(int_customeridDO);
                                            return;
                                            //    }
                                            //}

                                        }
                                        else
                                        {
                                            // if (obj_da_Customer.CheckCreditDays4Customer(int_customeridDO, int_divisionid) < 0)
                                            if (obj_da_Customer.CheckCreditDays4Customer4product(int_customeridDO, int_divisionid, int_bid, "FI", txt_bl.Text) < 0)
                                            {
                                                //if (obj_da_Customer.GetCreditAmount(int_customeridDO, int_divisionid) > obj_da_Customer.CheckCreditAmount(int_customeridDO, int_bid, int_divisionid))
                                                if (creditappamt > obj_da_Customer.CheckCreditAmount4product(int_customeridDO, int_bid, int_divisionid, "FI", txt_bl.Text))
                                                {
                                                    //dtnew = obj_da_Customer.CheckCreditAmountnew(int_customeridDO, int_bid, int_divisionid);
                                                    //if (dtnew.Rows.Count > 0)
                                                    //{

                                                    //    agentid = dtnew.Rows[0]["customertype"].ToString();
                                                    //    if (agentid == "Y")
                                                    //    {
                                                    
                                                    //string str_Message = hid_customer.Value.ToString() + " has already reached the credit limit Rs. " + obj_da_Customer.GetCreditAmount(int_customeridDO, int_divisionid) + "/" + obj_da_Customer.GetCreditDays(int_customeridDO, int_divisionid) + " Days." + " This Shipment has been blocked, Hence you cannot print Bill of Lading";
                                                    string str_Message = hid_customer.Value.ToString() + " has already reached the credit limit Rs. " + creditappamt + "/" + creditappdays + " Days." + " This Shipment has been blocked, Hence you cannot print Bill of Lading";                                      
                                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + str_Message + "');", true);
                                                    Btn_Print.Enabled = false;
                                                    Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                                    //Elengo
                                                    CreatDetails(int_customeridDO);
                                                    //        return;
                                                    //    }
                                                    //}
                                                }
                                            }
                                        }

                                    } //new added

                                }
                            }
                            else
                            {
                                if (obj_da_Customer.CheckCreditException(txt_bl.Text, "FI", int_bid).Trim().Length == 0)
                                {

                                    dtrecptchk = obj_da_BL.GetBLPrintRcptDtchk(txt_bl.Text, int_bid);

                                    //if (Grd_receipt.Rows.Count > 0)
                                    if (dtrecptchk.Rows.Count > 0)
                                    {
                                        Btn_Print.Enabled = true;
                                        Btn_Print.ForeColor = System.Drawing.Color.White;
                                    }
                                    else
                                    {
                                        Btn_Print.Enabled = false;
                                        Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('We have not received the Payment for this shipment Please Check with Accounts Department');", true);
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {

                            if (Grd_Invoice.Rows.Count > 0)
                            {
                                dtrecptchk = obj_da_BL.GetBLPrintRcptDtchk(txt_bl.Text, int_bid);

                                //if (Grd_receipt.Rows.Count > 0)
                                if (dtrecptchk.Rows.Count > 0)
                                {
                                    Btn_Print.Enabled = true;
                                    Btn_Print.ForeColor = System.Drawing.Color.White;
                                }
                                else
                                {
                                    if (Grd_Invoice.Rows.Count > 0)
                                    {
                                        if (obj_da_Customer.CheckCreditException(txt_bl.Text, "FI", int_bid).Trim().Length == 0)
                                        {
                                           // DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                                            obj_dt = obj_da_Invoice.ShowIPHead(int.Parse(Grd_Invoice.Rows[0].Cells[0].Text), "FI", "Invoice", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                            if (obj_dt.Rows.Count > 0)
                                            {
                                                if (obj_dt.Rows[0]["billtype"].ToString() == "I")
                                                {
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Btn_Print.Enabled = true;
                                            Btn_Print.ForeColor = System.Drawing.Color.White;
                                            return;
                                        }
                                    }
                                    Btn_Print.Enabled = false;
                                    Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                    txt_cha.Focus();
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('We have not received the Payment for this freehand shipment Please Check with Accounts Department');", true);
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        //------------------------------------NEW-------------------
                      //  DataAccess.Corporate obj_da_Corporate = new DataAccess.Corporate();
                        if (txtagentid != 0)
                        {
                            if (obj_da_Corporate.GetGroupID(txtagentid, int_divisionid) != 0)
                            {
                                if (obj_da_Customer.CheckCreditException(txt_bl.Text, "FI", int_bid).Trim().Length == 0)
                                {
                                     //newly added on 21082022
                                int status = 0;
                                double creditappamt = 0.00;
                                int creditappdays = 0;
                                DataTable dtprod = new DataTable();
                                // need to check creditstatus
                                dtprod = obj_da_Customer.GetCreditAmount4product(int_customeridDO, int_divisionid, int_bid, "FI", txt_bl.Text);
                                if (dtprod.Rows.Count > 0)
                                {
                                    status = Convert.ToInt32(dtprod.Rows[0]["status"].ToString());
                                    creditappamt = Convert.ToDouble(dtprod.Rows[0]["appAmount"].ToString());
                                    creditappdays = Convert.ToInt32(dtprod.Rows[0]["appdays"].ToString());
                                }

                                if (status == 0)
                                {
                                    string str_ErrMsg = dtprod.Rows[0]["creditstatus"].ToString();
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + str_ErrMsg + "');", true);
                                    Btn_Print.Enabled = false;
                                    Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                    CreatDetails(int_customeridDO);
                                    return;

                                }
                                else
                                {
                                    //end

                                    ///if (obj_da_Customer.CheckCreditAmount(txtagentid, int_bid, int_divisionid) < 0)
                                    if (obj_da_Customer.CheckCreditOSAmount(int_bid, Convert.ToInt32(yearnew), txtagentid, JOBNO, int_divisionid) < 0.0)
                                    {
                                       // string str_Message = str_CustomerName + " has already reached the credit limit rupees " + obj_da_Customer.GetCreditAmount(txtagentid, int_divisionid) + " This Shipment has been blocked, Hence you cannot print Bill of Lading";

                                        string str_Message = str_CustomerName + " has already reached the credit limit rupees " + creditappamt + " This Shipment has been blocked, Hence you cannot print Bill of Lading";
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + str_Message + "');", true);
                                        Btn_Print.Enabled = false;
                                        Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                        return;

                                    }
                                    else
                                    {
                                        // if (obj_da_Customer.CheckCreditDays4Customer(txtagentid, int_divisionid) < 0.0)
                                        if (obj_da_Customer.CheckCreditDays4Customer4product(txtagentid, int_divisionid, int_bid, "FI", txt_bl.Text) < 0.0)
                                        {
                                            //if (obj_da_Customer.GetCreditAmount(txtagentid, int_divisionid) > obj_da_Customer.CheckCreditAmount(txtagentid, int_bid, int_divisionid))

                                            if (obj_da_Customer.GetCreditAmount(txtagentid, int_divisionid) > obj_da_Customer.CheckCreditOSAmount(int_bid, Convert.ToInt32(yearnew), txtagentid, JOBNO, int_divisionid))
                                            {
                                                //string str_Message = str_CustomerName + " has already reached the credit limit Rs. " + obj_da_Customer.GetCreditAmount(int_customeridDO, int_divisionid) + "/" + obj_da_Customer.GetCreditDays(txtagentid, int_divisionid) + " Days." + " This Shipment has been blocked, Hence you cannot print Bill of Lading";

                                                string str_Message = str_CustomerName + " has already reached the credit limit Rs. " + creditappamt + "/" + creditappdays  + " Days." + " This Shipment has been blocked, Hence you cannot print Bill of Lading";
                                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + str_Message + "');", true);
                                                Btn_Print.Enabled = false;
                                                Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                                //Elengo
                                                CreatDetails(int_customeridDO);
                                            }
                                        }
                                    }

                                }//newly aded lin 21082022

                                }
                            }
                        }
                        //------------------------------------NEW-------------------
                        if (Grd_Invoice.Rows.Count > 0)
                        {
                            dtrecptchk = obj_da_BL.GetBLPrintRcptDtchk(txt_bl.Text, int_bid);

                            //if (Grd_receipt.Rows.Count > 0)

                            if (dtrecptchk.Rows.Count > 0)
                            {
                                //DataTable dt = new DataTable();
                                //DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
                                //dt = Appobj.checkblstatus(txt_bl.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                //if (dt.Rows.Count > 0)
                                //{
                                //    if (dt.Rows[0]["blstatus"].ToString() == "R")
                                //    {
                                //        Btn_Print.Text = "Update";
                                //        Btn_Print.Enabled = true;
                                //    }
                                //    else if (dt.Rows[0]["blstatus"].ToString() == "H")
                                //    {
                                //        Btn_Print.Text = "Update";
                                //        Btn_Print.Enabled = false;
                                //    }
                                //}
                                Btn_Print.Enabled = true;
                                Btn_Print.ForeColor = System.Drawing.Color.White;
                            }
                            else
                            {
                                if (Grd_Invoice.Rows.Count > 0)
                                {
                                    if (obj_da_Customer.CheckCreditException(txt_bl.Text, "FI", int_bid).Trim().Length == 0)
                                    {
                                      //  DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                                        obj_dt = obj_da_Invoice.ShowIPHead(int.Parse(Grd_Invoice.Rows[0].Cells[0].Text), "FI", "Invoice", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                        if (obj_dt.Rows.Count > 0)
                                        {
                                            if (obj_dt.Rows[0]["billtype"].ToString() == "I")
                                            {
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Btn_Print.Enabled = true;
                                        Btn_Print.ForeColor = System.Drawing.Color.White;
                                        return;
                                    }
                                }
                                Btn_Print.Enabled = false;
                                Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                txt_cha.Focus();
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('We have not received the Payment for this freehand shipment Please Check with Accounts Department');", true);
                                return;
                            }
                        }
                        else
                        {
                            Btn_Print.Enabled = false;
                            txt_book.Focus();
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('There is no invoice for shipment');", true);
                            return;
                        }
                    }
                }
                else
                {
                    Btn_Print.Enabled = true;
                    Btn_Print.ForeColor = System.Drawing.Color.White;
                }

                //newly added 22082022--------------
                int status1 = 0;
                double creditappamt1 = 0.00;
                int creditappdays1 = 0;
                string creditstatus = "";
                DataTable dtprodtype = new DataTable();
                dtprodtype = obj_da_Customer.GetCreditAmount4product(int_customeridDO, int_divisionid, int_bid, "FI", txt_bl.Text);
                if (dtprodtype.Rows.Count > 0)
                {
                    status1 = Convert.ToInt32(dtprodtype.Rows[0]["status"].ToString());
                    creditstatus = dtprodtype.Rows[0]["creditstatus"].ToString();
                    creditappamt1 = Convert.ToDouble(dtprodtype.Rows[0]["appAmount"].ToString());
                    creditappdays1 = Convert.ToInt32(dtprodtype.Rows[0]["appdays"].ToString());
                    if (txt_Quotation.Text != "")
                    {
                        if (dtu.Rows.Count > 0)
                        {
                            txt_creditgroupcus.Text = dtu.Rows[0]["groupname"].ToString() + " / App Days : " + creditappdays1 + " / App Amt : " + creditappamt1 + " / " + creditstatus;              
                            //txt_creditgroupcus.Text = dtu.Rows[0]["groupname"].ToString() + "/" + creditappdays1 + "/" + creditappamt1 + "/" + status1;
                        }
                    }
                }
                //end-------------
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        //
        private void Fn_Clear()
        {
            if (lbl_header.Text == "Booking #")
            {
                txt_bl.Text = "";
            }

            txt_agent.Text = "";
            txt_book.Text = "";
            txt_cargo.Text = "";
            txt_cfs.Text = "";
            txt_cha.Text = "";
            txt_consignee.Text = "";
            txt_date.Text = "";
            txt_destuff.Text = "";
            txt_dodate.Text = "";
            txt_doday.Text = "";
            txt_FD.Text = "";
            txt_feta.Text = "";
            txt_fetd.Text = "";
            txt_fpod.Text = "";
            txt_fpol.Text = "";
            txt_freight.Text = "";
            txt_hbl.Text = "";
            txt_issued.Text = "";
            txt_job.Text = "";
            txt_jobtype.Text = "";
            txt_kgs.Text = "";
            txt_line.Text = "";
            txt_mark.Text = "";
            txt_marketed.Text = "";
            txt_mbl.Text = "";
            txt_mblstatus.Text = "";
            txt_meta.Text = "";
            txt_metd.Text = "";
            txt_mlo.Text = "";
            txt_mpod.Text = "";
            txt_mpol.Text = "";
            txt_mvessel.Text = "";
            txt_notify.Text = "";
            txt_packages.Text = "";
            txt_POD.Text = "";
            txt_POL.Text = "";
            txt_POR.Text = "";
            txt_Quotation.Text = "";
            txt_remark.Text = "";
            txt_shipper.Text = "";
            txt_vessel.Text = "";
            txt_volume.Text = "";
            txt_voyage.Text = "";
            //lbl_cfs.Enabled = false;
            txt_cfs.Enabled = false;

            Grd_Invoice.DataSource = new DataTable();
            Grd_Invoice.DataBind();

            Grd_DN.DataSource = new DataTable();
            Grd_DN.DataBind();

            Grd_receipt.DataSource = new DataTable();
            Grd_receipt.DataBind();

            Grd_freightdetail.DataSource = new DataTable();
            Grd_freightdetail.DataBind();
            //lbl_cfs.Text = "";
            txt_cfs.Visible = false;
            lblCFS.Visible = false;
            btn_FBL.Visible = false;
            lnk_Creditdet.Visible = false;
            hid_CustomerId.Value = "";
        }

        private void FBL_Fn_Clear()
        {
            if (lbl_header.Text == "Booking #")
            {
                txt_bl.Text = "";
            }
            else
            {
                txt_bl.Text = "";
            }
            txt_agent.Text = "";
            txt_book.Text = "";
            txt_cargo.Text = "";
            //  txt_cfs.Text = "";
            txt_cha.Text = "";
            txt_consignee.Text = "";
            txt_date.Text = "";
            txt_destuff.Text = "";
            txt_dodate.Text = "";
            txt_doday.Text = "";
            txt_FD.Text = "";
            txt_feta.Text = "";
            txt_fetd.Text = "";
            txt_fpod.Text = "";
            txt_fpol.Text = "";
            txt_freight.Text = "";
            txt_hbl.Text = "";
            txt_issued.Text = "";
            txt_job.Text = "";
            txt_jobtype.Text = "";
            txt_kgs.Text = "";
            txt_line.Text = "";
            txt_mark.Text = "";
            txt_marketed.Text = "";
            txt_mbl.Text = "";
            txt_mblstatus.Text = "";
            txt_meta.Text = "";
            txt_metd.Text = "";
            txt_mlo.Text = "";
            txt_mpod.Text = "";
            txt_mpol.Text = "";
            txt_mvessel.Text = "";
            txt_notify.Text = "";
            txt_packages.Text = "";
            txt_POD.Text = "";
            txt_POL.Text = "";
            txt_POR.Text = "";
            txt_Quotation.Text = "";
            txt_remark.Text = "";
            txt_shipper.Text = "";
            txt_vessel.Text = "";
            txt_volume.Text = "";
            txt_voyage.Text = "";
            //lbl_cfs.Enabled = false;
            txt_cfs.Enabled = false;

            Grd_Invoice.DataSource = new DataTable();
            Grd_Invoice.DataBind();

            Grd_DN.DataSource = new DataTable();
            Grd_DN.DataBind();

            Grd_receipt.DataSource = new DataTable();
            Grd_receipt.DataBind();

            Grd_freightdetail.DataSource = new DataTable();
            Grd_freightdetail.DataBind();
            //lbl_cfs.Text = "";
            txt_cfs.Visible = false;
            lblCFS.Visible = false;
            btn_FBL.Visible = false;
            lnk_Creditdet.Visible = false;
            hid_CustomerId.Value = "";
        }

        protected void txt_book_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_book.Text.Trim().Length > 0)
                {
                    txt_bl.Text = txt_book.Text;
                    txt_bl_TextChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Invoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Boolean flag = false;
                string bltype = "", header = "";
                DateTime get_date, GST_date;
                get_date = Convert.ToDateTime((Grd_Invoice.SelectedRow.Cells[4].Text));
                GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
               // DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataTable obj_dt = new DataTable();
                DataTable obj_temp = new DataTable();

                obj_dt = obj_da_Invoice.RptIP(int.Parse(Grd_Invoice.SelectedRow.Cells[0].Text), Session["StrTranType"].ToString(), "Invoice", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Grd_Invoice.SelectedDataKey.Values[1].ToString()));
                if (obj_dt.Rows.Count > 0)
                {
                    obj_temp = obj_da_Invoice.CheckHblno(obj_dt.Rows[0].ItemArray[6].ToString(), Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
                    if (obj_temp.Rows.Count > 0)
                    {
                        flag = true;
                    }
                }
                if (Session["StrTranType"].ToString() == "FE")
                {
                    if (flag == true)
                    {
                        str_RptName = "FEInvoice.rpt";
                        bltype = "H";
                    }
                    else
                    {
                        str_RptName = "FEMInvoice.rpt";
                        bltype = "M";
                    }

                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    if (flag == true)
                    {
                        str_RptName = "FIInvoice.rpt";
                        bltype = "H";
                    }
                    else
                    {
                        str_RptName = "FIMInvoice.rpt";
                        bltype = "M";
                    }

                }
                if (str_RptName.Length > 0)
                {
                    //str_sf = "{InvoiceHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {InvoiceHead.invoiceno}=" + Grd_Invoice.SelectedRow.Cells[0].Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + Grd_Invoice.SelectedDataKey.Values[1].ToString();
                    //str_sp = "Lcurr=INR~container=" + hid_contno.Value.ToString();
                    //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //ScriptManager.RegisterStartupScript(Grd_Invoice, typeof(GridView), "BL  print", str_Script, true);

                    if (get_date >= GST_date)
                    {
                        //  str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + Grd_Invoice.SelectedDataKey.Values[1].ToString(); + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                        str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + Grd_Invoice.SelectedRow.Cells[0].Text + "&vouyear=" + Grd_Invoice.SelectedDataKey.Values[1].ToString() + "&total=" + Grd_Invoice.SelectedRow.Cells[2].Text + "&blno=" + txt_bl.Text + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Invoice, typeof(GridView), "BL  print", str_Script, true);
                    }
                    else
                    {
                        str_sf = "{InvoiceHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {InvoiceHead.invoiceno}=" + Grd_Invoice.SelectedRow.Cells[0].Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + Grd_Invoice.SelectedDataKey.Values[1].ToString();
                        str_sp = "Lcurr=INR~container=" + hid_contno.Value.ToString();
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Invoice, typeof(GridView), "BL  print", str_Script, true);
                    }
                }
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_DOsale_Click(object sender, EventArgs e)
        {
            try
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                str_RptName = "FIPDO4Sales.rpt";
                Session["str_sfs"] = "isnull({FIBLDetails.doissuedon})";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_DOsale, typeof(Button), "BL  print", str_Script, true);
                //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 119, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + "BLView");
                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 227, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + "BLView");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_DO_Click(object sender, EventArgs e)
        {
            try
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                str_RptName = "FIPDORegister.rpt";
                Session["str_sfs"] = "{FIBLDetails.bid}=" + Session["LoginBranchid"].ToString() + " and isnull({FIBLDetails.doissuedon})";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_DO, typeof(Button), "BL  print", str_Script, true);
               // DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 119, 3, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + "BLView");
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 227, 3, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + "BLView");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                DataTable obj_dt = new DataTable();

                DataAccess.ForwardingExports.BLPrinting obj_da_BL = new DataAccess.ForwardingExports.BLPrinting();
                //DataAccess.ForwardingImports.BLDetails obj_da_FIBL = new DataAccess.ForwardingImports.BLDetails();
                DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                //DataAccess.Corporate obj_da_Corporate = new DataAccess.Corporate();
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                string Ccode = Convert.ToString(Session["Ccode"]);
                obj_da_FEBL.GetDataBase(Ccode);
                obj_da_BL.GetDataBase(Ccode);

                string str_sp = "", str_sf = "", str_RptName = "", str_Script = "", str_CustomerName = "";
                string str_booking = "", strtrantype = "";
                int int_customeridDO = 0;
                if (str_booking != " 0" && strtrantype == "FE")
                {

                    str_booking = obj_da_FIBL.GetBookinkNo(txt_bl.Text, int_bid, int_divisionid);
                    hid_BookingNo.Value = str_booking;
                    obj_dt = obj_da_FEBL.GetBookingDt(str_booking, int_bid, int_divisionid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        int_customeridDO = int.Parse(obj_dt.Rows[0]["customerid"].ToString());
                        str_CustomerName = obj_da_Customer.GetCustomername(int_customeridDO);
                    }
                    if (int_customeridDO != 0)
                    {
                        if (obj_da_Corporate.GetGroupID(int_customeridDO, int_divisionid) != 0)
                        {
                            if (obj_da_Customer.CheckCreditException(txt_bl.Text, "FI", int_bid).Trim().Length > 0)
                            {
                                //newly added 21082022
                                //newly added on 21082022
                                int status = 0;
                                double creditappamt = 0.00;
                                int creditappdays = 0;
                                DataTable dtprod = new DataTable();
                                // need to check creditstatus
                                dtprod = obj_da_Customer.GetCreditAmount4product(int_customeridDO, int_divisionid, int_bid, "FI", txt_bl.Text);
                                if (dtprod.Rows.Count > 0)
                                {
                                    status = Convert.ToInt32(dtprod.Rows[0]["status"].ToString());
                                    creditappamt = Convert.ToDouble(dtprod.Rows[0]["appAmount"].ToString());
                                    creditappdays = Convert.ToInt32(dtprod.Rows[0]["appdays"].ToString());
                                }

                                if (status == 0)
                                {
                                    string str_ErrMsg = dtprod.Rows[0]["creditstatus"].ToString();
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + str_ErrMsg + "');", true);
                                    Btn_Print.Enabled = false;
                                    Btn_Print.ForeColor = System.Drawing.Color.Gray;
                                    CreatDetails(int_customeridDO);
                                    return;
                                }
                                else
                                {
                                    //end
                                    //if (obj_da_Customer.CheckCreditAmount(int_customeridDO, int_bid, int_divisionid) < 0)
                                    if (obj_da_Customer.CheckCreditAmount4product(int_customeridDO, int_bid, int_divisionid, "FI", txt_bl.Text) < 0)
                                    {
                                       // string str_Message = str_CustomerName + " has already reached the credit limit rupees " + obj_da_Customer.GetCreditAmount(int_customeridDO, int_divisionid) + " This Shipment has been blocked, Hence you cannot print Bill of Lading";
                                        string str_Message = str_CustomerName + " has already reached the credit limit rupees " + creditappamt + " This Shipment has been blocked, Hence you cannot print Bill of Lading";
                                       
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + str_Message + "');", true);
                                        str_RptName = "FEBL4PLDraft.rpt";
                                        str_sf = "{FEBLDetails.blno}=\"" + txt_bl.Text + "\" and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                                        str_sp = "location=" + Session["LoginBranchName"].ToString();
                                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                        ScriptManager.RegisterStartupScript(Btn_Print, typeof(Button), "BL  print", str_Script, true);

                                    }
                                    else
                                    {
                                        //if (obj_da_Customer.CheckCreditDays4Customer(int_customeridDO, int_divisionid) < 0)
                                        if (obj_da_Customer.CheckCreditDays4Customer4product(int_customeridDO, int_divisionid, int_bid, "FI", txt_bl.Text) < 0)
                                        {
                                            //if (obj_da_Customer.GetCreditAmount(int_customeridDO, int_divisionid) > obj_da_Customer.CheckCreditAmount(int_customeridDO, int_bid, int_divisionid))
                                            if (obj_da_Customer.GetCreditAmount(int_customeridDO, int_divisionid) > obj_da_Customer.CheckCreditAmount4product(int_customeridDO, int_bid, int_divisionid, "FI", txt_bl.Text))
                                            {
                                               // string str_Message = str_CustomerName + " has already reached the credit limit Rs. " + obj_da_Customer.GetCreditAmount(int_customeridDO, int_divisionid) + "/" + obj_da_Customer.GetCreditDays(int_customeridDO, int_divisionid) + " Days." + " This Shipment has been blocked, Hence you cannot print Bill of Lading";
                                                string str_Message = str_CustomerName + " has already reached the credit limit Rs. " + creditappamt + "/" + creditappdays + " Days." + " This Shipment has been blocked, Hence you cannot print Bill of Lading";
                                             
                                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + str_Message + "');", true);
                                                str_RptName = "FEBL4PLDraft.rpt";
                                                str_sf = "{FEBLDetails.blno}=\"" + txt_bl.Text + "\" and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                                                str_sp = "location=" + Session["LoginBranchName"].ToString();
                                                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                                ScriptManager.RegisterStartupScript(Btn_Print, typeof(Button), "BL  print", str_Script, true);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            obj_dt = obj_da_BL.GetBLPrintRcptDt(txt_bl.Text, int_bid);
                            if (obj_dt.Rows.Count == 0)
                            {
                                string str_Message = "We have not received the Payment for this shipment Please Check with Accounts Department";
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + str_Message + "');", true);
                                str_RptName = "FEBL4PLDraft.rpt";
                                str_sf = "{FEBLDetails.blno}=\"" + txt_bl.Text + "\" and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                                str_sp = "location=" + Session["LoginBranchName"].ToString();
                                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Btn_Print, typeof(Button), "BL  print", str_Script, true);

                            }
                        }
                    }
                }
                if (Btn_Print.Text == "Update")
                {
                    str_RptName = "";
                    if (txt_cha.Text.Trim().Length == 0)
                    {
                        ScriptManager.RegisterStartupScript(Btn_Print, typeof(Button), "BL  print", "alertify.alert('CNF Cannot Blank')", true);
                        return;
                    }
                    if (hid_cha.Value.ToString() == "0")
                    {
                        ScriptManager.RegisterStartupScript(Btn_Print, typeof(Button), "BL  print", "alertify.alert('Invalid CNF Name')", true);
                        return;
                    }
                    if (txt_hbl.Text =="NOT SURRENDERED")
                    {

                        ScriptManager.RegisterStartupScript(Btn_Print, typeof(Button), "BL  print", "alertify.alert('BL IS NOT SURRENDERED, SURRENDER THE BL')", true);
                        return;
                    }

                    obj_da_BL.UpdCNFFI(txt_bl.Text, int.Parse(hid_cha.Value.ToString()), int_bid, int.Parse(Session["LoginEmpId"].ToString()), int_divisionid);

                    int int_jobno = 0;
                    obj_dt = obj_da_BL.GetBLPrintingDt(txt_bl.Text, Session["StrTranType"].ToString(), int_bid, int_divisionid);
                    //string mailto = "";
                    //str_subject = "D/O issued intimation" + " // HBL No." + txt_bl.Text + " // Container No." + hid_contno.Value;
                    //string mailsub = str_subject;
                    //string adsf = canUpload1(txt_bl.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    //can_sendmail();
                    //Utility.SendMail(Session["usermailid"].ToString(), mailto, mailsub, sendqry, adsf, Session["usermailpwd"].ToString(), "", "");
                    if (obj_dt.Rows.Count > 0)
                    {
                        int_jobno = int.Parse(obj_dt.Rows[0]["jobtype"].ToString());
                    }

                    if (int_jobno == 3 || int_jobno == 2)
                    {
                        ////Elengo
                        //str_RptName = "";
                        //str_RptName = "fidofcl.rpt";

                        str_Script = "window.open('../Reportasp/deliveryorder.aspx?BLNO=" + txt_bl.Text + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    else
                    {
                        ////Elengo
                        //str_RptName = "fido.rpt";
                        str_Script = "window.open('../Reportasp/deliveryorder.aspx?BLNO=" + txt_bl.Text + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    ////Elengo
                    //str_sp = "head=" + hid_head.Value.ToString();
                    //str_sf = "{FIBLDetails.blno}=\"" + txt_bl.Text + "\" and {FIBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    ScriptManager.RegisterStartupScript(Btn_Print, typeof(Button), "BL  print", str_Script, true);
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;

                    // Important Have to UnCommand While Hosting 
                    obj_da_Corporate.UpdShipmentStatus(str_booking, "FI", int_bid, "D.O. Issued");
                    obj_da_Corporate.UpdateShipmentStatus(txt_bl.Text, "FI", int.Parse(hid_job.Value.ToString()), int_bid, "Delivery Order Issued");
                  //  Fn_SendDelivery();
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 119, 3, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + txt_bl.Text);
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 227, 3, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + txt_bl.Text);
                }
                else
                {
                    if (txt_bl.Text.Trim().Length > 0)
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            str_RptName = "FEBL4PL.rpt";
                            str_sf = "{FEBLDetails.blno}=\"" + txt_bl.Text + "\" and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            str_sp = "location=" + Session["LoginBranchName"].ToString();
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                            ScriptManager.RegisterStartupScript(Btn_Print, typeof(Button), "BL  print", str_Script, true);
                            //  obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 84, 4, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + txt_bl.Text);
                            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 227, 3, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + txt_bl.Text);
                        }
                        else
                        {
                            if (lbl_header.Text == "DODetails")
                            {
                                str_RptName = "";
                                int int_jobno = 0;
                                obj_dt = obj_da_BL.GetBLPrintingDt(txt_bl.Text, Session["StrTranType"].ToString(), int_bid, int_divisionid);
                                if (obj_dt.Rows.Count > 0)
                                {
                                    int_jobno = int.Parse(obj_dt.Rows[0]["jobtype"].ToString());
                                }
                                if (int_jobno == 3 || int_jobno == 2)
                                {
                                    ////Elengo
                                    //str_RptName = "";
                                    //str_RptName = "fidofcl.rpt";

                                    str_Script = "window.open('../Reportasp/deliveryorder.aspx?BLNO=" + txt_bl.Text + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    ////Elengo
                                    //str_RptName = "fido.rpt";
                                    str_Script = "window.open('../Reportasp/deliveryorder.aspx?BLNO=" + txt_bl.Text + "&" + this.Page.ClientQueryString + "','','');";
                                }

                                ////Elengo
                                //str_sf = "{FIBLDetails.blno}=\"" + txt_bl.Text + "\" and {FIBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //Session["str_sfs"] = str_sf;
                                //Session["str_sp"] = str_sp;

                                //Important Have to UnCommand While Hosting 
                                ScriptManager.RegisterStartupScript(Btn_Print, typeof(Button), "BL  print", str_Script, true);
                                obj_da_Corporate.UpdShipmentStatus(str_booking, "FI", int_bid, "D.O. Issued");
                                obj_da_Corporate.UpdateShipmentStatus(txt_bl.Text, "FI", int.Parse(hid_job.Value.ToString()), int_bid, "Delivery Order Issued");
                               // Fn_SendDelivery();
                                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 119, 3, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + txt_bl.Text);
                            }
                            else
                            {
                                //    str_RptName = "FEBL4PL.rpt";
                                //    str_sf = "{FEBLDetails.blno}=\"" + txt_bl.Text + "\" and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                                //    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //    Session["str_sfs"] = str_sf;
                                //    Session["str_sp"] = str_sp;
                                //    ScriptManager.RegisterStartupScript(Btn_Print, typeof(Button), "BL  print", str_Script, true);
                                //    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 119, 3, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + txt_bl.Text);
                                str_RptName = "FIBL4PL.rpt";
                                str_sf = "{FIBLDetails.blno}=\"" + txt_bl.Text + "\" and {FIBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                                //str_sp = "location=" + "";
                                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(Btn_Print, typeof(Button), "BL  print", str_Script, true);
                                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 119, 3, int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + txt_bl.Text);

                            }
                        }
                    }
                }
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                var JSONString = new StringBuilder();
                dt2 = da_obj_FIJobobj.amass_json(int.Parse(hid_job.Value.ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());

                if (dt2.Rows.Count > 0)
                {
                    string agentname = "";
                    agentname = dt2.Rows[0]["customername"].ToString();
                    dt1 = da_obj_FIJobobj.GetBL_Test(txt_bl.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dt1.Rows.Count > 0)
                    {
                        JSONString.Append("[");
                        JSONString.Append("{");
                        for (int k = 0; k < dt1.Rows.Count; k++)
                        {
                            for (int r = 0; r < dt1.Columns.Count; r++)
                            {
                                if (r == dt1.Columns.Count - 1)
                                {
                                    JSONString.Append("\"" + dt1.Columns[r].ColumnName.ToString() + "\":" + "\"" + dt1.Rows[k][r].ToString() + "\"");
                                }
                                else
                                {
                                    JSONString.Append("\"" + dt1.Columns[r].ColumnName.ToString() + "\":" + "\"" + dt1.Rows[k][r].ToString() + "\",");
                                }

                            }
                            if (k == dt1.Rows.Count - 1)
                            {
                                JSONString.Append("}");
                            }
                            else
                            {
                                JSONString.Append("}");
                            }
                        }

                        JSONString.Append("]");
                    }
                    string filename;
                    string jsone = JSONString.ToString();
                    byte[] byteArray = Encoding.ASCII.GetBytes(jsone);
                    filename = "AMASS_JSON" + "-" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
                    string attachment = "AMASS_JSON_DO_" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now) + ".json";
                    string pathxml = Server.MapPath("~/UploadFTP/" + attachment);
                    string jsone1 = Path.GetFileName(pathxml);
                    //string path = @"C:/inetpub/ftproot/MHCVS/test/xmluploadtest/" + attachment;
                    File.WriteAllBytes(pathxml, byteArray);
                    //File.WriteAllBytes(path, byteArray);

                    UploadFileToFTP(jsone1, pathxml);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "logix", "alertify.alert('EDI File Uploaded into " + agentname + "');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void UploadFileToFTP(string source, string path)
        {
            try
            {
                string Ccode = Convert.ToString(Session["Ccode"]);
                string DBName = "Demo";
                if (Ccode == "CH01")
                {
                    DBName = "SL";
                    using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                    {
                        DBCS = reader.ReadLine();
                    }
                }
                else if (Ccode == "CH02")
                {
                    DBName = "MarinAir";
                    using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                    {
                        DBCS = reader.ReadLine();
                    }
                }
                if (Ccode == "CH03")
                {
                    DBName = "OceanKare";
                    using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                    {
                        DBCS = reader.ReadLine();
                    }
                }

                ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
                dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
                username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
                password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();

                String sourcefilepath = source; // e.g. "d:/test.docx"
                String ftpurl = "ftp://DXBA00051@psus.amassfreight.com:52032/inbound/STA/" + sourcefilepath; // e.g. ftp://serverip/foldername/foldername
                //   string ftpurl = "ftp://20.235.30.214/test/EDIMAGIK/" + sourcefilepath ;
                String ftpusername = username;//"ifrtAdmin"; // e.g. username
                String ftppassword = password; //"05Jun!(&%"; // e.g. password
                string filename = Path.GetFileName(source);
                string ftpfullpath = ftpurl;
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                ftp.Credentials = new NetworkCredential("DXBA00051", "pgu#2^hhm8");
                //    ftp.Credentials = new NetworkCredential(Hf_ServerUsername.Value, Hf_ServerPwd.Value);
                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                FileStream fs = File.OpenRead(path); //File.OpenRead(source);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();
                Stream ftpstream = ftp.GetRequestStream();
                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();

                //// get file bytes
                //byte[] fileBytes = File.ReadAllBytes(source);
                //ftp.ContentLength = fileBytes.Length;

                //Stream ftpstream = ftp.GetRequestStream();
                //ftpstream.Write(fileBytes, 0, fileBytes.Length);
                //ftpstream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Fn_SendDelivery()
        {
            try
            {
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                DataTable obj_dt = new DataTable();
                DataAccess.ForwardingExports.JobInfo obj_da_Job = new DataAccess.ForwardingExports.JobInfo();
                DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                DataAccess.ForwardingImports.BLDetails obj_da_FIBL = new DataAccess.ForwardingImports.BLDetails();
                DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                string Ccode = Convert.ToString(Session["Ccode"]);
                obj_da_Job.GetDataBase(Ccode);
                obj_da_Invoice.GetDataBase(Ccode);
                obj_da_FEBL.GetDataBase(Ccode);
                obj_da_FIBL.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                string Str_Temp = "", str_Shipper = "", str_Consignee = "", str_Pol = "", str_Pod = "", str_City = "", str_Mbl = "", str_Shipperaddress = "", str_Ptc = "", str_Empmail = "", str_Custmail = "";
                int int_Agentid = 0;
                obj_dt = obj_da_Log.GetCompanyNameAdd(int_bid);
                if (obj_dt.Rows.Count > 0)
                {
                    Str_Temp = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + obj_dt.Rows[0].ItemArray[0].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + obj_dt.Rows[0].ItemArray[1].ToString() + " <br> Phone : " + obj_dt.Rows[0].ItemArray[2].ToString() + " Fax : " + obj_dt.Rows[0].ItemArray[3].ToString() + "</Font></center><HR width=100%></body>";
                }

                obj_dt = obj_da_Invoice.GetHblInvoiceHead(txt_bl.Text, "FI", int_bid);
                if (obj_dt.Rows.Count > 0)
                {
                    str_Shipper = obj_dt.Rows[0].ItemArray[4].ToString();
                    str_Consignee = obj_dt.Rows[0].ItemArray[5].ToString();
                    str_Pod = obj_dt.Rows[0].ItemArray[7].ToString();
                    str_Pol = obj_dt.Rows[0].ItemArray[12].ToString();
                    str_Mbl = obj_dt.Rows[0].ItemArray[13].ToString();
                    int_Agentid = int.Parse(obj_dt.Rows[0].ItemArray[9].ToString());
                }
                str_City = obj_da_Customer.GetCustlocation(int_Agentid);

                obj_dt = obj_da_Customer.RetrieveCustomerDetails(txt_agent.Text, "Agent / Principal", str_City);
                if (obj_dt.Rows.Count > 0)
                {
                    str_Ptc = obj_dt.Rows[0]["ptc"].ToString();
                }

                str_Shipperaddress = obj_da_Customer.GetCustomerAddress(txt_agent.Text, "Agent / Principal", str_City);
                Str_Temp = Str_Temp + "<body text=black><table width=100%><FONT FACE=tahoma ><tr><td align=left>To</td></tr><br>";
                Str_Temp = Str_Temp + "<tr><td align=left>" + txt_agent.Text + "</td></tr>";
                Str_Temp = Str_Temp + "<tr><td align=left>" + str_Shipperaddress + "</td></tr>";
                Str_Temp = Str_Temp + "<tr><td align=left>" + str_City + "</td></tr></br></table><br><br>";
                if (str_Ptc == "")
                {
                    Str_Temp = Str_Temp + "<table><tr><td align=left>Dear Sir / Madam</td></tr>";
                }
                else
                {
                    Str_Temp = Str_Temp + "<table><tr><td align=left>Dear " + str_Ptc + "</td></tr>";
                }
                Str_Temp = Str_Temp + "<tr><td align=left>MBL #          : " + str_Mbl + "</td></tr><br>";
                Str_Temp = Str_Temp + "<tr><td align=left>Loaded At      : " + str_Pol + "</td></tr><br>";
                Str_Temp = Str_Temp + "<tr><td align=left>Discharged Per : " + str_Pod + "</td></tr><br>";
                Str_Temp = Str_Temp + "<tr><td align=left>Arrived On     : " + txt_feta.Text + "</td></tr><br>";
                Str_Temp = Str_Temp + "<tr><td align=left>H B/L #        : " + txt_bl.Text + "</td></tr><br>";
                Str_Temp = Str_Temp + "<tr><td align=left>Shipper        : " + str_Shipper + "</td></tr><br>";
                Str_Temp = Str_Temp + "<tr><td align=left>Consignee      : " + str_Consignee + "</td></tr></table><br>";
                Str_Temp = Str_Temp + "<table border=1><tr><td align=center>Container # </td><td align=center>Sizetype</td><td align=center>Seal #</td></tr><br>";
                obj_dt = obj_da_FIBL.GetContainerDetail(int.Parse(hid_job.Value.ToString()), txt_bl.Text, int_bid, int_divisionid);
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    Str_Temp = Str_Temp + "<tr><td align=left>" + obj_dt.Rows[i].ItemArray[0].ToString() + "</td><td align=left>" + obj_dt.Rows[i].ItemArray[1].ToString() + "</td><td align=left>" + obj_dt.Rows[i].ItemArray[2].ToString() + "</td></tr><br>";
                }
                Str_Temp = Str_Temp + "</table><br>";
                Str_Temp = Str_Temp + "<table><tr><td align=left>Please be informed that we have issued  the Deliver Order to the consignee on doissuedon  after collecting the above ORGINAL/COPY BL.</td></tr></table><br><br>";
                Str_Temp = Str_Temp + "</table><table width=100% text=black><tr><td align=left>Thanks + Regards </td></tr></table><br><br><br>";
                Str_Temp = Str_Temp + "<table width=100% text=black><tr><td align=left>" + Session["LoginEmpName"].ToString() + " </td></tr></table></body></html>";

                DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                DataAccess.UserPermission obj_da_user = new DataAccess.UserPermission();


                 Ccode = Convert.ToString(Session["Ccode"]);
                obj_da_Emp.GetDataBase(Ccode);
                obj_da_user.GetDataBase(Ccode);

                obj_dt = obj_da_user.GetMLEmpid(obj_da_user.GetMLUiid("FI", "D.O.Issue"), int_bid);
                str_Custmail = obj_da_Customer.GetCusMailaddrs(int_Agentid);
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    str_Empmail = str_Empmail + obj_da_Emp.GetMailAdd(int.Parse(obj_dt.Rows[i].ItemArray[0].ToString())) + ";";
                }
                if (hid_nomination.Value == "F")
                {
                    if ((str_Empmail.Trim().Length > 0) && (str_Custmail.Trim().Length > 0))
                    {
                        str_Empmail = str_Empmail.Substring(0, str_Empmail.Length - 1);

                        Utility.SendMail(Session["usermailid"].ToString(), str_Custmail, "Delivery Status", Str_Temp, "", Session["usermailpwd"].ToString(), "", "HEMAKUMAR.MUNAIAH@SCM.CO.IN" + ";" + Session["usermailid"].ToString() + ";" + str_Empmail.ToString());
                        // Utility.SendMail(Session["usermailid"].ToString(), "muthuraj@ltsolutions.co.in", "Delivery Status", Str_Temp, "", Session["usermailpwd"].ToString(), "", "priya@ltsolutions.co.in");

                    }

                    else if ((str_Empmail.Trim().Length > 0))
                    {
                        str_Empmail = str_Empmail.Substring(0, str_Empmail.Length - 1);

                        Utility.SendMail(Session["usermailid"].ToString(), str_Empmail, "Delivery Status", Str_Temp, "", Session["usermailpwd"].ToString(), "", "HEMAKUMAR.MUNAIAH@SCM.CO.IN" + ";" + Session["usermailid"].ToString());
                        //Utility.SendMail(Session["usermailid"].ToString(), "muthuraj@ltsolutions.co.in", "Delivery Status", Str_Temp, "", Session["usermailpwd"].ToString(), "", "priya@ltsolutions.co.in");

                    }

                    else if (str_Custmail.Trim().Length > 0)
                    {

                        str_Custmail = str_Custmail.Replace(";", "");
                        Utility.SendMail(Session["usermailid"].ToString(), str_Custmail, "Delivery Status", Str_Temp, "", Session["usermailpwd"].ToString(), "", "HEMAKUMAR.MUNAIAH@SCM.CO.IN" + ";" + Session["usermailid"].ToString());
                        // Utility.SendMail(Session["usermailid"].ToString(),"nambi@ltsolutions.co.in", "Delivery Status", Str_Temp, "", Session["usermailpwd"].ToString());

                        // Utility.SendMail(Session["usermailid"].ToString(), "muthuraj@ltsolutions.co.in", "Delivery Status", Str_Temp, "", Session["usermailpwd"].ToString(), "", "priya@ltsolutions.co.in");

                    }
                }
                else if (hid_nomination.Value == "N")
                {
                    if ((str_Empmail.Trim().Length > 0))
                    {
                        str_Empmail = str_Empmail.Substring(0, str_Empmail.Length - 1);

                        Utility.SendMail(Session["usermailid"].ToString(), str_Empmail, "Delivery Status", Str_Temp, "", Session["usermailpwd"].ToString(), "", "HEMAKUMAR.MUNAIAH@SCM.CO.IN" + ";" + Session["usermailid"].ToString());
                        //   Utility.SendMail(Session["usermailid"].ToString(), "priya@ltsolutions.co.in", "Delivery Status", Str_Temp, "", Session["usermailpwd"].ToString(), "", "muthuraj@ltsolutions.co.in");

                    }
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void btn_FBL_Click(object sender, EventArgs e)
        {
            try
            {
                FBL_Fn_Clear();
                txt_bl.Text = txt_cfs.Text;
                if (hid_split.Value.ToString().Length > 0)
                {
                    hid_BL.Value = "true";
                }
                txt_bl.Focus();
                hid_split.Value = "";
                txt_bl_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_book_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_book.Text != "")
                {
                    if (txt_bl.Text.Trim().Length <= 0)
                    {
                        ScriptManager.RegisterStartupScript(lnk_bl, typeof(LinkButton), "BL_print", "alertify.alert('Booking Not Available');", true);
                        return;
                    }

                    else
                    {
                        Session["sess"] = 1;
                        //iframeBook.Attributes["src"] = "../Sales/Booking.aspx?BookingNo=" + txt_book.Text;
                        //iframeBook.Attributes["src"] = "../ForwardExpert/Booking.aspx" + txt_book.Text;
                        //ModalPopupExtender1.Show();
                        //Response.Redirect("../Sales/Booking.aspx?BookingNo=" + txt_book.Text);
                        Response.Redirect("../Sales/Booking.aspx?BookingNo=" + txt_book.Text);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(lnk_bl, typeof(LinkButton), "BL_print", "alertify.alert('Booking Not Available');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_Quotation_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Quotation.Text.Trim().Length > 0)
                {
                    Session["sess"] = 2;
                    //iframeBook.Attributes["src"] = "../Sales/Quotation.aspx";
                    // ModalPopupExtender1.Show();
                    //string quo = "Quotation";
                    //Session["Quotation"] = "Quotation";
                    Response.Redirect("../Sales/Quotation.aspx?Quotation=" + txt_Quotation.Text);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(lnk_Quotation, typeof(LinkButton), "BL_print", "alertify.alert('Quotation Not Available');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            if (Request.QueryString.ToString().Contains("blba"))
            {
                string trantype_process = Session["StrTranType"].ToString();
                DataTable dtuser = new DataTable();
               // DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                
                    dtuser = obj_UP.GetFormwiseuserRights(1014, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                    if (dtuser.Rows.Count > 0)
                    {


                        Response.Redirect("../FI/FIBL.aspx");


                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                    }

                
            }
            if (Btn_cancel.Text == "Cancel")
            {
                txt_bl.Text = "";
                chk_container.Items.Clear();
                Fn_Clear();
                Btn_cancel.Text = "Back";
                Session["blno"] = null;
                flagimg.ImageUrl = "";
                porflag.ImageUrl = "";
                podflag.ImageUrl = "";
                fdflag.ImageUrl = "";
                fpolflag.ImageUrl = "";
                fpodflag.ImageUrl = "";
                mpodflag.ImageUrl = "";
                mpolflag.ImageUrl = "";
            }
            else
            {
                this.Response.End();
            }
        }

        protected void lnk_back_Click(object sender, EventArgs e)
        {
            try
            {
                string type;
                if (Session["blnofife"] != null)
                {
                    type = Session["type"].ToString();
                    Session["type"] = null;
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        Response.Redirect("../ShipmentDetails/FEBLdetails.aspx?type=" + type + "", false);
                        return;
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        Response.Redirect("../FI/FIBL.aspx?type=" + type + "", false);
                        return;
                    }
                    //if (type == "Amendment BLDetails")
                    //{
                    //    Response.Redirect("/FI/FIBL.aspx?type=" + type + "");
                    //    return;
                    //}
                    //else if (type == "Direct BL")
                    //{
                    //    Response.Redirect("/FI/FIBL.aspx?type=" + type + "");
                    //    return;
                    //}
                    //else if (type == "Forwarder BL")
                    //{
                    //    Response.Redirect("/FI/FIBL.aspx?type=" + type + "");
                    //    return;
                    //}
                    //else if (type == "Split BL")
                    //{
                    //    Response.Redirect("/FI/FIBL.aspx?type=" + type + "");
                    //    return;
                    //}
                    //else if (type == "Split BL")
                    //{

                    //    Response.Redirect("/FI/FIBL.aspx?type=" + type + "");
                    //    return;
                    //}
                }
                if (Session["Queries"] != null)
                {
                    string type1 = Session["Queries"].ToString();
                    Session["Queries"] = null;
                    Session["Queriesnew"] = type1;

                    if (type1 == "Queries")
                    {
                        Response.Redirect("../ForwardExports/Query.aspx?type=" + type1 + "", false);
                        return;
                    }
                    else if (type1 == "Query")
                    {
                        Response.Redirect("../ForwardExports/Query.aspx?type=" + type1 + "", false);
                        return;
                    }
                }

                else if (Session["Query"] != null)
                {
                    type = Session["Query"].ToString();
                    Session["Query"] = null;
                    Session["Querynew"] = type;
                    if (type == "Query")
                    {
                        Response.Redirect("../AE/SalesQuery.aspx?type=" + type + "", false);
                        return;
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_new_pending_Click(object sender, EventArgs e)
        {
            try
            {

             //   DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();

                FIBLobj.GetDOIssue(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]));

                str_RptName = "DOIssue.rpt";

                Session["str_sfs"] = "{tempdoissue.branchid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {tempdoissue.empid}=" + Convert.ToInt32(Session["LoginEmpId"].ToString()) + " and {tempdoissue.freehand}='F'";

                Session["str_sp"] = "";

                str_RptName1 = "DOIssue.rpt";

                Session["str_sfs1"] = "{tempdoissue.branchid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {tempdoissue.empid}=" + Convert.ToInt32(Session["LoginEmpId"].ToString()) + " and {tempdoissue.freehand}='N'";

                Session["str_sp1"] = "";

                str_Script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_new_pending, typeof(Button), "logix", str_Script1, true);

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void btn_excel_Click(object sender, EventArgs e)
        {
            DataTable dts;
            //  string Str_FileName = "";
            // Str_FileName = "Pending DO";

          //  DataAccess.CostingDetails objcos = new DataAccess.CostingDetails();
            dts = objcos.SP_PENDINGDO(Convert.ToInt32(Session["LoginBranchid"].ToString()));

            //if (dts.Rows.Count > 0)
            //{
            //    string strtemp;

            //    strtemp = Utility.Fn_ExportExcel_Datatable(dts, "<tr><td><td><td></td><td><FONT FACE=arial SIZE=2>" + Str_FileName + "</td></tr>");
            //    Response.Clear();
            //    Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Str_FileName + ".xls");
            //    Response.Buffer = true;
            //    Response.Charset = "UTF-8";
            //    Response.ContentType = "application/vnd.ms-excel";
            //    Response.Write(strtemp);
            //    Response.End();
            //}

            // string Str_Title;
            // Str_Title = Session["LoginDivisionName"].ToString() + "-" + Session["LoginBranchName"].ToString();
            string Str_FileName;

            StringBuilder SB = new StringBuilder();
            StringWriter StringWriter = new System.IO.StringWriter(SB);
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
            Str_FileName = "PendingDO";

            if (dts.Rows.Count > 0)
            {
                Grid_BPRpt.DataSource = dts;
                Grid_BPRpt.DataBind();
                // Grid_BPRpt.Visible = false;
            }

            if (Grid_BPRpt.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";
                string FileName = "PendingDO" + DateTime.Now + ".xls";
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                Grid_BPRpt.GridLines = GridLines.Both;
                Grid_BPRpt.HeaderStyle.Font.Bold = true;
                Grid_BPRpt.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                Response.End();
            }

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 227, "DOISSUE", txt_bl.Text, txt_bl.Text, "");  //"/Rate ID: " +
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
        //Elengo
        public void CreatDetails(int Customerid)
        {
            hid_CustomerId.Value = Customerid.ToString();
            lnk_Creditdet.Visible = true;
        }

        protected void lnk_Creditdet_Click(object sender, EventArgs e)
        {
            try
            {
                this.PopCreditdet.Show();
                CustomerLbl1.InnerText = hid_customer.Value;
                grdCridtDet.DataSource = new DataTable();
                grdCridtDet.DataBind();
              //  DataAccess.CreditException Crexobj = new DataAccess.CreditException();
                DataTable dtinv = Crexobj.GetCustInvOut(Convert.ToInt32(hid_CustomerId.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (dtinv.Rows.Count > 0)
                {
                    DataTable dtt = new DataTable();
                    DataRow dr;
                    dtt.Columns.Add("shortname");
                    dtt.Columns.Add("customername");
                    dtt.Columns.Add("invoiceno");
                    dtt.Columns.Add("invdate");
                    dtt.Columns.Add("days");
                    dtt.Columns.Add("osamount", typeof(Double));
                    dtt.Columns.Add("branchid");

                    for (int i = 0; i <= (dtinv.Rows.Count - 1); i++)
                    {
                        int invouno = Convert.ToInt32(dtinv.Rows[i]["vouno"].ToString());
                        DateTime invoudate = Convert.ToDateTime(dtinv.Rows[i]["voudate"].ToString());
                        int invodays = Convert.ToInt32(dtinv.Rows[i]["noofdays"].ToString());
                        string voutype = dtinv.Rows[i]["voutype"].ToString();
                        double invamount = Convert.ToDouble(dtinv.Rows[i]["osamount"].ToString());

                        dr = dtt.NewRow();
                        dr["shortname"] = dtinv.Rows[i]["shortname"].ToString();
                        dr["customername"] = dtinv.Rows[i]["customername"].ToString();
                        dr["invoiceno"] = voutype + " - " + invouno;
                        dr["invdate"] = invoudate.ToShortDateString();
                        dr["days"] = invodays.ToString();
                        dr["osamount"] = Math.Round(invamount, 2).ToString("#0.00");
                        dr["branchid"] = dtinv.Rows[i]["branchid"].ToString();
                        dtt.Rows.Add(dr);
                    }
                    //Total
                    DataRow dr1 = dtt.NewRow();
                    dr1[4] = "Total";
                    dr1[5] = dtt.Compute("Sum(osamount)", "");
                    dtt.Rows.Add(dr1);
                    DataView Dtview = dtt.DefaultView;
                    ////Branchwise filtering
                    //dt_check.RowFilter = "branchid = " + Convert.ToInt32(Session["LoginBranchid"]);
                    DataTable dtbrafil = Dtview.ToTable();
                    grdCridtDet.DataSource = dtbrafil;
                    grdCridtDet.DataBind();
                    grdCridtDet.Rows[grdCridtDet.Rows.Count - 1].Font.Bold = true;
                }
                else
                {
                    grdCridtDet.DataSource = new DataTable();
                    grdCridtDet.DataBind();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdCridtDet_RowDataBound(object sender, GridViewRowEventArgs e)
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
                        if (i == 5)
                        {
                            //double dbl_temp = 0;
                            //if (double.TryParse(e.Row.Cells[i].Text.ToString(), out dbl_temp))
                            //{
                            //    e.Row.Cells[i].Text = string.Format("{0:#,##0.00}", dbl_temp);
                            //    e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                            //}
                            double dbl_temp = Convert.ToDouble(e.Row.Cells[i].Text);
                            e.Row.Cells[i].Text = dbl_temp.ToString("#0.00");
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

        protected void grdCridtDet_PreRender(object sender, EventArgs e)
        {
            if (grdCridtDet.Rows.Count > 0)
            {
                grdCridtDet.UseAccessibleHeader = true;
                grdCridtDet.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        public void can_sendmail(string bl)
        {

          //  DataAccess.Accounts.Approval appobj = new DataAccess.Accounts.Approval();
            DataTable dt = new DataTable();
            dt = appobj.mail_hblno1(txt_bl.Text, Convert.ToInt32(hid_job.Value), Convert.ToInt32(Session["LoginBranchid"]));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (dt.Rows[i]["blno"].ToString() == bl)
                    {
                        sendqry = sendqry + Session["Companyaddress"].ToString();
                        sendqry = sendqry + "<table border=1 width=100% text=blue><tr><td align=center><FONT FACE=Arial SIZE=3 COLOR=Grey><B> D/O Issued Information </B></FONT></td></tr><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Dear Sir/Madam,</FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>We are pleased to inform you that below mentioned Shipment Delivery Order issued on " + txt_dodate.Text + ".</FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>BL #: " + dt.Rows[i]["blno"].ToString() + " </FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Line #: " + dt.Rows[i]["linenumber"].ToString() + " " + " Subline #: " + dt.Rows[i]["sublineno"].ToString() + " </FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Vessel: " + dt.Rows[i]["vesselname"].ToString() + " " + dt.Rows[i]["voyage"].ToString() + " </FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>ETA: " + dt.Rows[i]["eta"].ToString() + "</FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>POL/POD: " + dt.Rows[i]["pol"].ToString() + " / " + dt.Rows[i]["pod"].ToString() + " </FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>MBL: " + dt.Rows[i]["mblno"].ToString() + " " + " Dt: " + dt.Rows[i]["mbldate"].ToString() + " </FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Container #: " + dt.Rows[i]["containerno"].ToString() + " / " + dt.Rows[i]["sizetype"].ToString() + "</FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>IGM #: " + dt.Rows[i]["igmno"].ToString() + " " + " Dt: " + dt.Rows[i]["igmdate"].ToString() + "</FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>We look forward to your continued support and assuring you our prompt services at all times.</FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Thank you for your best support.</FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Thanks & Regards,</FONT></td></tr></table><br>";
                        //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>BL #: " + dt.Rows[i]["blno"].ToString() + " </FONT></td></tr></table><br>";
                        //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Vessel: " + dt.Rows[i]["vesselname"].ToString() + " " + dt.Rows[i]["voyage"].ToString() + " </FONT></td></tr></table><br>";
                        //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>ETA: " + dt.Rows[i]["eta"].ToString() + "</FONT></td></tr></table><br>";
                        //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>POL/POD: " + dt.Rows[i]["pol"].ToString() + " / " + dt.Rows[i]["pod"].ToString() + " </FONT></td></tr></table><br>";
                        //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>MBL: " + dt.Rows[i]["mblno"].ToString() + " Dt: " + dt.Rows[i]["mbldate"].ToString() + " </FONT></td></tr></table><br>";
                        //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Container #: " + dt.Rows[i]["containerno"].ToString() + "</FONT></td></tr></table><br>";
                        //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>IGM #: " + dt.Rows[i]["igmno"].ToString() + " Dt: " + dt.Rows[i]["igmdate"].ToString() + "</FONT></td></tr></table><br>";
                        //sendqry = sendqry & "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Job # : " & txt_job.Text & "</FONT></td><td></td><td></td><td></td><td align=left><FONT FACE=Tahoma SIZE=2>Booking # : " & txt_book.Text & "</FONT></td></tr></table>"
                        //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Job # :" + txt_jobno.Text + "</FONT></td></tr>";
                        //sendqry = sendqry + "<tr><td align=left><FONT FACE=Tahoma SIZE=2>Booking # : " + txt_book.Text + "</FONT></td></tr></table>";
                    }     //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>POR : " + por + "</FONT></td><td align=left><FONT FACE=Tahoma SIZE=2>POL : " + pol + "</FONT></td><td align=left><FONT FACE=Tahoma SIZE=2>POD : " + pod + "</FONT></td><td align=left><FONT FACE=Tahoma SIZE=2>FD : " + fd + "</FONT></td></tr></table><br>";
                }
            }

        }

        public string canUpload1(string blno, int bid)
        {
            try
            { // bool retValue = false;
                Filename = "";
                Filename = Filename + "HBL" + "_" + txt_bl.Text + ".PDF";
                //hid_pdffile.Value = Filename;
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition", "attachment;filename=" + Session["Filename"].ToString() + ".PDF");
                string htmlUrl;

                int bid1 = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string username = Session["LoginUserName"].ToString();
                int cid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                //int bid1 = Convert.ToInt32(Session["LoginBranchid"].ToString());
                //if (hid_type.Value=="OSSI")
                //{
                //  htmlUrl = "http://localhost:52635/Reportasp/Invoicerpt1.aspx?Invoiceno=" + int_Refno.ToString() + "&vouyear=" + int_Vouyear.ToString() + "&total=" + total + "&trantype=" + "LT" + "&customerid=" + hid_SupplytoId.Value + "&blno=" + blno + "&bltype=" + "H" + "&header=" + "Invoice" + "&ltinvoice=" + "LTinvoice" + "&Profoma=" + "Profoma" + "&LoginDivisionId=" + Session["LoginDivisionId"].ToString() + "&LoginDivisionName=" + Session["LoginDivisionName"].ToString() + "&LoginBranchid=" + Session["LoginBranchid"].ToString() + "&FADbname=" + Session["FADbname"].ToString();

                // htmlUrl = "http://localhost:52635/Reportasp/Invoicerpt1.aspx?Invoiceno=" + int_Refno.ToString() + "&vouyear=" + int_Vouyear.ToString() + "&total=" + total + "&trantype=" + "LT" + "&customerid=" + hid_SupplytoId.Value + "&blno=" + blno + "&bltype=" + "H" + "&header=" + "Invoice" + "&ltinvoice=" + "LTinvoice" + "&Profoma=" + "" + "&LoginDivisionId=" + Session["LoginDivisionId"].ToString() + "&LoginDivisionName=" + Session["LoginDivisionName"].ToString() + "&LoginBranchid=" + Session["LoginBranchid"].ToString() + "&FADbname=" + Session["FADbname"].ToString();

                //    htmlUrl = "'https://localhost:52666/Reportasp/BL4CANrpt.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString();
                //       htmlUrl = "'http://localhost:52666/Reportasp/BL4CANrpt.aspx?jobno=+txt_jobno.Text.ToString()+&Blno=+hf_BL.Value+&Bid=+bid1+&cid=+cid1+&type=C&TOtype=consignee";
               htmlUrl = "'"+ Session["Site"].ToString() + "/Reportasp/deliveryorder.aspx?BLNO=" + txt_bl.Text.ToString() + "&bid1=" + bid1 + "&username=" + username + "&cid=" + cid + "&type=" + "D.O.+Issue";
          //      htmlUrl = "'https://localhost:52638/Reportasp/deliveryorder.aspx?BLNO=" + txt_bl.Text.ToString() + "&bid1=" + bid1 + "&username=" + username + "&cid=" + cid + "&type=" + "D.O.+Issue";
                //    htmlUrl = "'"+ Session["Site"].ToString() + "/Reportasp/Invoicerpt1.aspx?Invoiceno=" + int_Refno.ToString() + "&vouyear=" + int_Vouyear.ToString() + "&total=" + total + "&trantype=" + "LT" + "&customerid=" + hid_SupplytoId.Value + "&blno=" + blno + "&bltype=" + "H" + "&header=" + "Invoice" + "&ltinvoice=" + "LTinvoice" + "&Profoma=" + "" + "&LoginDivisionId=" + Session["LoginDivisionId"].ToString() + "&LoginDivisionName=" + Session["LoginDivisionName"].ToString() + "&LoginBranchid=" + Session["LoginBranchid"].ToString() + "&FADbname=" + Session["FADbname"].ToString();

                //  htmlUrl = "http://localhost:52633/Reportasp/invoicerpt1.aspx?refno=" + int_Refno + "&vouyear=" + int_Vouyear + "&tran=" + "LT" + "&jobno=" + "0" + "&bltype=" + "H" + "&LoginBranchid=" + "66" + "&Basecurr=" + Session["Basecurr"] + "&LoginDivisionName=" + Session["LoginDivisionName"].ToString() + "&StrTranType=" + "LT" + "&LoginDivisionId=" + Session["LoginDivisionId"].ToString();

                //htmlUrl = "http://localhost:52633/Reportasp/ProformaOverseaDebiCrediEDI.aspx?refno=" + Session["vouno"] + "&vouyear=" + Session["vouyear"] +"&tran"+hid_tran.Value+ "&bltype=" + Session["hid_type"] + "&LoginBranchid=" + Session["branch"];
                //htmlUrl = "'"+ Session["Site"].ToString() + "/Reportasp/ProformaOverseaDebiCrediEDI.aspx?refno=" + Grdcost.Rows[index].Cells[1].Text + "&vouyear=" + Grdcost.DataKeys[index].Values[0].ToString() + "&tran=" + hid_tran.Value + "&jobno=" + txt_job.Text + "&bltype=" + hid_type.Value + "&LoginBranchid=" + Convert.ToInt32(Session["LoginBranchid"]) + "&Basecurr=" + Session["Basecurr"] + "&LoginDivisionName=" + Session["LoginDivisionName"].ToString() + "&StrTranType=" + Session["StrTranType"].ToString() + "&LoginDivisionId=" + Session["LoginDivisionId"].ToString();
                // htmlUrl= '"+ Session["Site"].ToString() + "/Reportasp/ProformaOverseaDebiCredi.aspx?refno=86&vouyear=2018&tran=FE&jobno=15262&bltype=OSDN&type=OS+DN%2fCN&uiid=40;

                var pdfBytes = htmlToPdf.GeneratePdfFromFile(htmlUrl, null);

                ftpFullPath = Server.MapPath("~/SavePDF/");
                ftpFullPath = ftpFullPath + Filename;
                File.WriteAllBytes(ftpFullPath, pdfBytes);

                //Response.Clear();
                //  MemoryStream ms = new MemoryStream(pdfBytes);

                //  Response.Buffer = true;
                // ms.WriteTo(Response.OutputStream);

                //  ftpFullPath = ftpURL + "/" + Filename.ToString();

                //if (Directory.Exists(ftpFullPath))
                //{
                //    //Directory.CreateDirectory(filePath);
                //    foreach (string file in Directory.GetFiles(ftpFullPath))
                //    {
                //        File.Delete(file);
                //    }
                //}

                //WebRequest request = WebRequest.Create(Server.MapPath("~/SavePDF/" + pdfBytes));
                //request.Method = WebRequestMethods.Ftp.UploadFile;
                ////rptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, filePath + filename);
                ////request.Credentials = new NetworkCredential(username, password);
                //Stream reqStream = request.GetRequestStream();
                //reqStream.Close();
                //FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(new Uri(ftpFullPath));
                //ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                //ftp.KeepAlive = true;
                //ftp.UseBinary = true;
                //ftp.Method = WebRequestMethods.Ftp.UploadFile;
                //Stream ftpStream = ftp.GetRequestStream();
                //ftpStream.Write(pdfBytes, 0, pdfBytes.Length);
                //ftpStream.Close();
                //ftpStream.Dispose();
                //retValue = true;
            }
            catch (Exception ex)
            {

            }
            return ftpFullPath;
        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string str_subject;
          //  DataAccess.Accounts.Approval appobj = new DataAccess.Accounts.Approval();
            dt = appobj.mail_hblno(txt_bl.Text, Convert.ToInt32(hid_job.Value), Convert.ToInt32(Session["LoginBranchid"]));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    str_subject = "D/O issued Information" + " - " + "JOB # : " + dt.Rows[i]["jobno"].ToString() + " / " + " HBL # : " + dt.Rows[i]["blno"].ToString() + " / " + "Container # : " + dt.Rows[i]["containerno"].ToString() + " / " + dt.Rows[i]["sizetype"].ToString() + " ";
                    string mailsub = str_subject;
                    string adsf = canUpload1(txt_bl.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    can_sendmail(dt.Rows[i]["blno"].ToString());
                    DataTable dt1 = new DataTable();
                    dt1 = appobj.jobsplit_automail(dt.Rows[i]["blno"].ToString(), Convert.ToInt32(hid_job.Value), Convert.ToInt32(Session["LoginBranchid"]));
                    if (dt1.Rows.Count > 0)
                    {
                        if (mailid != "")
                        {
                            mailid = dt1.Rows[0]["tomailids"].ToString();
                            ccmail = dt1.Rows[0]["ccmailid"].ToString();
                        }
                       
                        string mailto = mailid;
                        Utility.SendMail(Session["usermailid"].ToString(), mailto, mailsub, sendqry, adsf, Session["usermailpwd"].ToString(), "", ccmail);
                        sendqry = "";
                    }

                }
            }
        }

        protected void btncfs_Click(object sender, EventArgs e)
        {
            DataTable dt;
            string StrScript = "";

            DataTable obj_dt = new DataTable();
          //  DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
            try
            {
                //if (hfWasConfirmed.Value == "true")
                //{
                dt = chargeobj.GEtCFSdtls4consignee(Convert.ToInt32(hid_consign.Value));
                if (dt.Rows.Count > 0)
                {
                    int Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Logobj.GetDate()), "FI", Convert.ToInt32(hid_job.Value),
                                               Convert.ToInt32(hid_consign.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                                               "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                                               "Profoma Invoice", "", 0, Convert.ToInt32(hid_consign.Value));


                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {


                        exrate = obj_da_Invoice.GetExRate(dt.Rows[i]["curr"].ToString(), Convert.ToDateTime(Logobj.GetDate()), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                        amount = CheckBase(dt.Rows[i]["base"].ToString(), Convert.ToDouble(dt.Rows[i]["rate"]), exrate);
                        ProINVobj.InsertProInvoiceDetails(Refno, Convert.ToInt32(dt.Rows[i]["chargeid"]), dt.Rows[i]["curr"].ToString(), Convert.ToDouble(dt.Rows[i]["rate"].ToString()),
                            exrate, dt.Rows[i]["base"].ToString(), amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                            , "C", "FI", "Profoma Invoice", "Y", unit);

                    }
                    if (Refno != 0)
                    {
                        StrScript += " Proforma Invoice # " + Refno + " is Generated For " +txt_consignee.Text+ "  Against CFS Details";
                        ScriptManager.RegisterStartupScript(btncfs, typeof(Button), "BL_print", "alertify.alert('" + StrScript + "');", true);
                    }

                   
                        
                        //    str_RptName = "FIProInvoice.rpt";
                        
                        //str_sf = "{InvoiceHead.trantype}=\"" + str_TranType + "\"  and {InvoiceHead.refno}=" + txtref.Text + " and {InvoiceHead.branchid}=" + int_branchid + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                        //str_sp = "Lcurr=INR~container=" + Str_Container;
                        //Session["str_sfs"] = str_sf;
                        //Session["str_sp"] = str_sp;
                    //}
                }

                else
                {
                    ScriptManager.RegisterStartupScript(btncfs, typeof(LinkButton), "BL_print", "alertify.alert('No CFS Charges available for the consignee');", true);
                }
                //}
            }
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
            strtrantype = "FI";
          string  FBase = strbase;
            if (strbase.ToUpper() == "BL" || strbase.ToUpper() == "HWBL" || strbase.ToUpper() == "DOC")
            {
                amount = rate * exrate;
                unit = 1;
            }
            else if (strbase.ToUpper() == "CBM" || strbase.ToUpper() == "MT")
            {
                if (strbase.ToUpper() == "CBM")
                {
                    if (strtrantype == "FE")
                    {
                        if (lbl_header.Text == "InvoiceWoJ")
                        {
                            strvolume = Convert.ToDouble(Invobj.GetVolume(txt_bl.Text, "Wo", Convert.ToInt32(Session["LoginBranchId"].ToString())));
                            amount = rate * exrate * strvolume;
                            unit = strvolume;
                        }
                        else
                        {
                            strvolume = Invobj.GetVolume(txt_bl.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                            amount = rate * exrate * strvolume;
                            unit = strvolume;
                        }
                    }
                    else
                    {
                        strvolume = Invobj.GetVolume(txt_bl.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
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

                                strntweight = Invobj.GetWeightnew(txt_bl.Text, "Wo", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                                amount = rate * exrate * (strntweight);
                                unit = (strntweight);
                            }
                            else
                            {
                                //strntweight = Invobj.GetWeight(txt_blno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                                //amount = rate * exrate * (strntweight / 1000);
                                //unit = (strntweight / 1000);

                                strntweight = Invobj.GetWeightnew(txt_bl.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                                amount = rate * exrate * (strntweight);
                                unit = (strntweight);
                            }
                        }
                        else
                        {
                            //strntweight = Invobj.GetWeight(txt_blno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                            //amount = rate * exrate * (strntweight / 1000);
                            //unit = (strntweight / 1000);

                            strntweight = Invobj.GetWeightnew(txt_bl.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                            amount = rate * exrate * (strntweight);
                            unit = (strntweight);
                        }
                    }
                }
                strvolume = Invobj.GetVolume(txt_bl.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                cbmAmt = rate * exrate * strvolume;
                //strntweight = Invobj.GetWeight(txt_blno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                // mtAmt = rate * exrate * (strntweight / 1000);


                strntweight = Invobj.GetWeightnew(txt_bl.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                mtAmt = rate * exrate * (strntweight);

                if (cbmAmt < mtAmt)
                {
                    FBase = "MT";
                    amount = mtAmt;
                    unit = (strntweight);
                }
                else
                {
                    FBase = "CBM";
                    amount = cbmAmt;
                    unit = strvolume;
                }
            }
            else
            {
                if (strbase.ToUpper() == "KGS" || strbase.ToUpper() == "Kgs") // strbase == "Kgs" || strbase == "KGS"
                {
                    if (strtrantype == "AE" || strtrantype == "AI")
                    {
                        strchgweight = Invobj.GetChargeWeight(txt_bl.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                        amount = rate * exrate * strchgweight;
                        unit = strchgweight;
                    }
                    else
                    {
                        strgrosswght = Invobj.GetGrossWeight(txt_bl.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                        amount = rate * exrate * strgrosswght;
                        unit = strgrosswght;
                    }
                }
                else if (strbase.ToUpper() == "SB")
                {
                    if (strtrantype == "FE")
                    {
                        sizecount = Invobj.GetSBillCount(txt_bl.Text, Convert.ToInt32(hid_job.Value), "BL", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                        amount = rate * exrate * sizecount;
                        unit = sizecount;
                    }
                }
                else
                {
                    if (strtrantype == "FE")
                    {
                        sizecount = Invobj.GetBaseCount(txt_bl.Text, strbase, strtrantype, "BL", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                        amount = rate * exrate * sizecount;
                        unit = sizecount;
                    }
                    else
                    {
                        sizecount = Invobj.GetBaseCount(txt_bl.Text, strbase, strtrantype, "BL", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                        amount = rate * exrate * sizecount;
                        unit = sizecount;
                    }
                }
            }
            return amount;



        }//checkbase
    }
}