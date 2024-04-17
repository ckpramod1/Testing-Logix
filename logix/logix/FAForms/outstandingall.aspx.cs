using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Text;
using ClosedXML.Excel;
using System.Web.Services.Description;


namespace logix.FAForms
{
    public partial class outstandingall : System.Web.UI.Page
    {
        DateTime time = new DateTime();
        Boolean YesterDayData = true;
        Boolean flag = true;
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        DataAccess.Outstanding sobj1 = new DataAccess.Outstanding();
        DataTable dtage = new DataTable();
        DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
        DataAccess.Outstanding outsobj = new DataAccess.Outstanding();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        int sgroupid = 0;
        int customerid = 0;
        int saleid = 0;
        DataTable dt = new DataTable();
        int Time;
        DataView dv = new DataView();
        DataTable dtl = new DataTable();
        DataTable dtcustomer = new DataTable();
        DataTable dtsales = new DataTable();
        Double amt = 0.0, overdue = 0.0, appamt = 0.0;
        DateTime Date = new DateTime();
        string sgname;
        int lid;
        int check = 1;
        DataTable dtvou;
        DataTable dtemptynew = new DataTable();
        int selectedRowIndex;
        int selectedColumnIndex;
        int VouYear;
        String Branch;
        String Product;
        String VouType;
        int Vou;
        String vdate;

        String BL;
        String Salesperson;
        String Ledger;
        Double amoun;
        int NoofDays;
        Double amtt;
        int appday;

        Double overdue1;
        int overdays;
        String shipper;
        String por;
        String pol;
        String pod;
        String Shipment;
        Double volume;
        string customer, Email;
        Double data1, data2, data3, data4, data5, data6, data7, data8, data9, ledgerbalance, data10;
        string phone, Address;
        int empid;
        int Vouyear, LogYear;
        string FADbname = "";
        DataAccess.FAMaster.ReportView da_obj_rv = new DataAccess.FAMaster.ReportView();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_Log.GetDataBase(Ccode);
                sobj1.GetDataBase(Ccode);
                HREmpobj.GetDataBase(Ccode);
                outsobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                da_obj_rv.GetDataBase(Ccode);
               

            }

