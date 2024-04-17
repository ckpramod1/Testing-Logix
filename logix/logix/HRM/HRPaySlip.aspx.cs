using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.HRM
{
    public partial class HRPaySlip : System.Web.UI.Page
    {
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.HR.Employee emp = new DataAccess.HR.Employee();
        DataAccess.Payroll.Details invesTobj = new DataAccess.Payroll.Details();
        DataAccess.Masters.MasterDivision divid = new DataAccess.Masters.MasterDivision();
        DataTable Dt = new DataTable();
        int intempid, fmonth, tmonth;
        Boolean bolerr;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnBack);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            Session["Packages"] = lbl_Header.Text;
            if (!IsPostBack == true)
            {
                hid_eid.Value = "0";
                hid_divsid.Value = "0";
                FillMonthYear();
                txtEmpCode.Focus();
            }
        }

        protected void txtEmpCode_TextChanged(object sender, EventArgs e)
        {
            if (txtEmpCode.Text.Trim() != "")
            {
                hid_eid.Value = Convert.ToInt16(emp.GetEmpId(txtEmpCode.Text)).ToString();
                Dt = invesTobj.GetEmpDetails(Convert.ToInt16(hid_eid.Value));
                if (hid_eid.Value != "0")
                {
                    if (Dt.Rows.Count > 0)
                    {
                        txtEmpName.Text = Dt.Rows[0]["empname"].ToString();
                        txtEmpCode.Text = Dt.Rows[0]["username"].ToString();
                        txtCompany.Text = Dt.Rows[0]["branchname"].ToString();
                        txtDept.Text = Dt.Rows[0]["deptname"].ToString();
                        txtDesg.Text = Dt.Rows[0]["designame"].ToString();
                        txtGrade.Text = Dt.Rows[0]["grade"].ToString();
                        txtDoj.Text = String.Format("{0:dd/MM/yyyy}", Dt.Rows[0]["doj"]);
                        txtLocation.Text = Dt.Rows[0]["portname"].ToString();
                        String strdiv = "";
                        strdiv = Dt.Rows[0]["branchname"].ToString();
                        hid_divsid.Value = Convert.ToInt16(divid.GetDivisionid(strdiv)).ToString();
                        FillMonthYear();
                    }
                }
                //btnBack.Text = "Cancel";
                btnBack.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }
        }

        public void FillMonthYear()
        {
            ddl_frommonth.Items.Clear();
            ddl_tomonth.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                ddl_frommonth.Items.Add(Convert.ToDateTime(i.ToString() + "/1/2010").ToString("MMMM"));
                ddl_tomonth.Items.Add(Convert.ToDateTime(i.ToString() + "/1/2010").ToString("MMMM"));
            }
            int d = logobj.GetDate().Month;
            ddl_frommonth.Text = Convert.ToDateTime(d.ToString() + "/1/2010").ToString("MMMM");
            ddl_tomonth.Text = Convert.ToDateTime(d.ToString() + "/1/2010").ToString("MMMM");
            txtToYear.Text = logobj.GetDate().Year.ToString();
            txtfrmYear.Text = logobj.GetDate().Year.ToString();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            checkdata();
            if (bolerr == true)
            {
                bolerr = false;
                return;
            }

            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";

            //str_RptName = "/Payroll" + "/rptHRPaySlip.rpt";

            str_RptName = "/Payroll" + "/rptHRPaySlipnew.rpt";
           // Session["str_sfs"] = "Date({HRPayroll.payyear},{HRPayroll.paymonth},1) >= Date(" + txtfrmYear.Text + "," + (ddl_frommonth.SelectedIndex + 1) + ",01) and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) <=Date(" + txtToYear.Text + "," + (ddl_tomonth.SelectedIndex + 1) + ",01)" + "and {HRPayroll.divisionid}= " + hid_divsid.Value + " and {HRPayroll.empid}=" + hid_eid.Value;
            Session["str_sfs"] = "Date({HRPayroll.payyear},{HRPayroll.paymonth},1) >= Date(" + txtfrmYear.Text + "," + (ddl_frommonth.SelectedIndex + 1) + ",01) and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) <=Date(" + txtToYear.Text + "," + (ddl_tomonth.SelectedIndex + 1) + ",01)"  + " and {HRPayroll.empid}=" + hid_eid.Value;
            //str_sf = "Date({HRPayroll.payyear},{HRPayroll.paymonth},1) >= Date(" + txtfrmYear.Text + "," + (ddl_frommonth.SelectedIndex + 1) + ",01) and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) <=Date(" + txtToYear.Text + "," + (ddl_tomonth.SelectedIndex + 1) + ",01)" + "and {HRPayroll.divisionid}= " + hid_divsid.Value + " and {HRPayroll.empid}=" + hid_eid.Value;
            str_sf = "Date({HRPayroll.payyear},{HRPayroll.paymonth},1) >= Date(" + txtfrmYear.Text + "," + (ddl_frommonth.SelectedIndex + 1) + ",01) and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) <=Date(" + txtToYear.Text + "," + (ddl_tomonth.SelectedIndex + 1) + ",01)" +  " and {HRPayroll.empid}=" + hid_eid.Value;
            
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            if (lbl_Header.Text == "PaySlip")
            {
                logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1348, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
            }
            else
            {
                logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 801, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
            }
            ScriptManager.RegisterStartupScript(btnView, typeof(Button), "HRM", str_Script, true);
            Session["str_sp"] = str_sp;
        }

        public void checkdata()
        {
            if (txtEmpCode.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter An Employee Code');", true);
                bolerr = true;
                txtEmpCode.Focus();
                return;
            }
            else if (hid_eid.Value == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter An Employee Code');", true);
                bolerr = true;
                txtEmpCode.Focus();
                return;
            }

            if (ddl_frommonth.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Please Select a Month');", true);
                bolerr = true;
                ddl_frommonth.Focus();
                return;
            }
            else if (txtfrmYear.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Financial Year');", true);
                bolerr = true;
                txtfrmYear.Focus();
                return;
            }
            else if (ddl_tomonth.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Please Select a Month');", true);
                bolerr = true;
                ddl_tomonth.Focus();
                return;
            }
            else if (txtToYear.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Financial Year');", true);
                bolerr = true;
                txtToYear.Focus();
                return;
            }

            int fmonth, tomonth, frmyr, toyr;
            fmonth = ddl_frommonth.SelectedIndex + 1;
            tomonth = ddl_tomonth.SelectedIndex + 1;
            frmyr = Convert.ToInt16(txtfrmYear.Text);
            toyr = Convert.ToInt16(txtToYear.Text);

            if (frmyr > toyr)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('From Year Should be Less Then To Year');", true);
                bolerr = true;
                txtfrmYear.Focus();
                return;
            }
            else
            {
                if (frmyr == toyr)
                {
                    if (fmonth > tomonth)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('From Month Should Be Less Then To Month');", true);
                        bolerr = true;
                        ddl_frommonth.Focus();
                        return;
                    }
                }
            }

            if (fmonth <= 3 && frmyr < 2012)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('From Month Should Be Start Up From April 2012 Only');", true);
                bolerr = true;
                ddl_frommonth.Focus();
                return;
            }

            if (fmonth == 4 && frmyr == 2014)
            {
                if (fmonth == logobj.GetDate().Month && frmyr == 2014)
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Current Month Payslip Not Allowed');", true);
                bolerr = true;
                ddl_frommonth.Focus();
                return;
            }
        }

        protected void LnkEmpname_Click(object sender, EventArgs e)
        {
            //iframeemp.Attributes["src"] = "HRM/EmployeeFind.aspx";
            //popup_empcode.Show();
            Response.Redirect("EmployeeFind.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (btnBack.ToolTip == "Cancel")
            {
                TxtClear();
                //btnBack.Text = "Back";
                btnBack.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
                txtEmpCode.Focus();
            }
            else
            {
                this.Response.End();
            }
        }

        public void TxtClear()
        {
            txtEmpName.Text = "";
            txtEmpCode.Text = "";
            txtCompany.Text = "";
            txtDept.Text = "";
            txtDesg.Text = "";
            txtGrade.Text = "";
            txtDoj.Text = "";
            txtLocation.Text = "";
            FillMonthYear();
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
            PanelLog1.Visible = true;
            GridViewlog.Visible = true;
            Panel3.Visible = true;

            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1348, "", "", "", "");  //"/Rate ID: " +
            //if (txt_customer.Text != "")
            //{
            //    JobInput.Text = txt_customer.Text;


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