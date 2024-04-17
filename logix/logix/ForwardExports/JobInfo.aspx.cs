using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Globalization;
using System.Web.UI.HtmlControls;

namespace logix.ForwardExports
{
    public partial class JobInfo : System.Web.UI.Page
    {
        DataAccess.Marketing.Booking book = new DataAccess.Marketing.Booking();
        DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
        DataAccess.Masters.MasterContainer obj_da_container = new DataAccess.Masters.MasterContainer();
        DataAccess.ForwardingExports.BLDetailsWOJob obj_da_BLwojob = new DataAccess.ForwardingExports.BLDetailsWOJob();
        DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();

        DataAccess.ForwardingExports.JobInfo obj_da_Job = new DataAccess.ForwardingExports.JobInfo();
        DataTable obj_dt = new DataTable();
        int branchid;
        DataTable dtbk = new DataTable();
        string str_CtrlLists, str_MsgLists, str_DataType, str_CtrlLists1, str_MsgLists1, str_DataType1;
        string str_FornName = "", str_Uiid = "";
        DataTable dsJob = new DataTable();
        DataTable dt_search = new DataTable();
        DataTable obj_dt1 = new DataTable();
        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        int bookno;
        Boolean blnMBL,brr;
        string str_status;
        int custid;
        string booking = "", book_select = "";
          DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "dropdownButton();SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);

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
                try
                {
                    
                    
                    str_CtrlLists = "txt_vessel~txt_voyage~txt_mbl~txt_loadport~txt_destport~txt_em~txt_mlo~txt_agent~txt_Stuffedon~txt_etd";
                    str_MsgLists = "Vessel~Voyage~MBL~Load Port~Destination Port~EM#~MLO~Agent~Carrier~Stuffed on~ETD";
                    str_DataType = "String~String~String~String~String~String~String~String~String~String~String";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "')");

                    Session["Container"] = "";
                    txt_job.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    txt_pkgs.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    str_CtrlLists1 = "txt_container~txt_seal~txt_pkgs~txt_wt";
                    str_MsgLists1 = "CONTAINER~SEAL NUMBER~PACKAGE~WEIGHT";
                    str_DataType1 = "String~String~String~String";
                    //btn_add.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists1 + "','" + str_MsgLists1 + "','" + str_DataType1 + "')");
                    hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                    txt_date.Text = hid_date.Value.ToString();
                    txt_eta.Text = hid_date.Value.ToString();
                    txt_etd.Text = hid_date.Value.ToString();
                    txt_Stuffedon.Text = hid_date.Value.ToString();
                    txtlbdate.Text = hid_date.Value.ToString();
                    txt_emdate.Text = hid_date.Value.ToString();
                    txt_date1.Text = hid_date.Value.ToString();
                    txt_wt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
                    ddl_size.Items.Add("");
                    obj_dt = obj_da_container.GetContainersizes();
                    if (obj_dt.Rows.Count > 0)
                    {
                        //ddl_size.DataSource = obj_dt;
                        //ddl_size.DataTextField = "conttype";
                        //ddl_size.DataBind();
                        for (int i = 0; i < obj_dt.Rows.Count - 1; i++)
                        {
                            ddl_size.Items.Add(obj_dt.Rows[i]["conttype"].ToString());

                        }
                    }
                    if (txt_search.Text != "")
                    {
                        txt_search.Focus();
                    }
                    else
                    {
                        txt_job.Focus();

                    }
                    DataTable dt_new = new DataTable();
                    dt_new.Columns.Add("Job #");
                    dt_new.Columns.Add("BL #");
                    dt_new.Columns.Add("Shipper");
                    dt_new.Columns.Add("Consignee");
                    dt_new.Columns.Add("20");
                    dt_new.Columns.Add("40");
                    dt_new.Columns.Add("CBM");

                    dt_new.Columns.Add("Gr.Wt.");
                    dt_new.Columns.Add("UoM");
                   

                    dt_new.Columns.Add("PoL");
                    dt_new.Columns.Add("FD");
                    dt_new.Columns.Add("OurBL");
                    grd.DataSource = dt_new;
                    grd.DataBind();

                    if (Request.QueryString.ToString().Contains("back"))
                    {
                        txt_job.Text = Request.QueryString["job"].ToString();
                        txt_job_TextChanged(sender, e);
                    }
                    if (Request.QueryString.ToString().Contains("JobDetails"))
                    {
                        hidbooking.Value = Request.QueryString["bookingno"].ToString();
                        custid = Convert.ToInt32(Request.QueryString["Cusid"].ToString());
                        txt_search.Text = hidbooking.Value;
                        Booking_select();
                        return;
                        //UserRights();
                        //return;
                    }
                    else
                    {
                        BindBooking();
                    }
                    UserRights();
                }
                //catch (Exception ex)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../FormMain.aspx','_top');", true);
                //}
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
            txt_date.Enabled = false;
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


