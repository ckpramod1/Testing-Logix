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
    public partial class TDSUpdate : System.Web.UI.Page
    {
        DataAccess.Payroll.Details obj_da_Detail = new DataAccess.Payroll.Details();
        DataAccess.PAYROLL.HRTDetails obj_da_HRTDetail = new DataAccess.PAYROLL.HRTDetails();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataTable dtgetyr = new DataTable();
        double TDSAmt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_update, null, null);
            }

            if (!IsPostBack)
            {

                DateTime dt = obj_da_Log.GetDate();
                ddl_Month.SelectedIndex = ddl_Month.Items.IndexOf(ddl_Month.Items.FindByValue(dt.Month.ToString()));
                txt_Payyear.Text = dt.Year.ToString();
                txt_Deposite.Text = Utility.fn_ConvertDate(dt.ToShortDateString());
                Grd_TDS.DataSource = new DataTable();
                Grd_TDS.DataBind();
                txt_Empcode.Focus();
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "ddl_Month~txt_Payyear";
                str_MsgLists = "PayMonth~PayYear";
                str_DataType = "DropDown~Integer";
                btn_Get.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                txt_Payyear.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_Payyear');");
                str_CtrlLists = "txt_Empcode~ddl_Month~txt_Payyear~txt_Tds~txt_surcharge~txt_Edu~txt_Cheque~txt_BSR~txt_Chellan";
                str_MsgLists = "Empcode~PayMonth~PayYear~TDS Amount~Sur Charge~Edu.Chess~Cheque #~BSR Code~Chellan";
                str_DataType = "String~DropDown~Integer~Double~Double~Double~String~String~String";
                btn_update.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && IsDate('txt_Deposite');;");
                Session["Packages"] = lbl_Header.Text;
              //  btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }

            if (Session["empcode"] != null)
            {
                txt_Empcode.Text = Session["empcode"].ToString();
                txt_Empcode_TextChanged(sender, e);
                Session["empcode"] = null;
            }
        }

        protected void txt_Empcode_TextChanged(object sender, EventArgs e)
        {
            if (txt_Empcode.Text.TrimEnd().Length > 0)
            {
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_Detail.GetEmpDetails4TDS(txt_Empcode.Text);
                if (obj_dt.Rows.Count > 0)
                {
                    txt_Name.Text = obj_dt.Rows[0]["empname"].ToString();
                    txt_Dept.Text = obj_dt.Rows[0]["deptname"].ToString();
                    txt_Desg.Text = obj_dt.Rows[0]["designame"].ToString();
                    txt_Location.Text = obj_dt.Rows[0]["portname"].ToString();
                    txt_company.Text = obj_dt.Rows[0]["branchname"].ToString();
                    txt_Grade.Text = obj_dt.Rows[0]["grade"].ToString();
                    hid_Empid.Value = obj_dt.Rows[0]["employeeid"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(txt_Empcode, typeof(TextBox), "HRM", "alertify.alert('Enter The Correct EmployeeCode');", true);
                    Fn_Clear();
                    return;
                }
            }
            Fn_TxtpayYear();
            txt_Tds.Focus();
            //btn_cancel.Text = "Cancel";

            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        private void Fn_Clear()
        {
            txt_BSR.Text = "";
            txt_Chellan.Text = "";
            txt_Cheque.Text = "";
            txt_company.Text = "";
            txt_Deposite.Text = "";
            txt_Dept.Text = "";
            txt_Desg.Text = "";
            txt_Edu.Text = "";
            txt_Grade.Text = "";
            txt_Location.Text = "";
            txt_Name.Text = "";
            txt_surcharge.Text = "";
            txt_Tds.Text = "";
            txt_Total.Text = "";
            txt_Empcode.Text = "";

            DateTime dt = obj_da_Log.GetDate();
            ddl_Month.SelectedIndex = ddl_Month.Items.IndexOf(ddl_Month.Items.FindByValue(dt.Month.ToString()));
            txt_Payyear.Text = dt.Year.ToString();
          
            Grd_TDS.DataBind();
           // btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";

        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                Fn_Clear();
                Grd_TDS.DataSource = new DataTable();
                Grd_TDS.DataBind();
                txt_Empcode.Focus();
            }
            else
            {
                this.Response.End();
            }
        }
        private void Fn_TxtpayYear()
        {
            double tds = 0;
            double surchas = 0;
            double edu = 0;
            int int_Empid = hid_Empid.Value.ToString().TrimEnd().Length == 0 ? 0 : int.Parse(hid_Empid.Value.ToString());
            if (txt_Empcode.Text != "")
            {
                TDSAmt = obj_da_HRTDetail.GetTDStaxAmt(int.Parse(hid_Empid.Value.ToString()), ddl_Month.SelectedIndex, Convert.ToInt32(txt_Payyear.Text));
                txt_Tds.Text = TDSAmt.ToString("#0.00");
            }
            if (txt_Payyear.Text.TrimEnd().Length == 4)
            {
                DataAccess.PAYROLL.HRTDetails obj_da_HRTDetail = new DataAccess.PAYROLL.HRTDetails();
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_HRTDetail.GetHRTDetails(int.Parse(ddl_Month.SelectedValue.ToString()), int.Parse(txt_Payyear.Text), int_Empid);
                if (obj_dt.Rows.Count > 0)
                {
                    tds=Convert.ToDouble( obj_dt.Rows[0]["tds"].ToString());
                    txt_Tds.Text = tds.ToString("#0.00");
                    if (txt_Tds.Text=="")
                    {
                        txt_Tds.Text = "0.0";
                    }
                    else
                    {

                    }
                    surchas = Convert.ToDouble(obj_dt.Rows[0]["surcharge"].ToString());
                    txt_surcharge.Text = surchas.ToString("#0.00");
                    if (txt_surcharge.Text=="")
                    {
                        txt_surcharge.Text = "0.0";
                    }
                    else
                    {

                    }
                    edu = Convert.ToDouble(obj_dt.Rows[0]["educess"].ToString());
                    txt_Edu.Text = edu.ToString("#0.00");
                    if (txt_Edu.Text=="")
                    {
                        txt_Edu.Text = "0.0";
                    }
                    else
                    {

                    }
                    txt_Chellan.Text = obj_dt.Rows[0]["chellan"].ToString();
                    txt_Cheque.Text = obj_dt.Rows[0]["cheque"].ToString();
                    txt_BSR.Text = obj_dt.Rows[0]["bsrcode"].ToString();
                    txt_Deposite.Text = Utility.fn_ConvertDate(obj_dt.Rows[0]["depdate"].ToString());
                    txt_Total.Text = (double.Parse(txt_Tds.Text) + double.Parse(txt_surcharge.Text) + double.Parse(txt_Edu.Text)).ToString();
                }
                else
                {
                    txt_Tds.Text = "";
                    txt_surcharge.Text = "";
                    txt_Edu.Text = "";
                    txt_Chellan.Text = "";
                    txt_Cheque.Text = "";
                    txt_BSR.Text = "";
                    txt_Total.Text = "";
                }
                Fn_GetDetail();
                txt_Tds.Focus();
              //  btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }

        }
        private void Fn_GetDetail()
        {
            if (txt_Payyear.Text.TrimEnd().Length > 0)
            {
                DataAccess.PAYROLL.HRTDetails obj_da_HRTDetail = new DataAccess.PAYROLL.HRTDetails();
                DataTable obj_dt = new DataTable();
                int int_Empid = hid_Empid.Value.ToString().TrimEnd().Length == 0 ? 0 : int.Parse(hid_Empid.Value.ToString());
                if (txt_Empcode.Text.TrimEnd().Length == 0)
                {
                    obj_dt = obj_da_HRTDetail.GetHRTdsDetailsforgrd(int.Parse(ddl_Month.SelectedValue.ToString()), int.Parse(txt_Payyear.Text), int_Empid, "A");
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_Cheque.Text = obj_dt.Rows[0]["cheque"].ToString();
                        txt_Chellan.Text = obj_dt.Rows[0]["chellan"].ToString();
                        txt_BSR.Text = obj_dt.Rows[0]["bsrcode"].ToString();
                        txt_Deposite.Text = Utility.fn_ConvertDate(obj_dt.Rows[0]["depdate"].ToString());
                        Grd_TDS.DataSource = obj_dt;
                        Grd_TDS.DataBind();
                    }
                }
                else
                {
                    obj_dt = obj_da_HRTDetail.GetHRTdsDetailsforgrd(int.Parse(ddl_Month.SelectedValue.ToString()), int.Parse(txt_Payyear.Text), int_Empid, "E");
                    if (obj_dt.Rows.Count > 0)
                    {
                        Grd_TDS.DataSource = obj_dt;
                        Grd_TDS.DataBind();
                    }
                }
            }
          //  btn_cancel.Text = "Cancel";

            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
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
            //double Total = 0;
            //for (int i = 0; i <= Str_Value.Length - 1; i++)
            //{
            //    Total = Total + double.Parse(Str_Value[i].ToString());
            //}
            var sum = Str_Value.Sum(row => double.Parse(row.ToString()));
            str_Total = string.Format("{0:0.##}", sum);
            return str_Total;
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            DataTable obj_dt = new DataTable();
            obj_da_HRTDetail.HRInsHRTDDetailsWeb(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Month.SelectedValue.ToString()), int.Parse(txt_Payyear.Text), DateTime.Parse(Utility.fn_ConvertDate(txt_Deposite.Text))
                , double.Parse(txt_Tds.Text), double.Parse(txt_surcharge.Text), double.Parse(txt_Edu.Text), txt_Cheque.Text, txt_BSR.Text, txt_Chellan.Text, "T");
            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 800, 2, int.Parse(Session["LoginBranchid"].ToString()), ddl_Month.SelectedValue.ToString() + "/" + txt_Payyear.Text + "/" + hid_Empid.Value.ToString() + "/U");
            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "HRM", "alertify.alert('Details Updated Successfully');", true);
            Fn_Clear();
            obj_dt = obj_da_HRTDetail.GetHRTdsDetailsforgrd(int.Parse(ddl_Month.SelectedValue.ToString()), int.Parse(txt_Payyear.Text), Convert.ToInt32(hid_Empid.Value), "E");
            if (obj_dt.Rows.Count > 0)
            {
                Grd_TDS.DataSource = obj_dt;
                Grd_TDS.DataBind();
            }
            else
            {

            }
            //btn_cancel.Text = "Cancel";

            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void lnk_empcode_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HRM/EmployeeFind.aspx");
            //Popup_Emp.Show();
            //iframecost.Attributes["src"] = "../HRM/EmployeeFind.aspx";
        }

        protected void txt_Payyear_TextChanged(object sender, EventArgs e)
        {
            Fn_TxtpayYear();
            txt_Tds.Focus();
        }

        protected void btn_Get_Click(object sender, EventArgs e)
        {
            DateTime date = obj_da_Log.GetDate();
            if (ddl_Month.SelectedIndex == date.Month && Convert.ToInt32(txt_Payyear.Text) == date.Year)
            {
                ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "HRM", "alertify.alert('Current Month Not Alowed For this Transactuion');", true);
                return;
            }
            else
            {
                obj_da_HRTDetail.InsGetHrTdsfromPayroll(ddl_Month.SelectedIndex, Convert.ToInt32(txt_Payyear.Text));
                Fn_GetDetail();
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 800, 2, int.Parse(Session["LoginBranchid"].ToString()), ddl_Month.Text + "/" + Convert.ToInt32(txt_Payyear.Text) + "/" + "TotalEMP/GP/U");
            }
           // btn_cancel.Text = "Cancel";


            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Grd_TDS_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text == "&nbsp;")
                {
                    e.Row.Cells[i].Text = "";
                }
                e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
            }
            //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_TDS, "Select$" + e.Row.RowIndex);
            //e.Row.Attributes["style"] = "cursor:pointer";
        }

        protected void ddl_Month_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            Fn_TxtpayYear();
            txt_Tds.Focus();
            //btn_cancel.Text = "Cancel";

            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 800, "Job", "", "", Session["StrTranType"].ToString());

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
