using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.IO;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.DataVisualization.Charting;
using System.Globalization;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Web.Services.Description;


namespace logix.Maintenance
{
    public partial class MasterTDSType : System.Web.UI.Page
    {
        string tdsType;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";

        DataAccess.Masters.MasterTDSType objp_tds = new DataAccess.Masters.MasterTDSType();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataTable dt_com = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                objp_tds.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                




            }


            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (IsPostBack != true)
            {
                try
                {
                    Ctrl_List = txt_Section.ID + "~" + txt_desc.ID + "~" + ddl_cmbType.ID + "~" + ddl_cmbSlab.ID + "~" + txt_Percent.ID;
                    Msg_List = "Section~TDS Descripton~TDS Type~TDS Slap~TDS Percentage";
                    Dtype_List = "string~string~Dropdownlist~Dropdownlist~string";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    //txt_Percent.Attributes.Add("onkeypress", "return validateFloatKeyPress(this, event)");
                    // str_Uiid = Request.QueryString["UIID"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, null, null);
                    //empty_grid();
                    txt_Section.Focus();
                    TopRowDisplay();
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
                //ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
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
        public static void GetdeptName1(string Prefix)
        {
            DataTable obj_dtEmp = new DataTable();
            if (Prefix.Length > 0)
            {
                DataAccess.Masters.MasterTDSType objp_tds = new DataAccess.Masters.MasterTDSType();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                objp_tds.GetDataBase(Ccode);
                DataTable obj_dt = new DataTable();
                obj_dt = objp_tds.GetTDSDtlsFun(Prefix.ToUpper());
                obj_dtEmp.Columns.Add("sno");
                obj_dtEmp.Columns.Add("tdsid");
                obj_dtEmp.Columns.Add("tdsdesc");
                obj_dtEmp.Columns.Add("tdstype");
                obj_dtEmp.Columns.Add("tdsslab");
                obj_dtEmp.Columns.Add("tdspercentage");
                obj_dtEmp.Columns.Add("tdssection");

                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["sno"] = obj_dt.Rows[i][0].ToString();
                    dr["tdsid"] = obj_dt.Rows[i][1].ToString();
                    dr["tdsdesc"] = obj_dt.Rows[i][2].ToString();
                    dr["tdstype"] = obj_dt.Rows[i][3].ToString();
                    dr["tdsslab"] = obj_dt.Rows[i][4].ToString();
                    dr["tdspercentage"] = obj_dt.Rows[i][5].ToString();
                    dr["tdssection"] = obj_dt.Rows[i][6].ToString();
                }
                HttpContext.Current.Session["Date"] = obj_dtEmp;
            }            
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_save.ToolTip == "Save")
                {
                    //DataAccess.Masters.MasterTDSType objp_tds = new DataAccess.Masters.MasterTDSType();
                    objp_tds.InsertTDSTypeFun(Convert.ToString(txt_desc.Text.ToUpper().Trim()), Convert.ToChar(hf_tdsType.Value), Convert.ToString(ddl_cmbSlab.SelectedValue), Convert.ToDouble(txt_Percent.Text.ToUpper().Trim()), txt_Section.Text.ToUpper().Trim());
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 356, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_Section.Text + "TDS Saved");                               
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved');", true);
                    btn_save.Text = "Update";
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn ico-update";
                    //BindGrid();
                    empty_grid();
                    txt_clear();
                    //TopRowDisplay();
                    View();
                    txt_cleardata();
                }
                else if (btn_save.ToolTip == "Update")
                {
                   // DataAccess.Masters.MasterTDSType objp_tds = new DataAccess.Masters.MasterTDSType();
                    objp_tds.UpdateTDSTypeFun(Convert.ToInt32(hf_tdsid.Value), txt_desc.Text.ToUpper(), Convert.ToChar(hf_tdsType.Value), Convert.ToString(ddl_cmbSlab.SelectedValue), Convert.ToDouble(txt_Percent.Text));
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 356, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_Section.Text+"TDS Updated");                               
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated');", true);
                    btn_save.Text = "Save";
                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                    BindGrid();
                    txt_cleardata();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        private void BindGrid()
        {
            DataTable dt = new DataTable();
            //DataTable obj_dtEmp = new DataTable();
            if (Session["Date"] != null)
            {
                dt = objp_tds.GetDescriptionFun(txt_Section.Text);
                grd.DataSource = dt;
                ViewState["Excel"] = dt;
                //obj_dtEmp = (DataTable)Session["Date"];
                //grd.DataSource = obj_dtEmp;
                grd.DataBind();
            }
        }
        
