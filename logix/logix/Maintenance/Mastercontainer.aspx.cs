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
using System.Web.Services.Description;

namespace logix.Maintenance
{
    public partial class Mastercontainer : System.Web.UI.Page
    {
        DataAccess.Masters.MasterContainer MasterContainer = new DataAccess.Masters.MasterContainer();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataSet dt_grdFill = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                MasterContainer.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
               



            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
          //  btn_delete.Click += btn_delete_Click;
         //   btn_delete.OnClientClick = @"return getConfirmationValue();";
            //excel.ServerClick += new EventHandler(Excelfunforserver_Click);
            //pdf.ServerClick += new EventHandler(pdffunforserver_Click);
            FillgrdonpageLoad();
            string Ctrl_List;
            string Msg_List;
            string Dtype_List;
            string str_Uiid = "";
            btn_delete.Visible = false;btn_delete_id.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    Ctrl_List = txt_ctype.ID + "~" + txt_description.ID;
                    Msg_List = "Container Type~Container Descripton";
                    Dtype_List = "string~string";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    btn_delete.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, null, null);
                    Utility.Fn_CheckUserRights(str_Uiid, btn_delete, null, null);
                    //btn_save.Enabled = false;
                    //btn_delete.Enabled = false;
                    btn_delete.Visible = false;btn_delete_id.Visible = false;
                    txt_ctype.Focus();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
            else if (Page.IsPostBack)
            {
                WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                int indx = wcICausedPostBack.TabIndex;
                var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                           where control.TabIndex > indx
                           select control;
                ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
            }

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
        public static List<string> GetLikeContType(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterContainer FA = new DataAccess.Masters.MasterContainer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            FA.GetDataBase(Ccode);
            dt = FA.GetLikeContType(prefix.ToUpper());
            list_result = Utility.Fn_TableToList(dt, "conttype", "conttype");
            return list_result;
        }



        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (btn_save.ToolTip == "Save")
            {
                try
                {

                    MasterContainer.InsertMasterConttype(txt_ctype.Text.ToUpper(), txt_description.Text.ToUpper(), txt_height.Text.ToUpper());
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master ContainerType", "alertify.alert('Container Type details has Saved');", true);
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 337, 1, int.Parse(Session["LoginBranchid"].ToString()), "Save");
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master ContainerType", "alertify.alert('Error!!! Try Again...');", true);
                }

            }
            else
            {
                try
                {
                    MasterContainer.UpdMasterConttype(txt_ctype.Text.ToUpper(), txt_description.Text.ToUpper(), Convert.ToInt32(hiddenid.Value), txt_height.Text.ToUpper());
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master ContainerType", "alertify.alert('Container Type details has updated');", true);
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 337, 2, int.Parse(Session["LoginBranchid"].ToString()), "Update");
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master ContainerType", "alertify.alert('Error!!! Try Again...');", true);
                }
            }
            clear();
        }


        public void clear()
        {
            txt_ctype.Text = "";
            txt_description.Text = "";
            txt_height.Text = "";
            btn_save.Text = "Save";
             btn_cancel.Text = "Back";

            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";

            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";

            FillgrdonpageLoad();

        }
        protected void txt_ctype_TextChanged(object sender, EventArgs e)
        {
            btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            try
            {

                DataTable dt = new DataTable();

                dt = MasterContainer.SelMasterConttype(txt_ctype.Text);
                if (dt.Rows.Count > 0)
                {
                    hiddenid.Value = dt.Rows[0]["conttypeid"].ToString();
                    txt_description.Text = dt.Rows[0]["descn"].ToString();
                    txt_height.Text = dt.Rows[0]["height"].ToString();

                }

            }
            catch
            {
                Response.Write("<script>alertify.alert('check your code')</script>");
            }
            if (!(txt_description.Text == ""))
            {
                 btn_save.Text = "Update";

                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn ico-update";
            }

            btn_save.Enabled = true;
            //  btn_delete.Enabled = false;

            btn_delete.Visible = false;btn_delete_id.Visible = false;
        }
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (hfWasConfirmed.Value == "true")
            {
                try
                {
                    MasterContainer.Deletecontainertype(Convert.ToInt32(hiddenid.Value));
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master ContainerType", "alertify.alert('Container Type details has Deleted...');", true);
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 337, 4, int.Parse(Session["LoginBranchid"].ToString()), "Delete");

                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master ContainerType", "alertify.alert('You Container Not deleted, Check You entered Container Name');", true);
                }
            }
            clear();
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
                txt_ctype.Focus();
                clear();
                containergrid.Visible = false;
                signup.Visible = false;
                FillgrdonpageLoad();

            }
        }
        public void FillgrdonpageLoad()
        {
            dt_grdFill = MasterContainer.containerpagegird();
            containergrid.Visible = true;
            containergrid.DataSource = dt_grdFill;
            containergrid.DataBind();
        }
        protected void gridbind()
        {
            DataSet ds = new DataSet();
            ds = MasterContainer.GetContainersize();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dtpkg = new DataTable();
                dtpkg = ds.Tables[0];
                containergrid.DataSource = dtpkg;
                containergrid.DataBind();
            }
        }
        protected void btn_view_Click(object sender, EventArgs e)
        {
            //  gridbind();
            //  signup.Visible = true;
            //  btn_cancel.Text = "Clear";
            ////  btn_delete.Enabled = false;
            //  btn_delete.Visible = false;btn_delete_id.Visible = false;
            try
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                str_RptName = "MasterContainerType.rpt";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "MasterContainer", str_Script, true);
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 337, 3, int.Parse(Session["LoginBranchid"].ToString()), "view");
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
            Response.AddHeader("content-disposition", "attachment;filename=ContainerType.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            containergrid.AllowPaging = false;
            gridbind();
            containergrid.RenderControl(hw);
            containergrid.HeaderRow.Style.Add("width", "5%");
            containergrid.HeaderRow.Style.Add("font-size", "10px");
            containergrid.Style.Add("text-decoration", "none");
            containergrid.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            containergrid.Style.Add("font-size", "8pt");
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


        protected void ExportToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ContainerType.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                containergrid.AllowPaging = false;
                gridbind();
                //  grdstate.HeaderRow.BackColor = Color.WHITE;
                foreach (System.Web.UI.WebControls.TableCell cell in containergrid.HeaderRow.Cells)
                {
                    cell.BackColor = containergrid.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in containergrid.Rows)
                {
                    //  row.BackColor = Color
                    foreach (System.Web.UI.WebControls.TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = containergrid.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = containergrid.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                containergrid.RenderControl(hw);

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

        protected void containergrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            containergrid.PageIndex = e.NewPageIndex;
            gridbind();
        }

        protected void txt_description_TextChanged(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            //  btn_delete.Enabled = false;
            btn_delete.Visible = false;btn_delete_id.Visible = false;
        }

        protected void txt_height_TextChanged(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            // btn_delete.Enabled = false;
            btn_delete.Visible = false;btn_delete_id.Visible = false;
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

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 337, "MSPort", txt_ctype.Text, txt_ctype.Text, "");  //"/Rate ID: " +
            if (txt_ctype.Text != "")
            {
                JobInput.Text = txt_ctype.Text;


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