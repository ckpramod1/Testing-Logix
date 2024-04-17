using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;


namespace logix.MainPage
{
    public partial class Main_Corporate : System.Web.UI.Page
    {
        DataAccess.HR.Employee da_obj_Emp = new DataAccess.HR.Employee();
        DataAccess.UserPermission Obj_Permission = new DataAccess.UserPermission();
        DataAccess.Masters.MasterEmployee employee = new DataAccess.Masters.MasterEmployee();
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_Emp.GetDataBase(Ccode);
                Obj_Permission.GetDataBase(Ccode);
                employee.GetDataBase(Ccode);

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
                return;
            }
            string Str_Trantype = "", str_menuhead = "", str_ModuleName = "";
            int Emp_Id, Division_ID, Branch_ID;

            DataTable dt_UserPermission = new DataTable();
            DataTable dt_MenuRights = new DataTable();

           /* lbl_CompanyName.Text = Session["LoginDivisionName"].ToString() + " , " + Session["LoginBranchName"].ToString();
            lbl_UserName.Text = Session["LoginEmpName"].ToString();
            Emp_Id = Convert.ToInt32(Session["LoginEmpId"]);
            Division_ID = Convert.ToInt32(Session["LoginDivisionid"]);
            Branch_ID = da_obj_Emp.GetBranchId(Division_ID, Session["LoginBranchName"].ToString());
            lblcname.Text = Session["LoginEmpName"].ToString();
            lblcname.Text = lblcname.Text.ToLowerInvariant();
            lblLoginYear.Text = "Financial Accounts  " + Session["FA_Year"].ToString();
            //lblcompany.Text = Session["LoginDivisionName"].ToString();
            //lblcompany.Text = lblcompany.Text.ToLowerInvariant() + "," + Session["LoginBranchName"].ToString().ToLowerInvariant();


            lblcname.Text = Session["LoginEmpName"].ToString();
            lblcname.Text = lblcname.Text.ToLowerInvariant();
            lbldesg.Text = Session["designation"].ToString();
            lbldesg.Text = lbldesg.Text.ToLowerInvariant();
            lbldept.Text = Session["dept"].ToString();
            lbldept.Text = lbldept.Text.ToLowerInvariant();
            lblport.Text = Session["branch"].ToString();
            lblport.Text = lblport.Text.ToLowerInvariant();*/

            string username = Session["LoginUserName"].ToString();

            DataTable dt = new DataTable();
            dt = employee.GetEmployeeDetails(username);


            StringBuilder str_MenuDesign = new StringBuilder();
            StringBuilder str_MenuDesign1 = new StringBuilder();
            StringBuilder str_MenuDesign2 = new StringBuilder();
            StringBuilder str_MenuDesign3 = new StringBuilder();
            StringBuilder str_MenuDesign4 = new StringBuilder();
            StringBuilder str_MenuDesign5 = new StringBuilder();
            StringBuilder str_MenuDesign6 = new StringBuilder();
            StringBuilder str_MenuDesign7 = new StringBuilder();
            StringBuilder str_MenuDesign8 = new StringBuilder();
            StringBuilder str_MenuDesign9 = new StringBuilder();
            StringBuilder str_MenuDesign10 = new StringBuilder();
            StringBuilder str_MenuDesign11 = new StringBuilder();
            StringBuilder str_MenuDesign12 = new StringBuilder();
            StringBuilder str_MenuDesign13 = new StringBuilder();

