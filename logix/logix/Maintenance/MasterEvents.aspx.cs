using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Web.Services.Description;

namespace logix.Maintenance
{
    public partial class MasterEvent : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataTable dt = new DataTable();
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        DataAccess.Masters.MasterEvents objp = new DataAccess.Masters.MasterEvents();
        DataTable obj_dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_da_Log.GetDataBase(Ccode);
                objp.GetDataBase(Ccode);
               




            }


            btn_delete.Click += btn_delete_Click;
            btn_delete.OnClientClick = @"return getConfirmationValue();";
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            //LinkButton1.ServerClick += new EventHandler(Excelfunforserver_Click);
            //LinkButton2.ServerClick += new EventHandler(pdffunforserver_Click);
            btn_delete.Visible = false;btn_delete_id.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    Ctrl_List = txt_events.ID;
                    Msg_List = "Events";
                    Dtype_List = "string";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, null, null);
                    btn_save.Enabled = false;
                    // btn_delete.Enabled = false;
                    btn_delete.Visible = false;btn_delete_id.Visible = false;
                    btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    get_display();
                    //GridTopRowDisplay();
                    txt_events.Focus();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

            }
            else if (Page.IsPostBack)
            {

                //WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                //int indx = wcICausedPostBack.TabIndex;
                //var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                //           where control.TabIndex > indx
                //           select control;
                //ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);

            }

        }
        [WebMethod]
        public static List<string> getEvents(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterEvents objp = new DataAccess.Masters.MasterEvents();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objp.GetDataBase(Ccode);
            dt = objp.LikeEventName(prefix.ToUpper());
            list_result = Utility.Fn_TableToList(dt, "eventname", "eventid");
            return list_result;
        }


        protected Control GetControlThatCausedPostBack(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button || c is System.Web.UI.WebControls.ImageButton)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;
        }

        [WebMethod]
        public static void GetEmpName(string Prefix)
        {

            DataTable obj_dtEmp = new DataTable();

            if (Prefix.Length > 0)
            {
                DataAccess.Masters.MasterEvents objp = new DataAccess.Masters.MasterEvents();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                objp.GetDataBase(Ccode);
                DataTable obj_dt = new DataTable();
                obj_dt = objp.LikeEventName(Prefix.ToUpper());
                obj_dtEmp.Columns.Add("eventname");
                obj_dtEmp.Columns.Add("eventid");

                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["eventname"] = obj_dt.Rows[i][0].ToString();

                    dr["eventid"] = obj_dt.Rows[i][1].ToString();

                }
                HttpContext.Current.Session["Date"] = obj_dtEmp;

            }

        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            DataTable obj_dtEmp = new DataTable();
            if (txt_Search.Text != "")
            {

                if (Session["Date"] != null)
                {
                    obj_dtEmp = (DataTable)Session["Date"];
                    ViewState["Mevent"] = obj_dtEmp;
                    eventgrid.DataSource = obj_dtEmp;
                    eventgrid.DataBind();

                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
                btn_cancel.Text = "Cancel";


                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            else
            {
                eventgrid.DataSource = null;
                eventgrid.DataBind();
            }
        }


        protected void get_display()
        {
            eventgrid.DataSource = new DataTable();
            eventgrid.DataBind();
        }


        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                btn_save.Enabled = true;
                btn_delete.Visible = false;btn_delete_id.Visible = false;
                if (btn_save.ToolTip == "Save")
                {
                    if (hiddenid.Value == "")
                    {
                        objp.InsertEvent(txt_events.Text.Trim().ToUpper());
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 133, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_events.Text.ToUpper()+"/Sav");                               
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Event", "alertify.alert('Saved Successfully');", true);

                        //gridview();
                        //btn_save.Text = "Update";
                        btn_cancel.Text = "Clear";

                        btn_cancel.ToolTip = "Clear";
                        btn_cancel1.Attributes["class"] = "btn ico-clear";
                        //GridTopRowDisplay();
                        clear();
                    }
                }
                else
                {
                    if (hiddenid.Value != "")
                    {
                        int eid = Convert.ToInt32(hiddenid.Value.ToString());
                        objp.UpdateEvent(eid, txt_events.Text.ToUpper());
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 133, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_events.Text.ToUpper() + "/Upd");                               
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Event", "alertify.alert('Updated Successfully');", true);

                      //  GridTopRowDisplay();
                        //gridview();
                         btn_save.Text = "Save";
                         btn_cancel.Text = "Clear";


                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                        btn_cancel.ToolTip = "Clear";
                        btn_cancel1.Attributes["class"] = "btn ico-clear";
                        clear();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txt_Search.Focus();
        }
        public void checkdata()
        {
            if (txt_events.Text == "")
            {

                txt_events.Focus();

            }
            else if (txt_events.Text == "")
            {
                txt_events.Text = "Enter Value";
                txt_events.Focus();
            }
        }

        public void checkEvent()
        {
            if (txt_events.Text != "")
            {
                dt = objp.CheckEventExist(txt_events.Text.ToUpper());

                if (dt.Rows.Count > 0)
                {
                    hiddenid.Value = dt.Rows[0]["eventid"].ToString();

                    ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "MasterEvents", "alertify.alert('Event Name Already Exists...');", true);
                     btn_save.Text = "Update";

                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn ico-update";

                   
                }
            }
        }

        private void clear()
        {
            txt_events.Text = "";
            hiddenid.Value = "";
            btn_save.Text = "Save";
             btn_cancel.Text = "Back";

            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";


            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
           // GridTopRowDisplay();
            signup.Visible = false;
        }

        protected void txt_events_TextChanged(object sender, EventArgs e)
        {
            try
            {
               // checkEvent();
                btn_save.Enabled = true;
                //  btn_delete.Enabled = false;
                btn_delete.Visible = false;btn_delete_id.Visible = false;
                if (hiddenid.Value == "0")
                {
                    return;
                }
                if (hiddenid.Value != "")
                {
                    DataTable dt1 = new DataTable();
                    int eid = Convert.ToInt32(hiddenid.Value.ToString());
                    dt1 = objp.GetEventName(eid);
                    if (dt1.Rows.Count > 0)
                    {
                        //txt_events.Text = dt1.Rows[0]["eventname"].ToString();
                         btn_save.Text = "Update";
                         btn_cancel.Text = "Cancel";

                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";


                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                        checkEvent();

                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txt_events.Focus();
           
        }

        private void gridbind()
        {
           
            DataTable ds = new DataTable();
            ds = objp.GetGridview();
            if (ds.Rows.Count > 0)
            {
                eventgrid.DataSource = ds;
                eventgrid.DataBind();
            }

        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                //eventgrid.Visible = true;
                //signup.Visible = true;
                //// btn_delete.Enabled = false;
                //btn_delete.Visible = false;btn_delete_id.Visible = false;
                //empty_grid();                
                //gridbind();
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                str_RptName = "MasterEvent.rpt";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "MasterEvents", str_Script, true);
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 133, 3, int.Parse(Session["LoginBranchid"].ToString()), "EventView");                               
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 
        }

        public void gridview()
        {
            eventgrid.Visible = true;                      
            empty_grid();
            gridbind();
        }

        //private void GridTopRowDisplay()
        //{
        //    DataTable dt_top = new DataTable();
        //    dt_top = objp.GetTOPEventRows();
        //    if (dt_top.Rows.Count > 0)
        //    {
        //        eventgrid.DataSource = dt_top;
        //        eventgrid.DataBind();
        //    }

        //}

        private void empty_grid()
        {
            DataTable dt_emp = new DataTable();
            eventgrid.DataSource = dt_emp;
            eventgrid.DataBind();
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            bool type = false;

            if (hfWasConfirmed.Value == "true")
            {
                if (hiddenid.Value != "")
                {
                    int eventid = Convert.ToInt32(hiddenid.Value.ToString());
                    //objp.DelTableEvent(eventid);
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Event", "alertify.alert('Your Event deleted');", true);
                    clear();
                    gridbind();
                }                               
            }   
        }
        public void checkdataevent()
        {
            if (txt_events.Text == "")
            {

                txt_events.Focus();

            }
            else if (txt_events.Text == "")
            {
                txt_events.Text = "Enter Events";
                txt_events.Focus();
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
           // btn_delete.Enabled = false;
            btn_delete.Visible = false;btn_delete_id.Visible = false;
            if (btn_cancel.ToolTip == "Back")
            {
                this.Response.End();

            }
            else
            {
                txt_events.Focus();
                clear();
                signup.Visible = false;
               // GridTopRowDisplay();
                get_display();
                txt_Search.Text = "";
            }
        }

        protected void btn_ep_Click(object sender, EventArgs e)
        {
            try
            {
                ExportGridToPDF();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 
        }

        private void ExportGridToPDF()
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Events.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            eventgrid.AllowPaging = false;
            //sectorid = Convert.ToInt32(hdn_id.Value.ToString());
            dt = objp.GetGridview();
            eventgrid.DataSource = dt;
            eventgrid.DataBind();
            signup.Visible = true;

            eventgrid.RenderControl(hw);
            eventgrid.HeaderRow.Style.Add("width", "5%");
            eventgrid.HeaderRow.Style.Add("font-size", "10px");
            eventgrid.Style.Add("text-decoration", "none");
            eventgrid.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            eventgrid.Style.Add("font-size", "8pt");
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btn_ee_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 
        }
        protected void ExportToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Events.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                eventgrid.AllowPaging = false;
                gridbind();
                //  grdstate.HeaderRow.BackColor = Color.WHITE;
                foreach (System.Web.UI.WebControls.TableCell cell in eventgrid.HeaderRow.Cells)
                {
                    cell.BackColor = eventgrid.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in eventgrid.Rows)
                {
                    //  row.BackColor = Color
                    foreach (System.Web.UI.WebControls.TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = eventgrid.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = eventgrid.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                eventgrid.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }


        protected void Excelfunforserver_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 
        }
        protected void pdffunforserver_Click(object sender, EventArgs e)
        {
            try
            {
                ExportGridToPDF();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 
        }

        protected void eventgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            eventgrid.PageIndex = e.NewPageIndex;
            gridbind();

        }



        public Control btnDelete { get; set; }

        protected void eventgrid_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            eventgrid.PageIndex = e.NewPageIndex;
            eventgrid.DataSource = (DataTable)ViewState["Mevent"];
            eventgrid.DataBind();
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

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 133, "MSevents", txt_events.Text, txt_events.Text, "");  //"/Rate ID: " +
            if (txt_events.Text != "")
            {
                JobInput.Text = txt_events.Text;


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

