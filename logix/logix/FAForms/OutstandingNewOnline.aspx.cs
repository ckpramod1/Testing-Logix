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

namespace logix.FAForms
{
    public partial class OutstandingNewOnline : System.Web.UI.Page
    {

        DateTime time = new DateTime();
        Boolean YesterDayData = true;
        Boolean flag = true;
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        DataAccess.Outstanding sobj1 = new DataAccess.Outstanding();
        DataTable dtage = new DataTable();
        DataAccess.FAMaster.MasterLedger ledgerobj = new DataAccess.FAMaster.MasterLedger();
        DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
        DataAccess.Outstanding outsobj = new DataAccess.Outstanding();
        int sgroupid = 0, groupid, ledgerid = 0;
        int customerid = 0;
        int saleid = 0;
        double cal = 0;
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
        int check = 0;
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
        string fcurr, Opstype;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            try
            {
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnClear);
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnExpertExcel);

                //if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
                //}
                txtSalesPerson.Visible = false;
                ChkTill.Visible = false;
                cboxSalesAgeing.Visible = false;
                txtSalesPerson.Visible = false;

                Vouyear = Convert.ToInt32(Session["Vouyear"].ToString());
                LogYear = Convert.ToInt32(Session["LogYear"].ToString());
                int stryear = Convert.ToInt32(DateTime.Now.Year.ToString());

