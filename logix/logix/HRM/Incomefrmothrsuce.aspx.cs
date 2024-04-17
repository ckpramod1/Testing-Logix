using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
namespace logix.HRM
{
    public partial class Incomefrmothrsuce : System.Web.UI.Page
    {
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.HR.Employee objHrEmp = new DataAccess.HR.Employee();
        DataAccess.PAYROLL.RentDetailss objRentt = new DataAccess.PAYROLL.RentDetailss();
        DataAccess.Payroll.Details objdet = new DataAccess.Payroll.Details();
        int fyear, eid;
        Boolean boo;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnclr);
            if (!IsPostBack)
            {
                txtprevinco.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'preincome')");
                txtPrvtax.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'tax')");
                txtothrinco.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'otherincome')");
                txtAmt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'amount')");
                fillyear();
                Session["otherincome"] = header.Text;
                txt_Empcode.Focus();
            }
            if (txt_Empcode.Text != "")
            {
                btnDel.Attributes["onClick"] = "return confirm('Do u want to delete the data?');";
            }
            //btnDel.Enabled = false;
            //btnView.Enabled = false;
        }

        protected void cmbYear_TextChanged(object sender, EventArgs e)
        {

        }

        public void fillyear()
        {
            for (int i = 2010; i <= (logobj.GetDate()).Year; i++)
            {
                cmbYear.Items.Add((i).ToString() + " - " + (i + 1).ToString());
            }
            if ((logobj.GetDate().Month) < 4)
            {
                cmbYear.Text = ((logobj.GetDate()).Year - 1).ToString() + " - " + ((logobj.GetDate()).Year).ToString();
            }
            else
            {
                cmbYear.Text = ((logobj.GetDate()).Year).ToString() + " - " + ((logobj.GetDate()).Year + 1).ToString();
            }
            fyear = Convert.ToInt32(cmbYear.Text.Trim().ToUpper().ToString().Substring(0, 4));
            hid_year.Value = fyear.ToString();
        }
        protected void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            fyear = Convert.ToInt32(cmbYear.Text.Trim().ToUpper().ToString().Substring(0, 4));
            hid_year.Value = fyear.ToString();
            if (txt_Empcode.Text != "")
            {
                eid = Convert.ToInt32(objHrEmp.GetEmpId(txt_Empcode.Text));
                dt1 = objRentt.GetHouseRent(eid, fyear);
                if (dt1.Rows.Count > 0)
                {
                    txtAmt.Text = dt1.Rows[0]["income"].ToString();
                    txtAmt.Attributes.Add("placeholder", dt1.Rows[0]["otherincome"].ToString());
                    txtAmt.ToolTip = dt1.Rows[0]["otherincome"].ToString();
                    //btnSave.Text = "Update";
                    btnSave.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                    btnDel.Enabled = true;
                }
                else
                {
                    txtAmt.Text = "";
                    btnDel.Enabled = false;
                    //btnSave.Text = "Save";
                    btnSave.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                }

            }
        }

        public void clear()
        {
            txt_Empcode.Focus();
            txt_Comp.Text = "";
            txt_Dept.Text = "";
            txt_Desg.Text = "";
            txt_Empcode.Text = "";
            txt_Grade.Text = "";
            txtEmpName.Text = "";
            txtAmt.Text = "";
            txtprevinco.Text = "";
            txtothrinco.Text = "";
            txtPrvtax.Text = "";
            btnView.Enabled = false;
            //btnclr.Text = "Back";
            btnclr.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
            if ((logobj.GetDate().Month) < 4)
            {
                cmbYear.Text = ((logobj.GetDate()).Year - 1).ToString() + " - " + ((logobj.GetDate()).Year).ToString();
            }
            else
            {
                cmbYear.Text = ((logobj.GetDate()).Year).ToString() + " - " + ((logobj.GetDate()).Year + 1).ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            checkdata();
            if (boo == true)
            {
                boo = false;
                return;
            }

            eid = Convert.ToInt32(objHrEmp.GetEmpId(txt_Empcode.Text));
            fyear = Convert.ToInt32(hid_year.Value);
            if (btnSave.ToolTip == "Save")
            {

                if (txtAmt.ToolTip == "House Rent Received PerAnnum")
                {
                    objRentt.InsHouseRent(eid, txtAmt.ToolTip, Convert.ToInt32(Convert.ToDouble(txtAmt.Text)), Convert.ToInt32(hid_year.Value));
                }
                if (txtprevinco.ToolTip == "Previous Employer Income")
                {
                    objRentt.InsHouseRent(eid, txtprevinco.ToolTip, Convert.ToInt32(Convert.ToDouble(txtprevinco.Text)), Convert.ToInt32(hid_year.Value));
                    objRentt.InsUpdPreEmpTaxPaid(eid, (logobj.GetDate()).Month, Convert.ToInt32(hid_year.Value), logobj.GetDate(), Convert.ToInt32(Convert.ToDouble(txtPrvtax.Text)));

                }
                if (txtothrinco.ToolTip == "OtherIncome")
                {
                    objRentt.InsHouseRent(eid, txtothrinco.ToolTip, Convert.ToInt32(Convert.ToDouble(txtothrinco.Text)), Convert.ToInt32(hid_year.Value));
                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Detail Saved');", true);
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1244, 1, Convert.ToInt32(Session["LoginBranchid"]), hid_year.Value + "/" + eid + "/S");
                //btnSave.Text = "Save";
                btnSave.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                clear();
                btnDel.Enabled = true;
            }
            else
            {
                if (btnSave.ToolTip == "Update")
                {
                    if (txtAmt.ToolTip == "House Rent Received PerAnnum")
                    {
                        objRentt.UpdHouseRent(eid, txtAmt.ToolTip, Convert.ToInt32(Convert.ToDouble(txtAmt.Text)), fyear);
                    }
                    if (txtprevinco.ToolTip == "Previous Employer Income")
                    {
                        objRentt.UpdHouseRent(eid, txtprevinco.ToolTip, Convert.ToInt32(Convert.ToDouble(txtprevinco.Text)), fyear);
                        objRentt.InsUpdPreEmpTaxPaid(eid, (logobj.GetDate()).Month, fyear, logobj.GetDate(), Convert.ToInt32(Convert.ToDouble(txtPrvtax.Text)));
                    }
                    if (txtothrinco.ToolTip == "OtherIncome")
                    {
                        objRentt.UpdHouseRent(eid, txtothrinco.ToolTip, Convert.ToInt32(Convert.ToDouble(txtothrinco.Text)), fyear);
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert(' Detail Updated');", true);
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1244, 2, Convert.ToInt32(Session["LoginBranchid"]), hid_year.Value + "/" + eid + "/U");
                    //btnSave.Text = "Save";
                    btnSave.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                    clear();
                    btnDel.Enabled = true;
                }
            }


        }

        public void checkdata()
        {
            if ((txt_Empcode.Text.Trim()) == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Employee Code');", true);
                boo = true;
                txt_Empcode.Focus();

            }
            if ((txtothrinco.Text.Trim()) == "" && (txtprevinco.Text.Trim()) == "" && (txtAmt.Text.Trim()) == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Employee Code');", true);
                boo = true;
            }
            if (txtAmt.Text == "")
            {
                txtAmt.Text = "0";
            }
            if (txtothrinco.Text == "")
            {
                txtothrinco.Text = "0";
            }
            if (txtprevinco.Text == "")
            {
                txtprevinco.Text = "0";
            }
        }
        protected void txt_Empcode_TextChanged(object sender, EventArgs e)
        {

            double temp;
            eid = objHrEmp.GetEmpId(txt_Empcode.Text);
            hid_eid.Value = eid.ToString();
            if (eid == 0)
            {

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter The Correct EmployeeCode');", true);
                txt_Empcode.Text = "";
                txt_Empcode.Focus();
                return;
            }
            fyear = Convert.ToInt32(hid_year.Value);
            dt1 = objdet.GetEmpDetails(eid);
            dt2 = objRentt.GetHouseRent(eid, fyear);
            if (dt1.Rows.Count > 0)
            {
                txtEmpName.Text = dt1.Rows[0]["empname"].ToString();
                txt_Comp.Text = dt1.Rows[0]["divisionname"].ToString();
                txt_Dept.Text = dt1.Rows[0]["deptname"].ToString();
                txt_Desg.Text = dt1.Rows[0]["designame"].ToString();
                txt_Grade.Text = dt1.Rows[0]["grade"].ToString();
                //dt2=objRentt.GetHouseRent(eid, int.Parse(cmbYear.SelectedValue.ToString()));
                if (dt2.Rows.Count > 0)
                {

                    for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        if (dt2.Rows[i]["otherincome"].ToString() == "House Rent Received PerAnnum")
                        {
                            var chosenRow = (from row in dt2.AsEnumerable()
                                             where row.Field<string>("otherincome") == "House Rent Received PerAnnum"
                                             select row).First();
                            //dtRow = dt2.Select("otherincome='House Rent Received PerAnnum'");
                            // txt_Empcode.Text = dt2.Rows[0]["empid"].ToString();
                            if (chosenRow != null)
                            {
                                temp = Convert.ToDouble(chosenRow[2]);
                                txtAmt.Text = temp.ToString("#0.00");
                                break;
                            }
                            else
                            {
                                chosenRow = (from row in dt2.AsEnumerable()
                                             where row.Field<string>("otherincome") == "House Rent Received"
                                             select row).First();
                                if (chosenRow != null)
                                {
                                    temp = Convert.ToDouble(chosenRow[2]);
                                    txtAmt.Text = temp.ToString("#0.00");
                                    break;
                                }
                                else
                                {
                                    txtAmt.Text = "0.00";
                                }
                            }
                        }
                        else
                        {
                            txtAmt.Text = "0.00";
                        }
                    }


                    for (int j = 0; j <= dt2.Rows.Count - 1; j++)
                    {
                        if (dt2.Rows[j]["otherincome"].ToString() == "Previous Employer Income")
                        {
                            var chosenRow = (from row in dt2.AsEnumerable()
                                             where row.Field<string>("otherincome") == "Previous Employer Income"
                                             select row).First();

                            temp = objRentt.GetHouseRent4PrvEmpTpaid(eid, fyear);
                            if (chosenRow != null)
                            {
                                txtPrvtax.Text = temp.ToString("#0.00");
                                temp = Convert.ToDouble(chosenRow[2]);
                                txtprevinco.Text = temp.ToString("#0.00");
                                break;
                            }
                            else
                            {
                                txtprevinco.Text = "0.00";
                                txtPrvtax.Text = "0.00";
                            }
                        }
                        else
                        {
                            txtprevinco.Text = "0.00";
                            txtPrvtax.Text = "0.00";
                        }
                    }

                    for (int k = 0; k <= dt2.Rows.Count - 1; k++)
                    {
                        if (dt2.Rows[k]["otherincome"].ToString() == "OtherIncome")
                        {
                            var chosenRow = (from row in dt2.AsEnumerable()
                                             where row.Field<string>("otherincome") == "OtherIncome"
                                             select row).First();
                            if (chosenRow != null)
                            {
                                temp = Convert.ToDouble(chosenRow[2]);
                                txtothrinco.Text = temp.ToString("#0.00");
                                break;
                            }
                            else
                            {
                                txtothrinco.Text = "0.00";
                            }
                        }
                        else
                        {
                            txtothrinco.Text = "0.00";
                        }
                    }



                    //btnSave.Text = "Update";
                    btnSave.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                    //btnDel.Enabled = true;
                    //dtRow = dt2.Select[0][0];
                }

                else
                {
                    txtAmt.Text = "0.00";
                    txtothrinco.Text = "0.00";
                    //btnSave.Text = "Save";
                    btnSave.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                    txtprevinco.Text = "0.00";
                    txtPrvtax.Text = "0.00";

                }
                btnDel.Enabled = true;
            }

            else
            {
                btnDel.Enabled = false;
                //btnSave.Text = "Save";
                btnSave.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
            }
            //btnclr.Text = "Cancel";
            btnclr.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

            btnView.Enabled = true;
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            eid = Convert.ToInt32(objHrEmp.GetEmpId(txt_Empcode.Text));
            if (eid == 0)
            {
                return;
            }
            fyear = Convert.ToInt32(hid_year.Value);

            if (txtAmt.ToolTip == "House Rent Received PerAnnum")
            {
                objRentt.DelHouseRent(eid,fyear, txtAmt.ToolTip );
            }
            if (txtprevinco.ToolTip == "Previous Employer Income")
            {
                objRentt.DelHouseRent(eid,fyear, txtprevinco.ToolTip);
            }
            if (txtothrinco.ToolTip == "OtherIncome")
            {
                objRentt.DelHouseRent(eid,fyear, txtothrinco.ToolTip);
            }
            logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1244, 4, int.Parse(Session["LoginBranchid"].ToString()),""+txt_Empcode.Text+" Delete");
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Successfully Deleted');", true);
            //btnSave.Text = "Save";
            btnSave.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            clear();
            btnDel.Enabled = true;
            txt_Empcode.Focus();
        }


        protected void btnView_Click(object sender, EventArgs e)
        {
            if (txt_Empcode.Text != "")
            {
                int year = Convert.ToInt32(hid_year.Value);
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                str_RptName = "/Payroll" + "/rptHouseRent.rpt";
                //  str_RptName = "BTStatus.rpt";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                str_sp = "year=" + (year - 1) + "-" + year;
                str_sf = "{HouseRent.empid}=" + hid_eid.Value + " and {HouseRent.fy}=" + year;
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1244, 3, int.Parse(Session["LoginBranchid"].ToString()), hid_year.Value + "/" + txt_Empcode.Text.ToString() + "/V");

                ScriptManager.RegisterStartupScript(btnView, typeof(Button), "HRM", str_Script, true);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter Employee code');", true);
            }



        }

        protected void btnclr_Click(object sender, EventArgs e)
        {

            if (btnclr.ToolTip == "Back")
            {
                this.Response.End();

            }
            else
            {
                clear();
                //btnSave.Text = "Save";
                btnSave.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";

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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1244, "Job", "", "", Session["StrTranType"].ToString());

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








