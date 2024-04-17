using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace logix.FI
{
    public partial class PendingDOAgent : System.Web.UI.Page
    {

        DataAccess.LogDetails obj_da_logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {


                obj_da_logobj.GetDataBase(Ccode);
                obj_da_Logobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);


               




            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (!IsPostBack)
            {
                try
                {
                    //DataAccess.LogDetails obj_da_logobj = new DataAccess.LogDetails();
                    txt_From.Text = Utility.fn_ConvertDate(obj_da_logobj.GetDate().ToShortDateString());
                    txt_To.Text = txt_From.Text;
                    btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel2.Attributes["class"] = "btn ico-cancel";
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
        }

        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_da_customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_customerobj.GetDataBase(Ccode);
           
            obj_dt = obj_da_customerobj.GetLikeCustomer(prefix, "P");
            customer = Utility.Fn_DatatableToList_int32(obj_dt, "customer", "customerid");
            return customer;
        }

        protected void txt_Agent_TextChanged(object sender, EventArgs e)
        {
            string[] str = txt_Agent.Text.Split(',');
            txt_Agent.Text = str[0];
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip=="Cancel")
            {
            //DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
            txt_From.Text = Utility.fn_ConvertDate(obj_da_Logobj.GetDate().ToShortDateString());
            txt_To.Text = txt_From.Text;
            txt_Agent.Text = "";
            btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel2.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();

            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                string str_RptName = "";
                string str_sp = "";
                string str_sf = "";
                string str_Script = "";
                DateTime dtfrom, dtto;
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel2.Attributes["class"] = "btn ico-cancel";
                dtfrom = Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text));
                dtto = Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text));
                //DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
                if (radio_DO.Checked == true)
                {
                    if (txt_Agent.Text != "")
                    {
                        str_RptName = "FIDOStatusForAgent.rpt";
                        str_sf = "{FIBLDetails.bid}=" + Session["LoginBranchid"].ToString() + " and {FIBLDetails.agentid}=" + hid_Customerid.Value + " and {FIBLDetails.doissuedon}>=Date(" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + ") And {FIBLDetails.doissuedon}<=date(" + dtto.Year + "," + dtto.Month + "," + dtto.Day + ")";
                        str_sp = "AgentName=" + txt_Agent.Text;
                        //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        str_Script = "window.open('../Reportasp/FIDOStatusForAgentRpt.aspx?bid=" + Session["LoginBranchid"].ToString() + "&agentid=" + hid_Customerid.Value + "&dtfrom=" + dtfrom + "&dtto=" + dtto + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                        obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 462, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), "AgentDOStatus/V");
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                    }
                }
                else
                {
                    if (txt_Agent.Text != "")
                    {
                        str_RptName = "FIPDORegister.rpt";
                        str_sf = "{FIBLDetails.bid}=" + Session["LoginBranchid"].ToString() + " and {FIBLDetails.agentid}=" + hid_Customerid.Value + " And isnull({FIBLDetails.doissuedon})";
                        //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        str_Script = "window.open('../Reportasp/FIPDORegisterRpt.aspx?bid=" + Session["LoginBranchid"].ToString() + "&agentid=" + hid_Customerid.Value + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                        obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 462, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), "AgentPndDO/V");
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void radio_PO_CheckedChanged(object sender, EventArgs e)
        {
            txt_From.Enabled = false;
            txt_To.Enabled = false;
        }

        protected void radio_DO_CheckedChanged(object sender, EventArgs e)
        {
            txt_From.Enabled = true;
            txt_To.Enabled = true;
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
            GridViewlog.Visible = true;
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 462, "Job", "", "", Session["StrTranType"].ToString());
                    
            //if (txt_jobno.Text != "")
            //{
            //    JobInput.Text = txt_jobno.Text;
            //}

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

    }
}