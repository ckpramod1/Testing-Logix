using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Net.Mail;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using System.IO;
namespace logix.Sales
{
    public partial class SBinBooking : System.Web.UI.Page
    {
        DataAccess.ForwardingExports.ShippingBill ShippingBillobj = new DataAccess.ForwardingExports.ShippingBill();
        DataAccess.Masters.MasterPackages packageobj = new DataAccess.Masters.MasterPackages();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.ForwardingExports.StuffingConfirmation STufobj = new DataAccess.ForwardingExports.StuffingConfirmation();
        string bookno = "", agent="";
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            if (Request.QueryString.ToString().Contains("book") )
            {
                bookno = Request.QueryString["book"].ToString();
                agent = Request.QueryString["agent"].ToString();
                DataTable dt = STufobj.GetSBDetailsinbooking(0, bookno, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                //dt.DefaultView.RowFilter = "sbno='" + txt_sb.Text.Trim() + "'";

                Grd_sb.DataSource = dt;
                Grd_sb.DataBind();
            }
        }

        [WebMethod]
        public static List<string> Getpackage(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPackages obj_mpackage = new DataAccess.Masters.MasterPackages();
            dt = obj_mpackage.GetLikepackage(prefix);
            //List_Result = Utility.Fn_TableToList(prefix.ToUpper(), dt, "descn");
            List_Result = Utility.Fn_TableToList(dt, "descn", "packageid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> Getportname(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_portname = new DataAccess.Masters.MasterPort();
            dt = obj_portname.GetLikePort(prefix);
            List_Result = Utility.Fn_TableToList(dt, "portname", "portid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> Getexporter(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_mcustomer = new DataAccess.Masters.MasterCustomer();
            dt = obj_mcustomer.GetLikeIndianCustomer(prefix);
            List_Result = Utility.Fn_TableToList(dt, "customer", "customerid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GETShipbill(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable dt = new DataTable();
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            DataAccess.ForwardingExports.ShippingBill obj_shipbill = new DataAccess.ForwardingExports.ShippingBill();
            dt = obj_shipbill.GetLikeShipBillinbooking(prefix, bid, did);
            //List_Result = Utility.Fn_TableToList(prefix.ToUpper(), dt, "sbno");   
            List_Result = Utility.Fn_DatatableToList_Text(dt, "sbno");
            return List_Result;
        }


        protected void txt_sb_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtdetails = new DataTable();
            try
            {
                int intpkgs, intshipperid, intagentid, intpkg;
                
                string transtype = HttpContext.Current.Session["StrTranType"].ToString();
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
                 
                if (txt_sb.Text != "")
                {
                    dtdetails = ShippingBillobj.GetShippingBillinbooking(txt_sb.Text, bid, did);
                    if (dtdetails.Rows.Count != 0)
                    {

                        //bookno = txt_booking.Text;

                        intshipperid = Convert.ToInt32(dtdetails.Rows[0]["shipper"].ToString());
                        hd_exporter.Value = intshipperid.ToString();
                        txt_exporter.Text = customerobj.GetCustomername(intshipperid);
                        double initialValue = Convert.ToDouble(dtdetails.Rows[0]["grosswt"].ToString());
                        txt_weight.Text = initialValue.ToString("0.00");
                     //   txt_weight.Text = dtdetails.Rows[0]["grosswt"].ToString();
                        intpkgs = Convert.ToInt32(dtdetails.Rows[0]["pkgid"].ToString());
                        txt_pkgtype.Text = packageobj.GetPackagename(intpkgs);
                        txt_pkgs.Text = dtdetails.Rows[0]["noofpkg"].ToString();
                        intpkgs = Convert.ToInt32(dtdetails.Rows[0]["pld"].ToString());
                        txt_dest.Text = portobj.GetPortname(intpkgs);
                        int intagent = Convert.ToInt32(dtdetails.Rows[0]["agent"]);

                        //if(hd_customer.Value !="")
                        //if (dtdetails.Rows[0]["agent"].ToString() != "")
                        //{
                        //    txt_agent.Text = "";
                        //    intagentid = Convert.ToInt32(dtdetails.Rows[0]["agent"].ToString());
                        //    txt_agent.Text = customerobj.GetCustomername(intagentid);
                        //}

                        txt_volume.Text = dtdetails.Rows[0]["volume"].ToString();
                        txt_remarks.Text = dtdetails.Rows[0]["remarks"].ToString();

                        //if (dtdetails.Rows[0]["invpl"].ToString() == "y")
                        //{
                        //    chk_invoice.Checked = true;
                        //}
                        //else
                        //{
                        //    chk_invoice.Checked = false;
                        //}
                        //GetJobInfo();
                        //GetContExit();
                        //GetStuffDetails();
                        //btn_save.Text = "Update";
                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";
                        //Grd_sb.DataSource = dtdetails;
                        //Grd_sb.DataBind();

                    }
                    else
                    {

                        //btn_save.Text = "Save";
                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                        txt_pkgs.Text = "";
                        txt_pkgtype.Text = "";
                        txt_weight.Text = "";
                        txt_volume.Text = "";
                        txt_exporter.Text = "";
                        txt_dest.Text = "";
                        txt_sbdate.Focus();
                        txt_remarks.Text = "";
                        txt_sb.Enabled = true;


                    }
                }
                 
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
                return;
            }

        }
        protected void Grd_sb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexvalue;
            try
            {
                if (Grd_sb.Rows.Count > 0)
                {
                    indexvalue = Grd_sb.SelectedRow.RowIndex;
                   
                    txt_sb.Text = Grd_sb.Rows[indexvalue].Cells[0].Text;
                    txt_sbdate.Text = Grd_sb.Rows[indexvalue].Cells[1].Text;
                    txt_pkgs.Text = Grd_sb.Rows[indexvalue].Cells[4].Text;
                    txt_pkgtype.Text = Grd_sb.Rows[indexvalue].Cells[5].Text;
                    txt_weight.Text = Grd_sb.Rows[indexvalue].Cells[6].Text;
                    txt_volume.Text = Grd_sb.Rows[indexvalue].Cells[7].Text;
                    //txt_exporter.Text = Grd_sb.Rows[indexvalue].Cells[2].Text;
                    txt_dest.Text = Grd_sb.Rows[indexvalue].Cells[3].Text;
                    txt_exporter.Text = HttpUtility.HtmlDecode(Grd_sb.Rows[indexvalue].Cells[2].Text);
                   
                    if (HttpUtility.HtmlDecode(Grd_sb.Rows[indexvalue].Cells[9].Text) == "")
                    {
                        txt_remarks.Text = "";
                    }
                    else
                    {
                        txt_remarks.Text = Grd_sb.Rows[indexvalue].Cells[9].Text;
                    }
                     

                    //btn_save.Text = "Update";
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn ico-update";
                    txt_sb.Enabled = false;
                    

                }
               
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);

            }

        }
        protected void Grd_sb_RowDataBound(object sender, GridViewRowEventArgs e)
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

                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Imgsb");
                //lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_sb, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void txt_pkgtype_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MasterPackages packobj = new DataAccess.Masters.MasterPackages();
                int intpkgs = packobj.GetNPackageid(txt_pkgtype.Text);
             
