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
using System.Globalization;
using System.Drawing;
using System.Text;
namespace logix.MIS
{
    public partial class SalesPerson : System.Web.UI.Page
    {
        string Ctrl_List;
        string Msg_List;
        string Data_List;
        int int_branchid;
        int int_salesid;
        string str_trantype;
        string str_fromdate;
        string str_todate;
        string str_filename;
        DateTime dt_now;
        string str_now;
        string str_Uiid = "";
        DataTable dt_MenuRights = new DataTable();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterBranch da_obj_Branch = new DataAccess.Masters.MasterBranch();
        DataAccess.Marketing.Booking obj_da_bkng = new DataAccess.Marketing.Booking();

        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "MuiTextField();", true);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "spancolorchange();", true);


            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);

            //if (Session["LoginUserName"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            //}

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnexportexcel);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (ddl_product.Text != "" && ddl_product.Text != "0")
            {
                if (ddl_product.Text == "Ocean Exports")
                {
                    //Session["StrTranType"] = "FE";
                    //StrTranType = Session["StrTranType"].ToString();
                    str_trantype = "FE";
                }
                else if (ddl_product.Text == "Ocean Imports")
                {
                    //Session["StrTranType"] = "FI";
                    // StrTranType = Session["StrTranType"].ToString();
                    str_trantype = "FI";
                }
                else if (ddl_product.Text == "Air Exports")
                {
                    //Session["StrTranType"] = "AE";
                    // StrTranType = Session["StrTranType"].ToString();
                    str_trantype = "AE";
                }
                else if (ddl_product.Text == "Air Imports")
                {
                    //Session["StrTranType"] = "AI";
                    // StrTranType = Session["StrTranType"].ToString();
                    str_trantype = "AI";
                }
                else if (ddl_product.Text == "CHA")
                {
                    //Session["StrTranType"] = "CH";
                    // StrTranType = Session["StrTranType"].ToString();
                    str_trantype = "CH";
                }
                else if (ddl_product.Text == "Bonded Trucking")
                {
                    //Session["StrTranType"] = "BT";
                    // StrTranType = Session["StrTranType"].ToString();
                    str_trantype = "BT";
                }


            }



            if (!IsPostBack)
            {
                try
                {
                    BindBranchDLL();
                    if (Session["trantype_process"] != null)
                    {
                        //lblHead1.Visible = false;
                        //lblHead2.Visible = false;
                        dt_MenuRights = Session["trantype_process"] as DataTable;
                        ddl_product.Items.Add("");

                        for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                        {
                            if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AE")
                            {
                                ddl_product.Items.Add("Air Exports");
                            }
                            else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AI")
                            {
                                ddl_product.Items.Add("Air Imports");
                            }
                            else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FE")
                            {
                                ddl_product.Items.Add("Ocean Exports");
                            }
                            else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FI")
                            {
                                ddl_product.Items.Add("Ocean Imports");
                            }
                            //else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "CH")
                            //{
                            //    ddl_product.Items.Add("CHA");
                            //}
                            //else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "BT")
                            //{
                            //    ddl_product.Items.Add("Bonded Trucking");
                            //}

                        }


                        // Session["StrTranType"] = dt_MenuRights.Rows[i]["modulename"].ToString();
                    }
                    else
                        if (Session["StrTranType"] != null)
                        {
                            ddl_product.Items.Add("");
                            if (Session["StrTranType"].ToString() == "FE")
                            {
                                ddl_product.Items.Add("Ocean Exports");
                                //ddl_product.SelectedIndex = 1;
                                ddl_product.SelectedValue = "Ocean Exports";
                            }
                            else if (Session["StrTranType"].ToString() == "FI")
                            {
                                ddl_product.Items.Add("Ocean Imports");
                                ddl_product.SelectedValue = "Ocean Imports";
                                //ddl_product.SelectedIndex = 1;
                            }
                            else if (Session["StrTranType"].ToString() == "AE")
                            {
                                ddl_product.Items.Add("Air Exports");
                                ddl_product.SelectedValue = "Air Exports";
                                //ddl_product.SelectedIndex = 1;
                            }
                            else if (Session["StrTranType"].ToString() == "AI")
                            {
                                ddl_product.Items.Add("Air Imports");
                                ddl_product.SelectedValue = "Air Imports";
                            }

                            else if (Session["StrTranType"].ToString() == "AC")
                            {
                                ddl_product.Items.Add("ALL");
                                ddl_product.SelectedValue = "ALL";
                                ddl_product_SelectedIndexChanged(sender, e);
                            }
                            else if (Session["StrTranType"].ToString() == "CH")
                            {
                                ddl_product.Items.Add("CHA");
                                ddl_product.SelectedValue = "CHA";
                                ddl_product_SelectedIndexChanged(sender, e);
                            }
                            else if (Session["StrTranType"].ToString() == "BT")
                            {
                                ddl_product.Items.Add("Bonded Trucking");
                                ddl_product.SelectedValue = "Bonded Trucking";
                                ddl_product_SelectedIndexChanged(sender, e);
                            }
                            //ddl_product.Enabled = false;
                            //ddl_product.SelectedIndex = 1;
                        }


                    if (Session["trantype_process"] == null)
                    {
                        ddl_product.Items.Add("");
                        ddl_product.Items.Add("Air Exports");
                        ddl_product.SelectedValue = "Air Exports";
                        ddl_product.Items.Add("Air Imports");
                        ddl_product.SelectedValue = "Air Imports";
                        ddl_product.Items.Add("Bonded Trucking");
                        ddl_product.SelectedValue = "Bonded Trucking";
                        ddl_product.Items.Add("CHA");
                        ddl_product.SelectedValue = "CHA";
                        ddl_product.Items.Add("Ocean Exports");
                        ddl_product.SelectedValue = "Ocean Exports";
                        ddl_product.Items.Add("Ocean Imports");
                        ddl_product.SelectedValue = "Ocean Imports";
                        ddl_product.SelectedIndex = 1;
                    }


                    if (Request.QueryString["type"] != null)
                    {
                        str_filename = Request.QueryString["type"].ToString();
                    }
                    if (str_filename != "Sales Person")
                    {
                        lbl_header.Text = "Volume";
                    }

                    Ctrl_List = txt_from.ID + "~" + txt_to.ID;
                    Msg_List = "From Date~To Date";
                    Data_List = "string~string";
                    btn_get.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Data_List + "');");
                    //str_now =Utility.fn_ConvertDate( Logobj.GetDate().ToShortDateString());
                    txt_from.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    txt_to.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    grd_sale();
                    //signup.Visible = true;
                    //  btnCancel.Text = "Cancel";
                    btnCancel.ToolTip = "Cancel";
                    btnCancel1.Attributes["class"] = "btn ico-cancel";
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    //Utility.Fn_CheckUserRights(str_Uiid, btn_get, btn_print, null);
                    string str_CtrlLists = "txt_from~txt_to";
                    btn_get.Attributes.Add("OnClick", "return IsDate('" + str_CtrlLists + "')");
                    /* if (Session["StrTranType"]!=null)
                     {
                     if (Session["StrTranType"].ToString() == "FE")
                     {
                         headerlable1.InnerText = "OceanExports";
                         if( lbl_header.Text=="Booking Register")
                         {
                             headerlable2.InnerText = "Utility";
                         }
                         else if (lbl_header.Text == "Sales Person")
                         {
                             headerlable2.InnerText = "Sales";
                         }
                     }
                     else if (Session["StrTranType"].ToString() == "FI")
                     {
                         headerlable1.InnerText = "OceanImports";
                         if (lbl_header.Text == "Booking Register")
                         {
                             headerlable2.InnerText = "Utility";
                         }
                     }
                     else if (Session["StrTranType"].ToString() == "AE")
                     {
                         headerlable1.InnerText = "AirExports";
                         if (lbl_header.Text == "Booking Register")
                         {
                             headerlable2.InnerText = "Utility";
                         }
                     }
                     else if (Session["StrTranType"].ToString() == "AI")
                     {
                         headerlable1.InnerText = "AirImports";
                         if (lbl_header.Text == "Booking Register")
                         {
                             headerlable2.InnerText = "Utility";
                         }
                     }
                     }*/
                    labelheader.InnerText = lbl_header.Text;
                    if (Session["LoginBranchid"].ToString() == "40")
                    {
                        Divbtnunclose.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

            }

            //if (!IsPostBack)
            //{                
            //    txtfromDate.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
            //    txttodate.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");

            //    empid = Convert.ToInt32(Session["LoginEmpId"]);
            //    //empid = 124;

            //    getgrid();
            //    signup.Visible = true;                
            //    Calendarextender1.EndDate = DateTime.Now;
            //}

        }

        protected void btn_get_Click(object sender, EventArgs e)
        {
            // hide by yuvaraj 06March23
            //if (ddl_product.SelectedValue != "0" && ddl_product.SelectedValue != "")
            //{
            //    if (chkwithamount.Checked == true)
            //    {
            //        fn_get_click();
            //    }
            //    else
            //    {
            //        GetWithamount();
            //    }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "ComRpt", "alertify.alert('Kindly Select the Product');", true);
            //    return;
            //}
            // add by yuvaraj 06march23 checkbox checked true 
            //if (chkwithamount.Checked == true)
            //{ 
                panelWithamount.Visible = true;
                panelWithOutamount.Visible = false;
                fn_get_click();
            //}
            //else
            //{
            //    panelWithamount.Visible = false;
            //    panelWithOutamount.Visible = true;
            //    GetWithamount();
            //}

        }
        private void grd_sale()
        {
            DataTable dt_nw = new DataTable();
            if (chkwithamount.Checked == true)
            {
                panelWithamount.Visible = true;
                panelWithOutamount.Visible = false;
                grd_sales.DataSource = dt_nw;
                grd_sales.DataBind();
            }
            else
            {
                panelWithamount.Visible = false;
                panelWithOutamount.Visible = true;
                GrdWithoutamount.DataSource = dt_nw;
                GrdWithoutamount.DataBind();
            }
        }
        private void fn_get_click()
        {
            try
            {
                DataTable dt_nw = new DataTable();
                grd_sales.DataSource = dt_nw;
                grd_sales.DataBind();
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                //Elengo
                if (ddl_branch.SelectedValue == "0")
                {
                    int_branchid = 40;
                }
                else
                {
                    int_branchid = Convert.ToInt32(ddl_branch.SelectedValue);
                }
                int_salesid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                //str_trantype = Session["StrTranType"].ToString();
                str_fromdate = Utility.fn_ConvertDate(txt_from.Text.ToString());
                str_todate = Utility.fn_ConvertDate(txt_to.Text.ToString());
                DataTable obj_dtselsalesdtls = new DataTable();
                DataTable obj_dtseldtls = new DataTable();


                if (Request.QueryString["type"] != null)
                {
                    str_filename = Request.QueryString["type"].ToString();
                }
                if (str_filename == "Sales Person")
                {
                    obj_dtselsalesdtls = obj_da_bkng.selSalesdetails(int_branchid, str_trantype, Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), int_salesid);

                    if (obj_dtselsalesdtls.Rows.Count > 0)
                    {
                        //DataRow dr_temp = obj_dtselsalesdtls.NewRow();
                        //dr_temp["Bookingno"] = "";
                        //dr_temp["Customer"] = "";
                        //dr_temp["PoL"] = "";
                        //dr_temp["PoD"] = "Total";
                        //dr_temp["samt"] = obj_dtselsalesdtls.Compute("sum(samt)", "");
                        //dr_temp["bamt"] = obj_dtselsalesdtls.Compute("sum(bamt)", "");
                        //dr_temp["ret"] = obj_dtselsalesdtls.Compute("sum(ret)", "");
                        //obj_dtselsalesdtls.Rows.Add(dr_temp);
                        //grd_sales.Columns[7].Visible = false;
                        grd_sales.DataSource = obj_dtselsalesdtls;
                        grd_sales.DataBind();
                    }
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 781, 3, Convert.ToInt32(Session["LoginBranchid"]), "Trantype: " + str_trantype + "/From: " + txt_from.Text + "/To: " + txt_to.Text + "/ Get");
                }
                else
                {
                    obj_dtseldtls = obj_da_bkng.seldetails4mis1(int_branchid, str_trantype, Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), "C");
                    //DataRow dr_temp = obj_dtseldtls.NewRow();
                    //dr_temp["Bookingno"] = "";
                    //dr_temp["Customer"] = "";
                    //dr_temp["PoL"] = "";
                    //dr_temp["PoD"] = "Total";
                    //dr_temp["samt"] = obj_dtseldtls.Compute("sum(samt)", "");
                    //dr_temp["bamt"] = obj_dtseldtls.Compute("sum(bamt)", "");
                    //dr_temp["ret"] = obj_dtseldtls.Compute("sum(ret)", "");
                    //obj_dtseldtls.Rows.Add(dr_temp);
                    if (obj_dtseldtls.Rows.Count > 0)
                    {
                        grd_sales.DataSource = obj_dtseldtls;
                        grd_sales.DataBind();
                    }
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 781, 3, Convert.ToInt32(Session["LoginBranchid"]), "Trantype: " + str_trantype + "/From: " + txt_from.Text + "/To: " + txt_to.Text + "/ Get");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../FormMain.aspx','_top');", true);
            }
            // btnCancel.Text = "Cancel";

            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";

        }
        private void ClearAll()
        {
            //str_now = DateTime.Now.ToString("MM/dd/yyyy");
            txt_from.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
            txt_to.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
            grd_sales.DataSource = null;
            grd_sales.DataBind();
            GrdWithoutamount.DataSource = new DataTable();
            chkwithamount.Checked = false;
            panelWithOutamount.Visible = true;
            panelWithamount.Visible = false;

        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            ClearAll();
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
            grd_sales.AllowPaging = false;
            //  GridBindValues();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            grd_sales.GridLines = GridLines.Both;
            grd_sales.HeaderStyle.Font.Bold = true;
            grd_sales.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        private void ExportToPdf()
        {
            Response.ContentType = "application/pdf";
            string FileName = "Customer" + DateTime.Now + ".pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            grd_sales.AllowPaging = false;
            grd_sales.RenderControl(hw);
            grd_sales.HeaderRow.Style.Add("width", "5%");
            grd_sales.HeaderRow.Style.Add("font-size", "10px");
            grd_sales.Style.Add("text-decoration", "none");
            grd_sales.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            grd_sales.Style.Add("font-size", "8pt");
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.ToolTip == "Cancel")
            {
                grd_sales.DataSource = new DataTable();
                grd_sales.DataBind();
                ddl_product.SelectedIndex = 0;
                if (Session["LoginBranchId"].ToString() == "40")
                {
                    ddl_branch.SelectedValue = "0";
                }

                //  btnCancel.Text = "Back";

                btnCancel.ToolTip = "Back";
                btnCancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                // this.Response.End();

                Response.Redirect("../Home/MISAndApproval.aspx");
            }
        }

        protected void grd_sales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label customer = (Label)e.Row.FindControl("customer");
            //    string tooltip = customer.Text;
            //    e.Row.Cells[2].Attributes.Add("title", tooltip);
            //    Label SalesPerson = (Label)e.Row.FindControl("SalesPerson");
            //    string Sales = SalesPerson.Text;
            //    e.Row.Cells[3].Attributes.Add("title", Sales);
            //    Label pol = (Label)e.Row.FindControl("pol");
            //    string tooltippol = pol.Text;
            //    e.Row.Cells[5].Attributes.Add("title", tooltippol);
            //    Label pod = (Label)e.Row.FindControl("pod");
            //    string tooltippod = pod.Text;
            //    e.Row.Cells[6].Attributes.Add("title", tooltippod);
            //}
        }

        protected void btn_Unclosed_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_product.SelectedValue != "0" && ddl_product.SelectedValue != "")
                {

                    panelWithOutamount.Visible = false;
                    panelWithamount.Visible = true;
                    grd_sales.DataSource = null;
                    grd_sales.DataBind();
                    int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    int_salesid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                    //str_trantype = Session["StrTranType"].ToString();
                    str_fromdate = Utility.fn_ConvertDate(txt_from.Text.ToString());
                    str_todate = Utility.fn_ConvertDate(txt_to.Text.ToString());
                    DataTable obj_dtselsalesdtls = new DataTable();
                    DataTable obj_dtseldtls = new DataTable();
                    DataAccess.Marketing.Booking obj_da_bkng = new DataAccess.Marketing.Booking();

                    if (Request.QueryString["type"] != null)
                    {
                        str_filename = Request.QueryString["type"].ToString();
                    }
                    if (str_filename == "Sales Person")
                    {
                        obj_dtselsalesdtls = obj_da_bkng.selSalesdetails(int_branchid, str_trantype, Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), int_salesid);

                        if (obj_dtselsalesdtls.Rows.Count > 0)
                        {
                            grd_sales.DataSource = obj_dtselsalesdtls;
                            grd_sales.DataBind();
                        }
                        else
                        {
                            grd_sales.DataSource = new DataTable();
                            grd_sales.DataBind();
                        }
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 781, 3, Convert.ToInt32(Session["LoginBranchid"]), "Trantype: " + str_trantype + "/From: " + txt_from.Text + "/To: " + txt_to.Text + "/ Get");
                    }
                    else
                    {
                        obj_dtseldtls = obj_da_bkng.seldetails(int_branchid, str_trantype, Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), "U");
                        if (obj_dtseldtls.Rows.Count > 0)
                        {

                            grd_sales.DataSource = obj_dtseldtls;
                            grd_sales.DataBind();
                        }
                        else
                        {
                            grd_sales.DataSource = new DataTable();
                            grd_sales.DataBind();
                        }
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 781, 3, Convert.ToInt32(Session["LoginBranchid"]), "Trantype: " + str_trantype + "/From: " + txt_from.Text + "/To: " + txt_to.Text + "/ Get");
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "ComRpt", "alertify.alert('Kindly Select the Product');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../FormMain.aspx','_top');", true);
            }
            // btnCancel.Text = "Cancel";
            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }


        public void BindBranchDLL()
        {
            try
            {
                int int_divid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                DataTable obj_dtTemp = new DataTable();
                obj_dtTemp = da_obj_Branch.GetBranchByDivID(int_divid);
                int i;
                ddl_branch.Items.Add(new System.Web.UI.WebControls.ListItem("ALL", "0"));
                for (i = 0; i <= obj_dtTemp.Rows.Count - 1; i++)
                {
                    if (obj_dtTemp.Rows[i]["branch"].ToString() != "CORPORATE")
                    {
                        ddl_branch.Items.Add(new System.Web.UI.WebControls.ListItem(obj_dtTemp.Rows[i]["branch"].ToString(), obj_dtTemp.Rows[i]["branchid"].ToString()));
                    }
                }

                if (Session["LoginBranchid"].ToString() != "40")
                {
                    ddl_branch.SelectedValue = Session["LoginBranchid"].ToString();
                    ddl_branch.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../Login.aspx','_top');", true);
            }

        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            try
            {
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_salesid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                //if (Session["StrTranType"] != null)
                //{
                //    str_trantype = Session["StrTranType"].ToString();
                //}
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                DateTime from = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text));
                DateTime to = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text));
                str_RptName = "BookingReg.rpt";
                //report.strRptName = "Reports" + "\BookingReg.rpt" ' "REPORTS" + "\EmpDetails.rpt"
                // sf = "{TempBooking.bid}=" & Login.branchid & " and {TempBooking.bookingdate}>=date('" & Dtfromdate.Value.Year & "," & Dtfromdate.Value.Month & "," & Dtfromdate.Value.Day & "') and {TempBooking.bookingdate}<=date('" & Dttodate.Value.Year & "," & Dttodate.Value.Month & "," & Dttodate.Value.Day & "') and {TempBooking.trantype}='" & strtrantype & "'"
                Session["str_sfs"] = "{TempBooking.bid}=" + int_branchid + " and {TempBooking.bookingdate}>=date('" + from.Year + "," + from.Month + "," + from.Day + "') and {TempBooking.bookingdate}<=date('" + to.Year + "," + to.Month + "," + to.Day + "') and {TempBooking.trantype}='" + str_trantype + "'";
                str_sp = "Header=Booking Register for the Period from " + txt_from.Text + " To " + txt_to.Text;
                //'sf = "{TempBooking.bookingdate}>=date('" &Dtfromdate.Value.Year & "," &Dtfromdate.Value.Month & "," &Dtfromdate.Value.Day & "') and {TempBooking.bookingdate}<=date('" &Dttodate.Value.Year & "," &Dttodate.Value.Month & "," &Dttodate.Value.Day &")' and {TempBooking.bid}=" & Login.branchid & " and {TempBooking.trantype}='" & strtrantype & "'"
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "Booking", str_Script, true);
                Logobj.InsLogDetail(int_salesid, 781, 3, int_branchid, "Trantype: " + str_trantype + "/From: " + txt_from.Text + "/To: " + txt_to.Text + "/ Print");
                //Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void ddl_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Session["StrTranType"] != null)
            //{
            //    str_trantype = Session["StrTranType"].ToString();
            //}



            if (ddl_product.Text != "" && ddl_product.Text != "0")
            {
                if (ddl_product.Text.ToUpper() == "Ocean Exports".ToUpper())
                {
                    str_trantype = "FE";
                }
                else if (ddl_product.Text.ToUpper() == "Ocean Imports".ToUpper())
                {
                    str_trantype = "FI";
                }
                else if (ddl_product.Text.ToUpper() == "Air Exports".ToUpper())
                {
                    str_trantype = "AE";
                }
                else if (ddl_product.Text.ToUpper() == "Air Imports".ToUpper())
                {
                    str_trantype = "AI";
                }
                else if (ddl_product.Text.ToUpper() == "CHA".ToUpper())
                {
                    str_trantype = "CH";
                }
                else if (ddl_product.Text.ToUpper() == "Bonded Trucking".ToUpper())
                {
                    str_trantype = "BT";
                }
                else if (ddl_product.Text.ToUpper() == "All".ToUpper())
                {
                    str_trantype = "CO";
                }
            }
            grd_sales.DataSource = new DataTable();
            grd_sales.DataBind();
        }

        protected void btnexportexcel_Click(object sender, EventArgs e)
        {
            string Str_Title;
            Str_Title = Session["LoginDivisionName"].ToString() + "-" + Session["LoginBranchName"].ToString();
            string Str_SelectedText;
            Str_SelectedText = lbl_header.Text;
            StringBuilder SB = new StringBuilder();
            StringWriter StringWriter = new System.IO.StringWriter(SB);
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

            if (panelWithamount.Visible == true)
            {
                if (grd_sales.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.AddHeader("content-disposition", "attachment;filename=" + Str_SelectedText + ".xls");
                    Response.Charset = "";
                    //Response.ContentType = "application/vnd.ms-excel";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    int cnt = grd_sales.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + Str_SelectedText + "</B></font></td></tr>");
                    SB.Append("</table>");
                    grd_sales.GridLines = GridLines.Both;
                    grd_sales.HeaderStyle.Font.Bold = true;
                    grd_sales.RenderControl(HtmlTextWriter);
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(StringWriter.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            else
            {
                if (GrdWithoutamount.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.AddHeader("content-disposition", "attachment;filename=" + Str_SelectedText + " WithOutCost.xls");
                    Response.Charset = "";
                    //Response.ContentType = "application/vnd.ms-excel";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    int cnt = GrdWithoutamount.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + Str_SelectedText + " WithOutCost</B></font></td></tr>");
                    SB.Append("</table>");
                    GrdWithoutamount.GridLines = GridLines.Both;
                    GrdWithoutamount.HeaderStyle.Font.Bold = true;
                    GrdWithoutamount.RenderControl(HtmlTextWriter);
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(StringWriter.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
        }


        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkwithamount.Checked == true)
            {
                grd_sales.DataSource = new DataTable();
                grd_sales.DataBind();
            }
            else
            {
                GrdWithoutamount.DataSource = new DataTable();
                GrdWithoutamount.DataBind();
            }
        }

        protected void GrdWithoutamount_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
            }
        }

        protected void chkwithamount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkwithamount.Checked == true)
            {
                panelWithamount.Visible = true;
                panelWithOutamount.Visible = false;
                fn_get_click();
            }
            else
            {
                panelWithamount.Visible = false;
                panelWithOutamount.Visible = true;
                GetWithamount();
            }
        }

        public void GetWithamount()
        {
            try
            {
                if (chkwithamount.Checked == true)
                {
                    panelWithamount.Visible = true;
                    panelWithOutamount.Visible = false;
                }
                else
                {
                    panelWithamount.Visible = false;
                    panelWithOutamount.Visible = true;
                }
                GrdWithoutamount.DataSource = new DataTable();
                GrdWithoutamount.DataBind();
                if (ddl_branch.SelectedValue == "0")
                {
                    int_branchid = 40;
                }
                else
                {
                    int_branchid = Convert.ToInt32(ddl_branch.SelectedValue);
                }
                str_fromdate = Utility.fn_ConvertDate(txt_from.Text.ToString());
                str_todate = Utility.fn_ConvertDate(txt_to.Text.ToString());
                DataTable Dt= obj_da_bkng.GetWithOutAmount4CORPandBR(Convert.ToDateTime(str_fromdate), Convert.ToDateTime(str_todate), str_trantype, int_branchid, Convert.ToInt32(Session["DivisionId"]));
                if (Dt.Rows.Count > 0)
                {
                    GrdWithoutamount.DataSource = Dt;
                    GrdWithoutamount.DataBind();
                }
                else
                {
                    GrdWithoutamount.DataSource = new DataTable();
                    GrdWithoutamount.DataBind();
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "ComRpt", "alertify.alert('No Data Found');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

    }
}