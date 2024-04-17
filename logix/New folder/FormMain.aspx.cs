using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix
{
    public partial class FormMain : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataTable Cid = new DataTable();
        DataAccess.Masters.MasterEmployee employee = new DataAccess.Masters.MasterEmployee();
        DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();
        string username;
        DataAccess.Masters.MasterExRate EXobj = new DataAccess.Masters.MasterExRate();
        DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
        string bmmail, bmmailid, rmmailid, strcompanyaddress;
        DataAccess.Masters.MasterBranch objbid = new DataAccess.Masters.MasterBranch();
        DataAccess.HR.FrontPage FrontpageObj = new DataAccess.HR.FrontPage();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        int VouYear, Alogyear;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Process"].ToString() != "")
            //{
            //    lnkbtn.Text = Session["Process"].ToString();

            //}
            //else
            //{
            //    lnkbtn.Text = "PRODUCT NAME";
            //    lnkbtn.Visible = true;
            //}
            

            Cid = da_obj_Logobj.Forcountryid(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (Cid.Rows.Count>0)
            {
                Session["countryid"] = Cid.Rows[0][0].ToString();
            }
            if (Session["countryid"].ToString() != "1102" && Session["countryid"].ToString() != "102")
            {
                br_Mainten.Visible = true;
                if (Session["LoginDivisionName"].ToString() == "FORWARDING PRIVATE LTD")
                {
                    MISandAnalysis.Visible = false;
                    FCAC.Visible = false;
                }
            }
            else
            {
                br_Mainten.Visible = false;


                MISandAnalysis.Visible = true;
                FCAC.Visible = true;
            }
            if (!IsPostBack)
            {
                if (Session["LoginBranchName"].ToString() == "CORPORATE")

                {
                    if ( Session["Processcor"].ToString() == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", ";window.open('../LOGIN.aspx','_top');", true);
                        return;
                    }
                }
                else
                {
                    if (Session["Process"].ToString() == "" )
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", ";window.open('../LOGIN.aspx','_top');", true);
                        return;
                    }

                }

                if (Session["countryid"].ToString() != "1102" && Session["countryid"].ToString() != "102")
                {
                    br_Mainten.Visible = true;
                    if (Session["LoginDivisionName"].ToString() == "FORWARDING PRIVATE LTD")
                    {
                        MISandAnalysis.Visible = false;
                        FCAC.Visible = false;
                    }
                }
                else
                {
                    br_Mainten.Visible = false;


                    MISandAnalysis.Visible = true;
                    FCAC.Visible = true;
                }
                DateTime dt_Date = da_obj_Log.GetDate();
                Session["TodayDate"] = dt_Date;
                if (Session["LoginBranchName"] != null)
                {
                    brname.Text = Session["LoginBranchName"].ToString();
                    
                    empname.Text = Session["LoginEmpName"].ToString();
                    if (Session["Process"].ToString() != "")
                    {
                        lnkbtn.Text = Session["Process"].ToString();
                    }
                    if (Session["Processcor"]!=null)
                    {
                        Linkcorpor.Text = Session["Processcor"].ToString();
                    }
                    //if (Session["LoginBranchName"].ToString() == "CORPORATE")
                    //{
                        Linkcorpor.Visible = true;
                        Linkcorpor.Text = Session["Processcor"].ToString();
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
                                    ddl_FCYear.Items.Add(str_dispyear);

                                    if (i == VouYear)
                                    {
                                        ddl_FCYear.Text = str_dispyear;
                                        Session["LYEAR"] = ddl_FCYear.Text;
                                        Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 2023; i < dt_Date.Year; i++)
                                {
                                    str_dispyear = Convert.ToString(i);
                                    str_dispyearnew = Convert.ToString(i);
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
                                    // str_dispyear = str_dispyearnew;
                                    ddl_FCYear.Items.Add(str_dispyearnew);

                                    if (i == VouYear)
                                    {
                                        ddl_FCYear.Text = str_dispyearnew;
                                        Session["LYEAR"] = ddl_FCYear.Text;
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
                                for (int i = 2023; i <= dt_Date.Year; i++)
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
                                    ddl_FCYear.Items.Add(str_dispyear);

                                    if (i == VouYear)
                                    {
                                        ddl_FCYear.Text = str_dispyear;
                                        Session["LYEAR"] = ddl_FCYear.Text;
                                        Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 2023; i <= dt_Date.Year; i++)
                                {
                                    str_dispyear = Convert.ToString(i);
                                    str_dispyearnew = Convert.ToString(i);
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
                                    ddl_FCYear.Items.Add(str_dispyearnew);

                                    if (i == VouYear)
                                    {
                                        ddl_FCYear.Text = str_dispyearnew;
                                        Session["LYEAR"] = ddl_FCYear.Text;
                                        Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                                    }
                                }
                            }
                        }
                        if (dt_Date.Month < 4)
                        {
                            lnkbtn.Visible = true;
                            // lnkbtn.Text = Session["Process"].ToString();
                            lnkbtn.Visible = true;
                            Session["Vouyear"] = dt_Date.Year - 1;
                            VouYear = dt_Date.Year - 1;
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
                                    str_dispyear = Convert.ToString(i);
                                    str_dispyearnew = Convert.ToString(i);
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
                                    // str_dispyear = str_dispyearnew;
                                    ddl_FAYear.Items.Add(str_dispyearnew);

                                    if (i == VouYear)
                                    {
                                        ddl_FAYear.Text = str_dispyearnew;
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
                                for (int i = 2023; i <= dt_Date.Year; i++)
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

                                    if (i == VouYear)
                                    {
                                        ddl_FAYear.Text = str_dispyearnew;
                                        Session["LYEAR"] = ddl_FAYear.Text;
                                        Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                                    }
                                }
                            }
                        }

                    //}
                    //else
                    //{
                        ////////////if (dt_Date.Month < 4)
                        ////////////{
                        ////////////    lnkbtn.Visible = true;
                        ////////////    lnkbtn.Text = Session["Process"].ToString();
                        ////////////    lnkbtn.Visible = true;
                        ////////////    Session["Vouyear"] = dt_Date.Year - 1;
                        ////////////    VouYear = dt_Date.Year - 1;
                        ////////////    Alogyear = VouYear;
                        ////////////    Session["Alogyear"] = Alogyear;
                        ////////////    string str_dispyear = "";
                        ////////////    string str_dispyearnew = "";
                        ////////////    if (Session["countryid"].ToString() == "1102" || Session["countryid"].ToString() == "102")
                        ////////////    {
                        ////////////        for (int i = 2023; i < dt_Date.Year; i++)
                        ////////////        {
                        ////////////            str_dispyear = Convert.ToString(i);
                        ////////////            str_dispyear = str_dispyear.Substring(2, 2);
                        ////////////            int dy;
                        ////////////            string dy1 = "";

                        ////////////            dy = Convert.ToInt32(str_dispyear) + 1;

                        ////////////            if (dy < 10)
                        ////////////            {
                        ////////////                dy1 = dy1 + "0" + Convert.ToString(dy);
                        ////////////            }
                        ////////////            else
                        ////////////            {
                        ////////////                dy1 = Convert.ToString(dy);

                        ////////////            }
                        ////////////            str_dispyear = str_dispyear + "-" + dy1;
                        ////////////            Session["str_dispyear"] = str_dispyear;
                        ////////////            ddl_FAYear.Items.Add(str_dispyear);

                        ////////////            if (i == VouYear)
                        ////////////            {
                        ////////////                ddl_FAYear.Text = str_dispyear;
                        ////////////                Session["LYEAR"] = ddl_FAYear.Text;
                        ////////////                Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                        ////////////            }
                        ////////////        }
                        ////////////    }
                        ////////////    else
                        ////////////    {
                        ////////////        for (int i = 2023; i < dt_Date.Year; i++)
                        ////////////        {
                        ////////////            str_dispyearnew = Convert.ToString(i);
                        ////////////            str_dispyear = Convert.ToString(i);
                        ////////////            str_dispyear = str_dispyear.Substring(2, 2);
                        ////////////            int dy;
                        ////////////            string dy1 = "";

                        ////////////            dy = Convert.ToInt32(str_dispyear) + 1;

                        ////////////            if (dy < 10)
                        ////////////            {
                        ////////////                dy1 = dy1 + "0" + Convert.ToString(dy);
                        ////////////            }
                        ////////////            else
                        ////////////            {
                        ////////////                dy1 = Convert.ToString(dy);

                        ////////////            }
                        ////////////            str_dispyear = str_dispyear + "-" + dy1;
                        ////////////            Session["str_dispyear"] = str_dispyear;
                        ////////////            //str_dispyear = str_dispyearnew;
                        ////////////            ddl_FAYear.Items.Add(str_dispyearnew);

                        ////////////            if (i == VouYear)
                        ////////////            {
                        ////////////                ddl_FAYear.Text = str_dispyearnew;
                        ////////////                Session["LYEAR"] = ddl_FAYear.Text;
                        ////////////                Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                        ////////////            }
                        ////////////        }
                        ////////////    }
                        ////////////}
                        ////////////else
                        ////////////{
                        ////////////    Session["Vouyear"] = dt_Date.Year;
                        ////////////    VouYear = dt_Date.Year;
                        ////////////    Alogyear = VouYear;
                        ////////////    Session["Alogyear"] = Alogyear;
                        ////////////    string str_dispyear = "";
                        ////////////    string str_dispyearnew = "";
                        ////////////    if (Session["countryid"].ToString() == "1102" || Session["countryid"].ToString() == "102")
                        ////////////    {
                        ////////////        for (int i = 2023; i <= dt_Date.Year; i++)
                        ////////////        {
                        ////////////            str_dispyear = Convert.ToString(i);
                        ////////////            str_dispyear = str_dispyear.Substring(2, 2);
                        ////////////            int dy;
                        ////////////            string dy1 = "";

                        ////////////            dy = Convert.ToInt32(str_dispyear) + 1;

                        ////////////            if (dy < 10)
                        ////////////            {
                        ////////////                dy1 = dy1 + "0" + Convert.ToString(dy);
                        ////////////            }
                        ////////////            else
                        ////////////            {
                        ////////////                dy1 = Convert.ToString(dy);

                        ////////////            }
                        ////////////            str_dispyear = str_dispyear + "-" + dy1;
                        ////////////            Session["str_dispyear"] = str_dispyear;
                        ////////////            ddl_FAYear.Items.Add(str_dispyear);

                        ////////////            if (i == VouYear)
                        ////////////            {
                        ////////////                ddl_FAYear.Text = str_dispyear;
                        ////////////                Session["LYEAR"] = ddl_FAYear.Text;
                        ////////////                Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                        ////////////            }
                        ////////////        }
                        ////////////    }
                        ////////////    else
                        ////////////    {
                        ////////////        for (int i = 2023; i <= dt_Date.Year; i++)
                        ////////////        {
                        ////////////            str_dispyearnew = Convert.ToString(i);
                        ////////////            str_dispyear = Convert.ToString(i);
                        ////////////            str_dispyear = str_dispyear.Substring(2, 2);
                        ////////////            int dy;
                        ////////////            string dy1 = "";

                        ////////////            dy = Convert.ToInt32(str_dispyear) + 1;

                        ////////////            if (dy < 10)
                        ////////////            {
                        ////////////                dy1 = dy1 + "0" + Convert.ToString(dy);
                        ////////////            }
                        ////////////            else
                        ////////////            {
                        ////////////                dy1 = Convert.ToString(dy);

                        ////////////            }
                        ////////////            str_dispyear = str_dispyearnew;
                        ////////////            str_dispyear = str_dispyear + "-" + dy1;
                        ////////////            Session["str_dispyear"] = str_dispyear;
                        ////////////            //str_dispyear = str_dispyearnew;
                        ////////////            ddl_FAYear.Items.Add(str_dispyearnew);

                        ////////////            if (i == VouYear)
                        ////////////            {
                        ////////////                ddl_FAYear.Text = str_dispyearnew;
                        ////////////                Session["LYEAR"] = ddl_FAYear.Text;
                        ////////////                Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                        ////////////            }
                        ////////////        }
                        ////////////    }
                        ////////////}
                        ////////////if (dt_Date.Month < 4)
                        ////////////{
                        ////////////    Session["Vouyear"] = dt_Date.Year - 1;
                        ////////////    VouYear = dt_Date.Year - 1;
                        ////////////    Alogyear = VouYear;
                        ////////////    Session["Alogyear"] = Alogyear;
                        ////////////    string str_dispyear = "";
                        ////////////    string str_dispyearnew = "";
                        ////////////    if (Session["countryid"].ToString() == "1102" || Session["countryid"].ToString() == "102")
                        ////////////    {
                        ////////////        for (int i = 2023; i < dt_Date.Year; i++)
                        ////////////        {
                        ////////////            str_dispyear = Convert.ToString(i);
                        ////////////            str_dispyear = str_dispyear.Substring(2, 2);
                        ////////////            int dy;
                        ////////////            string dy1 = "";

                        ////////////            dy = Convert.ToInt32(str_dispyear) + 1;

                        ////////////            if (dy < 10)
                        ////////////            {
                        ////////////                dy1 = dy1 + "0" + Convert.ToString(dy);
                        ////////////            }
                        ////////////            else
                        ////////////            {
                        ////////////                dy1 = Convert.ToString(dy);

                        ////////////            }
                        ////////////            str_dispyear = str_dispyear + "-" + dy1;
                        ////////////            Session["str_dispyear"] = str_dispyear;
                        ////////////            ddl_FAYear.Items.Add(str_dispyear);

                        ////////////            if (i == VouYear)
                        ////////////            {
                        ////////////                ddl_FAYear.Text = str_dispyear;
                        ////////////                Session["LYEAR"] = ddl_FAYear.Text;
                        ////////////                Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                        ////////////            }
                        ////////////        }
                        ////////////    }
                        ////////////    else
                        ////////////    {
                        ////////////        for (int i = 2023; i < dt_Date.Year; i++)
                        ////////////        {
                        ////////////            str_dispyearnew = Convert.ToString(i);
                        ////////////            str_dispyear = Convert.ToString(i);
                        ////////////            str_dispyear = str_dispyear.Substring(2, 2);
                        ////////////            int dy;
                        ////////////            string dy1 = "";

                        ////////////            dy = Convert.ToInt32(str_dispyear) + 1;

                        ////////////            if (dy < 10)
                        ////////////            {
                        ////////////                dy1 = dy1 + "0" + Convert.ToString(dy);
                        ////////////            }
                        ////////////            else
                        ////////////            {
                        ////////////                dy1 = Convert.ToString(dy);

                        ////////////            }
                        ////////////            str_dispyear = str_dispyear + "-" + dy1;
                        ////////////            Session["str_dispyear"] = str_dispyear;
                        ////////////            //str_dispyear = str_dispyearnew;
                        ////////////            ddl_FCYear.Items.Add(str_dispyearnew);

                        ////////////            if (i == VouYear)
                        ////////////            {
                        ////////////                ddl_FCYear.Text = str_dispyearnew;
                        ////////////                Session["LYEAR"] = ddl_FCYear.Text;
                        ////////////                Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                        ////////////            }
                        ////////////        }
                        ////////////    }
                        ////////////}
                        ////////////else
                        ////////////{
                        ////////////    Session["Vouyear"] = dt_Date.Year;
                        ////////////    VouYear = dt_Date.Year;
                        ////////////    Alogyear = VouYear;
                        ////////////    Session["Alogyear"] = Alogyear;
                        ////////////    string str_dispyear = "";
                        ////////////    string str_dispyearnew = "";
                        ////////////    if (Session["countryid"].ToString() == "1102" || Session["countryid"].ToString() == "102")
                        ////////////    {
                        ////////////        for (int i = 2023; i < dt_Date.Year; i++)
                        ////////////        {
                        ////////////            str_dispyear = Convert.ToString(i);
                        ////////////            str_dispyear = str_dispyear.Substring(2, 2);
                        ////////////            int dy;
                        ////////////            string dy1 = "";

                        ////////////            dy = Convert.ToInt32(str_dispyear) + 1;

                        ////////////            if (dy < 10)
                        ////////////            {
                        ////////////                dy1 = dy1 + "0" + Convert.ToString(dy);
                        ////////////            }
                        ////////////            else
                        ////////////            {
                        ////////////                dy1 = Convert.ToString(dy);

                        ////////////            }
                        ////////////            str_dispyear = str_dispyear + "-" + dy1;
                        ////////////            Session["str_dispyear"] = str_dispyear;
                        ////////////            ddl_FAYear.Items.Add(str_dispyear);

                        ////////////            if (i == VouYear)
                        ////////////            {
                        ////////////                ddl_FAYear.Text = str_dispyear;
                        ////////////                Session["LYEAR"] = ddl_FAYear.Text;
                        ////////////                Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                        ////////////            }
                        ////////////        }
                        ////////////    }
                        ////////////    else
                        ////////////    {
                        ////////////        for (int i = 2023; i <= dt_Date.Year; i++)
                        ////////////        {
                        ////////////            str_dispyearnew = Convert.ToString(i);
                        ////////////            str_dispyear = Convert.ToString(i);
                        ////////////            str_dispyear = str_dispyear.Substring(2, 2);
                        ////////////            int dy;
                        ////////////            string dy1 = "";

                        ////////////            dy = Convert.ToInt32(str_dispyear) + 1;

                        ////////////            if (dy < 10)
                        ////////////            {
                        ////////////                dy1 = dy1 + "0" + Convert.ToString(dy);
                        ////////////            }
                        ////////////            else
                        ////////////            {
                        ////////////                dy1 = Convert.ToString(dy);

                        ////////////            }
                        ////////////            str_dispyear = str_dispyear + "-" + dy1;
                        ////////////            Session["str_dispyear"] = str_dispyear;
                        ////////////            // str_dispyear = str_dispyearnew;
                        ////////////            ddl_FCYear.Items.Add(str_dispyearnew);

                        ////////////            if (i == VouYear)
                        ////////////            {
                        ////////////                ddl_FCYear.Text = str_dispyearnew;
                        ////////////                Session["LYEAR"] = ddl_FCYear.Text;
                        ////////////                Session["FADbname"] = "FA" + str_dispyear.Replace("-", "");
                        ////////////            }
                        ////////////        }
                        ////////////    }
                        ////////////}
                    //}
                }
            }

           
            try
            {
                imgRequest.Visible = true;
                //imgreqNext.Visible = false;
                //divNew.Visible = false;
                if (Session["LoginBranchid"] != null)
                {
                    //if (Convert.ToInt32(Session["LoginBranchid"].ToString()) == 40 || Convert.ToInt32(Session["LoginBranchid"].ToString()) == 62 || Convert.ToInt32(Session["LoginBranchid"].ToString()) == 82 || Convert.ToInt32(Session["LoginBranchid"].ToString()) == 66 || Convert.ToInt32(Session["LoginBranchid"].ToString()) == 5)
                    if (Session["LoginBranchName"].ToString() == "CORPORATE")

                    {
                        Session["StrTranType"] = "CO";
                        Linkcorpor.Visible = true;
                      lnkbtn.Visible = false;
                    }
                    else
                    {
                        lnkbtn.Visible = true;
                       Linkcorpor.Visible = false;
                    }
                }

                /*  if (Convert.ToInt32(Session["LoginBranchid"].ToString()) == 40)
                  {
                 
                  }
                  else
                  {
                      lnkbtn.Visible = true;
                  }*/



                if (Session["LoginEmpName"] != null)
                {
                    lblcname.Text = Session["LoginEmpName"].ToString();
                }

                lblcname.Text = lblcname.Text.ToLowerInvariant();
                if (Session["LoginDivisionName"] != null)
                {
                    lblcompany.Text = Session["LoginDivisionName"].ToString();
                }
                  if (Session["LoginDivisionName"] != null)
                {
                    lblcompany.Text = Session["LoginDivisionNameReport"].ToString();
                }
                if (Session["LoginBranchName"] != null)
                {
                    lblcompany.Text = lblcompany.Text.ToLowerInvariant() + " , " + Session["LoginBranchName"].ToString().ToLowerInvariant() + " - " + lblcname.Text;
                }

                //if (Session["Deviceinfo"] != null)
                //{
                //    lblcompany.Text += "" + Session["Deviceinfo"].ToString();
                //}

                //  lblname.Text = Session["LoginEmpName"].ToString();
                //lblname.Text = lblname.Text.ToLowerInvariant();
                lbldesg.Text = Session["designation"].ToString();
                lbldesg.Text = lbldesg.Text.ToLowerInvariant();
                lbldept.Text = Session["dept"].ToString();
                lbldept.Text = lbldept.Text.ToLowerInvariant();
                lblport.Text = Session["branch"].ToString();
                lblport.Text = lblport.Text.ToLowerInvariant();

                if (Session["LoginUserName"] != null)
                {
                    username = Session["LoginUserName"].ToString();
                }
                // username = Session["LoginUserName"].ToString();

                DataTable dt = new DataTable();
                dt = employee.GetEmployeeDetails(username);

                if (!(dt.Rows[0]["empphoto"].Equals(System.DBNull.Value)))
                {
                    byte[] imageBytes = ((byte[])dt.Rows[0]["empphoto"]);
                    string base64String = Convert.ToBase64String(imageBytes);
                    img_emp.ImageUrl = "data:image/png;base64," + base64String;
                    img_emp1.ImageUrl = "data:image/png;base64," + base64String;
                    Label1.Text = dt.Rows[0]["offmailid"].ToString();
                    //Image3.ImageUrl = "data:image/png;base64," + base64String;
                }

                Session["Basecurr"] = EXobj.GetBaseCurrency(Convert.ToInt32(Session["LoginBranchid"]));

                DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                if (dtlogo.Rows.Count > 0)
                {
                    byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                    string base64String = Convert.ToBase64String(logoimageBytes);
                    img_Logo.ImageUrl = "data:image/png;base64," + base64String;
                }

               // img_Logo.ImageUrl = "images/s2cpaint2.png";


                string BdName = "";
                if (Session["Budget"] != null)
                {
                    BdName = Session["Budget"].ToString();
                    if (BdName == "BudgetData")
                    {
                        Session["Budget"] = null;
                        ifrmaster.Attributes["src"] = "CRM/BudgetData.aspx";
                    }
                    else if (BdName == "BudgetCust")
                    {
                        Session["Budget"] = null;
                        ifrmaster.Attributes["src"] = "CRM/BudgetCust.aspx";
                    }
                    else if (BdName == "Miscorporate")
                    {
                        Session["Budget"] = null;
                        ifrmaster.Attributes["src"] = "ForwardExports/CostingDetails.aspx";
                    }
                    else if (BdName == "MIS")
                    {
                        Session["Budget"] = null;
                        ifrmaster.Attributes["src"] = "ForwardExports/CostingDetails.aspx";
                    }
                    else if (BdName == "userlog")
                    {
                        Session["Budget"] = null;
                        ifrmaster.Attributes["src"] = "MainPage/OceanExportsDocked.aspx";
                    }
                    else if (BdName == "userlog")
                    {
                        Session["Budget"] = null;
                        ifrmaster.Attributes["src"] = "MainPage/OceanImportsDocked.aspx";
                    }
                    else if (BdName == "userlog")
                    {
                        Session["Budget"] = null;
                        ifrmaster.Attributes["src"] = "MainPage/AEDocked.aspx";
                    }
                    else if (BdName == "userlog")
                    {
                        Session["Budget"] = null;
                        ifrmaster.Attributes["src"] = "MainPage/AIDocked.aspx";
                    }
                    else if (BdName == "userlog")
                    {
                        Session["Budget"] = null;
                        ifrmaster.Attributes["src"] = "MainPage/AccountsDocked.aspx";
                    }

                }
                else if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO" || Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "HR")
                    {
                        ifrmaster.Attributes["src"] = "Cor_MainModuleNew.aspx";
                        Session["RightsTranType"] = "MI";
                    }
                    else
                    {
                        ifrmaster.Attributes["src"] = "Mainmodule_product.aspx";
                    }
                }
                else
                {
                    ifrmaster.Attributes["src"] = "Mainmodule_product.aspx";
                }
                if (Session["LoginEmpId"] != null)
                {
                    ds = obj_emp.GetEmplistfroAppraiser(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows[0]["countno"].ToString() == "0")
                    {
                        lnkbtnapp.Visible = false;
                    }
                    else
                    {
                        lnkbtnapp.Visible = true;
                        lnkbtnapp.Text = ds.Tables[1].Rows[0]["appraisal"].ToString();

                    }
                }
                if (Session["LoginEmpId"] != null)
                {

                    ds = obj_emp.GetEmplistforReviewer(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows[0]["countno"].ToString() == "0")
                    {
                        lnkreviewer.Visible = false;
                    }
                    else
                    {
                        lnkreviewer.Visible = true;
                        lnkreviewer.Text = ds.Tables[1].Rows[0]["appraisal"].ToString();
                    }

                }
                if (Session["LoginEmpId"] != null)
                {
                    ds = obj_emp.GetEmplistforCompleteReviewer(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows[0]["countno"].ToString() == "0")
                    {
                        lnkcomrev.Visible = false;
                    }
                    else
                    {
                        lnkcomrev.Visible = true;
                        lnkcomrev.Text = ds.Tables[1].Rows[0]["appraisal"].ToString();
                    }

                }



                DataSet dtsub = new DataSet();
                if (Session["LoginEmpId"] != null)
                {
                    dtsub = obj_emp.GetKpiSubmittedDateDetails(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                }
                if (dtsub.Tables[1].Rows[0]["countno"].ToString() == "0")
                {
                    lnkbtnpendemp.Visible = false;
                }
                else
                {
                    lnkbtnpendemp.Visible = true;
                    lnkbtnpendemp.Text = dtsub.Tables[1].Rows[0]["appraisal"].ToString();
                }

                DataTable dtcoo = new DataTable();
                if (Session["LoginEmpId"] != null)
                {

                    dtcoo = obj_emp.GetEmpListForCOO();
                    if (dtcoo.Rows.Count > 0)
                    {
                        if (dtcoo.Rows[0]["countno"].ToString() == "0")
                        {
                            lnkbtncoo.Visible = false;
                            lnkbtncoo.Attributes["class"] = "hide";
                            lbl.Visible = false;
                        }
                        else
                        {
                            if (Session["LoginEmpid"].ToString() == "240" || Session["LoginEmpid"].ToString() == "239")
                            {
                                lnkbtncoo.Visible = true;
                                lnkbtncoo.Text = dtcoo.Rows[0]["appraiser"].ToString();
                                lnkbtncoo.Attributes["class"] = "lnkbtncooli";
                                lbl.Visible = true;
                            }
                            else
                            {
                                lnkbtncoo.Visible = false;
                                lnkbtncoo.Attributes["class"] = "hide";
                                lbl.Visible = false;
                            }

                        }
                    }
                    else
                    {
                        lnkbtncoo.Visible = false;
                        lnkbtncoo.Attributes["class"] = "hide";
                        lbl.Visible = false;
                    }
                }
                
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('" + msg + "');", true);                        


                //ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";



                DataTable table = da_obj_Logobj.Getloginbranchtouchlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                if (table.Rows.Count > 0)
                {
                    grd_branch.DataSource = table;
                    grd_branch.DataBind();
                }

                /* if(Session["LoginDivisionId"]!=null)
                 {
                     if (Session["LoginDivisionId"].ToString() == "1")
                     {
                         if (table.Rows.Count > 0)
                         {
                             AHB1.Text = table.Rows[0]["branchName"].ToString().ToLower();
                             BAB1.Text = table.Rows[1]["branchName"].ToString().ToLower();

                             // CALB1.Text = table.Rows[2]["branchName"].ToString().ToLower();
                             CHEB1.Text = table.Rows[2]["branchName"].ToString().ToLower();
                             // COCB1.Text = table.Rows[4]["branchName"].ToString().ToLower();
                             // COIB1.Text = table.Rows[5]["branchName"].ToString().ToLower();
                             //  CORB1.Text = table.Rows[3]["branchName"].ToString().ToLower();
                             HYDB1.Text = table.Rows[3]["branchName"].ToString().ToLower();
                             //LUDB1.Text = table.Rows[8]["branchName"].ToString().ToLower();

                             NEWB1.Text = table.Rows[4]["branchName"].ToString().ToLower();
                             MUMB1.Text = table.Rows[5]["branchName"].ToString().ToLower();
                             // TIRB1.Text = table.Rows[11]["branchName"].ToString().ToLower();
                             TUTB1.Text = table.Rows[6]["branchName"].ToString().ToLower();
                             TIRB1.Text = table.Rows[7]["branchName"].ToString().ToLower();
                             /// VISB1.Text = table.Rows[13]["branchName"].ToString().ToLower();
                             // WARB1.Text = table.Rows[14]["branchName"].ToString().ToLower();


                             hid_AHB1.Value = table.Rows[0]["branchID"].ToString();
                             hid_BAB1.Value = table.Rows[1]["branchID"].ToString();
                             // hid_CALB1.Value = table.Rows[2]["branchID"].ToString();
                             hid_CHEB1.Value = table.Rows[2]["branchID"].ToString();
                             // hid_COCB1.Value = table.Rows[4]["branchID"].ToString();
                             // hid_COIB1.Value = table.Rows[5]["branchID"].ToString();
                             // hid_CORB1.Value = table.Rows[3]["branchID"].ToString();

                             hid_HYDB1.Value = table.Rows[3]["branchID"].ToString();
                             // hid_LUDB1.Value = table.Rows[8]["branchID"].ToString();
                             // hid_MUMB1.Value = table.Rows[9]["branchID"].ToString();
                             hid_NEWB1.Value = table.Rows[4]["branchID"].ToString();
                             hid_MUMB1.Value = table.Rows[5]["branchID"].ToString();
                             // hid_TIRB1.Value = table.Rows[11]["branchID"].ToString();
                             hid_TUTB1.Value = table.Rows[6]["branchID"].ToString();
                             hid_TIRB1.Value = table.Rows[7]["branchID"].ToString();
                             // hid_VISB1.Value = table.Rows[13]["branchID"].ToString();
                             // hid_WARB1.Value = table.Rows[14]["branchID"].ToString();

                         }
                     }                 
                    
                 }*/


            }

            catch
            {
                Session["LoginEmpName"] = null;
                Session["LoginUserName"] = null;

                Response.Redirect("Login.Aspx");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alertify.alert('Sesion Time Out. Login Again');", true);
                return;
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["LoginEmpName"] = null;
            Session["LoginUserName"] = null;

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }

        //protected void LinkButton2_Click(object sender, EventArgs e)
        //{
        //    Session["iframeid"] = "Budget";
        //    //Response.Redirect("Budget.aspx");
        //    ifrmaster.Attributes["src"] = "MainModuleNew.aspx";

        //}

        protected void lnkbtn_Click1(object sender, EventArgs e)
        {

            //Product

            Session["sales"] = null;
            Session["OE_ops"] = null;
            Session["OI_ops"] = null;
            Session["AE_ops"] = null;
            Session["AI_ops"] = null;
            Session["OE_CSs"] = null;
            Session["OI_CSs"] = null;
            Session["AE_CS"] = null;
            Session["AI_CS"] = null;
            Session["OperatingAccounts"] = null;
            Session["MIS"] = null;
            Session["BondedTrucking"] = null;
            Session["CHA"] = null;
            Session["FAAccounts"] = null;
            Session["COMaintenance"] = null;
            //lnkbtn.Visible = true;
            //Linkcorpor.Visible = false;
        //  Session["Process"] = "";sindhuuu
          if (lnkbtn.Text == "")
          {
              lnkbtn.Text = "PRODUCT NAME";
          }
          // lnkbtn.Text = "PRODUCT NAME";
            imgRequest.Visible = true;
            //imgreqNext.Visible = false;
            //divNew.Visible = false;
            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "CO" || Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "HR")
                {
                    Session["StrTranType"] = "CO";
                    Session["iframeid"] = "Home";
                    ifrmaster.Attributes["src"] = "Cor_MainModuleNew.aspx";
                    Session["StrTranType1"] = null;
                    Session["home"] = null;
                    //if (Linkcorpor.Text == "MAINTENANCE")
                    //{
                    //    Maintenance_Click(sender, e);
                    //}
                    //else if (Linkcorpor.Text == "MIS & ANALYTICS")
                    //{
                    //    MISHome_Click(sender, e);
                    //}
                    //else if (Linkcorpor.Text == "FINANCIAL ACCOUNTS")
                    //{
                    //    FAHome_Click(sender, e);
                    //}
                    //else
                    //{
                    //    Maintenance_Click(sender, e);
                    //}

                }
                else
                {
                    if (lnkbtn.Text == "AIR IMPORTS")
                    {
                        Session["AI_ops"] = "AI_ops";
                        lnkbtn.Visible = true;
                        lnkbtn.Text = "AIR IMPORTS";
                        BL_Booking.Visible = true;
                        Booking.Visible = true;
                        linkBooking.Visible = true;
                        Booking.Text = "";
                        //AIOpsDocsHome_Click(sender, e);
                        //  ifrmaster.Attributes["src"] = "Mainpage/AirImports_ops.aspx";
                    }
                    else if (lnkbtn.Text == "AIR EXPORTS")
                    {
                        Session["Process1"] = "AIR EXPORT";
                        //   lnkbtn_Click1(sender, e);
                        Session["AE_ops"] = "AE_ops";

                        lnkbtn.Visible = true;
                        lnkbtn.Text = "AIR EXPORTS";
                        BL_Booking.Visible = true;
                        Booking.Visible = true;
                        linkBooking.Visible = true;
                        Booking.Text = "";
                        //   AEOpsDocsHome_Click(sender, e);
                        // ifrmaster.Attributes["src"] = "Mainpage/AirExports_ops.aspx";
                    }
                    else if (lnkbtn.Text == "OCEAN IMPORTS")
                    {
                        Session["Process1"] = "OCEAN IMPORT";
                        // lnkbtn_Click1(sender, e);
                        Session["OI_ops"] = "OI_ops";

                        lnkbtn.Visible = true;
                        lnkbtn.Text = "OCEAN IMPORTS";
                        BL_Booking.Visible = true;
                        Booking.Visible = true;
                        linkBooking.Visible = true;
                        Booking.Text = "";
                        //   OIOpsDocsHome_Click(sender, e);
                        // ifrmaster.Attributes["src"] = "Mainpage/OceanImports_ops.aspx";

                    }
                    else if (lnkbtn.Text == "OCEAN EXPORTS")
                    {
                        Session["Process1"] = "OCEAN EXPORTS";
                        // lnkbtn_Click1(sender, e);
                        Session["OE_ops"] = "OE_ops";

                        lnkbtn.Visible = true;
                        lnkbtn.Text = "OCEAN EXPORTS";
                        BL_Booking.Visible = true;
                        Booking.Visible = true;
                        linkBooking.Visible = true;
                        Booking.Text = "";
                        // OEOpsDocsHome_Click(sender, e);
                        // ifrmaster.Attributes["src"] = "Mainpage/OceanExportsOps_Docs.aspx";
                    }
                    else if (lnkbtn.Text == "MAINTENANCE")
                    {
                        lnkbtn.Text = "MAINTENANCE";
                        lnkbtn.Visible = true;
                        Session["COMaintenance"] = "COMaintenance";
                        Booking.Visible = false;
                        linkBooking.Visible = false;
                        BL_Booking.Visible = false;
                        Booking.Text = "";
                        //    br_Mainten_Click(sender, e);
                        // ifrmaster.Attributes["src"] = "MainPage/MaintenanceDockedPanel.aspx";
                    }
                    else if (lnkbtn.Text == "FINANCIAL ACCOUNTS")
                    {
                        Session["FAAccounts"] = "FAAccounts";
                        lnkbtn.Text = "FINANCIAL ACCOUNTS";
                        Booking.Visible = false;
                        linkBooking.Visible = false;
                        BL_Booking.Visible = false;
                        Booking.Text = "";
                        //FAHome_Click(sender, e);
                        // ifrmaster.Attributes["src"] = "Mainpage/AirImports_ops.aspx";
                    }
                    else if (lnkbtn.Text == "MIS & ANALYTICS")
                    {
                        lnkbtn.Text = "MIS & ANALYTICS";
                        Session["MIS"] = "MIS";
                        Booking.Visible = false;
                        linkBooking.Visible = false;
                        BL_Booking.Visible = false;
                        Booking.Text = "";
                        //MISHome_Click(sender, e);
                        // ifrmaster.Attributes["src"] = "Mainpage/MIS_ApprovalDock.aspx";

                    }
                    else if (lnkbtn.Text == "SALES")
                    {
                        Session["Process1"] = "Sales";
                        lnkbtn.Visible = true;
                        lnkbtn.Text = "SALES";

                        Session["sales"] = "sales";
                        Booking.Visible = false;
                        linkBooking.Visible = false;
                        BL_Booking.Visible = false;
                        Booking.Text = "";
                        // ifrmaster.Attributes["src"] = "Mainpage/SalesDocked.aspx";

                    }
                    //Session["iframeid"] = "Home";
                    //ifrmaster.Attributes["src"] = "Mainmodule_product.aspx?finaddlyear=" + ddl_FAYear.Text;
                    //Session["StrTranType"] = null;
                    //Session["home"] = null;
                    //Session["StrTranType1"] = null;
                }
            }
            else
            {

                Session["iframeid"] = "Home";
                ifrmaster.Attributes["src"] = "Mainmodule_product.aspx?finaddlyear=" + ddl_FAYear.Text;
                Session["StrTranType"] = null;
                Session["home"] = null;
                Session["StrTranType1"] = null;
            }

        }
        protected void imgRequest_Click(object sender, ImageClickEventArgs e)
        {
            //iframeprofile.Attributes["src"] = "HRM/CompanyProfile.aspx";
            //popup_cheque.Show();

        }

        protected void lnkhome_Click(object sender, EventArgs e)
        {
            string home;
            if (Session["home"] != null)
            {
                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "SA")
                    {
                        ifrmaster.Attributes["src"] = "Mainpage/SalesDocked.aspx";
                    }
                    else if (Session["home"].ToString() == "MIS")
                    {
                        ifrmaster.Attributes["src"] = "Mainpage/MIS_ApprovalDock.aspx";
                    }
                    else if (Session["home"].ToString() == "FABR")
                    {
                        ifrmaster.Attributes["src"] = "Mainpage/Main_Branch.aspx";
                    }

                    else if (Session["home"].ToString() == "FABR")
                    {
                        ifrmaster.Attributes["src"] = "Mainpage/Main_Branch.aspx";
                    }
                }
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        if (Session["home"].ToString() != null)
                        {
                            home = Session["home"].ToString();
                            if (home == "OPS&DOC")
                            {
                                ifrmaster.Attributes["src"] = "Mainpage/OceanExportsOps_Docs.aspx";
                            }
                            else if (home == "CS")
                            {
                                ifrmaster.Attributes["src"] = "Mainpage/OceanExportsCustomerSupport.aspx";
                            }
                        }
                        //ifrmaster.Attributes["src"] = "Mainpage/OceanExports.aspx";
                    }

                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        if (Session["home"].ToString() != null)
                        {
                            home = Session["home"].ToString();
                            if (home == "OPS&DOC")
                            {
                                ifrmaster.Attributes["src"] = "Mainpage/OceanImports_ops.aspx";
                            }
                            else if (home == "CS")
                            {
                                ifrmaster.Attributes["src"] = "Mainpage/OceanImportsCustomerSupport.aspx";
                            }
                        }
                        //ifrmaster.Attributes["src"] = "Mainpage/OceanImportsDocked.aspx";
                    }
                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        if (Session["home"].ToString() != null)
                        {
                            home = Session["home"].ToString();
                            if (home == "OPS&DOC")
                            {
                                ifrmaster.Attributes["src"] = "Mainpage/AirExports_ops.aspx";
                            }
                            else if (home == "CS")
                            {
                                ifrmaster.Attributes["src"] = "Mainpage/AECustomerSupport.aspx";
                            }
                        }
                        //ifrmaster.Attributes["src"] = "Mainpage/AEDocked.aspx";
                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        if (Session["home"].ToString() != null)
                        {
                            home = Session["home"].ToString();
                            if (home == "OPS&DOC")
                            {
                                ifrmaster.Attributes["src"] = "Mainpage/AirImports_ops.aspx";
                            }
                            else if (home == "CS")
                            {
                                ifrmaster.Attributes["src"] = "Mainpage/AICustomerSupport.aspx";
                            }
                        }
                        //ifrmaster.Attributes["src"] = "Mainpage/AIDocked.aspx";
                    }
                    else if (Session["StrTranType"].ToString() == "AC")
                    {
                        if (Session["home"].ToString() != null)
                        {
                            home = Session["home"].ToString();
                            if (home == "FABR")
                            {
                                ifrmaster.Attributes["src"] = "Mainpage/Main_Branch.aspx";
                            }

                        }
                        //ifrmaster.Attributes["src"] = "Mainpage/AIDocked.aspx";
                    }
                    else if (Session["StrTranType"].ToString() == "CO")
                    {

                        if (Session["StrTranType1"] != null)
                        {
                            if (Session["StrTranType1"].ToString() == "AccountandFinanceCor")
                            {
                                ifrmaster.Attributes["src"] = "CorMainPage/Accounts_and_finanace_Docked.aspx";
                            }
                            else if (Session["StrTranType1"].ToString() == "BudgetCor")
                            {
                                ifrmaster.Attributes["src"] = "CorMainPage/Budget_Docked.aspx";
                            }
                            else if (Session["StrTranType1"].ToString() == "CreditControlcor")
                            {
                                ifrmaster.Attributes["src"] = "CorMainPage/Credit_Control_Docked.aspx";
                            }
                            else if (Session["StrTranType1"].ToString() == "MISandAnalysisCor")
                            {
                                ifrmaster.Attributes["src"] = "CorMainPage/MIS_and_Analysis_Docked.aspx";
                            }
                            else if (Session["StrTranType1"].ToString() == "Utilitycor")
                            {
                                ifrmaster.Attributes["src"] = "CorMainPage/Utility_Docked.aspx";
                            }
                            else if (Session["StrTranType1"].ToString() == "CRMcor")
                            {
                                ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
                            }
                            else if (Session["StrTranType1"].ToString() == "MCor")
                            {
                                ifrmaster.Attributes["src"] = "MainPage/MaintenanceDockedPanel.aspx";
                            }
                            else if (Session["StrTranType1"].ToString() == "HRCor")
                            {
                                ifrmaster.Attributes["src"] = "MainPage/HRMDocked.aspx";
                            }
                            else if (Session["StrTranType1"].ToString() == "FCCO")
                            {
                                ifrmaster.Attributes["src"] = "MainPage/Main_Corporate.aspx";
                            }
                        }


                        else
                        {
                            ifrmaster.Attributes["src"] = "Cor_MainModuleNew.aspx";
                        }
                    }

                }

            }
            else if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "CH")
                {
                    ifrmaster.Attributes["src"] = "Mainpage/CHADocked.aspx";
                }
                else if (Session["StrTranType"].ToString() == "BT")
                {
                    ifrmaster.Attributes["src"] = "Mainpage/BondedTruckingDocked.aspx";
                }
                else if (Session["StrTranType"].ToString() == "AC")
                {
                    ifrmaster.Attributes["src"] = "Mainpage/AccountsDocked.aspx";
                }

                else if (Session["StrTranType"].ToString() == "CRM")
                {
                    ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
                }

                else if (Session["StrTranType"].ToString() == "HR")
                {
                    ifrmaster.Attributes["src"] = "Mainpage/HRMDocked.aspx";
                }
                else if (Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "MN")
                {
                    ifrmaster.Attributes["src"] = "MainPage/MaintenanceDockedPanel.aspx";
                }

                if (Session["StrTranType"].ToString() == "CO")
                {

                    if (Session["StrTranType1"] != null)
                    {
                        if (Session["StrTranType1"].ToString() == "AccountandFinanceCor")
                        {
                            ifrmaster.Attributes["src"] = "CorMainPage/Accounts_and_finanace_Docked.aspx";
                        }
                        else if (Session["StrTranType1"].ToString() == "BudgetCor")
                        {
                            ifrmaster.Attributes["src"] = "CorMainPage/Budget_Docked.aspx";
                        }
                        else if (Session["StrTranType1"].ToString() == "CreditControlcor")
                        {
                            ifrmaster.Attributes["src"] = "CorMainPage/Credit_Control_Docked.aspx";
                        }
                        else if (Session["StrTranType1"].ToString() == "MISandAnalysisCor")
                        {
                            ifrmaster.Attributes["src"] = "CorMainPage/MIS_and_Analysis_Docked.aspx";
                        }
                        else if (Session["StrTranType1"].ToString() == "TaskManagement")
                        {
                            ifrmaster.Attributes["src"] = "../TaskDetailsDashMain.aspx";
                        }
                        else if (Session["StrTranType1"].ToString() == "Utilitycor")
                        {
                            ifrmaster.Attributes["src"] = "CorMainPage/Utility_Docked.aspx";
                        }
                        else if (Session["StrTranType1"].ToString() == "CRMcor")
                        {
                            ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
                        }
                        else if (Session["StrTranType1"].ToString() == "MCor")
                        {
                            ifrmaster.Attributes["src"] = "MainPage/MaintenanceDockedPanel.aspx";
                        }
                    }


                    else
                    {
                        ifrmaster.Attributes["src"] = "Cor_MainModuleNew.aspx";
                    }
                }
                //else if (Session["StrTranType"].ToString() == "HR")
                //{
                //    ifrmaster.Attributes["src"] = "MainPage/HRMDocked.aspx";
                //}
            }
            else
            {
                Session["iframeid"] = "Home";
                ifrmaster.Attributes["src"] = "Mainmodule_product.aspx";
            }
        }

        protected void viewlinkbutton_Click(object sender, EventArgs e)
        {
            //ifrmaster.Attributes["class"] = "div_Menunew";
            //ifrmaster.Attributes["src"] = "Home/Profile.aspx";


            string profile = "profile";
            ifrmaster.Attributes["class"] = "div_Menunew";
            ifrmaster.Attributes["src"] = "ForwardExports/EmpchangePass.aspx?profile=" + profile;
            //iframeprofile.Attributes["src"] = "Home/Profile.aspx";
            //popup_cheque.Show();

            // Response.Redirect("Home/Profile.aspx");
        }

        protected void lnkreviewer_Click(object sender, EventArgs e)
        {
            Session["REV"] = "Y";
            ifrmaster.Attributes["class"] = "div_Menunew";
            ifrmaster.Attributes["src"] = "Home/ReviewerPage.aspx";
        }

        protected void lnkbtnapp_Click(object sender, EventArgs e)
        {
            ifrmaster.Attributes["class"] = "div_Menunew";
            ifrmaster.Attributes["src"] = "Home/AppraiserPage.aspx";
            Session["appraisal"] = "appraisal";
            // Response.Redirect("Appraisal/formappraiser.aspx");
        }

        protected void lnkbtnpendemp_Click(object sender, EventArgs e)
        {
            Session["EMPCONFIRM"] = "1";
            ifrmaster.Attributes["class"] = "div_Menunew";

            ifrmaster.Attributes["src"] = "Home/AppPage1.aspx";
        }

        protected void lnkbtncoo_Click(object sender, EventArgs e)
        {
            //DataTable dtcoo = new DataTable();
            //if (Session["LoginEmpId"] != null)
            //{
            //    if (Session["LoginEmpid"].ToString() == "240" || Session["LoginEmpid"].ToString() == "239")
            //    {
            //        dtcoo = obj_emp.GetEmpListForCOO();
            //        if (dtcoo.Rows.Count > 0)
            //        {
            //            if (dtcoo.Rows[0]["countno"].ToString() == "0")
            //            {
            //                return;
            //            }
            //            else
            //            {
            ifrmaster.Attributes["class"] = "div_Menunew";
            ifrmaster.Attributes["src"] = "Home/CooEmpList.aspx";
            //            }
            //        }
            //    }
            //}

        }

        protected void lnkcomrev_Click(object sender, EventArgs e)
        {
            Session["REV"] = "N";
            ifrmaster.Attributes["class"] = "div_Menunew";
            ifrmaster.Attributes["src"] = "Home/RevCompleteList.aspx";
        }




        //protected void img_profile_Click(object sender, ImageClickEventArgs e)
        //{
        //    ifrmaster.Attributes["src"] = "../HRM/CompanyProfile.aspx";
        //}

        //protected void LinkButton3_Click(object sender, EventArgs e)
        //{
        //    Session["iframeid"] = "Appointment";
        //    //Response.Redirect("Budget.aspx");
        //    ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
        //}

        //protected void LinkButton4_Click(object sender, EventArgs e)
        //{
        //    Session["iframeid"] = "GenerateSchedule";
        //    //Response.Redirect("Budget.aspx");
        //    ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
        //}

        //protected void lnkSalesFollowup_Click(object sender, EventArgs e)
        //{
        //    Session["iframeid"] = "SalesFollowUp";
        //    //Response.Redirect("Budget.aspx");
        //    ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
        //}

        //protected void imgRequest_Click(object sender, ImageClickEventArgs e)
        //{
        //    //imgRequest.Visible = false;
        //    //imgreqNext.Visible = true;
        //    //divNew.Visible = true;
        //    //divNew.Attributes.Add("class", "top_FndNew");
        //    Session["iframeid"] = "SalesPerson";
        //    ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
        //}

        //protected void imgreqNext_Click(object sender, ImageClickEventArgs e)
        //{
        //    imgRequest.Visible = true;
        //    imgreqNext.Visible = false;
        //    divNew.Visible = false;
        //    //divNew.Attributes.Add("class", "top_FndNew");
        //    Session["iframeid"] = "SalesPerson";
        //    ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
        //}

        //protected void imgmsg_Click(object sender, ImageClickEventArgs e)
        //{
        //    Session["iframeid"] = "Mail";
        //    ifrmaster.Attributes["src"] = "MainPage/CRMDocked.aspx";
        //}



        protected void lnkbranch_Click(object sender, EventArgs e)
        {
            Session["StrTranType"] = null;
            Session["LoginBranchid"] = null;
            Response.Redirect("MainFormNew.aspx");


            if (lnkbranch.Text == "CORPORATE")
            {
                Booking.Visible = false;
                linkBooking.Visible = false;
                BL_Booking.Visible = false;
                Booking.Text = "";
            }
        }



        //Product

        protected void SalesHome_Click(object sender, EventArgs e)
        {
            //Response.Redirect("FormMain.aspx");
            //DataTable dts = new DataTable();
           Session["Process1"] = "Sales";
            lnkbtn.Visible = true;
            lnkbtn.Text = "SALES";
            lnkbtn_Click1(sender, e);
            Session["sales"] = "sales";
            BL_Booking.Visible = false;
            Booking.Visible = false;
            linkBooking.Visible = false;
            Booking.Text = "";

            //dts = (DataTable)Session["Datarights"];
            //for (int i = 0; i < dts.Rows.Count; i++)
            //{
            //    if ((dts.Rows[i]["trantype"].ToString() == "FE" || dts.Rows[i]["trantype"].ToString() == "FI" || dts.Rows[i]["trantype"].ToString() == "AE" || dts.Rows[i]["trantype"].ToString() == "AI"))
            //    {
            //        for (int j = 0; j < dts.Rows.Count; j++)
            //        {
            //            if (dts.Rows[j]["menuname"].ToString().Trim() == "Sales")
            //            {
            //                //Sales.ServerClick += new EventHandler(Sales_Click);
            //                Sales_Click(sender, e);
            //                break;
            //            }
            //        }

            //    }
            //}



            //Session["home"] = "SA";
            //Response.Redirect("MainPage/SalesDocked.aspx");

        }
        public void Sales_Click(object sender, EventArgs e)
        {
            //Session["StrTranType"] = "SA";
            Session["home"] = "SA";
            Response.Redirect("MainPage/SalesDocked.aspx");

        }

        protected void OECSHome_Click(object sender, EventArgs e)
        {
            // Response.Redirect("Home/OECSHome.aspx");

            lnkbtn_Click1(sender, e);
            Session["OE_CSs"] = "OE_CSs";
        }

        protected void OICSHome_Click(object sender, EventArgs e)
        {
            // Response.Redirect("Home/OICSHome.aspx");

            lnkbtn_Click1(sender, e);
            Session["OI_CSs"] = "OI_CSs";
        }

        protected void AECSHome_Click(object sender, EventArgs e)
        {
            //  Response.Redirect("Home/AECSHome.aspx");

            lnkbtn_Click1(sender, e);
            Session["AE_CS"] = "AE_CS";

        }

        protected void AICSHome_Click(object sender, EventArgs e)
        {
            // Response.Redirect("Home/AICSHome.aspx");

            lnkbtn_Click1(sender, e);
            Session["AI_CS"] = "AI_CS";
        }

        protected void OEOpsDocsHome_Click(object sender, EventArgs e)
        {
            // Response.Redirect("Home/OEOpsAndDocs.aspx");
            // lnkhome_Click(sender, e);
            lnkbtn.Text = "OCEAN EXPORTS";
            Session["Process1"] = "OCEAN EXPORTS";
            lnkbtn_Click1(sender, e);
            Session["OE_ops"] = "OE_ops";
          
            lnkbtn.Visible = true;

            BL_Booking.Visible = true;
            Booking.Visible = true;
            linkBooking.Visible = true;
            Booking.Text = "";


        }

        protected void OIOpsDocsHome_Click(object sender, EventArgs e)
        {

            // Response.Redirect("Home/OEOpsAndDocs.aspx");
            Session["Process1"] = "OCEAN IMPORT";
            lnkbtn.Text = "OCEAN IMPORTS";
            lnkbtn_Click1(sender, e);
            Session["OI_ops"] = "OI_ops";
            
            lnkbtn.Visible = true;
            BL_Booking.Visible = true;
            Booking.Visible = true;
            linkBooking.Visible = true;
            Booking.Text = "";

        }

        protected void AEOpsDocsHome_Click(object sender, EventArgs e)
        {
            // Response.Redirect("Home/OEOpsAndDocs.aspx");
            Session["Process1"] = "AIR EXPORT";
            lnkbtn.Text = "AIR EXPORTS";
            lnkbtn_Click1(sender, e);
            Session["AE_ops"] = "AE_ops";
            
            lnkbtn.Visible = true;
            BL_Booking.Visible = true;
            Booking.Visible = true;
            linkBooking.Visible = true;
            Booking.Text = "";

        }

        protected void AIOpsDocsHome_Click(object sender, EventArgs e)
        {
            // Response.Redirect("Home/OEOpsAndDocs.aspx");
            Session["Process1"] = "AIR IMPORT";
            lnkbtn.Text = "AIR IMPORTS";
            lnkbtn_Click1(sender, e);
            Session["AI_ops"] = "AI_ops";
            
            lnkbtn.Visible = true;
            BL_Booking.Visible = true;
            Booking.Visible = true;
            linkBooking.Visible = true;
            Booking.Text = "";


        }

        protected void BondedTruckingHome_Click(object sender, EventArgs e)
        {
            // Response.Redirect("Home/BTHome.aspx");
            lnkbtn_Click1(sender, e);
            Session["BondedTrucking"] = "BondedTrucking";
        }

        protected void CHAHome_Click(object sender, EventArgs e)
        {
            //  Response.Redirect("Home/BTHome.aspx");
            lnkbtn_Click1(sender, e);
            Session["CHA"] = "CHA";
        }

        protected void MISHome_Click(object sender, EventArgs e)
        {
            // Response.Redirect("Home/MISAndApproval.aspx");
            Session["Process1"] = "MIS & ANALYTICS";
            lnkbtn.Text = "MIS & ANALYTICS";
            lnkbtn_Click1(sender, e);
           
            Session["MIS"] = "MIS";
            BL_Booking.Visible = false;
            Booking.Visible = false;
            linkBooking.Visible = false;
            Booking.Text = "";
        }

        protected void OAHome_Click(object sender, EventArgs e)
        {
            // Response.Redirect("Home/OAHome.aspx");
            lnkbtn_Click1(sender, e);
            Session["OperatingAccounts"] = "OperatingAccounts";
        }

        protected void FAHome_Click(object sender, EventArgs e)
        {
            Session["Process1"] = "FINANCIAL ACCOUNTS";
            lnkbtn.Text = "FINANCIAL ACCOUNTS";
            lnkbtn_Click1(sender, e);
            Session["FAAccounts"] = "FAAccounts";
            BL_Booking.Visible = false;
            Booking.Visible = false;
            linkBooking.Visible = false;
            Booking.Text = "";

        }
        protected void Linkcorpor_Click(object sender, EventArgs e)
        {
            Session["sales"] = null;
            Session["OE_ops"] = null;
            Session["OI_ops"] = null;
            Session["AE_ops"] = null;
            Session["AI_ops"] = null;
            Session["OE_CSs"] = null;
            Session["OI_CSs"] = null;
            Session["AE_CS"] = null;
            Session["AI_CS"] = null;
            Session["OperatingAccounts"] = null;
            Session["MIS"] = null;
            Session["BondedTrucking"] = null;
            Session["CHA"] = null;
            Session["Accounts_and_finanace"] = null;
            Session["Credit_Control"] = null;
            Session["MIS_and_Analysis"] = null;
            Session["Utility"] = null;
            Session["Budget"] = null;
            Session["Maintenances"] = null;
            Session["HRM"] = null;
            Session["CRMCO"] = null;
            Session["CRMM"] = null;
            Session["CRMM"] = null;
            Session["FAAccounts"] = null;
            Session["FAFC"] = null;
            Session["Tasks"] = null;
            imgRequest.Visible = true;
            //imgreqNext.Visible = false;
            //divNew.Visible = false;
            //  lnkbtn.Visible = false;
            // Linkcorpor.Visible = true;
            //   Linkcorpor.Text = "PRODUCT NAME";
            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "CO" || Session["StrTranType"].ToString() == "M" || Session["StrTranType"].ToString() == "HR")
                {
                    Session["StrTranType"] = "CO";
                    //Session["iframeid"] = "Home";

                    if (Linkcorpor.Text == "MAINTENANCE")
                    {
                        Session["Process1"] = "MAINTENANCE";
                        Linkcorpor.Text = "MAINTENANCE";
                        Linkcorpor.Visible = true;
                        Session["Maintenances"] = "Maintenances";
                    }
                    else if (Linkcorpor.Text == "MIS & ANALYTICS")
                    {

                        Session["Process1"] = "MIS & ANALYTICS";
                        Linkcorpor.Text = "MIS & ANALYTICS";
                        Linkcorpor.Visible = true;
                        Session["MIS_and_Analysis"] = "MIS_and_Analysis";

                    }
                    else if (Linkcorpor.Text == "FINANCIAL ACCOUNTS")
                    {
                        Session["Process1"] = "FINANCIAL ACCOUNTS";
                        Linkcorpor.Text = "FINANCIAL ACCOUNTS";
                        Linkcorpor.Visible = true;
                        Session["FAFC"] = "FAFC";
                    }
                    else if (Linkcorpor.Text == "Task Managment")
                    {Session["Process1"] = "TASK MANAGEMENT";
                        Linkcorpor.Text = "TASK MANAGEMENT";
                        Linkcorpor.Visible = true;
                        Session["Tasks"] = "Tasks";
                    }
                    else
                    {
                        Session["Process1"] = "MAINTENANCE";
                        Linkcorpor.Text = "MAINTENANCE";
                        Linkcorpor.Visible = true;
                        Session["Maintenances"] = "Maintenances";
                    }

                    ifrmaster.Attributes["src"] = "Cor_MainModuleNew.aspx?finaddlyear=" + ddl_FCYear.Text;
                    Session["StrTranType1"] = null;
                    Session["home"] = null;
                    //ProcessBranch.Visible = false;
                    //ProcessCorporate.Visible = true;
                }
                else
                {
                    if (Linkcorpor.Text == "MAINTENANCE")
                    {
                        Session["Process1"] = "MAINTENANCE";
                        Linkcorpor.Text = "MAINTENANCE";
                        Linkcorpor.Visible = true;
                        Session["Maintenances"] = "Maintenances";
                    }
                    else if (Linkcorpor.Text == "MIS & ANALYTICS")
                    {
                        Session["Process1"] = "MIS & ANALYTICS";
                        Linkcorpor.Text = "MIS & ANALYTICS";
                        Linkcorpor.Visible = true;
                        Session["MIS_and_Analysis"] = "MIS_and_Analysis";

                    }
                    else if (Linkcorpor.Text == "FINANCIAL ACCOUNTS")
                    {Session["Process1"] = "FINANCIAL ACCOUNTS";
                        Linkcorpor.Text = "FINANCIAL ACCOUNTS";
                        Linkcorpor.Visible = true;
                        Session["FAFC"] = "FAFC";
                    }
                    else
                    {Session["Process1"] = "MAINTENANCE";
                        Linkcorpor.Text = "MAINTENANCE";
                        Linkcorpor.Visible = true;
                        Session["Maintenances"] = "Maintenances";
                    }
                    //Session["iframeid"] = "Home";

                    //ifrmaster.Attributes["src"] = "Mainmodule_product.aspx";
                    //Session["StrTranType"] = null;
                    //Session["home"] = null;
                    //Session["StrTranType1"] = null;
                    //ProcessBranch.Visible = true;
                    //ProcessCorporate.Visible = false;
                }
            }
            else
            {
                if (Linkcorpor.Text == "MAINTENANCE")
                {
                    Linkcorpor.Text = "MAINTENANCE";
                    Linkcorpor.Visible = true;
                    Session["Maintenances"] = "Maintenances";
                }
                else if (Linkcorpor.Text == "MIS & ANALYTICS")
                {Session["Process1"] = "MIS & ANALYTICS";
                    Linkcorpor.Text = "MIS & ANALYTICS";
                    Linkcorpor.Visible = true;
                    Session["MIS_and_Analysis"] = "MIS_and_Analysis";

                }
                else if (Linkcorpor.Text == "FINANCIAL ACCOUNTS")
                {Session["Process1"] = "FINANCIAL ACCOUNTS";
                    Linkcorpor.Text = "FINANCIAL ACCOUNTS";
                    Linkcorpor.Visible = true;
                    Session["FAFC"] = "FAFC";
                }
                else
                {
                    Session["Process1"] = "MAINTENANCE";
                    Maintenance_Click(sender, e);
                }
                //    Session["iframeid"] = "Home";
                //    //ProcessBranch.Visible = true;
                //    //ProcessCorporate.Visible = false;
                //    ifrmaster.Attributes["src"] = "Mainmodule_product.aspx";
                //    Session["StrTranType"] = null;
                //    Session["home"] = null;
                //    Session["StrTranType1"] = null;
                //}

            }
        }

        protected void CreditControl_Click(object sender, EventArgs e)
        {
            Linkcorpor_Click(sender, e);
            Session["Credit_Control"] = "Credit_Control";
        }

        protected void AccountsFinance_Click(object sender, EventArgs e)
        {
            Linkcorpor_Click(sender, e);
            Session["Accounts_and_finanace"] = "Accounts_and_finanace";
        }

        protected void Budget_Click(object sender, EventArgs e)
        {
            Linkcorpor_Click(sender, e);
            Session["Budget"] = "Budget";
        }

        protected void Utility_Click(object sender, EventArgs e)
        {
            Linkcorpor_Click(sender, e);
            Session["Utility"] = "Utility";
        }

        protected void Maintenance_Click(object sender, EventArgs e)
        {
            Session["Process1"] = "MAINTENANCE";
            Linkcorpor.Text = "MAINTENANCE";
            Linkcorpor_Click(sender, e);           
            Linkcorpor.Visible = true;
            Session["Maintenances"] = "Maintenances";
        }

        protected void MISandAnalysis_Click(object sender, EventArgs e)
        {
            Session["Process1"] = "MIS & ANALYTICS";
            Linkcorpor.Text = "MIS & ANALYTICS";
            Linkcorpor_Click(sender, e);
            Linkcorpor.Visible = true;
            Session["MIS_and_Analysis"] = "MIS_and_Analysis";
        }

        protected void HRM_Click(object sender, EventArgs e)
        {
            Linkcorpor_Click(sender, e);
            Session["HRM"] = "HRM";
        }

        protected void CRM_Click(object sender, EventArgs e)
        {
            Linkcorpor_Click(sender, e);
            Session["CRMM"] = "CRMM";

        }

        protected void CRMCO_Click(object sender, EventArgs e)
        {
            Linkcorpor_Click(sender, e);
            Session["CRMCO"] = "CRMCO";
        }
        protected void FCAC_Click(object sender, EventArgs e)
        {
            Session["Process1"] = "FINANCIAL ACCOUNTS";
            Linkcorpor.Text = "FINANCIAL ACCOUNTS";
            Linkcorpor_Click(sender, e);
            Linkcorpor.Visible = true;
            Session["FAFC"] = "FAFC";
        }



        protected void AHB1_Click(object sender, EventArgs e)
        {
            Session["LoginBranchid"] = Convert.ToInt32(hid_AHB1.Value);
            Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(hid_AHB1.Value));

            FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            DataTable Dt = new DataTable();
            Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                bmmail = Dt.Rows[0]["email"].ToString();
                bmmailid = Dt.Rows[0]["bm"].ToString();
                rmmailid = Dt.Rows[0]["rm"].ToString();
                Session["BM"] = bmmailid.ToString();
                Session["rm"] = rmmailid.ToString();
                strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                Session["Companyaddress"] = strcompanyaddress;
            }

            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                Response.Redirect("FormMain.aspx");
            }
            else
            {
                Session["StrTranType"] = null;
                Session["RightsTranType"] = null;
                Response.Redirect("FormMain.aspx");
            }
        }

        protected void BAB1_Click(object sender, EventArgs e)
        {
            Session["LoginBranchid"] = Convert.ToInt32(hid_BAB1.Value);
            Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(hid_BAB1.Value));

            FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            DataTable Dt = new DataTable();
            Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                bmmail = Dt.Rows[0]["email"].ToString();
                bmmailid = Dt.Rows[0]["bm"].ToString();
                rmmailid = Dt.Rows[0]["rm"].ToString();
                Session["BM"] = bmmailid.ToString();
                Session["rm"] = rmmailid.ToString();
                strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                Session["Companyaddress"] = strcompanyaddress;
            }

            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                Response.Redirect("FormMain.aspx");
            }
            else
            {
                Session["StrTranType"] = null;
                Session["RightsTranType"] = null;
                Response.Redirect("FormMain.aspx");
            }
        }

        protected void CHEB1_Click(object sender, EventArgs e)
        {
            Session["LoginBranchid"] = Convert.ToInt32(hid_CHEB1.Value);
            Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(hid_CHEB1.Value));

            FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            DataTable Dt = new DataTable();
            Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                bmmail = Dt.Rows[0]["email"].ToString();
                bmmailid = Dt.Rows[0]["bm"].ToString();
                rmmailid = Dt.Rows[0]["rm"].ToString();
                Session["BM"] = bmmailid.ToString();
                Session["rm"] = rmmailid.ToString();
                strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                Session["Companyaddress"] = strcompanyaddress;
            }

            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                Response.Redirect("FormMain.aspx");
            }
            else
            {
                Session["StrTranType"] = null;
                Session["RightsTranType"] = null;
                Response.Redirect("FormMain.aspx");
            }
        }

        protected void COCB1_Click(object sender, EventArgs e)
        {
            Session["LoginBranchid"] = Convert.ToInt32(hid_COCB1.Value);
            Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(hid_COCB1.Value));

            FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            DataTable Dt = new DataTable();
            Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                bmmail = Dt.Rows[0]["email"].ToString();
                bmmailid = Dt.Rows[0]["bm"].ToString();
                rmmailid = Dt.Rows[0]["rm"].ToString();
                Session["BM"] = bmmailid.ToString();
                Session["rm"] = rmmailid.ToString();
                strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                Session["Companyaddress"] = strcompanyaddress;
            }

            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                Response.Redirect("FormMain.aspx");
            }
            else
            {
                Session["StrTranType"] = null;
                Session["RightsTranType"] = null;
                Response.Redirect("FormMain.aspx");
            }
        }

        protected void COIB1_Click(object sender, EventArgs e)
        {
            Session["LoginBranchid"] = Convert.ToInt32(hid_COIB1.Value);
            Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(hid_COIB1.Value));

            FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            DataTable Dt = new DataTable();
            Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                bmmail = Dt.Rows[0]["email"].ToString();
                bmmailid = Dt.Rows[0]["bm"].ToString();
                rmmailid = Dt.Rows[0]["rm"].ToString();
                Session["BM"] = bmmailid.ToString();
                Session["rm"] = rmmailid.ToString();
                strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                Session["Companyaddress"] = strcompanyaddress;
            }

            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                Response.Redirect("FormMain.aspx");
            }
            else
            {
                Session["StrTranType"] = null;
                Session["RightsTranType"] = null;
                Response.Redirect("FormMain.aspx");
            }
        }

        //protected void CORB1_Click(object sender, EventArgs e)
        //{
        //    Session["LoginBranchid"] = Convert.ToInt32(hid_CORB1.Value);
        //    Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(hid_CORB1.Value));

        //    FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
        //    DataTable Dt = new DataTable();
        //    Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
        //    if (Dt.Rows.Count > 0)
        //    {
        //        bmmail = Dt.Rows[0]["email"].ToString();
        //        bmmailid = Dt.Rows[0]["bm"].ToString();
        //        rmmailid = Dt.Rows[0]["rm"].ToString();
        //        Session["BM"] = bmmailid.ToString();
        //        Session["rm"] = rmmailid.ToString();
        //        strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
        //        Session["Companyaddress"] = strcompanyaddress;
        //    }

        //    if (Session["LoginBranchName"].ToString() == "CORPORATE")
        //    {
        //        Session["StrTranType"] = "CO";
        //        Session["RightsTranType"] = "MI";
        //        //Response.Redirect("Cor_MainModuleNew.aspx");
        //        Response.Redirect("FormMain.aspx");
        //    }
        //    else
        //    {
        //        Session["StrTranType"] = null;
        //        Session["RightsTranType"] = null;
        //        Response.Redirect("FormMain.aspx");
        //    }
        //}

        protected void LUDB1_Click(object sender, EventArgs e)
        {
            Session["LoginBranchid"] = Convert.ToInt32(hid_LUDB1.Value);
            Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(hid_LUDB1.Value));

            FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            DataTable Dt = new DataTable();
            Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                bmmail = Dt.Rows[0]["email"].ToString();
                bmmailid = Dt.Rows[0]["bm"].ToString();
                rmmailid = Dt.Rows[0]["rm"].ToString();
                Session["BM"] = bmmailid.ToString();
                Session["rm"] = rmmailid.ToString();
                strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                Session["Companyaddress"] = strcompanyaddress;
            }

            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                Response.Redirect("FormMain.aspx");
            }
            else
            {
                Session["StrTranType"] = null;
                Session["RightsTranType"] = null;
                Response.Redirect("FormMain.aspx");
            }
        }

        protected void HYDB1_Click(object sender, EventArgs e)
        {
            Session["LoginBranchid"] = Convert.ToInt32(hid_HYDB1.Value);
            Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(hid_HYDB1.Value));

            FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            DataTable Dt = new DataTable();
            Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                bmmail = Dt.Rows[0]["email"].ToString();
                bmmailid = Dt.Rows[0]["bm"].ToString();
                rmmailid = Dt.Rows[0]["rm"].ToString();
                Session["BM"] = bmmailid.ToString();
                Session["rm"] = rmmailid.ToString();
                strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                Session["Companyaddress"] = strcompanyaddress;
            }

            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                Response.Redirect("FormMain.aspx");
            }
            else
            {
                Session["StrTranType"] = null;
                Session["RightsTranType"] = null;
                Response.Redirect("FormMain.aspx");
            }
        }

        protected void MUMB1_Click(object sender, EventArgs e)
        {
            Session["LoginBranchid"] = Convert.ToInt32(hid_MUMB1.Value);
            Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(hid_MUMB1.Value));

            FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            DataTable Dt = new DataTable();
            Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                bmmail = Dt.Rows[0]["email"].ToString();
                bmmailid = Dt.Rows[0]["bm"].ToString();
                rmmailid = Dt.Rows[0]["rm"].ToString();
                Session["BM"] = bmmailid.ToString();
                Session["rm"] = rmmailid.ToString();
                strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                Session["Companyaddress"] = strcompanyaddress;
            }

            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                Response.Redirect("FormMain.aspx");
            }
            else
            {
                Session["StrTranType"] = null;
                Session["RightsTranType"] = null;
                Response.Redirect("FormMain.aspx");
            }
        }

        protected void NEWB1_Click(object sender, EventArgs e)
        {
            Session["LoginBranchid"] = Convert.ToInt32(hid_NEWB1.Value);
            Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(hid_NEWB1.Value));

            FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            DataTable Dt = new DataTable();
            Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                bmmail = Dt.Rows[0]["email"].ToString();
                bmmailid = Dt.Rows[0]["bm"].ToString();
                rmmailid = Dt.Rows[0]["rm"].ToString();
                Session["BM"] = bmmailid.ToString();
                Session["rm"] = rmmailid.ToString();
                strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                Session["Companyaddress"] = strcompanyaddress;
            }

            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                Response.Redirect("FormMain.aspx");
            }
            else
            {
                Session["StrTranType"] = null;
                Session["RightsTranType"] = null;
                Response.Redirect("FormMain.aspx");
            }
        }

        protected void TIRB1_Click(object sender, EventArgs e)
        {
            Session["LoginBranchid"] = Convert.ToInt32(hid_TIRB1.Value);
            Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(hid_TIRB1.Value));

            FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            DataTable Dt = new DataTable();
            Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                bmmail = Dt.Rows[0]["email"].ToString();
                bmmailid = Dt.Rows[0]["bm"].ToString();
                rmmailid = Dt.Rows[0]["rm"].ToString();
                Session["BM"] = bmmailid.ToString();
                Session["rm"] = rmmailid.ToString();
                strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                Session["Companyaddress"] = strcompanyaddress;
            }

            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                Response.Redirect("FormMain.aspx");
            }
            else
            {
                Session["StrTranType"] = null;
                Session["RightsTranType"] = null;
                Response.Redirect("FormMain.aspx");
            }
        }

        protected void TUTB1_Click(object sender, EventArgs e)
        {
            Session["LoginBranchid"] = Convert.ToInt32(hid_TUTB1.Value);
            Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(hid_TUTB1.Value));

            FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            DataTable Dt = new DataTable();
            Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                bmmail = Dt.Rows[0]["email"].ToString();
                bmmailid = Dt.Rows[0]["bm"].ToString();
                rmmailid = Dt.Rows[0]["rm"].ToString();
                Session["BM"] = bmmailid.ToString();
                Session["rm"] = rmmailid.ToString();
                strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                Session["Companyaddress"] = strcompanyaddress;
            }

            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                Response.Redirect("FormMain.aspx");
            }
            else
            {
                Session["StrTranType"] = null;
                Session["RightsTranType"] = null;
                Response.Redirect("FormMain.aspx");
            }

        }

        protected void VISB1_Click(object sender, EventArgs e)
        {
            Session["LoginBranchid"] = Convert.ToInt32(hid_VISB1.Value);
            Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(hid_VISB1.Value));

            FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            DataTable Dt = new DataTable();
            Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                bmmail = Dt.Rows[0]["email"].ToString();
                bmmailid = Dt.Rows[0]["bm"].ToString();
                rmmailid = Dt.Rows[0]["rm"].ToString();
                Session["BM"] = bmmailid.ToString();
                Session["rm"] = rmmailid.ToString();
                strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                Session["Companyaddress"] = strcompanyaddress;
            }

            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                Response.Redirect("FormMain.aspx");
            }
            else
            {
                Session["StrTranType"] = null;
                Session["RightsTranType"] = null;
                Response.Redirect("FormMain.aspx");
            }
        }

        protected void WARB1_Click(object sender, EventArgs e)
        {
            Session["LoginBranchid"] = Convert.ToInt32(hid_WARB1.Value);
            Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(hid_WARB1.Value));

            FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            DataTable Dt = new DataTable();
            Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                bmmail = Dt.Rows[0]["email"].ToString();
                bmmailid = Dt.Rows[0]["bm"].ToString();
                rmmailid = Dt.Rows[0]["rm"].ToString();
                Session["BM"] = bmmailid.ToString();
                Session["rm"] = rmmailid.ToString();
                strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                Session["Companyaddress"] = strcompanyaddress;
            }

            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                Response.Redirect("FormMain.aspx");
            }
            else
            {
                Session["StrTranType"] = null;
                Session["RightsTranType"] = null;
                Response.Redirect("FormMain.aspx");
            }
        }
        protected void Tasks_Click(object sender, EventArgs e)
        {
            Linkcorpor.Text = "Task Managment";
            Linkcorpor_Click(sender, e);
            Linkcorpor.Visible = true;
            Session["Tasks"] = "Tasks";
        }

        protected void linkBooking_Click(object sender, EventArgs e)
        {
            if (Booking.Text != "")
            {
                //ifrmaster.Attributes["src"] = "Mainmodule_product.aspx";
                if (lnkbtn.Text == "OCEAN EXPORTS")
                {
                    DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtblnoFE = masterObj.GetBLDetails2(Booking.Text);
                    if (dtblnoFE.Rows.Count > 0)
                    {


                        string BL_No = Booking.Text;
                        //string feblDetailsUrl = ResolveUrl("ShipmentDetails/FEBLdetails.aspx?BL_No=" + BL_No);
                        //ScriptManager.RegisterStartupScript(this, GetType(), "RedirectScript", "redirectToFEBL('" + feblDetailsUrl + "');", true);
                        //Response.Redirect("/Mainmodule_product.aspx");
                        //Response.Redirect("/ShipmentDetails/FEBLdetails.aspx?BL_No=" + BL_No);
                        //ifrmaster.Attributes["src"] = "./OceanExportsOps_Docs.aspx";
                        //ifrmaster.Attributes["src"] = "../ShipmentDetails/FEBLdetails.aspx?BL_No=" + BL_No;
                        ifrmaster.Attributes["src"] = "Mainpage/OceanExportsOps_Docs.aspx?BL_No=" + BL_No;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alertify.alert('InValid BL No');", true);
                        Booking.Focus();
                        return;

                    }


                }
                if (lnkbtn.Text == "OCEAN IMPORTS")
                {

                    DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtblnoFI = masterObj.ShowBLDetailsBLNO(Booking.Text);

                    if (dtblnoFI.Rows.Count > 0)
                    {
                        string BL_No = Booking.Text;

                        ifrmaster.Attributes["src"] = "Mainpage/OceanImports_ops.aspx?BL_No=" + BL_No;

                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alertify.alert('InValid BL No');", true);
                        Booking.Focus();
                        return;

                    }

                }
                if (lnkbtn.Text == "AIR IMPORTS")
                {
                    string trantype = "AI";


                    DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtblnoAI = masterObj.GetAIEDetailBLNO(Booking.Text, trantype);
                    if (dtblnoAI.Rows.Count > 0)
                    {


                        string BL_No = Booking.Text;
                        ifrmaster.Attributes["src"] = "Mainpage/AirImports_ops.aspx?BL_No=" + BL_No;

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alertify.alert('InValid BL No');", true);
                        Booking.Focus();
                        return;

                    }

                }


                if (lnkbtn.Text == "AIR EXPORTS")
                {
                    string trantype = "AE";

                    DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                    DataTable dtblnoAE = masterObj.GetAIEDetailBLNO(Booking.Text, trantype);
                    if (dtblnoAE.Rows.Count > 0)
                    {


                        string BL_No = Booking.Text;
                        ifrmaster.Attributes["src"] = "Mainpage/AirExports_ops.aspx?BL_No=" + BL_No;
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alertify.alert('InValid BL No');", true);
                        Booking.Focus();
                        return;

                    }
                }

            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alertify.alert('Please Enter BL NO');", true);
                ScriptManager.RegisterStartupScript(linkBooking, typeof(Button), "alert", "alertify.alert('Please Enter BL NO');", true);
                Booking.Focus();
                return;

            }

            Booking.Text = "";
            //Booking.Visible = false;
            //linkBooking.Visible = false;


        }
        protected void CALB1_Click(object sender, EventArgs e)
        {
            Session["LoginBranchid"] = Convert.ToInt32(hid_CALB1.Value);
            Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(hid_CALB1.Value));

            FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            DataTable Dt = new DataTable();
            Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                bmmail = Dt.Rows[0]["email"].ToString();
                bmmailid = Dt.Rows[0]["bm"].ToString();
                rmmailid = Dt.Rows[0]["rm"].ToString();
                Session["BM"] = bmmailid.ToString();
                Session["rm"] = rmmailid.ToString();
                strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                Session["Companyaddress"] = strcompanyaddress;
            }

            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                Response.Redirect("FormMain.aspx");
            }
            else
            {
                Session["StrTranType"] = null;
                Session["RightsTranType"] = null;
                Response.Redirect("FormMain.aspx");
            }
        }



        protected void grd_branch_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //  string charge = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CHARge"));
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#6dadbd';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_branch, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }



        protected void grd_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int index = grd_branch.SelectedRow.RowIndex;
            //Session["LoginBranchid"] = Convert.ToInt32(grd_branch.Rows[index].Cells[1].Text);
            //Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(grd_branch.Rows[index].Cells[1].Text));

            //FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            //DataTable Dt = new DataTable();
            //DataTable ddtew = new DataTable();
            //Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            //if (Dt.Rows.Count > 0)
            //{
            //    bmmail = Dt.Rows[0]["email"].ToString();
            //    bmmailid = Dt.Rows[0]["bm"].ToString();
            //    rmmailid = Dt.Rows[0]["rm"].ToString();
            //    Session["BM"] = bmmailid.ToString();
            //    Session["rm"] = rmmailid.ToString();
            //    strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
            //    Session["Companyaddress"] = strcompanyaddress;
            //}

            //else if (Session["LoginBranchid"].ToString() == "5")
            //{
            //    Session["StrTranType"] = "CO";
            //    Session["RightsTranType"] = "MI";
            //    //Response.Redirect("Cor_MainModuleNew.aspx");
            //    Response.Redirect("FormMain.aspx");
            //}
            //else
            //{
            //    Session["StrTranType"] = null;
            //    Session["RightsTranType"] = null;
            //    Response.Redirect("FormMain.aspx");
            //}
           
            int index = grd_branch.SelectedRow.RowIndex;
            Session["LoginBranchid"] = Convert.ToInt32(grd_branch.Rows[index].Cells[1].Text);
            Session["LoginBranchName"] = objbid.Getbranchname(Convert.ToInt32(grd_branch.Rows[index].Cells[1].Text));
            brname.Text = Session["LoginBranchName"].ToString();
         DataTable   dts = objbid.GetBranchandDivisionnew(Convert.ToInt32(Session["LoginBranchid"]));
              if (dts.Rows.Count > 0)
              {

                  Session["LoginDivisionId"] = dts.Rows[0]["divisionid"];
                  Session["LoginBranchName"] = dts.Rows[0]["portname"];
                  Session["LoginDivisionName"] = dts.Rows[0]["branchname"];
                  Session["countryid"] = dts.Rows[0]["countryid"];
              }

              if (Session["countryid"].ToString() != "1102" && Session["countryid"].ToString() != "102")
              {
                  br_Mainten.Visible = true;
                  if (Session["LoginDivisionName"].ToString() == "FORWARDING PRIVATE LTD")
                  {
                      MISandAnalysis.Visible = false;
                      FCAC.Visible = false;
                      ddl_FCYear.Visible = false;
                  }                                   
              }
              else
              {
                  br_Mainten.Visible = false;
                  if (Session["LoginDivisionName"].ToString() == "FORWARDING PRIVATE LTD")
                  {
                      MISandAnalysis.Visible = false;
                      FCAC.Visible = false;
                      ddl_FCYear.Visible = false;
                  }
                  else
                  {
                      MISandAnalysis.Visible = true;
                      FCAC.Visible = true;
                      ddl_FCYear.Visible = true;
                  }
              }

            FrontpageObj.InsMasterACCode(Session["LoginDivisionName"].ToString(), Session["LoginBranchName"].ToString(), Convert.ToInt32(Session["Vouyear"].ToString()));
            DataTable obj_Dt = new DataTable();
            DataAccess.userlogin obj_login = new DataAccess.userlogin();
            obj_Dt = obj_login.selEmpDetailsWOROLnew(Session["LoginUserName"].ToString());
            Session["Process"] = obj_Dt.Rows[0]["process"].ToString();


            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                lnkbtn.Visible = false;
                Linkcorpor.Visible = true;
                Linkcorpor.Text = "MAINTENANCE";

            }
            else
            {
                if (Session["Process"].ToString() != "")
                {
                    lnkbtn.Visible = true;
                   Linkcorpor.Visible = false;
                    lnkbtn.Text = Session["Process"].ToString();
                }
            }







            //if (Session["Process"].ToString() != "")
            //{
            //    lnkbtn.Text = Session["Process"].ToString();
            //    Linkcorpor.Text = "PRODUCT NAME";
            //    if (Session["LoginBranchName"].ToString() == "CORPORATE")
            //    {
                    
            //        lnkbtn.Visible = false;
            //        Linkcorpor.Visible = true;
            //        Linkcorpor.Text = "PRODUCT NAME";
            //    }
            //    else
            //    {
            //        lnkbtn.Visible = true;
            //        lnkbtn.Text = Session["Process"].ToString();
            //        Linkcorpor.Visible = false;
            //    }
            //}
            //else
            //{
            //    lnkbtn.Text = "PRODUCT NAME";
            //    Linkcorpor.Text = "PRODUCT NAME";
            //    if (Session["LoginBranchName"].ToString()=="CORPORATE")
            //    {
            //        Linkcorpor.Text = "PRODUCT NAME";
            //        lnkbtn.Visible = false;
            //        Linkcorpor.Visible = true;
            //    }
            //    else
            //    {
            //        lnkbtn.Visible = true;
            //        Linkcorpor.Visible = false;
            //    }
                
            //}
            DataTable Dt = new DataTable();
            Dt = da_obj_Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                bmmail = Dt.Rows[0]["email"].ToString();
                bmmailid = Dt.Rows[0]["bm"].ToString();
                rmmailid = Dt.Rows[0]["rm"].ToString();
                Session["BM"] = bmmailid.ToString();
                Session["rm"] = rmmailid.ToString();
                strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                Session["Companyaddress"] = strcompanyaddress;
            }

            if (Session["LoginBranchName"].ToString() == "CORPORATE")
            {
                Session["StrTranType"] = "CO";
                Session["RightsTranType"] = "MI";
                BL_Booking.Visible = false;
                Booking.Visible = false;
                linkBooking.Visible = false;
                Booking.Text = "";
                //Response.Redirect("Cor_MainModuleNew.aspx");
                //  Response.Redirect("FormMain.aspx");
                // Maintenance_Click(sender, e);
                if (Session["Processcor"].ToString() == "MAINTENANCE")
                    {
                        Maintenance_Click(sender, e);
                    BL_Booking.Visible = false;
                    Booking.Visible = false;
                    linkBooking.Visible = false;
                    Booking.Text = "";
                }
                else if (Session["Processcor"].ToString() == "MIS & ANALYTICS")
                    {
                        MISandAnalysis_Click(sender, e);
                    BL_Booking.Visible = false;
                    Booking.Visible = false;
                    linkBooking.Visible = false;
                    Booking.Text = "";
                }
                else if (Session["Processcor"].ToString() == "FINANCIAL ACCOUNTS")
                    {
                        FCAC_Click(sender, e);
                    BL_Booking.Visible = false;
                    Booking.Visible = false;
                    linkBooking.Visible = false;
                    Booking.Text = "";
                }
                else
                  {
                      Maintenance_Click(sender, e);
                    BL_Booking.Visible = false;
                    Booking.Visible = false;
                    linkBooking.Visible = false;
                    Booking.Text = "";
                }




               // Linkcorpor.Visible = true;
            }
            else
            {
                Session["StrTranType"] = null;
                Session["RightsTranType"] = null;
                if (Session["Process"].ToString() != "")
                {
                    if (Session["Process"].ToString() == "SALES")
                    {
                        SalesHome_Click(sender, e);
                        BL_Booking.Visible = false;
                        Booking.Visible = false;
                        linkBooking.Visible = false;
                        Booking.Text = "";
                    }
                    else if (Session["Process"].ToString() == "OCEAN EXPORTS")
                    {
                        OEOpsDocsHome_Click(sender, e);
                        BL_Booking.Visible = true;
                        Booking.Visible = true;
                        linkBooking.Visible = true;
                        Booking.Text = "";
                    }
                    else if (Session["Process"].ToString() == "OCEAN IMPORTS")
                    {
                        OIOpsDocsHome_Click(sender, e);
                        BL_Booking.Visible = true;
                        Booking.Visible = true;
                        linkBooking.Visible = true;
                        Booking.Text = "";
                    }
                    else if (Session["Process"].ToString() == "AIR IMPORTS")
                    {
                        AIOpsDocsHome_Click(sender, e);
                        BL_Booking.Visible = true;
                        Booking.Visible = true;
                        linkBooking.Visible = true;
                        Booking.Text = "";

                    }
                    else if (Session["Process"].ToString() == "AIR EXPORTS")
                    {
                        AEOpsDocsHome_Click(sender, e);
                        BL_Booking.Visible = true;
                        Booking.Visible = true;
                        linkBooking.Visible = true;
                        Booking.Text = "";
                    }
                    else if (Session["Process"].ToString() == "MIS & ANALYTICS")
                    {
                        MISHome_Click(sender, e);
                        BL_Booking.Visible = false;
                        Booking.Visible = false;
                        linkBooking.Visible = false;
                        Booking.Text = "";

                    }
                    else if (Session["Process"].ToString() == "FINANCIAL ACCOUNTS")
                    {

                        FAHome_Click(sender, e);
                        BL_Booking.Visible = false;
                        Booking.Visible = false;
                        linkBooking.Visible = false;
                        Booking.Text = "";
                    }
                   

                }
                else
                {
                    Response.Redirect("FormMain.aspx");
                }

            }
        }

        

        protected void br_Mainten_Click(object sender, EventArgs e)
        {
            lnkbtn_Click1(sender, e);
            lnkbtn.Text = "MAINTENANCE";
            lnkbtn.Visible = true;         
            Session["COMaintenance"] = "COMaintenance";
        }




    }
}