        protected void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dtEmp = new DataTable();
                if (txt_desc.Text != "")
                {
                    if (Session["Date"] != null)
                    {
                        obj_dtEmp = (DataTable)Session["Date"];
                        ViewState["Excel"] = obj_dtEmp;
                        grd.DataSource = obj_dtEmp;
                        grd.DataBind();

                    }
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "selectAndFocus", "$get('" + txt_desc.ClientID + "').selectionStart=$get('" + txt_desc.ClientID + "').value.length;$get('" + txt_desc.ClientID + "').selectionEnd=$get('" + txt_desc.ClientID + "').value.length;$get('" + txt_desc.ClientID + "').focus()", true);
                }
                else
                {
                    grd.DataSource = new DataTable();
                    grd.DataBind();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        private void empty_grid()
        {
            DataTable dt_new = new DataTable();
            grd.DataSource = dt_new;
            grd.DataBind();
        }

        protected void ddl_cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_cmbSlab.Items.Clear();
            if (ddl_cmbType.SelectedItem.Value != "")
            {
                if (ddl_cmbType.SelectedValue == "I")
                {
                    hf_tdsType.Value = "I";
                    ddl_cmbSlab.Items.Add("Income of 10 Lakhs or Below");
                    ddl_cmbSlab.Items.Add("Income above 10 Lacs");
                }
                else if (ddl_cmbType.SelectedValue == "C")
                {
                    hf_tdsType.Value = "C";
                    ddl_cmbSlab.Items.Add("Income of 1 Crore or Below");
                    ddl_cmbSlab.Items.Add("Income above 1 Crore");
                }
            }
        }

        private void txt_cleardata()
        {
            txt_Section.Text = "";
            txt_Percent.Text = "";
            txt_desc.Text = "";
            txt_desc.ReadOnly = false;
            ddl_cmbType.SelectedIndex = 0;
            ddl_cmbSlab.SelectedIndex = 0;
            //btn_save.Text = "Save";
            //grd.DataSource = null;
            //grd.DataBind();
        }


        private void txt_clear()
        {
            txt_Section.Text = "";
            txt_Percent.Text = "";
            txt_desc.Text = "";
            txt_desc.ReadOnly = false;
            ddl_cmbType.SelectedIndex = 0;
            ddl_cmbSlab.SelectedIndex = 0;
            btn_save.Text = "Save";

            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            grd.DataSource = new DataTable();
            grd.DataBind();
            btn_back.Text = "Back";

            btn_back.ToolTip = "Back";
            btn_back1.Attributes["class"] = "btn ico-back";
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Back")
            {
            this.Response.End();
            }
            else
           {
            txt_clear();
            //TopRowDisplay();
           }
            
        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try { 
           // DataAccess.Masters.MasterTDSType objp_tds = new DataAccess.Masters.MasterTDSType();
            DataTable dt_new = new DataTable();

            //dt_new = (DataTable)Session["grd"];
           // dt_new = (DataTable)Session["Date"];
            //dt_new= da_obj_tdsTypeobj.GetTDSDtls(txt_desc.Text);

            int int_index;
            int_index = grd.SelectedRow.RowIndex;
            //dt_new = da_obj_tdsTypeobj.GetTDSDtls(txt_desc.Text);
           // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
            if (grd.Rows.Count > 0)
            {
                hf_tdsid.Value = grd.Rows[int_index].Cells[1].Text;
                //ddl_cmbType.SelectedItem.Value = dt_new.Rows[int_index][2].ToString();
                string str_ddl = grd.Rows[int_index].Cells[3].Text;
                if (str_ddl == "I")
                {
                    ddl_cmbType.SelectedValue = "I";
                    ddl_cmbType_SelectedIndexChanged(sender, e);
                }

                else
                {
                    ddl_cmbType.SelectedValue = "C";
                    ddl_cmbType_SelectedIndexChanged(sender, e);
                }
                ddl_cmbSlab.Text = grd.Rows[int_index].Cells[4].Text;
                txt_Percent.Text = grd.Rows[int_index].Cells[5].Text;
                txt_Section.Text = grd.Rows[int_index].Cells[6].Text;
                txt_desc.Text = grd.Rows[int_index].Cells[2].Text;
                txt_desc.ReadOnly = true;
                btn_save.Text = "Update";
                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn ico-update";

              

            }
           }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(GridView), "test", "alertify.alert('Enter The Type of Decriptions');", true);
               // txt_clear();
            }

        }
        protected void txt_Section_TextChanged(object sender, EventArgs e)
        {

            try
            {
                btn_back.Text = "Cancel";


                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                DataTable dt = new DataTable();
               // DataAccess.Masters.MasterTDSType objp_tds = new DataAccess.Masters.MasterTDSType();
                dt = objp_tds.GetDescriptionFun(txt_Section.Text);
                grd.DataSource = dt;
                grd.DataBind();
                ViewState["Topgrid"] = dt;
                ViewState["Excel"] = dt;
                txt_desc.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

      
        private void TopRowDisplay()
        {
            dt_com = objp_tds.GETGridTopTDS();
            if (dt_com.Rows.Count > 0)
            {
                grd.DataSource = dt_com;
                ViewState["Topgrid"] = dt_com;
                ViewState["Excel"] = dt_com;
                grd.DataBind();
            }
        }

        public void View()
        {
            //DataAccess.Masters.MasterTDSType objp_tds = new DataAccess.Masters.MasterTDSType();
            DataTable dt_view = new DataTable();
            dt_view = objp_tds.ViewSave();
            grd.DataSource = dt_view;
            ViewState["Excel"] = dt_view;
            grd.DataBind();
            // canclbtn.Text = "Cancel";
            grd.Visible = true;
        }

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            //DataAccess.Masters.MasterTDSType objp_tds = new DataAccess.Masters.MasterTDSType();
            //DataTable dt_view = new DataTable();
            //dt_view = objp_tds.ViewSave();
            //grd.DataSource = dt_view;
            //grd.DataBind();
            //// canclbtn.Text = "Cancel";
            grd.DataSource = (DataTable)ViewState["Topgrid"];
            ViewState["Excel"] = (DataTable)ViewState["Topgrid"];
            grd.DataBind();
            grd.Visible = true;
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text == "&nbsp;")
                {
                    e.Row.Cells[i].Text = "";
                }
                e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
            }

        }

        protected void btnoutExcel_Click(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                DataTable obj_dtEmp = new DataTable();
                cust.Visible = true;
                
                DataTable dt = (DataTable)ViewState["Excel"];
                obj_dtEmp.Columns.Add("sno");
                obj_dtEmp.Columns.Add("tdsid");
                obj_dtEmp.Columns.Add("tdsdesc");
                obj_dtEmp.Columns.Add("tdstype");
                obj_dtEmp.Columns.Add("tdsslab");
                obj_dtEmp.Columns.Add("tdspercentage");
                //obj_dtEmp.Columns.Add("tdssection");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        obj_dtEmp.Rows.Add();
                        obj_dtEmp.Rows[i]["sno"] = dt.Rows[i]["sno"];
                        obj_dtEmp.Rows[i]["tdsid"] = dt.Rows[i]["tdsid"];
                        obj_dtEmp.Rows[i]["tdsdesc"] = dt.Rows[i]["tdsdesc"];
                        obj_dtEmp.Rows[i]["tdstype"] = dt.Rows[i]["tdstype"];
                        obj_dtEmp.Rows[i]["tdsslab"] = dt.Rows[i]["tdsslab"];
                        obj_dtEmp.Rows[i]["tdspercentage"] = dt.Rows[i]["tdspercentage"];
                        //obj_dtEmp.Rows[i]["tdssection"] = dt.Rows[i]["tdssection"];
                    }
                    GridView1.DataSource = obj_dtEmp;
                    GridView1.DataBind();
                }

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=VoucherwiseDetails.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                GridView1.Visible = true;
                GridView1.GridLines = GridLines.Both;
                GridView1.HeaderStyle.Font.Bold = true;
                GridView1.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());

                cust.Visible = false;
                GridView1.Visible = false;
                Response.End();
                //Response.Clear();
                //Response.Buffer = true;
                //Response.AddHeader("content-disposition", "attachment;filename=Quatotion.xls");
                //Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                //StringWriter StringWriter = new System.IO.StringWriter();
                //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                //grd.GridLines = GridLines.Both;
                //grd.HeaderStyle.Font.Bold = true;
                //grd.RenderControl(HtmlTextWriter);
                //Response.Write(StringWriter.ToString());
                //Response.End();
               
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        //protected override void Render(HtmlTextWriter writer)
        //{


        //    foreach (GridViewRow r in GridView1.Rows)
        //    {
        //        if (r.RowType == DataControlRowType.DataRow)
        //        {
        //            for (int columnIndex = 0; columnIndex < r.Cells.Count; columnIndex++)
        //            {
        //                Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl00", columnIndex.ToString());
        //            }
        //        }
        //    }

        //    base.Render(writer);
        //}


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

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 356, "MSTDS", txt_Section.Text, txt_Section.Text, "");  //"/Rate ID: " +
            if (txt_Section.Text != "")
            {
                JobInput.Text = txt_Section.Text;


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