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
    public partial class MailingList : System.Web.UI.Page
    {
        string str_trantype;
        string cmbmenu;
        string cmbscreen;
        string Ctrl_List, Msg_List, Dtype_List;
        string str_Uiid = "";
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (IsPostBack != true)
            {
                Ctrl_List = ddl_cmbDivision.ID + "~" + ddl_cmbbranch.ID + "~" + ddl_cmbTrantype.ID + "~" + ddl_cmbmenu.ID + "~" + ddl_cmbscreen.ID + "~" + txt_emp.ID;
                Msg_List = "Division~Branch~Product~Menu~Screen~Name";
                Dtype_List = "Dropdownlist~Dropdownlist~Dropdownlist~Dropdownlist~Dropdownlist~string";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                //str_Uiid = Request.QueryString["UIID"].ToString();
                //Utility.Fn_CheckUserRights(str_Uiid, btn_save, null, null);
               // str_trantype = Session["StrTranType"].ToString();
                str_trantype = "MN";
                pagecode();
              //  btn_back.Text = "Cancel";

                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
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

        private void pagecode()
        {
            DataTable Dt_Fill = new DataTable();
            DataAccess.Masters.MailingList da_obj_ListObj = new DataAccess.Masters.MailingList();
            //str_trantype = Session["StrTranType"].ToString();
            str_trantype = "MN";
            if (str_trantype == "MN")
            {
                BindDivision();
                BindBranch();
            }
            else
            {
                ddl_cmbDivision.Items.Add(Session["LoginDivisionName"].ToString());
                ddl_cmbbranch.Items.Add(Session["LoginBranchName"].ToString());
                ddl_cmbDivision.Enabled = false;
                ddl_cmbbranch.Enabled = false;
                ddl_cmbDivision.SelectedValue = Session["LoginDivisionName"].ToString();
                ddl_cmbbranch.SelectedValue = Session["LoginBranchName"].ToString();
            }
            DataSet Ds;
            Ds = da_obj_ListObj.GetAllMailings("", "", "");
            if (Ds.Tables.Count > 0)
            {
                if (Ds.Tables[1].Rows.Count > 0)
                {
                    for (int j = 0; j <= Ds.Tables[1].Rows.Count - 1; j++)
                    {
                        if (Ds.Tables[1].Rows[j][0].ToString() == "AE")
                        {
                            ddl_cmbTrantype.Items.Add("Air Exports");
                        }
                        if (Ds.Tables[1].Rows[j][0].ToString() == "AI")
                        {
                            ddl_cmbTrantype.Items.Add("Air Imports");
                        }
                        if (Ds.Tables[1].Rows[j][0].ToString() == "FE")
                        {
                            ddl_cmbTrantype.Items.Add("Ocean Exports");
                        }
                        if (Ds.Tables[1].Rows[j][0].ToString() == "FI")
                        {
                            ddl_cmbTrantype.Items.Add("Ocean Imports");
                        }
                        if (Ds.Tables[1].Rows[j][0].ToString() == "AC")
                        {
                            ddl_cmbTrantype.Items.Add("Accounts");
                        }
                    }
                }
            }
            Dt_Fill = da_obj_ListObj.GetALLMailingList(0);
            if (Dt_Fill.Rows.Count > 0)
            {
                grd.DataSource = Dt_Fill;
                grd.DataBind();
            }
        }
        private void BindDivision()
        {
            DataAccess.HR.Employee da_obj_HrEmpObj = new DataAccess.HR.Employee();
            DataTable Dt = new DataTable();
            Dt = da_obj_HrEmpObj.GetDivision();
            ddl_cmbDivision.Items.Add("");

            if (Dt.Rows.Count > 0)
            {
                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    ddl_cmbDivision.Items.Add(Dt.Rows[i]["divisionname"].ToString());
                }
            }
        }
        private void BindBranch()
        {
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            DataTable Dt = new DataTable();

            Dt = da_obj_portobj.GetAllBranchNameforPortName();
            ddl_cmbbranch.Items.Add("");

            if (Dt.Rows.Count > 0)
            {
                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    ddl_cmbbranch.Items.Add(Dt.Rows[i]["portname"].ToString());
                }
            }
        }

        protected void ddl_cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MailingList da_obj_ListObj = new DataAccess.Masters.MailingList();
                DataAccess.HR.Employee da_obj_HrEmpObj = new DataAccess.HR.Employee();
                DataAccess.Masters.MasterBranch da_obj_bobj = new DataAccess.Masters.MasterBranch();
                DataTable Dt = new DataTable();
                DataTable Dt_div = new DataTable();
                ddl_cmbbranch.Items.Clear();
                ddl_cmbTrantype.Items.Clear();
                ddl_cmbmenu.Items.Clear();
                ddl_cmbscreen.Items.Clear();
                txt_emp.Text = "";

                Dt = da_obj_bobj.GetBranchByDivID(Convert.ToInt32(da_obj_HrEmpObj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))));
                if (Dt.Rows.Count > 0)
                {
                    ddl_cmbbranch.Items.Add("");
                    for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        ddl_cmbbranch.Items.Add(Dt.Rows[i]["branch"].ToString());
                    }
                }

                hf_divisionid.Value = da_obj_HrEmpObj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue)).ToString();

                if (hf_divisionid.Value != "0")
                {
                    Dt_div = da_obj_ListObj.GetALLMailingListDivwise(Convert.ToInt32(hf_divisionid.Value), 0);
                    if (Dt_div.Rows.Count > 0)
                    {
                        grd.DataSource = Dt_div;
                        grd.DataBind();
                        hf_branchid.Value = da_obj_HrEmpObj.GetBranchId(Convert.ToInt32(hf_divisionid.Value), Convert.ToString(ddl_cmbbranch.SelectedValue)).ToString();
                    }
                    else
                    {
                        grd.DataSource = new DataTable();
                        grd.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 

        }

        protected void ddl_cmbbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.HR.Employee da_obj_HrEmpObj = new DataAccess.HR.Employee();
                DataAccess.Masters.MailingList da_obj_ListObj = new DataAccess.Masters.MailingList();
                DataTable Dt_Bran = new DataTable();
                DataTable Dt_Fill = new DataTable();
                hf_branchid.Value = da_obj_HrEmpObj.GetBranchId(Convert.ToInt32(hf_divisionid.Value), Convert.ToString(ddl_cmbbranch.SelectedValue)).ToString();
                if (hf_divisionid.Value != "0" && hf_branchid.Value != "0")
                {
                    Dt_Bran = da_obj_ListObj.GetALLMailingListDivwise(Convert.ToInt32(hf_divisionid.Value), Convert.ToInt32(hf_branchid.Value));
                    if (Dt_Bran.Rows.Count > 0)
                    {
                        grd.DataSource = Dt_Bran;
                        grd.DataBind();
                    }
                    else
                    {
                        grd.DataSource = new DataTable();
                        grd.DataBind();
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('No Mailing List Exists');", true);
                        return;
                    }

                    DataSet Ds;
                    Ds = da_obj_ListObj.GetAllMailings("", "", "");
                    if (Ds.Tables.Count > 0)
                    {
                        ddl_cmbTrantype.Items.Add("");
                        if (Ds.Tables[1].Rows.Count > 0)
                        {
                            for (int j = 0; j <= Ds.Tables[1].Rows.Count - 1; j++)
                            {
                                if (Ds.Tables[1].Rows[j][0].ToString() == "AE")
                                {
                                    ddl_cmbTrantype.Items.Add("Air Exports");
                                }
                                if (Ds.Tables[1].Rows[j][0].ToString() == "AI")
                                {
                                    ddl_cmbTrantype.Items.Add("Air Imports");
                                }
                                if (Ds.Tables[1].Rows[j][0].ToString() == "FE")
                                {
                                    ddl_cmbTrantype.Items.Add("Ocean Exports");
                                }
                                if (Ds.Tables[1].Rows[j][0].ToString() == "FI")
                                {
                                    ddl_cmbTrantype.Items.Add("Ocean Imports");
                                }
                                if (Ds.Tables[1].Rows[j][0].ToString() == "AC")
                                {
                                    ddl_cmbTrantype.Items.Add("Accounts");
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 

        }

        protected void ddl_cmbTrantype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MailingList da_obj_ListObj = new DataAccess.Masters.MailingList();
                DataTable Dt_Tran = new DataTable();
                DataSet Ds;
                gettran();
                Ds = da_obj_ListObj.GetAllMailings(Convert.ToString(hf_tran.Value), "", "");
                if (Ds.Tables.Count > 0)
                {
                    if (Ds.Tables[2].Rows.Count > 0)
                    {
                        ddl_cmbmenu.Items.Clear();
                        ddl_cmbmenu.Items.Add("");
                        for (int k = 0; k <= Ds.Tables[2].Rows.Count - 1; k++)
                        {
                            ddl_cmbmenu.Items.Add(Ds.Tables[2].Rows[k][0].ToString());

                        }
                    }
                }

                if (hf_branchid.Value != "0")
                {
                    gettran();
                    if (hf_tran.Value != "")
                    {
                        Dt_Tran = da_obj_ListObj.GetMailingListAll("T", Convert.ToString(hf_tran.Value), "", "", Convert.ToInt32(hf_branchid.Value));

                        grd.DataSource = Dt_Tran;
                        grd.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 

        }

        private void gettran()
        {
            if (ddl_cmbTrantype.SelectedValue != "")
            {
                if (ddl_cmbTrantype.SelectedValue == "Ocean Exports")
                {
                    hf_tran.Value = "FE";
                }
                else if (ddl_cmbTrantype.SelectedValue == "Ocean Imports")
                {
                    hf_tran.Value = "FI";
                }
                else if (ddl_cmbTrantype.SelectedValue == "Air Exports")
                {
                    hf_tran.Value = "AE";
                }
                else if (ddl_cmbTrantype.SelectedValue == "Air Imports")
                {
                    hf_tran.Value = "AI";
                }
                else if (ddl_cmbTrantype.SelectedValue == "Accounts")
                {
                    hf_tran.Value = "AC";
                }
            }
        }

        protected void ddl_cmbmenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MailingList da_obj_ListObj = new DataAccess.Masters.MailingList();
                DataTable Dt_Tran = new DataTable();

                if (ddl_cmbTrantype.SelectedValue != "")
                {
                    gettran();
                    Dt_Tran = da_obj_ListObj.GetMailingListAll("m", Convert.ToString(hf_tran.Value), Convert.ToString(ddl_cmbmenu.SelectedValue), "", Convert.ToInt32(hf_branchid.Value));

                    grd.DataSource = Dt_Tran;
                    grd.DataBind();

                    DataSet Ds;
                    Ds = da_obj_ListObj.GetAllMailings(Convert.ToString(hf_tran.Value), Convert.ToString(ddl_cmbmenu.SelectedValue), "");
                    if (Ds.Tables.Count > 0)
                    {
                        ddl_cmbscreen.Items.Clear();
                        ddl_cmbscreen.Items.Add("");
                        if (Ds.Tables[3].Rows.Count > 0)
                        {
                            for (int k = 0; k <= Ds.Tables[3].Rows.Count - 1; k++)
                            {
                                ddl_cmbscreen.Items.Add(Ds.Tables[3].Rows[k][0].ToString());
                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select Product');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 

        }

        protected void ddl_cmbscreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MailingList da_obj_ListObj = new DataAccess.Masters.MailingList();
                DataTable Dt_Tran = new DataTable();
                if (!string.IsNullOrEmpty(ddl_cmbTrantype.SelectedValue) && !string.IsNullOrEmpty(ddl_cmbmenu.SelectedValue))
                {
                    gettran();
                    Dt_Tran = da_obj_ListObj.GetMailingListAll("s", Convert.ToString(hf_tran.Value), Convert.ToString(ddl_cmbmenu.SelectedValue), Convert.ToString(ddl_cmbscreen.SelectedValue), Convert.ToInt32(hf_branchid.Value));

                    grd.DataSource = Dt_Tran;
                    grd.DataBind();
                    DataSet Ds;

                    Ds = da_obj_ListObj.GetAllMailings(Convert.ToString(hf_tran.Value), Convert.ToString(ddl_cmbmenu.SelectedValue), Convert.ToString(ddl_cmbscreen.SelectedValue));
                    if (Ds.Tables.Count > 0)
                    {
                        if (Ds.Tables[4].Rows.Count > 0)
                        {
                            hf_uiid.Value = Ds.Tables[4].Rows[0][0].ToString();
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Alert');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable Dt_Tran = new DataTable();
                DataTable DT_all = new DataTable();
                DataAccess.Masters.MailingList da_obj_ListObj = new DataAccess.Masters.MailingList();
                if (btn_save.ToolTip == "Save")
                {
                    da_obj_ListObj.InsMalingList(Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(hf_employeeid.Value));
                    DT_all = da_obj_ListObj.GetMailingListAll("A", "", "", "", Convert.ToInt32(hf_branchid.Value));
                    grd.DataSource = DT_all;
                    grd.DataBind();
                    gettran();
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1230, 1, int.Parse(Session["LoginBranchid"].ToString()), "Save"); 
                  //  btn_back.Text = "Cancel";
                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    da_obj_ListObj.UpdMailingList(Convert.ToInt32(hf_empid.Value), Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(hf_oldid.Value));
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Mailing List Updated');", true);
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1230,2, int.Parse(Session["LoginBranchid"].ToString()), "update"); 
                  //  btn_save.Text = "Save";
                    //btn_back.Text = "Cancel";
                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";

                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                }
                Dt_Tran = da_obj_ListObj.GetMailingListAll("A", "", "", "", Convert.ToInt32(hf_branchid.Value));
                //For i = 0 To Grd.Rows.Count - 1
                //    Grd.Rows.Remove(Grd.Rows(0))
                //Next
                ddl_cmbTrantype.SelectedIndex = -1;
                ddl_cmbmenu.SelectedIndex = -1;
                ddl_cmbscreen.SelectedIndex = -1;
                grd.DataSource = Dt_Tran;
                txt_emp.Text = "";
                ddl_cmbDivision.Enabled = true;
                ddl_cmbbranch.Enabled = true;
                ddl_cmbTrantype.Enabled = true;
                ddl_cmbmenu.Enabled = true;
                ddl_cmbscreen.Enabled = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 

        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            int int_index;
            int_index = grd.SelectedRow.RowIndex;
            mdl_msg1.Show();
            return;
        }

        protected void btn_yes1_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.HR.Employee da_obj_HrEmpObj = new DataAccess.HR.Employee();
                DataAccess.Masters.MailingList da_obj_ListObj = new DataAccess.Masters.MailingList();
                DataTable Dt_div = new DataTable();
                int int_index;
                int_index = grd.SelectedRow.RowIndex;

                hf_uiid.Value = int.Parse(grd.DataKeys[int_index].Values[0].ToString()).ToString();
                hf_employeeid.Value = int.Parse(grd.DataKeys[int_index].Values[1].ToString()).ToString();
                hf_branchid.Value = int.Parse(grd.DataKeys[int_index].Values[2].ToString()).ToString();

                da_obj_ListObj.DelMailingList(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_uiid.Value));
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Mailing List Deleted');", true);
                gettran();
                hf_divisionid.Value = da_obj_HrEmpObj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue)).ToString();
                hf_branchid.Value = da_obj_HrEmpObj.GetBranchId(Convert.ToInt32(hf_divisionid.Value), Convert.ToString(ddl_cmbbranch.SelectedValue)).ToString();

                if (hf_divisionid.Value != "0")
                {
                    Dt_div = da_obj_ListObj.GetALLMailingListDivwise(Convert.ToInt32(hf_divisionid.Value), 0);
                }
                else
                {
                    Dt_div = da_obj_ListObj.GetALLMailingList(0);
                }
                if (Dt_div.Rows.Count > 0)
                {
                    grd.DataSource = Dt_div;
                    grd.DataBind();
                }
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1230, 4, int.Parse(Session["LoginBranchid"].ToString()), "Delete");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 

        }

        protected void btn_no1_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MailingList da_obj_ListObj = new DataAccess.Masters.MailingList();
                DataTable Dt_uiid = new DataTable();
                int int_index;
                int_index = grd.SelectedRow.RowIndex;

                hf_uiid.Value = int.Parse(grd.DataKeys[int_index].Values[0].ToString()).ToString();
                hf_empid.Value = int.Parse(grd.DataKeys[int_index].Values[1].ToString()).ToString();
                hf_oldid.Value = hf_empid.Value;

                hf_branchid.Value = int.Parse(grd.DataKeys[int_index].Values[2].ToString()).ToString();

                Dt_uiid = da_obj_ListObj.GetMailList4uiid(Convert.ToInt32(hf_empid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(hf_branchid.Value));


                if (Dt_uiid.Rows.Count > 0)
                {
                    ddl_cmbDivision.SelectedValue = Dt_uiid.Rows[0][0].ToString();
                    //ddl_cmbDivision_SelectedIndexChanged(sender, e);
                    ddl_cmbbranch.SelectedValue = Dt_uiid.Rows[0][1].ToString();
                    //ddl_cmbbranch_SelectedIndexChanged(sender, e);
                    //string cmbtran = Dt_uiid.Rows[0][2].ToString();
                    ddl_cmbTrantype.SelectedValue = Dt_uiid.Rows[0][2].ToString();
                    ddl_cmbmenu.Items.Clear();
                    cmbmenu = Dt_uiid.Rows[0][3].ToString();
                    ddl_cmbmenu.Items.Add(cmbmenu);
                    ddl_cmbscreen.Items.Clear();
                    cmbscreen = Dt_uiid.Rows[0][4].ToString();
                    ddl_cmbscreen.Items.Add(cmbscreen);
                    txt_emp.Text = Dt_uiid.Rows[0][5].ToString();
                }
                ddl_cmbDivision.Enabled = false;
                ddl_cmbbranch.Enabled = false;
                ddl_cmbTrantype.Enabled = false;
                ddl_cmbmenu.Enabled = false;
                ddl_cmbscreen.Enabled = false;
                //btn_save.Text = "Update";
              //  btn_back.Text = "Cancel";

                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
          
           if(btn_back.ToolTip=="Cancel")
           {
            DataAccess.Masters.MailingList da_obj_ListObj = new DataAccess.Masters.MailingList();
            DataTable Dt_Fill = new DataTable();
            ddl_cmbDivision.SelectedIndex = -1;
            ddl_cmbbranch.SelectedIndex = -1;
            ddl_cmbTrantype.SelectedIndex = -1;
            ddl_cmbmenu.SelectedIndex = -1;
            ddl_cmbscreen.SelectedIndex = -1;
            txt_emp.Text = "";
            ddl_cmbscreen.Items.Clear();
            ddl_cmbmenu.Items.Clear();

         //   btn_save.Text = "Save";

            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";

            Dt_Fill = da_obj_ListObj.GetALLMailingList(0);
            if (Dt_Fill.Rows.Count > 0)
            {
                grd.DataSource = Dt_Fill;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = new DataTable();
                grd.DataBind();
            }
            ddl_cmbDivision.Enabled = true;
            ddl_cmbbranch.Enabled = true;
            ddl_cmbTrantype.Enabled = true;
            ddl_cmbmenu.Enabled = true;
            ddl_cmbscreen.Enabled = true;
          //  btn_back.Text = "Back";

            btn_back.ToolTip = "Back";
            btn_back1.Attributes["class"] = "btn ico-back";
           }
           else
           {
               this.Response.End();
           }
        }

        protected void txt_emp_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text == "&nbsp;")
                {
                    e.Row.Cells[i].Text = "";
                }
                e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
            }

             if (e.Row.Cells[1].Text != "")
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

    }
}