            if (!IsPostBack)
            {
                if (Session["FA_Year"] != null)
                {
                    lblLoginYear.Visible = true;
                    lblLoginYear.Text = " " + Session["FA_Year"].ToString();
                }
                if (Session["StrTranType"].ToString() == "BR")
                {
                    str_ModuleName = "FA";
                    Str_Trantype = "FA";
                    Session["str_ModuleName"] = str_ModuleName;
                    Session["StrTranType"] = "AC";
                    Session["HeadTranType"] = "FA";
                }
                if (Session["StrTranType"] == "CA" || Session["StrTranType"] == "CO")
                {
                    str_ModuleName = "FC";
                    Str_Trantype = "FC";
                    Session["str_ModuleName"] = str_ModuleName;
                    Session["StrTranType"] = "CO";
                    Session["HeadTranType"] = "FC";
                }

                dt_MenuRights = Obj_Permission.GetMenus(Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["str_ModuleName"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                Session["dt_UserRights"] = dt_MenuRights;

                if (dt_MenuRights.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                    {
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Account Info")
                        {
                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Groups" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Sub Groups" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Ledgers" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "L&ist of Accounts")
                            {
                                AccountInfo.Visible = true;
                                str_MenuDesign.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                                str_MenuDesign.Append("</li>");
                                div_accountinfo.InnerHtml = str_MenuDesign.ToString();
                            }
                        }

                        //if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Vouchers")
                        //{
                        //    if (
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Payments" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Payment Cance&l" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Admin Voucehers" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Not Over Cheque" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Cheque &Request" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Receipts" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "R&emittance - Receipt" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Re&mittance - Payment" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Con&tra" ||
                        //        // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Receipts_Tax" ||     //NewOne    //08/08/2022
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Payments_Tax" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Journal" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Deposit &Slip" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&BRS" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Che&que Clearance" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Service Ta&x Amendment" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Che&que Clearance" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Adjustment DN/CN" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OSSI" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OSPI" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Journa&l"
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Debit Note" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Credit Note" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Cheque Request Vouyearwise" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Invoice" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Profoma Credit Note - Operations" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Invoice" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Credit Note - Operations" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OPBalance Breakup" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&ReceiptsNew" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&PaymentNew" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Receipts New Backdated" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Payment New Backdated" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Bill of Supply")
                        //        )
                        //    {
                        //        Vouchers.Visible = true;
                        //        if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() != "Admin Voucehers")
                        //        {
                        //            str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                        //        }
                        //        else
                        //        {
                        //            str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='#' title='Admin Vouchers'>Admin Vouchers &raquo;</a>");
                        //            str_MenuDesign1.Append("<ul class='navigation-3'>");

                        //            str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profoma DN-Admin.aspx?FormName=Proforma DN-Admin&uiid=1180' target='MainFrame' onclick ='ifrmaster'>Proforma DN-Admin</a>");
                        //            str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profoma DN-Admin.aspx?FormName=Proforma CN-Admin&uiid=1181' target='MainFrame' onclick ='ifrmaster'>Proforma CN-Admin</a>");
                        //            //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNO.aspx?FormName=Admin Sales Invoice&uiid=1182' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                        //            //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNO.aspx?FormName=Admin Purchase Invoice&uiid=1183' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");
                        //            str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Sales Invoice&uiid=10004' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                        //            str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Purchase Invoice&uiid=10005' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");

                        //            str_MenuDesign1.Append("</ul>");
                        //        }

                        //        str_MenuDesign1.Append("</li>");
                        //        div_Vouchers.InnerHtml = str_MenuDesign1.ToString();
                        //    }
                        //}


                        //another start kalai
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Vouchers")
                        {
                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Admin Voucehers" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Journa&l")
                            {
                                Vouchers.Visible = true;
                                if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() != "Admin Voucehers")
                                {
                                    str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                                }
                                else
                                {
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='#' title='Admin Vouchers'>Admin Vouchers &raquo;</a>");
                                    //str_MenuDesign1.Append("<ul class='navigation-3'>");

                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profoma DN-Admin.aspx?FormName=Proforma DN-Admin&uiid=1180' target='MainFrame' onclick ='ifrmaster'>Proforma DN-Admin</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profoma DN-Admin.aspx?FormName=Proforma CN-Admin&uiid=1181' target='MainFrame' onclick ='ifrmaster'>Proforma CN-Admin</a>");
                                    ////str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNO.aspx?FormName=Admin Sales Invoice&uiid=1182' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                                    ////str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNO.aspx?FormName=Admin Purchase Invoice&uiid=1183' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");
                                    ////str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Sales Invoice&uiid=10004' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                                    ////str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Purchase Invoice&uiid=10005' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Sales Invoice&uiid=10004' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Purchase Invoice&uiid=10005' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");
                                    //str_MenuDesign1.Append("</ul>");
                                    str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='#' title='Admin Vouchers'>Admin Vouchers &raquo;</a>");
                                    str_MenuDesign1.Append("<ul class='navigation-3'>");

                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profoma DN-Admin.aspx?FormName=Proforma DN-Admin&uiid=1180' target='MainFrame' onclick ='ifrmaster'>Proforma DN-Admin</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profoma DN-Admin.aspx?FormName=Proforma CN-Admin&uiid=1181' target='MainFrame' onclick ='ifrmaster'>Proforma CN-Admin</a>");


                                    str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profomaAdminVouchers.aspx?FormName=Proforma Admin Vouchers&uiid=10090' target='MainFrame' onclick ='ifrmaster'>Proforma Admin Vouchers</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profoma DN-Admin.aspx?FormName=Proforma CN-Admin&uiid=1181' target='MainFrame' onclick ='ifrmaster'>Proforma CN-Admin</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNO.aspx?FormName=Admin Sales Invoice&uiid=1182' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNO.aspx?FormName=Admin Purchase Invoice&uiid=1183' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Sales Invoice&uiid=10004' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Purchase Invoice&uiid=10005' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Sales Invoice&uiid=10004' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Purchase Invoice&uiid=10005' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");
                                    str_MenuDesign1.Append("</ul>");
                                }

                                str_MenuDesign1.Append("</li>");
                                div_Vouchers.InnerHtml = str_MenuDesign1.ToString();
                            }

                            if ( dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Payments" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Payment Cance&l" ||
                                
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Not Over Cheque" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Cheque &Request" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Receipts" ||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&ReceiptsNew" ||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Admin Voucehers" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&PaymentsNew" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "R&emittance - Receipt" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Re&mittance - Payment" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Con&tra" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Journal" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Deposit &Slip" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&BRS" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Che&que Clearance"
                                 || dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OPBalanceBreakUpNew"
                                )
                            {
                                Vouchers.Visible = true;
                                if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() != "Admin Voucehers")
                                {
                                    str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                                }
                                else
                                {
                                    //str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='#' title='Admin Vouchers'>Admin Vouchers &raquo;</a>");
                                    //str_MenuDesign12.Append("<ul class='navigation-3'>");

                                    ////str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profoma DN-Admin.aspx?FormName=Proforma DN-Admin&uiid=1180' target='MainFrame' onclick ='ifrmaster'>Proforma DN-Admin</a>");
                                    ////str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profoma DN-Admin.aspx?FormName=Proforma CN-Admin&uiid=1181' target='MainFrame' onclick ='ifrmaster'>Proforma CN-Admin</a>");
                                    ////str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNO.aspx?FormName=Admin Sales Invoice&uiid=1182' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                                    ////str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNO.aspx?FormName=Admin Purchase Invoice&uiid=1183' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");
                                    //str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Sales Invoice&uiid=10004' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                                    //str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Purchase Invoice&uiid=10005' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");

                                    //str_MenuDesign12.Append("</ul>");
                                    str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='#' title='Admin Vouchers'>Admin Vouchers &raquo;</a>");
                                    str_MenuDesign12.Append("<ul class='navigation-3'>");
                                    str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/ApprovedAdminDCNvouchers.aspx?FormName=Approved Admin Vouchers&uiid=10005' target='MainFrame' onclick ='ifrmaster'>Approved Admin Vouchers</a>");
                                    //str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profoma DN-Admin.aspx?FormName=Proforma DN-Admin&uiid=1180' target='MainFrame' onclick ='ifrmaster'>Proforma DN-Admin</a>");
                                    //str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profoma DN-Admin.aspx?FormName=Proforma CN-Admin&uiid=1181' target='MainFrame' onclick ='ifrmaster'>Proforma CN-Admin</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNO.aspx?FormName=Admin Sales Invoice&uiid=1182' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNO.aspx?FormName=Admin Purchase Invoice&uiid=1183' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");
                                    //str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Sales Invoice&uiid=10004' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                                    //str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Purchase Invoice&uiid=10005' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");

                                    str_MenuDesign12.Append("</ul>");
                                }

                                str_MenuDesign12.Append("</li>");
                                div_App.InnerHtml = str_MenuDesign12.ToString();
                            }
                        }

                        //end kalai




                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "A&pproval")
                        {
                            if (
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Payment Request Approval" ||
                               //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&CO Deline" ||
                               //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Payments Approval" ||
                               dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Admin to Commercial-Admin" ||
                               //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&DN Proforma to Commercial-Admin" ||
                               dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Journal Proforma to Commercial" //||
                               //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Cheque Request Approval Vouyearwise" ||
                               //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Invoice Proforma to Commercial" ||
            
                               //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "CN-Ops Proforma to Commercial"
                                )
                            {
                                Approval.Visible = true;
                                str_MenuDesign2.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                                str_MenuDesign2.Append("</li>");
                                divApproval.InnerHtml = str_MenuDesign2.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Reports")
                        {
                            if (//dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&DayBook" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Account Book" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Group Summary" ||
                               // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Statement of Accounts" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Trial Balance" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Profit and Loss Account" ||
                                (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Ledger - PAN" && dt_MenuRights.Rows[i]["uiid"].ToString().Trim() == "10082") ||  // Hari [28-12-2023]
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Balance Sheet" //||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Indirect &Expense Summary" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Fund Flow" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "IndirectExpense Ledgerwise" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "FCur Balance" ||
                                //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "TurnOver"||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Ledger Transfer"
                                )
                            {
                                Reports.Visible = true;
                                if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() != "&Account Book" && dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() != "&Statement of Accounts")
                                {
                                    str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                                   
                                }
                                else
                                {
                                    if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Account Book")
                                    {
                                        str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' title='Account Book'>Account Book &raquo;</a>");
                                        str_MenuDesign3.Append("<ul class='navigation-3'>");

                                        str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/FALedgerView.aspx?FormName=Ledger&uiid=1782' target='MainFrame' onclick ='ifrmaster'>Ledger</a>");
                                        str_MenuDesign3.Append("<li style='list-style:none'><a class='Text' href='../FAForms/VoucherRegister.aspx?FormName=Registers&uiid=1783' target='MainFrame' onclick ='ifrmaster'>Registers</a>");
                                        //str_MenuDesign3.Append("<li class='liststylenone' style='border-bottom:0px solid #f00;'><a class='drawer-dropdown-menu-item' href='../FAForms/GSTRegisters.aspx?FormName=GST Registers&uiid=1901' target='MainFrame' onclick ='ifrmaster'>GST Registers</a>");
                                        str_MenuDesign3.Append("</ul>");
                                    }

                                    //if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Statement of Accounts")
                                    //{
                                    //    str_MenuDesign3.Append("<li class='liststylenone'><a title='Statement of Accounts'>Statement of Accounts &raquo;</a>");
                                    //    str_MenuDesign3.Append("<ul class='navigation-3'>");

                                    //    str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/FACostCategory.aspx?FormName=Cost Category&uiid=1204' target='MainFrame' onclick ='ifrmaster'>Cost Category</a>");
                                    //    str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/CostCenter.aspx?FormName=Cost Center&uiid=1204' target='MainFrame' onclick ='ifrmaster'>Cost Center</a>");
                                    //    str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/Statistics of Register.aspx?FormName=Statistics Register&uiid=1204' target='MainFrame' onclick ='ifrmaster'>Statistics Register</a>");
                                    //    str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/Statistics.aspx?FormName=Statistics&uiid=1204' target='MainFrame' onclick ='ifrmaster'>Statistics</a>");
                                    //    str_MenuDesign3.Append("<li style='list-style:none'><a class='drawer-dropdown-menu-item' href='../FAForms/ServiceTaxStatistics.aspx?FormName=TAX Report&uiid=1204' target='MainFrame' onclick ='ifrmaster'>TAX Report</a>");
                                    //    str_MenuDesign3.Append("</ul>");
                                    //}
                                }
                                str_MenuDesign3.Append("</li>");
                                divReports.InnerHtml = str_MenuDesign3.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Outstanding &New")
                        {
                            //if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding - Schedule" || dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding - Online")
                            //{
                            //    OutstandingNew.Visible = true;
                            //    str_MenuDesign4.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                            //    str_MenuDesign4.Append("</li>");
                            //    divOutstanding.InnerHtml = str_MenuDesign4.ToString();
                            //}

                             

                          /*  if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding - Schedule")
                            {
                                OutstandingNew.Visible = true;
                                str_MenuDesign4.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/Outstanding_New.aspx?FormName=Outstanding - Schedule&uiid=1424' target='MainFrame' onclick ='ifrmaster'>Outstanding - Schedule</a>");
                                str_MenuDesign4.Append("</li>");
                                divOutstanding.InnerHtml = str_MenuDesign4.ToString();
                            }

                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding - Online")
                            {
                                OutstandingNew.Visible = true;
                                str_MenuDesign4.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/Outstanding_Online.aspx?FormName=Outstanding - Online&uiid=1425' target='MainFrame' onclick='return ConfirmMsg();'>Outstanding - Online</a>");
                                str_MenuDesign4.Append("</li>");
                                divOutstanding.InnerHtml = str_MenuDesign4.ToString();
                            }*/
                            //if(Session["LoginEmpId"].ToString()=="124" || Session["loginEmpId"].ToString()=="246")
                            //{
                                
                            //}

                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding - OnlineNew")
                            {
                                OutstandingNew.Visible = true;
                                str_MenuDesign4.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/Outstanding_Online_newSlab.aspx?FormName=Outstanding - Online&uiid=1877' target='MainFrame'>Outstanding</a>");   // onclick='return ConfirmMsg();'
                                str_MenuDesign4.Append("</li>");
                                divOutstanding.InnerHtml = str_MenuDesign4.ToString();
                            }
                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding All")
                            {
                                OutstandingNew.Visible = true;
                                str_MenuDesign4.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/outstandingall.aspx?FormName=Outstanding - Online&uiid=1926' target='MainFrame'>Outstanding All</a>");
                                str_MenuDesign4.Append("</li>");
                                divOutstanding.InnerHtml = str_MenuDesign4.ToString();
                            }
                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding Credit")
                            {
                                OutstandingNew.Visible = true;
                                str_MenuDesign4.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/OutstandingCreditCustomerWise.aspx?FormName=Outstanding - Online&uiid=1928' target='MainFrame'>Outstanding Credit</a>");
                                str_MenuDesign4.Append("</li>");
                                divOutstanding.InnerHtml = str_MenuDesign4.ToString();
                            } 
                            //if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "NewOutstanding - Online")  
                            //{
                            //    OutstandingNew.Visible = true;
                            //    str_MenuDesign4.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/OutstandingNewOnline.aspx?FormName=Outstanding - Online&uiid=1879' target='MainFrame' onclick='return ConfirmMsg();'>NewOutstanding - Online</a>");
                            //    str_MenuDesign4.Append("</li>");
                            //    divOutstanding.InnerHtml = str_MenuDesign4.ToString();
                            //} 
                        }

                        //if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&M I S")
                        //{
                        //    if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "M I S")
                        //    {
                        //        MIS.Visible = true;
                        //        str_MenuDesign5.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                        //        str_MenuDesign5.Append("</li>");
                        //        divMIS.InnerHtml = str_MenuDesign5.ToString();
                        //    }
                        //}

                        //if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Query")
                        //{
                        //    if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Che&que" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Amount" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Cost &Sheet" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&CN - Admin TDS" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Multiple Query")
                        //    {
                        //        Query.Visible = true;
                        //        str_MenuDesign6.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                        //        str_MenuDesign6.Append("</li>");
                        //        divQuery.InnerHtml = str_MenuDesign6.ToString();
                        //    }
                        //}

                        //if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&CTC")
                        //{
                        //    if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Co&llections" ||
                        //       dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Payments" ||
                        //       dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Overseas Agent Balance" ||
                        //       dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Bank Balance")
                        //    {
                        //        CTC.Visible = true;
                        //        str_MenuDesign7.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                        //        str_MenuDesign7.Append("</li>");
                        //        div_CTC.InnerHtml = str_MenuDesign7.ToString();
                        //    }
                        //}

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&FA Edi")
                        {
                            if (
                               // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Corporate XML" ||
                               // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&FA Edi" ||
                               //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "CN-Ops TDS" ||
                               //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "CN - Admin TDS" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Tally XML"
                                )
                            {
                                FAEdi.Visible = true;
                                str_MenuDesign8.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                                str_MenuDesign8.Append("</li>");
                                divFAEdi.InnerHtml = str_MenuDesign8.ToString();
                            }
                        }

                        //if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Credit")
                        //{
                        //    if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Credit Approval Limits" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "DSO Days" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Credit Approval")
                        //    //|| dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Credit Exemption")
                        //    {
                        //        Credit.Visible = true;
                        //        str_MenuDesign9.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                        //        str_MenuDesign9.Append("</li>");
                        //        divCredit.InnerHtml = str_MenuDesign9.ToString();
                        //    }
                        //}

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Utility")
                        {
                            if (
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Cheque &Bounce" ||
                              //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Customer &TDS" ||
                             dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Change &LedgerName" ||
                              //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Merge LedgerName" ||
                              //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Merge LedgerNameNew" ||
                              //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Block Ledger Name" ||
                              //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&User Rights" ||
                              //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "MIS Reconciliation" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Voucher Count - Ops Vs FA" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Collection > 60 Days" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Journal BackDate Rights" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Unclosed Job Detail" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Voucherwise Job Details" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "FY End Back Dated Receipts" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "FY End Back Dated Payments" ||
                                ////dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "FY End Back Dated Petty Cash Receipts" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Set Off - On Account OS" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "ChangePassword" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Book Closure" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Set Off - &Adjustment" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Set Off Adjustment - Overseas" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Adjustment Ledgerwise" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Charge wise Reversal" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Customer Evaluation" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Set Off - On Account" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Deposit Details" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "GST Amendment" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma GST Amendment" ||
                                //(dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Business Plan" && Session["LoginBranchid"].ToString() == "66") ||
                                //(dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Master Customer" && Session["LoginBranchid"].ToString() == "66") ||
                                //       dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Bank Balances" ||
                                //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Cash Balances" ||
                                //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "CTC Accounts" ||
                                //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OVC Accounts" ||
                                //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Collections" ||
                                //    dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Payments" ||
                                //    dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding Adjustment" ||     //NewOne
                                //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Pending Journals"||
                                //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Inter Company DN/CN"||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "ContraBackDated" //||
                                //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "TDS Removal" ||
                                // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Vendorno Update"||
                                // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "FY End Back Dated Remittance-Receipt" ||
                                //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "FY End Back Dated Remittance-Payment" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "GST IRN Details"
                                || dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Set Off - &Adjustment" 
                                )
                            {
                                utility.Visible = true;
                                str_MenuDesign10.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                                str_MenuDesign10.Append("</li>");
                                divUtility.InnerHtml = str_MenuDesign10.ToString();

                            }
                        //    //if (Convert.ToInt32(Session["LoginEmpId"].ToString()) == 246 || Convert.ToInt32(Session["LoginEmpId"].ToString()) == 140 || Convert.ToInt32(Session["LoginEmpId"].ToString()) == 124)
                        //    //{

                        //    //    if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Merge LedgerName")
                        //    //    {
                        //    //        utility.Visible = true;
                        //    //        str_MenuDesign10.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                        //    //        str_MenuDesign10.Append("</li>");
                        //    //        divUtility.InnerHtml = str_MenuDesign10.ToString();
                        //    //    }
                        //    //}
                        }

                        //if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Audit Reports")
                        //{
                        //    if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "InternalBilling&Income" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "InternalBilling&Expense" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "ChargewiseBreakup")
                        //    {
                        //        AuditReports.Visible = true;
                        //        str_MenuDesign11.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                        //        str_MenuDesign11.Append("</li>");
                        //        divAuditReports.InnerHtml = str_MenuDesign11.ToString();
                        //    }
                        //}
                    }
                }
               
            }

            //string msg = "Please use a different browser to work simultaneously with multiple branches / companies in FA. Do not open FA in the another tab in the same browser to work for other branches / companies.";
            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('" + msg + "');", true);                        

        }

      

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("../Login.aspx");
        }

       




    }
}