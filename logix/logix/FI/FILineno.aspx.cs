using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.FI
{
    public partial class FILineno : System.Web.UI.Page
    {
        DataAccess.ForwardingImports.Lineno obj_da_lineobj = new DataAccess.ForwardingImports.Lineno();
        DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "dropdownButton();SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);
            if (Ccode != "")
            {

                obj_da_lineobj.GetDataBase(Ccode);
                //hrempobj.GetDataBase(Ccode);
                //leftObj.GetDataBase(Ccode);
                //Appobj.GetDataBase(Ccode);
                //rightObj.GetDataBase(Ccode);
                //Approveobj.GetDataBase(Ccode);
                //logobj.GetDataBase(Ccode);
                //exrobj.GetDataBase(Ccode);
            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txt_Job);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(grd_Line);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Lineno);
            if (!IsPostBack)
            {
                grd_Job.Visible = false;
                grd_Line.Visible = true;
               // btn_Lineno.Text = "Update";

                btn_Lineno.ToolTip = "Update";
                btn_Lineno1.Attributes["class"] = "btn ico-update1";

                
                btn_Lineno.Enabled = true;
                //btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";


            }
        }
        protected void lnk_Job_Click(object sender, EventArgs e)
        {
            DataTable obj_dtjob = new DataTable();
            //DataAccess.ForwardingImports.Lineno obj_da_lineobj = new DataAccess.ForwardingImports.Lineno();
             string Ccode = Convert.ToString(Session["Ccode"]);
            if (Ccode != "")
            {

                obj_da_lineobj.GetDataBase(Ccode);
               
            }
            try
            {
                LoadJob();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void LoadJob()
        {
            DataTable obj_dtjob = new DataTable();
            obj_dtjob = obj_da_lineobj.GetJobDetails(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            if (obj_dtjob.Rows.Count > 0)
            {
                Grd_Job_popup.Show();
                grd_Job.Visible = true;
                grd_Job.DataSource = obj_dtjob;
                grd_Job.DataBind();
                return;
            }
           // btn_Lineno.Text = "Update";

            btn_Lineno.ToolTip = "Update";
            btn_Lineno1.Attributes["class"] = "btn btn-update1";
            btn_Lineno.Enabled = true;
           // btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void grd_Job_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName != "Page")
                {
                    DataTable obj_dtline = new DataTable();
                    
                    LinkButton img4 = (LinkButton)e.CommandSource;

                    GridViewRow gv4 = (GridViewRow)img4.Parent.Parent;
                    hid_img4.Value = gv4.RowIndex.ToString();
                    int index = gv4.RowIndex;
                    if (e.CommandName == "Select")
                    {
                        //grd_Job.Visible = false;
                        txt_Job.Text = grd_Job.Rows[index].Cells[0].Text.ToString();
                        obj_dtline = obj_da_lineobj.GetBLDetails(Convert.ToInt32(txt_Job.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                        if (obj_dtline.Rows.Count > 0)
                        {

                            grd_Line.DataSource = obj_dtline;
                            grd_Line.DataBind();
                            //DropDownList ddl1 = (DropDownList)grd_Line.FindControl("ddl_cargo");
                            DropDownList ddl1 = (DropDownList)grd_Line.Rows[0].Cells[4].FindControl("ddl_cargo");
                            DropDownList ddl2 = (DropDownList)grd_Line.Rows[0].Cells[5].FindControl("ddl_mm");
                            if (obj_dtline.Rows[0]["itemtype"].ToString() == "OT" | obj_dtline.Rows[0]["itemtype"].ToString() == "")
                            {
                                ddl1.SelectedValue = "0";
                            }
                            else
                            {
                                ddl1.SelectedValue = "1";
                            }
                            if (obj_dtline.Rows[0]["cargommt"].ToString() == "LC" | obj_dtline.Rows[0]["cargommt"].ToString() == "")
                            {
                                ddl2.SelectedValue = "0";
                            }
                            else if (obj_dtline.Rows[0]["cargommt"].ToString() == "TI")
                            {
                                ddl2.SelectedValue = "1";
                            }
                            else if (obj_dtline.Rows[0]["cargommt"].ToString() == "GC")
                            {
                                ddl2.SelectedValue = "2";
                            }
                            else if (obj_dtline.Rows[0]["cargommt"].ToString() == "TC")
                            {
                                ddl2.SelectedValue = "3";
                            }
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

        protected void txt_Job_TextChanged(object sender, EventArgs e)
        {
            try
            {
               // btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                DataTable obj_dtline = new DataTable();
               // DataAccess.ForwardingImports.Lineno obj_da_lineobj = new DataAccess.ForwardingImports.Lineno();

                 string Ccode = Convert.ToString(Session["Ccode"]);
                if (Ccode != "")
                {

                    obj_da_lineobj.GetDataBase(Ccode);

                }

                if (txt_Job.Text != "0")
                {
                    obj_dtline = obj_da_lineobj.GetBLDetails(Convert.ToInt32(txt_Job.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                    if (obj_dtline.Rows.Count > 0)
                    {
                        grd_Line.DataSource = obj_dtline;
                        grd_Line.DataBind();
                        //DropDownList ddl1 = (DropDownList)grd_Line.FindControl("ddl_cargo");
                        //DropDownList ddl1 = (DropDownList)grd_Line.Rows[0].Cells[4].FindControl("ddl_cargo");
                        //DropDownList ddl2 = (DropDownList)grd_Line.Rows[0].Cells[5].FindControl("ddl_mm");
                        //if (obj_dtline.Rows[0]["itemtype"].ToString() == "OT" | obj_dtline.Rows[0]["itemtype"].ToString() == "")
                        //{
                        //    ddl1.SelectedValue = "0";
                        //}
                        //else
                        //{
                        //    ddl1.SelectedValue = "1";
                        //}
                        //if (obj_dtline.Rows[0]["cargommt"].ToString() == "LC" | obj_dtline.Rows[0]["cargommt"].ToString() == "")
                        //{
                        //    ddl2.SelectedValue = "0";
                        //}
                        //else if (obj_dtline.Rows[0]["cargommt"].ToString() == "TI")
                        //{
                        //    ddl2.SelectedValue = "1";
                        //}
                        //else if (obj_dtline.Rows[0]["cargommt"].ToString() == "GC")
                        //{
                        //    ddl2.SelectedValue = "2";
                        //}
                        //else if (obj_dtline.Rows[0]["cargommt"].ToString() == "TC")
                        //{
                        //    ddl2.SelectedValue = "3";
                        //}

                        for (int i = 0; i <= obj_dtline.Rows.Count - 1; i++)
                        {
                            DropDownList ddl1 = (DropDownList)grd_Line.Rows[i].Cells[4].FindControl("ddl_cargo");
                            DropDownList ddl2 = (DropDownList)grd_Line.Rows[i].Cells[5].FindControl("ddl_mm");
                            if (obj_dtline.Rows[i]["itemtype"].ToString() == "OT" | obj_dtline.Rows[i]["itemtype"].ToString() == "")
                            {
                                ddl1.SelectedValue = "0";
                            }
                            else
                            {
                                ddl1.SelectedValue = "1";
                            }
                            if (obj_dtline.Rows[i]["cargommt"].ToString() == "LC" | obj_dtline.Rows[i]["cargommt"].ToString() == "")
                            {
                                ddl2.SelectedValue = "0";
                            }
                            else if (obj_dtline.Rows[i]["cargommt"].ToString() == "TI")
                            {
                                ddl2.SelectedValue = "1";
                            }
                            else if (obj_dtline.Rows[i]["cargommt"].ToString() == "GC")
                            {
                                ddl2.SelectedValue = "2";
                            }
                            else if (obj_dtline.Rows[i]["cargommt"].ToString() == "TC")
                            {
                                ddl2.SelectedValue = "3";
                            }
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

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
          if(btn_cancel.ToolTip=="Cancel")
          {
            txt_Job.Text = "";
            grd_Line.DataSource = null;
            grd_Line.DataBind();
           // btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
          }
          else
          {
              this.Response.End();
          }
        }

        protected void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                string strto;
                string sendqry;
                string strsubj;
                string strcc = "";
               // btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                if (grd_Line.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grd_Line.Rows)
                    {
                        int index = row.RowIndex;
                        CheckBox cb = (CheckBox)row.FindControl("chk_select");
                        if (cb.Checked == true)
                        {
                            TextBox txt_email = (TextBox)grd_Line.Rows[index].Cells[7].FindControl("txt_email");
                            TextBox txthbl = (TextBox)grd_Line.Rows[index].Cells[2].FindControl("txt_hbl");
                            TextBox txtline = (TextBox)grd_Line.Rows[index].Cells[0].FindControl("txt_line");
                            TextBox txtsub = (TextBox)grd_Line.Rows[index].Cells[1].FindControl("txt_subline");
                            strto = txt_email.Text.ToString();
                           // strsubj = "Line # for your BL# : " + grd_Line.Rows[index].Cells[2].Text;
                            strsubj = "Line # for your BL# : " + txthbl.Text;
                            sendqry = "";
                            sendqry = sendqry + "<FONT FACE=sans-serif SIZE=2>Dear Sir / Madam,</FONT>";
                            sendqry = sendqry + "<FONT FACE=sans-serif SIZE=2><br><br>House BL # : " + txthbl.Text + "</FONT>";
                            sendqry = sendqry + "<FONT FACE=sans-serif SIZE=2><br><br>Line # / SubLine # : " + txtline.Text + " /" + txtsub.Text + "</FONT>";
                            sendqry = sendqry + "<FONT FACE=sans-serif SIZE=2><br><br><br>System Generated Mail</FONT><br><br>";
                            strcc = Session["usermailid"].ToString();
                            Utility.SendMail("", strto, lbl_header.Text + " - " + strsubj, sendqry, "", Session["usermailpwd"].ToString(), "", strcc);
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

        protected void btn_Lineno_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_Lineno.ToolTip == "Line#")
                {
                }
                else if (btn_Lineno.ToolTip == "Update")
                {
                   // DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
                     string Ccode = Convert.ToString(Session["Ccode"]);
                    if (Ccode != "")
                    {

                        obj_da_Logobj.GetDataBase(Ccode);

                    }
                    if (txt_Job.Text != "")
                    {
                        fn_UpdateLineNumbers();
                        obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 110, 2, Convert.ToInt32(Session["LoginBranchid"]), hid_strbl.Value);
                       // btn_Lineno.Text = "Update";
                        btn_Lineno.ToolTip = "Update";
                        btn_Lineno1.Attributes["class"] = "btn ico-update1";
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        
        private void fn_UpdateLineNumbers()
        {
            //string cargotype = "";
            //string mmtype = "";
            string strlineno;
            string strsublineno;
            int i;
            string txtshipp = string.Empty;
          //  DataAccess.ForwardingImports.Lineno obj_da_lineobj = new DataAccess.ForwardingImports.Lineno();
             string Ccode = Convert.ToString(Session["Ccode"]);
            if (Ccode != "")
            {

                obj_da_lineobj.GetDataBase(Ccode);

            }

            try {
                for (i = 0; i <= grd_Line.Rows.Count - 1; i++)
                {
                    TextBox txtline = (TextBox)grd_Line.Rows[i].Cells[0].FindControl("txt_line");
                    TextBox txtsub = (TextBox)grd_Line.Rows[i].Cells[1].FindControl("txt_subline");
                    TextBox txthbl = (TextBox)grd_Line.Rows[i].Cells[2].FindControl("txt_hbl");
                    DropDownList ddlc = (DropDownList)grd_Line.Rows[i].Cells[4].FindControl("ddl_cargo");
                    DropDownList ddlmm = (DropDownList)grd_Line.Rows[i].Cells[5].FindControl("ddl_mm");
                    TextBox txtshippod=(TextBox)grd_Line.Rows[i].Cells[8].FindControl("txt_Shippod");
                    if (!string.IsNullOrEmpty(txtline.Text.ToString()) & txtline.Text.ToString() != "")
                    {
                        strlineno = txtline.Text.ToString();
                    }
                    else
                    {
                        strlineno = "";
                    }
                    if (!string.IsNullOrEmpty(txtshippod.Text.ToString()) & txtshippod.Text.ToString() != "")
                    {
                        txtshipp = txtshippod.Text.ToString();
                    }
                    else
                    {
                        txtshipp = "";
                    }
                    if (!string.IsNullOrEmpty(txtsub.Text.ToString()) & txtsub.Text.ToString() != "")
                    {
                        strsublineno = txtsub.Text.ToString();
                    }
                    else
                    {
                        strsublineno = "";
                    }
                    hid_strbl.Value = txthbl.Text.ToString();
                    //cargotype =  grd_Line.Rows[i].Cells[4].Text.ToString();
                    //mmtype =  grd_Line.Rows[i].Cells[5].Text.ToString();
                    
                    obj_da_lineobj.UpdateFILineNumber(Convert.ToInt32(txt_Job.Text), hid_strbl.Value, strlineno, strsublineno, ddlc.SelectedItem.Text, ddlmm.SelectedItem.Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                    obj_da_lineobj.UpdateFIBL(Convert.ToInt32(txt_Job.Text), Convert.ToInt32(Session["LoginBranchid"]), hid_strbl.Value, txtshipp);

                    ScriptManager.RegisterStartupScript(btn_Lineno, typeof(Button), "DataFound", "alertify.alert('Details Updated');", true);

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void grd_Job_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_Job, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_Job_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grd_Job.PageIndex = e.NewPageIndex;
                LoadJob();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_Job_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dtline = new DataTable();
                int index = grd_Job.SelectedRow.RowIndex;

                txt_Job.Text = grd_Job.Rows[index].Cells[0].Text.ToString();
                obj_dtline = obj_da_lineobj.GetBLDetails(Convert.ToInt32(txt_Job.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtline.Rows.Count > 0)
                {

                    grd_Line.DataSource = obj_dtline;
                    grd_Line.DataBind();
                    //DropDownList ddl1 = (DropDownList)grd_Line.FindControl("ddl_cargo");
                    DropDownList ddl1 = (DropDownList)grd_Line.Rows[0].Cells[4].FindControl("ddl_cargo");
                    DropDownList ddl2 = (DropDownList)grd_Line.Rows[0].Cells[5].FindControl("ddl_mm");
                    if (obj_dtline.Rows[0]["itemtype"].ToString() == "OT" | obj_dtline.Rows[0]["itemtype"].ToString() == "")
                    {
                        ddl1.SelectedValue = "0";
                    }
                    else
                    {
                        ddl1.SelectedValue = "1";
                    }
                    if (obj_dtline.Rows[0]["cargommt"].ToString() == "LC" | obj_dtline.Rows[0]["cargommt"].ToString() == "")
                    {
                        ddl2.SelectedValue = "0";
                    }
                    else if (obj_dtline.Rows[0]["cargommt"].ToString() == "TI")
                    {
                        ddl2.SelectedValue = "1";
                    }
                    else if (obj_dtline.Rows[0]["cargommt"].ToString() == "GC")
                    {
                        ddl2.SelectedValue = "2";
                    }
                    else if (obj_dtline.Rows[0]["cargommt"].ToString() == "TC")
                    {
                        ddl2.SelectedValue = "3";
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void grd_Line_PreRender(object sender, EventArgs e)
        {
            if (grd_Line.Rows.Count > 0)
            {
                grd_Line.UseAccessibleHeader = true;
                grd_Line.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}