using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Diagnostics;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Mail;



namespace logix.FAForm
{
    public partial class Quotation : System.Web.UI.Page
    {
       
        public string strFName = "", strSF = "", strPM = "";
        string straddress, intzip;
        public string strapproved;
        string strcity;
        string custtype;
        Boolean blnapprove;
        string oldbase;
        string shipment_dt;
        string intapprovedbyid;
        int app = 0;
        public int flag;
        static public string strtrantype;
        static int strapprovedby;
        string strtran;
        string intShipment;
        string intcustid;
        int quotid;
        int intchargeid;
        string Strshipment;
        string strfstatus;
        int OldQuotNo;
        static string sendqry,pdt;
        string mailid="";
      static  string straddress1, zipcode;

        int intpol, intpod, intpor, intfd;
        Boolean blnexists;
        DataTable Dt = new DataTable();
        DataTable dtQuot = new DataTable();
        DataTable dtBooking = new DataTable();
        DataTable dtcrm = new DataTable();
        DataTable dtlf = new DataTable();
        DataTable dtfill = new DataTable();
        DataSet dsnew = new DataSet();
        int customerid, cargoid, sales, prepared, hazard;
        DataTable obj_dtQuot = new DataTable();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterEmployee employee = new DataAccess.Masters.MasterEmployee();
        DataAccess.Marketing.Booking booking = new DataAccess.Marketing.Booking();
        DataAccess.Marketing.Quotation quotation = new DataAccess.Marketing.Quotation();
        DataAccess.Masters.MasterContainer container = new DataAccess.Masters.MasterContainer();
        DataAccess.Masters.MasterCharges charges = new DataAccess.Masters.MasterCharges();
        DataAccess.Masters.MasterPort port = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCustomer customer = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterCargo cargo = new DataAccess.Masters.MasterCargo();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();

        DataAccess.CRM.CRMSalesDetails objcrm = new DataAccess.CRM.CRMSalesDetails();
        static int pol, pod, por, fd;

        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        string Ctrl_List1;
        string Msg_List1;
        string Dtype_List1;

       // public ReportDocument rpt = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnclose);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();

                if (Session["salesfollowop"] != null)
                {
                    lblHeader.Text = "Quotation";
                    getsales();
                    return;
                }
                else
                {
                    lblHeader.Text = Request.QueryString["type"].ToString();
                }


                fillddl();
                Ctrl_List = txtCustomer.ID + "~" + txtCargo.ID + "~" + txtDescription.ID + "~" + txtPOR.ID + "~" + txtPOL.ID + "~" + txtPOD.ID + "~" + txtFD.ID + "~" + txtSalesPerson.ID;
                Msg_List = "Cuatomer Name ~Cargo ~ Description~POR~POL~POD~FDe~Sales Person";
                Dtype_List = "string~string~string~string~string~string~string";
                btnSave.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                Ctrl_List1 = txtCharges.ID + "~" + txtCurr.ID + "~" + txtRate.ID;
                Msg_List1 = "Charge Name ~Currency ~ Rate";
                Dtype_List1 = "string~string~string";
                btnAdd.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List1 + "','" + Msg_List1 + "','" + Dtype_List1 + "')");

                Utility.Fn_CheckUserRights(str_Uiid, btnSave, null, null);
                grdQuotation.DataSource = Utility.Fn_GetEmptyDataTable();
                grdQuotation.DataBind();

                grdBuying.DataSource = Utility.Fn_GetEmptyDataTable();
                grdBuying.DataBind();
                ddlpdt.Items.Add("Product");
                ddlpdt.Items.Add("Ocean Exports FCL");
                ddlpdt.Items.Add("Ocean Exports LCL");
                ddlpdt.Items.Add("Ocean Imports FCL");
                ddlpdt.Items.Add("Ocean Imports LCL");
                ddlpdt.Items.Add("Air Exports");
                ddlpdt.Items.Add("Air Imports");

