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
using System.Web.Services.Description;

namespace logix.Maintenance
{
    public partial class MasterBank : System.Web.UI.Page
    {
        DataAccess.Masters.MasterBank objp = new DataAccess.Masters.MasterBank();
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        DataTable dt = new DataTable();
        string banktype;
        DataAccess.Masters.MasterBank obj_ins = new DataAccess.Masters.MasterBank();
        DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataTable obj_dt = new DataTable();
        DataTable bankid1 = new DataTable();
        Boolean blr;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);
            Button_delete.Click += Button_delete_Click;
            Button_delete.OnClientClick = @"return getConfirmationValue();";

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Button_cancel);
            //excel.ServerClick += new EventHandler(Excelfunforserver_Click);
            //pdf.ServerClick += new EventHandler(pdffunforserver_Click);
            Button_delete.Visible = false;Button_delete_id.Visible = false;

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_ins.GetDataBase(Ccode);
                recobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
               



            }


            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (!IsPostBack)
            {
                try
                {
                    Session["Update"] = Server.UrlEncode(System.DateTime.Now.ToString());

                    Ctrl_List = txt_bank.ID;
                    Msg_List = "Bank Name";
                    Dtype_List = "string~string";
                    Button_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, Button_save, null, null);
                    bankgrid.Visible = true;
                    Button_save.Enabled = false;
                    // Button_delete.Enabled = false;
                    Button_delete.Visible = false;Button_delete_id.Visible = false;
                    txt_bank.Focus();
                    grd_Empty();
                  //  GridTopRowDisplay();
                    clear();
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
                //            where control.TabIndex > indx
                //            select control;
                //ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
                
            }
        
        }
                
        protected void grd_Empty()
        {
            bankgrid.DataSource = new DataTable();
            bankgrid.DataBind();
        }

        [WebMethod]
        public static List<string> GetBank(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            recobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            dt = recobj.GetLikeBankName(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(dt, "bankname", "bankid");
            return List_Result;

        }

        [WebMethod]
        public static void GetEmpName(string Prefix)
        {

            DataTable obj_dtEmp = new DataTable();

            if (Prefix.Length > 0)
            {
                DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                recobj.GetDataBase(Ccode);
                DataTable obj_dt = new DataTable();
                obj_dt = recobj.GetLikeBankName(Prefix.ToUpper());
                obj_dtEmp.Columns.Add("bankname");
                obj_dtEmp.Columns.Add("bankid");
                
                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["bankname"] = obj_dt.Rows[i][0].ToString();
                    dr["bankid"] = obj_dt.Rows[i][1].ToString();
                

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
                    ViewState["Bak"] = obj_dtEmp;
                    bankgrid.DataSource = obj_dtEmp;
                    bankgrid.DataBind();

                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
            }
            else
            {
                bankgrid.DataSource = null;
                bankgrid.DataBind();
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


        protected void Button_save_Click(object sender, EventArgs e)
        {
            try
            {
                Button_delete.Visible = false;Button_delete_id.Visible = false;
                if (Button_save.ToolTip == "Save")
                {
                    //checkdata();
                    checkbank();
                    if(blr==true)
                    {
                        return;
                    }
                    if (hiddenid.Value == "0")
                    {
                        hiddenid.Value = "";
                    }
                    if (hiddenid.Value == "")
                    {
                        if (chkourbank.Checked)
                        {
                            obj_ins.InsertBank(txt_bank.Text.ToUpper(), "Y");
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Bank", "alertify.alert('Saved Successfully');", true);
                            Button_cancel.Text = "cancel";


                            Button_cancel.ToolTip = "Cancel";
                            Button_cancel1.Attributes["class"] = "btn ico-cancel";

                           

                            ////empty_grid();
                            //gridview();
                            clear();
                        }
                        else
                        {
                            obj_ins.InsertBank(txt_bank.Text.ToUpper(), "N");
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Bank", "alertify.alert('Saved Successfully');", true);
                            //gridview();
                        }
                        //gridbind();
                        //gridview();
                        //empty_grid();
                      //  GridTopRowDisplay();
                        //Button_save.Text = "Update";
                        Button_cancel.Text = "cancel";

                        Button_cancel.ToolTip = "Cancel";
                        Button_cancel1.Attributes["class"] = "btn ico-cancel";

                       
                        clear();
                    }
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 328, 1, int.Parse(Session["LoginBranchid"].ToString()), "save"); 
                }
                else
                {
                    if (hiddenid.Value != "")
                    {
                        int bid = Convert.ToInt32(hiddenid.Value.ToString());
                        if (chkourbank.Checked)
                        {
                            obj_ins.UpdBank(txt_bank.Text.ToUpper(), "Y", bid);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Bank", "alertify.alert('Updated Successfully');", true);
                            //gridview();
                        }
                        else
                        {
                            obj_ins.UpdBank(txt_bank.Text.ToUpper(), "N", bid);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Bank", "alertify.alert('Updated Successfully');", true);
                            //gridview();
                        }
                      //  gridview();
                        //gridbind();
                        //empty_grid();
                        Button_save.Text = "Save";
                        Button_cancel.Text = "cancel";

                        Button_cancel.ToolTip = "Cancel";
                        Button_cancel1.Attributes["class"] = "btn ico-cancel";

                        Button_save.ToolTip = "Save";
                        Button_save1.Attributes["class"] = "btn ico-save";
                        clear();
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 328, 2, int.Parse(Session["LoginBranchid"].ToString()), "update"); 
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
        public void checkdata()
        {
            if (txt_bank.Text == "")
            {
                txt_bank.Text = "";
              
                txt_bank.Focus();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Bank", "alertify.alert('Bank Name cannot be blank');", true);
                blr = true;

            }
          
        }

        public void checkbank()
        {
            if (txt_bank.Text != "")
            {
                hiddenid.Value = recobj.GetBankid(txt_bank.Text).ToString();

                if (hiddenid.Value!="" &&hiddenid.Value!="0" )
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Bank", "alertify.alert('Details Already Exists');", true);
                     Button_save.Text = "Update";
                  Button_cancel.Text = "Cancel";


                    Button_cancel.ToolTip = "Cancel";
                    Button_cancel1.Attributes["class"] = "btn ico-cancel";

                    Button_save.ToolTip = "Update";
                    Button_save1.Attributes["class"] = "btn ico-update";
                    //////////blr = true;
                    return;
                }
                else
                {
                    Button_save.Text = "Save";
                    Button_cancel.Text = "Cancel";

                    Button_cancel.ToolTip = "Cancel";
                    Button_cancel1.Attributes["class"] = "btn ico-cancel";

                    Button_save.ToolTip = "Save";
                    Button_save1.Attributes["class"] = "btn ico-save";
                    
                }

                //if (hiddenid.Value == "")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Bank", "alertify.alert('Details Already Exists');", true);
                //    blr = true;
                //    txt_bank.Focus();       
                //}
            }
        }

    public void clear()
    {
        txt_bank.Text = "";       
        hiddenid.Value = "";
        chkourbank.Checked = false;
      
    }

    protected void txt_bank_TextChanged(object sender, EventArgs e)
    {
        try
        {
            Button_delete.Visible = false;Button_delete_id.Visible = false;
            Button_save.Enabled = true;
            checkbank();
            checkdata();
            if(blr==true)
            {
                return;
            }
            if (hiddenid.Value != "")
            {
                DataTable dt_sel = new DataTable();

                int selid = Convert.ToInt32(hiddenid.Value.ToString());
                dt_sel = obj_ins.GetAllBankDetails(selid);
                if (dt_sel.Rows.Count > 0)
                {
                    banktype = dt_sel.Rows[0]["banktype"].ToString();
                    if (banktype == "Y")
                    {
                        chkourbank.Checked = true;
                    }
                    else if (banktype == "N")
                    {
                        chkourbank.Checked = false;
                    }
                    else if (banktype == "O")
                    {
                            chkourbank.Checked = true;
                        }
                    

                    // txt_ourbank.Text = dt_sel.Rows[0]["ourbank"].ToString();
                    Button_save.Text = "Update";
                    Button_cancel.Text = "cancel";


                    Button_cancel.ToolTip = "Cancel";
                    Button_cancel1.Attributes["class"] = "btn ico-cancel";

                    Button_save.ToolTip = "Update";
                    Button_save1.Attributes["class"] = "btn ico-update";
                }

            }
            else
            {
                Button_save.Text = "Save";
                Button_cancel.Text = "cancel";

                Button_cancel.ToolTip = "Cancel";
                Button_cancel1.Attributes["class"] = "btn ico-cancel";

                Button_save.ToolTip = "Save";
                Button_save1.Attributes["class"] = "btn ico-save";
            }
        }
        catch (Exception ex)
        {
            string message = ex.Message.ToString();
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        }
        txt_bank.Focus();
     }

    protected void Button_cancel_Click(object sender, EventArgs e)
    {
       // Button_delete.Enabled=false;
        Button_delete.Visible = false;Button_delete_id.Visible = false;
        if (Button_cancel.ToolTip == "Back")
        {
            this.Response.End();
            //Response.Redirect("../MainPage/MaintenanceDockedPanel.aspx");
        }
        else
        {
            clear();
            grd_Empty();
            divExport.Visible = false;
            Button_save.Text = "Save";
            Button_cancel.Text = "Back";




            Button_cancel.ToolTip = "Back";
            Button_cancel1.Attributes["class"] = "btn ico-back";

            Button_save.ToolTip = "Save";
            Button_save1.Attributes["class"] = "btn ico-save";

           // GridTopRowDisplay();
            chkourbank.Checked = false;
            txt_bank.Focus();
            txt_Search.Text = "";
            
        }
    }
    protected void gridbind()
    {
        DataTable  ds = new DataTable ();
        ds = objp.GetGridview();
        if (ds.Rows.Count > 0)
        {
            //DataTable dtbank = new DataTable();
            //dtbank = ds.Tables[0];
            bankgrid.DataSource = ds;
            bankgrid.DataBind();
           
        }
    }

    protected void Button_view_Click(object sender, EventArgs e)
    {
        try
        {
            //bankgrid.Visible = true;
            //empty_grid();
            //gridbind();
            //divExport.Visible = true;
            //Button_delete.Enabled = false;
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            str_RptName = "MasterBank.rpt";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(Button_view, typeof(Button), "MasterBank", str_Script, true);
            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 328,3, int.Parse(Session["LoginBranchid"].ToString()), "view"); 
        }
        catch (Exception ex)
        {
            string message = ex.Message.ToString();
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        } 

    }

    public void gridview()
    {
        bankgrid.Visible = true;
        empty_grid();
        gridbind();
    }
        

    //private void GridTopRowDisplay()
    //{
    //    DataTable dt_top = new DataTable();
    //    dt_top = objp.GetTopBankRows();
    //    if (dt_top.Rows.Count > 0)
    //    { 
    //        bankgrid.DataSource = dt_top;
    //        bankgrid.DataBind();
    //    }

    //}

    private void empty_grid()
    {
        DataTable dt_emp = new DataTable();
        bankgrid.DataSource = dt_emp;
        bankgrid.DataBind();
    }

    protected void btn_ep_Click(object sender, EventArgs e)
    {
        try
        {
            ExportGridToPDF();
        }
        catch (Exception ex)
        {
            string message = ex.Message.ToString();
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        } 

    }
  
    private void ExportGridToPDF()
    {

        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 328,5, int.Parse(Session["LoginBranchid"].ToString()), "pdf"); 
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Events.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        bankgrid.AllowPaging = false;
        dt = objp.GetGridview();
        bankgrid.DataSource = dt;
        bankgrid.DataBind();
        divExport.Visible = true; 
        bankgrid.RenderControl(hw);
        bankgrid.HeaderRow.Style.Add("width", "5%");
        bankgrid.HeaderRow.Style.Add("font-size", "10px");
        bankgrid.Style.Add("text-decoration", "none");
        bankgrid.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        bankgrid.Style.Add("font-size", "8pt");
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
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btn_ee_Click(object sender, EventArgs e)
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
   
    protected void ExportToExcel()
    {
        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 328,4, int.Parse(Session["LoginBranchid"].ToString()), "excel"); 
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=BankDetails.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            bankgrid.AllowPaging = false;
            dt = objp.GetGridview();
            bankgrid.DataSource = dt;
            bankgrid.DataBind();
            divExport.Visible = true; 
            // this.BindGrid();

            //  grdstate.HeaderRow.BackColor = Color.WHITE;
            foreach (System.Web.UI.WebControls.TableCell cell in bankgrid.HeaderRow.Cells)
            {
                cell.BackColor = bankgrid.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in bankgrid.Rows)
            {
                //  row.BackColor = Color
                foreach (System.Web.UI.WebControls.TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = bankgrid.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = bankgrid.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            bankgrid.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
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
            ExportGridToPDF();
        }
        catch (Exception ex)
        {
            string message = ex.Message.ToString();
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        } 

    }

    protected void bankgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        bankgrid.PageIndex = e.NewPageIndex;
        gridbind();

    }

    protected void Button_delete_Click(object sender, EventArgs e)
    {
        bool type = false;
        try
        {
            if (hfWasConfirmed.Value == "true")
            {
                if (hiddenid.Value != "")
                {
                    int bankid = Convert.ToInt32(hiddenid.Value.ToString());
                    objp.DelTableBank(bankid);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Bank", "alertify.alert('Your Department deleted');", true);
                    gridbind();
                    gridview();
                    txt_bank.Text = "";
                    Button_save.Text = "Save";
                                      

                    Button_save.ToolTip = "Save";
                    Button_save1.Attributes["class"] = "btn ico-save";
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 328,4, int.Parse(Session["LoginBranchid"].ToString()), "delete"); 
                }
            }
        }
        catch (Exception ex)
        {
            string message = ex.Message.ToString();
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        } 

    }

    protected void chkourbank_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void bankgrid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void bankgrid_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        bankgrid.PageIndex = e.NewPageIndex;
        bankgrid.DataSource = (DataTable)ViewState["Bak"];
        bankgrid.DataBind();
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
       // DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataTable obj_dtlogdetails = new DataTable();

        obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 328, "MSbank", txt_bank.Text, txt_bank.Text, "");  //"/Rate ID: " +
        if (txt_bank.Text != "")
        {
            JobInput.Text = txt_bank.Text;
            
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


