using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class PaySlip : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.HR.Employee objbran = new DataAccess.HR.Employee();
        DataTable dt = new DataTable();
        int int_Division;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if (Request.QueryString.ToString().Contains("type"))
            {
                lbl_Header.Text = Request.QueryString["type"].ToString();
                if (lbl_Header.Text == "Letter to Bank")
                {
                    lbl_Header.Text = "Bank Statement";
                }
                string str_Uiid = "";
                str_Uiid = Request.QueryString["type"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, null,btn_View,null);
            }
            if (!IsPostBack)
            {
               
                Fn_BindDivision();
                ddl_Monrh.SelectedIndex = ddl_Monrh.Items.IndexOf(ddl_Monrh.Items.FindByValue(obj_da_Log.GetDate().Month.ToString()));
                txt_year.Text = obj_da_Log.GetDate().Year.ToString();
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_year~ddl_Monrh";
                str_MsgLists = "Year~Month";
                str_DataType = "Integer~DropDown";
                btn_View.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                Grd_Pay.DataSource = new DataTable();
                Grd_Pay.DataBind();
                Fill_Data();
              //  btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
        }
        public void Fn_BindDivision()
        {
            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
            //ddl_Company.Items.Add("ALL");
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Emp.GetDivision("HR");
            //ddl_Company.DataSource = obj_dt;
            //ddl_Company.DataTextField = "divisionname";
            //ddl_Company.DataValueField = "divisionid";
            //ddl_Company.DataBind();
            ddl_Company.Items.Clear();
            ddl_Company.Items.Add("Company");
            for(int i=0;i<=obj_dt .Rows.Count-1;i++)
            {
                ddl_Company.Items.Add(obj_dt.Rows[i]["divisionname"].ToString());
            }

        }  

       
        private void Fn_Clear()
        {
            lbl_workday.Text = "";
            txt_TotalEmp.Text = "";
            txt_joined.Text = "";
            txt_Relieved.Text = "";
            ddl_Monrh.SelectedIndex = ddl_Monrh.Items.IndexOf(ddl_Monrh.Items.FindByValue(obj_da_Log.GetDate().Month.ToString()));
            txt_year.Text = obj_da_Log.GetDate().Year.ToString();
            Grd_Pay.DataSource = new DataTable();
            Grd_Pay.DataBind();
            ddl_Company.SelectedIndex = 0;
            ddl_Monrh.SelectedIndex = 0;
           // btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
            
        }


        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
            Fn_Clear();
            }
            else
            {
                this.Response.End();
            }
        }

        


        protected void btn_View_Click(object sender, EventArgs e)
        {
            if (ddl_Monrh.SelectedValue=="0")
            {
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", "alertify.alert('Please Select a Month');", true);
                return;
            }
            if (ddl_Company.SelectedIndex != -1)
            {
                int int_Division = objbran.GetDivisionId(ddl_Company.SelectedItem.Text.ToString());
                //int int_Division = Convert.ToInt32(dt.Rows[0]["divisionid"].ToString());
                int int_Month = int.Parse(ddl_Monrh.SelectedValue.ToString());
                int int_Year = int.Parse(txt_year.Text);
                string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                if (lbl_Header.Text == "Payslip")
                {
                    Str_RptName = "/Payroll/" + "rptHRPaySlip.rpt";
                    if (int_Division != 0)
                    {
                        Str_sf = "{HRPayroll.paymonth}=" + int_Month + " and {HRPayroll.payyear}=" + int_Year + "and {MasterEmployee.division}=" + int_Division;
                    }
                    else
                    {
                        Str_sf = "{HRPayroll.paymonth}=" + int_Month + " and {HRPayroll.payyear}=" + int_Year;
                    }                                     
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 798, 3, int.Parse(Session["LoginBranchid"].ToString()), ddl_Monrh.SelectedItem.Text + "/" + txt_year.Text + "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (lbl_Header.Text == "Bank Statement")
                {
                    if (int_Division == 0)
                    {
                        Str_RptName = "/Payroll/" + "rptHRBankStmt.rpt";
                        Str_sp = "Title=" + ddl_Monrh.SelectedItem + "\"" + int_Year;
                        Str_sf = "{HRPayroll.paymonth}=" + int_Month + " and {HRPayroll.payyear}=" + int_Year + "and {MasterEmployee.accountno}<>\" \"";
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                        //Str_sp = "";
                        Str_RptName = "/Payroll/" + "rptHROtherBankStmt.rpt";
                        Str_sf = "{HRPayroll.paymonth}=" + int_Month + " and {HRPayroll.payyear}=" + int_Year + "and {MasterEmployee.bankname}=\"AXIS\" and {MasterEmployee.accountno}<>\" \"";
                        Str_Script = Str_Script + ";" + "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 798, 3, int.Parse(Session["LoginBranchid"].ToString()), ddl_Monrh.SelectedItem.Text + "/" + txt_year.Text + "View");
                        ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                        Session["str_sfs1"] = Str_sf;
                        Session["str_sp1"] = Str_sp;
                    }
                    else
                    {
                        Str_RptName = "/Payroll/" + "rptHRBankStmt.rpt";
                        Str_sp = "Title=" + ddl_Monrh.SelectedItem + "\"" + int_Year;
                        Str_sf = "{HRPayroll.paymonth}=" + int_Month + " and {HRPayroll.payyear}=" + int_Year + "and {MasterDivision.divisionid}=" + int_Division + "and {MasterEmployee.accountno}<>\"\"";
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                        //Str_sp = "";
                        Str_RptName = "/Payroll/" + "rptHROtherBankStmt.rpt";
                        Str_sf = "{HRPayroll.paymonth}=" + int_Month + " and {HRPayroll.payyear}=" + int_Year + "and {MasterDivision.divisionid}=" + int_Division + "and {MasterEmployee.bankname}=\"AXIS\" and {MasterEmployee.accountno}<>\"\"";
                        Str_Script = Str_Script + ";" + "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 798, 3, int.Parse(Session["LoginBranchid"].ToString()), ddl_Monrh.SelectedItem.Text + "/" + txt_year.Text + "View");
                        ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                        Session["str_sfs1"] = Str_sf;
                        Session["str_sp1"] = Str_sp;
                    }

                   // ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", "alertify.alert('Please Select The CompanyName');", true);
            }
        }

       public void Fill_Data()
        {
            int int_Month = int.Parse(ddl_Monrh.SelectedValue.ToString());
            int int_Year = int.Parse(txt_year.Text);
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            DataAccess.Payroll.Details obj_da_Detail = new DataAccess.Payroll.Details();
            if (ddl_Monrh.SelectedIndex != 0 && txt_year.Text.Trim().Length==4)
            {

                if (ddl_Company.SelectedIndex == -1 || ddl_Company.SelectedIndex == 0)
                {
                    obj_dt = obj_da_Detail.getreportdet(int_Month, int_Year, int_Division, 'A');
                    obj_dttemp = obj_da_Detail.GetTotDet(int_Month, int_Year, int_Division, 'A');
                }
                else
                {
                    obj_dt = obj_da_Detail.getreportdet(int_Month, int_Year, int_Division, 'S');
                    obj_dttemp = obj_da_Detail.GetTotDet(int_Month, int_Year, int_Division, 'S');
                }
                if (obj_dt.Rows.Count > 0)
                {
                    txt_TotalEmp.Text = obj_dt.Rows[0]["totemp"].ToString();
                    txt_joined.Text = obj_dt.Rows[0]["nj"].ToString();
                    txt_Relieved.Text = obj_dt.Rows[0]["rel"].ToString();
                    lbl_workday.Text = "Worked Days " + obj_dt.Rows[0]["wd"].ToString();
                }

                Grd_Pay.DataSource = obj_dttemp;
                Grd_Pay.DataBind();
            }
        }

        protected void ddl_Company_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddl_Company.SelectedIndex != -1)
            {
                int_Division = objbran.GetDivisionId(ddl_Company.SelectedItem.Text.ToString());
                //int int_Division = Convert.ToInt32(dt.Rows[0]["divisionid"].ToString());
                Fill_Data();
            }
          //  btn_cancel.Text = "Cancel";

            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Grd_Pay_RowDataBound(object sender, GridViewRowEventArgs e)
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


                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Pay, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ddl_Monrh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Data();
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 798, "Job", "", "", Session["StrTranType"].ToString());

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