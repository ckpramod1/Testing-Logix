using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace logix.CHA
{
    public partial class EventDetails : System.Web.UI.Page
    {
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.CustomHousingAgent.JobInfo CHAJobobj = new DataAccess.CustomHousingAgent.JobInfo();
        DataAccess.ForwardingImports.JobInfo Connstr = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.CustomHousingAgent.EventDetails CHAEventobj = new DataAccess.CustomHousingAgent.EventDetails();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterEvents eventobj = new DataAccess.Masters.MasterEvents();
        int inteventid;
        DataTable Dt = new DataTable();
        DataTable DtEvents = new DataTable();
        int bid, empid, did;
        string Jobtype, customerloc, shipperloc, consigneeloc, notifyloc, principalloc;
        string str_sp = "";
        string str_sf = "";
        string str_RptName = "";
        string str_Script = "", str_CtrlLists = "", str_MsgLists = "", str_DataType = "";
        string str_FornName, str_Uiid;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            try
            {
                bid = Convert.ToInt32(Session["LoginBranchid"]);
                empid = Convert.ToInt32(Session["LoginEmpId"]);
                did = int.Parse(Session["LoginDivisionId"].ToString());
                if (!IsPostBack)
                {
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    grdevent.DataSource = Utility.Fn_GetEmptyDataTable();
                    grdevent.DataBind();
                    hid_date.Value = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    txt_eventDate.Text = hid_date.Value.ToString();
                    str_CtrlLists = "txt_job~txt_event~txt_remarks";
                    str_MsgLists = "Job NO~Event DETAILS~REMARKS";
                    str_DataType = "String~String~String";
                    UserRights();
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "')");

                    txt_job.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
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
                    btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
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
        [WebMethod]
        public static List<string> Get_event(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterEvents eventobj = new DataAccess.Masters.MasterEvents();
            obj_dt = eventobj.LikeEventName(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(obj_dt, "eventname", "eventname");
            return List_Result;
        }

        protected void lnk_job_Click(object sender, EventArgs e)
        {
            try
            {

                Load_grid();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Load_grid()
        {
            try
            {
                Dt = CHAJobobj.GetAllCHJobInfo(bid, did);
                if (Dt.Rows.Count > 0)
                {
                    this.popup_Grd.Show();
                    DataTable dttemp = new DataTable();
                    dttemp.Columns.Add("Job #");
                    dttemp.Columns.Add("Job Type");
                    dttemp.Columns.Add("Doc #");
                    dttemp.Columns.Add("Doc Date");
                    dttemp.Columns.Add("Mode");
                    DataRow dr = dttemp.NewRow();

                    for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        dr = dttemp.NewRow();
                        dttemp.Rows.Add(dr);
                        dr["Job #"] = Dt.Rows[i][0].ToString();
                        dr["Doc #"] = Dt.Rows[i][2].ToString();
                        dr["Doc Date"] = Dt.Rows[i][3].ToString();
                        dr["Mode"] = Dt.Rows[i][4].ToString();
                        if (Dt.Rows[i][1].ToString() == "SE")
                        {
                            dr["Job Type"] = "Sea Exports";
                        }
                        else if (Dt.Rows[i][1].ToString() == "SI")
                        {
                            dr["Job Type"] = "Sea Imports";
                        }
                        else if (Dt.Rows[i][1].ToString() == "AE")
                        {
                            dr["Job Type"] = "Air Exports";
                        }
                        else if (Dt.Rows[i][1].ToString() == "AI")
                        {
                            dr["Job Type"] = "Air Imports";
                        }
                        else if (Dt.Rows[i][1].ToString() == "RE")
                        {
                            dr["Job Type"] = "Road Exports";
                        }
                        else if (Dt.Rows[i][1].ToString() == "RI")
                        {
                            dr["Job Type"] = "Road Imports";
                        }
                        else
                        {
                            dr["Job Type"] = "By Road";
                        }
                    }
                    Grd_JOb.DataSource = dttemp;
                    Grd_JOb.DataBind();

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job Not Available');", true);

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_job_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Clear();
                GetDetails();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txt_job.Text = "";
                txt_job.Focus();
            }
        }

        protected void grdevent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = grdevent.SelectedRow.RowIndex;
                txt_event.Text = grdevent.Rows[index].Cells[0].Text;
                txt_eventDate.Text = grdevent.Rows[index].Cells[1].Text;
                txt_eventDate.Text = Utility.fn_ConvertDate(txt_eventDate.Text);
                txt_remarks.Text = grdevent.Rows[index].Cells[2].Text;
                //btn_save.Text = "Update";


                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdevent_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdevent, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_JOb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Clear();
                int index = Grd_JOb.SelectedRow.RowIndex;
                txt_job.Text = Grd_JOb.Rows[index].Cells[0].Text;
                GetDetails();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Back")
            {
                this.Response.End();
            }
            else
            {
                Clear();
                txt_job.Focus();
                UserRights();
            }
        }

        protected void GetDetails()
        {

            try
            {
                int jobno=0;
                if(txt_job.Text!="")
                {
                    jobno = Convert.ToInt32(txt_job.Text);
                    DtEvents = CHAJobobj.GetCHJobInfo(jobno, bid, did);
                }
              
             
                if (DtEvents.Rows.Count > 0)
                {
                    Jobtype = DtEvents.Rows[0][1].ToString();
                    txt_jobtype.Text = CHAJobobj.SetJobtype(Jobtype);
                    txt_doc.Text = DtEvents.Rows[0][2].ToString();
                    txt_mdoc.Text = DtEvents.Rows[0][4].ToString();
                    txt_mode.Text = DtEvents.Rows[0][5].ToString();
                    txt_customer.Text = DtEvents.Rows[0][6].ToString();
                    txt_shipper.Text = DtEvents.Rows[0][7].ToString();
                    txt_consignee.Text = DtEvents.Rows[0][8].ToString();
                    txt_notify.Text = DtEvents.Rows[0][9].ToString();
                    txt_principal.Text = DtEvents.Rows[0][10].ToString();
                    txt_pic.Text = DtEvents.Rows[0][11].ToString();
                    txt_cargo.Text = DtEvents.Rows[0][12].ToString();
                    txt_packages.Text = DtEvents.Rows[0][14].ToString();
                    txt_Grossweight.Text = DtEvents.Rows[0][15].ToString();
                    txt_netWeight.Text = DtEvents.Rows[0][16].ToString();
                    txt_volume.Text = DtEvents.Rows[0][18].ToString();
                    txt_documents.Text = DtEvents.Rows[0][19].ToString();
                    txt_pol.Text = DtEvents.Rows[0][20].ToString();
                    txt_pod.Text = DtEvents.Rows[0][21].ToString();
                    txt_fd.Text = DtEvents.Rows[0][22].ToString();
                    customerloc = customerobj.GetCustomername(Convert.ToInt32(DtEvents.Rows[0][23].ToString()));
                    shipperloc = customerobj.GetCustomername(Convert.ToInt32(DtEvents.Rows[0][24].ToString()));
                    consigneeloc = customerobj.GetCustomername(Convert.ToInt32(DtEvents.Rows[0][25].ToString()));
                    notifyloc = customerobj.GetCustomername(Convert.ToInt32(DtEvents.Rows[0][26]));
                    principalloc = customerobj.GetCustomername(Convert.ToInt32(DtEvents.Rows[0][27]));
                    if (txt_job.Text != "")
                    {
                       
                       DtEvents.Columns.Add("eventname");
                        DtEvents.Columns.Add("eventdate");
                        DtEvents.Columns.Add("remarks");
                        DtEvents = CHAEventobj.GetEventDetails(jobno, bid, did);
                        if (DtEvents.Rows.Count > 0)
                        {
                            DataRow drow1;
                            drow1 = DtEvents.NewRow();
                            for(int i=0;i<=DtEvents.Rows.Count-1;i++)
                            {
                                DtEvents.Rows[i][0] = DtEvents.Rows[i][0].ToString();
                                DtEvents.Rows[i][1] = DtEvents.Rows[i][1].ToString();
                                DtEvents.Rows[i][2] = (DtEvents.Rows[i][2].ToString()).ToUpper();
                               
                            }
                           
                            grdevent.DataSource = DtEvents;
                            grdevent.DataBind();
                        }
                        else
                        {
                            grdevent.DataSource = Utility.Fn_GetEmptyDataTable();
                            grdevent.DataBind();
                        }
                    }
                   // btn_cancel.Text = "Cancel";

                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    Clear();
                    txt_job.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txt_event.Focus();
           // btn_cancel.Text = "Cancel";



            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

        }

        protected void Clear()
        {
            txt_job.Text = "";
            txt_cargo.Text = "";
            txt_consignee.Text = "";
            txt_doc.Text = "";
            txt_customer.Text = "";
            txt_documents.Text = "";
            txt_event.Text = "";
            txt_fd.Text = "";
            txt_Grossweight.Text = "";
            txt_mdoc.Text = "";
            txt_mode.Text = "";
            txt_netWeight.Text = "";
            txt_notify.Text = "";
            txt_packages.Text = "";
            txt_pic.Text = "";
            txt_pod.Text = "";
            txt_pol.Text = "";
            txt_principal.Text = "";
            txt_remarks.Text = "";
            txt_shipper.Text = "";
            txt_volume.Text = "";
            txt_jobtype.Text = "";
            grdevent.DataSource = Utility.Fn_GetEmptyDataTable();
            grdevent.DataBind();
            txt_eventDate.Text = hid_date.Value.ToString();
            //btn_cancel.Text = "Back";

            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            this.PopUpService.Show();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                int custId = 0; string eventname = "";
                if (txt_event.Text != "")
                {
                    custId = eventobj.GetEventid(txt_event.Text);
                    if (custId == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('INVALID EVENT NAME');", true);
                        txt_event.Focus();
                        txt_event.Text = "";
                        return;
                    }

                }
                int jobno = Convert.ToInt32(txt_job.Text);
                if (btn_save.ToolTip == "Save")
                {
                    if (grdevent.Rows.Count > 0)
                    {
                        for (int i = 0; i <= grdevent.Rows.Count - 1; i++)
                        {
                            eventname = grdevent.Rows[i].Cells[0].Text;
                            if (eventname == txt_event.Text)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Exists');", true);
                                txt_event.Focus();
                                return;
                            }
                        }
                    }
                    CHAEventobj.InsEventDetails(jobno, txt_event.Text, Convert.ToDateTime(Utility.fn_ConvertDate(txt_eventDate.Text)), txt_remarks.Text, bid, did);
                    Logobj.InsLogDetail(empid, 169, 1, bid, txt_job.Text);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Saved');", true);
                    //DtEvents = CHAEventobj.GetEventDetails(jobno, bid, did);
                    //grdevent.DataSource = DtEvents;
                    //grdevent.DataBind();
                   
                    DataRow drow;

                    DtEvents.Columns.Add("eventname");
                    DtEvents.Columns.Add("eventdate");
                    DtEvents.Columns.Add("remarks");
                    DtEvents = CHAEventobj.GetEventDetails(jobno, bid, did);
                    if (DtEvents.Rows.Count > 0)
                    {
                        drow = DtEvents.NewRow();
                        for (int i = 0; i <= DtEvents.Rows.Count - 1; i++)
                        {
                           
                            
                            DtEvents.Rows[i][0] = DtEvents.Rows[i][0].ToString();
                            DtEvents.Rows[i][1] = DtEvents.Rows[i][1].ToString();
                            DtEvents.Rows[i][2] = (DtEvents.Rows[i][2].ToString()).ToUpper();
                            
                        }
                       
                        grdevent.DataSource = DtEvents;
                        grdevent.DataBind();
                    }
                    else
                    {
                        grdevent.DataSource = Utility.Fn_GetEmptyDataTable();
                        grdevent.DataBind();
                    }
                    txt_event.Text = "";
                    txt_eventDate.Text = hid_date.Value;
                    txt_remarks.Text = "";
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                }
                else
                {
                    CHAEventobj.UpdEventDetails(jobno, txt_event.Text, Convert.ToDateTime(Utility.fn_ConvertDate(txt_eventDate.Text)), txt_remarks.Text, bid, did);
                    Logobj.InsLogDetail(empid, 169, 2, bid, txt_job.Text);
                 //   btn_save.Text = "Save";



                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";

                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated');", true);
                    //DtEvents = CHAEventobj.GetEventDetails(jobno, bid, did);
                    //grdevent.DataSource = DtEvents;
                    //grdevent.DataBind();
                 
                    DataRow drow;

                    DtEvents.Columns.Add("eventname");
                    DtEvents.Columns.Add("eventdate");
                    DtEvents.Columns.Add("remarks");
                    DtEvents = CHAEventobj.GetEventDetails(jobno, bid, did);
                    if (DtEvents.Rows.Count > 0)
                    {
                        drow = DtEvents.NewRow();
                        for (int i = 0; i <= DtEvents.Rows.Count - 1; i++)
                        {
                            
                           
                            DtEvents.Rows[i][0] = DtEvents.Rows[i][0].ToString();
                            DtEvents.Rows[i][1] = DtEvents.Rows[i][1].ToString();
                            DtEvents.Rows[i][2] = (DtEvents.Rows[i][2].ToString()).ToUpper();
                           
                        }
                       
                        grdevent.DataSource = DtEvents;
                        grdevent.DataBind();

                    }
                    else
                    {
                        grdevent.DataSource = Utility.Fn_GetEmptyDataTable();
                        grdevent.DataBind();
                    }
                    txt_event.Text = "";
                    txt_eventDate.Text = hid_date.Value;
                    txt_remarks.Text = "";
                }
                txt_event.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_JOb_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_JOb, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_JOb_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grd_JOb.PageIndex = e.NewPageIndex;
                Load_grid();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_yes_Click(object sender, EventArgs e)
        {

            str_RptName = "CHEventDtsEventwise.rpt";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "EventDetails", str_Script, true);
            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 169, 3, Convert.ToInt32(Session["LoginBranchid"]), "CH-EventView");
        }

        protected void btn_no_Click(object sender, EventArgs e)
        {
            str_RptName = "CHEventDtsDatewise.rpt";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "EventDetails", str_Script, true);
            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 169, 3, Convert.ToInt32(Session["LoginBranchid"]), "CH-EventView");
        }

        protected void txt_event_TextChanged(object sender, EventArgs e)
        {
            inteventid = eventobj.GetEventid(txt_event.Text);
            if (inteventid == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Correct Event Name);", true);
                txt_event.Focus();
                txt_event.Text = "";
                return;
            }
            txt_remarks.Focus();
           // btn_cancel.Text = "Cancel";



            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 169, "Job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
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
     

    }
}