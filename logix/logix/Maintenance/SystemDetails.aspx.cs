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

namespace logix.Maintenance
{
    public partial class SystemDetails : System.Web.UI.Page
    {
        string str_pctype;
        string str_fdd;
        string str_cd;
        string str_dvd;
        string Ctrl_List, Msg_List, Dtype_List;
        string str_Uiid = "";
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            } 
            if (IsPostBack != true)
            {
                try
                {
                    Ctrl_List = txt_User.ID + "~" + hf_employeeid.ID + "~" + ddl_cmbPctype.ID + "~" + txt_Processor.ID + "~" + txt_Ram.ID + "~" + txt_Mb.ID + "~" + txt_Moniter.ID + "~" + txt_ip.ID + "~" + txt_HD.ID + "~" + ddl_cmbfdd.ID + "~" + ddl_cmbCd.ID + "~" + ddl_cmbDvd.ID;
                    Msg_List = "User ID~User ID~PC Type~Processor~RAM~MotherBoard~Monitor~IP Address~Hard Disk~Floppy Disk~CD~DVD";
                    Dtype_List = "int~Autocomplete~Dropdownlist~string~string~string~string~string~string~Dropdownlist~Dropdownlist~Dropdownlist";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    str_Uiid = Request.QueryString["type"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, null);
                    //btn_back.Text="Cancel";
                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                    txt_User.Focus();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }
        protected void txt_User_TextChanged(object sender, EventArgs e)
        {
            try { 
            DataAccess.Masters.MasterEmployee da_obj_Empobj = new DataAccess.Masters.MasterEmployee();
            DataAccess.HR.Employee da_obj_HREmpobj = new DataAccess.HR.Employee();
            DataAccess.SystemDetails da_obj_SDobj = new DataAccess.SystemDetails();
            DataTable dt_div = new DataTable();
            DataTable dt_user = new DataTable();

            if (txt_User.Text.ToString() != "")
            {
                hf_employeeid.Value = da_obj_Empobj.GetEmpid(txt_User.Text.ToUpper()).ToString();
                dt_div = da_obj_HREmpobj.GetBranchandDivisionempid(Convert.ToInt32(hf_employeeid.Value));
                if (dt_div.Rows.Count > 0)
                {
                    txt_division.Text = dt_div.Rows[0]["divisionname"].ToString();
                    txt_branch.Text = dt_div.Rows[0]["branch"].ToString();
                    txtname.Text = dt_div.Rows[0]["empname"].ToString();
                }
                dt_user = da_obj_SDobj.GetSystemDetails(txt_division.Text.ToUpper(), txt_branch.Text.ToUpper(), Convert.ToInt32(hf_employeeid.Value));
                if (dt_user.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt_user.Rows.Count - 1; i++)
                    {
                        str_pctype = dt_user.Rows[i][2].ToString();
                        ddl_cmbPctype.SelectedValue = str_pctype;

                        txt_Processor.Text = dt_user.Rows[i][3].ToString();
                        txt_Mb.Text = dt_user.Rows[i][4].ToString();
                        txt_Ram.Text = dt_user.Rows[i][5].ToString();
                        txt_Moniter.Text = dt_user.Rows[i][6].ToString();
                        txt_HD.Text = dt_user.Rows[i][7].ToString();
                        str_fdd = dt_user.Rows[i][8].ToString();

                        ddl_cmbfdd.SelectedValue = str_fdd;

                        str_cd = dt_user.Rows[i][9].ToString();
                        ddl_cmbCd.SelectedValue = str_cd;

                        str_dvd = dt_user.Rows[i][10].ToString();
                        ddl_cmbDvd.SelectedValue = str_dvd;

                        txt_DC.Text = dt_user.Rows[i][11].ToString();
                        txt_ip.Text = dt_user.Rows[i][12].ToString();

                    }
                   // btn_save.Text = "Update";
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";

                }
                else
                {
                }
               // btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";

              }
                }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txt_User.Focus();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try 
            {
            DataAccess.SystemDetails da_obj_SDobj = new DataAccess.SystemDetails();
            if (btn_save.ToolTip == "Save")
            {
                ddl_all();
                da_obj_SDobj.InsSystemDetail(txt_division.Text.ToUpper(), txt_branch.Text.ToUpper(), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(str_pctype), txt_Processor.Text.ToUpper(), txt_Mb.Text.ToUpper(), txt_Ram.Text.ToUpper(), txt_Moniter.Text.ToUpper(), txt_HD.Text.ToUpper(), Convert.ToChar(str_fdd), Convert.ToString(str_cd), Convert.ToString(str_dvd), txt_DC.Text.ToUpper(), txt_ip.Text.ToUpper());
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details saved');", true);
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 269, 1, int.Parse(Session["LoginBranchid"].ToString()), "Save");
                txtclear();
            }
            else if (btn_save.ToolTip == "Update")
            {
                ddl_all();
                da_obj_SDobj.UpdSystemDetails(txt_division.Text.ToUpper(), txt_branch.Text.ToUpper(), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(str_pctype), txt_Processor.Text.ToUpper(), txt_Mb.Text.ToUpper(), txt_Ram.Text.ToUpper(), txt_Moniter.Text.ToUpper(), txt_HD.Text.ToUpper(), Convert.ToChar(str_fdd), Convert.ToString(str_cd), Convert.ToString(str_dvd), Convert.ToString(txt_DC.Text.ToUpper()), txt_ip.Text.ToUpper());
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated');", true);
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 269,2, int.Parse(Session["LoginBranchid"].ToString()), "Update");
                txtclear();
            }

