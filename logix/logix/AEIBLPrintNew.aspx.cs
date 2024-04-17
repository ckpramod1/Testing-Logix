using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix
{
    public partial class AEIBLPrintNew : System.Web.UI.Page
    {
        CustomerDataAccess.RegCustomer regCustObj = new CustomerDataAccess.RegCustomer();
        CustomerDataAccess.PODetails POCustObj = new CustomerDataAccess.PODetails();
        DataSet dsTemp;
        DataTable Dt, DtDim, obj_dt;
        public string strBLNo, strTranType, strPmtr;
        DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                if (Session["Blno"] != null)
                {
                    strBLNo = Session["Blno"].ToString();
                    strTranType = Session["Btrantype"].ToString();
                    txt_bl.Text = Session["Blno"].ToString();
                    txt_flight.Text = Session["flight"].ToString();
                    AIEBLInfo();
                    Btn_Print.Visible = false;
                    Btn_cancel.Visible = false;
                }
            }
        }

        public void AIEBLInfo()
        {
            string str_booking = "";
            string str_Nomination = "";
            dsTemp = regCustObj.GetAIEBL4CustLogin(Session["Blno"].ToString(), Session["Btrantype"].ToString());
            Dt = dsTemp.Tables[0];
            if (Dt.Rows.Count > 0)
            {
                txt_date.Text = Dt.Rows[0]["issuedon"].ToString();
                txt_issued.Text = Dt.Rows[0]["issuedat"].ToString();
                txt_shipper.Text = Dt.Rows[0]["shipper"].ToString();
                txt_consignee.Text = Dt.Rows[0]["consignee"].ToString();
                txt_notify.Text = Dt.Rows[0]["notifyparty1"].ToString();
                txt_agent.Text = Dt.Rows[0]["notifyparty2"].ToString();
                txt_POD.Text = Dt.Rows[0]["fromport"].ToString();
                txt_POL.Text = Dt.Rows[0]["toport"].ToString();
                txt_mbl.Text = Dt.Rows[0]["hawblno"].ToString();
                txt_jobtype.Text = Dt.Rows[0]["jobno"].ToString();
                txtShipperaddr.Text = Dt.Rows[0]["saddress"].ToString();
                txtConsgaddr.Text = Dt.Rows[0]["caddress"].ToString();
                txtNotifyaddr.Text = Dt.Rows[0]["n1address"].ToString();
                txtAgentaddr.Text = Dt.Rows[0]["n2address"].ToString();

                txt_mlo.Text = Dt.Rows[0]["carrier1"].ToString();
                //txt_fpol.Text = Dt.Rows[0]["pod2"].ToString();
                //txtCarrier2.Text = Dt.Rows[0]["carrier2"].ToString();
                //txtPOD3.Text = Dt.Rows[0]["pod3"].ToString();
                //txtCarrier3.Text = Dt.Rows[0]["carrier3"].ToString();
                //txtHndlInfo.Text = Dt.Rows[0]["handling"].ToString();
                txt_packages.Text = Dt.Rows[0]["package"].ToString();
                txt_kgs.Text = Dt.Rows[0]["grosswt"].ToString();
                txt_volume.Text = Dt.Rows[0]["chargewt"].ToString();
                txt_freight.Text = Dt.Rows[0]["freight"].ToString();
                str_booking = POCustObj.GetBookinkNoCSWEB(txt_bl.Text);
                txt_book.Text = str_booking;
                str_Nomination = Dt.Rows[0]["nomination"].ToString();
                txt_cargo.Text = Dt.Rows[0]["descn"].ToString();
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
        }

        protected void Btn_Print_Click(object sender, EventArgs e)
        {
            /*string str_Script = "";
            str_Script = "window.open('../Reportasp/deliveryorderAI.aspx?BLNO=" + txt_bl.Text + "&" + this.Page.ClientQueryString + "','','');";

            da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["webgroupid"].ToString()), 1417, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_bl.Text + "&View");
            ScriptManager.RegisterStartupScript(Btn_Print, typeof(Button), "BL  print", str_Script, true);
            */

           // AIEBLObj.InsDelOrd(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()), txtblno.Text, Convert.ToInt32(txtjobno.Text));
            /*string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";
            str_RptName = "rptDeliveryorder.rpt";
            Session["str_sfs"] = "{AIBLDetails.hawblno}='" + txtblno.Text + "' and {AIBLDetails.bid}=" + Session["LoginBranchid"].ToString();
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";*/
           
            //Session["str_sp"] = str_sp; 
        }

    }
}