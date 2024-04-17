using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Runtime.Serialization;
namespace logix
{
    public partial class Mainmodule_product : System.Web.UI.Page
    {
        DataTable dt_MenuRights = new DataTable();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();

        int Login_EmpID, VouYear, FYear = 0, ddlFYear, changepass, divisionId, branchid, ipcheck, loginid, Alogyear;
        string DispYear, FinYear; string[] Fin_Year;

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //  //  ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(mastercustomer);
        //    try
        //    {
        //        dt_MenuRights = obj_UP.Getmodule(Convert.ToInt16(Session["LoginEmpId"].ToString()), Convert.ToInt16(Session["LoginBranchid"].ToString()));
        //        for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
        //        {

        //            if (dt_MenuRights.Rows[i]["trantype"].ToString() == "CRM")
        //            {
        //                CRM.ServerClick += new EventHandler(CRM_Click);
        //                continue;
        //            }
        //            if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FE")
        //            {
        //                for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
        //                {
        //                    if(dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "CRM")
        //                    {
        //                        OE_CSs.ServerClick += new EventHandler(OE_CSs_Click);
        //                        continue;
        //                    }
        //                }
                        
        //            }
        //            if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "FE" ||dt_MenuRights.Rows[i]["trantype"].ToString() == "FI" ||dt_MenuRights.Rows[i]["trantype"].ToString() == "AE" ||dt_MenuRights.Rows[i]["trantype"].ToString() == "AI"))

        //            {
        //                for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
        //                {
        //                    if(dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Sales")
        //                    {
        //                        Sales.ServerClick += new EventHandler(Sales_Click);
        //                        continue;
        //                    }
        //                }
                          
        //            }
        //            if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FI" )
        //            {
        //                for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
        //                {
        //                    if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "CRM")
        //                    {
        //                        OI_CSs.ServerClick += new EventHandler(OI_CSs_Click);
        //                        continue;
        //                    }
        //                }

        //            }
        //            if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AE")
        //            {
        //                for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
        //                {
        //                    if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "CRM")
        //                    {
        //                        AE_CS.ServerClick += new EventHandler(AE_CS_Click);
        //                        continue;
        //                    }
        //                }

        //            }
        //            if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AI" )
        //            {
        //                for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
        //                {
        //                    if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "CRM")
        //                    {
        //                        AI_cs.ServerClick += new EventHandler(AI_CS_Click);
        //                        continue;
        //                    }
        //                }
                                               
        //            }
        //            if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "FE") )
        //            {

        //                for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
        //                {
        //                    if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Shipment Details" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Approval" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Accounts")
        //                    {
        //                        OE_ops.ServerClick += new EventHandler(OE_ops_Click);
        //                        continue;
        //                    }
        //                }

        //            }
        //            if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "FI"))
        //            {

        //                for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
        //                {
        //                    if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Shipment Details" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Approval" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Accounts")
        //                    {
        //                        OI_ops.ServerClick += new EventHandler(OI_ops_Click);
        //                        continue;
        //                    }
        //                }

        //            }
        //            if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "AE"))
        //            {
        //                for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
        //                {
        //                    if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Shipment Details" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Approval" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Accounts")
        //                    {

        //                        AE_ops.ServerClick += new EventHandler(AE_ops_Click);
        //                        continue;
        //                    }
        //                }

        //            }

        //            if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "AI"))
        //            {
        //                for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
        //                {
        //                    if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Shipment Details" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Approval" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Accounts")
        //                    {

        //                        AI_ops.ServerClick += new EventHandler(AI_ops_Click);
        //                        continue;
        //                    }
        //                }

        //            }
        //            if(dt_MenuRights.Rows[i]["trantype"].ToString() == "CH")
        //            {
        //                   CHA.ServerClick += new EventHandler(CHA_Click);
        //                 continue;
        //            }
        //            if (dt_MenuRights.Rows[i]["trantype"].ToString() == "MN")
        //           {
        //                  Maintenance.ServerClick += new EventHandler(Maintenance_Click);
        //                continue;
        //           }

        //            if (dt_MenuRights.Rows[i]["trantype"].ToString() == "BT")
        //            {
        //                  BondedTrucking.ServerClick += new EventHandler(BondedTrucking_Click);
        //                  continue;
        //            }
        //            if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AC")
        //            {
        //                OperatingAccounts.ServerClick += new EventHandler(OperatingAccounts_Click);
        //                continue;
        //            }

        //            if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "FE" || dt_MenuRights.Rows[i]["trantype"].ToString() == "FI" || dt_MenuRights.Rows[i]["trantype"].ToString() == "AE" || dt_MenuRights.Rows[i]["trantype"].ToString() == "AI") )
        //            {
        //                for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
        //                {
        //                    if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "MIS" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Approval" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Sales" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Utility" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Operation MIS")
        //                    {

        //                        MIS.ServerClick += new EventHandler(MIS_Click);
        //                        continue;
        //                    }
        //                }

