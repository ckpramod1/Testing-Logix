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
using DataAccess.HR;
using logix.CRMNew;
using System.ComponentModel;
using System.Web.Services.Description;


namespace logix
{
    public partial class Booking : System.Web.UI.Page
    {
        string strCtrlLst, strMsgLst, strDtypeLst;
        CustomerDataAccess.PODetails Logobj = new CustomerDataAccess.PODetails();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        CustomerDataAccess.RegCustomer regCustObj = new CustomerDataAccess.RegCustomer();
        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
        protected void Page_Load(object sender, EventArgs e)
        {


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                //Logobj.GetDataBase(Ccode);
                //regCustObj.GetDataBase(Ccode);
                da_obj_Log.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);

            }

            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            

            if (!IsPostBack)
            {
                Calendar date = new Calendar(this.Page, txt_date, Imgdate);

                Calendar cargodate = new Calendar(this.Page, txt_cargodate, Imgcargo);
                Calendar despatchdate = new Calendar(this.Page, txt_despatchdate, Imgdespatch);
                Calendar pickupdate = new Calendar(this.Page, txt_pickupdate, Imgpick);
                Calendar invoicedate = new Calendar(this.Page, txt_invoicedate, ImgInv);

                //txt_date.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                //txt_despatchdate.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                //txt_pickupdate.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                //txt_invoicedate.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                Grd.DataSource = new DataTable();
                Grd.DataBind();
                Session["data"] = null;
                strCtrlLst = "txt_date~txt_shipper~txt_consignee~txt_notify~txt_por~hid_por~txt_pol~hid_pol~txt_pod~hid_pod~txt_fd~hid_fd~txt_approx_volume~txt_cargodate~txt_despatchdate~txt_pickupdate~txt_inco~hid_inco";
                strDtypeLst = "Date~Text~Text~Text~Text~AutoComplete~Text~AutoComplete~Text~AutoComplete~Text~AutoComplete~Double~Date~Date~Date~Text~AutoComplete";
                strMsgLst = "Date~Shipper~Consignee~Notify~PoR~PoR~PoL~PoL~PoD~PoD~FD~FD~Volume~Cargo Received Date~Tentative Despatch Date~Tentative Pickup Date~Inco #~Inco #";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + strCtrlLst + "','" + strMsgLst + "','" + strDtypeLst + "') ;");

