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

namespace logix.Maintenance
{
    public partial class MasterCountry : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCountry obj_cut = new DataAccess.Masters.MasterCountry();
       
      
        int filesize;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        string empty;
        protected void Page_Load(object sender, EventArgs e)
        {
          

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
           // ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(pdf);
           // ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(excel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Button_save);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Button_cancel);
           //excel.ServerClick += new EventHandler(Excelfunforserver_Click);
           // pdf.ServerClick += new EventHandler(pdffunforserver_Click);
            Button_delete.Visible = false;               
            if (!IsPostBack)
            {
               
                Button_save.Enabled = false;
               // Button_delete.Enabled = false;               
                Button_delete.Visible = false;               
                Ctrl_List = txt_Country.ID + "~" + TextBox_currency.ID + "~" + TextBox_cents.ID + "~" + TextBox_ISD.ID + "~" + TextBox_MRcode.ID + "~" + TextBox_Sector.ID;
                Msg_List = "Country Name~Currency~Cents~isd code~Mr Code~Sector Name";
                Dtype_List = "string~string~string~int~string~string";
                Button_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");                
                Utility.Fn_CheckUserRights(str_Uiid, Button_save, null, null);
                TopRowGridDisplay();

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
        [WebMethod]
        public static List<string> GetCountry(string prefix)
        {
            List<string> List_Result = new List<string>();           
            DataAccess.Masters.MasterCountry obj_cut = new DataAccess.Masters.MasterCountry();
            DataTable dt_country = new DataTable();
            dt_country = obj_cut.GetCountryname(prefix);
            List_Result = Utility.Fn_TableToList(dt_country, "CountryName", "Countryid");
            return List_Result;

        }
        [WebMethod]
        public static List<string> GetSector(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCountry obj_cut = new DataAccess.Masters.MasterCountry();
            DataTable dt_country = new DataTable();
            dt_country = obj_cut.GetSectorname(prefix);
            List_Result = Utility.Fn_TableToList(dt_country, "sectorname", "sectorid");
            return List_Result;

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


        protected void Button_save_Click(object sender, EventArgs e)
        {
           // Button_delete.Enabled = false;
            Button_delete.Visible = false;               
            if (hdn_flag.Value != "")
            {
               empty = hdn_flag.Value;
            }
            if (txt_Country.Text != "") 
            {
                if (Button_save.Text == "Save")
                {
                    if (hdncountry_id.Value == "")
                    {
                        Byte[] imgbyte = null;
                        if (FileUpload1.HasFile || FileUpload1.PostedFile != null)
                        {
                            HttpPostedFile File = FileUpload1.PostedFile;
                            imgbyte = new Byte[File.ContentLength];
                            File.InputStream.Read(imgbyte, 0, File.ContentLength);
                            filesize = FileUpload1.PostedFile.ContentLength / 1024;
                            string base64String = Convert.ToBase64String(imgbyte);
                            hdn_flag.Value = base64String;
                            img_flag.ImageUrl = "data:image/png;base64," + base64String;
                        }

                        int sectorid = Convert.ToInt32(hdf_sectorid.Value);

                        if (filesize > 20)
                        {
                            ScriptManager.RegisterStartupScript(img_flag, typeof(Button), "DataFound", "alertify.alert('Image Size Does not Exist 20kb');", true);
                            FileUpload1.Attributes.Clear();
                            img_flag.ImageUrl = "";
                            return;
                        }

                        obj_cut.MasterCountryInsert(txt_Country.Text, TextBox_currency.Text, TextBox_cents.Text, Convert.ToInt32(TextBox_ISD.Text), Convert.ToInt32(hdf_sectorid.Value), TextBox_MRcode.Text, imgbyte);
                        ScriptManager.RegisterStartupScript(Button_save, typeof(Button), "DataFound", "alertify.alert('Inserted successfully');", true);
                        Button_save.Text = "Update";
                        //GridFill();
                        TopRowGridDisplay();
                        clear();
                        signup.Visible = false;
                    }
                }


                else
                {
                    if (hdncountry_id.Value != "")
                    {
                        Byte[] imgbyte = null;
                        if (FileUpload1.HasFile || FileUpload1.PostedFile != null)
                        {
                            HttpPostedFile File = FileUpload1.PostedFile;
                            imgbyte = new Byte[File.ContentLength];

                            File.InputStream.Read(imgbyte, 0, File.ContentLength);
                            filesize = FileUpload1.PostedFile.ContentLength / 1024;
                            string base64String = Convert.ToBase64String(imgbyte);
                            hdn_flag.Value = base64String;
                            img_flag.ImageUrl = "data:image/png;base64," + base64String;

                        }
                        if (filesize > 20)
                        {
                            ScriptManager.RegisterStartupScript(img_flag, typeof(Button), "DataFound", "alertify.alert('Image Size Does not Exist 20kb');", true);
                            FileUpload1.Attributes.Clear();
                           
                            return;
                        }

                        int int_sectorid = Convert.ToInt32(hdf_sectorid.Value);
                        int int_hdncountry_id = Convert.ToInt32(hdncountry_id.Value);

                        if (FileUpload1.FileName == string.Empty)
                        {
                            Byte[] imgbyte1 = Convert.FromBase64String(empty);
                            obj_cut.GetUpdateCountry(txt_Country.Text, TextBox_currency.Text, TextBox_cents.Text, Convert.ToInt16(TextBox_ISD.Text), TextBox_MRcode.Text, int_sectorid, imgbyte1, int_hdncountry_id);
                            ScriptManager.RegisterStartupScript(Button_save, typeof(Button), "DataFound", "alertify.alert('update successfully');", true);
                           

                        }
                        else
                        {
                            obj_cut.GetUpdateCountry(txt_Country.Text, TextBox_currency.Text, TextBox_cents.Text, Convert.ToInt16(TextBox_ISD.Text), TextBox_MRcode.Text, int_sectorid, imgbyte, int_hdncountry_id);
                            ScriptManager.RegisterStartupScript(Button_save, typeof(Button), "DataFound", "alertify.alert('update successfully');", true);
                         
                        }
                        //GridFill();
                        TopRowGridDisplay();
                        signup.Visible = false;
                        clear();
                    }
                }
            }
        }

        public void checkdataCountry()
        {
            if (txt_Country.Text == "")
            {
                txt_Country.Text = "Enter Country";
                txt_Country.Focus();

            }
            else if (TextBox_currency.Text == "")
            {
                TextBox_currency.Text = "";
                TextBox_currency.Focus();
            }

            else if (TextBox_cents.Text == "") 
            {
                TextBox_cents.Text = "Enter cents";
                TextBox_cents.Focus();
            }
            else if (TextBox_ISD.Text == "")
            {
                TextBox_ISD.Text = "Enter ISD";
                TextBox_ISD.Focus();
            }
            else if (TextBox_MRcode.Text == "")
            {
                TextBox_MRcode.Text = "Enter cents";
                TextBox_MRcode.Focus();
            }
           
           
        }
            
        

        protected void txt_Country_TextChanged(object sender, EventArgs e)
        {           
            try
            { 
            Button_save.Enabled = true;
         //   Button_delete.Enabled = false;
            Button_delete.Visible = false;               
            DataTable dt = new DataTable();
          
            dt = obj_cut.GetCountryname4Auto(txt_Country.Text.ToString());
            if (dt.Rows.Count > 0)
            {
                txt_Country.Text = dt.Rows[0]["CountryName"].ToString();
                TextBox_currency.Text = dt.Rows[0]["Currency"].ToString();
                TextBox_cents.Text = dt.Rows[0]["Cents"].ToString();
                TextBox_ISD.Text = dt.Rows[0]["ISDcode"].ToString();
                TextBox_MRcode.Text = dt.Rows[0]["MRcode"].ToString();
                TextBox_Sector.Text = dt.Rows[0]["sectorname"].ToString();
                hdf_sectorid.Value = dt.Rows[0]["sectorid"].ToString();
                
                
                 //Byte[] imageBytes = null;
                 // if (FileUpload1.HasFile || FileUpload1.PostedFile != null)
                 //    {
                if (dt.Rows[0]["Flag"].ToString() != "")
                {
                    Byte[] imageBytes = ((byte[])dt.Rows[0]["Flag"]);
                    //Byte[] imgbyte1 = Convert.FromBase64String(hdn_flag.Value);               
                    string base64String = Convert.ToBase64String(imageBytes);
                    hdn_flag.Value = base64String;
                    img_flag.ImageUrl = "data:image/png;base64," + base64String;
                    //}

                    if (filesize > 20)
                    {
                        ScriptManager.RegisterStartupScript(img_flag, typeof(Button), "DataFound", "alertify.alert('Image Size Does not Exist 20kb');", true);
                        FileUpload1.Attributes.Clear();
                        img_flag.ImageUrl = "";
                        return;
                    }
                }
                

                Button_save.Text = "Update";
                Button_cancel.Text = "Cancel";
            
            }
            else
            {
                Button_save.Text = "Save";
                Button_cancel.Text = "Cancel";

            }
            }

            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(GridView), "test", "alertify.alert('No Flag Image');", true);
            }
           
        }


        protected void Button_view_Click(object sender, EventArgs e)
        {
            signup.Visible = true;
            GridCountry.Visible = true;
            //Button_delete.Enabled = false;
            Button_delete.Visible = false;               
            empty_grid();
            GridFill();
            
          
        }
        private void GridFill()
        {
            DataTable ds = new DataTable();
            GridCountry.DataSource = null;
            GridCountry.DataBind();
            ds = obj_cut.GetGridview();
            if (ds.Rows.Count > 0)
            {
                GridCountry.DataSource = ds;
                GridCountry.DataBind();
            }

        }
        private void empty_grid()
        {
            DataTable ds_emp = new DataTable();
            GridCountry.DataSource = ds_emp;
            GridCountry.DataBind();
        }
        private void TopRowGridDisplay()
        {
            DataTable ds_emp = new DataTable();
            ds_emp = obj_cut.CountryTopGridRow();
            GridCountry.DataSource = ds_emp;
            GridCountry.DataBind();
        }

        protected void Button_cancel_Click(object sender, EventArgs e)
        {
            if (Button_cancel.Text == "Back")
            {
                this.Response.End();
            }
            else
            {
                clear();
                TopRowGridDisplay();
            }
        }

        private void clear()
        {                      
            Button_save.Text = "Save";
            txt_Country.Text = "";
            TextBox_currency.Text = "";
            TextBox_cents.Text = "";
            TextBox_ISD.Text = "";
            TextBox_MRcode.Text = "";
            img_flag.ImageUrl = "";
            hdf_sectorid.Value = "";
            TextBox_Sector.Text = "";
            signup.Visible = false;
            hdn_flag.Value = "";
          FileUpload1.Attributes.Clear();
          hdncountry_id.Value = "";
          hdf_sectorid.Value = "";
          TopRowGridDisplay();
           
            Button_cancel.Text = "Back";
        }

        private void ExportGridToPDF()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Country.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridCountry.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            GridCountry.AllowPaging = true;
            GridCountry.DataBind();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Country" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridCountry.GridLines = GridLines.Both;
            GridCountry.HeaderStyle.Font.Bold = true;
            GridCountry.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        protected void btn_exl_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }
        protected void Excelfunforserver_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }


        protected void pdffunforserver_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();
        }

        protected void GridCountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridCountry.PageIndex = e.NewPageIndex;
            
            GridCountry.Visible = true;         
            DataTable dt = new DataTable();
            GridCountry.DataSource = null;
            GridCountry.DataBind();
            dt = obj_cut.GetGridview();
            if (dt.Rows.Count > 0)
            {
                GridCountry.DataSource = dt;
                GridCountry.DataBind();
                //signup.Visible = true;

            }
        }

        protected void TextBox_Sector_TextChanged1(object sender, EventArgs e)
        {
            Button_delete.Visible = false;               
            DataAccess.Masters.MasterCountry objp = new DataAccess.Masters.MasterCountry();
            DataTable dt_sector = new DataTable();
            dt_sector = objp.GetSectorname(TextBox_Sector.Text);
            if (dt_sector.Rows.Count > 0)
            {
                hdf_sectorid.Value = dt_sector.Rows[0]["sectorid"].ToString();
                Button_cancel.Text = "Cancel";
            }
            else
            {
                ScriptManager.RegisterStartupScript(Button_save, typeof(Button), "DataFound", "alertify.alert('Please Enter Valid Sector');", true);
                TextBox_Sector.Text = "";
                TextBox_Sector.Focus();
                Button_cancel.Text = "Cancel";
            }
            Button_cancel.Text = "Cancel";
        }

        protected void TextBox_Sector_TextChanged(object sender, EventArgs e)
        {
            Button_delete.Visible = false;               
            if (TextBox_Sector.Text != "")
            {
                DataAccess.Masters.MasterSector get_sector = new DataAccess.Masters.MasterSector();
                DataTable dt_secid = new DataTable();
                dt_secid = get_sector.GetsecId(TextBox_Sector.Text.ToUpper());

                if (dt_secid.Rows.Count > 0)
                {
                    hdf_sectorid.Value = dt_secid.Rows[0]["sectorid"].ToString();
                    Button_cancel.Text = "Cancel";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Button_save, typeof(Button), "DataFound", "alertify.alert('Choose Correct Sector...');", true);
                    TextBox_Sector.Text = "";
                    TextBox_Sector.Focus();
                    Button_cancel.Text = "Cancel";
                }
                Button_cancel.Text = "Cancel";
            }
        }

        

                 
    }
}