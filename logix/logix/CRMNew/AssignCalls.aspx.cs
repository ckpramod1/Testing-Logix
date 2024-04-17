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
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Web.Security;
using System.Collections;

namespace logix.CRM
{
    public partial class AssignCalls : System.Web.UI.Page
    {
        string statusval;
        DataAccess.CRMNew.TeleCaller obj_main = new DataAccess.CRMNew.TeleCaller();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterEmployee obj_emp = new DataAccess.Masters.MasterEmployee();
        DataAccess.CRMNew.MasterCustomerProspective obj_MasterCustomer = new DataAccess.CRMNew.MasterCustomerProspective();
        DataTable dt_comm = new DataTable();
        DataTable dtstateFilter = new DataTable();
        DataTable dtDistFilter = new DataTable();
        DataTable dtLocationFilter = new DataTable();
        int stateid, distcid, locid;
        DataTable tempval = new DataTable();
        DataTable dtemp = new DataTable();
        string productid;
        int portid = 0;
        int employeeid;
        int totcustcount = 0;
        Boolean blnerr = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(GrdCustomer);
            // ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnClear);

            if (Session["Telesales"] != null)
            {
                FillNewCity();
                FillNEwCountry();
                GetNewGrade();
                FillNewCom();
                FillPincode();
                GrdCustomer.Visible = true;
                GrdCustomer.DataSource = null;
                GrdCustomer.DataSource = (DataTable)Session["Filtervale"];
                GrdCustomer.DataBind();
                txtEmpname.Focus();
                //btnClear.Text = "Cancel";
                btnClear.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                LblName.Visible = false;
                GridFill();
                Session["Telesales"] = null;
            }

            if (!IsPostBack)
            {
                popup_Cus.Hide();
                FillNewCity();
                FillNEwCountry();
                GetNewGrade();
                FillNewCom();
                FillPincode();
                // //  GridFill();
                txtEmpname.Focus();
                GrdCustomer.Visible = false;
                LblName.Visible = true;
                //btnClear.Text = "Cancel";
                btnClear.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                totcustcount = obj_MasterCustomer.getcustomerprospectivelist();
                LblName.Text = "There are " + totcustcount.ToString() + " Prospect Customers.Please use above Filter Criteria to fill the Prospect Customer List.";
            }
            else
            {
                //txtcustomer.Focus();
                ddlCountry.Enabled = true;
                dllCommdity.Enabled = true;
                //EmptyGridForPOL();
                ddlCity.Enabled = true;
                ddlCountry.Enabled = true;
                dllCommdity.Enabled = true;
                txtcustomer.Enabled = true;
                LblName.Visible = false;
                // btnClear.Text = "Back";
                //  CustListchk.Focus();
                //GrdCustomer.DataSource = Utility.Fn_GetEmptyDataTable();
                //GrdCustomer.DataBind();
            }


        }

        public void FillNewCity()
        {
            dt_comm = obj_MasterCustomer.GetPortnameNewcity();
            ddlCity.Items.Clear();
            ddlCity.Items.Add("City");
            for (int i = 0; i <= dt_comm.Rows.Count - 1; i++)
            {
                ddlCity.Items.Add(dt_comm.Rows[i]["portname"].ToString());
            }
            //ddlCity.DataSource = dt_comm;
            //ddlCity.DataTextField = "portname";
            //ddlCity.DataValueField = "portid";
            //ddlCity.DataBind();
        }

        public void FillPincode()
        {
            dt_comm = obj_MasterCustomer.SellocationnameNEWpincodeFilter();
            ddlPicode.Items.Clear();
            ddlPicode.Items.Add("Pincode");
            for (int i = 0; i <= dt_comm.Rows.Count - 1; i++)
            {
                ddlPicode.Items.Add(dt_comm.Rows[i]["pincode"].ToString());
            }
        }

        public void FillNEwCountry()
        {
            dt_comm = obj_MasterCustomer.GetCountryNew();
            ddlCountry.Items.Clear();
            ddlCountry.Items.Add("Country");
            for (int i = 0; i <= dt_comm.Rows.Count - 1; i++)
            {
                ddlCountry.Items.Add(dt_comm.Rows[i]["countryname"].ToString());
            }
            //ddlCountry.DataSource = dt_comm;
            //ddlCountry.DataTextField = "countryname";
            //ddlCountry.DataValueField = "countryid";
            //ddlCountry.DataBind();
        }

        public void FillNewCom()
        {
            dt_comm = obj_MasterCustomer.GetCommdityNew();
            dllCommdity.Items.Clear();
            dllCommdity.Items.Add("Commodity");

            for (int i = 0; i <= dt_comm.Rows.Count - 1; i++)
            {
                dllCommdity.Items.Add(dt_comm.Rows[i]["cargotype"].ToString());
            }
            //dllCommdity.DataSource = dt_comm;
            //dllCommdity.DataTextField = "cargotype";
            //dllCommdity.DataValueField = "commodityid";
            //dllCommdity.DataBind();
        }

        public void GetNewGrade()
        {
            dt_comm = obj_MasterCustomer.GetGradeNew();
            ddlGrade.Items.Clear();
            ddlGrade.Items.Add("Grade");
            for (int i = 0; i <= dt_comm.Rows.Count - 1; i++)
            {
                ddlGrade.Items.Add(dt_comm.Rows[i]["grade"].ToString());
            }
        }


