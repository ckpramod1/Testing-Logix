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

namespace logix.FI
{
    public partial class jobinfo : System.Web.UI.Page
    {
        public static Boolean btndelete;
        DataAccess.ForwardingImports.BLDetails blobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterContainer conttypeobj = new DataAccess.Masters.MasterContainer();
        DataAccess.ForwardingImports.BLDetails bldetailsobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.Masters.BudgetVActual BVAobj = new DataAccess.Masters.BudgetVActual();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
        DataAccess.ForwardingImports.JobInfo da_obj_jobinfo = new DataAccess.ForwardingImports.JobInfo();
        DataTable dtbk = new DataTable();
        DataAccess.Accounts.Invoice INVobj = new DataAccess.Accounts.Invoice();
        DataTable DaTMBL = new DataTable();
        DataTable dt_job = new DataTable();
        DataSet dsJobinfo;
        DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
        DataAccess.ForwardingExports.JobInfo FEJobobj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.Marketing.Booking book = new DataAccess.Marketing.Booking();
        DataTable obj_dt = new DataTable();
        DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();
        DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.ForwardingExports.JobInfo obj_da_Job = new DataAccess.ForwardingExports.JobInfo();
        DataTable dsJob = new DataTable();
        int int_jobtype;
        string str_intagent;
        string str_intmlo;
        string str_stragent;
        string strmlo;
        string str_stragentlocation;
        string str_strmlolocation;
        DateTime date_dteeta;
        string str_dteeta;
        DateTime date_dteetb;
        string str_dteetb;
        int int_pol;
        int int_pod;
        DateTime date_dtembl;
        string str_dtembl;
        //int intCFSid;
        string str_strcfslocation;
        string strjobclose;
        string str_oldcont;
        string str_status;
        string str_sf = "";
        string str_SP = "";
        string str_RptName = "";
        string str_frmname = "";
        string str_Script = "";
        string str_Script1 = "";
        string str_Script2 = "";
        int intjobtype;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string oldcont;
        string Ctrl_List1;
        string Msg_List1;
        string Dtype_List1;
        string str_FornName, str_Uiid;
        int branchid, back = 0;
        Boolean blrr;
        int bookno;
        int custid;
        string booking;
        string book_select;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);