        //            }
        //        }
        //        OI_CS.ServerClick += new EventHandler(OI_CS_Click);
        //        OE_CS.ServerClick += new EventHandler(OE_CS_Click);

        //        //Ops_Doc.ServerClick += new EventHandler(Ops_Doc_Click);

        //      //  Hr.ServerClick += new EventHandler(Hr_Click);

        //        if (!IsPostBack)
        //        {
        //            fn_GrdLoadNews();
        //            Fn_Loaddetail();
        //            Fn_Loaddetailemployee();
        //            Fn_Loaddetailwelfare();
        //            fn_loaddetailsothers();
        //            //Txt_IncomeTax.Text = "INCOME TAX";
        //            //Txt_ProAppr.Text = "Probation Apprasial";
        //            //Txt_Annu.Text = "Annual Performance Appraisal";
        //            //Txt_Sug.Text = "Suggestion Policy";
        //            //Txt_IncPoli.Text = "Incentive Policy";
        //            //Txt_GrivPoli.Text = "Grievance Policy";
        //            //txt_grplifeins.Text = "Group term life insurance";
        //            //TextBox1.Text = "VMA";
        //            //  fn_loaditpolicy();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }

        //}
        bool fayearflag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //  ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(mastercustomer);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "left_menu();", true);
            if (Request.QueryString.ToString().Contains("fayear"))
            {
                fayearflag = true;
                ddl_FAYear.SelectedItem.Text = Request.QueryString["fayear"].ToString();
                FAccounts_Click(sender, e);
            }
            else
            {
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
                            string str_dispyearnew = "";
                            if (Session["countryid"].ToString() == "1102" || Session["countryid"].ToString() == "102")
                            {
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
                                for (int i = 2023; i < dt_Date.Year; i++)
                                {
                                    str_dispyearnew = Convert.ToString(i);
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
                                    //str_dispyear = str_dispyearnew;
                                    ddl_FAYear.Items.Add(str_dispyearnew);

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
                            Session["Vouyear"] = dt_Date.Year;
                            VouYear = dt_Date.Year;
                            Alogyear = VouYear;
                            Session["Alogyear"] = Alogyear;
                            string str_dispyear = "";
                            string str_dispyearnew = "";
                            if (Session["countryid"].ToString() == "1102" || Session["countryid"].ToString() == "102")
                            {
                                for (int i = 2023; i < dt_Date.Year; i++)
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

                                    //if (i == VouYear)
                                    //{
                                    //    ddl_FAYear.Text = str_dispyear;
                                    //    Session["LYEAR"] = ddl_FAYear.Text;
                                    //    Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                                    //}
                                }
                            }
                            else
                            {


                                for (int i = 2023; i <= dt_Date.Year; i++)
                                {
                                    str_dispyearnew = Convert.ToString(i);
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
                                    //str_dispyear = str_dispyearnew;
                                    ddl_FAYear.Items.Add(str_dispyearnew);

                                    if (i == VouYear)
                                    {
                                        //ddl_FAYear.Text = str_dispyear;
                                        ddl_FAYear.Text = str_dispyearnew;
                                        Session["LYEAR"] = ddl_FAYear.Text;
                                        Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //Session["Vouyear"] = dt_Date.Year;
                        //VouYear = dt_Date.Year;
                        //Alogyear = VouYear;
                        //Session["Alogyear"] = Alogyear;
                        //string str_dispyear = "";
                        //for (int i = 2012; i <= dt_Date.Year; i++)
                        //{
                        //    str_dispyear = Convert.ToString(i);
                        //    str_dispyear = str_dispyear.Substring(2, 2);
                        //    int dy;
                        //    string dy1 = "";

                        //    dy = Convert.ToInt32(str_dispyear) + 1;

                        //    if (dy < 10)
                        //    {l
                        //        dy1 = dy1 + "0" + Convert.ToString(dy);
                        //    }
                        //    else
                        //    {
                        //        dy1 = Convert.ToString(dy);

                        //    }
                        //    str_dispyear = str_dispyear + "-" + dy1;
                        //    Session["str_dispyear"] = str_dispyear;
                        //    ddl_FAYear.Items.Add(str_dispyear);
                        //}
                        //ddl_FAYear.Text = favouyearddl;
                        //Session["LYEAR"] = favouyearddl;

                        if (dt_Date.Month < 4)
                        {
                            Session["Vouyear"] = dt_Date.Year - 1;
                            VouYear = dt_Date.Year - 1;
                            Alogyear = VouYear;
                            Session["Alogyear"] = Alogyear;
                            string str_dispyear = "";
                            string str_dispyearnew = "";
                            if (Session["countryid"].ToString() == "1102" || Session["countryid"].ToString() == "102")
                            {
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
                                for (int i = 2023; i < dt_Date.Year; i++)
                                {
                                    str_dispyearnew = Convert.ToString(i);
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
                                    //str_dispyear = str_dispyearnew;
                                    ddl_FAYear.Items.Add(str_dispyearnew);

                                    //if (i == VouYear)
                                    //{
                                    //    ddl_FAYear.Text = str_dispyear;
                                    //    Session["LYEAR"] = ddl_FAYear.Text;
                                    //    Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                                    //}
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
                            string str_dispyearnew = "";
                            if (Session["countryid"].ToString() == "1102" || Session["countryid"].ToString() == "102")
                            {
                                for (int i = 2022; i <= dt_Date.Year; i++)
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
                                for (int i = 2023; i <= dt_Date.Year; i++)
                                {

                                    str_dispyearnew = Convert.ToString(i);
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
                                    //str_dispyear = str_dispyearnew;
                                    ddl_FAYear.Items.Add(str_dispyearnew);

                                    //if (i == VouYear)
                                    //{
                                    //    ddl_FAYear.Text = str_dispyear;
                                    //    Session["LYEAR"] = ddl_FAYear.Text;
                                    //    Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                                    //}
                                }
                            }
                        }
                        ddl_FAYear.Text = favouyearddl;
                        Session["LYEAR"] = favouyearddl;
                    }
                    //chart
                    loadgrd();
                    line();
                    piechar();

                }
            }
            try
            {
                dt_MenuRights = obj_UP.Getmodule(Convert.ToInt16(Session["LoginEmpId"].ToString()), Convert.ToInt16(Session["LoginBranchid"].ToString()));
                if (dt_MenuRights.Rows.Count > 0)
                {
                    Session["Datarights"] = dt_MenuRights;
                }
                for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                {

                    if (dt_MenuRights.Rows[i]["trantype"].ToString() == "CRM")
                    {
                        CRM.ServerClick += new EventHandler(CRM_Click);
                        if (Session["CRMM"] != null)
                        {
                            Session["CRMM"] = null;
                            CRM_Click(sender, e);
                            return;
                        }
                        continue;
                    }
                    if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FE")
                    {
                        for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                        {
                            if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "CRM")
                            {
                                OE_CSs.ServerClick += new EventHandler(OE_CSs_Click);
                                if (Session["OE_CSs"] != null)
                                {
                                    Session["OE_CSs"] = null;
                                    OE_CSs_Click(sender, e);
                                    return;
                                }
                                continue;
                            }
                        }

                    }
                    if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "FE" || dt_MenuRights.Rows[i]["trantype"].ToString() == "FI" || dt_MenuRights.Rows[i]["trantype"].ToString() == "AE" || dt_MenuRights.Rows[i]["trantype"].ToString() == "AI"))
                    {
                        for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                        {
                            if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Sales")
                            {
                                Sales.ServerClick += new EventHandler(Sales_Click);
                                if (Session["sales"] == "sales")
                                {
                                    Session["sales"] = null;
                                    Sales_Click(sender, e);
                                    return;
                                }
                                continue;
                            }
                        }

                    }
                    if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FI")
                    {
                        for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                        {
                            if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "CRM")
                            {
                                OI_CSs.ServerClick += new EventHandler(OI_CSs_Click);
                                if (Session["OI_CSs"] != null)
                                {
                                    Session["OI_CSs"] = null;
                                    OI_CSs_Click(sender, e);
                                    return;
                                }

                                continue;
                            }
                        }

                    }
                    if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AE")
                    {
                        for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                        {
                            if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "CRM")
                            {
                                AE_CS.ServerClick += new EventHandler(AE_CS_Click);
                                if (Session["AE_CS"] != null)
                                {
                                    Session["AE_CS"] = null;
                                    AE_CS_Click(sender, e);
                                    return;
                                }

                                continue;
                            }
                        }

                    }
                    if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AI")
                    {
                        for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                        {
                            if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "CRM")
                            {
                                AI_cs.ServerClick += new EventHandler(AI_CS_Click);
                                if (Session["AI_cs"] != null)
                                {
                                    Session["AI_cs"] = null;
                                    AI_CS_Click(sender, e);
                                    return;
                                }

                                continue;
                            }
                        }

                    }
                    if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "FE"))
                    {

                        for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                        {
                            if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Shipment Details" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Approval" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Accounts")
                            {
                                OE_ops.ServerClick += new EventHandler(OE_ops_Click);
                                if (Session["OE_ops"] != null)
                                {
                                    Session["OE_ops"] = null;
                                    OE_ops_Click(sender, e);
                                    return;
                                }
                                continue;
                            }
                        }

                    }
                    if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "FI"))
                    {

                        for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                        {
                            if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Shipment Details" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Approval" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Accounts")
                            {
                                OI_ops.ServerClick += new EventHandler(OI_ops_Click);
                                if (Session["OI_ops"] != null)
                                {
                                    Session["OI_ops"] = null;
                                    OI_ops_Click(sender, e);
                                    return;
                                }
                                continue;
                            }
                        }

                    }
                    if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "AE"))
                    {
                        for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                        {
                            if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Shipment Details" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Approval" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Accounts")
                            {

                                AE_ops.ServerClick += new EventHandler(AE_ops_Click);
                                if (Session["AE_ops"] != null)
                                {
                                    Session["AE_ops"] = null;
                                    AE_ops_Click(sender, e);
                                    return;
                                }
                                continue;
                            }
                        }

                    }

                    if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "AI"))
                    {
                        for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                        {
                            if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Shipment Details" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Approval" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Accounts")
                            {

                                AI_ops.ServerClick += new EventHandler(AI_ops_Click);
                                if (Session["AI_ops"] != null)
                                {
                                    Session["AI_ops"] = null;
                                    AI_ops_Click(sender, e);
                                    return;
                                }
                                continue;
                            }
                        }

                    }
                    if (dt_MenuRights.Rows[i]["trantype"].ToString() == "CH")
                    {
                        CHA.ServerClick += new EventHandler(CHA_Click);
                        if (Session["CHA"] != null)
                        {
                            Session["CHA"] = null;
                            CHA_Click(sender, e);
                            return;
                        }
                        continue;
                    }
                    if (dt_MenuRights.Rows[i]["trantype"].ToString() == "MN")
                    {
                        if (Session["LoginBranchName"].ToString() == "CORPORATE")
                        {

                            Maintenance.ServerClick += new EventHandler(Maintenance_Click);
                            continue;
                        }
                        else

                        {
                            for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                            {
                                if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Systems" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Master")
                                {
                                    Maintenance.ServerClick += new EventHandler(Maintenance_Click);
                                    if (Session["COMaintenance"] != null)
                                    {
                                        Session["COMaintenance"] = null;
                                        Maintenance_Click(sender, e);
                                        return;
                                    }
                                    continue;
                                }
                            }
                        }

                    }

                    if (dt_MenuRights.Rows[i]["trantype"].ToString() == "BT")
                    {
                        BondedTrucking.ServerClick += new EventHandler(BondedTrucking_Click);
                        if (Session["BondedTrucking"] != null)
                        {
                            Session["BondedTrucking"] = null;
                            BondedTrucking_Click(sender, e);
                            return;
                        }
                        continue;
                    }
                    if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AC")
                    {
                        OperatingAccounts.ServerClick += new EventHandler(OperatingAccounts_Click);
                        if (Session["OperatingAccounts"] != null)
                        {
                            Session["OperatingAccounts"] = null;
                            OperatingAccounts_Click(sender, e);
                            return;
                        }
                        continue;
                    }

                    if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FA")
                    {
                        FAccounts.ServerClick += new EventHandler(FAccounts_Click);

                        if (Session["FAAccounts"] != null)
                        {
                            Session["FAAccounts"] = null;
                            FAccounts_Click(sender, e);
                            return;
                        }
                        continue;
                    }

                    if ((dt_MenuRights.Rows[i]["trantype"].ToString() == "FE" || dt_MenuRights.Rows[i]["trantype"].ToString() == "FI" || dt_MenuRights.Rows[i]["trantype"].ToString() == "AE" || dt_MenuRights.Rows[i]["trantype"].ToString() == "AI"))
                    {
                        for (int j = 0; j < dt_MenuRights.Rows.Count; j++)
                        {
                            if (dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "MIS" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Approval" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Sales" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Utility" || dt_MenuRights.Rows[j]["menuname"].ToString().Trim() == "Operation MIS")
                            {

                                MIS.ServerClick += new EventHandler(MIS_Click);
                                if (Session["MIS"] != null)
                                {
                                    Session["MIS"] = null;
                                    MIS_Click(sender, e);
                                    return;
                                }
                                continue;
                            }
                        }

                    }
                }
                OI_CS.ServerClick += new EventHandler(OI_CS_Click);
                OE_CS.ServerClick += new EventHandler(OE_CS_Click);

                //Ops_Doc.ServerClick += new EventHandler(Ops_Doc_Click);

                //  Hr.ServerClick += new EventHandler(Hr_Click);

                if (!IsPostBack)
                {
                    fn_GrdLoadNews();
                    Fn_Loaddetail();
                    Fn_Loaddetailemployee();
                    Fn_Loaddetailwelfare();
                    fn_loaddetailsothers();
                    //Txt_IncomeTax.Text = "INCOME TAX";
                    //Txt_ProAppr.Text = "Probation Apprasial";
                    //Txt_Annu.Text = "Annual Performance Appraisal";
                    //Txt_Sug.Text = "Suggestion Policy";
                    //Txt_IncPoli.Text = "Incentive Policy";
                    //Txt_GrivPoli.Text = "Grievance Policy";
                    //txt_grplifeins.Text = "Group term life insurance";
                    //TextBox1.Text = "VMA";
                    //  fn_loaditpolicy();
                }
                if (Session["Process1"].ToString() == "SALES")
                {
                    Sales_Click(sender, e);
                }
                else if (Session["Process1"].ToString() == "OCEAN EXPORTS")
                {
                    OE_ops_Click(sender, e);
                }
                else if (Session["Process1"].ToString() == "OCEAN IMPORTS")
                {
                    OI_ops_Click(sender, e);
                }
                else if (Session["Process1"].ToString() == "AIR IMPORTS")
                {
                    AI_ops_Click(sender, e);

                }
                else if (Session["Process1"].ToString() == "AIR EXPORTS")
                {
                    AE_ops_Click(sender, e);
                }
                else if (Session["Process1"].ToString() == "MIS & ANALYTICS")
                {
                    MIS_Click(sender, e);

                }
                else if (Session["Process1"].ToString() == "FINANCIAL ACCOUNTS")
                {
                    FAccounts_Click(sender, e);
                }

                  if (Session["Process"].ToString() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", ";window.open('../LOGIN.aspx','_top');", true);

                }
                //else
                //{
                //    Response.Redirect("FormMain.aspx?homenull");
                //}
                //if (Session["Process"].ToString() == "")
                //{
                //    string home;
                //    if (Session["home"] != null)
                //    {
                //        if (Session["home"] != null)
                //        {
                //            if (Session["home"].ToString() == "SA")
                //            {
                //                Response.Redirect("Home/SalesHome.aspx");
                //                //ifrmaster.Attributes["src"] = "Home/SalesHome.aspx";
                //            }
                //            else if (Session["home"].ToString() == "MIS")
                //            {
                //                Response.Redirect("Home/MISAndApproval.aspx");
                //                //ifrmaster.Attributes["src"] = "Home/MISAndApproval.aspx";
                //            }
                //            else if (Session["home"].ToString() == "FABR")
                //            {
                //                ifrmaster.Attributes["src"] = "Mainpage/Main_Branch.aspx";
                //            }

                //            else if (Session["home"].ToString() == "FABR")
                //            {
                //                ifrmaster.Attributes["src"] = "Mainpage/Main_Branch.aspx";
                //            }
                //        }
                //        if (Session["StrTranType"] != null)
                //        {
                //            if (Session["StrTranType"].ToString() == "FE")
                //            {
                //                if (Session["home"].ToString() != null)
                //                {
                //                    home = Session["home"].ToString();
                //                    if (home == "OPS&DOC")
                //                    {
                //                        Response.Redirect("Home/OEOpsAndDocs.aspx");
                //                       //ifrmaster.Attributes["src"] = "Home/OEOpsAndDocs.aspx";
                //                    }
                //                    else if (home == "CS")
                //                    {
                //                        ifrmaster.Attributes["src"] = "Mainpage/OceanExportsCustomerSupport.aspx";
                //                    }
                //                }
                //                //ifrmaster.Attributes["src"] = "Mainpage/OceanExports.aspx";
                //            }

                //            else if (Session["StrTranType"].ToString() == "FI")
                //            {
                //                if (Session["home"].ToString() != null)
                //                {
                //                    home = Session["home"].ToString();
                //                    if (home == "OPS&DOC")
                //                    {
                //                        Response.Redirect("Home/OEOpsAndDocs.aspx");
                //                    }
                //                    else if (home == "CS")
                //                    {
                //                        ifrmaster.Attributes["src"] = "Mainpage/OceanImportsCustomerSupport.aspx";
                //                    }
                //                }
                //                //ifrmaster.Attributes["src"] = "Mainpage/OceanImportsDocked.aspx";
                //            }
                //            else if (Session["StrTranType"].ToString() == "AE")
                //            {
                //                if (Session["home"].ToString() != null)
                //                {
                //                    home = Session["home"].ToString();
                //                    if (home == "OPS&DOC")
                //                    {
                //                        Response.Redirect("Home/OEOpsAndDocs.aspx");
                //                    }
                //                    else if (home == "CS")
                //                    {
                //                        ifrmaster.Attributes["src"] = "Mainpage/AECustomerSupport.aspx";
                //                    }
                //                }
                //                //ifrmaster.Attributes["src"] = "Mainpage/AEDocked.aspx";
                //            }
                //            else if (Session["StrTranType"].ToString() == "AI")
                //            {
                //                if (Session["home"].ToString() != null)
                //                {
                //                    home = Session["home"].ToString();
                //                    if (home == "OPS&DOC")
                //                    {
                //                        Response.Redirect("Home/OEOpsAndDocs.aspx");
                //                    }
                //                    else if (home == "CS")
                //                    {
                //                        ifrmaster.Attributes["src"] = "Mainpage/AICustomerSupport.aspx";
                //                    }
                //                }
                //                //ifrmaster.Attributes["src"] = "Mainpage/AIDocked.aspx";
                //            }
                //            else if (Session["StrTranType"].ToString() == "AC")
                //            {
                //                if (Session["home"].ToString() != null)
                //                {
                //                    home = Session["home"].ToString();
                //                    if (home == "FABR")
                //                    {
                //                        ifrmaster.Attributes["src"] = "Mainpage/Main_Branch.aspx";
                //                    }

                //                }
                //                //ifrmaster.Attributes["src"] = "Mainpage/AIDocked.aspx";
                //            }
                //            else if (Session["StrTranType"].ToString() == "CO")
                //            {

                //                if (Session["StrTranType1"] != null)
                //                {
                //                    if (Session["StrTranType1"].ToString() == "AccountandFinanceCor")
                //                    {
                //                        ifrmaster.Attributes["src"] = "CorMainPage/Accounts_and_finanace_Docked.aspx";
                //                    }
                //                    else if (Session["StrTranType1"].ToString() == "BudgetCor")
                //                    {
                //                        ifrmaster.Attributes["src"] = "CorMainPage/Budget_Docked.aspx";
                //                    }
                //                    else if (Session["StrTranType1"].ToString() == "CreditControlcor")
                //                    {
                //                        ifrmaster.Attributes["src"] = "CorMainPage/Credit_Control_Docked.aspx";
                //                    }
                //                    else if (Session["StrTranType1"].ToString() == "MISandAnalysisCor")
                //                    {
                //                        ifrmaster.Attributes["src"] = "CorMainPage/MIS_and_Analysis_Docked.aspx";
                //                    }
                //                    else if (Session["StrTranType1"].ToString() == "Utilitycor")
                //                    {
                //                        ifrmaster.Attributes["src"] = "CorMainPage/Utility_Docked.aspx";
                //                    }
                //                    else if (Session["StrTranType1"].ToString() == "CRMcor")
                //                    {
                //                        ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
                //                    }
                //                    else if (Session["StrTranType1"].ToString() == "MCor")
                //                    {
                //                        ifrmaster.Attributes["src"] = "MainPage/MaintenanceDockedPanel.aspx";
                //                    }
                //                    else if (Session["StrTranType1"].ToString() == "HRCor")
                //                    {
                //                        ifrmaster.Attributes["src"] = "MainPage/HRMDocked.aspx";
                //                    }
                //                    else if (Session["StrTranType1"].ToString() == "FCCO")
                //                    {
                //                        ifrmaster.Attributes["src"] = "MainPage/Main_Corporate.aspx";
                //                    }
                //                }


                //                else
                //                {
                //                    ifrmaster.Attributes["src"] = "Cor_MainModuleNew.aspx";
                //                }
                //            }

                //        }

                //    }
                //    else if (Session["StrTranType"] != null)
                //    {
                //        if (Session["StrTranType"].ToString() == "CH")
                //        {
                //            ifrmaster.Attributes["src"] = "Mainpage/CHADocked.aspx";
                //        }
                //        else if (Session["StrTranType"].ToString() == "BT")
                //        {
                //            ifrmaster.Attributes["src"] = "Mainpage/BondedTruckingDocked.aspx";
                //        }
                //        else if (Session["StrTranType"].ToString() == "AC")
                //        {
                //            ifrmaster.Attributes["src"] = "Mainpage/AccountsDocked.aspx";
                //        }

                //        else if (Session["StrTranType"].ToString() == "CRM")
                //        {
                //            ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
                //        }

                //        else if (Session["StrTranType"].ToString() == "HR")
                //        {
                //            ifrmaster.Attributes["src"] = "Mainpage/HRMDocked.aspx";
                //        }
                //        else if (Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "MN")
                //        {
                //            ifrmaster.Attributes["src"] = "MainPage/MaintenanceDockedPanel.aspx";
                //        }

                //        if (Session["StrTranType"].ToString() == "CO")
                //        {

                //            if (Session["StrTranType1"] != null)
                //            {
                //                if (Session["StrTranType1"].ToString() == "AccountandFinanceCor")
                //                {
                //                    ifrmaster.Attributes["src"] = "CorMainPage/Accounts_and_finanace_Docked.aspx";
                //                }
                //                else if (Session["StrTranType1"].ToString() == "BudgetCor")
                //                {
                //                    ifrmaster.Attributes["src"] = "CorMainPage/Budget_Docked.aspx";
                //                }
                //                else if (Session["StrTranType1"].ToString() == "CreditControlcor")
                //                {
                //                    ifrmaster.Attributes["src"] = "CorMainPage/Credit_Control_Docked.aspx";
                //                }
                //                else if (Session["StrTranType1"].ToString() == "MISandAnalysisCor")
                //                {
                //                    ifrmaster.Attributes["src"] = "CorMainPage/MIS_and_Analysis_Docked.aspx";
                //                }
                //                else if (Session["StrTranType1"].ToString() == "Utilitycor")
                //                {
                //                    ifrmaster.Attributes["src"] = "CorMainPage/Utility_Docked.aspx";
                //                }
                //                else if (Session["StrTranType1"].ToString() == "CRMcor")
                //                {
                //                    ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
                //                }
                //                else if (Session["StrTranType1"].ToString() == "MCor")
                //                {
                //                    ifrmaster.Attributes["src"] = "MainPage/MaintenanceDockedPanel.aspx";
                //                }
                //            }


                //            else
                //            {
                //                ifrmaster.Attributes["src"] = "Cor_MainModuleNew.aspx";
                //            }
                //        }
                //        //else if (Session["StrTranType"].ToString() == "HR")
                //        //{
                //        //    ifrmaster.Attributes["src"] = "MainPage/HRMDocked.aspx";
                //        //}
                //    }
                //    else
                //    {
                //        Session["iframeid"] = "Home";
                //        ifrmaster.Attributes["src"] = "Mainmodule_product.aspx";
                //    }
                //}

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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
                    grd.DataSource = dt_ok;
                    grd.DataBind();
                    for(int i=0;i<dt_ok.Rows.Count;i++)
                    {
                        news.InnerText += dt_ok.Rows[i]["news"].ToString() + " | " ;
                    }
                }
                else
                {
                    grd.DataSource = dt_ok;
                    grd.DataBind();
                    news.InnerText = "";
                }
              
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
                    TextBox2.Text = obj_dt.Rows[0][12].ToString();
                }
            }
           
        }

        private void Fn_Loaddetailwelfare()
        {
            DataAccess.HR.CompanyProfile obj_da_CompanyProfile = new DataAccess.HR.CompanyProfile();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_CompanyProfile.GetCompanyProfile(3);
            if (obj_dt.Rows.Count > 0)
            {
               
                txt_Group.Text = obj_dt.Rows[0][0].ToString();
               
                //txt_Leavewelfare.Text = obj_dt.Rows[0][1].ToString();
                txt_Wedding.Text = obj_dt.Rows[0][2].ToString();
                txt_Referral.Text = obj_dt.Rows[0][3].ToString();
                if (!string.IsNullOrEmpty(obj_dt.Rows[0][5].ToString()))
                {
                    txt_grplifeins.Text = obj_dt.Rows[0][5].ToString();
                }
            }
           
        }

        public void CRM_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "CRM";
            Session["home"] = null;
            Response.Redirect("MainPage/CRMDocked.aspx");

        }
        public void Sales_Click(object sender, EventArgs e)
         {
           // Session["Process"] = "Sales";

            //Session["StrTranType"] = "SA";
            Session["home"] = "SA";
            Response.Redirect("MainPage/SalesDocked.aspx");

        }
        public void OE_CS_Click(object sender, EventArgs e)
        {
            demo.Visible = true;
            demo1.Visible = false;
        }
        public void OE_CSs_Click(object sender, EventArgs e)
        {
            Session["home"] = "CS";
            Session["StrTranType"] = "FE";
            Response.Redirect("MainPage/OceanExportsCustomerSupport.aspx");

        }
        public void OI_CSs_Click(object sender, EventArgs e)
        {
            Session["home"] = "CS";
            Session["StrTranType"] = "FI";
            Response.Redirect("MainPage/OceanImportsCustomerSupport.aspx");

        }
        public void Ops_Doc_Click(object sender, EventArgs e)
        {

            Session["home"] = "OPS&DOC";
            
            //Response.Redirect("MainPage/OceanExportsCustomerSupport.aspx");

        }
        public void OI_CS_Click(object sender, EventArgs e)
        {

            Session["home"] = "OPS&DOC";
            demo.Visible = false;
            demo1.Visible = true;

        }
        public void AE_CS_Click(object sender, EventArgs e)
        {
            Session["home"] = "CS";
            Session["StrTranType"] = "AE";
            Response.Redirect("MainPage/AECustomerSupport.aspx");

        }

        public void AI_CS_Click(object sender, EventArgs e)
        {
            Session["home"] = "CS";
            Session["StrTranType"] = "AI";
            Response.Redirect("MainPage/AICustomerSupport.aspx");
            
        }
        public void OE_ops_Click(object sender, EventArgs e)
        {
            Session["home"] = "OPS&DOC";
            Session["StrTranType"] = "FE";
           // Session["Process"] = "Ocean Export";
            Response.Redirect("MainPage/OceanExportsOps_Docs.aspx");
          
        }
        public void OI_ops_Click(object sender, EventArgs e)
        {
            Session["home"] = "OPS&DOC";
            Session["StrTranType"] = "FI";
           // Session["Process"] = "Ocean Import";
            Response.Redirect("MainPage/OceanImports_ops.aspx");           

        }
        public void AE_ops_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "AE";
            Session["home"] = "OPS&DOC";
          //  Session["Process"] = "Air Export";
            Response.Redirect("MainPage/AirExports_ops.aspx");

        }
        public void AI_ops_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "AI";
            Session["home"] = "OPS&DOC";
         //   Session["Process"] = "Air Import";
            Response.Redirect("MainPage/AirImports_ops.aspx");

        }
        public void CHA_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "CH";
            Session["home"] = null;
            Response.Redirect("MainPage/CHADocked.aspx");
        }

        public void BondedTrucking_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "BT";
            Session["home"] = null;
            Response.Redirect("MainPage/BondedTruckingDocked.aspx");
        }

        public void OperatingAccounts_Click(object sender, EventArgs e)
        {
           
            Session["StrTranType"] = "AC";
            Session["home"] = null;
            Session["HeadTranType"] = "AC";
            Response.Redirect("MainPage/AccountsDocked.aspx");
        }

        public void FAccounts_Click(object sender, EventArgs e)
        {
            if(Session["countryid"].ToString()=="1102"|| Session["countryid"].ToString() == "102")
            {
                ddl_FAYear.SelectedItem.Text = "23-24";
                fn_GetFADB_old();
                
                Session["LogYear"] = "20" + ddl_FAYear.SelectedItem.Text.ToString().Substring(0, 2);
                Session["Vouyear"] = "20" + ddl_FAYear.SelectedItem.Text.ToString().Substring(0, 2);
            }
            else
            {
                fn_GetFADB();
                ddl_FAYear.SelectedItem.Text = "2023";
                Session["LogYear"] = ddl_FAYear.SelectedItem.Text;
                Session["Vouyear"] = ddl_FAYear.SelectedItem.Text;
            }
            
            Session["FA_Year"] = ddl_FAYear.SelectedItem.Text;
            Session["LYEAR"] = ddl_FAYear.SelectedItem.Text;
               
            Session["StrTranType"] = "BR";
            Session["HeadTranType"] = "FA";
            Session["home"] = "FABR";

            Response.Redirect("MainPage/Main_Branch.aspx");
        }
        public void MIS_Click(object sender, EventArgs e)
        {

            //Session["StrTranType"] = "MIS";//OECSHome
            Session["home"] = "MIS";
            Response.Redirect("MainPage/MIS_ApprovalDock.aspx");
        }

        public void Hr_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "HR";
            Session["home"] = null;
            Response.Redirect("MainPage/HRMDocked.aspx");
        }

        public void Maintenance_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "MN";
            Session["home"] = null;
            Response.Redirect("MainPage/MaintenanceDockedPanel.aspx");
        }

        protected void br_Mainten_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = "MN";
            Session["home"] = null;
            Response.Redirect("MainPage/MaintenanceDockedPanel.aspx");
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

               e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            if (grd.Rows.Count > 0)
            {
                index = grd.SelectedIndex;
                Label l1 = (Label)grd.Rows[index].Cells[1].FindControl("title");
                txttitle.Text = l1.Text;
                txtNews.Text = HttpUtility.HtmlDecode(grd.Rows[index].Cells[3].Text).Replace("&AMP;", "&");
                txtpost.Text = grd.Rows[index].Cells[2].Text;
                popup_KPI.Show();
            }
        }

        protected void lbl_mastercustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("Maintenance/MasterCustomerNEWUPDATE.aspx");
        }


        private void fn_GetFADB()
        {
            string str_FAYear = "";
            string str_FADbname = "";
            string str_FADbnameNEW = "";

            //  BHUVI 30082022
            string str_dispyear = "";
            //"23-24"
            if (ddl_FAYear.Text == "0")
            {
                str_dispyear = Convert.ToString("2023");
            }
            else
            {
                str_dispyear = Convert.ToString(ddl_FAYear.Text);
            }

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
            // BHUVI END

            //  str_FAYear = ddl_FAYear.Text;
                Session["LYEAR"] = ddl_FAYear.Text;
            Session["FALYEAR"] = str_dispyear;
            //      str_FAYear = str_FAYear.Replace("-", "");
            str_dispyear = str_dispyear.Replace("-", "");  //BHUVI
            //  str_FADbname = "FA" + str_FAYear;

            str_FADbnameNEW = "FA" + str_dispyear;
            //str_FADbname = "DemoFA" + str_FAYear;
            //   Session["FADbname"] = str_FADbname;

            Session["FADbname"] = str_FADbnameNEW;
        }

        private void fn_GetFADB_old()
        {
            string str_FAYear = "";
            string str_FADbname = "";
            ddl_FAYear.Text = "23-24";
            str_FAYear = "23-24";
            Session["LYEAR"] = "23-24";
            str_FAYear = str_FAYear.Replace("-", "");
            str_FADbname = "FA" + str_FAYear;
            //str_FADbname = "DemoFA" + str_FAYear;
            Session["FADbname"] = str_FADbname;
        }
        //chart
        public void line()
        {

            DataTable dt0 = new DataTable();
            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
            dt0 = da_obj_misgrd.getunclosejobandclosedcount(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
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
            str.Append(" chart.draw(data, {width: '100%',height:200,");
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

            dt0 = Appobj.getunclosejobcount(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
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
          
            str1.Append(" chart.draw(data1, {width: '100%',height:250,");
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