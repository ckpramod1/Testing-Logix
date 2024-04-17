using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;
using DataAccess;
using System.Runtime.Remoting;

namespace logix.AE
{
    public partial class AEJobInfo : System.Web.UI.Page
    {
        DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.ForwardingImports.JobInfo da_obj_jobinfo = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.Marketing.Booking book = new DataAccess.Marketing.Booking();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.ForwardingExports.JobInfo obj_da_Job = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.Masters.MasterBranch mb = new DataAccess.Masters.MasterBranch();
        DataAccess.ForwardingExports.JobInfo objdirct = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
        string str_trantype;
        string str_status;
        string str_status1;
        string str_airline;
        string str_mawblno;
        string mawbldate;
        string str_flightno;
        string str_flightdate;
        string str_agent;
        string str_handlinginfo;
        string str_fromport;
        string str_toport;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_txtdtmfdate;
        string str_Uiid = "", str_FornName;
        Boolean brr;
        string sendqry;
        DataTable dtbk = new DataTable();
        int branchid;
        DataTable dsJob = new DataTable();
        DataTable dt_search = new DataTable();
        int bookno;
        int custid;
        string booking, book_select = "";
        string directbl, notify;
        string subject = "";
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
        DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
        DataAccess.Reportasp objRpt = new DataAccess.Reportasp();
        DataAccess.Accounts.Invoice da_obj_INVobj = new DataAccess.Accounts.Invoice();
        DataAccess.ForwardingExports.BLDetails objbl = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
       
        DataAccess.AirImportExports.AIEBLDetails da_obj_blobj = new DataAccess.AirImportExports.AIEBLDetails();
        DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.UserPermission userperobj = new DataAccess.UserPermission();
        DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCargo da_obj_cargoobj = new DataAccess.Masters.MasterCargo();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.ChangeJob.ChangeJob obj_da_changejob = new DataAccess.ChangeJob.ChangeJob();
        DataAccess.AirImportExports.AIEBLDetails da_obj_AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
        DataAccess.Accounts.Invoice obj_inv = new DataAccess.Accounts.Invoice();

        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_Logobj.GetDataBase(Ccode);
                da_obj_customerobj.GetDataBase(Ccode);
                da_obj_jobinfo.GetDataBase(Ccode);
                book.GetDataBase(Ccode);
                portobj.GetDataBase(Ccode);
                obj_da_Job.GetDataBase(Ccode);
                mb.GetDataBase(Ccode);
                objdirct.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);
                da_obj_AEJobobj.GetDataBase(Ccode);

