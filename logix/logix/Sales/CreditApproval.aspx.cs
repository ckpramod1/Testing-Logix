using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Drawing;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Reflection;
using DataAccess.Accounts;

namespace logix.Sales
{
    public partial class CreditApproval : System.Web.UI.Page
    {
        string Bmmail, salesmail, sendqry, days = "0";
        string type = "0";
        DataTable dtsalesuser = new DataTable();
        DataTable dtsalesmail = new DataTable();
        DataAccess.Masters.MasterBranch obj_main = new DataAccess.Masters.MasterBranch();
        DataAccess.Masters.MasterEmployee obj_emp = new DataAccess.Masters.MasterEmployee();
        DataAccess.Masters.MasterRegion obj_region = new DataAccess.Masters.MasterRegion();
        DataAccess.Masters.MasterPort obj_port = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterDivision obj_div = new DataAccess.Masters.MasterDivision();
        DataAccess.Masters.MasterCustomerGroup obj_cusgruopname = new DataAccess.Masters.MasterCustomerGroup();
        DataAccess.HR.Employee obj_HRemp = new DataAccess.HR.Employee();
        DataAccess.CrdtAppLimit obj_CRApp = new DataAccess.CrdtAppLimit();
        DataAccess.Masters.MasterCreditApproval Appro_obj = new DataAccess.Masters.MasterCreditApproval();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.CrdtAppLimit crdtObj = new DataAccess.CrdtAppLimit();
        DataAccess.Masters.MasterCreditApproval obj_creditapp = new DataAccess.Masters.MasterCreditApproval();
        DataAccess.Masters.MasterBranch branchobj = new DataAccess.Masters.MasterBranch();
        DataTable Dt_GetDet = new DataTable();
        DataTable DTable = new DataTable();
        int intDivID, empid, emp;
        int intBranchID;
        int DsoDays;
        public Double availCrdtDay;
        string BranchSName;
        int groupid;
        string strCompany;
        int apptype;
        int intowner;
        Double AmtLmt;
        int DayLmt, back;
        int category;
        int ClientType;
        int CreditType;
        int OwnerId;
        int SalesId;
        string Ownername;
        string salname;
        bool strrow;
        DataTable dtbln = new DataTable();
        DataTable Dt = new DataTable();
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        Boolean crbln;
        DataTable dt_MenuRights = new DataTable();
        string exmode, Salesusername;
        int EmpId;
        string StrTranType = "";
        int rowIndex;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_main.GetDataBase(Ccode);
                obj_emp.GetDataBase(Ccode);
                obj_region.GetDataBase(Ccode);
                obj_port.GetDataBase(Ccode);
                obj_div.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                obj_cusgruopname.GetDataBase(Ccode);


                obj_HRemp.GetDataBase(Ccode);
                obj_CRApp.GetDataBase(Ccode);
                obj_creditapp.GetDataBase(Ccode);
                branchobj.GetDataBase(Ccode);
               




            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            //else if (Session["StrTranType"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            //}

            //Response.AppendHeader("refresh", "4"); 
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);

            if (ddl_product.Text != "" && ddl_product.Text != "0")
            {
                if (ddl_product.Text == "Ocean Exports")
                {
                    Session["StrTranType"] = "FE";
                    StrTranType = Session["StrTranType"].ToString();
                }
                else if (ddl_product.Text == "Ocean Imports")
                {
                    Session["StrTranType"] = "FI";
                    StrTranType = Session["StrTranType"].ToString();
                }
                else if (ddl_product.Text == "Air Exports")
                {
                    Session["StrTranType"] = "AE";
                    StrTranType = Session["StrTranType"].ToString();
                }
                else if (ddl_product.Text == "Air Imports")
                {
                    Session["StrTranType"] = "AI";
                    StrTranType = Session["StrTranType"].ToString();
                }
                //  GetDetails();
                intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                empid = Convert.ToInt32(Session["LoginEmpId"].ToString());

                if (Session["StrTranType"].ToString() == "FE")
                {
                    lblHead1.Visible = true;
                    lblHead2.Visible = true;
                    HeaderLabel1.InnerText = "OceanExports";
                    headerlabel2.InnerText = "Sales";
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    lblHead1.Visible = true;
                    lblHead2.Visible = true;
                    HeaderLabel1.InnerText = "OceanImports";
                    headerlabel2.InnerText = "Sales";
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    lblHead1.Visible = true;
                    lblHead2.Visible = true;
                    HeaderLabel1.InnerText = "AirExports";
                    headerlabel2.InnerText = "Sales";
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    lblHead1.Visible = true;
                    lblHead2.Visible = true;
                    HeaderLabel1.InnerText = "AirImports";
                    headerlabel2.InnerText = "Sales";
                }
                else if (Session["StrTranType"].ToString() == "CO")
                {
                    lblHead1.Visible = true;
                    lblHead2.Visible = true;
                    HeaderLabel1.InnerText = "Credit Control";
                    if (Session["RightsTranType"].ToString() == "MI")
                    {
                        headerlabel2.InnerText = "Credit";
                    }
                }

                if (intBranchID == 7)
                {
                    dtbln = Appro_obj.SPGETEmp(empid, intDivID);
                    if (dtbln.Rows.Count > 0)
                    {
                        emp = Convert.ToInt32(dtbln.Rows[0][0]);
                    }
                    if (emp != 0)
                    {
                        crbln = true;
                    }
                    else
                    {
                        crbln = false;
                    }

                }
                else
                {
                    emp = 0;

                }

                /* if (crbln == true)
                 {
                     if (intDivID == 1 || intDivID == 7)
                     {
                         txt_exemptions.Text = "1";
                         txt_exemptions.Enabled = true;
                         ddl_per.Enabled = true;
                         txt_overdue.Enabled = true;
                     }
                     else
                     {
                         txt_exemptions.Text = "3";
                         txt_exemptions.Enabled = true;
                         ddl_per.Enabled = true;
                         txt_overdue.Enabled = true;
                     }
                 }
                 else
                 {
                     if (intDivID == 1 || intDivID == 7)
                     {
                         txt_exemptions.Text = "1";
                         txt_exemptions.Enabled = false;
                         ddl_per.Enabled = false;
                         txt_overdue.Enabled = false;
                         ddl_per.SelectedIndex = 1;
                         txt_overdue.Text = "50";
                     }
                     else
                     {
                         txt_exemptions.Text = "3";
                         txt_exemptions.Enabled = false;
                         ddl_per.Enabled = false;
                         txt_overdue.Enabled = false;
                         ddl_per.SelectedIndex = 1;
                         txt_overdue.Text = "50";
                     }
                 }

             */

                string credit = "";
                if (Session["StrTranType"].ToString() == "CO")
                {
                     btnCancel.Text = "Cancel";
                    btnCancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    if (Session["Credit"] != null)
                    {
                        credit = Session["Credit"].ToString();
                        //Image1.Style.display = 'none';
                        //Image1.Attributes.Add("disabled", "disabled");
                        if (credit == "Credit")
                        {
                            //this.programmaticModalCancelCredit.Show();
                            Dt = Appro_obj.MCrdAppToShowGrd(empid, intDivID);
                            if (Dt.Rows.Count > 0)
                            {
                                GrdCancel.DataSource = Dt;
                                GrdCancel.DataBind();
                            }
                            else
                            {
                                GrdCancel.DataSource = Utility.Fn_GetEmptyDataTable();
                                GrdCancel.DataBind();
                            }

                        }
                    }

                    //txt_branch.Enabled = true;
                    //txt_branch.Focus();
                    ddlBranch.Enabled = true;
                    ddlBranch.Focus();

                }
                if (intBranchID != 7)
                {
                    ddlCompany.SelectedValue = Session["LoginDivisionName"].ToString();
                    //  txt_branch.Text = obj_CRApp.GetPortName(intBranchID, intDivID);
                    ddlBranch.SelectedItem.Text = obj_CRApp.GetPortName(intBranchID, intDivID);

                    ddlCompany_SelectedIndexChanged(sender, e);
                    //FillAmt();
                    ddlCompany.Enabled = false;
                    //txt_branch.Enabled = false;
                    ddlBranch.Enabled = false;
                }
                else
                {
                    ddlCompany.Enabled = true;
                    //txt_branch.Enabled = true;
                    ddlBranch.Enabled = true;
                }

                if (Request.QueryString.ToString().Contains("mis"))
                {
                    // breadcrumbs.Visible = false;
                    crumbsid.Attributes["class"] = "crumbs1";
                    btnCancel.Enabled = true;
                    btnSave.Enabled = false;
                    btnview.Enabled = false;
                    customerlink_Click(sender, e);
                }
            }
            else
            {
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        //CompanyDropCreditnew.Attributes["class"] = "CompanyDropCreditnew";
                        ddl_product.Visible = false;
                        intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                        intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                        empid = Convert.ToInt32(Session["LoginEmpId"].ToString());

                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            lblHead1.Visible = true;
                            lblHead2.Visible = true;
                            HeaderLabel1.InnerText = "OceanExports";
                            headerlabel2.InnerText = "Sales";
                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {
                            lblHead1.Visible = true;
                            lblHead2.Visible = true;
                            HeaderLabel1.InnerText = "OceanImports";
                            headerlabel2.InnerText = "Sales";
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {
                            lblHead1.Visible = true;
                            lblHead2.Visible = true;
                            HeaderLabel1.InnerText = "AirExports";
                            headerlabel2.InnerText = "Sales";
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {
                            lblHead1.Visible = true;
                            lblHead2.Visible = true;
                            HeaderLabel1.InnerText = "AirImports";
                            headerlabel2.InnerText = "Sales";
                        }
                        else if (Session["StrTranType"].ToString() == "CO")
                        {
                            lblHead1.Visible = true;
                            lblHead2.Visible = true;
                            HeaderLabel1.InnerText = "Credit Control";
                            if (Session["RightsTranType"].ToString() == "MI")
                            {
                                headerlabel2.InnerText = "Credit";
                            }
                        }

                        string credit = "";
                        if (Session["StrTranType"].ToString() == "CO")
                        {
                            btnCancel.Text = "Cancel";
                            //btnCancel.ToolTip = "Cancel";
                            //btn_cancel1.Attributes["class"] = "btn ico-cancel";
                            if (Session["Credit"] != null)
                            {
                                credit = Session["Credit"].ToString();
                                //Image1.Style.display = 'none';
                                //Image1.Attributes.Add("disabled", "disabled");
                                if (credit == "Credit")
                                {
                                    //this.programmaticModalCancelCredit.Show();
                                    Dt = Appro_obj.MCrdAppToShowGrd(empid, intDivID);
                                    if (Dt.Rows.Count > 0)
                                    {
                                        GrdCancel.DataSource = Dt;
                                        GrdCancel.DataBind();
                                    }
                                    else
                                    {
                                        GrdCancel.DataSource = Utility.Fn_GetEmptyDataTable();
                                        GrdCancel.DataBind();
                                    }

                                }
                            }

                            //txt_branch.Enabled = true;
                            //txt_branch.Focus();
                            ddlBranch.Enabled = true;
                            ddlBranch.Focus();

                        }
                        if (intBranchID != 7)
                        {
                            ddlCompany.SelectedValue = Session["LoginDivisionName"].ToString();
                            //  txt_branch.Text = obj_CRApp.GetPortName(intBranchID, intDivID);
                            ddlBranch.SelectedItem.Text = obj_CRApp.GetPortName(intBranchID, intDivID);

                            ddlCompany_SelectedIndexChanged(sender, e);
                            //FillAmt();
                            ddlCompany.Enabled = false;
                            //txt_branch.Enabled = false;
                            ddlBranch.Enabled = false;
                        }
                        else
                        {
                            ddlCompany.Enabled = true;
                            //txt_branch.Enabled = true;
                            ddlBranch.Enabled = true;
                        }

                        if (Request.QueryString.ToString().Contains("mis"))
                        {
                            // breadcrumbs.Visible = false;
                            crumbsid.Attributes["class"] = "crumbs1";
                            btnCancel.Enabled = true;
                            btnSave.Enabled = false;
                            btnview.Enabled = false;
                            customerlink_Click(sender, e);
                        }
                    }
                }
                //else
                //{

                //}
            }