            if (IsPostBack != true)
            {
                try
                {
                    Session["FromName"] = lbl_Header.Text;
                    page_load_cod();
                    
                    grdBookJob.DataSource = Utility.Fn_GetEmptyDataTable();
                    grdBookJob.DataBind();

                    Ctrl_List = txt_vessel.ID + "~" + hf_vesselid.ID + "~" + txt_voyage.ID + "~" + txt_imno.ID + "~" + txt_pol.ID + "~" + hf_porid.ID + "~" + txt_pod.ID + "~" + hf_podid.ID + "~" + txt_mblno.ID + "~" + txt_MLO.ID + "~" + hf_intMLOid.ID + "~" + txt_Agent.ID + "~" + hf_intAgentid.ID + "~" + txt_cfs.ID + "~" + hf_intCFSid.ID;
                    Msg_List = "Vessel ( Feeder Vessel / Direct )~Vessel ( Feeder Vessel / Direct )~Voyage~IM NUMBER~Load Port~Load Port~Discharge Port~Discharge Port~MBLNO #~MLO~MLO~Agent~Agent~C F S~C F S";
                    Dtype_List = "string~Autocomplete~string~string~string~Autocomplete~string~Autocomplete~string~string~Autocomplete~string~Autocomplete~string~Autocomplete~Autocomplete";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "');");

                    Ctrl_List1 = txt_Container.ID + "~" + ddl_cmbSize.ID + "~" + txt_Seal.ID + "~" + txt_Pkgs.ID + "~" + txt_Wt.ID + "~" + txt_isocode.ID + "~" + txt_SocFlag.ID;
                    Msg_List1 = "Container #~Size~Seal #~Pkgs~Wt(MT)~ISO Code~Soc Flag";
                    Dtype_List1 = "string~Dropdown~string~int~int~string~string";
                    //btn_add.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List1 + "','" + Msg_List1 + "','" + Dtype_List1 + "');");

                    txt_Pkgs.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    txt_CTotal.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    txt_Wt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
                    txt_jobno.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    btn_back.Text = "Cancel";
                    
                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";

                    BindBooking();
                    if (Request.QueryString.ToString().Contains("back"))
                    {
                        txt_jobno.Text = Request.QueryString["job"].ToString();
                        txt_jobno_TextChanged(sender, e);
                    }
                    if (Request.QueryString.ToString().Contains("JobDetails"))
                    {
                        hidbooking.Value = Request.QueryString["bookingno"].ToString();
                        custid = Convert.ToInt32(Request.QueryString["Cusid"].ToString());
                        txt_search.Text = hidbooking.Value;
                        Booking_select();
                        // txt_jobno_TextChanged(sender, e);
                        // hidbooking.Value = Request.QueryString["bookingno"].ToString();
                        // custid = Convert.ToInt32(Request.QueryString["jobno"].ToString());
                    }

                    UserRights();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../FormMain.aspx','_top');", true);
                }
            }
            if (Page.IsPostBack)
            {
                WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                int indx = wcICausedPostBack.TabIndex;
                var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                           where control.TabIndex > indx
                           select control;
                ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
            }
            dt_jobdate.Enabled = false;
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

        protected void Booking_fill()
        {
            dtbk = obj_da_Job.sp_getdetailsforemptyjobbookingFI(int.Parse(Session["LoginBranchid"].ToString()), book_select, Session["StrTranType"].ToString());
            if (dtbk.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtbk.Rows[0]["agentid"].ToString()))
                {
                    txt_Agent.Text = dtbk.Rows[0]["agent"].ToString();
                    hf_intAgentid.Value = dtbk.Rows[0]["agentid"].ToString();
                }

                if (!string.IsNullOrEmpty(dtbk.Rows[0]["CarrierID"].ToString()))
                {
                    hdnCarrier.Value = dtbk.Rows[0]["CarrierID"].ToString();
                    txtCarrier.Text = dtbk.Rows[0]["CarrierName"].ToString();
                }

                //if (!string.IsNullOrEmpty(dtbk.Rows[0]["etd"].ToString()))
                //{
                //    dt_ETA.Text = Utility.fn_ConvertDate(dtbk.Rows[0]["etd"].ToString());
                //    dt_ETB".Text = Utility.fn_ConvertDate((Convert.ToDateTime(dtbk.Rows[0]["etd"].ToString()).AddDays(-2)).ToString());
                //}
                //if (!string.IsNullOrEmpty(dtbk.Rows[0]["eta"].ToString()))
                //{
                //    dt_ETA.Text = Utility.fn_ConvertDate(dtbk.Rows[0]["eta"].ToString());
                //}

                if (!string.IsNullOrEmpty(dtbk.Rows[0]["mloid"].ToString()))
                {
                    txt_MLO.Text = dtbk.Rows[0]["mlo"].ToString();
                    hf_intMLOid.Value = dtbk.Rows[0]["mloid"].ToString();
                }
                if (!string.IsNullOrEmpty(dtbk.Rows[0]["polid"].ToString()))
                {
                    txt_pol.Text = dtbk.Rows[0]["pol"].ToString();
                    hf_porid.Value = dtbk.Rows[0]["polid"].ToString();
                }
                if (!string.IsNullOrEmpty(dtbk.Rows[0]["podid"].ToString()))
                {
                    txt_pod.Text = dtbk.Rows[0]["pod"].ToString();
                    hf_podid.Value = dtbk.Rows[0]["podid"].ToString();
                }
                if (!string.IsNullOrEmpty(dtbk.Rows[0]["vesselid"].ToString()))
                {
                    txt_vessel.Text = dtbk.Rows[0]["vesselname"].ToString();
                    hf_vesselid.Value = dtbk.Rows[0]["vesselid"].ToString();
                    txt_voyage.Text = dtbk.Rows[0]["voyage"].ToString();
                }
            }
        }

        protected void Booking_select()
        {
            branchid = Convert.ToInt32(Session["LoginBranchid"]);
            //dtbk = book.GETBookingNofordock(branchid, "FE", custid, 0);
            dtbk = book.GETBookingNoJobInfo(branchid, "FI");
            grdBookJob.DataSource = dtbk;
            grdBookJob.DataBind();

            for (int i = 0; i < dtbk.Rows.Count; i++)
            {
                booking = grdBookJob.Rows[i].Cells[1].Text;
                if (Request.QueryString["bookingno"].ToString() == booking)
                {
                    book_select = grdBookJob.Rows[i].Cells[1].Text;
                    CheckBox chkRow = (grdBookJob.Rows[i].Cells[7].FindControl("ChkMail") as CheckBox);
                    chkRow.Checked = true;
                    //book_select = grdBookJob.Rows[0].Cells[1].Text;
                }

            }
            Booking_fill();
        }
        [WebMethod]
        public static List<string> FE_GetBookingNo(string prefix, string job)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
            obj_dt = bookingobj.GetBookingnosearch(prefix.Trim().ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()), HttpContext.Current.Session["StrTranType"].ToString());
            HttpContext.Current.Session["shiprefno"] = obj_dt;
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "shiprefno");
            return List_Result;
        }


        [WebMethod]
        public static List<string> GetVessel(string prefix)
        {
            List<string> vesselname = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();
            obj_dt = da_obj_vesselobj.GetLikeVessel(prefix.Trim());
            vesselname = Utility.Fn_DatatableToList(obj_dt, "vesselname", "vesselid");
            return vesselname;
        }
        [WebMethod]
        public static List<string> FEJobInfo_GetPort(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
            obj_dt = da_obj_Port.GetLikePort(prefix.Trim().ToUpper());
            List_Result = Utility.Fn_DatatableToList(obj_dt, "portname", "portid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> FIJobInfo_GetCustomer(string prefix, string FType)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_Customer.GetLikeIndianCustomer(prefix.Trim().ToUpper() );
            List_Result = Utility.Fn_DatatableToList_Customer(obj_dt, "customer", "customerid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_da_customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.Marketing.Quotation objQuotation = new DataAccess.Marketing.Quotation();
            obj_dt = obj_da_customerobj.GetLikeIndianCustomer(prefix.Trim());
            //cargo = logix.Utility.Fn_DatatableToList_Customer(obj_dt, "customername", "customerid");
            customer = Utility.Fn_DatatableToList(obj_dt, "customer", "customerid");
            return customer;
        }

        [WebMethod]
        public static List<string> Getcus(string prefix, string strcustype)
        {

            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();

            strcustype = "P";

            obj_dt = da_obj_customerobj.GetLikeCustomer(prefix.Trim().ToUpper(), strcustype);
            customer = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            return customer;
        }

        [WebMethod]
        public static List<string> GetCarrierName(string prefix)
        {
            List<string> customername = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_customerobj.GetLikeCustomer4Carrier(prefix.Trim());
            customername = Utility.Fn_DatatableToList(obj_dt, "customername", "customerid");
            return customername;
        }

        [WebMethod]
        public static List<string> Getcarrier(string prefix, string strcustype)
        {

            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();

            strcustype = "L";
            // strcustype = "1";

            obj_dt = da_obj_customerobj.GetLikeCustomer(prefix.Trim().ToUpper(), strcustype);
            customer = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            return customer;
        }

        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {
                    Boolean btn_delete;
                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                  //  btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void page_load_cod()
        {
            DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
            try
            {
                if (lbl_Header.Text == "Job Info")
                {
                    btn_save.Visible = true;
                     btn_view.Text = "View";



                    btn_view.ToolTip = "View";
                    btn_view1.Attributes["class"] = "btn ico-view";
                    lbldestuff.Visible = false;
                    dt_destuff.Visible = false;
                    lblgodown.Visible = false;
                    txt_Godown.Visible = false;
                    dt_jobdate.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());
                }
                else
                {
                    txtdisable();
                    txt_Godown.Focus();
                    lbldestuff.Visible = true;
                    dt_destuff.Visible = true;
                    lblgodown.Visible = true;
                    txt_Godown.Visible = true;
                    btn_save.Visible = false;
                    btn_view.Text = "Update";
                    btn_view.ToolTip = "Update";
                    btn_view1.Attributes["class"] = "btn ico-update";
                    txt_jobno.Enabled = true;
                    dt_jobdate.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());
                }
                grd_Jobno.Visible = false;
                Contfill();
                btn_back.Enabled = true;
                int divisionid = da_obj_hrempobj.GetDivisionId(Session["LoginDivisionName"].ToString());
                int branch = da_obj_hrempobj.GetBranchId(divisionid, Session["LoginBranchName"].ToString());
                //dt_jobdate.Text = Utility.fn_ConvertDate(Utility.fn_ConvertDate( da_obj_Logobj.GetDate().ToString()));                
                dt_imdate.Text = dt_jobdate.Text;
                dt_ETA.Text = dt_jobdate.Text;
                dt_ETB.Text = dt_jobdate.Text;
                dt_MBL.Text = dt_jobdate.Text;
                dt_destuff.Text = dt_jobdate.Text;
                txt_DocRecdon.Text = dt_jobdate.Text;
                txt_etd.Text = dt_jobdate.Text;
                txt_obldate.Text = dt_jobdate.Text;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void lbl_lnkrate_Click(object sender, EventArgs e)
        {
            loadpagegrid();
            UserRights();
        }

        protected void loadpagegrid()
        {
            try
            {
                dt_job = da_obj_jobinfo.BindJobgrid(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (dt_job.Rows.Count > 0)
                {
                    pnl_Buying.Visible = true;
                    Panel2.Visible = true;
                    Panelreuse.Visible = false;

                    this.Grd_buying_popup.Show();
                    grd_Jobno.Visible = true;
                    grd_Jobno.DataSource = dt_job;
                    grd_Jobno.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(grd_Jobno, typeof(GridView), "Valid", "alertify.alert('Job is empty');", true);
                }
                btn_back.Text = "Cancel";



                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }




        protected void loadpagegridReuse()
        {
            try
            {
                dt_job = da_obj_jobinfo.BindJobgrid(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (dt_job.Rows.Count > 0)
                {
                    pnl_Buying.Visible = true;
                    Panel2.Visible = false;
                    Panelreuse.Visible = true;

                    this.Grd_buying_popup.Show();
                    Grd_reuse.Visible = true;
                    Grd_reuse.DataSource = dt_job;
                    Grd_reuse.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(grd_Jobno, typeof(GridView), "Valid", "alertify.alert('Your Reuse JobNo is empty');", true);
                }
                btn_back.Text = "Cancel";



                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        public void JobDetailsReuse()
        {
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            DataAccess.ForwardingImports.JobInfo da_obj_jobinfo = new DataAccess.ForwardingImports.JobInfo();
            DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.Accounts.Invoice da_obj_INVobj = new DataAccess.Accounts.Invoice();
            DataTable dt_jobinfo = new DataTable();
            try
            {

                if (txt_jobno.Text.ToString() != "")
                {
                    DataTable dt_job = new DataTable();
                    hf_intJobno.Value = Convert.ToString(txt_jobno.Text);
                    if (hf_intJobno.Value.Length > 10)
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid Job #');", true);
                        txt_jobno.Enabled = true;
                        txt_jobno.Text = "";
                        txt_vessel.Focus();
                        return;
                    }
                    dt_job = da_obj_jobinfo.ShowJobDetails(Convert.ToInt32(hf_intJobno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dt_job.Rows.Count > 0)
                    {
                        hf_intjobtype.Value = Convert.ToInt32(dt_job.Rows[0][0].ToString()).ToString();
                        hf_vesselid.Value = dt_job.Rows[0][1].ToString();
                        txt_vessel.Text = da_obj_vesselobj.GetVesselname(Convert.ToInt32(hf_vesselid.Value));
                        CheckVesselName(txt_vessel);
                        txt_voyage.Text = dt_job.Rows[0][2].ToString();
                        str_intagent = dt_job.Rows[0][3].ToString();
                        hf_intAgentid.Value = dt_job.Rows[0][3].ToString();
                        hf_intMLOid.Value = dt_job.Rows[0][4].ToString();
                        str_intmlo = dt_job.Rows[0][4].ToString();
                        str_stragent = da_obj_customerobj.GetCustomername(Convert.ToInt32(dt_job.Rows[0][3].ToString()));
                        strmlo = da_obj_customerobj.GetCustomername(Convert.ToInt32(dt_job.Rows[0][4].ToString()));
                        str_stragentlocation = da_obj_customerobj.GetCustlocation(Convert.ToInt32(dt_job.Rows[0][3].ToString()));
                        str_strmlolocation = da_obj_customerobj.GetCustlocation(Convert.ToInt32(dt_job.Rows[0][4].ToString()));
                        str_dteeta = Utility.fn_ConvertDate(dt_job.Rows[0][5].ToString()).ToString();
                        dt_ETA.Text = (str_dteeta.ToString());
                        str_dteeta = Utility.fn_ConvertDate(dt_job.Rows[0][6].ToString());
                        dt_ETB.Text = (str_dteeta.ToString());
                        hf_porid.Value = dt_job.Rows[0][7].ToString();
                        txt_pol.Text = da_obj_portobj.GetPortname(Convert.ToInt32(hf_porid.Value));
                        hf_podid.Value = dt_job.Rows[0][8].ToString();
                        txt_pod.Text = da_obj_portobj.GetPortname(Convert.ToInt32(hf_podid.Value));
                        //txt_mblno.Text = dt_job.Rows[0][9].ToString();
                        //str_dtembl = Utility.fn_ConvertDate(dt_job.Rows[0][10].ToString()).ToString();
                        //dt_MBL.Text = (str_dtembl.ToString());

                        hdnCarrier.Value = dt_job.Rows[0]["carrierid"].ToString();
                        txtCarrier.Text = dt_job.Rows[0]["carrier"].ToString();



                        if (dt_job.Rows[0]["jobprofit"].ToString() == "P")
                        {
                            CHk_DropFI.Checked = true;
                        }
                        else
                        {
                            CHk_DropFI.Checked = false;
                        }



                        if (string.IsNullOrEmpty(dt_job.Rows[0]["docrecdon"].ToString()) == true)
                        {
                            txt_DocRecdon.Text = "";
                        }
                        else
                        {
                            txt_DocRecdon.Text = dt_job.Rows[0]["docrecdon"].ToString();


                        }


                        if (string.IsNullOrEmpty(dt_job.Rows[0]["obldate"].ToString()) == true)
                        {
                            txt_obldate.Text = "";
                        }
                        else
                        {
                            txt_obldate.Text = dt_job.Rows[0]["obldate"].ToString();


                        }
                        if (string.IsNullOrEmpty(dt_job.Rows[0]["obl"].ToString()) == true)
                        {
                            txt_obl.Text = "";
                        }
                        else
                        {
                            txt_obl.Text = dt_job.Rows[0]["obl"].ToString();


                        }

                        txt_CVslCode.Text = dt_job.Rows[0][11].ToString();
                        txt_CLineCode.Text = dt_job.Rows[0][12].ToString();
                        txt_CAgent.Text = dt_job.Rows[0][13].ToString();
                        txt_CMaster.Text = dt_job.Rows[0][14].ToString();
                        txt_CNation.Text = dt_job.Rows[0][15].ToString();
                        txt_CArrport.Text = da_obj_portobj.GetPortname(Convert.ToInt32(dt_job.Rows[0][16].ToString()));
                        txt_CLastport.Text = da_obj_portobj.GetPortname(Convert.ToInt32(dt_job.Rows[0][17].ToString()));
                        txt_CPort1.Text = da_obj_portobj.GetPortname(Convert.ToInt32(dt_job.Rows[0][18].ToString()));
                        txt_CPort2.Text = da_obj_portobj.GetPortname(Convert.ToInt32(dt_job.Rows[0][19].ToString()));
                        txt_CGRT.Text = dt_job.Rows[0][20].ToString();
                        txt_CNRT.Text = dt_job.Rows[0][21].ToString();
                        txt_CVsltype.Text = dt_job.Rows[0][22].ToString();
                        txt_CTotal.Text = dt_job.Rows[0][23].ToString();
                        txt_imno.Text = dt_job.Rows[0][24].ToString();
                        dt_jobdate.Text = Utility.fn_ConvertDate(dt_job.Rows[0][25].ToString());

                        hf_cfsid.Value = dt_job.Rows[0][26].ToString();
                        txt_cfscode.Text = dt_job.Rows[0][27].ToString();

                        dt_imdate.Text = Utility.fn_ConvertDate(dt_job.Rows[0][29].ToString());
                        dt_destuff.Text = dt_job.Rows[0][28].ToString();
                        txt_Godown.Text = dt_job.Rows[0]["godownno"].ToString();
                        txt_callsign.Text = dt_job.Rows[0]["callsign"].ToString();
                        txt_Bond.Text = dt_job.Rows[0]["bondno"].ToString();
                        txt_MMT.Text = dt_job.Rows[0]["mmtdetails"].ToString();
                        txt_remarks.Text = dt_job.Rows[0]["remarks"].ToString();
                        hf_intCFSid.Value = Convert.ToInt32(Convert.ToInt32(hf_cfsid.Value)).ToString();
                        txt_cfs.Text = da_obj_customerobj.GetCustomername(Convert.ToInt32(hf_cfsid.Value));
                        str_strcfslocation = da_obj_customerobj.GetCustlocation(Convert.ToInt32(hf_cfsid.Value));
                        txt_MLO.Text = strmlo;
                        txt_Agent.Text = str_stragent;

                        ddl_jobtype.SelectedValue = hf_intjobtype.Value;

                        //if (hf_intjobtype.Value == "1")
                        //{
                        //    ddl_jobtype.SelectedValue = "1";
                        //}
                        //else if (hf_intjobtype.Value == "2")
                        //{
                        //    ddl_jobtype.SelectedValue = "1";
                        //}
                        //else if (hf_intjobtype.Value == "3")
                        //{
                        //    ddl_jobtype.SelectedValue = "1";
                        //}
                        //else if (hf_intjobtype.Value == "4")
                        //{
                        //    ddl_jobtype.SelectedValue = "4";
                        //}
                        //else if (hf_intjobtype.Value == "5")
                        //{
                        //    ddl_jobtype.SelectedValue = "5";
                        //}

                        dt_jobinfo = bldetailsobj.GetContainerDetail(Convert.ToInt32(hf_intJobno.Value), Convert.ToString(hf_intJobno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                        Session["Container"] = dt_jobinfo;
                        grd.DataSource = new DataTable();
                        grd.DataBind();
                        txt_jobno.Text = "";
                        btn_save.Text = "Save";

                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";

                        btn_back.Text = "Cancel";


                        btn_back.ToolTip = "Cancel";
                        btn_back1.Attributes["class"] = "btn ico-cancel";
                        btn_back.Enabled = true;

                        btn_save.Enabled = true;
                        //for (int s = 1; s <= 6; s++)
                        //{
                        //    DaTMBL = da_obj_INVobj.CheckIPDCWMBL(Convert.ToString(txt_mblno.Text), "FI", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), Convert.ToInt32(s));
                        //    if (DaTMBL.Rows.Count > 0)
                        //    {
                        //        txt_mblno.Enabled = false;
                        //        break;
                        //    }
                        //    else
                        //    {
                        //        txt_mblno.Enabled = true;
                        //    }
                        //}
                        //DataTable dtchk = new DataTable();
                        //dtchk = FEJobobj.getCheckCNDNForaJOb(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_jobno.Text), "FI");
                        //if (dtchk.Rows.Count != 0)
                        //{
                        //    txt_Agent.Enabled = false;
                        //}
                    }

                    Grd_reuse.Visible = false;

                    //getbookingassigned();
                    UserRights();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }





        protected void txt_jobno_TextChanged(object sender, EventArgs e)
        {
             btn_back.Text = "Cancel";


            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
            dt_jobdate.Enabled = false;
            if (txt_jobno.Text.ToString() != "")
            {
                txt_jobno.Enabled = false;
                JobDetails();
                getbldetails();
                getblno();
            }
            UserRights();
        }
        public void JobDetails()
        {
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            DataAccess.ForwardingImports.JobInfo da_obj_jobinfo = new DataAccess.ForwardingImports.JobInfo();
            DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.Accounts.Invoice da_obj_INVobj = new DataAccess.Accounts.Invoice();
            DataTable dt_jobinfo = new DataTable();
            try
            {
                if (txt_jobno.Text.ToString() != "")
                {
                    DataTable dt_job = new DataTable();
                    hf_intJobno.Value = Convert.ToString(txt_jobno.Text);
                    if (hf_intJobno.Value.Length > 10)
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid Job #');", true);
                        txt_jobno.Enabled = true;
                        txt_jobno.Text = "";
                        txt_vessel.Focus();
                        return;
                    }
                    dt_job = da_obj_jobinfo.ShowJobDetails(Convert.ToInt32(hf_intJobno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dt_job.Rows.Count > 0)
                    {
                        hf_intjobtype.Value = Convert.ToInt32(dt_job.Rows[0][0].ToString()).ToString();
                        hf_vesselid.Value = dt_job.Rows[0][1].ToString();
                        txt_vessel.Text = da_obj_vesselobj.GetVesselname(Convert.ToInt32(hf_vesselid.Value));
                        CheckVesselName(txt_vessel);
                        txt_voyage.Text = dt_job.Rows[0][2].ToString();
                        str_intagent = dt_job.Rows[0][3].ToString();
                        hf_intAgentid.Value = dt_job.Rows[0][3].ToString();
                        hf_intMLOid.Value = dt_job.Rows[0][4].ToString();
                        str_intmlo = dt_job.Rows[0][4].ToString();
                        str_stragent = da_obj_customerobj.GetCustomername(Convert.ToInt32(dt_job.Rows[0][3].ToString()));
                        strmlo = da_obj_customerobj.GetCustomername(Convert.ToInt32(dt_job.Rows[0][4].ToString()));
                        str_stragentlocation = da_obj_customerobj.GetCustlocation(Convert.ToInt32(dt_job.Rows[0][3].ToString()));
                        str_strmlolocation = da_obj_customerobj.GetCustlocation(Convert.ToInt32(dt_job.Rows[0][4].ToString()));
                        str_dteeta = Utility.fn_ConvertDate(dt_job.Rows[0][5].ToString()).ToString();
                        dt_ETA.Text = (str_dteeta.ToString());
                        if (dt_job.Rows[0]["etd"].ToString() != "")
                        {
                            string etd = Utility.fn_ConvertDate(dt_job.Rows[0]["etd"].ToString()).ToString();
                            txt_etd.Text = etd.ToString();
                        }
                        txt_etd.Text = "";
                        str_dteeta = Utility.fn_ConvertDate(dt_job.Rows[0][6].ToString());
                        dt_ETB.Text = (str_dteeta.ToString());
                        hf_porid.Value = dt_job.Rows[0][7].ToString();
                        txt_pol.Text = da_obj_portobj.GetPortname(Convert.ToInt32(hf_porid.Value));
                        hf_podid.Value = dt_job.Rows[0][8].ToString();
                        txt_pod.Text = da_obj_portobj.GetPortname(Convert.ToInt32(hf_podid.Value));
                        txt_mblno.Text = dt_job.Rows[0][9].ToString();
                        str_dtembl = Utility.fn_ConvertDate(dt_job.Rows[0][10].ToString()).ToString();
                        dt_MBL.Text = (str_dtembl.ToString());

                        hdnCarrier.Value = dt_job.Rows[0]["carrierid"].ToString();
                        txtCarrier.Text = dt_job.Rows[0]["carrier"].ToString();



                        if (dt_job.Rows[0]["jobprofit"].ToString() == "P")
                        {
                            CHk_DropFI.Checked = true;
                        }
                        else
                        {
                            CHk_DropFI.Checked = false;
                        }



                        if (string.IsNullOrEmpty(dt_job.Rows[0]["docrecdon"].ToString()) == true)
                        {
                            txt_DocRecdon.Text = "";
                        }
                        else
                        {
                            txt_DocRecdon.Text = dt_job.Rows[0]["docrecdon"].ToString();
                            //txt_DocRecdon.Text = dt_job.Rows[0]["docrecdon"].ToString();
                            //txt_DocRecdon.Text = Convert.ToDateTime(txt_DocRecdon.Text).ToShortDateString();

                        }



                        if (string.IsNullOrEmpty(dt_job.Rows[0]["obldate"].ToString()) == true)
                        {
                            txt_obldate.Text = "";
                        }
                        else
                        {
                            txt_obldate.Text = dt_job.Rows[0]["obldate"].ToString();
                            //txt_DocRecdon.Text = dt_job.Rows[0]["docrecdon"].ToString();
                            //txt_DocRecdon.Text = Convert.ToDateTime(txt_DocRecdon.Text).ToShortDateString();

                        }


                        if (string.IsNullOrEmpty(dt_job.Rows[0]["obl"].ToString()) == true)
                        {
                            txt_obl.Text = "";
                        }
                        else
                        {
                            txt_obl.Text = dt_job.Rows[0]["obl"].ToString();


                        }

                        txt_CVslCode.Text = dt_job.Rows[0][11].ToString();
                        txt_CLineCode.Text = dt_job.Rows[0][12].ToString();
                        txt_CAgent.Text = dt_job.Rows[0][13].ToString();
                        txt_CMaster.Text = dt_job.Rows[0][14].ToString();
                        txt_CNation.Text = dt_job.Rows[0][15].ToString();
                        txt_CArrport.Text = da_obj_portobj.GetPortname(Convert.ToInt32(dt_job.Rows[0][16].ToString()));
                        txt_CLastport.Text = da_obj_portobj.GetPortname(Convert.ToInt32(dt_job.Rows[0][17].ToString()));
                        txt_CPort1.Text = da_obj_portobj.GetPortname(Convert.ToInt32(dt_job.Rows[0][18].ToString()));
                        txt_CPort2.Text = da_obj_portobj.GetPortname(Convert.ToInt32(dt_job.Rows[0][19].ToString()));
                        txt_CGRT.Text = dt_job.Rows[0][20].ToString();
                        txt_CNRT.Text = dt_job.Rows[0][21].ToString();
                        txt_CVsltype.Text = dt_job.Rows[0][22].ToString();
                        txt_CTotal.Text = dt_job.Rows[0][23].ToString();
                        txt_imno.Text = dt_job.Rows[0][24].ToString();
                        dt_jobdate.Text = Utility.fn_ConvertDate(dt_job.Rows[0][25].ToString());

                        hf_cfsid.Value = dt_job.Rows[0][26].ToString();
                        txt_cfscode.Text = dt_job.Rows[0][27].ToString();

                        dt_imdate.Text = Utility.fn_ConvertDate(dt_job.Rows[0][29].ToString());
                        dt_destuff.Text = dt_job.Rows[0][28].ToString();
                        txt_Godown.Text = dt_job.Rows[0]["godownno"].ToString();
                        txt_callsign.Text = dt_job.Rows[0]["callsign"].ToString();
                        txt_Bond.Text = dt_job.Rows[0]["bondno"].ToString();
                        txt_MMT.Text = dt_job.Rows[0]["mmtdetails"].ToString();
                        txt_remarks.Text = dt_job.Rows[0]["remarks"].ToString();
                        hf_intCFSid.Value = Convert.ToInt32(Convert.ToInt32(hf_cfsid.Value)).ToString();
                        txt_cfs.Text = da_obj_customerobj.GetCustomername(Convert.ToInt32(hf_cfsid.Value));
                        str_strcfslocation = da_obj_customerobj.GetCustlocation(Convert.ToInt32(hf_cfsid.Value));
                        txt_MLO.Text = strmlo;
                        txt_Agent.Text = str_stragent;
                        ddl_jobtype.SelectedValue = hf_intjobtype.Value;
                        //if (hf_intjobtype.Value == "1")
                        //{
                        //    rdoConsol.Checked = true;
                        //}
                        //else if (hf_intjobtype.Value == "2")
                        //{
                        //    rdoCoload.Checked = true;
                        //}
                        //else if (hf_intjobtype.Value == "3")
                        //{
                        //    rdoFCL.Checked = true;
                        //}
                        //else if (hf_intjobtype.Value == "4")
                        //{
                        //    rdoMCC.Checked = true;
                        //}
                        //else if (hf_intjobtype.Value == "5")
                        //{
                        //    rdoBuyerConsol.Checked = true;
                        //}
                        DataTable dt;
                        DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                        if (txt_CArrport.Text != "" && txt_CArrport.Text != "0")
                        {
                            dt = obj_MasterPort.SelPortName4typepadimg(txt_CArrport.Text.ToUpper(), Session["StrTranType"].ToString());
                            arrportflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                        }
                        if (txt_CLastport.Text != "" && txt_CLastport.Text != "0")
                        {
                            dt = obj_MasterPort.SelPortName4typepadimg(txt_CLastport.Text.ToUpper(), Session["StrTranType"].ToString());
                            lastportflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                        }
                        if (txt_CPort1.Text != "" && txt_CPort1.Text != "0")
                        {
                            dt = obj_MasterPort.SelPortName4typepadimg(txt_CPort1.Text.ToUpper(), Session["StrTranType"].ToString());
                            cport1flag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                        }
                        if (txt_CPort2.Text != "" && txt_CPort2.Text != "0")
                        {
                            dt = obj_MasterPort.SelPortName4typepadimg(txt_CPort2.Text.ToUpper(), Session["StrTranType"].ToString());
                            cport2flag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                        }
                        dt = obj_MasterPort.SelPortName4typepadimg(txt_pol.Text.ToUpper(), Session["StrTranType"].ToString());
                        flagimg.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                        dt = obj_MasterPort.SelPortName4typepadimg(txt_pod.Text.ToUpper(), Session["StrTranType"].ToString());
                        podflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";


                        dt_jobinfo = bldetailsobj.GetContainerDetail(Convert.ToInt32(hf_intJobno.Value), Convert.ToString(hf_intJobno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                        Session["Container"] = dt_jobinfo;
                        grd.DataSource = dt_jobinfo;
                        grd.DataBind();

                        btn_save.Text = "Update";

                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";
                         btn_back.Text = "Cancel";

                        btn_back.ToolTip = "Cancel";
                        btn_back1.Attributes["class"] = "btn ico-cancel";
                        btn_back.Enabled = true;

                        btn_save.Enabled = true;
                        for (int s = 1; s <= 6; s++)
                        {
                            DaTMBL = da_obj_INVobj.CheckIPDCWMBL(Convert.ToString(txt_mblno.Text), "FI", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), Convert.ToInt32(s));
                            if (DaTMBL.Rows.Count > 0)
                            {
                                txt_mblno.Enabled = false;
                                break;
                            }
                            else
                            {
                                txt_mblno.Enabled = true;
                            }
                        }
                        DataTable dtchk = new DataTable();
                        dtchk = FEJobobj.getCheckCNDNForaJOb(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_jobno.Text), "FI");
                        if (dtchk.Rows.Count != 0)
                        {
                            txt_Agent.Enabled = false;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid Job #');", true);
                        txt_jobno.Enabled = true;
                        txt_jobno.Text = "";
                        txt_jobno.Focus();
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please fill the Job #');", true);
                    txt_jobno.Enabled = true;
                    txt_jobno.Text = "";
                    txt_jobno.Focus();
                    return;
                }
                grd_Jobno.Visible = false;

                getbookingassigned();
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void CheckVesselName(TextBox txtbox)
        {
            DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();
            try
            {
                if (!string.IsNullOrEmpty(txtbox.Text))
                {

                    if (hf_vesselid.Value != "")
                    {
                        DataTable dt_Get = new DataTable();
                        dt_Get = da_obj_vesselobj.GetVesselDetails(Convert.ToInt32(hf_vesselid.Value));
                        if (dt_Get.Rows.Count > 0)
                        {
                            txt_ImoCode.Text = dt_Get.Rows[0]["imocode"].ToString();
                        }
                        else
                        {
                            txt_ImoCode.Text = "";
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

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int count = 0;

            DataAccess.ForwardingImports.JobInfo fijobobj = new DataAccess.ForwardingImports.JobInfo();
            DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();
            DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
            DataAccess.ForwardingExports.JobInfo da_obj_FEJobobj = new DataAccess.ForwardingExports.JobInfo();
            txt_mblno.Text = txt_mblno.Text.ToString();
            txt_vessel_TextChanged(sender, e);
            txt_MLO_TextChanged(sender, e);
            txt_Agent_TextChanged(sender, e);
            txt_pol_TextChanged(sender, e);
            txt_pod_TextChanged(sender, e);
            txt_cfs_TextChanged(sender, e);
            //txtCarrier_TextChanged(sender,e);
            if (hf_vesselid.Value == "0" || hf_vesselid.Value == "")
            {
                txt_vessel.Text = "";
                txt_vessel.Focus();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Vessel ( Feeder Vessel / Direct )');", true);
                return;
            }
            if (blrr == true)
            {
                return;
            }

            txt_mblno.Text = txt_mblno.Text.Trim();
            if (txt_mblno.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Enter the correct MBL # ');", true);
                txt_mblno.Focus();
                return;
            }

            if (CHk_DropFI.Checked == false)
            {
                str_status = "O";
            }
            else if (CHk_DropFI.Checked == true)
            {
                str_status = "P";
            }
            else
            {
                str_status = "";
            }
            try
            {
                if (txt_pol.Text.ToString() != "" && txt_pod.Text.ToString() != "")
                {
                    if (txt_pol.Text.ToString() == txt_pod.Text.ToString())
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Load and Destination Port Should be Different');", true);
                        txt_pod.Focus();
                        return;
                    }
                }





                if (txt_jobno.Text.ToString() != "")
                {
                    if (da_obj_INVOICEobj.CheckClosedJobs("FI", Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString())) == 1)
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Job has Closed Already" + "You Can not Update the Job Details.');", true);
                        return;
                    }
                }
                if ( ddl_jobtype.SelectedValue == "0")//(rdoConsol.Checked == false && rdoCoload.Checked == false && rdoFCL.Checked == false && rdoMCC.Checked == false && rdoBuyerConsol.Checked == false)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Select Shipment Type');", true);
                    return;
                }
                da_obj_vesselobj.UpdateIMOCode(da_obj_vesselobj.GetVesselid(txt_vessel.Text), txt_ImoCode.Text);
                System.DateTime dtDocDate = default(System.DateTime);
                System.DateTime dtoblDate = default(System.DateTime);

                if (string.IsNullOrEmpty(txt_DocRecdon.Text))
                {
                    dtDocDate = Convert.ToDateTime("1/1/1900");
                }
                else
                {
                    dtDocDate = Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_DocRecdon.Text));
                }


                if (string.IsNullOrEmpty(txt_obldate.Text))
                {
                    dtoblDate = Convert.ToDateTime("1/1/1900");
                }
                else
                {
                    dtoblDate = Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_obldate.Text));
                }

                DataTable dtbl = new DataTable();
                dtbl = fijobobj.GetLikeBLNo(txt_mblno.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (dtbl.Rows.Count > 0)
                {
                    for (int i = 0; i <= dtbl.Rows.Count - 1; i++)
                    {
                        string bltext = dtbl.Rows[i].ItemArray[0].ToString().ToUpper();
                        if (bltext.ToUpper() == txt_mblno.Text.ToUpper())
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('BL # and MBL # should not Same,kindly change MBL # in Job screen');", true);
                            txt_mblno.Focus();
                            txt_mblno.Text = "";
                            return;
                        }
                    }
                }

                if (txtCarrier.Text == "")
                {
                    hdnCarrier.Value = "0";
                }
                if (btn_save.ToolTip == "Save")
                {

                    CheckMBL();
                    if (back == 1)
                    {
                        return;
                    }
                    Collectdetails();
                    DataAccess.ForwardingImports.JobInfo da_obj_jobinfo = new DataAccess.ForwardingImports.JobInfo();

                    ///hide on 10mar2022 as per instruction on nambi sir
                    //if (grdBookJob.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i <= grdBookJob.Rows.Count - 1; i++)
                    //    {
                    //        CheckBox chkRowtest = (grdBookJob.Rows[i].Cells[3].FindControl("ChkMail") as CheckBox);
                    //        if (chkRowtest.Checked == true)
                    //        {
                    //            count = 1;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Booking Number empty');", true);
                    //    count = 0;


                    //}

                    //if (count == 0)
                    //{
                    //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select Booking Number');", true);
                    //    count = 0;
                    //    return;
                    //}


                    strjobclose = "N";

                    hf_intJobno.Value = da_obj_jobinfo.InsertJobInfo(Convert.ToInt32(intjobtype), (txt_vessel.Text),
                        (txt_voyage.Text.ToUpper()), Convert.ToInt32(hf_intMLOid.Value), Convert.ToInt32(hf_intAgentid.Value),
                        Convert.ToDateTime(Utility.fn_ConvertDatetime(dt_ETA.Text)).ToString(), Convert.ToDateTime(Utility.fn_ConvertDatetime(dt_ETB.Text)).ToString(),
                        Convert.ToInt32(hf_porid.Value), Convert.ToInt32(hf_podid.Value), (txt_mblno.Text.Trim().ToUpper()),
                        Convert.ToDateTime(Utility.fn_ConvertDatetime(dt_MBL.Text)), (txt_CVslCode.Text),
                       (txt_CLineCode.Text), (txt_CAgent.Text), (txt_CMaster.Text),
                        (txt_CNation.Text), (txt_CArrport.Text), (txt_CLastport.Text),
                       (txt_CPort1.Text), (txt_CPort2.Text), (txt_CGRT.Text),
                        (txt_CNRT.Text), (txt_CVsltype.Text), (txt_CTotal.Text),
                        (txt_imno.Text), Convert.ToDateTime(Utility.fn_ConvertDatetime(dt_jobdate.Text)), Convert.ToInt32(hf_intCFSid.Value),
                        (txt_cfscode.Text), Convert.ToDateTime(Utility.fn_ConvertDatetime(dt_imdate.Text)), (txt_callsign.Text),
                        Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()), txt_Bond.Text,
                        txt_MMT.Text, txt_remarks.Text, Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(dtDocDate), txt_obl.Text, Convert.ToDateTime(dtoblDate)).ToString();


                    da_obj_jobinfo.updjobinfoprofit("FI", Convert.ToInt32(hf_intJobno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), str_status, Convert.ToInt32(hdnCarrier.Value));
                    da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 3, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()),
                        (hf_intJobno.Value) + "/S");
                    if(txt_etd.Text!="")
                    {
                        da_obj_jobinfo.UPDetdinjob(Convert.ToInt32(hf_intJobno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_etd.Text)));

                    }
                    // ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved');", true);
                    //SendDeleiveryStatus();
                    txt_jobno.Text = hf_intJobno.Value;
                    btn_back.Enabled = true;
                    //   ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Job # is: " + hf_intJobno.Value + "');", true);
                    int intBooking;
                    //int count = 0;
                    branchid = Convert.ToInt32(Session["LoginBranchid"]);
                    if (txt_jobno.Text != "")
                    {
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

                            //if (count == 0)
                            //{
                            //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select Booking No');", true);
                            //    count = 0;
                            //    return;
                            //}

                            for (int i = 0; i <= grdBookJob.Rows.Count - 1; i++)
                            {
                                CheckBox chkRow = (grdBookJob.Rows[i].Cells[3].FindControl("ChkMail") as CheckBox);
                                if (chkRow.Checked == true)
                                {
                                    intBooking = Convert.ToInt32(grdBookJob.Rows[i].Cells[0].Text);
                                    book.UpdJobInComBooking(intBooking, Convert.ToInt32(txt_jobno.Text), "FI", branchid, 2);
                                }
                            }
                            if (count != 0)
                            {
                                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved, Job # is " + hf_intJobno.Value + ", Booking Details Updated and Please Update Container');", true);
                                getbookingassigned();
                                BindBooking();
                                count = 0;
                                btn_save.ToolTip = "Update";
                                btn_save1.Attributes["class"] = "btn ico-update";
                                // return;
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid Jobno');", true);
                        return;
                    }
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved, Job # is " + hf_intJobno.Value + ", Please Update Container ');", true);
                    SendDeleiveryStatus();
                     btn_save.Text = "Update";

                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn ico-update";

                }
                else if (btn_save.ToolTip == "Update")
                {
                    DataAccess.ForwardingImports.JobInfo da_obj_jobinfo = new DataAccess.ForwardingImports.JobInfo();
                    hf_intJobno.Value = txt_jobno.Text.ToString();
                    strjobclose = "N";
                    Collectdetails();


                    ///hide on 10mar2022 as per instruction on nambi sir
                    //if (grdBookJob.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i <= grdBookJob.Rows.Count - 1; i++)
                    //    {
                    //        CheckBox chkRowtest = (grdBookJob.Rows[i].Cells[3].FindControl("ChkMail") as CheckBox);
                    //        if (chkRowtest.Checked == true)
                    //        {
                    //            count = 1;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Booking Number empty');", true);
                    //    count = 0;


                    //}

                    //if (count == 0)
                    //{
                    //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select Booking Number');", true);
                    //    count = 0;
                    //    return;
                    //}





                    da_obj_jobinfo.UpdateJobInfo(Convert.ToInt32(hf_intJobno.Value), Convert.ToInt32(intjobtype), (txt_vessel.Text),
                        (txt_voyage.Text.ToUpper()), Convert.ToInt32(hf_intMLOid.Value), Convert.ToInt32(hf_intAgentid.Value),
                        Convert.ToDateTime(Utility.fn_ConvertDatetime(dt_ETA.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(dt_ETB.Text)),
                        Convert.ToInt32(hf_porid.Value), Convert.ToInt32(hf_podid.Value), (txt_mblno.Text.Trim().ToUpper()), Convert.ToDateTime(Utility.fn_ConvertDatetime(dt_MBL.Text)),
                        (txt_CVslCode.Text), (txt_CLineCode.Text), (txt_CAgent.Text),
                        (txt_CMaster.Text), (txt_CNation.Text), (txt_CArrport.Text),
                        (txt_CLastport.Text), (txt_CPort1.Text), (txt_CPort2.Text),
                        (txt_CGRT.Text), (txt_CNRT.Text), (txt_CVsltype.Text),
                        (txt_CTotal.Text), (txt_imno.Text), Convert.ToDateTime(Utility.fn_ConvertDatetime(dt_jobdate.Text)),
                        Convert.ToInt32(hf_intCFSid.Value), (txt_cfscode.Text), Convert.ToDateTime(Utility.fn_ConvertDatetime(dt_imdate.Text)),
                        (txt_callsign.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), (txt_Bond.Text), (txt_MMT.Text),
                        (txt_remarks.Text), dtDocDate, txt_obl.Text, dtoblDate);
                    da_obj_jobinfo.UpdateFIEventJobno(Convert.ToInt32(hf_intJobno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    da_obj_jobinfo.updjobinfoprofit("FI", Convert.ToInt32(hf_intJobno.Value), Convert.ToInt32(Session["LoginBranchid"]), str_status, Convert.ToInt32(hdnCarrier.Value));
                    da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 3, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hf_intJobno.Value) + "/U");

                    if (txt_etd.Text != "")
                    {
                        da_obj_jobinfo.UPDetdinjob(Convert.ToInt32(hf_intJobno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_etd.Text)));

                    }
                   // da_obj_jobinfo.UPDetdinjob(Convert.ToInt32(hf_intJobno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_etd.Text)));


                    //  ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated');", true);
                    int intBooking;
                    //  int count = 0;
                    branchid = Convert.ToInt32(Session["LoginBranchid"]);
                    if (txt_jobno.Text != "")
                    {
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

                            //if (count == 0)
                            //{
                            //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select Booking No');", true);
                            //    count = 0;
                            //    return;
                            //}

                            for (int i = 0; i <= grdBookJob.Rows.Count - 1; i++)
                            {
                                CheckBox chkRow = (grdBookJob.Rows[i].Cells[3].FindControl("ChkMail") as CheckBox);
                                if (chkRow.Checked == true)
                                {
                                    intBooking = Convert.ToInt32(grdBookJob.Rows[i].Cells[0].Text);
                                    book.UpdJobInComBooking(intBooking, Convert.ToInt32(txt_jobno.Text), "FI", branchid, 2);
                                }
                            }
                            if (count != 0)
                            {
                                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Booking Details Updated');", true);
                                getbookingassigned();
                                BindBooking();
                                count = 0;
                                // return;
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid Jobno');", true);
                        return;
                    }
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Update for Job # " + hf_intJobno.Value + "');", true);
                    //btn_save.Text = "Save";
                    txt_jobno.Enabled = true;
                }

                btn_back.Enabled = true;
                txt_Container.Focus();
                btn_save.Text = "Update";

                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn ico-update";
                //  btn_save.Enabled = false;
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
        private void dateconvert()
        {
            try
            {
                DataAccess.ForwardingImports.JobInfo da_obj_jobinfo = new DataAccess.ForwardingImports.JobInfo();
                str_dteeta = Utility.fn_ConvertDate(dt_ETA.Text).ToString();
                str_dteetb = Utility.fn_ConvertDate(dt_ETB.Text).ToString();
                str_dtembl = Utility.fn_ConvertDate(dt_MBL.Text).ToString();
                DataTable dt_job = new DataTable();
                dt_job = da_obj_jobinfo.ShowJobDetails(Convert.ToInt32(hf_intJobno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                string str_job = Utility.fn_ConvertDate(dt_job.Rows[0][25].ToString());
                dt_jobdate.Text = Convert.ToDateTime(Utility.fn_ConvertDate(str_job)).ToString();
                string str_imdate = Utility.fn_ConvertDate(dt_job.Rows[0][29].ToString());
                dt_imdate.Text = Convert.ToDateTime(Utility.fn_ConvertDate(str_imdate)).ToString();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Collectdetails()
        {
            try
            {
                if ( ddl_jobtype.SelectedValue == "1")
                {
                    intjobtype = 1;
                    Session["JobType"] = hf_intjobtype.Value;

                }
                else if (ddl_jobtype.SelectedValue == "2")
                {
                    intjobtype = 2;
                    Session["JobType"] = intjobtype;

                }
                else if (ddl_jobtype.SelectedValue == "3")
                {
                    intjobtype = 3;
                    Session["JobType"] = intjobtype;

                }
                else if (ddl_jobtype.SelectedValue == "4")
                {
                    intjobtype = 4;
                    Session["JobType"] = intjobtype;

                }
                else if (ddl_jobtype.SelectedValue == "5")
                {
                    intjobtype = 5;
                    Session["JobType"] = intjobtype;

                }

                str_dteeta = Utility.fn_ConvertDate(dt_ETA.Text);
                str_dteetb = Utility.fn_ConvertDate(dt_ETB.Text);
                str_dtembl = Utility.fn_ConvertDate(dt_MBL.Text);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void CheckMBL()
        {
            int i;
            try
            {
                if (txt_mblno.Text.ToUpper().Trim().ToString() != "")
                {
                    DataTable dt_job = new DataTable();
                    DataAccess.Accounts.Invoice da_obj_INVobj = new DataAccess.Accounts.Invoice();
                    dt_job = da_obj_INVobj.CheckMblno((txt_mblno.Text.ToUpper().Trim()), "FI", Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    if (dt_job.Rows.Count > 0)
                    {
                        for (i = 0; i <= dt_job.Rows.Count - 1; i++)
                        {
                            if (txt_jobno.Text.ToString() != "")
                            {
                                if (dt_job.Rows[i][0].ToString() != txt_jobno.Text)
                                {
                                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('MBL # Already Exists');", true);
                                    txt_mblno.Focus();
                                    //txt_mblno.SelectAll();
                                    back = 1;
                                    return;
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('MBL # Already Exists');", true);
                                txt_mblno.Focus();
                                //txt_mblno.SelectAll();
                                back = 1;
                                return;
                            }
                        }
                    }
                    DataAccess.ForwardingImports.BLDetails da_obj_blobj = new DataAccess.ForwardingImports.BLDetails();
                    dt_job = da_obj_blobj.GetLikeOTHERIBL((txt_mblno.Text.ToUpper().Trim()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dt_job.Rows.Count > 0)
                    {
                        for (i = 0; i <= dt_job.Rows.Count - 1; i++)
                        {
                            if (dt_job.Rows[i][0].ToString() == txt_mblno.Text.ToUpper().Trim())
                            {
                                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid MBL #');", true);
                                txt_mblno.Focus();
                                back = 1;
                                return;
                            }
                        }
                    }
                    dt_job = da_obj_blobj.GetLikeFBL((txt_mblno.Text.ToUpper().Trim()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dt_job.Rows.Count > 0)
                    {
                        for (i = 0; i <= dt_job.Rows.Count - 1; i++)
                        {
                            if (dt_job.Rows[i][0].ToString() == txt_mblno.Text.ToUpper().Trim())
                            {
                                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid MBL #');", true);
                                txt_mblno.Focus();
                                back = 1;
                                return;
                            }
                        }
                    }
                    DataAccess.ForwardingExports.BLDetails objbl = new DataAccess.ForwardingExports.BLDetails();
                    DataTable dtbook = new DataTable();
                    dtbook = objbl.getsp_getbookingno(txt_mblno.Text.ToUpper(), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dtbook.Rows.Count > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('MBL# and Booking# is same');", true);
                        txt_mblno.Text = "";
                        txt_mblno.Focus();
                        back = 1;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
             btn_back.Text = "Cancel";


            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";

            DataAccess.Accounts.Invoice da_obj_VOICEobj = new DataAccess.Accounts.Invoice();
            DataAccess.ForwardingImports.BLDetails da_obj_blobj = new DataAccess.ForwardingImports.BLDetails();
            try
            {
                if (txt_jobno.Text.ToString() != "")
                {
                    if (da_obj_VOICEobj.CheckClosedJobs("FI", Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString())) == 1)
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Job has Closed Already" + "You Can not Update the Job Details');", true);
                        return;
                    }

                    if (txt_Container.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btn_add, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Enter the Container Details...');", true);
                        txt_Container.Focus();
                        return;
                    }

                    if (!string.IsNullOrEmpty(txt_Container.Text) && !string.IsNullOrEmpty(ddl_cmbSize.SelectedValue))
                    {
                        if (ddl_cmbSize.SelectedIndex == 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "JobInfo", "alertify.alert('Please Select the Base...');", true);
                            ddl_cmbSize.Focus();
                            return;
                        }
                        if (txt_Seal.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btn_add, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Enter the Seal Number...');", true);
                            txt_Seal.Focus();
                            return;
                        }
                        if (txt_Pkgs.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btn_add, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Enter the Package...');", true);
                            txt_Pkgs.Focus();
                            return;
                        }
                        if (txt_Wt.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btn_add, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Enter the Weight...');", true);
                            txt_Wt.Focus();
                            return;
                        }
                        if (txt_isocode.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btn_add, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Enter the ISO Code...');", true);
                            txt_isocode.Focus();
                            return;
                        }
                        if (txt_SocFlag.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btn_add, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Enter the Soc Flag...');", true);
                            txt_SocFlag.Focus();
                            return;
                        }

                        if (string.IsNullOrEmpty(txt_Pkgs.Text))
                        {
                            txt_Pkgs.Text = "";
                        }
                        if (string.IsNullOrEmpty(txt_Seal.Text))
                        {
                            txt_Seal.Text = "";
                        }
                        if (string.IsNullOrEmpty(txt_Wt.Text))
                        {
                            txt_Wt.Text = "";
                        }
                        if (string.IsNullOrEmpty(txt_SocFlag.Text))
                        {
                            txt_SocFlag.Text = "N";
                        }

                        if (btn_add.ToolTip == "Add")
                        {
                            DataAccess.ForwardingImports.JobInfo da_obj_jobinfo = new DataAccess.ForwardingImports.JobInfo();
                            int index;
                            foreach (GridViewRow row in grd.Rows)
                            {
                                if (row.Cells[0].Text.Trim().ToUpper().ToString() == txt_Container.Text.Trim().ToUpper().ToString())
                                {
                                    ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "JobInfo", "alertify.alert('Container Already Exists');", true);
                                    txt_Container.Focus();
                                    return;
                                }
                            }
                            /* if (grd.Rows.Count > 0)
                              {
                                  foreach (GridViewRow row in grd.Rows)
                                  {
                                      if (row.Cells[0].Text.Trim().ToUpper().ToString() == txt_Container.Text.Trim().ToUpper().ToString())
                                      {
                                          ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "JobInfo", "alertify.alert('Container Already Exists');", true);
                                          txt_Container.Focus();
                                          return;
                                      }
                                  }
                                  //index = grd.SelectedRow.RowIndex;
                                  //if (txt_Container.Text == grd.Rows[index].Cells[0].Text.ToString())
                                  //{
                                  //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Container Already Exists');", true);
                                  //    txt_Container.Focus();
                                  //    return;
                                  //}
                              }*/


                            da_obj_jobinfo.InsertJobCont(Convert.ToInt32(txt_jobno.Text), (txt_jobno.Text), (txt_Container.Text.ToUpper()), (ddl_cmbSize.SelectedValue), (txt_Seal.Text.ToUpper()), Convert.ToInt32(txt_Pkgs.Text), Convert.ToDouble(txt_Wt.Text), Convert.ToString(txt_isocode.Text.ToUpper()), Convert.ToString(txt_SocFlag.Text.ToUpper()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            da_obj_jobinfo.UpdContDetails(Convert.ToInt32(txt_jobno.Text), Convert.ToString(txt_jobno.Text), Convert.ToString(txt_Container.Text.ToUpper()), Convert.ToString(ddl_cmbSize.SelectedValue), Convert.ToString(txt_Seal.Text.ToUpper()), Convert.ToString(hf_oldcont.Value), Convert.ToInt32(txt_Pkgs.Text), Convert.ToDouble(txt_Wt.Text), Convert.ToString(txt_isocode.Text.ToUpper()), Convert.ToString(txt_SocFlag.Text.ToUpper()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 3, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Ins Job#-" + txt_jobno.Text + "  /  " + txt_Container.Text);
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Container Saved');", true);
                            txtContainerDtsClear();
                            DataTable dt_job = new DataTable();
                            dt_job = da_obj_blobj.GetContainerDetail(Convert.ToInt32(txt_jobno.Text), Convert.ToString(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            Session["Container"] = dt_job;
                            grd.DataSource = dt_job;
                            grd.DataBind();
                        }
                        else
                        {
                            DataTable dt_job = new DataTable();
                            DataAccess.ForwardingImports.JobInfo da_obj_jobinfo = new DataAccess.ForwardingImports.JobInfo();
                            da_obj_jobinfo.UpdContDetails(Convert.ToInt32(txt_jobno.Text), Convert.ToString(txt_jobno.Text), Convert.ToString(txt_Container.Text.ToUpper()), Convert.ToString(ddl_cmbSize.SelectedValue), Convert.ToString(txt_Seal.Text.ToUpper()), Convert.ToString(hf_oldcont.Value), Convert.ToInt32(txt_Pkgs.Text), Convert.ToDouble(txt_Wt.Text), Convert.ToString(txt_isocode.Text.ToUpper()), Convert.ToString(txt_SocFlag.Text.ToUpper()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 3, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Upd Job#-" + txt_jobno.Text + "  /  " + txt_Container.Text);
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Container Updated');", true);
                            txtContainerDtsClear();
                            dt_job = blobj.GetContainerDetail(Convert.ToInt32(txt_jobno.Text), Convert.ToString(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            Session["Container"] = dt_job;
                            grd.DataSource = dt_job;
                            grd.DataBind();
                        }
                        txt_Container.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        public void txtContainerDtsClear()
        {
            txt_Container.Enabled = true;
            txt_Container.Text = "";
            txt_Seal.Text = "";
            txt_Pkgs.Text = "";
            txt_Wt.Text = "";
            txt_isocode.Text = "";
            txt_SocFlag.Text = "";
            // btn_add.Text = "Add";
            btn_add.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn ico-add";
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                btn_back.Text = "Cancel";


                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                string sf = null;
                string blno = null;
                string SP = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                blno = txt_jobno.Text;
                if (btn_view.ToolTip == "View")
                {
                    if (string.IsNullOrEmpty(txt_jobno.Text))
                    {
                        str_RptName = "FIJobInfo.rpt";
                        str_sf = "{FIJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                        Session["str_sfs"] = "{FIJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_SP + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Shipment Details", str_Script, true);
                        da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 3, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), "FI-JobRegVew");
                    }
                    else
                    {
                        str_frmname = "FI JobDetails";
                        str_RptName = "FIExportsDetails.rpt";
                        Session["str_sfs"] = "{FIJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {FIJobInfo.jobno}=" + Convert.ToString(txt_jobno.Text);
                        str_sf = "{FIJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {FIJobInfo.jobno}=" + Convert.ToString(txt_jobno.Text);
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_SP + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";


                        //  str_Script = "window.open('../Reportasp/FIExportsDetailsrpt.aspx?jobno=" + txt_jobno.Text + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Shipment Details", str_Script, true);
                        da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 3, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(txt_jobno.Text) + "FI-JobVew");
                    }

                }
                else
                {
                    DataAccess.Corporate da_obj_CorpObj = new DataAccess.Corporate();
                    DataAccess.ForwardingImports.JobInfo da_obj_jobinfo = new DataAccess.ForwardingImports.JobInfo();

                    if (txt_vessel.Text.ToString() != "" || txt_Agent.Text.ToString() != "")
                    {
                        da_obj_jobinfo.UpdateJobDeStuff(Convert.ToInt32(txt_jobno.Text), Convert.ToDateTime(dt_destuff.Text), Convert.ToString(txt_Godown.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        da_obj_CorpObj.UpdateShipmentStatus("", "FI", Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), "De Stuffed at CFS");
                        da_obj_jobinfo.UpdateFIEventdestuffedon(Convert.ToInt32(txt_jobno.Text), da_obj_Logobj.GetDate(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated');", true);
                        //txtclear();
                    }
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void txtclear()
        {

            txt_jobno.Text = "";
            txt_vessel.Text = "";
            txt_voyage.Text = "";
            txt_imno.Text = "";
            txt_pol.Text = "";
            txt_pod.Text = "";
            txt_Agent.Text = "";
            txt_mblno.Text = "";
            txt_MLO.Text = "";
            txt_CArrport.Text = "";
            txt_CPort1.Text = "";
            txt_CPort2.Text = "";
            txt_CLastport.Text = "";
            txt_CMaster.Text = "";
            txt_CVslCode.Text = "";
            txt_CLineCode.Text = "";
            txt_CAgent.Text = "";
            txt_CNation.Text = "";
            txt_CMaster.Text = "";
            txt_CGRT.Text = "";
            txt_CNRT.Text = "";
            txt_CVsltype.Text = "";
            txt_CTotal.Text = "";
            //rdoConsol.Checked = false;
            //rdoCoload.Checked = false;
            //rdoFCL.Checked = false;
            //rdoMCC.Checked = false;
            //rdoBuyerConsol.Checked = false;
            ddl_jobtype.SelectedValue = "0";
            CHk_DropFI.Checked = false;
            txt_cfs.Text = "";
            txt_cfscode.Text = "";
            dt_jobdate.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());
            dt_imdate.Text = Utility.fn_ConvertDate(dt_jobdate.Text);
            dt_jobdate.Text = Utility.fn_ConvertDate(dt_imdate.Text);
            dt_imdate.Text = dt_jobdate.Text;

            dt_ETA.Text = Utility.fn_ConvertDate(dt_jobdate.Text);
            dt_jobdate.Text = Utility.fn_ConvertDate(dt_ETA.Text);
            dt_ETA.Text = dt_jobdate.Text;

            dt_ETB.Text = Utility.fn_ConvertDate(dt_jobdate.Text);

            dt_jobdate.Text = Utility.fn_ConvertDate(dt_ETB.Text);
            dt_ETB.Text = dt_jobdate.Text;

            dt_MBL.Text = Utility.fn_ConvertDate(dt_jobdate.Text);
            dt_jobdate.Text = Utility.fn_ConvertDate(dt_MBL.Text);
            dt_MBL.Text = dt_jobdate.Text;


            dt_destuff.Text = Utility.fn_ConvertDate(dt_jobdate.Text);
            txt_mblno.Enabled = false;
            txt_Godown.Text = "";
            txt_callsign.Text = "";
            // btn_add.Text = "Add";
            btn_add.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn ico-add";
            txt_ContainerDtsClear();
            txt_Bond.Text = "";
            txt_MMT.Text = "";
            txt_remarks.Text = "";
            txt_ImoCode.Text = "";
            txt_Agent.Enabled = true;
            txtCarrier.Text = "";

        }
        public void txt_ContainerDtsClear()
        {
            txt_Container.Enabled = true;
            txt_Container.Text = "";
            ddl_cmbSize.SelectedIndex = 0;
            txt_Seal.Text = "";
            txt_Pkgs.Text = "";
            txt_Wt.Text = "";
            txt_isocode.Text = "";
            txt_SocFlag.Text = "";
            // btn_add.Text = "Add";
            btn_add.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn ico-add";
        }

        private void txtEnable()
        {
            txt_jobno.Enabled = true;
            txt_vessel.Enabled = true;
            txt_voyage.Enabled = true;
            txt_imno.Enabled = true;
            txt_pol.Enabled = true;
            txt_pod.Enabled = true;
            txt_Agent.Enabled = true;
            txt_mblno.Enabled = true;
            txt_MLO.Enabled = true;
            txt_CArrport.Enabled = true;
            txt_CPort1.Enabled = true;
            txt_CPort2.Enabled = true;
            txt_CLastport.Enabled = true;
            txt_CMaster.Enabled = true;
            txt_CVslCode.Enabled = true;
            txt_CLineCode.Enabled = true;
            txt_CAgent.Enabled = true;
            txt_CNation.Enabled = true;
            txt_CMaster.Enabled = true;
            txt_CGRT.Enabled = true;
            txt_CNRT.Enabled = true;
            txt_CVsltype.Enabled = true;
            txt_remarks.Enabled = true;
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


                        Response.Redirect("../FI/FIBL.aspx");


                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                    }

                 
            }
            if (btn_back.ToolTip == "Cancel")
            {
                txtclear();
                txtEnable();
                txt_DocRecdon.Text = "";
                 btn_save.Text = "Save";
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                btn_back.Enabled = true;
                 btn_back.Text = "Back";


                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";

                btn_save.Enabled = true;


                grd_Jobno.Visible = false;
                grd.DataSource = new DataTable();
                grd.DataBind();
                Grid_blno.DataSource = null;
                Grid_blno.DataBind();
                BindBooking();

                arrportflag.ImageUrl = "";
                lastportflag.ImageUrl = "";
                cport1flag.ImageUrl = "";
                cport2flag.ImageUrl = "";
                flagimg.ImageUrl = "";
                podflag.ImageUrl = "";
            }
            else
            {
                //this.Response.End();


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
            UserRights();
        }

        public void SendDeleiveryStatus()
        {

            // string str_mailserver = Session["MailServer"].ToString();
            string str_usermailid = Session["usermailid"].ToString();
            //string str_mailuser = Session["MailUser"].ToString();
            string str_mailpwd = Session["usermailpwd"].ToString();

            DataAccess.ForwardingImports.BLDetails da_obj_blobj = new DataAccess.ForwardingImports.BLDetails();
            string sendqry = "";
            DataTable Dt = new DataTable();
            sendqry = sendqry + "<body text=darkblue><table width=100%><FONT FACE=tahoma ><tr><td align=left>New Job # : " + Convert.ToInt32(hf_intJobno.Value) + "  has created in Ocean Imports. Please find below details</td></tr></table><br>";
            sendqry = sendqry + "<table><tr><td align=left>Job # : " + Convert.ToInt32(hf_intJobno.Value) + "   </td><td align=left>Vessel Vs Voyage : " + Convert.ToString(txt_vessel.Text) + " Vs " + Convert.ToString(txt_voyage.Text) + "   " + "     </td><td align=left colspan=2>MBL # : " + Convert.ToString(txt_mblno.Text) + "</td></tr><br>";
            sendqry = sendqry + "<tr><td align=left>PoL : " + Convert.ToString(txt_pol.Text) + "   " + "   </td><td align=left>ETD : " + Convert.ToDateTime(Utility.fn_ConvertDatetime(dt_ETB.Text)) + "   </td><td align=left>PoD : " + Convert.ToString(txt_pod.Text) + "   " + "   </td><td align=left>ETA : " + Convert.ToDateTime(Utility.fn_ConvertDatetime(dt_ETA.Text)) + "</td></tr><br>";
            sendqry = sendqry + "<tr><td align=left colspan=4>Agent : " + Convert.ToString(txt_Agent.Text) + "   </td></tr><br>";
            sendqry = sendqry + "<tr><td align=left colspan=4>Carrier / Forwarder # : " + Convert.ToString(txt_MLO.Text) + "</td></tr></table>";

            sendqry = sendqry + "<table BORDER=2 BORDERCOLOR=#336699 CELLPADDING=2 CELLSPACING=0 WIDTH=100% text=black><tr><td align=center>Container # </td><td align=center>Sizetype</td><td align=center>Seal #</td><td align=center>Pkgs</td><td align=center>Weight</td></tr><br>";
            Dt = da_obj_blobj.GetContainerDetail(Convert.ToInt32(hf_intJobno.Value), Convert.ToString(hf_intJobno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            int i;
            if (Dt.Rows.Count > 0)
            {
                for (i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    sendqry = sendqry + "<tr><td align=left>" + Dt.Rows[i][0].ToString() + "</td><td align=left>" + Dt.Rows[i][1].ToString() + "</td><td align=left>" + Dt.Rows[i][2].ToString() + "</td><td align=left>" + Dt.Rows[i][3].ToString() + "</td><td align=left>" + Dt.Rows[i][4].ToString() + "</td></tr>";
                }
            }
            sendqry = sendqry + "</table>";
            DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();
            sendqry = sendqry + "</table><table width=100% text=darkblue><tr><td align=left>Best Regards </td></tr></table><br><br><br>";
            sendqry = sendqry + "<table width=100% text=black><tr><td align=left>" + employeeobj.GetEmployeeName(employeeobj.GetEmpid(Session["LoginUserName"].ToString())) + " </td></tr></table></body></html>";

            string usermail = null;
            string empmailadd = "";
            DataAccess.HR.Employee da_obj_hrempobj = new DataAccess.HR.Employee();
            DataAccess.UserPermission da_obj_userperobj = new DataAccess.UserPermission();
            usermail = da_obj_hrempobj.GetMailAdd(da_obj_hrempobj.GetEmpId(Session["LoginUserName"].ToString()));
            Dt = da_obj_userperobj.GetMLEmpid(da_obj_userperobj.GetMLUiid("FI", "Job Info"), Convert.ToInt32(Session["LoginBranchid"].ToString()));
            for (i = 0; i <= Dt.Rows.Count - 1; i++)
            {
                empmailadd = empmailadd + da_obj_hrempobj.GetMailAdd(Convert.ToInt32(Dt.Rows[i][0].ToString())) + ";";
            }
            if (!string.IsNullOrEmpty(empmailadd))
            {
                //int emp = Convert.ToInt32(empmailadd.Length.ToString());
                empmailadd = empmailadd.Substring(0, Convert.ToInt32(empmailadd.Length.ToString()) - 1);
                Utility.SendMail(usermail, empmailadd, "New Job # : " + Convert.ToString(txt_jobno.Text) + "  has created in Ocean Imports", sendqry, "", Session["usermailpwd"].ToString(), "", usermail);
                //sendmail.SendEmail(empmailadd, usermail, "pandi", "New Job # : " + Convert.ToString(txt_jobno.Text) + "  has been created in Ocean Imports", sendqry, true, str_mailserver, str_usermailid, "", str_mailuser, str_mailpwd, "");
            }

        }

        protected void grd_Jobno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (grd_Jobno.Rows.Count > 0)
                {
                    //ImageButton btnsubmit = sender as ImageButton;
                    //GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
                    int int_index;
                    int_index = Convert.ToInt32(grd_Jobno.SelectedRow.RowIndex);
                    hf_intjob.Value = grd_Jobno.Rows[int_index].Cells[0].Text.ToString();
                    txt_jobno.Text = hf_intjob.Value;
                    JobDetails();
                    getblno();
                }
                grd_Jobno.Visible = false;
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void getblno()
        {

            DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
            DataAccess.ForwardingImports.BLDetails da_obj_blobj = new DataAccess.ForwardingImports.BLDetails();
            DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();
            DataTable dt_new = new DataTable();
            if (grd_Jobno.Rows.Count > 0)
            {
                int index = grd_Jobno.SelectedRow.RowIndex;
                int jobno = Convert.ToInt32(grd_Jobno.Rows[index].Cells[0].Text);
                if (jobno.ToString() != "")
                {

                    dt_new = da_obj_blobj.ShowFIInfonew(Convert.ToInt32(jobno), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    if (dt_new.Rows.Count > 0)
                    {
                        if (string.IsNullOrEmpty(dt_new.Rows[0]["splitbl"].ToString()) == true)
                        {
                            hid_splitbl.Value = "";
                        }
                        else
                        {
                            hid_splitbl.Value = dt_new.Rows[0]["splitbl"].ToString();
                        }
                        if (Grid_blno.Rows.Count > 0)
                        {
                            Grid_blno.DataSource = null;
                            Grid_blno.DataBind();
                        }
                        else
                        {
                            Grid_blno.DataSource = dt_new;
                            Grid_blno.DataBind();
                        }
                        //Grid_blno.DataSource = dt_new;
                        //Grid_blno.DataBind();

                        if (Grid_blno.Rows.Count > 0)
                        {
                            Grid_blno.HeaderRow.Cells[0].Text = "Job #";
                            Grid_blno.HeaderRow.Cells[1].Text = "BL #";
                            Grid_blno.HeaderRow.Cells[2].Text = "Shipper";
                            Grid_blno.HeaderRow.Cells[3].Text = "Consignee";
                            Grid_blno.HeaderRow.Cells[4].Text = "20";
                            Grid_blno.HeaderRow.Cells[5].Text = "40";
                            Grid_blno.HeaderRow.Cells[6].Text = "CBM";
                            Grid_blno.HeaderRow.Cells[7].Text = "Gr.Wt.";
                            Grid_blno.HeaderRow.Cells[8].Text = "NoOfPkgs";

                            Grid_blno.HeaderRow.Cells[9].Text = "Pkgs";
                            Grid_blno.HeaderRow.Cells[10].Text = "Pol";
                            Grid_blno.HeaderRow.Cells[11].Text = "FD";
                            Grid_blno.HeaderRow.Cells[12].Text = "Splitbl#";
                        }
                        //else
                        //{
                        //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('No Data Found');", true);

                        //}

                    }

                }
            }
        }

        public void txtdisable()
        {
            txt_jobno.Enabled = false;
            txt_vessel.Enabled = false;
            txt_voyage.Enabled = false;
            txt_imno.Enabled = false;
            txt_pol.Enabled = false;
            txt_pod.Enabled = false;
            txt_Agent.Enabled = false;
            txt_mblno.Enabled = false;
            txt_MLO.Enabled = false;
            txt_CArrport.Enabled = false;
            txt_CPort1.Enabled = false;
            txt_CPort2.Enabled = false;
            txt_CLastport.Enabled = false;
            txt_CMaster.Enabled = false;
            txt_CVslCode.Enabled = false;
            txt_CLineCode.Enabled = false;
            txt_CAgent.Enabled = false;
            txt_CNation.Enabled = false;
            txt_CMaster.Enabled = false;
            txt_CGRT.Enabled = false;
            txt_CNRT.Enabled = false;
            txt_CVsltype.Enabled = false;
            txt_CTotal.Enabled = false;
            dt_ETA.Enabled = false;
            dt_ETB.Enabled = false;
            dt_MBL.Enabled = false;
            dt_jobdate.Enabled = false;
            //rdoConsol.Enabled = false;
            //rdoCoload.Enabled = false;
            //rdoFCL.Enabled = false;
            //rdoMCC.Enabled = false;
            //rdoBuyerConsol.Enabled = false;
            ddl_jobtype.SelectedValue = "0";
            txt_cfs.Enabled = false;
            txt_cfscode.Enabled = false;
            dt_imdate.Enabled = false;
            txt_remarks.Enabled = false;
            grd.Enabled = false;
        }
        public void Contfill()
        {
            try
            {
                DataAccess.Masters.MasterContainer da_obj_conttypeobj = new DataAccess.Masters.MasterContainer();
                DataTable dt_job = new DataTable();
                dt_job = da_obj_conttypeobj.GetContainersizes();
                if (dt_job.Rows.Count > 0)
                {
                    ddl_cmbSize.Items.Add("");
                    for (int i = 0; i <= dt_job.Rows.Count - 1; i++)
                    {
                        ddl_cmbSize.Items.Add(dt_job.Rows[i]["conttype"].ToString());
                        ddl_cmbSize.DataBind();
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
            try
            {

                DataAccess.ForwardingImports.BLDetails da_obj_blobj = new DataAccess.ForwardingImports.BLDetails();
                DataTable dt_new = new DataTable();

                if (grd.Rows.Count > 0)
                {

                    int int_index = grd.SelectedRow.RowIndex;
                    Session["index"] = int_index;
                    hf_intjob.Value = grd.Rows[int_index].Cells[0].Text.ToString();
                    DataAccess.ForwardingImports.JobInfo da_obj_jobinfo = new DataAccess.ForwardingImports.JobInfo();


                    int_index = Convert.ToInt32(Session["index"].ToString());
                    hf_oldcont.Value = grd.Rows[int_index].Cells[0].Text.ToString();
                    txt_Container.Text = grd.Rows[int_index].Cells[0].Text.ToString();
                    ddl_cmbSize.SelectedValue = grd.Rows[int_index].Cells[1].Text.ToString();
                    txt_Seal.Text = grd.Rows[int_index].Cells[2].Text.ToString();
                    if (string.IsNullOrEmpty(grd.Rows[int_index].Cells[3].Text.ToString()) == true)
                    {
                        txt_Pkgs.Text = "";
                    }
                    else
                    {
                        txt_Pkgs.Text = grd.Rows[int_index].Cells[3].Text.ToString();
                    }
                    if (string.IsNullOrEmpty(grd.Rows[int_index].Cells[4].Text.ToString()) == true)
                    {
                        txt_Wt.Text = "";
                    }
                    else
                    {
                        txt_Wt.Text = grd.Rows[int_index].Cells[4].Text.ToString();
                    }
                    if (string.IsNullOrEmpty(grd.Rows[int_index].Cells[5].Text.ToString()) == true)
                    {
                        txt_isocode.Text = " ";
                    }
                    else
                    {
                        txt_isocode.Text = Server.HtmlDecode(grd.Rows[int_index].Cells[5].Text.ToString());
                    }
                    txt_SocFlag.Text = grd.Rows[int_index].Cells[6].Text.ToString();
                    if (txt_jobno.Text != "")
                    {
                        dt_new = da_obj_blobj.ShowFIInfonew(Convert.ToInt32(txt_jobno.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    }
                    if (dt_new.Rows.Count > 0)
                    {
                        txt_Container.Enabled = false;
                    }
                    else
                    {
                        txt_Container.Enabled = true;
                    }
                    //btn_add.Text = "Update";


                    btn_add.ToolTip = "Update";
                    btn_add1.Attributes["class"] = "btn ico-update";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_yes1_Click1(object sender, EventArgs e)
        {

        }

        protected void grd_Jobno_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_Jobno.PageIndex = e.NewPageIndex;
            //grd_Jobno.DataSource = dt_job;
            //grd_Jobno.DataBind();
            loadpagegrid();
        }

        protected void grd_Jobno_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCustomer1 = (Label)e.Row.FindControl("JobType");
                string tooltip1 = lblCustomer1.Text;
                e.Row.Cells[1].Attributes.Add("title", tooltip1);
                Label lblCustomer2 = (Label)e.Row.FindControl("vesselname");
                string tooltip2 = lblCustomer2.Text;
                e.Row.Cells[2].Attributes.Add("title", tooltip2);
                Label lblCustomer3 = (Label)e.Row.FindControl("voyage");
                string tooltip3 = lblCustomer3.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip3);
                Label lblCustomer4 = (Label)e.Row.FindControl("mblno");
                string tooltip4 = lblCustomer4.Text;
                e.Row.Cells[4].Attributes.Add("title", tooltip4);
                //Label lblCustomer5 = (Label)e.Row.FindControl("voyage");
                //string tooltip5 = lblCustomer5.Text;
                //e.Row.Cells[5].Attributes.Add("title", tooltip5);
                Label lblCustomer6 = (Label)e.Row.FindControl("eta");
                string tooltip6 = lblCustomer6.Text;
                e.Row.Cells[5].Attributes.Add("title", tooltip6);
                Label lblCustomer7 = (Label)e.Row.FindControl("etd");
                string tooltip7 = lblCustomer7.Text;
                e.Row.Cells[6].Attributes.Add("title", tooltip7);
                Label lblCustomer8 = (Label)e.Row.FindControl("POL");
                string tooltip8 = lblCustomer8.Text;
                e.Row.Cells[7].Attributes.Add("title", tooltip8);
                Label lblCustomer9 = (Label)e.Row.FindControl("agent");
                string tooltip9 = lblCustomer9.Text;
                e.Row.Cells[8].Attributes.Add("title", tooltip9);
                Label lblCustomer10 = (Label)e.Row.FindControl("mlo");
                string tooltip10 = lblCustomer10.Text;
                e.Row.Cells[9].Attributes.Add("title", tooltip10);
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_Jobno, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        //protected void id_img_Click(object sender, ImageClickEventArgs e)
        //{
        //    try { 
        //    if (grd_Jobno.Rows.Count > 0)
        //    {
        //        ImageButton btnsubmit = sender as ImageButton;
        //        GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
        //        int int_index;
        //        int_index = gRow.RowIndex;
        //        hf_intjob.Value = grd_Jobno.Rows[int_index].Cells[0].Text.ToString();
        //        txt_jobno.Text = hf_intjob.Value;
        //        JobDetails();
        //    }
        //    grd_Jobno.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}

        protected void img_click_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void btnupdateBook_Click(object sender, EventArgs e)
        {

        }

        private void getbookingassigned()
        {
            //branchid = Convert.ToInt32(Session["LoginBranchid"]);
            //int bookno;
            //dtbk = book.SELBookingDtlsByJob("FI", branchid, Convert.ToInt32(txt_jobno.Text));
            //if (dtbk.Rows.Count > 0)
            //{
            //    grdBookJob.DataSource = dtbk;
            //    grdBookJob.DataBind();
            //}
            //int grdbookno;
            //if (dtbk.Rows.Count > 0)
            //{
            //    for (int i = 0; i <= dtbk.Rows.Count - 1; i++)
            //    {
            //        if (grdBookJob.Rows.Count > 0)
            //        {
            //            bookno = Convert.ToInt32(dtbk.Rows[i]["bookingno"].ToString());
            //            for (int j = 0; j <= grdBookJob.Rows.Count - 1; j++)
            //            {
            //                CheckBox chkRow = (grdBookJob.Rows[j].Cells[3].FindControl("ChkMail") as CheckBox);
            //                grdbookno = Convert.ToInt32(grdBookJob.Rows[j].Cells[0].Text);
            //                if (bookno == grdbookno)
            //                {
            //                    chkRow.Checked = true;
            //                }
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    for (int j = 0; j <= grdBookJob.Rows.Count - 1; j++)
            //    {
            //        CheckBox chkRow = (grdBookJob.Rows[j].Cells[3].FindControl("ChkMail") as CheckBox);
            //        chkRow.Checked = false;
            //    }
            //}
            branchid = Convert.ToInt32(Session["LoginBranchid"]);

            DataTable dtbk1;

            dtbk1 = book.SELBookingDtlsByJobnew("FI", branchid, Convert.ToInt32(txt_jobno.Text));
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
            if (txt_jobno.Text != "")
            {
                branchid = Convert.ToInt32(Session["LoginBranchid"]);

                dtbk = book.SELBookingDtlsByJob("FI", branchid, Convert.ToInt32(txt_jobno.Text));


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
        private void BindBooking()
        {

            //Session["shiprefno"] = null;

            if (txt_jobno.Text != "")
            {
                dtbk = book.SELBookingDtlsByJob("FI", branchid, Convert.ToInt32(txt_jobno.Text));


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
                //   dtbk = book.GETBookingNoJobInfo(branchid, "FI");
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

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    ImageButton Img_delete = (ImageButton)e.CommandSource;
                    GridViewRow gvRow = (GridViewRow)Img_delete.NamingContainer;
                    DataTable obj_dt = new DataTable();
                    obj_dt = (DataTable)Session["Container"];
                     btn_back.Text = "Cancel";


                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";

                    DataAccess.ForwardingImports.JobInfo da_obj_jobinfo = new DataAccess.ForwardingImports.JobInfo();
                    if (da_obj_jobinfo.CheckContainerNo(int.Parse(txt_jobno.Text), obj_dt.Rows[gvRow.RowIndex]["containerno"].ToString(), "FI", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString())) != 0)
                    {
                        ScriptManager.RegisterStartupScript(Img_delete, typeof(Button), "DataFound", "alertify.alert('Container Already Assigned to BL');", true);
                        btndelete = false;
                        //btn_add.Text = "Update";
                        return;
                    }
                    da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 3, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Del Job#-" + txt_jobno.Text + "  /  " + obj_dt.Rows[gvRow.RowIndex]["containerno"].ToString());

                    da_obj_jobinfo.DeleteContainerdtls(int.Parse(txt_jobno.Text), obj_dt.Rows[gvRow.RowIndex]["containerno"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));


                    ScriptManager.RegisterStartupScript(Img_delete, typeof(Button), "DataFound", "alertify.alert('Container Deleted');", true);
                    obj_dt.Rows[gvRow.RowIndex].Delete();
                    obj_dt.AcceptChanges();

                    grd.DataSource = obj_dt;
                    grd.DataBind();
                    Session["Container"] = obj_dt;
                    //grd.DataSource = dt_job;
                    //grd.DataBind();
                    //JobDetails();

                    //txtContainerDtsClear();
                    //return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void txt_vessel_TextChanged(object sender, EventArgs e)
        {


            try
            {
                int vesse1id = da_obj_vesselobj.GetVesselid(txt_vessel.Text.Trim().ToUpper());

                if (vesse1id != 0)
                {
                    CheckVesselName(txt_vessel);
                }
                else
                {
                    txt_vessel.Text = "";
                    txt_vessel.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Vessel ( Feeder Vessel / Direct )');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_voyage_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_pod_TextChanged(object sender, EventArgs e)
        {


            try
            {

                if (da_obj_Port.GetNPortid(txt_pod.Text.Trim().ToUpper()) != 0 && hf_podid.Value != "0")
                {
                    DataTable dtflag;
                    DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                    dtflag = obj_MasterPort.SelPortName4typepadimg(txt_pod.Text.ToUpper(), Session["StrTranType"].ToString());
                    podflag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Discharge Port');", true);
                    txt_pod.Text = "";
                    txt_pod.Focus();
                    blrr = true;
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
            DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();

            try
            {

                if (da_obj_Port.GetNPortid(txt_pol.Text.Trim().ToUpper()) != 0 && hf_porid.Value != "0")
                {
                    DataTable dtflag;
                    DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                    dtflag = obj_MasterPort.SelPortName4typepadimg(txt_pol.Text.ToUpper(), Session["StrTranType"].ToString());
                    flagimg.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Load Port');", true);
                    txt_pol.Text = "";
                    txt_pol.Focus();
                    blrr = true;
                    return;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_MLO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                // obj_dt = da_obj_Customer.GetCustomerid(txt_MLO.Text.Trim().ToUpper());

                //int mloid = da_obj_Customer.GetCustomerid((txt_MLO.Text.Trim().ToUpper()));
                //if (mloid != 0)
                obj_dt = da_obj_Customer.GetexactCustomer(txt_MLO.Text.ToUpper(), "L");
                if (obj_dt.Rows.Count > 0 && hf_intMLOid.Value != "0")
                {

                }
                else
                {
                    txt_MLO.Text = "";
                    txt_MLO.Focus();
                    blrr = true;
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid MLO');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_Agent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();

                if (da_obj_Customer.GetCustomerid(txt_Agent.Text.Trim().ToUpper()) != 0 && hf_intAgentid.Value != "0")
                {

                }
                else
                {
                    txt_Agent.Text = "";
                    txt_Agent.Focus();
                    blrr = true;
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Agent');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_cfs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();

                DataTable obj_dt = new DataTable();
                //if (da_obj_Customer.GetCustomerid(txt_cfs.Text.Trim().ToUpper()) != 0)

                obj_dt = da_obj_Customer.GetexactCustomer(txt_cfs.Text.Trim().ToUpper(), "L");
                if (obj_dt.Rows.Count > 0 && hf_intCFSid.Value != "0")
                {
                    txt_ImoCode.Focus();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid C F S');", true);
                    txt_cfs.Text = "";
                    txt_cfs.Focus();
                    blrr = true;
                    return;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtCarrier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] carriertxt = txtCarrier.Text.Split(',');
                DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
                DataTable dt = new DataTable();
                dt = da_obj_customerobj.GetExactCustomer4Carrier(txtCarrier.Text.Trim());

                if (dt.Rows.Count > 0 && hdnCarrier.Value != "0")
                {
                    txt_cfs.Focus();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Carrier');", true);
                    txtCarrier.Text = "";
                    txtCarrier.Focus();
                    blrr = true;
                    return;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void CHk_DropFI_CheckedChanged(object sender, EventArgs e)
        {
            if (CHk_DropFI.Checked == false)
            {
                str_status = "O";
            }
            else if (CHk_DropFI.Checked == true)
            {
                str_status = "P";
            }
            else
            {
                str_status = "";
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

        protected void Proinvoic_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1013, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_mblno.Text != "")
                    {
                        string mblno = txt_mblno.Text;
                        //Response.Redirect("../ForwardExports/CostingDetails.aspx");
                        string app1 = "1";
                        Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app1 + "&mblno=" + mblno);
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
            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1020, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");
                    if (txt_mblno.Text != "")
                    {
                        string mblno = txt_mblno.Text;
                        string app1 = "1";
                        Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app1 + "&mblno=" + mblno);
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

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1027, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string app1 = "1";
                    Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app1);


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

                    string app1 = "1";
                    Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app1);


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

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1014, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_mblno.Text != "")
                    {
                        string mblno = txt_mblno.Text;
                        string app2 = "2";
                        //Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app2);
                        Response.Redirect("../Accounts/ProformaLV.aspx?app2=" + app2 + "&mblno=" + mblno);
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


            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1021, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_mblno.Text != "")
                    {
                        string mblno = txt_mblno.Text;
                        string app2 = "2";
                        Response.Redirect("../Accounts/ProformaLV.aspx?app2=" + app2 + "&mblno=" + mblno);
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

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1028, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    string app2 = "2";
                    Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app2);

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

                    string app2 = "2";
                    Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app2);



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

        protected void btnreuse_Click(object sender, EventArgs e)
        {
            loadpagegridReuse();
            UserRights();
        }

        protected void Grd_reuse_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_reuse.PageIndex = e.NewPageIndex;
            loadpagegridReuse();
        }

        protected void Grd_reuse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Grd_reuse.Rows.Count > 0)
                {

                    int int_index;
                    int_index = Convert.ToInt32(Grd_reuse.SelectedRow.RowIndex);
                    hf_intjob.Value = Grd_reuse.Rows[int_index].Cells[0].Text.ToString();
                    txt_jobno.Text = hf_intjob.Value;
                    JobDetailsReuse();
                    getblno();
                }
                Grd_reuse.Visible = false;
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_reuse_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCustomer1 = (Label)e.Row.FindControl("JobType");
                string tooltip1 = lblCustomer1.Text;
                e.Row.Cells[1].Attributes.Add("title", tooltip1);
                Label lblCustomer2 = (Label)e.Row.FindControl("vesselname");
                string tooltip2 = lblCustomer2.Text;
                e.Row.Cells[2].Attributes.Add("title", tooltip2);
                Label lblCustomer3 = (Label)e.Row.FindControl("voyage");
                string tooltip3 = lblCustomer3.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip3);
                Label lblCustomer4 = (Label)e.Row.FindControl("mblno");
                string tooltip4 = lblCustomer4.Text;
                e.Row.Cells[4].Attributes.Add("title", tooltip4);
                //Label lblCustomer5 = (Label)e.Row.FindControl("voyage");
                //string tooltip5 = lblCustomer5.Text;
                //e.Row.Cells[5].Attributes.Add("title", tooltip5);
                Label lblCustomer6 = (Label)e.Row.FindControl("eta");
                string tooltip6 = lblCustomer6.Text;
                e.Row.Cells[5].Attributes.Add("title", tooltip6);
                Label lblCustomer7 = (Label)e.Row.FindControl("etd");
                string tooltip7 = lblCustomer7.Text;
                e.Row.Cells[6].Attributes.Add("title", tooltip7);
                Label lblCustomer8 = (Label)e.Row.FindControl("POL");
                string tooltip8 = lblCustomer8.Text;
                e.Row.Cells[7].Attributes.Add("title", tooltip8);
                Label lblCustomer9 = (Label)e.Row.FindControl("agent");
                string tooltip9 = lblCustomer9.Text;
                e.Row.Cells[8].Attributes.Add("title", tooltip9);
                Label lblCustomer10 = (Label)e.Row.FindControl("mlo");
                string tooltip10 = lblCustomer10.Text;
                e.Row.Cells[9].Attributes.Add("title", tooltip10);
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_reuse, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Proosdncn_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1022, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_jobno.Text != "")
                    {
                        string jobno = txt_jobno.Text;
                        string appFI3 = "OSSI";
                        //Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app2);
                        Response.Redirect("../Accounts/ProOSV.aspx?appFI3=" + appFI3 + "&jobno=" + jobno);
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

        public void getbldetails()
        {

            DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
            DataAccess.ForwardingImports.BLDetails da_obj_blobj = new DataAccess.ForwardingImports.BLDetails();
            DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();
            DataTable dt_new = new DataTable();

            if (txt_jobno.Text.ToString() != "")
            {

                dt_new = da_obj_blobj.ShowFIInfonew(Convert.ToInt32(txt_jobno.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (dt_new.Rows.Count > 0)
                {
                    if (string.IsNullOrEmpty(dt_new.Rows[0]["splitbl"].ToString()) == true)
                    {
                        hid_splitbl.Value = "";
                    }
                    else
                    {
                        hid_splitbl.Value = dt_new.Rows[0]["splitbl"].ToString();
                    }

                    if (Grid_blno.Rows.Count > 0)
                    {
                        Grid_blno.DataSource = null;
                        Grid_blno.DataBind();
                    }
                    else
                    {
                        Grid_blno.DataSource = dt_new;
                        Grid_blno.DataBind();
                    }
                    //Grid_blno.DataSource = dt_new;
                    //Grid_blno.DataBind();

                    if (Grid_blno.Rows.Count > 0)
                    {
                        Grid_blno.HeaderRow.Cells[0].Text = "Job #";
                        Grid_blno.HeaderRow.Cells[1].Text = "BL #";
                        Grid_blno.HeaderRow.Cells[2].Text = "Shipper";
                        Grid_blno.HeaderRow.Cells[3].Text = "Consignee";
                        Grid_blno.HeaderRow.Cells[4].Text = "20";
                        Grid_blno.HeaderRow.Cells[5].Text = "40";
                        Grid_blno.HeaderRow.Cells[6].Text = "CBM";
                        Grid_blno.HeaderRow.Cells[7].Text = "Gr.Wt.";
                        Grid_blno.HeaderRow.Cells[8].Text = "NoOfPkgs";

                        Grid_blno.HeaderRow.Cells[9].Text = "Pkgs";
                        Grid_blno.HeaderRow.Cells[10].Text = "Pol";
                        Grid_blno.HeaderRow.Cells[11].Text = "FD";
                        Grid_blno.HeaderRow.Cells[12].Text = "Splitbl#";
                    }

                }
                //else
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('No Data Found');", true);

                //}
            }

        }

        protected void Grid_blno_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                // lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_blno, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grid_blno_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();
            DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
            if (Grid_blno.Rows.Count > 0)
            {
                int index = Grid_blno.SelectedRow.RowIndex;
                string blno = Grid_blno.Rows[index].Cells[1].Text;
                string typenew = "";

                if (hid_splitbl.Value != "")
                {
                    typenew = "Split BL";
                }
                else
                {
                    typenew = "Direct BL";

                }
                int uiid = 267;
                dtuser = obj_UP.GetFormwiseuserRights(uiid, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FI");
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../FI/FIBL.aspx?blno=" + blno + "&type=" + typenew);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(grd, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
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

            obj_dtlogdetails = da_obj_Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 3, "Job", txt_jobno.Text, txt_jobno.Text, Session["StrTranType"].ToString());
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

        protected void txt_mblno_TextChanged(object sender, EventArgs e)
        {
            DataAccess.ForwardingExports.BLDetails objbl = new DataAccess.ForwardingExports.BLDetails();
            DataAccess.ForwardingImports.JobInfo fijobobj = new DataAccess.ForwardingImports.JobInfo();
            DataTable dtbook = new DataTable();
            dtbook = objbl.getsp_getbookingno(txt_mblno.Text.ToUpper(), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (dtbook.Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('MBL# and Booking# is same');", true);
                txt_mblno.Text = "";
                txt_mblno.Focus();
                return;
            }

            DataTable dtbl = new DataTable();
            dtbl = fijobobj.GetLikeBLNo(txt_mblno.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (dtbl.Rows.Count > 0)
            {
                for (int i = 0; i <= dtbl.Rows.Count - 1; i++)
                {
                    string bltext = dtbl.Rows[i].ItemArray[0].ToString().ToUpper();
                    if (bltext.ToUpper() == txt_mblno.Text.ToUpper())
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('BL # and MBL # should not Same,kindly change MBL # in Job screen');", true);
                        txt_mblno.Focus();
                        txt_mblno.Text = "";
                        return;
                    }
                }
            }
        }

        protected void grdBookJob_PreRender(object sender, EventArgs e)
        {
            if (grdBookJob.Rows.Count > 0)
            {
                grdBookJob.UseAccessibleHeader = true;
                grdBookJob.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void txt_CPort2_TextChanged(object sender, EventArgs e)
        {
            if(txt_CPort2.Text!="")
            {
                DataTable dtflag;
                DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                dtflag = obj_MasterPort.SelPortName4typepadimg(txt_CPort2.Text.ToUpper(), Session["StrTranType"].ToString());
                cport2flag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";
            }
        }

        protected void txt_CPort1_TextChanged(object sender, EventArgs e)
        {
            if (txt_CPort1.Text != "")
            {
                DataTable dtflag;
                DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                dtflag = obj_MasterPort.SelPortName4typepadimg(txt_CPort1.Text.ToUpper(), Session["StrTranType"].ToString());
                cport1flag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";
            }
        }

        protected void txt_CLastport_TextChanged(object sender, EventArgs e)
        {
            if (txt_CLastport.Text != "")
            {
                DataTable dtflag;
                DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                dtflag = obj_MasterPort.SelPortName4typepadimg(txt_CLastport.Text.ToUpper(), Session["StrTranType"].ToString());
                lastportflag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";
            }
        }

        protected void txt_CArrport_TextChanged(object sender, EventArgs e)
        {
            if (txt_CArrport.Text != "")
            {
                DataTable dtflag;
                DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                dtflag = obj_MasterPort.SelPortName4typepadimg(txt_CArrport.Text.ToUpper(), Session["StrTranType"].ToString());
                arrportflag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";
            }
        }

        protected void Btnamendmbl_Click(object sender, EventArgs e)
        {
            DataTable dtuser;
            if (Session["StrTranType"].ToString() == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1921, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_jobno.Text != "")
                    {
                        iframe1.Attributes["src"] = "../AI/AmendMBL.aspx?jobno=" + txt_jobno.Text + "&link=../FI/FIBL.aspx";
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
        protected void Btnamendjob_Click(object sender, EventArgs e)
        {
            DataTable dtuser;
            if (Session["StrTranType"].ToString() == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(89, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
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
        protected void Close_voucher_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Session["amendmbl"].ToString()))
            {
                txt_mblno.Text = Session["amendmbl"].ToString();
            }

        }
    }
}