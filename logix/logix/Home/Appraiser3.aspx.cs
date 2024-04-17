using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logix;
using System.Data;

namespace logix.Home
{
    public partial class Appraiser3 : System.Web.UI.Page
    {
        DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
        int employeeid = 0;
        DataTable dtcom = new DataTable();
        DataTable dtcompetencies = new DataTable();
        DataTable dtkpi = new DataTable();
        int year = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                employeeid = Convert.ToInt32(Session["APPEmpid"].ToString());
                dtcom = da_obj_Employee.GetEmpidAppraisalCom(employeeid);
                year = Convert.ToInt32(DateTime.Now.Year.ToString());
                if (dtcom.Rows.Count > 0)
                {
                    txtempcode.Text = dtcom.Rows[0]["UserName"].ToString();
                    txtempname.Text = dtcom.Rows[0]["empname"].ToString();
                    txtdept.Text = dtcom.Rows[0]["deptname"].ToString();
                    txtdesig.Text = dtcom.Rows[0]["designame"].ToString();
                    txtlocation.Text = dtcom.Rows[0]["shortname"].ToString();
                    txtgrossmon.Text = string.Format("{0:#,##0.00}", dtcom.Rows[0]["MonthlyGross"]);
                    txtgrade.Text = dtcom.Rows[0]["grade"].ToString();
                    txtdoj.Text = dtcom.Rows[0]["doj"].ToString();
                    txtdoc.Text = dtcom.Rows[0]["doc"].ToString();
                    txtctcann.Text = string.Format("{0:#,##0.00}", dtcom.Rows[0]["AnnualCTC"]);
                    txtctcmon.Text = string.Format("{0:#,##0.00}", dtcom.Rows[0]["MonthlyCTC"]);
                }
                dtcompetencies = da_obj_Employee.GetAppraisalpage3(employeeid, year);
                if (dtcompetencies.Rows.Count > 0)
                {
                    txt1ques.Text = dtcompetencies.Rows[0]["Q1Ans"].ToString();
                    ddl2aques.SelectedValue = dtcompetencies.Rows[0]["Q2aAns"].ToString();
                    ddl2bques.SelectedValue = dtcompetencies.Rows[0]["Q2bAns"].ToString();
                    ddl2cques.SelectedValue = dtcompetencies.Rows[0]["Q2cAns"].ToString();
                    ddl2dques.SelectedValue = dtcompetencies.Rows[0]["Q2dAns"].ToString();
                    ddl2eques.SelectedValue = dtcompetencies.Rows[0]["Q2eAns"].ToString();
                    ddl2fques.SelectedValue = dtcompetencies.Rows[0]["Q2fAns"].ToString();
                    ddl2gans.SelectedValue = dtcompetencies.Rows[0]["Q2gAns"].ToString();
                    txt2gques.Text = dtcompetencies.Rows[0]["Q2gAnsRemarks"].ToString();
                    ddl3aques.SelectedValue = dtcompetencies.Rows[0]["Q3aAns"].ToString();
                    txt3aTQues.Text = dtcompetencies.Rows[0]["Q3bAnsT"].ToString();
                    txt3aFQues.Text = dtcompetencies.Rows[0]["Q3bAnsF"].ToString();
                    txt3aSQues.Text = dtcompetencies.Rows[0]["Q3bAnsS"].ToString();
                    txt4aQues.Text = dtcompetencies.Rows[0]["Q4aAns"].ToString();
                    txt4bQues.Text = dtcompetencies.Rows[0]["Q4bAns"].ToString();
                    txtSpecify.Text = dtcompetencies.Rows[0]["Q3spans"].ToString();
                }
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            if (txtgrade.Text.Substring(0, 1).ToString() == "M")
            {
                Response.Redirect("Appraiser4.aspx");
            }
            else
            {
                Response.Redirect("AppPage4A.aspx");
            }
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("Appraiser2.aspx");
        }

        protected void btncancelpage2_Click(object sender, EventArgs e)
        {

        }
    }
}