                if (!IsPostBack)
                {
                    lbnl_logyear.Text = Session["LYEAR"].ToString();
                    //txtLedger.TextChanged += new EventHandler(txtLedger.TextChanged);
                    txtLedger.Focus();
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
                    txtSubGroupName.Enabled = false;
                    txtGroupName.Enabled = false;
                    // txtLedger.Enabled = false;
                    ddlcurency.Enabled = false;

                    DataTable dtempty = new DataTable();
                    if (dtempty.Rows.Count > 0)
                    {
                        grdvou.Visible = true;
                        grdvou.DataSource = dtempty;
                        grdvou.DataBind();
                    }
                    if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month < 3) || Vouyear == (DateTime.Now).Year)
                    {
                        txt_date.Text = Utility.fn_ConvertDate(da_obj_Log.GetDate().ToString()); //da_obj_Log.GetDate().ToShortDateString();
                    }
                    else
                    {
                        txt_date.Text = Utility.fn_ConvertDate("3/31/" + (Vouyear + 1));
                    }

                    if (Request.QueryString.ToString().Contains("bidcus"))
                    {
                        Session["LoginBranchid"] = Request.QueryString["bidcus"].ToString();
                        Panel2.Attributes["class"] = "TblGridS2";
                        row1.Attributes["class"] = "row1";
                    }
                    if (Request.QueryString.ToString().Contains("Ledgername"))
                    {
                        lnk_back.Visible = false;
                        btnClear.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                        Time = da_obj_Log.GetDate().Hour;
                        Date = da_obj_Log.GetDate();
                        //hid_date.Value = txt_date.Text;
                        txt_date.Text = Request.QueryString["Todate"].ToString();
                        hid_date.Value = txt_date.Text;
                        txtLedger.Text = Request.QueryString["Ledgername"].ToString();
                        hf_custname.Value = Request.QueryString["LedgerID"].ToString();
                        hf_custid.Value = Request.QueryString["hf_custid"].ToString();
                        txtLedger_TextChanged(sender, e);
                        if (cboxcheck.Checked == false)
                        {
                            cboxcheck.Checked = true;
                        }
                        btnGet_Click(sender, e);
                        txtLedger.ReadOnly = true;
                        div_crumbs.Visible = true;
                        return;
                    }
                }

                lnk_back.Visible = false;
                btnClear.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                Time = da_obj_Log.GetDate().Hour;
                Date = da_obj_Log.GetDate();
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

        protected void txtSubGroupName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sgroupid = 0;
                DataTable obj_dt = new DataTable();
                List<string> customername = new List<string>();
                DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

                if (hdf_name.Value != "")
                {
                    if (hdf_id.Value != "")
                    {
                        sgroupid = Convert.ToInt32(hdf_id.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            if (btnClear.ToolTip == "Cancel")
            {
                if (Request.QueryString.ToString().Contains("Ledgername"))
                {
                    ScriptManager.RegisterStartupScript(btnClear, typeof(Button), "DataFound", "alertify.alert('If you want to close the screen. Kindly use Pop-up close Icon');", true);
                    return;
                    return;
                }
                txtLedger.Focus();
                txtSubGroupName.Text = "";
                txtSalesPerson.Text = "";
                txtLedger.Text = "";
                txtSubGroupName.Enabled = false;
                txtGroupName.Enabled = false;
                ddlProduct.SelectedIndex = -1;
                ddlbranch.SelectedIndex = -1;
                ddlreceive.SelectedIndex = -1;
                txtGroupName.Text = "";
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
                if (txtLedger.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter LedgerName');", true);
                    return;
                }
                if (hdf_id.Value == "" || hdf_id.Value == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Subgroup');", true);
                    txtSubGroupName.Text = "";
                    txtSubGroupName.Focus();
                    return;

                }

                ddlProduct.SelectedIndex = -1;
                ddlbranch.SelectedIndex = -1;
                ddlcurency.SelectedIndex = -1;
                ledgerid = Convert.ToInt32(hf_custid.Value);
                sgroupid = Convert.ToInt32(hdf_id.Value);
                if (cboxcheck.Checked == true)
                {
                    check = 0;
                }
                Time = da_obj_Log.GetDate().Hour;
                flag = true;
                dwb_Clear();
                dt = new DataTable();
                Date = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)); //da_obj_Log.GetDate(); 

                int Tillyear;
                if (Date.Month <= 3)
                {
                    Tillyear = (Date.Year) - 1;
                }
                else
                {
                    Tillyear = (Date.Year);
                }

                if (Session["LoginBranchName"].ToString() == "CORPORATE")
                {
                    if (ChkTill.Checked == true)
                    {
                        dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), ledgerid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                        // dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                    }
                    else
                    {
                        if (hid_date.Value == Utility.fn_ConvertDate("3/31/" + (LogYear + 1)) || hid_date.Value != Utility.fn_ConvertDate(da_obj_Log.GetDate().ToString()))
                        {
                            ChkTill.Checked = true;
                            // dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), ledgerid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                            //Ruban For Zero Balnce
                            dt = outsobj.OutStandingNewLedgerTillDate(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), ledgerid, check);
                            // dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                        }
                        else
                        {
                            //Ruban for non zerop
                            dt = outsobj.OutStandingNewLedger(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), ledgerid, check);
                            //dt = outsobj.OutStandingNewLedger(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), ledgerid);
                            //  dt = outsobj.OutStandingNew(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                        }
                    }
                }
                else
                {
                    if (ChkTill.Checked == true)
                    {
                        //dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), ledgerid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                        dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                    }
                    else
                    {
                        //DateTime timecon = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text));
                        //if (timecon == Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)))
                        //{
                        /* if (hid_date.Value == Utility.fn_ConvertDate("3/31/" + (LogYear + 1)))
                         {
                             ChkTill.Checked = true;
                             //   dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                             dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                         }
                         else
                         {
                             // dt = outsobj.OutStandingNewBranch(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                             dt = outsobj.OutStandingNewLedger(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), ledgerid);
                         }*/
                        if (hid_date.Value == Utility.fn_ConvertDate("3/31/" + (LogYear + 1)) || hid_date.Value != Utility.fn_ConvertDate(da_obj_Log.GetDate().ToString()))
                        {
                            ChkTill.Checked = true;
                            // dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), ledgerid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                            
                            dt = outsobj.OutStandingNewLedgerTillDate(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), ledgerid, check);
                            // dt = outsobj.OutStandingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                        }
                        else
                        {
                         
                            dt = outsobj.OutStandingNewLedger(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), ledgerid, check);
                            //dt = outsobj.OutStandingNewLedger(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), ledgerid);
                            //  dt = outsobj.OutStandingNew(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));
                        }
                    }
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

                    if ((Session["LoginBranchName"].ToString()) == "CORPORATE")
                    {
                        ///ddlbranch.Items.Add("ALL");
                        ddlbranch.Items.Add("Branch");
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

                    if (Session["LoginBranchName"].ToString() != "CORPORATE")
                    {
                        ddlbranch.Enabled = false;
                    }

                    string[] b = new string[1];
                    b[0] = "trantype";
                    dtl = new DataTable();
                    dtl = dv.ToTable("name", true, b);

                    // ddlProduct.Items.Add("ALL");
                    ddlProduct.Items.Add("Product");
                    for (int i = 0; i <= dtl.Rows.Count - 1; i++)
                    {
                        if ((dtl.Rows[i]["trantype"].ToString()) != "")
                        {
                            ddlProduct.Items.Add(dtl.Rows[i]["trantype"].ToString());
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
                    //ddlcurency.Items.Add("ALL");
                    ddlcurency.Items.Add("Currency");
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

                    if (Session["LoginBranchName"].ToString() != "CORPORATE")
                    {
                        ddlbranch.Enabled = false;
                        GrdLW.Enabled = true;
                        //if (GrdLW.Rows.Count == 0)
                        //{
                        //    GridFilter();
                        //}
                        GridFilter();
                        if (GrdLW.Rows.Count > 0)
                        {
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[7].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[9].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[11].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[12].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[13].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[14].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[15].ForeColor = System.Drawing.Color.Maroon;
                            GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[16].ForeColor = System.Drawing.Color.Maroon;
                        }

                        double dr1 = 0, cr1 = 0;
                        /*for (int i = 0; i < GrdLW.Rows.Count - 1; i++)
                        {
                            if (!string.IsNullOrEmpty(GrdLW.Rows[i].Cells[6].Text))
                            {

                            }
                            else
                            {
                                GrdLW.Rows[i].Cells[6].Text = "0.00";
                            }
                            if (i == 0)
                            {
                                //GrdLW.Rows[i].Cells[14].Text = GrdLW.Rows[i].Cells[6].Text;
                            }
                            else
                            {
                                cr1 = Convert.ToDouble(GrdLW.Rows[i - 1].Cells[11].Text) + Convert.ToDouble(GrdLW.Rows[i].Cells[6].Text);
                                //GrdLW.Rows[i].Cells[14].Text = cr1.ToString("#,0.00");
                            }
                        }*/

                        ddlreceive.SelectedValue = "3";
                        //get_Ledger_filter();
                        return;
                    }
                    amt = 0;
                    overdue = 0;
                    DataTable dt1 = new DataTable();
                    dt1 = dt;
                    double cummm = 0;
                    DataRow dr = dt1.NewRow();

                    dr["curr"] = "Total";
                    dr["amount"] = dt1.Compute("sum(amount)", "");

                    dr["vamount"] = dt1.Compute("sum(vamount)", "");
                    dr["Receivedamount"] = dt1.Compute("sum(Receivedamount)", "");
                    dr["famount"] = dt1.Compute("sum(famount)", "");

                    dr["recefamount"] = dt1.Compute("sum(recefamount)", "");
                    dr["foverdue"] = dt1.Compute("sum(foverdue)", "");
                    dt1.Rows.Add(dr);
                    //GC.Collect();
                    GrdLW.DataSource = dt1;
                    GrdLW.DataBind();
                    //dt1.Dispose();                    
                    ddlreceive.SelectedValue = "3";
                    if (GrdLW.Rows.Count > 0)
                    {
                        GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                        GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[9].ForeColor = System.Drawing.Color.Maroon;
                        GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
                        GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[11].ForeColor = System.Drawing.Color.Maroon;
                        GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[12].ForeColor = System.Drawing.Color.Maroon;
                        GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[13].ForeColor = System.Drawing.Color.Maroon;
                        double dr1 = 0, cr1 = 0;
                        /*for (int i = 0; i < GrdLW.Rows.Count - 1; i++)
                        {
                            if (!string.IsNullOrEmpty(GrdLW.Rows[i].Cells[12].Text))//&& (GrdLW.Rows[i].Cells[15].Text != "OP" && !string.IsNullOrEmpty(GrdLW.Rows[i].Cells[15].Text))
                            {

                            }
                            else
                            {
                                GrdLW.Rows[i].Cells[12].Text = "0.00";
                            }
                            if (i == 0)
                            {
                                GrdLW.Rows[i].Cells[16].Text = GrdLW.Rows[i].Cells[12].Text;
                            }
                            else
                            {
                                cr1 = Convert.ToDouble(GrdLW.Rows[i - 1].Cells[16].Text) + Convert.ToDouble(GrdLW.Rows[i].Cells[12].Text);
                                GrdLW.Rows[i].Cells[16].Text = cr1.ToString("#,0.00");
                            }

                        }*/
                    }
                    else
                    {
                        GrdLW.DataSource = Utility.Fn_GetEmptyDataTable();
                        GrdLW.DataBind();
                    }

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
                        if (ddlbranch.SelectedItem.Text == "Branch")
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

                if (ddlcurency.SelectedValue == "Currency")
                {
                    fcurr = "NO";
                }
                else
                {
                    fcurr = "YES";
                }

                if (cboxLedgerAgeing.Checked == true)//|| Request.QueryString["FlgValue"].ToString() == "true"
                {
                    flag = false;
                    GrdLW.Visible = false;
                    ddlbranch.Enabled = false;
                    ddlProduct.Enabled = false;
                    DropDownList1.Enabled = false;
                    DropDownList2.Enabled = false;
                    ////txtLedger.Enabled = false;
                    //GrdAgeing.Visible = true;
                    GrdAgeingsales.Visible = false;
                    txtSalesPerson.Enabled = false;
                    //txtLedger.Enabled = false;
                    ddlcurency.Enabled = false;
                    cboxSalesAgeing.Checked = false;
                    int branch = 0;
                    if (cboxcheck.Checked == true)
                    {
                        check = 0;
                    }
                    else
                    {
                        check = 1;
                    }
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
                    sgroupid = Convert.ToInt32(hdf_id.Value);
                    branch = HREmpobj.GetBId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), ddlbranch.SelectedItem.Text);

                    GrdAgeing.Visible = false;
                    grd_ageingnew.Visible = true;

                    //if (Tillyear > 2013)
                    //{
                    if (ChkTill.Checked == true)
                    {
                        //dtage = outsobj.OutStdageingNewOnlineFormatnewfordate(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, HttpContext.Current.Session["FADbname"].ToString(), Convert.ToInt32(hf_custname.Value), check, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));

                        dtage = outsobj.OutStdageingNew_newfortilldate(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 0, sgroupid, Session["FADbname"].ToString(), Convert.ToInt32(hf_custname.Value), fcurr, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)));

                        ////  dtage = outsobj.OutStdageingNewTILLDATE(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), HttpContext.Current.Session["FADbname"].ToString());
                       // dtage = outsobj.OutStdageingNewOnlineFormatnew(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, HttpContext.Current.Session["FADbname"].ToString(), Convert.ToInt32(hf_custname.Value), check);
                    }
                    else
                    {
                        //dtage = outsobj.OutStdageingNew(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, HttpContext.Current.Session["FADbname"].ToString(), Convert.ToInt32(hf_custname.Value));
                     //keerthi dtage = outsobj.OutStdageingNewOnlineFormatnew(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, HttpContext.Current.Session["FADbname"].ToString(), Convert.ToInt32(hf_custname.Value), check);

                        dtage = outsobj.OutStdageingNew_new(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 0, sgroupid, Session["FADbname"].ToString(), Convert.ToInt32(hf_custname.Value), fcurr);

                    }
                    //}
                    //else
                    //{
                    //    dtage = outsobj.OutStdageingSchedule2013(99999, Convert.ToInt32(Session["LoginDivisionId"].ToString()), branch, sgroupid, Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), HttpContext.Current.Session["FADbname"].ToString(), Convert.ToInt32(hf_custname.Value));
                    //}

                    if (GrdAgeing.Visible == true)
                    {

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
                        }
                        GrdAgeing.Columns[1].HeaderText = "Ledger";
                        GrdAgeing.Columns[GrdAgeing.Columns.Count - 1].HeaderText = "Ledger Balance";
                        Session["dtage"] = dtage;
                      btnprint.Text = "View";
                        btnprint.ToolTip = "View";
                        btn_print1.Attributes["class"] = "btn ico-view";
                        //RAJ
                        ddlreceive.Enabled = false;
                        ddlreceive.SelectedValue = "3";

                    }

                    else
                    {

                        grd_ageingnew.DataSource = dtage;
                        grd_ageingnew.DataBind();
                        if (grd_ageingnew.Rows.Count > 0)
                        {
                            grd_ageingnew.Rows[grd_ageingnew.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.Maroon;
                            grd_ageingnew.Rows[grd_ageingnew.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.Maroon;
                            grd_ageingnew.Rows[grd_ageingnew.Rows.Count - 1].Cells[3].ForeColor = System.Drawing.Color.Maroon;
                            grd_ageingnew.Rows[grd_ageingnew.Rows.Count - 1].Cells[4].ForeColor = System.Drawing.Color.Maroon;
                            grd_ageingnew.Rows[grd_ageingnew.Rows.Count - 1].Cells[5].ForeColor = System.Drawing.Color.Maroon;
                            grd_ageingnew.Rows[grd_ageingnew.Rows.Count - 1].Cells[6].ForeColor = System.Drawing.Color.Maroon;
                            grd_ageingnew.Rows[grd_ageingnew.Rows.Count - 1].Cells[7].ForeColor = System.Drawing.Color.Maroon;
                            grd_ageingnew.Rows[grd_ageingnew.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                            grd_ageingnew.Rows[grd_ageingnew.Rows.Count - 1].Cells[9].ForeColor = System.Drawing.Color.Maroon;
                            //grd_ageingnew.Rows[GrdAgeing.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
                            //grd_ageingnew.Rows[GrdAgeing.Rows.Count - 1].Cells[11].ForeColor = System.Drawing.Color.Maroon;
                            //grd_ageingnew.Rows[GrdAgeing.Rows.Count - 1].Cells[12].ForeColor = System.Drawing.Color.Maroon;
                        }
                        grd_ageingnew.Columns[1].HeaderText = "Ledger";
                        grd_ageingnew.Columns[grd_ageingnew.Columns.Count - 1].HeaderText = "Ledger Balance";
                        Session["dtage"] = dtage;
                        btnprint.Text = "View";
                        btnprint.ToolTip = "View";
                        btn_print1.Attributes["class"] = "btn ico-view";
                        //RAJ
                        ddlreceive.Enabled = false;
                        ddlreceive.SelectedValue = "3";

                    }

                }
                else
                {
                    ddlreceive.Enabled = true;
                    ddlreceive.SelectedValue = "3";
                    flag = true;
                    ddlbranch.Enabled = true;
                    GrdAgeing.Visible = false;
                    GrdAgeingsales.Visible = false;
                    GrdLW.Visible = true;
                    ddlProduct.Enabled = true;
                    txtLedger.Enabled = true;
                    txtSalesPerson.Enabled = true;
                    btnprint.ToolTip = "Print";
                    grd_ageingnew.Visible = false;
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
                    //txtLedger.Enabled = false;
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

            if (ddlbranch.SelectedIndex != -1)
            {
                try
                {
                    if (ddlbranch.SelectedItem.Text != "Branch")
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
            if (ddlProduct.SelectedIndex != -1)
            {
                try
                {
                    if (ddlProduct.Text != "Product")
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
                            str_SelFormula = str_SelFormula + "  and customerid=" + customerid;//and customer =  '" + txtLedger.Text + "'
                        }
                        else
                        {
                            str_SelFormula = " customerid=" + customerid;//customer like '" + txtLedger.Text + "' and
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
                    if (ddlcurency.Text != "Currency")
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
            dr2["curr"] = "Total";
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

            if (GrdLW.Rows.Count > 0)
            {
                GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[9].ForeColor = System.Drawing.Color.Maroon;
                GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
                GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[11].ForeColor = System.Drawing.Color.Maroon;
                GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[12].ForeColor = System.Drawing.Color.Maroon;
                GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[13].ForeColor = System.Drawing.Color.Maroon;
                double cr1 = 0;
             
            }
            else
            {
                GrdLW.DataSource = Utility.Fn_GetEmptyDataTable();
                GrdLW.DataBind();
            }

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
                DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

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
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
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
            DataTable dtl1 = new DataTable();
            try
            {
                if (txtLedger.Text == "")
                {
                    //btnGet_Click(sender, e);
                    //return;
                    hf_custname.Value = "0";
                }
                else if (hf_custname.Value != "")
                {
                    if (hf_custid.Value != "")
                    {
                        customerid = Convert.ToInt32(hf_custid.Value);
                        dtl1 = ledgerobj.SelMasterLedger(customerid, Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        if (dtl1.Rows.Count > 0)
                        {
                            sgroupid = Convert.ToInt32(dtl1.Rows[0]["subgroupid"].ToString());
                            hdf_id.Value = sgroupid.ToString();
                            Session["sgpid"] = sgroupid;
                            groupid = Convert.ToInt32(dtl1.Rows[0]["groupid"].ToString());
                            Session["gpid"] = groupid;
                            hdf_groupdi.Value = groupid.ToString();

                            txtSubGroupName.Text = dtl1.Rows[0]["subgroupname"].ToString();
                            txtGroupName.Text = dtl1.Rows[0]["groupname"].ToString();
                        }
                    }

                }
                //  get_Ledger_filter();
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

            sgroupid = Convert.ToInt32(hdf_id.Value);
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
                sgroupid = Convert.ToInt32(hdf_id.Value);
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

                //if (Tillyear > 2013)
                //{
                //    if (st == "Total O/S" && Session["LoginBranchName"].ToString() == "CORPORATE")
                //    {
                //        //if (hid_groupid.Value == "12" || hid_groupid.Value=="13")
                //        if (sgroupid == 65)
                //        {

                //        }
                //        dtvou = outsobj.Getoutstd_breakuopdetails(Convert.ToInt32(Session["LoginEmpId"].ToString()), lid);

                //    }
                //    if (dtvou.Rows.Count == 0)
                //    {
                //        if (GrdAgeing.Columns[1].HeaderText == "Ledger")
                //        {
                //            dtvou = outsobj.Outstdagingvounew(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                //        }
                //        else
                //        {
                //            dtvou = outsobj.Outstdagingvounewsales(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                //        }
                //    }

                //}
                if (Tillyear > 2013)
                {
                    if (st == "Total O/S" && Session["LoginBranchName"].ToString() == "CORPORATE")////01-07-2022 HARI
                    {
                        ////if (hid_groupid.Value == "12" || hid_groupid.Value=="13")
                        //if (sgroupid == 65 || sgroupid == 59 || sgroupid == 44)
                        //{
                        //    dtvou = outsobj.Getoutstd_breakuopdetailsusd(Convert.ToInt32(Session["LoginEmpId"].ToString()), lid);
                        //}
                        //else
                        //{
                        //    dtvou = outsobj.Getoutstd_breakuopdetails(Convert.ToInt32(Session["LoginEmpId"].ToString()), lid);
                        //}
                        ////dtvou = outsobj.Getoutstd_breakuopdetails(Convert.ToInt32(Session["LoginEmpId"].ToString()), lid);

                        if (GrdAgeing.Columns[1].HeaderText == "Ledger")
                        {
                            if (sgroupid == 65 || sgroupid == 59 || sgroupid == 44)
                            {
                                dtvou = outsobj.Outstdagingvounewusd(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), 0);
                            }
                            else
                            {
                                dtvou = outsobj.Outstdagingvounew(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), 0);
                            }
                            // dtvou = outsobj.Outstdagingvounew(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                        }
                        else
                        {
                            dtvou = outsobj.Outstdagingvounewsales(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), 0);
                        }

                    }
                    if (dtvou.Rows.Count == 0)
                    {
                        if (GrdAgeing.Columns[1].HeaderText == "Ledger")
                        {
                            if (sgroupid == 65 || sgroupid == 59 || sgroupid == 44)
                            {
                                dtvou = outsobj.Outstdagingvounewusd(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                            }
                            else
                            {
                                dtvou = outsobj.Outstdagingvounew(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                            }
                            // dtvou = outsobj.Outstdagingvounew(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
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

                //RAJ
                txtGroupName.Visible = false;
                ddlreceive.Visible = false;
                /////////
                cboxLedgerAgeing.Enabled = false;
                cboxSalesAgeing.Enabled = false;
                custname.Text = GrdAgeing.Rows[index].Cells[1].Text;
                custname.Visible = true;
                txtSubGroupName.Visible = false;
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
                    if (GrdAgeingsales.Rows[index].Cells[6].Text == "")
                    {
                        opbal = 0;
                    }
                    else
                    {
                        opbal = Convert.ToDouble(GrdAgeingsales.Rows[index].Cells[6].Text);
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
                    txtSubGroupName.Visible = false;
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

                    if (GrdAgeingsales.Rows.Count > 0 && cboxSalesAgeing.Checked == true)
                    {
                        custname.Visible = false;
                        GrdAgeingsales.Visible = true;
                        txtSalesPerson.Visible = true;
                        cboxSalesAgeing.Visible = true;
                        txtSubGroupName.Visible = true;
                        btnGet.Visible = true;
                        btnClear.Visible = true;
                        btnExpertExcel.Visible = true;
                        ddlbranch.Visible = true;
                        ddlProduct.Visible = true;
                        txtLedger.Visible = true;
                        ddlcurency.Visible = true;
                        ChkTill.Visible = true;
                        txt_date.Visible = true;
                    }
                    else if (GrdAgeing.Rows.Count > 0 && cboxLedgerAgeing.Checked == true)
                    {
                        custname.Visible = false;
                        GrdAgeing.Visible = true;
                        txtSalesPerson.Visible = true;
                        cboxLedgerAgeing.Visible = true;
                        cboxSalesAgeing.Visible = true;
                        txtSubGroupName.Visible = true;
                        btnGet.Visible = true;
                        btnClear.Visible = true;
                        btnExpertExcel.Visible = true;
                        ddlbranch.Visible = true;
                        ddlProduct.Visible = true;
                        txtLedger.Visible = true;
                        ddlcurency.Visible = true;
                        ChkTill.Visible = true;
                        txt_date.Visible = true;
                    }
                }

                //RAJ
                ChkTill.Visible = false;
                txtSalesPerson.Visible = false;
                cboxSalesAgeing.Visible = false;

                txtGroupName.Visible = true;
                ddlreceive.Visible = true;
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

        protected void btnExpertExcel_Click(object sender, EventArgs e)
        {
            string str = "";
            //DataTable dt1 =(DataTable)Session["Data"];
            if (GrdLW.Visible == true && GrdLW.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                //Response.AddHeader("content-disposition", "attachment;filename=VoucherwiseDetails.xls");
                Response.AddHeader("content-disposition", "attachment;filename=" + txtSubGroupName.Text + "-VOUCHER WISE DETAILS " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt") + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter sw = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(sw);
                //GrdLW.Columns[16].Visible = false;
                GrdLW.AllowPaging = false;

                int Count = GrdLW.Columns.Count;

                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + Count + "><font face=arial size=3;><B> CompanyName :: " + Session["LoginDivisionName"].ToString() + "</B></font></td></tr><br />");
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + Count + "><font face=arial size=1.5;><B> LedgerName :: " + txtLedger.Text + "</B></font></td></tr><br />");
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + Count + "><font face=arial size=1.5;><B> SubGroupName :: " + txtSubGroupName.Text + "</B></font></td></tr><br />");
                SB.Append("</table><br />");
                GrdLW.GridLines = GridLines.Both;
                GrdLW.HeaderStyle.Font.Bold = true;
                GrdLW.RenderControl(HtmlTextWriter);
                Response.Write(sw.ToString());
                Response.End();
            }
            if (grdvou.Visible == true && grdvou.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=VoucherwiseDetails.xls");
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
                //Response.AddHeader("content-disposition", "attachment;filename=AgeingWiseDetailsTill.xls");
                Response.AddHeader("content-disposition", "attachment;filename=" + txtSubGroupName.Text + "-LEDGERAGING WISE DETAILS " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt") + ".xls");
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
                //Response.AddHeader("content-disposition", "attachment;filename=SalesAgeingWiseDetails.xls");
                Response.AddHeader("content-disposition", "attachment;filename=" + txtSubGroupName.Text + "-SALESAGING WISE DETAILS " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt") + ".xls");
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
                Response.AddHeader("content-disposition", "attachment;filename=AgeingWiseDetailsTill.xls");
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
            else if (grd_ageingnew.Visible == true && grd_ageingnew.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                //Response.AddHeader("content-disposition", "attachment;filename=AgeingWiseDetailsTill.xls");
                Response.AddHeader("content-disposition", "attachment;filename=" + txtSubGroupName.Text + "-LEDGERAGING WISE DETAILS " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt") + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                grd_ageingnew.GridLines = GridLines.Both;
                grd_ageingnew.HeaderStyle.Font.Bold = true;
                grd_ageingnew.RenderControl(HtmlTextWriter);
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
            double dr = 0, cr = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].Text = HttpUtility.HtmlDecode(e.Row.Cells[i].Text);
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    double dbl_temp = 0;

                    if (double.TryParse(e.Row.Cells[5].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[5].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[5].Attributes.CssStyle["text-align"] = "Right";
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
                    if (double.TryParse(e.Row.Cells[11].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[11].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[11].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }

                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;

                }

                if (e.Row.Cells[21].Text != "")
                {
                    //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdLW, "Select$" + e.Row.RowIndex);
                    //e.Row.Attributes["style"] = "cursor:pointer";
                }

            }

            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                {
                    if (ddlcurency.Text == "Currency")
                    {
                        e.Row.Cells[5].Visible = true;
                        e.Row.Cells[6].Visible = true;
                        e.Row.Cells[7].Visible = true;
                        e.Row.Cells[8].Visible = false;
                        e.Row.Cells[9].Visible = false;
                        e.Row.Cells[10].Visible = false;

                    }
                    else
                    {
                        e.Row.Cells[5].Visible = false;
                        e.Row.Cells[6].Visible = false;
                        e.Row.Cells[7].Visible = false;
                        e.Row.Cells[8].Visible = true;
                        e.Row.Cells[9].Visible = true;
                        e.Row.Cells[10].Visible = true;

                    }
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

                    if (ddlcurency.SelectedValue == "Currency")
                    {
                        fcurr = "NO";
                    }
                    else
                    {
                        fcurr = "YES";
                    }
                    Str_Script = "window.open('../Reportasp/Outstanding_online_rpt.aspx?Branchid=" + Branchid + "&Ledger=" + hf_custname.Value + "&SubgroupID=" + hdf_id.Value + "&Date=" + string.Format("{0:dd-MMMMMMMMMMM-yyyy}", Getdate) + "&fcurr=" + fcurr.ToUpper().Trim() + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Outstanding", Str_Script, true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('No data available');", true);
                return;
            }

        }

        /* protected void GrdLW_RowCommand(object sender, GridViewCommandEventArgs e)
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
         }*/

        protected void ddlreceive_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtnew = new DataTable();
            if (hdf_id.Value == "" || hdf_id.Value == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Subgroup');", true);
                txtSubGroupName.Text = "";
                txtSubGroupName.Focus();
                return;

            }

            dt = outsobj.OutStandingNewLedger(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(hdf_id.Value), Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value)), Convert.ToInt32(hf_custname.Value));
            if (ddlreceive.SelectedItem.Text == "Receivable" && dt.Rows.Count > 0)
            {
                DataView dt_ldg = new DataView(dt);
                dt_ldg.RowFilter = "ledgertype='Dr'";

                dt = dt_ldg.ToTable();
                if (dt.Rows.Count > 0)
                {

                    dtnew = dt;
                    DataRow dr = dtnew.NewRow();
                    dr["containerno"] = "Total";
                    dr["vamount"] = dtnew.Compute("sum(vamount)", "");
                    dr["amount"] = dtnew.Compute("sum(amount)", "");
                    dr["famount"] = dtnew.Compute("sum(famount)", "");
                    dr["foverdue"] = dtnew.Compute("sum(foverdue)", "");
                    dtnew.Rows.Add(dr);
                    GrdLW.DataSource = dt;
                    GrdLW.DataBind();

                }
            }
            else if (ddlreceive.SelectedItem.Text == "Payable" && dt.Rows.Count > 0)
            {
                DataView dt_ldg = new DataView(dt);
                dt_ldg.RowFilter = "ledgertype='Cr'";

                dt = dt_ldg.ToTable();
                if (dt.Rows.Count > 0)
                {
                    dtnew = dt;
                    DataRow dr = dtnew.NewRow();
                    dr["containerno"] = "Total";
                    dr["vamount"] = dtnew.Compute("sum(vamount)", "");
                    dr["amount"] = dtnew.Compute("sum(amount)", "");
                    dtnew.Rows.Add(dr);
                    GrdLW.DataSource = dt;
                    GrdLW.DataBind();

                }
            }
            else if (ddlreceive.SelectedItem.Text == "Both" && dt.Rows.Count > 0)
            {
                dtnew = dt;
                DataRow dr = dtnew.NewRow();
                dr["containerno"] = "Total";
                dr["vamount"] = dtnew.Compute("sum(vamount)", "");
                dr["amount"] = dtnew.Compute("sum(amount)", "");
                dtnew.Rows.Add(dr);
                GrdLW.DataSource = dt;
                GrdLW.DataBind();
            }

            if (GrdLW.Rows.Count > 0)
            {
                GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[9].ForeColor = System.Drawing.Color.Maroon;
                GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
                GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[11].ForeColor = System.Drawing.Color.Maroon;
                GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[12].ForeColor = System.Drawing.Color.Maroon;
                GrdLW.Rows[GrdLW.Rows.Count - 1].Cells[13].ForeColor = System.Drawing.Color.Maroon;
                double cr1 = 0;
                for (int i = 0; i < GrdLW.Rows.Count - 1; i++)
                {
                    if (ddlcurency.Text == "Currency")
                    {
                        if (!string.IsNullOrEmpty(GrdLW.Rows[i].Cells[6].Text))//&& (GrdLW.Rows[i].Cells[15].Text != "OP" && !string.IsNullOrEmpty(GrdLW.Rows[i].Cells[15].Text))
                        {

                        }
                        else
                        {
                            GrdLW.Rows[i].Cells[6].Text = "0.00";
                        }
                        if (i == 0)
                        {
                            GrdLW.Rows[i].Cells[11].Text = GrdLW.Rows[i].Cells[6].Text;
                        }
                        else
                        {
                            cr1 = Convert.ToDouble(GrdLW.Rows[i - 1].Cells[11].Text) + Convert.ToDouble(GrdLW.Rows[i].Cells[6].Text);
                            //GrdLW.Rows[i].Cells[14].Text = cr1.ToString("#,0.00");
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(GrdLW.Rows[i].Cells[13].Text))//&& (GrdLW.Rows[i].Cells[15].Text != "OP" && !string.IsNullOrEmpty(GrdLW.Rows[i].Cells[15].Text))
                        {

                        }
                        else
                        {
                            GrdLW.Rows[i].Cells[13].Text = "0.00";
                        }
                        if (i == 0)
                        {
                            //GrdLW.Rows[i].Cells[14].Text = GrdLW.Rows[i].Cells[13].Text;
                        }
                        else
                        {
                            cr1 = Convert.ToDouble(GrdLW.Rows[i - 1].Cells[11].Text) + Convert.ToDouble(GrdLW.Rows[i].Cells[13].Text);
                            //GrdLW.Rows[i].Cells[14].Text = cr1.ToString("#,0.00");
                        }
                    }

                }
            }
            else
            {
                GrdLW.DataSource = Utility.Fn_GetEmptyDataTable();
                GrdLW.DataBind();
            }

        }

        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //}

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{

        //}

        protected void grd_ageingnew_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void grd_ageingnew_RowCommand(object sender, GridViewCommandEventArgs e)
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

            if (grd_ageingnew.Rows.Count > 0)
            {
                index = selectedRowIndex;
                cindex = selectedColumnIndex;
                int gridViewCellCount = grd_ageingnew.Rows[0].Cells.Count;
                //lid = Convert.ToInt32(GrdAgeing.Rows[index].Cells[13].Text);
                lid = Convert.ToInt32(grd_ageingnew.DataKeys[index].Values[0].ToString());
                if (grd_ageingnew.Rows[index].Cells[8].Text == "")
                {
                    opbal = 0;
                }
                else
                {
                    opbal = Convert.ToDouble(grd_ageingnew.Rows[index].Cells[8].Text);
                }

                st = grd_ageingnew.Columns[selectedColumnIndex].HeaderText;
                sgroupid = Convert.ToInt32(hdf_id.Value);
                branch = HREmpobj.GetBId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), ddlbranch.SelectedItem.Text);
                string CustomerName = grd_ageingnew.Rows[index].Cells[1].Text.Replace("&amp;", " ");
                string Branch = "";

                dtvou = new DataTable();
                if (st == "0-30Days")
                {
                    fda = 1;
                    tda = 30;
                }
                else if (st == "30Days")
                {
                    fda = 31;
                    tda = 45;
                }
                else if (st == "45 Days")
                {
                    fda = 46;
                    tda = 60;
                }
                else if (st == "60 Days")
                {
                    fda = 61;
                    tda = 75;
                }
                else if (st == "75 Days")
                {
                    fda = 76;
                    tda = 90;
                }
                else if (st == "90 Days")
                {
                    fda = 91;
                    tda = 120;
                }
                else if (st == "120 Days")
                {
                    fda = 121;
                    tda = 400;
                }
                //else if (st == "181~365")
                //{
                //    fda = 181;
                //    tda = 365;
                //}
                //else if (st == ">=366")
                //{
                //    fda = 366;
                //    tda = 400;
                //}
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

                //if (Tillyear > 2013)
                //{
                //    if (st == "Total O/S" && Session["LoginBranchName"].ToString() == "CORPORATE")
                //    {
                //        //if (hid_groupid.Value == "12" || hid_groupid.Value=="13")
                //        if (sgroupid == 65)
                //        {

                //        }
                //        dtvou = outsobj.Getoutstd_breakuopdetails(Convert.ToInt32(Session["LoginEmpId"].ToString()), lid);

                //    }
                //    if (dtvou.Rows.Count == 0)
                //    {
                //        if (grd_ageingnew.Columns[1].HeaderText == "Ledger")
                //        {
                //            dtvou = outsobj.Outstdagingvounew(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                //        }
                //        else
                //        {
                //            dtvou = outsobj.Outstdagingvounewsales(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                //        }
                //    }

                //}
                if (Tillyear > 2013)
                {
                    if (st == "Total O/S" && Session["LoginBranchName"].ToString() == "CORPORATE") ////05-07-2022 HARI
                    {
                        ////if (hid_groupid.Value == "12" || hid_groupid.Value=="13")
                        //if (sgroupid == 65 || sgroupid == 59 || sgroupid == 44)
                        //{
                        //    dtvou = outsobj.Getoutstd_breakuopdetailsusd(Convert.ToInt32(Session["LoginEmpId"].ToString()), lid);
                        //}
                        //else
                        //{
                        //    dtvou = outsobj.Getoutstd_breakuopdetails(Convert.ToInt32(Session["LoginEmpId"].ToString()), lid);
                        //}
                        ////dtvou = outsobj.Getoutstd_breakuopdetails(Convert.ToInt32(Session["LoginEmpId"].ToString()), lid);

                        if (GrdAgeing.Columns[1].HeaderText == "Ledger")
                        {
                            if (sgroupid == 65 || sgroupid == 59 || sgroupid == 44)
                            {
                                dtvou = outsobj.Outstdagingvounewusd(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), 0);
                            }
                            else
                            {
                                dtvou = outsobj.Outstdagingvounew(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), 0);
                            }
                            // dtvou = outsobj.Outstdagingvounew(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                        }
                        else
                        {
                            dtvou = outsobj.Outstdagingvounewsales(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), 0);
                        }

                    }
                    if (dtvou.Rows.Count == 0)
                    {
                        if (GrdAgeing.Columns[1].HeaderText == "Ledger")
                        {
                            if (sgroupid == 65 || sgroupid == 59 || sgroupid == 44)
                            {
                                dtvou = outsobj.Outstdagingvounewusd(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                            }
                            else
                            {
                                dtvou = outsobj.Outstdagingvounew(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                            }
                            // dtvou = outsobj.Outstdagingvounew(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                        }
                        else
                        {
                            dtvou = outsobj.Outstdagingvounewsales(lid, fda, tda, Convert.ToInt32(Session["LoginEmpId"].ToString()), HttpContext.Current.Session["FADbname"].ToString(), branch);
                        }
                    }

                }
                else
                {
                    if (grd_ageingnew.Columns[1].HeaderText == "Ledger")
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

                //RAJ
                txtGroupName.Visible = false;
                ddlreceive.Visible = false;
                /////////
                cboxLedgerAgeing.Enabled = false;
                cboxSalesAgeing.Enabled = false;
                custname.Text = grd_ageingnew.Rows[index].Cells[1].Text;
                custname.Visible = true;
                txtSubGroupName.Visible = false;
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
                grd_ageingnew.Visible = false;
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
            }

        }

    }
}

