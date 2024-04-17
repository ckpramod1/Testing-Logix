using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Web.Services;
using System.Text;
using ClosedXML.Excel;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace logix.FAForm
{
    public partial class Afterjobcloseapproval_finance : System.Web.UI.Page
    {
        DataAccess.Masters.MasterExRate exrateshow = new DataAccess.Masters.MasterExRate();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.CloseJobs objClosedJob = new DataAccess.CloseJobs();
        DataAccess.ForwardingExports.JobInfo objJobInfo = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
        DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.Documents objnew = new DataAccess.Documents();
        DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
        DataAccess.Accounts.OSDNCN obj_da_OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();

        DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
        DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
        DataAccess.Accounts.ProfomaInvoice ProINVobj = new DataAccess.Accounts.ProfomaInvoice();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.OSDNCN obj_da_invoice2 = new DataAccess.Accounts.OSDNCN();
       

        protected void Page_Load(object sender, EventArgs e)
        {


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                exrateshow.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                leftObj.GetDataBase(Ccode);
                Appobj.GetDataBase(Ccode);
                exrobj.GetDataBase(Ccode);
                custobj.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);
                objClosedJob.GetDataBase(Ccode);
                objJobInfo.GetDataBase(Ccode);
                obj_da_FA.GetDataBase(Ccode);
                obj_da_Approval.GetDataBase(Ccode);
                obj_da_Invoice.GetDataBase(Ccode);


                objnew.GetDataBase(Ccode);
                obj_da_Cost.GetDataBase(Ccode);
                obj_da_OSDNCN.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);
                employeeobj.GetDataBase(Ccode);
                obj_da_Ledger.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                obj_da_FAVoucher.GetDataBase(Ccode);
                employeeobj.GetDataBase(Ccode);
                obj_da_Cheque.GetDataBase(Ccode);



                ProINVobj.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                obj_da_BL.GetDataBase(Ccode);
                obj_da_Cheque.GetDataBase(Ccode);
                employeeobj.GetDataBase(Ccode);
                obj_da_Approval.GetDataBase(Ccode);
                obj_da_invoice2.GetDataBase(Ccode);
                obj_da_Invoice.GetDataBase(Ccode);



            }


            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();dropdown();", true);

        }
        protected void ddl_voutype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_product.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Select Product');", true);
                ddl_product.Focus();
                return;
            }
            DataTable dcon = Appobj.Checkcountry(int.Parse(Session["LoginBranchid"].ToString()));
            int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
            if (con == 1102 || con == 102)
            {
                if (ddl_voutype.SelectedValue != "2" && ddl_voutype.SelectedValue != "23")
                {
                    Grd_Approval.Columns[8].Visible = false;
                    Grd_Approval.Columns[9].Visible = false;
                    Grd_Approval.Columns[10].Visible = false;
                    Grd_Approval.Columns[11].Visible = false;       //NewOne    //21/07/2022
                    Grd_Approval.Columns[12].Visible = false;
                    Grd_Approval.Columns[13].Visible = false;
                    Grd_Approval.Columns[14].Visible = false;
                    Grd_Approval.Columns[15].Visible = false;
                    Grd_Approval.Columns[16].Visible = false;
                }
                else
                {
                    Grd_Approval.Columns[8].Visible = false;
                    Grd_Approval.Columns[9].Visible = true;
                    Grd_Approval.Columns[10].Visible = true;
                    Grd_Approval.Columns[11].Visible = true;       //NewOne    //21/07/2022
                    Grd_Approval.Columns[12].Visible = true;
                    Grd_Approval.Columns[13].Visible = true;
                    Grd_Approval.Columns[14].Visible = true;
                    Grd_Approval.Columns[15].Visible = true;
                    Grd_Approval.Columns[16].Visible = true;
                }
            }
            else
            {
                Grd_Approval.Columns[8].Visible = false;
                Grd_Approval.Columns[9].Visible = false;
                Grd_Approval.Columns[10].Visible = false;
                Grd_Approval.Columns[11].Visible = false;       //NewOne    //21/07/2022
                Grd_Approval.Columns[12].Visible = false;
                Grd_Approval.Columns[13].Visible = false;
                Grd_Approval.Columns[14].Visible = false;
                Grd_Approval.Columns[15].Visible = false;
                Grd_Approval.Columns[16].Visible = false;
            }

            DataTable obj_dt = new DataTable();
            //DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
            obj_dt = obj_da_Approval.GetProApprovependingLV_AJclose(ddl_product.SelectedValue, int.Parse(Session["LoginBranchid"].ToString()), Convert.ToInt32(ddl_voutype.SelectedValue));
            if (ddl_voutype.SelectedValue != "0")
            {
                if (obj_dt.Rows.Count > 0)
                {

                    DataView obj_dtview = new DataView(obj_dt);
                    obj_dtview.RowFilter = "voutype='" + ddl_voutype.SelectedItem.Text + "' ";
                    obj_dt = obj_dtview.ToTable();
                    Grd_Approval.DataSource = obj_dt;
                    Grd_Approval.DataBind();
                    if (obj_dt.Rows.Count > 0)
                    {
                        hid_voutypeid.Value = obj_dt.Rows[0]["voutypeid"].ToString();
                    }
                }
            }
        }
        protected void ddl_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataTable DT_per = new DataTable();
                DataTable dt = new DataTable();
                int RowIndex = ((GridViewRow)((DropDownList)sender).NamingContainer).RowIndex;
                DropDownList drp_section = ((DropDownList)Grd_Approval.Rows[RowIndex].FindControl("ddl_section"));
                DropDownList drp_section1 = ((DropDownList)Grd_Approval.Rows[RowIndex].FindControl("ddl_section1"));
                TextBox Txt_per = ((TextBox)Grd_Approval.Rows[RowIndex].FindControl("txtpercentage"));
                TextBox TDSdescnew = ((TextBox)Grd_Approval.Rows[RowIndex].FindControl("TDSdescnew"));

                DataTable dlp = new DataTable();
                dlp = obj_da_Invoice.sp_ddltds(drp_section.SelectedItem.Text);

                var ddl2 = (DropDownList)Grd_Approval.Rows[RowIndex].FindControl("ddl_section1");
                ddl2.Items.Clear();
                ddl2.Items.Add("");
                for (int i = 0; i < dlp.Rows.Count; i++)
                {
                    ddl2.Items.Add(dlp.Rows[i]["tdspercentage"].ToString());
                }
            }

            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        protected void ddl_section_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataTable DT_per = new DataTable();
                DataTable dt = new DataTable();
                int RowIndex = ((GridViewRow)((DropDownList)sender).NamingContainer).RowIndex;
                DropDownList drp_section = ((DropDownList)Grd_Approval.Rows[RowIndex].FindControl("ddl_section1"));
                TextBox Txt_per = ((TextBox)Grd_Approval.Rows[RowIndex].FindControl("txtpercentage"));
                TextBox TDSdescnew = ((TextBox)Grd_Approval.Rows[RowIndex].FindControl("TDSdescnew"));

                Txt_per.Text = drp_section.SelectedValue;

            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
        }

        private void Grd_TDS_CellContentClick(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > 0)
            {
                int rowindex = e.Row.RowIndex;
                GridViewRow row = this.Grd_Approval.Rows[rowindex];
            }

        }
        protected void lnkedit_Click(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            GridViewRow GvRow = (GridViewRow)lb.NamingContainer;
            int Row_ID = GvRow.RowIndex;
            if (Grd_Approval.Rows[Row_ID].Cells[1].Text == "SALES INVOICE" || Grd_Approval.Rows[Row_ID].Cells[1].Text == "PURCHASE INVOICE" || Grd_Approval.Rows[Row_ID].Cells[1].Text == "SALES INVOICE OC" || Grd_Approval.Rows[Row_ID].Cells[1].Text == "PURCHASE INVOICE OC")
            {
                Response.Redirect("../FAForms/ProformaLV.aspx?1voutype=" + Grd_Approval.DataKeys[Row_ID].Values[2].ToString() + "&refno=" + Grd_Approval.Rows[Row_ID].Cells[2].Text + "&1vouyear=" + Grd_Approval.DataKeys[Row_ID].Values[0].ToString() + "&1tran=" +ddl_product.SelectedValue);
            }
            else
            {
                Response.Redirect("../FAForms/ProOSV.aspx?voutype=" + Grd_Approval.DataKeys[Row_ID].Values[2].ToString() + "&1refno=" + Grd_Approval.Rows[Row_ID].Cells[2].Text + "&1vouyear=" + Grd_Approval.DataKeys[Row_ID].Values[0].ToString() + "&1tran=" + ddl_product.SelectedValue);

            }
        }
        protected void lnkdownload_Click(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            GridViewRow GvRow = (GridViewRow)lb.NamingContainer;
            int Row_ID = GvRow.RowIndex;
            if (Grd_Approval.Rows[Row_ID].Cells[1].Text == "SALES INVOICE" || Grd_Approval.Rows[Row_ID].Cells[1].Text == "PURCHASE INVOICE" || Grd_Approval.Rows[Row_ID].Cells[1].Text == "SALES INVOICE OC" || Grd_Approval.Rows[Row_ID].Cells[1].Text == "PURCHASE INVOICE OC")
            {
                Response.Redirect("../FAForms/ProformaLV.aspx?rptvoutype=" + Grd_Approval.DataKeys[Row_ID].Values[2].ToString() + "&rptrefno=" + Grd_Approval.Rows[Row_ID].Cells[2].Text + "&rptvouyear=" + Grd_Approval.DataKeys[Row_ID].Values[0].ToString() + "&rpttran=" + ddl_product.SelectedValue);
            }
            else
            {
                Response.Redirect("../FAForms/ProOSV.aspx?rptvtype=" + Grd_Approval.DataKeys[Row_ID].Values[2].ToString() + "&rptrefno=" + Grd_Approval.Rows[Row_ID].Cells[2].Text + "&rptvouyear=" + Grd_Approval.DataKeys[Row_ID].Values[0].ToString() + "&rpttran=" + ddl_product.SelectedValue);

            }
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                Grd_Approval.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_Approval.DataBind();
                btn_cancel.Text = "Back";

                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";

            }
            else
            {
                div_iframe.Visible = false;
            }
        }
        protected void Grd_Approval_PreRender(object sender, EventArgs e)
        {
            if (Grd_Approval.Rows.Count > 0)
            {
                Grd_Approval.UseAccessibleHeader = true;
                Grd_Approval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_Approval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index, cindex, selectedColumnIndex = 0, selectedRowIndex = 0;
                string st = "";
                if (e.CommandName.ToString() == "ColumnClickNew")
                {
                    selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                    selectedColumnIndex = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
                    Session["column"] = selectedColumnIndex;
                    Session["row"] = selectedRowIndex;
                }
                if (selectedColumnIndex != 5)
                {
                    //Grd_Approval_SelectedIndexChanged(sender, e);
                    //approval();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Approval_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row;
            List<TableCell> columns = new List<TableCell>();
            foreach (DataControlField column in Grd_Approval.Columns)
            {
                TableCell cell = row.Cells[0];
                row.Cells.Remove(cell);
                columns.Add(cell);
            }
            row.Cells.AddRange(columns.ToArray());
        }
        protected void Grd_Approval_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void btn_transfer_Click(object sender, EventArgs e)
        {
            try
            {

                log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(Afterjobcloseapproval_finance));
                log4net.Config.BasicConfigurator.Configure();
                log1.Info("********************************************************************************************************************************************************");
                log1.Info("Voucher Transfer has been Called");

                // Einvoice newly added start//
                //DataAccess.Documents objnew = new DataAccess.Documents();
                if (ddl_product.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Select Product');", true);
                    ddl_product.Focus();
                    return;
                }
                //DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
                string div_id = "", gstirn_ = "", gstirnerr_ = "";
                int gstirn = 0, gstirnerr = 0;
                // Einvoice newly added end//
                int int_Vouyear1 = 0;
                int invoinumberfright = 0;
                string type = "";
                string str_favourname = "";
                int invoinumber = 0;
                //DataAccess.Accounts.OSDNCN obj_da_OSDNCN = new DataAccess.Accounts.OSDNCN();
                int int_osdncn = 0;
                DataTable dtosdn = new DataTable();
              //  DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                string cutname = "";
                // DataSet dsosdn=new DataSet();
                int jobnoosdn = 0;
                //int gsttype = 0, statename = 0, supplyto = 0, int_osdncn1 = 0;
                //string gsttype_ = "", statename_ = "", supplyto_ = "", str_osdncn1 = "";
                int gsttype = 0, statename = 0, supplyto = 0, int_osdncn1 = 0, int_TDS = 0;
                string gsttype_ = "", statename_ = "", supplyto_ = "", str_osdncn1 = "", str_TDS = "";

                int int_Invoiceno = 0, int_Refno = 0, int_Vouyear = 0, int_Empid = 0, int_bid = 0, int_divisionid = 0, int_intdcno = 0, int_Voutypeid = 0;
                string Str_Trantype = ddl_product.SelectedValue, Str_invoiceno = "", Str_invoicenonew = "";
                int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                DataTable obj_dt = new DataTable();
                string StrScript = "";
                int countinv = 0;
                double st_amt = 0.0;
                double Amount = 0, TDS = 0, TDSAmount = 0, CSTAmount = 0, gstamt = 0;
                //DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                //DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
                //DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();
                //DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
                int int_Custid = 0;
                TextBox Txt = new TextBox();
                //DataAccess.Accounts.ProfomaInvoice ProINVobj = new DataAccess.Accounts.ProfomaInvoice();
                string tdstype = "", tdsdesc = "";
                string str_tdstype = "", str_tdsdesc = "";
                int int_tdstype = 0, int_tdsdesc = 0;
                DataTable dtcheck = new DataTable();
                DataTable Dtckeck = new DataTable();
                DataTable dtnew1 = new DataTable();
                string str_VType = "";
                DataTable obj_dt1 = new DataTable();

                int countryid = 0;
                //DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
                DataTable dtcust = new DataTable();
                DataTable dtcust1 = new DataTable();
                DataTable dcon = Appobj.Checkcountry(int_bid);
                int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
                /******************* For Auto mail *********************/
                bool bos = false;
                /*******************************************************/


                Button lb = (Button)sender;
                GridViewRow GvRow = (GridViewRow)lb.NamingContainer;
                int Row_ID = GvRow.RowIndex;
                hid_voutype.Value = Grd_Approval.Rows[Row_ID].Cells[1].Text;
                hid_voutypeid.Value = Grd_Approval.DataKeys[Row_ID].Values[2].ToString();
                if (hid_voutype.Value.ToString() == "SALES INVOICE" || hid_voutype.Value.ToString() == "PURCHASE INVOICE" || hid_voutype.Value.ToString() == "SALES INVOICE OC" || hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
                {

                    //foreach (GridViewRow row in Grd_Approval.Rows)
                    //{
                    type = Grd_Approval.Rows[Row_ID].Cells[22].Text;       //NewOne       //21/07/2022
                    string str_Voutype = type;
                    bool ChkLedger = true;
                    //   CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
                    //if (Chk.Checked == true)
                    //{
                    countinv = 1;
                    int_Custid = int.Parse(Grd_Approval.DataKeys[Row_ID].Values[1].ToString());
                    countryid = obj_da_Invoice.getcustomercountry(Convert.ToInt32(int_Custid));


                    if (hid_voutype.Value.ToString() == "PURCHASE INVOICE" || hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
                    {
                        //DataTable dcon = Appobj.Checkcountry(Convert.ToInt32(row.Cells[0].Text.ToString()));
                        //int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
                        if (con == 1102 || con == 102)
                        {
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                Txt = (TextBox)Grd_Approval.Rows[Row_ID].FindControl("txtpercentage");         //NewOne       //21/07/2022
                                if (Txt.Text.Trim().Length == 0)
                                {
                                    //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "TDS", "alertify.alert('Enter TDS%');", true);
                                    if (int_TDS == 0)
                                    {
                                        str_TDS = "Enter TDS% for Ref number is " + int_Refno;

                                    }
                                    else
                                    {
                                        str_TDS = str_TDS + "," + int_Refno;
                                    }
                                    Txt.Focus();
                                    int_TDS = 1;
                                    //continue;

                                }
                                else
                                {
                                    tdstype = Grd_Approval.Rows[Row_ID].Cells[9].Text;
                                    tdsdesc = Grd_Approval.Rows[Row_ID].Cells[10].Text;// row.Cells[7].Text.ToString();
                                    if (tdstype == "" && tdstype == "")
                                    {
                                        if (int_tdstype == 0)
                                        {
                                            str_tdstype = "TDS Type is Empty && TDS DESC is Empty for Ref number is " + int_Refno;

                                        }
                                        else
                                        {
                                            str_tdstype = str_tdstype + "," + int_Refno;
                                        }
                                        Txt.Focus();
                                        int_tdstype = 1;
                                        //continue;
                                    }
                                    else if (tdstype == "")
                                    {
                                        if (int_tdstype == 0)
                                        {
                                            str_tdstype = "TDS Type is Empty for Ref number is " + int_Refno;

                                        }
                                        else
                                        {
                                            str_tdstype = str_tdstype + "," + int_Refno;
                                        }
                                        Txt.Focus();
                                        int_tdstype = 1;
                                        //continue;
                                    }

                                    else if (tdsdesc == "")
                                    {
                                        if (int_tdsdesc == 0)
                                        {
                                            str_tdsdesc = "TDS DESC is Empty for Ref number is " + int_Refno;

                                        }
                                        else
                                        {
                                            str_tdsdesc = str_tdsdesc + "," + int_Refno;
                                        }
                                        Txt.Focus();
                                        int_tdsdesc = 1;
                                        //continue;
                                    }

                                }
                            }
                        }
                    }
                    int_Refno = Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text);
                    int_Vouyear = int.Parse(Grd_Approval.DataKeys[Row_ID].Values[0].ToString());

                    /******************* For Auto mail *********************/
                    hid_refno.Value = Grd_Approval.Rows[Row_ID].Cells[2].Text;
                    //hid_vouyear.Value = Grd_Approval.DataKeys[row.RowIndex].Values[0].ToString();
                    hid_vouyear.Value = obj_da_FAVoucher.Getvouyearforautotransfer(int_bid).ToString();
                    /****************************************/

                    //hid_stamt.Value = row.Cells[7].Text.ToString();
                    //hid_supplyto.Value = row.Cells[8].Text.ToString();
                    hid_stamt.Value = Grd_Approval.Rows[Row_ID].Cells[19].Text;
                    hid_supplyto.Value = Grd_Approval.Rows[Row_ID].Cells[20].Text;

                    if (hid_voutype.Value.ToString() == "PURCHASE INVOICE" || hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
                    {
                        //DataTable dcon = Appobj.Checkcountry(Convert.ToInt32(row.Cells[0].Text.ToString()));
                        //int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
                        if (con == 1102 || con == 102)
                        {
                            if( (countryid == 1102)||(countryid == 102))
                            {

                                if (hid_supplyto.Value != "")
                                {
                                    dtcust1 = obj_da_BL.Gettdsforcustomer(Convert.ToInt32(hid_supplyto.Value));
                                }
                                if (dtcust1.Rows.Count > 0)
                                {
                                    // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                                    StrScript += "TDS does not exist for Supply to customer" + int_Refno + ".Kindly check Proforma PA";
                                    //continue;

                                }

                                dtcust1 = obj_da_BL.Gettdsforcustomer(int_Custid);

                                if (dtcust1.Rows.Count > 0)
                                {
                                    // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                                    StrScript += "TDS does not exist for Bill to customer" + int_Refno + ".Kindly check Proforma PA";
                                    //continue;

                                }
                            }
                        }

                    }

                    if (hid_supplyto.Value != "0")
                    {
                        cutname = obj_da_Customer.GetCustomername(Convert.ToInt32(hid_supplyto.Value));
                    }
                    string emp = Grd_Approval.Rows[Row_ID].Cells[8].Text;
                    int empp = employeeobj.GetNEmpid(emp);
                    //if (empp == int_Empid)
                    //{
                    //    StrScript += "You have no rights to approve Voucher # " + int_Refno + " prepared by you";
                    //    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                    //    continue;
                    //}
                    DataTable dtnewexrate = obj_da_Invoice.GET_exratecheckLV(int_Refno, int_bid, int_Vouyear, Convert.ToInt32(hid_voutypeid.Value));
                    if (dtnewexrate.Rows.Count > 0)
                    {
                        StrScript += "Ex.Rate Different in Voucher Details " + int_Refno + ".Kindly check Proforma Invoice";
                        //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                        //continue;
                    }

                    DataTable dtnewgst = obj_da_Invoice.Get_checkwithSGSTPIGSTLV(int_Refno, int_bid, int_Vouyear, Convert.ToInt32(hid_voutypeid.Value));

                    if (dtnewgst.Rows.Count > 0)
                    {
                        StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice/PA";
                        //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                        //continue;
                    }

                    DataTable dtnewgst1 = obj_da_Invoice.Get_checkwithSGSTPIGST1LV(int_Refno, int_bid, int_Vouyear, Convert.ToInt32(hid_voutypeid.Value));

                    if (dtnewgst1.Rows.Count > 0)
                    {
                        StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice/PA";
                        //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                        //continue;
                    }
                    if ((hid_voutype.Value.ToString() == "SALES INVOICE" && countryid == 1102) || (hid_voutype.Value.ToString() == "SALES INVOICE OC" && countryid == 1102))
                    {
                        Dtckeck = obj_da_Approval.GetInvoiceAppSTCheckAmtLV(int_Refno, Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Vouyear);
                        if (Dtckeck.Rows.Count > 0)
                        {
                            StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice";
                            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                            //continue;

                        }
                    }

                    if ((hid_voutype.Value.ToString() == "PURCHASE INVOICE" && countryid == 1102) || (hid_voutype.Value.ToString() == "PURCHASE INVOICE OC" && countryid == 1102))
                    {
                        Dtckeck = obj_da_Approval.GetInvoiceAppSTCheckAmtLV(int_Refno, Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Vouyear);
                        if (Dtckeck.Rows.Count > 0)
                        {
                            StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Credit Note Operation";
                            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                            //continue;

                        }
                    }

                    // Einvoice newly added start//
                    if ((hid_voutype.Value.ToString() == "SALES INVOICE OC" && countryid == 1102) || (hid_voutype.Value.ToString() == "SALES INVOICE" && countryid == 1102))
                    {
                        DataTable dthsncode = obj_da_Approval.GetchksaccodeforvoucherLV(Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Refno, int_Vouyear, "I");
                        if (dthsncode.Rows.Count > 0)
                        {
                            StrScript += "Kindly update the SACCode in master " + int_Refno + ".check Proforma Invoice";
                            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                            //continue;

                        }
                    }

                    if (hid_voutype.Value.ToString() == "SALES INVOICE OC" || hid_voutype.Value.ToString() == "SALES INVOICE")
                    {
                        string custid1 = objnew.getloctdetails(Convert.ToInt32(hid_supplyto.Value));

                        if (custid1 == "1")
                        {
                            //StrScript += "kindly update the Location or State name for customer " + int_Refno + ".check Proforma Invoice";
                            StrScript += "Proforma Invoice #" + int_Refno.ToString() + "- Please Update Location / State / Pincode of " + cutname + ",";
                            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                            //continue;
                        }

                        string custid2 = objnew.getloctdetails(Convert.ToInt32(int_Custid));

                        if (custid2 == "1")
                        {
                            StrScript += "Proforma Invoice #" + int_Refno.ToString() + "- Please Update Location / State / Pincode of " + cutname + ",";
                            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                            //continue;
                        }
                    }

                    string custid11 = objnew.getholdcutdetails(Convert.ToInt32(hid_supplyto.Value));

                    if (custid11 == "1")
                    {
                        //StrScript += "kindly update the Location or State name for customer " + int_Refno + ".check Proforma Invoice";
                        StrScript += "Proforma Invoice #" + int_Refno.ToString() + "- Customer " + cutname + " status is Hold please discuss with Finance team" + ",";
                        //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                        //continue;
                    }

                    string custid21 = objnew.getholdcutdetails(Convert.ToInt32(int_Custid));

                    if (custid21 == "1")
                    {
                        StrScript += "Proforma Invoice #" + int_Refno.ToString() + "- Customer " + cutname + " status is Hold please discuss with Finance team" + ",";
                        //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                        //continue;
                    }


                    if (Session["hid_gstdate"] != null)
                    {
                        if (Convert.ToDateTime(logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                        {

                            if (hid_supplyto.Value != "0")
                            {

                                if (Convert.ToDouble(hid_stamt.Value) > 0)
                                {

                                    int int_custidnew;
                                    DataTable dt_list = new DataTable();
                                    //DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

                                    //int int_custid = Convert.ToInt32(hdncustid.Value);
                                    if (!string.IsNullOrEmpty(Grd_Approval.Rows[Row_ID].Cells[20].Text))   //NewOne       //21/07/2022
                                    {
                                        int_custidnew = Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[20].Text);  //NewOne       //21/07/2022
                                        dt_list = customerobj.GetIndianCustomergstadd(int_custidnew);
                                    }

                                    if (dt_list.Rows.Count > 0)
                                    {
                                        if (!string.IsNullOrEmpty(dt_list.Rows[0]["GSTGroup"].ToString()))
                                        {
                                            if (dt_list.Rows[0]["GSTGroup"].ToString() == "N")
                                            {
                                                if (gsttype == 0)
                                                {
                                                    gsttype_ = cutname;
                                                }
                                                else
                                                {
                                                    gsttype_ = " ," + cutname;
                                                }
                                                gsttype = 1;
                                                //StrScript += "GST TYPE not Updated for the Customer Name :" + row.Cells[2].Text.ToString() + " in the Voucher #" + int_Refno;
                                                //continue;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        //StrScript += "State Name not Updated in Master Kindly update Master Customer for" + row.Cells[2].Text.ToString();
                                        if (statename == 0)
                                        {
                                            statename_ = cutname;
                                        }
                                        else
                                        {
                                            statename_ = " ," + cutname;
                                        }
                                        statename = 1;
                                        //continue;
                                    }

                                }

                            }
                            else
                            {
                                //StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + int_Refno;
                                if (supplyto == 0)
                                {
                                    supplyto_ = int_Refno.ToString();
                                }
                                else
                                {
                                    supplyto_ = " ," + int_Refno.ToString();
                                }
                                supplyto = 1;
                                //continue;
                            }
                        }
                    }

                    string inapproved = obj_da_Approval.CHKVoucherbosLV(int_Refno);

                    if ((inapproved.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE" && countryid == 1102) || (inapproved.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE OC" && countryid == 1102))
                    {
                        invoinumber = obj_da_Approval.UpdProApprovalnewBOSLV(0, int_bid, int_Refno, int_Vouyear, Grd_Approval.Rows[Row_ID].Cells[4].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype);
                      
                        ProINVobj.UpdAfterjobclose(invoinumber,int_bid,Convert.ToInt32(hid_voutypeid.Value),"");

                        bos = true;

                        //  logix.CommanClass.TallyEDIFA.Fn_FATransfer("BOS", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");
                         
                           // app = 1;
                            //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "DNCNApproval", "alertify.alert('CN # :" + int_Invoiceno + "transferred');", true);
                            //StrScript += "CN # : " + Str_invoiceno + " Generated and Transfered";
                        obj_dt = obj_da_Invoice.ShowLVHead(invoinumber, ddl_product.SelectedValue.ToString(), Convert.ToInt32(hid_voutypeid.Value), int_Vouyear, int_bid);
                           str_VType = "B";
                        
                        if (obj_dt.Rows.Count > 0)
                        {
                            Fn_DNCNBL(Convert.ToInt32(obj_dt.Rows[0][3].ToString()), ddl_product.SelectedValue.ToString(), "Approve", obj_da_Log.GetDate(), invoinumber, str_VType);
                        }
                     //   DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
                        if (obj_da_Cost.CheckcostinginsertAfterjobclose(Convert.ToInt32(obj_dt.Rows[0][3].ToString()), int_bid, ddl_product.SelectedValue.ToString(), invoinumber, str_VType) == "false")
                        {
                            Fn_DNCNBL(Convert.ToInt32(obj_dt.Rows[0][3].ToString()), ddl_product.SelectedValue.ToString(), "Approve", obj_da_Log.GetDate(), invoinumber, str_VType);

                        }
                        if (invoinumber != 0)
                        {
                            Str_invoicenonew = Str_invoicenonew + invoinumber.ToString() + ",";
                        }
                        else
                        {
                            Str_invoicenonew = "Invoice not Approved";
                        }
                    }

                    ////hari /// 09_09_2022 //std
                    string invapprovegst = obj_da_Approval.SPCHECkfrightLV(int_Refno);

                    if ((invapprovegst.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE" && countryid == 1102) || (invapprovegst.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE OC" && countryid == 1102))
                    {

                        invoinumberfright = obj_da_Approval.UpdProApprovalnewLV(hid_type.Value.ToString(), int_bid, int_Refno, int_Vouyear, Grd_Approval.Rows[Row_ID].Cells[4].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype);
                        ProINVobj.UpdAfterjobclose(invoinumberfright, int_bid, Convert.ToInt32(hid_voutypeid.Value), "");
                        // logix.CommanClass.TallyEDIFA.Fn_FATransfer("BOS", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", "");

                        // logix.CommanClass.TallyEDIFA.Fn_FATransfer("BOS", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", int_bid, "", 0, 0, "", 1);

                        //hide on 14Jun2022 -- nambi
                        ////4 invoice
                        //invoinumber = obj_da_Approval.UpdProApprovalnew(hid_type.Value.ToString(), int_bid, int_Refno, int_Vouyear, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype);
                        // logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", "");

                        if (invoinumberfright != 0)
                        {
                            Str_invoicenonew = Str_invoicenonew + invoinumberfright.ToString() + ",";
                        }
                        else
                        {
                            Str_invoicenonew = "Invoice not Approved";
                        }

                        div_id = objnew.getinsmastergstdetailsMR(Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                        string custid1ung = objnew.getunregcustvouchers(invoinumberfright, int_Vouyear, int_bid, "I");

                        if (div_id == "1" && custid1ung == "0" && countryid == 1102)
                        {

                            try
                            {

                                //int vouno = 1018;  // 793 ,826
                                //int bid = 13;
                                //int vouyear = 2020;
                                //int cid = 1;
                                string json1 = objnew.getgstdetails(invoinumberfright, int_bid, int_Vouyear, "I");
                                //   DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", "{\r\n    \"Version\": \"1.1\",\r\n    \"TranDtls\": {\r\n        \"TaxSch\": \"GST\",\r\n        \"SupTyp\": \"B2B\",\r\n        \"RegRev\": \"N\"\r\n    },\r\n    \"DocDtls\": {\r\n        \"Typ\": \"INV\",\r\n        \"No\": \"IN2021CHEOE100\",\r\n        \"Dt\": \"13\\/05\\/2020\"\r\n    },\r\n    \"SellerDtls\": {\r\n        \"Gstin\": \"29AAFCC9980MZZT\",\r\n        \"LglNm\": \"DEMO CUSTOMER21577\",\r\n        \"Addr1\": \"CUSTOMER ADDRESS\",\r\n        \"Loc\": \"Supreme Court\",\r\n        \"Pin\": 110001,\r\n        \"Stcd\": \"29\"\r\n    },\r\n    \"BuyerDtls\": {\r\n        \"Gstin\": \"07AAACA4691C2ZY\",\r\n        \"LglNm\": \"DEMO CUSTOMER21577\",\r\n        \"Pos\": \"07\",\r\n        \"Addr1\": \"CUSTOMER ADDRESS\",\r\n        \"Loc\": \"Supreme Court\",\r\n        \"Pin\": 110001,\r\n        \"Stcd\": \"07\"\r\n    },\r\n    \"ItemList\": [{\r\n        \"SlNo\": \"1\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 5.00,\r\n        \"TotAmt\": 388.25,\r\n        \"AssAmt\": 388.25,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 69.89,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 458.14\r\n    }, {\r\n        \"SlNo\": \"2\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 4050.00,\r\n        \"TotAmt\": 4050.00,\r\n        \"AssAmt\": 4050.00,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 729.00,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 4779.00\r\n    }, {\r\n        \"SlNo\": \"3\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 5500.00,\r\n        \"TotAmt\": 5500.00,\r\n        \"AssAmt\": 5500.00,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 990.00,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 6490.00\r\n    }],\r\n    \"ValDtls\": {\r\n        \"AssVal\": 9938.25,\r\n        \"CgstVal\": 0.00,\r\n        \"SgstVal\": 0.00,\r\n        \"IgstVal\": 1788.89,\r\n        \"RndOffAmt\": 0.00,\r\n        \"TotInvVal\": 11727.00\r\n    }\r\n}\r\n\r\n");

                                string datajson = DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", json1);

                                //DataTable dtjson = ConvertJsonToDatatable(datajson);
                                // string l0 = dtjson.Rows[0][0].ToString().Trim();
                                DataTable dtjson = new DataTable();
                                string status = "";
                                if (datajson != null)
                                {
                                    dtjson = ConvertJsonToDatatable(datajson);
                                    status = dtjson.Rows[0][0].ToString().Trim();
                                }
                                else
                                {
                                    status = "0";
                                }

                                string message1 = "";
                                string IRN1 = "";
                                string Ackdt = "";
                                string Ackno = "";
                                string status1 = "";
                                string SignedQRCode = "";
                                string SignedInvoice = "";

                                string uuid = "";
                                string SignedQrCodeImgUrl = "";
                                string IrnStatus = "";
                                string EwbStatus = "";
                                string Irp = "";
                                string EwbDt = "";
                                string EwbNo = "";
                                string EwbValidTill = "";
                                string Remarks = "";

                                if (status == "1")
                                {
                                    //message1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();
                                    //IRN1 = dtjson.Rows[0][2].ToString().Replace('"', ' ').Trim();
                                    //Ackdt = dtjson.Rows[0][3].ToString().Replace('"', ' ').Trim();
                                    //Ackno = dtjson.Rows[0][4].ToString().Replace('"', ' ').Trim();
                                    //status1 = dtjson.Rows[0][5].ToString().Replace('"', ' ').Trim();
                                    //SignedQRCode = dtjson.Rows[0][6].ToString().Replace('"', ' ').Trim();

                                    //SignedInvoice = dtjson.Rows[0][7].ToString().Replace('"', ' ').Trim();

                                    //uuid = dtjson.Rows[0][8].ToString().Replace('"', ' ').Trim();
                                    //SignedQrCodeImgUrl = dtjson.Rows[0][9].ToString().Replace('"', ' ').Trim();
                                    //IrnStatus = dtjson.Rows[0][10].ToString().Replace('"', ' ').Trim();
                                    //EwbStatus = dtjson.Rows[0][11].ToString().Replace('"', ' ').Trim();
                                    //Irp = dtjson.Rows[0][12].ToString().Replace('"', ' ').Trim();

                                    message1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();    		//	1                       
                                    IRN1 = dtjson.Rows[0][2].ToString().Replace('"', ' ').Trim();       // 2
                                    Ackdt = dtjson.Rows[0][3].ToString().Replace('"', ' ').Trim();     //3
                                    Ackno = dtjson.Rows[0][4].ToString().Replace('"', ' ').Trim();    // 4 
                                    status1 = dtjson.Rows[0][7].ToString().Replace('"', ' ').Trim();  // 7
                                    SignedQRCode = dtjson.Rows[0][10].ToString().Replace('"', ' ').Trim(); //10

                                    SignedInvoice = dtjson.Rows[0][11].ToString().Replace('"', ' ').Trim(); //11

                                    uuid = dtjson.Rows[0][12].ToString().Replace('"', ' ').Trim();  //12
                                    SignedQrCodeImgUrl = dtjson.Rows[0][13].ToString().Replace('"', ' ').Trim();// 13 
                                    IrnStatus = dtjson.Rows[0][14].ToString().Replace('"', ' ').Trim();  //14 
                                    EwbStatus = dtjson.Rows[0][15].ToString().Replace('"', ' ').Trim(); //15
                                    Irp = dtjson.Rows[0][16].ToString().Replace('"', ' ').Trim(); //16

                                    EwbDt = dtjson.Rows[0][5].ToString().Replace('"', ' ').Trim(); //5
                                    EwbNo = dtjson.Rows[0][6].ToString().Replace('"', ' ').Trim(); //6
                                    EwbValidTill = dtjson.Rows[0][9].ToString().Replace('"', ' ').Trim(); // 9
                                    Remarks = dtjson.Rows[0][8].ToString().Replace('"', ' ').Trim();//  8

                                    objnew.insmastergstdetails(invoinumberfright, int_Vouyear, int_bid, int_divisionid, status, message1, IRN1, Ackdt, Ackno, status1, SignedQRCode, SignedInvoice, uuid, SignedQrCodeImgUrl, IrnStatus, EwbStatus, Irp, "I", EwbDt, EwbNo, EwbValidTill, Remarks);

                                }
                                else
                                {
                                    //  l1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();
                                    if (datajson != null)
                                    {
                                        message1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();
                                    }
                                    else
                                    {
                                        message1 = "The GSTZen user credentials provided in the request are invalid-.";
                                    }
                                    objnew.insmastergstdetails(invoinumberfright, int_Vouyear, int_bid, int_divisionid, status, message1, "", "", "", "", "", "", "", "", "", "", "", "I", "", "", "", "");

                                }

                            }
                            catch (Exception ex)
                            {
                                string message = ex.Message.ToString();
                                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                            }
                        }
                    }

                    ////hari /// 09_09_2022 //END

                    string inapproved1 = obj_da_Approval.CHKVoucherinvgenLV(int_Refno);

                    if ((inapproved1.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE" && countryid == 1102) || (inapproved1.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE OC" && countryid == 1102))
                    {
                        int_Invoiceno = obj_da_Approval.GetNoforAcForApprovalLV(int_bid, hid_voutype.Value.ToString());
                        if (hid_voutype.Value.ToString() == "SALES INVOICE")
                        {
                            obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "Invoice");
                        }
                        else
                        {
                            obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "Invoice FC");
                        }

                        // obj_da_Approval.UpdProApproval(int_Refno, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype, int_Vouyear, int_bid, int_Invoiceno, hid_type.Value.ToString());

                        // Einvoice newly added satrt//

                        div_id = objnew.getinsmastergstdetailsMR(Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                        string custid1ung = objnew.getunregcustvouchers(int_Invoiceno, int_Vouyear, int_bid, "I");

                        if (div_id == "1" && custid1ung == "0" && countryid == 1102)
                        {

                            try
                            {

                                string json2 = objnew.getgstdetails(int_Invoiceno, int_bid, int_Vouyear, "I");

                                string datajson1 = DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", json2);
                                DataTable dtjson1 = new DataTable();
                                string status = "";
                                if (datajson1 != null)
                                {
                                    dtjson1 = ConvertJsonToDatatable(datajson1);
                                    status = dtjson1.Rows[0][0].ToString().Trim();
                                }
                                else
                                {
                                    status = "0";
                                }

                                string message1 = "";
                                string IRN1 = "";
                                string Ackdt = "";
                                string Ackno = "";
                                string status1 = "";
                                string SignedQRCode = "";
                                string SignedInvoice = "";

                                string uuid = "";
                                string SignedQrCodeImgUrl = "";
                                string IrnStatus = "";
                                string EwbStatus = "";
                                string Irp = "";

                                string EwbDt = "";
                                string EwbNo = "";
                                string EwbValidTill = "";
                                string Remarks = "";

                                if (status == "1")
                                {

                                    message1 = dtjson1.Rows[0][1].ToString().Replace('"', ' ').Trim();    		//	1   

                                    IRN1 = dtjson1.Rows[0][2].ToString().Replace('"', ' ').Trim();       // 2

                                    gstirn_ = gstirn_ + "," + message1 + " " + IRN1 + " ,";
                                    gstirn = 0;

                                    Ackdt = dtjson1.Rows[0][3].ToString().Replace('"', ' ').Trim();     //3
                                    Ackno = dtjson1.Rows[0][4].ToString().Replace('"', ' ').Trim();    // 4 
                                    status1 = dtjson1.Rows[0][7].ToString().Replace('"', ' ').Trim();  // 7
                                    SignedQRCode = dtjson1.Rows[0][10].ToString().Replace('"', ' ').Trim(); //10

                                    SignedInvoice = dtjson1.Rows[0][11].ToString().Replace('"', ' ').Trim(); //11

                                    uuid = dtjson1.Rows[0][12].ToString().Replace('"', ' ').Trim();  //12
                                    SignedQrCodeImgUrl = dtjson1.Rows[0][13].ToString().Replace('"', ' ').Trim();// 13 
                                    IrnStatus = dtjson1.Rows[0][14].ToString().Replace('"', ' ').Trim();  //14 
                                    EwbStatus = dtjson1.Rows[0][15].ToString().Replace('"', ' ').Trim(); //15
                                    Irp = dtjson1.Rows[0][16].ToString().Replace('"', ' ').Trim(); //16

                                    EwbDt = dtjson1.Rows[0][5].ToString().Replace('"', ' ').Trim(); //5
                                    EwbNo = dtjson1.Rows[0][6].ToString().Replace('"', ' ').Trim(); //6
                                    EwbValidTill = dtjson1.Rows[0][9].ToString().Replace('"', ' ').Trim(); // 9
                                    Remarks = dtjson1.Rows[0][8].ToString().Replace('"', ' ').Trim();//  8

                                    objnew.insmastergstdetails(int_Invoiceno, int_Vouyear, int_bid, int_divisionid, status, message1, IRN1, Ackdt, Ackno, status1, SignedQRCode, SignedInvoice, uuid, SignedQrCodeImgUrl, IrnStatus, EwbStatus, Irp, "I", EwbDt, EwbNo, EwbValidTill, Remarks);

                                }
                                else
                                {
                                    if (datajson1 != null)
                                    {
                                        message1 = dtjson1.Rows[0][1].ToString().Replace('"', ' ').Trim();

                                        gstirnerr_ = gstirnerr_ + "," + message1;
                                        gstirnerr = 1;

                                    }
                                    else
                                    {
                                        message1 = "The GSTZen user credentials provided in the request are invalid-.";
                                    }
                                    objnew.insmastergstdetails(int_Invoiceno, int_Vouyear, int_bid, int_divisionid, status, message1, "", "", "", "", "", "", "", "", "", "", "", "I", "", "", "", "");
                                }

                            }
                            catch (Exception ex)
                            {
                                string message = ex.Message.ToString();
                                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                            }

                        }

                        // Einvoice newly added end//
                    }
                    else if ((hid_voutype.Value.ToString() == "SALES INVOICE" && countryid != 1102) || (hid_voutype.Value.ToString() == "SALES INVOICE OC " && countryid != 1102))
                    {
                        int_Invoiceno = obj_da_Approval.GetNoforAcForApprovalLV(int_bid, hid_voutype.Value.ToString());
                        if (hid_voutype.Value.ToString() == "SALES INVOICE")
                        {
                            obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "Invoice");
                        }
                        else
                        {
                            obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "Invoice FC");
                        }
                        //  obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "Invoice");
                    }
                    else
                    {
                        if (hid_voutype.Value.ToString() != "SALES INVOICE" && hid_voutype.Value.ToString() != "SALES INVOICE OC")
                        {
                            int_Invoiceno = obj_da_Approval.GetNoforAcForApprovalLV(int_bid, hid_voutype.Value.ToString());
                            // obj_da_Approval.UpdProApproval(int_Refno, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype, int_Vouyear, int_bid, int_Invoiceno,  hid_voutype.Value.ToString());
                            if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                            {
                                obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "PA");
                            }
                            else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
                            {
                                obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "PA FC");
                            }
                            //  obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "PA");

                        }

                    }

                    log1.Info("********************************************************************************************************************************************************");
                    log1.Info("Transfer To Commercial PA After Approval");

                    if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                    {

                        log1.Info("Before TDS- (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");

                        int_Custid = int.Parse(Grd_Approval.DataKeys[Row_ID].Values[1].ToString());

                        countryid = obj_da_Invoice.getcustomercountry(Convert.ToInt32(int_Custid));
                        //Amount = double.Parse((Grd_Approval.Rows[row.RowIndex].Cells[4].Text.ToString()));
                        //gstamt = double.Parse((Grd_Approval.Rows[row.RowIndex].Cells[12].Text.ToString()));
                        // Amount = Amount - gstamt;
                        DataTable Dt_LimitCheck = new DataTable();
                        int_Vouyear1 = Convert.ToInt32(obj_da_FA.Getvouyearforautotransfer(int_bid).ToString());
                        Dt_LimitCheck = obj_da_Approval.GetCustAmtLimt(int_Custid, int_bid);
                        Amount = obj_da_Approval.GetVoucherAmount4TDS(int_Invoiceno, int_bid, int_Vouyear1, "P");
                        log1.Info("Before TDS Procedure1- (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");
                        if (Dt_LimitCheck.Rows.Count > 0)
                        {
                            if (Amount > 0)
                            {
                                double cstamount = Convert.ToDouble(Dt_LimitCheck.Rows[0]["cstamount"].ToString()) - Amount;
                                double AmtWidExem, AmtWidTds, AmtwitoutTds;
                                double tdsemp, tdsper;
                                if (Convert.ToDouble(cstamount) >= Convert.ToDouble(Dt_LimitCheck.Rows[0]["limit"].ToString()))
                                {
                                    TDS = Convert.ToDouble(Txt.Text.ToString());
                                    TDSAmount = Convert.ToDouble((Amount * (TDS / 100)).ToString("#0.00"));
                                    log1.Info("Before TDS Amount > 0- (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                                }
                                else //if(Convert.ToInt32(Dt_LimitCheck.Rows[0]["cstamount"].ToString()) < Convert.ToInt32(Dt_LimitCheck.Rows[0]["limit"].ToString()))
                                {
                                    double diff = Convert.ToDouble(cstamount) + Amount;
                                    if (diff > Convert.ToDouble(Dt_LimitCheck.Rows[0]["limit"].ToString()))
                                    {
                                        tdsper = Convert.ToDouble(Txt.Text.ToString());
                                        AmtWidExem = diff - Convert.ToDouble(Dt_LimitCheck.Rows[0]["limit"].ToString());
                                        AmtwitoutTds = Convert.ToDouble((AmtWidExem * (tdsper / 100)).ToString("#0.00"));
                                        tdsemp = Convert.ToDouble(Dt_LimitCheck.Rows[0]["tdsemp"].ToString());
                                        AmtWidTds = Convert.ToDouble(((Amount - AmtWidExem) * (tdsemp / 100)).ToString("#0.00"));
                                        TDSAmount = AmtwitoutTds + AmtWidTds;
                                        log1.Info("Before TDS Amount < 0- (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                                    }
                                    else
                                    {
                                        TDS = Convert.ToDouble(Dt_LimitCheck.Rows[0]["tdsemp"].ToString());
                                        TDSAmount = Convert.ToDouble((Amount * (TDS / 100)).ToString("#0.00"));
                                        log1.Info("Before TDS Amount = 0- (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                                    }
                                }
                            }
                            else
                            {
                                if (Txt.Text.ToString() == "")
                                {
                                    TDSAmount = 0;
                                }
                                else if (Convert.ToDouble(Txt.Text.ToString()) == 0.0)
                                {
                                    TDSAmount = 0;
                                }
                                else
                                {
                                    TDS = Convert.ToDouble(Txt.Text.ToString());
                                    //  TDSAmount = Amount * (TDS / 100);
                                    TDSAmount = Convert.ToDouble((Amount * (TDS / 100)).ToString("#0.00"));
                                }
                            }

                        }
                        else
                        {
                            //DataTable dcon = Appobj.Checkcountry(Convert.ToInt32(row.Cells[0].Text.ToString()));
                            //int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
                            if (con == 1102 || con == 102)
                            {
                                if (Convert.ToDouble(Txt.Text.ToString()) == 0.0)
                                {
                                    TDSAmount = 0;
                                }
                                else
                                {
                                    TDS = Convert.ToDouble(Txt.Text.ToString());
                                    // TDSAmount = Amount * (TDS / 100);
                                    TDSAmount = Convert.ToDouble((Amount * (TDS / 100)).ToString("#0.00"));
                                }
                            }

                        }

                        log1.Info("Before TDS insert  - (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                        CSTAmount = Amount - TDSAmount;

                        //if (str_Voutype == "S")
                        //{
                        //    obj_dt = obj_da_Invoice.GetPartyLedger4PAAdmin(int_Invoiceno, "C", int.Parse(Session["LoginBranchid"].ToString()), int_Vouyear1);
                        //}
                        //for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        //{
                        //    int int_Ledgerid = 0;
                        //    int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int.Parse(obj_dt.Rows[i]["chargeid"].ToString()), "A", Session["FADbname"].ToString());
                        //    if (int_Ledgerid == 0)
                        //    {
                        //        ChkLedger = false;
                        //    }
                        //}
                        //string Str_ddlVoucherType = "", Str_ddlNarration = "", Str_ddlReference = "";
                        //if (hid_voutype.Value.ToString() == "Transfer To Commercial PA")
                        //{
                        //    str_Voutype = "P";              //CN-OPS  -->P  //Admin-CN-->S//  Other-CN-->E
                        //    type = "P";
                        //}


                        //log1.Info("Before TDS insert-1  - (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                        //if (ChkLedger == true)
                        //{
                        //    if( (countryid == 1102)||(countryid == 102))
                        //    {
                        //        log1.Info("Before TDS insert-2  - (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                        //        obj_da_Invoice.InsertPATDS(int_Invoiceno, str_Voutype, int.Parse(Session["LoginBranchid"].ToString()), int_Custid, int_Vouyear1, CSTAmount, TDSAmount, "", Convert.ToDouble(Txt.Text.ToString()));
                        //        log1.Info("Before TDS insert-3  - (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                        //    }
                        //    //if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                        //    // {
                        //    //     str_Voutype="P";
                        //    //     type = "P";
                        //    // }

                        //    if (str_Voutype == "P")
                        //    {
                        //        Str_ddlVoucherType = "Credit Note - Operations";
                        //        Str_ddlNarration = "Vessel/Voyage/Container";
                        //        Str_ddlReference = "BL No";
                        //    }
                        //    else if (str_Voutype == "E")
                        //    {
                        //        Str_ddlVoucherType = "Credit Note - Others";
                        //        Str_ddlNarration = "Vessel/Voyage/Container";
                        //        Str_ddlReference = "BL No";
                        //    }
                        //    else if (str_Voutype == "S")
                        //    {
                        //        Str_ddlVoucherType = "Admin Purchase Invoice";
                        //        Str_ddlNarration = "Remarks";
                        //        Str_ddlReference = "Ref No";
                        //    }//raj

                        //    logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_ddlVoucherType, int_Invoiceno, int_Invoiceno, Str_ddlNarration, Str_ddlReference, Convert.ToInt32(Session["LoginBranchid"]));

                        //    int int_Ledgerid = 0;
                        //    int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_Custid, "C", Session["FADbname"].ToString());
                        //    int_Voutypeid = obj_da_FAVoucher.Selvoutypeid(Str_ddlVoucherType, Session["FADbname"].ToString());
                        //    if (int_Ledgerid == 0)
                        //    {
                        //        int_Ledgerid = Fn_Getcustomergroupid(int_Custid, Str_ddlVoucherType);
                        //    }
                        //    //DateTime dtdate = DateTime.Parse(Utility.fn_ConvertDate(Grd_Approval.Rows[row.RowIndex].Cells[12].Text));
                        //    DateTime dtdate = DateTime.Parse((Grd_Approval.Rows[Row_ID].Cells[21].Text));     //NewOne       //21/07/2022
                        //    string Str_CustType = obj_da_Customer.GetCustomerType(int_Custid);
                        //    if (Str_CustType == "P" || Str_CustType == "E")
                        //    {
                        //        DataTable dt = new DataTable();
                        //        dt = obj_da_Invoice.GetOtherDCNAmount(int_Invoiceno, "CNHead", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["Vouyear"].ToString()));
                        //        string Str_Curr = "";
                        //        double F_Curr = 0;
                        //        if (dt.Rows.Count > 0)
                        //        {
                        //            Str_Curr = dt.Rows[0]["curr"].ToString();
                        //            F_Curr = double.Parse(dt.Rows[0]["amt"].ToString());
                        //        }
                        //        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, dtdate, char.Parse(type), int.Parse(Session["Vouyear"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), CSTAmount, Str_Curr, F_Curr, int_Custid);
                        //    }
                        //    else
                        //    {

                        //        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, dtdate, char.Parse(type), int.Parse(Session["Vouyear"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), CSTAmount, "", 0, int_Custid);
                        //    }
                        //}

                        //str_favourname = row.Cells[2].Text.ToString();
                        //obj_da_Cheque.UpdChequeRequest(int_Invoiceno, int.Parse(Session["Vouyear"].ToString()), Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), int_Empid, "PA", char.Parse("C"), "", str_favourname);

                    }
                    if (hid_voutypeid.Value.ToString() == "1")
                    {
                        //app = 1;
                        //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "DNCNApproval", "alertify.alert('DN # :" + int_Invoiceno + "transferred');", true);
                        //StrScript += "DN # : " + Str_invoiceno + " Generated and Transfered";
                        obj_dt1 = obj_da_Invoice.ShowLVHead(int_Invoiceno, ddl_product.SelectedValue.ToString(), Convert.ToInt32(hid_voutypeid.Value), int_Vouyear, int_bid);
                        str_VType = "I";
                    }
                    //else if (lbl_Header.Text == "Transfer To Commercial PA")
                    if (hid_voutypeid.Value.ToString() == "2")
                    {
                       // app = 1;
                        //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "DNCNApproval", "alertify.alert('CN # :" + int_Invoiceno + "transferred');", true);
                        //StrScript += "CN # : " + Str_invoiceno + " Generated and Transfered";
                        obj_dt1 = obj_da_Invoice.ShowLVHead(int_Invoiceno, ddl_product.SelectedValue.ToString(), Convert.ToInt32(hid_voutypeid.Value), int_Vouyear, int_bid);
                        str_VType = "P";
                    }
                    if (obj_dt1.Rows.Count > 0)
                    {
                        Fn_DNCNBL(Convert.ToInt32(obj_dt1.Rows[0][3].ToString()), ddl_product.SelectedValue.ToString(), "Approve", obj_da_Log.GetDate(), int_Invoiceno, str_VType);
                    }

                    if (obj_da_Cost.CheckcostinginsertAfterjobclose(Convert.ToInt32(obj_dt1.Rows[0][3].ToString()), int_bid, ddl_product.SelectedValue.ToString(), int_Invoiceno, str_VType) == "false")
                    {
                        Fn_DNCNBL(Convert.ToInt32(obj_dt.Rows[0][3].ToString()), ddl_product.SelectedValue.ToString(), "Approve", obj_da_Log.GetDate(), invoinumber, str_VType);

                    }
                    if (hid_voutype.Value.ToString() == "SALES INVOICE")
                    {
                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                obj_da_Log.InsLogDetail(int_Empid, 1016, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                break;

                            case "FI":
                                obj_da_Log.InsLogDetail(int_Empid, 1023, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                break;

                            case "AE":
                                obj_da_Log.InsLogDetail(int_Empid, 1030, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                break;

                            case "AI":
                                obj_da_Log.InsLogDetail(int_Empid, 1037, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                break;
                            case "CH":
                                obj_da_Log.InsLogDetail(int_Empid, 1043, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                break;

                        }
                    }
                    else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                    {
                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                obj_da_Log.InsLogDetail(int_Empid, 1017, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                break;

                            case "FI":
                                obj_da_Log.InsLogDetail(int_Empid, 1024, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                break;

                            case "AE":
                                obj_da_Log.InsLogDetail(int_Empid, 1031, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                break;

                            case "AI":
                                obj_da_Log.InsLogDetail(int_Empid, 1038, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                break;
                            case "CH":
                                obj_da_Log.InsLogDetail(int_Empid, 1044, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                break;

                        }
                    }

                    Str_invoiceno = Str_invoiceno + int_Invoiceno.ToString() + ",";

                    /******************* For Auto mail *********************/
                    if (hid_voutype.Value.ToString() == "SALES INVOICE")
                    {
                        if (bos == false)
                        {
                            // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-Invoices", int_bid, Convert.ToInt32(hid_vouyear.Value), Session["FADbname"].ToString(), obj_da_Log.GetDate());
                        }
                        else if (bos == true)
                        {
                            // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "BOS", int_bid, Convert.ToInt32(hid_vouyear.Value), Session["FADbname"].ToString(), obj_da_Log.GetDate());
                        }
                    }
                    else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                    {
                        // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-CNOPS", int_bid, Convert.ToInt32(hid_vouyear.Value), Session["FADbname"].ToString(), obj_da_Log.GetDate());
                    }

                    /******************************************************/

                    //}
                    //else if (countinv != 1)
                    //{

                    //    ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                    //    return;
                    //}
                    //}
                    if (countinv != 1)
                    {

                        ScriptManager.RegisterStartupScript(Grd_Approval, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                        return;
                    }
                    if (Str_invoiceno.Length > 0)
                    {
                        Str_invoiceno = Str_invoiceno.Substring(0, Str_invoiceno.Length - 1);

                        if (hid_voutype.Value.ToString() == "SALES INVOICE" || hid_voutype.Value.ToString() == "SALES INVOICE OC")
                        {

                            StrScript += "Invoice # " + Str_invoiceno + " Generated and Transfered";

                            //if (invoinumber != 0)
                            //{
                            //    StrScript += "BOS # " + invoinumber + " Generated and Transfered";
                            //}
                            //if (int_Invoiceno != 0)
                            //{
                            //    StrScript += "Invoice # " + int_Invoiceno + " Generated and Transfered";
                            //}
                        }
                        else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE" || hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
                        {
                            StrScript += "PI # " + Str_invoiceno + " Generated and Transfered";
                        }
                        else if (hid_voutype.Value.ToString() == "Transfer To Commercial CN")
                        {
                            StrScript += "CN # " + Str_invoiceno + " Generated and Transfered";
                        }
                        else if (hid_voutype.Value.ToString() == "Transfer To Commercial DN")
                        {
                            StrScript += "DN # " + Str_invoiceno + " Generated and Transfered";
                        }

                        /* else if (hid_type.Value.ToString() == "ProOSDNApproval")
                         {
                             StrScript = "OSDN # " + Str_invoiceno + " Generated and Transfered";
                         }
                         else if (hid_type.Value.ToString() == "ProOSCNApproval")
                         {
                             StrScript = "OSCN # " + Str_invoiceno + " Generated and Transfered";
                         }*/

                    }
                    if (gsttype == 1)
                    {
                        StrScript += "GST TYPE not Updated for the Customer Name :" + gsttype_;
                    }
                    if (statename == 1)
                    {
                        StrScript += "State Name not Updated in Master Kindly update Master Customer for" + statename_;
                    }
                    if (supplyto == 1)
                    {
                        StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + supplyto_;
                    }

                    if (int_TDS == 1)
                    {
                        StrScript += " " + str_TDS;
                    }

                    if (int_tdstype == 1)
                    {
                        StrScript += " " + str_tdstype;
                    }

                    if (int_tdsdesc == 1)
                    {
                        StrScript += " " + str_tdsdesc;
                    }
                    if (countinv != 1)
                    {

                        StrScript += "Check Atleast One Ref#";
                        //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                        //return;
                    }
                    if (invoinumber != 0)
                    {
                        // Str_invoicenonew = Str_invoicenonew + invoinumber.ToString() + ",";
                        StrScript += "BOS # " + Str_invoicenonew;
                    }

                    if (Str_invoicenonew != "")
                    {
                        // Str_invoicenonew = Str_invoicenonew + invoinumber.ToString() + ",";
                        StrScript += "Freight Inv # " + Str_invoicenonew;
                    }

                    // ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert(" + StrScript + ");", true);
                }


                    //////////////////////////////////////////////////////////////////////////////////////////////////





                else if (hid_voutype.Value.ToString() == "OSSI" || hid_voutype.Value.ToString() == "OSPI")
                {
                    //foreach (GridViewRow row in Grd_Approval.Rows)
                    //{
                    //  CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
                    //if (Chk.Checked == true)
                    //{
                    countinv = 1;
                    int_Refno = int.Parse(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString());
                    jobnoosdn = int.Parse(Grd_Approval.Rows[Row_ID].Cells[4].Text.ToString());
                    int_Vouyear = int.Parse(Grd_Approval.DataKeys[Row_ID].Values[0].ToString());
                    if (hid_voutypeid.Value == "5")
                    {
                        hid_type.Value = "ProOSDNApproval";
                    }
                    else
                    {
                        hid_type.Value = "ProOSCNApproval";
                    }
                    /******************* For Auto mail *********************/
                    hid_refno.Value = Grd_Approval.Rows[Row_ID].Cells[2].Text;
                    hid_vouyear.Value = Grd_Approval.DataKeys[Row_ID].Values[0].ToString();
                    /****************************************/

                    // dcno = Approveobj.UpdProApprovalOSDCN(refno, strblno, Login.logempid, strTranType, vouyear, branchid, strFType)
                    hid_stamt.Value = Grd_Approval.Rows[Row_ID].Cells[19].Text;
                    hid_supplyto.Value = Grd_Approval.Rows[Row_ID].Cells[20].Text;

                    //hid_stamt.Value = row.Cells[16].Text.ToString();         //NewOne       //21/07/2022
                    //        hid_supplyto.Value = row.Cells[17].Text.ToString();      //NewOne       //21/07/2022
                    string emp = Grd_Approval.Rows[Row_ID].Cells[8].Text;
                    int empp = employeeobj.GetNEmpid(emp);

                    dtosdn = obj_da_OSDNCN.GetCheckosdncnnewLV(Str_Trantype, jobnoosdn, int_bid);
                    int cnt = 0;
                    cnt = dtosdn.Rows.Count;
                    if (cnt == 1)
                    {
                        if (int_osdncn1 == 0)
                        {
                            str_osdncn1 = int_Refno.ToString();
                        }
                        else
                        {
                            str_osdncn1 = " ," + int_Refno.ToString();
                        }
                        int_osdncn1 = 1;
                        //continue;

                    }

                    else
                    {
                        DataTable dtt = new DataTable();

                        DataTable dtnewexrate1 = obj_da_Invoice.GET_exratechecknewLV(int_Refno, int_bid, int_Vouyear, jobnoosdn, Str_Trantype, 0);
                        if (dtnewexrate1.Rows.Count > 0)
                        {
                            StrScript += "Ex.Rate Different in Voucher Details " + int_Refno + ".Kindly check Proforma Invoice";
                            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                            //continue;
                        }

                        dtt = obj_da_Approval.getdebitadviseactamtcheckLV(int_Vouyear, int_Refno, Convert.ToInt32(Session["LoginBranchid"].ToString()), jobnoosdn, Str_Trantype, hid_voutype.Value.ToString());
                        if (dtt.Rows.Count > 0)
                        {
                            StrScript += "Taxable amount is mismatch for the Ref # : " + int_Refno + ",.Kindly update the ProOSDN/CN charge again and Save it";
                            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                            //continue;
                        }

                        int amount1 = obj_da_Approval.getacosdncnamoutcheckLV(Str_Trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Refno, hid_voutype.Value.ToString());
                        if (amount1 == 1)
                        {
                            StrScript += "Taxable amount is mismatch for the Ref # : " + int_Refno + ",.Kindly update the ProOSDN/CN charge again and Save it";
                            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                            //continue;
                        }
                        else
                        {

                        }
                        if (hid_voutypeid.Value == "5")
                        {
                            int_intdcno = obj_da_Approval.UpdproappOSDNCN(int_Refno, int_Empid, int_bid, int_Invoiceno, "ProOSDNApproval");
                            // hid_type.Value = "ProOSDNApproval";
                        }
                        else
                        {
                            int_intdcno = obj_da_Approval.UpdproappOSDNCN(int_Refno, int_Empid, int_bid, int_Invoiceno, "ProOSCNApproval");
                            //  hid_type.Value = "ProOSCNApproval";
                        }
                        //int_intdcno = obj_da_Approval.UpdproappOSDNCNOSV(int_Refno, Grd_Approval.Rows[Row_ID].Cells[4].Text.ToString(), int_Empid, Str_Trantype, int_Vouyear, int_bid, int.Parse(Grd_Approval.DataKeys[Row_ID].Values[2].ToString()));

                        ////int_intdcno = obj_da_Approval.UpdProApprovalOSDCN(int_Refno, Convert.ToInt32(row.Cells[1].Text.ToString()), int_Empid, Str_Trantype, int_Vouyear, int_bid, hid_type.Value.ToString());
                        //obj_da_Approval.insForOSDNCNDNCNNumberLV(int_intdcno, hid_voutype.Value.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[4].Text), Str_Trantype, int_Refno);
                        //einvoice start 28 may 22
                        ProINVobj.UpdAfterjobclose(int_intdcno, int_bid, Convert.ToInt32(hid_voutypeid.Value), "");
                        if (hid_voutype.Value.ToString() == "OSSI" && int_intdcno > 0)
                        {

                            //newly GST added

                            // Einvoice newly added satrt//

                            div_id = objnew.getinsmastergstdetailsMR(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            //  div_id = "0";

                            string custid1ung = objnew.getunregcustvouchers(int_intdcno, int_Vouyear, int_bid, "D");


                            if (div_id == "1" && custid1ung == "0")
                            {

                                try
                                {

                                    //int vouno = 1018;  // 793 ,826
                                    //int bid = 13;
                                    //int vouyear = 2020;
                                    //int cid = 1;

                                    //invoinumber = 700;
                                    //int_bid = 1;
                                    //int_Vouyear = 2020;
                                    //int_divisionid = 1;
                                    string json2 = objnew.getgstdetails(int_intdcno, int_bid, int_Vouyear, "D");
                                    //   DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", "{\r\n    \"Version\": \"1.1\",\r\n    \"TranDtls\": {\r\n        \"TaxSch\": \"GST\",\r\n        \"SupTyp\": \"B2B\",\r\n        \"RegRev\": \"N\"\r\n    },\r\n    \"DocDtls\": {\r\n        \"Typ\": \"INV\",\r\n        \"No\": \"IN2021CHEOE100\",\r\n        \"Dt\": \"13\\/05\\/2020\"\r\n    },\r\n    \"SellerDtls\": {\r\n        \"Gstin\": \"29AAFCC9980MZZT\",\r\n        \"LglNm\": \"DEMO CUSTOMER21577\",\r\n        \"Addr1\": \"CUSTOMER ADDRESS\",\r\n        \"Loc\": \"Supreme Court\",\r\n        \"Pin\": 110001,\r\n        \"Stcd\": \"29\"\r\n    },\r\n    \"BuyerDtls\": {\r\n        \"Gstin\": \"07AAACA4691C2ZY\",\r\n        \"LglNm\": \"DEMO CUSTOMER21577\",\r\n        \"Pos\": \"07\",\r\n        \"Addr1\": \"CUSTOMER ADDRESS\",\r\n        \"Loc\": \"Supreme Court\",\r\n        \"Pin\": 110001,\r\n        \"Stcd\": \"07\"\r\n    },\r\n    \"ItemList\": [{\r\n        \"SlNo\": \"1\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 5.00,\r\n        \"TotAmt\": 388.25,\r\n        \"AssAmt\": 388.25,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 69.89,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 458.14\r\n    }, {\r\n        \"SlNo\": \"2\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 4050.00,\r\n        \"TotAmt\": 4050.00,\r\n        \"AssAmt\": 4050.00,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 729.00,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 4779.00\r\n    }, {\r\n        \"SlNo\": \"3\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 5500.00,\r\n        \"TotAmt\": 5500.00,\r\n        \"AssAmt\": 5500.00,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 990.00,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 6490.00\r\n    }],\r\n    \"ValDtls\": {\r\n        \"AssVal\": 9938.25,\r\n        \"CgstVal\": 0.00,\r\n        \"SgstVal\": 0.00,\r\n        \"IgstVal\": 1788.89,\r\n        \"RndOffAmt\": 0.00,\r\n        \"TotInvVal\": 11727.00\r\n    }\r\n}\r\n\r\n");

                                    string datajson1 = DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", json2);
                                    DataTable dtjson1 = new DataTable();
                                    string status = "";
                                    if (datajson1 != null)
                                    {
                                        dtjson1 = ConvertJsonToDatatable(datajson1);
                                        status = dtjson1.Rows[0][0].ToString().Trim();
                                    }
                                    else
                                    {
                                        status = "0";
                                    }

                                    string message1 = "";
                                    string IRN1 = "";
                                    string Ackdt = "";
                                    string Ackno = "";
                                    string status1 = "";
                                    string SignedQRCode = "";
                                    string SignedInvoice = "";

                                    string uuid = "";
                                    string SignedQrCodeImgUrl = "";
                                    string IrnStatus = "";
                                    string EwbStatus = "";
                                    string Irp = "";

                                    string EwbDt = "";
                                    string EwbNo = "";
                                    string EwbValidTill = "";
                                    string Remarks = "";

                                    if (status == "1")
                                    {
                                        //message1 = dtjson1.Rows[0][1].ToString().Replace('"', ' ').Trim();
                                        //IRN1 = dtjson1.Rows[0][2].ToString().Replace('"', ' ').Trim();
                                        //Ackdt = dtjson1.Rows[0][3].ToString().Replace('"', ' ').Trim();
                                        //Ackno = dtjson1.Rows[0][4].ToString().Replace('"', ' ').Trim();
                                        //status1 = dtjson1.Rows[0][5].ToString().Replace('"', ' ').Trim();
                                        //SignedQRCode = dtjson1.Rows[0][6].ToString().Replace('"', ' ').Trim();

                                        //SignedInvoice = dtjson1.Rows[0][7].ToString().Replace('"', ' ').Trim();



                                        //uuid = dtjson1.Rows[0][8].ToString().Replace('"', ' ').Trim();
                                        //SignedQrCodeImgUrl = dtjson1.Rows[0][9].ToString().Replace('"', ' ').Trim();
                                        //IrnStatus = dtjson1.Rows[0][10].ToString().Replace('"', ' ').Trim();
                                        //EwbStatus = dtjson1.Rows[0][11].ToString().Replace('"', ' ').Trim();
                                        //Irp = dtjson1.Rows[0][12].ToString().Replace('"', ' ').Trim();


                                        //message1 = dtjson1.Rows[0]["message"].ToString().Replace('"', ' ').Trim();
                                        //IRN1 = dtjson1.Rows[0]["Irn"].ToString().Replace('"', ' ').Trim();
                                        //Ackdt = dtjson1.Rows[0]["AckDt"].ToString().Replace('"', ' ').Trim();
                                        //Ackno = dtjson1.Rows[0]["AckNo"].ToString().Replace('"', ' ').Trim();
                                        //status1 = dtjson1.Rows[0]["Status"].ToString().Replace('"', ' ').Trim();
                                        //SignedQRCode = dtjson1.Rows[0]["SignedQRCode"].ToString().Replace('"', ' ').Trim();

                                        //SignedInvoice = dtjson1.Rows[0]["SignedInvoice"].ToString().Replace('"', ' ').Trim();



                                        //uuid = dtjson1.Rows[0]["uuid"].ToString().Replace('"', ' ').Trim();
                                        //SignedQrCodeImgUrl = dtjson1.Rows[0]["SignedQrCodeImgUrl"].ToString().Replace('"', ' ').Trim();
                                        //IrnStatus = dtjson1.Rows[0]["IrnStatus"].ToString().Replace('"', ' ').Trim();
                                        //EwbStatus = dtjson1.Rows[0]["EwbStatus"].ToString().Replace('"', ' ').Trim();
                                        //Irp = dtjson1.Rows[0]["Irp"].ToString().Replace('"', ' ').Trim();

                                        //EwbDt = dtjson1.Rows[0]["EwbDt"].ToString().Replace('"', ' ').Trim();
                                        //EwbNo = dtjson1.Rows[0]["EwbNo"].ToString().Replace('"', ' ').Trim();
                                        //EwbValidTill = dtjson1.Rows[0]["EwbValidTill"].ToString().Replace('"', ' ').Trim();
                                        //Remarks = dtjson1.Rows[0]["Remarks"].ToString().Replace('"', ' ').Trim();



                                        message1 = dtjson1.Rows[0][1].ToString().Replace('"', ' ').Trim();    		//	1   



                                        IRN1 = dtjson1.Rows[0][2].ToString().Replace('"', ' ').Trim();       // 2

                                        gstirn_ = gstirn_ + "," + message1 + " " + IRN1 + " ,";
                                        gstirn = 0;

                                        Ackdt = dtjson1.Rows[0][3].ToString().Replace('"', ' ').Trim();     //3
                                        Ackno = dtjson1.Rows[0][4].ToString().Replace('"', ' ').Trim();    // 4 
                                        status1 = dtjson1.Rows[0][7].ToString().Replace('"', ' ').Trim();  // 7
                                        SignedQRCode = dtjson1.Rows[0][10].ToString().Replace('"', ' ').Trim(); //10

                                        SignedInvoice = dtjson1.Rows[0][11].ToString().Replace('"', ' ').Trim(); //11



                                        uuid = dtjson1.Rows[0][12].ToString().Replace('"', ' ').Trim();  //12
                                        SignedQrCodeImgUrl = dtjson1.Rows[0][13].ToString().Replace('"', ' ').Trim();// 13 
                                        IrnStatus = dtjson1.Rows[0][14].ToString().Replace('"', ' ').Trim();  //14 
                                        EwbStatus = dtjson1.Rows[0][15].ToString().Replace('"', ' ').Trim(); //15
                                        Irp = dtjson1.Rows[0][16].ToString().Replace('"', ' ').Trim(); //16

                                        EwbDt = dtjson1.Rows[0][5].ToString().Replace('"', ' ').Trim(); //5
                                        EwbNo = dtjson1.Rows[0][6].ToString().Replace('"', ' ').Trim(); //6
                                        EwbValidTill = dtjson1.Rows[0][9].ToString().Replace('"', ' ').Trim(); // 9
                                        Remarks = dtjson1.Rows[0][8].ToString().Replace('"', ' ').Trim();//  8



                                        objnew.insmastergstdetails(int_intdcno, int_Vouyear, int_bid, int_divisionid, status, message1, IRN1, Ackdt, Ackno, status1, SignedQRCode, SignedInvoice, uuid, SignedQrCodeImgUrl, IrnStatus, EwbStatus, Irp, "D", EwbDt, EwbNo, EwbValidTill, Remarks);


                                    }
                                    else
                                    {
                                        if (datajson1 != null)
                                        {
                                            message1 = dtjson1.Rows[0][1].ToString().Replace('"', ' ').Trim();

                                            gstirnerr_ = gstirnerr_ + "," + message1;
                                            gstirnerr = 1;

                                        }
                                        else
                                        {
                                            message1 = "The GSTZen user credentials provided in the request are invalid-.";
                                        }
                                        objnew.insmastergstdetails(int_intdcno, int_Vouyear, int_bid, int_divisionid, status, message1, "", "", "", "", "", "", "", "", "", "", "", "D", "", "", "", "");
                                    }


                                }
                                catch (Exception ex)
                                {
                                    string message = ex.Message.ToString();
                                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                                }


                            }

                            // Einvoice newly added end//
                        }


                        //end


                    }

                    //log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + int_intdcno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                    if (hid_voutype.Value.ToString() == "OSSI")
                    {
                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                obj_da_Log.InsLogDetail(int_Empid, 1018, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                break;

                            case "FI":
                                obj_da_Log.InsLogDetail(int_Empid, 1025, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                break;

                            case "AE":
                                obj_da_Log.InsLogDetail(int_Empid, 1032, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                break;

                            case "AI":
                                obj_da_Log.InsLogDetail(int_Empid, 1039, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                break;

                        }
                    }
                    else if (hid_voutype.Value.ToString() == "OSPI")
                    {
                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                obj_da_Log.InsLogDetail(int_Empid, 1019, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                break;

                            case "FI":
                                obj_da_Log.InsLogDetail(int_Empid, 1026, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                break;

                            case "AE":
                                obj_da_Log.InsLogDetail(int_Empid, 1036, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                break;

                            case "AI":
                                obj_da_Log.InsLogDetail(int_Empid, 1040, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                break;

                        }
                    }
                    if (int_intdcno != 0)
                    {
                        Str_invoiceno = Str_invoiceno + int_intdcno.ToString() + ",";
                    }
                    else
                    {
                        StrScript += "OSDN # or OSCN # Not Generated and Transfered";

                    }

                    /******************* For Auto mail *********************/
                    if (hid_voutype.Value.ToString() == "ProOSDNApproval")
                    {
                        // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-OSDN", int_bid, Convert.ToInt32(hid_vouyear.Value), Session["FADbname"].ToString(), obj_da_Log.GetDate());
                    }
                    else if (hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-OSCN", int_bid, Convert.ToInt32(hid_vouyear.Value), Session["FADbname"].ToString(), obj_da_Log.GetDate());
                    }
                    /******************************************************/

                    //}

                    //}
                    if (countinv != 1)
                    {

                        ScriptManager.RegisterStartupScript(Grd_Approval, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                        return;
                    }
                    if (Str_invoiceno.Length > 0)
                    {
                        Str_invoiceno = Str_invoiceno.Substring(0, Str_invoiceno.Length - 1);

                        // string StrScript = "";
                        if (hid_voutype.Value.ToString() == "OSSI")
                        {
                            StrScript += "OSDN # " + Str_invoiceno + " Generated and Transfered";
                        }
                        else if (hid_voutype.Value.ToString() == "OSPI")
                        {
                            StrScript += "OSCN # " + Str_invoiceno + " Generated and Transfered";
                        }

                    }
                    if (gsttype == 1)
                    {
                        StrScript += "GST TYPE not Updated for the Customer Name :" + gsttype_;
                    }
                    if (statename == 1)
                    {
                        StrScript += "State Name not Updated in Master Kindly update Master Customer for" + statename_;
                    }
                    if (supplyto == 1)
                    {
                        StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + supplyto_;
                    }
                    if (int_osdncn1 == 1)
                    {
                        StrScript += "Kindly Save the Proforma Voucher Again and Approve for" + str_osdncn1;
                    }

                }

                Fn_Getdetail();

                //{
                ScriptManager.RegisterStartupScript(Grd_Approval, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

                //}
                //  UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }
        private void Fn_Getdetail()
        {
            try
            {
                DataTable dcon = Appobj.Checkcountry(int.Parse(Session["LoginBranchid"].ToString()));
                int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
                if (con == 1102 || con == 102)
                {
                    if (ddl_voutype.SelectedValue != "2" && ddl_voutype.SelectedValue != "23")
                    {
                        Grd_Approval.Columns[8].Visible = false;
                        Grd_Approval.Columns[9].Visible = false;
                        Grd_Approval.Columns[10].Visible = false;
                        Grd_Approval.Columns[11].Visible = false;       //NewOne    //21/07/2022
                        Grd_Approval.Columns[12].Visible = false;
                        Grd_Approval.Columns[13].Visible = false;
                        Grd_Approval.Columns[14].Visible = false;
                        Grd_Approval.Columns[15].Visible = false;
                        Grd_Approval.Columns[16].Visible = false;
                    }
                    else
                    {
                        Grd_Approval.Columns[8].Visible = false;
                        Grd_Approval.Columns[9].Visible = true;
                        Grd_Approval.Columns[10].Visible = true;
                        Grd_Approval.Columns[11].Visible = true;       //NewOne    //21/07/2022
                        Grd_Approval.Columns[12].Visible = true;
                        Grd_Approval.Columns[13].Visible = true;
                        Grd_Approval.Columns[14].Visible = true;
                        Grd_Approval.Columns[15].Visible = true;
                        Grd_Approval.Columns[16].Visible = true;
                    }
                }
                else
                {
                    Grd_Approval.Columns[8].Visible = false;
                    Grd_Approval.Columns[9].Visible = false;
                    Grd_Approval.Columns[10].Visible = false;
                    Grd_Approval.Columns[11].Visible = false;       //NewOne    //21/07/2022
                    Grd_Approval.Columns[12].Visible = false;
                    Grd_Approval.Columns[13].Visible = false;
                    Grd_Approval.Columns[14].Visible = false;
                    Grd_Approval.Columns[15].Visible = false;
                    Grd_Approval.Columns[16].Visible = false;
                }

                DataTable obj_dt = new DataTable();
                //DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                obj_dt = obj_da_Approval.GetProApprovependingLV_AJclose(ddl_product.SelectedValue, int.Parse(Session["LoginBranchid"].ToString()), Convert.ToInt32(ddl_voutype.SelectedValue));
                Grd_Approval.DataSource = obj_dt;
                Grd_Approval.DataBind();
                if (ddl_voutype.SelectedValue != "0")
                {
                    if (obj_dt.Rows.Count > 0)
                    {

                        DataView obj_dtview = new DataView(obj_dt);
                        obj_dtview.RowFilter = "voutype='" + ddl_voutype.SelectedItem.Text + "' ";
                        obj_dt = obj_dtview.ToTable();
                        Grd_Approval.DataSource = obj_dt;
                        Grd_Approval.DataBind();
                        if (obj_dt.Rows.Count > 0)
                        {
                            hid_voutypeid.Value = obj_dt.Rows[0]["voutypeid"].ToString();
                        }
                    }
                }
                //NewOne    //21/07/2022
                //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataTable dlp = new DataTable();
                dlp = obj_da_Invoice.sp_ddlsectionnew1();

                for (int j = 0; j < Grd_Approval.Rows.Count; j++)
                {
                    var ddl1 = (DropDownList)Grd_Approval.Rows[j].FindControl("ddl_section");

                    ddl1.DataSource = dlp;
                    ddl1.DataTextField = "tdssection";

                    ddl1.DataBind();

                }


                TextBox lnkbtn;
                int i = 0;
                if (Grd_Approval.Rows.Count > 0)
                {
                    if (obj_dt.Rows.Count > 0)
                    {
                        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                            {

                                lnkbtn = (TextBox)(Grd_Approval.Rows[i].FindControl("txtpercentage"));       //NewOne       //22/07/2022
                                lnkbtn.Visible = true;

                            }
                            else
                            {
                                lnkbtn = (TextBox)(Grd_Approval.Rows[i].FindControl("txtpercentage"));       //NewOne       //22/07/2022
                                lnkbtn.Visible = false;
                            }

                        }
                    }
                }



            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        protected void Grd_Approval_SelectedIndexChanged(object sender, EventArgs e)
        {
            approval();

        }
        private void Fn_Getcontainer(DataTable dt, int int_Rowindex)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    string Str_sblno = "";
                    if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                    {
                        Str_sblno = dt.Rows[0]["blno"].ToString();
                    }
                    else
                    {
                        Str_sblno = dt.Rows[0]["hawblno"].ToString();
                    }
                    if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                    {
                        if (Grd_Approval.Rows[int_Rowindex].Cells[4].Text.ToString().Trim().Length > 0)
                        {
                            if (Grd_Approval.Rows[int_Rowindex].Cells[4].Text.ToString() == Str_sblno)
                            {
                                //DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
                                DataTable obj_dt = new DataTable();

                                obj_dt = obj_da_invoice.GetHBLContainerDtls(Str_sblno, Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
                                if (obj_dt.Rows.Count > 0)
                                {
                                    var obj_Container = (from r in obj_dt.AsEnumerable()
                                                         select r.Field<string>("containerno"));
                                    hid_container.Value = string.Join("-", obj_Container);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        private void Fn_GetCredit(int int_Rowindex)
        {
            try
            {
                //DataAccess.Accounts.OSDNCN obj_da_invoice = new DataAccess.Accounts.OSDNCN();
                DataSet obj_ds = new DataSet();

                obj_ds = obj_da_invoice2.RptOSDNCNProFromJobNo(Session["StrTranType"].ToString(), int.Parse(Grd_Approval.Rows[int_Rowindex].Cells[4].Text.ToString()), int.Parse(Session["LoginBranchid"].ToString()));

                if (obj_ds.Tables.Count > 1)
                {
                    hid_debit.Value = (obj_ds.Tables[1].Rows.Count > 0 ? obj_ds.Tables[2].Rows.Count : 0).ToString();
                    hid_credit.Value = (obj_ds.Tables[2].Rows.Count > 0 ? obj_ds.Tables[2].Rows.Count : 0).ToString();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        public void approval()
        {

            DateTime get_date, GST_date;
            // get_date = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
            get_date = Convert.ToDateTime(Grd_Approval.SelectedRow.Cells[21].Text.ToString());       //NewOne       //22/07/2022
            GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
            DataTable dcon = Appobj.Checkcountry(int.Parse(Session["LoginBranchid"].ToString()));
            int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
            string header = "";
            double amount = Convert.ToDouble(Grd_Approval.SelectedRow.Cells[7].Text.ToString());
            //if (hid_credit.Value == "")
            //{
            //    hid_credit.Value = "0";
            //}

            //if (hid_debit.Value == "")
            //{
            //    hid_debit.Value = "0";
            //}
            string str_Voucher = "", Str_StrTrantype = "";
            int int_Vouno = 0, int_vouyear = 0;
            //Session["str_sfs"] = "";
            //Session["str_sp"] = "";
            string Str_SP1 = "", Str_SF1 = "", Str_SF2 = "", Str_SP2 = "", str_RptName1 = "", str_RptName2 = "", BL = "";
            Str_StrTrantype = ddl_product.SelectedValue;
            // if (Grd_Approval.SelectedRow.Cells[5].Text == "Transfer")

            if (Str_StrTrantype == "CH")
            {
                return;
            }
            DataTable obj_dt = new DataTable();
            hid_voutype.Value = Grd_Approval.SelectedRow.Cells[1].Text.ToString();
            if (hid_voutype.Value.ToString() == "SALES INVOICE")
            {
                header = "Invoice";
                str_Voucher = "Invoice";
            }
            else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
            {
                header = "PA";
                str_Voucher = "PA";
            }
            else if (hid_voutype.Value.ToString() == "OSSI")
            {
                str_Voucher = "OSSI";
            }
            else if (hid_voutype.Value.ToString() == "SALES INVOICE OC")
            {
                header = "Invoice FC";
                str_Voucher = "Invoice FC";
            }

            else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
            {
                header = "PA FC";
                str_Voucher = "PA FC";
            }
            else
            {
                str_Voucher = "OSPI";
            }

            //DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
            if (!DBNull.Value.Equals(Grd_Approval.SelectedRow.Cells[2].Text))
            {
                int_Vouno = int.Parse(Grd_Approval.SelectedRow.Cells[2].Text.ToString());
            }
            else
            {
                return;
            }
            int_vouyear = Convert.ToInt32(Grd_Approval.SelectedDataKey.Values[0].ToString());
            BL = HttpUtility.HtmlDecode(Grd_Approval.SelectedRow.Cells[4].Text.ToString());
            obj_dt = obj_da_invoice.CheckHblno(BL, Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
            Fn_Getcontainer(obj_dt, Grd_Approval.SelectedRow.RowIndex);
            if (str_Voucher == "OSSI" || str_Voucher == "OSPI")
            {
                Fn_GetCredit(Grd_Approval.SelectedRow.RowIndex);
            }
            string Str_RptName = "", Str_SF = "", Str_SP = "", Str_Script = "";
            int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            if (obj_dt.Rows.Count > 0)
            {
                if (str_Voucher == "Invoice")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProInvoice.rpt";
                        // Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProInvoice.rpt";
                        // Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProInvoice.rpt";
                        Str_SP = "Lcurr=INR ";
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProInvoice.rpt";
                        Str_SP = "Lcurr=INR";
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHProInvoice.rpt";
                        Str_SP = "Lcurr=INR";
                    }

                    Str_SF = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\"  and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}=" + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear;
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    if (get_date >= GST_date)
                    {
                        if (con == 1102 || con == 102)
                        {
                            Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                        else
                        {
                            Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }

                        // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&trantype=" + Str_StrTrantype + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);

                    Session["str_sp"] = Str_SP;
                }
                else if (str_Voucher == "Invoice FC")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProInvoice.rpt";
                        // Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProInvoice.rpt";
                        //Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProInvoice.rpt";
                        Str_SP = "Lcurr=INR ";
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProInvoice.rpt";
                        Str_SP = "Lcurr=INR";
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHProInvoice.rpt";
                        Str_SP = "Lcurr=INR";
                    }

                    Str_SF = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\"  and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}=" + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear;
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    if (get_date >= GST_date)
                    {
                        if (con == 1102 || con == 102)
                        {
                            Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                        else
                        {
                            Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }

                        // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&trantype=" + Str_StrTrantype + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);

                    Session["str_sp"] = Str_SP;
                }
                if (str_Voucher == "PA")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHAPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }

                    Str_SP = "Lcurr=INR";
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                    if (get_date >= GST_date)
                    {
                        // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        if (con == 1102 || con == 102)
                        {
                            Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                        else
                        {
                            Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    }

                    Session["str_sp"] = Str_SP;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                }

                if (str_Voucher == "PA FC")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHAPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }

                    Str_SP = "Lcurr=INR";
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                    if (get_date >= GST_date)
                    {
                        // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        if (con == 1102 || con == 102)
                        {
                            Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                        else
                        {
                            Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    }

                    Session["str_sp"] = Str_SP;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                }
            }
            else
            {

                if (str_Voucher == "Invoice")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //   Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //  Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //   Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR ";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "BT")
                    {
                        Str_RptName = "BTProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear;
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                    if (get_date >= GST_date)
                    {
                    }
                    else
                    {
                        if (con == 1102 || con == 102)
                        {
                            Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                        else
                        {
                            Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                    }
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1054, 4, Convert.ToInt32(Session["LoginBranchid"]), int_Vouno.ToString());

                    Session["str_sp"] = Str_SP;
                }

                //

                if (str_Voucher == "Invoice FC")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //   Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        //  Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //   Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR ";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "BT")
                    {
                        Str_RptName = "BTProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear;
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                    if (get_date >= GST_date)
                    {
                    }
                    else
                    {
                        if (con == 1102 || con == 102)
                        {
                            Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                        else
                        {
                            Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                    }
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1054, 4, Convert.ToInt32(Session["LoginBranchid"]), int_Vouno.ToString());

                    Session["str_sp"] = Str_SP;
                }
                //
                if (str_Voucher == "PA FC")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }

                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHAProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "BT")
                    {
                        Str_RptName = "BTProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    Str_SP = "Lcurr=INR";
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1055, 4, Convert.ToInt32(Session["LoginBranchid"]), int_Vouno.ToString());

                    Session["str_sp"] = Str_SP;
                    if (get_date >= GST_date)
                    {
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    }

                }
                if (str_Voucher == "PA")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }

                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHAProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "BT")
                    {
                        Str_RptName = "BTProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    Str_SP = "Lcurr=INR";
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1055, 4, Convert.ToInt32(Session["LoginBranchid"]), int_Vouno.ToString());

                    Session["str_sp"] = Str_SP;
                    if (get_date >= GST_date)
                    {
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    }

                }

                string str_curr = "";
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                if (str_Voucher == "OSSI")
                {
                    int int_jobno = int.Parse(Grd_Approval.SelectedRow.Cells[4].Text.ToString());

                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;

                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {

                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;
                        //Session["str_sp"] = Str_SP;

                    }


                }
                if (str_Voucher == "OSPI")
                {
                    int int_jobno = int.Parse(Grd_Approval.SelectedRow.Cells[4].Text.ToString());

                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());

                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }

                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }



                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);

                    return;
                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);

            }
            // UserRights();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        // Einvoice newly added satrt//

        public static string DineshhttpPostWebRequets(string url, string postData)
        {
            string strResponse = null;
            string dataval = null;
            string tokenvalue = null;
            DataAccess.Documents objnew = new DataAccess.Documents();

            if (System.Net.ServicePointManager.MaxServicePointIdleTime > 10000)
            {
                System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;
            }

            if (System.Net.ServicePointManager.MaxServicePoints != 0) //unlimit
                System.Net.ServicePointManager.MaxServicePoints = 0;
            // System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 |
(SecurityProtocolType)768 | (SecurityProtocolType)3072;
            //System.Net.ServicePointManager.SecurityProtocol =  SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 |  SecurityProtocolType.Tls;
            try
            {

                var webRequest = System.Net.WebRequest.Create(url);
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.Timeout = 120000;
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    webRequest.ContentType = "application/json";
                    //   webRequest.Headers.Add("Token", "ceadc473-7dc7-42f9-a99b-63ae924a8adb"); // M+R Einvoice Token
                    tokenvalue = objnew.geteinvoicetoken(Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));

                    webRequest.Headers.Add("Token", tokenvalue);  //"ceadc473-7dc7-42f9-a99b-63ae924a8adb"

                    webRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = webRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Close();
                        using (Stream s = webRequest.GetResponse().GetResponseStream())
                        {
                            using (StreamReader sr = new StreamReader(s))
                            {
                                strResponse = sr.ReadToEnd();
                            }
                        }

                    }
                }
                webRequest = null;

            }
            catch (Exception ex)
            {

            }
            return strResponse;
        }
        protected DataTable ConvertJsonToDatatable(string jsonString)
        {
            DataTable dt = new DataTable();
            //strip out bad characters
            string[] jsonParts = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");

            //hold column names
            List<string> dtColumns = new List<string>();

            //get columns
            foreach (string jp in jsonParts)
            {
                //only loop thru once to get column names
                string[] propData = Regex.Split(jp.Replace("{", "").Replace("}", ""), ",");
                foreach (string rowData in propData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string n = rowData.Substring(0, idx - 1);
                        string v = rowData.Substring(idx + 1);
                        if (!dtColumns.Contains(n))
                        {
                            dtColumns.Add(n.Replace("'", ""));//'
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Error Parsing Column Name : {0}", rowData));
                    }

                }
                break; // TODO: might not be correct. Was : Exit For
            }

            //build dt
            foreach (string c in dtColumns)
            {
                dt.Columns.Add(c);
            }
            //get table data
            foreach (string jp in jsonParts)
            {
                string[] propData = Regex.Split(jp.Replace("{", "").Replace("}", ""), ",");
                DataRow nr = dt.NewRow();
                foreach (string rowData in propData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string n = rowData.Substring(0, idx - 1).Replace("'", "");
                        string v = rowData.Substring(idx + 1).Replace("'", "");
                        nr[n] = v;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
                dt.Rows.Add(nr);
            }
            return dt;
        }

        protected void ddl_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_product.SelectedValue != "0")
            {

            }

        }
        private void Fn_DNCNBL(int jobno, string trantype, string type, DateTime CDate, int vouno, string voutype)
        {
            int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            double BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0;
            int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
            DateTime dtdate = CDate;
            //DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
           string tran1 = ddl_product.SelectedValue;
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            //if (type == "Closed")
            //{
            //    obj_dt = obj_da_Cost.GetDNCN4MISFromJobNo(jobno, int_bid, trantype);

            //}
            //else if (type == "Approve")
            //{
            //    obj_dt = obj_da_Cost.GetDNCN4MISFromVounonew(jobno, int_bid, trantype, vouno, voutype);
            //}
            if (type == "Closed")
            {
                obj_dt = obj_da_Cost.GetDNCN4MISFromJobNoLV(jobno, int_bid, trantype);

            }
            else if (type == "Approve")
            {
                obj_dt = obj_da_Cost.GetDNCN4MISFromVounonew(jobno, int_bid, trantype, vouno, voutype);
            }
            int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
            char Nomination = ' ';
            string blno;
            double volume = 0;
            if (obj_dt.Rows.Count > 0)
            {
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    blno = obj_dt.Rows[i]["blno"].ToString();
                    int_job = Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString());
                    if (tran1 != "CH")
                    {
                        MLO = Convert.ToInt32(obj_dt.Rows[i]["mlo"].ToString());
                    }
                    else
                    {
                        MLO = 0;
                    }
                    if (type == "Closed")
                    {
                        dtdate = CDate;
                    }
                    else if (type == "Approve")
                    {
                        dtdate = DateTime.Parse((obj_dt.Rows[i]["voudate"].ToString()));
                    }
                    obj_dttemp = obj_da_Cost.GetBLRowBL(blno, tran1, int_bid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        if (i < obj_dt.Rows.Count - 1)
                        {
                            if (obj_dt.Rows[i]["blno"].ToString() != obj_dt.Rows[i + 1]["blno"].ToString())
                            {
                                if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (obj_dt.Rows[i]["voutype"].ToString() == "I")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (obj_dt.Rows[i]["voutype"].ToString() == "P")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                            }
                            else
                            {
                                if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }

                                else if (obj_dt.Rows[i]["voutype"].ToString() == "I")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (obj_dt.Rows[i]["voutype"].ToString() == "P")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                            {
                                if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                {
                                    BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                }
                            }
                            else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
                            {
                                if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                {
                                    BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                }
                            }

                            else if (obj_dt.Rows[i]["voutype"].ToString() == "I")
                            {
                                if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                {
                                    BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                }
                            }
                            else if (obj_dt.Rows[i]["voutype"].ToString() == "P")
                            {
                                if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                {
                                    BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                }
                            }
                        }
                        int_job = Convert.ToInt32(obj_dttemp.Rows[0][0].ToString());
                        blno = obj_dttemp.Rows[0][1].ToString();
                        int_shipper = Convert.ToInt32(obj_dttemp.Rows[0][6].ToString());
                        int_consignee = Convert.ToInt32(obj_dttemp.Rows[0][7].ToString());
                        int_notify = Convert.ToInt32(obj_dttemp.Rows[0][8].ToString());
                        int_agent = Convert.ToInt32(obj_dttemp.Rows[0][9].ToString());
                        int_pol = Convert.ToInt32(obj_dttemp.Rows[0][10].ToString());
                        int_pod = Convert.ToInt32(obj_dttemp.Rows[0][11].ToString());
                        if (tran1 != "CH")
                        {
                            int_sales = obj_da_Cost.GetSalesPerson(blno, tran1, int_bid);
                        }
                        //Nomination = char.Parse(obj_dttemp.Rows[0][4].ToString());
                        if (!string.IsNullOrEmpty(obj_dttemp.Rows[0][4].ToString()))
                        {
                            //Nomination = Convert.ToChar(obj_dt.Rows[j][4].ToString());
                            if (obj_dttemp.Rows[0][4].ToString().Length > 0)
                            {
                                Nomination = char.Parse(obj_dttemp.Rows[0][4].ToString());
                            }
                        }
                        else
                        {
                            Nomination = ' ';
                        }

                        volume = Convert.ToDouble(obj_dttemp.Rows[0][5].ToString());

                        if (tran1 == "FE" || tran1 == "FI")
                        {
                            if (obj_dttemp.Rows[0][2].ToString().Length > 0 && obj_dttemp.Rows[0][3].ToString().Length > 0)
                            {
                                int_Cont20 = Convert.ToInt32(obj_dttemp.Rows[0][2].ToString());
                                int_Cont40 = Convert.ToInt32(obj_dttemp.Rows[0][3].ToString());
                                JobType = Convert.ToInt32(obj_dt.Rows[i]["jobtype"].ToString());
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI" || trantype == "CH")
                        {
                            int_Cont20 = 0;
                            int_Cont40 = 0;
                            JobType = 0;
                        }
                        BL_Amount = BL_Amount + BL_debit;
                        BL_Expense = BL_Expense + BL_credit;

                        //obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, volume, int_Cont20, int_Cont40, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, dtdate, MLO, 0, char.Parse(string.Empty));
                        obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, tran1, int_bid, blno, 0, 0, 0, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, dtdate, MLO, vouno, Convert.ToChar(voutype));
                    }
                    else
                    {
                        Fn_DNCNMBL(jobno, tran1, vouno, voutype, i, obj_dt, int_bid, dtdate);
                    }
                }
            }

        }
        private void Fn_DNCNMBL(int jobno, string trantype, int vouno, string voutype, int count, DataTable dt, int int_bid, DateTime Close_date)
        {
            double MBL_Amount = 0, MBL_credit = 0, MBL_debit = 0, MBL_Expense = 0, BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0, Total_CBM = 0, Total_Tues = 0, JobChargeWT = 0, BL_CBM = 0, BL_Tues = 0, BL_ChargeWT = 0;
            int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
            //DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
            //  obj_da_Cost.DelCostingDetailsRpt(jobno, trantype, "V", int_bid, 0, "");
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            obj_dt = obj_da_Cost.GetBLRow(jobno, trantype, int_bid);
            if (obj_dt.Rows.Count > 0)
            {
                if (count < dt.Rows.Count - 1)
                {
                    if (dt.Rows[count]["blno"].ToString() != dt.Rows[count + 1]["blno"].ToString())
                    {
                        if (dt.Rows[count]["voutype"].ToString() == "V")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        else if (dt.Rows[count]["voutype"].ToString() == "E")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }

                        else if (dt.Rows[count]["voutype"].ToString() == "I")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        else if (dt.Rows[count]["voutype"].ToString() == "P")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                    }
                    else
                    {
                        if (dt.Rows[count]["voutype"].ToString() == "V")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                //BL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());

                                MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        else if (dt.Rows[count]["voutype"].ToString() == "E")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                //BL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());

                                MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }

                        else if (dt.Rows[count]["voutype"].ToString() == "I")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                //BL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());

                                MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        else if (dt.Rows[count]["voutype"].ToString() == "P")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                // BL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());

                                MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                    }
                }
                else
                {
                    if (dt.Rows[count]["voutype"].ToString() == "V")
                    {
                        if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                        {
                            MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                        }
                    }
                    else if (dt.Rows[count]["voutype"].ToString() == "E")
                    {
                        if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                        {
                            MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                        }
                    }

                    else if (dt.Rows[count]["voutype"].ToString() == "I")
                    {
                        if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                        {
                            MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                        }
                    }
                    else if (dt.Rows[count]["voutype"].ToString() == "P")
                    {
                        if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                        {
                            MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                        }
                    }


                }
                if (trantype == "FE" || trantype == "FI")
                {
                    JobType = Convert.ToInt32(dt.Rows[count]["jobtype"].ToString());
                    obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(dt.Rows[count]["jobno"].ToString()), trantype, int_bid);
                    if (obj_dttemp.Rows[0]["cbmtotal"].ToString().Trim().Length > 0 && obj_dttemp.Rows[0]["Tuestotal"].ToString().Trim().Length > 0)
                    {
                        Total_CBM = Convert.ToDouble(obj_dttemp.Rows[0]["cbmtotal"].ToString());
                        Total_Tues = Convert.ToDouble(obj_dttemp.Rows[0]["Tuestotal"].ToString());
                    }
                }
                else if (trantype == "AE" || trantype == "AI")
                {
                    //  JobType = Convert.ToInt32(dt.Rows[count]["jobtype"].ToString());
                    JobType = 0;
                    obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(dt.Rows[count]["jobno"].ToString()), trantype, int_bid);
                    if (obj_dttemp.Rows[0][0].ToString().Trim().Length > 0)
                    {
                        JobChargeWT = Convert.ToDouble(obj_dttemp.Rows[0][0].ToString());

                    }
                }
                for (int j = 0; j <= obj_dt.Rows.Count - 1; j++)
                {
                    BL_Amount = 0;
                    BL_Expense = 0;
                    if (trantype == "FE" || trantype == "FI")
                    {
                        BL_Tues = Convert.ToInt32(obj_dt.Rows[j]["cont20"].ToString()) + (Convert.ToInt32(obj_dt.Rows[j]["cont40"].ToString()) * 2);
                        BL_CBM = Convert.ToDouble(obj_dt.Rows[j]["cbm"].ToString());
                        if (MBL_Amount != 0)
                        {
                            if (JobType == 3)
                            {
                                BL_Amount = ((MBL_Amount / Total_Tues) * BL_Tues);
                            }
                            else
                            {
                                BL_Amount = ((MBL_Amount / Total_CBM) * BL_CBM);
                            }
                        }

                        if (MBL_Expense != 0)
                        {
                            if (JobType == 3)
                            {
                                BL_Expense = ((MBL_Expense / Total_Tues) * BL_Tues);
                            }
                            else
                            {
                                if (BL_CBM == 0)
                                {
                                    BL_Expense = 0;
                                }
                                else if (Total_CBM == 0)
                                {
                                    BL_Expense = 0;
                                }
                                else
                                {
                                    BL_Expense = ((MBL_Expense / Total_CBM) * BL_CBM);
                                }
                            }
                        }
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        BL_ChargeWT = Convert.ToDouble(obj_dt.Rows[j]["chargewt"].ToString());

                        if (MBL_Amount != 0)
                        {
                            BL_Amount = ((MBL_Amount / JobChargeWT) * BL_ChargeWT);
                        }
                        if (MBL_Expense != 0)
                        {
                            BL_Expense = ((MBL_Expense / JobChargeWT) * BL_ChargeWT);
                        }
                    }

                    if (trantype == "FE" || trantype == "FI")
                    {
                        if (obj_dt.Rows[j][2].ToString().Length > 0 && obj_dt.Rows[j][3].ToString().Length > 0)
                        {
                            int_Cont20 = Convert.ToInt32(obj_dt.Rows[j][2].ToString());
                            int_Cont40 = Convert.ToInt32(obj_dt.Rows[j][3].ToString());
                        }
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        int_Cont20 = 0;
                        int_Cont40 = 0;
                    }
                    int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
                    char Nomination = ' ';
                    string blno;
                    double volume = 0;
                    int_job = Convert.ToInt32(obj_dt.Rows[j][0].ToString());
                    blno = obj_dt.Rows[j][1].ToString();
                    int_shipper = Convert.ToInt32(obj_dt.Rows[j][6].ToString());
                    int_consignee = Convert.ToInt32(obj_dt.Rows[j][7].ToString());
                    int_notify = Convert.ToInt32(obj_dt.Rows[j][8].ToString());
                    int_agent = Convert.ToInt32(obj_dt.Rows[j][9].ToString());
                    int_pol = Convert.ToInt32(obj_dt.Rows[j][10].ToString());
                    int_pod = Convert.ToInt32(obj_dt.Rows[j][11].ToString());
                    int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
                    // Nomination = char.Parse(obj_dt.Rows[j][4].ToString());

                    if (!string.IsNullOrEmpty(obj_dt.Rows[j][4].ToString()))
                    {
                        //Nomination = Convert.ToChar(obj_dt.Rows[j][4].ToString());
                        if (obj_dt.Rows[j][4].ToString().Length > 0)
                        {
                            Nomination = char.Parse(obj_dt.Rows[j][4].ToString());
                        }
                    }
                    else
                    {
                        Nomination = ' ';
                    }

                    volume = Convert.ToDouble(obj_dt.Rows[j][5].ToString());
                    if (trantype == "FE" || trantype == "FI")
                    {
                        if (JobType == 3)
                        {
                            volume = 0;
                            int_Cont20 = Convert.ToInt32(obj_dt.Rows[j][2].ToString());
                            int_Cont40 = Convert.ToInt32(obj_dt.Rows[j][3].ToString());
                        }
                        else
                        {
                            int_Cont20 = 0;
                            int_Cont40 = 0;
                        }
                    }
                    obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, 0, 0, 0, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, Close_date, MLO, vouno, char.Parse(voutype));

                }
            }
        }
    }
}