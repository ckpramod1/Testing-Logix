using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Web.Services;

namespace logix
{
    public partial class BLPrint : System.Web.UI.Page
    {
        public DataSet dsTemp;
        public string strBLNo, strTranType;
        public CustomerDataAccess.RegCustomer regCustObj = new CustomerDataAccess.RegCustomer();
        public CustomerDataAccess.PODetails POCustObj = new CustomerDataAccess.PODetails();
        public int intBranchID;
        public ReportShow rptobj;
        public DataTable Dt, DtJob, DtConfirm, DtTentative, dtSBDtl, dtMVDtl, dtContainer, obj_dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            string str_FornName = "", str_Uiid = "";
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                str_FornName = Request.QueryString["FormName"].ToString();
                str_Uiid = Request.QueryString["UIID"].ToString();
                //Utility.Fn_CheckUserRights(str_Uiid, null, Btn_Print, null);
            }

            if (!IsPostBack)
            {
                if (Session["Blno"] != null)
                {
                    strBLNo = Session["Blno"].ToString();
                    strTranType = Session["Btrantype"].ToString();
                    txt_bl.Text = Session["Blno"].ToString();
                    if (strTranType == "FE")
                    {
                        dsTemp = regCustObj.GetFEBL4CustLogin(strBLNo);
                        SetBLDetails(dsTemp.Tables[4]);
                        divcontno.Attributes["class"] = "div_submaincontainer";

                    }
                    else
                    {
                        dsTemp = regCustObj.GetFIBL4CustLogin(strBLNo);
                        SetBLDetailsFI(dsTemp.Tables[0]);
                        divcontno.Attributes["class"] = "div_submaincontainerFI";
                    }

                    Fn_Getvalue();
                }

                if (strTranType == "FE")
                {

                    txtLineDesuff.Visible = false;
                }
                else
                {

                    txtLineDesuff.Visible = true;
                }

            }

            //if (strTranType == "FE")
            //{
            //    rptobj = new ReportShow("FEBL4PL.rpt", "BLPrint.blno~txt_bl~Text~=", "location=" + txt_issued.Text, "", Btn_Print, this.Page, intBranchID.ToString());
            //}


