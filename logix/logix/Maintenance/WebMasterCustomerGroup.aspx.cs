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
    public partial class WebMasterCustomerGroup : System.Web.UI.Page
    {
        string Ctrl_List, Msg_List, Dtype_List;
        CheckBox chk;
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
            if (!IsPostBack)
            {
                try
                {
                    txt_Search.Enabled = false;
                    btn_update.Enabled = false;
                    Ctrl_List = txt_company.ID + "~" + txt_city.ID;
                    Msg_List = "Company~City";
                    Dtype_List = "string~string";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    //Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, null);
                    txt_company.Focus();
                    Empty_grid();
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
            List<string> gname = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.WebMasterCustomerGroup da_obj_custGroupobj = new DataAccess.Masters.WebMasterCustomerGroup();
            obj_dt = da_obj_custGroupobj.GetLikeWebCustGroup(prefix.ToUpper());
            gname = Utility.Fn_DatatableToList_int32(obj_dt, "gname", "Webgroupid");
            HttpContext.Current.Session["name"] = obj_dt;
            return gname;

        }
        [WebMethod]
        public static List<string> Getponame(string prefix)
        {
            List<string> portname = new List<string>();
            DataTable obj_dtl = new DataTable();
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            obj_dtl = da_obj_portobj.GetLikePort(prefix.ToUpper());
            portname = Utility.Fn_DatatableToList(obj_dtl, "portname", "portid");
            return portname;
        }
        [WebMethod]
        public static void GetBanName(string Prefix)
        {
            DataTable obj_dtEmp = new DataTable();

            if (Prefix.Length > 0)
            {
                DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
                DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
                DataTable obj_dt = new DataTable();
                obj_dt = da_obj_customerobj.GetLikeCustomerAll(Prefix.ToUpper());
                obj_dtEmp.Columns.Add("customerid");
                obj_dtEmp.Columns.Add("customername");
                obj_dtEmp.Columns.Add("portname");
                obj_dtEmp.Columns.Add("grdblselect");

                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["customerid"] = obj_dt.Rows[i][0].ToString();
                    dr["customername"] = obj_dt.Rows[i][1].ToString();
                    int c = Convert.ToInt32(obj_dt.Rows[i][3].ToString());
                    //da_obj_portobj.GetPortname(c);
                    da_obj_portobj.GetPortname(c);
                    dr["portname"] = da_obj_portobj.GetPortname(c);
                    dr["grdblselect"] = obj_dt.Rows[0][5].ToString();


                }
                HttpContext.Current.Session["Date"] = obj_dtEmp;
            }

        }
        private void Empty_grid()
        {
            DataTable dt_new = new DataTable();
            grd_Web.DataSource = dt_new;
            grd_Web.DataBind();
        }




        protected void txt_company_TextChanged(object sender, EventArgs e)
        {
           try { 


            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            DataTable dt_web = new DataTable();
            DataTable dt_new = new DataTable();
            DataAccess.Masters.WebMasterCustomerGroup da_obj_custGroupobj = new DataAccess.Masters.WebMasterCustomerGroup();
            if (txt_company.Text.ToString() != "")
            {
                //dt_new = (DataTable)Session["name"];
                //hf_webgroupid.Value = dt_new.Rows[0][0].ToString();

                if (hf_webgroupid.Value == "0")
                {
                    hf_webgroupid.Value = da_obj_custGroupobj.RetrieveCustGroupID(txt_company.Text.ToUpper()).ToString();
                }
                dt_web = da_obj_custGroupobj.RetrieveCustGroupDetails(Convert.ToInt32(hf_webgroupid.Value));
                if (dt_web.Rows.Count > 0)
                {
                    txt_address.Text = dt_web.Rows[0][1].ToString();
                    hf_cityid.Value = dt_web.Rows[0][2].ToString();
                    txt_city.Text = da_obj_portobj.GetPortname(Convert.ToInt32(hf_cityid.Value));
                    txt_zip.Text = dt_web.Rows[0][3].ToString();
                    txt_contact.Text = dt_web.Rows[0][4].ToString();
                    txt_phone.Text = dt_web.Rows[0][5].ToString();
                    txt_fax.Text = dt_web.Rows[0][6].ToString();
                    txt_email.Text = dt_web.Rows[0][7].ToString();

                  //  btn_save.Text = "Update";
                //    btn_back.Text = "Cancel";

                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";

                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";

                }
            }
            dt_new = da_obj_custGroupobj.RetrieveMasterCustGroupIDs(Convert.ToInt32(hf_webgroupid.Value));

            if (dt_new.Rows.Count > 0)
            {
                //for (int i = 0; i <= dt_new.Rows.Count - 1; i++)
                //{
                //hf_customerid.Value = dt_new.Rows[i][0].ToString();
                grd_Web.DataSource = dt_new;
                grd_Web.DataBind();
                //}
            }
            for (int i = 0; i <= dt_new.Rows.Count - 1; i++)
            {
                string str_c = dt_new.Rows[i][3].ToString();
                foreach (GridViewRow row in grd_Web.Rows)
                {
                    CheckBox Chk = (CheckBox)row.FindControl("grdblselect");

                    if (str_c != "")
                    {
                        Chk.Checked = true;
                    }
                }
            }
            btn_update.Enabled = true;
                  }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
           txt_company.Focus();
        }

        protected void txt_city_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btn_save_Click(object sender, EventArgs e)
        { try{
            DataAccess.Masters.WebMasterCustomerGroup da_obj_custGroupobj = new DataAccess.Masters.WebMasterCustomerGroup();
            if (btn_save.ToolTip == "Save")
            {
                hf_webgroupid.Value = da_obj_custGroupobj.InsertCustomerDetails(txt_company.Text.ToUpper(), txt_contact.Text.ToUpper(), txt_address.Text.ToUpper(), txt_city.Text.ToUpper(), txt_zip.Text.ToUpper(), txt_phone.Text, txt_fax.Text, txt_email.Text.ToUpper()).ToString();
                ScriptManager.RegisterStartupScript(btn_save, typeof(TextBox), "Outstanding", "alertify.alert('Details Saved');", true);
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 763, 1, int.Parse(Session["LoginBranchid"].ToString()), "Save");
                txt_Search.Focus();
                txt_Search.Enabled = true;
                btn_update.Enabled = true;
               
            }
            else
            {
                da_obj_custGroupobj.UpdCustGroupDetails(txt_company.Text.ToUpper(), Convert.ToInt32(hf_webgroupid.Value), txt_contact.Text.ToUpper(), txt_address.Text.ToUpper(), txt_city.Text.ToUpper(), txt_zip.Text.ToUpper(), txt_phone.Text, txt_fax.Text, txt_email.Text.ToUpper());
                ScriptManager.RegisterStartupScript(btn_save, typeof(TextBox), "Outstanding", "alertify.alert('Details Updated');", true);
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 763, 2, int.Parse(Session["LoginBranchid"].ToString()), "Update");
                txt_Search.Focus();
                txt_Search.Enabled = true;
               
                btn_update.Enabled = true;
            }
                  }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
           btn_search.Focus();
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
        try{

            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.Masters.WebMasterCustomerGroup da_obj_custGroupobj = new DataAccess.Masters.WebMasterCustomerGroup();
            DataTable obj_dtEmp = new DataTable();
            //obj_dtEmp = (DataTable)Session["Date"];
            int int_Custid = int.Parse(hf_webgroupid.Value);

            if (int_Custid != 0)
            {
                foreach (GridViewRow row in grd_Web.Rows)
                {
                    CheckBox Chk = (CheckBox)row.FindControl("grdblselect");
                    if (Chk.Checked == true)
                    {
                        int_Custid = Convert.ToInt32(row.Cells[0].Text);
                       // int_Custid = Convert.ToInt32(grd_Web.DataKeys[rowgrd_Web.Rows[row.RowIndex]..RowIndex].Values[0].ToString());
                        if (Chk.Checked == true)
                        {
                            da_obj_custGroupobj.UpdateCustomerGroupid(int_Custid, Convert.ToInt32(hf_webgroupid.Value), 1);
                        }
                        else
                        {
                            da_obj_custGroupobj.UpdateCustomerGroupid(int_Custid, Convert.ToInt32(hf_webgroupid.Value), 0);
                        }
                    }

                    ScriptManager.RegisterStartupScript(btn_save, typeof(TextBox), "Outstanding", "alertify.alert('Details Updated');", true);
                    grd_Web.DataSource = null;
                    grd_Web.DataBind();
                    btn_update.Enabled = false;
                    txt_Search.Enabled = false;
                }
            }
                  }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }



        protected void btn_search_Click(object sender, EventArgs e)
        {
            //try { 

            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            DataTable obj_dtEmp = new DataTable();
            if (txt_Search.Text != "")
            {
                if (Session["Date"] != null)
                {
                    obj_dtEmp = (DataTable)Session["Date"];
                    grd_Web.DataSource = obj_dtEmp;
                    Session["grd"] = obj_dtEmp;
                    grd_Web.DataBind();
                    txt_Search.Focus();

                }
               // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
            }
            else
            {
                grd_Web.DataSource = null;
                grd_Web.DataBind();
            }
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}
          
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
         if(btn_back.Text=="Cancel")
         {
            txt_address.Text = "";
            txt_city.Text = "";
            txt_zip.Text = "";
            txt_contact.Text = "";
            txt_phone.Text = "";
            txt_fax.Text = "";
            txt_email.Text = "";
            txt_company.Text = "";
            txt_Search.Text = "";
            txt_Search.Enabled = false;
            btn_update.Enabled = false;
           // btn_save.Text = "Save";

            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            grd_Web.DataSource = null;
            grd_Web.DataBind();
            Empty_grid();
            // btn_back.Text="Back";
             btn_back.ToolTip = "Back";
             btn_back1.Attributes["class"] = "btn ico-back";

             txt_company.Focus();
         }
         else
         {
             this.Response.End();
         }
        }

       

        protected void grd_Web_SelectedIndexChanged(object sender, EventArgs e)
        {
            int int_jobno = int.Parse(grd_Web.SelectedRow.Cells[1].Text.ToString());
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

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 763, "Mswebmaster", txt_company.Text, txt_company.Text, "");  //"/Rate ID: " +
            if (txt_company.Text != "")
            {
                JobInput.Text = txt_company.Text;

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