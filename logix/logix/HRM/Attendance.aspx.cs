using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace logix.HRM
{
    public partial class Attendance : System.Web.UI.Page
    {
        DataAccess.Masters.MasterEmployee EmpObj = new DataAccess.Masters.MasterEmployee();
        DataAccess.HR.Employee PIObj = new DataAccess.HR.Employee();
        DataTable dt = new DataTable();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.HR.Attendance atobj = new DataAccess.HR.Attendance();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataTable attdt = new DataTable();
        DateTime dtoj;
        int empid;
        DataTable Dt_Det = new DataTable();
        string fnstatus, anstatus;
        string fnstatus1, anstatus1;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);
            try { 
            if (!IsPostBack)
            {
                Fillbranch();
                Get_Dept();
                Get_Division();
                Empty_grid();
                txtAttendanceDate.Text = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
            }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          

        }


        protected void Empty_grid()
        {
            grd.DataSource = Utility.Fn_GetEmptyDataTable();
            grd.DataBind();
        }

        protected void Get_Division()
        {
            dt = PIObj.GetDivision("M");
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                ddlCompany.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        protected void Get_Dept()
        {
            dt = EmpObj.GetDept();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                ddlDepartment.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        protected void Fillbranch()
        {
            dt = portobj.GetAllBranchNameforPortName();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    ddlbranch.Items.Add(dt.Rows[i]["portname"].ToString());
                }
            }
        }

        protected void Get_Details_Emp()
        {
            try
            {
            attdt = atobj.GetEmpForAttendance(ddlCompany.Text, ddlbranch.Text, ddlDepartment.Text, Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtAttendanceDate.Text)));
            DataTable dtTemp = new DataTable();
            if (attdt.Rows.Count > 0)
            {
                for (int i = 0; i <= grd.Rows.Count - 1; i++)
                {
                    grd.DataSource = Utility.Fn_GetEmptyDataTable();
                    grd.DataBind();
                }


                dtTemp.Columns.Add("Code");
                dtTemp.Columns.Add("Name");
                dtTemp.Columns.Add("Department");
                dtTemp.Columns.Add("Designation");
                dtTemp.Columns.Add("D.O.J");
                dtTemp.Columns.Add("FN");
                dtTemp.Columns.Add("AN");
                DataRow dr = dtTemp.NewRow();
                //  dtTemp.Rows.Add(dr);

                for (int i = 0; i <= attdt.Rows.Count - 1; i++)
                {
                    dr = dtTemp.NewRow();
                    dtTemp.Rows.Add(dr);
                    dtTemp.Rows[i][0] = attdt.Rows[i]["empcode"].ToString();
                    dtTemp.Rows[i][1] = attdt.Rows[i]["empname"].ToString();
                    dtTemp.Rows[i][2] = attdt.Rows[i]["deptname"].ToString();
                    dtTemp.Rows[i][3] = attdt.Rows[i]["designame"].ToString();
                    //dtoj = Convert.ToDateTime();
                    dtTemp.Rows[i][4] = Utility.fn_ConvertDate(attdt.Rows[i]["doj"].ToString());//dtoj.ToString();
                    

                    //btnCancel.Text = "Cancel";
                    btnCancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    btnUpdate.Visible = true;
                    grd.DataSource = dtTemp;
                    grd.DataBind();
                    
                }
                for (int i = 0; i <= attdt.Rows.Count - 1; i++)
                {
                    fnstatus = attdt.Rows[i]["fnstatus"].ToString();
                    anstatus = attdt.Rows[i]["anstatus"].ToString();
                    DropDownList ddl = (DropDownList)grd.Rows[i].FindControl("ddlFn");
                    DropDownList ddlan = (DropDownList)grd.Rows[i].FindControl("ddlAn");
                    if (fnstatus == "P")
                    {
                        
                        //ddl.SelectedIndex = 0;
                        //dtTemp.Rows[i][5] = "Present";
                        ((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text = "Present";
                    }
                    else if (fnstatus == "A")
                    {
                        ((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text = "Absent";
                        //ddl.SelectedValue = "1";
                        //dtTemp.Rows[i][5] = "Absent";
                          //ddl.SelectedItem.Text = "Absent"; 
                    }
                    else if (fnstatus == "C")
                    {
                        //ddl.SelectedIndex = 2;
                        //dtTemp.Rows[i][5] = "CL";
                        ((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text = "CL";
                    }
                    else if (fnstatus == "S")
                    {
                        //ddl.SelectedIndex = 3;
                        //dtTemp.Rows[i][5] = "SL";
                        ((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text = "SL";

                    }
                    else if (fnstatus == "E")
                    {
                        //ddl.SelectedIndex = 4;
                        //dtTemp.Rows[i][5] = "EL";
                        ((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text = "EL";
                    }

                    else if (fnstatus == "T")
                    {
                        //ddl.SelectedIndex = 5;
                        //dtTemp.Rows[i][5] = "LTA";
                        ((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text = "LTA";
                    }
                    else if (fnstatus == "O")
                    {
                        //ddl.SelectedIndex = 6;
                        //dtTemp.Rows[i][5] = "OD";
                        ((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text = "OD";
                    }
                    else if (fnstatus == "F")
                    {
                        //ddl.SelectedIndex = 7;
                        //dtTemp.Rows[i][5] = "OFF";
                        ((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text = "OFF";
                    }

                    else if (fnstatus == "X")
                    {
                        //ddl.SelectedIndex = 8;
                        //dtTemp.Rows[i][5] = "LOP";
                        ((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text = "LOP";
                    }

                    if (anstatus == "P")
                    {

                        ((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text = "Present";
                        //dtTemp.Rows[i][6] = "Present";
                        //ddlan.SelectedItem.Text = "Present";
                    }
                    else if (anstatus == "A")
                    {
                        //ddl.SelectedIndex = 1;
                        //dtTemp.Rows[i][6] = "Absent";
                        ((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text = "Absent";
                    }
                    else if (anstatus == "C")
                    {
                        //ddl.SelectedIndex = 2;
                        //dtTemp.Rows[i][6] = "CL";
                        ((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text = "CL";
                    }
                    else if (anstatus == "S")
                    {
                        //DropDownList ddl = (DropDownList)grd.Rows[row.RowIndex].FindControl("ddlAn");
                        //ddl.SelectedIndex = 3;
                        //dtTemp.Rows[i][5] = "SL";
                        ((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text = "SL";
                    }
                    else if (anstatus == "E")
                    {
                        //DropDownList ddl = (DropDownList)grd.Rows[row.RowIndex].FindControl("ddlAn");
                        //ddl.SelectedIndex = 4;
                        //dtTemp.Rows[i][6] = "EL";
                        ((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text = "EL";
                    }

                    else if (anstatus == "T")
                    {
                        //DropDownList ddl = (DropDownList)grd.Rows[row.RowIndex].FindControl("ddlAn");
                        //ddl.SelectedIndex = 5;
                        //dtTemp.Rows[i][6] = "LTA";
                        ((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text = "LTA";
                    }
                    else if (anstatus == "O")
                    {
                        //DropDownList ddl = (DropDownList)grd.Rows[row.RowIndex].FindControl("ddlAn");
                        //ddl.SelectedIndex = 6;
                        //dtTemp.Rows[i][5] = "OD";
                        ((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text = "OD";
                    }
                    else if (fnstatus == "F")
                    {
                        //DropDownList ddl = (DropDownList)grd.Rows[row.RowIndex].FindControl("ddlAn");
                        //ddl.SelectedIndex = 7;
                        //dtTemp.Rows[i][6] = "OFF";
                        ((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text = "OFF";
                    }

                    else if (anstatus == "X")
                    {
                        //DropDownList ddl = (DropDownList)grd.Rows[row.RowIndex].FindControl("ddlAn");
                        //ddl.SelectedIndex = 8;
                        //dtTemp.Rows[i][6] = "LOP";
                        ((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text = "LOP";
                    }
                    //btnCancel.Text = "Cancel";
                    btnCancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    btnUpdate.Visible = true;
                    //grd.DataSource = dtTemp;
                    //grd.DataBind();

                   
                }
            }
            else
            {
                DateTime dta = logobj.GetDate();

                dtTemp.Columns.Add("Code");
                dtTemp.Columns.Add("Name");
                dtTemp.Columns.Add("Department");
                dtTemp.Columns.Add("Designation");
                dtTemp.Columns.Add("D.O.J");
                dtTemp.Columns.Add("FN");
                dtTemp.Columns.Add("AN");
                DataRow dr = dtTemp.NewRow();
                if (Convert.ToDateTime(Utility.fn_ConvertDate(txtAttendanceDate.Text)) <= dta)
                {
                    if (attdt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= grd.Rows.Count - 1; i++)
                        {
                            grd.DataSource = Utility.Fn_GetEmptyDataTable();
                            grd.DataBind();
                        }

                        dtTemp.Rows.Add(dr);
                        for (int i = 0; i <= attdt.Rows.Count - 1; i++)
                        {
                            dtTemp.Rows.Add(dr);
                            dtTemp.Rows[i][0] = attdt.Rows[i]["empcode"].ToString();
                            dtTemp.Rows[i][1] = attdt.Rows[i]["empname"].ToString();
                            dtTemp.Rows[i][2] = attdt.Rows[i]["deptname"].ToString();
                            dtTemp.Rows[i][3] = attdt.Rows[i]["designame"].ToString();
                            //dtoj = Convert.ToDateTime(attdt.Rows[i]["doj"].ToString());
                            dtTemp.Rows[i][4] = Utility.fn_ConvertDate(attdt.Rows[i]["doj"].ToString()); //dtoj.ToString();
                            dtTemp.Rows[i][5] = "Present";
                            dtTemp.Rows[i][6] = "Present";
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= grd.Rows.Count - 1; i++)
                        {
                            grd.DataSource = Utility.Fn_GetEmptyDataTable();
                            grd.DataBind();
                        }
                    }
                    //btnCancel.Text = "Cancel";
                    btnCancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    btnUpdate.Visible = true;


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Attendance.aspx", "alertify.alert('Details Not Exist');", true);
                    btnUpdate.Visible = false;
                }
                grd.DataSource = dtTemp;
                grd.DataBind();

            }


            //foreach (GridViewRow row in grd.Rows)
            //{
            //    DropDownList ddl = (DropDownList)grd.Rows[row.RowIndex].FindControl("ddlAn");

            //}
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            if (ddlbranch.Text.Trim() != "" && ddlCompany.Text.Trim() != "" && ddlDepartment.Text.Trim() != "")
            {
                Get_Details_Emp();
            }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
            if (Convert.ToDateTime(Utility.fn_ConvertDate(txtAttendanceDate.Text)) > logobj.GetDate())
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Attendance.aspx", "alertify.alert('Selected Date Must be Lessthan Or Equal to Current Date');", true);
                txtAttendanceDate.Focus();
            }

            Dt_Det = atobj.SelAllEmpAttendance(Convert.ToDateTime(Utility.fn_ConvertDate(txtAttendanceDate.Text)));
            if (Dt_Det.Rows.Count == 0)
            {
                DateTime dd = Convert.ToDateTime(Utility.fn_ConvertDate(txtAttendanceDate.Text));
                //int dd1 = int.Parse(dd.DayOfWeek.ToString());
                int dd1 = (int)dd.DayOfWeek;
                if (dd1 == 0)
                {
                    this.PopUpService.Show();
                    Get_Method();
                }
                else
                {
                    atobj.InsAllEmpAttendance(Convert.ToDateTime(Utility.fn_ConvertDate(txtAttendanceDate.Text)));
                    Get_Method();
                }
            }

            Get_Method();
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }

        protected void btn_GRD_Click(object sender, EventArgs e)
        {
            atobj.InsAllEmpAttendance(Convert.ToDateTime(Utility.fn_ConvertDate(txtAttendanceDate.Text)));
        }

        protected void btn_GRD_No_Click(object sender, EventArgs e)
        {

        }

        protected void Get_Method()
        {
            try
            {
            if (ddlCompany.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Attendance.aspx", "alertify.alert('Division Cannot be Blank');", true);
                ddlCompany.Focus();
                ddlCompany.Text = "";
            }
            if (ddlbranch.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Attendance.aspx", "alertify.alert('Branch Cannot be Blank');", true);
                ddlbranch.Focus();
                ddlbranch.Text = "";
            }
            if (ddlDepartment.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Attendance.aspx", "alertify.alert('Department Cannot be Blank');", true);
                ddlDepartment.Focus();
                ddlDepartment.Text = "";
            }

            for (int i = 0; i <= grd.Rows.Count - 1; i++)
            {
                empid = EmpObj.GetEmpid((grd.Rows[i].Cells[0].Text.ToString()));
                DropDownList ddl = (DropDownList)grd.Rows[i].FindControl("ddlFn");
                if (((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text == "Present")
                {
                    fnstatus = "P";
                }
                else if (((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text == "Absent")
                {
                    fnstatus = "A";
                }
                else if (((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text == "CL")
                {
                    fnstatus = "C";
                }
                else if (((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text == "SL")
                {
                    fnstatus = "S";
                }
                else if (((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text == "EL")
                {
                    fnstatus = "E";
                }
                else if (((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text == "LTA")
                {
                    fnstatus = "T";
                }
                else if (((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text == "OD")
                {
                    fnstatus = "O";
                }
                else if (((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text == "OFF")
                {
                    fnstatus = "F";
                }

                else if (((DropDownList)grd.Rows[i].FindControl("ddlFn")).SelectedItem.Text == "LOP")
                {
                    fnstatus = "X";
                }

                DropDownList ddl1 = (DropDownList)grd.Rows[i].FindControl("ddlAn");

                if (((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text == "Present")
                {
                    anstatus = "P";
                }
                else if (((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text == "Absent")
                {
                    anstatus = "A";
                }
                else if (((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text == "CL")
                {
                    anstatus = "C";
                }
                else if (((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text == "SL")
                {
                    anstatus = "S";
                }
                else if (((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text == "EL")
                {
                    anstatus = "E";
                }
                else if (((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text == "LTA")
                {
                    anstatus = "T";
                }
                else if (((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text == "OD")
                {
                    anstatus = "O";
                }
                else if (((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text == "OFF")
                {
                    anstatus = "F";
                }

                else if (((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text == "LOP")
                {
                    anstatus = "X";
                }


                dt = PIObj.SelForEmpLeaveDetails(Convert.ToString(empid));
                double leaveDays = 0;
                if (fnstatus == "C" || fnstatus == "S" || fnstatus == "E" || anstatus == "C" || anstatus == "S" || anstatus == "E")
                {
                    if (dt.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Attendance.aspx", "alertify.alert('" + grd.Rows[i].Cells[0].Text + " for this employee, Leave Details Not Found.');", true);
                        return;
                    }
                }

                if (fnstatus == "C")
                {

                    leaveDays = Convert.ToDouble(dt.Rows[0][2].ToString()) - (Convert.ToDouble(dt.Rows[0][5].ToString()) + 0.5);
                }

                else if (fnstatus == "S")
                {

                    leaveDays = Convert.ToDouble(dt.Rows[0][3].ToString()) - (Convert.ToDouble(dt.Rows[0][6].ToString()) + 0.5);
                }

                else if (fnstatus == "E")
                {

                    leaveDays = Convert.ToDouble(dt.Rows[0][4].ToString()) - (Convert.ToDouble(dt.Rows[0][7].ToString()) + 0.5);
                }

                if (anstatus == "C")
                {

                    leaveDays = Convert.ToDouble(dt.Rows[0][2].ToString()) - (Convert.ToDouble(dt.Rows[0][5].ToString()) + 0.5);
                }

                else if (anstatus == "S")
                {

                    leaveDays = Convert.ToDouble(dt.Rows[0][3].ToString()) - (Convert.ToDouble(dt.Rows[0][6].ToString()) + 0.5);
                }

                else if (anstatus == "E")
                {

                    leaveDays = Convert.ToDouble(dt.Rows[0][4].ToString()) - (Convert.ToDouble(dt.Rows[0][7].ToString()) + 0.5);
                }

                if (leaveDays < 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Attendance.aspx", "alertify.alert('" + grd.Rows[i].Cells[0].Text + " for this employee, selected leave not Available');", true);
                }

                attdt = atobj.GetEmpForAttendanceEmpid(empid, Convert.ToDateTime(Utility.fn_ConvertDate(txtAttendanceDate.Text)));

                if (attdt.Rows.Count > 0)
                {
                    fnstatus1 = attdt.Rows[0]["fnstatus"].ToString();
                    anstatus1 = attdt.Rows[0]["anstatus"].ToString();

                    if (fnstatus1 != fnstatus || anstatus1 != anstatus)
                    {
                        atobj.UpdEmpAttendanceExist(empid, Convert.ToDateTime(Utility.fn_ConvertDate(txtAttendanceDate.Text)), Convert.ToChar(fnstatus1), Convert.ToChar(anstatus1));
                        atobj.UpdEmpAttendance(empid, Convert.ToDateTime(Utility.fn_ConvertDate(txtAttendanceDate.Text)), Convert.ToChar(fnstatus), Convert.ToChar(anstatus));
                    }
                }
                else
                {
                    atobj.UpdEmpAttendance(empid, Convert.ToDateTime(Utility.fn_ConvertDate(txtAttendanceDate.Text)), Convert.ToChar(fnstatus1), Convert.ToChar(anstatus1));
                }
            }
            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 297, 2, Convert.ToInt32(Session["LoginBranchid"]),""+Convert.ToDateTime(Utility.fn_ConvertDate(txtAttendanceDate.Text))+" /U");
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Attendance.aspx", "alertify.alert('Attendance Updated');", true);
            btnUpdate.Enabled = false;
            //ddlbranch.SelectedIndex = -1;
            //ddlCompany.SelectedIndex = -1;
            ddlDepartment.SelectedIndex = 0;
            Clear();
            txtAttendanceDate.Text = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
            //btnCancel.Text = "Cancel";
            btnCancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }

        protected void Clear()
        {
            grd.DataSource = Utility.Fn_GetEmptyDataTable();
            grd.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.ToolTip == "Cancel")
            {
                Clear();
                ddlbranch.SelectedIndex = -1;
                ddlCompany.SelectedIndex = -1;
                ddlDepartment.SelectedIndex = -1;
                txtAttendanceDate.Text = logobj.GetDate().ToString();
                //btnCancel.Text = "Back";
                btnCancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDepartment.SelectedIndex = -1;
            Clear();
        }

        protected void txtAttendanceDate_TextChanged(object sender, EventArgs e)
        {
            ddlDepartment.SelectedIndex = -1;
            Clear();
        }

        protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDepartment.SelectedIndex = -1;
            Clear();
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 297, "Job", "", "", Session["StrTranType"].ToString());

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