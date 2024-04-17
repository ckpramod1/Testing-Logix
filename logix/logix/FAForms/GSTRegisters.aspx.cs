using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Web.Services;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Web.Services.Description;


namespace logix.FAForm
{
    public partial class GSTRegisters : System.Web.UI.Page
    {
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        string strtrantype;
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();

        DataAccess.LogDetails da_obj_lD = new DataAccess.LogDetails();
        DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
        DataAccess.Outstanding budgetobj = new DataAccess.Outstanding();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();


        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);



            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                logobj.GetDataBase(Ccode);
                hrempobj.GetDataBase(Ccode);
                da_obj_lD.GetDataBase(Ccode);
                HREmpobj.GetDataBase(Ccode);
                budgetobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
              
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_export);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alert('Session TimeOut');window.open('http://marinair.ifact.co.in/logix/','_top');", true);
            }

            if (Session["str_ModuleName"] != null)
            {
                if (Session["str_ModuleName"].ToString() == "FC")
                {
                    strtrantype = "CA";
                }
                else
                {
                    strtrantype = "AC";
                }
            }
            if (!IsPostBack)
            {
                lbl_payreceivable.Visible = false;
                lbl_payreceivableamt.Visible = false;
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
                //txt_from.Text = "01/04/" + Session["vouyear"].ToString();
                //txt_from.Text = Str_CurrrentDate;
                //txt_to.Text = Str_CurrrentDate;

                txt_from.Text = Utility.fn_ConvertDate(da_obj_lD.GetDate().ToShortDateString());
                txt_to.Text = Utility.fn_ConvertDate(da_obj_lD.GetDate().ToShortDateString());
                div_Grdheader.Visible = false;

                string str_CtrlLists = "txt_from~txt_to";
                btn_get.Attributes.Add("OnClick", "return IsDate('" + str_CtrlLists + "')");
                Fn_LoadBranch();

           

                if (strtrantype == "CA")
                {
                    ddl_branch.Visible = true;
                    //Fn_LoadBranch();
                }
                else
                {
                    //lbl_branch.Text = lbl_Header.Text;
                    ddl_branch.Enabled = false;
                    ddl_branch.SelectedItem.Text = Session["LoginBranchName"].ToString();
                }
                //ddlSelect.Enabled = true;

               
            }
        }


        private void Fn_LoadBranch()
        {
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterPort obj_da_Port = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_Port.GetDataBase(Ccode);
            obj_dt = obj_da_Port.GetAllBranchNameforPortName();
            ddl_branch.Items.Add("ALL");
            ddl_branch.DataSource = obj_dt;
            ddl_branch.DataTextField = "portname";
            ddl_branch.DataBind();
        }

        /*protected void btnget_Click(object sender, EventArgs e)
        {
            div_Grdheader.Visible = true;
            grd_trial.Visible = true;
           int int_bid = 0, int_divisionid = 0;
            DateTime FromDate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text).ToString());
            DateTime ToDate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text).ToString());
            DataTable DT_get = new DataTable();
            DataTable DT_get2 = new DataTable();
            DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
            DataAccess.Outstanding budgetobj = new DataAccess.Outstanding();
            int int_subgroupid=65;
            int_divisionid = Convert.ToInt32( Session["LoginDivisionId"]);
            if (FromDate > ToDate)
            {
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('From Date Should be Lessthan To Date');", true);
                txt_from.Focus();
            }

            string dispname;
            

            DataAccess.FAMaster.TBCurwiseLedger obj_TB = new DataAccess.FAMaster.TBCurwiseLedger();
            DataSet ds_Transdet = new DataSet();

             int_bid = HREmpobj.GetBranchId(int_divisionid, ddl_branch.SelectedItem.Text);
             int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            if (ddl_By.SelectedItem.Text == "GSTR1 Local Taxable Sales")
            {
                DT_get = budgetobj.Get_GSTvoucher4xlGSTReportFormat(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "GSTR1L", ""); //ddl_GST.SelectedValue,

                if (DT_get.Rows.Count > 0)
                {
                    
                    grd_trial.Visible = true;
                    //var vouchervalue = DT_get.Compute("sum(vouchervalue)", "");
                    var TaxableValue = DT_get.Compute("sum(TaxableValue)", "");
                    var NonTax = DT_get.Compute("sum(IntegratedTax)", "");
                    var CentralTax = DT_get.Compute("sum(CentralTax)", "");
                    var StateTax = DT_get.Compute("sum(StateTax)", "");
                    //var CessAmount = DT_get.Compute("sum(CessAmount)", "");
                    var InvoiceAmount = DT_get.Compute("sum(InvoiceAmount)", "");
                    //var total = DT_get.Compute("sum(total)", "");
                    DataRow dr1 = DT_get.NewRow();
                    DT_get.Rows.Add(dr1);
                    dr1[3] = "Total";
                    //dr1[7] = vouchervalue;
                    dr1[4] = TaxableValue;
                    dr1[5] = NonTax;
                    dr1[6] = CentralTax;
                    dr1[7] = StateTax;
                    //dr1[8] = CessAmount;
                    dr1[9] = InvoiceAmount;
                    //dr1[10] = total;
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();


                    ViewState["data"] = DT_get;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);
                    return;
                }
            }
            else if (ddl_By.SelectedItem.Text == "GSTR1 Overseas Sales")
            {
                DT_get = budgetobj.Get_GSTvoucher4xlGSTReportFormat(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "GSTR1O", ""); //ddl_GST.SelectedValue,



                if (DT_get.Rows.Count > 0)
                {

                    grd_trial.Visible = true;
                    //var vouchervalue = DT_get.Compute("sum(vouchervalue)", "");
                    var TaxableValue = DT_get.Compute("sum(TaxableValue)", "");
                    var NonTax = DT_get.Compute("sum(IntegratedTax)", "");
                    var CentralTax = DT_get.Compute("sum(CentralTax)", "");
                    var StateTax = DT_get.Compute("sum(StateTax)", "");
                    //var CessAmount = DT_get.Compute("sum(CessAmount)", "");
                    var InvoiceAmount = DT_get.Compute("sum(TotalTaxAmount)", "");
                    var InvoiceAmount1 = DT_get.Compute("sum(InvoiceAmount)", "");
                    //var total = DT_get.Compute("sum(total)", "");
                    DataRow dr1 = DT_get.NewRow();
                    DT_get.Rows.Add(dr1);
                    dr1[7] = "Total";
                    //dr1[7] = vouchervalue;
                    dr1[8] = TaxableValue;
                    dr1[9] = NonTax;
                    dr1[10] = CentralTax;
                    dr1[11] = StateTax;
                    //dr1[8] = CessAmount;
                    dr1[13] = InvoiceAmount;
                    dr1[14] = InvoiceAmount1;
                    //dr1[10] = total;
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();


                    ViewState["data"] = DT_get;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);
                    return;
                }

            }

            else if (ddl_By.SelectedItem.Text == "GSTR2 Local Taxable Purchase")
            {
                DT_get = budgetobj.Get_GSTvoucher4xlGSTReportFormat(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "GSTR2 Local Taxable Purchase", ""); //ddl_GST.SelectedValue,


                if (DT_get.Rows.Count > 0)
                {

                    grd_trial.Visible = true;
                    //var vouchervalue = DT_get.Compute("sum(vouchervalue)", "");
                    var TaxableValue = DT_get.Compute("sum(TaxableValue)", "");
                    var NonTax = DT_get.Compute("sum(IntegratedTax)", "");
                    var CentralTax = DT_get.Compute("sum(CentralTax)", "");
                    var StateTax = DT_get.Compute("sum(StateTax)", "");
                    //var CessAmount = DT_get.Compute("sum(CessAmount)", "");
                    var InvoiceAmount = DT_get.Compute("sum(TotalTaxAmount)", "");
                    //var total = DT_get.Compute("sum(total)", "");
                    DataRow dr1 = DT_get.NewRow();
                    DT_get.Rows.Add(dr1);
                    dr1[6] = "Total";
                    //dr1[7] = vouchervalue;
                    dr1[7] = TaxableValue;
                    dr1[8] = NonTax;
                    dr1[9] = CentralTax;
                    dr1[10] = StateTax;
                    //dr1[8] = CessAmount;
                    dr1[12] = InvoiceAmount;
                    //dr1[10] = total;
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();


                    ViewState["data"] = DT_get;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);                   
                    return;
                }

            }
            else if (ddl_By.SelectedItem.Text == "NILL Rate Exempted")
            {
                DT_get = budgetobj.Get_GSTvoucher4xlGSTReportFormat(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "NILLRate", ""); //ddl_GST.SelectedValue,
            }

            else if (ddl_By.SelectedItem.Text == "RCM")
            {
                DT_get = budgetobj.Get_GSTvoucher4xlGSTReportFormat(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "RCM", ""); //ddl_GST.SelectedValue,
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('Please Select Register)')", true);
                ddl_By.Focus();
                return;
            }


            if (strtrantype == "CA")
            {
                int_bid = hrempobj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), ddl_branch.SelectedItem.Text);
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
            }
            else
            {
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
            }
            //DataTable TransDet = new DataTable();
            //DataTable dt = new DataTable();
            //TransDet = ds_Transdet.Tables[0];

            //int rowcount;
            //string subgroupname="";
            //if (TransDet.Rows.Count > 0)
            //{
            //    for (int i = 0; i <= TransDet.Columns.Count - 1; i++)
            //    {
            //        dt.Columns.Add(TransDet.Columns[i].ColumnName);
            //    }

            //    for (int i = 0; i <= TransDet.Rows.Count - 1; i++)
            //    {
            //        dt.Rows.Add();
            //        rowcount = dt.Rows.Count - 1;
            //        if (subgroupname != TransDet.Rows[i][0].ToString())
            //        {
            //            subgroupname = TransDet.Rows[i][0].ToString();
            //            dt.Rows[rowcount][1] = TransDet.Rows[i][0].ToString();
            //            dt.Rows.Add();
            //            rowcount = dt.Rows.Count - 1;
            //        }

            //        dt.Rows[rowcount][1] = TransDet.Rows[i][1].ToString();
                   
            //        for (int j = 2; j <= TransDet.Columns.Count - 1; j++)
            //        {
            //            if ((j >= 3 && j <= 10) || (j >= 13))
            //            {
            //                double temp2;
            //                temp2 = Convert.ToDouble(TransDet.Rows[i][j].ToString());
            //                dt.Rows[rowcount][j] = temp2.ToString("#,0.00");
            //            }
            //            else
            //            {
            //                dt.Rows[rowcount][j] = TransDet.Rows[i][j].ToString();
            //            }
            //        }
            //    }
            //}
                   
            //dt.Columns.Remove("subgroupname");
            //dt.Columns.Remove("ledgerid");
            //dt.Columns.Remove("subgroupid");

            //grd_trial.DataSource = dt;
            //grd_trial.DataBind();
           // ViewState["data"] = dt;    




            /*DataTable Dtemp = new DataTable();
            DataTable dtnew = new DataTable();
            
            DataRow dtrow;
            double total=0.0;
            double amount = 0.0, amount1 = 0.0, amount2 = 0.0, amount3 = 0.0, amount4 = 0.0, amount5=0.0;
            if (DT_get.Rows.Count > 0)
            {

                DataRow dataRow;
                //   Dtemp.Columns.Add("SNo");
                Dtemp.Columns.Add("Date");
                Dtemp.Columns.Add("Particulars");
                Dtemp.Columns.Add("GSTIN/UIN");
                Dtemp.Columns.Add("Invoice No.");
                Dtemp.Columns.Add("Taxable Value");
                Dtemp.Columns.Add("Integrated Tax");
                Dtemp.Columns.Add("Central Tax");
                Dtemp.Columns.Add("State Tax");
                Dtemp.Columns.Add("Cess Amount");
                Dtemp.Columns.Add("Invoice Amount");

                //DataView dv_co = new DataView(DT_get);
                //dtnew = dv_co.ToTable(true, "Date");
                //dv_co = new DataView(dtnew);
                //dv_co.Sort = "Date";
                //dtnew = dv_co.ToTable();
                //DataRow dr = Dtemp.NewRow();
                for (int i = 0; i <= DT_get.Rows.Count - 1; i++)
                {

                    Dtemp.Rows.Add();
                  
                           

                            Dtemp.Rows[i]["Date"] = DT_get.Rows[i]["Date"];
                             Dtemp.Rows[i]["Particulars"] = DT_get.Rows[i]["Particulars"];
                             Dtemp.Rows[i]["GSTIN/UIN"] = DT_get.Rows[i]["GSTIN/UIN"];
                             Dtemp.Rows[i]["Invoice No."] = DT_get.Rows[i]["Invoice No."];

                             Dtemp.Rows[i]["Taxable Value"] = DT_get.Rows[i]["Taxable Value"];
                             Dtemp.Rows[i]["Integrated Tax"] = DT_get.Rows[i]["Integrated Tax"];
                             Dtemp.Rows[i]["Central Tax"] = DT_get.Rows[i]["Central Tax"];
                             Dtemp.Rows[i]["State Tax"] = DT_get.Rows[i]["State Tax"];
                             Dtemp.Rows[i]["Cess Amount"] = DT_get.Rows[i]["Cess Amount"];
                             Dtemp.Rows[i]["Invoice Amount"] = DT_get.Rows[i]["Invoice Amount"];


                            // amount = Convert.ToDouble(DT_get.Compute("sum(Taxable Value)", ""));
                             amount = amount + Convert.ToDouble(Dtemp.Rows[i]["Taxable Value"].ToString());
                             amount1 = amount1 + Convert.ToDouble(Dtemp.Rows[i]["Integrated Tax"].ToString());
                             amount2 = amount2 + Convert.ToDouble(Dtemp.Rows[i]["Central Tax"].ToString());
                             amount3 = amount3 + Convert.ToDouble(Dtemp.Rows[i]["State Tax"].ToString());
                            // amount4 = amount4 + Convert.ToDouble(Dtemp.Rows[i]["Cess Amount"].ToString());
                             amount5 = amount5 + Convert.ToDouble(Dtemp.Rows[i]["Invoice Amount"].ToString());
                            // Dtemp.Rows.Add(dr);
                     }



                int count = Dtemp.Rows.Count;
                Dtemp.Rows.Add();
                Dtemp.Rows[count]["Invoice No."] = "Total";
                Dtemp.Rows[count]["Taxable Value"] = amount.ToString("#,0.00") + "";
                Dtemp.Rows[count]["Integrated Tax"] = amount1.ToString("#,0.00") + "";
                Dtemp.Rows[count]["Central Tax"] = amount2.ToString("#,0.00") + "";
                Dtemp.Rows[count]["State Tax"] = amount3.ToString("#,0.00") + "";
               // Dtemp.Rows[count]["Cess Amount"] = amount4.ToString("#,0.00") + "";
                Dtemp.Rows[count]["Invoice Amount"] = amount5.ToString("#,0.00") + "";
                grd_trial.DataSource = Dtemp;
                grd_trial.DataBind();
                ViewState["data"] = Dtemp;
              
            }



        }
        */



        protected void btnget_Click(object sender, EventArgs e)
        {
            div_Grdheader.Visible = true;
            grd_trial.Visible = true;
            int int_bid = 0, int_divisionid = 0;
            DateTime FromDate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text).ToString());
            DateTime ToDate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text).ToString());
            DataTable DT_get = new DataTable();
            DataTable DT_get2 = new DataTable();
            //DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
            //DataAccess.Outstanding budgetobj = new DataAccess.Outstanding();
            int int_subgroupid = 65;
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
            if (FromDate > ToDate)
            {
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('From Date Should be Lessthan To Date');", true);
                txt_from.Focus();
            }

            string dispname;


            //DataAccess.FAMaster.TBCurwiseLedger obj_TB = new DataAccess.FAMaster.TBCurwiseLedger();
            DataSet ds_Transdet = new DataSet();

            int_bid = HREmpobj.GetBranchId(int_divisionid, ddl_branch.SelectedItem.Text);
            int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            if (ddl_By.SelectedItem.Text == "GSTR1 Local Taxable Sales")
            {
                lbl_head.Visible = true;
                lbl_head.Text = ddl_By.SelectedItem.Text;
                lbl_payreceivable.Visible = false;
                lbl_payreceivableamt.Visible = false;
                ds_Transdet = budgetobj.Get_GSTvoucher4xlGSTReportFormatnew(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "GSTR1L", ""); //ddl_GST.SelectedValue,

                if (ds_Transdet.Tables.Count > 0)
                {
                    DT_get = ds_Transdet.Tables[0];
                   
                    
                }

                if (DT_get.Rows.Count > 0)
                {

                    grd_trial.Visible = true;
                    //var vouchervalue = DT_get.Compute("sum(vouchervalue)", "");
                    var TaxableValue = DT_get.Compute("sum(TaxableValue)", "");
                    var NonTax = DT_get.Compute("sum(IntegratedTax)", "");
                    var CentralTax = DT_get.Compute("sum(CentralTax)", "");
                    var StateTax = DT_get.Compute("sum(StateTax)", "");
                    //var CessAmount = DT_get.Compute("sum(CessAmount)", "");
                    var InvoiceAmount = DT_get.Compute("sum(InvoiceAmount)", "");
                    //var total = DT_get.Compute("sum(total)", "");
                    DataRow dr1 = DT_get.NewRow();
                    DT_get.Rows.Add(dr1);
                    dr1[3] = "Total";
                    //dr1[7] = vouchervalue;
                    dr1[4] = TaxableValue;
                    dr1[5] = NonTax;
                    dr1[6] = CentralTax;
                    dr1[7] = StateTax;
                    //dr1[8] = CessAmount;
                    dr1[9] = InvoiceAmount;
                    //dr1[10] = total;
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();

                    ViewState["data"] = DT_get;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();
                    return;
                }
            }

            else if (ddl_By.SelectedItem.Text == "GSTR1 Local NillRate Sales")
            {
                lbl_head.Visible = true;
                lbl_head.Text = ddl_By.SelectedItem.Text;
                lbl_payreceivable.Visible = false;
                lbl_payreceivableamt.Visible = false;
                ds_Transdet = budgetobj.Get_GSTvoucher4xlGSTReportFormatnew(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "GSTR1LWOT", ""); //ddl_GST.SelectedValue,

                if (ds_Transdet.Tables.Count > 0)
                {
                    DT_get = ds_Transdet.Tables[0];


                }

                if (DT_get.Rows.Count > 0)
                {

                    grd_trial.Visible = true;
                   //var vouchervalue = DT_get.Compute("sum(vouchervalue)", "");
                    var StateInvValue = DT_get.Compute("sum(StateInvValue)", "");
                    var IntegratedInvValue = DT_get.Compute("sum(IntegratedInvValue)", "");
                    var InvoiceAmount = DT_get.Compute("sum(InvoiceAmount)", "");
                   
                    DataRow dr1 = DT_get.NewRow();
                    DT_get.Rows.Add(dr1);
                    dr1[3] = "Total";
                    //dr1[7] = vouchervalue;
                    dr1[4] = StateInvValue;
                    dr1[5] = IntegratedInvValue;
                    dr1[6] = InvoiceAmount;                   
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();

                    ViewState["data"] = DT_get;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();
                    return;
                }
            }
            else if (ddl_By.SelectedItem.Text == "GSTR1 Overseas Sales")
            {
                lbl_head.Visible = true;
                lbl_head.Text = ddl_By.SelectedItem.Text;
                lbl_payreceivable.Visible = false;
                lbl_payreceivableamt.Visible = false;
                ds_Transdet = budgetobj.Get_GSTvoucher4xlGSTReportFormatnew(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "GSTR1O", ""); //ddl_GST.SelectedValue,

                if (ds_Transdet.Tables.Count > 0)
                {
                    DT_get = ds_Transdet.Tables[0];
                    //DT_get2 = ds_Transdet.Tables[1];
                    //ViewState["data1"] = DT_get2;
                }

                if (DT_get.Rows.Count > 0)
                {

                    grd_trial.Visible = true;
                    //var vouchervalue = DT_get.Compute("sum(vouchervalue)", "");
                    var TaxableValue = DT_get.Compute("sum(TaxableValue)", "");
                    var NonTax = DT_get.Compute("sum(IntegratedTax)", "");
                    var CentralTax = DT_get.Compute("sum(CentralTax)", "");
                    var StateTax = DT_get.Compute("sum(StateTax)", "");
                    //var CessAmount = DT_get.Compute("sum(CessAmount)", "");
                    var InvoiceAmount = DT_get.Compute("sum(TotalTaxAmount)", "");
                    var InvoiceAmount1 = DT_get.Compute("sum(InvoiceAmount)", "");
                    //var total = DT_get.Compute("sum(total)", "");
                    DataRow dr1 = DT_get.NewRow();
                    DT_get.Rows.Add(dr1);
                    dr1[7] = "Total";
                    //dr1[7] = vouchervalue;
                    dr1[8] = TaxableValue;
                    dr1[9] = NonTax;
                    dr1[10] = CentralTax;
                    dr1[11] = StateTax;
                    //dr1[8] = CessAmount;
                    dr1[13] = InvoiceAmount;
                    dr1[14] = InvoiceAmount1;
                    //dr1[10] = total;
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();


                    ViewState["data"] = DT_get;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();
                    return;
                }


            }
                //nivetha 17032023
              else if (ddl_By.SelectedItem.Text == "Local Sales Reversal")
           // else if (ddl_By.SelectedItem.Text == "Local Purchase Reversal")
            {
                lbl_head.Visible = true;
                lbl_head.Text = ddl_By.SelectedItem.Text;
                lbl_payreceivable.Visible = false;
                lbl_payreceivableamt.Visible = false;
                DataTable der=new DataTable();
                der = budgetobj.Get_GSTvoucher4xlGSTReportNew(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "LSR", ""); //ddl_GST.SelectedValue,
                if (der.Rows.Count>0)
                {  grd_trial.Visible = true;
                  
                 DataRow dr_temp = der.NewRow();
                    dr_temp["vendorrefno"] = "Total";

                    dr_temp["taxableValue"] = der.Compute("sum(taxableValue)", "");
                    dr_temp["igst"] = der.Compute("sum(igst)", "");
                    dr_temp["cgst"] = der.Compute("sum(cgst)", "");
                    dr_temp["sgst"] = der.Compute("sum(sgst)", "");
                    dr_temp["taxtotal"] = der.Compute("sum(taxtotal)", "");
                    dr_temp["total"] = der.Compute("sum(total)", "");
                    der.Rows.Add(dr_temp);

                    //dr1[10] = total;
                    grd_trial.DataSource = der;
                    grd_trial.DataBind();
                    ViewState["data"] = der;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);
                    grd_trial.DataSource = der;
                    grd_trial.DataBind();
                    return;
                }


                  
        }
          else if (ddl_By.SelectedItem.Text == "Local Purchase Reversal")
       // else if (ddl_By.SelectedItem.Text == "Local Sales Reversal")
            {
                lbl_head.Visible = true;
                lbl_head.Text = ddl_By.SelectedItem.Text;
                lbl_payreceivable.Visible = false;
                lbl_payreceivableamt.Visible = false;
                DataTable der = new DataTable();
                der = budgetobj.Get_GSTvoucher4xlGSTReportNew(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "LPR", ""); //ddl_GST.SelectedValue,
                if (der.Rows.Count > 0)
                {
                    grd_trial.Visible = true;

                    DataRow dr_temp = der.NewRow();
                    dr_temp["vendorrefno"] = "Total";

                    dr_temp["taxableValue"] = der.Compute("sum(taxableValue)", "");
                    dr_temp["igst"] = der.Compute("sum(igst)", "");
                    dr_temp["cgst"] = der.Compute("sum(cgst)", "");
                    dr_temp["sgst"] = der.Compute("sum(sgst)", "");
                    dr_temp["taxtotal"] = der.Compute("sum(taxtotal)", "");
                    dr_temp["total"] = der.Compute("sum(total)", "");
                    der.Rows.Add(dr_temp);

                    //dr1[10] = total;
                    grd_trial.DataSource = der;
                    grd_trial.DataBind();
                    ViewState["data"] = der;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);
                    grd_trial.DataSource = der;
                    grd_trial.DataBind();
                    return;
                }
            }
            else if (ddl_By.SelectedItem.Text == "Overseas  Sales Reversal")
            {
                lbl_head.Visible = true;
                lbl_head.Text = ddl_By.SelectedItem.Text;
                lbl_payreceivable.Visible = false;
                lbl_payreceivableamt.Visible = false;
                DataTable der = new DataTable();
                der = budgetobj.Get_GSTvoucher4xlGSTReportNew(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "OSR", ""); //ddl_GST.SelectedValue,
                if (der.Rows.Count > 0)
                {
                    grd_trial.Visible = true;

                    DataRow dr_temp = der.NewRow();
                    dr_temp["vendorrefno"] = "Total";

                    dr_temp["taxableValue"] = der.Compute("sum(taxableValue)", "");
                    dr_temp["igst"] = der.Compute("sum(igst)", "");
                    dr_temp["cgst"] = der.Compute("sum(cgst)", "");
                    dr_temp["sgst"] = der.Compute("sum(sgst)", "");
                    dr_temp["taxtotal"] = der.Compute("sum(taxtotal)", "");
                    dr_temp["total"] = der.Compute("sum(total)", "");
                    der.Rows.Add(dr_temp);

                    //dr1[10] = total;
                    grd_trial.DataSource = der;
                    grd_trial.DataBind();
                    ViewState["data"] = der;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);
                    grd_trial.DataSource = der;
                    grd_trial.DataBind();
                    return;
                }

            }
            else if (ddl_By.SelectedItem.Text == "Overseas Purchase Reversal")
            {
                lbl_head.Visible = true;
                lbl_head.Text = ddl_By.SelectedItem.Text;
                lbl_payreceivable.Visible = false;
                lbl_payreceivableamt.Visible = false;
                DataTable der = new DataTable();
                der = budgetobj.Get_GSTvoucher4xlGSTReportNew(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "OPR", ""); //ddl_GST.SelectedValue,
                if (der.Rows.Count > 0)
                {
                    grd_trial.Visible = true;

                    DataRow dr_temp = der.NewRow();
                    dr_temp["vendorrefno"] = "Total";

                    dr_temp["taxableValue"] = der.Compute("sum(taxableValue)", "");
                    dr_temp["igst"] = der.Compute("sum(igst)", "");
                    dr_temp["cgst"] = der.Compute("sum(cgst)", "");
                    dr_temp["sgst"] = der.Compute("sum(sgst)", "");
                    dr_temp["taxtotal"] = der.Compute("sum(taxtotal)", "");
                    dr_temp["total"] = der.Compute("sum(total)", "");
                    der.Rows.Add(dr_temp);

                    //dr1[10] = total;
                    grd_trial.DataSource = der;
                    grd_trial.DataBind();
                    ViewState["data"] = der;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);
                    grd_trial.DataSource = der;
                    grd_trial.DataBind();
                    return;
                }
            }
            //nivetha 17032023
            else if (ddl_By.SelectedItem.Text == "GSTR2 Local Taxable Purchase")
            {
                lbl_head.Visible = true;
                lbl_head.Text = ddl_By.SelectedItem.Text;
                lbl_payreceivable.Visible = false;
                lbl_payreceivableamt.Visible = false;
                ds_Transdet = budgetobj.Get_GSTvoucher4xlGSTReportFormatnew(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "GSTR2", ""); //ddl_GST.SelectedValue,
                if (ds_Transdet.Tables.Count > 0)
                {
                    DT_get = ds_Transdet.Tables[0];
                    //DT_get2 = ds_Transdet.Tables[1];
                    //ViewState["data1"] = DT_get2;
                }

                if (DT_get.Rows.Count > 0)
                {

                    grd_trial.Visible = true;
                    //var vouchervalue = DT_get.Compute("sum(vouchervalue)", "");
                    var TaxableValue = DT_get.Compute("sum(TaxableValue)", "");
                    var NonTax = DT_get.Compute("sum(IntegratedTax)", "");
                    var CentralTax = DT_get.Compute("sum(CentralTax)", "");
                    var StateTax = DT_get.Compute("sum(StateTax)", "");
                    //var CessAmount = DT_get.Compute("sum(CessAmount)", "");
                    var InvoiceAmount = DT_get.Compute("sum(TotalTaxAmount)", "");
                    //var total = DT_get.Compute("sum(total)", "");
                    DataRow dr1 = DT_get.NewRow();
                    DT_get.Rows.Add(dr1);
                    dr1[6] = "Total";
                    //dr1[7] = vouchervalue;
                    dr1[7] = TaxableValue;
                    dr1[8] = NonTax;
                    dr1[9] = CentralTax;
                    dr1[10] = StateTax;
                    //dr1[8] = CessAmount;
                    dr1[12] = InvoiceAmount;
                    //dr1[10] = total;
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();


                    ViewState["data"] = DT_get;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();
                    return;
                }

            }

            else if (ddl_By.SelectedItem.Text == "GSTR2 NillRate Purchase")
            {
                lbl_head.Visible = true;
                lbl_head.Text = ddl_By.SelectedItem.Text;
                lbl_payreceivable.Visible = false;
                lbl_payreceivableamt.Visible = false;
                ds_Transdet = budgetobj.Get_GSTvoucher4xlGSTReportFormatnew(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "GSTR2WOT", ""); //ddl_GST.SelectedValue,
                if (ds_Transdet.Tables.Count > 0)
                {
                    DT_get = ds_Transdet.Tables[0];
                    //DT_get2 = ds_Transdet.Tables[1];
                    //ViewState["data1"] = DT_get2;
                }

                if (DT_get.Rows.Count > 0)
                {

                    grd_trial.Visible = true;                  
                    var StateInvValue = DT_get.Compute("sum(StateInvValue)", "");
                    var IntegratedInvValue = DT_get.Compute("sum(IntegratedInvValue)", "");
                    var TotalTaxAmount = DT_get.Compute("sum(TotalTaxAmount)", "");
                  
                    DataRow dr1 = DT_get.NewRow();
                    DT_get.Rows.Add(dr1);
                    dr1[6] = "Total";
                    dr1[7] = StateInvValue;
                    dr1[8] = IntegratedInvValue;
                    dr1[9] = TotalTaxAmount;
                  
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();


                    ViewState["data"] = DT_get;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();
                    return;
                }

            }


            else if (ddl_By.SelectedItem.Text == "NILL Rate Exempted")
            {
                lbl_head.Visible = true;
                lbl_head.Text = ddl_By.SelectedItem.Text;
                lbl_payreceivable.Visible = false;
                lbl_payreceivableamt.Visible = false;
                ds_Transdet = budgetobj.Get_GSTvoucher4xlGSTReportFormatnew(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "NILLRate", ""); //ddl_GST.SelectedValue,

                if (ds_Transdet.Tables.Count > 0)
                {
                    DT_get = ds_Transdet.Tables[0];
                    //DT_get2 = ds_Transdet.Tables[1];
                    //ViewState["data1"] = DT_get2;
                }

                if (DT_get.Rows.Count > 0)
                {
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();
                    ViewState["data"] = DT_get;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();
                    return;
                }

            }

            else if (ddl_By.SelectedItem.Text == "RCM")
            {
                lbl_head.Visible = true;
                lbl_head.Text = ddl_By.SelectedItem.Text;
                lbl_payreceivable.Visible = false;
                lbl_payreceivableamt.Visible = false;
                ds_Transdet = budgetobj.Get_GSTvoucher4xlGSTReportFormatnew(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "RCM", ""); //ddl_GST.SelectedValue,

                if (ds_Transdet.Tables.Count > 0)
                {
                    DT_get = ds_Transdet.Tables[0];
                    DT_get2 = ds_Transdet.Tables[1];
                    ViewState["data1"] = DT_get2;
                }
                if (DT_get.Rows.Count > 0)
                {

                    grd_trial.Visible = true;
                    //var vouchervalue = DT_get.Compute("sum(vouchervalue)", "");
                    var TaxableValue = DT_get.Compute("sum(TaxableValue)", "");
                    //var NonTax = DT_get.Compute("sum(IntegratedTax)", "");
                    var CentralTax = DT_get.Compute("sum(CentralTax)", "");
                    var EligibleCentralTax = DT_get.Compute("sum(EligibleCentralTax)", "");
                    var StateTax = DT_get.Compute("sum(StateTax)", "");
                    var EligibleStateTax = DT_get.Compute("sum(EligibleStateTax)", "");
                    var IntegratedTax = DT_get.Compute("sum(IntegratedTax)", "");
                    var EligibleIntegratedTax = DT_get.Compute("sum(EligibleIntegratedTax)", "");
                    //var CessAmount = DT_get.Compute("sum(CessAmount)", "");
                    // var EligibleCessAmount = DT_get.Compute("sum(EligibleCessAmount)", "");

                    var TotalTax = DT_get.Compute("sum(TotalTax)", "");
                    var TotalEligibleTax = DT_get.Compute("sum(TotalEligibleTax)", "");

                    //var total = DT_get.Compute("sum(total)", "");
                    DataRow dr1 = DT_get.NewRow();
                    DT_get.Rows.Add(dr1);
                    dr1[5] = "Total";
                    //dr1[7] = vouchervalue;
                    dr1[6] = TaxableValue;
                    dr1[7] = CentralTax;
                    dr1[8] = EligibleCentralTax;
                    dr1[9] = StateTax;
                    //dr1[8] = CessAmount;
                    dr1[10] = EligibleStateTax;
                    dr1[11] = IntegratedTax;
                    dr1[12] = EligibleIntegratedTax;
                    //dr1[14] = CessAmount;
                    // dr1[15] = EligibleCessAmount;
                    dr1[15] = TotalTax;
                    dr1[16] = TotalEligibleTax;
                    //dr1[10] = total;
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();


                    ViewState["data"] = DT_get;
                   
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();
                    return;
                }


            }
            else if (ddl_By.SelectedItem.Text == "GSTR-3B")
            {
                lbl_head.Visible = true;
                lbl_head.Text = ddl_By.SelectedItem.Text;
                string values1 = "";
                double amt=0.0;
                ds_Transdet = budgetobj.Get_GSTvoucher4xlGSTReportFormatnew(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "GSTR-3B", ""); //ddl_GST.SelectedValue,

                if (ds_Transdet.Tables.Count > 0)
                {
                    DT_get = ds_Transdet.Tables[0];
                    //DT_get2 = ds_Transdet.Tables[1];
                    //ViewState["data1"] = DT_get2;
                }


                if (ds_Transdet.Tables.Count > 0)
                {
                    DT_get2 = ds_Transdet.Tables[1];
                    if (DT_get2.Rows.Count > 0)
                    {
                        values1 = DT_get2.Rows[0][0].ToString().Substring(0, 1);
                        if(values1=="-")
                        {
                            lbl_payreceivable.Visible = true;
                            lbl_payreceivable.Text = "Tax -Receivable : ";
                            lbl_payreceivableamt.Visible = true;
                            amt =Convert.ToDouble((DT_get2.Rows[0][0].ToString()));
                            lbl_payreceivableamt.Text = Math.Abs(amt).ToString("#0,0.00");
                          
                        }
                        else
                        {
                            lbl_payreceivable.Visible = true;
                            lbl_payreceivable.Text = "Tax -Payable : ";
                            lbl_payreceivableamt.Visible = true;
                            amt = Convert.ToDouble((DT_get2.Rows[0][0].ToString()));
                            lbl_payreceivableamt.Text = Math.Abs(amt).ToString("#0,0.00");
                            
                        }
                    }

                }
                if (DT_get.Rows.Count > 0)
                {
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();
                    ViewState["data"] = DT_get;
                }
                else
                {
                    lbl_payreceivable.Visible = false;
                    lbl_payreceivableamt.Visible = false;
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();
                    return;
                }

            }
            else if (ddl_By.SelectedItem.Text == "GSTR1 Overseas Purchase")
            {
                lbl_head.Visible = true;
                lbl_head.Text = ddl_By.SelectedItem.Text;
                lbl_payreceivable.Visible = false;
                lbl_payreceivableamt.Visible = false;
                ds_Transdet = budgetobj.Get_GSTvoucher4xlGSTReportFormatnew(int_bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), "GSTR11", ""); //ddl_GST.SelectedValue,

                if (ds_Transdet.Tables.Count > 0)
                {
                    DT_get = ds_Transdet.Tables[0];
                    //DT_get2 = ds_Transdet.Tables[1];
                    //ViewState["data1"] = DT_get2;
                }

                if (DT_get.Rows.Count > 0)
                {

                    grd_trial.Visible = true;
                    //var vouchervalue = DT_get.Compute("sum(vouchervalue)", "");
                    var TaxableValue = DT_get.Compute("sum(TaxableValue)", "");
                    var NonTax = DT_get.Compute("sum(IntegratedTax)", "");
                    var CentralTax = DT_get.Compute("sum(CentralTax)", "");
                    var StateTax = DT_get.Compute("sum(StateTax)", "");
                    //var CessAmount = DT_get.Compute("sum(CessAmount)", "");
                    var InvoiceAmount = DT_get.Compute("sum(TotalTaxAmount)", "");
                    var InvoiceAmount1 = DT_get.Compute("sum(InvoiceAmount)", "");
                    //var total = DT_get.Compute("sum(total)", "");
                    DataRow dr1 = DT_get.NewRow();
                    DT_get.Rows.Add(dr1);
                    dr1[7] = "Total";
                    //dr1[7] = vouchervalue;
                    dr1[8] = TaxableValue;
                    dr1[9] = NonTax;
                    dr1[10] = CentralTax;
                    dr1[11] = StateTax;
                    //dr1[8] = CessAmount;
                    dr1[13] = InvoiceAmount;
                    dr1[14] = InvoiceAmount1;
                    //dr1[10] = total;
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();


                    ViewState["data"] = DT_get;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('No Record Found')", true);
                    grd_trial.DataSource = DT_get;
                    grd_trial.DataBind();
                    return;
                }


            }

            else
            {
                lbl_head.Visible = false;               
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alert('Please Select Register)')", true);
                lbl_payreceivable.Visible = false;
                lbl_payreceivableamt.Visible = false;
                ddl_By.Focus();
                return;
            }


            if (strtrantype == "CA")
            {
                int_bid = hrempobj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), ddl_branch.SelectedItem.Text);
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
            }
            else
            {
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
            }

            //logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1866, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Branch:" + ddl_branch.SelectedItem.Text + "/By:" + ddl_By.SelectedItem.Text + "/From:" + txt_from.Text + "/To:" + txt_to.Text + "/GET");

        }





        protected void btn_export_Click(object sender, EventArgs e)
        {
             if (ddl_By.SelectedItem.Text == "GSTR-3B")
            {

                lbl_payreceivable.Visible = true;
                lbl_payreceivableamt.Visible = true;
             }
             else
             {
                 lbl_payreceivable.Visible = false;
                 lbl_payreceivableamt.Visible = false;
             }
            if (grd_trial.Rows.Count > 0)
            {
                //string strtemp = "";
                //string Filename = "GSTRegisterFrom  " + txt_from.Text + " To " + txt_to.Text;
                //strtemp = Utility.Fn_ExportExcel(grd_trial, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                //Response.Clear();
                //Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
                //Response.Buffer = true;
                //Response.Charset = "UTF-8";
                //Response.ContentType = "application/vnd.ms-excel";
                //Response.Write(strtemp);
                //Response.End();



               /* Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=" + ddl_By.SelectedItem.Text + "From  " + txt_from.Text + " To " + txt_to.Text+".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);


                if (grd_trial.Visible == true)
                {
                    grd_trial.GridLines = GridLines.Both;
                    grd_trial.HeaderStyle.Font.Bold = true;
                    grd_trial.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();*/



              
                DataTable dt = (DataTable)ViewState["data"];
                DataTable dt1 = new DataTable();
                if (ViewState["data1"] != null)
                {
                   dt1= (DataTable)ViewState["data1"];
                }
                if (dt.Rows.Count > 0)
                {
                    string str = "", str_filename = "";
                    string Str_FileName = "";
                    Response.ClearContent();
                    Response.Buffer = true;


                    str_filename = "";
                    str_filename = ddl_By.SelectedItem.Text + "-GST Register DETAILS " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt");
                    str_filename = str_filename.Replace(" ", "_");
                    Response.AddHeader("content-disposition", "Attachment;filename=" + ddl_By.SelectedItem.Text + "From  " + txt_from.Text + " To " + txt_to.Text + ".xls");
                    Response.ContentType = "application/ms-excel";
                    
                    str = string.Empty;
                    foreach (DataColumn dtcol in dt.Columns)
                    {
                        Response.Write(str + dtcol.ColumnName);
                        str = "\t";
                    }
                    Response.Write("\n");
                    foreach (DataRow dr in dt.Rows)
                    {
                        str = "";
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            Response.Write(str + Convert.ToString(dr[j]));
                            str = "\t";
                        }
                        Response.Write("\n");
                    }


                   
                    if (dt1.Rows.Count>0)
                    {     
                        Response.Write("\n");
                        Response.Write("\n");
                        Response.Write("\n");
                        Response.Write("\n");
                        Response.Write(ddl_By.SelectedItem.Text);
                        Response.Write("\n");                        
                        str = string.Empty;
                        foreach (DataColumn dtcol in dt1.Columns)
                        {
                            Response.Write(str + dtcol.ColumnName);
                            str = "\t";
                        }
                        Response.Write("\n");
                        foreach (DataRow dr in dt1.Rows)
                        {
                            str = "";
                            for (int j = 0; j < dt1.Columns.Count; j++)
                            {
                                Response.Write(str + Convert.ToString(dr[j]));
                                str = "\t";
                            }
                            Response.Write("\n");
                        }
                    }

                    Response.End();
                }


            }
        }

        //protected void btnprint_Click(object sender, EventArgs e)
        //{

        //}

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
            //txt_from.Text = "01/04/" + Session["vouyear"].ToString();
            txt_from.Text = Str_CurrrentDate;
            txt_to.Text = Str_CurrrentDate;
            div_Grdheader.Visible = false;
            grd_trial.Visible = false;
            grd_trial.DataSource = null;
            grd_trial.DataBind();
            ddl_By.SelectedValue = "";
            lbl_head.Visible = false; 
            lbl_payreceivable.Visible = false;
            lbl_payreceivableamt.Visible = false;
            //if (strtrantype == "CA")
            //{
            //    ddl_branch.SelectedValue = "ALL";
            //}
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected void grd_trial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double dbl_temp = 0;
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                // e.Row.Cells[0].CssClass = "locked";

                
                 if (ddl_By.SelectedItem.Text == "GSTR1 Local Taxable Sales")
                 {
                     //d
                     for (int h = 4; h < e.Row.Cells.Count-1; h++)
                     {
                         if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                         {
                             e.Row.Cells[h].Text = dbl_temp.ToString("#.00");
                         }
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }
                 }

                 else if (ddl_By.SelectedItem.Text == "GSTR1 Local NillRate Sales")
                 {
                     //dd for (int h = 4; h < e.Row.Cells.Count; h++)

                     for (int h = 4; h < e.Row.Cells.Count-1; h++)
                     {
                         if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                         {
                             e.Row.Cells[h].Text = dbl_temp.ToString("#.00");
                         }
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }
                 }
                 else if (ddl_By.SelectedItem.Text == "GSTR2 Local Taxable Purchase")
                 {
                   
                     //dd
                     for (int h = 7; h < e.Row.Cells.Count-1; h++)
                     {
                         if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                         {
                             e.Row.Cells[h].Text = dbl_temp.ToString("#.00");
                         }
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }
                 }
                 else if (ddl_By.SelectedItem.Text == "GSTR1 Overseas Sales")
                 {
                     //dd

                     for (int h = 7; h < e.Row.Cells.Count-1; h++)
                     {
                         if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                         {
                             e.Row.Cells[h].Text = dbl_temp.ToString("#.00");
                         }
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }
                 }

                 else if (ddl_By.SelectedItem.Text == "RCM")
                 {
                     //d
                     for (int h = 6; h < e.Row.Cells.Count-1; h++)
                     {
                         if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                         {
                             e.Row.Cells[h].Text = dbl_temp.ToString("#.00");
                         }
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }
                 }

                 else if (ddl_By.SelectedItem.Text == "NILL Rate Exempted")
                 {
                     for (int h = 1; h < e.Row.Cells.Count; h++)
                     {
                         if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                         {
                             e.Row.Cells[h].Text = dbl_temp.ToString("#.00");
                         }
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }
                 }


                 else if (ddl_By.SelectedItem.Text == "GSTR-3B")
                 {
                     for (int h = 1; h < e.Row.Cells.Count; h++)
                     {
                         if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                         {
                             e.Row.Cells[h].Text = dbl_temp.ToString("#.00");
                         }
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }
                 }
                 else if (ddl_By.SelectedItem.Text == "GSTR2 NillRate Purchase")
                 {
                     //d
                     for (int h = 6; h < e.Row.Cells.Count-1; h++)
                     {
                         if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                         {
                             e.Row.Cells[h].Text = dbl_temp.ToString("#.00");
                         }
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }

                 }

                 for (int i = 0; i < e.Row.Cells.Count; i++)
                 {
                     if (e.Row.Cells[i].Text == "&nbsp;")
                     {
                         e.Row.Cells[i].Text = "";
                     }
                     e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                 }                 
             }

             if (e.Row.RowType == DataControlRowType.Header)
             {
                 if (ddl_By.SelectedItem.Text == "GSTR1 Local Taxable Sales")
                 {
                     //d
                     for (int h = 4; h < e.Row.Cells.Count-1; h++)
                     {
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }
                 }
                 else if (ddl_By.SelectedItem.Text == "GSTR2 Local Taxable Purchase")
                 {
                     for (int h = 7; h < e.Row.Cells.Count-1; h++)
                     {
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }
                 }

                 else if (ddl_By.SelectedItem.Text == "GSTR1 Overseas Sales")
                 {
                     for (int h = 7; h < e.Row.Cells.Count-1; h++)
                     {
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }
                 }

                 else if (ddl_By.SelectedItem.Text == "RCM")
                 {
                     for (int h = 6; h < e.Row.Cells.Count-1; h++)
                     {
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }
                 }
                 else if (ddl_By.SelectedItem.Text == "GSTR-3B")
                 {
                     for (int h = 1; h < e.Row.Cells.Count; h++)
                     {
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }
                 }

                 else if (ddl_By.SelectedItem.Text == "NILL Rate Exempted")
                 {
                     for (int h = 1; h < e.Row.Cells.Count; h++)
                     {
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }
                 }
                 else if (ddl_By.SelectedItem.Text == "GSTR1 Local NillRate Sales")
                 {
                     for (int h = 4; h < e.Row.Cells.Count-1; h++)
                     {
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }
                 }
                 else if (ddl_By.SelectedItem.Text == "GSTR2 NillRate Purchase")
                 {
                     for (int h = 6; h < e.Row.Cells.Count-1; h++)
                     {
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }
                 
                 }

               


                 else if (ddl_By.SelectedItem.Text == "GSTR1 Overseas Purchase")
                 {
                     for (int h = 6; h < e.Row.Cells.Count - 1; h++)
                     {
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }

                 }


//NIVETHA 17032023        
                 else if (ddl_By.SelectedItem.Text == "Local Sales Reversal")
                 {
                     for (int h = 6; h < e.Row.Cells.Count - 1; h++)
                     {
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }

                 }
                 else if (ddl_By.SelectedItem.Text == "Local Purchase Reversal")
                 {
                     for (int h = 6; h < e.Row.Cells.Count - 1; h++)
                     {
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }

                 }
                 else if (ddl_By.SelectedItem.Text == "Overseas  Sales Reversal")
                 {
                     for (int h = 6; h < e.Row.Cells.Count - 1; h++)
                     {
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }

                 }
                 else if (ddl_By.SelectedItem.Text == "Overseas Purchase Reversal")
                 {
                     for (int h = 6; h < e.Row.Cells.Count - 1; h++)
                     {
                         e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                     }

                 }
                 //NIVETHA 17032023 
             }

        }

        protected void grd_trial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_trial.PageIndex = e.NewPageIndex;
            grd_trial.DataSource = (DataTable)ViewState["data"];
            grd_trial.DataBind();
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
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        protected void loadgridlog()
        {
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            GridViewlog.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();

            lbl_no.InnerText = lbl_header.Text;


            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1866, "", "", "", Session["StrTranType"].ToString());


            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grd_trial_PreRender(object sender, EventArgs e)
        {
            if (grd_trial.Rows.Count > 0)
            {
                grd_trial.UseAccessibleHeader = true;
                grd_trial.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GridViewlog_PreRender(object sender, EventArgs e)
        {
            if (GridViewlog.Rows.Count > 0)
            {
                GridViewlog.UseAccessibleHeader = true;
                GridViewlog.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}