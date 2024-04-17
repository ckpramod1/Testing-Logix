using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class LWFGrade : System.Web.UI.Page
    {
        DataAccess.Payroll.LWF obj_da_LWF = new DataAccess.Payroll.LWF();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Clear);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_Save, btn_view,null);
            }
            if (!IsPostBack)
            {
                Grd_LWF.DataSource = new DataTable();
                Grd_LWF.DataBind();
                txt_Branch.Focus();
                //btn_Clear.Text = "Cancel";
                btn_Clear.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_Branch~hid_bid~txt_Grade~hid";
                str_MsgLists = "Branch~Branch~Grade~Grade";
                str_DataType = "String~AutoComplete~String~AutoComplete";
                btn_Save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
            }
        }
        private void Fn_LoadGrid()
        {
            DataTable obj_dt = new DataTable();
            if (txt_Branch.Text.TrimEnd().Length > 0)
            {
                obj_dt = obj_da_LWF.Getlwfgrade(int.Parse(hid_bid.Value.ToString()), int.Parse(hid_portid.Value.ToString()));
                Grd_LWF.DataSource = obj_dt;
                Grd_LWF.DataBind();
                Session["BranchData"] = obj_dt;
            }
        }

        protected void txt_Branch_TextChanged(object sender, EventArgs e)
        {
            Fn_LoadGrid();
            //btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Grd_LWF_SelectedIndexChanged(object sender, EventArgs e)
        {
            hid_Lg.Value = Grd_LWF.SelectedDataKey.Values[0].ToString();
            if (hid_confirm.Value.ToString() == "N")
            {
                txt_Grade.Text = Grd_LWF.SelectedRow.Cells[2].Text;
                //btn_Save.Text = "Update";
                btn_Save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
            }
            else if (hid_confirm.Value.ToString() == "Y")
            {
                obj_da_LWF.Dellwfgrade(int.Parse(hid_Lg.Value.ToString()));
                Fn_LoadGrid();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Details Deleted');", true);
            }
            //btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (Session["BranchData"] != null)
            {
                DataTable obj_dt = new DataTable();
                obj_dt = (DataTable)Session["BranchData"];

                int int_Count = obj_dt.AsEnumerable().Count(row => row.Field<string>("grade") == txt_Grade.Text.Trim());
                if (int_Count != 0)
                {
                    ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Cannot Insert Grade');", true);
                    txt_Grade.Text = "";
                    txt_Grade.Focus();
                    return;
                }
            }
            if (btn_Save.ToolTip == "Save")
            {
                obj_da_LWF.Inslwfgrade(int.Parse(hid_bid.Value.ToString()), txt_Grade.Text, int.Parse(hid_portid.Value.ToString()));
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1004, 1, int.Parse(Session["LoginBranchid"].ToString()), hid_bid.Value.ToString() + "/S");
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
            }
            else if (btn_Save.ToolTip == "Update")
            {
                obj_da_LWF.Updlwfgrade(int.Parse(hid_bid.Value.ToString()), txt_Grade.Text, int.Parse(hid_portid.Value.ToString()), int.Parse(hid_Lg.Value.ToString()));
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1004, 2, int.Parse(Session["LoginBranchid"].ToString()), hid_bid.Value.ToString() + "/U");
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
            }
            Fn_Clear();
            Fn_LoadGrid();
            //btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }
        private void Fn_Clear()
        {
            txt_Branch.Focus();
            txt_Grade.Text = "";
            //btn_Save.Text = "Save";
            btn_Save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            Grd_LWF.DataSource = new DataTable();
            Grd_LWF.DataBind();
        
        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            if (btn_Clear.ToolTip == "Cancel")
            {
                txt_Branch.Text = "";
                Fn_Clear();
                //btn_Clear.Text = "Back";
                btn_Clear.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                txt_Branch.Focus();
            }
            else
            {
                this.Response.End();
            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            Str_RptName = "/Payroll/" + "rptLWF.rpt";
            if (txt_Branch.Text.TrimEnd().Length > 0)
            {
                Str_sf = "{LWFGrade.Branch}=" + hid_bid.Value.ToString();
            }
            
            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1004, 3, int.Parse(Session["LoginBranchid"].ToString()),"View");
            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", Str_Script, true);
            Session["str_sfs"] = Str_sf;
            Session["str_sp"] = Str_sp;
            //btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Grd_LWF_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_LWF, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
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
            GridViewlog.Visible = true;
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1004, "Job", "", "", Session["StrTranType"].ToString());

            //if (txt_jobno.Text != "")
            //{
            //    JobInput.Text = txt_jobno.Text;
            //}

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

    }
}