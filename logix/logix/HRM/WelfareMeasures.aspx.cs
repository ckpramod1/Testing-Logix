using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class WelfareMeasures : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_Group~txt_Leave~txt_Wedding~txt_Referral";
                str_MsgLists = "Group Personal Accident Insurance Cover~Earn Leave Encashment~Employee Wedding~Employee Refferal";
                str_DataType = "String~String~String~String";
                btn_Save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                Fn_Loaddetail();

            }
        }
        private void Fn_Loaddetail()
        {
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_CompanyProfile.GetCompanyProfile(3);
            if (obj_dt.Rows.Count > 0)
            {
             //   btn_Save.Text = "Update";


                btn_Save.ToolTip = "Update";
                btn_Save1.Attributes["class"] = "btn btn-update1";
                txt_Group.Text = obj_dt.Rows[0][0].ToString();
                txt_Leave.Text = obj_dt.Rows[0][1].ToString();
                txt_Wedding.Text = obj_dt.Rows[0][2].ToString();
                txt_Referral.Text = obj_dt.Rows[0][3].ToString();
                
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (btn_Save.ToolTip == "Save")
            {
                //obj_da_CompanyProfile.InsWelfareMeasures(txt_Group.Text, txt_Leave.Text, txt_Wedding.Text, txt_Referral.Text);
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 970, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_Group.Text + "/S");
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
            }
            else if (btn_Save.ToolTip == "Update")
            {
                //obj_da_CompanyProfile.UpdWelfareMeasures(txt_Group.Text, txt_Leave.Text, txt_Wedding.Text, txt_Referral.Text);
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 970, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_Group.Text + "/U");
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
            }
        }
    }
}