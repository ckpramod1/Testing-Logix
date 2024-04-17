using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
namespace logix.CRM
{
    public partial class SendDocument : System.Web.UI.Page
    {
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
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
        DateTime dt_now;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (!IsPostBack == true)
            {
                // Ctrl_List = lstbox_bldate.ID;
                // Msg_List = "Status";
                try
                {
                    Ctrl_List = txt_job.ID + "~" + txt_vvoy.ID + "~" + txt_pol.ID + "~" + txt_etd.ID + "~" + txt_pod.ID + "~" + txt_eta.ID + "~" + txt_stuffedon.ID;
                    Msg_List = "JOBNUMBER~Vessel&VOYAGE~POL~ETD~Port Of Destination~ETA~STUFFEDON";
                    Dtype_List = "string~string";
                    btn_send.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "');");
                    this.Mdl_grdjob.Hide();
                    fn_enblstatus();
                    DataAccess.Masters.MasterEmployee obj_da_me = new DataAccess.Masters.MasterEmployee();
                    int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                    strEmpName = obj_da_me.GetEmployeeName(int_empid);
                    ClearAll();

                    grd_cmail.DataSource = new DataTable();
                    grd_cmail.DataBind();

                    grd_imail.DataSource = new DataTable();
                    grd_imail.DataBind();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

            }
        }
        [WebMethod]
        public static List<string> IMailID(string prefix)
        {
            DataAccess.ForwardingExports.StuffingConfirmation obj_da_sc = new DataAccess.ForwardingExports.StuffingConfirmation();

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
            DataTable obj_Dt = new DataTable();
            List<string> Bookingno = new List<string>();
            obj_Dt = obj_da_sc.GetLikeCustExporMailID(prefix);
            Bookingno = Utility.Fn_DatatableToList_int32(obj_Dt, "expmailid", "customerid");
            return Bookingno;
        }
        public void fn_enblstatus()
        {
            // txt_job.Enabled = false;
            txt_vvoy.Enabled = false;
            txt_pol.Enabled = false;
            txt_etd.Enabled = false;
            txt_pod.Enabled = false;
            txt_eta.Enabled = false;
            txt_stuffedon.Enabled = false;

        }
        protected void lbl_job_Click(object sender, EventArgs e)
        {
            try
            {
                LoadJob();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void LoadJob()
        {
           
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.JobInfo obj_da_job = new DataAccess.ForwardingExports.JobInfo();
            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "FE")
                {
                    obj_dt = obj_da_job.GetJobNoList(int_branchid, int_divisionid);
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    obj_dt = obj_da_job.GetJobNoListFI(int_branchid, int_divisionid);
                }
            }

            if (obj_dt.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(btn_cancel, typeof(Button), "DataFound", "alertify.alert('Job Not Available');", true);
            }
            else
            {
                this.Mdl_grdjob.Show();
                grd_job.DataSource = obj_dt;
                grd_job.DataBind();
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
        //           // txt_booking.Text = hf_bookno.Value.ToString();
        //           // getBLDetails(hf_bookno.Value);
        //        }
        //    }
        //}

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
                DataAccess.ForwardingExports.JobInfo obj_da_job = new DataAccess.ForwardingExports.JobInfo();
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
                }

                DataTable obj_dt_bl = new DataTable();
                DataAccess.ForwardingExports.BLDetails obj_da_bl = new DataAccess.ForwardingExports.BLDetails();

                DataAccess.ForwardingExports.StuffingConfirmation obj_da_stuff = new DataAccess.ForwardingExports.StuffingConfirmation();
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        obj_dt_bl = obj_da_bl.SelBLDetailsByJob(jobno, int_branchid, int_divisionid);
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        obj_dt_bl = obj_da_bl.SelFIBLDetailsByJob(jobno, int_branchid, int_divisionid);
                    }


                }
                //if (obj_dt_bl.Rows.Count>0)
                //{
                //    btn_send.Visible = true;
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(btn_cancel, typeof(Button), "DataFound", "alertify.alert('This job do not have BL#');", true);
                //    txt_job.Focus();
                //    btn_send.Visible = false;
                //    return;
                //}

                DataTable DtBl = new DataTable();
                DataTable obj_dt_stuff1 = new DataTable();
                DataTable obj_dt_stuff2 = new DataTable();
                fn_enblstatus();
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
                    txt_stuffedon.Text = obj_dt_job.Rows[0]["stuffedon"].ToString();
                    // txt_stuffedon.Text = obj_dt_job.Rows(0).Item("stuffedon").ToString();
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
                    if (Session["StrTranType"] != null)
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            DtBl = obj_da_bl.SelBLDetailsByJob(jobno, int_branchid, int_divisionid);
                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {
                            DtBl = obj_da_bl.SelFIBLDetailsByJob(jobno, int_branchid, int_divisionid);
                        }

                    }
                    if (DtBl.Rows.Count > 0)
                    {
                        lstbox_bldate.Items.Clear();
                        for (int i = 0; i < DtBl.Rows.Count; i++)
                        {
                            lstbox_bldate.Items.Add(DtBl.Rows[i]["blno"].ToString() + "   /   " + DtBl.Rows[i]["bldate"].ToString());
                        }
                    }
                    if (Session["StrTranType"] != null)
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            obj_dt_stuff1 = obj_da_stuff.GetSBDetails4mail(jobno, int_branchid, int_divisionid);
                        }
                    }
                    if (obj_dt_stuff1.Rows.Count > 0)
                    {
                        lst_sbdate.Items.Clear();
                        for (int i = 0; i < obj_dt_stuff1.Rows.Count; i++)
                        {
                            lst_sbdate.Items.Add(obj_dt_stuff1.Rows[i]["sbno"].ToString() + "   /   " + obj_dt_stuff1.Rows[i]["sbdate"].ToString());
                        }
                    }

                    chk_containers.Items.Clear();
                    DataTable obj_dt_jobinfo = new DataTable();
                    DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
                    obj_dt_jobinfo = obj_da_jobinfo.GetContainerDetails(Convert.ToInt32(txt_job.Text), txt_job.Text, int_branchid, int_divisionid);
                    //for (int i = 0; i < obj_dt_jobinfo.Rows.Count; i++)
                    //{
                    //    chk_containers.Items.Add(obj_dt_jobinfo.Rows[i][0].ToString());
                    //}
                    if (obj_dt_jobinfo.Rows.Count > 0)
                    {
                        for (int i = 0; i <= obj_dt_jobinfo.Rows.Count - 1; i++)
                        {
                            chk_containers.Items.Add(obj_dt_jobinfo.Rows[i][0].ToString() + " Container," + obj_dt_jobinfo.Rows[i][1].ToString());
                        }
                    }
                    // getcontexist();
                    btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    //btn_send.Enabled = false;
                    ScriptManager.RegisterStartupScript(btn_cancel, typeof(Button), "DataFound", "alertify.alert('Invalid Job #');", true);
                    txt_job.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        //private void getcontexist()
        //{
        //    DataTable obj_dt_dtCont = new DataTable();
        //    DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
        //    obj_dt_dtCont = obj_da_jobinfo.GetContainerDetails(Convert.ToInt32(hf_jobno.Value), hf_bookno.Value, int_branchid, int_divisionid);
        //    if (obj_dt_dtCont.Rows.Count > 0)
        //    {
        //        for (int k = 0; k < obj_dt_dtCont.Rows.Count; k++)
        //        {
        //            if (chk_containers.Items[k].ToString() == obj_dt_dtCont.Rows[k]["containerno"].ToString())
        //            {
        //                chk_containers.Items[k].Selected = true;
        //            }
        //        }
        //    }
        //}

        //private void GetBL()
        //{

        //   int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
        //    int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());




        //}
        protected void btn_plus_Click(object sender, EventArgs e)
        {
            //Get_CmailID();
            //txt_cmailid.Text = "";
            //txt_cmailid.Focus();
            try
            {
                if (txt_cmailid.Text.Trim().ToUpper() != "")
                {
                    if (IsValidEmailId(txt_cmailid.Text.Trim().ToUpper()))
                    {
                        if (ViewState["CurrentData"] != null)
                        {
                            DataTable dt = (DataTable)ViewState["CurrentData"];
                            int count = dt.Rows.Count;
                            BindGrid(count, txt_cmailid.Text.Trim().ToUpper());
                        }
                        else
                        {
                            BindGrid(1, txt_cmailid.Text.Trim().ToUpper());
                        }

                        txt_cmailid.Text = "";
                        txt_cmailid.Focus();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('InValid Email Format');", true);
                        txt_cmailid.Text = "";
                        txt_cmailid.Focus();
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Cant Be Balnk');", true);
                    txt_cmailid.Text = "";
                    txt_cmailid.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private bool IsValidEmailId(string InputEmail)
        {
            //Regex To validate Email Address
            Regex regex = new Regex(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$");

            Match match = regex.Match(InputEmail);
            if (match.Success)
                return true;
            else
                return false;
        }

        private void BindGrid(int rowcount, string txtname)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            try
            {
                dt.Columns.Add(new System.Data.DataColumn("mailid", typeof(String)));
                //dt.Columns.Add(new System.Data.DataColumn("customername", typeof(String)));

                if (ViewState["CurrentData"] != null)
                {

                    ImageButton btndelete = new ImageButton();
                    foreach (GridViewRow row in grd_cmail.Rows)
                    {

                        btndelete = (ImageButton)row.FindControl("ImageButton2");
                        btndelete.Visible = true;

                    }
                    for (int i = 0; i < rowcount + 1; i++)
                    {
                        dt = (DataTable)ViewState["CurrentData"];

                        if (dt.Rows.Count > 0)
                        {
                            DataView dv = new DataView(dt);
                            dv.RowFilter = "mailid = '" + txtname.ToString().ToUpper().Trim() + "'";
                            if (dv.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail id Already Exist');", true);
                                return;
                            }

                            dr = dt.NewRow();
                            dr[0] = dt.Rows[0][0].ToString();
                        }
                    }


                    dr = dt.NewRow();
                    dr[0] = txtname;
                    //dr[1] = custtype;

                    dt.Rows.Add(dr);

                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = txtname;
                    //dr[1] = custtype;

                    dt.Rows.Add(dr);

                }


                if (ViewState["CurrentData"] != null)
                {
                    grd_cmail.DataSource = (DataTable)ViewState["CurrentData"];
                    //Grd_mail.DataSource = dt;
                    grd_cmail.DataBind();
                }
                else
                {
                    grd_cmail.DataSource = dt;
                    grd_cmail.DataBind();
                    //EmptyGridmail();

                }

                ViewState["CurrentData"] = dt;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }


        }

        protected void grd_cmail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("ImageButton2");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_cmail, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
        }

        //private void Get_ImailID()
        //{
        //    str_imailid = hf_imailname.Value.ToString();
        //    txt_imailid.Text = str_imailid.ToString();

        //    DataTable dt_list = new DataTable();
        //    dt_list = (DataTable)Session["dt_IList"];
        //    DataRow dr;
        //    if (dt_list == null)
        //    {
        //        dt_list = new DataTable();
        //        DataColumn dc_col2 = new DataColumn("mailid", typeof(string));
        //        dt_list.Columns.Add(dc_col2);
        //    }
        //    DataRow[] dr_tt1 = dt_list.Select("mailid='" + txt_imailid.Text.ToString() + "'");
        //    if (dr_tt1.Length == 0)
        //    {
        //        if (txt_imailid.Text == "")
        //        {
        //            ScriptManager.RegisterStartupScript(btn_cancel, typeof(Button), "DataFound", "alertify.alert('Please Enter mailid');", true);
        //        }
        //        else
        //        {
        //            dr = dt_list.NewRow();
        //            dr["mailid"] = txt_imailid.Text;
        //            dt_list.Rows.Add(dr);
        //        }

        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(btn_cancel, typeof(Button), "DataFound", "alertify.alert('Mail id Already There');", true);
        //    }

        //    Session["dt_IList"] = dt_list;
        //    grd_imail.DataSource = dt_list;
        //    grd_imail.DataBind();
        //}



        private void BindGrid1(int rowcount, string txtname)
        {
            DataTable dtINR = new DataTable();
            DataRow dr1;
            try
            {
                dtINR.Columns.Add(new System.Data.DataColumn("offmailid", typeof(String)));
                //dt.Columns.Add(new System.Data.DataColumn("customername", typeof(String)));

                if (ViewState["CurrentDataMail"] != null)
                {

                    ImageButton btndelete = new ImageButton();
                    foreach (GridViewRow row in grd_imail.Rows)
                    {

                        btndelete = (ImageButton)row.FindControl("ImageButton");
                        btndelete.Visible = true;

                    }
                    for (int i = 0; i < rowcount + 1; i++)
                    {
                        dtINR = (DataTable)ViewState["CurrentDataMail"];

                        if (dtINR.Rows.Count > 0)
                        {
                            DataView dv = new DataView(dtINR);
                            dv.RowFilter = "offmailid = '" + txtname.ToString().ToUpper().Trim() + "'";
                            if (dv.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail id Already Exist');", true);
                                return;
                            }

                            dr1 = dtINR.NewRow();
                            dr1[0] = dtINR.Rows[0][0].ToString();
                        }
                    }


                    dr1 = dtINR.NewRow();
                    dr1[0] = txtname;
                    //dr[1] = custtype;

                    dtINR.Rows.Add(dr1);

                }
                else
                {
                    dr1 = dtINR.NewRow();
                    dr1[0] = txtname;
                    //dr[1] = custtype;

                    dtINR.Rows.Add(dr1);

                }


                if (ViewState["CurrentDataMail"] != null)
                {
                    grd_imail.DataSource = (DataTable)ViewState["CurrentDataMail"];
                    grd_imail.DataBind();
                }
                else
                {
                    grd_imail.DataSource = dtINR;
                    grd_imail.DataBind();
                    //EmptyGridIntermail();

                }

                ViewState["CurrentDataMail"] = dtINR;

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton lb = (ImageButton)sender;
                GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
                int rowID = gvRow.RowIndex;
                if (ViewState["CurrentData"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentData"];
                    if (dt.Rows.Count > 0)
                    {
                        if (gvRow.RowIndex < dt.Rows.Count)
                        {

                            dt.Rows.Remove(dt.Rows[rowID]);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details Deleted Successfully...');", true);
                        }

                        ViewState["CurrentTable"] = dt;

                        grd_cmail.DataSource = dt;
                        grd_cmail.DataBind();
                    }
                    if (dt.Rows.Count == 0)
                    {
                        EmptyGridmail();
                    }

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton lb = (ImageButton)sender;
                GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
                int rowID = gvRow.RowIndex;
                if (ViewState["CurrentDataMail"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentDataMail"];
                    if (dt.Rows.Count > 0)
                    {
                        if (gvRow.RowIndex < dt.Rows.Count)
                        {

                            dt.Rows.Remove(dt.Rows[rowID]);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details Deleted Successfully...');", true);
                        }

                        ViewState["CurrentTable"] = dt;

                        grd_imail.DataSource = dt;
                        grd_imail.DataBind();
                    }
                    if (dt.Rows.Count == 0)
                    {
                        EmptyGridIntermail();
                    }


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void grd_imail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("ImageButton");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_imail, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        //private void Get_CmailID()
        //{
        //    str_cmailid = hf_cmailname.Value.ToString();
        //    txt_cmailid.Text = str_cmailid.ToString();

        //    DataTable dt_list = new DataTable();
        //    dt_list = (DataTable)Session["dt_CList"];
        //    DataRow dr;
        //    if (dt_list == null)
        //    {
        //        dt_list = new DataTable();
        //        DataColumn dc_col2 = new DataColumn("mailid", typeof(string));
        //        dt_list.Columns.Add(dc_col2);
        //    }
        //    DataRow[] dr_tt1 = dt_list.Select("mailid='" + txt_cmailid.Text.ToString() + "'");
        //    if (dr_tt1.Length == 0)
        //    {
        //        if (txt_cmailid.Text == "")
        //        {
        //            ScriptManager.RegisterStartupScript(btn_cancel, typeof(Button), "DataFound", "alertify.alert('Please Enter mailid');", true);
        //        }
        //        else
        //        {
        //            dr = dt_list.NewRow();
        //            dr["mailid"] = txt_cmailid.Text;
        //            dt_list.Rows.Add(dr);
        //        }

        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(btn_cancel, typeof(Button), "DataFound", "alertify.alert('Mail id Already There');", true);
        //    }

        //    Session["dt_CList"] = dt_list;
        //    grd_cmail.DataSource = dt_list;
        //    grd_cmail.DataBind();
        //}



        private void ClearAll()
        {
            txt_job.Text = "";
            txt_vvoy.Text = "";
            txt_pol.Text = "";
            txt_etd.Text = "";
            txt_pod.Text = "";
            txt_eta.Text = "";

            txt_cmailid.Text = "";
            txt_imailid.Text = "";
            txt_stuffedon.Text = "";
            // lstbox_bldate.Text = "";
            lstbox_bldate.Items.Clear();
            chk_containers.Items.Clear();
            lst_sbdate.Items.Clear();
            hf_jobno.Value = "0";
            txt_subject.Text = "";
            txt_body.Text = "";
            grd_cmail.DataSource = new DataTable();
            grd_cmail.DataBind();
            grd_imail.DataSource = new DataTable();
            grd_imail.DataBind();
            // EmptyGridmail();
            // EmptyGridIntermail();
            //  lstbox_bldate.Text = "";
            btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_back1.Attributes["class"] = "btn ico-back";
            //btn_send.Text = "Send";
        }
        private void EmptyGridmail()
        {
            DataTable dtempty = new DataTable();
            dtempty.Columns.Add("mailid");
            dtempty.Rows.Add(dtempty.NewRow());
            grd_cmail.DataSource = dtempty;
            grd_cmail.DataBind();
            grd_cmail.Rows[0].Visible = false;
        }

        private void EmptyGridIntermail()
        {
            DataTable dtempty = new DataTable();
            dtempty.Columns.Add("offmailid");
            dtempty.Rows.Add(dtempty.NewRow());
            grd_imail.DataSource = dtempty;
            grd_imail.DataBind();
            grd_imail.Rows[0].Visible = false;
        }

        protected void txt_booking_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grd_cmail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            DataAccess.HR.Employee obj_da_hre = new DataAccess.HR.Employee();
            DataAccess.ForwardingExports.JobInfo FEJobobj = new DataAccess.ForwardingExports.JobInfo();
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());

            try
            {
                int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());

                if (txt_job.Text.Length != 0)
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
                    //StatusMail();
                    getbody();
                    //FEJobobj.Upddocsentby(int_branchid, (txt_job.Text), (txt_booking.Text.trim()), int_empid, int_divisionid);
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 664, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void getbody()
        {
            string str_usermailid = Session["usermailid"].ToString();
            string str_mailpwd = Session["usermailpwd"].ToString();
            string sendqry = "";
            String[] myParas;
            myParas = txt_body.Text.Split();
            int k = myParas.Length;
            string ss, subject = "";
            subject = txt_subject.Text;

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
                for (int i = 0; i <= k - 1; i++)
                {
                    sendqry = sendqry + "<table cellspacing=0 cellpadding=2>";
                    ss = myParas[i].ToString();
                    sendqry = sendqry + "<tr><td align=left ><font size=2 face=sans-serif>" + ss + "</td></tr>";
                    sendqry = sendqry + "</table>";
                }
                Utility.SendMailnew("", shippermailadd, subject, sendqry, st2, "Msncl2021$");
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
                DataAccess.Masters.MasterEmployee obj_da_me = new DataAccess.Masters.MasterEmployee();
                strEmpName = obj_da_me.GetEmployeeName(int_empid);
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                string sname = "";
                string sendqry = "";

                string subject = "";
                DataAccess.Documents obj_da_doc = new DataAccess.Documents();
                DataAccess.LogDetails obj_da_ld = new DataAccess.LogDetails();
                DataAccess.Message4Booking obj_da_m4b = new DataAccess.Message4Booking();
                sname = obj_da_doc.GetShortname(int_branchid);
                subject = "PRESENT STATUS - " + "-" + blpod + "-" + sname + "-" + txt_job.Text + "-" + txt_subject.Text;
                sendqry = sendqry + "<table cellspacing=0 cellpadding=2>";
                sendqry = sendqry + "<tr><td align=left ><font size=2 face=sans-serif>Dear Sir / Madam,</td></tr>";
                sendqry = sendqry + "</table>";
                sendqry = sendqry + "<table cellspacing=0 cellpadding=2>";
                sendqry = sendqry + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<tr><td align=left ><font size=2 face=sans-serif>Status - " + txt_body.Text + ". </td></tr>";
                sendqry = sendqry + "</table>";
                sendqry = sendqry + "<table cellspacing=0 cellpadding=2>";
                sendqry = sendqry + "<tr><td align=left ><font size=2 face=sans-serif>Thanks & Regards ,</td></tr>";
                sendqry = sendqry + "<tr><td align=left ><font size=2 face=sans-serif>" + obj_da_me.GetEmployeeName(int_empid) + ".</td></tr><br>";
                sendqry = sendqry + "</table>";

                // string str_mailserver = Session["MailServer"].ToString();
                string str_usermailid = Session["usermailid"].ToString();
                // string str_mailuser = Session["MailUser"].ToString();

                string str_mailpwd = Session["usermailpwd"].ToString();

                Utility.SendMailnew(usermail, shippermailadd, subject, sendqry, "", str_mailpwd);
                // Utility.SendMail(str_usermailid, shippermailadd, subject, sendqry, "", str_mailpwd);
                //sendmail.SendEmail(shippermailadd, usermail, "pandi", subject, sendqry, true, str_mailserver, internalmailid, "", str_mailuser, str_mailpwd, str_attach);
                obj_da_m4b.InsMsg4Booking(txt_job.Text, subject, shippermailadd, internalmailid, obj_da_ld.GetDate(), strEmpName, "", "", "");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }


        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                ClearAll();
                btn_send_id.Visible = false;
                btn_send.Visible = false;
            }
            else
            {
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

                        }
                    }
                }
                else
                {
                    this.Response.End();
                }
            }

        }

        protected void chk_containers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lst_sbdate_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void grd_job_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = grd_job.SelectedRow.RowIndex;
                txt_job.Text = ((Label)grd_job.Rows[index].Cells[0].FindControl("Job")).Text;
                getjobinfo(Convert.ToInt32(txt_job.Text));
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
                //int index = grd_job.SelectedRow.RowIndex;
                //txt_job.Text = ((Label)grd_job.Rows[index].Cells[0].FindControl("Job")).Text;
                getjobinfo(Convert.ToInt32(txt_job.Text));
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

        protected void btn_cmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_imailid.Text.Trim().ToUpper() != "")
                {
                    if (IsValidEmailId(txt_imailid.Text.Trim().ToUpper()))
                    {
                        if (ViewState["CurrentDataMail"] != null)
                        {
                            DataTable dtINMail = (DataTable)ViewState["CurrentDataMail"];
                            int count = dtINMail.Rows.Count;
                            BindGrid1(count, txt_imailid.Text.Trim().ToUpper());
                        }
                        else
                        {
                            BindGrid1(1, txt_imailid.Text.Trim().ToUpper());
                        }

                        txt_imailid.Text = "";
                        txt_imailid.Focus();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Email Format');", true);
                        txt_imailid.Focus();
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Can't Be Blank');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
    }
}