            if (!IsPostBack)
            {
                try
                {

                    AppType();
                    CompanyFill();
                    footerRowVisible();
                    BranchLoad();
                    grdcreditrequest();//newadded
                    txt_customer.Focus();
                       btnSave.Text = "Save";
                   btnCancel.Text = "Back";
                    btnSave.ToolTip = "Save";
                    btnCancel.ToolTip = "Back";
                    btn_save1.Attributes["class"] = "btn ico-save";
                    btnCancel.ToolTip = "Back";
                    btn_cancel1.Attributes["class"] = "btn ico-back";
                    GetDetails();
                    //Ctrl_List = txt_customer.ID + "~" + txt_approvedBy.ID + "~" + txt_approvedAmt.ID + "~" + txt_app_days.ID + "~" + ddlApptype.ID + "~" + txt_exemptions.ID + "~" + txt_overdue.ID;
                    //Msg_List = "Customer Name~Approved By~Approved Amt~Approved Days~Approved Type ~ No. of Exemptions~Overdue";
                    //   Ctrl_List = txt_customer.ID + "~" + ddlApptype.ID + "~" + txt_exemptions.ID + "~" + txt_overdue.ID;
                    Ctrl_List = txt_customer.ID;
                    Msg_List = "Customer Name";
                    Dtype_List = "string";
                    // Msg_List = "Customer Name~Approved Type ~ No. of Exemptions~Overdue";
                    //Dtype_List = "string~string";
                    btnSave.Attributes.Add("onclick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    Utility.Fn_CheckUserRights(str_Uiid, btnSave, null, null);
                    txt_app_days.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    txt_exemptions.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    txt_overdue.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    //CheckPending.Checked = false;
                    txt_credit_reqon.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    EmpId = Convert.ToInt32(Session["LoginEmpId"].ToString());
                    txt_approvedBy.Text = obj_emp.GetEmployeeName(EmpId);
                    txt_approvedBy.Enabled = false;

                    if (Session["trantype_process"] != null)
                    {
                        lblHead1.Visible = false;
                        lblHead2.Visible = false;
                        dt_MenuRights = Session["trantype_process"] as DataTable;
                        ddl_product.Items.Add("");
                        for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                        {
                            if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FE")
                            {
                                ddl_product.Items.Add("Ocean Exports");
                            }
                            else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FI")
                            {
                                ddl_product.Items.Add("Ocean Imports");
                            }
                            else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AE")
                            {
                                ddl_product.Items.Add("Air Exports");
                            }
                            else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AI")
                            {
                                ddl_product.Items.Add("Air Imports");
                            }
                        }

                        ddl_product.SelectedValue = "Air Exports";
                        // Session["StrTranType"] = dt_MenuRights.Rows[i]["modulename"].ToString();
                    }
                    intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());

                    if (intBranchID == 7 || intBranchID == 5)
                    {
                        dtbln = Appro_obj.SPGETEmp(empid, intDivID);
                        if (dtbln.Rows.Count > 0)
                        {
                            emp = Convert.ToInt32(dtbln.Rows[0][0]);
                        }
                        if (emp != 0)
                        {
                            crbln = true;
                        }
                        else
                        {
                            crbln = false;
                        }

                    }
                    else
                    {
                        emp = 0;

                    }

                    if (crbln == true)
                    {
                        if (intDivID == 11)
                        {
                            txt_exemptions.Text = "1";
                            txt_exemptions.Enabled = true;
                            ddl_per.Enabled = true;
                            txt_overdue.Enabled = true;
                        }
                        else
                        {
                            txt_exemptions.Text = "3";
                            txt_exemptions.Enabled = true;
                            ddl_per.Enabled = true;
                            txt_overdue.Enabled = true;
                        }
                    }
                    else
                    {
                        if (intDivID == 11)
                        {
                            txt_exemptions.Text = "1";
                            txt_exemptions.Enabled = false;
                            ddl_per.Enabled = false;
                            txt_overdue.Enabled = false;
                            if (intBranchID == 7)
                            {
                                if (ddl_per.Enabled == true)
                                {
                                    ddl_per.SelectedIndex = 0;//1
                                }
                                else
                                {
                                    ddl_per.SelectedIndex = 1;//2
                                }
                            }
                            else
                            {
                                ddl_per.SelectedIndex = 0;//1
                            }
                            txt_overdue.Text = "50";
                        }
                        else
                        {
                            txt_exemptions.Text = "3";
                            txt_exemptions.Enabled = false;
                            ddl_per.Enabled = false;
                            txt_overdue.Enabled = false;
                            if (intBranchID == 7)
                            {

                                if (ddl_per.Enabled == true)
                                {
                                    ddl_per.SelectedIndex = 0;//1
                                }
                                else
                                {
                                    ddl_per.SelectedIndex = 1;//2
                                }
                            }
                            else
                            {
                                ddl_per.SelectedIndex = 0;//1
                            }
                            txt_overdue.Text = "50";
                        }
                    }

                    string credit = "";
                    if (Session["StrTranType"] != null)
                    {
                        if (Session["StrTranType"].ToString() == "CO")
                        {
                            //  btnCancel.Text = "Cancel";
                            btnCancel.ToolTip = "Cancel";
                            if (Session["Credit"] != null)
                            {
                                credit = Session["Credit"].ToString();
                                if (credit == "Credit")
                                {
                                    Dt = Appro_obj.MCrdAppToShowGrd(empid, intDivID);
                                    if (Dt.Rows.Count > 0)
                                    {
                                        GrdCancel.DataSource = Dt;
                                        GrdCancel.DataBind();
                                    }
                                    else
                                    {
                                        GrdCancel.DataSource = Utility.Fn_GetEmptyDataTable();
                                        GrdCancel.DataBind();
                                    }

                                }
                            }
                            ddlBranch.Enabled = true;
                            ddlBranch.Focus();

                        }
                    }
                    if (intBranchID != 7)
                    {
                        ddlCompany.SelectedValue = Session["LoginDivisionName"].ToString();
                        ddlBranch.SelectedItem.Text = obj_CRApp.GetPortName(intBranchID, intDivID);
                        ddlCompany.Enabled = false;
                        ddlBranch.Enabled = false;
                    }
                    else
                    {
                        ddlCompany.Enabled = true;
                        ddlBranch.Enabled = true;
                    }

                    if (Request.QueryString.ToString().Contains("mis"))
                    {
                        crumbsid.Attributes["class"] = "crumbs1";
                        btnCancel.Enabled = true;
                        btnSave.Enabled = false;
                        btnview.Enabled = false;
                        customerlink_Click(sender, e);
                    }

                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            string a = Session["LoginDivisionName"].ToString();
            ddlCompany.Items.Clear();
            ddlCompany.Items.Add(a);
            //ddlCompany.Text = a;
            ddlCompany.Enabled = false;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<string> GetCustomer(string prefix, string ChkType)
        {
            List<string> List_Result = new List<string>();
            //String val = false.ToString();
            // bool val;

            //  val = Convert.ToBoolean(HttpContext.Current.Session["VSSsnap"]);
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int dvid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString());
            int eid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());

            //
            //     DataAccess.CrdtAppLimit crdtObj = new DataAccess.CrdtAppLimit();
            //     int INTDIVID =Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            //     int bid = Convert.ToInt32(HttpContext.Current.Session["BRANCHID"].ToString());

            //

            //String value = session["VSSsnap"].ToString();
            DataAccess.Masters.MasterCustomerGroup obj_name = new DataAccess.Masters.MasterCustomerGroup();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_name.GetDataBase(Ccode);
            DataTable dt_cusname = new DataTable();
            //       if (bid == 40 || bid == 51 || bid == 52 || bid == 62|)
            if (bid == 7)
            {
                if (ChkType == "True")
                {
                    dt_cusname = obj_name.GetLikePendingApp4CreditAppNew(prefix, eid, 0, dvid);

                }
                else
                {
                    dt_cusname = obj_name.GetLikeCustGroup4DivisionNew(prefix, 0, dvid);
                }
            }
            else
            {
                if (ChkType == "True")
                {
                    dt_cusname = obj_name.GetLikePendingApp4CreditAppNew(prefix.ToUpper(), eid, bid, dvid);

                }
                else
                {
                    dt_cusname = obj_name.GetLikeCustGroup4DivisionNew(prefix, bid, dvid);
                }
            }

            List_Result = Utility.Fn_DatatableToList_int16Display(dt_cusname, "gname", "groupid", "Column1");
            return List_Result;

        }

        [WebMethod]

        public static List<string> GetBranch(string prefix)
        {

            List<string> list_result = new List<string>();
            DataAccess.CrdtAppLimit crdtObj = new DataAccess.CrdtAppLimit();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            crdtObj.GetDataBase(Ccode);

            DataTable DTable = new DataTable();
            int dvid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString());
            DTable = crdtObj.GetLikeBranchName(dvid, prefix);

            list_result = Utility.fn_test(DTable, "portname", "branchid", "dsodays", "portname");

