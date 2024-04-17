using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace logix.HRM
{
    public partial class IncomeTax : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Save);
          
            if (!IsPostBack)
            {
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "Txt_IncomeTax~Txt_ProAppr~Txt_Annu~Txt_Sug~Txt_IncPoli~Txt_GrivPoli";
                str_MsgLists = "Income Tax~Probation Apprasial~Annual Performance Appraisal~Suggestion Policy~Incentive Policy~Grievance Policy";
                str_DataType = "String";
                btn_Save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                Fn_Loaddetail();

            }
        }
        private void Fn_Loaddetail()
        {
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_CompanyProfile.GetCompanyProfile(4);
            if (obj_dt.Rows.Count > 0)
            {
                //btn_Save.Text = "Update";
                btn_Save.ToolTip = "Update";
                btn_save2.Attributes["class"] = "btn btn-update1";
                if (!string.IsNullOrEmpty(obj_dt.Rows[0][1].ToString()))
                {
                    Txt_IncomeTax.Text = obj_dt.Rows[0][1].ToString();
                }
                if (!string.IsNullOrEmpty(obj_dt.Rows[0][2].ToString()))
                {
                    Txt_ProAppr.Text = obj_dt.Rows[0][2].ToString();
                }
                if (!string.IsNullOrEmpty(obj_dt.Rows[0][3].ToString()))
                {
                    Txt_Annu.Text = obj_dt.Rows[0][3].ToString();
                }

                if (!string.IsNullOrEmpty(obj_dt.Rows[0][4].ToString()))
                {
                    Txt_Sug.Text = obj_dt.Rows[0][4].ToString();
                }

                if (!string.IsNullOrEmpty(obj_dt.Rows[0][5].ToString()))
                {
                    Txt_IncPoli.Text = obj_dt.Rows[0][5].ToString();
                }
                if (!string.IsNullOrEmpty(obj_dt.Rows[0][6].ToString()))
                {
                    Txt_GrivPoli.Text = obj_dt.Rows[0][6].ToString();
                }
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (btn_Save.ToolTip == "Save")
            {
                obj_da_CompanyProfile.InsupdIncometax(Txt_IncomeTax.Text, Txt_ProAppr.Text, Txt_Annu.Text, Txt_Sug.Text, Txt_IncPoli.Text, Txt_GrivPoli.Text, "save");
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1805, 1, int.Parse(Session["LoginBranchid"].ToString()), Txt_IncomeTax.Text + "/S");
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
            }
            else if (btn_Save.ToolTip == "Update")
            {
                obj_da_CompanyProfile.InsupdIncometax(Txt_IncomeTax.Text, Txt_ProAppr.Text, Txt_Annu.Text, Txt_Sug.Text, Txt_IncPoli.Text, Txt_GrivPoli.Text, "update");
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1805, 2, int.Parse(Session["LoginBranchid"].ToString()), Txt_IncomeTax.Text + "/U");
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
            }
        }
    }
}