                if (intpkgs != 0)
                {
                    txt_weight.Focus();

                }
                else
                {

                    txt_pkgtype.Text = "";
                    txt_pkgtype.Focus();
                    ScriptManager.RegisterStartupScript(txt_pkgtype, typeof(TextBox), "Valid", "alert('INVALID PACKAGE TYPE');", true);
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);

            }

        }

        protected void txt_dest_TextChanged(object sender, EventArgs e)
        {
            
            int custid = portobj.GetNPortid(txt_dest.Text.Trim().ToUpper());
            if (custid != 0)
            {
                txt_exporter.Focus();

            }
            else
            {

                txt_dest.Text = "";
                txt_dest.Focus();
                ScriptManager.RegisterStartupScript(txt_dest, typeof(TextBox), "Valid", "alert('INVALID DESTINATION NAME');", true);
            }
            //if (hd_dest.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", "alert('Select Correct Port Name');", true);
            //    return;
            //}
            //txt_dest.Focus();
        }
        protected void txt_exporter_TextChanged(object sender, EventArgs e)
        {
           
            int shipperid = customerobj.GetCustomerid(txt_exporter.Text.Trim().ToUpper());
            if (shipperid != 0)
            {
                txt_remarks.Focus();

            }
            else
            {
                ScriptManager.RegisterStartupScript(txt_exporter, typeof(TextBox), "Valid", "alert('INVALID Exporter');", true);
                txt_exporter.Text = "";
                txt_exporter.Focus();

            }

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
           
            DataTable dtdetails = new DataTable();
            DataTable dt = new DataTable();
            int intshipperid;
            DataAccess.Masters.MasterPackages packobj = new DataAccess.Masters.MasterPackages();
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            int empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            try
            {

                if (txt_exporter.Text == "")
                {
                    intshipperid = 0;
                }
                else
                {
                    intshipperid = customerobj.GetCustomerid(txt_exporter.Text);
                    if (intshipperid == 0)
                    {
                        ScriptManager.RegisterStartupScript(txt_exporter, typeof(TextBox), "Valid", "alert('INVALID Exporter NAME');", true);
                        txt_exporter.Text = "";
                        txt_exporter.Focus();

                        return;
                    }
                }
                if (txt_dest.Text != "")
                {
                    int cusdesttid = portobj.GetNPortid(txt_dest.Text);
                    if (cusdesttid == 0)
                    {
                        ScriptManager.RegisterStartupScript(txt_dest, typeof(TextBox), "Valid", "alert('INVALID DESTINATION NAME');", true);
                        txt_dest.Text = "";
                        txt_dest.Focus();

                        return;
                    }
                }
                if (txt_pkgs.Text == "")
                {
                    txt_pkgs.Text = "0";
                }
                //if (txt_pol.Text != "")
                //{
                //    int pol = portobj.GetNPortid(txt_pol.Text);
                //    if (pol == 0)
                //    {
                //        ScriptManager.RegisterStartupScript(txt_pol, typeof(TextBox), "Valid", "alert('INVALID PORT OF LOADING');", true);
                //        txt_pol.Text = "";
                //        txt_pol.Focus();

                //        return;
                //    }
                //}
                int intpkgs = packobj.GetNPackageid(txt_pkgtype.Text);
                int destid = portobj.GetNPortid(txt_dest.Text);
                if (btn_save.ToolTip == "Save")
                {
                    STufobj.InsertOEShipBillinbooking(bookno, txt_sb.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_sbdate.Text)), Convert.ToInt32(txt_pkgs.Text), intpkgs,
                        Convert.ToDouble(txt_weight.Text.ToString()),
                        txt_volume.Text, intshipperid, Convert.ToInt32(agent), destid, txt_remarks.Text, 'N', 0, bid, empid, did);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Details Saved!!');", true);
                    sbclear();
                }
                else
                {
                    STufobj.UpdateShipBillinbooking(txt_sb.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_sbdate.Text)), Convert.ToInt32(txt_pkgs.Text), intpkgs,
                         Convert.ToDouble(txt_weight.Text.ToString()),
                        txt_volume.Text, intshipperid, Convert.ToInt32(agent), destid, txt_remarks.Text, 'N', 0, bid, did);

                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alert('Details Updated');", true);
                    sbclear();
                }
               
            }

            catch (Exception ex)
            {


                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);

            }
        }
        private void sbclear()
        {
            txt_sb.Text = "";
            txt_sbdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());

            txt_pkgs.Text = "";
            txt_pkgtype.Text = "";
            txt_weight.Text = "";
            txt_volume.Text = "";
            txt_exporter.Text = "";
            txt_dest.Text = "";

            txt_remarks.Text = "";

        }
        protected void btn_clear_Click(object sender, EventArgs e)
        {
            sbclear();           
        }
        protected void btndelete_Click(object sender, EventArgs e)
        {
            if (txt_sb.Text!="")
            {
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());

                STufobj.DeleteShipBillinbooking( txt_sb.Text , bid, did);                 
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alert('Shipping Bill Deleted');", true);                             
                sbclear();
                DataTable dt = STufobj.GetSBDetailsinbooking(0, bookno, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));              
                Grd_sb.DataSource = dt;
                Grd_sb.DataBind();
            }
        }
      
    }
}