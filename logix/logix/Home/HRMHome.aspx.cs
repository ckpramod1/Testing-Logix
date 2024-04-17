using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Globalization;
using System.Drawing;
namespace logix.Home
{
    public partial class HRMHome : System.Web.UI.Page
    {
        DataTable DTConf = new DataTable();
        DataAccess.HR.FrontPage HRFrontObj = new DataAccess.HR.FrontPage();
        DataTable dt = new DataTable();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.DashBoard.RightFrame rightObj = new DataAccess.DashBoard.RightFrame();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
       
        DataAccess.MIS MISObj = new DataAccess.MIS();
      
        DataTable dthbl = new DataTable();
        DataTable dtmbl = new DataTable();
        DataTable dttemp = new DataTable();
        long lngPQuot, lngInv, lngPA, lngDN, lngCN;
        int branchid, vouyear, logempid;
        string ModuleName;
        string hname;
        protected void Page_Load(object sender, EventArgs e)
        {
            //GrdDisable1();

            if (!IsPostBack)
            {
                DTConf = HRFrontObj.GetCurrMonthConfirm();
                DataTable dtnew = new DataTable();
                dtnew.Columns.Add("EMPNAME");
                dtnew.Columns.Add("(Confirm)");
                dtnew.Columns.Add("Company");
                dtnew.Columns.Add("Branch");
               
                for (int i = 0; i < DTConf.Rows.Count; i++)
                {
                    dtnew.Rows.Add();
                    dtnew.Rows[i]["EMPNAME"] = DTConf.Rows[i][0].ToString().Trim();
                    dtnew.Rows[i]["Company"] = DTConf.Rows[i][2].ToString().Trim();
                    if (DTConf.Rows[i][3].ToString()=="CHENNAI")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim()+"-CHE";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "BANGALORE")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-BLR";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "CALCUTTA")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-KOL";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "AHMEDABAD")       
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-AHD";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "COCHIN")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-COC";
                    }

                    else if (DTConf.Rows[i][3].ToString() == "COIMBATORE")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-CBE";
                    }

