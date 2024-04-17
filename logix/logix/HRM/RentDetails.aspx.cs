using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class RentDetails : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_update, btn_View,null);
            }
            if (!IsPostBack)
            {
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_Empcode~ddl_Year~txt_ActualRent";
                str_MsgLists = "EmpCode~Financial Year~Rent Amount";
                str_DataType = "String~DropDown~Double";
                btn_update.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                txt_ActualRent.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_ActualRent');");
                Fn_LoadDYear();
                Session["Rent Details"] = lbl.Text;
                Session["Packages"] = lbl.Text;
                txt_Empcode.Focus();
            }

            if (Session["empcode"]!=null)
            {
                txt_Empcode.Text = Session["empcode"].ToString();
                txt_Empcode_TextChanged(sender, e);
                Session["empcode"] = null;
            }
        }

        private void Fn_LoadDYear()
        {
            DateTime Dt_Date = obj_da_Log.GetDate();
            ddl_Year.Items.Clear();
            ddl_Year.Items.Add("");
            for (int i = 2008; i <= Dt_Date.Year; i++)
            {
                ddl_Year.Items.Add(new ListItem(i.ToString() + "-" + (i + 1).ToString(), i.ToString()));
            }
            if (Dt_Date.Month > 4)
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.Year.ToString()));
            }
            else
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.AddYears(-1).Year.ToString()));
            }
        }
        private void Fn_GetDetail()
        {
            DataTable obj_dt = new DataTable();
            DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
            DataAccess.Payroll.Details obj_da_detail = new DataAccess.Payroll.Details();

            int int_Empid = obj_da_Employee.GetEmpId(txt_Empcode.Text);
            hid_Empid.Value = int_Empid.ToString();
            obj_dt = obj_da_detail.GetEmpDetails(int_Empid);
            if (obj_dt.Rows.Count > 0)
            {
                txt_Name.Text = obj_dt.Rows[0]["empname"].ToString();
                txt_Company.Text = obj_dt.Rows[0]["divisionname"].ToString();
                txt_Dept.Text = obj_dt.Rows[0]["deptname"].ToString();
                txt_Desg.Text = obj_dt.Rows[0]["designame"].ToString();
                txt_Grade.Text = obj_dt.Rows[0]["grade"].ToString();

                var Result = obj_dt.AsEnumerable().Where(row => row.Field<Int16>("branch") == int.Parse("11315") ||
                    row.Field<Int16>("branch") == int.Parse("11288") ||
                    row.Field<Int16>("branch") == int.Parse("11312") ||
                    row.Field<Int16>("branch") == int.Parse("11289") ||
                    row.Field<Int16>("branch") == int.Parse("13906")).ToList();
                if (Result.Count > 0)
                {
                    hid_Amount.Value = "50";
                }
                else
                {
                    hid_Amount.Value = "40";
                }
                Fn_GetAmountDetail();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter The Correct EmployeeCode');", true);
            }
        }
        private void Fn_GetAmountDetail()
        {
            if (txt_Empcode.Text.TrimEnd().Length > 0 && ddl_Year.SelectedItem.Text!="")
            {
                DataAccess.PayrollProcess obj_da_PayRoll = new DataAccess.PayrollProcess();
                DataAccess.PAYROLL.RentDetailss obj_da_Rent = new DataAccess.PAYROLL.RentDetailss();
                DataTable obj_dt = new DataTable();
                DateTime dt_date = DateTime.Parse("11/1/" + ddl_Year.SelectedValue.ToString());
                if (Session["StrTranType"].ToString() == "HR")
                {
                    obj_dt = obj_da_PayRoll.GetEmpSalaryDetails(int.Parse(hid_Empid.Value.ToString()), dt_date);
                }
                else
                {
                    obj_dt = obj_da_PayRoll.GetEmpSalaryDetails(int.Parse(Session["LoginEmpId"].ToString()), dt_date);
                }
                if (obj_dt.Rows.Count > 0)
                {
                    double Basic = 0, HRA = 0;
                    Basic = double.Parse(obj_dt.Rows[0]["basic"].ToString());
                    HRA = double.Parse(obj_dt.Rows[0]["hra"].ToString()) * 12;

                    txt_Basic.Text = string.Format("{0:0.00}", Basic);
                    txt_RentReceived.Text = string.Format("{0:0.00}", HRA);
                    txt_Basic50.Text = string.Format("{0:0.00}", (((Basic * int.Parse(hid_Amount.Value.ToString())) / 100) * 12));
                    if (Session["StrTranType"].ToString() == "HR")
                    {
                        obj_dt = obj_da_Rent.HRGetRentDetails(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Year.SelectedValue.ToString()));
                    }
                    else
                    {
                        obj_dt = obj_da_Rent.HRGetRentDetails(int.Parse(Session["LoginEmpId"].ToString()), int.Parse(ddl_Year.SelectedValue.ToString()));
                    }
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_ActualRent.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["rp"]);
                        txt_RentReceived.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["rr"]);
                        if (obj_dt.Rows[0]["rb"].ToString().TrimEnd().Length > 0)
                        {
                            txt_RentPaid.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["rb"]);
                        }
                    }
                    else
                    {
                        txt_ActualRent.Text = "0";
                        txt_RentPaid.Text = "0";
                    }
                }
                else
                {
                    txt_Basic.Text = "";
                    txt_RentPaid.Text = "";
                    txt_Basic50.Text = "";
                    txt_ActualRent.Text = "";
                    txt_RentReceived.Text = "";
                }
            }
        }

        protected void txt_Empcode_TextChanged(object sender, EventArgs e)
        {
            if (txt_Empcode.Text.TrimEnd().Length > 0)
            {
                Fn_GetDetail();
            }
        }

        protected void txt_ActualRent_TextChanged(object sender, EventArgs e)
        {
            if (txt_ActualRent.Text.TrimEnd().Length > 0)
            {
                double Basic = 0, Rent = 0;
                int tot = 0;
                txt_Basic.Text = txt_Basic.Text.TrimEnd().Length == 0 ? "0" : txt_Basic.Text;
                Basic = (double.Parse(txt_Basic.Text) / 100) * 10;
                tot = Convert.ToInt32(Basic);
                Rent = double.Parse(txt_ActualRent.Text) - (tot * 12);
                if (Rent > 0)
                {
                    txt_RentPaid.Text = string.Format("{0:0.00}", Rent);
                }
                else
                {
                    txt_RentPaid.Text = "0";
                }
            }
        }

        protected void ddl_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fn_GetAmountDetail();
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            double ActualAmount = 0, Rentreceived = 0, RentPaid = 0, Basic50 = 0, Amount = 0;
            ActualAmount = double.Parse(txt_ActualRent.Text);
            Rentreceived = double.Parse(txt_RentReceived.Text);
            RentPaid = double.Parse(txt_RentPaid.Text);
            Basic50 = double.Parse(txt_Basic50.Text);
            double[] RentAmount = { ActualAmount, Rentreceived, RentPaid, Basic50 };
            Amount=RentAmount.Min();
            DataAccess.PAYROLL.RentDetailss obj_da_Rent = new DataAccess.PAYROLL.RentDetailss();
            obj_da_Rent.HRInsRentDetailsWeb(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Year.SelectedValue.ToString()), ActualAmount, Rentreceived, RentPaid, Amount, Basic50);
            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 803, 2, int.Parse(Session["LoginBranchid"].ToString()), ddl_Year.SelectedValue.ToString() + "/" + hid_Empid.Value.ToString() + "/U");
            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
            Fn_Clear();
        }
        private void Fn_Clear()
        {
            txt_ActualRent.Text = "";
            txt_Basic.Text = "";
            txt_Basic50.Text = "";
            txt_Company.Text = "";
            txt_Dept.Text = "";
            txt_Desg.Text = "";
            txt_Empcode.Text = "";
            txt_Grade.Text = "";
            txt_Name.Text = "";
            txt_RentPaid.Text = "";
            txt_RentReceived.Text = "";
            hid_Amount.Value = "50";
            Fn_LoadDYear();
           // btn_cancel.Text = "Back";

            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";

        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Str_RptName = "/Payroll/" +"rptHRRentExcmp.rpt";
            if (txt_Empcode.Text.TrimEnd().Length > 0 && ddl_Year.SelectedItem.Text!="")
            {
                Str_sf = "{HRRentDetails.fy}=" + ddl_Year.SelectedItem.Text.Substring(0, 4) + "and {HRRentDetails.empid}=" + hid_Empid.Value.ToString();
            }
            else
            {
                Str_sf = "{HRRentDetails.fy}=" + ddl_Year.SelectedItem.Text.Substring(0, 4);
            }
            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
            Session["str_sfs"] = Str_sf;
            Session["str_sp"] = Str_sp;
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                Fn_Clear();
                txt_Empcode.Focus();
            }
            else
            {
                this.Response.End();
            }
           
        }

        protected void lnk_empcode_Click(object sender, EventArgs e)
        {
            //Popup_Emp.Show();
            //iframecost.Attributes["src"] = "../HRM/EmployeeFind.aspx";
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 803, "Job", "", "", Session["StrTranType"].ToString());

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