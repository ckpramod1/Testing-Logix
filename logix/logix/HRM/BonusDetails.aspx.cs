using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class BonusDetails : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Payroll.BonusDetails obj_da_Bonus = new DataAccess.Payroll.BonusDetails();
        DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
        int divid = 0;
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
                Utility.Fn_CheckUserRights(str_Uiid, btn_Save, null,null);
            }
            if (!IsPostBack)
            {
                Grd_Bonus.DataSource = new DataTable();
                Grd_Bonus.DataBind();
                Fn_LoadYear();
                //btn_Clear.Text = "Cancel";
                btn_Clear.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                Fn_LoadDivision();
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "ddl_company~txt_percentage";
                str_MsgLists = "Company~Percentage";
                str_DataType = "String~Double";
                btn_Save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                btn_Generate.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
               
            }
        }
        private void Fn_LoadYear()
        {
            DateTime Dt_Date = obj_da_Log.GetDate();
            ddl_Year.Items.Clear();
            for (int i = 2008; i <= Dt_Date.Year; i++)
            {
                ddl_Year.Items.Add(new ListItem(i.ToString() + "-" + (i + 1).ToString(), i.ToString()));
            }
            if (Dt_Date.Month > 4)
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.Year.ToString()));
            }
            else
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.AddYears(-1).Year.ToString()));
            }
        }
        public void Fn_LoadDivision()
        {
            ddl_company.Items.Clear();
            ddl_company.Items.Add("");
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.GetDivisionhrm("HR");
            ddl_company.DataSource = obj_dt;
            ddl_company.DataTextField = "divisionname";
            ddl_company.DataValueField = "divisionid";
            ddl_company.DataBind();
        }

        protected void btn_Generate_Click(object sender, EventArgs e)
        {
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Bonus.GetHRBasic4Bonus(int.Parse(ddl_Year.SelectedValue.ToString()), int.Parse(ddl_company.SelectedValue.ToString()), 'S');

            DataColumn Dc = new DataColumn();
            Dc.ColumnName = "bonusamt";
            Dc.DataType = typeof(double);
            obj_dt.Columns.Add(Dc);
            double Percentage = double.Parse(txt_percentage.Text);

            foreach (DataRow dr in obj_dt.Rows)
            {
                dr["bonusamt"] = (double.Parse(dr["basic"].ToString()) * Percentage) / 100;
            }
            Grd_Bonus.DataSource = obj_dt;
            Grd_Bonus.DataBind();
            //btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        private void Fn_LoadGrid()
        {
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Bonus.GetHRBonusDtls(int.Parse(ddl_Year.SelectedValue.ToString()), int.Parse(ddl_company.SelectedValue.ToString()), 'S');
            if (obj_dt.Rows.Count > 0)
            {
                txt_percentage.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["percentage"]);
                Grd_Bonus.DataSource = obj_dt;
                Grd_Bonus.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Already Details Saved for this Financial Year');", true);
                //btn_Generate.Text = "Re-Generate";
                btn_Generate.ToolTip = "Re-Generate";
                btn_generate1.Attributes["class"] = "btn btn-generate1";
                //btn_Save.Text = "Update";
                btn_Save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
            }
            else
            {
                Fn_SaveClear();
            }
            //btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }
        private void Fn_SaveClear()
        {
            //btn_Generate.Text = "Generate";
            btn_Generate.ToolTip = "Generate";
            btn_generate1.Attributes["class"] = "btn btn-generate1";
            //btn_Save.Text = "Save";
            btn_Save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            txt_percentage.Text = "";
            Grd_Bonus.DataSource = new DataTable();
            Grd_Bonus.DataBind();
        }
        private void Fn_Clear()
        {
            ddl_company.SelectedIndex = 0;
            ddl_Year.SelectedIndex = 0;
            Fn_LoadYear();
            Fn_SaveClear();
            
        }
        protected void ddl_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Year.SelectedIndex != 0 && ddl_company.SelectedIndex != 0)
            {
                Fn_LoadGrid();
                //btn_Clear.Text = "Cancel";
                btn_Clear.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            int int_year, int_Empid;
            int_year = int.Parse(ddl_Year.SelectedValue.ToString());
            double Percentage;
            decimal Amount;
            Percentage = double.Parse(txt_percentage.Text);

            if (btn_Save.ToolTip == "Save")
            {

                foreach (GridViewRow row in Grd_Bonus.Rows)
                {
                    int_Empid = int.Parse(Grd_Bonus.DataKeys[row.RowIndex].Values[0].ToString());
                    Amount = decimal.Parse(row.Cells[3].Text.ToString());
                    obj_da_Bonus.DelBnsDtls(int_Empid, int_year);
                    obj_da_Bonus.InsBnsDtls(int_Empid, int_year, Amount, Percentage);
                }
                if (Grd_Bonus.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 975, 1, int.Parse(Session["LoginBranchid"].ToString()), int_year + "/S");
                }
            }
            else if (btn_Save.ToolTip == "Update")
            {
                foreach (GridViewRow row in Grd_Bonus.Rows)
                {
                    int_Empid = int.Parse(Grd_Bonus.DataKeys[row.RowIndex].Values[0].ToString());
                    Amount = decimal.Parse(row.Cells[3].Text.ToString());
                    obj_da_Bonus.UpdBnsDtls(int_Empid, int_year, Amount, Percentage);
                }
                if (Grd_Bonus.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 975, 2, int.Parse(Session["LoginBranchid"].ToString()), int_year + "/U");
                }
            }
            Fn_Clear();
            //btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            if (btn_Clear.ToolTip == "Cancel")
            {
                Fn_Clear();
                //btn_Clear.Text = "Back";
                btn_Clear.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
        }

        protected void Grd_Bonus_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Bonus, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ddl_company_SelectedIndexChanged(object sender, EventArgs e)
        {
           // divid = da_obj_HrEmp.GetDivisionId(ddl_company.SelectedItem.ToString());
            Fn_LoadGrid();
            //btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Clear";
            btn_cancel1.Attributes["class"] = "btn btn-clear1";
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 975, "Job", "", "", Session["StrTranType"].ToString());

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