using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace logix
{
    public partial class Cor_MainModule : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
        //    //Session["StrTranType"] = "CO";

        //   /* Accounts_and_finanace.ServerClick += new EventHandler(Accounts_and_finanace_Click);
        //    Credit_Control.ServerClick += new EventHandler(Credit_Control_Click);
        //    Budget.ServerClick += new EventHandler(Budget_Click);
        //    MIS_and_Analysis.ServerClick += new EventHandler(MIS_and_Analysis_Click);
        //    Utility.ServerClick += new EventHandler(Utility_Click);
        //    CRM.ServerClick += new EventHandler(CRM_Click);
        //    Maintenances.ServerClick += new EventHandler(Maintenances_Click);
        //    HRM.ServerClick += new EventHandler(HRM_Click);*/

        //    DataTable dt_MenuRights = new DataTable();
        //    DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        //    dt_MenuRights = obj_UP.Getmodule(Convert.ToInt16(Session["LoginEmpId"].ToString()), Convert.ToInt16(Session["LoginBranchid"].ToString()));
        //    for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
        //    {
        //        if (dt_MenuRights.Rows[i]["trantype"].ToString() == "HR")
        //        {
        //            HRM.ServerClick += new EventHandler(HRM_Click);
        //            continue;
        //        }
        //        if (dt_MenuRights.Rows[i]["trantype"].ToString() == "CRM")
        //        {
        //            CRM.ServerClick += new EventHandler(CRM_Click);
        //            continue;
        //        }


        //        if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "MI"))
        //        {

        //            for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
        //            {
        //                if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Voucher" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Register" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Approval" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Query")
        //                {
        //                    Accounts_and_finanace.ServerClick += new EventHandler(Accounts_and_finanace_Click);
        //                    continue;
        //                }
        //            }


        //        }


        //        if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "MI"))
        //        {

        //            for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
        //            {
        //                if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Credit")
        //                {
        //                    Credit_Control.ServerClick += new EventHandler(Credit_Control_Click);
        //                    continue;
        //                }
        //            }


        //        }

        //        if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "MI"))
        //        {

        //            for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
        //            {
        //                if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Analysis" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "M I S")
        //                {
        //                   MIS_and_Analysis.ServerClick += new EventHandler(MIS_and_Analysis_Click);
        //                    continue;
        //                }
        //            }


        //        }

        //        if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "MI"))
        //        {
        //            for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
        //            {
        //                if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Utility")
        //                {
        //                    Utility.ServerClick += new EventHandler(Utility_Click);
        //                    continue;
        //                }
        //            }
        //        }


        //        if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "MI"))
        //        {

        //            for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
        //            {
        //                if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Budget")
        //                {
        //                    Budget.ServerClick += new EventHandler(Budget_Click);
        //                    continue;
        //                }
        //            }


        //        }

        //        if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "MN"))
        //        {
        //            Maintenances.ServerClick += new EventHandler(Maintenances_Click);
        //            continue;
        //        }
        //    }




        //    if (!IsPostBack)
        //    {
        //        fn_GrdLoadNews();
        //        Fn_Loaddetail();
        //        Fn_Loaddetailemployee();
        //        Fn_Loaddetailwelfare();
        //        fn_loaddetailsothers();

                
        //        //TextBox1.Text = "VMA";
        //    }
         

           
        //}

        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();

        int Login_EmpID, VouYear, FYear = 0, ddlFYear, changepass, divisionId, branchid, ipcheck, loginid, Alogyear;
        string DispYear, FinYear; string[] Fin_Year;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
            //Session["StrTranType"] = "CO";

            /* Accounts_and_finanace.ServerClick += new EventHandler(Accounts_and_finanace_Click);
             Credit_Control.ServerClick += new EventHandler(Credit_Control_Click);
             Budget.ServerClick += new EventHandler(Budget_Click);
             MIS_and_Analysis.ServerClick += new EventHandler(MIS_and_Analysis_Click);
             Utility.ServerClick += new EventHandler(Utility_Click);
             CRM.ServerClick += new EventHandler(CRM_Click);
             Maintenances.ServerClick += new EventHandler(Maintenances_Click);
             HRM.ServerClick += new EventHandler(HRM_Click);*/


            if (!IsPostBack)
            {

                DateTime dt_Date = da_obj_Log.GetDate();
                Session["TodayDate"] = dt_Date;
                string favouyearddl = "";
                if (Request.QueryString.ToString().Contains("finaddlyear"))
                {
                    Session["finaddlyear"] = Request.QueryString["finaddlyear"].ToString();
                    favouyearddl = Session["finaddlyear"].ToString();

                }
                if (favouyearddl == "")
                {

                if (dt_Date.Month < 4)
                {
                    Session["Vouyear"] = dt_Date.Year - 1;
                    VouYear = dt_Date.Year - 1;
                    Alogyear = VouYear;
                    Session["Alogyear"] = Alogyear;
                    string str_dispyear = "";
                    for (int i = 2017; i < dt_Date.Year; i++)
                    {
                        str_dispyear = Convert.ToString(i);
                        str_dispyear = str_dispyear.Substring(2, 2);
                        int dy;
                        string dy1 = "";

                        dy = Convert.ToInt32(str_dispyear) + 1;

                        if (dy < 10)
                        {
                            dy1 = dy1 + "0" + Convert.ToString(dy);
                        }
                        else
                        {
                            dy1 = Convert.ToString(dy);

                        }
                        str_dispyear = str_dispyear + "-" + dy1;
                        Session["str_dispyear"] = str_dispyear;
                        ddl_FAYear.Items.Add(str_dispyear);

                        if (i == VouYear)
                        {
                            ddl_FAYear.Text = str_dispyear;
                            Session["LYEAR"] = ddl_FAYear.Text;
                            Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                        }
                    }
                }
                else
                {
                    Session["Vouyear"] = dt_Date.Year;
                    VouYear = dt_Date.Year;
                    Alogyear = VouYear;
                    Session["Alogyear"] = Alogyear;
                    string str_dispyear = "";
                    for (int i = 2018; i <= dt_Date.Year; i++)
                    {
                        str_dispyear = Convert.ToString(i);
                        str_dispyear = str_dispyear.Substring(2, 2);
                        int dy;
                        string dy1 = "";

                        dy = Convert.ToInt32(str_dispyear) + 1;

                        if (dy < 10)
                        {
                            dy1 = dy1 + "0" + Convert.ToString(dy);
                        }
                        else
                        {
                            dy1 = Convert.ToString(dy);

                        }
                        str_dispyear = str_dispyear + "-" + dy1;
                        Session["str_dispyear"] = str_dispyear;
                        ddl_FAYear.Items.Add(str_dispyear);

                        if (i == VouYear)
                        {
                            ddl_FAYear.Text = str_dispyear;
                            Session["LYEAR"] = ddl_FAYear.Text;
                            Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                        }
                    }
                }

            }

                else
                {

                    if (dt_Date.Month < 4)
                    {
                        Session["Vouyear"] = dt_Date.Year - 1;
                        VouYear = dt_Date.Year - 1;
                        Alogyear = VouYear;
                        Session["Alogyear"] = Alogyear;
                        string str_dispyear = "";
                        for (int i = 2017; i < dt_Date.Year; i++)
                        {
                            str_dispyear = Convert.ToString(i);
                            str_dispyear = str_dispyear.Substring(2, 2);
                            int dy;
                            string dy1 = "";

                            dy = Convert.ToInt32(str_dispyear) + 1;

                            if (dy < 10)
                            {
                                dy1 = dy1 + "0" + Convert.ToString(dy);
                            }
                            else
                            {
                                dy1 = Convert.ToString(dy);

                            }
                            str_dispyear = str_dispyear + "-" + dy1;
                            Session["str_dispyear"] = str_dispyear;
                            ddl_FAYear.Items.Add(str_dispyear);

                            if (i == VouYear)
                            {
                                ddl_FAYear.Text = str_dispyear;
                                Session["LYEAR"] = ddl_FAYear.Text;
                                Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                            }
                        }
                    }
                    else
                    {
                        Session["Vouyear"] = dt_Date.Year;
                        VouYear = dt_Date.Year;
                        Alogyear = VouYear;
                        Session["Alogyear"] = Alogyear;
                        string str_dispyear = "";
                        for (int i = 2018; i <= dt_Date.Year; i++)
                        {
                            str_dispyear = Convert.ToString(i);
                            str_dispyear = str_dispyear.Substring(2, 2);
                            int dy;
                            string dy1 = "";

                            dy = Convert.ToInt32(str_dispyear) + 1;

                            if (dy < 10)
                            {
                                dy1 = dy1 + "0" + Convert.ToString(dy);
                            }
                            else
                            {
                                dy1 = Convert.ToString(dy);

                            }
                            str_dispyear = str_dispyear + "-" + dy1;
                            Session["str_dispyear"] = str_dispyear;
                            ddl_FAYear.Items.Add(str_dispyear);

                            if (i == VouYear)
                            {
                                ddl_FAYear.Text = str_dispyear;
                                Session["LYEAR"] = ddl_FAYear.Text;
                                Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                            }
                        }
                    }

                    ddl_FAYear.Text = favouyearddl;
                    Session["LYEAR"] = ddl_FAYear.Text;
                }
                //chart
                loadgrd();
                line();
                piechar();

            }



            DataTable dt_MenuRights = new DataTable();
            DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
            dt_MenuRights = obj_UP.Getmodule(Convert.ToInt16(Session["LoginEmpId"].ToString()), Convert.ToInt16(Session["LoginBranchid"].ToString()));
            for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
            {
                if (dt_MenuRights.Rows[i]["trantype"].ToString() == "HR")
                {
                    HRM.ServerClick += new EventHandler(HRM_Click);
                    if (Session["HRM"] != null)
                    {
                        Session["HRM"] = null;
                        HRM_Click(sender, e);
                        return;
                    }
                    continue;
                }
                if (dt_MenuRights.Rows[i]["trantype"].ToString() == "CRM")
                {
                    CRM.ServerClick += new EventHandler(CRM_Click);
                    if (Session["CRMCO"] != null)
                    {
                        Session["CRMCO"] = null;
                        CRM_Click(sender, e);
                        return;
                    }
                    continue;
                }
                if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FC")
                {
                    FAccounts.ServerClick += new EventHandler(FAccounts_Click);

                    if (Session["FAFC"] != null)
                    {
                        Session["FAFC"] = null;
                        FAccounts_Click(sender, e);
                        return;
                    }
                    continue;
                }

                if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "MI"))
                {

                    for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                    {
                        if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Voucher" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Register" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Approval" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Query")
                        {
                            Accounts_and_finanace.ServerClick += new EventHandler(Accounts_and_finanace_Click);
                            if (Session["Accounts_and_finanace"] != null)
                            {
                                Session["Accounts_and_finanace"] = null;
                                Accounts_and_finanace_Click(sender, e);
                                return;
                            }
                            continue;
                        }
                    }


                }


                if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "MI"))
                {

                    for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                    {
                        if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Credit")
                        {
                            Credit_Control.ServerClick += new EventHandler(Credit_Control_Click);
                            if (Session["Credit_Control"] != null)
                            {
                                Session["Credit_Control"] = null;
                                Credit_Control_Click(sender, e);
                                return;
                            }
                            continue;
                        }
                    }


                }

                if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "MI"))
                {

                    for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                    {
                        if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Analysis" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "M I S")
                        {
                            MIS_and_Analysis.ServerClick += new EventHandler(MIS_and_Analysis_Click);
                            if (Session["MIS_and_Analysis"] != null)
                            {
                                Session["MIS_and_Analysis"] = null;
                                MIS_and_Analysis_Click(sender, e);
                                return;
                            }
                            continue;
                        }
                    }


                }

                if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "MI"))
                {
                    for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                    {
                        if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Utility")
                        {
                            Utility.ServerClick += new EventHandler(Utility_Click);
                            if (Session["Utility"] != null)
                            {
                                Session["Utility"] = null;
                                Utility_Click(sender, e);
                                return;
                            }
                            continue;
                        }
                    }
                }


                if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "MI"))
                {

                    for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                    {
                        if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Budget")
                        {
                            Budget.ServerClick += new EventHandler(Budget_Click);
                            if (Session["Budget"] != null)
                            {
                                Session["Budget"] = null;
                                Budget_Click(sender, e);
                                return;
                            }

                            continue;
                        }
                    }


                }

                if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "MN"))
                {
                    Maintenances.ServerClick += new EventHandler(Maintenances_Click);
                    if (Session["Maintenances"] != null)
                    {
                        Session["Maintenances"] = null;
                        Maintenances_Click(sender, e);
                        return;
                    }
                    continue;
                }
                if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "MI"))
                {

                    for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                    {
                        if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Analysis" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "M I S")
                        {
                            MIS_and_Analysis.ServerClick += new EventHandler(MIS_and_Analysis_Click);
                            if (Session["Tasks"] != null)
                            {
                                Session["Tasks"] = null;
                                Task_Clik(sender, e);
                                return;
                            }
                            continue;
                        }
                    }


                }
            }




            if (!IsPostBack)
            {
                fn_GrdLoadNews();
                Fn_Loaddetail();
                Fn_Loaddetailemployee();
                Fn_Loaddetailwelfare();
                fn_loaddetailsothers();


                //TextBox1.Text = "VMA";
            }
             if (Session["Process1"].ToString() == "MAINTENANCE")
            {
                Maintenances_Click(sender, e);
            }
            else if (Session["Process1"].ToString() == "MIS & ANALYTICS")
            {
                MIS_and_Analysis_Click(sender, e);
            }
            else if (Session["Process1"].ToString() == "FINANCIAL ACCOUNTS")
            {
                FAccounts_Click(sender, e);
            }
            else if (Session["Process1"].ToString() == "TASK MANAGEMENT")
            {
                Task_Clik(sender, e);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", ";window.open('../LOGIN.aspx','_top');", true);

            }
        }
        
        private void fn_GrdLoadNews()
        {
            try
            {
                DataAccess.Masters.MasterMaintenance obj_da_reqobj = new DataAccess.Masters.MasterMaintenance();
                DataTable dt_ok = new DataTable();
                dt_ok = obj_da_reqobj.GetFrontNews();
                if (dt_ok.Rows.Count > 0)
                {
                    grd1.DataSource = dt_ok;
                    grd1.DataBind();
                    for (int i = 0; i < dt_ok.Rows.Count; i++)
                    {
                        news.InnerText += dt_ok.Rows[i]["news"].ToString() + " | ";
                    }
                }
                else
                {
                    grd1.DataSource = dt_ok;
                    grd1.DataBind();
                    news.InnerText = "";
                }
                // itpolicy.Visible = false;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        private void Fn_Loaddetail()
        {
            DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_CompanyProfile.GetCompanyProfile(1);
            if (obj_dt.Rows.Count > 0)
            {
                // btn_Save.Text = "Update";
                txt_Profile.Text = obj_dt.Rows[0][0].ToString();
                txt_Mission.Text = obj_dt.Rows[0][1].ToString();
                txt_Achieve.Text = obj_dt.Rows[0][2].ToString();
                txt_Philosophy.Text = obj_dt.Rows[0][3].ToString();
                txt_Beleifs.Text = obj_dt.Rows[0][4].ToString();
                txt_Hours.Text = obj_dt.Rows[0][5].ToString();
                txt_DressCode.Text = obj_dt.Rows[0][6].ToString();
                txt_Salary.Text = obj_dt.Rows[0][7].ToString();
                txt_Leave.Text = obj_dt.Rows[0][8].ToString();
                txt_Probation.Text = obj_dt.Rows[0][9].ToString();
            }
            // itpolicy.Visible = false;
        }
        //private void fn_loaditpolicy()
        //{
        //    try
        //    {
        //        if (tab33lable.InnerText == "IT Policy")
        //        {
        //            itpolicy.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }

        //}
        private void Fn_Loaddetailemployee()
        {
            DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_CompanyProfile.GetCompanyProfile(2);
            if (obj_dt.Rows.Count > 0)
            {

                txt_Leaveemployee.Text = obj_dt.Rows[0][0].ToString();
                txt_Medical.Text = obj_dt.Rows[0][1].ToString();
                txt_Lunch.Text = obj_dt.Rows[0][2].ToString();
                txt_Entertain.Text = obj_dt.Rows[0][3].ToString();
                txt_Driver.Text = obj_dt.Rows[0][4].ToString();
                txt_PF.Text = obj_dt.Rows[0][5].ToString();
                txt_Employee.Text = obj_dt.Rows[0][6].ToString();
                txt_Gratutity.Text = obj_dt.Rows[0][7].ToString();
                txt_Bonus.Text = obj_dt.Rows[0][8].ToString();
                txt_Travel.Text = obj_dt.Rows[0][9].ToString();
                if (!string.IsNullOrEmpty(obj_dt.Rows[0][11].ToString()))
                {
                    TextBox1.Text = obj_dt.Rows[0][11].ToString();
                }
                if (!string.IsNullOrEmpty(obj_dt.Rows[0][12].ToString()))
                {
                 
                    TextBox2.Text =  obj_dt.Rows[0][12].ToString();
                }
            }
            // itpolicy.Visible = false;
        }
        private void Fn_Loaddetailwelfare()
        {
            DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_CompanyProfile.GetCompanyProfile(3);
            if (obj_dt.Rows.Count > 0)
            {
                // btn_Save.Text = "Update";
                txt_Group.Text = obj_dt.Rows[0][0].ToString();
              //  txt_Leavewelfare.Text = obj_dt.Rows[0][1].ToString();
                txt_Wedding.Text = obj_dt.Rows[0][2].ToString();
                txt_Referral.Text = obj_dt.Rows[0][3].ToString();
                if (!string.IsNullOrEmpty(obj_dt.Rows[0][5].ToString()))
                {
                    txt_grplifeins.Text = obj_dt.Rows[0][5].ToString();
                }
            }
            // itpolicy.Visible = false;
        }

        public void fn_loaddetailsothers()
        {
            DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_CompanyProfile.GetCompanyProfile(4);
            if (obj_dt.Rows.Count > 0)
            {
                //Txt_IncomeTax.Text = "INCOME TAX";
                //Txt_ProAppr.Text = "Probation Apprasial";
                //Txt_Annu.Text = "Annual Performance Appraisal";
                //Txt_Sug.Text = "Suggestion Policy";
                //Txt_IncPoli.Text = "Incentive Policy";
                //Txt_GrivPoli.Text = "Grievance Policy";

                if (!string.IsNullOrEmpty(obj_dt.Rows[0][1].ToString()))
                {
                    Txt_IncomeTax.Text = obj_dt.Rows[0][1].ToString();
                }
                if (!string.IsNullOrEmpty(obj_dt.Rows[0][2].ToString()))
                {
                    Txt_ProAppr.Text = obj_dt.Rows[0][2].ToString();
                }
                if (!string.IsNullOrEmpty(obj_dt.Rows[0][3].ToString()))
                {
                    Txt_Annu.Text = obj_dt.Rows[0][3].ToString();
                }

                if (!string.IsNullOrEmpty(obj_dt.Rows[0][4].ToString()))
                {
                    Txt_Sug.Text = obj_dt.Rows[0][4].ToString();
                }

                if (!string.IsNullOrEmpty(obj_dt.Rows[0][5].ToString()))
                {
                    Txt_IncPoli.Text = obj_dt.Rows[0][5].ToString();
                }
                if (!string.IsNullOrEmpty(obj_dt.Rows[0][6].ToString()))
                {
                    Txt_GrivPoli.Text = obj_dt.Rows[0][6].ToString();
                }
            }
          
          
        }


        
        public void Accounts_and_finanace_Click(object sender, EventArgs e)
        {
            Session["home"] = "AC&FINhome";
            Session["StrTranType1"] = "AccountandFinanceCor";
            Response.Redirect("CorMainPage/Accounts_and_finanace_Docked.aspx");
        }

        public void Credit_Control_Click(object sender, EventArgs e)
        {
            Session["home"] = "CredConthome";
            Session["StrTranType1"] = "CreditControlcor";
            Response.Redirect("CorMainPage/Credit_Control_Docked.aspx");
        }

        public void Budget_Click(object sender, EventArgs e)
        {
            Session["home"] = "Budgethome";
            Session["StrTranType1"] = "BudgetCor";
            Response.Redirect("CorMainPage/Budget_Docked.aspx");
        }

        public void MIS_and_Analysis_Click(object sender, EventArgs e)
        {
            Session["StrTranType1"] = "MISandAnalysisCor";
            Response.Redirect("CorMainPage/MIS_and_Analysis_Docked.aspx");
        }

        public void Task_Clik(object sender, EventArgs e)
        {
            Session["StrTranType1"] = "TaskManagement";
            Response.Redirect("TaskDetailsDashMain.aspx");
        }

        public void Utility_Click(object sender, EventArgs e)
        {
            Session["StrTranType1"] = "Utilitycor";
            Response.Redirect("CorMainPage/Utility_Docked.aspx");
        }
        public void CRM_Click(object sender, EventArgs e)
        {
            Session["StrTranType1"] = "CRMcor";
            Response.Redirect("MainPage/CRMDocked.aspx");
        }
        public void Maintenances_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "M";
            Session["StrTranType1"] = "MCor";
            DataTable dt_MenuRights = new DataTable();
            string str_ModuleName = "MN";
            DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
            dt_MenuRights = obj_UP.GetMenus(Convert.ToInt16(Session["LoginEmpId"].ToString()), str_ModuleName, Convert.ToInt16(Session["LoginBranchid"].ToString()));
            Session["dt_UserRights"] = dt_MenuRights;

            if (dt_MenuRights.Rows.Count > 0)
            {
                Response.Redirect("MainPage/MaintenanceDockedPanel.aspx");
            }
        }
        public void HRM_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "HR";
            Session["StrTranType1"] = "HRCor";
            Response.Redirect("MainPage/HRMDocked.aspx");
        }

        public void FAccounts_Click(object sender, EventArgs e)
        {
            fn_GetFADB();
            Session["FA_Year"] = ddl_FAYear.SelectedItem.Text;
            Session["LogYear"] = "20" + ddl_FAYear.Text.ToString().Substring(0, 2);
            Session["Vouyear"] = "20" + ddl_FAYear.Text.ToString().Substring(0, 2);
            Session["StrTranType"] = "CO";
            Session["StrTranType1"] = "FCCO";
            Session["home"] = "FCCO";
            Response.Redirect("MainPage/Main_Corporate.aspx");
        }

        private void fn_GetFADB()
        {
            string str_FAYear = "";
            string str_FADbname = "";
            str_FAYear = ddl_FAYear.Text;
            Session["LYEAR"] = ddl_FAYear.Text;
            str_FAYear = str_FAYear.Replace("-", "");
            str_FADbname = "FA" + str_FAYear;
            //str_FADbname = "DemoFA" + str_FAYear;
            Session["FADbname"] = str_FADbname;
        }
        public void line()
        {


            DataTable dt0 = new DataTable();
            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
            //dt0 = da_obj_misgrd.getunclosejobandclosedcount(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"])); hide 240821
            //corporate added
            dt0 = da_obj_misgrd.getunclosejobandclosedcountcorp(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

            StringBuilder str = new StringBuilder();
            str.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Type');
            data.addColumn('number', 'Jobs');
            data.addColumn('number', 'Closed Job');
             data.addColumn('number', 'Unclosed Jobs');
               data.addColumn('number', 'Shipments');
           
            data.addRows(" + dt0.Rows.Count + ");");



            for (int i = 0; i <= dt0.Rows.Count - 1; i++)
            {


                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt0.Rows[i]["type"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt0.Rows[i]["Jobs"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 2 + "," + dt0.Rows[i]["closedjob"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 3 + "," + dt0.Rows[i]["unclosedjobs"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 4 + "," + dt0.Rows[i]["shipment"].ToString() + ") ;");
            }

            str.Append("   var chart = new google.visualization.ColumnChart(document.getElementById('chart_divbar'));");
            str.Append(" chart.draw(data, {width: 760,height:300,");
            str.Append("hAxis: {title: '', titleTextStyle: {color: 'green'}},legend: { position: 'bottom' },colors: ['#4ebcd5','#bce3c8','#408fdc','#5765b2'],");
            str.Append("}); }");
            str.Append("</script>");
            lts.Text = str.ToString().Replace('*', '"');



        }
        public void piechar()
        {



            DataTable dt0 = new DataTable();
            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();

            DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();


            //  dt0 = Appobj.getunclosejobcount(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"])); hide 240821
            //corporate added std
            dt0 = Appobj.getunclosejobcountcorp(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

            //end
            StringBuilder str1 = new StringBuilder();
            str1.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart1);
            function drawChart1() {
            var data1 = new google.visualization.DataTable();
            data1.addColumn('string', 'Countryname');
            data1.addColumn('number', 'Total');
          
           
            data1.addRows(" + dt0.Rows.Count + ");");



            //for (int i = 0; i <= dt0.Rows.Count - 1; i++)
            //{


            //    //str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt0.Rows[i]["type"].ToString() + "');");
            //    //str.Append("data.setValue(" + i + "," + 1 + "," + dt0.Rows[i]["Jobs"].ToString() + ") ;");
            //    //str.Append("data.setValue(" + i + "," + 2 + "," + dt0.Rows[i]["closedjob"].ToString() + ") ;");
            //    //str.Append("data.setValue(" + i + "," + 3 + "," + dt0.Rows[i]["unclosedjobs"].ToString() + ") ;");
            //    str.Append("data.setValue(" + i + "," + 0 + "," + dt0.Rows[i]["type"].ToString() + ") ;")
            //    str.Append("data.setValue(" + i + "," + 0 + "," + dt0.Rows[i]["type"].ToString() + ") ;")
            //}


            //for (int i = 0; i < dt0.Rows.Count; i++) {
            //    data.addRow([dt0[i].Countryname, dt0[i].Total]);
            //}

            for (int i = 0; i <= dt0.Rows.Count - 1; i++)
            {


                str1.Append("data1.setValue( " + i + "," + 0 + "," + "'" + dt0.Rows[i]["type"].ToString() + "');");
                str1.Append("data1.setValue(" + i + "," + 1 + "," + dt0.Rows[i]["counts"].ToString() + ") ;");

            }

            str1.Append("   var chart = new google.visualization.PieChart(document.getElementById('chartdiv'));");
            str1.Append(" chart.draw(data1, {width: 350,height:300, ");
            str1.Append("hAxis: {title: '', titleTextStyle: {color: 'green'}},legend: { position: 'bottom' },colors: ['#4ebcd5','#bce3c8','#408fdc','#5765b2'],");
            str1.Append("}); }");
            str1.Append("</script>");
            Literal1.Text = str1.ToString().Replace('*', '"');



        }
        public void loadgrd()
        {
            DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
            string dtexdate = obj_da_Logobj.GetDate().ToString();
            DataTable dt = new DataTable();
            //dt = exrobj.GetExRateDetails(dtexdate);
            dt = exrobj.GetExRateDetails(Convert.ToDateTime(dtexdate));
            if (dt.Rows.Count > 0)
            {
                Gridexrate.DataSource = dt;
                Gridexrate.DataBind();
            }
            else
            {
                Gridexrate.DataSource = dt;
                Gridexrate.DataBind();
            }
        }

        protected void Gridexrate_PreRender(object sender, EventArgs e)
        {
            if (Gridexrate.Rows.Count > 0)
            {
                Gridexrate.UseAccessibleHeader = true;
                Gridexrate.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}