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
    public partial class MasterCargoNew : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCargo MasterCargo = new DataAccess.Masters.MasterCargo();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCargo FA = new DataAccess.Masters.MasterCargo();
        DataSet dt_grdFill = new DataSet();
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        DataTable obj_dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                MasterCargo.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                FA.GetDataBase(Ccode);
                




            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }


            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            //btn_delete.Click += btn_delete_Click;
           // btn_delete.OnClientClick = @"return getConfirmationValue();";
            //excel.ServerClick += new EventHandler(Excelfunforserver_Click);
            //pdf.ServerClick += new EventHandler(pdffunforserver_Click);
            //btn_delete.Enabled = false;
            btn_delete.Visible = false;btn_delete_id.Visible = false;
           // FillgrdonpageLoad();
            if (!IsPostBack)
            {
                try
                {
                    // btn_delete.Enabled = false;
                    //btn_save.Enabled = false;
                    //btn_delete.Enabled = false;
                    Ctrl_List = txt_cargo.ID;
                    Msg_List = "Cargo Name~Cargo Descripton";
                    Dtype_List = "string~string";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, null, null);
                    //btn_delete.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    ////str_Uiid = Request.QueryString["UIID"].ToString();
                    //Utility.Fn_CheckUserRights(str_Uiid, btn_delete, null, null);
                    Empty_grd();
                    txt_cargo.Focus();
                   btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
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

        public void FillgrdonpageLoad()
        {
            dt_grdFill = MasterCargo.pagecargogrid();
            cargogrid.Visible = true;
            cargogrid.DataSource = dt_grdFill;
            cargogrid.DataBind();
        }

        protected void Empty_grd()
        {
            cargogrid.DataSource = new DataTable();
            cargogrid.DataBind();
        }

        [WebMethod]
        public static List<string> GetLikeCargo(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCargo FA = new DataAccess.Masters.MasterCargo();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            FA.GetDataBase(Ccode);
            dt = FA.GetLikeCargo(prefix.ToUpper());
            list_result = Utility.Fn_TableToList(dt, "cargotype", "cargoid");
            return list_result;
        }


        [WebMethod]
        public static void GetEmpName(string Prefix)
        {

            DataTable obj_dtEmp = new DataTable();

            if (Prefix.Length > 0)
            {
                DataAccess.Masters.MasterCargo FA = new DataAccess.Masters.MasterCargo();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                FA.GetDataBase(Ccode);
                DataTable obj_dt = new DataTable();
                obj_dt = FA.GetLikeCargo(Prefix.ToUpper());
                obj_dtEmp.Columns.Add("cargotype");
                obj_dtEmp.Columns.Add("cargoid");
               
                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["cargotype"] = obj_dt.Rows[i][0].ToString();

                    dr["cargoid"] = obj_dt.Rows[i][1].ToString();

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
                    ViewState["cargogrid"] = obj_dtEmp;
                    cargogrid.DataSource = obj_dtEmp;
                    cargogrid.DataBind();

                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
            }
            else
            {
                cargogrid.DataSource = null;
                cargogrid.DataBind();
            }
        }


        protected void btn_save_Click(object sender, EventArgs e)
        {
            // btn_delete.Enabled = false;
            btn_delete.Visible = false;btn_delete_id.Visible = false;
            if (btn_save.ToolTip == "Save")
            {
                try
                {
                    MasterCargo.InsertCargo(txt_cargo.Text.ToUpper());
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 129, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_cargo.Text + "/Sav");
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Cargo", "alertify.alert('Your Cargo Saved');", true);
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
                    MasterCargo.UpdateCargo(Convert.ToInt32(hiddenid.Value), txt_cargo.Text.ToUpper());
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 129, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_cargo.Text + "/Sav");
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Cargo", "alertify.alert('Your cargo Updated');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Cargo", "alertify.alert('Your cargo not Updated');", true);
                }
            }
            clear();
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
        private void ExportGridToPDF()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Cargo.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            cargogrid.RenderControl(hw);
            cargogrid.AllowPaging = false;
            gridbind();
            cargogrid.HeaderRow.Style.Add("width", "5%");
            cargogrid.HeaderRow.Style.Add("font-size", "10px");
            cargogrid.Style.Add("text-decoration", "none");
            cargogrid.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            cargogrid.Style.Add("font-size", "8pt");
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
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "ExportExcel" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            cargogrid.AllowPaging = false;
            gridbind();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            cargogrid.GridLines = GridLines.Both;
            cargogrid.HeaderStyle.Font.Bold = true;
            cargogrid.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        public void clear()
        {
            txt_cargo.Text = "";
             btn_save.Text = "Save";
            btn_cancel.Text = "Back";


            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";

            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";


            //gridbind();          
           // FillgrdonpageLoad();
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                //gridbind();
                //obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 129, 4, int.Parse(Session["LoginBranchid"].ToString()), "CargoView");                               
                //signup.Visible = true;
                //btn_cancel.Text = "Clear";
                //btn_delete.Enabled = false;
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                str_RptName = "MasterCargo.rpt";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "MasterCargo", str_Script, true);
                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 129, 4, Convert.ToInt32(Session["LoginBranchid"]), "CargoView");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        protected void gridbind()
        {
            //  dt_grdFill = MasterCargo.pagecargogrid();
            dt_grdFill = MasterCargo.pagecargogrid();
            DataTable dtpkg = new DataTable();
            cargogrid.Visible = true;

            if (dt_grdFill.Tables[0].Rows.Count > 0)
            {
                dtpkg = dt_grdFill.Tables[0];
                cargogrid.DataSource = dtpkg;
                cargogrid.DataBind();
            }
            else
            {
                cargogrid.DataSource = new DataTable();
                cargogrid.DataBind();
            }

        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (hfWasConfirmed.Value == "true")
            {
                if (txt_cargo.Text == "")
                {
                    try
                    {

                        MasterCargo.deletecargo(Convert.ToInt32(hiddenid.Value));
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Cargo", "alertify.alert('Your cargo Deleted');", true);
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Cargo", "alertify.alert('Your cargo not Deleted');", true);
                    }
                }
            }
            clear();

        }

        protected void txt_cargo_TextChanged(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            // btn_delete.Enabled = false;
            btn_delete.Visible = false;btn_delete_id.Visible = false;
            btn_cancel.Text = "Cancel";

            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

            DataTable dt1 = new DataTable();
            //DataAccess.Masters.MasterCargo FA = new DataAccess.Masters.MasterCargo();
            dt1 = FA.CheckCargoExist(txt_cargo.Text.ToUpper());
            if (dt1.Rows.Count > 0)
            {
                btn_save.Text = "Update";
                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn ico-update";

            }
            txt_cargo.Focus();

        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            //   btn_delete.Enabled = false;
            btn_delete.Visible = false;btn_delete_id.Visible = false;
            if (btn_cancel.ToolTip == "Back")
            {
                this.Response.End();
            }
            else
            {
                txt_cargo.Focus();
                txt_Search.Text = "";
                clear();
                //cargogrid.Visible = false;
                signup.Visible = false;
                //FillgrdonpageLoad();
                Empty_grd();
            }
        }

        protected void cargogrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            cargogrid.PageIndex = e.NewPageIndex;
            cargogrid.DataSource = (DataTable)ViewState["cargogrid"];
            cargogrid.DataBind();
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

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 129, "MSCargotype", txt_cargo.Text, txt_cargo.Text, "");  //"/Rate ID: " +
            if (txt_cargo.Text != "")
            {
                JobInput.Text = txt_cargo.Text;


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