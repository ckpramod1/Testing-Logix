using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser; 
namespace logix.Maintenance
{
    public partial class MasterRegion1 : System.Web.UI.Page
    {
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";

        int regionid;
        DataAccess.Masters.MasterRegion objp_start = new DataAccess.Masters.MasterRegion();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataTable dt_com = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                objp_start.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
               
            }


            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(canclbtn);
            deltbtn.Visible = false;deltbtn_id.Visible = false;
            if (!IsPostBack)
            {
                Ctrl_List = txtregin.ID + "~" + txtdes.ID;
                Msg_List = "Region~Description";
                Dtype_List = "string~string";
                savbtn.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                Utility.Fn_CheckUserRights(str_Uiid, savbtn, null, null);
                savbtn.Text = "Save";


                savbtn.ToolTip = "Save";
                savbtn1.Attributes["class"] = "btn ico-save";
                txtregin.Focus();
                //TopRowDisplay();
                clear();
                deltbtn.Click += deltbtn_Click;
                deltbtn.OnClientClick = @"return getConfirmationValue();";
                deltbtn.Visible = false;deltbtn_id.Visible = false;
                // deltbtn.Enabled = false;
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

            //pdf.ServerClick += new EventHandler(ExportPDF_Click);
            //excel.ServerClick += new EventHandler(ExportExcel_Click);
        }

        protected void savbtn_Click(object sender, EventArgs e)
        {
            //  deltbtn.Enabled = false;
            deltbtn.Visible = false;deltbtn_id.Visible = false;
            if (savbtn.ToolTip == "Update")
            {

                //DataAccess.Masters.MasterRegion objp_start = new DataAccess.Masters.MasterRegion();
                objp_start.updatefun(Convert.ToInt32(hdf1.Value), txtregin.Text.ToUpper().Trim(), txtdes.Text.ToUpper().Trim());
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master region", "alertify.alert('Updated sucessfully');", true);
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 330,2, int.Parse(Session["LoginBranchid"].ToString()), "Update");
                //TopRowDisplay();
                //clear();
                txtregin.Text = "";
                txtdes.Text = "";
                savbtn.Text = "Save";


                savbtn.ToolTip = "Save";
                savbtn1.Attributes["class"] = "btn ico-save";
                //View();

            }

            else
            {
              
               // DataAccess.Masters.MasterRegion objp_start = new DataAccess.Masters.MasterRegion();
                regionid = Convert.ToInt32(objp_start.InsertRegionDeatils(txtregin.Text.ToUpper().Trim(), txtdes.Text.ToUpper().Trim()));
                hdf1.Value = regionid.ToString();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master region", "alertify.alert('Saved Successfully');", true);
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 330, 1, int.Parse(Session["LoginBranchid"].ToString()), "Save");
                txtdes.Text = "";
                txtregin.Text = "";
                //TopRowDisplay();
                //clear();
                //View();
                   savbtn.Text = "Save";


