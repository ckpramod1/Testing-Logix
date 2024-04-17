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
    public partial class UserPermissions : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        int int_btnaccess;
        int int_btnsave;
        int int_btndelete;
        int int_btnupdate;
        int int_btnview;
        string str_employeecode, str_modulename;
        CheckBox chk1;
        CheckBox chk2;
        CheckBox chk3;
        CheckBox chk4;
        CheckBox chk5;
        string str_Uiid;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
         
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            } 
            if (IsPostBack != true)
            {
                try
                {
                    DivisionBind();
                    BranchBind();
                    LoadModule();
                    Empty_grid();
                    if (Request.QueryString.ToString().Contains("type"))
                    {
                        lblheader.Text = Request.QueryString["type"].ToString();
                    }
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        lblHead.InnerText = "Utility";
                        lblHead1.InnerText = "Utility";
                    }
                    else if (Session["StrTranType"].ToString() == "AC")
                    {
                        lblHead.InnerText = "Operating Accounts";
                        lblHead1.InnerText = "Utility";
                    }
                    else if (Session["StrTranType"].ToString() == "CH")
                    {
                        lblHead.InnerText = "Custom House Agent";
                        lblHead1.InnerText = "Utility";
                    }
                    else if (Session["StrTranType"].ToString() == "BT")
                    {
                        lblHead.InnerText = "BondedTrucking";
                        lblHead1.InnerText = "Utility";
                    }
                    else if (Session["StrTranType"].ToString() == "M")
                    {
                        lblHead.InnerText = "Maintenance";
                        lblHead1.InnerText = "Systems";

                    }


                   lblHead2.InnerText= lblheader.Text;

                    str_Uiid = Request.QueryString["type"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, null);
                  //  btn_back.Text = "Cancel";


                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
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
            DataAccess.HR.FrontPage da_obj_HRFrontObj = new DataAccess.HR.FrontPage();
            obj_dt = da_obj_HRFrontObj.GetLikeEmpName(prefix.ToUpper());
            gname = Utility.Fn_DatatableToList_int16(obj_dt, "empnamecode", "employeeid");
            return gname;
        }

        public void LoadModule()
        {
            ddl_cmbModule.Items.Clear();
            ddl_cmbModule.Items.Add("");
            ddl_cmbModule.Items.Add("Accounts");
            ddl_cmbModule.Items.Add("Air Exports");
            ddl_cmbModule.Items.Add("Air Imports");
            ddl_cmbModule.Items.Add("Bonded Trucking");
            ddl_cmbModule.Items.Add("CRM");
            ddl_cmbModule.Items.Add("Custom House Agent");
            ddl_cmbModule.Items.Add("Forwarding Exports");
            ddl_cmbModule.Items.Add("Forwarding Imports");
            ddl_cmbModule.Items.Add("Human Resource Management");
            ddl_cmbModule.Items.Add("Maintenance");
            ddl_cmbModule.Items.Add("Management");
            ddl_cmbModule.Items.Add("WMS");
            ddl_cmbModule.Items.Add("Sales");
            ddl_cmbModule.Items.Add("Financial Accounts");
            ddl_cmbModule.Items.Add("Financial Accounts - CO");
        }
        private void Empty_grid()
        {
            DataTable dt_new = new DataTable();
            grd_user.DataSource = dt_new;
            grd_user.DataBind();
        }
        private void BranchBind()
        {
            DataAccess.Masters.MasterPort da_obj_PortObj = new DataAccess.Masters.MasterPort();
            DataTable Dt = new DataTable();
            ddl_cmbLocation.Items.Clear();
            ddl_cmbLocation.Items.Add("");
            Dt = da_obj_PortObj.GetAllBranchNameforPortName();
            for (int i = 0; i <= Dt.Rows.Count - 1; i++)
            {
                ddl_cmbLocation.Items.Add(Dt.Rows[i]["portname"].ToString());
            }
        }

        private void DivisionBind()
        {
            DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
            DataTable Dt = new DataTable();
            ddl_cmbDivision.Items.Clear();
            ddl_cmbDivision.Items.Add("");

            Dt = da_obj_hrempobj.GetDivision();
            for (int i = 0; i <= Dt.Rows.Count - 1; i++)
            {
                ddl_cmbDivision.Items.Add(Dt.Rows[i]["divisionname"].ToString());
            }
        }

        protected void ddl_cmbModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_cmbDivision.SelectedValue != "" && ddl_cmbLocation.SelectedValue != "" && txt_user.Text != "")
            {
                LoadCheckList();

                ddl_chk.Items.Clear();
                LoadCombo();
            }
            else
            {
                //ddl_cmbModule.Items.Clear();
                //ddl_chk.Items.Clear();
                ddl_cmbModule.SelectedValue = "";
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert(' Please Select Above Required Values. ');", true);
            }
        }
        private void LoadCombo()
        {
            DataAccess.UserPermission da_obj_userobj = new DataAccess.UserPermission();
            DataTable dt = new DataTable();
            ddl_chk.Items.Add("");
            dt = da_obj_userobj.GetMenuName(Convert.ToString(getmodule()));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    ddl_chk.Items.Add(dt.Rows[i][0].ToString());
                }
            }
        }

        public object getmodule()
        {
            if (ddl_cmbModule.SelectedValue == "Forwarding Exports")
            {
                hf_modulename.Value = "FE";
            }
            else if (ddl_cmbModule.SelectedValue == "Coastal Cargo")
            {
                hf_modulename.Value = "CC";
            }
            else if (ddl_cmbModule.SelectedValue == "Forwarding Imports")
            {
                hf_modulename.Value = "FI";
            }
            else if (ddl_cmbModule.SelectedValue == "Air Exports")
            {
                hf_modulename.Value = "AE";
            }
            else if (ddl_cmbModule.SelectedValue == "Air Imports")
            {
                hf_modulename.Value = "AI";
            }
            else if (ddl_cmbModule.SelectedValue == "Custom House Agent")
            {
                hf_modulename.Value = "CH";
            }
            else if (ddl_cmbModule.SelectedValue == "CRM")
            {
                hf_modulename.Value = "CR";
            }
            else if (ddl_cmbModule.SelectedValue == "Human Resource Management")
            {
                hf_modulename.Value = "HR";
            }
            else if (ddl_cmbModule.SelectedValue == "Maintenance")
            {
                hf_modulename.Value = "MN";
            }
            else if (ddl_cmbModule.SelectedValue == "Accounts")
            {
                hf_modulename.Value = "AC";
            }
            else if (ddl_cmbModule.SelectedValue == "ExRate Amend")
            {
                hf_modulename.Value = "EX";
            }
            else if (ddl_cmbModule.SelectedValue == "Bonded Trucking")
            {
                hf_modulename.Value = "BT";
            }
            else if (ddl_cmbModule.SelectedValue == "Management")
            {
                hf_modulename.Value = "MI";
            }
            else if (ddl_cmbModule.SelectedValue == "WMS")
            {
                hf_modulename.Value = "WM";
            }
            else if (ddl_cmbModule.SelectedValue == "CO - Accounts")
            {
                hf_modulename.Value = "CA";
            }
            else if (ddl_cmbModule.SelectedValue == "East")
            {
                hf_modulename.Value = "EA";
            }
            else if (ddl_cmbModule.SelectedValue == "West")
            {
                hf_modulename.Value = "WE";
            }
            else if (ddl_cmbModule.SelectedValue == "North")
            {
                hf_modulename.Value = "NO";
            }
            else if (ddl_cmbModule.SelectedValue == "South")
            {
                hf_modulename.Value = "SO";
            }
            else if (ddl_cmbModule.SelectedValue == "Sales")
            {
                hf_modulename.Value = "SA";
            }
            else if (ddl_cmbModule.SelectedValue == "Financial Accounts")
            {
                hf_modulename.Value = "FA";
            }
            else if (ddl_cmbModule.SelectedValue == "Financial Accounts - CO")
            {
                hf_modulename.Value = "FC";
            }
            return hf_modulename.Value;
        }
        private void LoadCheckList()
        {
            DataAccess.UserPermission da_obj_userobj = new DataAccess.UserPermission();

            if (hf_empcode.Value != "")
            {
                if (ddl_cmbDivision.SelectedValue != "All" && ddl_cmbLocation.SelectedValue != "All" && txt_user.Text != "All" && ddl_cmbModule.SelectedValue != "All" & ddl_chk.SelectedValue != "All" && grd_user.Rows.Count > 0)
                {
                    DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
                    str_employeecode = hf_empcode.Value;
                    hf_employeeid.Value = da_obj_hrempobj.GetEmpId(Convert.ToString(hf_empcode.Value)).ToString();

                    hf_branchid.Value = da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                    hf_divisionid.Value = da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue)).ToString();

                    CheckBox chk1;
                    CheckBox chk2;
                    CheckBox chk3;
                    CheckBox chk4;
                    CheckBox chk5;
                    for (int r = 0; r < grd_user.Rows.Count; r++)
                    {
                        chk1 = (CheckBox)(grd_user.Rows[r].FindControl("chk_access"));
                        if (chk1.Checked == true)
                        {
                            int_btnaccess = 1;
                        }
                        else
                        {
                            int_btnaccess = 0;
                        }

                        chk2 = (CheckBox)(grd_user.Rows[r].FindControl("chk_save"));
                        if (chk2.Checked == true)
                        {
                            int_btnsave = 1;
                        }
                        else
                        {
                            int_btnsave = 0;
                        }

                        chk3 = (CheckBox)(grd_user.Rows[r].FindControl("chk_delete"));
                        if (chk3.Checked == true)
                        {
                            int_btndelete = 1;
                        }
                        else
                        {
                            int_btndelete = 0;
                        }

                        chk4 = (CheckBox)(grd_user.Rows[r].FindControl("chk_upd"));
                        if (chk4.Checked == true)
                        {
                            int_btnupdate = 1;
                        }
                        else
                        {
                            int_btnupdate = 0;
                        }

                        chk5 = (CheckBox)(grd_user.Rows[r].FindControl("chk_view"));
                        if (chk5.Checked == true)
                        {
                            int_btnview = 1;
                        }
                        else
                        {
                            int_btnview = 0;
                        }
                        hf_uiid.Value = da_obj_userobj.GetUiid(Convert.ToString(hf_trantype.Value), Convert.ToString(hf_menuname.Value), Convert.ToString(grd_user.Rows[r].Cells[0].Text)).ToString();


                        da_obj_userobj.DeleteUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(hf_branchid.Value));

                        da_obj_userobj.InsertUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToInt32(hf_uiid.Value), Convert.ToInt32(hf_branchid.Value), Convert.ToString(hf_modulename.Value), Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnaccess), Convert.ToInt32(int_btnsave), Convert.ToInt32(int_btnview), Convert.ToInt32(int_btndelete), Convert.ToInt32(int_btnupdate));


                        /*If modulename = "MN" Then
                        logObj.InsLogDetail(Login.logempid, 315, 1, Login.branchid, "MN/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    ElseIf modulename = "AC" Then
                        logObj.InsLogDetail(Login.logempid, 769, 1, Login.branchid, "AC/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    ElseIf modulename = "FE" Then
                        logObj.InsLogDetail(Login.logempid, 770, 1, Login.branchid, "FE/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    ElseIf modulename = "FI" Then
                        logObj.InsLogDetail(Login.logempid, 771, 1, Login.branchid, "FI/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    ElseIf modulename = "AE" Then
                        logObj.InsLogDetail(Login.logempid, 772, 1, Login.branchid, "AE/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    ElseIf modulename = "AI" Then
                        logObj.InsLogDetail(Login.logempid, 773, 1, Login.branchid, "AI/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    ElseIf modulename = "CH" Then
                        logObj.InsLogDetail(Login.logempid, 774, 1, Login.branchid, "CH/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    ElseIf modulename = "BT" Then
                        logObj.InsLogDetail(Login.logempid, 775, 1, Login.branchid, "BT/E" & empid & "/U" & uiid & "/B" & branchid & "/A" & btnaccess & "," & btnsave & "," & btnview & "," & btndelete & "," & btnupdate)
                    End If*/




                    }
                }
            }
        }

        protected void txt_user_TextChanged(object sender, EventArgs e)
        {

            DataTable dt_get = new DataTable();
            DataAccess.HR.FrontPage da_obj_HRFrontObj = new DataAccess.HR.FrontPage();
            dt_get = da_obj_HRFrontObj.GetLikeEmpName(txt_user.Text);
            if (dt_get.Rows.Count > 0)
            {
                for (int i = 0; i <= dt_get.Rows.Count - 1; i++)
                {
                    hf_empcode.Value = dt_get.Rows[0][1].ToString();
                }
            }
        }

        protected void ddl_chk_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
            DataAccess.UserPermission da_obj_userobj = new DataAccess.UserPermission();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
            hf_branchid.Value = da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
            if (da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue)) == 1)
            {
                if (ddl_cmbLocation.SelectedValue == "CO - Accounts")
                {
                    hf_branchid.Value = "100";
                }
                else if (ddl_cmbLocation.SelectedValue == "South")
                {
                    hf_branchid.Value = "101";
                }
                else if (ddl_cmbLocation.SelectedValue == "North")
                {
                    hf_branchid.Value = "1102";
                }
                else if (ddl_cmbLocation.SelectedValue == "West")
                {
                    hf_branchid.Value = "103";
                }
                else if (ddl_cmbLocation.SelectedValue == "East")
                {
                    hf_branchid.Value = "104";
                }
                else
                {
                    hf_branchid.Value = da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                }
            }
            else if (da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue)) == 2)
            {
                if (ddl_cmbLocation.SelectedValue == "CO - Accounts")
                {
                    hf_branchid.Value = "105";
                }
                else if (ddl_cmbLocation.SelectedValue == "South")
                {
                    hf_branchid.Value = "106";
                }
                else if (ddl_cmbLocation.SelectedValue == "North")
                {
                    hf_branchid.Value = "107";
                }
                else if (ddl_cmbLocation.SelectedValue == "West")
                {
                    hf_branchid.Value = "108";
                }
                else if (ddl_cmbLocation.SelectedValue == "East")
                {
                    hf_branchid.Value = "109";
                }
                else
                {
                    hf_branchid.Value = da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                }
            }
            else if (da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue)) == 4)
            {
                if (ddl_cmbLocation.SelectedValue == "CO - Accounts")
                {
                    hf_branchid.Value = "110";
                }
                else if (ddl_cmbLocation.SelectedValue == "South")
                {
                    hf_branchid.Value = "111";
                }
                else if (ddl_cmbLocation.SelectedValue == "North")
                {
                    hf_branchid.Value = "112";
                }
                else if (ddl_cmbLocation.SelectedValue == "West")
                {
                    hf_branchid.Value = "113";
                }
                else if (ddl_cmbLocation.SelectedValue == "East")
                {
                    hf_branchid.Value = "114";
                }
                else
                {
                    hf_branchid.Value = da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                }
            }
            if (!string.IsNullOrEmpty(Convert.ToString(ddl_cmbDivision.SelectedValue)) && !string.IsNullOrEmpty(ddl_cmbLocation.SelectedValue) && !string.IsNullOrEmpty(txt_user.Text) && !string.IsNullOrEmpty(Convert.ToString(ddl_cmbModule.SelectedValue)))
            {
                if (grd_user.Rows.Count > 0)
                {
                    LoadCheckList();
                }
                hf_trantype.Value = hf_modulename.Value;
                hf_menuname.Value = ddl_chk.SelectedValue;

                if (!string.IsNullOrEmpty(hf_empcode.Value))
                {
                    hf_employeeid.Value = da_obj_hrempobj.GetEmpId(Convert.ToString(hf_empcode.Value)).ToString();
                }
                else
                {
                    hf_employeeid.Value = "0";
                }
                if (grd_user.Rows.Count > 0)
                {
                    grd_user.DataSource = new DataTable();
                    grd_user.DataBind();
                }

                dt = da_obj_userobj.GetFrmName(Convert.ToString(getmodule()), Convert.ToString(ddl_chk.SelectedValue));

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        //string test;
                        //test = dt.Rows[i][0].ToString();
                        //dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[i][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));
                        DataTable obj_dtEmp = new DataTable();

                        obj_dtEmp.Columns.Add("uicaption");
                        obj_dtEmp.Columns.Add("uiaccess");
                        obj_dtEmp.Columns.Add("btnsave");
                        obj_dtEmp.Columns.Add("btnview");
                        obj_dtEmp.Columns.Add("btndelete");
                        obj_dtEmp.Columns.Add("btnupdate");

                        DataRow dr;

                        for (i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dr = obj_dtEmp.NewRow();
                            obj_dtEmp.Rows.Add(dr);
                            dr["uicaption"] = dt.Rows[i][0].ToString();
                            dr["uiaccess"] = "";
                            dr["btnsave"] = "";
                            dr["btnview"] = "";
                            dr["btndelete"] = "";
                            dr["btnupdate"] = "";
                        }
                        grd_user.DataSource = obj_dtEmp;
                        grd_user.DataBind();
                    }
                    dt = da_obj_userobj.GetFrmName(Convert.ToString(getmodule()), Convert.ToString(ddl_chk.SelectedValue));
                    if (dt.Rows.Count > 0)
                    {
                        for (int r = 0; r < dt.Rows.Count; r++)
                        {
                            string test;
                            test = dt.Rows[r][1].ToString();
                            dt1 = da_obj_userobj.GetUserRights(Convert.ToInt32(hf_employeeid.Value), Convert.ToString(hf_modulename.Value), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(dt.Rows[r][0].ToString()), test, Convert.ToInt32(hf_branchid.Value));

                            if (dt1.Rows.Count > 0)
                            {
                                if (dt1.Rows[0][1].ToString() == "True")
                                {
                                    chk1 = (CheckBox)(grd_user.Rows[r].FindControl("chk_access"));
                                    chk1.Checked = true;
                                }
                                else
                                {
                                    chk1 = (CheckBox)(grd_user.Rows[r].FindControl("chk_access"));
                                    chk1.Checked = false;
                                }

                                if (dt1.Rows[0][2].ToString() == "True")
                                {
                                    chk2 = (CheckBox)(grd_user.Rows[r].FindControl("chk_save"));
                                    chk2.Checked = true;
                                }
                                else
                                {
                                    chk2 = (CheckBox)(grd_user.Rows[r].FindControl("chk_save"));
                                    chk2.Checked = false;
                                }

                                if (dt1.Rows[0][3].ToString() == "True")
                                {
                                    chk3 = (CheckBox)(grd_user.Rows[r].FindControl("chk_view"));
                                    chk3.Checked = true;
                                }
                                else
                                {
                                    chk3 = (CheckBox)(grd_user.Rows[r].FindControl("chk_view"));
                                    chk3.Checked = false;
                                }

                                if (dt1.Rows[0][4].ToString() == "True")
                                {
                                    chk4 = (CheckBox)(grd_user.Rows[r].FindControl("chk_delete"));
                                    chk4.Checked = true;
                                }
                                else
                                {
                                    chk4 = (CheckBox)(grd_user.Rows[r].FindControl("chk_delete"));
                                    chk4.Checked = false;
                                }

                                if (dt1.Rows[0][5].ToString() == "True")
                                {
                                    chk5 = (CheckBox)(grd_user.Rows[r].FindControl("chk_upd"));
                                    chk5.Checked = true;
                                }
                                else
                                {
                                    chk5 = (CheckBox)(grd_user.Rows[r].FindControl("chk_upd"));
                                    chk5.Checked = false;
                                }
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

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.UserPermission da_obj_userobj = new DataAccess.UserPermission();
                DataAccess.Masters.MasterPort da_obj_PortObj = new DataAccess.Masters.MasterPort();
                DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
                LoadCheckList();

                if (!string.IsNullOrEmpty(Convert.ToString(hf_empcode.Value)))
                {
                    if (ddl_cmbDivision.SelectedValue != "All" && ddl_cmbLocation.SelectedValue != "All" && txt_user.Text != "All" && ddl_cmbModule.Text != "All" && ddl_chk.SelectedValue != "All" && grd_user.Rows.Count > 0)
                    {
                    }
                    else
                    {
                        hf_employeeid.Value = da_obj_hrempobj.GetEmpId(Convert.ToString(hf_empcode.Value)).ToString();

                        if (ddl_cmbDivision.SelectedValue == "All")
                        {
                            hf_branchid.Value = da_obj_PortObj.GetNPortid(Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                        }
                        else
                        {
                            hf_branchid.Value = da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                        }
                        hf_divisionid.Value = da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue)).ToString();

                        if (grd_user.Rows.Count > 0)
                        {
                            //foreach (GridViewRow row in grd_user.Rows)
                            for (int r = 0; r < grd_user.Rows.Count; r++)
                            {
                                if (grd_user.Rows[r].Cells[0].Text == "True")
                                {
                                    da_obj_userobj.InsAllUserRights(Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_divisionid.Value), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(ddl_cmbModule.SelectedValue), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(grd_user.Rows[r].Cells[0].Text));

                                    if (ddl_cmbModule.Text == "MN")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 315, 1, int.Parse(Session["LoginBranchid"].ToString()), "MN/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[r].Cells[0].Text);
                                    }
                                    else if (ddl_cmbModule.Text == "AC")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 769, 1, int.Parse(Session["LoginBranchid"].ToString()), "AC/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[r].Cells[0].Text);
                                    }
                                    else if (ddl_cmbModule.Text == "FE")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 770, 1, int.Parse(Session["LoginBranchid"].ToString()), "FE/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[r].Cells[0].Text);
                                    }
                                    else if (ddl_cmbModule.Text == "FI")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 771, 1, int.Parse(Session["LoginBranchid"].ToString()), "FI/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[r].Cells[0].Text);
                                    }
                                    else if (ddl_cmbModule.Text == "AE")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 772, 1, int.Parse(Session["LoginBranchid"].ToString()), "AE/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[r].Cells[0].Text);
                                    }
                                    else if (ddl_cmbModule.Text == "AI")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 773, 1, int.Parse(Session["LoginBranchid"].ToString()), "AI/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[r].Cells[0].Text);
                                    }
                                    else if (ddl_cmbModule.Text == "CH")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 774, 1, int.Parse(Session["LoginBranchid"].ToString()), "CH/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[r].Cells[0].Text);
                                    }
                                    else if (ddl_cmbModule.Text == "BT")
                                    {
                                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 775, 1, int.Parse(Session["LoginBranchid"].ToString()), "BT/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[r].Cells[0].Text);
                                    }

                                }
                            }
                            
                        }
                        else
                        {
                            da_obj_userobj.InsAllUserRights(Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_divisionid.Value), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(ddl_cmbModule.SelectedValue), Convert.ToString(ddl_chk.SelectedValue), "All");

                            if (ddl_cmbModule.Text == "MN")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 315, 1, int.Parse(Session["LoginBranchid"].ToString()), "MN/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            }
                            else if (ddl_cmbModule.Text == "AC")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 769, 1, int.Parse(Session["LoginBranchid"].ToString()), "AC/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            }
                            else if (ddl_cmbModule.Text == "FE")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 770, 1, int.Parse(Session["LoginBranchid"].ToString()), "FE/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            }
                            else if (ddl_cmbModule.Text == "FI")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 771, 1, int.Parse(Session["LoginBranchid"].ToString()), "FI/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            }
                            else if (ddl_cmbModule.Text == "AE")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 772, 1, int.Parse(Session["LoginBranchid"].ToString()), "AE/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            }
                            else if (ddl_cmbModule.Text == "AI")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 773, 1, int.Parse(Session["LoginBranchid"].ToString()), "AI/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            }
                            else if (ddl_cmbModule.Text == "CH")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 774, 1, int.Parse(Session["LoginBranchid"].ToString()), "CH/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            }
                            else if (ddl_cmbModule.Text == "BT")
                            {
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 775, 1, int.Parse(Session["LoginBranchid"].ToString()), "BT/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                            }

                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(hf_empcode.Value))
                    {
                        hf_employeeid.Value = da_obj_hrempobj.GetEmpId(Convert.ToString(hf_empcode.Value)).ToString();
                    }
                    else
                    {
                        hf_employeeid.Value = "0";
                    }
                    if (ddl_cmbDivision.SelectedValue == "All")
                    {
                        hf_branchid.Value = da_obj_PortObj.GetNPortid(Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                    }
                    else
                    {
                        hf_branchid.Value = da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                    }

                    hf_divisionid.Value = da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue)).ToString();

                    if (grd_user.Rows.Count > 0)
                    {
                        //foreach (GridViewRow row in grd_user.Rows)
                        for (int r = 0; r <= grd_user.Rows.Count - 1; r++)
                        {
                            if (grd_user.Rows[r].Cells[0].Text == "True")
                            {
                                da_obj_userobj.InsAllUserRights(Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_divisionid.Value), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(ddl_cmbModule.SelectedValue), Convert.ToString(ddl_chk.SelectedValue), Convert.ToString(grd_user.Rows[0].Cells[0].Text));
                                if (ddl_cmbModule.Text == "MN")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 315, 1, int.Parse(Session["LoginBranchid"].ToString()), "MN/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[0].Cells[0].Text);
                                }
                                else if (ddl_cmbModule.Text == "AC")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 769, 1, int.Parse(Session["LoginBranchid"].ToString()), "AC/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[0].Cells[0].Text);
                                }
                                else if (ddl_cmbModule.Text == "FE")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 770, 1, int.Parse(Session["LoginBranchid"].ToString()), "FE/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[0].Cells[0].Text);
                                }
                                else if (ddl_cmbModule.Text == "FI")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 771, 1, int.Parse(Session["LoginBranchid"].ToString()), "FI/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[0].Cells[0].Text);
                                }
                                else if (ddl_cmbModule.Text == "AE")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 772, 1, int.Parse(Session["LoginBranchid"].ToString()), "AE/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[0].Cells[0].Text);
                                }
                                else if (ddl_cmbModule.Text == "AI")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 773, 1, int.Parse(Session["LoginBranchid"].ToString()), "AI/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[0].Cells[0].Text);
                                }
                                else if (ddl_cmbModule.Text == "CH")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 774, 1, int.Parse(Session["LoginBranchid"].ToString()), "CH/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[0].Cells[0].Text);
                                }
                                else if (ddl_cmbModule.Text == "BT")
                                {
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 775, 1, int.Parse(Session["LoginBranchid"].ToString()), "BT/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/" + grd_user.Rows[0].Cells[0].Text);
                                }

                            }
                        }
                    }
                    else
                    {
                        da_obj_userobj.InsAllUserRights(Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_divisionid.Value), Convert.ToInt32(hf_employeeid.Value), Convert.ToString(ddl_cmbModule.SelectedValue), Convert.ToString(ddl_chk.SelectedValue), "All");
                        if (ddl_cmbModule.Text == "MN")
                        {
                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 315, 1, int.Parse(Session["LoginBranchid"].ToString()), "MN/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        }
                        else if (ddl_cmbModule.Text == "AC")
                        {
                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 769, 1, int.Parse(Session["LoginBranchid"].ToString()), "AC/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        }
                        else if (ddl_cmbModule.Text == "FE")
                        {
                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 770, 1, int.Parse(Session["LoginBranchid"].ToString()), "FE/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        }
                        else if (ddl_cmbModule.Text == "FI")
                        {
                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 771, 1, int.Parse(Session["LoginBranchid"].ToString()), "FI/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        }
                        else if (ddl_cmbModule.Text == "AE")
                        {
                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 772, 1, int.Parse(Session["LoginBranchid"].ToString()), "AE/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        }
                        else if (ddl_cmbModule.Text == "AI")
                        {
                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 773, 1, int.Parse(Session["LoginBranchid"].ToString()), "AI/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        }
                        else if (ddl_cmbModule.Text == "CH")
                        {
                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 774, 1, int.Parse(Session["LoginBranchid"].ToString()), "CH/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        }
                        else if (ddl_cmbModule.Text == "BT")
                        {
                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 775, 1, int.Parse(Session["LoginBranchid"].ToString()), "BT/Bid-" + hf_branchid.Value + ddl_cmbModule.Text + "/EmpId" + hf_employeeid.Value + "/" + "Menu:" + "/" + ddl_chk.Text + "/All");
                        }
                    }
                }
                ddl_cmbDivision.SelectedValue = "";
                ddl_cmbLocation.SelectedValue = "";
                txt_user.Text = "";
                ddl_cmbModule.SelectedValue = "";
                ddl_chk.SelectedValue = "";
                ddl_chk.SelectedIndex = -1;
                grd_user.DataSource = new DataTable();
                grd_user.DataBind();
                DivisionBind();
                BranchBind();
                LoadModule();
              //  btn_back.Text = "Cancel";

                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
            string str_RptName = "";
            string str_Script = "";
            string str_sf = "";
            string str_sp = "";

            if (!string.IsNullOrEmpty(ddl_cmbDivision.SelectedValue) && !string.IsNullOrEmpty(ddl_cmbLocation.SelectedValue) && !string.IsNullOrEmpty(txt_user.Text))
            {
                //str_frmname = "User Rights";
                str_RptName = "userrights.rpt";
                str_sf = "{MasterEmployee.employeeid}=" + Convert.ToInt32(hf_employeeid.Value) + " and {UserRights.branch}=" + da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue));
                str_sp = "";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
            else if (!string.IsNullOrEmpty(ddl_cmbDivision.SelectedValue) && !string.IsNullOrEmpty(ddl_cmbLocation.SelectedValue))
            {
                str_RptName = "userrights.rpt";
                str_sf = "{UserRights.branch}=" + da_obj_hrempobj.GetBranchId(Convert.ToInt32(da_obj_hrempobj.GetDivisionId(Convert.ToString(ddl_cmbDivision.SelectedValue))), Convert.ToString(ddl_cmbLocation.SelectedValue)).ToString();
                str_sp = "";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
        }

        protected void ddl_cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
           if(btn_back.ToolTip=="Cancel")
           {
            LoadCheckList();
            ddl_cmbDivision.SelectedValue = "";
            ddl_cmbLocation.SelectedValue = "";
            txt_user.Text = "";
            ddl_cmbModule.SelectedValue = "";
            txt_user.Text = "";
            ddl_chk.SelectedValue = "";
            ddl_chk.SelectedIndex = -1;
            grd_user.DataSource = new DataTable();
            grd_user.DataBind();
            DivisionBind();
            BranchBind();
            LoadModule();
           // btn_back.Text = "Back";
            btn_back.ToolTip = "Back";
            btn_back1.Attributes["class"] = "btn ico-back";

            }
             else 
            {
              //  this.Response.End();



                if (Session["StrTranType"] != null)
                {

                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        if (Session["home"] != null)
                        {
                            if (Session["home"].ToString() == "AC&FINhome")
                            {
                                Response.Redirect("../Home/CorpAccNFinance.aspx");
                            }
                            else if (Session["home"].ToString() == "CredConthome")
                            {
                                Response.Redirect("../Home/CorpCreditControl.aspx");
                            }
                            else if (Session["home"].ToString() == "Budgethome")
                            {
                                Response.Redirect("../Home/CorpBudgetHome.aspx");
                            }
                            else if (Session["home"].ToString() == "MISandAnalysisCor")
                            {
                                Response.Redirect("../Home/CORHomeMIS.aspx");
                            }
                            else if (Session["home"].ToString() == "MIS")
                            {
                                Response.Redirect("../Home/MISAndApproval.aspx");
                            }
                        }
                        else if (Session["StrTranType1"].ToString() == "MISandAnalysisCor")
                        {
                            Response.Redirect("../Home/CORHomeMIS.aspx");
                        }
                        else if (Session["StrTranType1"].ToString() == "Utilitycor")
                        {
                            Response.Redirect("../Home/CORHome.aspx");
                        }
                        else
                        {
                            this.Response.End();
                        }

                    }
                    else if (Session["StrTranType"].ToString() == "AC")
                    {
                        Response.Redirect("../Home/OAHome.aspx");
                    }
                    else if (Session["StrTranType"].ToString() == "CH")
                    {
                        Response.Redirect("../Home/CHAHome.aspx");
                    }
                    else
                    {
                        this.Response.End();
                    }
                }


                else
                {
                    this.Response.End();
                }
            }
        }

        protected void chk_accessAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkBoxHeader = (CheckBox)grd_user.HeaderRow.FindControl("chk_accessAll");
            foreach (GridViewRow row in grd_user.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("chk_access");
                if (ChkBoxHeader.Checked == true)
                {
                    ChkBoxRows.Checked = true;
                }
                else
                {
                    ChkBoxRows.Checked = false;
                }
            }
        }

        protected void chk_saveAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk_saveHeader = (CheckBox)grd_user.HeaderRow.FindControl("chk_saveAll");
            foreach (GridViewRow row in grd_user.Rows)
            {
                CheckBox chk_save = (CheckBox)row.FindControl("chk_save");
                if (chk_saveHeader.Checked == true)
                {
                    chk_save.Checked = true;
                }
                else
                {
                    chk_save.Checked = false;
                }
            }
        }

        protected void chk_viewAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk_viewAll = (CheckBox)grd_user.HeaderRow.FindControl("chk_viewAll");
            foreach (GridViewRow row in grd_user.Rows)
            {
                CheckBox chk_view = (CheckBox)row.FindControl("chk_view");
                if (chk_viewAll.Checked == true)
                {
                    chk_view.Checked = true;
                }
                else
                {
                    chk_view.Checked = false;
                }
            }
        }

        protected void chk_deleteAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk_deleteAll = (CheckBox)grd_user.HeaderRow.FindControl("chk_deleteAll");
            foreach (GridViewRow row in grd_user.Rows)
            {
                CheckBox chk_delete = (CheckBox)row.FindControl("chk_delete");
                if (chk_deleteAll.Checked == true)
                {
                    chk_delete.Checked = true;
                }
                else
                {
                    chk_delete.Checked = false;
                }
            }
        }

        protected void chk_updAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk_updAll = (CheckBox)grd_user.HeaderRow.FindControl("chk_updAll");
            foreach (GridViewRow row in grd_user.Rows)
            {
                CheckBox chk_upd = (CheckBox)row.FindControl("chk_upd");
                if (chk_updAll.Checked == true)
                {
                    chk_upd.Checked = true;
                }
                else
                {
                    chk_upd.Checked = false;
                }
            }
        }

        protected void grd_user_RowDataBound(object sender, GridViewRowEventArgs e)
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

            }
        }

        protected void grd_user_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            {
                CheckBox chk_access = (CheckBox)e.Row.Cells[1].FindControl("chk_access");
                CheckBox chk_accessAll = (CheckBox)this.grd_user.HeaderRow.FindControl("chk_accessAll");
                chk_access.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_accessAll.ClientID);
                CheckBox chk_save = (CheckBox)e.Row.Cells[1].FindControl("chk_save");
                CheckBox chk_saveAll = (CheckBox)this.grd_user.HeaderRow.FindControl("chk_saveAll");
                chk_save.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_saveAll.ClientID);
                CheckBox chk_view = (CheckBox)e.Row.Cells[1].FindControl("chk_view");
                CheckBox chk_viewAll = (CheckBox)this.grd_user.HeaderRow.FindControl("chk_viewAll");
                chk_view.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_viewAll.ClientID);
                CheckBox chk_delete = (CheckBox)e.Row.Cells[1].FindControl("chk_delete");
                CheckBox chk_deleteAll = (CheckBox)this.grd_user.HeaderRow.FindControl("chk_deleteAll");
                chk_delete.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_deleteAll.ClientID);
                CheckBox chk_upd = (CheckBox)e.Row.Cells[1].FindControl("chk_upd");
                CheckBox chk_updAll = (CheckBox)this.grd_user.HeaderRow.FindControl("chk_updAll");
                chk_upd.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chk_updAll.ClientID);
            }
        }
    }
}