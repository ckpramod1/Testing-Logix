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
//using System.Windows.Documents;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Web.Services.Description;

namespace logix.Maintenance
{
    public partial class MasterPackage : System.Web.UI.Page
    {
        DataAccess.Masters.MasterPackages MasterPackages = new DataAccess.Masters.MasterPackages();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataSet dt_grdFill = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                MasterPackages.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
               




            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }


            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_save);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);

            string Ctrl_List;
            string Msg_List;
            string Dtype_List;
            string str_Uiid = "";
            btn_delete.Visible = false;btn_delete_id.Visible = false;
            if (!IsPostBack)
            {
                btn_delete.Click += btn_delete_Click;
                btn_delete.OnClientClick = @"return getConfirmationValue();";
                Ctrl_List = txt_packcode.ID + "~" + txt_packdes.ID;
                Msg_List = "Package Code~Package Descripton";
                Dtype_List = "string~string";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                btn_delete.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                //str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_save, null, null);
                Utility.Fn_CheckUserRights(str_Uiid, btn_delete, null, null);
                //btn_save.Enabled = true;
                //btn_delete.Enabled = true;
               // clear();
                //btn_ep.Visible = false;
                //btn_ee.Visible = false;
                //btn_print.Visible = false;
                //btn_delete.Enabled = false;
                btn_delete.Visible = false;btn_delete_id.Visible = false;
                txt_packcode.Focus();
                Empty_grd();
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
         //   FillgrdonpageLoad();
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
        public static List<string> getpackagecode(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPackages FA = new DataAccess.Masters.MasterPackages();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            FA.GetDataBase(Ccode);
            dt = FA.GetLikePackageCode(prefix.ToUpper());
            list_result = Utility.Fn_TableToList(dt, "packagecode", "packageid");
            return list_result;
        }
        public void FillgrdonpageLoad()
        {
            dt_grdFill = MasterPackages.packagepagegrid();
            packagegrid.Visible = true;
            packagegrid.DataSource = dt_grdFill;
            packagegrid.DataBind();
        }

        protected void txt_packcode_TextChanged(object sender, EventArgs e)
        {
            btn_delete.Visible = false;btn_delete_id.Visible = false;
            btn_save.Enabled = true;
            // btn_delete.Enabled = false;
           btn_cancel.Text = "Cancel";

            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

            try
            {
                int packageId = MasterPackages.GetPackageid(txt_packcode.Text.ToUpper());
                if(packageId.ToString()!="" && packageId.ToString()!="0")
                {
                    txt_packdes.Text = MasterPackages.GetPackagename(Convert.ToInt32(packageId));
                }
               
                if (txt_packdes.Text != "" && txt_packdes.Text!="0")
                {
                    hiddenid.Value = packageId.ToString();

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Packages", "alertify.alert('Packages Details already exists');", true);
                    btn_save.Text = "Update";
                    btn_cancel.Text = "Cancel";


                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn ico-update";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                if (txt_packdes.Text == "0")
                {

                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(txt_packcode, typeof(TextBox), "Master Packages", "alertify.alert('check your code');", true);

                //Response.Write("<script>alertify.alert('check your code')</script>");
            }
            txt_packdes.Focus();

        }

        [WebMethod]
        public static void GetEmpName(string Prefix)
        {

            DataTable obj_dtEmp = new DataTable();

            if (Prefix.Length > 0)
            {
                DataTable dt = new DataTable();
                DataAccess.Masters.MasterPackages FA = new DataAccess.Masters.MasterPackages();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                FA.GetDataBase(Ccode);
                dt = FA.GetLikePackageCode(Prefix.ToUpper());
                obj_dtEmp.Columns.Add("packagecode");
                obj_dtEmp.Columns.Add("packageid");
                ////obj_dtEmp.Columns.Add("currency");
                ////obj_dtEmp.Columns.Add("amount");
                ////obj_dtEmp.Columns.Add("percentage");
                DataRow dr;

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["packagecode"] = dt.Rows[i][0].ToString();
                    dr["packageid"] = dt.Rows[i][1].ToString();
                    //dr["currency"] = obj_dt.Rows[i][1].ToString();
                    //dr["amount"] = obj_dt.Rows[i][2].ToString();
                    //dr["percentage"] = obj_dt.Rows[i][3].ToString();

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
                    ViewState["PackagesGrd"] = obj_dtEmp;
                    packagegrid.DataSource = obj_dtEmp;
                    packagegrid.DataBind();

                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 757, 5, int.Parse(Session["LoginBranchid"].ToString()), txt_Search.Text + "/Search");
            }
            else
            {
                packagegrid.DataSource = null;
                packagegrid.DataBind();
            }
        }

        private void checkallfun()
        {

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            btn_delete.Visible = false;btn_delete_id.Visible = false;
            //  btn_delete.Enabled = false;
            if ((btn_save.ToolTip == "Save"))
            {
                //DataTable dt1 = new DataTable();
                //DataAccess.Masters.MasterPackages FA = new DataAccess.Masters.MasterPackages();
                //dt1 = FA.getlikepackagecode(hiddenid.Value);
                if (hiddenid.Value!="")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Master Packages", "alertify.alert('Package Name already exist');", true);
                    return;
                }
                else
                {
                    try
                    {
                        MasterPackages.InsMasterPackages(txt_packcode.Text.ToUpper(), txt_packdes.Text.ToUpper());
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 757, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_packcode.Text + "/Sav");
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Master Packages", "alertify.alert('Your Packages Saved');", true);
                        clear();
                        return;
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Master Packages", "alertify.alert('Try Again, Thank You!!!');", true);
                        return;
                    }

                }

            }
            else
            {
                try
                {
                    MasterPackages.UpdMasterPackages(Convert.ToInt32(hiddenid.Value), txt_packcode.Text.ToUpper(), txt_packdes.Text.ToUpper());
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 757, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_packcode.Text + "/UPD");
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Packages", "alertify.alert('Your Packages has updated');", true);
                    clear();
                    return;
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Packages", "alertify.alert('Your Packages has not been updated'');", true);
                    return;
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Packages", "alertify.alert('Your package has not been updated');", true);
                }
            }
            clear();
            txt_packcode.Focus();
        }
        public void clear()
        {
            //gridbind();
           // FillgrdonpageLoad();
            txt_packcode.Text = "";
            txt_packdes.Text = "";
            btn_save.Text = "Save";

            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";

           // btn_cancel.Text = "Back";

        }

        protected void Empty_grd()
        {
            packagegrid.DataSource = Utility.Fn_GetEmptyDataTable();
            packagegrid.DataBind();
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_delete.Visible = false;btn_delete_id.Visible = false;
            //btn_delete.Enabled = false;
            if (btn_cancel.ToolTip == "Back")
            {
                this.Response.End();
            }
            else
            {
                Empty_grd();
                txt_packcode.Focus();
                clear();
                btn_cancel.Text = "Back";

                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
               // packagegrid.Visible = false;
                signup.Visible = false;
               // FillgrdonpageLoad();
                txt_Search.Text = "";
            }
        }
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (hfWasConfirmed.Value == "true")
            {
                if (txt_packcode.Text == "")
                {

                    try
                    {
                        MasterPackages.Deletepackage(Convert.ToInt32(hiddenid.Value));
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 757, 4, int.Parse(Session["LoginBranchid"].ToString()), txt_packcode.Text + "/DEL");
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Packages", "alertify.alert('Your Package deleted');", true);
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Packages", "alertify.alert('Try Again, Thank You!!!');", true);
                    }
                }
            }

            clear();
        }
        public void checkdata()
        {
            if (txt_packcode.Text == "")
            {

                txt_packcode.Focus();

            }
            else if (txt_packdes.Text == "")
            {
                txt_packdes.Text = "Enter Description";
                txt_packdes.Focus();
            }
            // int pkgcodelength=Convert.ToInt32(btn_save.Attributes.Add("OnClick", "return getlen('" + txt_packcode +  "');"));
        }
        protected void gridbind()
        {
            DataSet ds = new DataSet();
            ds = MasterPackages.getgridpackage();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dtpkg = new DataTable();
                dtpkg = ds.Tables[0];
                packagegrid.DataSource = dtpkg;
                packagegrid.DataBind();
            }
        }
        protected void btn_ep_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();
        }
        private void ExportGridToPDF()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Packages.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            packagegrid.AllowPaging = false;
            gridbind();

            packagegrid.RenderControl(hw);
            packagegrid.HeaderRow.Style.Add("width", "5%");
            packagegrid.HeaderRow.Style.Add("font-size", "10px");
            packagegrid.Style.Add("text-decoration", "none");
            packagegrid.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            packagegrid.Style.Add("font-size", "8pt");
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
            ExportToExcel();
        }
        protected void ExportToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Package.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                packagegrid.AllowPaging = false;
                gridbind();
                //  grdstate.HeaderRow.BackColor = Color.WHITE;
                foreach (System.Web.UI.WebControls.TableCell cell in packagegrid.HeaderRow.Cells)
                {
                    cell.BackColor = packagegrid.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in packagegrid.Rows)
                {
                    //  row.BackColor = Color
                    foreach (System.Web.UI.WebControls.TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = packagegrid.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = packagegrid.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                packagegrid.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }


        protected void btn_view_Click(object sender, EventArgs e)
        {
            //gridbind();
            //signup.Visible = true;
            //btn_delete.Visible = false;btn_delete_id.Visible = false;
            try
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                str_RptName = "MasterPackages.rpt";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "MasterPackages", str_Script, true);
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 757, 3, int.Parse(Session["LoginBranchid"].ToString()), txt_packcode.Text + "MasterPackageView");                               

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        protected void Excelfunforserver_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        protected void pdffunforserver_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();
        }



        protected void txt_packdes_TextChanged(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            btn_delete.Visible = false;btn_delete_id.Visible = false;
            //btn_delete.Enabled = false;
        }

        protected void packagegrid_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            packagegrid.PageIndex = e.NewPageIndex;
            gridbind();

        }

        protected void packagegrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            packagegrid.PageIndex = e.NewPageIndex;
            packagegrid.DataSource = (DataTable)ViewState["PackagesGrd"];
            packagegrid.DataBind();
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

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 757, "MSpkg", txt_packcode.Text, txt_packcode.Text, "");  //"/Rate ID: " +
            if (txt_packcode.Text != "")
            {
                JobInput.Text = txt_packcode.Text;


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