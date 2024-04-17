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

namespace logix.Maintenance
{
    public partial class MasterCustomerPANandST : System.Web.UI.Page
    {
        string str_CType;
        string str_PAN;
        string str_ST;
        string Ctrl_List, Msg_List, Dtype_List;
        string str_Uiid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);

            if (IsPostBack != true)
            {
                try
                {
                    Ctrl_List = txt_Customer.ID + "~" + hf_customerid.ID;
                    Msg_List = "Customer Name~Customer Name";
                    Dtype_List = "string~Autocomplete";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    txt_Customer.Focus();
                  //  btn_back.Text = "Cancel";


                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    //Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, null);
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }
        [WebMethod]
        public static List<string> Getcustomer(string prefix)
        {
            List<string> customername = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Cusobj = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_Cusobj.GetLikeCustomerNotAgent(prefix.ToUpper());
            customername = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            return customername;
        }

        protected void txt_Customer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
                DataTable dt_customer = new DataTable();
                DataTable dt_Cust = new DataTable();
                dt_customer = da_obj_customerobj.GetLikeCustomerNotAgent(txt_Customer.Text.ToUpper());

                if (hf_customerid.Value == "")
                {
                    hf_customerid.Value = "0";
                }
                if (dt_customer.Rows.Count != 0)
                {
                    for (int i = 0; i < dt_customer.Rows.Count; i++)
                    {
                        str_CType = dt_customer.Rows[i][4].ToString();
                        dt_Cust = da_obj_customerobj.GetCustDetails(Convert.ToInt32(hf_customerid.Value));
                    }
                }

                if (dt_Cust.Rows.Count > 0)
                {
                    txt_CustType.Text = str_CType;
                    txt_City.Text = dt_Cust.Rows[0]["portname"].ToString();
                    txt_Address.Text = dt_Cust.Rows[0]["address"].ToString() + "," + txt_City.Text;
                    txt_PAN.Text = dt_Cust.Rows[0]["panno"].ToString();
                    txt_ST.Text = dt_Cust.Rows[0]["stno"].ToString();
                    if (!string.IsNullOrEmpty(txt_PAN.Text) || !string.IsNullOrEmpty(txt_ST.Text))
                    {
                      //  btn_save.Text = "Update";

                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn btn-update1";
                    }
                    else
                    {
                        //btn_save.Text = "Save";
                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                    }
                }
                else
                {
                    clear();
                }
              //  btn_back.Text = "Cancel";

                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

            txt_PAN.Focus();
        }

        private void clear()
        {
            txt_CustType.Text = "";
            txt_City.Text = "";
            txt_Address.Text = "";
            txt_PAN.Text = "";
            txt_ST.Text = "";
        }



        protected void btn_save_Click1(object sender, EventArgs e)
        {
            try
            {
                DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
                if (!string.IsNullOrEmpty(txt_Customer.Text) && hf_customerid.Value != "0")
                {
                    str_PAN = txt_PAN.Text;
                    str_ST = txt_ST.Text;
                    DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();

                    if (!string.IsNullOrEmpty(str_PAN) || !string.IsNullOrEmpty(str_ST))
                    {
                        da_obj_customerobj.UpdCustPAN_STNo(Convert.ToInt32(hf_customerid.Value), Convert.ToString(str_PAN.ToUpper()), Convert.ToString(str_ST.ToUpper()));
                        if (btn_save.ToolTip == "Save")
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved')", true);
                            da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1051, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_Customer.Text + "/Sav");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated')", true);
                            da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1051, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_Customer.Text + "/Upd");
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid Customer Name')", true);
                    txt_Customer.Focus();
                    txt_Customer.Text = "";
                    clear();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_view_Click1(object sender, EventArgs e)
        {
            try
            {
                string str_sf = "";
                string str_frmname = "";
                string str_RptName = "";
                string str_Script = "";
                string str_sp = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";

                str_frmname = "Master Customer";
                str_RptName = "MasterCustomer4PAN_ST.rpt";

                if (!string.IsNullOrEmpty(txt_Customer.Text))
                {
                    str_sf = "{MasterCustomer.customerid}=" + hf_customerid.Value;
                }
                else
                {
                    str_sf = "";
                }
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_back_Click1(object sender, EventArgs e)
        {
          if(btn_back.ToolTip=="Cancel")
          {
            clear();
            txt_Customer.Text = "";
          //  btn_save.Text = "Save";

            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
           

            hf_customerid.Value = "0";
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
            Panel1.Visible = true;
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1051, "Mscus", hf_customerid.Value, hf_customerid.Value, "");  //"/Rate ID: " +
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