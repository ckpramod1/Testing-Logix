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
    public partial class MasterDepartment : System.Web.UI.Page
    {
        DataAccess.Masters.MasterDepartment objp = new DataAccess.Masters.MasterDepartment();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterDepartment obj_ins = new DataAccess.Masters.MasterDepartment();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataTable obj_dt = new DataTable();
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        Boolean blr;
        DataTable dt_com = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                objp.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                obj_ins.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
               

            }


            btn_delete.Click += btn_delete_Click;
            btn_delete.OnClientClick = @"return getConfirmationValue();";
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            //excel.ServerClick += new EventHandler(Excelfunforserver_Click);
            //pdf.ServerClick += new EventHandler(pdffunforserver_Click);
            btn_delete.Visible = false;btn_delete_id.Visible = false;
            if (!IsPostBack)
            {

                try
                {
                    //btn_delete.Enabled = false;
                    btn_delete.Visible = false;btn_delete_id.Visible = false;
                    Ctrl_List = txt_Dept.ID;
                    Msg_List = "Department Name";
                    Dtype_List = "string";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, null, null);
                    checkdata();
                    //Empty_grd();
                    dt_com = objp.GetDepartmentview();
                    Deptgrid.DataSource = dt_com;
                    Deptgrid.DataBind();
                    btn_save.Enabled = false;
                   // DisplayGridTopRow();
                    txt_Dept.Focus();
                    clear();
                  
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
            btn_delete.Enabled = false;
        
        }
        [WebMethod]
        public static List<string> getDept(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt_get = new DataTable();
            DataAccess.Masters.MasterDepartment objp = new DataAccess.Masters.MasterDepartment();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objp.GetDataBase(Ccode);
            dt_get = objp.GetLikeDeptname(prefix.ToUpper());
            list_result = Utility.Fn_TableToList(dt_get, "deptname", "deptname");
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

        protected void Empty_grd()
        {
            Deptgrid.DataSource = Utility.Fn_GetEmptyDataTable();
            Deptgrid.DataBind();
        }

        [WebMethod]
        public static void GetEmpName(string Prefix)
        {

            DataTable obj_dtEmp = new DataTable();

            if (Prefix.Length > 0)
            {
                DataAccess.Masters.MasterDepartment objp = new DataAccess.Masters.MasterDepartment();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                objp.GetDataBase(Ccode);
                DataTable obj_dt = new DataTable();
                obj_dt = objp.GetLikeDeptname(Prefix.ToUpper());
                obj_dtEmp.Columns.Add("deptname");
                //obj_dtEmp.Columns.Add("deptid");

                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["deptname"] = obj_dt.Rows[i][0].ToString();
                  
                  

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
                    ViewState["department"] = obj_dtEmp;
                    Deptgrid.DataSource = obj_dtEmp;
                    Deptgrid.DataBind();

                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
                btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";

            }
            else
            {
                Deptgrid.DataSource = null;
                Deptgrid.DataBind();
            }
        }



        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                //btn_save.Enabled = true;
                btn_delete.Visible = false;btn_delete_id.Visible = false;
                //DataAccess.Masters.MasterDepartment obj_ins = new DataAccess.Masters.MasterDepartment();
                if (btn_save.ToolTip == "Save")
                {
                    if (hiddenid.Value == "")
                    {
                        obj_ins.Insertdepartment(txt_Dept.Text.Trim().ToUpper());
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Department", "alertify.alert('Saved Successfully');", true);
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 331, 1, int.Parse(Session["LoginBranchid"].ToString()), "Save");
                        btn_save.Text = "Update";


                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";

                        btn_cancel.Text = "Cancel";


                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";

                       // gridbind();
                        clear();
                    }
                }
                else
                {
                    if (hiddenid.Value != "")
                    {
                        int deptid = Convert.ToInt32(hiddenid.Value.ToString());
                        obj_ins.Upddepartment(txt_Dept.Text.ToUpper(), deptid);
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Department", "alertify.alert('Updated Successfully');", true);
                        btn_save.Text = "Save";
                       btn_cancel.Text = "Back";

                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";

                        btn_cancel.ToolTip = "Back";
                        btn_cancel1.Attributes["class"] = "btn ico-back";
                     //   gridbind();
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

        private void clear()
        {
            txt_Dept.Text = "";
           hiddenid.Value = "";
            btn_save.Text = "Save";

           btn_save.ToolTip = "Save";
           btn_save1.Attributes["class"] = "btn ico-save";
          //  btn_cancel.Text = "Back";
           // DisplayGridTopRow();
            divExport.Visible = false;
         //   DisplayGridTopRow();

        }

        protected void txt_Dept_TextChanged(object sender, EventArgs e)
        {
            try
            {
                checkDepartment();
                btn_save.Enabled = true;
                // btn_delete.Enabled = false;
                btn_delete.Visible = false;btn_delete_id.Visible = false;
                if(blr==true)
                {
                    return;
                }
                if (hiddenid.Value != "" && hiddenid.Value != "0")
                {
                    //DataTable dt_sel = new DataTable();
                    //DataAccess.Masters.MasterDepartment objp = new DataAccess.Masters.MasterDepartment();

                    //dt_sel = objp.GetDetpNameView(Convert.ToInt32(hiddenid.Value.ToString()));

                    //if (dt_sel.Rows.Count > 0)
                    //{
                    ScriptManager.RegisterStartupScript(btn_save, typeof(System.Web.UI.WebControls.Button), "MasterDepartment", "alertify.alert('Department Name Already Exists...');", true);
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Department", "alertify.alert('Details Already Exists');", true);
                        btn_save.Text = "Update";
                        btn_cancel.Text = "Cancel";

                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";


                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    //}
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txt_Dept.Focus();

        }

        protected void gridbind()
        {
            DataTable dt = new DataTable();
            dt = objp.GetGridview();
            if (dt.Rows.Count > 0)
            {
                Deptgrid.DataSource = dt;
                Deptgrid.DataBind();
            }
        }

        private void DisplayGridTopRow()
        {
            DataTable dt_top = new DataTable();
            dt_top = objp.GetDeptTopGridRow();
            if (dt_top.Rows.Count > 0)
            {
                Deptgrid.DataSource = dt_top;
                Deptgrid.DataBind();
            }

        }

        private void empty_grid()
        {
            DataTable dt_emp = new DataTable();
            Deptgrid.DataSource = dt_emp;
            Deptgrid.DataBind();
        }
        protected void btn_view_Click1(object sender, EventArgs e)
        {
            try
            {
                //gridbind();
                //Deptgrid.Visible = true;
                //divExport.Visible = true;
                //btn_cancel.Text = "Cancel";
                //// btn_delete.Enabled = false;
                //btn_delete.Visible = false;btn_delete_id.Visible = false;
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                str_RptName = "MasterDepartment.rpt";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "MasterPort", str_Script, true);
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 331, 3, int.Parse(Session["LoginBranchid"].ToString()), "view");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                bool type = false;

                if (hfWasConfirmed.Value == "true")
                {
                    if (hiddenid.Value != "")
                    {
                        int deptid = Convert.ToInt32(hiddenid.Value.ToString());
                        objp.DelTableDept(deptid);
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Department", "alertify.alert('Your Department deleted');", true);
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 331, 4, int.Parse(Session["LoginBranchid"].ToString()), "Delete");
                        clear();
                        gridbind();
                    }


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Department", "alertify.alert('Your Not Department deleted');", true);
                    clear();
                    gridbind();

                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
       

           




        public void checkdata()
        {
            if (txt_Dept.Text == "")
            {

                txt_Dept.Focus();

            }
            else if (txt_Dept.Text == "")
            {
                txt_Dept.Text = "Enter Depts";
                txt_Dept.Focus();
            }
        }
        public void checkDepartment()
        {
            DataTable dt1 = new DataTable();
            if (txt_Dept.Text != "")
            {
                dt1 = objp.SelDeptname(txt_Dept.Text.ToUpper());

                if (dt1.Rows.Count > 0)
                {
                    hiddenid.Value = dt1.Rows[0]["deptid"].ToString();

                    
                    

                }
                else
                {
                    //hiddenid.Value = "";
                    blr = true;
                }
            }
        }
        protected void btn_cancel_Click1(object sender, EventArgs e)
        {
          //  btn_delete.Enabled = false;
            btn_delete.Visible = false;btn_delete_id.Visible = false;btn_delete_id.Visible = false;
            if (btn_cancel.ToolTip == "Back")
            {
                this.Response.End();

            }
            else
            {
                btn_cancel.Text = "Back";

                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                txt_Search.Text = "";
                Empty_grd();
                txt_Dept.Focus();
                clear();
              //  hiddenid.Value = "";
               // DisplayGridTopRow();
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
        private void ExportGridToPDF()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Department.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Deptgrid.AllowPaging = false;

            dt_com = objp.GetGridview();
            if (dt_com.Rows.Count > 0)
            {
                Deptgrid.DataSource = dt_com;
                Deptgrid.DataBind();
            }
            Deptgrid.RenderControl(hw);
            Deptgrid.HeaderRow.Style.Add("width", "5%");
            Deptgrid.HeaderRow.Style.Add("font-size", "10px");
            Deptgrid.Style.Add("text-decoration", "none");
            Deptgrid.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            Deptgrid.Style.Add("font-size", "8pt");
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
            Response.AddHeader("content-disposition", "attachment;filename=Department.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                Deptgrid.AllowPaging = false;

                dt_com = objp.GetGridview();
                if (dt_com.Rows.Count > 0)
                {
                    Deptgrid.DataSource = dt_com;
                    Deptgrid.DataBind();
                }
                // this.BindGrid();

                //  grdstate.HeaderRow.BackColor = Color.WHITE;
                foreach (System.Web.UI.WebControls.TableCell cell in Deptgrid.HeaderRow.Cells)
                {
                    cell.BackColor = Deptgrid.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in Deptgrid.Rows)
                {
                    //  row.BackColor = Color
                    foreach (System.Web.UI.WebControls.TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = Deptgrid.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = Deptgrid.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                Deptgrid.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        protected void Deptgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Deptgrid.PageIndex = e.NewPageIndex;
            gridbind();
        }

        protected void Deptgrid_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            Deptgrid.PageIndex = e.NewPageIndex;
            Deptgrid.DataSource = (DataTable)ViewState["department"];
            Deptgrid.DataBind();
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

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 331, "MSdept", txt_Dept.Text, txt_Dept.Text, "");  //"/Rate ID: " +
            if (txt_Dept.Text != "")
            {
                JobInput.Text = txt_Dept.Text;


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