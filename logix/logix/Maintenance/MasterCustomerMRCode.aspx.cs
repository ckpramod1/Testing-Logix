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
    public partial class MasterCustomerMRCode : System.Web.UI.Page
    {
        Boolean blr;
        string Ctrl_List, Msg_List, Dtype_List;
        string str_Uiid = "";


        DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();

        DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_customerobj.GetDataBase(Ccode);
                da_obj_Logobj.GetDataBase(Ccode);
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
                //    Ctrl_List = txt_Customer.ID + "~" + hf_custid.ID;
                //    Msg_List = "Customer Name~Customer Name";
                //    Dtype_List = "string~Autocomplete";
                //    btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    //Utility.Fn_CheckUserRights(str_Uiid, btn_save, null, btn_delete);
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
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_customerobj.GetDataBase(Ccode);
            obj_dt = da_obj_customerobj.GetLikeCustomerAll(prefix.ToUpper());
            category = Utility.Fn_DatatableToList_int32(obj_dt, "customer", "customerid");
            return category;
        }


        protected void cHECK_DATA()
        {
            if (txt_Customer.Text == "" && txt_MRShipper.Text == "" && txt_MRConsig.Text == "" && txt_MRNotify.Text == "" && txt_MRSeaAgnt.Text == "" && txt_MRAirAgnt.Text == "" && txt_MRSCAC.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please Enter any one of this details')", true);
                blr = true;
                return;
            }
            if (txt_MRConsig.Text != "")
            {
                if (txt_MRConsig.Text.Trim().Substring(0, 1) != "4")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "EDI", "alertify.alert('Invalid Consignee Code. Please Starts with Character 4');", true);
                    blr = true;
                    txt_MRConsig.Focus();
                    return;
                }
            }

            if (txt_MRNotify.Text != "")
            {
                if (txt_MRNotify.Text.Trim().Substring(0, 1) != "4")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "EDI", "alertify.alert('Invalid Notify PartyCode. Please Starts with Character 4');", true);
                    blr = true;
                    txt_MRNotify.Focus();
                    return;
                }
            }
            if (txt_MRSeaAgnt.Text != "")
            {
                if (txt_MRSeaAgnt.Text.Trim().Substring(0, 1) != "1")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "EDI", "alertify.alert('Invalid Sea Agent Code. Please Starts with Character 1');", true);
                    blr = true;
                    txt_MRSeaAgnt.Focus();
                    return;
                }
            }
            if (txt_MRAirAgnt.Text != "")
            {
                if (txt_MRAirAgnt.Text.Trim().Substring(0, 1) != "2")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "EDI", "alertify.alert('Invalid Air Agent Code. Please Starts with Character 2');", true);
                    blr = true;
                    txt_MRAirAgnt.Focus();
                    return;
                }
            }
        }
        protected void txt_Customer_TextChanged(object sender, EventArgs e)
        {

            try
            {
                //DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();

                DataTable dt_Cust = new DataTable();
                if (txt_Customer.Text != "")
                {
                    dt_Cust = da_obj_customerobj.SelMasterCust4MRCode(Convert.ToInt32(hf_custid.Value));
                    if (dt_Cust.Rows.Count > 0)
                    {
                        txt_MRAirAgnt.Text = dt_Cust.Rows[0]["mrcodeairagent"].ToString();
                        txt_MRConsig.Text = dt_Cust.Rows[0]["mrcodeconsignee"].ToString();
                        txt_MRSCAC.Text = dt_Cust.Rows[0]["mrscaccode"].ToString();
                        txt_MRSeaAgnt.Text = dt_Cust.Rows[0]["mrcodeseaagent"].ToString();
                        txt_MRShipper.Text = dt_Cust.Rows[0]["mrcodeshipper"].ToString();
                        txt_MRNotify.Text = dt_Cust.Rows[0]["mrcodenotify"].ToString();
                        btn_save.Text = "Update";

                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";
                        txt_Customer.Focus();
                    }
                    else
                    {
                        btn_save.Text = "Save";

                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                        clear();
                        btn_delete.Enabled = true;
                        txt_Customer.Focus();
                    }

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        private void clear()
        {
            txt_MRAirAgnt.Text = "";
            txt_MRConsig.Text = "";
            txt_MRSCAC.Text = "";
            txt_MRSeaAgnt.Text = "";
            txt_MRShipper.Text = "";
            txt_MRNotify.Text = "";
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
                //DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();

                cHECK_DATA();

                if(blr==true)
                {
                    return;
                }
                if (!string.IsNullOrEmpty(txt_Customer.Text) & hf_custid.Value != "0")
                {
                    if (string.IsNullOrEmpty(txt_MRShipper.Text) & string.IsNullOrEmpty(txt_MRConsig.Text) & string.IsNullOrEmpty(txt_MRAirAgnt.Text) & string.IsNullOrEmpty(txt_MRSeaAgnt.Text) & string.IsNullOrEmpty(txt_MRSCAC.Text) & string.IsNullOrEmpty(txt_MRNotify.Text))
                    {
                    }
                    else
                    {



                        if (btn_save.ToolTip == "Save")
                        {
                            da_obj_customerobj.InsMasterCust4MRCode(Convert.ToInt32(hf_custid.Value), txt_MRShipper.Text.ToUpper(), txt_MRConsig.Text.ToUpper(), txt_MRAirAgnt.Text.ToUpper(), txt_MRSeaAgnt.Text.ToUpper(), txt_MRSCAC.Text.ToUpper(), txt_MRNotify.Text.ToUpper());
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved')", true);
                            da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1064, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_Customer.Text + Convert.ToInt32(hf_custid.Value) + "/Sav");
                        }
                        else
                        {
                            da_obj_customerobj.UpdMasterCust4MRCode(Convert.ToInt32(hf_custid.Value), txt_MRShipper.Text.ToUpper(), txt_MRConsig.Text.ToUpper(), txt_MRAirAgnt.Text.ToUpper(), txt_MRSeaAgnt.Text.ToUpper(), txt_MRSCAC.Text.ToUpper(), txt_MRNotify.Text.ToUpper());
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated')", true);
                            btn_save.Text = "Save";


                            btn_save.ToolTip = "Save";
                            btn_save1.Attributes["class"] = "btn ico-save";
                            da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1064, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_Customer.Text + Convert.ToInt32(hf_custid.Value) + "/Upd");
                        }
                        txt_Customer.Text = "";
                        clear();
                        txt_Customer.Focus();
                    }

                }
                else
                {
                    txt_Customer.Focus();
                    txt_Customer.Text = "";
                    clear();
                   btn_save.Text = "Save";

                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
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
            if (btn_back.ToolTip=="Cancel")
            {
                clear();
                txt_Customer.Text = "";
                btn_save.Text = "Save";

                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                btn_delete.Enabled = true;
                txt_Customer.Focus();
                 btn_back.Text = "Back";


                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";

            }
            else
            {
                this.Response.End();
            }
            
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
              //  DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
                if (txt_Customer.Text != "" && hf_custid.Value != "")
                {
                    da_obj_customerobj.DelMasterCust4MRCode(Convert.ToInt32(hf_custid.Value));
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Deleted')", true);
                    txt_Customer.Text = "";
                    clear();
                   btn_save.Text = "Save";


                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";

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

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1064, "MScusmrcode", hf_custid.Value, hf_custid.Value, "");  //"/Rate ID: " +
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