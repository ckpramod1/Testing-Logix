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

namespace logix.CRMNew
{
    public partial class Customer : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.CheckBoxList chkType;
        DataTable dt = new DataTable();
        int custid = 0;
        DataAccess.Masters.MasterCustomer objCust = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterCustomer obj_Details4Location = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterLocation location = new DataAccess.Masters.MasterLocation();
        DataAccess.CRMNew.MasterCustomerProspective obj_MasterCustomer = new DataAccess.CRMNew.MasterCustomerProspective();
        DataAccess.Masters.MasterPort port = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCountry countryobj = new DataAccess.Masters.MasterCountry();
        DataAccess.Masters.MasterBranch objadd = new DataAccess.Masters.MasterBranch();
        DataAccess.Masters.MasterEmployee employee = new DataAccess.Masters.MasterEmployee();
        DataAccess.CRMNew.CRMSalesDetails obj_CRM = new DataAccess.CRMNew.CRMSalesDetails();
        DataAccess.CRM.CRMSalesDetails objsales = new DataAccess.CRM.CRMSalesDetails();
        DataAccess.Masters.MasterEmployee objMasEmp = new DataAccess.Masters.MasterEmployee();
        bool blnerrchk = false;
        int int_location;
        string std;
        int int_customer;
        int int_port;
        int int_district;
        int int_state;
        int int_country;
        int llisd;
        int landline;
        int mblisd;
        int faxisd;
        int int_fax;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        char status;
        char type;
        DataTable dt1 = new DataTable();
        string titleceo = "", titlech = "", titleeh = "", titleih = "", titlefh = "";
        Boolean blnerr;
        int updateby;
        int createdby;
        int productid, crmid, crmkeyid;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnsave1);

            //  ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(grdKey);

            //Response.Redirect("../CRMNew/Customer.aspx?type=TS");

            if (Request.QueryString["type"] == "TS")
            {
                lnkButton.Enabled = true;
            }
            else
            {
                lnkButton.Enabled = false;
            }

            if (hf_customerid.Value != null && hf_customerid.Value != "")
            {
                String[] st = hf_customerid.Value.Split(',');
                hf_customerid.Value = st[0];
            }
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            
            //if (Session["Customer"] != null)
            //{
            //    txtcustomer.Text = Session["Customer"].ToString();
            //    hf_customerid.Value = Session["hidcustomer"].ToString();

            //    txtcustomer_TextChanged(sender, e);
            //    Session["Customer"] = null;
            //    Session["New"] = "Cus";

            //}

            Session["portid"] = "0";
            if (!IsPostBack)
            {
                Ctrl_List = txtcustomer.ID + "~" + ddlCType.ID + "~" + txtdoor.ID + "~" + txtstreet.ID + "~" + txtcity.ID + "~" + txtpincode.ID; //prabha //////+"~" + txtSalePerson.ID;
                Msg_List = "Customer~Customer Type~Door~Street~City~Pincode~SalesPerson";
                Dtype_List = "string~string";
                btnSave.Attributes.Add("onclick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");

                LoadDDL();
                gettitle();
                btnView.Enabled = false;

                Session["dt_List"] = null;

                //Convert.ToInt32(Session["LoginEmpId"]);
                DataTable Dtemp = new DataTable();
                if (Convert.ToString(Session["LoginEmpId"]) != null)
                {
                    Dtemp = objMasEmp.Get_Salespersonname(Convert.ToInt32(Session["LoginEmpId"]));
                    if (Dtemp.Rows.Count > 0)
                    {
                        txtEmpname.Text = Dtemp.Rows[0]["empname"].ToString().ToUpper();
                        hid_Empname.Value = Dtemp.Rows[0]["employeeid"].ToString();
                    }
                }
                //keypersonenable();
                //lnkButton.Enabled = false;
                //if (Session["CustomerName"] != null)
                //{
                //    txtcustomer.Text = Session["CustomerName"].ToString();
                //    hf_customerid.Value = Session["Customerid"].ToString();
                //    txtcustomer_TextChanged(sender, e);
                //}
            }
            else if (Page.IsPostBack)
            {
                //txtComm
                // txtlocation_TextChanged1(sender, e);
                // txtpin_TextChanged(sender, e);
                WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                //int indx = wcICausedPostBack.TabIndex;
                //var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                //           where control.TabIndex > indx
                //           select control;
                //ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
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
        public static List<string> Getpincodelotaion(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterLocation location = new DataAccess.Masters.MasterLocation();
            dt = location.GetPincodeDetailsForLocation(prefix);
            list_result = Utility.Fn_TableToList(dt, "Location", "locationid");
            return list_result;
        }

        //prabha
        [WebMethod]
        public static List<string> GetLikeCargo(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCargo FA = new DataAccess.Masters.MasterCargo();
            dt = FA.GetLikeCargo(prefix);
            list_result = Utility.Fn_TableToList(dt, "cargotype", "cargoid");
            return list_result;
        }
        [WebMethod]
        public static List<string> Getptc(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.CRM.CRMSalesDetails obj_CRM = new DataAccess.CRM.CRMSalesDetails();
            DataTable dt_Location = new DataTable();
            dt_Location = obj_CRM.GetKeyPersonName(prefix);
            // List_Result = Utility.Fn_TableToList(dt_Location, "currency");
            List_Result = Utility.Fn_TableToList(dt_Location, "ptc", "ptc");
            return List_Result;
        }


        [WebMethod]
        public static List<string> GetPortName(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            dt = obj_MasterPort.GetPortNameDetails(prefix);
            // list_result = Fn_TableToList(prefix.ToUpper(), dt, "countryname");
            // list_result = obj_MasterDistrict.GetCountryName(prefix);
            list_result = Utility.Fn_TableToList(dt, "portname", "portid");
            return list_result;
        }
        //protected void Submit(object sender, EventArgs e)
        //{
        //    string customerNames = Request.Form[txtComm.UniqueID];
        //    string customerIds = Request.Form[hfComm.UniqueID];
        //}
        [WebMethod]
        public static List<string> GetLocation(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
            DataAccess.CRMNew.MasterCustomerProspective obj_MasterCustomer = new DataAccess.CRMNew.MasterCustomerProspective();
            DataTable dt_Location = new DataTable();
            int port;

            if (HttpContext.Current.Session["portid"].ToString() != "0")
            {
                port = Convert.ToInt32(HttpContext.Current.Session["portid"].ToString());
                dt_Location = obj_MasterCustomer.SPSelLikeLocationWithCity(prefix, Convert.ToInt32(HttpContext.Current.Session["portid"].ToString()));
            }
            else
            {
                dt_Location = objp_location.GetlocationnameNEWLocation(prefix);

            }
            List_Result = Utility.Fn_TableToList(dt_Location, "Location", "LocationId");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.CRMNew.MasterCustomerProspective obj_MasterCustomer = new DataAccess.CRMNew.MasterCustomerProspective();
            dt = obj_MasterCustomer.GetCustomerName(prefix);
            list_result = Utility.Fn_DatatableToList_int16Display(dt, "customer", "customerid", "customername");
            return list_result;
        }

        [WebMethod]
        public static List<string> GetPincode(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
            obj_dt = objp_location.GetlocationnameNEWpincode(prefix);
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "pinCode");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetSalesPerson(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterEmployee obj_branchmgr = new DataAccess.Masters.MasterEmployee();
            DataTable dt_Bgr = new DataTable();
            dt_Bgr = obj_branchmgr.GetLikeEmployee(prefix.Trim());
            List_Result = Utility.Fn_DatatableToList_int16Display(dt_Bgr, "empnamecode", "employeeid", "empname");
            return List_Result;
        }


        [WebMethod]
        public static List<string> Getcargo(string prefix)
        {
            List<string> cargotype = new List<string>();
            DataTable obj_dt1 = new DataTable();
            DataAccess.Masters.MasterCargo da_obj_cargoobj = new DataAccess.Masters.MasterCargo();
            obj_dt1 = da_obj_cargoobj.GetLikeCargo(prefix);
            cargotype = Utility.Fn_DatatableToList(obj_dt1, "cargotype", "cargoid");
            return cargotype;
        }
        [WebMethod]
        public static List<string> Getponame1(string prefix)
        {
            List<string> portname = new List<string>();
            DataTable obj_dtl = new DataTable();
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            DataAccess.Masters.MasterCharges da_obj_chargeobj = new DataAccess.Masters.MasterCharges();
            obj_dtl = da_obj_portobj.GetLikePort(prefix);
            portname = Utility.Fn_DatatableToList(obj_dtl, "portname", "portid");
            return portname;
        }

        [WebMethod]
        public static List<string> GetEmpname(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterEmployee obj_branchmgr = new DataAccess.Masters.MasterEmployee();
            DataTable dt_Bgr = new DataTable();
           // dt_Bgr = obj_branchmgr.GetLikeEmployee4CRM(prefix.Trim());
            dt_Bgr = obj_branchmgr.GetLikeEmployee4CRMCorn(prefix.Trim());
            List_Result = Utility.Fn_DatatableToList(dt_Bgr, "empname", "employeeid");
            return List_Result;
        }


        [WebMethod]
        public static List<string> GetEmpnameCorn(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterEmployee obj_branchmgr = new DataAccess.Masters.MasterEmployee();
            DataTable dt_Bgr = new DataTable();
            dt_Bgr = obj_branchmgr.GetLikeEmployee4CRMCorn(prefix.Trim());
            List_Result = Utility.Fn_DatatableToList(dt_Bgr, "empname", "employeeid");
            return List_Result;
        }
        protected void txtcustomer_TextChanged(object sender, EventArgs e)
        {
            if (txtcustomer.Text != "" && hf_customerid.Value != "")
            {                
                getdetails();
                //lnkButton.Enabled = true;
            }
            else
            {
                //keypersondisable();
            }
        }


        //private void keypersonenable()
        //{
        //    lnkKeyPerson.Enabled = true;
        //    ddlTitle.Enabled = true;
        //    txtName.Enabled = true;
        //    txtDesingnation.Enabled = true;
        //    txtDepartment.Enabled = true;
        //    txt_Mobile.Enabled = true;
        //    txt_Landline.Enabled = true;
        //    txt_email.Enabled = true;
        //    btnKSave.Enabled = true;
        //    lnkButton.Enabled = true;
        //}

        //private void keypersondisable()
        //{
        //    lnkKeyPerson.Enabled = false;
        //    ddlTitle.Enabled = false;
        //    txtName.Enabled = false;
        //    txtDesingnation.Enabled = false;
        //    txtDepartment.Enabled = false;
        //    txt_Mobile.Enabled = false;
        //    txt_Landline.Enabled = false;
        //    txt_email.Enabled = false;
        //    btnKSave.Enabled = false;
        //    lnkButton.Enabled = false;
        //}

        private void getdetails()
        {
            string resource = "";
            string resource1 = "";
            dt = obj_MasterCustomer.SPSelGetCustomerDetails(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
            if (dt.Rows.Count > 0)
            {
                resource1 = dt.Rows[0]["officetype"].ToString();
                if (resource1 == "" || resource1 == "0" || resource1 == null)
                {
                    ddlCType.SelectedValue = "0";
                }
                else
                {
                    if (resource1 == "1")
                    {
                        ddlCType.SelectedValue = "1";
                    }
                    else if (resource1 == "2")
                    {
                        ddlCType.SelectedValue = "2";
                    }
                    else if (resource1 == "3")
                    {
                        ddlCType.SelectedValue = "3";
                    }
                    else if (resource1 == "4")
                    {
                        ddlCType.SelectedValue = "4";
                    }
                    else if (resource1 == "5")
                    {
                        ddlCType.SelectedValue = "5";
                    }
                    else if (resource1 == "6")
                    {
                        ddlCType.SelectedValue = "6";
                    }
                }


                //  ddlCType.SelectedIndex = Convert.ToInt32(dt.Rows[0]["officetype"].ToString());
                hf_customerid.Value = dt.Rows[0]["customerid"].ToString();
                txtstreet.Text = dt.Rows[0]["street"].ToString();
                hf_portid.Value = dt.Rows[0]["cityid"].ToString();
                Session["portid"] = hf_portid.Value;
                txtcity.Text = port.GetPortname(Convert.ToInt32(hf_portid.Value));
                hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(txtcity.Text));
                txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                txtpincode.Text = dt.Rows[0]["pincode"].ToString();
                txtlandline.Text = dt.Rows[0]["landline"].ToString();
                txtfax.Text = dt.Rows[0]["fax"].ToString();
                txtemail.Text = dt.Rows[0]["email"].ToString();
                txtpanno.Text = dt.Rows[0]["panno"].ToString();
                txtstno.Text = dt.Rows[0]["stno"].ToString();

                if (string.IsNullOrEmpty(dt.Rows[0]["salescordid"].ToString()) != true)
                {


                    hid_salesCordin.Value = dt.Rows[0]["salescordid"].ToString().ToUpper();
                    txt_salescordin.Text = employee.GetEmployeeName(Convert.ToInt32(hid_salesCordin.Value));
                    if (txt_salescordin.Text == "0")
                    {
                        txt_salescordin.Text = "";
                    }
                }
                else
                {
                    txt_salescordin.Text = "";
                    hid_salesCordin.Value = "";
                }
                /***********************************************/
                txtunit.Text = dt.Rows[0]["unit#"].ToString();
                txtBuilding.Text = dt.Rows[0]["buildingname"].ToString();
                txtdoor.Text = dt.Rows[0]["door#"].ToString();
                hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                txtllisd.Text = dt.Rows[0]["llisd"].ToString();
                txtllstd.Text = dt.Rows[0]["llstd"].ToString();
                // txtlandline.Text = dt.Rows[0]["landline"].ToString();
                txtfaxisd.Text = dt.Rows[0]["faxisd"].ToString();
                txtfaxstd.Text = dt.Rows[0]["faxstd"].ToString();
                txtfax.Text = dt.Rows[0]["fax"].ToString();
                txtmblisd.Text = dt.Rows[0]["mblisd"].ToString();
                txtmobile.Text = dt.Rows[0]["mobile"].ToString();
                txtwebsite.Text = dt.Rows[0]["website"].ToString();
                status = Convert.ToChar(dt.Rows[0]["status"].ToString());
                txtGrade.Text = dt.Rows[0]["grade"].ToString();
                txtRemarks.Text = dt.Rows[0]["remarks"].ToString();
                //resource = dt.Rows[0]["Resourceid"].ToString();
                //if (resource == "" || resource == "0" || resource == null)
                //{
                //    ddResourceName.SelectedValue = "0";
                //}
                //else
                //{
                //    if (resource == "1")
                //    {
                //        ddResourceName.SelectedValue = "1";
                //    }
                //    else if (resource == "2")
                //    {
                //        ddResourceName.SelectedValue = "2";
                //    }
                //    else if (resource == "3")
                //    {
                //        ddResourceName.SelectedValue = "3";
                //    }
                //    else if (resource == "4")
                //    {
                //        ddResourceName.SelectedValue = "4";
                //    }
                //}
                //prabha
                /////  txtSalePerson.Text = dt.Rows[0]["empname"].ToString();
                if (hf_districtid.Value != "")
                {
                    txtdistrict.Text = obj_MasterCustomer.GetStateDistrictname(Convert.ToInt32(hf_districtid.Value));


                }
                if (hf_stateid.Value != "")
                {
                    txtstate.Text = obj_MasterCustomer.GetStatename(Convert.ToInt32(hf_stateid.Value));

                }

                //prabha
                ////////ddl_ceo.SelectedValue = dt.Rows[0]["titleceo"].ToString();
                ////////ddl_ch.SelectedValue = dt.Rows[0]["titlech"].ToString();
                ////////ddl_eh.SelectedValue = dt.Rows[0]["titleeh"].ToString();
                ////////ddl_ih.SelectedValue = dt.Rows[0]["titleih"].ToString();
                ////////ddl_fh.SelectedValue = dt.Rows[0]["titlefh"].ToString();

                ////////txtmailcom.Text = dt.Rows[0]["commailid"].ToString();
                ////////txtmailimp.Text = dt.Rows[0]["impmailid"].ToString();
                ////////txtmailexport.Text = dt.Rows[0]["expmailid"].ToString();
                ////////txtmailfin.Text = dt.Rows[0]["finmailid"].ToString();
                ////////txtmailmanag.Text = dt.Rows[0]["managmail"].ToString();

                ////////txtmanagptc.Text = dt.Rows[0]["managptc"].ToString();
                ////////txtcomptc.Text = dt.Rows[0]["comptc"].ToString();
                ////////txtexpptc.Text = dt.Rows[0]["expptc"].ToString();
                ////////txtimpptc.Text = dt.Rows[0]["impptc"].ToString();
                ////////txtfinptc.Text = dt.Rows[0]["finptc"].ToString();
                /***********************************************/

                hf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                hid_Empname.Value = dt.Rows[0]["telecallerid"].ToString();
                if (hid_Empname.Value != "0" || hid_Empname.Value != "")
                {
                    txtEmpname.Text = employee.GetEmployeeName(Convert.ToInt32(hid_Empname.Value));
                    if (txtEmpname.Text == "0")
                    {
                        txtEmpname.Text = "";
                    }
                }
                else
                {
                    txtEmpname.Text = "";
                }
                if (hf_locationid.Value != "" && hf_locationid.Value != "0")
                {
                    txtlocation.Text = obj_MasterCustomer.GetLocationname(Convert.ToInt32(hf_locationid.Value));
                    ddllocation.Visible = false;

                }
                else
                {
                    if (txtpincode.Text == "")
                    {
                        txtpincode.Focus();
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
                            //txtlocation.Visible = false;
                            //ddllocation.Visible = true;
                            //ddllocation.DataSource = dt;
                            //ddllocation.DataTextField = "Location";
                            //ddllocation.DataBind();
                            ddllocation.Visible = true;
                            txtlocation.Visible = false;
                            ddllocation.Items.Clear();
                            ddllocation.Items.Add("Location");

                            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                ddllocation.Items.Add(dt.Rows[i]["Location"].ToString());
                            }
                        }
                        else if (dt.Rows.Count == 1)
                        {
                            txtlocation.Visible = true;
                            ddllocation.Visible = false;
                            txtlocation.Text = dt.Rows[0]["Location"].ToString();
                        }
                    }
                }
                btnSave.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                //btnCancel.Text = "Cancel";
                btnCancel.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                if (txtcountry.Text.ToUpper() != "INDIA")
                {
                    txtlocation.ReadOnly = true;
                    txtdistrict.ReadOnly = true;
                    txtstate.ReadOnly = true;
                    txtcountry.ReadOnly = true;
                }
                // ddlCType.Enabled = false;
            }

            DataTable dtt = new DataTable();
            dtt = obj_MasterCustomer.GetCommodity(Convert.ToInt32(hf_customerid.Value));
            if (dtt.Rows.Count > 0)
            {
                txtComm.Text = dtt.Rows[0]["cargotype"].ToString();
                hfComm.Value = dtt.Rows[0]["commodityid"].ToString();
            }

            DataTable dtcntry = new DataTable();
            dtcntry = obj_MasterCustomer.GetProspectCountry(Convert.ToInt32(hf_customerid.Value));
            if (dtcntry.Rows.Count > 0)
            {
                txtCntry.Text = dtcntry.Rows[0]["countryname"].ToString();
                hfCountry.Value = dtcntry.Rows[0]["countryid"].ToString();
            }

            DataTable dtproduct = new DataTable();
            dtproduct = obj_CRM.SPSElProduct(0, Convert.ToUInt16(hf_customerid.Value));
            if (dtproduct.Rows.Count > 0)
            {
                for (int i = 0; i <= dtproduct.Rows.Count - 1; i++)
                {
                    if (dtproduct.Rows[i]["productid"].ToString() == "1")
                    {
                        chkproducts.Items[1].Selected = true;
                    }
                    else if (dtproduct.Rows[i]["productid"].ToString() == "2")
                    {
                        chkproducts.Items[2].Selected = true;
                    }
                    else if (dtproduct.Rows[i]["productid"].ToString() == "3")
                    {
                        chkproducts.Items[3].Selected = true;
                    }
                    else if (dtproduct.Rows[i]["productid"].ToString() == "4")
                    {
                        chkproducts.Items[4].Selected = true;
                    }
                    else if (dtproduct.Rows[i]["productid"].ToString() == "5")
                    {
                        chkproducts.Items[5].Selected = true;
                    }
                    else if (dtproduct.Rows[i]["productid"].ToString() == "6")
                    {
                        chkproducts.Items[6].Selected = true;
                    }
                    else if (dtproduct.Rows[i]["productid"].ToString() == "7")
                    {
                        chkproducts.Items[7].Selected = true;
                    }
                    else if (dtproduct.Rows[i]["productid"].ToString() == "8")
                    {
                        chkproducts.Items[8].Selected = true;
                    }
                }

                string name = "";
                for (int i = 0; i < chkproducts.Items.Count; i++)
                {
                    if (chkproducts.Items[i].Text != "Select All")
                    {
                        if (chkproducts.Items[i].Selected)
                        {
                            name += chkproducts.Items[i].Text + ",";
                        }
                    }
                }
                txtProducts.Text = name;
            }
            fillgrdkey();
        }

        protected void txtlocation_TextChanged(object sender, EventArgs e)
        {
            DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
            dt = objp_location.CheckDuplicateForLocationPincode(txtlocation.Text, txtpincode.Text);
            hf_locationid.Value = "0";
            if (dt.Rows.Count > 0)
            {
                hf_locationid.Value = dt.Rows[0]["locationid"].ToString();
            }

            if (hf_locationid.Value != "" && hf_locationid.Value != "0")
            {
               
                getlocationdetails();

                if (blnerr == true)
                {
                    return;
                }
            }
        }
        private void getlocationdetails()
        {
            int locationid = Convert.ToInt32(hf_locationid.Value.ToString());
            DataTable dt1 = new DataTable();
            dt1 = obj_Details4Location.GetLocationDetailsIntNEw(Convert.ToInt32(hf_locationid.Value));
            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows[0]["cityport"].ToString() == "")
                {

                    txtcity.Enabled = true;
                    txtcity.Text = "";
                    hf_portid.Value = "";
                    hf_districtid.Value = dt1.Rows[0]["districtid"].ToString();
                    hf_stateid.Value = dt1.Rows[0]["stateid"].ToString();
                    txtdistrict.Text = obj_MasterCustomer.GetStateDistrictname(Convert.ToInt32(hf_districtid.Value));
                    txtstate.Text = obj_MasterCustomer.GetStatename(Convert.ToInt32(hf_stateid.Value));
                    hf_stateid.Value = dt1.Rows[0]["stateid"].ToString();
                    txtcountry.Text = dt1.Rows[0]["CountryName"].ToString();
                    hf_countryid.Value = dt1.Rows[0]["Countryid"].ToString();
                    txtpincode.Text = dt1.Rows[0]["pincode"].ToString();
                    txtllisd.Text = dt1.Rows[0]["ISDcode"].ToString();
                    txtmblisd.Text = dt1.Rows[0]["ISDcode"].ToString();
                    txtfaxisd.Text = dt1.Rows[0]["ISDcode"].ToString();
                }
                else if (dt1.Rows[0]["cityport"].ToString() != "")
                {
                    hf_portid.Value = dt1.Rows[0]["cityport"].ToString();
                    dt = obj_Details4Location.GETDetails4LocationIntNewPort(Convert.ToInt32(hf_locationid.Value), Convert.ToInt32(hf_portid.Value));
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

                    txtdistrict.Text = obj_MasterCustomer.GetStateDistrictname(Convert.ToInt32(hf_districtid.Value));
                    txtstate.Text = obj_MasterCustomer.GetStatename(Convert.ToInt32(hf_stateid.Value));
                    if (txtllisd.Text != "")
                    {
                        txtpanno.Focus();
                    }
                    else
                    {
                        txtpanno.Focus();
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Invalid Location');", true);
                txtlocation.Text = "";
                blnerr = true;
                return;
            }
            //btnCancel.Text = "Cancel";
            btnCancel.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtpincode_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = location.GetPincodeDetailsForLocation(txtpincode.Text);
            if (dt.Rows.Count > 0)
            {
                txtlocation.Visible = false;
                ddllocation.Visible = true;
                //int i;
                //ddllocation.Items.Add("Select Location");
                //for (i = 0; i <= dt.Rows.Count - 1;i++ )
                //{
                //    ddllocation.DataSource = dt;
                //    ddllocation.DataTextField = "Location";
                //    ddllocation.DataBind();
                //}
                ddllocation.Items.Clear();
                ddllocation.Items.Add("");
                ddllocation.Items.Add("Location");

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    ddllocation.Items.Add(dt.Rows[i]["Location"].ToString());
                }
            }
            else if (dt.Rows.Count == 1)
            {
                txtlocation.Visible = true;
                ddllocation.Visible = false;
                txtlocation.Text = dt.Rows[0]["Location"].ToString();
            }
            else
            {
                if (dt.Rows.Count == 0)
                {
                    ddllocation.Items.Clear();
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Invalid Pincode');", true);
                    txtpincode.Text = "";                    
                    return;
                }
            }
        }

        protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void txtcity_TextChanged(object sender, EventArgs e)
        {

            if (txtcity.Text != "CITY")
            {
                //hf_portid.Value = Convert.ToString( port.GetNPortid(txtcity.Text));
                hf_portid.Value = Convert.ToString(port.GetNPortid(txtcity.Text));
                if (hf_portid.Value != "")
                {
                    Session["portid"] = hf_portid.Value;
                }
                else if (hf_portid.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Invalid City');", true);
                    txtcity.Text = "";
                    txtcity.Focus();
                    return;
                }
                hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(txtcity.Text));
                txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                if (hf_countryid.Value != "1102" && hf_countryid.Value != "102")
                {
                    txtdistrict.ReadOnly = true;
                    txtstate.ReadOnly = true;
                    txtcountry.ReadOnly = true;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["dt_List"] = null;
            if (Session["New"] != null)
            {
                clear();
                Session["Telesales"] = 1;
                Session["New"] = null;
                Response.Redirect("../CRM/TeleSales.aspx");

            }

            if (btnCancel.ToolTip == "Back")
            {
                this.Response.End();
            }
            else
            {
                clear();
                LoadDDL();
                ClearKeyPerson();
                //btnCancel.Text = "Back";
                DataTable Dtemp = new DataTable();
                if (Convert.ToString(Session["LoginEmpId"]) != null)
                {
                    Dtemp = objMasEmp.Get_Salespersonname(Convert.ToInt32(Session["LoginEmpId"]));
                    if (Dtemp.Rows.Count > 0)
                    {
                        txtEmpname.Text = Dtemp.Rows[0]["empname"].ToString().ToUpper();
                        hid_Empname.Value = Dtemp.Rows[0]["employeeid"].ToString();
                    }
                }
                btnCancel.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
                btnKSave.ToolTip = "Add";
                btn_add1.Attributes["class"] = "btn btn-add1";
                grdKey.Visible = false;
            }
        }
        private void clear()
        {
            hid_salesCordin.Value = "";
            txt_salescordin.Text = "";
            txtEmpname.Text = "";
            txtcustomer.Text = "";
            //ddlCType.SelectedValue = "Select Customer Type";
            txtunit.Text = "";
            txtBuilding.Text = "";
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
            txtmobile.Text = "";
            txtfaxisd.Text = "";
            txtfaxstd.Text = "";
            txtfax.Text = "";
            txtemail.Text = "";
            hf_customerid.Value = "";
            txtpanno.Text = "";
            txtstno.Text = "";
            // btnSave.ToolTip = "Save";
            btnSave.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
          //  ddResourceName.SelectedValue = "0";
            //prabha
            ////////txtmailcom .Text = "";
            ////////txtcomptc .Text = "";
            ////////txtmailexport .Text = "";
            ////////txtexpptc .Text = "";
            ////////txtmailimp .Text = "";
            ////////txtimpptc .Text = "";
            ////////txtfinptc .Text = "";
            ////////txtmailfin .Text = "";
            //rdbExisting.Checked = false;
            //rdbFollowUp.Checked = false;
            //rdbNewCustomer.Checked = false;
            //prabha
            ////////txtmailmanag.Text = "";
            ////////txtmanagptc.Text="";
            // txttds.Text = "";
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
            hdnSalesid.Value = "";
            txtProducts.Text = "";
            txtComm.Text = "";
            txtCntry.Text = "";
            txtwebsite.Text = "";
            ddlCType.SelectedIndex = -1;
            txtProducts.Text = "Product Details";
            txtRemarks.Text = "";
            txtGrade.Text = "";
            for (int i = 0; i < chkproducts.Items.Count; i++)
            {
                chkproducts.Items[0].Selected = false;
            }
            //prabha
            ////////////txtSalePerson.Text = "";
        }

        //protected void rdbNewCustomer_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdbNewCustomer.Checked==true)
        //    {
        //        rdbFollowUp.Checked = false;
        //        rdbExisting.Checked = false; 
        //    }
        //}

        //protected void rdbFollowUp_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdbFollowUp.Checked == true)
        //    {
        //        rdbNewCustomer.Checked = false;
        //        rdbExisting.Checked = false;
        //    }

        //}

        //protected void rdbExisting_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdbExisting.Checked == true)
        //    {
        //        rdbFollowUp.Checked = false;
        //       rdbNewCustomer.Checked = false;
        //    }

        //}
        private void LoadDDL()
        {
            //ddlCType.Items.Clear();
            //ddlCType.Items.Add("Customer Type");
            //ddlCType.Items.Add("CHA / CNF");
            //ddlCType.Items.Add("Consignee");
            //ddlCType.Items.Add("Notify Party");
            //ddlCType.Items.Add("Others");
            //ddlCType.Items.Add("Shipper");
            //ddlCType.Items.Add("Freight Forwarder");



            //ddlCType.Items.Clear();
            //ddlCType.Items.Insert(0, "Select");
            //ddlCType.Items.Insert(1, "Register Office");
            //ddlCType.Items.Insert(2, "Head Office");
            //ddlCType.Items.Insert(3, "Corporate Office");
            //ddlCType.Items.Insert(4, "Regional Office");
            //ddlCType.Items.Insert(5, "Branch Office");
            //ddlCType.Items.Insert(6, "Factory");
        }

        protected void txtemail_TextChanged(object sender, EventArgs e)
        {
            if (hf_customerid.Value == "")
            {
                return;
            }

            if (IsValidEmailId(txt_email.Text))
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Invalid Email ID');", true);
                txtemail.Text = "";
                txtemail.Focus();
            }

        }

        //prabha
        ////////protected void txtmailmanag_TextChanged(object sender, EventArgs e)
        ////////{
        ////////    if (IsValidEmailId(txtmailmanag.Text))
        ////////    {
        ////////    }
        ////////    else
        ////////    {
        ////////        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Invalid Email ID');", true);
        ////////        txtmailmanag.Text = "";
        ////////        txtmailmanag.Focus();
        ////////    } 
        ////////}

        ////////protected void txtmailcom_TextChanged(object sender, EventArgs e)
        ////////{
        ////////    if (IsValidEmailId(txtmailcom.Text))
        ////////    {
        ////////    }
        ////////    else
        ////////    {
        ////////        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Invalid Email ID');", true);
        ////////        txtmailcom.Text = "";
        ////////        txtmailcom.Focus();
        ////////    } 
        ////////}

        ////////protected void txtmailexport_TextChanged(object sender, EventArgs e)
        ////////{
        ////////    if (IsValidEmailId(txtmailexport.Text))
        ////////    {
        ////////    }
        ////////    else
        ////////    {
        ////////        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Invalid Email ID');", true);
        ////////        txtmailexport.Text = "";
        ////////        txtmailexport.Focus();
        ////////    } 
        ////////}

        ////////protected void txtmailimp_TextChanged(object sender, EventArgs e)
        ////////{
        ////////    if (IsValidEmailId(txtmailimp.Text))
        ////////    {
        ////////    }
        ////////    else
        ////////    {
        ////////        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Invalid Email ID');", true);
        ////////        txtmailimp.Text = "";
        ////////        txtmailimp.Focus();
        ////////    } 
        ////////}

        ////////protected void txtmailfin_TextChanged(object sender, EventArgs e)
        ////////{
        ////////    if (IsValidEmailId(txtmailfin.Text))
        ////////    {
        ////////    }
        ////////    else
        ////////    {
        ////////        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Invalid Email ID');", true);
        ////////        txtmailfin.Text = "";
        ////////        txtmailfin.Focus();
        ////////    } 
        ////////}
        private bool IsValidEmailId(string InputEmail)
        {
            //Regex To validate Email Address
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(InputEmail);
            if (match.Success)
                return true;
            else
                return false;
        }

        protected void txtllisd_TextChanged(object sender, EventArgs e)
        {
            if (txtllisd.Text != "ISD")
            {
                txtfaxisd.Text = txtllisd.Text;
                txtmblisd.Text = txtllisd.Text;
                txtfaxisd.ReadOnly = true;
                txtmblisd.ReadOnly = true;
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //string countryIds = Request.Form[hfCountry.UniqueID];
            //checkData();
            string website = "";
            website = txtwebsite.Text;
            if (ddlCType.SelectedItem.Text == "Select")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Prospect Customer", "alertify.alert('Select Office Type');", true);
                ddlCType.Focus();
                return;
            }

            if (ddllocation.Visible == true)
            {
                if (ddllocation.SelectedItem != null)
                {
                    if (ddllocation.SelectedItem.Text == "Location" || ddllocation.SelectedItem.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Prospect Customer", "alertify.alert('Select Location');", true);
                        ddllocation.Focus();
                        return;
                    }
                }
            }

            if (ddllocation.Visible == false)
            {
                if (txtlocation.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Prospect Customer", "alertify.alert('Select Location');", true);
                    txtlocation.Focus();
                    return;
                }
            }


            if (txtEmpname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Sales Person Name cannot be blank');", true);
                txtEmpname.Focus();
                txtEmpname.Text = "";
                return;

            }
            else
            {
                if (hid_Empname.Value == "" || hid_Empname.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Invalid Sales Person Name');", true);
                    txtEmpname.Focus();
                    txtEmpname.Text = "";
                    return;
                }
                else
                {
                    txt_salescordin.Focus();
                }
            }
            
               
                

            if (ddllocation.Visible == true)
            {
                ddllocation_SelectedIndexChanged(sender, e);
            }
            else if (txtlocation.Visible == true)
            {
                txtlocation_TextChanged(sender, e);
                if(blnerr==true)
                {
                    return;
                }
            }
            if (hf_locationid.Value == "")
            {
                int_location = 0;
            }
            else
            {
                int_location = Convert.ToInt32(hf_locationid.Value);
            }
            std = txtllstd.Text;

            if (hf_portid.Value == "")
            {
                int_port = 0;
            }
            else
            {
                int_port = Convert.ToInt32(hf_portid.Value.ToString());
            }

            if (hf_districtid.Value == "")
            {
                int_district = 0;
            }
            else
            {
                int_district = Convert.ToInt32(hf_districtid.Value.ToString());
            }

            int_state = Convert.ToInt32(hf_stateid.Value.ToString());
            int_country = Convert.ToInt32(hf_countryid.Value.ToString());
            if (txtllisd.Text != "")
            {
                llisd = Convert.ToInt32(txtllisd.Text.ToString());
                mblisd = Convert.ToInt32(txtmblisd.Text.ToString());
                faxisd = Convert.ToInt32(txtfaxisd.Text.ToString());
            }
            else
            {
                llisd = 0;
                mblisd = 0;
                faxisd = 0;
            }

            //prabha
            ///////gettitle();

            if (hdnSalesid.Value == "")
            {
                //prabha
                ///////hdnSalesid.Value = employee.GetNEmpid(txtSalePerson.Text).ToString();
                hdnSalesid.Value = "0";
            }
            //if (ddResourceName.SelectedValue == "0" || ddResourceName.SelectedValue == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Prospect Customer", "alertify.alert('Select Resourcename');", true);
            //    ddResourceName.Focus();
            //    return;
            //}

            updateby = Convert.ToInt32(Session["LoginEmpId"]);


            // createdby = Convert.ToInt32(hdnSalesid.Value);


            createdby = Convert.ToInt32(Session["LoginEmpId"]);
            string customerIds = "0";
            if (hfComm.UniqueID != "")
            {
                customerIds = Request.Form[hfComm.UniqueID];
            }
            //DataTable Dt = new DataTable();
            //Dt = objMasEmp.GetEmployeeID(txtEmpname.Text.ToUpper());
            //if (Dt.Rows.Count > 0)
            //{
            //    hid_Empname.Value = Dt.Rows[0]["employeeid"].ToString();
            //}
            //else
            //{

            //}

            if (hid_salesCordin.Value == "")
            {
                hid_salesCordin.Value = "0";
            }
            else
            {

            }

            if (hid_Empname.Value == "")
            {
                hid_Empname.Value = "0";
            }
            if (btnSave.ToolTip == "Save")
            {
                int commid = 0;
                int cntryid = 0;
                // refno
                int offcetyp = Convert.ToInt32(ddlCType.SelectedIndex.ToString());
                int_customer = obj_MasterCustomer.InsMasterCustomer(txtcustomer.Text.ToUpper(), "C", txtunit.Text, txtBuilding.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, txtlandline.Text, mblisd, txtmobile.Text, faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text, txtpanno.Text, txtstno.Text, 'N', "", "", "", "", "", "", "", "", "", "", createdby, titleceo, titlech, titleeh, titleih, titlefh, updateby, offcetyp, website, txtGrade.Text, txtRemarks.Text, Convert.ToInt32(Session["LoginDivisionId"]), 0, Convert.ToInt32(hid_salesCordin.Value)); //,offcetyp
                hf_customerid.Value = int_customer.ToString();
                obj_MasterCustomer.UPdateTeleCallDetails(Convert.ToInt32(hf_customerid.Value), Convert.ToInt32(hid_Empname.Value));
                string cusIds = txtComm.Text;
                string countryIds = txtCntry.Text;
                if (customerIds != "")
                {

                    // txtComm.Text
                    foreach (string ids in customerIds.Split(',', '~'))
                    {
                        //    obj_MasterCustomer.Insprospectcommodity(int_customer, Convert.ToInt32(ids));
                        commid = obj_MasterCustomer.GETCommodityid(ids.TrimStart().TrimEnd());
                        if (commid != 0)
                        {
                            obj_MasterCustomer.Insprospectcommodity(int_customer, commid);
                        }
                    }
                }
                else
                {
                    foreach (string ids in cusIds.Split(',', '~'))
                    {
                        commid = obj_MasterCustomer.GETCommodityid(ids.TrimStart().TrimEnd());
                        if (commid != 0)
                        {
                            obj_MasterCustomer.Insprospectcommodity(int_customer, commid);
                        }
                    }
                }

                if (countryIds != "")
                {
                    foreach (string ids in countryIds.Split(','))
                    {
                        cntryid = countryobj.GetLikeCountryNAme(ids.TrimStart().TrimEnd());
                        if (cntryid != 0)
                        {
                            obj_MasterCustomer.Insprospectcountry(int_customer, cntryid);
                        }
                    }
                }

                checkDetails();
                DataTable dt_list = (DataTable)Session["dt_List"];
                if (Session["dt_List"] == null)
                {
                    // ScriptManager.RegisterStartupScript(btnKSave, typeof(Button), "DataFound", "alertify.alert('Index Value Null');", true);
                }
                else
                {
                    //for (int kk = 0; kk < dt_list.Rows.Count; kk++)
                    //{
                    //    objp.InsertMasterIndexValues(int_customerid, int_deptid, int_docid, int_cindexid, dt_list.Rows[kk][0].ToString());
                    //}
                    //ptcc, desig,dept,mobile,phone,email,title,ptc,crmkeyid,crmid
                    for (int kk = 0; kk < dt_list.Rows.Count; kk++)
                    {
                        obj_CRM.InsPCustomerContactDetails(int_customer, dt_list.Rows[kk]["title"].ToString(), dt_list.Rows[kk]["ptcc"].ToString().ToUpper(), dt_list.Rows[kk]["desig"].ToString().ToUpper(), dt_list.Rows[kk]["dept"].ToString().ToUpper(), dt_list.Rows[kk]["phone"].ToString(), dt_list.Rows[kk]["mobile"].ToString(), dt_list.Rows[kk]["email"].ToString().ToUpper(), 0);
                        // ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "KeyPerson", "alertify.alert('Key Person Details Saved..');", true);
                    }
                }
                Session["dt_List"] = null;
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Prospect Customer", "alertify.alert('Customer Details Saved');", true);
                clear();
            }
            else
            {
                obj_MasterCustomer.UpdMasterCustomer(txtcustomer.Text.ToUpper(), "C", txtunit.Text, txtBuilding.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country, txtpincode.Text, llisd, txtllstd.Text, txtlandline.Text, mblisd, txtmobile.Text, faxisd, txtfaxstd.Text, txtfax.Text, txtemail.Text, txtpanno.Text, txtstno.Text, 'N', "", "", "", "", "", "", "", "", "", "", Convert.ToInt32(hf_customerid.Value), titleceo, titlech, titleeh, titleih, titlefh, updateby, createdby, Convert.ToInt32(ddlCType.SelectedIndex), website, txtGrade.Text, txtRemarks.Text, Convert.ToInt32(Session["LoginDivisionId"]), 0, Convert.ToInt32(hid_salesCordin.Value));

                string cusIds = txtComm.Text;
                string countryIds = txtCntry.Text;
                //string customerIds = hfComm.Value;
                //string ss = cusIds + customerIds;
                obj_MasterCustomer.UPdateTeleCallDetails(Convert.ToInt32(hf_customerid.Value), Convert.ToInt32(hid_Empname.Value));
                int commid = 0;
                obj_MasterCustomer.DelCommodity(Convert.ToInt32(hf_customerid.Value));
                foreach (string ids in cusIds.Split(',', '~'))
                {
                    commid = obj_MasterCustomer.GETCommodityid(ids.TrimStart().TrimEnd());
                    if (commid != 0)
                    {
                        obj_MasterCustomer.Insprospectcommodity(Convert.ToInt32(hf_customerid.Value), commid);
                    }
                }

                int cntryid = 0;
                obj_MasterCustomer.Delcountry(Convert.ToInt32(hf_customerid.Value));
                if (countryIds != "")
                {
                    foreach (string ids in countryIds.Split(',', '~'))
                    {
                        cntryid = countryobj.GetLikeCountryNAme(ids.TrimStart().TrimEnd());
                        if (cntryid != 0)
                        {
                            obj_MasterCustomer.Insprospectcountry(Convert.ToInt32(hf_customerid.Value), cntryid);
                        }
                    }
                }

                checkDetails();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Prospect Customer", "alertify.alert('Customer Details Updated');", true);
                clear();
            }
            //clear();
        }

        //prabha
        //////////private void gettitle()
        //////////{
        //////////    titleceo = ddl_ceo.SelectedValue.ToString();
        //////////    titlech = ddl_ch.SelectedValue.ToString();
        //////////    titleeh = ddl_eh.SelectedValue.ToString();
        //////////    titlefh = ddl_fh.SelectedValue.ToString();
        //////////    titleih = ddl_ih.SelectedValue.ToString();
        //////////}

        private void gettitle()
        {
            ddlTitle.Items.Clear();
            ddlTitle.Items.Add("Mr.");
            ddlTitle.Items.Add("Mrs.");
            ddlTitle.Items.Add("Ms.");
        }

        private void checkData()
        {
            if (txtcustomer.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "Prospect Customer", "alertify.alert('Enter Customer Name')", true);
                //ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "SOA", "alertify.alert('Please select the correct Container #')", true);
                txtcustomer.Focus();
                blnerr = true;
                return;
            }
            if (ddlCType.SelectedItem.Text == "Customer Type")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Prospect Customer", "alertify.alert('Select Customer Type');", true);
                ddlCType.Focus();
                blnerr = true;
                return;
            }
            if (txtdoor.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Prospect Customer", "alertify.alert('Enter Door# ');", true);
                txtdoor.Focus();
                blnerr = true;
                return;
            }
            if (txtstreet.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Prospect Customer", "alertify.alert('Enter Street');", true);
                txtstreet.Focus();
                blnerr = true;
                return;
            }
            if (txtcity.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Prospect Customer", "alertify.alert('Enter City ');", true);
                txtcity.Focus();
                blnerr = true;
                return;
            }
            if (txtlocation.Visible == true)
            {
                if (txtlocation.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Prospect Customer", "alertify.alert('Enter Location');", true);
                    txtlocation.Focus();
                    blnerr = true;
                    return;
                }
            }
            if (txtpincode.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Prospect Customer", "alertify.alert('Enter Pincode');", true);
                txtpincode.Focus();
                blnerr = true;
                return;
            }


        }

        protected void imghelpnew_Click(object sender, ImageClickEventArgs e)
        {
            //txthelpmsg.Text = Environment.NewLine + "This Screen allows the user to be update the potential customer details.Customer name,Type are mandatory,Unit# & building to updated if customer office in a commercial complex.Door # and Street name are mandatory.Space for City will suggest the city based the characters typed by the user.Pin code is must, Location details will be displayed based on the pin code, and this is applicable only for Indian Pin codes.District, State, Country, ISD & STD details  will be filled automatically once the location selected from the drop down list.Landline, fax, Mobile, eMail details to be updated.User can update multiple key contact details";
            //Session["helpmsg"] = "";
            //Session["helpmsg"] =  "This Screen allows the user to update the potential customer details.Customer name,Type are mandatory,Unit# & building to updated if customer office in a commercial complex.Door # and Street name are mandatory.Space for City will suggest the city based the characters typed by the user.Pin code is must, Location details will be displayed based on the pin code, and this is applicable only for Indian Pin codes.District, State, Country, ISD & STD details  will be filled automatically once the location selected from the drop down list.Landline, fax, Mobile, eMail details to be updated.User can update multiple key contact details";
            //string strPopup = "<script language='javascript' ID='script1'>" + "window.open('Help.aspx?" + "','new window', 'top=100, left=200, width=429, height=507, dependant=no, location=0,titlebar=0,alwaysRaised=no, menubar=no, resizeable=0, scrollbars=no, toolbar=no, status=no, center=yes')" + "</script>";
            //ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "Script1", strPopup, false);      
        }

        protected void lnkKeyPerson_Click(object sender, EventArgs e)
        {
            fillgrdkey();
        }
        private void fillgrdkey()
        {
            grdKey.Visible = true;
            if (hf_customerid.Value != "")
            {
                dt = obj_CRM.GetKeyPersonDetails4Grid(Convert.ToInt32(hf_customerid.Value), 0);
                if (dt.Rows.Count > 0)
                {
                    grdKey.DataSource = dt;
                    Session["dt_List"] = dt;
                    grdKey.DataBind();
                    //this.modelpopupkey.Show();
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "CRM Sales", "alertify.alert('Record Not Found');", true);
                    //return;
                }
            }
            else
            {
                //ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "CRM Sales", "alertify.alert('Select Customer Name');", true);
                //return;
                if (Session["dt_List"] != null && Session["dt_List"] != "")
                {
                    grdKey.DataSource = (DataTable)Session["dt_List"];
                    grdKey.DataBind();
                    //this.modelpopupkey.Show();
                }
                else
                {

                }
           
            }
        }

        private void AddValues()
        {
            DataTable dt_list = new DataTable();
            dt_list = (DataTable)Session["dt_List"];

            if (Session["dt_List"] != null && Session["dt_List"]!="")
            {                
                if (dt_list.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt_list.Rows.Count - 1; i++)
                    {
                        string kewname = "";
                        string deptname = "";
                        string desgname = "";
                        kewname = dt_list.Rows[i]["ptcc"].ToString().ToUpper();
                        desgname = dt_list.Rows[i]["desig"].ToString().ToUpper();
                        deptname = dt_list.Rows[i]["dept"].ToString().ToUpper();
                        if (txtName.Text.ToUpper() == kewname && txtDepartment.Text.ToUpper() == deptname && txtDesingnation.Text.ToUpper() == desgname)
                        {
                            ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "CRM Sales", "alertify.alert('Key Person already exist...');", true);
                            blnerrchk = true;
                            return;
                        }
                        else
                        {

                        }
                    }
                }
            }
         
            DataRow dr;
            if (dt_list == null)
            {
                dt_list = new DataTable();
                // DataColumn dc_col2 = new DataColumn("indexvalue", typeof(string));
                dt_list.Columns.Add("ptcc");
                dt_list.Columns.Add("desig");
                dt_list.Columns.Add("dept");
                dt_list.Columns.Add("mobile");
                dt_list.Columns.Add("phone");
                dt_list.Columns.Add("email");
                dt_list.Columns.Add("title");
                dt_list.Columns.Add("ptc");
                dt_list.Columns.Add("crmkeyid", typeof(int));
                dt_list.Columns.Add("crmid", typeof(int));
            }
            //DataRow[] dr_tt1 = dt_list.Select("ptcc='" + txtName.Text.ToString() + "'", "desig='" + txtDesingnation.Text.ToString() + "'", "dept='" + txtDepartment.Text.ToString() + "'",
            //    "mobile='" + txt_Mobile.Text.ToString() + "'", "phone='" + txt_Landline.Text.ToString() + "'", "email='" + txt_email.Text.ToString() + "'",
            //    "title='" '",);

            dr = dt_list.NewRow();
            dr["ptcc"] = txtName.Text.ToUpper();
            dr["desig"] = txtDesingnation.Text.ToUpper();
            dr["dept"] = txtDepartment.Text.ToUpper();
            dr["mobile"] = txt_Mobile.Text;
            dr["phone"] = txt_Landline.Text;
            dr["email"] = txt_email.Text;
            dr["title"] = ddlTitle.SelectedItem;
            dr["ptc"] = txtName.Text;
            dr["crmkeyid"] = 0;
            dr["crmid"] = 0;
            dt_list.Rows.Add(dr);



            Session["dt_List"] = dt_list;
            grdKey.DataSource = dt_list;
            grdKey.DataBind();
        }//Dinesh

        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            //this.ModelPOPForKeyPerson.Show();
            DataTable dtkey = new DataTable();
            if (hf_customerid.Value == "" || hf_customerid.Value == "0")
            {
                return;
            }
            if (hf_customerid.Value != "" || hf_customerid.Value != null)
            {
                dtkey = obj_CRM.GetKeyPersonDetails(0, Convert.ToInt32(hf_customerid.Value), txtName.Text);
            }
            if (dtkey.Rows.Count > 0)
            {
                ddlTitle.Text = dtkey.Rows[0]["title"].ToString();
                // txtName.Text=dtkey.Rows[0]["ptc"].ToString();
                txtDesingnation.Text = dtkey.Rows[0]["desig"].ToString();
                txtDepartment.Text = dtkey.Rows[0]["dept"].ToString();
                txt_Mobile.Text = dtkey.Rows[0]["phone"].ToString();
                txt_Landline.Text = dtkey.Rows[0]["mobile"].ToString();
                txt_email.Text = dtkey.Rows[0]["email"].ToString();
                //  btnKSave.Text = "Update";
                //  btnKClose.Text = "Clear";
            }
            //prabha
            /////// btnClear.Text = "Cancel";
        }

        private void checkKeyperson()
        {
            if (txtcustomer.Text == "" && hf_customerid.Value == "")
            {
                ScriptManager.RegisterStartupScript(btnKSave, typeof(Button), "Prospect Customer", "alertify.alert('Customer Name Should not be Blank..')", true);
                txtcustomer.Focus();
                blnerr = false;
                return;
            }

            if (txtName.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "CRM Sales", "alertify.alert('Key Person Should not be Blank..');", true);
                txtName.Focus();
                blnerr = false;
                return;
            }
            if (ddlTitle.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "CRM Sales", "alertify.alert('Title Should not be Blank..');", true);
                ddlTitle.Focus();
                blnerr = false;
                return;
            }
            //if (txtName.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "CRM Sales", "alertify.alert('Name Should not be Blank..');", true);
            //    txtName.Focus();
            //    blnerr = false;
            //    return;
            //}
            //if (txtDesingnation.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "CRM Sales", "alertify.alert('Designation Should not be Blank..');", true);
            //    txtDesingnation.Focus();
            //    blnerr = false;
            //    return;
            //}
            //if (txtDepartment.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "CRM Sales", "alertify.alert('Department Should not be Blank..');", true);
            //    txtDepartment.Focus();
            //    blnerr = false;
            //    return;
            //}
            if (txt_Mobile.Text == "" && txt_Landline.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "CRM Sales", "alertify.alert('Enter Any One Contact Details..');", true);
                txt_Mobile.Focus();
                blnerr = false;
                return;
            }
        }
        protected void btnKSave_Click(object sender, EventArgs e)
        {
            blnerr = true;

           
            checkKeyperson();
            if (blnerr == false)
            {
                blnerr = true;
                return;
            }
            if (btnKSave.ToolTip == "Add")
            {
                if (hf_customerid.Value == "")
                {
                    AddValues();
                    if (blnerrchk==true)
                    {
                        blnerrchk = false;
                        return;
                    }
                    ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "KeyPerson", "alertify.alert('Key Person Details Saved..');", true);
                    ClearKeyPerson();
                    return;
                }
                DataTable Dtchk = new DataTable();
                Dtchk = objsales.ChkKeypersondetails(Convert.ToInt32(hf_customerid.Value), txtName.Text.ToUpper(), txtDepartment.Text.ToUpper(), txtDesingnation.Text.ToUpper());
                if (Dtchk.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "KeyPerson", "alertify.alert('Key Person Details Already Exist..');", true);
                    txtName.Focus();
                    return;
                }
                else
                {
                    obj_CRM.InsPCustomerContactDetails(Convert.ToInt32(hf_customerid.Value), ddlTitle.SelectedValue, txtName.Text.ToUpper(), txtDesingnation.Text.ToUpper(), txtDepartment.Text.ToUpper(), txt_Landline.Text, txt_Mobile.Text, txt_email.Text.ToUpper(), 0);                    
                }

                ClearKeyPerson();
                ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "KeyPerson", "alertify.alert('Key Person Details Saved..');", true);
            }
            else if (btnKSave.ToolTip == "Upd")
            {
                obj_CRM.UpdPCustomerContactDetails(ddlTitle.SelectedValue, txtName.Text.ToUpper(), txtDesingnation.Text.ToUpper(), txtDepartment.Text.ToUpper(), txt_Landline.Text, txt_Mobile.Text, txt_email.Text.ToUpper(), 0, Convert.ToInt32(hf_customerid.Value), Convert.ToInt32(hdf_crmkeyid.Value));
                ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "KeyPerson", "alertify.alert('Key Person Details Updated..');", true);
            }
            //prabha
            ////// btnClear.Text = "Cancel";
            fillgrdkey();            
        }

        private void ClearKeyPerson()
        {
            txtName.Text = "";
            txtDepartment.Text = "";
            txtDesingnation.Text = "";
            txt_Mobile.Text = "";
            txt_Landline.Text = "";
            txt_email.Text = "";
        }

        protected void chkproducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string result = Request.Form["__EVENTTARGET"];
            string[] checkedBox = result.Split('$');
            int index = int.Parse(checkedBox[checkedBox.Length - 1]);
            if (index == 0)
            {
                if (chkproducts.Items[0].Selected == true)
                {
                    for (int i = 0; i < chkproducts.Items.Count; i++)
                    {
                        if (chkproducts.Items[i].Text != "Select All")
                        {
                            chkproducts.Items[i].Selected = true;
                        }
                    }
                }

                else
                {
                    for (int i = 0; i < chkproducts.Items.Count; i++)
                    {
                        chkproducts.Items[i].Selected = false;
                    }
                    return;
                }
            }
            else
            {
                for (int i = 0; i < chkproducts.Items.Count; i++)
                {
                    int a = chkproducts.Items.Count - 1;
                    int count = 0;
                    for (int j = 1; j < chkproducts.Items.Count; j++)
                    {
                        count = count + 1;
                    }

                    if (a == count)
                    {
                        chkproducts.Items[0].Selected = true;
                    }
                }

                for (int i = 0; i < chkproducts.Items.Count; i++)
                {
                    if (chkproducts.Items[i].Selected == false)
                    {
                        chkproducts.Items[0].Selected = false;
                        break;
                    }

                }
            }

            string name = "";
            for (int i = 0; i < chkproducts.Items.Count; i++)
            {
                if (chkproducts.Items[i].Text != "Select All")
                {
                    if (chkproducts.Items[i].Selected)
                    {
                        name += chkproducts.Items[i].Text + ",";
                    }
                }
            }
            txtProducts.Text = name;

            //PceSelectCustom
        }

        protected void grdKey_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdKey, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdkeyselectindex();
            //prabha
            ////////btnClear.Text = "Cancel";
        }
        private void grdkeyselectindex()
        {
            if (grdKey.Rows.Count > 0)
            {
                int index = grdKey.SelectedRow.RowIndex;
                hf_indexid.Value = index.ToString();
                ddlTitle.SelectedValue = grdKey.SelectedRow.Cells[6].Text;
                txtName.Text = grdKey.SelectedRow.Cells[7].Text;
                txtDepartment.Text = grdKey.SelectedRow.Cells[2].Text;
                txtDesingnation.Text = grdKey.SelectedRow.Cells[1].Text;
                if (grdKey.SelectedRow.Cells[5].Text == "&nbsp;")
                {
                    txt_email.Text = "";
                }
                else
                {
                    txt_email.Text = grdKey.SelectedRow.Cells[5].Text;
                } 
                txt_Mobile.Text = grdKey.SelectedRow.Cells[3].Text;
                txt_Landline.Text = grdKey.SelectedRow.Cells[4].Text;
                crmkeyid = Convert.ToInt32(grdKey.SelectedRow.Cells[8].Text);
                hdf_crmkeyid.Value = grdKey.SelectedRow.Cells[8].Text;
                crmid = Convert.ToInt32(grdKey.SelectedRow.Cells[9].Text);
                //prabha
                ////// hdf_CRM.Value = grdKey.SelectedRow.Cells[9].Text;
                // btnKSave.Text = "Upd";
                btnKSave.ToolTip = "Upd";
                btn_add1.Attributes["class"] = "btn btn-update1";
            }
        }

        private void checkDetails()
        {
            if (chkproducts.Items[1].Selected == true)
            {
                productid = 1;
                obj_CRM.InsCRMProductDetails(0, productid, Convert.ToInt32(hf_customerid.Value));//Convert.ToInt32(hf_customerid.Value)
                //  ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "Product", "alertify.alert('Sales Details Saved');", true);
                //  ClearProduct();
            }
            if (chkproducts.Items[2].Selected == true)
            {
                productid = 2;
                obj_CRM.InsCRMProductDetails(0, productid, Convert.ToInt32(hf_customerid.Value));
                //  ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "Product", "alertify.alert('Details Saved Successfully...');", true);
                //  ClearProduct();
            }
            if (chkproducts.Items[3].Selected == true)
            {
                productid = 3;
                obj_CRM.InsCRMProductDetails(0, productid, Convert.ToInt32(hf_customerid.Value));
                // ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "Product", "alertify.alert('Details Saved Successfully...');", true);
                // ClearProduct();
            }
            if (chkproducts.Items[4].Selected == true)
            {
                productid = 4;
                obj_CRM.InsCRMProductDetails(0, productid, Convert.ToInt32(hf_customerid.Value));
                //  ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "Product", "alertify.alert('Details Saved Successfully...');", true);
                //ClearProduct();
            }
            if (chkproducts.Items[1].Selected == true)
            {
                productid = 5;
                obj_CRM.InsCRMProductDetails(0, productid, Convert.ToInt32(hf_customerid.Value));
                // ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "Product", "alertify.alert('Details Saved Successfully...');", true);
                // ClearProduct();
            }
            if (chkproducts.Items[1].Selected == true)
            {
                productid = 6;
                obj_CRM.InsCRMProductDetails(0, productid, Convert.ToInt32(hf_customerid.Value));
                // ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "Product", "alertify.alert('Details Saved Successfully...');", true);
                // ClearProduct();
            }
            if (chkproducts.Items[7].Selected == true)
            {
                productid = 7;
                obj_CRM.InsCRMProductDetails(0, productid, Convert.ToInt32(hf_customerid.Value));
                //  ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "Product", "alertify.alert('Details Saved Successfully...');", true);
                //  ClearProduct();
            }
            if (chkproducts.Items[8].Selected == true)
            {
                productid = 8;
                obj_CRM.InsCRMProductDetails(0, productid, Convert.ToInt32(hf_customerid.Value));
                // ScriptManager.RegisterStartupScript(btnKSave, typeof(System.Web.UI.WebControls.Button), "Product", "alertify.alert('Details Saved Successfully...');", true);
            }
        }

        protected void btnanother_Click(object sender, EventArgs e)
        {
            //btnSave.Text = "Save";
            btnSave.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            txtcity.Text = "";
            txtdistrict.Text = "";
            txtlocation.Text = "";
            txtpincode.Text = "";
        }

        protected void lnkButton_Click(object sender, EventArgs e)
        {
            this.Grd_buying_popup.Show();
            // custid = Convert.ToInt32(Request.QueryString["custid"]);
            if (hf_customerid.Value != null && hf_customerid.Value != "")
            {
                txtCustName.Text = obj_MasterCustomer.GetCustomerProspectname(Convert.ToInt32(hf_customerid.Value));
                txtPretext.Text = obj_MasterCustomer.GetFreetext(Convert.ToInt32(hf_customerid.Value));

            }
        }

        protected void btnsave1_Click1(object sender, EventArgs e)
        {
            this.Grd_buying_popup.Show();
            if (btnsave1.ToolTip == "Save")
            {
                //custid = Convert.ToInt32(Request.QueryString["custid"]);
                if (hf_customerid.Value != null && hf_customerid.Value != "")
                {
                    obj_MasterCustomer.DelFreetext(Convert.ToInt32(hf_customerid.Value));
                    obj_MasterCustomer.CustTeleCast(Convert.ToInt32(hf_customerid.Value), txtPretext.Text);
                    //objsales.InsForCallDetails(Convert.ToInt32(hf_customerid.Value));
                    objsales.InsForCallDetailsNew(Convert.ToInt32(hf_customerid.Value));
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "TeleCallDetails", "alertify.alert('Saved Successfully...');", true);
                    //btnCancel.Text = "Cancel";
                }
                else
                {

                }
            }
        }

        protected void btnCancel1_Click1(object sender, EventArgs e)
        {
            txtCustName.Text = "";
            txtPretext.Text = "";
        }

        protected void grdKey_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //hf_indexid.Value = e.RowIndex.ToString();
            //DataTable dt_list = new DataTable();
            //dt_list = (DataTable)Session["dt_List"];
            //dt_list.Rows[Convert.ToInt32(hf_indexid.Value)].Delete();
            //dt_list.AcceptChanges();
            //Session["dt_List"] = dt_list;
            //grdKey.DataSource = dt_list;
            //grdKey.DataBind();
            //this.modelpopupkey.Show();


            if (hf_customerid.Value != "" && hf_customerid.Value!="0")
            {
                hf_indexid.Value = e.RowIndex.ToString();
                DataTable dt_list = new DataTable();
                dt_list = (DataTable)Session["dt_List"];
                int custid = 0;
                if (hf_customerid.Value == "" || hf_customerid.Value == "0")
                {
                    custid = 0;
                }
                else
                {
                    custid = Convert.ToInt32(hf_customerid.Value);
                }
                int keyid = 0;
                if (dt_list.Rows.Count > 0)
                {
                    keyid = Convert.ToInt32(dt_list.Rows[Convert.ToInt32(hf_indexid.Value)]["crmkeyid"].ToString());
                    objsales.DelForCallDetails(keyid, custid);
                }
                dt = obj_CRM.GetKeyPersonDetails4Grid(Convert.ToInt32(hf_customerid.Value), 0);
                Session["dt_List"] = dt;
                grdKey.DataSource = dt;
                grdKey.DataBind();
            }
            else
            {
                DataTable dt_list = new DataTable();
                dt_list = (DataTable)Session["dt_List"];
                dt_list.Rows[Convert.ToInt32(hf_indexid.Value)].Delete();
                dt_list.AcceptChanges();
                Session["dt_List"] = dt_list;
                grdKey.DataSource = dt_list;
                grdKey.DataBind();
                //this.modelpopupkey.Show();
            }
         
            //this.modelpopupkey.Show();
        }

        protected void grdKey_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void txtstno_TextChanged(object sender, EventArgs e)
        {
            if (txtstno.Text.Length >= 12 && txtpanno.Text.ToUpper() != "")
            {
                if (txtpanno.Text.ToUpper() == txtstno.Text.ToUpper().Substring(2, 10))
                {


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('GSTIN # - PAN# and Customer PAN# is Not Match');", true);
                    return;
                }
            }
        }

        protected void txtEmpname_TextChanged(object sender, EventArgs e)
        {

            if (txtEmpname.Text != "")
            {

                if (hid_Empname.Value == "" || hid_Empname.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Invalid Sales Person Name');", true);
                    txtEmpname.Focus();
                    txtEmpname.Text = "";
                    return;
                }
                else
                {
                    txt_salescordin.Focus();
                }
            }

        }

        protected void txt_salescordin_TextChanged(object sender, EventArgs e)
        {
            if (txt_salescordin.Text != "")
            {

                if (hid_salesCordin.Value == "" || hid_salesCordin.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Invalid Sales Coordinator);", true);
                    txt_salescordin.Focus();
                    txt_salescordin.Text = "";
                    return;
                }
                else
                {

                }
            }
        }

        protected void txt_email_TextChanged(object sender, EventArgs e)
        {
            if (hf_customerid.Value == "")
            {
                return;
            }

            if (IsValidEmailId(txt_email.Text))
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Invalid Email ID');", true);
                txt_email.Text = "";
                txt_email.Focus();
            }
        }

        protected void txt_Mobile_TextChanged(object sender, EventArgs e)
        {
            if (txt_Mobile.Text.Length < 10)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Mobile Number should not be less than 10 Numbers');", true);
                txt_Mobile.Text = "";
                txt_Mobile.Focus();
            }
        }

        protected void txtmobile_TextChanged(object sender, EventArgs e)
        {
            if (txtmobile.Text.Length < 10)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Mobile Number should not be less than 10 Numbers');", true);
                txtmobile.Text = "";
                txtmobile.Focus();
            }
        }

        protected void txtName_TextChanged1(object sender, EventArgs e)
        {
            btnKSave.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn btn-add1";
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string customerIds = Request.Form[hfComm.UniqueID];

        //    foreach (string ids in customerIds.Split(','))
        //    {
        //        if (ids.ToString().Contains("HAZ")==false)
        //        {
        //            obj_MasterCustomer.Insprospectcommodity(999999, Convert.ToInt32(ids));
        //        }
        //    }
        //}


        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string customerIds = Request.Form[hfComm.UniqueID];

        //    foreach (string ids in customerIds.Split(','))
        //    {
        //        obj_MasterCustomer.Insprospectcommodity(999999, Convert.ToInt32(ids));
        //    }
        //}

        //protected void imapccolse_Click(object sender, ImageClickEventArgs e)
        //{
        //    divhelp.Visible = false;
        //    imapccolse.Visible = false;
        //}

        //prabha
        ////////protected void txtSalePerson_TextChanged(object sender, EventArgs e)
        ////////{
        ////////    DataTable dt_empcheck = new DataTable();
        ////////    if(txtSalePerson.Text != "")
        ////////    {
        ////////        if (hdnSalesid.Value == "")
        ////////        {
        ////////            hdnSalesid.Value = employee.GetNEmpid(txtSalePerson.Text).ToString();
        ////////        }

        ////////        if (hdnSalesid.Value != "")
        ////////        {
        ////////            int ptcid = Convert.ToInt32(hdnSalesid.Value.ToString());
        ////////            dt_empcheck = objadd.CheckEmpNameNew(ptcid);
        ////////            if (dt_empcheck.Rows.Count > 0)
        ////////            {
        ////////                btnCancel.Text = "Cancel";
        ////////            }
        ////////            else
        ////////            {
        ////////                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CRMSalesDetails", "alertify.alert('Invalid Sales Person');", true);
        ////////                txtSalePerson.Text = "";
        ////////                txtSalePerson.Focus();
        ////////            }
        ////////        }


        ////////    }
        ////////}
    }
}