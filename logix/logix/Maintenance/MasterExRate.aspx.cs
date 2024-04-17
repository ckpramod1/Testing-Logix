using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;
using System.Reflection;
using System.Web.Services.Description;


namespace logix.Maintenance
{
    public partial class MasterExRate : System.Web.UI.Page
    {


        DataAccess.Masters.MasterExRate exrateshow = new DataAccess.Masters.MasterExRate();
        DataTable dtshow = new DataTable();
        string gdcurrency;
        string gdtextOs;
        string typeRC;
        string oldlocal, oldos;


        DataAccess.LogDetails Log_Obj = new DataAccess.LogDetails();
        bool blnerr = false;
        protected string DBCS;

        string username = "";
        string password = "";

        string ip = "";
        string dbname = "";

        DataAccess.Masters.MasterExRate obj_exrate = new DataAccess.Masters.MasterExRate();
        DataAccess.Masters.MasterCharges obi_charges = new DataAccess.Masters.MasterCharges();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        string ddltype;
        DataTable dt_com = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);
            exdate.Text = DateTime.Now.ToString("dd/MM/yyyy");


            // exdate.Text=DateTime.Parse(Utility.fn_ConvertDate(exdate.Text)));

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_exrate.GetDataBase(Ccode);
                obi_charges.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                Log_Obj.GetDataBase(Ccode);
                exrateshow.GetDataBase(Ccode);




            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnClear);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(GridExrate);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(GrdExrateFile);
            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(GrdExrateFile);

            //pdf.ServerClick += new EventHandler(btnpdf_Click);
            //excel.ServerClick += new EventHandler(btnexcel_Click);
            txtDate.Text = Utility.fn_ConvertDate(Log_Obj.GetDate().ToString());// DateTime.Today.ToString("dd/MM/yyyy");
            btnDelete.Visible = false;btnDelete_id.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    txt_exdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    empty_grid();
                    txtDate.Enabled = false;
                    //btnDelete.Enabled = false;
                    btnDelete.Visible = false;btnDelete_id.Visible = false;
                       btnSave.Text = "Save";
                      btnClear.Text = "Back";
                    droptype.SelectedIndex = 1;
                    btnSave.ToolTip = "Save";
                    btnSave1.Attributes["class"] = "btn ico-save";

                    btnClear.ToolTip = "Back";
                    btnClear1.Attributes["class"] = "btn ico-back";

                    //btnDelete.Visible = false;btnDelete_id.Visible = false;
                    txtcurrency.Focus();
                    TopRowDisplay();
                    GetExRate();
                    Grdchangeratefill();

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
                ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
            }


        }


        public void GetExRate()
        {


            //  DateTime.Parse(Utility.fn_ConvertDatetime(txt_venDate.Text).ToString())

            //DateTime.ParseExact(exdate.Text,"dd-mm-yyyy",CultureInfo)
            GridExrate.Visible = true;
            dtshow = exrateshow.ShowExRate(DateTime.Parse(Utility.fn_ConvertDate(exdate.Text).ToString()), Convert.ToInt32(Session["LoginDivisionId"]));
            GridExrate.DataSource = dtshow;
            GridExrate.DataBind();

            //  dtshow = exrateshow.ShowExRate(Convert.ToDateTime(Utility.fn_ConvertDate(exdate.Text)));
            //  Convert.ToDateTime(Utility.fn_ConvertDate((exdate.Text))

            //   dtshow = exrateshow.ShowExRate(Convert.ToDateTime(exdate.Text));



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
        public static List<string> GetCurrency(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterExRate obj_curr = new DataAccess.Masters.MasterExRate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_curr.GetDataBase(Ccode);
            DataTable dt_curr = new DataTable();
            dt_curr = obj_curr.GetCurrencyValue(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(prefix.ToUpper(), dt_curr, "excurr");

            return List_Result;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = true;
                // btnDelete.Enabled = false;
                btnDelete.Visible = false;btnDelete_id.Visible = false;
                string extype;
                string type;

                if (btnSave.ToolTip == "Save")
                {
                    if (droptype.SelectedIndex != 0)
                    {
                        extype = Convert.ToString(droptype.SelectedItem.Text.ToString());
                        obj_exrate.GetInsertExRate(extype, txtcurrency.Text.ToUpper(), Convert.ToSingle(txt_ratelocal.Text), Convert.ToSingle(txtovers.Text),Convert.ToInt32(Session["LoginDivisionId"]));

                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 255, 1, int.Parse(Session["LoginBranchid"].ToString()), txtDate.Text + "/" + txtcurrency.Text);

                        ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "MasterExchangeRate", "alertify.alert(' Details has Saved...');", true);
                        Clear();
                        //btnSave.Text = "Update";
                        // Grdfill();
                        TopRowDisplay();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "MasterExchangeRate", "alertify.alert('Select Exchange Rate Type ');", true);

                    }
                }
                else
                {
                    if (txtDate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "MasterExchangeRate", "alertify.alert('Choose Date.....');", true);
                    }

                    else if (btnSave.ToolTip == "Update")
                    {
                        if (droptype.SelectedIndex != 0)
                        {

                            //string date = Convert.ToDateTime(txtDate.Text.Trim()).ToString();
                            extype = Convert.ToString(droptype.SelectedItem.Text.ToString());
                            obj_exrate.GetUpdExcRateValues(extype, txtcurrency.Text.ToUpper(), Convert.ToSingle(txt_ratelocal.Text), Convert.ToSingle(txtovers.Text), Convert.ToDateTime(Utility.fn_ConvertDate(txtDate.Text)), Convert.ToInt32(Session["LoginDivisionId"]));
                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 255, 2, int.Parse(Session["LoginBranchid"].ToString()), txtDate.Text + "/" + txtcurrency.Text);
                            ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "MasterExchangeRate", "alertify.alert(' Details has Updated...');", true);
                            Clear();
                            txtDate.Enabled = true;
                            //Grdfill();
                            TopRowDisplay();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "MasterExchangeRate", "alertify.alert('Select Exchange Rate Type ');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        protected void btnview_Click(object sender, EventArgs e)
        {
            try
            {
                //drop_box.Visible = true;
                ////  btnDelete.Enabled = false;
                //btnDelete.Visible = false;btnDelete_id.Visible = false;
                ////empty_grid();
                //Grdfill();
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                str_RptName = "MasterExRate.rpt";
                str_Script = "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "MasterExrate", str_Script, true);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //btnDelete.Enabled = false;
            btnDelete.Visible = false;btnDelete_id.Visible = false;
            if (btnClear.ToolTip == "Cancel")
            {
                txtcurrency.Focus();
                Clear();
                //TopRowDisplay();
                   btnSave.Text = "Save";
                 btnClear.Text = "Back";

                btnSave.ToolTip = "Save";
                btnSave1.Attributes["class"] = "btn ico-save";
                btnClear.ToolTip = "Back";
                btnClear1.Attributes["class"] = "btn ico-back";

                btnSave.Enabled = true;
                // btnDelete.Enabled = false;
                //GrdExrate.Visible = false;
                drop_box.Visible = false;
                txtDate.Enabled = false;
                //droptype.SelectedItem.Text = "COST";
            }
            else if (btnClear.ToolTip == "Back")
            {
                Clear();
                this.Response.End();
            }
        }

        private void Grdfill()
        {
            //GrdExrate.Visible = true;



            DataTable dt1 = new DataTable();
            dt1 = obj_exrate.GetExRateView(Convert.ToInt32(Session["LoginDivisionId"]));

            if (dt1.Rows.Count > 0)
            {
                //GrdExrate.DataSource = dt1;
                //GrdExrate.DataBind();
            }

            btnClear.Text = "Cancel";



            btnClear.ToolTip = "Cancel";
            btnClear1.Attributes["class"] = "btn ico-cancel";

        }

        private void empty_grid()
        {
            DataTable dt_emp = new DataTable();
            //GrdExrate.DataSource = dt_emp;
            //GrdExrate.DataBind();
        }

        private void TopRowDisplay()
        {
            DataTable dt_top = new DataTable();
            //  dt_top = obj_exrate.RetriveTopExRateVal();
            if (dt_top.Rows.Count > 0)
            {
                //GrdExrate.DataSource = dt_top;
                //GrdExrate.DataBind();
            }

        }

        private void Clear()
        {
            txt_ratelocal.Text = "";
            txtcurrency.Text = "";
            txtovers.Text = "";
            txtDate.Text = "";
               btnSave.Text = "Save";

            btnSave.ToolTip = "Save";
            btnSave1.Attributes["class"] = "btn ico-save";


            //droptype.SelectedIndex =0;
            droptype.SelectedIndex = 1;
        }


        protected void txtcurrency_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string StrExType;
                string strDate;
                string strDate1;
                DataTable dt = new DataTable();
                btnSave.Enabled = true;
                  btnClear.Text = "Cancel";

                btnClear.ToolTip = "Cancel";
                btnClear1.Attributes["class"] = "btn ico-cancel";
                btnDelete.Visible = false;btnDelete_id.Visible = false;
                if (string.IsNullOrEmpty(droptype.SelectedItem.Text.ToString()))
                {
                    StrExType = "";
                }
                else if (droptype.SelectedItem.Text == "COST")
                {
                    StrExType = "C";
                }
                else if (droptype.SelectedItem.Text == "REVENUE")
                {
                    StrExType = "R";
                }

                if (!string.IsNullOrEmpty(txtcurrency.Text.ToUpper()))
                {

                    txt_ratelocal.Text = "";
                    txtovers.Text = "";
                    txtDate.Enabled = true;
                    strDate = Utility.fn_ConvertDateWithTime(obj_exrate.GetDate().ToString());
                    strDate1 = Utility.fn_ConvertDate(strDate);
                    int currId = Convert.ToInt32(obi_charges.GetCurrID(txtcurrency.Text.ToUpper()));
                    // dt = obj_exrate.RetrieveExRateDetails(Convert.ToDateTime(strDate1), txtcurrency.Text.ToUpper(), Convert.ToString(droptype.SelectedItem.Text.ToString()));
                    if (currId != 0)
                    {
                        dt = obj_exrate.RetrieveExRateDetails(Convert.ToDateTime(strDate1), txtcurrency.Text.ToUpper(), Convert.ToString(droptype.SelectedItem.Text.ToString()), Convert.ToInt32(Session["LoginDivisionId"]));
                        if (dt.Rows.Count > 0)
                        {
                            txt_ratelocal.Text = dt.Rows[0][0].ToString();
                            txtovers.Text = dt.Rows[0][1].ToString();
                            txtDate.Text = Utility.fn_ConvertDate(strDate1);
                            ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Exchange Rate Exists For This Currency')", true);
                                btnSave.Text = "Update";

                            btnSave.ToolTip = "Update";
                            btnSave1.Attributes["class"] = "btn ico-update";

                            txt_ratelocal.Focus();
                        }
                        else
                        {
                            txt_ratelocal.Focus();
                            return;
                        }

                    }
                    else if (currId == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Invalied Currency)", true);
                        txtcurrency.Focus();
                        txtcurrency.Text = "";
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(btnSave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        //private void pdf_fun()
        //{
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", "attachment;filename=ExChangeRate.pdf");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);

        //    GrdExrate.AllowPaging = false;
        //    // this.BindGrid();

        //    dt_com = obj_exrate.GetExRateView();
        //    GrdExrate.DataSource = dt_com;
        //    GrdExrate.DataBind();

        //    GrdExrate.RenderControl(hw);
        //    GrdExrate.HeaderRow.Style.Add("width", "5%");
        //    GrdExrate.HeaderRow.Style.Add("font-size", "10px");
        //    GrdExrate.Style.Add("text-decoration", "none");
        //    GrdExrate.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        //    GrdExrate.Style.Add("font-size", "8pt");
        //    StringReader sr = new StringReader(sw.ToString());
        //    Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
        //    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    pdfDoc.Open();
        //    htmlparser.Parse(sr);
        //    pdfDoc.Close();
        //    Response.Write(pdfDoc);
        //    Response.End();

        //}

        //private void excel_fun()
        //{
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment;filename=ExChangeRate.xls");
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-excel";
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        HtmlTextWriter hw = new HtmlTextWriter(sw);

        //        //To Export all pages
        //        GrdExrate.AllowPaging = false;
        //        // this.BindGrid();

        //        dt_com = obj_exrate.GetExRateView();
        //        GrdExrate.DataSource = dt_com;
        //        GrdExrate.DataBind();
        //        drop_box.Visible = true;
        //        //  grdstate.HeaderRow.BackColor = Color.WHITE;
        //        foreach (TableCell cell in GrdExrate.HeaderRow.Cells)
        //        {
        //            cell.BackColor = GrdExrate.HeaderStyle.BackColor;
        //        }
        //        foreach (GridViewRow row in GrdExrate.Rows)
        //        {
        //            //  row.BackColor = Color
        //            foreach (TableCell cell in row.Cells)
        //            {
        //                if (row.RowIndex % 2 == 0)
        //                {
        //                    cell.BackColor = GrdExrate.AlternatingRowStyle.BackColor;
        //                }
        //                else
        //                {
        //                    cell.BackColor = GrdExrate.RowStyle.BackColor;
        //                }
        //                cell.CssClass = "textmode";
        //            }
        //        }
        //        GrdExrate.RenderControl(hw);
        //        string style = @"<style> .textmode { } </style>";
        //        Response.Write(style);
        //        Response.Output.Write(sw.ToString());
        //        Response.Flush();
        //        Response.End();
        //    }
        //}

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        public void btnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                //pdf_fun();
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
                //excel_fun();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void droptype_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
              btnClear.Text = "Cancel";


            btnClear.ToolTip = "Cancel";
            btnClear1.Attributes["class"] = "btn ico-cancel";
            btnDelete.Visible = false;btnDelete_id.Visible = false;
        }


        protected void txtovers_TextChanged(object sender, EventArgs e)
        {
            btnClear.Text = "Cancel";



            btnClear.ToolTip = "Cancel";
            btnClear1.Attributes["class"] = "btn ico-cancel";

        }

        protected void txt_ratelocal_TextChanged(object sender, EventArgs e)
        {
             btnClear.Text = "Cancel";
            btnClear.ToolTip = "Cancel";
            btnClear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            btnClear.Text = "Cancel";
            btnClear.ToolTip = "Cancel";
            btnClear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //GrdExrate.PageIndex = e.NewPageIndex;
            //Grdfill(); 

        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GrdExrate_SelectedIndexChanged(object sender, EventArgs e)
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
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 255, "MSPort", txtcurrency.Text, txtcurrency.Text, "");  //"/Rate ID: " +
            if (txtcurrency.Text != "")
            {
                JobInput.Text = txtcurrency.Text;


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

        protected void exdate_TextChanged(object sender, EventArgs e)
        {

            GetExRate();

        }

        protected void btn_updrate_Click(object sender, EventArgs e)
        {

            DataTable dtup = new DataTable();
            dtshow = exrateshow.ShowExRate(DateTime.Parse(Utility.fn_ConvertDate(exdate.Text).ToString()), Convert.ToInt32(Session["LoginDivisionId"]));




            for (int i = 0; i <= GridExrate.Rows.Count - 1; i++)
            {


                //  oldlocal = oldlocal + "," + Loc_rate.Text;
                //oldos = oldos + "," + OS_ExRate.Text;


                //  gdcurrency = txtDate.Text;
                // Utility.fn_ConvertDate(Log_Obj.GetDate().ToString());
                gdcurrency = GridExrate.Rows[i].Cells[3].Text;

                TextBox Loc_rate = (TextBox)GridExrate.Rows[i].FindControl("Txt_LocalExRate");
                Label typcr = (Label)GridExrate.Rows[i].FindControl("typecr");

                Label oldloc = (Label)GridExrate.Rows[i].FindControl("old_LocalExRate");

                Label oldso = (Label)GridExrate.Rows[i].FindControl("old_OSExRate");


                typeRC = typcr.Text;
                TextBox OS_ExRate = (TextBox)GridExrate.Rows[i].FindControl("Txt_OSExRate");
                if (Loc_rate.Text == "")
                {
                    Loc_rate.Text = "0";
                }

                if (OS_ExRate.Text == "")
                {
                    OS_ExRate.Text = "0";
                }

                exrateshow.updlocalosrate(Convert.ToDouble(Loc_rate.Text), Convert.ToDouble(OS_ExRate.Text), DateTime.Parse(Utility.fn_ConvertDate(txtDate.Text).ToString()), gdcurrency, typeRC, Convert.ToInt32(Session["LoginDivisionId"]));
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 255, 2, int.Parse(Session["LoginBranchid"].ToString()), typeRC + "-" + txtDate.Text + "-" + gdcurrency + "-" + Loc_rate.Text + "-" + OS_ExRate.Text + "-" + oldloc.Text + "-" + oldso.Text);


            }


            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Exrates Updated');", true);


            //   gdtextLoc = gdtextLoc   + "," + Loc_rate.Text;


            // gdtextOs = GridExrate.Rows[i].Cells[3].Text;
            // gdtextOs = OS_ExRate.Text;


            //double.Parse
        }

        protected void GridExrate_PreRender(object sender, EventArgs e)
        {
            GridExrate.UseAccessibleHeader = true;
            GridExrate.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void Btn_get_Click(object sender, EventArgs e)
        {
            DataTable dtts = new DataTable();
            dtts = exrateshow.GetExrateFiledetails(Convert.ToDateTime(Utility.fn_ConvertDate(txt_exdate.Text)));
            if (dtts.Rows.Count > 0)
            {
                GrdExrateFile.DataSource = dtts;
                GrdExrateFile.DataBind();
            }
            else
            {
                GrdExrateFile.DataSource = dtts;
                GrdExrateFile.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('No Data Found');", true);
                

            }
        }

        public void Grdchangeratefill()
        {
            DataTable dtts = new DataTable();
            dtts = exrateshow.SpGetExrateFile();
            if (dtts.Rows.Count > 0)
            {
                GrdExrateFile.DataSource = dtts;
                GrdExrateFile.DataBind();
            }
            else
            {
                GrdExrateFile.DataSource = dtts;
                GrdExrateFile.DataBind();
            }
        }

        protected void btn_AddUploaded_Click(object sender, EventArgs e)
        {
            string c;
            if (!(ExrateUpload.HasFile))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('File DocPath cannot be Blank');", true);
                ExrateUpload.Focus();
                return;
            }
            DataTable dts = new DataTable();
            dts = exrateshow.SpGetExrateFile();
            if (dts.Rows.Count > 0)
            {
                int count = Convert.ToInt16(dts.Rows.Count);
                int i = count + 1;
                hid_ExrateId.Value = Convert.ToString(i);
            }
            else
            {
                hid_ExrateId.Value = "0";
            }
            string idfilename = string.Empty;

            ExrateUpload.SaveAs(Server.MapPath("~/UploadDocument/ExRateFile/" + hid_ExrateId.Value + "-" + "Exrate" + "-" + ExrateUpload.FileName));
            c = (Server.MapPath("~/UploadDocument/ExRateFile/") + hid_ExrateId.Value + "-" + "Exrate" + "-" + Path.GetFileName(ExrateUpload.FileName));
            idfilename = hid_ExrateId.Value + "-" + "Exrate" + "-" + Path.GetFileName(ExrateUpload.FileName);
            IdProoffileupload(ExrateUpload.FileName, c);
            DataTable dtss = new DataTable();
            DateTime exdate = new DateTime();
            exdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_exdate.Text));
            dtss = exrateshow.ExrateInsFileupload(exdate, idfilename);
            Grdchangeratefill();

            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('EXChangeRate Document Uploaded Successfully' );", true);
            return;

        }

        private void IdProoffileupload(string filenames, string path)
        {
            string a, b;
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode == "CH01")
            {
                string DBName = "SL";
                using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                {
                    DBCS = reader.ReadLine();
                }
            }
            else if (Ccode == "CH02")
            {
                string DBName = "MarinAir";
                using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                {
                    DBCS = reader.ReadLine();
                }
            }
            if (Ccode == "CH03")
            {
                string DBName = "OceanKare";
                using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                {
                    DBCS = reader.ReadLine();
                }
            }
            ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
            dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
            //username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
            //password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();

            // added on 25Mar2023 
            username = "vmadmin";
            password = "VMWeb20Mar@)@#";
            b = Path.GetFileName(filenames);
            a = "ftp://20.235.30.214/SL/ExRateFile/" + hid_ExrateId.Value + "-" + "Exrate" + "-" + filenames;
            // FtpWebRequest req = (FtpWebRequest)(WebRequest.Create(a));
            FtpWebRequest req = (FtpWebRequest)(WebRequest.Create(a));
            req.Credentials = new NetworkCredential(username, password);
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Proxy = null;
            byte[] file = System.IO.File.ReadAllBytes(path);
            System.IO.Stream str = req.GetRequestStream();
            str.Write(file, 0, file.Length);
            str.Close();
            str.Dispose();
        }

        protected void Imgsb_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dtSB = new DataTable();
            DataTable dtgrid1 = new DataTable();
            ImageButton lb = (ImageButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;

            if (GrdExrateFile.Rows.Count > 0)
            {
                int rowID = gvRow.RowIndex;
                hid_ExrateGrdid.Value = GrdExrateFile.Rows[rowID].Cells[2].Text;
                Hid_ExrateFilename.Value = GrdExrateFile.Rows[rowID].Cells[1].Text;
            }


            // hid_crid.Value = Gridcreditreq.SelectedRow.Cells[8].Text;
            DataTable dtgrid = new DataTable();
            if (hid_ExrateGrdid.Value != "")
            {
                //dtgrid = obj_creditapp.delgridMasterCreditApp4Prod(groupid, Convert.ToInt32(hid_crid.Value));
                //dtgrid1 = obj_creditapp.selgridMasterCreditApp4Prod(groupid, Convert.ToInt32(Session["LoginDivisionId"]));

                //ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "DataFound", "alertify.alert('Product Details Deleted');", true);

            }

        }

        protected void GrdExrateFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GrdExrateFile.SelectedRow.RowIndex;
            string filenameExrate = "";
            if (GrdExrateFile.Rows.Count > 0)
            {
                filenameExrate = GrdExrateFile.Rows[index].Cells[1].Text;
                DataTable dt = new DataTable();
                dt = exrateshow.GetExrateFileUploadname(filenameExrate);
                if (dt.Rows.Count > 0)
                {
                    string hidExrateid = dt.Rows[0]["MASTEREXRATEFILEUPLOADID"].ToString();
                    if (hidExrateid != "")
                    {
                        string Test = "2";
                        ScriptManager.RegisterStartupScript(GrdExrateFile, typeof(GridView), "Download", "window.open('../Download.aspx?ExchangeFile=" + filenameExrate + "&Test=" + Test + "');", true);

                    }
                }
            }
        }

        protected void ftpdeleted(string filename)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://20.235.30.214/SL/ExRateFile/" + filename);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                //request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
                request.Credentials = new NetworkCredential(Hid_ServerUsername.Value, Hid_ServerPWD.Value);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    //  return response.StatusDescription;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        protected void GrdExrateFile_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                ImageButton Img_delete = (ImageButton)e.CommandSource;
                GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
                DataTable obj_dt = new DataTable();
                string filename = "";
                int Index = grd.RowIndex;
                if (!string.IsNullOrWhiteSpace(GrdExrateFile.Rows[grd.RowIndex].Cells[1].Text))
                {
                    filename = GrdExrateFile.Rows[grd.RowIndex].Cells[1].Text;
                    DataTable dt = new DataTable();
                    dt = exrateshow.GetExrateFileUploadname(filename);
                    if (dt.Rows.Count > 0)
                    {
                        string hidExrateid = dt.Rows[0]["MASTEREXRATEFILEUPLOADID"].ToString();
                        exrateshow.ExrateInsFileupload(filename, Convert.ToInt32(hidExrateid));
                        Grdchangeratefill();
                        ftpdeleted(filename);                       
                        ScriptManager.RegisterClientScriptBlock(GrdExrateFile, typeof(GridView), "logix", "alertify.alert('File has been deleted');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('No File To deleted');", true);
                    return;
                }
            }
        }

        protected void GrdExrateFile_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdbudget, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdExrateFile, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GrdExrateFile_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        //protected void GridExrate_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        //{
        //    //  TextBox Loc_ratenew = ((TextBox)GridExrate.Rows[e.RowIndex].FindControl("Txt_LocalExRate")).Text;
        //    GridViewRow row = (GridViewRow)GridExrate.Rows[e];
        //    int id = Int32.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        //    string tname = ((TextBox)row.Cells[0].Controls[0]).Text;
        //    string tques = ((TextBox)row.Cells[1].Controls[0]).Text;
        //}                            
    }
}