                INVOICEobj.GetDataBase(Ccode);
                obj_da_Log1.GetDataBase(Ccode);
                objRpt.GetDataBase(Ccode);
                da_obj_INVobj.GetDataBase(Ccode);
                INVOICEobj.GetDataBase(Ccode);
                objbl.GetDataBase(Ccode);
                da_obj_employeeobj.GetDataBase(Ccode);
                da_obj_hrempobj.GetDataBase(Ccode);
                da_obj_vesselobj.GetDataBase(Ccode);
                da_obj_blobj.GetDataBase(Ccode);
                hrempobj.GetDataBase(Ccode);
                userperobj.GetDataBase(Ccode);
                da_obj_Customer.GetDataBase(Ccode);
                da_obj_cargoobj.GetDataBase(Ccode);
                obj_MasterPort.GetDataBase(Ccode);
                da_obj_portobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                obj_da_changejob.GetDataBase(Ccode);
                da_obj_AEBLobj.GetDataBase(Ccode);
                obj_inv.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();dropdownButton();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "//FormMain.aspx','_top');", true);
            }
            if (Request.QueryString.ToString().Contains("type"))
            {
                lblheader.Text = Request.QueryString["type"].ToString();
            }
            if (Request.QueryString.ToString().Contains("AEbl"))
            {
                lblheader.Text = Request.QueryString["AEbl"].ToString();
            }



            if (IsPostBack != true)
            {

                try
                {

                    Ctrl_List = txt_mawbno.ID + "~" + txt_airline.ID + "~" + hf_airlineid.ID + "~" + txt_flightno.ID + "~" + txt_agent.ID + "~" + ddl_cmbstatus.ID + "~" + txt_from.ID + "~" + txt_to.ID;          //txt_handlinginfo.ID + "~" +



                    Msg_List = "MAWBL#~AirLineName~Air LineName~Flight#~Agent~status~From Port~ToPort";  // ~Handling info
                    Dtype_List = "string~string~Autocomplete~string~string~string~Dropdown~string~string~string";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");

                    txt_jobno.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    //Grd_buying_popup.Hide();
                    txt_dtjobdate.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());
                    txt_dtdate.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());
                    txt_dtfdate.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());
                    txt_dtmfdate.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());
                    txtmawbdate.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());

                    if (Request.QueryString.ToString().Contains("type"))
                    {
                        lblheader.Text = Request.QueryString["type"].ToString();
                    }
                    //Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, null);
                     btn_back.Text = "Cancel";

                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                    txt_jobno.Focus();
                    UserRights();



                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        HeaderLabel1.InnerText = "Ocean Exports";
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        HeaderLabel1.InnerText = "Ocean Imports";
                    }
                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        HeaderLabel1.InnerText = "Air Exports";
                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        HeaderLabel1.InnerText = "Air Imports";
                    }
                    BindBooking();
                    if (Request.QueryString.ToString().Contains("back"))
                    {
                        txt_jobno.Text = Request.QueryString["job"].ToString();
                        if(txt_jobno.Text!="")
                        {
                            txt_jobno_TextChanged(sender, e);
                        }
                        
                    }
                    if (Request.QueryString.ToString().Contains("JobDetails"))
                    {
                        lblheader.Text = " Job Info";
                        hidbooking.Value = Request.QueryString["bookingno"].ToString();
                        custid = Convert.ToInt32(Request.QueryString["Cusid"].ToString());
                        txt_search.Text = hidbooking.Value;
                        Booking_select();
                        return;

                    }
                }

                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
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
        }




        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {

                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    Boolean btn_delete;
                    btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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
        public static List<string> Getcusname(string prefix)
        {
            string custtype = "C";
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_customerobj.GetDataBase(Ccode);
            obj_dt = da_obj_customerobj.GetLikeIndianCustomer(prefix);
            customer = Utility.Fn_TableToList(obj_dt, "customername", "customerid");
            return customer;
        }

        [WebMethod]
        public static List<string> Getagentname(string prefix, string strcustype)
        {
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_customerobj.GetDataBase(Ccode);

            strcustype = "P";

            obj_dt = da_obj_customerobj.GetLikeCustomer(prefix.ToUpper(), strcustype);
            customer = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            return customer;
        }

        [WebMethod]
        public static List<string> Getportname(string prefix)
        {
            List<string> portname = new List<string>();
            DataTable obj_dtl = new DataTable();
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_portobj.GetDataBase(Ccode);
            obj_dtl = da_obj_portobj.GetLikePort(prefix);
            portname = Utility.Fn_DatatableToList_int16(obj_dtl, "portname", "portid");
            return portname;
        }

        [WebMethod]
        public static List<string> FE_GetBookingNo(string prefix, string job)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            bookingobj.GetDataBase(Ccode);
            obj_dt = bookingobj.GetBookingnosearch(prefix.Trim().ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()), HttpContext.Current.Session["StrTranType"].ToString());
            HttpContext.Current.Session["shiprefno"] = obj_dt;
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "shiprefno");
            return List_Result;
        }

        protected void Close_voucher_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Session["amendmbl"].ToString()))
            {
                txt_mawbno.Text = Session["amendmbl"].ToString();
            }
           
        }
        protected void Booking_select()
        {
            branchid = Convert.ToInt32(Session["LoginBranchid"]);
            //dtbk = book.GETBookingNofordock(branchid, "FE", custid, 0);
            dtbk = book.GETBookingNoJobInfo4task(branchid, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginEmpId"]));
            grdBookJob.DataSource = dtbk;
            grdBookJob.DataBind();

            for (int i = 0; i < dtbk.Rows.Count; i++)
            {
                booking = grdBookJob.Rows[i].Cells[1].Text;
                if (Request.QueryString["bookingno"].ToString() == booking)
                {
                    book_select = grdBookJob.Rows[i].Cells[1].Text;
                    CheckBox chkRow = (grdBookJob.Rows[i].Cells[3].FindControl("ChkMail") as CheckBox);
                    chkRow.Checked = true;
                    //book_select = grdBookJob.Rows[0].Cells[1].Text;
                }

            }
            Booking_fill();
        }


        protected void Booking_fill()
        {
            string status = "";
            dtbk = obj_da_Job.get_getdetailsforemptyjobbookingAE(int.Parse(Session["LoginBranchid"].ToString()), book_select, Session["StrTranType"].ToString());
            if (dtbk.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtbk.Rows[0]["agent"].ToString()))
                {
                    txt_agent.Text = dtbk.Rows[0]["agent"].ToString();
                }
                if (!string.IsNullOrEmpty(dtbk.Rows[0]["agentid"].ToString()))
                {
                    hf_agentid.Value = dtbk.Rows[0]["agentid"].ToString();
                }

                if (!string.IsNullOrEmpty(dtbk.Rows[0]["mlo"].ToString()))
                {
                    txt_airline.Text = dtbk.Rows[0]["mlo"].ToString();
                }
                if (!string.IsNullOrEmpty(dtbk.Rows[0]["mloid"].ToString()))
                {
                    hf_airlineid.Value = dtbk.Rows[0]["mloid"].ToString();
                }
                if (!string.IsNullOrEmpty(dtbk.Rows[0]["pol"].ToString()))
                {
                    txt_from.Text = dtbk.Rows[0]["pol"].ToString();
                }

                if (!string.IsNullOrEmpty(dtbk.Rows[0]["polid"].ToString()))
                {
                    hf_intfromid.Value = dtbk.Rows[0]["polid"].ToString();
                }

                if (!string.IsNullOrEmpty(dtbk.Rows[0]["pod"].ToString()))
                {
                    txt_to.Text = dtbk.Rows[0]["pod"].ToString();
                }
                if (!string.IsNullOrEmpty(dtbk.Rows[0]["podid"].ToString()))
                {

                    hf_inttoid.Value = dtbk.Rows[0]["podid"].ToString();
                }
                if (!string.IsNullOrEmpty(dtbk.Rows[0]["fstatus"].ToString()))
                {
                    status = dtbk.Rows[0]["fstatus"].ToString();
                }


                if (status == "C")
                {
                    ddl_cmbstatus.SelectedValue = "T";
                }
                else
                {
                    ddl_cmbstatus.SelectedValue = "P";
                }
            }


        }
        protected void lbl_lnkrate_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            Panelreuse.Visible = false;
            Bindgrid();
        }
        protected void txt_jobno_TextChanged(object sender, EventArgs e)
        {
            Get_grd_airline();
            getbldetails();
        }

        public void Bindgrid()
        {

            str_trantype = Session["StrTranType"].ToString();
            //DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
            DataTable Dt = new DataTable();


            if (str_trantype == "AE")
            {

                Dt = da_obj_AEJobobj.GetAIEAllDetails("AE", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (Dt.Rows.Count > 0)
                {
                    this.programmaticModalCancelCredit.Show();
                    grd_airline.DataSource = Dt;
                    grd_airline.DataBind();
                    ViewState["Job"] = Dt;
                    grd_airline.Visible = true;
                    //Grd_buying_popup.Show();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Job Not Available')", true);
                }

            }
            else
            {
                Dt = da_obj_AEJobobj.GetAIEAllDetails("AI", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (Dt.Rows.Count > 0)
                {
                    this.programmaticModalCancelCredit.Show();
                    grd_airline.DataSource = Dt;
                    grd_airline.DataBind();
                    grd_airline.Visible = true;
                    //Grd_buying_popup.Show();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Job Not Available')", true);
                }
            }
            UserRights();
        }


        public void Bindgridreuse()
        {
            str_trantype = Session["StrTranType"].ToString();
         //   DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
            DataTable Dt = new DataTable();


            if (str_trantype == "AE")
            {

                Dt = da_obj_AEJobobj.GetAIEAllDetails("AE", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (Dt.Rows.Count > 0)
                {
                    this.programmaticModalCancelCredit.Show();
                    Grd_reuse.DataSource = Dt;
                    Grd_reuse.DataBind();
                    ViewState["Job"] = Dt;
                    Grd_reuse.Visible = true;
                    //Grd_buying_popup.Show();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Job Not Available')", true);
                }

            }
            else
            {
                Dt = da_obj_AEJobobj.GetAIEAllDetails("AI", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (Dt.Rows.Count > 0)
                {
                    this.programmaticModalCancelCredit.Show();
                    Grd_reuse.DataSource = Dt;
                    Grd_reuse.DataBind();
                    Grd_reuse.Visible = true;
                    //Grd_buying_popup.Show();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Job Not Available')", true);
                }
            }
            UserRights();
        }



        protected void btn_save_Click(object sender, EventArgs e)
        {
            str_trantype = Session["StrTranType"].ToString();

            int count = 0, intBooking, branchid;
            branchid = Convert.ToInt32(Session["LoginBranchid"]);
            try
            {
                DataTable obj_dt = new DataTable();
                DataTable DtA_Details = new DataTable();
               // DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
                assign();
                CheckMBL();

                if (hf_blnMBL.Value == "true")
                {
                    hf_blnMBL.Value = "false";
                    return;
                }
                txt_airline_TextChanged(sender, e);
                txt_agent_TextChanged(sender, e);
                txt_from_TextChanged(sender, e);
                txt_to_TextChanged(sender, e);
                if (brr == true)
                {
                    brr = false;
                    return;
                }
                if (ddl_cmbstatus.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please Select status')", true);
                    return;
                }

                txt_mawbno.Text = txt_mawbno.Text.Trim();
                if (txt_mawbno.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Enter the correct MAWBL # ');", true);
                    txt_mawbno.Focus();
                    return;
                }



                //if (ddl_DropAE.SelectedIndex == 0)
                //{
                //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please Select JobProfit')", true);
                //    return;
                //}

                if (str_trantype == "AE")
                {
                    DateTime cur_date;
                    cur_date = Convert.ToDateTime(Utility.fn_ConvertDate(txt_dtfdate.Text));
                    if (cur_date >= DateTime.Now.AddDays(-30))
                    {
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please Enter valid flightdate')", true);
                        txt_dtfdate.Focus();
                        return;
                    }
                }
                //obj_dt = da_obj_customerobj.GetLikeCustomer(txt_airline.Text, "L");
                //if (obj_dt.Rows.Count == 0)
                //{
                if (hf_airlineid.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please Enter Valid AIRLINE NAME')", true);
                    txt_airline.Text = "";
                    txt_airline.Focus();
                    return;
                }
                //obj_dt = da_obj_customerobj.GetLikeCustomer(txt_agent.Text, "P");
                //if (obj_dt.Rows.Count == 0)
                //{                
                if (hf_agentid.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please Enter Valid Agent name')", true);
                    txt_agent.Text = "";
                    txt_agent.Focus();
                    return;
                }
                if (portobj.GetNPortid(txt_from.Text.ToUpper()) == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please Enter Valid Port of Loading')", true);
                    txt_from.Text = "";
                    txt_from.Focus();
                    return;
                }
                if (portobj.GetNPortid(txt_to.Text.ToUpper()) == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please Enter Valid Place of Destination')", true);
                    txt_to.Text = "";
                    txt_to.Focus();
                    return;
                }

                if (!string.IsNullOrEmpty(txt_from.Text) && !string.IsNullOrEmpty(txt_to.Text))
                {
                    if (txt_from.Text.ToString() == txt_to.Text.ToString())
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Load and Destination Port Should be Different')", true);
                        txt_to.Focus();
                        return;
                    }
                }


                DataTable Dtne1 = new DataTable();

                Dtne1 = da_obj_AEJobobj.getLikeAIEblnojob(txt_mawbno.Text.Trim().ToUpper(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                if (Dtne1.Rows.Count > 0)
                {
                    for (int i = 0; i <= Dtne1.Rows.Count - 1; i++)
                    {
                        if (txt_mawbno.Text.ToUpper() == Dtne1.Rows[i][0].ToString().ToUpper())
                        {
                            txt_mawbno.Text = "";
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('HAWBL # and MAWB # should not Same,kindly change MAWB # in Job screen');", true);
                            txt_mawbno.Focus();
                            return;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(txt_jobno.Text))
                {
                    //DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
                    if (INVOICEobj.CheckClosedJobs(Convert.ToString(str_trantype), Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString())) == 1)
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Job has been Closed Already" + "You Can not Update the Job Details')", true);
                        return;
                    }
                }


                if (str_trantype == "AE")
                {
                    // txt_jobno.Text = "";
                    if (grdBookJob.Rows.Count > 0)
                    {
                        for (int i = 0; i <= grdBookJob.Rows.Count - 1; i++)
                        {
                            CheckBox chkRowtest = (grdBookJob.Rows[i].Cells[3].FindControl("ChkMail") as CheckBox);
                            if (chkRowtest.Checked == true)
                            {
                                count = 1;
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Booking Number empty');", true);
                        count = 0;

                    }

                    if (count == 0)
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select Booking Number');", true);
                        count = 0;
                        return;
                    }
                    if (chk_directbl.Checked == true)
                    {
                        directbl = "Y";
                    }
                    else
                    {
                        directbl = "N";
                    }
                    if (chk_notify.Checked == true)
                    {
                        notify = "Y";
                    }
                    else
                    {
                        notify = "N";
                    }


                    if (btn_save.ToolTip == "Save")
                    {
                        txt_jobno.Text = "";

                        if (txt_dtfdate2.Text.Trim() == "")
                        {
                            hf_jobno.Value = da_obj_AEJobobj.InsAIEJobInfo(Convert.ToInt32(hf_airlineid.Value), Convert.ToString(str_mawblno.ToUpper()),
                           Convert.ToDateTime(Utility.fn_ConvertDatetime(txtmawbdate.Text)), Convert.ToString(str_flightno), Convert.ToDateTime(Utility.fn_ConvertDatetime(str_flightdate)),
                           Convert.ToInt32(hf_agentid.Value), Convert.ToString(str_status), Convert.ToString(str_handlinginfo), Convert.ToInt32(hf_intfromid.Value),
                           Convert.ToInt32(hf_inttoid.Value), "AE", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtjobdate.Text)), txt_iatacarrier.Text, txt_manifestno.Text,
                           Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtmfdate.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()),
                           Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()),
                           Convert.ToInt32(Session["LoginDivisionId"].ToString())).ToString();
                        }
                        else
                        {
                            hf_jobno.Value = da_obj_AEJobobj.InsAIEJobInfo(Convert.ToInt32(hf_airlineid.Value), Convert.ToString(str_mawblno.ToUpper()),
                           Convert.ToDateTime(Utility.fn_ConvertDatetime(txtmawbdate.Text)), Convert.ToString(str_flightno), Convert.ToDateTime(Utility.fn_ConvertDatetime(str_flightdate)),
                           Convert.ToInt32(hf_agentid.Value), Convert.ToString(str_status), Convert.ToString(str_handlinginfo), Convert.ToInt32(hf_intfromid.Value),
                           Convert.ToInt32(hf_inttoid.Value), "AE", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtjobdate.Text)), txt_iatacarrier.Text, txt_manifestno.Text,
                           Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtmfdate.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()),
                           Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()),
                           Convert.ToInt32(Session["LoginDivisionId"].ToString()), txt_flightno2.Text, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtfdate2.Text))).ToString();

                            

                        }

                        txt_jobno.Text = hf_jobno.Value;




                        //DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
                        //DataAccess.Reportasp objRpt = new DataAccess.Reportasp();
                        hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());

                        objRpt.InsOEeventdetailsTask(Convert.ToInt32(txt_jobno.Text), txt_search.Text.ToString(), "", "Job Updation",
                   Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), 0, "", 24);



                        da_obj_jobinfo.updjobinfoprofit("AE", Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), str_status1, 0);

                        objdirct.updjobindirectnotify(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), directbl.ToString(), notify.ToString());

                        //da_obj_AEJobobj.InsAIEJobInfodirectnotify(Convert.ToInt32(hf_jobno.Value),Convert.ToInt32(Session["LoginBranchid"].ToString(),directbl,notify);

                        da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 5, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_mawbno.Text + " Sav");
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved')", true);
                        //txt_jobno.Text = hf_jobno.Value;
                        SendDeleiveryStatus();
                        if (txt_jobno.Text != "")
                        {

                            if (grdBookJob.Rows.Count > 0)
                            {
                                for (int i = 0; i <= grdBookJob.Rows.Count - 1; i++)
                                {
                                    CheckBox chkRow = (grdBookJob.Rows[i].Cells[3].FindControl("ChkMail") as CheckBox);
                                    if (chkRow.Checked == true)
                                    {
                                        intBooking = Convert.ToInt32(grdBookJob.Rows[i].Cells[0].Text);
                                        book.UpdJobInComBooking(intBooking, Convert.ToInt32(txt_jobno.Text), str_trantype, branchid, 2);
                                    }
                                }
                                // ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Booking Details Updated');", true);

                                BindBooking();
                                getbookingassigned();
                            }
                            else
                            {
                                grdBookJob.DataSource = new DataTable();
                                grdBookJob.DataBind();
                            }

                        }
                    }
                    else
                    {


                        hf_jobno.Value = txt_jobno.Text;
                        if (txt_dtfdate2.Text.Trim() == "")
                        {
                            da_obj_AEJobobj.UpdAIEJobInfo(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(hf_airlineid.Value), Convert.ToString(str_mawblno.ToUpper()),
                           Convert.ToDateTime(Utility.fn_ConvertDatetime(txtmawbdate.Text)), Convert.ToString(str_flightno), Convert.ToDateTime(Utility.fn_ConvertDatetime(str_flightdate)),
                           Convert.ToInt32(hf_agentid.Value), Convert.ToString(str_status), Convert.ToString(str_handlinginfo), Convert.ToInt32(hf_intfromid.Value),
                           Convert.ToInt32(hf_inttoid.Value), "AE", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtjobdate.Text)), txt_iatacarrier.Text, txt_manifestno.Text,
                          Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtmfdate.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()),

                           Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else
                        {
                            da_obj_AEJobobj.UpdAIEJobInfo(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(hf_airlineid.Value), Convert.ToString(str_mawblno.ToUpper()),
                         Convert.ToDateTime(Utility.fn_ConvertDatetime(txtmawbdate.Text)), Convert.ToString(str_flightno), Convert.ToDateTime(Utility.fn_ConvertDatetime(str_flightdate)),
                         Convert.ToInt32(hf_agentid.Value), Convert.ToString(str_status), Convert.ToString(str_handlinginfo), Convert.ToInt32(hf_intfromid.Value),
                         Convert.ToInt32(hf_inttoid.Value), "AE", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtjobdate.Text)), txt_iatacarrier.Text, txt_manifestno.Text,
                        Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtmfdate.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()),

                         Convert.ToInt32(Session["LoginDivisionId"].ToString()), txt_flightno2.Text, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtfdate2.Text)));
                        }

                        da_obj_jobinfo.updjobinfoprofit("AE", Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), str_status1, 0);
                        objdirct.updjobindirectnotify(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), directbl.ToString(), notify.ToString());
                        da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 5, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_mawbno.Text + " Upd");
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated')", true);
                         btn_save.Text = "Save";
                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                        if (txt_jobno.Text != "")
                        {

                            if (grdBookJob.Rows.Count > 0)
                            {
                                for (int i = 0; i <= grdBookJob.Rows.Count - 1; i++)
                                {
                                    CheckBox chkRow = (grdBookJob.Rows[i].Cells[3].FindControl("ChkMail") as CheckBox);
                                    if (chkRow.Checked == true)
                                    {
                                        intBooking = Convert.ToInt32(grdBookJob.Rows[i].Cells[0].Text);
                                        book.UpdJobInComBooking(intBooking, Convert.ToInt32(txt_jobno.Text), str_trantype, branchid, 2);
                                    }
                                }
                                // ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Booking Details Updated');", true);

                                BindBooking();
                                getbookingassigned();
                            }
                            else
                            {
                                grdBookJob.DataSource = new DataTable();
                                grdBookJob.DataBind();
                            }

                        }

                    }
                }
                else
                {




                    


                   /* if (grdBookJob.Rows.Count > 0)   hided for AI --sindhu
                    {
                        for (int i = 0; i <= grdBookJob.Rows.Count - 1; i++)
                        {
                            CheckBox chkRowtest = (grdBookJob.Rows[i].Cells[3].FindControl("ChkMail") as CheckBox);
                            if (chkRowtest.Checked == true)
                            {
                                count = 1;
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Booking Number empty');", true);
                        count = 0;


                    }

                    if (count == 0)
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select Booking Number');", true);
                        count = 0;
                        return;
                    }*/
                    

                    if (chk_directbl.Checked == true)
                    {
                        directbl = "Y";
                    }
                    else
                    {
                        directbl = "N";
                    }
                    if (chk_notify.Checked == true)
                    {
                        notify = "Y";
                    }
                    else
                    {
                        notify = "N";
                    }

                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Booking Number empty');", true);
                    //    count = 1;

                    //}

                    //if (count == 0)
                    //{
                    //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select Booking No');", true);
                    //    count = 0;
                    //    return;
                    //}

                    if (btn_save.ToolTip == "Save")
                    {
                        txt_jobno.Text = "";
                        if (txt_dtfdate2.Text.Trim() == "")
                        {
                            txt_jobno.Text = da_obj_AEJobobj.InsAIEJobInfo(Convert.ToInt32(hf_airlineid.Value), Convert.ToString(str_mawblno.ToUpper()),
                                Convert.ToDateTime(Utility.fn_ConvertDatetime(txtmawbdate.Text)), Convert.ToString(str_flightno), Convert.ToDateTime(Utility.fn_ConvertDatetime(str_flightdate)),
                                Convert.ToInt32(hf_agentid.Value), Convert.ToString(str_status), Convert.ToString(str_handlinginfo), Convert.ToInt32(hf_intfromid.Value),
                                Convert.ToInt32(hf_inttoid.Value), "AI", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtjobdate.Text)), txt_iatacarrier.Text, txt_manifestno.Text,
                                Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtmfdate.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()),
                                Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString())).ToString();

                        }
                        else
                        {
                            txt_jobno.Text = da_obj_AEJobobj.InsAIEJobInfo(Convert.ToInt32(hf_airlineid.Value), Convert.ToString(str_mawblno.ToUpper()),
                            Convert.ToDateTime(Utility.fn_ConvertDatetime(txtmawbdate.Text)), Convert.ToString(str_flightno), Convert.ToDateTime(Utility.fn_ConvertDatetime(str_flightdate)),
                            Convert.ToInt32(hf_agentid.Value), Convert.ToString(str_status), Convert.ToString(str_handlinginfo), Convert.ToInt32(hf_intfromid.Value),
                            Convert.ToInt32(hf_inttoid.Value), "AI", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtjobdate.Text)), txt_iatacarrier.Text, txt_manifestno.Text,
                            Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtmfdate.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()),
                            Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), txt_flightno2.Text, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtfdate2.Text))).ToString();

                        }

                        da_obj_jobinfo.updjobinfoprofit("AI", Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), str_status1, 0);
                        hf_jobno.Value = txt_jobno.Text;
                        objdirct.updjobindirectnotify(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), directbl.ToString(), notify.ToString());

                        da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 7, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_mawbno.Text + " Sav");
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved')", true);
                        SendDeleiveryStatus();

                        if (txt_jobno.Text != "")
                        {

                            if (grdBookJob.Rows.Count > 0)
                            {
                                for (int i = 0; i <= grdBookJob.Rows.Count - 1; i++)
                                {
                                    CheckBox chkRow = (grdBookJob.Rows[i].Cells[3].FindControl("ChkMail") as CheckBox);
                                    if (chkRow.Checked == true)
                                    {
                                        intBooking = Convert.ToInt32(grdBookJob.Rows[i].Cells[0].Text);
                                        book.UpdJobInComBooking(intBooking, Convert.ToInt32(txt_jobno.Text), str_trantype, branchid, 2);
                                    }
                                }
                                // ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Booking Details Updated');", true);

                                BindBooking();
                                getbookingassigned();
                            }
                            else
                            {
                                grdBookJob.DataSource = new DataTable();
                                grdBookJob.DataBind();
                            }

                        }

                    }
                    else
                    {
                        hf_jobno.Value = txt_jobno.Text;

                        if (txt_dtfdate2.Text.Trim() == "")
                        {
                            da_obj_AEJobobj.UpdAIEJobInfo(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(hf_airlineid.Value), Convert.ToString(str_mawblno.ToUpper()),
                                Convert.ToDateTime(Utility.fn_ConvertDatetime(txtmawbdate.Text)), Convert.ToString(str_flightno), Convert.ToDateTime(Utility.fn_ConvertDatetime(str_flightdate)),
                                Convert.ToInt32(hf_agentid.Value), Convert.ToString(str_status), Convert.ToString(str_handlinginfo), Convert.ToInt32(hf_intfromid.Value),
                                Convert.ToInt32(hf_inttoid.Value), "AI", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtjobdate.Text)), txt_iatacarrier.Text, txt_manifestno.Text,
                                Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtmfdate.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));


                        }
                        else
                        {
                            da_obj_AEJobobj.UpdAIEJobInfo(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(hf_airlineid.Value), Convert.ToString(str_mawblno.ToUpper()),
                              Convert.ToDateTime(Utility.fn_ConvertDatetime(txtmawbdate.Text)), Convert.ToString(str_flightno), Convert.ToDateTime(Utility.fn_ConvertDatetime(str_flightdate)),
                              Convert.ToInt32(hf_agentid.Value), Convert.ToString(str_status), Convert.ToString(str_handlinginfo), Convert.ToInt32(hf_intfromid.Value),
                              Convert.ToInt32(hf_inttoid.Value), "AI", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtjobdate.Text)), txt_iatacarrier.Text, txt_manifestno.Text,
                              Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtmfdate.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), txt_flightno2.Text, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dtfdate2.Text)));

                        }
                        da_obj_jobinfo.updjobinfoprofit("AI", Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), str_status1, 0);
                        objdirct.updjobindirectnotify(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), directbl.ToString(), notify.ToString());
                        da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 7, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_mawbno.Text + " Upd");
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated')", true);
                         btn_save.Text = "Save";

                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                        if (txt_jobno.Text != "")
                        {

                            if (grdBookJob.Rows.Count > 0)
                            {
                                for (int i = 0; i <= grdBookJob.Rows.Count - 1; i++)
                                {
                                    CheckBox chkRow = (grdBookJob.Rows[i].Cells[3].FindControl("ChkMail") as CheckBox);
                                    if (chkRow.Checked == true)
                                    {
                                        intBooking = Convert.ToInt32(grdBookJob.Rows[i].Cells[0].Text);
                                        book.UpdJobInComBooking(intBooking, Convert.ToInt32(txt_jobno.Text), str_trantype, branchid, 2);
                                    }
                                }
                                // ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Booking Details Updated');", true);

                                BindBooking();
                                getbookingassigned();
                            }
                            else
                            {
                                grdBookJob.DataSource = new DataTable();
                                grdBookJob.DataBind();
                            }

                        }
                    }
                }
                txt_jobno.Focus();
                //btn_save.Enabled = false;
                //btn_save.ForeColor = System.Drawing.Color.Gray;
                // btn_save.Enabled = false;
                 btn_save.Text = "Update";
                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                 btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                UserRights();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }



        public void assign()
        {
            str_airline = txt_airline.Text;
            str_mawblno = txt_mawbno.Text.Trim();
            //txtmawbdate.Text = txt_dtdate.Text;
            str_flightno = txt_flightno.Text;
            str_flightdate = txt_dtfdate.Text;
            str_agent = txt_agent.Text;
            if (ddl_cmbstatus.SelectedValue == "T")
            {
                str_status = "T";
            }
            else if (ddl_cmbstatus.SelectedValue == "P")
            {
                str_status = "P";
            }

            if (CHk_DropAIR.Checked == false)
            {
                str_status1 = "O";
            }
            else if (CHk_DropAIR.Checked == true)
            {
                str_status1 = "P";
            }
            else
            {
                str_status1 = "";
            }


            str_handlinginfo = txt_handlinginfo.Text;
            str_fromport = txt_from.Text;
            str_toport = txt_to.Text;
            str_txtdtmfdate = txt_dtmfdate.Text;
        }

        public void CheckMBL()
        {
            str_trantype = Session["StrTranType"].ToString();
           // DataAccess.Accounts.Invoice da_obj_INVobj = new DataAccess.Accounts.Invoice();
            DataTable Dt = new DataTable();
            if (txt_mawbno.Text.ToUpper().Trim().ToString() != "")
            {
                 btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                btn_save.Enabled = true;
                btn_save.ForeColor = System.Drawing.Color.White;
                Dt = da_obj_INVobj.CheckMblno(txt_mawbno.Text.ToUpper().Trim(), Convert.ToString(str_trantype), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                Session["Datatable"] = Dt;
                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        if (Dt.Rows[i][0].ToString() != txt_jobno.Text)
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('MAWBL # Already Exists')", true);
                            hf_blnMBL.Value = "true";
                            txt_mawbno.Focus();
                            brr = true;
                            return;
                            //txt_mawbno.SelectAll();

                        }
                    }
                }
                if (da_obj_Logobj.CheckMBLNOWithHBL(Convert.ToString(str_trantype), txt_mawbno.Text.ToUpper().Trim(), Convert.ToInt32(Session["LoginBranchid"].ToString())) != 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid MBL #')", true);
                    txt_mawbno.Focus();
                    //txt_mawbno.SelectAll();
                    hf_blnMBL.Value = "true";
                    brr = true;
                    return;
                }
                //DataAccess.ForwardingExports.BLDetails objbl = new DataAccess.ForwardingExports.BLDetails();
                DataTable dtbook = new DataTable();
                dtbook = objbl.getsp_getbookingno(txt_mawbno.Text.ToUpper(), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (dtbook.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('MBL# and Booking# is same');", true);
                    txt_mawbno.Text = "";
                    txt_mawbno.Focus();
                    hf_blnMBL.Value = "true";
                    brr = true;
                    return;
                }

            }
        }
        public void SendDeleiveryStatus()
        {
            //DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
            //DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
            str_trantype = Session["StrTranType"].ToString();
            string sendqry = "";
            DataTable Dt = new DataTable();
            if (str_trantype == "AE")
            {
                sendqry = sendqry + "<body text=darkblue><table width=100%><FONT FACE=tahoma ><tr><td align=left>New Job # : " + txt_jobno.Text + "  has been created in " + "Air Exports" + ". Please find below details</td></tr></table><br>";
            }
            else
            {
                sendqry = sendqry + "<body text=darkblue><table width=100%><FONT FACE=tahoma ><tr><td align=left>New Job # : " + txt_jobno.Text + "  has been created in " + "Air Imports" + ". Please find below details</td></tr></table><br>";
            }
            sendqry = sendqry + "<table><tr><td align=left>Job # : " + txt_jobno.Text + "   </td><td align=left>Vessel Vs Voyage : " + txt_flightno.Text + " Vs " + Convert.ToDateTime(Utility.fn_ConvertDate(txt_dtfdate.Text)) + "   " + "     </td><td align=left colspan=2>MBL # : " + txt_mawbno.Text + "</td></tr><br>";
            sendqry = sendqry + "<tr><td align=left>PoL : " + txt_from.Text + "   " + "   </td><td align=left>PoD : " + txt_to.Text + "   " + "   </td></tr><br>";
            sendqry = sendqry + "<tr><td align=left colspan=4>Agent : " + txt_agent.Text + "   </td></tr><br>";
            sendqry = sendqry + "<tr><td align=left colspan=4>Air Liner # : " + txt_airline.Text + "</td></tr></table>";

            //DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();
            sendqry = sendqry + "</table><table width=100% text=darkblue><tr><td align=left>Best Regards </td></tr></table><br><br><br>";
            sendqry = sendqry + "<table width=100% text=black><tr><td align=left>" + da_obj_employeeobj.GetEmployeeName(Convert.ToInt32(da_obj_employeeobj.GetEmpid(Convert.ToString(Session["LoginUserName"].ToString())))) + " </td></tr></table></body></html>";

            string usermail = null;
            string empmailadd = "";
            //DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
            //DataAccess.UserPermission userperobj = new DataAccess.UserPermission();
            usermail = hrempobj.GetMailAdd(hrempobj.GetEmpId(Convert.ToString(Session["LoginUserName"].ToString())));
            Dt = userperobj.GetMLEmpid(userperobj.GetMLUiid(Convert.ToString(str_trantype), "Job Info"), Convert.ToInt32(Session["LoginBranchid"].ToString()));
            for (int i = 0; i <= Dt.Rows.Count - 1; i++)
            {
                empmailadd = empmailadd + da_obj_hrempobj.GetMailAdd(Convert.ToInt32(Dt.Rows[i][0].ToString())) + ";";
            }
            if (!string.IsNullOrEmpty(empmailadd))
            {
                //  string str_mailserver = Session["MailServer"].ToString();
                string str_usermailid = Session["usermailid"].ToString();
                // string str_mailuser = Session["MailUser"].ToString();
                string str_mailpwd = Session["mailpwd"].ToString();

                empmailadd = empmailadd.Substring(0, empmailadd.Length - 1);
                if (str_trantype == "AE")
                {
                    //sendmail.SendEmail(empmailadd, usermail, "pandi", "New Job # : " & txtjobno.Text & "  has been created in Air Exports", sendqry, True, Login.MailServer, usermail, "", Login.MailUser, Login.mailpwd, "")
                    Utility.SendMail(Session["usermailid"].ToString(), empmailadd, "New Job # : " + txt_jobno.Text + " has been created in Air Exports", sendqry, "", Session["usermailpwd"].ToString());
                }
                else
                {
                    //sendmail.SendEmail(empmailadd, usermail, "pandi", "New Job # : " & txtjobno.Text & "  has been created in Air Imports", sendqry, True, Login.MailServer, usermail, "", Login.MailUser, Login.mailpwd, "")
                    Utility.SendMail(Session["usermailid"].ToString(), empmailadd, "New Job # : " + txt_jobno.Text + " has been created in Air Imports", sendqry, "", Session["usermailpwd"].ToString());
                    //Utility.SendMail(empmailadd, usermail, "pandi", "New Job # : " + txtjobno.Text + "  has been created in Air Imports", sendqry, true, Login.MailServer, usermail, "", Login.MailUser, Login.mailpwd, "");
                    //Utility.SendMail(Session["usermailid"].ToString(), empmailadd, " has been created in Air Imports", sendqry, "", Session["usermailpwd"].ToString());
                }

            }

        }


        protected void btn_view_Click(object sender, EventArgs e)
        {
            str_trantype = Session["StrTranType"].ToString();
            string str_sf = "";
            string str_frmname = "";
            string str_RptName = "";
            string str_Script;
            string Str_P = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            if (str_trantype == "AE")
            {
                if (txt_jobno.Text.ToString() == "")
                {
                    str_frmname = "AE JobDetails";
                    str_RptName = "AEJobInfo.rpt";
                    str_sf = "{AEJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                    //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + Str_P + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    str_Script = "window.open('../Reportasp/JobinfoRpt.aspx?bid=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + "&Trantype=" + "AE" + "&" + this.Page.ClientQueryString + "','','');";

                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = Str_P;
                }
                else
                {
                    str_frmname = "AE JobDetails";
                    str_RptName = "AEJobInfo.rpt";
                    str_sf = "{AEJobInfo.jobno}=" + txt_jobno.Text + " and " + "{AEJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                    //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + Str_P + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    str_Script = "window.open('../Reportasp/JobinfoRpt.aspx?jobno=" + txt_jobno.Text + "&bid=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + "&Trantype=" + "AE" + "&" + this.Page.ClientQueryString + "','','');";


                    // str_Script = "window.open('../Reportasp/AEJobInforpt.aspx?jobno=" + txt_jobno.Text + "&bid=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + "&" + this.Page.ClientQueryString + "','','');";


                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = Str_P;
                }
                da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 5, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), "View Details");
            }
            else
            {
                //if (string.IsNullOrEmpty(txt_jobno.Text))
                if (txt_jobno.Text.ToString() == "")
                {
                    str_frmname = "AI JobDetails";
                    str_RptName = "AIJobInfo.rpt";
                    str_sf = "{AIJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                    //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + Str_P + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    str_Script = "window.open('../Reportasp/JobinfoRpt.aspx?bid=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + "&Trantype=" + "AI" + "&" + this.Page.ClientQueryString + "','','');";

                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = Str_P;
                }
                else
                {
                    str_frmname = "AI JobDetails";
                    str_RptName = "AIJobInfo.rpt";
                    str_sf = "{AIJobInfo.jobno}=" + txt_jobno.Text + " and " + "{AIJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                    //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + Str_P + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    str_Script = "window.open('../Reportasp/JobinfoRpt.aspx?jobno=" + txt_jobno.Text + "&bid=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + "&Trantype=" + "AI" + "&" + this.Page.ClientQueryString + "','','');";

                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = Str_P;

                    // str_Script = "window.open('../Reportasp/AEJobInforpt.aspx?jobno=" + txt_jobno.Text + "&bid=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + "&" + this.Page.ClientQueryString + "','','');";
                    //ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                }
                da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 7, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), "View Details");
            }
             btn_back.Text = "Cancel";
            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";

            UserRights();
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (Request.QueryString.ToString().Contains("back"))
            {
                string trantype_process = Session["StrTranType"].ToString();
                DataTable dtuser = new DataTable();

                
                    dtuser = obj_UP.GetFormwiseuserRights(1014, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                    if (dtuser.Rows.Count > 0)
                    {


                        Response.Redirect("../AE/AEAWBDetails.aspx");


                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                    }

                
            }

            if (btn_back.ToolTip == "Cancel")
            {
                txt_agent.Enabled = true;
                btn_save.Enabled = true;
                 btn_save.Text = "Save";
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";

                txt_jobno.Text = "";
                txt_mawbno.Text = "";
                txt_dtdate.Text = "";
                txt_airline.Text = "";
                txt_flightno.Text = "";
                txt_dtfdate.Text = "";
                txt_handlinginfo.Text = "";
                ddl_cmbstatus.SelectedIndex = 0;
                CHk_DropAIR.Checked = false;
                chk_directbl.Checked = false;
                chk_notify.Checked = false;
                grd.DataSource = null;
                grd.DataBind();
                txt_from.Text = "";
                txt_to.Text = "";
                txt_agent.Text = "";
                txt_iatacarrier.Text = "";
                txt_manifestno.Text = "";
                txt_mawbno.Enabled = true;
                txt_dtjobdate.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString()).ToString();
                txt_dtdate.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString()).ToString();
                txt_dtfdate.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString()).ToString();
                txt_dtmfdate.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString()).ToString();
                txtmawbdate.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString()).ToString();
                txt_agent.Enabled = true;
                btn_back.Text = "Back";
                fromflag.ImageUrl = "";


                toflag.ImageUrl = "";

                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
                txt_search.Text = "";
                txt_jobno.Focus();
                UserRights();
                BindBooking();
            }
            else
            {
                // this.Response.End();
                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "CS")
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {

                            Response.Redirect("../Home/OECSHome.aspx");

                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {

                            Response.Redirect("../Home/OICSHome.aspx");
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {

                            Response.Redirect("../Home/AECSHome.aspx");
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {

                            Response.Redirect("../Home/AICSHome.aspx");
                        }
                    }
                    else if (Session["home"].ToString() == "OPS&DOC")
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {

                            Response.Redirect("../Home/OEOpsAndDocs.aspx");

                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {

                            Response.Redirect("../Home/OEOpsAndDocs.aspx");
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {

                            Response.Redirect("../Home/OEOpsAndDocs.aspx");
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {

                            Response.Redirect("../Home/OEOpsAndDocs.aspx");
                        }
                    }
                }
                else
                {
                    this.Response.End();
                }
            }

        }

        protected void grd_airline_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            Panelreuse.Visible = false;
            str_trantype = Session["StrTranType"].ToString();
            int int_index;
            int_index = grd_airline.SelectedRow.RowIndex;
            txt_jobno.Text = grd_airline.Rows[int_index].Cells[0].Text.ToString();
            Get_grd_airline();
            getblno();

        }

        public void getblno()
        {
            //DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
            //DataAccess.AirImportExports.AIEBLDetails da_obj_blobj = new DataAccess.AirImportExports.AIEBLDetails();
            //DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();
            DataTable dt_new = new DataTable();
            if (grd_airline.Rows.Count > 0)
            {
                int count = grd_airline.SelectedRow.RowIndex;
                int jobno = Convert.ToInt32(grd_airline.Rows[count].Cells[0].Text);
                if (jobno.ToString() != "")
                {
                    if (Session["StrTranType"].ToString() == "AE")
                    {
                        dt_new = da_obj_blobj.ShowAIEInfoQuery(Convert.ToInt32(jobno), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());

                        if (dt_new.Rows.Count > 0)
                        {
                            if (grd.Rows.Count > 0)
                            {
                                grd.DataSource = null;
                                grd.DataBind();
                            }
                            else
                            {
                                grd.DataSource = dt_new;
                                grd.DataBind();
                            }

                            //grd.DataSource = dt_new;
                            //grd.DataBind();
                            if (grd.Rows.Count > 0)
                            {
                                grd.HeaderRow.Cells[0].Text = "Job #";
                                grd.HeaderRow.Cells[1].Text = "HAWB #";
                                grd.HeaderRow.Cells[2].Text = "Shipper";
                                grd.HeaderRow.Cells[3].Text = "Consignee";
                                if (Session["StrTranType"].ToString() == "AI" || Session["StrTranType"].ToString() == "AE")
                                {
                                    grd.HeaderRow.Cells[4].Text = "Flight #/Date";
                                }
                                else
                                {
                                    grd.HeaderRow.Cells[4].Text = "Vessel/Voy";
                                }
                                grd.HeaderRow.Cells[5].Text = "CBM";
                                grd.HeaderRow.Cells[6].Text = "Gr.Wt.";
                                grd.HeaderRow.Cells[7].Text = "Pkgs";
                                grd.HeaderRow.Cells[8].Text = "";
                            }
                        }
                        else
                        {
                            grd.DataSource = null;
                            grd.DataBind();
                        }
                    }

                    if (Session["StrTranType"].ToString() == "AI")
                    {


                        if (txt_jobno.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowAIEInfoQuery(Convert.ToInt32(jobno), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                            if (dt_new.Rows.Count > 0)
                            {

                                if (grd.Rows.Count > 0)
                                {
                                    grd.DataSource = null;
                                    grd.DataBind();
                                }
                                else
                                {
                                    grd.DataSource = dt_new;
                                    grd.DataBind();
                                }
                                //grd.DataSource = dt_new;
                                //grd.DataBind();
                                if (grd.Rows.Count > 0)
                                {
                                    grd.HeaderRow.Cells[0].Text = "Job #";
                                    grd.HeaderRow.Cells[1].Text = "HAWB #";
                                    grd.HeaderRow.Cells[2].Text = "Shipper";
                                    grd.HeaderRow.Cells[3].Text = "Consignee";
                                    if (Session["StrTranType"].ToString() == "AI" || Session["StrTranType"].ToString() == "AE")
                                    {
                                        grd.HeaderRow.Cells[4].Text = "Flight #/Date";
                                    }
                                    else
                                    {
                                        grd.HeaderRow.Cells[4].Text = "Vessel/Voy";
                                    }
                                    grd.HeaderRow.Cells[5].Text = "CBM";
                                    grd.HeaderRow.Cells[6].Text = "Gr.Wt.";
                                    grd.HeaderRow.Cells[7].Text = "Pkgs";
                                    grd.HeaderRow.Cells[8].Text = "";
                                }
                            }
                            else
                            {
                                grd.DataSource = null;
                                grd.DataBind();
                            }
                        }
                    }
                }
            }
        }
        public void Get_grd_airline()
        {
            try
            {
                //DataAccess.Accounts.Invoice da_obj_INVobj = new DataAccess.Accounts.Invoice();
                //DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
                DataTable DtA_Details = new DataTable();
                str_trantype = Session["StrTranType"].ToString();
                string status;
                if (str_trantype == "AE")
                {
                    DtA_Details = da_obj_AEJobobj.GetAIEDetail(Convert.ToInt32(txt_jobno.Text), "AE", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (DtA_Details.Rows.Count > 0)
                    {
                        txt_mawbno.Text = DtA_Details.Rows[0][4].ToString();
                        txtmawbdate.Text= Utility.fn_ConvertDate(DtA_Details.Rows[0]["mawbldate"].ToString());
                        txt_dtdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][5].ToString());
                        txt_airline.Text = DtA_Details.Rows[0][0].ToString();
                        txt_flightno.Text = DtA_Details.Rows[0][6].ToString();
                        txt_dtfdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][7].ToString());
                        txt_handlinginfo.Text = DtA_Details.Rows[0][10].ToString();
                        //  ddl_cmbstatus.SelectedValue = DtA_Details.Rows[0][9].ToString();
                        status = DtA_Details.Rows[0][9].ToString();
                        txt_from.Text = DtA_Details.Rows[0][2].ToString();
                        txt_to.Text = DtA_Details.Rows[0][3].ToString();
                        txt_agent.Text = DtA_Details.Rows[0][1].ToString();
                        txt_iatacarrier.Text = DtA_Details.Rows[0]["iatacarrier"].ToString();
                        hf_agentid.Value = DtA_Details.Rows[0]["agent"].ToString();
                        hf_airlineid.Value = DtA_Details.Rows[0]["airline1"].ToString();
                        txt_dtjobdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][14].ToString());
                        hf_intfromid.Value = DtA_Details.Rows[0]["fromid"].ToString();
                        hf_inttoid.Value = DtA_Details.Rows[0]["toid"].ToString();
                        txt_manifestno.Text = DtA_Details.Rows[0]["manifestno"].ToString();
                        txt_dtmfdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][17].ToString());
                        if (DtA_Details.Rows[0]["jobprofit"].ToString() == "P")
                        {
                            CHk_DropAIR.Checked = true;
                        }
                        else
                        {

                            CHk_DropAIR.Checked = false;
                        }
                        if (DtA_Details.Rows[0]["directbl"].ToString() == "Y")
                        {
                            chk_directbl.Checked = true;
                        }
                        else
                        {

                            chk_directbl.Checked = false;
                        }
                        if (DtA_Details.Rows[0]["notify"].ToString() == "Y")
                        {
                            chk_notify.Checked = true;
                        }
                        else
                        {

                            chk_notify.Checked = false;
                        }

                        if (status == "T")
                        {
                            ddl_cmbstatus.SelectedValue = "T";
                        }
                        else
                        {
                            ddl_cmbstatus.SelectedValue = "P";
                        }


                        btn_save.Enabled = true;
                        btn_save.ForeColor = System.Drawing.Color.White;
                          btn_save.Text = "Update";

                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn btn-update1";

                        DataTable dt_DTMBL = new DataTable();

                        for (int s = 1; s <= 6; s++)
                        {
                            dt_DTMBL = da_obj_INVobj.CheckIPDCWMBL(txt_mawbno.Text, Convert.ToString(str_trantype), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), s);
                            if (dt_DTMBL.Rows.Count > 0)
                            {
                                txt_mawbno.Enabled = false;
                                break;
                            }
                            else
                            {
                                txt_mawbno.Enabled = true;
                            }
                        }

                        DataTable dtchk = new DataTable();
                        dtchk = obj_da_Job.getCheckCNDNForaJOb(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_jobno.Text), "AE");
                        if (dtchk.Rows.Count != 0)
                        {
                            txt_agent.Enabled = false;
                        }
                        txt_flightno2.Text = DtA_Details.Rows[0]["flightno2"].ToString();
                        if (DtA_Details.Rows[0]["flightdate2"].ToString() != "")
                        {
                            txt_dtfdate2.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0]["flightdate2"].ToString());
                        }
                        else
                        {
                            txt_dtfdate2.Text = ""; 
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "AEJobInfo", "alertify.alert('Job Not Available');", true);
                        txt_jobno.Text = "";
                        return;
                    }

                }

                else
                {
                    DtA_Details = da_obj_AEJobobj.GetAIEDetail(Convert.ToInt32(txt_jobno.Text), "AI", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (DtA_Details.Rows.Count > 0)
                    {
                        txt_mawbno.Text = DtA_Details.Rows[0][4].ToString();
                        txt_dtdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][5].ToString());
                        txt_airline.Text = DtA_Details.Rows[0][0].ToString();
                        txt_flightno.Text = DtA_Details.Rows[0][6].ToString();
                        txt_dtfdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][7].ToString());
                        txt_handlinginfo.Text = DtA_Details.Rows[0][10].ToString();
                        ddl_cmbstatus.SelectedValue = DtA_Details.Rows[0][9].ToString();
                        txt_from.Text = DtA_Details.Rows[0][2].ToString();
                        txt_to.Text = DtA_Details.Rows[0][3].ToString();
                        txt_agent.Text = DtA_Details.Rows[0][1].ToString();
                        hf_agentid.Value = DtA_Details.Rows[0]["agent"].ToString();
                        hf_airlineid.Value = DtA_Details.Rows[0]["airline1"].ToString();
                        txt_dtjobdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][14].ToString());
                        hf_intfromid.Value = DtA_Details.Rows[0]["fromid"].ToString();
                        hf_inttoid.Value = DtA_Details.Rows[0]["toid"].ToString();
                        txt_manifestno.Text = DtA_Details.Rows[0]["manifestno"].ToString();

                        if (DtA_Details.Rows[0]["jobprofit"].ToString() == "P")
                        {
                            CHk_DropAIR.Checked = true;
                        }
                        else
                        {
                            CHk_DropAIR.Checked = false;
                        }

                        btn_save.Enabled = true;
                        btn_save.ForeColor = System.Drawing.Color.White;
                          btn_save.Text = "Update";
                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn btn-update1";
                        DataTable dt_DTMBL = new DataTable();

                        for (int s = 1; s <= 6; s++)
                        {
                            dt_DTMBL = da_obj_INVobj.CheckIPDCWMBL(txt_mawbno.Text, Convert.ToString(str_trantype), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), s);
                            if (dt_DTMBL.Rows.Count > 0)
                            {
                                txt_mawbno.Enabled = false;
                                break;
                            }
                            else
                            {
                                txt_mawbno.Enabled = true;
                            }
                        }

                        DataTable dtchk = new DataTable();
                        dtchk = obj_da_Job.getCheckCNDNForaJOb(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_jobno.Text), "AI");
                        if (dtchk.Rows.Count != 0)
                        {
                            txt_agent.Enabled = false;
                        }
                        txt_flightno2.Text = DtA_Details.Rows[0]["flightno2"].ToString();
                        if (DtA_Details.Rows[0]["flightdate2"].ToString() != "")
                        {
                            txt_dtfdate2.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0]["flightdate2"].ToString());
                        }
                        else
                        {
                            txt_dtfdate2.Text ="";
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "JobInfo", "alertify.alert('Job Not Available');", true);
                        txt_jobno.Text = "";
                        return;
                    }
                }
                DataTable dt;
              //  DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                dt = obj_MasterPort.SelPortName4typepadimg(txt_from.Text.ToUpper(), Session["StrTranType"].ToString());
                fromflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                dt = obj_MasterPort.SelPortName4typepadimg(txt_to.Text.ToUpper(), Session["StrTranType"].ToString());
                toflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                getbookingassigned();
                BindBooking();
                UserRights();
                 btn_back.Text = "Cancel";

                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txt_jobno.Text = "";
                txt_jobno.Focus();
            }
        }






        public void Get_grd_airlineReuse()
        {
            try
            {
                //DataAccess.Accounts.Invoice da_obj_INVobj = new DataAccess.Accounts.Invoice();
                //DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
                DataTable DtA_Details = new DataTable();
                str_trantype = Session["StrTranType"].ToString();
                string status;
                Panel3.Visible = false;
                Panelreuse.Visible = true;
                if (str_trantype == "AE")
                {
                    DtA_Details = da_obj_AEJobobj.GetAIEDetail(Convert.ToInt32(txt_jobno.Text), "AE", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (DtA_Details.Rows.Count > 0)
                    {

                        txt_dtdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][5].ToString());
                        txt_airline.Text = DtA_Details.Rows[0][0].ToString();
                        txt_flightno.Text = DtA_Details.Rows[0][6].ToString();
                        txt_dtfdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][7].ToString());
                        txt_handlinginfo.Text = DtA_Details.Rows[0][10].ToString();
                        //  ddl_cmbstatus.SelectedValue = DtA_Details.Rows[0][9].ToString();
                        status = DtA_Details.Rows[0][9].ToString();
                        txt_from.Text = DtA_Details.Rows[0][2].ToString();
                        txt_to.Text = DtA_Details.Rows[0][3].ToString();
                        txt_agent.Text = DtA_Details.Rows[0][1].ToString();
                        txt_iatacarrier.Text = DtA_Details.Rows[0]["iatacarrier"].ToString();
                        hf_agentid.Value = DtA_Details.Rows[0]["agent"].ToString();
                        hf_airlineid.Value = DtA_Details.Rows[0]["airline1"].ToString();
                        txt_dtjobdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][14].ToString());
                        hf_intfromid.Value = DtA_Details.Rows[0]["fromid"].ToString();
                        hf_inttoid.Value = DtA_Details.Rows[0]["toid"].ToString();
                        txt_manifestno.Text = DtA_Details.Rows[0]["manifestno"].ToString();
                        txt_dtmfdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][17].ToString());

                        txt_jobno.Text = "";
                        btn_save.Enabled = true;
                        btn_save.ForeColor = System.Drawing.Color.White;
                        btn_save.Text = "Save";



                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "AEJobInfo", "alertify.alert('Job Not Available');", true);
                        txt_jobno.Text = "";
                        return;
                    }

                }

                else
                {
                    DtA_Details = da_obj_AEJobobj.GetAIEDetail(Convert.ToInt32(txt_jobno.Text), "AI", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (DtA_Details.Rows.Count > 0)
                    {

                        txt_dtdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][5].ToString());
                        txt_airline.Text = DtA_Details.Rows[0][0].ToString();
                        txt_flightno.Text = DtA_Details.Rows[0][6].ToString();
                        txt_dtfdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][7].ToString());
                        txt_handlinginfo.Text = DtA_Details.Rows[0][10].ToString();
                        ddl_cmbstatus.SelectedValue = DtA_Details.Rows[0][9].ToString();
                        txt_from.Text = DtA_Details.Rows[0][2].ToString();
                        txt_to.Text = DtA_Details.Rows[0][3].ToString();
                        txt_agent.Text = DtA_Details.Rows[0][1].ToString();
                        hf_agentid.Value = DtA_Details.Rows[0]["agent"].ToString();
                        hf_airlineid.Value = DtA_Details.Rows[0]["airline1"].ToString();
                        txt_dtjobdate.Text = Utility.fn_ConvertDate(DtA_Details.Rows[0][14].ToString());
                        hf_intfromid.Value = DtA_Details.Rows[0]["fromid"].ToString();
                        hf_inttoid.Value = DtA_Details.Rows[0]["toid"].ToString();
                        txt_manifestno.Text = DtA_Details.Rows[0]["manifestno"].ToString();

                        txt_jobno.Text = "";
                        btn_save.Enabled = true;
                        btn_save.ForeColor = System.Drawing.Color.White;
                         btn_save.Text = "Save";
                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "JobInfo", "alertify.alert('Job Not Available');", true);
                        txt_jobno.Text = "";
                        return;
                    }
                }

                grdBookJob.Visible = true;
                BindBooking();

                UserRights();
                 btn_back.Text = "Cancel";


                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txt_jobno.Text = "";
                txt_jobno.Focus();
            }
        }

        protected void grd_airline_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_airline, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_airline_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_airline.PageIndex = e.NewPageIndex;
            this.programmaticModalCancelCredit.Show();
            grd_airline.DataSource = (DataTable)ViewState["Job"];
            grd_airline.DataBind();
        }

        protected void btn_manifest_Click(object sender, EventArgs e)
        {
            try
            {



                str_trantype = Session["StrTranType"].ToString();
                string str_sf = "";
                string str_frmname = "";
                string str_RptName = "";
                string str_Script;
                string Str_P = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                string notify = "N";
                string direct = "N";

                if (txt_jobno.Text.ToString() != "")
                {
                    str_frmname = "AE JobDetails";

                    /*if (chk_notify.Checked == true)
                    {
                        str_RptName = "consolmanifest.rpt";
                    }
                    else
                    {
                        str_RptName = "consolmanifestwithoutagent.rpt";
                    }*/
                    if (str_trantype == "AE")
                    {
                        str_RptName = "consolmanifest.rpt";
                    }
                    else
                    {
                        str_RptName = "consolmanifestAI.rpt";
                    }

                    if (chk_notify.Checked == true)
                    {
                        notify = "Y";
                    }
                    if (chk_directbl.Checked == true)
                    {
                        direct = "Y";
                    }

                    Str_P = "head=M~notify=" + notify + "~direct=" + direct;


                    // str_RptName = "consolmanifest.rpt";
                    //Str_P = "head=M";
                    Session["str_sfs"] = "{AEBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {AEBLDetails.jobno}=" + txt_jobno.Text + " and   {AEBLDetails.switchbl}='" + "N" + "'";
                    // Session["str_sfs"] = "{AEJobInfo.jobno}=" + txt_jobno.Text + " and " + "{AEJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {AEBLDetails.switchbl}='" +"N" + "'";// '" + StrTranType + "'";
                    //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + Str_P + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    str_Script = "window.open('../Reportasp/consolmanifest.aspx?jobno=" + txt_jobno.Text + "&bid=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) +"&hf_bl="+"0"+"&hf_dbl=" + direct + "&hf_nt=" + notify + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                    // Session["str_sfs"] = str_sf;
                    Session["str_sp"] = Str_P;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_agent_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();

            dt = da_obj_Customer.GetexactCustomer(txt_agent.Text, "P");
            if (dt.Rows.Count > 0 && hf_agentid.Value != "0")
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID Agent NAME')", true);
                txt_agent.Text = "";
                txt_agent.Focus();
                brr = true;
                return;
            }
        }

        protected void txt_airline_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();

            dt = da_obj_Customer.GetexactCustomer(txt_airline.Text, "L");
            if (dt.Rows.Count > 0 && hf_airlineid.Value != "0")
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID Airline NAME')", true);
                txt_airline.Text = "";
                txt_airline.Focus();
                brr = true;
                return;
            }
        }

        protected void txt_from_TextChanged(object sender, EventArgs e)
        {
            if (portobj.GetNPortid(txt_from.Text.Trim().ToUpper()) != 0 && hf_intfromid.Value != "0")
            {
                DataTable dt;
              //  DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                dt = obj_MasterPort.SelPortName4typepadimg(txt_from.Text.ToUpper(), Session["StrTranType"].ToString());
                fromflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID From Port')", true);
                txt_from.Text = "";
                txt_from.Focus();
                brr = true;
                return;
            }
        }

        protected void txt_to_TextChanged(object sender, EventArgs e)
        {
            if (portobj.GetNPortid(txt_to.Text.Trim().ToUpper()) != 0 && hf_inttoid.Value != "0")
            {
                DataTable dt;
               // DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                
                dt = obj_MasterPort.SelPortName4typepadimg(txt_to.Text.ToUpper(), Session["StrTranType"].ToString());
                toflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('INVALID To Port')", true);
                txt_to.Text = "";
                txt_to.Focus();
                brr = true;
                return;
            }
        }
        protected void txt_search_TextChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in grdBookJob.Rows)
            {

                CheckBox chkRow = (grdBookJob.Rows[row.RowIndex].Cells[3].FindControl("ChkMail") as CheckBox);
                if (chkRow.Checked == true)
                {
                    row.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    row.ForeColor = System.Drawing.Color.Black;
                }
                if (row.Cells[1].Text == txt_search.Text.TrimEnd())
                {
                    chkRow.Checked = true;
                    row.ForeColor = System.Drawing.Color.Red;

                    chkRow.Focus();
                    txt_search.Text = "";
                    //break;
                }
            }
        }

        private void BindBooking()
        {

            //Session["shiprefno"] = null;
            if (Session["StrTranType"] != null)
            {
                str_trantype = Session["StrTranType"].ToString();
            }

            if (txt_jobno.Text != "")
            {
                dtbk = book.SELBookingDtlsByJob(str_trantype, branchid, Convert.ToInt32(txt_jobno.Text));


                if (dtbk.Rows.Count > 0)
                {
                    int jobno = Convert.ToInt32(dtbk.Rows[0]["job"].ToString());
                    int grdbookno;
                    dsJob = obj_da_Job.selgetjobbl(jobno);
                    for (int i = 0; i <= dtbk.Rows.Count - 1; i++)
                    {
                        if (grdBookJob.Rows.Count > 0)
                        {
                            bookno = Convert.ToInt32(dtbk.Rows[i]["bookingno"].ToString());
                            // int jobo=Convert.ToInt32(dtbk.Rows[i]["jobno"].ToString());
                            for (int j = 0; j <= grdBookJob.Rows.Count - 1; j++)
                            {
                                CheckBox chkRow = (grdBookJob.Rows[j].Cells[3].FindControl("ChkMail") as CheckBox);
                                grdbookno = Convert.ToInt32(grdBookJob.Rows[j].Cells[0].Text);
                                if (bookno == grdbookno)
                                {
                                    string shiprfno = dtbk.Rows[i]["shiprefno"].ToString();
                                    chkRow.Checked = true;

                                    for (int k = 0; k <= dsJob.Rows.Count - 1; k++)
                                    {
                                        if (shiprfno == dsJob.Rows[k]["shiprefno"].ToString())
                                        {
                                            chkRow.Enabled = false;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j <= grdBookJob.Rows.Count - 1; j++)
                    {
                        CheckBox chkRow = (grdBookJob.Rows[j].Cells[3].FindControl("ChkMail") as CheckBox);
                        chkRow.Checked = false;
                    }
                }
            }


            else
            {
                branchid = Convert.ToInt32(Session["LoginBranchid"]);
             //   dtbk = book.GETBookingNoJobInfo(branchid, str_trantype);
                dtbk = book.GETBookingNoJobInfo4task(branchid, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginEmpId"]));
                if (dtbk.Rows.Count > 0)
                {
                    grdBookJob.DataSource = dtbk;
                    grdBookJob.DataBind();
                    //ViewState["grdBookJob"] = dtbk;
                    //Session["shiprefno"] = dtbk;
                }
                else
                {
                    grdBookJob.DataSource = new DataTable();
                    grdBookJob.DataBind();
                }
                //Session["shiprefno"] = dtbk;
            }



        }

        private void getbookingassigned()
        {
            branchid = Convert.ToInt32(Session["LoginBranchid"]);
            if (Session["StrTranType"] != null)
            {
                str_trantype = Session["StrTranType"].ToString();
            }

            DataTable dtbk1;

            dtbk1 = book.SELBookingDtlsByJobnew(str_trantype, branchid, Convert.ToInt32(txt_jobno.Text));
            if (dtbk1.Rows.Count > 0)
            {
                grdBookJob.DataSource = dtbk1;
                grdBookJob.DataBind();
                // ViewState["grdBookJob"] = dtbk1;
                Session["shiprefno"] = dtbk1;
            }

            getallsearchvaluesbook();
        }

        public void getallsearchvaluesbook()
        {
            str_trantype = Session["StrTranType"].ToString();
            if (txt_jobno.Text != "")
            {
                branchid = Convert.ToInt32(Session["LoginBranchid"]);

                dtbk = book.SELBookingDtlsByJob(str_trantype, branchid, Convert.ToInt32(txt_jobno.Text));


                if (dtbk.Rows.Count > 0)
                {
                    int jobno = Convert.ToInt32(dtbk.Rows[0]["job"].ToString());
                    int grdbookno;
                    dsJob = obj_da_Job.selgetjobbl(jobno);
                    for (int i = 0; i <= dtbk.Rows.Count - 1; i++)
                    {
                        if (grdBookJob.Rows.Count > 0)
                        {
                            bookno = Convert.ToInt32(dtbk.Rows[i]["bookingno"].ToString());
                            // int jobo=Convert.ToInt32(dtbk.Rows[i]["jobno"].ToString());
                            for (int j = 0; j <= grdBookJob.Rows.Count - 1; j++)
                            {
                                CheckBox chkRow = (grdBookJob.Rows[j].Cells[3].FindControl("ChkMail") as CheckBox);
                                grdbookno = Convert.ToInt32(grdBookJob.Rows[j].Cells[0].Text);
                                if (bookno == grdbookno)
                                {
                                    string shiprfno = dtbk.Rows[i]["shiprefno"].ToString();
                                    chkRow.Checked = true;

                                    for (int k = 0; k <= dsJob.Rows.Count - 1; k++)
                                    {
                                        if (shiprfno == dsJob.Rows[k]["shiprefno"].ToString())
                                        {
                                            chkRow.Enabled = false;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j <= grdBookJob.Rows.Count - 1; j++)
                    {
                        CheckBox chkRow = (grdBookJob.Rows[j].Cells[3].FindControl("ChkMail") as CheckBox);
                        chkRow.Checked = false;
                    }
                }
            }


        }

        protected void Proinvoic_Click(object sender, EventArgs e)
        {

            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();


            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1027, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    if (txt_mawbno.Text != "")
                    {
                        string mblno = txt_mawbno.Text;
                        string app1 = "1";
                        string lblid = lblheader.Text;
                        Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app1 + "&mblno=" + mblno + "&lblid=" + lblid);
                    }
                    else
                    {
                        string message = "Enter the Job no";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }



                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1034, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    if (txt_mawbno.Text != "")
                    {
                        string mblno = txt_mawbno.Text;
                        string app1 = "1";
                        string lblid = lblheader.Text;
                        Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app1 + "&mblno=" + mblno + "&lblid=" + lblid);
                    }
                    else
                    {
                        string message = "Enter the Job no";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }


                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
        }

        protected void procrednote_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();



            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1028, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_mawbno.Text != "")
                    {
                        string mblno = txt_mawbno.Text;
                        string app2 = "2";
                        string lblid = lblheader.Text;
                        //Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app2);
                        Response.Redirect("../Accounts/ProformaLV.aspx?app2=" + app2 + "&mblno=" + mblno + "&lblid=" + lblid);
                    }
                    else
                    {
                        string message = "Enter the Job no";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1035, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    if (txt_mawbno.Text != "")
                    {
                        string mblno = txt_mawbno.Text;
                        string app2 = "2";
                        string lblid = lblheader.Text;
                        //Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app2);
                        Response.Redirect("../Accounts/ProformaLV.aspx?app2=" + app2 + "&mblno=" + mblno + "&lblid=" + lblid);
                    }
                    else
                    {
                        string message = "Enter the Job no";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }



                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
        }

        protected void uploaddoc_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(516, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ShipmentDetails/UploadDocument.aspx");


                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(517, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ShipmentDetails/UploadDocument.aspx");


                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(518, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ShipmentDetails/UploadDocument.aspx");


                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(519, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ShipmentDetails/UploadDocument.aspx");


                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
        }

        protected void Grd_reuse_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_reuse, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_reuse_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_reuse.PageIndex = e.NewPageIndex;
            this.programmaticModalCancelCredit.Show();
            Grd_reuse.DataSource = (DataTable)ViewState["Job"];
            Grd_reuse.DataBind();
        }

        protected void Grd_reuse_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            Book2.Visible = true;
            grdBookJob.Visible = false;
            Panelreuse.Visible = true;
            str_trantype = Session["StrTranType"].ToString();
            int int_index;
            int_index = Grd_reuse.SelectedRow.RowIndex;
            txt_jobno.Text = Grd_reuse.Rows[int_index].Cells[0].Text.ToString();
            Get_grd_airlineReuse();
            getblno();
        }


        protected void Btn_reuse_Click(object sender, EventArgs e)
        {
            Book2.Visible = true;
            Panel3.Visible = false;
            Panelreuse.Visible = true;
            Bindgridreuse();
        }

        protected void Proosdncn_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1029, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_jobno.Text != "")
                    {
                        string jobno = txt_jobno.Text;
                        string appAE3 = "5";
                        //Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app2);
                        Response.Redirect("../Accounts/ProOSV.aspx?appAE3=" + appAE3 + "&jobno=" + jobno);
                    }
                    else
                    {
                        string message = "Enter the Job no";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1036, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_jobno.Text != "")
                    {
                        string jobno = txt_jobno.Text;
                        string appAI3 = "5";
                        //Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app2);
                        Response.Redirect("../Accounts/ProOSV.aspx?appAI3=" + appAI3 + "&jobno=" + jobno);
                    }
                    else
                    {
                        string message = "Enter the Job no";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {

        }


        public void getbldetails()
        {
            //DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
            //DataAccess.AirImportExports.AIEBLDetails da_obj_blobj = new DataAccess.AirImportExports.AIEBLDetails();
            //DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();
            DataTable dt_new = new DataTable();

            if (txt_jobno.Text.ToString() != "")
            {
                if (Session["StrTranType"].ToString() == "AE")
                {
                    dt_new = da_obj_blobj.ShowAIEInfoQuery(Convert.ToInt32(txt_jobno.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());

                    if (dt_new.Rows.Count > 0)
                    {
                        if (grd.Rows.Count > 0)
                        {
                            grd.DataSource = null;
                            grd.DataBind();
                        }
                        else
                        {
                            grd.DataSource = dt_new;
                            grd.DataBind();
                        }


                        //grd.DataSource = dt_new;
                        //grd.DataBind();
                        if (grd.Rows.Count > 0)
                        {
                            grd.HeaderRow.Cells[0].Text = "Job #";
                            grd.HeaderRow.Cells[1].Text = "HAWB #";
                            grd.HeaderRow.Cells[2].Text = "Shipper";
                            grd.HeaderRow.Cells[3].Text = "Consignee";
                            if (Session["StrTranType"].ToString() == "AI" || Session["StrTranType"].ToString() == "AE")
                            {
                                grd.HeaderRow.Cells[4].Text = "Flight #/Date";
                            }
                            else
                            {
                                grd.HeaderRow.Cells[4].Text = "Vessel/Voy";
                            }
                            grd.HeaderRow.Cells[5].Text = "CBM";
                            grd.HeaderRow.Cells[6].Text = "Gr.Wt.";
                            grd.HeaderRow.Cells[7].Text = "Pkgs";
                            grd.HeaderRow.Cells[8].Text = "";
                        }
                    }
                    else
                    {
                        grd.DataSource = null;
                        grd.DataBind();
                    }
                }

                if (Session["StrTranType"].ToString() == "AI")
                {


                    if (txt_jobno.Text.ToString() != "")
                    {
                        dt_new = da_obj_blobj.ShowAIEInfoQuery(Convert.ToInt32(txt_jobno.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        if (dt_new.Rows.Count > 0)
                        {

                            if (grd.Rows.Count > 0)
                            {
                                grd.DataSource = null;
                                grd.DataBind();
                            }
                            else
                            {
                                grd.DataSource = dt_new;
                                grd.DataBind();
                            }
                            //grd.DataSource = dt_new;
                            //grd.DataBind();
                            if (grd.Rows.Count > 0)
                            {
                                grd.HeaderRow.Cells[0].Text = "Job #";
                                grd.HeaderRow.Cells[1].Text = "HAWB #";
                                grd.HeaderRow.Cells[2].Text = "Shipper";
                                grd.HeaderRow.Cells[3].Text = "Consignee";
                                if (Session["StrTranType"].ToString() == "AI" || Session["StrTranType"].ToString() == "AE")
                                {
                                    grd.HeaderRow.Cells[4].Text = "Flight #/Date";
                                }
                                else
                                {
                                    grd.HeaderRow.Cells[4].Text = "Vessel/Voy";
                                }
                                grd.HeaderRow.Cells[5].Text = "CBM";
                                grd.HeaderRow.Cells[6].Text = "Gr.Wt.";
                                grd.HeaderRow.Cells[7].Text = "Pkgs";
                                grd.HeaderRow.Cells[8].Text = "";
                            }
                        }
                        else
                        {
                            grd.DataSource = null;
                            grd.DataBind();
                        }
                    }
                }
            }
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
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
            DataTable dtuser;
          //  DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();

            if (grd.Rows.Count > 0)
            {
                if (Session["StrTranType"].ToString() == "AE")
                {
                    int index = grd.SelectedRow.RowIndex;
                    string blno = grd.Rows[index].Cells[1].Text;
                    int uiid = 6;
                    dtuser = obj_UP.GetFormwiseuserRights(uiid, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "AE");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../AE/AEAWBDetails.aspx?blno=" + blno);

                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grd, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }

                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    int index = grd.SelectedRow.RowIndex;
                    string blno = grd.Rows[index].Cells[1].Text;
                    int uiid = 8;
                    dtuser = obj_UP.GetFormwiseuserRights(uiid, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "AI");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../AE/AEAWBDetails.aspx?blno=" + blno);

                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grd, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }




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
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            if (Session["StrTranType"] == "AE")
            {
                obj_dtlogdetails = da_obj_Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 5, "Job", txt_mawbno.Text, txt_mawbno.Text, Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = da_obj_Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 7, "Job", txt_mawbno.Text, txt_mawbno.Text, Session["StrTranType"].ToString());
            }
            if (txt_jobno.Text != "")
            {
                JobInput.Text = txt_jobno.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void btn_agentbooking_Click(object sender, EventArgs e)
        {
            try
            {
                // sendmailforliner();

                string usermail = "";
              //  DataAccess.HR.Employee obj_da_hremp = new DataAccess.HR.Employee();
                str_trantype = Session["StrTranType"].ToString();
                string str_sf = "";
                string str_frmname = "";
                string str_RptName = "";
                string str_Script;
                string Str_P = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                string notify = "N";
                string direct = "N";
                checkpolPod();
                if (brr == true)
                {
                    brr = false;
                    return;
                }
                if (txt_jobno.Text.ToString() != "")
                {
                    str_frmname = "AE JobDetails";
                    //if (chk_notify.Checked == true)
                    //{
                    //    str_RptName = "consolmanifest.rpt";
                    //}
                    //else
                    //{
                    //    str_RptName = "consolmanifestwithoutagent.rpt";
                    //}

                    str_RptName = "consolmanifest.rpt";

                    if (chk_notify.Checked == true)
                    {
                        notify = "Y";
                    }
                    if (chk_directbl.Checked == true)
                    {
                        direct = "Y";
                    }

                    Str_P = "head=B~notify=" + notify + "~direct=" + direct;

                    str_sf = "{AEJobInfo.jobno}=" + txt_jobno.Text + " and " + "{AEJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                    //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + Str_P + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    str_Script = "window.open('../Reportasp/consolmanifest.aspx?jobno=" + txt_jobno.Text + "&bid=" + Convert.ToInt32(Session["LoginBranchid"].ToString())+ "&hf_dbl=" + direct + "&hf_nt=" + notify + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_agentbooking, typeof(Button), "Shipment Details", str_Script, true);
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = Str_P;
                }




            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        public void sendmailforliner()
        {
            //DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
            //DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
            str_trantype = Session["StrTranType"].ToString();
            string sendqry = "";
            DataTable Dt = new DataTable();
            //DataAccess.AirImportExports.AIEBLDetails da_obj_blobj = new DataAccess.AirImportExports.AIEBLDetails();
            //DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
            DataTable dt_new;
            DataTable Dt_Dimension = new DataTable();
            DataTable dmbr;
            string dimsion = "";

            string[] dimsionnew = new string[7];
            string flitno = "";
            string MAWB = "";
            string notifyto = "";
            string shiperto = "";
            string shiperto1 = "";
            int cloc;
            string str_caddress = "";
            DataTable DtA_Details = new DataTable();
            DataTable Dt_AIEDetails = new DataTable();
            //DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            //DataAccess.Masters.MasterCargo da_obj_cargoobj = new DataAccess.Masters.MasterCargo();
            string consigneeto = "";
            string consigneeto1 = "";
            Boolean l1;
            string commidty = "";
            int hf_IntCOMMODITY = 0;
            string notify = "N";
            string direct = "N";
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
            int i;
            double tot_volume = 0.0, tot_grosswt = 0.0;
            int noofpkgs = 0;
            dmbr = mb.getSelBranchdetails(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            str_trantype = Session["StrTranType"].ToString();
            dt_new = da_obj_blobj.ShowAIEInfoQuery(Convert.ToInt32(txt_jobno.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
            if (dt_new.Rows.Count > 0)
            {
                Dt_Dimension = da_obj_blobj.GetAIEBLDimension(dt_new.Rows[0]["blno"].ToString(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                DtA_Details = da_obj_blobj.GetAIEDetail(dt_new.Rows[0]["blno"].ToString(), str_trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                for (i = 0; i < dt_new.Rows.Count; i++)
                {
                    tot_volume = tot_volume + Convert.ToDouble(dt_new.Rows[i]["volume"].ToString());
                    tot_grosswt = tot_grosswt + Convert.ToDouble(dt_new.Rows[i]["grosswt"].ToString());
                    noofpkgs = noofpkgs + Convert.ToInt32(dt_new.Rows[i]["noofpkgs"].ToString());
                }



            }








            if (DtA_Details.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(DtA_Details.Rows[0]["consigneeid"].ToString()))
                {
                    cloc = Convert.ToInt32(DtA_Details.Rows[0]["consigneeid"].ToString());
                    str_caddress = da_obj_portobj.GetPortname(cloc);


                    dt = custobj.Get_customerdetails(cloc);
                    if (dt.Rows.Count > 0)
                    {

                        //consigneeto += dt.Rows[0]["customername"].ToString().ToUpper() + "<br />";
                        if (!string.IsNullOrEmpty(dt.Rows[0]["address"].ToString()))
                        {
                            consigneeto += dt.Rows[0]["address"].ToString().Replace(",", "").ToUpper() + "<br />";
                        }

                        if (!string.IsNullOrEmpty(dt.Rows[0]["Location"].ToString()))
                        {
                            consigneeto += dt.Rows[0]["Location"].ToString().ToUpper() + " ,";
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["portname"].ToString()))
                        {
                            consigneeto += dt.Rows[0]["portname"].ToString().ToUpper();
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["zip"].ToString()))
                        {
                            consigneeto += " - " + dt.Rows[0]["zip"].ToString().ToUpper() + "<br />";
                        }
                        else
                        {
                            consigneeto += "<br />";
                        }

                        if (!string.IsNullOrEmpty(dt.Rows[0]["districtname"].ToString()))
                        {
                            consigneeto += dt.Rows[0]["districtname"].ToString().ToUpper() + " , ";
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["statename"].ToString()))
                        {
                            consigneeto += dt.Rows[0]["statename"].ToString().ToUpper() + "<br />";
                        }
                        //if (!string.IsNullOrEmpty(dt.Rows[0]["ptc"].ToString()))
                        //{
                        //    consigneeto += "<strong>PTC :</strong>" + dt.Rows[0]["ptc"].ToString().ToUpper() + " ";
                        //}
                        //if (!string.IsNullOrEmpty(dt.Rows[0]["phone"].ToString()))
                        //{
                        //    consigneeto += "<strong>PH :</strong>" + dt.Rows[0]["phone"].ToString() + "<br />";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                        //}
                        if (!string.IsNullOrEmpty(dt.Rows[0]["portname"].ToString()))
                        {
                            consigneeto1 = dt.Rows[0]["portname"].ToString().ToUpper();
                        }

                    }

                    consigneeto += str_caddress;
                    //consigneeto = da_obj_customerobj.GetCustomerAddress(txt_agent.Text, "P"sss, str_caddress);

                }


                if (!string.IsNullOrEmpty(DtA_Details.Rows[0]["notifyparty1id"].ToString()))
                {
                    cloc = Convert.ToInt32(DtA_Details.Rows[0]["notifyparty1id"].ToString());
                    str_caddress = da_obj_portobj.GetPortname(cloc);


                    dt = custobj.Get_customerdetails(cloc);
                    if (dt.Rows.Count > 0)
                    {

                        //consigneeto += dt.Rows[0]["customername"].ToString().ToUpper() + "<br />";
                        if (!string.IsNullOrEmpty(dt.Rows[0]["address"].ToString()))
                        {
                            notifyto += dt.Rows[0]["address"].ToString().Replace(",", "").ToUpper() + "<br />";
                        }

                        if (!string.IsNullOrEmpty(dt.Rows[0]["Location"].ToString()))
                        {
                            notifyto += dt.Rows[0]["Location"].ToString().ToUpper() + " ,";
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["portname"].ToString()))
                        {
                            notifyto += dt.Rows[0]["portname"].ToString().ToUpper();
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["zip"].ToString()))
                        {
                            notifyto += " - " + dt.Rows[0]["zip"].ToString().ToUpper() + "<br />";
                        }
                        else
                        {
                            notifyto += "<br />";
                        }

                        if (!string.IsNullOrEmpty(dt.Rows[0]["districtname"].ToString()))
                        {
                            notifyto += dt.Rows[0]["districtname"].ToString().ToUpper() + " , ";
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["statename"].ToString()))
                        {
                            notifyto += dt.Rows[0]["statename"].ToString().ToUpper() + "<br />";
                        }
                        //if (!string.IsNullOrEmpty(dt.Rows[0]["ptc"].ToString()))
                        //{
                        //    notifyto += "<strong>PTC :</strong>" + dt.Rows[0]["ptc"].ToString().ToUpper() + " ";
                        //}
                        //if (!string.IsNullOrEmpty(dt.Rows[0]["phone"].ToString()))
                        //{
                        //    notifyto += "<strong>PH :</strong>" + dt.Rows[0]["phone"].ToString() + "<br />";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                        //}


                    }

                    notifyto += str_caddress;
                    //consigneeto = da_obj_customerobj.GetCustomerAddress(txt_agent.Text, "P", str_caddress);

                }

                if (!string.IsNullOrEmpty(DtA_Details.Rows[0]["shipperid"].ToString()))
                {
                    cloc = Convert.ToInt32(DtA_Details.Rows[0]["shipperid"].ToString());
                    str_caddress = da_obj_portobj.GetPortname(cloc);


                    dt = custobj.Get_customerdetails(cloc);
                    if (dt.Rows.Count > 0)
                    {

                        //consigneeto += dt.Rows[0]["customername"].ToString().ToUpper() + "<br />";
                        if (!string.IsNullOrEmpty(dt.Rows[0]["address"].ToString()))
                        {
                            shiperto += dt.Rows[0]["address"].ToString().Replace(",", "").ToUpper() + "<br />";
                        }

                        if (!string.IsNullOrEmpty(dt.Rows[0]["Location"].ToString()))
                        {
                            shiperto += dt.Rows[0]["Location"].ToString().ToUpper() + " ,";
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["portname"].ToString()))
                        {
                            shiperto += dt.Rows[0]["portname"].ToString().ToUpper();
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["zip"].ToString()))
                        {
                            shiperto += " - " + dt.Rows[0]["zip"].ToString().ToUpper() + "<br />";
                        }
                        else
                        {
                            shiperto += "<br />";
                        }

                        if (!string.IsNullOrEmpty(dt.Rows[0]["districtname"].ToString()))
                        {
                            shiperto += dt.Rows[0]["districtname"].ToString().ToUpper() + " , ";
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["statename"].ToString()))
                        {
                            shiperto += dt.Rows[0]["statename"].ToString().ToUpper() + "<br />";
                        }
                        //if (!string.IsNullOrEmpty(dt.Rows[0]["ptc"].ToString()))
                        //{
                        //    shiperto += "<strong>PTC :</strong>" + dt.Rows[0]["ptc"].ToString().ToUpper() + " ";
                        //}
                        //if (!string.IsNullOrEmpty(dt.Rows[0]["phone"].ToString()))
                        //{
                        //    shiperto += "<strong>PH :</strong>" + dt.Rows[0]["phone"].ToString() + "<br />";//+ "Fax :" + dt.Rows[0]["fax"].ToString()
                        //}
                        if (!string.IsNullOrEmpty(dt.Rows[0]["portname"].ToString()))
                        {
                            shiperto1 = dt.Rows[0]["portname"].ToString().ToUpper();
                        }

                    }

                    shiperto += str_caddress;
                    //consigneeto = da_obj_customerobj.GetCustomerAddress(txt_agent.Text, "P", str_caddress);

                }










                if (!string.IsNullOrEmpty(DtA_Details.Rows[0]["cargoid"].ToString()))
                {
                    hf_IntCOMMODITY = Convert.ToInt32(DtA_Details.Rows[0]["cargoid"].ToString());
                    commidty = da_obj_cargoobj.GetCargoname(hf_IntCOMMODITY);
                }
            }




            if (chk_notify.Checked == true)
            {
                notify = "Y";

            }
            if (chk_directbl.Checked == true)
            {
                direct = "Y";
            }







            sendqry = "";
            if (dt_new.Rows.Count > 0)
            {
                sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>Dear Sir / Madam ,</td></tr></font></table><br>";                              //#4, 2 ND STREET, PONNI NAGAR, PAMMAL,CHENNAI - 600 075
                sendqry = sendqry + "<table width=90% border=0 cellspacing=0 cellpadding=0 style='border:1px solid #000;  font-family:sans-serif, Geneva, sans-serif; font-size:12px;'><tr><td colspan=3 style='border-bottom:1px solid #000; text-align:center; padding:3px;'><table width=100% border=0 cellspacing=0 cellpadding=0> <tr> <td width=13%><asp:Image ID='Image1' runat='server' ImageUrl='../images/MR.png' /></td><td width=87% align='center'><h3 style='padding:5px; margin:5px; font-family:sans-serif, Geneva, sans-serif; font-size:21px; font-weight:normal;'>Demo company PVT LTD</h3><p style='font-family:sans-serif, Geneva, sans-serif; padding:3px; margin:0px; font-size:13px;'>Demo address- INDIA<br />Phone # : + +91 00 00 000000      Fax # :</p></td></tr></table></td></tr>";

                sendqry = sendqry + "<tr><td colspan=3 style='border-bottom:1px solid #000;border-top:1px solid #000; text-align:center; padding:3px; font-size:12px;'>Booking</td></tr>";
                sendqry = sendqry + "<tr><td width=33% style='border-bottom:1px solid #000; border-right:1px solid #000; padding:3px; font-size:12px;' >PREPARED BY </td><td width=33% style='border-bottom:1px solid #000; padding:3px; font-size:12px;'>CONSIGNED TO </td><td width=33% style='border-bottom:1px solid #000; padding:3px; font-size:12px;'>NOTIFIED To</td></tr>";
                if (notify == "Y")
                {
                    // notifyto = "";
                    if (direct == "Y")
                    {
                        sendqry = sendqry + "<tr><td align=left style='border-right:1px solid #000; border-bottom:1px solid #000; padding:3px; font-size:12px;'>" + dt_new.Rows[0]["shipper"].ToString() + "<br/>" + shiperto.ToString() + "   </td><td align=left style='border-right:1px solid #000; border-bottom:1px solid #000; padding:3px; font-size:12px;'>" + dt_new.Rows[0]["consignee"].ToString() + " " + consigneeto.ToString() + "</td><td align=left style='border-right:1px solid #000;  border-bottom:1px solid #000; padding:3px; font-size:12px;'>" + notifyto.ToString() + "</td></tr>";

                    }
                    else
                    {
                        sendqry = sendqry + "<tr><td align=left style='border-right:1px solid #000; border-bottom:1px solid #000; padding:3px; font-size:12px;'>" + dmbr.Rows[0]["branchname"].ToString() + "<br/>" + dmbr.Rows[0]["address"].ToString() + "   </td><td align=left style='border-right:1px solid #000; border-bottom:1px solid #000; padding:3px; font-size:12px;'>" + txt_agent.Text + " " + consigneeto.ToString() + "</td><td align=left style='border-right:1px solid #000;  border-bottom:1px solid #000; padding:3px; font-size:12px;'>" + notifyto.ToString() + "</td></tr>";
                    }
                }
                else
                {
                    notifyto = "";
                    if (direct == "Y")
                    {
                        sendqry = sendqry + "<tr><td align=left style='border-right:1px solid #000; border-bottom:1px solid #000; padding:3px; font-size:12px;'>" + dt_new.Rows[0]["shipper"].ToString() + "<br/>" + shiperto.ToString() + "   </td><td align=left style='border-right:1px solid #000; border-bottom:1px solid #000; padding:3px; font-size:12px;'>" + dt_new.Rows[0]["consignee"].ToString() + " " + consigneeto.ToString() + "</td><td align=left style='border-right:1px solid #000;  border-bottom:1px solid #000; padding:3px; font-size:12px;'>" + notifyto.ToString() + "</td></tr>";
                    }
                    else
                    {
                        sendqry = sendqry + "<tr><td align=left style='border-right:1px solid #000; border-bottom:1px solid #000; padding:3px; font-size:12px;'>" + dmbr.Rows[0]["branchname"].ToString() + "<br/>" + dmbr.Rows[0]["address"].ToString() + "   </td><td align=left style='border-right:1px solid #000; border-bottom:1px solid #000; padding:3px; font-size:12px;'>" + txt_agent.Text + " " + consigneeto.ToString() + "</td><td align=left style='border-right:1px solid #000;  border-bottom:1px solid #000; padding:3px; font-size:12px;'>" + notifyto.ToString() + "</td></tr>";
                    }

                }
                sendqry = sendqry + "<tr><td align=left colspan=3 valign=top style='border-bottom:1px solid #000;'><table width=100% border=0 cellspacing=0 cellpadding=0 style='padding:3px; font-size:12px;'><tr><td width=16% style='font-size:12px;'>MAWB NO. & DATE</td><td>:</td><td width=16%>" + MAWB.ToString() + "</td> <td width=16% style='font-size:12px;'>CONSOL REF #</td><td width=1%>:</td><td width=16% style='font-size:12px;'>" + txt_jobno.Text + "</td><td>FLIGHT # </td><td width=1%; style='font-size:12px;'>:</td><td width=16% style='font-size:12px;'>" + flitno.ToString() + "</td></tr></td></tr>";

                sendqry = sendqry + "<tr><td style='font-size:12px;'>CARRIER</td><td>:</td><td  style='font-size:12px;'><p>" + txt_airline.Text + "</p></td> <td  style='font-size:12px;'></td><td  style='font-size:12px;'></td><td  style='font-size:12px;'></td><td  style='font-size:12px;'></td></tr>";
                sendqry = sendqry + "<tr><td  style='font-size:12px;'>PORT OF LOADING</td><td  style='font-size:12px;'>:</td><td style='background-color:#c0c0c0; font-size:12px;'>" + dt_new.Rows[0]["polcode"].ToString() + "</td> <td style='font-size:12px;'>PORT OF DESTINATION </td><td style='font-size:12px;'>:</td><td style='background-color:#c0c0c0; font-size:12px;'>" + dt_new.Rows[0]["fdcode"].ToString() + "</td><td style='font-size:12px;'></td><td style='font-size:12px;'></td></tr>";
                sendqry = sendqry + "<tr><td style='font-size:12px;'>NO OF PACKAGES</td><td style='font-size:12px;'>:</td><td style='font-size:12px;'>" + noofpkgs.ToString() + "  Bags</td> <td></td><td></td><td></td><td></td></tr>";
                sendqry = sendqry + "<tr><td style='font-size:12px;'>GROSS WEIGHT</td><td>:</td><td style='font-size:12px;'>" + tot_grosswt.ToString() + " KGS</td> <td style='font-size:12px;'></td><td style='font-size:12px;'></td><td style='font-size:12px;'></td><td style='font-size:12px;'></td></tr>";
                sendqry = sendqry + "<tr><td>CHARGE WEIGHT</td><td>:</td><td>" + tot_volume.ToString() + "  KGS</td> <td></td><td></td><td></td><td></td></tr></table>";
                sendqry = sendqry + "<tr><td align=left colspan=3 style='padding:3px; font-size:12px;'><table width=100% border=0 cellspacing=0 cellpadding=3 class=TblGridtable' style='font-size:12px;'><tr><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px; white-space:nowrap;'>S # </td><td  style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>HAWB NO.</td><td  style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>NO OF PKGS</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>GR. WT(KGS)</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>VOL. WT(KGS)</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>COMMODITY</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>SHIPPER</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>CONSIGNEE</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>DIMENSIONS</td></tr>";

                if (dt_new.Rows.Count > 0)
                {
                    for (i = 0; i < dt_new.Rows.Count; i++)
                    {
                        if (direct == "Y")
                        {
                            sendqry = sendqry + "<tr style='border-bottom:1px solid #000;'><td nowrap=nowrap style='font-size:12px;border-right:1px solid #000;  border-bottom:1px solid #000; white-space: nowrap;'>" + i + 1 + "</td><td style='border-right:1px solid #000;  border-bottom:1px solid #000; font-size:12px;'></td>" + " " + "<td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>" + dt_new.Rows[0]["noofpkgs"].ToString() + "</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>" + dt_new.Rows[0]["grosswt"].ToString() + "</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>" + DtA_Details.Rows[0]["volwt"].ToString() + "</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>" + commidty.ToString() + "</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>" + dt_new.Rows[0]["shipper"].ToString() + " " + shiperto1 + " </td><td style='border-right:1px solid #000;border-bottom:1px solid #000; font-size:12px;'>" + dt_new.Rows[0]["consignee"].ToString() + " " + consigneeto1 + "</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>Dimension in Length / Breadth / Width / Pieces<br/>";

                        }
                        else
                        {
                            sendqry = sendqry + "<tr style='border-bottom:1px solid #000;'><td nowrap=nowrap style='font-size:12px;border-right:1px solid #000;  border-bottom:1px solid #000; white-space: nowrap;'>" + i + 1 + "</td><td style='border-right:1px solid #000;  border-bottom:1px solid #000; font-size:12px;'> " + dt_new.Rows[0]["blno"].ToString() + "</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>" + dt_new.Rows[0]["noofpkgs"].ToString() + "</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>" + dt_new.Rows[0]["grosswt"].ToString() + "</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>" + DtA_Details.Rows[0]["volwt"].ToString() + "</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>" + commidty.ToString() + "</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>" + dt_new.Rows[0]["shipper"].ToString() + " " + shiperto1 + "</td><td style='border-right:1px solid #000;border-bottom:1px solid #000; font-size:12px;'>" + dt_new.Rows[0]["consignee"].ToString() + " " + consigneeto1 + "</td><td style='border-right:1px solid #000; border-bottom:1px solid #000; font-size:12px;'>Dimension in Length / Breadth / Width / Pieces<br/>";
                        }
                        if (Dt_Dimension.Rows.Count > 0)
                        {

                            for (i = 0; i < Dt_Dimension.Rows.Count; i++)
                            {
                                dimsionnew[i] = Dt_Dimension.Rows[i]["length"].ToString() + "/" + Dt_Dimension.Rows[i]["breadth"].ToString() + "/" + Dt_Dimension.Rows[i]["width"].ToString() + "/" + Dt_Dimension.Rows[i]["pieces"].ToString();
                                sendqry = sendqry + dimsionnew[i] + "<br/>";
                            }

                        }
                        sendqry = sendqry + "</td></tr>";
                    }
                }

                sendqry = sendqry + "</table>";

                if (dt_new.Rows.Count > 0)
                {

                    sendqry = sendqry + "<tr><td colspan=3 style='padding:3px; font-size:12px;'><table width=100% border=0 cellspacing=0 cellpadding=0><tr> <td width=16% style='font-size:12px;'>TOTAL</td><td width=83% style='font-size:12px;'></td> </tr> <tr> <td style='font-size:12px;'>CHARGE WEIGHT</td><td style='font-size:12px;'><div style='width:200px; background-color:#c0c0c0;'>" + tot_volume.ToString() + " KGS </div></td><td></td></tr></table></td></tr>";
                }
                sendqry = sendqry + "</table>";
                div_body.Visible = true;
                div_body.InnerHtml = Server.HtmlDecode(sendqry);

            }

            string usermail = null;
            string empmailadd = "";








 if (str_trantype == "AE")
            {

                Utility.SendMail(Session["usermailid"].ToString(), empmailadd, "New Job # : " + txt_jobno.Text, sendqry, "", Session["usermailpwd"].ToString());
            }

            //}




        }

        protected void btn_agentbooking1_Click(object sender, EventArgs e)
        {
            checkpolPod();
            if (brr == true)
            {
                brr = false;
                return;
            }


            sendmailforliner();

            /*  try
             {
                 MailMessage Msg = new MailMessage();
                 Msg.From = new MailAddress("dineshkumartmca@gmail.com");
                 Msg.To.Add("dineshkumartmca@gmail.com");
                 Msg.Subject = "testing";
                 Msg.Body = "SenderEmail: " + "dineshkumartmca@gmail.com" + "<br><br>" + "Sample";

                 //if (file.HasFile)
                 //{
                 //    string FileName = System.IO.Path.GetFileName(file.PostedFile.FileName);
                 //    Msg.Attachments.Add(new Attachment(file.PostedFile.InputStream, FileName));
                 //}

                 Msg.IsBodyHtml = true;

                 SmtpClient smtp = new SmtpClient();
                 smtp.Host = "smtp.gmail.com";
                 System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                 //NetworkCred.UserName = "dineshkumartmca@gmail.com";
                 //NetworkCred.Password = "9940840388";

             
                 smtp.UseDefaultCredentials = true;
                 smtp.Credentials = new System.Net.NetworkCredential("dineshkumartmca@gmail.com", "9940840388");
                 smtp.DeliveryMethod = SmtpDeliveryMethod.Network;   
                 smtp.Port = 465;
                 smtp.EnableSsl = true;
                 smtp.Send(Msg);
                 Response.Write("<script>alertify.alert('mail sent')</script>");

             }
             catch
             {
                 Response.Write("<script>alertify.alert('try again')</script>");
             }
               */

            /*
                        try
                        {
                            MailMessage m = new MailMessage();
                            m.Subject = "testing";
                            m.Body = "SenderEmail: " + "dineshkumartmca@gmail.com" + "<br><br>" + "Sample";
                            m.IsBodyHtml = true;
                            m.From = new MailAddress("dineshkumartmca@gmail.com");

                           // m.To = new MailAddress("dineshkumartmca@gmail.com");

                            m.To.Add(new MailAddress("dineshkumartmca@gmail.com"));
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";

                            NetworkCredential authinfo = new NetworkCredential("dineshkumartmca@gmail.com", "9940840388");
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = authinfo;
                            smtp.Send(m);
               




                        }
                        catch (Exception ex)
                        {
                           // return false;
                        }
                        */




        }

        public void checkpolPod()
        {
            DataTable dt_new;
          //  DataAccess.AirImportExports.AIEBLDetails da_obj_blobj = new DataAccess.AirImportExports.AIEBLDetails();
            dt_new = da_obj_blobj.ShowAIEInfoQuery(Convert.ToInt32(txt_jobno.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
            if (dt_new.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt_new.Rows[0]["polcode"].ToString()))
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Kindly Update Air code in Master for the Port " + dt_new.Rows[0]["pol"].ToString() + "');", true);


                    brr = true;
                    return;
                }

                if (!string.IsNullOrEmpty(dt_new.Rows[0]["fdcode"].ToString()))
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Kindly Update Air code in Master for the Port " + dt_new.Rows[0]["fd"].ToString() + "');", true);
                    brr = true;
                    return;
                }

            }
        }

        protected void txt_mawbno_TextChanged(object sender, EventArgs e)
        {
            //DataAccess.ForwardingExports.BLDetails objbl = new DataAccess.ForwardingExports.BLDetails();
            //DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
            DataTable dtbook = new DataTable();
            dtbook = objbl.getsp_getbookingno(txt_mawbno.Text.ToUpper(), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (dtbook.Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('MBL# and Booking# is same');", true);
                txt_mawbno.Text = "";
                txt_mawbno.Focus();
                return;
            }

            DataTable Dtne1 = new DataTable();

            Dtne1 = da_obj_AEJobobj.getLikeAIEblnojob(txt_mawbno.Text.Trim().ToUpper(), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

            if (Dtne1.Rows.Count > 0)
            {
                for (int i = 0; i <= Dtne1.Rows.Count - 1; i++)
                {
                    if (txt_mawbno.Text.ToUpper() == Dtne1.Rows[i][0].ToString().ToUpper())
                    {
                        txt_mawbno.Text = "";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('HAWBL # and MAWB # should not Same,kindly change MAWB # in Job screen');", true);
                        txt_mawbno.Focus();
                        return;
                    }
                }
            }
        }


        protected void btn_mbl_Click(object sender, EventArgs e)
        {
            string usermail = "";
          //  DataAccess.HR.Employee obj_da_hremp = new DataAccess.HR.Employee();
            str_trantype = Session["StrTranType"].ToString();
            string str_sf = "";
            string str_frmname = "";
            string str_RptName = "";
            string str_Script;
            string Str_P = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            string notify = "N";
            string direct = "N";
            //checkpolPod();
            if (brr == true)
            {
                brr = false;
                return;
            }
            if (txt_jobno.Text.ToString() != "")
            {
                str_frmname = "AE JobDetails";
                //if (chk_notify.Checked == true)
                //{
                //    str_RptName = "consolmanifest.rpt";
                //}
                //else
                //{
                //    str_RptName = "consolmanifestwithoutagent.rpt";
                //}

                str_RptName = "AEBLOriginalforjobinfo.rpt";

                //if (chk_notify.Checked == true)
                //{
                //    notify = "Y";
                //}
                //if (chk_directbl.Checked == true)
                //{
                //    direct = "Y";
                //}

              //  DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
                da_obj_AEJobobj.UpdAIEJobInfo1(Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), txt_cargodesc.Text.ToUpper());
                Str_P = "format=" + "" + "~np1=" + "NO" + "~np=" + "NO" + "~np2=" + "NO" + "~WCP=" + 0 + "~WCC=" + 0 + "~TOCDAP=" + 0 + "~TOCDAC=" + 0 + "~TOCDCP=" + 0 + "~TOCDCC=" + "";

                str_sf = "{AEJobInfo.jobno}=" + txt_jobno.Text + " and " + "{AEJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + Str_P + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_Script = "window.open('../Reportasp/AEBLOriginalforjobinfo.aspx?jobno=" + txt_jobno.Text + "&bid=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + "&np1=" + "Yes" + "&np2=" + "Yes" + "&draft=" + 0 + "&" + this.Page.ClientQueryString + "','','');";

                ScriptManager.RegisterStartupScript(btn_agentbooking, typeof(Button), "Shipment Details", str_Script, true);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = Str_P;
            }


        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
        protected void grdBookJob_PreRender(object sender, EventArgs e)
        {
            if (grdBookJob.Rows.Count > 0)
            {
                grdBookJob.UseAccessibleHeader = true;
                grdBookJob.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_PreRender(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                grd.UseAccessibleHeader = true;
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void Btnamendmbl_Click(object sender, EventArgs e)
        {
            DataTable dtuser;
            if (Session["StrTranType"].ToString() == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1923, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_jobno.Text != "")
                    {
                        iframe2.Attributes["src"] = "../AI/AmendMBL.aspx?jobno=" + txt_jobno.Text + "&link=../AE/AEJobInfo.aspx";
                        ModalPopupExtender1.Show();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Job # cannot be Empty!');", true);
                        txt_jobno.Focus();
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            else if (Session["StrTranType"].ToString() == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1922, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_jobno.Text != "")
                    {
                        iframe2.Attributes["src"] = "../AI/AmendMBL.aspx?jobno=" + txt_jobno.Text + "&link=../AE/AEJobInfo.aspx";
                        ModalPopupExtender1.Show();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Job # cannot be Empty!');", true);
                        txt_jobno.Focus();
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
           
        }
        protected void Btnamendjob_Click(object sender, EventArgs e)
        {
            DataTable dtuser;
            if (Session["StrTranType"].ToString() == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(91, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_jobno.Text != "")
                    {
                        iframe1.Attributes["src"] = "../ForwardExports/ChangeJob.aspx?jobno=" + txt_jobno.Text;
                        pop_up.Show();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Job # cannot be Empty!');", true);
                        txt_jobno.Focus();
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            else if (Session["StrTranType"].ToString() == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(90, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_jobno.Text != "")
                    {
                        iframe1.Attributes["src"] = "../ForwardExports/ChangeJob.aspx?jobno=" + txt_jobno.Text;
                        pop_up.Show();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Job # cannot be Empty!');", true);
                        txt_jobno.Focus();
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }



            
        }
        protected void btn_sendmail_Click(object sender, EventArgs e)
        {
            //if (ddl_product.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "iFact Touch", "alert('Please Select the Product Type');", true);
            //    ddl_product.Focus();
            //    return;
            //}
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            //DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
            if (txt_jobno.Text.Trim().Length > 0)
            {
                DataTable obj_dt = new DataTable();
                string str_Empmail = "";
                DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                DataAccess.UserPermission obj_da_user = new DataAccess.UserPermission();

                //obj_dt = obj_da_user.GetMLEmpid(obj_da_user.GetMLUiid("FI", "D.O.Issue"), int_bid);
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "AE")
                    {
                        obj_dt = obj_da_user.GetMLEmpprealrt("AE");
                    }
                    else if (Session["StrTranType"].ToString() == "FE")
                    {
                        obj_dt = obj_da_user.GetMLEmpprealrt("FE");
                    }
                }

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    str_Empmail = obj_dt.Rows[0]["mailid"].ToString();
                }
                string Str_Temp = "";

                if (str_Empmail.Trim().Length > 0)
                {
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        //Str_Temp = Fn_SendPrealert();
                    }
                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        Str_Temp = Fn_SendPrealertAE();
                    }
                    div_body.Visible = true;
                    div_body.InnerHtml = Server.HtmlDecode(Str_Temp);// Server.HtmlDecode("<table border=1><tr><td>test</td></tr></table>");
                                                                     //txtMailBody.Text = Server.HtmlEncode(Str_Temp);
                                                                     //str_Empmail = "nambi@ltsolutions.co.in;rajbarath@ltsolutions.co.in"; //str_Empmail.Substring(0, str_Empmail.Length - 1);
                    if (Session["StrTranType"].ToString() == "AE")
                    {
                        Utility.SendMail("air@marinair.in", str_Empmail, " PreAlert Job # : " + txt_jobno.Text + "" + subject.ToString(), Str_Temp, "", "arumugam369*");
                    }
                    else if (Session["StrTranType"].ToString() == "FE")
                    {
                        Utility.SendMail(Session["usermailid"].ToString(), str_Empmail, lblheader.Text + "  PreAlert Job # : " + txt_jobno.Text, Str_Temp, "", Session["usermailpwd"].ToString());

                    }
                    if (Session["StrTranType"].ToString() == "AE")
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1854, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + "/Job #: " + txt_jobno.Text + "/ Send");
                    }
                    else if (Session["StrTranType"].ToString() == "FE")
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 201, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + "/Job #: " + txt_jobno.Text + "/ Send");
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "iFact Touch", "alert('Mail Sent To Them "+ str_Empmail + "');", true);
                }


            }

            UserRights();

        }
        private string Fn_SendPrealertAE()
        {
            string str_temp = "";
            string data1 = " ";
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            DataTable obj_dtnewdate = new DataTable();
          //  DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();

            //str_temp = str_temp + "<html><body>";

            //obj_dt = obj_da_log.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));

            //if (obj_dt.Rows.Count > 0)
            //{
            //    str_temp = str_temp + "<html><body text=black><center> <FONT FACE=Arial SIZE=4>" + obj_dt.Rows[0].ItemArray[0].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + obj_dt.Rows[0].ItemArray[1].ToString() + " <br> Phone : " + obj_dt.Rows[0].ItemArray[2].ToString() + " Fax : " + obj_dt.Rows[0].ItemArray[3].ToString() + "</Font></center><HR width=100%></body>";
            //}

            str_temp = str_temp + "<FONT FACE=Courier New SIZE=2 color=black><table border=0 cellspacing=0 cellpadding=0 style='border:0px solid #000;  font-family:Tahoma, Geneva, sans-serif; font-size:12px;'><tr><td align=left><b>Dear Sir/Madam,<b></td></tr><tr></tr><tr></tr><br><br></table> ";
            //str_temp = str_temp + "<FONT FACE=Courier New SIZE=2 color=black><table style=font-size:10pt; width=100%><tr><td align=left><b>Please Find the details for FCL Shipment from " + txt_pol.Text + " to " + hid_fd.Value.ToString() + "<b></td></tr><br><br>";

            str_temp = str_temp + "<br>";
            str_temp = str_temp + "<br>";
            //DataAccess.ChangeJob.ChangeJob obj_da_changejob = new DataAccess.ChangeJob.ChangeJob();
            //DataAccess.AirImportExports.AIEBLDetails da_obj_AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
            DataTable Dt_AIEDetails = new DataTable();
            //DataAccess.AirImportExports.AICAN obj_aican = new DataAccess.AirImportExports.AICAN();
            obj_dt = obj_da_changejob.GetBLDetails(Convert.ToInt32(txt_jobno.Text), "AE", Convert.ToInt32(Session["LoginBranchid"].ToString()));
            //obj_aican.Updateprealert(Convert.ToDateTime(Utility.fn_ConvertDate(Txt_clearance.Text)), Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), txt_invoice.Text, txt_porefno.Text);
           // DataAccess.Accounts.Invoice obj_inv = new DataAccess.Accounts.Invoice();

            DataTable dtsp = new DataTable();



            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
            {
                obj_dttemp = da_obj_AEBLobj.GetAIEDetail(obj_dt.Rows[i]["blno"].ToString().ToUpper(), "AE", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                {
                    //str_temp = str_temp +"";
                    //str_temp = str_temp + "<table width=70% border=0 cellspacing=0 cellpadding=0 style='border:1px solid #000;  font-family:Tahoma, Geneva, sans-serif; font-size:12px;'><tr><td colspan=3 style='border-bottom:1px solid #000; text-align:center; padding:3px;'><table width=100% border=0 cellspacing=0 cellpadding=0> <tr> <td width=13%><img src='../images/MarinAir_org.png' width=106 height=43 /></td><td width=87% align='center'><h3 style='padding:5px; margin:5px; font-family:Tahoma, Geneva, sans-serif; font-size:21px; font-weight:normal;'>MARINAIR CARGO INDIA PVT LTD - DEMO</h3><p style='font-family:Tahoma, Geneva, sans-serif; padding:3px; margin:0px; font-size:13px;'>9/278-A, RADHAKRISHNA STREET, NEELAKADU,AMMAPALAYAM,TIRUPUR - 641652<br />Phone # : +91 421 2256 928     Fax # :123456789</p></td></tr></table></td></tr>";
                    if (!string.IsNullOrEmpty(obj_dttemp.Rows[j]["hawblno"].ToString()))
                    {
                        dtsp = obj_inv.Get_shipper(Convert.ToInt32(Session["LoginBranchid"]), "AE", obj_dttemp.Rows[j]["hawblno"].ToString());
                    }
                    str_temp = str_temp + "<table width=70% border=0 cellspacing=0 cellpadding=0 style='border:1px solid #000;  font-family:Tahoma, Geneva, sans-serif; font-size:12px;'>";
                    str_temp = str_temp + "<tr><th colspan=2 width=405 style='background-color:#538ed5; padding:3px; font-family:Tahoma, Geneva, sans-serif; font-size:14px; font-weight:normal; '>Prealert</th><th width=405 style='background-color:#8db4e3; padding:3px; font-family:Tahoma, Geneva, sans-serif; font-size:14px; font-weight:normal;'>Air</th></tr>";
                    str_temp = str_temp + "<tr><td width=350 style='padding:3px;'>Departure / Destination </td><td width=1 style='padding:3px;'>:</td><td width=404 style='padding:3px;'>" + obj_dttemp.Rows[j]["FROMportairportcode"].ToString() + "  /  " + obj_dttemp.Rows[j]["toportairportcode"].ToString() + "  </td></tr>";
                    str_temp = str_temp + "<tr><td width=350 style='padding:3px;'>MAWB</td><td width=1 style='padding:3px;'>:</td><td width=404 style='padding:3px;'>" + txt_mawbno.Text.ToString() + " </td></tr>";
                    str_temp = str_temp + "<tr><td width=404 style='padding:3px;'>HAWB</td><td width=1 style='padding:3px;'>:</td><td width=404 style='padding:3px;'>" + obj_dttemp.Rows[j]["hawblno"].ToString() + " </td></tr>";

                    string dateofclr = obj_dttemp.Rows[j]["dateofclrance"].ToString();

                    if (dateofclr == "" || dateofclr == null)
                    {
                       // DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
                        hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                        str_temp = str_temp + "<tr><td width=404 style='padding:3px;'>Date of Clearance</td><td width=1 style='padding:3px;'>:</td><td width=404 style='padding:3px;'>" + Convert.ToDateTime(hid_date.Value).ToString("dd/MM/yyyy") + "</td></tr>";
                    }
                    else
                    {

                        str_temp = str_temp + "<tr><td width=404 style='padding:3px;'>Date of Clearance</td><td width=1 style='padding:3px;'>:</td><td width=404 style='padding:3px;'>" + Convert.ToDateTime(obj_dttemp.Rows[j]["dateofclrance"]).ToString("dd/MM/yyyy") + "</td></tr>";
                    }
                    str_temp = str_temp + "<tr><td style='padding:3px;'>PO/Or.No./Style nr/Ref</td><td style='padding:3px;'>:</td><td style='padding:3px;'>" + obj_dttemp.Rows[j]["porefno"].ToString() + "</td></tr>";
                    str_temp = str_temp + "<tr><td style='padding:3px;'>Shipper/Exporter/Consignor</td><td style='padding:3px;'>:</td><td style='padding:3px;'>" + obj_dttemp.Rows[j]["shipper"].ToString() + "</td></tr>";
                    if (chk_notify.Checked == true)
                    {
                        str_temp = str_temp + "<tr><td style='padding:3px;'>Notify</td><td style='padding:3px;'>:</td><td style='padding:3px;'>" + obj_dttemp.Rows[j]["notIFyparty1"].ToString() + "</td></tr>";
                    }
                    if (dtsp.Rows.Count > 0)
                    {

                        //   str_temp = str_temp + "<tr><td style='padding:3px;'>Invoice # / Date </td><td style='padding:3px;'>:</td><td style='padding:3px;'>" + dtsp.Rows[0]["shipperinvoice"].ToString().ToUpper() +"</td></tr>";

                        for (int k = 0; k <= dtsp.Rows.Count - 1; k++)
                        {
                            data1 += " " + dtsp.Rows[k]["shipperinvoice"].ToString().ToUpper();
                        }
                        str_temp = str_temp + "<tr><td style='padding:3px;'>Invoice # / Date </td><td style='padding:3px;'>:</td><td style='padding:3px;'>" + data1 + "</td></tr>";

                    }
                    else
                    {
                        //  str_temp = str_temp + "<tr><td style='padding:3px;'>Invoice # / Date </td><td style='padding:3px;'>:</td><td style='padding:3px;'>" + dtsp.Rows[j]["invno"].ToString().ToUpper() + "</td></tr>";

                        for (int k = 0; k <= dtsp.Rows.Count - 1; k++)
                        {
                            data1 += " " + dtsp.Rows[k]["invno"].ToString().ToUpper();
                        }
                        str_temp = str_temp + "<tr><td style='padding:3px;'>Invoice # / Date </td><td style='padding:3px;'>:</td><td style='padding:3px;'>" + data1 + "</td></tr>";
                    }

                    str_temp = str_temp + "<tr><td style='padding:3px;'>Importer/Consignee</td><td style='padding:3px;'>:</td><td style='padding:3px;'>" + obj_dttemp.Rows[j]["consignee"].ToString() + "</td></tr>";
                    str_temp = str_temp + "<tr><td style='padding:3px;'>Commodity</td><td style='padding:3px;'>:</td><td style='padding:3px;'>" + obj_dttemp.Rows[j]["cargotype"].ToString() + "</td></tr>";
                    str_temp = str_temp + "<tr><td style='padding:3px;'>Package</td><td style='padding:3px;'>:</td><td style='padding:3px;'>" + obj_dttemp.Rows[j]["noofpkgs"].ToString() + " " + obj_dttemp.Rows[j]["pkgid"].ToString() + "</td></tr>";
                    str_temp = str_temp + "<tr><td style='padding:3px;'>Gross Weight</td><td style='padding:3px;'>:</td><td style='padding:3px;'>" + obj_dttemp.Rows[j]["grosswt"].ToString() + "</td></tr>";
                    str_temp = str_temp + "<tr><td style='padding:3px;'>Chargeable weight</td><td style='padding:3px;'>:</td><td style='padding:3px;'>" + obj_dttemp.Rows[j]["chargewt"].ToString() + "</td></tr>";
                    str_temp = str_temp + "<tr><td colspan=2 style='background-color:#538ed5; padding:3px; font-family:Tahoma, Geneva, sans-serif; font-size:14px; font-weight:normal;'>Schedule</td><td style='background-color:#8db4e3; padding:3px; font-family:Tahoma, Geneva, sans-serif; font-size:14px; font-weight:normal;'>" + obj_dttemp.Rows[j]["liner"].ToString() + "</td></tr>";
                    str_temp = str_temp + "</table>";
                    str_temp = str_temp + "";
                    str_temp = str_temp + "<br>";

                    /*str_temp = str_temp + "<table cellpadding=2 cellspacing=5 width=60%  style=font-family:Courier New;font-size:8pt><tr><td  align=left><b>HABL # <b></td><td valign=top>:</td><td>" + obj_dttemp.Rows[j]["hawblno"].ToString() + "</td></tr>";
                    str_temp = str_temp + "<tr><td valign=top align=left><b>MABL #<b></td><td valign=top>:</td><td valign=top> " + txt_mbl.Text.ToString() + "</td></tr>";
                    str_temp = str_temp + "<tr><td valign=top align=left><b>Date of Clearance<b></td><td valign=top>:</td><td valign=top> " + "Date" + "</td></tr>";
                    str_temp = str_temp + "<tr><td valign=top align=left><b>PO/Or.No./Style nr/Ref<b></td><td valign=top>:</td><td valign=top> " + "PO #" + "</td></tr>";
                    str_temp = str_temp + "<tr><td valign=top align=left><b>Shipper/Exporter/Consignor<b></td><td valign=top>:</td><td valign=top> " + obj_dttemp.Rows[j]["shipper"].ToString() + "</td></tr>";
                    str_temp = str_temp + "<tr><td valign=top align=left><b>Invoice Nr<b></td><td valign=top>:</td><td valign=top> " + "INV #" + "</td></tr>";
                    str_temp = str_temp + "<tr><td valign=top align=left><b>Importer/Consignee<b></td><td valign=top>:</td><td valign=top> " + obj_dttemp.Rows[j]["shipper"].ToString() + "</td></tr>";
                    str_temp = str_temp + "<tr><td valign=top align=left><b>Commodity<b></td><td valign=top>:</td><td valign=top> " + obj_dttemp.Rows[j]["cargotype"].ToString() + "</td></tr>";
                    str_temp = str_temp + "<tr><td valign=top align=left><b>Package<b></td><td valign=top>:</td><td valign=top> " + obj_dttemp.Rows[j]["noofpkgs"].ToString() + " " + obj_dttemp.Rows[j]["pkgid"].ToString() + "</td></tr>";
                    str_temp = str_temp + "<tr><td valign=top align=left><b>Gross Weight<b></td><td valign=top>:</td><td valign=top> " + obj_dttemp.Rows[j]["grosswt"].ToString() + "</td></tr>";
                    str_temp = str_temp + "<tr><td valign=top align=left><b>Chargeable weight<b></td><td valign=top>:</td><td valign=top> " + obj_dttemp.Rows[j]["chargewt"].ToString() + "</td></tr>";
                    str_temp = str_temp + "<tr><td valign=top align=left><b>Schedule<b></td><td valign=top>:</td><td valign=top> " + obj_dttemp.Rows[j]["liner"].ToString() + "</td></tr>";

                    str_temp = str_temp + "</table><br><HR><br>";*/




                    if (dateofclr == "" || dateofclr == null)
                    {
                      //  DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
                        hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                        subject = " / " + txt_mawbno.Text.ToString() + " / " + obj_dttemp.Rows[j]["shipper"].ToString() + " / " + obj_dttemp.Rows[j]["consignee"].ToString() + " / " + Convert.ToDateTime(hid_date.Value).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        subject = " / " + txt_mawbno.Text.ToString() + " / " + obj_dttemp.Rows[j]["shipper"].ToString() + " / " + obj_dttemp.Rows[j]["consignee"].ToString() + " / " + Convert.ToDateTime(obj_dttemp.Rows[j]["dateofclrance"]).ToString("dd/MM/yyyy");
                    }



                }

            }

            //str_temp = str_temp + "</table   cellpadding=2 cellspacing=5>"; txt_Note.Text
            str_temp = str_temp + "<table   width=1000><tr></tr><tr><td  align=left valign=top  style=font-family:Courier New;font-size:9pt;font-color:black;><b> Note <b></td><td style=font-family:Courier New;font-size:9pt valign=top> " + "" + "</td></tr></table>";
            str_temp = str_temp + "<table  style=font-family:Courier New;font-size:8pt><tr><td>With Regards<tr><td><br />" + Session["LoginEmpName"].ToString() + "</td></tr></table>";
            //str_temp = str_temp + "</body></html>";
            //str_temp = str_temp + "</table>";
            //str_temp = str_temp + "<table width=100% text=black><tr><td align=left>Best Regards </td></tr></table><br><br>";
            //str_temp = str_temp + "<table width=100% text=black><tr><td align=left>" + Session["LoginEmpName"].ToString() + " </td></tr></table></body></html>";
            return str_temp;


        }

    }
}