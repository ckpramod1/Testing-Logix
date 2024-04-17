using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace logix.Maintenance
{
    public partial class Changejobclosedate : System.Web.UI.Page
    {
        DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
        int int_Mont;
        string str_modulename;
        string str_tablename;
        string mnthname = "";
        string str_name;
        int int_jobno;
        string str_year;
        string Ctrl_List, Msg_List, Dtype_List;

        string mname = "";
        int intMonth, i;
        string str_Uiid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (IsPostBack != true)
            {
                Ctrl_List = ddl_cmbDivision.ID + "~" + ddl_cmbBranch.ID + "~" + ddl_cmbModule.ID + "~" + txt_user.ID + "~" + ddl_cmbMonth.ID;
                Msg_List = "Division~Branch~Module~Requested By~Closed Month";
                Dtype_List = "Dropdownlist~Dropdownlist~Dropdownlist~string~Dropdownlist";
                btn_update.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                btn_Unclsjob.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");

                DivisionBind();
                BranchBind();
                LoadModule();
                GetMonth();
                txt_dtNewClose.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());
                txt_dtpYear.Text = da_obj_Logobj.GetDate().Year.ToString();
                Empty_Grid();
                str_Uiid = Request.QueryString["type"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_update, null, null);
                txt_dtNewClose.Focus();
            }
        }
        [WebMethod]
        public static List<string> GetEmployeename(string prefix)
        {
            List<string> gname = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.HR.FrontPage da_obj_HRFrontObj = new DataAccess.HR.FrontPage();
            obj_dt = da_obj_HRFrontObj.GetLikeEmpName(prefix.ToUpper());
            gname = Utility.Fn_DatatableToList_int16(obj_dt, "empnamecode", "employeeid");
            return gname;
        }
        private void DivisionBind()
        {
            DataAccess.HR.Employee da_obj_HREmpobj = new DataAccess.HR.Employee();
            DataTable Dt_dat = new DataTable();

            //ddl_cmbDivision.Items.Add("Division");
            Dt_dat = da_obj_HREmpobj.GetDivision();
            for (int i = 0; i <= Dt_dat.Rows.Count - 1; i++)
            {
                ddl_cmbDivision.Items.Add(Dt_dat.Rows[i]["divisionname"].ToString());
            }
        }
        private void BranchBind()
        {
            DataAccess.Masters.MasterPort da_obj_PortObj = new DataAccess.Masters.MasterPort();
            DataTable dt = new DataTable();
            ddl_cmbBranch.Items.Add("");
            dt = da_obj_PortObj.GetAllBranchNameforPortName();

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                ddl_cmbBranch.Items.Add(dt.Rows[i]["portname"].ToString());
            }

        }
        private void Empty_Grid()
        {
            DataTable dt_new = new DataTable();
            grd_change.DataSource = dt_new;
            grd_change.DataBind();
        }
        private void LoadModule()
        {
            //ddl_cmbModule.Items.Add("Module");
            ddl_cmbModule.Items.Add("Air Exports");
            ddl_cmbModule.Items.Add("Air Imports");
            ddl_cmbModule.Items.Add("Bonded Trucking");
            ddl_cmbModule.Items.Add("Custom House Agent");
            ddl_cmbModule.Items.Add("Forwarding Exports");
            ddl_cmbModule.Items.Add("Forwarding Imports");
        }

        protected void txt_user_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddl_cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccess.HR.Employee da_obj_HREmpobj = new DataAccess.HR.Employee();
            hf_divisionid.Value = da_obj_HREmpobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue)).ToString();
        }

        protected void ddl_cmbModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_cmbModule.SelectedValue == "Air Exports" || ddl_cmbModule.SelectedValue == "Air Imports")
                {
                    hf_str_name.Value = "Flight # And Date";
                }
                else if (ddl_cmbModule.SelectedValue == "Forwarding Exports" || ddl_cmbModule.SelectedValue == "Forwarding Imports")
                {
                    hf_str_name.Value = "Vesl & Voy";
                }
                else if (ddl_cmbModule.SelectedValue == "Custom House Agent")
                {
                    hf_str_name.Value = "Mode";
                }
                else if (ddl_cmbModule.SelectedValue == "Bonded Trucking")
                {
                    hf_str_name.Value = "Truck#";
                }
                if (ddl_cmbMonth.SelectedIndex != 0)
                {
                    getDetails();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 

        }

        private void getDetails()
        {
            DataAccess.CloseJobs da_obj_jobcloseobj = new DataAccess.CloseJobs();
            DataTable obj_dtEmp = new DataTable();
            DataTable dt_Details = new DataTable();
            gettablename();
            str_year = txt_dtpYear.Text.ToString();
            if (hf_intbranchid.Value != "")
            {
                dt_Details = da_obj_jobcloseobj.GetJobDetails4datechange(Convert.ToInt32(hf_intbranchid.Value), Convert.ToInt32(hf_inti.Value), Convert.ToString(str_modulename));
            }
            if (dt_Details.Rows.Count > 0)
            {
                obj_dtEmp.Columns.Add("jobno");
                obj_dtEmp.Columns.Add("Column1");
                obj_dtEmp.Columns.Add("jobclosedate");

                DataRow dr;

                for (int i = 0; i <= dt_Details.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["jobno"] = dt_Details.Rows[i][0].ToString();
                    dr["Column1"] = dt_Details.Rows[i][1].ToString();
                    dr["jobclosedate"] = dt_Details.Rows[i][1].ToString();

                }
                grd_change.DataSource = obj_dtEmp;
                Session["Date"] = obj_dtEmp;
                grd_change.DataBind();

            }
            if (grd_change.Rows.Count > 0)
            {
                if (hf_str_name.Value == "Flight # And Date")
                {
                    grd_change.HeaderRow.Cells[1].Text = "Flight # And Date";
                }
                else if (hf_str_name.Value == "Vesl & Voy")
                {
                    grd_change.HeaderRow.Cells[1].Text = "Vesl & Voy";
                }
                else if (hf_str_name.Value == "Mode")
                {
                    grd_change.HeaderRow.Cells[1].Text = "Mode";
                }
                else if (hf_str_name.Value == "Truck#")
                {
                    grd_change.HeaderRow.Cells[1].Text = "Truck#";
                }
            }

        }

        protected void ddl_cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccess.HR.Employee da_obj_HREmpobj = new DataAccess.HR.Employee();
            hf_intbranchid.Value = da_obj_HREmpobj.GetBranchId(Convert.ToInt32(da_obj_HREmpobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbBranch.SelectedValue)).ToString();
        }

        private void GetMonth()
        {
            for (intMonth = 1; intMonth <= 12; intMonth++)
            {
               
                DateTime dtDate = new DateTime(2000, intMonth, 1);
                mname = dtDate.ToString("MMM");
               // ddl_cmbBranch.Items.Add("Month");
                ddl_cmbMonth.Items.Add(mname);

            }
            hf_intmonth.Value = Convert.ToString(ddl_cmbMonth.Items.Count - 1);
        }

        private void gettablename()
        {
            getmodule();
            if (str_modulename == "FE")
            {
                str_tablename = "FEJobInfo";
            }
            else if (str_modulename == "FI")
            {
                str_tablename = "FIJobInfo";
            }
            else if (str_modulename == "AE")
            {
                str_tablename = "AEJobInfo";
            }
            else if (str_modulename == "AI")
            {
                str_tablename = "AIJobInfo";
            }
            else if (str_modulename == "CH")
            {
                str_tablename = "CHJobInfo";
            }
            else if (str_modulename == "BT")
            {
                str_tablename = "BTJobInfo";
            }

        }

        public object getmodule()
        {
            if (ddl_cmbModule.SelectedValue == "Forwarding Exports")
            {
                str_modulename = "FE";
            }
            else if (ddl_cmbModule.SelectedValue == "Forwarding Imports")
            {
                str_modulename = "FI";
            }
            else if (ddl_cmbModule.SelectedValue == "Air Exports")
            {
                str_modulename = "AE";
            }
            else if (ddl_cmbModule.SelectedValue == "Air Imports")
            {
                str_modulename = "AI";
            }
            else if (ddl_cmbModule.SelectedValue == "Custom House Agent")
            {
                str_modulename = "CH";
            }
            else if (ddl_cmbModule.SelectedValue == "Bonded Trucking")
            {
                str_modulename = "BT";
            }
            return str_modulename;
        }

        protected void ddl_cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_cmbMonth.SelectedIndex != 0)
                {
                    hf_inti.Value = DateTime.ParseExact(ddl_cmbMonth.SelectedValue, "MMM", CultureInfo.CurrentCulture).Month.ToString();
                    getDetails();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 

        }

        protected void btn_Unclsjob_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.CloseJobs da_obj_jobcloseobj = new DataAccess.CloseJobs();

                Boolean bol_check = false;
                for (int f = 0; f < grd_change.Rows.Count; f++)
                {
                    CheckBox check;
                    check = (CheckBox)(grd_change.Rows[f].FindControl("grdblselect"));
                    if (check.Checked == true)
                    {
                        bol_check = true;
                    }
                }
                if (!bol_check)
                {
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Select atleast anyone Job#');", true);
                    return;
                }


                foreach (GridViewRow row in grd_change.Rows)
                {
                    int_jobno = int.Parse(grd_change.DataKeys[row.RowIndex].Values[0].ToString());
                    if (((CheckBox)row.Cells[3].FindControl("grdblselect")).Checked)
                    {
                        getmodule();
                        str_year = txt_dtpYear.Text.ToString();
                        string str_dat = Utility.fn_ConvertDate(txt_dtNewClose.Text);
                        da_obj_jobcloseobj.UpdateJobCloseNull(Convert.ToInt32(hf_intbranchid.Value), Convert.ToInt32(hf_divisionid.Value), Convert.ToInt32(int_jobno), Convert.ToInt32(hf_intmonth.Value), Convert.ToString(str_year), Convert.ToString(str_modulename));
                        da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 398, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Reqby-" + Convert.ToInt32(hf_employeeid.Value) + " " + Convert.ToString(str_modulename) + "-" + Convert.ToInt32(int_jobno) + " " + "jbrunclose-" + Convert.ToInt32(hf_intbranchid.Value));
                        ScriptManager.RegisterStartupScript(btn_update, typeof(TextBox), "Outstanding", "alertify.alert('Job has Unclosed');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 

        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.CloseJobs da_obj_jobcloseobj = new DataAccess.CloseJobs();
                Boolean bol_check = false;
                for (int f = 0; f < grd_change.Rows.Count; f++)
                {
                    CheckBox check;
                    check = (CheckBox)(grd_change.Rows[f].FindControl("grdblselect"));
                    if (check.Checked == true)
                    {
                        bol_check = true;
                    }
                }
                if (!bol_check)
                {
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Select atleast anyone Job#');", true);
                    return;
                }

                foreach (GridViewRow row in grd_change.Rows)
                {
                    int_jobno = int.Parse(grd_change.DataKeys[row.RowIndex].Values[0].ToString());
                    if (((CheckBox)row.Cells[3].FindControl("grdblselect")).Checked)
                    {
                        gettablename();
                        da_obj_jobcloseobj.UpdateJobClosedate(Convert.ToInt32(hf_intbranchid.Value), Convert.ToDateTime(Utility.fn_ConvertDate(txt_dtNewClose.Text)), Convert.ToString(str_modulename), Convert.ToInt32(int_jobno));
                        da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 398, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Reqby-" + Convert.ToInt32(hf_employeeid.Value) + " " + Convert.ToString(str_modulename) + "-" + Convert.ToInt32(int_jobno) + " " + "jbr-" + Convert.ToInt32(hf_intbranchid.Value));
                        ScriptManager.RegisterStartupScript(btn_update, typeof(TextBox), "Outstanding", "alertify.alert('JobClosed Date Updated');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if(btn_back.ToolTip=="Cancel")
            {
                txt_dtpYear.Focus();
                txtclear();
                Empty_Grid();
               // btn_back.Text = "Back";


                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";

                txt_dtNewClose.Focus();
            }else
            {
                this.Response.End();
            }
        }
        private void txtclear()
        {
            ddl_cmbDivision.SelectedIndex = -1;
            txt_user.Text = "";
            ddl_cmbModule.SelectedIndex = -1;
            ddl_cmbMonth.SelectedIndex = -1;
            ddl_cmbBranch.SelectedIndex = -1;
            grd_change.DataSource = null;
            grd_change.DataBind();

            txt_dtNewClose.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());

        }
    }
}