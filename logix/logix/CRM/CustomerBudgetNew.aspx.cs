using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using DataAccess.HR;
using logix.CRMNew;
using System.ComponentModel;
using System.Web.Services.Description;
namespace logix.CRM
{
    public partial class CustomerBudgetNew : System.Web.UI.Page
    {
        DataTable Dt = new DataTable();
        DataAccess.Masters.MasterBranch bobj = new DataAccess.Masters.MasterBranch();
        DataAccess.CRMNew.Budget budobj = new DataAccess.CRMNew.Budget();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.LogDetails LogObj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();

        string prod;
        DataTable Dtbranch,dtcustomer,dtactualbillinv,dtcusamt = new DataTable();
        String custype,jobtype,subprod;
        int porid,intvouyear,intsalesid,check;
        int intmonth,i, j, k ;
        int bid,intcust,mccid;
        double unit=0;
        double retention = 0, dunit = 0, drentention = 0;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        Double acbillamt= 0,bgtacbill;
        int portid;
        Single getamt;
        Double actrentention = 0, volume = 0;
        int intyear;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                bobj.GetDataBase(Ccode);
                budobj.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                portobj.GetDataBase(Ccode);
                HREmpobj.GetDataBase(Ccode);
                empobj.GetDataBase(Ccode);
                LogObj.GetDataBase(Ccode);
                da_obj_Customer.GetDataBase(Ccode);
              

            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnsave);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);

            if (!IsPostBack)
            {
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CRM")
                    {
                        HeaderLabel1.InnerText = "CRM";
                        li_head.Visible = true;
                        if (HeaderLabel1.InnerText == "CRM")
                        {
                            label1id.InnerText = "CRM";
                        }
                    }
                    else
                    {
                        li_head.Visible = false;
                    }
                    
                }
                //if (Session["StrTranType"].ToString() == "FE")
                //{
                //    HeaderLabel1.InnerText = "Ocean Exports";
                //}
                //else if (Session["StrTranType"].ToString() == "FI")
                //{
                //    HeaderLabel1.InnerText = "Ocean Imports";
                //}
                //else if (Session["StrTranType"].ToString() == "AE")
                //{
                //    HeaderLabel1.InnerText = "Air Exports";
                //} 
                //else
                //{
                    
                //}
                Ctrl_List = txtcustomer.ID + "~" + txtport.ID + "~" + txtunits.ID + "~" + txtrentention.ID;
                Msg_List = "Customer~Port~Unit~Retention";
                Dtype_List = "string~string~string~string";
                btnadd.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                FillBranch();
                FillMonth();
                txtsalperson.Text = empobj.GetEmployeeName(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                cmbbranch.SelectedItem.Text = Session["LoginBranchName"].ToString();
                grdcustomer.DataSource = Utility.Fn_GetEmptyDataTable();
                grdcustomer.DataBind();
                FillTrantype();
                btncancel.Text = "Cancel";
                btncancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                txtcustomer.Enabled = false;
                txtport.Enabled = false;
                txtunits.Enabled = false;
                txtrentention.Enabled = false;
                btnadd.Enabled = false;
                btnadd.Enabled = false;
                btncancel.Enabled = true;
                btnsave.Enabled = false;
            }
        }

        private void FillBranch()
        {
            Dt = bobj.GetBranchByDivID(HREmpobj.GetDivisionId(Session["LoginDivisionName"].ToString()));
            cmbbranch.Items.Clear();
            for (int i = 0; i <= Dt.Rows.Count-1; i++)
            {
                cmbbranch.Items.Add(Dt.Rows[i]["branch"].ToString());
            }
        }
    
        private void FillMonth()
        {
            cmbmonth.Items.Clear();
            cmbmonth.Items.Add("Month");
            cmbmonth.Items.Add("January");
            cmbmonth.Items.Add("Febraury");
            cmbmonth.Items.Add("March");
            cmbmonth.Items.Add("April");
            cmbmonth.Items.Add("May");
            cmbmonth.Items.Add("June");
            cmbmonth.Items.Add("July");
            cmbmonth.Items.Add("August");
            cmbmonth.Items.Add("September");
            cmbmonth.Items.Add("October");
            cmbmonth.Items.Add("November");
            cmbmonth.Items.Add("December");

            cmbyear.Items.Clear();
            cmbyear.Items.Add("Year");
            for (int i = LogObj.GetDate().Year ; i <= LogObj.GetDate().Year + 2; i++)
            {
                cmbyear.Items.Add(i.ToString());
            }
        }

        private void Check()
        {
            check = 0;
           if(cmbmonth.SelectedItem == null || cmbmonth.SelectedItem.Text == "Month")
           {
               ScriptManager.RegisterClientScriptBlock(btnsave, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Select Month');", true);
               cmbmonth.Focus();
               check = 1;
               return;
           }
           if (cmbyear.SelectedItem == null || cmbyear.SelectedItem.Text == "Year")
           {
               ScriptManager.RegisterClientScriptBlock(btnsave, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Select Year');", true);
               cmbyear.Focus();
               check = 1;
               return;
           }
           if (cmbproduct.SelectedItem == null || cmbproduct.SelectedItem.Text == "Product")
           {
               ScriptManager.RegisterClientScriptBlock(btnsave, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Select Product');", true);
               cmbproduct.Focus();
               check = 1;
               return;
           }
           if (txtbudunits.Text == "" )
           {
               ScriptManager.RegisterClientScriptBlock(btnsave, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Select Budget Unit');", true);
               txtbudunits.Focus();
               check = 1;
               return;
           }
           if (txtbudret.Text == "")
           {
               ScriptManager.RegisterClientScriptBlock(btnsave, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Select Budget Retention');", true);
               txtbudret.Focus();
               check = 1;
               return;
           }
        
        }
        


        private void clear()
        {
            txtbudunits.Text = "";
            txttype.Text = "";
            txtbudret.Text = "";
            txtcustomer.Text = "";
            txtport.Text = "";
            txtunits.Text = "";
            txtrentention.Text = "";
            btnsave.Text = "Save";
            btnsave.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            btncancel.Text = "Back";
            btncancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
            btnadd.Text = "Add";  
            btnadd.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn ico-add";
            cmbmonth.Enabled = true;
            cmbyear.Enabled = true;
            cmbproduct.Enabled = true;
            txtbudunits.Enabled = true;
            txtbudret.Enabled = true;
            txttotrent.Text = "";
            txttotunit.Text = "";
            grdcustomer.DataSource = Utility.Fn_GetEmptyDataTable();
            grdcustomer.DataBind();
            FillBranch();
            FillMonth();
            FillTrantype();
        }

        protected void cmbproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txttype.Text = "";
            if (cmbmonth.SelectedItem == null || cmbmonth.SelectedItem.Text == "Month")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Select Month');", true);
                cmbmonth.Focus();
                return;
            }
            if (cmbyear.SelectedItem == null || cmbyear.SelectedItem.Text == "Year")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Select Year');", true);
                cmbyear.Focus();
                return;
            }
            GetTrantypeVal();
            FillDetails();
            display();
        }

        private void GetTrantypeVal()
        {
            if (cmbproduct.SelectedItem.Text == "OCEAN EXPORTS- FCL")
            {
                txttype.Text = "Teus";
                subprod = "FE";
                prod = "FE";
                jobtype = "FCL";
                txtport.Attributes.Add("placeholder", "PoD");
            }
            else if (cmbproduct.SelectedItem.Text == "OCEAN EXPORTS- MCC")
            {
                txttype.Text = "Teus";
                subprod = "FE";
                prod = "FE";
                jobtype = "MCC";
                txtport.Attributes.Add("placeholder", "PoD");
            }
            else if (cmbproduct.SelectedItem.Text == "OCEAN EXPORTS- CONSOL")
            {
                txttype.Text = "Teus";
                subprod = "FE";
                prod = "FE";
                jobtype = "CONSOL";
                txtport.Attributes.Add("placeholder", "PoD");
            }
            else if (cmbproduct.SelectedItem.Text == "OCEAN EXPORTS- LCL")
            {
                txttype.Text = "CBM";
                subprod = "FE";
                prod = "FE";
                jobtype = "LCL";
                txtport.Attributes.Add("placeholder", "PoD");
            }
            else if (cmbproduct.SelectedItem.Text == "OCEAN EXPORTS- BCC")
            {
                txttype.Text = "CBM";
                subprod = "FE";
                prod = "FE";
                jobtype = "BCC";
                txtport.Attributes.Add("placeholder", "PoD");
            }
            else if (cmbproduct.SelectedItem.Text == "OCEAN EXPORTS- CHA Activity")
            {
                txttype.Text = "Shipments";
                subprod = "SE";
                prod = "CH";
                jobtype = "CH";
            }
            else if (cmbproduct.Text == "AIR EXPORTS")
            {
                txttype.Text = "Tonnage";
                subprod = "AE";
                prod = "AE";
                jobtype = "AE";
                txtport.Attributes.Add("placeholder", "PoD");
            }
            else if (cmbproduct.Text == "AIR EXPORTS- CHA Activity")
            {
                txttype.Text = "Shipments";
                subprod = "AE";
                prod = "CH";
                jobtype = "CH";
                txtport.Attributes.Add("placeholder", "PoD");
            }
            else if (cmbproduct.Text == "OCEAN IMPORTS- FCL")
            {
                txttype.Text = "Teus";
                subprod = "FI";
                prod = "FI";
                jobtype = "FCL";
                txtport.Attributes.Add("placeholder", "PoL");
            }
            else if (cmbproduct.Text == "OCEAN IMPORTS- MCC")
            {
                txttype.Text = "Teus";
                subprod = "FI";
                prod = "FI";
                jobtype = "MCC";
                txtport.Attributes.Add("placeholder", "PoL");
            }
            else if (cmbproduct.Text == "OCEAN IMPORTS- CONSOL")
            {
                txttype.Text = "Teus";
                subprod = "FI";
                prod = "FI";
                jobtype = "CONSOL";
                txtport.Attributes.Add("placeholder", "PoL");
            }
            else if (cmbproduct.Text == "OCEAN IMPORTS- LCL")
            {
                txttype.Text = "CBM";
                subprod = "FI";
                prod = "FI";
                jobtype = "LCL";
            }
            else if (cmbproduct.Text == "OCEAN IMPORTS- BCC")
            {
                txttype.Text = "CBM";
                subprod = "FI";
                prod = "FI";
                jobtype = "BCC";
                txtport.Attributes.Add("placeholder", "PoL");
            }
            else if (cmbproduct.Text == "OCEAN IMPORTS- CHA Activity")
            {
                txttype.Text = "Shipments";
                subprod = "SI";
                prod = "CH";
                jobtype = "CH";
                txtport.Attributes.Add("placeholder", "PoL");
            }
            else if (cmbproduct.Text == "AIR IMPORTS")
            {
                txttype.Text = "Tonnage";
                subprod = "AI";
                prod = "AI";
                jobtype = "AI";
                txtport.Attributes.Add("placeholder", "PoL");
            }

            else if (cmbproduct.Text == "AIR IMPORTS- CHA Activity")
            {
                txttype.Text = "Shipments";
                subprod = "AI";
                prod = "CH";
                jobtype = "CH";
                txtport.Attributes.Add("placeholder", "PoL");
            }
        }

        private void FillTrantype()
        {
            cmbproduct.Items.Clear();
            cmbproduct.Items.Add("Product");
            cmbproduct.Items.Add("AIR EXPORTS");
            cmbproduct.Items.Add("AIR EXPORTS- CHA");
            cmbproduct.Items.Add("AIR IMPORTS");
            cmbproduct.Items.Add("AIR IMPORTS- CHA");
            cmbproduct.Items.Add("OCEAN EXPORTS- BCC");
            cmbproduct.Items.Add("OCEAN EXPORTS- CHA");
            cmbproduct.Items.Add("OCEAN EXPORTS- CONSOL");
            cmbproduct.Items.Add("OCEAN EXPORTS- FCL");
            cmbproduct.Items.Add("OCEAN EXPORTS- LCL");
            cmbproduct.Items.Add("OCEAN EXPORTS- MCC");
            cmbproduct.Items.Add("OCEAN IMPORTS- BCC");

            cmbproduct.Items.Add("OCEAN IMPORTS- CHA");
            cmbproduct.Items.Add("OCEAN IMPORTS- CONSOL");
            cmbproduct.Items.Add("OCEAN IMPORTS- FCL");
            cmbproduct.Items.Add("OCEAN IMPORTS- LCL");
            cmbproduct.Items.Add("OCEAN IMPORTS- MCC");
        }

        //[WebMethod]
        //public static List<string> GetCustomer(string prefix)
        //{
            //List<string> List_Result = new List<string>();
            //DataAccess.Accounts.Budget budobj = new DataAccess.Accounts.Budget();
            //string custype = "C";
            //DataTable dt_cusname = new DataTable();
            //dt_cusname = budobj.GetLikeCustomerForSalesNew(prefix.ToUpper().Trim(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()));
            //List_Result = Utility.Fn_TableToList(dt_cusname, "customer", "customerid");
            //return List_Result;
        //}

        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
           List<string> List_Result = new List<string>();
           DataAccess.CRMNew.Budget budobj = new DataAccess.CRMNew.Budget();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            budobj.GetDataBase(Ccode);
            string custype = "C";
            DataTable dt_cusname = new DataTable();
            dt_cusname = budobj.GetLikeCustomerForSalesNew(prefix.ToUpper().Trim(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()));
            //List_Result = Utility.Fn_TableToList(dt_cusname, "customer", "customerid");
            List_Result = Utility.Fn_DatatableToList_int16DisplayNew(dt_cusname, "customer","customerid", "mccid","customername");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetPortName(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.CRMNew.Budget budobj = new DataAccess.CRMNew.Budget();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            budobj.GetDataBase(Ccode);
            dt = budobj.GetLikePort4Budget(prefix.Trim().ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()));
            // list_result = .Fn_TableToList(prefix.ToUpper(), dt, "countryname");
            // list_result = obj_MasterDistrict.GetCountryName(prefix);
            list_result = Utility.Fn_TableToList(dt, "portname", "portid");
            return list_result;
        }

        private void display()
        {
            bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            intyear = Convert.ToInt32(cmbyear.SelectedItem.Text);
            intsalesid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            Dtbranch = budobj.GetBudgetCustomerNew(bid, intsalesid, intmonth, intyear, prod, jobtype, subprod);
               
            DataTable dtfill = new DataTable();
            dtfill = budobj.GetALLBudgetCustomerPrabha(bid, intsalesid, intmonth, intyear, prod, jobtype, subprod);

            if (dtfill.Rows.Count > 0)
            {
                //int intyear, i;
                //double unit=0,rent=0;
                //double totvol=0, totamount=0;
                //DataTable dtFill = new DataTable();
                //DataTable dtempty = new DataTable();
                //string volval;
                //FillMonthValues();

               
                grdcustomer.DataSource = dtfill;
                grdcustomer.DataBind();
                ViewState["CurrentData"] = dtfill;
            }
           
            DataTable dtcnt = new DataTable();
            dtcnt = budobj.getunittot(bid, intsalesid, intmonth, intyear, prod, jobtype, subprod);

            if (dtcnt.Rows.Count > 0)
            {
                //txttotunit.Text = dtcnt.Rows[0]["volume"].ToString();
                //txttotrent.Text = dtcnt.Rows[0]["billamt"].ToString();

                txttotunit.Text =  Convert.ToSingle(dtcnt.Rows[0]["volume"].ToString())  + " " + txttype.Text.Trim();
                txttotrent.Text = Convert.ToDouble(dtcnt.Rows[0]["billamt"]).ToString("#,0.00");
            }

            //if(grdcustomer.Rows.Count>0)
            //{
            //    grdcustomer.DataSource = Utility.Fn_GetEmptyDataTable();
            //    grdcustomer.DataBind();
            //}
        }
        private void FillDetails()
        {
            int intyear, i;
            double unit=0,rent=0;
            double totvol=0, totamount=0;
            DataTable dtFill = new DataTable();
            DataTable dtempty = new DataTable();
            string volval;
            FillMonthValues();

            try
            {
                bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                intyear = Convert.ToInt32(cmbyear.SelectedItem.Text); 
                intsalesid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                Dtbranch = budobj.GetBudgetCustomerNew(bid, intsalesid, intmonth, intyear, prod, jobtype,subprod);
                rent = 0;
                unit = 0;
                btnsave.Enabled = true;

                 if(Dtbranch.Rows.Count > 0) 
                 {
                     rent = Convert.ToDouble(Dtbranch.Rows[0]["volume"].ToString());
                     Single arent = Convert.ToSingle(rent);
                     //arent = arent;
                     txtbudunits.Text = arent.ToString();
                    unit =  Convert.ToDouble(Dtbranch.Rows[0]["billamt"].ToString());
                    txtbudret.Text = unit.ToString("#,0.00");
                    btncancel.Text = "Cancel";
                    btncancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    
                    btnsave.Text = "Update";
                    btnsave.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                    btnsave.Enabled = false;

                     //prabha
                    cmbmonth.Enabled = false;
                    cmbyear.Enabled = false;
                    cmbproduct.Enabled = false;
                    txtbudunits.Enabled = false;
                    txttype.Enabled = false;
                    txtbudret.Enabled = false;
                    txtcustomer.Enabled = true;
                    txtport.Enabled = true;
                    txtunits.Enabled = true;
                    txtrentention.Enabled = true;
                    btnadd.Enabled = true;
                 }
                 else
                 {
                     txtbudunits.Text = "";
                     txtbudret.Text = "";
                 }
                 DataTable dtcnt = new DataTable();
                 dtcnt = budobj.getunittot(bid, intsalesid, intmonth, intyear, prod, jobtype, subprod);
                
                 if (dtcnt.Rows.Count > 0)
                 {
                     txttotunit.Text = Convert.ToSingle(dtcnt.Rows[0]["volume"].ToString()) + " " + txttype.Text.Trim()  ;
                     //txttotrent.Text = Convert.ToSingle(dtcnt.Rows[0]["billamt"]).ToString();
                     txttotrent.Text = Convert.ToDouble(dtcnt.Rows[0]["billamt"]).ToString("#,0.00");
                 }
                 //dtempty.Columns.Add("customername");
                 //dtempty.Columns.Add("volume");
                 //dtempty.Columns.Add("portname");
                 //dtempty.Columns.Add("billamt");
                 //dtempty.Columns.Add("customerid");
                 //dtempty.Columns.Add("portid");
                 //dtempty.Columns.Add("mccid");
                 //dtempty.Columns.Add("totunit");
                 DataRow dr;

                    //else
                    //{
                    //    grdcustomer.DataSource = Utility.Fn_GetEmptyDataTable();
                    //    grdcustomer.DataBind();
                    //    ViewState["CurrentData"] = null;
                    //}
                    //btnsave.Text = "Update";
                //prabha
                    //txtcustomer.Enabled = true;
                    //txtport.Enabled = true;
                    //txtunits.Enabled = true;
                    //txtrentention.Enabled = true;
                    //btnadd.Enabled = true;
                 //}
                 //else
                 //{
                 //   txttotrent.Text = "";
                 //   txttotunit.Text = "";

                 //   btnsave.Text = "Save";
                 //   txtcustomer.Enabled = false;
                 //   txtport.Enabled = false;
                 //   txtunits.Enabled = false;
                 //   txtrentention.Enabled = false;
                 //   btnadd.Enabled = false;
                 //   grdcustomer.DataSource = Utility.Fn_GetEmptyDataTable();
                 //   grdcustomer.DataBind();
                 //}            
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "CRM", "alertify.alert('" + message + "');", true);
            } 
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
             if(btncancel.ToolTip == "Cancel" )
             {
                 clear();
                
                 txtsalperson.Text = empobj.GetEmployeeName(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                 cmbbranch.SelectedItem.Text = Session["LoginBranchName"].ToString();
                 grdcustomer.DataSource = Utility.Fn_GetEmptyDataTable();
                 grdcustomer.DataBind();
                 ViewState["CurrentData"] = null;
             }
             else
             {
                 //this.Response.End();

                 if (Session["home"] != null)
                 {
                     if (Session["home"].ToString() == "SA")
                     {
                         Response.Redirect("../Home/SalesHome.aspx");
                     }
                 }
                 else
                 {
                     this.Response.End();
                 }
             }
        }

        protected void cmbmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillMonthValues();
            txtbudunits.Text = "";
            txttype.Text = "";
            txtbudret.Text = "";
            txtcustomer.Text = "";
            txtport.Text = "";
            txtunits.Text = "";
            txtrentention.Text = "";
            btnsave.Text = "Save";
            btnsave.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            btnadd.Text = "Add";
            btnadd.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn ico-add";
            cmbmonth.Enabled = true;
            cmbyear.Enabled = true;
            cmbproduct.Enabled = true;
            txtbudunits.Enabled = true;
            txtbudret.Enabled = true;
            txttotrent.Text = "";
            txttotunit.Text = "";
        }

        private void FillMonthValues()
        {
            if (cmbmonth.SelectedItem.Text == "January")
            {
                intmonth = 1;
            }
            else if (cmbmonth.SelectedItem.Text == "Febraury")
            {
                intmonth = 2;
            }
            else if (cmbmonth.SelectedItem.Text == "March")
            {
                intmonth = 3;
            }
            else if (cmbmonth.SelectedItem.Text == "April")
            {
                intmonth = 4;
            }
            else if (cmbmonth.SelectedItem.Text == "May")
            {
                intmonth = 5;
            }
            else if (cmbmonth.SelectedItem.Text == "June")
            {
                intmonth = 6;
            }
            else if (cmbmonth.SelectedItem.Text == "July")
            {
                intmonth = 7;
            }
            else if (cmbmonth.SelectedItem.Text == "August")
            {
                intmonth = 8;
            }
            else if (cmbmonth.SelectedItem.Text == "September")
            {
                intmonth = 9;
            }
            else if (cmbmonth.SelectedItem.Text == "October")
            {
                intmonth = 10;
            }
            else if (cmbmonth.SelectedItem.Text == "November")
            {
                intmonth = 11;
            }
            else if (cmbmonth.SelectedItem.Text == "December")
            {
                intmonth = 12;
            }
        }

        private void BindGrid(int rowcount, string txtname,string volume,string port,string retn,int custid,int portid,int mid)
        {        
            try
            {
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add(new System.Data.DataColumn("customername", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("volume", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("portname", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("billamt", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("customerid", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("portid", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("mccid", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("totunit", typeof(int)));
                if (ViewState["CurrentData"] != null) 
                {
                    for (int i = 0; i < rowcount + 1; i++)
                    {
                        dt = (DataTable)ViewState["CurrentData"];

                        if (dt.Rows.Count > 0)
                        {
                            DataView dv = new DataView(dt);
                            dv.RowFilter = "customerid = '" + custid + "'" + " and " + "portid = '" + portid + "'";
                            if (dv.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('customer Already Exist');", true);
                                return;
                            }

                            dr = dt.NewRow();
                            dr[0] = dt.Rows[0][0].ToString();
                        }
                    }
                    dr = dt.NewRow();
                    dr[0] = txtname;
                    dr[1] = volume + " " + txttype.Text;
                    dr[2] = port;
                    dr[3] = retn;
                    dr[4] = custid;
                    dr[5] = portid;
                    dr[6] = mid;
                    dr[7] = volume;
                    dt.Rows.Add(dr);
                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = txtname;
                    dr[1] = volume + " " + txttype.Text;
                    dr[2] = port;
                    dr[3] = retn;
                    dr[4] = custid;
                    dr[5] = portid;
                    dr[6] = mid;
                    dr[7] = volume;
                    dt.Rows.Add(dr);

                }

                if (ViewState["CurrentData"] != null)
                {
                    grdcustomer.DataSource = (DataTable)ViewState["CurrentData"];
                    grdcustomer.DataBind();
                }
                else
                {
                    grdcustomer.DataSource = dt;
                    grdcustomer.DataBind();
                }
                ViewState["CurrentData"] = dt;
       
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            DataTable dtcnt = new DataTable();

            if (cmbmonth.SelectedItem == null || cmbmonth.SelectedItem.Text == "Month")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Select Month');", true);
                cmbmonth.Focus();
                return;
            }
            if (cmbyear.SelectedItem == null || cmbyear.SelectedItem.Text == "Year")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Select Year');", true);
                cmbyear.Focus();
                return;
            }
            if (cmbproduct.SelectedItem == null || cmbproduct.SelectedItem.Text == "Product")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Select Product');", true);
                cmbproduct.Focus();
                return;
            }
            if (txtbudunits.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Select Budget Unit');", true);
                txtbudunits.Focus();
                return;
            }
            if (txtbudret.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Select Budget Retention');", true);
                txtbudret.Focus();
                return;
            }

            FillMonthValues();

            bid = Convert.ToInt32(Session["LoginBranchid"].ToString());

            intyear = Convert.ToInt32(cmbyear.SelectedItem.Text);
            dtactualbillinv = budobj.GetRetntion4Lastyear(bid, intmonth, intyear);
            GetTrantypeVal();
            intsalesid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            if (dtactualbillinv.Rows.Count > 0)
            {
                for (int b = 0; b <= dtactualbillinv.Rows.Count - 1; b++)
                {
                    for (int p = 0; p <= grdcustomer.Rows.Count - 1; p++)
                    {
                        if (dtactualbillinv.Rows[i]["trantype"].ToString() == prod)
                        {
                            if (dtactualbillinv.Rows[i]["jobtype"].ToString() == jobtype)
                            {
                                if (dtactualbillinv.Rows[i]["subprod"].ToString() == subprod)
                                {
                                    actrentention = Convert.ToDouble(dtactualbillinv.Rows[i]["retention"].ToString());
                                    volume = Convert.ToDouble(dtactualbillinv.Rows[i]["volume"].ToString());
                                }
                            }
                        }
                    }
                }
            }


            txtbudunits.Enabled = false;
            txtbudret.Enabled = false;
            cmbmonth.Enabled = false;
            cmbyear.Enabled = false;
            cmbproduct.Enabled = false;
            Double totvol = 0, totamount = 0, totacbill = 0;
            dunit = 0;
            drentention = 0;

            #region Test 1
            //if (btnadd.Text == "Add")
            //{
            //    for (k = 0; k <= grdcustomer.Rows.Count - 1; k++)
            //    {
            //        if (grdcustomer.Rows[k].Cells[0].Text.Trim() != "Total")
            //        {
            //            dunit = dunit + Convert.ToDouble(grdcustomer.Rows[k].Cells[8].Text);
            //            drentention = drentention + Convert.ToDouble(grdcustomer.Rows[k].Cells[3].Text);
            //        }
            //    }
            //}
            //else
            //{
            //    for (k = 0; k <= grdcustomer.Rows.Count - 1; k++)
            //    {
            //        if (grdcustomer.Rows[k].Cells[0].Text.Trim() != "Total")
            //        {
            //            if (grdcustomer.Rows[k].Cells[0].Text.Trim() != txtcustomer.Text.Trim())
            //            {
            //                dunit = dunit + Convert.ToDouble(grdcustomer.Rows[k].Cells[8].Text);
            //                drentention = drentention + Convert.ToDouble(grdcustomer.Rows[k].Cells[3].Text);
            //            }
            //        }
            //    }
            //}
            #endregion


            //dunit = dunit + Convert.ToDouble(txtunits.Text);
            //drentention = drentention + Convert.ToDouble(txtrentention.Text);

            if (txtrentention.Text == "0")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Volume Must be More than 1');", true);
                txtrentention.Focus();
                return;
            }
            if (txtunits.Text == "0")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Billing Amount Must be More than 1');", true);
                txtunits.Focus();
                return;
            }

            if (txtbudunits.Text != "")
            {
                if (dunit > Convert.ToDouble(txtbudunits.Text))
                {
                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Unit is Exceeds Sales Unit amount');", true);
                    txtunits.Focus();
                    return;
                }
            }

            if (txtbudret.Text != "")
            {
                if (drentention > Convert.ToDouble(txtbudret.Text))
                {
                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Retention is Exceeds Sales Retention Volume');", true);
                    txtunits.Focus();
                    return;
                }
            }

            if (hf_portid.Value != "")
            {
                portid = Convert.ToInt32(hf_portid.Value);
            }
            if (HdnCusId.Value != "")
            {
                intcust = Convert.ToInt32(HdnCusId.Value);
            }
            
            DataTable dtport = new DataTable();           
            if (portid == 0)
            {
                dtport = portobj.RetrievePortnameDetails(txtport.Text);
                if (dtport.Rows.Count > 0)
                {
                        portid = Convert.ToInt32(dtport.Rows[0]["portid"].ToString());
                }
            }
            

            mccid = Convert.ToInt32(txt_city.Text);
            GetTrantypeVal();

            if (portid == 0)
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Invalid Port');", true);
                txtport.Focus();
                return;
            }

            dtcnt = budobj.getunittot(bid, intsalesid, intmonth, intyear, prod, jobtype, subprod);
            
            if (dtcnt.Rows.Count > 0)
            {
                if (btnadd.ToolTip == "Add")
                {
                    dunit = Convert.ToDouble(dtcnt.Rows[0]["volume"].ToString()) + Convert.ToDouble(txtunits.Text);
                    drentention = Convert.ToDouble(dtcnt.Rows[0]["billamt"].ToString()) + Convert.ToDouble(txtrentention.Text);
                }
                else
                {
                    dunit = Convert.ToDouble(dtcnt.Rows[0]["volume"].ToString())- Convert.ToInt32(hfunit .Value);
                    drentention = Convert.ToDouble(dtcnt.Rows[0]["billamt"].ToString())-Convert.ToDouble(hfret .Value );
                    dunit = dunit +  Convert.ToInt32(txtunits.Text);
                    drentention = drentention + Convert.ToDouble(txtrentention.Text);
                }

                if (Convert.ToDouble(txtbudunits.Text) == dunit)
                {
                   
                }
                else if (Convert.ToDouble(txtbudunits.Text) < dunit)
                {
                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Unit is Exceeds total Units');", true);
                    txtunits.Focus();
                    return;
                }
                if (Convert.ToDouble(txtbudret.Text) == drentention)
                {
                   
                }
                if (Convert.ToDouble(txtbudret.Text) < drentention)
                {
                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Unit is Exceeds Sales Unit amount');", true);
                    txtunits.Focus();
                    return;
                } 
            }

            DataTable dtuniq = new DataTable();

            if (btnadd.ToolTip != "Add")
            {

            }
            else
            {
                dtuniq = budobj.chkuniqbudgetcust(bid, Convert.ToInt32(Session["LoginEmpId"].ToString()), intmonth, intyear, prod, jobtype, subprod, intcust, portid);
            }
            if (dtuniq.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Customer Details Already Exists');", true);
                txtcustomer.Focus();
                return;
            } 
            //HdnCusId.Value = intcust.ToString();
            //hf_portid.Value = porid.ToString();

             //  dtcnt = budobj.getunittot(bid, intsalesid, intmonth, intyear, prod, jobtype, subprod);
             // intmonth, intyear, volume, intcust, portid, mccid);


            if (btnadd.ToolTip == "Add")
            {
                //budobj.InsCustomerBudget(bid, prod, jobtype, Convert.ToDouble(txtbudunits.Text), txttype.Text, Convert.ToDouble(txtbudret.Text), actrentention, DateTime.Now, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()), subprod, intmonth, intyear, volume, 0, 0, 0);

                budobj.InsCustomerBudget(bid, prod, jobtype, Convert.ToDouble(txtunits.Text), txttype.Text, Convert.ToDouble(txtrentention.Text),Convert.ToDouble(txtrentention.Text), DateTime.Now, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()), subprod, intmonth, intyear, volume, intcust, portid, mccid);

                //if (ViewState["CurrentData"] != null)
                //{
                //    DataTable dt = (DataTable)ViewState["CurrentData"];
                //    int count = dt.Rows.Count;
                //    BindGrid(count, txtcustomer.Text.ToUpper(), txtunits.Text, txtport.Text, txtrentention.Text, intcust, portid, mccid);
                //}
                //else
                //{
                //    BindGrid(1, txtcustomer.Text.ToUpper(), txtunits.Text, txtport.Text, txtrentention.Text, intcust, portid, mccid);
                //}

                txtcustomer.Text = "";
                txtport.Text = "";
                txtunits.Text = "";
                txtrentention.Text = "";
                txtcustomer.Enabled = true;
            }
            string volval;
            if (btnadd.ToolTip == "Update")
            {

                // budobj.UpdCustomerBudget(bid, prod, jobtype, Convert.ToDouble(txtbudunits.Text), txttype.Text, Convert.ToDouble(txtbudret.Text), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()), subprod, intmonth, intyear, 0, 0, 0);


                //Dt = obj_md.SelectMasterdepartment4DeptName(str_DeptName, int_customerid);

                //if (Dt.Rows.Count > 0)
                //{
                //    ScriptManager.RegisterStartupScript(btndeptupdate, typeof(Button), "DataFound", "alertify.alert('Department Name Already Found');", true);
                //    txtdept.Focus();
                //}
                //else
                //{
                //    obj_md.UpdateMasterDepartment(int_DeptId, str_DeptName, str_Remarks, int_customerid, str_deleted);
                //    obj_md.InsertDeptLogDetails(Convert.ToInt32(Session["UserID"].ToString()), "UPDATE", hf_DeptName.Value.ToString() + " --" + hf_Remarks.Value.ToString(), int_DeptId, str_DeptName + " -- " + str_Remarks, int_customerid);
                //    ScriptManager.RegisterStartupScript(btndeptupdate, typeof(Button), "DataFound", "alertify.alert('Department Updated Successfully');", true);
                //    ClearAll();
                //}
                if (hf_portid.Value != "")
                {
                    portid = Convert.ToInt32(hf_portid.Value);
                }
                

                budobj.DelBudgetcustomernew(bid, intmonth, intyear, intsalesid, intcust, prod, jobtype, mccid, portid);
                //budobj.InsCustomerBudget(bid, prod, jobtype, Convert.ToDouble(grdcustomer.Rows[i].Cells[8].Text), txttype.Text, Convert.ToDouble(grdcustomer.Rows[i].Cells[3].Text), actrentention, DateTime.Now, Convert.ToInt32(Session["LoginEmpId"].ToString()),
                //    Convert.ToInt32(Session["LoginEmpId"].ToString()), subprod, intmonth, intyear, volume, Convert.ToInt32(grdcustomer.Rows[i].Cells[4].Text), Convert.ToInt32(grdcustomer.Rows[i].Cells[5].Text), Convert.ToInt32(grdcustomer.Rows[i].Cells[6].Text));

               // budobj.InsCustomerBudget(bid, prod, jobtype, Convert.ToDouble(txtbudunits.Text), txttype.Text, Convert.ToDouble(txtbudret.Text), actrentention, DateTime.Now, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()), subprod, intmonth, intyear, volume, intcust, portid, mccid);

                budobj.InsCustomerBudget(bid, prod, jobtype, Convert.ToDouble(txtunits.Text), txttype.Text, Convert.ToDouble(txtrentention.Text), Convert.ToDouble(txtrentention.Text), DateTime.Now, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()), subprod, intmonth, intyear, volume, intcust, portid, mccid);
                
                //for (i = 0; i <= grdcustomer.Rows.Count - 1; i++)
                //{
                //    if (intcust == Convert.ToInt32(grdcustomer.Rows[i].Cells[4].Text) && portid == Convert.ToInt32(grdcustomer.Rows[i].Cells[5].Text))
                //    {
                //        getamt = Convert.ToSingle(txtunits.Text);
                //        grdcustomer.Rows[i].Cells[8].Text = txtunits.Text;
                //        grdcustomer.Rows[i].Cells[2].Text = getamt + " " + txttype.Text;

                //        totvol = totvol + Convert.ToDouble(txtunits.Text);
                //        volval = txtrentention.Text;
                //        volval = Convert.ToDecimal(volval).ToString("#,0.00");
                //        grdcustomer.Rows[i].Cells[3].Text = volval;

                //        totamount = totamount + Convert.ToDouble(txtrentention.Text);
                //        grdcustomer.Rows[i].Cells[5].Text = hf_portid.Value;
                //        grdcustomer.Rows[i].Cells[1].Text = txtport.Text;   
                //    }
                //}
                btnadd.ToolTip = "Add";
            }

            totvol = 0;
            totamount = 0;

            //for (k = 0; k <= grdcustomer.Rows.Count - 1; k++)
            //{
            //    if (grdcustomer.Rows[k].Cells[0].Visible == true)
            //    {
            //        volval = grdcustomer.Rows[k].Cells[8].Text;
            //        totvol = totvol + Convert.ToDouble(volval);
            //        totamount = totamount + Convert.ToDouble(grdcustomer.Rows[k].Cells[3].Text);
            //        getamt = Convert.ToSingle(totvol);
            //        txttotunit.Text = getamt.ToString();
            //        txttotrent.Text = totamount.ToString("#,0.00");
            //    }
            //}

            txtcustomer.Text = "";
            txtport.Text = "";
            txtunits.Text = "";
            txtrentention.Text = "";
            txtcustomer.Enabled = true;
            txtport.Enabled = true;
            btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

            display();
        }


        protected void btnsave_Click(object sender, EventArgs e)
        {
            
            FillMonthValues();
           
            bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
           
            intyear = Convert.ToInt32(cmbyear.SelectedItem.Text);
            dtactualbillinv = budobj.GetRetntion4Lastyear(bid, intmonth, intyear);
            GetTrantypeVal();
            intsalesid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            if(dtactualbillinv.Rows.Count > 0 )
            {
                for (int b = 0; b <= dtactualbillinv.Rows.Count - 1; b++)
                {
                    for (int p = 0; p <= grdcustomer.Rows.Count - 1; p++)
                    {
                        if(dtactualbillinv.Rows[i]["trantype"].ToString() == prod)
                        {
                            if(dtactualbillinv.Rows[i]["jobtype"].ToString() == jobtype )
                            {
                                if( dtactualbillinv.Rows[i]["subprod"].ToString() == subprod)
                                {
                                    actrentention = Convert.ToDouble(dtactualbillinv.Rows[i]["retention"].ToString());
                                    volume = Convert.ToDouble(dtactualbillinv.Rows[i]["volume"].ToString());
                                }
                            }
                        }
                    }
                }
            }

            Check();
            if(check==1)
            {
                return;
            }
            if (btnsave.ToolTip == "Save")
            {
                budobj.InsCustomerBudget(bid, prod, jobtype, Convert.ToDouble(txtbudunits.Text), txttype.Text, Convert.ToDouble(txtbudret.Text), actrentention, DateTime.Now, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()), subprod, intmonth, intyear, volume, 0, 0, 0);

                //for (i = 0; i <= grdcustomer.Rows.Count - 1; i++)
                //{
                //    budobj.InsCustomerBudget(bid, prod, jobtype, Convert.ToDouble(grdcustomer.Rows[i].Cells[8].Text), txttype.Text, Convert.ToDouble(grdcustomer.Rows[i].Cells[3].Text), actrentention, DateTime.Now, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()), subprod, intmonth, intyear, volume,Convert.ToInt32(grdcustomer.Rows[i].Cells[4].Text),Convert.ToInt32(grdcustomer.Rows[i].Cells[5].Text),Convert.ToInt32(grdcustomer.Rows[i].Cells[6].Text));
                //}
                //LogObj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1745, 1, bid, "Budget/S-" + prod + "-" + jobtype + "-" + txtbudret.Text + intmonth + intyear);
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Please Update Budget details customer wise');", true);
                LogObj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1733,1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtcustomer.Text + "save");
                btncancel.Text = "Cancel";
                btncancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                btnsave.Text = "Update";
                btnsave.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                //rakshu
                cmbmonth.Enabled = false;
                cmbyear.Enabled = false;
                cmbproduct.Enabled = false;
                txtbudunits.Enabled = false;
                txttype.Enabled = false;
                txtbudret.Enabled = false;
                //txtbudunits.Enabled = true;
                //txtbudret.Enabled = true;
                txtcustomer.Enabled = true;
                txtport.Enabled = true;
                txtunits.Enabled = true;
                txtrentention.Enabled = true;
                btnadd.Enabled = true;
                //clear();
            }
            else if (btnsave.ToolTip == "Update")
            {
                Double a, b;
                getamt =Convert.ToSingle(txtbudunits.Text);
                txtbudunits.Text = getamt.ToString();
                a = Convert.ToDouble(txtbudunits.Text);
                b = Convert.ToDouble(txtbudret.Text);
                txtbudret.Text = b.ToString("#,0.00");
                b = Convert.ToDouble(txtbudret.Text);

                if(Convert.ToDouble(txtbudunits.Text) < Convert.ToDouble(txttotunit.Text))
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Unit is Exceeds Sales Unit amount');", true);
                    txtbudunits.Focus();
                    return;
                }

                if (Convert.ToDouble(txtbudret.Text) < Convert.ToDouble(txttotrent.Text))
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Retention is Exceeds Sales Retention amount');", true);
                    txtbudret.Focus();
                    return;
                }

                budobj.UpdCustomerBudget(bid, prod, jobtype,Convert.ToDouble(txtbudunits.Text), txttype.Text, Convert.ToDouble(txtbudret.Text), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()), subprod, intmonth, intyear, 0, 0, 0);
                //for (i = 0; i <= grdcustomer.Rows.Count - 1; i++)
                //{
                //    budobj.DelBudgetcustomernew(bid, intmonth, intyear, intsalesid, Convert.ToInt32(grdcustomer.Rows[i].Cells[4].Text), prod, jobtype, Convert.ToInt32(grdcustomer.Rows[i].Cells[6].Text));
                //    budobj.InsCustomerBudget(bid,prod,jobtype,Convert.ToDouble(grdcustomer.Rows[i].Cells[8].Text),txttype.Text, Convert.ToDouble(grdcustomer.Rows[i].Cells[3].Text),actrentention,DateTime.Now,Convert.ToInt32(Session["LoginEmpId"].ToString()),
                //        Convert.ToInt32(Session["LoginEmpId"].ToString()),subprod,intmonth,intyear,volume,Convert.ToInt32(grdcustomer.Rows[i].Cells[4].Text),Convert.ToInt32(grdcustomer.Rows[i].Cells[5].Text), Convert.ToInt32(grdcustomer.Rows[i].Cells[6].Text));
                //}

                LogObj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1733,2, bid, "Budget/U-" + prod + "-" + jobtype + "-" + txtbudret.Text + intmonth + intyear);
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Budget Details Updated');", true);
                btnsave.Text = "Save";
                btnsave.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                btnsave.Enabled = false;
                clear();
            }
            btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";            
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtbudret_TextChanged(object sender, EventArgs e)
        {
            if(txtbudunits.Text != "" && txtbudret.Text != "" )
            {
                txtcustomer.Enabled = true;
                txtport.Enabled = true;
                txtunits.Enabled = true;
                txtrentention.Enabled = true;
                btnadd.Enabled = true;
                
            }
            else
            {
                txtcustomer.Enabled = false;
                txtport.Enabled = false;
                txtunits.Enabled = false;
                txtrentention.Enabled = false;
                btnadd.Enabled = false;
            }      
        }

        protected void ImageButton2_Click(object sender, EventArgs e)
        {
            ImageButton lb = (ImageButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int index = gvRow.RowIndex;
            intcust = Convert.ToInt32(grdcustomer.Rows[index].Cells[4].Text);
            string volvalnew;
            double totvolnew = 0, totamountnew =0;
            DataTable dtempty = new DataTable();
            bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            intyear = Convert.ToInt32(cmbyear.SelectedItem.Text);
            intsalesid = Convert.ToInt32(Session["LoginEmpId"].ToString());

            if (hdnDelete.Value == "true")
            {
                //for (int b = 0; b <= grdcustomer.Rows.Count - 1; b++)
                //{
                //    if (intcust == Convert.ToInt32(grdcustomer.Rows[b].Cells[4].Text))
                //    {
                        
                //    }
                //}
                FillMonthValues();
                GetTrantypeVal();
                mccid = Convert.ToInt32(grdcustomer.Rows[index].Cells[6].Text);
                porid = Convert.ToInt32(grdcustomer.Rows[index].Cells[5].Text);
                budobj.DelBudgetcustomernew(bid, intmonth, intyear, intsalesid, intcust, prod, jobtype, mccid, porid);
               // display();
               DataTable objdt = new DataTable();
               objdt = (DataTable)ViewState["CurrentData"];
               objdt.Rows[gvRow.RowIndex].Delete();
               objdt.AcceptChanges();

               grdcustomer.DataSource = objdt;
               grdcustomer.DataBind();

               DataTable dtcnt = new DataTable();
               dtcnt = budobj.getunittot(bid, intsalesid, intmonth, intyear, prod, jobtype, subprod);

               if (dtcnt.Rows.Count > 0)
               {
                   //txttotunit.Text = dtcnt.Rows[0]["volume"].ToString();
                   //txttotrent.Text = dtcnt.Rows[0]["billamt"].ToString();

                   txttotunit.Text = Convert.ToSingle(dtcnt.Rows[0]["volume"].ToString()) + " " + txttype.Text.Trim();
                   txttotrent.Text = Convert.ToDouble(dtcnt.Rows[0]["billamt"]).ToString("#,0.00");
               }
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.TextBox), "Budget Customer", "alertify.alert('Details Deleted');", true);
                txtcustomer.Text = "";
                txtport.Text = "";
                txtunits.Text = "";
                txtrentention.Text = "";
                ViewState["CurrentData"] = objdt;
                btnadd.Text = "Add";
                btnadd.ToolTip = "Add";
                btn_add1.Attributes["class"] = "btn ico-add";
            }
            else
            {
                string unitrpl;

                txtcustomer.Text = grdcustomer.Rows[index].Cells[0].Text.Replace("&amp;", "&");            
             
                txtport.Text = grdcustomer.Rows[index].Cells[1].Text;
               txtunits.Text = grdcustomer.Rows[index].Cells[7].Text;

                txtrentention.Text = grdcustomer.Rows[index].Cells[3].Text;

                hfunit.Value = grdcustomer.Rows[index].Cells[7].Text;
                hfret.Value = grdcustomer.Rows[index].Cells[3].Text;
                porid = Convert.ToInt32(grdcustomer.Rows[index].Cells[5].Text);
                intcust = Convert.ToInt32(grdcustomer.Rows[index].Cells[4].Text);
                mccid = Convert.ToInt32(grdcustomer.Rows[index].Cells[6].Text);
                HdnCusId.Value = intcust.ToString();
                hf_portid.Value = porid.ToString();
                txt_city.Text = mccid.ToString();
                btnadd.Text = "Update";
                btnadd.ToolTip = "Update";
                btn_add1.Attributes["class"] = "btn ico-Update";
                txtcustomer.Enabled = false;
                txtport.Enabled = false;
            }
            btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

       
        protected void grdcustomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text == "&nbsp;")
                {
                    e.Row.Cells[i].Text = "";
                }
                e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdcustomer, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }

        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            string str_sp = ""; 
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";

            FillMonthValues();
            str_RptName = "BudgetDetails.rpt";
            str_sf = "{MasterBranch.branchid}=" + Session["LoginBranchid"].ToString() + " and {MasterBudget.salesid}=" + Session["LoginEmpId"].ToString() + " and {MasterBudget.bgtmonth}=" + intmonth + " and {MasterBudget.bgtyear}=" + cmbyear.Text;          
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";          
            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Budget Customer", str_Script, true);
            LogObj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1733,3, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtcustomer.Text + "view");

            Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;            
        }

        protected void grdcustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdcustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
              
        }

        protected void txtcustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                // dt_cust = Cusobj.GetLikeCustomer(txtCarrier.Text.Trim().ToUpper());
                int txtcustomerid = da_obj_Customer.GetCustomerid((txtcustomer.Text.Trim().ToUpper()));
                if (txtcustomerid != 0)
                {
                    txtport.Focus();
                }
                else
                {
                    txtcustomer.Text = "";
                    txtcustomer.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Customer');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtport_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (portobj.GetNPortid(txtport.Text.Trim().ToUpper()) != 0)
                {
                    txtunits.Focus();
                }
                else
                {
                    txtport.Text = "";
                    txtport.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Port');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }            
        }

        protected void grdcustomer_PreRender(object sender, EventArgs e)
        {
            if (grdcustomer.Rows.Count > 0)
            {
                grdcustomer.UseAccessibleHeader = true;
                grdcustomer.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }


    }

}