using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;
using System.Web.UI.DataVisualization.Charting;


namespace logix.Maintenance
{

    public partial class MasterCustomernew : System.Web.UI.Page
    {
        double tds;
        int index;
        int custid;
        protected System.Web.UI.WebControls.CheckBoxList chkType;
        DataTable dt = new DataTable();
        int ok;
       

        DataTable dtCus = new DataTable();
        DataTable dts = new DataTable();
        DataTable obj_dttemp = new DataTable();
        int cityport;
        int intgrdCusid;
        int int_location;
        int int_customer;
        int int_port;
        int int_district;
        int int_state;
        int int_country;
        int llisd;
        string landline;
        int mblisd;
        int faxisd;
        int ownerID;
        int groupids;
        int int_fax;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        string unregistered = "";
        string RCM = "";
        string SEZ = "";
        string Register = "";
        string NotApplicable = "";
        string gstexemp = "";
        char type, status;
        string std;
        DateTime empfrom, empto;

        string Coload = "";
        int k = 1, ddlid, ddlid1;
        Boolean blerr;
        DataTable dt1 = new DataTable();
        DataTable obj_dt = new DataTable();
        int filesize;
        byte[] postfile1 = null;

        byte[] postfile2 = null;
        byte[] postfile3 = null;
        byte[] postfile4 = null;
        byte[] postfile5 = null;

        bool blnerr = false;
        protected string DBCS;

        string username = "";
        string password = "";

        string ip = "";
        string dbname = "";

        public String GSTINFORMAT_REGEX = "[0-9]{2}[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9A-Za-z]{1}[Z]{1}[0-9a-zA-Z]{1}";

        public String GSTN_CODEPOINT_CHARS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        string idfilename, addfilename, iecfilename, idfilepath, ieccode, addfilepath, a, b, c, d, e, gstfilename;
        string SEZIgst = "";

        DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterLocation location = new DataAccess.Masters.MasterLocation();
        DataAccess.Masters.MasterPort port = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCountry countryobj = new DataAccess.Masters.MasterCountry();
        DataAccess.Masters.REqMasterCustomer cusobj = new DataAccess.Masters.REqMasterCustomer();
        DataAccess.Masters.MasterTDSType obj_da_TDS = new DataAccess.Masters.MasterTDSType();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
        DataAccess.Masters.MasterCustomer da_obj_Customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterCustomerGroup obj_mainx = new DataAccess.Masters.MasterCustomerGroup();
        DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.LogDetails objLog = new DataAccess.LogDetails();
        DataAccess.FEEvents objFEevent = new DataAccess.FEEvents();
        DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.Masters.MasterPort obj_port = new DataAccess.Masters.MasterPort();
        DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterCreditApproval obj_creditapp = new DataAccess.Masters.MasterCreditApproval();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCreditApproval Appro_obj = new DataAccess.Masters.MasterCreditApproval();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);



            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_MasterCustomer.GetDataBase(Ccode);
                location.GetDataBase(Ccode);
                port.GetDataBase(Ccode);
                countryobj.GetDataBase(Ccode);
                cusobj.GetDataBase(Ccode);
                obj_da_TDS.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                objp_location.GetDataBase(Ccode);
               


                da_obj_Customerobj.GetDataBase(Ccode);
                obj_mainx.GetDataBase(Ccode);
               
                da_obj_customerobj.GetDataBase(Ccode);
                objLog.GetDataBase(Ccode);
                objFEevent.GetDataBase(Ccode);
                da_obj_employeeobj.GetDataBase(Ccode);
                obj_port.GetDataBase(Ccode);
                obj_emp.GetDataBase(Ccode);


                obj_creditapp.GetDataBase(Ccode);
                
                Appro_obj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);




            }

           // DataAccess.Masters.MasterTDSType obj_da_TDSddd = new DataAccess.Masters.MasterTDSType();
            HttpContext.Current.Session["Agent"] = ddlfacategory.SelectedValue;
            HttpContext.Current.Session["Agent"] = ddlcategory.SelectedValue;
            HttpContext.Current.Session["Others"] = ddlcategory.SelectedValue;
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnBack);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Upload);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txt_gstin);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_xml);
            //grd.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            if (!IsPostBack)
            {
                try
                {
                    ddlCustomerTypefill();
                    lstlocation.Visible = false;
                    txtllstd.Enabled = true;
                    btndelete.Enabled = false;
                    btndelete.ForeColor = System.Drawing.Color.Gray;
                    // grd.Visible = false;
                    //txtcustomer.Focus();
                    txt_gstin.Focus();
                    ddlCType.Enabled = true;
                    lnkCustomer.Visible = false;
                    GrdProofkyc.Visible = true;
                    GrdProofkyc.DataSource = new DataTable();
                    GrdProofkyc.DataBind();
                    grdBusinesscard.DataSource = new DataTable();
                    grdBusinesscard.DataBind();
                    grd.DataSource = new DataTable();
                    grd.DataBind();
                    Gridcreditreq.DataSource = new DataTable();
                    Gridcreditreq.DataBind();
                    GridView1.DataSource = new DataTable();
                    GridView1.DataBind();
                    custds();
                    FillVolumeType();
                    ClearSlap();
                    customermrcode();
                    grd.DataSource = new DataTable();
                    grd.DataBind();
                    FillBranch();//FillBranch();
                    txt_exemptions.Text = "3";
                    txt_overdue.Text = "50";
                    ddl_per.SelectedIndex = 2;
                    ddl_branch.SelectedIndex = 3;
                    ddl_branch.SelectedValue = "3";
                    txt_creditday.Text = "0";// add by yuvaraj 15-12-2022
                    txt_creditamount.Text = "0";
                    //creditdetailsEnable();
                    //btntds.Enabled = false;
                    //btncredit.Enabled = false;
                    ddlcategory.Focus();
                    // add by yuvaraj 10/03/2023
                    Button9.Enabled = false;
                    Button10.Enabled = false;
                    Button11.Enabled = false;
                    Button12.Enabled = false;
                    Button13.Enabled = false;
                    Button14.Enabled = false;
                    Session["customergrdload"] = "0";
                    //End
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
            else if (Page.IsPostBack)
            {
                //txtlocation_TextChanged1(sender, e);
                WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                int indx = wcICausedPostBack.TabIndex;
                var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                           where control.TabIndex > indx
                           select control;
                ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
            }
            // Session["customergrdload"] = "0";
            // txtcustomer.Text = txtpancust.Text;
        }

        public void creditdetailsEnable()
        {
            ddlProductType.Enabled = false;
            txt_vol.Enabled = false;
            ddlvolumetype.Enabled = false;
            txt_revenue.Enabled = false;
            txt_creditdays.Enabled = false;
            txt_creditamount.Enabled = false;
            txt_exemptions.Enabled = false;
            txt_overdue.Enabled = false;
            ddl_per.Enabled = false;
            btnCreditRequestAdd.Enabled = false;
            txtCreditAboveamt.Enabled = false;
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
            //    }
            //Bhuvana
        }

        [WebMethod]
        public static List<string> GetLocation(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
            DataAccess.Masters.MasterCustomerProspective obj_MasterCustomer = new DataAccess.Masters.MasterCustomerProspective();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objp_location.GetDataBase(Ccode);
            obj_MasterCustomer.GetDataBase(Ccode);
            DataTable dt_Location = new DataTable();
            int port;
            if (HttpContext.Current.Session["portid"].ToString() != "0")
            {
                port = Convert.ToInt32(HttpContext.Current.Session["portid"].ToString());
                dt_Location = obj_MasterCustomer.SPSelLikeLocationWithCity(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["portid"].ToString()));
            }
            else
            {
                dt_Location = objp_location.GetlocationnameNEWLocation(prefix.ToUpper());

            }
            List_Result = Utility.Fn_TableToList(dt_Location, "Location", "LocationId");
            return List_Result;
        }

        //kalai
        [WebMethod]
        public static List<string> GetEmployeename(string prefix)
        {
            List<string> gname = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_employeeobj.GetDataBase(Ccode);
         
            obj_dt = da_obj_employeeobj.GetLikeEmployee(prefix.ToUpper());
            gname = Utility.Fn_DatatableToList_int16(obj_dt, "empnamecode", "employeeid");
            return gname;
        }
        //end

        [WebMethod(EnableSession = true)]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterCustomer.GetDataBase(Ccode);
            
            // dt = obj_MasterCustomer.GetCustomerName(prefix);GetLikeCustomerAll
            //////dt = obj_MasterCustomer.SPLikeCustomerAll4Customer(prefix.ToUpper());

            //kalai

            if (HttpContext.Current.Session["Agent"].ToString() == "5")
            {
                dt = obj_MasterCustomer.SPLikeCustomerAll4Customernewtype(prefix.ToUpper(), 'P');
            }
            else if (HttpContext.Current.Session["Others"].ToString() == "6")
            {
                dt = obj_MasterCustomer.SPLikeCustomerAll4Customernewtype(prefix.ToUpper(), 'C');
            }
            else
            {
                dt = obj_MasterCustomer.SPLikeCustomerAll4Customernewtype(prefix.ToUpper(), 'C');
            }
            //  list_result = Utility.Fn_TableToList(dt, "customername", "customerid");
            list_result = Utility.Fn_TableToList_Cust1(dt, "customer", "customerid", "address");
            return list_result;
        }

        [WebMethod]
        public static List<string> GetCustomerss(string prefix)
        {
            DataTable dt = new DataTable();
            //List<string> list_result = new List<string>();
            List<string> gname = new List<string>();

            DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterCustomer.GetDataBase(Ccode);
          
            if (HttpContext.Current.Session["Agent"].ToString() == "5")
            {
                dt = obj_MasterCustomer.SPLikeCustomerAll4Customerwithtypeforpan(prefix.ToUpper(), 'P');
            }
            else if (HttpContext.Current.Session["Others"].ToString() == "6")
            {
                dt = obj_MasterCustomer.SPLikeCustomerAll4Customerwithtypeforpan(prefix.ToUpper(), 'C');
            }
            else
            {
                dt = obj_MasterCustomer.SPLikeCustomerAll4Customerwithtypeforpan(prefix.ToUpper(), 'C');
            }
            gname = Utility.Fn_TableToList_Cust1(dt, "customerfull_legaltype", "customerid", "address");
            return gname;
        }




        [WebMethod]
        public static List<string> Getlikepanno(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterCustomer.GetDataBase(Ccode);
           
            // dt = obj_MasterCustomer.GetCustomerName(prefix);GetLikeCustomerAll
            dt = obj_MasterCustomer.Getlikepanno(prefix.ToUpper());
            //  list_result = Utility.Fn_TableToList(dt, "customername", "customerid");
            list_result = Utility.Fn_TableToList(dt, "CustomerPANno", "CustomerPANId");
            return list_result;
        }

        [WebMethod]
        public static List<string> GetPortName(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterPort.GetDataBase(Ccode);
           
            dt = obj_MasterPort.GetPortNameDetails(prefix.ToUpper());
            // list_result = Fn_TableToList(prefix.ToUpper(), dt, "countryname");
            // list_result = obj_MasterDistrict.GetCountryName(prefix);
            list_result = Utility.Fn_TableToList(dt, "portname", "portid");
            return list_result;
        }

        [WebMethod]
        public static List<string> GetPincode(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable dt_ok = new DataTable();
            DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objp_location.GetDataBase(Ccode);
            
            dt_ok = objp_location.GetlocationnameNEWpincode(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList_Text(dt_ok, "pinCode");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetCustomerbygstin(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterCustomer.GetDataBase(Ccode);
            
            dt = obj_MasterCustomer.GetCustomerbygstin(prefix.ToUpper());
            list_result = Utility.Fn_TableToList(dt, "gstin", "CustomerId");
            return list_result;
        }

        // kalai

        [WebMethod]
        public static List<string> GetEmployeenames(string prefix)
        {
            //List<string> gname = new List<string>();
            List<string> list_result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_employeeobj.GetDataBase(Ccode);
           
            obj_dt = da_obj_employeeobj.GetLikeEmployee(prefix.ToUpper());
            //gname = Utility.Fn_DatatableToList_int16(obj_dt, "empnamecode", "employeeid");
            //return gname;
            list_result = Utility.Fn_TableToList(obj_dt, "empnamecode", "employeeid");
            return list_result;
        }

        protected void loadgrid()
        {
            Grd_Job.Visible = true;
            DataTable obj_dt = new DataTable();
            obj_dt = cusobj.getREQMasterCustomer();
            // popup_Grd.Show();  

            if (obj_dt.Rows.Count <= 0)
            {
                //Grd_Job.DataSource = new DataTable();
                //Grd_Job.DataBind();           
                ScriptManager.RegisterStartupScript(lnk_RCL, typeof(LinkButton), "JobInfo", "alertify.alert('Customer Not Available');", true);
                return;
            }
            else
            {
                Grd_Job.Visible = true;
                popup_Grd.Show();
                Grd_Job.DataSource = obj_dt;
                Grd_Job.DataBind();
            }
        }

        private void LoadDDL()
        {
            ddlCType.ForeColor = System.Drawing.Color.Gray;
            ddlCType.Items.Add("CHA / CNF");
            ddlCType.Items.Add("Consignee");
            ddlCType.Items.Add("Notify Party");
            ddlCType.Items.Add("Others");
            ddlCType.Items.Add("Shipper");
            ddlCType.Items.Add("Freight Forwarder");
            ddlCType.Items.Add("Counter Part");
            ddlCType.Items.Add("Agent / Principal");
            ddlCType.Items.Add("Carrier / Airliner/ MLO / Freight Forwarder");
            ddlCType.Items.Add("CFS");
            ddlCType.Items.Add("Transporter");
            ddlCType.Items.Add("Warehouse");
            //obj_dt = cusobj.getREQMasterCustomer();
            //grd.DataSource = obj_dt;
        }

        private void clear()
        {

            ddlfacategory.SelectedValue = "0";
            ddlfacategory.Enabled = true;
            //ddlfacategory.Enabled = true;
            ddl_Option.SelectedValue = "0";
            //ddlfacategory.SelectedIndex = 0;
            ddlfacategory.SelectedValue = "0";
            //ddlfacategory.Items.Clear();
            // txtcustomer.Text = "";
            ddlCType.SelectedIndex = 0;
            txtunit.Text = "";
            txtbuildingname.Text = "";
            txtdoor.Text = "";
            txtstreet.Text = "";
            txtlocation.Text = "";
            txtcity.Text = "";
            txtdistrict.Text = "";
            txtstate.Text = "";
            txtcountry.Text = "";
            txtllisd.Text = "";
            txtllstd.Text = "";
            txtlandline.Text = "";
            txtpincode.Text = "";
            txtmblisd.Text = "";
            txtMobile.Text = "";
            txtfaxisd.Text = "";
            txtfaxstd.Text = "";
            txtfax.Text = "";
            txtemail.Text = "";
            //  txtPanNo.Text = "";
            txtServiceTaxNo.Text = "";
            txttds.Text = "";
            txtmailcom.Text = "";
            txtcomptc.Text = "";
            txtmailexport.Text = "";
            txtexpptc.Text = "";
            txtmailimp.Text = "";
            txtimpptc.Text = "";
            txtfinptc.Text = "";
            txtmailfin.Text = "";
            txtGSTCode.Text = "";
            txtmailmanag.Text = "";
            txtmanagptc.Text = "";
            ddllocation.SelectedIndex = 0;
            ddllocation.Visible = false;
            txtlocation.Visible = true;
            hdf_pinlocation.Value = "";
            hf_locationid.Value = "";
            hf_portid.Value = "";
            hf_districtid.Value = "";
            hf_stateid.Value = "";
            btn_Upload.ToolTip = "Add";
            hf_countryid.Value = "";
            // hf_customerid.Value = "";
            hf_email.Value = "";
            hfWasConfirmed.Value = "";
            txt_gstin.Text = "";
            //  txt_uinno.Text = "";
            // btnSave.Text = "Save";
            //kalai
            //ddl_Option.SelectedValue = "0";
            // txt_Salesperson.Text = "";

            //ddl_Option.Items.Clear();
            // txtcustomer.Text = "";
            btnSave.ToolTip = "Save";
            btnSave1.Attributes["class"] = "btn ico-save";
            //txt_RCM.Checked = false;
            txt_unregistered.Checked = false;
            txt_gstexi.Checked = false;
            ddlCType.Enabled = true;
            Img_Emp.ImageUrl = "~/images/visitingcard_img.jpg";
            Img_Emp1.ImageUrl = "~/images/visitingcard_img.jpg";
            Img_Emp2.ImageUrl = "~/images/visitingcard_img.jpg";
            Img_Emp3.ImageUrl = "~/images/visitingcard_img.jpg";
            Img_Emp4.ImageUrl = "~/images/visitingcard_img.jpg";
            //Elengo
            txtPanNo.ReadOnly = false;
            lnkCustomer.Visible = false;
            ddl_Option.Enabled = true;
            txtName.Text = "";
            ddlposition.SelectedValue = "";
            grdBusinesscard.DataSource = new DataTable();
            grdBusinesscard.DataBind();
            txt_email.Text = "";
            // txttanno.Text = "";
            //  txtcinno.Text = "";
            //ddl_description.SelectedIndex = 0;
            //ddl_type.SelectedIndex = 0;
            //ddl_slab.SelectedIndex = 0;
            //ddl_percentage.SelectedIndex = 0;
            lblxmlstatus.Text = "XML Upload Status : ";
            txt_Coloadercode.Text = "";
            txt_ColoadRemarks.Text = "";
            ChkCoload.Checked = false;
            // txtcustomer.Enabled = false; hide by 14Feb23
            // txtpancust.Text = "";


            //if (ddlcategory.SelectedItem.Text == "Agent") // yuvaraj 07/12/2022//ddlcategory.SelectedItem.Text == "OtherCountry" hide by 
            //{
            //    txtcustomer.Text = "";
            //    txtcustomer.Enabled = true;
            //    grd.DataSource = Utility.Fn_GetEmptyDataTable();
            //    grd.DataBind(); hide by yuvaraj 14FEB23
            //}

        }

        private void getgrid()
        {
            dt = obj_MasterCustomer.GetCustomerDetails4Grid();
            if (dt.Rows.Count > 0)
            {
                grd.DataSource = dt;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = Utility.Fn_GetEmptyDataTable();
                grd.DataBind();
            }

        }

        protected void Excelfunforserver_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void pdffunforserver_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToPdf();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        [WebMethod]
        public static List<string> GetBankNameDetails(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomer recobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            recobj.GetDataBase(Ccode);
          
            DataTable dt = new DataTable();
            dt = recobj.GetLikeBankName(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(dt, "bankname", "bankid");
            return List_Result;

        }
        protected void txtaccountno_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = obj_MasterCustomer.Gettextchangeledgernamenew(Convert.ToInt32(hf_customerid.Value), txtaccountno.Text, Convert.ToInt32(hid_bankid.Value));
            if (dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CustomerBankAccountDetails", "alertify.alert('Already exists');", true);
                txtaccountno.Focus();
                blerr = true;
                txtifsc.Text = dt.Rows[0]["IFSCCode"].ToString();
                DropDownList5.SelectedItem.Text = dt.Rows[0]["account"].ToString();

                hid_bankid.Value = dt.Rows[0]["bankid"].ToString();
                hid_bankid.Value = txtbankid.Text;
                txtbankid.Enabled = false;
                txtaccountno.Enabled = false;
                DropDownList5.Enabled = false;
                txtifsc.Enabled = false;
                btn_Save.Enabled = false;
                return;
            }
        }
        private void ExportToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "ExportExcel" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            grd.AllowPaging = false;
            getgrid();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            grd.GridLines = GridLines.Both;
            grd.HeaderStyle.Font.Bold = true;
            grd.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        private void ExportToPdf()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Export.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grd.AllowPaging = false;
            getgrid();
            HtmlForm frm = new HtmlForm();
            grd.Parent.Controls.Add(frm);
            frm.Attributes["runat"] = "server";
            frm.Controls.Add(grd);
            frm.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void carggrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            getgrid();
        }

        protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              //  DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
                dt = objp_location.CheckDuplicateForLocationPincode(ddllocation.SelectedValue, txtpincode.Text);
                if (dt.Rows.Count > 0)
                {
                    hf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                }
                if (hf_locationid.Value != "")
                {
                    getlocationdetails();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        private void locationdetails()
        {
            dt = obj_MasterCustomer.GetLocationDetails(txtlocation.Text);
            if (dt.Rows.Count > 0)
            {
                txtlocation.Text = dt.Rows[0]["locationname"].ToString();
                hf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                txtcity.Text = dt.Rows[0]["portname"].ToString();
                hf_portid.Value = dt.Rows[0]["portid"].ToString();
                txtdistrict.Text = dt.Rows[0]["Districts"].ToString();
                hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                txtstate.Text = dt.Rows[0]["States"].ToString();
                hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                txtcountry.Text = dt.Rows[0]["CountryName"].ToString();
                hf_countryid.Value = dt.Rows[0]["countryid"].ToString();
                txtpincode.Text = dt.Rows[0]["pincode"].ToString();
                txtllisd.Text = dt.Rows[0]["ISDcode"].ToString();
                txtllstd.Text = dt.Rows[0]["stdcode"].ToString();
                txtmblisd.Text = dt.Rows[0]["ISDcode"].ToString();
                txtfaxisd.Text = dt.Rows[0]["ISDcode"].ToString();
                txtfaxstd.Text = dt.Rows[0]["stdcode"].ToString();
            }
        }

        protected void txtlocation_TextChanged1(object sender, EventArgs e)
        {
            txtlocationTxtChange();
        }

        protected void txtlocationTxtChange()
        {
            try
            {
                if (hf_locationid.Value != "" && hf_locationid.Value != "0")
                {
                    int locationid = Convert.ToInt32(hf_locationid.Value);
                    DataTable dt1 = new DataTable();
                    if (txttds.Text == "")
                    {
                        txttds.Text = "0";
                    }
                    dt1 = obj_MasterCustomer.GetLocationDetailsIntNEw(Convert.ToInt32(hf_locationid.Value));
                    if (dt1.Rows.Count > 0)
                    {
                        if (dt1.Rows[0]["cityport"].ToString() == "")
                        {
                            txtcity.Enabled = true;
                            txtcity.Text = "";
                            hf_portid.Value = "";
                            txtdistrict.Text = dt1.Rows[0]["Districts"].ToString();
                            hf_districtid.Value = dt1.Rows[0]["districtid"].ToString();
                            txtstate.Text = dt1.Rows[0]["States"].ToString();
                            hf_stateid.Value = dt1.Rows[0]["stateid"].ToString();
                            txtcountry.Text = dt1.Rows[0]["CountryName"].ToString();
                            hf_countryid.Value = dt1.Rows[0]["Countryid"].ToString();
                            txtpincode.Text = dt1.Rows[0]["pincode"].ToString();
                            txtllisd.Text = dt1.Rows[0]["ISDcode"].ToString();
                            // txtllstd.Text = dt1.Rows[0]["stdcode"].ToString();
                            txtmblisd.Text = dt1.Rows[0]["ISDcode"].ToString();
                            txtfaxisd.Text = dt1.Rows[0]["ISDcode"].ToString();
                            txtGSTCode.Text = dt.Rows[0]["GSTCode"].ToString();
                            //txtfaxstd.Text = dt1.Rows[0]["stdcode"].ToString();

                        }
                        else if (dt1.Rows[0]["cityport"].ToString() != "")
                        {
                            // txtcity.Enabled = false;
                            hf_portid.Value = dt1.Rows[0]["cityport"].ToString();
                            dt = obj_MasterCustomer.GETDetails4LocationIntNewPort(Convert.ToInt32(hf_locationid.Value), Convert.ToInt32(hf_portid.Value));
                            txtcity.Text = dt.Rows[0]["portname"].ToString();
                            hf_portid.Value = dt.Rows[0]["cityport"].ToString();
                            // txtdistrict.Text = dt.Rows[0]["Districts"].ToString();
                            hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                            // txtstate.Text = dt.Rows[0]["States"].ToString();
                            hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                            txtcountry.Text = dt.Rows[0]["CountryName"].ToString();
                            hf_countryid.Value = dt.Rows[0]["Countryid"].ToString();
                            txtpincode.Text = dt.Rows[0]["pincode"].ToString();
                            txtllisd.Text = dt.Rows[0]["ISDcode"].ToString();
                            txtllstd.Text = dt.Rows[0]["stdcode"].ToString();
                            txtmblisd.Text = dt.Rows[0]["ISDcode"].ToString();
                            txtfaxisd.Text = dt.Rows[0]["ISDcode"].ToString();
                            txtfaxstd.Text = dt.Rows[0]["stdcode"].ToString();
                            txtGSTCode.Text = dt.Rows[0]["GSTCode"].ToString();
                            txtdistrict.Text = obj_MasterCustomer.GetStateDistrictname(Convert.ToInt32(hf_districtid.Value));
                            txtstate.Text = obj_MasterCustomer.GetStatename(Convert.ToInt32(hf_stateid.Value));
                        }
                       btnBack.Text = "Cancel";

                        btnBack.ToolTip = "Cancel";
                        btnBack1.Attributes["class"] = "btn ico-cancel";
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

            txtlandline.Focus();
        }

        protected void CheckDatd()
        {
            if (ddlfacategory.SelectedValue != "Agent")
            {
                if (hf_countryid.Value == "1102" || hf_countryid.Value == "102")
                {
                    if (txtcustomer.Text == "COUNTTRY")
                    {
                        if (txtcustomer.Text == "CUSTOMER NAME")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Should Not Be Empty');", true);
                            txtcustomer.Focus();
                            blerr = true;
                            return;
                        }
                        //else if (ddlCType.SelectedValue == "CUSTOMER TYPE")
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Select Customer Type');", true);
                        //    ddlCType.Focus();
                        //    blerr = true;
                        //    return;
                        //}
                        //else if (txtunit.Text == "")
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Enter The Unit');", true);
                        //    txtunit.Focus();
                        //    blerr = true;
                        //    return;

                        //}
                        //else if (txtdoor.Text == "DOOR #")
                        //{

                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Enter The Door No');", true);
                        //    txtdoor.Focus();
                        //    blerr = true;
                        //    return;
                        //}
                        else if (txtstreet.Text == "STREET")
                        {

                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Enter The Street');", true);
                            txtstreet.Focus();
                            blerr = true;
                            return;
                        }

                        else if (txtcity.Text == "CITY")
                        {

                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Select City');", true);
                            txtcity.Focus();
                            blerr = true;
                            return;
                        }
                        else if (txtpincode.Text == "PINCODE/ZIP")
                        {

                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Enter The Pin');", true);
                            txtpincode.Focus();
                            blerr = true;
                            return;
                        }

                       //if (txtlocation.Visible == true)
                        // {
                        //     if (txtlocation.Text == "LOCATION")
                        //     {

                       //         ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Select Location');", true);
                        //         txtlocation.Focus();
                        //         blerr = true;
                        //         return;

                       //     }

                       // }
                        // if (ddllocation.Visible == true)
                        // {
                        //     if (ddllocation.SelectedValue == "0")
                        //     {

                       //         ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Select Location');", true);
                        //         txtlocation.Focus();
                        //         blerr = true;
                        //         return;

                       //     }

                       // }

                       // else if (txtlandline.Text == "LANDLINE")
                        // {

                       //     ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Enter landline');", true);
                        //     txtlandline.Focus();
                        //     blerr = true;
                        //     return;

                       // }


                       // else if (txtMobile.Text == "MOBILE")
                        // {

                       //     ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Enter Mobile');", true);
                        //     txtMobile.Focus();
                        //     blerr = true;
                        //     return;

                       // }

                        else if (txtpincode.Text == "PINCODE/ZIP")
                        {

                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Enter The Pin#');", true);
                            txtpincode.Focus();
                            blerr = true;
                            return;
                        }
                    }
                    else
                    {
                        //  hf_countryid.Value = "1102";
                        if (txtcustomer.Text == "")
                        {

                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Should Not Be Empty');", true);
                            txtcustomer.Focus();
                            blerr = true;
                            return;

                        }
                        //else if (ddlCType.SelectedValue == "0")
                        //{

                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Select Customer Type');", true);
                        //    ddlCType.Focus();
                        //    blerr = true;
                        //    return;

                        //}
                        //else if (txtunit.Text == "")
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Enter The Unit');", true);
                        //    txtunit.Focus();
                        //    blerr = true;
                        //    return;

                        //}
                        //else if (txtbuildingname.Text == "")
                        //{

                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Enter The Buliding Name');", true);
                        //    txtbuildingname.Focus();
                        //    blerr = true;
                        //    return;

                        //}
                        //else if (txtdoor.Text == "")
                        //{

                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Enter The Door No');", true);
                        //    txtdoor.Focus();
                        //    blerr = true;
                        //    return;

                        //}

                        else if (txtstreet.Text == "")
                        {

                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Enter The Street');", true);
                            txtstreet.Focus();
                            blerr = true;
                            return;

                        }

                        else if (txtcity.Text == "")
                        {

                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Select City');", true);
                            txtcity.Focus();
                            blerr = true;
                            return;

                        }
                        else if (hf_portid.Value == "" || hf_portid.Value == "0")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Invalid City');", true);
                            txtcity.Focus();
                            blerr = true;
                            return;
                        }

                        else if (txtpincode.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Select Pincode');", true);
                            txtpincode.Focus();
                            blerr = true;
                            return;
                        }
                        //if (ChkCoload.Checked == true && txt_ColoadRemarks.Text == "")
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please  Enter The Coload Remarks')", true);
                        //}

                        if (ChkCoload.Checked == true && txt_Coloadercode.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Please  Enter The Coloader Code');", true);
                            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please  Enter The Coloader Code')", true);
                            txt_Coloadercode.Focus();
                            blerr = true;
                            return;
                        }
                        if (ChkCoload.Checked == false && txt_Coloadercode.Text != "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Please  Select IsCoload');", true);
                            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please  Select IsCoload')", true);
                            ChkCoload.Focus();
                            blerr = true;
                            return;
                        }
                        if (ChkCoload.Checked == false && txt_ColoadRemarks.Text != "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Please  Select IsCoload');", true);
                            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please  Select IsCoload')", true);
                            ChkCoload.Focus();
                            blerr = true;
                            return;
                        }
                        if (ChkCoload.Checked == false && txt_ColoadRemarks.Text != "" && txt_Coloadercode.Text != "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Please  Select IsCoload');", true);
                            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please  Select IsCoload')", true);
                            ChkCoload.Focus();
                            blerr = true;
                            return;
                        }
                    }
                }
            }
            if (hf_countryid.Value != "1102" && hf_countryid.Value != "102")
            {
                if (txtcustomer.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Should Not Be Empty');", true);
                    txtcustomer.Focus();
                    blerr = true;
                    return;
                }
                else if (txtcity.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Select City');", true);
                    txtcity.Focus();
                    blerr = true;
                    return;
                }
            }
            //else if (ddlfacategory.SelectedValue == "Agent")
            //{
            //    if (hf_countryid.Value == "1102" || hf_countryid.Value == "102")
            //    {
            //        if (txtcustomer.Text == "COUNTTRY")
            //        {
            //            if (txtcity.Text == "CITY")
            //            {

            //                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Select City');", true);
            //                txtcity.Focus();
            //                blerr = true;
            //                return;
            //            }
            //            else if (txtcustomer.Text == "CUSTOMER NAME")
            //            {
            //                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Should Not Be Empty');", true);
            //                txtcustomer.Focus();
            //                blerr = true;
            //                return;
            //            }
            //        }
            //    }
            //}

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            int groupid = 0;
            DataTable dtCheck = new DataTable();
            //string value = "";
            string eventdocs = "";
            string eventdocs1 = "";
            DataTable dtnew = new DataTable();
            DataRow dr;
            DataRow dr1;
            DataRow dr2;
            DataRow dr3;
            DataRow dr4;

            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            byte[] Img_Length = new byte[0];

            byte[] Img_Length1 = new byte[0];
            byte[] Img_Length2 = new byte[0];
            byte[] Img_Length3 = new byte[0];
            byte[] Img_Length4 = new byte[0];
            CheckDatd();
            if (blerr == true)
            {
                blerr = false;
                return;
            }
            try
            {
                //if (ddl_branch.SelectedValue != "")
                //{

                //    if (ddl_branch.SelectedValue == "")
                //    {
                //        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly Select the Branch );", true);
                //        ddl_branch.Focus();
                //        return;
                //    }
                //}
                //if (txt_creditamount.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly enter the CreditAmount');", true);
                //    txt_creditamount.Focus();
                //    return;
                //}
                //if (txt_creditday.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly enter the creditdays');", true);
                //    txt_creditday.Focus();
                //    return;
                //}
                //if(txt_Salesperson.Text =="")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly enter the SalesPerson');", true);
                //    txt_Salesperson.Focus();
                //    return;
                //}
                if (hf_employeeid.Value == "0" || hf_employeeid.Value == "")
                {
                    hf_employeeid.Value = "0";
                }

                if (hf_customerid.Value == "")
                {
                    custid = 0;
                    hf_customerid.Value = "0";
                }
                if (hf_locationid.Value == "")
                {
                    int_location = 0;
                }
                else
                {
                    int_location = Convert.ToInt32(hf_locationid.Value);
                }
                if (chkeinvoice.Checked == true)
                {
                    hid_einvoice.Value = "Y";
                }
                else
                {
                    hid_einvoice.Value = "N";
                }
                if (hf_districtid.Value == "")
                {
                    int_district = 0;
                }
                else
                {
                    int_district = Convert.ToInt32(hf_districtid.Value);
                }
                if (hf_stateid.Value == "")
                {
                    int_state = 0;
                }
                else
                {
                    int_state = Convert.ToInt32(hf_stateid.Value);
                }
                if (hf_portid.Value == "")
                {
                    int_port = 0;
                }
                else
                {
                    int_port = Convert.ToInt32(hf_portid.Value);
                }

                if (txtllisd.Text == "")
                {
                    llisd = 0;
                }
                else
                {
                    llisd = Convert.ToInt32(txtllisd.Text);
                }
                if (txtlandline.Text == "")
                {
                    landline = "0";
                }
                else
                {
                    landline = txtlandline.Text;
                }
                if (txtmblisd.Text == "")
                {
                    mblisd = 0;
                }
                else
                {
                    mblisd = Convert.ToInt32(txtmblisd.Text);
                }
                if (txtfaxisd.Text == "")
                {
                    faxisd = 0;
                }
                else
                {
                    faxisd = Convert.ToInt32(txtfaxisd.Text);
                }
                std = txtllstd.Text;
                //if (hf_locationid.Value != "")
                //{

                // int_location = Convert.ToInt32(hf_locationid.Value);
                // int_port = Convert.ToInt32(hf_portid.Value);


                //int_country = Convert.ToInt32(hf_countryid.Value);
                //llisd = Convert.ToInt32(txtllisd.Text);



                //int_fax = Convert.ToInt32(txtfax.Text);

                if (txtcity.Text != "")
                {
                    hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(txtcity.Text.ToUpper()));
                }
                int_country = Convert.ToInt32(hf_countryid.Value);

                if (txt_tds_exp.Text != "" && txt_tds_exp.Text != "&nbsp;") // tds add yuvaraj 27/12/2022
                {
                    tds = Convert.ToDouble(txt_tds_exp.Text.Trim());

                }
                if (txtlandline.Text == "")
                {
                    landline = "";
                }
                else
                {
                    landline = txtlandline.Text;
                }
                //if (txtfax.Text == "")
                //{
                //    int_fax = 0;
                //}
                //else
                //{
                //    int_fax = Convert.ToInt32(txtfax.Text);
                //}
                //kalai 28/10/2022

                string Type1;
                if (ddlCType.SelectedItem.Text == "Agent / Principal / Counter Part")
                {
                    Type1 = "P";
                }
                else if (ddlCType.SelectedItem.Text == "Depo")
                {
                    Type1 = "W";
                }
                else if (ddlcategory.SelectedValue == "5")
                {
                    Type1 = "P";
                }
                else if (ddlfacategory.SelectedValue == "4")
                {
                    Type1 = "P";
                }
                else if (ddlcategory.SelectedValue == "6")
                {
                    Type1 = "C";
                    ddl_Option.SelectedItem.Text = "Registered";
                }
                else
                {
                    Type1 = "C";
                }
                //if (txt_RCM.Checked == true)
                //{
                //    RCM = "Y";
                //}
                //else
                //{
                //    RCM = "N";
                //}
                //if (txt_unregistered.Checked == true)
                //{
                //    unregistered = "Y";
                //}
                //else
                //{
                //    unregistered = "N";
                //}


                //if (txt_gstexi.Checked==true)
                //{
                //    gstexemp = "Y";
                //}
                //else
                //{
                //    gstexemp = "N";
                //}
                if (ddl_Option.SelectedItem.Text == "RCM")
                {
                    RCM = "Y";
                }
                else
                {
                    RCM = "N";
                }
                if (ddl_Option.SelectedItem.Text == "UnRegistered")
                {
                    unregistered = "Y";
                }
                else if (ddl_Option.SelectedItem.Text == "Not Applicable")
                {
                    unregistered = "A";
                }
                else
                {
                    unregistered = "N";
                }
                if (ddl_Option.SelectedItem.Text == "GST Exemption")
                {
                    gstexemp = "Y";
                }
                else
                {
                    gstexemp = "N";
                }
                if (ddl_Option.SelectedItem.Text == "SEZ Exemption")
                {
                    SEZ = "Y";
                }
                else
                {
                    SEZ = "N";
                }
                if (ddl_Option.SelectedItem.Text == "SEZ")
                {
                    SEZIgst = "Y";
                }
                else
                {
                    SEZIgst = "N";
                }
                if (ddl_Option.SelectedItem.Text == "Registered")
                {
                    Register = "Y";
                }
                else
                {
                    Register = "N";
                }
                if (ddlcategory.SelectedItem.Text == "Others")
                {
                    Type1 = "C";
                    unregistered = "A";
                    Register = "N";
                }
                if (ddlcategory.SelectedItem.Text == "Agent")
                {
                    Type1 = "P";
                    unregistered = "A";
                    Register = "N";
                }

                //if (ddl_Option.SelectedItem.Text == "Not Applicable")
                //{
                //    NotApplicable = "A";
                //}
                //else
                //{
                //    NotApplicable = "N";
                //}

                txtcustomer.Text = txtcustomer.Text.ToUpper().Replace(" ,", ", ").Replace("  ,", ", ");

                //if (txt_gstin.Text != "" || txt_uinno.Text != "")
                //{
                //    //unregistered = "N";
                //    if (unregistered == "Y")
                //    {
                //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter only One Uin# (OR) GSTIN# (OR)Select UnRegistered');", true);
                //        return;
                //    }
                //}

                if (ChkCoload.Checked == true)
                {
                    Coload = "Y";
                }
                else
                {
                    Coload = "N";
                }

                if (txt_limit.Text == "")
                {
                    txt_limit.Text = "0.00";
                }
                if (txt_certno.Text == "")
                {
                    txt_certno.Text = "0";
                }
                if (txt_empfrom.Text == "")
                {
                    string date = "01/01/1999";
                    empfrom = DateTime.ParseExact(date, "dd/MM/yyyy", null);
                }
                else
                {
                    empfrom = Convert.ToDateTime(Utility.fn_ConvertDate(txt_empfrom.Text));
                }
                if (txt_empto.Text == "")
                {
                    string date = "01/01/1999";
                    empto = DateTime.ParseExact(date, "dd/MM/yyyy", null);
                }
                else
                {
                    empto = Convert.ToDateTime(Utility.fn_ConvertDate(txt_empto.Text));
                }
                if (txt_tds_exp.Text == "")
                {
                    txt_tds_exp.Text = "0";
                }

                //if (txt_uinno.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter the Uinno#');", true);
                //    txt_uinno.Focus();
                //    return;
                //}

                //if(txt_gstin.Text=="" && txt_uinno.Text=="")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter the Uin# OR GSTIN#');", true);
                //    return;
                //}
                //if (ddllocation.SelectedItem.Text=="" || txtlocation.Text=="")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('select The Location');", true);
                //    return;
                //}
                //if (txtlocation.Text=="")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter The Location');", true);
                //    return;
                //}
                //if (txt_gstin.Text != "" && txt_uinno.Text != "")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter Only the Uin# (OR) GSTIN#');", true);
                //    return;
                //}
                //if(txt_RCM.Checked==true &&  txt_unregistered.Checked==true)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Select  Only RCM (OR) The UnRegistered ');", true);
                //    return;
                //}
                //if (txt_RCM.Checked==true && txt_gstin.Text=="")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter GSTIN#  is  Mandatory  When The RCM');", true);
                //    return;
                //}
                if (hf_countryid.Value == "1102" || hf_countryid.Value == "102")
                {
                    //if (txt_gstin.Text == "" && txt_uinno.Text == "" && txt_RCM.Checked == false && txt_unregistered.Checked == false)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Atleast Enter Any One Uin# (OR) GSTIN# (OR)Select UnRegistered (OR)  Select RCM');", true);
                    //    return;
                    //} 
                    if (txt_gstin.Text == "" && txt_uinno.Text == "" && ddl_Option.SelectedItem.Text != "UnRegistered")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Atleast Enter Any One Uin# (OR) GSTIN# (OR)Select UnRegistered');", true);
                        return;
                    }
                }

                //if (ddl_description.SelectedItem.Text != "" && ddl_description.SelectedItem.Text != "Description")  //&& ddl_slab.SelectedItem.Text != "" && ddl_slab.SelectedItem.Text != "Slab" && ddl_type.SelectedItem.Text != "" && ddl_type.SelectedItem.Text != "Type" && ddl_percentage.SelectedItem.Text != "" && ddl_percentage.SelectedItem.Text != "Percentage")
                //{
                //    if (ddl_type.SelectedItem.Text != "" && ddl_type.SelectedItem.Text != "Type")
                //    {
                //        if (ddl_slab.SelectedItem.Text != "" && ddl_slab.SelectedItem.Text != "Slab")
                //        {
                //            if (ddl_percentage.SelectedItem.Text != "" && ddl_percentage.SelectedItem.Text != "Percentage")
                //            {
                //            }
                //            else
                //            {
                //                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Select Percentage');", true);
                //                return;
                //            }
                //        }
                //        else
                //        {
                //            ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Select Slab');", true);
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Select the Type')", true);
                //        return;
                //    }
                //}

                if (txtstreet.Text == "")
                {
                    txtstreet.Text = " ";
                }

                DateTime today = Convert.ToDateTime(obj_da_Log.GetDate());
                if (txtGSTCode.Text == "")
                {
                    dts = obj_MasterCustomer.SPSelGetCustomerDetailsGSTIN(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
                    if (dts.Rows.Count > 0)
                    {
                        txtGSTCode.Text = dts.Rows[0]["GSTCode"].ToString();
                        hdn_oldgstcode.Value = dts.Rows[0]["GSTCode"].ToString();
                    }
                }

                //Byte[] imgbyte = null;
                //if (FileUpd_logo.PostedFile != null)
                //{
                //    HttpPostedFile File = FileUpd_logo.PostedFile;
                //    imgbyte = new Byte[File.ContentLength];
                //    File.InputStream.Read(imgbyte, 0, File.ContentLength);
                //    filesize = FileUpd_logo.PostedFile.ContentLength / 1024;

                //    string base64String = Convert.ToBase64String(imgbyte);
                //    hdn_Flag.Value = base64String;
                //    ImgLogo.ImageUrl = "data:image/png;base64," + base64String;
                //}
                //if (filesize > 20)
                //{
                //    ScriptManager.RegisterStartupScript(ImgLogo, typeof(Button), "DataFound", "alertify.alert('Image Size Does not Exist 20kb');", true);
                //    FileUpd_logo.Attributes.Clear();
                //    return;
                //}
                if (FileUpd_logo.HasFile && FileUpd_logo.PostedFile != null)
                {
                    string Str_FileExt = System.IO.Path.GetExtension(FileUpd_logo.FileName).ToUpper();
                    int filesize = FileUpd_logo.PostedFile.ContentLength / 1024;
                    if (filesize < 50 && filesize != 0)
                    {
                        if (Str_FileExt == ".JPEG" || Str_FileExt == ".JPG" || Str_FileExt == ".GIF" || Str_FileExt == ".PNG" || Str_FileExt == ".BMP" || Str_FileExt == ".PNG")
                        {
                            dt.Clear();
                            postfile1 = pstFile(FileUpd_logo);
                            dr = dt.NewRow();
                            dt.Columns.Add("image", Type.GetType("System.Byte[]"));
                            dr["image"] = postfile1;
                            dt.Rows.Add(dr);
                            Session["dt"] = dt;
                            string base64String = Convert.ToBase64String(postfile1);
                            Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Upload Image File Only');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Image size should not Exceed 50kb');", true);
                        //img_upload.Attributes.Clear();
                        return;
                    }
                }

                if (FileUpd_logo1.HasFile && FileUpd_logo1.PostedFile != null)
                {
                    string Str_FileExt = System.IO.Path.GetExtension(FileUpd_logo1.FileName).ToUpper();
                    int filesize = FileUpd_logo1.PostedFile.ContentLength / 1024;
                    if (filesize < 50 && filesize != 0)
                    {
                        if (Str_FileExt == ".JPEG" || Str_FileExt == ".JPG" || Str_FileExt == ".GIF" || Str_FileExt == ".PNG" || Str_FileExt == ".BMP" || Str_FileExt == ".PNG")
                        {
                            dt1.Clear();
                            postfile2 = pstFile(FileUpd_logo1);
                            dr1 = dt1.NewRow();
                            dt1.Columns.Add("image1", Type.GetType("System.Byte[]"));
                            dr1["image1"] = postfile2;
                            dt1.Rows.Add(dr1);
                            Session["dt1"] = dt1;
                            string base64String = Convert.ToBase64String(postfile2);
                            Img_Emp1.ImageUrl = "data:image/png;base64," + base64String;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Upload Image File Only');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Image size should not Exceed 50kb');", true);
                        //img_upload.Attributes.Clear();
                        return;
                    }
                }
                if (FileUpd_logo2.HasFile && FileUpd_logo2.PostedFile != null)
                {
                    string Str_FileExt = System.IO.Path.GetExtension(FileUpd_logo2.FileName).ToUpper();
                    int filesize = FileUpd_logo2.PostedFile.ContentLength / 1024;
                    if (filesize < 50 && filesize != 0)
                    {
                        if (Str_FileExt == ".JPEG" || Str_FileExt == ".JPG" || Str_FileExt == ".GIF" || Str_FileExt == ".PNG" || Str_FileExt == ".BMP" || Str_FileExt == ".PNG")
                        {
                            dt2.Clear();
                            postfile3 = pstFile(FileUpd_logo2);
                            dr2 = dt2.NewRow();
                            dt2.Columns.Add("image2", Type.GetType("System.Byte[]"));
                            dr2["image2"] = postfile3;
                            dt2.Rows.Add(dr2);
                            Session["dt2"] = dt2;
                            string base64String = Convert.ToBase64String(postfile3);
                            Img_Emp2.ImageUrl = "data:image/png;base64," + base64String;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Upload Image File Only');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Image size should not Exceed 50kb');", true);
                        //img_upload.Attributes.Clear();
                        return;
                    }
                }

                if (FileUpd_logo3.HasFile && FileUpd_logo3.PostedFile != null)
                {
                    string Str_FileExt = System.IO.Path.GetExtension(FileUpd_logo3.FileName).ToUpper();
                    int filesize = FileUpd_logo3.PostedFile.ContentLength / 1024;
                    if (filesize < 50 && filesize != 0)
                    {
                        if (Str_FileExt == ".JPEG" || Str_FileExt == ".JPG" || Str_FileExt == ".GIF" || Str_FileExt == ".PNG" || Str_FileExt == ".BMP" || Str_FileExt == ".PNG")
                        {
                            dt3.Clear();
                            postfile4 = pstFile(FileUpd_logo3);
                            dr3 = dt3.NewRow();
                            dt3.Columns.Add("image3", Type.GetType("System.Byte[]"));
                            dr3["image3"] = postfile4;
                            dt3.Rows.Add(dr3);
                            Session["dt3"] = dt3;
                            string base64String = Convert.ToBase64String(postfile4);
                            Img_Emp3.ImageUrl = "data:image/png;base64," + base64String;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Upload Image File Only');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Image size should not Exceed 50kb');", true);
                        //img_upload.Attributes.Clear();
                        return;
                    }
                }
                if (FileUpd_logo4.HasFile && FileUpd_logo4.PostedFile != null)
                {
                    string Str_FileExt = System.IO.Path.GetExtension(FileUpd_logo4.FileName).ToUpper();
                    int filesize = FileUpd_logo4.PostedFile.ContentLength / 1024;
                    if (filesize < 50 && filesize != 0)
                    {
                        if (Str_FileExt == ".JPEG" || Str_FileExt == ".JPG" || Str_FileExt == ".GIF" || Str_FileExt == ".PNG" || Str_FileExt == ".BMP" || Str_FileExt == ".PNG")
                        {
                            dt4.Clear();
                            postfile5 = pstFile(FileUpd_logo4);
                            dr4 = dt4.NewRow();
                            dt4.Columns.Add("image4", Type.GetType("System.Byte[]"));
                            dr4["image4"] = postfile5;
                            dt4.Rows.Add(dr4);
                            Session["dt4"] = dt4;
                            string base64String = Convert.ToBase64String(postfile5);
                            Img_Emp4.ImageUrl = "data:image/png;base64," + base64String;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Upload Image File Only');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Image size should not Exceed 50kb');", true);
                        //img_upload.Attributes.Clear();
                        return;
                    }
                }
                if (FileUpd_logo5.HasFile && FileUpd_logo5.PostedFile != null)
                {
                    string Str_FileExt = System.IO.Path.GetExtension(FileUpd_logo5.FileName).ToUpper();
                    int filesize = FileUpd_logo5.PostedFile.ContentLength / 1024;
                    if (filesize < 50 && filesize != 0)
                    {
                        if (Str_FileExt == ".JPEG" || Str_FileExt == ".JPG" || Str_FileExt == ".GIF" || Str_FileExt == ".PNG" || Str_FileExt == ".BMP" || Str_FileExt == ".PNG")
                        {
                            dt4.Clear();
                            postfile5 = pstFile(FileUpd_logo5);
                            dr4 = dt4.NewRow();
                            dt4.Columns.Add("image4", Type.GetType("System.Byte[]"));
                            dr4["image4"] = postfile5;
                            dt4.Rows.Add(dr4);
                            Session["dt4"] = dt4;
                            string base64String = Convert.ToBase64String(postfile5);
                            Img_Emp4.ImageUrl = "data:image/png;base64," + base64String;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Upload Image File Only');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Image size should not Exceed 50kb');", true);
                        //img_upload.Attributes.Clear();
                        return;
                    }
                }

                DataTable obj_dt = new DataTable();
                DataTable obj_dt1 = new DataTable();
                DataTable obj_dt2 = new DataTable();
                DataTable obj_dt3 = new DataTable();
                DataTable obj_dt4 = new DataTable();
                if (Session["dt"] != null)
                {
                    obj_dt = (DataTable)Session["dt"];
                    if (obj_dt.Rows.Count > 0)
                    {
                        Img_Length = ((byte[])obj_dt.Rows[0][0]);
                    }
                }



                if (Session["dt1"] != null)
                {
                    obj_dt1 = (DataTable)Session["dt1"];
                    if (obj_dt1.Rows.Count > 0)
                    {
                        Img_Length1 = ((byte[])obj_dt1.Rows[0][0]);
                    }
                }

                if (Session["dt2"] != null)
                {
                    obj_dt2 = (DataTable)Session["dt2"];
                    if (obj_dt2.Rows.Count > 0)
                    {
                        Img_Length2 = ((byte[])obj_dt2.Rows[0][0]);
                    }
                }

                if (Session["dt3"] != null)
                {
                    obj_dt3 = (DataTable)Session["dt3"];
                    if (obj_dt3.Rows.Count > 0)
                    {
                        Img_Length3 = ((byte[])obj_dt3.Rows[0][0]);
                    }
                }

                if (Session["dt4"] != null)
                {
                    obj_dt4 = (DataTable)Session["dt4"];
                    if (obj_dt4.Rows.Count > 0)
                    {
                        Img_Length4 = ((byte[])obj_dt4.Rows[0][0]);
                    }
                }


                //DateTime empfrom = DateTime.ParseExact(txt_empfrom.Text, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                //DateTime empto = DateTime.ParseExact(txt_empto.Text, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (txt_creditamount.Text == "")
                {
                    txt_creditamount.Text = "0";
                }
                if (txt_creditday.Text == "")
                {
                    txt_creditamount.Text = "0";
                }
                if (txt_gstin.Text != "")
                {

                    //if(txtPanNo.Text=="")
                    //{
                    //    txtPanNo.Text = txt_gstin.Text.ToUpper().Substring(2, 10);
                    //}
                    if (txtGSTCode.Text == txt_gstin.Text.ToUpper().Substring(0, 2))
                    {
                        if (txtPanNo.Text.ToUpper() == txt_gstin.Text.ToUpper().Substring(2, 10))
                        {
                            if (ddl_Option.SelectedValue == "0")
                            {
                                ddl_Option.SelectedValue = "5";
                                Register = "Y";
                            }

                            if (btnSave.ToolTip == "Save")
                            {

                                //obj_MasterCustomer.SPInsMasterCustomerNew(txtcustomer.Text.ToUpper().Trim(), Type1, txtunit.Text, txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                                //int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                                //faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text.ToUpper(), txtPanNo.Text, txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                                //txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), txtfinptc.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register);
                                //cusobj.UpdTransinReqCus(custid);


                                string CustomerId = obj_MasterCustomer.SPInsMasterCustomerNewimageNews(txtcustomer.Text.ToUpper().Trim(), Type1, txtunit.Text, txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                                int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                                faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text.ToUpper(), txtPanNo.Text.ToUpper(), txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                                txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(Session["LoginEmpId"]),
                                txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(),
                                txtfinptc.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4,
                                txttanno.Text, txtcinno.Text, Convert.ToChar(SEZIgst));
                                //coload feb 9 20222
                                obj_MasterCustomer.SPUpdColoadDetails(Convert.ToInt32(CustomerId), Coload, txt_ColoadRemarks.Text, txt_Coloadercode.Text.ToUpper());

                                //  FEB2123 obj_MasterCustomer.Sp_UploadLimitDetails(Convert.ToDouble(txt_limit.Text), empfrom, empto, txt_certno.Text, Convert.ToInt32(CustomerId), Convert.ToDouble(txt_tds_exp.Text));
                                //end

                                //Elengo
                                //DataAccess.Masters.MasterCustomer da_obj_Customerobj = new DataAccess.Masters.MasterCustomer();
                                // CustomerId = "256";
                                //kALAI START SALESPERSON UPDATE QUERY
                                //da_obj_Customerobj.UpdSalesInMCustomer(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(int_Custid));
                                //new guided
                                if (txtcustomer.Text != "")
                                {
                                    da_obj_Customerobj.UpdSalesInMCustomer(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(CustomerId));
                                }
                                else
                                {
                                    da_obj_Customerobj.UpdSalesInMCustomer(0, Convert.ToInt32(hf_customerid.Value));
                                }
                                ////hf_customerid
                                savetds();
                                //obj_MasterCustomer.UPdEnvoice4cust(Convert.ToInt32(CustomerId), hid_einvoice.Value);
                                //if (txtpancust.Text != "" && txtPanNo.Text != "")
                                //{
                                //    DataTable dtcus = obj_MasterCustomer.Insmastercustpandtls(txtPanNo.Text.ToUpper(), txtpancust.Text, txttanno.Text, txtcinno.Text, txt_uinno.Text, Convert.ToInt32(hf_employeeid.Value));// yuvaraj 21/12/2022
                                //    if (dtcus.Rows.Count > 0)
                                //    {
                                //        hid_pan.Value = dtcus.Rows[0]["MasterCustomerPANid"].ToString();
                                //    }
                                //}
                                // add 
                                DataAccess.Masters.MasterCustomerGroup obj_mainx = new DataAccess.Masters.MasterCustomerGroup();
                                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                                obj_mainx.GetDataBase(Ccode);
                                DataTable dtss = new DataTable();
                                if (txtPanNo.Text != "" && txtpancust.Text != "")
                                {
                                    dtss = obj_mainx.customerpanidselect(txtPanNo.Text, txtpancust.Text);
                                    if (dtss.Rows.Count > 0)
                                    {
                                        hid_pan.Value = dtss.Rows[0]["CustomerPANId"].ToString();
                                        if (hid_pan.Value != "")
                                        {
                                            obj_mainx.customerpanidupdate(Convert.ToInt32(hid_pan.Value), txtpancust.Text);
                                        }
                                    }
                                }
                                // end 
                                if (txtPanNo.Text != "")
                                {
                                    if (hid_pan.Value != "")
                                    {
                                        obj_MasterCustomer.UPdEnvoice4cust(Convert.ToInt32(hid_pan.Value), hid_einvoice.Value);
                                        DataTable grid = obj_MasterCustomer.Getcustgridwithpan(txtPanNo.Text.ToUpper());
                                        if (grid.Rows.Count > 0)
                                        {
                                            grd.DataSource = grid;
                                            grd.DataBind();
                                        }
                                    }
                                }
                                else
                                {
                                    DataTable grid = obj_MasterCustomer.getcustgridwithcustomeragent(Convert.ToInt16(CustomerId), txtPanNo.Text.ToString());
                                    if (grid.Rows.Count > 0)
                                    {
                                        grd.DataSource = grid;
                                        grd.DataBind();
                                    }
                                }
                                string GSTData = txt_gstin.Text.ToUpper();
                                card.Text = txtcustomer.Text + " GST #  " + txt_gstin.Text;
                                if (CustomerId == "0")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Already Exist');", true);
                                    return;
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Inserted Successfully');", true);
                                    clear();
                                    ClearSlap();
                                }
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 1, int.Parse(Session["LoginBranchid"].ToString()), "CName" + txtcustomer.Text + "/Sav");


                                //dtCus = cusobj.getREQMasterCustomer();
                                //grd.DataSource = dtCus;
                                //grd.DataBind();


                                //obj_MasterCustomer.InsMasterCustomer(txtcustomer.Text.ToUpper(), "C", txtunit.Text, txtbuildingname.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country,
                                //    txtpincode.Text, llisd, txtllstd.Text, Convert.ToInt32(landline), mblisd, txtMobile.Text, faxisd, txtfaxstd.Text, int_fax, txtemail.Text, txtPanNo.Text, txtServiceTaxNo.Text, txtmailcom.Text, txtmailexport.Text, txtmailimp.Text, txtmailfin.Text, txtcomptc.Text,
                                //    txtexpptc.Text, txtimpptc.Text, txtfinptc.Text, Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text, txtmanagptc.Text, tds);
                                //location.UpdCityportInLocation(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_locationid.Value));
                                //obj_MasterCustomer.UpdPortFromCustomer(Convert.ToInt32(hf_districtid.Value), Convert.ToInt32(hf_stateid.Value), std, Convert.ToInt32(hf_portid.Value));
                                //obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 1, int.Parse(Session["LoginBranchid"].ToString()), "CName" + txtcustomer.Text + "/Sav");
                                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Inserted Successfully');", true);
                                //clear();
                                if (CustomerId != "0")
                                {
                                    DataTable dttem = obj_MasterCustomer.GetCustomerDetailsById(Convert.ToInt32(CustomerId));
                                    if (dttem.Rows.Count > 0)
                                    {
                                        lnkCustomer.Visible = true;
                                        hf_customerid.Value = dttem.Rows[0]["customerid"].ToString();
                                        txtcustomer.Text = dttem.Rows[0]["customername"].ToString();
                                        getdetails4pan();
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Something Went Wrong');", true);
                                    }
                                }
                                // yuvaraj 28/10/2022   group create

                                if (Type1 == "C" && ddlcategory.SelectedItem.Text != "Others")
                                {
                                    int locationid;
                                    DataAccess.Masters.MasterCustomerGroup obj_main = new DataAccess.Masters.MasterCustomerGroup();
                                    Ccode = HttpContext.Current.Session["Ccode"].ToString();
                                    obj_main.GetDataBase(Ccode);
                                    string data = string.Empty;
                                    dt = obj_main.GetAllGrouppan(txtPanNo.Text.ToUpper(), txtpancust.Text, "", 0);
                                    if (dt.Rows.Count > 0)
                                    {
                                        data = dt.Rows[0]["groupid"].ToString();
                                        groupid = Convert.ToInt32(dt.Rows[0]["groupid"].ToString());
                                    }

                                    if (groupid == 0)
                                    {
                                        if (hf_locationid.Value != "")
                                        {
                                            locationid = Convert.ToInt32(hf_locationid.Value);
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter correct location');", true);

                                            return;
                                        }
                                        string salesperson = txt_Salesperson.Text;// txt_Salesperson.Text.ToUpper(
                                        groupid = Convert.ToInt32(obj_main.InsertCustomerDetails(txtcustomer.Text.ToUpper(), salesperson, txtstreet.Text.ToUpper(), txtcity.Text.ToUpper(), txtpincode.Text, txtMobile.Text, txtfax.Text, txtemail.Text.ToUpper(), locationid));
                                        //obj_main.InsertCustomerDetails(txtname.Text, txt_person.Text, txtaddress.Text, txtcity.Text, txtzip.Text, txtphone.Text, txtfax.Text, txtEmail.Text, locationid);
                                        //if (custid == 0)
                                        //{
                                        //    custid = Convert.ToInt32(obj_MasterCustomer.GetCustomerid(txtcustomer.Text.ToUpper()).ToString());

                                        //}
                                        obj_main.UpdateCustomerGroupid(Convert.ToInt32(CustomerId), groupid, 1);

                                        obj_main.SpUpdateGroupidMasterPan(txtPanNo.Text.ToUpper(), txtpancust.Text, groupid);

                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 339, 1, int.Parse(Session["LoginBranchid"].ToString()), txtcustomer.Text + "/" + groupid);

                                        //// credit details
                                        //DataTable INDated = new DataTable();
                                        //int categoryval = 2;
                                        //string Gstdetails = GSTData;
                                        //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                                        ////string txt_DocReceived = "";
                                        ////string remarks = "";
                                        ////int clienttypeval = 1;
                                        ////string txt_AboutCust = "";
                                        ////double txt_revenue = 0.00;
                                        ////string txt_vol = "1";
                                        ////string vtype = "Teus";
                                        ////string datapo = "";
                                        //int Div_ID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                                        //DateTime now = DateTime.Now;
                                        //DateTime RegDtae = DateTime.Now;
                                        //DateTime INDate = DateTime.Now;
                                        //DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();
                                        //if (ddl_branch.SelectedValue == "Branch")
                                        //{
                                        //    ddl_branch.SelectedValue = "CORPORATE";
                                        //}
                                        //// ownerID = obj_emp.GetBranchId(Div_ID, Convert.ToString(ddl_branch.SelectedValue.ToString()));
                                        //int cridtype = 1;
                                        //ownerID = 2;
                                        //DataAccess.Masters.MasterCreditApproval obj_creditapp = new DataAccess.Masters.MasterCreditApproval();
                                        //DataTable dts = new DataTable();
                                        //dts = obj_creditapp.RetrieveCreditAppDts(groupid, Div_ID);
                                        //if (dt.Rows.Count > 0)
                                        //{
                                        //    return;
                                        //}
                                        //if (groupid == 0)
                                        //{
                                        //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Correct Customer name')", true);
                                        //    return;
                                        //}
                                        //if (groupid != 0)
                                        //{
                                        //    //  obj_creditapp.InsertMasterCreditApp(groupid, categoryval, txtPanNo.Text.ToUpper(), Gstdetails.ToUpper(), RegDtae, INDate, txt_DocReceived, datapo, txtlandline.Text, txtMobile.Text, txt_email.Text, clienttypeval, txt_vol, vtype, Convert.ToDouble(txt_revenue), txt_AboutCust, Convert.ToInt16(txt_creditday.Text.Trim()), Convert.ToDouble(txt_creditamount.Text.ToUpper().Trim()), cridtype, ownerID, Convert.ToInt32(hf_employeeid.Value.ToString()), remarks, Div_ID);
                                        //    //  Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 288, 1, Convert.ToInt32(Session["LoginBranchid"]), "groupid for " + groupid);
                                        //}
                                        //// credit Approval
                                        //int EmpId = Convert.ToInt32(Session["LoginEmpId"].ToString());
                                        //groupid = Convert.ToInt32(groupid.ToString());
                                        //string exmode = "";
                                        //if (ddl_per.Text == "Annual")
                                        //{
                                        //    exmode = "A";
                                        //}
                                        //else if (ddl_per.Text == "Month")
                                        //{
                                        //    exmode = "M";
                                        //}
                                        //else
                                        //{
                                        //    exmode = "M";
                                        //}
                                        //int apptype = 1;
                                        //int intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                                        //DataAccess.Masters.MasterCreditApproval Appro_obj = new DataAccess.Masters.MasterCreditApproval();
                                        //DateTime date = Convert.ToDateTime(now);
                                        //int exp = 3;
                                        //int due = 50;
                                        //string canno = "";
                                        ////if (btnSave.ToolTip == "Save")
                                        ////{
                                        //if (groupid != 0)
                                        //{
                                        //    canno = Appro_obj.UpdMasterCAppNew(groupid, canno, date, 0, 0, 0, ' ', 0, 0, 0, ' ', 0, 0, 0, ' ', EmpId, Convert.ToDouble(txt_creditamount.Text.Trim()), Convert.ToInt32(txt_creditday.Text.Trim()), apptype, Div_ID);
                                        //    Appro_obj.UpdMasterCreditApprovalCUSTLIMITS(groupid, intBranchID, Div_ID, exp, due, exmode);
                                        //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1731, 1, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + canno + "Limit :" + txt_exemptions.Text + "ExMode:" + ddl_per.Text + "Over Due:" + txt_overdue.Text + "%" + "/ S");
                                        //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 1, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + canno + "/ S");
                                        //}
                                        if (txtPanNo.Text != "")
                                        {
                                            PanSavetds();
                                        }
                                    }
                                    else
                                    {
                                        obj_main.UpdateCustomerGroupid(Convert.ToInt32(CustomerId), groupid, 1);
                                    }
                                }
                                // end 
                            }
                            else
                            {
                                //  (Trim(LTrim(RTrim(txtCustomer.Text))), type, Trim(LTrim(RTrim(txtUnit.Text))), Trim(LTrim(RTrim(txtBuilding.Text))), Trim(LTrim(RTrim(txtDoor.Text))), Trim(LTrim(RTrim(txtAddress.Text))), locationid, cityport, districtid, stateid, intcountry, Trim(LTrim(RTrim(txtZip.Text))), llisd, Trim(LTrim(RTrim(txtllstd.Text))), Trim(LTrim(RTrim(txtPhone.Text))), mblisd, Trim(LTrim(RTrim(txtmobile.Text))), faxisd, Trim(LTrim(RTrim(txtfaxstd.Text))), Trim(LTrim(RTrim(txtfax.Text))), Trim(LTrim(RTrim(txtemail.Text))), Trim(LTrim(RTrim(txtpano.Text))), Trim(LTrim(RTrim(txtsno.Text))), Trim(LTrim(RTrim(txtMailCommer.Text))), Trim(LTrim(RTrim(txtMailExp.Text))), Trim(LTrim(RTrim(txtMailImp.Text))), Trim(LTrim(RTrim(txtMailFinance.Text))), Trim(LTrim(RTrim(txtComPtc.Text))), Trim(LTrim(RTrim(txtExpPtc.Text))), Trim(LTrim(RTrim(txtImpPtc.Text))), Trim(LTrim(RTrim(txtFinPtc.Text))), intcustid, Trim(LTrim(RTrim(txtMailManag.Text))), Trim(LTrim(RTrim(txtPTC.Text))), tds, Trim(LTrim(RTrim(txtPTC.Text))))
                                if (hid_gstcode.Value == hf_stateid.Value || hid_gstcode.Value == "0")
                                {
                                    dt = (DataTable)Session["data"];
                                    if (dt.Rows.Count > 0)
                                    {
                                        hf_customerid.Value = dt.Rows[0]["customerid"].ToString();
                                    }

                                    if (hdn_oldgstcode.Value != "")
                                    {
                                        if (hdn_oldgstcode.Value != txtGSTCode.Text && (hf_countryid.Value == "1102" || hf_countryid.Value == "102"))
                                        {
                                            dtCheck = obj_MasterCustomer.checkvoucherraise(Convert.ToInt32(hf_customerid.Value));
                                            if (dtCheck.Rows.Count > 0)
                                            {
                                                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Voucher Raised For this customer So you Cannot change State ');", true);
                                                //return;
                                            }
                                        }
                                    }
                                    if (hf_customerid.Value != "")
                                    {
                                        obj_MasterCustomer.SPUpdMasterCustomerNewDesignimage(txtcustomer.Text.ToUpper(), Type1, txtunit.Text.ToUpper(), txtbuildingname.Text.ToUpper(),
                                            txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(), int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd,
                                            txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text, faxisd, txtfaxstd.Text.ToUpper(), txtfax.Text.ToUpper(),
                                            txtemail.Text.ToUpper(), txtPanNo.Text.ToUpper(), txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(),
                                            txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(), txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(),
                                            txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(hf_customerid.Value), txtmailmanag.Text.ToUpper(),
                                            txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txtfinptc.Text.ToUpper(), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(),
                                            RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4, txttanno.Text, txtcinno.Text, Convert.ToChar(SEZIgst));
                                        //obj_MasterCustomer.SPUpdMasterCustomerNewDesign(txtcustomer.Text.ToUpper(), Type1, txtunit.Text.ToUpper(), txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                                        //int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                                        //faxisd, txtfaxstd.Text.ToUpper(), txtfax.Text.ToUpper(), txtemail.Text.ToUpper(), txtPanNo.Text.ToUpper(), txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                                        //txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(hf_customerid.Value), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txtfinptc.Text.ToUpper(), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register);
                                        //obj_MasterCustomer.UpdMasterCustomerNew(txtcustomer.Text.ToUpper(), Type1, txtunit.Text, txtbuildingname.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country,
                                        //    txtpincode.Text, llisd, txtllstd.Text, Convert.ToInt32(landline), mblisd, txtMobile.Text, faxisd, txtfaxstd.Text, int_fax, txtemail.Text, txtPanNo.Text, txtServiceTaxNo.Text, txtmailcom.Text, txtmailexport.Text, txtmailimp.Text, txtmailfin.Text, txtcomptc.Text,
                                        //        txtexpptc.Text, txtimpptc.Text, txtfinptc.Text, int_customer, txtmailmanag.Text, txtmanagptc.Text, tds);
                                        //location.UpdCityportInLocation(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_locationid.Value));
                                        //obj_MasterCustomer.UpdPortFromCustomer(Convert.ToInt32(hf_districtid.Value), Convert.ToInt32(hf_stateid.Value), std, Convert.ToInt32(hf_portid.Value));

                                        //coload feb 9 20222
                                        obj_MasterCustomer.SPUpdColoadDetails(Convert.ToInt32(hf_customerid.Value), Coload, txt_ColoadRemarks.Text, txt_Coloadercode.Text.ToUpper());
                                        //end

                                        // hide by Feb2123 obj_MasterCustomer.Sp_UploadLimitDetails(Convert.ToDouble(txt_limit.Text), empfrom, empto, txt_certno.Text, Convert.ToInt32(hf_customerid.Value), Convert.ToDouble(txt_tds_exp.Text));
                                        //Elengo
                                        // hide by Feb2123  savetds();
                                      //  DataAccess.Masters.MasterCustomer da_obj_Customerobj = new DataAccess.Masters.MasterCustomer();

                                        if (txtcustomer.Text != "")
                                        {
                                            da_obj_Customerobj.UpdSalesInMCustomer(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_customerid.Value));
                                        }
                                        else
                                        {
                                            da_obj_Customerobj.UpdSalesInMCustomer(0, Convert.ToInt32(hf_customerid.Value));

                                        }
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 2, int.Parse(Session["LoginBranchid"].ToString()), "CName" + txtcustomer.Text + "/upd");
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Updated Successfully');", true);
                                        lstlocation.Visible = false;
                                        //if (txtPanNo.Text != "" && txtpancust.Text != "")
                                        //{
                                        //    DataTable dtcus = obj_MasterCustomer.Insmastercustpandtls(txtPanNo.Text.ToUpper(), txtpancust.Text, txttanno.Text, txtcinno.Text, txt_uinno.Text, Convert.ToInt32(hf_employeeid.Value));// yuvaraj 21/12/2022

                                        //    if (dtcus.Rows.Count > 0)
                                        //    {
                                        //        hid_pan.Value = dtcus.Rows[0]["MasterCustomerPANid"].ToString();
                                        //    }
                                        //}
                                      //  DataAccess.Masters.MasterCustomerGroup obj_mainx = new DataAccess.Masters.MasterCustomerGroup();
                                        DataTable dtss = new DataTable();
                                        if (txtPanNo.Text != "" && txtpancust.Text != "")
                                        {
                                            dtss = obj_mainx.customerpanidselect(txtPanNo.Text, txtpancust.Text);
                                            if (dtss.Rows.Count > 0)
                                            {
                                                hid_pan.Value = dtss.Rows[0]["CustomerPANId"].ToString();
                                                if (hid_pan.Value != "")
                                                {
                                                    obj_mainx.customerpanidupdate(Convert.ToInt32(hid_pan.Value), txtpancust.Text);
                                                }
                                            }
                                        }
                                        if (txtPanNo.Text != "")
                                        {
                                            if (hid_pan.Value != "")
                                            {
                                                obj_MasterCustomer.UPdEnvoice4cust(Convert.ToInt32(hid_pan.Value), hid_einvoice.Value);
                                                DataTable grid = obj_MasterCustomer.Getcustgridwithpan(txtPanNo.Text.ToUpper());
                                                if (grid.Rows.Count > 0)
                                                {
                                                    grd.DataSource = grid;
                                                    grd.DataBind();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            DataTable grid = obj_MasterCustomer.getcustgridwithcustomeragent(Convert.ToInt16(hf_customerid.Value), txtPanNo.Text.ToString());
                                            if (grid.Rows.Count > 0)
                                            {
                                                grd.DataSource = grid;
                                                grd.DataBind();
                                            }
                                        }

                                        // btnSave.Text = "Update";
                                        //string exmodes;
                                        //if (ddl_per.Text == "Annual")
                                        //{
                                        //    exmodes = "A";
                                        //}
                                        //else if (ddl_per.Text == "Month")
                                        //{
                                        //    exmodes = "M";
                                        //}
                                        //else
                                        //{
                                        //    exmodes = "M";
                                        //}
                                        //DataAccess.Masters.MasterCustomerGroup obj_main = new DataAccess.Masters.MasterCustomerGroup();
                                        //dt = obj_main.GetAllGrouppan(txtPanNo.Text.ToUpper(), txtpancust.Text, "", 0);
                                        //string data;
                                        //if (dt.Rows.Count > 0)
                                        //{
                                        //    data = dt.Rows[0]["groupid"].ToString();
                                        //    groupids = Convert.ToInt32(dt.Rows[0]["groupid"].ToString());
                                        //}
                                        //DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();
                                        //int Div_ID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                                        ////ownerID = obj_emp.GetBranchId(Div_ID, Convert.ToString(ddl_branch.SelectedValue.ToString()));
                                        //int intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                                        //DataAccess.Masters.MasterCreditApproval obj = new DataAccess.Masters.MasterCreditApproval();
                                        //ownerID = 2;
                                        //string Hiddata = ownerID.ToString();
                                        ////obj.mastercustomercreditrequest(Convert.ToDouble(txt_creditamount.Text.Trim()), Convert.ToInt32(txt_creditday.Text.Trim()), Convert.ToInt32(txt_exemptions.Text), Convert.ToInt32(txt_overdue.Text), exmodes, txtPanNo.Text.ToUpper(), txtpancust.Text.ToUpper(), Div_ID, Convert.ToInt32(intBranchID), Convert.ToInt32(groupids), ownerID, Hiddata);
                                        if (txtPanNo.Text != "")
                                        {
                                            PanSavetds();
                                        }

                                        btnSave.ToolTip = "Update";
                                        btnSave1.Attributes["class"] = "btn ico-update";
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('You cannot update to one state to another state.so you have create difference customer');", true);
                                }
                            }
                            eventdocs = txtcustomer.Text + "" + Type1 + "" + txtunit.Text + "" + txtbuildingname.Text + "" + txtdoor.Text + "" + txtstreet.Text + "" + txtpincode.Text + "" + txtllstd.Text + "" + "" + txtMobile.Text + "" + txtfaxstd.Text + "" + txtfax.Text + "" + txtemail.Text + "" + txtPanNo.Text + "" + txtServiceTaxNo.Text + "" + txtmailcom.Text + "" + txtmailexport.Text + "" + txtmailimp.Text + "" + txtmailfin.Text + "" + txtcomptc.Text + "" + txtexpptc.Text + "" + txtimpptc.Text + "" + txtfinptc.Text + "" + txtmailmanag.Text + "" + txtmanagptc.Text + txtfinptc.Text + "" + txt_gstin.Text + "" + txt_uinno.Text;
                            if (hf_customerid.Value != "")
                            {
                                obj_MasterCustomer.Insertupdloggst(Convert.ToInt32(hf_customerid.Value), eventdocs, Convert.ToInt32(Session["LoginEmpId"]), today);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('GSTIN # - PAN# and Customer PAN# is Not Match');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('GSTIN # - State Code and Customer State GST Code is Not Match');", true);
                        txt_gstin.Text = "";
                    }

                    //}
                }
                else
                {
                    if (ddlCType.SelectedValue == "C")
                    {
                        //if (txtPanNo.Text == "" && ddl_Option.SelectedItem.Text != "UnRegistered")
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter The Panno (OR) Select UnRegistered ');", true);
                        //    txtPanNo.Focus();
                        //    return;
                        //}
                    }
                    if (btnSave.ToolTip == "Save")
                    {

                        //obj_MasterCustomer.SPInsMasterCustomerNew(txtcustomer.Text.ToUpper(), Type1, txtunit.Text, txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                        //int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                        //faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text.ToUpper(), txtPanNo.Text, txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                        //txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), txtfinptc.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register);

                        string CustomerId = obj_MasterCustomer.SPInsMasterCustomerNewimageNews(txtcustomer.Text.ToUpper(), Type1, txtunit.Text, txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                       int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                       faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text.ToUpper(), txtPanNo.Text.ToUpper(), txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                       txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(Session["LoginEmpId"]),
                       txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(),
                       txtfinptc.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4,

                       txttanno.Text, txtcinno.Text, Convert.ToChar(SEZIgst));
                        //coload feb 9 20222
                        obj_MasterCustomer.SPUpdColoadDetails(Convert.ToInt32(CustomerId), Coload, txt_ColoadRemarks.Text, txt_Coloadercode.Text.ToUpper());
                        //end
                        // hide by yuvaraj FEB2123   obj_MasterCustomer.Sp_UploadLimitDetails(Convert.ToDouble(txt_limit.Text), empfrom, empto, txt_certno.Text, Convert.ToInt32(CustomerId), Convert.ToDouble(txt_tds_exp.Text));
                        //Elengo
                        // hide by yuvaraj FEB2123   savetds();
                        // obj_MasterCustomer.UPdEnvoice4cust(Convert.ToInt32(CustomerId), hid_einvoice.Value);
                        cusobj.UpdTransinReqCus(custid);



                        //Elengo start
                      //  DataAccess.Masters.MasterCustomer da_obj_Customerobj = new DataAccess.Masters.MasterCustomer();
                        // CustomerId = "256";
                        //kALAI START SALESPERSON UPDATE QUERY
                        //da_obj_Customerobj.UpdSalesInMCustomer(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(int_Custid));
                        //new guided
                        if (txtcustomer.Text != "")
                        {
                            da_obj_Customerobj.UpdSalesInMCustomer(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(CustomerId));
                        }
                        else
                        {
                            da_obj_Customerobj.UpdSalesInMCustomer(0, Convert.ToInt32(hf_customerid.Value));

                        }
                        ////hf_customerid


                        savetds();
                        //obj_MasterCustomer.UPdEnvoice4cust(Convert.ToInt32(CustomerId), hid_einvoice.Value);
                        //if (txtpancust.Text != "" && txtPanNo.Text != "")
                        //{
                        //    DataTable dtcus = obj_MasterCustomer.Insmastercustpandtls(txtPanNo.Text.ToUpper(), txtpancust.Text, txttanno.Text, txtcinno.Text, txt_uinno.Text, Convert.ToInt32(hf_employeeid.Value)); // add yuvaraj 21/12/2022
                        //    if (dtcus.Rows.Count > 0)
                        //    {
                        //        hid_pan.Value = dtcus.Rows[0]["MasterCustomerPANid"].ToString();
                        //    }
                        //}
                       // DataAccess.Masters.MasterCustomerGroup obj_mainx = new DataAccess.Masters.MasterCustomerGroup();
                        DataTable dtss = new DataTable();
                        if (txtPanNo.Text != "" && txtpancust.Text != "")
                        {
                            dtss = obj_mainx.customerpanidselect(txtPanNo.Text, txtpancust.Text);
                            if (dtss.Rows.Count > 0)
                            {
                                hid_pan.Value = dtss.Rows[0]["CustomerPANId"].ToString();
                                if (hid_pan.Value != "")
                                {
                                    obj_mainx.customerpanidupdate(Convert.ToInt32(hid_pan.Value), txtpancust.Text);
                                }
                            }
                        }
                        if (txtPanNo.Text != "")
                        {
                            if (hid_pan.Value != "")
                            {
                                obj_MasterCustomer.UPdEnvoice4cust(Convert.ToInt32(hid_pan.Value), hid_einvoice.Value);
                                DataTable grid = obj_MasterCustomer.Getcustgridwithpan(txtPanNo.Text.ToUpper());
                                if (grid.Rows.Count > 0)
                                {
                                    grd.DataSource = grid;
                                    grd.DataBind();
                                }
                            }

                        }
                        else
                        {
                            DataTable grid = obj_MasterCustomer.getcustgridwithcustomeragent(Convert.ToInt16(CustomerId), txtPanNo.Text.ToString());
                            if (grid.Rows.Count > 0)
                            {
                                grd.DataSource = grid;
                                grd.DataBind();
                            }
                        }
                        // end yuvaraj
                        if (txtPanNo.Text != "")
                        {
                            PanSavetds();
                        }

                        string GSTData = txt_gstin.Text.ToUpper();
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 1, int.Parse(Session["LoginBranchid"].ToString()), "CName" + txtcustomer.Text + "/Sav");
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Inserted Successfully');", true);
                        if (CustomerId == "0")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Already Exist');", true);
                            return;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Inserted Successfully');", true);
                        }
                        //dtCus = cusobj.getREQMasterCustomer();
                        //grd.DataSource = dtCus;
                        //grd.DataBind();
                        clear();
                        ClearSlap();
                        //obj_MasterCustomer.InsMasterCustomer(txtcustomer.Text.ToUpper(), "C", txtunit.Text, txtbuildingname.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country,
                        //    txtpincode.Text, llisd, txtllstd.Text, Convert.ToInt32(landline), mblisd, txtMobile.Text, faxisd, txtfaxstd.Text, int_fax, txtemail.Text, txtPanNo.Text, txtServiceTaxNo.Text, txtmailcom.Text, txtmailexport.Text, txtmailimp.Text, txtmailfin.Text, txtcomptc.Text,
                        //    txtexpptc.Text, txtimpptc.Text, txtfinptc.Text, Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text, txtmanagptc.Text, tds);
                        //location.UpdCityportInLocation(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_locationid.Value));
                        //obj_MasterCustomer.UpdPortFromCustomer(Convert.ToInt32(hf_districtid.Value), Convert.ToInt32(hf_stateid.Value), std, Convert.ToInt32(hf_portid.Value));
                        //obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 1, int.Parse(Session["LoginBranchid"].ToString()), "CName" + txtcustomer.Text + "/Sav");
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Inserted Successfully');", true);
                        //clear();

                        if (CustomerId != "0")
                        {
                            DataTable dttem1 = obj_MasterCustomer.GetCustomerDetailsById(Convert.ToInt32(CustomerId));
                            if (dttem1.Rows.Count > 0)
                            {
                                lnkCustomer.Visible = true;
                                hf_customerid.Value = dttem1.Rows[0]["customerid"].ToString();
                                txtcustomer.Text = dttem1.Rows[0]["customername"].ToString();
                                getdetails();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Something Went Wrong');", true);
                            }
                        }

                        if (Type1 == "C" && ddlcategory.SelectedItem.Text != "Others")
                        {
                            // yuvaraj 20/09/2022
                            int locationid;
                             DataAccess.Masters.MasterCustomerGroup obj_main = new DataAccess.Masters.MasterCustomerGroup();
                            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                            obj_main.GetDataBase(Ccode);
                            string data = string.Empty;
                            dt = obj_main.GetAllGrouppan(txtPanNo.Text.ToUpper(), txtpancust.Text, "", 0);
                            if (dt.Rows.Count > 0)
                            {
                                data = dt.Rows[0]["groupid"].ToString();
                                groupid = Convert.ToInt32(dt.Rows[0]["groupid"].ToString());
                            }

                            if (groupid == 0)
                            {
                                if (hf_locationid.Value != "")
                                {
                                    locationid = Convert.ToInt32(hf_locationid.Value);
                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter correct location');", true);

                                    return;
                                }
                                string salesperson = txt_Salesperson.Text;// txt_Salesperson.Text.ToUpper(
                                groupid = Convert.ToInt32(obj_main.InsertCustomerDetails(txtcustomer.Text.ToUpper(), salesperson, txtstreet.Text.ToUpper(), txtcity.Text.ToUpper(), txtpincode.Text, txtMobile.Text, txtfax.Text, txtemail.Text.ToUpper(), locationid));
                                //obj_main.InsertCustomerDetails(txtname.Text, txt_person.Text, txtaddress.Text, txtcity.Text, txtzip.Text, txtphone.Text, txtfax.Text, txtEmail.Text, locationid);
                                //if (custid == 0)
                                //{
                                //    custid = Convert.ToInt32(obj_MasterCustomer.GetCustomerid(txtcustomer.Text.ToUpper()).ToString());

                                //}
                                obj_main.UpdateCustomerGroupid(Convert.ToInt32(CustomerId), groupid, 1);

                                obj_main.SpUpdateGroupidMasterPan(txtPanNo.Text.ToUpper(), txtpancust.Text, groupid);

                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 339, 1, int.Parse(Session["LoginBranchid"].ToString()), txtcustomer.Text + "/" + groupid);
                                // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert(' Customer Group created');", true);
                                //ScriptManager.RegisterStartupScript(btn_custgroup, typeof(System.Web.UI.WebControls.Button), "MasterExchangeRate", "alertify.alert(' Customer Group created');", true);
                                // clear();
                                ////Fn_Clear();
                                ////clear12();
                                ////kycclear();
                                //Clear();

                                // credit details

                                //DateTime RegDtaed = new DateTime();
                                //DataTable INDated = new DataTable();
                                //int categoryval = 2;
                                //string Gstdetails = GSTData;
                                //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                                //string txt_DocReceived = "";
                                //string remarks = "";
                                //int clienttypeval = 1;
                                //string txt_AboutCust = "";
                                //double txt_revenue = 0.00;
                                //string txt_vol = "1";
                                //string vtype = "Teus";
                                //string datapo = "";
                                //string str_usermailid = Session["usermailid"].ToString();
                                //string str_mailpwd = Session["usermailpwd"].ToString();
                                //string strDate, strDate1;

                                //int Div_ID = Convert.ToInt32(Session["LoginDivisionId"].ToString());

                                //DateTime now = DateTime.Now;
                                //DateTime RegDtae = DateTime.Now;
                                //DateTime INDate = DateTime.Now;
                                //DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();
                                //ownerID = 2;
                                //int cridtype = 1;
                                ////if (btnSave.ToolTip == "Update")
                                ////{
                                //DataAccess.Masters.MasterCreditApproval obj_creditapp = new DataAccess.Masters.MasterCreditApproval();
                                //DataTable dts = new DataTable();
                                //dts = obj_creditapp.RetrieveCreditAppDts(groupid, Div_ID);
                                //if (dt.Rows.Count > 0)
                                //{
                                //    return;
                                //}
                                //if (groupid == 0)
                                //{
                                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Correct Customer name')", true);
                                //    return;
                                //}
                                //if (groupid != 0)
                                //{
                                //    obj_creditapp.InsertMasterCreditApp(groupid, categoryval, txtPanNo.Text.ToUpper(), Gstdetails.ToUpper(), RegDtae, INDate, txt_DocReceived, datapo, txtlandline.Text, txtMobile.Text, txt_email.Text, clienttypeval, txt_vol, vtype, Convert.ToDouble(txt_revenue), txt_AboutCust, Convert.ToInt16(txt_creditday.Text.Trim()), Convert.ToDouble(txt_creditamount.Text.ToUpper().Trim()), cridtype, ownerID, Convert.ToInt32(hf_employeeid.Value.ToString()), remarks, Div_ID);
                                //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 288, 1, Convert.ToInt32(Session["LoginBranchid"]), "groupid for " + groupid);
                                //    //   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Details Saved')", true);
                                //    //btnSave.Text = "Update";
                                //    //btnSave.ToolTip = "Update";
                                //}                              
                                ////credit end 
                                //// credit Approval
                                //int EmpId = Convert.ToInt32(Session["LoginEmpId"].ToString());
                                //groupid = Convert.ToInt32(groupid.ToString());
                                //string exmode = "";
                                //if (ddl_per.Text == "Annual")
                                //{
                                //    exmode = "A";
                                //}
                                //else if (ddl_per.Text == "Month")
                                //{
                                //    exmode = "M";
                                //}
                                //else
                                //{
                                //    exmode = "M";
                                //}
                                //int apptype = 1;
                                //int intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                                //DataAccess.Masters.MasterCreditApproval Appro_obj = new DataAccess.Masters.MasterCreditApproval();                      
                                //DateTime date = Convert.ToDateTime(now);
                                //int exp = 3;
                                //int due = 50;
                                //string canno = "";                        
                                //if (groupid != 0)
                                //{
                                //    canno = Appro_obj.UpdMasterCAppNew(groupid, canno, date, 0, 0, 0, ' ', 0, 0, 0, ' ', 0, 0, 0, ' ', EmpId, Convert.ToDouble(txt_creditamount.Text.Trim()), Convert.ToInt32(txt_creditday.Text.Trim()), apptype, Div_ID);
                                //    Appro_obj.UpdMasterCreditApprovalCUSTLIMITS(groupid, intBranchID, Div_ID, exp, due, exmode);
                                //    // ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Credit Approval :" + txt_cano.Text + " is Inserted');", true);

                                //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1731, 1, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + canno + "Limit :" + txt_exemptions.Text + "ExMode:" + ddl_per.Text + "Over Due:" + txt_overdue.Text + "%" + "/ S");
                                //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 1, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + canno + "/ S");
                                //}  
                            }
                            else
                            {
                                obj_main.UpdateCustomerGroupid(Convert.ToInt32(CustomerId), groupid, 1);
                            }
                        }
                        GSTData = "";
                        // end 
                        btnSave.Enabled = true;
                        btnSave.ToolTip = "Update";
                        btnSave1.Attributes["class"] = "btn ico-update";
                        btnBack.ToolTip = "Clear";
                        btnBack1.Attributes["class"] = "btn ico-clear";
                    }
                    else
                    {
                        //  (Trim(LTrim(RTrim(txtCustomer.Text))), type, Trim(LTrim(RTrim(txtUnit.Text))), Trim(LTrim(RTrim(txtBuilding.Text))), Trim(LTrim(RTrim(txtDoor.Text))), Trim(LTrim(RTrim(txtAddress.Text))), locationid, cityport, districtid, stateid, intcountry, Trim(LTrim(RTrim(txtZip.Text))), llisd, Trim(LTrim(RTrim(txtllstd.Text))), Trim(LTrim(RTrim(txtPhone.Text))), mblisd, Trim(LTrim(RTrim(txtmobile.Text))), faxisd, Trim(LTrim(RTrim(txtfaxstd.Text))), Trim(LTrim(RTrim(txtfax.Text))), Trim(LTrim(RTrim(txtemail.Text))), Trim(LTrim(RTrim(txtpano.Text))), Trim(LTrim(RTrim(txtsno.Text))), Trim(LTrim(RTrim(txtMailCommer.Text))), Trim(LTrim(RTrim(txtMailExp.Text))), Trim(LTrim(RTrim(txtMailImp.Text))), Trim(LTrim(RTrim(txtMailFinance.Text))), Trim(LTrim(RTrim(txtComPtc.Text))), Trim(LTrim(RTrim(txtExpPtc.Text))), Trim(LTrim(RTrim(txtImpPtc.Text))), Trim(LTrim(RTrim(txtFinPtc.Text))), intcustid, Trim(LTrim(RTrim(txtMailManag.Text))), Trim(LTrim(RTrim(txtPTC.Text))), tds, Trim(LTrim(RTrim(txtPTC.Text))))
                        //if (hid_gstcode.Value == hf_stateid.Value || hid_gstcode.Value == "0")
                        //{
                        dt = (DataTable)Session["data"];
                        if (dt.Rows.Count > 0)
                        {
                            hf_customerid.Value = dt.Rows[0]["customerid"].ToString();
                        }

                        if (hdn_oldgstcode.Value != "")
                        {
                            if (hdn_oldgstcode.Value != txtGSTCode.Text && (hf_countryid.Value == "1102" || hf_countryid.Value == "102"))
                            {
                                dtCheck = obj_MasterCustomer.checkvoucherraise(Convert.ToInt32(hf_customerid.Value));
                                if (dtCheck.Rows.Count > 0)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Voucher Raised For this customer So you Cannot change State ');", true);
                                    return;
                                }
                            }
                        }
                        if (hf_customerid.Value != "")
                        {
                            obj_MasterCustomer.SPUpdMasterCustomerNewDesignimage(txtcustomer.Text.ToUpper(), Type1, txtunit.Text.ToUpper(), txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                                int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                                faxisd, txtfaxstd.Text.ToUpper(), txtfax.Text.ToUpper(), txtemail.Text.ToUpper(), txtPanNo.Text.ToUpper(), txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                                txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(hf_customerid.Value),
                                txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txtfinptc.Text.ToUpper(), txt_gstin.Text.ToUpper(),
                                txt_uinno.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4,
                                txttanno.Text, txtcinno.Text, Convert.ToChar(SEZIgst));

                            //coload feb 9 20222
                            obj_MasterCustomer.SPUpdColoadDetails(Convert.ToInt32(hf_customerid.Value), Coload, txt_ColoadRemarks.Text, txt_Coloadercode.Text.ToUpper());
                            //end
                            // hide by Feb2123 obj_MasterCustomer.Sp_UploadLimitDetails(Convert.ToDouble(txt_limit.Text), empfrom, empto, txt_certno.Text, Convert.ToInt32(hf_customerid.Value), Convert.ToDouble(txt_tds_exp.Text));
                            //Elengo
                            //hide by Feb2123  savetds();
                            // obj_MasterCustomer.UPdEnvoice4cust(Convert.ToInt32(hf_customerid.Value), hid_einvoice.Value);
                            //obj_MasterCustomer.SPUpdMasterCustomerNewDesign(txtcustomer.Text.ToUpper(), Type1, txtunit.Text.ToUpper(), txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                            //    int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                            //    faxisd, txtfaxstd.Text.ToUpper(), txtfax.Text.ToUpper(), txtemail.Text.ToUpper(), txtPanNo.Text.ToUpper(), txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                            //    txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(hf_customerid.Value), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txtfinptc.Text.ToUpper(), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register);
                            //obj_MasterCustomer.UpdMasterCustomerNew(txtcustomer.Text.ToUpper(), Type1, txtunit.Text, txtbuildingname.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country,
                            //    txtpincode.Text, llisd, txtllstd.Text, Convert.ToInt32(landline), mblisd, txtMobile.Text, faxisd, txtfaxstd.Text, int_fax, txtemail.Text, txtPanNo.Text, txtServiceTaxNo.Text, txtmailcom.Text, txtmailexport.Text, txtmailimp.Text, txtmailfin.Text, txtcomptc.Text,
                            //        txtexpptc.Text, txtimpptc.Text, txtfinptc.Text, int_customer, txtmailmanag.Text, txtmanagptc.Text, tds);
                            //location.UpdCityportInLocation(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_locationid.Value));
                            //obj_MasterCustomer.UpdPortFromCustomer(Convert.ToInt32(hf_districtid.Value), Convert.ToInt32(hf_stateid.Value), std, Convert.ToInt32(hf_portid.Value));
                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 2, int.Parse(Session["LoginBranchid"].ToString()), "CName" + txtcustomer.Text + "/upd");
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Updated Successfully');", true);
                            lstlocation.Visible = false;
                            //  btnSave.Text = "Update";
                            if (txtPanNo.Text != "")
                            {
                                PanSavetds();
                            }

                           // DataAccess.Masters.MasterCustomerGroup obj_mainx = new DataAccess.Masters.MasterCustomerGroup();
                            DataTable dtss = new DataTable();
                            if (txtPanNo.Text != "" && txtpancust.Text != "")
                            {
                                dtss = obj_mainx.customerpanidselect(txtPanNo.Text, txtpancust.Text);
                                if (dtss.Rows.Count > 0)
                                {
                                    hid_pan.Value = dtss.Rows[0]["CustomerPANId"].ToString();
                                    if (hid_pan.Value != "")
                                    {
                                        obj_mainx.customerpanidupdate(Convert.ToInt32(hid_pan.Value), txtpancust.Text);
                                    }
                                }
                            }
                            // btnSave.Text = "Update";
                            //string exmodes;
                            //if (ddl_per.Text == "Annual")
                            //{
                            //    exmodes = "A";
                            //}
                            //else if (ddl_per.Text == "Month")
                            //{
                            //    exmodes = "M";
                            //}
                            //else
                            //{
                            //    exmodes = "M";
                            //}
                            //DataAccess.Masters.MasterCustomerGroup obj_main = new DataAccess.Masters.MasterCustomerGroup();
                            //dt = obj_main.GetAllGrouppan(txtPanNo.Text.ToUpper(), txtpancust.Text, "", 0);
                            //string data;
                            //if (dt.Rows.Count > 0)
                            //{
                            //    data = dt.Rows[0]["groupid"].ToString();
                            //    groupids = Convert.ToInt32(dt.Rows[0]["groupid"].ToString());
                            //}
                            //DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();
                            //int Div_ID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                            ////ownerID = obj_emp.GetBranchId(Div_ID, Convert.ToString(ddl_branch.SelectedValue.ToString()));
                            //int intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                            //DataAccess.Masters.MasterCreditApproval obj = new DataAccess.Masters.MasterCreditApproval();
                            //ownerID = 2;
                            //string hiddata = ownerID.ToString();
                            ////obj.mastercustomercreditrequest(Convert.ToDouble(txt_creditamount.Text.Trim()), Convert.ToInt32(txt_creditday.Text.Trim()), Convert.ToInt32(txt_exemptions.Text), Convert.ToInt32(txt_overdue.Text), exmodes, txtPanNo.Text.ToUpper(), txtpancust.Text.ToUpper(), Div_ID, intBranchID, Convert.ToInt16(groupids), ownerID, hiddata);

                            btnSave.ToolTip = "Update";
                            btnSave1.Attributes["class"] = "btn ico-update";
                            clear();
                            ClearSlap();
                        }
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('You cannot update to one state to another state.so you have create difference customer');", true);
                        //}
                    }
                    eventdocs1 = txtcustomer.Text + " " + Type1 + " " + txtunit.Text + " " + txtbuildingname.Text + " " + txtdoor.Text + " " + txtstreet.Text + " " + txtpincode.Text + " " + txtllstd.Text + " " + " " + txtMobile.Text + " " + txtfaxstd.Text + " " + txtfax.Text + " " + txtemail.Text + " " + txtPanNo.Text + " " + txtServiceTaxNo.Text + " " + txtmailcom.Text + " " + txtmailexport.Text + " " + txtmailimp.Text + "" + txtmailfin.Text + "" + txtcomptc.Text + "" + txtexpptc.Text + " " + txtimpptc.Text + " " + txtfinptc.Text + " " + txtmailmanag.Text + " " + txtmanagptc.Text + txtfinptc.Text + " " + txt_gstin.Text + " " + txt_uinno.Text;
                    if (hf_customerid.Value != "")
                    {
                        obj_MasterCustomer.Insertupdloggst(Convert.ToInt32(hf_customerid.Value), eventdocs1, Convert.ToInt32(Session["LoginEmpId"]), today);
                    }
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter The Panno ');", true);
                    //    txtPanNo.Focus();
                    //    return;
                    //}
                }
                if (ddlcategory.SelectedItem.Text == "Agent")
                {
                    //creditdetailsEnable();
                    btncredit.Enabled = false;
                    btntds.Enabled = false;
                }
                else if (ddlcategory.SelectedItem.Text == "Others")
                {
                    // creditdetailsEnable();
                    btncredit.Enabled = false;
                    btntds.Enabled = false;
                }
                else
                {
                    //if (grd.Rows.Count > 0)
                    //{
                    ddlProductType.Enabled = true;
                    txt_vol.Enabled = true;
                    ddlvolumetype.Enabled = true;
                    txt_revenue.Enabled = true;
                    txt_creditdays.Enabled = true;
                    txt_creditamount.Enabled = true;
                    txt_exemptions.Enabled = true;
                    txt_overdue.Enabled = true;
                    ddl_per.Enabled = true;
                    txtCreditAboveamt.Enabled = true;
                    btnCreditRequestAdd.Enabled = true;
                    // }
                    btncredit.Enabled = true;
                    btntds.Enabled = true;
                    ddlProductType.Focus();
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Add & Update Successfully, Please Fill the Credit Details ');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                //if (btnBack.ToolTip == "Back")
                //{
                //    clear();
                //    ClearSlap();
                //    grd.DataSource = null;
                //    grd.DataBind();
                //    this.Response.End();
                //}
                //else
                //{
                clear();
                //txt_empfrom.Text = "";
                //txt_empto.Text = "";
                //txt_certno.Text = "";
                //txt_tds_exp.Text = "";
                //txt_limit.Text = "";
                //  ClearSlap();
                //grd.DataSource = null;
                //grd.DataBind();
                //  customermrcode();
                ddlCType.Enabled = true;
                //txtcustomer.Focus();
                ddl_Option.SelectedValue = "0";
                txt_gstin.Focus();
                btn_Upload.ToolTip = "Add";

                ddlProductType.SelectedValue = "0";
                txt_vol.Text = "";
                ddlvolumetype.SelectedValue = "0";
                ddllegaltype.SelectedValue = "0";
                txt_revenue.Text = "";
                txt_creditdays.Text = "";
                txtCreditAboveamt.Text = "";
                btnCreditRequestAdd.ToolTip = "ADD";
                btn_add1.Attributes["class"] = "btn btn-add1 MCtrl MT10";
                // btnpancancel_Click(sender, e);
                GridView1.DataSource = Utility.Fn_GetEmptyDataTable();
                GridView1.DataBind();
                card.Text = "";
                //  btnBack.Text = "Back";
                //}
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtcustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //ddl_Option.SelectedValue = "0";
                if (txtcustomer.Text != "" && hf_customerid.Value != "" && hf_customerid.Value != "0")
                {
                    //getdetails4pan();
                    // GetCustxmlstatus();
                    Getcustomerdetails();
                    // btnSave.Text = "Update";
                    //txtcustomer.Text = "";
                    //txtcustomer.Focus();
                    txt_gstin.Focus();
                    DataTable grid = obj_MasterCustomer.getcustgridwithcustomeragent(Convert.ToInt16(hf_customerid.Value), txtPanNo.Text.ToString());
                    if (grid.Rows.Count > 0)
                    {
                        grd.DataSource = grid;
                        grd.DataBind();
                    }
                    ddl_Option.Enabled = true;
                }
                else if (txtcustomer.Text == "")
                {
                    kycGrid();
                    // Banking();
                    DataTable dts = new DataTable();
                    //dt = obj_MasterCustomer.get_Gridviewnewone(Convert.ToInt32(hf_customerid.Value));
                    if (txtPanNo.Text == "" && txtpancust.Text == "")
                    {
                        if (hf_customerid.Value != "")
                        {
                            dts = obj_MasterCustomer.SP_getbankdetailsAgent(Convert.ToInt32(hf_customerid.Value), txtcustomer.Text);
                            if (dts.Rows.Count > 0)
                            {
                                GridView1.DataSource = dts;
                                GridView1.DataBind();
                            }
                        }
                    }
                    //getdetails4pan();
                    Getcustomerdetails();
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('please enter the customername');", true);
                }
                else if (hf_customerid.Value == "" || hf_customerid.Value == "0")
                {

                    txtunit.Focus();
                    return;
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Invalid Customer Name');", true);
                    txtcustomer.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void getdetails()
        {
            //DataTable dtnew = new DataTable();
            dt = obj_MasterCustomer.SPSelGetCustomerDetails(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
            if (dt.Rows.Count > 0)
            {
                Session["data"] = dt;
            }
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["customertype"].ToString() == "C")
                {
                    ddlCType.SelectedValue = "C";
                }
                else if (dt.Rows[0]["customertype"].ToString() == "P")
                {
                    ddlCType.SelectedValue = "P";
                }
                else if (dt.Rows[0]["customertype"].ToString() == "W")
                {
                    ddlCType.SelectedValue = "W";
                }
                if (dt.Rows[0]["empperiodfrom"] != System.DBNull.Value)
                {
                    string Dateempfrom = dt.Rows[0]["empperiodfrom"].ToString();
                    DateTime _retVals = Convert.ToDateTime(Dateempfrom);
                    txt_empfrom.Text = _retVals.ToString("dd/MM/yyyy");
                    if (txt_empfrom.Text == "01/01/1999")
                    {
                        txt_empfrom.Text = "";
                    }
                }
                else
                {
                    txt_empfrom.Text = "";
                }
                if (dt.Rows[0]["empperiodto"] != System.DBNull.Value)
                {
                    string dateempto = dt.Rows[0]["empperiodto"].ToString();
                    DateTime _retVals = Convert.ToDateTime(dateempto);
                    txt_empto.Text = _retVals.ToString("dd/MM/yyyy");
                    if (txt_empto.Text == "01/01/1999")
                    {
                        txt_empto.Text = "";
                    }
                }
                else
                {
                    txt_empto.Text = "";
                }
                if (dt.Rows[0]["limit"] != System.DBNull.Value)
                {
                    txt_limit.Text = dt.Rows[0]["limit"].ToString();
                }
                else
                {
                    txt_limit.Text = "";
                }
                if (txt_limit.Text == "0.0000")
                {
                    txt_limit.Text = "";
                }
                if (dt.Rows[0]["tdsemp"] != System.DBNull.Value)
                {
                    txt_tds_exp.Text = dt.Rows[0]["tdsemp"].ToString();
                    if (txt_tds_exp.Text == "0")
                    {
                        txt_tds_exp.Text = "";
                    }
                }
                else
                {
                    txt_tds_exp.Text = "0";
                }
                if (txt_tds_exp.Text == "0.0000")
                {
                    txt_tds_exp.Text = "";
                }

                if (dt.Rows[0]["certno"] != System.DBNull.Value)
                {
                    txt_certno.Text = dt.Rows[0]["certno"].ToString();
                    if (txt_certno.Text == "0")
                    {
                        txt_certno.Text = "";
                    }
                }
                else
                {
                    txt_certno.Text = "";
                }
                //dt.Rows[0]["customerid"].ToString()
                hf_customerid.Value = dt.Rows[0]["customerid"].ToString();
                txtstreet.Text = dt.Rows[0]["address"].ToString();
                hf_portid.Value = dt.Rows[0]["city"].ToString();
                Session["portid"] = hf_portid.Value;
                txtcity.Text = port.GetPortname(Convert.ToInt32(hf_portid.Value));
                hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(txtcity.Text.ToUpper()));
                txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                txtpincode.Text = dt.Rows[0]["zip"].ToString();
                txtllisd.Text = dt.Rows[0]["llisd"].ToString();
                txtllstd.Text = dt.Rows[0]["llstd"].ToString();
                txtlandline.Text = dt.Rows[0]["phone"].ToString();
                txtfaxisd.Text = dt.Rows[0]["faxisd"].ToString();
                txtfaxstd.Text = dt.Rows[0]["faxstd"].ToString();
                txtfax.Text = dt.Rows[0]["fax"].ToString();
                txtemail.Text = dt.Rows[0]["email"].ToString();
                txtPanNo.Text = dt.Rows[0]["panno"].ToString();
                txtServiceTaxNo.Text = dt.Rows[0]["stno"].ToString();

                txt_Salesperson.Text = dt.Rows[0]["empname"].ToString();

                /***********************************************/
                txtunit.Text = dt.Rows[0]["unit#"].ToString();
                txtbuildingname.Text = dt.Rows[0]["buildingname"].ToString();
                txtdoor.Text = dt.Rows[0]["door#"].ToString();
                hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                hf_stateid.Value = dt.Rows[0]["stateid"].ToString();

                txttds.Text = dt.Rows[0]["tds"].ToString();
                //txtfax.Text = dt.Rows[0]["fax"].ToString();
                txtmblisd.Text = dt.Rows[0]["mblisd"].ToString();
                txtMobile.Text = dt.Rows[0]["mobile"].ToString();
                //status = Convert.ToChar(dt.Rows[0]["status"].ToString());
                if (hf_districtid.Value != "")
                {
                    txtdistrict.Text = obj_MasterCustomer.GetStateDistrictname(Convert.ToInt32(hf_districtid.Value));
                }
                if (hf_stateid.Value != "")
                {
                    txtstate.Text = obj_MasterCustomer.GetStatename(Convert.ToInt32(hf_stateid.Value));
                }
                txtmailcom.Text = dt.Rows[0]["commailid"].ToString();
                txtmailimp.Text = dt.Rows[0]["impmailid"].ToString();
                txtmailexport.Text = dt.Rows[0]["expmailid"].ToString();
                txtmailfin.Text = dt.Rows[0]["finmailid"].ToString();
                txtmailmanag.Text = dt.Rows[0]["managmail"].ToString();

                txtmanagptc.Text = dt.Rows[0]["managptc"].ToString();
                txtcomptc.Text = dt.Rows[0]["comptc"].ToString();
                txtexpptc.Text = dt.Rows[0]["expptc"].ToString();
                txtimpptc.Text = dt.Rows[0]["impptc"].ToString();
                txtfinptc.Text = dt.Rows[0]["finptc"].ToString();
                txt_gstin.Text = dt.Rows[0]["gstin"].ToString();
                txt_uinno.Text = dt.Rows[0]["uinno"].ToString();
                txttanno.Text = dt.Rows[0]["tanno"].ToString();
                txtcinno.Text = dt.Rows[0]["cinno"].ToString();
                if (txt_gstin.Text != "")
                {
                    //txt_RCM.Enabled = false;
                    //txt_unregistered.Enabled = false;
                    //txt_RCM.Checked = false;
                    //txt_unregistered.Checked = false;
                }
                else
                {
                    //txt_RCM.Enabled = true;
                    //txt_unregistered.Enabled = true;
                }
                if (txt_uinno.Text != "")
                {
                    //txt_RCM.Enabled = false;
                    //txt_unregistered.Enabled = false;
                    //txt_RCM.Checked = false;
                    //txt_unregistered.Checked = false;
                }
                else
                {
                    //txt_RCM.Enabled = true;
                    //txt_unregistered.Enabled = true;
                }

                if (dt.Rows[0]["RCM"].ToString() == "Y")
                {
                    // txt_RCM.Checked = true;
                    ddl_Option.SelectedValue = "1";
                }

                else if (dt.Rows[0]["UnRegistered"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "2";
                }
                else if (dt.Rows[0]["UnRegistered"].ToString() == "A")
                {
                    ddl_Option.SelectedValue = "7";
                }
                //else
                //{
                //    ddl_Option.SelectedValue = "7";
                //}
                else if (dt.Rows[0]["gstexemption"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "3";
                }
                else if (dt.Rows[0]["Sez"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "6";
                }
                else if (dt.Rows[0]["Register"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "5";
                }
                else if (dt.Rows[0]["SezIgst"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "4";
                    // txt_gstexi.Checked = true;
                }
                else if (dt.Rows[0]["Not Applicable"].ToString() == "A")
                {
                    ddl_Option.SelectedValue = "7";
                    // txt_gstexi.Checked = true; Enable by 13Feb23
                }
                else
                {
                    ddl_Option.SelectedValue = "0";
                }
                //newly added on 07012022 

                if (dt.Rows[0]["IsCoload"].ToString() == "Y")
                {
                    ChkCoload.Checked = true;
                    txt_Coloadercode.Enabled = true;
                    txt_ColoadRemarks.Enabled = true;
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ColoadRemarks"].ToString()) == true)
                    {
                        txt_ColoadRemarks.Text = dt.Rows[0]["ColoadRemarks"].ToString();

                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Coloadercode"].ToString()) == true)
                    {
                        txt_Coloadercode.Text = dt.Rows[0]["Coloadercode"].ToString();
                    }
                }
                else
                {
                    ChkCoload.Checked = false;
                    txt_ColoadRemarks.Enabled = false;
                    txt_Coloadercode.Enabled = false;
                }
                //end

                byte[] imageByte = null;
                if (!DBNull.Value.Equals(dt.Rows[0]["mgmtheadimg"]))
                {

                    imageByte = ((byte[])dt.Rows[0]["mgmtheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp.ImageUrl = "~/images/visitingcard_img.jpg";
                }

                if (!DBNull.Value.Equals(dt.Rows[0]["cmheadimg"]))
                {
                    imageByte = ((byte[])dt.Rows[0]["cmheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp1.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp1.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp1.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp1.ImageUrl = "~/images/visitingcard_img.jpg";
                }

                if (!DBNull.Value.Equals(dt.Rows[0]["expheadimg"]))
                {
                    imageByte = ((byte[])dt.Rows[0]["expheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp2.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp2.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp2.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp2.ImageUrl = "~/images/visitingcard_img.jpg";
                }

                if (!DBNull.Value.Equals(dt.Rows[0]["finheadimg"]))
                {

                    imageByte = ((byte[])dt.Rows[0]["finheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp3.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp3.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp3.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp3.ImageUrl = "~/images/visitingcard_img.jpg";
                }

                if (!DBNull.Value.Equals(dt.Rows[0]["impimg"]))
                {
                    imageByte = ((byte[])dt.Rows[0]["impimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp4.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp4.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp4.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp4.ImageUrl = "~/images/visitingcard_img.jpg";
                }

                hf_locationid.Value = dt.Rows[0]["locationid"].ToString();

                if (dt.Rows[0]["Register"].ToString() == "Y")
                {
                    DataTable DtNew = obj_MasterCustomer.checkvoucherraise(Convert.ToInt32(hf_customerid.Value));
                    if (DtNew.Rows.Count > 0)
                    {
                        ddl_Option.Enabled = false;
                    }
                    else
                    {
                        ddl_Option.Enabled = true;
                    }
                }
                else
                {
                    DataTable DtNew = obj_MasterCustomer.checkvoucherraise(Convert.ToInt32(hf_customerid.Value));
                    if (DtNew.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["UnRegistered"].ToString() == "Y")
                        {
                            ddl_Option.Enabled = true;
                        }
                        else
                        {
                            ddl_Option.Enabled = false;
                        }
                    }
                    else
                    {
                        ddl_Option.Enabled = true;
                    }
                }

                if (ddl_Option.SelectedValue == "0")
                {
                    ddl_Option.Enabled = true;
                }
                if (hf_locationid.Value != "" && hf_locationid.Value != "0")
                {
                    txtlocation.Text = obj_MasterCustomer.GetLocationname(Convert.ToInt32(hf_locationid.Value));
                    ddllocation.Visible = false;
                    btndelete.Enabled = true;
                    btndelete.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    if (txtpincode.Text == "")
                    {
                        txtpincode.Focus();
                        btndelete.Enabled = false;
                        btndelete.ForeColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        dt = location.GetPincodeDetailsForLocation(txtpincode.Text);
                        if (dt.Rows.Count > 1)
                        {
                            txtlocation.Visible = false;
                            ddllocation.Visible = true;
                            btndelete.Enabled = false;
                            btndelete.ForeColor = System.Drawing.Color.Gray;
                            ddllocation.Items.Clear();
                            ddllocation.Items.Add("");
                            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                ddllocation.Items.Add(dt.Rows[i]["Location"].ToString());
                            }
                        }
                        else if (dt.Rows.Count == 1)
                        {
                            txtlocation.Visible = true;
                            ddllocation.Visible = false;
                            btndelete.Enabled = false;
                            btndelete.ForeColor = System.Drawing.Color.Gray;
                            txtlocation.Text = dt.Rows[0]["Location"].ToString();
                            hf_locationid.Value = dt.Rows[0]["LocationId"].ToString();
                            txtlocationTxtChange();
                        }
                    }
                }
                //btnSave.Enabled = true;
                //btnSave.ToolTip = "Update";
                //btnSave1.Attributes["class"] = "btn ico-update";
                //btnBack.ToolTip = "Clear";
                //btnBack1.Attributes["class"] = "btn btn-clear1";

                if (txtcountry.Text.ToUpper() != "INDIA")
                {
                    txtdistrict.ReadOnly = true;
                    txtstate.ReadOnly = true;
                    txtcountry.ReadOnly = true;
                }
                dts = obj_MasterCustomer.SPSelGetCustomerDetailsGSTIN(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
                if (dts.Rows.Count > 0)
                {
                    txtGSTCode.Text = dts.Rows[0]["GSTCode"].ToString();
                    hdn_oldgstcode.Value = dts.Rows[0]["GSTCode"].ToString();
                }

                hid_gstcode.Value = hf_stateid.Value;
                GetBusinesscardDetails();
            }
            CustomerTDS();
            customermrcode();
        }

        public void customermrcode()
        {
          //  DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();

            DataTable dt_Custnew = new DataTable();
            if (txtcustomer.Text != "")
            {
                if (hf_customerid.Value != "" || hf_customerid.Value != "0")
                {
                    dt_Custnew = da_obj_customerobj.SelMasterCust4MRCode(Convert.ToInt32(hf_customerid.Value));
                }

                if (dt_Custnew.Rows.Count > 0)
                {
                    DataTable dtapp = new DataTable();
                    dtapp.Columns.Add("Name");
                    dtapp.Columns.Add(" Code");

                    DataRow dr1 = dtapp.NewRow();
                    dr1[0] = "Shipper";
                    if (dt_Custnew.Columns.Contains("mrcodeshipper"))
                    {
                        if (!string.IsNullOrEmpty(dt_Custnew.Rows[0]["mrcodeshipper"].ToString()))
                        {
                            dr1[1] = dt_Custnew.Rows[0]["mrcodeshipper"].ToString();
                        }
                        else
                        {
                            dr1[1] = "";
                        }
                    }
                    else
                    {
                        dr1[1] = "";
                    }
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();

                    dr1 = dtapp.NewRow();
                    dr1[0] = "Consignee";

                    if (dt_Custnew.Columns.Contains("mrcodeconsignee"))
                    {
                        if (!string.IsNullOrEmpty(dt_Custnew.Rows[0]["mrcodeconsignee"].ToString()))
                        {
                            dr1[1] = dt_Custnew.Rows[0]["mrcodeconsignee"].ToString();
                        }
                        else
                        {
                            dr1[1] = "";
                        }
                    }
                    else
                    {
                        dr1[1] = "";
                    }
                    //  dr1[1] = dt_Custnew.Rows[0]["mrcodeconsignee"].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "Notify";
                    // dr1[1] = dt_Custnew.Rows[0]["mrcodenotify"].ToString();
                    if (dt_Custnew.Columns.Contains("mrcodenotify"))
                    {
                        if (!string.IsNullOrEmpty(dt_Custnew.Rows[0]["mrcodenotify"].ToString()))
                        {
                            dr1[1] = dt_Custnew.Rows[0]["mrcodenotify"].ToString();
                        }
                        else
                        {
                            dr1[1] = "";
                        }
                    }
                    else
                    {
                        dr1[1] = "";
                    }
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "Sea";
                    // dr1[1] = dt_Custnew.Rows[0]["mrcodeseaagent"].ToString();
                    if (dt_Custnew.Columns.Contains("mrcodeseaagent"))
                    {
                        if (!string.IsNullOrEmpty(dt_Custnew.Rows[0]["mrcodeseaagent"].ToString()))
                        {
                            dr1[1] = dt_Custnew.Rows[0]["mrcodeseaagent"].ToString();
                        }
                        else
                        {
                            dr1[1] = "";
                        }
                    }
                    else
                    {
                        dr1[1] = "";
                    }
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "Air";
                    //dr1[1] = dt_Custnew.Rows[0]["mrcodeairagent"].ToString();
                    if (dt_Custnew.Columns.Contains("mrcodeairagent"))
                    {
                        if (!string.IsNullOrEmpty(dt_Custnew.Rows[0]["mrcodeairagent"].ToString()))
                        {
                            dr1[1] = dt_Custnew.Rows[0]["mrcodeairagent"].ToString();
                        }
                        else
                        {
                            dr1[1] = "";
                        }
                    }
                    else
                    {
                        dr1[1] = "";
                    }
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "SCAC";
                    // dr1[1] = dt_Custnew.Rows[0]["mrscaccode"].ToString();
                    if (dt_Custnew.Columns.Contains("mrscaccode"))
                    {
                        if (!string.IsNullOrEmpty(dt_Custnew.Rows[0]["mrscaccode"].ToString()))
                        {
                            dr1[1] = dt_Custnew.Rows[0]["mrscaccode"].ToString();
                        }
                        else
                        {
                            dr1[1] = "";
                        }
                    }
                    else
                    {
                        dr1[1] = "";
                    }
                    dtapp.Rows.Add(dr1);
                    test.DataSource = dtapp;
                    test.DataBind();
                }
                else
                {
                    DataTable dtapp = new DataTable();
                    dtapp.Columns.Add("Name");
                    dtapp.Columns.Add(" Code");

                    DataRow dr1 = dtapp.NewRow();
                    dr1[0] = "Shipper";
                    dr1[1] = "";
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();

                    dr1 = dtapp.NewRow();
                    dr1[0] = "Consignee";
                    dr1[1] = "";
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "Notify";
                    dr1[1] = "";
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "Sea";
                    dr1[1] = "";
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "Air";
                    dr1[1] = "";
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "SCAC";
                    dr1[1] = "";
                    dtapp.Rows.Add(dr1);

                    test.DataSource = dtapp;
                    test.DataBind();
                }
            }
            else
            {
                DataTable dtapp = new DataTable();
                dtapp.Columns.Add("Name");
                dtapp.Columns.Add(" Code");

                DataRow dr1 = dtapp.NewRow();
                dr1[0] = "Shipper";
                dr1[1] = "";
                dtapp.Rows.Add(dr1);
                dr1 = dtapp.NewRow();

                dr1 = dtapp.NewRow();
                dr1[0] = "Consignee";
                dr1[1] = "";
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "Notify";
                dr1[1] = "";
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "Sea";
                dr1[1] = "";
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "Air";
                dr1[1] = "";
                dtapp.Rows.Add(dr1);

                dr1 = dtapp.NewRow();
                dr1[0] = "SCAC";
                dr1[1] = "";
                dtapp.Rows.Add(dr1);


                test.DataSource = dtapp;
                test.DataBind();
            }
        }

        protected void test_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //   // e.Row.Cells[17].HorizontalAlign = HorizontalAlign.Right;
            //     e.Row.Cells[17].Attributes.CssStyle["text-align"] = "Right";
            //}

        }
        private void getdetailscustomer(int int_custid, string custname, string custtype)
        {
            //btndelete.Text = "Reject";
            btndelete.ToolTip = "Reject";
            btndelete1.Attributes["class"] = "btn btn-reject1";
            btndelete.Enabled = true;
            btndelete.ForeColor = System.Drawing.Color.White;
            DataTable dt1 = new DataTable();
            //string custpye;
            try
            {
                txtcustomer.Text = custname;
                dt1 = cusobj.getOtherReqCustomerDtls(int_custid, custname, custtype);
                if (dt1.Rows.Count > 0)
                {
                    //  zip,phone,fax,email,ptc,commailid,expmailid,impmailid,finmailid,tds,comptc,expptc,impptc,finptc,llisd
                    hf_customerid.Value = dt1.Rows[0]["customerid"].ToString();
                    txtunit.Text = dt1.Rows[0]["unit#"].ToString();
                    txtbuildingname.Text = dt1.Rows[0]["buildingname"].ToString();
                    txtdoor.Text = dt1.Rows[0]["door#"].ToString();
                    txtstreet.Text = dt1.Rows[0]["address"].ToString();
                    txtcity.Text = port.GetPortname(Convert.ToInt32(dt1.Rows[0]["city"].ToString()));
                    // txtlocation.Text = obj_MasterCustomer.GetLocationname(Convert.ToInt32(dt1.Rows[0]["countryid"].ToString()));
                    txtpincode.Text = dt1.Rows[0]["zip"].ToString();
                    txtpincode.ReadOnly = true;
                    txtlandline.Text = dt1.Rows[0]["phone"].ToString();
                    txtlandline.ReadOnly = true;
                    txtfax.Text = dt1.Rows[0]["fax"].ToString();
                    txtfax.ReadOnly = true;
                    txtemail.Text = dt1.Rows[0]["email"].ToString();
                    txtemail.ReadOnly = true;
                    txtmailcom.Text = dt1.Rows[0]["commailid"].ToString();
                    txtmailcom.ReadOnly = true;
                    txtmailexport.Text = dt1.Rows[0]["expmailid"].ToString();
                    txtmailexport.ReadOnly = true;
                    txtmailimp.Text = dt1.Rows[0]["impmailid"].ToString();
                    txtmailimp.ReadOnly = true;
                    txtmailfin.Text = dt1.Rows[0]["finmailid"].ToString();
                    txtmailfin.ReadOnly = true;
                    txttds.Text = dt1.Rows[0]["tds"].ToString();
                    txttds.ReadOnly = true;
                    txtcomptc.Text = dt1.Rows[0]["comptc"].ToString();
                    txtcomptc.ReadOnly = true;
                    txtexpptc.Text = dt1.Rows[0]["expptc"].ToString();
                    txtexpptc.ReadOnly = true;
                    txtimpptc.Text = dt1.Rows[0]["impptc"].ToString();
                    txtimpptc.ReadOnly = true;
                    txtfinptc.Text = dt1.Rows[0]["finptc"].ToString();
                    txtfinptc.ReadOnly = true;
                    txtllisd.Text = dt1.Rows[0]["llisd"].ToString();
                    txtllisd.ReadOnly = true;
                    if (!String.IsNullOrEmpty(dt1.Rows[0]["city"].ToString()))
                    {
                        hf_portid.Value = dt1.Rows[0]["city"].ToString();
                    }
                    else
                    {
                        hf_portid.Value = "0";
                    }
                    if (!String.IsNullOrEmpty(dt1.Rows[0]["districtid"].ToString()))
                    {
                        hf_districtid.Value = dt1.Rows[0]["districtid"].ToString();
                    }
                    else
                    {
                        hf_districtid.Value = "0";
                    }
                    if (!String.IsNullOrEmpty(dt1.Rows[0]["stateid"].ToString()))
                    {
                        hf_stateid.Value = dt1.Rows[0]["stateid"].ToString();
                    }
                    else
                    {
                        hf_stateid.Value = "0";
                    }
                    if (!String.IsNullOrEmpty(dt1.Rows[0]["Countryid"].ToString()))
                    {
                        hf_countryid.Value = dt1.Rows[0]["Countryid"].ToString();
                    }
                    else
                    {
                        hf_countryid.Value = "0";
                    }
                    if (!String.IsNullOrEmpty(dt1.Rows[0]["locationid"].ToString()))
                    {
                        hf_locationid.Value = dt1.Rows[0]["locationid"].ToString();
                    }
                    else
                    {
                        hf_locationid.Value = "0";
                    }

                    if (hf_locationid.Value != "")
                    {
                        txtlocation.Text = obj_MasterCustomer.GetLocationname(Convert.ToInt32(hf_locationid.Value));
                    }
                    if (hf_countryid.Value != "")
                    {
                        txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                    }
                    if (hf_districtid.Value != "")
                    {
                        txtdistrict.Text = obj_MasterCustomer.GetStateDistrictname(Convert.ToInt32(hf_districtid.Value));
                    }
                    if (hf_stateid.Value != "")
                    {
                        txtstate.Text = obj_MasterCustomer.GetStatename(Convert.ToInt32(hf_stateid.Value));
                    }

                    // txtcity.Text = port.GetPortname(Convert.ToInt32(hf_portid.Value));
                    //  hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(txtcity.Text));
                    //  txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                    //txtllisd.Text = dt.Rows[0]["llisd"].ToString();
                    //txtllstd.Text = dt.Rows[0]["llstd"].ToString();
                    //txtfaxisd.Text = dt.Rows[0]["faxisd"].ToString();
                    //txtfaxstd.Text = dt.Rows[0]["faxstd"].ToString();
                    //txtfax.Text = dt1.Rows[0]["fax"].ToString();
                    //txtPanNo.Text = dt.Rows[0]["panno"].ToString();
                    //txtServiceTaxNo.Text = dt.Rows[0]["stno"].ToString();
                    /***********************************************/
                    //txtunit.Text = dt.Rows[0]["unit#"].ToString();
                    //txtbuildingname.Text = dt.Rows[0]["buildingname"].ToString();
                    //txtdoor.Text = dt.Rows[0]["door#"].ToString();
                    //hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                    //hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                    //txttds.Text = dt.Rows[0]["tds"].ToString();
                    //txtfax.Text = dt.Rows[0]["fax"].ToString();
                    //txtmblisd.Text = dt.Rows[0]["mblisd"].ToString();
                    //txtMobile.Text = dt.Rows[0]["mobile"].ToString();
                    //status = Convert.ToChar(dt.Rows[0]["status"].ToString());
                    //if (hf_districtid.Value != "")
                    //{
                    //    txtdistrict.Text = obj_MasterCustomer.GetStateDistrictname(Convert.ToInt32(hf_districtid.Value));
                    //}
                    //if (hf_stateid.Value != "")
                    //{
                    //    txtstate.Text = obj_MasterCustomer.GetStatename(Convert.ToInt32(hf_stateid.Value));

                    //}
                    //txtmailcom.Text = dt.Rows[0]["commailid"].ToString();
                    //txtmailimp.Text = dt.Rows[0]["impmailid"].ToString();
                    //txtmailexport.Text = dt.Rows[0]["expmailid"].ToString();
                    //txtmailfin.Text = dt.Rows[0]["finmailid"].ToString();
                    //txtmailmanag.Text = dt.Rows[0]["managmail"].ToString();

                    //txtmanagptc.Text = dt.Rows[0]["managptc"].ToString();
                    //txtcomptc.Text = dt.Rows[0]["comptc"].ToString();
                    //txtexpptc.Text = dt.Rows[0]["expptc"].ToString();
                    //txtimpptc.Text = dt.Rows[0]["impptc"].ToString();
                    //txtfinptc.Text = dt.Rows[0]["finptc"].ToString();
                    /***********************************************/
                    //hf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                    //if (hf_locationid.Value != "" && hf_locationid.Value != "0")
                    //{
                    //    txtlocation.Text = obj_MasterCustomer.GetLocationname(Convert.ToInt32(hf_locationid.Value));
                    //    ddllocation.Visible = false;
                    //    btndelete.Enabled = true;
                    //}
                    //else
                    //{
                    //    if (txtpincode.Text == "")
                    //    {
                    //        txtpincode.Focus();
                    //        btndelete.Enabled = false;
                    //    }
                    //    else
                    //    {
                    //        dt = location.GetPincodeDetailsForLocation(txtpincode.Text);
                    //        if (dt.Rows.Count > 1)
                    //        {
                    //            //lstlocation.Visible = true;
                    //            //lstlocation.Items.Clear();
                    //            //lstlocation.DataSource = dt;
                    //            //lstlocation.DataValueField = "Location";
                    //            //lstlocation.DataBind();
                    //            txtlocation.Visible = false;
                    //            ddllocation.Visible = true;
                    //            btndelete.Enabled = false;
                    //            ddllocation.Items.Clear();
                    //            ddllocation.Items.Add("Location");
                    //            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    //            {
                    //                ddllocation.Items.Add(dt.Rows[i]["Location"].ToString());
                    //            }
                    //        }
                    //        else if (dt.Rows.Count == 1)
                    //        {
                    //            txtlocation.Visible = true;
                    //            ddllocation.Visible = false;
                    //            btndelete.Enabled = false;
                    //            txtlocation.Text = dt.Rows[0]["Location"].ToString();
                    //        }
                    //    }
                    //}
                    btnSave.Enabled = true;
                     btnSave.Text = "Save";
                     btnBack.Text = "Cancel";

                    btnSave.ToolTip = "Save";
                    btnSave1.Attributes["class"] = "btn ico-save";

                    btnBack.ToolTip = "Cancel";
                    btnBack1.Attributes["class"] = "btn ico-cancel";
                    //if (txtcountry.Text.ToUpper() != "INDIA")
                    //{
                    //    txtlocation.ReadOnly = true;
                    //    txtdistrict.ReadOnly = true;
                    //    txtstate.ReadOnly = true;
                    //    txtcountry.ReadOnly = true;

                    //}
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('Enter Valid Customer Type');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtpincode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = location.GetPincodeDetailsForLocation(txtpincode.Text.Trim());
                if (dt.Rows.Count >= 1)
                {
                    txtlocation.Visible = false;
                    ddllocation.Visible = true;
                    //int i;

                    //for (i = 0; i <= dt.Rows.Count - 1;i++ )
                    //{
                    //    ddllocation.DataSource = dt;
                    //    ddllocation.DataTextField = "Location";
                    //    ddllocation.DataBind();
                    //}
                    ddllocation.Items.Clear();
                    ddllocation.Items.Add("Select Location");

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        ddllocation.Items.Add(dt.Rows[i]["Location"].ToString());
                    }
                }
                else if (dt.Rows.Count == 0)
                {
                    txtlocation.Visible = true;
                    ddllocation.Visible = false;
                    //txtlocation.Text = dt.Rows[0]["Location"].ToString();
                }
                btnBack.Text = "Cancel";
                btnBack.ToolTip = "Cancel";
                btnBack1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void getlocationdetails()
        {
            int locationid = Convert.ToInt32(hf_locationid.Value.ToString());
            DataTable dt1 = new DataTable();
            dt1 = obj_MasterCustomer.GetLocationDetailsIntNEw(Convert.ToInt32(hf_locationid.Value));
            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows[0]["cityport"].ToString() == "")
                {
                    txtcity.Enabled = true;
                    txtcity.Text = "";

                    hf_portid.Value = "";
                    // txtdistrict.Text = dt1.Rows[0]["Districts"].ToString();
                    hf_districtid.Value = dt1.Rows[0]["districtid"].ToString();
                    // txtstate.Text = dt1.Rows[0]["States"].ToString();
                    hf_stateid.Value = dt1.Rows[0]["stateid"].ToString();
                    txtcountry.Text = dt1.Rows[0]["CountryName"].ToString();
                    hf_countryid.Value = dt1.Rows[0]["Countryid"].ToString();
                    txtpincode.Text = dt1.Rows[0]["pincode"].ToString();
                    txtllisd.Text = dt1.Rows[0]["ISDcode"].ToString();
                    // txtllstd.Text = dt1.Rows[0]["stdcode"].ToString();
                    txtmblisd.Text = dt1.Rows[0]["ISDcode"].ToString();
                    txtfaxisd.Text = dt1.Rows[0]["ISDcode"].ToString();
                    txtGSTCode.Text = dt1.Rows[0]["GSTCode"].ToString();
                    //txtfaxstd.Text = dt1.Rows[0]["stdcode"].ToString();
                    txtdistrict.Text = obj_MasterCustomer.GetStateDistrictname(Convert.ToInt32(hf_districtid.Value));
                    txtstate.Text = obj_MasterCustomer.GetStatename(Convert.ToInt32(hf_stateid.Value));
                    hid_gstcode.Value = hf_stateid.Value;

                }
                else if (dt1.Rows[0]["cityport"].ToString() != "0")
                {
                    // txtcity.Enabled = false;
                    hf_portid.Value = dt1.Rows[0]["cityport"].ToString();
                    dt = obj_MasterCustomer.GETDetails4LocationIntNewPort(Convert.ToInt32(hf_locationid.Value), Convert.ToInt32(hf_portid.Value));
                    txtcity.Text = dt.Rows[0]["portname"].ToString();
                    hf_portid.Value = dt.Rows[0]["cityport"].ToString();

                    hf_districtid.Value = dt.Rows[0]["districtid"].ToString();

                    hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                    txtcountry.Text = dt.Rows[0]["CountryName"].ToString();
                    hf_countryid.Value = dt.Rows[0]["Countryid"].ToString();
                    txtpincode.Text = dt.Rows[0]["pincode"].ToString();
                    txtllisd.Text = dt.Rows[0]["ISDcode"].ToString();
                    txtllstd.Text = dt.Rows[0]["stdcode"].ToString();
                    txtmblisd.Text = dt.Rows[0]["ISDcode"].ToString();
                    txtfaxisd.Text = dt.Rows[0]["ISDcode"].ToString();
                    txtfaxstd.Text = dt.Rows[0]["stdcode"].ToString();
                    txtGSTCode.Text = dt.Rows[0]["GSTCode"].ToString();
                    txtdistrict.Text = obj_MasterCustomer.GetStateDistrictname(Convert.ToInt32(hf_districtid.Value));
                    txtstate.Text = obj_MasterCustomer.GetStatename(Convert.ToInt32(hf_stateid.Value));
                    hid_gstcode.Value = hf_stateid.Value;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Enter Valid Location');", true);
                txtlocation.Text = "";
            }
        }

        protected void lstlocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lstlocation.Visible = false;
                lstlocation.Visible = false;
                txtlocation.Text = lstlocation.SelectedValue.ToString();
               // DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
                dt = objp_location.CheckDuplicateForLocationPincode(txtlocation.Text.ToUpper(), txtpincode.Text);
                if (dt.Rows.Count > 0)
                {
                    hf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                }
                if (txtlocation.Text != "" && hf_locationid.Value != "")
                {
                    getlocationdetails();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtcity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtcity.Text != "CITY")
                {
                    hf_portid.Value = Convert.ToString(port.GetNPortid(txtcity.Text.ToUpper()));
                    hf_portid.Value = Convert.ToString(port.GetNPortid(txtcity.Text.ToUpper()));
                    if (hf_portid.Value != "" && hf_portid.Value != "0")
                    {
                        Session["portid"] = hf_portid.Value;
                    }
                    else if (hf_portid.Value == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Enter Valid City');", true);
                        txtcity.Text = "";
                        txtcity.Focus();
                        txtcountry.Text = "";
                        return;
                    }
                    hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(txtcity.Text.ToUpper()));
                    txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                    //if (txtpincode.Text != "")
                    //{
                    //    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Enter Pin code');", true);
                    //    //kalai
                    //    txtpincode.Text = "";
                    //    txtlocation.Text = "";
                    //    txtstate.Text = "";
                    //    txtdistrict.Text = "";
                    //    txtGSTCode.Text = "";
                    //    txtcountry.Text = "";
                    //    txtpincode.Focus();
                    //    return;
                    //}
                    if ((hf_countryid.Value != "1102" && hf_countryid.Value != "102"))
                    {
                        txtdistrict.ReadOnly = true;
                        txtstate.ReadOnly = true;
                        txtcountry.ReadOnly = true;
                    }
                    else if (hf_countryid.Value == "1102" || hf_countryid.Value == "102")
                    {
                        if (txtpincode.Text != "")
                        {
                            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Enter Pin code');", true);
                            //kalai
                            txtpincode.Text = "";
                            txtlocation.Text = "";
                            txtstate.Text = "";
                            txtdistrict.Text = "";
                            txtGSTCode.Text = "";
                            txtcountry.Text = "";
                            txtpincode.Focus();
                            return;
                        }
                        if (ddlcategory.SelectedItem.Text == "Agent")
                        {
                            // txtcity.Text = "";
                            ///  ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Enter the correct city');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txtlocation.Focus();
        }

        private void validateport()
        {
            dt = obj_MasterCustomer.SPSelGetCustomerDetails(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["zip"].ToString() == "")
                {
                    // txtpincode.Text = dt.Rows[0]["zip"].ToString();
                }
            }
        }

        private void fillall()
        {
            dt = obj_MasterCustomer.GetAllDetailsForCustomer(txtcustomer.Text.ToUpper(), Convert.ToInt32(hf_customerid.Value), 'C');
            if (dt.Rows.Count > 0)
            {
                txtbuildingname.Text = dt.Rows[0]["buildingname"].ToString();
                txtunit.Text = dt.Rows[0]["unit#"].ToString();
                txtdoor.Text = dt.Rows[0]["door#"].ToString();
                txtstreet.Text = dt.Rows[0]["street"].ToString();
                hf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                hf_portid.Value = dt.Rows[0]["city"].ToString();
                hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                hf_countryid.Value = dt.Rows[0]["countryid"].ToString();
                txtllisd.Text = dt.Rows[0]["llisd"].ToString();
                txtllstd.Text = dt.Rows[0]["llstd"].ToString();
                txtpincode.Text = dt.Rows[0]["zip"].ToString();
                txtlandline.Text = dt.Rows[0]["phone"].ToString();
                txtfaxisd.Text = dt.Rows[0]["faxisd"].ToString();
                txtfaxstd.Text = dt.Rows[0]["faxstd"].ToString();
                txtfax.Text = dt.Rows[0]["fax"].ToString();
                txtmblisd.Text = dt.Rows[0]["mblisd"].ToString();
                txtMobile.Text = dt.Rows[0]["mobile"].ToString();
                txtemail.Text = dt.Rows[0]["email"].ToString();
                txtPanNo.Text = dt.Rows[0]["panno"].ToString();
                txtServiceTaxNo.Text = dt.Rows[0]["stno"].ToString();
                txtlocation.Text = dt.Rows[0]["Location"].ToString();
                txtdistrict.Text = dt.Rows[0]["Districts"].ToString();
                txtstate.Text = dt.Rows[0]["States"].ToString();
                txtcountry.Text = dt.Rows[0]["countryname"].ToString();
                txtcity.Text = dt.Rows[0]["portname"].ToString();
                lstlocation.Visible = false;
            }
        }

        protected void txtllisd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtllisd.Text != "ISD")
                {
                    txtfaxisd.Text = txtllisd.Text;
                    txtmblisd.Text = txtllisd.Text;
                    txtfaxisd.ReadOnly = true;
                    txtmblisd.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtllstd_TextChanged(object sender, EventArgs e)
        {
            if (txtllstd.Text != "STD")
            {
                txtfaxstd.Text = txtllstd.Text;
                txtfaxstd.ReadOnly = true;
            }
        }

        private bool IsValidEmailId(string InputEmail)
        {
            //Regex To validate Email Address
            // Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            Match match = regex.Match(InputEmail);
            if (match.Success)
                return true;
            else
                return false;
        }

        protected void txtmailmanag_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmailId(txtmailmanag.Text))
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct Email Format');", true);
                txtmailmanag.Text = "";
                txtmailmanag.Focus();
            }
        }

        protected void txtmailcom_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmailId(txtmailcom.Text))
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct Email Format');", true);
                txtmailcom.Text = "";
                txtmailcom.Focus();
            }
        }

        protected void txtmailexport_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmailId(txtmailexport.Text))
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct Email Format');", true);
                txtmailexport.Text = "";
                txtmailexport.Focus();
            }
        }

        protected void txtmailimp_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmailId(txtmailimp.Text))
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct Email Format');", true);
                txtmailimp.Text = "";
                txtmailimp.Focus();
            }
        }

        protected void txtmailfin_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmailId(txtmailfin.Text))
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Enter Correct Email Format');", true);
                txtmailfin.Text = "";
                txtmailfin.Focus();
            }
        }

        protected void btnview_Click1(object sender, EventArgs e)
        {
            try
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";

              //  DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                DataTable dts = obj_MasterCustomer.SPgetallpannodetails(txtPanNo.Text);
                if (dts.Rows.Count > 0)
                {
                    str_RptName = "MasterCustomer.rpt";
                    //  Session["str_sfs"] = "{FEJobInfo.bid}=" + Session["LoginBranchid"].ToString() + " and {FEJobInfo.jobno}=" + txt_job.Text;
                    //   report.strRptName = "Reports" + "\MasterCustomer.rpt" ' "REPORTS" + "\EmpDetails.rpt"
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "MasterCustomer", str_Script, true);
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Customer');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_RCL_Click(object sender, EventArgs e)
        {
            try
            {
                loadgrid();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Job_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblCustomer = (Label)e.Row.FindControl("customername");
                    string tooltip = lblCustomer.Text;
                    e.Row.Cells[0].Attributes.Add("title", tooltip);

                    Label lbltype = (Label)e.Row.FindControl("customertype");
                    string tooltip1 = lbltype.Text;
                    e.Row.Cells[1].Attributes.Add("title", tooltip1);

                    Label lbladdres = (Label)e.Row.FindControl("address");
                    string tooltip2 = lbladdres.Text;
                    e.Row.Cells[2].Attributes.Add("title", tooltip2);

                    Label lblcity = (Label)e.Row.FindControl("portname");
                    string tooltip3 = lblcity.Text;
                    e.Row.Cells[3].Attributes.Add("title", tooltip3);

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

        protected void Grd_Job_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grd_Job.PageIndex = e.NewPageIndex;
                loadgrid();
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
                btndelete.Enabled = true;
                btndelete.ForeColor = System.Drawing.Color.White;
                string custpye = "";
                // int int_jobno = int.Parse(Grd_Job.SelectedRow.Cells[0].Text.ToString());
                int index = Convert.ToInt32(Grd_Job.SelectedRow.RowIndex);
                int int_custid = int.Parse(Grd_Job.Rows[index].Cells[4].Text.ToString());
                string custname = (((Label)Grd_Job.Rows[index].Cells[0].FindControl("customername")).Text);
                string custtype = (((Label)Grd_Job.Rows[index].Cells[1].FindControl("customertype")).Text);
                if (custtype == "Agent / Principal / Counter Part")
                {
                    custpye = "P";
                    ddlCType.SelectedValue = custpye;
                }
                else if (custtype == "Depo")
                {
                    custpye = "W";
                    ddlCType.SelectedValue = custpye;
                }
                else
                {
                    custpye = "C";
                    ddlCType.SelectedValue = custpye;
                }
                getdetailscustomer(int_custid, custname, ddlCType.SelectedValue);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            if (btndelete.ToolTip == "Reject")
            {
                this.PopUpService.Show();
            }
            obj_dt = cusobj.getREQMasterCustomer();
            grd.DataSource = obj_dt;
        }

        protected void btn_yes_Click(object sender, EventArgs e)
        {
            try
            {
                cusobj.SPUpdReqCustomerReject(Convert.ToInt32(hf_customerid.Value));
                int cid = Convert.ToInt32(hf_customerid.Value);
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 131, 1, int.Parse(Session["LoginBranchid"].ToString()), "Cid:" + cid + " /Rej");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtPanNo_TextChanged(object sender, EventArgs e)
        {
            if (txtPanNo.Text != "")
            {
                DataTable dt = new DataTable();
                dt = obj_MasterCustomer.checklikepanno(txtPanNo.Text, "");
                DataTable grid = obj_MasterCustomer.Getcustgridwithpan(txtPanNo.Text);
                if (dt.Rows.Count > 0)
                {
                    //if (grid.Rows.Count ==1)
                    //{
                    txtpancust.Text = dt.Rows[0]["CustomerPANName"].ToString();
                    hid_pan.Value = dt.Rows[0]["CustomerPANId"].ToString();
                   //  Session["hiddenpanid1"] = txtPanNo.Text;
                    txtcustomer.Text = txtpancust.Text;
                    hf_customerid.Value = dt.Rows[0]["customerid"].ToString();
                    txt_uinno.Text = dt.Rows[0]["CustomerUINno"].ToString();
                    txttanno.Text = dt.Rows[0]["CustomerTANno"].ToString();
                    txtcinno.Text = dt.Rows[0]["CustomerCINno"].ToString();
                    ddlcategory.SelectedValue = dt.Rows[0]["category"].ToString();
                    ddlfacategory.SelectedValue = dt.Rows[0]["facategory"].ToString();
                    txt_creditamount.Text = dt.Rows[0]["creditAmount"].ToString();

                    // new add by yuvaraj 21-12-2022
                    txt_Salesperson.Text = dt.Rows[0]["empname"].ToString();
                    string data = dt.Rows[0]["employeeid"].ToString();
                    if (data != "")
                    {
                        hf_employeeid.Value = data;
                    }
                    if (dt.Rows[0]["empperiodfrom"] != System.DBNull.Value)
                    {
                        string Dateempfrom = dt.Rows[0]["empperiodfrom"].ToString();
                        DateTime _retVals = Convert.ToDateTime(Dateempfrom);
                        txt_empfrom.Text = _retVals.ToString("dd/MM/yyyy");
                        if (txt_empfrom.Text == "01/01/1999")
                        {
                            txt_empfrom.Text = "";
                        }
                    }
                    else
                    {
                        txt_empfrom.Text = "";
                    }
                    if (dt.Rows[0]["empperiodto"] != System.DBNull.Value)
                    {
                        string dateempto = dt.Rows[0]["empperiodto"].ToString();
                        DateTime _retVals = Convert.ToDateTime(dateempto);
                        txt_empto.Text = _retVals.ToString("dd/MM/yyyy");
                        if (txt_empto.Text == "01/01/1999")
                        {
                            txt_empto.Text = "";
                        }
                    }
                    else
                    {
                        txt_empto.Text = "";
                    }

                    if (dt.Rows[0]["limit"] != System.DBNull.Value)
                    {
                        txt_limit.Text = dt.Rows[0]["limit"].ToString();
                    }
                    else
                    {
                        txt_limit.Text = "";
                    }
                    if (txt_limit.Text == "0.0000")
                    {
                        txt_limit.Text = "";
                    }

                    if (dt.Rows[0]["tdsemp"] != System.DBNull.Value)
                    {
                        txt_tds_exp.Text = dt.Rows[0]["tdsemp"].ToString();
                        if (txt_tds_exp.Text == "0")
                        {
                            txt_tds_exp.Text = "";
                        }
                    }
                    else
                    {
                        txt_tds_exp.Text = "0";
                    }
                    if (txt_tds_exp.Text == "0.0000")
                    {
                        txt_tds_exp.Text = "";
                    }
                    if (dt.Rows[0]["certno"] != System.DBNull.Value)
                    {
                        txt_certno.Text = dt.Rows[0]["certno"].ToString();
                        if (txt_certno.Text == "0")
                        {
                            txt_certno.Text = "";
                        }
                    }
                    else
                    {
                        txt_certno.Text = "";
                    }
                    // end 
                    txt_creditday.Text = dt.Rows[0]["creditdays"].ToString();
                  //  DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();
                    //ddl_branch.SelectedItem.Text = dt.Rows[0]["Branch"].ToString();
                    //string datats = dt.Rows[0]["Branch"].ToString();
                    //if (datats != "")
                    //{
                    //    ownerID = Convert.ToInt16(datats);
                    //    FillBranch();
                    //    ddl_branch.SelectedIndex = ownerID;
                    //}
                    ddllegaltype.SelectedValue = dt.Rows[0]["legaltype"].ToString();
                    hid_einvoice.Value = dt.Rows[0]["einvoice"].ToString();
                    string Type1;
                    if (ddlCType.SelectedItem.Text == "Agent / Principal / Counter Part")
                    {
                        Type1 = "P";
                    }
                    else if (ddlCType.SelectedItem.Text == "Depo")
                    {
                        Type1 = "W";
                    }
                    else if (ddlcategory.SelectedValue == "5")
                    {
                        Type1 = "P";
                    }
                    else if (ddlfacategory.SelectedValue == "4")
                    {
                        Type1 = "P";
                    }
                    else if (ddlcategory.SelectedValue == "6")
                    {
                        Type1 = "C";
                        ddl_Option.SelectedItem.Text = "Not Applicable";
                    }
                    else
                    {
                        Type1 = "C";
                    }
                    Session["ctype"] = Type1;
                    txt_exemptions.Text = dt.Rows[0]["EXLIMIT"].ToString();
                    txt_overdue.Text = dt.Rows[0]["OVERDUE"].ToString();

                    string datas = dt.Rows[0]["EXMODE"].ToString();
                    if (datas != "")
                    {
                        if (datas == "A")
                        {
                            ddl_per.SelectedIndex = 1;
                        }
                        else if (datas == "M")
                        {
                            ddl_per.SelectedIndex = 2;
                        }
                    }

                    if (hid_einvoice.Value != "")
                    {
                        if (hid_einvoice.Value == "Y")
                        {
                            chkeinvoice.Checked = true;
                        }
                        else
                        {
                            chkeinvoice.Checked = false;
                        }
                    }
                    // getdetails4pan();
                    btnpanadd.ToolTip = "Update";
                    btnpanadd1.Attributes["class"] = "btn ico-update";
                    if (grid.Rows.Count > 0)
                    {
                        grd.DataSource = grid;
                        grd.DataBind();
                        Session["DataTable"] = grid;

                        if (ddlcategory.SelectedItem.Text == "Agent")
                        {
                            // creditdetailsEnable();
                            //btncredit.Enabled = false;
                            //btntds.Enabled = false;
                            Button9.Enabled = true;
                            Button10.Enabled = false;
                            Button11.Enabled = false;
                            Button12.Enabled = true;
                            Button13.Enabled = true;
                            Button14.Enabled = true;

                        }
                        else if (ddlcategory.SelectedItem.Text == "Others")
                        {
                            //creditdetailsEnable();
                            Button9.Enabled = true;
                            Button10.Enabled = false;
                            Button11.Enabled = false;
                            Button12.Enabled = true;
                            Button13.Enabled = true;
                            Button14.Enabled = true;


                        }
                        else
                        {
                            if (grd.Rows.Count > 0)
                            {
                                ddlProductType.Enabled = true;
                                txt_vol.Enabled = true;
                                ddlvolumetype.Enabled = true;
                                txt_revenue.Enabled = true;
                                txt_creditdays.Enabled = true;
                                txt_creditamount.Enabled = true;
                                txt_exemptions.Enabled = true;
                                txt_overdue.Enabled = true;
                                ddl_per.Enabled = true;
                                txtCreditAboveamt.Enabled = true;
                                btnCreditRequestAdd.Enabled = true;
                                Button9.Enabled = true;
                                Button10.Enabled = true;
                                Button11.Enabled = true;
                                Button12.Enabled = true;
                                Button13.Enabled = true;
                                Button14.Enabled = true;

                            }
                        }
                    }
                    kycGrid();
                    Banking();
                    fillcreditgrd();
                    CustomerTDSCustomerPan();
                    GetBusinesscardDetails();
                    //savetds();
                    //}
                    //else
                    //{                       
                    //    if (grid.Rows.Count > 0)
                    //    {
                    //        grd.DataSource = grid;
                    //        grd.DataBind();
                    //    }
                    //}

                    hid_panno.Value = txtPanNo.Text;
                    //if (hidpaninput.Value == "Y")
                    //{
                    //    hid_panno.Value = txtPanNo.Text;
                    //    txtPanNo.Text = ""; --------------hide on  19/03/24
                    //}
                }
                else
                {
                    btnpanadd.ToolTip = "Save";
                    btnpanadd1.Attributes["class"] = "btn ico-save";
                }
              //  hf_countryid.Value = "1102";

            }
            else
            {
                clear();
                ClearSlap();
                grd.DataSource = Utility.Fn_GetEmptyDataTable(); ;
                grd.DataBind();
                clearpan();
                txtcustomer.Text = "";
                GridView1.DataSource = Utility.Fn_GetEmptyDataTable();
                GridView1.DataBind();
                GrdProofkyc.DataSource = Utility.Fn_GetEmptyDataTable();
                GrdProofkyc.DataBind();
                //txtcustomer.Text = true;
                txtbankid.Enabled = true;
                txtaccountno.Enabled = true;
                DropDownList5.Enabled = true;
                txtifsc.Enabled = true;
                btn_Save.Enabled = true;
                ddl_branch.Items.Clear();
                txt_creditday.Text = "";
                txt_creditamount.Text = "";
                clrnew();
                card.Text = "";
                ddlcategory.SelectedValue = "0";
                ddlfacategory.SelectedValue = "0";
                ddllegaltype.SelectedValue = "0";
                btnCreditRequestAdd.ToolTip = "ADD";
                btn_add1.Attributes["class"] = "btn btn-add1 MCtrl MT10";
                // Response.End();
                FillBranch();
                txt_exemptions.Text = "3";
                txt_overdue.Text = "50";
                ddl_per.SelectedIndex = 2;
                ddl_branch.SelectedIndex = 3;
                GridCreditclear();
            }
            //if(Convert.ToInt32(txtPanNo.Text)>10)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Panno Only 10 Character allowed');", true);
            //}
        }

        protected void txt_RCM_CheckedChanged(object sender, EventArgs e)
        {
            txt_RCM.Checked = true;
            txt_unregistered.Checked = false;
        }

        protected void txt_unregistered_CheckedChanged(object sender, EventArgs e)
        {
            txt_RCM.Checked = false;
            txt_unregistered.Checked = true;
        }

        protected void txt_gstin_TextChanged(object sender, EventArgs e)
        {
            // txtPanNo.Text = "";
            if (txt_gstin.Text.Length >= 12 && txtPanNo.Text.ToUpper() != "")
            {
                if (txtPanNo.Text.ToUpper() == txt_gstin.Text.ToUpper().Substring(2, 10))
                {
                    ddl_Option.SelectedValue = "5";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('GSTIN # - PAN# and Customer PAN# is Not Match');", true);
                    return;
                }
            }
            String gstin = txt_gstin.Text.ToUpper().Trim();

            if (validGSTIN(gstin.ToUpper().Trim()))
            {
                if (txtPanNo.Text == "")
                {
                    if (txt_gstin.Text != "")
                    {
                        if (txt_gstin.Text.Trim().Length > 14)
                        {
                            txtPanNo.Text = txt_gstin.Text.ToUpper().Substring(2, 10);
                        }
                    }
                }
                ddl_Option.SelectedValue = "5";
                txtcustomer.Focus();
                //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + "Valid GSTIN!" + "');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + "Invalid GSTIN" + "');", true);
                txt_gstin.Text = "";
                // txtPanNo.Text = "";
                txt_gstin.Text.Trim();
                txt_gstin.Focus();
                //clear();
                return;
            }
            //Elengo
            if (txt_gstin.Text.Trim() != "")
            {
                dt = obj_MasterCustomer.GetEmployeeDetByGSTIN(txt_gstin.Text);
                //Session["tempdt"] = dt;
                if (dt.Rows.Count > 0)
                {
                    //if (dt.Rows.Count == 1)
                    //{
                    //    lnkCustomer.Visible = true;
                    //    PopUpCustomer.Show();
                    //    hf_customerid.Value = dt.Rows[0]["customerid"].ToString();
                    //    txtcustomer.Text = dt.Rows[0]["customername"].ToString();
                    //    ViewState["tempdt"] = dt;
                    //}
                    //else
                    //{
                    lnkCustomer.Visible = true;
                    PopUpCustomer.Show();
                    ViewState["tempdt"] = dt;
                    //}
                }
                else
                {
                }
            }
        }

        protected void txt_uinno_TextChanged(object sender, EventArgs e)
        {
            if (txt_uinno.Text != "")
            {
                //txt_RCM.Enabled = false;
                //txt_unregistered.Enabled = false;
                //txt_RCM.Checked = false;
                //txt_unregistered.Checked = false;

            }
            else if (txt_gstin.Text == "")
            {
                //txt_RCM.Enabled = true;
                //txt_unregistered.Enabled = true;
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
            PanelLog1.Visible = true;
            GridViewlog.Visible = true;
            Panel3.Visible = true;

            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 131, "Mscus", hf_customerid.Value, hf_customerid.Value, "");  //"/Rate ID: " +
            if (txtcustomer.Text != "")
            {
                JobInput.Text = txtcustomer.Text;

            }
            else
            {
                JobInput.Text = "";
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void txtemail_TextChanged(object sender, EventArgs e)
        {
            //if (IsValidEmailId(txtemail.Text))
            //{
            if (txtemail.Text.Trim().ToUpper() != "")
            {
                string[] strTemptobcc = txtemail.Text.Split(';', ',');

                for (int i = 0; i < strTemptobcc.Length; i++)
                {
                    if (IsValidEmailId(strTemptobcc[i].ToString().Trim().ToUpper()))
                    {
                        // txt_customer.Focus();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('InValid Email Format');", true);
                        txtemail.Text = "";
                        txtemail.Focus();
                        return;
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Branch", "alertify.alert('Mail ID Cant Be Balnk');", true);
                txtemail.Text = "";
                txtemail.Focus();
            }
        }

        public byte[] pstFile(FileUpload passfile)
        {
            Stream fs = default(Stream);
            byte[] bytes1 = null;
            byte[] postfile = null;
            fs = passfile.PostedFile.InputStream;
            BinaryReader br1 = new BinaryReader(fs);
            bytes1 = br1.ReadBytes(passfile.PostedFile.ContentLength);
            postfile = bytes1;
            return postfile;
        }

        public Boolean validGSTIN(String gstin)
        {
            Boolean isValidFormat = false;
            if (checkPattern(gstin, GSTINFORMAT_REGEX))
            {
                isValidFormat = verifyCheckDigit(gstin);
            }
            return isValidFormat;
        }

        public Boolean checkPattern(String inputval, String regxpatrn)
        {
            Boolean result = false;
            if (Regex.Match(inputval.Trim(), regxpatrn).Success)
            {
                result = true;
            }
            return result;
        }

        public Boolean verifyCheckDigit(String gstinWCheckDigit)
        {
            Boolean isCDValid = false;
            String newGstninWCheckDigit = getGSTINWithCheckDigit(
                    gstinWCheckDigit.Substring(0, gstinWCheckDigit.Length - 1));

            if (gstinWCheckDigit.Trim().Equals(newGstninWCheckDigit))
            {
                isCDValid = true;
            }
            return isCDValid;
        }

        public String getGSTINWithCheckDigit(String gstinWOCheckDigit)
        {
            int factor = 2;
            int sum = 0;
            int checkCodePoint = 0;
            char[] cpChars;
            char[] inputChars;
            try
            {
                if (gstinWOCheckDigit == null)
                {
                    throw new Exception("GSTIN supplied for checkdigit calculation is null");
                }
                cpChars = GSTN_CODEPOINT_CHARS.ToCharArray();
                inputChars = gstinWOCheckDigit.Trim().ToUpper().ToCharArray();

                int mod = cpChars.Length;
                for (int i = inputChars.Length - 1; i >= 0; i--)
                {
                    int codePoint = -1;
                    for (int j = 0; j < cpChars.Length; j++)
                    {
                        if (cpChars[j] == inputChars[i])
                        {
                            codePoint = j;
                        }
                    }
                    int digit = factor * codePoint;
                    factor = (factor == 2) ? 1 : 2;
                    digit = (digit / mod) + (digit % mod);
                    sum += digit;
                }
                checkCodePoint = (mod - (sum % mod)) % mod;
                string a = gstinWOCheckDigit + cpChars[checkCodePoint];
                return gstinWOCheckDigit + cpChars[checkCodePoint];
            }
            finally
            {
                inputChars = null;
                cpChars = null;
            }
        }

        protected void btn_CL_Yes_Click(object sender, EventArgs e)
        {
            ddl_Option.Enabled = true;
            ddl_Option.SelectedValue = "5";
            //  txtcustomer.Text = "";
            ddlCType.SelectedValue = "C";
            txtunit.Text = "";
            txtbuildingname.Text = "";
            txtdoor.Text = "";
            txtstreet.Text = "";
            txtcity.Text = "";
            txtpincode.Text = "";
            txtlocation.Text = "";
            ddllocation.SelectedIndex = 0;
            txtdistrict.Text = "";
            txtstate.Text = "";
            txtGSTCode.Text = "";
            txtcountry.Text = "";
            txtllisd.Text = "";
            txtllstd.Text = "";
            txtlandline.Text = "";
            txtfaxisd.Text = "";
            txtfaxstd.Text = "";
            txtfax.Text = "";
            txtmblisd.Text = "";
            txtMobile.Text = "";
            txtemail.Text = "";
            //txtPanNo.Text = "";
            txtServiceTaxNo.Text = "";
            txttds.Text = "";
            txt_uinno.Text = "";
            txtPanNo.ReadOnly = true;
            txtName.Text = "";
            btnSave.ToolTip = "Save";
            btnSave1.Attributes["class"] = "btn ico-save";
            grdBusinesscard.DataSource = new DataTable();
            grdBusinesscard.DataBind();
        }

        protected void btn_CL_No_Click(object sender, EventArgs e)
        {
            GetCustomerListInPOPUP();
        }

        //public void NewClear()
        //{
        //    ddl_Option.Enabled = true;
        //    txtcustomer.ReadOnly = false;
        //    ddlCType.Enabled = true;
        //    txtunit.ReadOnly = false;
        //    txtbuildingname.ReadOnly = false;
        //    txtdoor.ReadOnly = false;
        //    txtstreet.ReadOnly = false;
        //    txtcity.ReadOnly = false;
        //    txtpincode.ReadOnly = false;
        //    txtlocation.ReadOnly = false;
        //    ddllocation.Enabled = true;
        //    txtdistrict.ReadOnly = false;
        //    txtstate.ReadOnly = false;
        //    txtGSTCode.ReadOnly = false;
        //    txtcountry.ReadOnly = false;
        //    txtllisd.ReadOnly = false;
        //    txtllstd.ReadOnly = false;
        //    txtlandline.ReadOnly = false;
        //    txtfaxisd.ReadOnly = false;
        //    txtfaxstd.ReadOnly = false;
        //    txtfax.ReadOnly = false;
        //    txtmblisd.ReadOnly = false;
        //    txtMobile.ReadOnly = false;
        //    txtemail.ReadOnly = false;
        //    txtPanNo.ReadOnly = false;
        //    txtServiceTaxNo.ReadOnly = false;
        //    txttds.ReadOnly = false;
        //    txt_uinno.ReadOnly = false;
        //    grdBusinesscard.DataSource = new DataTable();
        //    grdBusinesscard.DataBind();
        //}

        protected void grdBusinesscard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    if (i != 5)
                    {
                        e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                        e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdBusinesscard, "Select$" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";
                        //ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                    }
                }
            }
        }

        protected void grdBusinesscard_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = grdBusinesscard.SelectedRow.RowIndex;
                string filename1;
                if (grdBusinesscard.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    if (txtcustomer.Text != "")
                    {
                        if (!string.IsNullOrWhiteSpace(grdBusinesscard.Rows[index].Cells[5].Text))// 2 change to 5
                        {
                            filename1 = grdBusinesscard.Rows[index].Cells[5].Text;
                            if (hf_customerid.Value != "")
                            {
                                string Test = "1";//0
                                ScriptManager.RegisterStartupScript(grdBusinesscard, typeof(GridView), "Download", "window.open('../Download.aspx?File=" + filename1 + "&Test=" + Test + "');", true);
                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('PoD not yet updated for this pickslip #');", true);
                                return;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('No File To Download');", true);
                            //txtcustomer.Focus();
                            txt_gstin.Focus();
                            txtName.Text = grdBusinesscard.Rows[index].Cells[3].Text;
                            txt_email.Text = grdBusinesscard.Rows[index].Cells[4].Text;
                            string data = grdBusinesscard.Rows[index].Cells[2].Text;
                            if (data != " ")
                            {
                                // ddlposition.SelectedItem.Text
                                if (data == "EXPORT")
                                {
                                    ddlposition.SelectedValue = "EH";
                                }
                                else if (data == "IMPORT")
                                {
                                    ddlposition.SelectedValue = "IH";
                                }
                                else if (data == "FINANCE")
                                {
                                    ddlposition.SelectedValue = "FH";
                                }
                                else if (data == "MANAGEMENT")
                                {
                                    ddlposition.SelectedValue = "MH";
                                }
                                else if (data == "COMMERCIAL")
                                {
                                    ddlposition.SelectedValue = "CH";
                                }
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Please Enter the Customer #');", true);
                        //txtcustomer.Focus();
                        txt_gstin.Focus();
                    }
                }
                btn_Upload.ToolTip = "Update";
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void grdBusinesscard_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    ImageButton Img_delete = (ImageButton)e.CommandSource;
                    GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
                    DataTable obj_dt = new DataTable();
                    string filename = "";
                    int Index = grd.RowIndex;
                  //  DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                    if (!string.IsNullOrWhiteSpace(grdBusinesscard.Rows[grd.RowIndex].Cells[4].Text))
                    {
                        filename = grdBusinesscard.Rows[grd.RowIndex].Cells[5].Text;
                        if (filename != "")
                        {
                            ftpdeleted(filename);
                        }
                        obj_MasterCustomer.DeleteMCUploadinfo(Convert.ToInt32(grdBusinesscard.Rows[grd.RowIndex].Cells[0].Text), Convert.ToInt32(grdBusinesscard.Rows[grd.RowIndex].Cells[1].Text));
                        GetBusinesscardDetails();
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "JobInfo", "alertify.alert('Card Details deleted');", true);
                        ddlposition.SelectedValue = "0";
                        ddlTitle.SelectedValue = "0";
                        txtName.Text = "";
                        txt_email.Text = "";
                    }
                    else
                    {
                        obj_MasterCustomer.DeleteMCUploadinfo(Convert.ToInt32(grdBusinesscard.Rows[grd.RowIndex].Cells[0].Text), Convert.ToInt32(grdBusinesscard.Rows[grd.RowIndex].Cells[1].Text));
                        ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('No File To deleted');", true);
                        GetBusinesscardDetails();
                        ddlposition.SelectedValue = "0";
                        ddlTitle.SelectedValue = "0";
                        txtName.Text = "";
                        txt_email.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            btn_Upload.ToolTip = "Add";
        }

        protected void fttnormaldwd(string filename1)
        {
            string str_filename;
            str_filename = filename1;
            DataTable dt = new DataTable();

            string path = Server.MapPath("~/UploadDocument/Businesscard/" + str_filename);
            string ftp = "ftp://20.235.30.214/";

            //FTP Folder name. Leave blank if you want to Download file from root folder.
            string ftpFolder = "SL/Mastercustomer/BusinessCard/";
            //try
            //{
            //Create FTP Request.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + str_filename);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            //Enter FTP Server credentials.
            //request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");

            request.Credentials = new NetworkCredential(Hid_ServerUsername.Value, Hid_ServerPWD.Value);
            request.UsePassive = true;
            request.UseBinary = true;
            request.EnableSsl = false;

            //Fetch the Response and read it into a MemoryStream object.
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using (FileStream outputStream = new FileStream(path, FileMode.OpenOrCreate))
            using (Stream ftpStream = response.GetResponseStream())
            {
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
            }
            WebClient client = new WebClient();
            Byte[] buffer1 = client.DownloadData(path);
            //if (buffer1 != null)
            //{
            //    Response.ContentType = ContentType;
            //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(path));
            //    Response.WriteFile(path);
            //    Response.Flush();
            //} 
            if (buffer1 != null)
            {
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("content-length", buffer1.Length.ToString());
                HttpContext.Current.Response.BinaryWrite(buffer1);
            }

            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            Response.End();
        }

        protected void ftpdeleted(string filename)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://20.235.30.214/SL/Mastercustomer/BusinessCard/" + filename);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                //request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
                request.Credentials = new NetworkCredential(Hid_ServerUsername.Value, Hid_ServerPWD.Value);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    //  return response.StatusDescription;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            if (hf_customerid.Value == "0" || hf_customerid.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Save The Customer Details Then Add');", true);
                txtcustomer.Focus();
                return;
            }
            if (txtcustomer.Text == "" && hf_customerid.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter Customer Name');", true);
                txtcustomer.Focus();
                return;
            }
            //else if (ddlposition.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Select DESIGNATION');", true);
            //    ddlposition.Focus();
            //    return;
            //}
            //else if (txtName.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter the Name');", true);
            //    txtName.Focus();
            //}
            //else if (FileUpd_logo5.FileName == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Choose the Card');", true);
            //    txtName.Focus();
            //    return;
            //}
            //else
            //{
            if (FileUpd_logo5.FileName != "")
            {
                SaveBusinessCardDetails();
            }
            else
            {
                string data = string.Empty;
                if (idfilename == "null")
                {
                    data = idfilename;
                }
                if (btn_Upload.ToolTip == "Add")
                {

                    string Result = obj_MasterCustomer.InsertBusinessCardInfotoCustomer(int.Parse(hf_customerid.Value), ddlposition.SelectedValue, txtName.Text, data, ddlTitle.Text);
                    if (hf_customerid.Value != "")
                    {
                        DataTable dtt = obj_MasterCustomer.sp_getBusinessCardInfoCustomer(Convert.ToInt32(hf_customerid.Value), txtName.Text, ddlposition.SelectedValue);
                        if (dtt.Rows.Count > 0)
                        {
                            string hidcustomerinfo = string.Empty;
                            hidcustomerinfo = dtt.Rows[0]["MCUploadinfo"].ToString();
                            if (hidcustomerinfo != "")
                            {
                                obj_MasterCustomer.SPfileuploadbusinesscard(int.Parse(hf_customerid.Value), txt_email.Text, Convert.ToInt16(hidcustomerinfo));
                            }
                        }
                    }
                    // obj_MasterCustomer.Updmail4businesscard(int.Parse(hf_customerid.Value), txt_email.Text);
                    // System.IO.File.Delete(c);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + Result + "');", true);
                }
                else
                {
                    string Result = obj_MasterCustomer.UpdateDetailsupload(int.Parse(hf_customerid.Value), ddlposition.SelectedValue, txtName.Text, data, ddlTitle.Text);
                    if (hf_customerid.Value != "")
                    {
                        DataTable dtt = obj_MasterCustomer.sp_getBusinessCardInfoCustomer(Convert.ToInt32(hf_customerid.Value), txtName.Text, ddlposition.SelectedValue);
                        if (dtt.Rows.Count > 0)
                        {
                            string hidcustomerinfo = string.Empty;
                            hidcustomerinfo = dtt.Rows[0]["MCUploadinfo"].ToString();
                            if (hidcustomerinfo != "")
                            {
                                obj_MasterCustomer.SPfileuploadbusinesscard(int.Parse(hf_customerid.Value), txt_email.Text, Convert.ToInt16(hidcustomerinfo));
                            }
                        }
                    }
                    //obj_MasterCustomer.Updmail4businesscard(int.Parse(hf_customerid.Value), txt_email.Text);
                    // System.IO.File.Delete(c);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + Result + "');", true);

                }
                GetBusinesscardDetails();
                ClearUploadDetails();
            }
            // }
        }

        private void SaveBusinessCardDetails()
        {
            string[] splitFilename = FileUpd_logo5.FileName.Split('.');
            string Afterdot = "";
            if (splitFilename.Length > 0)
            {
                Afterdot = splitFilename[1].ToString();
            }
            if (Afterdot.ToUpper() == "JPG" || Afterdot.ToUpper() == "JPEG" || Afterdot.ToUpper() == "PNG" || Afterdot.ToUpper() == "BMP" || Afterdot.ToUpper() == "TIF")
            {
                if (FileUpd_logo5.FileName != "")
                {
                    string idfilename = "", c = "";
                    if (hf_customerid.Value != "" && hf_customerid.Value != null)
                    {
                        int NoInc = 0;
                        if (grdBusinesscard.Rows.Count > 0)
                        {
                            NoInc = grdBusinesscard.Rows.Count + 1;
                        }
                        else
                        {
                            NoInc = grdBusinesscard.Rows.Count + 1;
                        }

                        FileUpd_logo5.SaveAs(Server.MapPath("~/UploadDocument/Businesscard/" + hf_customerid.Value + "-" + "" + NoInc + FileUpd_logo5.FileName));
                        c = (Server.MapPath("~/UploadDocument/Businesscard/") + hf_customerid.Value + "-" + "" + NoInc + Path.GetFileName(FileUpd_logo5.FileName));
                        idfilename = hf_customerid.Value + "-" + "" + NoInc + Path.GetFileName(FileUpd_logo5.FileName);
                        fileupload(NoInc + "" + FileUpd_logo5.FileName, c);
                        if (btn_Upload.ToolTip == "Add")
                        {

                            string Result = obj_MasterCustomer.InsertBusinessCardInfotoCustomer(int.Parse(hf_customerid.Value), ddlposition.SelectedValue, txtName.Text, idfilename, ddlTitle.Text);
                            // obj_MasterCustomer.Updmail4businesscard(int.Parse(hf_customerid.Value), txt_email.Text);
                            if (hf_customerid.Value != "")
                            {
                                DataTable dtt = obj_MasterCustomer.sp_getBusinessCardInfoCustomer(Convert.ToInt32(hf_customerid.Value), txtName.Text, ddlposition.SelectedValue);
                                if (dtt.Rows.Count > 0)
                                {
                                    string hidcustomerinfo = string.Empty;
                                    hidcustomerinfo = dtt.Rows[0]["MCUploadinfo"].ToString();
                                    if (hidcustomerinfo != "")
                                    {
                                        obj_MasterCustomer.SPfileuploadbusinesscard(int.Parse(hf_customerid.Value), txt_email.Text, Convert.ToInt16(hidcustomerinfo));
                                    }
                                }
                            }
                            System.IO.File.Delete(c);
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + Result + "');", true);
                        }
                        else
                        {
                            string Result = obj_MasterCustomer.UpdateDetailsupload(int.Parse(hf_customerid.Value), ddlposition.SelectedValue, txtName.Text, idfilename, ddlTitle.Text);
                            //obj_MasterCustomer.Updmail4businesscard(int.Parse(hf_customerid.Value), txt_email.Text);
                            if (hf_customerid.Value != "")
                            {
                                DataTable dtt = obj_MasterCustomer.sp_getBusinessCardInfoCustomer(Convert.ToInt32(hf_customerid.Value), txtName.Text, ddlposition.SelectedValue);
                                if (dtt.Rows.Count > 0)
                                {
                                    string hidcustomerinfo = string.Empty;
                                    hidcustomerinfo = dtt.Rows[0]["MCUploadinfo"].ToString();
                                    if (hidcustomerinfo != "")
                                    {
                                        obj_MasterCustomer.SPfileuploadbusinesscard(int.Parse(hf_customerid.Value), txt_email.Text, Convert.ToInt16(hidcustomerinfo));
                                    }
                                }
                            }
                            // System.IO.File.Delete(c);
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + Result + "');", true);
                        }
                        GetBusinesscardDetails();
                        ClearUploadDetails();

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Customer Name and Business Card');", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Format Try to Add image Extension Filename .JPG .JPEG .PNG .BMP');", true);
            }
        }

        private void fileupload(string filenames, string path)
        {
            //b = Path.GetFileName(filenames);
            //a = "ftp://20.235.30.214//Mastercustomer/BusinessCard/" + hf_customerid.Value + "-" + filenames;
            //FtpWebRequest req = (FtpWebRequest)(WebRequest.Create(a));
            ////req.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
            //req.Credentials = new NetworkCredential(Hid_ServerUsername.Value, Hid_ServerPWD.Value);
            //req.Method = WebRequestMethods.Ftp.UploadFile;
            //req.Proxy = null;
            //byte[] file = System.IO.File.ReadAllBytes(path);
            //System.IO.Stream str = req.GetRequestStream();
            //str.Write(file, 0, file.Length);
            //str.Close();
            //str.Dispose();
            using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
            {
                DBCS = reader.ReadLine();
            }
            ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
            dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
            //username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
            //password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();
            // added on 25Mar2023 
            username = "vmadmin";
            password = "VMWeb20Mar@)@#";
            b = Path.GetFileName(filenames);
            a = "ftp://20.235.30.214/SL/Mastercustomer/BusinessCard/" + hf_customerid.Value + "-" + filenames;
            FtpWebRequest req = (FtpWebRequest)(WebRequest.Create(a));
            //req.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
            req.Credentials = new NetworkCredential(username, password);
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Proxy = null;
            byte[] file = System.IO.File.ReadAllBytes(path);
            System.IO.Stream str = req.GetRequestStream();
            str.Write(file, 0, file.Length);
            str.Close();
            str.Dispose();
        }

        //private void SaveBusinessCardDetails()
        //{
        //    string[] splitFilename = FileUpd_logo5.FileName.Split('.');
        //    string Afterdot = "";
        //    if (splitFilename.Length > 0)
        //    {
        //        Afterdot = splitFilename[1].ToString();
        //    }
        //    if (Afterdot.ToUpper() == "JPG" || Afterdot.ToUpper() == "JPEG" || Afterdot.ToUpper() == "PNG" || Afterdot.ToUpper() == "BMP" || Afterdot.ToUpper() == "TIF")
        //    {
        //        if (FileUpd_logo5.FileName != "")
        //        {
        //            string idfilename = "", c = "";
        //            if (hf_customerid.Value != "" && hf_customerid.Value != null)
        //            {
        //                int NoInc = 0;
        //                if (grdBusinesscard.Rows.Count > 0)
        //                {
        //                    NoInc = grdBusinesscard.Rows.Count + 1;
        //                }
        //                else
        //                {
        //                    NoInc = grdBusinesscard.Rows.Count + 1;
        //                }
        //                FileUpd_logo5.SaveAs(Server.MapPath("~/UploadDocument/Businesscard/" + hf_customerid.Value + "-" + "" + NoInc + FileUpd_logo5.FileName));
        //                c = (Server.MapPath("~/UploadDocument/Businesscard/") + hf_customerid.Value + "-" + "" + NoInc + Path.GetFileName(FileUpd_logo5.FileName));
        //                idfilename = hf_customerid.Value + "-" + "" + NoInc + Path.GetFileName(FileUpd_logo5.FileName);
        //                fileupload(NoInc + "" + FileUpd_logo5.FileName, c);
        //                string Result = obj_MasterCustomer.InsertBusinessCardInfotoCustomer(int.Parse(hf_customerid.Value), ddlposition.SelectedValue, txtName.Text, idfilename, ddlTitle.Text);
        //                obj_MasterCustomer.Updmail4businesscard(int.Parse(hf_customerid.Value), txt_email.Text);
        //                System.IO.File.Delete(c);
        //                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + Result + "');", true);
        //                GetBusinesscardDetails();
        //                ClearUploadDetails();
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Customer Name and Business Card');", true);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Format Try to Add image Extension Filename .JPG .JPEG .PNG .BMP');", true);
        //    }
        //}

        //private void fileupload(string filenames, string path)
        //{
        //    b = Path.GetFileName(filenames);
        //    a = "ftp://20.235.30.214/SL/Mastercustomer/BusinessCard/" + hf_customerid.Value + "-" + filenames;
        //    FtpWebRequest req = (FtpWebRequest)(WebRequest.Create(a));
        //    //req.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
        //    req.Credentials = new NetworkCredential(Hid_ServerUsername.Value, Hid_ServerPWD.Value);
        //    req.Method = WebRequestMethods.Ftp.UploadFile;
        //    req.Proxy = null;
        //    byte[] file = System.IO.File.ReadAllBytes(path);
        //    System.IO.Stream str = req.GetRequestStream();
        //    str.Write(file, 0, file.Length);
        //    str.Close();
        //    str.Dispose();
        //}

        public void GetBusinesscardDetails()
        {
            if (hf_customerid.Value != "")
            {
                DataTable dtt = obj_MasterCustomer.GetBusinessCardInfotoCustomer(Convert.ToInt32(hf_customerid.Value));
                grdBusinesscard.DataSource = new DataTable();
                grdBusinesscard.DataBind();
                if (dtt.Rows.Count > 0)
                {
                    grdBusinesscard.DataSource = dtt;
                    grdBusinesscard.DataBind();
                }
                else
                {
                    grdBusinesscard.DataSource = new DataTable();
                    grdBusinesscard.DataBind();
                }
            }
        }

        public void ClearUploadDetails()
        {
            ddlposition.SelectedValue = "";
            ddlTitle.Text = "Mr";
            txtName.Text = "";
            txt_email.Text = "";
        }

        protected void ddlposition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grdBusinesscard.Rows.Count > 0)
            {
                for (int i = 0; i < grdBusinesscard.Rows.Count; i++)
                {
                    if (grdBusinesscard.Rows[i].Cells[2].Text == ddlposition.SelectedItem.Text)
                    {
                        ddlposition.SelectedValue = "";
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Exist Same Designation Delete than Add');", true);
                        return;
                    }
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected void grdBusinesscard_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grd_Noof_customer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_Noof_customer, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void grd_Noof_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Index = grd_Noof_customer.SelectedRow.RowIndex;
            hf_customerid.Value = grd_Noof_customer.Rows[Index].Cells[1].Text;
            txtcustomer.Text = grd_Noof_customer.Rows[Index].Cells[2].Text;
            getdetails4pan();
        }

        protected void lnkCustomer_Click(object sender, EventArgs e)
        {
            if (txt_gstin.Text.Length == 15)
            {
                DataTable dtt = obj_MasterCustomer.GetEmployeeDetByGSTIN(txt_gstin.Text);
                if (dtt.Rows.Count > 0)
                {
                    ViewState["tempdt"] = dtt;
                    GetCustomerListInPOPUP();
                    NoOfCustomerpopup.Show();
                }
                else
                {
                    lnkCustomer.Visible = false;
                }
            }
            else
            {
                txt_gstin.Text.Trim();
                NoOfCustomerpopup.Hide();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter Valid GSTNO');", true);
                return;
            }
        }

        protected void GetCustomerListInPOPUP()
        {
            DataTable dttem = (DataTable)ViewState["tempdt"];
            if (dttem != null)
            {
                if (dttem.Rows.Count > 0)
                {
                    NoOfCustomerpopup.Hide();// show hide by yuv
                    grd_Noof_customer.DataSource = dttem;
                    grd_Noof_customer.DataBind();
                }
                else
                {
                    getdetails();
                }
                // txtPanNo.ReadOnly = true;
                ViewState["tempdt"] = null;
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            btn_CL_Yes_Click(sender, e);
        }

        protected void ddl_Option_TextChanged(object sender, EventArgs e)
        {
            if (txt_gstin.Text.Length == 15)
            {
                if (ddl_Option.SelectedItem.Text == "UnRegistered")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('While Being GSTNO Cannot Select UnRegistered');", true);
                    ddl_Option.SelectedIndex = 5;
                    return;
                }
                //else if(ddl_Option.SelectedItem.Text == "Not Applicable")
                //{

                //}
            }
            else
            {
                txt_gstin.Text.Trim();
            }
        }

        protected void ddl_description_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hf_countryid.Value != "" && hf_countryid.Value == "1102")
            {

            }
            else
            {
                if (hf_countryid.Value == "")
                {
                    ddl_description.SelectedIndex = 0;
                    ddl_type.SelectedIndex = 0;
                    ddl_slab.SelectedIndex = 0;
                    ddl_percentage.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('TDS Will Be Apply Only Based on the Customers Country, Enter Customer Details');", true);
                    return;
                }
                else if (hf_countryid.Value != "1102" && hf_countryid.Value != "102")
                {
                    ddl_description.SelectedIndex = 0;
                    ddl_type.SelectedIndex = 0;
                    ddl_slab.SelectedIndex = 0;
                    ddl_percentage.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('You Can Only Save TDS To Indian Customers, Not Other Country');", true);
                    return;
                }
                else
                {
                    ddl_description.SelectedIndex = 0;
                    ddl_type.SelectedIndex = 0;
                    ddl_slab.SelectedIndex = 0;
                    ddl_percentage.SelectedIndex = 0;
                }
            }
        }

        protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_description.SelectedIndex != 0)
            {
                ddl_type_fn();
            }
            else
            {
                ddl_type.SelectedIndex = 0;
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Select Description');", true);
                return;
            }
        }

        protected void ddl_type_fn()
        {
            try
            {
                obj_dt = obj_da_TDS.SelAllTDSDtls();
                if (ddl_type.SelectedItem.Text.Trim().Length > 0)
                {
                    if (ddl_type.SelectedItem.Text == "Individual")
                    {
                        hid_type.Value = "I";
                    }
                    else
                    {
                        hid_type.Value = "C";
                    }
                    var result = obj_dt.AsEnumerable().Where(row => row.Field<string>("tdstype") == ddl_type.SelectedItem.Text.ToString())
                    .Select(row => new { Str_slab = row.Field<string>("tdsslab") }).Distinct().ToList();

                    ddl_slab.Items.Clear();
                    ddl_slab.Items.Add("Slab");
                    ddl_slab.DataSource = result;
                    ddl_slab.DataTextField = "Str_slab";
                    ddl_slab.DataBind();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void ddl_slab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //custds();
                obj_dt = obj_da_TDS.SelAllTDSDtls();
                if (ddl_type.SelectedItem.Text.Trim().Length > 0 && ddl_description.SelectedItem.Text.Trim().Length > 0 && ddl_slab.SelectedItem.Text.Trim().Length > 0)
                {
                    var result = obj_dt.AsEnumerable().Where(row => row.Field<string>("tdstype") == ddl_type.SelectedItem.Text.ToString()
                        && row.Field<string>("tdsdesc") == ddl_description.SelectedItem.Text.ToString()
                        && row.Field<string>("tdsslab") == ddl_slab.SelectedItem.Text.ToString()
                        ).ToList();

                    ddl_percentage.Items.Clear();
                    ddl_percentage.Items.Add("Percentage");

                    for (int i = 0; i <= result.Count - 1; i++)
                    {
                        ddl_percentage.Items.Add(string.Format("{0:0.#}", result[i].ItemArray[4]));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        public void savetds()
        {
            try
            {
                //CheckData();
                if (hf_customerid.Value == "" || hf_customerid.Value == "0")
                {
                    hf_customerid.Value = obj_MasterCustomer.GetCustomerid(txtcustomer.Text.ToUpper()).ToString();
                }
                else
                {

                }
                if (ddl_description.SelectedItem.Text != "" && ddl_description.SelectedItem.Text != "Description" && ddl_slab.SelectedItem.Text != "" && ddl_slab.SelectedItem.Text != "Slab" && ddl_type.SelectedItem.Text != "" && ddl_type.SelectedItem.Text != "Type" && ddl_percentage.SelectedItem.Text != "" && ddl_percentage.SelectedItem.Text != "Percentage")
                {
                    if (blnerr == true)
                    {
                        blnerr = false;
                        return;
                    }
                    int int_TDSid = obj_da_TDS.GetTDSid(ddl_description.SelectedItem.Text, char.Parse(hid_type.Value.ToString()), ddl_slab.SelectedItem.Text, double.Parse(ddl_percentage.SelectedItem.Text));

                    if (int_TDSid == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Select Vaild Details');", true);
                    }
                    else
                    {
                        obj_da_TDS.UpdTDSidnew(int_TDSid, int.Parse(hf_customerid.Value.ToString()), double.Parse(ddl_percentage.SelectedItem.Text));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        public void CustomerTDS()
        {
            if (txtcustomer.Text.Trim().Length > 0)
            {
                custds();
                obj_dttemp = obj_da_TDS.GetTDSDtlsForCustomer(int.Parse(hf_customerid.Value.ToString()));

                if (obj_dttemp.Rows.Count > 0)
                {
                    ddl_description.Text = obj_dttemp.Rows[0][1].ToString();

                    hid_type.Value = obj_dttemp.Rows[0][2].ToString();
                    if (hid_type.Value.ToString() == "I")
                    {
                        ddl_type.Text = "Individual";
                    }
                    else
                    {
                        ddl_type.Text = "Company";
                    }
                    ddl_type_fn();
                    if (ddl_slab.Items.FindByText(obj_dttemp.Rows[0][3].ToString()) != null)
                    {
                        ddl_slab.Text = obj_dttemp.Rows[0][3].ToString();
                    }
                    else
                    {
                        ddl_slab.Items.Add(obj_dttemp.Rows[0][3].ToString());
                    }
                    Fn_percentage_tds();
                    if (ddl_percentage.Items.FindByText(obj_dttemp.Rows[0][4].ToString()) != null)
                    {
                        ddl_percentage.Text = obj_dttemp.Rows[0][4].ToString();
                    }
                    else
                    {
                        ddl_percentage.Items.Add(obj_dttemp.Rows[0][4].ToString());
                    }

                    btnSave.ToolTip = "Update";
                    btnSave1.Attributes["class"] = "btn ico-update";
                    // ScriptManager.RegisterStartupScript(txtcustomer, typeof(TextBox), "CustomerTDS", "alertify.alert('TDS Already Exist');", true);
                }
                else
                {
                    ddl_description.SelectedIndex = 0;
                    ddl_type.SelectedIndex = 0;
                    if (ddl_slab.Items.Count > 0)
                    {
                        ddl_slab.SelectedIndex = 0;
                    }
                    if (ddl_percentage.Items.Count > 0)
                    {
                        ddl_percentage.SelectedIndex = 0;
                    }
                }
                btnSave.Enabled = true;
            }
        }

        public void CustomerTDSCustomerPan()
        {
            if (txtcustomer.Text.Trim().Length > 0)
            {
                custds();
                obj_dttemp = obj_da_TDS.GetdetailsTDSDtlsForCustomerPan(txtPanNo.Text.ToUpper());//int.Parse(hf_customerid.Value.ToString()));

                if (obj_dttemp.Rows.Count > 0)
                {
                    ddl_description.Text = obj_dttemp.Rows[0][1].ToString();

                    hid_type.Value = obj_dttemp.Rows[0][2].ToString();
                    if (hid_type.Value.ToString() == "I")
                    {
                        ddl_type.Text = "Individual";
                    }
                    else
                    {
                        ddl_type.Text = "Company";
                    }
                    ddl_type_fn();
                    if (ddl_slab.Items.FindByText(obj_dttemp.Rows[0][3].ToString()) != null)
                    {
                        ddl_slab.Text = obj_dttemp.Rows[0][3].ToString();
                    }
                    else
                    {
                        ddl_slab.Items.Add(obj_dttemp.Rows[0][3].ToString());
                    }
                    Fn_percentage_tds();
                    if (ddl_percentage.Items.FindByText(obj_dttemp.Rows[0][4].ToString()) != null)
                    {
                        ddl_percentage.Text = obj_dttemp.Rows[0][4].ToString();
                    }
                    else
                    {
                        ddl_percentage.Items.Add(obj_dttemp.Rows[0][4].ToString());
                    }
                    //btnSave.ToolTip = "S";

                    //btnSave1.Attributes["class"] = "btn ico-update";
                    // ScriptManager.RegisterStartupScript(txtcustomer, typeof(TextBox), "CustomerTDS", "alertify.alert('TDS Already Exist');", true);
                }
                else
                {
                    ddl_description.SelectedIndex = 0;
                    ddl_type.SelectedIndex = 0;
                    if (ddl_slab.Items.Count > 0)
                    {
                        ddl_slab.SelectedIndex = 0;
                    }
                    if (ddl_percentage.Items.Count > 0)
                    {
                        ddl_percentage.SelectedIndex = 0;
                    }
                }
                btnSave.Enabled = true;
            }
        }

        public void custds()
        {
            obj_dt = obj_da_TDS.SelAllTDSDtls();
            List<string> Description = obj_dt.AsEnumerable().Select(row => row.Field<string>(obj_dt.Columns[1].ColumnName.ToString())).Distinct().ToList();
            List<string> Type = obj_dt.AsEnumerable().Select(row => row.Field<string>(obj_dt.Columns[2].ColumnName.ToString())).Distinct().ToList();

            if (Description.Count > 0)
            {
                ddl_description.Items.Clear();
                ddl_description.Items.Add("Description");
                ddl_description.DataSource = Description;
                ddl_description.DataBind();
            }
            if (Type.Count > 0)
            {
                ddl_type.Items.Clear();
                ddl_type.Items.Add("Type");
                ddl_type.DataSource = Type;
                ddl_type.DataBind();
            }
            ddl_slab.Items.Add("Slab");
            ddl_percentage.Items.Add("Percentage");
        }

        protected void Fn_percentage_tds()
        {
            if (ddl_type.SelectedItem.Text.Trim().Length > 0 && ddl_description.SelectedItem.Text.Trim().Length > 0 && ddl_slab.SelectedItem.Text.Trim().Length > 0)
            {
                var result = obj_dt.AsEnumerable().Where(row => row.Field<string>("tdstype") == ddl_type.SelectedItem.Text.ToString()
                    && row.Field<string>("tdsdesc") == ddl_description.SelectedItem.Text.ToString()
                    && row.Field<string>("tdsslab") == ddl_slab.SelectedItem.Text.ToString()
                    ).ToList();

                ddl_percentage.Items.Clear();
                ddl_percentage.Items.Add("Percentage");

                for (int i = 0; i <= result.Count - 1; i++)
                {
                    ddl_percentage.Items.Add(string.Format("{0:0.#}", result[i].ItemArray[4]));
                }
            }
        }

        private void ClearSlap()
        {
            // txtcustomer.Text = "";
            ddl_description.SelectedIndex = 0;
            ddl_type.SelectedIndex = 0;
            if (ddl_slab.Items.Count > 0)
            {
                ddl_slab.Items.Clear();
                ddl_slab.Items.Add("Slab");
            }
            if (ddl_percentage.Items.Count > 0)
            {
                ddl_percentage.Items.Clear();
                ddl_percentage.Items.Add("Percentage");
            }
            //btnSave.Enabled = false;

            btnSave.Enabled = true;
            btnSave.ToolTip = "Save";

            btnSave1.Attributes["class"] = "btn ico-save";
        }

        protected void grdBusinesscard_PreRender(object sender, EventArgs e)
        {
            if (grdBusinesscard.Rows.Count > 0)
            {
                grdBusinesscard.UseAccessibleHeader = true;
                grdBusinesscard.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        public static string DineshhttpPostWebRequets(string url, string postData)
        {
            string strResponse = null;
            string dataval = null;
            if (System.Net.ServicePointManager.MaxServicePointIdleTime > 10000)
            {
                System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;
            }
            if (System.Net.ServicePointManager.MaxServicePoints != 0) //unlimit
                System.Net.ServicePointManager.MaxServicePoints = 0;
            // System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            //System.Net.ServicePointManager.SecurityProtocol =  SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 |  SecurityProtocolType.Tls;
            try
            {
                var webRequest = System.Net.WebRequest.Create(url);
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.Timeout = 120000;
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    webRequest.ContentType = "application/xml";
                    //webRequest.Headers.Add("Token", "ceadc473-7dc7-42f9-a99b-63ae924a8adb");
                    //webRequest.Headers.Add("Basic", "prs_aP1Test", "uDe2Ln)3");
                    //String username = "prs_aP1Test";--test
                    //String password = "uDe2Ln)3";
                    String username = "prs_ap1"; //live
                    String password = "k_EwoN2r";
                    String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
                    webRequest.Headers.Add("Authorization", "Basic " + encoded);

                    webRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = webRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Close();
                        using (Stream s = webRequest.GetResponse().GetResponseStream())
                        {
                            using (StreamReader sr = new StreamReader(s))
                            {
                                strResponse = sr.ReadToEnd();
                            }
                        }
                    }
                }
                webRequest = null;
            }
            catch (Exception ex)
            {

            }
            return strResponse;
        }

        public static string DineshhttpPostWebRequets4Coload(string url, string postData)
        {
            string strResponse = null;
            string dataval = null;
            if (System.Net.ServicePointManager.MaxServicePointIdleTime > 10000)
            {
                System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;
            }
            if (System.Net.ServicePointManager.MaxServicePoints != 0) //unlimit
                System.Net.ServicePointManager.MaxServicePoints = 0;
            // System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            //System.Net.ServicePointManager.SecurityProtocol =  SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 |  SecurityProtocolType.Tls;
            try
            {
                var webRequest = System.Net.WebRequest.Create(url);
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.Timeout = 120000;
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    webRequest.ContentType = "application/xml";
                    //webRequest.Headers.Add("Token", "ceadc473-7dc7-42f9-a99b-63ae924a8adb");
                    //webRequest.Headers.Add("Basic", "prs_aP1Test", "uDe2Ln)3");
                    String username = "prs_aP1Test";//test
                    String password = "uDe2Ln)3";

                    String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
                    webRequest.Headers.Add("Authorization", "Basic " + encoded);

                    webRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = webRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Close();
                        using (Stream s = webRequest.GetResponse().GetResponseStream())
                        {
                            using (StreamReader sr = new StreamReader(s))
                            {
                                strResponse = sr.ReadToEnd();
                            }
                        }
                    }
                }
                webRequest = null;
            }
            catch (Exception ex)
            {

            }
            return strResponse;
        }

        protected void btn_xml_Click(object sender, EventArgs e)
        {
            string ctype; //cust type for xml upload
            //coload cond chk
            if (ChkCoload.Checked == true && txt_Coloadercode.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Please  Enter The Coloader Code');", true);
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please  Enter The Coloader Code')", true);
                txt_Coloadercode.Focus();
                blerr = true;
                return;
            }
            if (ChkCoload.Checked == false && txt_Coloadercode.Text != "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Please  Select IsCoload');", true);
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please  Select IsCoload')", true);
                ChkCoload.Focus();
                blerr = true;
                return;
            }
            if (ChkCoload.Checked == false && txt_ColoadRemarks.Text != "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Please  Select IsCoload');", true);
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please  Select IsCoload')", true);
                ChkCoload.Focus();
                blerr = true;
                return;
            }
            if (ChkCoload.Checked == false && txt_ColoadRemarks.Text != "" && txt_Coloadercode.Text != "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Please  Select IsCoload');", true);
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please  Select IsCoload')", true);
                ChkCoload.Focus();
                blerr = true;
                return;
            }
            if (ChkCoload.Checked == true)
            {
                ctype = "C";
            }
            else
            {
                ctype = "S";
            }
            //end
            DataTable dt1 = new DataTable();
            dt1 = obj_MasterCustomer.GetShipperdtls(Convert.ToInt32(hf_customerid.Value), ctype);
            if (dt1.Rows.Count > 0)
            {
                Hidden_fullname.Value = dt1.Rows[0]["fullname"].ToString();
                Hidden_shippercode.Value = dt1.Rows[0]["shippercode"].ToString();
                Hidden_Add1.Value = dt1.Rows[0]["add1"].ToString();
                Hidden_Add2.Value = dt1.Rows[0]["add2"].ToString();
                Hidden_city.Value = dt1.Rows[0]["city"].ToString();
                Hidden_country.Value = dt1.Rows[0]["country"].ToString();
                Hidden_createdby.Value = dt1.Rows[0]["createdby"].ToString();
                Hidden_createdon.Value = dt1.Rows[0]["createdon"].ToString();
                Hidden_status.Value = dt1.Rows[0]["status"].ToString();
                Hidden_email.Value = dt1.Rows[0]["email"].ToString();
                Hidden_ph.Value = dt1.Rows[0]["phone"].ToString();
                Hidden_offcode.Value = dt1.Rows[0]["officecode"].ToString();
                Hidden_zip.Value = dt1.Rows[0]["zip"].ToString();
                Hidden_state.Value = dt1.Rows[0]["state"].ToString();
                Hidden_cityname.Value = dt1.Rows[0]["cityname"].ToString();
                if (ChkCoload.Checked == true && txt_Coloadercode.Text != "")
                {
                    fn_Coloadxml();
                }
                else if (Hidden_city.Value.Length == 5)
                {
                    fn_xml();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Kindly update correct portcode in master for the city " + Hidden_cityname.Value + " ');", true);
                }
            }
        }

        public static DataTable BuildDataTableFromXml(string Name, string XMLString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(XMLString));
            DataTable Dt = new DataTable(Name);
            try
            {
                XmlNode NodoEstructura = doc.FirstChild.FirstChild;
                //  Table structure (columns definition)
                foreach (XmlNode columna in NodoEstructura.ChildNodes)
                {
                    Dt.Columns.Add(columna.Name, typeof(String));
                }
                XmlNode Filas = doc.FirstChild;
                //  Data Rows
                foreach (XmlNode Fila in Filas.ChildNodes)
                {
                    List<string> Valores = new List<string>();
                    foreach (XmlNode Columna in Fila.ChildNodes)
                    {
                        Valores.Add(Columna.InnerText);
                    }
                    Dt.Rows.Add(Valores.ToArray());
                }
            }
            catch (Exception)
            {

            }
            return Dt;
        }

        public void fn_Coloadxml()
        {
          //  DataAccess.LogDetails objLog = new DataAccess.LogDetails();
            string Str_Xml = ""; string Str_XmlCoload = "";
            string path = "";
            string dat = objLog.GetDate().ToString();
            string dat1 = dat.Replace("/", "-");
            string dat2 = dat1.Replace(" ", "-");
            string date = dat2.Replace(":", "_");
            //coloader tag feb 10 2022
            Str_XmlCoload += "<Shipper>";
            Str_XmlCoload += "<GeneralInfo>";
            Str_XmlCoload += "<SupplierCode>" + txt_Coloadercode.Text + "</SupplierCode>";
            Str_XmlCoload += "<ShortName>" + "" + "</ShortName>";
            Str_XmlCoload += "<Fullname>" + Hidden_fullname.Value.Replace("&", "&amp;") + "</Fullname>";
            Str_XmlCoload += "<LocalFullName>" + "" + "</LocalFullName>";
            Str_XmlCoload += "<RequestOffice>" + Hidden_offcode.Value + "</RequestOffice>";//mandatory
            Str_XmlCoload += "<RequestBy>" + Hidden_createdby.Value + "</RequestBy>";
            Str_XmlCoload += "<RequestDate>" + objLog.GetDate().ToString("yyyy-MM-dd") + "</RequestDate>";
            Str_XmlCoload += "<MemoByRequester>" + "" + "</MemoByRequester>";
            Str_XmlCoload += "<MemoByManagement>" + "" + "</MemoByManagement>";
            Str_XmlCoload += "<Remarks>" + "" + "</Remarks>";
            Str_XmlCoload += "<NameLock>" + "" + "</NameLock>";
            Str_XmlCoload += "<AddressLock>" + "" + "</AddressLock>";
            Str_XmlCoload += "<NotallowtoprintHBL>" + "" + "</NotallowtoprintHBL>";
            Str_XmlCoload += "<CreditTerm>" + "" + "</CreditTerm>";
            Str_XmlCoload += "<ReserveTaxpayerID>" + "" + "</ReserveTaxpayerID>";
            Str_XmlCoload += "<CompanyID>" + "" + "</CompanyID>";
            Str_XmlCoload += "<IsColoader>" + "Y" + "</IsColoader>"; ///coload tag
            Str_XmlCoload += "<ColoaderRemarks>" + txt_ColoadRemarks.Text + "</ColoaderRemarks>"; ///coload tag
            Str_XmlCoload += "<Status>" + Hidden_status.Value + "</Status>";
            Str_XmlCoload += "</GeneralInfo>";

            Str_XmlCoload += "<MainAddressinEnglish>";
            Str_XmlCoload += "<AddressLine1>" + Hidden_Add1.Value + "</AddressLine1>";
            Str_XmlCoload += "<AddressLine2>" + Hidden_Add2.Value + "</AddressLine2>";
            Str_XmlCoload += "<AddressLine3>" + "" + "</AddressLine3>";
            Str_XmlCoload += "<AddressLine4>" + "" + "</AddressLine4>";
            Str_XmlCoload += "<City>" + Hidden_city.Value + "</City>";//portcode=IN
            Str_XmlCoload += "<State>" + Hidden_state.Value + "</State>";//statelist
            Str_XmlCoload += "<ZipPostal>" + Hidden_zip.Value + "</ZipPostal>";
            Str_XmlCoload += "<Country>" + Hidden_country.Value + "</Country>";
            Str_XmlCoload += "</MainAddressinEnglish> ";

            Str_XmlCoload += "<MainAddressinLocalLanguage> ";
            Str_XmlCoload += "<AddressLine1>" + "" + "</AddressLine1>";
            Str_XmlCoload += "<AddressLine2>" + "" + "</AddressLine2>";
            Str_XmlCoload += "<AddressLine3>" + "" + "</AddressLine3>";
            Str_XmlCoload += "<AddressLine4>" + "" + "</AddressLine4>";
            Str_XmlCoload += "<City>" + "" + "</City>";
            Str_XmlCoload += "<State>" + "" + "</State>";
            Str_XmlCoload += "<ZipPostal>" + "" + "</ZipPostal>";
            Str_XmlCoload += "<Country>" + "" + "</Country>";
            Str_XmlCoload += "</MainAddressinLocalLanguage> ";

            Str_XmlCoload += "<VATAddressinEnglish> ";
            Str_XmlCoload += "<AddressLine1>" + "" + "</AddressLine1>";
            Str_XmlCoload += "<AddressLine2>" + "" + "</AddressLine2>";
            Str_XmlCoload += "<AddressLine3>" + "" + "</AddressLine3>";
            Str_XmlCoload += "<AddressLine4>" + "" + "</AddressLine4>";
            Str_XmlCoload += "<City>" + "" + "</City>";
            Str_XmlCoload += "<State>" + "" + "</State>";
            Str_XmlCoload += "<ZipPostal>" + "" + "</ZipPostal>";
            Str_XmlCoload += "<Country>" + "" + "</Country>";
            Str_XmlCoload += "</VATAddressinEnglish> ";

            Str_XmlCoload += "<VATAddressinLocalLanguage> ";
            Str_XmlCoload += "<AddressLine1>" + "" + "</AddressLine1>";
            Str_XmlCoload += "<AddressLine2>" + "" + "</AddressLine2>";
            Str_XmlCoload += "<AddressLine3>" + "" + "</AddressLine3>";
            Str_XmlCoload += "<AddressLine4>" + "" + "</AddressLine4>";
            Str_XmlCoload += "<City>" + "" + "</City>";
            Str_XmlCoload += "<State>" + "" + "</State>";
            Str_XmlCoload += "<ZipPostal>" + "" + "</ZipPostal>";
            Str_XmlCoload += "<Country>" + "" + "</Country>";
            Str_XmlCoload += "</VATAddressinLocalLanguage>";

            Str_XmlCoload += "<CompanyContact>";
            Str_XmlCoload += "<ContactPerson>" + "" + "</ContactPerson>";
            Str_XmlCoload += "<Position>" + "" + "</Position>";
            Str_XmlCoload += "<Email>" + Hidden_email.Value + "</Email>";//mandate
            Str_XmlCoload += "<Phone>" + Hidden_ph.Value + "</Phone>";//mandate
            Str_XmlCoload += "<Fax>" + "" + "</Fax>";
            Str_XmlCoload += "</CompanyContact>";

            Str_XmlCoload += "<BillingContact>";
            Str_XmlCoload += "<ContactPerson>" + "" + "</ContactPerson>";
            Str_XmlCoload += "<Position>" + "" + "</Position>";
            Str_XmlCoload += "<Email>" + "" + "</Email> ";
            Str_XmlCoload += "<Phone>" + "" + "</Phone>";
            Str_XmlCoload += "<Fax>" + "" + "</Fax>";
            Str_XmlCoload += "</BillingContact> ";

            Str_XmlCoload += "<OtherContact> ";
            Str_XmlCoload += "<ContactPerson>" + "" + "</ContactPerson>";
            Str_XmlCoload += "<Position>" + "" + "</Position>";
            Str_XmlCoload += "<Email>" + "" + "</Email>";
            Str_XmlCoload += "<Phone>" + "" + "</Phone>";
            Str_XmlCoload += "<Fax>" + "" + "</Fax>";
            Str_XmlCoload += "</OtherContact>";

            Str_XmlCoload += "<Ledger>";
            Str_XmlCoload += "<LedgerCode>" + "" + "</LedgerCode>";
            Str_XmlCoload += "<SunSuffix>" + "" + "</SunSuffix>";
            Str_XmlCoload += "<SUN4xAccountCode>" + "" + "</SUN4xAccountCode>";
            Str_XmlCoload += "<BatchPaymentAR>" + "" + "</BatchPaymentAR>";
            Str_XmlCoload += "<BatchPaymentAP>" + "" + "</BatchPaymentAP>";
            Str_XmlCoload += "</Ledger> ";

            Str_XmlCoload += "<LedgerBankDetails>";
            Str_XmlCoload += "<LedgerCode>" + "" + "</LedgerCode>";
            Str_XmlCoload += "<BankName>" + "" + "</BankName>";
            Str_XmlCoload += "<BankAccountNo>" + "" + "</BankAccountNo>";
            Str_XmlCoload += "<AccountCurrency>" + "" + "</AccountCurrency>";//changed
            Str_XmlCoload += "</LedgerBankDetails>";

            Str_XmlCoload += "<LedgerCreditLimit>";
            Str_XmlCoload += "<LedgerCode>" + "" + "</LedgerCode>";
            Str_XmlCoload += "<PaymentTermsAR>" + "" + "</PaymentTermsAR>";
            Str_XmlCoload += "<PaymentTermsAP>" + "" + "</PaymentTermsAP>";
            Str_XmlCoload += "<CreditLimit>" + "" + "</CreditLimit>";
            Str_XmlCoload += "<CreditDeadline>" + "" + "</CreditDeadline>";
            Str_XmlCoload += "</LedgerCreditLimit>";

            Str_XmlCoload += "<LedgerCustomerTax>";
            Str_XmlCoload += "<LedgerCode>" + "" + "</LedgerCode>";
            Str_XmlCoload += "<TaxType>" + "" + "</TaxType>";
            Str_XmlCoload += "<TaxIDNumber>" + "" + "</TaxIDNumber>";
            Str_XmlCoload += "<InvoiceSubType>" + "" + "</InvoiceSubType>";
            Str_XmlCoload += "<TaxRate>" + "" + "</TaxRate>";
            Str_XmlCoload += "</LedgerCustomerTax>";
            Str_XmlCoload += "</Shipper>";

            Str_XmlCoload.Replace("&", "&amp;");

            //string xmlcoloadresp = DineshhttpPostWebRequets("https://insight.cargoemotion.com/TBC", Str_XmlCoload); //coloader response
            string xmlcoloadresp = DineshhttpPostWebRequets4Coload(hid_coloadlink.Value, Str_XmlCoload); //coloader response

            DataTable dtxmlcoload = BuildDataTableFromXml("Data", xmlcoloadresp);
            if (dtxmlcoload.Rows.Count > 0)
            {
                obj_MasterCustomer.INSmastercustomersiscodeupdate(Convert.ToInt32(hf_customerid.Value), dtxmlcoload.Rows[0][0].ToString(), dtxmlcoload.Rows[1][0].ToString(), Convert.ToInt32(Session["LoginEmpId"].ToString()));
            }
            if (Str_XmlCoload != "")
            {
               // DataAccess.FEEvents objFEevent = new DataAccess.FEEvents();
                DataTable Dt = objFEevent.GetCustomerEDIMailId(Convert.ToInt32(Session["LoginEmpId"]));

                string Filename = txtcustomer.Text.Trim() + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
                Filename = Regex.Replace(Filename, @"[^0-9a-zA-Z]+", "");
                path = Server.MapPath(@"EDI\" + Filename + ".xml");
                string str_fullpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                str_fullpath = Server.MapPath("~/Maintenance/EDI/");
                try
                {
                    if (Directory.Exists(str_fullpath))
                    {
                        //Directory.CreateDirectory(filePath);
                        foreach (string file in Directory.GetFiles(str_fullpath))
                        {
                            File.Delete(file);
                        }
                    }
                }
                catch (Exception)
                {

                }
                XmlDocument XMLDocument = new XmlDocument();
                XMLDocument.LoadXml(Str_XmlCoload.ToString());
                XMLDocument.Save(path);
                DataTable Dtmsg = obj_MasterCustomer.Getstatus4custxml(Convert.ToInt32(hf_customerid.Value));
                if (Dt.Rows.Count > 0)
                {
                    if (Dt.Rows[0]["FromMailid"].ToString() != "" && Dt.Rows[0]["MailPwd"].ToString() != "")
                    {
                        if (Dtmsg.Rows.Count > 0)
                        {
                            if (Dtmsg.Rows[0]["status"].ToString() == "SUCCESSFULL")
                            {
                                Utility.SendMail(Dt.Rows[0]["FromMailid"].ToString(), Dt.Rows[0]["Tomailid"].ToString(), "File Name : " + Filename + "   /   " + "Uploaded On :" + objLog.GetDate().ToString("dd/MMM/yyyy"),
                                    "Customer Details file has been Uploaded into FTP Successfully", path, Dt.Rows[0]["MailPwd"].ToString(), Dt.Rows[0]["BCCmailid"].ToString(), Dt.Rows[0]["CCmailid"].ToString());
                            }
                            else
                            {
                                Utility.SendMail(Dt.Rows[0]["FromMailid"].ToString(), Dt.Rows[0]["Tomailid"].ToString(), "File Name : " + Filename + "   /   " + "Uploaded On :" + objLog.GetDate().ToString("dd/MMM/yyyy"),
                                                              "File Upload " + Dtmsg.Rows[0]["status"].ToString() + " . Error Message : " + Dtmsg.Rows[0]["errormsg"].ToString(), path, Dt.Rows[0]["MailPwd"].ToString(), Dt.Rows[0]["BCCmailid"].ToString(), Dt.Rows[0]["CCmailid"].ToString());
                            }
                        }
                    }
                }
                GetCustxmlstatus();
            }
            //end
        }

        public void fn_xml()
        {
           // DataAccess.LogDetails objLog = new DataAccess.LogDetails();
            string Str_Xml = ""; string Str_XmlCoload = "";
            string path = "";
            string dat = objLog.GetDate().ToString();
            string dat1 = dat.Replace("/", "-");
            string dat2 = dat1.Replace(" ", "-");
            string date = dat2.Replace(":", "_");
            Str_Xml += "<Shipper>";
            Str_Xml += "<GeneralInfo>";
            Str_Xml += "<ShipperCode>" + Hidden_shippercode.Value + "</ShipperCode>";
            Str_Xml += "<ShortName>" + "" + "</ShortName>";
            Str_Xml += "<Fullname>" + Hidden_fullname.Value.Replace("&", "&amp;") + "</Fullname>";
            Str_Xml += "<LocalFullName>" + "" + "</LocalFullName>";
            Str_Xml += "<RequestOffice>" + Hidden_offcode.Value + "</RequestOffice>";//mandatory
            Str_Xml += "<RequestBy>" + Hidden_createdby.Value + "</RequestBy>";
            Str_Xml += "<RequestDate>" + objLog.GetDate().ToString("yyyy-MM-dd") + "</RequestDate>";
            Str_Xml += "<MemoByRequester>" + "" + "</MemoByRequester>";
            Str_Xml += "<MemoByManagement>" + "" + "</MemoByManagement>";
            Str_Xml += "<Remarks>" + "" + "</Remarks>";
            Str_Xml += "<NameLock>" + "" + "</NameLock>";
            Str_Xml += "<AddressLock>" + "" + "</AddressLock>";
            Str_Xml += "<NotallowtoprintHBL>" + "" + "</NotallowtoprintHBL>";
            Str_Xml += "<CreditTerm>" + "" + "</CreditTerm>";
            Str_Xml += "<ReserveTaxpayerID>" + "" + "</ReserveTaxpayerID>";
            Str_Xml += "<CompanyID>" + "" + "</CompanyID>";
            Str_Xml += "<Status>" + Hidden_status.Value + "</Status>";
            Str_Xml += "</GeneralInfo>";

            Str_Xml += "<MainAddressinEnglish>";
            Str_Xml += "<AddressLine1>" + Hidden_Add1.Value + "</AddressLine1>";
            Str_Xml += "<AddressLine2>" + Hidden_Add2.Value + "</AddressLine2>";
            Str_Xml += "<AddressLine3>" + "" + "</AddressLine3>";
            Str_Xml += "<AddressLine4>" + "" + "</AddressLine4>";
            Str_Xml += "<City>" + Hidden_city.Value + "</City>";//portcode=IN
            Str_Xml += "<State>" + Hidden_state.Value + "</State>";//statelist
            Str_Xml += "<ZipPostal>" + Hidden_zip.Value + "</ZipPostal>";
            Str_Xml += "<Country>" + Hidden_country.Value + "</Country>";
            Str_Xml += "</MainAddressinEnglish> ";

            Str_Xml += "<MainAddressinLocalLanguage> ";
            Str_Xml += "<AddressLine1>" + "" + "</AddressLine1>";
            Str_Xml += "<AddressLine2>" + "" + "</AddressLine2>";
            Str_Xml += "<AddressLine3>" + "" + "</AddressLine3>";
            Str_Xml += "<AddressLine4>" + "" + "</AddressLine4>";
            Str_Xml += "<City>" + "" + "</City>";
            Str_Xml += "<State>" + "" + "</State>";
            Str_Xml += "<ZipPostal>" + "" + "</ZipPostal>";
            Str_Xml += "<Country>" + "" + "</Country>";
            Str_Xml += "</MainAddressinLocalLanguage> ";

            Str_Xml += "<VATAddressinEnglish> ";
            Str_Xml += "<AddressLine1>" + "" + "</AddressLine1>";
            Str_Xml += "<AddressLine2>" + "" + "</AddressLine2>";
            Str_Xml += "<AddressLine3>" + "" + "</AddressLine3>";
            Str_Xml += "<AddressLine4>" + "" + "</AddressLine4>";
            Str_Xml += "<City>" + "" + "</City>";
            Str_Xml += "<State>" + "" + "</State>";
            Str_Xml += "<ZipPostal>" + "" + "</ZipPostal>";
            Str_Xml += "<Country>" + "" + "</Country>";
            Str_Xml += "</VATAddressinEnglish> ";

            Str_Xml += "<VATAddressinLocalLanguage> ";
            Str_Xml += "<AddressLine1>" + "" + "</AddressLine1>";
            Str_Xml += "<AddressLine2>" + "" + "</AddressLine2>";
            Str_Xml += "<AddressLine3>" + "" + "</AddressLine3>";
            Str_Xml += "<AddressLine4>" + "" + "</AddressLine4>";
            Str_Xml += "<City>" + "" + "</City>";
            Str_Xml += "<State>" + "" + "</State>";
            Str_Xml += "<ZipPostal>" + "" + "</ZipPostal>";
            Str_Xml += "<Country>" + "" + "</Country>";
            Str_Xml += "</VATAddressinLocalLanguage>";

            Str_Xml += "<CompanyContact>";
            Str_Xml += "<ContactPerson>" + "" + "</ContactPerson>";
            Str_Xml += "<Position>" + "" + "</Position>";
            Str_Xml += "<Email>" + Hidden_email.Value + "</Email>";//mandate
            Str_Xml += "<Phone>" + Hidden_ph.Value + "</Phone>";//mandate
            Str_Xml += "<Fax>" + "" + "</Fax>";
            Str_Xml += "</CompanyContact>";

            Str_Xml += "<BillingContact>";
            Str_Xml += "<ContactPerson>" + "" + "</ContactPerson>";
            Str_Xml += "<Position>" + "" + "</Position>";
            Str_Xml += "<Email>" + "" + "</Email> ";
            Str_Xml += "<Phone>" + "" + "</Phone>";
            Str_Xml += "<Fax>" + "" + "</Fax>";
            Str_Xml += "</BillingContact> ";

            Str_Xml += "<OtherContact> ";
            Str_Xml += "<ContactPerson>" + "" + "</ContactPerson>";
            Str_Xml += "<Position>" + "" + "</Position>";
            Str_Xml += "<Email>" + "" + "</Email>";
            Str_Xml += "<Phone>" + "" + "</Phone>";
            Str_Xml += "<Fax>" + "" + "</Fax>";
            Str_Xml += "</OtherContact>";

            Str_Xml += "<Ledger>";
            Str_Xml += "<LedgerCode>" + "" + "</LedgerCode>";
            Str_Xml += "<SunSuffix>" + "" + "</SunSuffix>";
            Str_Xml += "<SUN4xAccountCode>" + "" + "</SUN4xAccountCode>";
            Str_Xml += "<BatchPaymentAR>" + "" + "</BatchPaymentAR>";
            Str_Xml += "<BatchPaymentAP>" + "" + "</BatchPaymentAP>";
            Str_Xml += "</Ledger> ";

            Str_Xml += "<LedgerBankDetails>";
            Str_Xml += "<LedgerCode>" + "" + "</LedgerCode>";
            Str_Xml += "<BankName>" + "" + "</BankName>";
            Str_Xml += "<BankAccountNo>" + "" + "</BankAccountNo>";
            Str_Xml += "<AccountCurrency>" + "" + "</AccountCurrency>";//changed
            Str_Xml += "</LedgerBankDetails>";

            Str_Xml += "<LedgerCreditLimit>";
            Str_Xml += "<LedgerCode>" + "" + "</LedgerCode>";
            Str_Xml += "<PaymentTermsAR>" + "" + "</PaymentTermsAR>";
            Str_Xml += "<PaymentTermsAP>" + "" + "</PaymentTermsAP>";
            Str_Xml += "<CreditLimit>" + "" + "</CreditLimit>";
            Str_Xml += "<CreditDeadline>" + "" + "</CreditDeadline>";
            Str_Xml += "</LedgerCreditLimit>";

            Str_Xml += "<LedgerCustomerTax>";
            Str_Xml += "<LedgerCode>" + "" + "</LedgerCode>";
            Str_Xml += "<TaxType>" + "" + "</TaxType>";
            Str_Xml += "<TaxIDNumber>" + "" + "</TaxIDNumber>";
            Str_Xml += "<InvoiceSubType>" + "" + "</InvoiceSubType>";
            Str_Xml += "<TaxRate>" + "" + "</TaxRate>";
            Str_Xml += "</LedgerCustomerTax>";
            Str_Xml += "</Shipper>";

            Str_Xml = Str_Xml.Replace("&", "&amp;");

            //string xmrespos = DineshhttpPostWebRequets("https://insight.mrhkg.com/prsapi/party/in-shipper", Str_Xml);--test
            string xmrespos = DineshhttpPostWebRequets("https://insight.cargoemotion.com/prsapi/party/in-shipper", Str_Xml);//live
            DataTable dtxml = BuildDataTableFromXml("Data", xmrespos);
            if (dtxml.Rows.Count > 0)
            {
                obj_MasterCustomer.INSmastercustomersiscodeupdate(Convert.ToInt32(hf_customerid.Value), dtxml.Rows[0][0].ToString(), dtxml.Rows[1][0].ToString(), Convert.ToInt32(Session["LoginEmpId"].ToString()));
            }
            if (Str_Xml != "")
            {
             //   DataAccess.FEEvents objFEevent = new DataAccess.FEEvents();
                DataTable Dt = objFEevent.GetCustomerEDIMailId(Convert.ToInt32(Session["LoginEmpId"]));

                string Filename = txtcustomer.Text.Trim() + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
                Filename = Regex.Replace(Filename, @"[^0-9a-zA-Z]+", "");
                path = Server.MapPath(@"EDI\" + Filename + ".xml");
                string str_fullpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                str_fullpath = Server.MapPath("~/Maintenance/EDI/");
                try
                {
                    if (Directory.Exists(str_fullpath))
                    {
                        //Directory.CreateDirectory(filePath);
                        foreach (string file in Directory.GetFiles(str_fullpath))
                        {
                            File.Delete(file);
                        }
                    }
                }
                catch (Exception)
                {

                }
                XmlDocument XMLDocument = new XmlDocument();
                XMLDocument.LoadXml(Str_Xml.ToString());
                XMLDocument.Save(path);
                DataTable Dtmsg = obj_MasterCustomer.Getstatus4custxml(Convert.ToInt32(hf_customerid.Value));

                if (Dt.Rows.Count > 0)
                {
                    if (Dt.Rows[0]["FromMailid"].ToString() != "" && Dt.Rows[0]["MailPwd"].ToString() != "")
                    {
                        if (Dtmsg.Rows.Count > 0)
                        {
                            if (Dtmsg.Rows[0]["status"].ToString() == "SUCCESSFULL")
                            {
                                Utility.SendMail(Dt.Rows[0]["FromMailid"].ToString(), Dt.Rows[0]["Tomailid"].ToString(), "File Name : " + Filename + "   /   " + "Uploaded On :" + objLog.GetDate().ToString("dd/MMM/yyyy"),
                                    "Customer Details file has been Uploaded into FTP Successfully", path, Dt.Rows[0]["MailPwd"].ToString(), Dt.Rows[0]["BCCmailid"].ToString(), Dt.Rows[0]["CCmailid"].ToString());
                            }
                            else
                            {
                                Utility.SendMail(Dt.Rows[0]["FromMailid"].ToString(), Dt.Rows[0]["Tomailid"].ToString(), "File Name : " + Filename + "   /   " + "Uploaded On :" + objLog.GetDate().ToString("dd/MMM/yyyy"),
                                                              "File Upload " + Dtmsg.Rows[0]["status"].ToString() + " . Error Message : " + Dtmsg.Rows[0]["errormsg"].ToString(), path, Dt.Rows[0]["MailPwd"].ToString(), Dt.Rows[0]["BCCmailid"].ToString(), Dt.Rows[0]["CCmailid"].ToString());
                            }
                        }
                    }
                }
                GetCustxmlstatus();
            }
        }

        public void GetCustxmlstatus()
        {
            try
            {
                DataTable Dt = obj_MasterCustomer.Getstatus4custxml(Convert.ToInt32(hf_customerid.Value));
                if (Dt.Rows.Count > 0)
                {
                    if (!String.IsNullOrEmpty(Dt.Rows[0]["Updatedby"].ToString()) && !String.IsNullOrEmpty(Dt.Rows[0]["Updatedon"].ToString()))
                    {
                        if (Dt.Rows[0]["status"].ToString() == "SUCCESSFULL")
                        {
                            lblxmlstatus.Text = "XML Upload Status :Customer EDI  File Generated and Uploaded into FTP Successfully On " + Dt.Rows[0]["Updatedon"].ToString() + " By  " + Dt.Rows[0]["Updatedby"].ToString() + "";
                        }
                        else if (Dt.Rows[0]["status"].ToString() == "FAILED")
                        {
                            lblxmlstatus.Text = "XML Upload Status : File Upload " + Dt.Rows[0]["status"].ToString() + " . Error Message : " + Dt.Rows[0]["errormsg"].ToString();
                        }
                        else
                        {
                            lblxmlstatus.Text = "XML Upload Status : No Upload History ";
                        }
                    }
                    else
                    {
                        lblxmlstatus.Text = "XML Upload Status : No Upload History ";
                    }
                }
                else
                {
                    lblxmlstatus.Text = "XML Upload Status : No Upload History ";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString().Replace("'", "");
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void ChkCoload_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCoload.Checked == true)
            {
                txt_ColoadRemarks.Enabled = true;
                txt_Coloadercode.Enabled = true;
                Coload = "Y";
            }
            else
            {
                txt_ColoadRemarks.Enabled = false;
                txt_Coloadercode.Enabled = false;
                Coload = "N";
                txt_ColoadRemarks.Text = "";
                txt_Coloadercode.Text = "";
            }
        }

        private void ddlCustomerTypefill()
        {
            DataTable dttype = new DataTable();
            ddlIDProof.Items.Clear();
            dttype = obj_MasterCustomer.SPSelKYCProofCust("N");
            if (dttype.Rows.Count > 0)
            {
                ddlIDProof.Items.Add("");
                for (int i = 0; i <= dttype.Rows.Count - 1; i++)
                {
                    ddlIDProof.Items.Add(dttype.Rows[i]["Proofmaster"].ToString());
                }
            }
        }

        private void CheckDataforkyc()
        {
            if (ddlIDProof.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Customer IDProof Type cannot be Blank');", true);
                ddlIDProof.Focus();
                k = 0;
                return;
            }
            else if (!(KycUpload.HasFile))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('ID Proof of File DocPath cannot be Blank');", true);
                KycUpload.Focus();
                k = 0;
                return;
            }
        }

        private void savekyc()
        {
            CheckDataforkyc();
            if (k == 1)
            {
                if (hf_customerid.Value != "" && hf_customerid.Value != null)
                {
                    //if (Path.GetExtension(fuIDDoc.FileName) == ".pdf")
                    //{
                    if (ddlIDProof.Text == "Voter ID")
                    {
                        ddlid = 1;
                    }
                    if (ddlIDProof.Text == "PAN Card")
                    {
                        ddlid = 2;
                    }
                    if (ddlIDProof.Text == "Aadhar ID")
                    {
                        ddlid = 3;
                    }
                    if (ddlIDProof.Text == "GST")
                    {
                        ddlid = 4;
                    }
                    if (ddlIDProof.Text == "KYC")
                    {
                        ddlid = 5;
                    }
                    if (ddlIDProof.Text == "MSME certificate")
                    {
                        ddlid = 6;
                    }
                    if (ddlIDProof.Text == "Cancel Cheque")
                    {
                        ddlid = 7;
                    }
                    if (ddlIDProof.Text == "Credit form")
                    {
                        ddlid = 8;
                    }

                    KycUpload.SaveAs(Server.MapPath("~/UploadDocument/Proofs/" + hf_customerid.Value + "-" + ddlid + "-" + KycUpload.FileName));
                    c = (Server.MapPath("~/UploadDocument/Proofs/") + hf_customerid.Value + "-" + ddlid + "-" + Path.GetFileName(KycUpload.FileName));
                    idfilename = hf_customerid.Value + "-" + ddlid + "-" + Path.GetFileName(KycUpload.FileName);
                    IdProoffileupload(KycUpload.FileName, c);
                    //  obj_MasterCustomer.KycUpload(1, int.Parse(hf_customerid.Value), int.Parse(Session["LoginEmpId"].ToString()), ddlid, ddlIDProof.Text, idfilename);
                    if (txtPanNo.Text == "" && txtpancust.Text == "")
                    {
                        string data = hf_customerid.Value;
                        hid_pan.Value = data;
                    }

                    obj_MasterCustomer.KycUploadnew(1, int.Parse(hf_customerid.Value), int.Parse(Session["LoginEmpId"].ToString()), ddlid, ddlIDProof.Text, idfilename, Convert.ToInt32(hid_pan.Value));
                    System.IO.File.Delete(c);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('KYC Uploaded Successfully');", true);

                    //DataTable dt = (DataTable)ViewState["vst"];
                    //DataRow newrow = dt.NewRow();
                    //newrow["proof"] = ddlIDProof.Text;
                    //newrow["filename"] = fuIDDoc.FileName;
                    //newrow["path"] = c;
                    //dt.Rows.Add(newrow);
                    //dt.AcceptChanges();
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Upload Only PDF Files');", true);
                    //}
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Customer Name and Update KYC');", true);
                }
            }
        }

        private void IdProoffileupload(string filenames, string path)
        {
            //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
            //{
            //    DBCS = reader.ReadLine();
            //}
            //ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
            //dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
            //username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
            //password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();

            //b = Path.GetFileName(filenames);
            //a = "ftp://20.235.30.214/SL/KYC/" + hf_customerid.Value + "-" + ddlid + "-" + filenames;
            //FtpWebRequest req = (FtpWebRequest)(WebRequest.Create(a));
            //req.Credentials = new NetworkCredential(username, password);
            //req.Method = WebRequestMethods.Ftp.UploadFile;
            //req.Proxy = null;
            //byte[] file = System.IO.File.ReadAllBytes(path);
            //System.IO.Stream str = req.GetRequestStream();
            //str.Write(file, 0, file.Length);
            //str.Close();
            //str.Dispose();
            using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
            {
                DBCS = reader.ReadLine();

            }
            ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
            dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
            //username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
            //password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();
            // added on 25Mar2023 
            username = "vmadmin";
            password = "VMWeb20Mar@)@#";
            b = Path.GetFileName(filenames);
            a = "ftp://20.235.30.214/SL/KYC/" + hf_customerid.Value + "-" + ddlid + "-" + filenames;
            FtpWebRequest req = (FtpWebRequest)(WebRequest.Create(a));
            req.Credentials = new NetworkCredential(username, password);
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Proxy = null;
            byte[] file = System.IO.File.ReadAllBytes(path);
            System.IO.Stream str = req.GetRequestStream();
            str.Write(file, 0, file.Length);
            str.Close();
            str.Dispose();
        }


        public void kycGrid()
        {
            Pl_Proof.Visible = true;
            GrdProofkyc.Visible = true;
            DataTable GrdProofdt = new DataTable();
            //GrdProofdt = obj_MasterCustomer.GridKycproof(2, hf_customerid.Value);
            if (hf_customerid.Value != "")
            {
                string Type1;
                if (ddlCType.SelectedItem.Text == "Agent / Principal / Counter Part")
                {
                    Type1 = "P";
                }
                else if (ddlCType.SelectedItem.Text == "Depo")
                {
                    Type1 = "W";
                }
                else if (ddlcategory.SelectedValue == "5")
                {
                    Type1 = "P";
                }
                else if (ddlfacategory.SelectedValue == "4")
                {
                    Type1 = "P";
                }
                else
                {
                    Type1 = "C";
                }
                if (Type1 == "P")
                {
                    string data = hf_customerid.Value;
                    hid_pan.Value = data;
                }
                if (Type1 == "C" && ddlcategory.SelectedItem.Text == "Others")
                {
                    string data = hf_customerid.Value;
                    hid_pan.Value = data;
                }

                GrdProofdt = obj_MasterCustomer.KycUploadnew(2, int.Parse(hf_customerid.Value), int.Parse(Session["LoginEmpId"].ToString()), ddlid, ddlIDProof.Text, idfilename, Convert.ToInt32(hid_pan.Value));
                if (GrdProofdt.Rows.Count > 0)
                {
                    GrdProofkyc.DataSource = GrdProofdt;
                    GrdProofkyc.DataBind();
                }
                else
                {
                    DataTable dtp = new DataTable();
                    GrdProofkyc.DataSource = dtp;
                    GrdProofkyc.DataBind();
                }
            }
        }

        protected void btnkyc_Click(object sender, EventArgs e)
        {
            if (hf_customerid.Value != "" && hf_customerid.Value != "0")
            {

                if (GrdProofkyc.Rows.Count >= 0)
                {
                    for (int i = 0; i < GrdProofkyc.Rows.Count; i++)
                    {
                        if (GrdProofkyc.Rows[i].Cells[0].Text == ddlIDProof.Text)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ddlIDProof.Text + " Already Exist');", true);
                            return;
                        }
                    }
                }
                savekyc();
                kycGrid();
                ddlIDProof.SelectedIndex = 0;
                //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1730, 1, int.Parse(Session["LoginBranchid"].ToString()), hid_customerid + "-" + idfilepath + "-" + addfilepath);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('KYC Uploaded Successfully');", true);
                //txtclear();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Save Customer Details After that Update the Customer KYC');", true);
                return;
            }
        }

        protected void GrdProof_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = GrdProofkyc.SelectedRow.RowIndex;
                string filenamedownload = string.Empty;
                if (GrdProofkyc.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    if (txtcustomer.Text != "")
                    {
                        if (!string.IsNullOrWhiteSpace(GrdProofkyc.Rows[index].Cells[1].Text))
                        {
                            filenamedownload = GrdProofkyc.Rows[index].Cells[1].Text;
                            if (hf_customerid.Value != "")
                            {
                                //fttnormaldwd(filename1);
                                string Test = "0";
                                ScriptManager.RegisterStartupScript(GrdProofkyc, typeof(GridView), "Download", "window.open('../Download.aspx?Filename=" + filenamedownload + "&Test=" + Test + "');", true);
                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('PoD not yet updated for this pickslip #');", true);
                                return;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('No File To Download');", true);
                            txtcustomer.Focus();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Please Enter the Customer #');", true);
                        txtcustomer.Focus();
                    }
                }
            }
            catch
            {

            }
        }

        protected void GrdProof_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdbudget, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdProofkyc, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GrdProofkyc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    ImageButton Img_delete = (ImageButton)e.CommandSource;
                    GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
                    DataTable obj_dt = new DataTable();
                    string filename = "";
                    //obj_dt = (DataTable)Session["dt"];
                    if (!string.IsNullOrWhiteSpace(GrdProofkyc.Rows[grd.RowIndex].Cells[1].Text))
                    {
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "Voter ID")
                        {
                            ddlid1 = 1;
                        }
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "PAN Card")
                        {
                            ddlid1 = 2;
                        }
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "Aadhar ID")
                        {
                            ddlid1 = 3;
                        }
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "GST")
                        {
                            ddlid1 = 4;
                        }
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "KYC")
                        {
                            ddlid1 = 5;
                        }
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "MSME certificate")
                        {
                            ddlid1 = 6;
                        }
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "Cancel Cheque")
                        {
                            ddlid1 = 7;
                        }
                        if (GrdProofkyc.Rows[grd.RowIndex].Cells[0].Text == "Credit form")
                        {
                            ddlid1 = 8;
                        }
                        obj_MasterCustomer.kycDeleteProof(3, Convert.ToInt32(hf_customerid.Value), GrdProofkyc.Rows[grd.RowIndex].Cells[1].Text, ddlid1);
                        //obj_dt.Rows[grd.RowIndex].Delete();
                        //obj_dt.AcceptChanges();
                        filename = GrdProofkyc.Rows[grd.RowIndex].Cells[1].Text;
                        ftpKycdeleted(filename);
                        kycGrid();
                        //  ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('File has been deleted');", true);
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('File has been deleted');", true);
                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('No File To deleted');", true);
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('No File To deleted');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void ftpKycdeleted(string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
                {
                    DBCS = reader.ReadLine();
                }

                ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
                dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
                //username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
                //password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();
                // added on 25Mar2023 
                username = "vmadmin";
                password = "VMWeb20Mar@)@#";

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://20.235.30.214/SL/KYC/" + filename);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                // request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
                request.Credentials = new NetworkCredential(username, password);

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    //  return response.StatusDescription;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void GrdProofkyc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Button8_Click(object sender, EventArgs e)
        {

        }

        protected void btnpanadd_Click(object sender, EventArgs e)
        {
            //kalai guided
            string Paninput = "N";
            if (txtpancust.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly Enter The PAN CustomerName');", true);
                txtpancust.Focus();
                return;
            }
            if (ddlcategory.SelectedValue != "2") { 
            if (ddlfacategory.SelectedValue == "1")
            {
                if (txtPanNo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('PAN # mandatory for the bill to - supply to');", true);
                    txtPanNo.Focus();
                    return;
                }
            }
            }


            if (txtPanNo.Text == "")
            {
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly enter PAN #');", true);
                //txtPanNo.Focus();
                //return;

                // add 27/02/2023
               if (ddlcategory.SelectedValue == "0")
                {
                    if (ddlcategory.SelectedValue == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly Select the Category );", true);
                        ddl_branch.Focus();
                        return;
                    }
                }
                if (ddllegaltype.SelectedValue == "0")
                {
                    if (ddllegaltype.SelectedValue == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly Select the Type );", true);
                        ddl_branch.Focus();
                        return;
                    }
                }
                if (ddlfacategory.SelectedValue == "0")
                {
                    if (ddlfacategory.SelectedValue == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly Select the FA Category );", true);
                        ddl_branch.Focus();
                        return;
                    }
                }

                if (hid_panno.Value != "")
                {
                    Paninput = "Y";
                    txtPanNo.Text = hid_panno.Value;
                }
                else
                {
                    if (ddlcategory.SelectedItem.Text == "Agent")
                    {
                        string dates = DateTime.Now.ToString("ddMMyy");
                        string hoursminss = DateTime.Now.ToString("Hmm");
                        //string PanNoAuto = date + "" + hoursmins;
                        txtPanNo.Text = dates + "" + hoursminss;
                        Paninput = "Y";
                    }
                    else if (ddlcategory.SelectedItem.Text == "Others")
                    {
                        string dates = DateTime.Now.ToString("ddMMyy");
                        string hoursminss = DateTime.Now.ToString("Hmm");
                        //string PanNoAuto = date + "" + hoursmins;
                        txtPanNo.Text = dates + "" + hoursminss;
                        Paninput = "Y";
                    }
                    else if (ddlcategory.SelectedItem.Text == "Transporters" && txtPanNo.Text=="")
                    {
                        string dates = DateTime.Now.ToString("ddMMyy");
                        string hoursminss = DateTime.Now.ToString("Hmm");
                        //string PanNoAuto = date + "" + hoursmins;
                        txtPanNo.Text = dates + "" + hoursminss;
                        Paninput = "Y";
                    }
                    else
                    {
                        string date = DateTime.Now.ToString("ddMMyy");
                        string hoursmins = DateTime.Now.ToString("Hmm");
                        //string PanNoAuto = date + "" + hoursmins;
                        txtPanNo.Text = date + "" + hoursmins;
                        Paninput = "Y";
                    }
                }
            }


            //if (txt_uinno.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly enter UIN #');", true);
            //    txt_uinno.Focus();
            //    return;
            //}
            //if (txttanno.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly enter TAN #');", true);
            //    txttanno.Focus();
            //    return;
            //}
            if (ddllegaltype.SelectedValue != "")
            {
                if (ddllegaltype.SelectedValue == "1" || ddllegaltype.SelectedValue == "2" || ddllegaltype.SelectedValue == "3")
                {
                    //if (txtcinno.Text == "")
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly Enter CIN #');", true);
                    //    txtcinno.Focus();
                    //    return;
                    //}
                }
            }

            string Type1;
            if (ddlCType.SelectedItem.Text == "Agent / Principal / Counter Part")
            {
                Type1 = "P";
            }
            else if (ddlCType.SelectedItem.Text == "Depo")
            {
                Type1 = "W";
            }
            else if (ddlcategory.SelectedValue == "5")
            {
                Type1 = "P";
            }
            else if (ddlfacategory.SelectedValue == "4")
            {
                Type1 = "P";
            }
            else if (ddlcategory.SelectedValue == "6")
            {
                Type1 = "C";
                ddl_Option.SelectedItem.Text = "Not Applicable";
            }
            else
            {
                Type1 = "C";
            }
            Session["ctype"] = Type1;
            if (chkeinvoice.Checked == true)
            {
                hid_einvoice.Value = "Y";
            }
            else
            {
                hid_einvoice.Value = "N";
            }
            //if (Type1 == "C" && ddlcategory.SelectedItem.Text != "Others")
            //{
            //    if (txt_creditday.Text == "")
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly enter the creditdays');", true);
            //        txt_creditday.Focus();
            //        return;
            //    }
            //    if (txt_creditamount.Text == "")
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly enter the CreditAmount');", true);
            //        txt_creditamount.Focus();
            //        return;
            //    }
            //}
            txt_creditday.Text = "30";
            txt_creditamount.Text = "50,000";

            //if (ddl_per.SelectedValue == "0")
            //{
            //    if (ddl_per.SelectedValue == "")
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly Select the Per );", true);
            //        ddl_branch.Focus();
            //        return;
            //    }
            //}
            //if (txt_exemptions.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly enter the Exemptions');", true);
            //    txt_creditamount.Focus();
            //    return;
            //}
            //if (txt_overdue.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Kindly enter the Overdue');", true);
            //    txt_creditday.Focus();
            //    return;
            //}

            //if (ddl_description.SelectedItem.Text != "" && ddl_description.SelectedItem.Text != "Description")  //&& ddl_slab.SelectedItem.Text != "" && ddl_slab.SelectedItem.Text != "Slab" && ddl_type.SelectedItem.Text != "" && ddl_type.SelectedItem.Text != "Type" && ddl_percentage.SelectedItem.Text != "" && ddl_percentage.SelectedItem.Text != "Percentage")
            //{
            //    if (ddl_type.SelectedItem.Text != "" && ddl_type.SelectedItem.Text != "Type")
            //    {
            //        if (ddl_slab.SelectedItem.Text != "" && ddl_slab.SelectedItem.Text != "Slab")
            //        {
            //            if (ddl_percentage.SelectedItem.Text != "" && ddl_percentage.SelectedItem.Text != "Percentage")
            //            {
            //            }
            //            else
            //            {
            //                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Select Percentage');", true);
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Select Slab');", true);
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Select the Type')", true);
            //        return;
            //    }
            //}
            int Div_ID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
          //  DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();

            ownerID = 2;
            string dataower = ownerID.ToString();
            int exp;
            if (txt_exemptions.Text == "")
            {
                exp = 3;
            }
            else
            {
                exp = Convert.ToInt16(txt_exemptions.Text);
            }
            int due;
            if (txt_overdue.Text == "")
            {
                due = 50;
            }
            else
            {
                due = Convert.ToInt16(txt_overdue.Text);
            }
            string exmode = string.Empty;
            if (ddl_per.Text == "Annual")
            {
                exmode = "A";
            }
            else if (ddl_per.Text == "Month")
            {
                exmode = "M";
            }
            if (txt_Salesperson.Text == "")
            {
                hf_employeeid.Value = "";
            }
            if (hf_employeeid.Value == "0" || hf_employeeid.Value == "")
            {
                hf_employeeid.Value = "0";
            }

            if (txt_empfrom.Text == "")
            {
                string date = "01/01/1999";
                empfrom = DateTime.ParseExact(date, "dd/MM/yyyy", null);
            }
            else
            {
                empfrom = Convert.ToDateTime(Utility.fn_ConvertDate(txt_empfrom.Text));
            }
            if (txt_empto.Text == "")
            {
                string date = "01/01/1999";
                empto = DateTime.ParseExact(date, "dd/MM/yyyy", null);
            }
            else
            {
                empto = Convert.ToDateTime(Utility.fn_ConvertDate(txt_empto.Text));
            }
            if (txt_tds_exp.Text == "")
            {
                txt_tds_exp.Text = "0";
            }
            if (txt_limit.Text == "")
            {
                txt_limit.Text = "0.00";
            }


           
           
            if (txtPanNo.Text != "")
            {
                if (txtpancust.Text != "" && txtPanNo.Text != "")
                {
                    if (btnpanadd.ToolTip == "Save")
                    {
                       // DataAccess.Masters.MasterCustomerGroup obj_mainx = new DataAccess.Masters.MasterCustomerGroup();
                        DataTable dtsss = new DataTable();
                        dtsss = obj_mainx.customerpanidselects(txtPanNo.Text);
                        if (dtsss.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Customer Already Exists');", true);
                            return;
                        }
                        hid_panno.Value = "";
                        hid_pan.Value = "";
                        DataTable dtcus = obj_MasterCustomer.Insmastercustpandtls(txtPanNo.Text.ToUpper(), txtpancust.Text.ToUpper(), txttanno.Text.ToUpper(), txtcinno.Text.ToUpper(), txt_uinno.Text.ToUpper(), Convert.ToInt16(hf_employeeid.Value));
                        obj_MasterCustomer.Inscustpandtls(txtPanNo.Text.ToUpper(), txtpancust.Text.ToUpper(), Convert.ToInt32(ddllegaltype.SelectedValue), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlfacategory.SelectedValue));

                        obj_MasterCustomer.Sp_mastercustomerpancredit(dataower, Convert.ToDouble(txt_creditamount.Text), Convert.ToInt32(txt_creditday.Text), txtPanNo.Text, txtpancust.Text, Convert.ToInt32(exp), Convert.ToInt32(due), exmode);
                        //if (txt_limit.Text != "" && txt_tds_exp.Text != "")
                        //{

                        obj_MasterCustomer.PanUploadLimitDetails(Convert.ToDouble(txt_limit.Text), txtpancust.Text.ToUpper(), empfrom, empto, txt_certno.Text, Convert.ToDouble(txt_tds_exp.Text), txtPanNo.Text.ToString());
                        //}
                        //end
                        if (dtcus.Rows.Count > 0)
                        {
                            hid_pan.Value = dtcus.Rows[0]["MasterCustomerPANid"].ToString();
                        }
                        if (hid_pan.Value != "" && hid_einvoice.Value != "")
                        {
                            obj_MasterCustomer.UPdEnvoice4custpan(Convert.ToInt32(hid_pan.Value), hid_einvoice.Value);
                        }
                        txtcustomer.Text = txtpancust.Text;
                        if (ddlcategory.SelectedItem.Text == "Others")
                        {
                            ddl_Option.SelectedValue = "7";
                        }
                        hf_customerid.Value = "";
                        customernamehide.Value = "";
                        // update inputpan
                        //DataAccess.Masters.MasterCustomerGroup obj_mainx = new DataAccess.Masters.MasterCustomerGroup();
                        DataTable dtss = new DataTable();
                        dtss = obj_mainx.customerpanidselect(txtPanNo.Text, txtpancust.Text);
                        if (dtss.Rows.Count > 0)
                        {
                            hid_panno.Value = txtPanNo.Text;
                            hid_pan.Value = dtss.Rows[0]["CustomerPANId"].ToString();
                            if (hid_pan.Value != "")
                            {
                                obj_MasterCustomer.sp_paninputupdate(hid_pan.Value, txtpancust.Text.ToUpper(), Paninput);
                                if (Paninput == "Y")
                                {
                                    
                                    txtPanNo.Text = "";
                                    hidpaninput.Value = "Y";
                                }
                            }
                        }
                        // end
                        hf_customerid.Value = "";

                        txtcustomer.Enabled = false;
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('Customer Created.Kindly update location and other details');", true);
                        btnpanadd.ToolTip = "Update";
                        btnpanadd1.Attributes["class"] = "btn ico-update";
                    }
                    else if (btnpanadd.ToolTip == "Update")
                    {
                        DataTable dts = obj_MasterCustomer.SPgetallpannodetails(txtPanNo.Text);
                        if (dts.Rows.Count > 0)
                        {
                            hid_pan.Value = dts.Rows[0]["CustomerPANId"].ToString();
                        }
                        if (hid_pan.Value != "" && hid_pan.Value != "0")
                        {
                            int hiddenpannid = Convert.ToInt16(hid_pan.Value);
                            obj_MasterCustomer.sp_panupdatedetails(txtPanNo.Text.ToUpper(), txtpancust.Text, txttanno.Text, txtcinno.Text, txt_uinno.Text, Convert.ToInt16(hf_employeeid.Value), hiddenpannid);
                            obj_MasterCustomer.Inscustpandtls(txtPanNo.Text.ToUpper(), txtpancust.Text, Convert.ToInt32(ddllegaltype.SelectedValue), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlfacategory.SelectedValue));

                            obj_MasterCustomer.Sp_mastercustomerpancredit(dataower, Convert.ToDouble(txt_creditamount.Text), Convert.ToInt32(txt_creditday.Text), txtPanNo.Text, txtpancust.Text, Convert.ToInt32(exp), Convert.ToInt32(due), exmode);

                            obj_MasterCustomer.PanUploadLimitDetails(Convert.ToDouble(txt_limit.Text), txtpancust.Text.ToString(), empfrom, empto, txt_certno.Text, Convert.ToDouble(txt_tds_exp.Text), txtPanNo.Text.ToString());
                        }
                        // DataTable dtcus = obj_MasterCustomer.Insmastercustpandtls(txtPanNo.Text.ToUpper(), txtpancust.Text, txttanno.Text, txtcinno.Text, txt_uinno.Text, Convert.ToInt16(hf_employeeid.Value));

                        if (hid_pan.Value != "" && hid_einvoice.Value != "")
                        {
                            obj_MasterCustomer.UPdEnvoice4custpan(Convert.ToInt32(hid_pan.Value), hid_einvoice.Value);
                        }
                        txtcustomer.Text = txtpancust.Text;
                        if (ddlcategory.SelectedItem.Text == "Others")
                        {
                            ddl_Option.SelectedValue = "7";
                        }

                        // update inputpan
                      //  DataAccess.Masters.MasterCustomerGroup obj_mainx = new DataAccess.Masters.MasterCustomerGroup();
                        DataTable dtss = new DataTable();
                        dtss = obj_mainx.customerpanidselect(txtPanNo.Text, txtpancust.Text);
                        if (dtss.Rows.Count > 0)
                        {
                            hid_panno.Value = txtPanNo.Text;
                            hid_pan.Value = dtss.Rows[0]["CustomerPANId"].ToString();
                            if (hid_pan.Value != "")
                            {
                                obj_MasterCustomer.sp_paninputupdate(hid_pan.Value.ToString(), txtpancust.Text.ToUpper(), Paninput);
                                if (Paninput == "Y")
                                {
                                   
                                    txtPanNo.Text = "";
                                    hidpaninput.Value = "Y";
                                }
                            }
                        }
                        // end
                        txtcustomer.Enabled = false;
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "logix", "alertify.alert('PAN  Details Updated');", true);
                        btnpanadd.ToolTip = "Update";
                        btnpanadd1.Attributes["class"] = "btn ico-update";
                    }
                    PanSavetds();
                    if (txt_limit.Text == "0.00")
                    {
                        txt_limit.Text = "";
                    }
                    if (txt_tds_exp.Text == "0")
                    {
                        txt_tds_exp.Text = "";
                    }

                    if (ddlcategory.SelectedItem.Text == "Agent")
                    {
                        // creditdetailsEnable();
                        //btncredit.Enabled = false;
                        //btntds.Enabled = false;
                        Button9.Enabled = true;
                        Button10.Enabled = false;
                        Button11.Enabled = false;
                        Button12.Enabled = true;
                        Button13.Enabled = true;
                        Button14.Enabled = true;

                    }
                    else if (ddlcategory.SelectedItem.Text == "Others")
                    {
                        //creditdetailsEnable();
                        Button9.Enabled = true;
                        Button10.Enabled = false;
                        Button11.Enabled = false;
                        Button12.Enabled = true;
                        Button13.Enabled = true;
                        Button14.Enabled = true;


                    }
                    else
                    {
                        Button9.Enabled = true;
                        Button10.Enabled = true;
                        Button11.Enabled = true;
                        Button12.Enabled = true;
                        Button13.Enabled = true;
                        Button14.Enabled = true;

                    }
                }
            }
        }

        public void clearpan()
        {
            txtPanNo.Text = "";
            txtpancust.Text = "";
            txt_uinno.Text = "";
            txttanno.Text = "";
            txtcinno.Text = "";
            chkeinvoice.Checked = false;
            btnpanadd.ToolTip = "Save";
            btnpanadd1.Attributes["class"] = "btn ico-save";
        }

        protected void btnpancancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnpancancel.ToolTip == "Back")
                {
                    clear();
                    ClearSlap();
                    grd.DataSource = Utility.Fn_GetEmptyDataTable(); ;
                    grd.DataBind();
                    clearpan();
                    txtcustomer.Text = "";
                    GridView1.DataSource = Utility.Fn_GetEmptyDataTable();
                    GridView1.DataBind();
                    GrdProofkyc.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdProofkyc.DataBind();
                    //txtcustomer.Text = true;
                    txtbankid.Enabled = true;
                    txtaccountno.Enabled = true;
                    DropDownList5.Enabled = true;
                    txtifsc.Enabled = true;
                    btn_Save.Enabled = true;
                    ddl_branch.Items.Clear();
                    txt_creditday.Text = "";
                    txt_creditamount.Text = "";
                    clrnew();
                    card.Text = "";
                    hf_customerid.Value = "";
                    txt_Salesperson.Text = "";
                    hf_employeeid.Value = "";
                    txt_empfrom.Text = "";
                    txt_empto.Text = "";
                    txt_certno.Text = "";
                    txt_tds_exp.Text = "";
                    txt_limit.Text = "";
                    ddl_description.SelectedIndex = 0;
                    ddl_type.SelectedIndex = 0;
                    ddl_slab.SelectedIndex = 0;
                    ddl_percentage.SelectedIndex = 0;

                    ddlcategory.SelectedValue = "0";
                    ddlfacategory.SelectedValue = "0";
                    ddllegaltype.SelectedValue = "0";
                    btnCreditRequestAdd.ToolTip = "ADD";
                    btn_add1.Attributes["class"] = "btn btn-add1 MCtrl MT10";
                    // Response.End();
                    txtPanNo.Text = "";
                    hid_panno.Value = "";
                    hid_pan.Value = "";

                }
                else
                {
                    hid_pan.Value = "";
                    hid_panno.Value = "";
                    txtPanNo.Text = "";
                    clear();
                    GridView1.DataSource = Utility.Fn_GetEmptyDataTable();
                    GridView1.DataBind();
                    GrdProofkyc.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdProofkyc.DataBind();
                    //txtcustomer.Text = true;
                    txtbankid.Enabled = true;
                    txtaccountno.Enabled = true;
                    DropDownList5.Enabled = true;
                    txtifsc.Enabled = true;
                    btn_Save.Enabled = true;
                    clrnew();
                    ClearSlap();
                    txtcustomer.Text = "";
                    grd.DataSource = Utility.Fn_GetEmptyDataTable(); ;
                    grd.DataBind();
                    clearpan();
                    customermrcode();
                    ddlCType.Enabled = true;
                    //txtcustomer.Focus();
                    // txt_gstin.Focus();
                    //txtPanNo.Focus();
                    card.Text = "";
                    hf_employeeid.Value = "";
                    txt_Salesperson.Text = "";
                    txt_empfrom.Text = "";
                    txt_empto.Text = "";
                    txt_certno.Text = "";
                    txt_tds_exp.Text = "";
                    txt_limit.Text = "";
                    ddl_description.SelectedIndex = 0;
                    ddl_type.SelectedIndex = 0;
                    ddl_slab.SelectedIndex = 0;
                    ddl_percentage.SelectedIndex = 0;
                    hf_customerid.Value = "";
                    ddl_branch.Items.Clear();
                    txt_creditday.Text = "";
                    txt_creditamount.Text = "";
                    txt_exemptions.Text = "";
                    ddl_per.SelectedIndex = 0;
                    txt_overdue.Text = "";
                    txtpancust.Enabled = true;
                    txtcinno.Enabled = true;
                    txttanno.Enabled = true;
                    txt_uinno.Enabled = true;
                    ddlcategory.SelectedValue = "0";
                    ddlcategory.Focus();
                    ddlfacategory.SelectedValue = "0";
                    ddllegaltype.SelectedValue = "0";
                    btnCreditRequestAdd.ToolTip = "ADD";
                    btn_add1.Attributes["class"] = "btn btn-add1 MCtrl MT10";
                 btnBack.Text = "Back";
                    btnpancancel.Text = "Back";
                    btnpancancel.ToolTip = "Back";
                    btnBack1.Attributes["class"] = "btn ico-back";
                }
                FillBranch();
                txt_exemptions.Text = "3";
                txt_overdue.Text = "50";
                ddl_per.SelectedIndex = 2;
                ddl_branch.SelectedIndex = 3;
                Session["pannono"] = "";
                Session["hiddenpanid"] = "";
                Session["mastercustomerid"] = "";
                Session["mastercustomername"] = "";
                Session["mastercustomernames"] = "";
                Session["hidpaninput"] = "";
                Session["hidensalespersonid"] = "";
                Session["hiddensalespersonname"] = "";
                Session["customerCountryid"] = "";

                GridCreditclear();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void backclear()
        {
            try
            {
                if (btnpancancel.ToolTip == "Back")
                {
                    clear();
                    ClearSlap();
                    grd.DataSource = Utility.Fn_GetEmptyDataTable(); ;
                    grd.DataBind();
                    clearpan();
                    txtcustomer.Text = "";
                    GridView1.DataSource = Utility.Fn_GetEmptyDataTable();
                    GridView1.DataBind();
                    GrdProofkyc.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdProofkyc.DataBind();
                    //txtcustomer.Text = true;
                    txtbankid.Enabled = true;
                    txtaccountno.Enabled = true;
                    DropDownList5.Enabled = true;
                    txtifsc.Enabled = true;
                    btn_Save.Enabled = true;
                    ddl_branch.Items.Clear();
                    txt_creditday.Text = "";
                    txt_creditamount.Text = "";
                    clrnew();
                    card.Text = "";

                    txt_Salesperson.Text = "";
                    hf_employeeid.Value = "";
                    txt_empfrom.Text = "";
                    txt_empto.Text = "";
                    txt_certno.Text = "";
                    txt_tds_exp.Text = "";
                    txt_limit.Text = "";
                    ddl_description.SelectedIndex = 0;
                    ddl_type.SelectedIndex = 0;
                    ddl_slab.SelectedIndex = 0;
                    ddl_percentage.SelectedIndex = 0;

                    //ddlcategory.SelectedValue = "0";
                    ddlfacategory.SelectedValue = "0";
                    ddllegaltype.SelectedValue = "0";
                    btnCreditRequestAdd.ToolTip = "ADD";
                    btn_add1.Attributes["class"] = "btn btn-add1 MCtrl MT10";
                    // Response.End();
                }
                else
                {
                    clear();
                    GridView1.DataSource = Utility.Fn_GetEmptyDataTable();
                    GridView1.DataBind();
                    GrdProofkyc.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdProofkyc.DataBind();
                    //txtcustomer.Text = true;
                    txtbankid.Enabled = true;
                    txtaccountno.Enabled = true;
                    DropDownList5.Enabled = true;
                    txtifsc.Enabled = true;
                    btn_Save.Enabled = true;
                    clrnew();
                    ClearSlap();
                    txtcustomer.Text = "";
                    grd.DataSource = Utility.Fn_GetEmptyDataTable(); ;
                    grd.DataBind();
                    clearpan();
                    customermrcode();
                    ddlCType.Enabled = true;
                    //txtcustomer.Focus();
                    // txt_gstin.Focus();
                    //txtPanNo.Focus();
                    card.Text = "";
                    hf_employeeid.Value = "";
                    txt_Salesperson.Text = "";
                    txt_empfrom.Text = "";
                    txt_empto.Text = "";
                    txt_certno.Text = "";
                    txt_tds_exp.Text = "";
                    txt_limit.Text = "";
                    ddl_description.SelectedIndex = 0;
                    ddl_type.SelectedIndex = 0;
                    ddl_slab.SelectedIndex = 0;
                    ddl_percentage.SelectedIndex = 0;

                    ddl_branch.Items.Clear();
                    txt_creditday.Text = "";
                    txt_creditamount.Text = "";
                    txt_exemptions.Text = "";
                    ddl_per.SelectedIndex = 0;
                    txt_overdue.Text = "";
                    txtpancust.Enabled = true;
                    txtcinno.Enabled = true;
                    txttanno.Enabled = true;
                    txt_uinno.Enabled = true;
                    //ddlcategory.SelectedValue = "0";
                    ddlcategory.Focus();
                    ddlfacategory.SelectedValue = "0";
                    ddllegaltype.SelectedValue = "0";
                    btnCreditRequestAdd.ToolTip = "ADD";
                    btn_add1.Attributes["class"] = "btn btn-add1 MCtrl MT10";
                     btnBack.Text = "Back";
                    btnpancancel.ToolTip = "Back";
                    btnBack1.Attributes["class"] = "btn ico-back";
                }
                FillBranch();
                txt_exemptions.Text = "3";
                txt_overdue.Text = "50";
                ddl_per.SelectedIndex = 2;
                ddl_branch.SelectedIndex = 3;

                GridCreditclear();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void GridCreditclear()
        {
            // gridcredit 14/12/2022
            Gridcreditreq.DataSource = Utility.Fn_GetEmptyDataTable();
            Gridcreditreq.DataBind();
            ddlProductType.SelectedValue = "0";
            txt_vol.Text = "";
            ddlvolumetype.SelectedValue = "0";
            txt_revenue.Text = "";
            txt_creditdays.Text = "";
            txtCreditAboveamt.Text = "";
            // end 
        }

        private void getdetails4pan()
        {
            //DataTable dtnew = new DataTable();
            dt = obj_MasterCustomer.SPSelGetCustomerDetails4pan(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value), "");
            if (dt.Rows.Count > 0)
            {
                Session["data"] = dt;
            }
            if (dt.Rows.Count > 0)
            {
                hid_pan.Value = dt.Rows[0]["CustomerPANId"].ToString();

                if (hid_pan.Value != "")
                {
                    kycGrid();
                }
                Banking();
                // txtcustomer.Text = txtpancust.Text;
                if (dt.Rows[0]["customertype"].ToString() == "C")
                {
                    ddlCType.SelectedValue = "C";
                }
                else if (dt.Rows[0]["customertype"].ToString() == "P")
                {
                    ddlCType.SelectedValue = "P";
                }
                else if (dt.Rows[0]["customertype"].ToString() == "W")
                {
                    ddlCType.SelectedValue = "W";
                }
                if (dt.Rows[0]["empperiodfrom"] != System.DBNull.Value)
                {
                    string Dateempfrom = dt.Rows[0]["empperiodfrom"].ToString();
                    DateTime _retVals = Convert.ToDateTime(Dateempfrom);
                    txt_empfrom.Text = _retVals.ToString("dd/MM/yyyy");
                    if (txt_empfrom.Text == "01/01/1999")
                    {
                        txt_empfrom.Text = "";
                    }
                }
                else
                {
                    txt_empfrom.Text = "";
                }
                if (dt.Rows[0]["empperiodto"] != System.DBNull.Value)
                {
                    string dateempto = dt.Rows[0]["empperiodto"].ToString();
                    DateTime _retVals = Convert.ToDateTime(dateempto);
                    txt_empto.Text = _retVals.ToString("dd/MM/yyyy");
                    if (txt_empto.Text == "01/01/1999")
                    {
                        txt_empto.Text = "";
                    }
                }
                else
                {
                    txt_empto.Text = "";
                }
                if (dt.Rows[0]["limit"] != System.DBNull.Value)
                {
                    txt_limit.Text = dt.Rows[0]["limit"].ToString();
                }
                else
                {
                    txt_limit.Text = "";
                }
                if (txt_limit.Text == "0.0000")
                {
                    txt_limit.Text = "";
                }

                if (dt.Rows[0]["tdsemp"] != System.DBNull.Value)
                {
                    txt_tds_exp.Text = dt.Rows[0]["tdsemp"].ToString();
                    if (txt_tds_exp.Text == "0")
                    {
                        txt_tds_exp.Text = "";
                    }
                }
                else
                {
                    txt_tds_exp.Text = "0";
                }
                if (txt_tds_exp.Text == "0.0000")
                {
                    txt_tds_exp.Text = "";
                }
                if (dt.Rows[0]["certno"] != System.DBNull.Value)
                {
                    txt_certno.Text = dt.Rows[0]["certno"].ToString();
                    if (txt_certno.Text == "0")
                    {
                        txt_certno.Text = "";
                    }
                }
                else
                {
                    txt_certno.Text = "";
                }
                //dt.Rows[0]["customerid"].ToString()
                //kalai start
                // txt_gstin.Text = dt.Rows[0]["gstin"].ToString();
                //kalai end
                hf_customerid.Value = dt.Rows[0]["customerid"].ToString();
                txtstreet.Text = dt.Rows[0]["address"].ToString();
                hf_portid.Value = dt.Rows[0]["city"].ToString();
                Session["portid"] = hf_portid.Value;
                txtcity.Text = port.GetPortname(Convert.ToInt32(hf_portid.Value));
                hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(txtcity.Text.ToUpper()));
                txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                txtpincode.Text = dt.Rows[0]["zip"].ToString();
                txtllisd.Text = dt.Rows[0]["llisd"].ToString();
                txtllstd.Text = dt.Rows[0]["llstd"].ToString();
                txtlandline.Text = dt.Rows[0]["phone"].ToString();
                txtfaxisd.Text = dt.Rows[0]["faxisd"].ToString();
                txtfaxstd.Text = dt.Rows[0]["faxstd"].ToString();
                txtfax.Text = dt.Rows[0]["fax"].ToString();
                txtemail.Text = dt.Rows[0]["email"].ToString();
                //txt_Salesperson.Text = dt.Rows[0]["empname"].ToString();
                string empcode = dt.Rows[0]["employeeid"].ToString();
                if (empcode != "")
                {
                    hf_employeeid.Value = empcode;
                    txt_Salesperson.Text = dt.Rows[0]["empname"].ToString();
                }
                //    txtPanNo.Text = dt.Rows[0]["panno"].ToString();
                //  DataTable grid = obj_MasterCustomer.Getcustgridwithpan(dt.Rows[0]["panno"].ToString());
                //if (grid.Rows.Count > 0)
                //{
                //    grd.DataSource = grid;
                //    grd.DataBind();
                //}
                txtServiceTaxNo.Text = dt.Rows[0]["stno"].ToString();
                //txtpancust.Text = txtcustomer.Text;
                /***********************************************/
                txtunit.Text = dt.Rows[0]["unit#"].ToString();
                txtbuildingname.Text = dt.Rows[0]["buildingname"].ToString();
                txtdoor.Text = dt.Rows[0]["door#"].ToString();
                hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                hf_stateid.Value = dt.Rows[0]["stateid"].ToString();

                txttds.Text = dt.Rows[0]["tds"].ToString();

                //txtfax.Text = dt.Rows[0]["fax"].ToString();
                txtmblisd.Text = dt.Rows[0]["mblisd"].ToString();
                txtMobile.Text = dt.Rows[0]["mobile"].ToString();
                //status = Convert.ToChar(dt.Rows[0]["status"].ToString());
                if (hf_districtid.Value != "")
                {
                    txtdistrict.Text = obj_MasterCustomer.GetStateDistrictname(Convert.ToInt32(hf_districtid.Value));
                }
                if (hf_stateid.Value != "")
                {
                    txtstate.Text = obj_MasterCustomer.GetStatename(Convert.ToInt32(hf_stateid.Value));
                }
                txtmailcom.Text = dt.Rows[0]["commailid"].ToString();
                txtmailimp.Text = dt.Rows[0]["impmailid"].ToString();
                txtmailexport.Text = dt.Rows[0]["expmailid"].ToString();
                txtmailfin.Text = dt.Rows[0]["finmailid"].ToString();
                txtmailmanag.Text = dt.Rows[0]["managmail"].ToString();

                txtmanagptc.Text = dt.Rows[0]["managptc"].ToString();
                txtcomptc.Text = dt.Rows[0]["comptc"].ToString();
                txtexpptc.Text = dt.Rows[0]["expptc"].ToString();
                txtimpptc.Text = dt.Rows[0]["impptc"].ToString();
                txtfinptc.Text = dt.Rows[0]["finptc"].ToString();
                txt_gstin.Text = dt.Rows[0]["gstin"].ToString();
                //txt_uinno.Text = dt.Rows[0]["uinno"].ToString();
                //txttanno.Text = dt.Rows[0]["tanno"].ToString();
                //txtcinno.Text = dt.Rows[0]["cinno"].ToString();
                if (txt_gstin.Text != "")
                {
                    //txt_RCM.Enabled = false;
                    //txt_unregistered.Enabled = false;
                    //txt_RCM.Checked = false;
                    //txt_unregistered.Checked = false;
                }
                else
                {
                    //txt_RCM.Enabled = true;
                    //txt_unregistered.Enabled = true;
                }
                card.Text = txtcustomer.Text + " GST #  " + txt_gstin.Text;
                if (txt_uinno.Text != "")
                {
                    //txt_RCM.Enabled = false;
                    //txt_unregistered.Enabled = false;
                    //txt_RCM.Checked = false;
                    //txt_unregistered.Checked = false;
                }
                else
                {
                    //txt_RCM.Enabled = true;
                    //txt_unregistered.Enabled = true;
                }
                if (dt.Rows[0]["RCM"].ToString() == "Y")
                {
                    // txt_RCM.Checked = true;
                    ddl_Option.SelectedValue = "1";
                }
                else if (dt.Rows[0]["UnRegistered"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "2";
                }
                else if (dt.Rows[0]["UnRegistered"].ToString() == "A")
                {
                    ddl_Option.SelectedValue = "7";
                    ddl_Option.Enabled = false;
                }
                else if (dt.Rows[0]["gstexemption"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "3";
                }
                else if (dt.Rows[0]["Sez"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "6";
                }
                else if (dt.Rows[0]["Register"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "5";
                }
                else if (dt.Rows[0]["SezIgst"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "4";
                    // txt_gstexi.Checked = true;
                }
                //else if (dt.Rows[0]["Not Applicable"].ToString() == "A")
                //{
                //    ddl_Option.SelectedValue = "7";
                //    // txt_gstexi.Checked = true;
                //}
                //else
                //{
                //    ddl_Option.SelectedValue = "0";
                //}
                //newly added on 07012022 
                if (dt.Rows[0]["IsCoload"].ToString() == "Y")
                {
                    ChkCoload.Checked = true;
                    txt_Coloadercode.Enabled = true;
                    txt_ColoadRemarks.Enabled = true;
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ColoadRemarks"].ToString()) == true)
                    {
                        txt_ColoadRemarks.Text = dt.Rows[0]["ColoadRemarks"].ToString();

                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Coloadercode"].ToString()) == true)
                    {
                        txt_Coloadercode.Text = dt.Rows[0]["Coloadercode"].ToString();

                    }
                }
                else
                {
                    ChkCoload.Checked = false;
                    txt_ColoadRemarks.Enabled = false;
                    txt_Coloadercode.Enabled = false;
                }
                //end
                byte[] imageByte = null;
                if (!DBNull.Value.Equals(dt.Rows[0]["mgmtheadimg"]))
                {
                    imageByte = ((byte[])dt.Rows[0]["mgmtheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp.ImageUrl = "~/images/visitingcard_img.jpg";
                }
                if (!DBNull.Value.Equals(dt.Rows[0]["cmheadimg"]))
                {

                    imageByte = ((byte[])dt.Rows[0]["cmheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp1.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp1.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp1.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp1.ImageUrl = "~/images/visitingcard_img.jpg";
                }
                if (!DBNull.Value.Equals(dt.Rows[0]["expheadimg"]))
                {
                    imageByte = ((byte[])dt.Rows[0]["expheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp2.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp2.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp2.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp2.ImageUrl = "~/images/visitingcard_img.jpg";
                }
                if (!DBNull.Value.Equals(dt.Rows[0]["finheadimg"]))
                {

                    imageByte = ((byte[])dt.Rows[0]["finheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp3.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp3.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp3.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp3.ImageUrl = "~/images/visitingcard_img.jpg";
                }

                if (!DBNull.Value.Equals(dt.Rows[0]["impimg"]))
                {
                    imageByte = ((byte[])dt.Rows[0]["impimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp4.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp4.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp4.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp4.ImageUrl = "~/images/visitingcard_img.jpg";
                }

                hf_locationid.Value = dt.Rows[0]["locationid"].ToString();

                if (dt.Rows[0]["Register"].ToString() == "Y")
                {
                    DataTable DtNew = obj_MasterCustomer.checkvoucherraise(Convert.ToInt32(hf_customerid.Value));
                    if (DtNew.Rows.Count > 0)
                    {
                        ddl_Option.Enabled = false;
                    }
                    else
                    {
                        ddl_Option.Enabled = true;
                    }
                }
                else
                {
                    DataTable DtNew = obj_MasterCustomer.checkvoucherraise(Convert.ToInt32(hf_customerid.Value));
                    if (DtNew.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["UnRegistered"].ToString() == "Y")
                        {
                            ddl_Option.Enabled = true;
                        }
                        else
                        {
                            ddl_Option.Enabled = false;
                        }
                    }
                    else if (dt.Rows[0]["UnRegistered"].ToString() == "A")
                    {
                        ddl_Option.Enabled = false;
                    }
                    else
                    {
                        ddl_Option.Enabled = true;
                    }
                }
                if (ddl_Option.SelectedValue == "0")
                {
                    ddl_Option.Enabled = true;
                }
                if (hf_locationid.Value != "" && hf_locationid.Value != "0")
                {
                    txtlocation.Text = obj_MasterCustomer.GetLocationname(Convert.ToInt32(hf_locationid.Value));
                    ddllocation.Visible = false;
                    btndelete.Enabled = true;
                    btndelete.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    if (txtpincode.Text == "")
                    {
                        txtpincode.Focus();
                        btndelete.Enabled = false;
                        btndelete.ForeColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        dt = location.GetPincodeDetailsForLocation(txtpincode.Text);
                        if (dt.Rows.Count > 1)
                        {
                            txtlocation.Visible = false;
                            ddllocation.Visible = true;
                            btndelete.Enabled = false;
                            btndelete.ForeColor = System.Drawing.Color.Gray;
                            ddllocation.Items.Clear();
                            ddllocation.Items.Add("");
                            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                ddllocation.Items.Add(dt.Rows[i]["Location"].ToString());
                            }
                        }
                        else if (dt.Rows.Count == 1)
                        {
                            txtlocation.Visible = true;
                            ddllocation.Visible = false;
                            btndelete.Enabled = false;
                            btndelete.ForeColor = System.Drawing.Color.Gray;
                            txtlocation.Text = dt.Rows[0]["Location"].ToString();
                            hf_locationid.Value = dt.Rows[0]["LocationId"].ToString();
                            txtlocationTxtChange();
                        }
                    }
                }
                btnSave.Enabled = true;
                btnSave.ToolTip = "Update";
                btnSave1.Attributes["class"] = "btn ico-update";
                btnBack.ToolTip = "Clear";
                btnBack1.Attributes["class"] = "btn ico-cancel";
                btnpanadd.ToolTip = "Update";
                btnpanadd1.Attributes["class"] = "btn ico-update";
                btnpancancel.ToolTip = "Cancel";
                // btnpanadd1.Attributes["class"] = "btn ico-cancel";
                if (txtcountry.Text.ToUpper() != "INDIA")
                {
                    txtdistrict.ReadOnly = true;
                    txtstate.ReadOnly = true;
                    txtcountry.ReadOnly = true;
                }
                dts = obj_MasterCustomer.SPSelGetCustomerDetailsGSTIN(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
                if (dts.Rows.Count > 0)
                {
                    txtGSTCode.Text = dts.Rows[0]["GSTCode"].ToString();
                    hdn_oldgstcode.Value = dts.Rows[0]["GSTCode"].ToString();
                }
                hid_gstcode.Value = hf_stateid.Value;
                GetBusinesscardDetails();
            }
            CustomerTDS();
            customermrcode();
            FillBranch();
        }

        protected void txtpancust_TextChanged(object sender, EventArgs e)
        {
            //if (txtPanNo.Text != "" && txtpancust.Text != "")
            //{
            //    DataTable dt = new DataTable();
            //    DataTable grid = obj_MasterCustomer.Getcustgridwithpan(txtPanNo.Text);
            //    dt = obj_MasterCustomer.checklikepanno(txtPanNo.Text, txtpancust.Text);
            //    if (dt.Rows.Count > 0)
            //    {
            //        txtpancust.Text = dt.Rows[0]["CustomerPANName"].ToString();
            //        hf_customerid.Value = dt.Rows[0]["customerid"].ToString();
            //        txt_uinno.Text = dt.Rows[0]["CustomerUINno"].ToString();
            //        txttanno.Text = dt.Rows[0]["CustomerTANno"].ToString();
            //        txtcinno.Text = dt.Rows[0]["CustomerCINno"].ToString();
            //        // getdetails4pan();
            //        btnpanadd.ToolTip = "Update";
            //        btnpanadd1.Attributes["class"] = "btn ico-update";
            //        if (grid.Rows.Count > 0)
            //        {
            //            grd.DataSource = grid;
            //            grd.DataBind();
            //        }
            //    }
            //    else
            //    {
            //        txt_uinno.Text = "";
            //        txttanno.Text = "";
            //        txtcinno.Text = "";
            //        btnpanadd.ToolTip = "Save";
            //        btnpanadd1.Attributes["class"] = "btn ico-save";
            //        if (grid.Rows.Count > 0)
            //        {
            //            grd.DataSource = grid;
            //            grd.DataBind();
            //        }
            //    }
            //}

            if (txtpancust.Text != "")
            {
                DataTable dt = new DataTable();
                dt = obj_MasterCustomer.SP_GetallPannumberdetails(txtpancust.Text);
                if (dt.Rows.Count > 0)
                {
                    string data = dt.Rows[0]["CustomerPANno"].ToString();
                    if (data != "")
                    {
                        txtPanNo.Text = data;
                       // Session["hiddenpanid1"] = txtPanNo.Text;

                        hid_pan.Value = dt.Rows[0]["CustomerPANId"].ToString();
                        hidpaninput.Value = dt.Rows[0]["PanInput"].ToString();
                        hid_panno.Value = dt.Rows[0]["CustomerPANno"].ToString();
                        txtPanNo_TextChanged(sender, e);
                    }
                    else
                    {
                        txtpancust.Text = "";
                    }
                }
                else
                {
                    txtcustomer.Text = txtpancust.Text;
                    txtcustomer_TextChanged(sender, e);
                }
            }
            if (ddlcategory.SelectedItem.Text == "Agent")
            {
                // creditdetailsEnable();
                //btncredit.Enabled = false;
                //btntds.Enabled = false;
                Button9.Enabled = true;
                Button10.Enabled = false;
                Button11.Enabled = false;
                Button12.Enabled = true;
                Button13.Enabled = true;
                Button14.Enabled = true;

            }
            else if (ddlcategory.SelectedItem.Text == "Others")
            {
                //creditdetailsEnable();
                Button9.Enabled = true;
                Button10.Enabled = false;
                Button11.Enabled = false;
                Button12.Enabled = true;
                Button13.Enabled = true;
                Button14.Enabled = true;
            }
            else
            {
                Button9.Enabled = true;
                Button10.Enabled = true;
                Button11.Enabled = true;
                Button12.Enabled = true;
                Button13.Enabled = true;
                Button14.Enabled = true;
            }
        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
             index = grd.SelectedRow.RowIndex;
            hid_gst.Value = grd.SelectedRow.Cells[1].Text;
            //  txtcustomer.Text = grd.SelectedRow.Cells[2].Text.Replace("&amp;","&");
            hf_customerid.Value = grd.SelectedRow.Cells[4].Text;
            getdetails4panwithgst();
            //txt_Salesperson_TextChanged(object sender, EventArgs e);
            // getsalespersondetail();
            GetEmployeenamedetails();
            if (ddlcategory.SelectedItem.Text == "Agent")
            {
                // creditdetailsEnable();
                Button10.Enabled = false;
                Button11.Enabled = false;
            }
            else if (ddlcategory.SelectedItem.Text == "Others")
            {
                Button10.Enabled = false;
                Button11.Enabled = false;
                //creditdetailsEnable();
            }
            else
            {
                if (grd.Rows.Count > 0)
                {
                    Button10.Enabled = true;
                    Button11.Enabled = true;
                    ddlProductType.Enabled = true;
                    txt_vol.Enabled = true;
                    ddlvolumetype.Enabled = true;
                    txt_revenue.Enabled = true;
                    txt_creditdays.Enabled = true;
                    txt_creditamount.Enabled = true;
                    txt_exemptions.Enabled = true;
                    txt_overdue.Enabled = true;
                    ddl_per.Enabled = true;
                    txtCreditAboveamt.Enabled = true;
                    btnCreditRequestAdd.Enabled = true;
                    btncredit.Enabled = true;
                    btntds.Enabled = true;
                }
            }
            //popup_uploaddoc_credit.Show();
            if (hf_customerid.Value != "" && hf_customerid.Value != "0")
            {
                if (hid_pan.Value != "")
                {
                    iframecost.Attributes["src"] = "MasterCustomerDetails.aspx";
                    popupfro.Visible = true;
                    PopupBL.Show();
                    Session["pannono"] = txtPanNo.Text;
                    Session["hiddenpanid"] = hid_pan.Value;
                    Session["mastercustomerid"] = hf_customerid.Value;
                    Session["mastercustomername"] = txtpancust.Text;
                    Session["mastercustomernames"] = txtcustomer.Text;
                    Session["grd_SelectedIndex"] = index;
                    Session["grd_Selectedgst"] = hid_gst.Value;
                    Session["hidpaninput"] = hidpaninput.Value;
                    Session["hidensalespersonid"] = hf_employeeid.Value;
                    Session["hiddensalespersonname"] = txt_Salesperson.Text;
                }
                else
                {
                    iframecost.Attributes["src"] = "MasterCustomerDetails.aspx";
                    popupfro.Visible = true;
                    PopupBL.Show();
                    Session["pannono"] = txtPanNo.Text;
                    Session["hiddenpanid"] = hid_pan.Value;
                    Session["mastercustomerid"] = hf_customerid.Value;
                    Session["mastercustomername"] = txtpancust.Text;
                    Session["mastercustomernames"] = txtcustomer.Text;
                    Session["grd_SelectedIndex"] = index;
                    Session["grd_Selectedgst"] = hid_gst.Value;
                    Session["hidpaninput"] = hidpaninput.Value;
                    Session["hidensalespersonid"] = hf_employeeid.Value;
                    Session["hiddensalespersonname"] = txt_Salesperson.Text;
                }
            }
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        public void Banking()
        {
            DataTable dt = new DataTable();
            //dt = obj_MasterCustomer.get_Gridviewnewone(Convert.ToInt32(hf_customerid.Value));
            if (hf_customerid.Value != "")
            {
                dt = obj_MasterCustomer.Getbankdetails(Convert.ToInt32(hf_customerid.Value), txtPanNo.Text);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            index = GridView1.SelectedRow.RowIndex;
            DataTable dt = new DataTable();
            dt = obj_MasterCustomer.get_Gridviewnewone(Convert.ToInt32(hf_customerid.Value));
            if (GridView1.Rows.Count > 0)
            {
                Session["Index"] = index;
                txtbankid.Text = GridView1.Rows[index].Cells[5].Text.ToUpper();
                DropDownList5.SelectedItem.Text = GridView1.Rows[index].Cells[7].Text.ToUpper();
                txtaccountno.Text = GridView1.Rows[index].Cells[6].Text.ToUpper();
                txtifsc.Text = GridView1.Rows[index].Cells[8].Text.ToUpper();
            }
            txtbankid.Enabled = false;
            txtaccountno.Enabled = false;
            DropDownList5.Enabled = false;
            txtifsc.Enabled = false;
            btn_Save.Enabled = false;
            //btn_Save.ToolTip = "Update";
            //btn_Save.Attributes["class"] = "btn ico-update";
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Checkdatacon()
        {
            if (txtbankid.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CustomerBankAccountDetails", "alertify.alert('Please select Bankname');", true);
                txtbankid.Focus();
                blerr = true;
                return;
            }
            else if (txtaccountno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CustomerBankAccountDetails", "alertify.alert('Please Enter AccountNumber');", true);
                txtaccountno.Focus();
                blerr = true;
                return;
            }
            else if (DropDownList1.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CustomerBankAccountDetails", "alertify.alert('Select account Type');", true);
                DropDownList1.Focus();
                blerr = true;
                return;
            }
            else if (txtifsc.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CustomerBankAccountDetails", "alertify.alert('Please Enter IFSCCode');", true);
                txtifsc.Focus();
                blerr = true;
                return;
            }
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        public void clrnew()
        {
            txtbankid.Text = "";
            txtaccountno.Text = "";
            DropDownList5.Items.Clear();
            DropDownList5.Items.Add("");
            DropDownList5.Items.Add("SAVINGS");
            DropDownList5.Items.Add("CURRENT");
            txtifsc.Text = "";
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Checkdatacon();
            if (blerr == true)
            {
                blerr = false;
                return;
            }
            if (btn_Save.ToolTip == "Save")
            {

                if (hid_bankid.Value != "")
                {
                    obj_MasterCustomer.insertcustomerbankaccountnew(Convert.ToInt32(hf_customerid.Value), Convert.ToInt32(hid_bankid.Value), txtaccountno.Text, DropDownList5.SelectedItem.Text, txtifsc.Text);
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Saved Successfully!');", true);
                    btnSave.Enabled = true;
                    clrnew();
                    getgriddata();
                    //btn_Save.ToolTip = "Update";
                    //btn_Save.Attributes["class"] = "btn ico-update";
                    hid_bankid.Value = "";
                }
            }
            //else if(btn_Save.ToolTip == "Update")
            //{
            //    if (hid_bankid.Value != "")
            //    {
            //        obj_MasterCustomer.insertcustomerbankaccountnew(Convert.ToInt32(hf_customerid.Value), Convert.ToInt32(hid_bankid.Value), txtaccountno.Text, DropDownList5.SelectedItem.Text, txtifsc.Text);
            //        ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Saved Successfully!');", true);
            //        btnSave.Enabled = true;
            //        clrnew();
            //        getgriddata();
            //        btn_Save.ToolTip = "Save";
            //        btn_Save.Attributes["class"] = "btn ico-save";
            //        hid_bankid.Value = "";
            //    }
            //}
        }
        public void getgriddata()
        {
            DataTable dt = new DataTable();
            dt = obj_MasterCustomer.get_Gridviewnewone(Convert.ToInt32(hf_customerid.Value));
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btnbankcancel_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = Utility.Fn_GetEmptyDataTable();
            GridView1.DataBind();
            getgriddata();
            //txtcustomer.Text = true;
            txtbankid.Enabled = true;
            txtaccountno.Enabled = true;
            DropDownList5.Enabled = true;
            txtifsc.Enabled = true;
            btn_Save.Enabled = true;
            clrnew();
        }

        private void getdetails4panwithgst()
        {
            //DataTable dtnew = new DataTable();
            if (hid_gst.Value == "&nbsp;")
            {
                hid_gst.Value = "";
            }
            dt = obj_MasterCustomer.SPSelGetCustomerDetails4pan(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value), hid_gst.Value);
            if (dt.Rows.Count > 0)
            {
                Session["data"] = dt;
            }
            if (dt.Rows.Count > 0)
            {
                hid_pan.Value = dt.Rows[0]["CustomerPANId"].ToString();
                if (hid_pan.Value != "")
                {
                    kycGrid();
                }
                Banking();
                // txtcustomer.Text = txtpancust.Text;
                if (dt.Rows[0]["customertype"].ToString() == "C")
                {
                    ddlCType.SelectedValue = "C";
                }
                else if (dt.Rows[0]["customertype"].ToString() == "P")
                {
                    ddlCType.SelectedValue = "P";
                }
                else if (dt.Rows[0]["customertype"].ToString() == "W")
                {
                    ddlCType.SelectedValue = "W";
                }
                if (dt.Rows[0]["empperiodfrom"] != System.DBNull.Value)
                {
                    string Dateempfrom = dt.Rows[0]["empperiodfrom"].ToString();
                    DateTime _retVals = Convert.ToDateTime(Dateempfrom);
                    txt_empfrom.Text = _retVals.ToString("dd/MM/yyyy");
                    if (txt_empfrom.Text == "01/01/1999")
                    {
                        txt_empfrom.Text = "";
                    }
                }
                else
                {
                    txt_empfrom.Text = "";
                }
                if (dt.Rows[0]["empperiodto"] != System.DBNull.Value)
                {
                    string dateempto = dt.Rows[0]["empperiodto"].ToString();
                    DateTime _retVals = Convert.ToDateTime(dateempto);
                    txt_empto.Text = _retVals.ToString("dd/MM/yyyy");
                    if (txt_empto.Text == "01/01/1999")
                    {
                        txt_empto.Text = "";
                    }
                }
                else
                {
                    txt_empto.Text = "";
                }
                if (dt.Rows[0]["limit"] != System.DBNull.Value)
                {
                    txt_limit.Text = dt.Rows[0]["limit"].ToString();
                }
                else
                {
                    txt_limit.Text = "";
                }
                if (txt_limit.Text == "0.0000")
                {
                    txt_limit.Text = "";
                }

                if (dt.Rows[0]["tdsemp"] != System.DBNull.Value)
                {
                    txt_tds_exp.Text = dt.Rows[0]["tdsemp"].ToString();
                    if (txt_tds_exp.Text == "0")
                    {
                        txt_tds_exp.Text = "";
                    }
                }
                else
                {
                    txt_tds_exp.Text = "0";
                }
                if (txt_tds_exp.Text == "0.0000")
                {
                    txt_tds_exp.Text = "";
                }

                if (dt.Rows[0]["certno"] != System.DBNull.Value)
                {
                    txt_certno.Text = dt.Rows[0]["certno"].ToString();
                    if (txt_certno.Text == "0")
                    {
                        txt_certno.Text = "";
                    }
                }
                else
                {
                    txt_certno.Text = "";
                }
                txt_creditamount.Text = dt.Rows[0]["creditAmount"].ToString();
                txt_creditday.Text = dt.Rows[0]["creditdays"].ToString();
                //ddl_branch.SelectedItem.Text = dt.Rows[0]["Bid"].ToString();
                //dt.Rows[0]["customerid"].ToString()
                //ddl_branch.SelectedItem.Text = dt.Rows[0]["Branch"].ToString();
                // ownerID = Convert.ToInt32(dt.Rows[0]["Branch"].ToString());
                //string datats = dt.Rows[0]["Branch"].ToString();
                //if (datats != "")
                //{
                //    ownerID = Convert.ToInt16(datats);
                //    FillBranch();
                //    ddl_branch.SelectedIndex = ownerID;
                //}
                hf_customerid.Value = dt.Rows[0]["customerid"].ToString();
                txtstreet.Text = dt.Rows[0]["address"].ToString();
                hf_portid.Value = dt.Rows[0]["city"].ToString();
                Session["portid"] = hf_portid.Value;
                txtcity.Text = port.GetPortname(Convert.ToInt32(hf_portid.Value));
                hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(txtcity.Text.ToUpper()));
                txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                txtpincode.Text = dt.Rows[0]["zip"].ToString();
                txtllisd.Text = dt.Rows[0]["llisd"].ToString();
                if (txtllisd.Text == "0")
                {
                    txtllisd.Text = "";
                }
                txtllstd.Text = dt.Rows[0]["llstd"].ToString();
                txtlandline.Text = dt.Rows[0]["phone"].ToString();
                txtfaxisd.Text = dt.Rows[0]["faxisd"].ToString();
                if (txtfaxisd.Text == "0")
                {
                    txtfaxisd.Text = "";
                }
                txtfaxstd.Text = dt.Rows[0]["faxstd"].ToString();
                txtfax.Text = dt.Rows[0]["fax"].ToString();
                txtemail.Text = dt.Rows[0]["email"].ToString();
                //    txtPanNo.Text = dt.Rows[0]["panno"].ToString();
                //  DataTable grid = obj_MasterCustomer.Getcustgridwithpan(dt.Rows[0]["panno"].ToString());
                //if (grid.Rows.Count > 0)
                //{
                //    grd.DataSource = grid;
                //    grd.DataBind();
                //}
                txtServiceTaxNo.Text = dt.Rows[0]["stno"].ToString();
                //txtpancust.Text = txtcustomer.Text;
                /***********************************************/
                txtunit.Text = dt.Rows[0]["unit#"].ToString();
                txtbuildingname.Text = dt.Rows[0]["buildingname"].ToString();
                txtdoor.Text = dt.Rows[0]["door#"].ToString();
                hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                hf_stateid.Value = dt.Rows[0]["stateid"].ToString();

                string empcode = dt.Rows[0]["employeeid"].ToString();
                if (empcode != "")
                {
                    hf_employeeid.Value = empcode;
                    txt_Salesperson.Text = dt.Rows[0]["empname"].ToString();
                }
                txttds.Text = dt.Rows[0]["tds"].ToString();
                //txtfax.Text = dt.Rows[0]["fax"].ToString();
                txtmblisd.Text = dt.Rows[0]["mblisd"].ToString();
                txtMobile.Text = dt.Rows[0]["mobile"].ToString();
                //status = Convert.ToChar(dt.Rows[0]["status"].ToString());
                if (hf_districtid.Value != "")
                {
                    txtdistrict.Text = obj_MasterCustomer.GetStateDistrictname(Convert.ToInt32(hf_districtid.Value));
                }
                if (txtdistrict.Text == "0")
                {
                    txtdistrict.Text = "";
                }
                if (hf_stateid.Value != "")
                {
                    txtstate.Text = obj_MasterCustomer.GetStatename(Convert.ToInt32(hf_stateid.Value));
                }
                if (txtstate.Text == "0")
                {
                    txtstate.Text = "";
                }
                txtmailcom.Text = dt.Rows[0]["commailid"].ToString();
                txtmailimp.Text = dt.Rows[0]["impmailid"].ToString();
                txtmailexport.Text = dt.Rows[0]["expmailid"].ToString();
                txtmailfin.Text = dt.Rows[0]["finmailid"].ToString();
                txtmailmanag.Text = dt.Rows[0]["managmail"].ToString();

                txtmanagptc.Text = dt.Rows[0]["managptc"].ToString();
                txtcomptc.Text = dt.Rows[0]["comptc"].ToString();
                txtexpptc.Text = dt.Rows[0]["expptc"].ToString();
                txtimpptc.Text = dt.Rows[0]["impptc"].ToString();
                txtfinptc.Text = dt.Rows[0]["finptc"].ToString();
                txt_gstin.Text = dt.Rows[0]["gstin"].ToString();
                //txt_uinno.Text = dt.Rows[0]["uinno"].ToString();
                //txttanno.Text = dt.Rows[0]["tanno"].ToString();
                //txtcinno.Text = dt.Rows[0]["cinno"].ToString();
                if (txt_gstin.Text != "")
                {
                    //txt_RCM.Enabled = false;
                    //txt_unregistered.Enabled = false;
                    //txt_RCM.Checked = false;
                    //txt_unregistered.Checked = false;

                }
                else
                {
                    //txt_RCM.Enabled = true;
                    //txt_unregistered.Enabled = true;
                }
                card.Text = txtcustomer.Text + " GST #  " + txt_gstin.Text;
                if (txt_uinno.Text != "")
                {
                    //txt_RCM.Enabled = false;
                    //txt_unregistered.Enabled = false;
                    //txt_RCM.Checked = false;
                    //txt_unregistered.Checked = false;
                }
                else
                {
                    //txt_RCM.Enabled = true;
                    //txt_unregistered.Enabled = true;
                }
                if (dt.Rows[0]["RCM"].ToString() == "Y")
                {
                    // txt_RCM.Checked = true;
                    ddl_Option.SelectedValue = "1";
                }

                else if (dt.Rows[0]["UnRegistered"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "2";
                }
                else if (dt.Rows[0]["gstexemption"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "3";
                }
                else if (dt.Rows[0]["Sez"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "6";
                }
                else if (dt.Rows[0]["Register"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "5";
                }
                else if (dt.Rows[0]["SezIgst"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "4";
                    // txt_gstexi.Checked = true;
                }
                else if (dt.Rows[0]["unregistered"].ToString() == "A")
                {
                    ddl_Option.SelectedValue = "7";
                    // txt_gstexi.Checked = true;
                }
                else if (dt.Rows[0]["unregistered"].ToString() == "N")
                {
                    ddl_Option.SelectedValue = "7";
                    // txt_gstexi.Checked = true;
                }
                else
                {
                    ddl_Option.SelectedValue = "0";
                }
                if (dt.Rows[0]["unregistered"].ToString() == "A")
                {
                    ddl_Option.SelectedValue = "7";
                    // txt_gstexi.Checked = true;
                }
                //newly added on 07012022 
                if (dt.Rows[0]["IsCoload"].ToString() == "Y")
                {
                    ChkCoload.Checked = true;
                    txt_Coloadercode.Enabled = true;
                    txt_ColoadRemarks.Enabled = true;
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ColoadRemarks"].ToString()) == true)
                    {
                        txt_ColoadRemarks.Text = dt.Rows[0]["ColoadRemarks"].ToString();

                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Coloadercode"].ToString()) == true)
                    {
                        txt_Coloadercode.Text = dt.Rows[0]["Coloadercode"].ToString();
                    }
                }
                else
                {
                    ChkCoload.Checked = false;
                    txt_ColoadRemarks.Enabled = false;
                    txt_Coloadercode.Enabled = false;
                }
                //end
                byte[] imageByte = null;
                if (!DBNull.Value.Equals(dt.Rows[0]["mgmtheadimg"]))
                {
                    imageByte = ((byte[])dt.Rows[0]["mgmtheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp.ImageUrl = "~/images/visitingcard_img.jpg";
                }
                if (!DBNull.Value.Equals(dt.Rows[0]["cmheadimg"]))
                {
                    imageByte = ((byte[])dt.Rows[0]["cmheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp1.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp1.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp1.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp1.ImageUrl = "~/images/visitingcard_img.jpg";
                }
                if (!DBNull.Value.Equals(dt.Rows[0]["expheadimg"]))
                {

                    imageByte = ((byte[])dt.Rows[0]["expheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp2.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp2.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp2.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp2.ImageUrl = "~/images/visitingcard_img.jpg";
                }
                if (!DBNull.Value.Equals(dt.Rows[0]["finheadimg"]))
                {

                    imageByte = ((byte[])dt.Rows[0]["finheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp3.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp3.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp3.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp3.ImageUrl = "~/images/visitingcard_img.jpg";
                }


                if (!DBNull.Value.Equals(dt.Rows[0]["impimg"]))
                {

                    imageByte = ((byte[])dt.Rows[0]["impimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp4.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp4.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp4.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp4.ImageUrl = "~/images/visitingcard_img.jpg";
                }


                hf_locationid.Value = dt.Rows[0]["locationid"].ToString();


                if (dt.Rows[0]["Register"].ToString() == "Y")
                {
                    DataTable DtNew = obj_MasterCustomer.checkvoucherraise(Convert.ToInt32(hf_customerid.Value));
                    if (DtNew.Rows.Count > 0)
                    {
                        ddl_Option.Enabled = false;
                    }
                    else
                    {
                        ddl_Option.Enabled = true;
                    }
                }
                else
                {
                    DataTable DtNew = obj_MasterCustomer.checkvoucherraise(Convert.ToInt32(hf_customerid.Value));
                    if (DtNew.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["UnRegistered"].ToString() == "Y")
                        {
                            ddl_Option.Enabled = true;
                        }
                        else
                        {
                            ddl_Option.Enabled = false;
                        }


                    }
                    else
                    {
                        ddl_Option.Enabled = true;
                    }
                }

                if (ddl_Option.SelectedValue == "0")
                {
                    ddl_Option.Enabled = true;
                }
                if (hf_locationid.Value != "" && hf_locationid.Value != "0")
                {
                    txtlocation.Text = obj_MasterCustomer.GetLocationname(Convert.ToInt32(hf_locationid.Value));
                    //  ddllocation.Visible = false;
                    //btndelete.Enabled = true;
                    //btndelete.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    if (txtpincode.Text == "")
                    {
                        txtpincode.Focus();
                        btndelete.Enabled = false;
                        btndelete.ForeColor = System.Drawing.Color.Gray;

                    }
                    else
                    {
                        dt = location.GetPincodeDetailsForLocation(txtpincode.Text);
                        if (dt.Rows.Count > 1)
                        {
                            txtlocation.Visible = false;
                            ddllocation.Visible = true;
                            btndelete.Enabled = false;
                            btndelete.ForeColor = System.Drawing.Color.Gray;
                            ddllocation.Items.Clear();
                            ddllocation.Items.Add("");
                            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                ddllocation.Items.Add(dt.Rows[i]["Location"].ToString());
                            }
                        }
                        else if (dt.Rows.Count == 1)
                        {
                            txtlocation.Visible = true;
                            ddllocation.Visible = false;
                            btndelete.Enabled = false;
                            btndelete.ForeColor = System.Drawing.Color.Gray;
                            txtlocation.Text = dt.Rows[0]["Location"].ToString();
                            hf_locationid.Value = dt.Rows[0]["LocationId"].ToString();
                            txtlocationTxtChange();
                        }
                    }
                }

                btnSave.Enabled = true;
                btnSave.ToolTip = "Update";
                btnSave1.Attributes["class"] = "btn ico-update";
                btnBack.ToolTip = "Clear";
                btnBack1.Attributes["class"] = "btn ico-cancel";
                if (txtPanNo.Text != "" && txtpancust.Text != "")
                {
                    btnpanadd.ToolTip = "Update";
                    btnpanadd1.Attributes["class"] = "btn ico-update";
                    btnpancancel.ToolTip = "Cancel";
                }
                // btnpanadd1.Attributes["class"] = "btn ico-cancel";
                if (txtcountry.Text.ToUpper() != "INDIA")
                {
                    txtdistrict.ReadOnly = true;
                    txtstate.ReadOnly = true;
                    txtcountry.ReadOnly = true;

                }
                dts = obj_MasterCustomer.SPSelGetCustomerDetailsGSTIN(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
                if (dts.Rows.Count > 0)
                {
                    txtGSTCode.Text = dts.Rows[0]["GSTCode"].ToString();
                    hdn_oldgstcode.Value = dts.Rows[0]["GSTCode"].ToString();

                }

                hid_gstcode.Value = hf_stateid.Value;
                GetBusinesscardDetails();
            }
            CustomerTDS();
            customermrcode();
            // FillBranch();
        }

        protected void chkeinvoice_CheckedChanged(object sender, EventArgs e)
        {
            if (chkeinvoice.Checked == true)
            {
                hid_einvoice.Value = "Y";
            }
            else
            {
                hid_einvoice.Value = "N";
            }
        }

        protected void ddlcategory_TextChanged(object sender, EventArgs e)
        {
            ddlfacategory.Items[4].Enabled = true;
            ddlfacategory.Items[5].Enabled = true;
            if (ddlcategory.SelectedItem.Text == "Agent")
            {
                ddlfacategory.SelectedValue = "4";
                ddlfacategory.Enabled = false;
                ddl_Option.SelectedValue = "7";
                txtcustomer.Enabled = false;

                txttanno.Enabled = true;
                txtcinno.Enabled = true;
                txt_uinno.Enabled = true;
                txt_gstin.Enabled = false;
                txtcustomer.Focus();
                creditdetailsEnable();
                ddl_description.Enabled = false;
                ddl_type.Enabled = false;
                ddl_slab.Enabled = false;
                ddl_percentage.Enabled = false;
                txt_limit.Enabled = false;
                txt_exemptions.Enabled = false;
                txt_tds_exp.Enabled = false;
                txt_certno.Enabled = false;
                txt_empto.Enabled = false;
                txt_empfrom.Enabled = false;
                // btnBack_Click(sender, e);
                btnpancancel_Click(sender, e);
                txt_overdue.Enabled = false;
                txt_exemptions.Enabled = false;
                // ddl_Option.Enabled = false;
                grd.DataSource = new DataTable();
                grd.DataBind();
                // txtcustomer.Focus();

                // add by yuvaraj 27/02/2023
                ddl_Option.SelectedValue = "7";
                ddlfacategory.SelectedValue = "4";
                //ddlfacategory.Enabled = false;
                //by13Feb23 hide by 28/02/2023
                //string date = DateTime.Now.ToString("ddMMyy");
                //string hoursmins = DateTime.Now.ToString("Hmm");
                ////string PanNoAuto = date + "" + hoursmins;
                //txtPanNo.Text = date + "" + hoursmins;
                //btnpanadd.Enabled = true;
                txtPanNo.Enabled = false;
                txtcustomer.Text = "";
                txtcustomer.Enabled = false;
                ddlcategory.SelectedValue = "5";
                txtpancust.Focus();
                Button10.Enabled = false;
                Button11.Enabled = false;
            }
            else if (ddlcategory.SelectedItem.Text == "Others")
            {
                // ddlfacategory.SelectedValue = "4";
                ddlfacategory.Enabled = false;
                ddl_Option.SelectedValue = "7";
                txtcustomer.Enabled = false;
                txtPanNo.Enabled = false;
                txttanno.Enabled = true;
                txtcinno.Enabled = true;
                txt_uinno.Enabled = true;
                txt_gstin.Enabled = false;
                txt_creditamount.Enabled = false;
                txt_creditday.Enabled = false;
                txt_exemptions.Enabled = false;
                txt_overdue.Enabled = false;
                //ddl_Option.Enabled = false;
                ddl_per.Enabled = false;
                ddlfacategory.SelectedValue = "0";
                creditdetailsEnable();
                ddl_description.Enabled = false;
                ddl_type.Enabled = false;
                ddl_slab.Enabled = false;
                ddl_percentage.Enabled = false;
                txt_limit.Enabled = false;
                txt_exemptions.Enabled = false;
                txt_tds_exp.Enabled = false;
                txt_certno.Enabled = false;
                txt_empfrom.Enabled = false;
                txt_empto.Enabled = false;
                //btnBack_Click(sender, e);
                btnpancancel_Click(sender, e);
                txt_exemptions.Enabled = false;
                txt_overdue.Enabled = false;
                grd.DataSource = new DataTable();
                grd.DataBind();

                // add by yuvaraj 27/02/2023
                ddl_Option.SelectedValue = "7";
                ddlfacategory.SelectedValue = "5";
                //ddlfacategory.Enabled = false;
                //by13Feb23 hide by yuvaraj28/02/2023
                //string date = DateTime.Now.ToString("ddMMyy");
                //string hoursmins = DateTime.Now.ToString("Hmm");
                ////string PanNoAuto = date + "" + hoursmins;
                // txtPanNo.Text = date + "" + hoursmins;
                btnpanadd.Enabled = true;
                txtcustomer.Text = "";
                txtcustomer.Enabled = false;
                ddlcategory.SelectedValue = "6";
                txtpancust.Focus();
                txtPanNo.Enabled = false;
                Button10.Enabled = false;
                Button11.Enabled = false;

            }
            else
            {
                txtPanNo.Enabled = true;
                txtpancust.Text = "";
                ddlfacategory.SelectedValue = "0";
                ddlfacategory.Enabled = true;
                ddl_Option.SelectedValue = "0";
                txtcustomer.Enabled = false;
                btnpanadd.Enabled = true;
                txtpancust.Enabled = true;
                txttanno.Enabled = true;
                txtcinno.Enabled = true;
                txt_uinno.Enabled = true;
                txt_gstin.Enabled = true;
                ddl_Option.Enabled = true;
                ddl_description.Enabled = true;
                ddl_type.Enabled = true;
                ddl_slab.Enabled = true;
                ddl_percentage.Enabled = true;
                txt_limit.Enabled = true;
                txt_exemptions.Enabled = true;
                txt_tds_exp.Enabled = true;
                txt_certno.Enabled = true;
                txt_empfrom.Enabled = true;
                txt_empto.Enabled = true;
                btnBack_Click(sender, e);
                txt_exemptions.Enabled = true;
                txt_overdue.Enabled = true;
                txtcustomer.Text = "";
                txt_creditamount.Enabled = true;
                txt_creditday.Enabled = true;
                txt_exemptions.Enabled = true;
                txt_overdue.Enabled = true;
                //ddl_Option.Enabled = false;
                ddl_per.Enabled = true;
                ddlfacategory.SelectedValue = "0";
                grd.DataSource = new DataTable();
                grd.DataBind();
                txtPanNo.Text = "";
                txtPanNo.Focus();
                Button10.Enabled = true;
                Button11.Enabled = true;
            }
            //if (ddllegaltype.SelectedValue == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Select Type');", true);
            //    //txtlocation.Focus();
            //    blerr = true;
            //    return;
            //}
            //txtcustomer.Focus();
        }

        protected void ddlfacategory_TextChanged(object sender, EventArgs e)
        {
            if (ddlfacategory.SelectedItem.Text == "Agent")
            {
                ddl_Option.SelectedValue = "7";
                txtcustomer.Enabled = false;
                btnpanadd.Enabled = true;
                txtpancust.Enabled = true;
                txttanno.Enabled = true;
                txtcinno.Enabled = true;
                txt_uinno.Enabled = true;
                txt_gstin.Enabled = false;
                ddl_Option.Enabled = true;
                if (txtPanNo.Text == "")
                {
                    txtPanNo.Focus();
                    return;
                }
                if (txtPanNo.Text == "")
                {
                    txtpancust.Focus();
                    return;
                }
            }
            else if (ddlfacategory.SelectedItem.Text == "Others")
            {
                ddl_Option.SelectedValue = "7";
                txtcustomer.Enabled = false;
                btnpanadd.Enabled = true;
                txtpancust.Enabled = true;
                txttanno.Enabled = true;
                txtcinno.Enabled = true;
                txt_uinno.Enabled = true;
                txt_gstin.Enabled = false;
                ddl_Option.Enabled = true;
                if (txtPanNo.Text == "")
                {
                    txtPanNo.Focus();
                    return;
                }
                if (txtPanNo.Text == "")
                {
                    txtpancust.Focus();
                    return;
                }
            }
            else
            {
                ddl_Option.SelectedValue = "0";
                txtcustomer.Enabled = false;
                btnpanadd.Enabled = true;
                txtpancust.Enabled = true;
                txttanno.Enabled = true;
                txtcinno.Enabled = true;
                txt_uinno.Enabled = true;
                txt_gstin.Enabled = true;
                ddl_Option.Enabled = true;
                if (txtPanNo.Text == "")
                {
                    txtPanNo.Focus();
                    return;
                }
                if (txtPanNo.Text == "")
                {
                    txtpancust.Focus();
                    return;
                }
            }
        }

        protected void txt_Salesperson_TextChanged(object sender, EventArgs e)
        {
            // getsalespersondetail();
            GetEmployeenamedetails();
        }

        public void GetEmployeenamedetails()
        {
            DataTable obj_dt = new DataTable();
           // DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
            if (hf_employeeid.Value != "")
            {
                obj_dt = da_obj_employeeobj.Sp_GetEmployenamedetails(Convert.ToInt32(hf_employeeid.Value));

                if (txt_Salesperson.Text != "")
                {
                    if (obj_dt.Rows.Count > 0)
                    {
                        //gname = Utility.Fn_DatatableToList_int16(obj_dt, "empnamecode", "employeeid");
                        txt_Salesperson.Text = obj_dt.Rows[0]["empname"].ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Enter the Valid SalesPersonName');", true);
                        txt_Salesperson.Text = "";
                        return;
                    }
                }
            }
        }

        //private void FillBranch()
        //{
        //    //DataAccess.Masters.MasterPort obj_port = new DataAccess.Masters.MasterPort();
        //    //DataTable dt_brn = new DataTable();
        //    //dt_brn = obj_port.GetAllBranchNameforPortName();

        //    //ddl_branch.Items.Add("");
        //    //for (int i = 0; i <= dt_brn.Rows.Count - 1; i++)
        //    //{
        //    //    ddl_branch.Items.Add(dt_brn.Rows[i][0].ToString());
        //    //    //ddl_branch.Items.Add(dt_brn.Rows[i][0].ToString());
        //    //}
        //    ddl_branch.Items.Clear();
        //    DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
        //    DataTable obj_dt = new DataTable();
        //    obj_dt = da_obj_HrEmp.SP_selBranchListnew();
        //    if (obj_dt.Rows.Count > 0)
        //    {
        //        ddl_branch.Items.Add("");
        //        ddl_branch.DataSource = obj_dt;
        //        ddl_branch.DataTextField = "branchname";
        //        ddl_branch.DataBind();
        //    }
        //}

        public void getsalespersondetail()
        {
            List<string> gname = new List<string>();
            DataTable obj_dt = new DataTable();
         //   DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
            //obj_dt = da_obj_employeeobj.GetLikeEmployee(txtcustomer.Text.ToUpper());
            obj_dt = da_obj_employeeobj.GetLikeEmployeenewsalesdet(txtcustomer.Text.ToUpper());
            gname = Utility.Fn_DatatableToList_int16(obj_dt, "empnamecode", "employeeid");
            if (obj_dt.Rows.Count > 0)
            {
                gname = Utility.Fn_DatatableToList_int16(obj_dt, "empnamecode", "employeeid");
                txt_Salesperson.Text = obj_dt.Rows[0]["empname"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Invalid customer');", true);
                txt_Salesperson.Text = "";
                return;
            }
            //txt_Salesperson.Focus();
        }

        protected void btncustview_Click(object sender, EventArgs e)
        {
            string str_Script = string.Empty;
            DataTable dts = obj_MasterCustomer.SPgetallpannodetails(txtPanNo.Text);
            if (dts.Rows.Count > 0)
            {
                if (txtpancust.Text != "")
                {
                    str_Script = "window.open('../Reportasp/CustomerNewrpt.aspx?Panno=" + txtPanNo.Text + "&pancustomer=" + txtpancust.Text + "&Gst=" + txt_gstin.Text +
                        "','','');";
                }
                else
                {
                    str_Script = "window.open('../Reportasp/CustomerNewrpt.aspx?Panno=" + txtPanNo.Text + "&pancustomer=" + txtcustomer.Text + "&Gst=" + txt_gstin.Text + "','','');";
                }
                ScriptManager.RegisterStartupScript(btncustview, typeof(Button), "CustomerNew", str_Script, true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Customer');", true);
                return;
            }
        }

        protected void txt_overdue_TextChanged(object sender, EventArgs e)
        {
            int due = Convert.ToInt32(txt_overdue.Text);
            if (due >= 100 && due != 100)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('Overdue is Less Then 100');", true);
                txt_overdue.Text = "";
                txt_overdue.Focus();
            }
        }

        private void FillBranch()
        {
          //  DataAccess.Masters.MasterPort obj_port = new DataAccess.Masters.MasterPort();
            DataTable dt_brn = new DataTable();
            dt_brn = obj_port.GetAllBranchNameforPortName();
            ddl_branch.Items.Clear();
            ddl_branch.Items.Add("Branch");
            for (int i = 0; i <= dt_brn.Rows.Count - 1; i++)
            {
                ddl_branch.Items.Add(dt_brn.Rows[i][0].ToString());
            }
        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_branch.SelectedValue != "")
            {
                string data = ddl_branch.SelectedValue;
                int Div_ID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                //DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();
                ownerID = obj_emp.GetBranchId(Div_ID, Convert.ToString(ddl_branch.SelectedValue.ToString()));
            }
        }

        public void Getcustomerdetails()
        {
            //DataTable dtnew = new DataTable();
            dt = obj_MasterCustomer.SPSelGetCustomerDetailsCustomer(Convert.ToInt32(hf_customerid.Value), txtcustomer.Text);
            if (dt.Rows.Count > 0)
            {
                Session["data"] = dt;
            }

            if (dt.Rows.Count > 0)
            {
                hid_pan.Value = dt.Rows[0]["CustomerPANId"].ToString();
                if (hid_pan.Value == "")
                {
                    hid_pan.Value = "0";
                }


                if (hid_pan.Value != "")
                {
                    kycGrid();
                }
                if (hf_customerid.Value != "")
                {
                    kycGrid();
                }

                //Banking();
                DataTable dts = new DataTable();
                //dt = obj_MasterCustomer.get_Gridviewnewone(Convert.ToInt32(hf_customerid.Value));
                if (hf_customerid.Value != "")
                {
                    dts = obj_MasterCustomer.SP_getbankdetailsAgent(Convert.ToInt32(hf_customerid.Value), txtcustomer.Text);
                    if (dts.Rows.Count > 0)
                    {
                        GridView1.DataSource = dts;
                        GridView1.DataBind();
                    }
                }

                // txtcustomer.Text = txtpancust.Text;
                if (dt.Rows[0]["customertype"].ToString() == "C")
                {
                    ddlCType.SelectedValue = "C";
                }
                else if (dt.Rows[0]["customertype"].ToString() == "P")
                {
                    ddlCType.SelectedValue = "P";
                }
                else if (dt.Rows[0]["customertype"].ToString() == "W")
                {
                    ddlCType.SelectedValue = "W";
                }



                if (dt.Rows[0]["empperiodfrom"] != System.DBNull.Value)
                {
                    string Dateempfrom = dt.Rows[0]["empperiodfrom"].ToString();
                    DateTime _retVals = Convert.ToDateTime(Dateempfrom);
                    txt_empfrom.Text = _retVals.ToString("dd/MM/yyyy");
                    if (txt_empfrom.Text == "01/01/1999")
                    {
                        txt_empfrom.Text = "";
                    }
                }
                else
                {
                    txt_empfrom.Text = "";
                }
                if (dt.Rows[0]["empperiodto"] != System.DBNull.Value)
                {
                    string dateempto = dt.Rows[0]["empperiodto"].ToString();
                    DateTime _retVals = Convert.ToDateTime(dateempto);
                    txt_empto.Text = _retVals.ToString("dd/MM/yyyy");
                    if (txt_empto.Text == "01/01/1999")
                    {
                        txt_empto.Text = "";
                    }
                }
                else
                {
                    txt_empto.Text = "";
                }
                if (dt.Rows[0]["limit"] != System.DBNull.Value)
                {
                    txt_limit.Text = dt.Rows[0]["limit"].ToString();
                }
                else
                {
                    txt_limit.Text = "";
                }
                if (txt_limit.Text == "0.0000")
                {
                    txt_limit.Text = "";

                }
                if (dt.Rows[0]["tdsemp"] != System.DBNull.Value)
                {
                    txt_tds_exp.Text = dt.Rows[0]["tdsemp"].ToString();
                    if (txt_tds_exp.Text == "0")
                    {
                        txt_tds_exp.Text = "";
                    }
                }
                else
                {
                    txt_tds_exp.Text = "0";
                }
                if (txt_tds_exp.Text == "0.0000")
                {
                    txt_tds_exp.Text = "";
                }

                if (dt.Rows[0]["certno"] != System.DBNull.Value)
                {
                    txt_certno.Text = dt.Rows[0]["certno"].ToString();
                    if (txt_certno.Text == "0")
                    {
                        txt_certno.Text = "";
                    }
                }
                else
                {
                    txt_certno.Text = "";
                }
                //dt.Rows[0]["customerid"].ToString()
                //kalai start
                // txt_gstin.Text = dt.Rows[0]["gstin"].ToString();
                //kalai end
                hf_customerid.Value = dt.Rows[0]["customerid"].ToString();
                txtstreet.Text = dt.Rows[0]["address"].ToString();
                hf_portid.Value = dt.Rows[0]["city"].ToString();
                Session["portid"] = hf_portid.Value;
                txtcity.Text = port.GetPortname(Convert.ToInt32(hf_portid.Value));
                hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(txtcity.Text.ToUpper()));
                txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                txtpincode.Text = dt.Rows[0]["zip"].ToString();
                txtllisd.Text = dt.Rows[0]["llisd"].ToString();
                txtllstd.Text = dt.Rows[0]["llstd"].ToString();
                txtlandline.Text = dt.Rows[0]["phone"].ToString();
                txtfaxisd.Text = dt.Rows[0]["faxisd"].ToString();
                txtfaxstd.Text = dt.Rows[0]["faxstd"].ToString();
                txtfax.Text = dt.Rows[0]["fax"].ToString();
                txtemail.Text = dt.Rows[0]["email"].ToString();
                //txt_Salesperson.Text = dt.Rows[0]["empname"].ToString();
                string empcode = dt.Rows[0]["employeeid"].ToString();
                if (empcode != "")
                {
                    hf_employeeid.Value = empcode;
                    txt_Salesperson.Text = dt.Rows[0]["empname"].ToString();
                }
                //    txtPanNo.Text = dt.Rows[0]["panno"].ToString();
                //  DataTable grid = obj_MasterCustomer.Getcustgridwithpan(dt.Rows[0]["panno"].ToString());
                //if (grid.Rows.Count > 0)
                //{
                //    grd.DataSource = grid;
                //    grd.DataBind();
                //}
                txtServiceTaxNo.Text = dt.Rows[0]["stno"].ToString();
                //txtpancust.Text = txtcustomer.Text;
                /***********************************************/
                txtunit.Text = dt.Rows[0]["unit#"].ToString();
                txtbuildingname.Text = dt.Rows[0]["buildingname"].ToString();
                txtdoor.Text = dt.Rows[0]["door#"].ToString();
                hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                txttds.Text = dt.Rows[0]["tds"].ToString();
                //txtfax.Text = dt.Rows[0]["fax"].ToString();
                txtmblisd.Text = dt.Rows[0]["mblisd"].ToString();
                txtMobile.Text = dt.Rows[0]["mobile"].ToString();
                //status = Convert.ToChar(dt.Rows[0]["status"].ToString());
                if (hf_districtid.Value != "")
                {
                    txtdistrict.Text = obj_MasterCustomer.GetStateDistrictname(Convert.ToInt32(hf_districtid.Value));
                    if (txtdistrict.Text == "0")
                    {
                        txtdistrict.Text = "";
                    }
                }

                if (hf_stateid.Value != "")
                {
                    txtstate.Text = obj_MasterCustomer.GetStatename(Convert.ToInt32(hf_stateid.Value));
                    if (txtstate.Text == "0")
                    {
                        txtstate.Text = "";
                    }
                }
                txtmailcom.Text = dt.Rows[0]["commailid"].ToString();
                txtmailimp.Text = dt.Rows[0]["impmailid"].ToString();
                txtmailexport.Text = dt.Rows[0]["expmailid"].ToString();
                txtmailfin.Text = dt.Rows[0]["finmailid"].ToString();
                txtmailmanag.Text = dt.Rows[0]["managmail"].ToString();

                txtmanagptc.Text = dt.Rows[0]["managptc"].ToString();
                txtcomptc.Text = dt.Rows[0]["comptc"].ToString();
                txtexpptc.Text = dt.Rows[0]["expptc"].ToString();
                txtimpptc.Text = dt.Rows[0]["impptc"].ToString();
                txtfinptc.Text = dt.Rows[0]["finptc"].ToString();
                txt_gstin.Text = dt.Rows[0]["gstin"].ToString();
                //txt_uinno.Text = dt.Rows[0]["uinno"].ToString();
                //txttanno.Text = dt.Rows[0]["tanno"].ToString();
                //txtcinno.Text = dt.Rows[0]["cinno"].ToString();
                if (txt_gstin.Text != "")
                {
                    //txt_RCM.Enabled = false;
                    //txt_unregistered.Enabled = false;
                    //txt_RCM.Checked = false;
                    //txt_unregistered.Checked = false;
                }
                else
                {
                    //txt_RCM.Enabled = true;
                    //txt_unregistered.Enabled = true;
                }
                card.Text = txtcustomer.Text + " GST #  " + txt_gstin.Text;
                if (txt_uinno.Text != "")
                {
                    //txt_RCM.Enabled = false;
                    //txt_unregistered.Enabled = false;
                    //txt_RCM.Checked = false;
                    //txt_unregistered.Checked = false;
                }
                else
                {
                    //txt_RCM.Enabled = true;
                    //txt_unregistered.Enabled = true;
                }

                if (dt.Rows[0]["RCM"].ToString() == "Y")
                {
                    // txt_RCM.Checked = true;
                    ddl_Option.SelectedValue = "1";
                }
                else if (dt.Rows[0]["UnRegistered"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "2";
                }
                else if (dt.Rows[0]["UnRegistered"].ToString() == "A")
                {
                    ddl_Option.SelectedValue = "7";
                    ddl_Option.Enabled = false;
                }
                else if (dt.Rows[0]["gstexemption"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "3";
                }
                else if (dt.Rows[0]["Sez"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "6";
                }
                else if (dt.Rows[0]["Register"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "5";
                }
                else if (dt.Rows[0]["SezIgst"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "4";
                    // txt_gstexi.Checked = true;
                }
                //else if (dt.Rows[0]["Not Applicable"].ToString() == "A")
                //{
                //    ddl_Option.SelectedValue = "7";
                //    // txt_gstexi.Checked = true;
                //}
                //else
                //{
                //    ddl_Option.SelectedValue = "0";
                //}

                //newly added on 07012022 
                if (dt.Rows[0]["IsCoload"].ToString() == "Y")
                {
                    ChkCoload.Checked = true;
                    txt_Coloadercode.Enabled = true;
                    txt_ColoadRemarks.Enabled = true;
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ColoadRemarks"].ToString()) == true)
                    {
                        txt_ColoadRemarks.Text = dt.Rows[0]["ColoadRemarks"].ToString();

                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Coloadercode"].ToString()) == true)
                    {
                        txt_Coloadercode.Text = dt.Rows[0]["Coloadercode"].ToString();

                    }
                }
                else
                {
                    ChkCoload.Checked = false;
                    txt_ColoadRemarks.Enabled = false;
                    txt_Coloadercode.Enabled = false;
                }
                //end
                byte[] imageByte = null;
                if (!DBNull.Value.Equals(dt.Rows[0]["mgmtheadimg"]))
                {
                    imageByte = ((byte[])dt.Rows[0]["mgmtheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp.ImageUrl = "~/images/visitingcard_img.jpg";
                }

                if (!DBNull.Value.Equals(dt.Rows[0]["cmheadimg"]))
                {

                    imageByte = ((byte[])dt.Rows[0]["cmheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp1.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp1.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp1.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp1.ImageUrl = "~/images/visitingcard_img.jpg";
                }
                if (!DBNull.Value.Equals(dt.Rows[0]["expheadimg"]))
                {
                    imageByte = ((byte[])dt.Rows[0]["expheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp2.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp2.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp2.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp2.ImageUrl = "~/images/visitingcard_img.jpg";
                }
                if (!DBNull.Value.Equals(dt.Rows[0]["finheadimg"]))
                {
                    imageByte = ((byte[])dt.Rows[0]["finheadimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp3.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp3.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp3.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp3.ImageUrl = "~/images/visitingcard_img.jpg";
                }
                if (!DBNull.Value.Equals(dt.Rows[0]["impimg"]))
                {

                    imageByte = ((byte[])dt.Rows[0]["impimg"]);
                    string base64String = Convert.ToBase64String(imageByte);
                    hdn_Flag.Value = base64String;
                    Img_Emp4.ImageUrl = "data:image/png;base64," + base64String;
                    if (base64String == "")
                    {
                        Img_Emp4.ImageUrl = "~/images/visitingcard_img.jpg";
                    }
                    else
                    {
                        Img_Emp4.ImageUrl = "data:image/png;base64," + base64String;
                    }
                }
                else
                {
                    Img_Emp4.ImageUrl = "~/images/visitingcard_img.jpg";
                }
                hf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                if (dt.Rows[0]["Register"].ToString() == "Y")
                {
                    DataTable DtNew = obj_MasterCustomer.checkvoucherraise(Convert.ToInt32(hf_customerid.Value));
                    if (DtNew.Rows.Count > 0)
                    {
                        ddl_Option.Enabled = false;
                    }
                    else
                    {
                        ddl_Option.Enabled = true;
                    }
                }
                else
                {
                    DataTable DtNew = obj_MasterCustomer.checkvoucherraise(Convert.ToInt32(hf_customerid.Value));
                    if (DtNew.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["UnRegistered"].ToString() == "Y")
                        {
                            ddl_Option.Enabled = true;
                        }
                        else
                        {
                            ddl_Option.Enabled = false;
                        }
                    }
                    else if (dt.Rows[0]["UnRegistered"].ToString() == "A")
                    {
                        ddl_Option.Enabled = false;
                    }
                    else
                    {
                        ddl_Option.Enabled = true;
                    }
                }
                if (ddl_Option.SelectedValue == "0")
                {
                    ddl_Option.Enabled = true;
                }
                if (hf_locationid.Value != "" && hf_locationid.Value != "0")
                {
                    txtlocation.Text = obj_MasterCustomer.GetLocationname(Convert.ToInt32(hf_locationid.Value));
                    ddllocation.Visible = false;
                    btndelete.Enabled = true;
                    btndelete.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    if (txtpincode.Text == "")
                    {
                        txtpincode.Focus();
                        btndelete.Enabled = false;
                        btndelete.ForeColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        dt = location.GetPincodeDetailsForLocation(txtpincode.Text);
                        if (dt.Rows.Count > 1)
                        {
                            txtlocation.Visible = false;
                            ddllocation.Visible = true;
                            btndelete.Enabled = false;
                            btndelete.ForeColor = System.Drawing.Color.Gray;
                            ddllocation.Items.Clear();
                            ddllocation.Items.Add("");
                            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                ddllocation.Items.Add(dt.Rows[i]["Location"].ToString());
                            }
                        }
                        else if (dt.Rows.Count == 1)
                        {
                            txtlocation.Visible = true;
                            ddllocation.Visible = false;
                            btndelete.Enabled = false;
                            btndelete.ForeColor = System.Drawing.Color.Gray;
                            txtlocation.Text = dt.Rows[0]["Location"].ToString();
                            hf_locationid.Value = dt.Rows[0]["LocationId"].ToString();
                            txtlocationTxtChange();
                        }
                    }
                }

                btnSave.Enabled = true;
                btnSave.ToolTip = "Update";
                btnSave1.Attributes["class"] = "btn ico-update";
                btnBack.ToolTip = "Clear";
                btnBack1.Attributes["class"] = "btn ico-cancel";
                if (txtPanNo.Text != "" && txtpancust.Text != "")
                {
                    btnpanadd.ToolTip = "Update";
                    btnpanadd1.Attributes["class"] = "btn ico-update";
                    btnpancancel.ToolTip = "Cancel";
                }
                // btnpanadd1.Attributes["class"] = "btn ico-cancel";
                if (txtcountry.Text.ToUpper() != "INDIA")
                {
                    txtdistrict.ReadOnly = true;
                    txtstate.ReadOnly = true;
                    txtcountry.ReadOnly = true;
                }
                dts = obj_MasterCustomer.SPSelGetCustomerDetailsGSTIN(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
                if (dts.Rows.Count > 0)
                {
                    txtGSTCode.Text = dts.Rows[0]["GSTCode"].ToString();
                    hdn_oldgstcode.Value = dts.Rows[0]["GSTCode"].ToString();

                }

                hid_gstcode.Value = hf_stateid.Value;
                GetBusinesscardDetails();
            }
            CustomerTDS();
            customermrcode();
            FillBranch();
            if (ddlcategory.SelectedItem.Text == "Agent")
            {
                // creditdetailsEnable();
                Button10.Enabled = false;
                Button11.Enabled = false;
            }
            else if (ddlcategory.SelectedItem.Text == "Others")
            {
                //creditdetailsEnable();
                Button10.Enabled = false;
                Button11.Enabled = false;
            }
            else
            {
                if (grd.Rows.Count > 0)
                {
                    ddlProductType.Enabled = true;
                    txt_vol.Enabled = true;
                    ddlvolumetype.Enabled = true;
                    txt_revenue.Enabled = true;
                    txt_creditdays.Enabled = true;
                    txt_creditamount.Enabled = true;
                    txt_exemptions.Enabled = true;
                    txt_overdue.Enabled = true;
                    ddl_per.Enabled = true;
                    txtCreditAboveamt.Enabled = true;
                    btnCreditRequestAdd.Enabled = true;
                    btncredit.Enabled = true;
                    btntds.Enabled = true;
                }
            }
        }


        protected void btnCreditRequestAdd_Click(object sender, EventArgs e)
        {
            if (txtPanNo.Text != "" && txtpancust.Text != "")
            {
                DataTable dtgrid = new DataTable();
                int prod;
                prod = Convert.ToInt32(ddlProductType.SelectedValue);
                string str_usermailid = Session["usermailid"].ToString();
                string str_mailpwd = Session["usermailpwd"].ToString();
                string strDate, strDate1;
                //DataAccess.Masters.MasterCreditApproval obj_creditapp = new DataAccess.Masters.MasterCreditApproval();
                //DataAccess.Masters.MasterCustomerGroup obj_group = new DataAccess.Masters.MasterCustomerGroup();
                //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                int groupid = 0;
                DataAccess.Masters.MasterCustomerGroup obj_main = new DataAccess.Masters.MasterCustomerGroup();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                obj_main.GetDataBase(Ccode);
                string data = string.Empty;
                dt = obj_main.GetAllGrouppan(txtPanNo.Text.ToUpper(), txtpancust.Text, "", 0);
                if (dt.Rows.Count > 0)
                {
                    data = dt.Rows[0]["groupid"].ToString();
                    groupid = Convert.ToInt32(dt.Rows[0]["groupid"].ToString());
                }
                if (groupid != 0)
                {
                    int Div_ID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    // groupid = Convert.ToInt32(hdn_cusid.Value.ToString());
                    string vtype = ddlvolumetype.SelectedValue.ToString();
                    DateTime now = DateTime.Now;
                    DateTime RegDtae = DateTime.Now;
                    DateTime INDate = DateTime.Now;
                    if (ddlvolumetype.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Select Volume type');", true);
                        ddlvolumetype.Focus();
                        return;
                    }
                    if (txt_vol.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Kindly Enter the Volume');", true);
                        txt_vol.Focus();

                        return;
                    }
                    if (txt_creditdays.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Kindly Enter the Credit days');", true);
                        txt_creditdays.Focus();

                        return;
                    }
                    if (txtCreditAboveamt.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Kindly Enter the Credit amount');", true);
                        txtCreditAboveamt.Focus();

                        return;
                    }
                    if (txt_revenue.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Kindly Enter the Revenue');", true);
                        txt_revenue.Focus();

                        return;
                    }
                    if (ddlProductType.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Select Product');", true);
                        return;
                    }

                    int salesname = 0;
                    if (hf_employeeid.Value != "")
                    {
                        salesname = Convert.ToInt32(hf_employeeid.Value.ToString());
                    }
                    int clienttypeval = 1;
                    string remarks = "";
                    int cridtype = 1;
                    string txt_AboutCust = "";
                    int categoryval = 2;
                    string txt_DocReceived = "";
                    string ptc = "";
                    ownerID = 2;
                    int apptype = 1;
                    int EmpId = Convert.ToInt32(Session["LoginEmpId"].ToString());
                    //DataAccess.Masters.MasterCreditApproval Appro_obj = new DataAccess.Masters.MasterCreditApproval();
                    DateTime date = Convert.ToDateTime(now);
                    string datapo = "";
                    string canno = "";
                    // string txt_vol = "1";
                    DataTable dts = new DataTable();
                    dts = obj_creditapp.Getdetailscreditapproval(groupid, Div_ID);
                    if (dts.Rows.Count == 0)
                    {
                        obj_creditapp.InsertMasterCreditApp(groupid, categoryval, txtPanNo.Text.ToUpper(), txt_gstin.Text.ToUpper(), RegDtae, INDate,
                            txt_DocReceived, datapo, txtlandline.Text, txtMobile.Text, txt_email.Text, clienttypeval, txt_vol.Text.ToString(), vtype, Convert.ToDouble(txt_revenue.Text),
                            txt_AboutCust, Convert.ToInt16(txt_creditdays.Text.Trim()),
                            Convert.ToDouble(txtCreditAboveamt.Text.ToUpper().Trim()), cridtype, ownerID, Convert.ToInt32(Session["LoginEmpId"]), remarks, Div_ID);
                        string approdata = Appro_obj.UpdMasterCAppNew(groupid, canno, date, 0, 0, 0, ' ', 0, 0, 0, ' ', 0, 0, 0, ' ', EmpId, Convert.ToDouble(txtCreditAboveamt.Text.Trim()), Convert.ToInt32(txt_creditdays.Text.Trim()), apptype, Div_ID);
                        int exp = 3;
                        int due = 50;
                        int intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                        string exmode = "";
                        if (ddl_per.Text == "Annual")
                        {
                            exmode = "A";
                        }
                        else if (ddl_per.Text == "Month")
                        {
                            exmode = "M";
                        }
                        else
                        {
                            exmode = "M";
                        }
                        Appro_obj.UpdMasterCreditApprovalCUSTLIMITS(groupid, intBranchID, Div_ID, exp, due, exmode);
                        obj_creditapp.UpdMasterCreditApp(groupid, categoryval, txtPanNo.Text.ToUpper().Trim(), txt_gstin.Text.ToUpper(), RegDtae, INDate, txt_DocReceived, ptc, txtlandline.Text, txtMobile.Text, txt_email.Text.ToUpper(), clienttypeval, txt_vol.Text.ToUpper(), vtype, Convert.ToDouble(txt_revenue.Text.ToUpper()), txt_AboutCust.ToUpper().Trim(), Convert.ToInt32(txt_creditdays.Text.ToUpper().Trim()), Convert.ToDouble(txtCreditAboveamt.Text.Trim()), cridtype, ownerID, salesname, remarks.ToUpper(), Div_ID, prod);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 288, 1, Convert.ToInt32(Session["LoginBranchid"]), "groupid for " + groupid);
                    }
                    else
                    {

                        obj_creditapp.UpdMasterCreditApp(groupid, categoryval, txtPanNo.Text.ToUpper().Trim(), txt_gstin.Text.ToUpper(), RegDtae, INDate, txt_DocReceived, ptc, txtlandline.Text, txtMobile.Text, txt_email.Text.ToUpper(), clienttypeval, txt_vol.Text.ToUpper(), vtype, Convert.ToDouble(txt_revenue.Text.ToUpper()), txt_AboutCust.ToUpper().Trim(), Convert.ToInt32(txt_creditdays.Text.ToUpper().Trim()), Convert.ToDouble(txtCreditAboveamt.Text.Trim()), cridtype, ownerID, salesname, remarks.ToUpper(), Div_ID, prod);
                    }

                    // update 19/12/2022
                    obj_creditapp.updateCreditapprovalproduct(groupid, prod, Convert.ToInt32(txt_creditdays.Text), Convert.ToInt32(txt_creditdays.Text), Convert.ToDouble(txtCreditAboveamt.Text), INDate, EmpId);

                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 288, 2, Convert.ToInt32(Session["LoginBranchid"]), "groupid for " + groupid);

                    if (btnCreditRequestAdd.ToolTip == "ADD")
                    {

                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Product Details Saved')", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Product Details Updated')", true);

                    }

                    btnCreditRequestAdd.ToolTip = "ADD";
                    btn_add1.Attributes["class"] = "btn btn-add1 MCtrl MT10";
                    //   dtgrid = obj_creditapp.selgridMasterCreditApp4Prod(groupid, Convert.ToInt32(Session["LoginDivisionId"]));
                    dtgrid = obj_creditapp.selgridMasterCreditApp4Prod(groupid, Convert.ToInt32(Session["LoginDivisionId"]));
                    DataRow dr = dtgrid.NewRow();
                    if (dtgrid.Rows.Count > 0)
                    {
                        DataRow dr1 = dtgrid.NewRow();
                        dr1["VolumeType"] = "Total";
                        dr1["Creditdays"] = Convert.ToDouble(dtgrid.Compute("sum(Creditdays)", string.Empty)).ToString();
                        dr1["CreditAmount"] = Convert.ToDouble(dtgrid.Compute("sum(CreditAmount)", string.Empty)).ToString("0.00");
                        dtgrid.Rows.Add(dr1);
                        Gridcreditreq.DataSource = dtgrid;
                        Gridcreditreq.DataBind();
                        pnlcreditreq.Visible = true;
                    }
                    ddlvolumetype.SelectedIndex = 0;
                    txt_vol.Text = "";
                    txt_creditdays.Text = "";
                    txtCreditAboveamt.Text = "";
                    txt_revenue.Text = "";
                    ddlProductType.SelectedIndex = 0;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Correct Customer name')", true);
                    return;
                }
            }
        }

        private void FillVolumeType()
        {
            // ddlvolumetype.Items.Add("Select");
            ddlvolumetype.Items.Add("Teus");
            ddlvolumetype.Items.Add("CBM");
            ddlvolumetype.Items.Add("Kgs");
        }

        protected void Gridcreditreq_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtgrid1 = new DataTable();
            DataTable dtgrid = new DataTable();
            int index = Gridcreditreq.SelectedRow.RowIndex;
            string prod = Gridcreditreq.SelectedRow.Cells[1].Text;
            if (prod == "All")
            {
                ddlProductType.SelectedValue = "1";
            }
            if (prod == "OceanExport-FCL")
            {
                ddlProductType.SelectedValue = "2";
            }
            if (prod == "OceanExport-LCL")
            {
                ddlProductType.SelectedValue = "3";
            }
            if (prod == "OceanImport-FCL")
            {
                ddlProductType.SelectedValue = "4";
            }
            if (prod == "OceanImport-LCL")
            {
                ddlProductType.SelectedValue = "5";
            }
            if (prod == "AirExport")
            {
                ddlProductType.SelectedValue = "6";
            }
            if (prod == "AirImport")
            {
                ddlProductType.SelectedValue = "7";
            }
            //  ddlProductType.= Gridcreditreq.SelectedRow.Cells[1].Text;
            string datata = Gridcreditreq.SelectedRow.Cells[1].Text;
            if (datata != "&nbsp;")
            {
                txt_vol.Text = Gridcreditreq.SelectedRow.Cells[2].Text;
                ddlvolumetype.SelectedValue = Gridcreditreq.SelectedRow.Cells[3].Text;
                txt_revenue.Text = Gridcreditreq.SelectedRow.Cells[4].Text;
                txt_creditdays.Text = Gridcreditreq.SelectedRow.Cells[5].Text;
                txtCreditAboveamt.Text = Gridcreditreq.SelectedRow.Cells[6].Text;
                txtCreditAboveamt.Text = Convert.ToDecimal(txtCreditAboveamt.Text).ToString("#,##0");
                hid_crid.Value = Gridcreditreq.SelectedRow.Cells[8].Text;
                btnCreditRequestAdd.ToolTip = "Update";
                btn_add1.Attributes["class"] = "btn btn-UpdateAdd2";
            }
            else
            {
                ddlProductType.SelectedValue = "0";
                txt_revenue.Text = "";
                ddlvolumetype.SelectedValue = "0";
                txt_creditdays.Text = "";
                txtCreditAboveamt.Text = "";
                txt_vol.Text = "";
                btnCreditRequestAdd.ToolTip = "ADD";
                btn_add1.Attributes["class"] = "btn btn-add1 MCtrl MT10";
            }
            //trantype = GrdCredit.SelectedRow.Cells[3].Text;
            //Gridcreditreq.DataSource = dtgrid1;
            //Gridcreditreq.DataBind();
            //DataRow dr = dtgrid1.NewRow();
            //if (dtgrid1.Rows.Count > 0)
            //{
            //    DataRow dr1 = dtgrid1.NewRow();
            //    dr1["VolumeType"] = "Total";
            //    dr1["Creditdays"] = Convert.ToDouble(dtgrid1.Compute("sum(Creditdays)", string.Empty)).ToString();
            //    dr1["CreditAmount"] = Convert.ToDouble(dtgrid1.Compute("sum(CreditAmount)", string.Empty)).ToString("0.00");
            //    dtgrid1.Rows.Add(dr1);
            //    Gridcreditreq.DataSource = dtgrid1;
            //    Gridcreditreq.DataBind();
            //}
            //else
            //{
            //    Gridcreditreq.DataSource = dtgrid1;
            //    Gridcreditreq.DataBind();
            //}

        }

        protected void Gridcreditreq_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Gridcreditreq, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Imgsb_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dtSB = new DataTable();
            DataTable dtgrid1 = new DataTable();
            ImageButton lb = (ImageButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
           // DataAccess.Masters.MasterCreditApproval obj_creditapp = new DataAccess.Masters.MasterCreditApproval();
            if (Gridcreditreq.Rows.Count > 0)
            {
                int rowID = gvRow.RowIndex;
                hid_crid.Value = Gridcreditreq.Rows[rowID].Cells[8].Text;
            }
            int groupid = 0;
            DataAccess.Masters.MasterCustomerGroup obj_main = new DataAccess.Masters.MasterCustomerGroup();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_main.GetDataBase(Ccode);
            string data = string.Empty;
            dt = obj_main.GetAllGrouppan(txtPanNo.Text.ToUpper(), txtpancust.Text, "", 0);
            if (dt.Rows.Count > 0)
            {
                data = dt.Rows[0]["groupid"].ToString();
                groupid = Convert.ToInt32(dt.Rows[0]["groupid"].ToString());
            }
            if (groupid != 0)
            {
                // hid_crid.Value = Gridcreditreq.SelectedRow.Cells[8].Text;
                DataTable dtgrid = new DataTable();
                if (hid_crid.Value != "")
                {
                    dtgrid = obj_creditapp.delgridMasterCreditApp4Prod(groupid, Convert.ToInt32(hid_crid.Value));
                    dtgrid1 = obj_creditapp.selgridMasterCreditApp4Prod(groupid, Convert.ToInt32(Session["LoginDivisionId"]));
                    DataRow dr = dtgrid1.NewRow();
                    if (dtgrid1.Rows.Count > 0)
                    {
                        DataRow dr1 = dtgrid1.NewRow();
                        dr1["VolumeType"] = "Total";
                        dr1["Creditdays"] = Convert.ToDouble(dtgrid1.Compute("sum(Creditdays)", string.Empty)).ToString();
                        dr1["CreditAmount"] = Convert.ToDouble(dtgrid1.Compute("sum(CreditAmount)", string.Empty)).ToString("0.00");
                        dtgrid1.Rows.Add(dr1);
                        Gridcreditreq.DataSource = dtgrid1;
                        Gridcreditreq.DataBind();
                        pnlcreditreq.Visible = true;
                    }
                    else
                    {
                        Gridcreditreq.DataSource = dtgrid1;
                        Gridcreditreq.DataBind();
                        pnlcreditreq.Visible = true;

                    }
                    ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "DataFound", "alertify.alert('Product Details Deleted');", true);
                    btnCreditRequestAdd.ToolTip = "ADD";
                    btn_add1.Attributes["class"] = "btn btn-add1 MCtrl MT10";
                }
            }
        }

        public void fillcreditgrd()
        {
            int groupid = 0;
            DataAccess.Masters.MasterCustomerGroup obj_main = new DataAccess.Masters.MasterCustomerGroup();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_main.GetDataBase(Ccode);
            string data = string.Empty;

            dt = obj_main.GetAllGrouppan(txtPanNo.Text.ToUpper(), txtpancust.Text, "", 0);
            if (dt.Rows.Count > 0)
            {
                data = dt.Rows[0]["groupid"].ToString();
                groupid = Convert.ToInt32(dt.Rows[0]["groupid"].ToString());
            }
            if (groupid != 0)
            {
                DataTable dts = new DataTable();
              //  DataAccess.Masters.MasterCreditApproval obj_creditapp = new DataAccess.Masters.MasterCreditApproval();
                dts = obj_creditapp.selgridMasterCreditApp4Prod(groupid, Convert.ToInt32(Session["LoginDivisionId"]));
                DataRow dr = dts.NewRow();
                if (dts.Rows.Count > 0)
                {
                    DataRow dr1 = dts.NewRow();
                    dr1["VolumeType"] = "Total";
                    dr1["Creditdays"] = Convert.ToDouble(dts.Compute("sum(Creditdays)", string.Empty)).ToString();
                    dr1["CreditAmount"] = Convert.ToDouble(dts.Compute("sum(CreditAmount)", string.Empty)).ToString("0.00");
                    dts.Rows.Add(dr1);

                    Gridcreditreq.DataSource = dts;
                    Gridcreditreq.DataBind();
                    pnlcreditreq.Visible = true;
                }
            }
        }

        public void PanSavetds() // add by yuvaraj 21-12-2022
        {
            try
            {
                //CheckData();
                if (txtPanNo.Text == "" || txtpancust.Text == "")
                {
                    hf_customerid.Value = obj_MasterCustomer.GetCustomerid(txtcustomer.Text.ToUpper()).ToString();
                }
                else
                {

                }
                if (ddl_description.SelectedItem.Text != "" && ddl_description.SelectedItem.Text != "Description" && ddl_slab.SelectedItem.Text != "" && ddl_slab.SelectedItem.Text != "Slab" && ddl_type.SelectedItem.Text != "" && ddl_type.SelectedItem.Text != "Type" && ddl_percentage.SelectedItem.Text != "" && ddl_percentage.SelectedItem.Text != "Percentage")
                {
                    if (blnerr == true)
                    {
                        blnerr = false;
                        return;
                    }

                    int int_TDSid = obj_da_TDS.GetTDSid(ddl_description.SelectedItem.Text, char.Parse(hid_type.Value.ToString()), ddl_slab.SelectedItem.Text, double.Parse(ddl_percentage.SelectedItem.Text));

                    if (int_TDSid == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Select Vaild Details');", true);
                    }
                    else
                    {
                        obj_da_TDS.UpdPANTDSidnew(int_TDSid, txtPanNo.Text.ToString(), double.Parse(ddl_percentage.SelectedItem.Text));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void btntds_Click(object sender, EventArgs e)
        {

            if (hidpaninput.Value == "Y")
            {
                txtPanNo.Text = hid_panno.Value;
            }
            txtPanNo.Text = hid_panno.Value;
            if (grd.Rows.Count > 0)
            {
                int i = 0;
                for (i = 0; i < grd.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        int index = 0;
                        string city = grd.Rows[index].Cells[3].Text; //   grd.SelectedRow.Cells[4].Text;
                        //string country = grd.Columns[0].ToString();
                        hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(city.ToUpper()));
                        txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                        hf_customerid.Value = grd.Rows[index].Cells[4].Text;

                        Session["customeriddetailss"] = hf_customerid.Value;

                    }
                }
            }
            if (hf_customerid.Value != "" && hf_customerid.Value != "0")
            {
                iframecost.Attributes["src"] = "mastercustomertds.aspx";
                popupfro.Visible = true;
                PopupBL.Show();
                Session["panno"] = txtPanNo.Text;
                Session["pancustomer"] = txtpancust.Text;
                Session["customerid"] = hf_customerid.Value;
                Session["customerCountryid"] = hf_countryid.Value;
                Session["hf_employeeided"] = hf_employeeid.Value;
                Session["hidpaninput"] = hidpaninput.Value;
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Enter the Valid Customer Name');", true);
                txtpancust.Focus();
                return;
            }
        }

        protected void btncredit_Click(object sender, EventArgs e)
        {
            if (hidpaninput.Value == "Y")
            {
                txtPanNo.Text = hid_panno.Value;
            }
            txtPanNo.Text = hid_panno.Value;
            if (grd.Rows.Count > 0)
            {
                int i = 0;
                for (i = 0; i < grd.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        int index = 0;
                        string city = grd.Rows[index].Cells[3].Text; //   grd.SelectedRow.Cells[4].Text;
                        //string country = grd.Columns[0].ToString();
                        hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(city.ToUpper()));
                        txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                        hf_customerid.Value = grd.Rows[index].Cells[4].Text;

                        Session["customeriddetailss"] = hf_customerid.Value;

                    }
                }
            }

            if (!string.IsNullOrEmpty(Session["customeriddetailss"].ToString()))
            {
                hf_customerid.Value = Session["customeriddetailss"].ToString();
            }
            if (hidpaninput.Value == "Y")
            {
                txtPanNo.Text = hid_panno.Value;
            }
            if (hid_pan.Value != "")
            {
                iframecost.Attributes["src"] = "MastercustomerCredit.aspx";
                popupfro.Visible = true;
                PopupBL.Show();
                Session["pannocredit"] = txtPanNo.Text;
                Session["pancustomercredit"] = txtpancust.Text;
                Session["gst"] = txt_gstin.Text;
                Session["hf_employeeided"] = hf_employeeid.Value;
                Session["hidpaninput"] = hidpaninput.Value;
            }
            else
            {
                iframecost.Attributes["src"] = "MastercustomerCredit.aspx";
                popupfro.Visible = true;
                PopupBL.Show();
                Session["pannocredit"] = txtPanNo.Text;
                Session["pancustomercredit"] = txtpancust.Text;
                Session["gst"] = txt_gstin.Text;
                Session["hf_employeeided"] = hf_employeeid.Value;
                Session["hidpaninput"] = hidpaninput.Value;
            }
            // }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Enter the Valid Customer Name');", true);
            //    txtpancust.Focus();
            //    return;
            //}
        }

        protected void btn_kyc_Click(object sender, EventArgs e)
        {
            txtPanNo.Text = hid_panno.Value;
            if (hidpaninput.Value == "Y")
            {
                txtPanNo.Text = hid_panno.Value;
            }
            if (grd.Rows.Count > 0)
            {
                int i = 0;
                for (i = 0; i < grd.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        int index = 0;
                        string city = grd.Rows[index].Cells[3].Text; //   grd.SelectedRow.Cells[4].Text;
                        //string country = grd.Columns[0].ToString();
                        hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(city.ToUpper()));
                        txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                        hf_customerid.Value = grd.Rows[index].Cells[4].Text;

                        Session["customeriddetailss"] = hf_customerid.Value;

                    }
                }
            }
            if (!string.IsNullOrEmpty(Session["customeriddetailss"].ToString()))
            {
                hf_customerid.Value = Session["customeriddetailss"].ToString();
            }
            if (hid_pan.Value != "")
            {
                iframecost.Attributes["src"] = "MasterCustomerKYC.aspx";
                popupfro.Visible = true;
                PopupBL.Show();
                Session["txtpanno"] = txtPanNo.Text;
                Session["txtpancustomer"] = txtpancust.Text;
                Session["txtcustomerid"] = hf_customerid.Value;
                Session["customerCountryid"] = hf_countryid.Value;
                Session["hf_employeeided"] = hf_employeeid.Value;
                Session["Hidpanno"] = hid_pan.Value;
                Session["hidpaninput"] = hidpaninput.Value;
            }
            else
            {
                iframecost.Attributes["src"] = "MasterCustomerKYC.aspx";
                popupfro.Visible = true;
                PopupBL.Show();
                Session["txtpanno"] = txtPanNo.Text;
                Session["txtpancustomer"] = txtpancust.Text;
                Session["txtcustomerid"] = hf_customerid.Value;
                Session["customerCountryid"] = hf_countryid.Value;
                Session["hf_employeeided"] = hf_employeeid.Value;
                Session["Hidpanno"] = hid_pan.Value;
                Session["hidpaninput"] = hidpaninput.Value;
            }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Enter the Valid Customer Name');", true);
            //    txtpancust.Focus();
            //    return;
            //}
        }

        protected void btn_bank_Click(object sender, EventArgs e)
        {
            if (hidpaninput.Value == "Y")
            {
                txtPanNo.Text = hid_panno.Value;
            }
            txtPanNo.Text = hid_panno.Value;
            if (grd.Rows.Count > 0)
            {
                int i = 0;
                for (i = 0; i < grd.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        int index = 0;
                        string city = grd.Rows[index].Cells[3].Text; //   grd.SelectedRow.Cells[4].Text;
                        //string country = grd.Columns[0].ToString();
                        hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(city.ToUpper()));
                        txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                        hf_customerid.Value = grd.Rows[index].Cells[4].Text;

                        Session["customeriddetailss"] = hf_customerid.Value;

                    }
                }
            }
            if (!string.IsNullOrEmpty(Session["customeriddetailss"].ToString()))
            {
                hf_customerid.Value = Session["customeriddetailss"].ToString();
            }
            if (hid_pan.Value != "")
            {
                iframecost.Attributes["src"] = "MasterCustomerBank.aspx";
                popupfro.Visible = true;
                PopupBL.Show();
                Session["txtpanno"] = txtPanNo.Text;
                Session["txtpancustomer"] = txtpancust.Text;
                Session["txtcustomerid"] = hf_customerid.Value;
                Session["customerCountryid"] = hf_countryid.Value;
                Session["hf_employeeided"] = hf_employeeid.Value;
                Session["hidpaninput"] = hidpaninput.Value;
            }
            else
            {
                iframecost.Attributes["src"] = "MasterCustomerBank.aspx";
                popupfro.Visible = true;
                PopupBL.Show();
                Session["txtpanno"] = txtPanNo.Text;
                Session["txtpancustomer"] = txtpancust.Text;
                Session["txtcustomerid"] = hf_customerid.Value;
                Session["customerCountryid"] = hf_countryid.Value;
                Session["hf_employeeided"] = hf_employeeid.Value;
                Session["hidpaninput"] = hidpaninput.Value;
            }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Enter the Valid Customer Name');", true);
            //    txtpancust.Focus();
            //    return;
            //}
        }

        protected void btn_contact_Click(object sender, EventArgs e)
        {
            if (hidpaninput.Value == "Y")
            {
                txtPanNo.Text = hid_panno.Value;
            }
            txtPanNo.Text = hid_panno.Value;
            if (grd.Rows.Count > 0)
            {
                int i = 0;
                for (i = 0; i < grd.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        int index = 0;
                        string city = grd.Rows[index].Cells[3].Text; //   grd.SelectedRow.Cells[4].Text;
                        //string country = grd.Columns[0].ToString();
                        hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(city.ToUpper()));
                        txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                        hf_customerid.Value = grd.Rows[index].Cells[4].Text;

                        Session["customeriddetailss"] = hf_customerid.Value;

                    }
                }
            }

            if (!string.IsNullOrEmpty(Session["customeriddetailss"].ToString()))
            {
                hf_customerid.Value = Session["customeriddetailss"].ToString();
            }
            if (hf_customerid.Value != "" && hf_customerid.Value != "0")
            {
                if (hid_pan.Value != "")
                {
                    iframecost.Attributes["src"] = "MasterCustomerContact.aspx";
                    popupfro.Visible = true;
                    PopupBL.Show();
                    Session["txtpanno"] = txtPanNo.Text;
                    Session["txtpancustomer"] = txtpancust.Text;
                    Session["txtcustomerid"] = hf_customerid.Value;
                    Session["customerCountryid"] = hf_countryid.Value;
                    Session["hf_employeeided"] = hf_employeeid.Value;
                    Session["hidpaninput"] = hidpaninput.Value;
                }
                else
                {
                    iframecost.Attributes["src"] = "MasterCustomerContact.aspx";
                    popupfro.Visible = true;
                    PopupBL.Show();
                    Session["txtpanno"] = txtPanNo.Text;
                    Session["txtpancustomer"] = txtpancust.Text;
                    Session["txtcustomerid"] = hf_customerid.Value;
                    Session["customerCountryid"] = hf_countryid.Value;
                    Session["hf_employeeided"] = hf_employeeid.Value;
                    Session["hidpaninput"] = hidpaninput.Value;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Enter the Valid Customer Name');", true);
                txtpancust.Focus();
                return;
            }
        }

        protected void btn_mastercustomerdetails_Click(object sender, EventArgs e)
        {

            Session["customeriddetailss"] = hf_customerid.Value;

            iframecost.Attributes["src"] = "MasterCustomerDetails.aspx";
            popupfro.Visible = true;
            PopupBL.Show();
            txtPanNo.Text = hid_panno.Value;
            Session["pannono"] = txtPanNo.Text;
            Session["hiddenpanid"] = hid_pan.Value;
            Session["mastercustomerid"] = hf_customerid.Value;
            Session["mastercustomername"] = txtpancust.Text;
            Session["mastercustomernames"] = customernamehide.Value;
            Session["hidpaninput"] = hidpaninput.Value;
            Session["hidensalespersonid"] = hf_employeeid.Value;
            Session["hiddensalespersonname"] = txt_Salesperson.Text;
            Session["catagory"] = ddlcategory.SelectedValue;


        }

        protected void btncancelnew_Click(object sender, EventArgs e)
        {
            DataTable grid = obj_MasterCustomer.getcustgridwithcustomeragent(Convert.ToInt16(hf_customerid.Value), txtPanNo.Text.ToString());
            if (grid.Rows.Count > 0)
            {
                grd.DataSource = grid;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = new DataTable();
                grd.DataBind();
            }
        }

        protected void imgcroks_Click(object sender, EventArgs e)
        {

            if (grd.Rows.Count > 0)
            {
                int i = 0;
                for (i = 0; i < grd.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        int index = 0;
                        string city = grd.Rows[index].Cells[3].Text; //   grd.SelectedRow.Cells[4].Text;
                        //string country = grd.Columns[0].ToString();
                        hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(city.ToUpper()));
                        txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                        hf_customerid.Value = grd.Rows[index].Cells[4].Text;

                        Session["customeriddetailss"] = hf_customerid.Value;
                    }
                }
            }
            if (!string.IsNullOrEmpty(Session["customeriddetailss"].ToString()))
            {
                hf_customerid.Value = Session["customeriddetailss"].ToString();
            }
            if (txtpancust.Text != "")
            {
                if (hf_customerid.Value == "")
                {
                    hf_customerid.Value = "0";
                }
                DataTable grid = obj_MasterCustomer.getcustgridwithcustomeragent(Convert.ToInt16(hf_customerid.Value), txtPanNo.Text.ToString());
                if (grid.Rows.Count > 0)
                {
                    grd.DataSource = grid;
                    grd.DataBind();


                }
                else
                {
                    grd.DataSource = new DataTable();
                    grd.DataBind();
                }
            }
        }

        protected void btn_portalcred_Click(object sender, EventArgs e)
        {
            if (hf_customerid.Value != "" && hf_customerid.Value != "0")
            {
                if (hid_pan.Value != "")
                {
                    iframe1.Attributes["src"] = "CustPortalCredentials.aspx?panid=" + hid_pan.Value;
                    Panel2.Visible = true;
                    Modalpopupextender1.Show();
                    Session["txtpanno"] = txtPanNo.Text;
                    Session["txtpancustomer"] = txtpancust.Text;
                    Session["txtcustomerid"] = hf_customerid.Value;
                    Session["customerCountryid"] = hf_countryid.Value;
                    Session["hf_employeeided"] = hf_employeeid.Value;
                    Session["hidpaninput"] = hidpaninput.Value;
                    Session["hid_pan.Value"] = hid_pan.Value;
                }
                else
                {
                    iframe1.Attributes["src"] = "CustPortalCredentials.aspx?panid=" + hid_pan.Value;
                    Panel2.Visible = true;
                    Modalpopupextender1.Show();
                    Session["txtpanno"] = txtPanNo.Text;
                    Session["txtpancustomer"] = txtpancust.Text;
                    Session["txtcustomerid"] = hf_customerid.Value;
                    Session["customerCountryid"] = hf_countryid.Value;
                    Session["hf_employeeided"] = hf_employeeid.Value;
                    Session["hidpaninput"] = hidpaninput.Value;
                    Session["hid_pan.Value"] = hid_pan.Value;
                }

               
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Enter the Valid Customer Name');", true);
                txtpancust.Focus();
                return;
            }
        }
        protected void btntask_Click(object sender, EventArgs e)
        {
            if (hf_customerid.Value != "" && hf_customerid.Value != "0")
            {
                iframecost.Attributes["src"] = "MasterTask.aspx";
                popupfro.Visible = true;
                PopupBL.Show();
                Session["txtcustomerid"] = hf_customerid.Value;
                Session["pancustomer"] = txtpancust.Text;
                Session["hiddenpanid"] = hid_pan.Value;
                Session["grd_SelectedIndex"] = index;
                Session["grd_Selectedgst"] = hid_gst.Value;
                Session["hiddenpanid1"] = txtPanNo.Text;
                //Session["DataTable"];

            }
            else
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Enter the Valid Customer Name');", true);
                txtpancust.Focus();
                return;
            }
        }
    }
}