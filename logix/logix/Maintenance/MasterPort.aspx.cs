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
using System.Web.Services.Description;

namespace logix.Maintenance
{

    public partial class MasterPort : System.Web.UI.Page
    {
        DataAccess.Masters.MasterDistrict obj_MasterDistrict = new DataAccess.Masters.MasterDistrict();
        DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.Masters.MasterPort obj = new DataAccess.Masters.MasterPort();
        DataTable dt = new DataTable();
        DataTable obj_dt = new DataTable();
        int int_country;
        int int_sector;
        int int_district;
        int int_state;
        int int_port;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        int countryid;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_MasterDistrict.GetDataBase(Ccode);
                obj_MasterPort.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);
                obj.GetDataBase(Ccode);
               

            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnclose);
            // excel.ServerClick += new EventHandler(Excelfunforserver_Click);
            // pdf.ServerClick += new EventHandler(pdffunforserver_Click);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            btndelete.Visible = false;btndelete_id.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    countryid = obj_UP.Get_countrycodebyid(Convert.ToInt32( Session["LoginBranchid"]));
                    //if( (countryid == 1102)||(countryid == 102))
                    //{
                    //    Ctrl_List = txtportname.ID + "~" + txtdistrict.ID + "~" + txtstate.ID + "~" + txtcountry.ID + "~" + txtsector.ID + "~" + txtstdcode.ID;
                    //    Msg_List = "Port name~District Name~State Name~Country Name~Sector Name~ STD Code";
                    //    Dtype_List = "string~string~string~string~string~string";
                    //}else
                    //{
                    //    Ctrl_List = txtportname.ID + "~" +  txtcountry.ID;
                    //    Msg_List = "Port name~Country Name";
                    //    Dtype_List = "string~string";
                    //}
                    
                    btnsave.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btnsave, null, null);
                    btndelete.Visible = false;btndelete_id.Visible = false;
                    btnsave.Enabled = false;
                    //btndelete.Enabled = false;
                    grid();
                    txtportname.Focus();
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
        public static List<string> GetCountry(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCountry obj_Master = new DataAccess.Masters.MasterCountry();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_Master.GetDataBase(Ccode);
            dt = obj_Master.GetAllCountry(prefix.ToUpper());
            // list_result = Fn_TableToList(prefix.ToUpper(), dt, "countryname");
            // list_result = obj_MasterDistrict.GetCountryName(prefix);
            list_result = Utility.Fn_TableToList(dt, "countryname", "countryid");
            return list_result;

        }

        [WebMethod]
        public static List<string> GetDistrict(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterDistrict obj_MasterDistrict = new DataAccess.Masters.MasterDistrict();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterDistrict.GetDataBase(Ccode);
            dt = obj_MasterDistrict.GetDistrictName(prefix.ToUpper());
            // list_result = Fn_TableToList(prefix.ToUpper(), dt, "countryname");
            // list_result = obj_MasterDistrict.GetCountryName(prefix);
            list_result = Utility.Fn_TableToList(dt, "districtname", "districtid");
            return list_result;

        }
        [WebMethod]
        public static List<string> GetPort(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterPort.GetDataBase(Ccode);
            dt = obj_MasterPort.GetPortCodeDetails(prefix.ToUpper());
            // list_result = Fn_TableToList(prefix.ToUpper(), dt, "countryname");
            // list_result = obj_MasterDistrict.GetCountryName(prefix);
            list_result = Utility.Fn_TableToList(dt, "portcode", "portid");
            return list_result;

        }
        [WebMethod]
        public static List<string> GetPortName(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterPort.GetDataBase(Ccode);
            dt = obj_MasterPort.GetPortNameDetails(prefix.ToUpper());
            // list_result = Fn_TableToList(prefix.ToUpper(), dt, "countryname");
            // list_result = obj_MasterDistrict.GetCountryName(prefix);
            list_result = Utility.Fn_TableToList(dt, "portname", "portid");
            return list_result;

        }

        [WebMethod]
        public static void GetEmpName(string Prefix)
        {

            DataTable obj_dtEmp = new DataTable();

            if (Prefix.Length > 0)
            {
                DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                obj_MasterPort.GetDataBase(Ccode);
                DataTable obj_dt = new DataTable();
                obj_dt = obj_MasterPort.GetLikePort4grd(Prefix.ToUpper());
                obj_dtEmp.Columns.Add("portname");
                ////obj_dtEmp.Columns.Add("currency");
                ////obj_dtEmp.Columns.Add("amount");
                ////obj_dtEmp.Columns.Add("percentage");
                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["portname"] = obj_dt.Rows[i][0].ToString();
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
                    ViewState["data"] = obj_dtEmp;
                    grd1.DataSource = obj_dtEmp;
                    grd1.DataBind();

                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
            
            }
            else
            {
                grd1.DataSource = null;
                grd1.DataBind();
            }
        }


        public void grid()
        {
            //DataTable dt_top = new DataTable();
            //dt_top = obj_MasterPort.GetPortDetails4GridPage();
            //if (dt_top.Rows.Count > 0)
            //{
            grd1.DataSource = new DataTable();
            grd1.DataBind();
            //}

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                btndelete.Visible = false;btndelete_id.Visible = false;
                // btndelete.Enabled = false;
                txtportname.Text = txtportname.Text.ToUpper().Replace(" ,",", ").Replace(",  ",", ");
                if (btnsave.ToolTip == "Save")
                {
                    // int_country = Convert.ToInt32(hdf_countryid.Value);
                    if (hdf_districtid.Value=="")
                    {
                        int_district = 0;
                    }else
                    {
                        int_district = Convert.ToInt32(hdf_districtid.Value);
                    }
                    if (hdf_stateid.Value=="")
                    {

                    }else
                    {
                        int_state = Convert.ToInt32(hdf_stateid.Value);
                    }
                    if (hdf_sectorid.Value=="")
                    {
                        hdf_sectorid.Value = "0";
                    }
                    int_country = Convert.ToInt32(hdf_countryid.Value);
                    obj_MasterPort.InsertPortDetails(txtportcode.Text.ToUpper(), txtportname.Text.ToUpper(), txtcountry.Text.ToUpper(), txtsector.Text.ToUpper(), int_state, int_district, txtstdcode.Text.ToUpper(), txtaircode.Text.ToUpper());
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 134, 1, int.Parse(Session["LoginBranchid"].ToString()), txtportname.Text);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('Port Inserted Successfully');", true);
                }
                else
                {
                    int_port = Convert.ToInt32(hdf_portid.Value);
                    if (int_port == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('Invalid Port Name');", true);
                        txtportname.Focus();
                        return;
                    }
                    if (hdf_districtid.Value == "")
                    {
                        int_district = 0;
                    }
                    else
                    {
                        int_district = Convert.ToInt32(hdf_districtid.Value);
                    }
                    if (hdf_stateid.Value == "")
                    {

                    }
                    else
                    {
                        int_state = Convert.ToInt32(hdf_stateid.Value);
                    }
                    if (hdf_sectorid.Value == "")
                    {
                        hdf_sectorid.Value = "0";
                    }
                    int_country = Convert.ToInt32(hdf_countryid.Value);
                    obj_MasterPort.UpdatePortDetails(int_port, txtportcode.Text.ToUpper(), txtportname.Text.ToUpper(), txtcountry.Text.ToUpper(), txtsector.Text.ToUpper(), int_state, int_district, txtstdcode.Text.ToUpper(), txtaircode.Text.ToUpper());
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 134, 2, int.Parse(Session["LoginBranchid"].ToString()), txtportname.Text);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('Port Updated Successfully');", true);
                }
                clear();
                btnsave.Text = "Save";

                btnsave.ToolTip = "Save";
                btnsave1.Attributes["class"] = "btn ico-save";

                // getgrid();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtdistrict_TextChanged(object sender, EventArgs e)
        {
            try
            {
                btndelete.Enabled = false;
                dt = obj_MasterPort.GetLikeDistrict(txtdistrict.Text.ToUpper());
                if (dt.Rows.Count > 0)
                {
                    if (hdf_districtid.Value != "")
                    {
                        txtdistrict.Text = dt.Rows[0]["districtname"].ToString();
                        hdf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                        txtstate.Text = dt.Rows[0]["statename"].ToString();
                        txtcountry.Text = dt.Rows[0]["countryname"].ToString();
                        txtsector.Text = dt.Rows[0]["sectorname"].ToString();
                        hdf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                        hdf_countryid.Value = dt.Rows[0]["countryid"].ToString();
                        hdf_sectorid.Value = dt.Rows[0]["sectorid"].ToString();
                        if(hdf_countryid.Value=="1102" || hdf_countryid.Value == "102")
                        {
                            txtcountry.Enabled = false;
                        }else
                        {
                            txtcountry.Enabled = true;
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('Enter Valid Distrcit');", true);
                    txtdistrict.Text = "";
                    txtdistrict.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txtstdcode.Focus();
        }
        private void clear()
        {
            txtportcode.Text = "";
            txtportname.Text = "";
          //  txtunloccode.Text = "";
            txtaircode.Text = "";
            txtdistrict.Text = "";
            txtstate.Text = "";
            txtcountry.Text = "";
            txtstdcode.Text = "";
            txtsector.Text = "";
            hdf_portid.Value = "";
            grid();
            
        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            btndelete.Visible = false;btndelete_id.Visible = false;
            // btndelete.Enabled = false;
            if (btnclose.ToolTip == "Back")
            {
                this.Response.End();
            }
            else
            {
                txt_Search.Text = "";
                txtportname.Focus();
                clear();
                btnclose.Text = "Back";


                btnclose.ToolTip = "Back";
                btnclose1.Attributes["class"] = "btn ico-back";

                signup.Visible = false;
            }
        }

        
        private void getgrid()
        {
            dt = obj_MasterPort.GetPortDetails4Grid();
            if (dt.Rows.Count > 0)
            {
                grd1.DataSource = dt;
                grd1.DataBind();
            }
            else
            {
                grd1.DataSource = null;
                grd1.DataBind();
            }
        }

        protected void btnview_Click(object sender, EventArgs e)
        {//btndelete.Visible = false;btndelete_id.Visible = false;
            //// btndelete.Enabled = false;
            //getgrid();
            //grd.Visible = true;
            //signup.Visible = true;
            try
            {

                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                str_RptName = "Masterport.rpt";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "MasterPort", str_Script, true);

                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 134, 3, int.Parse(Session["LoginBranchid"].ToString()), "VesselView");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void Excelfunforserver_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void pdffunforserver_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToPdf();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
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
            grd1.AllowPaging = false;
            getgrid();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            grd1.GridLines = GridLines.Both;
            grd1.HeaderStyle.Font.Bold = true;
            grd1.RenderControl(htmltextwrtter);
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
            grd1.AllowPaging = false;
            //  BindGrid();
            dt = obj_MasterPort.GetPortDetails4Grid();
            grd1.DataSource = dt;
            grd1.DataBind();
            signup.Visible = true;



            grd1.RenderControl(hw);
            grd1.HeaderRow.Style.Add("width", "5%");
            grd1.HeaderRow.Style.Add("font-size", "10px");
            grd1.Style.Add("text-decoration", "none");
            grd1.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            grd1.Style.Add("font-size", "8pt");
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

        protected void txtportname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                btndelete.Visible = false;btndelete_id.Visible = false;
                //btndelete.Enabled = false;
                btnsave.Enabled = true;
                btnclose.Text = "Close";


                btnclose.ToolTip = "Close";
                btnclose1.Attributes["class"] = "btn ico-cancel";

               // dt = obj_MasterPort.GetPortName();
                int port = Convert.ToInt32(obj_MasterPort.GetNPortid(txtportname.Text.ToUpper()));
                if (port!=0)
                {
                    //int_port = Convert.ToInt32(hdf_portid.Value.ToString());
                    hdf_portid.Value = port.ToString();
                    int_port=port;
                    dt = obj_MasterPort.GetPortDetails(int_port);

                    if (dt.Rows.Count > 0)
                    {
                        txtportcode.Text = dt.Rows[0]["portcode"].ToString();
                        if (txtportcode.Text == "null")
                        {
                            txtportcode.Text = "";
                        }


                        txtaircode.Text = dt.Rows[0]["airportcode"].ToString();
                        // txtportname.Text = dt.Rows[0]["portname"].ToString();
                        //txtdistrict.Text = dt.Rows[0]["districtname"].ToString();
                        //txtstate.Text = dt.Rows[0]["statename"].ToString();
                        //txtcountry.Text = dt.Rows[0]["countryname"].ToString();
                        //txtsector.Text = dt.Rows[0]["sectorname"].ToString();
                        txtstdcode.Text = dt.Rows[0]["stdcode"].ToString();
                        hdf_countryid.Value = dt.Rows[0]["countryid"].ToString();
                        hdf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                        hdf_portid.Value = dt.Rows[0]["portid"].ToString();
                        hdf_sectorid.Value = dt.Rows[0]["sectorid"].ToString();
                        hdf_stateid.Value = dt.Rows[0]["stateid"].ToString();
                        if (hdf_countryid.Value != "")
                        {
                            txtcountry.Text = obj_MasterPort.GetCountryname(Convert.ToInt32(hdf_countryid.Value));
                            txtsector.Text = obj_MasterPort.GetSectorName(txtcountry.Text);
                            if (hdf_countryid.Value == "1102"|| hdf_countryid.Value == "102")
                            {
                                txtcountry.Enabled = false;
                            }
                            else
                            {
                                txtcountry.Enabled = true;
                            }
                        } 
                        GetDistrict();
                        btnsave.Text = "Update";


                        btnsave.ToolTip = "Update";
                        btnsave1.Attributes["class"] = "btn ico-update";

                    }else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master District", "alertify.alert('Port Name Already Exists...');", true);
                       btnclose.Text = "Cancel";

                        btnclose.ToolTip = "Cancel";
                        btnclose1.Attributes["class"] = "btn ico-cancel";
                    }
                  //  hdf_portid.Value = dt.Rows[0]["portid"].ToString();
                    
                }
                if (port == 0)
                {
                     btnsave.Text = "Save";
                    btnsave.ToolTip = "Save";
                    btnsave1.Attributes["class"] = "btn ico-save";

                    txtcountry.Enabled = true;
                    return;
                }

               
             
               // txtunloccode.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txtportcode.Focus();
        }

        protected void GetDistrict()
        {
            if (hdf_districtid.Value != "")
            {
                int disid = Convert.ToInt32(hdf_districtid.Value);
                string district = obj_MasterPort.GetStateDistrictname(disid);
                dt = obj_MasterPort.GetLikeDistrict(district);
                if (dt.Rows.Count > 0)
                {
                    txtdistrict.Text = dt.Rows[0]["districtname"].ToString();
                    hdf_districtid.Value = dt.Rows[0]["districtid"].ToString();
                    txtstate.Text = dt.Rows[0]["statename"].ToString();
                    txtcountry.Text = dt.Rows[0]["countryname"].ToString();
                    txtsector.Text = dt.Rows[0]["sectorname"].ToString();
                }
            }


        }


        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd1.PageIndex = e.NewPageIndex;
            getgrid();
        }  

       

        protected void grd1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        grd1.PageIndex=e.NewPageIndex;
        grd1.DataSource = (DataTable)ViewState["data"];
        grd1.DataBind();
        }

        protected void txtcountry_TextChanged(object sender, EventArgs e)
        {
           /*  If Trim(txtCountry.Text) <> "" Then
            If lstport.SelectedIndex <> -1 Then
                txtCountry.Text = lstport.Text
                intcountryid = portobj.GetCountryid(txtCountry.Text)
                txtSector.Text = portobj.GetSectorName(txtCountry.Text)
                End If
        End If*/

            //DataAccess.Masters.MasterPort obj = new DataAccess.Masters.MasterPort();
            if (txtcountry.Text!="")
            {
                countryid = obj.GetCountryid(txtcountry.Text);
                txtsector.Text = obj.GetSectorName(txtcountry.Text);
            }
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
            Panel1.Visible = true;
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 134, "MSPort", txtportname.Text, txtportname.Text, "");  //"/Rate ID: " +
            if (txtportname.Text != "")
            {
                JobInput.Text = txtportname.Text;


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