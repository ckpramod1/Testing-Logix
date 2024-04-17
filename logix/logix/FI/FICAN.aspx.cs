using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using logix;
using System.IO;

namespace logix.FI
{
    public partial class FICAN : System.Web.UI.Page
    {
        string str_FornName = "", str_Uiid = "";
        string sendqry;
        string ftpFullPath;
        string type;
        string Filename;
        string str_subject;
        string mailsub;

        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterEmployee obj_da_emp = new DataAccess.Masters.MasterEmployee();
        DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
        DataAccess.ForwardingImports.BLDetails obj_da_bldetails = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.Message4Booking obj_da_msg = new DataAccess.Message4Booking();
        DataAccess.ForwardingImports.JobInfo obj_da_fijob = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.Accounts.Approval appobj1 = new DataAccess.Accounts.Approval();
        DataAccess.Accounts.Invoice obj_da_inv = new DataAccess.Accounts.Invoice();

        DataAccess.ForwardingImports.BLDetails bldetailsobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.Masters.MasterCustomer CustObj = new DataAccess.Masters.MasterCustomer();

        DataAccess.Masters.MasterCustomer obj_da_cust = new DataAccess.Masters.MasterCustomer();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_da_log.GetDataBase(Ccode);
                obj_da_emp.GetDataBase(Ccode);
                obj_da_can.GetDataBase(Ccode);
                obj_da_bldetails.GetDataBase(Ccode);
                obj_da_BL.GetDataBase(Ccode);
                obj_da_msg.GetDataBase(Ccode);
                obj_da_fijob.GetDataBase(Ccode);


