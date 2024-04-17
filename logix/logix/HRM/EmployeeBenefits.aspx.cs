using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class EmployeeBenefits : System.Web.UI.Page
    {
        DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Save);
            if (!IsPostBack)
            {
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_Employee~txt_Gratutity~txt_Leaveemployee~txt_Medical~txt_Lunch~txt_Entertain~txt_Driver~txt_PF~txt_Bonus~txt_Travel~txt_grplifeins~txtvmr~txt_Group~txt_Wedding~txt_Referral~TextBox1";
                str_MsgLists = "Employees State Insurance~Gratuity~Leave Travel Allowance~Medical Allowance~Lunch Allowance~Entertainment Allowance~Driver Allowance~Employee Provident Fund~Bonus~Travel Per Diem~GROUP TERM LIFE INSURANCE~VEHICLE MAINTENANCE REIMBURSEMENTS~Group Personal Accident Insurance Cover~Employee Wedding~Employee Refferal~Ins Content";
                str_DataType = "String~String~String~String~String~String~String~String~String~String";
                btn_Save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                Fn_Loaddetail();
                
            }
        }
        private void Fn_Loaddetail()
        {
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_CompanyProfile.GetCompanyProfile(2);
            if (obj_dt.Rows.Count > 0)
            {
                //btn_Save.Text = "Update";
                btn_Save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                txt_Leaveemployee.Text = obj_dt.Rows[0][0].ToString();
                txt_Medical.Text = obj_dt.Rows[0][1].ToString();
                txt_Lunch.Text = obj_dt.Rows[0][2].ToString();
                txt_Entertain.Text = obj_dt.Rows[0][3].ToString();
                txt_Driver.Text = obj_dt.Rows[0][4].ToString();
                txt_PF.Text = obj_dt.Rows[0][5].ToString();
                txt_Employee.Text = obj_dt.Rows[0][6].ToString();
                txt_Gratutity.Text = obj_dt.Rows[0][7].ToString();
                txt_Bonus.Text = obj_dt.Rows[0][8].ToString();
                txt_Travel.Text = obj_dt.Rows[0][9].ToString();
                if (!string.IsNullOrEmpty(obj_dt.Rows[0][11].ToString()))
                {
                    txtvmr.Text = obj_dt.Rows[0][11].ToString();
                }
                if (!string.IsNullOrEmpty(obj_dt.Rows[0][12].ToString()))
                {
                    TextBox1.Text = obj_dt.Rows[0][12].ToString();
                }
            }
            DataTable obj_dt1 = new DataTable();
            obj_dt1 = obj_da_CompanyProfile.GetCompanyProfile(3);
            if (obj_dt1.Rows.Count > 0)
            {
                //btn_Save.Text = "Update";
                btn_Save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                txt_Group.Text = obj_dt1.Rows[0][0].ToString();
              //  txt_Leaveemployee.Text = obj_dt.Rows[0][1].ToString();
                txt_Wedding.Text = obj_dt1.Rows[0][2].ToString();
                txt_Referral.Text = obj_dt1.Rows[0][3].ToString();
                if (!string.IsNullOrEmpty(obj_dt1.Rows[0][5].ToString()))
                {
                    txt_grplifeins.Text = obj_dt1.Rows[0][5].ToString();
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (btn_Save.ToolTip == "Save")
            {
                obj_da_CompanyProfile.InsEmpBenefits(txt_Leaveemployee.Text, txt_Medical.Text, txt_Lunch.Text, txt_Entertain.Text, txt_Driver.Text, txt_PF.Text, txt_Employee.Text, txt_Gratutity.Text, txt_Bonus.Text, txt_Travel.Text, txtvmr.Text, TextBox1.Text);
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 969, 1, Convert.ToInt32(Session["LoginBranchid"]), " / S");
                obj_da_CompanyProfile.InsWelfareMeasures(txt_Group.Text, txt_Leaveemployee.Text, txt_Wedding.Text, txt_Referral.Text, txt_grplifeins.Text);
                obj_da_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 970, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_Group.Text + "/S");
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
            }
            else if (btn_Save.ToolTip == "Update")
            {
                obj_da_CompanyProfile.UpdEmpBenefits(txt_Leaveemployee.Text, txt_Medical.Text, txt_Lunch.Text, txt_Entertain.Text, txt_Driver.Text, txt_PF.Text, txt_Employee.Text, txt_Gratutity.Text, txt_Bonus.Text, txt_Travel.Text, txtvmr.Text, TextBox1.Text);
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 969, 2, Convert.ToInt32(Session["LoginBranchid"]), " / U");
                obj_da_CompanyProfile.UpdWelfareMeasures(txt_Group.Text, txt_Leaveemployee.Text, txt_Wedding.Text, txt_Referral.Text, txt_grplifeins.Text);
                obj_da_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 970, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_Group.Text + "/U");
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
            }
        }
    }
}