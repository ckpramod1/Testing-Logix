using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.FI
{
    public partial class forwarderhbl : System.Web.UI.Page
    {
        int int_divisionid;
        int int_branchid;

        string str_division;
        string str_branch;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            if (!IsPostBack)
            {
                try
                {
                    txt_jobno.Focus();
                    lbl_fbl.Visible = true;
                    lbl_hbl.Visible = true;
                    int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    str_division = Session["LoginDivisionName"].ToString();
                    str_branch = Session["LoginBranchName"].ToString();
                    grd.Visible = true;
                    grd.DataSource = new DataTable();
                    grd.DataBind();
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
            grd.Visible = true;
            //grd.DataSource = new DataTable();
            //grd.DataBind();
            //grd.Visible = false;
            txt_jobno.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
        }
        protected void txt_jobno_TextChanged(object sender, EventArgs e)
        {
            DataTable obj_Dt = new DataTable();
            DataAccess.ForwardingImports.BLDetails obj_da_FIBLobj = new DataAccess.ForwardingImports.BLDetails();
            if (txt_jobno.Text != "")
            {
                obj_Dt = obj_da_FIBLobj.ForwarderVsHBL(Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            }
            if (obj_Dt.Rows.Count > 0)
            {

                grd.DataSource = obj_Dt;
                grd.DataBind();

            }
            else
            {
                lbl_fbl.Visible = true;
                lbl_hbl.Visible = true;
                grd.DataSource = new DataTable();
                grd.DataBind();

            }
            btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel2.Attributes["class"] = "btn ico-cancel";
            grd.Visible = true;
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel2.Attributes["class"] = "btn ico-cancel";
                string str_RPtName = "";
                string str_sf = "";
                string str_Script = "";
                string str_sp = "";
                DataAccess.LogDetails obj_da_logobj = new DataAccess.LogDetails();
                if (txt_jobno.Text == "")
                {
                    str_RPtName = "forwardervshbl.rpt";
                    str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]);
                    //str_sp = "Title=Air Exports SalesPeson Revenue from  " + txt_From.Text + "  to  " + txt_To.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RPtName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                    
                    obj_da_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 672, 3, Convert.ToInt32(Session["LoginBranchid"]), "FI-FwdHBLDtls");
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                }
                else
                {
                    //report.strfrmname = "ForwarderBLvsHBL"
                    str_RPtName = "forwardervshbl.rpt";
                    str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.jobno}=" + txt_jobno.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RPtName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                    obj_da_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 672, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text + "FI-FwdHBLDtls");
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if(btn_cancel.ToolTip=="Cancel")
            {
            lbl_fbl.Visible = false;
            lbl_hbl.Visible = false;
            txt_jobno.Text = "";          
            grd.DataSource = new DataTable();
            grd.DataBind();
            btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel2.Attributes["class"] = "btn ico-back";
            txt_jobno.Focus(); 
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
            GridViewlog.Visible = true;
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 672, "Job", txt_jobno.Text, txt_jobno.Text, Session["StrTranType"].ToString());

            if (txt_jobno.Text != "")
            {
                JobInput.Text = txt_jobno.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grd_PreRender(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                grd.UseAccessibleHeader = true;
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}