                appobj1.GetDataBase(Ccode);
                obj_da_inv.GetDataBase(Ccode);
                bldetailsobj.GetDataBase(Ccode);
                CustObj.GetDataBase(Ccode);
                obj_da_cust.GetDataBase(Ccode);
              

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/'_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (!IsPostBack == true)
            {
                //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
                //DataAccess.Masters.MasterEmployee obj_da_emp = new DataAccess.Masters.MasterEmployee();
                DataTable obj_dt = new DataTable();
                txt_imdate.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToString()).ToString();
                txt_eta.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToString()).ToString();
                txt_etb.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToString()).ToString();
                txt_mbldate.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToString()).ToString();
                txt_candate.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToString()).ToString();
                hf_empname.Value = obj_da_emp.GetEmployeeName(Convert.ToInt32(Session["LoginEmpId"]));
                hf_candtbol.Value = "false";
                btn_can.Attributes.Add("OnClick", "return IsValid('" + txt_jobno.ID + "','Jobnumber','string');");
                btn_send.Attributes.Add("OnClick", "return IsValid('" + txt_jobno.ID + "','Jobnumber','string');");
                txt_jobno.Attributes.Add("onkeypress", "return IntegerCheck(event);");

                grd_bLdtls.DataSource = new DataTable();
                grd_bLdtls.DataBind();

                grd_contnr.DataSource = new DataTable();
                grd_contnr.DataBind();
                btn_cancel.Text = "Cancel";
                txt_jobno.Focus();
                UserRights();
            }
            Mdl_job.Hide();
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
                    Utility.Fn_CheckUserRights(str_Uiid, btn_can, btn_canprfrma, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    // btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }



        protected void lbtn_jobno_Click(object sender, EventArgs e)
        {
            fn_lbtnjobno_Click();
        }

        public void fn_lbtnjobno_Click()
        {
            //DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_can.GetDetailsNew(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            if (obj_dt.Rows.Count > 0)
            {
                Mdl_job.Show();
                grd_job.Visible = true;
                grd_job.DataSource = obj_dt;
                grd_job.DataBind();

                btn_cancel.Text = "Cancel";
            }
            else
            {
                ScriptManager.RegisterStartupScript(lbtn_jobno, typeof(LinkButton), "Valid", "alertify.alert('Job Not Available');", true);
                return;
            }
            rbtn_forwarder.Checked = false;
            rbtn_cnsg.Checked = false;
            rbtn_ntfyparty.Checked = false;
        }

        protected void grd_job_SelectedIndexChanged(object sender, EventArgs e)
        {
            hf_grdjob_index.Value = grd_job.SelectedRow.RowIndex.ToString();
            txt_jobno.Text = ((Label)grd_job.Rows[Convert.ToInt32(hf_grdjob_index.Value)].Cells[0].FindControl("Job")).Text;
            //grd_job.Rows[Convert.ToInt32(hf_grdjob_index.Value)].Cells[0].Text.ToString();
            fn_grdjob_Select();
        }
        public void fn_grdjob_Select()
        {
            CANDetails();
        }
        public void CANDetails()
        {
            UserRights();
            DataTable obj_dt = new DataTable();
            DataTable obj_dtjobinfo = new DataTable();
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            //DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
            //DataAccess.ForwardingImports.BLDetails obj_da_bldetails = new DataAccess.ForwardingImports.BLDetails();
            if (txt_jobno.Text != "")
            {

                obj_dt = obj_da_can.ShowCANDetails(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(txt_jobno.Text.ToString()));
                if (obj_dt.Rows.Count == 1)
                {
                    txt_vessel.Text = obj_dt.Rows[0]["vesselname"].ToString();
                    txt_voyage.Text = obj_dt.Rows[0]["voyage"].ToString();
                    txt_eta.Text = Utility.fn_ConvertDate(obj_dt.Rows[0]["eta"].ToString()).ToString();
                    txt_etb.Text = Utility.fn_ConvertDate(obj_dt.Rows[0]["etb"].ToString()).ToString();
                    txt_mbldate.Text = Utility.fn_ConvertDate(obj_dt.Rows[0]["mbldate"].ToString()).ToString();
                    if (string.IsNullOrEmpty(obj_dt.Rows[0]["candate"].ToString()) == true)
                    {
                        hf_candtbol.Value = "false";
                        txt_candate.Enabled = true;
                        txt_candate.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToString());
                    }
                    else
                    {
                        txt_candate.Text = Utility.fn_ConvertDate(obj_dt.Rows[0]["candate"].ToString());
                        txt_candate.Enabled = false;
                        hf_candtbol.Value = "true";
                    }

                    txt_loadprt.Text = obj_dt.Rows[0]["pol"].ToString();
                    txt_dischrgprt.Text = obj_dt.Rows[0]["pod"].ToString();
                    txt_mblno.Text = obj_dt.Rows[0]["mblno"].ToString();
                    txt_MLO.Text = obj_dt.Rows[0]["mlo"].ToString();
                    txt_agent.Text = obj_dt.Rows[0]["Agent"].ToString();
                    txt_imno.Text = obj_dt.Rows[0]["imno"].ToString();
                    txt_imdate.Text = Utility.fn_ConvertDate(obj_dt.Rows[0]["imdate"].ToString()).ToString();
                    txt_cfscode.Text = obj_dt.Rows[0]["cfscode"].ToString();
                    txt_cfs.Text = obj_dt.Rows[0]["cfs"].ToString();
                    txt_vslimocode.Text = obj_dt.Rows[0]["cvslcode"].ToString();
                    btn_cancel.Text = "Cancel";

                }
                else
                {
                    ScriptManager.RegisterStartupScript(lbtn_jobno, typeof(LinkButton), "Valid", "alertify.alert('Kindly Check the Job #');", true);
                    txt_jobno.Text = "";
                    txt_jobno.Focus();
                    return;
                }
                obj_dtjobinfo = obj_da_bldetails.GetContainerDetail(Convert.ToInt32(txt_jobno.Text.ToString()), txt_jobno.Text.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtjobinfo.Rows.Count > 0)
                {
                    grd_contnr.DataSource = obj_dtjobinfo;
                    grd_contnr.DataBind();

                }
                grd_bLdtls.DataSource = new DataTable();
                grd_bLdtls.DataBind();
                rbtn_cnsg.Checked = false;
                rbtn_ntfyparty.Checked = false;
                rbtn_forwarder.Checked = false;
                txt_imdate.Enabled = false;
                txt_eta.Enabled = false;
                txt_etb.Enabled = false;
                txt_mbldate.Enabled = false;

            }
        }

        protected void txt_jobno_TextChanged(object sender, EventArgs e)
        {
            fn_grdjob_Select();
        }
        //newly added on feb06 23

        protected void btn_send_Click(object sender, EventArgs e)
        {
            fn_btnsend_Click();
        }

        public void fn_btnsend_Click()
        {
            //DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
            //DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
            //DataAccess.ForwardingImports.JobInfo obj_da_fijob = new DataAccess.ForwardingImports.JobInfo();
            //DataAccess.Message4Booking obj_da_msg = new DataAccess.Message4Booking();
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            //string str_BL;
            string str_BL4mail;
            string str_CMail;
            //string str_subject;
            string str_filename;

            string str_frmname = "";
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            int index;
            if (grd_bLdtls.Rows.Count > 0)
            {
                //strcandate = Format(dteCANDate.Value, "MM/dd/yyyy")
                if (hf_candtbol.Value == "false")
                {
                    obj_da_can.UpdateCANDate(Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_candate.Text).ToString()), Convert.ToInt32(txt_jobno.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                    txt_candate.Enabled = false;
                    hf_candtbol.Value = "true";
                }
                hf_flag.Value = "false";
                foreach (GridViewRow row in grd_bLdtls.Rows)
                {
                    index = row.RowIndex;
                    CheckBox cb = (CheckBox)row.FindControl("chk_select");
                    if (cb.Checked == true)
                    {
                        hf_flag.Value = "true";
                        DataTable dt1 = new DataTable();
                        //DataAccess.Accounts.Approval appobj1 = new DataAccess.Accounts.Approval();
                        hf_BL.Value = grd_bLdtls.Rows[index].Cells[0].Text.ToString();
                        str_BL4mail = hf_BL.Value.Replace("/", "-");
                        str_BL4mail = str_BL4mail.Replace("/", "-");
                        if (((TextBox)grd_bLdtls.Rows[index].Cells[3].FindControl("MailId")).Text != "")
                        {
                            str_CMail = ((TextBox)grd_bLdtls.Rows[index].Cells[3].FindControl("MailId")).Text;
                            if (str_CMail != "")
                            {
                                dt1 = appobj1.automailids_update(Session["StrTranType"].ToString(), Convert.ToInt32(txt_jobno.Text), grd_bLdtls.Rows[index].Cells[0].Text.ToString(), Convert.ToInt32(Session["LoginBranchid"]), str_CMail);
                            }
                        }
                        else
                        {
                            str_CMail = "";
                        }

                        string exp = "S";
                        //Session["mailfrom"] = Session["usermailid"].ToString();
                        string mailto = str_CMail;
                        string mailcontent = "Kindly find the attachment";
                        str_filename = "CAN - BL No  " + str_BL4mail;
                        index = row.RowIndex;

                        //DataAccess.Accounts.Approval appobj = new DataAccess.Accounts.Approval();
                        DataTable dt = new DataTable();
                        dt = appobj1.get_splitbl_jobinfo_grid(hf_BL.Value, Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"]), hf_gridradio.Value);
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                str_subject = "Cargo Arrival Notice & Proforma Invoice" + " - " + "JOB # : " + txt_jobno.Text + " / " + "BL # : " + hf_BL.Value + " / " + "Container # : " + dt.Rows[i]["containerno"].ToString() + " / " + dt.Rows[i]["sizetype"].ToString();
                                mailsub = str_subject;
                                string adsf = canUpload1(Convert.ToInt32(txt_jobno.Text.ToString()), hf_BL.Value, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                //         DataAccess.Accounts.Approval appobj = new DataAccess.Accounts.Approval();
                                DataTable dt_inv = new DataTable();
                                // hide on 20Feb2023 STD
                                //dt_inv = appobj.profomainvoice_report(hf_BL.Value, Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
                                //if (dt_inv.Rows.Count > 0)
                                //{
                                //    adsf = adsf + ";" + canUpload2(Convert.ToInt32(txt_jobno.Text.ToString()), hf_BL.Value, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                                //}
                                // hide on 20Feb2023 END


                                //string Filename = Session["Filename"].ToString() + ";" + Session["Filename1"].ToString();

                                //string FinalPath = Server.MapPath(@"SavePDF\" + Filename);
                                can_sendmail(dt.Rows[i]["blno"].ToString());
                                if (mailto != "")
                                {

                                    Utility.SendMail(Session["usermailid"].ToString(), mailto, mailsub, sendqry, adsf, Session["usermailpwd"].ToString(), "", Session["usermailid"].ToString());
                                    // Utility.SendMail(Session["usermailid"].ToString(), mailto, mailsub, sendqry, adsf, Session["usermailpwd"].ToString(), "", "");
                                    sendqry = "";
                                     }
                                //sendqry = "";
                            }

                        }

                        //Utility.SendMail(Session["usermailid"].ToString(), "sample", str_subject, "Kindly find the attachment", "", Session["usermailpwd"].ToString());

                        if (str_CMail != "")
                        {
                            if (rbtn_cnsg.Checked == true)
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICAN4Consignee.rpt";
                                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.jobno}=" + txt_jobno.Text.ToString() + " and {FIBLDetails.blno}=\"" + hf_BL.Value + "\"";
                                str_sp = "";
                                //str_Script += "window.open('../Reportasp/Invoicerpt.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&mailto=" + mailto + "&mailcontent=" + mailcontent + "&str_filename=" + str_filename + "&mailsub=" + mailsub + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
                            }
                            else if (rbtn_forwarder.Checked == true)
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICANsplit.rpt";
                                str_sf = "{FISplitBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FISplitBLDetails.jobno}=" + txt_jobno.Text.ToString() + " and {FISplitBLDetails.blno}=\"" + hf_BL.Value + "\"";
                                str_sp = "";
                                //str_Script += "window.open('../Reportasp/Invoicerpt.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&mailto=" + mailto + "&mailcontent=" + mailcontent + "&str_filename=" + str_filename + "&mailsub=" + mailsub + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
                            }
                            else if (rbtn_ntfyparty.Checked == true)
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICAN4Noti.rpt";
                                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.jobno}=" + txt_jobno.Text.ToString() + " and {FIBLDetails.blno}=\"" + hf_BL.Value + "\"";
                                str_sp = "";
                                //str_Script += "window.open('../Reportasp/Invoicerpt.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&mailto=" + mailto + "&mailcontent=" + mailcontent + "&str_filename=" + str_filename + "&mailsub=" + mailsub + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
                            }
                            else if (rbtn_dirctcnsg.Checked == true)
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICAN4Consignee.rpt";
                                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.jobno}=" + txt_jobno.Text.ToString() + " and {FIBLDetails.blno}=\"" + hf_BL.Value + "\"";
                                str_sp = "";
                                //str_Script += "window.open('../Reportasp/Invoicerpt.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&mailto=" + mailto + "&mailcontent=" + mailcontent + "&str_filename=" + str_filename + "&mailsub=" + mailsub + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
                            }
                            hf_bookno.Value = obj_da_BL.GetBookinkNo(hf_BL.Value, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                            obj_da_msg.InsMsg4Booking(hf_bookno.Value.ToString(), str_subject, str_CMail, "", obj_da_log.GetDate(), hf_empname.Value.ToString(), "", "", str_filename);
                            obj_da_fijob.UpdateFIEventcaninvsenton(Convert.ToInt32(txt_jobno.Text.ToString()), obj_da_log.GetDate(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                        }
                    }
                }
                ScriptManager.RegisterStartupScript(btn_send, typeof(Button), "Cargo Arrival Notice", str_Script, true);

                if (hf_flag.Value == "false")
                {
                    ScriptManager.RegisterStartupScript(btn_send, typeof(Button), "Valid", "alertify.alert('Please Select atleast a BL #');", true);
                }
                UserRights();
            }
        }
        //end

        //hided on feb 06 2023
        //protected void btn_send_Click(object sender, EventArgs e)
        //{
        //    fn_btnsend_Click();
        //}
        //public void fn_btnsend_Click()
        //{
        //    DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
        //    DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
        //    DataAccess.ForwardingImports.JobInfo obj_da_fijob = new DataAccess.ForwardingImports.JobInfo();
        //    DataAccess.Message4Booking obj_da_msg = new DataAccess.Message4Booking();
        //    DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        //    //string str_BL;
        //    string str_BL4mail;
        //    string str_CMail;
        //    string str_subject;
        //    string str_filename;

        //    string str_frmname = "";
        //    string str_RptName = "";
        //    string str_sp = "";
        //    string str_sf = "";
        //    string str_Script = "";
        //    int index;
        //    if (grd_bLdtls.Rows.Count > 0)
        //    {
        //        //strcandate = Format(dteCANDate.Value, "MM/dd/yyyy")
        //        if (hf_candtbol.Value == "false")
        //        {
        //            obj_da_can.UpdateCANDate(Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_candate.Text).ToString()), Convert.ToInt32(txt_jobno.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
        //            txt_candate.Enabled = false;
        //            hf_candtbol.Value = "true";
        //        }
        //        hf_flag.Value = "false";
        //        foreach (GridViewRow row in grd_bLdtls.Rows)
        //        {
        //            index = row.RowIndex;
        //            CheckBox cb = (CheckBox)row.FindControl("chk_select");
        //            if (cb.Checked == true)
        //            {
        //                hf_flag.Value = "true";
        //                hf_BL.Value = grd_bLdtls.Rows[index].Cells[0].Text.ToString();
        //                str_BL4mail = hf_BL.Value.Replace("/", "-");
        //                str_BL4mail = str_BL4mail.Replace("/", "-");
        //                if (((TextBox)grd_bLdtls.Rows[index].Cells[3].FindControl("MailId")).Text != "")
        //                {
        //                    str_CMail = ((TextBox)grd_bLdtls.Rows[index].Cells[3].FindControl("MailId")).Text;
        //                }
        //                else
        //                {
        //                    str_CMail = "";
        //                }

        //                string exp = "S";
        //                //Session["mailfrom"] = Session["usermailid"].ToString();
        //                string mailto = str_CMail;
        //                string mailcontent = "Kindly find the attachment";
        //                str_filename = "CAN - BL No  " + str_BL4mail;
        //                str_subject = "Cargo Arrival Notice & Proforma Invoice" + " //BL No." + hf_BL.Value + " //Container No." + grd_contnr.Rows[index].Cells[0].Text.ToString() + " ";
        //                string mailsub = str_subject;
        //                string adsf = canUpload1(Convert.ToInt32(txt_jobno.Text.ToString()), hf_BL.Value, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
        //                can_sendmail();
        //                Utility.SendMail(Session["usermailid"].ToString(), mailto, mailsub, sendqry, adsf, Session["usermailpwd"].ToString(), "", "");


        //                //Utility.SendMail(Session["usermailid"].ToString(), "sample", str_subject, "Kindly find the attachment", "", Session["usermailpwd"].ToString());

        //                if (str_CMail != "")
        //                {
        //                    if (rbtn_cnsg.Checked == true)
        //                    {
        //                        str_frmname = "Cargo Arrival Notice";
        //                        str_RptName = "FICAN4Consignee.rpt";
        //                        str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.jobno}=" + txt_jobno.Text.ToString() + " and {FIBLDetails.blno}=\"" + hf_BL.Value + "\"";
        //                        str_sp = "";
        //                        str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&mailto=" + mailto + "&mailcontent=" + mailcontent + "&str_filename=" + str_filename + "&mailsub=" + mailsub + "&" + this.Page.ClientQueryString + "','_blank'); ";
        //                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
        //                    }
        //                    else if (rbtn_forwarder.Checked == true)
        //                    {
        //                        str_frmname = "Cargo Arrival Notice";
        //                        str_RptName = "FICANsplit.rpt";
        //                        str_sf = "{FISplitBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FISplitBLDetails.jobno}=" + txt_jobno.Text.ToString() + " and {FISplitBLDetails.blno}=\"" + hf_BL.Value + "\"";
        //                        str_sp = "";
        //                        str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&mailto=" + mailto + "&mailcontent=" + mailcontent + "&str_filename=" + str_filename + "&mailsub=" + mailsub + "&" + this.Page.ClientQueryString + "','_blank'); ";
        //                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
        //                    }
        //                    else if (rbtn_ntfyparty.Checked == true)
        //                    {
        //                        str_frmname = "Cargo Arrival Notice";
        //                        str_RptName = "FICAN4Noti.rpt";
        //                        str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.jobno}=" + txt_jobno.Text.ToString() + " and {FIBLDetails.blno}=\"" + hf_BL.Value + "\"";
        //                        str_sp = "";
        //                        str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&mailto=" + mailto + "&mailcontent=" + mailcontent + "&str_filename=" + str_filename + "&mailsub=" + mailsub + "&" + this.Page.ClientQueryString + "','_blank'); ";
        //                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
        //                    }
        //                    else if (rbtn_dirctcnsg.Checked == true)
        //                    {
        //                        str_frmname = "Cargo Arrival Notice";
        //                        str_RptName = "FICAN4Consignee.rpt";
        //                        str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.jobno}=" + txt_jobno.Text.ToString() + " and {FIBLDetails.blno}=\"" + hf_BL.Value + "\"";
        //                        str_sp = "";
        //                        str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&mailto=" + mailto + "&mailcontent=" + mailcontent + "&str_filename=" + str_filename + "&mailsub=" + mailsub + "&" + this.Page.ClientQueryString + "','_blank'); ";
        //                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
        //                    }
        //                    hf_bookno.Value = obj_da_BL.GetBookinkNo(hf_BL.Value, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
        //                    obj_da_msg.InsMsg4Booking(hf_bookno.Value.ToString(), str_subject, str_CMail, "", obj_da_log.GetDate(), hf_empname.Value.ToString(), "", "", str_filename);
        //                    obj_da_fijob.UpdateFIEventcaninvsenton(Convert.ToInt32(txt_jobno.Text.ToString()), obj_da_log.GetDate(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
        //                }
        //            }
        //        }
        //        ScriptManager.RegisterStartupScript(btn_send, typeof(Button), "Cargo Arrival Notice", str_Script, true);

        //        if (hf_flag.Value == "false")
        //        {
        //            ScriptManager.RegisterStartupScript(btn_send, typeof(Button), "Valid", "alertify.alert('Please Select atleast a BL #');", true);
        //        }
        //        UserRights();
        //    }
        //}

        //end
        protected void btn_canprfrma_Click(object sender, EventArgs e)
        {
            fn_btncanprfrma_Click();
        }

        public void fn_btncanprfrma_Click()
        {
            DataTable obj_dtcan = new DataTable();
            DataTable obj_dt = new DataTable();
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            //DataAccess.ForwardingImports.JobInfo obj_da_fijob = new DataAccess.ForwardingImports.JobInfo();
            //DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
            //DataAccess.ForwardingImports.BLDetails obj_da_bldetails = new DataAccess.ForwardingImports.BLDetails();
            obj_da_can.UpdateCANDate(Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_candate.Text.ToString())), Convert.ToInt32(txt_jobno.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

            string exp = "";
            string str_Script = "";

            int index;
            if (rbtn_forwarder.Checked == true)
            {
                obj_dtcan = obj_da_can.GetBLDetails(Convert.ToInt32(txt_jobno.Text.ToString()), "FO", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            }
            else if (rbtn_dirctcnsg.Checked == true)
            {
                obj_dtcan = obj_da_can.GetBLDetails(Convert.ToInt32(txt_jobno.Text.ToString()), "DC", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            }
            else
            {
                obj_dtcan = obj_da_can.GetBLDetails(Convert.ToInt32(txt_jobno.Text.ToString()), "FI", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            }

            if (obj_dtcan.Rows.Count > 0)
            {
                foreach (GridViewRow row in grd_bLdtls.Rows)
                {
                    string cont = "";
                    string cont1 = "";
                    string cont2 = "";

                    string str_frmname = "";
                    string str_RptName = "";
                    string str_sp = "";
                    string str_sf = "";
                    index = row.RowIndex;

                    CheckBox cb = (CheckBox)row.FindControl("chk_select");
                    if (cb.Checked == true)
                    {
                        hf_BL.Value = obj_dtcan.Rows[index][1].ToString();
                        obj_dt = obj_da_bldetails.GetContainerDetail(Convert.ToInt32(txt_jobno.Text.ToString()), hf_BL.Value.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

                        for (int l = 0; l <= obj_dt.Rows.Count - 1; l++)
                        {

                            cont = cont + " , " + obj_dt.Rows[l][0].ToString() + "/" + obj_dt.Rows[l][1].ToString() + "/" + obj_dt.Rows[l][2].ToString();
                        }
                        if (cont.Length > 3)
                        {
                            cont = cont.Remove(0, 3);
                        }
                        if (cont.Length > 210)
                        {
                            cont1 = cont.Substring(0, 210);
                            cont = cont.Remove(0, 210);
                            if (cont.Length > 245)
                            {
                                cont2 = cont.Substring(0, 210);
                                cont = cont.Remove(0, 210);
                            }
                            else
                            {
                                cont2 = cont.Substring(0, cont.Length);
                            }
                        }
                        else
                        {
                            cont1 = cont.Substring(0, cont.Length);
                        }
                        if (rbtn_cnsg.Checked == true)
                        {
                            if (hid_canprorpt.Value == "Y")
                            {
                                str_Script += "window.open('../Reportasp/BL4CANprofoma.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "CT" + "&TOtype=" + "consignee" + "','','');";

                            }
                            else
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICanInvoice4Consignee.rpt";
                                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.blno}=\"" + hf_BL.Value + "\"";
                                str_sp = "cont1=" + cont1 + "~cont2=" + cont2;
                                string pageurl = "../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "";
                                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                
                            }
                            obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
                            //Session["str_sfs"] = str_sf;
                            //Session["str_sp"] = str_sp;
                            // btn_canprfrma.Attributes.Add("onclick", "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "', '', 'menubar=1,resizable=1,fullscreen=no, scrollbars=auto')");
                            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", str_Script, true);
                        }
                        else if (rbtn_forwarder.Checked == true)
                        {
                            if (hid_canprorpt.Value == "Y")
                            {
                                str_Script += "window.open('../Reportasp/BL4CANprofoma.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "CT" + "&TOtype=" + "forwarder" + "','','');";

                            }
                            else
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICanInvoice4Forwarder.rpt";
                                str_sf = "{FISplitBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FISplitBLDetails.blno}=\"" + hf_BL.Value + "\"";
                                str_sp = "cont1=" + cont1 + "~cont2=" + cont2;
                                string pageurl = "../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "";
                                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                
                            }
                            obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
                            //Session["str_sfs"] = str_sf;
                            //Session["str_sp"] = str_sp;
                            // logix.CommanClass.
                        }
                        else if (rbtn_ntfyparty.Checked == true)
                        {
                            if (hid_canprorpt.Value == "Y")
                            {
                                str_Script += "window.open('../Reportasp/BL4CANprofoma.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "CT" + "&TOtype=" + "notifyparty" + "','','');";

                            }
                            else
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICanInvoice4NP.rpt";
                                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.blno}=\"" + hf_BL.Value + "\"";
                                str_sp = "cont1=" + cont1 + "~cont2=" + cont2;
                                string pageurl = "../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "";
                                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                //logix.Tools.ReportView.
                            }
                            obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
                            //Session["str_sfs"] = str_sf;
                            //Session["str_sp"] = str_sp;
                            btn_canprfrma.Attributes.Add("onclick", "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "', '', '', 'height=200,width=400'");
                        }
                        else if (rbtn_dirctcnsg.Checked == true)
                        {
                            if (hid_canprorpt.Value == "Y")
                            {
                                str_Script += "window.open('../Reportasp/BL4CANprofoma.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "CT" + "&TOtype=" + "consignee" + "','','');";

                            }
                            else
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICanInvoice4Consignee.rpt";
                                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.blno}=\"" + hf_BL.Value + "\"";
                                str_sp = "cont1=" + cont1 + "~cont2=" + cont2;
                                string pageurl = "../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "";
                                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                
                            }
                            obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
                            //Session["str_sfs"] = str_sf;
                            //Session["str_sp"] = str_sp;

                        }
                    }
                    obj_da_fijob.UpdateFIEventcaninvsenton(Convert.ToInt32(txt_jobno.Text.ToString()), obj_da_log.GetDate(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                }
                ScriptManager.RegisterStartupScript(btn_canprfrma, typeof(Button), "Cargo Arrival Notice", str_Script, true);
            }
            UserRights();
        }

        protected void btn_can_Click(object sender, EventArgs e)
        {
            fn_btncan_Click();
        }
        public void fn_btncan_Click()
        {
            string str_BL4mail;
            string str_BL;
            int index;

            string str_frmname = "";
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            string exp = "";
            string str_CMail;
            string str_subject;
            //DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
            //DataAccess.Accounts.Invoice obj_da_inv = new DataAccess.Accounts.Invoice();
            //DataAccess.ForwardingImports.JobInfo obj_da_fijob = new DataAccess.ForwardingImports.JobInfo();
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            DataTable obj_dt = new DataTable();
            if (grd_bLdtls.Rows.Count > 0)
            {
                //strcandate = Format(dteCANDate.Value, "MM/dd/yyyy")
                if (hf_candtbol.Value == "false")
                {
                    obj_da_can.UpdateCANDate(Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_candate.Text.ToString())), Convert.ToInt32(txt_jobno.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                    txt_candate.Enabled = false;
                    hf_candtbol.Value = "true";
                }
                obj_dt = obj_da_inv.GetInvNoFromJobno(Convert.ToInt32(txt_jobno.Text), "FI", Convert.ToInt32(Session["LoginBranchid"]));
                hf_flag.Value = "false";
                foreach (GridViewRow row in grd_bLdtls.Rows)
                {
                    index = row.RowIndex;

                    CheckBox cb = (CheckBox)row.FindControl("chk_select");
                    if (cb.Checked == true)
                    {

                        hf_flag.Value = "true";
                        hf_BL.Value = grd_bLdtls.Rows[index].Cells[0].Text.ToString();
                        str_BL4mail = hf_BL.Value.Replace("/", "-");

                        //string mailsub = txt_jobno.Text.ToString();
                        if (((TextBox)grd_bLdtls.Rows[index].Cells[3].FindControl("MailId")).Text != "")
                        {
                            str_CMail = ((TextBox)grd_bLdtls.Rows[index].Cells[3].FindControl("MailId")).Text;
                        }
                        else
                        {
                            str_CMail = "";
                        }


                        //Session["mailfrom"] = Session["usermailid"].ToString();
                        string mailto = str_CMail;
                        string mailcontent = "Kindly find the attachment";

                        //str_subject = "Cargo Arrival Notice - BL # " + hf_BL.Value + " - " + grd_bLdtls.Rows[index].Cells[0].Text.ToString();
                        //str_subject = "Cargo Arrival Notice & Proforma Invoice" + " //BL No." + hf_BL.Value + " //Container No." + grd_contnr.Rows[index].Cells[0].Text.ToString() + " ";
                        //string mailsub = str_subject;
                        //string adsf = canUpload1(Convert.ToInt32(txt_jobno.Text.ToString()), hf_BL.Value, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        //can_sendmail();
                        //Utility.SendMail(Session["usermailid"].ToString(), mailto, mailsub, sendqry, adsf, Session["usermailpwd"].ToString(), "", "");

                        if (rbtn_cnsg.Checked == true)
                        {
                            if (hid_canrpt.Value == "Y")
                            {
                                str_Script += "window.open('../Reportasp/BL4CANrpt.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "C" + "&TOtype=" + "consignee" + "','','');";

                            }
                            else
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICAN4Consignee.rpt";
                                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.jobno}=" + txt_jobno.Text.ToString() + " and {FIBLDetails.blno}=\"" + hf_BL.Value + "\"";
                                str_sp = "";
                                string pageurl = "../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "";
                                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&" + this.Page.ClientQueryString + "','_blank'); ";
                            }
                            obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
                            //Session["str_sfs"] = str_sf;
                            //Session["str_sp"] = str_sp;
                        }

                        else if (rbtn_forwarder.Checked == true)
                        {
                            //if (hid_canFWrpt.Value == "Y")
                            //{
                            //    DataSet ds;
                            //    DataAccess.Reportasp da_obj_rptasp = new DataAccess.Reportasp();
                            //    ds = da_obj_rptasp.GetCANFWRpt(Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), "C", hf_BL.Value);
                            //    if (ds.Tables.Count > 0)
                            //    {
                            //        DataTable dt = ds.Tables[0];
                            //        if (dt.Rows.Count > 0)
                            //        {
                            //            if (dt.Rows.Count > 1)
                            //            {
                            //                str_Script += "window.open('../Reportasp/BL4FWCANrpt.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "C" + "&TOtype=" + "forwarder" + "&count=" + dt.Rows.Count + "','','');";
                            //                str_Script += "window.open('../Reportasp/ForwarderBL4CANrpt.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "C" + "&TOtype=" + "forwarder" + "','','');";

                            //            }
                            //            else if (dt.Rows.Count == 1)
                            //            {
                            //                str_Script += "window.open('../Reportasp/BL4FWCANrpt.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "C" + "&TOtype=" + "forwarder" + "&count=" + dt.Rows.Count + "','','');";

                            //            }
                            //        }
                            //    }
                            //}
                            if (hid_canFWrpt.Value == "Y")
                            {
                                str_Script += "window.open('../Reportasp/ForwarderBL4CANrpt.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "C" + "&TOtype=" + "forwarder" + "','','');";
                            }

                           //if (hid_canFWrptCR.Value == "Y")
                           // {
                           //     str_frmname = "Cargo Arrival Notice";
                           //     str_RptName = "FICANsplit.rpt";
                           //     str_sf = "{FISplitBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FISplitBLDetails.jobno}=" + txt_jobno.Text.ToString() + " and {FISplitBLDetails.blno}=\"" + hf_BL.Value + "\"";
                           //     str_sp = "";
                           //     string pageurl = "../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "";
                           //     str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&" + this.Page.ClientQueryString + "','_blank'); ";
                           // }

                        }
                        //else if (rbtn_forwarder.Checked == true)
                        //{
                        //    //if (hid_canrpt.Value == "Y")
                        //    //{
                        //    //    str_Script += "window.open('../Reportasp/BL4CANrpt.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "C" + "&TOtype=" + "forwarder" + "','','');";

                        //    //}
                        //    //else
                        //    //{
                        //    str_frmname = "Cargo Arrival Notice";
                        //    str_RptName = "FICANsplit.rpt";
                        //    str_sf = "{FISplitBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FISplitBLDetails.jobno}=" + txt_jobno.Text.ToString() + " and {FISplitBLDetails.blno}=\"" + hf_BL.Value + "\"";
                        //    str_sp = "";
                        //    string pageurl = "../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "";
                        //    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&" + this.Page.ClientQueryString + "','_blank'); ";
                        //    //}
                        //    obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
                        //    //Session["str_sfs"] = str_sf;
                        //    //Session["str_sp"] = str_sp;
                        //}
                        else if (rbtn_ntfyparty.Checked == true)
                        {
                            if (hid_canrpt.Value == "Y")
                            {
                                str_Script += "window.open('../Reportasp/BL4CANrpt.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "C" + "&TOtype=" + "notifyparty" + "','','');";

                            }
                            else
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICAN4Noti.rpt";
                                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.jobno}=" + txt_jobno.Text.ToString() + " and {FIBLDetails.blno}=\"" + hf_BL.Value + "\"";
                                str_sp = "";
                                string pageurl = "../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "";
                                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&" + this.Page.ClientQueryString + "','_blank'); ";
                            }
                            obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
                            //Session["str_sfs"] = str_sf;
                            //Session["str_sp"] = str_sp;
                        }
                        else if (rbtn_dirctcnsg.Checked == true)
                        {
                            if (rbtn_dirctcnsg.Checked == true && hid_canrpt.Value == "Y")
                            {
                                str_Script += "window.open('../Reportasp/BL4CANrpt.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "C" + "&TOtype=" + "consignee" + "','','');";

                            }
                            else
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICAN4Consignee.rpt";
                                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.jobno}=" + txt_jobno.Text.ToString() + " and {FIBLDetails.blno}=\"" + hf_BL.Value + "\"";
                                str_sp = "";
                                string pageurl = "../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "";
                                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&" + this.Page.ClientQueryString + "','_blank'); ";
                            }
                            obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
                            //Session["str_sfs"] = str_sf;
                            //Session["str_sp"] = str_sp;
                        }

                    }
                }
                obj_da_fijob.UpdateFIEventcaninvsenton(Convert.ToInt32(txt_jobno.Text.ToString()), obj_da_log.GetDate(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                ScriptManager.RegisterStartupScript(btn_canprfrma, typeof(Button), "Cargo Arrival Notice", str_Script, true);
                if (hf_flag.Value == "false")
                {
                    ScriptManager.RegisterStartupScript(lbtn_jobno, typeof(LinkButton), "Valid", "alertify.alert('Please Select atleast a BL #');", true);
                }
                UserRights();
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            fn_btncancel_Click();
        }
        public void fn_btncancel_Click()
        {
            if (btn_cancel.Text == "Cancel")
            {
                txtClear();
                btn_cancel.Text = "Back";
                txt_jobno.Focus();
            }
            else
            {
                this.Response.End();
            }
        }
        public void txtClear()
        {
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            txt_jobno.Text = "";
            txt_vessel.Text = "";
            txt_agent.Text = "";
            txt_cfs.Text = "";
            txt_cfscode.Text = "";
            txt_vslimocode.Text = "";
            txt_imno.Text = "";
            txt_mblno.Text = "";
            txt_MLO.Text = "";
            txt_dischrgprt.Text = "";
            txt_loadprt.Text = "";
            txt_voyage.Text = "";
            txt_eta.Text = Convert.ToDateTime(obj_da_log.GetDate()).ToString();
            txt_etb.Text = Convert.ToDateTime(obj_da_log.GetDate()).ToString();
            txt_mbldate.Text = Convert.ToDateTime(obj_da_log.GetDate()).ToString();
            txt_imdate.Enabled = true;
            txt_eta.Enabled = true;
            txt_etb.Enabled = true;
            txt_mbldate.Enabled = true;
            txt_candate.Enabled = true;
            hf_candtbol.Value = "false";
            rbtn_cnsg.Checked = false;
            rbtn_forwarder.Checked = false;
            rbtn_ntfyparty.Checked = false;
            txt_imdate.Text = "";
            txt_vslimocode.Text = "";
            //cmbBL.Items.Clear()
            txt_candate.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToString());
            grd_contnr.DataSource = new DataTable();
            grd_contnr.DataBind();
            grd_bLdtls.DataSource = new DataTable();
            grd_bLdtls.DataBind();
        }

        protected void rbtn_cnsg_CheckedChanged(object sender, EventArgs e)
        {
            fn_rbtncnsg_Checked();
        }
        public void fn_rbtncnsg_Checked()
        {
            string str_mail;
            DataTable dtEmail = new DataTable();
            DataTable Dt = new DataTable();
            DataTable obj_dt1 = new DataTable();
            DataColumn dc_col1 = new DataColumn("blno", typeof(string));
            DataColumn dc_col2 = new DataColumn("linenumber", typeof(string));
            DataColumn dc_col3 = new DataColumn("consignee", typeof(string));
            DataColumn dc_col4 = new DataColumn("consigneeid", typeof(string));

            obj_dt1.Columns.Add(dc_col1);
            obj_dt1.Columns.Add(dc_col2);
            obj_dt1.Columns.Add(dc_col3);
            obj_dt1.Columns.Add(dc_col4);

            //DataAccess.ForwardingImports.BLDetails bldetailsobj = new DataAccess.ForwardingImports.BLDetails();
            //DataAccess.Masters.MasterCustomer CustObj = new DataAccess.Masters.MasterCustomer();

            if (rbtn_cnsg.Checked == true)
            {
                grd_bLdtls.Columns[2].HeaderText = "Consignee";
                if (txt_jobno.Text != "")
                {
                    //cmbBL.Items.Clear()
                    grd_bLdtls.DataSource = null;
                    grd_bLdtls.DataBind();
                    Dt = bldetailsobj.GetBLDtJobnoNew(Convert.ToInt32(txt_jobno.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), "C");
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                        {
                            obj_dt1.Rows.Add();
                            obj_dt1.Rows[i][0] = Dt.Rows[i]["blno"].ToString();
                            if ((string.IsNullOrEmpty(Dt.Rows[i]["linenumber"].ToString()) == false) && (string.IsNullOrEmpty(Dt.Rows[i]["sublineno"].ToString()) == false))
                            {
                                if (Dt.Rows[i]["sublineno"] != "")
                                {
                                    obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString() + " / " + Dt.Rows[i]["sublineno"].ToString();
                                }
                                else
                                {
                                    obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString();
                                }
                            }
                            else
                            {
                                obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString();
                            }
                            obj_dt1.Rows[i][2] = Dt.Rows[i]["consignee"].ToString();
                            hf_nomination.Value = Dt.Rows[i]["nomination"].ToString();
                            if (hf_nomination.Value == "N")
                            {
                                dtEmail = bldetailsobj.GetCustMail4BL(obj_dt1.Rows[i][0].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                                if (dtEmail.Rows.Count > 0)
                                {
                                    str_mail = dtEmail.Rows[0]["email"].ToString() + ";" + dtEmail.Rows[0]["commailid"].ToString();
                                    if (str_mail != ";")
                                    {
                                        if (CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consigneeid"])) != "")
                                        {
                                            str_mail = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consigneeid"])) + ";" + str_mail;
                                        }
                                        str_mail = str_mail.Remove(str_mail.Length - 1, 1);
                                    }
                                    else
                                    {
                                        str_mail = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consigneeid"]));
                                    }
                                    obj_dt1.Rows[i][3] = str_mail;
                                }
                                else
                                {
                                    obj_dt1.Rows[i][3] = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consigneeid"]));
                                }
                            }
                            else
                            {
                                obj_dt1.Rows[i][3] = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consigneeid"]));
                            }
                            //obj_dt1.Rows[i][4] = true;
                        }
                        grd_bLdtls.DataSource = obj_dt1;
                        grd_bLdtls.DataBind();
                    }
                }
            }
        }

        protected void rbtn_ntfyparty_CheckedChanged(object sender, EventArgs e)
        {
            fn_rbtnntyparty_Checked();
        }
        public void fn_rbtnntyparty_Checked()
        {
            string str_mail;
            DataTable dtEmail = new DataTable();
            DataTable Dt = new DataTable();
            DataTable obj_dt1 = new DataTable();
            DataColumn dc_col1 = new DataColumn("blno", typeof(string));
            DataColumn dc_col2 = new DataColumn("linenumber", typeof(string));
            DataColumn dc_col3 = new DataColumn("consignee", typeof(string));
            DataColumn dc_col4 = new DataColumn("consigneeid", typeof(string));

            obj_dt1.Columns.Add(dc_col1);
            obj_dt1.Columns.Add(dc_col2);
            obj_dt1.Columns.Add(dc_col3);
            obj_dt1.Columns.Add(dc_col4);

            //DataAccess.ForwardingImports.BLDetails bldetailsobj = new DataAccess.ForwardingImports.BLDetails();
            //DataAccess.Masters.MasterCustomer CustObj = new DataAccess.Masters.MasterCustomer();
            if (rbtn_ntfyparty.Checked == true)
            {
                grd_bLdtls.Columns[2].HeaderText = "Notify Party";
                if (txt_jobno.Text.ToString() != "")
                {
                    //cmbBL.Items.Clear()
                    grd_bLdtls.DataSource = null;
                    grd_bLdtls.DataBind();
                    Dt = bldetailsobj.GetBLDtJobnoNew(Convert.ToInt32(txt_jobno.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), "N");
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                        {
                            obj_dt1.Rows.Add();
                            obj_dt1.Rows[i][0] = Dt.Rows[i]["blno"].ToString();
                            if ((string.IsNullOrEmpty(Dt.Rows[i]["linenumber"].ToString()) == false) && (string.IsNullOrEmpty(Dt.Rows[i]["sublineno"].ToString()) == false))
                            {
                                if (Dt.Rows[i]["sublineno"] != "")
                                {
                                    obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString() + " / " + Dt.Rows[i]["sublineno"].ToString();
                                }
                                else
                                {
                                    obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString();
                                }
                            }
                            else
                            {
                                obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString();
                            }
                            obj_dt1.Rows[i][2] = Dt.Rows[i]["notifyparty"].ToString();
                            hf_nomination.Value = Dt.Rows[i]["nomination"].ToString();
                            if (hf_nomination.Value == "N")
                            {
                                dtEmail = bldetailsobj.GetCustMail4BL(obj_dt1.Rows[i][0].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                                if (dtEmail.Rows.Count > 0)
                                {
                                    str_mail = dtEmail.Rows[0]["email"].ToString() + ";" + dtEmail.Rows[0]["commailid"].ToString();
                                    if (str_mail != ";")
                                    {
                                        if (CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["notifypartyid"])) != "")
                                        {
                                            str_mail = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["notifypartyid"])) + ";" + str_mail;
                                        }
                                        str_mail = str_mail.Remove(str_mail.Length - 1, 1);
                                    }
                                    else
                                    {
                                        str_mail = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["notifypartyid"]));
                                    }
                                    obj_dt1.Rows[i][3] = str_mail;
                                }
                                else
                                {
                                    obj_dt1.Rows[i][3] = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["notifypartyid"]));
                                }
                            }
                            else
                            {
                                obj_dt1.Rows[i][3] = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["notifypartyid"]));
                            }
                            //obj_dt1.Rows[i][4] = true;
                        }
                        grd_bLdtls.DataSource = obj_dt1;
                        grd_bLdtls.DataBind();
                    }
                }
            }
        }

        protected void rbtn_forwarder_CheckedChanged(object sender, EventArgs e)
        {
            fn_rbtnforwarder_Checked();
        }
        public void fn_rbtnforwarder_Checked()
        {
            string str_mail;
            DataTable dtEmail = new DataTable();
            DataTable Dt = new DataTable();
            DataTable obj_dt1 = new DataTable();
            DataColumn dc_col1 = new DataColumn("blno", typeof(string));
            DataColumn dc_col2 = new DataColumn("linenumber", typeof(string));
            DataColumn dc_col3 = new DataColumn("consignee", typeof(string));
            DataColumn dc_col4 = new DataColumn("consigneeid", typeof(string));

            obj_dt1.Columns.Add(dc_col1);
            obj_dt1.Columns.Add(dc_col2);
            obj_dt1.Columns.Add(dc_col3);
            obj_dt1.Columns.Add(dc_col4);

            //DataAccess.ForwardingImports.BLDetails bldetailsobj = new DataAccess.ForwardingImports.BLDetails();
            //DataAccess.Masters.MasterCustomer CustObj = new DataAccess.Masters.MasterCustomer();

            if (rbtn_forwarder.Checked == true)
            {
                grd_bLdtls.Columns[2].HeaderText = "Forwarder";
                if (txt_jobno.Text != "")
                {
                    //cmbBL.Items.Clear()
                    grd_bLdtls.DataSource = null;
                    grd_bLdtls.DataBind();
                    Dt = bldetailsobj.GetBLDtJobnoNew(Convert.ToInt32(txt_jobno.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), "F");
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                        {
                            obj_dt1.Rows.Add();
                            obj_dt1.Rows[i][0] = Dt.Rows[i]["blno"].ToString();
                            if ((string.IsNullOrEmpty(Dt.Rows[i]["linenumber"].ToString()) == false) && (string.IsNullOrEmpty(Dt.Rows[i]["sublineno"].ToString()) == false))
                            {
                                if (Dt.Rows[i]["sublineno"] != "")
                                {
                                    obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString() + " / " + Dt.Rows[i]["sublineno"].ToString();
                                }
                                else
                                {
                                    obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString();
                                }
                            }
                            else
                            {
                                obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString();
                            }
                            obj_dt1.Rows[i][2] = Dt.Rows[i]["consignee"].ToString();
                            hf_nomination.Value = Dt.Rows[i]["nomination"].ToString();
                            if (hf_nomination.Value == "N")
                            {
                                dtEmail = bldetailsobj.GetCustMail4BL(obj_dt1.Rows[i][0].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                                if (dtEmail.Rows.Count > 0)
                                {
                                    str_mail = dtEmail.Rows[0]["email"].ToString() + ";" + dtEmail.Rows[0]["commailid"].ToString();
                                    if (str_mail != ";")
                                    {
                                        if (CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consigneeid"])) != "")
                                        {
                                            str_mail = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consigneeid"])) + ";" + str_mail;
                                        }
                                        str_mail = str_mail.Remove(str_mail.Length - 1, 1);
                                    }
                                    else
                                    {
                                        str_mail = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consigneeid"]));
                                    }
                                    obj_dt1.Rows[i][3] = str_mail;
                                }
                                else
                                {
                                    obj_dt1.Rows[i][3] = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consigneeid"]));
                                }
                            }
                            else
                            {
                                obj_dt1.Rows[i][3] = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consigneeid"]));
                            }
                            //obj_dt1.Rows[i][4] = true;
                        }
                        grd_bLdtls.DataSource = obj_dt1;
                        grd_bLdtls.DataBind();
                    }
                }
            }
        }

        protected void rbtn_dirctcnsg_CheckedChanged(object sender, EventArgs e)
        {
            fn_rbtndirctcnsg_Checked();
        }
        public void fn_rbtndirctcnsg_Checked()
        {
            string str_mail;
            DataTable dtEmail = new DataTable();
            DataTable Dt = new DataTable();
            DataTable obj_dt1 = new DataTable();
            DataColumn dc_col1 = new DataColumn("blno", typeof(string));
            DataColumn dc_col2 = new DataColumn("linenumber", typeof(string));
            DataColumn dc_col3 = new DataColumn("consignee", typeof(string));
            DataColumn dc_col4 = new DataColumn("consigneeid", typeof(string));

            obj_dt1.Columns.Add(dc_col1);
            obj_dt1.Columns.Add(dc_col2);
            obj_dt1.Columns.Add(dc_col3);
            obj_dt1.Columns.Add(dc_col4);

            //DataAccess.ForwardingImports.BLDetails bldetailsobj = new DataAccess.ForwardingImports.BLDetails();
            //DataAccess.Masters.MasterCustomer CustObj = new DataAccess.Masters.MasterCustomer();

            if (rbtn_dirctcnsg.Checked == true)
            {
                grd_bLdtls.Columns[2].HeaderText = "Direct Consignee";
                if (txt_jobno.Text.ToString() != "")
                {
                    //cmbBL.Items.Clear()
                    grd_bLdtls.DataSource = null;
                    grd_bLdtls.DataBind();
                    Dt = bldetailsobj.GetBLDtJobnoNew(Convert.ToInt32(txt_jobno.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), "D");
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                        {
                            obj_dt1.Rows.Add();
                            obj_dt1.Rows[i][0] = Dt.Rows[i]["blno"].ToString();
                            if ((string.IsNullOrEmpty(Dt.Rows[i]["linenumber"].ToString()) == false) && (string.IsNullOrEmpty(Dt.Rows[i]["sublineno"].ToString()) == false))
                            {
                                if (Dt.Rows[i]["sublineno"] != "")
                                {
                                    obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString() + " / " + Dt.Rows[i]["sublineno"].ToString();
                                }
                                else
                                {
                                    obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString();
                                }
                            }
                            else
                            {
                                obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString();
                            }
                            obj_dt1.Rows[i][2] = Dt.Rows[i]["consignee"].ToString();
                            hf_nomination.Value = Dt.Rows[i]["nomination"].ToString();
                            if (hf_nomination.Value == "N")
                            {
                                dtEmail = bldetailsobj.GetCustMail4BL(obj_dt1.Rows[i][0].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                                if (dtEmail.Rows.Count > 0)
                                {
                                    str_mail = dtEmail.Rows[0]["email"].ToString() + ";" + dtEmail.Rows[0]["commailid"].ToString();
                                    if (str_mail != ";")
                                    {
                                        if (CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consigneeid"])) != "")
                                        {
                                            str_mail = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consigneeid"])) + ";" + str_mail;
                                        }
                                        str_mail = str_mail.Remove(str_mail.Length - 1, 1);
                                    }
                                    else
                                    {
                                        str_mail = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consigneeid"]));
                                    }
                                    obj_dt1.Rows[i][3] = str_mail;
                                }
                                else
                                {
                                    obj_dt1.Rows[i][3] = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consigneeid"]));
                                }
                            }
                            else
                            {
                                obj_dt1.Rows[i][3] = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consigneeid"]));
                            }
                            //obj_dt1.Rows[i][4] = true;
                        }
                        grd_bLdtls.DataSource = obj_dt1;
                        grd_bLdtls.DataBind();
                    }
                }
            }
        }

        protected void grd_bLdtls_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grd_bLdtls_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grd_bLdtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string str_mail;
                DataTable obj_dtEmail = new DataTable();
                DataTable obj_dt = new DataTable();
                //DataAccess.Masters.MasterCustomer obj_da_cust = new DataAccess.Masters.MasterCustomer();
                //DataAccess.ForwardingImports.BLDetails obj_da_bldetails = new DataAccess.ForwardingImports.BLDetails();
                if (((string.IsNullOrEmpty(e.Row.Cells[1].Text.ToString())) == false) && (string.IsNullOrEmpty(grd_bLdtls.DataKeys[e.Row.RowIndex].Values["sublineno"].ToString()) == false))
                {
                    if (grd_bLdtls.DataKeys[e.Row.RowIndex].Values["sublineno"].ToString() != "")
                    {
                        e.Row.Cells[1].Text = e.Row.Cells[1].Text.ToString() + " / " + grd_bLdtls.DataKeys[e.Row.RowIndex].Values["sublineno"].ToString();
                    }
                    else
                    {
                        e.Row.Cells[1].Text = e.Row.Cells[1].Text.ToString();
                    }
                }
                else
                {
                    e.Row.Cells[1].Text = e.Row.Cells[1].Text.ToString();
                }
                if (rbtn_ntfyparty.Checked == true)
                {
                    e.Row.Cells[2].Text = grd_bLdtls.DataKeys[e.Row.RowIndex].Values["notifyparty"].ToString();
                }
                hf_nomination.Value = grd_bLdtls.DataKeys[e.Row.RowIndex].Values["nomination"].ToString();
                if (hf_nomination.Value == "N")
                {
                    obj_dtEmail = obj_da_bldetails.GetCustMail4BL(e.Row.Cells[0].Text.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));


                    if (obj_dtEmail.Rows.Count > 0)
                    {
                        str_mail = obj_dtEmail.Rows[0]["email"].ToString() + ";" + obj_dtEmail.Rows[0]["commailid"].ToString();
                        if (rbtn_ntfyparty.Checked == true)
                        {
                            if (str_mail != ";")
                            {
                                if (obj_da_cust.GetCusMailaddrs(Convert.ToInt32(grd_bLdtls.DataKeys[e.Row.RowIndex].Values["notifypartyid"].ToString())) != "")
                                {
                                    str_mail = obj_da_cust.GetCusMailaddrs(Convert.ToInt32(grd_bLdtls.DataKeys[e.Row.RowIndex].Values["notifypartyid"].ToString())) + ";" + str_mail;

                                }
                                str_mail = str_mail.Remove(str_mail.Length - 1, 1);
                            }
                            else
                            {
                                str_mail = obj_da_cust.GetCusMailaddrs(Convert.ToInt32(grd_bLdtls.DataKeys[e.Row.RowIndex].Values["notifypartyid"].ToString()));
                            }
                            e.Row.Cells[3].Text = str_mail;
                        }
                        else
                        {
                            if (str_mail != ";")
                            {
                                if (obj_da_cust.GetCusMailaddrs(Convert.ToInt32(grd_bLdtls.DataKeys[e.Row.RowIndex].Values["consigneeid"].ToString())) != "")
                                {
                                    str_mail = obj_da_cust.GetCusMailaddrs(Convert.ToInt32(grd_bLdtls.DataKeys[e.Row.RowIndex].Values["consigneeid"].ToString())) + ";" + str_mail;

                                }
                                str_mail = str_mail.Remove(str_mail.Length - 1, 1);
                            }
                            else
                            {
                                str_mail = obj_da_cust.GetCusMailaddrs(Convert.ToInt32(grd_bLdtls.DataKeys[e.Row.RowIndex].Values["consigneeid"].ToString()));
                            }
                            e.Row.Cells[3].Text = str_mail;
                        }
                    }
                    else
                    {

                        if (rbtn_ntfyparty.Checked == true)
                        {
                            e.Row.Cells[3].Text = obj_da_cust.GetCusMailaddrs(Convert.ToInt32(grd_bLdtls.DataKeys[e.Row.RowIndex].Values["notifypartyid"].ToString()));
                        }
                        else
                        {
                            e.Row.Cells[3].Text = obj_da_cust.GetCusMailaddrs(Convert.ToInt32(grd_bLdtls.DataKeys[e.Row.RowIndex].Values["consigneeid"].ToString()));
                        }
                    }
                }
                else
                {
                    if (rbtn_ntfyparty.Checked == true)
                    {
                        e.Row.Cells[3].Text = obj_da_cust.GetCusMailaddrs(Convert.ToInt32(grd_bLdtls.DataKeys[e.Row.RowIndex].Values["notifypartyid"]));
                    }
                    else
                    {

                        e.Row.Cells[3].Text = obj_da_cust.GetCusMailaddrs(Convert.ToInt32(grd_bLdtls.DataKeys[e.Row.RowIndex].Values["consigneeid"].ToString()));
                    }
                }
            }
        }

        protected void grd_job_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblVessel = (Label)e.Row.FindControl("Vessel");
                string tooltip = lblVessel.Text;
                e.Row.Cells[2].Attributes.Add("title", tooltip);

                Label lblVoyage = (Label)e.Row.FindControl("Voyage");
                string tooltip1 = lblVoyage.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip1);

                Label lblAgent = (Label)e.Row.FindControl("Agent");
                string tooltip2 = lblAgent.Text;
                e.Row.Cells[4].Attributes.Add("title", tooltip2);

                Label lblMLO = (Label)e.Row.FindControl("MLO");
                string tooltip3 = lblMLO.Text;
                e.Row.Cells[5].Attributes.Add("title", tooltip3);

                Label lblPOL = (Label)e.Row.FindControl("POL");
                string tooltip4 = lblPOL.Text;
                e.Row.Cells[8].Attributes.Add("title", tooltip4);

                Label lblMBL = (Label)e.Row.FindControl("MBL");
                string tooltip5 = lblMBL.Text;
                e.Row.Cells[9].Attributes.Add("title", tooltip5);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_job, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_bLdtls_PreRender(object sender, EventArgs e)
        {
            if (grd_bLdtls.Rows.Count > 0)
            {
                grd_bLdtls.UseAccessibleHeader = true;
                grd_bLdtls.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_contnr_PreRender(object sender, EventArgs e)
        {
            if (grd_contnr.Rows.Count > 0)
            {
                grd_contnr.UseAccessibleHeader = true;
                grd_contnr.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        public void can_sendmail()
        {
            sendqry = sendqry + Session["Companyaddress"].ToString();
            sendqry = sendqry + "<table border=1 width=100% text=blue><tr><td align=center><FONT FACE=Arial SIZE=3 COLOR=Blue><B> CAN </B></FONT></td></tr><br>";
            sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Dear Sir / Madam,</FONT></td></tr></table><br>";
            sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>We are pleased to inform you that your valuable shipment is expected to arrive at " + txt_dischrgprt.Text + " on " + txt_candate.Text + ",Attached please find CAN & Proforma Invoice.</FONT></td></tr></table><br>";
            sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Note: Any discrepancies in Proforma Invoice must be brought to our notice within 5 days from the date of issued / before taking the delivery order.</FONT></td></tr></table><br>";
            sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Otherwise it will be presumed that the Proforma is correct and have been verified at your end.It will be considered as a Final Invoice.</FONT></td></tr></table><br>";
            sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Please send UTR details along with invoices to Finance Department for the confirmation, In case payment is made by RTGS/NEFT mode.</FONT></td></table><br>";
            sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Our finance ids for are as below</FONT></td></table><br>";
            sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>We look forward to your continued support and assuring you our prompt services at all times.</FONT></td></tr></table><br>";
            //        sendqry = sendqry & "<tr><td align=left><FONT FACE=sans-serif SIZE=2>Note : Please forward Invoice and Packing List copies for this Shipment</FONT></td></tr><br><br>"
            //sendqry = sendqry & "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Job # : " & txt_job.Text & "</FONT></td><td></td><td></td><td></td><td align=left><FONT FACE=sans-serif SIZE=2>Booking # : " & txt_book.Text & "</FONT></td></tr></table>"
            //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Job # :" + txt_jobno.Text + "</FONT></td></tr>";
            //sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>Booking # : " + txt_book.Text + "</FONT></td></tr></table>";
            //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>POR : " + por + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POL : " + pol + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POD : " + pod + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>FD : " + fd + "</FONT></td></tr></table><br>";

        }

        public string canUpload1(int jobno, string blno, int bid, int cid)
        {
            try
            { // bool retValue = false;

                Filename = Filename + "CAN" + "_" + hf_BL.Value + ".PDF";
                //hid_pdffile.Value = Filename;
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition", "attachment;filename=" + Session["Filename"].ToString() + ".PDF");
                string htmlUrl;
                int bid1 = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int cid1 = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                //if (hid_type.Value=="OSSI")
                //{
                //  htmlUrl = "http://localhost:52635/Reportasp/Invoicerpt1.aspx?Invoiceno=" + int_Refno.ToString() + "&vouyear=" + int_Vouyear.ToString() + "&total=" + total + "&trantype=" + "LT" + "&customerid=" + hid_SupplytoId.Value + "&blno=" + blno + "&bltype=" + "H" + "&header=" + "Invoice" + "&ltinvoice=" + "LTinvoice" + "&Profoma=" + "Profoma" + "&LoginDivisionId=" + Session["LoginDivisionId"].ToString() + "&LoginDivisionName=" + Session["LoginDivisionName"].ToString() + "&LoginBranchid=" + Session["LoginBranchid"].ToString() + "&FADbname=" + Session["FADbname"].ToString();

                // htmlUrl = "http://localhost:52635/Reportasp/Invoicerpt1.aspx?Invoiceno=" + int_Refno.ToString() + "&vouyear=" + int_Vouyear.ToString() + "&total=" + total + "&trantype=" + "LT" + "&customerid=" + hid_SupplytoId.Value + "&blno=" + blno + "&bltype=" + "H" + "&header=" + "Invoice" + "&ltinvoice=" + "LTinvoice" + "&Profoma=" + "" + "&LoginDivisionId=" + Session["LoginDivisionId"].ToString() + "&LoginDivisionName=" + Session["LoginDivisionName"].ToString() + "&LoginBranchid=" + Session["LoginBranchid"].ToString() + "&FADbname=" + Session["FADbname"].ToString();


                //    htmlUrl = "'https://localhost:52666/Reportasp/BL4CANrpt.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString();
                //       htmlUrl = "'http://localhost:52666/Reportasp/BL4CANrpt.aspx?jobno=+txt_jobno.Text.ToString()+&Blno=+hf_BL.Value+&Bid=+bid1+&cid=+cid1+&type=C&TOtype=consignee";
           //D.     htmlUrl = "'"+ Session["Site"].ToString() + "/Reportasp/BL4CANrpt.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "C" + "&TOtype=" + "consignee";
              //D.  htmlUrl = "'https://localhost:5260/Reportasp/BL4CANrpt.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "C" + "&TOtype=" + "consignee";
                htmlUrl = "'"+ Session["Site"].ToString() + "/Reportasp/BL4CANrpt.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "C" + "&TOtype=" + "consignee";
                
               
                //    htmlUrl = "'"+ Session["Site"].ToString() + "/Reportasp/Invoicerpt1.aspx?Invoiceno=" + int_Refno.ToString() + "&vouyear=" + int_Vouyear.ToString() + "&total=" + total + "&trantype=" + "LT" + "&customerid=" + hid_SupplytoId.Value + "&blno=" + blno + "&bltype=" + "H" + "&header=" + "Invoice" + "&ltinvoice=" + "LTinvoice" + "&Profoma=" + "" + "&LoginDivisionId=" + Session["LoginDivisionId"].ToString() + "&LoginDivisionName=" + Session["LoginDivisionName"].ToString() + "&LoginBranchid=" + Session["LoginBranchid"].ToString() + "&FADbname=" + Session["FADbname"].ToString();

                //  htmlUrl = "http://localhost:52633/Reportasp/invoicerpt1.aspx?refno=" + int_Refno + "&vouyear=" + int_Vouyear + "&tran=" + "LT" + "&jobno=" + "0" + "&bltype=" + "H" + "&LoginBranchid=" + "66" + "&Basecurr=" + Session["Basecurr"] + "&LoginDivisionName=" + Session["LoginDivisionName"].ToString() + "&StrTranType=" + "LT" + "&LoginDivisionId=" + Session["LoginDivisionId"].ToString();

                //htmlUrl = "http://localhost:52633/Reportasp/ProformaOverseaDebiCrediEDI.aspx?refno=" + Session["vouno"] + "&vouyear=" + Session["vouyear"] +"&tran"+hid_tran.Value+ "&bltype=" + Session["hid_type"] + "&LoginBranchid=" + Session["branch"];
                //htmlUrl = "'"+ Session["Site"].ToString() + "/Reportasp/ProformaOverseaDebiCrediEDI.aspx?refno=" + Grdcost.Rows[index].Cells[1].Text + "&vouyear=" + Grdcost.DataKeys[index].Values[0].ToString() + "&tran=" + hid_tran.Value + "&jobno=" + txt_job.Text + "&bltype=" + hid_type.Value + "&LoginBranchid=" + Convert.ToInt32(Session["LoginBranchid"]) + "&Basecurr=" + Session["Basecurr"] + "&LoginDivisionName=" + Session["LoginDivisionName"].ToString() + "&StrTranType=" + Session["StrTranType"].ToString() + "&LoginDivisionId=" + Session["LoginDivisionId"].ToString();
                // htmlUrl= '"+ Session["Site"].ToString() + "/Reportasp/ProformaOverseaDebiCredi.aspx?refno=86&vouyear=2018&tran=FE&jobno=15262&bltype=OSDN&type=OS+DN%2fCN&uiid=40;

                var pdfBytes = htmlToPdf.GeneratePdfFromFile(htmlUrl, null);


                ftpFullPath = Server.MapPath("~/SavePDF/");
                ftpFullPath = ftpFullPath + Filename;
                File.WriteAllBytes(ftpFullPath, pdfBytes);

                //Response.Clear();
                //  MemoryStream ms = new MemoryStream(pdfBytes);

                //  Response.Buffer = true;
                // ms.WriteTo(Response.OutputStream);

                //  ftpFullPath = ftpURL + "/" + Filename.ToString();

                //if (Directory.Exists(ftpFullPath))
                //{
                //    //Directory.CreateDirectory(filePath);
                //    foreach (string file in Directory.GetFiles(ftpFullPath))
                //    {
                //        File.Delete(file);
                //    }
                //}

                //WebRequest request = WebRequest.Create(Server.MapPath("~/SavePDF/" + pdfBytes));
                //request.Method = WebRequestMethods.Ftp.UploadFile;
                ////rptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, filePath + filename);
                ////request.Credentials = new NetworkCredential(username, password);
                //Stream reqStream = request.GetRequestStream();
                //reqStream.Close();
                //FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(new Uri(ftpFullPath));
                //ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                //ftp.KeepAlive = true;
                //ftp.UseBinary = true;
                //ftp.Method = WebRequestMethods.Ftp.UploadFile;
                //Stream ftpStream = ftp.GetRequestStream();
                //ftpStream.Write(pdfBytes, 0, pdfBytes.Length);
                //ftpStream.Close();
                //ftpStream.Dispose();
                //retValue = true;
            }
            catch (Exception ex)
            {

            }
            return ftpFullPath;
        }

        public string canUpload2(int jobno, string blno, int bid, int cid)
        {
            try
            { // bool retValue = false;
                string Filename = "";
                Filename = Filename + "Profoma" + "_" + hf_BL.Value + ".PDF";

                //hid_pdffile.Value = Filename;
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition", "attachment;filename=" + Session["Filename"].ToString() + ".PDF");
                string htmlUrl;
                string FADbname123 = Session["FADbname"].ToString();
                string branchname = Session["LoginBranchName"].ToString();
                string divisionnamereport = Session["LoginDivisionNameReport"].ToString();
                string divisionname = Session["LoginDivisionName"].ToString();
                string trantype = Session["StrTranType"].ToString();
                int bid1 = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int cid1 = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                string username = Session["LoginUserName"].ToString();
                int empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                //if (hid_type.Value=="OSSI")
                //{
                //  htmlUrl = "http://localhost:52635/Reportasp/Invoicerpt1.aspx?Invoiceno=" + int_Refno.ToString() + "&vouyear=" + int_Vouyear.ToString() + "&total=" + total + "&trantype=" + "LT" + "&customerid=" + hid_SupplytoId.Value + "&blno=" + blno + "&bltype=" + "H" + "&header=" + "Invoice" + "&ltinvoice=" + "LTinvoice" + "&Profoma=" + "Profoma" + "&LoginDivisionId=" + Session["LoginDivisionId"].ToString() + "&LoginDivisionName=" + Session["LoginDivisionName"].ToString() + "&LoginBranchid=" + Session["LoginBranchid"].ToString() + "&FADbname=" + Session["FADbname"].ToString();

                // htmlUrl = "http://localhost:52635/Reportasp/Invoicerpt1.aspx?Invoiceno=" + int_Refno.ToString() + "&vouyear=" + int_Vouyear.ToString() + "&total=" + total + "&trantype=" + "LT" + "&customerid=" + hid_SupplytoId.Value + "&blno=" + blno + "&bltype=" + "H" + "&header=" + "Invoice" + "&ltinvoice=" + "LTinvoice" + "&Profoma=" + "" + "&LoginDivisionId=" + Session["LoginDivisionId"].ToString() + "&LoginDivisionName=" + Session["LoginDivisionName"].ToString() + "&LoginBranchid=" + Session["LoginBranchid"].ToString() + "&FADbname=" + Session["FADbname"].ToString();

                //    htmlUrl = "'https://localhost:52666/Reportasp/BL4CANrpt.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString();
                //       htmlUrl = "'http://localhost:52666/Reportasp/BL4CANrpt.aspx?jobno=+txt_jobno.Text.ToString()+&Blno=+hf_BL.Value+&Bid=+bid1+&cid=+cid1+&type=C&TOtype=consignee";
                //foreach (GridViewRow row in grd_bLdtls.Rows)
                //{
                //    if (grd_bLdtls.Rows.Count > 0)
                //    {
                //int index = row.RowIndex;
                //DataAccess.Accounts.Approval appobj = new DataAccess.Accounts.Approval();
                DataTable dt = new DataTable();
                dt = appobj1.profomainvoice_report(hf_BL.Value, Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                       //D. htmlUrl = "'"+ Session["Site"].ToString() + "/Reportasp/Invoicerpt.aspx?Invoiceno=" + dt.Rows[i]["refno"].ToString() + "&vouyear=" + dt.Rows[i]["vouyear"].ToString() + "&blno=" + dt.Rows[i]["blno"].ToString() + "&bltype=" + "H" + "&header=" + "Invoice" + "&Profoma=" + "Profoma" + "&FADbname123=" + FADbname123 + "&branchname=" + branchname + "&trantype=" + trantype + "&divisionnamereport=" + divisionnamereport + "&divisionname=" + divisionname + "&cid1=" + cid1 + "&bid1=" + bid1 + "&username=" + username + "&empid=" + empid;
                    //    htmlUrl = "'https://localhost:5260/Reportasp/Invoicerpt.aspx?Invoiceno=" + dt.Rows[i]["refno"].ToString() + "&vouyear=" + dt.Rows[i]["vouyear"].ToString() + "&blno=" + dt.Rows[i]["blno"].ToString() + "&bltype=" + "H" + "&header=" + "Invoice" + "&Profoma=" + "Profoma" + "&FADbname123=" + FADbname123 + "&branchname=" + branchname + "&trantype=" + trantype + "&divisionnamereport=" + divisionnamereport + "&divisionname=" + divisionname + "&cid1=" + cid1 + "&bid1=" + bid1 + "&username=" + username + "&empid=" + empid;
                        htmlUrl = "'"+ Session["Site"].ToString() + "/Reportasp/Invoicerpt.aspx?Invoiceno=" + dt.Rows[i]["refno"].ToString() + "&vouyear=" + dt.Rows[i]["vouyear"].ToString() + "&blno=" + dt.Rows[i]["blno"].ToString() + "&bltype=" + "H" + "&header=" + "Invoice" + "&Profoma=" + "Profoma" + "&FADbname123=" + FADbname123 + "&branchname=" + branchname + "&trantype=" + trantype + "&divisionnamereport=" + divisionnamereport + "&divisionname=" + divisionname + "&cid1=" + cid1 + "&bid1=" + bid1 + "&username=" + username + "&empid=" + empid;
                       
                        //      htmlUrl = "'https://localhost:52666/Reportasp/Invoicerpt.aspx?jobno=" + txt_jobno.Text.ToString() + "&Blno=" + hf_BL.Value + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&type=" + "CT" + "&TOtype=" + "consignee";

                        //    htmlUrl = "'"+ Session["Site"].ToString() + "/Reportasp/Invoicerpt1.aspx?Invoiceno=" + int_Refno.ToString() + "&vouyear=" + int_Vouyear.ToString() + "&total=" + total + "&trantype=" + "LT" + "&customerid=" + hid_SupplytoId.Value + "&blno=" + blno + "&bltype=" + "H" + "&header=" + "Invoice" + "&ltinvoice=" + "LTinvoice" + "&Profoma=" + "" + "&LoginDivisionId=" + Session["LoginDivisionId"].ToString() + "&LoginDivisionName=" + Session["LoginDivisionName"].ToString() + "&LoginBranchid=" + Session["LoginBranchid"].ToString() + "&FADbname=" + Session["FADbname"].ToString();

                        //  htmlUrl = "http://localhost:52633/Reportasp/invoicerpt1.aspx?refno=" + int_Refno + "&vouyear=" + int_Vouyear + "&tran=" + "LT" + "&jobno=" + "0" + "&bltype=" + "H" + "&LoginBranchid=" + "66" + "&Basecurr=" + Session["Basecurr"] + "&LoginDivisionName=" + Session["LoginDivisionName"].ToString() + "&StrTranType=" + "LT" + "&LoginDivisionId=" + Session["LoginDivisionId"].ToString();

                        //htmlUrl = "http://localhost:52633/Reportasp/ProformaOverseaDebiCrediEDI.aspx?refno=" + Session["vouno"] + "&vouyear=" + Session["vouyear"] +"&tran"+hid_tran.Value+ "&bltype=" + Session["hid_type"] + "&LoginBranchid=" + Session["branch"];
                        //htmlUrl = "'"+ Session["Site"].ToString() + "/Reportasp/ProformaOverseaDebiCrediEDI.aspx?refno=" + Grdcost.Rows[index].Cells[1].Text + "&vouyear=" + Grdcost.DataKeys[index].Values[0].ToString() + "&tran=" + hid_tran.Value + "&jobno=" + txt_job.Text + "&bltype=" + hid_type.Value + "&LoginBranchid=" + Convert.ToInt32(Session["LoginBranchid"]) + "&Basecurr=" + Session["Basecurr"] + "&LoginDivisionName=" + Session["LoginDivisionName"].ToString() + "&StrTranType=" + Session["StrTranType"].ToString() + "&LoginDivisionId=" + Session["LoginDivisionId"].ToString();
                        // htmlUrl= '"+ Session["Site"].ToString() + "/Reportasp/ProformaOverseaDebiCredi.aspx?refno=86&vouyear=2018&tran=FE&jobno=15262&bltype=OSDN&type=OS+DN%2fCN&uiid=40;

                        var pdfBytes = htmlToPdf.GeneratePdfFromFile(htmlUrl, null);

                        ftpFullPath = Server.MapPath(@"SavePDF\");
                        ftpFullPath = ftpFullPath + Filename;
                        File.WriteAllBytes(ftpFullPath, pdfBytes);
                        Session["Filename1"] = Filename;
                    }
                    //    }
                    //}
                    //Response.Clear();
                    //  MemoryStream ms = new MemoryStream(pdfBytes);

                    //  Response.Buffer = true;
                    // ms.WriteTo(Response.OutputStream);

                    //  ftpFullPath = ftpURL + "/" + Filename.ToString();

                    //if (Directory.Exists(ftpFullPath))
                    //{
                    //    //Directory.CreateDirectory(filePath);
                    //    foreach (string file in Directory.GetFiles(ftpFullPath))
                    //    {
                    //        File.Delete(file);
                    //    }
                    //}

                    //WebRequest request = WebRequest.Create(Server.MapPath("~/SavePDF/" + pdfBytes));
                    //request.Method = WebRequestMethods.Ftp.UploadFile;
                    ////rptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, filePath + filename);
                    ////request.Credentials = new NetworkCredential(username, password);
                    //Stream reqStream = request.GetRequestStream();
                    //reqStream.Close();
                    //FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(new Uri(ftpFullPath));
                    //ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                    //ftp.KeepAlive = true;
                    //ftp.UseBinary = true;
                    //ftp.Method = WebRequestMethods.Ftp.UploadFile;
                    //Stream ftpStream = ftp.GetRequestStream();
                    //ftpStream.Write(pdfBytes, 0, pdfBytes.Length);
                    //ftpStream.Close();
                    //ftpStream.Dispose();
                    //retValue = true;
                }
            }
            catch (Exception ex)
            {

            }
            return ftpFullPath;
        }

        public void can_sendmail(string bl)
        {
            foreach (GridViewRow row in grd_bLdtls.Rows)
            {
                int index = row.RowIndex;
                if (grd_bLdtls.Rows.Count > 0)
                {
                    //DataAccess.Accounts.Approval appobj = new DataAccess.Accounts.Approval();
                    DataTable dt = new DataTable();
                    dt = appobj1.get_splitbl_jobinfo_grid(grd_bLdtls.Rows[index].Cells[0].Text.ToString(), Convert.ToInt32(txt_jobno.Text), Convert.ToInt32(Session["LoginBranchid"]), hf_gridradio.Value);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            if (dt.Rows[i]["blno"].ToString() == bl)
                            {
                                sendqry = sendqry + Session["Companyaddress"].ToString();
                                sendqry = sendqry + "<table border=1 width=100% text=blue><tr><td align=center><FONT FACE=Arial SIZE=3 COLOR=Grey><B> CARGO ARRIVAL NOTICE </B></FONT></td></tr><br>";
                                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Dear Sir/Madam,</FONT></td></tr></table><br>";
                                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>We are pleased to inform you that below mentioned shipment is expected to arrive at " + txt_dischrgprt.Text + " on " + txt_candate.Text + ", Please find CAN & Proforma Invoice.</FONT></td></tr></table><br>";
                                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>BL #: " + dt.Rows[i]["blno"].ToString() + " </FONT></td></tr></table><br>";
                                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Line #: " + dt.Rows[i]["linenumber"].ToString() + " " + " Subline #: " + dt.Rows[i]["sublineno"].ToString() + " </FONT></td></tr></table><br>";
                                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Vessel: " + dt.Rows[i]["vesselname"].ToString() + " " + dt.Rows[i]["voyage"].ToString() + " </FONT></td></tr></table><br>";
                                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>ETA: " + dt.Rows[i]["eta"].ToString() + "</FONT></td></tr></table><br>";
                                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>POL/POD: " + dt.Rows[i]["pol"].ToString() + " / " + dt.Rows[i]["pod"].ToString() + " </FONT></td></tr></table><br>";
                                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>MBL: " + dt.Rows[i]["mblno"].ToString() + " " + " Dt: " + dt.Rows[i]["mbldate"].ToString() + " </FONT></td></tr></table><br>";
                                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Container #: " + dt.Rows[i]["containerno"].ToString() + " / " + dt.Rows[i]["sizetype"].ToString() + "</FONT></td></tr></table><br>";
                                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>IGM #: " + dt.Rows[i]["igmno"].ToString() + " " + " Dt: " + dt.Rows[i]["igmdate"].ToString() + "</FONT></td></tr></table><br>";
                                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Note: Any discrepancies in the Proforma Invoice must be brought to our notice within 2 working days from the date of issued or before taking the delivery order.  Otherwise it will be presumed that the Proforma is correct and have been verified at your end.  It will be considered as a Tax Invoice.</FONT></td></tr></table><br>";
                                //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Otherwise it will be presumed that the Proforma is correct and have been verified at your end.It will be considered as a Tax Invoice.</FONT></td></tr></table><br>";
                                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Please send UTR details along with invoices to Finance Department for the confirmation, In case payment is made by RTGS/NEFT mode.</FONT></td></table><br>";
                                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>We look forward to your continued support and assuring you our prompt services at all times.</FONT></td></tr></table><br>";
                                //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>BL #: " + dt.Rows[i]["blno"].ToString() + " </FONT></td></tr></table><br>";
                                //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Vessel: " + dt.Rows[i]["vesselname"].ToString() + " " + dt.Rows[i]["voyage"].ToString() + " </FONT></td></tr></table><br>";
                                //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>ETA: " + dt.Rows[i]["eta"].ToString() + "</FONT></td></tr></table><br>";
                                //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>POL/POD: " + dt.Rows[i]["pol"].ToString() + " / " + dt.Rows[i]["pod"].ToString() + " </FONT></td></tr></table><br>";
                                //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>MBL: " + dt.Rows[i]["mblno"].ToString() + " Dt: " + dt.Rows[i]["mbldate"].ToString() + " </FONT></td></tr></table><br>";
                                //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Container #: " + dt.Rows[i]["containerno"].ToString() + "</FONT></td></tr></table><br>";
                                //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>IGM #: " + dt.Rows[i]["igmno"].ToString() + " Dt: " + dt.Rows[i]["igmdate"].ToString() + "</FONT></td></tr></table><br>";
                            }
                        }
                    }
                }
            }
            // sendqry = sendqry & "<tr><td align=left><FONT FACE=Tahoma SIZE=2>Note : Please forward Invoice and Packing List copies for this Shipment</FONT></td></tr><br><br>"
            //sendqry = sendqry & "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Job # : " & txt_job.Text & "</FONT></td><td></td><td></td><td></td><td align=left><FONT FACE=Tahoma SIZE=2>Booking # : " & txt_book.Text & "</FONT></td></tr></table>"
            //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>Job # :" + txt_jobno.Text + "</FONT></td></tr>";
            //sendqry = sendqry + "<tr><td align=left><FONT FACE=Tahoma SIZE=2>Booking # : " + txt_book.Text + "</FONT></td></tr></table>";
            //sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=Tahoma SIZE=2>POR : " + por + "</FONT></td><td align=left><FONT FACE=Tahoma SIZE=2>POL : " + pol + "</FONT></td><td align=left><FONT FACE=Tahoma SIZE=2>POD : " + pod + "</FONT></td><td align=left><FONT FACE=Tahoma SIZE=2>FD : " + fd + "</FONT></td></tr></table><br>";

        }


    }
}