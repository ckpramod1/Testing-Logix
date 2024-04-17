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
using System.Globalization;


namespace logix.Maintenance
{
    public partial class Customer_List : System.Web.UI.Page
    {
        int int_Custid;
        string Ctrl_List, Msg_List, Dtype_List;
        string str_Uiid = "";
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
                    Ctrl_List = txt_Salesperson.ID + "~" + txt_Customer.ID;
                    Msg_List = "Sales Person~Customer";
                    Dtype_List = "string~string";
                    btn_update.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    //str_Uiid = Request.QueryString["UIID"].ToString();
                    //Utility.Fn_CheckUserRights(str_Uiid, btn_update, null, null);
                    Empty_grid();
                    //btn_back.Text = "Cancel";

                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";


                    txt_Salesperson.Focus();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }
        [WebMethod]
        public static List<string> GetEmployeename(string prefix)
        {
            List<string> gname = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
            obj_dt = da_obj_employeeobj.GetLikeEmployee(prefix.ToUpper());              
            gname = Utility.Fn_DatatableToList_int16(obj_dt, "empnamecode", "employeeid");                 
            return gname;
        }
        [WebMethod]
        public static void GetBanName(string Prefix)
        {
            DataTable obj_dtEmp = new DataTable();

            if (Prefix.Length > 0)
            {
                DataAccess.Masters.MasterCustomer da_obj_Customerobj = new DataAccess.Masters.MasterCustomer();
                DataTable obj_dt = new DataTable();
                obj_dt = da_obj_Customerobj.GetCustomerDetailsforSales(Prefix.ToUpper());
                obj_dtEmp.Columns.Add("customerid");
                obj_dtEmp.Columns.Add("customername");
                obj_dtEmp.Columns.Add("address");
                obj_dtEmp.Columns.Add("portname");
                obj_dtEmp.Columns.Add("employeeid");
                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["customerid"] = obj_dt.Rows[i][0].ToString();
                    dr["customername"] = obj_dt.Rows[i][1].ToString();
                    dr["address"] = obj_dt.Rows[i][2].ToString();
                    dr["portname"] = obj_dt.Rows[i][3].ToString();
                    dr["employeeid"] = obj_dt.Rows[i][4].ToString();
                    //if (dr["employeeid"]=="")
                    //{
                    //    CheckBox check;
                    //    check = (CheckBox)(dr.Rows[4].FindControl("grdblselect"));
                    //}

                }
                HttpContext.Current.Session["Date"] = obj_dtEmp;

            }

        }
        private void Empty_grid()
        {
            DataTable dt_new = new DataTable();
           
                grd.DataSource = dt_new;
                grd.DataBind();
           
           
        }
        protected void txt_Salesperson_TextChanged(object sender, EventArgs e)
        {
            List<string> gname = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
            obj_dt = da_obj_employeeobj.GetLikeEmployee(txt_Salesperson.Text.ToUpper());
            gname = Utility.Fn_DatatableToList_int16(obj_dt, "empnamecode", "employeeid");
            if (obj_dt.Rows.Count>0)
            {
                gname = Utility.Fn_DatatableToList_int16(obj_dt, "empnamecode", "employeeid");

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Invalid customer');", true);
                txt_Salesperson.Text = "";
                return;
            }
            txt_Salesperson.Focus();
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                int empno=0;
                DataTable obj_dtEmp = new DataTable();
                if (txt_Customer.Text != "")
                {
                    if (Session["Date"] != null)
                    {
                        obj_dtEmp = (DataTable)Session["Date"];
                        grd.DataSource = obj_dtEmp;
                        grd.DataBind();

                    }


                    if (obj_dtEmp.Rows.Count>0)
                    {

                        
                        for (int j = 0; j <= grd.Rows.Count - 1; j++)
                        {
                            if (!string.IsNullOrEmpty(obj_dtEmp.Rows[j]["employeeid"].ToString()))
                            {
                             empno = Convert.ToInt32(obj_dtEmp.Rows[j]["employeeid"].ToString());
                            }
                            CheckBox chkRow = (grd.Rows[j].Cells[4].FindControl("grdblselect") as CheckBox);
                            if (hf_employeeid.Value != "" && hf_employeeid.Value != "0")
                            {
                                if (empno == Convert.ToInt32(hf_employeeid.Value))
                                {

                                    chkRow.Checked = true;
                                }
                                else
                                {
                                    chkRow.Checked = false;
                                }
                            }
                        }
                        

                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
                }
                else
                {
                    grd.DataSource = new DataTable();
                    grd.DataBind();
                }
               // btn_back.Text = "Cancel";

                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 

        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
                DataAccess.Masters.MasterCustomer da_obj_Customerobj = new DataAccess.Masters.MasterCustomer();

                Boolean bol_check = false;
                for (int f = 0; f < grd.Rows.Count; f++)
                {
                    CheckBox check;
                    check = (CheckBox)(grd.Rows[f].FindControl("grdblselect"));
                    if (check.Checked == true)
                    {
                        bol_check = true;
                    }
                }
                //if (!bol_check)
                //{
                //    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Select anyone of the filetype');", true);
                //    return;
                //}

                foreach (GridViewRow row in grd.Rows)
                {
                    int_Custid = int.Parse(grd.DataKeys[row.RowIndex].Values[0].ToString());

                    if (((CheckBox)row.Cells[3].FindControl("grdblselect")).Checked)
                    {
                        da_obj_Customerobj.UpdSalesInMCustomer(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(int_Custid));
                    }
                    else
                    {
                        da_obj_Customerobj.UpdSalesInMCustomer(0, Convert.ToInt32(int_Custid));
                    }
                    ScriptManager.RegisterStartupScript(btn_update, typeof(TextBox), "Outstanding", "alertify.alert('Details Updated');", true);
                }
                da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 631, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "intsalesid/intCustid");
                txt_Customer.Text = "";
                grd.DataSource = null;
                grd.DataBind();
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

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
           if( btn_back.ToolTip =="Cancel")
            {
            txt_Customer.Text = "";
            txt_Salesperson.Text = "";
            grd.DataSource = new DataTable();
            grd.DataBind();
           // btn_back.Text = "Back";

            btn_back.ToolTip = "Back";
            btn_back1.Attributes["class"] = "btn ico-back";
            txt_Salesperson.Focus();
            }
            else
           {
               this.Response.End();
           }
        }
    }
}