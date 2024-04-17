using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.IO;

namespace logix.CRM
{
    public partial class ShipmentStatus : System.Web.UI.Page
    {
        string Ctrl_List;
        string Msg_List;
        string Data_List;

        int int_branchid;
        int int_divisionid;
        string blpod;
        string str_imailid;
        string str_cmailid;
        int int_empid;
        int int_uiid;
        int int_eventid;
        string shippermailadd;
        string internalmailid;
        string usermail;
        string strEmpName;
        string str_attach;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.AirImportExports.AIEJobInfo obj_aejobinfo = new DataAccess.AirImportExports.AIEJobInfo();
        DataAccess.Masters.MasterEmployee obj_da_me = new DataAccess.Masters.MasterEmployee();
        DataAccess.ForwardingExports.JobInfo obj_da_job = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.Marketing.Booking obj_da_book = new DataAccess.Marketing.Booking();
        DataAccess.Marketing.Booking obj_da_booking = new DataAccess.Marketing.Booking();
        DataAccess.ForwardingExports.StuffingConfirmation obj_da_stuff = new DataAccess.ForwardingExports.StuffingConfirmation();
        DataAccess.AirImportExports.AIEBLDetails da_obj_blobj = new DataAccess.AirImportExports.AIEBLDetails();
        DataAccess.ForwardingExports.BLDetails da_obj_FEblobj = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.ForwardingImports.BLDetails da_obj_blobj1 = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingExports.StuffingConfirmation obj_da_sc = new DataAccess.ForwardingExports.StuffingConfirmation();
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        DataAccess.Documents obj_da_doc = new DataAccess.Documents();
        DataAccess.LogDetails obj_da_ld = new DataAccess.LogDetails();
        DataAccess.Message4Booking obj_da_m4b = new DataAccess.Message4Booking();
        DataAccess.HR.Employee obj_da_hre = new DataAccess.HR.Employee();
        DateTime dt_now;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_aejobinfo.GetDataBase(Ccode);
                obj_da_me.GetDataBase(Ccode);
                obj_da_job.GetDataBase(Ccode);
                obj_da_book.GetDataBase(Ccode);
                obj_da_booking.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);


                obj_da_stuff.GetDataBase(Ccode);
                da_obj_blobj.GetDataBase(Ccode);
                da_obj_FEblobj.GetDataBase(Ccode);
                da_obj_blobj1.GetDataBase(Ccode);
                obj_da_jobinfo.GetDataBase(Ccode);


