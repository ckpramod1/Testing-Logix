using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;


namespace logix.ForwardExports
{
    public partial class QuotationMultiport : System.Web.UI.Page
    {
        string str_FornName = "", str_Uiid = "";

        DataAccess.Masters.MasterCustomer obj_da_customer = new DataAccess.Masters.MasterCustomer();

        DataAccess.ForwardingExports.QuotMultiPort obj_da_quotMulti = new DataAccess.ForwardingExports.QuotMultiPort();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            string ccode2 = Ccode;

            if (Ccode != "")
            {


                obj_da_customer.GetDataBase(Ccode);
                obj_da_quotMulti.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);


            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            //if (Session["LoginUserName"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            //}

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            //else if (Session["StrTranType"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            //}

            if (!IsPostBack)
            {               
               try
               {
                   fn_Grd();                   
               }
               catch (Exception ex)
               {
                   string message = ex.Message.ToString();
                   ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
               }
               btn_back.ToolTip = "Cancel";
               btn_back1.Attributes["class"] = "btn ico-cancel";
               UserRights();
            }
        }

        [WebMethod]
        public static List<string> Getcustomer(string prefix)
        {
            DataTable obj_dt = new DataTable();
                DataAccess.Masters.MasterCustomer obj_da_customer = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_customer.GetDataBase(Ccode);
            List<string> Agent = new List<string>();
            obj_dt = obj_da_customer.GetLikeCustomerWSCFL(prefix);
            Agent = Utility.Fn_DatatableToList(obj_dt, "customername", "customerid", "customer");
            return Agent;
        }

        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {
                    Boolean btn_delete;
                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, null, btn_print, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void fn_Grd()
        {
            try
            {
                grd_qtncustmr.DataSource = new DataTable();
                grd_qtncustmr.DataBind();
                  
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_customer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.ForwardingExports.QuotMultiPort obj_da_quotMulti = new DataAccess.ForwardingExports.QuotMultiPort();
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_quotMulti.GetCustQuotDetails(Convert.ToInt32(hf_customerid.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dt.Rows.Count > 0)
                {
                    grd_qtncustmr.DataSource = obj_dt;
                    grd_qtncustmr.DataBind();
                }
                else
                {
                    grd_qtncustmr.DataSource = new DataTable();
                    grd_qtncustmr.DataBind();                  
                   
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            btn_back.Text = "Cancel";

            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }
      

        protected void grd_qtncustmr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grd_qtncustmr_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            fn_btnprint_Click();
        }
        public void fn_btnprint_Click()
        {
            try
            {
                
                DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                Logobj.GetDataBase(Ccode);
                string str_RptName = "";
                string str_sp = "";
                string str_sf = "";
                string str_Script = "";
                string strquot = "";
                int index;
                int count = 0;
                if (txt_customer.Text != "")
                {
                    str_RptName = "QuotMultiPort.rpt";
                    if (grd_qtncustmr.Rows.Count == 0)
                    {//without grid it may cause error
                        return;
                    }
                    foreach (GridViewRow row in grd_qtncustmr.Rows)
                    {
                        index = row.RowIndex;

                        CheckBox cb = (CheckBox)row.FindControl("chk_select");
                        if (cb.Checked == true)
                        {
                            strquot = grd_qtncustmr.Rows[index].Cells[1].Text.ToString() + " , " + strquot;
                            count = 1;
                        }
                    }
                    if (count == 1)
                    {
                      //  str_sf = "{QuotationHead.quotno} in  [ " + strquot + "]";
                        str_sf= strquot ;
                        str_sf = str_sf.Substring(0, str_sf.Length - 3);
                        str_sf = str_sf ;
                        //str_sf = "{QuotationHead.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and " + str_sf + "  and {QuotationHead.customerid}= " + hf_customerid.Value + " and {QuotationHead.trantype}=\"FE\"";
                        Session["str_sfs"] = "{QuotationHead.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and " + str_sf + "  and {QuotationHead.customerid}= " + hf_customerid.Value + "and {QuotationHead.trantype}='FE'";
                      //  str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        str_Script = "window.open('../Reportasp/Quotmultiportrpt.aspx?Bid=" + Session["LoginBranchid"].ToString() + "&trantype=FE" + "&quotno=" + str_sf + "&" + this.Page.ClientQueryString + "&Ccode=" + Ccode +"','','');";
                                


                        
                        ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 97, 3, Convert.ToInt32(Session["LoginBranchid"]), "CustID: " + hf_customerid.Value + "/ Print ");
                    }
                    else
                    {
                       // ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "Plz check any one Print check box ", str_Script, true);
                         ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Plz check any one Print check box');", true);            
                        return;
                    }
                }
                UserRights();
            }
            catch(Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            btn_back.Text = "Cancel";
            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                txt_customer.Text = "";
                grd_qtncustmr.DataSource = new DataTable();
                grd_qtncustmr.DataBind();
                btn_back.Text = "Back";
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                //this.Response.End();
                Response.Redirect("../Home/SalesHome.aspx");

            }
        }
    }
}