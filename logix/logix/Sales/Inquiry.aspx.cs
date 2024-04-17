using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Diagnostics;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Mail;
using DocumentFormat.OpenXml.Office.CustomUI;
using CheckBox = System.Web.UI.WebControls.CheckBox;
using DocumentFormat.OpenXml.Vml;
using TextBox = System.Web.UI.WebControls.TextBox;
using Button = System.Web.UI.WebControls.Button;
using System.Reflection;
using AjaxControlToolkit.HtmlEditor.Popups;
using System.Web.UI.HtmlControls;
using static System.Net.Mime.MediaTypeNames;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Web.Services.Description;
using System.Threading;
using logix.Reportasp;
using DataAccess.Payroll;
using DocumentFormat.OpenXml.Math;
using logix.MIS;

namespace logix.Sales
{
    public partial class Inquiry : System.Web.UI.Page
    {
        string check = "";
        public string strFName = "", strSF = "", strPM = "";
        string straddress, intzip;
        public string strapproved;
        string strcity;
        string custtype;
        Boolean blnapprove;
        string oldbase;
        double famount, currexrate;
        string shipment_dt;
        string intapprovedbyid;
        int app = 0;
        public int flag;
        public string strtrantype;
        int strapprovedby;
        string strtran;
        string intShipment;
        string intcustid;
        int quotid;
        int quotationid;
        int intchargeid;
        string Strshipment;
        string strfstatus;
        int OldQuotNo;
        string sendqry, pdt;
        string mailid = "";
        string straddress1, zipcode;
        string str_Uiid = "", str_FornName;
        int intpol, intpod, intpor, intfd, movementtype;
        int int_country = 0;
        Boolean blnexists, ratevalid;
        char freight;
        char shipment;
        char dgcargo, bulkvolume;
        DataTable Dt = new DataTable();
        DataTable dtQuot = new DataTable();
        DataTable dtBooking = new DataTable();
        DataTable dtcrm = new DataTable();
        DataTable dtlf = new DataTable();
        DataTable dtfill = new DataTable();
        DataTable dtpercent = new DataTable();
        DataTable dtproduct = new DataTable();
        DataTable dtgetqty = new DataTable();
        DataSet dsnew = new DataSet();
        int customerid, cargoid, sales, prepared, hazard;
        DataTable obj_dtQuot = new DataTable();
        DataAccess.UserPermission userperobj = new DataAccess.UserPermission();
        string usermail;
        DateTime validity;
        string empmailadd = "";
        DataAccess.BuyingRate buyingobj = new DataAccess.BuyingRate();
        DataAccess.HR.Employee HrEmpobj = new DataAccess.HR.Employee();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterEmployee employee = new DataAccess.Masters.MasterEmployee();
        DataAccess.Marketing.Booking booking = new DataAccess.Marketing.Booking();
        DataAccess.Marketing.Quotation quotation = new DataAccess.Marketing.Quotation();
        DataAccess.Masters.MasterContainer container = new DataAccess.Masters.MasterContainer();
        DataAccess.Masters.MasterCharges charges = new DataAccess.Masters.MasterCharges();
        DataAccess.Masters.MasterPort port = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCustomer customer = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterCargo cargo = new DataAccess.Masters.MasterCargo();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
        DataAccess.CRM.CRMSalesDetails objcrm = new DataAccess.CRM.CRMSalesDetails();
        DataAccess.Masters.MasterCustomerGroup objgroup = new DataAccess.Masters.MasterCustomerGroup();
        DataAccess.Marketing.Quotation objoua = new DataAccess.Marketing.Quotation();
        DataTable dtgroup = new DataTable();
        DataTable dtbuying = new DataTable();
        DataTable dt_char = new DataTable();
        DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
        DataTable dtgr = new DataTable();
        int pol, pod, por, fd;
        DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
        DataTable DT_bind = new DataTable();
        DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
        DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
        DataAccess.CreditException Crexobj = new DataAccess.CreditException();
        DataAccess.Outstanding outsobj = new DataAccess.Outstanding();
        DataAccess.ForwardingImports.BLDetails da_obj_blobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.Marketing.Quotation quotobj = new DataAccess.Marketing.Quotation();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCustomer cus = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
        int total;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;

        string Ctrl_List1;
        string Msg_List1;
        string Dtype_List1;
        Boolean brr;
        DataTable dt_MenuRights = new DataTable();
        bool blnerr;

        public string Text { get; private set; }

        // public ReportDocument rpt = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                HrEmpobj.GetDataBase(Ccode);
                buyingobj.GetDataBase(Ccode);
                userperobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                employee.GetDataBase(Ccode);
                booking.GetDataBase(Ccode);
                quotation.GetDataBase(Ccode);
                container.GetDataBase(Ccode);
                charges.GetDataBase(Ccode);
                port.GetDataBase(Ccode);

                customer.GetDataBase(Ccode);
                cargo.GetDataBase(Ccode);
                portobj.GetDataBase(Ccode);
                custobj.GetDataBase(Ccode);
                INVOICEobj.GetDataBase(Ccode);
                objoua.GetDataBase(Ccode);
                chargeobj.GetDataBase(Ccode);
                bookingobj.GetDataBase(Ccode);
                obj_da_Branch.GetDataBase(Ccode);
                Crexobj.GetDataBase(Ccode);
                outsobj.GetDataBase(Ccode);
                da_obj_blobj.GetDataBase(Ccode);
                quotobj.GetDataBase(Ccode) ;
                obj_da_Log.GetDataBase(Ccode) ;
                obj_MasterPort.GetDataBase(Ccode) ;
                cus.GetDataBase(Ccode) ;
                da_obj_Customer.GetDataBase(Ccode) ;
            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnclose);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtInco);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtCustomer);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtPOR);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtPOL);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtPOD);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtFD);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtCargo);

            if (ddl_product.Text == "Ocean Exports")
            {
                Session["StrTranType"] = "FE";
                strtrantype = Session["StrTranType"].ToString();
                // baseFil();


            }
            else if (ddl_product.Text == "Ocean Imports")
            {
                Session["StrTranType"] = "FI";
                strtrantype = Session["StrTranType"].ToString();
                // baseFil();

            }
            else if (ddl_product.Text == "Air Exports")
            {
                Session["StrTranType"] = "AE";
                strtrantype = Session["StrTranType"].ToString();
                // baseFil();

            }
            else if (ddl_product.Text == "Air Imports")
            {
                Session["StrTranType"] = "AI";
                strtrantype = Session["StrTranType"].ToString();
                // baseFil();

            }
            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "FE")
                {
                    HeaderLabel1.InnerText = "Ocean Exports Customer Support";
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    HeaderLabel1.InnerText = "Ocean Imports Customer Support";
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    HeaderLabel1.InnerText = "Air Exports Customer Support";
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    HeaderLabel1.InnerText = "Air Imports Customer Support";
                }
                strtrantype = Session["StrTranType"].ToString();
                if (Session["StrTranType"].ToString() == "FE")
                {
                    HeaderLabel1.InnerText = "OceanExports";
                    if (lblHeader.Text == "Quotation Approval")
                    {
                        HeaderLabel2.InnerText = "Approval";
                    }
                    else if (lblHeader.Text == "Inquiry")
                    {
                        HeaderLabel2.InnerText = "Sales";
                    }

                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    HeaderLabel1.InnerText = "OceanImports";
                    if (lblHeader.Text == "Quotation Approval")
                    {
                        HeaderLabel2.InnerText = "Approval";
                    }
                    else if (lblHeader.Text == "Inquiry")
                    {
                        HeaderLabel2.InnerText = "Sales";
                    }
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    HeaderLabel1.InnerText = "AirExports";
                    if (lblHeader.Text == "Quotation Approval")
                    {
                        HeaderLabel2.InnerText = "Approval";
                    }
                    else if (lblHeader.Text == "Inquiry")
                    {
                        HeaderLabel2.InnerText = "Sales";
                    }
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    HeaderLabel1.InnerText = "AirImports";
                    if (lblHeader.Text == "Quotation Approval")
                    {
                        HeaderLabel2.InnerText = "Approval";
                    }
                    else if (lblHeader.Text == "Inquiry")
                    {
                        HeaderLabel2.InnerText = "Sales";
                    }
                }
            }






            if (!IsPostBack)
            {
                try
                {
                    Session["ChkType"] = "false";
                    txtRate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Rate')");
                    if (Request.QueryString.ToString().Contains("quotno"))
                    {

                        string product = Request.QueryString["product"].ToString();
                        if (product == "FE")
                        {
                            ddl_product.Items.Add("Ocean Exports");
                            ddl_product.SelectedValue = "Ocean Exports";
                            strtrantype = "FE";
                        }
                        else if (product == "FI")
                        {
                            ddl_product.Items.Add("Ocean Imports");
                            ddl_product.SelectedValue = "Ocean Imports";
                            strtrantype = "FI";
                        }
                        else if (product == "AI")
                        {
                            ddl_product.Items.Add("Air Imports");
                            ddl_product.SelectedValue = "Air Imports";
                            strtrantype = product;
                        }
                        else if (product == "AE")
                        {
                            ddl_product.Items.Add("Air Exports");
                            ddl_product.SelectedValue = "Air Exports";
                            strtrantype = product;
                        }
                        Session["StrTranType"] = strtrantype;
                    }
                    else
                        if (Session["trantype_process"] != null)
                    {
                        dt_MenuRights = userperobj.Getformuserrights(Convert.ToInt16(Session["LoginEmpId"].ToString()), "", Convert.ToInt16(Session["LoginBranchid"].ToString()), 2, "Inquiry");//Session["trantype_process"] as DataTable;
                        ddl_product.Items.Add("");
                        //Session["StrTranType"] = null;
                        for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                        {
                            if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FE")
                            {
                                ddl_product.Items.Add("Ocean Exports");
                            }
                            else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FI")
                            {
                                ddl_product.Items.Add("Ocean Imports");
                            }
                            else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AE")
                            {
                                ddl_product.Items.Add("Air Exports");
                            }
                            else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AI")
                            {
                                ddl_product.Items.Add("Air Imports");
                            }
                        }
                        // Session["StrTranType"] = dt_MenuRights.Rows[i]["modulename"].ToString();
                    }
                    else if (Session["StrTranType"] != null)
                    {
                        ddl_product.Items.Add("");
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            ddl_product.Items.Add("Ocean Exports");
                            //ddl_product.SelectedIndex = 1;
                            ddl_product.SelectedValue = "Ocean Exports";
                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {
                            ddl_product.Items.Add("Ocean Imports");
                            ddl_product.SelectedValue = "Ocean Imports";
                            //ddl_product.SelectedIndex = 1;
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {
                            ddl_product.Items.Add("Air Exports");
                            ddl_product.SelectedValue = "Air Exports";
                            //ddl_product.SelectedIndex = 1;
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {
                            ddl_product.Items.Add("Air Imports");
                            ddl_product.SelectedValue = "Air Imports";
                        }
                        else if (Session["StrTranType"].ToString() == "CRM")
                        {
                            ddl_product.Items.Add("Air Exports");
                            ddl_product.Items.Add("Air Imports");
                            ddl_product.Items.Add("Ocean Exports");
                            ddl_product.Items.Add("Ocean Imports");

                        }
                        //ddl_product.SelectedIndex = 1;
                    }
                    baseFil();
                    if (ddl_product.Text == "0")
                    {
                        DataTable Dt = new DataTable();
                        //chkContainerList.Items.Clear();
                        DataSet ds1 = new DataSet();
                        DataTable dtpkg1 = new DataTable();
                        ds1 = container.GetContainersize();
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            dtpkg1 = ds1.Tables[0];
                            Dt.Columns.Add("checksbno");
                            Dt.Columns.Add("conttype");
                            Dt.Columns.Add("txt_Sizecount");

                            if (dtpkg1.Rows.Count > 0)
                            {
                                //Dt.Rows.Add();
                                //Dt.Rows[0]["conttype"] = "CBM";
                                for (int i = 0; i <= dtpkg1.Rows.Count - 1; i++)
                                {
                                    Dt.Rows.Add();
                                    //Dt.Rows[0]["conttype"] = "CBM";
                                    Dt.Rows[i]["conttype"] = dtpkg1.Rows[i]["conttype"].ToString();
                                }


                                Dt.Rows.Add();
                                Dt.Rows[dtpkg1.Rows.Count]["conttype"] = "CBM";
                                Dt.Rows.Add();
                                Dt.Rows[dtpkg1.Rows.Count + 1]["conttype"] = "MT";
                                //Dt.Rows.Add();
                                //Dt.Rows[dtpkg1.Rows.Count + 2]["conttype"] = "AT ACTUALS";
                                grd_Sizetype.DataSource = Dt;
                                grd_Sizetype.DataBind();
                            }
                            // chkContainerList.DataSource = dtpkg1;
                            // chkContainerList.DataTextField = "conttype";
                            // chkContainerList.DataValueField = "conttype";
                            // chkContainerList.DataBind();
                            //chkContainerList.Items.Insert(1, "BL");
                            //chkContainerList.Items.Insert(2, "CBM");
                            //chkContainerList.Items.Insert(3, "MT");
                        }
                        else
                        {
                            grd_Sizetype.DataSource = Utility.Fn_GetEmptyDataTable();
                            grd_Sizetype.DataBind();
                        }
                    }

                    Containe_Charges();
                    btnAdd.Enabled = false;

                    grd_Sizetype.Enabled = true;
                    btnAdd.ForeColor = System.Drawing.Color.Gray;
                    //txtRate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Rate')");
                    txtBrokerage.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Brokerage')");
                    // txtRate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'EX-Rate')");
                    txtQuotation.Attributes.Add("onkeypress", "return IntegerCheck(event,'Quotation ID')");
                    txtCurr.Attributes.Add("onkeypress", "return CheckTextLength(this,3,'currency')");
                    txtQuotation.Attributes.Add("onKeyPress", "return CheckTextLength(this,5,'Quotation #')");
                    txtInco.Attributes.Add("onblur", "return doSomethingInJavascript()");
                    //if (Request.QueryString.ToString().Contains["type"])
                    if (Request.QueryString.ToString().Contains("type"))
                    {
                        //lblHeader.Text = Request.QueryString["type"].ToString();
                        lblHeader.Text = "Inquiry";
                    }



                    if (Session["sess"] != null)
                    {
                        txtQuotation.Text = Session["Quo"].ToString();
                        getvalue();
                        btnAdd.Visible = false;
                        btnSave.Visible = false;
                        btnApp.Visible = false;
                        //btnsend.Visible = false;
                        linkBuying.Enabled = false;
                        linkQuotation.Enabled = false;
                        chkHazard.Enabled = false;
                        ddl_controlledby.Enabled = false;
                        // rdbBussiness.Enabled = false;
                        //lnk_back.Visible = true;
                        btnclose.Visible = false;
                        Session["Quo"] = null;
                    }
                    else
                    {
                        fillddl();

                        Ctrl_List = txtCustomer.ID + "~" + txtCargo.ID + "~" + txtPOR.ID + "~" + txtPOL.ID + "~" + txtPOD.ID + "~" + txtFD.ID + "~" + txtSalesPerson.ID;
                        Msg_List = "Customer Name ~Cargo~POR~POL~POD~PODelivery~Sales Person";
                        Dtype_List = "string~string~string~string~string~string~string";
                        btnSave.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                        Ctrl_List1 = txtCharges.ID + "~" + txtCurr.ID;
                        Msg_List1 = "Charge Name ~Currency";
                        Dtype_List1 = "string~string~string";
                        btnAdd.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List1 + "','" + Msg_List1 + "','" + Dtype_List1 + "')");

                        Utility.Fn_CheckUserRights(str_Uiid, btnSave, null, null);
                        grdQuotation.DataSource = Utility.Fn_GetEmptyDataTable();
                        grdQuotation.DataBind();

                        grdBuying.DataSource = Utility.Fn_GetEmptyDataTable();
                        grdBuying.DataBind();
                        //ddlpdt.Items.Add("--Product--");
                        //ddlpdt.Items.Add("Forwarding Exports FCL");
                        //ddlpdt.Items.Add("Forwarding Exports LCL");
                        //ddlpdt.Items.Add("Forwarding Imports FCL");
                        //ddlpdt.Items.Add("Forwarding Imports LCL");
                        //ddlpdt.Items.Add("Air Exports");
                        //ddlpdt.Items.Add("Air Imports");
                        //ddlBase.Items.Add("--BASE--");
                        //strtrantype = "FE";
                        txtPreparedBy.Enabled = true;
                        txt_value.Text = "1";
                        // ddl_controlledby.Checked = false;
                        //  rdbagent.Checked = false;
                        btnAdd.Visible = true;
                        btnSave.Visible = true;
                        btnApp.Visible = true;
                        //btnsend.Visible = true;
                        linkBuying.Enabled = true;
                        linkQuotation.Enabled = true;
                        chkHazard.Enabled = true;
                        //  rdbagent.Enabled = true;
                        //rdbBussiness.Enabled = true;
                        //lnk_back.Visible = false;
                        btnclose.Visible = true;
                        fillDetails();
                        //grdmail.DataSource = Utility.Fn_GetEmptyDataTable();
                        // grdmail.DataBind();
                        if (btnApp.ToolTip == "Delete")
                        {
                            btnApp.Attributes["onClick"] = "return confirm('Are you sure you want to delete this Details?');";
                        }
                    }

                    //Session["Quo"]    Session["booking"]
                    txtQuotation.Focus();
                    if (Request.QueryString.ToString().Contains("inquiryid"))
                    {
                        crumbs.Attributes["class"] = "crumbslbl";
                        txtQuotation.Text = Request.QueryString["inquiryid"].ToString();
                        txtQuotation_TextChanged(sender, e);

                    }

                    if (Request.QueryString.ToString().Contains("inquiryid"))
                    {
                        txtQuotation.Text = Request.QueryString["inquiryid"].ToString();
                        txtQuotation_TextChanged(sender, e);

                    }
                    else if (lblHeader.Text == "Quotation Approval")
                    {
                        linkQuotation_Click(sender, e);
                    }


                    //if (lblHeader.Text == "Quotation Approval")
                    //{
                    //    linkQuotation_Click(sender, e);
                    //}
                    UserRights();
                    if (lblHeader.Text != "Quotation Approval")
                    {
                        btnApp.Enabled = false;
                    }

                    DT_bind.Columns.Add("Credit/Outstanding", typeof(string));
                    DT_bind.Columns.Add("Details", typeof(string));
                    DT_bind.Rows.Add("Credit Days");
                    DT_bind.Rows.Add("Credit Amount");
                    DT_bind.Rows.Add("Over Due Days");
                    DT_bind.Rows.Add("Over Due Amount");
                    DT_bind.Rows.Add("Total OS Amt");
                    test.DataSource = DT_bind;
                    test.DataBind();
                    // yuvaraj 07/09/2022

                    GrdBuysellcharge.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdBuysellcharge.DataBind();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
                txtQuotation.Focus();
                grd_Sizetype.Enabled = true;// add 20/1/23
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

            //grdQuotaionDetails.Visible = false;
            //grdBuyingDetails.Visible = false;

            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            Session["Quo"] = null;
            Session["sess"] = null;
            headerlabel.InnerText = lblHeader.Text;

            grd_Sizetype.Enabled = true;
            //BuyRateBtn.Visible = false;
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
        public static List<string> GetCustomer(string prefix, string FType)
        {
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_da_customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.Marketing.Quotation objQuotation = new DataAccess.Marketing.Quotation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_customerobj.GetDataBase(Ccode);
            objQuotation.GetDataBase(Ccode);
            
            obj_dt = obj_da_customerobj.GetLikeCustomer(prefix.Trim(), FType);
            // obj_dt = GetCustomer4quotcountrywise.GetLikeCustomer(prefix.Trim(), FType, Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));



            //obj_dt = obj_da_customerobj.GetLikeIndianCustomer(prefix);Cusobj
            //cargo = logix.Utility.Fn_DatatableToList_Customer(obj_dt, "customername", "customerid");
            //customer = Utility.Fn_DatatableToList(obj_dt, "customer", "customerid");
            customer = Utility.Fn_TableToList(obj_dt, "customer", "customerid", "customername", "address");
            return customer;
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

        protected void UserRights()
        {
            if (Request.QueryString.ToString().Contains("type"))
            {
                Boolean btn_delete;
                str_FornName = Request.QueryString["type"].ToString();
                str_Uiid = Request.QueryString["uiid"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btnSave, btnView, btnApp);
                DataTable obj_Dtuser = new DataTable();
                obj_Dtuser = (DataTable)Session["dt_UserRights"];
                DataView obj_dtview = new DataView(obj_Dtuser);
                obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                //obj_Dtuser = obj_dtview.ToTable();
                //btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                if (Request.QueryString["type"].ToString() == "Quotation Approval")
                {
                    btnApp.Enabled = true;
                    btnApp.ForeColor = System.Drawing.Color.White;
                }

            }
        }

        public void Containe_Charges()
        {
            if (Session["StrTranType"] != null)
            {
                strtrantype = Session["StrTranType"].ToString();
            }
            if (strtrantype == "FE" || strtrantype == "FI")
            {
                //chkContainerList.Items.Clear();
                //DataSet ds1 = new DataSet();
                //DataTable dtpkg1 = new DataTable();
                //ds1 = container.GetContainersize();
                //if (ds1.Tables[0].Rows.Count > 0)
                //{
                //    dtpkg1 = ds1.Tables[0];
                //    chkContainerList.DataSource = dtpkg1;
                //    chkContainerList.DataTextField = "conttype";
                //    chkContainerList.DataValueField = "conttype";
                //    chkContainerList.DataBind();
                //    //chkContainerList.Items.Insert(0, "<---Select--->");
                //    //chkContainerList.Items.Insert(1, "BL");
                //    //chkContainerList.Items.Insert(2, "CBM");
                //    //chkContainerList.Items.Insert(3, "MT");
                //}
                grd_Sizetype.DataSource = Utility.Fn_GetEmptyDataTable();
                grd_Sizetype.DataBind();
                DataTable Dt = new DataTable();
                //chkContainerList.Items.Clear();
                DataSet ds1 = new DataSet();
                DataTable dtpkg1 = new DataTable();
                ds1 = container.GetContainersize();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    dtpkg1 = ds1.Tables[0];
                    Dt.Columns.Add("checksbno");
                    Dt.Columns.Add("conttype");
                    Dt.Columns.Add("txt_Sizecount");

                    if (dtpkg1.Rows.Count > 0)
                    {
                        //Dt.Rows.Add();
                        //Dt.Rows[0]["conttype"] = "CBM";
                        for (int i = 0; i <= dtpkg1.Rows.Count - 1; i++)
                        {
                            Dt.Rows.Add();
                            //Dt.Rows[0]["conttype"] = "CBM";
                            Dt.Rows[i]["conttype"] = dtpkg1.Rows[i]["conttype"].ToString();
                        }
                        Dt.Rows.Add();
                        Dt.Rows[dtpkg1.Rows.Count]["conttype"] = "CBM";
                        Dt.Rows.Add();
                        Dt.Rows[dtpkg1.Rows.Count + 1]["conttype"] = "MT";
                        //Dt.Rows.Add();
                        //Dt.Rows[dtpkg1.Rows.Count + 2]["conttype"] = "AT ACTUALS";
                        grd_Sizetype.DataSource = Dt;
                        grd_Sizetype.DataBind();
                    }
                    // chkContainerList.DataSource = dtpkg1;
                    // chkContainerList.DataTextField = "conttype";
                    // chkContainerList.DataValueField = "conttype";
                    // chkContainerList.DataBind();
                    //chkContainerList.Items.Insert(1, "BL");
                    //chkContainerList.Items.Insert(2, "CBM");
                    //chkContainerList.Items.Insert(3, "MT");
                }
                else
                {
                    grd_Sizetype.DataSource = Utility.Fn_GetEmptyDataTable();
                    grd_Sizetype.DataBind();
                }
            }
        }

        private void fillDetails()
        {

            try
            {

                grdQuotation.Enabled = false;


                btnclose.Enabled = true;
                btnclose.ForeColor = System.Drawing.Color.White;
                txtDate.Enabled = false;
                if (flag == 0)
                {

                    txtDate.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                    txtValidTill.Text = DateTime.Parse(Logobj.GetDate().AddDays(15).ToShortDateString()).ToString("dd/MM/yyyy");
                    Calendarextender1.StartDate = DateTime.Parse(Logobj.GetDate().ToShortDateString());
                    DateTime now = DateTime.Now;//DateTime.Parse(Logobj.GetDate().AddDays(15).ToShortDateString()).ToString("dd/MM/yyyy");
                    txt_enquiry.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    linkQuotation.Enabled = true;

                }
                if (lblHeader.Text != "Quotation Approval")
                {

                    if (strtrantype == "FE")
                    {
                        ddlShipment.Enabled = true;
                        lblHeader.Text = "Inquiry";
                    }
                    else if (strtrantype == "FI")
                    {
                        ddlShipment.Enabled = true;
                        lblHeader.Text = "Inquiry";
                    }
                    else if (strtrantype == "AE")
                    {

                        ddlShipment.Enabled = false;
                        ddlShipment.SelectedValue = "AIR";
                        // ddlShipment.SelectedValue = "FCL";
                        if (txtPOL.Text == "ARGENTINA")
                        {
                            txtPOL.Text = "";
                        }
                        if (txtPOD.Text == "ARGENTINA")
                        {
                            txtPOD.Text = "";
                        }
                        if (txtPOR.Text == "ARGENTINA")
                        {
                            txtPOR.Text = "";
                        }
                        if (txtFD.Text == "ARGENTINA")
                        {
                            txtFD.Text = "";
                        }


                    }
                    else if (strtrantype == "AI")
                    {

                        ddlShipment.Enabled = false;
                        ddlShipment.SelectedValue = "AIR";
                        //   ddlShipment.SelectedValue = "FCL";
                        if (txtPOL.Text == "ARGENTINA")
                        {
                            txtPOL.Text = "";
                        }
                        if (txtPOD.Text == "ARGENTINA")
                        {
                            txtPOD.Text = "";
                        }
                        if (txtPOR.Text == "ARGENTINA")
                        {
                            txtPOR.Text = "";
                        }
                        if (txtFD.Text == "ARGENTINA")
                        {
                            txtFD.Text = "";
                        }
                    }
                    else if (strtran == "CC")
                    {

                        ddlShipment.Enabled = true;
                        ddlShipment.SelectedValue = "FCL";
                    }

                }
                //DataTable dtterms = new DataTable();

                //dtterms = quotation.Getterms(ddlShipment.Text, strtrantype);
                //if (dtterms.Rows.Count > 0)
                //{
                //    txtterms.Text = dtterms.Rows[0]["terms"].ToString();
                //    txt_terms.Text = dtterms.Rows[0]["terms"].ToString();
                //}
                //  btnclose.Text = "Back";
                if (lblHeader.Text == "Quotation Approval")
                {
                    //btnApp.Text = "Approve";
                    //btnApp.ToolTip = "Approve";
                    //btn_app1.Attributes["class"] = "btn btn-approve1";
                    btnAdd.Visible = false;
                    btn_app1.Visible = false;
                    btnSave.Visible = false;
                    btnView.Visible = false;
                }
                else
                {
                    try
                    {
                        //txtPreparedBy.Text = "Prepared By : " + Session["LoginEmpName"].ToString();
                        txtPreparedBy.Text = Session["LoginEmpName"].ToString();
                        btnApp.Text = "Delete";
                        btnApp.ToolTip = "Delete";
                        btn_app1.Attributes["class"] = "btn ico-delete";
                    }
                    catch
                    {
                        //ScriptManager.RegisterStartupScript(btnSave, typeof(Page), "alert", "alertify.alert('Session Expired. Login Again');", true);
                        //return;

                    }
                }
                // txtPreparedBy.Text = Session["LoginEmpName"].ToString();
                if (lblHeader.Text == "Quotation Approval")
                {
                    ddlBase.SelectedIndex = 0;
                    linkBuying.Enabled = false;
                    txtBuyingDetails.Enabled = false;
                    txtBuying.Enabled = false;
                    chkHazard.Enabled = false;
                    ddl_controlledby.Enabled = false;
                    //  rdbBussiness.Enabled = false;
                    btnAdd.Enabled = false;
                    btnSave.Enabled = false;

                    btnAdd.ForeColor = System.Drawing.Color.Gray;
                    btnSave.ForeColor = System.Drawing.Color.Gray;

                    txtQuotation.ReadOnly = true;
                    txtDate.Enabled = false;
                    txtValidTill.Enabled = false;
                    txtPreparedBy.ReadOnly = true;
                    txtPreparedBy.Enabled = true;
                    txtCustomer.ReadOnly = true;
                    txtCargo.ReadOnly = true;
                    chkHazard.Enabled = false;
                    ddlShipment.Enabled = false;
                    ddlFreight.Enabled = false;
                    txtDescription.ReadOnly = true;
                    txtPOL.ReadOnly = true;
                    txtPOD.ReadOnly = true;
                    txtPOR.ReadOnly = true;
                    txtFD.ReadOnly = true;
                    //txtSalesPerson.ReadOnly = true;
                    //txtBrokerage.ReadOnly = true;
                    txtRemarks.ReadOnly = true;
                    txtCharges.ReadOnly = true;
                    txtCurr.ReadOnly = true;
                    txtRate.ReadOnly = true;
                    ddlBase.Enabled = false;
                    ddlBase.BackColor = System.Drawing.Color.White;
                    txtQuotation.BackColor = System.Drawing.Color.White;
                    txtDate.BackColor = System.Drawing.Color.White;
                    txtValidTill.BackColor = System.Drawing.Color.White;
                    txtPreparedBy.BackColor = System.Drawing.Color.White;
                    txtCustomer.BackColor = System.Drawing.Color.White;
                    txtCargo.BackColor = System.Drawing.Color.White;
                    chkHazard.BackColor = System.Drawing.Color.White;
                    ddlShipment.BackColor = System.Drawing.Color.White;
                    ddlFreight.BackColor = System.Drawing.Color.White;
                    txtDescription.BackColor = System.Drawing.Color.White;
                    txtPOL.BackColor = System.Drawing.Color.White;
                    txtPOD.BackColor = System.Drawing.Color.White;
                    txtPOR.BackColor = System.Drawing.Color.White;
                    txtFD.BackColor = System.Drawing.Color.White;
                    txtSalesPerson.BackColor = System.Drawing.Color.White;
                    //  txtBrokerage.BackColor = System.Drawing.Color.White;
                    txtRemarks.BackColor = System.Drawing.Color.White;
                    txtCharges.BackColor = System.Drawing.Color.White;
                    txtCurr.BackColor = System.Drawing.Color.White;
                    txtRate.BackColor = System.Drawing.Color.White;
                    btnApp.Visible = true;
                    btnSave.Visible = false;
                    btnView.Visible = false;
                    btnAdd.Visible = false;
                    ddl_controlledby.Enabled = false;
                    //rdbBussiness.Enabled = false;

                }
                else
                {
                    if (flag == 0)
                    {
                        btnApp.Visible = false;
                        btnSave.Visible = true;
                        btnApp.Visible = true;
                        btnView.Visible = true;
                        btnAdd.Visible = true;


                        btnAdd.Enabled = true;
                        btnAdd.ForeColor = System.Drawing.Color.White;
                        btnSave.Enabled = true;
                        btnSave.ForeColor = System.Drawing.Color.White;
                        btnApp.Enabled = false;
                        btnApp.ForeColor = System.Drawing.Color.Gray;
                        chkHazard.Enabled = true;
                        ddl_controlledby.Enabled = true;
                        // rdbBussiness.Enabled = true;
                    }


                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        private void txtchrgUnable()
        {
            txtCharges.Enabled = false;
            txtCurr.Enabled = false;
            txtRate.Enabled = false;
            ddlBase.Enabled = false;
        }

        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_da_customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.Marketing.Quotation objQuotation = new DataAccess.Marketing.Quotation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_customerobj.GetDataBase(Ccode);
            objQuotation.GetDataBase(Ccode);
            if (HttpContext.Current.Session["ChkType"].ToString() == "true")
            {
                obj_dt = obj_da_customerobj.GetLikeCustomerForSalesWithAgent(prefix.Trim(), Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()));
            }
            else
            {
                obj_dt = obj_da_customerobj.GetLikeCustomerForSales(prefix.Trim(), Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()));
            }

            //cargo = logix.Utility.Fn_DatatableToList_Customer(obj_dt, "customername", "customerid");
            customer = Utility.Fn_TableToList(obj_dt, "customer", "customerid", "customername", "address");
            return customer;
        }

        [WebMethod]
        public static List<string> GetLikeCargo(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCargo fa = new DataAccess.Masters.MasterCargo();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            fa.GetDataBase(Ccode);
           
            dt = fa.GetLikeCargo(prefix.Trim());
            list_result = Utility.Fn_TableToList(dt, "cargotype", "cargoid");
            return list_result;
        }

        [WebMethod]
        public static List<string> GetPOR(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterPort.GetDataBase(Ccode);
            // dt = obj_MasterPort.GetPortNameDetails(prefix.Trim());
            string trantype = "";
            if (HttpContext.Current.Session["StrTranType"] != null)
            {
                trantype = HttpContext.Current.Session["StrTranType"].ToString();
                dt = obj_MasterPort.GetPortNameDetailsnew(prefix.Trim(), trantype);
                list_result = Utility.Fn_TableToList(dt, "portname", "portid");
            }

            return list_result;

        }

        [WebMethod]
        public static List<string> GetPOD(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterPort.GetDataBase(Ccode);
            //dt = obj_MasterPort.GetPortNameDetails(prefix.Trim());
            if (HttpContext.Current.Session["StrTranType"] != null)
            {
                string trantype = HttpContext.Current.Session["StrTranType"].ToString();
                dt = obj_MasterPort.GetPortNameDetailsnew(prefix.Trim(), trantype);
                list_result = Utility.Fn_TableToList(dt, "portname", "portid");
            }
            return list_result;

        }

        [WebMethod]
        public static List<string> GetPOL(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterPort.GetDataBase(Ccode);
            //dt = obj_MasterPort.GetPortNameDetails(prefix.Trim());
            if (HttpContext.Current.Session["StrTranType"] != null)
            {
                string trantype = HttpContext.Current.Session["StrTranType"].ToString();
                dt = obj_MasterPort.GetPortNameDetailsnew(prefix.Trim(), trantype);
                list_result = Utility.Fn_TableToList(dt, "portname", "portid");
            }
            return list_result;

        }

        [WebMethod]
        public static List<string> GetFD(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterPort.GetDataBase(Ccode);
            dt = obj_MasterPort.GetPortNameDetails(prefix.Trim());
            list_result = Utility.Fn_TableToList(dt, "portname", "portid");
            return list_result;

        }

        [WebMethod]
        public static List<string> GetSales(string prefix)
        {
            List<string> Sales = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterEmployee obj_da_employeeobj = new DataAccess.Masters.MasterEmployee();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_employeeobj.GetDataBase(Ccode);
            obj_dt = obj_da_employeeobj.GetLikeEmployee4Quot(prefix.Trim(), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            Sales = Utility.Fn_DatatableToList_int16Display(obj_dt, "empnamecode", "employeeid", "empname");
            return Sales;
        }

        [WebMethod]
        public static List<string> GetChargename(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCharges chargesobj = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            chargesobj.GetDataBase(Ccode);
            DataTable dt_Location = new DataTable();
            dt_Location = chargesobj.GetLikeChargesName(prefix.Trim());

            List_Result = Utility.Fn_TableToList(dt_Location, "chargename", "chargeid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetCurrencyname(string prefix)
        {
            List<string> List_Result = new List<string>();
            // DataAccess.Masters.MasterCharges chargesobj = new DataAccess.Masters.MasterCharges();
            DataAccess.Marketing.Quotation quotation = new DataAccess.Marketing.Quotation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            quotation.GetDataBase(Ccode);
            DataTable dt_Location = new DataTable();
            dt_Location = quotation.GetLikeCurrency(prefix.Trim());
            // List_Result = Utility.Fn_TableToList(dt_Location, "currency");
            List_Result = Utility.Fn_TableToList(dt_Location, "currency", "currency");
            return List_Result;
        }
        [WebMethod]
        public static List<string> SelPortName4typepadimg(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterPort.GetDataBase(Ccode);
            //dt = obj_MasterPort.GetPortNameDetails(prefix.Trim());
            if (HttpContext.Current.Session["StrTranType"] != null)
            {
                string trantype = HttpContext.Current.Session["StrTranType"].ToString();
                dt = obj_MasterPort.SelPortName4typepadimg(prefix.Trim(), trantype);
                list_result = Utility.Fn_TableToList4type(dt, "portname", "portid", "portcode", "countryname", "countrycode");
            }
            return list_result;

        }

        private void clear()
        {
            Session["ChkType"] = "false";
            Gross_country.Checked = false;
            txtDate.Text = "";
            txtValidTill.Text = "";
            //txtPreparedBy.Text = "";
            txtBuying.Text = "";
            txtBuyingDetails.Text = "";
            txtCustomer.Text = "";
            chkHazard.Checked = false;
            //ddlBase.Items.Add("BASE");

            if (ddl_product.Text != "")
            {
                ddl_product.Text = "";
                ddl_product.Items[0].Enabled = false;
            }
            ddl_product.Text = "";
            ddl_product.Items[0].Enabled = false;
            txtDescription.Text = "";
            txtPOR.Text = "";
            txtPOL.Text = "";
            txtPOD.Text = "";
            txtFD.Text = "";
            txtSalesPerson.Text = "";
            //txtBrokerage.Text = "";
            txtRemarks.Text = "";
            //rdbagent.Checked = false;
            //rdbBussiness.Checked = false;
            btnAdd.Enabled = false;
            btnclose.Text = "Back";
            btnSave.Text = "Save";
            btnSave.ToolTip = "Save";
            btn_save.Attributes["class"] = "btn ico-save";
            btnclose.ToolTip = "Back";
            btn_back1.Attributes["class"] = "btn ico-back";
            txtCargo.Text = "";
            txtCharges.Text = "";
            txtCurr.Text = "";
            txtRate.Text = "";
            txtaddress.Text = "";
            ddl_product.Text = "";
            txtgroupAddress.Text = "";
            txtgroupcustomer.Text = "";
            grdBuying.Enabled = false;
            grdQuotation.Enabled = false;
            txtterms.Text = "";
            txt_terms.Text = "";
            //txtcrm.Text = "";
            txtTotal.Text = "";
            txtprofitamount.Text = "";
            txtInco.Text = "";
            txt_shiper.Text = "";
            txt_shipermulti.Text = "";
            txt_consignee.Text = "";
            txt_consigneemulti.Text = "";
            txt_custpono.Text = "";
            txt_routing.Text = "";
            txt_transittime.Text = "";
            //    ddl_scope.Text = "";
            txt_pieces.Text = "";
            txt_noofcont.Text = "";
            txt_grwt.Text = "";
            txt_units.Text = "";
            txt_volume.Text = "";
            txt_dim.Text = "";
            txt_buyrate.Text = "";
            txt_sellrate.Text = "";
            txt_retention.Text = "";
            ddl_moveTypes.SelectedValue = "0";
            txt_value.Text = "1";
            TextBox1.Text = "";
            txtbuygrid.Text = "";
            txtCarrier.Text = "";
            txt_totdays.Text = "";
            ddl_feasi.SelectedValue = "0";
            ddl_version.Items.Clear();
            txt_enquiry.Text = "";
            txtapprovedby.Text = "";
            txtselling.Text = "";
            txtbuyings.Text = "";


            for (int j = 0; j <= grd_Sizetype.Rows.Count - 1; j++)
            {
                CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                TextBox Txt = (TextBox)grd_Sizetype.Rows[j].Cells[2].FindControl("txt_Sizecount");
                //CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                if (Txt.Text != "" && System.Text.RegularExpressions.Regex.IsMatch(Txt.Text, "^[0-9 ]*$"))
                {


                    cbox.Checked = false;
                    Txt.Text = "";




                }

            }

            flagimg.ImageUrl = "";
            porflag.ImageUrl = "";
            podflag.ImageUrl = "";
            fdflag.ImageUrl = "";

        }

        protected void LoadBuying()
        {
            try
            {

                if (hdf_POL.Value != "" && hdf_POD.Value != "" && hdf_POR.Value != "" && hdf_FD.Value != "")
                {
                    grdBuyingDetails.Visible = true;
                    if (ddlShipment.Text != "" && txtPOL.Text != "" && txtPOD.Text != "")
                    {
                        if (ddlShipment.Text == "FCL")
                        {
                            intShipment = "F";
                        }
                        else if (ddlShipment.Text == "LCL")
                        {
                            intShipment = "L";
                        }
                        else if (ddlShipment.Text == "AIR")
                        {
                            intShipment = "A";
                        }
                    }

                    intpol = Convert.ToInt32(hdf_POL.Value);
                    intpod = Convert.ToInt32(hdf_POD.Value);
                    intpor = Convert.ToInt32(hdf_POR.Value);
                    intfd = Convert.ToInt32(hdf_FD.Value);
                    dtQuot = booking.BuyingGrdDetails(intShipment, intpol, intpod, intpor, intfd);
                    if (dtQuot.Rows.Count > 0)
                    {
                        grdQuotaionDetails.Visible = false;
                        // grdBuyingDetails.Visible = true;
                        grdBuyingDetails.DataSource = dtQuot;
                        grdBuyingDetails.DataBind();
                        ViewState["Buying"] = dtQuot;
                        //shipment_dt=dtQuot.Rows[0]["shipment"].ToString();

                        this.popupBuying.Show();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "alert", "alertify.alert('Buying Not Available');", true);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "alert", "alertify.alert('select the Inquiry');", true);
                }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void linkBuying_Click(object sender, EventArgs e)
        {
            //  strtrantype = Session["StrTranType"].ToString();
            try
            {
                LoadBuying();
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdBuyingDetails_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            // strtrantype = Session["StrTranType"].ToString();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblCustomer = (Label)e.Row.FindControl("Buying");
                    string tooltip = lblCustomer.Text;
                    e.Row.Cells[0].Attributes.Add("title", tooltip);

                    Label lblCustomer1 = (Label)e.Row.FindControl("Customer");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[1].Attributes.Add("title", tooltip1);

                    Label lblCustomer2 = (Label)e.Row.FindControl("POL");
                    string tooltip2 = lblCustomer2.Text;
                    e.Row.Cells[2].Attributes.Add("title", tooltip2);

                    Label lblCustomer3 = (Label)e.Row.FindControl("POD");
                    string tooltip3 = lblCustomer3.Text;
                    e.Row.Cells[3].Attributes.Add("title", tooltip3);

                    Label lblCustomer4 = (Label)e.Row.FindControl("PreparedBy");
                    string tooltip4 = lblCustomer4.Text;
                    e.Row.Cells[4].Attributes.Add("title", tooltip4);

                    Label lblCustomer5 = (Label)e.Row.FindControl("shipment");
                    string tooltip5 = lblCustomer5.Text;
                    e.Row.Cells[5].Attributes.Add("title", tooltip5);

                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdBuyingDetails, "Select$" + e.Row.RowIndex);

                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdBuyingDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_product.SelectedItem.Text == "")
            {
                Session["StrTranType"] = "";
            }
            strtrantype = Session["StrTranType"].ToString();
            try
            {
                //fillddl();
                if (grdBuyingDetails.Rows.Count > 0)
                {
                    int index = grdBuyingDetails.SelectedRow.RowIndex;
                    string rate = ((Label)grdBuyingDetails.SelectedRow.Cells[0].FindControl("Buying")).Text;
                    string Customer = ((Label)grdBuyingDetails.SelectedRow.Cells[1].FindControl("Customer")).Text;
                    string pol = ((Label)grdBuyingDetails.SelectedRow.Cells[2].FindControl("POL")).Text;
                    string pod = ((Label)grdBuyingDetails.SelectedRow.Cells[3].FindControl("POD")).Text;

                    string buying = Customer + "/" + pol + "-" + pod + "/" + ddlShipment.Text;
                    txtBuying.Text = rate;
                    txtBuyingDetails.Text = buying;
                    GetBuyingGrid();
                    btnclose.Text = "Cancel";
                    btnclose.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void GetBuyingGrid()
        {
            strtrantype = Session["StrTranType"].ToString();
            try
            {
                if (txtBuying.Text != "")
                {
                    dtBooking = quotation.ChargeBuyingDetails(Convert.ToInt32(txtBuying.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    //DataView dv = new DataView(dtBooking);
                    //dv.RowFilter = "Base !='BL'";
                    //obj_dtQuot = dv.ToTable("test", true);
                    //DataView dv = new DataView(dtBooking);

                    //string[] a = new string[1];
                    //a[0] = "base";
                    //dv.RowFilter = "base<>'BL'";
                    //obj_dtQuot = dv.ToTable("test", true, a);
                    //baseFil();
                }
                if (dtBooking.Rows.Count > 0)
                {

                    int j;
                    txtbuygrid.Text = "";
                    double totb = 0, totb1 = 0;
                    for (j = 0; j <= dtBooking.Rows.Count - 1; j++)
                    {
                        totb1 = Convert.ToDouble(dtBooking.Rows[j]["amount"]);
                        totb = totb + totb1;
                    }
                    DataRow Drow = dtBooking.NewRow();
                    Drow["amount"] = totb.ToString("#,0.00");

                    dtBooking.Rows.Add(Drow);
                    txtbuygrid.Text = totb.ToString("#,0.00");
                    hid_totb.Value = totb.ToString("#,0.00");
                    grdBuying.DataSource = dtBooking;
                    grdBuying.DataBind();


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void ValidateFunction()
        {
            strtrantype = Session["StrTranType"].ToString();
            try
            {
                if (txtPOL.Text != "" && txtPOD.Text != "" && txtPOR.Text != "" && txtFD.Text != "")
                {
                    if (txtPOL.Text == txtPOD.Text)
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Page), "alert", "alertify.alert('PoL And PoD Should not Same');", true);
                        txtPOD.Focus();
                        brr = true;
                        return;
                    }

                    //    if (ddl_controlledby.SelectedValue == "0")
                    //    {
                    //        ScriptManager.RegisterStartupScript(btnSave, typeof(Page), "alert", "alertify.alert('Please select Agent Controlled Business or Business Controlled By Us');", true);
                    //        brr = true;
                    //        return;
                    //    }
                }

                //if (ddlShipment.Text == "Shipment")
                //{
                //    ScriptManager.RegisterStartupScript(btnSave, typeof(Page), "alert", "alertify.alert('Please select the Shipment');", true);

                //    ddlShipment.Focus();
                //    brr = true;
                //    return;
                //}
                if (ddlFreight.Text == "Freight")
                {
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Page), "alert", "alertify.alert('Please select the Freight');", true);
                    ddlFreight.Focus();
                    brr = true;
                    return;
                }





            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        private void txtUnable()
        {
            chkHazard.Enabled = false;
            ddl_controlledby.Enabled = false;
            // rdbBussiness.Enabled = false;
            //btnAdd.Enabled = false;
            //btnSave.Enabled = false;
            ddlShipment.Enabled = false;
            ddlFreight.Enabled = false;
            txtQuotation.Enabled = false;
            chkHazard.Enabled = false;
            txtCargo.Enabled = false;
            txtDescription.Enabled = false;
            txtCustomer.Enabled = false;
            txtPOR.Enabled = false;
            txtPOL.Enabled = false;
            txtPOD.Enabled = false;
            txtFD.Enabled = false;
            //txtSalesPerson.Enabled = false;
            txtPreparedBy.Enabled = true;
            txtRemarks.Enabled = false;
            //  txtBrokerage.Enabled = false;
            //btnSave.Enabled = false;
        }

        private void fillddl()
        {
            //ddlShipment.Items.Add("Shipment");
            //ddlFreight.Items.Add("Freight");

            ddlShipment.Items.Add("FCL");
            ddlShipment.Items.Add("LCL");
            ddlShipment.Items.Add("AIR");
            ddlFreight.Items.Add("PrePaid");
            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                {
                    ddlFreight.Items.Add("Collect");
                    //ddlShipment.Items.Clear();
                    //ddlShipment.Items.Add("AIR");
                }
                else
                {
                    ddlFreight.Items.Add("Collect");
                    //ddlShipment.Items.Clear();
                    //ddlShipment.Items.Add("FCL");
                    //ddlShipment.Items.Add("LCL");

                }
            }
            else
            {
                //ddlShipment.Items.Add("FCL");
                //ddlShipment.Items.Add("LCL");
                //ddlShipment.Items.Add("AIR");
            }



        }

        private void txtCargeEnable()
        {
            txtCharges.Enabled = true;
            txtCurr.Enabled = true;
            txtRate.Enabled = true;
            ddlBase.Enabled = true;
            btnAdd.Enabled = true;
        }

        private void CollectData()
        {
            if (chkHazard.Checked == true)
            {
                hdf_Hazard.Value = "1";
            }
            else
            {
                hdf_Hazard.Value = "0";
            }
            //if (ddl_controlledby.SelectedValue != "0")
            //{
            //    if (ddl_controlledby.SelectedValue == "O")
            //    {
            //        hdf_Bussiness.Value = "O";
            //    }
            //    else
            //    {
            //        hdf_Bussiness.Value = "A";
            //    }
            //}
            if (ddlFreight.Text == "PrePaid")
            {
                freight = 'P';
            }
            else if (ddlFreight.Text == "Collect")
            {
                freight = 'C';
            }

            if (ddlShipment.Text == "LCL")
            {
                shipment = 'L';
            }
            else if (ddlShipment.Text == "FCL")
            {
                shipment = 'F';
            }
            else if (ddlShipment.Text == "AIR")
            {
                shipment = 'A';
            }
            if (chkHazard.Checked == true)
            {
                dgcargo = 'Y';
            }
            else
            {
                dgcargo = 'N';
            }
            bulkvolume = 'N';
        }

        protected void baseFil()
        {
            if (Session["StrTranType"] != null)
            {
                strtrantype = Session["StrTranType"].ToString();
            }

            ddlBase.Items.Clear();
            if (strtrantype == "FI" || strtrantype == "FE" || strtrantype == "CC")
            {
                ddlBase.Items.Add("");

                DataSet ds = new DataSet();
                ds = container.GetContainersize();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dtpkg = new DataTable();
                    dtpkg = ds.Tables[0];
                    //ddlBase.DataSource = dtpkg;
                    //ddlBase.DataTextField = "conttype";
                    //ddlBase.DataBind();
                    //for (int i = 0; i <= dtpkg.Rows.Count - 1; i++)
                    //{
                    //    ddlBase.Items.Add(dtpkg.Rows[i]["conttype"].ToString());
                    //}
                    //ddlBase.Items.Add("BL");

                    ddlBase.Items.Add("CBM");
                    ddlBase.Items.Add("MT");
                    ddlBase.Items.Add("AT ACTUALS");
                    ddlBase.Items.Add("W/M");
                }




                //for (int i = 0; i <= obj_dtQuot.Rows.Count - 1; i++)
                //{
                //    ddlBase.Items.Add(obj_dtQuot.Rows[i]["base"].ToString());
                //}

            }
            else if (strtrantype == "AE" || strtrantype == "AI")
            {
                ddlBase.Items.Add("");
                ddlBase.Items.Add("HAWB");
                ddlBase.Items.Add("KGS");
                ddlBase.Items.Add("PER TRUCK");
                ddlBase.Items.Add("COTTON/PALLET");
                ddlBase.Items.Add("AT ACTUALS");
                ddlBase.Items.Add("W/M");
                //ddlBase.Items.Add("");
                //ddlBase.Items.Add("FLAT RATE");
                //ddlBase.Items.Add("PER KG");
            }
            else if (strtrantype == "CH")
            {
                ddlBase.Items.Add("");
                ddlBase.Items.Add("DOC");
                ddlBase.Items.Add("KG");
                ddlBase.Items.Add("AT ACTUALS");
                ddlBase.Items.Add("W/M");
            }

        }

        protected void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            DataTable dtnew = new DataTable();
            if (ddl_product.SelectedItem.Text == "")
            {
                Session["StrTranType"] = "";
            }
            strtrantype = Session["StrTranType"].ToString();
            try
            {
                int sales = 0;
                btnSave.Enabled = true;
                btnSave.ForeColor = System.Drawing.Color.White;
                DataTable dt = new DataTable();
                btnclose.Text = "Cancel";
                btnclose.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                DataTable dtcust = new DataTable();
                //DataAccess.Masters.MasterCustomer cus = new DataAccess.Masters.MasterCustomer();



                if (hdf_customerid.Value == "" || hdf_customerid.Value == "0")
                {
                    hdf_customerid.Value = "0";
                }



                // dtcust = cus.GetexactCustomerForSales(txtCustomer.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginEmpId"].ToString()));
                dtcust = cus.GetexactCustomerForSalescustid(Convert.ToInt32(hdf_customerid.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()));

                //dtnew = cus.getcustomerblk(Convert.ToInt32(hdf_customerid.Value));
                //if (dtnew.Rows.Count > 0)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('This customer " + txtCustomer.Text + " status is Hold please discuss with Finance team ');", true);
                //    txtCustomer.Text = "";
                //    txtCustomer.Focus();
                //    brr = true;
                //    return;
                //}

                if (dtcust.Rows.Count > 0 && hdf_customerid.Value != "0")
                {
                    //hdf_customerid.Value = dt.Rows[0]["customerid"].ToString();
                    for (int i = 0; i < dtcust.Rows.Count; i++)
                    {
                        sales = Convert.ToInt32(dtcust.Rows[0]["saleid"].ToString());
                        //hdf_salesperson.Value = sales.ToString();
                        if (sales != 0)
                        {
                            string datas = employee.GetEmployeeName(sales);
                            if (datas != "")
                            {
                                if (datas != "0")
                                {
                                    txtSalesPerson.Text = datas;
                                    hdf_salesperson.Value = sales.ToString();
                                }
                            }
                        }
                        //else
                        //{
                        //    txtSalesPerson.Text = "";
                        //}// hide by yuvaraj 28/12/2022
                        if (hdf_salesperson.Value != "" && sales == 0)
                        {
                            int data = Convert.ToInt32(hdf_salesperson.Value);
                            txtSalesPerson.Text = employee.GetEmployeeName(data);
                        }




                    }
                    dtgroup = customer.GetCustomernamegroupid(Convert.ToInt32(hdf_customerid.Value));
                    if (dtgroup.Rows.Count > 0)
                    {


                        txtCustomer.Text = dtgroup.Rows[0]["customername"].ToString();   //if (dtgroup.Rows[0]["groupid"].ToString() != null)
                        txtaddress.Text = dtgroup.Rows[0]["address"].ToString();
                        if (!string.IsNullOrEmpty(dtgroup.Rows[0]["groupid"].ToString()))
                        {
                            hidgroupid.Value = dtgroup.Rows[0]["groupid"].ToString();
                            dtgr = objoua.RetrieveCustGroupDetails(Convert.ToInt32(hidgroupid.Value));

                            if (dtgr.Rows.Count > 0)
                            {
                                txtgroupcustomer.Text = dtgr.Rows[0]["groupname"].ToString();
                                txtgroupAddress.Text = dtgr.Rows[0]["address"].ToString();

                            }
                            else
                            {
                                txtgroupcustomer.Text = "";
                                txtgroupAddress.Text = "";
                            }

                            Bind_outstandingdetails();

                        }


                    }


                    txtPOR.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Customer');", true);
                    txtCustomer.Text = "";
                    txtCustomer.Focus();
                    brr = true;
                    return;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void txt_Sizecount_TextChanged(object sender, EventArgs e)
        {
            for (int j = 0; j <= grd_Sizetype.Rows.Count - 1; j++)
            {
                CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                TextBox Txt = (TextBox)grd_Sizetype.Rows[j].Cells[2].FindControl("txt_Sizecount");
                string value = Txt.Text;
                //CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                if (Txt.Text != "" && System.Text.RegularExpressions.Regex.IsMatch(Txt.Text, "^[0.0-9.9 ]*$"))
                {


                    cbox.Checked = true;




                }


                //if (Txt.Text == "[^a-z]$")
                if (System.Text.RegularExpressions.Regex.IsMatch(Txt.Text, "^[a-zA-Z !@#$%^&*()_+= ]*$") && Txt.Text != "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Numbers Only allowed');", true);

                    Txt.Text = "";


                    return;
                }


            }


            //    if (ddl_product.Text == "Ocean Exports" || ddl_product.Text == "Ocean Imports")
            //    {

            //        if (SType != "CBM")
            //        {
            //            if (System.Text.RegularExpressions.Regex.IsMatch(Txt.Text, "[^0-9]"))
            //            {
            //                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Numbers Only allowed');", true);
            //                txtBox.Focus();
            //                return;
            //            }
            //        }
            //    }
            //    else if (ddl_product.Text == "Air Exports" || ddl_product.Text == "Air Imports")
            //    {
            //        if (SType != "KGS")
            //        {
            //            if (System.Text.RegularExpressions.Regex.IsMatch(txtBox.Text, "[^0-9]"))
            //            {
            //                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Numbers Only allowed');", true);
            //                txtBox.Focus();
            //                return;
            //            }
            //        }
            //    }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            strtrantype = Session["StrTranType"].ToString();
            string txtCharges1 = hdf_Charges.Value;
            string Curr1 = hdf_Curr.Value;
            bool check = false;
            //if (txt_margin.Text == "-∞" || txt_margin.Text == "∞")
            //{
            //    txt_margin.Text = "0.0";
            //}
            //if (txt_retention.Text == "-∞" || txt_retention.Text == "∞")
            //{
            //    txt_retention.Text = "0.0";
            //}
            try
            {
                if (ddlBase.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Select Base type');", true);
                    return;
                }

                if (txt_buyrate.Text != "" && txt_margin.Text != "" && txt_sellrate.Text == "")
                {
                    double sellrate = ((Convert.ToDouble(txt_margin.Text)) / (Convert.ToDouble(txt_buyrate.Text)) * 100);
                    txt_sellrate.Text = sellrate.ToString();
                }
                if (txt_buyrate.Text != "" && txt_sellrate.Text != "")
                {
                    double ret = Convert.ToDouble(txt_sellrate.Text) - Convert.ToDouble(txt_buyrate.Text);
                    txt_retention.Text = ret.ToString();
                }
                else
                {
                    txt_retention.Text = "0.00";
                }
                if (txt_buyrate.Text == "")
                {
                    txt_buyrate.Text = "0.00";
                }
                if (txt_sellrate.Text == "")
                {
                    txt_sellrate.Text = "0.00";
                }
                if (txt_margin.Text == "")
                {
                    txt_margin.Text = "0.00";
                }
                txtCurr.Text = txtCurr.Text.ToUpper();
                // oldbase = ddlBase.SelectedValue;
                if (txtQuotation.Text != "")
                {
                    dtQuot = quotation.CheckQuotForBookingFromQno(Convert.ToInt32(txtQuotation.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), "Q");
                    if (dtQuot.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Booking Already done, you cannot amend. create New Quotation');", true);
                        return;
                    }
                }
                if (txtCurr.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Currency Should Not Be Blank');", true);
                    txtCurr.Focus();
                    return;
                }
                else
                {  //chargeobj.GetLikeChargesName(prefix);
                    //DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                    int cha = chargeobj.GetCurrID(txtCurr.Text);
                    if (cha == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Currency');", true);
                        txtCurr.Focus();
                        return;
                    }

                }
                //  ddlBase_SelectedIndexChanged(sender, e);
                if (btnAdd.ToolTip == "Add")
                {
                    if (txtQuotation.Text != "")
                    {
                        string amtval = "";
                        quotid = Convert.ToInt32(txtQuotation.Text);
                        int chargeid = charges.GetChargeid(txtCharges.Text);
                        blnexists = quotation.CheckChargeExist(chargeid, quotid, ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()));


                        if (blnexists == false)
                        {
                            if ((ddlBase.Text == "BL") || (ddlBase.Text == "HAWB") || (ddlBase.Text == "AT ACTUALS") || (ddlBase.Text == "W/M"))
                            {
                                txtqty.Text = "1";
                            }
                            if (ddlBase.Text != "" && txtCharges.Text != "" && txtCurr.Text != "" && txt_sellrate.Text != "" && txtqty.Text != "")
                            {

                                string strbase = ddlBase.Text;
                                famount = Convert.ToDouble(txt_sellrate.Text) * Convert.ToDouble(hid_exrate.Value) * Convert.ToDouble(txtqty.Text); //CheckBase(strbase, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtex.Text));
                                txtamount.Text = famount.ToString();
                                txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
                                hid_amount.Value = Convert.ToDecimal(txtamount.Text).ToString("0.00");

                            }
                            if (txt_buyrate.Text != "" && txt_sellrate.Text != "")
                            {
                                Double dts = Convert.ToDouble(txt_buyrate.Text) * Convert.ToDouble(hid_exrate.Value) * Convert.ToDouble(txtqty.Text);

                                double ret = Convert.ToDouble(hid_amount.Value) - dts;
                                txt_retention.Text = ret.ToString();
                            }

                            quotation.InsertcombinedChargeDetailsnew(quotid, txtCharges.Text, txtCurr.Text.ToUpper(), Convert.ToDouble(txt_sellrate.Text), ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToDouble(txtqty.Text), Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value));
                            quotation.Updquotmarginper(quotid, HttpUtility.HtmlDecode(txtCharges.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDecimal(txt_margin.Text), Convert.ToDecimal(txt_retention.Text));

                            /*  if (grd_Sizetype.Rows.Count > 0)
                              {
                                  for (int j = 0; j <= grd_Sizetype.Rows.Count - 1; j++)
                                  {
                                      string SType = grd_Sizetype.Rows[j].Cells[1].Text;
                                      CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                                      if (SType == ddlBase.Text)
                                      {

                                          if (cbox.Checked == false)
                                          {
                                              ScriptManager.RegisterStartupScript(btnAdd, typeof(Button), "logix", "alertify.alert('Select and Enter Expected.Qty for Base type : " + ddlBase.Text + "');", true);
                                              return;
                                          }
                                      }
                                      if (cbox.Checked == true)
                                      {


                                          amtval = "";
                                          TextBox txtBox = (TextBox)grd_Sizetype.Rows[j].FindControl("txt_Sizecount");

                                          /// expqty = grd_Sizetype.Rows[j].Cells[2].Text;
                                          /// 
                                          if (ddl_product.Text == "Ocean Exports" || ddl_product.Text == "Ocean Imports")
                                          {

                                              if (SType != "CBM")
                                              {
                                                  if (System.Text.RegularExpressions.Regex.IsMatch(txtBox.Text, "[^0-9]"))
                                                  {
                                                      ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Numbers Only allowed');", true);
                                                      txtBox.Focus();
                                                      return;
                                                  }
                                              }
                                          }
                                          else if (ddl_product.Text == "Air Exports" || ddl_product.Text == "Air Imports")
                                          {
                                              if (SType != "KGS")
                                              {
                                                  if (System.Text.RegularExpressions.Regex.IsMatch(txtBox.Text, "[^0-9]"))
                                                  {
                                                      ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Numbers Only allowed');", true);
                                                      txtBox.Focus();
                                                      return;
                                                  }
                                              }
                                          }


                                          if (txtBox.Text == "")
                                          {
                                              ScriptManager.RegisterStartupScript(btnAdd, typeof(Button), "logix", "alertify.alert('Enter Exp.Qty for " + SType + "');", true);
                                              txtBox.Focus();
                                              return;
                                              //amtval = "1";
                                          }
                                          else
                                          {
                                              amtval = txtBox.Text;
                                          }
                                          double firstamt = 0;
                                          firstamt = Convert.ToDouble(txt_sellrate.Text);
                                          //double totalamt = firstamt * Convert.ToInt32(amtval);
                                          if (txt_sellrate.Text != "")
                                          {
                                              if (SType == ddlBase.Text)
                                              {
                                                  if (ddlBase.Text != "" && txtCharges.Text != "" && txtCurr.Text != "" && txt_sellrate.Text != "")
                                                  {

                                                      string strbase = ddlBase.Text;
                                                      famount = Convert.ToDouble(txt_sellrate.Text) * Convert.ToDouble(hid_exrate.Value) * Convert.ToDouble(amtval); //CheckBase(strbase, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtex.Text));
                                                      txtamount.Text = famount.ToString();
                                                      txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
                                                      hid_amount.Value = Convert.ToDecimal(txtamount.Text).ToString("0.00");

                                                  }
                                                  if (txt_buyrate.Text != "" && txt_sellrate.Text != "")
                                                  {
                                                      Double dts = Convert.ToDouble(txt_buyrate.Text) * Convert.ToDouble(hid_exrate.Value) * Convert.ToDouble(amtval);

                                                      double ret = Convert.ToDouble(hid_amount.Value) - dts;
                                                      txt_retention.Text = ret.ToString();
                                                  }

                                                  quotation.InsertcombinedChargeDetailsnew(quotid, txtCharges.Text, txtCurr.Text.ToUpper(), Convert.ToDouble(txt_sellrate.Text), ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToDouble(amtval), Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value));
                                                  quotation.Updquotmarginper(quotid, HttpUtility.HtmlDecode(txtCharges.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDecimal(txt_margin.Text), Convert.ToDecimal(txt_retention.Text));

                                                  check = true;
                                              }
                                          }
                                      }
                                  }
                              }
                              if (check == false)
                              {
                                  if (txt_sellrate.Text != "")
                                  {


                                      if ((ddlBase.Text == "BL") || (ddlBase.Text == "HAWB") || (ddlBase.Text == "AT ACTUALS") || (ddlBase.Text == "W/M"))
                                      {
                                          if (ddlBase.Text != "" && txtCharges.Text != "" && txtCurr.Text != "" && txt_sellrate.Text != "")
                                          {

                                              string strbase = ddlBase.Text;
                                              famount = Convert.ToDouble(txt_sellrate.Text) * Convert.ToDouble(hid_exrate.Value) * 1; //CheckBase(strbase, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtex.Text));
                                              txtamount.Text = famount.ToString();
                                              txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
                                              hid_amount.Value = Convert.ToDecimal(txtamount.Text).ToString("0.00");

                                          }

                                          if (txt_buyrate.Text != "" && txt_sellrate.Text != "")
                                          {
                                              Double dts = Convert.ToDouble(txt_buyrate.Text) * Convert.ToDouble(hid_exrate.Value) * 1;

                                              double ret = Convert.ToDouble(hid_amount.Value) - dts;
                                              txt_retention.Text = ret.ToString();
                                          }

                                          quotation.InsertcombinedChargeDetailsnew(quotid, txtCharges.Text, txtCurr.Text.ToUpper(), Convert.ToDouble(txt_sellrate.Text), ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 1, Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value));
                                          quotation.Updquotmarginper(quotid, HttpUtility.HtmlDecode(txtCharges.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDecimal(txt_margin.Text), Convert.ToDecimal(txt_retention.Text));

                                      }
                                      else
                                      {

                                          ScriptManager.RegisterStartupScript(btnAdd, typeof(Button), "logix", "alertify.alert('Select and enter Expected Qty for basetype :" + ddlBase.Text + "');", true);
                                          return;



                                      }
                                  }
                              }*/
                            // quotation.InsertChargeDetailsnew(quotid, txtCharges.Text, txtCurr.Text.ToUpper(), Convert.ToDouble(txtRate.Text), ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(hid_expqty.Value), Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value));
                            //if (txt_buyrate.Text != "" && txt_buyrate.Text != "0")
                            //  {

                            //int chargeid;
                            //chargeid = chargeobj.GetChargeid(txtCharges.Text);
                            //hdnChargeid.Value = chargeid.ToString();

                            //if (hdf_Charges.Value == "")
                            //{
                            //    hdf_Charges.Value = chargeid.ToString();
                            //}
                            dt_char = buyingobj.BuyingChargebaseExist(Convert.ToInt32(txtBuying.Text), Convert.ToInt32(hdf_Charges.Value), ddlBase.Text);
                            if (dt_char.Rows.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Buy Rate Charge Details Already Exists.');", true);
                                //bottomValuesClear();
                                return;
                            }
                            else
                            {

                                buyingobj.InsBuyingDetails(Convert.ToInt32(txtBuying.Text), chargeid, txtCurr.Text.ToUpper().Trim(), Convert.ToDouble(txt_buyrate.Text), ddlBase.Text);
                                dtbuying = buyingobj.SelBuyingDetailsnew(Convert.ToInt32(txtBuying.Text));
                                Session["Container"] = dtbuying;
                                int j;
                                txtbuygrid.Text = "";
                                double totb = 0, totb1 = 0;
                                for (j = 0; j <= dtbuying.Rows.Count - 1; j++)
                                {
                                    totb1 = Convert.ToDouble(dtbuying.Rows[j]["amount"]);
                                    totb = totb + totb1;
                                }
                                DataRow Drow = dtbuying.NewRow();
                                Drow["amount"] = totb.ToString("#,0.00");

                                dtbuying.Rows.Add(Drow);
                                txtbuygrid.Text = totb.ToString("#,0.00");
                                hid_totb.Value = totb.ToString("#,0.00");
                                grdBuying.DataSource = dtbuying;
                                grdBuying.DataBind();

                            }
                            //}

                            dtQuot = quotation.ChargeDetailsnew(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                            if (dtQuot.Rows.Count > 0)
                            {
                                int i;
                                txtTotal.Text = "";
                                double tot = 0, tot1 = 0;
                                for (i = 0; i <= dtQuot.Rows.Count - 1; i++)
                                {
                                    tot1 = Convert.ToDouble(dtQuot.Rows[i]["amount"]);
                                    tot = tot + tot1;
                                }
                                DataRow Drow1 = dtQuot.NewRow();
                                Drow1["amount"] = tot.ToString("#,0.00");
                                dtQuot.Rows.Add(Drow1);
                                txtTotal.Text = tot.ToString("#,0.00");
                                hid_tot.Value = tot.ToString("#,0.00");
                                grdQuotation.DataSource = dtQuot;
                                grdQuotation.DataBind();
                            }
                            else
                            {
                                hid_tot.Value = "0";
                            }

                            DataTable dtss = buyingobj.Sellbuyingdeatils(Convert.ToInt32(txtBuying.Text), quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                            if (dtss.Rows.Count > 0)
                            {
                                int i;
                                txtTotal.Text = "";
                                double totals = 0;
                                double tot2 = 0;
                                txtbuygrid.Text = "";
                                double totb = 0, totb1 = 0;
                                for (i = 0; i <= dtss.Rows.Count - 1; i++)
                                {
                                    tot2 = Convert.ToDouble(dtss.Rows[i]["amount"]);
                                    totals = totals + tot2;
                                    totb1 = Convert.ToDouble(dtss.Rows[i]["sell"]);
                                    totb = totb + totb1;
                                }
                                txtbuyings.Text = totals.ToString("#,0.00");
                                hid_tot.Value = totals.ToString("#,0.00");
                                txtselling.Text = totb.ToString("#,0.00");
                                Hidtotal.Value = totb.ToString("#,0.00");

                                //DataRow Drow6 = dtss.NewRow();
                                //Drow6["amount"] = tot.ToString("#,0.00");
                                //dtss.Rows.Add(Drow6);
                                //txtTotal.Text = tot.ToString("#,0.00");
                                //hid_tot.Value = tot.ToString("#,0.00");

                                //DataRow Drow3 = dtss.NewRow();
                                //Drow3["sell"] = totb.ToString("#,0.00");
                                //dtss.Rows.Add(Drow3);
                                //txtbuygrid.Text = totb.ToString("#,0.00");
                                ////.Value = totb.ToString("#,0.00");
                                //Hidtotal.Value = totb.ToString("#,0.00");

                                GrdBuysellcharge.DataSource = dtss;
                                GrdBuysellcharge.DataBind();
                            }

                            double profitamount = Convert.ToDouble(Hidtotal.Value) - Convert.ToDouble(hid_tot.Value);
                            if (profitamount != 0.0)
                            {
                                txtprofitamount.Text = profitamount.ToString("#,0.00");
                            }
                            else
                            {
                                txtprofitamount.Text = "";
                            }
                            clearCharges();
                            txtCharges.Focus();
                            blnexists = false;
                            switch (Session["StrTranType"].ToString())
                            {
                                case "FE":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 181, 1, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + " / " + chargeid + "OE_QuotChargeS");
                                    break;
                                case "FI":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 180, 1, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + " / " + chargeid + "OI_QuotChargeS");
                                    break;
                                case "AE":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 217, 1, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + " / " + chargeid + "AE_QuotChargeS");
                                    break;
                                case "AI":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 215, 1, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + " / " + chargeid + "AI_QuotChargeS");
                                    break;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Charge Already exists for the selected Base');", true);
                            txtCharges.Focus();
                            dtQuot = quotation.ChargeDetailsnew(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                            int i;
                            txtTotal.Text = "";
                            double tot = 0, tot1 = 0;
                            for (i = 0; i <= dtQuot.Rows.Count - 1; i++)
                            {
                                tot1 = Convert.ToDouble(dtQuot.Rows[i]["amount"]);
                                tot = tot + tot1;
                            }
                            DataRow Drow1 = dtQuot.NewRow();
                            Drow1["amount"] = tot.ToString("#,0.00");
                            dtQuot.Rows.Add(Drow1);
                            txtTotal.Text = tot.ToString("#,0.00");
                            hid_tot.Value = tot.ToString("#,0.00");
                            grdQuotation.DataSource = dtQuot;
                            grdQuotation.DataBind();

                            // yuvaraj 06/09/2022
                            DataTable dtss = buyingobj.Sellbuyingdeatils(Convert.ToInt32(txtBuying.Text), quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                            if (dtss.Rows.Count > 0)
                            {

                                txtTotal.Text = "";
                                double totals = 0;
                                double tot2 = 0;
                                txtbuygrid.Text = "";
                                double totb = 0, totb1 = 0;
                                for (i = 0; i <= dtss.Rows.Count - 1; i++)
                                {
                                    tot2 = Convert.ToDouble(dtss.Rows[i]["amount"]);
                                    totals = totals + tot2;
                                    totb1 = Convert.ToDouble(dtss.Rows[i]["sell"]);
                                    totb = totb + totb1;
                                }
                                txtbuyings.Text = totals.ToString("#,0.00");
                                hid_tot.Value = totals.ToString("#,0.00");
                                txtselling.Text = totb.ToString("#,0.00");
                                Hidtotal.Value = totb.ToString("#,0.00");

                                //DataRow Drow6 = dtss.NewRow();
                                //Drow6["amount"] = tot.ToString("#,0.00");
                                //dtss.Rows.Add(Drow6);
                                //txtTotal.Text = tot.ToString("#,0.00");
                                //hid_tot.Value = tot.ToString("#,0.00");

                                //DataRow Drow3 = dtss.NewRow();
                                //Drow3["sell"] = totb.ToString("#,0.00");
                                //dtss.Rows.Add(Drow3);
                                //txtbuygrid.Text = totb.ToString("#,0.00");
                                ////.Value = totb.ToString("#,0.00");
                                //Hidtotal.Value = totb.ToString("#,0.00");

                                GrdBuysellcharge.DataSource = dtss;
                                GrdBuysellcharge.DataBind();
                            }

                            switch (Session["StrTranType"].ToString())
                            {
                                case "FE":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 181, 2, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + " / " + chargeid + "OE_QuotChargeU");
                                    break;
                                case "FI":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 180, 2, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + " / " + chargeid + "OI_QuotChargeU");
                                    break;
                                case "AE":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 217, 2, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + " / " + chargeid + "AE_QuotChargeU");
                                    break;
                                case "AI":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 215, 2, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + " / " + chargeid + "AI_QuotChargeU");
                                    break;
                            }
                            clearCharges();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Kindly Save the Quotation');", true);
                        return;
                    }
                }
                else
                {
                    if (btnAdd.ToolTip == "Update")
                    {
                        quotid = Convert.ToInt32(txtQuotation.Text);
                        int chargeid = charges.GetChargeid(HttpUtility.HtmlDecode(txtCharges.Text));
                        string amtval = "";
                        if ((ddlBase.Text == "BL") || (ddlBase.Text == "HAWB" || (ddlBase.Text == "AT ACTUALS") || (ddlBase.Text == "W/M")))
                        {
                            txtqty.Text = "1";
                        }
                        if (ddlBase.Text != "" && txtCharges.Text != "" && txtCurr.Text != "" && txt_sellrate.Text != "" && txtqty.Text != "")
                        {

                            string strbase = ddlBase.Text;
                            famount = Convert.ToDouble(txt_sellrate.Text) * Convert.ToDouble(hid_exrate.Value) * Convert.ToDouble(txtqty.Text); //CheckBase(strbase, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtex.Text));
                            txtamount.Text = famount.ToString();
                            txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
                            hid_amount.Value = Convert.ToDecimal(txtamount.Text).ToString("0.00");

                        }
                        if (txt_buyrate.Text != "" && txt_sellrate.Text != "")
                        {
                            Double dts = Convert.ToDouble(txt_buyrate.Text) * Convert.ToDouble(hid_exrate.Value) * Convert.ToDouble(txtqty.Text);

                            double ret = Convert.ToDouble(hid_amount.Value) - Math.Round(dts, 2);
                            txt_retention.Text = ret.ToString();
                        }
                        quotation.UpdateGrdQtyDetailsnew(quotid, ddlBase.Text, txtqty.Text);

                        /*   if (grd_Sizetype.Rows.Count > 0)
                           {
                               for (int j = 0; j <= grd_Sizetype.Rows.Count - 1; j++)
                               {
                                   string SType = grd_Sizetype.Rows[j].Cells[1].Text;
                                   CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                                   if (cbox.Checked == true)
                                   {
                                       amtval = "";
                                       TextBox txtBox = (TextBox)grd_Sizetype.Rows[j].FindControl("txt_Sizecount");


                                       if (ddl_product.Text == "Ocean Exports" || ddl_product.Text == "Ocean Imports")
                                       {

                                           if (SType != "CBM")
                                           {
                                               if (System.Text.RegularExpressions.Regex.IsMatch(txtBox.Text, "[^0-9]"))
                                               {
                                                   ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Numbers Only allowed');", true);
                                                   txtBox.Focus();
                                                   return;
                                               }
                                           }
                                       }
                                       else if (ddl_product.Text == "Air Exports" || ddl_product.Text == "Air Imports")
                                       {
                                           if (SType != "KGS")
                                           {
                                               if (System.Text.RegularExpressions.Regex.IsMatch(txtBox.Text, "[^0-9]"))
                                               {
                                                   ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Numbers Only allowed');", true);
                                                   txtBox.Focus();
                                                   return;
                                               }
                                           }
                                       }
                                       if (SType != ddlBase.Text)// if (ddlBase.Text != "BL" && SType != ddlBase.Text && ddlBase.Text != "HAWBL")
                                       {
                                           if (txtBox.Text == "")
                                           {


                                               if (ddlBase.Text != "BL" && ddlBase.Text != "HAWB")
                                               {
                                                   ScriptManager.RegisterStartupScript(btnAdd, typeof(Button), "logix", "alertify.alert('Select and Enter Expected Qty for Base type : " + ddlBase.Text + "');", true);
                                                   return;
                                               }
                                           }

                                       }
                                       else if (txtBox.Text == "")
                                       {
                                           ScriptManager.RegisterStartupScript(btnAdd, typeof(Button), "logix", "alertify.alert('Enter Exp.Qty for " + SType + "');", true);
                                           txtBox.Focus();
                                           //amtval = "1";
                                           return;
                                       }
                                       else
                                       {
                                           amtval = txtBox.Text;
                                       }
                                       double firstamt = 0;
                                       firstamt = Convert.ToDouble(txt_sellrate.Text);
                                       //double totalamt = firstamt * Convert.ToInt32(amtval);
                                       if (txt_sellrate.Text != "")
                                       {
                                           if (SType == ddlBase.Text)
                                           {
                                               if (ddlBase.Text != "" && txtCharges.Text != "" && txtCurr.Text != "" && txt_sellrate.Text != "")
                                               {

                                                   string strbase = ddlBase.Text;
                                                   famount = Convert.ToDouble(txt_sellrate.Text) * Convert.ToDouble(hid_exrate.Value) * Convert.ToDouble(amtval); //CheckBase(strbase, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtex.Text));
                                                   txtamount.Text = famount.ToString();
                                                   txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
                                                   hid_amount.Value = Convert.ToDecimal(txtamount.Text).ToString("0.00");

                                               }
                                               if (txt_buyrate.Text != "" && txt_sellrate.Text != "")
                                               {
                                                   Double dts = Convert.ToDouble(txt_buyrate.Text) * Convert.ToDouble(hid_exrate.Value) * Convert.ToDouble(amtval);

                                                   double ret = Convert.ToDouble(hid_amount.Value) - Math.Round(dts, 2);
                                                   txt_retention.Text = ret.ToString();
                                               }
                                               quotation.UpdateGrdChargeDetailsnew(quotid, HttpUtility.HtmlDecode(txtCharges.Text), txtCurr.Text.ToUpper(), Convert.ToDouble(txt_sellrate.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), ddlBase.Text, hid_oldData.Value, Convert.ToDouble(amtval), Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value));
                                               quotation.Updquotmarginper(quotid, HttpUtility.HtmlDecode(txtCharges.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDecimal(txt_margin.Text), Convert.ToDecimal(txt_retention.Text));
                                               check = true;
                                           }
                                       }
                                   }
                               }
                           }
                           if (check == false)
                           {
                               if (txt_sellrate.Text != "")
                               {
                                   if ((ddlBase.Text == "BL") || (ddlBase.Text == "HAWB" || (ddlBase.Text == "AT ACTUALS") || (ddlBase.Text == "W/M")))
                                   {
                                       if (ddlBase.Text != "" && txtCharges.Text != "" && txtCurr.Text != "" && txt_sellrate.Text != "")
                                       {

                                           string strbase = ddlBase.Text;
                                           famount = Convert.ToDouble(txt_sellrate.Text) * Convert.ToDouble(hid_exrate.Value) * 1; //CheckBase(strbase, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtex.Text));
                                           txtamount.Text = famount.ToString();
                                           txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
                                           hid_amount.Value = Convert.ToDecimal(txtamount.Text).ToString("0.00");

                                       }

                                       if (txt_buyrate.Text != "" && txt_sellrate.Text != "")
                                       {
                                           Double dts = Convert.ToDouble(txt_buyrate.Text) * Convert.ToDouble(hid_exrate.Value) * 1;

                                           double ret = Convert.ToDouble(hid_amount.Value) - dts;
                                           txt_retention.Text = ret.ToString("0.00");
                                       }
                                  

                                       quotation.UpdateGrdChargeDetailsnew(quotid, HttpUtility.HtmlDecode(txtCharges.Text), txtCurr.Text.ToUpper(), Convert.ToDouble(txt_sellrate.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), ddlBase.Text, hid_oldData.Value, 1, Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value));
                                       quotation.Updquotmarginper(quotid, HttpUtility.HtmlDecode(txtCharges.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDecimal(txt_margin.Text), Convert.ToDecimal(txt_retention.Text));

                                   }
                                   else
                                   {
                                       ScriptManager.RegisterStartupScript(btnAdd, typeof(Button), "logix", "alertify.alert('Select and Enter Expected Qty for Base type : " + ddlBase.Text + "');", true);
                                       return;
                                       //if (ddlBase.Text != "" && txtCharges.Text != "" && txtCurr.Text != "" && txtRate.Text != "")
                                       //{

                                       //    string strbase = ddlBase.Text;
                                       //    famount = Convert.ToDouble(hid_rate.Value) * Convert.ToDouble(hid_exrate.Value) * Convert.ToInt32(amtval); //CheckBase(strbase, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtex.Text));
                                       //    txtamount.Text = famount.ToString();
                                       //    txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
                                       //    hid_amount.Value = Convert.ToDecimal(txtamount.Text).ToString("0.00");

                                       //}
                                       //quotation.UpdateGrdChargeDetailsnew(quotid, HttpUtility.HtmlDecode(txtCharges.Text), txtCurr.Text.ToUpper(), Convert.ToDouble(txtRate.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), ddlBase.Text, hid_oldData.Value, 1, Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value));
                                   }
                               }
                           }*/
                        // quotation.InsertChargeDetailsnew(quotid, txtCharges.Text, txtCurr.Text.ToUpper(), Convert.ToDouble(txtRate.Text), ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(hid_expqty.Value), Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value));

                        if (txtBuying.Text != "")  //if (txtBuying.Text != "" && txt_buyrate.Text != "0") //hidee
                        {

                            if (txt_buyrate.Text != "")
                            {
                                buyingobj.UpdBuyingDetails(Convert.ToInt32(txtBuying.Text), chargeid, txtCurr.Text.ToUpper().Trim(), Convert.ToDouble(txt_buyrate.Text), ddlBase.Text);
                                dtbuying = buyingobj.SelBuyingDetailsnew(Convert.ToInt32(txtBuying.Text));
                                Session["Container"] = dtbuying;
                                int j;
                                txtbuygrid.Text = "";
                                double totb = 0, totb1 = 0;
                                for (j = 0; j <= dtbuying.Rows.Count - 1; j++)
                                {
                                    totb1 = Convert.ToDouble(dtbuying.Rows[j]["amount"]);
                                    totb = totb + totb1;
                                }
                                DataRow Drow = dtbuying.NewRow();
                                Drow["amount"] = totb.ToString("#,0.00");

                                dtbuying.Rows.Add(Drow);
                                txtbuygrid.Text = totb.ToString("#,0.00");
                                hid_totb.Value = totb.ToString("#,0.00");
                                grdBuying.DataSource = dtbuying;
                                grdBuying.DataBind();


                            }
                        }
                        //}

                        dtQuot = quotation.ChargeDetailsnew(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                        int i;
                        txtTotal.Text = "";
                        double tot = 0, tot1 = 0;
                        if (dtQuot.Rows.Count > 0)
                        {
                            for (i = 0; i <= dtQuot.Rows.Count - 1; i++)
                            {
                                tot1 = Convert.ToDouble(dtQuot.Rows[i]["amount"]);
                                tot = tot + tot1;
                            }
                            DataRow Drow1 = dtQuot.NewRow();
                            Drow1["amount"] = tot.ToString("#,0.00");
                            dtQuot.Rows.Add(Drow1);
                            txtTotal.Text = tot.ToString("#,0.00");
                            hid_tot.Value = tot.ToString("#,0.00");
                            grdQuotation.DataSource = dtQuot;
                            grdQuotation.DataBind();
                        }
                        else
                        {
                            hid_tot.Value = "0";
                        }
                        // yuvaraj 06/09/2022

                        DataTable dtss = buyingobj.Sellbuyingdeatils(Convert.ToInt32(txtBuying.Text), quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        if (dtss.Rows.Count > 0)
                        {

                            txtTotal.Text = "";
                            double totals = 0;
                            double amounts = 0;
                            int j;
                            txtbuygrid.Text = "";
                            double totb = 0, totb1 = 0;
                            for (i = 0; i <= dtss.Rows.Count - 1; i++)
                            {
                                totals = Convert.ToDouble(dtss.Rows[i]["amount"]);
                                amounts = amounts + totals;
                                totb1 = Convert.ToDouble(dtss.Rows[i]["sell"]);
                                totb = totb + totb1;
                            }
                            txtbuyings.Text = amounts.ToString("#,0.00");
                            hid_tot.Value = amounts.ToString("#,0.00");
                            txtselling.Text = totb.ToString("#,0.00");
                            Hidtotal.Value = totb.ToString("#,0.00");

                            //DataRow Drow6 = dtss.NewRow();
                            //Drow6["amount"] = tot.ToString("#,0.00");
                            //dtss.Rows.Add(Drow6);
                            //txtTotal.Text = tot.ToString("#,0.00");
                            //hid_tot.Value = tot.ToString("#,0.00");

                            //DataRow Drow3 = dtss.NewRow();
                            //Drow3["sell"] = totb.ToString("#,0.00");
                            //dtss.Rows.Add(Drow3);
                            //txtbuygrid.Text = totb.ToString("#,0.00");
                            ////.Value = totb.ToString("#,0.00");
                            //Hidtotal.Value = totb.ToString("#,0.00");

                            GrdBuysellcharge.DataSource = dtss;
                            GrdBuysellcharge.DataBind();
                        }

                        double profitamount = Convert.ToDouble(Hidtotal.Value) - Convert.ToDouble(hid_tot.Value);
                        if (profitamount != 0.0)
                        {
                            txtprofitamount.Text = profitamount.ToString("#,0.00");
                        }
                        else
                        {
                            txtprofitamount.Text = "";
                        }

                        //quotation.UpdateGrdChargeDetailsnew(quotid, HttpUtility.HtmlDecode(txtCharges.Text), txtCurr.Text.ToUpper(), Convert.ToDouble(txtRate.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), ddlBase.Text, hid_oldData.Value, Convert.ToInt32(hid_expqty.Value), Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value));
                        //dtQuot = quotation.ChargeDetailsnew(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                        //int i;
                        //txtTotal.Text = "";
                        //double tot = 0, tot1 = 0;
                        //for (i = 0; i <= grdQuotation.Rows.Count - 1; i++)
                        //{
                        //    tot1 = Convert.ToDouble(grdQuotation.Rows[i].Cells[6].Text);
                        //    tot = tot + tot1;
                        //}

                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Updated Successfully');", true);
                        grdQuotation.DataSource = dtQuot;
                        grdQuotation.DataBind();
                        txtTotal.Text = tot.ToString("#,0.00");
                        clearCharges();
                        //btnAdd.Text = "Add";
                        btnAdd.ToolTip = "Add";
                        btn_add.Attributes["class"] = "btn ico-add";

                        //RateLabel1.Visible = true;
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

        public void gridsize()
        {
            DataTable dtnew = new DataTable();
            dtnew = quotation.CheckMax2(quotid);
            if (dtnew.Rows.Count > 0)
            {
                string type = "";
                string type1 = "";
                string trantype = dtQuot.Rows[0]["trantype"].ToString();
                if ((trantype == "AE") || (trantype == "AI"))
                {
                    Label43.Text = "Chargeable Weight (KGS)";
                    DataTable Dt = new DataTable();
                    Dt.Columns.Add("checksbno");
                    Dt.Columns.Add("conttype");
                    Dt.Columns.Add("txt_Sizecount");
                    Dt.Rows.Add();
                    Dt.Rows[0]["conttype"] = "KGS";
                    Dt.Rows.Add();
                    Dt.Rows[1]["conttype"] = "PER TRUCK";
                    Dt.Rows.Add();
                    Dt.Rows[2]["conttype"] = "COTTON/PALLET";
                    Dt.Rows.Add();
                    Dt.Rows[3]["conttype"] = "AT ACTUALS";
                    grd_Sizetype.DataSource = Dt;
                    grd_Sizetype.DataBind();

                }
                else if (trantype == "OI")
                {
                    DataTable Dt = new DataTable();
                    Dt.Columns.Add("checksbno");
                    Dt.Columns.Add("conttype");
                    Dt.Columns.Add("txt_Sizecount");
                    Dt.Rows.Add();
                    Dt.Rows[0]["conttype"] = "CBM";
                    Dt.Rows.Add();
                    Dt.Rows[1]["conttype"] = "MT";
                    Dt.Rows.Add();
                    Dt.Rows[2]["conttype"] = "AT ACTUALS";
                    Dt.Rows.Add();
                    Dt.Rows[3]["conttype"] = "W/M";
                    grd_Sizetype.DataSource = Dt;
                    grd_Sizetype.DataBind();

                }
                for (int n = 0; n <= dtnew.Rows.Count - 1; n++)
                {
                    type1 = dtnew.Rows[n]["base"].ToString();

                    for (int i = 0; i <= grd_Sizetype.Rows.Count - 1; i++)
                    {
                        type = grd_Sizetype.Rows[i].Cells[1].Text;
                        if (type1 == type)
                        {
                            //for (int r = 0; r <= dtnew.Rows.Count - 1; r++)
                            //{
                            //string sitype = dtnew.Rows[r]["base"].ToString();
                            //if (sitype == type)
                            //{


                            //string qty = dtnew.Rows[n]["qty"].ToString(); 

                            CheckBox cbox = (CheckBox)grd_Sizetype.Rows[i].FindControl("checksbno");
                            cbox.Checked = true;
                            TextBox txt = (TextBox)grd_Sizetype.Rows[i].FindControl("txt_Sizecount");
                            if (grd_Sizetype.Rows[i].Cells[1].Text == "CBM" || grd_Sizetype.Rows[i].Cells[1].Text == "KGS")
                            {

                                if (dtnew.Rows[n]["qty"].ToString() != "")
                                {
                                    txt.Text = Convert.ToDecimal(dtnew.Rows[n]["qty"]).ToString();
                                }
                            }
                            else
                            {
                                if (dtnew.Rows[n]["qty"].ToString() != "")
                                {
                                    txt.Text = dtnew.Rows[n]["qty"].ToString();
                                }

                            }

                            if (txt.Text == "0" || txt.Text == "")
                            {
                                txt.Text = "";
                            }
                            //  txt_noofcont.Text = type1 + " X " + txt.Text;
                        }
                    }
                }
            }
        }

        private void clearCharges()
        {
            txtCharges.Text = "";
            txtCurr.Text = "";
            txtRate.Text = "";

            //ddlBase.Items.Add("--BASE--");
            // ddlFreight.Items.Add("--FREIGHT--");
            //ddlShipment.Items.Add("--SHIPMENT--");
            ddlBase.Enabled = true;
            btnAdd.Enabled = true;
            btnAdd.ForeColor = System.Drawing.Color.White;
            txtCharges.Enabled = true;
            txtCurr.Enabled = true;
            txtRate.Enabled = true;
            ddlBase.SelectedIndex = -1;
            txtqty.Text = "";
            txtex.Text = "";
            txtamount.Text = "";
            txt_sellrate.Text = "";
            txt_buyrate.Text = "";
            txt_retention.Text = "";
            txt_margin.Text = "";
            txtamount.Text = "";

        }

        protected void LoadQuoatation()
        {
            strtrantype = Session["StrTranType"].ToString();
            try
            {
                grdQuotaionDetails.Visible = true;
                if (lblHeader.Text == "Quotation Approval")
                {
                    dtQuot = quotation.ApprovalPendingDetails1(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                }
                else
                {
                    if (txtCustomer.Text != "" && hdf_customerid.Value != "")
                    {
                        dtQuot = quotation.InquiryDetailsCustqnew(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hdf_customerid.Value.ToString()));
                    }
                    else
                    {
                        dtQuot = quotation.InquiryDetailsnew(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    }
                }
                //getvaluereuse();
                if (dtQuot.Rows.Count > 0)
                {
                    grdBuyingDetails.Visible = false;
                    grdQuotaionDetails.DataSource = dtQuot;
                    grdQuotaionDetails.DataBind();
                    Panel6.Visible = false;
                    ViewState["inquiry"] = dtQuot;
                    pnlJobAE.Visible = true;
                    this.popupQuot.Show();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('No Inquiry available to modify');", true);
                }
                btnSave.Enabled = true;
                btnSave.ForeColor = System.Drawing.Color.White;
                UserRights();

                BuyRateBtn.Visible = true;
                GenQuotBtn.Visible = true;


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }





        }

        protected void linkQuotation_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddl_product.SelectedItem.Text == "")
                {
                    Session["StrTranType"] = "";
                }
                Panel4.Visible = true;
                grdQuotaionDetails.Visible = true;
                Panel6.Visible = false;
                LoadQuoatation();
                BuyRateBtn.Visible = true;
                GenQuotBtn.Visible = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }



        }

        protected void grdQuotaionDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdQuotaionDetails, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";


                    Label lblCustomer = (Label)e.Row.FindControl("customer");
                    string tooltip = lblCustomer.Text;
                    e.Row.Cells[1].Attributes.Add("title", tooltip);

                    Label lblCustomer1 = (Label)e.Row.FindControl("pol");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[2].Attributes.Add("title", tooltip1);

                    Label lblCustomer2 = (Label)e.Row.FindControl("pod");
                    string tooltip2 = lblCustomer2.Text;
                    e.Row.Cells[3].Attributes.Add("title", tooltip2);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void grdQuotaionDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_product.SelectedItem.Text == "")
            {
                Session["StrTranType"] = "";
            }
            btn_approve.Enabled = true;
            btnSave.Enabled = true;
            strtrantype = Session["StrTranType"].ToString();
            try
            {
                OldQuotNo = 0;
                DataTable dt;
                grdQuotation.Visible = true;
                //btnsend.Enabled = false;
                if (grdQuotaionDetails.Rows.Count > 0)
                {
                    grd_Sizetype.Enabled = true;// add 20/1/23
                    int index = grdQuotaionDetails.SelectedRow.RowIndex;
                    txtQuotation.Text = Convert.ToString(quotid);
                    txtQuotation.Text = ((Label)grdQuotaionDetails.Rows[Convert.ToInt32(index)].Cells[0].FindControl("inquiryid")).Text;
                    quotid = Convert.ToInt32(txtQuotation.Text);
                    hid_quotno.Value = txtQuotation.Text;
                    dtQuot = quotation.GetInquiryHeadDetails(quotid, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));

                    ViewState["Approvalby"] = dtQuot;
                    if (dtQuot.Rows.Count > 0)
                    {
                        ddl_product.SelectedItem.Text = dtQuot.Rows[0]["product"].ToString();
                        Session["StrTranType"] = dtQuot.Rows[0]["strtrantype"].ToString();
                        DataTable dtterms = new DataTable();

                        //dtterms = quotation.Getterms(ddlShipment.Text, dtQuot.Rows[0]["strtrantype"].ToString());
                        //if (dtterms.Rows.Count > 0)
                        //{
                        //    txtterms.Text = dtterms.Rows[0]["terms"].ToString();
                        //    txt_terms.Text = dtterms.Rows[0]["terms"].ToString();
                        //}
                        txtQuotation.Text = Convert.ToString(quotid);
                        OldQuotNo = Convert.ToInt32(txtQuotation.Text);
                        hdf_OldQuotNo.Value = OldQuotNo.ToString();
                        customerid = Convert.ToInt32(dtQuot.Rows[0]["customerid"].ToString());
                        GetAllMailIds(customerid);
                        hdf_customerid.Value = Convert.ToString(customerid);
                        intpol = Convert.ToInt32(dtQuot.Rows[0]["pol"].ToString());
                        hdf_POL.Value = Convert.ToString(intpol);
                        intpor = Convert.ToInt32(dtQuot.Rows[0]["por"].ToString());
                        hdf_POR.Value = Convert.ToString(intpor);
                        intpod = Convert.ToInt32(dtQuot.Rows[0]["pod"].ToString());
                        hdf_POD.Value = Convert.ToString(intpod);
                        intfd = Convert.ToInt32(dtQuot.Rows[0]["fd"].ToString());
                        hdf_FD.Value = Convert.ToString(intfd);
                        cargoid = Convert.ToInt32(dtQuot.Rows[0]["cargoid"].ToString());
                        hdf_cargoid.Value = Convert.ToString(cargoid);
                        sales = Convert.ToInt32(dtQuot.Rows[0]["marketedby"].ToString());
                        hdf_salesperson.Value = Convert.ToString(sales);
                        prepared = Convert.ToInt32(dtQuot.Rows[0]["preparedby"].ToString());

                        string trantype = dtQuot.Rows[0]["trantype"].ToString();




                        hazard = Convert.ToInt32(dtQuot.Rows[0]["hazardous"].ToString());
                        hdf_Hazard.Value = Convert.ToString(hazard);
                        txtDescription.Text = dtQuot.Rows[0]["descn"].ToString();
                        string validtill = dtQuot.Rows[0]["validtill"].ToString();
                        txtValidTill.Text = DateTime.Parse(dtQuot.Rows[0]["validtill"].ToString()).ToString("dd/MM/yyyy");

                        string validtill1 = dtQuot.Rows[0]["inquirydate"].ToString();
                        txtDate.Text = DateTime.Parse(dtQuot.Rows[0]["inquirydate"].ToString()).ToString("dd/MM/yyyy");

                        txtterms.Text = dtQuot.Rows[0]["Terms"].ToString();
                        txt_terms.Text = dtQuot.Rows[0]["terms"].ToString();
                        txtRemarks.Text = dtQuot.Rows[0]["remarks"].ToString();
                        // txtBrokerage.Text = dtQuot.Rows[0]["brokerage"].ToString();
                        Strshipment = quotation.GetShipment(Char.Parse(dtQuot.Rows[0]["stype"].ToString()));
                        if (strtrantype == "AE" || strtrantype == "AI")
                        {
                            strfstatus = quotation.GetFrightAEAI(Char.Parse(dtQuot.Rows[0]["fstatus"].ToString()));
                        }
                        else
                        {
                            strfstatus = quotation.GetFright(Char.Parse(dtQuot.Rows[0]["fstatus"].ToString()));
                        }
                        DataTable dtversion = new DataTable();
                        dtversion = quotation.SpGetversion(quotid, Convert.ToInt32(Session["LoginBranchid"]));
                        if (dtversion.Rows.Count > 0)
                        {
                            ddl_version.Items.Clear();
                            for (int i = 0; i <= dtversion.Rows.Count - 1; i++)
                            {
                                ddl_version.Items.Add(dtversion.Rows[i]["version"].ToString());
                            }
                        }
                        if (dtQuot.Rows[0]["enquiryno"].ToString() != "")
                        {
                            txt_enquiry.Text = DateTime.Parse(dtQuot.Rows[0]["enquiryno"].ToString()).ToString("dd/MM/yyyy");
                        }
                        txt_value.Text = dtQuot.Rows[0]["value"].ToString();
                        DataTable dtinco = new DataTable();
                        hdn_Incoid.Value = dtQuot.Rows[0]["inco"].ToString();
                        if (hdn_Incoid.Value != "")
                        {

                            dtinco = bookingobj.SelMasterInco(Convert.ToInt32(hdn_Incoid.Value));
                        }
                        txt_custpono.Text = dtQuot.Rows[0]["cuspono"].ToString();
                        txt_routing.Text = dtQuot.Rows[0]["routing"].ToString();
                        txt_transittime.Text = dtQuot.Rows[0]["transittime"].ToString();
                        txt_pieces.Text = dtQuot.Rows[0]["pieces"].ToString();
                        if (Session["StrTranType"].ToString() == "FI" || Session["StrTranType"].ToString() == "FE")
                        {
                            txt_noofcont.Text = dtQuot.Rows[0]["noofcont"].ToString();
                        }
                        else
                        {
                            txt_noofcont.Text = dtQuot.Rows[0]["chrageblewt"].ToString();
                        }
                        txt_grwt.Text = dtQuot.Rows[0]["grwt"].ToString();
                        txt_units.Text = dtQuot.Rows[0]["noofunits"].ToString();
                        txt_volume.Text = dtQuot.Rows[0]["volume"].ToString();
                        txt_dim.Text = dtQuot.Rows[0]["dimension"].ToString();
                        txt_value.Text = dtQuot.Rows[0]["value"].ToString();

                        //hdnCarrier.Value = dtQuot.Rows[0]["carrier"].ToString();

                        //if (hdnCarrier.Value != "0")
                        //{
                        //    string data = custobj.GetCustomername(Convert.ToInt32(dtQuot.Rows[0]["carrier"]));
                        //    if (data != "0")
                        //    {
                        //        txtCarrier.Text = data;
                        //        TextBox1.Text = custobj.GetCustomerAddress(Convert.ToInt32(dtQuot.Rows[0]["carrier"]));
                        //    }
                        //    else
                        //    {
                        //        txtCarrier.Text = "";
                        //    }
                        //}

                        if (dtinco.Rows.Count > 0)
                        {
                            txtInco.Text = dtinco.Rows[0]["incocode"].ToString();
                        }

                        if (string.IsNullOrEmpty(dtQuot.Rows[0]["scope"].ToString()) != true)
                        {
                            movementtype = Convert.ToInt32(dtQuot.Rows[0]["scope"].ToString());
                            if (movementtype == 1)
                            {
                                ddl_moveTypes.SelectedValue = "1";
                            }
                            else if (movementtype == 2)
                            {
                                ddl_moveTypes.SelectedValue = "2";
                            }
                            else if (movementtype == 3)
                            {
                                ddl_moveTypes.SelectedValue = "3";
                            }
                            else if (movementtype == 4)
                            {
                                ddl_moveTypes.SelectedValue = "4";
                            }
                            else if (movementtype == 0)
                            {
                                ddl_moveTypes.SelectedValue = "0";
                            }


                        }
                        else
                        {
                            ddl_moveTypes.SelectedValue = "0";
                        }
                        txt_totdays.Text = dtQuot.Rows[0]["totaldays"].ToString();
                        if (dtQuot.Rows[0]["feasibility"].ToString() != "")
                        {
                            ddl_feasi.SelectedValue = dtQuot.Rows[0]["feasibility"].ToString();
                        }
                        //ddl_version.Text = dtQuot.Rows[0]["version"].ToString();
                        //if (Session["StrTranType"].ToString() == "FI" || Session["StrTranType"].ToString() == "AI")
                        //{
                        //intcustid = dtQuot.Rows[0]["consigneeid"].ToString();
                        //hdn_Consigneeid.Value = dtQuot.Rows[0]["consigneeid"].ToString();
                        //if (intcustid != "")
                        //{

                        //    txt_consignee.Text = custobj.GetCustomername(Convert.ToInt32(intcustid));

                        //    txt_consigneemulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(intcustid));

                        //}
                        //DataTable dtmail = new DataTable();
                        //string Shipmail = custobj.GetCusMailaddrs(Convert.ToInt32(dtBuying.Rows[0]["customerid"].ToString()));

                        //if (Shipmail != "")
                        //{
                        //    dtmail = new DataTable();
                        //    dtmail.Columns.Add("email");
                        //    dtmail.Columns.Add("Cname");
                        //    dtmail.Rows.Add(Shipmail, "Consignee");
                        //    grdCMail.DataSource = dtmail;
                        //    grdCMail.DataBind();
                        //    ViewState["CurrentData"] = dtmail;
                        //}
                        //}
                        //else
                        //{
                        if (dtQuot.Rows[0]["shipperid"].ToString() != "0")
                        {
                            hdn_shipperid.Value = dtQuot.Rows[0]["shipperid"].ToString();
                            if (hdn_shipperid.Value != "")
                            {

                                txt_shiper.Text = custobj.GetCustomername(Convert.ToInt32(dtQuot.Rows[0]["shipperid"].ToString()));
                                // txtCustomer.Text = txt_shiper.Text;
                                txt_shipermulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(dtQuot.Rows[0]["shipperid"].ToString()));
                            }
                        }
                        //DataTable dtmail = new DataTable();
                        //string Shipmail = custobj.GetCusMailaddrs(Convert.ToInt32(dtBuying.Rows[0]["customerid"].ToString()));

                        //if (Shipmail != "")
                        //{
                        //    dtmail = new DataTable();
                        //    dtmail.Columns.Add("email");
                        //    dtmail.Columns.Add("Cname");
                        //    dtmail.Rows.Add(Shipmail, "Shipper");
                        //    grdCMail.DataSource = dtmail;
                        //    grdCMail.DataBind();
                        //    ViewState["CurrentData"] = dtmail;
                        //}

                        //}
                        if (dtQuot.Rows[0]["approvedby"] != System.DBNull.Value)
                        {
                            app = Convert.ToInt32(dtQuot.Rows[0]["approvedby"].ToString());
                        }
                        if (app != 0)
                        {
                            // btnsend.Enabled = true;
                        }

                        hdf_app.Value = app.ToString();

                        if (dtQuot.Rows[0]["business"].ToString() == "A")
                        {
                            ddl_controlledby.SelectedValue = "A";

                        }
                        else
                        {
                            ddl_controlledby.SelectedValue = "O";
                        }
                    }
                    txtapprovedby.Text = dtQuot.Rows[0]["approvedbyname"].ToString();
                    dtgroup = customer.GetCustomernamegroupid(customerid);
                    if (dtgroup.Rows.Count > 0)
                    {


                        txtCustomer.Text = dtgroup.Rows[0]["customername"].ToString();
                        txtaddress.Text = dtgroup.Rows[0]["address"].ToString();
                        //if (dtgroup.Rows[0]["groupid"].ToString() != null)
                        if (!string.IsNullOrEmpty(dtgroup.Rows[0]["groupid"].ToString()))
                        {
                            hidgroupid.Value = dtgroup.Rows[0]["groupid"].ToString();
                            dtgr = objoua.RetrieveCustGroupDetails(Convert.ToInt32(hidgroupid.Value));

                            if (dtgr.Rows.Count > 0)
                            {
                                txtgroupcustomer.Text = dtgr.Rows[0]["groupname"].ToString();
                                txtgroupAddress.Text = dtgr.Rows[0]["address"].ToString();

                            }

                            Bind_outstandingdetails();

                        }


                    }



                    // txtCustomer.Text = customer.GetCustomername(customerid);
                    txtPOL.Text = port.GetPortname(intpol);
                    txtPOD.Text = port.GetPortname(intpod);
                    txtPOR.Text = port.GetPortname(intpor);
                    txtFD.Text = port.GetPortname(intfd);
                    txtCargo.Text = cargo.GetCargoname(cargoid);
                    txtSalesPerson.Text = employee.GetEmployeeName(sales);
                    //txtPreparedBy.Text = "Prepared By : " + employee.GetEmployeeName(prepared);
                    txtPreparedBy.Text = employee.GetEmployeeName(prepared);

                    //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                    dt = obj_MasterPort.SelPortName4typepadimg(txtFD.Text.ToUpper(), Session["StrTranType"].ToString());
                    fdflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    dt = obj_MasterPort.SelPortName4typepadimg(txtPOR.Text.ToUpper(), Session["StrTranType"].ToString());
                    porflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    dt = obj_MasterPort.SelPortName4typepadimg(txtPOD.Text.ToUpper(), Session["StrTranType"].ToString());
                    podflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    dt = obj_MasterPort.SelPortName4typepadimg(txtPOL.Text.ToUpper(), Session["StrTranType"].ToString());
                    flagimg.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                    //Bhuvana
                    //int crmid = objcrm.GetCRMid(Convert.ToInt32(txtQuotation.Text.ToUpper()), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    //if (crmid != 0)
                    //{
                    //    txtcrm.Text = crmid.ToString();
                    //}
                    //else
                    //{
                    //    txtcrm.Text = "";
                    //}
                    if (hazard == 1)
                    {
                        chkHazard.Checked = true;
                    }
                    else
                    {
                        chkHazard.Checked = false;
                    }
                    ddlShipment.Text = Strshipment;
                    ddlFreight.Text = strfstatus;
                    //dtQuot = quotation.ChargeInquiryDetailsnew(quotid, "");
                    gridsize();
                    int k;
                    txtTotal.Text = "";
                    double tot = 0, tot1 = 0;
                    //if (dtQuot.Rows.Count > 0)
                    //{
                    //    for (k = 0; k <= dtQuot.Rows.Count - 1; k++)
                    //    {
                    //        tot1 = Convert.ToDouble(dtQuot.Rows[k]["amount"]);
                    //        tot = tot + tot1;
                    //    }
                    //    DataRow Drow1 = dtQuot.NewRow();
                    //    //Drow1["base"] = tot.ToString("#,0.00");
                    //    Drow1["amount"] = tot.ToString("#,0.00");
                    //    dtQuot.Rows.Add(Drow1);
                    //    txtTotal.Text = tot.ToString("#,0.00");
                    //    hid_tot.Value = tot.ToString("#,0.00");
                    //    grdQuotation.DataSource = dtQuot;
                    //    grdQuotation.DataBind();
                    //}
                    //else
                    //{
                    //    hid_tot.Value = "0";
                    //}

                    //}



                    btnApp.Enabled = true;
                    btnApp.ForeColor = System.Drawing.Color.White;
                    btnSave.Text = "Update";
                    btnSave.ToolTip = "Update";
                    btn_save.Attributes["class"] = "btn ico-update";
                    RateLabel1.Visible = true;
                    Dt = quotation.CheckInquiryForBookingFromQno(quotid, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), "BB");
                    if (Dt.Rows.Count > 0)
                    {
                        //string Customer = custobj.GetCustomername(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()));
                        string Customer = quotation.quotbuyingget(Convert.ToInt32(Dt.Rows[0]["buyingno"].ToString()));
                        string pol = portobj.GetPortname(Convert.ToInt32(Dt.Rows[0]["pol"].ToString()));
                        string pod = portobj.GetPortname(Convert.ToInt32(Dt.Rows[0]["pod"].ToString()));
                        string status = "";
                        if (Dt.Rows[0]["stype"].ToString() == "F")
                        {
                            status = "FCL";
                        }
                        else if (Dt.Rows[0]["stype"].ToString() == "L")
                        {
                            status = "LCL";
                        }
                        else if (Dt.Rows[0]["stype"].ToString() == "A")
                        {
                            status = "AIR";
                        }
                        string buying = Customer + "/" + pol + "-" + pod + "/" + status;
                        txtBuying.Text = Dt.Rows[0]["buyingno"].ToString();
                        hid_rateid.Value = Dt.Rows[0]["buyingno"].ToString();
                        if (txtBuying.Text == "0")
                        {
                            txtBuyingDetails.Text = "";
                        }
                        else
                        {
                            txtBuyingDetails.Text = buying;
                        }
                        //GetBuyingGrid();

                        // yuvaraj 06/09/2022
                        DataTable dtss = buyingobj.SelInquirybuyingdetails(Convert.ToInt32(txtBuying.Text), quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        //    if (dtss.Rows.Count > 0)
                        //    {
                        //        int i;
                        //        txtTotal.Text = "";
                        //        tot = 0;

                        //        tot1 = 0;
                        //        txtbuygrid.Text = "";
                        //        double totb = 0, totb1 = 0;
                        //        for (i = 0; i <= dtss.Rows.Count - 1; i++)
                        //        {
                        //            tot1 = Convert.ToDouble(dtss.Rows[i]["amount"]);
                        //            tot = tot + tot1;
                        //            totb1 = Convert.ToDouble(dtss.Rows[i]["sell"]);
                        //            totb = totb + totb1;
                        //        }
                        //        txtbuyings.Text = tot.ToString("#,0.00");
                        //        hid_tot.Value = tot.ToString("#,0.00");
                        //        txtselling.Text = totb.ToString("#,0.00");
                        //        Hidtotal.Value = totb.ToString("#,0.00");

                        //        //DataRow Drow6 = dtss.NewRow();
                        //        //Drow6["amount"] = tot.ToString("#,0.00");
                        //        //dtss.Rows.Add(Drow6);
                        //        //txtTotal.Text = tot.ToString("#,0.00");
                        //        //hid_tot.Value = tot.ToString("#,0.00");

                        //        //DataRow Drow3 = dtss.NewRow();
                        //        //Drow3["sell"] = totb.ToString("#,0.00");
                        //        //dtss.Rows.Add(Drow3);
                        //        //txtbuygrid.Text = totb.ToString("#,0.00");
                        //        ////.Value = totb.ToString("#,0.00");
                        //        //Hidtotal.Value = totb.ToString("#,0.00");

                        //        GrdBuysellcharge.DataSource = dtss;
                        //        GrdBuysellcharge.DataBind();
                        //    }

                        //    double profitamount = Convert.ToDouble(Hidtotal.Value) - Convert.ToDouble(hid_tot.Value);
                        //    if (profitamount != 0.0)
                        //    {
                        //        txtprofitamount.Text = profitamount.ToString("#,0.00");
                        //    }
                        //    else
                        //    {
                        //        txtprofitamount.Text = "";
                        //    }
                        //}
                        //else
                        //{
                        //    DataTable dtl = new DataTable();
                        //    baseFil();
                        //}
                        if (blnexists == true)
                        {
                            btnApp.Enabled = true;
                            btnApp.ForeColor = System.Drawing.Color.White;
                            btnclose.Enabled = true;
                            btnclose.ForeColor = System.Drawing.Color.White;
                            blnapprove = false;

                        }
                        else
                        {
                            btnApp.Enabled = true;
                            btnApp.ForeColor = System.Drawing.Color.Gray;

                            btnclose.Enabled = true;
                            btnclose.ForeColor = System.Drawing.Color.White;
                            txtCargeEnable();
                            if (lblHeader.Text == "Inquiry")
                            {
                                ddlBase.Enabled = false;
                                txtUnable();
                            }
                            blnapprove = false;
                        }


                        //BaseFill();

                    }
                    if (lblHeader.Text == "Inquiry")
                    {
                        btnApp.Enabled = true;
                        btnApp.ForeColor = System.Drawing.Color.White;
                    }
                    btnclose.Text = "Cancel";
                    btnclose.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                    btnSave.Enabled = true;
                    btnSave.ForeColor = System.Drawing.Color.White;
                    baseFil();
                    UserRights();
                    if (dtQuot.Rows.Count > 0)
                    {

                        if (app != 0)
                        {
                            //  btnApp.Enabled = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }



            DataTable buytable = new DataTable();

            buytable = quotation.GetRateId(quotid);


            RateLabel1.Text = buytable.Rows[0]["buyingno"].ToString();



            if (RateLabel1.Text != "" && RateLabel1.Text != "0")
            {
                DataTable quottable = new DataTable();

                quottable = quotation.GetQuotId(Convert.ToInt16(RateLabel1.Text));

                if (quottable.Rows.Count > 0)
                {
                    GenQuotBtn.Text = quottable.Rows[0]["quotno"].ToString();


                }
            }



            //buytable = quotation.GetRateId(quotid);



            BuyRateBtn.Visible = true;
            GenQuotBtn.Visible = true;
        }

        protected void grdQuotation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdQuotation, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                    //Label lblCustomer = (Label)e.Row.FindControl("Charges");
                    //string tooltip = lblCustomer.Text;
                    //e.Row.Cells[0].Attributes.Add("title", tooltip);
                    //Label lblCustomer1 = (Label)e.Row.FindControl("curr");
                    //string tooltip1 = lblCustomer1.Text;
                    //e.Row.Cells[1].Attributes.Add("title", tooltip);
                    //Label lblCustomer2 = (Label)e.Row.FindControl("Rate");
                    //string tooltip2 = lblCustomer2.Text;
                    //e.Row.Cells[2].Attributes.Add("title", tooltip);
                    //Label lblCustomer3 = (Label)e.Row.FindControl("Base");
                    //string tooltip3 = lblCustomer3.Text;
                    //e.Row.Cells[3].Attributes.Add("title", tooltip);


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
                if (ddl_product.SelectedItem.Text == "")
                {
                    Session["StrTranType"] = "";
                }
                string date = Logobj.GetDate().ToShortDateString();
                date = Utility.fn_ConvertDate(date.ToString());
                grdQuotation.Visible = true;
                if (grdQuotation.Rows.Count > 0)
                {
                    baseFil();
                    int index = grdQuotation.SelectedRow.RowIndex;
                    //Label txt2 = (Label)grdQuotation.Rows[index].Cells[0].FindControl("Charges");
                    //Label txt3 = (Label)grdQuotation.Rows[index].Cells[2].FindControl("rate");

                    txtqty.Text = grdQuotation.SelectedRow.Cells[3].Text;
                    hid_expqty.Value = grdQuotation.SelectedRow.Cells[3].Text;
                    //txtCharges.Text = grdQuotation.SelectedRow.Cells[0].Text;
                    txtCurr.Text = grdQuotation.SelectedRow.Cells[1].Text;
                    txtCharges.Text = grdQuotation.SelectedRow.Cells[0].Text;
                    //hid_charge.Value = txtCharges.Text;
                    // txtCurr.Text = txt3.Text;
                    txt_sellrate.Text = grdQuotation.SelectedRow.Cells[2].Text;
                    hid_sellrate.Value = grdQuotation.SelectedRow.Cells[2].Text;
                    int chargeid = charges.GetChargeid(txtCharges.Text);
                    ddlBase.SelectedValue = grdQuotation.SelectedRow.Cells[4].Text;
                    if (grdQuotation.SelectedRow.Cells[5].Text == "&nbsp;")
                    {
                        txtex.Text = INVOICEobj.GetExRate(txtCurr.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDate(date.ToString())), "R", Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                        hid_exrate.Value = txtex.Text;
                    }
                    else
                    {
                        txtex.Text = grdQuotation.SelectedRow.Cells[5].Text;
                        hid_exrate.Value = grdQuotation.SelectedRow.Cells[5].Text;
                    }
                    DataTable dt = new DataTable();
                    dt = quotation.Getbuyingdtls(chargeid, Convert.ToInt32(hid_rateid.Value), ddlBase.SelectedValue);
                    if (dt.Rows.Count > 0)
                    {
                        txt_buyrate.Text = Convert.ToDouble(dt.Rows[0]["rate"]).ToString("0.00");
                    }
                    //if (grdBuying.Rows.Count > 0)
                    //{
                    //    if (index < grdBuying.Rows.Count)
                    //    {
                    //        txt_buyrate.Text = grdBuying.Rows[index].Cells[2].Text;
                    //    }
                    //    else
                    //    {
                    //        txt_buyrate.Text = "0";
                    //    }
                    //}
                    else
                    {
                        txt_buyrate.Text = "0";
                    }
                    if (txt_buyrate.Text != "" && txt_sellrate.Text != "")
                    {
                        double ret = Convert.ToDouble(txt_sellrate.Text) - Convert.ToDouble(txt_buyrate.Text);
                        txt_retention.Text = ret.ToString();
                    }
                    if (txt_buyrate.Text == "0" || txt_buyrate.Text == "0.00" || txt_buyrate.Text == "")
                    {
                        txt_margin.Text = "0";
                    }
                    else
                    {

                        double margin = (Convert.ToDouble(txt_sellrate.Text) - Convert.ToDouble(txt_buyrate.Text)); // yuvaraj * 100    
                        double margin1 = (margin / Convert.ToDouble(txt_buyrate.Text) * 100);

                        txt_margin.Text = Convert.ToDouble(margin1).ToString("0.00");

                        //double margin = ((Convert.ToDouble(txt_sellrate.Text)) / (Convert.ToDouble(txt_buyrate.Text)) * 100);
                        //txt_margin.Text = Convert.ToDouble(margin).ToString("0.00");

                    }

                    txtamount.Text = grdQuotation.SelectedRow.Cells[6].Text;
                    ddlBase.Enabled = false;
                    oldbase = ddlBase.SelectedValue;
                    hid_oldData.Value = oldbase;
                    txtCharges.Enabled = false;
                    txtCurr.Enabled = true;
                    txtRate.Enabled = true;
                    btnAdd.Enabled = true;

                    btnSave.Enabled = false;
                    btnAdd.ForeColor = System.Drawing.Color.White;

                    btnSave.ForeColor = System.Drawing.Color.Gray;

                    // btnAdd.Text = "Update";
                    btnAdd.ToolTip = "Update";
                    btn_add.Attributes["class"] = "btn ico-update";
                    UserRights();
                    DataSet dsQuot = new DataSet();
                    dtQuot = quotation.GetInquiryHeadDetails(Convert.ToInt32(txtQuotation.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    dtQuot.TableName = "Test1";
                    dsQuot.Tables.Add("Test1");
                    // ViewState["Approvalby"] = dtQuot;
                    //  DataTable dtappr = (DataTable)ViewState["Approvalby"];

                    if (dtQuot.Rows.Count > 0)
                    {
                        int dtapprvalue = Convert.ToInt32(dtQuot.Rows[0]["approvedby"].ToString());
                        if (dtapprvalue != 0)
                        {
                            //  btnApp.Enabled = false;
                            btnApp.ForeColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            btnApp.Enabled = true;
                            btnApp.ForeColor = System.Drawing.Color.White;
                        }

                    }


                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


            DataTable buytable = new DataTable();

            buytable = quotation.GetRateId(quotid);

            string rateid = RateLabel1.Text;

            RateLabel1.Text = buytable.Rows[0]["buyingno"].ToString();



            DataTable quottable = new DataTable();

            quottable = quotation.GetQuotId(Convert.ToInt16(RateLabel1.Text));

            string quotno = GenQuotBtn.Text;

            GenQuotBtn.Text = quottable.Rows[0]["quotno"].ToString();
        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            try
            {
                DT_bind.Columns.Add("Credit/Outstanding", typeof(string));
                DT_bind.Columns.Add("Details", typeof(string));
                DT_bind.Rows.Add("Credit Days");
                DT_bind.Rows.Add("Credit Amount");
                DT_bind.Rows.Add("Over Due Days");
                DT_bind.Rows.Add("Over Due Amount");
                DT_bind.Rows.Add("Total OS Amt");
                test.DataSource = DT_bind;
                test.DataBind();

                if (btnclose.ToolTip == "Cancel")
                {
                    JobInput.Text = "";
                    //if (Session["trantype_process"] != null)
                    //{
                    //    ddl_product.SelectedIndex = 0;
                    //    Session["StrTranType"] = null;
                    //}
                    ddl_product.SelectedIndex = 0;
                    clearCharges();
                    clear();
                    RateLabel1.Visible = false;
                    btnAdd.Enabled = false;
                    hdf_salesperson.Value = "";
                    ddlBase.SelectedIndex = 0;
                    ddlFreight.SelectedIndex = 0;
                    ddlShipment.SelectedIndex = 0;
                    //ddlpdt.SelectedValue = "--Product--";

                    btnSave.Text = "Save";
                    btnAdd.Text = "Add";

                    btnSave.ToolTip = "Save";
                    btn_save.Attributes["class"] = "btn ico-save";
                    btnAdd.ToolTip = "Add";
                    btn_add.Attributes["class"] = "btn ico-add";
                    txtQuotation.Text = "";
                    if (lblHeader.Text == "Quotation Approval")
                    {
                        btnApp.Enabled = true;
                        btnApp.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        btnApp.Enabled = false;
                        btnApp.ForeColor = System.Drawing.Color.Gray;
                    }
                    linkQuotation.Enabled = true;
                    grdQuotation.Enabled = false;

                    btnSave.Enabled = false;
                    btnSave.ForeColor = System.Drawing.Color.Gray;
                    btnclose.Enabled = true;
                    //btnView.Enabled = true;
                    btnclose.ForeColor = System.Drawing.Color.White;
                    //btnView.ForeColor = System.Drawing.Color.White;
                    btnApp.Enabled = false;
                    btnApp.ForeColor = System.Drawing.Color.Gray;
                    txtEnable();
                    btnclose.Text = "Back";
                    btnclose.ToolTip = "Back";
                    btn_back1.Attributes["class"] = "btn ico-back";
                    ddl_controlledby.SelectedValue = "0";
                    txtDate.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                    txtValidTill.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                    linkQuotation.Enabled = true;

                    grdBuying.DataSource = null;
                    grdBuying.DataBind();

                    grdQuotation.DataSource = null;
                    grdQuotation.DataBind();

                    grdQuotation.DataSource = Utility.Fn_GetEmptyDataTable();
                    grdQuotation.DataBind();

                    grdBuying.DataSource = Utility.Fn_GetEmptyDataTable();
                    grdBuying.DataBind();

                    // grdmail.DataSource = Utility.Fn_GetEmptyDataTable();
                    grdBuying.DataBind();

                    // yuvaraj 06/09/2022
                    GrdBuysellcharge.DataSource = null;
                    GrdBuysellcharge.DataBind();
                    GrdBuysellcharge.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdBuysellcharge.DataBind();

                    // End                    

                    if (ddl_product.SelectedValue == "0")
                    {
                        DataTable Dt = new DataTable();
                        //chkContainerList.Items.Clear();
                        DataSet ds1 = new DataSet();
                        DataTable dtpkg1 = new DataTable();
                        ds1 = container.GetContainersize();
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            dtpkg1 = ds1.Tables[0];
                            Dt.Columns.Add("checksbno");
                            Dt.Columns.Add("conttype");
                            Dt.Columns.Add("txt_Sizecount");

                            if (dtpkg1.Rows.Count > 0)
                            {
                                //Dt.Rows.Add();
                                //Dt.Rows[0]["conttype"] = "CBM";
                                for (int i = 0; i <= dtpkg1.Rows.Count - 1; i++)
                                {
                                    Dt.Rows.Add();
                                    //Dt.Rows[0]["conttype"] = "CBM";
                                    Dt.Rows[i]["conttype"] = dtpkg1.Rows[i]["conttype"].ToString();
                                }


                                Dt.Rows.Add();
                                Dt.Rows[dtpkg1.Rows.Count]["conttype"] = "CBM";
                                Dt.Rows.Add();
                                Dt.Rows[dtpkg1.Rows.Count + 1]["conttype"] = "MT";
                                //Dt.Rows.Add();
                                //Dt.Rows[dtpkg1.Rows.Count + 2]["conttype"] = "AT ACTUALS";
                                grd_Sizetype.DataSource = Dt;
                                grd_Sizetype.DataBind();
                            }
                            // chkContainerList.DataSource = dtpkg1;
                            // chkContainerList.DataTextField = "conttype";
                            // chkContainerList.DataValueField = "conttype";
                            // chkContainerList.DataBind();
                            //chkContainerList.Items.Insert(1, "BL");
                            //chkContainerList.Items.Insert(2, "CBM");
                            //chkContainerList.Items.Insert(3, "MT");
                        }
                        else
                        {
                            grd_Sizetype.DataSource = Utility.Fn_GetEmptyDataTable();
                            grd_Sizetype.DataBind();
                        }
                    }
                    //ddlBase.Items.Clear();
                    //ddlBase.Items.Add("BASE");
                    // btnsend.Enabled = false;
                    UserRights();


                }
                else
                {
                    //this.Response.End();
                    if (Request.QueryString.ToString().Contains("quotno"))
                    {

                        if (Session["home"] != null)
                        {
                            if (Session["home"].ToString() == "SA")
                            {
                                Response.Redirect("../Home/SalesHome.aspx");
                            }
                            else if (Session["home"].ToString() == "CS")
                            {
                                if (Session["StrTranType"].ToString() == "FE")
                                {
                                    Response.Redirect("../Home/OECSHome.aspx");
                                }
                                else if (Session["StrTranType"].ToString() == "FI")
                                {
                                    Response.Redirect("../Home/OICSHome.aspx");
                                }
                            }
                        }
                    }
                    else if (Session["home"] != null)
                    {
                        if (Request.QueryString.ToString().Contains("Quotno"))
                        {
                            Response.Redirect("../Sales/Quatapp.aspx");
                        }
                        else if (Session["home"].ToString() == "SA")
                        {
                            Response.Redirect("../Home/SalesHome.aspx");
                        }
                        else if (Request.QueryString.ToString().Contains("type"))
                        {
                            if (lblHeader.Text == "Quotation Approval")
                            {
                                Response.Redirect("../Home/OEOpsAndDocs.aspx");
                            }
                        }

                    }

                    else
                    {
                        this.Response.End();
                    }

                    RateLabel1.Visible = true;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


            BuyRateBtn.Visible = false;
            //RateLabel1.Visible = false;

            GenQuotBtn.Visible = false;




        }

        protected void txtCarrier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                // dt_cust = Cusobj.GetLikeCustomer(txtCarrier.Text.Trim().ToUpper());
                //int txtcarrierid = da_obj_Customer.GetCustomerid((txtCarrier.Text.Trim().ToUpper()));
                DataTable obj_dt = new DataTable();
                obj_dt = da_obj_Customer.GetexactCustomer(txtCarrier.Text.ToUpper(), "L");
                if (obj_dt.Rows.Count > 0 && hdnCarrier.Value != "0")
                {

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Carrier');", true);
                    txtCarrier.Text = "";
                    txtCarrier.Focus();
                    brr = true;
                    return;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        //protected void txtRateby_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
        //        int empid = Convert.ToInt32(Session["LoginEmpId"]);
        //        if (empid != 0 && Convert.ToInt32(Session["LoginEmpId"]).ToString() != "0")
        //        {
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Rate Obtained By');", true);
        //            txtRateby.Text = "";
        //            txtRateby.Focus();
        //            brr = true;
        //            return;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}

        public void CheckEmp(string empname)
        {
            brr = false;
            int empid = Convert.ToInt32(Session["LoginEmpId"]);
            if (empid == 0)
            {
                try
                {

                    brr = true;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Select Correct Employee Name');", true);
                    return;
                }
                catch (Exception ex)
                {

                }
            }
        }

        public int getvalidity()
        {
            try
            {
                int a, b;

                validity = Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text));
                DateTime validity1;


                DateTime dvt = Convert.ToDateTime(Logobj.GetDate().ToString("dd-MMM-yyyy"));

                validity1 = dvt.AddDays(15);
                if (validity <= validity1)
                {
                    txtValidTill.Text = validity.ToString("dd/MM/yyyy");
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Date Again. Date format is wrong');", true);

                return 0;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int intpby;
                int empid;
                if (ddl_product.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                    blnerr = true;
                    ddl_product.Focus();
                    return;
                }
                if (txtPOL.Text.ToUpper().Trim() == txtPOD.Text.ToUpper().Trim())
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Both PoL And PoD Should not Same');", true);
                    txtPOD.Text = "";
                    txtPOD.Focus();
                    return;
                }
                if (ddlFreight.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Freight');", true);
                    ddlFreight.Focus();
                    return;
                }
                if (ddlShipment.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Shipment');", true);
                    ddlShipment.Focus();
                    return;
                }
                if (hdn_Incoid.Value == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Enter Inco Term');", true);
                    txtInco.Focus();
                    return;
                }

                if (txt_grwt.Text.Length == 0)
                {
                    txt_grwt.Text = "0";
                }
                if (txt_volume.Text.Length == 0)
                {
                    txt_volume.Text = "0";
                }
                if (txt_totdays.Text.Length == 0)
                {
                    txt_totdays.Text = "0";
                }


                txtCustomer_TextChanged(sender, e);
                txtCargo_TextChanged(sender, e);
                txtPOR_TextChanged(sender, e);
                txtPOL_TextChanged(sender, e);
                txtPOD_TextChanged(sender, e);
                txtFD_TextChanged(sender, e);
                txtSalesPerson_TextChanged(sender, e);
                // txtCarrier_TextChanged(sender, e);// hide me yuvaraj
                //DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
                string emploid = Session["LoginUserName"].ToString();
                int employeeID = Convert.ToInt32(Session["LoginEmpId"]);
                int preparedby = empobj.GetEmpid(emploid);
                int custid;
                if (hdnCarrier.Value == "0" || hdnCarrier.Value == "")// by yuvaraj
                {
                    custid = 0;
                }
                else
                {
                    custid = Convert.ToInt32(hdnCarrier.Value);
                }
                int cargoid = Convert.ToInt32(hdf_cargoid.Value);
                int polid = Convert.ToInt32(hdf_POL.Value);
                int podid = Convert.ToInt32(hdf_POD.Value);
                int porid = Convert.ToInt32(hdf_POR.Value);
                int fdid = Convert.ToInt32(hdf_FD.Value);
                int obtainedby = Convert.ToInt32(Session["LoginEmpId"]);
                int j;
                int count = 0;
                if (brr == true)
                {
                    return;
                }

                if (Gross_country.Checked == true)
                {
                    check = "Y";
                }
                else
                {
                    check = "N";
                }
                if (hdn_shipperid.Value == "")
                {
                    hdn_shipperid.Value = "0";
                }
                if (hdn_Consigneeid.Value == "")
                {
                    hdn_Consigneeid.Value = "0";
                }
                //if (hdn_Consigneeid.Value == "")
                //{
                //    hdn_Consigneeid.Value = "0";
                //}
                //txt_noofcont.Text = "0";

                //if (txt_enquiry.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select Enquiry Date');", true);
                //    brr = false;
                //    return;
                //}
                //if (txt_noofcont.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select Base Type and Enter Expected Qty.');", true);
                //    brr = false;
                //    return;
                //}
                txtBrokerage.Text = "0";
                if (btnSave.ToolTip == "Save")
                {
                    ValidateFunction();
                    if (brr == true)
                    {
                        return;
                    }

                    if (txtBuying.Text == "")
                    {
                        int i = 0;
                        txtBuying.Text = Convert.ToString(i);
                    }
                    if (ddlFreight.SelectedItem.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Select Freight type');", true);
                        return;
                    }
                    if (Session["StrTranType"] != null)
                    {
                        strtrantype = Session["StrTranType"].ToString();
                        if (strtrantype != "AE" || strtrantype != "AI")
                        {
                            if (ddlShipment.SelectedItem.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Select Shipment type');", true);
                                return;
                            }
                        }
                    }
                    if (txtQuotation.Text != "")
                    {
                    }

                    btnApp.Enabled = false;
                    btnAdd.Enabled = true;
                    btnApp.ForeColor = System.Drawing.Color.Gray;
                    btnAdd.ForeColor = System.Drawing.Color.White;
                    baseFil();
                    txtCargeEnable();
                    CollectData();


                    j = getvalidity();


                    if (brr == true)
                    {
                        return;
                    }
                    //if (txtBuying.Text == "0" || txtBuying.Text == "")
                    //{
                    //    if (count == 0)
                    //    {
                    //        //if (j == 1)
                    //        //{ 
                    //        //total = buyingobj.InsBuyingHead(custid, cargoid, polid, podid, freight, Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text)), shipment, dgcargo, bulkvolume, Convert.ToDouble(txtBrokerage.Text), obtainedby, preparedby, txtRemarks.Text.ToUpper().Trim(), porid, fdid);


                    //        total = buyingobj.InsBuyingHead(custid, cargoid, polid, podid, freight, Convert.ToDateTime(Utility.fn_ConvertDatetime(txtValidTill.Text).ToString()), shipment, dgcargo, bulkvolume, Convert.ToDouble(txtBrokerage.Text), obtainedby, preparedby, txtRemarks.Text.ToUpper().Trim(), porid, fdid);
                    //        txtBuying.Text = total.ToString();
                    //        hid_rateid.Value = total.ToString();

                    //        //}
                    //        //else
                    //        //{
                    //        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Date Again .Valid Till Date should not  exceed 15 days');", true);
                    //        //}
                    //        count = 1;
                    //    }
                    //}
                    int count1 = 0;
                    for (int l = 0; l <= grd_Sizetype.Rows.Count - 1; l++)
                    {
                        CheckBox cbox = (CheckBox)grd_Sizetype.Rows[l].FindControl("checksbno");
                        //CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                        if (cbox.Checked == true)
                        {

                            count1++;

                        }



                    }
                    if (count1 == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select Size ');", true);
                        return;
                    }


                    save();
                }
                else
                {

                    if (btnSave.ToolTip == "Update")
                    {
                        string ver = "";
                        DataTable dtQuottt = new DataTable();
                        string ddlversion = "";
                        //if (ddl_version.Text == "")
                        //{
                        //    ddlversion = "0";
                        //}
                        //else
                        //{
                        //    ddlversion = ddl_version.Text;
                        //}
                        ddlversion = "0";
                        dtQuottt = quotation.GetInquiryHeadDetails(Convert.ToInt32(txtQuotation.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        if (dtQuottt.Rows[0]["version"].ToString() == "0")
                        {
                            // ver = "";
                        }
                        if (ddlversion == dtQuottt.Rows[0]["version"].ToString())
                        {
                            //if (txtQuotation.Text != "")
                            //{
                            //    dtQuot = quotation.CheckQuotForBookingFromQno(Convert.ToInt32(txtQuotation.Text), strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Q");
                            //    if (dtQuot.Rows.Count > 0)
                            //    {
                            //        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Booking Already done, you cannot amend. create New Quotation');", true);
                            //        return;
                            //    }
                            //}
                            quotid = Convert.ToInt32(txtQuotation.Text);
                            hid_quotno.Value = txtQuotation.Text;
                            hid_rateid.Value = txtBuying.Text;
                            intapprovedbyid = Convert.ToString(1);
                            CollectData();
                            if (txtBuying.Text != "")
                            {
                                j = getvalidity();
                                //checkdata();
                                //DataAccess.Marketing.Quotation quotobj = new DataAccess.Marketing.Quotation();
                                string Ccode = Convert.ToString(Session["Ccode"]);

                                if (Ccode != "")
                                {

                                    quotobj.GetDataBase(Ccode);
                                }
                                    DataTable dt_quot = new DataTable();
                                total = Convert.ToInt32(txtBuying.Text);
                                dt_quot = quotobj.CheckInquiryForBookingFromQno(Convert.ToInt32(txtBuying.Text), "FE", Convert.ToInt32(Session["LoginBranchid"].ToString()), "B");

                                //if (dt_quot.Rows.Count > 0)
                                //{
                                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Booking Already used this Buying .Create  New Buying.');", true);
                                //    return;
                                //}

                                //dt_quot = quotobj.CheckQuotForBookingFromQno(Convert.ToInt32(txtBuying.Text), "FE", Convert.ToInt32(Session["LoginBranchid"].ToString()), "BB");
                                //if (dt_quot.Rows.Count > 0 && txtQuotation.Text == dt_quot.Rows[0]["quotno"].ToString())
                                //{
                                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Quotation Already used this Buying .Create  New Buying.');", true);
                                //    return;
                                //}
                            }

                            if (ratevalid != true)
                            {
                                j = getvalidity();
                                // validity = Convert.ToDateTime(Utility.fn_ConvertDate(dtpValidity.Text));
                                //if (j == 1)
                                //{
                                buyingobj.UpdBuyingHead(total, custid, cargoid, polid, podid, freight, shipment, dgcargo, bulkvolume, Convert.ToDateTime((validity)),
                                    Convert.ToDouble(txtBrokerage.Text), obtainedby, preparedby, txtRemarks.Text, porid, fdid);
                                //}
                                //else
                                //{
                                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Date Again .Valid Till Date should not  exceed 15 days');", true);
                                //}
                            }
                            else if (ratevalid == true)
                            {
                                j = getvalidity();
                                //validity = Convert.ToDateTime(Utility.fn_ConvertDate(dtpValidity.Text));
                                //if (j == 1)
                                //{
                                buyingobj.UpdBuyingHead(Convert.ToInt32(txtBuying.Text), custid, cargoid, polid, podid, freight, shipment, dgcargo, bulkvolume,
                                    Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text)), Convert.ToDouble(txtBrokerage.Text), obtainedby, preparedby, txtRemarks.Text.ToUpper().Trim(), porid, fdid);
                                //}
                                //else
                                //{
                                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Date Again .Valid Till Date should not  exceed 15 days');", true);
                                //}
                            }

                            hdf_app.Value = app.ToString();
                            app = Convert.ToInt16(hdf_app.Value);


                            if (app == 0)
                            {

                                if (strtrantype == "FE")
                                {
                                    if (ddlBase.Text == "FCL")
                                    {
                                        if (grdBuying.Rows.Count > 0)
                                        {

                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Buy Rate is  Mandatory');", true);
                                        }

                                    }
                                }
                                if (Gross_country.Checked == true)
                                {
                                    check = "Y";
                                }
                                else
                                {
                                    check = "N";
                                }
                                if (strtrantype == "FE" || strtrantype == "FI")
                                {
                                    quotation.UpdateInquiryheadDetail(quotid, Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text) + " " + DateTime.Now.ToLongTimeString()), Convert.ToInt32(hdf_customerid.Value), Convert.ToInt32(hdf_POR.Value),
                                        Convert.ToInt32(hdf_POL.Value), Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.Text, ddlFreight.Text, Convert.ToInt32(hdf_cargoid.Value), txtDescription.Text,
                                        Convert.ToInt32(hdf_salesperson.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hdf_Hazard.Value), Session["StrTranType"].ToString(), txtRemarks.Text, "0", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                                        Convert.ToInt32(txtBuying.Text.Trim()), hdf_Bussiness.Value, check, txtterms.Text, Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txt_custpono.Text, txt_routing.Text,
                            txt_transittime.Text, Convert.ToInt32(ddl_moveTypes.SelectedValue), txt_pieces.Text, txt_noofcont.Text, /*Convert.ToDecimal(txt_grwt.Text)*/ 0, (txt_units.Text), Convert.ToDouble(txt_volume.Text), txt_dim.Text, txt_value.Text, 0, Convert.ToInt32(txt_totdays.Text), ddl_feasi.SelectedValue
                           , Convert.ToDateTime(Utility.fn_ConvertDate(txt_enquiry.Text)));

                                    for (j = 0; j <= grd_Sizetype.Rows.Count - 1; j++)
                                    {
                                        CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                                        //CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                                        if (cbox.Checked == true)
                                        {

                                            string stype = grd_Sizetype.Rows[j].Cells[1].Text;
                                            string expqty = grd_Sizetype.Rows[j].Cells[2].Text;
                                            TextBox Txt = (TextBox)grd_Sizetype.Rows[j].Cells[2].FindControl("txt_Sizecount");
                                            string value = Txt.Text;

                                            quotation.UpdateInquiryDetailsTable(quotid, stype, Convert.ToInt32(value));

                                        }
                                    }

                                }
                                else
                                {
                                    quotation.UpdateInquiryheadDetail(quotid, Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text) + " " + DateTime.Now.ToLongTimeString()), Convert.ToInt32(hdf_customerid.Value), Convert.ToInt32(hdf_POR.Value),
                                                                        Convert.ToInt32(hdf_POL.Value), Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.Text, ddlFreight.Text, Convert.ToInt32(hdf_cargoid.Value), txtDescription.Text,
                                                                        Convert.ToInt32(hdf_salesperson.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hdf_Hazard.Value), Session["StrTranType"].ToString(), txtRemarks.Text, "0", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                                                                        Convert.ToInt32(txtBuying.Text.Trim()), hdf_Bussiness.Value, check, txtterms.Text, Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txt_custpono.Text, txt_routing.Text,
                                                            txt_transittime.Text, Convert.ToInt32(ddl_moveTypes.SelectedValue), txt_pieces.Text, "0", /*Convert.ToDecimal(txt_grwt.Text)*/0, (txt_units.Text), Convert.ToDouble(txt_volume.Text), txt_dim.Text, txt_value.Text, Convert.ToDecimal(txt_noofcont.Text), Convert.ToInt32(txt_totdays.Text), ddl_feasi.SelectedValue
                                                           , Convert.ToDateTime(Utility.fn_ConvertDate(txt_enquiry.Text)));



                                    for (j = 0; j <= grd_Sizetype.Rows.Count - 1; j++)
                                    {
                                        CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                                        //CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                                        if (cbox.Checked == true)
                                        {

                                            string stype = grd_Sizetype.Rows[j].Cells[1].Text;
                                            string expqty = grd_Sizetype.Rows[j].Cells[2].Text;
                                            TextBox Txt = (TextBox)grd_Sizetype.Rows[j].Cells[2].FindControl("txt_Sizecount");
                                            string value = Txt.Text;

                                            quotation.UpdateInquiryDetailsTable(quotid, stype, Convert.ToInt32(value));

                                        }
                                    }
                                }





                                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Inquiry # " + quotid + " Updated ');", true);
                                btnAdd.Enabled = true;
                                btnAdd.ForeColor = System.Drawing.Color.White;
                                intapprovedbyid = Convert.ToString(1);
                                DateTime appdate;
                                appdate = Logobj.GetDate();
                                strapproved = Session["LoginUserName"].ToString();

                                intpby = employee.GetNEmpid(txtPreparedBy.Text);
                                empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                                int version = 0;
                                dtQuot = quotation.GetInquiryHeadDetails(quotid, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                                if (dtQuot.Rows.Count > 0)
                                {
                                    if (dtQuot.Rows[0]["approvedby"].ToString() == "" && dtQuot.Rows[0]["version"].ToString() == "")
                                    {
                                        version = 1;

                                    }
                                    else
                                    {
                                        version = Convert.ToInt32(dtQuot.Rows[0]["version"]) + 1;
                                    }
                                    // txt_version.Text = version.ToString();
                                }
                                //quotation.UpdateQuotationDetailsWApp(quotid, Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text)), Convert.ToInt32(hdf_customerid.Value),
                                //    Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value), Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.Text,
                                //    ddlFreight.Text, Convert.ToInt32(hdf_cargoid.Value), txtDescription.Text, Convert.ToInt32(hdf_salesperson.Value), intpby, Convert.ToInt32(Session["LoginEmpId"].ToString()),
                                //    Convert.ToInt32(hdf_Hazard.Value), appdate, Convert.ToInt32(Session["LoginBranchid"].ToString()));

                                //     quotation.Updversion(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), version);

                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 14, 2, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "OE_QuotUpd");
                                        break;
                                    case "FI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 15, 2, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "OI_QuotUpd");
                                        break;
                                    case "AE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 16, 2, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "AE_QuotUpd");
                                        break;
                                    case "AI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 17, 2, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "AI_QuotUpd");
                                        break;
                                }
                            }
                            else
                            {
                                Confirmdialog.Show();
                                return;
                            }

                            btnAdd.Enabled = true;
                            btnSave.Text = "Update";
                            btnSave.ToolTip = "Update";
                            btn_save.Attributes["class"] = "btn ico-update";
                            grdQuotation.Enabled = true;
                            btnSave.Enabled = true;
                            btnSave.ForeColor = System.Drawing.Color.White;
                            txtCharges.Focus();
                            btnclose.Enabled = true;
                            btnclose.ForeColor = System.Drawing.Color.White;
                            //btnView.Enabled = true;
                            //btnView.ForeColor = System.Drawing.Color.White;
                            btnApp.Enabled = true;
                            btnApp.ForeColor = System.Drawing.Color.White;
                            btnAdd.Enabled = true;
                            btnAdd.ForeColor = System.Drawing.Color.White;
                            txtUnable();
                        }

                        txtCharges.Focus();
                        btnSave.Enabled = false;
                        btnSave.ForeColor = System.Drawing.Color.Gray;
                        btnApp.Enabled = false;
                        btnApp.ForeColor = System.Drawing.Color.Gray;
                        btnclose.Text = "Cancel";
                        btnclose.ToolTip = "Cancel";
                        btn_back1.Attributes["class"] = "btn ico-cancel";
                        //BuyRateBtn.Visible = false;
                        //GenQuotBtn.Visible = false;
                    }
                }
                UserRights();
                grd_Sizetype.Enabled = true;// add 20/1/23

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void save()
        {
            int intpby;
            int empid;
            //Newly added
            string str_usermailid = Session["usermailid"].ToString();
            //string str_mailuser = Session["MailUser"].ToString();
            string str_mailpwd = Session["usermailpwd"].ToString();
            if (txtCustomer.Text != "" && txtPOR.Text != "" && txtPOL.Text != "" && txtPOD.Text != "" && txtFD.Text != "")
            {


                if (Gross_country.Checked == true)
                {
                    check = "Y";
                }
                else
                {
                    check = "N";
                }

                if (strtrantype == "FE" || strtrantype == "FI")
                {
                    quotid = quotation.InsertInquiryHeadDetails(Convert.ToDateTime(Utility.fn_ConvertDate(txtDate.Text) + " " + DateTime.Now.ToLongTimeString()), Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text) + " " +
                        DateTime.Now.ToLongTimeString()), Session["StrTranType"].ToString(), Convert.ToInt32(hdf_customerid.Value), Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value),
                        Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.SelectedItem.Text, ddlFreight.SelectedItem.Text, Convert.ToInt32(hdf_cargoid.Value),
                        txtDescription.Text, Convert.ToInt32(hdf_salesperson.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hdf_Hazard.Value), txtRemarks.Text.Trim(),
                        "0", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtBuying.Text.Trim()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), hdf_Bussiness.Value,
                        check, txtterms.Text, Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txt_custpono.Text, txt_routing.Text,
                        txt_transittime.Text, Convert.ToInt32(ddl_moveTypes.SelectedValue), txt_pieces.Text, txt_noofcont.Text,/* Convert.ToDecimal(txt_grwt.Text)*/ 0, (txt_units.Text), Convert.ToDouble(txt_volume.Text), txt_dim.Text, txt_value.Text, 0, Convert.ToInt32(txt_totdays.Text), ddl_feasi.SelectedValue, Convert.ToDateTime(Utility.fn_ConvertDate(txt_enquiry.Text)));//Convert.ToDateTime(Utility.fn_ConvertDate(txt_enquiry.Text))

                    //txt_Sizecount_TextChanged(sender,e);
                    BuyRateBtn.Visible = true;




                    for (int j = 0; j <= grd_Sizetype.Rows.Count - 1; j++)
                    {
                        CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                        //CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                        if (cbox.Checked == true)
                        {

                            string stype = grd_Sizetype.Rows[j].Cells[1].Text;
                            string expqty = grd_Sizetype.Rows[j].Cells[2].Text;
                            TextBox Txt = (TextBox)grd_Sizetype.Rows[j].Cells[2].FindControl("txt_Sizecount");
                            string value = Txt.Text;

                            if (expqty != "")
                            {
                                cbox.Checked = true;
                            }

                            quotation.InsertInquiryDetailsTable(quotid, stype, value);

                        }



                    }






                }
                else
                {
                    quotid = quotation.InsertInquiryHeadDetails(Convert.ToDateTime(Utility.fn_ConvertDate(txtDate.Text) + " " + DateTime.Now.ToLongTimeString()), Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text) + " " +
                        DateTime.Now.ToLongTimeString()), Session["StrTranType"].ToString(), Convert.ToInt32(hdf_customerid.Value), Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value),
                        Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.SelectedItem.Text, ddlFreight.SelectedItem.Text, Convert.ToInt32(hdf_cargoid.Value),
                        txtDescription.Text, Convert.ToInt32(hdf_salesperson.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hdf_Hazard.Value), txtRemarks.Text.Trim(),
                        "0", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtBuying.Text.Trim()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), hdf_Bussiness.Value,
                        check, txtterms.Text, Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txt_custpono.Text, txt_routing.Text,
                        txt_transittime.Text, Convert.ToInt32(ddl_moveTypes.SelectedValue), txt_pieces.Text, txt_noofcont.Text,/* Convert.ToDecimal(txt_grwt.Text)*/ 0, (txt_units.Text), Convert.ToDouble(txt_volume.Text), txt_dim.Text, txt_value.Text, 0, Convert.ToInt32(txt_totdays.Text), ddl_feasi.SelectedValue, Convert.ToDateTime(Utility.fn_ConvertDate(txt_enquiry.Text)));//Convert.ToDateTime(Utility.fn_ConvertDate(txt_enquiry.Text))

                    //txt_Sizecount_TextChanged(sender, e);


                    BuyRateBtn.Visible = true;

                    for (int j = 0; j <= grd_Sizetype.Rows.Count - 1; j++)
                    {
                        CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                        //CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                        if (cbox.Checked == true)
                        {

                            string stype = grd_Sizetype.Rows[j].Cells[1].Text;
                            string expqty = grd_Sizetype.Rows[j].Cells[2].Text;
                            TextBox Txt = (TextBox)grd_Sizetype.Rows[j].Cells[2].FindControl("txt_Sizecount");
                            string value = Txt.Text;

                            quotation.InsertInquiryDetailsTable(quotid, stype, value);

                        }
                    }
                }



                txtQuotation.Text = Convert.ToString(quotid);
                hid_quotno.Value = txtQuotation.Text;

                if (hidreuse.Value == "1")
                {
                    if (txtQuotation.Text != "")
                    {
                        quotid = Convert.ToInt32(txtQuotation.Text);
                        int chargeid;
                        //if(txtCharges.Text !="")
                        //{
                        //     chargeid = charges.GetChargeid(txtCharges.Text);
                        //}
                        //else
                        //{
                        //   
                        //}
                        //if (blnexists == false)
                        //{

                        DataTable dts = new DataTable();


                        if (GrdBuysellcharge.Rows.Count > 0)
                        {

                            quotation.qreuseNewdetails(Convert.ToInt32(Session["OldQuotation"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), quotid);

                            Session["OldQuotation"] = "";
                            //for (int i = 0; i <= grdQuotation.Rows.Count - 1; i++)
                            //{
                            //    chargeid = charges.GetChargeid(grdQuotation.Rows[i].Cells[0].Text);
                            //    blnexists = quotation.CheckChargeExist(chargeid, quotid, ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                            //    double rateamt = 0;
                            //    double total = 0;
                            //    string value = "1";

                            //    if (grdQuotation.Rows[i].Cells[2].Text != "")
                            //    {
                            //        rateamt = Convert.ToDouble(grdQuotation.Rows[i].Cells[2].Text);
                            //    }

                            //    total = rateamt * Convert.ToInt32(value);
                            //    //  quotation.InsertChargeDetails(quotid, grdQuotation.Rows[i].Cells[0].Text.ToUpper(), grdQuotation.Rows[i].Cells[1].Text.ToUpper(), total, grdQuotation.Rows[i].Cells[3].Text.ToUpper(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), "N", 0, Convert.ToDouble(grdQuotation.Rows[i].Cells[4].Text));
                            //   // quotation.InsertChargeDetails(quotid, grdQuotation.Rows[i].Cells[0].Text, grdQuotation.Rows[i].Cells[1].Text, Convert.ToDouble(grdQuotation.Rows[i].Cells[2].Text), grdQuotation.Rows[i].Cells[4].Text.Trim(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                            //    quotation.InsertcombinedChargeDetailsnew(quotid, grdQuotation.Rows[i].Cells[0].Text, grdQuotation.Rows[i].Cells[1].Text.ToUpper(), Convert.ToDouble(grdQuotation.Rows[i].Cells[7].Text), grdQuotation.Rows[i].Cells[4].Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToDouble(grdQuotation.Rows[i].Cells[4].Text), Convert.ToDouble(grdQuotation.Rows[i].Cells[5].Text), Convert.ToDouble(grdQuotation.Rows[i].Cells[6].Text));
                            //    quotation.Updquotmarginper(quotid, HttpUtility.HtmlDecode(grdQuotation.Rows[i].Cells[0].Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDecimal(txt_margin.Text), Convert.ToDecimal(grdQuotation.Rows[i].Cells[8].Text));

                            //}
                        }

                        if (GrdBuysellcharge.Rows.Count > 0)
                        {
                            for (int i = 0; i <= GrdBuysellcharge.Rows.Count - 1; i++)
                            {
                                int intchargeid = charges.GetChargeid(GrdBuysellcharge.Rows[i].Cells[0].Text);
                                //  buyingobj.InsBuyingDetails(Convert.ToInt32(txtBuying.Text), chargeid, txtCurr.Text.ToUpper().Trim(), Convert.ToDouble(txt_buyrate.Text), ddlBase.Text);

                                buyingobj.InsBuyingDetails(Convert.ToInt32(txtBuying.Text), intchargeid, GrdBuysellcharge.Rows[i].Cells[1].Text.Trim(), Convert.ToDouble(GrdBuysellcharge.Rows[i].Cells[6].Text.Trim()), GrdBuysellcharge.Rows[i].Cells[4].Text.Trim());
                            }
                        }
                        // }
                    }
                }

                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Inquiry # " + quotid + ", please update Buy Rate');", true);
                baseFil();
                txtCharges.Focus();

                switch (Session["StrTranType"].ToString())
                {
                    case "FE":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 14, 1, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "OE_QuotSave");
                        break;
                    case "FI":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 15, 1, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "OI_QuotSave");
                        break;
                    case "AE":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 16, 1, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "AE_QuotSave");
                        break;
                    case "AI":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 17, 1, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "AI_QuotSave");
                        break;
                }
                ValidateFunction();
                CollectData();
                intapprovedbyid = Convert.ToString(1);
                DateTime appdate;
                appdate = Logobj.GetDate();
                strapproved = Session["LoginUserName"].ToString();


                intpby = employee.GetNEmpid(txtPreparedBy.Text);
                empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                int version = 0;
                dtQuot = quotation.GetcombbinedQuotationDetails(quotid, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                if (dtQuot.Rows.Count > 0)
                {
                    if (dtQuot.Rows[0]["approvedby"].ToString() == "0" && dtQuot.Rows[0]["version"].ToString() == "")
                    {
                        version = 1;

                    }
                    else
                    {
                        version = Convert.ToInt32(dtQuot.Rows[0]["version"]) + 1;
                    }
                    // txt_version.Text = version.ToString();
                }
                //quotation.UpdateQuotationDetailsWApp(quotid, Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text)), Convert.ToInt32(hdf_customerid.Value),
                //    Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value), Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.Text,
                //    ddlFreight.Text, Convert.ToInt32(hdf_cargoid.Value), txtDescription.Text, Convert.ToInt32(hdf_salesperson.Value), intpby, Convert.ToInt32(Session["LoginEmpId"].ToString()),
                //    Convert.ToInt32(hdf_Hazard.Value), appdate, Convert.ToInt32(Session["LoginBranchid"].ToString()));

                //  quotation.Updversion(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), version);

                switch (Session["StrTranType"].ToString())
                {
                    case "FE":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 180, 1, Convert.ToInt32(Session["LoginBranchid"]), "OE_QuotApp # : " + quotid);
                        break;
                    case "FI":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 181, 1, Convert.ToInt32(Session["LoginBranchid"]), "OI_QuotApp # : " + quotid);
                        break;
                    case "AE":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 217, 1, Convert.ToInt32(Session["LoginBranchid"]), "AE_QuotApp # : " + quotid);
                        break;
                    case "AI":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 215, 1, Convert.ToInt32(Session["LoginBranchid"]), "AI_QuotApp # : " + quotid);
                        break;
                }
                //  SendDeleiveryStatus();
                usermail = HrEmpobj.GetMailAdd(Convert.ToInt32(hdf_salesperson.Value));
                dtQuot = userperobj.GetMLEmpid(userperobj.GetMLUiid(Session["StrTranType"].ToString(), "Quotation Approval"), Convert.ToInt32(Session["LoginBranchid"]));

                for (int i = 0; i <= dtQuot.Rows.Count - 1; i++)
                {
                    empmailadd = empmailadd + HrEmpobj.GetMailAdd(Convert.ToInt32(dtQuot.Rows[i][0].ToString())) + ";";
                }

                ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Inquiry Approved');", true);


                if (empmailadd != "")
                {
                    empmailadd = empmailadd.Substring(0, empmailadd.Length - 1);



                }
            }


            quotid = Convert.ToInt32(txtQuotation.Text);
            //int chargeid = charges.GetChargeid(HttpUtility.HtmlDecode(txtCharges.Text));
            //string amtval = "";
            //if (grd_Sizetype.Rows.Count > 0)
            //{
            //    for (int j = 0; j <= grd_Sizetype.Rows.Count - 1; j++)
            //    {
            //        string SType = grd_Sizetype.Rows[j].Cells[1].Text;
            //        CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
            //        if (cbox.Checked == true)
            //        {
            //            amtval = "";
            //            TextBox txtBox = (TextBox)grd_Sizetype.Rows[j].FindControl("txt_Sizecount");


            //            if (ddl_product.Text == "Ocean Exports" || ddl_product.Text == "Ocean Imports")
            //            {

            //                if (SType != "CBM")
            //                {
            //                    if (System.Text.RegularExpressions.Regex.IsMatch(txtBox.Text, "[^0-9]"))
            //                    {
            //                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Numbers Only allowed');", true);
            //                        txtBox.Focus();
            //                        return;
            //                    }
            //                }
            //            }
            //            else if (ddl_product.Text == "Air Exports" || ddl_product.Text == "Air Imports")
            //            {
            //                if (SType != "KGS")
            //                {
            //                    if (System.Text.RegularExpressions.Regex.IsMatch(txtBox.Text, "[^0-9]"))
            //                    {
            //                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Numbers Only allowed');", true);
            //                        txtBox.Focus();
            //                        return;
            //                    }
            //                }
            //            }
            //            if (ddlBase.Text != "BL" && SType != ddlBase.Text)
            //            {

            //                ScriptManager.RegisterStartupScript(btnAdd, typeof(Button), "logix", "alertify.alert('Select and Enter Expected Qty for Base type : " + ddlBase.Text + "');", true);
            //                return;

            //            }
            //            else if (txtBox.Text == "")
            //            {
            //                ScriptManager.RegisterStartupScript(btnAdd, typeof(Button), "logix", "alertify.alert('Enter Exp.Qty for " + SType + "');", true);
            //                txtBox.Focus();
            //                //amtval = "1";
            //                return;
            //            }
            //            else
            //            {
            //                amtval = txtBox.Text;
            //            }
            //            double firstamt = 0;
            //            firstamt = Convert.ToDouble(txt_sellrate.Text);
            //            //double totalamt = firstamt * Convert.ToInt32(amtval);
            //            if (txt_sellrate.Text != "")
            //            {
            //                if (SType == ddlBase.Text)
            //                {
            //                    if (ddlBase.Text != "")
            //                    {

            //                        string strbase = ddlBase.Text;
            //                       /* famount = Convert.ToDouble(txt_sellrate.Text) * Convert.ToDouble(hid_exrate.Value) * Convert.ToDouble(amtval);*/ //CheckBase(strbase, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtex.Text));
            //                        txtamount.Text = famount.ToString();
            //                        txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
            //                        hid_amount.Value = Convert.ToDecimal(txtamount.Text).ToString("0.00");

            //                    }
            //                    quotation.InsertChargeDetailsnewversion(Convert.ToInt32(txtQuotation.Text), txtCharges.Text, txtCurr.Text.ToUpper(), Convert.ToDouble(txt_sellrate.Text), ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToDouble(amtval), Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value), version);
            //                    quotation.Updquotmarginper(Convert.ToInt32(txtQuotation.Text), HttpUtility.HtmlDecode(txtCharges.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDecimal(txt_margin.Text), Convert.ToDecimal(txt_retention.Text));

            //                    check1 = true;
            //                }
            //            }
            //        }
            //    }
            //}
            //if (check1 == false)
            //{
            //    if (txt_sellrate.Text != "")
            //    {
            //        if ((ddlBase.Text == "BL") || (ddlBase.Text == "HAWB"))
            //        {
            //            if (ddlBase.Text != "" && txtCharges.Text != "" && txtCurr.Text != "" && txt_sellrate.Text != "")
            //            {

            //                string strbase = ddlBase.Text;
            //                famount = Convert.ToDouble(txt_sellrate.Text) * Convert.ToDouble(hid_exrate.Value) * 1; //CheckBase(strbase, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtex.Text));
            //                txtamount.Text = famount.ToString();
            //                txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
            //                hid_amount.Value = Convert.ToDecimal(txtamount.Text).ToString("0.00");

            //            }
            //            quotation.InsertChargeDetailsnewversion(Convert.ToInt32(txtQuotation.Text), txtCharges.Text, txtCurr.Text.ToUpper(), Convert.ToDouble(txt_sellrate.Text), ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 1, Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value), version);
            //            quotation.Updquotmarginper(Convert.ToInt32(txtQuotation.Text), HttpUtility.HtmlDecode(txtCharges.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDecimal(txt_margin.Text), Convert.ToDecimal(txt_retention.Text));

            //        }
            //        else
            //        {
            //            ScriptManager.RegisterStartupScript(btnAdd, typeof(Button), "logix", "alertify.alert('Select and Enter Expected Qty for Base type : " + ddlBase.Text + "');", true);
            //            return;
            //            //if (ddlBase.Text != "" && txtCharges.Text != "" && txtCurr.Text != "" && txtRate.Text != "")
            //            //{

            //            //    string strbase = ddlBase.Text;
            //            //    famount = Convert.ToDouble(hid_rate.Value) * Convert.ToDouble(hid_exrate.Value) * Convert.ToInt32(amtval); //CheckBase(strbase, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtex.Text));
            //            //    txtamount.Text = famount.ToString();
            //            //    txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
            //            //    hid_amount.Value = Convert.ToDecimal(txtamount.Text).ToString("0.00");

            //            //}
            //            //quotation.UpdateGrdChargeDetailsnew(quotid, HttpUtility.HtmlDecode(txtCharges.Text), txtCurr.Text.ToUpper(), Convert.ToDouble(txtRate.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), ddlBase.Text, hid_oldData.Value, 1, Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value));
            //        }
            //    }
            //}


            //if (txtBuying.Text != "" && txt_buyrate.Text != "0")
            //{

            //    if (txt_buyrate.Text != "")
            //    {
            //        buyingobj.InsBuyingDetailsversion(Convert.ToInt32(txt_buyrate.Text), char, txtCurr.Text.ToUpper().Trim(), Convert.ToDouble(txt_buyrate.Text), ddlBase.Text, version);
            //        //dtbuying = buyingobj.SelBuyingDetailsnew(Convert.ToInt32(txtBuying.Text));
            //        //Session["Container"] = dtbuying;
            //        //grdBuying.DataSource = dtbuying;
            //        //grdBuying.DataBind();
            //    }
            //}

            grd_Sizetype.Enabled = true;// add 20/1/23
            txtUnable();
            txtCargeEnable();
            btnSave.Text = "Update";
            btnSave.ToolTip = "Update";
            btn_save.Attributes["class"] = "btn ico-update";
            btnSave.Enabled = true;
            btnSave.ForeColor = System.Drawing.Color.White;
        }

        protected void btn_Yes1_Click(object sender, EventArgs e)
        {
            try
            {
                LoadBuying();
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_No1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void txtEnable()
        {
            try
            {
                if (strtrantype == "AE" || strtrantype == "AI")
                {
                    ddlShipment.Enabled = false;
                }
                else
                {
                    //  ddlShipment.Enabled = true;
                }
                ddlFreight.Enabled = true;
                ddlShipment.Enabled = true;
                txtQuotation.Enabled = true;
                chkHazard.Enabled = true;
                txtCargo.Enabled = true;
                txtDescription.Enabled = true;
                txtCustomer.Enabled = true;
                txtPOR.Enabled = true;
                txtPOL.Enabled = true;
                txtPOD.Enabled = true;
                txtFD.Enabled = true;
                //  txtSalesPerson.Enabled = true;
                txtPreparedBy.Enabled = true;
                txtRemarks.Enabled = true;
                //txtBrokerage.Enabled = true; 
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtQuotation_TextChanged(object sender, EventArgs e)

        {
            if (ddl_product.SelectedItem.Text == "")
            {
                Session["StrTranType"] = "";
            }
            btn_approve.Enabled = true;
            btnSave.Enabled = true;
            getvalue();
            BuyRateBtn.Visible = true;
            RateLabel1.Visible = true;
            GenQuotBtn.Visible = true;

            // ddl_product_SelectedIndexChanged(sender, e);
        }


        public void getvalue()
        {
            try
            {
                OldQuotNo = 0;

                if (txtQuotation.Text != "")
                {
                    quotid = Convert.ToInt32(txtQuotation.Text);
                    hid_quotno.Value = txtQuotation.Text;
                    DataSet dsQuot = new DataSet();
                    dtQuot = quotation.GetInquiryHeadDetails(quotid, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    dtQuot.TableName = "Test1";
                    dsQuot.Tables.Add("Test1");
                    ViewState["Approvalby"] = dtQuot;
                    grd_Sizetype.Enabled = true;// add 20/1/23
                    if (dtQuot.Rows.Count > 0)
                    {
                        if (dtQuot.Rows[0]["grosscountry"].ToString() == "Y")
                        {
                            Gross_country.Checked = true;
                        }
                        else
                        {
                            Gross_country.Checked = false;
                        }
                        ddl_product.SelectedItem.Text = dtQuot.Rows[0]["product"].ToString();
                        Session["StrTranType"] = dtQuot.Rows[0]["strtrantype"].ToString();
                        DataTable dtterms;
                        dtterms = quotation.Getterms(ddlShipment.Text, dtQuot.Rows[0]["strtrantype"].ToString());
                        if (dtterms.Rows.Count > 0)
                        {
                            txtterms.Text = dtterms.Rows[0]["terms"].ToString();
                            txt_terms.Text = dtterms.Rows[0]["terms"].ToString();
                        }
                        txtQuotation.Text = Convert.ToString(quotid);
                        OldQuotNo = Convert.ToInt32(txtQuotation.Text);
                        hdf_OldQuotNo.Value = OldQuotNo.ToString();
                        customerid = Convert.ToInt32(dtQuot.Rows[0]["customerid"].ToString());
                        hdf_customerid.Value = Convert.ToString(customerid);
                        intpol = Convert.ToInt32(dtQuot.Rows[0]["pol"].ToString());
                        hdf_POL.Value = Convert.ToString(intpol);
                        intpor = Convert.ToInt32(dtQuot.Rows[0]["por"].ToString());
                        hdf_POR.Value = Convert.ToString(intpor);
                        intpod = Convert.ToInt32(dtQuot.Rows[0]["pod"].ToString());
                        hdf_POD.Value = Convert.ToString(intpod);
                        intfd = Convert.ToInt32(dtQuot.Rows[0]["fd"].ToString());
                        hdf_FD.Value = Convert.ToString(intfd);
                        cargoid = Convert.ToInt32(dtQuot.Rows[0]["cargoid"].ToString());
                        hdf_cargoid.Value = Convert.ToString(cargoid);
                        sales = Convert.ToInt32(dtQuot.Rows[0]["marketedby"].ToString());
                        hdf_salesperson.Value = Convert.ToString(sales);
                        prepared = Convert.ToInt32(dtQuot.Rows[0]["preparedby"].ToString());
                        hazard = Convert.ToInt32(dtQuot.Rows[0]["hazardous"].ToString());
                        hdf_Hazard.Value = Convert.ToString(hazard);
                        txtDescription.Text = dtQuot.Rows[0]["descn"].ToString();
                        // txtValidTill.Text = Utility.fn_ConvertDate(dtQuot.Rows[0]["validtill"].ToString());
                        txtterms.Text = dtQuot.Rows[0]["Terms"].ToString();
                        txt_terms.Text = dtQuot.Rows[0]["terms"].ToString();
                        txtValidTill.Text = DateTime.Parse(dtQuot.Rows[0]["validtill"].ToString()).ToString("dd/MM/yyyy");
                        txtRemarks.Text = dtQuot.Rows[0]["remarks"].ToString();
                        txtBrokerage.Text = dtQuot.Rows[0]["brokerage"].ToString();
                        Strshipment = quotation.GetShipment(Char.Parse(dtQuot.Rows[0]["stype"].ToString()));
                        txt_totdays.Text = dtQuot.Rows[0]["totaldays"].ToString();
                        if (dtQuot.Rows[0]["feasibility"].ToString() != "")
                        {
                            ddl_feasi.SelectedValue = dtQuot.Rows[0]["feasibility"].ToString();
                        }
                        if (dtQuot.Rows[0]["enquiryno"].ToString() != "")
                        {
                            txt_enquiry.Text = DateTime.Parse(dtQuot.Rows[0]["enquiryno"].ToString()).ToString("dd/MM/yyyy");
                        }
                        if (Session["StrTranType"] != null)
                        {
                            if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                            {
                                strfstatus = quotation.GetFrightAEAI(Char.Parse(dtQuot.Rows[0]["fstatus"].ToString()));

                            }
                            else
                            {
                                strfstatus = quotation.GetFright(Char.Parse(dtQuot.Rows[0]["fstatus"].ToString()));
                            }
                        }
                        //if (dtQuot.Rows[0]["business"].ToString() != "0")
                        //{
                        //    if (dtQuot.Rows[0]["business"].ToString() == "A")
                        //    {
                        //        ddl_controlledby.SelectedValue = "A";
                        //    }
                        //    else
                        //    {
                        //        ddl_controlledby.SelectedValue = "O";
                        //    }
                        //}


                        txt_value.Text = dtQuot.Rows[0]["value"].ToString();
                        DataTable dtinco = new DataTable();
                        hdn_Incoid.Value = dtQuot.Rows[0]["inco"].ToString();
                        if (hdn_Incoid.Value != "")
                        {
                            dtinco = bookingobj.SelMasterInco(Convert.ToInt32(hdn_Incoid.Value));
                            if (dtinco.Rows.Count > 0)
                            {
                                txtInco.Text = dtinco.Rows[0]["incocode"].ToString();
                            }
                        }
                        txt_custpono.Text = dtQuot.Rows[0]["cuspono"].ToString();
                        txt_routing.Text = dtQuot.Rows[0]["routing"].ToString();
                        txt_transittime.Text = dtQuot.Rows[0]["transittime"].ToString();
                        txt_pieces.Text = dtQuot.Rows[0]["pieces"].ToString();
                        if (Session["StrTranType"].ToString() == "FI" || Session["StrTranType"].ToString() == "FE")
                        {
                            txt_noofcont.Text = dtQuot.Rows[0]["noofcont"].ToString();
                        }
                        else
                        {
                            txt_noofcont.Text = dtQuot.Rows[0]["chrageblewt"].ToString();
                        }
                        txt_grwt.Text = dtQuot.Rows[0]["grwt"].ToString();
                        txt_units.Text = dtQuot.Rows[0]["noofunits"].ToString();
                        txt_volume.Text = dtQuot.Rows[0]["volume"].ToString();
                        txt_dim.Text = dtQuot.Rows[0]["dimension"].ToString();
                        txt_value.Text = dtQuot.Rows[0]["value"].ToString();
                        DataTable dtversion = new DataTable();
                        dtversion = quotation.SpGetversion(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        if (dtversion.Rows.Count > 0)
                        {
                            ddl_version.Items.Clear();
                            for (int i = 0; i <= dtversion.Rows.Count - 1; i++)
                            {
                                ddl_version.Items.Add(dtversion.Rows[i]["version"].ToString());
                            }
                        }
                        if (dtversion.Rows.Count > 0)
                        {
                            ddl_version.SelectedItem.Text = dtQuot.Rows[0]["version"].ToString();
                        }
                        //string carr = custobj.GetCustomername(Convert.ToInt32(dtQuot.Rows[0]["carrier"]));
                        //if (carr == "0")
                        //{
                        //    txtCarrier.Text = "";
                        //}
                        //else
                        //{
                        //    txtCarrier.Text = carr;
                        //    hdnCarrier.Value = (dtQuot.Rows[0]["carrier"].ToString());
                        //    TextBox1.Text = custobj.GetCustomerAddress(Convert.ToInt32(dtQuot.Rows[0]["carrier"]));
                        //}


                        if (string.IsNullOrEmpty(dtQuot.Rows[0]["scope"].ToString()) != true)
                        {
                            movementtype = Convert.ToInt32(dtQuot.Rows[0]["scope"].ToString());
                            if (movementtype == 1)
                            {
                                ddl_moveTypes.SelectedValue = "1";
                            }
                            else if (movementtype == 2)
                            {
                                ddl_moveTypes.SelectedValue = "2";
                            }
                            else if (movementtype == 3)
                            {
                                ddl_moveTypes.SelectedValue = "3";
                            }
                            else if (movementtype == 4)
                            {
                                ddl_moveTypes.SelectedValue = "4";
                            }
                            else if (movementtype == 0)
                            {
                                ddl_moveTypes.SelectedValue = "0";
                            }


                        }
                        else
                        {
                            ddl_moveTypes.SelectedValue = "0";
                        }
                        //if (Session["StrTranType"].ToString() == "FI" || Session["StrTranType"].ToString() == "AI")
                        //{
                        intcustid = dtQuot.Rows[0]["consigneeid"].ToString();
                        hdn_Consigneeid.Value = dtQuot.Rows[0]["consigneeid"].ToString();
                        if (intcustid == "0")
                        {
                            txt_consignee.Text = "";
                            txt_consigneemulti.Text = "";
                        }
                        else
                        {
                            txt_consignee.Text = custobj.GetCustomername(Convert.ToInt32(intcustid));
                            txt_consigneemulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(intcustid));
                        }
                        //DataTable dtmail = new DataTable();
                        //string Shipmail = custobj.GetCusMailaddrs(Convert.ToInt32(dtBuying.Rows[0]["customerid"].ToString()));

                        //if (Shipmail != "")
                        //{
                        //    dtmail = new DataTable();
                        //    dtmail.Columns.Add("email");
                        //    dtmail.Columns.Add("Cname");
                        //    dtmail.Rows.Add(Shipmail, "Consignee");
                        //    grdCMail.DataSource = dtmail;
                        //    grdCMail.DataBind();
                        //    ViewState["CurrentData"] = dtmail;
                        //}
                        //}
                        //else
                        //{
                        hdn_shipperid.Value = dtQuot.Rows[0]["shipperid"].ToString();
                        if (dtQuot.Rows[0]["shipperid"].ToString() != "")
                        {
                            if (hdn_shipperid.Value == "0")
                            {
                                txt_shiper.Text = "";
                                txt_shipermulti.Text = "";
                            }
                            else
                            {

                                txt_shiper.Text = custobj.GetCustomername(Convert.ToInt32(dtQuot.Rows[0]["shipperid"].ToString()));
                                txtCustomer.Text = txt_shiper.Text;
                                txt_shipermulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(dtQuot.Rows[0]["shipperid"].ToString()));
                            }
                        }
                        //DataTable dtmail = new DataTable();
                        //string Shipmail = custobj.GetCusMailaddrs(Convert.ToInt32(dtBuying.Rows[0]["customerid"].ToString()));

                        //if (Shipmail != "")
                        //{
                        //    dtmail = new DataTable();
                        //    dtmail.Columns.Add("email");
                        //    dtmail.Columns.Add("Cname");
                        //    dtmail.Rows.Add(Shipmail, "Shipper");
                        //    grdCMail.DataSource = dtmail;
                        //    grdCMail.DataBind();
                        //    ViewState["CurrentData"] = dtmail;
                        //}

                        //}
                        app = Convert.ToInt32(dtQuot.Rows[0]["approvedby"].ToString());
                        hdf_app.Value = app.ToString();
                        txtapprovedby.Text = dtQuot.Rows[0]["approvedbyname"].ToString();
                        //bhuvana
                        //int crmid = objcrm.GetCRMid(Convert.ToInt32(txtQuotation.Text.ToUpper()), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        //txtcrm.Text = crmid.ToString();

                        DataTable dtgroup = new DataTable();
                        DataTable dtgr = new DataTable();

                        dtgroup = customer.GetCustomernamegroupid(customerid);
                        if (dtgroup.Rows.Count > 0)
                        {


                            txtCustomer.Text = dtgroup.Rows[0]["customername"].ToString();
                            txtaddress.Text = dtgroup.Rows[0]["address"].ToString();
                            //if (dtgroup.Rows[0]["groupid"].ToString() != null)
                            if (!string.IsNullOrEmpty(dtgroup.Rows[0]["groupid"].ToString()))
                            {
                                hidgroupid.Value = dtgroup.Rows[0]["groupid"].ToString();
                                dtgr = objoua.RetrieveCustGroupDetails(Convert.ToInt32(hidgroupid.Value));

                                if (dtgr.Rows.Count > 0)
                                {
                                    txtgroupcustomer.Text = dtgr.Rows[0]["groupname"].ToString();
                                    txtgroupAddress.Text = dtgr.Rows[0]["address"].ToString();

                                }

                            }


                        }
                        //Bind_outstandingdetails();
                        string trantype = dtQuot.Rows[0]["trantype"].ToString();
                        if ((trantype == "AI") || (trantype == "AE"))
                        {

                            DataTable Dt = new DataTable();
                            Dt.Columns.Add("checksbno");
                            Dt.Columns.Add("conttype");
                            Dt.Columns.Add("txt_Sizecount");
                            Dt.Rows.Add();
                            Dt.Rows[0]["conttype"] = "KGS";
                            Dt.Rows.Add();
                            Dt.Rows[1]["conttype"] = "PER TRUCK";
                            Dt.Rows.Add();
                            Dt.Rows[2]["conttype"] = "COTTON/PALLET";
                            Dt.Rows.Add();
                            Dt.Rows[3]["conttype"] = "AT ACTUALS";
                            grd_Sizetype.DataSource = Dt;
                            grd_Sizetype.DataBind();

                        }
                        else
                        {

                            DataTable Dt = new DataTable();
                            //chkContainerList.Items.Clear();
                            DataSet ds1 = new DataSet();
                            DataTable dtpkg1 = new DataTable();
                            ds1 = container.GetContainersize();
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                dtpkg1 = ds1.Tables[0];
                                Dt.Columns.Add("checksbno");
                                Dt.Columns.Add("conttype");
                                Dt.Columns.Add("txt_Sizecount");

                                if (dtpkg1.Rows.Count > 0)
                                {
                                    //Dt.Rows.Add();
                                    //Dt.Rows[0]["conttype"] = "CBM";
                                    for (int j = 0; j <= dtpkg1.Rows.Count - 1; j++)
                                    {
                                        Dt.Rows.Add();
                                        //Dt.Rows[0]["conttype"] = "CBM";
                                        Dt.Rows[j]["conttype"] = dtpkg1.Rows[j]["conttype"].ToString();
                                    }

                                    Dt.Rows.Add();
                                    Dt.Rows[dtpkg1.Rows.Count]["conttype"] = "CBM";
                                    Dt.Rows.Add();
                                    Dt.Rows[dtpkg1.Rows.Count + 1]["conttype"] = "MT";
                                    //Dt.Rows.Add();
                                    //Dt.Rows[dtpkg1.Rows.Count + 2]["conttype"] = "AT ACTUALS";
                                    grd_Sizetype.DataSource = Dt;
                                    grd_Sizetype.DataBind();
                                }
                                // chkContainerList.DataSource = dtpkg1;
                                // chkContainerList.DataTextField = "conttype";
                                // chkContainerList.DataValueField = "conttype";
                                // chkContainerList.DataBind();
                                //chkContainerList.Items.Insert(1, "BL");
                                //chkContainerList.Items.Insert(2, "CBM");
                                //chkContainerList.Items.Insert(3, "MT");
                            }
                            else
                            {
                                grd_Sizetype.DataSource = Utility.Fn_GetEmptyDataTable();
                                grd_Sizetype.DataBind();
                            }
                        }
                        gridsize();

                        //txtCustomer.Text = customer.GetCustomername(customerid);

                        txtPOL.Text = port.GetPortname(intpol);
                        txtPOD.Text = port.GetPortname(intpod);
                        txtPOR.Text = port.GetPortname(intpor);
                        txtFD.Text = port.GetPortname(intfd);
                        DataTable dtflag;
                        //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                        
                        dtflag = obj_MasterPort.SelPortName4typepadimg(txtFD.Text.ToUpper(), Session["StrTranType"].ToString());
                        fdflag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";

                        dtflag = obj_MasterPort.SelPortName4typepadimg(txtPOR.Text.ToUpper(), Session["StrTranType"].ToString());
                        porflag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";

                        dtflag = obj_MasterPort.SelPortName4typepadimg(txtPOD.Text.ToUpper(), Session["StrTranType"].ToString());
                        podflag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";

                        dtflag = obj_MasterPort.SelPortName4typepadimg(txtPOL.Text.ToUpper(), Session["StrTranType"].ToString());
                        flagimg.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";
                        txtCargo.Text = cargo.GetCargoname(cargoid);
                        txtSalesPerson.Text = employee.GetEmployeeName(sales);
                        //txtPreparedBy.Text = "Prepared By : " + employee.GetEmployeeName(prepared);
                        txtPreparedBy.Text = employee.GetEmployeeName(prepared);
                        if (app == 0)
                        {
                            txtEnable();
                        }
                        else
                        {
                            txtUnable();
                        }
                        if (hazard == 1)
                        {
                            chkHazard.Checked = true;
                        }
                        else
                        {
                            chkHazard.Checked = false;
                        }
                        ddlShipment.Text = Strshipment;
                        ddlFreight.Text = strfstatus;
                        //dtQuot = quotation.ChargeDetailsnew(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                        //if (dtQuot.Rows.Count > 0)
                        //{
                        //    int i;
                        //    txtTotal.Text = "";
                        //    double tot = 0, tot1 = 0;
                        //    for (i = 0; i <= dtQuot.Rows.Count - 1; i++)
                        //    {
                        //        tot1 = Convert.ToDouble(dtQuot.Rows[i]["amount"]);
                        //        tot = tot + tot1;
                        //    }
                        //    DataRow Drow1 = dtQuot.NewRow();
                        //    Drow1["amount"] = tot.ToString("#,0.00");
                        //    dtQuot.Rows.Add(Drow1);
                        //    txtTotal.Text = tot.ToString("#,0.00");
                        //    hid_tot.Value = tot.ToString("#,0.00");
                        //    grdQuotation.DataSource = dtQuot;
                        //    grdQuotation.DataBind();
                        //}
                        //else
                        //{
                        //    hid_tot.Value = "0";
                        //}



                        // end 

                        //int l;
                        //txtTotal.Text = "";
                        //double tot = 0, tot1 = 0;
                        //for (l = 0; l <= grdQuotation.Rows.Count - 1; l++)
                        //{
                        //    tot1 = Convert.ToDouble(grdQuotation.Rows[l].Cells[6].Text);
                        //    tot = tot + tot1;
                        //}
                        //txtTotal.Text = tot.ToString("#,0.00");
                        //hid_tot.Value = tot.ToString("#,0.00");
                        DataTable Dtnew1 = new DataTable();
                        Dtnew1 = quotation.CheckInquiryForBookingFromQno(quotid, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), "B");
                        if (Dtnew1.Rows.Count > 0)
                        {
                            //txtBuying.Text = Dt.Rows[0]["buyingno"].ToString();
                            // string Customer = custobj.GetCustomername(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()));

                            string Customer = quotation.quotbuyingget(Convert.ToInt32(Dtnew1.Rows[0]["buyingno"].ToString()));

                            string pol = portobj.GetPortname(Convert.ToInt32(Dtnew1.Rows[0]["pol"].ToString()));
                            string pod = portobj.GetPortname(Convert.ToInt32(Dtnew1.Rows[0]["pod"].ToString()));
                            string status;
                            if (Dtnew1.Rows[0]["stype"].ToString() == "F")
                            {
                                status = "FCL";
                            }
                            else
                            {
                                status = "LCL";
                            }

                            txtBuying.Text = Dtnew1.Rows[0]["buyingno"].ToString();
                            hid_rateid.Value = Dtnew1.Rows[0]["buyingno"].ToString();
                            string buying = Customer + "/" + pol + "-" + pod + "/" + status;
                            if (txtBuying.Text != "0")
                            {
                                txtBuyingDetails.Text = buying;

                            }
                            else
                            {
                                txtBuyingDetails.Text = "";
                            }

                            //GetBuyingGrid();
                            //// yuvaraj 06/09/2022
                            //DataTable dtss = buyingobj.Sellbuyingdeatils(Convert.ToInt32(txtBuying.Text), quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                            //if (dtss.Rows.Count > 0)
                            //{
                            //    int i;
                            //    txtTotal.Text = "";
                            //    double totals = 0;
                            //    double amounts = 0;
                            //    txtbuygrid.Text = "";
                            //    double totb = 0, totb1 = 0;
                            //    for (i = 0; i <= dtss.Rows.Count - 1; i++)
                            //    {
                            //        totals = Convert.ToDouble(dtss.Rows[i]["amount"]);
                            //        amounts = amounts + totals;
                            //        totb1 = Convert.ToDouble(dtss.Rows[i]["sell"]);
                            //        totb = totb + totb1;
                            //    }
                            //    txtbuyings.Text = amounts.ToString("#,0.00");
                            //    hid_tot.Value = amounts.ToString("#,0.00");
                            //    txtselling.Text = totb.ToString("#,0.00");
                            //    Hidtotal.Value = totb.ToString("#,0.00");

                            //    //DataRow Drow6 = dtss.NewRow();
                            //    //Drow6["amount"] = tot.ToString("#,0.00");
                            //    //dtss.Rows.Add(Drow6);
                            //    //txtTotal.Text = tot.ToString("#,0.00");
                            //    //hid_tot.Value = tot.ToString("#,0.00");

                            //    //DataRow Drow3 = dtss.NewRow();
                            //    //Drow3["sell"] = totb.ToString("#,0.00");
                            //    //dtss.Rows.Add(Drow3);
                            //    //txtbuygrid.Text = totb.ToString("#,0.00");
                            //    ////.Value = totb.ToString("#,0.00");
                            //    //Hidtotal.Value = totb.ToString("#,0.00");

                            //    GrdBuysellcharge.DataSource = dtss;
                            //    GrdBuysellcharge.DataBind();
                            //}

                            //    double profitamount = Convert.ToDouble(Hidtotal.Value) - Convert.ToDouble(hid_tot.Value);
                            //    if (profitamount != 0.0)
                            //    {
                            //        txtprofitamount.Text = profitamount.ToString("#,0.00");
                            //    }
                            //    else
                            //    {
                            //        txtprofitamount.Text = "";
                            //    }
                            //}
                            //else
                            //{
                            //    DataTable dt1 = new DataTable();
                            //    baseFil();
                            //}
                            btnclose.Text = "Cancel";
                            btnclose.ToolTip = "Cancel";
                            btn_back1.Attributes["class"] = "btn ico-cancel";
                            btnclose.Enabled = true;
                            btnclose.ForeColor = System.Drawing.Color.White;
                            btnApp.Enabled = false;
                            btnApp.ForeColor = System.Drawing.Color.Gray;

                            txtCargeEnable();
                            grdQuotation.Enabled = true;
                            baseFil();
                            btnSave.Text = "Update";
                            btnSave.ToolTip = "Update";
                            btn_save.Attributes["class"] = "btn ico-update";
                            UserRights();
                        }


                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Inquiry Number');", true);
                            txtQuotation.Focus();
                            return;
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Inquiry Number');", true);
                        txtQuotation.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txtQuotation.Text = "";
                txtQuotation.Focus();
            }


            DataTable buytable = new DataTable();

            buytable = quotation.GetRateId(quotid);

            string rateid = RateLabel1.Text;


            RateLabel1.Text = buytable.Rows[0]["buyingno"].ToString();


            if (RateLabel1.Text != "" && RateLabel1.Text != "0")
            {
                DataTable quottable = new DataTable();

                quottable = quotation.GetQuotId(Convert.ToInt16(RateLabel1.Text));

                if (quottable.Rows.Count > 0)
                {
                    GenQuotBtn.Text = quottable.Rows[0]["quotno"].ToString();


                }
            }

        }

        protected void txtCharges_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ddlBase.Enabled = true;
                btnAdd.Enabled = true;
                btnAdd.ForeColor = System.Drawing.Color.White;
                txtCharges.Enabled = true;
                txtCurr.Enabled = true;
                txtRate.Enabled = true;
                if (lblHeader.Text == "")
                {
                    dtQuot = charges.GetLikeCharges(txtCharges.Text);
                    if (dtQuot.Rows.Count > 0)
                    {
                        hdf_Charges.Value = dtQuot.Rows[0]["chargeid"].ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Invalid Charge Name');", true);
                        txtCharges.Focus();
                        return;
                    }
                }
                else
                {
                    int chargeid = charges.GetChargeid(txtCharges.Text.Trim().ToUpper());
                    if (chargeid != 0)
                    {

                    }
                    else
                    {
                        txtCharges.Text = "";
                        txtCharges.Focus();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Charges');", true);
                        return;

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

        protected void btnApp_Click(object sender, EventArgs e)
        {
            if (ddl_product.SelectedItem.Text == "")
            {
                Session["StrTranType"] = "";
            }
            //string str_mailserver = Session["MailServer"].ToString();
            string str_usermailid = Session["usermailid"].ToString();
            //string str_mailuser = Session["MailUser"].ToString();
            string str_mailpwd = Session["usermailpwd"].ToString();
            try
            {

                //    txtCustomer_TextChanged(sender, e);
                txtCargo_TextChanged(sender, e);
                txtPOR_TextChanged(sender, e);
                txtPOL_TextChanged(sender, e);
                txtPOD_TextChanged(sender, e);
                txtFD_TextChanged(sender, e);

                if (brr == true)
                {
                    return;
                }
                if (btnApp.ToolTip == "Approve")
                {


                    if (txtQuotation.Text != "" && txtCustomer.Text != "" && txtPOR.Text != "" && txtPOL.Text != "" && txtPOD.Text != "" && txtFD.Text != "")
                    {
                        quotid = Convert.ToInt32(txtQuotation.Text);
                        hid_quotno.Value = txtQuotation.Text;
                        ValidateFunction();
                        CollectData();
                        intapprovedbyid = Convert.ToString(1);
                        DateTime appdate;
                        appdate = Logobj.GetDate();
                        strapproved = Session["LoginUserName"].ToString();
                        if (grdQuotation.Rows.Count > 0)
                        {
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Charges are not Available in this Inquiry');", true);
                            return;
                        }
                        int intpby;
                        intpby = employee.GetNEmpid(txtPreparedBy.Text);
                        int empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                        //if (intpby == empid)
                        //{
                        //    ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('You can not approve the Quotation prepared by you');", true);
                        //}
                        //else
                        //{
                        /// quotation.UpdateQuotationDetailsWApp(quotid, Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text)), Convert.ToInt32(hdf_customerid.Value), Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value), Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.Text, ddlFreight.Text, Convert.ToInt32(hdf_cargoid.Value), txtDescription.Text, Convert.ToInt32(hdf_salesperson.Value), intpby, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hdf_Hazard.Value), appdate, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 180, 1, Convert.ToInt32(Session["LoginBranchid"]), "OE_QuotApp # : " + quotid);
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 181, 1, Convert.ToInt32(Session["LoginBranchid"]), "OI_QuotApp # : " + quotid);
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 217, 1, Convert.ToInt32(Session["LoginBranchid"]), "AE_QuotApp # : " + quotid);
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 215, 1, Convert.ToInt32(Session["LoginBranchid"]), "AI_QuotApp # : " + quotid);
                                break;
                        }
                        // SendDeleiveryStatus();
                        usermail = HrEmpobj.GetMailAdd(Convert.ToInt32(hdf_salesperson.Value));
                        dtQuot = userperobj.GetMLEmpid(userperobj.GetMLUiid(Session["StrTranType"].ToString(), "Quotation Approval"), Convert.ToInt32(Session["LoginBranchid"]));

                        for (int i = 0; i <= dtQuot.Rows.Count - 1; i++)
                        {
                            empmailadd = empmailadd + HrEmpobj.GetMailAdd(Convert.ToInt32(dtQuot.Rows[i][0].ToString())) + ";";
                        }

                        ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Inquiry Approved');", true);


                        if (empmailadd != "")
                        {
                            empmailadd = empmailadd.Substring(0, empmailadd.Length - 1);
                            Utility.SendMail(usermail, empmailadd, "Quotation # : " + txtQuotation.Text + "-" + txtPOL.Text + " to " + txtPOD.Text, sendqry, "", str_mailpwd, "", "");



                        }
                    }
                }
                else if (btnApp.ToolTip == "Delete")
                {
                    string ddlversion = "";
                    if (ddl_version.Text == "")
                    {
                        ddlversion = "0";
                    }
                    else
                    {
                        ddlversion = ddl_version.Text;
                    }
                    DataSet dsQuot = new DataSet();
                    DataTable dtQuottt = new DataTable();
                    dtQuottt = quotation.GetcombbinedQuotationDetails(Convert.ToInt32(txtQuotation.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    dtQuot = quotation.GetcombbinedQuotationDetailsversion(Convert.ToInt32(txtQuotation.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(ddlversion.ToString()));
                    string ver = "";
                    if (dtQuottt.Rows.Count > 0)
                    {
                        if (dtQuottt.Rows[0]["version"].ToString() == "0")
                        {
                            // ver = "";
                        }
                        if (ddlversion == dtQuottt.Rows[0]["version"].ToString())
                        {



                            if (txtCharges.Text != "" && txt_sellrate.Text != "" && txtCurr.Text != "" && ddlBase.SelectedIndex != 0)
                            {
                                if (txtQuotation.Text != "")
                                {
                                    dtQuot = quotation.CheckQuotForBookingFromQno(Convert.ToInt32(txtQuotation.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), "Q");
                                    if (dtQuot.Rows.Count > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Booking Already done, you cannot Delete this Inquiry);", true);
                                        return;
                                    }
                                }
                                int intchargeid = charges.GetChargeid(txtCharges.Text);
                                quotation.DeleteGrdchargesnew(txtCharges.Text, Convert.ToInt32(txtQuotation.Text), ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"]));



                                if (txtBuying.Text != "")
                                {
                                    DataTable dt_quot = new DataTable();
                                    //DataAccess.Marketing.Quotation quotobj = new DataAccess.Marketing.Quotation();
                                    int chargeid = chargeobj.GetChargeid(txtCharges.Text);


                                    dt_quot = quotobj.CheckQuotForBookingFromQno(Convert.ToInt32(txtBuying.Text), "FE", Convert.ToInt32(Session["LoginBranchid"].ToString()), "B");

                                    if (dt_quot.Rows.Count > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Booking Already used this Buying .Create a New Buying.');", true);
                                        return;
                                    }

                                    dt_quot = quotobj.CheckQuotForBookingFromQno(Convert.ToInt32(txtBuying.Text), "FE", Convert.ToInt32(Session["LoginBranchid"].ToString()), "BB");
                                    if (dt_quot.Rows.Count > 0 && (txtQuotation.Text == dt_quot.Rows[0]["quotno"]))
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Inquiry Already used this Buying .Create a New Buying.');", true);
                                        return;
                                    }




                                    //new 
                                    buyingobj.DelBuyingDetailnew(Convert.ToInt32(txtBuying.Text), chargeid, ddlBase.Text);
                                    dtbuying = buyingobj.SelBuyingDetailsnew(Convert.ToInt32(txtBuying.Text));
                                    grdBuying.DataSource = dtbuying;
                                    grdBuying.DataBind();
                                    if (grdBuying.Rows.Count == 0)
                                    {

                                        buyingobj.UpdBuyHeadDelYes(Convert.ToInt32(txtBuying.Text));
                                        // yuvaraj 06/09/2022

                                        //  ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Details Deleted...", true);
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details Deleted...');", true);

                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 18, 1, Convert.ToInt32(Session["LoginBranchid"]), "/CustID: " + hdnCarrier.Value + "/CargoID: " + cargoid + "/ D");

                                        //return;
                                    }
                                }
                                DataTable dtss = buyingobj.Sellbuyingdeatils(Convert.ToInt32(txtBuying.Text), Convert.ToInt32(txtQuotation.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                                if (dtss.Rows.Count > 0)
                                {
                                    int i;
                                    txtTotal.Text = "";
                                    double totals = 0;
                                    double amounts = 0;
                                    txtbuygrid.Text = "";
                                    double totb = 0, totb1 = 0;
                                    for (i = 0; i <= dtss.Rows.Count - 1; i++)
                                    {
                                        totals = Convert.ToDouble(dtss.Rows[i]["amount"]);
                                        amounts = amounts + totals;
                                        totb1 = Convert.ToDouble(dtss.Rows[i]["sell"]);
                                        totb = totb + totb1;
                                    }
                                    txtbuyings.Text = amounts.ToString("#,0.00");
                                    hid_tot.Value = amounts.ToString("#,0.00");
                                    txtselling.Text = totb.ToString("#,0.00");
                                    Hidtotal.Value = totb.ToString("#,0.00");

                                    //DataRow Drow6 = dtss.NewRow();
                                    //Drow6["amount"] = tot.ToString("#,0.00");
                                    //dtss.Rows.Add(Drow6);
                                    //txtTotal.Text = tot.ToString("#,0.00");
                                    //hid_tot.Value = tot.ToString("#,0.00");

                                    //DataRow Drow3 = dtss.NewRow();
                                    //Drow3["sell"] = totb.ToString("#,0.00");
                                    //dtss.Rows.Add(Drow3);
                                    //txtbuygrid.Text = totb.ToString("#,0.00");
                                    ////.Value = totb.ToString("#,0.00");
                                    //Hidtotal.Value = totb.ToString("#,0.00");

                                    GrdBuysellcharge.DataSource = dtss;
                                    GrdBuysellcharge.DataBind();
                                }

                                double profitamount = Convert.ToDouble(Hidtotal.Value) - Convert.ToDouble(hid_tot.Value);
                                if (profitamount != 0.0)
                                {
                                    txtprofitamount.Text = profitamount.ToString("#,0.00");
                                }
                                else
                                {
                                    txtprofitamount.Text = "";
                                }
                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 181, 4, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "/" + intchargeid + "OE_QuotChargeD");
                                        break;
                                    case "FI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 180, 4, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "/" + intchargeid + "OI_QuotChargeD");
                                        break;
                                    case "AE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 217, 4, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "/" + intchargeid + "AE_QuotChargeD");
                                        break;
                                    case "AI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 215, 4, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "/" + intchargeid + "AI_QuotChargeD");
                                        break;
                                }
                                //ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Quotation Approved');", true);
                                dtQuot = quotation.ChargeDetailsnew(Convert.ToInt32(txtQuotation.Text), Convert.ToInt32(Session["LoginBranchid"]), "");
                                grdQuotation.DataSource = new DataTable();
                                grdQuotation.DataBind();
                                if (dtQuot.Rows.Count > 0)
                                {
                                    int i;
                                    txtTotal.Text = "";
                                    double tot = 0, tot1 = 0;
                                    for (i = 0; i <= dtQuot.Rows.Count - 1; i++)
                                    {
                                        tot1 = Convert.ToDouble(dtQuot.Rows[i]["amount"]);
                                        tot = tot + tot1;
                                    }
                                    DataRow Drow1 = dtQuot.NewRow();
                                    Drow1["amount"] = tot.ToString("#,0.00");
                                    dtQuot.Rows.Add(Drow1);
                                    txtTotal.Text = tot.ToString("#,0.00");
                                    hid_tot.Value = tot.ToString("#,0.00");
                                    grdQuotation.DataSource = dtQuot;
                                    grdQuotation.DataBind();
                                }
                                //int j;
                                //txtTotal.Text = "";
                                //double tot = 0, tot1 = 0;
                                //for (j = 0; j <= grdQuotation.Rows.Count - 1; j++)
                                //{
                                //    tot1 = Convert.ToDouble(grdQuotation.Rows[j].Cells[6].Text);
                                //    tot = tot + tot1;
                                //}
                                //txtTotal.Text = tot.ToString("#,0.00");
                                clearCharges();
                                if ((ddl_product.SelectedValue == "Air Imports") || (ddl_product.SelectedValue == "Air Exports"))
                                {

                                    DataTable Dt = new DataTable();
                                    Dt.Columns.Add("checksbno");
                                    Dt.Columns.Add("conttype");
                                    Dt.Columns.Add("txt_Sizecount");
                                    Dt.Rows.Add();
                                    Dt.Rows[0]["conttype"] = "KGS";
                                    Dt.Rows.Add();
                                    Dt.Rows[1]["conttype"] = "PER TRUCK";
                                    Dt.Rows.Add();
                                    Dt.Rows[2]["conttype"] = "COTTON/PALLET";
                                    Dt.Rows.Add();
                                    Dt.Rows[3]["conttype"] = "AT ACTUALS";
                                    grd_Sizetype.DataSource = Dt;
                                    grd_Sizetype.DataBind();

                                }
                                else
                                {

                                    DataTable Dt = new DataTable();
                                    //chkContainerList.Items.Clear();
                                    DataSet ds1 = new DataSet();
                                    DataTable dtpkg1 = new DataTable();
                                    ds1 = container.GetContainersize();
                                    if (ds1.Tables[0].Rows.Count > 0)
                                    {
                                        dtpkg1 = ds1.Tables[0];
                                        Dt.Columns.Add("checksbno");
                                        Dt.Columns.Add("conttype");
                                        Dt.Columns.Add("txt_Sizecount");

                                        if (dtpkg1.Rows.Count > 0)
                                        {
                                            //Dt.Rows.Add();
                                            //Dt.Rows[0]["conttype"] = "CBM";
                                            for (int k = 0; k <= dtpkg1.Rows.Count - 1; k++)
                                            {
                                                Dt.Rows.Add();
                                                //Dt.Rows[0]["conttype"] = "CBM";
                                                Dt.Rows[k]["conttype"] = dtpkg1.Rows[k]["conttype"].ToString();
                                            }

                                            Dt.Rows.Add();
                                            Dt.Rows[dtpkg1.Rows.Count]["conttype"] = "CBM";
                                            Dt.Rows.Add();
                                            Dt.Rows[dtpkg1.Rows.Count + 1]["conttype"] = "MT";
                                            //Dt.Rows.Add();
                                            //Dt.Rows[dtpkg1.Rows.Count + 2]["conttype"] = "AT ACTUALS";
                                            grd_Sizetype.DataSource = Dt;
                                            grd_Sizetype.DataBind();
                                        }
                                        // chkContainerList.DataSource = dtpkg1;
                                        // chkContainerList.DataTextField = "conttype";
                                        // chkContainerList.DataValueField = "conttype";
                                        // chkContainerList.DataBind();
                                        //chkContainerList.Items.Insert(1, "BL");
                                        //chkContainerList.Items.Insert(2, "CBM");
                                        //chkContainerList.Items.Insert(3, "MT");
                                    }
                                    else
                                    {
                                        grd_Sizetype.DataSource = Utility.Fn_GetEmptyDataTable();
                                        grd_Sizetype.DataBind();
                                    }
                                }
                                gridsize();



                                // btnAdd.Text = "Add";
                                btnAdd.ToolTip = "Add";
                                btn_add.Attributes["class"] = "btn ico-add";
                            }
                        }
                    }
                    else
                    {
                        dtQuot = quotation.QuotDetails(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                        if (dtQuot.Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('No Inquiry available to Delete');", true);
                        }
                        if (dtQuot.Rows.Count > 0)
                        {
                            grdQuotaionDetails.DataSource = dtQuot;
                            grdQuotaionDetails.DataBind();
                            Panel6.Visible = false;
                            ViewState["inquiry"] = dtQuot;
                            pnlJobAE.Visible = true;
                            this.popupQuot.Show();

                        }
                    }
                    btnApp.Enabled = false;
                    btnApp.ForeColor = System.Drawing.Color.Gray;
                }
                UserRights();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        //public void GetCompanyName()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        string zipcode = "";
        //        dtQuot = Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
        //        if (dtQuot.Rows.Count > 0)
        //        {
        //            if (strtrantype == "FE" || strtrantype == "AE")
        //            {
        //                custtype = "S";
        //            }
        //            else
        //            {
        //                custtype = "C";
        //            }
        //            strcity = customer.GetCustlocation(customerid);
        //            if (strtrantype == "FE" || strtrantype == "AE")
        //            {
        //                custtype = "Shipper";
        //            }
        //            else
        //            {
        //                custtype = "Consignee";
        //            }
        //            dt = quotation.RetrieveCustomerDetails4Pin(customerid);
        //            if (dt.Rows.Count > 0)
        //            {
        //                straddress = dt.Rows[0]["address"].ToString();
        //                intzip = dt.Rows[0]["pincode"].ToString();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }

        //}

        protected void txtPOR_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = port.GetPortName(txtPOR.Text.ToUpper());
                if (dt.Rows.Count > 0 || hdf_POR.Value != "0")
                {
                    hdf_POR.Value = dt.Rows[0]["portid"].ToString();
                    //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                    dt = obj_MasterPort.SelPortName4typepadimg(txtPOR.Text.ToUpper(), Session["StrTranType"].ToString());
                    porflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    txtPOL.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Invalid Place of Receipt');", true);
                    txtPOR.Text = "";
                    txtPOR.Focus();
                    brr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtPOL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = port.GetPortName(txtPOL.Text.ToUpper());
                if (dt.Rows.Count > 0 && hdf_POL.Value != "0")
                {

                    hdf_POL.Value = dt.Rows[0]["portid"].ToString();
                    //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                    dt = obj_MasterPort.SelPortName4typepadimg(txtPOL.Text.ToUpper(), Session["StrTranType"].ToString());
                    flagimg.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    txtPOD.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Invalid Port of Loading');", true);
                    txtPOL.Text = "";
                    txtPOL.Focus();
                    brr = true;
                    return;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtPOD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = port.GetPortName(txtPOD.Text.ToUpper());
                if (dt.Rows.Count > 0 && hdf_POD.Value != "0")
                {
                    hdf_POD.Value = dt.Rows[0]["portid"].ToString();
                    //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                    dt = obj_MasterPort.SelPortName4typepadimg(txtPOD.Text.ToUpper(), Session["StrTranType"].ToString());
                    podflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    txtFD.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Invalid Port of Discharge');", true);
                    txtPOD.Text = "";
                    txtPOD.Focus();
                    brr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtFD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = port.GetPortName(txtFD.Text.ToUpper());
                if (dt.Rows.Count > 0 && hdf_FD.Value != "0")
                {
                    hdf_FD.Value = dt.Rows[0]["portid"].ToString();
                    txt_custpono.Focus();
                    //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                    dt = obj_MasterPort.SelPortName4typepadimg(txtFD.Text.ToUpper(), Session["StrTranType"].ToString());
                    fdflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    if (txtPOD.Text != "" && txtPOL.Text != "" && txtPOR.Text != "")
                    {
                        // txt_routing.Text = txtPOL.Text.ToUpper() + " - " + txtFD.Text.ToUpper();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Invalid Place of Delivery');", true);
                    txtFD.Text = "";
                    txtFD.Focus();
                    brr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtCargo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = cargo.CheckCargoExist(txtCargo.Text.ToUpper());
                if (dt.Rows.Count > 0 && hdf_cargoid.Value != "0")
                {
                    hdf_cargoid.Value = dt.Rows[0]["cargoid"].ToString();
                    txtDescription.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Invalid Cargo Type');", true);
                    txtCargo.Text = "";
                    txtCargo.Focus();
                    brr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtCurr_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtCurr.Text != "")
            //    {
            //        hdf_Curr.Value = charges.GetCurrID(txtCurr.Text.ToUpper()).ToString();
            //        txtRate.Focus();
            //        if (hdf_Curr.Value == "0")
            //        {
            //            ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Invalid Currency');", true);
            //            txtCurr.Text = "";
            //            txtCurr.Focus();
            //            return;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}
            try
            {

                //DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                strtrantype = Session["StrTranType"].ToString();
                int currid = chargeobj.GetCurrID(txtCurr.Text.Trim().ToUpper());
                string date = Logobj.GetDate().ToShortDateString();
                date = Utility.fn_ConvertDate(date.ToString());
                if (currid != 0)
                {
                    if (txtCharges.Text != "" && txtCurr.Text != "")
                    {
                        if (txtCurr.Text.ToUpper() != "INR")
                        {
                            // txtex.Text = INVOICEobj.GetCheckInvExrate(Convert.ToInt32(txtjobno.Value), str_TranType, int_branchid, txtCurr.Text).ToString();
                            //if (txtex.Text == "0")
                            //{
                            txtex.Text = INVOICEobj.GetExRate(txtCurr.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDate(date.ToString())), "R", Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                            hid_exrate.Value = txtex.Text;
                            txtRate.Focus();
                            // txt_sellrate.Text = "";
                            //txtex .Text="";
                            //}
                            //else
                            //{
                            //    txtex.Text = INVOICEobj.GetExRate(txtCurr.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), "R").ToString();       
                            //}
                            if (txtex.Text == "0")
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Ex. Rate Not Available .", true);
                                txtex.Focus();
                                txtex.Text = "";
                                return;
                            }
                        }
                        else
                        {

                            txtex.Text = INVOICEobj.GetExRate(txtCurr.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDate(date.ToString())), "R", Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                            hid_exrate.Value = txtex.Text;
                            txtex.Focus();
                        }

                    }
                    //txtrate.Focus();    
                }
                else
                {
                    txtCurr.Text = "";
                    txtCurr.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Currency');", true);
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtex_TextChanged(object sender, EventArgs e)
        {
            //DataAccess.UserPermission userobj = new DataAccess.UserPermission();
            string script = "";
            string date = Logobj.GetDate().ToShortDateString();
            date = Utility.fn_ConvertDate(date.ToString());
            //if (txtref.Text == "")
            //{
            //    return;
            //}
            if (txtex.Text != "")
            {
                //if (lbl_Header.Text == "Profoma Invoice")
                //{
                //    Dt = userobj.GetBtnPermission(Convert.ToInt32(Session["LoginEmpId"]), branchid, 287);
                //    if (Dt.Rows.Count > 0)
                //    {
                //currexrate = INVOICEobj.GetCheckInvExrate(Convert.ToInt32(txtjobno.Value), strtrantype, Convert.ToInt32(Session["LoginBranchid"]), txtCurr.Text);
                //        script = "Less than PA Exrate Not Allowed";
                //        if (currexrate == 0)
                //        {
                //    currexrate = INVOICEobj.GetExRate(txtCurr.Text, Convert.ToDateTime(Utility.fn_ConvertDate(txtDate.Text)), "R");
                //            script = "Less than Current Exrate Not Allowed";
                //        }

                //        if (Convert.ToDouble(txtex.Text) < currexrate)
                //        {
                //    txtex.Text = INVOICEobj.GetExRate(txtCurr.Text, Convert.ToDateTime(Utility.fn_ConvertDate(txtDate.Text)), "R").ToString();
                //            txtex.Focus();
                //            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + script + "');", true);

                //            return;
                //        }

                //}
                //else
                //{
                currexrate = INVOICEobj.GetExRate(txtCurr.Text, Convert.ToDateTime(Utility.fn_ConvertDate(date.ToString())), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                if (Convert.ToDouble(txtex.Text) < currexrate)
                {
                    txtex.Text = INVOICEobj.GetExRate(txtCurr.Text, Convert.ToDateTime(Utility.fn_ConvertDate(date.ToString())), "R", Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                    txtex.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Less than Current Exrate Not Allowed');", true);
                    return;
                }
                //}
                //}
            }
            // ddlBase_SelectedIndexChanged(sender, e);
        }

        protected void ddlBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (txtref.Text == "")
            //{
            //    return;
            //}
            if (ddlBase.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Any Of One of Base...');", true);
                return;
            }


            if (ddlBase.Text != "" && txtCharges.Text != "" && txtCurr.Text != "" && txtRate.Text != "")
            {

                //string strbase = ddlBase.Text;
                //famount = Convert.ToDouble(hid_rate.Value) * Convert.ToDouble(hid_exrate.Value) * Convert.ToInt32(hid_expqty.Value); //CheckBase(strbase, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtex.Text));
                //txtamount.Text = famount.ToString();
                //txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
                //hid_amount.Value= Convert.ToDecimal(txtamount.Text).ToString("0.00");
                //btnAdd.Enabled = true;
                //btnAdd.ForeColor = System.Drawing.Color.White;
                //btnAdd.Focus();
            }
            UserRights();
        }
        //public double CheckBase(string strbase, double rate, double exrate)
        //{
        //    double amount = 0;
        //    hdnUnit.Value = "1";
        //    if (Session["StrTranTypenew"] == "LT")
        //    {
        //        DataTable dt1 = new DataTable();
        //        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        //        dt1 = custobj.Getinvcountfrmcusid(Convert.ToInt32(hdncustid.Value));
        //        if (ddlBase.Text.ToUpper() == "DOC".ToUpper())
        //        {
        //            amount = rate * exrate * Convert.ToInt32(dt1.Rows[0]["noofuser"]);
        //        }
        //    }
        //    else
        //    {
        //        if (ddlBase.Text.ToUpper() == "DOC".ToUpper())
        //        {
        //            amount = rate * exrate;
        //        }
        //    }
        //    return amount;
        //}

        protected void txtSalesPerson_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                // hdf_salesperson.Value = employee.GetNEmpid(txtSalesPerson.Text).ToString();

                if (hdf_salesperson.Value == "0" || hdf_salesperson.Value == "")
                {
                    ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Invalid Sales Person Name');", true);
                    txtSalesPerson.Text = "";
                    txtSalesPerson.Focus();
                    brr = true;
                    return;
                }
                else
                {
                    txtBrokerage.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        //protected void rdbagent_CheckedChanged(object sender, EventArgs e)
        //{
        //    rdbBussiness.Checked = false;
        //}

        //protected void rdbBussiness_CheckedChanged(object sender, EventArgs e)
        //{
        //    rdbagent.Checked = false;
        //}

        //protected void txtcrm_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtcrm.Text.Trim() != "")
        //    {
        //        string hazard;
        //        txtclear();
        //        int crmid = Convert.ToInt32(txtcrm.Text.Trim());
        //        dsnew = objcrm.GetQuot4CRM(crmid, strtrantype);
        //        dtcrm = dsnew.Tables[0];
        //        por = Convert.ToInt32(dtcrm.Rows[0]["por"].ToString());
        //        txtPOR.Text = port.GetPortname(por);
        //        pol = Convert.ToInt32(dtcrm.Rows[0]["pol"].ToString());
        //        txtPOL.Text = port.GetPortname(por);
        //        pod = Convert.ToInt32(dtcrm.Rows[0]["pod"].ToString());
        //        txtPOD.Text = port.GetPortname(por);
        //        fd = Convert.ToInt32(dtcrm.Rows[0]["fd"].ToString());
        //        txtFD.Text = port.GetPortname(por);

        //        txtSalesPerson.Text = dtcrm.Rows[0]["salespersonid"].ToString();
        //        txtCargo.Text = dtcrm.Rows[0]["commodity"].ToString();
        //        ddlFreight.SelectedValue = dtcrm.Rows[0]["freight"].ToString();
        //        hazard = dtcrm.Rows[0]["hazardous"].ToString();
        //        if (hazard == "Y")
        //        {
        //            chkHazard.Checked = true;
        //        }
        //        else
        //        {
        //            chkHazard.Checked = false;
        //        }
        //        txtCustomer.Text = dtcrm.Rows[0]["customername"].ToString();
        //        hdf_salesperson.Value = dtcrm.Rows[0]["salespersonid"].ToString();
        //        hdf_cargoid.Value = dtcrm.Rows[0]["commodityid"].ToString();
        //        hdf_customerid.Value = dtcrm.Rows[0]["customerid"].ToString();

        //        string pdt = dtcrm.Rows[0]["pdt"].ToString();
        //        ddlShipment.SelectedValue = pdt;


        //        btnclose.Text = "Cancel";
        //        btnSave.Enabled = true;

        //    }
        //}

        public void txtclear()
        {
            txtPOR.Text = "";
            txtPOL.Text = "";
            txtPOD.Text = "";
            txtFD.Text = "";
            ddlShipment.SelectedIndex = -1;


        }

        //protected void lnkcrm_Click(object sender, EventArgs e)
        //{
        //    //if (ddlpdt.Text == "--Product--")
        //    //{
        //    //    ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Select the Product');", true);
        //    //    ddlpdt.Focus();
        //    //    return;
        //    //}

        //    if (txtQuotation.Text.Trim() == "")
        //    {
        //        if (txtcrm.Text.Trim() == "")
        //        {
        //            dtfill = objcrm.GetCRM4grd(strtrantype, Convert.ToInt32(Session["LoginEmpId"]), pdt);
        //            if (dtfill.Rows.Count > 0)
        //            {
        //                grdcrmQuot.DataSource = dtfill;
        //                grdcrmQuot.DataBind();
        //                popupthird.Visible = true;
        //                this.popupcrm.Show();
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('CRM Unavailable');", true);
        //                return;
        //            }
        //        }
        //    }
        //}

        protected void grdcrmQuot_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int crmid;
                int index = grdcrmQuot.SelectedRow.RowIndex;
                string hazard;
                crmid = Convert.ToInt32(grdcrmQuot.SelectedRow.Cells[0].Text);
                txtclear();
                //txtcrm.Text = crmid.ToString();
                txtPOR.Text = grdcrmQuot.SelectedRow.Cells[2].Text;
                txtPOL.Text = grdcrmQuot.SelectedRow.Cells[3].Text;
                txtPOD.Text = grdcrmQuot.SelectedRow.Cells[4].Text;
                txtFD.Text = grdcrmQuot.SelectedRow.Cells[5].Text;
                txtSalesPerson.Text = grdcrmQuot.SelectedRow.Cells[11].Text;
                txtCargo.Text = grdcrmQuot.SelectedRow.Cells[13].Text;
                ddlFreight.SelectedValue = grdcrmQuot.SelectedRow.Cells[14].Text;
                hazard = grdcrmQuot.SelectedRow.Cells[15].Text;
                if (hazard == "Y")
                {
                    chkHazard.Checked = true;
                }
                else
                {
                    chkHazard.Checked = false;
                }
                txtCustomer.Text = grdcrmQuot.SelectedRow.Cells[1].Text;
                hdf_POR.Value = grdcrmQuot.SelectedRow.Cells[6].Text;
                hdf_POL.Value = grdcrmQuot.SelectedRow.Cells[7].Text;
                hdf_POD.Value = grdcrmQuot.SelectedRow.Cells[8].Text;
                hdf_FD.Value = grdcrmQuot.SelectedRow.Cells[9].Text;
                hdf_salesperson.Value = grdcrmQuot.SelectedRow.Cells[10].Text;
                hdf_cargoid.Value = grdcrmQuot.SelectedRow.Cells[12].Text;
                hdf_customerid.Value = grdcrmQuot.SelectedRow.Cells[16].Text;
                ddlShipment.SelectedValue = pdt;
                GetAllMailIds(Convert.ToInt32(hdf_customerid.Value));

                btnSave.Enabled = true;
                btnSave.ForeColor = System.Drawing.Color.White;
                btnclose.Text = "Cancel";
                btnclose.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                //}
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdcrmQuot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdcrmQuot, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        //protected void ddlpdt_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    if (ddlpdt.Text == "--Product--")
        //    {
        //        ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Select the Product');", true);
        //        ddlpdt.Focus();

        //        ddlBase.Items.Clear();
        //        ddlBase.Items.Add("--BASE--");
        //        return;
        //    }

        //    if (ddlpdt.SelectedValue == "Forwarding Exports FCL")
        //    {
        //        strtrantype = "FE";
        //        ddlShipment.Enabled = false;
        //        ddlShipment.SelectedValue = "FCL";
        //        pdt = "FCL";

        //    }
        //    else if (ddlpdt.SelectedValue == "Forwarding Exports LCL")
        //    {
        //        strtrantype = "FE";
        //        ddlShipment.Enabled = false;
        //        ddlShipment.SelectedValue = "LCL";
        //        pdt = "LCL";
        //    }
        //    else if (ddlpdt.SelectedValue == "Forwarding Imports FCL")
        //    {
        //        strtrantype = "FI";
        //        ddlShipment.Enabled = false;
        //        ddlShipment.SelectedValue = "FCL";
        //        pdt = "FCL";
        //    }
        //    else if (ddlpdt.SelectedValue == "Forwarding Imports LCL")
        //    {
        //        strtrantype = "FI";
        //        ddlShipment.Enabled = false;
        //        ddlShipment.SelectedValue = "LCL";
        //        pdt = "LCL";
        //    }
        //    else if (ddlpdt.SelectedValue == "Air Exports")
        //    {
        //        strtrantype = "AE";
        //        pdt = "emp";
        //        ddlShipment.SelectedValue = "FCL";
        //        ddlShipment.Enabled = false;
        //    }
        //    else if (ddlpdt.SelectedValue == "Air Imports")
        //    {
        //        strtrantype = "AI";
        //        ddlShipment.SelectedValue = "FCL";
        //        ddlShipment.Enabled = false;
        //        pdt = "emp";
        //    }
        //    BaseFill();



        //}

        private void GetAllMailIds(int Custid)
        {
            try
            {
                DataTable dt = new DataTable();

                dt = booking.GETMAilis4BookigCRM(Custid);
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



                    DataTable dt1 = dttemp.Clone(); //copy the structure
                    for (int i = 0; i <= dttemp.Rows.Count - 1; i++) //iterate through the rows of the source
                    {
                        DataRow currentRow = dttemp.Rows[i];  //copy the current row
                        foreach (var colValue in currentRow.ItemArray)//move along the columns
                        {
                            if (!string.IsNullOrEmpty(colValue.ToString())) // if there is a value in a column, copy the row and finish
                            {
                                dt1.ImportRow(currentRow);
                                break; //break and get a new row
                            }
                        }
                    }



                    // grdmail.DataSource = dt1;
                    ///  grdmail.DataBind();

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        //protected void btnsend_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sendqry = "";
        //        sendqry = sendqry + (Utility.Fn_GetCompanyAddress());

        //        //sendqry = sendqry + ("<hr>");
        //        //sendqry = sendqry +("<br>");
        //        sendqry = sendqry + ("<tr><td><hr><br></td></tr>");
        //        sendqry = sendqry + ("<tr><td><table width=100%><FONT FACE=tahoma><tr><td align=left style='font-weight: bold;font-size :13pt;'>Dear Sir / Madam ,</td></tr></font></table></td></tr><br>");
        //        sendqry = sendqry + "<tr><td><table width=100%><FONT FACE=tahoma ><tr><td align=left>To</td><td align=right><FONT FACE=Arial> Quotation # : </Font> " + txtQuotation.Text + "</td></tr></br>";
        //        sendqry = sendqry + ("<tr><td align=left>" + txtCustomer.Text + "</td><td align=right><FONT FACE=Arial> Date :</font> " + txtDate.Text + "</td></tr></br>");
        //        //sendqry = sendqry +("<tr><td align=left>Quotation # : " + txtQuotation.Text + " Dt : " + txtDate.Text + "</td></tr>");



        //        DataTable dt = new DataTable();
        //        dt = custobj.RetrieveCustomerDetails(Convert.ToInt32(hdf_customerid.Value));

        //        if (dt.Rows.Count > 0)
        //        {
        //            straddress1 = dt.Rows[0]["address"].ToString();
        //            zipcode = dt.Rows[0]["zip"].ToString();
        //        }


        //        sendqry = sendqry + "<tr><td  align=left>" + straddress1 + "</td><td align=right><FONT FACE=Arial> Valid Till</font> : " + txtValidTill.Text + "</td></tr></br>";
        //        sendqry = sendqry + "<tr><td align=left>" + strcity + " - " + zipcode + "</td></tr></font></table></td></tr>";
        //        sendqry = sendqry + "<tr><td><table width=100% text=black><tr><td align=left> Thank you very much for your inquiry and we are pleased to offer our rates & services as per your requirement from " + txtPOL.Text + " to " + txtPOD.Text + "</td></tr></table></td></tr>";
        //        sendqry = sendqry + "<tr><td><table width=100% text=black><tr><td align=left> Commodity :   " + txtCargo.Text + "</td></tr></table></td></tr>";
        //        sendqry = sendqry + "<tr><td><table BORDER=2 BORDERCOLOR=#336699 CELLPADDING=2 CELLSPACING=0 WIDTH=100% text=black><tr><td align=center>Charge Name</td><td align=center>Curr</td><td align=center>Rate</td><td align=center>Base</td></tr>";

        //        DataTable Dt = new DataTable();
        //        Dt = quotation.ChargeDetails(Convert.ToInt32(txtQuotation.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
        //        for (int i = 0; i <= Dt.Rows.Count - 1; i++)
        //        {

        //            double rate = Convert.ToDouble(dt.Rows[i][2].ToString());
        //            string rate1 = rate.ToString("#,0.00");
        //            sendqry = sendqry + ("<tr><FONT FACE=tahoma><td align=left>" + Dt.Rows[i][0].ToString() + "</td><td align=left>" + Dt.Rows[i][1].ToString() + "</td><td align=right>" + rate1 + "</td><td align=left>" + Dt.Rows[i][3].ToString() + "</td></font></tr>");
        //        }


        //        sendqry = sendqry + ("</table></td></tr><br>");
        //        sendqry = sendqry + ("<tr><td><table width=100% text=black><tr><td align=left>Taxes As Applicable</td></tr></table></td></tr><br>");
        //        sendqry = sendqry + ("<tr><td><table width=100% text=black><tr><td align=left>The  quote (s) are subject to standard terms and conditions, available on request.</td></tr></table></td></tr><br>");

        //        sendqry = sendqry + ("<tr><td><table width=100% text=black><tr><td align=left>I am sure that you will find our offer is attractive and await your confirmation</td></tr></table></td></tr><br>");
        //        sendqry = sendqry + ("<tr><td><table width=100% text=black><tr><td align=left>Best Regards </td></tr></table></td></tr><br>");
        //        sendqry = sendqry + ("<tr><td><table width=100% text=black><tr><td align=left>" + HttpContext.Current.Session["LoginEmpName"].ToString() + " </td></tr></table></td></tr>");
        //        sendqry = sendqry + ("</table></body></html>");

        //        if (grdmail.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < grdmail.Rows.Count - 1; i++)
        //            {
        //                CheckBox chkRow = (grdmail.Rows[i].Cells[2].FindControl("chkselect") as CheckBox);

        //                if (chkRow.Checked == true)
        //                {
        //                    Label lbl = (Label)grdmail.Rows[i].Cells[1].FindControl("lblemailid");
        //                    mailid = lbl.Text + ";" + mailid;
        //                }


        //            }
        //        }

        //        if (mailid == "")
        //        {
        //            ScriptManager.RegisterStartupScript(this, typeof(Button), "UserName", "alertify.alert('Select Any One of the Mail ID');", true);
        //            return;
        //        }


        //        string branchmgrid = quotation.GetBranchmgrmailid(Convert.ToInt32(Session["LoginBranchid"].ToString()));


        //        if (Session["usermailid"].ToString() == "" || Session["mailpwd"].ToString() == "")
        //        {
        //            ScriptManager.RegisterStartupScript(this, typeof(Button), "UserName", "alertify.alert('Update Email ID and Password');", true);
        //            return;
        //        }

        //        //  Utility.SendMail(HttpContext.Current.Session["usermailid"].ToString(), mailid, " Quotation # -" + txtQuotation.Text + " PoL : " + txtPOL.Text + " PoD : " + txtPOD.Text, sendqry , "", HttpContext.Current.Session["mailpwd"].ToString(),);

        //        Utility.SendMail(HttpContext.Current.Session["usermailid"].ToString(), mailid, " Quotation # -" + txtQuotation.Text + " PoL : " + txtPOL.Text + " PoD : " + txtPOD.Text, sb.ToString(), "", HttpContext.Current.Session["mailpwd"].ToString(), "", HttpContext.Current.Session["usermailid"].ToString() + ";" + branchmgrid);
        //        ScriptManager.RegisterStartupScript(this, typeof(Button), "UserName", "alertify.alert('Mail Send.');", true);


        //        GetAllMailIds(Convert.ToInt32(hdf_customerid.Value));


        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}

        public void SendDeleiveryStatus()
        {
            //string sendqry = "";
            DataTable Dt = new DataTable();
            //DataAccess.ForwardingImports.BLDetails da_obj_blobj = new DataAccess.ForwardingImports.BLDetails();
            //DataAccess.Marketing.Quotation quotobj = new DataAccess.Marketing.Quotation();
            DataTable dtTab = new DataTable();
            string zipcode = "";
            // string str_mailserver = Session["MailServer"].ToString();
            //string str_usermailid = Session["usermailid"].ToString();
            // string str_mailuser = Session["MailUser"].ToString();
            //string str_mailpwd = Session["mailpwd"].ToString();
            dtQuot = Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (dtQuot.Rows.Count > 0)
            {
                if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FE")
                {
                    custtype = "S";
                }
                else
                {
                    custtype = "S";
                }
                //hdf_customerid
                strcity = custobj.GetCustlocation(Convert.ToInt32(hdf_customerid.Value));
                if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "AE")
                {
                    custtype = "Shipper";
                }
                else
                {
                    custtype = "Consignee";
                }

                dtTab = custobj.RetrieveCustomerDetails(Convert.ToInt32(hdf_customerid.Value));
                if (dtTab.Rows.Count > 0)
                {
                    straddress = dtTab.Rows[0]["address"].ToString();
                    zipcode = dtTab.Rows[0]["zip"].ToString();
                }

                sendqry = sendqry + "<body text=darkblue><table width=100%><FONT FACE=tahoma ><tr><td align=left>Quotation # : " + Convert.ToInt32(txtQuotation.Text) + "  has created in Ocean Imports. Please find below details</td></tr></table><br>";
                sendqry = sendqry + "<table><tr><td align=left>" + txtCustomer.Text + "   </td><td align=left>Date: " + Convert.ToDateTime(txtDate.Text) + " </td></tr><br>";
                sendqry = sendqry + "<tr><td align=left>PoL : " + straddress + "   " + "   </td><td align=left>Valid Till: " + Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text)) + "</td></tr><br>";
                sendqry = sendqry + "<tr><td align=left colspan=4>Agent : " + strcity + " - " + zipcode + "   </td></tr><br>";
                // 
                sendqry = sendqry + "<tr><td align=left colspan=4>Agent : Thank you very much for your inquiry and we are pleased to offer our rates + services as per your requirement from " + txtPOL.Text + " to " + txtPOD.Text + "  </td></tr><br>";
                sendqry = sendqry + "<tr><td align=left colspan=4>Commodity : " + txtCargo.Text + "</td></tr></table>";

                sendqry = sendqry + "<table BORDER=2 BORDERCOLOR=#336699 CELLPADDING=2 CELLSPACING=0 WIDTH=100% text=black><tr><td align=center>Container # </td><td align=center>Sizetype</td><td align=center>Seal #</td><td align=center>Pkgs</td><td align=center>Weight</td></tr><br>";
                sendqry = sendqry + "<table BORDER=2 BORDERCOLOR=#336699 CELLPADDING=2 CELLSPACING=0 WIDTH=100% text=black><tr><td align=center>Charge Name</td><td align=center>Curr</td><td align=center>Rate</td><td align=center>Base</td></tr>";
                Dt = quotobj.ChargeDetails(Convert.ToInt32(txtQuotation.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                int i;
                if (Dt.Rows.Count > 0)
                {
                    for (i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        string rat;
                        double rate;
                        rate = Convert.ToDouble(Dt.Rows[i][2].ToString());
                        rat = rate.ToString("#0.00");
                        sendqry = sendqry + "<tr><td align=left>" + Dt.Rows[i][0].ToString() + "</td><td align=left>" + Dt.Rows[i][1].ToString() + "</td><td align=left>" + Dt.Rows[i][2].ToString() + "</td><td align=left>" + rat + "</td><td align=left>" + Dt.Rows[i][3].ToString() + "</td></tr>";
                    }
                }
                sendqry = sendqry + "</table>";

                sendqry = sendqry + "<table width=100% text=black><tr><td align=left>Taxes As Applicable </td></tr></table><br>";
                sendqry = sendqry + "<table width=100% text=black><tr><td align=left>I am sure that you will find our offer is attractive and await your Confirmation </td></tr></table><br>";
                sendqry = sendqry + "<table width=100% text=black><tr><td align=left>Best Regards </td></tr></table><br><br>";
                sendqry = sendqry + "<table width=100% text=black><tr><td align=left>" + txtSalesPerson.Text + " </td></tr></table></body></html>";


            }


        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        private string SendPDFEmail(StringBuilder sb)
        {

            StringReader sr = new StringReader(sb.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                if (File.Exists(Server.MapPath("Quotation.pdf")))
                {
                    File.Delete(Server.MapPath("Quotation.pdf"));
                }
                string sFile = Server.MapPath("Quotation.pdf"); //Path
                FileStream fs = File.Create(sFile);
                fs.Close();
                File.WriteAllBytes(Server.MapPath("Quotation.pdf"), bytes);
                string strattach = Server.MapPath("Quotation.pdf");
                return strattach;
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_product.SelectedItem.Text == "")
                {
                    Session["StrTranType"] = "";
                }
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                string version = "0";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                if (ddl_version.Text == "")
                {
                    version = "0";
                }
                else
                {
                    version = ddl_version.Text;
                }
                if (NewQuoteRpt.Value == "Y")
                {
                    DataTable dtform = quotation.Checkquotform(Convert.ToInt32(txtQuotation.Text), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());

                    if (txtQuotation.Text.Trim() != "")
                    {
                        if (dtform.Rows.Count > 0)
                        {
                            str_Script = "window.open('../Reportasp/Combinedquotrpt.aspx?Quoteno=" + txtQuotation.Text + "&Bid=" + Session["LoginBranchid"] + "&Cid=" + Session["LoginDivisionid"] + "&TranType=" + Session["StrTranType"] + "&version=" + version + "','','');";
                            ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quote", str_Script, true);

                        }
                        else
                        {
                            str_Script = "window.open('../Reportasp/Combinedquotrpt.aspx?Quoteno=" + txtQuotation.Text + "&Bid=" + Session["LoginBranchid"] + "&Cid=" + Session["LoginDivisionid"] + "&TranType=" + Session["StrTranType"] + "&version=" + version + "','','');";
                            ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quote", str_Script, true);
                            //str_Script = "window.open('../Reportasp/QuoteRpt.aspx?Quoteno=" + txtQuotation.Text + "&Bid=" + Session["LoginBranchid"] + "&Cid=" + Session["LoginDivisionid"] + "&TranType=" + Session["StrTranType"] + "','','');";
                            //ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quote", str_Script, true);
                        }
                    }



                    switch (Session["StrTranType"].ToString())
                    {
                        case "FE":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 181, 3, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "FE_QuotRegView");
                            break;
                        case "FI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 180, 3, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "FI_QuotRegView");
                            break;
                        case "AE":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 217, 3, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "AE_QuotRegView");
                            break;
                        case "AI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 215, 3, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "AI_QuotRegView");
                            break;
                    }
                }

                else
                {
                    if (txtQuotation.Text.Trim().Length > 0)
                    {
                        str_RptName = "Quotation.rpt";
                        Session["str_sfs"] = "{QuotationHead.bid}=" + Session["LoginBranchid"].ToString() + " and {QuotationHead.quotno}=" + txtQuotation.Text;
                        str_sf = "{QuotationHead.bid}=" + Session["LoginBranchid"].ToString() + " and {QuotationHead.quotno}=" + txtQuotation.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quotation", str_Script, true);
                        //str_Script = "window.open('../Reportasp/quotationrpt.aspx?Quotno=" + txtQuotation.Text + "&" + this.Page.ClientQueryString + "','','');";
                        //ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quotation", str_Script, true); 
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1, 4, int.Parse(Session["LoginBranchid"].ToString()), txtQuotation.Text + " FE_QuotRegView");

                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 181, 3, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "FE_QuotRegView");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 180, 3, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "FI_QuotRegView");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 217, 3, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "AE_QuotRegView");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 215, 3, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "AI_QuotRegView");
                                break;
                        }
                    }
                    else
                    {
                        str_RptName = "QuotationReg.rpt";
                        Session["str_sfs"] = "{QuotationHead.bid}=" + Session["LoginBranchid"].ToString();
                        str_sf = "{QuotationHead.bid}=" + Session["LoginBranchid"].ToString();
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1, 4, int.Parse(Session["LoginBranchid"].ToString()), " FE_QuotRegView");
                        ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quotation", str_Script, true);
                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 181, 3, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "OE_QuotView");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 180, 3, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "OI_QuotView");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 217, 3, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "AE_QuotView");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 215, 3, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + "AI_QuotView");
                                break;
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

        protected void lnk_back_Click(object sender, EventArgs e)
        {

            if (Session["blno"] != null)
            {
                Session["Quo"] = null;
                Response.Redirect("../ForwardExports/BL Print.aspx");
                return;
            }
            else
            {
                Session["Quo"] = null;
                Response.Redirect("../ForwardExports/BL Print.aspx");
            }
        }

        protected void grdQuotation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdQuotation.PageIndex = e.NewPageIndex;
            LoadQuoatation();
        }

        protected void txtqty_TextChanged(object sender, EventArgs e)
        {
            if (txtqty.Text != "")
            {
                hid_expqty.Value = txtqty.Text;
                // ddlBase_SelectedIndexChanged(sender, e);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Enter Quantity');", true);
                txtqty.Focus();
                return;
            }
        }

        protected void txtRate_TextChanged(object sender, EventArgs e)
        {
            if (txtRate.Text != "")
            {
                hid_rate.Value = txtRate.Text;
                // ddlBase_SelectedIndexChanged(sender, e);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Enter Rate');", true);
                txtRate.Focus();
                return;
            }
        }

        protected void grdBuyingDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBuyingDetails.PageIndex = e.NewPageIndex;
            grdBuyingDetails.DataSource = (DataTable)ViewState["Buying"];
            grdBuyingDetails.DataBind();
            grdBuyingDetails.Visible = true;
            this.popupBuying.Show();
        }

        protected void grdQuotaionDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdQuotaionDetails.PageIndex = e.NewPageIndex;
            grdQuotaionDetails.DataSource = (DataTable)ViewState["inquiry"];
            grdQuotaionDetails.DataBind();
            this.popupQuot.Show();
            pnlJobAE.Visible = true;
            grdQuotaionDetails.Visible = true;
        }

        protected void grdcrmQuot_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdcrmQuot.PageIndex = e.NewPageIndex;
                LoadQuoatation();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            if (ddl_product.SelectedItem.Text == "")
            {
                Session["StrTranType"] = "";
            }
            CollectData();
            OldQuotNo = Convert.ToInt16(hdf_OldQuotNo.Value);
            if (strtrantype == "FE")
            {
                if (ddlShipment.Text == "FCL")
                {
                    if (grdBuying.Rows.Count > 0)
                    {
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Buy Rate Should be Mandatory');", true);
                        return;
                    }
                }
                //else
                //{
                //    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Shipment Should be Mandatory');", true);
                //    return;   
                //}
            }
            if (Gross_country.Checked == true)
            {
                check = "Y";
            }
            else
            {
                check = "N";
            }
            quotid = quotation.InsertQuotationDetailsnew(Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text)), Session["StrTranType"].ToString(), Convert.ToInt32(hdf_customerid.Value), Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value), Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.SelectedItem.Text, ddlFreight.SelectedItem.Text, Convert.ToInt32(hdf_cargoid.Value), txtDescription.Text, Convert.ToInt32(hdf_salesperson.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hdf_Hazard.Value), txtRemarks.Text.Trim(), "0", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtBuying.Text.Trim()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), hdf_Bussiness.Value, check, txtterms.Text);
            quotation.UpdQuotationValidTill(OldQuotNo, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));

            txtQuotation.Text = Convert.ToString(quotid);
            int j = 0;
            for (j = 0; j <= grdQuotation.Rows.Count - 1; j++)
            {
                intchargeid = charges.GetChargeid(grdQuotation.Rows[j].Cells[0].Text);
                blnexists = quotation.CheckChargeExist(intchargeid, quotid, ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                if (blnexists == false)
                {
                    quotation.InsertChargeDetails(quotid, grdQuotation.Rows[j].Cells[0].Text, grdQuotation.Rows[j].Cells[1].Text, Convert.ToDouble(grdQuotation.Rows[j].Cells[2].Text), grdQuotation.Rows[j].Cells[3].Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    clearCharges();
                    txtCharges.Focus();
                    blnexists = true;
                }
            }
            dtQuot = quotation.ChargeDetails(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
            grdQuotation.DataSource = dtQuot;
            grdQuotation.DataBind();
            switch (Session["StrTranType"].ToString())
            {
                case "FE":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 181, 1, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + " / FE_Quot");
                    break;
                case "FI":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 180, 1, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + " / FI_Quot");
                    break;
                case "AE":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 217, 1, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + " / AE_Quot");
                    break;
                case "AI":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 215, 1, Convert.ToInt32(Session["LoginBranchid"]), txtQuotation.Text + " / AI_Quot");
                    break;
            }
            ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Inquiry # " + quotid + "');", true);

            btnAdd.Enabled = true;
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnSave.Text = "Update";
            btnSave.ToolTip = "Update";
            btn_save.Attributes["class"] = "btn ico-update";
            grdQuotation.Enabled = true;
            btnSave.Enabled = true;
            txtCharges.Focus();
            btnclose.Enabled = true;
            btnclose.ForeColor = System.Drawing.Color.White;
            btnView.Enabled = true;
            btnView.ForeColor = System.Drawing.Color.White;
            btnApp.Enabled = true;
            btnApp.ForeColor = System.Drawing.Color.White;
            btnAdd.Enabled = true;
            btnAdd.ForeColor = System.Drawing.Color.White;
            txtUnable();

            txtCharges.Focus();
            btnSave.Enabled = false;
            btnSave.ForeColor = System.Drawing.Color.Gray;
            btnApp.Enabled = false;
            btnApp.ForeColor = System.Drawing.Color.Gray;
            btnclose.Text = "Cancel";
            btnclose.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
            UserRights();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            return;
        }

        protected void ddl_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            baseFil();
            ddlShipment.Items.Clear();
            ddlFreight.Items.Clear();
            fillddl();
            fillDetails();
            DataTable dtterms = new DataTable();

            dtterms = quotation.Getterms(ddlShipment.Text, ddl_product.SelectedValue);
            if (dtterms.Rows.Count > 0)
            {
                txtterms.Text = dtterms.Rows[0]["terms"].ToString();
                txt_terms.Text = dtterms.Rows[0]["terms"].ToString();
            }
            //string trantype = dtQuot.Rows[0]["strtrantype"].ToString();
            if ((ddl_product.Text == "Air Imports") || (ddl_product.Text == "Air Exports"))
            {
                Label43.Text = "Chargeable Weight (KGS)";
                DataTable Dt = new DataTable();
                Dt.Columns.Add("checksbno");
                Dt.Columns.Add("conttype");
                Dt.Columns.Add("txt_Sizecount");
                Dt.Rows.Add();
                Dt.Rows[0]["conttype"] = "KGS";
                Dt.Rows.Add();
                Dt.Rows[1]["conttype"] = "PER TRUCK";
                Dt.Rows.Add();
                Dt.Rows[2]["conttype"] = "COTTON/PALLET";
                Dt.Rows.Add();
                Dt.Rows[3]["conttype"] = "AT ACTUALS";
                grd_Sizetype.DataSource = Dt;
                grd_Sizetype.DataBind();

            }
            else if (ddl_product.Text == "Ocean Imports")
            {

                ddlShipment.Text = "LCL";

                DataTable Dt = new DataTable();
                Dt.Columns.Add("checksbno");
                Dt.Columns.Add("conttype");
                Dt.Columns.Add("txt_Sizecount");
                Dt.Rows.Add();
                Dt.Rows[0]["conttype"] = "CBM";
                Dt.Rows.Add();
                Dt.Rows[1]["conttype"] = "MT";
                Dt.Rows.Add();
                Dt.Rows[2]["conttype"] = "AT ACTUALS";
                Dt.Rows.Add();
                Dt.Rows[3]["conttype"] = "W/M";
                grd_Sizetype.DataSource = Dt;
                grd_Sizetype.DataBind();
            }


            else
            {

                DataTable Dt = new DataTable();
                //chkContainerList.Items.Clear();
                DataSet ds1 = new DataSet();
                DataTable dtpkg1 = new DataTable();
                ds1 = container.GetContainersize();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    dtpkg1 = ds1.Tables[0];
                    Dt.Columns.Add("checksbno");
                    Dt.Columns.Add("conttype");
                    Dt.Columns.Add("txt_Sizecount");

                    if (dtpkg1.Rows.Count > 0)
                    {
                        //Dt.Rows.Add();
                        //Dt.Rows[0]["conttype"] = "CBM";
                        for (int i = 0; i <= dtpkg1.Rows.Count - 1; i++)
                        {
                            Dt.Rows.Add();
                            //Dt.Rows[0]["conttype"] = "CBM";
                            Dt.Rows[i]["conttype"] = dtpkg1.Rows[i]["conttype"].ToString();
                        }

                        Dt.Rows.Add();
                        Dt.Rows[dtpkg1.Rows.Count]["conttype"] = "CBM";
                        Dt.Rows.Add();
                        Dt.Rows[dtpkg1.Rows.Count + 1]["conttype"] = "MT";
                        //Dt.Rows.Add();
                        //Dt.Rows[dtpkg1.Rows.Count + 2]["conttype"] = "AT ACTUALS";
                        grd_Sizetype.DataSource = Dt;
                        grd_Sizetype.DataBind();
                    }
                    // chkContainerList.DataSource = dtpkg1;
                    // chkContainerList.DataTextField = "conttype";
                    // chkContainerList.DataValueField = "conttype";
                    // chkContainerList.DataBind();
                    //chkContainerList.Items.Insert(1, "BL");
                    //chkContainerList.Items.Insert(2, "CBM");
                    //chkContainerList.Items.Insert(3, "MT");
                }
                else
                {
                    grd_Sizetype.DataSource = Utility.Fn_GetEmptyDataTable();
                    grd_Sizetype.DataBind();
                }
            }
            //string type1;
            //string type;
            //DataTable dtnew = new DataTable();
            //dtnew = quotation.CheckMax2(quotid);
            //for (int n = 0; n <= dtnew.Rows.Count - 1; n++)
            //{
            //    type1 = dtnew.Rows[n]["base"].ToString();

            //    for (int i = 0; i <= grd_Sizetype.Rows.Count - 1; i++)
            //    {
            //        type = grd_Sizetype.Rows[i].Cells[1].Text;
            //        if (type1 == type)
            //        {
            //            //for (int r = 0; r <= dtnew.Rows.Count - 1; r++)
            //            //{
            //            //string sitype = dtnew.Rows[r]["base"].ToString();
            //            //if (sitype == type)
            //            //{


            //            //string qty = dtnew.Rows[n]["qty"].ToString(); 

            //            CheckBox cbox = (CheckBox)grd_Sizetype.Rows[i].FindControl("checksbno");
            //            cbox.Checked = true;
            //            TextBox txt = (TextBox)grd_Sizetype.Rows[i].FindControl("txt_Sizecount");
            //            if (grd_Sizetype.Rows[i].Cells[1].Text == "CBM" || grd_Sizetype.Rows[i].Cells[1].Text == "KGS")
            //            {

            //                if (dtnew.Rows[n]["qty"].ToString() != "")
            //                {
            //                    txt.Text = Convert.ToDecimal(dtnew.Rows[n]["qty"]).ToString();
            //                }
            //            }
            //            else
            //            {
            //                if (dtnew.Rows[n]["qty"].ToString() != "")
            //                {
            //                    txt.Text = Convert.ToInt32(dtnew.Rows[n]["qty"]).ToString();
            //                }

            //            }

            //            if (txt.Text == "0" || txt.Text == "")
            //            {
            //                txt.Text = "";
            //            }
            //            //  txt_noofcont.Text = type1 + " X " + txt.Text;
            //        }
            //    }
            //}
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
            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"] == "FE")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 14, "Quot", txtQuotation.Text, txtQuotation.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"] == "FI")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 15, "Quot", txtQuotation.Text, txtQuotation.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"] == "AE")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 16, "Quot", txtQuotation.Text, txtQuotation.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"] == "AI")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 17, "Quot", txtQuotation.Text, txtQuotation.Text, Session["StrTranType"].ToString());
                }
                else
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 17, "Quot", txtQuotation.Text, txtQuotation.Text, "");
                }
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 17, "Quot", txtQuotation.Text, txtQuotation.Text, "");
            }


            if (txtQuotation.Text != "")
            {
                JobInput.Text = txtQuotation.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        /* protected void Bind_outstandingdetails()
         {
             DataTable dt = new DataTable();
             DataAccess.Outstanding outsobj = new DataAccess.Outstanding();

             int divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
             int branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
             int subgrpid = 40;
             int time = 0;            
             int Credit_Amount = 0, outstdamt = 0;

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

             // dt = da_obj_misgrd.Getnewoutstanding4MISHomeOutStndTotal(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), subgrpid);
             // dt = da_obj_misgrd.Getnewoutstanding4MISHomeOutStndTotal(logempid, branchid, divisionid, subgrpid);

             if (dt.Rows.Count > 0)
             {
                 DataTable DT_branch = new DataTable();
                 DataView data_view = dt.DefaultView;

                 //string str_SelFormula = "trantype ='" + ddl_product.Text + "' and bid=" + branchid;
                 //data_view.RowFilter = str_SelFormula;               
                 data_view.RowFilter = "bid = " + branchid + "and " + "trantype = '" + ddl_product.Text + "' " + " and " + " custid = " + hdf_customerid.Value + " ";
                 DT_branch = data_view.ToTable();

                 if (DT_branch.Rows.Count > 0)
                 {
                     DT_bind.Columns.Add("Credit/Outstanding", typeof(string));
                     DT_bind.Columns.Add("Details", typeof(string));
                     DataRow Drow = DT_bind.NewRow();

                     var sum_Outstanding = DT_branch.Compute("sum(amount)", "");
                     var sum_Over = DT_branch.Compute("sum(overdue)", "");
                     outstdamt = Convert.ToInt32(DT_branch.Compute("sum(amount)", ""));
                     sum_Outstanding = string.Format("{0:#,##0.00}", sum_Outstanding);
                     sum_Over = string.Format("{0:#,##0.00}", sum_Over);

                     Drow = DT_bind.NewRow();
                     Drow[0] = "Credit Days";
                     Drow[1] = DT_branch.Rows[0]["appdays"];
                     DT_bind.Rows.Add(Drow);

                     Drow = DT_bind.NewRow();
                     Drow[0] = "Credit Amount";
                     Drow[1] = DT_branch.Rows[0]["appamt"];
                     Credit_Amount = Convert.ToInt32(DT_branch.Rows[0]["appamt"]);
                     DT_bind.Rows.Add(Drow);

                     Drow = DT_bind.NewRow();
                     Drow[0] = "Over Due Days";
                     Drow[1] = DT_branch.Rows[0]["overduedays"];
                     DT_bind.Rows.Add(Drow);

                     Drow = DT_bind.NewRow();
                     Drow[0] = "Over Due Amount";
                     Drow[1] = sum_Over;
                     DT_bind.Rows.Add(Drow);

                     Drow = DT_bind.NewRow();
                     Drow[0] = "Total OS Amt";
                     Drow[1] = sum_Outstanding;
                     DT_bind.Rows.Add(Drow);

                     test.DataSource = DT_bind;
                     test.DataBind();
                     //ViewState["GridSalesOutPerson"] = DT_bind;
                     if (outstdamt > Credit_Amount)
                     {
                         ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Quotation", "alertify.alert('You have fully utilized Credit Exemption Limit for this Month');", true);
                     }
                 }
                 else
                 {
                     DT_bind.Columns.Add("Credit/Outstanding", typeof(string));
                     DT_bind.Columns.Add("Details", typeof(string));
                     DT_bind.Rows.Add("Credit Days");
                     DT_bind.Rows.Add("Credit Amount");
                     DT_bind.Rows.Add("Over Due Days");
                     DT_bind.Rows.Add("Over Due Amount");
                     DT_bind.Rows.Add("Total OS Amt");
                     test.DataSource = DT_bind;
                     test.DataBind();
                 }
             }
         } 
         */

        protected void Bind_outstandingdetails()
        {
            DataTable dt = new DataTable();
          

            int divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int subgrpid = 40;
            int time = 0;
            int Credit_Amount = 0, outstdamt = 0;

            time = Logobj.GetDate().Hour;


            DataTable DtCE = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dtinv = new DataTable();

            int intcustidn = 0;
            string salesperson = "";

            intcustidn = Convert.ToInt32(hdf_customerid.Value);

            double totalamt = 0;
            int overduedays = 0, extradays = 0;
            double overdueamount = 0;
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
                    overduedays = extradays - Convert.ToInt32(dt2.Rows[0]["creditdays"]);

                    DT_bind.Columns.Add("Credit/Outstanding", typeof(string));
                    DT_bind.Columns.Add("Details", typeof(string));
                    DataRow Drow = DT_bind.NewRow();



                    var sum_Outstanding = dtinv.Compute("sum(osamount)", "");
                    var sum_Over = overdueamount.ToString("#,0.00");
                    //  outstdamt = Convert.ToInt32(totalamt.ToString("#,0.00"));   // osamount creditdays  creditamt
                    var outstdamnt = totalamt.ToString("#,0.00");
                    sum_Outstanding = string.Format("{0:#,##0.00}", sum_Outstanding);
                    sum_Over = string.Format("{0:#,##0.00}", sum_Over);
                    //  outstdamnt = string.Format("{0:#,##0.00}", outstdamnt);


                    Drow = DT_bind.NewRow();
                    Drow[0] = "Credit Days";
                    Drow[1] = dt2.Rows[0]["creditdays"];
                    DT_bind.Rows.Add(Drow);

                    Drow = DT_bind.NewRow();
                    Drow[0] = "Credit Amount";
                    Drow[1] = Convert.ToDouble(dt2.Rows[0]["creditamt"].ToString()).ToString("#,0.00");
                    Credit_Amount = Convert.ToInt32(dt2.Rows[0]["creditamt"]);
                    DT_bind.Rows.Add(Drow);

                    Drow = DT_bind.NewRow();
                    Drow[0] = "Over Due Days";
                    Drow[1] = extradays;
                    DT_bind.Rows.Add(Drow);

                    Drow = DT_bind.NewRow();
                    Drow[0] = "Over Due Amount";
                    Drow[1] = sum_Over;
                    DT_bind.Rows.Add(Drow);

                    Drow = DT_bind.NewRow();
                    Drow[0] = "Total OS Amt";
                    Drow[1] = sum_Outstanding;
                    DT_bind.Rows.Add(Drow);

                    test.DataSource = DT_bind;
                    test.DataBind();
                    //ViewState["GridSalesOutPerson"] = DT_bind;
                    if (outstdamt > Credit_Amount)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Quotation", "alertify.alert('You have fully utilized Credit Exemption Limit for this Month');", true);
                    }
                }
                else
                {
                    DT_bind.Columns.Add("Credit/Outstanding", typeof(string));
                    DT_bind.Columns.Add("Details", typeof(string));
                    DT_bind.Rows.Add("Credit Days");
                    DT_bind.Rows.Add("Credit Amount");
                    DT_bind.Rows.Add("Over Due Days");
                    DT_bind.Rows.Add("Over Due Amount");
                    DT_bind.Rows.Add("Total OS Amt");
                    test.DataSource = DT_bind;
                    test.DataBind();
                }
            }
            else
            {
                dt2 = Crexobj.GetCustCreditAmtcust(intcustidn, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (dt2.Rows.Count > 0)
                {
                    // overduedays = extradays - Convert.ToInt32(dt2.Rows[0]["creditdays"]);


                    test.DataSource = Utility.Fn_GetEmptyDataTable();
                    test.DataBind();

                    DT_bind.Columns.Add("Credit/Outstanding", typeof(string));
                    DT_bind.Columns.Add("Details", typeof(string));
                    DataRow Drow = DT_bind.NewRow();


                    Drow = DT_bind.NewRow();
                    Drow[0] = "Credit Days";
                    Drow[1] = dt2.Rows[0]["creditdays"];
                    DT_bind.Rows.Add(Drow);

                    Drow = DT_bind.NewRow();
                    Drow[0] = "Credit Amount";
                    Drow[1] = Convert.ToDouble(dt2.Rows[0]["creditamt"].ToString()).ToString("#,0.00"); //dt2.Rows[0]["creditamt"];
                    Credit_Amount = Convert.ToInt32(dt2.Rows[0]["creditamt"]);
                    DT_bind.Rows.Add(Drow);

                    DT_bind.Rows.Add("Over Due Days");
                    DT_bind.Rows.Add("Over Due Amount");
                    DT_bind.Rows.Add("Total OS Amt");
                    test.DataSource = DT_bind;
                    test.DataBind();

                }
                else
                {

                    DT_bind.Columns.Add("Credit/Outstanding", typeof(string));
                    DT_bind.Columns.Add("Details", typeof(string));
                    DT_bind.Rows.Add("Credit Days");
                    DT_bind.Rows.Add("Credit Amount");
                    DT_bind.Rows.Add("Over Due Days");
                    DT_bind.Rows.Add("Over Due Amount");
                    DT_bind.Rows.Add("Total OS Amt");
                    test.DataSource = DT_bind;
                    test.DataBind();
                }


            }
        }

        protected void Bind_outstandingdetailsresue()
        {
            DataTable dt = new DataTable();
            //DataAccess.CreditException Crexobj = new DataAccess.CreditException();
            //DataAccess.Outstanding outsobj = new DataAccess.Outstanding();

            int divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int subgrpid = 40;
            int time = 0;
            int Credit_Amount = 0, outstdamt = 0;

            time = Logobj.GetDate().Hour;


            DataTable DtCE = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dtinv = new DataTable();

            int intcustidn = 0;
            string salesperson = "";

            intcustidn = Convert.ToInt32(hdf_customerid.Value);

            double totalamt = 0;
            int overduedays = 0, extradays = 0;
            double overdueamount = 0;
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
                    overduedays = extradays - Convert.ToInt32(dt2.Rows[0]["creditdays"]);

                    DT_bind.Columns.Add("Credit/Outstanding", typeof(string));
                    DT_bind.Columns.Add("Details", typeof(string));
                    DataRow Drow = DT_bind.NewRow();



                    var sum_Outstanding = dtinv.Compute("sum(osamount)", "");
                    var sum_Over = overdueamount.ToString("#,0.00");
                    //  outstdamt = Convert.ToInt32(totalamt.ToString("#,0.00"));   // osamount creditdays  creditamt
                    var outstdamnt = totalamt.ToString("#,0.00");
                    sum_Outstanding = string.Format("{0:#,##0.00}", sum_Outstanding);
                    sum_Over = string.Format("{0:#,##0.00}", sum_Over);
                    //  outstdamnt = string.Format("{0:#,##0.00}", outstdamnt);


                    Drow = DT_bind.NewRow();
                    Drow[0] = "Credit Days";
                    Drow[1] = dt2.Rows[0]["creditdays"];
                    DT_bind.Rows.Add(Drow);

                    Drow = DT_bind.NewRow();
                    Drow[0] = "Credit Amount";
                    Drow[1] = Convert.ToDouble(dt2.Rows[0]["creditamt"].ToString()).ToString("#,0.00");
                    Credit_Amount = Convert.ToInt32(dt2.Rows[0]["creditamt"]);
                    DT_bind.Rows.Add(Drow);

                    Drow = DT_bind.NewRow();
                    Drow[0] = "Over Due Days";
                    Drow[1] = extradays;
                    DT_bind.Rows.Add(Drow);

                    Drow = DT_bind.NewRow();
                    Drow[0] = "Over Due Amount";
                    Drow[1] = sum_Over;
                    DT_bind.Rows.Add(Drow);

                    Drow = DT_bind.NewRow();
                    Drow[0] = "Total OS Amt";
                    Drow[1] = sum_Outstanding;
                    DT_bind.Rows.Add(Drow);

                    test.DataSource = DT_bind;
                    test.DataBind();
                    //ViewState["GridSalesOutPerson"] = DT_bind;
                    if (outstdamt > Credit_Amount)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Quotation", "alertify.alert('You have fully utilized Credit Exemption Limit for this Month');", true);
                    }
                }
                //else
                //{
                //    DT_bind.Columns.Add("Credit/Outstanding", typeof(string));
                //    DT_bind.Columns.Add("Details", typeof(string));
                //    DT_bind.Rows.Add("Credit Days");
                //    DT_bind.Rows.Add("Credit Amount");
                //    DT_bind.Rows.Add("Over Due Days");
                //    DT_bind.Rows.Add("Over Due Amount");
                //    DT_bind.Rows.Add("Total OS Amt");
                //    test.DataSource = DT_bind;
                //    test.DataBind();
                //}
            }
            else
            {
                dt2 = Crexobj.GetCustCreditAmtcust(intcustidn, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (dt2.Rows.Count > 0)
                {
                    // overduedays = extradays - Convert.ToInt32(dt2.Rows[0]["creditdays"]);


                    test.DataSource = Utility.Fn_GetEmptyDataTable();
                    test.DataBind();

                    DT_bind.Columns.Add("Credit/Outstanding", typeof(string));
                    DT_bind.Columns.Add("Details", typeof(string));
                    DataRow Drow = DT_bind.NewRow();


                    Drow = DT_bind.NewRow();
                    Drow[0] = "Credit Days";
                    Drow[1] = dt2.Rows[0]["creditdays"];
                    DT_bind.Rows.Add(Drow);

                    Drow = DT_bind.NewRow();
                    Drow[0] = "Credit Amount";
                    Drow[1] = Convert.ToDouble(dt2.Rows[0]["creditamt"].ToString()).ToString("#,0.00"); //dt2.Rows[0]["creditamt"];
                    Credit_Amount = Convert.ToInt32(dt2.Rows[0]["creditamt"]);
                    DT_bind.Rows.Add(Drow);

                    DT_bind.Rows.Add("Over Due Days");
                    DT_bind.Rows.Add("Over Due Amount");
                    DT_bind.Rows.Add("Total OS Amt");
                    test.DataSource = DT_bind;
                    test.DataBind();

                }
                //else
                //{

                //    DT_bind.Columns.Add("Credit/Outstanding", typeof(string));
                //    DT_bind.Columns.Add("Details", typeof(string));
                //    DT_bind.Rows.Add("Credit Days");
                //    DT_bind.Rows.Add("Credit Amount");
                //    DT_bind.Rows.Add("Over Due Days");
                //    DT_bind.Rows.Add("Over Due Amount");
                //    DT_bind.Rows.Add("Total OS Amt");
                //    test.DataSource = DT_bind;
                //    test.DataBind();
                //}


            }
        }

        protected void Btn_reuse_Click(object sender, EventArgs e)
        {
            Panel4.Visible = false;
            grdQuotaionDetails.Visible = false;
            Panel6.Visible = true;
            GrdReuse.Visible = true;
            hidreuse.Value = "1";

            Session["OldQuotation"] = txtQuotation.Text;

            try
            {
                if (Session["OldQuotation"] != "")
                {
                    if (ddl_product.SelectedItem.Text == "")
                    {
                        Session["StrTranType"] = "";
                    }
                    LoadQuoatationreuse();
                    txtQuotation.Text = "";
                    txtBuying.Text = "";
                    hid_rateid.Value = "";
                    /* txtBuying.Text = "";
                     txtBuyingDetails.Text = "";
                     grdBuying.DataSource = Utility.Fn_GetEmptyDataTable();
                     grdBuying.DataBind();
                     txtQuotation.Focus();*/
                    btnSave.ToolTip = "Save";
                    btn_save.Attributes["class"] = "btn ico-save";
                    btnclose.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Enter the Inquiry # ');", true);
                    return;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void LoadQuoatationreuse()
        {
            strtrantype = Session["StrTranType"].ToString();
            try
            {
                Panel4.Visible = false;
                grdQuotaionDetails.Visible = false;
                GrdReuse.Visible = true;
                if (lblHeader.Text == "Inquiry")
                {
                    dtQuot = quotation.ApprovalPendingDetails1(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                }
                else
                {
                    if (txtCustomer.Text != "" && hdf_customerid.Value != "")
                    {
                        dtQuot = quotation.InquiryDetailsCustqnew(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hdf_customerid.Value.ToString()));
                    }
                    else
                    {
                        dtQuot = quotation.InquiryDetailsnew(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    }
                }

                getvaluereuse();
                //if (dtQuot.Rows.Count > 0)
                //{
                //    grdBuyingDetails.Visible = false;
                //    GrdReuse.DataSource = dtQuot;
                //    GrdReuse.DataBind();
                //    ViewState["quotationreuse"] = dtQuot;
                //    pnlJobAE.Visible = true;
                //    this.popupQuot.Show();

                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('No Quotation available to modify');", true);
                //}


                btnSave.Enabled = true;
                btnSave.ForeColor = System.Drawing.Color.White;
                UserRights();


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void GrdReuse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_product.SelectedItem.Text == "")
            {
                Session["StrTranType"] = "";
            }
            strtrantype = Session["StrTranType"].ToString();
            try
            {
                OldQuotNo = 0;
                grdQuotation.Visible = true;
                //btnsend.Enabled = false;
                hidreuse.Value = "1";
                if (GrdReuse.Rows.Count > 0)
                {

                    int index = GrdReuse.SelectedRow.RowIndex;
                    //txtQuotation.Text = Convert.ToString(quotid);
                    txtQuotation.Text = ((Label)GrdReuse.Rows[Convert.ToInt32(index)].Cells[0].FindControl("Quotation")).Text;
                    quotid = Convert.ToInt32(txtQuotation.Text);
                    dtQuot = quotation.GetQuotationDetails(quotid, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));

                    ViewState["Approvalby"] = dtQuot;
                    if (dtQuot.Rows.Count > 0)
                    {
                        txtQuotation.Text = Convert.ToString(quotid);

                        OldQuotNo = Convert.ToInt32(txtQuotation.Text);
                        hdf_OldQuotNo.Value = OldQuotNo.ToString();
                        customerid = Convert.ToInt32(dtQuot.Rows[0]["customerid"].ToString());
                        GetAllMailIds(customerid);
                        hdf_customerid.Value = Convert.ToString(customerid);
                        intpol = Convert.ToInt32(dtQuot.Rows[0]["pol"].ToString());
                        hdf_POL.Value = Convert.ToString(intpol);
                        intpor = Convert.ToInt32(dtQuot.Rows[0]["por"].ToString());
                        hdf_POR.Value = Convert.ToString(intpor);
                        intpod = Convert.ToInt32(dtQuot.Rows[0]["pod"].ToString());
                        hdf_POD.Value = Convert.ToString(intpod);
                        intfd = Convert.ToInt32(dtQuot.Rows[0]["fd"].ToString());
                        hdf_FD.Value = Convert.ToString(intfd);
                        cargoid = Convert.ToInt32(dtQuot.Rows[0]["cargoid"].ToString());
                        hdf_cargoid.Value = Convert.ToString(cargoid);
                        sales = Convert.ToInt32(dtQuot.Rows[0]["marketedby"].ToString());
                        hdf_salesperson.Value = Convert.ToString(sales);
                        prepared = Convert.ToInt32(dtQuot.Rows[0]["preparedby"].ToString());

                        hazard = Convert.ToInt32(dtQuot.Rows[0]["hazardous"].ToString());
                        hdf_Hazard.Value = Convert.ToString(hazard);
                        txtDescription.Text = dtQuot.Rows[0]["descn"].ToString();
                        string validtill = dtQuot.Rows[0]["validtill"].ToString();
                        txtValidTill.Text = DateTime.Parse(dtQuot.Rows[0]["validtill"].ToString()).ToString("dd/MM/yyyy");

                        string validtill1 = dtQuot.Rows[0]["quotdate"].ToString();
                        txtDate.Text = DateTime.Parse(dtQuot.Rows[0]["quotdate"].ToString()).ToString("dd/MM/yyyy");


                        txtRemarks.Text = dtQuot.Rows[0]["remarks"].ToString();
                        // txtBrokerage.Text = dtQuot.Rows[0]["brokerage"].ToString();
                        Strshipment = quotation.GetShipment(Char.Parse(dtQuot.Rows[0]["stype"].ToString()));


                        //  strfstatus = quotation.GetFright(Char.Parse(dtQuot.Rows[0]["fstatus"].ToString()));


                        if (strtrantype == "AE" || strtrantype == "AI")
                        {
                            strfstatus = quotation.GetFrightAEAI(Char.Parse(dtQuot.Rows[0]["fstatus"].ToString()));
                        }
                        else
                        {
                            strfstatus = quotation.GetFright(Char.Parse(dtQuot.Rows[0]["fstatus"].ToString()));
                        }

                        if (dtQuot.Rows[0]["approvedby"] != System.DBNull.Value)
                        {
                            app = Convert.ToInt32(dtQuot.Rows[0]["approvedby"].ToString());
                        }
                        if (app != 0)
                        {
                            // btnsend.Enabled = true;
                        }

                        hdf_app.Value = app.ToString();

                        if (dtQuot.Rows[0]["business"].ToString() != "0")
                        {
                            if (dtQuot.Rows[0]["business"].ToString() == "A")
                            {
                                ddl_controlledby.SelectedValue = "A";

                            }
                            else
                            {
                                ddl_controlledby.SelectedValue = "O";
                            }
                        }
                    }

                    txtCustomer.Text = customer.GetCustomername(customerid);
                    txtPOL.Text = port.GetPortname(intpol);
                    txtPOD.Text = port.GetPortname(intpod);
                    txtPOR.Text = port.GetPortname(intpor);
                    txtFD.Text = port.GetPortname(intfd);
                    txtCargo.Text = cargo.GetCargoname(cargoid);
                    txtSalesPerson.Text = employee.GetEmployeeName(sales);
                    //txtPreparedBy.Text = "Prepared By : " + employee.GetEmployeeName(prepared);
                    txtPreparedBy.Text = employee.GetEmployeeName(prepared);

                    //Bhuvana
                    //int crmid = objcrm.GetCRMid(Convert.ToInt32(txtQuotation.Text.ToUpper()), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    //if (crmid != 0)
                    //{
                    //    txtcrm.Text = crmid.ToString();
                    //}
                    //else
                    //{
                    //    txtcrm.Text = "";
                    //}
                    if (hazard == 1)
                    {
                        chkHazard.Checked = true;
                    }
                    else
                    {
                        chkHazard.Checked = false;
                    }
                    ddlShipment.Text = Strshipment;
                    ddlFreight.Text = strfstatus;
                    grdQuotation.DataSource = new DataTable();
                    grdQuotation.DataBind();
                    //dtQuot = quotation.ChargeDetails(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                    //grdQuotation.DataSource = dtQuot;
                    //grdQuotation.DataBind();
                    btnApp.Enabled = true;
                    btnApp.ForeColor = System.Drawing.Color.White;
                    btnSave.Text = "Save";
                    btnSave.ToolTip = "Save";
                    btn_save.Attributes["class"] = "btn ico-save";
                    DataTable Dt = new DataTable();
                    Dt = quotation.CheckQuotForBookingFromQno(quotid, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), "QB");
                    if (Dt.Rows.Count > 0)
                    {
                        //string Customer = custobj.GetCustomername(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()));
                        string Customer = quotation.quotbuyingget(Convert.ToInt32(Dt.Rows[0]["buyingno"].ToString()));
                        string pol = portobj.GetPortname(Convert.ToInt32(Dt.Rows[0]["pol"].ToString()));
                        string pod = portobj.GetPortname(Convert.ToInt32(Dt.Rows[0]["pod"].ToString()));
                        string status;
                        if (Dt.Rows[0]["stype"].ToString() == "F")
                        {
                            status = "FCL";
                        }
                        else
                        {
                            status = "LCL";
                        }
                        string buying = Customer + "/" + pol + "-" + pod + "/" + status;
                        txtBuying.Text = Dt.Rows[0]["buyingno"].ToString();
                        if (txtBuying.Text == "0")
                        {
                            txtBuyingDetails.Text = "";
                        }
                        else
                        {
                            txtBuyingDetails.Text = buying;
                        }
                        GetBuyingGrid();
                    }
                    else
                    {
                        DataTable dtl = new DataTable();
                        baseFil();
                    }
                    if (blnexists == true)
                    {
                        btnApp.Enabled = true;
                        btnApp.ForeColor = System.Drawing.Color.White;
                        btnclose.Enabled = true;
                        btnclose.ForeColor = System.Drawing.Color.White;
                        blnapprove = false;

                    }
                    else
                    {
                        btnApp.Enabled = false;
                        btnApp.ForeColor = System.Drawing.Color.Gray;

                        btnclose.Enabled = true;
                        btnclose.ForeColor = System.Drawing.Color.White;
                        txtCargeEnable();
                        if (lblHeader.Text == "Quotation Approval")
                        {
                            ddlBase.Enabled = false;
                            txtUnable();
                        }
                        blnapprove = false;
                    }


                    //BaseFill();

                }
                if (lblHeader.Text == "Quotation Approval")
                {
                    btnApp.Enabled = true;
                    btnApp.ForeColor = System.Drawing.Color.White;
                }
                btnclose.Text = "Cancel";
                btnclose.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                btnSave.Enabled = true;
                btnSave.ForeColor = System.Drawing.Color.White;
                baseFil();
                UserRights();
                if (dtQuot.Rows.Count > 0)
                {

                    if (app != 0)
                    {
                        btnApp.Enabled = false;
                    }
                }
                txtQuotation.Text = "";
                txtQuotation.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void GrdReuse_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdQuotaionDetails.PageIndex = e.NewPageIndex;
            grdQuotaionDetails.DataSource = (DataTable)ViewState["quotationreuse"];
            grdQuotaionDetails.DataBind();
            this.popupQuot.Show();
            pnlJobAE.Visible = true;
            grdQuotaionDetails.Visible = true;
        }

        protected void GrdReuse_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdReuse, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";


                    Label lblCustomer = (Label)e.Row.FindControl("customer");
                    string tooltip = lblCustomer.Text;
                    e.Row.Cells[1].Attributes.Add("title", tooltip);

                    Label lblCustomer1 = (Label)e.Row.FindControl("pol");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[2].Attributes.Add("title", tooltip1);

                    Label lblCustomer2 = (Label)e.Row.FindControl("pod");
                    string tooltip2 = lblCustomer2.Text;
                    e.Row.Cells[3].Attributes.Add("title", tooltip2);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        public void getvaluereuse()
        {
            try
            {
                OldQuotNo = 0;

                if (txtQuotation.Text != "")
                {
                    quotid = Convert.ToInt32(txtQuotation.Text);
                    DataSet dsQuot = new DataSet();
                    dtQuot = quotation.GetInquiryHeadDetails(quotid, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    dtQuot.TableName = "Test1";
                    dsQuot.Tables.Add("Test1");
                    ViewState["Approvalby"] = dtQuot;

                    if (dtQuot.Rows.Count > 0)
                    {
                        ddl_product.SelectedItem.Text = dtQuot.Rows[0]["product"].ToString();
                        Session["StrTranType"] = dtQuot.Rows[0]["strtrantype"].ToString();
                        DataTable dtterms;
                        dtterms = quotation.Getterms(ddlShipment.Text, dtQuot.Rows[0]["strtrantype"].ToString());
                        if (dtterms.Rows.Count > 0)
                        {
                            txtterms.Text = dtterms.Rows[0]["terms"].ToString();
                            txt_terms.Text = dtterms.Rows[0]["terms"].ToString();
                        }
                        txtQuotation.Text = Convert.ToString(quotid);
                        OldQuotNo = Convert.ToInt32(txtQuotation.Text);
                        hdf_OldQuotNo.Value = OldQuotNo.ToString();
                        txtDate.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                        customerid = Convert.ToInt32(dtQuot.Rows[0]["customerid"].ToString());
                        hdf_customerid.Value = Convert.ToString(customerid);
                        intpol = Convert.ToInt32(dtQuot.Rows[0]["pol"].ToString());
                        hdf_POL.Value = Convert.ToString(intpol);
                        intpor = Convert.ToInt32(dtQuot.Rows[0]["por"].ToString());
                        hdf_POR.Value = Convert.ToString(intpor);
                        intpod = Convert.ToInt32(dtQuot.Rows[0]["pod"].ToString());
                        hdf_POD.Value = Convert.ToString(intpod);
                        intfd = Convert.ToInt32(dtQuot.Rows[0]["fd"].ToString());
                        hdf_FD.Value = Convert.ToString(intfd);
                        cargoid = Convert.ToInt32(dtQuot.Rows[0]["cargoid"].ToString());
                        hdf_cargoid.Value = Convert.ToString(cargoid);
                        sales = Convert.ToInt32(dtQuot.Rows[0]["marketedby"].ToString());
                        hdf_salesperson.Value = Convert.ToString(sales);
                        prepared = Convert.ToInt32(dtQuot.Rows[0]["preparedby"].ToString());
                        hazard = Convert.ToInt32(dtQuot.Rows[0]["hazardous"].ToString());
                        hdf_Hazard.Value = Convert.ToString(hazard);
                        txtDescription.Text = dtQuot.Rows[0]["descn"].ToString();
                        // txtValidTill.Text = Utility.fn_ConvertDate(dtQuot.Rows[0]["validtill"].ToString());

                        txtValidTill.Text = DateTime.Parse(dtQuot.Rows[0]["validtill"].ToString()).ToString("dd/MM/yyyy");
                        txtRemarks.Text = dtQuot.Rows[0]["remarks"].ToString();
                        txtBrokerage.Text = dtQuot.Rows[0]["brokerage"].ToString();
                        Strshipment = quotation.GetShipment(Char.Parse(dtQuot.Rows[0]["stype"].ToString()));

                        if (Session["StrTranType"] != null)
                        {
                            if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                            {
                                strfstatus = quotation.GetFrightAEAI(Char.Parse(dtQuot.Rows[0]["fstatus"].ToString()));

                            }
                            else
                            {
                                strfstatus = quotation.GetFright(Char.Parse(dtQuot.Rows[0]["fstatus"].ToString()));
                            }
                        }
                        if (dtQuot.Rows[0]["business"].ToString() != "0")
                        {
                            if (dtQuot.Rows[0]["business"].ToString() == "A")
                            {
                                ddl_controlledby.SelectedValue = "A";
                            }
                            else
                            {
                                ddl_controlledby.SelectedValue = "O";
                            }
                        }
                        app = Convert.ToInt32(dtQuot.Rows[0]["approvedby"].ToString());
                        hdf_app.Value = app.ToString();
                        //bhuvana
                        //int crmid = objcrm.GetCRMid(Convert.ToInt32(txtQuotation.Text.ToUpper()), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        //txtcrm.Text = crmid.ToString();

                        DataTable dtgroup = new DataTable();
                        DataTable dtgr = new DataTable();

                        dtgroup = customer.GetCustomernamegroupid(customerid);
                        if (dtgroup.Rows.Count > 0)
                        {


                            txtCustomer.Text = dtgroup.Rows[0]["customername"].ToString();
                            txtaddress.Text = dtgroup.Rows[0]["address"].ToString();
                            //if (dtgroup.Rows[0]["groupid"].ToString() != null)
                            if (!string.IsNullOrEmpty(dtgroup.Rows[0]["groupid"].ToString()))
                            {
                                hidgroupid.Value = dtgroup.Rows[0]["groupid"].ToString();
                                dtgr = objoua.RetrieveCustGroupDetails(Convert.ToInt32(hidgroupid.Value));

                                if (dtgr.Rows.Count > 0)
                                {
                                    txtgroupcustomer.Text = dtgr.Rows[0]["groupname"].ToString();
                                    txtgroupAddress.Text = dtgr.Rows[0]["address"].ToString();

                                }

                            }


                        }
                        Bind_outstandingdetailsresue();


                        //txtCustomer.Text = customer.GetCustomername(customerid);

                        txtPOL.Text = port.GetPortname(intpol);
                        txtPOD.Text = port.GetPortname(intpod);
                        txtPOR.Text = port.GetPortname(intpor);
                        txtFD.Text = port.GetPortname(intfd);
                        txtCargo.Text = cargo.GetCargoname(cargoid);
                        txtSalesPerson.Text = employee.GetEmployeeName(sales);
                        //txtPreparedBy.Text = "Prepared By : " + employee.GetEmployeeName(prepared);
                        txtPreparedBy.Text = employee.GetEmployeeName(prepared);
                        if (app == 0)
                        {
                            txtEnable();
                        }
                        else
                        {
                            txtUnable();
                        }
                        if (hazard == 1)
                        {
                            chkHazard.Checked = true;
                        }
                        else
                        {
                            chkHazard.Checked = false;
                        }
                        ddlShipment.Text = Strshipment;
                        ddlFreight.Text = strfstatus;
                        dtQuot = quotation.ChargeDetails(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                        if (dtQuot.Rows.Count > 0)
                        {
                            grdQuotation.DataSource = dtQuot;
                            grdQuotation.DataBind();
                        }
                        Dt = quotation.CheckQuotForBookingFromQno(quotid, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), "QB");
                        if (Dt.Rows.Count > 0)
                        {
                            //txtBuying.Text = Dt.Rows[0]["buyingno"].ToString();
                            // string Customer = custobj.GetCustomername(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()));

                            string Customer = quotation.quotbuyingget(Convert.ToInt32(Dt.Rows[0]["buyingno"].ToString()));

                            string pol = portobj.GetPortname(Convert.ToInt32(Dt.Rows[0]["pol"].ToString()));
                            string pod = portobj.GetPortname(Convert.ToInt32(Dt.Rows[0]["pod"].ToString()));
                            string status;
                            if (Dt.Rows[0]["stype"].ToString() == "F")
                            {
                                status = "FCL";
                            }
                            else
                            {
                                status = "LCL";
                            }

                            txtBuying.Text = Dt.Rows[0]["buyingno"].ToString();
                            string buying = Customer + "/" + pol + "-" + pod + "/" + status;
                            if (txtBuying.Text != "0")
                            {
                                txtBuyingDetails.Text = buying;
                            }
                            else
                            {
                                txtBuyingDetails.Text = "";
                            }

                            GetBuyingGrid();
                        }
                        else
                        {
                            DataTable dt1 = new DataTable();
                            baseFil();
                        }
                        btnclose.Text = "Cancel";
                        btnclose.ToolTip = "Cancel";
                        btn_back1.Attributes["class"] = "btn ico-cancel";
                        btnclose.Enabled = true;
                        btnclose.ForeColor = System.Drawing.Color.White;
                        btnApp.Enabled = false;
                        btnApp.ForeColor = System.Drawing.Color.Gray;

                        txtCargeEnable();
                        grdQuotation.Enabled = true;
                        baseFil();
                        btnSave.Text = "Update";
                        btnSave.ToolTip = "Update";
                        btn_save.Attributes["class"] = "btn ico-update";
                        UserRights();
                    }


                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Inquiry Number');", true);
                        txtQuotation.Focus();
                        return;
                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Inquiry Number');", true);
                    txtQuotation.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txtQuotation.Text = "";
                txtQuotation.Focus();
            }
        }

        protected void Gross_country_CheckedChanged(object sender, EventArgs e)
        {
            if (Gross_country.Checked == true)
            {
                Session["ChkType"] = "true";
            }
            else
            {
                Session["ChkType"] = "false";
            }
        }

        protected void txt_custpono_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grd_Sizetype_PreRender(object sender, EventArgs e)
        {
            if (grd_Sizetype.Rows.Count > 0)
            {
                grd_Sizetype.UseAccessibleHeader = true;
                grd_Sizetype.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void txt_buyrate_TextChanged(object sender, EventArgs e)
        {
            if (txt_buyrate.Text == "0.00")
            {
                txt_buyrate.Text = "0";
            }
            //if (txt_buyrate.Text != "" && txt_margin.Text != "" && txt_sellrate.Text == "")
            //{
            //    double sellrate = ((Convert.ToDouble(txt_margin.Text)) / 100) * (Convert.ToDouble(txt_buyrate.Text)) + Convert.ToDouble(txt_buyrate.Text);
            //    txt_sellrate.Text = sellrate.ToString();
            //}
            //if (txt_buyrate.Text != "" && txt_sellrate.Text != "")
            //{
            //    double ret = Convert.ToDouble(txt_sellrate.Text) - Convert.ToDouble(txt_buyrate.Text);
            //    txt_retention.Text = ret.ToString();
            //    double margin = (((Convert.ToDouble(txt_sellrate.Text)) / (Convert.ToDouble(txt_buyrate.Text))) - 1) * 100;
            //    txt_margin.Text = Convert.ToDouble(margin).ToString("#,0.00");
            //}
            //if (txt_buyrate.Text != "" && txt_margin.Text == "" && txt_sellrate.Text != "" && txt_buyrate.Text != "0")
            //{
            //    double margin = (((Convert.ToDouble(txt_sellrate.Text)) / (Convert.ToDouble(txt_buyrate.Text))) - 1) * 100;
            //    txt_margin.Text = Convert.ToDouble(margin).ToString("#,0.00");
            //    double ret = Convert.ToDouble(txt_sellrate.Text) - Convert.ToDouble(txt_buyrate.Text);
            //    txt_retention.Text = ret.ToString();
            //}
            if (txt_buyrate.Text != "" && txt_margin.Text != "" && txt_sellrate.Text == "")
            {
                double sellrate = ((Convert.ToDouble(txt_margin.Text)) / 100) * (Convert.ToDouble(txt_buyrate.Text)) + Convert.ToDouble(txt_buyrate.Text);
                txt_sellrate.Text = sellrate.ToString();
            }
            else if (txt_buyrate.Text != "" && txt_sellrate.Text != "" && txt_buyrate.Text != "0")
            {
                double ret = Convert.ToDouble(txt_sellrate.Text) - Convert.ToDouble(txt_buyrate.Text);
                txt_retention.Text = ret.ToString();
                double margin = (((Convert.ToDouble(txt_sellrate.Text)) / (Convert.ToDouble(txt_buyrate.Text))) - 1) * 100;
                txt_margin.Text = Convert.ToDouble(margin).ToString("#,0.00");
            }
            else if (txt_buyrate.Text != "" && txt_margin.Text == "" && txt_sellrate.Text != "" && txt_buyrate.Text != "0")
            {
                double margin = (((Convert.ToDouble(txt_sellrate.Text)) / (Convert.ToDouble(txt_buyrate.Text))) - 1) * 100;
                txt_margin.Text = Convert.ToDouble(margin).ToString("#,0.00");
                double ret = Convert.ToDouble(txt_sellrate.Text) - Convert.ToDouble(txt_buyrate.Text);
                txt_retention.Text = ret.ToString();
            }
            else
            {
                txt_margin.Text = "0";
                if (txt_sellrate.Text != "" && txt_buyrate.Text != "")
                {
                    double ret = Convert.ToDouble(txt_sellrate.Text) - Convert.ToDouble(txt_buyrate.Text);
                    txt_retention.Text = ret.ToString();
                }
                else
                {
                    txt_retention.Text = "0";
                }
            }
        }

        protected void txt_sellrate_TextChanged(object sender, EventArgs e)
        {
            if (txt_buyrate.Text != "" && txt_sellrate.Text != "" && txt_buyrate.Text != "0")
            {
                double ret = Convert.ToDouble(txt_sellrate.Text) - Convert.ToDouble(txt_buyrate.Text);
                txt_retention.Text = ret.ToString();
                double margin = (((Convert.ToDouble(txt_sellrate.Text)) / (Convert.ToDouble(txt_buyrate.Text))) - 1) * 100;
                txt_margin.Text = Convert.ToDouble(margin).ToString("#,0.00");
            }
            else if (txt_buyrate.Text != "" && txt_margin.Text == "" && txt_sellrate.Text != "" && txt_buyrate.Text != "0")
            {
                double margin = (((Convert.ToDouble(txt_sellrate.Text)) / (Convert.ToDouble(txt_buyrate.Text))) - 1) * 100;
                txt_margin.Text = Convert.ToDouble(margin).ToString("#,0.00");
                double ret = Convert.ToDouble(txt_sellrate.Text) - Convert.ToDouble(txt_buyrate.Text);
                txt_retention.Text = ret.ToString();
                if (txt_retention.Text == "-∞" || txt_retention.Text == "∞" || txt_margin.Text == "NaN")
                {
                    txt_retention.Text = "0.0";
                }
            }
            else
            {
                txt_margin.Text = "0";
            }
            if (txt_buyrate.Text == "0.00" || txt_buyrate.Text == "0")
            {
                txt_margin.Text = "0.00";
            }
        }



        protected void grd_combinedcharges_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_combinedcharges, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void BuyRateBtn_Click(object sender, EventArgs e)
        {
            //int count = 0;
            //    collectdata();
            //    //i = getvalidity();
            //    //validity = Convert.ToDateTime(Utility.fn_ConvertDate(dtpValidity.Text));
            //    CheckEmp(txtRateby.Text);
            //    if (blnexist == true)
            //    {
            //        return;
            //    }
            //    checkdata();
            //    if (blnexist == true)
            //    {
            //        return;
            //    }
            //    if (count == 0)
            //    {
            //if (i == 1)
            //{

            //if (ddlFreight.Text == "PrePaid")
            //{
            //    freight = 'P';
            //}
            //else if (ddlFreight.Text == "Collect")
            //{
            //    freight = 'C';
            //}

            //if (ddlShipment.Text == "LCL")
            //{
            //    shipment = 'L';
            //}
            //else if (ddlShipment.Text == "FCL")
            //{
            //    shipment = 'F';
            //}
            //else if (ddlShipment.Text == "AIR")
            //{
            //    shipment = 'A';
            //}

            //DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
            //string emploid = Session["LoginUserName"].ToString();
            //int employeeID = Convert.ToInt32(Session["LoginEmpId"]);
            //int preparedby = empobj.GetEmpid(emploid);

            //int custid = Convert.ToInt32(hdf_customerid.Value);
            //int cargoid = Convert.ToInt32(hdf_cargoid.Value);
            //int polid = Convert.ToInt32(hdf_POL.Value);
            //int podid = Convert.ToInt32(hdf_POD.Value);
            //int porid = Convert.ToInt32(hdf_POR.Value);
            //int fdid = Convert.ToInt32(hdf_FD.Value);
            //int obtainedby = Convert.ToInt32(Session["LoginEmpId"]);

            ////char frieght = Convert.ToChar(ddlFreight.SelectedItem.Text);
            ////char shipment = Convert.ToChar(ddlShipment.SelectedItem.Text);


            //total = buyingobj.InsBuyingHead(custid, cargoid, polid, podid, freight, Convert.ToDateTime(txtValidTill.Text), shipment, 'N', 'N', 0, obtainedby, preparedby, txtRemarks.Text, porid, fdid);




            //buyingobj.InsertBuyingNo(Convert.ToInt32(txtQuotation.Text), Convert.ToInt32(total));


            //RateLabel1.Text = Convert.ToString(total);

            if (RateLabel1.Text == "" || RateLabel1.Text == "0")
            //if (RateLabel1.Text == "")
            {
                Buyrateform(sender, e);
                //ScriptManager.RegisterStartupScript(BuyRateBtn, typeof(Button), "alert", "alertify.alert('Buy Rate Ref # " + total + ", Please Generate The Quotation');", true);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Rate Id has generated as " + total + ", please update charges');", true);
            }
            else
            {


                iframe_outstd.Attributes["src"] = "../Sales/BuyingRates.aspx?&quotid=" + txtQuotation.Text + "&POR=" + txtPOR.Text + "&POL=" + txtPOL.Text + "&POD=" + txtPOD.Text + "&FD=" + txtFD.Text + "&Frieght=" + ddlFreight.SelectedItem + "&Shipment=" + ddlShipment.SelectedItem + "&Commodity=" + txtCargo.Text + "&Remarks=" + txtRemarks.Text + "&Preparedby=" + txtPreparedBy.Text + "&Rateid=" + RateLabel1.Text + "&CustomerId=" + txtCustomer.Text + "&validTill=" + txtValidTill.Text + "&Brokerage=" + txtBrokerage.Text + "&quotid2=" + txtQuotation.Text + "&Buyingno=" + txtBuying.Text;

                popup_upload.Visible = true;
                this.popup_uploaddoc.Show();
            }

            //txtCharges.Focus();
            //btncancel.ToolTip = "Cancel";
            //btn_cancel.Attributes["class"] = "btn ico-cancel";
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Date Again .Valid Till Date should not been exceed 15 days');", true);
            //}
            //count = 1;



        }


        public void Buyrateform(object sender, EventArgs e)
        {

            if (ddlFreight.Text == "PrePaid")
            {
                freight = 'P';
            }
            else if (ddlFreight.Text == "Collect")
            {
                freight = 'C';
            }

            if (ddlShipment.Text == "LCL")
            {
                shipment = 'L';
            }
            else if (ddlShipment.Text == "FCL")
            {
                shipment = 'F';
            }
            else if (ddlShipment.Text == "AIR")
            {
                shipment = 'A';
            }

            //DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
            string emploid = Session["LoginUserName"].ToString();
            int employeeID = Convert.ToInt32(Session["LoginEmpId"]);
            int preparedby = empobj.GetEmpid(emploid);

            int custid = Convert.ToInt32(hdf_customerid.Value);
            int cargoid = Convert.ToInt32(hdf_cargoid.Value);
            int polid = Convert.ToInt32(hdf_POL.Value);
            int podid = Convert.ToInt32(hdf_POD.Value);
            int porid = Convert.ToInt32(hdf_POR.Value);
            int fdid = Convert.ToInt32(hdf_FD.Value);
            int obtainedby = Convert.ToInt32(Session["LoginEmpId"]);
            DateTime validtill = Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text));


            //char frieght = Convert.ToChar(ddlFreight.SelectedItem.Text);
            //char shipment = Convert.ToChar(ddlShipment.SelectedItem.Text);


            total = buyingobj.InsBuyingHead(custid, cargoid, polid, podid, freight, validtill, shipment, 'N', 'N', 0, obtainedby, preparedby, txtRemarks.Text, porid, fdid);




            buyingobj.InsertBuyingNo(Convert.ToInt32(txtQuotation.Text), Convert.ToInt32(total));


            RateLabel1.Text = Convert.ToString(total);



            //txtCharges.Focus();
            //btncancel.ToolTip = "Cancel";
            //btn_cancel.Attributes["class"] = "btn ico-cancel";
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Date Again .Valid Till Date should not been exceed 15 days');", true);
            //}
            //count = 1;



            iframe_outstd.Attributes["src"] = "../Sales/BuyingRates.aspx?&quotid=" + txtQuotation.Text + "&POR=" + txtPOR.Text + "&POL=" + txtPOL.Text + "&POD=" + txtPOD.Text + "&FD=" + txtFD.Text + "&Frieght=" + ddlFreight.SelectedItem + "&Shipment=" + ddlShipment.SelectedItem + "&Commodity=" + txtCargo.Text + "&Remarks=" + txtRemarks.Text + "&Preparedby=" + txtPreparedBy.Text + "&Rateid=" + RateLabel1.Text + "&CustomerId=" + txtCustomer.Text + "&validTill=" + txtValidTill.Text + "&Brokerage=" + txtBrokerage.Text + "&quotid2=" + txtQuotation.Text + "&Buyingno=" + txtBuying.Text;
            popup_upload.Visible = true;
            this.popup_uploaddoc.Show();
        }




        protected void grd_combinedcharges_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddl_product.SelectedItem.Text == "")
            {
                Session["StrTranType"] = "";
            }

            if (grd_combinedcharges.Rows.Count > 0)
            {
                baseFil();
                int index = grd_combinedcharges.SelectedRow.RowIndex;
                hid_exrate.Value = grdQuotation.SelectedRow.Cells[2].Text;
                txtCurr.Text = grdQuotation.SelectedRow.Cells[1].Text;
                hdf_Charges.Value = grdQuotation.SelectedRow.Cells[0].Text;
                txtCharges.Text = grdQuotation.SelectedRow.Cells[7].Text;
                txt_sellrate.Text = grdQuotation.SelectedRow.Cells[3].Text;

                txt_margin.Text = grdQuotation.SelectedRow.Cells[5].Text;

                txt_retention.Text = grdQuotation.SelectedRow.Cells[6].Text;
                ddlBase.Text = grdQuotation.SelectedRow.Cells[8].Text;
            }

        }

        protected void GenBtn_Click(object sender, EventArgs e)
        {
            int intpby;
            int empid;
            //Newly added
            string str_usermailid = Session["usermailid"].ToString();
            //string str_mailuser = Session["MailUser"].ToString();
            string str_mailpwd = Session["usermailpwd"].ToString();
            string ddlversion = "";
            DataTable dtQuottt = new DataTable();
            if (ddl_version.Text == "")
            {
                ddlversion = "0";
            }
            else
            {
                ddlversion = ddl_version.Text;
            }
            txt_consignee.Text = "0";
            hdn_Consigneeid.Value = "0";
            dtQuottt = quotation.GetInquiryHeadDetails(Convert.ToInt32(txtQuotation.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
            hdn_shipperid.Value = dtQuottt.Rows[0]["shipperid"].ToString();
            if (RateLabel1.Text != "0" && RateLabel1.Text != "" && txtQuotation.Text != "")
            {

                if (GenQuotBtn.Text == "")
                {
                    if (txtCustomer.Text != "" && txtPOR.Text != "" && txtPOL.Text != "" && txtPOD.Text != "" && txtFD.Text != "")
                    {


                        if (Gross_country.Checked == true)
                        {
                            check = "Y";
                        }
                        else
                        {
                            check = "N";
                        }


                        if (strtrantype == "FE" || strtrantype == "FI")
                        {
                            quotationid = quotation.InsertGenQuotDetails(Convert.ToDateTime(Utility.fn_ConvertDate(txtDate.Text) + " " + DateTime.Now.ToLongTimeString()), Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text) + " " +
                                DateTime.Now.ToLongTimeString()), Session["StrTranType"].ToString(), Convert.ToInt32(hdf_customerid.Value), Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value),
                                Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.SelectedItem.Text, ddlFreight.SelectedItem.Text, Convert.ToInt32(hdf_cargoid.Value),
                                txtDescription.Text, Convert.ToInt32(hdf_salesperson.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hdf_Hazard.Value), txtRemarks.Text.Trim(),
                                "0", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(RateLabel1.Text), Convert.ToInt32(Session["LoginDivisionId"].ToString()), hdf_Bussiness.Value,
                                check, txtterms.Text, Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txt_custpono.Text, txt_routing.Text,
                                txt_transittime.Text, Convert.ToInt32(ddl_moveTypes.SelectedValue), txt_pieces.Text, txt_noofcont.Text,/* Convert.ToDecimal(txt_grwt.Text)*/ 0, (txt_units.Text), Convert.ToDouble(txt_volume.Text), txt_dim.Text, txt_value.Text, 0, Convert.ToInt32(txt_totdays.Text), ddl_feasi.SelectedValue, Convert.ToDateTime(Utility.fn_ConvertDate(txt_enquiry.Text)));//Convert.ToDateTime(Utility.fn_ConvertDate(txt_enquiry.Text))
                        }
                        else
                        {
                            quotationid = quotation.InsertGenQuotDetails(Convert.ToDateTime(Utility.fn_ConvertDate(txtDate.Text) + " " + DateTime.Now.ToLongTimeString()), Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text) + " " +
                                DateTime.Now.ToLongTimeString()), Session["StrTranType"].ToString(), Convert.ToInt32(hdf_customerid.Value), Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value),
                                Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.SelectedItem.Text, ddlFreight.SelectedItem.Text, Convert.ToInt32(hdf_cargoid.Value),
                                txtDescription.Text, Convert.ToInt32(hdf_salesperson.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hdf_Hazard.Value), txtRemarks.Text.Trim(),
                                "0", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(RateLabel1.Text), Convert.ToInt32(Session["LoginDivisionId"].ToString()), hdf_Bussiness.Value,
                                check, txtterms.Text, Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txt_custpono.Text, txt_routing.Text,
                                txt_transittime.Text, Convert.ToInt32(ddl_moveTypes.SelectedValue), txt_pieces.Text, txt_noofcont.Text,/* Convert.ToDecimal(txt_grwt.Text)*/ 0, (txt_units.Text), Convert.ToDouble(txt_volume.Text), txt_dim.Text, txt_value.Text, 0, Convert.ToInt32(txt_totdays.Text), ddl_feasi.SelectedValue, Convert.ToDateTime(Utility.fn_ConvertDate(txt_enquiry.Text)));//Convert.ToDateTime(Utility.fn_ConvertDate(txt_enquiry.Text))
                        }



                    }


                    int buyingno = Convert.ToInt32(RateLabel1.Text);

                    dtproduct = buyingobj.GetSelProduct(buyingno);

                    string product = dtproduct.Rows[0]["trantype"].ToString();

                    dtpercent = buyingobj.GetSelPercent(buyingno, product);



                    dtbuying = buyingobj.SelBuyingDetails(buyingno);

                    dtgetqty = quotation.GetQty(Convert.ToInt32(txtQuotation.Text));
                    if (dtbuying.Rows.Count > dtgetqty.Rows.Count)
                    {

                        DataRow dr;
                        dr = dtgetqty.NewRow();
                        dr["Base"] = "BL";
                        dr["Qty"] = 1;

                        dtgetqty.Rows.Add(dr);

                    }
                    for (int i = 0; i < dtbuying.Rows.Count; i++)
                    {
                        for (int j = i + 1; j < dtbuying.Rows.Count; j++)
                        {
                            if (dtbuying.Rows[i]["base"].ToString() == dtbuying.Rows[j]["base"].ToString())
                            {

                                DataRow dr;
                                dr = dtgetqty.NewRow();
                                dr["Base"] = dtbuying.Rows[i]["base"].ToString();
                                dr["Qty"] = dtgetqty.Rows[i]["Qty"].ToString();

                                dtgetqty.Rows.Add(dr);

                                break;


                            }

                        }
                    }
                    //string BASE = dtbuying.Rows[0]["base"].ToString();




                    int quotno = Convert.ToInt32(quotationid);


                    for (int i = 0; i < dtpercent.Rows.Count; i++)
                    {
                        //  string   type1 = dtpercent.Rows[i]["trantype"].ToString();
                        //    string  = dtpercent.Rows[i]["base"].ToString();
                        //    double 
                        double percent = Convert.ToDouble(dtpercent.Rows[i]["margin"].ToString());
                        string chargename = dtbuying.Rows[i]["chargename"].ToString();
                        string curr = dtbuying.Rows[i]["curr"].ToString();
                        string BASE = dtbuying.Rows[i]["base"].ToString();
                        double qty = 0;

                        for (int j = 0; j < dtbuying.Rows.Count; j++)
                        {
                            string base1 = dtpercent.Rows[j]["base"].ToString();
                            if (BASE == base1)
                            {
                                qty = Convert.ToDouble(dtgetqty.Rows[j]["Qty"].ToString());
                                break;
                            }
                        }



                        if (BASE == "BL")
                        {
                            qty = 1;

                        }





                        string rate = dtbuying.Rows[i]["rate"].ToString();

                        double num1 = Convert.ToDouble(rate);





                        double margin = (num1 / 100) * percent;



                        double sell = num1 + margin;

                        //double retension = sell - num1;

                        double num2 = num1 * qty;
                        double sell2 = sell * qty;

                        double retension = sell2 - num2;

                        //string rate = dtbuying.Rows[i]["rate"].ToString();  //1500

                        //double num1 = Convert.ToDouble(rate)*qty;





                        //double margin = (num1 / 100) * percent;   //1500/100 -----150



                        //double sell = num1 + (margin*qty);    //1500+150

                        //double retension = sell - num1;    //1650-1500=150


                        quotation.InsertQuotChargeDetails(quotno, chargename, curr.ToUpper(), num2, BASE, /*Convert.ToInt32(Session["LoginBranchid"].ToString())*/1, /*Convert.ToInt32(Session["LoginDivisionId"].ToString())*/1, Convert.ToDouble(qty), 1.0, sell2, percent, retension, 1);



                        //quotation.Updquotmarginper(quotid, HttpUtility.HtmlDecode(txtCharges.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDecimal(txt_margin.Text), Convert.ToDecimal(txt_retention.Text));

                    }

                    //ScriptManager.RegisterStartupScript(GenBtn, typeof(Button), "alert", "alertify.alert('Quotation Details is Saved Successfully ');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "alert", "alertify.alert('Quot No is Already Generated');", true);

                    return;
                }
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "alert", "alertify.alert('Please Enter Buy RateId');", true);
                return;
            }

            ScriptManager.RegisterStartupScript(GenBtn, typeof(Button), "alert", "alertify.alert('Generate QuotNo  " + quotationid + "  is Generated');", true);

            GenQuotBtn.Text = Convert.ToString(quotationid);

            GenQuotBtn.Visible = true;
        }


        protected void grdBuying_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
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

        protected void GenQuotBtn_Click(object sender, EventArgs e)
        {
            //int buyingno = Convert.ToInt32(RateLabel1.Text);

            //dtproduct = buyingobj.GetSelProduct(buyingno);

            //string product = dtproduct.Rows[0]["trantype"].ToString();

            //dtpercent = buyingobj.GetSelPercent(buyingno, product);



            //dtbuying = buyingobj.SelBuyingDetails(buyingno);

            //dtgetqty = quotation.GetQty(Convert.ToInt32(txtQuotation.Text));

            //int quotno = Convert.ToInt32(GenQuotBtn.Text);


            //for (int i = 0; i < dtpercent.Rows.Count; i++)
            //{
            //    //  string   type1 = dtpercent.Rows[i]["trantype"].ToString();
            //    //    string  = dtpercent.Rows[i]["base"].ToString();
            //    //    double 
            //    double percent = Convert.ToDouble(dtpercent.Rows[i]["margin"].ToString());
            //    string chargename = dtbuying.Rows[i]["chargename"].ToString();
            //    string curr = dtbuying.Rows[i]["curr"].ToString();

            //    int qty = Convert.ToInt32(dtgetqty.Rows[i]["Qty"].ToString());

            //    string rate = dtbuying.Rows[i]["rate"].ToString();

            //    double num1 = Convert.ToDouble(rate);



            //    double margin = (num1 / 100) * percent;

            //    string BASE = dtbuying.Rows[i]["base"].ToString();

            //    double sell = num1 + margin;

            //    double retension = sell - num1;

            //    quotation.InsertQuotChargeDetails(quotno, chargename, curr.ToUpper(), num1, BASE, /*Convert.ToInt32(Session["LoginBranchid"].ToString())*/1, /*Convert.ToInt32(Session["LoginDivisionId"].ToString())*/1, Convert.ToDouble(qty), 1.0, sell, percent, retension, 1);



            //    //quotation.Updquotmarginper(quotid, HttpUtility.HtmlDecode(txtCharges.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDecimal(txt_margin.Text), Convert.ToDecimal(txt_retention.Text));

            //}


            int genquotno = Convert.ToInt32(GenQuotBtn.Text);
            int buyingno = Convert.ToInt32(RateLabel1.Text);
            dtproduct = buyingobj.GetSelProduct(buyingno);
            string product = dtproduct.Rows[0]["trantype"].ToString();
            //string por= txtPOR.Text;
            //string pol = txtPOL.Text;
            //string pod = txtPOD.Text;
            //string fd = txtFD.Text;
            //string Frieght =ddlFreight.SelectedItem.ToString();
            //string shipment =ddlShipment.SelectedItem.ToString();

            //string commodity = txtCargo.Text;
            //string remarks = txtRemarks.Text;
            //string Preparedby = txtPreparedBy.Text;

            //string Rateid = RateLabel1.Text;
            //string CustomerId = txtCustomer.Text;

            //string validTill=txtValidTill.Text;
            //string Brokerage=txtBrokerage.Text;


            if (GenQuotBtn.Text != "0")
            {
                //Response.Redirect("../Sales/QuotBuyBook.aspx?quotno=" + quotno + "&POR=" + por + "&POL=" + pol + "&POD=" + pod + "&FD=" + fd + "&Frieght=" + Frieght + "&Shipment=" + shipment + "&Commodity=" + commodity + "&Remarks=" + remarks /*+ "&Preparedby=" + Preparedby*/ + "&Rateid=" + Rateid + "&CustomerId=" + CustomerId + "&validTill=" + validTill + "&Brokerage=" + Brokerage);

                Response.Redirect("../Sales/QuotBuyBook.aspx?quotno=" + genquotno + "&product=" + product);



            }

        }

        protected void Image4_Load(object sender, EventArgs e)
        {

        }

        protected void btnpopcls_Click(object sender, EventArgs e)
        {
            this.popup_uploaddoc.Hide();
        }

        protected void txt_margin_TextChanged(object sender, EventArgs e)
        {
            if (txt_buyrate.Text != "" && txt_margin.Text != "") //&& txt_sellrate.Text == ""
            {
                double sellrate = ((Convert.ToDouble(txt_margin.Text)) / 100) * (Convert.ToDouble(txt_buyrate.Text)) + Convert.ToDouble(txt_buyrate.Text);
                txt_sellrate.Text = sellrate.ToString();
            }
            if (txt_buyrate.Text != "" && txt_sellrate.Text != "")
            {
                double ret = Convert.ToDouble(txt_sellrate.Text) - Convert.ToDouble(txt_buyrate.Text);
                txt_retention.Text = ret.ToString();
            }
            if (txt_margin.Text == "")
            {
                txt_margin.Text = "0";
            }
        }

        protected void ddlShipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlShipment.Text != "")
            {
                DataTable dtterms = new DataTable();

                dtterms = quotation.Getterms(ddlShipment.Text, strtrantype);
                if (dtterms.Rows.Count > 0)
                {
                    txtterms.Text = dtterms.Rows[0]["terms"].ToString();
                    txt_terms.Text = dtterms.Rows[0]["terms"].ToString();
                }
            }

        }

        protected void btn_approve_Click(object sender, EventArgs e)
        {
            if (ddl_product.SelectedItem.Text == "")
            {
                Session["StrTranType"] = "";
            }
            int version = 0;
            int versionquot, versionrate;
            //string str_mailserver = Session["MailServer"].ToString();
            string str_usermailid = Session["usermailid"].ToString();
            //string str_mailuser = Session["MailUser"].ToString();
            string str_mailpwd = Session["usermailpwd"].ToString();
            try
            {

                //    txtCustomer_TextChanged(sender, e);

                int intpby;
                int empid;
                //if (ddl_product.SelectedItem.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                //    blnerr = true;
                //    ddl_product.Focus();
                //    return;
                //}
                if (txtPOL.Text.ToUpper().Trim() == txtPOD.Text.ToUpper().Trim())
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Both PoL And PoD Should not Same');", true);
                    txtPOD.Text = "";
                    txtPOD.Focus();
                    return;
                }
                if (ddlFreight.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Freight');", true);
                    ddlFreight.Focus();
                    return;
                }
                if (ddlShipment.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Shipment');", true);
                    ddlShipment.Focus();
                    return;
                }
                if (hdn_Incoid.Value == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Enter Inco Term');", true);
                    txtInco.Focus();
                    return;
                }

                if (txt_grwt.Text.Length == 0)
                {
                    txt_grwt.Text = "0";
                }
                if (txt_volume.Text.Length == 0)
                {
                    txt_volume.Text = "0";
                }
                if (txt_totdays.Text.Length == 0)
                {
                    txt_totdays.Text = "0";
                }


                txtCustomer_TextChanged(sender, e);
                txtCargo_TextChanged(sender, e);
                txtPOR_TextChanged(sender, e);
                txtPOL_TextChanged(sender, e);
                txtPOD_TextChanged(sender, e);
                txtFD_TextChanged(sender, e);
                txtSalesPerson_TextChanged(sender, e);
                //txtCarrier_TextChanged(sender, e);
                //DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
                string emploid = Session["LoginUserName"].ToString();
                int employeeID = Convert.ToInt32(Session["LoginEmpId"]);
                int preparedby = empobj.GetEmpid(emploid);
                //int custid = Convert.ToInt32(hdnCarrier.Value);
                int custid;
                if (hdnCarrier.Value == "0" || hdnCarrier.Value == "")// by yuvaraj
                {
                    custid = 0;
                }
                else
                {
                    custid = Convert.ToInt32(hdnCarrier.Value);
                }
                int cargoid = Convert.ToInt32(hdf_cargoid.Value);
                int polid = Convert.ToInt32(hdf_POL.Value);
                int podid = Convert.ToInt32(hdf_POD.Value);
                int porid = Convert.ToInt32(hdf_POR.Value);
                int fdid = Convert.ToInt32(hdf_FD.Value);
                int obtainedby = Convert.ToInt32(Session["LoginEmpId"]);

                int count = 0;
                if (brr == true)
                {
                    return;
                }
                string check = "";
                if (Gross_country.Checked == true)
                {
                    check = "Y";
                }
                else
                {
                    check = "N";
                }
                if (hdn_shipperid.Value == "")
                {
                    hdn_shipperid.Value = "0";
                }
                else if (hdn_Consigneeid.Value == "")
                {
                    hdn_Consigneeid.Value = "0";
                }
                txt_noofcont.Text = "0";
                //if (txt_noofcont.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select Base Type and Enter Expected Qty.');", true);
                //    brr = false;
                //    return;
                //}
                txtBrokerage.Text = "0";
                if (brr == true)
                {
                    return;
                }
                strtrantype = Session["StrTranType"].ToString();
                string txtCharges1 = hdf_Charges.Value;
                string Curr1 = hdf_Curr.Value;
                bool check1 = false;

                //if (ddlBase.SelectedIndex == 0)
                //{
                //    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Select Base type');", true);
                //    return;
                //}
                //if (txt_buyrate.Text == "")
                //{
                //    txt_buyrate.Text = "0";
                //}
                //if (txt_sellrate.Text == "")
                //{
                //    txt_sellrate.Text = "0";
                //}
                //if (txt_buyrate.Text != "" && txt_margin.Text != "" && txt_sellrate.Text == "")
                //{
                //    double sellrate = ((Convert.ToDouble(txt_margin.Text)) / (Convert.ToDouble(txt_buyrate.Text)) * 100);
                //    txt_sellrate.Text = sellrate.ToString();
                //}
                //if (txt_buyrate.Text != "" && txt_sellrate.Text != "")
                //{
                //    double ret = Convert.ToDouble(txt_sellrate.Text) - Convert.ToDouble(txt_buyrate.Text);
                //    txt_retention.Text = ret.ToString();
                //}
                //txtCurr.Text = txtCurr.Text.ToUpper();
                //// oldbase = ddlBase.SelectedValue;
                //if (txtQuotation.Text != "")
                //{
                //    dtQuot = quotation.CheckQuotForBookingFromQno(Convert.ToInt32(txtQuotation.Text), strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Q");
                //    if (dtQuot.Rows.Count > 0)
                //    {
                //        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Booking Already done, you cannot amend. create New Quotation');", true);
                //        return;
                //    }
                //}
                //if (txtCurr.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Currency Should Not Be Blank');", true);
                //    txtCurr.Focus();
                //    return;
                //}
                //else
                //{  //chargeobj.GetLikeChargesName(prefix);
                //    DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                //    int cha = chargeobj.GetCurrID(txtCurr.Text);
                //    if (cha == 0)
                //    {
                //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Currency');", true);
                //        txtCurr.Focus();
                //        return;
                //    }

                //}
                if (btn_approve.ToolTip == "Approve")
                {


                    if (txtQuotation.Text != "" && txtCustomer.Text != "" && txtPOR.Text != "" && txtPOL.Text != "" && txtPOD.Text != "" && txtFD.Text != "")
                    {
                        quotid = Convert.ToInt32(txtQuotation.Text);
                        hid_quotno.Value = txtQuotation.Text;
                        ValidateFunction();
                        CollectData();
                        intapprovedbyid = Convert.ToString(1);
                        DateTime appdate;

                        appdate = Logobj.GetDate();
                        strapproved = Session["LoginUserName"].ToString();
                        dtQuot = quotation.GetInquiryHeadDetails(quotid, strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        if (dtQuot.Rows.Count > 0)
                        {
                            if (dtQuot.Rows[0]["approvedby"].ToString() == "0" && dtQuot.Rows[0]["version"].ToString() == "0")
                            {
                                version = 1;

                            }
                            else
                            {
                                version = Convert.ToInt32(dtQuot.Rows[0]["version"].ToString()) + 1;
                            }
                            // txt_version.Text = version.ToString();



                            if (grdQuotation.Rows.Count > 0)
                            {
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Charges are not Available in this Inquiry');", true);
                                return;
                            }

                            intpby = employee.GetNEmpid(txtPreparedBy.Text);
                            empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                            //if (intpby == empid)
                            //{
                            //    ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('You can not approve the Quotation prepared by you');", true);
                            //    return;
                            //}
                            //else
                            //{
                            quotation.UpdateQuotationDetailsWApp(quotid, Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text)), Convert.ToInt32(hdf_customerid.Value),
                                Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value), Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.Text,
                                ddlFreight.Text, Convert.ToInt32(hdf_cargoid.Value), txtDescription.Text, Convert.ToInt32(hdf_salesperson.Value), intpby, Convert.ToInt32(Session["LoginEmpId"].ToString()),
                                Convert.ToInt32(hdf_Hazard.Value), appdate, Convert.ToInt32(Session["LoginBranchid"].ToString()));

                            txtapprovedby.Text = Session["LoginEmpName"].ToString();
                            quotation.Updversion(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), version);
                            if (strtrantype == "FE" || strtrantype == "FI")
                            {//Convert.ToDateTime((txtDate.Text) + " " + DateTime.Now.ToLongTimeString())
                                quotation.InsertInquiryHeadDetailsversion(Convert.ToDateTime(Utility.fn_ConvertDate(txtDate.Text) + " " + DateTime.Now.ToLongTimeString()), Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text) + " " +
                                      DateTime.Now.ToLongTimeString()), Session["StrTranType"].ToString(), Convert.ToInt32(hdf_customerid.Value), Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value),
                                      Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.SelectedItem.Text, ddlFreight.SelectedItem.Text, Convert.ToInt32(hdf_cargoid.Value),
                                      txtDescription.Text, Convert.ToInt32(hdf_salesperson.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hdf_Hazard.Value), txtRemarks.Text.Trim(),
                                      "0", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtBuying.Text.Trim()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), hdf_Bussiness.Value,
                                      check, txtterms.Text, Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txt_custpono.Text, txt_routing.Text,
                                      txt_transittime.Text, Convert.ToInt32(ddl_moveTypes.SelectedValue), txt_pieces.Text, txt_noofcont.Text, Convert.ToDecimal(txt_grwt.Text), (txt_units.Text), Convert.ToDecimal(txt_volume.Text), txt_dim.Text, txt_value.Text, 0, Convert.ToInt32(txt_totdays.Text), ddl_feasi.SelectedValue, version, quotid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_enquiry.Text)));
                            }
                            else
                            {
                                quotation.InsertInquiryHeadDetailsversion(Convert.ToDateTime(Utility.fn_ConvertDate(txtDate.Text) + " " + DateTime.Now.ToLongTimeString()), Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text) + " " +
                                                        DateTime.Now.ToLongTimeString()), Session["StrTranType"].ToString(), Convert.ToInt32(hdf_customerid.Value), Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value),
                                                        Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.SelectedItem.Text, ddlFreight.SelectedItem.Text, Convert.ToInt32(hdf_cargoid.Value),
                                                        txtDescription.Text, Convert.ToInt32(hdf_salesperson.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hdf_Hazard.Value), txtRemarks.Text.Trim(),
                                                        "0", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtBuying.Text.Trim()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), hdf_Bussiness.Value,
                                                        check, txtterms.Text, Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txt_custpono.Text, txt_routing.Text,
                                                        txt_transittime.Text, Convert.ToInt32(ddl_moveTypes.SelectedValue), txt_pieces.Text, "0", Convert.ToDecimal(txt_grwt.Text), (txt_units.Text), Convert.ToDecimal(txt_volume.Text), txt_dim.Text, txt_value.Text, Convert.ToDecimal(txt_noofcont.Text), Convert.ToInt32(txt_totdays.Text), ddl_feasi.SelectedValue, version, quotid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_enquiry.Text)));
                            }
                            buyingobj.InsBuyingHeadversion(custid, cargoid, polid, podid, freight, Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text)), shipment, dgcargo, bulkvolume, Convert.ToDouble(txtBrokerage.Text), obtainedby, preparedby, txtRemarks.Text.ToUpper().Trim(), porid, fdid, Convert.ToInt32(txtBuying.Text), version);
                            quotation.InsertChargeDetailsnewversion(Convert.ToInt32(txtQuotation.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), version);
                            buyingobj.InsBuyingDetailsversion(Convert.ToInt32(txtBuying.Text), version);

                            try
                            {
                                if (txtPOD.Text != "")
                                {

                                    DataTable bmdt = new DataTable();
                                    hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(txtPOD.Text.ToUpper()));
                                    int_country = Convert.ToInt32(hf_countryid.Value);
                                    if (int_country == 233)
                                    {
                                        DataSet mds;
                                        mds = obj_da_Branch.getmailcredentials(Convert.ToInt32(Session["LoginBranchid"]));

                                        string Bmmail = "";

                                        string Bccmail = "";

                                        if (mds.Tables.Count > 0)
                                        {
                                            bmdt = (DataTable)mds.Tables[0];

                                            if (bmdt.Rows.Count > 0)
                                            {
                                                Bmmail = bmdt.Rows[0]["automail"].ToString();
                                                Bccmail = bmdt.Rows[0]["automail"].ToString();
                                            }
                                            Utility.SendMail1(str_usermailid, Bccmail, "US Shipment - Quotation # : " + txtQuotation.Text + "-" + txtPOL.Text + " to " + txtPOD.Text, sendqry, "", str_mailpwd, "", "");


                                        }
                                    }
                                }
                            } //
                            catch (Exception ex)
                            {

                            }

                            //quotid = Convert.ToInt32(txtQuotation.Text);
                            //int chargeid = charges.GetChargeid(HttpUtility.HtmlDecode(txtCharges.Text));
                            //string amtval = "";
                            //if (grd_Sizetype.Rows.Count > 0)
                            //{
                            //    for (int j = 0; j <= grd_Sizetype.Rows.Count - 1; j++)
                            //    {
                            //        string SType = grd_Sizetype.Rows[j].Cells[1].Text;
                            //        CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                            //        if (cbox.Checked == true)
                            //        {
                            //            amtval = "";
                            //            TextBox txtBox = (TextBox)grd_Sizetype.Rows[j].FindControl("txt_Sizecount");


                            //            if (ddl_product.Text == "Ocean Exports" || ddl_product.Text == "Ocean Imports")
                            //            {

                            //                if (SType != "CBM")
                            //                {
                            //                    if (System.Text.RegularExpressions.Regex.IsMatch(txtBox.Text, "[^0-9]"))
                            //                    {
                            //                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Numbers Only allowed');", true);
                            //                        txtBox.Focus();
                            //                        return;
                            //                    }
                            //                }
                            //            }
                            //            else if (ddl_product.Text == "Air Exports" || ddl_product.Text == "Air Imports")
                            //            {
                            //                if (SType != "KGS")
                            //                {
                            //                    if (System.Text.RegularExpressions.Regex.IsMatch(txtBox.Text, "[^0-9]"))
                            //                    {
                            //                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Numbers Only allowed');", true);
                            //                        txtBox.Focus();
                            //                        return;
                            //                    }
                            //                }
                            //            }
                            //            if (ddlBase.Text != "BL" && SType != ddlBase.Text)
                            //            {

                            //                ScriptManager.RegisterStartupScript(btnAdd, typeof(Button), "logix", "alertify.alert('Select and Enter Expected Qty for Base type : " + ddlBase.Text + "');", true);
                            //                return;

                            //            }
                            //            else if (txtBox.Text == "")
                            //            {
                            //                ScriptManager.RegisterStartupScript(btnAdd, typeof(Button), "logix", "alertify.alert('Enter Exp.Qty for " + SType + "');", true);
                            //                txtBox.Focus();
                            //                //amtval = "1";
                            //                return;
                            //            }
                            //            else
                            //            {
                            //                amtval = txtBox.Text;
                            //            }
                            //            double firstamt = 0;
                            //            firstamt = Convert.ToDouble(txt_sellrate.Text);
                            //            //double totalamt = firstamt * Convert.ToInt32(amtval);
                            //            if (txt_sellrate.Text != "")
                            //            {
                            //                if (SType == ddlBase.Text)
                            //                {
                            //                    if (ddlBase.Text != "" && txtCharges.Text != "" && txtCurr.Text != "" && txt_sellrate.Text != "")
                            //                    {

                            //                        string strbase = ddlBase.Text;
                            //                        famount = Convert.ToDouble(txt_sellrate.Text) * Convert.ToDouble(hid_exrate.Value) * Convert.ToDouble(amtval); //CheckBase(strbase, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtex.Text));
                            //                        txtamount.Text = famount.ToString();
                            //                        txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
                            //                        hid_amount.Value = Convert.ToDecimal(txtamount.Text).ToString("0.00");

                            //                    }
                            //                    quotation.InsertChargeDetailsnewversion(Convert.ToInt32(txtQuotation.Text), txtCharges.Text, txtCurr.Text.ToUpper(), Convert.ToDouble(txt_sellrate.Text), ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToDouble(amtval), Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value), version);
                            //                    quotation.Updquotmarginper(Convert.ToInt32(txtQuotation.Text), HttpUtility.HtmlDecode(txtCharges.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDecimal(txt_margin.Text), Convert.ToDecimal(txt_retention.Text));

                            //                    check1 = true;
                            //                }
                            //            }
                            //        }
                            //    }
                            //}
                            //if (check1 == false)
                            //{
                            //    if (txt_sellrate.Text != "")
                            //    {
                            //        if ((ddlBase.Text == "BL") || (ddlBase.Text == "HAWB"))
                            //        {
                            //            if (ddlBase.Text != "" && txtCharges.Text != "" && txtCurr.Text != "" && txt_sellrate.Text != "")
                            //            {

                            //                string strbase = ddlBase.Text;
                            //                famount = Convert.ToDouble(txt_sellrate.Text) * Convert.ToDouble(hid_exrate.Value) * 1; //CheckBase(strbase, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtex.Text));
                            //                txtamount.Text = famount.ToString();
                            //                txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
                            //                hid_amount.Value = Convert.ToDecimal(txtamount.Text).ToString("0.00");

                            //            }
                            //            quotation.InsertChargeDetailsnewversion(Convert.ToInt32(txtQuotation.Text), txtCharges.Text, txtCurr.Text.ToUpper(), Convert.ToDouble(txt_sellrate.Text), ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 1, Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value), version);
                            //            quotation.Updquotmarginper(Convert.ToInt32(txtQuotation.Text), HttpUtility.HtmlDecode(txtCharges.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDecimal(txt_margin.Text), Convert.ToDecimal(txt_retention.Text));

                            //        }
                            //        else
                            //        {
                            //            ScriptManager.RegisterStartupScript(btnAdd, typeof(Button), "logix", "alertify.alert('Select and Enter Expected Qty for Base type : " + ddlBase.Text + "');", true);
                            //            return;
                            //            //if (ddlBase.Text != "" && txtCharges.Text != "" && txtCurr.Text != "" && txtRate.Text != "")
                            //            //{

                            //            //    string strbase = ddlBase.Text;
                            //            //    famount = Convert.ToDouble(hid_rate.Value) * Convert.ToDouble(hid_exrate.Value) * Convert.ToInt32(amtval); //CheckBase(strbase, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtex.Text));
                            //            //    txtamount.Text = famount.ToString();
                            //            //    txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
                            //            //    hid_amount.Value = Convert.ToDecimal(txtamount.Text).ToString("0.00");

                            //            //}
                            //            //quotation.UpdateGrdChargeDetailsnew(quotid, HttpUtility.HtmlDecode(txtCharges.Text), txtCurr.Text.ToUpper(), Convert.ToDouble(txtRate.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), ddlBase.Text, hid_oldData.Value, 1, Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value));
                            //        }
                            //    }
                            //}
                            //// quotation.InsertChargeDetailsnew(quotid, txtCharges.Text, txtCurr.Text.ToUpper(), Convert.ToDouble(txtRate.Text), ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(hid_expqty.Value), Convert.ToDouble(hid_exrate.Value), Convert.ToDouble(hid_amount.Value));

                            //if (txtBuying.Text != "" && txt_buyrate.Text != "0")
                            //{

                            //    if (txt_buyrate.Text != "")
                            //    {
                            //        buyingobj.InsBuyingDetailsversion(Convert.ToInt32(txt_buyrate.Text), chargeid, txtCurr.Text.ToUpper().Trim(), Convert.ToDouble(txt_buyrate.Text), ddlBase.Text, version);
                            //        //dtbuying = buyingobj.SelBuyingDetailsnew(Convert.ToInt32(txtBuying.Text));
                            //        //Session["Container"] = dtbuying;
                            //        //grdBuying.DataSource = dtbuying;
                            //        //grdBuying.DataBind();
                            //    }
                            //}


                            DataTable dtversion = new DataTable();
                            dtversion = quotation.SpGetversion(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                            if (dtversion.Rows.Count > 0)
                            {
                                ddl_version.Items.Clear();
                                for (int i = 0; i <= dtversion.Rows.Count - 1; i++)
                                {
                                    ddl_version.Items.Add(dtversion.Rows[i]["version"].ToString());
                                }
                            }
                            ddl_version.Text = version.ToString();



                            //}
                            switch (Session["StrTranType"].ToString())
                            {
                                case "FE":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 180, 1, Convert.ToInt32(Session["LoginBranchid"]), "OE_QuotApp # : " + quotid);
                                    break;
                                case "FI":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 181, 1, Convert.ToInt32(Session["LoginBranchid"]), "OI_QuotApp # : " + quotid);
                                    break;
                                case "AE":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 217, 1, Convert.ToInt32(Session["LoginBranchid"]), "AE_QuotApp # : " + quotid);
                                    break;
                                case "AI":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 215, 1, Convert.ToInt32(Session["LoginBranchid"]), "AI_QuotApp # : " + quotid);
                                    break;
                            }
                            // SendDeleiveryStatus();
                            usermail = HrEmpobj.GetMailAdd(Convert.ToInt32(hdf_salesperson.Value));
                            dtQuot = userperobj.GetMLEmpid(userperobj.GetMLUiid(Session["StrTranType"].ToString(), "Quotation Approval"), Convert.ToInt32(Session["LoginBranchid"]));

                            for (int i = 0; i <= dtQuot.Rows.Count - 1; i++)
                            {
                                empmailadd = empmailadd + HrEmpobj.GetMailAdd(Convert.ToInt32(dtQuot.Rows[i][0].ToString())) + ";";
                            }

                            ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Quotation Approved');", true);

                            if (empmailadd != "")
                            {
                                empmailadd = empmailadd.Substring(0, empmailadd.Length - 1);





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

        protected void test_PreRender(object sender, EventArgs e)
        {
            if (test.Rows.Count > 0)
            {
                test.UseAccessibleHeader = true;
                test.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdQuotation_PreRender(object sender, EventArgs e)
        {
            if (grdQuotation.Rows.Count > 0)
            {
                grdQuotation.UseAccessibleHeader = true;
                grdQuotation.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void txt_transittime_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_transittime.Text, "[^0-9]"))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Numbers Only allowed');", true);
                txt_transittime.Text = "";
                txt_transittime.Focus();
                return;
            }
        }

        protected void txt_totdays_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_totdays.Text, "[^0-9]"))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Numbers Only allowed');", true);
                txt_totdays.Text = "";
                txt_totdays.Focus();
                return;
            }
        }

        protected void ddl_version_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_version.Text != "")
            {

                if (ddl_product.SelectedItem.Text == "")
                {
                    Session["StrTranType"] = "";
                }
                getvalueversion();
            }
        }

        public void getvalueversion()
        {
            try
            {
                OldQuotNo = 0;

                if (txtQuotation.Text != "")
                {

                    quotid = Convert.ToInt32(txtQuotation.Text);
                    hid_quotno.Value = txtQuotation.Text;
                    DataSet dsQuot = new DataSet();
                    DataTable dtQuottt = new DataTable();
                    dtQuottt = quotation.GetcombbinedQuotationDetails(quotid, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    dtQuot = quotation.GetcombbinedQuotationDetailsversion(quotid, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(ddl_version.Text));
                    dtQuot.TableName = "Test1";
                    dsQuot.Tables.Add("Test1");
                    ViewState["Approvalby"] = dtQuot;

                    if (dtQuot.Rows.Count > 0)
                    {
                        if (ddl_version.Text != dtQuottt.Rows[0]["version"].ToString())
                        {
                            btn_approve.Enabled = false;
                            btnSave.Enabled = false;
                            btnApp.Enabled = false;
                            btnAdd.Enabled = false;
                        }
                        else
                        {
                            btn_approve.Enabled = true;
                            btnSave.Enabled = true;
                            btnApp.Enabled = true;
                            btnAdd.Enabled = true;
                        }
                        if (dtQuot.Rows[0]["grosscountry"].ToString() == "Y")
                        {
                            Gross_country.Checked = true;
                        }
                        else
                        {
                            Gross_country.Checked = false;
                        }
                        ddl_product.SelectedItem.Text = dtQuot.Rows[0]["product"].ToString();
                        Session["StrTranType"] = dtQuot.Rows[0]["strtrantype"].ToString();
                        DataTable dtterms;
                        dtterms = quotation.Getterms(ddlShipment.Text, dtQuot.Rows[0]["strtrantype"].ToString());
                        if (dtterms.Rows.Count > 0)
                        {
                            txtterms.Text = dtterms.Rows[0]["terms"].ToString();
                            txt_terms.Text = dtterms.Rows[0]["terms"].ToString();
                        }
                        txtQuotation.Text = Convert.ToString(quotid);
                        OldQuotNo = Convert.ToInt32(txtQuotation.Text);
                        hdf_OldQuotNo.Value = OldQuotNo.ToString();
                        customerid = Convert.ToInt32(dtQuot.Rows[0]["customerid"].ToString());
                        hdf_customerid.Value = Convert.ToString(customerid);
                        intpol = Convert.ToInt32(dtQuot.Rows[0]["pol"].ToString());
                        hdf_POL.Value = Convert.ToString(intpol);
                        intpor = Convert.ToInt32(dtQuot.Rows[0]["por"].ToString());
                        hdf_POR.Value = Convert.ToString(intpor);
                        intpod = Convert.ToInt32(dtQuot.Rows[0]["pod"].ToString());
                        hdf_POD.Value = Convert.ToString(intpod);
                        intfd = Convert.ToInt32(dtQuot.Rows[0]["fd"].ToString());
                        hdf_FD.Value = Convert.ToString(intfd);
                        cargoid = Convert.ToInt32(dtQuot.Rows[0]["cargoid"].ToString());
                        hdf_cargoid.Value = Convert.ToString(cargoid);
                        sales = Convert.ToInt32(dtQuot.Rows[0]["marketedby"].ToString());
                        hdf_salesperson.Value = Convert.ToString(sales);
                        prepared = Convert.ToInt32(dtQuot.Rows[0]["preparedby"].ToString());
                        hazard = Convert.ToInt32(dtQuot.Rows[0]["hazardous"].ToString());
                        hdf_Hazard.Value = Convert.ToString(hazard);
                        txtDescription.Text = dtQuot.Rows[0]["descn"].ToString();
                        // txtValidTill.Text = Utility.fn_ConvertDate(dtQuot.Rows[0]["validtill"].ToString());
                        txtterms.Text = dtQuot.Rows[0]["Terms"].ToString();
                        txt_terms.Text = dtQuot.Rows[0]["terms"].ToString();
                        txtValidTill.Text = DateTime.Parse(dtQuot.Rows[0]["validtill"].ToString()).ToString("dd/MM/yyyy");
                        txtRemarks.Text = dtQuot.Rows[0]["remarks"].ToString();
                        txtBrokerage.Text = dtQuot.Rows[0]["brokerage"].ToString();
                        Strshipment = quotation.GetShipment(Char.Parse(dtQuot.Rows[0]["stype"].ToString()));
                        txt_totdays.Text = dtQuot.Rows[0]["totaldays"].ToString();
                        if (dtQuot.Rows[0]["feasibility"].ToString() != "")
                        {
                            ddl_feasi.SelectedValue = dtQuot.Rows[0]["feasibility"].ToString();
                        }

                        if (dtQuot.Rows[0]["enquiryno"].ToString() != "")
                        {
                            txt_enquiry.Text = DateTime.Parse(dtQuot.Rows[0]["enquiryno"].ToString()).ToString("dd/MM/yyyy");
                        }
                        if (Session["StrTranType"] != null)
                        {
                            if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                            {
                                strfstatus = quotation.GetFrightAEAI(Char.Parse(dtQuot.Rows[0]["fstatus"].ToString()));

                            }
                            else
                            {
                                strfstatus = quotation.GetFright(Char.Parse(dtQuot.Rows[0]["fstatus"].ToString()));
                            }
                        }
                        if (dtQuot.Rows[0]["business"].ToString() != "0")
                        {
                            if (dtQuot.Rows[0]["business"].ToString() == "A")
                            {
                                ddl_controlledby.SelectedValue = "A";
                            }
                            else
                            {
                                ddl_controlledby.SelectedValue = "O";
                            }
                        }


                        txt_value.Text = dtQuot.Rows[0]["value"].ToString();
                        DataTable dtinco = new DataTable();
                        hdn_Incoid.Value = dtQuot.Rows[0]["inco"].ToString();
                        dtinco = bookingobj.SelMasterInco(Convert.ToInt32(hdn_Incoid.Value));
                        txt_custpono.Text = dtQuot.Rows[0]["cuspono"].ToString();
                        txt_routing.Text = dtQuot.Rows[0]["routing"].ToString();
                        txt_transittime.Text = dtQuot.Rows[0]["transittime"].ToString();
                        txt_pieces.Text = dtQuot.Rows[0]["pieces"].ToString();
                        if (Session["StrTranType"].ToString() == "FI" || Session["StrTranType"].ToString() == "FE")
                        {
                            txt_noofcont.Text = dtQuot.Rows[0]["noofcont"].ToString();
                        }
                        else
                        {
                            txt_noofcont.Text = dtQuot.Rows[0]["chrageblewt"].ToString();
                        }
                        txt_grwt.Text = dtQuot.Rows[0]["grwt"].ToString();
                        txt_units.Text = dtQuot.Rows[0]["noofunits"].ToString();
                        txt_volume.Text = dtQuot.Rows[0]["volume"].ToString();
                        txt_dim.Text = dtQuot.Rows[0]["dimension"].ToString();
                        txt_value.Text = dtQuot.Rows[0]["value"].ToString();
                        //DataTable dtversion = new DataTable();
                        //dtversion = quotation.SpGetversion(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        //if (dtversion.Rows.Count > 0)
                        //{
                        //    ddl_version.Items.Clear();
                        //    for (int i = 0; i <= dtversion.Rows.Count - 1; i++)
                        //    {
                        //        ddl_version.Items.Add(dtversion.Rows[i]["version"].ToString());
                        //    }
                        //}
                        //ddl_version.SelectedItem.Text = dtQuot.Rows[0]["version"].ToString();

                        string data = custobj.GetCustomername(Convert.ToInt32(dtQuot.Rows[0]["carrier"]));
                        if (data == "0")
                        {

                        }
                        else
                        {
                            txtCarrier.Text = data;
                            hdnCarrier.Value = (dtQuot.Rows[0]["carrier"].ToString());
                            TextBox1.Text = custobj.GetCustomerAddress(Convert.ToInt32(dtQuot.Rows[0]["carrier"]));
                        }

                        if (dtinco.Rows.Count > 0)
                        {
                            txtInco.Text = dtinco.Rows[0]["incocode"].ToString();
                        }

                        if (string.IsNullOrEmpty(dtQuot.Rows[0]["scope"].ToString()) != true)
                        {
                            movementtype = Convert.ToInt32(dtQuot.Rows[0]["scope"].ToString());
                            if (movementtype == 1)
                            {
                                ddl_moveTypes.SelectedValue = "1";
                            }
                            else if (movementtype == 2)
                            {
                                ddl_moveTypes.SelectedValue = "2";
                            }
                            else if (movementtype == 3)
                            {
                                ddl_moveTypes.SelectedValue = "3";
                            }
                            else if (movementtype == 4)
                            {
                                ddl_moveTypes.SelectedValue = "4";
                            }
                            else if (movementtype == 0)
                            {
                                ddl_moveTypes.SelectedValue = "0";
                            }


                        }
                        else
                        {
                            ddl_moveTypes.SelectedValue = "0";
                        }
                        //if (Session["StrTranType"].ToString() == "FI" || Session["StrTranType"].ToString() == "AI")
                        //{
                        intcustid = dtQuot.Rows[0]["consigneeid"].ToString();
                        hdn_Consigneeid.Value = dtQuot.Rows[0]["consigneeid"].ToString();

                        txt_consignee.Text = custobj.GetCustomername(Convert.ToInt32(intcustid));

                        txt_consigneemulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(intcustid));

                        //DataTable dtmail = new DataTable();
                        //string Shipmail = custobj.GetCusMailaddrs(Convert.ToInt32(dtBuying.Rows[0]["customerid"].ToString()));

                        //if (Shipmail != "")
                        //{
                        //    dtmail = new DataTable();
                        //    dtmail.Columns.Add("email");
                        //    dtmail.Columns.Add("Cname");
                        //    dtmail.Rows.Add(Shipmail, "Consignee");
                        //    grdCMail.DataSource = dtmail;
                        //    grdCMail.DataBind();
                        //    ViewState["CurrentData"] = dtmail;
                        //}
                        //}
                        //else
                        //{
                        hdn_shipperid.Value = dtQuot.Rows[0]["shipperid"].ToString();
                        txt_shiper.Text = custobj.GetCustomername(Convert.ToInt32(dtQuot.Rows[0]["shipperid"].ToString()));
                        txtCustomer.Text = txt_shiper.Text;
                        txt_shipermulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(dtQuot.Rows[0]["shipperid"].ToString()));
                        //DataTable dtmail = new DataTable();
                        //string Shipmail = custobj.GetCusMailaddrs(Convert.ToInt32(dtBuying.Rows[0]["customerid"].ToString()));

                        //if (Shipmail != "")
                        //{
                        //    dtmail = new DataTable();
                        //    dtmail.Columns.Add("email");
                        //    dtmail.Columns.Add("Cname");
                        //    dtmail.Rows.Add(Shipmail, "Shipper");
                        //    grdCMail.DataSource = dtmail;
                        //    grdCMail.DataBind();
                        //    ViewState["CurrentData"] = dtmail;
                        //}

                        //}
                        app = Convert.ToInt32(dtQuot.Rows[0]["approvedby"].ToString());
                        hdf_app.Value = app.ToString();
                        //bhuvana
                        //int crmid = objcrm.GetCRMid(Convert.ToInt32(txtQuotation.Text.ToUpper()), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        //txtcrm.Text = crmid.ToString();

                        DataTable dtgroup = new DataTable();
                        DataTable dtgr = new DataTable();

                        dtgroup = customer.GetCustomernamegroupid(customerid);
                        if (dtgroup.Rows.Count > 0)
                        {


                            txtCustomer.Text = dtgroup.Rows[0]["customername"].ToString();
                            txtaddress.Text = dtgroup.Rows[0]["address"].ToString();
                            //if (dtgroup.Rows[0]["groupid"].ToString() != null)
                            if (!string.IsNullOrEmpty(dtgroup.Rows[0]["groupid"].ToString()))
                            {
                                hidgroupid.Value = dtgroup.Rows[0]["groupid"].ToString();
                                dtgr = objoua.RetrieveCustGroupDetails(Convert.ToInt32(hidgroupid.Value));

                                if (dtgr.Rows.Count > 0)
                                {
                                    txtgroupcustomer.Text = dtgr.Rows[0]["groupname"].ToString();
                                    txtgroupAddress.Text = dtgr.Rows[0]["address"].ToString();

                                }

                            }


                        }
                        Bind_outstandingdetails();
                        if ((ddl_product.Text == "Air Imports") || (ddl_product.Text == "Air Exports"))
                        {

                            DataTable Dt = new DataTable();
                            Dt.Columns.Add("checksbno");
                            Dt.Columns.Add("conttype");
                            Dt.Columns.Add("txt_Sizecount");
                            Dt.Rows.Add();
                            Dt.Rows[0]["conttype"] = "KGS";
                            Dt.Rows.Add();
                            Dt.Rows[1]["conttype"] = "PER TRUCK";
                            Dt.Rows.Add();
                            Dt.Rows[2]["conttype"] = "COTTON/PALLET";
                            Dt.Rows.Add();
                            Dt.Rows[3]["conttype"] = "AT ACTUALS";
                            grd_Sizetype.DataSource = Dt;
                            grd_Sizetype.DataBind();

                        }
                        else
                        {

                            DataTable Dt = new DataTable();
                            //chkContainerList.Items.Clear();
                            DataSet ds1 = new DataSet();
                            DataTable dtpkg1 = new DataTable();
                            ds1 = container.GetContainersize();
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                dtpkg1 = ds1.Tables[0];
                                Dt.Columns.Add("checksbno");
                                Dt.Columns.Add("conttype");
                                Dt.Columns.Add("txt_Sizecount");

                                if (dtpkg1.Rows.Count > 0)
                                {
                                    //Dt.Rows.Add();
                                    //Dt.Rows[0]["conttype"] = "CBM";
                                    for (int j = 0; j <= dtpkg1.Rows.Count - 1; j++)
                                    {
                                        Dt.Rows.Add();
                                        //Dt.Rows[0]["conttype"] = "CBM";
                                        Dt.Rows[j]["conttype"] = dtpkg1.Rows[j]["conttype"].ToString();
                                    }

                                    Dt.Rows.Add();
                                    Dt.Rows[dtpkg1.Rows.Count]["conttype"] = "CBM";
                                    Dt.Rows.Add();
                                    Dt.Rows[dtpkg1.Rows.Count + 1]["conttype"] = "MT";
                                    //Dt.Rows.Add();
                                    //Dt.Rows[dtpkg1.Rows.Count + 2]["conttype"] = "AT ACTUALS";
                                    grd_Sizetype.DataSource = Dt;
                                    grd_Sizetype.DataBind();
                                }
                                // chkContainerList.DataSource = dtpkg1;
                                // chkContainerList.DataTextField = "conttype";
                                // chkContainerList.DataValueField = "conttype";
                                // chkContainerList.DataBind();
                                //chkContainerList.Items.Insert(1, "BL");
                                //chkContainerList.Items.Insert(2, "CBM");
                                //chkContainerList.Items.Insert(3, "MT");
                            }
                            else
                            {
                                grd_Sizetype.DataSource = Utility.Fn_GetEmptyDataTable();
                                grd_Sizetype.DataBind();
                            }
                        }
                        gridsize();

                        //txtCustomer.Text = customer.GetCustomername(customerid);

                        txtPOL.Text = port.GetPortname(intpol);
                        txtPOD.Text = port.GetPortname(intpod);
                        txtPOR.Text = port.GetPortname(intpor);
                        txtFD.Text = port.GetPortname(intfd);
                        txtCargo.Text = cargo.GetCargoname(cargoid);
                        txtSalesPerson.Text = employee.GetEmployeeName(sales);
                        //txtPreparedBy.Text = "Prepared By : " + employee.GetEmployeeName(prepared);
                        txtPreparedBy.Text = employee.GetEmployeeName(prepared);
                        if (app == 0)
                        {
                            txtEnable();
                        }
                        else
                        {
                            txtUnable();
                        }
                        if (hazard == 1)
                        {
                            chkHazard.Checked = true;
                        }
                        else
                        {
                            chkHazard.Checked = false;
                        }
                        ddlShipment.Text = Strshipment;
                        ddlFreight.Text = strfstatus;
                        dtQuot = quotation.ChargeDetailsnewversion(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), "", Convert.ToInt32(ddl_version.Text));
                        if (dtQuot.Rows.Count > 0)
                        {
                            int i;
                            txtTotal.Text = "";
                            double tot = 0, tot1 = 0;
                            for (i = 0; i <= dtQuot.Rows.Count - 1; i++)
                            {
                                tot1 = Convert.ToDouble(dtQuot.Rows[i]["amount"]);
                                tot = tot + tot1;
                            }
                            DataRow Drow1 = dtQuot.NewRow();
                            Drow1["amount"] = tot.ToString("#,0.00");
                            dtQuot.Rows.Add(Drow1);
                            txtTotal.Text = tot.ToString("#,0.00");
                            hid_tot.Value = tot.ToString("#,0.00");
                            grdQuotation.DataSource = dtQuot;
                            grdQuotation.DataBind();
                        }
                        //int l;
                        //txtTotal.Text = "";
                        //double tot = 0, tot1 = 0;
                        //for (l = 0; l <= grdQuotation.Rows.Count - 1; l++)
                        //{
                        //    tot1 = Convert.ToDouble(grdQuotation.Rows[l].Cells[6].Text);
                        //    tot = tot + tot1;
                        //}
                        //txtTotal.Text = tot.ToString("#,0.00");
                        DataTable Dtnew1 = new DataTable();
                        Dtnew1 = quotation.CheckQuotForBookingFromQno(quotid, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), "QB");
                        if (Dtnew1.Rows.Count > 0)
                        {
                            //txtBuying.Text = Dt.Rows[0]["buyingno"].ToString();
                            // string Customer = custobj.GetCustomername(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()));

                            string Customer = quotation.quotbuyingget(Convert.ToInt32(Dtnew1.Rows[0]["buyingno"].ToString()));

                            string pol = portobj.GetPortname(Convert.ToInt32(Dtnew1.Rows[0]["pol"].ToString()));
                            string pod = portobj.GetPortname(Convert.ToInt32(Dtnew1.Rows[0]["pod"].ToString()));
                            string status;
                            if (Dtnew1.Rows[0]["stype"].ToString() == "F")
                            {
                                status = "FCL";
                            }
                            else
                            {
                                status = "LCL";
                            }

                            txtBuying.Text = Dtnew1.Rows[0]["buyingno"].ToString();
                            hid_rateid.Value = Dtnew1.Rows[0]["buyingno"].ToString();
                            string buying = Customer + "/" + pol + "-" + pod + "/" + status;
                            if (txtBuying.Text != "0")
                            {
                                txtBuyingDetails.Text = buying;

                            }
                            else
                            {
                                txtBuyingDetails.Text = "";
                            }

                            if (txtBuying.Text != "")
                            {
                                dtBooking = quotation.ChargeBuyingDetailsnewversion(Convert.ToInt32(txtBuying.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(ddl_version.Text));
                                //DataView dv = new DataView(dtBooking);
                                //dv.RowFilter = "Base !='BL'";
                                //obj_dtQuot = dv.ToTable("test", true);
                                //DataView dv = new DataView(dtBooking);

                                //string[] a = new string[1];
                                //a[0] = "base";
                                //dv.RowFilter = "base<>'BL'";
                                //obj_dtQuot = dv.ToTable("test", true, a);
                                //baseFil();

                            }
                            if (dtBooking.Rows.Count > 0)
                            {
                                int j;
                                txtbuygrid.Text = "";
                                double totb = 0, totb1 = 0;
                                for (j = 0; j <= dtBooking.Rows.Count - 1; j++)
                                {
                                    totb1 = Convert.ToDouble(dtBooking.Rows[j]["amount"]);
                                    totb = totb + totb1;
                                }
                                DataRow Drow = dtBooking.NewRow();
                                Drow["amount"] = totb.ToString("#,0.00");

                                dtBooking.Rows.Add(Drow);
                                txtbuygrid.Text = totb.ToString("#,0.00");
                                hid_totb.Value = totb.ToString("#,0.00");
                                grdBuying.DataSource = dtBooking;
                                grdBuying.DataBind();
                            }
                            DataTable dtss = buyingobj.Sellbuyingdeatilsversion(Convert.ToInt32(txtBuying.Text), quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(ddl_version.Text));
                            if (dtss.Rows.Count > 0)
                            {
                                int i;
                                txtTotal.Text = "";
                                double totals = 0;
                                double tot2 = 0;
                                txtbuygrid.Text = "";
                                double totb = 0, totb1 = 0;
                                for (i = 0; i <= dtss.Rows.Count - 1; i++)
                                {
                                    tot2 = Convert.ToDouble(dtss.Rows[i]["amount"]);
                                    totals = totals + tot2;
                                    totb1 = Convert.ToDouble(dtss.Rows[i]["sell"]);
                                    totb = totb + totb1;
                                }
                                txtbuyings.Text = totals.ToString("#,0.00");
                                hid_tot.Value = totals.ToString("#,0.00");
                                txtselling.Text = totb.ToString("#,0.00");
                                Hidtotal.Value = totb.ToString("#,0.00");

                                //DataRow Drow6 = dtss.NewRow();
                                //Drow6["amount"] = tot.ToString("#,0.00");
                                //dtss.Rows.Add(Drow6);
                                //txtTotal.Text = tot.ToString("#,0.00");
                                //hid_tot.Value = tot.ToString("#,0.00");

                                //DataRow Drow3 = dtss.NewRow();
                                //Drow3["sell"] = totb.ToString("#,0.00");
                                //dtss.Rows.Add(Drow3);
                                //txtbuygrid.Text = totb.ToString("#,0.00");
                                ////.Value = totb.ToString("#,0.00");
                                //Hidtotal.Value = totb.ToString("#,0.00");

                                GrdBuysellcharge.DataSource = dtss;
                                GrdBuysellcharge.DataBind();
                            }

                        }
                        else
                        {
                            DataTable dt1 = new DataTable();
                            baseFil();
                        }
                        btnclose.Text = "Cancel";
                        btnclose.ToolTip = "Cancel";
                        btn_back1.Attributes["class"] = "btn ico-cancel";
                        btnclose.Enabled = true;
                        btnclose.ForeColor = System.Drawing.Color.White;
                        btnApp.Enabled = false;
                        btnApp.ForeColor = System.Drawing.Color.Gray;

                        txtCargeEnable();
                        grdQuotation.Enabled = true;
                        baseFil();
                        btnSave.Text = "Update";
                        btnSave.ToolTip = "Update";
                        btn_save.Attributes["class"] = "btn ico-update";
                        UserRights();
                    }


                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Inquiry Number');", true);
                        txtQuotation.Focus();
                        return;
                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Inquiry Number');", true);
                    txtQuotation.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txtQuotation.Text = "";
                txtQuotation.Focus();
            }
        }

        protected void grdBuying_PreRender(object sender, EventArgs e)
        {
            if (grdBuying.Rows.Count > 0)
            {
                grdBuying.UseAccessibleHeader = true;
                grdBuying.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void lnk_terms_Click(object sender, EventArgs e)
        {
            if (ddl_product.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                blnerr = true;
                ddl_product.Focus();
                return;
            }
            else
            {
                this.ModalPopupExtender1.Show();
            }
        }

        protected void GrdBuysellcharge_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_product.SelectedItem.Text == "")
                {
                    Session["StrTranType"] = "";
                }
                string date = Logobj.GetDate().ToShortDateString();
                date = Utility.fn_ConvertDate(date.ToString());
                GrdBuysellcharge.Visible = true;
                if (GrdBuysellcharge.Rows.Count > 0)
                {
                    baseFil();
                    int index = GrdBuysellcharge.SelectedRow.RowIndex;
                    //Label txt2 = (Label)grdQuotation.Rows[index].Cells[0].FindControl("Charges");
                    //Label txt3 = (Label)grdQuotation.Rows[index].Cells[2].FindControl("rate");

                    txtqty.Text = GrdBuysellcharge.SelectedRow.Cells[3].Text;
                    hid_expqty.Value = GrdBuysellcharge.SelectedRow.Cells[3].Text;
                    //txtCharges.Text = grdQuotation.SelectedRow.Cells[0].Text;
                    txtCurr.Text = GrdBuysellcharge.SelectedRow.Cells[1].Text;
                    txtCharges.Text = GrdBuysellcharge.SelectedRow.Cells[0].Text;
                    //hid_charge.Value = txtCharges.Text;
                    // txtCurr.Text = txt3.Text;
                    txt_sellrate.Text = GrdBuysellcharge.SelectedRow.Cells[2].Text;
                    hid_sellrate.Value = GrdBuysellcharge.SelectedRow.Cells[2].Text;
                    int chargeid = charges.GetChargeid(txtCharges.Text);
                    if (GrdBuysellcharge.SelectedRow.Cells[4].Text != "&nbsp;")
                    {

                        ddlBase.SelectedValue = GrdBuysellcharge.SelectedRow.Cells[4].Text;
                    }
                    if (GrdBuysellcharge.SelectedRow.Cells[5].Text == "&nbsp;")
                    {
                        txtex.Text = INVOICEobj.GetExRate(txtCurr.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDate(date.ToString())), "R", Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                        hid_exrate.Value = txtex.Text;
                    }
                    else
                    {
                        txtex.Text = GrdBuysellcharge.SelectedRow.Cells[5].Text;
                        hid_exrate.Value = GrdBuysellcharge.SelectedRow.Cells[5].Text;
                    }
                    DataTable dt = new DataTable();
                    dt = quotation.Getbuyingdtls(chargeid, Convert.ToInt32(hid_rateid.Value), ddlBase.SelectedValue);
                    if (dt.Rows.Count > 0)
                    {
                        txt_buyrate.Text = Convert.ToDouble(dt.Rows[0]["rate"]).ToString("0.00");
                    }
                    //if (grdBuying.Rows.Count > 0)
                    //{
                    //    if (index < grdBuying.Rows.Count)
                    //    {
                    //        txt_buyrate.Text = grdBuying.Rows[index].Cells[2].Text;
                    //    }
                    //    else
                    //    {
                    //        txt_buyrate.Text = "0";
                    //    }
                    //}
                    else
                    {
                        txt_buyrate.Text = "0";
                    }
                    if (txt_buyrate.Text != "" && txt_sellrate.Text != "")
                    {
                        double ret = Convert.ToDouble(txt_sellrate.Text) - Convert.ToDouble(txt_buyrate.Text);
                        txt_retention.Text = ret.ToString();
                    }
                    if (txt_buyrate.Text == "0" || txt_buyrate.Text == "0.00" || txt_buyrate.Text == "")
                    {
                        txt_margin.Text = "0";
                    }
                    else
                    {

                        double margin = (Convert.ToDouble(txt_sellrate.Text) - Convert.ToDouble(txt_buyrate.Text)); // yuvaraj * 100    
                        double margin1 = (margin / Convert.ToDouble(txt_buyrate.Text) * 100);

                        txt_margin.Text = Convert.ToDouble(margin1).ToString("0.00");

                        //double margin = ((Convert.ToDouble(txt_sellrate.Text)) / (Convert.ToDouble(txt_buyrate.Text)) * 100);
                        //txt_margin.Text = Convert.ToDouble(margin).ToString("0.00");

                    }


                    // txtamount.Text = GrdBuysellcharge.SelectedRow.Cells[6].Text;
                    ddlBase.Enabled = false;
                    oldbase = ddlBase.SelectedValue;
                    hid_oldData.Value = oldbase;
                    txtCharges.Enabled = false;
                    txtCurr.Enabled = true;
                    txtRate.Enabled = true;
                    btnAdd.Enabled = true;

                    btnSave.Enabled = false;
                    btnAdd.ForeColor = System.Drawing.Color.White;

                    btnSave.ForeColor = System.Drawing.Color.Gray;

                    // btnAdd.Text = "Update";
                    btnAdd.ToolTip = "Update";
                    btn_add.Attributes["class"] = "btn ico-update";
                    UserRights();
                    DataSet dsQuot = new DataSet();
                    dtQuot = quotation.GetInquiryHeadDetails(Convert.ToInt32(txtQuotation.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    dtQuot.TableName = "Test1";
                    dsQuot.Tables.Add("Test1");
                    // ViewState["Approvalby"] = dtQuot;
                    //  DataTable dtappr = (DataTable)ViewState["Approvalby"];

                    if (dtQuot.Rows.Count > 0)
                    {
                        int dtapprvalue = Convert.ToInt32(dtQuot.Rows[0]["approvedby"].ToString());
                        if (dtapprvalue != 0)
                        {
                            //  btnApp.Enabled = false;
                            btnApp.ForeColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            btnApp.Enabled = true;
                            btnApp.ForeColor = System.Drawing.Color.White;
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

        protected void GrdBuysellcharge_PreRender(object sender, EventArgs e)
        {
            if (GrdBuysellcharge.Rows.Count > 0)
            {
                GrdBuysellcharge.UseAccessibleHeader = true;
                GrdBuysellcharge.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdBuysellcharge_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdBuysellcharge, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";

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
            dtgroup = customer.GetCustomernamegroupid(Convert.ToInt32(hdn_shipperid.Value));
            if (dtgroup.Rows.Count > 0)
            {
                txt_shiper.Text = dtgroup.Rows[0]["customername"].ToString();   //if (dtgroup.Rows[0]["groupid"].ToString() != null)
                txt_shipermulti.Text = dtgroup.Rows[0]["address"].ToString();
            }
        }

        protected void txtCarrier_TextChanged1(object sender, EventArgs e)
        {
            dtgroup = customer.GetCustomernamegroupid(Convert.ToInt32(hdnCarrier.Value));
            if (dtgroup.Rows.Count > 0)
            {
                txtCarrier.Text = dtgroup.Rows[0]["customername"].ToString();   //if (dtgroup.Rows[0]["groupid"].ToString() != null)
                TextBox1.Text = dtgroup.Rows[0]["address"].ToString();
            }
        }

        protected void txt_consignee_TextChanged(object sender, EventArgs e)
        {

            dtgroup = customer.GetCustomernamegroupid(Convert.ToInt32(hdn_Consigneeid.Value));
            if (dtgroup.Rows.Count > 0)
            {
                txt_consignee.Text = dtgroup.Rows[0]["customername"].ToString();   //if (dtgroup.Rows[0]["groupid"].ToString() != null)
                txt_consigneemulti.Text = dtgroup.Rows[0]["address"].ToString();
            }
        }

        protected void lnk_credit_Click(object sender, EventArgs e)
        {
            ModalPopupExtender2.Show();
        }
        // End txt_consigneemulti


        protected void RateId_TextChanged(object sender, EventArgs e)
        {
            //iframe_outstd.Attributes["src"] = "../Sales/BuyingRates.aspx?&quotid=" + txtQuotation.Text;
            //popup_upload.Visible = true;
            //this.popup_uploaddoc.Show();
            if (RateLabel1.Text != "0")
            {

                iframe_outstd.Attributes["src"] = "../Sales/BuyingRates.aspx?&quotid=" + txtQuotation.Text + "&POR=" + txtPOR.Text + "&POL=" + txtPOL.Text + "&POD=" + txtPOD.Text + "&FD=" + txtFD.Text + "&Frieght=" + ddlFreight.SelectedItem + "&Shipment=" + ddlShipment.SelectedItem + "&Commodity=" + txtCargo.Text + "&Remarks=" + txtRemarks.Text + "&Preparedby=" + txtPreparedBy.Text + "&Rateid=" + RateLabel1.Text + "&CustomerId=" + txtCustomer.Text + "&validTill=" + txtValidTill.Text + "&Brokerage=" + txtBrokerage.Text + "&quotid2=" + txtQuotation.Text + "&Buyingno=" + txtBuying.Text;
                popup_upload.Visible = true;
                this.popup_uploaddoc.Show();
            }
        }

        public void getbasetext()
        {
            if ((ddl_product.Text != "air imports") && (ddl_product.Text != "air exports"))
            {
                if (grd_Sizetype.Rows.Count > 0)
                {
                    for (int j = 0; j <= grd_Sizetype.Rows.Count - 1; j++)
                    {
                        string stype = grd_Sizetype.Rows[j].Cells[1].Text;
                        CheckBox cbox = (CheckBox)grd_Sizetype.Rows[j].FindControl("checksbno");
                        if (stype == ddlBase.Text)
                        {

                            if (cbox.Checked == false)
                            {
                                //scriptmanager.registerstartupscript(btnadd, typeof(button), "logix", "alertify.alert('select and enter expected.qty for base type : " + ddlbase.text + "');", true);
                                return;
                            }
                        }
                        if (cbox.Checked == true)
                        {


                            string amtval = "";
                            //TextBox txtbox = (TextBox)grd_Sizetype.Rows[j].FindControl("txt_sizecount");

                            String expqty = grd_Sizetype.Rows[j].Cells[2].Text;
                            /// 
                            if (ddl_product.Text == "ocean exports" || ddl_product.Text == "ocean imports")
                            {

                                if (stype != "cbm")
                                {
                                    //if (System.Text.regularexpressions.regex.ismatch(txtbox.Text, "[^0-9]"))
                                    //{
                                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('numbers only allowed');", true);
                                    //    txtbox.Focus();
                                    //    return;
                                    //}
                                }
                            }
                            else if (ddl_product.Text == "air exports" || ddl_product.Text == "air imports")
                            {
                                if (stype != "kgs")
                                {
                                    //if (system.text.regularexpressions.regex.ismatch(txtbox.text, "[^0-9]"))
                                    //{
                                    //    scriptmanager.registerstartupscript(this.page, typeof(page), "logix", "alertify.alert('numbers only allowed');", true);
                                    //    txtbox.focus();
                                    //    return;
                                    //}
                                }
                            }


                            //if (txtbox.Text == "")
                            //{
                            //    ScriptManager.RegisterStartupScript(btnAdd, typeof(Button), "logix", "alertify.alert('enter exp.qty for " + stype + "');", true);
                            //    txtbox.Focus();
                            //    return;
                            //    //amtval = "1";
                            //}
                            //else
                            //{
                            //    amtval = txtbox.Text;
                            //}
                            txt_noofcont.Text += stype + " x " + amtval + ",";
                        }
                    }
                    if (txt_noofcont.Text != "")
                    {
                        txt_noofcont.Text = txt_noofcont.Text.Substring(0, txt_noofcont.Text.Length - 1);
                    }
                }
            }
        }



    }
}

