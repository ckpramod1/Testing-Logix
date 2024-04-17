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

namespace logix.Maintenance
{
    public partial class MasterCustomerProspective : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.CheckBoxList chkType;
        DataTable dt = new DataTable();
   DataAccess.Masters.MasterCustomer obj_Details4Location = new DataAccess.Masters.MasterCustomer();
   DataAccess.Masters.MasterLocation location = new DataAccess.Masters.MasterLocation();
        DataAccess.Masters.MasterCustomerProspective obj_MasterCustomer = new DataAccess.Masters.MasterCustomerProspective();
        DataAccess.Masters.MasterPort port = new DataAccess.Masters.MasterPort();
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
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnBack);
            btnDelete.OnClientClick = @"return getConfirmationValue();";
            if (!IsPostBack)
            {
                Ctrl_List = txtcustomer.ID + "~" + txtunit.ID + "~" + txtbuildingname.ID + "~" + txtdoor.ID + "~" + txtstreet.ID + "~" + txtlocation.ID + "~" + txtpin.ID + "~" + txtcity.ID + "~" + txtdistrict.ID + "~" + txtstate.ID + "~" + txtcountry.ID + "~" + txtllisd.ID + "~" + txtllstd.ID + "~" + txtlandline.ID + "~" + txtfaxisd.ID + "~" + txtfaxstd.ID + "~" + txtfax.ID + "~" + txtmblisd.ID + "~" + txtMobile.ID + "~" + txtemail.ID+"~"+txtPanNo.ID +"~"+txtServiceTaxNo.ID ;
                Msg_List = "Customer Name~Unit No~Building Name~Door No~ Street Name~Location Name~Pincode~Port Name~District Name~State Name~Country Name~ISD Code For Landline~STD Code For Landline~Landline Number~ISD Code For Fax~STD Code For Fax~Fax Number~ISD Code For Mobile~Mobile Number~Email~Pan #~ServicTax #";
                Dtype_List = "string~string~string~string~string~string~string~string~string~string~string~int~int~int~int~int~int~int~int~string~string~string";
                btnSave.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                //str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btnSave, null, null);

                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                lstlocation.Visible = false;
                txtllstd.Enabled = true;
                txtfaxstd.Enabled = true;

            }
            else if (Page.IsPostBack)
            {
              // txtlocation_TextChanged1(sender, e);
              // txtpin_TextChanged(sender, e);
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
            [WebMethod]
            public static List<string> GetLocation(string prefix)
            {
                List<string> List_Result = new List<string>();
                DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
                DataTable dt_Location = new DataTable();
                dt_Location = objp_location.GetlocationnameNEWLocation(prefix);
                List_Result = Utility.Fn_DatatableToList_int16Display(dt_Location, "locport", "locationid", "Location");
                return List_Result;
            }
            [WebMethod]
            public static List<string> GetCustomer(string prefix)
            {
                List<string> list_result = new List<string>();
                DataTable dt = new DataTable();
                DataAccess.Masters.MasterCustomerProspective obj_MasterCustomer = new DataAccess.Masters.MasterCustomerProspective();
                dt = obj_MasterCustomer.GetCustomerName(prefix);
                list_result = Utility.Fn_TableToList(dt, "customername", "customerid");
                return list_result;

            }
          [WebMethod]
            public static List<string> GetPincode(string prefix)
            {
                List<string> List_Result = new List<string>();
                DataTable obj_dt = new DataTable();
                DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
                obj_dt = objp_location.GetlocationnameNEWpincode(prefix);
                List_Result = Utility.Fn_DatatableToList_Text(obj_dt,"pinCode");
                return List_Result;
            }
            private void filldetails()
            {
                if (hf_customerid.Value != "" && hf_locationid.Value != "")
                {
                    if (Check4.Checked)
                    {
                        dt = obj_MasterCustomer.GetCustomerDetails(Convert.ToInt32(hf_customerid.Value), "P", Convert.ToInt32(hf_locationid.Value));

                        if (dt.Rows.Count > 0)
                        {
                            // Check4.Checked = true;
                            txtunit.Text = dt.Rows[0]["unit#"].ToString();
                            txtbuildingname.Text = dt.Rows[0]["buildingname"].ToString();
                            txtdoor.Text = dt.Rows[0]["door#"].ToString();
                            txtstreet.Text = dt.Rows[0]["street"].ToString();
                            txtlocation.Text = dt.Rows[0]["Location"].ToString();
                            hf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                            txtcity.Text = dt.Rows[0]["portname"].ToString();
                            hf_portid.Value = dt.Rows[0]["portid"].ToString();
                            txtdistrict.Text = dt.Rows[0]["Districts"].ToString();
                            hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                            txtstate.Text = dt.Rows[0]["States"].ToString();
                            hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                            txtcountry.Text = dt.Rows[0]["CountryName"].ToString();
                            hf_countryid.Value = dt.Rows[0]["countryid"].ToString();
                            txtpin.Text = dt.Rows[0]["pincode"].ToString();
                            txtllisd.Text = dt.Rows[0]["llisd"].ToString();
                            txtllstd.Text = dt.Rows[0]["llstd"].ToString();
                            txtmblisd.Text = dt.Rows[0]["mblisd"].ToString();
                            txtMobile.Text = dt.Rows[0]["mobile"].ToString();
                            txtfaxisd.Text = dt.Rows[0]["faxisd"].ToString();
                            txtfaxstd.Text = dt.Rows[0]["faxstd"].ToString();
                            txtfax.Text = dt.Rows[0]["fax"].ToString();
                            txtemail.Text = dt.Rows[0]["email"].ToString();
                            txtlandline.Text = dt.Rows[0]["landline"].ToString();
                            txtPanNo.Text = dt.Rows[0]["panno"].ToString();
                            txtServiceTaxNo.Text = dt.Rows[0]["stno"].ToString();


                            txtComPTC.Text = dt.Rows[0]["comptc"].ToString();
                            txtComMail.Text = dt.Rows[0]["commailid"].ToString();
                            txtExpPTC.Text = dt.Rows[0]["expptc"].ToString();
                            txtExpMail.Text = dt.Rows[0]["expmailid"].ToString();
                            txtImpPTC.Text = dt.Rows[0]["impptc"].ToString();
                            txtImpMail.Text = dt.Rows[0]["impmailid"].ToString();
                            txtFinPTC.Text = dt.Rows[0]["finptc"].ToString();
                            txtFinMail.Text = dt.Rows[0]["finmailid"].ToString();
                            if(dt.Rows[0]["status"].ToString()=="N")
                            {
                                rdbNewCustomer.Checked = true;
                            }
                            else if (dt.Rows[0]["status"].ToString() == "F")
                            {
                                rdbFollowUp.Checked = true;
                            }
                            else if (dt.Rows[0]["status"].ToString() == "E")
                            {
                                rdbExisting .Checked = true;
                            }
                            btnSave.Text = "Update";
                        }
                        else
                        {
                            clear();
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter Valid Customer,Customer Type,Location');", true);
                        }

                    }
                    else if (Check1.Checked || Check2.Checked || Check3.Checked || Check5.Checked || Check6.Checked || Check7.Checked || Check8.Checked || Check9.Checked || Check10.Checked || Check11.Checked)
                    {
                        dt = obj_MasterCustomer.GetCustomerDetails(Convert.ToInt32(hf_customerid.Value), "C", Convert.ToInt32(hf_locationid.Value));

                        if (dt.Rows.Count > 0)
                        {
                            // CkeckList();
                            txtunit.Text = dt.Rows[0]["unit#"].ToString();
                            txtbuildingname.Text = dt.Rows[0]["buildingname"].ToString();
                            txtdoor.Text = dt.Rows[0]["door#"].ToString();
                            txtstreet.Text = dt.Rows[0]["street"].ToString();
                            txtlocation.Text = dt.Rows[0]["Location"].ToString();
                            hf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                            txtcity.Text = dt.Rows[0]["portname"].ToString();
                            hf_portid.Value = dt.Rows[0]["portid"].ToString();
                            txtdistrict.Text = dt.Rows[0]["Districts"].ToString();
                            hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                            txtstate.Text = dt.Rows[0]["States"].ToString();
                            hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                            txtcountry.Text = dt.Rows[0]["CountryName"].ToString();
                            hf_countryid.Value = dt.Rows[0]["countryid"].ToString();
                            txtpin.Text = dt.Rows[0]["pincode"].ToString();
                            txtllisd.Text = dt.Rows[0]["llisd"].ToString();
                            txtllstd.Text = dt.Rows[0]["llstd"].ToString();
                            txtmblisd.Text = dt.Rows[0]["mblisd"].ToString();
                            txtMobile.Text = dt.Rows[0]["mobile"].ToString();
                            txtfaxisd.Text = dt.Rows[0]["faxisd"].ToString();
                            txtfaxstd.Text = dt.Rows[0]["faxstd"].ToString();
                            txtfax.Text = dt.Rows[0]["fax"].ToString();
                            txtemail.Text = dt.Rows[0]["email"].ToString();
                            txtlandline.Text = dt.Rows[0]["landline"].ToString();
                            txtPanNo.Text = dt.Rows[0]["panno"].ToString();
                            txtServiceTaxNo.Text = dt.Rows[0]["stno"].ToString();

                            txtComPTC.Text = dt.Rows[0]["comptc"].ToString();
                            txtComMail.Text = dt.Rows[0]["commailid"].ToString();
                            txtExpPTC.Text = dt.Rows[0]["expptc"].ToString();
                            txtExpMail.Text = dt.Rows[0]["expmailid"].ToString();
                            txtImpPTC.Text = dt.Rows[0]["impptc"].ToString();
                            txtImpMail.Text = dt.Rows[0]["impmailid"].ToString();
                            txtFinPTC.Text = dt.Rows[0]["finptc"].ToString();
                            txtFinMail.Text = dt.Rows[0]["finmailid"].ToString();
                            if (dt.Rows[0]["status"].ToString() == "N")
                            {
                                rdbNewCustomer.Checked = true;
                            }
                            else if (dt.Rows[0]["status"].ToString() == "F")
                            {
                                rdbFollowUp.Checked = true;
                            }
                            else if (dt.Rows[0]["status"].ToString() == "E")
                            {
                                rdbExisting.Checked = true;
                            }

                            btnSave.Text = "Update";
                        }
                        else
                        {
                            clear();
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Enter Valid Customer,Customer Type,Location');", true);
                        }

                    }


                }

                else
                {
                    btnSave.Text = "Save";
                    locationdetails();

                }
                btnBack.Text = "Cancel";

            }
          
            private void clear()
            {
                txtcustomer.Text = "";
                //  ddlCType.SelectedValue = "Select";
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
                txtpin.Text = "";
                txtmblisd.Text = "";
                txtMobile.Text = "";
                txtfaxisd.Text = "";
                txtfaxstd.Text = "";
                txtfax.Text = "";
                txtemail.Text = "";
                hf_customerid.Value = "";
                txtPanNo.Text = "";
                txtServiceTaxNo.Text = "";
                Check1.Checked = false;
                Check2.Checked = false;
                Check3.Checked = false;
                Check4.Checked = false;
                Check5.Checked = false;
                Check6.Checked = false;
                Check7.Checked = false;
                Check8.Checked = false;
                Check9.Checked = false;
                Check10.Checked = false;
                Check11.Checked = false;
                btnSave.Text = "Save";
                txtComMail.Text = "";
                txtComPTC.Text = "";
                txtExpMail.Text = "";
                txtExpPTC.Text = "";
                txtImpMail.Text = "";
                txtImpPTC.Text = "";
                txtFinMail.Text = "";
                txtFinPTC.Text = "";
                rdbExisting.Checked = false;
                rdbFollowUp.Checked = false;
                rdbNewCustomer.Checked = false;


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
                ExportToExcel();
            }
            protected void pdffunforserver_Click(object sender, EventArgs e)
            {
                ExportToPdf();
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


            private void locationdetails()
            {
                dt = obj_Details4Location.GetLocationDetails(txtlocation.Text);
                if (dt.Rows.Count > 0)
                {
                    // txtlocation.Text = dt.Rows[0]["locationname"].ToString();
                    hf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                    txtcity.Text = dt.Rows[0]["portname"].ToString();
                    hf_portid.Value = dt.Rows[0]["portid"].ToString();
                    txtdistrict.Text = dt.Rows[0]["Districts"].ToString();
                    hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                    txtstate.Text = dt.Rows[0]["States"].ToString();
                    hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                    txtcountry.Text = dt.Rows[0]["CountryName"].ToString();
                    hf_countryid.Value = dt.Rows[0]["countryid"].ToString();
                    txtpin.Text = dt.Rows[0]["pincode"].ToString();
                    txtllisd.Text = dt.Rows[0]["ISDcode"].ToString();
                    txtllstd.Text = dt.Rows[0]["stdcode"].ToString();
                    txtmblisd.Text = dt.Rows[0]["ISDcode"].ToString();
                    txtfaxisd.Text = dt.Rows[0]["ISDcode"].ToString();
                    txtfaxstd.Text = dt.Rows[0]["stdcode"].ToString();
                }
            }

            protected void txtlocation_TextChanged1(object sender, EventArgs e)
            {
                DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
                dt = objp_location.CheckDuplicateForLocationNew(txtlocation.Text);
                if (dt.Rows.Count > 0)
                {
                    hf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                }
                btnBack.Text = "Clear";
                if (hf_locationid.Value != "" && hf_customerid.Value != "")
                {

                    filldetails();

                }
                else
                {

                    
                    dt = objp_location.CheckDuplicateForLocationNew(txtlocation.Text);
                    if (dt.Rows.Count > 0 && hf_locationid.Value!= "")
                    {
                        hf_locationid.Value = dt.Rows[0]["locationid"].ToString();
                    }

                    if (hf_locationid.Value != "")
                    {

                        getlocationdetails();
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
                        txtdistrict.Text = dt1.Rows[0]["Districts"].ToString();
                        hf_districtid.Value = dt1.Rows[0]["districtid"].ToString();
                        txtstate.Text = dt1.Rows[0]["States"].ToString();
                        hf_stateid.Value = dt1.Rows[0]["stateid"].ToString();
                        txtcountry.Text = dt1.Rows[0]["CountryName"].ToString();
                        hf_countryid.Value = dt1.Rows[0]["Countryid"].ToString();
                        txtpin.Text = dt1.Rows[0]["pincode"].ToString();
                        txtllisd.Text = dt1.Rows[0]["ISDcode"].ToString();
                        // txtllstd.Text = dt1.Rows[0]["stdcode"].ToString();
                        txtmblisd.Text = dt1.Rows[0]["ISDcode"].ToString();
                        txtfaxisd.Text = dt1.Rows[0]["ISDcode"].ToString();
                        //txtfaxstd.Text = dt1.Rows[0]["stdcode"].ToString();

                    }
                    else if (dt1.Rows[0]["cityport"].ToString() != "")
                    {
                        // txtcity.Enabled = false;
                        hf_portid.Value = dt1.Rows[0]["cityport"].ToString();
                        dt = obj_Details4Location.GETDetails4LocationIntNewPort(Convert.ToInt32(hf_locationid.Value), Convert.ToInt32(hf_portid.Value));
                        txtcity.Text = dt.Rows[0]["portname"].ToString();
                        hf_portid.Value = dt.Rows[0]["cityport"].ToString();
                        txtdistrict.Text = dt.Rows[0]["Districts"].ToString();
                        hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                        txtstate.Text = dt.Rows[0]["States"].ToString();
                        hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                        txtcountry.Text = dt.Rows[0]["CountryName"].ToString();
                        hf_countryid.Value = dt.Rows[0]["Countryid"].ToString();
                        txtpin.Text = dt.Rows[0]["pincode"].ToString();
                        txtllisd.Text = dt.Rows[0]["ISDcode"].ToString();
                        txtllstd.Text = dt.Rows[0]["stdcode"].ToString();
                        txtmblisd.Text = dt.Rows[0]["ISDcode"].ToString();
                        txtfaxisd.Text = dt.Rows[0]["ISDcode"].ToString();
                        txtfaxstd.Text = dt.Rows[0]["stdcode"].ToString();
                    }
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Location", "alertify.alert('Enter Valid Location');", true);
                    txtlocation.Text = "";
                }
            }
            private void ckecK()
            {
                if (Check1.Checked == false && Check2.Checked == false && Check3.Checked == false && Check4.Checked == false && Check5.Checked == false && Check6.Checked == false && Check7.Checked == false && Check8.Checked == false && Check9.Checked == false && Check10.Checked == false && Check11.Checked == false)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Please Select Customer Type....');", true);
                }
            }

            protected void btnSave_Click(object sender, EventArgs e)
            {
                custDetails();
                std = txtllstd.Text;
                if (btnSave.Text == "Save")
                {
                    int_location = Convert.ToInt32(hf_locationid.Value.ToString());
                    int_port = Convert.ToInt32(hf_portid.Value.ToString());
                    int_district = Convert.ToInt32(hf_districtid.Value.ToString());
                    int_state = Convert.ToInt32(hf_stateid.Value.ToString());
                    int_country = Convert.ToInt32(hf_countryid.Value.ToString());
                    llisd = Convert.ToInt32(txtllisd.Text.ToString());
                    landline = Convert.ToInt32(txtlandline.Text.ToString());
                    mblisd = Convert.ToInt32(txtmblisd.Text.ToString());
                    faxisd = Convert.ToInt32(txtfaxisd.Text.ToString());
                    int_fax = Convert.ToInt32(txtfax.Text.ToString());
                    if (Check4.Checked)
                    {
                       // obj_MasterCustomer.InsMasterCustomer(txtcustomer.Text.ToUpper(), "P", txtunit.Text, txtbuildingname.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country, txtpin.Text, llisd, txtllstd.Text, landline, mblisd, txtMobile.Text, faxisd, txtfaxstd.Text, int_fax, txtemail.Text, txtPanNo.Text, txtServiceTaxNo.Text);
                      /////  obj_MasterCustomer.InsMasterCustomer(txtcustomer.Text.ToUpper(), "P", txtunit.Text, txtbuildingname.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country, txtpin.Text, llisd, txtllstd.Text, landline, mblisd, txtMobile.Text, faxisd, txtfaxstd.Text, int_fax, txtemail.Text, txtPanNo.Text, txtServiceTaxNo.Text, status, txtComMail.Text, txtExpMail.Text, txtImpMail.Text, txtFinMail.Text, txtComPTC.Text, txtExpPTC.Text, txtImpPTC.Text, txtFinPTC.Text, Convert.ToInt32(Session["LoginEmpId"]));
                        location.UpdCityportInLocation(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_locationid.Value));
                          obj_Details4Location.UpdPortFromCustomer(Convert.ToInt32(hf_districtid.Value), Convert.ToInt32(hf_stateid.Value), std, Convert.ToInt32(hf_portid.Value));
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Inserted Successfully');", true);
                    }
                    else if (Check1.Checked || Check2.Checked || Check3.Checked || Check5.Checked || Check6.Checked || Check7.Checked || Check8.Checked || Check9.Checked || Check10.Checked || Check11.Checked)
                    {
                        //obj_MasterCustomer.InsMasterCustomer(txtcustomer.Text.ToUpper(), "C", txtunit.Text, txtbuildingname.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country, txtpin.Text, llisd, txtllstd.Text, landline, mblisd, txtMobile.Text, faxisd, txtfaxstd.Text, int_fax, txtemail.Text, txtPanNo.Text, txtServiceTaxNo.Text);
                      ////  obj_MasterCustomer.InsMasterCustomer(txtcustomer.Text.ToUpper(), "C", txtunit.Text, txtbuildingname.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country, txtpin.Text, llisd, txtllstd.Text, landline, mblisd, txtMobile.Text, faxisd, txtfaxstd.Text, int_fax, txtemail.Text, txtPanNo.Text, txtServiceTaxNo.Text, status, txtComMail.Text, txtExpMail.Text, txtImpMail.Text, txtFinMail.Text, txtComPTC.Text, txtExpPTC.Text, txtImpPTC.Text, txtFinPTC.Text, Convert.ToInt32(Session["LoginEmpId"]));
                        location.UpdCityportInLocation(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_locationid.Value));
                          obj_Details4Location.UpdPortFromCustomer(Convert.ToInt32(hf_districtid.Value), Convert.ToInt32(hf_stateid.Value), std, Convert.ToInt32(hf_portid.Value));
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Inserted Successfully');", true);
                    }
                    else
                    {
                        ckecK();

                    }

                }
                else
                {
                    int_location = Convert.ToInt32(hf_locationid.Value.ToString());
                    int_port = Convert.ToInt32(hf_portid.Value.ToString());
                    int_district = Convert.ToInt32(hf_districtid.Value.ToString());
                    int_state = Convert.ToInt32(hf_stateid.Value.ToString());
                    int_country = Convert.ToInt32(hf_countryid.Value.ToString());
                    llisd = Convert.ToInt32(txtllisd.Text.ToString());
                    landline = Convert.ToInt32(txtlandline.Text.ToString());
                    mblisd = Convert.ToInt32(txtmblisd.Text.ToString());
                    faxisd = Convert.ToInt32(txtfaxisd.Text.ToString());
                    int_fax = Convert.ToInt32(txtfax.Text.ToString());
                    int_customer = Convert.ToInt32(hf_customerid.Value.ToString());
                    if (Check4.Checked)
                    {

                        //obj_MasterCustomer.UpdMasterCustomer(txtcustomer.Text.ToUpper(), "P", txtunit.Text, txtbuildingname.T
                        obj_Details4Location.UpdPortFromCustomer(Convert.ToInt32(hf_districtid.Value), Convert.ToInt32(hf_stateid.Value), std, Convert.ToInt32(hf_portid.Value));
                     ////////   obj_MasterCustomer.UpdMasterCustomer(txtcustomer.Text.ToUpper(), "P", txtunit.Text, txtbuildingname.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country, txtpin.Text, llisd, txtllstd.Text, landline, mblisd, txtMobile.Text, faxisd, txtfaxstd.Text, int_fax, txtemail.Text, txtPanNo.Text, txtServiceTaxNo.Text, status, txtComMail.Text, txtExpMail.Text, txtImpMail.Text, txtFinMail.Text, txtComPTC.Text, txtExpPTC.Text, txtImpPTC.Text, txtFinPTC.Text, int_customer);
                        location.UpdCityportInLocation(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_locationid.Value));
                      
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Updated Successfully');", true);
                    }
                    else if (Check1.Checked || Check2.Checked || Check3.Checked || Check5.Checked || Check6.Checked || Check7.Checked || Check8.Checked || Check9.Checked || Check10.Checked || Check11.Checked)
                    {
                       // obj_MasterCustomer.UpdMasterCustomer(txtcustomer.Text.ToUpper(), "C", txtunit.Text, txtbuildingname.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country, txtpin.Text, llisd, txtllstd.Text, landline, mblisd, txtMobile.Text, faxisd, txtfaxstd.Text, int_fax, txtemail.Text, txtPanNo.Text, txtServiceTaxNo.Text, int_customer);
                    //////////    obj_MasterCustomer.UpdMasterCustomer(txtcustomer.Text.ToUpper(), "C", txtunit.Text, txtbuildingname.Text, txtdoor.Text, txtstreet.Text, int_location, int_port, int_district, int_state, int_country, txtpin.Text, llisd, txtllstd.Text, landline, mblisd, txtMobile.Text, faxisd, txtfaxstd.Text, int_fax, txtemail.Text, txtPanNo.Text, txtServiceTaxNo.Text, status, txtComMail.Text, txtExpMail.Text, txtImpMail.Text, txtFinMail.Text, txtComPTC.Text, txtExpPTC.Text, txtImpPTC.Text, txtFinPTC.Text, int_customer);
                        location.UpdCityportInLocation(Convert.ToInt32(hf_portid.Value), Convert.ToInt32(hf_locationid.Value));
                        obj_Details4Location.UpdPortFromCustomer(Convert.ToInt32(hf_districtid.Value), Convert.ToInt32(hf_stateid.Value), std, Convert.ToInt32(hf_portid.Value));
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert('Customer Details Updated Successfully');", true);
                    }
                    else
                    {
                        ckecK();
                    }
                }
                getgrid();
            }
            private void CkeckList()
            {

                Check1.Checked = true;
                Check2.Checked = true;
                Check3.Checked = true;
                Check5.Checked = true;
                Check6.Checked = true;
                Check7.Checked = true;
                Check8.Checked = true;
                Check9.Checked = true;
                Check10.Checked = true;
                Check11.Checked = true;

            }

            protected void Check4_CheckedChanged(object sender, EventArgs e)
            {
                Check1.Checked = false;
                Check2.Checked = false;
                Check3.Checked = false;
                Check5.Checked = false;
                Check6.Checked = false;
                Check7.Checked = false;
                Check8.Checked = false;
                Check9.Checked = false;
                Check10.Checked = false;
                Check11.Checked = false;
                type = 'C';
                if (txtcustomer.Text != "" && hf_customerid.Value != "" && type != ' ')
                {

                    getdetails();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert(' Select Valid Customer Type.....');", true);
                    Check1.Focus();
                }
            }
            protected void Check1_CheckedChanged(object sender, EventArgs e)
            {
                Check4.Checked = false;
                type = 'C';
                if (txtcustomer.Text != "" && hf_customerid.Value != "" && type != ' ')
                {

                    getdetails();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert(' Select Valid Customer Type.....');", true);
                    Check1.Focus();
                }
            }
            protected void Check2_CheckedChanged(object sender, EventArgs e)
            {
                Check4.Checked = false;
                type = 'C';
                if (txtcustomer.Text != "" && hf_customerid.Value != "" && type != ' ')
                {

                    getdetails();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert(' Select Valid Customer Type.....');", true);
                    Check1.Focus();
                }
            }

            protected void Check3_CheckedChanged(object sender, EventArgs e)
            {
                Check4.Checked = false;
                type = 'C';
                if (txtcustomer.Text != "" && hf_customerid.Value != "" && type != ' ')
                {

                    getdetails();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert(' Select Valid Customer Type.....');", true);
                    Check1.Focus();
                }
            }

            protected void Check5_CheckedChanged(object sender, EventArgs e)
            {
                Check4.Checked = false;
                type = 'C';
                if (txtcustomer.Text != "" && hf_customerid.Value != "" && type != ' ')
                {

                    getdetails();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert(' Select Valid Customer Type.....');", true);
                    Check1.Focus();
                }
            }

            protected void Check6_CheckedChanged(object sender, EventArgs e)
            {
                Check4.Checked = false;
                type = 'C';
                if (txtcustomer.Text != "" && hf_customerid.Value != "" && type != ' ')
                {

                    getdetails();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert(' Select Valid Customer Type.....');", true);
                    Check1.Focus();
                }
            }

            protected void Check7_CheckedChanged(object sender, EventArgs e)
            {
                Check4.Checked = false;
                type = 'C';
                if (txtcustomer.Text != "" && hf_customerid.Value != "" && type != ' ')
                {

                    getdetails();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert(' Select Valid Customer Type.....');", true);
                    Check1.Focus();
                }
            }

            protected void Check8_CheckedChanged(object sender, EventArgs e)
            {
                Check4.Checked = false;
                type = 'C';
                if (txtcustomer.Text != "" && hf_customerid.Value != "" && type != ' ')
                {

                    getdetails();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert(' Select Valid Customer Type.....');", true);
                    Check1.Focus();
                }
            }

            protected void Check9_CheckedChanged(object sender, EventArgs e)
            {
                Check4.Checked = false;
                type = 'C';
                if (txtcustomer.Text != "" && hf_customerid.Value != "" && type != ' ')
                {

                    getdetails();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert(' Select Valid Customer Type.....');", true);
                    Check1.Focus();
                }
            }

            protected void Check10_CheckedChanged(object sender, EventArgs e)
            {
                Check4.Checked = false;
                type = 'C';
                if (txtcustomer.Text != "" && hf_customerid.Value != "" && type != ' ')
                {

                    getdetails();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert(' Select Valid Customer Type.....');", true);
                    Check1.Focus();
                }
            }
            protected void Check11_CheckedChanged(object sender, EventArgs e)
            {
                Check4.Checked = false;
                type = 'C';
                if (txtcustomer.Text != "" && hf_customerid.Value != "" && type != ' ')
                {

                    getdetails();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert(' Select Valid Customer Type.....');", true);
                    Check1.Focus();
                }
            }

            protected void btnView_Click(object sender, EventArgs e)
            {
                getgrid();
                signup.Visible = true;
            }

            protected void btnBack_Click(object sender, EventArgs e)
            {
                if (btnBack.Text == "Back")
                {
                    this.Response.End();
                }
                else
                {
                    clear();
                    btnBack.Text = "Back";
                }
            }

            protected void txtcustomer_TextChanged(object sender, EventArgs e)
            {
                //btnSave.Enabled = true;
                ////btnDelete.Enabled = true;
                //btnBack.Text = "Cancel";
                //dt = obj_MasterCustomer.GetCustomerNameExist(txtcustomer.Text.ToUpper());
                //if (dt.Rows.Count > 0)
                //{
                //    // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('Customer Name Already Exists.....');", true);
                //    hf_customerid.Value = dt.Rows[0]["customerid"].ToString();
                //    btnSave.Text = "Update";
                //}
               // btnSave.Text = "Update";
                btnDelete.Enabled = false;
                gettype();
                if (txtcustomer.Text != "" && hf_customerid.Value != "" && type != ' ')
                {

                    getdetails();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Customer", "alertify.alert(' Select Customer Type.....');", true);
                    Check1.Focus();
                }
            }

            //protected void txtpin_TextChanged(object sender, EventArgs e)
            //{
            //    DataTable dt = new DataTable();
            //    dt = location.GetPincodeDetailsForLocation(txtpin.Text );
            //    if(dt.Rows.Count>0)
            //    {
            //        lstlocation.Items.Clear();
            //        lstlocation.DataSource = dt;
            //        lstlocation.DataValueField = "Location";
            //        lstlocation.DataBind();
            //        txtlocation.Text = lstlocation.SelectedValue;
            //        if (dt.Rows[0]["cityport"].ToString() == "")
            //        {
            //            txtcity.Enabled = true;
            //            txtcity.Text = "";
            //            hf_portid.Value = "";

            //          //  txtlocation.Text = dt.Rows[0]["Location"].ToString();
            //           // hf_locationid.Value = dt.Rows[0]["LocationId"].ToString();
            //            txtdistrict.Text = dt.Rows[0]["Districts"].ToString();
            //            hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
            //            txtstate.Text = dt.Rows[0]["States"].ToString();
            //            hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
            //            txtcountry.Text = dt.Rows[0]["CountryName"].ToString();
            //            hf_countryid.Value = dt.Rows[0]["Countryid"].ToString();
            //          //  txtpin.Text = dt.Rows[0]["pincode"].ToString();
            //           // txtllisd.Text = dt.Rows[0]["ISDcode"].ToString();
            //          //  txtmblisd.Text = dt.Rows[0]["ISDcode"].ToString();
            //          //  txtfaxisd.Text = dt.Rows[0]["ISDcode"].ToString();
            //        }
            //        else if(dt.Rows[0]["cityport"].ToString() != "")
            //        {
            //            hf_portid.Value = dt.Rows[0]["cityport"].ToString();
            //            hf_locationid.Value = dt.Rows[0]["LocationId"].ToString();
            //            dt = obj_Details4Location.GETDetails4LocationIntNewPort(Convert.ToInt32(hf_locationid.Value), Convert.ToInt32(hf_portid.Value));
            //            txtcity.Text = dt.Rows[0]["portname"].ToString();
            //            hf_portid.Value = dt.Rows[0]["cityport"].ToString();
            //            txtdistrict.Text = dt.Rows[0]["Districts"].ToString();
            //            hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
            //            txtstate.Text = dt.Rows[0]["States"].ToString();
            //            hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
            //            txtcountry.Text = dt.Rows[0]["CountryName"].ToString();
            //            hf_countryid.Value = dt.Rows[0]["Countryid"].ToString();
            //            txtpin.Text = dt.Rows[0]["pincode"].ToString();
            //            txtllisd.Text = dt.Rows[0]["ISDcode"].ToString();
            //            txtllstd.Text = dt.Rows[0]["stdcode"].ToString();
            //            txtmblisd.Text = dt.Rows[0]["ISDcode"].ToString();
            //            txtfaxisd.Text = dt.Rows[0]["ISDcode"].ToString();
            //            txtfaxstd.Text = dt.Rows[0]["stdcode"].ToString();
            //        }

            //    }
            //}

            protected void txtcity_TextChanged(object sender, EventArgs e)
            {
          DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
          if (hf_portid.Value != "")
          {
              dt = obj_MasterPort.GetPortDetailsNew(Convert.ToInt32(hf_portid.Value));
              if (dt.Rows.Count > 0)
              {
                  hf_portid.Value = dt.Rows[0]["portid"].ToString();
                  txtllstd.Text = dt.Rows[0]["stdcode"].ToString();
                  txtfaxstd.Text = dt.Rows[0]["stdcode"].ToString();
              }
              else
              {
                  ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('Enter Valid City');", true);
                  txtcity.Text = "";
              }

           }
        }

            protected void lstlocation_SelectedIndexChanged(object sender, EventArgs e)
           {
               lstlocation.Visible = false ;
               txtlocation.Text = lstlocation.SelectedValue.ToString();
               DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
               dt = objp_location.CheckDuplicateForLocationPincode(txtlocation.Text,txtpin.Text );
               if (dt.Rows.Count > 0)
               { 
                   hf_locationid.Value = dt.Rows[0]["locationid"].ToString();
               }
               if (txtlocation.Text != "" && hf_locationid.Value != "")
               {
                   getlocationdetails();
                   //if (dt.Rows[0]["cityport"].ToString() == "")
                   //{
                   //    txtcity.Enabled = true;
                   //    txtcity.Text = "";
                   //    hf_portid.Value = "";

                   //    //  txtlocation.Text = dt.Rows[0]["Location"].ToString();
                   //    // hf_locationid.Value = dt.Rows[0]["LocationId"].ToString();
                   //    txtdistrict.Text = dt.Rows[0]["Districts"].ToString();
                   //    hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                   //    txtstate.Text = dt.Rows[0]["States"].ToString();
                   //    hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                   //    txtcountry.Text = dt.Rows[0]["CountryName"].ToString();
                   //    hf_countryid.Value = dt.Rows[0]["Countryid"].ToString();
                   //    //  txtpin.Text = dt.Rows[0]["pincode"].ToString();
                   //    // txtllisd.Text = dt.Rows[0]["ISDcode"].ToString();
                   //    //  txtmblisd.Text = dt.Rows[0]["ISDcode"].ToString();
                   //    //  txtfaxisd.Text = dt.Rows[0]["ISDcode"].ToString();
                   //}
                   //else if (dt.Rows[0]["cityport"].ToString() != "")
                   //{
                   //    hf_portid.Value = dt.Rows[0]["cityport"].ToString();
                   //    // hf_locationid.Value = dt.Rows[0]["LocationId"].ToString();
                   //    dt = obj_Details4Location.GETDetails4LocationIntNewPort(Convert.ToInt32(hf_locationid.Value), Convert.ToInt32(hf_portid.Value));
                   //    txtcity.Text = dt.Rows[0]["portname"].ToString();
                   //    hf_portid.Value = dt.Rows[0]["cityport"].ToString();
                   //    txtdistrict.Text = dt.Rows[0]["Districts"].ToString();
                   //    hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                   //    txtstate.Text = dt.Rows[0]["States"].ToString();
                   //    hf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                   //    txtcountry.Text = dt.Rows[0]["CountryName"].ToString();
                   //    hf_countryid.Value = dt.Rows[0]["Countryid"].ToString();
                   //    txtpin.Text = dt.Rows[0]["pincode"].ToString();
                   //    txtllisd.Text = dt.Rows[0]["ISDcode"].ToString();
                   //    txtllstd.Text = dt.Rows[0]["stdcode"].ToString();
                   //    txtmblisd.Text = dt.Rows[0]["ISDcode"].ToString();
                   //    txtfaxisd.Text = dt.Rows[0]["ISDcode"].ToString();
                   //    txtfaxstd.Text = dt.Rows[0]["stdcode"].ToString();
                   //}

               }
            }
            protected void rdbNewCustomer_CheckedChanged(object sender, EventArgs e)
            {
                rdbExisting.Checked = false;
                rdbFollowUp.Checked = false;
            }
            protected void rdbFollowUp_CheckedChanged(object sender, EventArgs e)
            {
                rdbExisting.Checked = false;
                rdbNewCustomer.Checked = false;
            }

            protected void rdbExisting_CheckedChanged(object sender, EventArgs e)
            {
                rdbFollowUp.Checked = false;
                rdbNewCustomer.Checked = false;
            }
            private void custDetails()
            {
                if (rdbNewCustomer.Checked == true)
                {
                    status = 'N';
                    rdbExisting.Checked = false;
                    rdbFollowUp.Checked = false;
                }
                if (rdbFollowUp.Checked == true)
                {
                    rdbExisting.Checked = false;
                    rdbNewCustomer.Checked = false;
                    status = 'F';
                }
                if (rdbExisting.Checked == true)
                {
                    rdbFollowUp.Checked = false;
                    rdbNewCustomer.Checked = false;
                    status = 'E';
                }
            }

            protected void txtpin_TextChanged(object sender, EventArgs e)
            {
                btnDelete.Enabled = false;
                DataTable dt = new DataTable();
                dt = location.GetPincodeDetailsForLocation(txtpin.Text);
                if (dt.Rows.Count > 0)
                {
                    lstlocation.Visible = true;
                    lstlocation.Items.Clear();
                    lstlocation.DataSource = dt;
                    lstlocation.DataValueField = "Location";
                    lstlocation.DataBind();
                   
                }
                
            }
            private void getdetails()
            {
                gettype();
                getport();
                if (type == 'P')
                {

                    dt = obj_MasterCustomer.SPSelGetCustomerDetails(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
                    if (dt.Rows.Count > 0)
                    {
                        txtstreet.Text = dt.Rows[0]["street"].ToString();
                        hf_portid.Value = dt.Rows[0]["cityid"].ToString();
                        txtpin .Text = dt.Rows[0]["pincode"].ToString();
                        txtlandline.Text = dt.Rows[0]["landline"].ToString();
                        txtfax.Text = dt.Rows[0]["fax"].ToString();
                        txtemail.Text = dt.Rows[0]["email"].ToString();
                        txtPanNo.Text = dt.Rows[0]["panno"].ToString();
                        txtServiceTaxNo.Text = dt.Rows[0]["stno"].ToString();
                        dt = location.GetPincodeDetailsForLocation(txtpin.Text);
                        if (dt.Rows.Count > 0)
                        {
                            lstlocation.Visible = true;
                            lstlocation.Items.Clear();
                            lstlocation.DataSource = dt;
                            lstlocation.DataValueField = "Location";
                            lstlocation.DataBind();

                        }
                        btnSave.Text = "Update";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('Enter Valid Customer Type');", true);
                    }
                }
                else if (type == 'C')
                {
                    dt = obj_MasterCustomer.SPSelGetCustomerDetails(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
                    if (dt.Rows.Count > 0)
                    {
                        txtstreet.Text = dt.Rows[0]["street"].ToString();
                        hf_portid.Value = dt.Rows[0]["cityid"].ToString();
                        txtpin .Text = dt.Rows[0]["pincode"].ToString();
                        txtlandline.Text = dt.Rows[0]["landline"].ToString();
                        txtfax.Text = dt.Rows[0]["fax"].ToString();
                        txtemail.Text = dt.Rows[0]["email"].ToString();
                        txtPanNo.Text = dt.Rows[0]["panno"].ToString();
                        txtServiceTaxNo.Text = dt.Rows[0]["stno"].ToString();
                        dt = location.GetPincodeDetailsForLocation(txtpin.Text);
                        if (dt.Rows.Count > 0)
                        {
                            lstlocation.Visible = true;
                            lstlocation.Items.Clear();
                            lstlocation.DataSource = dt;
                            lstlocation.DataValueField = "Location";
                            lstlocation.DataBind();

                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('Enter Valid Customer Type');", true);
                    }
                }

            }
            private void gettype()
            {
                if (Check4.Checked)
                {
                    type = 'P';
                }
                else if (Check1.Checked || Check2.Checked || Check3.Checked || Check5.Checked || Check6.Checked || Check7.Checked || Check8.Checked || Check9.Checked || Check10.Checked || Check11.Checked)
                {
                    type = 'C';
                }
                else
                {
                    type = ' ';
                }
            }
            private void getport()
            {
                dt = obj_MasterCustomer.SPSelGetCustomerDetails(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
                if (dt.Rows.Count > 0)
                {
                    hf_portid.Value = dt.Rows[0]["city"].ToString();
                    if (hf_portid.Value != "")
                    {
                        dt = port.SPSelGetPortNameFromId(Convert.ToInt32(hf_portid.Value));
                        if (dt.Rows.Count > 0)
                        {
                            txtcity.Text = dt.Rows[0]["portname"].ToString();
                        }

                    }
                    else
                    {
                        dt = obj_MasterCustomer.SPSelGetCustomerDetails(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["zip"].ToString() != "")
                            {
                                txtpin.Text = dt.Rows[0]["zip"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    dt = obj_MasterCustomer.SPSelGetCustomerDetails(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
                    if (dt.Rows.Count > 0)
                    {
                        hf_portid.Value = dt.Rows[0]["cityid"].ToString();
                        if (hf_portid.Value != "")
                        {
                            dt = port.SPSelGetPortNameFromId(Convert.ToInt32(hf_portid.Value));
                            if (dt.Rows.Count > 0)
                            {
                                txtcity.Text = dt.Rows[0]["portname"].ToString();
                                hf_portid.Value = dt.Rows[0]["portid"].ToString();
                            }
                            dt = obj_MasterCustomer.SPSelGetCustomerDetails(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["pincode"].ToString() != "")
                                {
                                    txtpin.Text = dt.Rows[0]["pincode"].ToString();
                                    dt1 = location.GetPincodeDetailsForLocation(txtpin.Text);
                                    if (dt1.Rows.Count > 0)
                                    {

                                    }
                                }
                            }

                        }
                        else
                        {


                        }
                    }
                }
            }
          
    }
}