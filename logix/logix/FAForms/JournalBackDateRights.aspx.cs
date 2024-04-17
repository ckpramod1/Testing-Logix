using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.Sql;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Web.Services.Description;

namespace logix.FAForm
{
    public partial class JournalBackDateRights : System.Web.UI.Page
    {
        int divisionid, branchid, employeeid;
        DataTable dt = new DataTable();
        Boolean blnErr;
        DataTable dtcom = new DataTable();
        DataAccess.Masters.MasterBranch bobj = new DataAccess.Masters.MasterBranch();
        DataAccess.Masters.MasterEmployee MasterEmpObj = new DataAccess.Masters.MasterEmployee();
        DataAccess.ComTVBackDateRights ComJV = new DataAccess.ComTVBackDateRights();
        DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();

        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                bobj.GetDataBase(Ccode);
                MasterEmpObj.GetDataBase(Ccode);
                ComJV.GetDataBase(Ccode);
                HREmpobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                obj_emp.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
              
            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_view);
            if (Session["LoginDivisionId"] != null)
            {
                //if (Session["LoginDivisionId"].ToString() == "1")
                //{
                //    btn_save.Enabled = false;
                //}
            }
            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                filldivision();
            }
        }


        [WebMethod]
        public static List<string> GetEmp(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterEmployee da_obj_Employee = new DataAccess.Masters.MasterEmployee();
            obj_dt = da_obj_Employee.GetLikeEmployee(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(obj_dt, "empnamecode", "empcode");
            return List_Result;
        }

        public void fillbranch()
        {
            drop_branch.Items.Clear();
            dt = bobj.GetBranchByDivID(HREmpobj.GetDivisionId(drop_division.SelectedValue));

            if (dt.Rows.Count > 0)
            {
                drop_branch.Items.Add("");
                drop_branch.Items.Add("ALL");
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    drop_branch.Items.Add(dt.Rows[i]["branch"].ToString());
                }
            }
        }
        public void filldivision()
        {
            drop_division.Items.Clear();
            dt = HREmpobj.GetDivision();
            if (dt.Rows.Count > 0)
            {                
                drop_division.Items.Add("");
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    drop_division.Items.Add(dt.Rows[i]["divisionname"].ToString());
                }
            }
        }

        protected void drop_division_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillbranch();
            txt_noofmonth.SelectedIndex = 0;
           // btn_save.ToolTip = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";

            btn_view.ToolTip = "Cancel";
            btn_save1.Attributes["class"] = "btn ico-save";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void drop_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fillbranch();
            divisionid = HREmpobj.GetDivisionId(drop_division.Text);
            branchid = HREmpobj.GetBranchId(divisionid, drop_branch.Text);
            getdetail();
            btn_view.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }
        public void getdetail()
        {
            dt = MasterEmpObj.GetLikeEmployee(txt_empname.Text);
            employeeid = Convert.ToInt32(dt.Rows[0]["employeeid"]);
            dtcom = ComJV.SelCtBDtRights(employeeid, branchid);

            if (dtcom.Rows.Count > 0)
            {
                txt_noofmonth.SelectedValue = dtcom.Rows[0]["noofmonth"].ToString();
                txt_noofdays.Text = dtcom.Rows[0]["noofdays"].ToString();
                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
            }
            else
            {
                txt_noofmonth.SelectedIndex = 0;
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
            }
            btn_view.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txt_empname_TextChanged(object sender, EventArgs e)
        {
            if (txt_empname.Text != "")
            {
                if (Str_empCode.Value != "0")
                {
                    dt = HREmpobj.selEmpDetails(Str_empCode.Value.ToString(), "OFF");
                    if (dt.Rows.Count > 0)
                    {
                        txt_branch.Text = dt.Rows[0]["branch"].ToString();
                        btn_view.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Please Enter Valid EmployeeName');", true);
                    btn_view.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    clear();
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            //DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();
            blnErr = false;
            Empty_Check();
            if (blnErr == true)
            {
                return;
            }
            employeeid = obj_emp.GetEmpId(Str_empCode.Value);
            if (btn_save.ToolTip == "Save")
            {
                divisionid = HREmpobj.GetDivisionId(drop_division.Text);
                branchid = HREmpobj.GetBranchId(divisionid, drop_branch.Text);
                if(txt_noofmonth.Text=="")
                {
                    txt_noofmonth.Text = "0";
                }
             
                ComJV.InsCtBDtRights(Convert.ToInt32(employeeid), Convert.ToInt32(branchid), Convert.ToInt32(txt_noofmonth.Text),Convert.ToInt32(txt_noofdays.Text));
                logobj.InsLogDetail(employeeid, 1278, 1, branchid, "EMPID : " + employeeid + "/Branch :" + branchid + "/No Of Days :" + Convert.ToInt32(txt_noofdays.Text));
                ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Detail Saved');", true);
                btn_save.ToolTip = "Update";

                btn_save1.Attributes["class"] = "btn btn-update1";
            }
            else
            {
                divisionid = HREmpobj.GetDivisionId(drop_division.Text);
                branchid = HREmpobj.GetBranchId(divisionid, drop_branch.Text);
                if (txt_noofmonth.Text == "")
                {
                    txt_noofmonth.Text = "0";
                }
                ComJV.UpdCtBDtRights(Convert.ToInt32(employeeid), Convert.ToInt32(branchid), Convert.ToInt32(txt_noofmonth.Text),Convert.ToInt32(txt_noofdays.Text));
                logobj.InsLogDetail(employeeid, 1278, 2, branchid, "EMPID : " + employeeid + "/Branch :" + branchid + "/No Of Days :" + Convert.ToInt32(txt_noofdays.Text));
                ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Detail Updated');", true);
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
            }
        }

        public void Empty_Check()
        {

            if (txt_empname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Please Enter Valid EmployeeName');", true);
                txt_empname.Focus();
                blnErr = true;
            }else if(Str_empCode.Value=="" || Str_empCode.Value=="0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Please Enter Valid EmployeeName');", true);
                txt_empname.Focus();
                blnErr = true;
            }
            else if (drop_division.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Please Select DivisionName');", true);
                drop_division.Focus();
                blnErr = true;
            }
            else if (drop_branch.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Please Select BranchName');", true);
                drop_branch.Focus();
                blnErr = true;
            }
            //else if (txt_noofmonth.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Please Select No Of Months for BackDate');", true);
            //    txt_noofmonth.Focus();
            //    blnErr = true;
            //}
            else if(txt_noofdays.Text=="")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Kindly Enter No of Days for BackDate');", true);
                txt_noofdays.Focus();
                blnErr = true;
            }
            
            
        }

        public void clear()
        {
            txt_branch.Text = "";
            txt_empname.Text = "";
            drop_branch.Items.Clear();
            drop_branch.Items.Add("Branch");
            drop_division.SelectedIndex = 0;
            txt_noofmonth.SelectedIndex = 0;
            btn_view.ToolTip = "Back";
            btn_save.ToolTip = "Save";
            txt_noofdays.Text = "";


            btn_save1.Attributes["class"] = "btn ico-save";
            btn_cancel1.Attributes["class"] = "btn ico-back";


            btn_save.Enabled = true;
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            if (btn_view.ToolTip == "Cancel")
            {
                clear();
            }
            else
            {
            //    this.Response.End();

                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                    else if (Session["StrTranType"].ToString() == "BR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");

                    }
                    else if (Session["StrTranType"].ToString() == "AC")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"] != null)
                    {
                        if (Session["home"].ToString() == "FABR")
                        {
                            Response.Redirect("../Home/Branch_home.aspx");
                        }
                        else if (Session["home"].ToString() == "FAFC")
                        {
                            Response.Redirect("../Home/CorporateHome.aspx");
                        }
                    }

                }
                else if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "FABR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"].ToString() == "FAFC")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                }
                else
                {
                    this.Response.End();
                }
                

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
            Panel3.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1278, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1278, "", "", "", Session["StrTranType"].ToString());
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