            try
            {
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnClear);
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnExpertExcel);

                if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
                }

                Vouyear = Convert.ToInt32(Session["Vouyear"].ToString());
                LogYear = Convert.ToInt32(Session["LogYear"].ToString());
                int stryear = Convert.ToInt32(DateTime.Now.Year.ToString());
                FADbname = Session["FADbname"].ToString();
                if (!IsPostBack)
                {
                    hid_groupid.Value = "";
                    //txtLedger.TextChanged += new EventHandler(txtLedger.TextChanged);
                    GrdLW.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                    hdf_idsales.Value = "0";
                    GrdLW.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdLW.DataBind();
                    lst.Visible = false;
                    DropDownList1.Visible = false;
                    DropDownList2.Visible = false;
                    lnk_back.Visible = false;
                    cboxLedgerAgeing.Enabled = false;
                    cboxSalesAgeing.Enabled = false;
                    ddlbranch.Enabled = false;
                    ddlProduct.Enabled = false;
                    txtSalesPerson.Enabled = false;
                    txtLedger.Enabled = false;
                    ddlcurency.Enabled = false;



                    DataTable dtempty = new DataTable();
                    if (dtempty.Rows.Count > 0)
                    {
                        grdvou.Visible = true;
                        grdvou.DataSource = dtempty;
                        grdvou.DataBind();
                    }
                    //txtSubGroupName.Text = "All";

                    Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
                    string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
                    DateTime Date = da_obj_rv.MaxVouGetDate(Session["FADbname"].ToString());

                    if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month <=3) || Vouyear == (DateTime.Now).Year)
                    {
                        txt_date.Text = Utility.fn_ConvertDate(da_obj_Log.GetDate().ToString()); //da_obj_Log.GetDate().ToShortDateString();
                    }
                    else
                    {
                        txt_date.Text = Utility.fn_ConvertDate("3/31/" + (Vouyear + 1));
                    }
                }

                lnk_back.Visible = false;
                btnClear.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                Time = da_obj_Log.GetDate().Hour;
                //Date = da_obj_Log.GetDate();
                hid_date.Value = txt_date.Text;


            }
            catch (Exception ex)
            {
                //Session["Error"] = lblOutstanding.Text + ex.Message.ToString();
                //Response.Redirect("ErrorPage.aspx");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alter('" + ex.Message.ToString() + "')", true);
            }
        }

        [WebMethod]
        public static List<string> Getcustomer(string prefix)
        {
            List<string> customername = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.FAMaster.MasterSubGroup sobj = new DataAccess.FAMaster.MasterSubGroup();
            string FADbname = HttpContext.Current.Session["FADbname"].ToString();
            obj_dt = sobj.GetLikesubGroupname4outstd(prefix.ToUpper(), FADbname);
            customername = Utility.Fn_DatatableToList(obj_dt, "subgroupname", "subgroupid");
            return customername;
        }


        [WebMethod]
        public static List<string> Gettxtcustomer(string prefix)
        {
            List<string> customername = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

            obj_dt = (DataTable)HttpContext.Current.Session["customer"];
            DataView dt_ldg = new DataView(obj_dt);
            dt_ldg.RowFilter = "customer like '" + prefix.ToUpper() + "%'";

            obj_dt = dt_ldg.ToTable();
            if (obj_dt.Rows.Count > 0)
            {
                for (int i = 0; i < obj_dt.Rows.Count; i++)
                {
                    if (obj_dt.Rows[i][1].ToString() != "")
                        customername = Utility.Fn_DatatableToList(obj_dt, "customer", "customerid");
                }
            }

            return customername;
        }

        [WebMethod]
        public static List<string> Gettxtsales(string prefix)
        {
            List<string> customername = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            obj_dt = (DataTable)HttpContext.Current.Session["Sales"];
            DataView dt_ldg = new DataView(obj_dt);
            dt_ldg.RowFilter = "salesname like '" + prefix.ToUpper() + "%'";

            obj_dt = dt_ldg.ToTable();
            if (obj_dt.Rows.Count > 0)
            {
                for (int i = 0; i < obj_dt.Rows.Count; i++)
                {
                    if (obj_dt.Rows[i][1].ToString() != "")
                    {
                        customername = Utility.Fn_DatatableToList(obj_dt, "salesname", "salesid");
                    }
                }
            }
            return customername;
        }

        //protected void txtSubGroupName_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        sgroupid = 0;
        //        txtSubGroupName.Text = "All";
        //        txtSubGroupName.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}

        protected void btnClear_Click(object sender, EventArgs e)
        {
            if (btnClear.ToolTip == "Cancel")
            {
                // txtSubGroupName.Text = "";
                               
                ddl_groupname.SelectedIndex = -1;
                txt_workprocess.Text = "";
                txtSalesPerson.Text = "";
                txtLedger.Text = "";
                txtLedger.Enabled = false;
                ddlProduct.SelectedIndex = -1;
                ddlbranch.SelectedIndex = -1;
                GrdLW.DataSource = Utility.Fn_GetEmptyDataTable();
                GrdLW.DataBind();
                GrdLW.Visible = true;
                grdvou.Visible = false;
                GrdAgeing.Visible = false;
                GrdAgeingsales.Visible = false;
                cboxLedgerAgeing.Enabled = false;
                cboxSalesAgeing.Enabled = false;

                cboxLedgerAgeing.Checked = false;
                cboxSalesAgeing.Checked = false;
                ChkTill.Checked = false;
                btnClear.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                //ddlcurency.Items.Clear();
                ddlcurency.SelectedIndex = -1;

                ViewState["dt1"] = null;
                ViewState["SalesPerson"] = null;
                ViewState["GrdAgeing"] = null;
            }
            else
            {
                this.Response.End();
            }
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                int groupid = 0;
                string subgroupid = "";
                //if (txtSubGroupName.Text == "")
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter SubGroupName');", true);
                //    return;
                //}

                if (ddl_groupname.SelectedItem.Text == "ALL")
                {

                    groupid = 0;
                    subgroupid = "0";
                }
                else if (ddl_groupname.SelectedItem.Text != "ALL" && txt_workprocess.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "btnget", "alertify.alert('Kindly select Subgroupname');", true);
                    txt_workprocess.Focus();
                    return;
                }
                else if (ddl_groupname.SelectedItem.Text != "ALL" && txt_workprocess.Text != "")
                {
                    groupid = Convert.ToInt32(hd_groupid.Value);
                    subgroupid = hd_subgroupid.Value;

                }
                ddlProduct.SelectedIndex = -1;
                ddlbranch.SelectedIndex = -1;
                ddlcurency.SelectedIndex = -1;

                int ledgerid = 0;

                // sgroupid = Convert.ToInt32(hdf_id.Value);
                // sgroupid = 0;
                Time = da_obj_Log.GetDate().Hour;
                flag = true;
                dwb_Clear();
                dt = new DataTable();
                Date = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)); //da_obj_Log.GetDate(); 
               // DataAccess.FAMaster.MasterSubGroup sobj = new DataAccess.FAMaster.MasterSubGroup();
                DataTable obj_dt = new DataTable();

                int Tillyear;
                if (Date.Month <= 3)
                {
                    Tillyear = (Date.Year) - 1;
                }
                else
                {
                    Tillyear = (Date.Year);
                }

                if (Tillyear > 2013)
                {

                    //if (Session["LoginBranchName"].ToString() == "CORPORATE")
                    //{
                    //    dt = outsobj.OutStandingCheckUSD(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(hdf_id.Value), Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)));
                    //}
                    //else

                    if (Session["LoginBranchName"].ToString() == "CORPORATE")
                    {
                        if (ChkTill.Checked == true)
                        {
                            dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                        }
                        else
                        {
                            if (hid_date.Value == Utility.fn_ConvertDate("3/31/" + (LogYear + 1)) || hid_date.Value != Utility.fn_ConvertDate(da_obj_Log.GetDate().ToString()))
                            {
                                ChkTill.Checked = true;
                                dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                            }
                            else
                            {
                                dt = outsobj.OutStandingNewLedgerall(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), subgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), ledgerid, groupid);
                                //dt = outsobj.OutStandingNewonlineformat(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                            }
                        }
                    }
                    else
                    {
                        if (ChkTill.Checked == true)
                        {
                            dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                        }
                        else
                        {
                            //DateTime timecon = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text));
                            //if (timecon == Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)))
                            //{
                            if (hid_date.Value == Utility.fn_ConvertDate("3/31/" + (LogYear + 1)) || hid_date.Value != Utility.fn_ConvertDate(da_obj_Log.GetDate().ToString()))
                            {
                                ChkTill.Checked = true;
                                dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                            }
                            else
                            {
                                // dt = outsobj.OutStandingNewBranch(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                // dt = outsobj.OutStandingNewonlineformat(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                                dt = outsobj.OutStandingNewLedger(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), ledgerid);
                            }
                        }
                    }
                }
                else
                {
                    dt = outsobj.OutStdingGET2013(99999, Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid);
                }

                Session["Data"] = dt;
                if (dt.Rows.Count > 0)
                {
                    GrdLW.Enabled = true;
                    ddlProduct.Enabled = true;
                    txtLedger.Enabled = true;
                    txtSalesPerson.Enabled = true;
                    GrdAgeing.Visible = false;
                    cboxLedgerAgeing.Enabled = true;
                    cboxLedgerAgeing.Checked = false;
                    cboxSalesAgeing.Enabled = true;
                    cboxSalesAgeing.Checked = false;
                    dv = new DataView(dt);
                    dtl = new DataTable();
                    string[] a = new string[2];
                    a[0] = "shortname";
                    a[1] = "bid";
                    dtl = dv.ToTable("name", true, a);
                    if (dtl.Rows.Count > 0)
                    {
                        ddlbranch.Items.Add("Branch");
                        if ((Session["LoginBranchName"].ToString()) == "CORPORATE")
                        {
                            ddlbranch.Items.Add("ALL");
                            ddlbranch.Enabled = true;
                        }
                        for (int i = 0; i <= dtl.Rows.Count - 1; i++)
                        {
                            if ((Session["LoginBranchName"].ToString()) == "CORPORATE")
                            {
                                ddlbranch.Items.Add(dtl.Rows[i]["shortname"].ToString());
                            }
                            else
                            {
                                if (Convert.ToInt32(Session["LoginBranchid"].ToString()) == Convert.ToInt32(dtl.Rows[i]["bid"].ToString()))
                                {
                                    ddlbranch.Items.Add(dtl.Rows[i]["shortname"].ToString());
                                    ddlbranch.SelectedItem.Text = dtl.Rows[i]["shortname"].ToString();
                                    //ddlbranch_SelectedIndexChanged(sender, e);
                                }
                            }
                        }


                    }

                    if (Session["LoginBranchName"].ToString() != "CORPORATE")
                    {
                        ddlbranch.Enabled = false;
                    }

                    string[] b = new string[1];
                    b[0] = "trantype";
                    dtl = new DataTable();
                    dtl = dv.ToTable("name", true, b);
                    ddlProduct.Items.Add("Product");
                    if (dtl.Rows.Count > 0)
                    {
                        ddlProduct.Items.Add("ALL");

                        for (int i = 0; i <= dtl.Rows.Count - 1; i++)
                        {
                            if ((dtl.Rows[i]["trantype"].ToString()) != "")
                            {
                                ddlProduct.Items.Add(dtl.Rows[i]["trantype"].ToString());
                            }
                        }
                    }

                    string[] c = new string[2];
                    c[0] = "customerid";
                    c[1] = "customer";

                    dtcustomer = new DataTable();
                    dtcustomer = dv.ToTable("name", true, c);
                    Session["customer"] = dtcustomer;
                    DataRow drc = dtcustomer.NewRow();
                    drc["customerid"] = 0;
                    drc["customer"] = "ALL";
                    dtcustomer.Rows.Add(drc);

                    string[] d = new string[2];
                    d[0] = "salesid";
                    d[1] = "salesname";
                    dtsales = new DataTable();
                    dtsales = dv.ToTable("name", true, d);
                    Session["Sales"] = dtsales;
                    DataRow drs = dtsales.NewRow();
                    drs["salesid"] = 0;
                    drs["salesname"] = "ALL";
                    dtsales.Rows.Add(drs);

                    string[] z = new string[1];
                    z[0] = "fcurr";

                    dtl = new DataTable();
                    dtl = dv.ToTable("name", true, z);
                    // ddlcurency.Items.Clear();
                    ddlcurency.Enabled = true;
                    ddlcurency.Items.Add("ALL");
                    if (dtl.Rows.Count > 0)
                    {
                        ///ddlcurency.Items.Add("Curr");
                        //ddlcurency.Items.Clear();


                        for (int i = 0; i <= dtl.Rows.Count - 1; i++)
                        {
                            if ((dtl.Rows[i]["fcurr"].ToString()) != "")
                            {
                                if (dtl.Rows[i]["fcurr"].ToString() == "INR")
                                {
                                    //ddlcurency.Items.Clear();
                                    //ddlcurency.Enabled = false;
                                    //break;
                                }
                                else
                                {
                                    ddlcurency.Enabled = true;

                                }
                                ddlcurency.Items.Add(dtl.Rows[i]["fcurr"].ToString());
                            }
                        }
                    }
                    //subgroupname   

                    //ddlcurency.SelectedIndex = 1;

                    if (Session["LoginBranchName"].ToString() != "CORPORATE")
                    {
                        ddlbranch.Enabled = false;
                        GrdLW.Enabled = true;
                       
                        GridFilter();
                        //if (GrdLW.Rows.Count > 0)
                        //{
                        //    GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[7].ForeColor = System.Drawing.Color.Maroon;
                        //    GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                        //    GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[9].ForeColor = System.Drawing.Color.Maroon;
                        //    GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
                        //    GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[11].ForeColor = System.Drawing.Color.Maroon;
                        //    GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[12].ForeColor = System.Drawing.Color.Maroon;
                        //    GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[13].ForeColor = System.Drawing.Color.Maroon;
                        //}
                        //get_Ledger_filter();
                        return;
                    }
                    amt = 0;
                    overdue = 0;
                    DataTable dt1 = new DataTable();
                    dt1 = dt;
                    DataRow dr = dt1.NewRow();
                    dr["curr"] = "Total";
                    dr["amount"] = dt1.Compute("sum(amount)", "");

                    dr["vamount"] = dt1.Compute("sum(vamount)", "");
                    dr["Receivedamount"] = dt1.Compute("sum(Receivedamount)", "");
                    dr["famount"] = dt1.Compute("sum(famount)", "");

                    dr["recefamount"] = dt1.Compute("sum(recefamount)", "");
                    dr["foverdue"] = dt1.Compute("sum(foverdue)", "");
                   // dt1.Rows.Add(dr);
                    dt1.Rows.Add(dr);
                    //GC.Collect();
                    GrdLW.DataSource = dt1;
                    GrdLW.DataBind();
                    //dt1.Dispose();                    

                    //if (GrdLW.Rows.Count > 0)
                    //{
                    //    GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[7].ForeColor = System.Drawing.Color.Maroon;
                    //    GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                    //    GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[15].ForeColor = System.Drawing.Color.Maroon;
                    //    GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[9].ForeColor = System.Drawing.Color.Maroon;

                    //    //if(sgroupid == 65 || sgroupid == 59 || sgroupid == 44)
                    //    //{
                    //    //    ddlcurency.SelectedItem.Text = "USD";
                    //    //    GridFilter();
                    //    //}
                    //}
                    //else
                    //{
                    //    GrdLW.DataSource = Utility.Fn_GetEmptyDataTable();
                    //    GrdLW.DataBind();
                    //}
                    ViewState["dt1"] = dt1;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

                //Session["Error"] = lblOutstanding.Text + ex.Message.ToString();
                //Response.Redirect("ErrorPage.aspx");
            }

            int Emp_ID = Convert.ToInt32(Session["LoginEmpId"]);
            int BranchId = Convert.ToInt32(Session["LoginBranchid"].ToString());
            if (Session["str_ModuleName"] == "FA")
            {
                da_obj_Log.InsLogDetail(Emp_ID, 1926, 3, BranchId, "/V");
            }
            else
            {
                da_obj_Log.InsLogDetail(Emp_ID, 1926, 3, BranchId, "/V");
            }



        }

        private void dwb_Clear()
        {
            //ddlbranch.SelectedIndex = 0;
            //ddlProduct.SelectedIndex = 0;
            //ddlcurency.SelectedIndex = 0;
            ddlbranch.Items.Clear();
            ddlProduct.Items.Clear();
            ddlcurency.Items.Clear();
        }

        protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int branch = 0;
                sgroupid = Convert.ToInt32(hdf_id.Value);
                if (ddlbranch.SelectedIndex != -1)
                {
                    if (flag == false && cboxSalesAgeing.Checked == true)
                    {
                        if (ddlbranch.SelectedItem.Text == "ALL")
                        {
                            dtage = outsobj.OutStdageingNew(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 0, sgroupid, HttpContext.Current.Session["FADbname"].ToString(), customerid);
                            GrdLW.DataSource = dtage;
                            GrdLW.DataBind();

                            ViewState["dt1"] = dtage;
                        }
                        else
                        {
                            branch = HREmpobj.GetBId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), ddlbranch.SelectedItem.Text);
                            dtage = outsobj.OutStdageingNew(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, HttpContext.Current.Session["FADbname"].ToString(), customerid);
                            // dtage = outsobj.OutStdageingNew(Login.logempid, Login.divisionid, branch, sgroupid, Login.FADbname, customerid)
                            GrdLW.DataSource = dtage;
                            GrdLW.DataBind();

                            ViewState["dt1"] = dtage;
                        }

                    }
                    else if (flag == true)
                    {
                        GridFilter();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void cboxLedgerAgeing_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Date = da_obj_Log.GetDate();
                Time = Date.Hour;
                int Tillyear;

                if (cboxLedgerAgeing.Checked == true)//|| Request.QueryString["FlgValue"].ToString() == "true"
                {
                    flag = false;
                    GrdLW.Visible = false;
                    ddlbranch.Enabled = false;
                    ddlProduct.Enabled = false;
                    DropDownList1.Enabled = false;
                    DropDownList2.Enabled = false;
                    txtLedger.Enabled = false;
                    GrdAgeing.Visible = true;
                    GrdAgeingsales.Visible = false;
                    txtSalesPerson.Enabled = false;
                    txtLedger.Enabled = false;
                    ddlcurency.Enabled = false;

                    cboxSalesAgeing.Checked = false;
                    int branch = 0;

                    if (Date.Month <= 3)
                    {
                        Tillyear = (Date.Year) - 1;
                    }
                    else
                    {
                        Tillyear = (Date.Year);
                    }
                    if (hf_custname.Value == "" || txtLedger.Text == "")
                    {
                        hf_custname.Value = "0";
                    }
                    //sgroupid = Convert.ToInt32(hdf_id.Value);

                    //sgroupid = 0;
                    branch = HREmpobj.GetBId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), ddlbranch.SelectedItem.Text);

                    if (Tillyear > 2013)
                    {
                        if (hd_subgroupid.Value=="" && Convert.ToInt32( hd_groupid.Value)==0)
                        {
                            dtage = outsobj.OutStdageingNewOnlineFormatnewfordate(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch,hd_subgroupid.Value, HttpContext.Current.Session["FADbname"].ToString(), Convert.ToInt32(hf_custname.Value), check, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)),Convert.ToInt32(hd_groupid.Value));

                        }
                        else if(hd_subgroupid.Value!="" && Convert.ToInt32( hd_groupid.Value)!=0)
                        {
                            dtage = outsobj.OutStdageingNewOnlineFormatnewfordate(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, hd_subgroupid.Value, HttpContext.Current.Session["FADbname"].ToString(), Convert.ToInt32(hf_custname.Value), check, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), Convert.ToInt32(hd_groupid.Value));
                        }
                        else if (sgroupid != 0)
                        {
                            if (ChkTill.Checked == true)
                            {
                                //dtage = outsobj.OutStdageingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), HttpContext.Current.Session["FADbname"].ToString());
                                // dtage = outsobj.OutStdageingNewOnlineFormatnew(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, HttpContext.Current.Session["FADbname"].ToString(), Convert.ToInt32(hf_custname.Value), check);
                                dtage = outsobj.OutStdageingNewOnlineFormatnewfordate(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, HttpContext.Current.Session["FADbname"].ToString(), Convert.ToInt32(hf_custname.Value), check, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                            }
                            else
                            {

                                //dtage = outsobj.OutStdageingNewOnlineFormatnew(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, HttpContext.Current.Session["FADbname"].ToString(), Convert.ToInt32(hf_custname.Value), check);
                                dtage = outsobj.OutStdageingNewOnlineFormatnewfordate(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, HttpContext.Current.Session["FADbname"].ToString(), Convert.ToInt32(hf_custname.Value), check, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));

                            }
                        }

                    }
                    else
                    {
                        dtage = outsobj.OutStdageingSchedule2013(99999, Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), HttpContext.Current.Session["FADbname"].ToString(), Convert.ToInt32(hf_custname.Value));
                    }


                    GrdAgeing.DataSource = dtage;
                    GrdAgeing.DataBind();
                    if (GrdAgeing.Rows.Count > 0)
                    {
                        GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[3].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[4].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[5].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[6].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[7].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[9].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[11].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[12].ForeColor = System.Drawing.Color.Maroon;
                        //GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[13].ForeColor = System.Drawing.Color.Maroon;
                        //GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[14].ForeColor = System.Drawing.Color.Maroon;
                        //GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[15].ForeColor = System.Drawing.Color.Maroon;
                        //GrdAgeing.Rows[GrdAgeing.Rows.Count - 1].Cells[16].ForeColor = System.Drawing.Color.Maroon;
                    }
                    GrdAgeing.Columns[1].HeaderText = "Ledger";
                    GrdAgeing.Columns[GrdAgeing.Columns.Count - 1].HeaderText = "Ledger Balance";
                    Session["dtage"] = dtage;
                    btnprint.Text = "View";
                    btnprint.ToolTip = "View";
                    btn_print1.Attributes["class"] = "btn ico-view";
                }
                else
                {
                    flag = true;
                    ddlbranch.Enabled = true;
                    GrdAgeing.Visible = false;
                    GrdAgeingsales.Visible = false;
                    GrdLW.Visible = true;
                    ddlProduct.Enabled = true;
                    txtLedger.Enabled = true;
                    txtSalesPerson.Enabled = true;
                    btnprint.ToolTip = "Print";
                    btn_print1.Attributes["class"] = "btn ico-print";
                    if (ddlcurency.Items.Count > 0)
                    {
                        ddlcurency.Enabled = true;
                    }

                    if (cboxSalesAgeing.Checked == true)
                    {
                        cboxSalesAgeing_CheckedChanged(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void cboxSalesAgeing_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Date = da_obj_Log.GetDate();
                Time = Date.Hour;
                lnk_back.Visible = false;

                if (cboxSalesAgeing.Checked == true)
                {
                    flag = false;
                    GrdLW.Visible = false;
                    ddlbranch.Enabled = false;
                    ddlProduct.Enabled = false;
                    DropDownList1.Enabled = false;
                    DropDownList2.Enabled = false;
                    GrdAgeing.Visible = false;
                    GrdAgeingsales.Visible = true;
                    txtLedger.Enabled = false;
                    txtSalesPerson.Enabled = false;
                    ddlcurency.Enabled = false;

                    DataTable dtsales = new DataTable();
                    int branch = 0;
                    cboxLedgerAgeing.Checked = false;
                    sgroupid = Convert.ToInt32(hdf_id.Value);
                    saleid = Convert.ToInt32(hdf_idsales.Value);
                    branch = HREmpobj.GetBId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), ddlbranch.SelectedItem.Text);

                    int Tillyear;
                    if (Date.Month <= 3)
                    {
                        Tillyear = (Date.Year) - 1;
                    }
                    else
                    {
                        Tillyear = (Date.Year);
                    }

                    if (Tillyear > 2013)
                    {
                        if (ChkTill.Checked == true)
                        {
                            dtsales = outsobj.OutStdageingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), HttpContext.Current.Session["FADbname"].ToString());
                        }
                        else
                        {
                            dtsales = outsobj.OutStdageingNewsales(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, HttpContext.Current.Session["FADbname"].ToString(), saleid);
                        }
                    }
                    else
                    {
                        dtsales = outsobj.OutStdageingNewsalesSchedule2013(99999, Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, HttpContext.Current.Session["FADbname"].ToString(), saleid);
                    }

                    GrdAgeingsales.Columns[1].HeaderText = "SalesPerson";
                    GrdAgeingsales.DataSource = dtsales;
                    GrdAgeingsales.DataBind();
                    if (GrdAgeingsales.Rows.Count > 0)
                    {
                        GrdAgeingsales.Rows[GrdAgeingsales.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeingsales.Rows[GrdAgeingsales.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeingsales.Rows[GrdAgeingsales.Rows.Count - 1].Cells[3].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeingsales.Rows[GrdAgeingsales.Rows.Count - 1].Cells[4].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeingsales.Rows[GrdAgeingsales.Rows.Count - 1].Cells[5].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeingsales.Rows[GrdAgeingsales.Rows.Count - 1].Cells[6].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeingsales.Rows[GrdAgeingsales.Rows.Count - 1].Cells[7].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeingsales.Rows[GrdAgeingsales.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeingsales.Rows[GrdAgeingsales.Rows.Count - 1].Cells[9].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeingsales.Rows[GrdAgeingsales.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
                        GrdAgeingsales.Rows[GrdAgeingsales.Rows.Count - 1].Cells[11].ForeColor = System.Drawing.Color.Maroon;
                    }
                    ViewState["SalesPerson"] = dtsales;
                }
                else
                {
                    flag = true;
                    ddlbranch.Enabled = true;
                    GrdAgeing.Visible = false;
                    GrdAgeingsales.Visible = false;
                    GrdLW.Visible = true;
                    ddlProduct.Enabled = true;
                    DropDownList1.Enabled = true;
                    DropDownList2.Enabled = true;
                    txtLedger.Enabled = true;
                    txtSalesPerson.Enabled = true;
                    if (ddlcurency.Items.Count > 0)
                    {
                        ddlcurency.Enabled = true;
                    }

                    if (cboxLedgerAgeing.Checked == true)
                    {
                        cboxLedgerAgeing_CheckedChanged(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void GridFilter()
        {
            string str_SelFormula = "";

            if (hdf_idsales.Value != "")
            {
                saleid = Convert.ToInt32(hdf_idsales.Value);
            }
            //if (hf_custid.Value != "")
            //{
            //    customerid = Convert.ToInt32(hf_custid.Value);
            //}

            if (hf_custname.Value != "")
            {
                customerid = Convert.ToInt32(hf_custname.Value);
            }

            if (ddlbranch.SelectedIndex != 0)
            {
                try
                {
                    if (ddlbranch.SelectedItem.Text != "ALL")
                    {
                        str_SelFormula = "shortname =  '" + ddlbranch.SelectedItem.Text + "'";
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
            if (ddlProduct.SelectedIndex != 0)
            {
                try
                {
                    if (ddlProduct.Text != "ALL")
                    {
                        if (str_SelFormula != "")
                        {
                            str_SelFormula = str_SelFormula + " and trantype ='" + ddlProduct.SelectedItem.Text + "'";
                        }
                        else
                        {
                            str_SelFormula = "trantype = '" + ddlProduct.SelectedItem.Text + "'";
                        }
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }

            if (txtLedger.Text != "")
            {
                try
                {
                    if (txtLedger.Text != "ALL")
                    {
                        if (str_SelFormula != "")
                        {
                            str_SelFormula = str_SelFormula + " and customer =  '" + txtLedger.Text + "' and customerid=" + customerid;
                        }
                        else
                        {
                            str_SelFormula = "customer like '" + txtLedger.Text + "' and customerid=" + customerid;
                        }
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }

            if (txtSalesPerson.Text != "")
            {
                try
                {
                    if (txtSalesPerson.Text != "ALL")
                    {
                        if (str_SelFormula != "" && txtSalesPerson.Text != "")
                        {
                            str_SelFormula = str_SelFormula + " and salesname = '" + txtSalesPerson.Text + "' and salesid=" + saleid;
                        }
                        else
                        {
                            str_SelFormula = "salesname like '" + txtSalesPerson.Text + "' and salesid=" + saleid;
                        }
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
            if (ddlcurency.SelectedIndex != -1)
            {
                try
                {
                    if (ddlcurency.Text != "ALL")
                    {
                        if (str_SelFormula != "")
                        {
                            str_SelFormula = str_SelFormula + " and fcurr ='" + ddlcurency.SelectedItem.Text + "'";
                        }
                        else
                        {
                            str_SelFormula = "fcurr = '" + ddlcurency.SelectedItem.Text + "'";
                        }
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }


            dt = (DataTable)Session["Data"];
            DataView dt_ldg = new DataView(dt);

            if (str_SelFormula != "")
            {
                dt_ldg.RowFilter = str_SelFormula;
            }
            else
            {

            }
            DataTable dt2 = new DataTable();
            dt2 = dt_ldg.ToTable();
            DataRow dr2 = dt2.NewRow();
            dr2["amount"] = dt2.Compute("sum(amount)", "");
            dr2["vamount"] = dt2.Compute("sum(vamount)", "");
            dr2["Receivedamount"] = dt2.Compute("sum(Receivedamount)", "");
            dr2["famount"] = dt2.Compute("sum(famount)", "");

            dr2["recefamount"] = dt2.Compute("sum(recefamount)", "");
            dr2["foverdue"] = dt2.Compute("sum(foverdue)", "");

            

            dt2.Rows.Add(dr2);

            GrdLW.Visible = true;
            GrdLW.DataSource = dt2;
            GrdLW.DataBind();

            ViewState["dt1"] = dt2;
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            {
                GridFilter();
            }
        }

        protected void ddlcurency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            {
                if (cboxLedgerAgeing.Checked == true)
                {

                }
                else
                {
                    GridFilter();
                }
            }
        }

        protected void txtSalesPerson_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSalesPerson.Text != "")
                {
                    //btnGet_Click(sender, e);
                    //return;
                }
                DataTable obj_dt = new DataTable();
              //  DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

                obj_dt = (DataTable)HttpContext.Current.Session["Sales"];
                DataView dt_ldg = new DataView(obj_dt);
                dt_ldg.RowFilter = "salesname like '" + txtSalesPerson.Text + "%'";
                obj_dt = dt_ldg.ToTable();

                if (hdf_salename.Value != "" && txtSalesPerson.Text != "")
                {
                    if (obj_dt.Rows.Count > 0)
                    {
                        hdf_idsales.Value = obj_dt.Rows[0]["salesid"].ToString();
                        sgroupid = Convert.ToInt32(obj_dt.Rows[0]["salesid"].ToString());
                        sgname = obj_dt.Rows[0]["salesname"].ToString();
                        txtSalesPerson.Text = sgname;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Name');", true);
                    }
                }
                else
                {
                    hdf_idsales.Value = "0";
                }
                GridFilter();
                txtLedger.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }



        protected void get_Ledger_filter()
        {
            DataTable obj_dt = new DataTable();
           // DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            if (Session["customer"] == null)
            {
                return;
            }
            //if (txtLedger.Text=="")
            //{
            //    return;
            //}
            obj_dt = (DataTable)HttpContext.Current.Session["customer"];
            DataView dt_ldg = new DataView(obj_dt);
            dt_ldg.RowFilter = "customer like '" + txtLedger.Text + "%'";
            obj_dt = dt_ldg.ToTable();

            //if (hf_custname.Value != "")
            //{
            //    if (obj_dt.Rows.Count > 0)
            //    {
            //        hf_custname.Value = obj_dt.Rows[0]["customerid"].ToString();
            //        txtLedger.Text = obj_dt.Rows[0]["customer"].ToString();
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Name');", true);
            //    }
            //}
            //else
            //{
            //    hf_custname.Value = "0";
            //}
            GridFilter();
            txtLedger.Focus();
        }


        protected void txtLedger_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtLedger.Text == "")
                {
                    //btnGet_Click(sender, e);
                    //return;
                    hf_custname.Value = "0";
                }
                get_Ledger_filter();
                txtLedger.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                get_Ledger_filter();
                txtLedger.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void GrdAgeing_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    double dbl_temp = 0;
                    if (i > 1 && i < 13)
                    {
                        if (double.TryParse(e.Row.Cells[i].Text.ToString(), out dbl_temp))
                        {
                            e.Row.Cells[i].Text = string.Format("{0:#,##0.00}", dbl_temp);
                            e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                        }
                    }

                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;

                }
                LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
                string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");
                // Add events to each editable cell
                for (int columnIndex = 0; columnIndex < e.Row.Cells.Count; columnIndex++)
                {
                    // Add the column index as the event argument parameter
                    string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                    // Add this javascript to the onclick Attribute of the cell
                    e.Row.Cells[columnIndex].Attributes["onclick"] = js;

                    // Add a cursor style to the cells
                    //e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";
                }

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdAgeing, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[i].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[i].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void GrdAgeingsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    double dbl_temp = 0;
                    if (i > 1 && i < 12)
                    {
                        if (double.TryParse(e.Row.Cells[i].Text.ToString(), out dbl_temp))
                        {
                            e.Row.Cells[i].Text = string.Format("{0:#,##0.00}", dbl_temp);
                            e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                        }
                    }
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
                string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");
                // Add events to each editable cell
                for (int columnIndex = 0; columnIndex < e.Row.Cells.Count; columnIndex++)
                {
                    // Add the column index as the event argument parameter
                    string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                    // Add this javascript to the onclick Attribute of the cell
                    e.Row.Cells[columnIndex].Attributes["onclick"] = js;

                    // Add a cursor style to the cells
                    //e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";
                }

                e.Row.Attributes["style"] = "cursor:pointer";

                for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[i].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[i].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void GrdAgeing_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fda = 0;
            int tda = 0;
            int index = 0;
            int cindex;
            string st = null;
            int rcnt = 0;
            double opbal = 0.0;
            double onacc = 0.0;
            double totamt = 0.0;
            double totramt = 0.0;
            Date = da_obj_Log.GetDate();
            Time = Date.Hour;
            int branch = 0;

            //sgroupid = Convert.ToInt32(hdf_id.Value);
            sgroupid = 0;
            branch = HREmpobj.GetBId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), ddlbranch.SelectedItem.Text);
            dtvou = new DataTable();

            if (e.CommandName.ToString() == "ColumnClick")
            {
                foreach (GridViewRow r in GrdAgeing.Rows)
                {
                    if (r.RowType == DataControlRowType.DataRow)
                    {
                        for (int columnIndex = 0; columnIndex < r.Cells.Count; columnIndex++)
                        {
                            r.Cells[columnIndex].Attributes["style"] += "background-color:White;";
                        }
                    }
                }

                selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                selectedColumnIndex = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
                //GrdAgeing.Rows[selectedRowIndex].Cells[selectedColumnIndex].Attributes["style"] += "background-color:Red;";
            }

            if (GrdAgeing.Rows.Count > 0)
            {
                index = selectedRowIndex;
                cindex = selectedColumnIndex;
                int gridViewCellCount = GrdAgeing.Rows[0].Cells.Count;
                //lid = Convert.ToInt32(GrdAgeing.Rows[index].Cells[13].Text);
                lid = Convert.ToInt32(GrdAgeing.DataKeys[index].Values[0].ToString());
                if (GrdAgeing.Rows[index].Cells[10].Text == "")
                {
                    opbal = 0;
                }
                else
                {
                    opbal = Convert.ToDouble(GrdAgeing.Rows[index].Cells[10].Text);
                }

                st = GrdAgeing.Columns[selectedColumnIndex].HeaderText;
                //sgroupid = Convert.ToInt32(hdf_id.Value);
                sgroupid = 0;
                branch = HREmpobj.GetBId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), ddlbranch.SelectedItem.Text);
                string CustomerName = GrdAgeing.Rows[index].Cells[1].Text.Replace("&amp;", " ");
                string Branch = "";

                dtvou = new DataTable();
                if (st == "<=15")
                {
                    fda = 1;
                    tda = 15;
                }
                else if (st == "16~30")
                {
                    fda = 16;
                    tda = 30;
                }
                else if (st == "31~45")
                {
                    fda = 31;
                    tda = 45;
                }
                else if (st == "46~60")
                {
                    fda = 46;
                    tda = 60;
                }
                else if (st == "61~90")
                {
                    fda = 61;
                    tda = 90;
                }
                else if (st == "91~120")
                {
                    fda = 91;
                    tda = 120;
                }
                else if (st == "121~180")
                {
                    fda = 121;
                    tda = 180;
                }
                else if (st == "181~365")
                {
                    fda = 181;
                    tda = 365;
                }
                else if (st == ">=366")
                {
                    fda = 366;
                    tda = 400;
                }
                else if (st == "Total O/S")
                {
                    fda = 1;
                    tda = 400;
                }
                else if (st == "Ledger")
                {
                    string BranchName = Session["LoginBranchName"].ToString();
                    if (BranchName == "CORPORATE")
                    {
                        Branch = "CORPORATE";
                    }
                    else
                    {
                        Branch = "";
                    }

                    iframecost.Attributes["src"] = "../FAForms/FALedgerView.aspx?Customer=" + CustomerName + "&CheckedValue=" + false + "&LedgerID=" + lid + "&FromDate=04/01/" + LogYear + "&ToDate=" + Utility.fn_ConvertDate(da_obj_Log.GetDate().ToString()) + "&Branch=" + Branch + "&EcsValue=" + true + "";
                    ModalPopupExtender1.Show();
                    return;
                }
                else if (st == "Customer")
                {
                    lnk_back.Visible = false;
                }
            }

            if (lid == 0)
            {
                lid = -1;
            }
            if (lid != 0)
            {
                dtvou = new DataTable();

                int Tillyear;
                if (Date.Month <= 3)
                {
                    Tillyear = (Date.Year) - 1;
                }
                else
                {
                    Tillyear = (Date.Year);
                }

                if (Tillyear > 2013)
                {
                    if (st == "Total O/S" && Session["LoginBranchName"].ToString() == "CORPORATE")
                    {
                        //if (hid_groupid.Value == "12" || hid_groupid.Value=="13")
                        //if (sgroupid == 65 || sgroupid == 59 || sgroupid == 44)
                        //{
                        //    dtvou = outsobj.Getoutstd_breakuopdetailsusd(Convert.ToInt32(Session["LoginEmpId"].ToString()), lid);
                        //}
                        //else
                        //{
                        //    dtvou = outsobj.Getoutstd_breakuopdetails(Convert.ToInt32(Session["LoginEmpId"].ToString()), lid);
                        //}
                        dtvou = outsobj.Getoutstd_breakuopdetails(Convert.ToInt32(Session["LoginEmpId"].ToString()), lid);

                    }
                    if (dtvou.Rows.Count == 0)
                    {
                        if (GrdAgeing.Columns[1].HeaderText == "Ledger")
                        {
                            //if (sgroupid == 65 || sgroupid == 59 || sgroupid == 44)
                            //{
                            //    dtvou = outsobj.Outstdagingvounewusd(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                            //}
                            //else
                            //{
                            //    dtvou = outsobj.Outstdagingvounew(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                            //}

                            dtvou = outsobj.Outstdagingvounew(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                        }
                        else
                        {
                            dtvou = outsobj.Outstdagingvounewsales(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                        }
                    }

                }
                else
                {
                    if (GrdAgeing.Columns[1].HeaderText == "Ledger")
                    {
                        dtvou = outsobj.OutstdagingVouSchedule2013(lid, fda, tda, 99999, Session["FADbname"].ToString(), branch, Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid);
                    }
                    else
                    {
                        dtvou = outsobj.OutstdagingvounewsalesSchedule2013(lid, fda, tda, 99999, Session["FADbname"].ToString(), branch, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    }
                }
            }

            if (dtvou.Rows.Count > 0)
            {
                cboxLedgerAgeing.Enabled = false;
                cboxSalesAgeing.Enabled = false;
                custname.Text = GrdAgeing.Rows[index].Cells[1].Text;
                custname.Visible = true;
                //  txtSubGroupName.Visible = false;
                ddl_groupname.Visible = false;

                chkproducts.Visible = false;
                txt_workprocess.Visible = false;
                btnGet.Visible = false;
                btnClear.Visible = false;
                btnExpertExcel.Visible = true;
                cboxSalesAgeing.Visible = false;
                DropDownList1.Visible = false;
                DropDownList2.Visible = false;
                ddlbranch.Visible = false;
                ddlProduct.Visible = false;
                txtSalesPerson.Visible = false;
                txtLedger.Visible = false;
                lst.Visible = false;
                ddlcurency.Visible = false;

                GrdLW.Visible = false;
                GrdAgeingsales.Visible = false;
                GrdAgeing.Visible = false;
                grdvou.Visible = true;
                ChkTill.Visible = false;
                txt_date.Visible = false;
                SubgroupName.Visible = true;
                int count;
                if (dtvou.Rows.Count > 0)
                {
                    double Total1 = 0.0, Total2 = 0.00, temp2 = 0.0;
                    dtemptynew.Columns.Add("Branch");
                    dtemptynew.Columns.Add("Voucher");
                    dtemptynew.Columns.Add("Vou #");
                    dtemptynew.Columns.Add("Date");
                    dtemptynew.Columns.Add("Customer");
                    dtemptynew.Columns.Add("Ref #");
                    dtemptynew.Columns.Add("Amount");
                    dtemptynew.Columns.Add("Days");
                    DataRow dr = dtemptynew.NewRow();
                    Total1 = 0.0;
                    for (int i = 0; i <= dtvou.Rows.Count - 1; i++)
                    {

                        dr = dtemptynew.NewRow();
                        dtemptynew.Rows.Add();
                        count = dtemptynew.Rows.Count - 1;
                        dtemptynew.Rows[count]["Branch"] = dtvou.Rows[i]["shortname"].ToString();
                        dtemptynew.Rows[count]["Voucher"] = dtvou.Rows[i]["Voucher"].ToString();
                        dtemptynew.Rows[count]["Vou #"] = dtvou.Rows[i]["Vouno"].ToString();
                        dtemptynew.Rows[count]["Date"] = dtvou.Rows[i]["voudate"].ToString();
                        dtemptynew.Rows[count]["Customer"] = dtvou.Rows[i]["customer"].ToString();
                        dtemptynew.Rows[count]["Ref #"] = dtvou.Rows[i]["refno"].ToString();
                        dtemptynew.Rows[count]["Days"] = dtvou.Rows[i]["da"].ToString();
                        dtemptynew.Rows[count]["Amount"] = Convert.ToDouble(dtvou.Rows[i]["ramount"].ToString()).ToString("#,0.00");
                        Total1 = Total1 + Convert.ToDouble(dtvou.Rows[i]["ramount"].ToString());
                        //dtemptynew.Rows[count]["Amount"] = Total1;                                                                  
                    }

                    grdvou.DataSource = dtemptynew;
                    grdvou.DataBind();

                    //rcnt = grdvou.Rows.Count;
                    DataTable dt12 = new DataTable();
                    dt12 = dtemptynew;
                    DataRow drr2 = dt12.NewRow();
                    drr2["Ref #"] = "Total";
                    drr2["Amount"] = Total1.ToString("#,0.00");
                    dt12.Rows.Add(drr2);
                    lnk_back.Visible = true;
                    grdvou.DataSource = dt12;
                    grdvou.DataBind();

                    rcnt = grdvou.Rows.Count;
                    ViewState["GrdAgeing"] = dt12;
                    grdvou.Rows[rcnt - 1].ForeColor = System.Drawing.Color.Maroon;
                    if (st == "Total")
                    {
                        //grdvou.Rows[rcnt + 1].ForeColor = System.Drawing.Color.Maroon;
                        //grdvou.Rows[rcnt + 1].Cells[7].Text = "Total";
                        //grdvou.Rows[rcnt + 1].Cells[8].Text = "Total";
                    }
                }
                else
                {
                    lnk_back.Visible = false;
                }

                SubgroupName.Text = outsobj.GetSubgroupName(lid, Session["FADbname"].ToString());
            }
        }

        protected void GrdAgeingsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int fda = 0;
                int tda = 0;
                int index = 0;
                int cindex;
                string st = null;
                int rcnt = 0;
                double opbal = 0.0;
                double onacc = 0.0;
                double totamt = 0.0;
                double totramt = 0.0;
                Date = da_obj_Log.GetDate();
                Time = Date.Hour;
                int branch = 0;
                sgroupid = Convert.ToInt32(hdf_id.Value);
                branch = HREmpobj.GetBId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), ddlbranch.SelectedItem.Text);

                if (e.CommandName.ToString() == "ColumnClick")
                {
                    foreach (GridViewRow r in GrdAgeingsales.Rows)
                    {
                        if (r.RowType == DataControlRowType.DataRow)
                        {
                            for (int columnIndex = 0; columnIndex < r.Cells.Count; columnIndex++)
                            {
                                r.Cells[columnIndex].Attributes["style"] += "background-color:White;";
                            }
                        }
                    }

                    selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                    selectedColumnIndex = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
                }

                if (GrdAgeingsales.Rows.Count > 0)
                {
                    index = selectedRowIndex;
                    cindex = selectedColumnIndex;
                    int gridViewCellCount = GrdAgeingsales.Rows[0].Cells.Count;
                    lid = Convert.ToInt32(GrdAgeingsales.DataKeys[index].Values[0].ToString());
                    if (GrdAgeingsales.Rows[index].Cells[11].Text == "")
                    {
                        opbal = 0;
                    }
                    else
                    {
                        opbal = Convert.ToDouble(GrdAgeingsales.Rows[index].Cells[11].Text);
                    }


                    st = GrdAgeingsales.Columns[selectedColumnIndex].HeaderText;
                    sgroupid = Convert.ToInt32(hdf_id.Value);
                    branch = HREmpobj.GetBId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), ddlbranch.SelectedItem.Text);

                    if (st == "<=15")
                    {
                        fda = 1;
                        tda = 15;
                    }
                    else if (st == "16~30")
                    {
                        fda = 16;
                        tda = 30;
                    }
                    else if (st == "31~45")
                    {
                        fda = 31;
                        tda = 45;
                    }
                    else if (st == "46~60")
                    {
                        fda = 46;
                        tda = 60;
                    }
                    else if (st == "61~90")
                    {
                        fda = 61;
                        tda = 90;
                    }
                    else if (st == "91~120")
                    {
                        fda = 91;
                        tda = 120;
                    }
                    else if (st == "121~180")
                    {
                        fda = 121;
                        tda = 180;
                    }
                    else if (st == "181~365")
                    {
                        fda = 181;
                        tda = 365;
                    }
                    else if (st == ">=366")
                    {
                        fda = 366;
                        tda = 400;
                    }
                    else if (st == "Total O/S")
                    {
                        fda = 1;
                        tda = 400;
                    }
                    else if (st == "Ledger")
                    {
                        return;
                    }
                    else if (st == "Customer")
                    {
                        lnk_back.Visible = false;
                    }
                }

                if (lid == 0)
                {
                    lid = -1;
                }

                if (lid != 0)
                {
                    dtvou = new DataTable();

                    int Tillyear;
                    if (Date.Month <= 3)
                    {
                        Tillyear = (Date.Year) - 1;
                    }
                    else
                    {
                        Tillyear = (Date.Year);
                    }

                    if (Tillyear > 2013)
                    {
                        if (GrdAgeingsales.Columns[1].HeaderText == "Ledger")
                        {
                            dtvou = outsobj.Outstdagingvounew(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                        }
                        else
                        {
                            dtvou = outsobj.Outstdagingvounewsales(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                        }
                    }
                    else
                    {
                        if (GrdAgeingsales.Columns[1].HeaderText == "Ledger")
                        {
                            dtvou = outsobj.OutstdagingVouSchedule2013(lid, fda, tda, 99999, Session["FADbname"].ToString(), branch, Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid);
                        }
                        else
                        {
                            dtvou = outsobj.OutstdagingvounewsalesSchedule2013(lid, fda, tda, 99999, Session["FADbname"].ToString(), branch, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                    }
                }

                if (dtvou.Rows.Count > 0)
                {
                    cboxLedgerAgeing.Enabled = false;
                    cboxSalesAgeing.Enabled = false;
                    grdvou.Visible = true;
                    lnk_back.Visible = true;
                    custname.Text = GrdAgeingsales.Rows[index].Cells[1].Text;
                    custname.Visible = true;
                    //  txtSubGroupName.Visible = false;
                    ddl_groupname.Visible = false;
                    chkproducts.Visible = false;
                    txt_workprocess.Visible = false;
                    btnGet.Visible = false;
                    btnClear.Visible = false;
                    btnExpertExcel.Visible = true;
                    cboxSalesAgeing.Visible = false;
                    DropDownList1.Visible = false;
                    DropDownList2.Visible = false;
                    ddlbranch.Visible = false;
                    ddlProduct.Visible = false;
                    txtSalesPerson.Visible = false;
                    txtLedger.Visible = false;
                    lst.Visible = false;
                    ddlcurency.Visible = false;

                    GrdLW.Visible = false;
                    GrdAgeingsales.Visible = false;
                    GrdAgeing.Visible = false;
                    ChkTill.Visible = false;
                    txt_date.Visible = false;
                    int count;
                    if (dtvou.Rows.Count > 0)
                    {
                        double total = 0.0, total1 = 0.0, temp2 = 0.0;
                        dtemptynew.Columns.Add("Branch");
                        dtemptynew.Columns.Add("Voucher");
                        dtemptynew.Columns.Add("Vou #");
                        dtemptynew.Columns.Add("Date");
                        dtemptynew.Columns.Add("Customer");
                        dtemptynew.Columns.Add("Ref #");
                        dtemptynew.Columns.Add("Amount");
                        dtemptynew.Columns.Add("Days");
                        DataRow dr = dtemptynew.NewRow();

                        for (int i = 0; i <= (dtvou.Rows.Count - 1); i++)
                        {
                            dr = dtemptynew.NewRow();
                            dtemptynew.Rows.Add();
                            count = dtemptynew.Rows.Count - 1;
                            dtemptynew.Rows[count]["Branch"] = dtvou.Rows[i]["shortname"].ToString();
                            dtemptynew.Rows[count]["Voucher"] = dtvou.Rows[i]["Voucher"].ToString();
                            dtemptynew.Rows[count]["Vou #"] = dtvou.Rows[i]["Vouno"].ToString();
                            dtemptynew.Rows[count]["Date"] = dtvou.Rows[i]["voudate"].ToString();
                            dtemptynew.Rows[count]["Customer"] = dtvou.Rows[i]["customer"].ToString();
                            dtemptynew.Rows[count]["Ref #"] = dtvou.Rows[i]["refno"].ToString();
                            dtemptynew.Rows[count]["Days"] = dtvou.Rows[i]["da"].ToString();
                            dtemptynew.Rows[count]["Amount"] = Convert.ToDouble(dtvou.Rows[i]["ramount"].ToString()).ToString("#,0.00");
                            total = total + Convert.ToDouble(dtvou.Rows[i]["ramount"].ToString());

                        }

                        //grdvou.Visible = true;
                        //GrdAgeing.Visible = false;
                        //grdvou.DataSource = dtemptynew;
                        //grdvou.DataBind();


                        DataTable dt12 = new DataTable();
                        dt12 = dtemptynew;
                        DataRow drr2 = dt12.NewRow();
                        drr2["Ref #"] = "Total";
                        drr2["Amount"] = total.ToString("#,0.00");
                        dt12.Rows.Add(drr2);
                        lnk_back.Visible = true;
                        grdvou.Visible = true;
                        grdvou.DataSource = dt12;
                        grdvou.DataBind();

                        rcnt = grdvou.Rows.Count;
                        grdvou.Rows[rcnt - 1].ForeColor = System.Drawing.Color.Maroon;
                        ViewState["GrdAgeing"] = dt12;
                        if (st == "Total")
                        {
                            //grdvou.Rows[rcnt + 1].ForeColor = System.Drawing.Color.Maroon;
                            //grdvou.Rows[rcnt + 1].Cells[7].Text = "Total";
                            //grdvou.Rows[rcnt + 1].Cells[8].Text = "Total";
                        }
                    }
                }
                else
                {
                    lnk_back.Visible = false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_back_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdvou.Visible == true)
                {
                    cboxLedgerAgeing.Enabled = true;
                    cboxSalesAgeing.Enabled = true;
                    grdvou.Visible = false;
                    lnk_back.Visible = false;
                    SubgroupName.Visible = false;

                    if (GrdAgeingsales.Rows.Count > 0 && cboxSalesAgeing.Checked == true)
                    {
                        custname.Visible = false;
                        GrdAgeingsales.Visible = true;
                        txtSalesPerson.Visible = true;
                        cboxSalesAgeing.Visible = true;
                        //   txtSubGroupName.Visible = true;
                        ddl_groupname.Visible = true;

                        txt_workprocess.Visible = true;
                        btnGet.Visible = true;
                        btnClear.Visible = true;
                        btnExpertExcel.Visible = true;
                        ddlbranch.Visible = true;
                        ddlProduct.Visible = true;
                        txtLedger.Visible = true;
                        ddlcurency.Visible = true;

                        ChkTill.Visible = false;
                        txt_date.Visible = true;
                        SubgroupName.Visible = false;
                    }
                    else if (GrdAgeing.Rows.Count > 0 && cboxLedgerAgeing.Checked == true)
                    {
                        custname.Visible = false;
                        GrdAgeing.Visible = true;
                        txtSalesPerson.Visible = true;
                        cboxLedgerAgeing.Visible = true;
                        cboxSalesAgeing.Visible = true;
                        //   txtSubGroupName.Visible = true;
                        ddl_groupname.Visible = true;

                        txt_workprocess.Visible = true;
                        btnGet.Visible = true;
                        btnClear.Visible = true;
                        btnExpertExcel.Visible = true;
                        ddlbranch.Visible = true;
                        ddlProduct.Visible = true;
                        txtLedger.Visible = true;
                        ddlcurency.Visible = true;

                        ChkTill.Visible = false;
                        txt_date.Visible = true;
                        SubgroupName.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void ChkTill_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTill.Checked == true)
            {
                txt_date.Enabled = true;
                txt_date.Text = Utility.fn_ConvertDate(da_obj_Log.GetDate().AddDays(-1).ToString());
                hid_date.Value = txt_date.Text;
            }
            else
            {
                txt_date.Enabled = false;
                txt_date.Text = Utility.fn_ConvertDate(da_obj_Log.GetDate().ToString());
                hid_date.Value = txt_date.Text;
            }

            flag = true;
            GrdLW.Visible = true;
            GrdAgeing.Visible = false;
            ddlbranch.Items.Clear();
            ddlProduct.Items.Clear();
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            {
                GridFilter();
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            {
                GridFilter();
            }
        }
        public DataTable BindDatatable()
        {
            DataTable dtt = new DataTable();
            DataTable dttt = new DataTable();
            dtt = (DataTable)ViewState["dt1"];
            dttt.Columns.Add("Branch");
            dttt.Columns.Add("Subgroupname");
            dttt.Columns.Add("VouType");
            dttt.Columns.Add("Vendor Ref #");
            dttt.Columns.Add("Date");
            dttt.Columns.Add("BPJ");
            dttt.Columns.Add("Vou #");
            dttt.Columns.Add("Ledger");
            dttt.Columns.Add("Amount");
            dttt.Columns.Add("FAmount");
           
            dttt.Columns.Add("AppAmt");
            dttt.Columns.Add("OverDue");
            dttt.Columns.Add("FOverDue");

            dttt.Columns.Add("NoOfDays");
            dttt.Columns.Add("AppDays");
            dttt.Columns.Add("OverDueDays");
            dttt.Columns.Add("Product");
          
           
            
            dttt.Columns.Add("BL #");

            dttt.Columns.Add("Shipper/Consignee");

            dttt.Columns.Add("P O R");
            dttt.Columns.Add("P O L");
            dttt.Columns.Add("P O D");
            dttt.Columns.Add("Sales Person");

            dttt.Columns.Add("Shipment");
         
          
           
            dttt.Columns.Add("Volume/Teus/KGS");

            dttt.Columns.Add("Quotation #");
            dttt.Columns.Add("Quot # Customer");
            DataRow dr;
            if (dtt.Rows.Count > 0)
            {
                dr = dttt.NewRow();
                for (int i = 0; i <= dtt.Rows.Count - 1; i++)
                {
                    dttt.Rows.Add();
                    dttt.Rows[i]["Branch"] = dtt.Rows[i]["shortname"];
                    dttt.Rows[i]["Subgroupname"] = dtt.Rows[i]["subgroupname"];
                    dttt.Rows[i]["Product"] = dtt.Rows[i]["trantype"];
                    dttt.Rows[i]["VouType"] = dtt.Rows[i]["voutype"];
                    dttt.Rows[i]["Vou #"] = dtt.Rows[i]["vouno"];
                    dttt.Rows[i]["Date"] = dtt.Rows[i]["voudate"];
                    dttt.Rows[i]["BL #"] = dtt.Rows[i]["refno"];
                    dttt.Rows[i]["Sales Person"] = dtt.Rows[i]["salesname"];
                    dttt.Rows[i]["Ledger"] = dtt.Rows[i]["customer"];
                    dttt.Rows[i]["Amount"] = dtt.Rows[i]["amount"];
                    dttt.Rows[i]["FAmount"] = dtt.Rows[i]["famount"];
                    dttt.Rows[i]["NoOfDays"] = dtt.Rows[i]["nodays"];
                    dttt.Rows[i]["AppAmt"] = dtt.Rows[i]["appamt"];
                    dttt.Rows[i]["AppDays"] = dtt.Rows[i]["appdays"];
                    dttt.Rows[i]["OverDue"] = dtt.Rows[i]["overdue"];
                    dttt.Rows[i]["FOverDue"] = dtt.Rows[i]["foverdue"];
                    dttt.Rows[i]["OverDueDays"] = dtt.Rows[i]["overduedays"];
                    dttt.Rows[i]["Shipper/Consignee"] = dtt.Rows[i]["Shipper/Consignee"];
                    dttt.Rows[i]["P O R"] = dtt.Rows[i]["P O R"];
                    dttt.Rows[i]["P O L"] = dtt.Rows[i]["P O L"];
                    dttt.Rows[i]["P O D"] = dtt.Rows[i]["P O D"];
                    dttt.Rows[i]["Shipment"] = dtt.Rows[i]["Shipment"];
                    dttt.Rows[i]["Volume/Teus/KGS"] = dtt.Rows[i]["Volume/Teus/KGS"];
                    dttt.Rows[i]["Vendor Ref #"] = dtt.Rows[i]["vendorrefno"];
                    dttt.Rows[i]["Quotation #"] = dtt.Rows[i]["quotno"];
                    dttt.Rows[i]["Quot # Customer"] = dtt.Rows[i]["quotcustomer"];
                    dttt.Rows[i]["BPJ"] = dtt.Rows[i]["BPJ"];
                }

            }
            return dttt;
        }

        public DataTable Bindtable1()
        {

            DataTable dttn = new DataTable();
            DataTable dtttn = new DataTable();
            dttn = (DataTable)ViewState["dtag"];
            dtttn.Columns.Add("Ledger");
            dtttn.Columns.Add("<=15");
            dtttn.Columns.Add("16~30");
            dtttn.Columns.Add("31~45");
            dtttn.Columns.Add("46~60");
            dtttn.Columns.Add("61~90");
            dtttn.Columns.Add("91~120");
            dtttn.Columns.Add("121~180");
            dtttn.Columns.Add("181~365");
            dtttn.Columns.Add(">=366");
            dtttn.Columns.Add("Total O/S");
            dtttn.Columns.Add("Ledger Balance");

            DataRow dr;
            if (dttn.Rows.Count > 0)
            {
                dr = dtttn.NewRow();
                for (int i = 0; i <= dttn.Rows.Count - 1; i++)
                {
                    dtttn.Rows.Add();
                    dtttn.Rows[i]["Ledger"] = dttn.Rows[i]["customer"];
                    dtttn.Rows[i]["<=15"] = dttn.Rows[i]["grt15"];
                    dtttn.Rows[i]["16~30"] = dttn.Rows[i]["grt1630"];
                    dtttn.Rows[i]["31~45"] = dttn.Rows[i]["grt3145"];
                    dtttn.Rows[i]["46~60"] = dttn.Rows[i]["grt4660"];
                    dtttn.Rows[i]["61~90"] = dttn.Rows[i]["grt6190"];
                    dtttn.Rows[i]["91~120"] = dttn.Rows[i]["grt91120"];
                    dtttn.Rows[i]["121~180"] = dttn.Rows[i]["grt121180"];
                    dtttn.Rows[i]["181~365"] = dttn.Rows[i]["grt181365"];
                    dtttn.Rows[i][">=366"] = dttn.Rows[i]["grt366"];
                    dtttn.Rows[i]["Total O/S"] = dttn.Rows[i]["grttot"];
                    dtttn.Rows[i]["Ledger Balance"] = dttn.Rows[i]["Ledger Balance"];

                }

            }
            return dtttn;
        }

        protected void btnExpertExcel_Click(object sender, EventArgs e)
        {
            string str = "", str_filename = "";
            string Str_FileName = "VoucherwiseDetails";
            //DataTable dt1 =(DataTable)Session["Data"];
            if (GrdLW.Visible == true && GrdLW.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + ddl_groupname.SelectedItem.Text + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringBuilder SB = new StringBuilder();
                StringWriter sw = new System.IO.StringWriter(SB);
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                //To Export all pages
                GrdLW.AllowPaging = false;

                int Count = GrdLW.Columns.Count;

                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + Count + "><font face=arial size=3;><B>" + Session["LoginDivisionName"].ToString() + "</B></font></td></tr>");

                SB.Append("</table><br />");
                if (ViewState["dt1"] != null)
                {
                    GrdLW.DataSource = (DataTable)ViewState["dt1"];
                    GrdLW.DataBind();
                }

                GrdLW.RenderControl(hw);
                Response.Write(sw);
                Response.Flush();
                Response.End();
            }
            if (grdvou.Visible == true && grdvou.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                if (txtLedger.Text != "")
                {
                    string filename = txtLedger.Text.Replace('.', ' ').Replace(',', ' ');
                    Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                }
                else
                {
                    Response.AddHeader("content-disposition", "attachment;filename=VoucherwiseDetails.xls");
                }
                //  Response.AddHeader("content-disposition", "attachment;filename=VoucherwiseDetails.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                grdvou.GridLines = GridLines.Both;
                grdvou.HeaderStyle.Font.Bold = true;
                grdvou.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
            else if (GrdAgeing.Visible == true && GrdAgeing.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                if (txtLedger.Text != "")
                {
                    string filename = txtLedger.Text.Replace('.', ' ').Replace(',', ' ');
                    Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                }
                else
                {
                    Response.AddHeader("content-disposition", "attachment;filename=AgeingWiseDetailsTill.xls");
                }
                //Response.AddHeader("content-disposition", "attachment;filename=AgeingWiseDetailsTill.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                GrdAgeing.GridLines = GridLines.Both;
                GrdAgeing.HeaderStyle.Font.Bold = true;
                GrdAgeing.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();

            }
            else if (GrdAgeingsales.Visible == true && GrdAgeingsales.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                if (txtLedger.Text != "")
                {
                    string filename = txtLedger.Text.Replace('.', ' ').Replace(',', ' ');
                    Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                }
                else
                {
                    Response.AddHeader("content-disposition", "attachment;filename=SalesAgeingWiseDetails.xls");
                }
                // Response.AddHeader("content-disposition", "attachment;filename=SalesAgeingWiseDetails.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                GrdAgeingsales.Columns[GrdAgeingsales.Columns.Count - 1].Visible = false;
                GrdAgeingsales.GridLines = GridLines.Both;
                GrdAgeingsales.HeaderStyle.Font.Bold = true;
                GrdAgeingsales.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
            else if (GrdLW.Visible == true && GrdLW.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                if (txtLedger.Text != "")
                {
                    string filename = txtLedger.Text.Replace('.', ' ').Replace(',', ' ');
                    Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                }
                else
                {
                    Response.AddHeader("content-disposition", "attachment;filename=OutStandingOnlineDetails.xls");
                }
                //Response.AddHeader("content-disposition", "attachment;filename=AgeingWiseDetailsTill.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                GrdLW.GridLines = GridLines.Both;
                GrdLW.HeaderStyle.Font.Bold = true;
                GrdLW.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }


            /*string strtemp = "";
            if (grdvou.Visible == true && grdvou.Rows.Count > 0)
            {
                GridView grdexcel = new GridView();
                DataTable dtExcel = new DataTable();
                int Count;
                if (ViewState["GrdAgeing"] != null)
                {
                    dtExcel = ViewState["GrdAgeing"] as DataTable;
                }

                grdexcel.DataSource = null;
                grdexcel.DataBind();
                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=VoucherwiseDetails.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                grdexcel.DataSource = dtExcel;
                grdexcel.DataBind();
                Count = dtExcel.Columns.Count;

                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + Count + "><font face=arial size=3><B>" + Session["LoginDivisionName"].ToString() + "</B></font></td></tr>");
                SB.Append("</table><br />");

                if (grdexcel.Visible == true)
                {
                   
                    grdexcel.GridLines = GridLines.Both;
                    grdexcel.HeaderStyle.Font.Bold = true;
                    grdexcel.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
            else if (GrdAgeing.Visible == true && GrdAgeing.Rows.Count > 0)
            {
                GridView grdexcel = new GridView();
                DataTable dtExcel = new DataTable();
                int Count;
                if (Session["dtage"] != null)
                {
                    dtExcel = Session["dtage"] as DataTable;
                }
                
                grdexcel.DataSource = null;
                grdexcel.DataBind();
                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=SalesAgeingWiseDetails.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                grdexcel.DataSource = dtExcel;
                grdexcel.DataBind();
                Count = dtExcel.Columns.Count;

                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + Count + "><font face=arial size=3><B>" + Session["LoginDivisionName"].ToString() + "</B></font></td></tr>");
                SB.Append("</table><br />");

                if (grdexcel.Visible == true)
                {
                    grdexcel.GridLines = GridLines.Both;
                    grdexcel.HeaderStyle.Font.Bold = true;
                    grdexcel.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
            else if (GrdAgeingsales.Visible == true && GrdAgeingsales.Rows.Count > 0)
            {
                GridView grdexcel = new GridView();
                DataTable dtExcel = new DataTable();
                int Count;
                if (ViewState["SalesPerson"] != null)
                {
                    dtExcel = ViewState["SalesPerson"] as DataTable;
                }
                //dtExcel.Columns.RemoveAt(0);
                grdexcel.DataSource = null;
                grdexcel.DataBind();
                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=SalesAgeingWiseDetails.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                grdexcel.DataSource = dtExcel;
                grdexcel.DataBind();
                Count = dtExcel.Columns.Count;

                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + Count + "><font face=arial size=3><B>" + Session["LoginDivisionName"].ToString() + "</B></font></td></tr>");
                SB.Append("</table><br />");

                if (grdexcel.Visible == true)
                {
                    grdexcel.GridLines = GridLines.Both;
                    grdexcel.HeaderStyle.Font.Bold = true;
                    grdexcel.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
            else if (GrdLW.Visible == true && GrdLW.Rows.Count > 0)
            {
                GridView grdexcel = new GridView();
                DataTable dtExcel = new DataTable();
                int Count;
                if (ViewState["dt1"] != null)
                {
                    dtExcel = ViewState["dt1"] as DataTable;
                }
                grdexcel.DataSource = null;
                grdexcel.DataBind();
                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=AgeingWiseDetailsTill.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                grdexcel.DataSource = dtExcel;
                grdexcel.DataBind();
                Count = dtExcel.Columns.Count;

                string SubGroupName = "", LedgerName = "";
                if (txtSubGroupName.Text != "")
                {
                    SubGroupName = "SubGroupName - " + txtSubGroupName.Text;
                }
                if (txtLedger.Text != "")
                {
                    LedgerName = "Ledger Name - " + txtLedger.Text;
                }

                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + Count + "><font face=arial size=3><B>" + Session["LoginDivisionName"].ToString() + SubGroupName + LedgerName + "</B></font></td></tr>");
                SB.Append("</table><br />");

                if (grdexcel.Visible == true)
                {
                    grdexcel.GridLines = GridLines.Both;
                    grdexcel.HeaderStyle.Font.Bold = true;
                    grdexcel.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }*/

        }

        protected void GrdLW_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    double dbl_temp = 0;

                    if (double.TryParse(e.Row.Cells[11].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[11].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[11].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[6].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[6].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[6].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[7].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[7].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[7].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[8].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[8].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[8].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[9].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[9].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[9].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[10].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[10].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[10].Attributes.CssStyle["text-align"] = "Right";
                    }
                   
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;

                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                if (e.Row.Cells[26].Text != "")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdLW, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }

             

            }

            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                {
                    //if (ddlcurency.Text == "ALL")
                    //{
                    //    e.Row.Cells[10].Visible = false;
                    //    e.Row.Cells[13].Visible = false;
                    //    e.Row.Cells[12].Visible = true;
                    //    e.Row.Cells[15].Visible = true;
                    //}
                    //else
                    //{
                    //    e.Row.Cells[9].Visible = false;
                    //    e.Row.Cells[15].Visible = false;
                    //    e.Row.Cells[10].Visible = true;
                    //    e.Row.Cells[13].Visible = true;
                    //}
                }
            }
        }

        protected void grdvou_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    double dbl_temp = 0;
                    if (e.Row.Cells[6].Text != "")
                    {
                        if (double.TryParse(e.Row.Cells[6].Text.ToString(), out dbl_temp))
                        {
                            e.Row.Cells[6].Text = string.Format("{0:#,##0.00}", dbl_temp);
                            e.Row.Cells[6].Attributes.CssStyle["text-align"] = "Right";
                        }
                    }

                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    if (e.Row.Cells[i].Text == "Total")
                    {
                        e.Row.Cells[i].ForeColor = System.Drawing.Color.Brown;
                        e.Row.Cells[i + 1].ForeColor = System.Drawing.Color.Brown;
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;

                }
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            string Str_Script = "", fcurr = "NO"; int Branchid;
            if (GrdLW.Rows.Count > 0 && ViewState["dt1"] != null)
            {
                DataTable DT_out_print = (DataTable)ViewState["dt1"];
                Session["DT_out_print"] = DT_out_print;
                if (DT_out_print.Rows.Count > 0)
                {
                    Session["DT_out_print"] = DT_out_print;
                    DateTime Getdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text));
                    //  if (ddlbranch.SelectedItem.Value == "0")  
                    if (ddlbranch.SelectedValue == "Branch")
                    {
                        Branchid = Convert.ToInt32(Session["LoginBranchid"]);
                    }
                    else
                    {
                        Branchid = HREmpobj.GetBId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), ddlbranch.SelectedItem.Text);
                    }

                    if(txt_workprocess.Text=="")
                    {
                        Str_Script = "window.open('../Reportasp/OutstandingReportForAll.aspx?Branchid=" + Branchid + "&Ledger=" + hf_custname.Value + "&SubgroupID=" + 0 + "&Date=" + string.Format("{0:dd-MMMMMMMMMMM-yyyy}", Getdate) + "&Title=" + ddl_groupname.SelectedItem.Text + "&Subgroupname=" + txt_workprocess.Text.Replace(",", ",").Replace("&", "&") + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    else
                    {
                        Str_Script = "window.open('../Reportasp/OutstandingReportForAll.aspx?Branchid=" + Branchid + "&Ledger=" + hf_custname.Value + "&SubgroupID=" + 0 + "&Date=" + string.Format("{0:dd-MMMMMMMMMMM-yyyy}", Getdate) + "&Title=" + ddl_groupname.SelectedItem.Text + "&Subgroupname=" + txt_workprocess.Text.Replace(",", ",").Replace("&", "&") + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    
                    ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Outstanding", Str_Script, true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('No data available');", true);
                return;
            }
        }

        protected void GrdLW_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string str_RptName = "", str_sf = "", str_Script = "", str_sp = "";
                int Row_Index, branchid, quotno;
                if (e.CommandName.ToString() == "Select")
                {
                    Row_Index = Convert.ToInt32(e.CommandArgument.ToString());
                    if (GrdLW.Rows[Row_Index].Cells[23].Text != "")
                    {
                        Session["str_sp"] = "";
                        branchid = Convert.ToInt32(GrdLW.DataKeys[Row_Index].Values["bid"]);
                        quotno = Convert.ToInt32(GrdLW.Rows[Row_Index].Cells[23].Text);
                        str_RptName = "Quotation.rpt";
                        Session["str_sfs"] = "{QuotationHead.bid}=" + branchid + " and {QuotationHead.quotno}=" + quotno;
                        str_sf = "{QuotationHead.bid}=" + branchid + " and {QuotationHead.quotno}=" + quotno;
                        str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(GrdLW, typeof(GridView), "Quotation", str_Script, true);
                    }


                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
        protected void GrdLW_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtmp = new DataTable();
            if (ViewState["dt1"] != null)
            {
                dtmp = (DataTable)ViewState["dt1"];
                if (dtmp.Rows.Count > 0)
                {
                    GrdLW.PageIndex = e.NewPageIndex;
                    GrdLW.DataSource = dtmp;
                    GrdLW.DataBind();
                }
                else
                {
                    GrdLW.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdLW.DataBind();
                }

            }
        }
        protected void GrdAgeing_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtm = new DataTable();
            if (ViewState["dtag"] != null)
            {
                dtm = (DataTable)ViewState["dtag"];
                if (dtm.Rows.Count > 0)
                {
                    GrdAgeing.PageIndex = e.NewPageIndex;
                    GrdAgeing.DataSource = dtm;
                    GrdAgeing.DataBind();
                }
                else
                {
                    GrdAgeing.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdAgeing.DataBind();
                }

            }
        }
        protected void ddl_groupname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int groupid = 0;
                DataTable dt = new DataTable();

                if (ddl_groupname.SelectedItem.Text == "ALL")
                {
                    chkproducts.Enabled = false;
                   // ddl_groupname.Enabled = false;
                    btnGet.Enabled = true;
                    txt_workprocess.Enabled = false;
                    txt_workprocess.Text = "All Subgroupname";
                }
                else if (ddl_groupname.SelectedItem.Text != "ALL")
                {
                    txt_workprocess.Enabled = true;
                    txt_workprocess.Text = "";
                    groupid = sobj1.SpGroupid(ddl_groupname.SelectedItem.Text, FADbname);
                    hd_groupid.Value = Convert.ToInt32(groupid).ToString();
                    dt = sobj1.SpSubGroupname(Convert.ToInt32(groupid), FADbname);
                    if (dt.Rows.Count > 0)
                    {
                        chkproducts.Items.Clear();
                        chkproducts.Items.Add("Select All");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            chkproducts.Items.Add(dt.Rows[i][0].ToString());
                            // ll_subgroupname.Items.Add(dt.Rows[i][0].ToString());
                        }
                    }
                    chkproducts.Enabled = true;
                  //  ddl_groupname.Enabled = false;
                    btnGet.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void chkproducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string result = Request.Form["__EVENTTARGET"];
            string[] checkedBox = result.Split('$');
            int index = int.Parse(checkedBox[checkedBox.Length - 1]);
            string subgroupid = "";
            DataTable dt = new DataTable();

            if (index == 0)
            {
                if (chkproducts.Items[0].Selected == true)
                {
                    for (int i = 0; i < chkproducts.Items.Count; i++)
                    {
                        if (chkproducts.Items[i].Text != "Select All")
                        {
                            chkproducts.Items[i].Selected = true;


                        }
                    }
                }

                else
                {
                    for (int i = 0; i < chkproducts.Items.Count; i++)
                    {
                        chkproducts.Items[i].Selected = false;
                    }
                    txt_workprocess.Text = "";
                    return;
                }
            }
            else
            {
                for (int i = 0; i < chkproducts.Items.Count; i++)
                {
                    int a = chkproducts.Items.Count - 1;
                    int count = 0;
                    for (int j = 1; j <= chkproducts.Items.Count; j++)
                    {
                        count = count + 1;
                    }

                    if (a == count)
                    {
                        chkproducts.Items[0].Selected = true;
                    }
                }

                for (int i = 0; i < chkproducts.Items.Count; i++)
                {
                    if (chkproducts.Items[i].Selected == false)
                    {
                        chkproducts.Items[0].Selected = false;
                        break;
                    }
                }
            }

            string name = "";
            for (int i = 0; i < chkproducts.Items.Count; i++)
            {
                if (chkproducts.Items[i].Text != "Select All")
                {
                    if (chkproducts.Items[i].Selected)
                    {
                        name += chkproducts.Items[i].Text + ",";
                        if (subgroupid == "")
                        {
                            subgroupid = sobj1.SPSubgroupid(chkproducts.Items[i].Text, FADbname).ToString();

                        }
                        else if (subgroupid != "")
                        {
                            subgroupid += "," + sobj1.SPSubgroupid(chkproducts.Items[i].Text, FADbname).ToString();
                        }
                    }


                }

            }
            hd_subgroupid.Value = subgroupid.ToString();
            txt_workprocess.Text = name;




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
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void loadgridlog()
        {
            GridViewlog.Visible = true;
            Panel2.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
           // DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1926, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1926, "", "", "", Session["StrTranType"].ToString());
            }



            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

    }
}
