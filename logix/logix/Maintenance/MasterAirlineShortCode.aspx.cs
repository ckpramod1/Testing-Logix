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
using System.Web.Services.Description;

namespace logix.Maintenance
{
    public partial class MasterAirlineShortCode : System.Web.UI.Page
    {
        string Ctrl_List, Msg_List, Dtype_List;
        string str_Uiid = "";

        DataAccess.Masters.MasterCountry da_obj_countryobj = new DataAccess.Masters.MasterCountry();
        DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_countryobj.GetDataBase(Ccode);
                da_obj_customerobj.GetDataBase(Ccode);
                da_obj_logobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
               

            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (IsPostBack != true)
            {
                try
                {
                    Ctrl_List = txt_Customer.ID + "~" + hf_custid.ID + "~" + txt_SC.ID;
                    Msg_List = "Customer~Customer~ShortCode";
                    Dtype_List = "string~Autocomplete~string";
                    btn_update.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    //Utility.Fn_CheckUserRights(str_Uiid, btn_update, null, null);
                    txt_Customer.Focus();
                    btn_back.Text = "Cancel";

                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
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
            string custtype = "C";
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_customerobj.GetDataBase(Ccode);
            obj_dt = da_obj_customerobj.GetLikeCustomer(prefix.ToUpper(), custtype);
           // customer = Utility.Fn_TableToList(obj_dt, "customername", "customerid");
            customer = Utility.Fn_DatatableToList_int16Display(obj_dt, "customer", "customerid", "customername");
            return customer;
        }

        protected void txt_Customer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.Masters.MasterCountry da_obj_countryobj = new DataAccess.Masters.MasterCountry();
                //DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
                DataTable dt_Cus = new DataTable();
                DataTable dt_rds = new DataTable();
                if (txt_Customer.Text.ToString() != "")
                {
                    dt_Cus = da_obj_customerobj.GetLikeCustomer(txt_Customer.Text.ToUpper(), "C");
                    clear();
                    if (dt_Cus.Rows.Count > 0)
                    {
                        txt_City.Text = dt_Cus.Rows[0][4].ToString();
                        txt_Address.Text = dt_Cus.Rows[0][2].ToString();
                        txt_Customer.Text = da_obj_customerobj.GetCustomername(Convert.ToInt32(hf_custid.Value)).ToString();

                    }
                    if (txt_City.Text.ToString() != "")
                    {
                        txt_Country.Text = da_obj_countryobj.GetCountryName(txt_City.Text.ToUpper());
                    }
                }
                dt_rds = da_obj_customerobj.GetMASterAirlineShortCode(Convert.ToInt32(hf_custid.Value));
                if (dt_rds.Rows.Count > 0)
                {
                    txt_SC.Text = dt_rds.Rows[0]["shortcode"].ToString();
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Details Already Exists')", true);
                    btn_update.Text = "Update";

                    btn_update.ToolTip = "Update";
                    btn_update1.Attributes["class"] = "btn ico-update";

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txt_SC.Focus();
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                clear();
                txt_Customer.Focus(); 
            }
            else
            {
                this.Response.End();
            }
        }
        private void clear()
        {

            txt_Customer.Text = "";
            txt_Address.Text = "";
            txt_City.Text = "";
            txt_Country.Text = "";
            txt_SC.Text = "";
            btn_update.Text = "Update";
            btn_back.Text="Back";

            btn_update.ToolTip = "Update";
            btn_update1.Attributes["class"] = "btn ico-update";

            btn_back.ToolTip = "Back";
            btn_back1.Attributes["class"] = "btn ico-back";

        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            try
            {                //DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
                //DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();

                if (txt_Customer.Text.ToString() != "" && txt_SC.Text.ToString() != "")
                {
                    da_obj_customerobj.InsMasterAirlineShortCode(txt_Customer.Text.ToUpper(), txt_SC.Text.ToUpper());
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Details Updated')", true);
                    da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1263, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "AirLine-" + txt_Customer.Text + "/" + txt_SC.Text);
                    btn_back.Text = "Cancel";
                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
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
          //  DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1263, "MSairlineshotcode", hf_custid.Value, hf_custid.Value, "");  //"/Rate ID: " +
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