                strCtrlLst = "txt_invoice~txt_invoicedate~txt_PO~txt_style~txt_desc~txt_marks~txt_qty~txt_pkg~txt_wt~txt_cartons";
                strDtypeLst = "Text~Date~Text~Text~Text~Text~Integer~Text~Double~Integer";
                strMsgLst = "Invoice #~Invoice Date~PO #~Style~Description~Marks~Qty~Package~Weight~Cartons";
                btn_add.Attributes.Add("OnClick", "return IsValid('" + strCtrlLst + "','" + strMsgLst + "','" + strDtypeLst + "') ;");



            }
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

        protected void btn_save_Click(object sender, EventArgs e)
        {

            DateTime dt_date, dt_cargo, dt_despatch, dt_pickup, dt_invoice;
            dt_date = fn_ConvertDate(txt_date.Text);
            dt_cargo = fn_ConvertDate(txt_cargodate.Text);
            dt_despatch = fn_ConvertDate(txt_despatchdate.Text);
            dt_pickup = fn_ConvertDate(txt_pickupdate.Text);

            string str_trantype, str_Po, str_Style, str_Desc, str_invoice, str_unittype, str_remark, str_Marks;
            str_trantype = ddl_out.SelectedItem.Value.ToString() + ddl.SelectedItem.Value.ToString();
            int int_booikgno, int_Inco, int_pol, int_por, int_pod, int_fd, int_Pieces, int_cartons;
            double volume;
            float weight;
            int_Inco = int.Parse(hid_inco.Value);
            volume = double.Parse(txt_approx_volume.Text);

            int_pol = int.Parse(hid_pol.Value.ToString());
            int_pod = int.Parse(hid_pod.Value.ToString());
            int_por = int.Parse(hid_por.Value.ToString());
            int_fd = int.Parse(hid_fd.Value.ToString());
            DataAccess.ForwardingExports.PODetails obj_da_Podetails = new DataAccess.ForwardingExports.PODetails();
            int_booikgno = obj_da_Podetails.InsertBookingDetails_web(dt_date, str_trantype, volume, int_Inco, txt_remark.Text);

            if (int_booikgno > 0)
            {
                txt_booking.Text = int_booikgno.ToString();
                obj_da_Podetails.InsEBookingdetails(int_booikgno, int_por, int_pol, int_pod, int_fd, txt_shipper.Text, txt_consignee.Text, txt_notify.Text);

                foreach (GridViewRow row in Grd.Rows)
                {
                    str_invoice = row.Cells[0].Text;
                    dt_invoice = fn_ConvertDate(row.Cells[1].Text);
                    str_Po = row.Cells[2].Text;
                    str_Style = row.Cells[3].Text;
                    str_Desc = row.Cells[4].Text;
                    int_Pieces = int.Parse(row.Cells[5].Text);
                    int_cartons = int.Parse(row.Cells[7].Text);
                    weight = float.Parse(row.Cells[6].Text);
                    str_unittype = row.Cells[8].Text;
                    str_Marks = row.Cells[9].Text;
                    str_remark = row.Cells[10].Text;
                    obj_da_Podetails.InsPODetailsweb(int_booikgno.ToString(), str_Po, str_Style, int_Pieces, int_cartons, weight, str_Desc, str_trantype, str_invoice, dt_invoice, 67, 0, str_unittype, str_remark, dt_cargo, dt_despatch, dt_pickup, str_Marks);
                }
                //da_obj_Log.InsLogDetail(Convert.ToInt32(Session["webgroupid"].ToString()), 1, 1, Convert.ToInt32(Session["LoginDivisionId"]), "Booking" + "# -" + txt_booking.Text);
              

                regCustObj.InsWebCustLogDtl(Convert.ToInt32(Session["webgroupid"].ToString()), CustomerDataAccess.RegCustomer.EventType.LoginSuccess, DateTime.Now, Convert.ToInt32(Session["LoginDivisionId"])+ "Booking" + "# -" + txt_booking.Text);
            }
            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Save", "alertify.alert('Booking Created');", true);
           
            Fn_Clear();
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (Session["data"] == null)
            {
                dt.Columns.Add("invoiceno");
                dt.Columns.Add("invoicedate");
                dt.Columns.Add("pono");
                dt.Columns.Add("styleno");
                dt.Columns.Add("dimensions");
                dt.Columns.Add("pieces");
                dt.Columns.Add("weight");
                dt.Columns.Add("cartons");
                dt.Columns.Add("unittype");
                dt.Columns.Add("remarks");
                dt.Columns.Add("marksno");

                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                dr["invoiceno"] = txt_invoice.Text;
                dr["invoicedate"] = txt_invoicedate.Text;
                dr["pono"] = txt_PO.Text;
                dr["styleno"] = txt_style.Text;
                dr["dimensions"] = txt_desc.Text;
                dr["pieces"] = txt_qty.Text;
                dr["weight"] = txt_wt.Text;
                dr["cartons"] = txt_cartons.Text;
                dr["unittype"] = txt_pkg.Text;
                dr["remarks"] = txt_remarkpo.Text;
                dr["marksno"] = txt_marks.Text;

                Session["data"] = dt;
            }
            else
            {
                dt = (DataTable)Session["data"];
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                dr["invoiceno"] = txt_invoice.Text;
                dr["invoicedate"] = txt_invoicedate.Text;
                dr["pono"] = txt_PO.Text;
                dr["styleno"] = txt_style.Text;
                dr["dimensions"] = txt_desc.Text;
                dr["pieces"] = txt_qty.Text;
                dr["weight"] = txt_wt.Text;
                dr["cartons"] = txt_cartons.Text;
                dr["unittype"] = txt_pkg.Text;
                dr["remarks"] = txt_remarkpo.Text;
                dr["marksno"] = txt_marks.Text;
            }
            Grd.DataSource = dt;
            Grd.DataBind();
           // da_obj_Log.InsLogDetail(Convert.ToInt32(Session["webgroupid"].ToString()), 1, 1, Convert.ToInt32(Session["LoginDivisionId"]), "Booking" + "# -" + txt_booking.Text +"ADD" );

            regCustObj.InsWebCustLogDtl(Convert.ToInt32(Session["webgroupid"].ToString()), CustomerDataAccess.RegCustomer.EventType.LoginSuccess, DateTime.Now, Convert.ToInt32(Session["LoginDivisionId"]) + "Booking" + "# -" + txt_booking.Text + "ADD");
            Fn_Clear_Add();

        }
        private void Fn_Clear_Add()
        {
            txt_invoice.Text = "";
            txt_invoicedate.Text = fn_ConvertDateTime(DateTime.Now.ToString());
            txt_PO.Text = "";
            txt_style.Text = "";
            txt_desc.Text = "";
            txt_qty.Text = "";
            txt_wt.Text = "";
            txt_cartons.Text = "";
            txt_pkg.Text = "";
            txt_remarkpo.Text = "";
            txt_marks.Text = "";

        }
        private void Fn_Clear()
        {

            txt_date.Text = fn_ConvertDateTime(DateTime.Now.ToString());
            txt_shipper.Text = "";
            txt_consignee.Text = "";
            txt_notify.Text = "";
            txt_pol.Text = "";
            txt_por.Text = "";
            txt_pod.Text = "";
            txt_fd.Text = "";
            txt_approx_volume.Text = "";
            txt_inco.Text = "";
            txt_remark.Text = "";
            txt_cargodate.Text = txt_date.Text;
            txt_despatchdate.Text = txt_date.Text;
            txt_pickupdate.Text = txt_date.Text;
            Grd.DataSource = new DataTable();
            Grd.DataBind();
            Session["data"] = null;
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.Text == "Cancel")
            {
                txt_booking.Text = "";
                Fn_Clear();
                Fn_Clear_Add();
                btn_cancel.Text = "Back";
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

        }

        public static string fn_ConvertDateTime(string str_IPDate)
        {
            string str_OPDate = "";
            string[] datSrc;
            datSrc = str_IPDate.Split(' ');
            str_IPDate = datSrc[0];
            datSrc = str_IPDate.Split('/');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            str_OPDate = datSrc[1] + "/" + datSrc[0] + "/" + datSrc[2];
            return str_OPDate;
        }

        public static DateTime fn_ConvertDate(string str_IPDate)
        {
            string str_OPDate = "";
            string[] datSrc;
            datSrc = str_IPDate.Split(' ');
            str_IPDate = datSrc[0];
            datSrc = str_IPDate.Split('/');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            str_OPDate = datSrc[1] + "/" + datSrc[0] + "/" + datSrc[2];
            return DateTime.Parse(str_OPDate);
        }
    }
}