        protected void Booking_select()
        {
            branchid = Convert.ToInt32(Session["LoginBranchid"]);
            dtbk = book.GETBookingNofordock(branchid, "FE", custid, 0);
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

        protected void Booking_fill()
        {

            dtbk = obj_da_Job.get_getdetailsforemptyjobbooking(int.Parse(Session["LoginBranchid"].ToString()), book_select);
            if (dtbk.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtbk.Rows[0]["etd"].ToString()))
                {
                    txt_etd.Text = Utility.fn_ConvertDate(dtbk.Rows[0]["etd"].ToString());
                    txt_Stuffedon.Text = Utility.fn_ConvertDate((Convert.ToDateTime(dtbk.Rows[0]["etd"].ToString()).AddDays(-2)).ToString());
                }
                if (!string.IsNullOrEmpty(dtbk.Rows[0]["eta"].ToString()))
                {
                    txt_eta.Text = Utility.fn_ConvertDate(dtbk.Rows[0]["eta"].ToString());
                }

                if (!string.IsNullOrEmpty(dtbk.Rows[0]["CarrierID"].ToString()))
                {
                    hdnCarrier.Value = dtbk.Rows[0]["CarrierID"].ToString();
                }
                else
                {
                    hdnCarrier.Value = "";
                }
                if (!string.IsNullOrEmpty(dtbk.Rows[0]["CarrierName"].ToString()))
                {
                    txtCarrier.Text = dtbk.Rows[0]["CarrierName"].ToString();
                }

                //txt_mbl.Text = dtbk.Rows[0]["mbl"].ToString();
                txt_loadport.Text = dtbk.Rows[0]["pol"].ToString();
                hid_Loadportid.Value = dtbk.Rows[0]["polid"].ToString();
                txt_destport.Text = dtbk.Rows[0]["pod"].ToString();
                hid_Destportid.Value = dtbk.Rows[0]["podid"].ToString();
                txt_shptdest.Text = dtbk.Rows[0]["fd"].ToString();
                hid_Shipdesportid.Value = dtbk.Rows[0]["fdid"].ToString();
                txt_agent.Text = dtbk.Rows[0]["agent"].ToString();
                hid_Agentid.Value = dtbk.Rows[0]["agentid"].ToString();
                txt_mlo.Text = dtbk.Rows[0]["mlo"].ToString();
                hid_Mloid.Value = dtbk.Rows[0]["mloid"].ToString();
                txt_vessel.Text = dtbk.Rows[0]["vesselname"].ToString();
                txt_voyage.Text = dtbk.Rows[0]["voyage"].ToString();
                hid_Vesselid.Value = dtbk.Rows[0]["vesselid"].ToString();
                ddl_jobtype.SelectedValue = "3";
                if (dtbk.Rows[0]["business"].ToString() != "O")
                {
                    ddl_Contract.SelectedValue = "A";
                }
                else
                {
                    ddl_Contract.SelectedValue = dtbk.Rows[0]["business"].ToString();
                }

            }
        }

        [WebMethod]
        public static List<string> SelPortName4typepadimg(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            //dt = obj_MasterPort.GetPortNameDetails(prefix.Trim());
            if (HttpContext.Current.Session["StrTranType"] != null)
            {
                string trantype = HttpContext.Current.Session["StrTranType"].ToString();
                dt = obj_MasterPort.SelPortName4typepadimg(prefix.Trim(), trantype);
                list_result = Utility.Fn_TableToList4type(dt, "portname", "portid", "portcode", "countryname", "countrycode");
            }
            return list_result;

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
                 //   btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                    //if (btn_delete == true)
                    //{
                    //    Grd_container.Columns[6].Visible = true;
                    //}
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_job_Click(object sender, EventArgs e)
        {
            try
            {
                loadgrid();
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void loadgrid()
        {
            Grd_Job.Visible = true;
            Grd_Vessel.Visible = false;
            DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_jobinfo.GetJobNoList(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
            if (obj_dt.Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(lnk_job, typeof(LinkButton), "JobInfo", "alertify.alert('Job Not Available');", true);
                return;
            }
            else
            {
                popup_Grd.Show();
                Grd_Job.DataSource = obj_dt;
                Grd_Job.DataBind();
                txt_date1.Enabled = true;
            }
        }
        protected void btnbl_Click(object sender, EventArgs e)
        {
            if (Request.QueryString.ToString().Contains("back"))
            {
                string trantype_process = Session["StrTranType"].ToString();
                DataTable dtuser = new DataTable();

                if (trantype_process == "FE")
                {
                    dtuser = obj_UP.GetFormwiseuserRights(1014, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                    if (dtuser.Rows.Count > 0)
                    {


                        Response.Redirect("../ShipmentDetails/FEBLdetails.aspx");


                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                    }

                }
            }
        }
        protected void Grd_Job_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                popup_Grd.Hide();
                //int int_jobno = int.Parse(Grd_Job.SelectedRow.Cells[0].Text.ToString());
                int index = Convert.ToInt32(Grd_Job.SelectedRow.RowIndex);
                int int_jobno = Convert.ToInt32(((Label)Grd_Job.Rows[index].Cells[0].FindControl("Job")).Text);
                hid_jobid.Value = int_jobno.ToString();
                fn_jobdetails(int_jobno);

                getblno();
                UserRights();
                //BindBooking();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        public void getblno()
        {
            DataAccess.ForwardingExports.BLDetails da_obj_FEblobj = new DataAccess.ForwardingExports.BLDetails();
            DataTable dt_new;
            if (Grd_Job.Rows.Count > 0)
            {
                //int count = Grd_Job.SelectedRow.RowIndex;
                //int jobno;
                //Label lbl = (Grd_Job.Rows[count].Cells[0].FindControl("jobno") as Label);
                // jobno =Convert.ToInt32(lbl.Text);
                if (hid_jobid.Value.ToString() != "")
                {
                    dt_new = da_obj_FEblobj.ShowFEInfonew(Convert.ToInt32(hid_jobid.Value), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dt_new.Rows.Count > 0)
                    {

                        hid_type.Value = dt_new.Rows[0]["ourbl"].ToString();
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
                            grd.HeaderRow.Cells[1].Text = "BL #";
                            grd.HeaderRow.Cells[2].Text = "Shipper";
                            grd.HeaderRow.Cells[3].Text = "Consignee";
                            grd.HeaderRow.Cells[4].Text = "NoOfCont20";
                            grd.HeaderRow.Cells[5].Text = "NoOfCont40";
                            grd.HeaderRow.Cells[6].Text = "CBM";

                            grd.HeaderRow.Cells[7].Text = "Gr.Wt.";
                            grd.HeaderRow.Cells[8].Text = "NoofPkgs";
                            grd.HeaderRow.Cells[9].Text = "UoM";

                            grd.HeaderRow.Cells[10].Text = "PoL";
                            grd.HeaderRow.Cells[11].Text = "FD";
                            grd.HeaderRow.Cells[12].Text = "OurBL";




                        }
                        else
                        {

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

        private void fn_jobdetails(int jobno)
        {
            DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_jobinfo.GetFEJobInfo(jobno, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
            if (obj_dt.Rows.Count > 0)
            {

                txt_job.Text = jobno.ToString();
                txt_date.Text = obj_dt.Rows[0]["webjobdate"].ToString();
                txt_loadport.Text = obj_dt.Rows[0]["pol"].ToString();
                txt_destport.Text = obj_dt.Rows[0]["pod"].ToString();
                DataTable dtflag;
                DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                dtflag = obj_MasterPort.SelPortName4typepadimg(txt_loadport.Text.ToUpper(), Session["StrTranType"].ToString());
                flagimg.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";

                dtflag = obj_MasterPort.SelPortName4typepadimg(txt_destport.Text.ToUpper(), Session["StrTranType"].ToString());
                podflag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";
                txt_vessel.Text = obj_dt.Rows[0]["vessel"].ToString();
                txt_voyage.Text = obj_dt.Rows[0]["voyage"].ToString();
                txt_shptdest.Text = obj_dt.Rows[0]["sd"].ToString();

                dtflag = obj_MasterPort.SelPortName4typepadimg(txt_shptdest.Text.ToUpper(), Session["StrTranType"].ToString());
                fdflag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";
                txt_agent.Text = obj_dt.Rows[0]["agent"].ToString();

                txt_mlo.Text = obj_dt.Rows[0]["mlo"].ToString();
                txt_eta.Text = obj_dt.Rows[0]["webeta"].ToString();
                txt_etd.Text = obj_dt.Rows[0]["webetd"].ToString();
                txt_emdate.Text = obj_dt.Rows[0]["webemdate"].ToString();
                txt_em.Text = obj_dt.Rows[0]["emno"].ToString();
                txt_mbl.Text = obj_dt.Rows[0]["mblno"].ToString();
             
                hid_Agentid.Value = obj_dt.Rows[0]["agentid"].ToString();
                hid_Mloid.Value = obj_dt.Rows[0]["mloid"].ToString();
                hid_Vesselid.Value = obj_dt.Rows[0]["vesselid"].ToString();
                hid_Contra.Value = obj_dt.Rows[0]["contract"].ToString();
                hid_Loadportid.Value = obj_dt.Rows[0]["polid"].ToString();
                hid_Destportid.Value = obj_dt.Rows[0]["podid"].ToString();
                hid_Shipdesportid.Value = obj_dt.Rows[0]["fdid"].ToString();
                hid_jobtype.Value = obj_dt.Rows[0]["jobtype"].ToString();
                hdnCarrier.Value = obj_dt.Rows[0]["carrierid"].ToString();
                txtCarrier.Text = obj_dt.Rows[0]["carrier"].ToString();
                if (obj_dt.Rows[0]["jobprofit"].ToString() == "P")
                {
                    CHk_DropFE.Checked = true;
                }
                else
                {
                    CHk_DropFE.Checked = false;
                }




                if (obj_dt.Rows[0]["lbdate"].ToString().Trim().Length > 0)
                {
                    txtlbdate.Text = obj_dt.Rows[0]["lbdate"].ToString();
                    //txtlbdate.Text = obj_da_Log1.GetDate();
                    txtlbdate.Text = Convert.ToDateTime(txtlbdate.Text).ToString("dd/MM/yyyy");
                }
                else
                {
                    txtlbdate.Text = hid_date.Value;

                }
                if (obj_dt.Rows[0]["stuffedon"].ToString().Trim().Length > 0)
                {
                    txt_Stuffedon.Text = obj_dt.Rows[0]["webstuffedon"].ToString();
                }
                else
                {
                    txt_Stuffedon.Text = hid_date.Value;
                }
                txt_remark.Text = obj_dt.Rows[0]["remarks"].ToString();
                if (obj_dt.Rows[0]["mblstatus"].ToString() != "S" && obj_dt.Rows[0]["mblstatus"].ToString() != "B")
                {
                    ddl_mblstatus.SelectedValue = "R";
                }
                else
                {
                    ddl_mblstatus.SelectedValue = obj_dt.Rows[0]["mblstatus"].ToString();
                }
                ddl_jobtype.SelectedValue = obj_dt.Rows[0]["jobtype"].ToString();
                if (obj_dt.Rows[0]["contract"].ToString() != "O")
                {
                    ddl_Contract.SelectedValue = "A";
                }
                else
                {
                    ddl_Contract.SelectedValue = obj_dt.Rows[0]["contract"].ToString();
                }

                DataTable obj_dtjob = new DataTable();
                Grd_container.DataSource = Utility.Fn_GetEmptyDataTable();
                obj_dtjob = obj_da_jobinfo.GetContainerDetails(jobno, jobno.ToString(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));


                Grd_container.DataSource = obj_dtjob;
                Grd_container.DataBind();
                Session["Container"] = obj_dtjob;



                obj_dtjob = null;
                //  DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                for (int i = 1; i <= 6; i++)
                {
                    obj_dtjob = obj_da_Invoice.CheckIPDCWMBL(txt_mbl.Text, "FE", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["Vouyear"].ToString()), i);
                    if (obj_dtjob.Rows.Count > 0)
                    {
                        txt_mbl.Enabled = false;
                        break;
                    }
                    else
                    {
                        txt_mbl.Enabled = true;
                    }

                }
                obj_dtjob.Reset();
                obj_dtjob = obj_da_jobinfo.getCheckCNDNForaJOb(int.Parse(Session["LoginBranchid"].ToString()), jobno, "FE");
                if (obj_dtjob.Rows.Count > 0)
                {
                    txt_agent.Enabled = false;

                }
                //btn_save.Text = "Update";
                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                txt_container.Focus();
                getbookingassigned();
                BindBooking();

            }
            else
            {
                btn_save.Enabled = false;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "JobInfo", "alertify.alert('Job Not Available');", true);
            }
        }



        private void fn_jobdetailsReuse(int jobno)
        {
            DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_jobinfo.GetFEJobInfo(jobno, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
            if (obj_dt.Rows.Count > 0)
            {


                txt_date.Text = obj_dt.Rows[0]["webjobdate"].ToString();
                txt_loadport.Text = obj_dt.Rows[0]["pol"].ToString();
                txt_destport.Text = obj_dt.Rows[0]["pod"].ToString();
                txt_vessel.Text = obj_dt.Rows[0]["vessel"].ToString();
                txt_voyage.Text = obj_dt.Rows[0]["voyage"].ToString();
                txt_shptdest.Text = obj_dt.Rows[0]["sd"].ToString();
                txt_agent.Text = obj_dt.Rows[0]["agent"].ToString();
                txt_mlo.Text = obj_dt.Rows[0]["mlo"].ToString();
                txt_eta.Text = obj_dt.Rows[0]["webeta"].ToString();
                txt_etd.Text = obj_dt.Rows[0]["webetd"].ToString();
                txt_emdate.Text = obj_dt.Rows[0]["webemdate"].ToString();
                txt_em.Text = obj_dt.Rows[0]["emno"].ToString();
                txt_mbl.Text = obj_dt.Rows[0]["mblno"].ToString();

                hid_Agentid.Value = obj_dt.Rows[0]["agentid"].ToString();
                hid_Mloid.Value = obj_dt.Rows[0]["mloid"].ToString();
                hid_Vesselid.Value = obj_dt.Rows[0]["vesselid"].ToString();
                hid_Contra.Value = obj_dt.Rows[0]["contract"].ToString();
                hid_Loadportid.Value = obj_dt.Rows[0]["polid"].ToString();
                hid_Destportid.Value = obj_dt.Rows[0]["podid"].ToString();
                hid_Shipdesportid.Value = obj_dt.Rows[0]["fdid"].ToString();
                hid_jobtype.Value = obj_dt.Rows[0]["jobtype"].ToString();
                hdnCarrier.Value = obj_dt.Rows[0]["carrierid"].ToString();
                txtCarrier.Text = obj_dt.Rows[0]["carrier"].ToString();
                if (obj_dt.Rows[0]["jobprofit"].ToString() == "P")
                {
                    CHk_DropFE.Checked = true;
                }
                else
                {
                    CHk_DropFE.Checked = false;





                    if (obj_dt.Rows[0]["lbdate"].ToString().Trim().Length > 0)
                    {
                        txtlbdate.Text = obj_dt.Rows[0]["lbdate"].ToString();
                        //txtlbdate.Text = obj_da_Log1.GetDate();
                        txtlbdate.Text = Convert.ToDateTime(txtlbdate.Text).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txtlbdate.Text = hid_date.Value;

                    }
                    if (obj_dt.Rows[0]["stuffedon"].ToString().Trim().Length > 0)
                    {
                        txt_Stuffedon.Text = obj_dt.Rows[0]["webstuffedon"].ToString();
                    }
                    else
                    {
                        txt_Stuffedon.Text = hid_date.Value;
                    }

                    if (obj_dt.Rows[0]["mblstatus"].ToString() != "S" && obj_dt.Rows[0]["mblstatus"].ToString() != "B")
                    {
                        ddl_mblstatus.SelectedValue = "R";
                    }
                    else
                    {
                        ddl_mblstatus.SelectedValue = obj_dt.Rows[0]["mblstatus"].ToString();
                    }
                    ddl_jobtype.SelectedValue = obj_dt.Rows[0]["jobtype"].ToString();
                    if (obj_dt.Rows[0]["contract"].ToString() != "O")
                    {
                        ddl_Contract.SelectedValue = "A";
                    }
                    else
                    {
                        ddl_Contract.SelectedValue = obj_dt.Rows[0]["contract"].ToString();
                    }


                    Grd_container.DataSource = new DataTable();
                    Grd_container.DataBind();
                    txt_job.Text = "";
                    txt_mbl.Text = "";


                    //  DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                    //for (int i = 1; i <= 6; i++)
                    //{
                    //    obj_dtjob = obj_da_Invoice.CheckIPDCWMBL(txt_mbl.Text, "FE", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["Vouyear"].ToString()), i);
                    //    if (obj_dtjob.Rows.Count > 0)
                    //    {
                    //        txt_mbl.Enabled = false;
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        txt_mbl.Enabled = true;
                    //    }

                    //}
                    //obj_dtjob.Reset();
                    //obj_dtjob = obj_da_jobinfo.getCheckCNDNForaJOb(int.Parse(Session["LoginBranchid"].ToString()), jobno, "FE");
                    //if (obj_dtjob.Rows.Count > 0)
                    //{
                    //    txt_agent.Enabled = false;

                    //}
                   // btn_save.Text = "Save";
                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                    txt_mbl.Focus();

                    //getbookingassigned();

                }

            }
        }
        private void fn_Clear()
        {
            txt_job.Text = "";
            txt_agent.Text = "";
            txt_container.Text = "";
            txt_date.Text = hid_date.Value.ToString();
            txt_eta.Text = hid_date.Value.ToString();
            txt_etd.Text = hid_date.Value.ToString();
            txt_Stuffedon.Text = hid_date.Value.ToString();
            txt_emdate.Text = hid_date.Value.ToString();
            txtlbdate.Text = hid_date.Value.ToString();
            txt_destport.Text = "";
            txt_destport.Text = "";
            txt_em.Text = "";
            txt_loadport.Text = "";
            txt_mbl.Text = "";
            txt_mlo.Text = "";
            txt_pkgs.Text = "";
            txt_remark.Text = "";
            txt_seal.Text = "";
            txt_shptdest.Text = "";
            txt_vessel.Text = "";
            txt_voyage.Text = "";
            txt_wt.Text = "";
            txt_search.Text = "";
            Grd_container.DataSource = null;
            Grd_container.DataBind();
            grd.DataSource = null;
            grd.DataBind();
            ddl_jobtype.ClearSelection();
            txt_mbl.Enabled = true;
            txt_agent.Enabled = true;
            //btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            btn_save.Enabled = true;
            ddl_Contract.SelectedIndex = 0;
            ddl_mblstatus.SelectedIndex = 0;
            CHk_DropFE.Checked = false;
            ddl_size.SelectedIndex = 0;
           // btn_add.Text = "Add";
            btn_add.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn ico-add";
            txt_date1.Enabled = true;
            txt_search.Text = "";
            txtCarrier.Text = "";

        }
        private void fn_ContainerClear()
        {
            txt_container.Text = "";
            txt_pkgs.Text = "";
            txt_seal.Text = "";
            txt_wt.Text = "";
            ddl_size.SelectedIndex = 0;
            ddl_GwType.SelectedIndex = 0;
            ddl_NwType.SelectedIndex = 0;
            txt_netweight.Text = "";
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {

            if (Request.QueryString.ToString().Contains("back"))
            {
                string trantype_process = Session["StrTranType"].ToString();
                DataTable dtuser = new DataTable();

                if (trantype_process == "FE")
                {
                    dtuser = obj_UP.GetFormwiseuserRights(1014, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                    if (dtuser.Rows.Count > 0)
                    {


                        Response.Redirect("../ShipmentDetails/FEBLdetails.aspx");


                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                    }

                }
            }

            if (btn_cancel.ToolTip == "Cancel")
            {

                fn_Clear();
                flagimg.ImageUrl = "";
                podflag.ImageUrl = "";
                BindBooking();
                DataTable dt_new = new DataTable();
                dt_new.Columns.Add("Job #");
                dt_new.Columns.Add("BL #");
                dt_new.Columns.Add("Shipper");
                dt_new.Columns.Add("Consignee");
                dt_new.Columns.Add("20");
                dt_new.Columns.Add("40");
                dt_new.Columns.Add("CBM");

                dt_new.Columns.Add("Gr.Wt.");
                dt_new.Columns.Add("UoM");


                dt_new.Columns.Add("PoL");
                dt_new.Columns.Add("FD");
                dt_new.Columns.Add("OurBL");
                grd.DataSource = dt_new;
                grd.DataBind();

                 btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {

                if (Request.QueryString.ToString().Contains("JobDetails"))
                {
                    Response.Redirect("../Home/OEOpsAndDocs.aspx");
                }
                

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
        public static List<string> FE_GetBookingNo(string prefix, string job)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
            obj_dt = bookingobj.GetBookingnosearch(prefix.Trim().ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()), HttpContext.Current.Session["StrTranType"].ToString());

            //if (job == "")
            //{
            //    obj_dt = bookingobj.GetBookingnosearch(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()), HttpContext.Current.Session["StrTranType"].ToString());
            //    //obj_dt = bookingobj.GetBookingnosearch("T",1,1,"FE");
            //}
            //else
            //{
            //    obj_dt = bookingobj.GetBookingnosearchjob(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()), HttpContext.Current.Session["StrTranType"].ToString(), Convert.ToInt32(job));
            //}
            //obj_dt = bookingobj.GetBookingnosearch(prefix,int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            HttpContext.Current.Session["shiprefno"] = obj_dt;
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "shiprefno");
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
        public static List<string> FEJobInfo_GetVessel(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterVessel da_obj_Vessel = new DataAccess.Masters.MasterVessel();
            obj_dt = da_obj_Vessel.GetLikeVessel(prefix.Trim().ToUpper());
            List_Result = Utility.Fn_DatatableToList(obj_dt, "vesselname", "vesselid");
            return List_Result;
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
        //[WebMethod]
        //public static List<string> FEJobInfo_GetCustomer(string prefix, string FType)
        //{
        //    List<string> List_Result = new List<string>();
        //    DataTable obj_dt = new DataTable();
        //    DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
        //    obj_dt = da_obj_Customer.GetLikeIndianCustomer(prefix.Trim().ToUpper() );
        //    List_Result = Utility.Fn_DatatableToList_Customer(obj_dt, "customer", "customerid");
        //    return List_Result;
        //}

        [WebMethod]
        public static List<string> FEJobInfo_GetCustomer(string prefix, string FType)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_Customer.GetLikeCustomer(prefix.Trim().ToUpper(), FType);
            List_Result = Utility.Fn_DatatableToList_Customer(obj_dt, "customer", "customerid");
            return List_Result;
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

        protected void Grd_container_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_container.Text = HttpUtility.HtmlDecode(Grd_container.SelectedRow.Cells[0].Text);
                hid_ContainerName.Value = Grd_container.SelectedRow.Cells[0].Text;
                ddl_size.SelectedValue = Grd_container.SelectedRow.Cells[1].Text;
                txt_seal.Text = Grd_container.SelectedRow.Cells[2].Text;
                txt_pkgs.Text = Grd_container.SelectedRow.Cells[3].Text;
                txt_wt.Text = Grd_container.SelectedRow.Cells[4].Text;
                txt_date1.Text = Grd_container.SelectedRow.Cells[10].Text;
                if (Grd_container.SelectedRow.Cells[9].Text == "")
                {
                    ddl_GwType.SelectedValue = "0";
                }
                else
                {
                    ddl_GwType.SelectedValue = Grd_container.SelectedRow.Cells[9].Text;
                }
                txt_netweight.Text = Grd_container.SelectedRow.Cells[6].Text;
                ddl_NwType.SelectedValue = Grd_container.SelectedRow.Cells[8].Text;
               // btn_add.Text = "Update";
                btn_add.ToolTip = "Update";
                btn_add1.Attributes["class"] = "btn ico-update";
                //this.PopUpService.Show();                   
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_yes_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_container.Text != "")
                {
                    //ImageButton Img_delete = (ImageButton)e.CommandSource;
                    //GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
                    //DataTable obj_dt = new DataTable();
                    //obj_dt = (DataTable)Session["Container"];

                    DataAccess.ForwardingImports.JobInfo obj_da_FIjobinfo = new DataAccess.ForwardingImports.JobInfo();
                    DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                    if (obj_da_FIjobinfo.CheckContainerNo(int.Parse(txt_job.Text), txt_container.Text, "FE", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString())) != 1)
                    {
                        ScriptManager.RegisterStartupScript(btn_yes, typeof(Button), "JobInfo", "alertify.alert('Container Already Assigned to BL');", true);
                        //Grd_container.Columns[7].Visible = false;
                        //ImageButton Img = (ImageButton)grd.FindControl("Img_Delete");
                        //Img.Visible = false;
                        return;
                    }
                    obj_da_jobinfo.DeleteContDetails(int.Parse(txt_job.Text), txt_container.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 3001, 4, int.Parse(Session["LoginBranchid"].ToString()), "Del Job#-" + txt_job.Text + " /" + txt_container.Text);
                    ScriptManager.RegisterStartupScript(btn_yes, typeof(Button), "JobInfo", "alertify.alert('Container Deleted');", true);
                    //obj_dt.Rows[grd.RowIndex].Delete();                    
                    //obj_dt.AcceptChanges();
                    //Grd_container.DataSource = obj_dt;
                    //Grd_container.DataBind();
                    int int_jobno = int.Parse(txt_job.Text);
                    fn_jobdetails(int_jobno);
                    fn_ContainerClear();
                    //btn_add.Text = "Add";

                    btn_add.ToolTip = "Add";
                    btn_add1.Attributes["class"] = "btn ico-add";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_no_Click(object sender, EventArgs e)
        {
            return;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_container.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btn_add, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Enter the Container Details...');", true);
                    txt_container.Focus();
                    return;
                }
                if (ddl_size.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_add, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please select the Size...');", true);
                    ddl_size.Focus();
                    return;
                }
                if (txt_seal.Text == "")
                {
                    txt_seal.Text = "0";
                }
                if (txt_pkgs.Text == "")
                {
                    txt_pkgs.Text = "0";
                }
                if (txt_wt.Text == "")
                {
                    txt_wt.Text = "0";
                }




                //if (txt_seal.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(btn_add, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Enter the Seal Number...');", true);
                //    txt_seal.Focus();
                //    return;
                //}
                //if (txt_pkgs.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(btn_add, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Enter the Package...');", true);
                //    txt_pkgs.Focus();
                //    return;
                //}
                //if (txt_wt.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(btn_add, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Enter the Weight...');", true);
                //    txt_wt.Focus();
                //    return;
                //}

                if (txt_job.Text.Trim().Length > 0)
                {
                    DataTable obj_dt = new DataTable();
                    DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                    DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                    if (obj_da_Invoice.CheckClosedJobs("FE", int.Parse(txt_job.Text), int.Parse(Session["LoginBranchid"].ToString())) == 1)
                    {
                        ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "JobInfo", "alertify.alert('Job has Closed Already You Can not Update the Job Details.');", true);
                        return;
                    }
                    if (btn_add.ToolTip == "Add")
                    {
                        foreach (GridViewRow row in Grd_container.Rows)
                        {
                            if (row.Cells[0].Text.Trim().ToUpper().ToString() == txt_container.Text.Trim().ToUpper().ToString())
                            {
                                ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "JobInfo", "alertify.alert('Container Already Exists');", true);
                                txt_container.Focus();
                                return;
                            }
                        }
                        obj_da_jobinfo.InsContDetail4job(int.Parse(txt_job.Text.Trim()), txt_container.Text.ToUpper().Trim(), ddl_size.SelectedItem.Text, txt_seal.Text.ToUpper(), txt_job.Text, Convert.ToInt32(txt_pkgs.Text), double.Parse(txt_wt.Text.Trim()), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_date1.Text)), double.Parse(txt_netweight.Text.Trim()), Convert.ToChar(ddl_GwType.SelectedValue), Convert.ToChar(ddl_NwType.SelectedValue));

                        //    obj_da_jobinfo.InsContDetail(int.Parse(txt_job.Text.Trim()), txt_container.Text.ToUpper().Trim(), ddl_size.SelectedItem.Text, txt_seal.Text.ToUpper(), txt_job.Text, Convert.ToInt32(txt_pkgs.Text), double.Parse(txt_wt.Text.Trim()), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_date1.Text)));
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1, 1, int.Parse(Session["LoginBranchid"].ToString()), "Ins Job#-" + txt_job.Text + "  /  " + txt_container.Text);
                        ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "JobInfo", "alertify.alert('Container Saved');", true);
                        fn_ContainerClear();
                    }
                    else
                    {
                        // obj_da_jobinfo.UpdContDetails(int.Parse(txt_job.Text.Trim()), txt_job.Text, txt_container.Text, ddl_size.SelectedItem.Text, txt_seal.Text, hid_ContainerName.Value.ToString(), int.Parse(txt_pkgs.Text.Trim()), double.Parse(txt_wt.Text.Trim()), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1, 2, int.Parse(Session["LoginBranchid"].ToString()), "Ins Job#-" + txt_job.Text + "  /  " + txt_container.Text);
                        obj_da_jobinfo.UpdContDetails4job(int.Parse(txt_job.Text.Trim()), txt_job.Text, txt_container.Text.ToUpper().Trim(), ddl_size.SelectedItem.Text, txt_seal.Text.ToUpper(), hid_ContainerName.Value.ToString(), Convert.ToInt32(txt_pkgs.Text.Trim()), double.Parse(txt_wt.Text.Trim()), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_date1.Text)), double.Parse(txt_netweight.Text.Trim()), Convert.ToChar(ddl_GwType.SelectedValue), Convert.ToChar(ddl_NwType.SelectedValue));

                        
                        //  obj_da_jobinfo.UpdContDetails(int.Parse(txt_job.Text.Trim()), txt_job.Text, txt_container.Text.ToUpper().Trim(), ddl_size.SelectedItem.Text, txt_seal.Text.ToUpper(), hid_ContainerName.Value.ToString(), Convert.ToInt32(txt_pkgs.Text.Trim()), double.Parse(txt_wt.Text.Trim()), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_date1.Text)));
                        ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "JobInfo", "alertify.alert('Container Updated');", true);
                        fn_ContainerClear();
                       // btn_add.Text = "Add";
                        btn_add.ToolTip = "Add";
                        btn_add1.Attributes["class"] = "btn ico-add";
                    }
                    obj_dt = obj_da_jobinfo.GetContainerDetails(int.Parse(txt_job.Text), txt_job.Text.ToString(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

                    Session["Container"] = obj_dt;
                    Grd_container.DataSource = obj_dt;
                    Grd_container.DataBind();

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
            try
            {
                string a = hid_Shipdesportid.Value;
                string b = hid_Destportid.Value;
                string c = hid_Vesselid.Value;
                string d = hid_Loadportid.Value;
                string agent = hid_Agentid.Value;
                string f = hid_Mloid.Value;
                string G = hdnCarrier.Value;
                int count = 0;

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
                txt_vessel_TextChanged1(sender,e);
                txt_loadport_TextChanged(sender,e);
                txt_destport_TextChanged(sender,e);
                txt_shptdest_TextChanged1(sender, e);
                txt_mlo_TextChanged(sender, e);
                txt_agent_TextChanged(sender, e);
                txtCarrier_TextChanged(sender, e);
                if(brr==true)
                {
                    brr = false;
                    return;
                }
                //if (hid_Shipdesportid.Value == "0" || hid_Destportid.Value == "0" || hid_Vesselid.Value == "0" || hid_Loadportid.Value == "0" || hid_Agentid.Value == "0" || hid_Mloid.Value == "0")
                //    return;

                if (txtCarrier.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Enter the correct Carrier Name ');", true);
                    txtCarrier.Focus();
                    return;
                }

                if (agent == "0")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Enter the correct Agent name ');", true);
                    txt_agent.Focus();
                    return;
                }

                if (ddl_Contract.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Select Contract Type');", true);
                    ddl_Contract.Focus();
                    return;
                }
                if (ddl_mblstatus.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Select MBL Status ');", true);
                    ddl_mblstatus.Focus();
                    return;
                }
                //if (ddl_DropFE.SelectedIndex == 0)
                //{
                //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Please Select JobProfit')", true);
                //    ddl_DropFE.Focus();
                //    return;
                //}



                txt_mbl.Text = txt_mbl.Text.Trim();
                if (txt_mbl.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Enter the correct MBL # ');", true);
                    txt_mbl.Focus();
                    return;
                }


                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_Job.SPLikeJobBLno(txt_mbl.Text.ToUpper(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                DataView obj_dtview = new DataView(obj_dt);
                obj_dtview.RowFilter = "blno='" + txt_mbl.Text.ToUpper() + "'";
                obj_dt = obj_dtview.ToTable();
                if (obj_dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(txt_mbl, typeof(TextBox), "BL", "alertify.alert('BL # and MBL # should not Same,kindly change MBL # in Job screen');", true);
                    txt_mbl.Focus();
                    txt_mbl.Text = "";

                    return;
                }

                if (CHk_DropFE.Checked == false)
                {
                    str_status = "O";
                }
                else if (CHk_DropFE.Checked == true)
                {
                    str_status = "P";
                }
                else
                {
                    str_status = "";
                }


                if (ddl_jobtype.SelectedValue.ToString() == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Select Shipment Type');", true);
                    return;
                }
                if (DateTime.Parse(Utility.fn_ConvertDate(txt_eta.Text)) <= DateTime.Parse(Utility.fn_ConvertDate(txt_etd.Text)))
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('ETA Date Should be Greater than ETD Date');", true);
                    txt_eta.Focus();
                    return;
                }
                //if (DateTime.Parse(Utility.fn_ConvertDate(txt_Stuffedon.Text)) > DateTime.Parse(Utility.fn_ConvertDate(txt_etd.Text)))
                //{
                //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('StuffOn Date Should be Less than ETD Date');", true);
                //    txt_Stuffedon.Focus();
                //    return;
                //}
                //if (DateTime.Parse(Utility.fn_ConvertDate(txtlbdate.Text)) > DateTime.Parse(Utility.fn_ConvertDate(txt_Stuffedon.Text)))
                //{
                //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Line Booking Date Should be Less than or Equal to Stuffed On Date');", true);
                //    txtlbdate.Focus();
                //    return;
                //}
                if (DateTime.Parse(Utility.fn_ConvertDate(txt_etd.Text)) <= DateTime.Now.AddDays(-30))
                {
                    if (btn_save.ToolTip == "Save")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Please Enter valid ETD');", true);
                        txt_etd.Focus();
                        return;
                    }
                }
                if (txt_loadport.Text.ToString().ToUpper() == txt_destport.Text.ToString().ToUpper())
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Load and Destination Port Should be Different');", true);
                    txt_destport.Focus();
                    return;
                }

                if (ddl_Contract.Text == "CONTRACT")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Please select Contract Type');", true);
                    ddl_Contract.Focus();
                    return;
                }
                if (ddl_mblstatus.Text == "STATUS")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Please select STATUS Type');", true);
                    ddl_mblstatus.Focus();
                    return;
                }
                //DataTable obj_dt = new DataTable();
                DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                int intBooking;
              
                blnMBL = false;
                CheckMBL();
                if (blnMBL == true)
                {
                    blnMBL = false;
                    return;
                }

                branchid = Convert.ToInt32(Session["LoginBranchid"]);
                if (btn_save.ToolTip == "Save")
                {
                    txt_job.Text = "";
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



                    txt_job.Text = obj_da_jobinfo.InsertJoboinfo(Convert.ToInt32(hid_Vesselid.Value.ToString()), Convert.ToInt32(hid_Loadportid.Value.ToString()), Convert.ToInt32(hid_Destportid.Value.ToString()), txt_em.Text.ToUpper(), txt_voyage.Text, DateTime.Parse(Utility.fn_ConvertDatetime(txt_etd.Text).ToString()), DateTime.Parse(Utility.fn_ConvertDatetime(txt_eta.Text).ToString()), DateTime.Parse(Utility.fn_ConvertDatetime(txt_emdate.Text).ToString()), int.Parse(hid_Shipdesportid.Value.ToString()), int.Parse(hid_Mloid.Value.ToString()), int.Parse(hid_Agentid.Value.ToString()), txt_mbl.Text.Trim().ToUpper(), int.Parse(ddl_jobtype.SelectedValue.ToString()), DateTime.Parse(Utility.fn_ConvertDatetime(txt_date.Text).ToString()), char.Parse(ddl_Contract.SelectedValue.ToString()), int.Parse(Session["LoginBranchid"].ToString()), DateTime.Parse(Utility.fn_ConvertDatetime(txt_Stuffedon.Text).ToString()), ddl_mblstatus.SelectedValue.ToString(), int.Parse(Session["LoginEmpId"].ToString()), txt_remark.Text.ToUpper(), int.Parse(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtlbdate.Text))).ToString();
                    obj_da_jobinfo.updjobinfoprofit("FE", Convert.ToInt32(txt_job.Text), branchid, str_status, Convert.ToInt32(hdnCarrier.Value));
                    //obj_da_jobinfo.UpdateTaskEvent(txt_search.Text.ToString(), HttpContext.Current.Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()),Convert.ToInt32( Session["LoginEmpId"].ToString()),2);
                    DataAccess.Reportasp objRpt = new DataAccess.Reportasp();

                    objRpt.InsOEeventdetailsTask(Convert.ToInt32(txt_job.Text), txt_search.Text.ToString(), "", "Job Updation",
                   Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(),0,"",24);
                    //Convert.ToInt32(txt_job.Text),txt_search.Text.ToString(),


                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_job.Text + " /Save");


                    if (txt_job.Text != "")
                    {

                        if (grdBookJob.Rows.Count > 0)
                        {
                            for (int i = 0; i <= grdBookJob.Rows.Count - 1; i++)
                            {
                                CheckBox chkRow = (grdBookJob.Rows[i].Cells[3].FindControl("ChkMail") as CheckBox);
                                if (chkRow.Checked == true)
                                {
                                    intBooking = Convert.ToInt32(grdBookJob.Rows[i].Cells[0].Text);
                                    book.UpdJobInComBooking(intBooking, Convert.ToInt32(txt_job.Text), "FE", branchid, 2);
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
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid Jobno');", true);
                        return;
                    }
                  //  obj_da_Log1.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 3001, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text + "/Save");
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Details Saved, Job # is " + txt_job.Text + ", Please Update Containers ');", true);
                    //fn_Clear();
                    fn_Sendmail();
                    //btn_save.Text = "Update";

                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                    txt_container.Focus();
                }
                else if (btn_save.ToolTip == "Update")
                {
                    branchid = Convert.ToInt32(Session["LoginBranchid"]);
                    if (obj_da_Invoice.CheckClosedJobs("FE", Convert.ToInt32(txt_job.Text), Convert.ToInt32(Session["LoginBranchid"].ToString())) == 1)
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Job has Closed Already You Can not Update the Job Details.');", true);
                        return;
                    }
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
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert(' Booking Number empty');", true);
                        count = 1;

                    }


                    if (count == 0)
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select Booking Number');", true);
                        count = 0;
                        return;
                    }
                    if (txtCarrier.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Enter the correct Carrier Name ');", true);
                        txtCarrier.Focus();
                        return;
                    }

                    DateTime d1 = Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_eta.Text));

                    obj_da_jobinfo.UpdateFEJobInfo(Convert.ToInt32(hid_Vesselid.Value.ToString()), Convert.ToInt32(hid_Loadportid.Value.ToString()), Convert.ToInt32(hid_Destportid.Value.ToString()), txt_em.Text.ToUpper(), txt_voyage.Text, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_etd.Text).ToString()), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_eta.Text).ToString()), DateTime.Parse(Utility.fn_ConvertDatetime(txt_emdate.Text).ToString()), int.Parse(hid_Shipdesportid.Value.ToString()), int.Parse(hid_Mloid.Value.ToString()), int.Parse(hid_Agentid.Value.ToString()), txt_mbl.Text.Trim().ToUpper(), int.Parse(ddl_jobtype.SelectedValue.ToString()), int.Parse(txt_job.Text), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_date.Text).ToString()), char.Parse(ddl_Contract.SelectedValue.ToString()), int.Parse(Session["LoginBranchid"].ToString()), DateTime.Parse(Utility.fn_ConvertDatetime(txt_Stuffedon.Text).ToString()), ddl_mblstatus.SelectedValue.ToString(), txt_remark.Text.ToUpper(), int.Parse(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDatetime(txtlbdate.Text)));
                    obj_da_jobinfo.updjobinfoprofit("FE", Convert.ToInt32(txt_job.Text), Convert.ToInt32(Session["LoginBranchid"]), str_status, Convert.ToInt32(hdnCarrier.Value));

                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_job.Text + " /Upd");


                    if (txt_job.Text != "")
                    {


                        if (grdBookJob.Rows.Count > 0)
                        {
                            for (int i = 0; i <= grdBookJob.Rows.Count - 1; i++)
                            {
                                CheckBox chkRow = (grdBookJob.Rows[i].Cells[3].FindControl("ChkMail") as CheckBox);
                                if (chkRow.Checked == true)
                                {
                                    intBooking = Convert.ToInt32(grdBookJob.Rows[i].Cells[0].Text);
                                    book.UpdJobInComBooking(intBooking, Convert.ToInt32(txt_job.Text), "FE", branchid, 2);
                                }
                                else if (chkRow.Checked == false)
                                {
                                    intBooking = Convert.ToInt32(grdBookJob.Rows[i].Cells[0].Text);
                                    book.UpdJobInComBooking(intBooking, 0, "FE", branchid, 2);
                                }
                            }
                            //ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Booking Details Updated');", true);
                            getbookingassigned();
                            BindBooking();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Invalid Jobno');", true);
                        return;
                    }
                    obj_da_Log1.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 3001, 2, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text + "/Upd");
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "JobInfo", "alertify.alert('Details Updated, Job # is " + txt_job.Text + "');", true);
                    fn_Clear();
                   // btn_save.Text = "Save";

                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                    txt_job.Focus();
                }
                UserRights();
                btn_save.Enabled = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        protected void btn_search_Click(object sender, EventArgs e)
        {
            //DataTable obj_dt = new DataTable();
            //if (txt_search.Text != "")
            //{

            //    if (Session["shiprefno123"] != null)
            //    {
            //        obj_dt = (DataTable)Session["shiprefno123"];
            //        //ViewState["data"] = obj_dtEmp;
            //        grdBookJob.DataSource = obj_dt;
            //        grdBookJob.DataBind();
            //        Session["shiprefno123"] = obj_dt;
            //    }

            //   ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);

            //}
            //else
            //{
            //    if (txt_job.Text == "")
            //    {
            //        obj_dt = book.GetBookingnosearch(txt_search.Text, int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()), HttpContext.Current.Session["StrTranType"].ToString());
            //        //obj_dt = bookingobj.GetBookingnosearch("T",1,1,"FE");
            //    }
            //    else
            //    {
            //        obj_dt = book.GetBookingnosearchjob(txt_search.Text, int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()), HttpContext.Current.Session["StrTranType"].ToString(), Convert.ToInt32(txt_job.Text));
            //    }

            //    grdBookJob.DataSource = obj_dt;
            //    grdBookJob.DataBind();
            //}
            ////getbookingassigned();
            ////getallsearchvaluesbook();
            ////get_Value();
            //txt_search.Focus();
        }


        protected void txt_job_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_date1.Enabled = true;
                txt_date.Enabled = false;
                if (txt_job.Text.Trim().Length > 0)
                {
                    fn_jobdetails(int.Parse(txt_job.Text.ToString()));
                    getbldetais();
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
            UserRights();
        }

        private void fn_Sendmail()
        {
            string Str_Content = "";
            Str_Content = Str_Content + "<body text=darkblue><table width=100%><FONT FACE=tahoma ><tr><td align=left>New Job " + txt_job.Text + " has created in Ocean Exports. Please find below details</td></tr></table><br>";
            Str_Content = Str_Content + "<table><tr><td align=left>Job # : " + txt_job.Text + "   </td><td align=left>Vessel Vs Voyage : " + txt_vessel.Text + " Vs " + txt_voyage.Text + "   " + "   </td><td align=left colspan=2>MBL # : " + txt_mbl.Text + "</td></tr><br>";
            Str_Content = Str_Content + "<tr><td align=left>PoL : " + txt_loadport.Text + "   " + "   </td><td align=left>ETD : " + txt_etd.Text + "   </td><td align=left>PoD : " + txt_destport.Text + "   " + "   </td><td align=left>ETA : " + txt_eta.Text + "</td></tr><br>";
            Str_Content = Str_Content + "<tr><td align=left colspan=4>Agent : " + txt_agent.Text + "   </td></tr><br>";
            Str_Content = Str_Content + "<tr><td align=left colspan=4>Carrier / Forwarder # : " + txt_mlo.Text + "</td></tr></table>";
            Str_Content = Str_Content + "<table BORDER=2 BORDERCOLOR=#336699 CELLPADDING=2 CELLSPACING=0 WIDTH=100% text=black><tr><td align=center>Container # </td><td align=center>Sizetype</td><td align=center>Seal #</td><td align=center>Pkgs</td><td align=center>Weight</td></tr><br>";
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
            DataAccess.UserPermission obj_da_User = new DataAccess.UserPermission();
            DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
            obj_dt = obj_da_jobinfo.GetContainerDetails(int.Parse(txt_job.Text), txt_job.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
            {
                Str_Content = Str_Content + "<tr><td align=left>" + obj_dt.Rows[i][0].ToString() + "</td><td align=left>" + obj_dt.Rows[i][1].ToString() + "</td><td align=left>" + obj_dt.Rows[i][2].ToString() + "</td><td align=left>" + obj_dt.Rows[i][3].ToString() + "</td><td align=left>" + obj_dt.Rows[i][4].ToString() + "</td></tr>";
            }
            Str_Content = Str_Content + "</table><br>";
            Str_Content = Str_Content + "</table><table width=100% text=darkblue><tr><td align=left>Best Regards </td></tr></table><br><br><br>";
            Str_Content = Str_Content + "<table width=100% text=black><tr><td align=left>" + Session["LoginEmpName"].ToString() + " </td></tr></table></body></html>";

            int int_uiid = obj_da_User.GetMLUiid("FE", "Job Info");
            string Str_emailid = "";
            obj_dt = obj_da_User.GetMLEmpid(int_uiid, int.Parse(Session["LoginBranchid"].ToString()));
            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
            {
                Str_emailid = Str_emailid + obj_da_Employee.GetMailAdd(int.Parse(obj_dt.Rows[i]["empid"].ToString())) + ";";
            }
            if (Str_emailid.Trim().Length > 0)
            {
                Str_emailid = Str_emailid.Substring(0, Str_emailid.Length - 1);
                Utility.SendMail(Session["usermailid"].ToString(), Str_emailid, "New Job " + txt_job.Text + " has created in Ocean Exports", Str_Content, "", Session["usermailpwd"].ToString());
            }
        }

        protected void Grd_container_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    ImageButton Img_delete = (ImageButton)e.CommandSource;
                    GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
                    DataTable obj_dt = new DataTable();
                    obj_dt = (DataTable)Session["Container"];

                    DataAccess.ForwardingImports.JobInfo obj_da_FIjobinfo = new DataAccess.ForwardingImports.JobInfo();
                    DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                    if (obj_da_FIjobinfo.CheckContainerNo(int.Parse(txt_job.Text), Grd_container.Rows[grd.RowIndex].Cells[0].Text, "FE", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString())) != 1)
                    {
                        ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('Container Already Assigned to BL');", true);
                        //Grd_container.Columns[7].Visible = false;
                        //ImageButton Img = (ImageButton)grd.FindControl("Img_Delete");
                        //Img.Visible = false;
                        return;
                    }
                    obj_da_jobinfo.DeleteContDetails(int.Parse(txt_job.Text), Grd_container.Rows[grd.RowIndex].Cells[0].Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1, 4, int.Parse(Session["LoginBranchid"].ToString()), "Del Job#-" + txt_job.Text + " /" + obj_dt.Rows[grd.RowIndex]["containerno"].ToString());
                    ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('Container Deleted');", true);
                    obj_dt.Rows[grd.RowIndex].Delete();
                    obj_dt.AcceptChanges();

                    Grd_container.DataSource = obj_dt;
                    Grd_container.DataBind();
                    Session["Container"] = obj_dt;
                    fn_ContainerClear();
                    //btn_add.Text = "Add";
                    btn_add.ToolTip = "Add";
                    btn_add1.Attributes["class"] = "btn ico-add";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_container_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Grd_container_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    //e.Row.Cells[i].Text = HttpUtility.HtmlDecode(e.Row.Cells[i].Text);
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_container, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }

        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";

                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                if (txt_job.Text.Trim().Length > 0)
                {
                   str_RptName = "FEexports.rpt";
                     Session["str_sfs"] = "{FEJobInfo.bid}=" + Session["LoginBranchid"].ToString() + " and {FEJobInfo.jobno}=" + txt_job.Text;
                    // str_sf = "{FEJobInfo.bid}=" + Session["LoginBranchid"].ToString() + " and {FEJobInfo.jobno}=" + txt_job.Text;
                     str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                       Session["str_sp"] = str_sp;
                     
                   //str_Script = "window.open('../Reportasp/feexportsrpt.aspx?jobno=" + txt_job.Text + "&" + this.Page.ClientQueryString + "','','');";
                  

                   
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "JobInfo", str_Script, true);
                    obj_da_Log1.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1, 4, Convert.ToInt32(Session["LoginBranchid"]), "FE-JobRegVew");
               //     Session["str_sfs"] = str_sf;
                   
                }
                else
                {
                    str_RptName = "FEJobInfo.rpt";
                    Session["str_sfs"] = "{FEJobInfo.bid}=" + Session["LoginBranchid"].ToString();
                    //str_sf = "{FEJobInfo.bid}=" + Session["LoginBranchid"].ToString();
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                   
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "JobInfo", str_Script, true);
                    obj_da_Log1.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1, 4, Convert.ToInt32(Session["LoginBranchid"]), "FE-JobVew");
                   // Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_mbl_Click(object sender, EventArgs e)
        {
            try
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";

                if (txt_job.Text.Trim().Length > 0)
                {
                    str_RptName = "FEMBLAnnuxure.rpt";
                    str_sf = "{FEJobInfo.jobno}=" + txt_job.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_mbl, typeof(Button), "JobInfo", str_Script, true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Vessel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                popup_Grd.Hide();
                txt_vessel.Text = Grd_Vessel.SelectedRow.Cells[0].Text;
                txt_voyage.Text = Grd_Vessel.SelectedRow.Cells[1].Text;
                txt_loadport.Text = Grd_Vessel.SelectedRow.Cells[2].Text;
                txt_destport.Text = Grd_Vessel.SelectedRow.Cells[3].Text;
                if (Grd_Vessel.SelectedRow.Cells[4].Text.Trim().Length > 0)
                {
                    txt_etd.Text = Grd_Vessel.SelectedRow.Cells[4].Text;
                }
                else
                {
                    txt_etd.Text = hid_date.Value.ToString();
                }
                if (Grd_Vessel.SelectedRow.Cells[5].Text.Trim().Length > 0)
                {
                    txt_eta.Text = Grd_Vessel.SelectedRow.Cells[5].Text;
                }
                else
                {
                    txt_eta.Text = hid_date.Value.ToString();
                }
                hid_Vesselid.Value = Grd_Vessel.SelectedDataKey.Values[0].ToString();
                hid_Loadportid.Value = Grd_Vessel.SelectedDataKey.Values[1].ToString();
                hid_Destportid.Value = Grd_Vessel.SelectedDataKey.Values[2].ToString();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_vessel_Click(object sender, EventArgs e)
        {
            try
            {
                Grd_Job.Visible = false;
                Grd_Vessel.Visible = true;
                DataTable obj_dt = new DataTable();
                DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                // obj_dt = obj_da_jobinfo.GetVslfromSS4web();
                obj_dt = obj_da_jobinfo.GetVslfromSS();

                if (obj_dt.Rows.Count > 0)
                {
                    popup_Grd.Show();
                    Grd_Vessel.DataSource = obj_dt;
                    Grd_Vessel.DataBind();
                }
                if (obj_dt.Rows.Count <= 0)
                {
                    //ScriptManager.RegisterStartupScript(lnk_vessel, typeof(LinkButton), "JobInfo", "alertify.alert('Vessel Not Available');", true);
                    return;
                }
                //else
                //{
                //    popup_Grd.Show();
                //    Grd_Vessel.DataSource = new DataTable();
                //    Grd_Vessel.DataBind();
                //}
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_container_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grd_container.PageIndex = e.NewPageIndex;
                DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                DataTable obj_dt = new DataTable();

                obj_dt = obj_da_jobinfo.GetContainerDetails(int.Parse(txt_job.Text), txt_job.Text.ToString(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

                Session["Container"] = obj_dt;
                Grd_container.DataSource = obj_dt;
                Grd_container.DataBind();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Job_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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
                    Label lblCustomer = (Label)e.Row.FindControl("mlo");
                    string tooltip = lblCustomer.Text;
                    e.Row.Cells[8].Attributes.Add("title", tooltip);
                    Label lblCustomer1 = (Label)e.Row.FindControl("vessel");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[2].Attributes.Add("title", tooltip1);

                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Job, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }



        protected void Grd_Vessel_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Vessel, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_destport_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
                DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
                int port = da_obj_Port.GetNPortid(txt_destport.Text.ToUpper());
               /* if (port != 0 && hid_Destportid.Value!="0")
                {
                    hid_Destportid.Value = port.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid DESTINATION PORT Name');", true);
                    txt_destport.Focus();
                    txt_destport.Text = "";
                    brr = true;
                    return;
                }*/
                if (da_obj_Port.GetNPortid(txt_destport.Text.ToUpper()) == 0 || hid_Destportid.Value=="0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid DESTINATION PORT Name');", true);
                    txt_destport.Text = "";
                    txt_destport.Focus();
                    brr = true;
                    return;
                }
                else
                {
                    DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                    obj_dt = obj_MasterPort.SelPortName4typepadimg(txt_destport.Text.ToUpper(), Session["StrTranType"].ToString());
                    podflag.ImageUrl = "../LOGO/" + obj_dt.Rows[0]["countrycode"] + ".svg";
                    txt_shptdest.Focus();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_vessel_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
                DataAccess.Masters.MasterVessel da_obj_Vessel = new DataAccess.Masters.MasterVessel();
                int vesselid = da_obj_Vessel.GetVesselid(txt_vessel.Text.ToUpper());

               /* if (vesselid != 0 && hid_Vesselid.Value!="0")
                {
                    hid_Vesselid.Value = vesselid.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Vessel Name');", true);
                    txt_vessel.Focus();
                    txt_vessel.Text = "";
                    brr = true;
                    return;
                }*/
                if (da_obj_Vessel.GetVesselid(txt_vessel.Text.ToUpper()) == 0 || hid_Vesselid.Value=="0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Vessel Name');", true);
                    txt_vessel.Text = "";
                    txt_vessel.Focus();
                    brr = true;
                    return;
                }
                else
                {
                    txt_voyage.Focus();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            UserRights();
        }

        protected void txt_loadport_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
                DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
                int port = da_obj_Port.GetNPortid(txt_loadport.Text.ToUpper());
               /* if (port != 0 && hid_Loadportid.Value!="0")
                {
                    hid_Loadportid.Value = port.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid LOAD PORT Name');", true);
                    txt_loadport.Focus();
                    txt_loadport.Text = "";
                    brr = true;
                    return;
                }*/
                if (da_obj_Port.GetNPortid(txt_loadport.Text.ToUpper()) == 0 || hid_Loadportid.Value=="0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid LOAD PORT Name');", true);
                    txt_loadport.Text = "";
                    txt_loadport.Focus();
                    brr = true;
                    return;
                }
                else
                {
                    DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                    obj_dt = obj_MasterPort.SelPortName4typepadimg(txt_loadport.Text.ToUpper(), Session["StrTranType"].ToString());
                    flagimg.ImageUrl = "../LOGO/" + obj_dt.Rows[0]["countrycode"] + ".svg";
                    txt_destport.Focus();
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_shptdest_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
                DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
                int port = da_obj_Port.GetNPortid(txt_shptdest.Text.ToUpper());
                /*if (port != 0 && hid_Shipdesportid.Value!="0")
                {
                    hid_Shipdesportid.Value = port.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid SHIPMENT DESTINATION');", true);
                    txt_shptdest.Focus();
                    txt_shptdest.Text = "";
                    brr = true;
                    return;
                }*/


                if (da_obj_Port.GetNPortid(txt_shptdest.Text.ToUpper()) == 0 || hid_Shipdesportid.Value == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid SHIPMENT DESTINATION');", true);
                    txt_shptdest.Text = "";
                    txt_shptdest.Focus();
                    brr = true;
                    return;
                }
                else
                {
                    DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                    obj_dt = obj_MasterPort.SelPortName4typepadimg(txt_shptdest.Text.ToUpper(), Session["StrTranType"].ToString());
                    fdflag.ImageUrl = "../LOGO/" + obj_dt.Rows[0]["countrycode"] + ".svg";
                    txt_em.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_mlo_TextChanged(object sender, EventArgs e)
        {

            //List<string> List_Result = new List<string>();
            //DataTable obj_dt = new DataTable();
            //DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            //obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper(), FType);
            //List_Result = Utility.Fn_DatatableToList_Customer(obj_dt, "customername", "customerid");
            //return List_Result;
            try
            {
                DataTable obj_dt = new DataTable();
                DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                //int customerid = da_obj_Customer.GetCustomerid(txt_mlo.Text.ToUpper());//(txt_mlo.Text.ToUpper(), "L");
                obj_dt = da_obj_Customer.GetexactCustomer(txt_mlo.Text.ToUpper(),"L");
               // if (customerid != 0)
                if (obj_dt.Rows.Count > 0 && hid_Mloid.Value!="0")
                {
                    //hid_Mloid.Value = customerid.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid MLO Name');", true);
                    txt_mlo.Focus();
                    txt_mlo.Text = "";
                    brr = true;
                    return;
                    
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
            try
            {
                DataTable obj_dt = new DataTable();
                DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                //int customerid = da_obj_Customer.GetCustomerid(txt_agent.Text.ToUpper());
                //if (customerid != 0)
                obj_dt = da_obj_Customer.GetexactCustomer(txt_agent.Text.ToUpper(), "P");
                if (obj_dt.Rows.Count > 0 && hid_Agentid.Value!="0")
                {
                   // hid_Agentid.Value = customerid.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Agent Name');", true);
                    txt_agent.Focus();
                    txt_agent.Text = "";
                    brr = true;
                    return;
                    //txt_agent.SelectionStart = txt_agent.Text.Length;
                    //this.Page.SetFocus(txt_agent.ClientID);
                    //txt_agent.Text = selectedItemText;
                    //txt_agent.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
        }

        protected void btnupdateBook_Click(object sender, EventArgs e)
        {

        }

        private void getbookingassigned()
        {
            branchid = Convert.ToInt32(Session["LoginBranchid"]);

            DataTable dtbk1;
            if(txt_job.Text !="")
            {
                dtbk1 = book.SELBookingDtlsByJobnew("FE", branchid, Convert.ToInt32(txt_job.Text));
                if (dtbk1.Rows.Count > 0)
                {
                    grdBookJob.DataSource = dtbk1;
                    grdBookJob.DataBind();
                    // ViewState["grdBookJob"] = dtbk1;
                    Session["shiprefno"] = dtbk1;
                }

                getallsearchvaluesbook();
            }
            
        }

        private void BindBooking()
        {

            //Session["shiprefno"] = null;

            if (txt_job.Text != "")
            {
                dtbk = book.SELBookingDtlsByJob("FE", branchid, Convert.ToInt32(txt_job.Text));


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
                //dtbk = book.GETBookingNoJobInfo(branchid, "FE");
                dtbk = book.GETBookingNoJobInfo4task(branchid, "FE", Convert.ToInt32(Session["LoginEmpId"]));
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

        protected void grdBookJob_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBookJob.PageIndex = e.NewPageIndex;
            BindBooking();
        }

        protected void Grd_Job_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grd_Job.PageIndex = e.NewPageIndex;
                loadgrid();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_voyage_TextChanged(object sender, EventArgs e)
        {
            UserRights();
        }

        protected void get_Value()
        {
            DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
            if (txt_job.Text == "")
            {
                obj_dt = bookingobj.GetBookingnosearch(txt_search.Text, int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()), HttpContext.Current.Session["StrTranType"].ToString());
            }
            else
            {
                obj_dt = bookingobj.GetBookingnosearchjob(txt_search.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString(), Convert.ToInt32(txt_job.Text));

            }
            if (obj_dt.Rows.Count > 0)
            {
                obj_dt.Columns.Add("jobno");
                grdBookJob.DataSource = obj_dt;
                grdBookJob.DataBind();
                //= obj_dt;
                //Session["shiprefno"] = obj_dt;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Booking #');", true);
                txt_search.Focus();
                txt_search.Text = "";
            }



        }

        //protected void txt_search_TextChanged(object sender, EventArgs e)
        //{

        //  if (ViewState["grdBookJob"] != null)
        //       {

        //           obj_dt = (DataTable)ViewState["grdBookJob"];
        //       DataView dvobj = new DataView(obj_dt);
        //       dvobj.RowFilter = string.Format("shiprefno LIKE'{0}%'", txt_search.Text);
        //       grdBookJob.DataSource = dvobj;
        //       grdBookJob.DataBind();
        //       get_Value();
        //       getallsearchvaluesbook();
        //       }
        //}

        public void getallsearchvaluesbook()
        {
            if (txt_job.Text != "")
            {
                branchid = Convert.ToInt32(Session["LoginBranchid"]);

                dtbk = book.SELBookingDtlsByJob("FE", branchid, Convert.ToInt32(txt_job.Text));


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


        public void CheckMBL()
        {
            DataTable Dt;
            if (txt_mbl.Text.ToUpper().Trim() != "")
            {
                Dt = obj_da_Invoice.CheckMblno((txt_mbl.Text.ToUpper()).Trim(), "FE", Convert.ToInt32(Session["LoginBranchid"]));
                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        if (txt_job.Text.Trim() != "")
                        {
                            if (Dt.Rows[i][0].ToString() != txt_job.Text)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('MBL # Already Exists');", true);
                                txt_mbl.Focus();
                                blnMBL = true;
                                return;
                            }

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('MBL # Already Exists');", true);
                            txt_mbl.Focus();
                            blnMBL = true;
                            return;
                        }

                    }
                }
                if (obj_da_Log1.CheckMBLNOWithHBL("FE", (txt_mbl.Text).Trim(), Convert.ToInt32(Session["LoginBranchid"])) != 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid MBL #');", true);
                    txt_mbl.Focus();
                    blnMBL = true;
                    return;
                }
                DataAccess.ForwardingExports.BLDetails objbl = new DataAccess.ForwardingExports.BLDetails();
                DataTable dtbook = new DataTable();
                dtbook = objbl.getsp_getbookingno(txt_mbl.Text.ToUpper(), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (dtbook.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('MBL# and Booking# is same');", true);
                    txt_mbl.Text = "";
                    txt_mbl.Focus();
                    blnMBL = true;
                    return;
                }
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

        protected void txtCarrier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] carriertxt = txtCarrier.Text.Split(',');
                DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
                // obj_dt = da_obj_customerobj.GetLikeCustomer4Carrier(txtCarrier.Text);

                //  int txtcarrierid = da_obj_customerobj.GetCustomerid(carriertxt[0].Trim().ToUpper());
                //if (hdnCarrier.Value != "0")
                 obj_dt = da_obj_customerobj.GetExactCustomer4Carrier(txtCarrier.Text.ToUpper());
                 if (obj_dt.Rows.Count > 0 && hdnCarrier.Value!="0")
                
                {
                    ddl_Contract.Focus();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Carrier');", true);
                    txtCarrier.Text = "";
                    txtCarrier.Focus();
                    brr = true;
                    return;
                    
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void CHk_DropFE_CheckedChanged(object sender, EventArgs e)
        {
            if (CHk_DropFE.Checked == false)
            {
                str_status = "O";
            }
            else if (CHk_DropFE.Checked == true)
            {
                str_status = "P";
            }
            else
            {
                str_status = "";
            }
        }

        protected void grdBookJob_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    if (txt_mbl.Text != "")
                    {
                        string mblno = txt_mbl.Text;
                        //Response.Redirect("../ForwardExports/CostingDetails.aspx");
                        string app1 = "Proforma Sales Invoice";
                        Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app1 + "&mblno=" + mblno);
                    }
                    else
                    {
                        string message = "Enter the Job No";
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

                    string app1 = "Proforma Sales Invoice";
                    Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app1 );


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

                    string app1 = "Proforma Sales Invoice";
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

                    string app1 = "Proforma Sales Invoice";
                    Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app1 );


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
                    if (txt_mbl.Text != "")
                    {
                        string mblno = txt_mbl.Text;
                        string app2 = "Profoma Purchase Invoice";
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

                    string app2 = "Profoma Purchase Invoice";
                    Response.Redirect("../Accounts/ProformaLV.aspx?app1=" + app2);
                    
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
                    string app2 = "Profoma Purchase Invoice";
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

                    string app2 = "Profoma Purchase Invoice";
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


        protected void Btn_reuse_Click(object sender, EventArgs e)
        {
            
            GrdReuse.Visible = true;
            Grd_Job.Visible = false;
            DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_jobinfo.GetJobNoList(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
            if (obj_dt.Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(Btn_reuse, typeof(LinkButton), "JobInfo", "alertify.alert('Your Reuse Job is Not Available');", true);
                return;
            }
            else
            {
                popup_Grd.Show();
                GrdReuse.DataSource = obj_dt;
                GrdReuse.DataBind();
                txt_date1.Enabled = true;
            }
        }

        protected void ChkMail_CheckedChanged(object sender, EventArgs e)
        {
            int count = 0;
            //int index = grdBookJob.SelectedRow.RowIndex;
            CheckBox chk = (CheckBox)sender;
            GridViewRow gr = (GridViewRow)chk.Parent.Parent;
            if (txt_loadport.Text == "" && txt_destport.Text == "")
            {

                book_select = grdBookJob.DataKeys[gr.RowIndex].Value.ToString();
                if (chk.Checked == true)
                {
                    Booking_fill();
                }
                else
                {
                    fn_Clear();
                }
                //book_select = grdBookJob.Rows[index].Cells[1].Text;

                for (int i = 0; i < grdBookJob.Rows.Count; i++)
                {
                    CheckBox chkRowtest = (grdBookJob.Rows[i].Cells[3].FindControl("ChkMail") as CheckBox);
                    if (chkRowtest.Checked == true)
                    {
                        count = 1;
                    }
                }
                if (count == 0)
                {
                    fn_Clear();
                    //btn_cancel_Click(sender,e);
                }
            }
            else
            {
                for (int i = 0; i < grdBookJob.Rows.Count; i++)
                {
                    CheckBox chkRowtest = (grdBookJob.Rows[i].Cells[3].FindControl("ChkMail") as CheckBox);
                    if (chkRowtest.Checked == true)
                    {
                        count = 1;
                    }
                }
                if (count == 0)
                {
                    if (chk.Checked == false)
                    {
                        fn_Clear();
                    }
                }

            }

        }

        protected void GrdReuse_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grd_Job.PageIndex = e.NewPageIndex;
                        Btn_reuse_Click(sender, e);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void GrdReuse_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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
                    Label lblCustomer = (Label)e.Row.FindControl("mlo");
                    string tooltip = lblCustomer.Text;
                    e.Row.Cells[8].Attributes.Add("title", tooltip);
                    Label lblCustomer1 = (Label)e.Row.FindControl("vessel");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[2].Attributes.Add("title", tooltip1);

                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdReuse, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void GrdReuse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                popup_Grd.Hide();             
                int index = Convert.ToInt32(GrdReuse.SelectedRow.RowIndex);
                int int_jobno = Convert.ToInt32(((Label)GrdReuse.Rows[index].Cells[0].FindControl("Job")).Text);
                 fn_jobdetailsReuse(int_jobno);
                 getblno();
                UserRights();
            
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Proosdncn_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1015, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_job.Text != "")
                    {
                        string jobno = txt_job.Text;
                        string app3 = "OSSI";
                        //Response.Redirect("../Accounts/ProfomaInvoice.aspx?app1=" + app2);
                        Response.Redirect("../Accounts/ProOSV.aspx?app3=" + app3 + "&jobno=" + jobno);
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
        //muthu
        public void getbldetais()
        {
            DataAccess.ForwardingExports.BLDetails da_obj_FEblobj = new DataAccess.ForwardingExports.BLDetails();
            DataTable dt_new;
            if (txt_job.Text.ToString() != "")
            {
                dt_new = da_obj_FEblobj.ShowFEInfonew(Convert.ToInt32(txt_job.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (dt_new.Rows.Count > 0)
                {
                    hid_type.Value = dt_new.Rows[0]["ourbl"].ToString();
                   if(grd.Rows.Count>0)
                   {
                       grd.DataSource = null;
                       grd.DataBind();
                   }
                   else
                   {
                       grd.DataSource = dt_new;
                       grd.DataBind();
                   }
                   
                    if (grd.Rows.Count > 0)
                    {
                        grd.HeaderRow.Cells[0].Text = "Job #";
                        grd.HeaderRow.Cells[1].Text = "BL #";
                        grd.HeaderRow.Cells[2].Text = "Shipper";
                        grd.HeaderRow.Cells[3].Text = "Consignee";
                        grd.HeaderRow.Cells[4].Text = "20";
                        grd.HeaderRow.Cells[5].Text = "40";
                        grd.HeaderRow.Cells[6].Text = "CBM";

                        grd.HeaderRow.Cells[7].Text = "Gr.Wt.";
                        grd.HeaderRow.Cells[8].Text = "Pkgs";
                        grd.HeaderRow.Cells[9].Text = "Pkgs";

                        grd.HeaderRow.Cells[10].Text = "PoL";
                        grd.HeaderRow.Cells[11].Text = "FD";
                        grd.HeaderRow.Cells[12].Text = "OurBL";


                    }
                    else
                    {
                      
                    }
                }
                else
                {
                    grd.DataSource = null;
                    grd.DataBind();
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

        protected void btn_Vessel_Click(object sender, EventArgs e)
        {
            if (txt_job.Text != "")
            {
                DataTable dt = new DataTable();

                // Add columns to the DataTable
                dt.Columns.Add("Bookingno", typeof(string));
                for (int i = 0; i < grdBookJob.Rows.Count; i++)
                {
                    CheckBox chkRow = (grdBookJob.Rows[i].Cells[6].FindControl("ChkMail") as CheckBox);

                    CheckBox cbox = (CheckBox)grdBookJob.Rows[i].FindControl("ChkMail");

                    if (chkRow.Checked == true)
                    {

                        string bookingno = grdBookJob.Rows[i].Cells[1].Text;
                        DataRow row = dt.NewRow();
                        row["Bookingno"] = bookingno;
                        dt.Rows.Add(row);

                    }
                }

                HttpContext.Current.Session["BookingNo"] = dt;


                string vouy = txt_vessel.Text + " .V " + txt_voyage.Text;


                iframe_outstd.Attributes["src"] = "../CRM/MotherVesselDetail.aspx?&jobno=" + txt_job.Text + "&Pod=" + txt_destport.Text + "&Eta=" + txt_eta.Text + "&Pol=" + txt_loadport.Text + "&Vessel=" + vouy + "&Finaldes=" + txt_shptdest.Text + "&Etd=" + txt_etd.Text + "";
                popup_upload.Visible = true;
                this.popup_uploaddoc.Show();
            }

        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                string typenew = "";
                DataTable dtuser;
                DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                int index = grd.SelectedRow.RowIndex;
                string blno = grd.Rows[index].Cells[1].Text;
                if(hid_type.Value=="N")
                {
                    typenew = "Our BL";
                }
                else
                {
                    typenew = " Liner BL";
                   
                }
                int uiid = 2;
                dtuser = obj_UP.GetFormwiseuserRights(uiid, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FE");
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../ShipmentDetails/FEBLdetails.aspx?blno=" + blno + "&type=" + typenew);

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
            Panel2.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log1.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1, "Job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
            if (txt_job.Text != "")
            {
                JobInput.Text = txt_job.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void txt_mbl_TextChanged(object sender, EventArgs e)
        {
            DataAccess.ForwardingExports.BLDetails objbl = new DataAccess.ForwardingExports.BLDetails();
            DataTable dtbook = new DataTable();
            dtbook = objbl.getsp_getbookingno(txt_mbl.Text.ToUpper(), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (dtbook.Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('MBL# and Booking# is same');", true);
                txt_mbl.Text = "";
                txt_mbl.Focus();
                return;
            }

            obj_dt = obj_da_Job.SPLikeJobBLno(txt_mbl.Text.ToUpper(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
            DataView obj_dtview = new DataView(obj_dt);
            obj_dtview.RowFilter = "blno='" + txt_mbl.Text.ToUpper() + "'";
            obj_dt = obj_dtview.ToTable();
            if (obj_dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(txt_mbl, typeof(TextBox), "BL", "alertify.alert('BL # and MBL # should not Same,kindly change MBL # in Job screen');", true);
                txt_mbl.Focus();
                txt_mbl.Text = "";

                return;
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

        protected void ddl_jobtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddl_GwType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_NwType.Text = ddl_GwType.Text;
        }

        protected void btn_mothervessupd_Click(object sender, EventArgs e)
        {
            if (txt_job.Text != "")
            {
                iframecost.Attributes["src"] = "../CRM/MotherVesselDetail.aspx?Job=" + txt_job.Text;
                popup_cheque.Show();
            }
            else
            {
                ScriptManager.RegisterStartupScript(txt_job, typeof(TextBox), "BL", "alertify.alert('Kindly select job #');", true);
                txt_job.Focus();
            }
        }
        protected void Btnamendmbl_Click(object sender, EventArgs e)
        {
            DataTable dtuser;
            if (Session["StrTranType"].ToString() == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1920, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_job.Text != "")
                    {
                        iframe1.Attributes["src"] = "../AI/AmendMBL.aspx?jobno=" + txt_job.Text + "&link=../ForwardExports/JobInfo.aspx";
                        pop_up.Show();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Job # cannot be Empty!');", true);
                        txt_job.Focus();
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
            if (Session["StrTranType"].ToString() == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(88, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_job.Text != "")
                    {
                        iframe3.Attributes["src"] = "../ForwardExports/ChangeJob.aspx?jobno=" + txt_job.Text;
                        ModalPopupExtender2.Show();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Job # cannot be Empty!');", true);
                        txt_job.Focus();
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            
        }
        protected void btn_draftmbl_Click(object sender, EventArgs e)
        {
            iframe2.Attributes["src"] = "../ForwardExports/MBLDraft.aspx?&job=" + txt_job.Text;
            Panel5.Visible = true;
            this.ModalPopupExtender1.Show();

        }
        protected void Close_voucher_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Session["amendmbl"].ToString()))
            {
                txt_mbl.Text = Session["amendmbl"].ToString();
            }

        }
    }
}