            //btn_back.Text = "Cancel";
            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 
        }
        private void ddl_all()
        {
            if (ddl_cmbfdd.SelectedValue == "Y")
            {
                str_fdd = "Y";
            }
            else
            {
                str_fdd = "N";
            }

            if (ddl_cmbPctype.SelectedValue == "D")
            {
                str_pctype = "D";
            }
            else if (ddl_cmbPctype.SelectedValue == "L")
            {
                str_pctype = "L";
            }

            if (ddl_cmbCd.SelectedValue == "1")
            {
                str_cd = "1";
            }
            else if (ddl_cmbCd.SelectedValue == "2")
            {
                str_cd = "2";
            }
            else if (ddl_cmbCd.SelectedValue == "0")
            {
                str_cd = "0";
            }
            if (ddl_cmbDvd.SelectedValue == "1")
            {
                str_dvd = "1";
            }
            else if (ddl_cmbDvd.SelectedValue == "2")
            {
                str_dvd = "2";
            }
            else if (ddl_cmbDvd.SelectedValue == "0")
            {
                str_dvd = "0";
            }

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if(btn_back.ToolTip=="Cancel")
            {
            txtclear();
            //btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
            //btn_back.Text = "Back";
            btn_back.ToolTip = "Back";
            btn_back1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
        }
        private void txtclear()
        {
            txtname.Text = "";
            txt_division.Text = "";
            txt_branch.Text = "";
            txt_User.Text = "";
            ddl_cmbPctype.SelectedIndex = -1;
            ddl_cmbfdd.SelectedIndex = -1;
            txt_DC.Text = "";
            txt_Moniter.Text = "";
            txt_Mb.Text = "";
            txt_Processor.Text = "";
            txt_Ram.Text = "";
            txt_HD.Text = "";
            ddl_cmbCd.SelectedIndex = -1;
            ddl_cmbDvd.SelectedIndex = -1;
            txt_ip.Text = "";
            txt_User.Focus();
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            string str_RptName = "", str_sf = "", str_Script = "", str_sp = "";
          
            if (string.IsNullOrEmpty(txt_User.Text))
            {
                str_RptName = "SystemDetails.rpt";
                str_sf = "";
                str_sp = "";
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 269,3, int.Parse(Session["LoginBranchid"].ToString()), "View");
            }
            else
            {
                str_RptName = "SystemDetailsIND.rpt";
                str_sf = "{systemdetails.userid}=" + Convert.ToInt32(hf_employeeid.Value);
                str_sp = "";
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 269,3, int.Parse(Session["LoginBranchid"].ToString()), "View");
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
            PanelLog1.Visible = true;
            GridViewlog.Visible = true;
            Panel2.Visible = true;
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 269, "MSSystem", txt_User.Text, txt_User.Text, "");  //"/Rate ID: " +
            if (txt_User.Text != "")
            {
                JobInput.Text = txt_User.Text;

            }
            else
            {
                JobInput.Text = "";
            }


            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }
    }
}