                savbtn.ToolTip = "Update";
                savbtn1.Attributes["class"] = "btn ico-update";
            }
            txtregin.Focus();
        }
        [WebMethod]
        public static List<string> GetRegion(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterRegion objp_start = new DataAccess.Masters.MasterRegion();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objp_start.GetDataBase(Ccode);
            DataTable dt_country = new DataTable();
            dt_country = objp_start.GetRegionName(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(dt_country, "region", "regionid");
            return List_Result;
        }

        private void TopRowDisplay()
        {
            dt_com = objp_start.GETGridTopRegion();
            if (dt_com.Rows.Count > 0)
            {
                GridView1.DataSource = dt_com;
                GridView1.DataBind();
            }
        }

        private void emp_grid()
        {
            DataTable dt_emp = new DataTable();
            GridView1.DataSource = dt_emp;
            GridView1.DataBind();
        }



        protected void canclbtn_Click(object sender, EventArgs e)
        {
            deltbtn.Visible = false;deltbtn_id.Visible = false;
            // deltbtn.Enabled = false;
            if (canclbtn.ToolTip == "Back")
            {
                this.Response.End();

            }
            else
            {
                clear();
                //GridView1.Visible = false;

            }
        }


        private void clear()
        {
            txtdes.Text = "";
            txtregin.Text = "";
            savbtn.Text = "Save";
           canclbtn.Text = "Back";


            savbtn.ToolTip = "Save";
            savbtn1.Attributes["class"] = "btn ico-save";


            canclbtn.ToolTip = "Back";
            canclbtn1.Attributes["class"] = "btn ico-back";
            deltbtn.Visible = false;deltbtn_id.Visible = false;
            //deltbtn.Enabled = false;
            //GridView1.Visible = false;
            divExport.Visible = false;
            TopRowDisplay();


        }

        protected void viewbtn_Click(object sender, EventArgs e)
        {
            //deltbtn.Visible = false;deltbtn_id.Visible = false;
            ////deltbtn.Enabled = false;
            //emp_grid();
            //GridView1.Visible = true;
            //canclbtn.Text = "Cancel";
            //DataTable dt = new DataTable();
            //DataAccess.Masters.MasterRegion objp_start = new DataAccess.Masters.MasterRegion();
            //dt = objp_start.viewfun();
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
            //divExport.Visible = true;
            try
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                str_sp = "CompanyName=" + Session["LoginDivisionName"].ToString();
                str_RptName = "MasterRegion.rpt";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(viewbtn, typeof(Button), "Masterregion", str_Script, true);
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 330, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                Session["str_sfs"] = "";
                Session["str_sp"] = str_sp;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        public void View()
        {
            emp_grid();
            GridView1.Visible = true;
          //  canclbtn.Text = "Cancel";

            canclbtn.ToolTip = "Cancel";
            canclbtn1.Attributes["class"] = "btn ico-cancel";

            DataTable dt = new DataTable();
          //  DataAccess.Masters.MasterRegion objp_start = new DataAccess.Masters.MasterRegion();
            dt = objp_start.viewfun();
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
        private void ExportGridToPDF()
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Region.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;
            DataTable dt = new DataTable();
            dt = objp_start.viewfun();
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
            Response.AddHeader("content-disposition", "attachment;filename=Region.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView1.AllowPaging = false;
                DataTable dt = new DataTable();
                dt = objp_start.viewfun();
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

        public void check()
        {
            DataTable dt = new DataTable();
          //  DataAccess.Masters.MasterRegion objp_start = new DataAccess.Masters.MasterRegion();
            dt = objp_start.GetRegion(txtregin.Text);

            if (dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master region", "alertify.alert('Region Already Exist');", true);

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

        protected void hdf1_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void deltbtn_Click(object sender, EventArgs e)
        {
            bool type = false;

            if ((hfWasConfirmed.Value == "true"))
            {
                if (hdf1.Value != "")
                {
                    regionid = Convert.ToInt32(hdf1.Value.ToString());
                    objp_start.DeltFun(regionid);
                    ScriptManager.RegisterStartupScript(deltbtn, typeof(System.Web.UI.WebControls.Button), "Master Region", "alertify.alert('Region Details Deleted Successfully...');", true);
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 330, 4, int.Parse(Session["LoginBranchid"].ToString()), "Delete");
                    txtdes.Text = "";
                    txtregin.Text = "";
                    savbtn.Text = "Save";

                    savbtn.ToolTip = "Save";
                    savbtn1.Attributes["class"] = "btn ico-save";

                    deltbtn.Visible = false;deltbtn_id.Visible = false;
                    //  deltbtn.Enabled = false;

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(deltbtn, typeof(System.Web.UI.WebControls.Button), "Master Region", "alertify.alert('Region not delt ...');", true);
            }
           // View();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.Visible = true;
            DataTable dt = new DataTable();
           // DataAccess.Masters.MasterRegion objp_start = new DataAccess.Masters.MasterRegion();
            dt = objp_start.viewfun();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //divExport.Visible = true;
        }

        protected void txtregin_TextChanged(object sender, EventArgs e)
        {
            savbtn.Enabled = true;
           // canclbtn.Text = "Cancel";


            canclbtn.ToolTip = "Cancel";
            canclbtn1.Attributes["class"] = "btn ico-cancel";

            deltbtn.Visible = false;deltbtn_id.Visible = false;
            //deltbtn.Enabled = false;
            DataTable dt = new DataTable();
          //  DataAccess.Masters.MasterRegion objp_start = new DataAccess.Masters.MasterRegion();
            dt = objp_start.GetRegion(txtregin.Text);
            //check();
            if (dt.Rows.Count > 0)
            {
                hdf1.Value = dt.Rows[0]["regionid"].ToString();
                txtdes.Text = dt.Rows[0]["descn"].ToString();
               savbtn.Text = "Update";

                savbtn.ToolTip = "Update";
                savbtn1.Attributes["class"] = "btn ico-update";
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master region", "alertify.alert('Region Already Exist');", true);
            }
            txtdes.Focus();
        }

        protected void txtdes_TextChanged(object sender, EventArgs e)
        {

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
          //  DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 330, "MSREGION", txtregin.Text, txtregin.Text, "");  //"/Rate ID: " +
            if (txtregin.Text != "")
            {
                JobInput.Text = txtregin.Text;


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