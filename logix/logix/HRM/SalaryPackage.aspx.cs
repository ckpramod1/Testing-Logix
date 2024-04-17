using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace logix.HRM
{
    public partial class SalaryPackage : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {

            
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnBack);
            try { 
            if (!IsPostBack)
            {
                btn_save.Enabled = false;
                btn_delete.Enabled = false;
              
                txt_from.Text = "01" + "/04/" + Session["Vouyear"].ToString();
                txt_to.Text = "31" + "/03/" + (int.Parse(Session["Vouyear"].ToString()) + 1);
                Grd_Salary.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_Salary.DataBind();
                txt_Empcode.Focus();
                Session["Packages"] = lbl_header.Text;
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_Empcode~txt_Gross";
                str_MsgLists = "EmpCode~Gross";
                str_DataType = "String~String";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && IsDate('txt_from~txt_to');");
                btn_delete.Attributes.Add("OnClick", "return confirm('Do U Want Delete');");
                txt_Empcode.Focus();
            }
            btn_view.Enabled = false;

            if (Session["empcode"] != null)
            {
                txt_Empcode.Text = Session["empcode"].ToString();
                txt_Empcode_TextChanged(sender, e);
                Session["empcode"] = null;
            }
            txt_Gross.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_Gross');");
            txt_otherallow.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_otherallow');");
            txt_lunchallow.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_lunchallow');");
            txt_others.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_others');");
            txt_driverallow.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_driverallow');");
            txt_petrol.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_petrol');");
            txt_datacard.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_datacard');");
            txt_driverwages.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_driverwages');");
            txt_mobile.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_mobile');");
            txt_phone.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_phone');");
            txt_vma.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_vma');");
            txt_othervma.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_othervma');");
            txt_lta.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_lta');");
            txt_medical.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_medical');");
            txt_bonus.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_bonus');");
            txt_car.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_car');");
            txt_amount.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_amount');");
            txt_permonth.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_permonth');");
            txt_perannum.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_perannum');");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

           
        }

        protected void lnk_empcode_Click(object sender, EventArgs e)
        {
            //Popup_Emp.Show();
            //iframecost.Attributes["src"] = "../HRM/EmployeeFind.aspx";
            Response.Redirect("EmployeeFind.aspx");
        }
        private void Fn_GetDetail()
        {
            try { 
            if (txt_Empcode.Text.Trim().Length > 0)
            {
                DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
                DataTable obj_dt = new DataTable();
                DataTable obj_dtEmp = new DataTable();
                obj_dtEmp.Columns.Add("sfrom", typeof(string));
                obj_dtEmp.Columns.Add("sto", typeof(string));
                obj_dtEmp.Columns.Add("basic", typeof(double));
                obj_dtEmp.Columns.Add("hra", typeof(double));
                obj_dtEmp.Columns.Add("conveyance", typeof(double));
                obj_dtEmp.Columns.Add("sallowence", typeof(double));
                obj_dtEmp.Columns.Add("lta", typeof(double));
                obj_dtEmp.Columns.Add("medical", typeof(double));
                obj_dtEmp.Columns.Add("ctcmonth", typeof(double));
                obj_dtEmp.Columns.Add("ctcannum", typeof(double));
                obj_dtEmp.Columns.Add("esi", typeof(double));
                obj_dtEmp.Columns.Add("pf", typeof(double));
                obj_dtEmp.Columns.Add("others", typeof(double));
                obj_dtEmp.Columns.Add("entertainallow", typeof(double));
                obj_dtEmp.Columns.Add("loyality", typeof(double));
                obj_dtEmp.Columns.Add("lallowence", typeof(double));
                obj_dtEmp.Columns.Add("Expr2", typeof(double));
                obj_dtEmp.Columns.Add("datacard", typeof(double));
                obj_dtEmp.Columns.Add("mobile", typeof(double));
                obj_dtEmp.Columns.Add("petrol", typeof(double));
                obj_dtEmp.Columns.Add("phoner", typeof(double));
                obj_dtEmp.Columns.Add("bonus", typeof(double));
                obj_dtEmp.Columns.Add("Expr1", typeof(double));
                obj_dtEmp.Columns.Add("driverallow", typeof(double));
                obj_dtEmp.Columns.Add("driverwages", typeof(double));
                obj_dtEmp.Columns.Add("vma", typeof(double));
                obj_dtEmp.Columns.Add("mc", typeof(int));
                obj_dtEmp.Columns.Add("mcamt", typeof(double));
                obj_dtEmp.Columns.Add("Gross", typeof(double));
                DataRow dr;

                obj_dt = obj_da_Employee.SelEmpSalDtls(txt_Empcode.Text.Trim());
                if (obj_dt.Rows.Count > 0)
                {
                    txt_Empname.Text = obj_dt.Rows[0]["title"].ToString() + "." + obj_dt.Rows[0]["empname"].ToString();
                    txt_company.Text = obj_dt.Rows[0]["divisionname"].ToString().TrimEnd() + "," + obj_dt.Rows[0]["portname"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('No Data Found..');", true);
                    txt_Empcode.Focus();
                    //txt_Empcode.Text = "";
                    return;
                }
                //var Empname=obj_dt.AsEnumerable().Select(row => row.Field<string>("title").ToString() + "." + row.Field<string>("empname").ToString()).Distinct();
                //var Divname = obj_dt.AsEnumerable().Select(row => row.Field<string>("divisionname").ToString() + "," + row.Field<string>("portname").ToString()).Distinct();

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    double Esi, Total;
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);

                    dr[0] = Utility.fn_ConvertDate(obj_dt.Rows[i]["sfrom"].ToString());
                    dr[1] = Utility.fn_ConvertDate(obj_dt.Rows[i]["sto"].ToString());
                    dr[2] = string.Format("{0:0.00}", obj_dt.Rows[i]["basic"]);
                    dr[3] = string.Format("{0:0.00}", obj_dt.Rows[i]["hra"]);
                    dr[4] = string.Format("{0:0.00}", obj_dt.Rows[i]["conveyance"]);
                    dr[5] = string.Format("{0:0.00}", obj_dt.Rows[i]["sallowence"]);
                    dr[6] = string.Format("{0:0.00}", obj_dt.Rows[i]["lta"]);
                    dr[7] = string.Format("{0:0.00}", obj_dt.Rows[i]["medical"]);
                    if (double.Parse(obj_dt.Rows[i]["Gross"].ToString()) <= 15000)
                    {
                        Esi = (double.Parse(obj_dt.Rows[i]["Gross"].ToString()) * 4.75) / 100;
                    }
                    else
                    {
                        Esi = 0;
                    }
                    Total = double.Parse(obj_dt.Rows[i]["basic"].ToString()) + double.Parse(obj_dt.Rows[i]["hra"].ToString()) + double.Parse(obj_dt.Rows[i]["conveyance"].ToString()) + double.Parse(obj_dt.Rows[i]["sallowence"].ToString()) + double.Parse(obj_dt.Rows[i]["others"].ToString()) + double.Parse(obj_dt.Rows[i]["entertainallow"].ToString()) + double.Parse(obj_dt.Rows[i]["loyality"].ToString())
                        + double.Parse(obj_dt.Rows[i]["lallowence"].ToString()) + double.Parse(obj_dt.Rows[i]["Expr2"].ToString()) + double.Parse(obj_dt.Rows[i]["datacard"].ToString()) + double.Parse(obj_dt.Rows[i]["mobile"].ToString()) + double.Parse(obj_dt.Rows[i]["petrol"].ToString()) + double.Parse(obj_dt.Rows[i]["phoner"].ToString()) + double.Parse(obj_dt.Rows[i]["Expr1"].ToString()) + double.Parse(obj_dt.Rows[i]["bonus"].ToString()) + (double.Parse(obj_dt.Rows[i]["lta"].ToString()) / 12) + (double.Parse(obj_dt.Rows[i]["medical"].ToString()) / 12) + double.Parse(obj_dt.Rows[i]["driverallow"].ToString())
                        + double.Parse(obj_dt.Rows[i]["driverwages"].ToString()) + double.Parse(obj_dt.Rows[i]["vma"].ToString()) + double.Parse(obj_dt.Rows[i]["pf"].ToString()) + Esi;
                    dr[8] = string.Format("{0:0.00}", Total);
                    dr[9] = string.Format("{0:0.00}", (Total * 12));
                    dr[10] = string.Format("{0:0.00}", obj_dt.Rows[i]["esi"]);
                    dr[11] = string.Format("{0:0.00}", obj_dt.Rows[i]["pf"]);
                    dr[12] = string.Format("{0:0.00}", obj_dt.Rows[i]["others"]);
                    dr[13] = string.Format("{0:0.00}", obj_dt.Rows[i]["entertainallow"]);
                    dr[14] = string.Format("{0:0.00}", obj_dt.Rows[i]["loyality"]);
                    dr[15] = string.Format("{0:0.00}", obj_dt.Rows[i]["lallowence"]);
                    dr[16] = string.Format("{0:0.00}", obj_dt.Rows[i]["Expr2"]);
                    dr[17] = string.Format("{0:0.00}", obj_dt.Rows[i]["datacard"]);
                    dr[18] = string.Format("{0:0.00}", obj_dt.Rows[i]["mobile"]);
                    dr[19] = string.Format("{0:0.00}", obj_dt.Rows[i]["petrol"]);
                    dr[20] = string.Format("{0:0.00}", obj_dt.Rows[i]["phoner"]);
                    dr[21] = string.Format("{0:0.00}", obj_dt.Rows[i]["bonus"]);
                    dr[22] = string.Format("{0:0.00}", obj_dt.Rows[i]["Expr1"]);
                    dr[23] = string.Format("{0:0.00}", obj_dt.Rows[i]["driverallow"]);
                    dr[24] = string.Format("{0:0.00}", obj_dt.Rows[i]["driverwages"]);
                    dr[25] = string.Format("{0:0.00}", obj_dt.Rows[i]["vma"]);
                    dr[26] = string.Format("{0:0}", obj_dt.Rows[i]["mc"]);
                    dr[27] = string.Format("{0:0.00}", obj_dt.Rows[i]["mcamt"]);
                    dr[28] = string.Format("{0:0.00}", obj_dt.Rows[i]["Gross"]);
                }
                Grd_Salary.DataSource = obj_dtEmp;
                Grd_Salary.DataBind();
            }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_Empcode_TextChanged(object sender, EventArgs e)
        {
            try
            {

            Fn_GetDetail();
            //btnBack.Text = "Cancel";
            btnBack.ToolTip = "Cancel";
            btnBack1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_Empname_TextChanged(object sender, EventArgs e)
        {
            try { 
            txt_Empcode.Text = hid_empcode.Value.ToString();
            txt_Empcode_TextChanged(sender, e);
         //   btnBack.Text = "Cancel";

            btnBack.ToolTip = "Cancel";
            btnBack1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Salary_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_from.Text = Grd_Salary.SelectedRow.Cells[0].Text;
                txt_to.Text = Grd_Salary.SelectedRow.Cells[1].Text;
                txt_basic.Text = Grd_Salary.SelectedRow.Cells[2].Text;
                txt_hra.Text = Grd_Salary.SelectedRow.Cells[3].Text;
                txt_conveyance.Text = Grd_Salary.SelectedRow.Cells[4].Text;
                txt_specialallow.Text = Grd_Salary.SelectedRow.Cells[5].Text;
                txt_lta.Text = Grd_Salary.SelectedRow.Cells[6].Text;
                txt_medical.Text = Grd_Salary.SelectedRow.Cells[7].Text;
                txt_permonth.Text = Grd_Salary.SelectedRow.Cells[8].Text;
                txt_perannum.Text = Grd_Salary.SelectedRow.Cells[9].Text;

                txt_Gross.Text = Grd_Salary.SelectedDataKey.Values["Gross"].ToString();
                txt_pf.Text = Grd_Salary.SelectedDataKey.Values["pf"].ToString();
                txt_esi.Text = Grd_Salary.SelectedDataKey.Values["esi"].ToString();
                txt_entertainallow.Text = Grd_Salary.SelectedDataKey.Values["entertainallow"].ToString();
                txt_loyality.Text = Grd_Salary.SelectedDataKey.Values["loyality"].ToString();
                txt_otherallow.Text = Grd_Salary.SelectedDataKey.Values["Expr2"].ToString();
                txt_lunchallow.Text = Grd_Salary.SelectedDataKey.Values["lallowence"].ToString();
                txt_others.Text = Grd_Salary.SelectedDataKey.Values["Expr2"].ToString();
                txt_driverallow.Text = Grd_Salary.SelectedDataKey.Values["driverallow"].ToString();
                txt_petrol.Text = Grd_Salary.SelectedDataKey.Values["petrol"].ToString();
                txt_datacard.Text = Grd_Salary.SelectedDataKey.Values["datacard"].ToString();
                txt_driverwages.Text = Grd_Salary.SelectedDataKey.Values["driverwages"].ToString();
                txt_mobile.Text = Grd_Salary.SelectedDataKey.Values["mobile"].ToString();
                txt_phone.Text = Grd_Salary.SelectedDataKey.Values["phoner"].ToString();
                txt_vma.Text = Grd_Salary.SelectedDataKey.Values["vma"].ToString();
                txt_othervma.Text = Grd_Salary.SelectedDataKey.Values["Expr1"].ToString();
                txt_bonus.Text = Grd_Salary.SelectedDataKey.Values["bonus"].ToString();
                txt_car.Text = Grd_Salary.SelectedDataKey.Values["mc"].ToString();
                txt_amount.Text = Grd_Salary.SelectedDataKey.Values["mcamt"].ToString();

                //btn_save.Text = "Update";

                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                btn_save.Enabled = true;
                btn_delete.Enabled = true;
                txt_from.Enabled = false;
                txt_to.Enabled = false;
                txt_Gross.Focus();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        [WebMethod]
        public static string GetTotal(string Prefix)
        {
            string[] Str_Value = Prefix.Split(',');
            string str_Total = "";
            for (int i = 0; i <= Str_Value.Length - 1; i++)
            {
                if (Str_Value[i].ToString().TrimEnd().Length == 0)
                {
                    Str_Value[i] = "0";
                }
            }
            double Total = 0, Gross = 0;
            if (double.Parse(Str_Value[0].ToString()) <= 15000)
            {
                Gross = (double.Parse(Str_Value[0].ToString()) * 4.75) / 100;
            }
            Str_Value[20] = (double.Parse(Str_Value[20].ToString()) / 12).ToString();
            Str_Value[21] = (double.Parse(Str_Value[21].ToString()) / 12).ToString();
            Str_Value[22] = (double.Parse(Str_Value[22].ToString()) / 12).ToString();
            for (int i = 1; i <= Str_Value.Length - 1; i++)
            {
                Total = Total + double.Parse(Str_Value[i].ToString());
            }
            Total = Total + Gross;
            str_Total = string.Format("{0:0.##}", Total) + "~" + string.Format("{0:0.##}", (Total * 12));
            return str_Total;
        }

        private void Fn_Clear()
        {
            txt_Empcode.Text = "";
            txt_Empname.Text = "";
            txt_company.Text = "";
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            txt_from.Text = "01" + "/04/" + Session["Vouyear"].ToString();
            txt_to.Text = "31" + "/03/" + (int.Parse(Session["Vouyear"].ToString()) + 1);
            Grd_Salary.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Salary.DataBind();
           
            Fn_TxtClear();
        }
        private void Fn_TxtClear()
        {
           // btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            btn_save.Enabled = false;
            btn_delete.Enabled = false;
            txt_from.Enabled = true;
            txt_to.Enabled = true;

            txt_basic.Text = "";
            txt_hra.Text = "";
            txt_conveyance.Text = "";
            txt_specialallow.Text = "";
            txt_lta.Text = "";
            txt_medical.Text = "";
            txt_permonth.Text = "";
            txt_perannum.Text = "";
            txt_Gross.Text = "";
            txt_pf.Text = "";
            txt_esi.Text = "";
            txt_entertainallow.Text = "";
            txt_loyality.Text = "";
            txt_otherallow.Text = "";
            txt_lunchallow.Text = "";
            txt_others.Text = "";
            txt_driverallow.Text = "";
            txt_petrol.Text = "";
            txt_datacard.Text = "";
            txt_driverwages.Text = "";
            txt_mobile.Text = "";
            txt_phone.Text = "";
            txt_vma.Text = "";
            txt_othervma.Text = "";
            txt_bonus.Text = "";
            txt_car.Text = "";
            txt_amount.Text = "";
        }
        //protected void btn_cancel_Click(object sender, EventArgs e)
        //{
        //    Fn_Clear();
        //}
        private void Fn_TxtValue(TextBox[] Txt_Ctrl)
        {
            for (int i = 0; i <= Txt_Ctrl.Length - 1; i++)
            {
                if (Txt_Ctrl[i].Text.Trim() == "")
                {
                    Txt_Ctrl[i].Text = "0";
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            { 

            DateTime Dt_from, Dt_to;
            Dt_from = DateTime.Parse(Utility.fn_ConvertDate(txt_from.Text));
            Dt_to = DateTime.Parse(Utility.fn_ConvertDate(txt_to.Text));
            DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
            TextBox[] Txt_list = { txt_pf, txt_esi, txt_basic, txt_hra, txt_conveyance, txt_specialallow, txt_entertainallow, txt_loyality, txt_otherallow, txt_lunchallow, txt_others, txt_driverallow, txt_petrol, txt_datacard, txt_driverwages, txt_mobile, txt_phone, txt_vma, txt_othervma, txt_medical, txt_bonus, txt_lta,txt_car,txt_amount };
            Fn_TxtValue(Txt_list);
            if (btn_save.ToolTip == "Save")
            {
                if (obj_da_Employee.GetSalDtls4Ins(txt_Empcode.Text, Dt_from, Dt_to) == 0)
                {
                    obj_da_Employee.InsEmpSalaryNew(txt_Empcode.Text, double.Parse(txt_basic.Text), double.Parse(txt_hra.Text), double.Parse(txt_specialallow.Text),
                        double.Parse(txt_lunchallow.Text), double.Parse(txt_conveyance.Text), double.Parse(txt_others.Text), Dt_from, Dt_to, double.Parse(txt_loyality.Text)
                        ,double.Parse(txt_entertainallow.Text), double.Parse(txt_driverallow.Text), double.Parse(txt_medical.Text), double.Parse(txt_Gross.Text));
                    obj_da_Employee.InsEmpAnualCompensation(txt_Empcode.Text, double.Parse(txt_lta.Text), double.Parse(txt_medical.Text), double.Parse(txt_bonus.Text), double.Parse(txt_othervma.Text), Dt_from, Dt_to);
                    obj_da_Employee.InsEmpContribution(txt_Empcode.Text, double.Parse(txt_esi.Text), double.Parse(txt_pf.Text), Dt_from, Dt_to);
                    obj_da_Employee.InsEmpAllowances(txt_Empcode.Text, double.Parse(txt_petrol.Text), double.Parse(txt_mobile.Text), double.Parse(txt_phone.Text), double.Parse(txt_datacard.Text),
                        double.Parse(txt_others.Text), Dt_from, Dt_to, double.Parse(txt_vma.Text), double.Parse(txt_driverwages.Text), double.Parse(txt_car.Text), double.Parse(txt_amount.Text));

                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1070, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "/S");
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details already found');", true);
                    return;
                }

            }
            else if (btn_save.ToolTip == "Update")
            {
                obj_da_Employee.UpdEmpSalaryNew(txt_Empcode.Text, double.Parse(txt_basic.Text), double.Parse(txt_hra.Text), double.Parse(txt_specialallow.Text),
                        double.Parse(txt_lunchallow.Text), double.Parse(txt_conveyance.Text), double.Parse(txt_others.Text), Dt_from, Dt_to, double.Parse(txt_loyality.Text)
                        , double.Parse(txt_entertainallow.Text), double.Parse(txt_driverallow.Text), double.Parse(txt_medical.Text), double.Parse(txt_Gross.Text));
                obj_da_Employee.UpdEmpAnualCompensation(txt_Empcode.Text, double.Parse(txt_lta.Text), double.Parse(txt_medical.Text), double.Parse(txt_bonus.Text), double.Parse(txt_othervma.Text), Dt_from, Dt_to);
                obj_da_Employee.UpdEmpContribution(txt_Empcode.Text, double.Parse(txt_esi.Text), double.Parse(txt_pf.Text), Dt_from, Dt_to);
                obj_da_Employee.UpdEmpAllowances(txt_Empcode.Text, double.Parse(txt_petrol.Text), double.Parse(txt_mobile.Text), double.Parse(txt_phone.Text), double.Parse(txt_datacard.Text),
                    double.Parse(txt_others.Text), Dt_from, Dt_to, double.Parse(txt_vma.Text), double.Parse(txt_driverwages.Text), double.Parse(txt_car.Text), double.Parse(txt_amount.Text));

                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1070, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "/U");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
            }
            Fn_GetDetail();
            Fn_TxtClear();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_Gross_TextChanged(object sender, EventArgs e)
        {
            try
            {
            DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();

            if (txt_Empcode.Text.Trim().Length > 0)
            {
                TextBox[] Txt_list = { txt_pf, txt_esi, txt_basic, txt_hra, txt_conveyance, txt_specialallow, txt_entertainallow, txt_loyality, txt_otherallow, txt_lunchallow, txt_others, txt_driverallow, txt_petrol, txt_datacard, txt_driverwages, txt_mobile, txt_phone, txt_vma, txt_othervma, txt_medical, txt_bonus, txt_lta };
                Fn_TxtValue(Txt_list);
                if (txt_Gross.Text.Trim().Length > 0)
                {
                    txt_conveyance.Text = "800";
                    txt_basic.Text = ((double.Parse(txt_Gross.Text) / 100) * 50).ToString();
                    txt_loyality.Text = ((double.Parse(txt_Gross.Text) * 5) / 100).ToString();
                    double Basic = double.Parse(txt_basic.Text);
                    txt_hra.Text = ((Basic / 100) * 50).ToString();
                    txt_pf.Text = ((Basic * 12) / 100).ToString();
                    if (Basic < 15000)
                    {
                        txt_esi.Text = ((double.Parse(txt_Gross.Text) * 1.75) / 100).ToString();
                    }
                    else
                    {
                        txt_esi.Text = "0";
                    }
                    txt_lta.Text = txt_basic.Text;
                    if (Grd_Salary.Rows.Count > 0)
                    {
                        DataTable obj_dt = new DataTable();
                        obj_dt = obj_da_Employee.getgradedtls4salary(txt_Empcode.Text, DateTime.Parse(Utility.fn_ConvertDate(txt_from.Text)), DateTime.Parse(Utility.fn_ConvertDate(txt_to.Text)));
                        if (obj_dt.Rows.Count > 0)
                        {
                            txt_entertainallow.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["ea"]);
                            txt_driverallow.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["driverall"]);
                            txt_medical.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["medical"]);
                        }
                        else
                        {
                            txt_entertainallow.Text = "0";
                            txt_driverallow.Text = "0";
                            txt_medical.Text = "0";
                        }
                        double SpecialAllow = 0;
                        SpecialAllow = double.Parse(txt_hra.Text) - (double.Parse(txt_conveyance.Text) + double.Parse(txt_entertainallow.Text) + double.Parse(txt_driverallow.Text) + double.Parse(txt_loyality.Text));
                        if (SpecialAllow < 0)
                        {
                            txt_specialallow.Text = "0";
                        }
                        else
                        {
                            txt_specialallow.Text = SpecialAllow.ToString();
                        }
                    }
                    else
                    {
                        txt_pf.Text = "0";
                        txt_esi.Text = "0";
                    }
                }
                btn_save.Enabled = true;
                Fn_CalculateCTC();
            }
            else
            {
                ScriptManager.RegisterStartupScript(txt_Gross, typeof(TextBox), "HRM", "alertify.alert('Enter the Employee Code');", true);
                return;
            }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void Fn_CalculateCTC()
        {
            try
            {
            double Tot_Salary = 0;
            Tot_Salary = double.Parse(txt_basic.Text) + double.Parse(txt_hra.Text) + double.Parse(txt_specialallow.Text) + double.Parse(txt_lunchallow.Text) +
                    double.Parse(txt_conveyance.Text) + double.Parse(txt_otherallow.Text) + double.Parse(txt_loyality.Text) + double.Parse(txt_entertainallow.Text) +
                    double.Parse(txt_driverallow.Text) + (double.Parse(txt_lta.Text) / 12) + (double.Parse(txt_medical.Text) / 12) + (double.Parse(txt_bonus.Text) / 12) +
                    double.Parse(txt_others.Text) + double.Parse(txt_petrol.Text) + double.Parse(txt_mobile.Text) + double.Parse(txt_phone.Text) + double.Parse(txt_datacard.Text) +
                    double.Parse(txt_othervma.Text) + double.Parse(txt_vma.Text) + double.Parse(txt_driverwages.Text) + double.Parse(txt_pf.Text);
            if (double.Parse(txt_Gross.Text) <= 15000)
            {
                Tot_Salary = Tot_Salary + ((double.Parse(txt_Gross.Text) * 4.75) / 100);
            }
            txt_permonth.Text = string.Format("{0:0.00}", Tot_Salary);
            txt_perannum.Text = string.Format("{0:0.00}", (Tot_Salary * 12));
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            try { 
            DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
            DateTime Dt_from, Dt_to;
            Dt_from = DateTime.Parse(Utility.fn_ConvertDate(txt_from.Text));
            Dt_to = DateTime.Parse(Utility.fn_ConvertDate(txt_to.Text));

            obj_da_Employee.DelEmpSalary(txt_Empcode.Text, Dt_from, Dt_to);
            obj_da_Employee.DelEmpACompensation(txt_Empcode.Text, Dt_from, Dt_to);
            obj_da_Employee.DelEmpContribution(txt_Empcode.Text, Dt_from, Dt_to);
            obj_da_Employee.DelEmpAllowances(txt_Empcode.Text, Dt_from, Dt_to);
            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1070, 4, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "Delete");
            ScriptManager.RegisterStartupScript(btn_delete, typeof(Button), "HRM", "alertify.alert('Details Deleted');", true);
            Fn_GetDetail();
            Fn_TxtClear();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Salary_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text == "&nbsp;")
                {
                    e.Row.Cells[i].Text = "";
                }
                e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
            }
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Salary, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (btnBack.ToolTip == "Cancel")
            {
                Fn_Clear();
                txt_Empcode.Focus();
              //  btnBack.Text = "Back";
                btnBack.ToolTip = "Back";
                btnBack1.Attributes["class"] = "btn ico-back";

            }
            else
            {
                this.Response.End();
            }
        }

       
    }
}