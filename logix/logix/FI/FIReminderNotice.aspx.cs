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
    public partial class FIReminderNotice : System.Web.UI.Page
    {
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
        DataAccess.ForwardingImports.ReminderNotice obj_da_reminder = new DataAccess.ForwardingImports.ReminderNotice();
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        DataAccess.Corporate obj_da_corp = new DataAccess.Corporate();
        DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
        string str_FornName, str_Uiid;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();dropdown();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Logobj.GetDataBase(Ccode);
                obj_da_can.GetDataBase(Ccode);
                obj_da_reminder.GetDataBase(Ccode);
                obj_da_log.GetDataBase(Ccode);


                obj_da_corp.GetDataBase(Ccode);
                obj_da_BL.GetDataBase(Ccode);



            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
           
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(grd_job);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_forwarder);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cnsg);
            if (!IsPostBack)
            {
               // Mdl_rnotice.Show();
                bind();
                UserRights();
            }
        }

        public void bind()
        {
            DataTable obj_dtreminder = new DataTable();
            //DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
            obj_dtreminder = obj_da_can.GetDetails(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            grd_job.DataSource = obj_dtreminder;
            grd_job.DataBind();
            btn_cancel.Text = "Cancel";
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
                    Utility.Fn_CheckUserRights(str_Uiid, null, btn_cnsg, null);
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
            //Mdl_rnotice.Hide();
            DataTable obj_dtRnotice = new DataTable();
            //DataAccess.ForwardingImports.ReminderNotice obj_da_reminder = new DataAccess.ForwardingImports.ReminderNotice();
            int index = Convert.ToInt32(hf_grdjob_index.Value);
            //txt_vslvoy.Text = grd_job.Rows[index].Cells[1].Text.ToString();
            //txt_agent.Text = grd_job.Rows[index].Cells[2].Text.ToString();
            //txt_line.Text = grd_job.Rows[index].Cells[3].Text.ToString();
            //txt_eta.Text = grd_job.Rows[index].Cells[4].Text.ToString();
            //txt_etb.Text = grd_job.Rows[index].Cells[5].Text.ToString();

            txt_vslvoy.Text = ((Label)grd_job.Rows[index].Cells[1].FindControl("Vessel")).Text;
            txt_agent.Text = ((Label)grd_job.Rows[index].Cells[2].FindControl("Agent")).Text;
            txt_line.Text = ((Label)grd_job.Rows[index].Cells[3].FindControl("MLO")).Text;
            txt_eta.Text = ((Label)grd_job.Rows[index].Cells[4].FindControl("ETA")).Text;
            txt_etb.Text = ((Label)grd_job.Rows[index].Cells[5].FindControl("ETB")).Text;
            obj_dtRnotice = obj_da_reminder.GetBLJobNo(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            ddl_hblno.Items.Clear();
            if (obj_dtRnotice.Rows.Count > 0)
            {
                pnl_rnotice.Visible = true;
                ddl_hblno.DataSource = obj_dtRnotice;
                //ddl_hblno.DataValueField="blno";
                ddl_hblno.DataTextField = "blno";
                ddl_hblno.DataBind();
            }
            Mdl_rnotice.Show();
        }

        protected void btn_forwarder_Click(object sender, EventArgs e)
        {
            fn_btnforwarder_Click();
            UserRights();
        }

        public void fn_btnforwarder_Click()
        {
            //report("FIFWDRemainderNotice.rpt");
            string str_frmname = "";
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
            string bookingno;
            //DataAccess.ForwardingImports.ReminderNotice obj_da_reminder = new DataAccess.ForwardingImports.ReminderNotice();
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            //DataAccess.Corporate obj_da_corp = new DataAccess.Corporate();
            //DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
            DataTable obj_dtrnotice = new DataTable();
            string str_BL;
            str_BL = ddl_hblno.SelectedValue;

            if (str_BL == "")
            {
                obj_dtrnotice = obj_da_reminder.GetBLJobNo(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtrnotice.Rows.Count > 0)
                {
                    str_BL = obj_dtrnotice.Rows[0][3].ToString();
                }
            }
            else
            {
                obj_dtrnotice = obj_da_reminder.GetBLNo(str_BL, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtrnotice.Rows.Count > 0)
                {
                    str_BL = obj_dtrnotice.Rows[0][3].ToString();
                }
            }

            if (str_BL != "")
            {
                str_frmname = "RemainderNotice";
                //str_RptName = Rptname;
                //str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.blno}=\"" + str_BL + "\"";
                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_Script = "window.open('../Reportasp/FIFWDRemainderNoticeReport.aspx?bid=" + Convert.ToInt32(Session["LoginBranchid"]) + "&blno=" + str_BL + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_forwarder, typeof(Button), "Freight Certificate", str_Script, true);
                          
                bookingno = obj_da_BL.GetBookinkNo(str_BL, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                obj_da_corp.UpdShipmentStatus(bookingno, "FI", Convert.ToInt32(Session["LoginBranchid"]), "Remainder Notice");
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 115, 3, Convert.ToInt32(Session["LoginBranchid"]), str_BL);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
        }

        public void report(string Rptname)
        {
            string str_frmname = "";
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
            string bookingno;
            //DataAccess.ForwardingImports.ReminderNotice obj_da_reminder = new DataAccess.ForwardingImports.ReminderNotice();
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            //DataAccess.Corporate obj_da_corp = new DataAccess.Corporate();
            //DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
            DataTable obj_dtrnotice = new DataTable();
            string str_BL;
            str_BL = ddl_hblno.SelectedValue;

            if (str_BL == "")
            {
                obj_dtrnotice = obj_da_reminder.GetBLJobNo(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtrnotice.Rows.Count > 0)
                {
                    str_BL = obj_dtrnotice.Rows[0][3].ToString();
                }
            }
            else
            {
                obj_dtrnotice = obj_da_reminder.GetBLNo(str_BL, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtrnotice.Rows.Count > 0)
                {
                    str_BL = obj_dtrnotice.Rows[0][3].ToString();
                }
            }

            if (str_BL != "")
            {
                str_frmname = "RemainderNotice";
                str_RptName = Rptname;
                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.blno}=\"" + str_BL + "\"";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_forwarder, typeof(Button), "Freight Certificate", str_Script, true);
                          
                bookingno = obj_da_BL.GetBookinkNo(str_BL, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                obj_da_corp.UpdShipmentStatus(bookingno, "FI", Convert.ToInt32(Session["LoginBranchid"]), "Remainder Notice");
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 115, 3, Convert.ToInt32(Session["LoginBranchid"]), str_BL);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
        }

        protected void btn_cnsg_Click(object sender, EventArgs e)
        {
            fn_btncnsg_Click();
            UserRights();
        }
        public void fn_btncnsg_Click()
        {
            //report("FIRemainderNotice.rpt");
            string str_frmname = "";
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
            string bookingno;
            //DataAccess.ForwardingImports.ReminderNotice obj_da_reminder = new DataAccess.ForwardingImports.ReminderNotice();
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            //DataAccess.Corporate obj_da_corp = new DataAccess.Corporate();
            //DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
            DataTable obj_dtrnotice = new DataTable();
            string str_BL;
            str_BL = ddl_hblno.SelectedValue;

            if (str_BL == "")
            {
                obj_dtrnotice = obj_da_reminder.GetBLJobNo(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtrnotice.Rows.Count > 0)
                {
                    str_BL = obj_dtrnotice.Rows[0][3].ToString();
                }
            }
            else
            {
                obj_dtrnotice = obj_da_reminder.GetBLNo(str_BL, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtrnotice.Rows.Count > 0)
                {
                    str_BL = obj_dtrnotice.Rows[0][3].ToString();
                }
            }

            if (str_BL != "")
            {
                str_frmname = "RemainderNotice";
                //str_RptName = Rptname;
                //str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.blno}=\"" + str_BL + "\"";
                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_Script = "window.open('../Reportasp/FIRemainderNoticeReport.aspx?bid=" + Convert.ToInt32(Session["LoginBranchid"]) + "&blno=" + str_BL + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_forwarder, typeof(Button), "Freight Certificate", str_Script, true);
                          
                bookingno = obj_da_BL.GetBookinkNo(str_BL, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                obj_da_corp.UpdShipmentStatus(bookingno, "FI", Convert.ToInt32(Session["LoginBranchid"]), "Remainder Notice");
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 115, 3, Convert.ToInt32(Session["LoginBranchid"]), str_BL);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.Text == "Cancel")
            {
                fn_btncancel_Click();
            }
            else
            {
              //  this.Response.End();
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
            //ddl_hblno.Items.Clear();
        }

        protected void grd_job_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_job.PageIndex = e.NewPageIndex;
            bind();            
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
    }
}