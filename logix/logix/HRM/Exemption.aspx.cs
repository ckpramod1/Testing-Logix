using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
namespace logix.HRM
{
    public partial class Exemption : System.Web.UI.Page
    {
        DataAccess.payroll.MedicalExcemption medobj = new DataAccess.payroll.MedicalExcemption();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataTable dt = new DataTable();
        int yea,ans;
        string type, mex;
        Boolean blnerr;
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnback);
            if(!IsPostBack)
            {
                btnDelete.Enabled = false;
                txtExemption.Focus();
               
            }
            txtAmount.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
            txtyear.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
        }

        protected void txtyear_TextChanged(object sender, EventArgs e)
        {
            double temp;
            if(txtyear.Text!="")
            {
                yea = Convert.ToInt32 (txtyear.Text);
            }
            if(txtExemption.Text!="")
            {
                mex = (txtExemption.Text);
            }
            if (ddltype.SelectedValue == "1")
            {
                type = "M";
            }

            else if (ddltype.SelectedValue == "2")
            {
                type = "Y";
            }

            if(txtExemption.Text!="")
            {
                if(txtyear.Text!="")
                {
                    if (ddltype.SelectedValue != "0")
                    {
                        dt = medobj.GetMasExcem(txtExemption.Text,Convert.ToChar (type),Convert.ToInt32 (txtyear.Text));
                        
                        if(dt.Rows.Count>0)
                        {
                            temp = Convert.ToDouble (dt.Rows[0]["amount"].ToString());
                            txtAmount.Text = temp.ToString("#0.00");
                            //btnSave.Text = "Update";
                            btnSave.ToolTip = "Update";
                            btn_save1.Attributes["class"] = "btn btn-update1";
                            btnDelete.Enabled = true;
                            //btnback.Text = "Cancel";
                            btnback.ToolTip = "Cancel";
                            btn_cancel1.Attributes["class"] = "btn ico-cancel";
                        }
                    }
                }
            }
        }

        protected void Clear()
        {
            txtyear.Text = "";
            txtAmount.Text = "";
            txtExemption.Text = "";
            ddltype.SelectedValue = "0"; 
            //btnSave.Text = "Save";
            btnSave.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            //btnback.Text = "Cancel";
            btnback.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            btnDelete.Enabled = false;
            txtExemption.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            double con;
            if(btnSave.ToolTip=="Save")
            {
                emptycheck();
                if(blnerr==true)
                {
                    blnerr = false;
                    return;
                }

                if (ddltype.SelectedValue == "1")
                {
                    type = "M";
                }

                else if (ddltype.SelectedValue == "2")
                {
                    type = "Y";
                }

                Double amt;

                amt = Convert.ToDouble(txtAmount.Text);
                medobj.InsMasExcem(txtExemption.Text,Convert.ToChar (type),Convert.ToInt32 (txtyear.Text), amt);
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 802, 1, Convert.ToInt32(Session["LoginBranchid"]),""+txtExemption.Text+" / S");
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Details Saved');", true);
                Clear();
            }
            else if(btnSave.ToolTip=="Update")
            {
                emptycheck();
                if (blnerr == true)
                {
                    blnerr = false;
                    return;
                }
                con = Convert.ToDouble (txtAmount.Text);
                if(con >0)
                {
                    if (ddltype.SelectedValue == "1")
                    {
                        type = "M";
                    }

                    else if (ddltype.SelectedValue == "2")
                    {
                        type = "Y";
                    }

                    medobj.UpdMedExcem(txtExemption.Text, Convert.ToChar(type), Convert.ToInt32(txtyear.Text), con);
                    obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 802, 2, Convert.ToInt32(Session["LoginBranchid"]), "" + txtExemption.Text + " / U");
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Details Updated');", true);
                    Clear();
                    txtExemption.Text = "";
                    ddltype.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('The Value MustBe Greaterthan Zero');", true);
                    txtAmount.Text = "";
                    txtAmount.Focus();
                }
            }
        }
        protected void emptycheck()
        {
            if(txtExemption.Text=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Excemption');", true);
                txtExemption.Focus();
                blnerr = true;
                return;
            }

            if (ddltype.SelectedValue == "0" )
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Select Excemption Type');", true);
                ddltype.Focus();
                blnerr = true;
                return;
            }
            if (txtAmount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Amount');", true);
                txtAmount.Focus();
                blnerr = true;
                return;
            }

            if (txtyear.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Year');", true);
                txtyear.Focus();
                blnerr = true;
                return;
            }
        }

        protected void btn_no_Click(object sender, EventArgs e)
        {
            return;
        }
        protected void btn_yes_Click(object sender, EventArgs e)
        {
            if (ddltype.Text == "1")
            {
                type = "M";
            }

            else if (ddltype.Text == "2")
            {
                type = "Y";
            }
            medobj.DelMasExcem(txtExemption.Text,Convert.ToChar( type),Convert.ToInt32( txtyear.Text));
            obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 802, 4, Convert.ToInt32(Session["LoginBranchid"]), "" + txtExemption.Text + "Deleted");
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Details Deleted');", true);
            Clear();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            this.PopUpService.Show();
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnback.ToolTip == "Back")
                {
                    this.Response.End();
                }
                else
                {
                    Clear();
                    txtExemption.Focus();
                }
            }
            catch(Exception ex)
            {
              string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            if (ddltype.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Select Excemption Type');", true);
                ddltype.Focus();
                return;
            }
            if (ddltype.SelectedValue == "1")
            {
                type = "M";
            }

            else if (ddltype.SelectedValue == "2")
            {
                type = "Y";
            }
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Str_RptName = "Payroll" + "//RptHRMediClaims.rpt";
            if (ddltype.SelectedValue != "0" && txtyear.Text != "")
            {
                Str_sp = "";
                Session["str_sfs"] = "{HRMasterMedicalClaims.type}='" + type + "'" + "and {HRMasterMedicalClaims.year}=" + txtyear.Text;
            }
            else if (ddltype.SelectedValue != "0")
            {
                Str_sp = "";
                Session["str_sfs"] = "{HRMasterMedicalClaims.type}='" + type + "'";
            }
            else
            {
                Str_sp = "";
                Session["str_sfs"] = "";
            }         
            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 802, 3, Convert.ToInt32(Session["LoginBranchid"]), "View");
            ScriptManager.RegisterStartupScript(btnView, typeof(Button), "HRM", Str_Script, true);
            //Session["str_sfs"] = Str_sf;
            Session["str_sp"] = Str_sp;
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 802, "Job", "", "", Session["StrTranType"].ToString());

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