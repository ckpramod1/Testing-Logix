using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

namespace logix.CRM
{
    public partial class EventTracking : System.Web.UI.Page
    {
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_exprtexcel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_clear);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            
            if (Request.QueryString.ToString().Contains("OECSHomeEventtracking"))
            {
                crumbslbl.Attributes["class"] = "crumbslbl";

            }

            if (!IsPostBack == true)
            {

                try
                {
                    fn_enblstatus();
                    if (ddl_nxtflwupdate.SelectedValue == "0")
                    {
                        // ddl_nxtflwupdate.Items.Clear();
                        fn_ddl_nxtfllwupload();
                    }
                    if (Session["backjobno"] != null)
                    {
                        txt_jobno.Text = Convert.ToString(Session["backjobno"]);
                        fn_txtjob_Click();
                        txt_blno.Enabled = false;
                        fn_enblstatus();
                        Session["backjobno"] = null;
                    }
                    //if (Session["Backnxtflwdate"] != null)
                    //{
                    //    ddl_nxtflwupdate.Text = Session["Backnxtflwdate"].ToString();
                    //    fn_ddlnxtflw_Select();
                    //}
                    if (Session["ss_grdevttrakng"] != null)
                    {
                        grd_evnttrack.DataSource = (DataTable)Session["ss_grdevttrakng"];
                        grd_evnttrack.DataBind();
                        Session["ss_grdevttrakng"] = null;
                    }
                    else
                    {
                        grd_evnttrack.DataSource = new DataTable();
                        grd_evnttrack.DataBind();

                        grd_pndngevents.DataSource = new DataTable();
                        grd_pndngevents.DataBind();
                    }
                    btn_clear.Text = "Cancel";
                    btn_clear.ToolTip = "Cancel";
                   btn_clear1.Attributes["class"] = "btn ico-cancel";

                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

            }
           // pnl_job.Visible = true;
        }

