using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Web.Services.Description;

namespace logix.Maintenance
{
    public partial class MasterSector : System.Web.UI.Page
    {
        int sectorid;
        DataTable dt_grid;
        DataAccess.Masters.MasterSector obj_main = new DataAccess.Masters.MasterSector();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterSector obj_upd = new DataAccess.Masters.MasterSector();
        DataAccess.Masters.MasterSector obj_dtt = new DataAccess.Masters.MasterSector();
        DataAccess.Masters.MasterSector obj_grid = new DataAccess.Masters.MasterSector();
        DataAccess.Masters.MasterSector obj_che = new DataAccess.Masters.MasterSector();
          DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        DataTable obj_dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnClear);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_main.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                obj_upd.GetDataBase(Ccode);
                obj_dtt.GetDataBase(Ccode);
                obj_grid.GetDataBase(Ccode);
                obj_che.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
               


            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            //pdf.ServerClick += new EventHandler(btnpdf_Click);
            //excel.ServerClick += new EventHandler(btnexcel_Click);
            btnDelete.Visible = false;btnDelete_id.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    Ctrl_List = txtsector.ID ;
                    Msg_List = "Sector Name";
                    Dtype_List = "string";
                    btnSave.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    btnDelete.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    btnDelete.Click += btnDelete_Click;
                    btnDelete.OnClientClick = @"return getConfirmationValue();";
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btnSave, null, null);
                    hdn_id.Value = "";

                    btnClear.Text = "Clear";
                    btnSave.Text = "Save";


                    btnClear.ToolTip = "Clear";
                    btnClear1.Attributes["class"] = "btn ico-clear";

                    btnSave.ToolTip = "Save";
                    btnSave1.Attributes["class"] = "btn ico-save";



                    txtsector.Focus();
                    //btnSave.Enabled = true;
                    btnDelete.Visible = false;btnDelete_id.Visible = false;
                    empty_grd();
                    // btnDelete.Enabled = false;
                  //  GridTopRow();
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
        

        [WebMethod]
        public static List<string> GetSector(string prefix)
        {
            List<string> List_Result = new List<string>();

            DataAccess.Masters.MasterSector obj_sec = new DataAccess.Masters.MasterSector();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_sec.GetDataBase(Ccode);
            DataTable dt_sector = new DataTable();
            dt_sector = obj_sec.GetLikesectorname(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(dt_sector, "sectorname", "sectorid");
            return List_Result;
        }


        [WebMethod]
        public static void GetEmpName(string Prefix)
        {

            DataTable obj_dtEmp = new DataTable();

            if (Prefix.Length > 0)
            {
                DataAccess.Masters.MasterSector obj_main = new DataAccess.Masters.MasterSector();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                obj_main.GetDataBase(Ccode);
                DataTable obj_dt = new DataTable();
                obj_dt = obj_main.GetLikesectorname(Prefix.ToUpper());
                obj_dtEmp.Columns.Add("sectorname");
                obj_dtEmp.Columns.Add("sectorid");

                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["sectorname"] = obj_dt.Rows[i][0].ToString();
                    dr["sectorid"] = obj_dt.Rows[i][1].ToString();


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
                    ViewState["Sector"] = obj_dtEmp;
                    grdview.DataSource = obj_dtEmp;
                    grdview.DataBind();

                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
            }
            else
            {
                grdview.DataSource = null;
                grdview.DataBind();
            }
        }
        protected void empty_grd()
        {
            grdview.DataSource = new DataTable();
            grdview.DataBind();
        }

        protected void txtsector_TextChanged(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Visible = false;btnDelete_id.Visible = false;
                btnSave.Enabled = true;
                // btnDelete.Enabled = false;
                if (txtsector.Text != "")
                {
                    check();
                    //btnSave.Text = "Update";
                }

                DataTable dt_get = new DataTable();
                if (hdn_id.Value != "")
                {
                   // dt_get = obj_main.GetAllSectorDetails(Convert.ToInt32(hdn_id.Value));
                  //  txtdescn.Text = dt_get.Rows[0]["descn"].ToString();
                    btnSave.Text = "Update";
                    btnClear.Text = "Cancel";


                    btnSave.ToolTip = "Update";
                    btnSave1.Attributes["class"] = "btn ico-update";

                    btnClear.ToolTip = "Cancel";
                    btnClear1.Attributes["class"] = "btn ico-cancel";


                    btnDelete.Visible = false;btnDelete_id.Visible = false;
                    //  btnDelete.Enabled = false;
                    //check();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txtsector.Focus();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Visible = false;btnDelete_id.Visible = false;
                //btnDelete.Enabled = false;       
                if (btnSave.ToolTip == "Update")
                {
                    if (hdn_id.Value != "")
                    {
                        //DataAccess.Masters.MasterSector obj_upd = new DataAccess.Masters.MasterSector();
                        obj_upd.UpdSector(txtsector.Text.ToUpper(), Convert.ToInt32(hdn_id.Value));
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Sector", "alertify.alert('Updated sucessfully');", true);
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 333, 2, int.Parse(Session["LoginBranchid"].ToString()), "Update");
                        btnDelete.Enabled = false;
                         btnSave.Text = "Save";
                        btnSave.ToolTip = "Save";
                        btnSave1.Attributes["class"] = "btn ico-save";


                       // viewgrid();
                        clear();
                        drop_box.Visible = false;
                    }
                }
                else
                {
                    if (btnSave.ToolTip == "Save")
                    {
                        check();
                        if (hdn_id.Value == "")
                        {
                            //DataAccess.Masters.MasterSector obj_dtt = new DataAccess.Masters.MasterSector();
                            obj_dtt.InsertSector(txtsector.Text.ToUpper());
                            hdn_id.Value = sectorid.ToString();
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Sector", "alertify.alert('Saved Successfully');", true);
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 333, 1, int.Parse(Session["LoginBranchid"].ToString()), "Save");
                            btnSave.Text = "Update";

                            btnSave.ToolTip = "Update";
                            btnSave1.Attributes["class"] = "btn ico-update";


                            btnDelete.Enabled = false;
                            //viewgrid();
                            clear();
                            drop_box.Visible = false;
                        }
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
               
     protected void btnview_Click(object sender, EventArgs e)
        {
            try
            {
                //drop_box.Visible = true;
                //btnDelete.Visible = false;btnDelete_id.Visible = false;
                //// btnDelete.Enabled = false;
                //empty_grid();
                //viewgrid();
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                str_RptName = "MasterSector.rpt";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "MasterSector", str_Script, true);
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 333, 3, int.Parse(Session["LoginBranchid"].ToString()), "view");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 
        }

        private void viewgrid()
        {
            //DataAccess.Masters.MasterSector obj_grid = new DataAccess.Masters.MasterSector();
            dt_grid = obj_grid.GetallDetails();
            grdview.Visible = true;
            if (dt_grid.Rows.Count > 0)
            {
                grdview.DataSource = dt_grid;
                grdview.DataBind();
            }
            btnClear.Text = "Clear";

            btnClear.ToolTip = "Clear";
            btnClear1.Attributes["class"] = "btn ico-clear";
        }

        private void GridTopRow()
        {
            DataTable dt_top = new DataTable();
            dt_top= obj_main.RetriveTopSectors();
            if (dt_top.Rows.Count > 0)
            {
                grdview.DataSource = dt_top;
                grdview.DataBind();
            }

        }

        private void empty_grid()
        {
            DataTable dt_emp = new DataTable();
            grdview.DataSource = dt_emp;
            grdview.DataBind();
        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            btnDelete.Visible = false;btnDelete_id.Visible = false;
            //btnDelete.Enabled = false;
            if (btnClear.ToolTip == "Clear")
            {
                clear();
                hdn_id.Value = "";
                //btnSave.Enabled = false;
                //btnDelete.Enabled = false;
                drop_box.Visible = false;
                btnClear.Text = "Back";
                btnSave.Text = "Save";


                btnClear.ToolTip = "Back";
                btnClear1.Attributes["class"] = "btn ico-back";
                btnSave.ToolTip = "Save";
                btnSave1.Attributes["class"] = "btn ico-save";


               // GridTopRow();
                empty_grd();
                txtsector.Focus();
                txt_Search.Text = "";
            }
            else if (btnClear.ToolTip == "Back")
            {
                this.Page.Response.End();
            }
        }

        private void check()
        {
            DataTable dt_check = new DataTable();
            //DataAccess.Masters.MasterSector obj_che = new DataAccess.Masters.MasterSector();
            dt_check = obj_che.Selsectorname(txtsector.Text.ToUpper());
            if (dt_check.Rows.Count > 0)
            {
                if (hdn_id.Value == "")
                {
                   DataTable dt_idasgn = new DataTable();
                   dt_idasgn = obj_main.GetsecId(txtsector.Text.ToUpper());
                   //dt_idasgn= obj_main.Getonsectorname(txtsector.Text);
                    hdn_id.Value = dt_idasgn.Rows[0]["sectorid"].ToString();

                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Sector", "alertify.alert('Sector Already Exitis');", true);
               btnSave.Text = "Update";

                btnSave.ToolTip = "Update";
                btnSave1.Attributes["class"] = "btn ico-update";
            }
            //else
            //{
            //    btnSave.Text = "Save";
            //}
        }

        private void clear()
        {
            txtsector.Text = "";
           // txtdescn.Text = "";
            hdn_id.Value = "";
          //  btnClear.Text = "Back";
            btnSave.Text = "Save";

            btnSave.ToolTip = "Save";
            btnSave1.Attributes["class"] = "btn ico-save";


            btnDelete.Visible = false;btnDelete_id.Visible = false;
            //btnSave.Enabled = true;
          //  btnDelete.Enabled = false;
            drop_box.Visible = false;
            //grdview.Visible = false;
            //btnSave.Enabled = true;
           
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        public void btnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                pdf_fun();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 
        }

        public void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                excel_fun();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 
        }

        private void pdf_fun()
        {
            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 333,4, int.Parse(Session["LoginBranchid"].ToString()), "view");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Sectors.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            grdview.AllowPaging = false;
                //sectorid = Convert.ToInt32(hdn_id.Value.ToString());
                dt_grid = obj_main.GetallDetails();
                grdview.DataSource = dt_grid;
                grdview.DataBind();
                drop_box.Visible = true;

            grdview.RenderControl(hw);
            grdview.HeaderRow.Style.Add("width", "5%");
            grdview.HeaderRow.Style.Add("font-size", "10px");
            grdview.Style.Add("text-decoration", "none");
            grdview.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            grdview.Style.Add("font-size", "8pt");
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

        private void excel_fun()
        {
            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 333,4, int.Parse(Session["LoginBranchid"].ToString()), "view");
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Sector.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grdview.AllowPaging = false;
                

                //if (hdn_id.Value != "")
                //{
                    //sectorid = Convert.ToInt32(hdn_id.Value.ToString());
                    dt_grid = obj_main.GetallDetails();
                    grdview.DataSource = dt_grid;
                    grdview.DataBind();
                    drop_box.Visible = true;
                //}
                //  grdstate.HeaderRow.BackColor = Color.WHITE;
                foreach (TableCell cell in grdview.HeaderRow.Cells)
                {
                    cell.BackColor = grdview.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdview.Rows)
                {
                    //  row.BackColor = Color
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdview.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdview.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }
                grdview.RenderControl(hw);
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            bool type = false;

            if (hfWasConfirmed.Value == "true")
            {
                ScriptManager.RegisterStartupScript(btnDelete, typeof(System.Web.UI.WebControls.Button), "Master Sector", "alertify.alert('thanks...');", true);
            }


            //ScriptManager.RegisterStartupScript(btnDelete, typeof(System.Web.UI.WebControls.Button), "Master Sector", "alertify.alert('Sector Deleted Successfully...');", true);
    
            //if(hdn_id.Value != "")   
            //{
            //    obj_main.GetDeleteSector(Convert.ToInt32(hdn_id.Value));
            //    ScriptManager.RegisterStartupScript(btnDelete, typeof(System.Web.UI.WebControls.Button), "Master Sector", "alertify.alert('Sector Deleted Successfully...');", true);
            //    clear();

            //}
    }
        


        

        protected void txtdescn_TextChanged(object sender, EventArgs e)
        {
            btnClear.Text = "Clear";

            btnClear.ToolTip = "Clear";
            btnClear1.Attributes["class"] = "btn ico-clear";
        }

        protected void grdview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdview.PageIndex = e.NewPageIndex;
            viewgrid();

        }

        protected void grdview_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdview_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            grdview.PageIndex = e.NewPageIndex;
            grdview.DataSource = (DataTable)ViewState["Sector"];
            grdview.DataBind();
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

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 333, "MSsector", txtsector.Text, txtsector.Text, "");  //"/Rate ID: " +
            if (txtsector.Text != "")
            {
                JobInput.Text = txtsector.Text;


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