            return list_result;
        }
        public void BranchLoad()
        {
            ddlBranch.SelectedValue = "0";
            int i;
            int divid = Convert.ToInt32(Session["LoginDivisionId"].ToString());

            Dt = obj_main.GetBranchByDivID(divid);

            if (Dt.Rows.Count > 0)
            {
                for (i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    ddlBranch.Items.Add(Dt.Rows[i]["branch"].ToString());
                }
            }
        }

        private void AppType()
        {
            //ddlApptype.Items.Add("--App.Type--");
            ddlApptype.Items.Add("Clean");
            ddlApptype.Items.Add("Against PDC");
        }
        private void CompanyFill()
        {
            //DataTable dtdivn = new DataTable();
            //dtdivn = obj_HRemp.GetCreditDivision("S");
            //ddlCompany.Items.Add("");
            //for (int i = 0; i <= dtdivn.Rows.Count - 1; i++)
            //{
            //    ddlCompany.Items.Add(dtdivn.Rows[i][0].ToString());
            //}
            // DataTable obj_dtTemp = new DataTable();
            // obj_dtTemp = obj_HRemp.GetDivision();
            // ddlCompany.DataSource = obj_dtTemp;
            //// ddlCompany.DataTextField = "divsname";
            // ddlCompany.DataBind();

        }

        private void FillAmt()
        {
            try
            {
                DataTable Dt_GetDet = new DataTable();
                Dt_GetDet = obj_CRApp.GetCrdtAppLimitDetails(intBranchID, intDivID, DsoDays);
                if (Dt_GetDet.Rows.Count > 0)
                {
                    txt_invoiceAmt.Text = Dt_GetDet.Rows[0]["TotInvAmt"].ToString();
                    txt_invoiceAmt.Text = Convert.ToDecimal(txt_invoiceAmt.Text).ToString("#,0.00");

                    txt_AppCrdtAmt.Text = Dt_GetDet.Rows[0]["CrdtAmt"].ToString();
                    txt_AppCrdtAmt.Text = Convert.ToDecimal(txt_AppCrdtAmt.Text).ToString("#,0.00");

                    txt_actOutstanding.Text = Dt_GetDet.Rows[0]["OSAmt"].ToString();
                    txt_actOutstanding.Text = Convert.ToDecimal(txt_actOutstanding.Text).ToString("#,0.00");
                    txt_dsodays.Text = DsoDays.ToString();

                    txt_Avg.Text = Dt_GetDet.Rows[0]["TotInvAmt"].ToString();
                    Double avg = Convert.ToDouble(txt_Avg.Text) / 30;
                    txt_Avg.Text = avg.ToString("#,0.00");

                    txt_less.Text = txt_actOutstanding.Text;

                    if ((Convert.ToDouble(txt_less.Text.Trim())) <= 0 || (Convert.ToDouble(txt_Avg.Text.Trim())) <= 0)
                    {
                        availCrdtDay = 0;
                    }
                    else
                    {
                        double less1 = Convert.ToDouble(txt_less.Text);
                        int less = Convert.ToInt32(less1);
                        availCrdtDay = less / avg;
                        //availCrdtDay = Convert.ToInt64(txt_less.Text) / avg;
                    }
                    //    availCrdtDay = 10;

                    hid_availCrdtDay.Value = availCrdtDay.ToString();
                    txt_actual_dsodays.Text = availCrdtDay.ToString();
                    txt_actual_dsodays.Text = Convert.ToInt32(Convert.ToDouble(availCrdtDay)).ToString();

                    if ((Convert.ToInt32(txt_dsodays.Text.Trim())) < availCrdtDay || availCrdtDay == 0)
                    {
                        btnSave.Enabled = false;

                        txt_actual_dsodays.ForeColor = Color.Red;

                        id_txt_actual_dsodays.Attributes["class"] = "custom-col custom-mr-05";
                        btnSave.ForeColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        txt_actual_dsodays.ForeColor = Color.Black;
                        id_txt_actual_dsodays.Attributes["class"] = "custom-col custom-mr-05";
                        btnSave.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    ClearAmt();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void ClearAmt()
        {
            txt_invoiceAmt.Text = "";
            txt_AppCrdtAmt.Text = "";
            txt_actOutstanding.Text = "";
            txt_dsodays.Text = "";
            txt_Avg.Text = "";
            txt_less.Text = "";
            txt_actual_dsodays.Text = "";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //DataTable dt_CrdAmt = new DataTable();
                intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());

                Double TotalACAmt = 0;

                DataTable dt_CrdAmt = new DataTable();
                //DataRow dr = dt_CrdAmt.NewRow();

                dt_CrdAmt.Columns.Add("salesperson");
                dt_CrdAmt.Columns.Add("branch");
                dt_CrdAmt.Columns.Add("customername");
                dt_CrdAmt.Columns.Add("appamt");
                dt_CrdAmt.Columns.Add("employeeid");
                dt_CrdAmt.Columns.Add("bid");
                dt_CrdAmt.Columns.Add("divid");
                DataRow dr;
                dr = dt_CrdAmt.NewRow();
                dt_CrdAmt = obj_CRApp.GetCrdtAmtLimitEmpwise(intBranchID, intDivID);

                if (dt_CrdAmt.Rows.Count > 0)
                {
                    this.programmaticModalPopup.Show();

                    dr = dt_CrdAmt.NewRow();
                    for (int i = 0; i <= dt_CrdAmt.Rows.Count - 1; i++)
                    {
                        TotalACAmt = TotalACAmt + Convert.ToDouble(dt_CrdAmt.Rows[i]["appamt"]);
                    }
                    //Label lblSerial = (Label)Grdcustomer.Rows[0].FindControl("lblSerial");
                    //lblSerial.Text = "";          
                    dr[2] = "Total";
                    dr[3] = string.Format("{0:0.00}", TotalACAmt);
                    dt_CrdAmt.Rows.Add(dr);
                    GrdCreditAmt.DataSource = dt_CrdAmt;
                    GrdCreditAmt.DataBind();
                    GrdCreditAmt.Visible = true;
                    GrdCreditAmt.Rows[GrdCreditAmt.Rows.Count - 1].Cells[0].Text = "";
                }
                else
                {
                    //dt_CrdAmt.Rows.Add(dt_CrdAmt.NewRow());
                    //GrdCreditAmt.DataSource = dt_CrdAmt;
                    //GrdCreditAmt.DataBind();
                    //int totalcolums = GrdCreditAmt.Rows[0].Cells.Count;
                    //GrdCreditAmt.Rows[0].Cells.Clear();
                    //GrdCreditAmt.Rows[0].Cells.Add(new TableCell());
                    //GrdCreditAmt.Rows[0].Cells[0].ColumnSpan = totalcolums;
                    //GrdCreditAmt.Rows[0].Cells[0].Text = "No Data Found";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('No Approved Credit Available');", true);

                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        //TotalACAmt = TotalACAmt + Convert.ToDouble(dt_CrdAmt.Rows[0]["appamt"].ToString());
        //dr = dt_CrdAmt.NewRow();
        //dr["customername"] ="Total";
        //dr["appamt"] = TotalACAmt;
        //dt_CrdAmt.Rows.Add(dr);

        protected void customerlink_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlBranch.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(customerlink, typeof(Button), "Master Approval", "alertify.alert('Please Select Branch Name');", true);
                    ddlBranch.Focus();
                    return;
                }

                intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int EmpId = Convert.ToInt32(Session["LoginEmpId"].ToString());

                Dt = crdtObj.GetLikeBranchName(intDivID, (ddlBranch.SelectedItem.Text.Trim()));

                DataTable dt_com = new DataTable();

                if (obj_main.Getbranchname(intBranchID) == "CORPORATE")
                {
                    if (CheckPending.Checked == true)
                    {
                        dt_com = Appro_obj.MCrdAppToShowGrdNew(0, 0, intDivID);
                    }
                    else
                    {
                        dt_com = Appro_obj.MCrdAppToShowGrdNew(EmpId, 0, intDivID);
                    }

                }
                else
                {
                    if (CheckPending.Checked == true)
                    {
                        dt_com = Appro_obj.MCrdAppToShowGrdNew(0, intBranchID, intDivID);
                    }
                    else
                    {
                        dt_com = Appro_obj.MCrdAppToShowGrdNew(EmpId, intBranchID, intDivID);
                    }
                }

                if (dt_com.Rows.Count > 0)
                {
                    this.programmaticModalCustomer.Show();
                    Grdcustomer.DataSource = dt_com;
                    Grdcustomer.DataBind();
                }
                else
                {
                    //dt_com.Rows.Add(dt_com.NewRow());
                    //Grdcustomer.DataSource = dt_com;
                    //Grdcustomer.DataBind();
                    //int totalcolums = Grdcustomer.Rows[0].Cells.Count;
                    //Grdcustomer.Rows[0].Cells.Clear();
                    //Grdcustomer.Rows[0].Cells.Add(new TableCell());
                    //Grdcustomer.Rows[0].Cells[0].ColumnSpan = totalcolums;
                    //Grdcustomer.Rows[0].Cells[0].Text = "No Data Found";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('No customer');", true);
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void chkCanelCerdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlBranch.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(customerlink, typeof(Button), "Master Approval", "alertify.alert('Please Select Branch Name');", true);
                    ddlBranch.Focus();
                    return;
                }
                if (hid_branchid.Value != "")
                {
                    intBranchID = Convert.ToInt32(hid_branchid.Value);
                }
                else
                {
                    intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                }

                DataTable dtCancel = new DataTable();
                dtCancel = Appro_obj.GetApprovedListgrd(intBranchID);

                if (dtCancel.Rows.Count > 0)
                {
                    this.programmaticModalCancelCredit.Show();
                    GrdCancel.DataSource = dtCancel;
                    GrdCancel.DataBind();
                    ViewState["GrdCancel"] = dtCancel;
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('Cancel Credit not Available');", true);

                    //dtCancel.Rows.Add(dtCancel.NewRow());
                    //GrdCancel.DataSource = dtCancel;
                    //GrdCancel.DataBind();
                    //int totalcolums = GrdCancel.Rows[0].Cells.Count;
                    //GrdCancel.Rows[0].Cells.Clear();
                    //GrdCancel.Rows[0].Cells.Add(new TableCell());
                    //GrdCancel.Rows[0].Cells[0].ColumnSpan = totalcolums;
                    //GrdCancel.Rows[0].Cells[0].Text = "No Data Found";

                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCompany.SelectedIndex != -1)
                {
                    intDivID = obj_div.GetDivisionId_new(ddlCompany.SelectedValue);
                }
                else
                {
                    intDivID = 0;
                    ClearAmt();
                }

                if (intBranchID != 0)
                {
                    DataTable dt = new DataTable();
                    dt = obj_CRApp.GetLikeBranchName(intDivID, ddlBranch.SelectedItem.Text.Trim());
                    if (dt.Rows.Count > 0)
                    {
                        intBranchID = Convert.ToInt32(dt.Rows[0]["branchid"].ToString());
                        BranchSName = dt.Rows[0]["portname"].ToString();
                        DsoDays = Convert.ToInt32(dt.Rows[0]["dsodays"].ToString());
                        ddlBranch.SelectedItem.Text = BranchSName;
                        FillAmt();
                    }
                    else
                    {
                        ClearAmt();
                        ddlBranch.SelectedIndex = 0;
                        ddlBranch.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_customer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtCust = new DataTable();
                intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int EmpId = Convert.ToInt32(Session["LoginEmpId"].ToString());
                if (ddlBranch.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(customerlink, typeof(Button), "Master Approval", "alertify.alert('Please Select Branch Name');", true);
                    txt_customer.Text = "";
                    ddlBranch.Focus();
                    return;
                }
                if (txt_customer.Text.Trim().ToUpper() != "")
                {
                    if (hdf_cusid.Value != "")
                    {
                        groupid = Convert.ToInt32(hdf_cusid.Value.ToString());
                    }
                    else if (txt_customer.Text.Trim().ToUpper() != "")
                    {
                        if (intBranchID != 40 && intBranchID != 51 && intBranchID != 52 && intBranchID != 62)
                        {
                            if (CheckPending.Checked == true)
                            {
                                DtCust = obj_cusgruopname.GetLikePendingApp4CreditAppNew(txt_customer.Text, EmpId, 0, intDivID);
                            }
                            else
                            {
                                DtCust = obj_cusgruopname.GetLikeCustGroup4DivisionNew(txt_customer.Text, 0, intDivID);
                            }
                        }
                        else
                        {
                            if (CheckPending.Checked == true)
                            {
                                DtCust = obj_cusgruopname.GetLikePendingApp4CreditAppNew(txt_customer.Text, EmpId, intBranchID, intDivID);
                            }
                            else
                            {
                                DtCust = obj_cusgruopname.GetLikeCustGroup4DivisionNew(txt_customer.Text, intBranchID, intDivID);
                            }
                        }

                        if (DtCust.Rows.Count > 0)
                        {
                            groupid = Convert.ToInt32(DtCust.Rows[0][0].ToString());
                            hdf_cusid.Value = groupid.ToString();
                            strCompany = DtCust.Rows[0][1].ToString();
                            txt_customer.Text = strCompany;
                        }
                        else
                        {

                            groupid = 0;
                            strCompany = "";
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('Enter Correct Customer Name');", true);
                            txtclear();
                            txtappclear();
                            txt_customer.Focus();
                        }
                    }
                }
                else
                {
                    groupid = 0;
                    txtclear();
                    txtappclear();
                }

                if (groupid != 0)
                {
                    GetDetails();
                    txt_customer.Focus();
                    btn_save1.Attributes["class"] = "btn ico-update";
                    btnSave.Text = "Update";
                    btnSave.ToolTip = "Update";
                   btnCancel.Text = "Cancel";
                    btnCancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                grdcreditrequest(); //added
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void txtclear()
        {
            //txt_cusdetails.Text = "";
            txt_customer.Text = "";
            txt_approvedAmt.Text = "";
            txt_app_days.Text = "";
            txt_cano.Text = "";
            // txt_overdue.Text = "";
            //txt_exemptions.Text = "";
            //ddl_per.SelectedIndex = 0;
            ddlApptype.SelectedIndex = 0;
            Book2.Visible = true;
        }
        private void txtclear1()
        {
            //txt_cusdetails.Text = "";
            txt_customer.Text = "";
            txt_approvedAmt.Text = "";
            txt_app_days.Text = "";
            txt_cano.Text = "";
            // txt_overdue.Text = "";
            // txt_exemptions.Text = "";
            //ddl_per.SelectedIndex = 0;
            ddlApptype.SelectedIndex = 0;
            // Book2.Visible = false;
        }

        public void txtappclear()
        {
            txt_approvedAmt.Text = "";
            txt_app_days.Text = "";
            //ddlApptype.SelectedIndex = 0;

            //ddlFootrCFO.SelectedIndex = 0;
            //ddlFootrCoO.SelectedIndex = 0;
            //ddlFootrMD.SelectedIndex = 0;

            txt_approvedAmt.Enabled = true;
            txt_app_days.Enabled = true;
            ddlApptype.Enabled = true;

            if (txt_dsodays.Text.Trim() != "")
            {
                if ((Convert.ToInt32(txt_dsodays.Text.Trim())) < Convert.ToDouble(hid_availCrdtDay.Value) || Convert.ToDouble(hid_availCrdtDay.Value) == 0)
                {
                    btnSave.Enabled = false;

                    txt_actual_dsodays.ForeColor = Color.Red;
                    id_txt_actual_dsodays.Attributes["class"] = "custom-col custom-mr-05";
                    btnSave.ForeColor = System.Drawing.Color.Gray;

                }
                else
                {
                    btnSave.Enabled = true;
                    btnSave.ForeColor = System.Drawing.Color.White;
                    id_txt_actual_dsodays.Attributes["class"] = "custom-col custom-mr-05";
                    txt_actual_dsodays.ForeColor = Color.Black;
                }
            }

        }

        private void CollectData()
        {
            if (ddlApptype.SelectedValue == "Clean")
            {
                apptype = 1;
            }
            else if (ddlApptype.SelectedValue == "Against PDC")
            {
                apptype = 2;
            }
            if (ddl_per.Text == "Annual")
            {
                exmode = "A";
            }
            else if (ddl_per.Text == "Month")
            {
                exmode = "M";
            }
            else
            {
                exmode = "";
            }
            ddlApptype.SelectedValue = "Clean";
            apptype = 1;
        }

        private void GetDetails()
        {
            try
            {
                DataTable dt_retv = new DataTable();
                DataTable dtcredit = new DataTable();
                DataSet dtset = new DataSet();
                intDivID = Convert.ToInt16(Session["LoginDivisionId"].ToString());
                intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                if (hdf_cusid.Value != "" || hdf_cusid.Value == "0")
                {
                    groupid = Convert.ToInt32(hdf_cusid.Value);
                }
                if (intBranchID == 7)
                {
                    dtbln = Appro_obj.SPGETEmp(empid, intDivID);
                    if (dtbln.Rows.Count > 0)
                    {
                        emp = Convert.ToInt32(dtbln.Rows[0][0]);
                    }
                    if (emp != 0)
                    {
                        crbln = true;
                    }
                    else
                    {
                        crbln = false;
                    }

                }
                else
                {
                    emp = 0;

                }

                if (groupid != 0)
                {
                    //groupid = obj_cusgruopname.GetCustomerGroupID(txt_customer.Text.ToUpper().Trim());
                    dtset = Appro_obj.RetrieveCreditAppDtsNew(groupid, intDivID);
                    if (dtset.Tables.Count > 0)
                    {
                        dt_retv = dtset.Tables[0];
                        dtcredit = dtset.Tables[1];
                    }
                    //dt_retv = Appro_obj.RetrieveCreditAppDtsNew(groupid, DivsnId);
                    hdf_cusid.Value = groupid.ToString();
                    if (dt_retv.Rows.Count > 0)
                    {

                        Book2.Visible = true;
                        category = Convert.ToInt32(dt_retv.Rows[0][1].ToString());
                        String rgdate1 = dt_retv.Rows[0][4].ToString();
                        String indate1 = dt_retv.Rows[0][5].ToString();
                        OwnerId = Convert.ToInt32(dt_retv.Rows[0][19].ToString());

                        SalesId = Convert.ToInt32(dt_retv.Rows[0][20].ToString());
                        hid_sal.Value = SalesId.ToString();
                        Ownername = obj_main.GetShortName(OwnerId);
                        hid_own.Value = OwnerId.ToString();
                        salname = obj_emp.GetEmployeeName(SalesId);

                        DataTable dtapp = new DataTable();
                        dtapp.Columns.Add("Customer");
                        dtapp.Columns.Add(" Details");
                        DataRow dr1 = dtapp.NewRow();
                        dr1[0] = "PAN #";
                        dr1[1] = dt_retv.Rows[0][2].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "REG #";
                        dr1[1] = dt_retv.Rows[0][3].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "REG Date";
                        if (rgdate1 != "")
                        {
                            dr1[1] = Utility.fn_ConvertDate(rgdate1);
                        }
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "InCorp Date";
                        if (indate1 != "")
                        {
                            dr1[1] = Utility.fn_ConvertDate(indate1);
                        }
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "DOC Recv";
                        dr1[1] = dt_retv.Rows[0][6].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "Owner";
                        dr1[1] = Ownername;
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Sales Person";
                        dr1[1] = salname;
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Volume ";
                        dr1[1] = dt_retv.Rows[0]["volume"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Revenue ";
                        dr1[1] = dt_retv.Rows[0]["revenue"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "PTC ";
                        dr1[1] = dt_retv.Rows[0][7].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Phone";
                        dr1[1] = dt_retv.Rows[0][8].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "Mobile";
                        dr1[1] = dt_retv.Rows[0][9].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "EMail";
                        dr1[1] = dt_retv.Rows[0][10].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "about";
                        dr1[1] = dt_retv.Rows[0][15].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "credit days";
                        dr1[1] = dt_retv.Rows[0][16].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "credit amt";
                        dr1[1] = dt_retv.Rows[0][17].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "credit type";
                        dr1[1] = Convert.ToInt32(dt_retv.Rows[0][18].ToString());
                        dtapp.Rows.Add(dr1);

                        //dr1 = dtapp.NewRow();
                        //dr1[0] = "OwnerId";
                        //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][19].ToString());
                        //dtapp.Rows.Add(dr1);

                        //dr1 = dtapp.NewRow();
                        //dr1[0] = "SalesId";
                        //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][20].ToString());
                        //dtapp.Rows.Add(dr1);

                        test.DataSource = dtapp;
                        test.DataBind();

                        CreditType = Convert.ToInt32(dt_retv.Rows[0][18].ToString());
                        OwnerId = Convert.ToInt32(dt_retv.Rows[0][19].ToString());
                        SalesId = Convert.ToInt32(dt_retv.Rows[0][20].ToString());

                        if ((Convert.ToDouble(txt_dsodays.Text)) < (Convert.ToDouble(txt_actual_dsodays.Text)))
                        {
                            btnSave.Enabled = false;

                            btnSave.ForeColor = System.Drawing.Color.Gray;
                            txt_actual_dsodays.ForeColor = Color.Red;
                            id_txt_actual_dsodays.Attributes["class"] = "custom-col custom-mr-05";

                        }
                        else
                        {
                            btnSave.Enabled = true;
                            btnSave.ForeColor = System.Drawing.Color.White;
                            txt_actual_dsodays.ForeColor = Color.Black;
                            id_txt_actual_dsodays.Attributes["class"] = "custom-col custom-mr-05";
                        }

                        txt_approvedAmt.Text = dt_retv.Rows[0][24].ToString();
                        txt_approvedAmt.Text = Convert.ToDecimal(txt_approvedAmt.Text).ToString("0.00");
                        txt_app_days.Text = dt_retv.Rows[0][25].ToString();
                        lbl_crmt.Text = "";
                        if (txt_approvedAmt.Text != "0.00")
                        {

                            lbl_crmt.Text = "Existing Overall Credit Amount : " + Convert.ToDecimal(dt_retv.Rows[0][24].ToString()).ToString("0.00") + " and Overall Credit Days : " + dt_retv.Rows[0][25].ToString();
                        }
                        if (Convert.ToInt32(dt_retv.Rows[0][26].ToString()) == 1)
                        {
                            ddlApptype.SelectedValue = "Clean";
                        }
                        else if (Convert.ToInt32(dt_retv.Rows[0][26].ToString()) == 2)
                        {
                            ddlApptype.SelectedValue = "Against PDC";
                        }

                        if (dt_retv.Rows[0]["appby"].ToString() == "")
                        {
                            if (dt_retv.Rows[0]["appby"].ToString() != "")
                            {
                                if (Convert.ToInt32(dt_retv.Rows[0]["appby"].ToString()) == 0)
                                {
                                    txt_approvedBy.Text = obj_emp.GetEmployeeName(Convert.ToInt32(dt_retv.Rows[0]["appby"].ToString()));
                                }
                                else
                                {
                                    txt_approvedBy.Text = obj_emp.GetEmployeeName(empid);
                                }
                            }
                            else
                            {
                                txt_approvedBy.Text = obj_emp.GetEmployeeName(empid);
                            }
                        }
                        else
                        {
                            txt_approvedBy.Text = obj_emp.GetEmployeeName(empid);
                        }

                        if (dt_retv.Rows[0]["creditreqon"].ToString() != "")
                        {
                            String date1 = dt_retv.Rows[0]["creditreqon"].ToString();
                            txt_credit_reqon.Text = Utility.fn_ConvertDate(date1);
                        }
                        else
                        {
                            txt_credit_reqon.Text = Logobj.GetDate().ToShortDateString();
                        }

                        Ownername = obj_main.GetShortName(OwnerId);
                        salname = obj_emp.GetEmployeeName(SalesId);

                        ddl_per.Items.Clear();
                        //ddl_per.Items.Add("Per");
                        ddl_per.Items.Add("Annual");
                        ddl_per.Items.Add("Month");
                        if (dtcredit.Rows.Count > 0)
                        {
                            txt_exemptions.Text = dtcredit.Rows[0]["exlimit"].ToString();
                            if (dtcredit.Rows[0]["exmode"].ToString() == "A")
                            {
                                ddl_per.SelectedIndex = 0; //1
                            }
                            else if (dtcredit.Rows[0]["exmode"].ToString() == "M")
                            {
                                ddl_per.SelectedIndex = 1; //2
                            }
                            else
                            {
                                ddl_per.SelectedIndex = 0;
                            }
                            txt_overdue.Text = dtcredit.Rows[0]["overdue"].ToString();
                        }
                        else
                        {

                            if (crbln == true)
                            {
                                if (intDivID == 11)
                                {
                                    txt_exemptions.Text = "1";
                                    txt_exemptions.Enabled = true;
                                    ddl_per.Enabled = true;
                                    txt_overdue.Enabled = true;
                                }
                                else
                                {
                                    txt_exemptions.Text = "3";
                                    txt_exemptions.Enabled = true;
                                    ddl_per.Enabled = true;
                                    txt_overdue.Enabled = true;
                                }
                            }
                            else
                            {
                                if (intDivID == 11)
                                {
                                    txt_exemptions.Text = "1";
                                    txt_exemptions.Enabled = false;
                                    ddl_per.Enabled = false;
                                    txt_overdue.Enabled = false;
                                    ddl_per.SelectedIndex = 0;//1
                                    txt_overdue.Text = "50";
                                }
                                else
                                {
                                    txt_exemptions.Text = "3";
                                    txt_exemptions.Enabled = false;
                                    ddl_per.Enabled = false;
                                    txt_overdue.Enabled = false;
                                    ddl_per.SelectedIndex = 0;//1
                                    txt_overdue.Text = "50";
                                }
                            }

                            if (intBranchID == 7)
                            {
                                if (ddl_per.Enabled == true)
                                {
                                    ddl_per.SelectedIndex = 0;
                                }

                                else
                                {
                                    ddl_per.SelectedIndex = 1;//2

                                }
                            }
                            else
                            {
                                ddl_per.SelectedIndex = 0;//1
                            }

                        }
                      btnSave.Text = "Update";
                        btnSave.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";

                        btnCancel.Text = "Cancel";
                        btnCancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                    else
                    {

                        Book2.Visible = true;
                        /* category = Convert.ToInt32(dt_retv.Rows[0][1].ToString());
                         String rgdate1 = dt_retv.Rows[0][4].ToString();
                         String indate1 = dt_retv.Rows[0][5].ToString();
                         OwnerId = Convert.ToInt32(dt_retv.Rows[0][19].ToString());

                         SalesId = Convert.ToInt32(dt_retv.Rows[0][20].ToString());
                         hid_sal.Value = SalesId.ToString();
                         Ownername = obj_main.GetShortName(OwnerId);
                         hid_own.Value = OwnerId.ToString();
                         salname = obj_emp.GetEmployeeName(SalesId);*/

                        DataTable dtapp = new DataTable();
                        dtapp.Columns.Add("Customer");
                        dtapp.Columns.Add(" Details");
                        DataRow dr1 = dtapp.NewRow();
                        dr1[0] = "PAN #";
                        // dr1[1] = dt_retv.Rows[0][2].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "REG #";
                        dr1[1] = dt_retv.Rows[0][3].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "REG Date";
                        //  dr1[1] = Utility.fn_ConvertDate(rgdate1);
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "InCorp Date";
                        //   dr1[1] = Utility.fn_ConvertDate(indate1);
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "DOC Recv";
                        // dr1[1] = dt_retv.Rows[0][6].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "Owner";
                        // dr1[1] = Ownername;
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Sales Person";
                        // dr1[1] = salname;
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Volume ";
                        // dr1[1] = dt_retv.Rows[0]["volume"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Revenue ";
                        //  dr1[1] = dt_retv.Rows[0]["revenue"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "PTC ";
                        // dr1[1] = dt_retv.Rows[0][7].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Phone";
                        //  dr1[1] = dt_retv.Rows[0][8].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "Mobile";
                        //  dr1[1] = dt_retv.Rows[0][9].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "EMail";
                        // dr1[1] = dt_retv.Rows[0][10].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "about";
                        //dr1[1] = dt_retv.Rows[0][15].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "credit days";
                        //  dr1[1] = dt_retv.Rows[0][16].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "credit amt";
                        //  dr1[1] = dt_retv.Rows[0][17].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "credit type";
                        //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][18].ToString());
                        dtapp.Rows.Add(dr1);

                        //dr1 = dtapp.NewRow();
                        //dr1[0] = "OwnerId";
                        //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][19].ToString());
                        //dtapp.Rows.Add(dr1);

                        //dr1 = dtapp.NewRow();
                        //dr1[0] = "SalesId";
                        //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][20].ToString());
                        //dtapp.Rows.Add(dr1);

                        test.DataSource = dtapp;
                        test.DataBind();

                        txtclear();
                        txtappclear();
                        txt_customer.Focus();
                       btnSave.Text = "Save";
                        btnSave.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";

                    }

                    GetAppDetailsNew();
                    btnCancel.Text = "Cancel";
                    btnCancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {

                    Book2.Visible = true;
                    /* category = Convert.ToInt32(dt_retv.Rows[0][1].ToString());
                     String rgdate1 = dt_retv.Rows[0][4].ToString();
                     String indate1 = dt_retv.Rows[0][5].ToString();
                     OwnerId = Convert.ToInt32(dt_retv.Rows[0][19].ToString());

                     SalesId = Convert.ToInt32(dt_retv.Rows[0][20].ToString());
                     hid_sal.Value = SalesId.ToString();
                     Ownername = obj_main.GetShortName(OwnerId);
                     hid_own.Value = OwnerId.ToString();
                     salname = obj_emp.GetEmployeeName(SalesId);*/
                    test.Visible = true;

                    DataTable dtapp = new DataTable();
                    dtapp.Columns.Add("Customer");
                    dtapp.Columns.Add(" Details");
                    DataRow dr1 = dtapp.NewRow();
                    dr1[0] = "PAN #";
                    // dr1[1] = dt_retv.Rows[0][2].ToString();
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "REG #";
                    // dr1[1] = dt_retv.Rows[0][3].ToString();
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "REG Date";
                    //  dr1[1] = Utility.fn_ConvertDate(rgdate1);
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "InCorp Date";
                    //   dr1[1] = Utility.fn_ConvertDate(indate1);
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "DOC Recv";
                    // dr1[1] = dt_retv.Rows[0][6].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "Owner";
                    // dr1[1] = Ownername;
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    // dr1[0] = "Sales Person";
                    dr1[1] = salname;
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "Volume ";
                    // dr1[1] = dt_retv.Rows[0]["volume"].ToString();
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "Revenue ";
                    //  dr1[1] = dt_retv.Rows[0]["revenue"].ToString();
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "PTC ";
                    // dr1[1] = dt_retv.Rows[0][7].ToString();
                    dtapp.Rows.Add(dr1);
                    dr1 = dtapp.NewRow();
                    dr1[0] = "Phone";
                    //  dr1[1] = dt_retv.Rows[0][8].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "Mobile";
                    //  dr1[1] = dt_retv.Rows[0][9].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "EMail";
                    // dr1[1] = dt_retv.Rows[0][10].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "about";
                    //dr1[1] = dt_retv.Rows[0][15].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "credit days";
                    //  dr1[1] = dt_retv.Rows[0][16].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "credit amt";
                    //  dr1[1] = dt_retv.Rows[0][17].ToString();
                    dtapp.Rows.Add(dr1);

                    dr1 = dtapp.NewRow();
                    dr1[0] = "credit type";
                    //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][18].ToString());
                    dtapp.Rows.Add(dr1);

                    //dr1 = dtapp.NewRow();
                    //dr1[0] = "OwnerId";
                    //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][19].ToString());
                    //dtapp.Rows.Add(dr1);

                    //dr1 = dtapp.NewRow();
                    //dr1[0] = "SalesId";
                    //dr1[1] = Convert.ToInt32(dt_retv.Rows[0][20].ToString());
                    //dtapp.Rows.Add(dr1);

                    test.DataSource = dtapp;
                    test.DataBind();

                    txtclear1();
                    txtappclear();
                    txt_customer.Focus();
                    btnSave.Text = "Save";
                    btnSave.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void GetAppDetailsNew()
        {
            try
            {
                int DivsnId = Convert.ToInt16(Session["LoginDivisionId"].ToString());
                DataTable dt_can = new DataTable();
                dt_can = Appro_obj.RetrieveCApprovalDtsNew(groupid, DivsnId);

                if (dt_can.Rows.Count > 0)
                {
                    txt_cano.Text = dt_can.Rows[0][1].ToString();
                    if (txt_cano.Text != "")
                    {
                        btnSave.Text = "Update";
                        btnSave.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";

                    }
                    else
                    {
                        btnSave.Text = "Save";
                        btnSave.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                        txtappclear();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        //protected void sendmail4app()
        //{
        //    mail();
        //    //string str_mailserver = Session["MailServer"].ToString();

        //    //string str_mailuser = Session["MailUser"].ToString();

        //    string str_usermailid = Session["usermailid"].ToString();
        //    string str_mailpwd = Session["usermailpwd"].ToString();

       
        //    DataAccess.Masters.MasterBranch branchobj = new DataAccess.Masters.MasterBranch();

        //    DataTable bmdt = new DataTable();
        //    DataTable rmdt = new DataTable();
        //    DataSet mds;
        //    mds = branchobj.getbmrmid(Convert.ToInt32(hid_own.Value));
        //    string rmmail = "";
        //    Bmmail = "";

        //    if (mds.Tables.Count > 0)
        //    {
        //        bmdt = (DataTable)mds.Tables[0];
        //        rmdt = (DataTable)mds.Tables[1];
        //        if (bmdt.Rows.Count > 0)
        //        {
        //            Bmmail = bmdt.Rows[0]["offmailid"].ToString();
        //        }
        //        if (rmdt.Rows.Count > 0)
        //        {
        //            rmmail = bmdt.Rows[0]["offmailid"].ToString();
        //        }

        //    }

        //    dtsalesuser = obj_emp.GetUsernamefromid(Convert.ToInt32(hid_sal.Value));
        //    if (dtsalesuser.Rows.Count > 0)
        //    {
        //        Salesusername = dtsalesuser.Rows[0]["username"].ToString();
        //    }
        //    dtsalesmail = obj_emp.GetEmployeeDetails(Salesusername);
        //    if (dtsalesmail.Rows.Count > 0)
        //    {
        //        if (string.IsNullOrEmpty(dtsalesmail.Rows[0]["offmailid"].ToString()))
        //        {
        //            salesmail = "";
        //        }
        //        else
        //        {
        //            salesmail = dtsalesmail.Rows[0]["offmailid"].ToString();
        //        }

        //    }
       

        protected void sendmail4app()
        {
            mail();
            //string str_mailserver = Session["MailServer"].ToString();
            string str_usermailid = Session["usermailid"].ToString();
            //string str_mailuser = Session["MailUser"].ToString();
            string str_mailpwd = Session["usermailpwd"].ToString();

            //DataAccess.Masters.MasterBranch branchobj = new DataAccess.Masters.MasterBranch();

            DataTable bmdt = new DataTable();
            DataTable rmdt = new DataTable();
            DataSet mds;
            mds = branchobj.getbmrmid(Convert.ToInt32(hid_own.Value));
            string rmmail = "";
            Bmmail = "";

            if (mds.Tables.Count > 0)
            {
                bmdt = (DataTable)mds.Tables[0];
                rmdt = (DataTable)mds.Tables[1];
                if (bmdt.Rows.Count > 0)
                {
                    Bmmail = bmdt.Rows[0]["offmailid"].ToString();
                }
                if (rmdt.Rows.Count > 0)
                {
                    rmmail = bmdt.Rows[0]["offmailid"].ToString();
                }

            }

            dtsalesuser = obj_emp.GetUsernamefromid(Convert.ToInt32(hid_sal.Value));
            if (dtsalesuser.Rows.Count > 0)
            {
                Salesusername = dtsalesuser.Rows[0]["username"].ToString();
            }
            dtsalesmail = obj_emp.GetEmployeeDetails(Salesusername);
            if (dtsalesmail.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(dtsalesmail.Rows[0]["offmailid"].ToString()))
                {
                    salesmail = "";
                }
                else
                {
                    salesmail = dtsalesmail.Rows[0]["offmailid"].ToString();
                }

            }
            Utility.SendMail(str_usermailid, salesmail, "Credit   Approval", sendqry, "", str_mailpwd, "", Bmmail + ";" + rmmail);
            //sendmail.SendEmail(empmailadd, usermail, "pandi", "Credit   Approval", sendqry, true, str_mailserver, str_usermailid, "", str_mailuser, str_mailpwd, "");
        }

        protected void mail()
        {
            string cont = "";
            string remarks = "";
            string type = "";
            string days = "0";
            string amount = "0";
            string salesname;
            double amt;

            sendqry = "";
            salesname = obj_emp.GetEmployeeName(Convert.ToInt32(hid_sal.Value));

            sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Dear <B>" + salesname + "</B></FONT></td></tr></table><br>";
            sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Your Credit request for the <B>" + txt_customer.Text + "</B> has approved, and find the details below.</FONT></td></tr></table><br>";
            sendqry = sendqry + "<table BORDER=1 CELLPADDING=2 CELLSPACING=0 text=black width=80%><tr><td colspan=3 align = center FontFace = Arial width=40%>Approved</td><td colspan=3 align=center FontFace = Arial width=40% >Applied</td></tr>";

            sendqry = sendqry + "<tr><td align = center FontFace = Arial width=15%>Amount</td><td align=center FontFace = Arial width=10%>Days</td><td align=center FontFace = Arial width=15% >Type</td><td align=center FontFace = Arial width=15%>Amount</td><td align=center FontFace = Arial width=10%>Day</td><td align=center FontFace = Arial width=15%>Type</td></tr>";
            if (ddlApptype.SelectedIndex != -1)
            {
                type = ddlApptype.Text;
            }
            if (ddlApptype.Text != "")
            {
                amt = Convert.ToDouble(txt_approvedAmt.Text);
                amount = amt.ToString("#0.00");
            }

            if (txt_app_days.Text != "")
            {
                days = txt_app_days.Text;
            }
            sendqry = sendqry + "<tr><td align = right FontFace = Tahoma>" + amount + "</td><td align=left FontFace = Tahoma>" + days + "</td><td align=left FontFace = Tahoma>" + type + "  </td><td align=right FontFace = Tahoma> " + txt_approvedAmt.Text + "</td><td align=left FontFace = Tahoma>" + txt_app_days.Text + "</td><td align=left FontFace = Tahoma>" + ddlApptype.Text + "</td></tr>";
            sendqry = sendqry + "</table><br>";
            sendqry = sendqry + "<table><tr><td align=left><FONT FACE=Tahoma SIZE=2>Regards,</FONT></td></tr>";
            sendqry = sendqry + "<tr><td align=left><FONT FACE=Tahoma SIZE=2>" + obj_emp.GetEmployeeName(Convert.ToInt32(Session["LoginEmpId"].ToString())) + "</FONT></td></tr><br><table>";
        }

        //protected void mail()
        //{
        //    string cont = "";
        //    string remarks = "";
        //    string type = "";
        //    string days = "0";
        //    string amount = "0";
        //    string salesname;
        //    double amt;

        //    sendqry = "";
        //    salesname = obj_emp.GetEmployeeName(Convert.ToInt32(hid_sal.Value));

        //    sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Dear <B>" + salesname + "</B></FONT></td></tr></table><br>";
        //    sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Your Credit request for the <B>" + txt_customer.Text + "</B> has approved, and find the details below.</FONT></td></tr></table><br>";
        //    sendqry = sendqry + "<table BORDER=1 CELLPADDING=2 CELLSPACING=0 text=black width=80%><tr><td colspan=3 align = center FontFace = Arial width=40%>Approved</td><td colspan=3 align=center FontFace = Arial width=40% >Applied</td></tr>";

        //    sendqry = sendqry + "<tr><td align = center FontFace = Arial width=15%>Amount</td><td align=center FontFace = Arial width=10%>Days</td><td align=center FontFace = Arial width=15% >Type</td><td align=center FontFace = Arial width=15%>Amount</td><td align=center FontFace = Arial width=10%>Day</td><td align=center FontFace = Arial width=15%>Type</td></tr>";
        //    if (ddlApptype.SelectedIndex != -1)
        //    {
        //        type = ddlApptype.Text;
        //    }
        //    if (ddlApptype.Text != "")
        //    {
        //        amt = Convert.ToDouble(txt_approvedAmt.Text);
        //        amount = amt.ToString("#0.00");
        //    }

        //    if (txt_app_days.Text != "")
        //    {
        //        days = txt_app_days.Text;
        //    }
        //    sendqry = sendqry + "<tr><td align = right FontFace = Tahoma>" + amount + "</td><td align=left FontFace = Tahoma>" + days + "</td><td align=left FontFace = Tahoma>" + type + "  </td><td align=right FontFace = Tahoma> " + txt_approvedAmt.Text + "</td><td align=left FontFace = Tahoma>" + txt_app_days.Text + "</td><td align=left FontFace = Tahoma>" + ddlApptype.Text + "</td></tr>";
        //    sendqry = sendqry + "</table><br>";
        //    sendqry = sendqry + "<table><tr><td align=left><FONT FACE=Tahoma SIZE=2>Regards,</FONT></td></tr>";
        //    sendqry = sendqry + "<tr><td align=left><FONT FACE=Tahoma SIZE=2>" + obj_emp.GetEmployeeName(Convert.ToInt32(Session["LoginEmpId"].ToString())) + "</FONT></td></tr><br><table>";
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() != "CO")
                    {
                        if (ddl_product.SelectedIndex == 0)
                        {
                            ddl_product.SelectedValue = "Air Exports";
                            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                            //// blnerr = true;
                            //ddl_product.Focus();
                            //return;
                        }
                    }
                }
                intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int EmpId = Convert.ToInt32(Session["LoginEmpId"].ToString());
                groupid = Convert.ToInt32(hdf_cusid.Value.ToString());
                //GetLimitCheck();
                //    if(back==1)
                //    {
                //        return;
                //    }
                CollectData();
                if (apptype != 1 && apptype != 2)
                {
                    apptype = 1;
                }
                //if (apptype != 1 && apptype != 2)
                //{
                //    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('select Approval Type');", true);
                //    return;
                //}
                //if (exmode == "")
                //{
                //    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('select Period Type');", true);
                //    return;
                //}
                String strDate = Utility.fn_ConvertDate(txt_credit_reqon.Text.Trim());
                //String strDate1 = Utility.fn_ConvertDate(strDate);
                DateTime date = Convert.ToDateTime(strDate);
                int exp = Convert.ToInt32(txt_exemptions.Text);
                int due = Convert.ToInt32(txt_overdue.Text);
                if (txt_approvedAmt.Text == "")
                {
                    txt_approvedAmt.Text = "0";
                }
                if (txt_app_days.Text == "")
                {
                    txt_app_days.Text = "0";
                }

                if (btnSave.ToolTip == "Save")
                {
                    if (groupid != 0)
                    {
                        txt_cano.Text = Appro_obj.UpdMasterCAppNew(groupid, txt_cano.Text, date, 0, 0, 0, ' ', 0, 0, 0, ' ', 0, 0, 0, ' ', EmpId, Convert.ToDouble(txt_approvedAmt.Text), Convert.ToInt32(txt_app_days.Text), apptype, intDivID);
                        Appro_obj.UpdMasterCreditApprovalCUSTLIMITS(groupid, intBranchID, intDivID, exp, due, exmode);
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Credit Approval :" + txt_cano.Text + " is Inserted');", true);
                       btnSave.Text = "Update";
                        btnSave.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";

                        btnCancel.Text = "Cancel";
                        btnCancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                        sendmail4app();
                        //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1731, 1, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "Limit :" + txt_exemptions.Text + "ExMode:" + ddl_per.Text + "Over Due:" + txt_overdue.Text + "%" + "/ S");
                        //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 1, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ S");

                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 986, 1, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ S");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 987, 1, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ S");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 988, 1, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ S");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 989, 1, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ S");
                                break;
                            case "MI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 1, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ S");
                                break;
                        }

                    }
                }
                else if (btnSave.ToolTip == "Update")
                {
                    if (groupid != 0)
                    {
                        txt_cano.Text = Appro_obj.UpdMasterCAppNew(groupid, txt_cano.Text, date, 0, 0, 0, ' ', 0, 0, 0, ' ', 0, 0, 0, ' ', EmpId, Convert.ToDouble(txt_approvedAmt.Text), Convert.ToInt32(txt_app_days.Text), apptype, intDivID);
                        Appro_obj.UpdMasterCreditApprovalCUSTLIMITS(groupid, intBranchID, intDivID, exp, due, exmode);
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Credit Approval:" + txt_cano.Text + " is Updated');", true);
                        //sendmail4app();
                        btnSave.Text = "Save";
                        btnSave.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";

                        btnCancel.Text = "Cancel";
                        btnCancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                        //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1731, 2, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "Limit :" + txt_exemptions.Text + "ExMode:" + ddl_per.Text + "Over Due:" + txt_overdue.Text + "%" + "/ U");
                        //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 2, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 986, 2, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 987, 2, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 988, 2, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 989, 2, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/  U");
                                break;
                            case "MI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 2, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/  U");
                                break;
                        }

                    }
                }
                int appdays = 0, exmp = 0, ovrdue = 0;
                decimal appamt = 0; string exmpmode = "";

                foreach (GridViewRow row in Gridcreditreq.Rows)
                {

                    int txtdays = Convert.ToInt32(((TextBox)Gridcreditreq.Rows[row.RowIndex].FindControl("txt_AppDays")).Text);
                    if (txtdays != null)
                    {
                        appdays = (txtdays);
                    }
                    else
                    {
                        appdays = 0;
                    }
                    decimal txtamt = Convert.ToDecimal(((TextBox)Gridcreditreq.Rows[row.RowIndex].FindControl("txt_AppAmount")).Text);
                    if (txtamt != null)
                    {
                        appamt = (txtamt);
                    }
                    else
                    {
                        appamt = 0;
                    }
                    int txtexmp = Convert.ToInt32(((TextBox)Gridcreditreq.Rows[row.RowIndex].FindControl("txt_Exemptions")).Text);
                    if (txtexmp != null)
                    {
                        exmp = (txtexmp);
                    }
                    else
                    {
                        exmp = 0;
                    }
                    int txtovrdue = Convert.ToInt32(((TextBox)Gridcreditreq.Rows[row.RowIndex].FindControl("txt_Overdue")).Text);
                    if (txtovrdue != null)
                    {
                        ovrdue = (txtovrdue);
                    }
                    else
                    {
                        ovrdue = 0;
                    }
                    string txtempmode = ((DropDownList)Gridcreditreq.Rows[row.RowIndex].FindControl("ddl_exemption")).Text;
                    if (txtempmode != null)
                    {
                        exmpmode = (txtempmode);
                        if (exmpmode == "1")
                        {
                            exmpmode = "M";
                        }
                        if (exmpmode == "2")
                        {
                            exmpmode = "A";
                        }
                    }
                    else
                    {
                        exmpmode = "";
                    }

                    if (Gridcreditreq.Rows[row.RowIndex].Cells[11].Text != "&nbsp;")
                    {
                        hid_crid.Value = Gridcreditreq.Rows[row.RowIndex].Cells[11].Text;
                        if (hid_crid.Value != "")
                        {
                            Appro_obj.UpdMasterCreditAppDetailsNew(groupid, Convert.ToInt32(hid_crid.Value), appdays, Convert.ToDecimal(appamt), Convert.ToInt32(Session["LoginEmpId"]), exmp, exmpmode, ovrdue);

                        }
                    }

                }

                txtclear();
                txtappclear();
                Gridcreditreq.DataSource = Utility.Fn_GetEmptyDataTable();
                Gridcreditreq.DataBind();
                 btnCancel.Text = "Back";
                btnCancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                btnSave.Text = "Save";
                btnSave.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void GetLimitCheck()
        {
            try
            {
                DataTable dt2 = new DataTable();
                int EmpId = Convert.ToInt32(Session["LoginEmpId"].ToString());

                dt2 = Appro_obj.GetAmountLmt4CrdtApp(intowner, intDivID, intBranchID, 0);

                if (dt2.Rows.Count > 0)
                {
                    AmtLmt = Convert.ToDouble(dt2.Rows[0][0].ToString());
                    DayLmt = Convert.ToInt32(dt2.Rows[0][1].ToString());

                    if (AmtLmt < (Convert.ToDouble(txt_approvedAmt.Text.Trim())))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('Approved Amount Should Not Exceed');", true);
                        txt_approvedAmt.Text = "";
                        txt_approvedAmt.Focus();
                        back = 1;
                        return;
                    }

                    if (DayLmt < (Convert.ToDouble(txt_app_days.Text.Trim())))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('Approved Days Should Not Exceed');", true);
                        txt_app_days.Text = "";
                        txt_app_days.Focus();
                        back = 1;
                        return;
                    }
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('Limit not set for you in');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.ToolTip == "Cancel")
            {
                // CheckPending_CheckedChanged(sender, e);
                AllClear();
                ddl_product.SelectedValue = "0";
                ddlBranch.SelectedValue = "0";
                //txt_exemptions.Text = "";
                intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                BranchLoad();
                GetDetails();
                if (intBranchID != 40 && intBranchID != 51 && intBranchID != 52 && intBranchID != 62)
                {
                    txtappclear();
                }
                else
                {
                    AllClear();
                    btnSave.Enabled = true;
                    btnSave.ForeColor = System.Drawing.Color.White;

                }
                Gridcreditreq.DataSource = Utility.Fn_GetEmptyDataTable();
                Gridcreditreq.DataBind();
                CheckPending.Checked = false;
                 btnCancel.Text = "Back";
                btnCancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                btnSave.Text = "Save";
                btnSave.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";

                if (intDivID == 1 || intDivID == 7)
                {
                    txt_exemptions.Text = "1";
                }
                else
                {
                    txt_exemptions.Text = "3";
                }
                if (Session["StrTranType"].ToString() == "CO")
                {
                    AllClear1();
                    ClearAmt();
                }
                //if (Session["StrTranType"].ToString() == "CO")
                //{
                //    txt_branch.Text = "";
                //    txt_dsodays.Text = "";
                //    txt_invoiceAmt.Text = "";
                //    txt_Avg.Text = "";
                //    txt_AppCrdtAmt.Text = "";
                //    txt_actOutstanding.Text = "";
                //    txt_less.Text = "";
                //    txt_actual_dsodays.Text = "";
                //}
            }
            else
            {

                if (Session["home"] != null)
                {
                    if (Session["StrTranType"] != null)
                    {
                        if (Session["StrTranType"].ToString() == "CO")
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
                        }
                        else if (Session["home"].ToString() == "MIS")
                        {
                            Response.Redirect("../Home/MISAndApproval.aspx");
                        }
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

        private void AllClear()
        {
            intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int EmpId = Convert.ToInt32(Session["LoginEmpId"].ToString());
            txt_customer.Text = "";
            //txt_cusdetails.Text = "";
            //txt_textarea.Text = "";
            //txt_docreceived.Text = "";
            //txt_ptc.Text = "";
            //txt_about.Text = "";
            //txt_category.Text = "";
            //txt_creditdays.Text = "";
            //txt_credittype.Text = "";
            //txt_creditamt.Text = "";
            txt_cano.Text = "";
            txt_credit_reqon.Text = "";
            txt_approvedBy.Text = "";
            txt_approvedAmt.Text = "";
            txt_app_days.Text = "";
            ddlApptype.SelectedIndex = 0;
            hdf_cusid.Value = "";
            footerRowVisible();
            txt_approvedBy.Text = obj_emp.GetEmployeeName(EmpId);
            Book2.Visible = true;
            lbl_crmt.Text = "";
            // txt_overdue.Text = "";
            //   txt_exemptions.Text = "";
            //ddl_per.SelectedIndex = 1;
            //ddl_product.SelectedValue = "0";

            if (intBranchID == 7)
            {
                if (ddl_per.Enabled == true)
                {
                    ddl_per.SelectedIndex = 0;
                }
                else
                {
                    ddl_per.SelectedIndex = 0;//1
                }
            }
            else
            {
                ddl_per.SelectedIndex = 0;//1
            }

        }

        private void AllClear1()
        {
            intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int EmpId = Convert.ToInt32(Session["LoginEmpId"].ToString());
            txt_customer.Text = "";
            //txt_branch.Text = "";
            ddlBranch.SelectedIndex = 0;
            txt_cano.Text = "";
            txt_credit_reqon.Text = "";
            txt_approvedBy.Text = "";
            txt_approvedAmt.Text = "";
            txt_app_days.Text = "";
            ddlApptype.SelectedIndex = 0;
            hdf_cusid.Value = "";
            footerRowVisible();
            txt_approvedBy.Text = obj_emp.GetEmployeeName(EmpId);
            Book2.Visible = true;
            // txt_overdue.Text = "";
            // txt_exemptions.Text = "";
            // ddl_per.SelectedIndex = 1;
            ddl_product.SelectedValue = "0";
            if (intBranchID == 7)
            {
                if (ddl_per.Enabled == true)
                {
                    ddl_per.SelectedIndex = 0;
                }
                else
                {
                    ddl_per.SelectedIndex = 0;//1
                }
            }
            else
            {
                ddl_per.SelectedIndex = 0;//1
            }
        }

        private void footerRowVisible()
        {
            ddlFootrCFO.Visible = false;
            ddlFootrCoO.Visible = false;
            ddlFootrMD.Visible = false;

            txtcfoappdays.Visible = false;
            txtcooappdays.Visible = false;
            txtmdappdays.Visible = false;

            txtcfoappamt.Visible = false;
            txtcooappamt.Visible = false;
            txtmdappamt.Visible = false;

            txtcfoexempted.Visible = false;
            txtcooexempted.Visible = false;
            txtmdexempted.Visible = false;

            cmbcfoapptype.Visible = false;
            cmbcooapptype.Visible = false;
            cmbmdapptype.Visible = false;

        }

        protected void GrdCreditAmt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {

                e.Row.Cells[0].Text = "" + ((((GridView)sender).PageIndex * ((GridView)sender).PageSize) + (e.Row.RowIndex + 1));

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //((DropDownList)grd.Rows[i].FindControl("ddlAn")).SelectedItem.Text = "LOP";
                Label total = (Label)e.Row.FindControl("customername");

                if (total.Text == "Total")
                {

                    e.Row.ForeColor = System.Drawing.Color.Brown;

                }
                else
                    if (e.Row.Cells[5].Text != "Total")
                    {
                        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdCreditAmt, "Select$" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";
                    }

            }

        }

        protected void Grdcustomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {

                e.Row.Cells[0].Text = "" + ((((GridView)sender).PageIndex * ((GridView)sender).PageSize) + (e.Row.RowIndex + 1));

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grdcustomer, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
        }

        protected void GrdCancel_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {

                e.Row.Cells[0].Text = "" + ((((GridView)sender).PageIndex * ((GridView)sender).PageSize) + (e.Row.RowIndex + 1));

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdCancel, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";

            }
        }

        protected void btncrdtcncl_Click(object sender, EventArgs e)
        {
            try
            {

                intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int EmpId = Convert.ToInt32(Session["LoginEmpId"].ToString());
                DataTable dtview = new DataTable();

                if (GrdCancel.Rows.Count > 0)
                {
                    for (int i = 0; i <= GrdCancel.Rows.Count - 1; i++)
                    {
                        CheckBox chkRow = (GrdCancel.Rows[i].Cells[7].FindControl("cbSelect") as CheckBox);

                        if (chkRow.Checked == true)
                        {
                            int customerid = Convert.ToInt32(GrdCancel.Rows[i].Cells[6].Text);
                            int cdays = Convert.ToInt32(GrdCancel.Rows[i].Cells[4].Text);
                            Double amt = Convert.ToDouble(GrdCancel.Rows[i].Cells[5].Text);

                            Appro_obj.updCancelcreditrequest(intBranchID, customerid);
                            Appro_obj.InsCreditCancel(customerid, cdays, amt, Convert.ToDateTime(Logobj.GetDate().ToShortDateString()), EmpId, intBranchID);
                            strrow = true;
                        }
                    }

                    if (Convert.ToBoolean(strrow) == false)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('No Rows Selected');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('Credit Cancelled');", true);
                        // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ Credit Cancelled");

                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 986, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ Credit Cancelled");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 987, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ Credit Cancelled");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 988, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ Credit Cancelled");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 989, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ Credit Cancelled");
                                break;
                            case "MI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ Credit Cancelled");
                                break;
                        }

                    }

                    dtview = Appro_obj.GetApprovedListgrd(intBranchID);
                    if (dtview.Rows.Count > 0)
                    {
                        this.programmaticModalCancelCredit.Show();
                        GrdCancel.DataSource = dtview;
                        GrdCancel.DataBind();
                    }

                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void GrdCancel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CheckBox chkRow = (GrdCancel.Rows[0].Cells[7].FindControl("cbSelect") as CheckBox);

            //if (chkRow.Checked == true)
            //{
            //    Button1_Click(sender, e);
            //}

        }

        protected void CheckPending_CheckedChanged(object sender, EventArgs e)
        {
            txtappclear();
            // Session["VSSsnap"] = CheckPending.Checked;
            //   string vss = Session["VSSsnap"].ToString();
            AllClear();
            GetDetails();
            if (ddlBranch.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(customerlink, typeof(Button), "Master Approval", "alertify.alert('Please Select Branch Name');", true);
                CheckPending.Checked = false;
                ddlBranch.Focus();
                return;
            }
            if (hid_branchid.Value != "")
            {
                intBranchID = Convert.ToInt32(hid_branchid.Value);
            }
            else
            {
                intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
            }

            if (txt_dsodays.Text.Trim() != "")
            {
                if ((Convert.ToInt32(txt_dsodays.Text.Trim())) < Convert.ToDouble(hid_availCrdtDay.Value) || Convert.ToDouble(hid_availCrdtDay.Value) == 0)
                {
                    btnSave.Enabled = false;

                    txt_actual_dsodays.ForeColor = Color.Red;
                    id_txt_actual_dsodays.Attributes["class"] = "custom-col custom-mr-05";
                    btnSave.ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    btnSave.Enabled = true;
                    btnSave.ForeColor = System.Drawing.Color.White;
                    txt_actual_dsodays.ForeColor = Color.Black;
                    id_txt_actual_dsodays.Attributes["class"] = "custom-col custom-mr-05";
                }
            }

            btnCancel.Text = "Back";
            btnCancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
            btnSave.Text = "Save";
            btnSave.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";

        }

        protected void img_delete_Click(object sender, ImageClickEventArgs e)
        {

            intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int EmpId = Convert.ToInt32(Session["LoginEmpId"].ToString());
            DataTable dtdel = new DataTable();
            int cdays;
            Double amt;
            int cid;

            cdays = Convert.ToInt32(GrdCancel.Rows[0].Cells[4].Text);
            amt = Convert.ToDouble(GrdCancel.Rows[0].Cells[5].Text);
            cid = Convert.ToInt32(GrdCancel.Rows[0].Cells[6].Text.ToString());

            if (cdays != 0 && amt != 0 && cid != 0)
            {
                Appro_obj.updCancelcreditrequest(intBranchID, cid);
                Appro_obj.InsCreditCancel(cid, cdays, amt, Convert.ToDateTime(Logobj.GetDate().ToShortDateString()), EmpId, intBranchID);
                strrow = true;
            }

            if (Convert.ToBoolean(strrow) == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('No Rows Selected');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('Credit Cancelled');", true);
            }

            dtdel = Appro_obj.GetApprovedListgrd(intBranchID);
            if (dtdel.Rows.Count > 0)
            {
                this.programmaticModalCancelCredit.Show();
                GrdCancel.DataSource = dtdel;
                GrdCancel.DataBind();
            }

        }

        protected void txt_textarea_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnview_Click(object sender, EventArgs e)
        {

            if (Session["LoginBranchid"] == 40.ToString() || Session["LoginBranchid"] == 51.ToString() || Session["LoginBranchid"] == 52.ToString() || Session["LoginBranchid"] == 62.ToString())
            {
                if (txt_cano.Text == "")
                {
                    if (CheckPending.Checked == true)
                    {
                        string str_sp = "";
                        string str_sf = "";
                        string str_RptName = "";
                        string str_Script = "";
                        Session["str_sfs"] = "";
                        Session["str_sp"] = "";
                        //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                        str_RptName = "MasterCreditApproval.rpt";
                        str_sp = "Title= UnApproved Credit Request";
                        Session["str_sp"] = "Title= UnApproved Credit Request";
                        Session["str_sfs"] = "isnull({MasterCreditApproval.appon}) and {MasterCreditApproval.division}=" + Session["LoginDivisionId"];
                        str_sf = "isnull({MasterCreditApproval.appon}) and {MasterCreditApproval.division}=" + Session["LoginDivisionId"];
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(Login.logempid, 986, 3, Login.branchid, "/GroupID: " & groupid & "/ Ca #: " & txtcano.Text & "/ S");
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Booking", str_Script, true);
                        //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 2, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 986, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ V");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 987, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ V");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 988, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ V");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 989, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ V");
                                break;
                            case "MI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ V");
                                break;
                        }

                    }
                    else
                    {
                        string str_sp = "";
                        string str_sf = "";
                        string str_RptName = "";
                        string str_Script = "";
                        Session["str_sfs"] = "";
                        Session["str_sp"] = "";
                        //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                        str_RptName = "MasterCreditApproval.rpt";
                        str_sp = "Title= Approved Credit Request";
                        Session["str_sp"] = "Title= Approved Credit Request";
                        Session["str_sfs"] = "not isnull({MasterCreditApproval.appon}) and {MasterCreditApproval.division}=" + Session["LoginDivisionId"];
                        str_sf = "not isnull({MasterCreditApproval.appon}) and {MasterCreditApproval.division}=" + Session["LoginDivisionId"];
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(Login.logempid, 986, 3, Login.branchid, "/GroupID: " & groupid & "/ Ca #: " & txtcano.Text & "/ S");
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Booking", str_Script, true);
                        // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 2, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");

                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 986, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 987, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 988, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 989, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                                break;
                            case "MI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                                break;
                        }

                    }
                }
                else
                {
                    string str_sp = "";
                    string str_sf = "";
                    string str_RptName = "";
                    string str_Script = "";
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                    str_RptName = "MasterCreditApproval.rpt";
                    str_sp = "Title= Approved Credit Request";
                    Session["str_sp"] = "Title= Approved Credit Request";
                    Session["str_sfs"] = "{MasterCreditApproval.can}='" + txt_cano.Text + "'";
                    str_sf = "{MasterCreditApproval.can}=" + txt_cano.Text + "";
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(Login.logempid, 986, 3, Login.branchid, "/GroupID: " & groupid & "/ Ca #: " & txtcano.Text & "/ S");
                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Booking", str_Script, true);
                    // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 2, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                    switch (Session["StrTranType"].ToString())
                    {
                        case "FE":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 986, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                            break;
                        case "FI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 987, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                            break;
                        case "AE":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 988, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                            break;
                        case "AI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 989, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                            break;
                        case "MI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                            break;
                    }

                }
            }
            else
            {
                if (txt_cano.Text == "")
                {
                    if (CheckPending.Checked == true)
                    {
                        string str_sp = "";
                        string str_sf = "";
                        string str_RptName = "";
                        string str_Script = "";
                        Session["str_sfs"] = "";
                        Session["str_sp"] = "";
                      //  DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                        str_RptName = "MasterCreditApproval.rpt";
                        str_sp = "Title= UnApproved Credit Request";
                        Session["str_sp"] = "Title= UnApproved Credit Request";
                        Session["str_sfs"] = "isnull({MasterCreditApproval.appon}) and {MasterCreditApproval.division}=" + Session["LoginDivisionId"]; //+ " and {MasterCreditApproval.owner}=" + Session["LoginBranchid"];
                        str_sf = "isnull({MasterCreditApproval.appon}) and {MasterCreditApproval.division}=" + Session["LoginDivisionId"]; //+ " and {MasterCreditApproval.owner}=" + Session["LoginBranchid"];
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(Login.logempid, 986, 3, Login.branchid, "/GroupID: " & groupid & "/ Ca #: " & txtcano.Text & "/ S");
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Booking", str_Script, true);
                        // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 2, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");

                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 986, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/V");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 987, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/V");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 988, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/V");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 989, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ V");
                                break;
                            case "MI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ V");
                                break;
                        }

                    }
                    else
                    {
                        string str_sp = "";
                        string str_sf = "";
                        string str_RptName = "";
                        string str_Script = "";
                        Session["str_sfs"] = "";
                        Session["str_sp"] = "";
                       // DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                        str_RptName = "MasterCreditApproval.rpt";
                        str_sp = "Title= Approved Credit Request";
                        Session["str_sp"] = "Title= Approved Credit Request";
                        Session["str_sfs"] = "not isnull({MasterCreditApproval.appon}) and {MasterCreditApproval.division}=" + Session["LoginDivisionId"];  //"not isnull({MasterCreditApproval.appon}) and {MasterCreditApproval.division}=" + Session["LoginDivisionId"] + " and {MasterCreditApproval.owner}=" + Session["LoginBranchid"];
                        str_sf = "not isnull({MasterCreditApproval.appon}) and {MasterCreditApproval.division}=" + Session["LoginDivisionId"];  //"not isnull({MasterCreditApproval.appon}) and {MasterCreditApproval.division}=" + Session["LoginDivisionId"] + " and {MasterCreditApproval.owner}=" + Session["LoginBranchid"];
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(Login.logempid, 986, 3, Login.branchid, "/GroupID: " & groupid & "/ Ca #: " & txtcano.Text & "/ S");
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Booking", str_Script, true);
                        // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 2, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");
                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 986, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/V");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 987, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/V");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 988, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/V");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 989, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ V");
                                break;
                            case "MI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ V");
                                break;
                        }

                    }
                }
                else
                {
                    string str_sp = "";
                    string str_sf = "";
                    string str_RptName = "";
                    string str_Script = "";
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                  //  DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                    str_RptName = "MasterCreditApproval.rpt";
                    str_sp = "Title= Approved Credit Request";
                    Session["str_sp"] = "Title= Approved Credit Request";
                    Session["str_sfs"] = "{MasterCreditApproval.can}='" + txt_cano.Text + "'";// + " and {MasterCreditApproval.owner}=" + Session["LoginBranchid"];
                    str_sf = "{MasterCreditApproval.can}=" + txt_cano.Text + ""; // + " and {MasterCreditApproval.owner}=" + Session["LoginBranchid"];
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(Login.logempid, 986, 3, Login.branchid, "/GroupID: " & groupid & "/ Ca #: " & txtcano.Text & "/ S");
                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Booking", str_Script, true);
                    // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 2, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ U");

                    switch (Session["StrTranType"].ToString())
                    {
                        case "FE":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 986, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/V");
                            break;
                        case "FI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 987, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/V");
                            break;
                        case "AE":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 988, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/V");
                            break;
                        case "AI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 989, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ V");
                            break;
                        case "MI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 422, 3, Convert.ToInt32(Session["LoginBranchid"]), "/GroupID: " + groupid + "/ Ca #: " + txt_cano.Text + "/ V");
                            break;
                    }

                }
            }
        }

        protected void Grdcustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = 0;
                if (Grdcustomer.Rows.Count > 0)
                {
                    index = Grdcustomer.SelectedRow.RowIndex;
                    txt_customer.Text = ((Label)Grdcustomer.Rows[index].Cells[2].FindControl("groupname")).Text;
                    hdf_cusid.Value = Grdcustomer.Rows[index].Cells[8].Text;
                    groupid = Convert.ToInt32(hdf_cusid.Value);

                    GetDetails();
                    grdcreditrequest();// ADD
                    txt_approvedAmt.Focus();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void GrdCancel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Panel5.Visible = true;
            GrdCancel.PageIndex = e.NewPageIndex;
            DataTable dt = (DataTable)ViewState["GrdCancel"];
            this.programmaticModalCancelCredit.Show();
            GrdCancel.DataSource = dt;
            GrdCancel.DataBind();

            //intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());

            //DataTable dtCancel = new DataTable();
            //dtCancel = Appro_obj.GetApprovedListgrd(intBranchID);

            //if (dtCancel.Rows.Count > 0)
            //{
            //    this.programmaticModalCancelCredit.Show();
            //    GrdCancel.DataSource = dtCancel;
            //    GrdCancel.DataBind();
            //}
            //Panel5.Visible = true;
        }

        protected void GrdCreditAmt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdCreditAmt.PageIndex = e.NewPageIndex;
            intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());

            Double TotalACAmt = 0;

            DataTable dt_CrdAmt = new DataTable();
            //DataRow dr = dt_CrdAmt.NewRow();

            dt_CrdAmt.Columns.Add("salesperson");
            dt_CrdAmt.Columns.Add("branch");
            dt_CrdAmt.Columns.Add("customername");
            dt_CrdAmt.Columns.Add("appamt");
            dt_CrdAmt.Columns.Add("employeeid");
            dt_CrdAmt.Columns.Add("bid");
            dt_CrdAmt.Columns.Add("divid");
            DataRow dr;
            dr = dt_CrdAmt.NewRow();
            dt_CrdAmt = obj_CRApp.GetCrdtAmtLimitEmpwise(intBranchID, intDivID);

            if (dt_CrdAmt.Rows.Count > 0)
            {
                this.programmaticModalPopup.Show();

                dr = dt_CrdAmt.NewRow();
                var Total_Income = TotalACAmt.ToString() + dt_CrdAmt.Rows[0]["appamt"];
                dr[2] = "Total";
                dr[3] = string.Format("{0:0.00}", Total_Income);
                dt_CrdAmt.Rows.Add(dr);

                GrdCreditAmt.DataSource = dt_CrdAmt;
                GrdCreditAmt.DataBind();

                GrdCreditAmt.Visible = true;
            }

            Panel4.Visible = true;
        }

        //protected void FillAmt()
        //{
        //    Double AvgAmt, LessAmt;
        //    Dt_GetDet = crdtObj.GetCrdtAppLimitDetails(intBranchID, intDivID, DsoDays);
        //    if (Dt_GetDet.Rows.Count>0)
        //    {
        //         txt_invoiceAmt.Text = string.Format("{0:0.00}", Dt_GetDet.Rows[0]["TotInvAmt"]);
        //         txt_AppCrdtAmt.Text = string.Format("{0:0.00}", Dt_GetDet.Rows[0]["CrdtAmt"]);
        //         txt_actOutstanding.Text =  string.Format("{0:0.00}", Dt_GetDet.Rows[0]["OSAmt"]); 
        //    txt_dsodays.Text =Convert.ToString( DsoDays);
        //        txt_Avg.Text =  string.Format("{0:0.00}", Dt_GetDet.Rows[0]["TotInvAmt"]);
        //        AvgAmt = Convert.ToDouble (Convert.ToInt32(Dt_GetDet.Rows[0]["TotInvAmt"]) / 30);

        //        txt_less.Text = txt_actOutstanding.Text;

        //        if (Convert.ToDouble(txt_less.Text) <= 0 || Convert.ToDouble(txt_Avg.Text) <= 0)
        //        {
        //            availCrdtDay = 0;
        //        }
        //        else 
        //        {
        //            availCrdtDay = Convert.ToDouble (txt_less.Text) / AvgAmt;
        //        }

        //        txt_AppCrdtAmt.Text = availCrdtDay.ToString();

        //        if (Convert.ToDouble(txt_dsodays.Text) < availCrdtDay || availCrdtDay == 0)
        //        {
        //            btnSave.Enabled = false;
        //        }
        //        else
        //        {
        //            btnSave.Enabled = true;

        //        }
        //    }
        //}

        /* protected void txt_branch_TextChanged(object sender, EventArgs e)
         {
             if (txt_branch.Text != "")
             {
                 intDivID = Convert.ToInt32(Session["LoginDivisionId"]);

                 Dt = crdtObj.GetLikeBranchName(intDivID, (txt_branch.Text.Trim()));

                 if (Dt.Rows.Count > 0)
                 {
                     intBranchID = Convert.ToInt32(Dt.Rows[0]["branchid"]);
                     hid_branchid.Value = intBranchID.ToString();
                     BranchSName = Convert.ToString(Dt.Rows[0]["portname"]);
                     DsoDays = Convert.ToInt32(Dt.Rows[0]["dsodays"]);
                     txt_branch.Text = BranchSName;
                     FillAmt();
                     txt_customer.Focus();
                 }

                 else
                 {
                     ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('Please Enter Correct Branch Name');", true);
                     txt_branch.Text = "";
                     ClearAmt();
                     txt_branch.Focus();
                 }
             }
             else
             {
                 ClearAmt();
             }
         }*/

        public void branch()
        {
            if (ddlBranch.SelectedItem.Text != "")
            {
                intDivID = Convert.ToInt32(Session["LoginDivisionId"]);

                Dt = crdtObj.GetLikeBranchName(intDivID, (ddlBranch.SelectedItem.Text.Trim()));

                if (Dt.Rows.Count > 0)
                {
                    intBranchID = Convert.ToInt32(Dt.Rows[0]["branchid"]);
                    Session["BRANCHID"] = intBranchID;
                    hid_branchid.Value = intBranchID.ToString();
                    BranchSName = Convert.ToString(Dt.Rows[0]["portname"]);
                    DsoDays = Convert.ToInt32(Dt.Rows[0]["dsodays"]);
                    ddlBranch.SelectedItem.Text = BranchSName;
                    FillAmt();
                    txt_customer.Focus();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('Please Enter Correct Branch Name');", true);
                    ddlBranch.SelectedIndex = 0;
                    ClearAmt();
                    ddlBranch.Focus();
                }
            }
            else
            {
                ClearAmt();
            }
        }
        protected void txt_overdue_TextChanged(object sender, EventArgs e)
        {
            int due = Convert.ToInt32(txt_overdue.Text);
            if (due >= 100 && due != 100)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('Overdue is Less Then 100');", true);
                txt_overdue.Text = "";
                txt_overdue.Focus();
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            branch();
        }

        protected void test_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //   // e.Row.Cells[17].HorizontalAlign = HorizontalAlign.Right;
            //     e.Row.Cells[17].Attributes.CssStyle["text-align"] = "Right";
            //}

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
            Panel3.Visible = true;

            DataTable obj_dtlogdetails = new DataTable();

            switch (Session["StrTranType"].ToString())
            {
                case "FE":
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 986, "Credreq", hdf_cusid.Value, hdf_cusid.Value, "");
                    break;
                case "FI":
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 987, "Credreq", hdf_cusid.Value, hdf_cusid.Value, "");
                    break;
                case "AE":
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 988, "Credreq", hdf_cusid.Value, hdf_cusid.Value, "");
                    break;
                case "AI":
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 989, "Credreq", hdf_cusid.Value, hdf_cusid.Value, "");
                    break;
                case "MI":
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 422, "Credreq", hdf_cusid.Value, hdf_cusid.Value, "");
                    break;
            }

            //"/Rate ID: " +
            if (txt_customer.Text != "")
            {
                JobInput.Text = txt_customer.Text;

            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }
        protected void Gridcreditreq_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtgrid1 = new DataTable();
            int RowIndex = Gridcreditreq.SelectedRow.RowIndex;
            if (Gridcreditreq.Rows[RowIndex].Cells[4].Text != null)
            {
                for (int i = 0; i <= Gridcreditreq.Rows.Count - 1; i++)
                {

                    TextBox txtvale = ((TextBox)Gridcreditreq.Rows[i].FindControl("txt_AppDays"));

                    if (txtvale.Text == "" || txtvale == null)
                    {
                        txtvale.Text = "0";
                    }
                    if (txtvale.Text != "" || txtvale.Text != null)
                    {
                        //  rowIndex = Convert.ToInt32(e.CommandArgument);
                        TextBox txt1 = ((TextBox)Gridcreditreq.Rows[RowIndex].FindControl("txt_AppDays"));
                        //string value = txt1.Text;
                        if (txt1.Text == "0")
                        {
                            txt1.Text = "";
                            txt1.Focus();
                        }
                        else
                        {
                            txt1.Focus();
                        }
                    }
                }
            }

            //DataTable dtgrid1 = new DataTable();
            //int RowIndex = Gridcreditreq.SelectedRow.RowIndex;
            //if (Gridcreditreq.Rows[RowIndex].Cells[4].Text != null)
            //{
            //       TextBox TxtAmount = ((TextBox)Gridcreditreq.Rows[RowIndex].FindControl("txt_receiptamount"));

            //        if (TxtAmount.Text == "")
            //        {
            //            TxtAmount.Text = "0.00";
            //        }
            //        if (Convert.ToDouble(Gridcreditreq.Rows[RowIndex].Cells[4].Text.ToString()) < 0)
            //        {
            //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Amount must be greater than or equal to zero')", true);
            //            Gridcreditreq.Rows[RowIndex].Cells[4].Text = "0.00";
            //            return;
            //        }

            //}
            //int totappdays=0;
            //double totappmount=0.00;

            //if (Gridcreditreq.Rows.Count > 0)
            //{
            //    for (int i = 0; i <= Gridcreditreq.Rows.Count - 2; i++)
            //    {
            //        totappdays = totappdays + Convert.ToInt32(Gridcreditreq.Rows[i].Cells[5].Text);
            //        totappmount = totappmount + Convert.ToDouble(Gridcreditreq.Rows[i].Cells[6].Text);
            //    }
            //    Gridcreditreq.Rows[Gridcreditreq.Rows.Count - 1].Cells[5].Text = totappdays.ToString();
            //    Gridcreditreq.Rows[Gridcreditreq.Rows.Count - 1].Cells[5].Text = totappdays.ToString();
            //}

            //if (prod == "All")
            //{
            //    ddlProductType.SelectedValue = "1";
            //}
            //if (prod == "OceanExport-FCL")
            //{
            //    ddlProductType.SelectedValue = "2";
            //}
            //if (prod == "OceanExport-LCL")
            //{
            //    ddlProductType.SelectedValue = "3";
            //}
            //if (prod == "OceanImport-FCL")
            //{
            //    ddlProductType.SelectedValue = "4";
            //}
            //if (prod == "OceanImport-LCL")
            //{
            //    ddlProductType.SelectedValue = "5";
            //}
            //if (prod == "AirExport")
            //{
            //    ddlProductType.SelectedValue = "6";
            //}
            //if (prod == "AirImport")
            //{
            //    ddlProductType.SelectedValue = "7";
            //}

            ////  ddlProductType.= Gridcreditreq.SelectedRow.Cells[1].Text;
            //txt_vol.Text = Gridcreditreq.SelectedRow.Cells[2].Text;
            //ddlvolumetype.SelectedValue = Gridcreditreq.SelectedRow.Cells[3].Text;
            //txt_revenue.Text = Gridcreditreq.SelectedRow.Cells[4].Text;
            //txt_creditdays.Text = Gridcreditreq.SelectedRow.Cells[5].Text;
            //txtCreditAboveamt.Text = Gridcreditreq.SelectedRow.Cells[6].Text;
            //txtCreditAboveamt.Text = Convert.ToDecimal(txtCreditAboveamt.Text).ToString("#,##0");
            //hid_crid.Value = Gridcreditreq.SelectedRow.Cells[8].Text;
            ////trantype = GrdCredit.SelectedRow.Cells[3].Text;
            //btn_add.ToolTip = "Update";
            //btn_add1.Attributes["class"] = "btn btn-UpdateAdd2";
        }

        protected void Gridcreditreq_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Gridcreditreq, "Select$" + e.Row.RowIndex);
            //    e.Row.Attributes["style"] = "cursor:pointer";

            //}
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    for (int i = 0; i < e.Row.Cells.Count; i++)
            //    {
            //        if (e.Row.Cells[i].Text == "&nbsp")
            //        {
            //            e.Row.Cells[i].Text = "";
            //        }
            //        if (e.Row.Cells[i].Text == "Approved Days")
            //        {
            //            TextBox txtvale = ((TextBox)e.Row.Cells[i].FindControl("txt_AppDays"));
            //            if (txtvale != null)
            //            {
            //                txtvale.Focus();
            //            }
            //        }

            //        e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
            //    }
            //    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Gridcreditreq, "TxtClick$" + e.Row.RowIndex);
            //    e.Row.Attributes["style"] = "cursor:pointer";
            //}

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_shiperconsignee, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
                string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");
                // Add events to each editable cell
                for (int columnIndex = 0; columnIndex < e.Row.Cells.Count; columnIndex++)
                {
                    // Add the column index as the event argument parameter
                    string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                    // Add this javascript to the onclick Attribute of the cell
                    e.Row.Cells[columnIndex].Attributes["onclick"] = js;

                    // Add a cursor style to the cells
                    e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";
                }

            }

        }

        protected void Imgsb_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dtSB = new DataTable();
            DataTable dtgrid1 = new DataTable();
            ImageButton lb = (ImageButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            if (Gridcreditreq.Rows.Count > 0)
            {
                int rowID = gvRow.RowIndex;
                hid_crid.Value = Gridcreditreq.Rows[rowID].Cells[8].Text;
            }
            groupid = Convert.ToInt32(hdn_cusid.Value.ToString());
            // hid_crid.Value = Gridcreditreq.SelectedRow.Cells[8].Text;
            DataTable dtgrid = new DataTable();
            if (hid_crid.Value != "")
            {
                dtgrid = obj_creditapp.delgridMasterCreditApp4Prod(groupid, Convert.ToInt32(hid_crid.Value));
                dtgrid1 = obj_creditapp.selgridMasterCreditApp4Prod(groupid, Convert.ToInt32(Session["LoginDivisionId"]));
                DataRow dr = dtgrid1.NewRow();
                if (dtgrid1.Rows.Count > 0)
                {

                    DataRow dr1 = dtgrid1.NewRow();
                    dr1["VolumeType"] = "Total";
                    dr1["Creditdays"] = Convert.ToDouble(dtgrid1.Compute("sum(Creditdays)", string.Empty)).ToString();
                    dr1["CreditAmount"] = Convert.ToDouble(dtgrid1.Compute("sum(CreditAmount)", string.Empty)).ToString("0.00");
                    dtgrid1.Rows.Add(dr1);

                    Gridcreditreq.DataSource = dtgrid1;
                    Gridcreditreq.DataBind();

                }
                else
                {
                    Gridcreditreq.DataSource = dtgrid1;
                    Gridcreditreq.DataBind();

                }
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Product Details Deleted');", true);

            }

        }
        public void grdcreditrequest()
        {
            DataTable dtgrid1 = new DataTable();
            dtgrid1 = obj_creditapp.selgridMasterCreditApp4Prod(groupid, Convert.ToInt32(Session["LoginDivisionId"]));
            DataRow dr = dtgrid1.NewRow();
            if (dtgrid1.Rows.Count > 0)
            {

                DataRow dr1 = dtgrid1.NewRow();
                dr1["VolumeType"] = "Total";
                dr1["Creditdays"] = Convert.ToDouble(dtgrid1.Compute("sum(Creditdays)", string.Empty)).ToString();
                dr1["CreditAmount"] = Convert.ToDouble(dtgrid1.Compute("sum(CreditAmount)", string.Empty)).ToString("0.00");
                dr1["pappdays"] = Convert.ToDouble(dtgrid1.Compute("sum(pappdays)", string.Empty)).ToString();
                dr1["pappamt"] = Convert.ToDouble(dtgrid1.Compute("sum(pappamt)", string.Empty)).ToString("0.00");
                dr1["pEXLIMIT"] = Convert.ToDouble(dtgrid1.Compute("sum(pEXLIMIT)", string.Empty)).ToString();
                dr1["pOVERDUE"] = Convert.ToDouble(dtgrid1.Compute("sum(pOVERDUE)", string.Empty)).ToString();

                dtgrid1.Rows.Add(dr1);

                Gridcreditreq.DataSource = dtgrid1;
                Gridcreditreq.DataBind();

                for (int i = 0; i < dtgrid1.Rows.Count; i++)
                {
                    DropDownList ddl_tdssection = (DropDownList)Gridcreditreq.Rows[i].FindControl("ddl_exemption");
                    if (dtgrid1.Rows[i]["pEXMODE"].ToString() == "Month")
                    {
                        ddl_tdssection.SelectedValue = "1";
                    }
                    if (dtgrid1.Rows[i]["pEXMODE"].ToString() == "Annual")
                    {
                        ddl_tdssection.SelectedValue = "2";
                    }
                    // ddl_tdssection.SelectedValue = dtgrid1.Rows[i]["pEXMODE"].ToString();
                }
                foreach (GridViewRow row in Gridcreditreq.Rows)
                {
                    if (Gridcreditreq.Rows[row.RowIndex].Cells[11].Text == "&nbsp;")
                    {
                        Gridcreditreq.Rows[row.RowIndex].Cells[13].Text = "";
                    }
                }
            }
            else
            {
                Gridcreditreq.DataSource = dtgrid1;
                Gridcreditreq.DataBind();

            }
        }

        protected void Gridcreditreq_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //if (e.CommandName == "TxtClick")
            //{
            //    foreach (GridViewRow row in Gridcreditreq.Rows)
            //    {
            //        TextBox txtvale = ((TextBox)Gridcreditreq.Rows[row.RowIndex].FindControl("txt_AppDays"));
            //        if (txtvale != null)
            //        {
            //            txtvale.Focus();
            //        }

            //        //TextBox txtamt = ((TextBox)Gridcreditreq.Rows[row.RowIndex].FindControl("txt_AppAmount"));
            //        //if (txtamt != null)
            //        //{
            //        //    txtamt.Focus();
            //        //}

            //    }
            //}

            int index, indexcol = 0;
            int selectedRowIndex, selectedColumnIndex;
            selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            selectedColumnIndex = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
            Session["cellindex"] = selectedColumnIndex;
            string text = Gridcreditreq.Columns[selectedColumnIndex].HeaderText;
            Session["Head"] = text;
            Session["rowindex"] = selectedRowIndex;

            index = (int)Session["rowindex"];
            indexcol = (int)Session["cellindex"];

            if (e.CommandName == "ColumnClick")
            {
                //  int j = Gridcreditreq.SelectedRow.RowIndex;
                if (indexcol == 8)
                {
                    for (int i = 0; i <= Gridcreditreq.Rows.Count - 1; i++)
                    {

                        TextBox txtvale = ((TextBox)Gridcreditreq.Rows[i].FindControl("txt_AppDays"));

                        if (txtvale.Text == "" || txtvale == null)
                        {
                            txtvale.Text = "0";
                        }
                        if (txtvale.Text != "" || txtvale.Text != null)
                        {
                            rowIndex = Convert.ToInt32(e.CommandArgument);
                            TextBox txt1 = ((TextBox)Gridcreditreq.Rows[rowIndex].FindControl("txt_AppDays"));
                            //string value = txt1.Text;
                            if (txt1.Text == "0")
                            {
                                txt1.Text = "";
                                txt1.Focus();
                            }
                            else
                            {
                                txt1.Focus();
                            }
                        }
                    }
                }
                if (indexcol == 9)
                {

                    for (int i = 0; i <= Gridcreditreq.Rows.Count - 1; i++)
                    {

                        TextBox txtvale = ((TextBox)Gridcreditreq.Rows[i].FindControl("txt_AppAmount"));
                        if (txtvale.Text == "")
                        {
                            txtvale.Text = "0.00";
                        }
                        if (txtvale.Text != "" || txtvale.Text != null)
                        {
                            rowIndex = Convert.ToInt32(e.CommandArgument);
                            TextBox txt2 = ((TextBox)Gridcreditreq.Rows[rowIndex].FindControl("txt_AppAmount"));
                            //string value = txt1.Text;
                            if (txt2.Text == "0.00")
                            {
                                txt2.Text = "";
                                txt2.Focus();
                            }
                            else
                            {
                                txt2.Focus();
                            }

                        }
                    }
                }

                if (indexcol == 12)
                {

                    for (int i = 0; i <= Gridcreditreq.Rows.Count - 1; i++)
                    {

                        TextBox txtvale = ((TextBox)Gridcreditreq.Rows[i].FindControl("txt_Exemptions"));
                        if (txtvale.Text == "")
                        {
                            txtvale.Text = "0.00";
                        }
                        if (txtvale.Text != "" || txtvale.Text != null)
                        {
                            rowIndex = Convert.ToInt32(e.CommandArgument);
                            TextBox txt3 = ((TextBox)Gridcreditreq.Rows[rowIndex].FindControl("txt_Exemptions"));
                            //string value = txt1.Text;
                            if (txt3.Text == "0.00")
                            {
                                txt3.Text = "";
                                txt3.Focus();
                            }
                            else
                            {
                                txt3.Focus();
                            }
                        }
                    }
                }

                if (indexcol == 13)
                {
                    DropDownList dropDownList = sender as DropDownList;

                    //for (int i = 0; i <= Gridcreditreq.Rows.Count - 1; i++)
                    //{
                    //}
                    //hide
                    //for (int i = 0; i < Gridcreditreq.Rows.Count - 1; i++)
                    //{
                    //    DropDownList ddl_exemption = (DropDownList)Gridcreditreq.Rows[i].FindControl("ddl_exemption");
                    //    ddl_exemption.Focus();
                    //}
                    //hide
                    //for (int i = 0; i < Gridcreditreq.Rows.Count-1; i++)
                    //{
                    //    DropDownList ddl_exemption = (DropDownList)Gridcreditreq.Rows[i].FindControl("ddl_exemption");
                    //    ddl_exemption.SelectedValue = "1";
                    //}
                    //foreach (GridViewRow row in Gridcreditreq.Rows)
                    //{
                    //        DropDownList ddl_exemption = (DropDownList)Gridcreditreq.Rows[row.RowIndex].FindControl("ddl_exemption");
                    //        ddl_exemption.Focus();
                    //}
                    //for (int i = 0; i <= Gridcreditreq.Rows.Count - 1; i++)
                    //{
                    //    DropDownList ddl_exemption = (DropDownList)Gridcreditreq.Rows[i].FindControl("ddl_exemption");
                    //    if (ddl_exemption.Text == "")
                    //    {
                    //        ddl_exemption.SelectedValue = "1";
                    //    }
                    //    if (ddl_exemption.Text != "" || ddl_exemption.Text != null)
                    //    {
                    //        rowIndex = Convert.ToInt32(e.CommandArgument);
                    //        DropDownList ddl_ex = ((DropDownList)Gridcreditreq.Rows[rowIndex].FindControl("ddl_exemption"));
                    //        ddl_ex.Focus();
                    //    }
                    //}
                    foreach (GridViewRow row in Gridcreditreq.Rows)
                    {
                        rowIndex = Convert.ToInt32(e.CommandArgument);
                        // DropDownList ddl_ex = ((DropDownList)Gridcreditreq.Rows[rowIndex].FindControl("ddl_exemption"));
                        DropDownList ddl1 = (DropDownList)Gridcreditreq.Rows[0].Cells[11].FindControl("ddl_cargo");
                        if (Gridcreditreq.Rows[row.RowIndex].Cells[11].Text == "&nbsp;")
                        {
                            Gridcreditreq.Rows[row.RowIndex].Cells[13].Text = "";
                        }
                    }
                }
                if (indexcol == 14)
                {

                    for (int i = 0; i <= Gridcreditreq.Rows.Count - 1; i++)
                    {

                        TextBox txtvale = ((TextBox)Gridcreditreq.Rows[i].FindControl("txt_Overdue"));
                        if (txtvale.Text == "")
                        {
                            txtvale.Text = "0.00";
                        }
                        if (txtvale.Text != "" || txtvale.Text != null)
                        {
                            rowIndex = Convert.ToInt32(e.CommandArgument);
                            TextBox txt4 = ((TextBox)Gridcreditreq.Rows[rowIndex].FindControl("txt_Overdue"));
                            //string value = txt1.Text;
                            if (txt4.Text == "0.00")
                            {
                                txt4.Text = "";
                                txt4.Focus();
                            }
                            else
                            {
                                txt4.Focus();
                            }
                        }
                    }
                }
            }
        }

        protected void txt_AppDays_TextChanged(object sender, EventArgs e)
        {
            int totappdays = 0;
            double totappmount = 0.00;

            foreach (GridViewRow row in Gridcreditreq.Rows)
            {
                int txtdays = Convert.ToInt32(((TextBox)Gridcreditreq.Rows[row.RowIndex].FindControl("txt_AppDays")).Text);
                if (txtdays != null)
                {
                    //  appdays = (txtdays);
                }
                else
                {
                    // appdays = 0;
                }
                //int txtamt = Convert.ToInt32(((TextBox)Gridcreditreq.Rows[row.RowIndex].FindControl("txt_AppAmount")).Text);
                //if (txtdays != null)
                //{
                //    //  appamt = (txtamt);
                //}
                //else
                //{
                //    // appamt = 0;
                //}
                totappdays = 0;
                if (Gridcreditreq.Rows.Count > 0)
                {
                    for (int i = 0; i <= Gridcreditreq.Rows.Count - 2; i++)
                    {
                        totappdays = totappdays + Convert.ToInt32(((TextBox)Gridcreditreq.Rows[i].FindControl("txt_AppDays")).Text);
                        //totappmount = totappmount + Convert.ToDouble(Gridcreditreq.Rows[i].Cells[6].Text);
                    }

                    TextBox TxtAmount = ((TextBox)Gridcreditreq.Rows[Gridcreditreq.Rows.Count - 1].FindControl("txt_AppDays"));
                    TxtAmount.Text = totappdays.ToString();

                    //Gridcreditreq.Rows[Gridcreditreq.Rows.Count - 1].Cells[6].Text = totappdays.ToString();
                    // Gridcreditreq.Rows[row.RowIndex].FindControl("txt_AppDays").ToString()= totappdays.ToString();
                }

                //for (int i = 0; i < Gridcreditreq.Rows.Count; i++)
                //{
                //    TextBox box1 = (TextBox)Gridcreditreq.Rows[rowIndex].Cells[6].FindControl("txt_AppDays");
                //    TextBox box2 = (TextBox)Gridcreditreq.Rows[rowIndex].Cells[7].FindControl("txt_AppAmount");
                //    totappdays = totappdays + Convert.ToInt32(((TextBox)Gridcreditreq.Rows[row.RowIndex].FindControl("txt_AppDays")).Text);

                //    box1.Text = totappdays.ToString();
                //    //box2.Text = dt.Rows[i]["Column2"].ToString();
                //    //box3.Text = dt.Rows[i]["Column3"].ToString();
                //    //box4.Text = dt.Rows[i]["Column4"].ToString();

                //    rowIndex++;
                //}
            }

        }
        protected void txt_AppAmount_TextChanged(object sender, EventArgs e)
        {

            double totappmount = 0.00;

            foreach (GridViewRow row in Gridcreditreq.Rows)
            {
                totappmount = Convert.ToDouble(((TextBox)Gridcreditreq.Rows[row.RowIndex].FindControl("txt_AppAmount")).Text);
                if (totappmount != null)
                {

                }
                else
                {

                }
                totappmount = 0.00;
                if (Gridcreditreq.Rows.Count > 0)
                {
                    for (int i = 0; i <= Gridcreditreq.Rows.Count - 2; i++)
                    {
                        totappmount = totappmount + Convert.ToDouble(((TextBox)Gridcreditreq.Rows[i].FindControl("txt_AppAmount")).Text);
                        //totappmount = totappmount + Convert.ToDouble(Gridcreditreq.Rows[i].Cells[6].Text);
                    }

                    TextBox TxtAmountnew = ((TextBox)Gridcreditreq.Rows[Gridcreditreq.Rows.Count - 1].FindControl("txt_AppAmount"));
                    TxtAmountnew.Text = totappmount.ToString("0.00");

                }

            }
        }

        protected void txt_Exemptions_TextChanged(object sender, EventArgs e)
        {
            int exmp = 0;

            foreach (GridViewRow row in Gridcreditreq.Rows)
            {
                int txtemp = Convert.ToInt32(((TextBox)Gridcreditreq.Rows[row.RowIndex].FindControl("txt_Exemptions")).Text);
                if (txtemp != null)
                {

                }
                else
                {

                }

                exmp = 0;
                if (Gridcreditreq.Rows.Count > 0)
                {
                    for (int i = 0; i <= Gridcreditreq.Rows.Count - 2; i++)
                    {
                        exmp = exmp + Convert.ToInt32(((TextBox)Gridcreditreq.Rows[i].FindControl("txt_Exemptions")).Text);

                    }

                    TextBox TxtExmp = ((TextBox)Gridcreditreq.Rows[Gridcreditreq.Rows.Count - 1].FindControl("txt_Exemptions"));
                    TxtExmp.Text = exmp.ToString();

                }

            }

        }

        protected void txt_Overdue_TextChanged1(object sender, EventArgs e)
        {
            int ovrdue = 0;

            foreach (GridViewRow row in Gridcreditreq.Rows)
            {
                int ovrduedays = Convert.ToInt32(((TextBox)Gridcreditreq.Rows[row.RowIndex].FindControl("txt_Overdue")).Text);
                if (ovrduedays != null)
                {

                }
                else
                {

                }

                ovrdue = 0;
                if (Gridcreditreq.Rows.Count > 0)
                {
                    for (int i = 0; i <= Gridcreditreq.Rows.Count - 2; i++)
                    {
                        ovrdue = ovrdue + Convert.ToInt32(((TextBox)Gridcreditreq.Rows[i].FindControl("txt_Overdue")).Text);
                    }
                    TextBox TxtOverdue = ((TextBox)Gridcreditreq.Rows[Gridcreditreq.Rows.Count - 1].FindControl("txt_Overdue"));
                    TxtOverdue.Text = ovrdue.ToString();
                }
            }
        }

        protected void GrdCreditAmt_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = this.GrdCreditAmt.SelectedRow;
            Label LblId = (Label)row.FindControl("customername");
            string data = LblId.Text;
            txt_customer.Text = data;
            txt_customer_TextChanged(sender, e);
            GetDetails();
        }

    }
}