        [WebMethod]
        public static List<string> GetEmpname(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterEmployee obj_branchmgr = new DataAccess.Masters.MasterEmployee();
            DataTable dt_Bgr = new DataTable();
            dt_Bgr = obj_branchmgr.GetLikeEmployee4CRM(prefix.Trim());
            List_Result = Utility.Fn_DatatableToList_int16Display(dt_Bgr, "empnamecode", "employeeid", "empname");
            return List_Result;
        }



        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.CRMNew.MasterCustomerProspective obj_MasterCustomer = new DataAccess.CRMNew.MasterCustomerProspective();
            DataTable dt_cusname = new DataTable();
            dt_cusname = obj_MasterCustomer.GetCustomerName(prefix.ToUpper().Trim());
            List_Result = Utility.Fn_DatatableToList_int16Display(dt_cusname, "customer", "customerid", "customername");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetRemarks(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.CRMNew.MasterCustomerProspective obj_MasterCustomer = new DataAccess.CRMNew.MasterCustomerProspective();
            DataTable dt_cusname = new DataTable();
            dt_cusname = obj_MasterCustomer.GetLikeRemarksNew(prefix.ToUpper().Trim());
            List_Result = Utility.Fn_DatatableToList_string(dt_cusname, "remarks", "remarks");
            return List_Result;
        }

        protected void CustListchk_SelectedIndexChanged(object sender, EventArgs e)
        {

            //ddlCountry.Enabled = true;
            //dllCommdity.Enabled = true;
            ddlCity.Items.Clear();
            ddlCountry.Items.Clear();
            dllCommdity.Items.Clear();

            //if (CustListchk.SelectedValue == "New")
            //{
            //    statusval = "N";
            //    GridFill();
            //    txtcustomer.Text = "";
            //    txtcustomer.Enabled = true;
            //    ddlCity.Enabled = true;
            //}
            //else if (CustListchk.SelectedValue == "Followup")
            //{
            //    statusval = "F";
            //    GridFill();
            //    txtcustomer.Text = "";
            //    txtcustomer.Enabled = true;
            //    ddlCity.Enabled = true;
            //}
            //else if (CustListchk.SelectedValue == "Both")
            //{
            //    statusval = "B";
            //    GridFill();
            //    txtcustomer.Text = "";
            //    txtcustomer.Enabled = true;
            //    ddlCity.Enabled = true;
            //}

            //btnClear.Text = "Cancel";
            btnClear.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }

