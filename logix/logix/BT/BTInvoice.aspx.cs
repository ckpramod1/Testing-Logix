using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

namespace logix.BT
{
    public partial class BTInvoice : System.Web.UI.Page
    {

        DataAccess.LogDetails objLogDetails = new DataAccess.LogDetails();

        DataAccess.HR.Employee objHrEmp = new DataAccess.HR.Employee();

        DataAccess.BondedTrucking.BTJobInfo objJobingo = new DataAccess.BondedTrucking.BTJobInfo();

        DataAccess.Accounts.Invoice objInvoice = new DataAccess.Accounts.Invoice();
        DataAccess.Masters.MasterPort objPort = new DataAccess.Masters.MasterPort();
        DataTable DtTable = new DataTable();
        int custid, intcustid, cityid, approvedby;
        DateTime voudate;
        string city, billtype, fatransfer="";
        DataAccess.Masters.MasterCustomer objCustomer = new DataAccess.Masters.MasterCustomer();
        DataTable dt = new DataTable();
        DataTable dtable = new DataTable();
        int i;
        string extype = "";
        int branchId, divisionId, supplytoid, intsupplytoid;
        string str_Uiid = "", str_FornName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);
            hid_date.Value = Utility.fn_ConvertDate(objLogDetails.GetDate().ToShortDateString());
            //Session["StrTranType"] = "gbl";
            divisionId = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            branchId = Convert.ToInt32(Session["LoginBranchid"].ToString());

