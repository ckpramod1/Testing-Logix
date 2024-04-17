using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logix;
using System.Data;

namespace logix.HRM
{
    public partial class HEAppraisalEnable : System.Web.UI.Page
    {
        DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataTable dtcom = new DataTable();
        int employeeid = 0;
        DataTable dtcompetencies = new DataTable();
        DataSet dscomp = new DataSet();
        DataTable dtkpi = new DataTable();
        DataTable dtsub = new DataTable();
        int year;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnsave);
            if (!IsPostBack)
            {
                year = Convert.ToInt32(DateTime.Now.Year.ToString());
                lblyear.Text = Session["Vouyear"].ToString() + '-' + Convert.ToInt32(DateTime.Now.Year.ToString());
                dtcom = da_obj_Employee.GetAppraisalEnable(year);
                if (dtcom.Rows.Count > 0)
                {
                    if (dtcom.Rows[0]["Enabledon"].ToString() != "")
                    {
                        chkenable.Checked = true;
                    }
                    else
                    {
                        chkenable.Checked = false;
                    }
                    //if (dtcom.Rows[0]["Closedon"].ToString() != "")
                    //{
                    //    chkdisable.Checked = true;
                    //}
                    //else
                    //{
                    //    chkdisable.Checked = false;
                    //}
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            year = Convert.ToInt32(DateTime.Now.Year.ToString());
            employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
             dtcom = da_obj_Employee.GetAppraisalEnable(year);
             if (dtcom.Rows.Count > 0)
             {
                 if (dtcom.Rows[0]["Enabledon"].ToString() == "")
                 {
                     if (chkenable.Checked == true)
                     {
                         da_obj_Employee.InsAppraisalEnable(employeeid, 1 , year);
                         obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1798, 1, Convert.ToInt32(Session["LoginBranchid"]), "/ S");
                         ScriptManager.RegisterStartupScript(chkenable, typeof(CheckBox), "HRM", "alertify.alert('Appraisal Enabled');", true);
                         return;
                     }
                 }
                 else
                 {
                     da_obj_Employee.InsAppraisalEnable(employeeid, 0, year);
                     obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1798, 1, Convert.ToInt32(Session["LoginBranchid"]), "/ S");
                     ScriptManager.RegisterStartupScript(chkenable, typeof(CheckBox), "HRM", "alertify.alert('Appraisal Disabled');", true);
                     return;
                 }
             }
             else
             {
                 if (chkenable.Checked == true)
                 {
                     da_obj_Employee.InsAppraisalEnable(employeeid, 1, year);
                     obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1798, 1, Convert.ToInt32(Session["LoginBranchid"]), "/ S");
                     ScriptManager.RegisterStartupScript(chkenable, typeof(CheckBox), "HRM", "alertify.alert('Appraisal Enabled');", true);
                     return;
                 }
                 else
                 {
                     da_obj_Employee.InsAppraisalEnable(employeeid, 0, year);
                     obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1798, 1, Convert.ToInt32(Session["LoginBranchid"]), "/ S");
                     ScriptManager.RegisterStartupScript(chkenable, typeof(CheckBox), "HRM", "alertify.alert('Appraisal Disabled');", true);
                     return;
                 }
             }
            //if (chkdisable.Checked == true)
            //{
            //    dtcompetencies = da_obj_Employee.GetDateDiffAppraisal(year);
            //    if(dtcompetencies.Rows.Count > 0 )
            //    {
            //        if(Convert.ToInt32(dtcompetencies.Rows[0]["DateDiff"].ToString()) < 15)
            //        {
            //            ScriptManager.RegisterStartupScript(chkdisable, typeof(CheckBox), "HRM", "alertify.alert('Minimum 15 days need to disable the Appraisal');", true);
            //        }
            //        else
            //        {
            //            da_obj_Employee.InsAppraisalEnable(0, employeeid, year);
            //            ScriptManager.RegisterStartupScript(chkdisable, typeof(CheckBox), "HRM", "alertify.alert('Appraisal Disabled');", true);
            //            return;
            //        }
            //    }
            //}
            
        }

        protected void chkdisable_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkdisable.Checked == true)
            //{
            //    dtcom = da_obj_Employee.GetAppraisalEnable(year);
            //    if (dtcom.Rows.Count > 0)
            //    {
            //        if (dtcom.Rows[0]["Enabledon"].ToString() == "")
            //        {
            //            ScriptManager.RegisterStartupScript(chkdisable, typeof(CheckBox), "HRM", "alertify.alert('Appraisal not yet enabled for this year');", true);
            //        }
            //    }
            //}
        }

        protected void chkenable_CheckedChanged(object sender, EventArgs e)
        {

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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1798, "Job", "", "", Session["StrTranType"].ToString());

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