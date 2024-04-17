using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace logix.HRM
{
    public partial class LOPDays : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.PayrollProcess obj_PP = new DataAccess.PayrollProcess();
        DataAccess.payroll.LopDetails LopObj = new DataAccess.payroll.LopDetails();
        DataTable obj_dt = new DataTable();
        int eid=0;
        DateTime dtfrom, dtto;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.QueryString.ToString().Contains("FormName"))
            //{
            //    string str_Uiid = "";
            //    str_Uiid = Request.QueryString["UIID"].ToString();
            //    Utility.Fn_CheckUserRights(str_Uiid, btn_update, btn_view);
            //}
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if (!IsPostBack)
            {

                ddl_Monrh.SelectedValue = (Convert.ToInt32((obj_da_Log.GetDate().Month))-1).ToString();//ddl_Monrh.Items.IndexOf(ddl_Monrh.Items.FindByValue(((obj_da_Log.GetDate().Month)).ToString()));
                txt_year.Text = obj_da_Log.GetDate().Year.ToString();
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "ddl_Monrh~txt_year";
                str_MsgLists = "Month~year";
                str_DataType = "DropDown~Integer";
                //btn_Get.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                str_CtrlLists = "txt_Empname~txt_lop~txt_day";
                str_MsgLists = "EmpName~LOP Day~Working Day";
                str_DataType = "String~Double~Double";
                btn_update.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");

                Grd_LOP.DataSource = new DataTable();
                Grd_LOP.DataBind();
            }

            if (txt_company.Text !="")
            {
                if(Grd_LOP.Rows.Count>0)
                {
                    btn_delete.Attributes["onclick"] = "return confirm('Are you sure you want to delete this " + hid_empcode.Value + " Employee Lopdays?');";
                }
                else
                {
                    btn_delete.Attributes["onclick"] = "return confirm('Are you sure you want to delete this " + (ddl_Monrh.SelectedIndex + 1) + " Month Lopdays?');";
                }
               
            }
            if (txt_company.Text == "")
            {
                if (Grd_LOP.Rows.Count > 0)
                {
                    btn_regenrate.Attributes["onclick"] = "return confirm('Are you sure you want to Regenrate this " + hid_empcode.Value + " Employee Lopdays?');";
                }
                else
                {
                    btn_regenrate.Attributes["onclick"] = "return confirm('Are you sure you want to Regenrate this " + (ddl_Monrh.SelectedIndex + 1) + " Month Lopdays?');";
                }

            }
            txt_year.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
            
        }




        protected void btn_Get_Click(object sender, EventArgs e)
        {
            Fn_GetDetail();
           // hid_get.Value = "Click";
        }
        private void Fn_GetDetail()
        {
            DateTime Dt_from, Dt_to;
            if (Convert.ToInt32( ddl_Monrh.SelectedValue) == 0)
            {
                Dt_from = DateTime.Parse("12/20/" + (int.Parse(txt_year.Text) - 1));
                Dt_to = DateTime.Parse((Convert.ToInt32( ddl_Monrh.SelectedValue)+1).ToString() + "/19/" + txt_year.Text);
            }
            else
            {
                Dt_from = DateTime.Parse(Convert.ToInt32(ddl_Monrh.SelectedValue).ToString() + "/20/" + txt_year.Text);
                Dt_to = DateTime.Parse((int.Parse(ddl_Monrh.SelectedValue.ToString()) + 1) + "/19/" + txt_year.Text);
            }
            DataAccess.payroll.LopDetails obj_da_LOP = new DataAccess.payroll.LopDetails();
            obj_dt = obj_da_LOP.SelLopDays(Dt_from, Dt_to);
            Grd_LOP.DataSource = obj_dt;
            Grd_LOP.DataBind();
            Session["Data"] = obj_dt;
            txt_day.Text = "";
            txt_lop.Text = "";
            txt_Empname.Text = "";
            txt_dept.Text = "";
            txt_desg.Text = "";
            //txt_year.Text = "";
            txt_company.Text = "";
            txt_Empname.Focus();
            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 796, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_Monrh.SelectedIndex + 1 + " - " + txt_year.Text + " Employee Code : " + hid_empcode.Value + "Get");
        }

        protected void Grd_LOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(Grd_LOP.SelectedRow.RowIndex);
            hid_index.Value = index.ToString();
            txt_company.Text = Grd_LOP.SelectedRow.Cells[1].Text + "," + Grd_LOP.SelectedRow.Cells[2].Text;
            txt_dept.Text = Grd_LOP.SelectedRow.Cells[8].Text.Replace("&amp;", "&");
            txt_desg.Text = Grd_LOP.SelectedDataKey.Values[2].ToString();
            txt_lop.Text = Grd_LOP.SelectedRow.Cells[6].Text;
            txt_day.Text = Grd_LOP.SelectedRow.Cells[7].Text;
            hid_empcode.Value = Grd_LOP.Rows[index].Cells[3].Text;
            txt_Empname.Text = Grd_LOP.SelectedDataKey.Values[1].ToString();
            hid_Empid.Value = Grd_LOP.SelectedDataKey.Values[0].ToString();
            btn_update.Enabled = true;
            Page_Load(sender,e);
        }


        [WebMethod]
        public static void GetEmpName(string Prefix)
        {


            DataTable obj_dt = new DataTable();
            if (HttpContext.Current.Session["Data"] != null)
            {
                obj_dt = (DataTable)HttpContext.Current.Session["Data"];
                var Result = obj_dt.AsEnumerable().Where(row => row.Field<string>("EmpName").StartsWith(Prefix.ToUpper())).ToList();
                if (Result.Count > 0)
                {
                    obj_dt = Result.CopyToDataTable();
                }
                else
                {
                    obj_dt = new DataTable();
                }
                HttpContext.Current.Session["ConditionData"] = obj_dt;
            }
        }

        [WebMethod]
        public static void GetDivName(string Prefix)
        {
            DataTable obj_dt = new DataTable();
            if (HttpContext.Current.Session["Data"] != null)
            {
                var Result = new List<DataRow>();
                obj_dt = (DataTable)HttpContext.Current.Session["Data"];
                string[] Str_Division = Prefix.Split(',');
                if (Str_Division.Length == 1)
                {
                    Result = obj_dt.AsEnumerable().Where(row => row.Field<string>("divsname").StartsWith(Prefix.ToUpper())).ToList();
                }
                else if (Str_Division.Length > 1)
                {
                    Result = obj_dt.AsEnumerable().Where(row => row.Field<string>("divsname") == Str_Division[0].ToUpper() &&
                        row.Field<string>("portname").StartsWith(Str_Division[1].ToUpper())
                        ).ToList();
                }
                if (Result.Count > 0)
                {
                    obj_dt = Result.CopyToDataTable();
                }
                else
                {
                    obj_dt = new DataTable();
                }
                HttpContext.Current.Session["ConditionData"] = obj_dt;
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            DataTable obj_dt = new DataTable();
            if (Session["ConditionData"] != null)
            {
                obj_dt = (DataTable)Session["ConditionData"];
            }
            Grd_LOP.DataSource = obj_dt;
            Grd_LOP.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
        }

        protected void btn_division_Click(object sender, EventArgs e)
        {
            DataTable obj_dt = new DataTable();
            if (Session["ConditionData"] != null)
            {
                obj_dt = (DataTable)Session["ConditionData"];
            }
            //var Result = obj_dt.AsEnumerable().Where(row => row.Field<string>("divsname").StartsWith(txt_Empname.Text.ToUpper())).ToList();
            //if (Result.Count > 0)
            //{
            //    obj_dt = Result.CopyToDataTable();
            //}
            //else
            //{
            //    obj_dt = new DataTable();
            //}
            Grd_LOP.DataSource = obj_dt;
            Grd_LOP.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "TxtDivFocus();", true);
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            if (Grd_LOP.Rows.Count > 0)
            {
                DataAccess.payroll.LopDetails obj_da_LOP = new DataAccess.payroll.LopDetails();
                if (double.Parse(txt_day.Text) > 31)
                {
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "HRM", "alertify.alert('Day Lessthan 31');", true);
                    txt_day.Focus();
                    return;
                }
                if (double.Parse(txt_lop.Text) > double.Parse(txt_day.Text))
                {
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "HRM", "alertify.alert('LOP Days Must be Less than Working Days');", true);
                    txt_lop.Focus();
                    return;
                }

                if (hid_Empid.Value.ToString().TrimEnd().Length > 0)
                {
                    int idnew = Convert.ToInt32(hid_index.Value);
                    int int_Empid = int.Parse(hid_Empid.Value.ToString());
                    Grd_LOP.Rows[idnew].Cells[6].Text = string.Format("{0:0.00}", txt_lop.Text);
                    Grd_LOP.Rows[idnew].Cells[7].Text =  string.Format("{0:0.00}",txt_day.Text);
                    obj_da_LOP.InsLopDays(int_Empid, (int.Parse(ddl_Monrh.SelectedValue.ToString()) + 1), int.Parse(txt_year.Text), decimal.Parse(txt_lop.Text), decimal.Parse(txt_day.Text));
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 796, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_Monrh.SelectedIndex + 1 + " - " + txt_year.Text + " Employee Code : " + hid_empcode.Value + " Update");
                    Fn_Clear();
                    Fn_GetDetail();


                }
            }
        }
        private void Fn_Clear()
        {
            txt_company.Text = "";
            txt_day.Text = "";
            txt_dept.Text = "";
            txt_desg.Text = "";
            txt_Empname.Text = "";
            txt_lop.Text = "";
            hid_Empid.Value = "";
            //btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                Fn_Clear();
                Session["ConditionData"] = null;
                Session["Data"] = null;
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                ddl_Monrh.SelectedIndex = ddl_Monrh.Items.IndexOf(ddl_Monrh.Items.FindByValue(obj_da_Log.GetDate().Month.ToString()));
                txt_year.Text = obj_da_Log.GetDate().Year.ToString();
                Grd_LOP.DataSource = new DataTable();
                Grd_LOP.DataBind();
            }
            else
            {
                this.Response.End();
            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Str_RptName = "Payroll//" + "rptHRLopday.rpt";
            //Str_sp = "{HRLopDays.lopmonth}=" + ddl_Monrh.SelectedIndex+1 + "and {HRLopDays.lopyear}=" + Convert.ToInt32( txt_year.Text  );
            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", Str_Script, true);
            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 796, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_Monrh.SelectedIndex + 1 + " - " + txt_year.Text + " Employee Code : " + hid_empcode.Value + " View");
            Session["str_sfs"] = Str_sf;
            Session["str_sp"] = Str_sp;
        }

        protected void Grd_LOP_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_LOP, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void Grd_LOP_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grd_LOP.PageIndex = e.NewPageIndex;
                Fn_GetDetail();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {

            checkdata();
            if(btn_delete.ToolTip=="Delete")
            {
                if (Grd_LOP.Rows.Count > 0)
                {
                    //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Do You Want Delete');", true);

                    eid = hrempobj.GetEmpId(hid_empcode.Value);
                    obj_PP.DelLopDaysEmployee(eid, Convert.ToInt32(ddl_Monrh.SelectedIndex + 1), Convert.ToInt32(txt_year.Text));
                    Fn_GetDetail();
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 796, 4, Convert.ToInt32(Session["LoginBranchid"]), ddl_Monrh.SelectedIndex + 1 + " - " + txt_year.Text + " Employee Code : " + Grd_LOP.Rows[0].Cells[3].Text.ToString());
                    ScriptManager.RegisterClientScriptBlock(btn_delete, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Record Deleted');", true);
                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Do You Want Delete');", true);
                    obj_PP.DelLopDaysEmployee(0, Convert.ToInt32(ddl_Monrh.SelectedIndex) + 1, Convert.ToInt32(txt_year.Text));
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 796, 4, Convert.ToInt32(Session["LoginBranchid"]), ddl_Monrh.SelectedIndex + 1 + " - " + txt_year.Text + " Month : " + (ddl_Monrh.SelectedIndex + 1).ToString() + " Deleted");
                    ScriptManager.RegisterClientScriptBlock(btn_delete, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Record Deleted');", true);
                    txt_day.Text = "";
                    txt_lop.Text = "";
                    txt_Empname.Text = "";
                    txt_dept.Text = "";
                    txt_desg.Text = "";
                    //txt_year.Text = "";
                    txt_company.Text = "";
                    txt_Empname.Focus();
                }
                Page_Load(sender, e);
            }
           
        }

        protected void btn_regenrate_Click(object sender, EventArgs e)
        {
            checkdata();
            if (btn_regenrate.ToolTip == "Regenrate")
            {
                if (Grd_LOP.Rows.Count > 0)
                {

                    eid = hrempobj.GetEmpId(hid_empcode.Value);
                    obj_PP.DelLopDaysEmployee(Convert.ToInt32(eid), Convert.ToInt32(ddl_Monrh.SelectedIndex) + 1, Convert.ToInt32(txt_year.Text));
                    if ((ddl_Monrh.SelectedIndex) == 0)
                    {
                        dtfrom = Convert.ToDateTime("12/20/" + (Convert.ToInt32(txt_year.Text) - 1).ToString());
                        dtto = Convert.ToDateTime((ddl_Monrh.SelectedIndex + 1).ToString() + "/19/" + txt_year.Text);
                    }
                    else
                    {
                        dtfrom = Convert.ToDateTime((ddl_Monrh.SelectedIndex).ToString() + "/20/" + txt_year.Text);
                        dtto = Convert.ToDateTime((ddl_Monrh.SelectedIndex + 1).ToString() + "/19/" + txt_year.Text);
                    }
                    LopObj.RegenlopDays4Emp(eid,dtfrom, dtto);
                    Fn_GetDetail();
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 796, 5, Convert.ToInt32(Session["LoginBranchid"]), ddl_Monrh.SelectedIndex + 1 + " - " + txt_year.Text + " Employee Code : " + hid_empcode.Value + " Regenerated");
                    ScriptManager.RegisterClientScriptBlock(btn_regenrate, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Record Regenerated Succcessfully');", true);
                }
                else
                {

                    obj_PP.DelLopDaysEmployee(0, Convert.ToInt32(ddl_Monrh.SelectedIndex) + 1, Convert.ToInt32(txt_year.Text));
                    Fn_GetDetail();
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 796, 5, Convert.ToInt32(Session["LoginBranchid"]), ddl_Monrh.SelectedIndex + 1 + " - " + txt_year.Text + " Month : " + ddl_Monrh.SelectedIndex + 1 + " Regenerated");
                    ScriptManager.RegisterClientScriptBlock(btn_regenrate, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Records Regenerated Successfully');", true);
                }
            }
        }

        public void checkdata()
        {
            if(ddl_Monrh.Text == "" )
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Month Cannot be Blank ');", true);
                ddl_Monrh.Focus();
                ddl_Monrh.Text = "";
            }
            else if(txt_year.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Year Cannot be Blank ');", true);
                txt_year.Focus();
                txt_year.Text = "";
            }
        }

        protected void ddl_Monrh_SelectedIndexChanged(object sender, EventArgs e)
        {

           
            for (int i = 0; i <= Grd_LOP.Rows.Count - 1;i++ )
            {
                Grd_LOP.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_LOP.DataBind();
            }
            txt_day.Text = "";
            txt_Empname.Text = "";
            txt_dept.Text = "";
            txt_desg.Text = "";
            txt_company.Text = "";
            txt_lop.Text = "";
            
            
        }

        protected void txt_year_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= Grd_LOP.Rows.Count - 1; i++)
            {
                Grd_LOP.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_LOP.DataBind();
            }
            txt_day.Text = "";
            txt_Empname.Text = "";
            txt_dept.Text = "";
            txt_desg.Text = "";
            txt_company.Text = "";
            txt_lop.Text = "";
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 796, "Job", "", "", Session["StrTranType"].ToString());

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