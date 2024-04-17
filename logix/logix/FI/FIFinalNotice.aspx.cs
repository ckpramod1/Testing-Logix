using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.FI
{
    public partial class FIFinalNotice : System.Web.UI.Page
    {
        string str_FornName, str_Uiid;
        DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
        DataAccess.ForwardingImports.ReminderNotice obj_da_reminder = new DataAccess.ForwardingImports.ReminderNotice();
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();download();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

               
                obj_da_can.GetDataBase(Ccode);
                obj_da_reminder.GetDataBase(Ccode);
                obj_da_log.GetDataBase(Ccode);



            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
           ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(grd_job);
    
           ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_print);
            if (!IsPostBack == true)
            {
                bind();
                UserRights();
            }
        }

        public void bind()
        {
            try
            {
                DataTable obj_dtfinal = new DataTable();
                //DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
                obj_dtfinal = obj_da_can.GetDetails(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                grd_job.DataSource = obj_dtfinal;
                grd_job.DataBind();
                btn_cancel.Text = "Cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
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

        protected void btn_print_Click(object sender, EventArgs e)
        {
            fn_btnprint_Click();
            UserRights();
        }

        public void fn_btnprint_Click()
        {
            string str_frmname = "";
            string str_RptName = "";
            string str_BL = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";

            DataTable obj_dtfnotice = new DataTable();
            //DataAccess.ForwardingImports.ReminderNotice obj_da_reminder = new DataAccess.ForwardingImports.ReminderNotice();
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();

            str_BL = ddl_hblno.SelectedValue.ToString();
            if (str_BL == "")
            {

                obj_dtfnotice = obj_da_reminder.GetBLJobNo(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtfnotice.Rows.Count > 0)
                {
                    str_BL = obj_dtfnotice.Rows[0][3].ToString();
                }
            }
            else
            {
                obj_dtfnotice = obj_da_reminder.GetBLNo(str_BL, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtfnotice.Rows.Count > 0)
                {
                    str_BL = obj_dtfnotice.Rows[0][3].ToString();
                }
            }

            if (str_BL != "")
            {
                str_frmname = "FinalNotice";
                str_RptName = "FIFinalNotice.rpt";
                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.blno}=\"" + str_BL + "\"";
                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_Script = "window.open('../Reportasp/FIFinalReport.aspx?bid=" + Convert.ToInt32(Session["LoginBranchid"]) + "&blno=" + str_BL + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "FinalNotice", str_Script, true);
                
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 116, 3, Convert.ToInt32(Session["LoginBranchid"]), str_BL);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.Text=="Cancel")
            {
                 fn_btncancel_Click();
            }
            else
            {
               // this.Response.End();
                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "CS")
                    {
                        if (Session["StrTranType"] != null)
                        {
                            if (Session["StrTranType"].ToString() == "FI")
                            {
                                Response.Redirect("../Home/OICSHome.aspx");
                            }
                           
                        }
                    }
                }
                else
                {
                    this.Response.End();
                }

            }
        }
        
        public void fn_btncancel_Click()
        {
            txt_vslvoy.Text = "";
            txt_agent.Text = "";
            txt_eta.Text = "";
            txt_etb.Text = "";
            txt_line.Text = "";
            btn_cancel.Text = "Back";
        }

        protected void grd_job_SelectedIndexChanged(object sender, EventArgs e)
        {
            hf_grdjob_index.Value = grd_job.SelectedRow.RowIndex.ToString();
            hf_jobno.Value = ((Label)grd_job.Rows[Convert.ToInt32(hf_grdjob_index.Value)].Cells[0].FindControl("Job")).Text;
            //grd_job.Rows[Convert.ToInt32(hf_grdjob_index.Value)].Cells[0].Text.ToString();
            fn_grdjob_Select();
            UserRights();
        }

        public void fn_grdjob_Select()
        {
            try
            {
                DataTable obj_dtFnotice = new DataTable();
                //DataAccess.ForwardingImports.ReminderNotice obj_da_reminder = new DataAccess.ForwardingImports.ReminderNotice();
                int index = Convert.ToInt32(hf_grdjob_index.Value);
                //txt_vslvoy.Text = grd_job.Rows[index].Cells[1].Text.ToString();
                //txt_agent.Text = grd_job.Rows[index].Cells[2].Text.ToString();
                //txt_line.Text = grd_job.Rows[index].Cells[3].Text.ToString();
                //txt_eta.Text = grd_job.Rows[index].Cells[4].Text.ToString(); ;
                //txt_etb.Text = grd_job.Rows[index].Cells[5].Text.ToString();

                txt_vslvoy.Text = ((Label)grd_job.Rows[index].Cells[1].FindControl("Vessel")).Text;
                txt_agent.Text = ((Label)grd_job.Rows[index].Cells[2].FindControl("Agent")).Text;
                txt_line.Text = ((Label)grd_job.Rows[index].Cells[3].FindControl("MLO")).Text;
                txt_eta.Text = ((Label)grd_job.Rows[index].Cells[4].FindControl("ETA")).Text;
                txt_etb.Text = ((Label)grd_job.Rows[index].Cells[5].FindControl("ETB")).Text;
                obj_dtFnotice = obj_da_reminder.GetBLJobNo(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                ddl_hblno.Items.Clear();
                if (obj_dtFnotice.Rows.Count > 0)
                {
                    pnl_rnotice.Visible = true;
                    ddl_hblno.DataSource = obj_dtFnotice;
                    //ddl_hblno.DataValueField="blno";
                    ddl_hblno.DataTextField = "blno";
                    ddl_hblno.DataBind();
                }
                Mdl_rnotice.Show();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_job_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblVessel = (Label)e.Row.FindControl("Vessel");
                string tooltip = lblVessel.Text;
                e.Row.Cells[1].Attributes.Add("title", tooltip);

                Label lblAgent = (Label)e.Row.FindControl("Agent");
                string tooltip1 = lblAgent.Text;
                e.Row.Cells[2].Attributes.Add("title", tooltip1);

                Label lblMLO = (Label)e.Row.FindControl("MLO");
                string tooltip2 = lblMLO.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip2);

                Label lblPOL = (Label)e.Row.FindControl("POL");
                string tooltip3 = lblPOL.Text;
                e.Row.Cells[6].Attributes.Add("title", tooltip3);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_job, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_job_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_job.PageIndex = e.NewPageIndex;
            bind();   
        }
    }
}