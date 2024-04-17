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

namespace logix.Maintenance
{
    public partial class MasterLocation : System.Web.UI.Page
    {
        DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
        DataTable dt_citydet = new DataTable();
        DataTable dt_locdet = new DataTable();
        DataTable dt_grd = new DataTable();
        DataTable dt_grdFill = new DataTable();
        DataTable dt_check = new DataTable();
        DataTable dt_loccity = new DataTable();
        int cityid, locationid;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);

            btndelete.Click += btndelete_Click;
            btndelete.OnClientClick = @"return getConfirmationValue();";
            //txt_Location.Attributes.Add("onblur", "javascript:onChangeTest()");
            grdlocation.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            btndelete.Visible = false;
            if (!this.IsPostBack)
            {
              //  btndelete.Enabled = false;
                btnsave.Enabled = false;
                //btndelete.Enabled = false;
                btndelete.Visible = false;
                btncancel.Enabled = true;
                btncancel.Text = "Back";
                txt_Location.Focus();
                FillgrdonpageLoad();
                Ctrl_List = txt_Location.ID + "~" + txt_city.ID + "~" + txt_pincode.ID;
                Msg_List = "Location Name~City Name~Pin Code";
                Dtype_List = "string~string~string";
                btnsave.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                btndelete.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                Utility.Fn_CheckUserRights(str_Uiid, btnsave, null, null);
                Utility.Fn_CheckUserRights(str_Uiid, btndelete, null, null);
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
        public static List<string> GetLocation(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
            DataTable dt_Location = new DataTable();
            dt_Location = objp_location.GetLocationname(prefix);
            List_Result = Utility.Fn_DatatableToList_int16Display(dt_Location, "locport", "locationid", "cityname");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetCity(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterLocation objp_location = new DataAccess.Masters.MasterLocation();
            DataTable dt_Location = new DataTable();
            dt_Location = objp_location.GetCity(prefix);
            List_Result = Utility.Fn_TableToList(dt_Location, "portname", "portid");
            return List_Result;
        }


        public void FillgrdonpageLoad()
        {
             
            dt_grdFill = objp_location.FillGridOnPageLoad2location();
            grdlocation.Visible = true;
            grdlocation.DataSource = dt_grdFill;
            grdlocation.DataBind();
        }
        protected void txt_city_TextChanged(object sender, EventArgs e)
        {
           // btndelete.Enabled = false;
            btndelete.Visible = false;
            DataTable dtcity = new DataTable();
            dtcity = objp_location.CheckCityName(txt_city.Text.ToUpper());

            if (dtcity.Rows.Count > 0)
            {
                hdn_cityid.Value = dtcity.Rows[0]["portid"].ToString();
            }

           
            if (hdn_cityid.Value != "" && dtcity.Rows .Count >0)
            {
                cityid = Convert.ToInt32(hdn_cityid.Value.ToString());
                dt_citydet = objp_location.SelCityDeatils(cityid);
                if (dt_citydet.Rows.Count > 0)
                {   
                    txt_District.Text = dt_citydet.Rows[0]["dstrictname"].ToString();
                    txt_State.Text = dt_citydet.Rows[0]["statename"].ToString();
                    txt_Country.Text = dt_citydet.Rows[0]["countryname"].ToString();
                    hdn_countryname.Value = dt_citydet.Rows[0]["countryname"].ToString();
                    locationid = Convert.ToInt32(dt_citydet.Rows[0]["portid"].ToString());
                    btnsave.Text = "Save";
                    txt_pincode.Text = "";

                }


                if (hdn_locationid.Value != "")
                {
                    int locid=Convert .ToInt32 (hdn_locationid .Value);
                    int pid=Convert .ToInt32 (hdn_cityid .Value);
                    dt_loccity = objp_location.Checklocationcity(txt_Location.Text, pid);

                    if (dt_loccity.Rows.Count > 0)
                    {
                        hdn_locationid.Value = dt_loccity.Rows[0]["locationid"].ToString();
                        txt_pincode.Text = dt_loccity.Rows[0]["pincode"].ToString();
                        
                    }
                    btnsave.Text = "Update";
                }
                btnsave.Enabled = true;
               // btndelete.Enabled = true;
                btndelete.Visible = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Location", "alertify.alert('Invalid Location Name');", true);
                txt_city.Text = "";
                txt_city.Focus();
            }
            btncancel.Text = "Cancel";
        }
        protected void txt_Location_TextChanged(object sender, EventArgs e)
        {
            btnsave.Enabled = true;
           // btndelete.Enabled = false;
            btndelete.Visible = false;
            dt_check = objp_location.CheckDuplicateForLocation(txt_Location.Text);
            if(dt_check .Rows.Count>0 && hdn_locationid .Value=="")
            {
                hdn_locationid.Value = dt_check.Rows[0]["locationid"].ToString();
            }

            if (hdn_locationid.Value != "")
            {
                locationid = Convert.ToInt32(hdn_locationid.Value.ToString());
                dt_locdet = objp_location.SelLocationDeatils(locationid);
                if (dt_locdet.Rows.Count > 0)
                {
                    //txt_city.Text = dt_locdet.Rows[0]["portname"].ToString();
                    txt_District.Text = dt_locdet.Rows[0]["districtname"].ToString();
                    txt_State.Text = dt_locdet.Rows[0]["statename"].ToString();
                    txt_Country.Text = dt_locdet.Rows[0]["countryname"].ToString();
                    hdn_countryname.Value = dt_locdet.Rows[0]["countryname"].ToString();
                    txt_pincode.Text = dt_locdet.Rows[0]["pincode"].ToString();
                    //cityid = Convert.ToInt32(dt_locdet.Rows[0]["portid"].ToString());
                    //hdn_cityid.Value = dt_locdet.Rows[0]["portid"].ToString();

                }

                btnsave.Text = "Update";
            }
            else
            {
                btnsave.Text = "Save";
            }
            btncancel.Text = "Cancel";
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            //btndelete.Enabled = false;
            btndelete.Visible = false;
            if (btnsave.Text == "Save")
                {
                    if (txt_Location.Text != "" && txt_pincode .Text!="")
                    {
                        if (hdn_cityid.Value != "")
                            {

                                objp_location.InsertLocationDetails(txt_Location.Text.ToUpper().Trim(), Convert.ToInt32(hdn_cityid.Value.ToString()), txt_pincode.Text);
                                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Location", "alertify.alert('Location has Inserted...');", true);
                                clear();
                                
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Location", "alertify.alert('Invalid City Name...');", true);
                                clear();
                            }
                           
                        
                    }

                }
                else
                {
                    if (txt_Location.Text != "" && txt_pincode.Text != "")
                    {
                        if (hdn_locationid.Value != "")
                        {

                            if (hdn_cityid.Value != "")
                            {
                                cityid = Convert.ToInt32(hdn_cityid.Value.ToString());
                            }

                            if (cityid != 0)
                            {

                                objp_location.UpdateLocationDetails(txt_Location.Text.ToUpper().Trim(), cityid, txt_pincode.Text, Convert.ToInt32(hdn_locationid.Value.ToString()));
                                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Location", "alertify.alert('Location has Updated...');", true);
                                btnsave.Text = "Save";
                                cityid = 0;
                                clear();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Location", "alertify.alert('Invalid City Name...');", true);
                                txt_city.Text = "";
                            }
                        }
                    }

                }
          
        }

        public void clear()
        {
            txt_city.Text = "";
            txt_Location.Text = "";
            txt_District.Text = "";
            txt_pincode.Text = "";
            txt_State.Text = "";
            txt_Country.Text = "";
            btnsave.Text = "Save";
            btnsave.Enabled = false;
           // btndelete.Enabled = false;
            btndelete.Visible = false;
            dropdown_box.Visible = false;
            cityid = 0;
            locationid = 0;
            hdn_cityid.Value = "";
            hdn_locationid.Value = "";
            btncancel.Text = "Back";
            FillgrdonpageLoad();
           
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (btncancel.Text == "Cancel")
            {
                clear();
                btncancel.Text = "Back";
                FillgrdonpageLoad();
                btnsave.Text = "save";
                
               
            }
            else if (btncancel.Text == "Back")
            {
                this.Response.End();
            }
        }

        protected void btnview_Click1(object sender, EventArgs e)
        {
           // btndelete.Enabled = false;
            btndelete.Visible = false;
            if (txt_Country.Text != "")
            {
                grdlocation.Visible = true;
                bindgrid();
                dropdown_box.Visible = true;
          
            }
             else
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Location", "alertify.alert('Enter Valid CityName...');", true);
            }

        }

        private void ExportGridToPDF()
        {

            Response.ContentType = "application/pdf";
            string FileName = "LocationDetails" + DateTime.Now + ".pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grdlocation.AllowPaging = false;

            grdlocation.Visible = true;
            bindgrid();
      
            grdlocation.RenderControl(hw);
            grdlocation.HeaderRow.Style.Add("width", "5%");
            grdlocation.HeaderRow.Style.Add("font-size", "10px");
            grdlocation.Style.Add("text-decoration", "none");
            grdlocation.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            grdlocation.Style.Add("font-size", "8pt");
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
        protected void ExportToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            string FileName = "LocationDetails" + DateTime.Now + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdlocation.AllowPaging = false;
                grdlocation.Visible = true;
                bindgrid();
            
                foreach (TableCell cell in grdlocation.HeaderRow.Cells)
                {
                    cell.BackColor = grdlocation.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdlocation.Rows)
                {
                 
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdlocation.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdlocation.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdlocation.RenderControl(hw);
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void fnExportGridToPDF_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();
        }
        protected void fnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            bool type = false;

            if (hfWasConfirmed.Value == "true")
            {
                if (hdn_locationid.Value != "")
                {
                    locationid = Convert.ToInt32(hdn_locationid.Value.ToString());
                    //objp_location.DelLocationDetails(locationid);
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Location", "alertify.alert('Location Details Deleted Successfully...');", true);
                    clear();

                }
            }

        }

        protected void txt_pincode_TextChanged(object sender, EventArgs e)
        {

            //if (txt_pincode.Text != "")
            //{
            //    DataTable dt_pincode = new DataTable();
            //    dt_pincode = objp_location.Checkpincodeexist(txt_pincode.Text);
            //    if (dt_pincode.Rows.Count > 0)
            //    {
            //        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Location", "alertify.alert('Pincode already Exist...');", true);
            //        txt_pincode.Text = "";
            //        txt_pincode.Focus();
            //    }
            //}
        }
        protected void grdstate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdlocation.PageIndex = e.NewPageIndex;
            grdlocation.Visible = true;
            bindgrid();
        }
        public void bindgrid()
        {
                dt_grd = objp_location.SelFillGrid(hdn_countryname .Value);
                if (dt_grd.Rows.Count > 0)
                {
                    grdlocation.DataSource = dt_grd;
                    grdlocation.DataBind();
                    
                    btnsave.Enabled = true;
                   // btndelete.Enabled = false;
                    btndelete.Visible = false;
                }

        }


    }
}