                obj_da_sc.GetDataBase(Ccode);
                obj_da_log.GetDataBase(Ccode);
                obj_da_doc.GetDataBase(Ccode);
                obj_da_ld.GetDataBase(Ccode);
                obj_da_m4b.GetDataBase(Ccode);
                obj_da_hre.GetDataBase(Ccode);

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_FornName, str_Uiid;
                str_FornName = Request.QueryString["FormName"].ToString();
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_save, null, null);
            } ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (!IsPostBack == true)
            {
                try
                {
                    Ctrl_List = txt_job.ID + "~" + txt_booking.ID + "~" + txt_status.ID;
                    Msg_List = "Status~Status~Status";
                    Data_List = "string";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Data_List + "');");
                    this.Mdl_grdjob.Hide();
                    this.Mdl_grdbook.Hide();
                    //DataAccess.Masters.MasterEmployee obj_da_me = new DataAccess.Masters.MasterEmployee();
                    int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                    strEmpName = obj_da_me.GetEmployeeName(int_empid);
                    ClearAll();
                    txt_job.Attributes.Add("onkeypress", "return IntegerCheck(event,'JOB#')");
                    grd_cmail.DataSource = new DataTable();
                    grd_cmail.DataBind();

                    grd_imail.DataSource = new DataTable();
                    grd_imail.DataBind();


                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        headerlable1.InnerText = "Ocean Exports";
                        //txt_vvoy.Attributes.Add("placeholder", "Vessel & Voy");
                        lbl_vvoy.Text = "Vessel & Voy";
                        txt_vvoy.ToolTip = "Vessel & Voy";
                        //txt_mvessel.Attributes.Add("placeholder", "Vessel & Voy");
                        lbl_mvessel.Text = "Vessel & Voy";
                        txt_mvessel.ToolTip = "Vessel & Voy";
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        headerlable1.InnerText = "Ocean Imports";
                        //txt_vvoy.Attributes.Add("placeholder", "Vessel & Voy");
                        lbl_vvoy.Text = "Vessel & Voy";

                        txt_vvoy.ToolTip = "Vessel & Voy";
                        //txt_mvessel.Attributes.Add("placeholder", "Vessel & Voy");
                        lbl_mvessel.Text = "Vessel & Voy";

                        txt_mvessel.ToolTip = "Vessel & Voy";
                    }
                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        headerlable1.InnerText = "Air Imports";
                        //txt_vvoy.Attributes.Add("placeholder", "Flight # & Date");
                        lbl_vvoy.Text = "Flight # & Date";

                        txt_vvoy.ToolTip = "Flight No & Date";
                        //txt_mvessel.Attributes.Add("placeholder", "Flight # & Date");
                        lbl_mvessel.Text = "Flight # & Date";

                        txt_mvessel.ToolTip = "Flight No & Date";
                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        headerlable1.InnerText = "Air Imports";
                        //txt_vvoy.Attributes.Add("placeholder", "Flight # & Date");
                        lbl_vvoy.Text = "Flight # & Date";
                        txt_vvoy.ToolTip = "Flight No & Date";




                        //txt_mvessel.Attributes.Add("placeholder", "Flight # & Date");
                        lbl_mvessel.Text = "Flight # & Date";
                        txt_mvessel.ToolTip = "Flight No & Date";
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
        public static List<string> IMailID(string prefix)
        {
            DataAccess.ForwardingExports.StuffingConfirmation obj_da_sc = new DataAccess.ForwardingExports.StuffingConfirmation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_sc.GetDataBase(Ccode);

            DataTable obj_Dt = new DataTable();
            List<string> Bookingno = new List<string>();
            obj_Dt = obj_da_sc.GetLikeEmpMailID(prefix);
            Bookingno = Utility.Fn_DatatableToList_int16(obj_Dt, "offmailid", "employeeid");
            return Bookingno;
        }

        [WebMethod]
        public static List<string> CMailID(string prefix)
        {
            DataAccess.ForwardingExports.StuffingConfirmation obj_da_sc = new DataAccess.ForwardingExports.StuffingConfirmation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_sc.GetDataBase(Ccode);
            DataTable obj_Dt = new DataTable();
            List<string> Bookingno = new List<string>();
            obj_Dt = obj_da_sc.GetLikeCustExporMailID(prefix);
            Bookingno = Utility.Fn_DatatableToList_int32(obj_Dt, "expmailid", "customerid");
            return Bookingno;
        }

        protected void lbl_job_Click(object sender, EventArgs e)
        {
            LoadJob();
        }

        protected void LoadJob()
        {
            try
            {
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                DataTable obj_dt = new DataTable();
                //DataAccess.ForwardingExports.JobInfo obj_da_job = new DataAccess.ForwardingExports.JobInfo();
                // obj_dt = obj_da_job.GetJobNoList(int_branchid, int_divisionid);

                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        obj_dt = obj_da_job.GetFEQrywithoutJobinfonew(int_branchid, int_divisionid);
                    }

                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        obj_dt = obj_da_job.GetFIQrywithoutJobinfonew(int_branchid, int_divisionid);

                    }

                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        obj_dt = obj_aejobinfo.GetAEQrywithoutJobinfonew(int_branchid, int_divisionid);

                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        obj_dt = obj_aejobinfo.GetAIQrywithoutJobinfonew(int_branchid, int_divisionid);

                    }



                }
                if (obj_dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Job Not Available');", true);
                }
                else
                {
                    Mdl_grdjob.Show();
                    grd_job.DataSource = obj_dt;
                    grd_job.DataBind();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        private void getjobinfo(int jobno)
        {
            string s_etd = "";
            string s_eta = "";
            string s_mnetd = "";
            string s_mneta = "";

            try
            {

                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                txt_job.Text = jobno.ToString();
                DataTable obj_dt_job = new DataTable();
                //DataAccess.ForwardingExports.JobInfo obj_da_job = new DataAccess.ForwardingExports.JobInfo();
                // obj_dt_job = obj_da_job.GetFEJobInfo(jobno, int_branchid, int_divisionid);

                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        obj_dt_job = obj_da_job.GetFEJobInfo(jobno, int_branchid, int_divisionid);
                    }

                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        obj_dt_job = obj_da_job.GetFIJobInfo(jobno, int_branchid, int_divisionid);

                    }

                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        obj_dt_job = obj_aejobinfo.GETAEJOBINFO(int_branchid, jobno.ToString());

                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        obj_dt_job = obj_aejobinfo.GETAIJOBINFO(int_branchid, jobno.ToString());

                    }



                }

                if (obj_dt_job.Rows.Count > 0 && Session["StrTranType"].ToString() == "AE")
                {
                    string flightno = "", flightdate = "";

                    flightno = obj_dt_job.Rows[0]["flightno"].ToString();
                    if (!string.IsNullOrEmpty(obj_dt_job.Rows[0]["flightdate"].ToString()))
                    {
                        flightdate = Utility.fn_ConvertDate(Convert.ToDateTime(obj_dt_job.Rows[0]["flightdate"].ToString()).ToShortDateString()); //Convert.ToDateTime(Utility.fn_ConvertDate(dtjob.Rows[0]["mbldraftssenton"].ToString())).ToShortDateString();
                    }

                    txt_vvoy.Text = flightno + " V " + flightdate;
                    txt_pol.Text = obj_dt_job.Rows[0][8].ToString();
                    txt_pod.Text = obj_dt_job.Rows[0][9].ToString();


                    s_etd = obj_dt_job.Rows[0]["etd"].ToString();
                    s_eta = obj_dt_job.Rows[0]["eta"].ToString();

                    DateTime dt_etd = Convert.ToDateTime(obj_dt_job.Rows[0]["etd"].ToString());
                    string format = "dd/MM/yyyy";
                    s_etd = dt_etd.ToString(format);

                    DateTime dt_eta = Convert.ToDateTime(obj_dt_job.Rows[0]["eta"].ToString());
                    string format1 = "dd/MM/yyyy";
                    s_eta = dt_eta.ToString(format1);

                    txt_etd.Text = s_etd.ToString();
                    txt_eta.Text = s_eta.ToString();




                }
                else if (obj_dt_job.Rows.Count > 0 && Session["StrTranType"].ToString() == "AI")
                {
                    string flightno = "", flightdate = "";

                    flightno = obj_dt_job.Rows[0]["flightno"].ToString();
                    if (!string.IsNullOrEmpty(obj_dt_job.Rows[0]["flightdate"].ToString()))
                    {
                        flightdate = Utility.fn_ConvertDate(Convert.ToDateTime(obj_dt_job.Rows[0]["flightdate"].ToString()).ToShortDateString()); //Convert.ToDateTime(Utility.fn_ConvertDate(dtjob.Rows[0]["mbldraftssenton"].ToString())).ToShortDateString();
                    }

                    txt_vvoy.Text = flightno + " V " + flightdate;
                    txt_pol.Text = obj_dt_job.Rows[0][8].ToString();
                    txt_pod.Text = obj_dt_job.Rows[0][9].ToString();


                    s_etd = obj_dt_job.Rows[0]["etd"].ToString();
                    s_eta = obj_dt_job.Rows[0]["eta"].ToString();

                    DateTime dt_etd = Convert.ToDateTime(obj_dt_job.Rows[0]["etd"].ToString());
                    string format = "dd/MM/yyyy";
                    s_etd = dt_etd.ToString(format);

                    DateTime dt_eta = Convert.ToDateTime(obj_dt_job.Rows[0]["eta"].ToString());
                    string format1 = "dd/MM/yyyy";
                    s_eta = dt_eta.ToString(format1);

                    txt_etd.Text = s_etd.ToString();
                    txt_eta.Text = s_eta.ToString();




                }

                if (obj_dt_job.Rows.Count > 0)
                {
                    txt_vvoy.Text = obj_dt_job.Rows[0]["vessel"].ToString() + " V " + obj_dt_job.Rows[0]["voyage"].ToString();
                    txt_pol.Text = obj_dt_job.Rows[0]["pol"].ToString();
                    txt_pod.Text = obj_dt_job.Rows[0]["pod"].ToString();

                    s_etd = obj_dt_job.Rows[0]["etd"].ToString();
                    s_eta = obj_dt_job.Rows[0]["eta"].ToString();

                    DateTime dt_etd = Convert.ToDateTime(obj_dt_job.Rows[0]["etd"].ToString());
                    string format = "dd/MM/yyyy";
                    s_etd = dt_etd.ToString(format);

                    DateTime dt_eta = Convert.ToDateTime(obj_dt_job.Rows[0]["eta"].ToString());
                    string format1 = "dd/MM/yyyy";
                    s_eta = dt_eta.ToString(format1);

                    txt_etd.Text = s_etd.ToString();
                    txt_eta.Text = s_eta.ToString();

                    //String[] str = s_etd.Split(' ');
                    //s_etd = str[0].ToString();

                    //String[] str1 = s_eta.Split(' ');
                    //s_eta = str[0].ToString();

                    //s_mnetd = Utility.fn_intMonthName(s_etd).ToString();
                    //s_mneta = Utility.fn_intMonthName(s_eta).ToString();

                    //s_etd = str[2] + "/" + s_mnetd + "/" + str[3];
                    //txt_etd.Text = s_etd.ToString();

                    //s_eta = str1[2] + "/" + s_mneta + "/" + str1[3];
                    //txt_eta.Text = s_eta.ToString();
                }

                else
                {
                    btn_save.Enabled = false;
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid Job #');", true);
                    txt_job.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        //protected void grd_job_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName != "Page")
        //    {
        //        LinkButton img_btn = (LinkButton)e.CommandSource;
        //        GridViewRow gvr = (GridViewRow)img_btn.NamingContainer;
        //        hf_jobno.Value = grd_job.DataKeys[gvr.RowIndex].Value.ToString();
        //        if (e.CommandName == "select")
        //        {
        //            getjobinfo(Convert.ToInt32(hf_jobno.Value));
        //        }
        //    }
        //}

        protected void lbl_booking_Click(object sender, EventArgs e)
        {

            try
            {
                Loadbooking();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void Loadbooking()
        {
            DataTable obj_dt_book = new DataTable();
            //DataAccess.Marketing.Booking obj_da_book = new DataAccess.Marketing.Booking();
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            if (txt_job.Text.Length != 0)
            {
                //obj_dt_book = obj_da_book.GetBookingPending4Shipstatus("FE", Convert.ToInt32(txt_job.Text), int_branchid);
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        obj_dt_book = obj_da_book.GetBookingPending4Shipstatus("FE", Convert.ToInt32(txt_job.Text), int_branchid);
                    }
                    else
                    {
                        obj_dt_book = obj_da_book.GetBookingPending4Shipstatus(Session["StrTranType"].ToString(), Convert.ToInt32(txt_job.Text), int_branchid);
                    }
                }

                if (obj_dt_book.Rows.Count > 0)
                {
                    this.Mdl_grdbook.Show();
                    grd_book.DataSource = obj_dt_book;
                    grd_book.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Booking number Not Available');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('JOB Number Not Available');", true);
            }
        }

        private void getBLDetails(string bookingno)
        {

            DataTable obj_dt_book = new DataTable();
            //DataAccess.Marketing.Booking obj_da_booking = new DataAccess.Marketing.Booking();
            //DataAccess.ForwardingExports.StuffingConfirmation obj_da_stuff = new DataAccess.ForwardingExports.StuffingConfirmation();
            //DataAccess.AirImportExports.AIEBLDetails da_obj_blobj = new DataAccess.AirImportExports.AIEBLDetails();
            //DataAccess.ForwardingExports.BLDetails da_obj_FEblobj = new DataAccess.ForwardingExports.BLDetails();
            //DataAccess.ForwardingImports.BLDetails da_obj_blobj1 = new DataAccess.ForwardingImports.BLDetails();
            try
            {
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                obj_dt_book = obj_da_booking.GetBookingDetails(bookingno, Session["StrTranType"].ToString(), int_branchid);
                if (obj_dt_book.Rows.Count > 0)
                {
                    DataTable obj_dt_stuff = new DataTable();
                    DataTable obj_dt_stuff1 = new DataTable();
                    DataTable obj_dt_stuff2 = new DataTable();

                    obj_dt_stuff = obj_da_stuff.SelFEshipstatus(bookingno, Convert.ToInt32(hf_jobno.Value), int_branchid, int_divisionid, Session["StrTranType"].ToString());
                    if (obj_dt_stuff.Rows.Count > 0)
                    {
                        txt_status.Text = obj_dt_stuff.Rows[0]["status"].ToString();
                        //    Dim ston As Date
                        //    ston = dtsp.Rows(0).Item("statuson").ToString()
                        //    txtStatuson.Text = Format(ston, "dd/MM/yyyy")
                        //btn_save.Text = "Update";
                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn btn-update1";
                    }

                    /*  obj_dt_stuff1 = obj_da_stuff.SelBL4shipstatus(bookingno, Convert.ToInt32(hf_jobno.Value), int_branchid, int_divisionid);
                      if (obj_dt_stuff1.Rows.Count > 0)
                      {
                          txt_bl.Text = obj_dt_stuff1.Rows[0]["blno"].ToString();
                          txt_stuffedon.Text = Utility.fn_ConvertDate(obj_dt_stuff1.Rows[0]["stuffedon"].ToString());
                          txt_mvessel.Text = obj_dt_stuff1.Rows[0]["vesselname"].ToString() + " V " + obj_dt_stuff1.Rows[0]["mvoyage"].ToString();
                          blpod = obj_dt_stuff1.Rows[0]["PORTNAME"].ToString();
                          txt_shipper.Text = obj_dt_stuff1.Rows[0]["shipper"].ToString();
                          txt_consignee.Text = obj_dt_stuff1.Rows[0]["consignee"].ToString();
                          txt_agent.Text = obj_dt_stuff1.Rows[0]["agent"].ToString();
                      }*/

                    if (Session["StrTranType"] != null)
                    {
                        //if (Session["StrTranType"].ToString()=="AE" || Session["StrTranType"].ToString()=="AI")
                        //{
                        obj_dt_stuff1 = da_obj_blobj.ShowSeljobinfonew(Convert.ToInt32(txt_job.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        //}
                        //else if (Session["StrTranType"].ToString() == "FE")
                        //{
                        //    obj_dt_stuff1 = da_obj_FEblobj.ShowFEInfonew(Convert.ToInt32(txt_job.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        //}

                        //else if (Session["StrTranType"].ToString() == "FI")
                        //{
                        //    obj_dt_stuff1 = da_obj_blobj1.ShowFIInfonew(Convert.ToInt32(txt_job.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        //}
                    }


                    if (obj_dt_stuff1.Rows.Count > 0)
                    {
                        txt_bl.Text = obj_dt_stuff1.Rows[0]["blno"].ToString();
                        txt_mvessel.Text = obj_dt_stuff1.Rows[0]["vessel"].ToString();
                        txt_shipper.Text = obj_dt_stuff1.Rows[0]["shipper"].ToString();
                        txt_consignee.Text = obj_dt_stuff1.Rows[0]["consignee"].ToString();
                        txt_agent.Text = obj_dt_stuff1.Rows[0]["Agent"].ToString();

                    }




                    obj_dt_stuff2 = obj_da_stuff.GetSBDetails(Convert.ToInt32(hf_jobno.Value), bookingno, int_branchid, int_divisionid);
                    if (obj_dt_stuff2.Rows.Count > 0)
                    {
                        lst_sbdate.Items.Clear();
                        for (int i = 0; i < obj_dt_stuff2.Rows.Count; i++)
                        {
                            lst_sbdate.Items.Add(obj_dt_stuff2.Rows[i]["sbno"].ToString() + "   /   " + obj_dt_stuff2.Rows[i]["sbdate"].ToString());
                        }
                    }



                    chk_containers.Items.Clear();
                    DataTable obj_dt_jobinfo = new DataTable();
                    //DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                    if (Session["StrTranType"] != null)
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            obj_dt_jobinfo = obj_da_jobinfo.GetContainerDetails(Convert.ToInt32(hf_jobno.Value), hf_jobno.Value, int_branchid, int_divisionid);
                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {
                            obj_dt_jobinfo = obj_da_jobinfo.GetContainerDetailsFI(Convert.ToInt32(hf_jobno.Value), hf_jobno.Value, int_branchid, int_divisionid);
                        }

                    }
                    for (int i = 0; i < obj_dt_jobinfo.Rows.Count; i++)
                    {
                        chk_containers.Items.Add(obj_dt_jobinfo.Rows[i][0].ToString());

                    }
                    getcontexist();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please Enter the Valid Bookingno');", true);
                    txt_booking.Focus();
                }

                //lstve.Visible = False
                DataTable obj_dt_dtc = new DataTable();
                obj_dt_dtc = obj_da_stuff.SelCRMMailids4shipstatus(Convert.ToInt32(hf_jobno.Value), bookingno, int_branchid, "E", int_divisionid);
                if (obj_dt_dtc.Rows.Count > 0)
                {
                    //for (int k = 0; k < obj_dt_dtc.Rows.Count; k++)
                    //{  
                    //}
                    grd_cmail.DataSource = obj_dt_dtc;
                    grd_cmail.DataBind();
                    Session["dt_CList"] = obj_dt_dtc;
                }

                DataTable obj_dt_dti = new DataTable();
                obj_dt_dti = obj_da_stuff.SelCRMMailids4shipstatus(Convert.ToInt32(hf_jobno.Value), bookingno, int_branchid, "I", int_divisionid);

                if (obj_dt_dti.Rows.Count > 0)
                {
                    //for (int k = 0; k < obj_dt_dtc.Rows.Count; k++)
                    //{  
                    //}
                    grd_imail.DataSource = obj_dt_dti;
                    grd_imail.DataBind();
                    Session["dt_IList"] = obj_dt_dti;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        private void getcontexist()
        {
            DataTable obj_dt_dtCont = new DataTable();
            //DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
            try
            {
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        obj_dt_dtCont = obj_da_jobinfo.GetContainerDetails(Convert.ToInt32(hf_jobno.Value), txt_booking.Text, int_branchid, int_divisionid);
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        obj_dt_dtCont = obj_da_jobinfo.GetContainerDetailsFI(Convert.ToInt32(hf_jobno.Value), txt_booking.Text, int_branchid, int_divisionid);
                    }
                }
                if (obj_dt_dtCont.Rows.Count > 0)
                {
                    for (int k = 0; k < obj_dt_dtCont.Rows.Count; k++)
                    {
                        if (chk_containers.Items[k].ToString() == obj_dt_dtCont.Rows[k]["containerno"].ToString())
                        {
                            chk_containers.Items[k].Selected = true;
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

        //protected void grd_book_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName != "Page")
        //    {
        //        LinkButton img_btn = (LinkButton)e.CommandSource;
        //        GridViewRow gvr = (GridViewRow)img_btn.NamingContainer;
        //        hf_bookno.Value = grd_book.DataKeys[gvr.RowIndex].Value.ToString();
        //        if (e.CommandName == "select")
        //        {
        //            txt_booking.Text = hf_bookno.Value.ToString();
        //            getBLDetails(hf_bookno.Value);
        //        }
        //    }
        //}

        private void Get_ImailID()
        {
            try
            {
                str_imailid = hf_imailname.Value.ToString();
                txt_imailid.Text = str_imailid.ToString();

                DataTable dt_list = new DataTable();
                dt_list = (DataTable)Session["dt_IList"];
                DataRow dr;
                if (dt_list == null)
                {
                    dt_list = new DataTable();
                    DataColumn dc_col2 = new DataColumn("mailid", typeof(string));
                    dt_list.Columns.Add(dc_col2);
                }
                DataRow[] dr_tt1 = dt_list.Select("mailid='" + txt_imailid.Text.ToString() + "'");
                if (dr_tt1.Length == 0)
                {
                    if (txt_imailid.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please Enter mailid');", true);
                    }
                    else
                    {
                        dr = dt_list.NewRow();
                        dr["mailid"] = txt_imailid.Text;
                        dt_list.Rows.Add(dr);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Mail id Already There');", true);
                }

                Session["dt_IList"] = dt_list;
                grd_imail.DataSource = dt_list;
                grd_imail.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void txt_imailid_TextChanged(object sender, EventArgs e)
        {
            if (hf_imailid.Value.Length > 0 && hf_imailid.Value != "0")
            {
                Get_ImailID();
                txt_imailid.Text = "";
                txt_cmailid.Focus();
            }
        }

        private void Get_CmailID()
        {
            try
            {
                str_cmailid = hf_cmailname.Value.ToString();
                txt_cmailid.Text = str_cmailid.ToString();

                DataTable dt_list = new DataTable();
                dt_list = (DataTable)Session["dt_CList"];
                DataRow dr;
                if (dt_list == null)
                {
                    dt_list = new DataTable();
                    DataColumn dc_col2 = new DataColumn("mailid", typeof(string));
                    dt_list.Columns.Add(dc_col2);
                }
                DataRow[] dr_tt1 = dt_list.Select("mailid='" + txt_cmailid.Text.ToString() + "'");
                if (dr_tt1.Length == 0)
                {
                    if (txt_cmailid.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please Enter mailid');", true);
                    }
                    else
                    {
                        dr = dt_list.NewRow();
                        dr["mailid"] = txt_cmailid.Text;
                        dt_list.Rows.Add(dr);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Mail id Already There');", true);
                }

                Session["dt_CList"] = dt_list;
                grd_cmail.DataSource = dt_list;
                grd_cmail.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void btn_plus_Click(object sender, EventArgs e)
        {
            Get_CmailID();
            txt_cmailid.Text = "";
            txt_cmailid.Focus();
        }

        private void ClearAll()
        {
            txt_job.Text = "";
            txt_vvoy.Text = "";
            txt_pol.Text = "";
            txt_etd.Text = "";
            txt_pod.Text = "";
            txt_eta.Text = "";
            txt_booking.Text = "";
            txt_bl.Text = "";
            txt_stuffedon.Text = "";
            txt_mvessel.Text = "";
            txt_shipper.Text = "";
            chk_containers.Items.Clear();
            lst_sbdate.Items.Clear();
            txt_consignee.Text = "";
            txt_agent.Text = "";
            hf_jobno.Value = "0";
            txt_status.Text = "";
            btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            btn_back.Text = "Back";
            btn_back.ToolTip = "Back";
            btn_back1.Attributes["class"] = "btn ico-back";
            grd_cmail.DataSource = new DataTable();
            grd_cmail.DataBind();
            grd_imail.DataSource = new DataTable();
            grd_imail.DataBind();
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            DataTable obj_dt_book = new DataTable();
            //DataAccess.Marketing.Booking obj_da_booking = new DataAccess.Marketing.Booking();
            //DataAccess.ForwardingExports.StuffingConfirmation obj_da_sc = new DataAccess.ForwardingExports.StuffingConfirmation();
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            try
            {
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                obj_dt_book = obj_da_booking.GetBookingDetails(txt_booking.Text, Session["StrTranType"].ToString(), int_branchid);
                if (obj_dt_book.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please Enter the Valid Bookingno');", true);
                    return;
                }
                if (btn_save.ToolTip == "Save")
                {
                    obj_da_sc.InsFEShipmentStatus(Convert.ToInt32(txt_job.Text), txt_booking.Text, obj_da_log.GetDate(), txt_status.Text, int_branchid, int_divisionid, Session["StrTranType"].ToString());
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved');", true);


                    switch (Session["StrTranType"].ToString())
                    {
                        case "FE":
                            obj_da_log.InsLogDetail(int_empid, 660, 1, int_branchid, txt_booking.Text + "FE / " + obj_da_log.GetDate() + "/" + txt_status.Text + "/Sav");

                            break;
                        case "FI":
                            obj_da_log.InsLogDetail(int_empid, 1976, 1, int_branchid, txt_booking.Text + "FI / " + obj_da_log.GetDate() + "/" + txt_status.Text + "/Sav");
                            break;
                        case "AE":
                            obj_da_log.InsLogDetail(int_empid, 1977, 1, int_branchid, txt_booking.Text + "AE / " + obj_da_log.GetDate() + "/" + txt_status.Text + "/Sav");
                            break;
                        case "AI":
                            obj_da_log.InsLogDetail(int_empid, 1978, 1, int_branchid, txt_booking.Text + "AI / " + obj_da_log.GetDate() + "/" + txt_status.Text + "/Sav");
                            break;

                    }




                }
                else
                {
                    obj_da_sc.UpdFEShipmentStatus(Convert.ToInt32(txt_job.Text), txt_booking.Text, obj_da_log.GetDate(), txt_status.Text, int_branchid, int_divisionid, Session["StrTranType"].ToString());
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated');", true);
                    //obj_da_log.InsLogDetail(int_empid, 660, 2, int_branchid, txt_booking.Text);

                    switch (Session["StrTranType"].ToString())
                    {
                        case "FE":
                            obj_da_log.InsLogDetail(int_empid, 660, 2, int_branchid, txt_booking.Text + "FE / " + obj_da_log.GetDate() + "/" + txt_status.Text + "/Upd");

                            break;
                        case "FI":
                            obj_da_log.InsLogDetail(int_empid, 1976, 2, int_branchid, txt_booking.Text + "FI / " + obj_da_log.GetDate() + "/" + txt_status.Text + "/Upd");
                            break;
                        case "AE":
                            obj_da_log.InsLogDetail(int_empid, 1977, 2, int_branchid, txt_booking.Text + "AE / " + obj_da_log.GetDate() + "/" + txt_status.Text + "/Upd");
                            break;
                        case "AI":
                            obj_da_log.InsLogDetail(int_empid, 1978, 2, int_branchid, txt_booking.Text + "AI / " + obj_da_log.GetDate() + "/" + txt_status.Text + "/Upd");
                            break;

                    }

                    //btn_save.Text = "Save";
                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                }
                ClearAll();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }
        private void StatusMail()
        {
            string st = "";
            string st1 = "";
            string st2 = "";
            try
            {
                if (fu_attach.HasFile)
                {
                    str_attach = fu_attach.PostedFile.FileName;

                    str_attach = fu_attach.FileName;
                    st = Path.GetFileName(fu_attach.FileName);
                    st2 = Path.GetFullPath(fu_attach.PostedFile.FileName);

                }

                int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                //DataAccess.Masters.MasterEmployee obj_da_me = new DataAccess.Masters.MasterEmployee();
                strEmpName = obj_da_me.GetEmployeeName(int_empid);
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                string sname = "";
                string sendqry = "";

                string subject = "";
                //DataAccess.Documents obj_da_doc = new DataAccess.Documents();
                //DataAccess.LogDetails obj_da_ld = new DataAccess.LogDetails();
                //DataAccess.Message4Booking obj_da_m4b = new DataAccess.Message4Booking();
                sname = obj_da_doc.GetShortname(int_branchid);
                subject = "PRESENT STATUS - " + txt_bl.Text + "-" + blpod + "-" + sname + "-" + txt_job.Text;
                sendqry = sendqry + "<table cellspacing=0 cellpadding=2>";
                sendqry = sendqry + "<tr><td align=left ><font size=2 face=sans-serif>Dear Sir / Madam,</td></tr>";
                sendqry = sendqry + "</table>";
                sendqry = sendqry + "<table cellspacing=0 cellpadding=2>";
                sendqry = sendqry + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<tr><td align=left ><font size=2 face=sans-serif>Status - " + txt_status.Text + ". </td></tr>";
                sendqry = sendqry + "</table>";
                sendqry = sendqry + "<table cellspacing=0 cellpadding=2>";
                sendqry = sendqry + "<tr><td align=left ><font size=2 face=sans-serif>Thanks & Regards ,</td></tr>";
                sendqry = sendqry + "<tr><td align=left ><font size=2 face=sans-serif>" + obj_da_me.GetEmployeeName(int_empid) + ".</td></tr><br>";
                sendqry = sendqry + "</table>";

                //string str_mailserver = Session["MailServer"].ToString();
                string str_usermailid = Session["usermailid"].ToString();
                // string str_mailuser = Session["MailUser"].ToString();
                string str_mailpwd = Session["usermailpwd"].ToString();


                //Utility.SendMail(usermail, shippermailadd, subject, sendqry, "", str_mailpwd);



                Utility.SendMailnew("", shippermailadd, subject, sendqry, "", "Msncl2021$", "");
                 


                //sendmail.SendEmail(shippermailadd, usermail, "pandi", subject, sendqry, true, str_mailserver, internalmailid, "", str_mailuser, str_mailpwd, str_attach);
                obj_da_m4b.InsMsg4Booking(txt_booking.Text, subject, shippermailadd, internalmailid, obj_da_ld.GetDate(), strEmpName, "", "", "");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            //DataAccess.HR.Employee obj_da_hre = new DataAccess.HR.Employee();
            try
            {
                int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                string str_usermailid = Session["usermailid"].ToString();
                string str_mailpwd = Session["usermailpwd"].ToString();
                if (txt_job.Text.Length != 0 && txt_booking.Text.Length != 0)
                {
                    shippermailadd = "";
                    for (int i = 0; i < grd_cmail.Rows.Count; i++)
                    {
                        shippermailadd = shippermailadd + grd_cmail.Rows[i].Cells[0].Text + ";";
                    }
                    internalmailid = "";
                    usermail = "";
                    if (grd_imail.Rows.Count > 0)
                    {
                        for (int i = 0; i < grd_imail.Rows.Count; i++)
                        {
                            internalmailid = internalmailid + grd_imail.Rows[i].Cells[0].Text + ";";
                        }
                        usermail = obj_da_hre.GetMailAdd(int_empid);
                        if (internalmailid != "")
                        {
                            internalmailid = internalmailid + ";" + usermail;
                        }
                        else
                        {
                            internalmailid = usermail;
                        }
                    }
                    else
                    {
                        usermail = obj_da_hre.GetMailAdd(int_empid);
                        internalmailid = usermail;
                    }
                    if (shippermailadd != "")
                    {
                        shippermailadd = shippermailadd.Replace(",", ";");
                        shippermailadd = shippermailadd.Remove(shippermailadd.Length - 1, 1);
                    }
                    StatusMail();
                    //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 660, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text + "/ Send");


                    switch (Session["StrTranType"].ToString())
                    {
                        case "FE":
                            Logobj.InsLogDetail(int_empid, 660, 3, int_branchid, txt_booking.Text + "FE / " + txt_status.Text + "/Send");

                            break;
                        case "FI":
                            Logobj.InsLogDetail(int_empid, 1976, 3, int_branchid, txt_booking.Text + "FI / " + txt_status.Text + "/Send");
                            break;
                        case "AE":
                            Logobj.InsLogDetail(int_empid, 1977, 3, int_branchid, txt_booking.Text + "AE / " + txt_status.Text + "/Send");
                            break;
                        case "AI":
                            Logobj.InsLogDetail(int_empid, 1978, 3, int_branchid, txt_booking.Text + "AI / " + txt_status.Text + "/Send");
                            break;

                    }



                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                ClearAll();
            }
            else
            {
                //this.Response.End();

                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "CS")
                    {
                        if (Session["StrTranType"] != null)
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

                    }
                }
                else
                {
                    this.Response.End();
                }
            }
        }

        protected void txt_job_TextChanged(object sender, EventArgs e)
        {
            txt_job_change();
        }

        public void txt_job_change()
        {
            if (txt_job.Text != "")
            {
                ClearAll1();
                hf_jobno.Value = txt_job.Text;
                getjobinfo(Convert.ToInt32(txt_job.Text));
            }
            btn_back.Text = "Cancel";
            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }

        private void ClearAll1()
        {
            txt_vvoy.Text = "";
            txt_etd.Text = "";
            txt_eta.Text = "";
            txt_pol.Text = "";
            txt_pod.Text = "";

            txt_status.Text = "";
            txt_imailid.Text = "";
            txt_cmailid.Text = "";
            lst_sbdate.Items.Clear();
            txt_bl.Text = "";
            txt_stuffedon.Text = "";
            txt_mvessel.Text = "";

            txt_agent.Text = "";
            txt_consignee.Text = "";
            txt_shipper.Text = "";
        }

        protected void txt_cmailid_TextChanged(object sender, EventArgs e)
        {
            if (hf_imailid.Value.Length > 0 && hf_imailid.Value != "0")
            {
                Get_ImailID();
                txt_imailid.Text = "";
                txt_cmailid.Focus();
            }
        }

        protected void grd_job_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblVesselName = (Label)e.Row.FindControl("VesselName");
                string tooltip = lblVesselName.Text;
                e.Row.Cells[1].Attributes.Add("title", tooltip);

                Label lblVoyage = (Label)e.Row.FindControl("Voyage");
                string tooltip1 = lblVoyage.Text;
                e.Row.Cells[2].Attributes.Add("title", tooltip1);

                Label lblMBL = (Label)e.Row.FindControl("MBL");
                string tooltip2 = lblMBL.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip2);

                Label lblDestination = (Label)e.Row.FindControl("Destination");
                string tooltip3 = lblDestination.Text;
                e.Row.Cells[5].Attributes.Add("title", tooltip3);

                Label lblMLO = (Label)e.Row.FindControl("MLO");
                string tooltip4 = lblMLO.Text;
                e.Row.Cells[7].Attributes.Add("title", tooltip4);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_job, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_book_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCustomer = (Label)e.Row.FindControl("Customer");
                string tooltip = lblCustomer.Text;
                e.Row.Cells[1].Attributes.Add("title", tooltip);

                Label lblPOL = (Label)e.Row.FindControl("POL");
                string tooltip1 = lblPOL.Text;
                e.Row.Cells[2].Attributes.Add("title", tooltip1);

                Label lblPOD = (Label)e.Row.FindControl("POD");
                string tooltip2 = lblPOD.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip2);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_book, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
        }

        protected void grd_job_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grd_job.SelectedRow.RowIndex;
            txt_job.Text = ((Label)grd_job.Rows[index].Cells[0].FindControl("Job")).Text;
            txt_job_change();
        }

        protected void grd_book_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grd_book.SelectedRow.RowIndex;
            txt_booking.Text = ((Label)grd_book.Rows[index].Cells[0].FindControl("Booking")).Text;
            getBLDetails(txt_booking.Text);
        }

        protected void grd_book_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grd_book.PageIndex = e.NewPageIndex;
                Loadbooking();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void grd_job_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grd_job.PageIndex = e.NewPageIndex;
                LoadJob();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void grd_imail_PreRender(object sender, EventArgs e)
        {
            if (grd_imail.Rows.Count > 0)
            {
                grd_imail.UseAccessibleHeader = true;
                grd_imail.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_cmail_PreRender(object sender, EventArgs e)
        {
            if (grd_cmail.Rows.Count > 0)
            {
                grd_cmail.UseAccessibleHeader = true;
                grd_cmail.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}