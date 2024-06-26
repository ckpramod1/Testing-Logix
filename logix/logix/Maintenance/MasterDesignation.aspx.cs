﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;  

namespace logix.Maintenance
{
    public partial class MasterDesignation : System.Web.UI.Page
    {
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";

        int desigid;
        DataAccess.Masters.MasterDesignation objp_begin = new DataAccess.Masters.MasterDesignation();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataTable dt_com = new DataTable();
        DataTable obj_dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                objp_begin.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                
            }


            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(pdf);
            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(excel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(canclbtn);
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            deltbtn.Visible = false;deltbtn_id.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    Ctrl_List = txtdesignation.ID;
                    Msg_List = "Designame";
                    Dtype_List = "string";
                    savbtn.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    Utility.Fn_CheckUserRights(str_Uiid, savbtn, null, null);
                    txtdesignation.Focus();
                    savbtn.Text = "Save";

                    savbtn.ToolTip = "Save";
                    savbtn1.Attributes["class"] = "btn ico-save";

                    //deltbtn.Enabled = false;
                    deltbtn.Visible = false;deltbtn_id.Visible = false;
                    empty_grd();
                    //TopRowDisplay();
                    clear();
                    deltbtn.Click += deltbtn_Click;
                    deltbtn.OnClientClick = @"return getConfirmationValue();";
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
            //pdf.ServerClick += new EventHandler(ExportPDF_Click);
            //excel.ServerClick += new EventHandler(ExportExcel_Click);

        }


        [WebMethod]
        public static void GetEmpName(string Prefix)
        {

            DataTable obj_dtEmp = new DataTable();

            if (Prefix.Length > 0)
            {
                DataAccess.Masters.MasterDesignation objp_begin = new DataAccess.Masters.MasterDesignation();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                objp_begin.GetDataBase(Ccode);
                DataTable obj_dt = new DataTable();
                obj_dt = objp_begin.GetLikedesigname(Prefix.ToUpper());
                obj_dtEmp.Columns.Add("designame");
              //  obj_dtEmp.Columns.Add("desigidid");

                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["designame"] = obj_dt.Rows[i][0].ToString();

             //  dr["desigidid"] = obj_dt.Rows[i][1].ToString();

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
                    ViewState["designation"] = obj_dtEmp;
                    GridView1.DataSource = obj_dtEmp;
                    GridView1.DataBind();

                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
               
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        protected void empty_grd()
        {
            GridView1.DataSource = Utility.Fn_GetEmptyDataTable();
            GridView1.DataBind();
        }

        protected void savbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (savbtn.ToolTip == "Update")
                {
                    //DataAccess.Masters.MasterDesignation objp_begin = new DataAccess.Masters.MasterDesignation();
                    objp_begin.UpdDesignation(txtdesignation.Text.ToUpper().Trim(), Convert.ToInt32(hdf1_designame.Value));
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master designation", "alertify.alert('Updated sucessfully');", true);
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 332, 2, int.Parse(Session["LoginBranchid"].ToString()), txtdesignation.Text+"/Upd");
                    //TopRowDisplay();
                    //clear();
                    canclbtn.Text = "Cancel";

                    canclbtn.ToolTip = "Cancel";
                    canclbtn1.Attributes["class"] = "btn ico-cancel";
                    // deltbtn.Enabled = false;
                    deltbtn.Visible = false;deltbtn_id.Visible = false;
                    txtdesignation.Text = "";
                     savbtn.Text = "Save";

                    savbtn.ToolTip = "Save";
                    savbtn1.Attributes["class"] = "btn ico-save";
                  //  TopRowDisplay();

                }

                else
                {

                  //  DataAccess.Masters.MasterDesignation objp_begin = new DataAccess.Masters.MasterDesignation();
                    desigid = Convert.ToInt32(objp_begin.insertdesignationfun(txtdesignation.Text.ToUpper().Trim()));
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 332, 1, int.Parse(Session["LoginBranchid"].ToString()), txtdesignation.Text + "/Save");
                   // hdf1_designame.Value = desigid.ToString();
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master designation", "alertify.alert('Saved Successfully');", true);
                    //TopRowDisplay();
                    txtdesignation.Text = "";
                     savbtn.Text = "Update";

                    savbtn.ToolTip = "Update";
                    savbtn1.Attributes["class"] = "btn ico-update";

                    // deltbtn.Enabled = false;
                    deltbtn.Visible = false;deltbtn_id.Visible = false;
                    canclbtn.Text = "Cancel";

                    canclbtn.ToolTip = "Cancel";
                    canclbtn1.Attributes["class"] = "btn ico-cancel";
                   // TopRowDisplay();
                }

