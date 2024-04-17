using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.Services;
using System.Net;
using System.IO;


namespace logix
{
    public partial class Ebookingdetails : System.Web.UI.Page
    {
        string strCtrlLst, strMsgLst, strDtypeLst;
        CustomerDataAccess.PODetails Logobj = new CustomerDataAccess.PODetails();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        CustomerDataAccess.RegCustomer regCustObj = new CustomerDataAccess.RegCustomer();

        DataAccess.Masters.MasterPort port = new DataAccess.Masters.MasterPort();

        DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
        int intBranchID = 0;
      
        Boolean blnerr;

        DataAccess.ForwardingExports.PODetails obj_da_Podetails = new DataAccess.ForwardingExports.PODetails();

        string username = "";
        string password = "";


        string ip = "";
        string dbname = "";

        protected string DBCS;
     

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ((ScriptManager)Master.FindControl("ScriptManager2")).RegisterPostBackControl(btnSave);
                ((ScriptManager)Master.FindControl("ScriptManager2")).RegisterPostBackControl(grpupdload);
            }

            catch (Exception ex)
            {
                //string message = ex.Message.ToString();
               // ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (!IsPostBack)
            {
                txt_date.Text = Utility.fn_ConvertDate(da_obj_Log.GetDate().ToString());

                //txt_date.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                //txt_despatchdate.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                //txt_pickupdate.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                //txt_invoicedate.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                Fn_Loadbranch();
                txt_wt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weight')");

                txt_approx_volume.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Volume')");
                txt_noofpkg.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
             //   txt_pkg.Attributes.Add("OnKeypress", "return IntegerCheck(event);");


                txt_uno.Attributes.Add("onkeypress", "return IntegerCheck(event);");
                strCtrlLst = "txt_customer~txtbranchoff~txt_branchaddress~txt_por~txt_pol~txt_pod~txt_fd~txt_shipper~txt_consignee~txt_notify~txt_marks~txt_noofpkg~txt_pkg";
                strDtypeLst = "AutoComplete~ddl~Text~AutoComplete~AutoComplete~AutoComplete~AutoComplete~AutoComplete~AutoComplete~AutoComplete~Text~Text~Text";
                strMsgLst = "Customer Name~Branch~Branch Addess~POR~POL~POD~FD~Shipper~Consignee~Notify~Marks and Nos~No of Packages~Pkg Type";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + strCtrlLst + "','" + strMsgLst + "','" + strDtypeLst + "') ;");
                

            }
        }

        [WebMethod]
        public static List<string> Getlikebookfromtmp(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.ForwardingExports.PODetails FEPOobj = new DataAccess.ForwardingExports.PODetails();
            DataTable dtbooklike = new DataTable();
            dtbooklike = FEPOobj.Getlikebookfromtmpnewly(prefix);
            List_Result = Utility.Fn_TableToList(prefix.ToUpper(), dtbooklike, "bookingno");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            obj_dt = obj_da_Customer.GetLikeCustomer(prefix.ToUpper(), "C");
            List_Result = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetPort(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterPort obj_da_Customer = new DataAccess.Masters.MasterPort();
            obj_dt = obj_da_Customer.GetLikePort(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(obj_dt, "portname", "portid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetInco(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Marketing.Booking obj_da_Booking = new DataAccess.Marketing.Booking();
            obj_dt = obj_da_Booking.GetLikeIncocode(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(obj_dt, "incocode", "incoid");
            return List_Result;
        }


        [WebMethod]
        public static List<string> getlikeshipper(string prefix)
        {
            List<string> list_result = new List<string>();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataTable dt = new DataTable();
            string custype = "C";
            dt = customerobj.GetLikeCustomer(prefix.ToUpper(), custype);
            list_result = Utility.Fn_DatatableToList_CustomerAddress2(dt, "customer", "customername", "customerid");
            return list_result;
        }


        [WebMethod]
        public static List<string> getlikeconsignee(string prefix)
        {
            List<string> list_result = new List<string>();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataTable dt = new DataTable();
            string custype = "C";
            dt = customerobj.GetLikeCustomer(prefix.ToUpper(), custype);
            list_result = Utility.Fn_DatatableToList_CustomerAddress2(dt, "customer", "customername", "customerid");
            return list_result;
        }

        [WebMethod]
        public static List<string> getlikenotify(string prefix)
        {
            List<string> list_result = new List<string>();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataTable dt = new DataTable();
            string custype = "C";
            dt = customerobj.GetLikeCustomer(prefix.ToUpper(), custype);
            list_result = Utility.Fn_DatatableToList_CustomerAddress2(dt, "customer", "customername", "customerid");
            return list_result;
        }


        [WebMethod]
        public static List<string> GetCustomername(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();

            dt = obj_MasterCustomer.SPLikeCustomerAll4CustomernewEbooking(prefix.ToUpper());
           
            list_result = Utility.Fn_TableToList_Cust1(dt, "customer", "customerid", "address");
            return list_result;

        }


        [WebMethod]
        public static List<string> GetLikeIncocode(string prefix)
        {
            DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
            DataTable obj_Dt = new DataTable();
            List<string> Incocode = new List<string>();
            obj_Dt = bookingobj.GetLikeIncocode(prefix.ToUpper());
            Incocode = Utility.Fn_DatatableToList_int32(obj_Dt, "incocode", "incoid");
            return Incocode;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

            DateTime dt_date, dt_cargo, dt_despatch, dt_pickup, dt_invoice;
           
            DataAccess.Masters.MasterCustomer customerobj1 = new DataAccess.Masters.MasterCustomer();
            string portcode = "";
            string str_trantype, str_Po, str_Style, str_Desc, str_invoice, str_unittype, str_remark, str_Marks;
            str_trantype = ddl_out.SelectedItem.Value.ToString() + ddl.SelectedItem.Value.ToString();
            int int_booikgno, int_Inco, int_pol, int_por, int_pod, int_fd, int_Pieces, int_cartons;
            double volume;
            float weight;
            string cont = "";
            string customermailid = "";

            DataTable dtnew=new DataTable();
            DataTable dtnew1 = new DataTable();
            DataTable dtnew2 = new DataTable();
            DataTable dtnew3 = new DataTable();
            volume = double.Parse(txt_approx_volume.Text);

            int_pol = int.Parse(hid_pol.Value.ToString());
            int_pod = int.Parse(hid_pod.Value.ToString());
            int_por = int.Parse(hid_por.Value.ToString());
            int_fd = int.Parse(hid_fd.Value.ToString());
          
          
            txt_customer_TextChanged(sender, e);
            txt_shipper_TextChanged(sender, e);
            txt_consignee_TextChanged(sender, e);
            txt_notify_TextChanged(sender, e);
            
            txt_por_TextChanged(sender, e);
            txt_pol_TextChanged(sender, e);
            txt_pod_TextChanged(sender, e);
            txt_fd_TextChanged(sender,e);
            txtbranchoff_SelectedIndexChanged(sender, e);

            if (hid_branchid.Value != "")
            {
                portcode = port.GetPortCodeportid(Convert.ToInt32(hid_branchid.Value));
                //portcode = "E" +"/" +portcode.Substring(2, 3);
                portcode =  portcode.Substring(2, 3);
                
            }
            else
            {

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Master Branch not updated');", true);
                return;
            }
            if (blnerr == true)
            {
                return;
            }

            if(btn_save.ToolTip=="Save")
            {
                string ebooking = "";
                txt_booking.Text = "1233";
              

                    ebooking = obj_da_Podetails.InsEBookingdetailsnew(txt_booking.Text, txt_customer.Text, Convert.ToInt32(hf_customerid.Value), Convert.ToInt32(hid_branchid.Value),
                        txtbranchoff.SelectedItem.Text, txt_branchaddress.Text, ddl_type.SelectedValue, Convert.ToInt32(hid_por.Value),
                        Convert.ToInt32(hid_pol.Value), Convert.ToInt32(hid_pod.Value), Convert.ToInt32(hid_fd.Value), txt_tues.Text,
                        Convert.ToInt32(Hiddenshipper.Value), txt_shipper.Text, txtsaddress.Text, Convert.ToInt32(Hiddenconsignee.Value),
                        txt_consignee.Text, txtcaddress.Text, Convert.ToInt32(Hiddennotify.Value), txt_notify.Text,
                        txtnaddress.Text, txt_marks.Text, Convert.ToInt32(txt_noofpkg.Text),txt_pkg.Text,
                        Convert.ToDouble(txt_wt.Text), Convert.ToDouble(txt_approx_volume.Text), Convert.ToInt32(hdn_Incoid.Value)
                        , Convert.ToInt32(txt_uno.Text), ddlhya.SelectedItem.Value.ToString(), txt_cartons.Text, "N", portcode);
                    txt_booking.Text = ebooking.ToString();


                    obj_da_Podetails.updatedateBookingdetailsnew(txt_booking.Text, Convert.ToInt32(hid_branchid.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txt_date.Text).ToString()));

                  /*  cont = "<html>";
                    cont = cont + "<body style='font-size:14px; font-family:tahoma;  color:#4e4e4c;'><table width=100% class='TBLFormat'><FONT FACE=tahoma > <tr><td>  Dear Sir/Madam, </td> </tr> <tr><td style='text-align:center; font-weight:bold;'> Shipper Name :" + txt_shipper.Text + " </td> </tr><tr><td align=left>e-booking  # : " + txt_booking.Text + "  has been created in " + "customer" + ". Please find below details</td></tr></table>";

                    cont = cont + "<table class='TBLFormat'><tr><td align=left colspan='2'>e-booking # : " + txt_booking.Text + "   </td><td align=left>Cutomser Name : " + txt_customer.Text + "     </td></tr>";
                    cont = cont + "<tr><td align=left>PoR : " + txt_por.Text + "   " + "   </td><td align=left style='width:250px;'>PoL : " + txt_pol.Text + "   " + "   </td> <td align=left style='width:250px;'>FD : " + txt_fd.Text + "   </td></tr>";
                    cont = cont + "<tr></tr>";
                    cont = cont + "<tr><td align=left width='250px' colspan='2'>Shipper : " + txt_shipper.Text + "</td><td>Addess : " + txtsaddress.Text + "</td></tr>";
                    cont = cont + "<tr><td align=left width='250px' colspan='2'>Noify : " + txt_notify.Text + "</td><td>Addess : " + txtnaddress.Text + "</td></tr>";
                    cont = cont + "<tr><td align=left width='250px' colspan='2'>Consignee : " + txt_consignee.Text + "</td><td>Addess : " + txtcaddress.Text + "</td></tr></table></body></html>";

                */




                    cont = "<html>";
                    cont = cont + "<body style='padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                    cont = cont + "<div style='width:1010px; margin:0px auto; padding:10px; border:1px solid #000;'>";
                    cont = cont + "<div style='width:1010px;'>";

                    cont = cont + "<div style='clear:both;'></div></div>";
                    cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border:1px solid #000;'>";
                    cont = cont + "<div style=' width:495px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                    cont = cont + "<label style='color:#fff;'>Booking Alert Mail to Consignee</label></div>";

                    cont = cont + "<div style=' width:494px; color:#fff; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";
                    if (ddl_type.SelectedItem.Text == "FCL")
                    {
                        cont = cont + "<label style='color:#fff;'>FCL Export Booking Status</label></div>";
                    }
                    else if (ddl_type.SelectedItem.Text == "LCL")
                    {
                        cont = cont + "<label style='color:#fff;'>LCL Import Booking Status</label></div>";
                    }
                    else if (ddl_type.SelectedItem.Text == "Air")
                    {
                        cont = cont + "<label style='color:#fff;'>AIR Booking Status</label></div>";
                    }

                    cont = cont + "<div style='clear:both;'></div></div>";
                    cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                    cont = cont + "<div style=' width:495px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                    cont = cont + "<label style='color:#fff;'>Message From " + Session["LoginDivisionName"].ToString() + "</label></div>";
                    cont = cont + "<div style=' width:494px; color:#000; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";
                    cont = cont + "<label>Date: " + txt_date.Text + "</label></div>";
                    cont = cont + "<div style='clear:both;'></div></div>";
                    cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                    cont = cont + "<div style=' width:990px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                    cont = cont + "<label> Dear Sir/Madam,Please find attached e-booking  # : " + txt_booking.Text + "  has been Booked in " + "customer" + ". Please find below details</label></div>";

                    cont = cont + "<div style='clear:both;'></div></div>";
                    cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                    cont = cont + "<div style=' width:990px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                    cont = cont + "<label style='color:#fff;'> BOOKING REFERENCE</label></div>";

                    cont = cont + "<div style='clear:both;'></div></div>";
                    cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                    cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Number : </div>";
                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + txt_booking.Text + "</label></div>";
                    cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Date : </div>";
                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + txt_date.Text + "</label></div>";
                    cont = cont + "</div>";

                    cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                    cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Origin  : </div>";

                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + txt_por.Text + "</label></div>";
                    cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Destination  : </div>";
                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + txt_fd.Text + "</label></div>";
                    cont = cont + "</div>";
                    cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Number  : </div>";
                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Date  : </div>";
                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Released  : </div>";
                    cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "&nbsp;" + "</label></div>";
                    cont = cont + "</div>";
                    cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                    cont = cont + "<div style='float:left; width:990px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold;'>Customer Reference Number : </div>";
                    cont = cont + "</div>";
                    cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";

                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                    cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Shipper</div>";
                    cont = cont + "<div style='float:left; width:300px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'> ";
                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + txt_shipper.Text + "</p>";
                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + txtsaddress.Text + "</p>";
                    cont = cont + "</div></div>";

                    cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                    cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Consignee</div>";
                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + txt_consignee.Text + "</p>";

                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + txtcaddress.Text + "<br />";
                    cont = cont + "</p> </div>";
                    cont = cont + "<div style='float:left; width:368px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:0px solid #000; min-height:145px;'>";
                    cont = cont + "<div style='float:left; width:368px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'> Notify Party</div>";
                    cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + txt_notify.Text + "</p>";
                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + txtnaddress.Text + "</p>";
                    cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'></p></div></div>";

                    cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                    cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                    cont = cont + "<label style='color:#fff;'>  SHIPMENT DETAIL</label></div>";
                    cont = cont + "<div style='clear:both;'></div></div>";


                    cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                    cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Terms of Shipment:</div>";
                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + ddl_type.SelectedItem.Text + "</label></div>";

                    cont = cont + "</div>";
                    cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Freight Terms : </div>";
                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

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
                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + txt_customer.Text + "</label></div>";

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
                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + txt_pol.Text + "</td>";
                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + txt_por.Text + "</td>";
                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                    cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>PLANNED</td>";
                   
                    if (ddl_type.SelectedItem.Text == "FCL" || ddl_type.SelectedItem.Text == "LCL")
                    {
                        cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "SEA" + "</td>";
                    }
                    else if (ddl_type.SelectedItem.Text == "Air")
                    {
                        cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "AIR" + "</td>";
                    }
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
                    cont = cont + "<label>" + "" + "</label></div>";

                    cont = cont + "<div style='clear:both;'></div>";



                    cont = cont + "</div>";
                    cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                    cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>No of Packages:</div>";
                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + txt_noofpkg.Text + "</label></div>";

                    cont = cont + "</div>";
                    cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Gross Weight : </div>";
                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + txt_wt.Text + " </label></div>";


                    cont = cont + "</div>";
                    cont = cont + "<div style='clear:both;'></div>";
                    cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Volume  : </div>";
                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + txt_approx_volume.Text + " </label></div>";

                    cont = cont + "</div>";
                    cont = cont + "<div style='width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Chargeable Volume : </div>";
                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + txt_wt.Text + " </label></div>";

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

                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Loading Vessel/Voyage : </div>";
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

                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Discharge Vessel/Voyage :</div>";
                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

                    cont = cont + "</div>";
                    cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                    cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> ETA  : </div>";
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


                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                    txt_booking.Enabled = true;

                     dtnew = customerobj1.spcustomernamemailid(Convert.ToInt32(Hiddenshipper.Value));
                     dtnew1 = customerobj1.spcustomernamemailid(Convert.ToInt32(Hiddenconsignee.Value));
                     dtnew2 = customerobj1.spcustomernamemailid(Convert.ToInt32(Hiddennotify.Value));

                     dtnew3 = customerobj1.spcustomernamemailid(Convert.ToInt32(hf_customerid.Value));
                     customermailid = dtnew.Rows[0]["email"].ToString() + ";" + dtnew1.Rows[0]["email"].ToString() + ";" + dtnew2.Rows[0]["email"].ToString() + ";" + dtnew3.Rows[0]["email"].ToString() ;
                     string sub11 = "e-booking  # : " + txt_booking.Text + "  has been Booked in " + "customer." + ". Please find below details";


                 


                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "alert", "alertify.alert('Details Saved Successfully');", true);
                 
            }
            else 
            {
               obj_da_Podetails.updEBookingdetailsnew(txt_booking.Text, txt_customer.Text, Convert.ToInt32(hf_customerid.Value), Convert.ToInt32(hid_branchid.Value),
                  txtbranchoff.SelectedItem.Text, txt_branchaddress.Text, ddl_type.SelectedValue, Convert.ToInt32(hid_por.Value),
                  Convert.ToInt32(hid_pol.Value), Convert.ToInt32(hid_pod.Value), Convert.ToInt32(hid_fd.Value), txt_tues.Text,
                  Convert.ToInt32(Hiddenshipper.Value), txt_shipper.Text, txtsaddress.Text, Convert.ToInt32(Hiddenconsignee.Value),
                  txt_consignee.Text, txtcaddress.Text, Convert.ToInt32(Hiddennotify.Value), txt_notify.Text,
                  txtnaddress.Text, txt_marks.Text, Convert.ToInt32(txt_noofpkg.Text), txt_pkg.Text,
                  Convert.ToDouble(txt_wt.Text), Convert.ToDouble(txt_approx_volume.Text), Convert.ToInt32(hdn_Incoid.Value)
                  , Convert.ToInt32(txt_uno.Text), ddlhya.SelectedItem.Value.ToString(), txt_cartons.Text, "N");
                
                
                obj_da_Podetails.updatedateBookingdetailsnew(txt_booking.Text, Convert.ToInt32(hid_branchid.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txt_date.Text).ToString()));
               
                
                /*cont = "<html>";
                cont = cont + "<body style='font-size:14px; font-family:tahoma;  color:#4e4e4c;'><table width=100% class='TBLFormat'><FONT FACE=tahoma > <tr><td>  Dear Sir/Madam, </td> </tr> <tr><td style='text-align:center; font-weight:bold;'> Shipper Name :" + txt_shipper.Text + " </td> </tr><tr><td align=left>e-booking  # : " + txt_booking.Text + "  has been Updated in " + "customer" + ". Please find below details</td></tr></table>";

                cont = cont + "<table class='TBLFormat'><tr><td align=left colspan='2'>e-booking # : " + txt_booking.Text + "   </td><td align=left>Cutomser Name : " + txt_customer.Text + "     </td></tr>";
                cont = cont + "<tr><td align=left>PoR : " + txt_por.Text + "   " + "   </td><td align=left style='width:250px;'>PoL : " + txt_pol.Text + "   " + "   </td> <td align=left style='width:250px;'>FD : " + txt_fd.Text + "   </td></tr>";
                cont = cont + "<tr></tr>";
                cont = cont + "<tr><td align=left width='250px' colspan='2'>Shipper : " + txt_shipper.Text + "</td><td>Addess : " + txtsaddress.Text + "</td></tr>";
                cont = cont + "<tr><td align=left width='250px' colspan='2'>Noify : " + txt_notify.Text + "</td><td>Addess : " + txtnaddress.Text + "</td></tr>";
                cont = cont + "<tr><td align=left width='250px' colspan='2'>Consignee : " + txt_consignee.Text + "</td><td>Addess : " + txtcaddress.Text + "</td></tr></table></body></html>";
                */

               

                dtnew = customerobj1.spcustomernamemailid(Convert.ToInt32(Hiddenshipper.Value));
                dtnew1 = customerobj1.spcustomernamemailid(Convert.ToInt32(Hiddenconsignee.Value));
                dtnew2 = customerobj1.spcustomernamemailid(Convert.ToInt32(Hiddennotify.Value));

                dtnew3 = customerobj1.spcustomernamemailid(Convert.ToInt32(hf_customerid.Value));
                customermailid = dtnew.Rows[0]["email"].ToString() + ";" + dtnew1.Rows[0]["email"].ToString() + ";" + dtnew2.Rows[0]["email"].ToString() + ";" + dtnew3.Rows[0]["email"].ToString();

                cont = "<html>";
                cont = cont + "<body style='padding:0px 0px 0px 0px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                cont = cont + "<div style='width:1010px; margin:0px auto; padding:10px; border:1px solid #000;'>";
                cont = cont + "<div style='width:1010px;'>";
                
         
                cont = cont + "<div style='clear:both;'></div></div>";
                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border:1px solid #000;'>";
                cont = cont + "<div style=' width:495px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                cont = cont + "<label style='color:#fff;'>Booking Alert Mail to Consignee</label></div>";

                cont = cont + "<div style=' width:494px; color:#fff; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";
                if (ddl_type.SelectedItem.Text == "FCL")
                {
                    cont = cont + "<label style='color:#fff;'>FCL Export Booking Status</label></div>";
                }
                else if (ddl_type.SelectedItem.Text == "LCL")
                {
                    cont = cont + "<label style='color:#fff;'>LCL Import Booking Status</label></div>";
                }
                else if (ddl_type.SelectedItem.Text == "Air")
                {
                    cont = cont + "<label style='color:#fff;'>AIR Booking Status</label></div>";
                }
              
                cont = cont + "<div style='clear:both;'></div></div>";
                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                cont = cont + "<div style=' width:495px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                cont = cont + "<label style='color:#fff;'>Message From " + Session["LoginDivisionName"].ToString() + "</label></div>";
                cont = cont + "<div style=' width:494px; color:#000; float:left; padding:5px; margin:0px 0px 0px 0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px; text-align:right;'>";
                cont = cont + "<label>Date: "+txt_date.Text+ "</label></div>";
                cont = cont + "<div style='clear:both;'></div></div>";
                cont = cont + "<div style='width:1010px; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                cont = cont + "<div style=' width:990px; color:#000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                cont = cont + "<label> Dear Sir/Madam,Please find attached e-booking  # : " + txt_booking.Text + "  has been Updated in " + "customer" + ". Please find below details</label></div>";

                cont = cont + "<div style='clear:both;'></div></div>";
                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                cont = cont + "<div style=' width:990px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                cont = cont + "<label style='color:#fff;'> BOOKING REFERENCE</label></div>";

                cont = cont + "<div style='clear:both;'></div></div>";
                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Number : </div>";
                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>"+txt_booking.Text+"</label></div>";
                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Booking Date : </div>";
                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>"+txt_date.Text+"</label></div>";
                cont = cont + "</div>";

                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Origin  : </div>";

                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + txt_por.Text+ "</label></div>";
                cont = cont + "<div style='float:left; width:120px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>Destination  : </div>";
                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + txt_fd.Text + "</label></div>";
                cont = cont + "</div>";
                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Number  : </div>";
                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>"+"&nbsp;"+"</label></div>";
                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Date  : </div>";
                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-right:1px solid #000;'><label>" + "&nbsp;" + "</label></div>";
                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:bold; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>HBL Released  : </div>";
                cont = cont + "<div style='float:left; width:150px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'><label>" + "&nbsp;" + "</label></div>";
                cont = cont + "</div>";
                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                cont = cont + "<div style='float:left; width:990px; margin:0px 0px 0px 0px; padding:5px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold;'>Customer Reference Number : </div>";
                cont = cont + "</div>";
                cont = cont + "<div style='float:left; width:1010px; border-left:1px solid #000; borer-bottom:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";

                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Shipper</div>";
                cont = cont + "<div style='float:left; width:300px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'> ";
                cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px;'>" + txt_shipper.Text+ "</p>";
                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>"+txtsaddress.Text+"</p>";
                cont = cont + "</div></div>";

                cont = cont + "<div style='float:left; width:320px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:1px solid #000; min-height:145px;'>";
                cont = cont + "<div style='float:left; width:320px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'>Consignee</div>";
                cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + txt_consignee.Text+ "</p>";

                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'>" + txtcaddress.Text+"<br />";
                cont = cont + "</p> </div>";
                cont = cont + "<div style='float:left; width:368px; margin:0px 0px 0px 0px; padding:5px 0px 5px 0px; color:#000; font-weight:normal; font-family:sans-serif, Geneva, sans-serif; font-size:13px; font-weight:bold; border-right:0px solid #000; min-height:145px;'>";
                cont = cont + "<div style='float:left; width:368px; text-align:center; font-weight:bold; color:#000; font-family:sans-serif, Geneva, sans-serif; font-size:13px; border-bottom:1px solid #000; padding:0px 0px 5px 0px;'> Notify Party</div>";
                cont = cont + "<p style='font-size:13px; font-weight:bold; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + txt_notify.Text + "</p>";
                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:5px 0px 5px 0px; float:left; width:100%;'>" + txtnaddress.Text + "</p>";
                cont = cont + "<p style='font-size:13px; font-weight:normal; text-align:left; padding:0px 5px 0px 5px; margin:0px 0px 0px 0px;'></p></div></div>";

                cont = cont + "<div style='width:1010px; background-color:#0674c1; float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                cont = cont + "<div style=' width:1000px; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";
                cont = cont + "<label style='color:#fff;'>  SHIPMENT DETAIL</label></div>";
                cont = cont + "<div style='clear:both;'></div></div>";


                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Terms of Shipment:</div>";
                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + ddl_type.SelectedItem.Text + "</label></div>";

                cont = cont + "</div>";
                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Freight Terms : </div>";
                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + "" + "</label></div>";

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
                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + txt_customer.Text + "</label></div>";

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
                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + txt_pol.Text+ "</td>";
                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>"+""+"</td>";
                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + txt_por.Text + "</td>";
                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>"+""+"</td>";
                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "" + "</td>";
                cont = cont + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; padding:5px;'>PLANNED</td>";
                if (ddl_type.SelectedItem.Text == "FCL" || ddl_type.SelectedItem.Text == "LCL")
                {
                    cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "SEA" + "</td>";
                }
                else if (ddl_type.SelectedItem.Text == "Air")
                {
                    cont = cont + " <td style='border-right:0px solid #000; border-bottom:1px solid #000; padding:5px;'>" + "AIR" + "</td>";
                }
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
                cont = cont + "<label>"+""+"</label></div>";

                cont = cont + "<div style='clear:both;'></div>";



                cont = cont + "</div>";
                cont = cont + "<div style='width:1010px;  float:left; border-left:1px solid #000; border-right:1px solid #000; border-bottom:1px solid #000;'>";
                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; border-bottom:1px solid #000; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>No of Packages:</div>";
                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + txt_noofpkg.Text+ "</label></div>";

                cont = cont + "</div>";
                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Gross Weight : </div>";
                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + txt_wt.Text+ " </label></div>";


                cont = cont + "</div>";
                cont = cont + "<div style='clear:both;'></div>";
                cont = cont + "<div style=' width:495px; border-right:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Volume  : </div>";
                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + txt_approx_volume .Text+ " </label></div>";

                cont = cont + "</div>";
                cont = cont + "<div style='width:494px; border-right:0px solid #000; border-top:0px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'>Chargeable Volume : </div>";
                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>" + txt_wt.Text+ " </label></div>";

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

                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Loading Vessel/Voyage : </div>";
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

                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> Discharge Vessel/Voyage :</div>";
                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>"+""+"</label></div>";

                cont = cont + "</div>";
                cont = cont + "<div style=' width:494px; border-right:0px solid #000; border-bottom:1px solid #000; color:#fff; float:left; padding:5px; margin:0px; font-family:sans-serif, Geneva, sans-serif; font-size:13px;'>";

                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:bold; color:#000;'> ETA  : </div>";
                cont = cont + "<div style='width:auto; margin:0px 5px 0px 0px; float:left; font-weight:normal; color:#000;'><label>"+""+"</label></div>";

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

                



               // mailcontent.Text = cont.ToString();
                string sub1 = "e-booking  # : " + txt_booking.Text + "  has been Updated in " + "customer." + ". Please find below details";
              
                
               
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn btn-booking";
                txt_booking.Enabled = true;
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "alert", "alertify.alert('Details Updated  Successfully');", true);
                Fn_Clear();
            }
           
           
             


                //da_obj_Log.InsLogDetail(Convert.ToInt32(Session["webgroupid"].ToString()), 1, 1, Convert.ToInt32(Session["LoginDivisionId"]), "Booking" + "# -" + txt_booking.Text);

                regCustObj.InsWebCustLogDtl(Convert.ToInt32(Session["webgroupid"].ToString()), CustomerDataAccess.RegCustomer.EventType.LoginSuccess, DateTime.Now, Convert.ToInt32(Session["LoginDivisionId"])+ "Booking" + "# -" + txt_booking.Text);
           
        }

        protected void txt_shipper_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Hiddenshipper.Value != "0")
                {
                    txt_consignee.Focus();
                }
                else
                {
                    txt_shipper.Text = "";
                    txtsaddress.Text = "";
                    blnerr = true;
                    txt_shipper.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid SHIPPER');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_consignee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Hiddenconsignee.Value != "0")
                {
                    txt_notify.Focus();
                }
                else
                {
                    txt_consignee.Text = "";
                    txtcaddress.Text = "";
                    txt_consignee.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid CONSIGNEE');", true);
                    blnerr = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_notify_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Hiddennotify.Value != "0")
                {
                    txt_marks.Focus();
                }
                else
                {
                    txt_notify.Text = "";
                    txtnaddress.Text = "";
                    txt_notify.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid NOTIFY PARTY');", true);
                    blnerr = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }
       /* private void FillBranch()
        {
            DataTable Dt = new DataTable();
            txtbranchoff.Items.Clear();
            Dt = regCustObj.GetBranchByDivID(1);
            if (Dt.Rows.Count > 0)
            {
                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    txtbranchoff.Items.Add(Dt.Rows[i]["branch"].ToString());
                }
            }
        }*/


        private void Fn_Loadbranch()
        {
          /*  txtbranchoff.Items.Clear();
            DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.selBranchList(Session["LoginDivisionId"].ToString());
            if (obj_dt.Rows.Count > 0)
            {
                txtbranchoff.DataSource = obj_dt;
                txtbranchoff.DataTextField = "branchname";
                txtbranchoff.DataBind();
            }
            */
            DataTable Dt = new DataTable();
            txtbranchoff.Items.Clear();
            txtbranchoff.Items.Add("Branch");
            Dt = regCustObj.GetBranchByDivID(1);
            if (Dt.Rows.Count > 0)
            {
                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    if (i != 3)
                    {
                        txtbranchoff.Items.Add(Dt.Rows[i]["branch"].ToString());
                    }
                }
            }

        }

        protected void txtbranchoff_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
            DataAccess.ForwardingExports.ISFDetails obj = new DataAccess.ForwardingExports.ISFDetails();
            DataTable dt = new DataTable();
            if (Session["LoginDivisionId"] != null)
            {
                if (txtbranchoff.SelectedItem.Text != "Branch")
                {

                    intBranchID = HREmpobj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), txtbranchoff.SelectedItem.Text);
                    hid_branchid.Value = intBranchID.ToString();
                    dt = obj.GetBdtls(intBranchID);
                    txt_branchaddress.Text = dt.Rows[0]["address"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Branch');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Branch');", true);
            }
        }

        protected void txt_inco_TextChanged(object sender, EventArgs e)
        {
            DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
            // DataTable obj_Dt = new DataTable();
            // List<string> Incocode = new List<string>();
            // obj_Dt = bookingobj.GetLikeIncocode(prefix.ToUpper());
            int incodeid = bookingobj.Getinconame(txt_inco.Text.Trim().ToUpper());
            if (incodeid != 0 && hdn_Incoid.Value != "0")
            {
                txt_uno.Focus();
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid INCO');", true);
                txt_inco.Text = "";
                txt_inco.Focus();
                blnerr = true;
                return;

            }
        }
        private void Fn_Clear()
         {

            txt_date.Text = Utility.fn_ConvertDate(da_obj_Log.GetDate().ToString());
            txt_booking.Text = "";
            txt_customer.Text = "";
            //txtbranchoff.se = "0";
            Fn_Loadbranch();
            txt_branchaddress.Text = "";
            ddl_type.SelectedValue = "0";


            txt_shipper.Text = "";
            txt_consignee.Text = "";
            txtsaddress.Text = "";
            txtcaddress.Text = "";
            txt_notify.Text = "";
            txtnaddress.Text = "";

            txt_por.Text = "";

            txt_pol.Text = "";
            txt_pod.Text = "";
            txt_fd.Text = "";
            txt_noofpkg.Text = "";
            txt_pkg.Text = "";
            txt_wt.Text = "";
            txt_approx_volume.Text = "";
            txt_inco.Text = "";
            txt_uno.Text = "";
            ddlhya.SelectedValue = "0";
            txt_tues.Text = "";
            txt_cartons.Text = "";
            txt_marks.Text = "";           


              hdn_Incoid.Value ="0";
              hid_por.Value = "0";

              hid_pol.Value = "0";
              hid_pod.Value = "0";
              hid_fd.Value = "0";

              hf_customerid.Value = "0";
              Hiddenshipper.Value = "0";
              Hiddenconsignee.Value = "0";
              Hiddennotify.Value = "0";
        }

        protected void txt_customer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (hf_customerid.Value != "0")
                {
                    txt_marks.Focus();
                }
                else
                {
                    
                    txt_customer.Text = "";
                    txt_customer.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid Customer');", true);
                    blnerr = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Fn_Clear();
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn btn-booking";
        }

        protected void txt_por_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = port.GetPortName(txt_por.Text.ToUpper());
                if (dt.Rows.Count > 0 || hid_por.Value != "0")
                {
                    hid_por.Value = dt.Rows[0]["portid"].ToString();
                    txt_pol.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "alert", "alertify.alert('Invalid Place of Receipt');", true);
                    txt_por.Text = "";
                    txt_por.Focus();
                    blnerr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_pol_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = port.GetPortName(txt_pol.Text.ToUpper());
                if (dt.Rows.Count > 0 && hid_pol.Value != "0")
                {
                    hid_pol.Value = dt.Rows[0]["portid"].ToString();
                    txt_pod.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "alert", "alertify.alert('Invalid Port of Loading');", true);
                    txt_pol.Text = "";
                    txt_pol.Focus();
                    blnerr = true;
                    return;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_pod_TextChanged(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = new DataTable();
                dt = port.GetPortName(txt_pod.Text.ToUpper());
                if (dt.Rows.Count > 0 && hid_pod.Value != "0")
                {
                    hid_pod.Value = dt.Rows[0]["portid"].ToString();
                    txt_fd.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "alert", "alertify.alert('Invalid Port of Discharge');", true);
                    txt_pod.Text = "";
                    txt_pod.Focus();
                    blnerr = true;
                    return;


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_fd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = port.GetPortName(txt_fd.Text.ToUpper());
                if (dt.Rows.Count > 0 && hid_fd.Value != "0")
                {
                    hid_fd.Value = dt.Rows[0]["portid"].ToString();
                    txt_shipper.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "alert", "alertify.alert('Invalid Place of Delivery');", true);
                    txt_fd.Text = "";
                    txt_fd.Focus();
                    blnerr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_booking_TextChanged(object sender, EventArgs e)
        {
             DataTable dt = new DataTable();
             dt = obj_da_Podetails.getbookingdetails(txt_booking.Text.ToUpper());
                if (dt.Rows.Count > 0 )
                {
                    txt_customer.Text = dt.Rows[0]["customername"].ToString();
                    txtbranchoff.SelectedItem.Text = dt.Rows[0]["branch"].ToString();
                    txt_branchaddress.Text = dt.Rows[0]["branchname"].ToString();

                    txt_branchaddress.Text = dt.Rows[0]["branchname"].ToString();
                    ddl_type.SelectedValue = dt.Rows[0]["stype"].ToString();
                    txt_por.Text = dt.Rows[0]["pol"].ToString();
                    txt_pol.Text = dt.Rows[0]["por"].ToString();
                    txt_pod.Text = dt.Rows[0]["pod"].ToString();
                    txt_fd.Text = dt.Rows[0]["fd"].ToString();

                    txt_shipper.Text = dt.Rows[0]["shipper"].ToString();
                    txtsaddress.Text = dt.Rows[0]["saddress"].ToString();

                    txt_consignee.Text = dt.Rows[0]["consignee"].ToString();
                    txtcaddress.Text = dt.Rows[0]["caddress"].ToString();

                    txt_notify.Text = dt.Rows[0]["notifyparty"].ToString();
                    txtnaddress.Text = dt.Rows[0]["naddress"].ToString();

                    txt_marks.Text = dt.Rows[0]["marksno"].ToString();
                    txt_noofpkg.Text = dt.Rows[0]["noofpks"].ToString();
                    txt_pkg.Text = dt.Rows[0]["packageid"].ToString();
                    txt_wt.Text = dt.Rows[0]["grweight"].ToString();
                    txt_approx_volume.Text = dt.Rows[0]["ntweight"].ToString();
                    hdn_Incoid.Value = dt.Rows[0]["inco"].ToString();
                    DataTable dtinco = new DataTable();
                    dtinco = bookingobj.SelMasterInco(Convert.ToInt32(hdn_Incoid.Value));
                    if (dtinco.Rows.Count > 0)
                    {
                        txt_inco.Text = dtinco.Rows[0]["incocode"].ToString();
                    }
                  
                    txt_uno.Text = dt.Rows[0]["uno"].ToString();
                    ddlhya.SelectedValue = dt.Rows[0]["approved"].ToString();
                    txt_tues.Text = dt.Rows[0]["portname1"].ToString();
                    txt_cartons.Text = dt.Rows[0]["cargodet"].ToString();

                    hid_por.Value = dt.Rows[0]["por1"].ToString();

                    hid_pol.Value = dt.Rows[0]["pol1"].ToString();
                    hid_pod.Value = dt.Rows[0]["pod1"].ToString();
                    hid_fd.Value = dt.Rows[0]["fd1"].ToString();

                    hf_customerid.Value = dt.Rows[0]["customerid"].ToString();
                    Hiddenshipper.Value = dt.Rows[0]["shipperid"].ToString();
                    Hiddenconsignee.Value = dt.Rows[0]["consigneeid"].ToString();
                    Hiddennotify.Value = dt.Rows[0]["notifypartyid"].ToString();


                    if (dt.Rows[0]["bookingdate"] != System.DBNull.Value)
                    {
                        txt_date.Text = dt.Rows[0]["bookingdate"].ToString();
                    }
                    else
                    {
                        txt_date.Text = Utility.fn_ConvertDate(da_obj_Log.GetDate().ToString());
                    }

                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";

                    Fn_FillGrid();
                }

                else
                {
                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn btn-booking";
                }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
            string filePath = "";
            string filename = "";
            string[] filename1;

            string[] branchname;
            string branchnameshortname = "";

            string c = "";
            txtbranchoff_SelectedIndexChanged(sender,e);
            if (!upd_document.HasFile)
            {
                // Label2.Text = "Please Select File";                          //if file uploader has no file selected
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Select Document Path');", true);
                upd_document.Focus();
            }
            else
            {
                if (upd_document.HasFile)
                {

                    try
                    {
                        if (Path.GetExtension(upd_document.PostedFile.FileName).ToLower() != ".pdf")
                        {
                            ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Upload PDF Document');", true);
                            return;
                        }
                        string[] str_Item = new string[9];
                     

                        
                        

                        // Uploading.Uploading obj = new Uploading.Uploading();
                        DataAccess.Payroll.Details obj_da_Pay = new DataAccess.Payroll.Details();

                        DataAccess.Masters.MasterDocument obj_da_Document = new DataAccess.Masters.MasterDocument();
                        DataAccess.Documents obj_da_Doc = new DataAccess.Documents();

                        DataTable obj_dt = new DataTable();

                        if (btnSave.ToolTip == "Upload")
                        {

                            int int_Documentid = 0;


                            DataAccess.Documents obj_da_Document1 = new DataAccess.Documents();
                            DataTable obj_dt1 = new DataTable();


                            obj_dt1 = obj_da_Document1.GetDocDtls4ebooking(int.Parse(hid_branchid.Value), "E", txt_booking.Text);

                            if (obj_dt1.Rows.Count > 0)
                            {
                                string str = upd_document.PostedFile.FileName.ToString();
                                string withoutspecialcharacters = RemoveSpecialChars(str);


                                int_Documentid = Convert.ToInt32(obj_dt1.Rows.Count);
                                int_Documentid = int_Documentid + 1;
                                if (int_Documentid != 0)
                                {
                                    
                                   // filename = hf_customerid.Value + "-" + ddl_type.Text + "-" + upd_document.PostedFile.FileName.ToString() + "-" + int_Documentid + ".pdf";

                                    filename = hf_customerid.Value + "-" + ddl_type.Text + "-" + withoutspecialcharacters + "-" + int_Documentid + ".pdf";
                                }
                                
                            }
                            else
                            {

                                string str1 = upd_document.PostedFile.FileName.ToString();
                                string withoutspecialcharacters1 = RemoveSpecialChars(str1);

                                int_Documentid = int_Documentid+ 1;
                                // filename = hf_customerid.Value + "-" + ddl_type.Text + "-" + upd_document.PostedFile.FileName.ToString() + "-" + int_Documentid + ".pdf";
                                filename = hf_customerid.Value + "-" + ddl_type.Text + "-" + withoutspecialcharacters1 + "-" + int_Documentid + ".pdf";
                            }
                          

                          
                            if (filename != "")
                            {
                                int_Documentid = Convert.ToInt32(obj_da_Doc.InsebookingDocuments(Convert.ToInt32(hid_branchid.Value), "E", txt_booking.Text, int_Documentid, "Upload-Ebooking", ddl_type.SelectedItem.Text, filename, Session["username"].ToString(), "", txt_date.Text, ddl_type.SelectedItem.Text, txt_date.Text, Convert.ToInt32(Session["webgroupid"].ToString()), Convert.ToInt32(hf_customerid.Value), Convert.ToInt32(Hiddenshipper.Value), Convert.ToInt32(Hiddenconsignee.Value), Convert.ToInt32(Hiddennotify.Value)));//str_alltype
                                

                                upd_document.SaveAs(Server.MapPath("~/UploadDocument/Ebooking/" + filename));
                                c = (Server.MapPath("~/UploadDocument/Ebooking/") + filename);
                                try
                                {
                                    UploadFileToFTP(filename, c);
                                }
                                catch (Exception ex)
                                {
                                    lbl_DispMsg.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                                }
                                finally
                                {

                                    System.IO.File.Delete(c);
                                }


                                obj_da_Doc.updatefileforEbooking(int_Documentid, filename);
                                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Document Uploaded');", true);

                                
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('File not found');", true);
                                return;
                            }
                            Fn_FillGrid();

                        }

                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message.ToString();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                    }
                }
            }
            //btnclose.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel.Attributes["class"] = "btn ico-cancel";
        }

        protected void grpupdload_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdbudget, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grpupdload, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grpupdload_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                int index = grpupdload.SelectedRow.RowIndex;
                int docid, i, dcmtid;
                string Remarks, filenameloc;
                if (grpupdload.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    if (txt_booking.Text != "")
                    {
                        docid = Convert.ToInt32(grpupdload.Rows[index].Cells[2].Text);
                        Remarks = grpupdload.Rows[index].Cells[1].Text;
                        dcmtid = Convert.ToInt32(grpupdload.Rows[index].Cells[3].Text);                  

                        hid_poddownload.Value = grpupdload.Rows[index].Cells[4].Text;

                        if (hid_poddownload.Value != "")
                        {                            
                            fttnormaldwd();
                        }
                        else
                        {
                            
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('PoD not yet updated for this pickslip #');", true);
                            return;
                        }


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "EDI", "alertify.alert('Please Enter the Booking #');", true);
                        txt_booking.Focus();
                    }

                    
                }

            }
            catch (Exception ex)
            {

            }

        }

        protected void grpupdload_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
            if (e.CommandName == "Delete")
                {
                    ImageButton Img_delete = (ImageButton)e.CommandSource;
                    GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
                    DataTable obj_dt = new DataTable();
                    string filename = "";

                    obj_dt = (DataTable)Session["dt"];
                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                    DataAccess.Documents Dobj = new DataAccess.Documents();


                    DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
                    DataAccess.ForwardingExports.ISFDetails obj = new DataAccess.ForwardingExports.ISFDetails();
                    DataTable dt = new DataTable();
                    if (Session["LoginDivisionId"] != null)
                    {
                        intBranchID = HREmpobj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), txtbranchoff.SelectedItem.Text);
                        hid_branchid.Value = intBranchID.ToString();
                        dt = obj.GetBdtls(intBranchID);
                        txt_branchaddress.Text = dt.Rows[0]["address"].ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Branch');", true);
                    }

                    Dobj.Geteboookingdeleteftpdile(Convert.ToInt32(grpupdload.Rows[grd.RowIndex].Cells[3].Text), Convert.ToInt32(hid_branchid.Value), txt_booking.Text);


                    ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('File has been deleted');", true);
                    obj_dt.Rows[grd.RowIndex].Delete();
                    obj_dt.AcceptChanges();
                    filename = grpupdload.Rows[grd.RowIndex].Cells[4].Text;
                   
                    Fn_FillGrid();
                    ftpdeleted(filename);


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void grpupdload_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void fttnormaldwd()
        {

            using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
            {
                DBCS = reader.ReadLine();
            }

            ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
            dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
            username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
            password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();



            string str_path = "";
            string str_paths = "";
            string str_FileId, str_filename;
            str_filename = hid_poddownload.Value.Replace("&", "");            
            DataTable dt = new DataTable();


            str_path = Server.MapPath("~/UploadDocument/Ebooking/");

            string path = Server.MapPath("~/UploadDocument/Ebooking/" + str_filename);


            string ftp = "ftp://20.235.30.214/";
            //FTP Folder name. Leave blank if you want to Download file from root folder.
            string ftpFolder = "SL/Ebooking/";
            //try
            //{
            //Create FTP Request.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + str_filename);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            //Enter FTP Server credentials.
           // request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
            request.Credentials = new NetworkCredential(username, password);

            request.UsePassive = true;
            request.UseBinary = true;
            request.EnableSsl = false;

            //Fetch the Response and read it into a MemoryStream object.
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using (FileStream outputStream = new FileStream(path, FileMode.OpenOrCreate))
            using (Stream ftpStream = response.GetResponseStream())
            {
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
            }


            WebClient client = new WebClient();
            Byte[] buffer1 = client.DownloadData(path);
            if (buffer1 != null)
            {
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(path));
                Response.WriteFile(path);
                Response.Flush();



            }


            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            Response.End();




        }



        private void Fn_FillGrid()
        {
            try
            {
                DataAccess.Documents obj_da_Document = new DataAccess.Documents();
                DataTable obj_dt = new DataTable();

                DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
                DataAccess.ForwardingExports.ISFDetails obj = new DataAccess.ForwardingExports.ISFDetails();
                DataTable dt = new DataTable();
                if (Session["LoginDivisionId"] != null)
                {
                    intBranchID = HREmpobj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), txtbranchoff.SelectedItem.Text);
                    hid_branchid.Value = intBranchID.ToString();
                    dt = obj.GetBdtls(intBranchID);
                    txt_branchaddress.Text = dt.Rows[0]["address"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Branch');", true);
                }

                obj_dt = obj_da_Document.GetDocDtls4ebooking(int.Parse(hid_branchid.Value), "E", txt_booking.Text);
                
                
                 if (obj_dt.Rows.Count > 0)
                {
                  
                    grpupdload.DataSource = obj_dt;
                    grpupdload.DataBind();


                    Session["dt"] = obj_dt;


                   
                }
                else
                {
                    //Grd_Doc.DataSource = new DataTable();
                    //Grd_Doc.DataBind();

                    grpupdload.DataSource = new DataTable();
                    grpupdload.DataBind();
                    Session["dt"] = new DataTable();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }




        protected void ftpdeleted(string filename)
        {

            try
            {


                using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
                {
                    DBCS = reader.ReadLine();
                }

                ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
                dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
                username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
                password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();
           
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://20.235.30.214/SL/Ebooking/" + filename);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                //request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
                request.Credentials = new NetworkCredential(username, password);

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    //  return response.StatusDescription;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

       protected  void UploadFileToFTP(string source, string path)
        {
            try
            {

                using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SL\DB.txt"))
                {
                    DBCS = reader.ReadLine();
                }

                ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
                dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
                username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
                password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();
         
                String sourcefilepath = source; // e.g. "d:/test.docx"
                String ftpurl = "ftp://20.235.30.214/SL/Ebooking/" + sourcefilepath; // e.g. ftp://serverip/foldername/foldername
                String ftpusername = username; // e.g. username
                String ftppassword = password; // e.g. password



                string filename = Path.GetFileName(source);
                string ftpfullpath = ftpurl;
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);

                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                FileStream fs = File.OpenRead(path); //File.OpenRead(source);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();
                Stream ftpstream = ftp.GetRequestStream();
                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();

                //// get file bytes
                //byte[] fileBytes = File.ReadAllBytes(source);
                //ftp.ContentLength = fileBytes.Length;

                //Stream ftpstream = ftp.GetRequestStream();
                //ftpstream.Write(fileBytes, 0, fileBytes.Length);
                //ftpstream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public string RemoveSpecialChars(string str)
       {
           // Create  a string array and add the special characters you want to remove
           string[] chars = new string[] { " ", "-", ",", ".", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(", ")", ":", "|", "[", "]" };
           //Iterate the number of times based on the String array length.
           for (int i = 0; i < chars.Length; i++)
           {
               if (str.Contains(chars[i]))
               {
                   str = str.Replace(chars[i], "");
               }
           }
           return str;
       }


      
    }
}