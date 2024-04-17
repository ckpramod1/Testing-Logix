using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace logix.Maintenance
{
    public partial class OpeningBalance : System.Web.UI.Page
    {
        double opbal;
        string Ctrl_List, Msg_List, Dtype_List;
        string str_Uiid = "";
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);                

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            } 
            if (IsPostBack != true)
            {
                try
                {
                    Ctrl_List = txt_Customer.ID + "~" + hf_custid.ID + "~" + txt_Opbal.ID + "~" + ddl_cmbbilltype.ID;
                    Msg_List = "Customer Name~Customer Name~Opening Balance~OpeningBalance Type";
                    Dtype_List = "string~Autocomplete~string~Dropdownlist";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");

                    //btn_save.Text = "Save";
                    //btn_back.Text="Cancel";

                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";

                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";


                    CustomerTypefill();
                    txt_Opbal.Attributes.Add("onkeypress", "return validateFloatKeyPress(this, event)");
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    //Utility.Fn_CheckUserRights(str_Uiid, btn_save, null, null);
                    txt_Customer.Focus();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }

        [WebMethod]
        public static List<string> Getcusname(string prefix)
        {
            List<string> category = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_customerobj.GetLikeCustomerAll(prefix.ToUpper());
            category = Utility.Fn_DatatableToList_int32(obj_dt, "customer", "customerid");
            return category;
        }
        [WebMethod]
        public static List<string> GetPortName(string prefix)
        {
            List<string> portname = new List<string>();
            DataTable obj_dtl = new DataTable();
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            obj_dtl = da_obj_portobj.GetLikePort(prefix.ToUpper());
            portname = Utility.Fn_DatatableToList(obj_dtl, "portname", "portid");
            return portname;
        }


        protected void txt_Customer_TextChanged(object sender, EventArgs e)
        {
            Getdetails();
            txt_Customer.Focus();
        }
        private void CustomerTypefill()
        {
            ddl_CmbCType.Items.Add("");
            ddl_CmbCType.Items.Add("Shipper");
            ddl_CmbCType.Items.Add("Consignee");
            ddl_CmbCType.Items.Add("Notify Party");
            ddl_CmbCType.Items.Add("Agent / Principal");
            ddl_CmbCType.Items.Add("CHA / CNF");
            ddl_CmbCType.Items.Add("Carrier / Airliner / MLO / Freight Forwarder");
            ddl_CmbCType.Items.Add("Transporter");
            ddl_CmbCType.Items.Add("Counter Part");
            ddl_CmbCType.Items.Add("Others");
            ddl_CmbCType.Items.Add("CFS");
            ddl_CmbCType.Items.Add("Warehouse");
        }

        protected void txt_location_TextChanged(object sender, EventArgs e)
        {
            try
            {
            DataAccess.Masters.MasterCountry da_obj_countryobj = new DataAccess.Masters.MasterCountry();
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            DataTable dt_customer = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            if (!string.IsNullOrEmpty(txt_location.Text))
            {
                hf_custid.Value = da_obj_customerobj.GetCustomerid(txt_Customer.Text.ToUpper()).ToString();
                if (hf_custid.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Customer Not available');", true);
                    return;
                }
                else
                {
                    Getdetails();
                    txt_City.Text = txt_location.Text;
                }
            }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 
        }

        private void Getdetails()
        {
            try
            {
                DataAccess.Masters.MasterCountry da_obj_countryobj = new DataAccess.Masters.MasterCountry();
                DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
                DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
                DataTable dt_customer = new DataTable();
                if (txt_Customer.Text.ToString() != "")
                {
                    dt_customer = da_obj_customerobj.RetrieveCustomerDetails(txt_Customer.Text.ToUpper(), da_obj_customerobj.GetCustomerType(Convert.ToInt32(hf_custid.Value)), da_obj_customerobj.GetCustlocation(Convert.ToInt32(hf_custid.Value)));
                    if (dt_customer.Rows.Count > 0)
                    {
                        if (da_obj_customerobj.GetCustomerType(Convert.ToInt32(hf_custid.Value)) == "C")
                        {
                            ddl_CmbCType.SelectedValue = "Shipper";
                        }
                        else
                        {
                            ddl_CmbCType.SelectedValue = "Agent / Principal";
                        }

                        txt_Address.Text = dt_customer.Rows[0][0].ToString();
                        hf_intcity.Value = dt_customer.Rows[0][1].ToString();
                        txt_Zip.Text = dt_customer.Rows[0][2].ToString();
                        hf_custid.Value = dt_customer.Rows[0][7].ToString();
                        txt_City.Text = da_obj_portobj.GetPortname(Convert.ToInt32(hf_intcity.Value));
                        txt_location.Text = da_obj_portobj.GetPortname(Convert.ToInt32(hf_intcity.Value));
                        txt_Country.Text = da_obj_countryobj.GetCountryName(txt_City.Text.ToUpper());
                        //btnview.Enabled = True
                        opbal = da_obj_customerobj.GetCustomerOpeningBal(Convert.ToInt32(hf_custid.Value));
                        if (opbal == 0)
                        {
                            txt_Opbal.Text = "";
                            ddl_cmbbilltype.SelectedValue = "";
                        }
                        else
                        {
                            //btn_save.Text = "Update";

                            btn_save.ToolTip = "Update";
                            btn_save1.Attributes["class"] = "btn btn-update1";

                            btn_save.Focus();
                            txt_Opbal.Text = Convert.ToString(opbal);
                            int x1 = Convert.ToInt32(txt_Opbal.Text);
                            if (x1 > 0)
                            {
                                ddl_cmbbilltype.SelectedValue = "D";
                            }
                            else if (x1 < 0)
                            {
                                ddl_cmbbilltype.SelectedValue = "C";
                            }

                        }

                        btn_save.Enabled = true;
                    }
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Please Select the Correct Customer Name and Location');", true);
                    //    txtclear();
                    //    txt_Customer.Focus();
                    //}
                }
            }
          
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
           if(btn_back.ToolTip=="Cancel")
           {
            txtclear();
         //   btn_back.Text = "Back";


            btn_back.ToolTip = "Back";
            btn_back1.Attributes["class"] = "btn ico-back";
            txt_Customer.Focus();
           }
           else
           {
               this.Response.End();
           }
        }
        private void txtclear()
        {
            txt_Customer.Text = "";
            ddl_CmbCType.SelectedIndex = -1;
            txt_location.Text = "";
            txt_Address.Text = "";
            txt_City.Text = "";
            txt_Country.Text = "";
            txt_Zip.Text = "";
            txt_Opbal.Text = "";
            ddl_cmbbilltype.SelectedIndex = 0;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
        try 
        {
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            if (!string.IsNullOrEmpty(txt_Opbal.Text))
            {
                if (ddl_cmbbilltype.SelectedValue == "D")
                {
                    da_obj_customerobj.UpdateOpeningBalance(Convert.ToInt32(hf_custid.Value), Convert.ToDouble(txt_Opbal.Text));
                }
                else
                {
                    da_obj_customerobj.UpdateOpeningBalance(Convert.ToInt32(hf_custid.Value), -(Convert.ToDouble(txt_Opbal.Text)));
                }
                if (btn_save.ToolTip == "Save")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 338, 1, int.Parse(Session["LoginBranchid"].ToString()), "Save");  
                    txtclear();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 338, 2, int.Parse(Session["LoginBranchid"].ToString()), "update");
                   
                    txtclear();
                   // btn_save.Text = "Save";
                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                }
                btn_save.Enabled = false;
                txt_Customer.Focus();
            }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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
            Panel2.Visible = true;
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 338, "Mscus", hf_custid.Value, hf_custid.Value, "");  //"/Rate ID: " +
            if (txt_Customer.Text != "")
            {
                JobInput.Text = txt_Customer.Text;

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
              



    }
}