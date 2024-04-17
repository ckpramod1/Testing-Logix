using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class ProfTax : System.Web.UI.Page
    {
        DataAccess.PAYROLL.IncentiveDetails obj_da_IncentiveDetail = new DataAccess.PAYROLL.IncentiveDetails();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_View,btn_delete);
            }
            if (!IsPostBack)
            {
                ddl_Monrh.SelectedIndex = ddl_Monrh.Items.IndexOf(ddl_Monrh.Items.FindByValue(obj_da_Log.GetDate().Month.ToString()));
                txt_Year.Text = obj_da_Log.GetDate().Year.ToString();
                Fn_LoadData();
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_Empcode~ddl_Monrh~txt_Year~txt_Tax";
                str_MsgLists = "EmpCode~Month~Year~Professional Tax";
                str_DataType = "String~DropDown~Integer~Double";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                
            }
        }

        protected void txt_Empcode_TextChanged(object sender, EventArgs e)
        {
            if (ddl_Monrh.SelectedIndex != 0 && txt_Year.Text.TrimEnd().Length == 4)
            {
                if (txt_Empcode.Text.TrimEnd().Length > 0)
                {
                    int int_Month, int_Year;
                    int_Month = int.Parse(ddl_Monrh.SelectedValue.ToString());
                    int_Year = int.Parse(txt_Year.Text);
                    DataTable obj_dt = new DataTable();
                    obj_dt = obj_da_IncentiveDetail.Getempdtls(txt_Empcode.Text);
                    if (obj_dt.Rows.Count > 0)
                    {
                        if (DBNull.Value.Equals(obj_dt.Rows[0]["dol"]))
                        {
                            txt_Name.Text = obj_dt.Rows[0]["empname"].ToString();
                            txt_Company.Text = obj_dt.Rows[0]["divsname"].ToString() + "," + obj_dt.Rows[0]["portname"].ToString();
                            txt_Dept.Text = obj_dt.Rows[0]["deptname"].ToString();
                            txt_Desg.Text = obj_dt.Rows[0]["designame"].ToString();
                            txt_Grade.Text = obj_dt.Rows[0]["grade"].ToString();
                            hid_Empid.Value = obj_dt.Rows[0]["employeeid"].ToString();

                            obj_dt = obj_da_IncentiveDetail.GetHRProftaxdtls(int.Parse(hid_Empid.Value.ToString()), int_Month, int_Year);
                            if (obj_dt.Rows.Count > 0)
                            {
                                txt_Tax.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["amount"]);
                                btn_save.Text = "Update";
                            }
                            else
                            {
                                txt_Tax.Text = "";
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Entered employee is Resigned');", true);
                            txt_Empcode.Text = "";
                            txt_Empcode.Focus();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Enter the Correct Employee Code');", true);
                        Fn_Clear();
                        txt_Empcode.Focus();
                    }
                }
            }
        }
        private void Fn_Clear()
        {
            txt_Company.Text = "";
            txt_Dept.Text = "";
            txt_Desg.Text = "";
            txt_Empcode.Text = "";
            txt_Grade.Text = "";
            txt_Name.Text = "";
            txt_Tax.Text = "";
            txt_Year.Text = "";
            btn_save.Text = "Save";
            Grd_Tax.DataSource = new DataTable();
            Grd_Tax.DataBind();
            ddl_Monrh.SelectedIndex = ddl_Monrh.Items.IndexOf(ddl_Monrh.Items.FindByValue(obj_da_Log.GetDate().Month.ToString()));
            txt_Year.Text = obj_da_Log.GetDate().Year.ToString();
        }
        private void Fn_LoadData()
        {
            if (ddl_Monrh.SelectedIndex != 0 && txt_Year.Text.TrimEnd().Length == 4)
            {
                int int_Month, int_Year;
                int_Month = int.Parse(ddl_Monrh.SelectedValue.ToString());
                int_Year = int.Parse(txt_Year.Text);
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_IncentiveDetail.GetHRProftaxdtlsfrommonth(int_Month, int_Year);
                Grd_Tax.DataSource = obj_dt;
                Grd_Tax.DataBind();
            }
        }

        protected void ddl_Monrh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fn_LoadData();
        }

        protected void txt_Year_TextChanged(object sender, EventArgs e)
        {
            Fn_LoadData();
        }

        protected void Grd_Tax_SelectedIndexChanged(object sender, EventArgs e)
        {
            hid_Empid.Value = Grd_Tax.SelectedDataKey.Values[2].ToString();
            hid_Portid.Value = Grd_Tax.SelectedDataKey.Values[0].ToString();
            if (hid_confirm.Value.ToString() == "N")
            {
                txt_Empcode.Text = Grd_Tax.SelectedRow.Cells[0].Text;
                txt_Name.Text = Grd_Tax.SelectedDataKey.Values[3].ToString();
                txt_Company.Text = Grd_Tax.SelectedDataKey.Values[1].ToString();
                txt_Dept.Text = Grd_Tax.SelectedRow.Cells[3].Text;
                txt_Desg.Text = Grd_Tax.SelectedDataKey.Values[4].ToString();
                txt_Grade.Text = Grd_Tax.SelectedRow.Cells[2].Text;
                txt_Tax.Text = Grd_Tax.SelectedRow.Cells[7].Text;
                btn_save.Text = "Update";
            }
            else if (hid_confirm.Value.ToString() == "Y")
            {
                obj_da_IncentiveDetail.DElHRProftax(int.Parse(hid_Portid.Value.ToString()));
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 806, 4, int.Parse(Session["LoginBranchid"].ToString()), ddl_Monrh.SelectedValue.ToString() + "/" + txt_Year.Text + "/" + hid_Empid.Value.ToString() + "/D");
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Details Deleted Successfully');", true);
                Fn_Clear();
                Fn_LoadData();

            }
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            obj_da_IncentiveDetail.DElHRProftax(int.Parse(hid_Portid.Value.ToString()));
            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 806, 4, int.Parse(Session["LoginBranchid"].ToString()), ddl_Monrh.SelectedValue.ToString() + "/" + txt_Year.Text + "/" + hid_Empid.Value.ToString() + "/D");
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Details Deleted Successfully');", true);
            Fn_Clear();
            Fn_LoadData();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int int_Month, int_Year;
            int_Month = int.Parse(ddl_Monrh.SelectedValue.ToString());
            int_Year = int.Parse(txt_Year.Text);
            if (btn_save.Text == "Save")
            {
                obj_da_IncentiveDetail.InsHRProfTax(int.Parse(hid_Empid.Value.ToString()), int_Month, int_Year, decimal.Parse(txt_Tax.Text));
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 806, 1, int.Parse(Session["LoginBranchid"].ToString()), ddl_Monrh.SelectedValue.ToString() + "/" + txt_Year.Text + "/" + hid_Empid.Value.ToString() + "/S");
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Details Saved Successfully');", true);

                Fn_Clear();
                Fn_LoadData();
            }
            else if (btn_save.Text == "Update")
            {
                obj_da_IncentiveDetail.UpdHRProftax(int.Parse(hid_Empid.Value.ToString()), int.Parse(hid_Portid.Value.ToString()), int_Month, int_Year, double.Parse(txt_Tax.Text));
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 806, 2, int.Parse(Session["LoginBranchid"].ToString()), ddl_Monrh.SelectedValue.ToString() + "/" + txt_Year.Text + "/" + hid_Empid.Value.ToString() + "/U");
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Details Updated Successfully');", true);

                Fn_Clear();
                Fn_LoadData();
            }

        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            if (ddl_Monrh.SelectedIndex != 0 && txt_Year.Text.TrimEnd().Length == 4)
            {
                string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
                Str_RptName = "rptHRProfTaxSlap.rpt";
                Str_sp = "Month=" + ddl_Monrh.SelectedItem.Text + "~Year=" + txt_Year.Text;
                if (txt_Empcode.Text.TrimEnd().Length == 0)
                {
                    Str_sf = "{HRProfessionaltax.paymonth}=" + ddl_Monrh.SelectedValue.ToString() + "and {HRProfessionaltax.payyear}=" + txt_Year.Text;
                }
                else
                {
                    Str_sf = "{HRProfessionaltax.paymonth}=" + ddl_Monrh.SelectedValue.ToString() + "and {HRProfessionaltax.payyear}=" + txt_Year.Text + "and {HRProfessionaltax.empid}=" + hid_Empid.Value.ToString();
                }
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 806, 3, int.Parse(Session["LoginBranchid"].ToString()), ddl_Monrh.SelectedValue.ToString() + "/" + txt_Year.Text + "/" + hid_Empid.Value.ToString() + "/V");

            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Fn_Clear();
        }

        protected void lnk_empcode_Click(object sender, EventArgs e)
        {
            Popup_Emp.Show();
            iframecost.Attributes["src"] = "../HRM/EmployeeFind.aspx";
        }
    }
}