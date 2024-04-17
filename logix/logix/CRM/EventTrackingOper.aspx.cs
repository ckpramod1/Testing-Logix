using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text.RegularExpressions;
using System.Drawing;

namespace logix.CRM
{
    public partial class EventTrackingOper : System.Web.UI.Page
    {
        string submenuname;
        DataAccess.ForwardingExports.JobInfo FEJobobj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingImports.JobInfo FIJobobj = new DataAccess.ForwardingImports.JobInfo();
        DataTable Dt = new DataTable();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        int i;
        string sp = "";
        //string strTrantype = "FE";

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnExporttoexcel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnBack);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }


            if (Request.QueryString.ToString().Contains("EventTrackingOper"))
            {
                crumbslbl.Attributes["class"] = "crumbslbl";

            }

            if (IsPostBack != true)
            {
                DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
                dtFrom.Text = Utility.fn_ConvertDate(obj_da_Logobj.GetDate().ToString());
                dtTo.Text = Utility.fn_ConvertDate(obj_da_Logobj.GetDate().ToString());
                //dtFrom.Text = Utility.fn_ConvertDate(obj_da_Logobj.GetDate().ToShortDateString());
                //dtTo.Text = dtFrom.Text;
                 btnBack.Text = "Cancel";
                btnBack.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            if (Session["StrTranType"] == "FE")
            {
                tran.InnerText = "Ocean Exports";
                GrdFI.Visible = true;
            }
            else if (Session["StrTranType"] == "FI")
            {
                tran.InnerText = "Ocean Imports";
                 grdFE.Visible = false;
            }

          //  btnBack.Text = "Cancel";
            Panel1.Visible = false;
            Panel2.Visible = false; 
            //dtFrom.Text = Convert.ToDateTime(logobj.GetDate()).ToString();
            //dtTo.Text = Convert.ToDateTime(logobj.GetDate()).ToString();
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            if (dtFrom.Text == "" || dtTo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "EventTracking", "alertify.alert('Select the date');", true);
            }
            else 
            { 
               bind();
               btnBack.Text = "Cancel";
               btnBack.ToolTip = "Cancel";
               btn_cancel1.Attributes["class"] = "btn ico-cancel";

            }            
        }
        
        public void bind()
        {
            try
            {
                int LoginBranchid = Convert.ToInt16(Session["LoginBranchid"]);
                int LoginDivisionId = Convert.ToInt16(Session["LoginDivisionId"]);
                int LoginEmpId = Convert.ToInt16(Session["LoginEmpId"]);
                DateTime fdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(dtFrom.Text));
                DateTime FromDate = fdate;
                DateTime tdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(dtTo.Text));
                DateTime ToDate = tdate;

                if (Session["StrTranType"] == "FE")
                {
                    Dt = FEJobobj.GetFEBookStuff(LoginBranchid, LoginDivisionId, FromDate, ToDate);
                    if (Dt.Rows.Count > 0)
                    {
                        grdFE.DataSource = Dt;
                        grdFE.DataBind();
                        Panel1.Visible = true;
                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "EventTracking", "alertify.alert('No Data in Records);", true);
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('No Record Found plz select previous month Records');", true);
                    }

                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 628, 3, Convert.ToInt32(Session["LoginBranchid"]), "/From: " + dtFrom.Text + "/To: " + dtTo.Text + "/ Get");
                }
                else if (Session["StrTranType"] == "FI")
                {
                    Dt = FIJobobj.SelFIEventTrackOper(LoginBranchid, FromDate, ToDate, LoginDivisionId);
                    if (Dt.Rows.Count > 0)
                    {
                        GrdFI.DataSource = Dt;
                        GrdFI.DataBind();
                        Panel2.Visible = true;
                    }
                    else
                    {
                        //  ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "EventTracking", "alertify.alert('No Data in Records);", true);
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('No Record Found plz select previous month Records');", true);
                    }
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 679, 3, Convert.ToInt32(Session["LoginBranchid"]), "/From: " + dtFrom.Text + "/To: " + dtTo.Text + "/ Get");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "EventTracking", "alertify.alert('Session Expire TranType');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../Login.aspx','_top');", true);
            }
        }
       
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btnExporttoexcel_Click(object sender, EventArgs e)
        {
            if (dtFrom.Text == "" || dtTo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "EventTracking", "alertify.alert('Select the date');", true);
            }
            else
            {
                try
                {
                    int LoginBranchid = Convert.ToInt16(Session["LoginBranchid"]);
                    int LoginDivisionId = Convert.ToInt16(Session["LoginDivisionId"]);
                    int LoginEmpId = Convert.ToInt16(Session["LoginEmpId"]);
                    DateTime fdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(dtFrom.Text));
                    DateTime FromDate = fdate;
                    DateTime tdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(dtTo.Text));
                    DateTime ToDate = tdate;

                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 628, 3, Convert.ToInt32(Session["LoginBranchid"]), "/From: " + dtFrom.Text + "/To: " + dtTo.Text + "/ Excel");

                        Response.Clear();
                        Response.Buffer = true;
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.Charset = "";
                        string FileName = "EventTrackingOper_FE" + DateTime.Now + ".xls";
                        StringWriter strwritter = new StringWriter();
                        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);

                        grdFE.AllowPaging = false;
                        Dt = FEJobobj.GetFEBookStuff(LoginBranchid, LoginDivisionId, FromDate, ToDate);
                        grdFE.DataSource = Dt;
                        grdFE.DataBind();

                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                        grdFE.GridLines = GridLines.Both;
                        grdFE.HeaderStyle.Font.Bold = true;
                        grdFE.RenderControl(htmltextwrtter);
                        Response.Write(strwritter.ToString());
                        Response.End();
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 679, 3, Convert.ToInt32(Session["LoginBranchid"]), "/From: " + dtFrom.Text + "/To: " + dtTo.Text + "/ Excel");

                        Response.Clear();
                        Response.Buffer = true;
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.Charset = "";
                        string FileName = "EventTrackingOper_FI" + DateTime.Now + ".xls";
                        StringWriter strwritter = new StringWriter();
                        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);

                        GrdFI.AllowPaging = false;
                        Dt = FIJobobj.SelFIEventTrackOper(LoginBranchid, FromDate, ToDate, LoginDivisionId);
                        GrdFI.DataSource = Dt;
                        GrdFI.DataBind();

                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                        GrdFI.GridLines = GridLines.Both;
                        GrdFI.HeaderStyle.Font.Bold = true;
                        GrdFI.RenderControl(htmltextwrtter);
                        Response.Write(strwritter.ToString());
                        Response.End();
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../FormMain.aspx','_top');", true);
                }
            }
            btnBack.Text = "Cancel";
            btnBack.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            Panel1.Visible = true;
            Panel2.Visible = true; 
        }
        protected void grdFE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFE.PageIndex = e.NewPageIndex;
            bind();
            Panel1.Visible = true;
            //Panel2.Visible = true; 
        }

        protected void GrdFI_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdFI.PageIndex = e.NewPageIndex;
            bind();
            //Panel1.Visible = true;
            Panel2.Visible = true; 
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            DataAccess.LogDetails da_obj_LogObj = new DataAccess.LogDetails();
            if( btnBack.ToolTip == "Cancel")
            {
                dtFrom.Text = Utility.fn_ConvertDate(da_obj_LogObj.GetDate().ToString());
                dtTo.Text = Utility.fn_ConvertDate(da_obj_LogObj.GetDate().ToString());
                grdFE.DataSource = null;
                grdFE.DataBind();
                GrdFI.DataSource = null;
                GrdFI.DataBind();
                Panel1.Visible = false;
                Panel2.Visible = false;
                btnBack.Text = "Back";
                btnBack.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "CS")
                    {
                        if (Session["StrTranType"] != null)
                        {
                            if (Session["StrTranType"].ToString() == "FE")
                            {
                                Response.Redirect("../Home/OECSHome.aspx");
                            }
                            else  if (Session["StrTranType"].ToString() == "FI")
                            {
                                Response.Redirect("../Home/OICSHome.aspx");
                            }
                        }
                    }
                }
                else if (Request.QueryString.ToString().Contains("EventTrackingOper"))
                {
                    Response.Redirect("../Home/OICSHome.aspx");
                }                  
               else
                 {
                     this.Response.End();

               }
               
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

            //obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 762, "Job", txt_jobno.Text, txt_jobno.Text, Session["StrTranType"].ToString());

            switch (Session["StrTranType"].ToString())
            {
                case "FE":
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 628, "Job", "", "", Session["StrTranType"].ToString());
                    break;

                case "FI":
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 679, "Job", "", "", Session["StrTranType"].ToString());
                    break;
            }

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

        protected void grdFE_PreRender(object sender, EventArgs e)
        {
            if (grdFE.Rows.Count > 0)
            {
                grdFE.UseAccessibleHeader = true;
                grdFE.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdFI_PreRender(object sender, EventArgs e)
        {
            if (GrdFI.Rows.Count > 0)
            {
                GrdFI.UseAccessibleHeader = true;
                GrdFI.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}
       