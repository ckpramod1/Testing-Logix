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
    public partial class Main_Branch : System.Web.UI.Page
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
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
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
            string countryid = Session["countryid"].ToString();

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

                if (Session["StrTranType"].ToString() == "CA" || Session["StrTranType"].ToString() == "CO")
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
                                str_MenuDesign.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                                str_MenuDesign.Append("</li>");
                                div_accountinfo.InnerHtml = str_MenuDesign.ToString();
                            }
                        }

                        //if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Vouchers")
                        //{
                        //    if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Invoice" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Cr&edit Note - Operations" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Overseas &Debit Note" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Overseas &Credit Note" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OSSI" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OSPI" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Debit Note" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Credit Note" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Journal" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Con&tra" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Debit Note" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Credit Note" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma DN-Admin" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma CN-Admin" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Admin Sales Invoice" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Admin Purchase Invoice" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Che&que Request" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Receipts" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Payments" ||
                        //         dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Receipts_Tax" ||     //NewOne    //08/08/2022
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Payments_Tax" ||
                        //       // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Deposit &Slip" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Journa&l" ||
                        //        //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Man&ual Voucher" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Cheque Request Vouyearwise" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Invoice" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Profoma Credit Note - Operations" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Invoice" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Credit Note - Operations" ||

                                 //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Invoices After Job closing" ||
                                 // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Profoma Credit Note - Operations After Job closing" ||
                        //         dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Invoice After Job closing" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Credit Note - Operations After Job closing" ||

                                // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Debit Note-WH" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Credit Note-WH" ||
                        //            dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Debit Note-WH" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Credit Note-WH"
                        //        || dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OPBalance Breakup" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Bill of Supply"||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&ReceiptsNew"||

                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "R&emittance - Receipt" ||
                        //        dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Re&mittance - Payment" ||

                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma OS DN/CN After Job closed")
                        //    {
                        //        Vouchers.Visible = true;
                        //        str_MenuDesign1.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                        //        str_MenuDesign1.Append("</li>");
                        //        div_Vouchers.InnerHtml = str_MenuDesign1.ToString();
                        //    }
                        //}


                        //another start kalai
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Vouchers")
                        {
                            if (//dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Debit Note" ||
                               // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Credit Note" ||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Admin Vouchers" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma DN-Admin" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma CN-Admin" ||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Vouchers After Job Close" ||
                                   dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma OS Vouchers After Job Close" ||
                                  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Journa&l" )
                                //  ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "ChequeRequest" )  // Vino [22-10-2023])
                                // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Invoices After Job closing" ||
                                //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Profoma Purchase Invoice After Job closing" ||
                                // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Debit Note-WH" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Credit Note-WH" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma OS DN/CN After Job closed")
                            {
                                Vouchers.Visible = true;
                                if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() != "Admin Voucehers")
                                {
                                    str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                                }
                                else
                                {
                                    str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='#' title='Admin Vouchers'>Admin Vouchers &raquo;</a>");
                                    str_MenuDesign1.Append("<ul class='navigation-3'>");

                                    str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profoma DN-Admin.aspx?FormName=Proforma DN-Admin&uiid=1180' target='MainFrame' onclick ='ifrmaster'>Proforma DN-Admin</a>");
                                    str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profoma DN-Admin.aspx?FormName=Proforma CN-Admin&uiid=1181' target='MainFrame' onclick ='ifrmaster'>Proforma CN-Admin</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNO.aspx?FormName=Admin Sales Invoice&uiid=1182' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNO.aspx?FormName=Admin Purchase Invoice&uiid=1183' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Sales Invoice&uiid=10004' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Purchase Invoice&uiid=10005' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");

                                    str_MenuDesign1.Append("</ul>");
                                }

                                str_MenuDesign1.Append("</li>");
                                div_Vouchers.InnerHtml = str_MenuDesign1.ToString();
                            }

                            if (//dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Invoice" ||
                               dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Approved Vouchers" ||
                                    dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Approved OS Vouchers" ||
                               // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Cr&edit Note - Operations" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Overseas &Debit Note" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Overseas &Credit Note" ||
                              //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OSSI" ||
                              //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OSPI" ||
                              //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Debit Note" ||
                              //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Credit Note" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Journal" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Con&tra" ||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Approved Admin Vouchers" ||
                               // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Admin Sales Invoice" ||
                               // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Admin Purchase Invoice" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Payment Request" ||
                                (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Receipts" &&  (countryid == "1102" || countryid == "102")) ||
                                (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Payments" && (countryid == "1102" || countryid == "102")) ||
                                (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&ReceiptsNew" && (countryid != "1102" && countryid != "102")) ||
                                (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&PaymentsNew" && (countryid != "1102" && countryid != "102")) ||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Receipts_Tax" ||     //NewOne    //08/08/2022
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Payments_Tax" ||
                               // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Deposit &Slip" ||
                                         //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Man&ual Voucher" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Payment Request Vouyearwise" ||
                                        // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Invoice" ||
                              //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Purchase Invoice" ||
                                         //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Invoice After Job closing" ||
                             //   dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Purchase Invoice After Job closing" ||
                                             dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Debit Note-WH" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Credit Note-WH"
                                || dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OPBalance Breakup" ||
                              //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Bill of Supply"||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&ReceiptsNew"||

                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "R&emittance - Receipt" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Re&mittance - Payment" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&BRS" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Che&que Clearance")
                            {
                                Vouchers.Visible = true;
                                if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() != "Admin Voucehers")
                                {
                                    str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                                }
                                else
                                {
                                    str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='#' title='Admin Vouchers'>Admin Vouchers &raquo;</a>");
                                    str_MenuDesign12.Append("<ul class='navigation-3'>");

                                    //str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profoma DN-Admin.aspx?FormName=Proforma DN-Admin&uiid=1180' target='MainFrame' onclick ='ifrmaster'>Proforma DN-Admin</a>");
                                    //str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/profoma DN-Admin.aspx?FormName=Proforma CN-Admin&uiid=1181' target='MainFrame' onclick ='ifrmaster'>Proforma CN-Admin</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNO.aspx?FormName=Admin Sales Invoice&uiid=1182' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                                    //str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNO.aspx?FormName=Admin Purchase Invoice&uiid=1183' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");
                                    str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Sales Invoice&uiid=10004' target='MainFrame' onclick ='ifrmaster'>Admin Sales Invoice</a>");
                                    str_MenuDesign12.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/AdminDCNNONew.aspx?FormName=Admin Purchase Invoice&uiid=10005' target='MainFrame' onclick ='ifrmaster'>Admin Purchase Invoice</a>");

                                    str_MenuDesign12.Append("</ul>");
                                }

                                str_MenuDesign12.Append("</li>");
                                div_App.InnerHtml = str_MenuDesign12.ToString();
                            }
                        }

                        //end kalai










                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "A&pproval")
                        {
                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Payment Request &Approval" ||
                               //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "D&ebit Note Proforma to Commercialnew" ||
                               //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "C&redit Note Proforma to Commercialnew" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Voucher Approval After Job Close" ||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Admin to Commercial-Admin" ||
                               //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&CN Proforma to Commercial-Admin" ||
                               //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&DN Proforma to Commercial-Admin" ||
                               /*dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "ChequeRequestApproval" ||*/  // Vino [22-10-2023]
                               dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Journal Proforma to Commercial" )
                               //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Cheque Request Approval Vouyearwise" ||
                               //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Invoice Proforma to Commercial" ||
                               //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "CN-Ops Proforma to Commercial" ||
                               // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Invoice Proforma to Commercial After Job closing" ||
                               //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "PI Proforma to Commercial After Job closing" ||
                               // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OSDN Proforma to Commercial After Job closed" ||
                               // dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OSCN Proforma to Commercial After Job closed")

                            {
                                Approval.Visible = true;
                                str_MenuDesign2.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                                str_MenuDesign2.Append("</li>");
                                divApproval.InnerHtml = str_MenuDesign2.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Reports")
                        {
                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&DayBook" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Account Book" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Group Summary" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Statement of Accounts" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Trial Balance" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Profit and Loss Account" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Balance Sheet" ||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Ledger - PAN" ||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&GST Registers"
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Indirect &Expense Summary" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Fund Flow" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "IndirectExpense Ledgerwise" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "FCur Balance"||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "TurnOver"  
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
                                        str_MenuDesign3.Append("<li class='liststylenone'> <a class='drawer-dropdown-menu-item'>Account Book &raquo;</a>");
                                        str_MenuDesign3.Append("<ul class='navigation-3'>");

                                        str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/FALedgerView.aspx?FormName=Ledger&uiid=1782' target='MainFrame' onclick ='ifrmaster'>Ledger</a>");
                                        str_MenuDesign3.Append("<li class='liststylenone' style='border-bottom:0px solid #f00;'><a class='drawer-dropdown-menu-item' href='../FAForms/VoucherRegister.aspx?FormName=Registers&uiid=1783' target='MainFrame' onclick ='ifrmaster'>Registers</a>");
                                        //str_MenuDesign3.Append("<li class='liststylenone' style='border-bottom:0px solid #f00;'><a class='drawer-dropdown-menu-item' href='../FAForms/GSTRegisters.aspx?FormName=GST Registers&uiid=1900' target='MainFrame' onclick ='ifrmaster'>GST Registers</a>");
                                        str_MenuDesign3.Append("</ul>");
                                    }

                                    if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Statement of Accounts")
                                    {
                                        str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' title='Statement of Accounts'>Statement of Accounts &raquo;</a>");
                                        str_MenuDesign3.Append("<ul class='navigation-3'>");

                                        //str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/FACostCategory.aspx?FormName=Cost Category&uiid=1204' target='MainFrame' onclick ='ifrmaster'>Cost Category</a>");
                                        //str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/CostCenter.aspx?FormName=Cost Center&uiid=1204' target='MainFrame' onclick ='ifrmaster'>Cost Center</a>");
                                        ////str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/Statistics of Register.aspx?FormName=Statistics Register&uiid=1204' target='MainFrame' onclick ='ifrmaster'>Statistics Register</a>");
                                        str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/Statistics.aspx?FormName=Statistics&uiid=1204' target='MainFrame' onclick ='ifrmaster'>Statistics</a>");
                                        //str_MenuDesign3.Append("<li class='liststylenone' style='border-bottom:0px solid #f00;'><a class='drawer-dropdown-menu-item' href='../FAForms/ServiceTaxStatistics.aspx?FormName=TAX Report&uiid=1204' target='MainFrame' onclick ='ifrmaster'>TAX Report</a>");
                                        str_MenuDesign3.Append("</ul>");
                                    }
                                }
                                str_MenuDesign3.Append("</li>");
                                divReports.InnerHtml = str_MenuDesign3.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Outstanding &New")
                        {
                            //if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding - Schedule" || dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding - Online")
                            // {
                            //     OutstandingNew.Visible = true;
                            //     str_MenuDesign4.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                            //     str_MenuDesign4.Append("</li>");
                            //     divOutstanding.InnerHtml = str_MenuDesign4.ToString();                       
                            // }

                            //if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding - Schedule")
                            //{
                            //    OutstandingNew.Visible = true;
                            //    str_MenuDesign4.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/Outstanding_New.aspx?FormName=Outstanding - Schedule&uiid=1426' target='MainFrame' onclick ='ifrmaster'>Outstanding - Schedule</a>");
                            //    str_MenuDesign4.Append("</li>");
                            //    divOutstanding.InnerHtml = str_MenuDesign4.ToString();
                            //}

                            //if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding - Online")
                            //{
                            //    OutstandingNew.Visible = true;
                            //    str_MenuDesign4.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/Outstanding_Online.aspx?FormName=Outstanding - Online&uiid=1427' target='MainFrame' onclick='return ConfirmMsg();'>Outstanding - Online</a>");
                            //    str_MenuDesign4.Append("</li>");
                            //    divOutstanding.InnerHtml = str_MenuDesign4.ToString();
                            //}
                            ////if (Session["LoginEmpId"].ToString() == "124" || Session["loginEmpId"].ToString() == "246")
                            ////{
                            ////}
                            //if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding - OnlineNew")
                            //{
                            //    OutstandingNew.Visible = true;
                            //    str_MenuDesign4.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/Outstanding_Online_New.aspx?FormName=Outstanding - Online&uiid=1876' target='MainFrame' onclick='return ConfirmMsg();'>Outstanding</a>");
                            //    str_MenuDesign4.Append("</li>");
                            //    divOutstanding.InnerHtml = str_MenuDesign4.ToString();
                            //}

                            //if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding - OnlineNew")
                            //{
                            //    OutstandingNew.Visible = true;
                            //    str_MenuDesign4.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/Outstanding_Online_New.aspx?FormName=Outstanding - Online&uiid=1876' target='MainFrame' onclick='return ConfirmMsg();'>Outstanding - OnlineNew</a>");
                            //    str_MenuDesign4.Append("</li>");
                            //    divOutstanding.InnerHtml = str_MenuDesign4.ToString();
                            //}



                            if (Session["LoginEmpId"].ToString() == "1" || Session["loginEmpId"].ToString() == "2")
                            {
                                if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding - Schedule")
                                {
                                    OutstandingNew.Visible = true;
                                    str_MenuDesign4.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/Outstanding_New.aspx?FormName=Outstanding - Schedule&uiid=1426' target='MainFrame' onclick ='ifrmaster'>Outstanding - Schedule</a>");
                                    str_MenuDesign4.Append("</li>");
                                    divOutstanding.InnerHtml = str_MenuDesign4.ToString();
                                }

                                if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding - Online")
                                {
                                    OutstandingNew.Visible = true;
                                    str_MenuDesign4.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/Outstanding_Online.aspx?FormName=Outstanding - Online&uiid=1427' target='MainFrame' onclick='return ConfirmMsg();'>Outstanding - Online</a>");
                                    str_MenuDesign4.Append("</li>");
                                    divOutstanding.InnerHtml = str_MenuDesign4.ToString();
                                }
                            }

                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding - OnlineNew")
                            {
                                OutstandingNew.Visible = true;
                                str_MenuDesign4.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='../FAForms/Outstanding_Online_New.aspx?FormName=Outstanding - Online&uiid=1876' target='MainFrame'>Outstanding</a>");   //onclick='return ConfirmMsg();'
                                str_MenuDesign4.Append("</li>");
                                divOutstanding.InnerHtml = str_MenuDesign4.ToString();
                            }
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

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Query")
                        {
                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Query")
                            {
                                Query.Visible = true;
                                str_MenuDesign6.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                                str_MenuDesign6.Append("</li>");
                                divQuery.InnerHtml = str_MenuDesign6.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Utility")
                        {
                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Cheque &Bounce" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Set Off - On Account" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Set Off - &Adjustment" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Set Off Adjustment - Overseas" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Adjustment Ledgerwise" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Reversal" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Charge wise Reversal" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Service Tax Amount &Amendment" ||
                                  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "GST Amendment" ||

                                   dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma GST Amendment" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Customer &TDS" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Change &LedgerName" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Merge LedgerName" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "MIS Reconciliation" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Voucher Count - Ops Vs FA" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Collection > 60 Days" ||


                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&OnAccount To Against Journal" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Unclosed Job Detail" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Voucherwise Job Details" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "FY End Back Dated Receipts" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "FY End Back Dated Payments" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Customer Evaluation" ||
                                //dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding Adjustment" ||         //NewOne
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "ChangePassword"||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "ContraBackDated"||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "TDS Removal" ||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Vendorno Update" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "GST IRN Details" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Change Voucher Date"
                                )
                            {
                                utility.Visible = true;
                                str_MenuDesign7.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                                str_MenuDesign7.Append("</li>");
                                divUtility.InnerHtml = str_MenuDesign7.ToString();
                            }
                            if (Convert.ToInt32(Session["LoginEmpId"].ToString()) == 246 || Convert.ToInt32(Session["LoginEmpId"].ToString()) == 140 || Convert.ToInt32(Session["LoginEmpId"].ToString()) == 124)
                            {

                                if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&OnAccount To Against Journal" ||
                                    dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&Merge LedgerName")
                                {
                                    utility.Visible = true;
                                    str_MenuDesign7.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                                    str_MenuDesign7.Append("</li>");
                                    divUtility.InnerHtml = str_MenuDesign7.ToString();
                                }
                            }
                        }

                        string Trantype = "", Type = "";
                        //if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Shipment Details")
                        //{
                        //    if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Ocean &Exports" ||
                        //       dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Ocean &Imports" ||
                        //       dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Air Exports" ||
                        //       dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Air Imports")
                        //    {
                        //        if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Air Exports")
                        //        {
                        //            Trantype = "AE";
                        //            Type = "HAWBL";
                        //        }
                        //        else if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Air Imports")
                        //        {
                        //            Trantype = "AI";
                        //            Type = "HAWBL";
                        //        }
                        //        else if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Ocean &Exports")
                        //        {
                        //            Trantype = "FE";
                        //        }
                        //        else if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Ocean &Imports")
                        //        {
                        //            Trantype = "FI";
                        //        }
                        //        ShipmentDetails.Visible = true;
                        //        str_MenuDesign8.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + " &Trantype=" + Trantype.TrimEnd().TrimStart() + "" + "&Type=" + Type + "' target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                        //        str_MenuDesign8.Append("</li>");
                        //        divShipmentDetails.InnerHtml = str_MenuDesign8.ToString();
                        //    }
                        //}

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&FA Edi")
                        {
                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "&FA Edi" ||
                               dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "PI TDS" ||
                               dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Other CN TDS" ||
                               dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "PI - Admin TDS" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Tally XML")
                            {
                                FAEdi.Visible = true;
                                str_MenuDesign9.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?FormName=" + dt_MenuRights.Rows[i]["submenuname"].ToString().Replace("&", "") + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString().Replace("&", "") + "</a></li>");
                                str_MenuDesign9.Append("</li>");
                                divFA.InnerHtml = str_MenuDesign9.ToString();
                            }
                        }
                    }
                }
            }

            //string msg = "Please use a different browser to work simultaneously with multiple branches / companies in FA. Do not open FA in the another tab in the same browser to work for other branches / companies.";
            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alert('" + msg + "');", true);                        

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