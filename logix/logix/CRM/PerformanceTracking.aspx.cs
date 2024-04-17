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
    public partial class PerformanceTracking : System.Web.UI.Page
    {
        string submenuname;
        DataAccess.ForwardingExports.JobInfo FEJobobj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingImports.JobInfo FIJobobj = new DataAccess.ForwardingImports.JobInfo();
        DataTable Dt = new DataTable();
        DataTable dtgrid=new DataTable();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        int i;
        string sp = "";
        //string strTrantype = "FE";

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                logobj.GetDataBase(Ccode);
                FEJobobj.GetDataBase(Ccode);
                FIJobobj.GetDataBase(Ccode);
                //LogObj.GetDataBase(Ccode);
                //da_obj_AEJobobj.GetDataBase(Ccode);
                //LogObj.GetDataBase(Ccode);


            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "','_top');", true);
            }
            

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnExporttoexcel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnBack);


            if (Request.QueryString.ToString().Contains("OECSHome"))
            {
                crumbslbl.Attributes["class"] = "crumbslbl";

            }
           if(!IsPostBack)
           {
               dtFrom.Text = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
               dtTo.Text = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
               GrdFI.DataSource = null;
               GrdFI.DataBind();
           }
            if (Session["StrTranType"] == "FE")
            {
                Panel1.Visible = true;
                GrdFI.Visible = false;
                //dtgrid = FEJobobj.GetGridHeader("Y");
                ////Dt = FEJobobj.GetFEBookPerformanceTrack(LoginBranchid, LoginDivisionId, Session["StrTranType"].ToString(), FromDate, ToDate);
                //DataTable datagrid = new DataTable();
                //for (int i = 0; i < dtgrid.Rows.Count; i++)
                //{
                //    datagrid.Columns.Add(Convert.ToString(dtgrid.Rows[i]["Events"]));
                //}
                //GrdFI.DataSource = datagrid;
                
                //for (int i = 0; i < datagrid.Columns.Count; i++)
                //{

                //    GrdFI.Columns[i].HeaderText = datagrid.Columns[i].ColumnName;
                    
                //}

            }
            else if (Session["StrTranType"] == "FI")
            {
                Panel2.Visible = true;
                grdFE.Visible = false;
                
            }
            //dtFrom.Text = Convert.ToDateTime(logobj.GetDate()).ToString();
            //dtTo.Text = Convert.ToDateTime(logobj.GetDate()).ToString();
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            if (dtFrom.Text == "" || dtTo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "PerformanceTracking", "alertify.alert('Select the date');", true);
            }
            else { 
                bind(); 
            }
        }
        public void bind()
        {
            try
            {
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1455, 3, Convert.ToInt32(Session["LoginBranchid"]), "/From: " + dtFrom.Text + "/To: " + dtTo.Text + "/ Get");
                int LoginBranchid = Convert.ToInt16(Session["LoginBranchid"]);
                int LoginDivisionId = Convert.ToInt16(Session["LoginDivisionId"]);
                int LoginEmpId = Convert.ToInt16(Session["LoginEmpId"]);
                DateTime fdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(dtFrom.Text));
                DateTime FromDate = fdate;
                DateTime tdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(dtTo.Text));
                DateTime ToDate = tdate;
                if ((Session["StrTranType"].ToString() == "FE"))
                {
                    //dtgrid = FEJobobj.GetGridHeader("Y");
                   // Dt = FEJobobj.GetFEBookPerformanceTrack(LoginBranchid, LoginDivisionId, Session["StrTranType"].ToString(), FromDate, ToDate);
                    //DataTable datagrid = new DataTable();
                    //for (int i = 0;i < dtgrid.Rows.Count;i++)
                    //{
                    //    datagrid.Columns.Add(Convert.ToString( dtgrid.Rows[i]["Events"]));
                    //}
                    //GrdFI.DataSource = datagrid;
                    //int j = 12;
                    //for (int i = 0; i < datagrid.Columns.Count; i++)
                    //{

                    //    GrdFI.Columns[j].HeaderText = datagrid.Columns[i].ColumnName;
                    //    j++;
                    // }
                    Dt = FEJobobj.GetFEBookPerformanceTrackEvents(LoginBranchid, LoginDivisionId, Session["StrTranType"].ToString(), FromDate, ToDate);
                    //GrdFI.DataSource = Dt;
                    //GrdFI.DataBind();
                    GrdFI.Visible = true;

                    //DataTable dtevent = new DataTable();

                    //dtevent = FEJobobj.GetEvent(FromDate, ToDate);

                    GrdFI.DataSource = Dt;
                    GrdFI.DataBind();

                    //GrdFI.DataSource = Dt;
                    //GrdFI.DataBind();
                    //GrdFI.DataBind();

                    //logobj.InsLogDetail(LoginEmpId, 1455, 3, LoginBranchid, ("/From: " + (dtFrom.Text.ToString() + ("/To: " + (dtTo.Text.ToString() + "/ Get")))));
                    //if ((GrdFI.Rows.Count > 0))
                    //{
                    //    btnBack.Text = "Clear";
                    //}
                    btnBack.Text = "Cancel";
                    btnBack.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('No Record Found plz select previous month Records');", true);
                }
            }
            catch (Exception ex)
            {
                //string message = ex.Message.ToString();
                //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alertify.alert('" + message + "');", true);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../FormMain.aspx','_top');", true);
            }

        }

        protected void btnBack_Click(object sender, System.EventArgs e)
        {
           if(btnBack.ToolTip=="Back")
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

                       }
                   }
               }
               else if (Request.QueryString.ToString().Contains("OECSHome"))
               {
                   Response.Redirect("../Home/OECSHome.aspx");
               }
               
               else
               {
                     this.Response.End();
               }
           }else
           {
               dtFrom.Text = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
               dtTo.Text = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
               GrdFI.DataSource = null;
               GrdFI.DataBind();
               btnBack.Text = "Back";
               btnBack.ToolTip = "Back";
               btn_back1.Attributes["class"] = "btn ico-back";
           }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btnExporttoexcel_Click(object sender, System.EventArgs e)
        {
            if (dtFrom.Text == "" || dtTo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "PerformanceTracking", "alertify.alert('Select the date');", true);
            }
            else
            {
                try
                {
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1455, 3, Convert.ToInt32(Session["LoginBranchid"]), "/From: " + dtFrom.Text + "/To: " + dtTo.Text + "/ Excel");
                    int LoginBranchid = Convert.ToInt16(Session["LoginBranchid"]);
                    int LoginDivisionId = 1;//Convert.ToInt16(Session["LoginDivisionId"]);
                    int LoginEmpId = Convert.ToInt16(Session["LoginEmpId"]);
                    DateTime fdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(dtFrom.Text));
                    DateTime FromDate = fdate;
                    DateTime tdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(dtTo.Text));
                    DateTime ToDate = tdate;

                    if ((Session["StrTranType"] == "FI"))
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("content-disposition", "attachment;filename=PerformanceTracking_OI.xls");
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.ms-excel";
                        using (StringWriter sw = new StringWriter())
                        {
                            HtmlTextWriter hw = new HtmlTextWriter(sw);

                            //To Export all pages
                            grdFE.AllowPaging = false;
                            Dt = FEJobobj.GetFEBookStuff(LoginBranchid, LoginDivisionId, FromDate, ToDate);
                            grdFE.DataSource = Dt;
                            grdFE.DataBind();
                            // this.BindGrid();

                            //  grdstate.HeaderRow.BackColor = Color.WHITE;
                            foreach (System.Web.UI.WebControls.TableCell cell in grdFE.HeaderRow.Cells)
                            {
                                cell.BackColor = grdFE.HeaderStyle.BackColor;
                            }
                            foreach (GridViewRow row in grdFE.Rows)
                            {
                                //  row.BackColor = Color
                                foreach (System.Web.UI.WebControls.TableCell cell in row.Cells)
                                {
                                    if (row.RowIndex % 2 == 0)
                                    {
                                        cell.BackColor = grdFE.AlternatingRowStyle.BackColor;
                                    }
                                    else
                                    {
                                        cell.BackColor = grdFE.RowStyle.BackColor;
                                    }
                                    cell.CssClass = "textmode";
                                }
                            }

                            grdFE.RenderControl(hw);

                            //style to format numbers to string
                            string style = @"<style> .textmode { } </style>";
                            Response.Write(style);
                            Response.Output.Write(sw.ToString());
                            Response.Flush();
                            Response.End();
                        }
                    }
                    else if ((Session["StrTranType"] == "FE"))
                    {
                        //Response.Clear();
                        //Response.Buffer = true;
                        //Response.AddHeader("content-disposition", "attachment;filename=PerformanceTracking_OE.xls");
                        //Response.Charset = "";
                        //Response.ContentType = "application/vnd.ms-excel";
                        //using (StringWriter sw = new StringWriter())
                        //{
                        //    HtmlTextWriter hw = new HtmlTextWriter(sw);

                        //    //To Export all pages
                        //    GrdFI.AllowPaging = false;
                        //    Dt = FEJobobj.GetFEBookPerformanceTrack(LoginBranchid, LoginDivisionId, Session["StrTranType"].ToString(), FromDate, ToDate);
                        //    GrdFI.DataSource = Dt;
                        //    GrdFI.DataBind();

                        //    // this.BindGrid();

                        //    //  grdstate.HeaderRow.BackColor = Color.WHITE;
                        //    foreach (System.Web.UI.WebControls.TableCell cell in GrdFI.HeaderRow.Cells)
                        //    {
                        //        cell.BackColor = GrdFI.HeaderStyle.BackColor;
                        //    }
                        //    foreach (GridViewRow row in GrdFI.Rows)
                        //    {
                        //        //  row.BackColor = Color
                        //        foreach (System.Web.UI.WebControls.TableCell cell in row.Cells)
                        //        {
                        //            if (row.RowIndex % 2 == 0)
                        //            {
                        //                cell.BackColor = GrdFI.AlternatingRowStyle.BackColor;
                        //            }
                        //            else
                        //            {
                        //                cell.BackColor = GrdFI.RowStyle.BackColor;
                        //            }
                        //            cell.CssClass = "textmode";
                        //        }
                        //    }

                        //    GrdFI.RenderControl(hw);

                        //    //style to format numbers to string
                        //    string style = @"<style> .textmode { } </style>";
                        //    Response.Write(style);
                        //    Response.Output.Write(sw.ToString());
                        //    Response.Flush();
                        //    Response.End();

                        // }
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.Charset = "";
                        string FileName = "PerformanceTracking_OE" + DateTime.Now + ".xls";
                        StringWriter strwritter = new StringWriter();
                        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);

                        grdFE.AllowPaging = false;
                        Dt = FEJobobj.GetFEBookPerformanceTrackEvents(LoginBranchid, LoginDivisionId, Session["StrTranType"].ToString(), FromDate, ToDate);
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
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('No Record Found plz select previous month Records');", true);
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../Login.aspx','_top');", true);
                }
            }
        }

        protected void GrdFI_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdFI.PageIndex = e.NewPageIndex;
            bind();
            Panel1.Visible = true;
        }

        protected void grdFE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFE.PageIndex = e.NewPageIndex;
            bind();
            Panel2.Visible = true;
        }

        protected void GrdFI_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                //Label lblCustomer = (Label)e.Row.FindControl("shipper");
                //string tooltip = lblCustomer.Text;
                //e.Row.Cells[5].Attributes.Add("title", tooltip);
                //Label lblCustomer1 = (Label)e.Row.FindControl("consignee");
                //string tooltip1 = lblCustomer1.Text;
                //e.Row.Cells[6].Attributes.Add("title", tooltip1);
                //Label lblCustomer2 = (Label)e.Row.FindControl("nomination");
                //string tooltip2 = lblCustomer2.Text;
                //e.Row.Cells[7].Attributes.Add("title", tooltip2);

               
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