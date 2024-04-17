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

namespace logix.Maintenance
{
    public partial class Mastercustomertds : System.Web.UI.Page
    {
        DataAccess.Masters.MasterTDSType obj_da_TDS = new DataAccess.Masters.MasterTDSType();
        string hidcountrid;
        string txtcustomer;
        bool blnerr = false;
        string txtpanno, customerid;
        DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable obj_dt = new DataTable();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "dropdownButton();SpanTagMoveInputBottom();MuiTextField();", true);
            DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();
            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Grd_MAsterCredit);
            //panno = Session["pannocredit"].ToString();
            //customerpan = Session["pancustomercredit"].ToString();
            //gst = Session["gst"].ToString();
            //hf_employeeid = Session["hf_employeeided"].ToString();

            if (!IsPostBack)
            {
                txtpanno = Session["panno"].ToString();
                txtcustomer = Session["pancustomer"].ToString();
                hidcountrid = Session["customerCountryid"].ToString();
                customerid = Session["customerid"].ToString();
                if (!string.IsNullOrEmpty(Session["pancustomer"].ToString()))
                {
                    string customername = Session["pancustomer"].ToString();
                    lblcustomername.Text = customername.ToUpper();
                }
                if (!string.IsNullOrEmpty(Session["panno"].ToString()))
                {
                    lblpanno.Text = Session["panno"].ToString();
                }
                else
                {
                    plblan.Visible = false;
                }
                if (!string.IsNullOrEmpty(Session["hidpaninput"].ToString()))
                {
                    hidpaninput.Value = Session["hidpaninput"].ToString();
                    if (hidpaninput.Value == "Y")
                    {
                        plblan.Visible = false;
                    }
                }
                ClearSlap();
                custds();               
                GetFilldetails();
                getdetails4pan();
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

                txtpanno = Session["panno"].ToString();
                txtcustomer = Session["pancustomer"].ToString();
                hidcountrid = Session["customerCountryid"].ToString();
                customerid = Session["customerid"].ToString();
                if (!string.IsNullOrEmpty(Session["pancustomer"].ToString()))
                {
                    lblcustomername.Text = Session["pancustomer"].ToString();
                }
                if (!string.IsNullOrEmpty(Session["panno"].ToString()))
                {
                    lblpanno.Text = Session["panno"].ToString();
                }
                else
                {
                    plblan.Visible = false;
                }
            }
            //ddl_type_fn();
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

            //btnSave.Enabled = true;
            //btnSave.ToolTip = "Save";

            //btnSave1.Attributes["class"] = "btn ico-save";
        }


        public void GetFilldetails()
        {
            DataTable dt = new DataTable();
            dt = obj_MasterCustomer.SPSelGetCustomerDetails(txtcustomer, Convert.ToInt32(customerid));
            if (dt.Rows.Count > 0)
            {
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
            }
            CustomerTDS();
        }


        public void CustomerTDS()
        {
            if (txtcustomer.Trim().Length > 0)
            {
                //custds();
                DataTable obj_dttemp = new DataTable();
                obj_dttemp = obj_da_TDS.GetTDSDtlsForCustomer(int.Parse(customerid.ToString()));

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
                        ddl_percentage.SelectedItem.Text = obj_dttemp.Rows[0][4].ToString();
                    }
                    else
                    {
                        ddl_percentage.Items.Add(obj_dttemp.Rows[0][4].ToString());
                    }

                    //btnSave.ToolTip = "Update";
                    //btnSave1.Attributes["class"] = "btn btn-update1";
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
                //btnSave.Enabled = true;
            }
        }

        protected void Fn_percentage_tds()
        {
            DataTable obj_dt = new DataTable();
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

        public void custds()
        {
            DataTable obj_dt = new DataTable();
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


        protected void ddl_description_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hidcountrid != "" && (hidcountrid == "1102" || hidcountrid == "102"))
            {

            }
            else
            {
                if (hidcountrid == "")
                {
                    ddl_description.SelectedIndex = 0;
                    ddl_type.SelectedIndex = 0;
                    ddl_slab.SelectedIndex = 0;
                    ddl_percentage.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "CustomerTDS", "alertify.alert('TDS Will Be Apply Only Based on the Customers Country, Enter Customer Details');", true);
                    return;
                }
                else if (hidcountrid != "1102" && hidcountrid != "102")
                {
                    ddl_description.SelectedIndex = 0;
                    ddl_type.SelectedIndex = 0;
                    ddl_slab.SelectedIndex = 0;
                    ddl_percentage.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "CustomerTDS", "alertify.alert('You Can Only Save TDS To Indian Customers, Not Other Country');", true);
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
          //  ddl_type_fn();
        }

        protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_description.SelectedItem.Text != "")
            {
                ddl_type_fn();
            }
            else
            {
                ddl_type.SelectedIndex = 0;
                // ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "CustomerTDS", "alertify.alert('Select Description');", true);
                return;
            }
        }

        protected void ddl_type_fn()
        {
            try
            {
                DataAccess.Masters.MasterTDSType obj_da_TDS = new DataAccess.Masters.MasterTDSType();
                DataTable obj_dt = new DataTable();
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
                percentage();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        public void percentage()
        {
            try
            {
                DataTable obj_dt = new DataTable();
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


        protected void ddl_slab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
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
                if (hidcountrid == "" || hidcountrid == "0")
                {
                    hidcountrid = obj_MasterCustomer.GetCustomerid(txtcustomer.ToUpper()).ToString();
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
                        ScriptManager.RegisterStartupScript(this, typeof(Button), "CustomerTDS", "alertify.alert('Select Vaild Details');", true);
                    }
                    else
                    {
                        obj_da_TDS.UpdTDSidnew(int_TDSid, int.Parse(customerid.ToString()), double.Parse(ddl_percentage.SelectedItem.Text));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }


        protected void btnsave_Click(object sender, EventArgs e)
        {
            DateTime empfrom, empto;
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

            obj_MasterCustomer.Sp_UploadLimitDetails(Convert.ToDouble(txt_limit.Text), empfrom, empto, txt_certno.Text, Convert.ToInt32(customerid), Convert.ToDouble(txt_tds_exp.Text));
            savetds();
            ScriptManager.RegisterStartupScript(this, typeof(Button), "CustomerTDS", "alertify.alert('Details Added');", true);
        }

        protected void btnpancancel_Click(object sender, EventArgs e)
        {
            txt_limit.Text = "";
            txt_tds_exp.Text = "";
            ddl_description.SelectedIndex = 0;
            ddl_type.SelectedIndex = 0;
            ddl_slab.SelectedIndex = 0;
            ddl_percentage.SelectedIndex = 0;
            txt_empfrom.Text = "";
            txt_empto.Text = "";
            txt_certno.Text = "";
        }


        private void getdetails4pan()
        {
            DataTable dt = new DataTable();
            dt = obj_MasterCustomer.SPSelGetCustomerDetails4pan(txtcustomer, Convert.ToInt32(customerid), "");
            if (dt.Rows.Count > 0)
            {
                Session["data"] = dt;
            }
            if (dt.Rows.Count > 0)
            {
                //hid_pan.Value = dt.Rows[0]["CustomerPANId"].ToString();

                //if (hid_pan.Value != "")
                //{
                //    kycGrid();
                //}
                //Banking();
                //// txtcustomer.Text = txtpancust.Text;
                //if (dt.Rows[0]["customertype"].ToString() == "C")
                //{
                //    ddlCType.SelectedValue = "C";
                //}
                //else if (dt.Rows[0]["customertype"].ToString() == "P")
                //{
                //    ddlCType.SelectedValue = "P";
                //}
                //else if (dt.Rows[0]["customertype"].ToString() == "W")
                //{
                //    ddlCType.SelectedValue = "W";
                //}
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
                customerid = dt.Rows[0]["customerid"].ToString();
                //txtstreet.Text = dt.Rows[0]["address"].ToString();
                //hf_portid.Value = dt.Rows[0]["city"].ToString();
                //Session["portid"] = hf_portid.Value;
                //txtcity.Text = port.GetPortname(Convert.ToInt32(hf_portid.Value));
                //hf_countryid.Value = Convert.ToString(port.SPSelPortByCountryId(txtcity.Text.ToUpper()));
                //txtcountry.Text = countryobj.GetCountryNamefrmid(Convert.ToInt32(hf_countryid.Value));
                //txtpincode.Text = dt.Rows[0]["zip"].ToString();
                //txtllisd.Text = dt.Rows[0]["llisd"].ToString();
                //txtllstd.Text = dt.Rows[0]["llstd"].ToString();
                //txtlandline.Text = dt.Rows[0]["phone"].ToString();
                //txtfaxisd.Text = dt.Rows[0]["faxisd"].ToString();
                //txtfaxstd.Text = dt.Rows[0]["faxstd"].ToString();
                //txtfax.Text = dt.Rows[0]["fax"].ToString();
                //txtemail.Text = dt.Rows[0]["email"].ToString();
                ////txt_Salesperson.Text = dt.Rows[0]["empname"].ToString();
                //string empcode = dt.Rows[0]["employeeid"].ToString();
                //if (empcode != "")
                //{
                //    hf_employeeid.Value = empcode;
                //    txt_Salesperson.Text = dt.Rows[0]["empname"].ToString();
                //}
                ////    txtPanNo.Text = dt.Rows[0]["panno"].ToString();
                ////  DataTable grid = obj_MasterCustomer.Getcustgridwithpan(dt.Rows[0]["panno"].ToString());
                ////if (grid.Rows.Count > 0)
                ////{
                ////    grd.DataSource = grid;
                ////    grd.DataBind();
                ////}
                //txtServiceTaxNo.Text = dt.Rows[0]["stno"].ToString();
                ////txtpancust.Text = txtcustomer.Text;
                ///***********************************************/
                //txtunit.Text = dt.Rows[0]["unit#"].ToString();
                //txtbuildingname.Text = dt.Rows[0]["buildingname"].ToString();
                //txtdoor.Text = dt.Rows[0]["door#"].ToString();
                //hf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                //hf_stateid.Value = dt.Rows[0]["stateid"].ToString();

                //txttds.Text = dt.Rows[0]["tds"].ToString();

                ////txtfax.Text = dt.Rows[0]["fax"].ToString();
                //txtmblisd.Text = dt.Rows[0]["mblisd"].ToString();
                //txtMobile.Text = dt.Rows[0]["mobile"].ToString();
                ////status = Convert.ToChar(dt.Rows[0]["status"].ToString());
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
                //txt_gstin.Text = dt.Rows[0]["gstin"].ToString();
                ////txt_uinno.Text = dt.Rows[0]["uinno"].ToString();
                ////txttanno.Text = dt.Rows[0]["tanno"].ToString();
                ////txtcinno.Text = dt.Rows[0]["cinno"].ToString();
                //if (txt_gstin.Text != "")
                //{
                //    //txt_RCM.Enabled = false;
                //    //txt_unregistered.Enabled = false;
                //    //txt_RCM.Checked = false;
                //    //txt_unregistered.Checked = false;
                //}
                //else
                //{
                //    //txt_RCM.Enabled = true;
                //    //txt_unregistered.Enabled = true;
                //}
                //card.Text = txtcustomer.Text + " GST #  " + txt_gstin.Text;
                //if (txt_uinno.Text != "")
                //{
                //    //txt_RCM.Enabled = false;
                //    //txt_unregistered.Enabled = false;
                //    //txt_RCM.Checked = false;
                //    //txt_unregistered.Checked = false;
                //}
                //else
                //{
                //    //txt_RCM.Enabled = true;
                //    //txt_unregistered.Enabled = true;
                //}
                //if (dt.Rows[0]["RCM"].ToString() == "Y")
                //{
                //    // txt_RCM.Checked = true;
                //    ddl_Option.SelectedValue = "1";
                //}
                //else if (dt.Rows[0]["UnRegistered"].ToString() == "Y")
                //{
                //    ddl_Option.SelectedValue = "2";
                //}
                //else if (dt.Rows[0]["UnRegistered"].ToString() == "A")
                //{
                //    ddl_Option.SelectedValue = "7";
                //    ddl_Option.Enabled = false;
                //}
                //else if (dt.Rows[0]["gstexemption"].ToString() == "Y")
                //{
                //    ddl_Option.SelectedValue = "3";
                //}
                //else if (dt.Rows[0]["Sez"].ToString() == "Y")
                //{
                //    ddl_Option.SelectedValue = "6";
                //}
                //else if (dt.Rows[0]["Register"].ToString() == "Y")
                //{
                //    ddl_Option.SelectedValue = "5";
                //}
                //else if (dt.Rows[0]["SezIgst"].ToString() == "Y")
                //{
                //    ddl_Option.SelectedValue = "4";
                //    // txt_gstexi.Checked = true;
                //}
                ////else if (dt.Rows[0]["Not Applicable"].ToString() == "A")
                ////{
                ////    ddl_Option.SelectedValue = "7";
                ////    // txt_gstexi.Checked = true;
                ////}
                ////else
                ////{
                ////    ddl_Option.SelectedValue = "0";
                ////}
                ////newly added on 07012022 
                //if (dt.Rows[0]["IsCoload"].ToString() == "Y")
                //{
                //    ChkCoload.Checked = true;
                //    txt_Coloadercode.Enabled = true;
                //    txt_ColoadRemarks.Enabled = true;
                //    if (!string.IsNullOrEmpty(dt.Rows[0]["ColoadRemarks"].ToString()) == true)
                //    {
                //        txt_ColoadRemarks.Text = dt.Rows[0]["ColoadRemarks"].ToString();

                //    }
                //    if (!string.IsNullOrEmpty(dt.Rows[0]["Coloadercode"].ToString()) == true)
                //    {
                //        txt_Coloadercode.Text = dt.Rows[0]["Coloadercode"].ToString();

                //    }
                //}
                //else
                //{
                //    ChkCoload.Checked = false;
                //    txt_ColoadRemarks.Enabled = false;
                //    txt_Coloadercode.Enabled = false;
                //}
                ////end
                //byte[] imageByte = null;
                //if (!DBNull.Value.Equals(dt.Rows[0]["mgmtheadimg"]))
                //{
                //    imageByte = ((byte[])dt.Rows[0]["mgmtheadimg"]);
                //    string base64String = Convert.ToBase64String(imageByte);
                //    hdn_Flag.Value = base64String;
                //    Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                //    if (base64String == "")
                //    {
                //        Img_Emp.ImageUrl = "~/images/visitingcard_img.jpg";
                //    }
                //    else
                //    {
                //        Img_Emp.ImageUrl = "data:image/png;base64," + base64String;
                //    }
                //}
                //else
                //{
                //    Img_Emp.ImageUrl = "~/images/visitingcard_img.jpg";
                //}
                //if (!DBNull.Value.Equals(dt.Rows[0]["cmheadimg"]))
                //{

                //    imageByte = ((byte[])dt.Rows[0]["cmheadimg"]);
                //    string base64String = Convert.ToBase64String(imageByte);
                //    hdn_Flag.Value = base64String;
                //    Img_Emp1.ImageUrl = "data:image/png;base64," + base64String;
                //    if (base64String == "")
                //    {
                //        Img_Emp1.ImageUrl = "~/images/visitingcard_img.jpg";
                //    }
                //    else
                //    {
                //        Img_Emp1.ImageUrl = "data:image/png;base64," + base64String;
                //    }
                //}
                //else
                //{
                //    Img_Emp1.ImageUrl = "~/images/visitingcard_img.jpg";
                //}
                //if (!DBNull.Value.Equals(dt.Rows[0]["expheadimg"]))
                //{
                //    imageByte = ((byte[])dt.Rows[0]["expheadimg"]);
                //    string base64String = Convert.ToBase64String(imageByte);
                //    hdn_Flag.Value = base64String;
                //    Img_Emp2.ImageUrl = "data:image/png;base64," + base64String;
                //    if (base64String == "")
                //    {
                //        Img_Emp2.ImageUrl = "~/images/visitingcard_img.jpg";
                //    }
                //    else
                //    {
                //        Img_Emp2.ImageUrl = "data:image/png;base64," + base64String;
                //    }
                //}
                //else
                //{
                //    Img_Emp2.ImageUrl = "~/images/visitingcard_img.jpg";
                //}
                //if (!DBNull.Value.Equals(dt.Rows[0]["finheadimg"]))
                //{

                //    imageByte = ((byte[])dt.Rows[0]["finheadimg"]);
                //    string base64String = Convert.ToBase64String(imageByte);
                //    hdn_Flag.Value = base64String;
                //    Img_Emp3.ImageUrl = "data:image/png;base64," + base64String;
                //    if (base64String == "")
                //    {
                //        Img_Emp3.ImageUrl = "~/images/visitingcard_img.jpg";
                //    }
                //    else
                //    {
                //        Img_Emp3.ImageUrl = "data:image/png;base64," + base64String;
                //    }
                //}
                //else
                //{
                //    Img_Emp3.ImageUrl = "~/images/visitingcard_img.jpg";
                //}

                //if (!DBNull.Value.Equals(dt.Rows[0]["impimg"]))
                //{
                //    imageByte = ((byte[])dt.Rows[0]["impimg"]);
                //    string base64String = Convert.ToBase64String(imageByte);
                //    hdn_Flag.Value = base64String;
                //    Img_Emp4.ImageUrl = "data:image/png;base64," + base64String;
                //    if (base64String == "")
                //    {
                //        Img_Emp4.ImageUrl = "~/images/visitingcard_img.jpg";
                //    }
                //    else
                //    {
                //        Img_Emp4.ImageUrl = "data:image/png;base64," + base64String;
                //    }
                //}
                //else
                //{
                //    Img_Emp4.ImageUrl = "~/images/visitingcard_img.jpg";
                //}

                //hf_locationid.Value = dt.Rows[0]["locationid"].ToString();

                //if (dt.Rows[0]["Register"].ToString() == "Y")
                //{
                //    DataTable DtNew = obj_MasterCustomer.checkvoucherraise(Convert.ToInt32(hf_customerid.Value));
                //    if (DtNew.Rows.Count > 0)
                //    {
                //        ddl_Option.Enabled = false;
                //    }
                //    else
                //    {
                //        ddl_Option.Enabled = true;
                //    }
                //}
                //else
                //{
                //    DataTable DtNew = obj_MasterCustomer.checkvoucherraise(Convert.ToInt32(hf_customerid.Value));
                //    if (DtNew.Rows.Count > 0)
                //    {
                //        if (dt.Rows[0]["UnRegistered"].ToString() == "Y")
                //        {
                //            ddl_Option.Enabled = true;
                //        }
                //        else
                //        {
                //            ddl_Option.Enabled = false;
                //        }
                //    }
                //    else if (dt.Rows[0]["UnRegistered"].ToString() == "A")
                //    {
                //        ddl_Option.Enabled = false;
                //    }
                //    else
                //    {
                //        ddl_Option.Enabled = true;
                //    }
                //}
                //if (ddl_Option.SelectedValue == "0")
                //{
                //    ddl_Option.Enabled = true;
                //}
                //if (hf_locationid.Value != "" && hf_locationid.Value != "0")
                //{
                //    txtlocation.Text = obj_MasterCustomer.GetLocationname(Convert.ToInt32(hf_locationid.Value));
                //    ddllocation.Visible = false;
                //    btndelete.Enabled = true;
                //    btndelete.ForeColor = System.Drawing.Color.White;
                //}
                //else
                //{
                //    if (txtpincode.Text == "")
                //    {
                //        txtpincode.Focus();
                //        btndelete.Enabled = false;
                //        btndelete.ForeColor = System.Drawing.Color.Gray;
                //    }
                //    else
                //    {
                //        dt = location.GetPincodeDetailsForLocation(txtpincode.Text);
                //        if (dt.Rows.Count > 1)
                //        {
                //            txtlocation.Visible = false;
                //            ddllocation.Visible = true;
                //            btndelete.Enabled = false;
                //            btndelete.ForeColor = System.Drawing.Color.Gray;
                //            ddllocation.Items.Clear();
                //            ddllocation.Items.Add("");
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
                //            btndelete.ForeColor = System.Drawing.Color.Gray;
                //            txtlocation.Text = dt.Rows[0]["Location"].ToString();
                //            hf_locationid.Value = dt.Rows[0]["LocationId"].ToString();
                //            txtlocationTxtChange();
                //        }
                //    }
                //}
                //btnSave.Enabled = true;
                //btnSave.ToolTip = "Update";
                //btnSave1.Attributes["class"] = "btn btn-update1";
                //btnBack.ToolTip = "Clear";
                //btnBack1.Attributes["class"] = "btn ico-cancel";
                //btnpanadd.ToolTip = "Update";
                //btnpanadd1.Attributes["class"] = "btn btn-update1";
                //btnpancancel.ToolTip = "Cancel";
                //// btnpanadd1.Attributes["class"] = "btn ico-cancel";
                //if (txtcountry.Text.ToUpper() != "INDIA")
                //{
                //    txtdistrict.ReadOnly = true;
                //    txtstate.ReadOnly = true;
                //    txtcountry.ReadOnly = true;
                //}
                //dts = obj_MasterCustomer.SPSelGetCustomerDetailsGSTIN(txtcustomer.Text, Convert.ToInt32(hf_customerid.Value));
                //if (dts.Rows.Count > 0)
                //{
                //    txtGSTCode.Text = dts.Rows[0]["GSTCode"].ToString();
                //    hdn_oldgstcode.Value = dts.Rows[0]["GSTCode"].ToString();
                //}
                //hid_gstcode.Value = hf_stateid.Value;
                //GetBusinesscardDetails();
            }
            CustomerTDS();
            //customermrcode();
            //FillBranch();
        }
    }
}