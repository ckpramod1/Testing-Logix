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

namespace logix.HRM
{
    public partial class Quarter : System.Web.UI.Page
    {

        bool bluerr;
        int eid, intQtrId, Fyear, Qid, i, j, k;
        DataAccess.HR.Employee objHrEmp = new DataAccess.HR.Employee();
        DataAccess.Payroll.Details objdet = new DataAccess.Payroll.Details();
        DataAccess.PAYROLL.RentDetailss objRentt = new DataAccess.PAYROLL.RentDetailss();
        DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);

            DateTime getdate = da_obj_Logobj.GetDate();
            if (!IsPostBack)
            {
                FillYear();
                rdbExpired.Checked = true;
                options();
                loadgrd();
                txt_Empcode.Focus();
                txtamt.Text = "";
                Session["Packages"] = lbl_Header.Text;
               // btn_cancel.Text = "clear";

                btn_cancel.ToolTip = "clear";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";

            }


            if (Session["empcode"] != null)
            {
                txt_Empcode.Text = Session["empcode"].ToString();
                txt_Empcode_TextChanged(sender, e);
                Session["empcode"] = null;
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            checkdata();
            if( bluerr == true)
            {
                bluerr = false;
                return;
            }
            double amount = Convert.ToDouble( txtamt.Text);
            int total = Convert.ToInt32(amount);
            
                dt2 = objRentt.GetInsUpdQuarterDtl(Convert.ToInt32(Hid_Empid.Value), Convert.ToInt32(hid_quaot.Value), txtQuarter.Text, total, Convert.ToInt32(Hid_Fyear.Value));
            
            if (dt2.Rows.Count > 0)
            {
                da_obj_Logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1305, 1, int.Parse(Session["LoginBranchid"].ToString()), Hid_Empid.Value + "/S");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated');", true);
                bluerr = true;
                clear();
                loadgrd();
            }
            else
            {
                da_obj_Logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1305, 2, int.Parse(Session["LoginBranchid"].ToString()), Hid_Empid.Value + "/U");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved');", true);
               // btn_save.Text = "Update";


                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                clear();
                loadgrd();
            }
            //btn_cancel.Text = "clear";

            btn_cancel.ToolTip = "clear";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            FillYear();
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "clear")
            {
                clear();
              //  btn_cancel.Text = "Back";

                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";

                grdInvest.DataSource = new DataTable();
                grdInvest.DataBind();
                txt_Empcode.Focus();
                FillYear();
            }
            else
            {
                this.Response.End();
            }

        }

        public void checkdata()
        {
            string amt = txtamt.Text.ToString();

            if (txt_Empcode.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Enter the Employee Code');", true);
                bluerr = true;
                txt_Empcode.Focus();
            }
            else if (ddlmonth.SelectedItem.Text == "")
            {

                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Enter the Financial Year');", true);
                bluerr = true;
                ddlmonth.Focus();
            }
            else if (txtQuarter.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Enter the Quarter Marks');", true);
                bluerr = true;
                txtQuarter.Focus();
            }
            
            else if ( amt == "")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Enter the Amount');", true);
                bluerr = true;
                txtamt.Focus();

            }
            else if (rdbExpired.Checked == true)
            {
                intQtrId = 1;
                hid_quaot.Value = intQtrId.ToString();
            }
            else if (rdbLive.Checked == true)
            {
                intQtrId = 2;
                hid_quaot.Value = intQtrId.ToString();
            }
            else if (rdbBoth.Checked == true)
            {
                intQtrId = 3;
                hid_quaot.Value = intQtrId.ToString();
            }
            else if (rdb4.Checked == true)
            {
                intQtrId = 4;
                hid_quaot.Value = intQtrId.ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please Choose Any One Option');", true);
                bluerr = true;
            }

        }
        public void FillYear()
        {
            //ddlmonth.Items.Clear();
            //DateTime getdate = da_obj_Logobj.GetDate();
            //int i = 2008;
            //for(i = 2008;i<=getdate.Year;i++)
            //{
            //    ddlmonth.Items.Add((i).ToString() + " - " + (i + 1).ToString());

            //}
            //    if(getdate.Month<4)
            //    {

            //        ddlmonth.SelectedItem.Text = (getdate.Year - 1).ToString() + " - " + (getdate.Year).ToString();

            //    }
            //else
            //    {
            //        ddlmonth.SelectedItem.Text = (getdate.Year).ToString() + " - " + (getdate.Year + 1).ToString();
            //    }
            // }
            DateTime Dt_Date = da_obj_Logobj.GetDate();
            ddlmonth.Items.Clear();
            for (int i = 2008; i <= Dt_Date.Year; i++)
            {
                ddlmonth.Items.Add(new ListItem(i.ToString() + "-" + (i + 1).ToString(), i.ToString()));
            }
            if (Dt_Date.Month > 4)
            {
                ddlmonth.SelectedIndex = ddlmonth.Items.IndexOf(ddlmonth.Items.FindByValue(Dt_Date.Year.ToString()));
            }
            else
            {
                ddlmonth.SelectedIndex = ddlmonth.Items.IndexOf(ddlmonth.Items.FindByValue(Dt_Date.AddYears(-1).Year.ToString()));
            }

        }
        //If Month(logobj.GetDate()) < 4 Then
        //    cmbYear.Text = (Year(logobj.GetDate()) - 1).ToString() + " - " + (Year(logobj.GetDate())).ToString()
        //Else
        //    cmbYear.Text = (Year(logobj.GetDate())).ToString() + " - " + (Year(logobj.GetDate()) + 1).ToString()
        //}

        protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fyear = Convert.ToInt32(ddlmonth.SelectedItem.ToString().Substring(0, 4));
            Hid_Fyear.Value = Fyear.ToString();
            loadgrd();
        }

        public void loadgrd()
        {
            Fyear = Convert.ToInt32(ddlmonth.SelectedItem.ToString().Substring(0, 4));
            Hid_Fyear.Value = Fyear.ToString();
            if (txt_Empcode.Text.ToString() == "")
            {
                dt3 = objRentt.GetAllQuarterDtls(0, Convert.ToInt32(hid_quaot.Value), Fyear);
            }
            else
            {
                eid = objHrEmp.GetEmpId(txt_Empcode.Text);
                dt3 = objRentt.GetAllQuarterDtls(eid, Convert.ToInt32(hid_quaot.Value), Fyear);
            }
            grdInvest.DataSource = new DataTable();
            grdInvest.DataBind();
            if (dt3.Rows.Count > 0)
            {
                DataTable dt4 = new DataTable();
                dt4.Columns.Add("empcode");
                dt4.Columns.Add("empname");
                dt4.Columns.Add("quartermark");
                dt4.Columns.Add("quarteramt");
                dt4.Columns.Add("quarterid");
                dt4.Columns.Add("Fyear");

                for (int i = 0; i <= dt3.Rows.Count - 1; i++)
                {
                    dt4.Rows.Add();
                    dt4.Rows[i]["empcode"] = dt3.Rows[i]["empcode"];
                    dt4.Rows[i]["empname"] = dt3.Rows[i]["empname"];
                    dt4.Rows[i]["quartermark"] = dt3.Rows[i]["quartermark"];
                    double tot = Convert.ToDouble(dt3.Rows[i]["quarteramt"]);
                    dt4.Rows[i]["quarteramt"] = tot.ToString("#0.00");
                    dt4.Rows[i]["quarterid"] = dt3.Rows[i]["quarterid"];
                    dt4.Rows[i]["Fyear"] = dt3.Rows[i]["Fyear"];
                }
                grdInvest.DataSource = dt4;
                grdInvest.DataBind();

            }
            else
            {
                grdInvest.DataSource = new DataTable();
                grdInvest.DataBind();
            }


        }
        public void clear()
        {
            DateTime getdate = da_obj_Logobj.GetDate();

            txt_division.Text = "";
            txt_Grade.Text = "";
            txt_dept.Text = "";
            txt_designation.Text = "";
            txt_Empcode.Text = "";
            txt_Grade.Text = "";
            txt_EmpName.Text = "";
            txtQuarter.Text = "";
            txtamt.Text = "";
            //btn_cancel.Text = "Back";

            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";

            int i = 0;

            if (getdate.Month < 4)
            {
                ddlmonth.SelectedItem.Text = (getdate.Year - 1).ToString() + " - " + (getdate.Year).ToString();
            }
            else
            {
                ddlmonth.SelectedItem.Text = (getdate.Year).ToString() + " - " + (getdate.Year + 1).ToString();

            }

            rdbExpired.Checked = true;
            rdbLive.Checked = false;
            rdbBoth.Checked = false;
            rdb4.Checked = false;
            
          //  btn_save.Text = "Save";

            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";

        }
        public void options()
        {

            if (rdbExpired.Checked == true)
            {
                intQtrId = 1;
                hid_quaot.Value = intQtrId.ToString();
            }
            else if (rdbLive.Checked == true)
            {
                intQtrId = 2;
                hid_quaot.Value = intQtrId.ToString();
            }
            else if (rdbBoth.Checked == true)
            {
                intQtrId = 3;
                hid_quaot.Value = intQtrId.ToString();
            }
            else if (rdb4.Checked == true)
            {
                intQtrId = 4;
                hid_quaot.Value = intQtrId.ToString();
            }
        }

        protected void txt_Empcode_TextChanged(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            eid = objHrEmp.GetEmpId(txt_Empcode.Text);
            Hid_Empid.Value = eid.ToString();
            dt1 = objdet.GetEmpDetails(eid);

            if (dt1.Rows.Count > 0)
            {
                txt_Empcode.Text = dt1.Rows[0]["username"].ToString();
                txt_dept.Text = dt1.Rows[0]["deptname"].ToString();
                txt_designation.Text = dt1.Rows[0]["designame"].ToString();
                txt_Grade.Text = dt1.Rows[0]["grade"].ToString();
                txt_EmpName.Text = dt1.Rows[0]["empname"].ToString();
                txt_division.Text = dt1.Rows[0]["divisionname"].ToString();
                getdetails();
            //    btn_cancel.Text = "clear";


                btn_cancel.ToolTip = "clear";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                txtQuarter.Focus();

            }
            else
            {
                clear();
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Not a Valid User');", true);
                txt_Empcode.Focus();
                bluerr = true;
            }

        }
        public void getdetails()
        {

            dt1 = objRentt.GetQuarterDetails(Convert.ToInt32(Hid_Empid.Value), Convert.ToInt32(Hid_Fyear.Value));
            if (dt1.Rows.Count > 0)
            {
                txtQuarter.Text = dt1.Rows[0]["quartermark"].ToString();
                dt2 = objRentt.GetHRTDS4AmtQtr(Convert.ToInt32(Hid_Empid.Value), Convert.ToInt32(hid_quaot.Value), Convert.ToInt32(Hid_Fyear.Value));
                if (dt2.Rows.Count > 0)
                {
                    txtamt.Text = string.Format("0.00", dt2.Rows[0]["tdsamt"]);
                }
                else
                {
                    txtamt.Text = string.Format("0.00", "0");
                }
                Qid = Convert.ToInt32(dt1.Rows[0]["quarterid"].ToString());
                if (Qid == 1)
                {
                    rdbExpired.Checked = true;
                }
                else if (Qid == 2)
                {
                    rdbLive.Checked = true;
                }
                else if (Qid == 3)
                {
                    rdbBoth.Checked = true;
                }
                else if (Qid == 4)
                {
                    rdb4.Checked = true;
                }
                //btn_save.Text = "Update";


                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";

            }
            else
            {
               // btn_save.Text = "Save";

                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
            }

          
          //  btn_cancel.Text = "clear";

            btn_cancel.ToolTip = "clear";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";


        }

        public void getdtls1()
        {
            txtamt.Text = string.Format("0.00", "0");
            dt1 = objRentt.GetQuarterDetails(Convert.ToInt32(Hid_Empid.Value), Convert.ToInt32(Hid_Fyear.Value));

            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i <= dt1.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(hid_quaot.Value) == Convert.ToInt32(dt1.Rows[i]["quarterid"]))
                    {
                        double newamt = Convert.ToDouble(dt1.Rows[i]["quarteramt"].ToString());
                        txtQuarter.Text = dt1.Rows[i]["quartermark"].ToString();
                        txtamt.Text = newamt.ToString("#0.00");
                      //  btn_save.Text = "Update";
                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn btn-update1";
                        j = 1;

                    }

                }
                if (j == 1)
                {
                   // btn_save.Text = "Update";
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                }
                else
                {
                    txtQuarter.Text = "";
                  //  btn_save.Text = "Save";


                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                }
            }

            dt2 = objRentt.GetHRTDS4AmtQtr(Convert.ToInt32(Hid_Empid.Value), Convert.ToInt32(hid_quaot.Value), Convert.ToInt32(Hid_Fyear.Value));
            int k = 0;

            for (i = 0; i <= dt1.Rows.Count - 1; i++)
            {
                if (Convert.ToInt32(hid_quaot.Value) == Convert.ToInt32(dt1.Rows[i]["quarterid"]))
                {
                    double newamt = Convert.ToDouble(dt1.Rows[i]["quarteramt"].ToString());
                    txtamt.Text = newamt.ToString("#0.00");
                  //  btn_save.Text = "Update";

                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                    k = 1;

                }
            }
            if (k != 1)
            {
               
                if (dt2.Rows.Count > 0)
                {
                    double total = Convert.ToDouble(dt2.Rows[0]["tdsamt"].ToString());
                    txtamt.Text = total.ToString("#0.00");
                }
            }
            //btn_cancel.Text = "clear";


            btn_cancel.ToolTip = "clear";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void rdbExpired_CheckedChanged(object sender, EventArgs e)
        {

            options();
            loadgrd();
            if (txt_Empcode.Text != "")
            {
                getdtls1();
            }
            //btn_cancel.Text = "clear";

            btn_cancel.ToolTip = "clear";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

        }

        protected void rdbLive_CheckedChanged(object sender, EventArgs e)
        {

            options();
            loadgrd();
            if (txt_Empcode.Text != "")
            {
                getdtls1();
            }
          //  btn_cancel.Text = "clear";
            btn_cancel.ToolTip = "clear";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

        }

        protected void rdbBoth_CheckedChanged(object sender, EventArgs e)
        {

            options();
            loadgrd();
            if (txt_Empcode.Text != "")
            {
                getdtls1();
            }
         //   btn_cancel.Text = "clear";
            btn_cancel.ToolTip = "clear";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

        }

        protected void rdb4_CheckedChanged(object sender, EventArgs e)
        {
            options();
            loadgrd();
            if (txt_Empcode.Text != "")
            {
                getdtls1();
            }
            //btn_cancel.Text = "clear";
            btn_cancel.ToolTip = "clear";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

        }

        protected void lnk_empcode_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HRM/EmployeeFind.aspx");
        }

        protected void grdInvest_RowDataBound(object sender, GridViewRowEventArgs e)
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

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdInvest, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1305, "Job", "", "", Session["StrTranType"].ToString());

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