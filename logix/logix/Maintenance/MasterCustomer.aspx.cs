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

using System.Text.RegularExpressions;
using System.Text;
using System.Net;


namespace logix.Maintenance
{

    public partial class MasterCustomer : System.Web.UI.Page
    {
        double tds;
        int custid;
        protected System.Web.UI.WebControls.CheckBoxList chkType;
        DataTable dt = new DataTable();
        DataAccess.Masters.MasterBranch mbranch = new DataAccess.Masters.MasterBranch();

        DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterLocation location = new DataAccess.Masters.MasterLocation();
        DataAccess.Masters.MasterPort port = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCountry countryobj = new DataAccess.Masters.MasterCountry();
        DataAccess.Masters.REqMasterCustomer cusobj = new DataAccess.Masters.REqMasterCustomer();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.FAMaster.MasterSubGroup sobj = new DataAccess.FAMaster.MasterSubGroup();
        DataAccess.Masters.MasterEmployee objmasemp = new DataAccess.Masters.MasterEmployee();
        DataAccess.FAMaster.MasterLedger ledgerobj = new DataAccess.FAMaster.MasterLedger();
        DataTable dtCus = new DataTable();
        DataTable dts = new DataTable();
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
        int int_fax;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        string unregistered = "";
        string RCM = "";
        string SEZ = "";
        string SEZIgst = "";
        string Register = "";
        string gstexemp = "";
        char type, status;
        string std;
        Boolean blerr;
        DataTable dt1 = new DataTable();
        DataTable obj_dt = new DataTable();
        int filesize;
        byte[] postfile1 = null;

        byte[] postfile2 = null;
        byte[] postfile3 = null;
        byte[] postfile4 = null;
        byte[] postfile5 = null;
        DataTable obj_dttemp = new DataTable();
        DataAccess.Masters.MasterTDSType obj_da_TDS = new DataAccess.Masters.MasterTDSType();
        bool blnerr = false;

        public String GSTINFORMAT_REGEX = "[0-9]{2}[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9A-Za-z]{1}[Z]{1}[0-9a-zA-Z]{1}";
        public String GSTN_CODEPOINT_CHARS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string status1 = "";

        int id, add, iec, k = 1, gid, ddlid, ddlid1;
        string idfilename, addfilename, iecfilename, idfilepath, ieccode, addfilepath, a, b, c, d, e, gstfilename;

        string livehold;



        string username = "";
        string password = "";


        string ip = "";
        string dbname = "";

