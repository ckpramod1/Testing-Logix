using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Data;


namespace logix.FI
{
    public partial class FIEventsnew : System.Web.UI.Page
    {
        DataTable Dt_new = new DataTable();
        Double cbm, amt;
        DataTable dtcont = new DataTable();
        string strblno, strdnno;
        int intjobno, intAgentID, cfsid;
        DataAccess.Masters.MasterCustomer objCust = new DataAccess.Masters.MasterCustomer();
        DataTable dt = new DataTable();
        DataTable Dt = new DataTable();
        int i;
        // DataAccess.LogDetails da_obj_objLog = new DataAccess.LogDetails();
        DataTable dtcaargo = new DataTable();
        DataAccess.ForwardingImports.CargoPickup objcargopick = new DataAccess.ForwardingImports.CargoPickup();
        DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
        string type;
        DataAccess.ForwardingImports.JobInfo da_obj_FIJobobj = new DataAccess.ForwardingImports.JobInfo();

        int int_divisionid;
        string str_closedjob;
        int int_branchid;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DateTime date;

        string txtdate; 
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Cancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            if (!IsPostBack)
            {
                txtEta.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                txtdestuff.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");


                txt_dtdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
                txtCargopickedon.Text = txtdestuff.Text;
                btn_Cancel.Text = "Cancel";
                btn_Cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";

              
                


               

                if (Session["StrTranType"].ToString() == "FI")
                {
                    HeaderLabel1.InnerText = "Ocean Imports";

                  /*  ddlEvents.Items.Add("");
                    ddlEvents.Items.Add("Nomination Received On");
                    ddlEvents.Items.Add("Pick-up On");
                    ddlEvents.Items.Add("AWB Confirmation On");
                    ddlEvents.Items.Add("Prealart Sent On");
                    //  ddlEvents.Items.Add("Flight Schedule");
                    // ddlEvents.Items.Add("DO Issued on");
                    ddlEvents.Items.Add("Invoice sent On");
                    ddlEvents.Items.Add("Clearance Status On");
                    //  ddlEvents.Items.Add("Job closed On");

                    */


                    ddlEvents.Items.Add("");
                    ddlEvents.Items.Add("Booked On");
                    ddlEvents.Items.Add("Origin On");                    
                    ddlEvents.Items.Add("Draft Confirmed On");
                    ddlEvents.Items.Add("Vessel Departured On");
                    ddlEvents.Items.Add("Prealert Sent On");   
                    ddlEvents.Items.Add("Transhippment arrived On");                       
                    ddlEvents.Items.Add("Transhipment Departured On");
                    ddlEvents.Items.Add("Vessel Arrived At POD On");                   
                    ddlEvents.Items.Add("Destination CFS Arrived On");
                    ddlEvents.Items.Add("Cargo Destuffed On");
                    ddlEvents.Items.Add("Order Delivered On");
                    ddlEvents.Items.Add("Cargo Delivered On");
                    ddlEvents.Items.Add("Empty Container Returned On");
                   
                  
                    
                }
                //else if (Session["StrTranType"].ToString() == "AI")
                //{
                //    HeaderLabel1.InnerText = "Air Imports";

                //   /* ddlEvents.Items.Add("");
                //    ddlEvents.Items.Add("Nomination Received On");
                //    ddlEvents.Items.Add("Pick-up On");
                //    ddlEvents.Items.Add("AWB Confirmation On");
                //    ddlEvents.Items.Add("Prealart Sent On");
                //    //  ddlEvents.Items.Add("Flight Schedule");
                //    // ddlEvents.Items.Add("DO Issued on");
                //    ddlEvents.Items.Add("Invoice sent On");
                //    ddlEvents.Items.Add("Clearance Status On");
                //    //  ddlEvents.Items.Add("Job closed On");
                //    */



                //    ddlEvents.Items.Add("");
                //    ddlEvents.Items.Add("Nomination Received On");
                //    ddlEvents.Items.Add("Pick-up On");
                //    ddlEvents.Items.Add("Warehouse Arrival On");
                //    ddlEvents.Items.Add("Booking Confirmation On");
                //    ddlEvents.Items.Add("AWB Confirmation On");
                //    ddlEvents.Items.Add("Flight Schedule On");
                //    ddlEvents.Items.Add("Prealart Sent On");
                //    ddlEvents.Items.Add("Arrivals On");
                //    ddlEvents.Items.Add("DO Issued on");
                //    ddlEvents.Items.Add("Clearance Status on");
                //    ddlEvents.Items.Add("Delivery Update On");
                //    ddlEvents.Items.Add("Invoice sent On");
                  
                //}

                GridView1.Visible = false;
                /*txtCargopickedon.Visible = false;
                txtCfs.Visible = false;
                txtContainer.Visible = false;
                txtsize.Visible = false;
                txtSeal.Visible = false;
                txtdestuff.Visible = false;
                btnAdd.Visible = false;
                txtjob.Visible = false;
                txtEta.Visible = false;*/
                grd.DataSource = Utility.Fn_GetEmptyDataTable();
                grd.DataBind();
                /*txtCargopickedon.Visible = false;*/
            }
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            txtjob.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
        }

        [WebMethod]

        public static List<string> GetCfs(string prefix)
        {
            List<string> list_result = new List<string>();

            DataAccess.Masters.MasterCustomer objCust = new DataAccess.Masters.MasterCustomer();
            DataTable dt = new DataTable();

            dt = objCust.GetLikeCustomerWDL(prefix);

            list_result = Utility.Fn_DatatableToList(dt, "customer", "customerid");

            return list_result;
        }

        //public void LoadGrd()
        //{

        //    DataAccess.ForwardingImports.JobInfo da_obj_FIJobobj = new DataAccess.ForwardingImports.JobInfo();

        //        "PA2Accs Send On":
        //            Dt_new = da_obj_FIJobobj.GetPA2AccDts("PA2", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
        //            break;
        //        case "Cheque Received On":
        //            Dt_new = da_obj_FIJobobj.GetPA2AccDts("CHQ", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
        //            break;
        //        case "Line DO Received On":
        //            Dt_new = da_obj_FIJobobj.GetPA2AccDts("LDO", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
        //            break;
        //        case "Devanning Received On":
        //            Dt_new = da_obj_FIJobobj.GetPA2AccDts("DVR", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
        //            break;
        //        case "Refund Received On":
        //            Dt_new = da_obj_FIJobobj.GetPA2AccDts("RRO", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
        //            break;
        //    }
        //    grd.DataSource = Dt_new;
        //    ViewState["Dtnewvalue"] = Dt_new;
        //    grd.DataBind();

        //}