            string strTemp = intBranchID.ToString();
        }

        public DataTable GetEmptySBDtl()
        {
            DataTable dtTempSBDtl = new DataTable();
            DataColumn dcSBNo = new DataColumn("sbno");
            DataColumn dcSBDate = new DataColumn("sbdate");
            dtTempSBDtl.Columns.Add(dcSBNo);
            dtTempSBDtl.Columns.Add(dcSBDate);
            DataRow dtRow = dtTempSBDtl.NewRow();
            dtRow[dcSBNo] = "NA";
            dtRow[dcSBDate] = "NA";
            dtTempSBDtl.Rows.Add(dtRow);
            return dtTempSBDtl;
        }

        public void SetBLDetails(DataTable DtTemp)
        {
            if (DtTemp.Rows.Count != 0)
            {
                txt_bl.Text = strBLNo;
                txt_date.Text = DtTemp.Rows[0]["issuedon"].ToString();
                txt_issued.Text = DtTemp.Rows[0]["issuedat"].ToString();
                txt_shipper.Text = DtTemp.Rows[0]["sname"].ToString();
                txt_consignee.Text = DtTemp.Rows[0]["conname"].ToString();
                txt_notify.Text = DtTemp.Rows[0]["npame"].ToString();
                txt_agent.Text = DtTemp.Rows[0]["aname"].ToString();
                txt_POR.Text = DtTemp.Rows[0]["por"].ToString();
                txt_POL.Text = DtTemp.Rows[0]["pol"].ToString();
                txt_POD.Text = DtTemp.Rows[0]["pod"].ToString();
                txt_FD.Text = DtTemp.Rows[0]["fd"].ToString();

                if (DtTemp.Rows[0]["jobtype"].ToString() == "3")
                    txt_volume.Text = DtTemp.Rows[0]["container"].ToString();
                else
                    txt_volume.Text = DtTemp.Rows[0]["cbm"].ToString();
                txt_kgs.Text = DtTemp.Rows[0]["grweight"].ToString();
                txt_packages.Text = DtTemp.Rows[0]["package"].ToString();
                txt_freight.Text = DtTemp.Rows[0]["freight"].ToString();
                txt_mark.Text = DtTemp.Rows[0]["marks"].ToString();
                txt_cargo.Text = DtTemp.Rows[0]["descn"].ToString();

                txt_vessel.Text = DtTemp.Rows[0]["fvessel"].ToString();
                txt_fpol.Text = DtTemp.Rows[0]["fpol"].ToString();
                txt_fpod.Text = DtTemp.Rows[0]["fpod"].ToString();
                txt_feta.Text = DtTemp.Rows[0]["fveta"].ToString();
                txt_fetd.Text = DtTemp.Rows[0]["fvetd"].ToString();
                intBranchID = int.Parse(DtTemp.Rows[0]["branch"].ToString());
                txtShipperaddr.Text = DtTemp.Rows[0]["saddress"].ToString();
                txtConsgaddr.Text = DtTemp.Rows[0]["caddress"].ToString();
                txtNotifyaddr.Text = DtTemp.Rows[0]["naddress"].ToString();

                txt_agent.Text = POCustObj.GetCustomername(Convert.ToInt32(DtTemp.Rows[0]["deliveryagent"].ToString()));
                string location = POCustObj.GetCustlocation(Convert.ToInt32(DtTemp.Rows[0]["deliveryagent"].ToString()));
                txtAgentaddr.Text = POCustObj.GetCustomerAddress(txt_agent.Text, "Agent / Principal", location);
            }
        }

        public void SetBLDetailsFI(DataTable DtTemp)
        {
            if (DtTemp.Rows.Count != 0)
            {
                txt_bl.Text = strBLNo;
                txt_date.Text = DtTemp.Rows[0]["bldate"].ToString();
                txt_issued.Text = DtTemp.Rows[0]["blissuedat"].ToString();
                txt_shipper.Text = DtTemp.Rows[0]["shipper"].ToString();
                txt_consignee.Text = DtTemp.Rows[0]["consignee"].ToString();
                txt_notify.Text = DtTemp.Rows[0]["notifyparty"].ToString();
                txt_agent.Text = DtTemp.Rows[0]["agent"].ToString();
                txt_POR.Text = DtTemp.Rows[0]["por"].ToString();
                txt_POL.Text = DtTemp.Rows[0]["pol"].ToString();
                txt_POD.Text = DtTemp.Rows[0]["pod"].ToString();
                txt_FD.Text = DtTemp.Rows[0]["fd"].ToString();

                if (DtTemp.Rows[0]["jobtype"].ToString() == "3")
                    txt_volume.Text = DtTemp.Rows[0]["container"].ToString();
                else
                    txt_volume.Text = DtTemp.Rows[0]["cbm"].ToString();
                txt_kgs.Text = DtTemp.Rows[0]["weight"].ToString();
                txt_packages.Text = DtTemp.Rows[0]["package"].ToString();
                txt_freight.Text = DtTemp.Rows[0]["freight"].ToString();
                txt_mark.Text = DtTemp.Rows[0]["marks"].ToString();
                txt_cargo.Text = DtTemp.Rows[0]["cargo"].ToString();

                txt_vessel.Text = DtTemp.Rows[0]["fvessel"].ToString();
                txt_fpol.Text = DtTemp.Rows[0]["fvpol"].ToString();
                txt_fpod.Text = DtTemp.Rows[0]["fvpod"].ToString();
                txt_feta.Text = DtTemp.Rows[0]["fvETA"].ToString();
                txt_fetd.Text = DtTemp.Rows[0]["fvETB"].ToString();

                txt_mvessel.Text = DtTemp.Rows[0]["mvessel"].ToString() + " V. " + DtTemp.Rows[0]["mvoyage"].ToString();
                txtShipperaddr.Text = DtTemp.Rows[0]["saddress"].ToString();
                txtConsgaddr.Text = DtTemp.Rows[0]["caddress"].ToString();
                txtNotifyaddr.Text = DtTemp.Rows[0]["naddress"].ToString();

                txt_agent.Text = POCustObj.GetCustomername(Convert.ToInt32(DtTemp.Rows[0]["agentid"].ToString()));
                string location = POCustObj.GetCustlocation(Convert.ToInt32(DtTemp.Rows[0]["agentid"].ToString()));
                txtAgentaddr.Text = POCustObj.GetCustomerAddress(txt_agent.Text, "Agent / Principal", location);


            }
        }


        private void Fn_Getvalue()
        {
            string str_Nomination = "";
            chk_container.Items.Clear();
            string str_BL = "";
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            CustomerDataAccess.PODetails objbl = new CustomerDataAccess.PODetails();

            //obj_dt = objbl.ShowFEBLDetails(txt_bl.Text);
            //if (obj_dt.Rows.Count > 0)
            //{
            //    str_BL = obj_dt.Rows[0]["splitbl"].ToString();
            //    hid_split.Value = str_BL;
            //}
            //if (str_BL.Trim().Length > 0)
            //{


            //txt_cfs.Text = obj_dt.Rows[0]["splitbl"].ToString();
            Fn_GetDetailsSplit();
            hid_BL.Value = "false";


            string str_booking = "";
            int int_customeridDO = 0;
            str_booking = POCustObj.GetBookinkNoCSWEB(txt_bl.Text);
            hid_BookingNo.Value = str_booking;
            txt_book.Text = str_booking;

            //Fn_GetDetails();
            obj_dttemp = POCustObj.GetBlMVesslvallWeb(hid_BookingNo.Value.ToString());
            if (obj_dttemp.Rows.Count > 0)
            {
                txt_mvessel.Text = obj_dttemp.Rows[0]["vessel"].ToString();
                //txt_destuff.Text = obj_dttemp.Rows[0]["mvoyage"].ToString();
                txt_mpol.Text = obj_dttemp.Rows[0]["pol"].ToString();
                txt_mpod.Text = obj_dttemp.Rows[0]["pod"].ToString();
                txt_meta.Text = obj_dttemp.Rows[0]["eta"].ToString();
                txt_metd.Text = obj_dttemp.Rows[0]["etd"].ToString();
            }

            if (str_booking != "0")
            {
                if (Session["Btrantype"].ToString() == "FI")
                {
                    if (str_Nomination == "N")
                    {
                        obj_dt = POCustObj.GetBookingDtls4CsNewelaa(str_booking, Session["Btrantype"].ToString());
                        if (obj_dt.Rows.Count > 0)
                        {
                            txt_book.Text = str_booking + " & " + obj_dt.Rows[0]["bookingdate"].ToString();
                            txt_Quotation.Text = obj_dt.Rows[0]["quotno"].ToString() + " & " + obj_dt.Rows[0]["quotdate"].ToString();
                            //txt_marketed.Text = obj_dt.Rows[0]["marketedbyName"].ToString();
                        }
                        else
                        {
                            txt_book.Text = "";
                            txt_Quotation.Text = "";
                            //txt_marketed.Text = "";
                        }

                    }
                }
                else
                {
                    obj_dt = POCustObj.GetBookingDtls4CsNewelaa(str_booking, Session["Btrantype"].ToString());
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_book.Text = str_booking + " & " + obj_dt.Rows[0]["bookingdate"].ToString();
                        txt_Quotation.Text = obj_dt.Rows[0]["quotno"].ToString() + " & " + obj_dt.Rows[0]["quotdate"].ToString();
                    }
                    else
                    {
                        txt_book.Text = "";
                        txt_Quotation.Text = "";
                    }
                }

            }
            else
            {
                txt_book.Text = "";
                txt_Quotation.Text = "";
            }
        }

        private void Fn_GetDetailsSplit()
        {
            //int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            //int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
            string str_Nomination = "", str_CustomerName = "";
            chk_container.Items.Clear();
            DataTable obj_dt = new DataTable();
            //DataAccess.ForwardingExports.BLPrinting obj_da_BL = new DataAccess.ForwardingExports.BLPrinting();
            //DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
            //DataAccess.ForwardingImports.BLDetails obj_da_FIBL = new DataAccess.ForwardingImports.BLDetails();
            //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();

            if (Session["Btrantype"].ToString() == "FE" || Session["Btrantype"].ToString() == "FI")
            {
                obj_dt = POCustObj.GetBLPrintingDtNewCS(txt_bl.Text, Session["Btrantype"].ToString());
            }
            if (obj_dt.Rows.Count > 0)
            {
                txt_date.Text = obj_dt.Rows[0]["bldate"].ToString();
                txt_issued.Text = obj_dt.Rows[0]["issuedat"].ToString();
                txt_shipper.Text = obj_dt.Rows[0]["shipper"].ToString();
                txt_consignee.Text = obj_dt.Rows[0]["consignee"].ToString();
                txt_notify.Text = obj_dt.Rows[0]["notify"].ToString();
                txt_remark.Text = obj_dt.Rows[0]["remarks"].ToString();

                if (!string.IsNullOrEmpty(obj_dt.Rows[0].ItemArray[5].ToString()))
                {
                    //str_CustomerName = obj_da_Customer.GetCustomername(int.Parse(obj_dt.Rows[0].ItemArray[5].ToString()));
                    hid_cha.Value = obj_dt.Rows[0].ItemArray[5].ToString();
                }
                if (Session["Btrantype"].ToString() != "FE")
                {
                    txt_mvessel.Text = obj_dt.Rows[0]["mvessel"].ToString();
                    //txt_destuff.Text = obj_dt.Rows[0]["mvoy"].ToString() + " & " + str_CustomerName;
                    if (obj_dt.Rows[0]["blsurrendered"].ToString() == "Y")
                    {
                        txt_hbl.Text = "SURRENDERED";
                    }
                    else
                    {
                        txt_hbl.Text = "NOT SURRENDERED";
                    }
                    txt_job.Text = obj_dt.Rows[0]["jobno"].ToString() + "/" + obj_dt.Rows[0]["type"].ToString();
                    //txt_line.Text = obj_dt.Rows[0]["linenumber"].ToString();

                }
                else
                {
                    if (obj_dt.Rows[0]["surrendered"].ToString() == "S")
                    {
                        txt_hbl.Text = "SURRENDERED";
                    }
                    else if (obj_dt.Rows[0]["surrendered"].ToString() == "B")
                    {
                        txt_hbl.Text = "SEAWAY BILL";
                    }
                    else
                    {
                        txt_hbl.Text = "RELEASE";
                    }

                    if (obj_dt.Rows[0]["mblstatus"].ToString() == "S")
                    {
                        txt_mblstatus.Text = "SURRENDERED";
                    }
                    else if (obj_dt.Rows[0]["surrendered"].ToString() == "B")
                    {
                        txt_mblstatus.Text = "SEAWAY BILL";
                    }
                    else
                    {
                        txt_mblstatus.Text = "RELEASE";
                    }

                    txt_freight.Text = obj_dt.Rows[0]["surrendered"].ToString();
                    txt_job.Text = obj_dt.Rows[0]["jobno"].ToString() + "/" + obj_dt.Rows[0]["type"].ToString();
                }

                DataTable obj_dttemp = new DataTable();
                if (Session["Btrantype"].ToString() == "FE")
                {
                    //txt_cha.Text = str_CustomerName;                 
                    obj_dttemp = POCustObj.GetContainerDetails4Web(int.Parse(obj_dt.Rows[0]["jobno"].ToString()), txt_bl.Text);
                    for (int i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                    {
                        chk_container.Items.Add(obj_dttemp.Rows[i][0].ToString() + "/" + obj_dttemp.Rows[i][1].ToString() + "/" + obj_dttemp.Rows[i][2].ToString());
                        if (i == 0)
                        {
                            hid_contno.Value = obj_dttemp.Rows[i][0].ToString();
                        }
                        else
                        {
                            hid_contno.Value = hid_contno.Value.ToString() + "/" + obj_dttemp.Rows[i][0].ToString();
                        }
                    }
                }
                else
                {

                    obj_dttemp = POCustObj.GetContainerDetail4FI(int.Parse(obj_dt.Rows[0]["intjobno"].ToString()), txt_bl.Text);
                    for (int i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                    {
                        chk_container.Items.Add(obj_dttemp.Rows[i][0].ToString() + "/" + obj_dttemp.Rows[i][1].ToString() + "/" + obj_dttemp.Rows[i][2].ToString());
                        if (i == 0)
                        {
                            hid_contno.Value = obj_dttemp.Rows[i][0].ToString();
                        }
                        else
                        {
                            hid_contno.Value = hid_contno.Value.ToString() + "/" + obj_dttemp.Rows[i][0].ToString();
                        }
                    }
                }

                txt_agent.Text = obj_dt.Rows[0]["agent"].ToString();
                txt_mlo.Text = obj_dt.Rows[0]["mlo"].ToString();
                txt_POR.Text = obj_dt.Rows[0]["por"].ToString();
                txt_POL.Text = obj_dt.Rows[0]["pol"].ToString();
                txt_POD.Text = obj_dt.Rows[0]["pod"].ToString();
                txt_FD.Text = obj_dt.Rows[0]["fd"].ToString();
                txt_mark.Text = obj_dt.Rows[0]["marks"].ToString();
                txt_cargo.Text = obj_dt.Rows[0]["descn"].ToString();
                txt_kgs.Text = obj_dt.Rows[0]["ntweight"].ToString();
                txt_volume.Text = obj_dt.Rows[0]["cbm"].ToString();
                txt_packages.Text = obj_dt.Rows[0]["noofpkgs"].ToString() + " " + obj_dt.Rows[0]["package"].ToString();
                //txt_vessel.Text = obj_dt.Rows[0]["fvessel"].ToString() + "V." + obj_dt.Rows[0]["fvoy"].ToString();

                if (strTranType == "FI")
                {
                    txtLineDesuff.Text = obj_dt.Rows[0]["imno"].ToString() + "/" + obj_dt.Rows[0]["destuff"].ToString() + "/" + obj_dt.Rows[0]["linenumber"].ToString();
                }
                ////txt_voyage.Text = obj_dt.Rows[0]["fvoy"].ToString();
                txt_fpol.Text = obj_dt.Rows[0]["fpol"].ToString();
                txt_fpod.Text = obj_dt.Rows[0]["fpod"].ToString();
                txt_feta.Text = obj_dt.Rows[0]["feta"].ToString();
                txt_fetd.Text = obj_dt.Rows[0]["fetd"].ToString();
                txt_freight.Text = obj_dt.Rows[0]["freight"].ToString();
                if (Session["Btrantype"].ToString() == "FE")
                {
                    txt_mbl.Text = obj_dt.Rows[0]["mblno"].ToString();
                }
                else
                {
                    txt_mbl.Text = obj_dt.Rows[0]["mblno"].ToString() + " & " + obj_dt.Rows[0]["mbldateweb"].ToString();
                }
                txt_jobtype.Text = obj_dt.Rows[0]["jobno"].ToString() + "/" + obj_dt.Rows[0]["type"].ToString();
                //txt_dodate.Text = obj_dt.Rows[0]["doissuedon"].ToString();
                txt_remark.Text = obj_dt.Rows[0]["remarks"].ToString();
                str_Nomination = obj_dt.Rows[0]["nomination"].ToString();
                //DataAccess.ForwardingExports.Confirmation obj_da_confirm = new DataAccess.ForwardingExports.Confirmation();
                obj_dttemp = POCustObj.GetConfirmDetailsWebNew(txt_bl.Text, "C");
                if (obj_dttemp.Rows.Count > 0)
                {
                    txt_mvessel.Text = obj_dttemp.Rows[0][1].ToString();
                    //txt_destuff.Text = obj_dttemp.Rows[0][4].ToString();
                }
                else
                {
                    obj_dttemp = POCustObj.GetConfirmDetailsWebNew(txt_bl.Text, "T");
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        txt_mvessel.Text = obj_dttemp.Rows[0][1].ToString();
                        //txt_destuff.Text = obj_dttemp.Rows[0][4].ToString();
                    }
                }

                //if (lbl_header.Text == "DODetails" && Session["Btrantype"].ToString() == "FI")
                //{
                //    int int_DoDay = 0;
                //    int_DoDay = obj_da_FIBL.GetPendingDODays(txt_bl.Text, int_bid, int_divisionid);
                //    if (int_DoDay > 0)
                //    {
                //        btn_DOsale.Visible = true;
                //        btn_DO.Visible = true;
                //        div_cha.Attributes["class"] = "div_cha";
                //        doday.Visible = false;
                //        dodaytxt.Visible = false;
                //    }
                //    else
                //    {
                //        btn_DOsale.Visible = false;
                //        btn_DO.Visible = false;
                //        div_cha.Attributes["class"] = "div_cha_visible";
                //        doday.Visible = false;
                //        dodaytxt.Visible = false;
                //    }

                //}
            }
            else
            {
                Fn_Clear();
            }

        }


        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            Fn_Clear();
        }

        private void Fn_Clear()
        {
            if (lbl_header.Text == "Booking #")
            {
                txt_bl.Text = "";
            }
            txt_agent.Text = "";
            txt_book.Text = "";
            txt_cargo.Text = "";


            txt_consignee.Text = "";
            txt_date.Text = "";
            //txt_destuff.Text = "";
            //txt_dodate.Text = "";

            txt_FD.Text = "";
            txt_feta.Text = "";
            txt_fetd.Text = "";
            txt_fpod.Text = "";
            txt_fpol.Text = "";
            txt_freight.Text = "";
            txt_hbl.Text = "";
            txt_issued.Text = "";
            txt_job.Text = "";
            txt_jobtype.Text = "";
            txt_kgs.Text = "";
            txt_line.Text = "";
            txt_mark.Text = "";
            //txt_marketed.Text = "";
            txt_mbl.Text = "";
            txt_mblstatus.Text = "";
            txt_meta.Text = "";
            txt_metd.Text = "";
            txt_mlo.Text = "";
            txt_mpod.Text = "";
            txt_mpol.Text = "";
            txt_mvessel.Text = "";
            txt_notify.Text = "";
            txt_packages.Text = "";
            txt_POD.Text = "";
            txt_POL.Text = "";
            txt_POR.Text = "";
            txt_Quotation.Text = "";
            txt_remark.Text = "";
            txt_shipper.Text = "";
            txt_vessel.Text = "";
            txt_volume.Text = "";
            //txt_voyage.Text = "";


            //Grd_Invoice.DataSource = new DataTable();
            //Grd_Invoice.DataBind();

            //Grd_DN.DataSource = new DataTable();
            //Grd_DN.DataBind();

            //Grd_receipt.DataSource = new DataTable();
            //Grd_receipt.DataBind();

            //Grd_freightdetail.DataSource = new DataTable();
            //Grd_freightdetail.DataBind();


        }

        protected void Btn_Print_Click(object sender, EventArgs e)
        {

        }


        protected void Btn_cancel_Click1(object sender, EventArgs e)
        {

        }
    }
}