                    else if (DTConf.Rows[i][3].ToString() == "CORPORATE")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-CO";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "HYDERABAD")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-HYD";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "KARUR")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-KRR";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "LUDHIANA")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-LUD";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "MUMBAI")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-MUM";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "NEW DELHI")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-DEL";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "PUNE")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-PUN";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "TIRUPUR")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-TPR";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "TRIVANDRUM")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-TVM";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "TUTICORIN")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-TUT";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "VISHAKHAPATNAM")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-VIS";
                    }
                   // dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim();
                    DateTime dtime = Convert.ToDateTime(DTConf.Rows[i][4].ToString());

                    DateTime dtimenew = Convert.ToDateTime(dtime.AddMonths(6).ToString());

                    dtnew.Rows[i]["(Confirm)"] = Utility.fn_ConvertDate(dtimenew.ToString());

                }

                grd.DataSource = dtnew;
                grd.DataBind();
                BindDivision();
                BindDivision1();
                loadDivisionConPro();
                Griddivconpro.Visible = true;
                Paneldiv.Visible = true;


                loadBirthDay();
                grdbdaylist.Visible = true;
                Panelbdaylist.Visible = true;

              //  GrdDisable1();
                Paneljobcostingframe.Visible = true;
                Griddiv.Visible = true;
                Panelemplist.Visible = true;
                lbl1.Enabled = true;

                ddl_product.Visible = true;

                Panelcnfpro.Visible = true;
                Griddiv1.Visible = true;
                Panelcnfpro1.Visible = true;
                Label1.Enabled = true;

                ddl_division.Visible = true;

            }
            GrdDisable1();
            
           

        }
        public void BindDivision()
        {


            DataTable obj_dtTemp = new DataTable();
            obj_dtTemp = hrempobj.GetDivisionhrm("HR");
            for (int i = 0; i <= obj_dtTemp.Rows.Count - 1; i++)
            {
                ddl_product.Items.Add(obj_dtTemp.Rows[i]["divisionname"].ToString());
            }

        }
        public void BindDivision1()
        {


            DataTable obj_dtTemp = new DataTable();
            obj_dtTemp = hrempobj.GetDivisionhrm("HR");
            for (int i = 0; i <= obj_dtTemp.Rows.Count - 1; i++)
            {
                ddl_division.Items.Add(obj_dtTemp.Rows[i]["divisionname"].ToString());
            }

        }

        public void GrdDisable1()
        {
            // Grid View //



            // Panels //
         
          
            Griddivconpro.Visible = true;
            Paneldiv.Visible = true;
            Panelbdaylist.Visible = true;



           

        }
        //protected void lnk_emplist_Click(object sender, EventArgs e)
        //{
        //    //GrdDisable1();
        //    //Paneljobcostingframe.Visible = true;
        //    //Griddiv.Visible = true;
        //    //Panelemplist.Visible = true;
        //    //lbl1.Enabled = true;

        //    //ddl_product.Visible = true;

        //}
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
        public void loadDivisionConPro()
        {
            int sumcon = 0;
            int sumpro = 0;
            // dt = hrempobj.GetDivision("M");
            dt = hrempobj.GetDivisionhrm("HR");
            DataTable dtnew = new DataTable();
            dtnew.Columns.Add("Division");
            dtnew.Columns.Add("Confirm");
            dtnew.Columns.Add("Probation");

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
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

                    if (i == 0)
                    {
                        hidConfirm.Text = Convert.ToString(HRFrontObj.GetDivisionNoofConfirmEmp(dt.Rows[i]["divisionname"].ToString()));
                        hidProbation.Text = Convert.ToString(HRFrontObj.GetDivisionNoofTemporaryEmp(dt.Rows[i]["divisionname"].ToString()));
                    }
                    else if (i == 1)
                    {
                        hidConfirm1.Text = Convert.ToString(HRFrontObj.GetDivisionNoofConfirmEmp(dt.Rows[i]["divisionname"].ToString()));
                        hidProbation1.Text = Convert.ToString(HRFrontObj.GetDivisionNoofTemporaryEmp(dt.Rows[i]["divisionname"].ToString()));
                    }
                    else if (i == 2)
                    {
                        hidConfirm2.Text = Convert.ToString(HRFrontObj.GetDivisionNoofConfirmEmp(dt.Rows[i]["divisionname"].ToString()));
                        hidProbation2.Text = Convert.ToString(HRFrontObj.GetDivisionNoofTemporaryEmp(dt.Rows[i]["divisionname"].ToString()));
                    }

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
        protected void grdbdaylist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label lblempname1 = (Label)e.Row.FindControl("ename");
            //    string tooltip = lblempname1.Text;
            //    e.Row.Cells[0].Attributes.Add("title", tooltip);

              
            //}
       }
        //protected void lnk_bdaylist_Click(object sender, EventArgs e)
        //{
        //    GrdDisable1();
        //    loadBirthDay();
        //    grdbdaylist.Visible = true;
        //    Panelbdaylist.Visible = true;
        //}



        //public void loadBirthDay()        {
            
        //    bool bdate;
        //    dt = HRFrontObj.GetCurrMonthBirthdayNew();
        //    DataTable dtnew = new DataTable();
        //    dtnew.Columns.Add("branch");
        //    dtnew.Columns.Add("empname");
        //    dtnew.Columns.Add("birthdate");
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            dtnew.Rows.Add();
        //            dtnew.Rows[i]["branch"].ToString();
        //            dtnew.Rows[i]["empname"].ToString();
                
                   

        //        }
        //        grdbdaylist.DataSource = dtnew;
        //        grdbdaylist.DataBind();
        //    }
        //}


        public void loadBirthDay()
        {
            DataTable dt = new DataTable();                     
            dt = HRFrontObj.GetCurrMonthBirthdayNew();
           
           
                grdbdaylist.DataSource = dt;
                grdbdaylist.DataBind();
          
        }


        //protected void lnk_cnfpro_Click(object sender, EventArgs e)
        //{
        //    //GrdDisable1();
        //    //Panelcnfpro.Visible = true;
        //    //Griddiv1.Visible = true;
        //    //Panelcnfpro1.Visible = true;
        //    //Label1.Enabled = true;

        //    //ddl_division.Visible = true;
        //}

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

        protected void ddl_product_TextChanged(object sender, EventArgs e)
        {
            Paneljobcostingframe.Visible = true;
            Griddiv.Visible = true;
            Panelemplist.Visible = true;
            lbl1.Enabled = true;

            ddl_product.Visible = true;
            string a;
            string empid = "0"; ;
            int Confirmation = 0;
            int temporary = 0;
            dt = HRFrontObj.GetPortName(ddl_product.Text);
            DataTable dtnew = new DataTable();
            dtnew.Columns.Add("Division");
            for (int i = 0; i < dt.Rows.Count; i++)
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


        protected void Griddiv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            this.PopUpService.Show();


        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
     
    }
}