        public void fn_ddl_nxtfllwupload()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                DataAccess.ForwardingExports.JobInfo obj_da_FEJobInfo = new DataAccess.ForwardingExports.JobInfo();
                obj_dt = obj_da_FEJobInfo.FillFollowup(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                ddl_nxtflwupdate.Items.Clear();
                //ddl_nxtflwupdate.Items.Add("--Select--");
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    ddl_nxtflwupdate.Items.Add(Utility.fn_ConvertDate(obj_dt.Rows[i]["nextfollowup"].ToString().TrimEnd()));
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../FormMain.aspx','_top');", true);
            }
        }
        [WebMethod]
        public static List<string> Getblno(string prefix)
        {
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.BLDetails obj_da_febl = new DataAccess.ForwardingExports.BLDetails();
            List<string> blno = new List<string>();
            obj_dt = obj_da_febl.GetLikeBLDetails(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
            blno = Utility.Fn_DatatableToList_string(obj_dt, "blno", "blno");
            return blno;
        }
        public void fn_enblstatus()
        {
           // txt_jobno.Enabled = false;
            txt_vessel.Enabled = false;
            txt_pod.Enabled = false;
            txt_pol.Enabled = false;
            txt_etdsailed.Enabled = false;
            txt_MBLstatus.Enabled = false;
            txt_stuffon.Enabled = false;
            txt_liner.Enabled = false;
            txt_agent.Enabled = false;
            lstbx_cntnrnocl.Enabled = false;
            txt_jobremarks.Enabled = false;
        }
        protected void txt_jobno_TextChanged(object sender, EventArgs e)
        {
            fn_grdjob_Select();
        }

        protected void lbtn_jobno_Click(object sender, EventArgs e)
        {
          // pnl_job.Visible = true;
            if (ddl_nxtflwupdate.SelectedValue == "0")
            {
                // ddl_nxtflwupdate.Items.Clear();
                fn_ddl_nxtfllwupload();
            }
            fn_jobno_Click();

        }
        public void fn_jobno_Click()
        {
            try
            {
                Mdl_grdjob.Show();
                DataTable obj_dtcosting = new DataTable();
                DataAccess.ForwardingExports.JobInfo obj_da_FEJobInfo = new DataAccess.ForwardingExports.JobInfo();
                obj_dtcosting = obj_da_FEJobInfo.GridFillJobdtlsForEvnttrack("FE", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                grd_job.DataSource = obj_dtcosting;
                grd_job.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../FormMain.aspx','_top');", true);
            }
        }


        public void fn_grdjob_Select()
        {
            if (ddl_nxtflwupdate.SelectedValue == "0")
            {
                // ddl_nxtflwupdate.Items.Clear();
                fn_ddl_nxtfllwupload();
            }
            
            fn_txtjob_Click();
            fn_enblstatus();
            txt_blno.Enabled = false;
        }
        public void fn_txtjob_Click()
        {
            if (txt_jobno.Text != "")
            {
                string Strmblstatus;
                string mblstatus;
                DataTable obj_dt = new DataTable();
                DataTable obj_dt1 = new DataTable();
                DataTable obj_dt2 = new DataTable();
                DataAccess.ForwardingExports.JobInfo obj_da_FEJobInfo = new DataAccess.ForwardingExports.JobInfo();
                txt_blno.Enabled = false;

                try
                {
                    obj_dt = obj_da_FEJobInfo.GetFEJobInfo(Convert.ToInt32(txt_jobno.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                    Session["ss_job"] = obj_dt;
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_vessel.Text = obj_dt.Rows[0]["vessel"].ToString() + obj_dt.Rows[0]["voyage"].ToString();
                        txt_etdsailed.Text = obj_dt.Rows[0]["webetd"].ToString();
                        txt_pol.Text = obj_dt.Rows[0]["pol"].ToString();
                        txt_pod.Text = obj_dt.Rows[0]["pod"].ToString();
                        txt_etaarrvd.Text = obj_dt.Rows[0]["webeta"].ToString();
                        txt_agent.Text = obj_dt.Rows[0]["agent"].ToString();
                        txt_liner.Text = obj_dt.Rows[0]["mlo"].ToString();
                        Strmblstatus = obj_dt.Rows[0]["mblstatus"].ToString();
                        if (Strmblstatus == "S")
                        {
                            mblstatus = "SURRENDERED";
                        }
                        else if (Strmblstatus == "B")
                        {
                            mblstatus = "SEAWAY BILL";
                        }
                        else
                        {
                            mblstatus = "RELEASE";
                        }
                        txt_MBLstatus.Text = obj_dt.Rows[0]["mblno"].ToString() + "/" + mblstatus;
                        txt_emnodate.Text = obj_dt.Rows[0]["webemdate"].ToString();
                        txt_stuffon.Text = obj_dt.Rows[0]["webstuffedon"].ToString();
                        txt_jobremarks.Text = obj_dt.Rows[0]["remarks"].ToString();
                    }
                    obj_dt1 = obj_da_FEJobInfo.GetContainerDetails(Convert.ToInt32(txt_jobno.Text.ToString()), txt_jobno.Text.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                    lstbx_cntnrnocl.Items.Clear();

                    for (int i = 0; i <= obj_dt1.Rows.Count - 1; i++)
                    {
                        lstbx_cntnrnocl.Items.Add(obj_dt1.Rows[i]["containerno"].ToString() + " / " + obj_dt1.Rows[i]["sizetype"].ToString() + " / " + obj_dt1.Rows[i]["sealno"].ToString());

                    }
                    obj_dt2 = obj_da_FEJobInfo.GetFEEventTracking(Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString(), "J", Convert.ToInt32(Session["LoginDivisionId"]));
                   
                    Session["ss_grdevttrakng"] = obj_dt2;
                    grd_evnttrack.DataSource = obj_dt2;
                    grd_evnttrack.DataBind();
                   btn_clear.Text = "Cancel";
                   btn_clear.ToolTip = "Cancel";
                   btn_clear1.Attributes["class"] = "btn ico-cancel";

                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../FormMain.aspx','_top');", true);
                }
            }


        }

        protected void grd_job_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                hf_grdjob_index.Value = grd_job.SelectedRow.RowIndex.ToString();
                txt_jobno.Text = ((Label)grd_job.Rows[Convert.ToInt32(hf_grdjob_index.Value)].Cells[0].FindControl("Job")).Text;
                //txt_jobno.Text = grd_job.Rows[Convert.ToInt32(hf_grdjob_index.Value)].Cells[0].Text.ToString();
                fn_grdjob_Select();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void grd_evnttrack_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //public void fn_grdevnttrack_Select()
        //{

        //     if(btn_evntclear.Text== "Clear")
        //     {
        //     ddl_nxtflwupdate.Text="";
        //     grd_pndngevents.DataSource=null;
        //         grd_pndngevents.DataBind();
        //        txt_jobno.Enabled=true;
        //         txt_blno.Enabled=true;
        //         btn_evntclear.Text="Back";
        //     }
        //else
        //     {
        //    Response.Redirect("..//Corporate/FEEvent Tracking.aspx");
        //     } 
        //}

        public void fn_grdeventtrack_Select()
        {
            int index = Convert.ToInt32(hf_grdevnttrack_index.Value);


            //FEEventUpdates.txtblno.Text = GrdEvtTrack.Rows(index).Cells("grdblno").Value
            //FEEventUpdates.txtmvsl.Text = GrdEvtTrack.Rows(index).Cells("vslvoy").Value
            //FEEventUpdates.txtmetd.Text = GrdEvtTrack.Rows(index).Cells("grdmetd").Value
            //FEEventUpdates.txtmeta.Text = GrdEvtTrack.Rows(index).Cells("grdmeta").Value
            //FEEventUpdates.txtmpol.Text = GrdEvtTrack.Rows(index).Cells("grdmpol").Value
            //FEEventUpdates.txtmpod.Text = GrdEvtTrack.Rows(index).Cells("grdmpod").Value
            //Bkg = GrdEvtTrack.Rows(index).Cells("grdjobno").Value
            //FEEventUpdates.txtBkgno.Text = Bkg
            //FEEventUpdates.txtVessel.Text = txtVessel.Text
            //FEEventUpdates.txtPOL.Text = txtPOL.Text
            //FEEventUpdates.txtPOD.Text = txtPOD.Text
            //FEEventUpdates.txtETD.Text = txtETD.Text
            //FEEventUpdates.txtETA.Text = txtETA.Text
            //FEEventUpdates.txtStuffedon.Text = txtStuffedon.Text
            //FEEventUpdates.jobno = txtJobno.Text
            //FEEventUpdates.blno = txtblno.Text
            //FEEventUpdates.MdiParent = MDIParent1
            //FEEventUpdates.Show()
            //FEEventUpdates.Left = 2
            //FEEventUpdates.Top = 85
            //Me.Visible = False
            //FEEventUpdates.txtBkgno.Focus()

        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            fn_btnClear_Click();
        }
        public void fn_btnClear_Click()
        {
            try
            {
                Session["ss_grdevttrakng"] = null;
                if (btn_clear.ToolTip == "Cancel")
                {
                    fn_total_clear();
                    grd_pndngevents.DataSource = new DataTable();
                    grd_pndngevents.DataBind();
                    lstbx_cntnrnocl.Items.Clear();
                    //  ddl_nxtflwupdate.Items.Clear();
                }
                else if (btn_clear.ToolTip == "Back")
                {
                    if (Session["home"]!=null)
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
                    else if (Request.QueryString.ToString().Contains("OECSHomeEventtracking"))
                    {
                        Response.Redirect("../Home/OECSHome.aspx");
                    }

                    else
                    {
                        this.Response.End();
                    }
                } 
               
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

            
        }
        public void fn_total_clear()
        {
            txt_jobno.Text = "";
            grd_evnttrack.DataSource = new DataTable();
            grd_evnttrack.DataBind();
            txt_vessel.Text = "";
            txt_etdsailed.Text = "";
            txt_pol.Text = "";
            txt_pod.Text = "";
            txt_etaarrvd.Text = "";
            txt_agent.Text = "";
            txt_liner.Text = "";
            txt_MBLstatus.Text = "";
            txt_blno.Text = "";
            txt_jobno.Enabled = true;
            txt_blno.Enabled = true;
            btn_clear.Text = "Back";

            btn_clear.ToolTip = "Back";
            btn_clear1.Attributes["class"] = "btn ico-back";
            txt_emnodate.Text = "";
            txt_stuffon.Text = "";
            txt_jobremarks.Text = "";
            lstbx_cntnrnocl.Items.Clear();
        }

        protected void grd_evnttrack_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName != "Page")
            {
                ImageButton img_btn = (ImageButton)e.CommandSource;
                GridViewRow gvr = (GridViewRow)img_btn.NamingContainer;
                hf_grdevnttrack_index.Value = gvr.RowIndex.ToString();
                string blno = grd_evnttrack.Rows[Convert.ToInt32(hf_grdevnttrack_index.Value)].Cells[2].Text.ToString();
                string bkngno = grd_evnttrack.Rows[Convert.ToInt32(hf_grdevnttrack_index.Value)].Cells[1].Text.ToString();

                if (e.CommandName == "Select")
                {
                    Response.Redirect("../ForwardExports/EventUpdates.aspx?BLNo=" + blno + "&BookingNo=" + bkngno + "&Jobno=" + txt_jobno.Text.ToString());
                }
            }
        }

        protected void btn_exprtexcel_Click(object sender, EventArgs e)
        {
            fn_btnexprt_Click();
        }
        public void fn_btnexprt_Click()
        {
            try
            {
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 573, 3, Convert.ToInt32(Session["LoginBranchid"]), "/Excel");
                string Str_Title = Session["LoginDivisionName"].ToString() + "-" + Session["LoginBranchName"].ToString();
                string Filename = Session["LoginDivisionName"].ToString() + "-" + Session["LoginBranchName"].ToString();
                if (grd_evnttrack.Rows.Count > 0)
                {
                    string strtemp = "";
                    strtemp = Utility.Fn_ExportExcel(grd_evnttrack, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Str_Title + "</td></tr>");
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
                    Response.Buffer = true;
                    Response.Charset = "UTF-8";
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.Write(strtemp);
                    Response.End();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_exprtexcel, typeof(Button), "Valid", "alertify.alert('Data not Avaliable');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

            //    if(grd_evnttrack.Rows.Count > 0)
            //    {
            //    Dim cc As New ExportExcel
            //    Try
            //        Dim excelobj As New GrdToExcel
            //        excelobj.StrHead = sp
            //        excelobj.StrSubHead = Login.cmbDivision.Text & " - " & Login.cmbBranch.Text
            //        excelobj.ConvertExcel(GrdEvtTrack)
            //        excelobj.Close()
            //        'cc.createfileOds(GrdEvtTrack, sp, Login.cmbDivision.Text & " - " & Login.cmbBranch.Text)
            //    Catch ex As Exception
            //        Try
            //            ' excelobj.Close()
            //            cc.createfileOds(GrdEvtTrack, sp, Login.cmbDivision.Text & " - " & Login.cmbBranch.Text)
            //        Catch ex1 As Exception
            //            'excelobj.Close()
            //            MsgBox("Excel Not Found")
            //            Exit Try
            //        End Try

            //    End Try
            //Else
            //    MsgBox("Data not Avaliable")
            //    Exit Sub
            //    }
        }

        protected void btn_evntclear_Click(object sender, EventArgs e)
        {
            if (btn_evntclear.ToolTip == "Clear")
            {

                grd_pndngevents.DataSource = new DataTable(); ;
                grd_pndngevents.DataBind();
                txt_jobno.Enabled = true;
                txt_blno.Enabled = true;
               // btn_evntclear.Text = "Back";
                btn_evntclear.ToolTip = "Back";
                btn_evntclear1.Attributes["class"] = "btn ico-back";

               
            }
            else if (btn_clear.ToolTip == "Cancel")
            {
                fn_total_clear();
                grd_pndngevents.DataSource = new DataTable();
                grd_pndngevents.DataBind();
                lstbx_cntnrnocl.Items.Clear();
                ddl_nxtflwupdate.Items.Clear();
                btn_clear.Text = "Back";

                btn_clear.ToolTip = "Back";
                btn_clear1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
        }

        protected void ddl_nxtflwupdate_SelectedIndexChanged(object sender, EventArgs e)
        {

            fn_ddlnxtflw_Select();
        }
        public void fn_ddlnxtflw_Select()
        {
            try
            {
                if (ddl_nxtflwupdate.Text != "")
                {
                    DataTable obj_dt = new DataTable();
                    DataAccess.ForwardingExports.JobInfo obj_da_FEJobInfo = new DataAccess.ForwardingExports.JobInfo();
                    obj_dt = obj_da_FEJobInfo.Geteventsforfollowupdates(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToDateTime(Utility.fn_ConvertDate(ddl_nxtflwupdate.Text.ToString())), Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pndngevents.DataSource = obj_dt;
                    grd_pndngevents.DataBind();
                }
                else
                {
                    string message ="Invalid Entry";
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../FormMain.aspx','_top');", true);
            }
        }

        protected void grd_pndngevents_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable obj_Dt = new DataTable();
            DataAccess.ForwardingExports.JobInfo obj_da_FEJobInfo = new DataAccess.ForwardingExports.JobInfo();
            try
            {
                if (grd_pndngevents.Rows.Count > 0)
                {

                    hf_grdpndngevents_index.Value = grd_pndngevents.SelectedRow.RowIndex.ToString();
                    txt_jobno.Text = grd_pndngevents.Rows[Convert.ToInt32(hf_grdpndngevents_index.Value)].Cells[0].Text.ToString();
                    txt_blno.Enabled = false;
                    fn_txtjob_Click();
                    fn_enblstatus();
                    txt_blno.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }


        }

        protected void txt_blno_TextChanged(object sender, EventArgs e)
        {
            fn_blno_Txtchange();
            txt_jobno.Enabled = false;

        }
        public void fn_blno_Txtchange()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                DataAccess.ForwardingExports.BLDetails obj_da_febl = new DataAccess.ForwardingExports.BLDetails();
                obj_dt = obj_da_febl.GetBLDetails(txt_blno.Text.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dt.Rows.Count > 0)
                {
                    txt_jobno.Text = obj_dt.Rows[0]["jobno"].ToString();
                    fn_txtjob_Click();
                    fn_enblstatus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(txt_blno, typeof(TextBox), "Valid", "alertify.alert('BL # does not exists');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../FormMain.aspx','_top');", true);
            }
        }

        protected void grd_job_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblVessel = (Label)e.Row.FindControl("Vessel");
                string tooltip = lblVessel.Text;
                e.Row.Cells[2].Attributes.Add("title", tooltip);

                Label lblMBL = (Label)e.Row.FindControl("MBL");
                string tooltip1 = lblMBL.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip1);

                Label lblPOL = (Label)e.Row.FindControl("POL");
                string tooltip2 = lblPOL.Text;
                e.Row.Cells[5].Attributes.Add("title", tooltip2);

                Label lblPOD = (Label)e.Row.FindControl("POD");
                string tooltip3 = lblPOD.Text;
                e.Row.Cells[6].Attributes.Add("title", tooltip3);

                Label lblFD = (Label)e.Row.FindControl("FD");
                string tooltip4 = lblFD.Text;
                e.Row.Cells[7].Attributes.Add("title", tooltip4);

                Label lblMLO = (Label)e.Row.FindControl("MLO");
                string tooltip5 = lblMLO.Text;
                e.Row.Cells[8].Attributes.Add("title", tooltip5);


                Label lblSailingsenton = (Label)e.Row.FindControl("Sailingsenton");
                string tooltipSailingsenton = lblSailingsenton.Text;
                e.Row.Cells[9].Attributes.Add("title", tooltipSailingsenton);

                Label lblJob = (Label)e.Row.FindControl("Job");
                string tooltipjob = lblJob.Text;
                e.Row.Cells[0].Attributes.Add("title", tooltipjob);

                Label lblETA = (Label)e.Row.FindControl("ETA");
                string tooltipETA = lblETA.Text;
                e.Row.Cells[4].Attributes.Add("title", tooltipETA);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_job, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_job_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_job.PageIndex = e.NewPageIndex;
            if (ddl_nxtflwupdate.SelectedValue == "0")
            {
                // ddl_nxtflwupdate.Items.Clear();
                fn_ddl_nxtfllwupload();
            }
            fn_jobno_Click();
        }

        protected void grd_pndngevents_PreRender(object sender, EventArgs e)
        {
            if (grd_pndngevents.Rows.Count > 0)
            {
                grd_pndngevents.UseAccessibleHeader = true;
                grd_pndngevents.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}