        protected void btn_update_Click(object sender, EventArgs e)
        {
            bool blerr;
            try
            {
                btn_Cancel.Text = "Cancel";
                btn_Cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                hf_jobno.Value = "0";
                hf_docno.Value = "0";
                DataAccess.ForwardingImports.JobInfo da_obj_FIJobobj = new DataAccess.ForwardingImports.JobInfo();
                DataTable dtmail = new DataTable();
                txtdate = txt_dtdate.Text;
                blerr = false;
                DataTable dt1 = new DataTable();
                string cont = "";
                string origin = "";

                string customerid = "";
                string shipperidemailid = "";
                string cosigneeidemailid = "";
                string notifypartyidemailid = "";
                string customermailid = "";
                    if (grd.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in grd.Rows)
                        {
                            CheckBox Chk1 = (CheckBox)row.FindControl("Chk_Select");

                            if (Chk1.Checked == true)
                            {
                                hf_jobno.Value = row.Cells[0].Text;

                                Label lblblno = (Label)row.FindControl("BLno");

                                hf_blno.Value = lblblno.Text;
                                


                                if (Session["StrTranType"].ToString() == "FI")
                                {
                                    if (ddlEvents.Text == "Booked On")
                                    {
                                        hid_date.Value = row.Cells[8].Text;
                                        da_obj_FIJobobj.UpdateFIEventsbookings(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(hid_date.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_blno.Value);

                                        if (hf_blno.Value != "")
                                        {
                                           dt1 = da_obj_FIJobobj.spgetevents(Convert.ToInt32(Session["LoginBranchid"].ToString()), hf_blno.Value, Session["StrTranType"].ToString());
                                           

                                            if (dt1.Rows.Count>0)
                                            {
                                                cont = "";
                                                if (hid_date.Value != "")
                                                {
                                                    origin = Convert.ToDateTime((hid_date.Value)).ToString("dd-MMM-yyyy");
                                                }
                                                else
                                                {
                                                    origin = "";
                                                }
                                                cont = "<html>";
                                                cont = cont + "<body style='padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<div style='width:1010px; margin:0px auto; padding:10px; border:1px solid #000;'>";
                                                cont = cont + "<div style='width:1010px;'>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Booking Alert Mail to Consignee</label></div>";

                                                cont = cont + "<div style=' width:494px; color:#fff; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label style='color:#fff;'>LCL Import Booking Status</label></div>";



                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Message From " + Session["LoginDivisionName"].ToString() + "</label></div>";
                                                cont = cont + "<div style=' width:494px; color:#000; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";
                                                cont = cont + "<label>Date: " + Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)).ToString("dd-MMM-yyyy") + "</label></div>";  // txt_date.Text

                                                //if (dt1.Columns.Contains("bookingdate"))
                                                //{
                                                //    cont = cont + "<label>Date: " + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";  // txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<label>Date: " + "" + "</label></div>";  // txt_date.Text
                                                //}
                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Dear Sir/Madam,Please find attached Booking  # : " + dt1.Rows[0]["bookingno"].ToString() +"  has been Booked by the  " + "customer" + ". Please find below details</label></div>";//txt_booking.Text

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'> BOOKING REFERENCE</label></div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Number : </div>";
                                                if (dt1.Columns.Contains("bookingno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["bookingno"].ToString() + "</label></div>";// txt_booking.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_booking.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Date : </div>";

                                                if (dt1.Columns.Contains("bookingdate"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";// txt_date.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Origin  : </div>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["POL"].ToString() + "</label></div>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_por.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Destination  : </div>";
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["POD"].ToString() + "</label></div>";//txt_fd.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";//txt_fd.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Number  : </div>";
                                                if (dt1.Columns.Contains("blno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["blno"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Date  : </div>";
                                                if (dt1.Columns.Contains("hbldate"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["hbldate"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Released  : </div>";
                                                if (dt1.Columns.Contains("doissueon"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["doissueon"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:990px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold;'>Customer Reference Number : </div>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Shipper</div>";
                                                cont = cont + "<div style='float:left; width:300px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'> ";
                                                if (dt1.Columns.Contains("shipper"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + dt1.Rows[0]["shipper"].ToString() + "</p>";//txt_shipper.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + "" + "</p>";//txt_shipper.Text
                                                }

                                                if (dt1.Columns.Contains("saddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["saddress"].ToString() + "</p>";// txtsaddress.Text
                                                }

                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "</p>";// txtsaddress.Text
                                                }
                                                cont = cont + "</div></div>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Consignee</div>";
                                                if (dt1.Columns.Contains("consignee"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["consignee"].ToString() + "</p>";// txt_consignee.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_consignee.Text
                                                }
                                                if (dt1.Columns.Contains("caddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["caddress"].ToString() + "<br />";// txtcaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "<br />";// txtcaddress.Text
                                                }
                                                cont = cont + "</p> </div>";
                                                cont = cont + "<div style='float:left; width:368px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:0px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:368px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'> Notify Party</div>";
                                                if (dt1.Columns.Contains("notifyparty"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["notifyparty"].ToString() + "</p>";// txt_notify.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_notify.Text
                                                }
                                                if (dt1.Columns.Contains("naddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["naddress"].ToString() + "</p>";// txtnaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txtnaddress.Text
                                                }
                                                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'></p></div></div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>  SHIPMENT DETAIL</label></div>";
                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Terms of Shipment:</div>";
                                                if (dt1.Columns.Contains("stype"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["stype"].ToString() + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Freight Terms : </div>";
                                                if (dt1.Columns.Contains("fstatus"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["fstatus"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Expiry Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:1010px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Carrier: </div>";
                                                if (dt1.Columns.Contains("CarrierName"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["CarrierName"].ToString() + "</label></div>"; // txt_customer.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>"; // txt_customer.Text
                                                }
                                                cont = cont + "</div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>CONNECTION DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<table width='1010' border='0' cellspacing='0' cellpadding='0' style='font-family:sans-serif, Geneva, sans-serif; color:#000; border-left:1px solid #000; border-right:1px solid #000; border-top:1px solid #000; border-bottom:0px solid #000; padding:0px 0px 0px 0px; margin:10px 0px 0px 0px; float:left;'>";
                                                cont = cont + " <tr><th style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Loading</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETD</th>";
                                                cont = cont + " <th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Discharge</th><th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETA</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Vessel</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'> Voyage No.</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Status</th>";
                                                cont = cont + "<th style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>Mode</th>";
                                                cont = cont + "</tr>";
                                                cont = cont + "<tr>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POL"].ToString() + "</td>";// txt_pol.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_pol.Text
                                                }
                                                if (dt1.Columns.Contains("etd"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["etd"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POD"].ToString() + "</td>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_por.Text
                                                }
                                                if (dt1.Columns.Contains("eta"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["eta"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("vesselname"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["vesselname"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("voyage"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["voyage"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>PLANNED</td>";

                                                cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "SEA" + "</td>";

                                                cont = cont + "</tr>";
                                                cont = cont + "</table>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> CARGO DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";



                                                cont = cont + "<div style='width:1010px; float:left; border-top:0px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:0px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:auto; color:#000; float:left; margin:0px; padding:5px; margin:0px; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:left;'>";
                                                cont = cont + "<label> Commodity :</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:auto; margin:0px 0px 0px 10px; padding:5px; text-align:left; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                if (dt1.Columns.Contains("cargotype"))
                                                {
                                                    cont = cont + "<label>" + dt1.Rows[0]["cargotype"].ToString() + "</label></div>";
                                                }
                                                else
                                                {

                                                }
                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>No of Packages:</div>";
                                                if (dt1.Columns.Contains("noofpkgs"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["noofpkgs"].ToString() + "</label></div>";//txt_noofpkg.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//txt_noofpkg.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Gross Weight : </div>";
                                                if (dt1.Columns.Contains("grweight"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["grweight"].ToString() + " </label></div>";// txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";// txt_wt.Text
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Volume  : </div>";
                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_approx_volume.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Chargeable Volume : </div>";

                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_wt.Text
                                                }
                                                else

                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";


                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + " <div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Origin</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Origin Pickup Date :</div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Export Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Cargo Received Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Loading Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + "    </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:990px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Shipped Onboard Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label> </label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Destination</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Discharge Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> ETA  :"+ dt1.Rows[0]["eta"].ToString() + "</div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Devanning CFS/Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> CAN Sent On : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>DO Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> DO Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Import Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Customs Reference Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1000px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; line-height:24px; padding:5px;'>";


                                                cont = cont + "";
                                                cont = cont + "THIS CONFIRMATION IS NOT VALID FOR PERSONAL EFFECTS, ANY MIS-DECLARATION WILL RESULT IN FINES / PENALTIES WHICH WILL BE TO YOUR ACCOUNT<br />";


                                                cont = cont + "Please note that Security Surcharge will be applicable at actuals.<br />";


                                                cont = cont + "Kindly contact the undersigned for further assistance<br />";


                                                cont = cont + "Thank you for using our service and, we look forward to being of service to you again.<br />";


                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "</div>";
                                                cont = cont + "</body>";
                                                cont = cont + "</html>";                                              
                                         
                                                if (hf_blno.Value!="")
                                                {

                                                    dtmail = objCust.getmailidforebooking(Convert.ToString(hf_blno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                                                    if (dtmail.Rows.Count > 0)
                                                    {
                                                        customerid = dtmail.Rows[0]["customerid"].ToString();
                                                        shipperidemailid = dtmail.Rows[0]["shipperidemailid"].ToString();
                                                        cosigneeidemailid = dtmail.Rows[0]["cosigneeidemailid"].ToString();
                                                        notifypartyidemailid = dtmail.Rows[0]["notifypartyidemailid"].ToString();
                                                    }
                                                   customermailid = customerid + ";" + shipperidemailid + ";" + cosigneeidemailid + ";" + notifypartyidemailid;

                                                    
                                                }                                            
                                    
                                                string sub11 = "Booking Events has been updated. Please find below details";

                                               Utility.SendMailnew("", customermailid, sub11, cont, "", "Msncl2021$", "");

                                            
                                            }
                                        }

                                    }

                                   if (ddlEvents.Text == "Origin On")
                                    {
                                      da_obj_FIJobobj.UpdateFIEventsoriginon(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_blno.Value);
                                       
                                       if (hf_blno.Value != "")
                                        {
                                           dt1 = da_obj_FIJobobj.spgetevents(Convert.ToInt32(Session["LoginBranchid"].ToString()), hf_blno.Value, Session["StrTranType"].ToString());


                                            if (dt1.Rows.Count>0)
                                            {
                                                cont = "";
                                                //origin = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate));

                                                origin = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)).ToString("dd-MMM-yyyy");
                                               
                                               cont = "<html>";
                                                cont = cont + "<body style='padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<div style='width:1010px; margin:0px auto; padding:10px; border:1px solid #000;'>";
                                                cont = cont + "<div style='width:1010px;'>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Origin Alert Mail to Consignee</label></div>";

                                                cont = cont + "<div style=' width:494px; color:#fff; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label style='color:#fff;'>LCL Import Booking Status</label></div>";



                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Message From " + Session["LoginDivisionName"].ToString() + "</label></div>";
                                                cont = cont + "<div style=' width:494px; color:#000; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";
                                                cont = cont + "<label>Date: " +origin+ "</label></div>";  // txt_date.Text
                                                //if (dt1.Columns.Contains("bookingdate"))
                                                //{
                                                //    cont = cont + "<label>Date: " + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";  // txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<label>Date: " + "" + "</label></div>";  // txt_date.Text
                                                //}
                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Dear Sir/Madam Alert Origin Pickup date has been updated  for the  Booking  # : " + dt1.Rows[0]["bookingno"].ToString() +" . Please find below details</label></div>";//txt_booking.Text

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'> BOOKING REFERENCE</label></div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Number : </div>";
                                                if (dt1.Columns.Contains("bookingno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["bookingno"].ToString() + "</label></div>";// txt_booking.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_booking.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Date : </div>";

                                                if (dt1.Columns.Contains("bookingdate"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";// txt_date.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Origin  : </div>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["POL"].ToString() + "</label></div>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_por.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Destination  : </div>";
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["POD"].ToString() + "</label></div>";//txt_fd.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";//txt_fd.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Number  : </div>";
                                                if (dt1.Columns.Contains("blno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["blno"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Date  : </div>";
                                                if (dt1.Columns.Contains("hbldate"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["hbldate"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Released  : </div>";
                                                if (dt1.Columns.Contains("doissueon"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["doissueon"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:990px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold;'>Customer Reference Number : </div>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Shipper</div>";
                                                cont = cont + "<div style='float:left; width:300px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'> ";
                                                if (dt1.Columns.Contains("shipper"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + dt1.Rows[0]["shipper"].ToString() + "</p>";//txt_shipper.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + "" + "</p>";//txt_shipper.Text
                                                }

                                                if (dt1.Columns.Contains("saddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["saddress"].ToString() + "</p>";// txtsaddress.Text
                                                }

                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "</p>";// txtsaddress.Text
                                                }
                                                cont = cont + "</div></div>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Consignee</div>";
                                                if (dt1.Columns.Contains("consignee"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["consignee"].ToString() + "</p>";// txt_consignee.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_consignee.Text
                                                }
                                                if (dt1.Columns.Contains("caddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["caddress"].ToString() + "<br />";// txtcaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "<br />";// txtcaddress.Text
                                                }
                                                cont = cont + "</p> </div>";
                                                cont = cont + "<div style='float:left; width:368px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:0px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:368px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'> Notify Party</div>";
                                                if (dt1.Columns.Contains("notifyparty"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["notifyparty"].ToString() + "</p>";// txt_notify.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_notify.Text
                                                }
                                                if (dt1.Columns.Contains("naddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["naddress"].ToString() + "</p>";// txtnaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txtnaddress.Text
                                                }
                                                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'></p></div></div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>  SHIPMENT DETAIL</label></div>";
                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Terms of Shipment:</div>";
                                                if (dt1.Columns.Contains("stype"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["stype"].ToString() + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Freight Terms : </div>";
                                                if (dt1.Columns.Contains("fstatus"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["fstatus"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Expiry Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:1010px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Carrier: </div>";
                                                if (dt1.Columns.Contains("CarrierName"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["CarrierName"].ToString() + "</label></div>"; // txt_customer.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>"; // txt_customer.Text
                                                }
                                                cont = cont + "</div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>CONNECTION DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<table width='1010' border='0' cellspacing='0' cellpadding='0' style='font-family:sans-serif, Geneva, sans-serif; color:#000; border-left:1px solid #000; border-right:1px solid #000; border-top:1px solid #000; border-bottom:0px solid #000; padding:0px 0px 0px 0px; margin:10px 0px 0px 0px; float:left;'>";
                                                cont = cont + " <tr><th style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Loading</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETD</th>";
                                                cont = cont + " <th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Discharge</th><th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETA</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Vessel</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'> Voyage No.</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Status</th>";
                                                cont = cont + "<th style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>Mode</th>";
                                                cont = cont + "</tr>";
                                                cont = cont + "<tr>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POL"].ToString() + "</td>";// txt_pol.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_pol.Text
                                                }
                                                if (dt1.Columns.Contains("etd"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["etd"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POD"].ToString() + "</td>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_por.Text
                                                }
                                                if (dt1.Columns.Contains("eta"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["eta"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("vesselname"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["vesselname"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("voyage"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["voyage"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>PLANNED</td>";

                                                cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "SEA" + "</td>";

                                                cont = cont + "</tr>";
                                                cont = cont + "</table>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> CARGO DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";



                                                cont = cont + "<div style='width:1010px; float:left; border-top:0px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:0px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:auto; color:#000; float:left; margin:0px; padding:5px; margin:0px; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:left;'>";
                                                cont = cont + "<label> Commodity :</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:auto; margin:0px 0px 0px 10px; padding:5px; text-align:left; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                if (dt1.Columns.Contains("cargotype"))
                                                {
                                                    cont = cont + "<label>" + dt1.Rows[0]["cargotype"].ToString() + "</label></div>";
                                                }
                                                else
                                                {

                                                }
                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>No of Packages:</div>";
                                                if (dt1.Columns.Contains("noofpkgs"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["noofpkgs"].ToString() + "</label></div>";//txt_noofpkg.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//txt_noofpkg.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Gross Weight : </div>";
                                                if (dt1.Columns.Contains("grweight"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["grweight"].ToString() + " </label></div>";// txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";// txt_wt.Text
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Volume  : </div>";
                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_approx_volume.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Chargeable Volume : </div>";

                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_wt.Text
                                                }
                                                else

                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";


                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + " <div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Origin</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Origin Pickup Date :" + origin + "</div>";
                                                //if (dt1.Columns.Contains("originon"))
                                                //{
                                                //    cont = cont + "<label>Date: " +origin + "</label></div>";  // txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<label>Date: " + "" + "</label></div>";  // txt_date.Text
                                                //}


                                                //if (dt1.Columns.Contains("originon"))
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["origin"].ToString() + "</label></div>";// txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                //}
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Export Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Cargo Received Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Loading Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + "  </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:990px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Shipped Onboard Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label> </label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Destination</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Discharge Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + "</div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> ETA  :" + dt1.Rows[0]["eta"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Devanning CFS/Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> CAN Sent On : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>DO Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> DO Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Import Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Customs Reference Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1000px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; line-height:24px; padding:5px;'>";


                                                cont = cont + "";
                                                cont = cont + "THIS CONFIRMATION IS NOT VALID FOR PERSONAL EFFECTS, ANY MIS-DECLARATION WILL RESULT IN FINES / PENALTIES WHICH WILL BE TO YOUR ACCOUNT<br />";


                                                cont = cont + "Please note that Security Surcharge will be applicable at actuals.<br />";


                                                cont = cont + "Kindly contact the undersigned for further assistance<br />";


                                                cont = cont + "Thank you for using our service and, we look forward to being of service to you again.<br />";


                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "</div>";
                                                cont = cont + "</body>";
                                                cont = cont + "</html>";

                                                if (hf_blno.Value != "")
                                                {

                                                    dtmail = objCust.getmailidforebooking(Convert.ToString(hf_blno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                                                    if (dtmail.Rows.Count > 0)
                                                    {
                                                        customerid = dtmail.Rows[0]["customerid"].ToString();
                                                        shipperidemailid = dtmail.Rows[0]["shipperidemailid"].ToString();
                                                        cosigneeidemailid = dtmail.Rows[0]["cosigneeidemailid"].ToString();
                                                        notifypartyidemailid = dtmail.Rows[0]["notifypartyidemailid"].ToString();
                                                    }
                                                    customermailid = customerid + ";" + shipperidemailid + ";" + cosigneeidemailid + ";" + notifypartyidemailid;


                                                }

                                                string sub11 = "Origin Pickup has been updated. Please find below details";

                                                Utility.SendMailnew("", customermailid, sub11, cont, "", "Msncl2021$", "");
                                                
                                            }
                                        }

                                    
                                    }
                                    if (ddlEvents.Text == "Draft Confirmed On")
                                    {
                                        da_obj_FIJobobj.UpdateFIEventsdraftconfir(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_blno.Value);


                                        if (hf_blno.Value != "")
                                        {
                                            dt1 = da_obj_FIJobobj.spgetevents(Convert.ToInt32(Session["LoginBranchid"].ToString()), hf_blno.Value, Session["StrTranType"].ToString());


                                            if (dt1.Rows.Count > 0)
                                            {
                                                cont = "";
                                                //origin = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate));

                                                origin = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)).ToString("dd-MMM-yyyy");

                                                cont = "<html>";
                                                cont = cont + "<body style='padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<div style='width:1010px; margin:0px auto; padding:10px; border:1px solid #000;'>";
                                                cont = cont + "<div style='width:1010px;'>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Draft Confirmed Alert Mail to Consignee</label></div>";

                                                cont = cont + "<div style=' width:494px; color:#fff; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label style='color:#fff;'>LCL Import Booking Status</label></div>";



                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Message From " + Session["LoginDivisionName"].ToString() + "</label></div>";
                                                cont = cont + "<div style=' width:494px; color:#000; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";
                                                cont = cont + "<label>Date: " + origin + "</label></div>";  // txt_date.Text
                                                //if (dt1.Columns.Contains("bookingdate"))
                                                //{
                                                //    cont = cont + "<label>Date: " + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";  // txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<label>Date: " + "" + "</label></div>";  // txt_date.Text
                                                //}
                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Dear Sir/Madam Alert Draft Confirmed Date has been updated  for the  Booking  # : " + dt1.Rows[0]["bookingno"].ToString() + " . Please find below details</label></div>";//txt_booking.Text

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'> BOOKING REFERENCE</label></div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Number : </div>";
                                                if (dt1.Columns.Contains("bookingno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["bookingno"].ToString() + "</label></div>";// txt_booking.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_booking.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Date : </div>";

                                                if (dt1.Columns.Contains("bookingdate"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";// txt_date.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Origin  : </div>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["POL"].ToString() + "</label></div>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_por.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Destination  : </div>";
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["POD"].ToString() + "</label></div>";//txt_fd.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";//txt_fd.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Number  : </div>";
                                                if (dt1.Columns.Contains("blno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["blno"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Date  : </div>";
                                                if (dt1.Columns.Contains("hbldate"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["hbldate"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Released  : </div>";
                                                if (dt1.Columns.Contains("doissueon"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["doissueon"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:990px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold;'>Customer Reference Number : </div>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Shipper</div>";
                                                cont = cont + "<div style='float:left; width:300px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'> ";
                                                if (dt1.Columns.Contains("shipper"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + dt1.Rows[0]["shipper"].ToString() + "</p>";//txt_shipper.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + "" + "</p>";//txt_shipper.Text
                                                }

                                                if (dt1.Columns.Contains("saddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["saddress"].ToString() + "</p>";// txtsaddress.Text
                                                }

                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "</p>";// txtsaddress.Text
                                                }
                                                cont = cont + "</div></div>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Consignee</div>";
                                                if (dt1.Columns.Contains("consignee"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["consignee"].ToString() + "</p>";// txt_consignee.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_consignee.Text
                                                }
                                                if (dt1.Columns.Contains("caddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["caddress"].ToString() + "<br />";// txtcaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "<br />";// txtcaddress.Text
                                                }
                                                cont = cont + "</p> </div>";
                                                cont = cont + "<div style='float:left; width:368px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:0px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:368px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'> Notify Party</div>";
                                                if (dt1.Columns.Contains("notifyparty"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["notifyparty"].ToString() + "</p>";// txt_notify.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_notify.Text
                                                }
                                                if (dt1.Columns.Contains("naddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["naddress"].ToString() + "</p>";// txtnaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txtnaddress.Text
                                                }
                                                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'></p></div></div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>  SHIPMENT DETAIL</label></div>";
                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Terms of Shipment:</div>";
                                                if (dt1.Columns.Contains("stype"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["stype"].ToString() + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Freight Terms : </div>";
                                                if (dt1.Columns.Contains("fstatus"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["fstatus"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Expiry Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:1010px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Carrier: </div>";
                                                if (dt1.Columns.Contains("CarrierName"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["CarrierName"].ToString() + "</label></div>"; // txt_customer.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>"; // txt_customer.Text
                                                }
                                                cont = cont + "</div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>CONNECTION DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<table width='1010' border='0' cellspacing='0' cellpadding='0' style='font-family:sans-serif, Geneva, sans-serif; color:#000; border-left:1px solid #000; border-right:1px solid #000; border-top:1px solid #000; border-bottom:0px solid #000; padding:0px 0px 0px 0px; margin:10px 0px 0px 0px; float:left;'>";
                                                cont = cont + " <tr><th style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Loading</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETD</th>";
                                                cont = cont + " <th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Discharge</th><th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETA</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Vessel</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'> Voyage No.</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Status</th>";
                                                cont = cont + "<th style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>Mode</th>";
                                                cont = cont + "</tr>";
                                                cont = cont + "<tr>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POL"].ToString() + "</td>";// txt_pol.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_pol.Text
                                                }
                                                if (dt1.Columns.Contains("etd"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["etd"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POD"].ToString() + "</td>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_por.Text
                                                }
                                                if (dt1.Columns.Contains("eta"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["eta"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("vesselname"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["vesselname"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("voyage"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["voyage"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>PLANNED</td>";

                                                cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "SEA" + "</td>";

                                                cont = cont + "</tr>";
                                                cont = cont + "</table>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> CARGO DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";



                                                cont = cont + "<div style='width:1010px; float:left; border-top:0px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:0px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:auto; color:#000; float:left; margin:0px; padding:5px; margin:0px; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:left;'>";
                                                cont = cont + "<label> Commodity :</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:auto; margin:0px 0px 0px 10px; padding:5px; text-align:left; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                if (dt1.Columns.Contains("cargotype"))
                                                {
                                                    cont = cont + "<label>" + dt1.Rows[0]["cargotype"].ToString() + "</label></div>";
                                                }
                                                else
                                                {

                                                }
                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>No of Packages:</div>";
                                                if (dt1.Columns.Contains("noofpkgs"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["noofpkgs"].ToString() + "</label></div>";//txt_noofpkg.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//txt_noofpkg.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Gross Weight : </div>";
                                                if (dt1.Columns.Contains("grweight"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["grweight"].ToString() + " </label></div>";// txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";// txt_wt.Text
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Volume  : </div>";
                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_approx_volume.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Chargeable Volume : </div>";

                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";


                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + " <div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Origin</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Origin Pickup Date :" + "" + "</div>";
                                                //if (dt1.Columns.Contains("originon"))
                                                //{
                                                //    cont = cont + "<label>Date: " +origin + "</label></div>";  // txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<label>Date: " + "" + "</label></div>";  // txt_date.Text
                                                //}


                                                //if (dt1.Columns.Contains("originon"))
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["origin"].ToString() + "</label></div>";// txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                //}
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Export Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Cargo Received Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Loading Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + "  </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:990px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Shipped Onboard Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label> </label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Destination</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Discharge Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + "</div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> ETA  :" + dt1.Rows[0]["eta"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Devanning CFS/Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> CAN Sent On : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>DO Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> DO Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Import Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Customs Reference Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1000px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; line-height:24px; padding:5px;'>";


                                                cont = cont + "";
                                                cont = cont + "THIS CONFIRMATION IS NOT VALID FOR PERSONAL EFFECTS, ANY MIS-DECLARATION WILL RESULT IN FINES / PENALTIES WHICH WILL BE TO YOUR ACCOUNT<br />";


                                                cont = cont + "Please note that Security Surcharge will be applicable at actuals.<br />";


                                                cont = cont + "Kindly contact the undersigned for further assistance<br />";


                                                cont = cont + "Thank you for using our service and, we look forward to being of service to you again.<br />";


                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "</div>";
                                                cont = cont + "</body>";
                                                cont = cont + "</html>";

                                                if (hf_blno.Value != "")
                                                {

                                                    dtmail = objCust.getmailidforebooking(Convert.ToString(hf_blno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                                                    if (dtmail.Rows.Count > 0)
                                                    {
                                                        customerid = dtmail.Rows[0]["customerid"].ToString();
                                                        shipperidemailid = dtmail.Rows[0]["shipperidemailid"].ToString();
                                                        cosigneeidemailid = dtmail.Rows[0]["cosigneeidemailid"].ToString();
                                                        notifypartyidemailid = dtmail.Rows[0]["notifypartyidemailid"].ToString();
                                                    }
                                                    customermailid = customerid + ";" + shipperidemailid + ";" + cosigneeidemailid + ";" + notifypartyidemailid;

                                                   

                                                }

                                                string sub11 = "Draft Confirmed has been updated. Please find below details";

                                                Utility.SendMailnew("", customermailid, sub11, cont, "", "Msncl2021$", "");

                                                

                                            }
                                        }

                                    }
                                    if (ddlEvents.Text == "Vessel Departured On")
                                    {
                                       da_obj_FIJobobj.UpdateFIEventsvesseldepar(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_blno.Value);
                                         if (hf_blno.Value != "")
                                         {
                                           dt1 = da_obj_FIJobobj.spgetevents(Convert.ToInt32(Session["LoginBranchid"].ToString()), hf_blno.Value, Session["StrTranType"].ToString());


                                            if (dt1.Rows.Count>0)
                                            {
                                                cont = "";
                                                origin = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)).ToString("dd-MMM-yyyy");
                                                cont = "<html>";
                                                cont = cont + "<body style='padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<div style='width:1010px; margin:0px auto; padding:10px; border:1px solid #000;'>";
                                                cont = cont + "<div style='width:1010px;'>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Shipping Onboard Alert Mail to Consignee</label></div>";

                                                cont = cont + "<div style=' width:494px; color:#fff; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label style='color:#fff;'>LCL Import Booking Status</label></div>";



                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Message From " + Session["LoginDivisionName"].ToString() + "</label></div>";
                                                cont = cont + "<div style=' width:494px; color:#000; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";
                                                cont = cont + "<label>Date: " + origin + "</label></div>";  // txt_date.Text
                                                //if (dt1.Columns.Contains("bookingdate"))
                                                //{
                                                //    cont = cont + "<label>Date: " + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";  // txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<label>Date: " + "" + "</label></div>";  // txt_date.Text
                                                //}
                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Dear Sir/Madam,Alert Shipping Onboard has been updated for the Booking  # : " + dt1.Rows[0]["bookingno"].ToString() +" . Please find below details</label></div>";//txt_booking.Text

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'> BOOKING REFERENCE</label></div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Number : </div>";
                                                if (dt1.Columns.Contains("bookingno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["bookingno"].ToString() + "</label></div>";// txt_booking.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_booking.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Date : </div>";

                                                if (dt1.Columns.Contains("bookingdate"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";// txt_date.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Origin  : </div>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["POL"].ToString() + "</label></div>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_por.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Destination  : </div>";
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["POD"].ToString() + "</label></div>";//txt_fd.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";//txt_fd.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Number  : </div>";
                                                if (dt1.Columns.Contains("blno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["blno"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Date  : </div>";
                                                if (dt1.Columns.Contains("hbldate"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["hbldate"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Released  : </div>";
                                                if (dt1.Columns.Contains("doissueon"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["doissueon"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:990px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold;'>Customer Reference Number : </div>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Shipper</div>";
                                                cont = cont + "<div style='float:left; width:300px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'> ";
                                                if (dt1.Columns.Contains("shipper"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + dt1.Rows[0]["shipper"].ToString() + "</p>";//txt_shipper.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + "" + "</p>";//txt_shipper.Text
                                                }

                                                if (dt1.Columns.Contains("saddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["saddress"].ToString() + "</p>";// txtsaddress.Text
                                                }

                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "</p>";// txtsaddress.Text
                                                }
                                                cont = cont + "</div></div>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Consignee</div>";
                                                if (dt1.Columns.Contains("consignee"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["consignee"].ToString() + "</p>";// txt_consignee.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_consignee.Text
                                                }
                                                if (dt1.Columns.Contains("caddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["caddress"].ToString() + "<br />";// txtcaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "<br />";// txtcaddress.Text
                                                }
                                                cont = cont + "</p> </div>";
                                                cont = cont + "<div style='float:left; width:368px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:0px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:368px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'> Notify Party</div>";
                                                if (dt1.Columns.Contains("notifyparty"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["notifyparty"].ToString() + "</p>";// txt_notify.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_notify.Text
                                                }
                                                if (dt1.Columns.Contains("naddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["naddress"].ToString() + "</p>";// txtnaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txtnaddress.Text
                                                }
                                                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'></p></div></div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>  SHIPMENT DETAIL</label></div>";
                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Terms of Shipment:</div>";
                                                if (dt1.Columns.Contains("stype"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["stype"].ToString() + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Freight Terms : </div>";
                                                if (dt1.Columns.Contains("fstatus"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["fstatus"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Expiry Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:1010px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Carrier: </div>";
                                                if (dt1.Columns.Contains("CarrierName"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["CarrierName"].ToString() + "</label></div>"; // txt_customer.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>"; // txt_customer.Text
                                                }
                                                cont = cont + "</div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>CONNECTION DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<table width='1010' border='0' cellspacing='0' cellpadding='0' style='font-family:sans-serif, Geneva, sans-serif; color:#000; border-left:1px solid #000; border-right:1px solid #000; border-top:1px solid #000; border-bottom:0px solid #000; padding:0px 0px 0px 0px; margin:10px 0px 0px 0px; float:left;'>";
                                                cont = cont + " <tr><th style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Loading</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETD</th>";
                                                cont = cont + " <th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Discharge</th><th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETA</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Vessel</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'> Voyage No.</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Status</th>";
                                                cont = cont + "<th style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>Mode</th>";
                                                cont = cont + "</tr>";
                                                cont = cont + "<tr>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POL"].ToString() + "</td>";// txt_pol.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_pol.Text
                                                }
                                                if (dt1.Columns.Contains("etd"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["etd"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POD"].ToString() + "</td>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_por.Text
                                                }
                                                if (dt1.Columns.Contains("eta"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["eta"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("vesselname"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["vesselname"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("voyage"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["voyage"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>PLANNED</td>";

                                                cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "SEA" + "</td>";

                                                cont = cont + "</tr>";
                                                cont = cont + "</table>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> CARGO DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";



                                                cont = cont + "<div style='width:1010px; float:left; border-top:0px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:0px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:auto; color:#000; float:left; margin:0px; padding:5px; margin:0px; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:left;'>";
                                                cont = cont + "<label> Commodity :</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:auto; margin:0px 0px 0px 10px; padding:5px; text-align:left; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                if (dt1.Columns.Contains("cargotype"))
                                                {
                                                    cont = cont + "<label>" + dt1.Rows[0]["cargotype"].ToString() + "</label></div>";
                                                }
                                                else
                                                {

                                                }
                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>No of Packages:</div>";
                                                if (dt1.Columns.Contains("noofpkgs"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["noofpkgs"].ToString() + "</label></div>";//txt_noofpkg.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//txt_noofpkg.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Gross Weight : </div>";
                                                if (dt1.Columns.Contains("grweight"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["grweight"].ToString() + " </label></div>";// txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";// txt_wt.Text
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Volume  : </div>";
                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_approx_volume.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Chargeable Volume : </div>";

                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_wt.Text
                                                }
                                                else

                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";


                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + " <div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Origin</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Origin Pickup Date :</div>";
                                               
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Export Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Cargo Received Date : </div>";
                                              
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Loading Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + "  </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:990px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Shipped Onboard Date :"+origin+" </div>";
                                                // if (dt1.Columns.Contains("vesseldepar"))
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["vesseldepar"].ToString() + "</label></div>";// txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                //}

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label> </label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Destination</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Discharge Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> ETA  : " + dt1.Rows[0]["eta"].ToString() + "</div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Devanning CFS/Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> CAN Sent On : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>DO Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> DO Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Import Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Customs Reference Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1000px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; line-height:24px; padding:5px;'>";


                                                cont = cont + "";
                                                cont = cont + "THIS CONFIRMATION IS NOT VALID FOR PERSONAL EFFECTS, ANY MIS-DECLARATION WILL RESULT IN FINES / PENALTIES WHICH WILL BE TO YOUR ACCOUNT<br />";


                                                cont = cont + "Please note that Security Surcharge will be applicable at actuals.<br />";


                                                cont = cont + "Kindly contact the undersigned for further assistance<br />";


                                                cont = cont + "Thank you for using our service and, we look forward to being of service to you again.<br />";


                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "</div>";
                                                cont = cont + "</body>";
                                                cont = cont + "</html>";
                                                //mailcontent.Visible = true;

                                                //mailcontent.Text = cont.ToString();

                                                if (hf_blno.Value != "")
                                                {

                                                    dtmail = objCust.getmailidforebooking(Convert.ToString(hf_blno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                                                    if (dtmail.Rows.Count > 0)
                                                    {
                                                        customerid = dtmail.Rows[0]["customerid"].ToString();
                                                        shipperidemailid = dtmail.Rows[0]["shipperidemailid"].ToString();
                                                        cosigneeidemailid = dtmail.Rows[0]["cosigneeidemailid"].ToString();
                                                        notifypartyidemailid = dtmail.Rows[0]["notifypartyidemailid"].ToString();
                                                    }
                                                    customermailid = customerid + ";" + shipperidemailid + ";" + cosigneeidemailid + ";" + notifypartyidemailid;
                                                    
                                                }

                                                string sub11 = "Shipping Onboard has been updated. Please find below details";

                                                Utility.SendMailnew("", customermailid, sub11, cont, "", "Msncl2021$", "");

                                            }
                                        }

                                    }

                                    if (ddlEvents.Text == "Prealert Sent On")
                                    {
                                        da_obj_FIJobobj.UpdateFIEventsprealertsenton(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_blno.Value);


                                        if (hf_blno.Value != "")
                                        {
                                            dt1 = da_obj_FIJobobj.spgetevents(Convert.ToInt32(Session["LoginBranchid"].ToString()), hf_blno.Value, Session["StrTranType"].ToString());


                                            if (dt1.Rows.Count > 0)
                                            {
                                                cont = "";
                                                origin = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)).ToString("dd-MMM-yyyy");
                                                cont = "<html>";
                                                cont = cont + "<body style='padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<div style='width:1010px; margin:0px auto; padding:10px; border:1px solid #000;'>";
                                                cont = cont + "<div style='width:1010px;'>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Prealert Sent Alert Mail to Consignee</label></div>";

                                                cont = cont + "<div style=' width:494px; color:#fff; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label style='color:#fff;'>LCL Import Booking Status</label></div>";



                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Message From " + Session["LoginDivisionName"].ToString() + "</label></div>";
                                                cont = cont + "<div style=' width:494px; color:#000; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";
                                                cont = cont + "<label>Date: " + origin + "</label></div>";  // txt_date.Text
                                                //if (dt1.Columns.Contains("bookingdate"))
                                                //{
                                                //    cont = cont + "<label>Date: " + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";  // txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<label>Date: " + "" + "</label></div>";  // txt_date.Text
                                                //}
                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Dear Sir/Madam,Prealert Sent has been updated for the Booking  # : " + dt1.Rows[0]["bookingno"].ToString() + " . Please find below details</label></div>";//txt_booking.Text

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'> BOOKING REFERENCE</label></div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Number : </div>";
                                                if (dt1.Columns.Contains("bookingno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["bookingno"].ToString() + "</label></div>";// txt_booking.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_booking.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Date : </div>";

                                                if (dt1.Columns.Contains("bookingdate"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";// txt_date.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Origin  : </div>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["POL"].ToString() + "</label></div>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_por.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Destination  : </div>";
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["POD"].ToString() + "</label></div>";//txt_fd.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";//txt_fd.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Number  : </div>";
                                                if (dt1.Columns.Contains("blno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["blno"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Date  : </div>";
                                                if (dt1.Columns.Contains("hbldate"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["hbldate"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Released  : </div>";
                                                if (dt1.Columns.Contains("doissueon"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["doissueon"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:990px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold;'>Customer Reference Number : </div>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Shipper</div>";
                                                cont = cont + "<div style='float:left; width:300px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'> ";
                                                if (dt1.Columns.Contains("shipper"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + dt1.Rows[0]["shipper"].ToString() + "</p>";//txt_shipper.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + "" + "</p>";//txt_shipper.Text
                                                }

                                                if (dt1.Columns.Contains("saddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["saddress"].ToString() + "</p>";// txtsaddress.Text
                                                }

                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "</p>";// txtsaddress.Text
                                                }
                                                cont = cont + "</div></div>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Consignee</div>";
                                                if (dt1.Columns.Contains("consignee"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["consignee"].ToString() + "</p>";// txt_consignee.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_consignee.Text
                                                }
                                                if (dt1.Columns.Contains("caddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["caddress"].ToString() + "<br />";// txtcaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "<br />";// txtcaddress.Text
                                                }
                                                cont = cont + "</p> </div>";
                                                cont = cont + "<div style='float:left; width:368px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:0px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:368px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'> Notify Party</div>";
                                                if (dt1.Columns.Contains("notifyparty"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["notifyparty"].ToString() + "</p>";// txt_notify.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_notify.Text
                                                }
                                                if (dt1.Columns.Contains("naddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["naddress"].ToString() + "</p>";// txtnaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txtnaddress.Text
                                                }
                                                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'></p></div></div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>  SHIPMENT DETAIL</label></div>";
                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Terms of Shipment:</div>";
                                                if (dt1.Columns.Contains("stype"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["stype"].ToString() + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Freight Terms : </div>";
                                                if (dt1.Columns.Contains("fstatus"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["fstatus"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Expiry Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:1010px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Carrier: </div>";
                                                if (dt1.Columns.Contains("CarrierName"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["CarrierName"].ToString() + "</label></div>"; // txt_customer.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>"; // txt_customer.Text
                                                }
                                                cont = cont + "</div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>CONNECTION DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<table width='1010' border='0' cellspacing='0' cellpadding='0' style='font-family:sans-serif, Geneva, sans-serif; color:#000; border-left:1px solid #000; border-right:1px solid #000; border-top:1px solid #000; border-bottom:0px solid #000; padding:0px 0px 0px 0px; margin:10px 0px 0px 0px; float:left;'>";
                                                cont = cont + " <tr><th style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Loading</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETD</th>";
                                                cont = cont + " <th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Discharge</th><th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETA</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Vessel</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'> Voyage No.</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Status</th>";
                                                cont = cont + "<th style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>Mode</th>";
                                                cont = cont + "</tr>";
                                                cont = cont + "<tr>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POL"].ToString() + "</td>";// txt_pol.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_pol.Text
                                                }
                                                if (dt1.Columns.Contains("etd"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["etd"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POD"].ToString() + "</td>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_por.Text
                                                }
                                                if (dt1.Columns.Contains("eta"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["eta"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("vesselname"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["vesselname"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("voyage"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["voyage"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>PLANNED</td>";

                                                cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "SEA" + "</td>";

                                                cont = cont + "</tr>";
                                                cont = cont + "</table>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> CARGO DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";



                                                cont = cont + "<div style='width:1010px; float:left; border-top:0px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:0px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:auto; color:#000; float:left; margin:0px; padding:5px; margin:0px; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:left;'>";
                                                cont = cont + "<label> Commodity :</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:auto; margin:0px 0px 0px 10px; padding:5px; text-align:left; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                if (dt1.Columns.Contains("cargotype"))
                                                {
                                                    cont = cont + "<label>" + dt1.Rows[0]["cargotype"].ToString() + "</label></div>";
                                                }
                                                else
                                                {

                                                }
                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>No of Packages:</div>";
                                                if (dt1.Columns.Contains("noofpkgs"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["noofpkgs"].ToString() + "</label></div>";//txt_noofpkg.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//txt_noofpkg.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Gross Weight : </div>";
                                                if (dt1.Columns.Contains("grweight"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["grweight"].ToString() + " </label></div>";// txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";// txt_wt.Text
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Volume  : </div>";
                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_approx_volume.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Chargeable Volume : </div>";

                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";


                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + " <div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Origin</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Origin Pickup Date :</div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Export Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Cargo Received Date : </div>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Loading Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + "  </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:990px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Shipped Onboard Date :" + "" + " </div>";
                                                // if (dt1.Columns.Contains("vesseldepar"))
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["vesseldepar"].ToString() + "</label></div>";// txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                //}

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label> </label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Destination</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Discharge Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> ETA  : " + dt1.Rows[0]["eta"].ToString() + "</div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Devanning CFS/Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> CAN Sent On : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>DO Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> DO Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Import Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Customs Reference Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1000px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; line-height:24px; padding:5px;'>";


                                                cont = cont + "";
                                                cont = cont + "THIS CONFIRMATION IS NOT VALID FOR PERSONAL EFFECTS, ANY MIS-DECLARATION WILL RESULT IN FINES / PENALTIES WHICH WILL BE TO YOUR ACCOUNT<br />";


                                                cont = cont + "Please note that Security Surcharge will be applicable at actuals.<br />";


                                                cont = cont + "Kindly contact the undersigned for further assistance<br />";


                                                cont = cont + "Thank you for using our service and, we look forward to being of service to you again.<br />";


                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "</div>";
                                                cont = cont + "</body>";
                                                cont = cont + "</html>";
                                                //mailcontent.Visible = true;

                                                //mailcontent.Text = cont.ToString();

                                                if (hf_blno.Value != "")
                                                {

                                                    dtmail = objCust.getmailidforebooking(Convert.ToString(hf_blno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                                                    if (dtmail.Rows.Count > 0)
                                                    {
                                                        customerid = dtmail.Rows[0]["customerid"].ToString();
                                                        shipperidemailid = dtmail.Rows[0]["shipperidemailid"].ToString();
                                                        cosigneeidemailid = dtmail.Rows[0]["cosigneeidemailid"].ToString();
                                                        notifypartyidemailid = dtmail.Rows[0]["notifypartyidemailid"].ToString();
                                                    }
                                                    customermailid = customerid + ";" + shipperidemailid + ";" + cosigneeidemailid + ";" + notifypartyidemailid;

                                                }

                                                string sub11 = "Prealert Sent has been updated. Please find below details";

                                                Utility.SendMailnew("", customermailid, sub11, cont, "", "Msncl2021$", "");
                                                
                                            }
                                        }


                                    }
                                    if (ddlEvents.Text == "Transhippment arrived On")
                                    {
                                        da_obj_FIJobobj.UpdateFIEventstransarrive(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_blno.Value);

                                        if (hf_blno.Value != "")
                                        {
                                            dt1 = da_obj_FIJobobj.spgetevents(Convert.ToInt32(Session["LoginBranchid"].ToString()), hf_blno.Value, Session["StrTranType"].ToString());


                                            if (dt1.Rows.Count > 0)
                                            {
                                                cont = "";
                                                origin = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)).ToString("dd-MMM-yyyy");
                                                cont = "<html>";
                                                cont = cont + "<body style='padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<div style='width:1010px; margin:0px auto; padding:10px; border:1px solid #000;'>";
                                                cont = cont + "<div style='width:1010px;'>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Transhippment Arrived Alert Mail to Consignee</label></div>";

                                                cont = cont + "<div style=' width:494px; color:#fff; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label style='color:#fff;'>LCL Import Booking Status</label></div>";



                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Message From " + Session["LoginDivisionName"].ToString() + "</label></div>";
                                                cont = cont + "<div style=' width:494px; color:#000; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";
                                                cont = cont + "<label>Date: " + origin + "</label></div>";  // txt_date.Text
                                                //if (dt1.Columns.Contains("bookingdate"))
                                                //{
                                                //    cont = cont + "<label>Date: " + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";  // txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<label>Date: " + "" + "</label></div>";  // txt_date.Text
                                                //}
                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Dear Sir/Madam,Alert Transhippment Arrived has been updated for the Booking  # : " + dt1.Rows[0]["bookingno"].ToString() + " . Please find below details</label></div>";//txt_booking.Text

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'> BOOKING REFERENCE</label></div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Number : </div>";
                                                if (dt1.Columns.Contains("bookingno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["bookingno"].ToString() + "</label></div>";// txt_booking.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_booking.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Date : </div>";

                                                if (dt1.Columns.Contains("bookingdate"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";// txt_date.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Origin  : </div>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["POL"].ToString() + "</label></div>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_por.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Destination  : </div>";
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["POD"].ToString() + "</label></div>";//txt_fd.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";//txt_fd.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Number  : </div>";
                                                if (dt1.Columns.Contains("blno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["blno"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Date  : </div>";
                                                if (dt1.Columns.Contains("hbldate"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["hbldate"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Released  : </div>";
                                                if (dt1.Columns.Contains("doissueon"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["doissueon"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:990px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold;'>Customer Reference Number : </div>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Shipper</div>";
                                                cont = cont + "<div style='float:left; width:300px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'> ";
                                                if (dt1.Columns.Contains("shipper"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + dt1.Rows[0]["shipper"].ToString() + "</p>";//txt_shipper.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + "" + "</p>";//txt_shipper.Text
                                                }

                                                if (dt1.Columns.Contains("saddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["saddress"].ToString() + "</p>";// txtsaddress.Text
                                                }

                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "</p>";// txtsaddress.Text
                                                }
                                                cont = cont + "</div></div>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Consignee</div>";
                                                if (dt1.Columns.Contains("consignee"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["consignee"].ToString() + "</p>";// txt_consignee.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_consignee.Text
                                                }
                                                if (dt1.Columns.Contains("caddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["caddress"].ToString() + "<br />";// txtcaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "<br />";// txtcaddress.Text
                                                }
                                                cont = cont + "</p> </div>";
                                                cont = cont + "<div style='float:left; width:368px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:0px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:368px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'> Notify Party</div>";
                                                if (dt1.Columns.Contains("notifyparty"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["notifyparty"].ToString() + "</p>";// txt_notify.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_notify.Text
                                                }
                                                if (dt1.Columns.Contains("naddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["naddress"].ToString() + "</p>";// txtnaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txtnaddress.Text
                                                }
                                                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'></p></div></div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>  SHIPMENT DETAIL</label></div>";
                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Terms of Shipment:</div>";
                                                if (dt1.Columns.Contains("stype"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["stype"].ToString() + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Freight Terms : </div>";
                                                if (dt1.Columns.Contains("fstatus"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["fstatus"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Expiry Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:1010px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Carrier: </div>";
                                                if (dt1.Columns.Contains("CarrierName"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["CarrierName"].ToString() + "</label></div>"; // txt_customer.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>"; // txt_customer.Text
                                                }
                                                cont = cont + "</div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>CONNECTION DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<table width='1010' border='0' cellspacing='0' cellpadding='0' style='font-family:sans-serif, Geneva, sans-serif; color:#000; border-left:1px solid #000; border-right:1px solid #000; border-top:1px solid #000; border-bottom:0px solid #000; padding:0px 0px 0px 0px; margin:10px 0px 0px 0px; float:left;'>";
                                                cont = cont + " <tr><th style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Loading</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETD</th>";
                                                cont = cont + " <th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Discharge</th><th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETA</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Vessel</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'> Voyage No.</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Status</th>";
                                                cont = cont + "<th style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>Mode</th>";
                                                cont = cont + "</tr>";
                                                cont = cont + "<tr>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POL"].ToString() + "</td>";// txt_pol.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_pol.Text
                                                }
                                                if (dt1.Columns.Contains("etd"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["etd"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POD"].ToString() + "</td>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_por.Text
                                                }
                                                if (dt1.Columns.Contains("eta"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["eta"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("vesselname"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["vesselname"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("voyage"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["voyage"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>PLANNED</td>";

                                                cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "SEA" + "</td>";

                                                cont = cont + "</tr>";
                                                cont = cont + "</table>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> CARGO DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";



                                                cont = cont + "<div style='width:1010px; float:left; border-top:0px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:0px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:auto; color:#000; float:left; margin:0px; padding:5px; margin:0px; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:left;'>";
                                                cont = cont + "<label> Commodity :</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:auto; margin:0px 0px 0px 10px; padding:5px; text-align:left; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                if (dt1.Columns.Contains("cargotype"))
                                                {
                                                    cont = cont + "<label>" + dt1.Rows[0]["cargotype"].ToString() + "</label></div>";
                                                }
                                                else
                                                {

                                                }
                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>No of Packages:</div>";
                                                if (dt1.Columns.Contains("noofpkgs"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["noofpkgs"].ToString() + "</label></div>";//txt_noofpkg.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//txt_noofpkg.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Gross Weight : </div>";
                                                if (dt1.Columns.Contains("grweight"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["grweight"].ToString() + " </label></div>";// txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";// txt_wt.Text
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Volume  : </div>";
                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_approx_volume.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Chargeable Volume : </div>";

                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";


                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + " <div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Origin</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Origin Pickup Date :</div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Export Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Cargo Received Date : </div>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Loading Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + "  </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:990px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Shipped Onboard Date :" + "" + " </div>";
                                                // if (dt1.Columns.Contains("vesseldepar"))
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["vesseldepar"].ToString() + "</label></div>";// txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                //}

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label> </label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Destination</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Discharge Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> ETA  : " + dt1.Rows[0]["eta"].ToString() + "</div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Devanning CFS/Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> CAN Sent On : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>DO Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> DO Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Import Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Customs Reference Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1000px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; line-height:24px; padding:5px;'>";


                                                cont = cont + "";
                                                cont = cont + "THIS CONFIRMATION IS NOT VALID FOR PERSONAL EFFECTS, ANY MIS-DECLARATION WILL RESULT IN FINES / PENALTIES WHICH WILL BE TO YOUR ACCOUNT<br />";


                                                cont = cont + "Please note that Security Surcharge will be applicable at actuals.<br />";


                                                cont = cont + "Kindly contact the undersigned for further assistance<br />";


                                                cont = cont + "Thank you for using our service and, we look forward to being of service to you again.<br />";


                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "</div>";
                                                cont = cont + "</body>";
                                                cont = cont + "</html>";
                                                
                                                if (hf_blno.Value != "")
                                                {

                                                    dtmail = objCust.getmailidforebooking(Convert.ToString(hf_blno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                                                    if (dtmail.Rows.Count > 0)
                                                    {
                                                        customerid = dtmail.Rows[0]["customerid"].ToString();
                                                        shipperidemailid = dtmail.Rows[0]["shipperidemailid"].ToString();
                                                        cosigneeidemailid = dtmail.Rows[0]["cosigneeidemailid"].ToString();
                                                        notifypartyidemailid = dtmail.Rows[0]["notifypartyidemailid"].ToString();
                                                    }
                                                    customermailid = customerid + ";" + shipperidemailid + ";" + cosigneeidemailid + ";" + notifypartyidemailid;

                                                }
                                                string sub11 = "Transhippment Arrived has been updated. Please find below details";
                                                Utility.SendMailnew("", customermailid, sub11, cont, "", "Msncl2021$", "");

                                            }
                                        }




                                    }
                                    if (ddlEvents.Text == "Transhipment Departured On")
                                    {
                                        da_obj_FIJobobj.UpdateFIEventstransdepart(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_blno.Value);

                                        if (hf_blno.Value != "")
                                        {
                                            dt1 = da_obj_FIJobobj.spgetevents(Convert.ToInt32(Session["LoginBranchid"].ToString()), hf_blno.Value, Session["StrTranType"].ToString());


                                            if (dt1.Rows.Count > 0)
                                            {
                                                cont = "";
                                                origin = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)).ToString("dd-MMM-yyyy");
                                                cont = "<html>";
                                                cont = cont + "<body style='padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<div style='width:1010px; margin:0px auto; padding:10px; border:1px solid #000;'>";
                                                cont = cont + "<div style='width:1010px;'>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Transhipment Departured Alert Mail to Consignee</label></div>";

                                                cont = cont + "<div style=' width:494px; color:#fff; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label style='color:#fff;'>LCL Import Booking Status</label></div>";



                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Message From " + Session["LoginDivisionName"].ToString() + "</label></div>";
                                                cont = cont + "<div style=' width:494px; color:#000; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";
                                                cont = cont + "<label>Date: " + origin + "</label></div>";  // txt_date.Text
                                                //if (dt1.Columns.Contains("bookingdate"))
                                                //{
                                                //    cont = cont + "<label>Date: " + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";  // txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<label>Date: " + "" + "</label></div>";  // txt_date.Text
                                                //}
                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Dear Sir/Madam,Alert Transhipment Departured has been updated for the Booking  # : " + dt1.Rows[0]["bookingno"].ToString() + " . Please find below details</label></div>";//txt_booking.Text

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'> BOOKING REFERENCE</label></div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Number : </div>";
                                                if (dt1.Columns.Contains("bookingno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["bookingno"].ToString() + "</label></div>";// txt_booking.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_booking.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Date : </div>";

                                                if (dt1.Columns.Contains("bookingdate"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";// txt_date.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Origin  : </div>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["POL"].ToString() + "</label></div>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_por.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Destination  : </div>";
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["POD"].ToString() + "</label></div>";//txt_fd.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";//txt_fd.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Number  : </div>";
                                                if (dt1.Columns.Contains("blno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["blno"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Date  : </div>";
                                                if (dt1.Columns.Contains("hbldate"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["hbldate"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Released  : </div>";
                                                if (dt1.Columns.Contains("doissueon"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["doissueon"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:990px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold;'>Customer Reference Number : </div>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Shipper</div>";
                                                cont = cont + "<div style='float:left; width:300px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'> ";
                                                if (dt1.Columns.Contains("shipper"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + dt1.Rows[0]["shipper"].ToString() + "</p>";//txt_shipper.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + "" + "</p>";//txt_shipper.Text
                                                }

                                                if (dt1.Columns.Contains("saddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["saddress"].ToString() + "</p>";// txtsaddress.Text
                                                }

                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "</p>";// txtsaddress.Text
                                                }
                                                cont = cont + "</div></div>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Consignee</div>";
                                                if (dt1.Columns.Contains("consignee"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["consignee"].ToString() + "</p>";// txt_consignee.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_consignee.Text
                                                }
                                                if (dt1.Columns.Contains("caddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["caddress"].ToString() + "<br />";// txtcaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "<br />";// txtcaddress.Text
                                                }
                                                cont = cont + "</p> </div>";
                                                cont = cont + "<div style='float:left; width:368px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:0px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:368px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'> Notify Party</div>";
                                                if (dt1.Columns.Contains("notifyparty"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["notifyparty"].ToString() + "</p>";// txt_notify.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_notify.Text
                                                }
                                                if (dt1.Columns.Contains("naddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["naddress"].ToString() + "</p>";// txtnaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txtnaddress.Text
                                                }
                                                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'></p></div></div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>  SHIPMENT DETAIL</label></div>";
                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Terms of Shipment:</div>";
                                                if (dt1.Columns.Contains("stype"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["stype"].ToString() + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Freight Terms : </div>";
                                                if (dt1.Columns.Contains("fstatus"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["fstatus"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Expiry Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:1010px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Carrier: </div>";
                                                if (dt1.Columns.Contains("CarrierName"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["CarrierName"].ToString() + "</label></div>"; // txt_customer.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>"; // txt_customer.Text
                                                }
                                                cont = cont + "</div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>CONNECTION DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<table width='1010' border='0' cellspacing='0' cellpadding='0' style='font-family:sans-serif, Geneva, sans-serif; color:#000; border-left:1px solid #000; border-right:1px solid #000; border-top:1px solid #000; border-bottom:0px solid #000; padding:0px 0px 0px 0px; margin:10px 0px 0px 0px; float:left;'>";
                                                cont = cont + " <tr><th style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Loading</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETD</th>";
                                                cont = cont + " <th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Discharge</th><th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETA</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Vessel</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'> Voyage No.</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Status</th>";
                                                cont = cont + "<th style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>Mode</th>";
                                                cont = cont + "</tr>";
                                                cont = cont + "<tr>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POL"].ToString() + "</td>";// txt_pol.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_pol.Text
                                                }
                                                if (dt1.Columns.Contains("etd"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["etd"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POD"].ToString() + "</td>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_por.Text
                                                }
                                                if (dt1.Columns.Contains("eta"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["eta"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("vesselname"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["vesselname"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("voyage"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["voyage"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>PLANNED</td>";

                                                cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "SEA" + "</td>";

                                                cont = cont + "</tr>";
                                                cont = cont + "</table>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> CARGO DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";



                                                cont = cont + "<div style='width:1010px; float:left; border-top:0px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:0px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:auto; color:#000; float:left; margin:0px; padding:5px; margin:0px; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:left;'>";
                                                cont = cont + "<label> Commodity :</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:auto; margin:0px 0px 0px 10px; padding:5px; text-align:left; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                if (dt1.Columns.Contains("cargotype"))
                                                {
                                                    cont = cont + "<label>" + dt1.Rows[0]["cargotype"].ToString() + "</label></div>";
                                                }
                                                else
                                                {

                                                }
                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>No of Packages:</div>";
                                                if (dt1.Columns.Contains("noofpkgs"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["noofpkgs"].ToString() + "</label></div>";//txt_noofpkg.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//txt_noofpkg.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Gross Weight : </div>";
                                                if (dt1.Columns.Contains("grweight"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["grweight"].ToString() + " </label></div>";// txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";// txt_wt.Text
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Volume  : </div>";
                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_approx_volume.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Chargeable Volume : </div>";

                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";


                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + " <div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Origin</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Origin Pickup Date :</div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Export Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Cargo Received Date : </div>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Loading Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + "  </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:990px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Shipped Onboard Date :" + "" + " </div>";
                                                // if (dt1.Columns.Contains("vesseldepar"))
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["vesseldepar"].ToString() + "</label></div>";// txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                //}

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label> </label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Destination</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Discharge Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> ETA  : " + dt1.Rows[0]["eta"].ToString() + "</div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Devanning CFS/Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> CAN Sent On : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>DO Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> DO Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Import Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Customs Reference Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1000px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; line-height:24px; padding:5px;'>";


                                                cont = cont + "";
                                                cont = cont + "THIS CONFIRMATION IS NOT VALID FOR PERSONAL EFFECTS, ANY MIS-DECLARATION WILL RESULT IN FINES / PENALTIES WHICH WILL BE TO YOUR ACCOUNT<br />";


                                                cont = cont + "Please note that Security Surcharge will be applicable at actuals.<br />";


                                                cont = cont + "Kindly contact the undersigned for further assistance<br />";


                                                cont = cont + "Thank you for using our service and, we look forward to being of service to you again.<br />";


                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "</div>";
                                                cont = cont + "</body>";
                                                cont = cont + "</html>";                                             

                                                if (hf_blno.Value != "")
                                                {

                                                    dtmail = objCust.getmailidforebooking(Convert.ToString(hf_blno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                                                    if (dtmail.Rows.Count > 0)
                                                    {
                                                        customerid = dtmail.Rows[0]["customerid"].ToString();
                                                        shipperidemailid = dtmail.Rows[0]["shipperidemailid"].ToString();
                                                        cosigneeidemailid = dtmail.Rows[0]["cosigneeidemailid"].ToString();
                                                        notifypartyidemailid = dtmail.Rows[0]["notifypartyidemailid"].ToString();
                                                    }
                                                    customermailid = customerid + ";" + shipperidemailid + ";" + cosigneeidemailid + ";" + notifypartyidemailid;

                                                }

                                                string sub11 = "Transhipment Departured has been updated. Please find below details";
                                                Utility.SendMailnew("", customermailid, sub11, cont, "", "Msncl2021$", "");                                             

                                            }
                                        }



                                    }

                                    if (ddlEvents.Text == "Vessel Arrived At POD On")
                                    {
                                        da_obj_FIJobobj.UpdateFIEventsvesselarrivepod(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_blno.Value);


                                        if (hf_blno.Value != "")
                                        {
                                            dt1 = da_obj_FIJobobj.spgetevents(Convert.ToInt32(Session["LoginBranchid"].ToString()), hf_blno.Value, Session["StrTranType"].ToString());


                                            if (dt1.Rows.Count > 0)
                                            {
                                                cont = "";
                                                origin = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)).ToString("dd-MMM-yyyy");
                                                cont = "<html>";
                                                cont = cont + "<body style='padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<div style='width:1010px; margin:0px auto; padding:10px; border:1px solid #000;'>";
                                                cont = cont + "<div style='width:1010px;'>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Vessel Arrived Alert Mail to Consignee</label></div>";

                                                cont = cont + "<div style=' width:494px; color:#fff; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label style='color:#fff;'>LCL Import Booking Status</label></div>";



                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Message From " + Session["LoginDivisionName"].ToString() + "</label></div>";
                                                cont = cont + "<div style=' width:494px; color:#000; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";
                                                cont = cont + "<label>Date: " + origin + "</label></div>";  // txt_date.Text
                                                //if (dt1.Columns.Contains("bookingdate"))
                                                //{
                                                //    cont = cont + "<label>Date: " + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";  // txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<label>Date: " + "" + "</label></div>";  // txt_date.Text
                                                //}
                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Dear Sir/Madam,Alert Vessel Arrived has been updated for the Booking  # : " + dt1.Rows[0]["bookingno"].ToString() + " . Please find below details</label></div>";//txt_booking.Text

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'> BOOKING REFERENCE</label></div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Number : </div>";
                                                if (dt1.Columns.Contains("bookingno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["bookingno"].ToString() + "</label></div>";// txt_booking.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_booking.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Date : </div>";

                                                if (dt1.Columns.Contains("bookingdate"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";// txt_date.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Origin  : </div>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["POL"].ToString() + "</label></div>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_por.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Destination  : </div>";
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["POD"].ToString() + "</label></div>";//txt_fd.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";//txt_fd.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Number  : </div>";
                                                if (dt1.Columns.Contains("blno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["blno"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Date  : </div>";
                                                if (dt1.Columns.Contains("hbldate"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["hbldate"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Released  : </div>";
                                                if (dt1.Columns.Contains("doissueon"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["doissueon"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:990px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold;'>Customer Reference Number : </div>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Shipper</div>";
                                                cont = cont + "<div style='float:left; width:300px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'> ";
                                                if (dt1.Columns.Contains("shipper"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + dt1.Rows[0]["shipper"].ToString() + "</p>";//txt_shipper.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + "" + "</p>";//txt_shipper.Text
                                                }

                                                if (dt1.Columns.Contains("saddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["saddress"].ToString() + "</p>";// txtsaddress.Text
                                                }

                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "</p>";// txtsaddress.Text
                                                }
                                                cont = cont + "</div></div>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Consignee</div>";
                                                if (dt1.Columns.Contains("consignee"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["consignee"].ToString() + "</p>";// txt_consignee.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_consignee.Text
                                                }
                                                if (dt1.Columns.Contains("caddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["caddress"].ToString() + "<br />";// txtcaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "<br />";// txtcaddress.Text
                                                }
                                                cont = cont + "</p> </div>";
                                                cont = cont + "<div style='float:left; width:368px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:0px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:368px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'> Notify Party</div>";
                                                if (dt1.Columns.Contains("notifyparty"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["notifyparty"].ToString() + "</p>";// txt_notify.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_notify.Text
                                                }
                                                if (dt1.Columns.Contains("naddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["naddress"].ToString() + "</p>";// txtnaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txtnaddress.Text
                                                }
                                                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'></p></div></div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>  SHIPMENT DETAIL</label></div>";
                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Terms of Shipment:</div>";
                                                if (dt1.Columns.Contains("stype"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["stype"].ToString() + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Freight Terms : </div>";
                                                if (dt1.Columns.Contains("fstatus"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["fstatus"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Expiry Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:1010px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Carrier: </div>";
                                                if (dt1.Columns.Contains("CarrierName"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["CarrierName"].ToString() + "</label></div>"; // txt_customer.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>"; // txt_customer.Text
                                                }
                                                cont = cont + "</div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>CONNECTION DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<table width='1010' border='0' cellspacing='0' cellpadding='0' style='font-family:sans-serif, Geneva, sans-serif; color:#000; border-left:1px solid #000; border-right:1px solid #000; border-top:1px solid #000; border-bottom:0px solid #000; padding:0px 0px 0px 0px; margin:10px 0px 0px 0px; float:left;'>";
                                                cont = cont + " <tr><th style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Loading</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETD</th>";
                                                cont = cont + " <th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Discharge</th><th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETA</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Vessel</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'> Voyage No.</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Status</th>";
                                                cont = cont + "<th style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>Mode</th>";
                                                cont = cont + "</tr>";
                                                cont = cont + "<tr>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POL"].ToString() + "</td>";// txt_pol.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_pol.Text
                                                }
                                                if (dt1.Columns.Contains("etd"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["etd"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POD"].ToString() + "</td>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_por.Text
                                                }
                                                if (dt1.Columns.Contains("eta"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["eta"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("vesselname"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["vesselname"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("voyage"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["voyage"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>PLANNED</td>";

                                                cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "SEA" + "</td>";

                                                cont = cont + "</tr>";
                                                cont = cont + "</table>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> CARGO DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";



                                                cont = cont + "<div style='width:1010px; float:left; border-top:0px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:0px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:auto; color:#000; float:left; margin:0px; padding:5px; margin:0px; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:left;'>";
                                                cont = cont + "<label> Commodity :</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:auto; margin:0px 0px 0px 10px; padding:5px; text-align:left; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                if (dt1.Columns.Contains("cargotype"))
                                                {
                                                    cont = cont + "<label>" + dt1.Rows[0]["cargotype"].ToString() + "</label></div>";
                                                }
                                                else
                                                {

                                                }
                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>No of Packages:</div>";
                                                if (dt1.Columns.Contains("noofpkgs"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["noofpkgs"].ToString() + "</label></div>";//txt_noofpkg.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//txt_noofpkg.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Gross Weight : </div>";
                                                if (dt1.Columns.Contains("grweight"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["grweight"].ToString() + " </label></div>";// txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";// txt_wt.Text
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Volume  : </div>";
                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_approx_volume.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Chargeable Volume : </div>";

                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";


                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + " <div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Origin</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Origin Pickup Date :</div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Export Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Cargo Received Date : </div>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Loading Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + "  </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:990px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Shipped Onboard Date :" + "" + " </div>";
                                                // if (dt1.Columns.Contains("vesseldepar"))
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["vesseldepar"].ToString() + "</label></div>";// txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                //}

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label> </label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Destination</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Discharge Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> ETA  : " + dt1.Rows[0]["eta"].ToString() + "</div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Devanning CFS/Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> CAN Sent On : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>DO Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> DO Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Import Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Customs Reference Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1000px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; line-height:24px; padding:5px;'>";


                                                cont = cont + "";
                                                cont = cont + "THIS CONFIRMATION IS NOT VALID FOR PERSONAL EFFECTS, ANY MIS-DECLARATION WILL RESULT IN FINES / PENALTIES WHICH WILL BE TO YOUR ACCOUNT<br />";


                                                cont = cont + "Please note that Security Surcharge will be applicable at actuals.<br />";


                                                cont = cont + "Kindly contact the undersigned for further assistance<br />";


                                                cont = cont + "Thank you for using our service and, we look forward to being of service to you again.<br />";


                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "</div>";
                                                cont = cont + "</body>";
                                                cont = cont + "</html>";
                                              

                                                if (hf_blno.Value != "")
                                                {

                                                    dtmail = objCust.getmailidforebooking(Convert.ToString(hf_blno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                                                    if (dtmail.Rows.Count > 0)
                                                    {
                                                        customerid = dtmail.Rows[0]["customerid"].ToString();
                                                        shipperidemailid = dtmail.Rows[0]["shipperidemailid"].ToString();
                                                        cosigneeidemailid = dtmail.Rows[0]["cosigneeidemailid"].ToString();
                                                        notifypartyidemailid = dtmail.Rows[0]["notifypartyidemailid"].ToString();
                                                    }
                                                    customermailid = customerid + ";" + shipperidemailid + ";" + cosigneeidemailid + ";" + notifypartyidemailid;
                                                }
                                                string sub11 = "Vessel Arrived has been updated. Please find below details";
                                                Utility.SendMailnew("", customermailid, sub11, cont, "", "Msncl2021$", "");                                               

                                            }
                                        }

                                    }
                                    
                                    if (ddlEvents.Text == "Destination CFS Arrived On")
                                    {
                                        da_obj_FIJobobj.UpdateFIEventsdesticfsarrival(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_blno.Value);
                                        if (hf_blno.Value != "")
                                        {
                                            dt1 = da_obj_FIJobobj.spgetevents(Convert.ToInt32(Session["LoginBranchid"].ToString()), hf_blno.Value, Session["StrTranType"].ToString());


                                            if (dt1.Rows.Count > 0)
                                            {
                                                cont = "";
                                                origin = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)).ToString("dd-MMM-yyyy");
                                                cont = "<html>";
                                                cont = cont + "<body style='padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<div style='width:1010px; margin:0px auto; padding:10px; border:1px solid #000;'>";
                                                cont = cont + "<div style='width:1010px;'>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Import Custom Clearance Alert Mail to Consignee</label></div>";

                                                cont = cont + "<div style=' width:494px; color:#fff; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label style='color:#fff;'>LCL Import Booking Status</label></div>";



                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Message From " + Session["LoginDivisionName"].ToString() + "</label></div>";
                                                cont = cont + "<div style=' width:494px; color:#000; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";
                                                cont = cont + "<label>Date: " + origin + "</label></div>";  // txt_date.Text

                                                //if (dt1.Columns.Contains("bookingdate"))
                                                //{
                                                //    cont = cont + "<label>Date: " + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";  // txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<label>Date: " + "" + "</label></div>";  // txt_date.Text
                                                //}
                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Dear Sir/Madam, Alert! Import Custom Clearance has been updated for the Booking  # : " + dt1.Rows[0]["bookingno"].ToString() + " . Please find below details</label></div>";//txt_booking.Text

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'> BOOKING REFERENCE</label></div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Number : </div>";
                                                if (dt1.Columns.Contains("bookingno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["bookingno"].ToString() + "</label></div>";// txt_booking.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_booking.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Date : </div>";

                                                if (dt1.Columns.Contains("bookingdate"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";// txt_date.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Origin  : </div>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["POL"].ToString() + "</label></div>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_por.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Destination  : </div>";
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["POD"].ToString() + "</label></div>";//txt_fd.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";//txt_fd.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Number  : </div>";
                                                if (dt1.Columns.Contains("blno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["blno"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Date  : </div>";
                                                if (dt1.Columns.Contains("hbldate"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["hbldate"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Released  : </div>";
                                                if (dt1.Columns.Contains("doissueon"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["doissueon"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:990px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold;'>Customer Reference Number : </div>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Shipper</div>";
                                                cont = cont + "<div style='float:left; width:300px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'> ";
                                                if (dt1.Columns.Contains("shipper"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + dt1.Rows[0]["shipper"].ToString() + "</p>";//txt_shipper.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + "" + "</p>";//txt_shipper.Text
                                                }

                                                if (dt1.Columns.Contains("saddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["saddress"].ToString() + "</p>";// txtsaddress.Text
                                                }

                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "</p>";// txtsaddress.Text
                                                }
                                                cont = cont + "</div></div>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Consignee</div>";
                                                if (dt1.Columns.Contains("consignee"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["consignee"].ToString() + "</p>";// txt_consignee.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_consignee.Text
                                                }
                                                if (dt1.Columns.Contains("caddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["caddress"].ToString() + "<br />";// txtcaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "<br />";// txtcaddress.Text
                                                }
                                                cont = cont + "</p> </div>";
                                                cont = cont + "<div style='float:left; width:368px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:0px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:368px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'> Notify Party</div>";
                                                if (dt1.Columns.Contains("notifyparty"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["notifyparty"].ToString() + "</p>";// txt_notify.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_notify.Text
                                                }
                                                if (dt1.Columns.Contains("naddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["naddress"].ToString() + "</p>";// txtnaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txtnaddress.Text
                                                }
                                                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'></p></div></div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>  SHIPMENT DETAIL</label></div>";
                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Terms of Shipment:</div>";
                                                if (dt1.Columns.Contains("stype"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["stype"].ToString() + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Freight Terms : </div>";
                                                if (dt1.Columns.Contains("fstatus"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["fstatus"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Expiry Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:1010px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Carrier: </div>";
                                                if (dt1.Columns.Contains("CarrierName"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["CarrierName"].ToString() + "</label></div>"; // txt_customer.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>"; // txt_customer.Text
                                                }
                                                cont = cont + "</div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>CONNECTION DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<table width='1010' border='0' cellspacing='0' cellpadding='0' style='font-family:sans-serif, Geneva, sans-serif; color:#000; border-left:1px solid #000; border-right:1px solid #000; border-top:1px solid #000; border-bottom:0px solid #000; padding:0px 0px 0px 0px; margin:10px 0px 0px 0px; float:left;'>";
                                                cont = cont + " <tr><th style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Loading</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETD</th>";
                                                cont = cont + " <th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Discharge</th><th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETA</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Vessel</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'> Voyage No.</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Status</th>";
                                                cont = cont + "<th style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>Mode</th>";
                                                cont = cont + "</tr>";
                                                cont = cont + "<tr>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POL"].ToString() + "</td>";// txt_pol.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_pol.Text
                                                }
                                                if (dt1.Columns.Contains("etd"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["etd"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POD"].ToString() + "</td>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_por.Text
                                                }
                                                if (dt1.Columns.Contains("eta"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["eta"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("vesselname"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["vesselname"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("voyage"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["voyage"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>PLANNED</td>";

                                                cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "SEA" + "</td>";

                                                cont = cont + "</tr>";
                                                cont = cont + "</table>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> CARGO DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";



                                                cont = cont + "<div style='width:1010px; float:left; border-top:0px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:0px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:auto; color:#000; float:left; margin:0px; padding:5px; margin:0px; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:left;'>";
                                                cont = cont + "<label> Commodity :</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:auto; margin:0px 0px 0px 10px; padding:5px; text-align:left; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                if (dt1.Columns.Contains("cargotype"))
                                                {
                                                    cont = cont + "<label>" + dt1.Rows[0]["cargotype"].ToString() + "</label></div>";
                                                }
                                                else
                                                {

                                                }
                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>No of Packages:</div>";
                                                if (dt1.Columns.Contains("noofpkgs"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["noofpkgs"].ToString() + "</label></div>";//txt_noofpkg.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//txt_noofpkg.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Gross Weight : </div>";
                                                if (dt1.Columns.Contains("grweight"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["grweight"].ToString() + " </label></div>";// txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";// txt_wt.Text
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Volume  : </div>";
                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_approx_volume.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Chargeable Volume : </div>";

                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";


                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + " <div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Origin</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Origin Pickup Date :</div>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Export Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Cargo Received Date : </div>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Loading Vessel/Voyage : " + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:990px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Shipped Onboard Date : </div>";


                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label> </label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Destination</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Discharge Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> ETA  :" + dt1.Rows[0]["eta"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Devanning CFS/Date : </div>";
                                                // if (dt1.Columns.Contains("cargodestuff"))
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["cargodestuff"].ToString() + "</label></div>";// txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                //}

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> CAN Sent On : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>DO Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> DO Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Import Customs Clearance Date :" + origin + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Customs Reference Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1000px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; line-height:24px; padding:5px;'>";


                                                cont = cont + "";
                                                cont = cont + "THIS CONFIRMATION IS NOT VALID FOR PERSONAL EFFECTS, ANY MIS-DECLARATION WILL RESULT IN FINES / PENALTIES WHICH WILL BE TO YOUR ACCOUNT<br />";


                                                cont = cont + "Please note that Security Surcharge will be applicable at actuals.<br />";


                                                cont = cont + "Kindly contact the undersigned for further assistance<br />";


                                                cont = cont + "Thank you for using our service and, we look forward to being of service to you again.<br />";


                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "</div>";
                                                cont = cont + "</body>";
                                                cont = cont + "</html>";

                                                if (hf_blno.Value != "")
                                                {

                                                    dtmail = objCust.getmailidforebooking(Convert.ToString(hf_blno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                                                    if (dtmail.Rows.Count > 0)
                                                    {
                                                        customerid = dtmail.Rows[0]["customerid"].ToString();
                                                        shipperidemailid = dtmail.Rows[0]["shipperidemailid"].ToString();
                                                        cosigneeidemailid = dtmail.Rows[0]["cosigneeidemailid"].ToString();
                                                        notifypartyidemailid = dtmail.Rows[0]["notifypartyidemailid"].ToString();
                                                    }
                                                    customermailid = customerid + ";" + shipperidemailid + ";" + cosigneeidemailid + ";" + notifypartyidemailid;

                                                }

                                                string sub11 = "Import Custom Clearance has been updated. Please find below details";

                                                Utility.SendMailnew("", customermailid, sub11, cont, "", "Msncl2021$", "");

                                               

                                            }
                                        }


                                    }
                                    if (ddlEvents.Text == "Cargo Destuffed On")
                                    {
                                        da_obj_FIJobobj.UpdateFIEventscargodestuff(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_blno.Value);
                                         if (hf_blno.Value != "")
                                        {
                                           dt1 = da_obj_FIJobobj.spgetevents(Convert.ToInt32(Session["LoginBranchid"].ToString()), hf_blno.Value, Session["StrTranType"].ToString());


                                            if (dt1.Rows.Count>0)
                                            {
                                                cont = "";
                                                origin = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)).ToString("dd-MMM-yyyy");
                                                cont = "<html>";
                                                cont = cont + "<body style='padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<div style='width:1010px; margin:0px auto; padding:10px; border:1px solid #000;'>";
                                                cont = cont + "<div style='width:1010px;'>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Devanning CFS Alert Mail to Consignee</label></div>";

                                                cont = cont + "<div style=' width:494px; color:#fff; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label style='color:#fff;'>LCL Import Booking Status</label></div>";



                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Message From " + Session["LoginDivisionName"].ToString() + "</label></div>";
                                                cont = cont + "<div style=' width:494px; color:#000; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";
                                                cont = cont + "<label>Date: " + origin + "</label></div>";  // txt_date.Text

                                                //if (dt1.Columns.Contains("bookingdate"))
                                                //{
                                                //    cont = cont + "<label>Date: " + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";  // txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<label>Date: " + "" + "</label></div>";  // txt_date.Text
                                                //}
                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Dear Sir/Madam,Alert!Devanning CFS has been updated for the  Booking  # : " + dt1.Rows[0]["bookingno"].ToString() +" . Please find below details</label></div>";//txt_booking.Text

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'> BOOKING REFERENCE</label></div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Number : </div>";
                                                if (dt1.Columns.Contains("bookingno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["bookingno"].ToString() + "</label></div>";// txt_booking.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_booking.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Date : </div>";

                                                if (dt1.Columns.Contains("bookingdate"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";// txt_date.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Origin  : </div>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["POL"].ToString() + "</label></div>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_por.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Destination  : </div>";
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["POD"].ToString() + "</label></div>";//txt_fd.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";//txt_fd.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Number  : </div>";
                                                if (dt1.Columns.Contains("blno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["blno"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Date  : </div>";
                                                if (dt1.Columns.Contains("hbldate"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["hbldate"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Released  : </div>";
                                                if (dt1.Columns.Contains("doissueon"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["doissueon"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:990px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold;'>Customer Reference Number : </div>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Shipper</div>";
                                                cont = cont + "<div style='float:left; width:300px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'> ";
                                                if (dt1.Columns.Contains("shipper"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + dt1.Rows[0]["shipper"].ToString() + "</p>";//txt_shipper.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + "" + "</p>";//txt_shipper.Text
                                                }

                                                if (dt1.Columns.Contains("saddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["saddress"].ToString() + "</p>";// txtsaddress.Text
                                                }

                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "</p>";// txtsaddress.Text
                                                }
                                                cont = cont + "</div></div>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Consignee</div>";
                                                if (dt1.Columns.Contains("consignee"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["consignee"].ToString() + "</p>";// txt_consignee.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_consignee.Text
                                                }
                                                if (dt1.Columns.Contains("caddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["caddress"].ToString() + "<br />";// txtcaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "<br />";// txtcaddress.Text
                                                }
                                                cont = cont + "</p> </div>";
                                                cont = cont + "<div style='float:left; width:368px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:0px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:368px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'> Notify Party</div>";
                                                if (dt1.Columns.Contains("notifyparty"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["notifyparty"].ToString() + "</p>";// txt_notify.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_notify.Text
                                                }
                                                if (dt1.Columns.Contains("naddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["naddress"].ToString() + "</p>";// txtnaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txtnaddress.Text
                                                }
                                                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'></p></div></div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>  SHIPMENT DETAIL</label></div>";
                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Terms of Shipment:</div>";
                                                if (dt1.Columns.Contains("stype"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["stype"].ToString() + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Freight Terms : </div>";
                                                if (dt1.Columns.Contains("fstatus"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["fstatus"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Expiry Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:1010px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Carrier: </div>";
                                                if (dt1.Columns.Contains("CarrierName"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["CarrierName"].ToString() + "</label></div>"; // txt_customer.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>"; // txt_customer.Text
                                                }
                                                cont = cont + "</div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>CONNECTION DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<table width='1010' border='0' cellspacing='0' cellpadding='0' style='font-family:sans-serif, Geneva, sans-serif; color:#000; border-left:1px solid #000; border-right:1px solid #000; border-top:1px solid #000; border-bottom:0px solid #000; padding:0px 0px 0px 0px; margin:10px 0px 0px 0px; float:left;'>";
                                                cont = cont + " <tr><th style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Loading</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETD</th>";
                                                cont = cont + " <th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Discharge</th><th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETA</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Vessel</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'> Voyage No.</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Status</th>";
                                                cont = cont + "<th style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>Mode</th>";
                                                cont = cont + "</tr>";
                                                cont = cont + "<tr>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POL"].ToString() + "</td>";// txt_pol.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_pol.Text
                                                }
                                                if (dt1.Columns.Contains("etd"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["etd"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POD"].ToString() + "</td>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_por.Text
                                                }
                                                if (dt1.Columns.Contains("eta"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["eta"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("vesselname"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["vesselname"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("voyage"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["voyage"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>PLANNED</td>";

                                                cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "SEA" + "</td>";

                                                cont = cont + "</tr>";
                                                cont = cont + "</table>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> CARGO DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";



                                                cont = cont + "<div style='width:1010px; float:left; border-top:0px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:0px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:auto; color:#000; float:left; margin:0px; padding:5px; margin:0px; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:left;'>";
                                                cont = cont + "<label> Commodity :</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:auto; margin:0px 0px 0px 10px; padding:5px; text-align:left; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                if (dt1.Columns.Contains("cargotype"))
                                                {
                                                    cont = cont + "<label>" + dt1.Rows[0]["cargotype"].ToString() + "</label></div>";
                                                }
                                                else
                                                {

                                                }
                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>No of Packages:</div>";
                                                if (dt1.Columns.Contains("noofpkgs"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["noofpkgs"].ToString() + "</label></div>";//txt_noofpkg.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//txt_noofpkg.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Gross Weight : </div>";
                                                if (dt1.Columns.Contains("grweight"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["grweight"].ToString() + " </label></div>";// txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";// txt_wt.Text
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Volume  : </div>";
                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_approx_volume.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Chargeable Volume : </div>";

                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_wt.Text
                                                }
                                                else

                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";


                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + " <div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Origin</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Origin Pickup Date :</div>";
                                                
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Export Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Cargo Received Date : </div>";
                                                 
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Loading Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + "  </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:990px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Shipped Onboard Date : </div>";
                                                

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label> </label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Destination</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Discharge Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> ETA  :" + dt1.Rows[0]["eta"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Devanning CFS/Date :"+origin+" </div>";
                                                // if (dt1.Columns.Contains("cargodestuff"))
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["cargodestuff"].ToString() + "</label></div>";// txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                //}

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> CAN Sent On : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>DO Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> DO Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Import Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Customs Reference Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1000px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; line-height:24px; padding:5px;'>";


                                                cont = cont + "";
                                                cont = cont + "THIS CONFIRMATION IS NOT VALID FOR PERSONAL EFFECTS, ANY MIS-DECLARATION WILL RESULT IN FINES / PENALTIES WHICH WILL BE TO YOUR ACCOUNT<br />";


                                                cont = cont + "Please note that Security Surcharge will be applicable at actuals.<br />";


                                                cont = cont + "Kindly contact the undersigned for further assistance<br />";


                                                cont = cont + "Thank you for using our service and, we look forward to being of service to you again.<br />";


                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "</div>";
                                                cont = cont + "</body>";
                                                cont = cont + "</html>";

                                                if (hf_blno.Value != "")
                                                {

                                                    dtmail = objCust.getmailidforebooking(Convert.ToString(hf_blno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                                                    if (dtmail.Rows.Count > 0)
                                                    {
                                                        customerid = dtmail.Rows[0]["customerid"].ToString();
                                                        shipperidemailid = dtmail.Rows[0]["shipperidemailid"].ToString();
                                                        cosigneeidemailid = dtmail.Rows[0]["cosigneeidemailid"].ToString();
                                                        notifypartyidemailid = dtmail.Rows[0]["notifypartyidemailid"].ToString();
                                                    }
                                                    customermailid = customerid + ";" + shipperidemailid + ";" + cosigneeidemailid + ";" + notifypartyidemailid;

                                                }

                                                string sub11 = "Devanning CFS has been updated. Please find below details";

                                                Utility.SendMailnew("", customermailid, sub11, cont, "", "Msncl2021$", "");

                                            }
                                        }

                                    }
                                    if (ddlEvents.Text == "Order Delivered On")
                                    {
                                      da_obj_FIJobobj.UpdateFIEventsdeliorderstatus(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_blno.Value);
                                         if (hf_blno.Value != "")
                                        {
                                           dt1 = da_obj_FIJobobj.spgetevents(Convert.ToInt32(Session["LoginBranchid"].ToString()), hf_blno.Value, Session["StrTranType"].ToString());


                                            if (dt1.Rows.Count>0)
                                            {
                                                cont = "";
                                                origin = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)).ToString("dd-MMM-yyyy");
                                                cont = "<html>";
                                                cont = cont + "<body style='padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<div style='width:1010px; margin:0px auto; padding:10px; border:1px solid #000;'>";
                                                cont = cont + "<div style='width:1010px;'>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Delivered Order Alert Mail to Consignee</label></div>";

                                                cont = cont + "<div style=' width:494px; color:#fff; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label style='color:#fff;'>LCL Import Booking Status</label></div>";



                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Message From " + Session["LoginDivisionName"].ToString() + "</label></div>";
                                                cont = cont + "<div style=' width:494px; color:#000; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label>Date: " + origin + "</label></div>";  // txt_date.Text
                                                //if (dt1.Columns.Contains("bookingdate"))
                                                //{
                                                //    cont = cont + "<label>Date: " + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";  // txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<label>Date: " + "" + "</label></div>";  // txt_date.Text
                                                //}
                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Dear Sir/Madam,Alert! DO date has been updated for the Booking  # : " + dt1.Rows[0]["bookingno"].ToString() +". Please find below details</label></div>";//txt_booking.Text

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'> BOOKING REFERENCE</label></div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Number : </div>";
                                                if (dt1.Columns.Contains("bookingno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["bookingno"].ToString() + "</label></div>";// txt_booking.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_booking.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Date : </div>";

                                                if (dt1.Columns.Contains("bookingdate"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";// txt_date.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Origin  : </div>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["POL"].ToString() + "</label></div>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_por.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Destination  : </div>";
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["POD"].ToString() + "</label></div>";//txt_fd.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";//txt_fd.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Number  : </div>";
                                                if (dt1.Columns.Contains("blno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["blno"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Date  : </div>";
                                                if (dt1.Columns.Contains("hbldate"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["hbldate"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Released  : </div>";
                                                if (dt1.Columns.Contains("doissueon"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["doissueon"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:990px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold;'>Customer Reference Number : </div>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Shipper</div>";
                                                cont = cont + "<div style='float:left; width:300px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'> ";
                                                if (dt1.Columns.Contains("shipper"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + dt1.Rows[0]["shipper"].ToString() + "</p>";//txt_shipper.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + "" + "</p>";//txt_shipper.Text
                                                }

                                                if (dt1.Columns.Contains("saddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["saddress"].ToString() + "</p>";// txtsaddress.Text
                                                }

                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "</p>";// txtsaddress.Text
                                                }
                                                cont = cont + "</div></div>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Consignee</div>";
                                                if (dt1.Columns.Contains("consignee"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["consignee"].ToString() + "</p>";// txt_consignee.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_consignee.Text
                                                }
                                                if (dt1.Columns.Contains("caddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["caddress"].ToString() + "<br />";// txtcaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "<br />";// txtcaddress.Text
                                                }
                                                cont = cont + "</p> </div>";
                                                cont = cont + "<div style='float:left; width:368px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:0px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:368px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'> Notify Party</div>";
                                                if (dt1.Columns.Contains("notifyparty"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["notifyparty"].ToString() + "</p>";// txt_notify.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_notify.Text
                                                }
                                                if (dt1.Columns.Contains("naddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["naddress"].ToString() + "</p>";// txtnaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txtnaddress.Text
                                                }
                                                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'></p></div></div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>  SHIPMENT DETAIL</label></div>";
                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Terms of Shipment:</div>";
                                                if (dt1.Columns.Contains("stype"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["stype"].ToString() + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Freight Terms : </div>";
                                                if (dt1.Columns.Contains("fstatus"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["fstatus"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Expiry Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:1010px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Carrier: </div>";
                                                if (dt1.Columns.Contains("CarrierName"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["CarrierName"].ToString() + "</label></div>"; // txt_customer.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>"; // txt_customer.Text
                                                }
                                                cont = cont + "</div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>CONNECTION DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<table width='1010' border='0' cellspacing='0' cellpadding='0' style='font-family:sans-serif, Geneva, sans-serif; color:#000; border-left:1px solid #000; border-right:1px solid #000; border-top:1px solid #000; border-bottom:0px solid #000; padding:0px 0px 0px 0px; margin:10px 0px 0px 0px; float:left;'>";
                                                cont = cont + " <tr><th style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Loading</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETD</th>";
                                                cont = cont + " <th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Discharge</th><th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETA</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Vessel</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'> Voyage No.</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Status</th>";
                                                cont = cont + "<th style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>Mode</th>";
                                                cont = cont + "</tr>";
                                                cont = cont + "<tr>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POL"].ToString() + "</td>";// txt_pol.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_pol.Text
                                                }
                                                if (dt1.Columns.Contains("etd"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["etd"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POD"].ToString() + "</td>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_por.Text
                                                }
                                                if (dt1.Columns.Contains("eta"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["eta"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("vesselname"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["vesselname"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("voyage"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["voyage"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>PLANNED</td>";

                                                cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "SEA" + "</td>";

                                                cont = cont + "</tr>";
                                                cont = cont + "</table>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> CARGO DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";



                                                cont = cont + "<div style='width:1010px; float:left; border-top:0px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:0px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:auto; color:#000; float:left; margin:0px; padding:5px; margin:0px; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:left;'>";
                                                cont = cont + "<label> Commodity :</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:auto; margin:0px 0px 0px 10px; padding:5px; text-align:left; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                if (dt1.Columns.Contains("cargotype"))
                                                {
                                                    cont = cont + "<label>" + dt1.Rows[0]["cargotype"].ToString() + "</label></div>";
                                                }
                                                else
                                                {

                                                }
                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>No of Packages:</div>";
                                                if (dt1.Columns.Contains("noofpkgs"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["noofpkgs"].ToString() + "</label></div>";//txt_noofpkg.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//txt_noofpkg.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Gross Weight : </div>";
                                                if (dt1.Columns.Contains("grweight"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["grweight"].ToString() + " </label></div>";// txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";// txt_wt.Text
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Volume  : </div>";
                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_approx_volume.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Chargeable Volume : </div>";

                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_wt.Text
                                                }
                                                else

                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";


                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + " <div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Origin</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Origin Pickup Date :</div>";
                                                
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Export Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Cargo Received Date : </div>";
                                                 
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Loading Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + "  </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:990px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Shipped Onboard Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label> </label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Destination</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Discharge Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "/" + dt1.Rows[0]["voyage"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> ETA  :" + dt1.Rows[0]["eta"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Devanning CFS/Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> CAN Sent On : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>DO Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> DO Date :"+origin+" </div>";
                                                //if (dt1.Columns.Contains("deliorderstatus"))
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["deliorderstatus"].ToString() + "</label></div>";// txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                //}
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Import Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Customs Reference Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1000px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; line-height:24px; padding:5px;'>";


                                                cont = cont + "";
                                                cont = cont + "THIS CONFIRMATION IS NOT VALID FOR PERSONAL EFFECTS, ANY MIS-DECLARATION WILL RESULT IN FINES / PENALTIES WHICH WILL BE TO YOUR ACCOUNT<br />";


                                                cont = cont + "Please note that Security Surcharge will be applicable at actuals.<br />";


                                                cont = cont + "Kindly contact the undersigned for further assistance<br />";


                                                cont = cont + "Thank you for using our service and, we look forward to being of service to you again.<br />";


                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "</div>";
                                                cont = cont + "</body>";
                                                cont = cont + "</html>";

                                                if (hf_blno.Value != "")
                                                {

                                                    dtmail = objCust.getmailidforebooking(Convert.ToString(hf_blno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                                                    if (dtmail.Rows.Count > 0)
                                                    {
                                                        customerid = dtmail.Rows[0]["customerid"].ToString();
                                                        shipperidemailid = dtmail.Rows[0]["shipperidemailid"].ToString();
                                                        cosigneeidemailid = dtmail.Rows[0]["cosigneeidemailid"].ToString();
                                                        notifypartyidemailid = dtmail.Rows[0]["notifypartyidemailid"].ToString();
                                                    }
                                                    customermailid = customerid + ";" + shipperidemailid + ";" + cosigneeidemailid + ";" + notifypartyidemailid;

                                                }

                                                string sub11 = "Delivered Order has been updated. Please find below details";

                                                Utility.SendMailnew("", customermailid, sub11, cont, "", "Msncl2021$", "");
              

                                            }
                                        }
                                    }
                                    if (ddlEvents.Text == "Cargo Delivered On")
                                    {
                                      da_obj_FIJobobj.UpdateFIEventscargodeli(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_blno.Value);
                                        if (hf_blno.Value != "")
                                        {
                                           dt1 = da_obj_FIJobobj.spgetevents(Convert.ToInt32(Session["LoginBranchid"].ToString()), hf_blno.Value, Session["StrTranType"].ToString());


                                            if (dt1.Rows.Count>0)
                                            {
                                                cont = "";
                                                origin = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)).ToString("dd-MMM-yyyy");

                                                cont = "<html>";
                                                cont = cont + "<body style='padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<div style='width:1010px; margin:0px auto; padding:10px; border:1px solid #000;'>";
                                                cont = cont + "<div style='width:1010px;'>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Cargo Delivered Alert Mail to Consignee</label></div>";

                                                cont = cont + "<div style=' width:494px; color:#fff; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label style='color:#fff;'>LCL Import Booking Status</label></div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Message From " + Session["LoginDivisionName"].ToString() + "</label></div>";
                                                cont = cont + "<div style=' width:494px; color:#000; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label>Date: " + origin + "</label></div>";  // txt_date.Text
                                                //if (dt1.Columns.Contains("bookingdate"))
                                                //{
                                                //    cont = cont + "<label>Date: " + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";  // txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<label>Date: " + "" + "</label></div>";  // txt_date.Text
                                                //}
                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Dear Sir/Madam,Alert!Cargo received date has been updated for the Booking  # : " + dt1.Rows[0]["bookingno"].ToString() +" . Please find below details</label></div>";//txt_booking.Text

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'> BOOKING REFERENCE</label></div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Number : </div>";
                                                if (dt1.Columns.Contains("bookingno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["bookingno"].ToString() + "</label></div>";// txt_booking.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_booking.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Date : </div>";

                                                if (dt1.Columns.Contains("bookingdate"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";// txt_date.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Origin  : </div>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["POL"].ToString() + "</label></div>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_por.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Destination  : </div>";
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["POD"].ToString() + "</label></div>";//txt_fd.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";//txt_fd.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Number  : </div>";
                                                if (dt1.Columns.Contains("blno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["blno"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Date  : </div>";
                                                if (dt1.Columns.Contains("hbldate"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["hbldate"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Released  : </div>";
                                                if (dt1.Columns.Contains("doissueon"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["doissueon"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:990px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold;'>Customer Reference Number : </div>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Shipper</div>";
                                                cont = cont + "<div style='float:left; width:300px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'> ";
                                                if (dt1.Columns.Contains("shipper"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + dt1.Rows[0]["shipper"].ToString() + "</p>";//txt_shipper.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + "" + "</p>";//txt_shipper.Text
                                                }

                                                if (dt1.Columns.Contains("saddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["saddress"].ToString() + "</p>";// txtsaddress.Text
                                                }

                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "</p>";// txtsaddress.Text
                                                }
                                                cont = cont + "</div></div>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Consignee</div>";
                                                if (dt1.Columns.Contains("consignee"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["consignee"].ToString() + "</p>";// txt_consignee.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_consignee.Text
                                                }
                                                if (dt1.Columns.Contains("caddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["caddress"].ToString() + "<br />";// txtcaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "<br />";// txtcaddress.Text
                                                }
                                                cont = cont + "</p> </div>";
                                                cont = cont + "<div style='float:left; width:368px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:0px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:368px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'> Notify Party</div>";
                                                if (dt1.Columns.Contains("notifyparty"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["notifyparty"].ToString() + "</p>";// txt_notify.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_notify.Text
                                                }
                                                if (dt1.Columns.Contains("naddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["naddress"].ToString() + "</p>";// txtnaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txtnaddress.Text
                                                }
                                                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'></p></div></div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>  SHIPMENT DETAIL</label></div>";
                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Terms of Shipment:</div>";
                                                if (dt1.Columns.Contains("stype"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["stype"].ToString() + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Freight Terms : </div>";
                                                if (dt1.Columns.Contains("fstatus"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["fstatus"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Expiry Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:1010px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Carrier: </div>";
                                                if (dt1.Columns.Contains("CarrierName"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["CarrierName"].ToString() + "</label></div>"; // txt_customer.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>"; // txt_customer.Text
                                                }
                                                cont = cont + "</div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>CONNECTION DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<table width='1010' border='0' cellspacing='0' cellpadding='0' style='font-family:sans-serif, Geneva, sans-serif; color:#000; border-left:1px solid #000; border-right:1px solid #000; border-top:1px solid #000; border-bottom:0px solid #000; padding:0px 0px 0px 0px; margin:10px 0px 0px 0px; float:left;'>";
                                                cont = cont + " <tr><th style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Loading</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETD</th>";
                                                cont = cont + " <th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Discharge</th><th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETA</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Vessel</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'> Voyage No.</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Status</th>";
                                                cont = cont + "<th style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>Mode</th>";
                                                cont = cont + "</tr>";
                                                cont = cont + "<tr>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POL"].ToString() + "</td>";// txt_pol.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_pol.Text
                                                }
                                                if (dt1.Columns.Contains("etd"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["etd"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POD"].ToString() + "</td>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_por.Text
                                                }
                                                if (dt1.Columns.Contains("eta"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["eta"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("vesselname"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["vesselname"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("voyage"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["voyage"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>PLANNED</td>";

                                                cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "SEA" + "</td>";

                                                cont = cont + "</tr>";
                                                cont = cont + "</table>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> CARGO DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";



                                                cont = cont + "<div style='width:1010px; float:left; border-top:0px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:0px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:auto; color:#000; float:left; margin:0px; padding:5px; margin:0px; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:left;'>";
                                                cont = cont + "<label> Commodity :</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:auto; margin:0px 0px 0px 10px; padding:5px; text-align:left; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                if (dt1.Columns.Contains("cargotype"))
                                                {
                                                    cont = cont + "<label>" + dt1.Rows[0]["cargotype"].ToString() + "</label></div>";
                                                }
                                                else
                                                {

                                                }
                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>No of Packages:</div>";
                                                if (dt1.Columns.Contains("noofpkgs"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["noofpkgs"].ToString() + "</label></div>";//txt_noofpkg.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//txt_noofpkg.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Gross Weight : </div>";
                                                if (dt1.Columns.Contains("grweight"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["grweight"].ToString() + " </label></div>";// txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";// txt_wt.Text
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Volume  : </div>";
                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_approx_volume.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Chargeable Volume : </div>";

                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_wt.Text
                                                }
                                                else

                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";


                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + " <div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Origin</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Origin Pickup Date :</div>";
                                                
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Export Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Cargo Received Date :"+origin+" </div>";
                                                //  if (dt1.Columns.Contains("cargodeli"))
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["cargodeli"].ToString() + "</label></div>";// txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                //}
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Loading Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "" + dt1.Rows[0]["voyage"].ToString() + "  </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:990px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Shipped Onboard Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label> </label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Destination</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Discharge Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "" + dt1.Rows[0]["voyage"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> ETA  :" + dt1.Rows[0]["eta"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Devanning CFS/Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> CAN Sent On : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>DO Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> DO Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Import Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Customs Reference Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1000px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; line-height:24px; padding:5px;'>";


                                                cont = cont + "";
                                                cont = cont + "THIS CONFIRMATION IS NOT VALID FOR PERSONAL EFFECTS, ANY MIS-DECLARATION WILL RESULT IN FINES / PENALTIES WHICH WILL BE TO YOUR ACCOUNT<br />";


                                                cont = cont + "Please note that Security Surcharge will be applicable at actuals.<br />";


                                                cont = cont + "Kindly contact the undersigned for further assistance<br />";


                                                cont = cont + "Thank you for using our service and, we look forward to being of service to you again.<br />";


                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "</div>";
                                                cont = cont + "</body>";
                                                cont = cont + "</html>";
                                                if (hf_blno.Value != "")
                                                {

                                                    dtmail = objCust.getmailidforebooking(Convert.ToString(hf_blno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                                                    if (dtmail.Rows.Count > 0)
                                                    {
                                                        customerid = dtmail.Rows[0]["customerid"].ToString();
                                                        shipperidemailid = dtmail.Rows[0]["shipperidemailid"].ToString();
                                                        cosigneeidemailid = dtmail.Rows[0]["cosigneeidemailid"].ToString();
                                                        notifypartyidemailid = dtmail.Rows[0]["notifypartyidemailid"].ToString();
                                                    }
                                                    customermailid = customerid + ";" + shipperidemailid + ";" + cosigneeidemailid + ";" + notifypartyidemailid;

                                                }

                                                string sub11 = "Cargo Delivered has been updated. Please find below details";

                                                Utility.SendMailnew("", customermailid, sub11, cont, "", "Msncl2021$", "");
              

              

                                            }
                                        }

                                    }

                                    if (ddlEvents.Text == "Empty Container Returned On")
                                    {
                                        da_obj_FIJobobj.UpdateFIEventsempcontreturn(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_blno.Value);

                                        if (hf_blno.Value != "")
                                        {
                                            dt1 = da_obj_FIJobobj.spgetevents(Convert.ToInt32(Session["LoginBranchid"].ToString()), hf_blno.Value, Session["StrTranType"].ToString());


                                            if (dt1.Rows.Count > 0)
                                            {
                                                cont = "";
                                                origin = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)).ToString("dd-MMM-yyyy");

                                                cont = "<html>";
                                                cont = cont + "<body style='padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<div style='width:1010px; margin:0px auto; padding:10px; border:1px solid #000;'>";
                                                cont = cont + "<div style='width:1010px;'>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Empty Container Returned Alert Mail to Consignee</label></div>";

                                                cont = cont + "<div style=' width:494px; color:#fff; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label style='color:#fff;'>LCL Import Booking Status</label></div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>Message From " + Session["LoginDivisionName"].ToString() + "</label></div>";
                                                cont = cont + "<div style=' width:494px; color:#000; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";

                                                cont = cont + "<label>Date: " + origin + "</label></div>";  // txt_date.Text
                                                //if (dt1.Columns.Contains("bookingdate"))
                                                //{
                                                //    cont = cont + "<label>Date: " + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";  // txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<label>Date: " + "" + "</label></div>";  // txt_date.Text
                                                //}
                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Dear Sir/Madam,Alert!Empty Container Returned date has been updated for the Booking  # : " + dt1.Rows[0]["bookingno"].ToString() + " . Please find below details</label></div>";//txt_booking.Text

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:990px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'> BOOKING REFERENCE</label></div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Number : </div>";
                                                if (dt1.Columns.Contains("bookingno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["bookingno"].ToString() + "</label></div>";// txt_booking.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_booking.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Date : </div>";

                                                if (dt1.Columns.Contains("bookingdate"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["bookingdate"].ToString() + "</label></div>";// txt_date.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Origin  : </div>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["POL"].ToString() + "</label></div>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "" + "</label></div>";// txt_por.Text
                                                }
                                                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Destination  : </div>";
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["POD"].ToString() + "</label></div>";//txt_fd.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";//txt_fd.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Number  : </div>";
                                                if (dt1.Columns.Contains("blno"))
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["blno"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }
                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Date  : </div>";
                                                if (dt1.Columns.Contains("hbldate"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + dt1.Rows[0]["hbldate"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Released  : </div>";
                                                if (dt1.Columns.Contains("doissueon"))
                                                {

                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["doissueon"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "&nbsp;" + "</label></div>";
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style='float:left; width:990px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold;'>Customer Reference Number : </div>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Shipper</div>";
                                                cont = cont + "<div style='float:left; width:300px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'> ";
                                                if (dt1.Columns.Contains("shipper"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + dt1.Rows[0]["shipper"].ToString() + "</p>";//txt_shipper.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + "" + "</p>";//txt_shipper.Text
                                                }

                                                if (dt1.Columns.Contains("saddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["saddress"].ToString() + "</p>";// txtsaddress.Text
                                                }

                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "</p>";// txtsaddress.Text
                                                }
                                                cont = cont + "</div></div>";

                                                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Consignee</div>";
                                                if (dt1.Columns.Contains("consignee"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["consignee"].ToString() + "</p>";// txt_consignee.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_consignee.Text
                                                }
                                                if (dt1.Columns.Contains("caddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + dt1.Rows[0]["caddress"].ToString() + "<br />";// txtcaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + "" + "<br />";// txtcaddress.Text
                                                }
                                                cont = cont + "</p> </div>";
                                                cont = cont + "<div style='float:left; width:368px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:0px solid #000; min-height:145px;'>";
                                                cont = cont + "<div style='float:left; width:368px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'> Notify Party</div>";
                                                if (dt1.Columns.Contains("notifyparty"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["notifyparty"].ToString() + "</p>";// txt_notify.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txt_notify.Text
                                                }
                                                if (dt1.Columns.Contains("naddress"))
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + dt1.Rows[0]["naddress"].ToString() + "</p>";// txtnaddress.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + "" + "</p>";// txtnaddress.Text
                                                }
                                                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'></p></div></div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>  SHIPMENT DETAIL</label></div>";
                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Terms of Shipment:</div>";
                                                if (dt1.Columns.Contains("stype"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["stype"].ToString() + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//ddl_type.SelectedItem.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Freight Terms : </div>";
                                                if (dt1.Columns.Contains("fstatus"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["fstatus"].ToString() + "</label></div>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";
                                                }
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>LC. Expiry Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:1010px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Carrier: </div>";
                                                if (dt1.Columns.Contains("CarrierName"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["CarrierName"].ToString() + "</label></div>"; // txt_customer.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>"; // txt_customer.Text
                                                }
                                                cont = cont + "</div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label style='color:#fff;'>CONNECTION DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<table width='1010' border='0' cellspacing='0' cellpadding='0' style='font-family:sans-serif, Geneva, sans-serif; color:#000; border-left:1px solid #000; border-right:1px solid #000; border-top:1px solid #000; border-bottom:0px solid #000; padding:0px 0px 0px 0px; margin:10px 0px 0px 0px; float:left;'>";
                                                cont = cont + " <tr><th style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Loading</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETD</th>";
                                                cont = cont + " <th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Port of Discharge</th><th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>ETA</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Vessel</th>";
                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'> Voyage No.</th>";

                                                cont = cont + "<th  style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>Status</th>";
                                                cont = cont + "<th style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>Mode</th>";
                                                cont = cont + "</tr>";
                                                cont = cont + "<tr>";
                                                if (dt1.Columns.Contains("POL"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POL"].ToString() + "</td>";// txt_pol.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_pol.Text
                                                }
                                                if (dt1.Columns.Contains("etd"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["etd"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("POD"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["POD"].ToString() + "</td>";// txt_por.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";// txt_por.Text
                                                }
                                                if (dt1.Columns.Contains("eta"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["eta"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("vesselname"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["vesselname"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                if (dt1.Columns.Contains("voyage"))
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + dt1.Rows[0]["voyage"].ToString() + "</td>";
                                                }
                                                else
                                                {
                                                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                                                }
                                                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>PLANNED</td>";

                                                cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "SEA" + "</td>";

                                                cont = cont + "</tr>";
                                                cont = cont + "</table>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> CARGO DETAIL</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div></div>";



                                                cont = cont + "<div style='width:1010px; float:left; border-top:0px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:0px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:auto; color:#000; float:left; margin:0px; padding:5px; margin:0px; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:left;'>";
                                                cont = cont + "<label> Commodity :</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='float:left; width:auto; margin:0px 0px 0px 10px; padding:5px; text-align:left; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                if (dt1.Columns.Contains("cargotype"))
                                                {
                                                    cont = cont + "<label>" + dt1.Rows[0]["cargotype"].ToString() + "</label></div>";
                                                }
                                                else
                                                {

                                                }
                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>No of Packages:</div>";
                                                if (dt1.Columns.Contains("noofpkgs"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["noofpkgs"].ToString() + "</label></div>";//txt_noofpkg.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";//txt_noofpkg.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Gross Weight : </div>";
                                                if (dt1.Columns.Contains("grweight"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["grweight"].ToString() + " </label></div>";// txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";// txt_wt.Text
                                                }

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Volume  : </div>";
                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_approx_volume.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Chargeable Volume : </div>";

                                                if (dt1.Columns.Contains("cbm"))
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + dt1.Rows[0]["cbm"].ToString() + " </label></div>";//txt_wt.Text
                                                }
                                                else
                                                {
                                                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + " </label></div>";//txt_wt.Text
                                                }
                                                cont = cont + "</div>";


                                                cont = cont + "<div style='clear:both;'></div></div>";


                                                cont = cont + " <div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Origin</label>";
                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";



                                                cont = cont + "</div>";
                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Origin Pickup Date :</div>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Export Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Cargo Received Date :" + "" + " </div>";
                                                //  if (dt1.Columns.Contains("cargodeli"))
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + dt1.Rows[0]["cargodeli"].ToString() + "</label></div>";// txt_date.Text
                                                //}
                                                //else
                                                //{
                                                //    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "" + "</label></div>";// txt_date.Text
                                                //}
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Loading Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "" + dt1.Rows[0]["voyage"].ToString() + "  </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:990px; border-right:0px solid #000; border-top:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Shipped Onboard Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label> </label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-top:1px solid #000; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; margin:10px 0px 0px 0px;'>";
                                                cont = cont + "<div style=' width:986px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                                                cont = cont + "<label> Cargo Status at Destination</label>";
                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Discharge Vessel/Voyage :" + dt1.Rows[0]["vesselname"].ToString() + "" + dt1.Rows[0]["voyage"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> ETA  :" + dt1.Rows[0]["eta"].ToString() + " </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Devanning CFS/Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> CAN Sent On : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>DO Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> DO Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "<div style=' width:495px; border-right:1px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Import Customs Clearance Date : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Customs Reference Number : </div>";
                                                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label></label></div>";

                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";

                                                cont = cont + "<div style='width:1000px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000; line-height:24px; padding:5px;'>";


                                                cont = cont + "";
                                                cont = cont + "THIS CONFIRMATION IS NOT VALID FOR PERSONAL EFFECTS, ANY MIS-DECLARATION WILL RESULT IN FINES / PENALTIES WHICH WILL BE TO YOUR ACCOUNT<br />";


                                                cont = cont + "Please note that Security Surcharge will be applicable at actuals.<br />";


                                                cont = cont + "Kindly contact the undersigned for further assistance<br />";


                                                cont = cont + "Thank you for using our service and, we look forward to being of service to you again.<br />";


                                                cont = cont + "</div>";
                                                cont = cont + "<div style='clear:both;'></div>";

                                                cont = cont + "</div>";



                                                cont = cont + "<div style='clear:both;'></div>";
                                                cont = cont + "</div>";
                                                cont = cont + "</body>";
                                                cont = cont + "</html>";
                                                if (hf_blno.Value != "")
                                                {

                                                    dtmail = objCust.getmailidforebooking(Convert.ToString(hf_blno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                                                    if (dtmail.Rows.Count > 0)
                                                    {
                                                        customerid = dtmail.Rows[0]["customerid"].ToString();
                                                        shipperidemailid = dtmail.Rows[0]["shipperidemailid"].ToString();
                                                        cosigneeidemailid = dtmail.Rows[0]["cosigneeidemailid"].ToString();
                                                        notifypartyidemailid = dtmail.Rows[0]["notifypartyidemailid"].ToString();
                                                    }
                                                    customermailid = customerid + ";" + shipperidemailid + ";" + cosigneeidemailid + ";" + notifypartyidemailid;

                                                }

                                                string sub11 = "Empty Container Returned has been updated. Please find below details";

                                                Utility.SendMailnew("", customermailid, sub11, cont, "", "Msncl2021$", "");




                                            }
                                        }

                                    }


                                    //if (ddlEvents.Text == "Final invoice")
                                    //{
                                    //    da_obj_FIJobobj.UpdatechEventfin(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_blno.Value);

                                    //}
                                    //if (ddlEvents.Text == "Original Documents Send On")
                                    //{
                                    //    da_obj_FIJobobj.UpdatechEventoridoc(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_docno.Value);

                                    //}
                                    //if (ddlEvents.Text == "ExBond Boe Filed On")
                                    //{
                                    //    da_obj_FIJobobj.UpdatechEventexbond(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_docno.Value);

                                    //}
                                    //if (ddlEvents.Text == "Cargo Delivery")
                                    //{
                                    //    da_obj_FIJobobj.UpdatechEventcardeli(Convert.ToInt32(hf_jobno.Value), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), hf_docno.Value);

                                    //}


                                   

                                }


                               /* if (Session["StrTranType"].ToString() == "FI")
                                {
                                    da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1749, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), hf_jobno.Value + "-" + Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate)) + "FI" + "-" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " BL#:" + hf_blno.Value + " Upd");
                                }*/
                                
                                blerr = true;
                            }
                            
                        }
                    }


                    if (blerr == true)
                    {
                        blerr = false;
                        {

                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Details Updated');", true);
                            ddlEvents_SelectedIndexChanged(sender, e);

                        }

                    }
               
                

               
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            grd.DataSource = (DataTable)ViewState["Dtnewvalue"];
            grd.DataBind();
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
            for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            //if (ddlEvents.Text == "Cargo Pick Up")
            //{
            //    grdStuff.DataSource = new DataTable();
            //    grdStuff.DataBind();
            //    btn_Cancel.Text = "Back";
            //    txtjob.Text="";
            //    txtContainer.Text = "";
            //    txtsize.Text = "";
            //    txtSeal.Text = "";
            //    txtEta.Text = "";
            //    txtdestuff.Text = "";
            //}
            if (btn_Cancel.ToolTip == "Cancel")
            {
                JobInput.Text = "";
                grd.DataSource = new DataTable();
                grd.DataBind();
                grdStuff.DataSource = new DataTable();
                grdStuff.DataBind();
                grdStuff.Visible = false;
                btn_Cancel.Text = "Back";
                btn_Cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                txtCfs.Text = "";
                txtjob.Text = "";
                txtContainer.Text = "";
                txtsize.Text = "";
                txtSeal.Text = "";
                txtjob.Visible = false;
                txtContainer.Visible = false;
                txtsize.Visible = false;
                txtSeal.Visible = false;
                txtEta.Visible = false;
                txtdestuff.Visible = false;
                btnAdd.Visible = false;
                ddlEvents.SelectedValue = "0";
                txtCargopickedon.Visible = false;
                txtCfs.Visible = false;
                GridView1.DataSource = new DataTable();
                GridView1.DataBind();
                hf_jobno.Value = "0";
                hf_docno.Value = "0";

            }
            else
            {
               // this.Response.End();

                if (Session["home"] != null)
                {
                   // if (Session["home"].ToString() == "CS")
                   // {
                        if (Session["StrTranType"] != null)
                        {
                            if (Session["StrTranType"].ToString() == "FI")
                            {
                                Response.Redirect("../Home/OICSHome.aspx");
                            }
                            //else if (Session["StrTranType"].ToString() == "AI")
                            //{
                            //    Response.Redirect("../Home/AICSHome.aspx");
                            //}


                        }
                    //}
                }
                else
                {
                    this.Response.End();
                }
            }
        }

        protected void ddlEvents_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Session["StrTranType"].ToString() == "FI")
            {
                if (ddlEvents.Text == "Booked On")
                {
                    txtjob.Text = "";
                    grd.Visible = true;

                    Dt_new = da_obj_FIJobobj.GetPA2AccDtsFI("bookings", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                    grd.DataSource = Dt_new;
                    ViewState["Dtnewvalue"] = Dt_new;
                    grd.DataBind();
                    btn_update.Visible = true;
                    btn_Cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                else if (ddlEvents.Text == "Origin On")
                {
                    txtjob.Text = "";
                    grd.Visible = true;

                    Dt_new = da_obj_FIJobobj.GetPA2AccDtsFI("origin", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                    grd.DataSource = Dt_new;
                    ViewState["Dtnewvalue"] = Dt_new;
                    grd.DataBind();
                    btn_update.Visible = true;
                    btn_Cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }

                else if (ddlEvents.Text == "Draft Confirmed On")
                {
                    txtjob.Text = "";
                    grd.Visible = true;
                    Dt_new = da_obj_FIJobobj.GetPA2AccDtsFI("draft", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                    grd.DataSource = Dt_new;
                    ViewState["Dtnewvalue"] = Dt_new;
                    grd.DataBind();
                    btn_Cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }

                else if (ddlEvents.Text == "Vessel Departured On")
                {
                    txtjob.Text = "";
                    grd.Visible = true;
                    Dt_new = da_obj_FIJobobj.GetPA2AccDtsFI("vessel", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                    grd.DataSource = Dt_new;
                    ViewState["Dtnewvalue"] = Dt_new;
                    grd.DataBind();
                    btn_Cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }

                else if (ddlEvents.Text == "Prealert Sent On")
                {
                    txtjob.Text = "";
                    grd.Visible = true;
                    Dt_new = da_obj_FIJobobj.GetPA2AccDtsFI("prealert", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                    grd.DataSource = Dt_new;
                    ViewState["Dtnewvalue"] = Dt_new;
                    grd.DataBind();
                    btn_Cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }

                else if (ddlEvents.Text == "Transhippment arrived On")
                {
                    txtjob.Text = "";
                    grd.Visible = true;
                    Dt_new = da_obj_FIJobobj.GetPA2AccDtsFI("trans", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                    grd.DataSource = Dt_new;
                    ViewState["Dtnewvalue"] = Dt_new;
                    grd.DataBind();
                    btn_Cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }


                else if (ddlEvents.Text == "Transhipment Departured On")
                {
                    txtjob.Text = "";
                    grd.Visible = true;
                    Dt_new = da_obj_FIJobobj.GetPA2AccDtsFI("tdepart", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                    grd.DataSource = Dt_new;
                    ViewState["Dtnewvalue"] = Dt_new;
                    grd.DataBind();
                    btn_Cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }

                else if (ddlEvents.Text == "Vessel Arrived At POD On")
                {
                    txtjob.Text = "";
                    grd.Visible = true;
                    Dt_new = da_obj_FIJobobj.GetPA2AccDtsFI("pod", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                    grd.DataSource = Dt_new;
                    ViewState["Dtnewvalue"] = Dt_new;
                    grd.DataBind();
                    btn_Cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                else if (ddlEvents.Text == "Destination CFS Arrived On")
                {
                    txtjob.Text = "";
                    grd.Visible = true;
                    Dt_new = da_obj_FIJobobj.GetPA2AccDtsFI("desti", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                    grd.DataSource = Dt_new;
                    ViewState["Dtnewvalue"] = Dt_new;
                    grd.DataBind();
                    btn_Cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }

                else if (ddlEvents.Text == "Cargo Destuffed On")
                {
                    txtjob.Text = "";
                    grd.Visible = true;
                    Dt_new = da_obj_FIJobobj.GetPA2AccDtsFI("destuff", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                    grd.DataSource = Dt_new;
                    ViewState["Dtnewvalue"] = Dt_new;
                    grd.DataBind();
                    btn_Cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }


                else if (ddlEvents.Text == "Order Delivered On")
                {
                    txtjob.Text = "";
                    grd.Visible = true;
                    Dt_new = da_obj_FIJobobj.GetPA2AccDtsFI("deliorder", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                    grd.DataSource = Dt_new;
                    ViewState["Dtnewvalue"] = Dt_new;
                    grd.DataBind();
                    btn_Cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                else if (ddlEvents.Text == "Cargo Delivered On")
                {
                    txtjob.Text = "";
                    grd.Visible = true;
                    Dt_new = da_obj_FIJobobj.GetPA2AccDtsFI("cargodeli", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                    grd.DataSource = Dt_new;
                    ViewState["Dtnewvalue"] = Dt_new;
                    grd.DataBind();
                    btn_Cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }

                else if (ddlEvents.Text == "Empty Container Returned On")
                {
                    txtjob.Text = "";
                    grd.Visible = true;
                    Dt_new = da_obj_FIJobobj.GetPA2AccDtsFI("empty", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                    grd.DataSource = Dt_new;
                    ViewState["Dtnewvalue"] = Dt_new;
                    grd.DataBind();
                    btn_Cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                //else if (ddlEvents.Text == "Vendor invoice")
                //{
                //    txtjob.Text = "";
                //    grd.Visible = true;
                //    Dt_new = da_obj_FIJobobj.GetPA2AccDtsCH("vendorinv", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                //    grd.DataSource = Dt_new;
                //    ViewState["Dtnewvalue"] = Dt_new;
                //    grd.DataBind();
                //    btn_Cancel.ToolTip = "Cancel";
                //    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                //}

                //else if (ddlEvents.Text == "Final invoice")
                //{
                //    txtjob.Text = "";
                //    grd.Visible = true;
                //    Dt_new = da_obj_FIJobobj.GetPA2AccDtsCH("finalinv", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                //    grd.DataSource = Dt_new;
                //    ViewState["Dtnewvalue"] = Dt_new;
                //    grd.DataBind();
                //    btn_Cancel.ToolTip = "Cancel";
                //    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                //}

                //else if (ddlEvents.Text == "Original documents send On")
                //{
                //    txtjob.Text = "";
                //    grd.Visible = true;
                //    Dt_new = da_obj_FIJobobj.GetPA2AccDtsCH("oridocsendon", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                //    grd.DataSource = Dt_new;
                //    ViewState["Dtnewvalue"] = Dt_new;
                //    grd.DataBind();
                //    btn_Cancel.ToolTip = "Cancel";
                //    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                //}


                //else if (ddlEvents.Text == "ExBond Boe Filed On")
                //{
                //    txtjob.Text = "";
                //    grd.Visible = true;
                //    Dt_new = da_obj_FIJobobj.GetPA2AccDtsCH("exbondboefilling", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                //    grd.DataSource = Dt_new;
                //    ViewState["Dtnewvalue"] = Dt_new;
                //    grd.DataBind();
                //    btn_Cancel.ToolTip = "Cancel";
                //    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                //}


                //else if (ddlEvents.Text == "Cargo Delivery")
                //{
                //    txtjob.Text = "";
                //    grd.Visible = true;
                //    Dt_new = da_obj_FIJobobj.GetPA2AccDtsCH("cargodeliver", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                //    grd.DataSource = Dt_new;
                //    ViewState["Dtnewvalue"] = Dt_new;
                //    grd.DataBind();
                //    btn_Cancel.ToolTip = "Cancel";
                //    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                //}

            }
        


           
        }

        protected void grStuff()
        {
            grdStuff.DataSource = new DataTable();
            grdStuff.DataBind();
        }

        protected void txtCfs_TextChanged(object sender, EventArgs e)
        {
            if (txtCfs.Text != "")
            {
                cfsid = 0;
                Dt = objCust.GetLikeCustomerWDL((txtCfs.Text.Trim()));
                if (Dt.Rows.Count == 1)
                {
                    cfsid = Convert.ToInt32(Dt.Rows[0]["customerid"].ToString());
                    txtCfs.Text = Dt.Rows[0]["customername"].ToString();
                }
            }

            if (cfsid != 0)
            {
                GridView1.DataSource = Utility.Fn_GetEmptyDataTable();
                GridView1.DataBind();

                dtcaargo = objcargopick.getcfsDtls(cfsid, Convert.ToInt32(Session["LoginBranchid"].ToString()));

                if (dtcaargo.Rows.Count > 0)
                {
                    DataTable dtTemp = new DataTable();
                    dtTemp.Columns.Add("jobno");
                    dtTemp.Columns.Add("blno");
                    dtTemp.Columns.Add("consignee");
                    dtTemp.Columns.Add("vesselname");
                    dtTemp.Columns.Add("arrived");
                    dtTemp.Columns.Add("dodate");
                    //dtTemp.Columns.Add("cbm");
                    //dtTemp.Columns.Add("gagent");
                    DataRow dr = dtTemp.NewRow();
                    for (int i = 0; i <= dtcaargo.Rows.Count - 1; i++)
                    {
                        dr = dtTemp.NewRow();
                        dtTemp.Rows.Add(dr);

                        dtTemp.Rows[i]["jobno"] = dtcaargo.Rows[i]["jobno"].ToString();
                        dtTemp.Rows[i]["blno"] = dtcaargo.Rows[i]["blno"].ToString();
                        dtTemp.Rows[i]["consignee"] = dtcaargo.Rows[i]["consignee"].ToString();
                        dtTemp.Rows[i]["vesselname"] = dtcaargo.Rows[i]["vesselname"].ToString() + " & " + dtcaargo.Rows[i]["voyage"].ToString();
                        dtTemp.Rows[i]["arrived"] = dtcaargo.Rows[i]["arrived"].ToString();
                        dtTemp.Rows[i]["dodate"] = dtcaargo.Rows[i]["dodate"].ToString();
                        //dtTemp.Rows[i]["grdcbm"] = dtcaargo.Rows[i]["cbm"].ToString();
                        //dtTemp.Rows[i]["gagent"] = dtcaargo.Rows[i]["agentid"].ToString();
                    }
                    GridView1.DataSource = dtTemp;
                    ViewState["gridview1"] = dtTemp;
                    GridView1.DataBind();
                }
                btn_Cancel.Text = "Cancel";
                btn_Cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Enter Valid Customer');", true);
                txtCfs.Focus();
            }
        }



        protected void btnAdd_Click(object sender, EventArgs e)
        {
            /*if (txtContainer.Text != "")
            {
                if (Convert.ToDateTime(txtEta.Text) < Convert.ToDateTime(Utility.fn_ConvertDate(txtdestuff.Text)))
                {

                    da_obj_FIJobobj.UpdFIContDtlsForDestuff(Convert.ToInt32(txtjob.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdestuff.Text)), txtContainer.Text);
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Details Updated');", true);
                    txtContainer.Text = "";
                    txtSeal.Text = "";
                    txtsize.Text = "";
                    txtdestuff.Text = Utility.fn_ConvertDate(da_obj_logobj.GetDate().ToString());
                    dtcont = da_obj_FIJobobj.GetContforDestuff(Convert.ToInt32(txtjob.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dtcont.Rows.Count > 0)
                    {
                        grdStuff.DataSource = dtcont;
                        grdStuff.DataBind();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Destuff Date Should be Greater than ETA Date');", true);
                    txtdestuff.Focus();
                }
                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1750, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtContainer.Text + " Upd");
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Select the Container#');", true);
            }*/
        }

        protected void grdStuff_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdStuff, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
            }
        }

        protected void grdStuff_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            if(grdStuff.Rows.Count>0)
            {
                index = grdStuff.SelectedRow.RowIndex;
                txtContainer.Text = grdStuff.Rows[index].Cells[0].Text;
                txtsize.Text = grdStuff.Rows[index].Cells[1].Text;
                txtSeal.Text = grdStuff.Rows[index].Cells[2].Text;
                if (string.IsNullOrEmpty(grdStuff.Rows[index].Cells[3].Text) == true || grdStuff.Rows[index].Cells[3].Text == "&nbsp;")
                {
                  //  txtdestuff.Text = Utility.fn_ConvertDate(da_obj_logobj.GetDate().ToString());

                    txtdestuff.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                }
                else
                {
                    txtdestuff.Text = grdStuff.Rows[index].Cells[3].Text;
                }
            }
        } 

        protected void txtjob_TextChanged(object sender, EventArgs e)
        {

            try
            {
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());

                DataTable obj_dt_jinfo = new DataTable();
                DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();

                if (txtjob.Text != "")
                {
                    grdStuff.DataSource = new DataTable();
                    grdStuff.DataBind();
                    obj_dt_jinfo = obj_da_jinfo.GetJobInfoforDestuff(Convert.ToInt32(txtjob.Text), int_branchid, int_divisionid);
                    if (obj_dt_jinfo.Rows.Count > 0)
                    {

                        str_closedjob = obj_dt_jinfo.Rows[0]["closedjob"].ToString();

                        txtEta.Text = String.Format("{0:dd/MM/yyyy}", obj_dt_jinfo.Rows[0]["eta"]);

                        btn_Cancel.Text = "Cancel";
                        btn_Cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Invalid Job #');", true);
                        txtjob.Focus();
                        return;
                    }

                    DataTable obj_dt_dstuff = new DataTable();
                    obj_dt_dstuff = obj_da_jinfo.GetContforDestuff(Convert.ToInt32(txtjob.Text), int_branchid, int_divisionid);
                    if (obj_dt_dstuff.Rows.Count > 0)
                    {
                       // pnl_dstuff.Visible = true;
                        grdStuff.DataSource = obj_dt_dstuff;
                        grdStuff.DataBind();
                        grdStuff.Focus();
                        //btn_Cancel.Text = "Cancel";
                        btn_Cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                    if (str_closedjob == "True")
                    {
                        txtjob.Enabled = false;

                        txtEta.Enabled = false;
                        btn_update.Enabled = false;
                        txtContainer.Enabled = false;
                        txtsize.Enabled = false;
                        txtSeal.Enabled = false;
                        grdStuff.Enabled = false;
                        btn_Cancel.Text = "Cancel";
                        btn_Cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Job is Closed');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = (DataTable)ViewState["gridview1"];
            GridView1.DataBind();
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
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();


            obj_dtlogdetails = da_obj_logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1750, "fievents", txtjob.Text, txtjob.Text, Session["StrTranType"].ToString());

            if (txtjob.Text != "")
            {
                JobInput.Text = txtjob.Text;
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