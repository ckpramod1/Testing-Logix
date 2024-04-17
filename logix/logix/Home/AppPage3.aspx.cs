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
    public partial class AppPage3 : System.Web.UI.Page
    {
        DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
        int employeeid = 0;
        DataTable dtcom = new DataTable();
        DataTable dtcompetencies = new DataTable();
        DataTable dtkpi = new DataTable();
        int year = 0;
        Boolean bol;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
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
                dtcompetencies = da_obj_Employee.GetAppraisalpage3(employeeid,year);
                if(dtcompetencies.Rows.Count > 0)
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

        protected void btn_instr_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            checkdata();
            if (bol == true)
            {
                bol = false;
                return;
            }

            employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            year = Convert.ToInt32(DateTime.Now.Year.ToString());
            da_obj_Employee.InsKpiforPage3(employeeid, year, txt1ques.Text, Convert.ToInt32(ddl2aques.SelectedItem.Value), Convert.ToInt32(ddl2bques.SelectedItem.Value), Convert.ToInt32(ddl2cques.SelectedItem.Value), Convert.ToInt32(ddl2dques.SelectedItem.Value), Convert.ToInt32(ddl2eques.SelectedItem.Value), Convert.ToInt32(ddl2fques.SelectedItem.Value), Convert.ToInt32(ddl2gans.SelectedItem.Value), txt2gques.Text, Convert.ToInt32(ddl3aques.SelectedItem.Value), txt3aTQues.Text, txt3aFQues.Text, txt3aSQues.Text, txt4aQues.Text, txt4bQues.Text,txtSpecify.Text);
            ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Rating Details Saved');", true);
            //dtcompetencies = da_obj_Employee.GetAppraisalpage3(employeeid,year);
            //if (dtcompetencies.Rows.Count > 0)
            //{
            if (txtgrade.Text.Substring(0, 1).ToString() == "M")
            {
                Response.Redirect("Apppage4.aspx");
            }
            else
            {
                Response.Redirect("Apppage5.aspx");
            }

            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(btnnext, typeof(Button), "HRM", "alertify.alert('Kindly save the ratings in this page');", true);
            //    return;
            //}
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("Apppage2.aspx");
        }

        protected void btnsavepage2_Click(object sender, EventArgs e)
        {
            checkdata();
            if (bol == true)
            {
                bol = false;
                return;
            }
            //employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            //year = Convert.ToInt32(DateTime.Now.Year.ToString());
            //da_obj_Employee.InsKpiforPage3(employeeid, year, txt1ques.Text, Convert.ToInt32(ddl2aques.SelectedItem.Value), Convert.ToInt32(ddl2bques.SelectedItem.Value), Convert.ToInt32(ddl2cques.SelectedItem.Value), Convert.ToInt32(ddl2dques.SelectedItem.Value), Convert.ToInt32(ddl2eques.SelectedItem.Value), Convert.ToInt32(ddl2fques.SelectedItem.Value), Convert.ToInt32(ddl2gans.SelectedItem.Value), txt2gques.Text, Convert.ToInt32(ddl3aques.SelectedItem.Value), txt3aTQues.Text, txt3aFQues.Text, txt3aSQues.Text, txt4aQues.Text, txt4bQues.Text);
            //ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Ratings have been Saved , Go to Next Tab');", true);
        }

        protected void btncancelpage2_Click(object sender, EventArgs e)
        {

        }

        public void checkdata()
        {
            if (txt1ques.Text == "" )
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Performance must not be empty');", true);
                txt1ques.Focus();
                bol = true;
                return;
            }
            if (ddl2aques.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Select any one in ManPower');", true);
                ddl2aques.Focus();
                bol = true;
                return;
            }
            if (ddl2bques.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Select any one in Systems[Hardware]');", true);
                ddl2bques.Focus();
                bol = true;
                return;
            }
            if (ddl2cques.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Select any one in Work Environment');", true);
                ddl2cques.Focus();
                bol = true;
                return;
            }
            if (ddl2dques.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Select any one in Communications');", true);
                ddl2dques.Focus();
                bol = true;
                return;
            }
            if (ddl2eques.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Select any one in Leadership and Guidance');", true);
                ddl2eques.Focus();
                bol = true;
                return;
            }
            if (ddl2fques.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Select any one in Training');", true);
                ddl2fques.Focus();
                bol = true;
                return;
            }
            if (ddl2gans.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Select any one in Recognition and Appreciation');", true);
                ddl2gans.Focus();
                bol = true;
                return;
            }
            if (ddl3aques.SelectedItem.Text == "" || ddl3aques.SelectedItem.Value == "0")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Select any one in Self Enhancement and Training');", true);
                ddl3aques.Focus();
                bol = true;
                return;
            }
            if(ddl3aques.SelectedItem.Value == "1")
            {
                if (txtSpecify.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Kindly Specify anyone Self enhancement and Training ');", true);
                    txtSpecify.Focus();
                    bol = true;
                    return;
                }
            }

            if (txt3aTQues.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Kindly Fill Technical');", true);
                txt3aTQues.Focus();
                bol = true;
                return;
            }
            if (txt3aFQues.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Kindly Fill Functional');", true);
                txt3aFQues.Focus();
                bol = true;
                return;
            }
            if (txt3aSQues.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Kindly Fill Soft Skills');", true);
                txt3aSQues.Focus();
                bol = true;
                return;
            }


           if (txt4aQues.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Kindly Fill the answer in Future Objectives 4A');", true);
                txt4aQues.Focus();
                bol = true;
                return;
            }
            if (txt4bQues.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Kindly Fill the answer in Future Objectives 4B');", true);
                txt4bQues.Focus();
                bol = true;
                return;
            }

        }

        protected void ddl3aques_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl3aques.SelectedItem.Value == "1")
            {
                //txt3aTQues.Enabled = false;
                //txt3aFQues.Enabled = false;
                //txt3aSQues.Enabled = false;
            }
            else
            {
                //txt3aTQues.Enabled = true;
                //txt3aFQues.Enabled = true;
                //txt3aSQues.Enabled = true;
            }
        }

        protected void ddl3aques_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddl3aques.SelectedItem.Value == "1")
            {
                txtSpecify.Enabled = true;
                txtSpecify.Focus();
                //txt3aTQues.Enabled = true;
                //txt3aFQues.Enabled = true;
                //txt3aSQues.Enabled = true;
                //txt3aTQues.Focus();
            }
            else
            {
                txtSpecify.Enabled = true;
                //txt3aTQues.Enabled = false;
                //txt3aFQues.Enabled = false;
                //txt3aSQues.Enabled = false;
            }
        }

    }
}