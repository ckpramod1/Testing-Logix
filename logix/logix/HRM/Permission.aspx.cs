using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class Permission : System.Web.UI.Page
    {
        DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        DateTime delkpi;
        int eid;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            try
            {
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_save, null,null);
            }
            if (!IsPostBack)
            {
                btn_save.Enabled = false;
                txt_EmpName.Focus();
                
                txt_date.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToShortDateString());
                Grd_Permission.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_Permission.DataBind();
               // btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";

                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_EmpName~hid_empcode~ddl_permission~ddl_session";
                str_MsgLists = "EmpName~EmpName~Permission~Session";
                str_DataType = "String~AutoComplete~DropDown~DropDown";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
            }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }

        protected void txt_EmpName_TextChanged(object sender, EventArgs e)
        {
            try
            {
            if (txt_EmpName.Text.TrimEnd().Length > 0)
            {
                Fn_GetDetail();
                btn_save.Enabled = true;
            }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }
        private void Fn_GetDetail()
        {
            try
            {
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Employee.SelForPermission(hid_empcode.Value.ToString());
            if (obj_dt.Rows.Count > 0)
            {
                txt_Empcode.Text = hid_empcode.Value.ToString();
                hid_Empid.Value = obj_dt.Rows[0][0].ToString();
                txt_designation.Text = obj_dt.Rows[0][4].ToString();
                txt_dept.Text = obj_dt.Rows[0][3].ToString();
                txt_location.Text = obj_dt.Rows[0][2].ToString();
                txt_division.Text = obj_dt.Rows[0][1].ToString();
                Fn_FillGridDetail();
                
            }

            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Correct Employee Code');", true);
                Fn_Clear();
            }
           // btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }
        private void Fn_FillGridDetail()
        {
            string Newdate;
            string date;
            DateTime dt_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Employee.SelHRPermissDtls(int.Parse(hid_Empid.Value), dt_date);
            DataTable dtemp = new DataTable();
            dtemp.Columns.Add("permissiondate");
            dtemp.Columns.Add("minutes");
            dtemp.Columns.Add("fnan");

            if (obj_dt.Rows.Count>0)
            {
                for (int i = 0; i <= obj_dt.Rows.Count - 1;i++ )
                {
                    dtemp.Rows.Add();
                    //date = obj_dt.Rows[i]["permissiondate"].ToString();
                   // Newdate =
                    dtemp.Rows[i]["permissiondate"] = Utility.fn_ConvertDate(obj_dt.Rows[i]["permissiondate"].ToString());
                    dtemp.Rows[i]["minutes"] = obj_dt.Rows[i]["minutes"].ToString()+" "+ "Minutes";
                    dtemp.Rows[i]["fnan"] = obj_dt.Rows[i]["fnan"].ToString();
                }
                Grd_Permission.DataSource = dtemp;
                Grd_Permission.DataBind();
            }
            else
            {
                Grd_Permission.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_Permission.DataBind();
            }
           
        }

        protected void Grd_Permission_SelectedIndexChanged(object sender, EventArgs e)
        {
            string permission="";
            int index = Grd_Permission.SelectedRow.RowIndex;
            if (Grd_Permission.Rows.Count > 0)
            {
              
                hid_date.Value = Grd_Permission.Rows[index].Cells[0].Text;
                permission = Grd_Permission.Rows[index].Cells[1].Text;
                if (permission == "10 Minutes")
                {
                    ddl_permission.SelectedValue = "1";
                }
                else if (permission == "20 Minutes")
                {
                    ddl_permission.SelectedValue = "2";
                }
                else if (permission == "30 Minutes")
                {
                    ddl_permission.SelectedValue = "3";
                }
                else if (permission == "40 Minutes")
                {

                    ddl_permission.SelectedValue = "4";
                }
                else if (permission == "50 Minutes")
                {
                    ddl_permission.SelectedValue = "5";
                }
                else if (permission == "60 Minutes")
                {
                    ddl_permission.SelectedValue = "6";
                }
                else if (permission == "70 Minutes")
                {
                    ddl_permission.SelectedValue = "7";
                }
                else if (permission == "80 Minutes")
                {
                    ddl_permission.SelectedValue = "8";
                }
                else if (permission == "90 Minutes")
                {
                    ddl_permission.SelectedValue = "9";
                }
                string afternoon = Grd_Permission.Rows[index].Cells[2].Text.TrimEnd();
                if (afternoon == "AfterNoon")
                {
                    hiddelcar.Value = "A";
                    ddl_session.SelectedValue = "A";
                }
                else
                {
                    hiddelcar.Value = "F";
                    ddl_session.SelectedValue = "F";
                }
               // btn_save.Text = "Update";

                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                PopUpService1.Show();
            }
        }
        private void Fn_Clear()
        {
            txt_EmpName.Text = "";
            txt_Empcode.Text = "";
            txt_dept.Text = "";
            txt_designation.Text = "";
            txt_division.Text = "";
            txt_location.Text = "";
           // btn_save.Text = "Ok";

            btn_save.ToolTip = "Ok";
            btn_save1.Attributes["class"] = "btn btn-Ok1";
            btn_save.Enabled = false;
            ddl_permission.SelectedIndex = 0;
            ddl_session.SelectedIndex = 0;

            DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            txt_date.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToShortDateString());

        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip=="Cancel")
            {
                txt_EmpName.Text = "";
                Fn_Clear();
                Grd_Permission.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_Permission.DataBind();
               // btn_cancel.Text = "Back";

                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                txt_EmpName.Focus();
            }
            else
            {
                this.Response.End();
            }
            
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
            if (btn_save.ToolTip == "Ok")
            {
                obj_da_Employee.InsPermissions(int.Parse(hid_Empid.Value.ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)), int.Parse(ddl_permission.SelectedItem.Text), char.Parse(ddl_session.SelectedItem.Value.ToString()));
                obj_da_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 299, 1, int.Parse(Session["LoginBranchid"].ToString()), hid_Empid.Value + "/S");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
            }
            else if (btn_save.ToolTip == "Update")
            {
                obj_da_Employee.UpdPermissions(int.Parse(hid_Empid.Value.ToString()), Convert.ToDateTime(Utility.fn_ConvertDate( hid_date.Value)), int.Parse(ddl_permission.SelectedItem.Text), char.Parse(ddl_session.SelectedItem.Value.ToString()));
                obj_da_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 299, 2, int.Parse(Session["LoginBranchid"].ToString()), hid_Empid.Value + "/U");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
                
            }
           
            Fn_FillGridDetail();
           // btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }

        protected void Grd_Permission_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Permission, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }

           
        }

        protected void btnkpiyes_Click(object sender, EventArgs e)
        {
            try
            {
                eid = Convert.ToInt32(hid_Empid.Value);
                delkpi = Convert.ToDateTime(Utility.fn_ConvertDate( hid_date.Value));
                char c = Convert.ToChar(hiddelcar.Value);
                obj_da_Employee.DelPermissions(eid, delkpi,c);
                ScriptManager.RegisterStartupScript(btnkpiyes, typeof(Button), "logix", "alertify.alert('Details Deleted');", true);

               Fn_FillGridDetail();

              // Fn_Clear();
               ddl_permission.SelectedIndex = 0;
               ddl_session.SelectedIndex = 0;
              // btn_save.Text = "Ok";

               btn_save.ToolTip = "Ok";
               btn_save1.Attributes["class"] = "btn btn-Ok1";

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void btnkpino_Click(object sender, EventArgs e)
        {
            return;
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 299, "Job", "", "", Session["StrTranType"].ToString());

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