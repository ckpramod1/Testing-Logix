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
    public partial class EmployeeFind : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnBack);
            if (!IsPostBack)
            {
                try
                {
                    txt_empname.Focus();
                    // txt_empname.Attributes.Add("OnKeypress", "javascript:document.forms[0].elements['logix_CPH_btn_search'].Click();");
                    if (Request.QueryString.ToString().Contains("txt1"))
                    {
                        hid.Value = Request.QueryString["txt1"].ToString();
                    }

                    Grd_Emp.DataSource = new DataTable();
                    Grd_Emp.DataBind();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }

        protected void page_change()
        {
            try
            {
                DataTable obj_dtEmp = new DataTable();
                if (Session["Date"] != null)
                {
                    obj_dtEmp = (DataTable)Session["Date"];
                    Grd_Emp.DataSource = obj_dtEmp;
                    Grd_Emp.DataBind();
                    //foreach (GridViewRow row in Grd_Emp.Rows)
                    //{
                    //    LinkButton LnkBtn = (LinkButton)row.Cells[0].Controls[1];
                    //    LnkBtn.ID = LnkBtn.Text;
                    //    LnkBtn.Attributes.Add("OnClick", "return Get_EmpCode('" + hid.Value.ToString() + "','" + LnkBtn.Text + "')");
                    //}
                }

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }


        protected void btn_search_Click(object sender, EventArgs e)
        {
            page_change();
        }


        [WebMethod]
        public static void GetEmpName(string Prefix)
        {

            DataTable obj_dtEmp = new DataTable();
            if (Prefix.Length > 0)
            {
                DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_Employee.GetLikeEmpName(Prefix);
                obj_dtEmp.Columns.Add("empcode");
                obj_dtEmp.Columns.Add("unit");
                obj_dtEmp.Columns.Add("branch");
                obj_dtEmp.Columns.Add("designation");
                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["empcode"] = obj_dt.Rows[i][0].ToString();
                    dr["unit"] = obj_dt.Rows[i][1].ToString();
                    dr["branch"] = obj_dt.Rows[i][2].ToString();
                    dr["designation"] = obj_dt.Rows[i][3].ToString();

                }
                HttpContext.Current.Session["Date"] = obj_dtEmp;

            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Session["Packages"] == "Salary/Packages Details")
            {
                Response.Redirect("SalaryPackage.aspx");
            }
            else if (Session["Packages"] == "Personal Info")
            {
                Response.Redirect("HRMPersonalInformation.aspx");
            }
            else if (Session["Packages"] == "ITComputation")
            {
                Response.Redirect("ITComputation.aspx");
            }
            else if (Session["Packages"] == "PaySlip")
            {
                Response.Redirect("HRPaySlip.aspx");
            }
            else if (Session["Packages"] == "Late Attendance")
            {
                Response.Redirect("LateAttendance.aspx");
            }
            else if (Session["Packages"] == "Incentive Details")
            {
                Response.Redirect("IncentiveDetails.aspx");
            }
            else if (Session["Packages"] == "Update TDS Details")
            {
                Response.Redirect("TDSUpdate.aspx");
            }
            else if (Session["Packages"] == "Quarter Details")
            {
                Response.Redirect("Quarter.aspx");
            }
            else if (Session["Packages"] == "Rent Details")
            {
                Response.Redirect("RentDetails.aspx");
            }
            else if (Session["Packages"] == "Other Income")
            {
                Response.Redirect("Incomefrmothrsuce.aspx");
            }
            else if (Session["Packages"] == "Investment Plan Prof Received")
            {
                Response.Redirect("InvestmentPlanProf.aspx");
            }

            else if (Session["Packages"] == "ITComputation")
            {
                Response.Redirect("ITComputation.aspx");
            }
           
        }

        protected void Grd_Emp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_Emp.PageIndex = e.NewPageIndex;

            page_change();
        }

        protected void Grd_Emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
            //DataTable obj_dt = new DataTable();
            //obj_dt = obj_da_Emp.selEmpDetails(txt_empname.Text, "PER");HRMPersonalInformation
            if (Session["Packages"].ToString() == "Personal Info")
            {
                var empcode = (LinkButton)Grd_Emp.SelectedRow.FindControl("Lnk_Emp");
                Session["empcode"] = empcode.Text;

                Response.Redirect("HRMPersonalInformation.aspx");
            }
            else if (Session["Packages"].ToString() == "Salary/Packages Details")
            {
                var empcode = (LinkButton)Grd_Emp.SelectedRow.FindControl("Lnk_Emp");
                 Session["empcode"] = empcode.Text;
                Response.Redirect("SalaryPackage.aspx");
            }
            else if (Session["Packages"] == "Late Attendance")
            {
                var empcode = (LinkButton)Grd_Emp.SelectedRow.FindControl("Lnk_Emp");
                Session["empcode"] = empcode.Text;
                Response.Redirect("LateAttendance.aspx");
            }
            else if (Session["Packages"] == "Incentive Details")
            {
                var empcode = (LinkButton)Grd_Emp.SelectedRow.FindControl("Lnk_Emp");
                Session["empcode"] = empcode.Text;
                Response.Redirect("IncentiveDetails.aspx");
            }

            else if (Session["Packages"] == "Update TDS Details")
            {
                var empcode = (LinkButton)Grd_Emp.SelectedRow.FindControl("Lnk_Emp");
                Session["empcode"] = empcode.Text;
                Response.Redirect("TDSUpdate.aspx");
            }
            else if (Session["Packages"] == "Quarter Details")
            {
                var empcode = (LinkButton)Grd_Emp.SelectedRow.FindControl("Lnk_Emp");
                Session["empcode"] = empcode.Text;
                Response.Redirect("Quarter.aspx");
            }
            else if (Session["Packages"] == "Rent Details")
            {
                var empcode = (LinkButton)Grd_Emp.SelectedRow.FindControl("Lnk_Emp");
                Session["empcode"] = empcode.Text;
                Response.Redirect("RentDetails.aspx");
            }
            else if (Session["Packages"] == "Other Income")
            {
                var empcode = (LinkButton)Grd_Emp.SelectedRow.FindControl("Lnk_Emp");
                Session["empcode"] = empcode.Text;
                Response.Redirect("Incomefrmothrsuce.aspx");
            }
            else if (Session["Packages"] == "Investment Plan Prof Received")
            {
                var empcode = (LinkButton)Grd_Emp.SelectedRow.FindControl("Lnk_Emp");
                Session["empcode"] = empcode.Text;
                Response.Redirect("InvestmentPlanProf.aspx");
            }

            else if (Session["Packages"] == "ITComputation")
            {
                var empcode = (LinkButton)Grd_Emp.SelectedRow.FindControl("Lnk_Emp");
                Session["empcode"] = empcode.Text;
                Response.Redirect("ITComputation.aspx");
            }
        }

        protected void Grd_Emp_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Emp, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        


    }
}