using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.CRMNew
{
    public partial class BudgetSales : System.Web.UI.Page
    {
        DataAccess.Accounts.Budget budobj = new DataAccess.Accounts.Budget();
       //static double amt = 0.0;
        //static Double dlbillamt, dlactbill;
        
       static Double budgetvolume, actaulbillinv;
       static Double actaulbillDN, actaulbillOSDN;
       static string strtrantype, strjobtype;
       static string strvoltype, strsubprod;
        string custype, strvolt;
       static  int intjobtype;
        DataTable dtsales, Dtbranch = new DataTable();
        DataTable obj_dtTemp, obj_Dt;
        static int branchid;
        static int strmonth, stryear;
        static string month;
        static double actvolsal, actrent, dlactvol;
        DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterBranch da_obj_Branch = new DataAccess.Masters.MasterBranch();
        DataTable dtsalamt = new DataTable();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        string volval;
        string rbudgetval;
        static int intmonth;
        static int intyear, bid, empid;
        DataTable dtactualbillinv = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            } 

            DataTable Dtbranch = new DataTable();
            if (!IsPostBack)
            {
                DataTable dTab = new DataTable();
                grdsales.DataSource = dTab;
                grdsales.DataBind();
                empid = Convert.ToInt32(Session["LoginEmpId"]);
                txtSales.Text = Session["LoginEmpName"].ToString();
                txtcompany.Text = Session["LoginDivisionName"].ToString();


                ddllocation.SelectedItem .Text   = Session["LoginBranchName"].ToString();
                bid = Convert.ToInt32(Session["LoginBranchid"]);
                txtcompany.ReadOnly = true;
                ddllocation.Enabled = false;
                grdsales.Attributes.Add("onkeydown", "if(event.keyCode==13)return false;");
                ddlyear.Items.Clear();
                ddlyear.Items.Add("Year");
                for (int i = Logobj.GetDate().Year; i <= Logobj.GetDate().Year + 2; i++)
                {
                    ddlyear.Items.Add(i.ToString());
                }

            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            if (ddlmonth.SelectedItem.Text != "Month")
            {
                if (ddlyear.SelectedItem.Text != "Year")
                {

                    Session["ddlmonth"] = Convert.ToInt32(ddlmonth.SelectedValue);
                    Session["Month"] = ddlmonth.SelectedItem;
                    Session["Year"] = Convert.ToInt32(ddlyear.SelectedItem.ToString());
                    strmonth = Convert.ToInt32(ddlmonth .SelectedValue );
                    stryear = Convert.ToInt32(ddlyear .SelectedValue );
                    month = Session["Month"].ToString();

                    branchid = da_obj_HrEmp.GetBranchId(Convert.ToInt16(Session["LoginDivisionId"].ToString()), ddllocation.SelectedItem.Text.ToString());
                    Session["budgetbranch"] = branchid;
                    DataTable dtempty = new DataTable();

                    dtempty.Columns.Add("product");
                    dtempty.Columns.Add("unit");
                    dtempty.Columns.Add("unittype");
                    dtempty.Columns.Add("vactual");
                    dtempty.Columns.Add("rbudget");
                    dtempty.Columns.Add("ractual");
                    dtempty.Columns.Add("volume");
                    dtempty.Columns.Add("trantype");
                    dtempty.Columns.Add("jobtype");
                    dtempty.Columns.Add("bid");
                    dtempty.Columns.Add("subprod");

                    DataRow dr = dtempty.NewRow();
                    dr["product"] = "Ocean Exports - FCL";
                    dr["unit"] = "";
                    dr["unittype"] = "Teus";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "Teus";
                    dr["volume"] = "";
                    dr["trantype"] = "FE";
                    dr["jobtype"] = "FCL";
                    dr["bid"] = branchid;
                    dr["subprod"] = "FE";
                    dtempty.Rows.Add(dr);

                    dr = dtempty.NewRow();
                    dr["product"] = "Ocean Exports - MCC";
                    dr["unit"] = "";
                    dr["unittype"] = "Teus";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "Teus";
                    dr["volume"] = "";
                    dr["trantype"] = "FE";
                    dr["jobtype"] = "MCC";
                    dr["bid"] = branchid;
                    dr["subprod"] = "FE";
                    dtempty.Rows.Add(dr);

                    dr = dtempty.NewRow();
                    dr["product"] = "Ocean Exports - CONSOL";
                    dr["unit"] = "";
                    dr["unittype"] = "Teus";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "Teus";
                    dr["volume"] = "";
                    dr["trantype"] = "FE";
                    dr["jobtype"] = "CONSOL";
                    dr["bid"] = branchid;
                    dr["subprod"] = "FE";
                    dtempty.Rows.Add(dr);

                    dr = dtempty.NewRow();
                    dr["product"] = "Ocean Exports - LCL";
                    dr["unit"] = "";
                    dr["unittype"] = "CBM";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "CBM";
                    dr["volume"] = "";
                    dr["trantype"] = "FE";
                    dr["jobtype"] = "LCL";
                    dr["bid"] = branchid;
                    dr["subprod"] = "FE";
                    dtempty.Rows.Add(dr);

                    dr = dtempty.NewRow();
                    dr["product"] = "Ocean Exports - BCC";
                    dr["unit"] = "";
                    dr["unittype"] = "CBM";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "CBM";
                    dr["volume"] = "";
                    dr["trantype"] = "FE";
                    dr["jobtype"] = "BCC";
                    dr["bid"] = branchid;
                    dr["subprod"] = "FE";
                    dtempty.Rows.Add(dr);

                    dr = dtempty.NewRow();
                    dr["product"] = "Ocean Exports - CHA Activity";
                    dr["unit"] = "";
                    dr["unittype"] = "Shpts";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "Shpts";
                    dr["volume"] = "";
                    dr["trantype"] = "CH";
                    dr["jobtype"] = "CH";
                    dr["bid"] = branchid;
                    dr["subprod"] = "SE";
                    dtempty.Rows.Add(dr);

                    dr = dtempty.NewRow();
                    dr["product"] = "Air Exports";
                    dr["unit"] = "";
                    dr["unittype"] = "Tonnage";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "Tonnage";
                    dr["volume"] = "";
                    dr["trantype"] = "AE";
                    dr["jobtype"] = "AE";
                    dr["bid"] = branchid;
                    dr["subprod"] = "AE";
                    dtempty.Rows.Add(dr);

                    dr = dtempty.NewRow();
                    dr["product"] = "Air Exports - CHA Activity";
                    dr["unit"] = "";
                    dr["unittype"] = "Shpts";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "Shpts";
                    dr["volume"] = "";
                    dr["trantype"] = "CH";
                    dr["jobtype"] = "CH";
                    dr["bid"] = branchid;
                    dr["subprod"] = "AE";
                    dtempty.Rows.Add(dr);

                    dr = dtempty.NewRow();
                    dr["product"] = "Ocean Imports - FCL";
                    dr["unit"] = "";
                    dr["unittype"] = "Teus";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "Teus";
                    dr["volume"] = "";
                    dr["trantype"] = "FI";
                    dr["jobtype"] = "FCL";
                    dr["bid"] = branchid;
                    dr["subprod"] = "FI";
                    dtempty.Rows.Add(dr);

                    dr = dtempty.NewRow();
                    dr["product"] = "Ocean Imports - MCC";
                    dr["unit"] = "";
                    dr["unittype"] = "Teus";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "Teus";
                    dr["volume"] = "";
                    dr["trantype"] = "FI";
                    dr["jobtype"] = "MCC";
                    dr["bid"] = branchid;
                    dr["subprod"] = "FI";
                    dtempty.Rows.Add(dr);

                    dr = dtempty.NewRow();
                    dr["product"] = "Ocean Imports - CONSOL";
                    dr["unit"] = "";
                    dr["unittype"] = "Teus";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "Teus";
                    dr["volume"] = "";
                    dr["trantype"] = "FI";
                    dr["jobtype"] = "CONSOL";
                    dr["bid"] = branchid;
                    dr["subprod"] = "FI";
                    dtempty.Rows.Add(dr);

                    dr = dtempty.NewRow();
                    dr["product"] = "Ocean Imports - LCL";
                    dr["unit"] = "";
                    dr["unittype"] = "CBM";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "CBM";
                    dr["volume"] = "";
                    dr["trantype"] = "FI";
                    dr["jobtype"] = "LCL";
                    dr["bid"] = branchid;
                    dr["subprod"] = "FI";
                    dtempty.Rows.Add(dr);

                    dr = dtempty.NewRow();
                    dr["product"] = "Ocean Imports - BCC";
                    dr["unit"] = "";
                    dr["unittype"] = "CBM";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "CBM";
                    dr["volume"] = "";
                    dr["trantype"] = "FI";
                    dr["jobtype"] = "BCC";
                    dr["bid"] = branchid;
                    dr["subprod"] = "FI";
                    dtempty.Rows.Add(dr);

                    dr = dtempty.NewRow();
                    dr["product"] = "Ocean Imports - CHA Activity";
                    dr["unit"] = "";
                    dr["unittype"] = "Shpts";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "Shpts";
                    dr["volume"] = "";
                    dr["trantype"] = "FI";
                    dr["jobtype"] = "CH";
                    dr["bid"] = branchid;
                    dr["subprod"] = "SI";
                    dtempty.Rows.Add(dr);

                    dr = dtempty.NewRow();
                    dr["product"] = "Air Imports";
                    dr["unit"] = "";
                    dr["unittype"] = "Tonnage";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "Tonnage";
                    dr["volume"] = "";
                    dr["trantype"] = "AI";
                    dr["jobtype"] = "AI";
                    dr["bid"] = branchid;
                    dr["subprod"] = "AI";
                    dtempty.Rows.Add(dr);

                    dr = dtempty.NewRow();
                    dr["product"] = "Air Imports - CHA Activity";
                    dr["unit"] = "";
                    dr["unittype"] = "Shpts";
                    dr["vactual"] = "";
                    dr["rbudget"] = "";
                    dr["ractual"] = "Shpts";
                    dr["volume"] = "";
                    dr["trantype"] = "CH";
                    dr["jobtype"] = "CH";
                    dr["bid"] = branchid;
                    dr["subprod"] = "AI";
                    dtempty.Rows.Add(dr);
                    if (ddlmonth.SelectedItem.ToString() == "All")
                    {
                        intmonth = 0;
                    }
                    else
                    {
                        intmonth = Convert.ToInt32(ddlmonth.SelectedValue);
                    }

                    if (ddlyear.SelectedItem.ToString() == "All")
                    {
                        intyear = 0;
                    }
                    else
                    {
                        intyear = Convert.ToInt32(ddlyear.SelectedValue);
                    }
                  
                    Dtbranch = budobj.GetBudgetBranch4Salesperson(branchid, intmonth, intyear,empid );


                   // double totalVol = 0;
                    //double totalamt = 0;

                    for (int i = 0; i <= Dtbranch.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dtempty.Rows.Count - 1; j++)
                        {
                            if (Dtbranch.Rows[i]["trantype"].ToString() == dtempty.Rows[j]["trantype"].ToString())
                            {
                                if (Dtbranch.Rows[i]["trantype"].ToString() == "CH")
                                {
                                    if (Dtbranch.Rows[i]["trantype"].ToString() == dtempty.Rows[j]["trantype"].ToString())
                                    {
                                        if (Dtbranch.Rows[i]["jobtype"].ToString() == dtempty.Rows[j]["jobtype"].ToString())
                                        {
                                            dtempty.Rows[j]["unit"] = Dtbranch.Rows[i]["Volume"].ToString();
                                          //  totalVol = totalVol + Convert.ToDouble(dtempty.Rows[j]["unit"].ToString());

                                            dtempty.Rows[j]["unittype"] = Dtbranch.Rows[i]["volumetype"].ToString();

                                            dtempty.Rows[j]["vactual"] = Dtbranch.Rows[i]["billamt"].ToString();
                                            //totalamt = totalamt + Convert.ToDouble(dtempty.Rows[j]["vactual"].ToString());
                                            //volval = Dtbranch.Rows[i]["actualbill"].ToString();
                                            volval = Convert.ToDecimal(volval).ToString("#,0.00");
                                            dtempty.Rows[j]["volume"] = volval;
                                        }
                                    }
                                }
                                else
                                {
                                    if (Dtbranch.Rows[i]["jobtype"].ToString() == dtempty.Rows[j]["jobtype"].ToString())
                                    {
                                        dtempty.Rows[j]["unit"] = Dtbranch.Rows[i]["Volume"].ToString();
                                        //totalVol = totalVol + Convert.ToDouble(dtempty.Rows[j]["unit"].ToString());

                                        dtempty.Rows[j]["unittype"] = Dtbranch.Rows[i]["volumetype"].ToString();

                                        dtempty.Rows[j]["vactual"] = Dtbranch.Rows[i]["billamt"].ToString();
                                        //totalamt = totalamt + Convert.ToDouble(dtempty.Rows[j]["vactual"].ToString());
                                        //volval = Dtbranch.Rows[i]["actualbill"].ToString();
                                        volval = Convert.ToDecimal(volval).ToString("#,0.00");
                                        dtempty.Rows[j]["volume"] = volval;
                                    }
                                }
                            }
                        }
                    }

                    double totactret = 0;
                    double totactvolume = 0;


                    dtactualbillinv = budobj.GetRetntion4LastyearWithSalesperid(branchid, intmonth, intyear, empid);
                  

                    if (dtactualbillinv.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dtactualbillinv.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dtempty.Rows.Count - 1; j++)
                            {
                                if (dtactualbillinv.Rows[i]["trantype"].ToString() == dtempty.Rows[j]["trantype"].ToString())
                                {
                                    if (dtactualbillinv.Rows[i]["jobtype"].ToString() == dtempty.Rows[j]["jobtype"].ToString())
                                    {
                                        if (dtactualbillinv.Rows[i]["subprod"].ToString() == dtempty.Rows[j]["subprod"].ToString())
                                        {
                                            rbudgetval = dtactualbillinv.Rows[i]["retention"].ToString();
                                            rbudgetval = Convert.ToDecimal(rbudgetval).ToString("#,0.00");
                                            dtempty.Rows[j]["rbudget"] = rbudgetval;

                                            totactret = totactret + Convert.ToDouble(dtempty.Rows[j]["rbudget"].ToString());
                                            volval = dtactualbillinv.Rows[i]["volume"].ToString();
                                            volval = Convert.ToDecimal(volval).ToString("#,0.00");
                                            dtempty.Rows[j]["volume"] = volval;

                                            totactvolume = totactvolume + Convert.ToDouble(dtempty.Rows[j]["volume"].ToString());
                                        }

                                    }

                                }
                            }
                        }
                    }


                    //dr = dtempty.NewRow();
                    //dr["product"] = "Total";
                    //dr["vactual"] = totalamt.ToString("#,0.00");
                    //dr["rbudget"] = totactvolume.ToString("#,0.00");
                    //dtempty.Rows.Add(dr);

                    if (dtempty.Rows.Count > 0)
                    {
                        grdsales .DataSource = dtempty;
                        grdsales.DataBind();
                    }

                    //TextBox txt2 = (TextBox)gvProducts.Rows[gvProducts.Rows.Count - 1].Cells[0].FindControl("txtunit");
                    //TextBox txt3 = (TextBox)gvProducts.Rows[gvProducts.Rows.Count - 1].Cells[2].FindControl("txtrent");
                   // ImageButton img = (ImageButton)gvProducts.Rows[gvProducts.Rows.Count - 1].Cells[12].FindControl("imgbutton");
                    //txt2.ReadOnly = true;
                    //txt3.ReadOnly = true;
                   // img.Visible = false;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_view, typeof(TextBox), "Budget", "alertify.alert('Select Year');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_view, typeof(TextBox), "Budget", "alertify.alert('Select Month');", true);
                return;
            }
        }

        private void GetJobtype()
        {
            if (strjobtype == "FCL")
            {
                intjobtype = 3;
            }
            else if (strjobtype == "CONSOL")
            {
                intjobtype = 1;
            }
            else if (strjobtype == "LCL")
            {
                intjobtype = 2;
            }
            else if (strjobtype == "MCC")
            {
                intjobtype = 4;
            }
            else if (strjobtype == "BCC")
            {
                intjobtype = 5;
            }
            else
            {
                intjobtype = 0;
            }

        }

        protected void grdsales_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (txtcompany.Text != "")
            {
                if (ddllocation.Text != "")
                {
                    if (e.Row.RowType == DataControlRowType.Header)
                    {
                       ((Label)e.Row.FindControl("lblyear")).Text = month.ToString().Substring(0, 3) + "/" +(Convert.ToInt32(stryear.ToString()) - 1).ToString();
                       lblBudget.Text = "Budget For The Month of " + month.ToString().Substring(0, 3) + "-" + stryear;
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdsales, "Select$" + e.Row.RowIndex);
            }

        }

        protected void imgbutton_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnsubmit = sender as ImageButton;
            GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
            int index = gRow.RowIndex;

            if (grdsales.Rows[index].Cells[1].Text != "Total")
            {

                Session["budgetbillcus"] = grdsales.Rows[index].Cells[2].Text;
                Session["budgetvolumecus"] = grdsales.Rows[index].Cells[4].Text;
                strmonth = Convert.ToInt32(Session["ddlmonth"].ToString());
                stryear = Convert.ToInt32(Session["Year"].ToString());
                txtcompany.Text = Session["LoginDivisionName"].ToString();

                month = Session["Month"].ToString();
                bid = Convert.ToInt32(Session["LoginBranchid"]);


                Session["strtrantype"] = grdsales.Rows[index].Cells[7].Text;
                Session["strjobtype"] = grdsales.Rows[index].Cells[8].Text;

                Session["budgetbranchname"] = ddllocation.SelectedItem.ToString();

                if ((grdsales.Rows[index].Cells[3].Text != "&nbsp;") && (grdsales.Rows[index].Cells[4].Text != "&nbsp;"))
                {
                    if ((grdsales.Rows[index].Cells[3].Text != "") && (grdsales.Rows[index].Cells[4].Text != ""))
                    {
                        if ((grdsales.Rows[index].Cells[3].Text != "0.00") && (grdsales.Rows[index].Cells[4].Text != "0.00"))
                        {
                            Session["txtunit"] = grdsales.Rows[index].Cells[3].Text;
                            Session["txtrent"] = grdsales.Rows[index].Cells[4].Text;
                            ifrmaster.Attributes["src"] = "../CRM/BudgetCust.aspx";
                            this.popupBuying.Show();
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_view, typeof(TextBox), "Budget", "alertify.alert(' There is no Budget for this Product');", true);
                    return;
                }

            }
            else
            {
                return;
            }

        }

        protected void grdsales_SelectedIndexChanged1(object sender, EventArgs e)
        {
          

            
        }
    }
}