        public void FillStateDll()
        {
            // GetStatus();
            LblName.Visible = false;
            employeeid = Convert.ToInt32(Session["LoginEmpId"]);
            dt_comm = obj_main.GetAllCustDetailsCallers(Convert.ToChar(statusval), employeeid);
            RemoveDuplicateRows(dt_comm, "states");
            if (dt_comm.Rows.Count > 1)
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Add("State");
                ddlCity.Items.Add("ALL");
                for (int i = 0; i <= dt_comm.Rows.Count - 1; i++)
                {
                    ddlCity.Items.Add(dt_comm.Rows[i]["states"].ToString());
                }
            }
            else
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Add("State");
                for (int i = 0; i <= dt_comm.Rows.Count - 1; i++)
                {
                    ddlCity.Items.Add(dt_comm.Rows[i]["states"].ToString());
                }
            }


        }

        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();
            foreach (DataRow dtRow in dTable.Rows)
            {
                if (hTable.Contains(dtRow[colName]))
                    duplicateList.Add(dtRow);
                else
                    hTable.Add(dtRow[colName], string.Empty);
            }
            foreach (DataRow dtRow in duplicateList)
                dTable.Rows.Remove(dtRow);
            return dTable;
        }

        public void FillDistcDll()
        {
            //GetStatus();
            LblName.Visible = false;
            DataTable Dtdist = new DataTable();
            employeeid = Convert.ToInt32(Session["LoginEmpId"]);
            if (ddlCity.SelectedValue == "ALL")
            {
                dt_comm = obj_MasterCustomer.GetPortnameNew();
                RemoveDuplicateRows(dt_comm, "portname");
                if (dt_comm.Rows.Count > 1)
                {
                    ddlCity.Items.Clear();
                    ddlCity.Items.Add("City");
                    ddlCity.Items.Insert(0, "ALL");

                    for (int i = 0; i <= dt_comm.Rows.Count - 1; i++)
                    {
                        ddlCity.Items.Insert(Convert.ToInt32(dt_comm.Rows[i]["portid"].ToString()), dt_comm.Rows[i]["portname"].ToString());
                    }
                }
                else
                {
                    ddlCity.Items.Clear();
                    ddlCity.Items.Add("City");
                    for (int i = 0; i <= dt_comm.Rows.Count - 1; i++)
                    {
                        ddlCity.Items.Insert(Convert.ToInt32(dt_comm.Rows[i]["portid"].ToString()), dt_comm.Rows[i]["portname"].ToString());
                    }
                }

            }
            else
            {
                dt_comm = obj_MasterCustomer.GetPortnameNew();
                //  stateid = obj_main.GetStateIDCRM(ddlCity.SelectedItem.Text.Trim());

                DataTable dtLi = new DataTable();
                DataView data1 = dt_comm.DefaultView;
                data1.RowFilter = "portid = '" + ddlCity.SelectedValue + "' ";
                dtLi = data1.ToTable();
                RemoveDuplicateRows(dtLi, "Portname");
                if (dtLi.Rows.Count > 1)
                {
                    // ddlCity.Items.Clear();
                    //ddlCity.Items.Add("City");
                    // ddlCity.Items.Insert(0, "ALL");
                    for (int i = 0; i <= dtLi.Rows.Count - 1; i++)
                    {
                        ddlCity.Items.Add(dt_comm.Rows[i]["Portname"].ToString());
                    }
                }
                else
                {
                    //ddlCity.Items.Clear();
                    // ddlCity.Items.Add("City");
                    for (int i = 0; i <= dtLi.Rows.Count - 1; i++)
                    {
                        ddlCity.Items.Add(dt_comm.Rows[i]["Portname"].ToString());
                    }
                }
            }

            //if (ddlCity.SelectedValue == "ALL")
            //{
            //    Dtdist = obj_main.GetFDistcName4CRMAllDDL(Convert.ToChar(statusval));
            //    ddlCountry.Items.Clear();
            //    ddlCountry.Items.Add("-- District --");
            //    ddlCountry.Items.Add("ALL");
            //    for (int i = 0; i <= Dtdist.Rows.Count - 1; i++)
            //    {
            //        ddlCountry.Items.Add(Dtdist.Rows[i]["DistrictName"].ToString());
            //    }
            //}
            //else
            //{
            //    stateid = obj_main.GetStateIDCRM(ddlCity.SelectedValue.Trim());
            //    Dtdist = obj_main.GETDistcDetails4CRM(stateid, Convert.ToChar(statusval));
            //    ddlCountry.Items.Clear();
            //    ddlCountry.Items.Add("-- District --");
            //    ddlCountry.Items.Add("ALL");
            //    for (int i = 0; i <= Dtdist.Rows.Count - 1; i++)
            //    {
            //        ddlCountry.Items.Add(Dtdist.Rows[i]["DistrictName"].ToString());
            //    }
            //}
        }

        public void FillLocationDll()
        {
            // GetStatus();
            LblName.Visible = false;
            employeeid = Convert.ToInt32(Session["LoginEmpId"]);
            DataTable Dtloc = new DataTable();
            dt_comm = obj_MasterCustomer.GetCountryNew();
            if (ddlCountry.SelectedValue == "ALL")
            {
                if (ddlCountry.SelectedValue == "ALL")
                {
                    RemoveDuplicateRows(dt_comm, "countryname");
                    if (dt_comm.Rows.Count > 1)
                    {
                        //dllCommdity.Items.Clear();
                        //dllCommdity.Items.Add("Location");
                        //dllCommdity.Items.Add("ALL");
                        for (int i = 0; i <= dt_comm.Rows.Count - 1; i++)
                        {
                            ddlCountry.Items.Add(dt_comm.Rows[i]["countryname"].ToString());
                        }
                    }
                    else
                    {
                        //dllCommdity.Items.Clear();
                        //dllCommdity.Items.Add("Location");                  
                        for (int i = 0; i <= dt_comm.Rows.Count - 1; i++)
                        {
                            ddlCountry.Items.Add(dt_comm.Rows[i]["countryname"].ToString());
                        }
                    }

                }
                else
                {
                    //stateid = obj_main.GetStateIDCRM(ddlCity.SelectedItem.Text.Trim());
                    DataTable dtLi = new DataTable();
                    DataView data1 = dt_comm.DefaultView;
                    data1.RowFilter = "countryid = '" + ddlCountry.SelectedValue + "' ";
                    dtLi = data1.ToTable();
                    RemoveDuplicateRows(dtLi, "countryname");
                    if (dtLi.Rows.Count > 1)
                    {
                        //dllCommdity.Items.Clear();
                        //dllCommdity.Items.Add("Location");
                        // dllCommdity.Items.Add("ALL");
                        for (int i = 0; i <= dtLi.Rows.Count - 1; i++)
                        {
                            ddlCountry.Items.Add(dtLi.Rows[i]["countryname"].ToString());
                        }
                    }
                    else
                    {
                        //dllCommdity.Items.Clear();
                        //dllCommdity.Items.Add("Location");
                        for (int i = 0; i <= dtLi.Rows.Count - 1; i++)
                        {
                            ddlCountry.Items.Add(dtLi.Rows[i]["countryname"].ToString());
                        }
                    }

                }

            }
            else
            {
                //int Distid = obj_main.GetDistcIDCRM(ddlCountry.SelectedValue.Trim());
                DataTable dtLi = new DataTable();
                DataView data1 = dt_comm.DefaultView;
                data1.RowFilter = "countryid = '" + ddlCountry.SelectedValue + "' ";
                dtLi = data1.ToTable();
                RemoveDuplicateRows(dtLi, "countryname");
                if (dtLi.Rows.Count > 1)
                {
                    //dllCommdity.Items.Clear();
                    //dllCommdity.Items.Add("Location");
                    //dllCommdity.Items.Add("ALL");
                    for (int i = 0; i <= dtLi.Rows.Count - 1; i++)
                    {
                        ddlCountry.Items.Add(dtLi.Rows[i]["countryname"].ToString());
                    }
                }
                else
                {
                    //dllCommdity.Items.Clear();
                    //dllCommdity.Items.Add("Location");
                    for (int i = 0; i <= dtLi.Rows.Count - 1; i++)
                    {
                        ddlCountry.Items.Add(dtLi.Rows[i]["countryname"].ToString());
                    }
                }


            }
        }

        private void GridFill()
        {
            LblName.Visible = false;
            ViewState["dt"] = new DataTable(); ;
            employeeid = Convert.ToInt32(Session["LoginEmpId"]);
            dt_comm = obj_MasterCustomer.GetTeleCalDetails(1, 0, 0, 0, "0");
            Session["NewDtState"] = "";
            Session["NewDtState"] = dt_comm;
            if (dt_comm.Rows.Count > 0)
            {
                GrdCustomer.Visible = true;
                GrdCustomer.DataSource = null;
                GrdCustomer.DataSource = dt_comm;
                GrdCustomer.DataBind();
                Session["Filtervale"] = dt_comm;
                //  ViewState["sort"] = "Asc";
                // FillStateDll();
            }
            else
            {
                GrdCustomer.DataSource = Utility.Fn_GetEmptyDataTable();
                GrdCustomer.DataBind();
                ScriptManager.RegisterStartupScript(btnClear, typeof(Button), "DataFound", "alertify.alert('Customer Names Not Available');", true);
                return;
            }
        }


        protected void txtcustomer_TextChanged(object sender, EventArgs e)
        {
            LblName.Visible = false;
            //CustListchk.ClearSelection();
            DataTable dt = new DataTable();
            if (txtcustomer.Text.ToUpper().Trim() != "")
            {
                if (HdnCusId.Value != "")
                {
                    //dt = obj_MasterCustomer.GetTeleCalDetails(0,0,0,Convert.ToInt32(HdnCusId.Value.ToString()));
                    //if (dt.Rows.Count > 0)
                    //{
                    GetIds();
                    //    GrdCustomer.DataSource = null;
                    //    GrdCustomer.DataSource = dt;
                    //    GrdCustomer.DataBind();
                    //}
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnClear, typeof(Button), "DataFound", "alertify.alert('Customer Not Available ');", true);
                    txtcustomer.Text = "";
                    txtcustomer.Focus();
                    EmptyGridForPOL();
                }

                //btnClear.Text = "Cancel";
                btnClear.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }
            else
            {
                HdnCusId.Value = "0";
                GetIds();
            }
        }

        private void EmptyGridForPOL()
        {
            //DataTable dtempty = new DataTable();
            //DataRow dr;
            //dtempty.Columns.Add("customerid");
            //dtempty.Columns.Add("customername");
            //dtempty.Columns.Add("ptc");
            //dtempty.Columns.Add("portname");
            //dtempty.Columns.Add("locationname");
            //dtempty.Columns.Add("pincode");
            //dtempty.Columns.Add("mobile");
            //dtempty.Columns.Add("landline");
            //dtempty.Columns.Add("address");
            //dtempty.Rows.Add(dtempty.NewRow());
            //GrdCustomer.DataSource = dtempty;
            //GrdCustomer.DataBind();
            //GrdCustomer.Rows[0].Visible = false;
            //GrdCustomer.Rows[0].Cells[0].Text = "No Data Found";
            //GrdCustomer.Rows[0].Visible = false;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            if (btnClear.ToolTip == "Cancel")
            {
                //CustListchk.ClearSelection();
                GridFill();
                txtcustomer.Text = "";
                //HdnCusId.Value = "";
                //ddlCountry.SelectedIndex = -1;
                //ddlCity.SelectedIndex = -1;
                //dllCommdity.SelectedIndex = -1;
                ////FillStateDll();
                //ddlCity.Items.Clear();
                //ddlCountry.Items.Clear();
                //dllCommdity.Items.Clear();
                //EmptyGridForPOL();
                ddlCity.SelectedIndex = -1;
                ddlCountry.SelectedIndex = -1;
                ddlProduct.SelectedIndex = -1;
                ddlGrade.SelectedIndex = -1;
                //btnClear.Text = "Back";
                btnClear.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
                LblName.Visible = false;
                ddlProduct.SelectedIndex = 0;
                txtRemarks.Text = "";
                txtEmpname.Text = "";
                txtEmpname.Focus();
                ddlPicode.SelectedIndex = -1;
                //ViewState["dt"] = "";
                //ViewState["sort"] = "";
                //Session["Check"] = null;
                //btnClear.Text = "Back";
                //Session["ddlstate"] = "";
                //Session["ddldistc"] = "";
                //Session["ddllocation"] = "";
                //Session["chkvalue"] = "";
                //Session["textcustomer"] = "";
            }
            else
            {
                this.Response.End();
            }
        }

        protected void GrdCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdCustomer.PageIndex = e.NewPageIndex;
            GrdCustomer.DataSource = (DataTable)Session["Filtervale"];
            GrdCustomer.DataBind();
            LblName.Visible = false;
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblName.Visible = false;
            if (ddlCity.SelectedIndex != -1)
            {
                hid_City.Value = "0";
                DataAccess.Masters.MasterPort obj_mp = new DataAccess.Masters.MasterPort();
                int portid = 0;
                GrdCustomer.Visible = true;

                portid = obj_mp.GetNPortid(ddlCity.SelectedValue);
                ddlCountry.Enabled = true;
                if (ddlCity.SelectedValue != "City")
                {
                    hid_City.Value = portid.ToString();
                    GetIds();
                }
                else if (ddlCity.SelectedValue == "City")
                {
                    GetIds();
                }
            }

            //-----------------------------------------------------------------------------
            //if(ddlCity.SelectedIndex != -1)
            //{
            //    FillDistcDll();
            //    ddlCountry.Enabled = true;
            //    if(ddlCity.SelectedValue == "ALL")f
            //    {
            //        dt_comm = new DataTable();
            //        dt_comm = obj_main.GetStateDetailsAll();
            //        if (dt_comm.Rows.Count > 0)
            //        {
            //            GrdCustomer.DataSource = dt_comm;
            //            GrdCustomer.DataBind();
            //            ViewState["dt"] = dt_comm;
            //            ViewState["sort"] = "Asc";
            //        }
            //        else
            //        {
            //            EmptyGridForPOL();
            //        }
            //    }
            //    else
            //    {
            //        dt_comm = new DataTable();
            //        stateid = obj_main.GetStateIDCRM(ddlCity.SelectedValue.Trim());
            //        dt_comm = obj_main.GETCRMCustomerStateWise(stateid);
            //        if (dt_comm.Rows.Count > 0)
            //        {
            //            GrdCustomer.DataSource = dt_comm;
            //            GrdCustomer.DataBind();
            //            ViewState["dt"] = dt_comm;
            //            ViewState["sort"] = "Asc";
            //        }
            //        else
            //        {
            //            EmptyGridForPOL();
            //        }
            //    }
            //    GrdCustomer.Visible = true;               
            //}
        }

        //private void GetStatus()
        //{
        //    if (CustListchk.SelectedValue == "New")
        //    {
        //        statusval = "N";
        //    }
        //    else if (CustListchk.SelectedValue == "Followup")
        //    {
        //        statusval = "F";
        //    }
        //    else if (CustListchk.SelectedValue == "Both")
        //    {
        //        statusval = "B";
        //    }
        //}

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblName.Visible = false;

            if (ddlCountry.SelectedIndex != -1)
            {
                hid_country.Value = "0";
                DataAccess.Masters.MasterCountry obj_cntry = new DataAccess.Masters.MasterCountry();
                int countryid = 0;
                countryid = obj_cntry.GetLikeCountryNAme(ddlCountry.SelectedValue);
                GrdCustomer.Visible = true;

                if (ddlCountry.SelectedValue != "Country")
                {
                    hid_country.Value = countryid.ToString();
                    GetIds();
                }
                if (ddlCountry.SelectedValue == "Country")
                {
                    GetIds();
                }
            }
        }

        private void Display(int cityid, int countryid, int commodityid, string grade, int product, int customerid, string pincode)
        {
            LblName.Visible = false;

            //GetTeleCalDetailsFilter(int empid, int commodityid, int productid, int customerid, string remarks, int cityid, int countryid, string grade, int pincode)
            DataTable dtt = new DataTable();
            int type = 1;
            GrdCustomer.Visible = true;

            employeeid = Convert.ToInt32(Session["LoginEmpId"]);

            dtt = obj_MasterCustomer.GetTeleCalDetailsFilterAC(employeeid, commodityid, product, customerid, txtRemarks.Text.Trim(), cityid, countryid, grade, pincode);
            if (dtt.Rows.Count > 0)
            {
                GrdCustomer.DataSource = dtt;
                GrdCustomer.DataBind();
                Session["Filtervale"] = dtt;
            }
            else
            {
                GrdCustomer.DataSource = Utility.Fn_GetEmptyDataTable();
                GrdCustomer.DataBind();
            }



            //if (cityid == 0 && countryid == 0 && commodityid == 0 && grade == "0" && product == 0 && customerid == 0)
            //{
            //    dtt = obj_MasterCustomer.GetTeleCalDetails(type, commodityid, product, customerid,"0");
            //    GrdCustomer.DataSource = dtt;
            //    GrdCustomer.DataBind();
            //    ViewState["Filtervale"] = dtt;
            //}
            //if (cityid == 0 && countryid == 0 && commodityid == 0 && grade == "0" && product == 0 && customerid == 0 && txtRemarks.Text!="")
            //{
            //    dtt = obj_MasterCustomer.GetTeleCalDetails(4, commodityid, product, customerid, txtRemarks.Text);
            //    GrdCustomer.DataSource = dtt;
            //    GrdCustomer.DataBind();
            //    ViewState["Filtervale"] = dtt;
            //}
            //if (cityid == 0 && countryid == 0 && commodityid == 0 && grade == "0" && product == 0 && customerid != 0)
            //{
            //    dtt = obj_MasterCustomer.GetTeleCalDetails(0, commodityid, product, customerid,"0");
            //    GrdCustomer.DataSource = dtt;
            //    GrdCustomer.DataBind();
            //    ViewState["Filtervale"] = dtt;
            //    return;
            //}
            //if (cityid != 0 || countryid != 0 || grade != "0")
            //{
            //    type = 1;
            //}

            //if (commodityid != 0 && product == 0)
            //{
            //    type = 2;
            //}

            //if (product != 0 && commodityid == 0)
            //{
            //    type = 2;
            //}

            //if (product != 0 && commodityid != 0)
            //{
            //    type = 3;
            //}
            //dtt = obj_MasterCustomer.GetTeleCalDetails(type, commodityid, product, customerid,"0");
            //DataTable obj_Dtuser = new DataTable();
            //DataView obj_dtview = new DataView(dtt);
            //if (cityid == 0 && countryid == 0 && commodityid == 0 && grade == "0" && product != 0 && customerid == 0)
            //{

            //    dtt = obj_MasterCustomer.GetTeleCalDetails(0, commodityid, product, customerid,"0");
            //    GrdCustomer.DataSource = dtt;
            //    GrdCustomer.DataBind();
            //    ViewState["Filtervale"] = dtt;
            //}

            //if (cityid != 0 && countryid != 0 && grade != "0")
            //{
            //    obj_dtview.RowFilter = "cityid=" + cityid + " and countryid=" + countryid + " and grade='" + grade + "'";
            //    obj_Dtuser = obj_dtview.ToTable();
            //    GrdCustomer.DataSource = obj_Dtuser;
            //    GrdCustomer.DataBind();
            //    ViewState["Filtervale"] = obj_Dtuser;
            //}
            //else if (cityid == 0 && countryid == 0 && grade != "0")
            //{
            //    obj_dtview.RowFilter = "grade='" + grade + "'";
            //    obj_Dtuser = obj_dtview.ToTable();
            //    GrdCustomer.DataSource = obj_Dtuser;
            //    GrdCustomer.DataBind();
            //    ViewState["Filtervale"] = obj_Dtuser;
            //}
            //else if (cityid != 0 && countryid == 0 && grade == "0")
            //{
            //    obj_dtview.RowFilter = "cityid=" + cityid;
            //    obj_Dtuser = obj_dtview.ToTable();
            //    GrdCustomer.DataSource = obj_Dtuser;
            //    GrdCustomer.DataBind();
            //    ViewState["Filtervale"] = obj_Dtuser;
            //}
            //else if (cityid != 0 && countryid == 0 && grade != "0")
            //{
            //    obj_dtview.RowFilter = "cityid=" + cityid + " and grade='" + grade + "'";
            //    obj_Dtuser = obj_dtview.ToTable();
            //    GrdCustomer.DataSource = obj_Dtuser;
            //    GrdCustomer.DataBind();
            //    ViewState["Filtervale"] = obj_Dtuser;
            //}
            //else if (cityid == 0 && countryid != 0 && grade == "0")
            //{
            //    obj_dtview.RowFilter = "countryid=" + countryid;
            //    obj_Dtuser = obj_dtview.ToTable();
            //    GrdCustomer.DataSource = obj_Dtuser;
            //    GrdCustomer.DataBind();
            //    ViewState["Filtervale"] = obj_Dtuser;
            //}
            //else if (cityid == 0 && countryid != 0 && grade != "0")
            //{
            //    obj_dtview.RowFilter = "countryid=" + countryid + " and grade='" + grade + "'";
            //    obj_Dtuser = obj_dtview.ToTable();
            //    GrdCustomer.DataSource = obj_Dtuser;
            //    GrdCustomer.DataBind();
            //    ViewState["Filtervale"] = obj_Dtuser;
            //}
            //else if (cityid != 0 && countryid != 0 && grade == "0")
            //{
            //    obj_dtview.RowFilter = "cityid=" + cityid + " and countryid=" + countryid;
            //    obj_Dtuser = obj_dtview.ToTable();
            //    GrdCustomer.DataSource = obj_Dtuser;
            //    GrdCustomer.DataBind();
            //    ViewState["Filtervale"] = obj_Dtuser;
            //}
            //else if (cityid == 0 && countryid != 0 && grade != "0")
            //{
            //    obj_dtview.RowFilter = "countryid=" + countryid + " and grade='" + grade + "'";
            //    obj_Dtuser = obj_dtview.ToTable();
            //    GrdCustomer.DataSource = obj_Dtuser;
            //    GrdCustomer.DataBind();
            //    ViewState["Filtervale"] = obj_Dtuser;
            //}

            //obj_Dtuser = obj_dtview.ToTable();

        }

        private void GetIds()
        {
            LblName.Visible = false;

            int cityid = 0;
            int countryid = 0;
            int commodityid = 0;
            string grade = "";
            int product = 0;
            int customerid = 0;
            string pincode = "";

            if (hid_City.Value == "" || hid_City.Value == "0")
            {

            }
            else
            {
                cityid = Convert.ToInt32(hid_City.Value);
            }

            if (hid_country.Value == "" || hid_country.Value == "0")
            {

            }
            else
            {
                countryid = Convert.ToInt32(hid_country.Value);
            }

            if (Hid_commm.Value == "" || Hid_commm.Value == "0")
            {

            }
            else
            {
                commodityid = Convert.ToInt32(Hid_commm.Value);
            }

            grade = hid_grage.Value;

            if (grade == "")
            {
                grade = "";
            }

            if (hid_product.Value == "" || hid_product.Value == "0")
            {

            }
            else
            {
                product = Convert.ToInt32(hid_product.Value);
            }

            if (HdnCusId.Value == "" || HdnCusId.Value == "0")
            {

            }
            else
            {
                customerid = Convert.ToInt32(HdnCusId.Value);
            }

            if (ddlPicode.SelectedValue == "" || ddlPicode.SelectedValue == "Pincode")
            {
                pincode = "";
            }
            else
            {
                pincode = ddlPicode.SelectedValue;
            }


            if (dllCommdity.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(btnUpdate, typeof(System.Web.UI.WebControls.Button), "CRM Sales", "alertify.alert('Please select the Commdity..');", true);
                dllCommdity.Focus();
                blnerr = false;
                return;
            }
            if (dllCommdity.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(btnUpdate, typeof(System.Web.UI.WebControls.Button), "CRM Sales", "alertify.alert('Please select the Commdity..');", true);
                dllCommdity.Focus();
                blnerr = false;
                return;
            }

            Display(cityid, countryid, commodityid, grade, product, customerid, pincode);
            //btnClear.Text = "Cancel";
            btnClear.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }


        protected void dllCommdity_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblName.Visible = false;

            GrdCustomer.Visible = true;

            if (dllCommdity.SelectedIndex != -1)
            {
                Hid_commm.Value = "0";
                int commodity = 0;
                commodity = obj_MasterCustomer.GetLikeCommodityNAme(dllCommdity.SelectedValue);
                if (dllCommdity.SelectedValue != "Commodity")
                {
                    Hid_commm.Value = commodity.ToString();
                    GetIds();

                }
                else
                {
                    if (dllCommdity.SelectedValue == "Commodity")
                    {
                        GetIds();

                    }





                }
            }

        }

        private void GetCurrentPageValue()
        {
            LblName.Visible = false;

            Session["ddlstate"] = ddlCity.SelectedItem.ToString();
            if (ddlCountry.SelectedValue != "")
            {
                Session["ddldistc"] = ddlCountry.SelectedItem.ToString();
            }
            else
            {
                Session["ddldistc"] = "";
            }

            if (dllCommdity.SelectedValue != "")
            {
                Session["ddllocation"] = dllCommdity.SelectedItem.ToString();
            }
            else
            {
                Session["ddllocation"] = "";
            }

            // Session["chkvalue"] = CustListchk.SelectedItem.ToString();
            Session["textcustomer"] = txtcustomer.Text;

        }

        protected void imgbutton_Click(object sender, ImageClickEventArgs e)
        {

            Session["Customerid"] = "";
            Session["CustomerName"] = "";
            Session["Address"] = "";
            Session["CRMCustMbl"] = "";
            Session["CRMCustLandline"] = "";

            if (GrdCustomer.Rows.Count > 0)
            {
                ImageButton btnsubmit = sender as ImageButton;
                GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
                int indexval = gRow.RowIndex;
                string val = GrdCustomer.DataKeys[gRow.RowIndex].Value.ToString();
                Session["Customerid"] = GrdCustomer.Rows[indexval].Cells[1].Text;
                Label txt2 = (Label)GrdCustomer.Rows[indexval].Cells[2].FindControl("reviewnew");
                Session["CustomerName"] = txt2.Text;
                DataTable dtaddr = new DataTable();
                dtaddr = obj_main.GetAllDetailsTeleSales(Convert.ToInt32(Session["Customerid"].ToString()));
                if (dtaddr.Rows.Count > 0)
                {
                    Session["Address"] = dtaddr.Rows[0]["address"].ToString().Trim();
                }
                Session["CRMCustMbl"] = dtaddr.Rows[0]["mobile"].ToString().Trim();
                Session["CRMCustLandline"] = dtaddr.Rows[0]["landline"].ToString().Trim();

                GetCurrentPageValue();
                // Response.Redirect("../CRM/CRMAppointmentDetails.aspx");
                Response.Redirect("../CRMNew/Customer.aspx");

               


            }
        }

        protected void GrdCustomer_Sorting(object sender, GridViewSortEventArgs e)
        {
            LblName.Visible = false;

            if (GrdCustomer.Rows.Count > 1)
            {
                DataTable dt1 = new DataTable();
                dt1 = (DataTable)ViewState["dt"];


                if (dt1.Rows.Count > 1)
                {
                    if (Convert.ToString(ViewState["sort"]) == "Asc")
                    {
                        dt1.DefaultView.Sort = e.SortExpression + " Desc";
                        ViewState["sort"] = "Desc";
                    }
                    else
                    {
                        dt1.DefaultView.Sort = e.SortExpression + " Asc";
                        ViewState["sort"] = "Asc";
                    }
                    GrdCustomer.DataSource = dt1;
                    GrdCustomer.DataBind();
                }
            }
        }

        protected void GrdCustomer_PreRender(object sender, EventArgs e)
        {

        }

        protected void imghelp_Click(object sender, ImageClickEventArgs e)
        {
            Session["helpmsg"] = "";
            Session["helpmsg"] = Environment.NewLine + "This screen allows the users to view the customer details to begin conversation to do the business with them. There are 3 options, New, Follow-up, Both.  Option “New” will show the list of potential customer details with them we have not yet commence the conversation. Option “Follow-up” will show the details of the Potential customer, with them the conversation has already started, and asked us to call us later. Option “Both” will show all the potential customer details.  User can filter the customer details by state-wise, District-wise and Location-wise.  Click on the right arrow  ”->“ to view the selected customer details and initiate the contact with them.";
            string strPopup = "<script language='javascript' ID='script1'>" + "window.open('Help.aspx?" + "','new window', 'top=100, left=200, width=429, height=507, dependant=no, location=0,titlebar=0,alwaysRaised=no, menubar=no, resizeable=0, scrollbars=no, toolbar=no, status=no, center=yes')" + "</script>";
            ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "Script1", strPopup, false);
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblName.Visible = false;

            GrdCustomer.Visible = true;

            if (ddlGrade.SelectedIndex != -1)
            {
                hid_grage.Value = "";
                if (ddlGrade.SelectedValue != "Grade")
                {

                    hid_grage.Value = ddlGrade.SelectedValue;
                    GetIds();

                }
                else
                {
                    if (ddlGrade.SelectedValue == "Grade")
                    {
                        GetIds();
                    }





                }
            }
        }

        protected void GrdCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdCustomer, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GrdCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrdCustomer.Visible = true;
            LblName.Visible = false;

            int index = 0;
            Session["Customer"] = "";
            Session["hidcustomer"] = "";

            if (GrdCustomer.Rows.Count > 0)
            {
                index = GrdCustomer.SelectedRow.RowIndex;
                Session["Customer"] = HttpUtility.HtmlDecode(GrdCustomer.Rows[index].Cells[1].Text);
                Session["hidcustomer"] = GrdCustomer.Rows[index].Cells[0].Text;
              //  Response.Redirect("../CRMNew/Customer.aspx");
                popup_Cus.Show();
                iframecost.Attributes["src"] = "../CRMNew/Customer.aspx";
               

            }




        }


        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrdCustomer.Visible = true;
            LblName.Visible = false;

            if (ddlProduct.SelectedIndex != -1)
            {
                hid_product.Value = "0";
                if (ddlProduct.SelectedValue != "Product")
                {


                    productid = ddlProduct.SelectedValue;
                    hid_product.Value = productid;
                    GetIds();


                }
                else
                {
                    if (ddlProduct.SelectedValue == "Product")
                    {

                        GetIds();
                    }





                }
            }
        }

        protected void txtRemarks_TextChanged(object sender, EventArgs e)
        {
            LblName.Visible = false;
            GrdCustomer.Visible = true;

            DataTable dt = new DataTable();
            if (txtRemarks.Text.ToUpper().Trim() != "")
            {

                //dt = obj_MasterCustomer.GetTeleCalDetails(0,0,0,Convert.ToInt32(HdnCusId.Value.ToString()));
                //if (dt.Rows.Count > 0)
                //{
                GetIds();
                //    GrdCustomer.DataSource = null;
                //    GrdCustomer.DataSource = dt;
                //    GrdCustomer.DataBind();
                //}
            }
            else
            {
                //ScriptManager.RegisterStartupScript(btnClear, typeof(Button), "DataFound", "alertify.alert('Customer Not Available ');", true);
                txtRemarks.Text = "";
               // GetIds();
                txtRemarks.Focus();
                EmptyGridForPOL();
            }

            //btnClear.Text = "Cancel";
            btnClear.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }

        //protected void txtpincode_TextChanged(object sender, EventArgs e)
        //{
        //    GrdCustomer.Visible = true;
        //    DataTable dt = new DataTable();
        //    if (txtpincode.Text.ToUpper().Trim() != "")
        //    {

        //        //dt = obj_MasterCustomer.GetTeleCalDetails(0,0,0,Convert.ToInt32(HdnCusId.Value.ToString()));
        //        //if (dt.Rows.Count > 0)
        //        //{
        //        GetIds();
        //        //    GrdCustomer.DataSource = null;
        //        //    GrdCustomer.DataSource = dt;
        //        //    GrdCustomer.DataBind();
        //        //}
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(btnClear, typeof(Button), "DataFound", "alertify.alert('Customer Not Available ');", true);
        //        txtcustomer.Text = "";
        //        txtcustomer.Focus();
        //        EmptyGridForPOL();
        //    }

        //    btnClear.Text = "Cancel";
        //}

        protected void chkall_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;
            LblName.Visible = false;

            CheckBox chkboxHead = (CheckBox)GrdCustomer.HeaderRow.FindControl("chkall");
            if (chkboxHead.Checked == true)
            {
                for (i = 0; i <= GrdCustomer.Rows.Count - 1; i++)
                {
                    CheckBox chkbox = (CheckBox)GrdCustomer.Rows[i].FindControl("chkSelect");

                    chkbox.Checked = true;
                }
            }
            else
            {
                for (i = 0; i <= GrdCustomer.Rows.Count - 1; i++)
                {
                    CheckBox chkbox = (CheckBox)GrdCustomer.Rows[i].FindControl("chkSelect");

                    chkbox.Checked = false;
                }
            }
        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            LblName.Visible = false;

            int i = 0;
            for (i = 0; i <= GrdCustomer.Rows.Count - 1; i++)
            {
                CheckBox chkbox = (CheckBox)GrdCustomer.Rows[i].FindControl("chkSelect");

                if (chkbox.Checked == true)
                {
                    chkbox.Checked = true;
                }
                else
                {
                    chkbox.Checked = false;
                }

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            LblName.Visible = false;
           
            int i = 0;
            if (hid_Empname.Value == "" || hid_Empname.Value == "0" || txtEmpname.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnClear, typeof(Button), "DataFound", "alertify.alert('Invalied Employee Name..');", true);
                return;
            }
           if (blnerr == false)
           {
              blnerr = true;
              return;
           }
            if (GrdCustomer.Rows.Count > 0)
            {
                for (i = 0; i <= GrdCustomer.Rows.Count - 1; i++)
                {
                    CheckBox chkbox = (CheckBox)GrdCustomer.Rows[i].FindControl("chkSelect");

                    int CustId = Convert.ToInt32(GrdCustomer.Rows[i].Cells[0].Text);
                    if (chkbox.Checked == true)
                    {
                        obj_MasterCustomer.UPdateTeleCallDetails(CustId, Convert.ToInt32(hid_Empname.Value));
                    }
                }
                ScriptManager.RegisterStartupScript(btnClear, typeof(Button), "DataFound", "alertify.alert('Update Successfully..');", true);
                
                GetIds();
            }
        }

        protected void ddlPicode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblName.Visible = false;

            GrdCustomer.Visible = true;
            DataTable dt = new DataTable();
            if (ddlProduct.SelectedIndex != -1)
            {
                if (ddlPicode.SelectedValue.ToUpper().Trim() != "")
                {
                    GetIds();
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(btnClear, typeof(Button), "DataFound", "alertify.alert('Invalid Pincode ');", true);
                    //txtcustomer.Text = "";
                    //txtcustomer.Focus();
                    //EmptyGridForPOL();
                }


                //btnClear.Text = "Cancel";
                btnClear.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }
        }

        protected void txtEmpname_TextChanged(object sender, EventArgs e)
        {
            LblName.Visible = false;

            //btnClear.Text = "Cancel";
            btnClear.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }
    }
}