        protected string DBCS;
     



        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnview);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnBack);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnkyc);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(GrdProof);
            //  ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnSave);
            grd.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            if (!IsPostBack)
            {
                try
                {
                    // Ctrl_List = txtcustomer.ID + "~" + ddlCType.ID + "~" + txtunit.ID + "~" + txtbuildingname.ID + "~" + txtdoor.ID + "~" + txtstreet.ID + "~" + txtcity.ID + "~" + txtlocation.ID + "~" + ddllocation.ID + "~" + txtdistrict.ID + "~" + txtstate.ID + "~" + txtcountry.ID + "~" + txtpincode.ID + "~" + txtllisd.ID + "~" + txtllstd.ID + "~" + txtlandline.ID + "~" + txtfaxisd.ID + "~" + txtfaxstd.ID + "~" + txtfax.ID + "~" + txtmblisd.ID + "~" + txtMobile.ID + "~" + txtemail.ID + "~" + txtPanNo.ID + "~" + txtServiceTaxNo.ID + "~" + txtmanagptc.ID + "~" + txtmailmanag.ID + "~" + txtcomptc.ID + "~" + txtmailcom.ID + "~" + txtexpptc.ID + "~" + txtmailexport.ID + "~" + txtimpptc.ID + "~" + txtmailimp.ID + "~" + txtfinptc.ID + "~" + txtmailfin.ID + "~" + txttds.ID;
                    //Msg_List = "CUSTOMER~CUSTOMER TYPE~DOOR NO~STREET NO~CITY NAME~LOCATION NAME~LOCATION ID~DISTRIT NAME~STATE NAME~COUNTRY NAME~PINCODE";
                    //Dtype_List = "string~ddl~string~string~string~string~ddl~string~string~string~string";
                    // btnSave.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    // Utility.Fn_CheckUserRights(str_Uiid, btnSave, null, null);
                    //    Utility.Fn_CheckUserRights(str_Uiid, btnSave, null, null);

                    //btnSave.Enabled = false;
                    // btnDelete.Enabled = false;
                    if (Convert.ToInt32(Session["LoginEmpId"]) !=null )
                    {
                        chkleger.Visible = true;
                        txtsubgroupname.Visible = true;
                    }
                    lstlocation.Visible = false;
                    txtllstd.Enabled = true;
                    btndelete.Enabled = false;
                    btndelete.ForeColor = System.Drawing.Color.Gray;
                    //  LoadDDL();
                    grd.Visible = false;
                    txtcustomer.Focus();
                    ddlCType.Enabled = true;
                    custds();
                    cmbpanreq.Items.Clear();
                    cmbpanreq.Items.Add("");
                    cmbpanreq.Items.Add("YES");
                    cmbpanreq.Items.Add("NO");
                    ddlCustomerTypefill();
                    //string blockcustomer = obj_MasterCustomer.SP_Getrights4Blockcustomer(Convert.ToInt32(Session["LoginEmpId"]));
                    //if (blockcustomer.ToString() == "Y")
                    //{
                    //    btn_Block_customer.Visible = true;
                    //}
                    //else
                    //{
                    //    btn_Block_customer.Visible = false;
                    //}
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

        [WebMethod]
        public static List<string> GetLocation(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
            DataAccess.Masters.MasterCustomerProspective obj_MasterCustomer = new DataAccess.Masters.MasterCustomerProspective();
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

        [WebMethod]
        public static List<string> GetSubgroupname(string prefix)
        {
            DataAccess.FAMaster.MasterSubGroup subobj = new DataAccess.FAMaster.MasterSubGroup();
            DataTable obj_Dt = new DataTable();
            List<string> LedgerList = new List<string>();
            obj_Dt = subobj.GetLikesubGroupname(prefix.ToUpper(), HttpContext.Current.Session["FADbname"].ToString());
            LedgerList = Utility.Fn_DatatableToList_stringnew(obj_Dt, "subgroupname", "subgroupid");
            return LedgerList;
        }


        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();
            // dt = obj_MasterCustomer.GetCustomerName(prefix);GetLikeCustomerAll
            dt = obj_MasterCustomer.GetLikeCustomerAll(prefix.ToUpper());
            //  list_result = Utility.Fn_TableToList(dt, "customername", "customerid");
            list_result = Utility.Fn_TableToList_Cust1(dt, "customer", "customerid", "address");
            return list_result;

        }
        [WebMethod]
        public static List<string> GetPortName(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
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
            dt_ok = objp_location.GetlocationnameNEWpincode(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList_Text(dt_ok, "pinCode");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetEmployeename(string prefix)
        {
            List<string> gname = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
            obj_dt = da_obj_employeeobj.GetLikeEmployee(prefix.ToUpper());
            gname = Utility.Fn_DatatableToList_int16(obj_dt, "empnamecode", "employeeid");
            return gname;
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
            txtcustomer.Text = "";
            txt_Salesperson.ReadOnly = false;
            txt_Salesperson.Text = "";
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
            hf_customerid.Value = "";
            txtPanNo.Text = "";
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
            hf_countryid.Value = "";
            hf_customerid.Value = "";
            hf_email.Value = "";
            hfWasConfirmed.Value = "";
            txt_gstin.Text = "";
            txt_uinno.Text = "";
            // btnSave.Text = "Save";
            ddl_Option.SelectedValue = "0";
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
            hid_int_custid.Value = "0";
            chkleger.Enabled = true;
            chkleger.Checked = false;
            txtsubgroupname.Enabled = true;
            txtsubgroupname.Text = "";
            hid_SubGroupid.Value = "0";
            txtgroupname.Text = "";
            txtsubgroupname.Enabled = true;
            DropLiveHold.SelectedIndex = 0;

        }

        private void clear12()
        {
            cmbpanreq.SelectedIndex = 0;
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
                grd.DataSource = null;
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
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
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
                DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
                dt = objp_location.CheckDuplicateForLocationPincode(ddllocation.SelectedValue, txtpincode.Text);
                hf_locationid.Value = "0";
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
                        // btnBack.Text = "Cancel";

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
            if (txtcustomer.Text == "COUNTTRY")
            {
                if (txtcustomer.Text == "CUSTOMER NAME")
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Should Not Be Empty');", true);
                    txtcustomer.Focus();
                    blerr = true;
                    return;

                }
                else if (ddlCType.SelectedValue == "CUSTOMER TYPE")
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Select Customer Type');", true);
                    ddlCType.Focus();
                    blerr = true;
                    return;

                }
                else if (txtdoor.Text == "DOOR #")
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter The Door No');", true);
                    txtdoor.Focus();
                    blerr = true;
                    return;

                }
                else if (txtstreet.Text == "STREET")
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter The Street');", true);
                    txtstreet.Focus();
                    blerr = true;
                    return;

                }

                else if (txtcity.Text == "CITY")
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Select City');", true);
                    txtcity.Focus();
                    blerr = true;
                    return;

                }
                if (hf_countryid.Value == "1102" || hf_countryid.Value == "102")
                {
                    if (txtpincode.Text == "PINCODE/ZIP")
                    {

                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter The PinCode');", true);
                        txtpincode.Focus();
                        blerr = true;
                        return;

                    }
                    else if (txtpincode.Text == "")
                    {

                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter The PinCode');", true);
                        txtpincode.Focus();
                        blerr = true;
                        return;

                    }
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



                else if (ddlCType.SelectedValue == "0")
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert(' Select Customer Type');", true);
                    ddlCType.Focus();
                    blerr = true;
                    return;

                }
                else if (txtdoor.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter The Door#');", true);
                    txtdoor.Focus();
                    blerr = true;
                    return;

                }

                else if (txtstreet.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter The Street');", true);
                    txtstreet.Focus();
                    blerr = true;
                    return;

                }

                else if (txtcity.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Select City');", true);
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
                //if (txtlocation.Visible == true)
                //{
                //    if (txtlocation.Text == "LOCATION")
                //    {

                //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Select Location');", true);
                //        txtlocation.Focus();
                //        blerr = true;
                //        return;

                //    }

                //}

                //if (ddllocation.Visible == true)
                //{
                //    if (ddllocation.SelectedValue == "0")
                //    {

                //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Select Location');", true);
                //        txtlocation.Focus();
                //        blerr = true;
                //        return;

                //    }

                //}

                //else if (txtlandline.Text == "LANDLINE")
                //{

                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Enter landline');", true);
                //    txtlandline.Focus();
                //    blerr = true;
                //    return;

                //}


                //else if (txtMobile.Text == "MOBILE")
                //{

                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Pleast Enter Mobile');", true);
                //    txtMobile.Focus();
                //    blerr = true;
                //    return;

                //}
                if (hf_countryid.Value == "1102" || hf_countryid.Value == "102")
                {
                    if (txtpincode.Text == "PINCODE/ZIP")
                    {

                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter The PinCode');", true);
                        txtpincode.Focus();
                        blerr = true;
                        return;

                    }

                    else if (txtpincode.Text == "")
                    {

                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter The PinCode');", true);
                        txtpincode.Focus();
                        blerr = true;
                        return;

                    }
                }


            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string value = "";
            string eventdocs = "";
            string eventdocs1 = "";
            DataTable dtCheck = new DataTable();
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
            Session["dt1"] = null;
            Session["dt"] = null;
            Session["dt2"] = null;
            Session["dt3"] = null;
            Session["dt4"] = null;
            CheckDatd();
            if (blerr == true)
            {
                blerr = false;
                return;
            }
            try
            {
                if (hf_employeeid.Value == "")
                {
                    hf_employeeid.Value = "0";
                }

                if (txt_Salesperson.Text != "")
                {
                    int employid = objmasemp.GetNEmpid(txt_Salesperson.Text.ToUpper());
                    hf_employeeid.Value = employid.ToString();
                }
                if (hf_customerid.Value == "")
                {
                    custid = 0;
                    hf_customerid.Value = "0";
                }
                if (hid_int_custid.Value == "")
                {
                  hid_int_custid.Value = "0";
                }
                if (hf_locationid.Value == "")
                {
                    int_location = 0;
                }
                else
                {
                    int_location = Convert.ToInt32(hf_locationid.Value);
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
                if (txttds.Text != "")
                {
                    tds = Convert.ToInt32(txttds.Text.Trim());
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
                string Type1;
                if (ddlCType.SelectedItem.Text == "Agent / Principal / Counter Part")
                {
                    Type1 = "P";
                }
                else if (ddlCType.SelectedItem.Text == "Depo")
                {
                    Type1 = "W";
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
                //if (ddl_Option.SelectedItem.Text == "SEZ Exemption")
                //{
                //    SEZIgst = "Y";
                //}
                //else
                //{
                //    SEZIgst = "N";
                //}
                if (ddl_Option.SelectedItem.Text == "Register")
                {
                    Register = "Y";
                }
                else
                {
                    Register = "N";
                }
                //if (ddl_Option.SelectedItem.Text == "SEZ")
                //{
                //    SEZ = "Y";
                //}
                //else
                //{
                //    SEZ = "N";
                //}
                if (ddl_Option.SelectedItem.Text == "SEZ")
                {
                    SEZIgst = "Y";
                }
                else
                {
                    SEZIgst = "N";
                }
                txtcustomer.Text = txtcustomer.Text.ToUpper().Replace(" ,", ", ").Replace("  ,", ", ");

                if (txt_gstin.Text != "" || txt_uinno.Text != "")
                {
                    //unregistered = "N";
                    if (unregistered == "Y")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter only One Uin# (OR) GSTIN# (OR)Select UnRegistered');", true);
                        ddl_Option.SelectedValue = "0";
                        return;
                    }
                }


                //string porid="";
                //string bgstno;
                //DataTable dtbgstno = new DataTable();
                //if (Session["portid"]!=null)
                //{
                //    porid = Session["portid"].ToString();

                //}
                //if (ddlCType.SelectedValue == "C")
                //{
                //    if (txtcity.Text != "")
                //    {

                //        dtbgstno = mbranch.getmasterbranchgstin(Convert.ToInt32(porid));
                //        if(dtbgstno.Rows.Count>0)
                //        {
                //            bgstno = dtbgstno.Rows[0]["gstin"].ToString();

                //            if(bgstno==txt_gstin.Text)
                //            {
                //                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Branch GSTIN # and Given GSTIN # are same .so please enter Different GSTIN #');", true);
                //                //return;
                //            }
                //        }
                //    }
                //}







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
                   // if (txt_gstin.Text == "" && txt_uinno.Text == "" && ddl_Option.SelectedItem.Text != "UnRegistered")
                    if (txt_gstin.Text == "" && txt_uinno.Text == "" && ddl_Option.SelectedItem.Text != "UnRegistered")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter  GSTIN# (OR)Select UnRegistered');", true);
                        return;
                    }
                    //else if (txt_uinno.Text == "" && ddl_Option.SelectedItem.Text != "UnRegistered")
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter  Uin# (OR)Select UnRegistered');", true);
                    //    return;
                    //}
                }
                if (ddl_description.SelectedItem.Text != "" && ddl_description.SelectedItem.Text != "Description")  //&& ddl_slab.SelectedItem.Text != "" && ddl_slab.SelectedItem.Text != "Slab" && ddl_type.SelectedItem.Text != "" && ddl_type.SelectedItem.Text != "Type" && ddl_percentage.SelectedItem.Text != "" && ddl_percentage.SelectedItem.Text != "Percentage")
                {
                    if (ddl_type.SelectedItem.Text != "" && ddl_type.SelectedItem.Text != "Type")
                    {

                        if (ddl_slab.SelectedItem.Text != "" && ddl_slab.SelectedItem.Text != "Slab")
                        {


                            if (ddl_percentage.SelectedItem.Text != "" && ddl_percentage.SelectedItem.Text != "Percentage")
                            {


                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Select Percentage');", true);
                                return;
                            }
                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Select Slab');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Select the Type')", true);
                        return;
                    }
                }



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


                if (txt_empfrom.Text == "")
                {
                    //txt_empfrom.Text = obj_da_Log.GetDate().ToShortDateString();
                    //txt_empfrom.Text = Utility.fn_ConvertDate(txt_empfrom.Text);

                    //ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly select the  Exemption period From Date');", true);
                    //txt_empfrom.Focus();                   
                    //return;
                }

                if (txt_empto.Text == "")
                {

                    //txt_empto.Text = obj_da_Log.GetDate().ToShortDateString();
                    //txt_empto.Text = Utility.fn_ConvertDate(txt_empto.Text);
                    //ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly select the  Exemption period To Date');", true);
                    //txt_empto.Focus();
                    //return;
                }

                if (txt_tds_exp.Text == "")
                {

                    txt_tds_exp.Text = "0";
                    //ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the TDS Emptions');", true);
                    //txt_tds_exp.Focus();
                    //return;
                }

                if (txt_limit.Text == "")
                {
                    txt_limit.Text = "0.00";

                    //ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the Amount limit);", true);
                    //txt_limit.Focus();
                    //return;
                }
                if (txt_certno.Text == "")
                {
                    txt_certno.Text = "0";

                    //ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the certificate # );", true);
                    //txt_certno.Focus();
                    //return;
                }

                if (chkleger.Enabled == true)
                {
                    if (chkleger.Checked == true)
                    {
                        if (txtsubgroupname.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter Subgroupname..');", true);
                            txtsubgroupname.Focus();
                            return;
                        }
                        else
                        {
                            if (hid_SubGroupid.Value == "" || hid_SubGroupid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Invalid Subgroupname..');", true);
                                txtsubgroupname.Focus();
                                return;
                            }
                        }
                    }
                }


                if (DropLiveHold.SelectedItem.Text == "Hold")
                {
                    // livehold = DropLiveHold.SelectedItem.Text;

                    livehold = "H";

                }
                else
                {
                    livehold = "L";
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




                                if (ddl_Option.SelectedItem.Text == "Register")
                                {

                                    if (txtlandline.Text == "")
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter Landline');", true);
                                        txtlandline.Focus();
                                        return;
                                    }
                                    if (txtemail.Text == "")
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter EMAIL');", true);
                                        txtemail.Focus();
                                        return;
                                    }


                                    if (txtmanagptc.Text == "")
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter MANAGEMENT HEAD NAME');", true);
                                        txtmanagptc.Focus();
                                        return;
                                    }
                                    if (txtmailmanag.Text == "")
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter MANAGEMENT HEAD MAIL ID');", true);
                                        txtmailmanag.Focus();
                                        return;
                                    }
                                    if (txtcomptc.Text == "")
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter COMMERCIAL HEAD NAME');", true);
                                        txtcomptc.Focus();
                                        return;
                                    }
                                    if (txtmailcom.Text == "")
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter COMMERCIAL HEAD MAIL ID');", true);
                                        txtmailcom.Focus();
                                        return;
                                    }
                                    if (txtexpptc.Text == "")
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter EXPORT HEAD NAME');", true);
                                        txtexpptc.Focus();
                                        return;
                                    }
                                    if (txtmailexport.Text == "")
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter EXPORT HEAD MAIL ID');", true);
                                        txtmailexport.Focus();
                                        return;
                                    }
                                    if (txtimpptc.Text == "")
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter IMPORT HEAD NAME');", true);
                                        txtimpptc.Focus();
                                        return;
                                    }
                                    if (txtmailimp.Text == "")
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter IMPORT HEAD MAIL ID');", true);
                                        txtmailimp.Focus();
                                        return;
                                    }
                                    if (txtfinptc.Text == "")
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter FINANCIAL HEAD NAME');", true);
                                        txtfinptc.Focus();
                                        return;
                                    }
                                    if (txtmailfin.Text == "")
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter FINANCIAL HEAD MAIL ID');", true);
                                        txtmailfin.Focus();
                                        return;
                                    }
                                    //if (txt_uinno.Text == "")
                                    //{
                                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter UINNO');", true);
                                    //    txt_uinno.Focus();
                                    //    return;
                                    //}
                                }

                                // LIVE/HOLD


                                if (DropLiveHold.SelectedItem.Text == "Hold")
                                {
                                    // livehold = DropLiveHold.SelectedItem.Text;

                                    livehold = "H";

                                }
                                else
                                {
                                    livehold = "L";
                                }


                             


                                //if (txt_Salesperson.Text == "")
                                //{
                                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter Sales Person');", true);
                                //    txt_Salesperson.Focus();
                                //    return;
                                //}

                                //obj_MasterCustomer.SPInsMasterCustomerNew(txtcustomer.Text.ToUpper().Trim(), Type1, txtunit.Text, txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                                //int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                                //faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text.ToUpper(), txtPanNo.Text, txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                                //txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), txtfinptc.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register);
                                //cusobj.UpdTransinReqCus(custid);

                                /*    obj_MasterCustomer.SPInsMasterCustomerNewimage(txtcustomer.Text.ToUpper().Trim(), Type1, txtunit.Text, txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                                   int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                                   faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text.ToUpper(), txtPanNo.Text, txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                                   txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), txtfinptc.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4);
                                    */


                               /* obj_MasterCustomer.SPInsMasterCustomerNewimagenew(txtcustomer.Text.ToUpper().Trim(), Type1, txtunit.Text, txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                               int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                               faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text.ToUpper(), txtPanNo.Text, txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                               txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), txtfinptc.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4, Convert.ToInt32(hf_employeeid.Value));
                                */


                            /*    obj_MasterCustomer.SPInsMasterCustomerNewimagenewnew(txtcustomer.Text.ToUpper().Trim(), Type1, txtunit.Text, txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                               int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                               faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text.ToUpper(), txtPanNo.Text, txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                               txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), txtfinptc.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4, Convert.ToInt32(hf_employeeid.Value), Convert.ToDouble(txt_limit.Text), txt_empfrom.Text, txt_empto.Text, txt_certno.Text, Convert.ToDouble(txt_tds_exp.Text), SEZIgst);

                                */

                                //SATHYA



                                obj_MasterCustomer.SPInsMasterCustomerNewimagenewnew_onelh(txtcustomer.Text.ToUpper().Trim(), Type1, txtunit.Text, txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                               int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                               faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text.ToUpper(), txtPanNo.Text, txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                               txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds),
                               txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), txtfinptc.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4, Convert.ToInt32(hf_employeeid.Value),
                               Convert.ToDouble(txt_limit.Text), txt_empfrom.Text, txt_empto.Text, txt_certno.Text, Convert.ToDouble(txt_tds_exp.Text), SEZIgst,livehold);

                                hf_customerid.Value = obj_MasterCustomer.GetCustomeridnew(txtcustomer.Text.ToUpper().Trim(), txtpincode.Text, txtstreet.Text.ToUpper(), int_port.ToString()).ToString();


                                savetds();
                                //if (hid_int_custid.Value != "0" && hid_int_custid.Value != "") -- hide on 23Mar2022
                                if (hid_int_custid.Value != "0" && hid_int_custid.Value != "" && hf_customerid.Value != "0" && hf_customerid.Value != "")
                                {
                                    obj_MasterCustomer.updcustomertranfer(Convert.ToInt32(hid_int_custid.Value));
                                    savekyc();
                                }
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 1, int.Parse(Session["LoginBranchid"].ToString()), "CName" + txtcustomer.Text + " Cust:" + Convert.ToInt32(hid_int_custid.Value) + "Gst Type:" + ddl_Option.SelectedItem.Text + "GST TYPE :" + ddl_Option.SelectedItem.Text + "/Sav");
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Inserted Successfully');", true);
                                //dtCus = cusobj.getREQMasterCustomer();
                                //grd.DataSource = dtCus;
                                //grd.DataBind();

                                if (chkleger.Enabled == true)
                                {
                                    if (chkleger.Checked == true)
                                    {

                                        string FaDbName;
                                        int ledgerid;
                                        //    string acctype = "";
                                        // DataTable dtl1 = new DataTable();
                                        // char lt;                       

                                        //lt = Convert.ToChar(acctype);                       
                                        FaDbName = HttpContext.Current.Session["FADbname"].ToString();
                                        if (hid_GroupID.Value == "" || hid_GroupID.Value == "0")
                                        {
                                            hid_GroupID.Value = "18";
                                        }
                                        //if (hidgrptype.Value == "" || hidgrptype.Value=="0")
                                        //{
                                        //    hidgrptype.Value ="G";
                                        //}
                                        //ledgerid = ledgerobj.InsLedgerHead(txtcustomer.Text.ToUpper(), 87, 18, 'G', FaDbName);

                                        ledgerid = ledgerobj.InsLedgerHead(txtcustomer.Text.ToUpper(), Convert.ToInt32(hid_SubGroupid.Value), Convert.ToInt32(hid_GroupID.Value), 'G', FaDbName);
                                        ledgerobj.UpdLedgerid(FaDbName, Convert.ToInt32(Session["LoginBranchid"]), ledgerid, Convert.ToInt32(hf_customerid.Value), 'C');
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 2, int.Parse(Session["LoginBranchid"].ToString()), "LdegerName" + txtcustomer.Text + "ledgerid" + ledgerid + "/Saved");
                                    }
                                }
                                clear();
                                Fn_Clear();

                                //obj_MasterCustomer.InsMasterCustomer(txtcustomer.Text.ToUpper(), "C", txtunit.Text, txtbuildingname.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country,
                                //    txtpincode.Text, llisd, txtllstd.Text, Convert.ToInt32(landline), mblisd, txtMobile.Text, faxisd, txtfaxstd.Text, int_fax, txtemail.Text, txtPanNo.Text, txtServiceTaxNo.Text, txtmailcom.Text, txtmailexport.Text, txtmailimp.Text, txtmailfin.Text, txtcomptc.Text,
                                //    txtexpptc.Text, txtimpptc.Text, txtfinptc.Text, Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text, txtmanagptc.Text, tds);
                                //location.UpdCityportInLocation(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_locationid.Value));
                                //obj_MasterCustomer.UpdPortFromCustomer(Convert.ToInt32(hf_districtid.Value), Convert.ToInt32(hf_stateid.Value), std, Convert.ToInt32(hf_portid.Value));
                                //obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 1, int.Parse(Session["LoginBranchid"].ToString()), "CName" + txtcustomer.Text + "/Sav");
                                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Inserted Successfully');", true);
                                //clear();


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
                                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Voucher Raised For this customer So you Cannot change State ');", true);
                                                return;
                                            }
                                        }
                                    }

                                    /*  String gstin = txt_gstin.Text.ToUpper().Trim();

                                      if (validGSTIN(gstin.ToUpper().Trim()))
                                      {
                                          ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + "Valid GSTIN!" + "');", true);
                                      }
                                      else
                                      {
                                          ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + "Invalid GSTIN" + "');", true);
                                          txt_gstin.Text = "";
                                          txt_gstin.Focus();
                                          return;
                                      } */


                                    if (hf_customerid.Value != "")
                                    {

                                        /* obj_MasterCustomer.SPUpdMasterCustomerNewDesignimage(txtcustomer.Text.ToUpper(), Type1, txtunit.Text.ToUpper(), txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                                         int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                                         faxisd, txtfaxstd.Text.ToUpper(), txtfax.Text.ToUpper(), txtemail.Text.ToUpper(), txtPanNo.Text.ToUpper(), txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                                         txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(hf_customerid.Value), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txtfinptc.Text.ToUpper(), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4);
                                         */

                                        /*obj_MasterCustomer.SPUpdMasterCustomerNewDesignimagenew(txtcustomer.Text.ToUpper(), Type1, txtunit.Text.ToUpper(), txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                                        int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                                        faxisd, txtfaxstd.Text.ToUpper(), txtfax.Text.ToUpper(), txtemail.Text.ToUpper(), txtPanNo.Text.ToUpper(), txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                                        txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(hf_customerid.Value), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txtfinptc.Text.ToUpper(), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4, Convert.ToInt32(hf_employeeid.Value));
                                        */


                                        obj_MasterCustomer.SPUpdMasterCustomerNewDesignimagenewnew_updlp(txtcustomer.Text.ToUpper(), Type1, txtunit.Text.ToUpper(), txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                                  int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                                  faxisd, txtfaxstd.Text.ToUpper(), txtfax.Text.ToUpper(), txtemail.Text.ToUpper(), txtPanNo.Text.ToUpper(), txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                                  txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(hf_customerid.Value), txtmailmanag.Text.ToUpper(), 
                                  txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txtfinptc.Text.ToUpper(), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, 
                                  Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4, Convert.ToInt32(hf_employeeid.Value), Convert.ToDouble(txt_limit.Text), txt_empfrom.Text, txt_empto.Text, txt_certno.Text, Convert.ToDouble(txt_tds_exp.Text), SEZIgst,livehold);
                                        hf_customerid.Value = obj_MasterCustomer.GetCustomeridnew(txtcustomer.Text.ToUpper().Trim(), txtpincode.Text, txtstreet.Text.ToUpper(), int_port.ToString()).ToString();


                                        savetds();


                                        
                                        panreq();
                                        if (blerr == true)
                                        {
                                            blerr = false;
                                            return;
                                        }

                                        //obj_MasterCustomer.SPUpdMasterCustomerNewDesign(txtcustomer.Text.ToUpper(), Type1, txtunit.Text.ToUpper(), txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                                        //int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                                        //faxisd, txtfaxstd.Text.ToUpper(), txtfax.Text.ToUpper(), txtemail.Text.ToUpper(), txtPanNo.Text.ToUpper(), txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                                        //txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(hf_customerid.Value), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txtfinptc.Text.ToUpper(), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register);




                                        //obj_MasterCustomer.UpdMasterCustomerNew(txtcustomer.Text.ToUpper(), Type1, txtunit.Text, txtbuildingname.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country,
                                        //    txtpincode.Text, llisd, txtllstd.Text, Convert.ToInt32(landline), mblisd, txtMobile.Text, faxisd, txtfaxstd.Text, int_fax, txtemail.Text, txtPanNo.Text, txtServiceTaxNo.Text, txtmailcom.Text, txtmailexport.Text, txtmailimp.Text, txtmailfin.Text, txtcomptc.Text,
                                        //        txtexpptc.Text, txtimpptc.Text, txtfinptc.Text, int_customer, txtmailmanag.Text, txtmanagptc.Text, tds);
                                        //location.UpdCityportInLocation(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_locationid.Value));
                                        //obj_MasterCustomer.UpdPortFromCustomer(Convert.ToInt32(hf_districtid.Value), Convert.ToInt32(hf_stateid.Value), std, Convert.ToInt32(hf_portid.Value));
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 2, int.Parse(Session["LoginBranchid"].ToString()), "CName" + txtcustomer.Text + "CUSTID :" + Convert.ToInt32(hid_int_custid.Value) +  "Gst Type :" + ddl_Option.SelectedItem.Text + "/upd");
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Updated Successfully');", true);
                                        lstlocation.Visible = false;
                                        // btnSave.Text = "Update";
                                        btnSave.ToolTip = "Update";
                                        btnSave1.Attributes["class"] = "btn btn-update1";
                                        if (chkleger.Enabled == true)
                                        {
                                            if (chkleger.Checked == true)
                                            {

                                                string FaDbName;
                                                int ledgerid;
                                                //    string acctype = "";
                                                // DataTable dtl1 = new DataTable();
                                                // char lt;                       

                                                //lt = Convert.ToChar(acctype);                       
                                                FaDbName = HttpContext.Current.Session["FADbname"].ToString();
                                                if (hid_GroupID.Value == "" || hid_GroupID.Value == "0")
                                                {
                                                    hid_GroupID.Value = "18";
                                                }
                                                //if (hidgrptype.Value == "" || hidgrptype.Value=="0")
                                                //{
                                                //    hidgrptype.Value ="G";
                                                //}
                                                //ledgerid = ledgerobj.InsLedgerHead(txtcustomer.Text.ToUpper(), 87, 18, 'G', FaDbName);

                                                ledgerid = ledgerobj.InsLedgerHead(txtcustomer.Text.ToUpper(), Convert.ToInt32(hid_SubGroupid.Value), Convert.ToInt32(hid_GroupID.Value), 'G', FaDbName);
                                                ledgerobj.UpdLedgerid(FaDbName, Convert.ToInt32(Session["LoginBranchid"]), ledgerid, Convert.ToInt32(hf_customerid.Value), 'C');
                                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 2, int.Parse(Session["LoginBranchid"].ToString()), "LdegerName" + txtcustomer.Text + "ledgerid" + ledgerid + "/Saved");
                                            }
                                        }
                                        clear();
                                        Fn_Clear();
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
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('GSTIN # - PAN# and Customer PAN# Does Not Match');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('GSTIN # - State Code and Customer State GST Code Does Not Match');", true);
                        txt_gstin.Text = "";
                    }

                    //}
                }

                else
                {



                    if (ddlCType.SelectedValue == "C")
                    {
                        if (txtPanNo.Text == "" && ddl_Option.SelectedItem.Text != "UnRegistered")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter The Panno (OR) Select UnRegistered ');", true);
                            txtPanNo.Focus();
                            return;
                        }

                    }


                    if (btnSave.ToolTip == "Save")
                    {
                        if (ddl_Option.SelectedItem.Text == "Register")
                        {

                            if (txtlandline.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter Landline');", true);
                                txtlandline.Focus();
                                return;
                            }
                            if (txtemail.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter EMAIL');", true);
                                txtemail.Focus();
                                return;
                            }


                            if (txtmanagptc.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter MANAGEMENT HEAD NAME');", true);
                                txtmanagptc.Focus();
                                return;
                            }
                            if (txtmailmanag.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter MANAGEMENT HEAD MAIL ID');", true);
                                txtmailmanag.Focus();
                                return;
                            }
                            if (txtcomptc.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter COMMERCIAL HEAD NAME');", true);
                                txtcomptc.Focus();
                                return;
                            }
                            if (txtmailcom.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter COMMERCIAL HEAD MAIL ID');", true);
                                txtmailcom.Focus();
                                return;
                            }
                            if (txtexpptc.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter EXPORT HEAD NAME');", true);
                                txtexpptc.Focus();
                                return;
                            }
                            if (txtmailexport.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter EXPORT HEAD MAIL ID');", true);
                                txtmailexport.Focus();
                                return;
                            }
                            if (txtimpptc.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter IMPORT HEAD NAME');", true);
                                txtimpptc.Focus();
                                return;
                            }
                            if (txtmailimp.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter IMPORT HEAD MAIL ID');", true);
                                txtmailimp.Focus();
                                return;
                            }
                            if (txtfinptc.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter FINANCIAL HEAD NAME');", true);
                                txtfinptc.Focus();
                                return;
                            }
                            if (txtmailfin.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter FINANCIAL HEAD MAIL ID');", true);
                                txtmailfin.Focus();
                                return;
                            }
                        }


                        if (DropLiveHold.SelectedItem.Text == "Hold")
                        {
                            // livehold = DropLiveHold.SelectedItem.Text;

                            livehold = "H";
                           
                        }
                        else
                        {
                            livehold = "L";
                        }



                        //if (txt_Salesperson.Text == "")
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter Sales Person');", true);
                        //    return;
                        //}
                        //obj_MasterCustomer.SPInsMasterCustomerNew(txtcustomer.Text.ToUpper(), Type1, txtunit.Text, txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                        //int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                        //faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text.ToUpper(), txtPanNo.Text, txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                        //txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), txtfinptc.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register);

                        /*obj_MasterCustomer.SPInsMasterCustomerNewimage(txtcustomer.Text.ToUpper(), Type1, txtunit.Text, txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                       int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                       faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text.ToUpper(), txtPanNo.Text, txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                       txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), txtfinptc.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4);
                        */

                       /* obj_MasterCustomer.SPInsMasterCustomerNewimagenew(txtcustomer.Text.ToUpper(), Type1, txtunit.Text, txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                       int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                       faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text.ToUpper(), txtPanNo.Text, txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                       txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), txtfinptc.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4, Convert.ToInt32(hf_employeeid.Value));
                        */


                        /*obj_MasterCustomer.SPInsMasterCustomerNewimagenewnew(txtcustomer.Text.ToUpper(), Type1, txtunit.Text, txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                       int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                       faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text.ToUpper(), txtPanNo.Text, txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                       txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), txtfinptc.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4, Convert.ToInt32(hf_employeeid.Value), Convert.ToDouble(txt_limit.Text), txt_empfrom.Text, txt_empto.Text, txt_certno.Text, Convert.ToDouble(txt_tds_exp.Text), SEZIgst);

                        */
                        //SATHYA

                        obj_MasterCustomer.SPInsMasterCustomerNewimagenewnew_onelh(txtcustomer.Text.ToUpper().Trim(), Type1, txtunit.Text, txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                           int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                           faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text.ToUpper(), txtPanNo.Text, txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                           txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds),
                           txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), txtfinptc.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4, Convert.ToInt32(hf_employeeid.Value),
                           Convert.ToDouble(txt_limit.Text), txt_empfrom.Text, txt_empto.Text, txt_certno.Text, Convert.ToDouble(txt_tds_exp.Text), SEZIgst, livehold);

                        hf_customerid.Value = obj_MasterCustomer.GetCustomeridnew(txtcustomer.Text.ToUpper().Trim(), txtpincode.Text, txtstreet.Text.ToUpper(), int_port.ToString()).ToString();

                        if (custid == 0)
                        {
                            custid = Convert.ToInt32(obj_MasterCustomer.GetCustomerid(txtcustomer.Text.ToUpper()).ToString());
                           
                        }

                        cusobj.UpdTransinReqCus(custid);
                        savetds();
                         //if (hid_int_custid.Value != "0" && hid_int_custid.Value != "") -- hide on 23Mar2022
                         if (hid_int_custid.Value != "0" && hid_int_custid.Value != "" && hf_customerid.Value != "0" && hf_customerid.Value != "")
                        {
                            obj_MasterCustomer.updcustomertranfer(Convert.ToInt32(hid_int_custid.Value));
                            hf_customerid.Value = custid.ToString();
                            savekyc();
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 1, int.Parse(Session["LoginBranchid"].ToString()), "CName" + txtcustomer.Text + "/Sav" + "Gst Type :" + ddl_Option.SelectedItem.Text + "GSTIN:" + txt_gstin.Text + "PANNO:" + txtPanNo.Text + "CUSTID :" + Convert.ToInt32(hid_int_custid.Value));
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Inserted Successfully');", true);
                        //dtCus = cusobj.getREQMasterCustomer();
                        //grd.DataSource = dtCus;
                        //grd.DataBind();

                        if (chkleger.Enabled == true)
                        {
                            if (chkleger.Checked == true)
                            {

                                string FaDbName;
                                int ledgerid;
                                //    string acctype = "";
                                // DataTable dtl1 = new DataTable();
                                // char lt;                       

                                //lt = Convert.ToChar(acctype);                       
                                FaDbName = HttpContext.Current.Session["FADbname"].ToString();
                                if (hid_GroupID.Value == "" || hid_GroupID.Value == "0")
                                {
                                    hid_GroupID.Value = "18";
                                }
                                //if (hidgrptype.Value == "" || hidgrptype.Value=="0")
                                //{
                                //    hidgrptype.Value ="G";
                                //}
                                //ledgerid = ledgerobj.InsLedgerHead(txtcustomer.Text.ToUpper(), 87, 18, 'G', FaDbName);

                                ledgerid = ledgerobj.InsLedgerHead(txtcustomer.Text.ToUpper(), Convert.ToInt32(hid_SubGroupid.Value), Convert.ToInt32(hid_GroupID.Value), 'G', FaDbName);
                                ledgerobj.UpdLedgerid(FaDbName, Convert.ToInt32(Session["LoginBranchid"]), ledgerid, Convert.ToInt32(hf_customerid.Value), 'C');
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 2, int.Parse(Session["LoginBranchid"].ToString()), "LdegerName" + txtcustomer.Text + "ledgerid" + ledgerid + "/Saved");
                            }
                        }
                        clear();
                        Fn_Clear();
                        //obj_MasterCustomer.InsMasterCustomer(txtcustomer.Text.ToUpper(), "C", txtunit.Text, txtbuildingname.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country,
                        //    txtpincode.Text, llisd, txtllstd.Text, Convert.ToInt32(landline), mblisd, txtMobile.Text, faxisd, txtfaxstd.Text, int_fax, txtemail.Text, txtPanNo.Text, txtServiceTaxNo.Text, txtmailcom.Text, txtmailexport.Text, txtmailimp.Text, txtmailfin.Text, txtcomptc.Text,
                        //    txtexpptc.Text, txtimpptc.Text, txtfinptc.Text, Convert.ToInt32(Session["LoginEmpId"]), txtmailmanag.Text, txtmanagptc.Text, tds);
                        //location.UpdCityportInLocation(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_locationid.Value));
                        //obj_MasterCustomer.UpdPortFromCustomer(Convert.ToInt32(hf_districtid.Value), Convert.ToInt32(hf_stateid.Value), std, Convert.ToInt32(hf_portid.Value));
                        //obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 1, int.Parse(Session["LoginBranchid"].ToString()), "CName" + txtcustomer.Text + "/Sav");
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Inserted Successfully');", true);
                        //clear();

                      
                        
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

                        /*String gstin = txt_gstin.Text.ToUpper().Trim();

                        if (validGSTIN(gstin.ToUpper().Trim()))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + "Valid GSTIN!" + "');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + "Invalid GSTIN" + "');", true);
                            txt_gstin.Text = "";
                            txt_gstin.Focus();
                            return;
                        } */

                        if (hf_customerid.Value != "")
                        {
                            /*obj_MasterCustomer.SPUpdMasterCustomerNewDesignimage(txtcustomer.Text.ToUpper(), Type1, txtunit.Text.ToUpper(), txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                                int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                                faxisd, txtfaxstd.Text.ToUpper(), txtfax.Text.ToUpper(), txtemail.Text.ToUpper(), txtPanNo.Text.ToUpper(), txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                                txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(hf_customerid.Value), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txtfinptc.Text.ToUpper(), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4);
                            */


                           /* obj_MasterCustomer.SPUpdMasterCustomerNewDesignimagenew(txtcustomer.Text.ToUpper(), Type1, txtunit.Text.ToUpper(), txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                               int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                               faxisd, txtfaxstd.Text.ToUpper(), txtfax.Text.ToUpper(), txtemail.Text.ToUpper(), txtPanNo.Text.ToUpper(), txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                               txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(hf_customerid.Value), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txtfinptc.Text.ToUpper(), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4, Convert.ToInt32(hf_employeeid.Value));
                            */

                            /*obj_MasterCustomer.SPUpdMasterCustomerNewDesignimagenewnew(txtcustomer.Text.ToUpper(), Type1, txtunit.Text.ToUpper(), txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                               int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                               faxisd, txtfaxstd.Text.ToUpper(), txtfax.Text.ToUpper(), txtemail.Text.ToUpper(), txtPanNo.Text.ToUpper(), txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                               txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(hf_customerid.Value), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txtfinptc.Text.ToUpper(), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register, Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4, Convert.ToInt32(hf_employeeid.Value), Convert.ToDouble(txt_limit.Text), txt_empfrom.Text, txt_empto.Text, txt_certno.Text, Convert.ToDouble(txt_tds_exp.Text), SEZIgst);
                            */


                            //SATHYA

                            obj_MasterCustomer.SPUpdMasterCustomerNewDesignimagenewnew_updlp(txtcustomer.Text.ToUpper(), Type1, txtunit.Text.ToUpper(), txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                      int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                      faxisd, txtfaxstd.Text.ToUpper(), txtfax.Text.ToUpper(), txtemail.Text.ToUpper(), txtPanNo.Text.ToUpper(), txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                      txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(hf_customerid.Value), txtmailmanag.Text.ToUpper(),
                      txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txtfinptc.Text.ToUpper(), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register,
                      Img_Length, Img_Length1, Img_Length2, Img_Length3, Img_Length4, Convert.ToInt32(hf_employeeid.Value), Convert.ToDouble(txt_limit.Text), txt_empfrom.Text, txt_empto.Text, txt_certno.Text, Convert.ToDouble(txt_tds_exp.Text), SEZIgst, livehold);

                            hf_customerid.Value = obj_MasterCustomer.GetCustomeridnew(txtcustomer.Text.ToUpper().Trim(), txtpincode.Text, txtstreet.Text.ToUpper(), int_port.ToString()).ToString();




                            savetds();
                          

                            panreq();

                            if (blerr == true)
                            {
                                blerr = false;
                                return;
                            }
                            //obj_MasterCustomer.SPUpdMasterCustomerNewDesign(txtcustomer.Text.ToUpper(), Type1, txtunit.Text.ToUpper(), txtbuildingname.Text.ToUpper(), txtdoor.Text.ToUpper(), txtstreet.Text.ToUpper(),
                            //    int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, Convert.ToString(landline), mblisd, txtMobile.Text,
                            //    faxisd, txtfaxstd.Text.ToUpper(), txtfax.Text.ToUpper(), txtemail.Text.ToUpper(), txtPanNo.Text.ToUpper(), txtServiceTaxNo.Text.ToUpper(), txtmailcom.Text.ToUpper(), txtmailexport.Text.ToUpper(), txtmailimp.Text.ToUpper(), txtmailfin.Text.ToUpper(),
                            //    txtcomptc.Text.ToUpper(), txtexpptc.Text.ToUpper(), txtimpptc.Text.ToUpper(), txtfinptc.Text.ToUpper(), Convert.ToInt32(hf_customerid.Value), txtmailmanag.Text.ToUpper(), txtmanagptc.Text.ToUpper(), Convert.ToInt32(tds), txtfinptc.Text.ToUpper(), txt_gstin.Text.ToUpper(), txt_uinno.Text.ToUpper(), RCM, unregistered, gstexemp, SEZ, Register);
                            //obj_MasterCustomer.UpdMasterCustomerNew(txtcustomer.Text.ToUpper(), Type1, txtunit.Text, txtbuildingname.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country,
                            //    txtpincode.Text, llisd, txtllstd.Text, Convert.ToInt32(landline), mblisd, txtMobile.Text, faxisd, txtfaxstd.Text, int_fax, txtemail.Text, txtPanNo.Text, txtServiceTaxNo.Text, txtmailcom.Text, txtmailexport.Text, txtmailimp.Text, txtmailfin.Text, txtcomptc.Text,
                            //        txtexpptc.Text, txtimpptc.Text, txtfinptc.Text, int_customer, txtmailmanag.Text, txtmanagptc.Text, tds);
                            //location.UpdCityportInLocation(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_locationid.Value));
                            //obj_MasterCustomer.UpdPortFromCustomer(Convert.ToInt32(hf_districtid.Value), Convert.ToInt32(hf_stateid.Value), std, Convert.ToInt32(hf_portid.Value));
                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 2, int.Parse(Session["LoginBranchid"].ToString()), "CName" + txtcustomer.Text + "/upd" + "Gst Type :" + ddl_Option.SelectedItem.Text + "GSTIN:" + txt_gstin.Text + "PANNO:" + txtPanNo.Text + " CUTID :" + Convert.ToInt32(hid_int_custid.Value));
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Updated Successfully');", true);
                            lstlocation.Visible = false;
                            //  btnSave.Text = "Update";

                            btnSave.ToolTip = "Update";
                            btnSave1.Attributes["class"] = "btn btn-update1";
                            if (chkleger.Enabled == true)
                            {
                                if (chkleger.Checked == true)
                                {

                                    string FaDbName;
                                    int ledgerid;
                                    //    string acctype = "";
                                    // DataTable dtl1 = new DataTable();
                                    // char lt;                       

                                    //lt = Convert.ToChar(acctype);                       
                                    FaDbName = HttpContext.Current.Session["FADbname"].ToString();
                                    if (hid_GroupID.Value == "" || hid_GroupID.Value == "0")
                                    {
                                        hid_GroupID.Value = "18";
                                    }
                                    //if (hidgrptype.Value == "" || hidgrptype.Value=="0")
                                    //{
                                    //    hidgrptype.Value ="G";
                                    //}
                                    //ledgerid = ledgerobj.InsLedgerHead(txtcustomer.Text.ToUpper(), 87, 18, 'G', FaDbName);
                                   
                                    ledgerid = ledgerobj.InsLedgerHead(txtcustomer.Text.ToUpper(), Convert.ToInt32(hid_SubGroupid.Value), Convert.ToInt32(hid_GroupID.Value), 'G', FaDbName);
                                    ledgerobj.UpdLedgerid(FaDbName, Convert.ToInt32(Session["LoginBranchid"]), ledgerid, Convert.ToInt32(hf_customerid.Value), 'C');
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 2, int.Parse(Session["LoginBranchid"].ToString()), "LdegerName" + txtcustomer.Text + "ledgerid" + ledgerid + "/Saved");
                                }
                            }

                            clear();
                            Fn_Clear();
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


            }



            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        //protected void btnView_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        getgrid();
        //        signup.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnBack.ToolTip == "Back")
                {
                    clear();
                    Fn_Clear();
                    clear12();
                    kycclear();
                    hf_employeeid.Value = "";
                    ddl_type.Enabled = true;
                    ddl_Option.Enabled = true;
                    if (Session["Home"] != null)
                    {
                        if (Session["Home"].ToString() == "maintahome")
                        {
                            Response.Redirect("../Home/MaintenanceHome.aspx");
                        }
                    }

                    else
                    {
                        this.Response.End();
                    }

                }
                else
                {
                    ddl_Option.Enabled = true;
                    clear();
                    Fn_Clear();
                    clear12();
                    kycclear();
                    ddlCType.Enabled = true;
                    txtcustomer.Focus();
                    //  btnBack.Text = "Back";
                    txt_certno.Text = "";
                    txt_empfrom.Text = "";
                    txt_empto.Text = "";
                    txt_limit.Text = "";
                    txt_tds_exp.Text = "";
                    ddl_type.Enabled = true;
                    btnBack.ToolTip = "Back";
                    btnBack1.Attributes["class"] = "btn ico-back";
                }
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
                ddl_Option.SelectedValue = "0";
                DataTable dt2 = new DataTable();

                if (hid_int_custid.Value=="")
                {
                    hid_int_custid.Value = "0";
                }
                if (txtcustomer.Text != "" && hf_customerid.Value != "")
                {
                    dt2 = obj_MasterCustomer.GetAllCustDetails(Convert.ToInt32(hf_customerid.Value));
                    getdetails();

                    if (dt2.Rows.Count > 0)
                    {
                       
                        status1 = dt2.Rows[0]["panreq"].ToString();
                        if (status1 == "Y")
                        {
                            cmbpanreq.Text = "YES";
                        }
                        else if (status1 == "N")
                        {
                            cmbpanreq.Text = "NO";
                        }
                        else
                        {
                            cmbpanreq.SelectedIndex = -1;
                        }
                    }
                    // btnSave.Text = "Update";
                    //txtcustomer.Text = "";
                    string str_ledgername;
                    string[] str_temp = txtcustomer.Text.Split(',');
                    if (str_temp.Length > 0)
                    {
                        str_ledgername = str_temp[0].ToString();
                    }
                    else
                    {
                        str_ledgername = txtcustomer.Text;
                    }
                    DataTable dtl = new DataTable();
                    dtl = ledgerobj.GetLikeLedgername(str_ledgername.Trim().ToUpper(), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["FADbname"].ToString());
                    if (dtl.Rows.Count > 0)
                    {
                        chkleger.Enabled = false;
                        txtsubgroupname.Enabled = false;
                    }
                    else
                    {
                        chkleger.Enabled = true;
                        txtsubgroupname.Enabled = true;
                    }



                    kycdetailsnew();
                    txtcustomer.Focus();

                }
                else if (hf_customerid.Value == "")
                {
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
           /* dt = obj_MasterCustomer.SPSelGetCustomerDetails(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));*/

            //SATHYA

            dt = obj_MasterCustomer.SPSelGetCustomerDetailsLiHold(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
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

                //dt.Rows[0]["customerid"].ToString()


                if (dt.Rows[0]["empperiodfrom"] != System.DBNull.Value)
                {
                    txt_empfrom.Text = dt.Rows[0]["empperiodfrom"].ToString();
                }
                else
                {
                    txt_empfrom.Text = "";
                }
                if (dt.Rows[0]["empperiodto"] != System.DBNull.Value)
                {
                    txt_empto.Text = dt.Rows[0]["empperiodto"].ToString();
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
                    txt_limit.Text = "0.00";
                }

                if (dt.Rows[0]["certno"] != System.DBNull.Value)
                {
                    txt_certno.Text = dt.Rows[0]["certno"].ToString();
                }
                else
                {
                    txt_certno.Text = "";
                }


                if (dt.Rows[0]["tdsemp"] != System.DBNull.Value)
                {
                    txt_tds_exp.Text = dt.Rows[0]["tdsemp"].ToString();
                }
                else
                {
                    txt_tds_exp.Text = "0";
                }

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
                int employid = 0;

                if (string.IsNullOrEmpty(dt.Rows[0]["employeeid"].ToString()) != true)
                {
                    employid = Convert.ToInt32(dt.Rows[0]["employeeid"].ToString());
                    if (employid > 0)
                    {
                        txt_Salesperson.Text = objmasemp.GetEmployeeName(employid);
                        txt_Salesperson.Text = txt_Salesperson.Text.ToUpper();
                        hf_employeeid.Value = employid.ToString();
                        txt_Salesperson.ReadOnly = false;
                    }
                    else
                    {
                        txt_Salesperson.ReadOnly = false;
                        txt_Salesperson.Text = "";
                        hf_employeeid.Value = "";
                    }
                }
                else
                {
                    txt_Salesperson.ReadOnly = false;
                    txt_Salesperson.Text = "";
                    hf_employeeid.Value = "";
                }
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
                if (txt_gstin.Text != "")
                {
                    //txt_RCM.Enabled = false;
                    //txt_unregistered.Enabled = false;
                    //txt_RCM.Checked = false;
                    //txt_unregistered.Checked = false;


                    if (txt_gstin.Text.Substring(3, 1) == "P")
                    {
                        ddl_type.Enabled = false;
                        ddl_type_fn();
                    }
                    else
                    {
                        ddl_type.Enabled = true;
                    }

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
                //else
                //{
                //    //txt_RCM.Checked = false;
                //}
                else if (dt.Rows[0]["UnRegistered"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "2";
                    //txt_unregistered.Checked = true;
                }
                //else
                //{
                //    //txt_unregistered.Checked = false;
                //}

                else if (dt.Rows[0]["gstexemption"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "3";
                    // txt_gstexi.Checked = true;
                }
                else if (dt.Rows[0]["Sez"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "6";
                    // txt_gstexi.Checked = true;
                }
                else if (dt.Rows[0]["Register"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "5";
                    // txt_gstexi.Checked = true;
                }
                else if (dt.Rows[0]["sezexemption"].ToString() == "Y")
                {
                    ddl_Option.SelectedValue = "4";
                    // txt_gstexi.Checked = true;
                }
                else
                {
                    ddl_Option.SelectedValue = "0";
                }

                //livvehold selection 

                if(dt.Rows[0]["livehold"].ToString()=="H")
                {
                    DropLiveHold.SelectedValue = "2";
                }
                else
                {
                    DropLiveHold.SelectedValue = "1";
                }


                //else
                //{
                //   // txt_gstexi.Checked = false;
                //}
                /***********************************************/
                if (ddl_Option.SelectedValue == "4" || ddl_Option.SelectedValue == "1" || ddl_Option.SelectedValue == "3" || ddl_Option.SelectedValue == "5" || ddl_Option.SelectedValue == "6")
                {
                    ddl_Option.Enabled = false;
                }
                else
                {
                    ddl_Option.Enabled = true;
                }


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
                            //lstlocation.Visible = true;
                            //lstlocation.Items.Clear();
                            //lstlocation.DataSource = dt;
                            //lstlocation.DataValueField = "Location";
                            //lstlocation.DataBind();
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
                //dtnew=obj_MasterCustomer.SPSelGetCustomerDetails(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
                CustomerTDS();
                if (txt_gstin.Text != "")
                {
                    //txt_RCM.Enabled = false;
                    //txt_unregistered.Enabled = false;
                    //txt_RCM.Checked = false;
                    //txt_unregistered.Checked = false;


                    if (txt_gstin.Text.Substring(3, 1) == "P")
                    {
                        ddl_type.Enabled = false;
                        ddl_type_fn();
                    }
                    else
                    {
                        ddl_type.Enabled = true;
                    }

                }
                btnSave.Enabled = true;
                // btnSave.Text = "Update";
                //  btnBack.Text = "Clear";

                btnSave.ToolTip = "Update";
                btnSave1.Attributes["class"] = "btn btn-update1";

                btnBack.ToolTip = "Clear";
                btnBack1.Attributes["class"] = "btn btn-clear1";

                if (txtcountry.Text.ToUpper() != "INDIA")
                {
                    // txtlocation.ReadOnly = true;
                    txtdistrict.ReadOnly = true;
                    txtstate.ReadOnly = true;
                    txtcountry.ReadOnly = true;

                    ddl_description.Enabled = false;
                    ddl_type.Enabled = false;
                    ddl_slab.Enabled = false;
                    ddl_percentage.Enabled = false;

                }
                else
                {
                    ddl_description.Enabled = true;
                    ddl_type.Enabled = true;
                    ddl_slab.Enabled = true;
                    ddl_percentage.Enabled = true;
                }

                //if (txtGSTCode.Text == "")
                //{

                if (DropLiveHold.SelectedItem.Text == "Hold")
                {
                    // livehold = DropLiveHold.SelectedItem.Text;

                    livehold = "H";

                }
                else
                {
                    livehold = "L";
                }



                dts = obj_MasterCustomer.SPSelGetCustomerDetailsGSTIN(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
                if (dts.Rows.Count > 0)
                {
                    txtGSTCode.Text = dts.Rows[0]["GSTCode"].ToString();
                    hdn_oldgstcode.Value = dts.Rows[0]["GSTCode"].ToString();

                }
                //else
                //{
                //    if (ddlCType.SelectedValue=="C" && hf_countryid.Value=="1102")
                //    {
                //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('UPDATE THE GST CODE FOR THIS CUSTOMER');", true);
                //    }

                //}
                hid_gstcode.Value = hf_stateid.Value;

                ddlCType.Enabled = false;
            }


        }


        private void getdetailscustomer(int int_custid, string custname, string custtype)
        {

            //btndelete.Text = "Reject";

            btndelete.ToolTip = "Reject";
            btndelete1.Attributes["class"] = "btn btn-reject1";

            btndelete.Enabled = true;
            btndelete.ForeColor = System.Drawing.Color.White;
            DataTable dt1 = new DataTable();
            string custpye;
            try
            {
                txtcustomer.Text = custname;


                dt1 = cusobj.getOtherReqCustomerDtls(int_custid, custname, custtype);
                if (dt1.Rows.Count > 0)
                {
                    //  zip,phone,fax,email,ptc,commailid,expmailid,impmailid,finmailid,tds,comptc,expptc,impptc,finptc,llisd
                    ddl_Option.Enabled = true;
                    if (dt1.Rows[0]["empperiodfrom"] != System.DBNull.Value)
                    {
                        txt_empfrom.Text =dt1.Rows[0]["empperiodfrom"].ToString();
                    }
                    else
                    {
                        txt_empfrom.Text = "";
                    }
                    if (dt1.Rows[0]["empperiodto"] != System.DBNull.Value)
                    {
                        txt_empto.Text = dt1.Rows[0]["empperiodto"].ToString();
                    }
                    else
                    {
                        txt_empto.Text = "";
                    }
                    if (dt1.Rows[0]["limit"] != System.DBNull.Value)
                    {
                        txt_limit.Text = dt1.Rows[0]["limit"].ToString();
                    }
                    else
                    {
                        txt_limit.Text = "0.00";
                    }

                    if (dt1.Rows[0]["tdsemp"] != System.DBNull.Value)
                    {
                        txt_tds_exp.Text = dt1.Rows[0]["tdsemp"].ToString();
                    }
                    else
                    {
                        txt_tds_exp.Text = "0";
                    }

                    if (dt1.Rows[0]["certno"] != System.DBNull.Value)
                    {
                        txt_certno.Text = dt1.Rows[0]["certno"].ToString();
                    }
                    else
                    {
                        txt_certno.Text = "";
                    }

                    
                    hf_customerid.Value = int_custid.ToString();
                    txtunit.Text = dt1.Rows[0]["unit#"].ToString();
                    txtbuildingname.Text = dt1.Rows[0]["buildingname"].ToString();
                    txtdoor.Text = dt1.Rows[0]["door#"].ToString();
                    txtstreet.Text = dt1.Rows[0]["address"].ToString();
                    txtcity.Text = port.GetPortname(Convert.ToInt32(dt1.Rows[0]["city"].ToString()));
                    // txtlocation.Text = obj_MasterCustomer.GetLocationname(Convert.ToInt32(dt1.Rows[0]["countryid"].ToString()));





                    txtpincode.Text = dt1.Rows[0]["zip"].ToString();
                    txtpincode.ReadOnly = false;
                    txtlandline.Text = dt1.Rows[0]["phone"].ToString();
                    txtlandline.ReadOnly = false;
                    txtfax.Text = dt1.Rows[0]["fax"].ToString();
                    txtfax.ReadOnly = false;
                    txtemail.Text = dt1.Rows[0]["email"].ToString();
                    txtemail.ReadOnly = false;
                    txtmailcom.Text = dt1.Rows[0]["commailid"].ToString();
                    txtmailcom.ReadOnly = false;
                    txtmailexport.Text = dt1.Rows[0]["expmailid"].ToString();
                    txtmailexport.ReadOnly = false;
                    txtmailimp.Text = dt1.Rows[0]["impmailid"].ToString();
                    txtmailimp.ReadOnly = false;
                    txtmailfin.Text = dt1.Rows[0]["finmailid"].ToString();


                    txtmailfin.ReadOnly = false;
                    txtmailmanag.Text = dt1.Rows[0]["managmail"].ToString();
                    txtmailmanag.ReadOnly = false;
                    txtmanagptc.Text = dt1.Rows[0]["managptc"].ToString();
                    txtmanagptc.ReadOnly = false;

                    txtMobile.Text = dt1.Rows[0]["mobile"].ToString();
                    txtMobile.ReadOnly = false;
                    txttds.Text = dt1.Rows[0]["tds"].ToString();
                    txttds.ReadOnly = false;
                    txtcomptc.Text = dt1.Rows[0]["comptc"].ToString();
                    txtcomptc.ReadOnly = false;
                    txtexpptc.Text = dt1.Rows[0]["expptc"].ToString();
                    txtexpptc.ReadOnly = false;
                    txtimpptc.Text = dt1.Rows[0]["impptc"].ToString();
                    txtimpptc.ReadOnly = false;
                    txtfinptc.Text = dt1.Rows[0]["finptc"].ToString();
                    txtfinptc.ReadOnly = false;
                    txtllisd.Text = dt1.Rows[0]["llisd"].ToString();
                    txtllisd.ReadOnly = false;

                    txt_uinno.Text = dt1.Rows[0]["uinno"].ToString();
                    txt_uinno.ReadOnly = false;
                    if (!String.IsNullOrEmpty(dt1.Rows[0]["city"].ToString()))
                    {
                        hf_portid.Value = dt1.Rows[0]["city"].ToString();
                        Session["portid"] = dt1.Rows[0]["city"].ToString();
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
                        getlocationdetails();
                    }                        
                
                    else
                    {
                        hf_locationid.Value = "0";
                    }
                    if (!String.IsNullOrEmpty(dt1.Rows[0]["panno"].ToString()))
                    {
                        txtPanNo.Text = dt1.Rows[0]["panno"].ToString();
                    }
                    else
                    {
                        txtPanNo.Text = "";
                    }
                    if (!String.IsNullOrEmpty(dt1.Rows[0]["gstin"].ToString()))
                    {
                        txt_gstin.Text = dt1.Rows[0]["gstin"].ToString();
                    }
                    else
                    {
                        txt_gstin.Text = "";
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
                    if (dt1.Rows[0]["RCM"].ToString() == "Y")
                    {
                        // txt_RCM.Checked = true;
                        ddl_Option.SelectedValue = "1";
                    }
                    //else
                    //{
                    //    //txt_RCM.Checked = false;
                    //}
                    else if (dt1.Rows[0]["UnRegistered"].ToString() == "Y")
                    {
                        ddl_Option.SelectedValue = "2";
                        //txt_unregistered.Checked = true;
                    }
                    //else
                    //{
                    //    //txt_unregistered.Checked = false;
                    //}

                    else if (dt1.Rows[0]["gstexemption"].ToString() == "Y")
                    {
                        ddl_Option.SelectedValue = "3";
                        // txt_gstexi.Checked = true;
                    }
                    else if (dt1.Rows[0]["Sez"].ToString() == "Y")
                    {
                        ddl_Option.SelectedValue = "4";
                        // txt_gstexi.Checked = true;
                    }
                    else if (dt1.Rows[0]["Register"].ToString() == "Y")
                    {
                        ddl_Option.SelectedValue = "5";
                        // txt_gstexi.Checked = true;
                    }
                    else if (dt1.Rows[0]["sezexemption"].ToString() == "Y")
                    {
                        ddl_Option.SelectedValue = "6";
                        // txt_gstexi.Checked = true;
                    }
                    else
                    {
                        ddl_Option.SelectedValue = "0";
                    }


                    int employid = 0;
                    if (string.IsNullOrEmpty(dt1.Rows[0]["saleid"].ToString()) != true)
                    {
                        employid = Convert.ToInt32(dt1.Rows[0]["saleid"].ToString());
                        if (employid > 0)
                        {
                            txt_Salesperson.Text = objmasemp.GetEmployeeName(employid);
                            txt_Salesperson.Text = txt_Salesperson.Text.ToUpper();
                            hf_employeeid.Value = employid.ToString();
                            txt_Salesperson.ReadOnly = false;
                        }
                        else
                        {
                            txt_Salesperson.ReadOnly = false;
                            txt_Salesperson.Text = "";
                            hf_employeeid.Value = "";
                        }
                    }
                    else
                    {
                        txt_Salesperson.ReadOnly = false;
                        txt_Salesperson.Text = "";
                        hf_employeeid.Value = "";
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
                    // btnSave.Text = "Save";
                    // btnBack.Text = "Cancel";

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
                //  btnBack.Text = "Cancel";


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
            hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(txtcity.Text.ToUpper()));
            if (hf_countryid.Value == "1102" || hf_countryid.Value == "102")
            {
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
        }
        protected void lstlocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lstlocation.Visible = false;
                lstlocation.Visible = false;
                txtlocation.Text = lstlocation.SelectedValue.ToString();
                DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
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
                        return;
                    }
                    hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(txtcity.Text.ToUpper()));
                    txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                    if (txtpincode.Text != "")
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Enter Pin code');", true);
                        txtpincode.Text = "";
                        txtlocation.Text = "";
                        txtstate.Text = "";
                        txtdistrict.Text = "";
                        txtGSTCode.Text = "";
                        txtcountry.Text = "";
                        txtpincode.Focus();
                        return;

                        txtpincode.Focus();
                        return;
                    }
                    if (hf_countryid.Value != "1102" && hf_countryid.Value != "102")
                    {
                        txtdistrict.ReadOnly = true;
                        txtstate.ReadOnly = true;
                        txtcountry.ReadOnly = true;
                        ddl_description.Enabled = false;
                        ddl_type.Enabled = false;
                        ddl_slab.Enabled = false;
                        ddl_percentage.Enabled = false;

                    }
                    else
                    {
                        ddl_description.Enabled = true;
                        ddl_type.Enabled = true;
                        ddl_slab.Enabled = true;
                        ddl_percentage.Enabled = true;
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



            //try
            //{
            //    MailAddress m = new MailAddress(emailaddress);

            //    return true;
            //}
            //catch (FormatException)
            //{
            //    return false;
            //}

            

            //Regex To validate Email Address
          //  Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
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
            /* try
             {
                string str_sp = "";
                 string str_sf = "";
                 string str_RptName = "";
                 string str_Script = "";
                 Session["str_sfs"] = "";
                 Session["str_sp"] = "";

                 DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                 str_RptName = "MasterCustomer.rpt";
                 //  Session["str_sfs"] = "{FEJobInfo.bid}=" + Session["LoginBranchid"].ToString() + " and {FEJobInfo.jobno}=" + txt_job.Text;
                 //   report.strRptName = "Reports" + "\MasterCustomer.rpt" ' "REPORTS" + "\EmpDetails.rpt"
                 str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                 ScriptManager.RegisterStartupScript(btnview, typeof(Button), "MasterCustomer", str_Script, true);
                 Session["str_sfs"] = str_sf;
                 Session["str_sp"] = str_sp;
                 DataAccess.Masters.MasterCustomer  cutobj= new DataAccess.Masters.MasterCustomer();
                 DataTable dtl = new DataTable();
                 dt1 = cutobj.sgetcustomerdetailexport();



             }
             catch (Exception ex)
             {
                 string message = ex.Message.ToString();
                 ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
             }*/
            DataAccess.Masters.MasterCustomer cutobj = new DataAccess.Masters.MasterCustomer();
            

            grdexcel.DataSource = null;
            grdexcel.DataBind();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Customers.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringBuilder SB = new StringBuilder();
            StringWriter StringWriter = new System.IO.StringWriter(SB);
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

            DataTable dt = cutobj.sgetcustomerdetailexport();

            int cnt = 0;
            grdexcel.DataSource = dt;
            grdexcel.DataBind();
            cnt = dt.Columns.Count;
            SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Customer Details</B></font></td></tr>");
            SB.Append("</table>");

       
               grdexcel.GridLines = GridLines.Both;
                grdexcel.HeaderStyle.Font.Bold = true;
                grdexcel.RenderControl(HtmlTextWriter);
           Response.Write(StringWriter.ToString());
            Response.End();;
           
            
           
            
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

                //else
                //{
                //    custpye = null;
                //}



                // int int_jobno = Convert.ToInt32(((Label)Grd_Job.Rows[index].Cells[0].FindControl("cusomerid")).Text);
                getdetailscustomer(int_custid, custname, ddlCType.SelectedValue);
                hid_int_custid.Value = int_custid.ToString();
                hf_customerid.Value = int_custid.ToString();
                kycdetails();
                //BindBooking();
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
            //if (txt_gstin.Text.ToUpper() != "" && txtPanNo.Text.ToUpper() != "")
            if (txtPanNo.Text == "")
            {
                if (txt_gstin.Text != "")
                {

                 

                    if (txt_gstin.Text.Substring(3,1)=="P")
                    {
                        ddl_type.Enabled = false;
                        ddl_type_SelectedIndexChanged(sender, e);
                    }
                    else
                    {
                        ddl_type.Enabled = true;
                    }
                    if (txt_gstin.Text.Trim().Length > 14)
                    {
                        txtPanNo.Text = txt_gstin.Text.ToUpper().Substring(2, 10);
                    }
                }
                

            }

            if (txt_gstin.Text.Length == 15)
            {


            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('GSTIN # should be 15 characters ');", true);
                txt_gstin.Text = "";
                txt_gstin.Focus();
                ddl_type.Enabled = true;
                return;
            }


            if (txt_gstin.Text.Length >= 12 && txtPanNo.Text.ToUpper() != "")
            {
                if (txtPanNo.Text.ToUpper() == txt_gstin.Text.ToUpper().Substring(2, 10))
                {

                    ddl_Option.SelectedValue = "5";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('GSTIN # - PAN# and Customer PAN# Does Not Match');", true);
                    txt_gstin.Text = "";
                    txt_gstin.Focus();
                    ddl_type.Enabled = true;
                    return;
                }
            }
            //if (txt_gstin.Text != "")
            //{
            //    //txt_RCM.Enabled = false;
            //    //txt_unregistered.Enabled = false;
            //    //txt_RCM.Checked = false;
            //    //txt_unregistered.Checked = false;

            //}
            //else if (txt_uinno.Text == "")
            //{
            //    //txt_RCM.Enabled = true;
            //    // txt_unregistered.Enabled = true;
            //}


            String gstin = txt_gstin.Text.ToUpper().Trim();

            if (validGSTIN(gstin.ToUpper().Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + "Valid GSTIN!" + "');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + "Invalid GSTIN" + "');", true);
                txt_gstin.Text = "";
                txt_gstin.Focus();
                return;
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

                    btnSave1.Attributes["class"] = "btn btn-update1";
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
                    //btn_Save.Text = "Save";

                    //btn_Save1.Attributes["class"] = "btn ico-save";
                }
                btnSave.Enabled = true;

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

        protected void ddl_type_fn()
        {
            try
            {

                obj_dt = obj_da_TDS.SelAllTDSDtls();
                if (ddl_type.SelectedItem.Text.Trim().Length > 0)
                {
                    if (txtPanNo.Text != "")
                    {
                        if (txtPanNo.Text.Substring(3, 1) == "P")
                        {
                            ddl_type.Text = "Individual";
                        }
                    }
                    
                    if (ddl_type.Text == "Individual")
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

        protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_type_fn();
        }

        private void Fn_Clear()
        {
            ddl_description.Enabled = true;
            ddl_type.Enabled = true;
            ddl_slab.Enabled = true;
            ddl_percentage.Enabled = true;
            txtcustomer.Text = "";
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
            txt_certno.Text = "";
            txt_empfrom.Text = "";
            txt_empto.Text = "";
            txt_limit.Text = "";
            txt_tds_exp.Text = "";
            //btnSave.Enabled = false;
            btnSave.Enabled = true;
            btnSave.ToolTip = "Save";

            btnSave1.Attributes["class"] = "btn ico-save";
            chkleger.Checked = false;
            txtsubgroupname.Text = "";
            hid_SubGroupid.Value = "0";
            chkleger.Enabled = true;
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
                        // obj_da_TDS.UpdTDSid(int_TDSid, int.Parse(hf_customerid.Value.ToString()));

                        //if (btn_Save.Text == "Save")
                        //{
                        //    ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "CustomerTDS", "alertify.alert('TDS Saved');", true);
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "CustomerTDS", "alertify.alert('TDS Updated');", true);
                        //}
                    }



                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
        protected void txt_Salesperson_TextChanged(object sender, EventArgs e)
        {
            if (txt_Salesperson.Text != "")
            {
                if (hf_employeeid.Value == "" || hf_employeeid.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "Mastercustomer", "alertify.alert('Invalid Employee..');", true);
                    txt_Salesperson.Focus();
                    txt_Salesperson.Text = "";
                }
                else
                {

                }
            }
        }


        //Sinosh

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



        protected void btn_Block_customer_Click(object sender, EventArgs e)
        {
            string Vouchertype = "";
            if (txtcustomer.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Customer Name');", true);
                return;
            }
            if (btnSave.ToolTip == "Update")
            {
                if (hf_customerid.Value == "" || hf_customerid.Value == "0")
                {
                    dt = (DataTable)Session["data"];
                    if (dt.Rows.Count > 0)
                    {
                        hf_customerid.Value = dt.Rows[0]["customerid"].ToString();
                    }
                    else
                    {
                        return;
                    }

                }

                DataTable DT_check = obj_MasterCustomer.Get4customercheckblock(Convert.ToInt32(hf_customerid.Value));
                int count_check = 0;
                DT_check = DT_check.DefaultView.ToTable(true);
                if (DT_check.Rows.Count > 0)
                {
                    for (int i = 0; i < DT_check.Rows.Count; i++)
                    {
                        if (DT_check.Rows[i][0].ToString() == "Invoice")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }

                        }
                        else if (DT_check.Rows[i][0].ToString() == "Profoma Invoice")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "CN-OPS")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "Profoma CN-OPS")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "Credit Note")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "Profoma Credit Note")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "Debit Note")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "Profoma Debit Note")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "Admin DN")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "Profoma Admin DN")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "Admin CN")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "Profoma Admin DN")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "OSPI")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "Profoma OSCN")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "OSSI")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "Profoma OSDN")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "Receipt")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }
                        else if (DT_check.Rows[i][0].ToString() == "Payment")
                        {
                            if (count_check == 0)
                            {
                                Vouchertype += DT_check.Rows[i][0].ToString();
                                count_check += 1;
                            }
                            else
                            {
                                Vouchertype += ", " + DT_check.Rows[i][0].ToString();
                            }
                        }

                    }
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly check with IT Team, Because this customer is used for " + Vouchertype + " Vouchers');", true);
                    return;
                }
                else
                {
                    obj_MasterCustomer.Block_customer(Convert.ToInt32(hf_customerid.Value));
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Customer Blocked Successfully');", true);
                    clear();
                }






            }

            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 5, int.Parse(Session["LoginBranchid"].ToString()), "CName" + txtcustomer.Text + " Customer Id " + hf_customerid.Value + " " + Vouchertype  + "/blocked");

        }

        protected void ddlCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCType.SelectedValue == "P")
            {
                ddl_Option.SelectedValue = "2";
            }
        }


        public void panreq()
        {
            //string status = "";
            if (cmbpanreq.SelectedItem.Text != "")
            {

                if (cmbpanreq.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "CustomerWithPanReq", "alertify.alert('Required PAN# Details Cannot be Blank')", true);
                    cmbpanreq.Focus();
                    blerr = true;
                    return;
                }
                if (cmbpanreq.Text == "YES")
                {
                    status1 = "Y";
                }
                else
                {
                    status1 = "N";
                }
                if (hf_customerid.Value != "0")
                {
                    obj_MasterCustomer.UpdPAnno(Convert.ToInt32(hf_customerid.Value), status1);
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1691, 2, int.Parse(Session["LoginBranchid"].ToString()), hf_customerid.Value + "-Status-" + status1);
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerWithPanReq", "alertify.alert('Details has Updated')", true);
                    clear12();
                }
            }
        }

        protected void btn_custgroup_Click(object sender, EventArgs e)
        {
            int locationid, groupid;
            
            DataAccess.Masters.MasterCustomerGroup obj_main = new DataAccess.Masters.MasterCustomerGroup();
            int grouid1=1;
            if (hf_customerid.Value != "" && hf_customerid.Value !="0")
            {

                custid = Convert.ToInt32(hf_customerid.Value);
                grouid1 = Convert.ToInt32(obj_MasterCustomer.getcustgroupid(Convert.ToInt32(hf_customerid.Value)));

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter Customer Name ');", true);
                clear();
                Fn_Clear();
                clear12();
                kycclear();
                //Clear();
                return;
            }
            if (grouid1 == 0)
            {
                if (hf_locationid.Value != "" )
                {
                    locationid = Convert.ToInt32(hf_locationid.Value);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter correct location');", true);
                   
                    return;
                }
                groupid = Convert.ToInt32(obj_main.InsertCustomerDetails(txtcustomer.Text.ToUpper(), txt_Salesperson.Text.ToUpper(), txtstreet.Text.ToUpper(), txtcity.Text.ToUpper(), txtpincode.Text, txtMobile.Text, txtfax.Text, txtemail.Text.ToUpper(), locationid));
                //obj_main.InsertCustomerDetails(txtname.Text, txt_person.Text, txtaddress.Text, txtcity.Text, txtzip.Text, txtphone.Text, txtfax.Text, txtEmail.Text, locationid);
                if (custid == 0)
                {
                    custid = Convert.ToInt32(obj_MasterCustomer.GetCustomerid(txtcustomer.Text.ToUpper()).ToString());

                }
                obj_main.UpdateCustomerGroupid(custid, groupid, 1);

                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 339, 1, int.Parse(Session["LoginBranchid"].ToString()), txtcustomer.Text + "/" + groupid);
                ScriptManager.RegisterStartupScript(btn_custgroup, typeof(System.Web.UI.WebControls.Button), "MasterExchangeRate", "alertify.alert(' Customer Group created');", true);
                clear();
                Fn_Clear();
                clear12();
                kycclear();
                //Clear();
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_custgroup, typeof(System.Web.UI.WebControls.Button), "MasterExchangeRate", "alertify.alert('Group already created for This Customer');", true);
                clear();
                Fn_Clear();
                clear12();
                kycclear();
                return;
            }



            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 131, 6, int.Parse(Session["LoginBranchid"].ToString()), "CName:" + txtcustomer.Text + " Groupid Id:" + groupid + "custid:" + custid + "/Custgroup");
        }




        protected void ddlIDProof_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlIDProof.Text != "")
            {
                if (ddlIDProof.Text == "Voter ID")
                {
                    id = 1;
                }
                else if (ddlIDProof.Text == "PAN Card")
                {
                    id = 2;
                }
                else if (ddlIDProof.Text == "Adhaar ID")
                {
                    id = 3;
                }
                else if (ddlIDProof.Text == "GST")
                {
                    id = 4;
                }
                else if (ddlIDProof.Text == "KYC")
                {
                    id = 5;
                }
            }
        }

        protected void btnkyc_Click(object sender, EventArgs e)
        {
            if (hf_customerid.Value != "" && hf_customerid.Value != "0")
            {
                if (GrdProof.Rows.Count >= 0)
                {
                    for (int i = 0; i < GrdProof.Rows.Count; i++)
                    {
                        if (GrdProof.Rows[i].Cells[0].Text == ddlIDProof.Text)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ddlIDProof.Text + " Already Exist');", true);
                            return;
                        }
                    }
                }
                savekycmaster();
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

        private void savekyc()
        {
            if (hid_int_custid.Value != "" || hid_int_custid.Value != "0" || hf_customerid.Value != "" || hf_customerid.Value != "0")
            {
            obj_MasterCustomer.insertmastercustomerkyc(int.Parse(hid_int_custid.Value), int.Parse(hf_customerid.Value));   
            }
            
        }

        private void savekycmaster()
        {
            CheckDataforkyc();
            int icustreqid = 0;
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
                    fuIDDoc.SaveAs(Server.MapPath("~/UploadDocument/Proofs/" + hf_customerid.Value + "-" + ddlid + "-" + fuIDDoc.FileName));
                    c = (Server.MapPath("~/UploadDocument/Proofs/") + hf_customerid.Value + "-" + ddlid + "-" + Path.GetFileName(fuIDDoc.FileName));
                    idfilename = hf_customerid.Value + "-" + ddlid + "-" + Path.GetFileName(fuIDDoc.FileName);
                    fileupload(fuIDDoc.FileName, c);
                    //obj_MasterCustomer.inskycproofcustomerwithgst(ddlid, int.Parse(hf_customerid.Value), ddlid, idfilename, int.Parse(Session["LoginEmpId"].ToString()));

                    //obj_MasterCustomer.inskycproofcustomerwithgstreq(ddlid, int.Parse(hf_customerid.Value), ddlid, idfilename, int.Parse(Session["LoginEmpId"].ToString()));

                    icustreqid = obj_MasterCustomer.Getkycddetails(txtcustomer.Text);
                    obj_MasterCustomer.inskycproofcustomerwithgst(ddlid, icustreqid, ddlid, idfilename, int.Parse(Session["LoginEmpId"].ToString()));
                    System.IO.File.Delete(c);
                    kycdetails();
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


        public void kycdetails()
        {
            DataTable dtProof = new DataTable();
            DataTable dtPrf = new DataTable();


            dtProof = obj_MasterCustomer.Getkycdetailsreq(int.Parse(hf_customerid.Value));
            if (dtProof.Rows.Count > 0)
            {
                dtPrf.Columns.Add("proof");
                dtPrf.Columns.Add("filename");

                if (!string.IsNullOrWhiteSpace(dtProof.Rows[0]["idpfilename"].ToString()))
                {
                    dtPrf.Rows.Add();
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["proof"] = "Voter ID";
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["filename"] = dtProof.Rows[0]["idpfilename"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(dtProof.Rows[0]["panfilename"].ToString()))
                {
                    dtPrf.Rows.Add();
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["proof"] = "PAN Card";
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["filename"] = dtProof.Rows[0]["panfilename"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(dtProof.Rows[0]["addfilename"].ToString()))
                {
                    dtPrf.Rows.Add();
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["proof"] = "Aadhar ID";
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["filename"] = dtProof.Rows[0]["addfilename"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(dtProof.Rows[0]["gstfilename"].ToString()))
                {
                    dtPrf.Rows.Add();
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["proof"] = "GST";
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["filename"] = dtProof.Rows[0]["gstfilename"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(dtProof.Rows[0]["kycfilename"].ToString()))
                {
                    dtPrf.Rows.Add();
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["proof"] = "KYC";
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["filename"] = dtProof.Rows[0]["kycfilename"].ToString();
                }
                GrdProof.DataSource = dtPrf;
                GrdProof.DataBind();
            }


        }



        public void kycdetailsnew()
        {
            DataTable dtProof = new DataTable();
            DataTable dtPrf = new DataTable();
            int custreqid = 0;
            custreqid = obj_MasterCustomer.Getkycddetailsnew(txtcustomer.Text, txtpincode.Text, hf_portid.Value);
            if (custreqid != 0)
            {
                dtProof = obj_MasterCustomer.Getkycdetailsreq((custreqid));
            }
            if (dtProof.Rows.Count > 0)
            {
                dtPrf.Columns.Add("proof");
                dtPrf.Columns.Add("filename");

                if (!string.IsNullOrWhiteSpace(dtProof.Rows[0]["idpfilename"].ToString()))
                {
                    dtPrf.Rows.Add();
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["proof"] = "Voter ID";
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["filename"] = dtProof.Rows[0]["idpfilename"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(dtProof.Rows[0]["panfilename"].ToString()))
                {
                    dtPrf.Rows.Add();
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["proof"] = "PAN Card";
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["filename"] = dtProof.Rows[0]["panfilename"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(dtProof.Rows[0]["addfilename"].ToString()))
                {
                    dtPrf.Rows.Add();
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["proof"] = "Aadhar ID";
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["filename"] = dtProof.Rows[0]["addfilename"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(dtProof.Rows[0]["gstfilename"].ToString()))
                {
                    dtPrf.Rows.Add();
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["proof"] = "GST";
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["filename"] = dtProof.Rows[0]["gstfilename"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(dtProof.Rows[0]["kycfilename"].ToString()))
                {
                    dtPrf.Rows.Add();
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["proof"] = "KYC";
                    dtPrf.Rows[dtPrf.Rows.Count - 1]["filename"] = dtProof.Rows[0]["kycfilename"].ToString();
                }
                GrdProof.DataSource = dtPrf;
                GrdProof.DataBind();
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
            else if (!(fuIDDoc.HasFile))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('ID Proof of File DocPath cannot be Blank');", true);
                fuIDDoc.Focus();
                k = 0;
                return;
            }
        }

        private void fileupload(string filenames, string path)
        {

            using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
            {
                DBCS = reader.ReadLine();
            }

            ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
            dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
            username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
            password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();
         
            b = Path.GetFileName(filenames);
            a = "ftp://20.235.30.214/SL/kyc/" + hf_customerid.Value + "-" + ddlid + "-" + filenames;
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

        private void ddlCustomerTypefill()
        {
            DataTable dttype = new DataTable();
            ddlIDProof.Items.Clear();
            dttype = obj_MasterCustomer.SPSelKYCProof("I");
            if (dttype.Rows.Count > 0)
            {
                ddlIDProof.Items.Add("Select");
                for (int i = 0; i <= dttype.Rows.Count - 1; i++)
                {
                    ddlIDProof.Items.Add(dttype.Rows[i]["Proofmaster"].ToString());
                }
            }
        }

        protected void GrdProof_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = GrdProof.SelectedRow.RowIndex;
                string filename1;
                if (GrdProof.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    if (txtcustomer.Text != "")
                    {
                        if (!string.IsNullOrWhiteSpace(GrdProof.Rows[index].Cells[1].Text))
                        {
                            filename1 = GrdProof.Rows[index].Cells[1].Text;
                            if (hf_customerid.Value != "")
                            {
                                //fttnormaldwd(filename1);
                                string Test = "0";
                                ScriptManager.RegisterStartupScript(GrdProof, typeof(GridView), "Download", "window.open('../Download.aspx?Filename=" + filename1 + "&Test=" + Test + "');", true);
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
            catch (Exception ex)
            {

            }
        }

        protected void fttnormaldwd(string filename1)
        {
            using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
            {
                DBCS = reader.ReadLine();
            }

            ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
            dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
            username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
            password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();
           
            string str_filename;
            str_filename = filename1;
            DataTable dt = new DataTable();

            string path = Server.MapPath("~/UploadDocument/Proofs/" + str_filename);
            string ftp = "ftp://20.235.30.214/";

            //FTP Folder name. Leave blank if you want to Download file from root folder.
            string ftpFolder = "SL/kyc/";
            //try
            //{
            //Create FTP Request.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + str_filename);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            //Enter FTP Server credentials.
           // request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");

            request.Credentials = new NetworkCredential(username, password);

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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdProof, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GrdProof_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                    if (!string.IsNullOrWhiteSpace(GrdProof.Rows[grd.RowIndex].Cells[1].Text))
                    {
                        if (GrdProof.Rows[grd.RowIndex].Cells[0].Text == "Voter ID")
                        {
                            ddlid1 = 1;
                        }
                        if (GrdProof.Rows[grd.RowIndex].Cells[0].Text == "PAN Card")
                        {
                            ddlid1 = 2;
                        }
                        if (GrdProof.Rows[grd.RowIndex].Cells[0].Text == "Aadhar ID")
                        {
                            ddlid1 = 3;
                        }
                        if (GrdProof.Rows[grd.RowIndex].Cells[0].Text == "GST")
                        {
                            ddlid1 = 4;
                        }
                        if (GrdProof.Rows[grd.RowIndex].Cells[0].Text == "KYC")
                        {
                            ddlid1 = 5;
                        }
                        obj_MasterCustomer.Delkycdetails(ddlid1, Convert.ToInt32(hf_customerid.Value), GrdProof.Rows[grd.RowIndex].Cells[1].Text);
                        //obj_dt.Rows[grd.RowIndex].Delete();
                        //obj_dt.AcceptChanges();
                        filename = GrdProof.Rows[grd.RowIndex].Cells[1].Text;
                        ftpdeleted(filename);
                        kycdetails();
                        ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('File has been deleted');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('No File To deleted');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void ftpdeleted(string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
                {
                    DBCS = reader.ReadLine();
                }

                ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
                dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
                username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
                password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();
           


                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://20.235.30.214/SL/kyc/" + filename);
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

        protected void GrdProof_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        public void kycclear()
        {
            ddlIDProof.SelectedIndex = 0;
            GrdProof.DataSource = new DataTable();
            GrdProof.DataBind();
        }

        protected void ddlAddProof_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAddProof.Text != "")
            {
                if (ddlAddProof.Text == "Voter ID")
                {
                    add = 1;
                }
                else if (ddlAddProof.Text == "PAN Card")
                {
                    add = 2;
                }
                else if (ddlAddProof.Text == "Aathar ID")
                {
                    add = 3;
                }
                else if (ddlAddProof.Text == "GST")
                {
                    add = 4;
                }
            }
        }
        protected void ddlkycproof_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlkycproof.Text != "")
            {
                if (ddlkycproof.Text == "Voter ID")
                {
                    gid = 1;
                }
                else if (ddlkycproof.Text == "PAN Card")
                {
                    gid = 2;
                }
                else if (ddlkycproof.Text == "Aathar ID")
                {
                    gid = 3;
                }
                else if (ddlkycproof.Text == "GST")
                {
                    gid = 4;
                }
            }
        }

        protected void txtsubgroupname_TextChanged(object sender, EventArgs e)
        {
            if (txtsubgroupname.Text != "")
            {
                DataTable dtSub = new DataTable();
                dtSub = sobj.SelMastersubGroup(Convert.ToInt32(hid_SubGroupid.Value), Session["FADbname"].ToString());
                if (dtSub.Rows.Count > 0)
                {
                    hid_GroupID.Value = dtSub.Rows[0][0].ToString();
                    txtgroupname.Text = dtSub.Rows[0][1].ToString();
                    //   hidgrptype.Value = dtSub.Rows[0][3].ToString();
                }
            }
            if (chkleger.Checked == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Check Billing customer');", true);
                txtsubgroupname.Text = "";
                return;
            }
        }

        protected void chkleger_CheckedChanged(object sender, EventArgs e)
        {
            txtsubgroupname.Visible = true;
            txtsubgroupname.Focus();
        }

    }
}