            try
            {
              
                lblBtInvoice.Text = Request.QueryString["type"].ToString();
                header.InnerText = lblBtInvoice.Text;
                if (lblBtInvoice.Text == "Invoice")
                {
                    txtInvoice.ToolTip = "Inv #";
                    txtInvoice.Attributes.Add("placeholder", "Invoice #");
                    extype = "R";
                    txtVenderRef.Visible = false;
                }
                else
                {
                    txtInvoice.ToolTip = "PA #";
                    txtInvoice.Attributes.Add("placeholder", "PA #");
                    extype = "C";
                    txtVenderRef.Visible = true;
                }


               

                if (!IsPostBack)
                {
                    txtDate.Text = hid_date.Value;
                    billType();

                    ddlBase();

                    //  btnAdd.Enabled = false;

                    txtInvoice.Focus();

                   // btnCancel.Text = "Back";

                    btnCancel.ToolTip = "Back";
                    btnCancel1.Attributes["class"] = "btn ico-back";

                    txtVouyear.Text = Session["Vouyear"].ToString();
                    EmptyGrd();
                    // txtShippingBill.Focus();
                    UserRights();
                }



                txtInvoice.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txtVouyear.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void ddlBase()
        {

            //ddlbase.Items.Add("CBM");
            //ddlbase.Items.Add("Kgs");
            //ddlbase.Items.Add("Truck");
        }


        public void EmptyGrd()
        {
            grdViewInvoice.DataSource = Utility.Fn_GetEmptyDataTable();

            grdViewInvoice.DataBind();
        }
        public void billType()
        {
            try
            {
                ddlBillType.Items.Clear();
                ddlBillType.Items.Add("");
                ddlBillType.Items.Add("Cash/Cheque");
                ddlBillType.Items.Add("Credit");
                ddlBillType.Items.Add("Internal");


               
                //if (Convert.ToDateTime(objLogDetails.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                //{

                //  ddlBillType.Items.Add("Cash/Cheque");
                //ddlBillType.Items.Add("Credit");
                
                //}
                //else
                //{

                //    ddlBillType.Items.Add("Cash/Cheque");
                //    ddlBillType.Items.Add("Credit");
                //    ddlBillType.Items.Add("Internal");
                //}
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        [WebMethod]

        public static List<string> GrtTo(string prefix)
        {
            List<string> list_result = new List<string>();

            DataAccess.Masters.MasterCustomer objCustomer = new DataAccess.Masters.MasterCustomer();
            DataTable dt = new DataTable();

            dt = objCustomer.GetLikeCustomer(prefix);

            list_result = Utility.Fn_DatatableToList(dt, "customer", "customerid");

            return list_result;
        }


        [WebMethod]

        public static List<string> GetShippingBil(string prefix)
        {
            List<string> list_result = new List<string>();

            DataAccess.BondedTrucking.BTJobInfo objJobingo = new DataAccess.BondedTrucking.BTJobInfo();
            DataTable dtable = new DataTable();

            dtable = objJobingo.GetLikeBTSBNo(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
            list_result = Utility.Fn_TableToList(prefix, dtable, "sbno");

            return list_result;
        }

        protected void Grid_Load()
        {

            try
            {
                if (lblBtInvoice.Text == "Invoice")
                {
                    dt = objInvoice.GetInvoiceDetails(Convert.ToInt32(txtInvoice.Text), "I", Convert.ToInt32(txtVouyear.Text), branchId);
                }
                else
                {
                    dt = objInvoice.GetPADetails(Convert.ToInt32(txtInvoice.Text), Convert.ToInt32(txtVouyear.Text), branchId);
                }

                if (dt.Rows.Count > 0)
                {
                    grdViewInvoice.DataSource = dt;
                    grdViewInvoice.DataBind();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtInvoice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string bill;
                if (txtInvoice.Text != "")
                {
                    string Vtypy = "";

                    if (lblBtInvoice.Text == "Invoice")
                    {
                        Vtypy = "I";

                        DtTable = objInvoice.ShowIPHead(Convert.ToInt32(txtInvoice.Text), Session["StrTranType"].ToString(), "Invoice", Convert.ToInt32(txtVouyear.Text), branchId);
                    }

                    else
                    {
                        Vtypy = "P";

                        DtTable = objInvoice.ShowIPHead(Convert.ToInt32(txtInvoice.Text), Session["StrTranType"].ToString(), "Payment Advise", Convert.ToInt32(txtVouyear.Text), branchId);
                    }

                    i = DtTable.Rows.Count;

                    if (i > 0)
                    {
                        txtJob.Text = DtTable.Rows[0][3].ToString();

                        custid = Convert.ToInt32(DtTable.Rows[0][4]);

                        intcustid = custid;

                        txtTo.Text = objCustomer.GetCustomername(custid);

                        city = objCustomer.GetCustlocation(custid);
                        cityid = objPort.GetNPortid(city);
                        txtShippingBill.Text = DtTable.Rows[0][5].ToString();
                        approvedby = Convert.ToInt32(DtTable.Rows[0][7].ToString());
                        txtRemarks.Text = DtTable.Rows[0][10].ToString();
                        billtype = DtTable.Rows[0][12].ToString();
                        fatransfer = DtTable.Rows[0][13].ToString();
                        //cmbbill.Text = INVOICEobj.GetBillType(billtype)
                        bill = objInvoice.GetBillType(Convert.ToChar(billtype));
                        txtDate.Text = DtTable.Rows[0][1].ToString();
                        txtDate.Text = Utility.fn_ConvertDateonly(txtDate.Text);



                        if (bill == "Cash/Cheque")
                        {
                            ddlBillType.SelectedIndex = 1;
                        }
                        else if (bill == "Credit")
                        {
                            ddlBillType.SelectedIndex = 2;
                        }
                        else if (bill == "Internal")
                        {
                            ddlBillType.SelectedIndex = 3;
                        }

                        else if (bill == "--BILLTYPE--")
                        {
                            ddlBillType.SelectedIndex = 0;
                        }

                        //if (Convert.ToDateTime(objLogDetails.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                        //{

                        //    if (bill == "Cash/Cheque")
                        //    {
                        //        ddlBillType.SelectedIndex = 1;
                        //    }
                        //    else if (bill == "Credit")
                        //    {
                        //        ddlBillType.SelectedIndex = 2;
                        //    }

                        //    else if (bill == "--BILLTYPE--")
                        //    {
                        //        ddlBillType.SelectedIndex = 0;
                        //    }

                            

                        //}
                        //else
                        //{
                        //    if (bill == "Cash/Cheque")
                        //    {
                        //        ddlBillType.SelectedIndex = 1;
                        //    }
                        //    else if (bill == "Credit")
                        //    {
                        //        ddlBillType.SelectedIndex = 2;
                        //    }
                        //    else if (bill == "Internal")
                        //    {
                        //        ddlBillType.SelectedIndex = 3;
                        //    }

                        //    else if (bill == "--BILLTYPE--")
                        //    {
                        //        ddlBillType.SelectedIndex = 0;
                        //    }

                        //}

                        if (!string.IsNullOrEmpty(DtTable.Rows[0]["SupplyTo"].ToString()))
                        {
                            supplytoid = Convert.ToInt32(DtTable.Rows[0]["SupplyTo"].ToString());
                            intsupplytoid = supplytoid;
                            txtsupplyto.Text = objCustomer.GetCustomername(supplytoid);
                            
                        }


                        if (lblBtInvoice.Text == "Payment Advise")
                        {
                            txtVenderRef.Text = DtTable.Rows[0]["vendorrefno"].ToString();
                        }

                        if (txtJob.Text != "")
                        {
                            dt = objJobingo.GetBTJobInfo(Convert.ToInt32(txtJob.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

                            if (dt.Rows.Count > 0)
                            {
                                txtFromPort.Text = dt.Rows[0]["fromport"].ToString();
                                txtToport.Text = dt.Rows[0]["toport"].ToString();
                                txtEta.Text = dt.Rows[0]["eta"].ToString();
                                txtEta.Text = Utility.fn_ConvertDateonly(txtEta.Text);
                                txtEtd.Text = dt.Rows[0]["etd"].ToString();
                                txtEtd.Text = Utility.fn_ConvertDateonly(txtEtd.Text);
                            }
                        }
                      //  btnCancel.Text = "Cancel";

                        btnCancel.ToolTip = "Cancel";
                        btnCancel1.Attributes["class"] = "btn ico-cancel";
                        Grid_Load();
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTInvoice", "alertify.alert('Invalid Invoice Number');", true);
                        txtInvoice.Text = "";
                        // btnsave.Text = "&Save"
                        //btnCancel.Text = "Back";

                        btnCancel.ToolTip = "Back";
                        btnCancel1.Attributes["class"] = "btn ico-back";

                        txtInvoice.Focus();
                    }

                }
                txtTotal.Text = "";
                double total = 0;
                for (i = 0; i <= grdViewInvoice.Rows.Count - 1; i++)
                {
                    total = total + Convert.ToDouble(grdViewInvoice.Rows[i].Cells[7].Text);
                }
                txtTotal.Text = total.ToString("#,0.00");
                UserRights();

                if (fatransfer != "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTInvoice", "alertify.alert('Cannot Be Amended');", true);
                    grdViewInvoice.Enabled = true;


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txtInvoice.Text = "";
                txtInvoice.Focus();
            }
           // btnCancel.Text = "Cancel";

            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }
        protected void txtClear()
        {
            txtShippingBill.Text = "";

            txtJob.Text = "";

            ddlBillType.SelectedIndex = -1;

            txtInvoice.Text = "";


            txtTo.Text = "";
            txtsupplyto.Text= "";

            txtFromPort.Text = "";

         

            txtEta.Text = "";

            txtEtd.Text = "";

            txtRemarks.Text = "";


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.ToolTip == "Cancel")
            {
              //  btnCancel.Text = "Back";

                btnCancel.ToolTip = "Back";
                btnCancel1.Attributes["class"] = "btn ico-back";

                txtInvoice.Focus();
                txtTotal.Text = "";
                txtClear();
                EmptyGrd();
                txtDate.Text = hid_date.Value;
                // txtShippingBill.Focus();
                UserRights();
            }

            else
            {
                this.Response.End();
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime get_date, GST_date;
                DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                get_date =  Convert.ToDateTime(txtDate.Text);
                GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                str_RptName = " ";
                if (txtInvoice.Text != "")
                {
                    if (lblBtInvoice.Text == "Invoice")
                    {
                        str_RptName = "BTInvoice.rpt";
                        Session["str_sfs"] = "{ACInvoiceHead.trantype}='" + Session["StrTranType"] + "' and {ACInvoiceHead.invoiceno}=" + txtInvoice.Text + " and {ACInvoiceHead.branchid}=" + branchId + " and {ACInvoiceHead.vouyear}=" + txtVouyear.Text;
                        str_sp = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtInvoice.Text + "&vouyear=" + txtVouyear.Text + "&total=" + txtTotal.Text + "&blno=" + "" + "&bltype=" + "H" + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                        }else
                        {
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }

                    else
                    {
                        str_RptName = "BTPA.rpt";
                        Session["str_sfs"] = "{ACPAHead.trantype}='" + Session["StrTranType"] + "' and {ACPAHead.pano}=" + txtInvoice.Text + " and {ACPAHead.branchid}=" + branchId + " and {ACPAHead.vouyear}=" + txtVouyear.Text;
                        str_sp = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtInvoice.Text + "&vouyear=" + txtVouyear.Text + "&total=" + txtTotal.Text + "&blno=" + "" + "&bltype=" + "H" + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                        }else
                        {
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    ScriptManager.RegisterStartupScript(btnView, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtShippingBill_TextChanged(object sender, EventArgs e)
        {
            try
            {
             
                DataTable dt = new DataTable();
                dt = objJobingo.GetBTJobInfoFSBNo(txtShippingBill.Text, branchId, divisionId);
                if (dt.Rows.Count > 0)
                {
                    txtTo.Text = dt.Rows[0]["customername"].ToString();
                    txtJob.Text = dt.Rows[0]["jobno"].ToString();
                    txtFromPort.Text = dt.Rows[0]["fromport"].ToString();
                    txtToport.Text = dt.Rows[0]["toport"].ToString();
                    txtEta.Text = dt.Rows[0]["eta"].ToString();
                    txtEtd.Text = dt.Rows[0]["etd"].ToString();
                    intcustid = Convert.ToInt32(dt.Rows[0]["customer"].ToString());
                   // btnCancel.Text = "Cancel";

                    btnCancel.ToolTip = "Cancel";
                    btnCancel1.Attributes["class"] = "btn ico-cancel";
                    
                }
                else
                {
                   // btnCancel.Text = "Back";

                    btnCancel.ToolTip = "Back";
                    btnCancel1.Attributes["class"] = "btn ico-back";

                    txtTotal.Text = "";
                    txtClear();
                    EmptyGrd();
                    txtDate.Text = hid_date.Value;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTInvoice", "alertify.alert('Invalid Shipping Bill# ');", true);
                    txtRemarks.Focus();
                }
                UserRights();
               
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txtShippingBill.Text = "";
                txtShippingBill.Focus();
            }
            txtRemarks.Focus();
        }

        protected void grdViewInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
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


        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {
                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, null, btnView, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

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

            if (lblBtInvoice.Text == "Invoice")
            {
                obj_dtlogdetails = objLogDetails.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1052, "Inv", txtInvoice.Text, txtVouyear.Text, Session["StrTranType"].ToString());
                lbl_no.InnerText = "Invoice #:";
            }
            else
            {
                obj_dtlogdetails = objLogDetails.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1053, "PA", txtInvoice.Text, txtVouyear.Text, Session["StrTranType"].ToString());
                lbl_no.InnerText = "Credit Note-Ops #:";
            }


            if (txtInvoice.Text != "")
            {
                JobInput.Text = txtInvoice.Text;

               

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