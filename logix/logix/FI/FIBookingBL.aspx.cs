using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace logix.FI
{
    public partial class FIBookingBL : System.Web.UI.Page
    {
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterVessel obj_da_vessel = new DataAccess.Masters.MasterVessel();
        DataAccess.Marketing.FIBookingwithBL obj_da_FIB = new DataAccess.Marketing.FIBookingwithBL();
        DataAccess.Marketing.FIBookingwithBL obj_da_fib = new DataAccess.Marketing.FIBookingwithBL();
        DataAccess.Marketing.Booking obj_da_book = new DataAccess.Marketing.Booking();
        DataAccess.Masters.MasterPort obj_da_port = new DataAccess.Masters.MasterPort();
        DataAccess.Marketing.Booking obj_da_bkng = new DataAccess.Marketing.Booking();


        string Ctrl_List;
        string Msg_List;
        string Data_List;

        int int_branchid;
        int int_empid;
        int int_divisionid;
        int int_con;
        int int_vessel;
        int int_pol;
        int int_pod;
        int int_fd;

        string booking;
        string int_booking;
        string str_Trantype;
        string str_con;
        string str_vessel;
        char str_blstatus;

        DateTime etd;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Logobj.GetDataBase(Ccode);
                obj_da_mc.GetDataBase(Ccode);
                obj_da_vessel.GetDataBase(Ccode);
                obj_da_FIB.GetDataBase(Ccode);
                obj_da_fib.GetDataBase(Ccode);
                obj_da_book.GetDataBase(Ccode);
                obj_da_port.GetDataBase(Ccode);


                obj_da_bkng.GetDataBase(Ccode);
                //obj_da_cargo.GetDataBase(Ccode);
                //obj_da_cost.GetDataBase(Ccode);
                //FIJobobj.GetDataBase(Ccode);
                //Custobj1.GetDataBase(Ccode);


                //Vslobj.GetDataBase(Ccode);
                //HRFrontObj.GetDataBase(Ccode);
                //FIBLobj.GetDataBase(Ccode);
                //Portobj.GetDataBase(Ccode);
                //Pkgsobj.GetDataBase(Ccode);



            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            str_Trantype = Session["StrTranType"].ToString(); 
            if (!IsPostBack)
            { 
                Ctrl_List = txt_book.ID + "~" + txt_bdate.ID + "~" + txt_quot.ID + "~" + txt_qdate.ID + "~" + txt_bl.ID + "~" + txt_vessel.ID + "~" + txt_voyage.ID + "~" + txt_con.ID + "~" + txt_etd.ID + "~" + txt_pol.ID + "~" + txt_pod.ID + "~" + txt_fd.ID + "~" + txt_cbm.ID + "~" + txt_netwt.ID + "~" + txt_grosswt.ID + "~" + ddl_blstatus.ID ;
                Msg_List = "Booking #~Booking Date~Quotation~Quotation Date~BL #~Vessel~Voyage~Consignee~ETD~POL~POD~Place of Delivery~CBM~Net Wt~Gross Wt~BL status";
                Data_List = "string~string~string~string~string~Autocomplete~string~Autocomplete~string~string~string~string~int~int~int~ddl";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Data_List + "')");
                txt_cbm.Attributes.Add("onkeypress", "return validateFloatKeyPress(event);");
                txt_netwt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
                txt_grosswt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                txt_etd.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                txt_book.Focus();

                if (Request.QueryString.ToString().Contains("bookno"))
                {
                    txt_book.Text = Request.QueryString["bookno"].ToString();


                    if (Session["StrTranType"] == "FI")
                    {
                        txt_book_TextChanged(sender, e);
                    }

                } 



            }
            
               
            Mdl_Msg.Hide();
            Mdl_book.Hide();
            Mdl_Rev.Hide();
            if (Page.IsPostBack)
            {
                WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                int indx = wcICausedPostBack.TabIndex;
                var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                           where control.TabIndex > indx
                           select control;
                ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
            }
           
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
        [WebMethod]
        public static List<string> Get_Vessel(string prefix)
        {
            DataAccess.Masters.MasterVessel obj_da_mv = new DataAccess.Masters.MasterVessel();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_mv.GetDataBase(Ccode);
            DataTable obj_Dt = new DataTable();
            List<string> Bookingno = new List<string>();
            obj_Dt = obj_da_mv.GetLikeVessel(prefix);
            HttpContext.Current.Session["MVessel_Dt"] = obj_Dt;
            Bookingno = Utility.Fn_DatatableToList_int16(obj_Dt, "vesselname", "vesselid");
            return Bookingno;
        }

        [WebMethod]
        public static List<string> Get_Consignee(string prefix)
        {
            DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_mc.GetDataBase(Ccode);
            DataTable obj_Dt = new DataTable();
            List<string> Bookingno = new List<string>();
            obj_Dt = obj_da_mc.GetLikeCustomer(prefix);
            HttpContext.Current.Session["Cons_Dt"] = obj_Dt;
            Bookingno = Utility.Fn_DatatableToList(obj_Dt, "customer", "customerid");
            return Bookingno;
        }
        [WebMethod]
        public static List<string> GetBookingdetails(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Marketing.Booking obj_da_book = new DataAccess.Marketing.Booking();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_book.GetDataBase(Ccode);

            obj_dt = obj_da_book.GetLikeBooking("FI", prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()));

            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "shiprefno");
            return List_Result;
        }
        protected void txt_con_TextChanged(object sender, EventArgs e)
        {
           
            try
            {
            //DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
            DataTable obj_Dt = new DataTable();
            
           

                //int cutid = obj_da_mc.GetCustomerid(txt_con.Text.Trim().ToUpper());
                //if (cutid != 0)
                obj_Dt = obj_da_mc.GetexactCustomer(txt_con.Text.ToUpper());
               if (obj_Dt.Rows.Count > 0 && hf_conid.Value != "0")
                {                   
                    txt_etd.Focus();
                } 
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Consignee');", true);
                    txt_con.Text = "";
                    txt_con.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip=="Cancel")
            {
                txtclear();
                btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                txt_book.Focus();
            }
            else
            {
              //  this.Response.End();
                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "CS")
                    {
                        if (Session["StrTranType"] != null)
                        {
                            if (Session["StrTranType"].ToString() == "FI")
                            {
                                Response.Redirect("../Home/OICSHome.aspx");
                            }

                        }
                    }
                }
                else
                {
                    this.Response.End();
                }
            }
        }

        private void txtclear()
        {
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            txt_bl.Enabled = true;
            btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            txt_etd.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
            txt_book.Text = "";
            txt_bdate.Text = "";
            txt_quot.Text = "";
            txt_qdate.Text = "";
            txt_bl.Text = "";
            txt_vessel.Text = "";
            txt_voyage.Text = "";
            txt_con.Text = "";
            txt_pol.Text = "";
            txt_pod.Text = "";
            txt_fd.Text = "";
            txt_cbm.Text = "";
            txt_grosswt.Text = "";
            txt_netwt.Text = "";
            ddl_blstatus.SelectedIndex = 0;
            txt_remarks.Text = "";

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.Masters.MasterVessel obj_da_vessel = new DataAccess.Masters.MasterVessel();
                //DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
                //DataAccess.Marketing.FIBookingwithBL obj_da_FIB = new DataAccess.Marketing.FIBookingwithBL();
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                 if (ddl_blstatus.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Kindly Select BL Status');", true);
                    ddl_blstatus.Focus();
                    return;
                }
                 else if (ddl_blstatus.SelectedItem.Text == "Surrendered")
                {
                    str_blstatus = Convert.ToChar("S");
                }
                else if (ddl_blstatus.Text == "Release")
                {
                    str_blstatus = Convert.ToChar("R");
                }
                
                int_vessel = obj_da_vessel.GetVesselid(txt_vessel.Text);
                etd = Convert.ToDateTime(Utility.fn_ConvertDatetime( txt_etd.Text));
                int_con = obj_da_mc.GetCustomerIdFrmName(txt_con.Text);
                if (Convert.ToDouble(txt_cbm.Text) >100.00)
                {
                    txt_cbm.Text = "";
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('CBM should not be Greater than 100');", true);
                    txt_cbm.Focus();
                    return;
                }
                
                if (btn_save.ToolTip == "Save")
                {
                    obj_da_FIB.InsFIBookingWithBL(txt_book.Text.ToUpper(), txt_bl.Text.ToUpper(), int_vessel, txt_voyage.Text.ToUpper(), etd, int_con, Convert.ToDouble(txt_cbm.Text), Convert.ToDouble(txt_grosswt.Text), Convert.ToDouble(txt_netwt.Text), str_blstatus, txt_remarks.Text.ToUpper(), int_branchid, int_divisionid);
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved');", true);
                    Logobj.InsLogDetail(int_empid, 762, 1, int_branchid, txt_book.Text.Substring((txt_book.Text.Length) - 5, 5) + "/" + txt_bl.Text);
                    txtclear();
                }
                else
                {
                    obj_da_FIB.UpdFIBookingWithBL(txt_book.Text.ToUpper(), txt_bl.Text.ToUpper(), int_vessel, txt_voyage.Text.ToUpper(), etd, int_con, Convert.ToDouble(txt_cbm.Text), Convert.ToDouble(txt_grosswt.Text), Convert.ToDouble(txt_netwt.Text), str_blstatus, txt_remarks.Text.ToUpper(), int_branchid, int_divisionid);
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated');", true);
                    Logobj.InsLogDetail(int_empid, 762, 2, int_branchid, txt_book.Text.Substring((txt_book.Text.Length) - 5, 5) + "/" + txt_bl.Text);
                    //btn_save.Text = "Save";

                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                    txtclear();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txt_bl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_book.Text != "" && txt_bl.Text != "")
                {
                    int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                    int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());

                    DataTable obj_dt_fib = new DataTable();
                    //DataAccess.Marketing.FIBookingwithBL obj_da_fib = new DataAccess.Marketing.FIBookingwithBL();
                    //DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
                    obj_dt_fib = obj_da_fib.SelFIBkgwithBlDtls(int_branchid, "BL", txt_bl.Text, int_divisionid);
                    if (obj_dt_fib.Rows.Count > 0)
                    {
                        if (obj_dt_fib.Rows[0]["bookingno"].ToString() == txt_book.Text)
                        {
                            txt_vessel.Text = obj_dt_fib.Rows[0]["vesselname"].ToString();
                            txt_voyage.Text = obj_dt_fib.Rows[0]["voy"].ToString();
                            txt_con.Text = obj_dt_fib.Rows[0]["customername"].ToString();
                            int_con = obj_da_mc.GetCustomerIdFrmName(txt_con.Text);
                            txt_etd.Text = obj_dt_fib.Rows[0]["etd"].ToString();
                            txt_cbm.Text = obj_dt_fib.Rows[0]["cbm"].ToString();
                            txt_grosswt.Text = obj_dt_fib.Rows[0]["grweight"].ToString();
                            txt_netwt.Text = obj_dt_fib.Rows[0]["netweight"].ToString();
                            ddl_blstatus.Text = obj_dt_fib.Rows[0]["blstatus"].ToString();
                            txt_remarks.Text = obj_dt_fib.Rows[0]["remarks"].ToString();
                            btn_save.Text = "Update";
                            btn_save.ToolTip = "Update";
                            btn_save1.Attributes["class"] = "btn btn-update1";
                            btn_save.Focus();

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('BL Already assigned for another Booking');", true);
                            txt_bl.Text = "";
                            txt_vessel.Text = "";
                            txt_voyage.Text = "";
                            txt_cbm.Text = "";
                            txt_netwt.Text = "";
                            txt_grosswt.Text = "";
                            txt_remarks.Text = "";
                            txt_con.Text = "";
                            ddl_blstatus.SelectedValue = "0";
                            txt_bl.Focus();
                            btn_save.Text = "Save";
                            btn_save.ToolTip = "Save";
                            btn_save1.Attributes["class"] = "btn ico-save";
                        }
                    }
                    else
                    {
                        txt_vessel.Focus();
                        btn_cancel.Text = "Cancel";
                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                }
                else
                {
                    txt_vessel.Focus();
                    btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_vessel_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int_vessel = Convert.ToInt32(hf_vessel.Value);
                str_vessel = hf_vesselname.Value;
                txt_vessel.Text = str_vessel;
                int consigid = Convert.ToInt32(hf_vessel.Value);
                if (consigid == 0 || hf_vessel.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select Correct Vessel Name');", true);
                    txt_vessel.Text = "";
                    txt_vessel.Focus();
                    //DataAccess.Masters.MasterVessel obj_da_vessel = new DataAccess.Masters.MasterVessel();
                    //int_vessel = obj_da_vessel.GetVesselid(txt_vessel.Text);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_book_Click(object sender, EventArgs e)
        {
            Load_Book();
        }

        protected void Load_Book()
        {
            try
            {
                
                grd_book.Visible = true;
                str_Trantype = Session["StrTranType"].ToString();
                DataTable obj_dt_book = new DataTable();
                //DataAccess.Marketing.Booking obj_da_book = new DataAccess.Marketing.Booking();
                obj_dt_book = obj_da_book.GetBookingPending(str_Trantype, int_branchid);
                if (obj_dt_book.Rows.Count > 0)
                {
                    this.Mdl_book.Show();
                    grd_book.DataSource = obj_dt_book;
                    grd_book.DataBind();
                    ViewState["book"] = obj_dt_book;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(lnk_book, typeof(LinkButton), "Valid", "alertify.alert('Booking Not Available');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_book_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void btn_rbook_Click(object sender, EventArgs e)
        {
            Load_Rev();
        }

        protected void Load_Rev()
        {
            try
            {
                
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                DataTable obj_dt_bookbl = new DataTable();
                //DataAccess.Marketing.FIBookingwithBL obj_da_fib = new DataAccess.Marketing.FIBookingwithBL();
                obj_dt_bookbl = obj_da_fib.SelBookingBLDtls(int_branchid, int_divisionid);
                if (obj_dt_bookbl.Rows.Count > 0)
                {
                    this.Mdl_Rev.Show();
                    grd_rev.DataSource = obj_dt_bookbl;
                    grd_rev.DataBind();
                    ViewState["bookrev"] = obj_dt_bookbl;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('No more Booking available');", true);
                }
                Logobj.InsLogDetail(int_empid, 762, 1, int_branchid, txt_book.Text.Substring((txt_book.Text.Length) - 5, 5) + "/" + txt_bl.Text);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_rev_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void btn_yes1_Click(object sender, EventArgs e)
        {
            try
            {
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                booking = hf_msg1.Value.ToString();
                //DataAccess.Marketing.FIBookingwithBL obj_da_fib = new DataAccess.Marketing.FIBookingwithBL();
                DataTable obj_dt_fib = new DataTable();
                obj_da_fib.DelBLfromBooking(int_branchid, int_divisionid, booking);
                obj_dt_fib = obj_da_fib.SelBookingBLDtls(int_branchid, int_divisionid);
                grd_rev.DataSource = obj_dt_fib;
                grd_rev.DataBind();
                this.Mdl_Rev.Show();
                txtclear();
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_book_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                str_Trantype = Session["StrTranType"].ToString();

                int index;
                index = Convert.ToInt32(grd_book.SelectedRow.RowIndex.ToString());
                DataSet ds;
                //DataAccess.Marketing.FIBookingwithBL obj_da_fib = new DataAccess.Marketing.FIBookingwithBL();
                DataTable obj_dt1 = new DataTable();
                DataTable obj_dt2 = new DataTable();
                ds = obj_da_fib.CheckBLExistToDelete(((Label)grd_book.Rows[index].Cells[0].FindControl("Booking")).Text);


                if (ds.Tables.Count > 0)
                {
                    obj_dt1 = ds.Tables[0];
                    obj_dt2 = ds.Tables[1];
                }
                if (obj_dt1.Rows.Count > 0 || obj_dt2.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('You Cannot Update This BL #');", true);
                    return;
                }

                if (grd_book.Rows.Count > 0)
                {
                    //DataAccess.Marketing.Booking obj_da_book = new DataAccess.Marketing.Booking();
                    //DataAccess.Masters.MasterPort obj_da_port = new DataAccess.Masters.MasterPort();
                    //DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
                    DataTable obj_dt_book = new DataTable();
                    DataTable obj_dt_bl = new DataTable();
                    txtclear();
                    int_booking = ((Label)grd_book.Rows[index].Cells[0].FindControl("Booking")).Text;
                    //grd_book.Rows[index].Cells[0].Text;
                    obj_dt_bl = obj_da_fib.SelBlno(int_booking);
                    if (obj_dt_bl.Rows.Count > 0)
                    {
                        txt_bl.Text = obj_dt_bl.Rows[0]["blno"].ToString();
                    }

                    grd_book.Visible = false;
                    txt_book.Text = int_booking;
                    obj_dt_book = obj_da_book.GetBookingDetails(int_booking, str_Trantype, int_branchid);
                    if (obj_dt_book.Rows.Count > 0)
                    {
                        txt_bdate.Text = (Convert.ToDateTime(obj_dt_book.Rows[0]["bookingdate"])).ToString("dd/MM/yyyy");
                        txt_quot.Text = obj_dt_book.Rows[0]["quotno"].ToString();
                        txt_qdate.Text = (Convert.ToDateTime(obj_dt_book.Rows[0]["quotdate"])).ToString("dd/MM/yyyy");
                        int_pol = Convert.ToInt32(obj_dt_book.Rows[0]["pol"].ToString());
                        txt_pol.Text = obj_da_port.GetPortname(int_pol);
                        int_pod = Convert.ToInt32(obj_dt_book.Rows[0]["pod"].ToString());
                        txt_pod.Text = obj_da_port.GetPortname(int_pod);
                        int_fd = Convert.ToInt32(obj_dt_book.Rows[0]["fd"].ToString());
                        txt_fd.Text = obj_da_port.GetPortname(int_fd);
                        grd_book.Visible = false;
                        btn_save.Focus();
                        DataTable obj_dt_fibl = new DataTable();
                        obj_dt_fibl = obj_da_fib.SelFIBkgwithBlDtls(int_branchid, "", txt_bl.Text, int_divisionid);
                        if (obj_dt_fibl.Rows.Count > 0)
                        {
                            if (obj_dt_fibl.Rows[0]["bookingno"].ToString() == txt_book.Text)
                            {
                                txt_bl.Text = obj_dt_fibl.Rows[0]["blno"].ToString();
                                txt_vessel.Text = obj_dt_fibl.Rows[0]["vesselname"].ToString();
                                txt_voyage.Text = obj_dt_fibl.Rows[0]["voy"].ToString();
                                txt_con.Text = obj_dt_fibl.Rows[0]["customername"].ToString();
                                int_con = obj_da_mc.GetCustomerIdFrmName(txt_con.Text);
                                txt_etd.Text = (Convert.ToDateTime(obj_dt_fibl.Rows[0]["etd"])).ToString("dd/MM/yyyy");
                                txt_cbm.Text = obj_dt_fibl.Rows[0]["cbm"].ToString();
                                txt_grosswt.Text = obj_dt_fibl.Rows[0]["grweight"].ToString();
                                txt_netwt.Text = obj_dt_fibl.Rows[0]["netweight"].ToString();
                                ddl_blstatus.Text = obj_dt_fibl.Rows[0]["blstatus"].ToString();
                                txt_remarks.Text = obj_dt_fibl.Rows[0]["remarks"].ToString();
                                btn_save.Text = "Update";
                                btn_save.ToolTip = "Update";
                                btn_save1.Attributes["class"] = "btn btn-update1";
                            }
                        }
                    }
                    else
                    {
                        DataTable obj_dt_bk = new DataTable();
                        //DataAccess.Marketing.Booking obj_da_bkng = new DataAccess.Marketing.Booking();
                        obj_dt_book = obj_da_bkng.GetBookingDetails(int_booking, str_Trantype, int_branchid);
                        if (obj_dt_bk.Rows.Count > 0)
                        {
                            txt_bdate.Text = obj_dt_bk.Rows[0][11].ToString();
                            txt_bdate.Text = obj_dt_bk.Rows[0]["bookingdate"].ToString();
                            txt_quot.Text = obj_dt_bk.Rows[0]["quotno"].ToString();
                            txt_qdate.Text = obj_dt_bk.Rows[0]["quotdate"].ToString();
                            int_pol = Convert.ToInt32(obj_dt_bk.Rows[0]["pol"].ToString());
                            txt_pol.Text = obj_da_port.GetPortname(int_pol);
                            int_pod = Convert.ToInt32(obj_dt_bk.Rows[0]["pod"].ToString());
                            txt_pod.Text = obj_da_port.GetPortname(int_pod);
                            int_fd = Convert.ToInt32(obj_dt_bk.Rows[0]["fd"].ToString());
                            txt_fd.Text = obj_da_port.GetPortname(int_fd);
                            grd_book.Visible = false;
                        }
                    }
                    txt_bl.Focus();
                    btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_rev_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds;
                DataTable obj_dt1 = new DataTable();
                DataTable obj_dt2 = new DataTable();
                //DataAccess.Marketing.FIBookingwithBL obj_da_fib = new DataAccess.Marketing.FIBookingwithBL();
                int index;
                index = Convert.ToInt32(grd_rev.SelectedRow.RowIndex.ToString());
                ds = obj_da_fib.CheckBLExistToDelete(grd_rev.Rows[index].Cells[1].Text);
                this.Mdl_Rev.Show();
                if (ds.Tables.Count > 0)
                {
                    obj_dt1 = ds.Tables[0];
                    obj_dt2 = ds.Tables[1];
                }

                if (obj_dt1.Rows.Count > 0 || obj_dt2.Rows.Count > 0)
                {
                    
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('You Cannot Delete This BL #');", true);
                    return;
                }
                pnl_msg1.Visible = true;
                Mdl_Msg.Show();
                // Mdl_Msg1.Show();
                booking = grd_rev.Rows[index].Cells[0].Text;
                hf_msg1.Value = booking;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_book_TextChanged(object sender, EventArgs e)
        {

            DataSet ds;
            //DataAccess.Marketing.FIBookingwithBL obj_da_fib = new DataAccess.Marketing.FIBookingwithBL();
            DataTable obj_dt1 = new DataTable();
            DataTable obj_dt2 = new DataTable();
            ds = obj_da_fib.CheckBLExistToDelete(txt_book.Text);


            if (ds.Tables.Count > 0)
            {
                obj_dt1 = ds.Tables[0];
                obj_dt2 = ds.Tables[1];
            }
            if (obj_dt1.Rows.Count > 0 || obj_dt2.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('You Cannot Update This BL #');", true);
                return;
            }

          //  if (grd_book.Rows.Count > 0)
            //{
                //DataAccess.Marketing.Booking obj_da_book = new DataAccess.Marketing.Booking();
                //DataAccess.Masters.MasterPort obj_da_port = new DataAccess.Masters.MasterPort();
                //DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
                DataTable obj_dt_book = new DataTable();
                DataTable obj_dt_bl = new DataTable();
               // txtclear();
               // int_booking = ((Label)grd_book.Rows[index].Cells[0].FindControl("Booking")).Text;
                //grd_book.Rows[index].Cells[0].Text;
                obj_dt_bl = obj_da_fib.SelBlno(txt_book.Text);
                if (obj_dt_bl.Rows.Count > 0)
                {
                    txt_bl.Text = obj_dt_bl.Rows[0]["blno"].ToString();
                }

               // grd_book.Visible = false;
               // txt_book.Text = int_booking;
                obj_dt_book = obj_da_book.GetBookingDetails(txt_book.Text, str_Trantype, int_branchid);
                if (obj_dt_book.Rows.Count > 0)
                {
                    txt_bdate.Text = (Convert.ToDateTime(obj_dt_book.Rows[0]["bookingdate"])).ToString("dd/MM/yyyy");
                    txt_quot.Text = obj_dt_book.Rows[0]["quotno"].ToString();
                    txt_qdate.Text = (Convert.ToDateTime(obj_dt_book.Rows[0]["quotdate"])).ToString("dd/MM/yyyy");
                    int_pol = Convert.ToInt32(obj_dt_book.Rows[0]["pol"].ToString());
                    txt_pol.Text = obj_da_port.GetPortname(int_pol);
                    int_pod = Convert.ToInt32(obj_dt_book.Rows[0]["pod"].ToString());
                    txt_pod.Text = obj_da_port.GetPortname(int_pod);
                    int_fd = Convert.ToInt32(obj_dt_book.Rows[0]["fd"].ToString());
                    txt_fd.Text = obj_da_port.GetPortname(int_fd);
                    grd_book.Visible = false;
                    btn_save.Focus();
                    DataTable obj_dt_fibl = new DataTable();
                    obj_dt_fibl = obj_da_fib.SelFIBkgwithBlDtls(int_branchid, "", txt_bl.Text, int_divisionid);
                    if (obj_dt_fibl.Rows.Count > 0)
                    {
                        if (obj_dt_fibl.Rows[0]["bookingno"].ToString() == txt_book.Text)
                        {
                            txt_bl.Text = obj_dt_fibl.Rows[0]["blno"].ToString();
                            txt_vessel.Text = obj_dt_fibl.Rows[0]["vesselname"].ToString();
                            txt_voyage.Text = obj_dt_fibl.Rows[0]["voy"].ToString();
                            txt_con.Text = obj_dt_fibl.Rows[0]["customername"].ToString();
                            int_con = obj_da_mc.GetCustomerIdFrmName(txt_con.Text);
                            txt_etd.Text = (Convert.ToDateTime(obj_dt_fibl.Rows[0]["etd"])).ToString("dd/MM/yyyy");
                            txt_cbm.Text = obj_dt_fibl.Rows[0]["cbm"].ToString();
                            txt_grosswt.Text = obj_dt_fibl.Rows[0]["grweight"].ToString();
                            txt_netwt.Text = obj_dt_fibl.Rows[0]["netweight"].ToString();
                            ddl_blstatus.Text = obj_dt_fibl.Rows[0]["blstatus"].ToString();
                            txt_remarks.Text = obj_dt_fibl.Rows[0]["remarks"].ToString();
                            btn_save.Text = "Update";
                            btn_save.ToolTip = "Update";
                            btn_save1.Attributes["class"] = "btn btn-update1";
                        }
                    }
                }
                else
                {
                    DataTable obj_dt_bk = new DataTable();
                    //DataAccess.Marketing.Booking obj_da_bkng = new DataAccess.Marketing.Booking();
                    obj_dt_book = obj_da_bkng.GetBookingDetails(txt_book.Text, str_Trantype, int_branchid);
                    if (obj_dt_bk.Rows.Count > 0)
                    {
                        txt_bdate.Text = obj_dt_bk.Rows[0][11].ToString();
                        txt_bdate.Text = obj_dt_bk.Rows[0]["bookingdate"].ToString();
                        txt_quot.Text = obj_dt_bk.Rows[0]["quotno"].ToString();
                        txt_qdate.Text = obj_dt_bk.Rows[0]["quotdate"].ToString();
                        int_pol = Convert.ToInt32(obj_dt_bk.Rows[0]["pol"].ToString());
                        txt_pol.Text = obj_da_port.GetPortname(int_pol);
                        int_pod = Convert.ToInt32(obj_dt_bk.Rows[0]["pod"].ToString());
                        txt_pod.Text = obj_da_port.GetPortname(int_pod);
                        int_fd = Convert.ToInt32(obj_dt_bk.Rows[0]["fd"].ToString());
                        txt_fd.Text = obj_da_port.GetPortname(int_fd);
                        grd_book.Visible = false;
                    }
                }
                txt_bl.Focus();
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"]="btn ico-cancel";
            //}

        }

        
      

        protected void txt_grosswt_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddl_blstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_remarks_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grd_rev_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_rev, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_book_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_book, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_book_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_book.PageIndex = e.NewPageIndex;
            DataTable dt=(DataTable)ViewState["book"];
            grd_book.DataSource = dt;
            grd_book.DataBind();
            this.Mdl_book.Show();
        }

        protected void grd_rev_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_rev.PageIndex = e.NewPageIndex;
            DataTable dt = (DataTable)ViewState["bookrev"];
            grd_rev.DataSource = dt;
            grd_rev.DataBind();
            this.Mdl_Rev.Show();
        }

        protected void btn_no1_Click(object sender, EventArgs e)
        {
            this.Mdl_Rev.Show();
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


            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 762, "fibookingbl", txt_book.Text, txt_book.Text, Session["StrTranType"].ToString());

            if (txt_book.Text != "")
            {
                JobInput.Text = txt_book.Text;
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