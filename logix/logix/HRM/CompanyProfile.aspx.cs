using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class CompanyProfile : System.Web.UI.Page
    {
        DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_Profile~txt_Mission~txt_Achieve~txt_Philosophy~txt_Beleifs~txt_Hours~txt_DressCode~txt_Salary~txt_Leave~txt_Probation";
                str_MsgLists = "Corporate Profile~Our Mission~Plan To Acheive Our Mission~Our Philosophy~Our Beleifs~Working Hours~Dress Code~Salary Structure~Leave";
                str_DataType = "String~String~String~String~String~String~String~String~String~String";
                btn_Save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");

                Fn_Loaddetail();
            }
        }

        private void Fn_Loaddetail()
        {
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_CompanyProfile.GetCompanyProfile(1);
            if (obj_dt.Rows.Count > 0)
            {
                //btn_Save.Text = "Update";
                btn_Save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                txt_Profile.Text = obj_dt.Rows[0][0].ToString();
                txt_Mission.Text = obj_dt.Rows[0][1].ToString();
                txt_Achieve.Text = obj_dt.Rows[0][2].ToString();
                txt_Philosophy.Text = obj_dt.Rows[0][3].ToString();
                txt_Beleifs.Text = obj_dt.Rows[0][4].ToString();
                txt_Hours.Text = obj_dt.Rows[0][5].ToString();
                txt_DressCode.Text = obj_dt.Rows[0][6].ToString();
                txt_Salary.Text = obj_dt.Rows[0][7].ToString();
                txt_Leave.Text = obj_dt.Rows[0][8].ToString();
                txt_Probation.Text = obj_dt.Rows[0][9].ToString();
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (btn_Save.ToolTip == "Save")
            {
                obj_da_CompanyProfile.InsCompanyProfile(txt_Profile.Text, txt_Mission.Text, txt_Achieve.Text, txt_Philosophy.Text, txt_Beleifs.Text, txt_Hours.Text, txt_DressCode.Text, txt_Salary.Text, txt_Leave.Text, txt_Probation.Text);
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 968, 1, Convert.ToInt32(Session["LoginBranchid"]), "/ S");
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
            }
            else if (btn_Save.ToolTip == "Update")
            {
                obj_da_CompanyProfile.UpdCompanyProfile(txt_Profile.Text, txt_Mission.Text, txt_Achieve.Text, txt_Philosophy.Text, txt_Beleifs.Text, txt_Hours.Text, txt_DressCode.Text, txt_Salary.Text, txt_Leave.Text, txt_Probation.Text);
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 968, 2, Convert.ToInt32(Session["LoginBranchid"]), "/ U");
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
            }
        }
    }
}