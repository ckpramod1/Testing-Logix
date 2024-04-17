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
    public partial class HRMDocked : System.Web.UI.Page
    {
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.DashBoard.RightFrame rightObj = new DataAccess.DashBoard.RightFrame();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
        DataAccess.HR.FrontPage HRFrontObj = new DataAccess.HR.FrontPage();
        DataAccess.MIS MISObj = new DataAccess.MIS();
        DataTable dt = new DataTable();
        DataTable dthbl = new DataTable();
        DataTable dtmbl = new DataTable();
        DataTable dttemp = new DataTable();
        long lngPQuot, lngInv, lngPA, lngDN, lngCN;
        int branchid, vouyear, logempid;
        string ModuleName;
        string hname;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt_MenuRights = new DataTable();
                string str_ModuleName = Session["StrTranType"].ToString();
                DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                dt_MenuRights = obj_UP.GetMenus(Convert.ToInt16(Session["LoginEmpId"].ToString()), str_ModuleName, Convert.ToInt16(Session["LoginBranchid"].ToString()));
                Session["dt_UserRights"] = dt_MenuRights;
                string str_menuhead = "";
                StringBuilder str_MenuDesign = new StringBuilder();
                StringBuilder str_MenuDesign1 = new StringBuilder();
                StringBuilder str_MenuDesign2 = new StringBuilder();
                StringBuilder str_MenuDesign3 = new StringBuilder();

                StringBuilder str_MenuDesign4 = new StringBuilder();
                StringBuilder str_MenuDesign5 = new StringBuilder();
                StringBuilder str_MenuDesign6 = new StringBuilder();
                StringBuilder str_MenuDesign7 = new StringBuilder();

                if (dt_MenuRights.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                    {
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "H R M")
                        {
                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Employee" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Package" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Salary Package" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "C T C" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Confirmation" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Relieving" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Attendance" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Leave Balance" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Permissions" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "EL Encashed" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Claim Details" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Late Attendance" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Salary Revision" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Grade Details" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Excel Reader" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Appraisal")
                            {
                                setup.Visible = true;
                                str_MenuDesign.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item'  href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign.Append("</li>");

                                divsales.InnerHtml = str_MenuDesign.ToString();
                            }
                        }
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Payroll")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "LoP days" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Payroll" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Payslip" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Incentives" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "TDS - Update" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Letter to Bank" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Quarter")
                            {
                                links.Visible = true;
                                str_MenuDesign1.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign1.Append("</li>");

                                divcustomer.InnerHtml = str_MenuDesign1.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "IT - Workings")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Exemption" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Section" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Tax Slab" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Prof Tax Slab" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "LWF" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "LWF Grade" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Rent Exemption" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Other Income" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Investment Plan" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Investment Plan Prof Received" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Process - IT Computation" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "IT Computation" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Bonus Details")
                            {
                                files.Visible = true;
                                str_MenuDesign2.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign2.Append("</li>");

                                div3.InnerHtml = str_MenuDesign2.ToString();
                            }
                        }


                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Reports")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Statutory" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Accounts" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "All Plan Proof" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "PaySlip" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Appraisee Training Report")
                            {
                                Accounts.Visible = true;
                                str_MenuDesign3.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item'  href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign3.Append("</li>");

                                DivAccounts.InnerHtml = str_MenuDesign3.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "M I S")
                        {
                            MIS.Visible = true;
                            str_MenuDesign6.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item'  href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                            str_MenuDesign6.Append("</li>");

                            DivMIS.InnerHtml = str_MenuDesign6.ToString();

                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Utility")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "News" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "News Status" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Master Question" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Company Profile" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Employee Benefits" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Others" ||                                
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "ChangePassword")
                            {
                                Utility.Visible = true;
                                str_MenuDesign7.Append("<li class='liststylenone'><a class='drawer-dropdown-menu-item'  href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign7.Append("</li>");

                                Divutility.InnerHtml = str_MenuDesign7.ToString();
                            }
                        }
                    }
                }
            }

            /*   if(!IsPostBack)
               {
                   BindDivision();
                   BindDivision1();
                   loadDivisionConPro();
                   Griddivconpro.Visible = true;
                   Paneldiv.Visible = true;


                   loadBirthDay();
                   grdbdaylist.Visible = true;
                   Panelbdaylist.Visible = true;
               }

               GrdDisable1();
               string Strtrantype = Session["StrTranType"].ToString();
               if (Strtrantype == "HRM")
               {
             
                   Paneljobcostingframe.Visible = false;

               }
               else
               {


               }
               if (IsPostBack)
               {
                   if (Session["Loggedname"] != null)
                   {
                       hname = Session["Loggedname"].ToString();

                       if (hname == "userlog")
                       {
                           ifrmaster.Attributes["src"] = "../ForwardExports/Emptyform.aspx";
                           Session["Loggedname"] = null;
                       }
                   }
               }
           }
               */
            /*    protected void lnk_PendingBooking_Click(object sender, EventArgs e)
                {
                    GrdDisable1();
           
                }

      
                public void GrdDisable1()
                {
                    // Grid View //



                    // Panels //
                    Panelcnfpro.Visible = false;
                    Paneljobcostingframe.Visible = false;
                    Griddivconpro.Visible = true;
                    Paneldiv.Visible = true;
                    Panelbdaylist.Visible = true;
          


                    if (IsPostBack)
                    {
                        if (Session["Loggedname"] != null)
                        {
                            hname = Session["Loggedname"].ToString();

                            if (hname == "userlog")
                            {
                                ifrmaster.Attributes["src"] = "../ForwardExports/Emptyform.aspx";
                                Session["Loggedname"] = null;
                            }
                        }
                    }

                }

       
                protected void lnk_curr_Click(object sender, EventArgs e)
                {
                    ifrmaster.Attributes["src"] = "../ForwardExports/CountryCurrency.aspx";
                }

                protected void lnl_inco_Click(object sender, EventArgs e)
                {
                    ifrmaster.Attributes["src"] = "../ForwardExports/IncoTerm.aspx";
                }

                protected void lnk_length_Click(object sender, EventArgs e)
                {
                    ifrmaster.Attributes["src"] = "../ForwardExports/LengthConversion.aspx";
                }

                protected void lnk_weight_Click(object sender, EventArgs e)
                {
                    ifrmaster.Attributes["src"] = "../ForwardExports/WeightConversion.aspx";
                }

                protected void lnk_volume_Click(object sender, EventArgs e)
                {
                    ifrmaster.Attributes["src"] = "../ForwardExports/VolumeConversion.aspx";
                }

      
       

                protected void lnk_PendingBooking_Click1(object sender, EventArgs e)
                {
                    ifrmaster.Attributes["src"] = "../HRM/EmpConfirm.aspx";
                }

                public void BindDivision()
                {


                    DataTable obj_dtTemp = new DataTable();
                    obj_dtTemp = hrempobj.GetDivisionhrm("M");           
                    for (int i = 0; i <= obj_dtTemp.Rows.Count -1; i++)
                    {
                        ddl_product.Items.Add(obj_dtTemp.Rows[i]["divisionname"].ToString());
                    }

                }

                public void BindDivision1()
                {


                    DataTable obj_dtTemp = new DataTable();
                    obj_dtTemp = hrempobj.GetDivisionhrm("M");
                    for (int i = 0; i <= obj_dtTemp.Rows.Count - 1; i++)
                    {
                        ddl_division.Items.Add(obj_dtTemp.Rows[i]["divisionname"].ToString());
                    }

                }

                protected void ddl_product_TextChanged(object sender, EventArgs e)
                {
                    Paneljobcostingframe.Visible = true;
                    Griddiv.Visible = true;
                    Panelemplist.Visible = true;
                    lbl1.Enabled = true;

                    ddl_product.Visible = true;
                    string a;
                    string empid = "0"; ;
                    int Confirmation = 0 ;
                    int temporary=0;
                    dt = HRFrontObj.GetPortName(ddl_product.Text);
                    DataTable dtnew = new DataTable();
                    dtnew.Columns.Add("Division");
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        a = dt.Rows[i][0].ToString();
                        Confirmation = HRFrontObj.GetNoofConfirmEmp(ddl_product.Text, a);
                        temporary = HRFrontObj.GetNoofTemporaryEmp(ddl_product.Text, a);
                        dtnew.Rows.Add();
                        dtnew.Rows[i]["Division"] = (a + " ( " + Confirmation + " / " + temporary + " ) ").Trim();
                    }
                    Griddiv.DataSource = dtnew;
                    Griddiv.DataBind();
                }

                protected void lnk_emplist_Click(object sender, EventArgs e)
                {
                    GrdDisable1();
                    Paneljobcostingframe.Visible = true;
                    Griddiv.Visible = true;
                    Panelemplist.Visible = true;
                    lbl1.Enabled = true;
         
                    ddl_product.Visible = true;

                }

                protected void Griddiv_RowDataBound(object sender, GridViewRowEventArgs e)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Griddiv, "Select$" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";
                    }
                }

                protected void Griddiv_SelectedIndexChanged(object sender, EventArgs e)
                {
                    int index;
                    string name;
                    string Strtrantype = Session["StrTranType"].ToString();
                    string str_sp = "";
                    string str_sf = "";
                    string str_RptName = "";
                    string str_Script = "";
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    branchid = int.Parse(Session["LoginBranchid"].ToString());
                    logempid = int.Parse(Session["LoginEmpId"].ToString());
                    int intdivision;
                    int intbranch;
           
                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                    if (Griddiv.Rows.Count > 0 && ddl_product.Text != "")
                    {
                        index = Griddiv.SelectedRow.RowIndex;
                        name = Griddiv.Rows[index].Cells[0].Text;
                        intdivision = hrempobj.GetDivisionId(ddl_product.Text);
                        intbranch = hrempobj.GetBranchId((name.Substring(0, name.LastIndexOf(" ( "))).Trim());
                        str_RptName = "HREmpDetails.rpt";
                        str_sf = "{MasterEmployee.rol}=0 and {MasterEmployee.division }=" + intdivision + " and {MasterEmployee.branch} =" + intbranch;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Griddiv, typeof(GridView), "employeelist", str_Script, true);               
               
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                    }
                }
                public void  loadDivisionConPro()
                {
                    int sumcon = 0;
                    int sumpro = 0;
                   // dt = hrempobj.GetDivision("M");
                    dt = hrempobj.GetDivisionhrm("M");
                    DataTable dtnew = new DataTable();
                    dtnew.Columns.Add("Division");
                    dtnew.Columns.Add("Confirm");
                    dtnew.Columns.Add("Probation");
         
                    if(dt.Rows.Count > 0)
                    {
                        for (int i=0;i<dt.Rows.Count;i++)
                        {
                            dtnew.Rows.Add();
                            //Griddivconpro.Rows[i].Cells[0].Text = dt.Rows[i]["Probation"].ToString();

                            //Griddivconpro.Rows[i].Cells[1].Text = Convert.ToString(HRFrontObj.GetDivisionNoofTemporaryEmp(dt.Rows[i]["Division"].ToString()));
                            //Griddivconpro.Rows[i].Cells[2].Text = Convert.ToString(HRFrontObj.GetDivisionNoofTemporaryEmp(dt.Rows[i]["Division"].ToString()));

                            //sumcon = sumcon + HRFrontObj.GetDivisionNoofConfirmEmp(dt.Rows[i]["Division"].ToString());
                            //sumpro = sumpro + HRFrontObj.GetDivisionNoofTemporaryEmp(dt.Rows[i]["Division"].ToString());

                            dtnew.Rows[i]["Division"] = dt.Rows[i]["divsname"].ToString();
                            dtnew.Rows[i]["Confirm"] = Convert.ToString(HRFrontObj.GetDivisionNoofConfirmEmp(dt.Rows[i]["divisionname"].ToString()));
                            dtnew.Rows[i]["Probation"] = Convert.ToString(HRFrontObj.GetDivisionNoofTemporaryEmp(dt.Rows[i]["divisionname"].ToString()));
                            sumcon = sumcon + HRFrontObj.GetDivisionNoofConfirmEmp(dt.Rows[i]["divisionname"].ToString());
                            sumpro = sumpro + HRFrontObj.GetDivisionNoofTemporaryEmp(dt.Rows[i]["divisionname"].ToString());
                        }
                     //   dtnew.Rows.Add(dt);
                        dtnew.Rows.Add();

                        dtnew.Rows[dtnew.Rows.Count - 1][0] = "Total";
                        dtnew.Rows[dtnew.Rows.Count - 1][1] = Convert.ToString(sumcon);
                        dtnew.Rows[dtnew.Rows.Count - 1][2] = Convert.ToString(sumpro);
                    }
                    Griddivconpro.DataSource = dtnew;
                    Griddivconpro.DataBind();

           
            
                    if (Griddivconpro.Rows.Count > 0)
                    {

                        Griddivconpro.Rows[Griddivconpro.Rows.Count - 1].Cells[0].ForeColor = System.Drawing.Color.Blue;
                        Griddivconpro.Rows[Griddivconpro.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.Crimson;
                        Griddivconpro.Rows[Griddivconpro.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.Crimson;
                    }
                    else
                    {
                        Griddivconpro.DataSource = new DataTable();
                        Griddivconpro.DataBind();
                    }

                }

                protected void lnk_cnfpro_Click(object sender, EventArgs e)
                {
                    GrdDisable1();
                    Panelcnfpro.Visible = true;
                    Griddiv1.Visible = true;
                    Panelcnfpro1.Visible = true;
                    Label1.Enabled = true;

                    ddl_division.Visible = true;
                }

                protected void ddl_division_TextChanged(object sender, EventArgs e)
                {
                    Panelcnfpro.Visible = true;
                    Griddiv1.Visible = true;
                    Panelcnfpro1.Visible = true;
                    Label1.Enabled = true;

                    ddl_division.Visible = true;
                    string a;
                    string empid = "0"; ;
                    int Confirmation = 0;
                    int temporary = 0;
                    dt = HRFrontObj.GetPortName(ddl_division.Text);
                    DataTable dtnew = new DataTable();
                    dtnew.Columns.Add("Division");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        a = dt.Rows[i][0].ToString();
                        Confirmation = HRFrontObj.GetNoofConfirmEmp(ddl_division.Text, a);
                        temporary = HRFrontObj.GetNoofTemporaryEmp(ddl_division.Text, a);
                        dtnew.Rows.Add();
                        dtnew.Rows[i]["Division"] = (a + " ( " + Confirmation + " / " + temporary + " ) ").Trim();
                    }
                    Griddiv1.DataSource = dtnew;
                    Griddiv1.DataBind();
                }
               

       
                protected void btn_yes_Click(object sender, EventArgs e)
                {
                    try
                    {
                        int index;
                        string name;
                        string Strtrantype = Session["StrTranType"].ToString();
                        string str_sp = "";
                        string str_sf = "";
                        string str_RptName = "";
                        string str_Script = "";
                        Session["str_sfs"] = "";
                        Session["str_sp"] = "";
                        branchid = int.Parse(Session["LoginBranchid"].ToString());
                        logempid = int.Parse(Session["LoginEmpId"].ToString());
                        int intdivision;
                        int intbranch;
                        if (Griddiv1.Rows.Count > 0 && ddl_product.Text != "")
                        {
                            index = Griddiv1.SelectedRow.RowIndex;
                            name = Griddiv1.Rows[index].Cells[0].Text;
                            intdivision = hrempobj.GetDivisionId(ddl_product.Text);
                            intbranch = hrempobj.GetBranchId((name.Substring(0, name.LastIndexOf(" ( "))).Trim());
                            str_RptName = "HREmpDetails.rpt";
                            str_sf = "{MasterEmployee.rol}=0 and not isnull({MasterEmployee.doc}) and {MasterEmployee.division }=" + intdivision + " and {MasterEmployee.branch}=" + intbranch;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(Griddiv1, typeof(GridView), "employeelist", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message.ToString();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                    }
                }
                protected void btn_no_Click(object sender, EventArgs e)
                {
                    try
                    {
                        int index;
                        string name;
                        string Strtrantype = Session["StrTranType"].ToString();
                        string str_sp = "";
                        string str_sf = "";
                        string str_RptName = "";
                        string str_Script = "";
                        Session["str_sfs"] = "";
                        Session["str_sp"] = "";
                        branchid = int.Parse(Session["LoginBranchid"].ToString());
                        logempid = int.Parse(Session["LoginEmpId"].ToString());
                        int intdivision;
                        int intbranch;
                        if (Griddiv1.Rows.Count > 0 && ddl_product.Text != "")
                        {
                            index = Griddiv1.SelectedRow.RowIndex;
                            name = Griddiv1.Rows[index].Cells[0].Text;
                            intdivision = hrempobj.GetDivisionId(ddl_product.Text);
                            intbranch = hrempobj.GetBranchId((name.Substring(0, name.LastIndexOf(" ( "))).Trim());
                            str_RptName = "HREmpDetails.rpt";
                            str_sf = "{MasterEmployee.rol}=0 and isnull({MasterEmployee.doc}) and {MasterEmployee.division }=" + intdivision + " and {MasterEmployee.branch}=" + intbranch;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(Griddiv1, typeof(GridView), "employeelist", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message.ToString();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                    }
                }

                protected void Griddiv1_RowDataBound(object sender, GridViewRowEventArgs e)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Griddiv1, "Select$" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";
                    }
                }

                protected void Griddiv1_SelectedIndexChanged(object sender, EventArgs e)
                {
                    //int index;
                    //string name;
                    //string Strtrantype = Session["StrTranType"].ToString();
                    //string str_sp = "";
                    //string str_sf = "";
                    //string str_RptName = "";
                    //string str_Script = "";
                    //Session["str_sfs"] = "";
                    //Session["str_sp"] = "";
                    //branchid = int.Parse(Session["LoginBranchid"].ToString());
                    //logempid = int.Parse(Session["LoginEmpId"].ToString());
                    //int intdivision;
                    //int intbranch;

                    //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                    //if (Griddiv1.Rows.Count > 0 && ddl_product.Text != "")
                    //{
                    //    index = Griddiv1.SelectedRow.RowIndex;
                    //    name = Griddiv1.Rows[index].Cells[0].Text;
                    //    intdivision = hrempobj.GetDivisionId(ddl_product.Text);
                    //    intbranch = hrempobj.GetBranchId((name.Substring(0, name.LastIndexOf(" ( "))).Trim());
                    this.PopUpService.Show();


                    //}
                    //else
                    //{

                    //}
                }

                protected void lnk_bdaylist_Click(object sender, EventArgs e)
                {
                    GrdDisable1();
                    loadBirthDay();
                    grdbdaylist.Visible = true;
                    Panelbdaylist.Visible = true;
                }
                public void loadBirthDay()
                {
                    dt = HRFrontObj.GetCurrMonthBirth();
                    DataTable dtnew = new DataTable();
                    dtnew.Columns.Add("empname");
                    if (dt.Rows.Count > 0)
                    {
                        for(int i=0;i<dt.Rows.Count;i++)
                        {
                            dtnew.Rows.Add();
                            dtnew.Rows[i]["empname"] = (dt.Rows[i][2].ToString() + " - " + dt.Rows[i][0].ToString()).Trim();
                        }
                        grdbdaylist.DataSource = dtnew;
                        grdbdaylist.DataBind();
                    }
                }

                protected void grdbdaylist_RowDataBound(object sender, GridViewRowEventArgs e)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        Label lblempname = (Label)e.Row.FindControl("empname");
                        string tooltip = lblempname.Text;
                        e.Row.Cells[0].Attributes.Add("title", tooltip);
                
                        //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                        //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                       // e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdbdaylist, "Select$" + e.Row.RowIndex);
                       // e.Row.Attributes["style"] = "cursor:pointer";
                    }
                }*/
        }
    }
}