                ddlBase.Items.Clear();
                ddlBase.Items.Add("BASE");
                //ddlBase.Items.Insert(0, "--BASE--");
                strtrantype = "FE";
                txtPreparedBy.Enabled = false;
                rdbBussiness.Checked = true;
                fillDetails();
                grdmail.DataSource = Utility.Fn_GetEmptyDataTable();
                grdmail.DataBind();
            }
            else if (Page.IsPostBack)
            {

                WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                int indx = wcICausedPostBack.TabIndex;
                var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                           where control.TabIndex > indx
                           select control;
                ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
            }

            grdQuotaionDetails.Visible = false;
            grdBuyingDetails.Visible = false;


        }
        protected Control GetControlThatCausedPostBack(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button || c is System.Web.UI.WebControls.ImageButton)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;
        }
        private void fillDetails()
        {



            grdQuotation.Enabled = false;


            btnclose.Enabled = true;

            txtDate.Enabled = false;
            if (flag == 0)
            {

                txtDate.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                txtValidTill.Text = DateTime.Parse(Logobj.GetDate().AddDays(15).ToShortDateString()).ToString("dd-MMM-yyyy");
                Calendarextender1.StartDate =  DateTime.Parse(Logobj.GetDate().ToShortDateString());

                linkQuotation.Enabled = true;

            }
            if (lblHeader.Text != "Quotation Approval")
            {
                if (strtrantype == "FE")
                {
                    lblHeader.Text = "Quotation";
                }
                else if (strtrantype == "FI")
                {
                    lblHeader.Text = "Quotation";
                }
                else if (strtrantype == "AE")
                {

                    ddlShipment.Enabled = false;
                    ddlShipment.Text = "FCL";


                }
                else if (strtrantype == "AI")
                {

                    ddlShipment.Enabled = false;
                    ddlShipment.Text = "FCL";
                }
                else if (strtran == "CC")
                {

                    ddlShipment.Enabled = true;
                    ddlShipment.Text = "FCL";
                }

            }
            //  btnclose.Text = "Back";
            if (lblHeader.Text == "Quotation Approval")
            {
                //btnApp.Text = "Approve";
                btnApp.ToolTip = "Approve";
                btn_app1.Attributes["class"] = "btn btn-approve1";
            }
            else
            {
                try
                {
                    txtPreparedBy.Text = Session["LoginEmpName"].ToString();
                    //btnApp.Text = "Delete";
                    btnApp.ToolTip = "Delete";
                    btn_app1.Attributes["class"] = "btn btn-delete1";
                }
                catch
                {
                    //ScriptManager.RegisterStartupScript(btnSave, typeof(Page), "alert", "alertify.alert('Session Expired. Login Again');", true);
                    //return;

                }
            }
            // txtPreparedBy.Text = Session["LoginEmpName"].ToString();
            if (lblHeader.Text == "Quotation Approval")
            {
                txtQuotation.ReadOnly = true;
                txtDate.Enabled = false;
                txtValidTill.Enabled = false;
                txtPreparedBy.ReadOnly = true;
                txtPreparedBy.Enabled = false;
                txtCustomer.ReadOnly = true;
                txtCargo.ReadOnly = true;
                chkHazard.Enabled = false;
                ddlShipment.Enabled = false;
                ddlFreight.Enabled = false;
                txtDescription.ReadOnly = true;
                txtPOL.ReadOnly = true;
                txtPOD.ReadOnly = true;
                txtPOR.ReadOnly = true;
                txtFD.ReadOnly = true;
                txtSalesPerson.ReadOnly = true;
                //txtBrokerage.ReadOnly = true;
                txtRemarks.ReadOnly = true;
                txtCharges.ReadOnly = true;
                txtCurr.ReadOnly = true;
                txtRate.ReadOnly = true;
                ddlBase.Enabled = false;
                ddlBase.BackColor = System.Drawing.Color.White;
                txtQuotation.BackColor = System.Drawing.Color.White;
                txtDate.BackColor = System.Drawing.Color.White;
                txtValidTill.BackColor = System.Drawing.Color.White;
                txtPreparedBy.BackColor = System.Drawing.Color.White;
                txtCustomer.BackColor = System.Drawing.Color.White;
                txtCargo.BackColor = System.Drawing.Color.White;
                chkHazard.BackColor = System.Drawing.Color.White;
                ddlShipment.BackColor = System.Drawing.Color.White;
                ddlFreight.BackColor = System.Drawing.Color.White;
                txtDescription.BackColor = System.Drawing.Color.White;
                txtPOL.BackColor = System.Drawing.Color.White;
                txtPOD.BackColor = System.Drawing.Color.White;
                txtPOR.BackColor = System.Drawing.Color.White;
                txtFD.BackColor = System.Drawing.Color.White;
                txtSalesPerson.BackColor = System.Drawing.Color.White;
                //  txtBrokerage.BackColor = System.Drawing.Color.White;
                txtRemarks.BackColor = System.Drawing.Color.White;
                txtCharges.BackColor = System.Drawing.Color.White;
                txtCurr.BackColor = System.Drawing.Color.White;
                txtRate.BackColor = System.Drawing.Color.White;
                btnApp.Visible = true;
                btnSave.Visible = false;
                btnView.Visible = false;
                btnAdd.Visible = false;
                rdbagent.Enabled = false;
                rdbBussiness.Enabled = false;

            }
            else
            {
                if (flag == 0)
                {
                    btnApp.Visible = false;
                    btnSave.Visible = true;
                    btnApp.Visible = true;
                    btnView.Visible = true;
                    btnAdd.Visible = true;

                    btnApp.Enabled = false;

                }


            }


        }

        private void txtchrgUnable()
        {
            txtCharges.Enabled = false;
            txtCurr.Enabled = false;
            txtRate.Enabled = false;
            ddlBase.Enabled = false;
        }
        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            // DataAccess.Masters.MasterCustomer obj_da_customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.Marketing.Quotation objQuotation = new DataAccess.Marketing.Quotation();
            obj_dt = objQuotation.GetLikeCustomerForSales(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()));
            //cargo = logix.Utility.Fn_DatatableToList_Customer(obj_dt, "customername", "customerid");
            customer = Utility.Fn_DatatableToList(obj_dt, "customername", "customerid");
            return customer;
        }
        [WebMethod]
        public static List<string> GetLikeCargo(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCargo FA = new DataAccess.Masters.MasterCargo();
            dt = FA.GetLikeCargo(prefix);
            list_result = Utility.Fn_TableToList(dt, "cargotype", "cargoid");
            return list_result;
        }
        [WebMethod]
        public static List<string> GetPOR(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            dt = obj_MasterPort.GetPortNameDetails(prefix);
            list_result = Utility.Fn_TableToList(dt, "portname", "portid");
            return list_result;

        }
        [WebMethod]
        public static List<string> GetPOD(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            dt = obj_MasterPort.GetPortNameDetails(prefix);
            list_result = Utility.Fn_TableToList(dt, "portname", "portid");
            return list_result;

        }
        [WebMethod]
        public static List<string> GetPOL(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            dt = obj_MasterPort.GetPortNameDetails(prefix);
            list_result = Utility.Fn_TableToList(dt, "portname", "portid");
            return list_result;

        }
        [WebMethod]
        public static List<string> GetFD(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            dt = obj_MasterPort.GetPortNameDetails(prefix);
            list_result = Utility.Fn_TableToList(dt, "portname", "portid");
            return list_result;

        }
        [WebMethod]
        public static List<string> GetSales(string prefix)
        {
            List<string> Sales = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterEmployee obj_da_employeeobj = new DataAccess.Masters.MasterEmployee();
            obj_dt = obj_da_employeeobj.GetLikeEmployee4Quot(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            Sales = Utility.Fn_DatatableToList_int16Display(obj_dt, "empnamecode", "employeeid", "empname");
            return Sales;
        }
        [WebMethod]
        public static List<string> GetChargename(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCharges chargesobj = new DataAccess.Masters.MasterCharges();
            DataTable dt_Location = new DataTable();
            dt_Location = chargesobj.GetLikeChargesName(prefix);

            List_Result = Utility.Fn_TableToList(dt_Location, "chargename", "chargeid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetCurrencyname(string prefix)
        {
            List<string> List_Result = new List<string>();
            // DataAccess.Masters.MasterCharges chargesobj = new DataAccess.Masters.MasterCharges();
            DataAccess.Marketing.Quotation quotation = new DataAccess.Marketing.Quotation();
            DataTable dt_Location = new DataTable();
            dt_Location = quotation.GetLikeCurrency(prefix);
            // List_Result = Utility.Fn_TableToList(dt_Location, "currency");
            List_Result = Utility.Fn_TableToList(dt_Location, "currency", "currency");
            return List_Result;
        }
        private void clear()
        {
            txtDate.Text = "";
            txtValidTill.Text = "";
            //txtPreparedBy.Text = "";
            txtBuying.Text = "";
            txtBuyingDetails.Text = "";
            txtCustomer.Text = "";
            chkHazard.Checked = false;

            ddlBase.Items.Clear();
            ddlBase.Items.Add("BASE");

            txtDescription.Text = "";
            txtPOR.Text = "";
            txtPOL.Text = "";
            txtPOD.Text = "";
            txtFD.Text = "";
            txtSalesPerson.Text = "";
            //txtBrokerage.Text = "";
            txtRemarks.Text = "";
            rdbagent.Checked = false;
            rdbBussiness.Checked = false;
            btnAdd.Enabled = false;
            //btnclose.Text = "Back";
            btnclose.ToolTip = "Back";
            btn_back1.Attributes["class"] = "btn ico-back";
            //btnSave.Text = "Save";
            btnSave.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            txtCargo.Text = "";
            txtCharges.Text = "";
            txtCurr.Text = "";
            txtRate.Text = "";

            grdBuying.Enabled = false;
            grdQuotation.Enabled = false;
            txtcrm.Text = "";
        }

        protected void linkBuying_Click(object sender, EventArgs e)
        {
            if (hdf_POL.Value != "" && hdf_POD.Value != "" && hdf_POR.Value != "" && hdf_FD.Value != "")
            {
                grdBuyingDetails.Visible = true;
                if (ddlShipment.Text != "" && txtPOL.Text != "" && txtPOD.Text != "")
                {
                    if (ddlShipment.Text == "FCL")
                    {
                        intShipment = "F";
                    }
                    else if (ddlShipment.Text == "LCL")
                    {
                        intShipment = "L";
                    }
                }
                intpol = Convert.ToInt32(hdf_POL.Value);
                intpod = Convert.ToInt32(hdf_POD.Value);
                intpor = Convert.ToInt32(hdf_POR.Value);
                intfd = Convert.ToInt32(hdf_FD.Value);
                dtQuot = booking.BuyingGrdDetails(intShipment, intpol, intpod, intpor, intfd);
                if (dtQuot.Rows.Count > 0)
                {
                    grdQuotaionDetails.Visible = false;
                    // grdBuyingDetails.Visible = true;
                    grdBuyingDetails.DataSource = dtQuot;
                    grdBuyingDetails.DataBind();
                    //shipment_dt=dtQuot.Rows[0]["shipment"].ToString();

                    this.popupBuying.Show();
                }
            }

        }

        protected void grdBuyingDetails_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdBuyingDetails, "Select$" + e.Row.RowIndex);

                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdBuyingDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fillddl();
            if (grdBuyingDetails.Rows.Count > 0)
            {
                int index = grdBuyingDetails.SelectedRow.RowIndex;
                string rate = grdBuyingDetails.SelectedRow.Cells[0].Text;
                string Customer = grdBuyingDetails.SelectedRow.Cells[1].Text;
                string pol = grdBuyingDetails.SelectedRow.Cells[2].Text;
                string pod = grdBuyingDetails.SelectedRow.Cells[3].Text;

                string buying = Customer + "/" + pol + "-" + pod + "/" + ddlShipment.Text;
                txtBuying.Text = rate;
                txtBuyingDetails.Text = buying;
                GetBuyingGrid();
                //btnclose.Text = "Cancel";
                btnclose.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }

        }
        private void GetBuyingGrid()
        {
            dtBooking = quotation.ChargeBuyingDetails(Convert.ToInt32(txtBuying.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (dtBooking.Rows.Count > 0)
            {
                grdBuying.DataSource = dtBooking;
                grdBuying.DataBind();
            }
        }


        private void ValidateFunction()
        {
            if (txtPOL.Text != "" && txtPOD.Text != "" && txtPOR.Text != "" && txtFD.Text != "")
            {
                if (txtPOL.Text == txtPOD.Text)
                {
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Page), "alert", "alertify.alert('PoL And PoD Should not Same');", true);
                    txtPOD.Focus();
                    return;
                }


                if (rdbagent.Checked == false && rdbBussiness.Checked == false)
                {
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Page), "alert", "alertify.alert('Please select Agent Controlled Business or Business Controlled By Us');", true);
                    return;
                }
            }



            if (ddlShipment.Text == "Shipment")
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(Page), "alert", "alertify.alert('Please select the Shipment');", true);
                ddlShipment.Focus();
                return;
            }
            if (ddlFreight.Text == "Freight")
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(Page), "alert", "alertify.alert('Please select the Freight');", true);
                ddlFreight.Focus();
                return;
            }




        }
        private void txtUnable()
        {
            ddlShipment.Enabled = false;
            ddlFreight.Enabled = false;
            txtQuotation.Enabled = false;
            chkHazard.Enabled = false;
            txtCargo.Enabled = false;
            txtDescription.Enabled = false;
            txtCustomer.Enabled = false;
            txtPOR.Enabled = false;
            txtPOL.Enabled = false;
            txtPOD.Enabled = false;
            txtFD.Enabled = false;
            txtSalesPerson.Enabled = false;
            // txtPreparedBy.Enabled = false;
            txtRemarks.Enabled = false;
            //  txtBrokerage.Enabled = false;
            btnSave.Enabled = false;
        }
        private void fillddl()
        {
            ddlShipment.Items.Add("Shipment");
            ddlFreight.Items.Add("Freight");

            ddlShipment.Items.Add("FCL");
            ddlShipment.Items.Add("LCL");
            ddlFreight.Items.Add("PrePaid");
            ddlFreight.Items.Add("ToCollect");
        }
        private void txtCargeEnable()
        {
            txtCharges.Enabled = true;
            txtCurr.Enabled = true;
            txtRate.Enabled = true;
            ddlBase.Enabled = true;
            btnAdd.Enabled = true;
        }
        private void CollectData()
        {
            if (chkHazard.Checked == true)
            {
                hdf_Hazard.Value = "1";
            }
            else
            {
                hdf_Hazard.Value = "0";
            }

            if (rdbBussiness.Checked == true)
            {
                hdf_Bussiness.Value = "O";
            }
            else
            {
                hdf_Bussiness.Value = "A";
            }
        }
        private void BaseFill()
        {
            ddlBase.Items.Clear();
            if (strtrantype == "FI" || strtrantype == "FE" || strtrantype == "CC")
            {
                DataSet ds = new DataSet();
                ds = container.GetContainersize();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dtpkg = new DataTable();
                    dtpkg = ds.Tables[0];

                    ddlBase.DataSource = dtpkg;
                    ddlBase.DataTextField = "conttype";
                    ddlBase.DataBind();

                    ddlBase.Items.Add("BL");
                    ddlBase.Items.Add("CBM");
                    ddlBase.Items.Add("MT");
                    //ddlBase.Items.Clear();
                    //ddlBase.Items.Add("BASE");
                  ddlBase.Items.Insert(0, "BASE");
                }
                for (int i = 0; i <= obj_dtQuot.Rows.Count - 1; i++)
                {
                    ddlBase.Items.Add(obj_dtQuot.Rows[i][0].ToString());
                }

            }
            else if (strtrantype == " AI" || strtrantype == "AE")
            {
                ddlBase.Items.Add("BASE");
                ddlBase.Items.Add("HWBL");
                ddlBase.Items.Add("KG");
            }
            else if (strtrantype == "CH")
            {
                ddlBase.Items.Add("BASE");
                ddlBase.Items.Add("DOC");
                ddlBase.Items.Add("KG");
            }


        }

        protected void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            DataTable dt = new DataTable();
            btnclose.ToolTip = "Close";
            btn_back1.Attributes["class"] = "btn btn-close1";
            hdf_customerid.Value = customer.GetCustomerid(txtCustomer.Text.ToUpper()).ToString();
            if (hdf_customerid.Value != "0")
            {
                //hdf_customerid.Value = dt.Rows[0]["customerid"].ToString();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Customer');", true);
                txtCustomer.Text = "";
                txtCustomer.Focus();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            oldbase = ddlBase.SelectedItem.Text;
            if (txtQuotation.Text != "")
            {
                dtQuot = quotation.CheckQuotForBookingFromQno(Convert.ToInt32(txtQuotation.Text), strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Q");
                if (dtQuot.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Booking Already done, can not amend create New Quotation');", true);
                }
            }

            if (btnAdd.Text == "Add")
            {
                if (txtQuotation.Text != "")
                {
                    quotid = Convert.ToInt32(txtQuotation.Text);
                    int chargeid = charges.GetChargeid(txtCharges.Text);
                    blnexists = quotation.CheckChargeExist(chargeid, quotid, ddlBase.SelectedItem.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    if (blnexists == false)
                    {
                        quotation.InsertChargeDetails(quotid, txtCharges.Text, txtCurr.Text, Convert.ToDouble(txtRate.Text), ddlBase.SelectedItem.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        dtQuot = quotation.ChargeDetails(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                        grdQuotation.DataSource = dtQuot;
                        grdQuotation.DataBind();
                        clearCharges();
                        txtCharges.Focus();
                        blnexists = false;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Charge Already exists for the selected Base');", true);
                        txtCharges.Focus();
                        dtQuot = quotation.ChargeDetails(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                        grdQuotation.DataSource = dtQuot;
                        clearCharges();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Kindly Save the Quotation');", true);
                    return;
                }
            }
            else
            {
                if (btnAdd.Text == "Upd")
                {
                    quotid = Convert.ToInt32(txtQuotation.Text);
                    int chargeid = charges.GetChargeid(txtCharges.Text);
                    quotation.UpdateGrdChargeDetails(quotid, txtCharges.Text, txtCurr.Text, Convert.ToDouble(txtRate.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), ddlBase.SelectedItem.Text, oldbase);
                    dtQuot = quotation.ChargeDetails(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                    grdQuotation.DataSource = dtQuot;
                    grdQuotation.DataBind();
                    clearCharges();
                    btnAdd.Text = "Add";
                }
            }

            //else
            //{
            //    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Quotation Invalid');", true);
            //}

        }
        private void clearCharges()
        {
            txtCharges.Text = "";
            txtCurr.Text = "";
            txtRate.Text = "";
            ddlBase.Items.Add("BASE");
            ddlFreight.Items.Add("FREIGHT");
            ddlShipment.Items.Add("SHIPMENT");
            ddlBase.Enabled = true;
            btnAdd.Enabled = true;
            txtCharges.Enabled = true;
            txtCurr.Enabled = true;
            txtRate.Enabled = true;
        }

        protected void linkQuotation_Click(object sender, EventArgs e)
        {
            if (ddlpdt.SelectedItem.Text == "Product")
            {
                ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Select the Product');", true);
                ddlpdt.Focus();
                return;
            }

            grdQuotaionDetails.Visible = true;
            if (lblHeader.Text == "Quotation Approval")
            {
                dtQuot = quotation.ApprovalPendingDetails(strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()));
            }
            else
            {
                if (txtCustomer.Text != "" && hdf_customerid.Value != "")
                {
                    dtQuot = quotation.QuotationDetailsCust(strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hdf_customerid.Value.ToString()));
                }
                else
                {
                    dtQuot = quotation.QuotationDetails(strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                }
            }
            if (dtQuot.Rows.Count > 0)
            {
                grdBuyingDetails.Visible = false;
                grdQuotaionDetails.DataSource = dtQuot;
                grdQuotaionDetails.DataBind();
                grdBuyingDetails.DataSource = dtQuot;
                pnlJobAE.Visible = true;
                this.popupQuot.Show();

            }
            else
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('No Quotation available to modify');", true);
            }
            btnSave.Enabled = true;
        }




        protected void grdQuotaionDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdQuotaionDetails, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdQuotaionDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            OldQuotNo = 0;
            grdQuotation.Visible = true;
            btnsend.Enabled = false;
            if (grdQuotaionDetails.Rows.Count > 0)
            {

                int index = grdQuotaionDetails.SelectedRow.RowIndex;
                quotid = Convert.ToInt32(grdQuotaionDetails.SelectedRow.Cells[0].Text);
                txtQuotation.Text = Convert.ToString(quotid);

                dtQuot = quotation.GetQuotationDetails(quotid, strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                if (dtQuot.Rows.Count > 0)
                {

                    txtQuotation.Text = Convert.ToString(quotid);
                    OldQuotNo = Convert.ToInt32(txtQuotation.Text);
                    customerid = Convert.ToInt32(dtQuot.Rows[0]["customerid"].ToString());
                    GetAllMailIds(customerid);
                    hdf_customerid.Value = Convert.ToString(customerid);
                    intpol = Convert.ToInt32(dtQuot.Rows[0]["pol"].ToString());
                    hdf_POL.Value = Convert.ToString(intpol);
                    intpor = Convert.ToInt32(dtQuot.Rows[0]["por"].ToString());
                    hdf_POR.Value = Convert.ToString(intpor);
                    intpod = Convert.ToInt32(dtQuot.Rows[0]["pod"].ToString());
                    hdf_POD.Value = Convert.ToString(intpod);
                    intfd = Convert.ToInt32(dtQuot.Rows[0]["fd"].ToString());
                    hdf_FD.Value = Convert.ToString(intfd);
                    cargoid = Convert.ToInt32(dtQuot.Rows[0]["cargoid"].ToString());
                    hdf_cargoid.Value = Convert.ToString(cargoid);
                    sales = Convert.ToInt32(dtQuot.Rows[0]["marketedby"].ToString());
                    hdf_salesperson.Value = Convert.ToString(sales);
                    prepared = Convert.ToInt32(dtQuot.Rows[0]["preparedby"].ToString());

                    hazard = Convert.ToInt32(dtQuot.Rows[0]["hazardous"].ToString());
                    hdf_Hazard.Value = Convert.ToString(hazard);
                    txtDescription.Text = dtQuot.Rows[0]["descn"].ToString();
                    string validtill = dtQuot.Rows[0]["validtill"].ToString();
                    txtValidTill.Text = DateTime.Parse(dtQuot.Rows[0]["validtill"].ToString()).ToString("dd-MMM-yyyy");

                    txtRemarks.Text = dtQuot.Rows[0]["remarks"].ToString();
                    // txtBrokerage.Text = dtQuot.Rows[0]["brokerage"].ToString();
                    Strshipment = quotation.GetShipment(Char.Parse(dtQuot.Rows[0]["stype"].ToString()));
                    strfstatus = quotation.GetFright(Char.Parse(dtQuot.Rows[0]["fstatus"].ToString()));
                    if (dtQuot.Rows[0]["approvedby"] != System.DBNull.Value)
                    {
                        strapprovedby = Convert.ToInt32(dtQuot.Rows[0]["approvedby"].ToString());
                    }
                    if (strapprovedby != 0)
                    {
                        btnsend.Enabled = true;
                    }


                    if (dtQuot.Rows[0]["business"].ToString() == "A")
                    {
                        rdbagent.Checked = true;
                        rdbBussiness.Checked = false;

                    }
                    else
                    {
                        rdbBussiness.Checked = true;
                        rdbagent.Checked = false;
                    }
                }

                txtCustomer.Text = customer.GetCustomername(customerid);
                txtPOL.Text = port.GetPortname(intpol);
                txtPOD.Text = port.GetPortname(intpod);
                txtPOR.Text = port.GetPortname(intpor);
                txtFD.Text = port.GetPortname(intfd);
                txtCargo.Text = cargo.GetCargoname(cargoid);
                txtSalesPerson.Text = employee.GetEmployeeName(sales);
                txtPreparedBy.Text = employee.GetEmployeeName(prepared);

                //Bhuvana
                int crmid = objcrm.GetCRMid(Convert.ToInt32(txtQuotation.Text.ToUpper()), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                if (crmid != 0)
                {
                    txtcrm.Text = crmid.ToString();
                }
                else
                {
                    txtcrm.Text = "";
                }
                if (hazard == 1)
                {
                    chkHazard.Checked = true;
                }
                else
                {
                    chkHazard.Checked = false;
                }
                ddlShipment.SelectedItem.Text = Strshipment;
                ddlFreight.SelectedItem.Text = strfstatus;
                dtQuot = quotation.ChargeDetails(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                grdQuotation.DataSource = dtQuot;
                grdQuotation.DataBind();
                btnApp.Enabled = true;
                //btnSave.Text = "Update";
                btnSave.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";

                Dt = quotation.CheckQuotForBookingFromQno(quotid, strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), "QB");
                if (Dt.Rows.Count > 0)
                {
                    string Customer = custobj.GetCustomername(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()));
                    string pol = portobj.GetPortname(Convert.ToInt32(Dt.Rows[0]["pol"].ToString()));
                    string pod = portobj.GetPortname(Convert.ToInt32(Dt.Rows[0]["pod"].ToString()));
                    string status;
                    if (Dt.Rows[0]["stype"].ToString() == "F")
                    {
                        status = "FCL";
                    }
                    else
                    {
                        status = "LCL";
                    }
                    string buying = Customer + "/" + pol + "-" + pod + "/" + status;
                    txtBuying.Text = Dt.Rows[0]["buyingno"].ToString();
                    txtBuyingDetails.Text = buying;

                    GetBuyingGrid();
                }
                else
                {
                    DataTable dtl = new DataTable();
                    BaseFill();
                }
                if (blnexists == true)
                {
                    btnApp.Enabled = true;
                    btnclose.Enabled = true;
                    blnapprove = false;
                }
                else
                {
                    btnApp.Enabled = false;

                    btnclose.Enabled = true;
                    txtCargeEnable();
                    if (lblHeader.Text == "Quotation Approval")
                    {
                        ddlBase.Enabled = false;
                    }
                    blnapprove = false;
                }

                txtCargeEnable();
                BaseFill();

            }
            if (lblHeader.Text == "Quotation Approval")
            {
                btnApp.Enabled = true;
            }
            btnclose.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }

      
        protected void grdQuotation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdQuotation, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                //Label lblReview = (Label)e.Row.FindControl("new");
                // string tooltip = lblReview.Text;
                // e.Row.Cells[1].Attributes.Add("title", tooltip);

            }
        }

        protected void grdQuotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdQuotation.Visible = true;
            if (grdQuotation.Rows.Count > 0)
            {
                int index = grdQuotation.SelectedRow.RowIndex;
                Label txt2 = (Label)grdQuotation.Rows[index].Cells[0].FindControl("Charges");
                Label txt3 = (Label)grdQuotation.Rows[index].Cells[2].FindControl("rate");


                //txtCharges.Text = grdQuotation.SelectedRow.Cells[0].Text;
                txtCurr.Text = grdQuotation.SelectedRow.Cells[1].Text;
                txtCharges.Text = txt2.Text;
               // txtCurr.Text = txt3.Text;
                txtRate.Text = txt3.Text;
                ddlBase.SelectedValue = grdQuotation.SelectedRow.Cells[3].Text;
                oldbase = ddlBase.SelectedItem.Text;
                txtCharges.Enabled = false;
                txtCurr.Enabled = true;
                txtRate.Enabled = true;
                ddlBase.Enabled = true;
                btnAdd.Enabled = true;
                btnApp.Enabled = true;
                btnSave.Enabled = false;

                btnAdd.Text = "Upd";
            }


        }

        protected void btnclose_Click(object sender, EventArgs e)
        {

            if (btnclose.ToolTip == "Cancel")
            {

                clearCharges();
                clear();

                btnAdd.Enabled = false;

                //ddlBase.SelectedItem.Text = "BASE";
                //ddlFreight.SelectedItem.Text = "Freight";
                //ddlShipment.SelectedItem.Text = "Shipment";
                ddlpdt.Items.Clear();
                ddlpdt.Items.Add("Product");
                ddlpdt.Items.Add("Ocean Exports FCL");
                ddlpdt.Items.Add("Ocean Exports LCL");
                ddlpdt.Items.Add("Ocean Imports FCL");
                ddlpdt.Items.Add("Ocean Imports LCL");
                ddlpdt.Items.Add("Air Exports");
                ddlpdt.Items.Add("Air Imports");

                //btnSave.Text = "Save";
                btnSave.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                btnAdd.Text = "Add";
                txtQuotation.Text = "";
                if (lblHeader.Text == "Quotation Approval")
                {
                    btnApp.Enabled = true;
                }
                else
                {
                    btnApp.Enabled = false;
                }
                linkQuotation.Enabled = true;
                grdQuotation.Enabled = false;

                btnSave.Enabled = false;
                btnclose.Enabled = true;
                btnView.Enabled = true;
                btnApp.Enabled = false;

                txtEnable();
                //btnclose.Text = "Back";
                btnclose.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
                rdbBussiness.Checked = true;
                txtDate.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                txtValidTill.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");


            
                linkQuotation.Enabled = true;

                grdBuying.DataSource = null;
                grdBuying.DataBind();

                grdQuotation.DataSource = null;
                grdQuotation.DataBind();

                grdQuotation.DataSource = Utility.Fn_GetEmptyDataTable();
                grdQuotation.DataBind();

                grdBuying.DataSource = Utility.Fn_GetEmptyDataTable();
                grdBuying.DataBind();

                grdmail.DataSource = Utility.Fn_GetEmptyDataTable();
                grdBuying.DataBind();
                
                ddlBase.Items.Clear();
                //ddlBase.Items.Add("--BASE--");
                btnsend.Enabled = false;

            }
            else
            {
               // this.Response.End();

                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                    else if (Session["StrTranType"].ToString() == "BR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");

                    }
                    else if (Session["StrTranType"].ToString() == "AC")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"] != null)
                    {
                        if (Session["home"].ToString() == "FABR")
                        {
                            Response.Redirect("../Home/Branch_home.aspx");
                        }
                        else if (Session["home"].ToString() == "FAFC")
                        {
                            Response.Redirect("../Home/CorporateHome.aspx");
                        }
                    }

                }
                else if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "FABR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"].ToString() == "FAFC")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                }
                else
                {
                    this.Response.End();
                }
            }
            //}


            //ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "alert", "alertify.alert('Booking Already used this Quotation ,Create New Quotation'" + Session["trantype"].ToString() + ");", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ValidateFunction();
            btnSave.Enabled = false;
            if (txtBuying.Text == "")
            {
                int i = 0;
                txtBuying.Text = Convert.ToString(i);
            }

            if (btnSave.ToolTip == "Save")
            {
                if (txtQuotation.Text != "")
                {
                }

                if (txtcrm.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('CRM # should not be Blank');", true);
                    btnSave.Enabled = true;
                    return;

                }
                btnApp.Enabled = false;
                btnAdd.Enabled = true;
                BaseFill();
                txtCargeEnable();
                CollectData();
                if (strtrantype == "FE" || strtrantype == "FI")
                {
                    if (ddlShipment.Text == "FCL")
                    {
                        if (grdBuying.Rows.Count > 0)
                        {
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Buy Rate Should be Mandatory');", true);
                            btnSave.Enabled = true;
                            return;
                        }
                    }
                }
                quotid = quotation.InsertQuotationDetails(Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtValidTill.Text), strtrantype, Convert.ToInt32(hdf_customerid.Value), Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value), Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.SelectedItem.Text, ddlFreight.SelectedItem.Text, Convert.ToInt32(hdf_cargoid.Value), txtDescription.Text, Convert.ToInt32(hdf_salesperson.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hdf_Hazard.Value), txtRemarks.Text.Trim(), "0", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtBuying.Text.Trim()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(hdf_Bussiness.Value));
                objcrm.InsCRM4Quot(Convert.ToInt32(txtcrm.Text), Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value), Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                txtQuotation.Text = Convert.ToString(quotid);
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Quotation # " + quotid + "\\n\\ Please Update the charge details');", true);
                txtUnable();

            }
            else
            {
                if (btnSave.ToolTip == "Update")
                {
                    quotid = Convert.ToInt32(txtQuotation.Text);
                    intapprovedbyid = Convert.ToString(1);
                    CollectData();
                    if (app == 0)
                    {

                        if (strtrantype == "FE")
                        {
                            if (ddlBase.Text == "FCL")
                            {
                                if (grdBuying.Rows.Count > 0)
                                {

                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Buy Rate Should be Mandatory');", true); 
                                    btnSave.Enabled = true;
                                    return;
                                }

                            }
                        }
                        quotation.UpdateQuotationDetails(quotid, Convert.ToDateTime(txtValidTill.Text), Convert.ToInt32(hdf_customerid.Value), Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value), Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.Text, ddlFreight.SelectedItem.Text, Convert.ToInt32(hdf_cargoid.Value), txtDescription.Text, Convert.ToInt32(hdf_salesperson.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hdf_Hazard.Value), strtrantype, txtRemarks.Text, "0", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtBuying.Text.Trim()), hdf_Bussiness.Value,"N");
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Quotation Details Updated');", true);
                    }
                    else
                    {

                        CollectData();
                        if (strtrantype == "FE")
                        {
                            if (ddlShipment.Text == "FCL")
                            {
                                if (grdBuying.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Buy Rate Should be Mandatory');", true);
                                    btnSave.Enabled = true;
                                    return;
                                }
                            }
                        }
                        quotid = quotation.InsertQuotationDetails(Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtValidTill.Text), strtrantype, Convert.ToInt32(hdf_customerid.Value), Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value), Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.SelectedItem.Text, ddlFreight.SelectedItem.Text, Convert.ToInt32(hdf_cargoid.Value), txtDescription.Text, Convert.ToInt32(hdf_salesperson.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hdf_Hazard.Value), txtRemarks.Text.Trim(), "0", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtBuying.Text.Trim()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(hdf_Bussiness.Value));
                        quotation.UpdQuotationValidTill(OldQuotNo, strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()));


                        txtQuotation.Text = Convert.ToString(quotid);
                        int j = 0;
                        for (j = 0; j >= grdQuotation.Rows.Count - 1; j++)
                        {
                            intchargeid = charges.GetChargeid(grdQuotation.Rows[j].Cells[0].Text);
                            blnexists = quotation.CheckChargeExist(intchargeid, quotid, ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                            if (blnexists == false)
                            {
                                quotation.InsertChargeDetails(quotid, txtCharges.Text, txtCurr.Text, Convert.ToDouble(txtRate.Text), ddlBase.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                clearCharges();
                                txtCharges.Focus();
                                blnexists = true;

                            }
                        }
                        dtQuot = quotation.ChargeDetails(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                        grdQuotation.DataSource = dtQuot;
                        grdQuotation.DataBind();
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Quotation # " + quotid + "');", true);

                    }
                    btnAdd.Enabled = true;
                    //btnSave.Text = "Save";
                    btnSave.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                    grdQuotation.Enabled = true;

                    txtCharges.Focus();
                    btnclose.Enabled = true;
                    btnView.Enabled = true;
                    btnApp.Enabled = true;
                    btnAdd.Enabled = true;
                    txtUnable();
                }

                txtCharges.Focus();
                btnSave.Enabled = false;
                btnApp.Enabled = false;

                //btnclose.Text = "Cancel";
                btnclose.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";

            }

        }


        private void txtEnable()
        {
            if (strtrantype == "AE" || strtrantype == "AI")
            {
                ddlShipment.Enabled = false;
            }
            else
            {
                //  ddlShipment.Enabled = true;
            }
            ddlFreight.Enabled = true;
            txtQuotation.Enabled = true;
            chkHazard.Enabled = true;
            txtCargo.Enabled = true;
            txtDescription.Enabled = true;
            txtCustomer.Enabled = true;
            txtPOR.Enabled = true;
            txtPOL.Enabled = true;
            txtPOD.Enabled = true;
            txtFD.Enabled = true;
            txtSalesPerson.Enabled = true;
            // txtPreparedBy.Enabled = true; 
            txtRemarks.Enabled = true;
            //txtBrokerage.Enabled = true; 
        }

        protected void txtQuotation_TextChanged(object sender, EventArgs e)
        {
            OldQuotNo = 0;
            if (ddlpdt.Text == "Product")
            {
                ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Select the Product');", true);
                ddlpdt.Focus();
                return;
            }
            if (txtQuotation.Text != "")
            {
                quotid = Convert.ToInt32(txtQuotation.Text);
                DataSet dsQuot = new DataSet();
                dtQuot = quotation.GetQuotationDetails(quotid, strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                dtQuot.TableName = "Test1";
                dsQuot.Tables.Add("Test1");
                if (dtQuot.Rows.Count > 0)
                {

                    txtQuotation.Text = Convert.ToString(quotid);
                    OldQuotNo = Convert.ToInt32(txtQuotation.Text);
                    customerid = Convert.ToInt32(dtQuot.Rows[0]["customerid"].ToString());
                    hdf_customerid.Value = Convert.ToString(customerid);
                    intpol = Convert.ToInt32(dtQuot.Rows[0]["pol"].ToString());
                    hdf_POL.Value = Convert.ToString(intpol);
                    intpor = Convert.ToInt32(dtQuot.Rows[0]["por"].ToString());
                    hdf_POR.Value = Convert.ToString(intpor);
                    intpod = Convert.ToInt32(dtQuot.Rows[0]["pod"].ToString());
                    hdf_POD.Value = Convert.ToString(intpod);
                    intfd = Convert.ToInt32(dtQuot.Rows[0]["fd"].ToString());
                    hdf_FD.Value = Convert.ToString(intfd);
                    cargoid = Convert.ToInt32(dtQuot.Rows[0]["cargoid"].ToString());
                    hdf_cargoid.Value = Convert.ToString(cargoid);
                    sales = Convert.ToInt32(dtQuot.Rows[0]["marketedby"].ToString());
                    hdf_salesperson.Value = Convert.ToString(sales);
                    prepared = Convert.ToInt32(dtQuot.Rows[0]["preparedby"].ToString());
                    hazard = Convert.ToInt32(dtQuot.Rows[0]["hazardous"].ToString());
                    hdf_Hazard.Value = Convert.ToString(hazard);
                    txtDescription.Text = dtQuot.Rows[0]["descn"].ToString();
                    // txtValidTill.Text = Utility.fn_ConvertDate(dtQuot.Rows[0]["validtill"].ToString());

                    txtValidTill.Text = DateTime.Parse(dtQuot.Rows[0]["validtill"].ToString()).ToString("dd-MMM-yyyy");
                    txtRemarks.Text = dtQuot.Rows[0]["remarks"].ToString();
                    // txtBrokerage.Text = dtQuot.Rows[0]["brokerage"].ToString();
                    Strshipment = quotation.GetShipment(Char.Parse(dtQuot.Rows[0]["stype"].ToString()));
                    strfstatus = quotation.GetFright(Char.Parse(dtQuot.Rows[0]["fstatus"].ToString()));
                    if (dtQuot.Rows[0]["business"].ToString() == "A")
                    {
                        rdbagent.Checked = true;
                        rdbBussiness.Checked = false;
                    }
                    else
                    {
                        rdbBussiness.Checked = true;
                        rdbagent.Checked = false;
                    }
                    app = Convert.ToInt32(dtQuot.Rows[0]["approvedby"].ToString());
                    //bhuvana
                    int crmid = objcrm.GetCRMid(Convert.ToInt32(txtQuotation.Text.ToUpper()), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    txtcrm.Text = crmid.ToString();
                    txtCustomer.Text = customer.GetCustomername(customerid);
                    txtPOL.Text = port.GetPortname(intpol);
                    txtPOD.Text = port.GetPortname(intpod);
                    txtPOR.Text = port.GetPortname(intpor);
                    txtFD.Text = port.GetPortname(intfd);
                    txtCargo.Text = cargo.GetCargoname(cargoid);
                    txtSalesPerson.Text = employee.GetEmployeeName(sales);
                    txtPreparedBy.Text = employee.GetEmployeeName(prepared);
                    if (app == 0)
                    {
                        txtEnable();
                    }
                    else
                    {
                        txtUnable();
                    }
                    if (hazard == 1)
                    {
                        chkHazard.Checked = true;
                    }
                    else
                    {
                        chkHazard.Checked = false;
                    }
                    ddlShipment.SelectedItem.Text = Strshipment;
                    ddlFreight.SelectedItem.Text = strfstatus;
                    dtQuot = quotation.ChargeDetails(quotid, Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                    if (dtQuot.Rows.Count > 0)
                    {
                        grdQuotation.DataSource = dtQuot;
                        grdQuotation.DataBind();
                    }
                    Dt = quotation.CheckQuotForBookingFromQno(quotid, strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), "QB");
                    if (Dt.Rows.Count > 0)
                    {
                        txtBuying.Text = Dt.Rows[0]["buyingno"].ToString();
                        GetBuyingGrid();
                    }
                    else
                    {
                        DataTable dt1 = new DataTable();
                        BaseFill();
                    }
                    btnclose.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                    btnclose.Enabled = true;
                    btnApp.Enabled = false;
                    txtCargeEnable();
                    grdQuotation.Enabled = true;

                }
                //btnSave.Text = "Update";
                btnSave.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";

            }

        }

        protected void txtCharges_TextChanged(object sender, EventArgs e)
        {
            ddlBase.Enabled = true;
            btnAdd.Enabled = true;
            txtCharges.Enabled = true;
            txtCurr.Enabled = true;
            txtRate.Enabled = true;
            if (lblHeader.Text == "")
            {
                dtQuot = charges.GetLikeCharges(txtCharges.Text);
                if (dtQuot.Rows.Count > 0)
                {
                    hdf_Charges.Value = dtQuot.Rows[0]["chargeid"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('Invalid Charge Name');", true);
                }
            }
        }

        protected void btnApp_Click(object sender, EventArgs e)
        {
            quotid = Convert.ToInt32(txtQuotation.Text);
            ValidateFunction();

            if (txtQuotation.Text != "" && txtCustomer.Text != "" && txtPOR.Text != "" && txtPOL.Text != "" && txtPOD.Text != "" && txtFD.Text != "")
            {
                CollectData();
                intapprovedbyid = Convert.ToString(1);
                DateTime appdate;
                appdate = Logobj.GetDate();
                strapproved = Session["LoginUserName"].ToString();
                if (grdQuotation.Rows.Count > 0)
                {
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Charges are not Available in this Quotation');", true);
                }
                int intpby;
                intpby = employee.GetNEmpid(txtPreparedBy.Text);
                int empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                if (intpby == empid)
                {
                    ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('You can not approve the Quotation prepared by you');", true);
                }
                else
                {
                    quotation.UpdateQuotationDetailsWApp(quotid, Convert.ToDateTime(txtValidTill.Text), Convert.ToInt32(hdf_customerid.Value), Convert.ToInt32(hdf_POR.Value), Convert.ToInt32(hdf_POL.Value), Convert.ToInt32(hdf_POD.Value), Convert.ToInt32(hdf_FD.Value), ddlShipment.Text, ddlFreight.SelectedItem.Text, Convert.ToInt32(hdf_cargoid.Value), txtDescription.Text, Convert.ToInt32(hdf_salesperson.Value), intpby, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hdf_Hazard.Value), appdate, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Quotation Approved');", true);
                }
            }
        }
        public void GetCompanyName()
        {
            DataTable dt = new DataTable();
            string zipcode = "";
            dtQuot = Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (dtQuot.Rows.Count > 0)
            {
                if (strtrantype == "FE" || strtrantype == "AE")
                {
                    custtype = "S";
                }
                else
                {
                    custtype = "C";
                }
                strcity = customer.GetCustlocation(customerid);
                if (strtrantype == "FE" || strtrantype == "AE")
                {
                    custtype = "Shipper";
                }
                else
                {
                    custtype = "Consignee";
                }
                dt = quotation.RetrieveCustomerDetails4Pin(customerid);
                if (dt.Rows.Count > 0)
                {
                    straddress = dt.Rows[0]["address"].ToString();
                    intzip = dt.Rows[0]["pincode"].ToString();
                }
            }
        }

        protected void txtPOR_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = port.GetPortName(txtPOR.Text);
            if (dt.Rows.Count > 0)
            {
                hdf_POR.Value = dt.Rows[0]["portid"].ToString();

            }
            else
            {
                ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Invalid Port');", true);
                txtPOR.Text = "";
                txtPOR.Focus();

            }
        }

        protected void txtPOL_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = port.GetPortName(txtPOL.Text);
            if (dt.Rows.Count > 0)
            {
                hdf_POL.Value = dt.Rows[0]["portid"].ToString();

            }
            else
            {
                ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Invalid Port');", true);
                txtPOL.Text = "";
                txtPOL.Focus();

            }
        }

        protected void txtPOD_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = port.GetPortName(txtPOD.Text);
            if (dt.Rows.Count > 0)
            {
                hdf_POD.Value = dt.Rows[0]["portid"].ToString();

            }
            else
            {
                ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Invalid Port');", true);
                txtPOD.Text = "";
                txtPOD.Focus();

            }
        }

        protected void txtFD_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = port.GetPortName(txtFD.Text);
            if (dt.Rows.Count > 0)
            {
                hdf_FD.Value = dt.Rows[0]["portid"].ToString();

            }
            else
            {
                ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Invalid Port');", true);
                txtFD.Text = "";
                txtFD.Focus();

            }
        }

        protected void txtCargo_TextChanged(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = cargo.CheckCargoExist(txtCargo.Text);
            if (dt.Rows.Count > 0)
            {
                hdf_cargoid.Value = dt.Rows[0]["cargoid"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Invalid Cargo Type');", true);
                txtCargo.Text = "";
                txtCargo.Focus();
            }
        }

        protected void txtCurr_TextChanged(object sender, EventArgs e)
        {
            if (txtCurr.Text != "")
            {
                hdf_Curr.Value = charges.GetCurrID(txtCurr.Text).ToString();

                if (hdf_Curr.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Invalid Currency');", true);
                    txtCurr.Text = "";
                    txtCurr.Focus();
                }
            }

        }

        protected void txtSalesPerson_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            hdf_salesperson.Value = employee.GetNEmpid(txtSalesPerson.Text).ToString();

            if (hdf_salesperson.Value == "0")
            {
                ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Invalid Sales Person Name');", true);
                txtSalesPerson.Text = "";
                txtSalesPerson.Focus();
            }
        }

        protected void rdbagent_CheckedChanged(object sender, EventArgs e)
        {
            rdbBussiness.Checked = false;
        }

        protected void rdbBussiness_CheckedChanged(object sender, EventArgs e)
        {
            rdbagent.Checked = false;
        }

        protected void txtcrm_TextChanged(object sender, EventArgs e)
        {
            if (txtcrm.Text.Trim() != "")
            {
                string hazard;
                txtclear();
                int crmid = Convert.ToInt32(txtcrm.Text.Trim());
                dsnew = objcrm.GetQuot4CRM(crmid, strtrantype);
                dtcrm = dsnew.Tables[0];
                por = Convert.ToInt32(dtcrm.Rows[0]["por"].ToString());
                txtPOR.Text = port.GetPortname(por);
                pol = Convert.ToInt32(dtcrm.Rows[0]["pol"].ToString());
                txtPOL.Text = port.GetPortname(por);
                pod = Convert.ToInt32(dtcrm.Rows[0]["pod"].ToString());
                txtPOD.Text = port.GetPortname(por);
                fd = Convert.ToInt32(dtcrm.Rows[0]["fd"].ToString());
                txtFD.Text = port.GetPortname(por);

                txtSalesPerson.Text = dtcrm.Rows[0]["salespersonid"].ToString();
                txtCargo.Text = dtcrm.Rows[0]["commodity"].ToString();
                ddlFreight.SelectedItem.Text = dtcrm.Rows[0]["freight"].ToString();
                hazard = dtcrm.Rows[0]["hazardous"].ToString();
                if (hazard == "Y")
                {
                    chkHazard.Checked = true;
                }
                else
                {
                    chkHazard.Checked = false;
                }
                txtCustomer.Text = dtcrm.Rows[0]["customername"].ToString();
                hdf_salesperson.Value = dtcrm.Rows[0]["salespersonid"].ToString();
                hdf_cargoid.Value = dtcrm.Rows[0]["commodityid"].ToString();
                hdf_customerid.Value = dtcrm.Rows[0]["customerid"].ToString();

                string pdt = dtcrm.Rows[0]["pdt"].ToString();
                ddlShipment.SelectedValue = pdt;


                btnclose.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                btnSave.Enabled = true;

            }
        }

        public void txtclear()
        {
            txtPOR.Text = "";
            txtPOL.Text = "";
            txtPOD.Text = "";
            txtFD.Text = "";
            ddlShipment.SelectedIndex = -1;


        }

        protected void lnkcrm_Click(object sender, EventArgs e)
        {
            if (ddlpdt.Text == "Product")
            {
                ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Select the Product');", true);
                ddlpdt.Focus();
                return;
            }

            if (txtQuotation.Text.Trim() == "")
            {
                if (txtcrm.Text.Trim() == "")
                {
                    dtfill = objcrm.GetCRM4grd(strtrantype, Convert.ToInt32(Session["LoginEmpId"]),pdt );
                    if (dtfill.Rows.Count > 0)
                    {
                        grdcrmQuot.DataSource = dtfill;
                        grdcrmQuot.DataBind();
                        popupthird.Visible = true;
                        this.popupcrm.Show();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "alert", "alertify.alert('CRM Unavailable');", true);
                        return;
                    }
                }
            }
        }

        protected void grdcrmQuot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtcrm.Text.Trim() == "")
            {
                int crmid;
                int index = grdcrmQuot.SelectedRow.RowIndex;
                string hazard;
                crmid = Convert.ToInt32(grdcrmQuot.SelectedRow.Cells[0].Text);
                txtclear();
                txtcrm.Text = crmid.ToString();
                txtPOR.Text = grdcrmQuot.SelectedRow.Cells[2].Text;
                txtPOL.Text = grdcrmQuot.SelectedRow.Cells[3].Text;
                txtPOD.Text = grdcrmQuot.SelectedRow.Cells[4].Text;
                txtFD.Text = grdcrmQuot.SelectedRow.Cells[5].Text;
                txtSalesPerson.Text = grdcrmQuot.SelectedRow.Cells[11].Text;
                txtCargo.Text = grdcrmQuot.SelectedRow.Cells[13].Text;
                ddlFreight.SelectedItem.Text = grdcrmQuot.SelectedRow.Cells[14].Text;
                hazard = grdcrmQuot.SelectedRow.Cells[15].Text;
                if (hazard == "Y")
                {
                    chkHazard.Checked = true;
                }
                else
                {
                    chkHazard.Checked = false;
                }
                txtCustomer.Text = grdcrmQuot.SelectedRow.Cells[1].Text;
                hdf_POR.Value = grdcrmQuot.SelectedRow.Cells[6].Text;
                hdf_POL.Value = grdcrmQuot.SelectedRow.Cells[7].Text;
                hdf_POD.Value = grdcrmQuot.SelectedRow.Cells[8].Text;
                hdf_FD.Value = grdcrmQuot.SelectedRow.Cells[9].Text;
                hdf_salesperson.Value = grdcrmQuot.SelectedRow.Cells[10].Text;
                hdf_cargoid.Value = grdcrmQuot.SelectedRow.Cells[12].Text;
                hdf_customerid.Value = grdcrmQuot.SelectedRow.Cells[16].Text;

                txtRemarks .Text  = grdcrmQuot.SelectedRow.Cells[17].Text.Replace ("&nbsp;","");
                ddlShipment.SelectedValue = pdt;

                GetAllMailIds(Convert.ToInt32(hdf_customerid.Value));
             
                btnSave.Enabled = true;
                btnclose.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";

            }
        }

        protected void grdcrmQuot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdcrmQuot, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ddlpdt_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlpdt.Text == "Product")
            {
                ScriptManager.RegisterStartupScript(btnApp, typeof(Button), "alert", "alertify.alert('Select the Product');", true);
                ddlpdt.Focus();

                ddlBase.Items.Clear();
                ddlBase.Items.Add("BASE");
                return;
            }

            if (ddlpdt.SelectedValue == "Ocean Exports FCL")
            {
                strtrantype = "FE";
                ddlShipment.Enabled = false;
                ddlShipment.SelectedValue = "FCL";
                pdt = "FCL";

            }
            else if (ddlpdt.SelectedValue == "Ocean Exports LCL")
            {
                strtrantype = "FE";
                ddlShipment.Enabled = false;
                ddlShipment.SelectedValue = "LCL";
                pdt = "LCL";
            }
            else if (ddlpdt.SelectedValue == "Ocean Imports FCL")
            {
                strtrantype = "FI";
                ddlShipment.Enabled = false;
                ddlShipment.SelectedValue = "FCL";
                pdt = "FCL";
            }
            else if (ddlpdt.SelectedValue == "Ocean Imports LCL")
            {
                strtrantype = "FI";
                ddlShipment.Enabled = false;
                ddlShipment.SelectedValue = "LCL";
                pdt = "LCL";
            }
            else if (ddlpdt.SelectedValue == "Air Exports")
            {
                strtrantype = "AE";
                pdt = "emp";
                ddlShipment.SelectedValue = "FCL";
                ddlShipment.Enabled = false;
            }
            else if (ddlpdt.SelectedValue == "Air Imports")
            {
                strtrantype = "AI";
                ddlShipment.SelectedValue = "FCL";
                ddlShipment.Enabled = false;
                pdt = "emp";
            }
            BaseFill();



        }

        private void GetAllMailIds(int Custid)
        {
          DataTable   dt = new DataTable();

          dt = booking.GETMAilis4BookigCRM(Custid);
            if (dt.Rows.Count > 0)
            {
                DataTable dttemp = new DataTable();
                dttemp.Columns.Add("Cname");
                dttemp.Columns.Add("email");
                DataRow dr;
                string Comptc = dt.Rows[0]["comptc"].ToString();
                string Expptc = dt.Rows[0]["expptc"].ToString();
                string Mgtptc = dt.Rows[0]["managptc"].ToString();
                string Imptc = dt.Rows[0]["impptc"].ToString();
                string Finptc = dt.Rows[0]["finptc"].ToString();

                string ComMail = dt.Rows[0]["commailid"].ToString();
                string ExpMail = dt.Rows[0]["expmailid"].ToString();
                string MgtMail = dt.Rows[0]["managmail"].ToString();
                string ImpMail = dt.Rows[0]["impmailid"].ToString();
                string FinMail = dt.Rows[0]["finmailid"].ToString();

                dr = dttemp.NewRow();
                dr["Cname"] = Comptc;
                dr["email"] = ComMail;
                dttemp.Rows.Add(dr);

                dr = dttemp.NewRow();
                dr["Cname"] = Expptc;
                dr["email"] = ExpMail;
                dttemp.Rows.Add(dr);

                dr = dttemp.NewRow();
                dr["Cname"] = Mgtptc;
                dr["email"] = MgtMail;
                dttemp.Rows.Add(dr);

                dr = dttemp.NewRow();
                dr["Cname"] = Imptc;
                dr["email"] = ImpMail;
                dttemp.Rows.Add(dr);

                dr = dttemp.NewRow();
                dr["Cname"] = Finptc;
                dr["email"] = FinMail;
                dttemp.Rows.Add(dr);

             

                DataTable dt1 = dttemp.Clone(); //copy the structure
                for (int i = 0; i <= dttemp.Rows.Count - 1; i++) //iterate through the rows of the source
                {
                    DataRow currentRow = dttemp.Rows[i];  //copy the current row
                    foreach (var colValue in currentRow.ItemArray)//move along the columns
                    {
                        if (!string.IsNullOrEmpty(colValue.ToString())) // if there is a value in a column, copy the row and finish
                        {
                            dt1.ImportRow(currentRow);
                            break; //break and get a new row
                        }
                    }
                }



                grdmail.DataSource = dt1;
                grdmail.DataBind();

            }
        } 

        protected void btnsend_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            sendqry = "";
            sendqry = sendqry +(Utility.Fn_GetCompanyAddress());

            //sendqry = sendqry + ("<hr>");
            //sendqry = sendqry +("<br>");
            sendqry = sendqry + ("<tr><td><hr><br></td></tr>");
            sendqry = sendqry +("<tr><td><table width=100%><FONT FACE=tahoma><tr><td align=left style='font-weight: bold;font-size :13pt;'>Dear Sir / Madam ,</td></tr></font></table></td></tr><br>");
            sendqry = sendqry + "<tr><td><table width=100%><FONT FACE=tahoma ><tr><td align=left>To</td><td align=right><FONT FACE=Arial> Quotation # : </Font> "+ txtQuotation.Text + "</td></tr></br>";
            sendqry = sendqry + ("<tr><td align=left>" + txtCustomer.Text + "</td><td align=right><FONT FACE=Arial> Date :</font> " + txtDate.Text + "</td></tr></br>");
            //sendqry = sendqry +("<tr><td align=left>Quotation # : " + txtQuotation.Text + " Dt : " + txtDate.Text + "</td></tr>");


    
            DataTable dt = new DataTable();
            dt = custobj.RetrieveCustomerDetails( Convert.ToInt32(hdf_customerid .Value) );
          
            if( dt.Rows.Count > 0)
            {
                straddress1 = dt.Rows[0]["address"].ToString();
                zipcode = dt.Rows[0]["zip"].ToString();
            }


            sendqry = sendqry + "<tr><td  align=left>" + straddress1 + "</td><td align=right><FONT FACE=Arial> Valid Till</font> : " + txtValidTill.Text + "</td></tr></br>";
            sendqry = sendqry + "<tr><td align=left>" + strcity + " - " + zipcode + "</td></tr></font></table></td></tr>";
            sendqry = sendqry + "<tr><td><table width=100% text=black><tr><td align=left> Thank you very much for your inquiry and we are pleased to offer our rates & services as per your requirement from " + txtPOL.Text + " to " + txtPOD.Text + "</td></tr></table></td></tr>";
            sendqry = sendqry + "<tr><td><table width=100% text=black><tr><td align=left> Commodity :   " + txtCargo.Text + "</td></tr></table></td></tr>";
            sendqry = sendqry + "<tr><td><table BORDER=2 BORDERCOLOR=#336699 CELLPADDING=2 CELLSPACING=0 WIDTH=100% text=black><tr><td align=center>Charge Name</td><td align=center>Curr</td><td align=center>Rate</td><td align=center>Base</td></tr>";

            DataTable Dt = new DataTable();
            Dt = quotation.ChargeDetails(Convert.ToInt32(txtQuotation.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
            for (int i = 0; i <= Dt.Rows.Count - 1; i++)
            {

                double rate =Convert .ToDouble(  dt.Rows[i][2].ToString());
                string   rate1 = rate.ToString("#,0.00");
                sendqry = sendqry + ("<tr><FONT FACE=tahoma><td align=left>" + Dt.Rows[i][0].ToString() + "</td><td align=left>" + Dt.Rows[i][1].ToString() + "</td><td align=right>" + rate1 + "</td><td align=left>" + Dt.Rows[i][3].ToString() + "</td></font></tr>");
            }

          
            sendqry = sendqry +("</table></td></tr><br>");
            sendqry = sendqry +("<tr><td><table width=100% text=black><tr><td align=left>Taxes As Applicable</td></tr></table></td></tr><br>");
            sendqry = sendqry + ("<tr><td><table width=100% text=black><tr><td align=left>The  quote (s) are subject to standard terms and conditions, available on request.</td></tr></table></td></tr><br>");

            sendqry = sendqry +("<tr><td><table width=100% text=black><tr><td align=left>I am sure that you will find our offer is attractive and await your confirmation</td></tr></table></td></tr><br>");
            sendqry = sendqry +("<tr><td><table width=100% text=black><tr><td align=left>Best Regards </td></tr></table></td></tr><br>");
            sendqry = sendqry +("<tr><td><table width=100% text=black><tr><td align=left>" + HttpContext.Current.Session["LoginEmpName"].ToString() + " </td></tr></table></td></tr>");
            sendqry = sendqry +("</table></body></html>");
         
            if (grdmail.Rows.Count > 0)
            {
                for (int i = 0; i < grdmail.Rows.Count - 1; i++)
                {
                    CheckBox chkRow = (grdmail.Rows[i].Cells[2].FindControl("chkselect") as CheckBox);
                  
                    if (chkRow.Checked == true)
                    {
                        Label lbl = (Label)grdmail.Rows[i].Cells[1].FindControl("lblemailid");
                        mailid = lbl.Text  + ";" + mailid;
                    }


                }
            }

            if(mailid =="")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "UserName", "alertify.alert('Select Any One of the Mail ID');", true);
                return;
            }


            string branchmgrid = quotation.GetBranchmgrmailid(Convert.ToInt32(Session["LoginBranchid"].ToString()));
         

          if (Session["usermailid"].ToString() == "" || Session["mailpwd"].ToString() == "")
          {
              ScriptManager.RegisterStartupScript(this, typeof(Button), "UserName", "alertify.alert('Update Email ID and Password');", true);
              return;
          }

         //  Utility.SendMail(HttpContext.Current.Session["usermailid"].ToString(), mailid, " Quotation # -" + txtQuotation.Text + " PoL : " + txtPOL.Text + " PoD : " + txtPOD.Text, sendqry , "", HttpContext.Current.Session["mailpwd"].ToString(),);

          Utility.SendMail(HttpContext.Current.Session["usermailid"].ToString(), mailid, " Quotation # -" + txtQuotation.Text + " PoL : " + txtPOL.Text + " PoD : " + txtPOD.Text, sb.ToString(), "", HttpContext.Current.Session["mailpwd"].ToString(), "", HttpContext.Current.Session["usermailid"].ToString() + ";" + branchmgrid);
          ScriptManager.RegisterStartupScript(this, typeof(Button), "UserName", "alertify.alert('Mail Send.');", true);


          GetAllMailIds(Convert.ToInt32(hdf_customerid.Value));

        
        }

     

      
       
  
        
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }


        private string SendPDFEmail(StringBuilder sb)
        {
            StringReader sr = new StringReader(sb.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
          
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                if (File.Exists(Server.MapPath("Quotation.pdf")))
                {
                    File.Delete(Server.MapPath("Quotation.pdf"));
                }
                string sFile = Server.MapPath("Quotation.pdf"); //Path
                FileStream fs = File.Create(sFile);
                fs.Close();
                File.WriteAllBytes(Server.MapPath("Quotation.pdf"), bytes);
                string strattach = Server.MapPath("Quotation.pdf");

                return strattach;
             
            }
        }

        //bharthi



        private void getsales()
        {

            DataSet dsQuot = new DataSet();
            dtQuot = quotation.GetQuotationDetails(Convert.ToInt32(Session["quotono"]), Session["trantyp"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
            dtQuot.TableName = "Test1";
            dsQuot.Tables.Add("Test1");
            if (dtQuot.Rows.Count > 0)
            {

                txtQuotation.Text = Session["quotono"].ToString();
                OldQuotNo = Convert.ToInt32(txtQuotation.Text);
                customerid = Convert.ToInt32(dtQuot.Rows[0]["customerid"].ToString());
                hdf_customerid.Value = Convert.ToString(customerid);
                intpol = Convert.ToInt32(dtQuot.Rows[0]["pol"].ToString());
                hdf_POL.Value = Convert.ToString(intpol);
                intpor = Convert.ToInt32(dtQuot.Rows[0]["por"].ToString());
                hdf_POR.Value = Convert.ToString(intpor);
                intpod = Convert.ToInt32(dtQuot.Rows[0]["pod"].ToString());
                hdf_POD.Value = Convert.ToString(intpod);
                intfd = Convert.ToInt32(dtQuot.Rows[0]["fd"].ToString());
                hdf_FD.Value = Convert.ToString(intfd);
                cargoid = Convert.ToInt32(dtQuot.Rows[0]["cargoid"].ToString());
                hdf_cargoid.Value = Convert.ToString(cargoid);
                sales = Convert.ToInt32(dtQuot.Rows[0]["marketedby"].ToString());
                hdf_salesperson.Value = Convert.ToString(sales);
                prepared = Convert.ToInt32(dtQuot.Rows[0]["preparedby"].ToString());
                hazard = Convert.ToInt32(dtQuot.Rows[0]["hazardous"].ToString());
                hdf_Hazard.Value = Convert.ToString(hazard);
                txtDescription.Text = dtQuot.Rows[0]["descn"].ToString();
                // txtValidTill.Text = Utility.fn_ConvertDate(dtQuot.Rows[0]["validtill"].ToString());

                txtValidTill.Text = DateTime.Parse(dtQuot.Rows[0]["validtill"].ToString()).ToString("dd-MMM-yyyy");
                txtRemarks.Text = dtQuot.Rows[0]["remarks"].ToString();
                // txtBrokerage.Text = dtQuot.Rows[0]["brokerage"].ToString();
                Strshipment = quotation.GetShipment(Char.Parse(dtQuot.Rows[0]["stype"].ToString()));
                strfstatus = quotation.GetFright(Char.Parse(dtQuot.Rows[0]["fstatus"].ToString()));
                if (dtQuot.Rows[0]["business"].ToString() == "A")
                {
                    rdbagent.Checked = true;
                    rdbBussiness.Checked = false;
                }
                else
                {
                    rdbBussiness.Checked = true;
                    rdbagent.Checked = false;
                }
                app = Convert.ToInt32(dtQuot.Rows[0]["approvedby"].ToString());
                //bhuvana
                int crmid = objcrm.GetCRMid(Convert.ToInt32(txtQuotation.Text.ToUpper()), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                txtcrm.Text = crmid.ToString();
                txtCustomer.Text = customer.GetCustomername(customerid);
                txtPOL.Text = port.GetPortname(intpol);
                txtPOD.Text = port.GetPortname(intpod);
                txtPOR.Text = port.GetPortname(intpor);
                txtFD.Text = port.GetPortname(intfd);
                txtCargo.Text = cargo.GetCargoname(cargoid);
                txtSalesPerson.Text = employee.GetEmployeeName(sales);
                txtPreparedBy.Text = employee.GetEmployeeName(prepared);
                if (app == 0)
                {
                    txtEnable();
                }
                else
                {
                    txtUnable();
                }
                if (hazard == 1)
                {
                    chkHazard.Checked = true;
                }
                else
                {
                    chkHazard.Checked = false;
                }
                ddlShipment.Items.Add(Strshipment);
                ddlFreight.Items.Add(strfstatus);
                //Convert.ToInt32(Session["quotono"]), Session["trantyp"].ToString()
                dtQuot = quotation.ChargeDetails(Convert.ToInt32(Session["quotono"]), Convert.ToInt32(Session["LoginBranchid"].ToString()), "");
                if (dtQuot.Rows.Count > 0)
                {
                    grdQuotation.DataSource = dtQuot;
                    grdQuotation.DataBind();
                }
                Dt = quotation.CheckQuotForBookingFromQno(Convert.ToInt32(Session["quotono"]), Session["trantyp"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), "QB");
                if (Dt.Rows.Count > 0)
                {
                    txtBuying.Text = Dt.Rows[0]["buyingno"].ToString();
                    GetBuyingGrid();
                }
                else
                {
                    DataTable dt1 = new DataTable();
                    BaseFill();
                }
                //btnclose.Text = "Cancel";
                btnclose.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                btnclose.Enabled = true;
                btnApp.Enabled = false;
                txtCargeEnable();
                grdQuotation.Enabled = true;
                if (Session["trantyp"].ToString() == "FE" && Strshipment == "FCL")
                {
                    ddlpdt.Items.Add("Ocean Exports FCL");
                }
                else if (Session["trantyp"].ToString() == "FE" && Strshipment == "LCL")
                {
                    ddlpdt.Items.Add("Ocean Exports LCL");
                }
                else if (Session["trantyp"].ToString() == "FI" && Strshipment == "FCL")
                {
                    ddlpdt.Items.Add("Ocean Imports FCL");
                }
                else if (Session["trantyp"].ToString() == "FI" && Strshipment == "LCL")
                {
                    ddlpdt.Items.Add("Ocean Imports LCL");
                }
                else if (Session["trantyp"].ToString() == "AE")
                {
                    ddlpdt.Items.Add("Air Exports");
                }
                else if (Session["trantyp"].ToString() == "AI")
                {
                    ddlpdt.Items.Add("Air Imports");
                }


            }
        }





    }
        
    }
