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

namespace logix.Maintenance
{
    public partial class MasterVessel : System.Web.UI.Page
    {
        string VesNam;
        DataTable obj_dt = new DataTable();
        DataAccess.Masters.MasterVessel obj_main = new DataAccess.Masters.MasterVessel();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        int vesselid;
        Boolean blnexists;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        DataTable dt_com = new DataTable();
        int intvesselid;
        DataTable dtGet = new DataTable();
        Boolean bnrr;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_main.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
               




            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnClear);
            //pdf.ServerClick += new EventHandler(btnpdf_Click);
            //excel.ServerClick += new EventHandler(btnexcel_Click);
            btnDelete.Visible = false;btnDelete_id.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    Ctrl_List = txtvessel.ID + "~" + txtimocode.ID;
                    Msg_List = "Vessel Name~IMOCode";
                    Dtype_List = "string~string";
                    btnSave.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    btnDelete.Click += btnDelete_Click;
                    btnDelete.OnClientClick = @"return getConfirmationValue();";
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btnSave, null, null);
                    //btnSave.Enabled = false;
                    btnDelete.Visible = false;btnDelete_id.Visible = false;
                    //  btnDelete.Enabled = false;
                  //
                  btnClear.Text = "Clear";
                   btnSave.Text = "Save";

                    btnSave.ToolTip = "Save";
                    btnSave1.Attributes["class"] = "btn ico-save";
                    hdn_Vesselid.Value = "";
                    txtvessel.Focus();
                    Emopty_grd();
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

        protected void Emopty_grd()
        {
            GrdVessel.DataSource = new DataTable();
            GrdVessel.DataBind();
        }


        [WebMethod]
        public static List<string> GetVessel(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterVessel obj_vsalname = new DataAccess.Masters.MasterVessel();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_vsalname.GetDataBase(Ccode);
            DataTable dt_vsalname = new DataTable();
            dt_vsalname = obj_vsalname.GetLikeVessel(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(dt_vsalname, "vesselname", "vesselid");
            return List_Result;
        }



        [WebMethod]
        public static void GetEmpName(string Prefix)
        {

            DataTable obj_dtEmp = new DataTable();

            if (Prefix.Length > 0)
            {
                DataAccess.Masters.MasterVessel obj_main = new DataAccess.Masters.MasterVessel();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                obj_main.GetDataBase(Ccode);
                DataTable obj_dt = new DataTable();
                obj_dt = obj_main.GetLikeVessel(Prefix.ToUpper());

                obj_dtEmp.Columns.Add("vesselname");
                obj_dtEmp.Columns.Add("imocode");
                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["vesselname"] = obj_dt.Rows[i][0].ToString();
                    dr["imocode"] = obj_dt.Rows[i][2].ToString();


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
                    ViewState["Vessel"] = obj_dtEmp;
                    GrdVessel.DataSource = obj_dtEmp;
                    GrdVessel.DataBind();
                    txt_Search.Focus();

                }
               //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
               
            }
            else
            {
                GrdVessel.DataSource = null;
                GrdVessel.DataBind();
            }
        }


        protected void btnSave_Click1(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Visible = false;btnDelete_id.Visible = false; btnDelete_id.Visible = false;
                btnSave.Enabled = true;
                //btnDelete.Enabled = false;
                 btnClear.Text = "Clear";

                btnClear.ToolTip = "Clear";
                btnClear1.Attributes["class"] = "btn ico-clear";

                if(txtvessel.Text=="")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Vessel", "alertify.alert('Vessel Name cannot be Blank');", true);
                    txtvessel.Focus();                   
                    return;
                }

                if (btnSave.ToolTip == "Save")
                {
                    if (hdn_Vesselid.Value == "")
                    {
                       // checkval();
                        obj_main.InsertVessel(txtvessel.Text.ToUpper(), txtimocode.Text.ToUpper());
                        //vesselid = Convert.ToInt32(hdn_Vesselid.Value.ToString());
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 135, 1, int.Parse(Session["LoginBranchid"].ToString()), txtvessel.Text.ToUpper() + "/Sav");
                        ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "MasterVessel", "alertify.alert('Vessel Details has been Inserted...');", true);
                        Clear();
                       btnSave.Text = "Save";
                        btnSave.ToolTip = "Save";
                        btnSave1.Attributes["class"] = "btn ico-save";
                        //gridfill();
                        //drop_box.Visible = false;
                    }
                }
                else
                {
                    if (btnSave.ToolTip == "Update")
                    {
                        if (hdn_Vesselid.Value != "")
                        {

                            vesselid = Convert.ToInt32(hdn_Vesselid.Value.ToString());
                            // obj_main.SPUpdVesselvalues(vesselid, txtvessel.Text.ToUpper(), txtimocode.Text);InsertVessel
                            obj_main.UpdateVessel(vesselid, txtvessel.Text.ToUpper(), txtimocode.Text.ToUpper());
                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 135, 2, int.Parse(Session["LoginBranchid"].ToString()), txtvessel.Text.ToUpper() + "/Upd");
                            ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "MasterVessel", "alertify.alert('Vessel Details has been Updated...');", true);
                            Clear();
                            //gridfill();
                            btnSave.Text = "Save";

                            btnSave.ToolTip = "Save";
                            btnSave1.Attributes["class"] = "btn ico-save";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            btn_search.Focus();
        }

        protected void btnview_Click1(object sender, EventArgs e)
        {
            try
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                str_RptName = "Mastervessel.rpt";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "MasterVessel", str_Script, true);

                //btnDelete.Visible = false;btnDelete_id.Visible = false;
                //GrdVessel.Visible = true;
                //drop_box.Visible = true;
                //btnClear.Text = "Clear";
                //// btnDelete.Enabled = false;
                //empty_grid();
                //gridfill();
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 135, 3, int.Parse(Session["LoginBranchid"].ToString()), "VesselView");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void gridfill()
        {

            DataTable dt1 = new DataTable();
            dt1 = obj_main.SPVesselView();

            if (dt1.Rows.Count > 0)
            {
                GrdVessel.DataSource = dt1;
                GrdVessel.DataBind();
            }

            //drop_box.Visible = true;
        }

        private void empty_grid()
        {
            DataTable dt_emp = new DataTable();
            GrdVessel.DataSource = dt_emp;
            GrdVessel.DataBind();

        }

       

        private void GridTopRow()
        {
            DataTable dt_top = new DataTable();
            dt_top = obj_main.RetriveTopVessel();
            if (dt_top.Rows.Count > 0)
            {
                GrdVessel.DataSource = dt_top;
                GrdVessel.DataBind();
            }

        }

        private void ChkIMOCode()
        {
            dt_com = obj_main.GETCheckIMOCode(txtimocode.Text.Trim());
            if (dt_com.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Vessel", "alertify.alert('IMOCode Already Exists');", true);
                txtimocode.Text = "";
            }

        }

        //private void ChkVesselCode()
        //{
        //    dt_com = obj_main.GETCheckVesselCode(txtvcode.Text.Trim());
        //    if (dt_com.Rows.Count > 0)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Vessel", "alertify.alert('VesselCode Already Exists');", true);
        //        txtvcode.Text = "";
        //    }

        //}

        protected void btnClear_Click1(object sender, EventArgs e)
        {
            btnDelete.Visible = false;btnDelete_id.Visible = false;
            //  btnDelete.Enabled = false;
            if (btnClear.ToolTip == "Back")
            {
                if (Session["Home"] != null)
                {
                    if (Session["Home"].ToString() == "maintahome")
                    {
                        Response.Redirect("../Home/MaintenanceHome.aspx");
                    }
                }

                else
                {
                    this.Response.End();
                }
            }
            else
            {
                Clear();
                hdn_Vesselid.Value = "";
               btnClear.Text = "Back";
                btnSave.Text = "Save";



                btnClear.ToolTip = "Back";
                btnClear1.Attributes["class"] = "btn ico-back";
                btnSave.ToolTip = "Save";
                btnSave1.Attributes["class"] = "btn ico-save";
                Emopty_grd();
                txt_Search.Text = "";
                btnSave.Enabled = true;
                txtvessel.Focus();
                // btnDelete.Enabled = false;
                btnDelete.Visible = false;btnDelete_id.Visible = false;
                drop_box.Visible = false;
                //GrdVessel.Visible = false;
                
            }


        }


        private void Clear()
        {
            txtvessel.Text = "";
            txtimocode.Text = "";
            // txtvcode.Text = "";
           
           
        }


        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void txtvessel_TextChanged(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Visible = false;btnDelete_id.Visible = false;
                btnSave.Enabled = true;
                //  btnDelete.Enabled = false;
                btnClear.Text = "Clear";


                btnClear.ToolTip = "Clear";
                btnClear1.Attributes["class"] = "btn ico-clear";

                if (txtvessel.Text != "")
                {
                    int vesselid = obj_main.GetVesselid(txtvessel.Text.ToUpper());
                    if(vesselid !=0)
                    {
                        hdn_Vesselid.Value =vesselid.ToString();
                        vesselid = Convert.ToInt32(hdn_Vesselid.Value.ToString());
                        dt = obj_main.GetVesselDetails(vesselid);
                        if (dt.Rows.Count > 0)
                        {
                           
                            txtimocode.Text = dt.Rows[0]["imocode"].ToString();
                            //  txtvcode.Text = dt.Rows[0]["vesselcode"].ToString();
                            if (txtimocode.Text!="")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Vessel", "alertify.alert('VesselName Already Exists');", true);
                            }
                            
                        }
                        btnSave.Text = "Update";




                        btnSave.ToolTip = "Update";
                        btnSave1.Attributes["class"] = "btn ico-update";
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void pdf_fun()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Vessel.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GrdVessel.AllowPaging = false;
            //sectorid = Convert.ToInt32(hdn_id.Value.ToString());
            dt_com = obj_main.SPVesselView();
            GrdVessel.DataSource = dt_com;
            GrdVessel.DataBind();
            drop_box.Visible = true;

            GrdVessel.RenderControl(hw);
            GrdVessel.HeaderRow.Style.Add("width", "5%");
            GrdVessel.HeaderRow.Style.Add("font-size", "10px");
            GrdVessel.Style.Add("text-decoration", "none");
            GrdVessel.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            GrdVessel.Style.Add("font-size", "8pt");
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
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Vessel.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GrdVessel.AllowPaging = false;

                dt_com = obj_main.SPVesselView();
                GrdVessel.DataSource = dt_com;
                GrdVessel.DataBind();
                drop_box.Visible = true;
                // this.BindGrid();

                //  grdstate.HeaderRow.BackColor = Color.WHITE;
                foreach (TableCell cell in GrdVessel.HeaderRow.Cells)
                {
                    cell.BackColor = GrdVessel.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GrdVessel.Rows)
                {
                    //  row.BackColor = Color
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GrdVessel.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GrdVessel.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }
                GrdVessel.RenderControl(hw);
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
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

        protected void GrdVessel_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GrdVessel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdVessel.PageIndex = e.NewPageIndex;
            gridfill();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            bool type = false;

            if (hfWasConfirmed.Value == "true")
            {
                if (hdn_Vesselid.Value != "")
                {
                    obj_main.GETDeleteVessel(Convert.ToInt32(hdn_Vesselid.Value));
                    ScriptManager.RegisterStartupScript(btnDelete, typeof(System.Web.UI.WebControls.Button), "Master Vessel", "alertify.alert('Vessel Deleted Successfully...');", true);
                    Clear();
                }
            }
        }

        protected void txtimocode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ChkIMOCode();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void GrdVessel_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GrdVessel.PageIndex = e.NewPageIndex;
            GrdVessel.DataSource = (DataTable)ViewState["Vessel"];
            GrdVessel.DataBind();
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

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 135, "MSVessel", txtvessel.Text, txtvessel.Text, "");  //"/Rate ID: " +
            if (txtvessel.Text != "")
            {
                JobInput.Text = txtvessel.Text;


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
        //protected void txt_Search_TextChanged(object sender, EventArgs e)
        //{
        //    blnexists = obj_main.CheckVesselExist(txtvessel.Text);
        //    if (blnexists == true)
        //    {
        //        intvesselid = obj_main.GetVesselid(txtvessel.Text);
        //        txtvessel.Text = obj_main.GetVesselname(intvesselid);

        //        dtGet = obj_main.GetVesselDetails(intvesselid);
        //        if (dtGet.Rows.Count > 0)
        //        {
        //            txtvessel.Text = dtGet.Rows[0]["vesselname"].ToString();
        //            txtimocode.Text = dtGet.Rows[0]["imocode"].ToString();
        //            btnClear.Text = "Clear";
        //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Vessel", "alertify.alert('Details Already Exists');", true);
        //            btnSave.Text = "Update";
        //        }
        //    }
        //}

        //protected void txtvcode_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ChkVesselCode();
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }     
        //}


    }
}