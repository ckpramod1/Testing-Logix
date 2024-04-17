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
    public partial class MICharges_Classification : System.Web.UI.Page
    {
        string Ctrl_List, Msg_List, Dtype_List;
        string str_Uiid = "";
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.masterChargesCategory da_obj_MCCatagoryObj = new DataAccess.Masters.masterChargesCategory();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                logobj.GetDataBase(Ccode);
                da_obj_MCCatagoryObj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (IsPostBack != true)
            {
                Ctrl_List = txt_Category.ID + "~" + txt_Descr.ID;
                Msg_List = "Category~Description";
                Dtype_List = "string~string";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                //str_Uiid = Request.QueryString["UIID"].ToString();
                //Utility.Fn_CheckUserRights(str_Uiid, btn_save, null, null);
                txt_Category.Focus();
            }
        }
        [WebMethod]
        public static List<string> Getchargename(string prefix)
        {
            List<string> category = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.masterChargesCategory da_obj_MCCatagoryObj = new DataAccess.Masters.masterChargesCategory();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_MCCatagoryObj.GetDataBase(Ccode);
            obj_dt = da_obj_MCCatagoryObj.LikeChargesCategory(prefix.ToUpper());
            category = Utility.Fn_DatatableToList_int16(obj_dt, "category", "categoryid");
            return category;
        }

        protected void txt_Category_TextChanged(object sender, EventArgs e)
        {
            //DataAccess.Masters.masterChargesCategory da_obj_MCCatagoryObj = new DataAccess.Masters.masterChargesCategory();
            DataTable Dt_new = new DataTable();
            Dt_new = da_obj_MCCatagoryObj.ShowChargesCategory(Convert.ToInt32(da_obj_MCCatagoryObj.GetChargesCategoryid(txt_Category.Text.ToUpper())));
            if (Dt_new.Rows.Count > 0)
            {
                hf_categoryid.Value = Dt_new.Rows[0]["categoryid"].ToString();
                txt_Category.Text = Dt_new.Rows[0]["category"].ToString();
                txt_Descr.Text = Dt_new.Rows[0]["descr"].ToString();
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Already Exists')", true);
                btn_save.Text = "Update";


                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn ico-update";
                txt_Category.Focus();
            }
            else
            {
                if (hf_categoryid.Value == "0")
                {
                   
                }

            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
          //  DataAccess.Masters.masterChargesCategory da_obj_MCCatagoryObj = new DataAccess.Masters.masterChargesCategory();
          
            if (txt_Category.Text.ToString() != "")
            {
                if (btn_save.ToolTip == "Save")
                {
             
                    da_obj_MCCatagoryObj.InsertChargesCategory(txt_Category.Text.ToUpper(), txt_Descr.Text.ToUpper());
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved')", true);
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 570, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_Category.Text+"/save");
                    txt_Category.Focus();
                    //btn_save.ToolTip = "Update";
                    //btn_save1.Attributes["class"] = "btn btn-update1";
                    clear();
                   
                }
                else
                {
                    if (hf_categoryid.Value != "0")
                    {
                        if (btn_save.ToolTip == "Update")
                        {
                            da_obj_MCCatagoryObj.UpdateChargesCategory(txt_Category.Text.ToUpper(), txt_Descr.Text.ToUpper(), Convert.ToInt32(hf_categoryid.Value));
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated')", true);
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 570, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_Category.Text+"/Update");
                             txt_Category.Focus();
                             btn_save.Text = "Save";
                             btn_save.ToolTip = "Save";
                             btn_save1.Attributes["class"] = "btn ico-save";
                             clear();
                        }
                    }
                }
            }
        }
        private void clear()
        {
           txt_Category.Text = "";
           txt_Descr.Text = "";
           btn_save.Text = "Save";

           btn_save.ToolTip = "Save";
           btn_save1.Attributes["class"] = "btn ico-save";
           txt_Category.Focus();
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip=="Cancel")
            { 
                clear();
                btn_back.Text = "Back";

                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";

            }
            else
            {
                this.Response.End();
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
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 570, "MSchargeclass", txt_Category.Text, txt_Category.Text, "");  //"/Rate ID: " +
            if (txt_Category.Text != "")
            {
                JobInput.Text = txt_Category.Text;


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