                deltbtn.Visible = false;deltbtn_id.Visible = false;

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txt_Search.Focus();
        }

        [WebMethod]
        public static List<string> GetDesignationName(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterDesignation objp_begin = new DataAccess.Masters.MasterDesignation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objp_begin.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            dt = objp_begin.GetDesignationNamefun(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(dt, "designame", "designame");
            return List_Result;
        }

        public void check()
        {
            try
            {
              //  DataAccess.Masters.MasterDesignation objp_begin = new DataAccess.Masters.MasterDesignation();
                DataTable dt1 = new DataTable();
                dt1 = objp_begin.GetDesignationfun(txtdesignation.Text.ToUpper());

                if (dt1.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master designation", "alertify.alert('this name already exist');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void FillGrid()
        {
            try
            {
              //  DataAccess.Masters.MasterDesignation objp_begin = new DataAccess.Masters.MasterDesignation();
                DataTable dt_view = new DataTable();
                dt_view = objp_begin.viewdesignationfun();
                GridView1.DataSource = dt_view;
                GridView1.DataBind();
               canclbtn.Text = "Cancel";

                canclbtn.ToolTip = "Cancel";
                canclbtn1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void View()
        {
            try
            {
              //  DataAccess.Masters.MasterDesignation objp_begin = new DataAccess.Masters.MasterDesignation();
                DataTable dt_view = new DataTable();
                dt_view = objp_begin.viewdesignationfun();
                GridView1.DataSource = dt_view;
                GridView1.DataBind();
                canclbtn.Text = "Cancel";

                canclbtn.ToolTip = "Cancel";
                canclbtn1.Attributes["class"] = "btn ico-cancel";
                GridView1.Visible = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void viewbtn_Click(object sender, EventArgs e)
        {
           // GridView1.Visible = true;
           // divExport.Visible = true;
           //// deltbtn.Enabled = false;
           // deltbtn.Visible = false;deltbtn_id.Visible = false;
           // ////emp_grid();
           //  FillGrid();
            try
            {

                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                str_RptName = "MasterDesignation.rpt";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(viewbtn, typeof(Button), "MasterPort", str_Script, true);
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 332,3, int.Parse(Session["LoginBranchid"].ToString()), txtdesignation.Text+"/view");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void TopRowDisplay()
        {
            try
            {
                dt_com = objp_begin.GETGridTopDesignation();
                if (dt_com.Rows.Count > 0)
                {
                    GridView1.DataSource = dt_com;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void emp_grid()
        {
            try
            {
                DataTable dt_emp = new DataTable();
                GridView1.DataSource = dt_emp;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        public void clear()
        {
            
            txtdesignation.Text = "";
            savbtn.Text = "Save";

            savbtn.ToolTip = "Save";
            savbtn1.Attributes["class"] = "btn ico-save";


            canclbtn.Text = "Back";



            canclbtn.ToolTip = "Back";
            canclbtn1.Attributes["class"] = "btn ico-back";


           // deltbtn.Enabled = false;
            deltbtn.Visible = false;deltbtn_id.Visible = false;
            //GridView1.Visible = false;
            divExport.Visible = false;
            //TopRowDisplay();
            hdf1_designame.Value = "";
            

        }

        protected void canclbtn_Click(object sender, EventArgs e)
        {
          //  deltbtn.Enabled = false;
            deltbtn.Visible = false;deltbtn_id.Visible = false;
            if (canclbtn.ToolTip == "Back")
            {
                this.Response.End();
            }
            else
            {
                empty_grd();
                txtdesignation.Focus();
                clear();
                txt_Search.Text = "";
                //GridView1.Visible = false;
            }
        }

        protected void deltbtn_Click(object sender, EventArgs e)
        {

            try
            {
                bool type = false;
                deltbtn.Visible = false;deltbtn_id.Visible = false;
                if ((hfWasConfirmed.Value == "true"))
                {
                    if (hdf1_designame.Value != "")
                    {
                        desigid = Convert.ToInt32(hdf1_designame.Value.ToString());
                        objp_begin.DeltFun(desigid);
                        
                        ScriptManager.RegisterStartupScript(deltbtn, typeof(System.Web.UI.WebControls.Button), "Master Designation", "alertify.alert('Designation Details Deleted Successfully...');", true);
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 332,4, int.Parse(Session["LoginBranchid"].ToString()), desigid+"/delete");
                        txtdesignation.Text = "";

                         savbtn.Text = "Save";

                        savbtn.ToolTip = "Save";
                        savbtn1.Attributes["class"] = "btn ico-save";

                        //   deltbtn.Enabled = false;
                        deltbtn.Visible = false;deltbtn_id.Visible = false;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(deltbtn, typeof(System.Web.UI.WebControls.Button), "Master Designation", "alertify.alert('Designation not delete ...');", true);
                }

                View();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtdesignation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // deltbtn.Enabled = false;
                deltbtn.Visible = false;deltbtn_id.Visible = false;
                canclbtn.Text = "Cancel";

                canclbtn.ToolTip = "Cancel";
                canclbtn1.Attributes["class"] = "btn ico-cancel";

                DataTable dt = new DataTable();
                // deltbtn.Enabled = true;
              //  DataAccess.Masters.MasterDesignation objp_begin = new DataAccess.Masters.MasterDesignation();
                dt = objp_begin.Seldesigname(txtdesignation.Text.ToUpper());
                if (dt.Rows.Count > 0)
                {
                    hdf1_designame.Value = dt.Rows[0]["desigid"].ToString();
                     savbtn.Text = "Update";

                    savbtn.ToolTip = "Update";
                    savbtn1.Attributes["class"] = "btn ico-update";


                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Designation", "alertify.alert('Designation Already Exist');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txtdesignation.Focus();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
        private void ExportGridToPDF()
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Designation.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;
            DataTable dt = new DataTable();
            dt = objp_begin.viewdesignationfun();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0.0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();



        }

        protected void ExportToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Designation.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView1.AllowPaging = false;
                DataTable dt = new DataTable();
                dt = objp_begin.viewdesignationfun();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                // this.BindGrid();

                //  grdstate.HeaderRow.BackColor = Color.WHITE;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    //  row.BackColor = Color
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                GridView1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        protected void ExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        protected void ExportPDF_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();
        }

        protected void hdf1_designame_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = (DataTable)ViewState["designation"];
            GridView1.DataBind();
        }

        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    DataAccess.Masters.MasterDesignation objp_begin = new DataAccess.Masters.MasterDesignation();
        //    DataTable dt = new DataTable();
        //    dt = objp_begin.viewdesignationfun();
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
        //    GridView1.Visible = true;
        //    //divExport.Visible = true;
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

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 329, "MSdesign", txtdesignation.Text, txtdesignation.Text, "");  //"/Rate ID: " +
            if (txtdesignation.Text != "")
            {
                JobInput.Text = txtdesignation.Text;


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