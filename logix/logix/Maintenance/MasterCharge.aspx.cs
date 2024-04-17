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
    public partial class MasterCharge : System.Web.UI.Page
    {
    DataAccess.Masters.MasterCharges chargesobj = new DataAccess.Masters.MasterCharges();
    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
    string servicetype,chargetype;
    int chargeid;
    DataTable dt_charges=new DataTable ();
    DataTable dt_grd = new DataTable();
    DataTable dt_grdFill = new DataTable();
    DataTable dt_check = new DataTable();
    string Ctrl_List;
    string Msg_List;
    string Dtype_List;
    string str_Uiid = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
        ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
        ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
        if (Session["LoginUserName"] == null)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
        }
        //txtcharge.Attributes.Add("onblur", "javascript:onChangeTest()");
        grd.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

        btndelete.Visible = false;
        if (!this.IsPostBack)
        {
            try
            {
                ddl_service.Items.Add("BSS");
                ddl_service.Items.Add("BAS");
                ddl_service.Items.Add("GTA");
                ddl_service.Items.Add("Others");
                ChargeType();
                FillgrdonpageLoad();
                Ctrl_List = txtcharge.ID;
                Msg_List = "Charge Name";
                Dtype_List = "string~string";
                btnsave.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                btndelete.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                Utility.Fn_CheckUserRights(str_Uiid, btnsave, null, null);
                Utility.Fn_CheckUserRights(str_Uiid, btndelete, null, null);
                btncancel.Text = "Back";
                txtcharge.Focus();
                btnsave.Enabled = false;
                //  btndelete.Enabled = false;
                btndelete.Visible = false;
                dropdown_box.Visible = false;

                btndelete.Click += btndelete_Click;
                btndelete.OnClientClick = @"return getConfirmationValue();";
                //if(ddl_service.SelectedIndex==3)
                //{
                //    txtPercent.Enabled = false;
                //    txtEduPer.Enabled = false;
                //    txtHighEduPer.Enabled = false;
                //}
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        //Bhuvana
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

    protected void ChargeType()
    {
      //  ddl_chargetype.Items.Add("CHARGE");
        ddl_chargetype.Items.Add("ADMIN");
        ddl_chargetype.Items.Add("OPERATION");
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

   
        //Bhuvana
    }
        [WebMethod]
        public static List<string> GetChargename(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCharges chargesobj = new DataAccess.Masters.MasterCharges();
            DataTable dt_Location = new DataTable();
            dt_Location = chargesobj.GetLikeChargesName(prefix);

            List_Result = Utility.Fn_TableToList(dt_Location, "chargename", "chargeid");
            return List_Result;
        }
        public void FillgrdonpageLoad()
        {

            dt_grdFill = chargesobj.FillGridOnPageLoad2Charges();
            grd.Visible = true;
            grd.DataSource = dt_grdFill;
            grd.DataBind();
        }

        protected void btnsave_Click1(object sender, EventArgs e)
        {
            try
            {
                //btndelete.Enabled = false; 
                float percentage = 0;
                if (txtPercent.Text != "")
                {
                    percentage = Convert.ToSingle(txtPercent.Text);
                }

                btndelete.Visible = false;
                if (ddl_service.SelectedItem.Text == "BSS")
                {
                    servicetype = "B";
                }
                else if (ddl_service.SelectedItem.Text == "BAS")
                {
                    servicetype = "A";
                }
                else if (ddl_service.SelectedItem.Text == "GTA")
                {
                    servicetype = "G";
                }
                else if (ddl_service.SelectedItem.Text == "Others")
                {
                    servicetype = "O";
                }

                if (ddl_chargetype.SelectedItem.Text == "ADMIN")
                {
                    chargetype = "A";
                }
                else if (ddl_chargetype.SelectedItem.Text == "OPERATION")
                {
                    chargetype = "O";
                }
                if (ddl_chargetype.SelectedIndex != 0)
                {

                    if (btnsave.Text == "Save")
                    {

                        check();

                        if (txtcharge.Text != "" && hdn_chargeid.Value == "")
                        {
                            if (percentage <= 0)
                            {
                                // if ((txtPercent.Text == "") && (txtEduPer.Text == "") && (txtHighEduPer.Text == ""))
                                //{
                                chargesobj.InsertChargeTaxDetails(txtcharge.Text.ToUpper().Trim(), servicetype, chargetype);
                                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Charges", "alertify.alert('Charges Saved...');", true);
                                clear();
                                //}
                            }

                            else if (percentage > 0)
                            {
                                if ((txtPercent.Text != "") && (txtEduPer.Text != "") && (txtHighEduPer.Text != ""))
                                {
                                    chargesobj.InsertChargeTaxDetails(txtcharge.Text.ToUpper().Trim(), Convert.ToSingle(txtPercent.Text), Convert.ToSingle(txtEduPer.Text), Convert.ToSingle(txtHighEduPer.Text), servicetype, chargetype);
                                    //Logobj.InsLogDetail(Login.logempid, 130, 1, Login.branchid, txtCharges.Text);
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 130, 1, int.Parse(Session["LoginBranchid"].ToString()), txtcharge.Text + "/Sav");                               
                                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Charges", "alertify.alert('Charges Saved...');", true);

                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Charges", "alertify.alert('Fill All Percentages...');", true);
                                    //txtEduPer.Text = "";
                                    //txtHighEduPer.Text = "";
                                    //txtPercent.Text = "";

                                }
                                clear();
                            }


                        }
                    }
                    else if (btnsave.Text == "Update")
                    {

                        if (percentage <= 0)
                        {
                            //if ((txtPercent.Text == "") && (txtEduPer.Text == "") && (txtHighEduPer.Text == ""))
                            //{
                            chargeid = Convert.ToInt32(hdn_chargeid.Value.ToString());
                            chargesobj.UpdateChargeDetails4withouttax(chargeid, txtcharge.Text.ToUpper().Trim(), servicetype, chargetype);
                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 130, 2, int.Parse(Session["LoginBranchid"].ToString()), txtcharge.Text + "/upd");                               
                            ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Charges", "alertify.alert('Charges Updated...');", true);
                            clear();
                            btnsave.Text = "Save";
                            //}

                        }
                        else if (percentage > 0)
                        {
                            if ((txtPercent.Text != "") && (txtEduPer.Text != "") && (txtHighEduPer.Text != ""))
                            {
                                chargeid = Convert.ToInt32(hdn_chargeid.Value.ToString());
                                chargesobj.UpdateChargeDetails4withtax(chargeid, txtcharge.Text.ToUpper().Trim(), Convert.ToSingle(txtPercent.Text), Convert.ToSingle(txtEduPer.Text), Convert.ToSingle(txtHighEduPer.Text), servicetype, chargetype);
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 130, 2, int.Parse(Session["LoginBranchid"].ToString()), txtcharge.Text + "/upd");                               
                                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Charges", "alertify.alert('Charges Updated ...');", true);
                                clear();
                                btnsave.Text = "Save";
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Charges", "alertify.alert('Fill All Percentages...');", true);
                                //txtEduPer.Text = "";
                                //txtHighEduPer.Text = "";
                                //txtPercent.Text = "";

                            }

                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Charges", "alertify.alert('Select Charge Type...');", true);

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void check()
        {
            if (txtcharge.Text != "")
            {
                dt_check = chargesobj.CheckDuplicateForCharges(txtcharge.Text);

                if (dt_check.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master Charges", "alertify.alert('Charge Name Already Exists...');", true);
                    txtcharge.Text = "";
                }
            }

        }
        public void clear()
        {
            ddl_chargetype.SelectedIndex = 0;
            ddl_service.SelectedIndex = 0;
            txtcharge.Text = "";
            txtEduPer.Text = "";
            txtHighEduPer.Text = "";
            txtPercent.Text = "";
            ddl_service.Text = "BSS";
            FillgrdonpageLoad();
            btncancel.Text = "Back";
            hdn_chargeid.Value = "";
            dropdown_box.Visible = false;
            btnsave.Enabled = false;
           // btndelete.Enabled = false;
            btndelete.Visible = false;
            btnsave.Text = "Save";
        }

        protected void txtcharge_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                btnsave.Enabled = true;
                //  btndelete.Enabled = false;
                btndelete.Visible = false;
                dt_check = chargesobj.CheckDuplicateForCharges(txtcharge.Text);
                if (dt_check.Rows.Count > 0)
                {
                    hdn_chargeid.Value = dt_check.Rows[0]["chargeid"].ToString();
                }


                if (hdn_chargeid.Value != "")
                {
                    chargeid = Convert.ToInt32(hdn_chargeid.Value.ToString());

                    dt_charges = chargesobj.ShowChargeNameDetails(txtcharge.Text,"");
                    if (dt_charges.Rows.Count > 0)
                    {
                        chargetype = dt_charges.Rows[0]["chargetype"].ToString();
                        if (chargetype == "A")
                        {
                            ddl_chargetype.SelectedIndex = 1;
                        }
                        else
                        {
                            ddl_chargetype.SelectedIndex = 2;
                        }
                        servicetype = dt_charges.Rows[0]["servicetype"].ToString();
                        if (servicetype == "S")
                        {
                            ddl_service.Text = "BSS";
                        }
                        else if (servicetype == "A")
                        {
                            ddl_service.Text = "BAS";
                        }
                        else if (servicetype == "G")
                        {
                            ddl_service.Text = "GTA";
                        }
                        else if (servicetype == "O")
                        {
                            ddl_service.Text = "Others";
                        }
                        //if (ddl_service.SelectedIndex == 3)
                        //{
                        //    txtPercent.Enabled = false;
                        //    txtHighEduPer.Enabled = false;
                        //    txtEduPer.Enabled = false;
                        //}
                        //else
                        //{
                        //    txtPercent.Enabled = true;
                        //    txtHighEduPer.Enabled = true;
                        //    txtEduPer.Enabled = true;
                        //}
                        txtPercent.Text = dt_charges.Rows[0]["percentage"].ToString();
                        txtEduPer.Text = dt_charges.Rows[0]["edcess"].ToString();
                        txtHighEduPer.Text = dt_charges.Rows[0]["hedcess"].ToString();
                        //hdn_chargeid .Value = dt_charges.Rows[0]["chargeid"].ToString();
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Charges", "alertify.alert('Charges Already Exitis');", true);
                        btnsave.Text = "Update";

                    }
                }
                else
                {
                    btnsave.Text = "Save";
                }
                btncancel.Text = "Cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            btndelete.Enabled = false;
            if (btncancel.Text == "Cancel")
            {
                clear();
                FillgrdonpageLoad();
                btncancel.Text = "Back";
            }
            else if (btncancel.Text == "Back")
            {
                this.Response.End();
            }


        }
        protected void btnview_Click(object sender, EventArgs e)
        {
            bindgrid();
            grd.Visible = true;
            dropdown_box.Visible = true;
          //  btndelete.Enabled = false;
            btndelete.Visible = false;          
            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 130, 3, int.Parse(Session["LoginBranchid"].ToString()), "/ChargeView");                               

        }
        public void bindgrid()
        {
            dt_grd = chargesobj.ShowChargeDetails();
            if (dt_grd.Rows.Count > 0)
            {
                grd.DataSource = dt_grd;
                grd.DataBind();
              
            }

        }
        private void ExportGridToPDF()
        {

            Response.ContentType = "application/pdf";
            string FileName = "ChargeDetails" + DateTime.Now + ".pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grd.AllowPaging = false;
            bindgrid();
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
        protected void ExportToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            string FileName = "ChargeDetails" + DateTime.Now + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

             
                grd.AllowPaging = false;
                bindgrid();
                foreach (TableCell cell in grd.HeaderRow.Cells)
                {
                    cell.BackColor = grd.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grd.Rows)
                {
                 
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grd.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grd.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grd.RenderControl(hw);
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
        protected void grdstate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;

            dt_grd = chargesobj.ShowChargeDetails();
            if (dt_grd.Rows.Count > 0)
            {
                grd.DataSource = dt_grd;
                grd.DataBind();
                
            }

        }

        protected void txtPercent_TextChanged(object sender, EventArgs e)
        {

            btncancel.Text = "Cancel";
        }

        protected void txtEduPer_TextChanged(object sender, EventArgs e)
        {
            btncancel.Text = "Cancel";
        }

        protected void txtHighEduPer_TextChanged(object sender, EventArgs e)
        {
            btncancel.Text = "Cancel";
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            bool type = false;

            if (hfWasConfirmed.Value == "true")
            {
                if (hdn_chargeid.Value != "")
                {
                    chargeid = Convert.ToInt32(hdn_chargeid.Value.ToString());
                    chargesobj.DelChargeDetails(chargeid);
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "Master charges", "alertify.alert('Charge Details Deleted...');", true);
                    clear();
                }
            }
        }

        protected void ddl_service_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(ddl_service.SelectedIndex==3)
            //{
            //    txtPercent.Enabled = false;
            //    txtEduPer.Enabled = false;
            //    txtHighEduPer.Enabled = false;
            //}
            //else
            //{
            //    txtPercent.Enabled = true;
            //    txtEduPer.Enabled = true;
            //    txtHighEduPer.Enabled = true;
            //}
           
        }

        //protected void txtsearch_TextChanged(object sender, EventArgs e)
        //{
        //      int i;
        //      try
        //      {
        //          if (txtsearch.Text != "0")
        //          {
        //              dt_grdFill = chargesobj.GetLikeCharges(txtsearch.Text);
        //              if (dt_grdFill.Rows.Count > 0)
        //              {

        //                  grd.DataSource = dt_grdFill;
        //                  grd.DataBind();

        //              }
        //              else
        //              {
        //                  grd.DataSource = new DataTable();
        //                  grd.DataBind();
        //              }
        //          }
        //          else
        //          {
        //              ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.PageEventArgs), "Master charges", "alertify.alert('NO Record Founds');", true);
        //          }
        //      }
        //      catch (Exception ex)
        //      {
        //          string message = ex.Message.ToString();
        //          ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //      }
        //}
   
   
    }
}