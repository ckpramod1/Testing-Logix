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
    public partial class MasterState : System.Web.UI.Page
    {
      
        DataAccess.Masters.Masterstate objp_state = new DataAccess.Masters.Masterstate();
        DataTable dt_country = new DataTable();
        DataTable dt_get = new DataTable();
        DataTable dt_check = new DataTable();
        int countryid, stateid;
        DataTable dt_grd = new DataTable();
        DataTable dt_grdFill = new DataTable();
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
         
            //txtstate.Attributes.Add("onblur", "javascript:onChangeTest()");
            grdstate.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            btndelete.Visible = false;
            if (!this.IsPostBack)
            {
                btncancel.Text = "Back";
                txtstate.Focus();
                btnsave.Enabled = false;
                btndelete.Visible = false;
               // btndelete.Enabled = false;
                btncancel.Enabled = true;
                //validation
                FillgrdonpageLoad();
                Ctrl_List = txtstate.ID + "~" + txtcountry.ID;
                Msg_List = "State Name~Country Name";
                Dtype_List = "string~string";
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
        public static List<string> GetCountry(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.Masterstate objp_state = new DataAccess.Masters.Masterstate();
            DataTable dt_country = new DataTable();
            dt_country = objp_state.GetCountryName(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(dt_country, "countryname", "countryid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetStates(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.Masterstate objp_state = new DataAccess.Masters.Masterstate();
            DataTable dt_state = new DataTable();
            dt_state = objp_state.GetStatename(prefix);
            List_Result = Utility.Fn_TableToList(dt_state, "statename", "stateid");
            return List_Result;
        }

        public void FillgrdonpageLoad()
        {
            dt_grdFill= objp_state .FillGridOnPageLoad ();
            grdstate .Visible =true;
            grdstate .DataSource =dt_grdFill ;
            grdstate .DataBind ();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            btndelete.Visible = false;
            //btndelete.Enabled = false; 
            if (btnsave.Text == "Save")
             {
                    check();
                    if (hdn_countryid.Value != "" && txtstate .Text!="")
                    {
                        countryid = Convert.ToInt32(hdn_countryid.Value.ToString());
                        objp_state.InsertState(txtstate.Text.ToUpper().Trim (), countryid);
                        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master State", "alertify.alert('State has Inserted...');", true);
                        clear();
                       
                    }
                }
                else
                {

                    countryid = Convert.ToInt32(hdn_countryid.Value.ToString());
                    stateid = Convert.ToInt32(hdn_stateid.Value.ToString());
                    if (stateid != 0 && countryid != 0)
                    {
                        if (countryid !=0)
                        {
                       
                            objp_state.UpdateStatename(stateid, txtstate.Text.ToUpper ().Trim(), countryid);
                            ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master State", "alertify.alert('State has Updated...');", true);
                            clear();

                        }

                        else
                        {
                            ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master State", "alertify.alert('Invalid Country Name...');", true);
                        }
                    }

                }
           
        }
        protected void txtstate_TextChanged(object sender, EventArgs e)
        {
              btndelete.Visible = false;   
              btnsave.Enabled = true;
               // btndelete.Enabled = false;
                dt_check = objp_state.CheckDuplicateForStatename(txtstate.Text);
                if (dt_check.Rows.Count > 0)
                {
                    btnsave.Text = "Update";
                    hdn_stateid.Value = dt_check.Rows[0]["stateid"].ToString();
                }
                if (hdn_stateid.Value != "")
             
                {
                    stateid = Convert.ToInt32(hdn_stateid.Value.ToString());
                    dt_get = objp_state.GetCountryname4state(stateid);
                    if (dt_get.Rows.Count > 0)
                    {
                        txtcountry.Text = dt_get.Rows[0]["countryname"].ToString();
                        
                        countryid = Convert.ToInt32(dt_get.Rows[0]["countryid"].ToString());
                        hdn_countryid.Value = dt_get.Rows[0]["countryid"].ToString();
                        hdn_countryid_one.Value = dt_get.Rows[0]["countryid"].ToString();
                        btnsave.Text = "Update";
                        
                    }
                }
                else
                {
                    btnsave.Text = "Save";
                }
                btncancel.Text = "Cancel";
        
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            btndelete.Visible = false;
           // btndelete.Enabled = false;
            if (btncancel.Text == "Cancel")
            {
                clear();
                btncancel.Text = "Back";
                btnsave.Text = "Save";
                FillgrdonpageLoad();
            }
            else if (btncancel.Text == "Back")
            {
                this.Response.End();
            }

        }
        public void clear()
        {
            txtcountry.Text = "";
            txtstate.Text = "";
            stateid = 0;
            countryid = 0;
            hdn_countryid.Value = "";
            hdn_stateid.Value = "";
            btnsave.Enabled = false;
            btndelete.Visible = false;
           // btndelete.Enabled = false;
            btnsave.Text = "Save";
            btncancel.Text = "Back";
            dropdown_box.Visible = false;
            FillgrdonpageLoad();

        }
        public void check()
        {
            if (txtstate.Text != "")
            {
                dt_check = objp_state.CheckDuplicateForStatename(txtstate.Text);
                if (dt_check.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master State", "alertify.alert('StateName Already Exists...');", true);
                    txtstate.Text = "";
                }
            }
        }


        protected void btndelete_Click(object sender, EventArgs e)
        {
            btnsave.Enabled = true;
           // btndelete.Enabled = true;
            btndelete.Visible = false;
        }
        protected void txtcountry_TextChanged(object sender, EventArgs e)
        {
            btndelete.Visible = false;
            //btndelete.Enabled = false;
            DataTable dtcountry = new DataTable();
           
            dtcountry = objp_state.CheckCountryName(txtcountry.Text.ToUpper());
            hdn_countryid_one.Value = hdn_countryid.Value;
            if (hdn_countryid.Value != "" && (dtcountry .Rows.Count>0))
            {
                countryid = Convert.ToInt32(hdn_countryid.Value.ToString());
                btnsave.Enabled = true;
                btncancel.Text = "Cancel";
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master State", "alertify.alert('Invalid Country Name...');", true);
                txtcountry.Text = "";
            }
        }
        protected void btnview_Click(object sender, EventArgs e)
        {
            btndelete.Visible = false;
            //btndelete.Enabled = false;
            if (txtcountry.Text != "")
            {

                grdstate.Visible = true;
                bindgrid();
                dropdown_box.Visible = true;
            
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master State", "alertify.alert('Enter the Valid CountryName...');", true);
            }
        }

        private void ExportGridToPDF()
        {
            Response.ContentType = "application/pdf";
            string FileName = "StateDetails" + DateTime.Now + ".pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grdstate.AllowPaging = false;
            bindgrid();
            grdstate.RenderControl(hw);
            grdstate.HeaderRow.Style.Add("width", "15%");
            grdstate.HeaderRow.Style.Add("font-size", "10px");
            grdstate.Style.Add("text-decoration", "none");
            grdstate.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            grdstate.Style.Add("font-size", "8px");
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
            string FileName = "StateDetails" + DateTime.Now + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grdstate.AllowPaging = false;
                bindgrid();
              
                foreach (TableCell cell in grdstate.HeaderRow.Cells)
                {
                    cell.BackColor = grdstate.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdstate.Rows )
                {
                   
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdstate.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdstate.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdstate.RenderControl(hw);
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
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

        protected void grdstate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdstate.PageIndex = e.NewPageIndex;
            bindgrid();

        }
        public void bindgrid()
        {
            if (hdn_countryid_one.Value != "")
            {
                countryid = Convert.ToInt32(hdn_countryid_one.Value.ToString());
                dt_get = objp_state.GetCountryFillGrid(countryid);
                grdstate.DataSource = dt_get;
                grdstate.DataBind();
            }

        }
    }
}