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
    public partial class AirPortCode : System.Web.UI.Page
    {
        string Ctrl_List, Msg_List, Dtype_List;
        string str_Uiid = "";
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                logobj.GetDataBase(Ccode);
                da_obj_portobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                
            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (IsPostBack != true)
            {
                try
                {
                    Ctrl_List = txt_PortName.ID + "~" + txt_AirPortCode.ID;
                    Msg_List = "Port Name~Air Port Code";
                    Dtype_List = "string~string";
                    btn_update.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    //Utility.Fn_CheckUserRights(str_Uiid, btn_update, null, null);
                    txt_PortName.Focus();
                    btn_back.Text="Cancel";

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
        public static List<string> Getportname(string prefix)
        {
            List<string> portname = new List<string>();
            DataTable obj_dtl = new DataTable();
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_portobj.GetDataBase(Ccode);
            obj_dtl = da_obj_portobj.GetLikePort(prefix.ToUpper());
            portname = Utility.Fn_DatatableToList(obj_dtl, "portname", "portid");
            return portname;
        }

        protected void txt_PortName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
                DataTable dt_port = new DataTable();
                if (txt_PortName.Text != "")
                {
                    dt_port = da_obj_portobj.RetrievePortnameDetails(txt_PortName.Text.ToUpper());
                    if (dt_port.Rows.Count > 0)
                    {
                        hf_intcountryid.Value = dt_port.Rows[0][1].ToString();
                        hf_portid.Value = dt_port.Rows[0]["portid"].ToString();

                        if (DBNull.Value.Equals(dt_port.Rows[0]["airportcode"].ToString()) == false || !string.IsNullOrEmpty(dt_port.Rows[0]["airportcode"].ToString()))
                        {
                            txt_AirPortCode.Text = dt_port.Rows[0]["airportcode"].ToString();
                        }
                        txt_PortCode.Text = dt_port.Rows[0][0].ToString();
                        if (hf_intcountryid.Value != "0")
                        {
                            txt_Country.Text = da_obj_portobj.GetCountryname(Convert.ToInt32(hf_intcountryid.Value));
                            txt_Sector.Text = da_obj_portobj.GetSectorName(txt_Country.Text.ToUpper());
                        }
                    }
                }
                txt_AirPortCode.Focus();
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

        protected void txt_PortCode_TextChanged(object sender, EventArgs e)
        {

            try
            {
               // DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
                DataTable dt_port = new DataTable();

                if (txt_PortCode.Text != "")
                {
                    dt_port = da_obj_portobj.RetrievePortcodeDetails(txt_PortCode.Text);
                    if (dt_port.Rows.Count > 0)
                    {
                        hf_intcountryid.Value = Convert.ToInt32(dt_port.Rows[0][1].ToString()).ToString();
                        hf_intsectorid.Value = Convert.ToInt32(dt_port.Rows[0][2].ToString()).ToString();
                        if (DBNull.Value.Equals(dt_port.Rows[0]["airportcode"].ToString()) == false || !string.IsNullOrEmpty(dt_port.Rows[0]["airportcode"].ToString()))
                        {
                            txt_AirPortCode.Text = dt_port.Rows[0]["airportcode"].ToString();
                        }
                        txt_Country.Text = da_obj_portobj.GetCountryname(Convert.ToInt32(hf_intcountryid.Value));
                        txt_Sector.Text = da_obj_portobj.GetSectorName(txt_Country.Text);
                        txt_PortName.Text = dt_port.Rows[0][0].ToString();
                        hf_portid.Value = da_obj_portobj.GetPortid(txt_PortCode.Text).ToString();
                    }
                }
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

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                txt_PortName.Focus();
                clear();
                txt_PortCode.ReadOnly = false;
                btn_back.Text = "Back";

                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";

            }
            else
            {
                this.Response.End();
            }
        }
        private void clear()
        {
            
            txt_PortCode.Text = "";
            txt_PortName.Text = "";
            txt_Country.Text = "";
            txt_Sector.Text = "";
            txt_AirPortCode.Text = "";
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
              //  DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
                if (txt_AirPortCode.Text.ToString() != "")
                {
                    da_obj_portobj.UpdAirPortCode(Convert.ToInt32(hf_portid.Value), txt_AirPortCode.Text);
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Details Updated')", true);
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1261, 2, Convert.ToInt32(Session["LoginBranchid"]), txt_AirPortCode.Text+"/Update");
                }
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

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1261, "MSaircode", txt_PortName.Text, txt_PortName.Text, "");  //"/Rate ID: " +
            if (txt_PortName.Text != "")
            {
                JobInput.Text = txt_PortName.Text;

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