using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser; 

namespace logix.Maintenance
{
    public partial class MasterDistrict : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        
        DataAccess.Masters.MasterDistrict obj_MasterDistrict = new DataAccess.Masters.MasterDistrict();
        int int_district;
        int int_state;
        int int_country;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           // ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(pdf);
           // ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(excel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnBack);
           // excel.ServerClick += new EventHandler(Excelfunforserver_Click);
           // pdf.ServerClick += new EventHandler(pdffunforserver_Click);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            btnDelete.Visible = false;
            if (!this.IsPostBack)
            {
                Ctrl_List = txtdistrict.ID + "~" + txtstate.ID + "~" + txtcountry.ID;
                Msg_List = "District Name~State Name~Country Name";
                Dtype_List = "string~string~string";
                btnSave.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                //str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btnSave, null, null);
                btnSave.Enabled = false;
                //btnDelete.Enabled = false;
                btnDelete.Visible = false;
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
        
            gridload();
           
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
        public static List<string> GetCountry(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterDistrict obj_MasterDistrict = new DataAccess.Masters.MasterDistrict();
            dt = obj_MasterDistrict.GetCountryName(prefix);
            // list_result = Fn_TableToList(prefix.ToUpper(), dt, "countryname");
            // list_result = obj_MasterDistrict.GetCountryName(prefix);
            list_result = Utility.Fn_TableToList(dt, "countryname", "countryid");
            return list_result;

        }
        [WebMethod]
        public static List<string> GetState(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterDistrict obj_MasterDistrict = new DataAccess.Masters.MasterDistrict();
            dt = obj_MasterDistrict.GetStateName(prefix);
            // list_result = Fn_TableToList(prefix.ToUpper(), dt, "countryname");
            // list_result = obj_MasterDistrict.GetCountryName(prefix);
            list_result = Utility.Fn_TableToList(dt, "statename", "stateid");
            return list_result;

        }
        [WebMethod]
        public static List<string> GetDistrict(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterDistrict obj_MasterDistrict = new DataAccess.Masters.MasterDistrict();
            dt = obj_MasterDistrict.GetDistrictName(prefix);
            // list_result = Fn_TableToList(prefix.ToUpper(), dt, "countryname");
            // list_result = obj_MasterDistrict.GetCountryName(prefix);
            list_result = Utility.Fn_TableToList(dt, "districtname", "districtid");
            return list_result;
        }
        private void gridload()
        {
            dt = obj_MasterDistrict.GetGrid();
            if (dt.Rows.Count > 0)
            {
                grd.DataSource = dt;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
           // btnDelete.Enabled = false;
            btnDelete.Visible = false;
            if (btnSave.Text == "Save")
            {
                 int_country = Convert.ToInt32(hdf_country.Value.ToString());
                 int_state = Convert.ToInt32(hdf_state.Value.ToString());
                 obj_MasterDistrict.InsMasterDistrict(txtdistrict.Text.ToUpper(), int_state, int_country);
                   ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('District Inserted Successfully');", true);
                  }
                else
                {
                    if (hdf_district.Value != "")                                                                                                                             
                    {
                        int_district = Convert.ToInt32(hdf_district.Value.ToString());
                        int_state = Convert.ToInt32(hdf_state.Value.ToString());
                        int_country = Convert.ToInt32(hdf_country.Value.ToString());
                        obj_MasterDistrict.UpdMasterDistrict(txtdistrict.Text.ToUpper(), int_state, int_country, int_district);
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('District Updated Successfully');", true);
                        
                    }
                }
          
            clear();
            //BindGrid();
        }

        private void BindGrid()
        {
            dt = obj_MasterDistrict.GetDistrictDetails4Grid();
            if (dt.Rows.Count > 0)
            {
                grd.DataSource = dt;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            BindGrid();
            //btnprint.Visible = true;
            signup.Visible = true;
        }

        protected void txtdistrict_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
           // btnDelete.Enabled = false;
            btnDelete.Visible = false;
            btnBack.Text = "Cancel";
            DataTable dt1 = new DataTable();
            dt1 = obj_MasterDistrict.GetDistrictName4textbox(txtdistrict.Text);
            if (dt1.Rows.Count > 0)
            {
               // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('District Aready exists....');", true);
                hdf_district.Value = dt1.Rows[0]["districtid"].ToString();
            }
            
                if (hdf_district.Value != "")
                {
                    int_district = Convert.ToInt32(hdf_district.Value.ToString());
                    dt = obj_MasterDistrict.GetDistrictDetails4All(int_district);
                    if (dt.Rows.Count > 0)
                    {
                        // txtdistrict.Text = dt.Rows[0]["districtname"].ToString();
                        hdf_district.Value = dt.Rows[0]["districtid"].ToString();
                        txtstate.Text = dt.Rows[0]["statename"].ToString();
                        txtcountry.Text = dt.Rows[0]["countryname"].ToString();
                        hdf_state.Value = dt.Rows[0]["stateid"].ToString();
                        hdf_country.Value = dt.Rows[0]["countryid"].ToString();
                        btnSave.Text = "Update";

                    }

                }
          
            else
            {
                btnSave.Text = "Save";

            }
            btnBack.Text = "Cancel";
           
        }

        private void clear()
        {
            txtdistrict.Text = "";
            txtstate.Text = "";
            txtcountry.Text = "";
            hdf_district.Value = "";
            gridload();
        }
        //private void checkName()
        //{
        //    if (txtdistrict.Text != "")
        //    {
        //        DataTable dt1 = new DataTable();
        //        dt1 = obj_MasterDistrict.GetDistrictName4textbox(txtdistrict.Text);
        //        if (dt1.Rows.Count > 0)
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('District Aready exists....');", true);
        //            hdf_district.Value = dt1.Rows[0]["districtid"].ToString();
        //        }
        //    }
        //}

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //btnDelete.Enabled = false;
            btnDelete.Visible = false;
            if (btnBack.Text == "Back")
            {
                this.Response.End();
            }
            else
            {
                clear();
                btnBack.Text = "Back";
                signup.Visible = false;
            }
           
        }

        protected void Excelfunforserver_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        protected void pdffunforserver_Click(object sender, EventArgs e)
        {
            ExportToPdf();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
        private void ExportToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "ExportExcel" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            grd.AllowPaging = false;
            BindGrid();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            grd.GridLines = GridLines.Both;
            grd.HeaderStyle.Font.Bold = true;
            grd.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
        private void ExportToPdf()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Export.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grd.AllowPaging = false;
          //  BindGrid();
            dt = obj_MasterDistrict.GetDistrictDetails4Grid();
            grd.DataSource = dt;
            grd.DataBind();
            signup.Visible = true;



            grd.RenderControl(hw);
            grd.HeaderRow.Style.Add("width", "5%");
            grd.HeaderRow.Style.Add("font-size", "10px");
            grd.Style.Add("text-decoration", "none");
            grd.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            grd.Style.Add("font-size", "8pt");
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

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void txtstate_TextChanged(object sender, EventArgs e)
        {
            dt = obj_MasterDistrict.Getstate4country(txtstate.Text );
             if (dt.Rows.Count > 0)
             {
                 hdf_state.Value=dt.Rows[0]["stateid"].ToString();
                 txtstate.Text=dt.Rows[0]["statename"].ToString();
                 hdf_country.Value=dt.Rows[0]["Countryid"].ToString();
                 txtcountry.Text=dt.Rows[0]["CountryName"].ToString();
                 if (hdf_state.Value != "")
                 {
                     int_state = Convert.ToInt32(hdf_state.Value.ToString());

                 }
                
             }
             else
             {
                 ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('Enter Valid States');", true);
                 txtstate.Text = "";
             }
             
        }

        protected void txtcountry_TextChanged(object sender, EventArgs e)
        {
            btnDelete.Visible = false;
            // btnDelete.Enabled = false;
            if (hdf_country.Value != "")
            {
                int_state = Convert.ToInt32(hdf_country.Value.ToString());

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('Enter Valid Country');", true);
                txtcountry.Text = "";
            }
        }



    }
}