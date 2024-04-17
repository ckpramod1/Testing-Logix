using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.FI
{
    public partial class FIDeliveryStatus : System.Web.UI.Page
    {
        string str_FornName, str_Uiid;

        DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
        DataAccess.HR.Employee obj_da_hremp = new DataAccess.HR.Employee();
        DataAccess.UserPermission obj_da_userper = new DataAccess.UserPermission();
        DataAccess.Masters.MasterCustomer obj_da_cust = new DataAccess.Masters.MasterCustomer();
        DataAccess.ForwardingImports.JobInfo obj_da_fijob = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.Masters.MasterEmployee obj_da_employee = new DataAccess.Masters.MasterEmployee();
        DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
        DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();

        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        DataAccess.Corporate obj_da_corp = new DataAccess.Corporate();

        DataAccess.ForwardingImports.ReminderNotice obj_da_reminder = new DataAccess.ForwardingImports.ReminderNotice();
        protected void Page_Load(object sender, EventArgs e)
        {


            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();download();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {


                obj_da_can.GetDataBase(Ccode);
                obj_da_hremp.GetDataBase(Ccode);
                obj_da_userper.GetDataBase(Ccode);


                obj_da_cust.GetDataBase(Ccode);
                obj_da_fijob.GetDataBase(Ccode);
                obj_da_employee.GetDataBase(Ccode);

                obj_da_invoice.GetDataBase(Ccode);
                obj_da_invoice.GetDataBase(Ccode);
                obj_da_BL.GetDataBase(Ccode);

                obj_da_reminder.GetDataBase(Ccode);
                obj_da_corp.GetDataBase(Ccode);
                obj_da_log.GetDataBase(Ccode);



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
            if (!IsPostBack == true)
            {
                bind();
                UserRights();
            }
        }

        public void bind()
        {
            DataTable obj_dtDstatus = new DataTable();
            //DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
            obj_dtDstatus = obj_da_can.GetDetails(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            grd_job.DataSource = obj_dtDstatus;
            grd_job.DataBind();
            btn_cancel.Text = "Cancel";
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
                    Utility.Fn_CheckUserRights(str_Uiid, null, btn_print, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            fn_btnsend_Click();
        }
        public void fn_btnsend_Click()
        {
            string usermail;
            string empmailadd = "";
            string custmail;
            //DataAccess.HR.Employee obj_da_hremp = new DataAccess.HR.Employee();
            //DataAccess.UserPermission obj_da_userper = new DataAccess.UserPermission();
            //DataAccess.Masters.MasterCustomer obj_da_cust = new DataAccess.Masters.MasterCustomer();
            DataTable obj_dt = new DataTable();

            if (txt_vslvoy.Text != "" && txt_agent.Text != "")
            {
                return;
            }
          //  SendDeleiveryStatus();
            usermail = obj_da_hremp.GetMailAdd(obj_da_hremp.GetEmpId(Session["LoginUserName"].ToString()));
            obj_dt = obj_da_userper.GetMLEmpid(obj_da_userper.GetMLUiid("FI", "Delivery status"), Convert.ToInt32(Session["LoginBranchid"]));
            for (int i = 0; i < obj_dt.Rows.Count - 1; i++)
            {
                empmailadd = empmailadd + obj_da_hremp.GetMailAdd(Convert.ToInt32(obj_dt.Rows[i]["Item(0)"].ToString())) + ";";
            }
            if (empmailadd != "")
            {
                empmailadd = empmailadd.Substring(0, empmailadd.Length - 1);
                Utility.SendMail(Session["usermailid"].ToString(), "sDelivery Status", hf_sendqry.Value.ToString(), "", "", Session["usermailpwd"].ToString());

            }
            custmail = obj_da_cust.GetCusMailaddrs(Convert.ToInt32(hf_fiagentid.Value));
            if (custmail != "")
            {

                custmail = custmail.Substring(0, custmail.Length - 1);
                if (custmail != "")
                {
                    Utility.SendMail(Session["usermailid"].ToString(), "Delivery Status", hf_sendqry.Value.ToString(), "", "", Session["usermailpwd"].ToString());
                }
            }
        }
        public void SendDeleiveryStatus()
        {
            hf_sendqry.Value = "";
            DataTable obj_dt = new DataTable();
            //DataAccess.ForwardingImports.JobInfo obj_da_fijob = new DataAccess.ForwardingImports.JobInfo();
            //DataAccess.Masters.MasterEmployee obj_da_employee = new DataAccess.Masters.MasterEmployee();
            //DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
            //DataAccess.Masters.MasterCustomer obj_da_cust = new DataAccess.Masters.MasterCustomer();
            //DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
            obj_dt = obj_da_invoice.GetHblInvoiceHead(ddl_hblno.SelectedValue, "FI", Convert.ToInt32(Session["LoginBranchid"]));
            if (obj_dt.Rows.Count != 0)
            {
                hf_shipper.Value = obj_dt.Rows[0]["ItemArray(4)"].ToString();
                hf_consignee.Value = obj_dt.Rows[0]["ItemArray(5)"].ToString();
                hf_pod.Value = obj_dt.Rows[0]["ItemArray(7)"].ToString();
                hf_pol.Value = obj_dt.Rows[0]["ItemArray(12)"].ToString();
                hf_fiagentid.Value = obj_dt.Rows[0]["ItemArray(10)"].ToString();
                hf_mbl.Value = obj_dt.Rows[0]["ItemArray(13)"].ToString();
            }
            hf_sCity.Value = obj_da_cust.GetCustlocation(Convert.ToInt32(hf_fiagentid.Value));
            obj_dt = obj_da_cust.RetrieveCustomerDetails(txt_agent.Text.ToString(), "Agent / Principal", hf_sCity.Value);
            if (obj_dt.Rows.Count > 0)
            {
                hf_ptc.Value = obj_dt.Rows[0]["ptc"].ToString();

            }
            hf_sCity.Value = obj_da_cust.GetCustlocation(Convert.ToInt32(hf_fiagentid.Value));
            hf_shipperadd.Value = obj_da_cust.GetCustomerAddress(txt_agent.Text.ToString(), "Agent / Principal", hf_sCity.Value);
            hf_sendqry.Value = Session["strcompanyaddress"].ToString();
            hf_sendqry.Value = hf_sendqry.Value.ToString() + "<body text=black><table width=100%><FONT FACE=tahoma ><tr><td align=left>To</td></tr><br>";
            hf_sendqry.Value = hf_sendqry.Value + "<tr><td align=left>" + txt_agent.Text + "</td></tr>";
            hf_sendqry.Value = hf_sendqry.Value + "<tr><td align=left>" + hf_shipperadd.Value + "</td></tr>";
            hf_sendqry.Value = hf_sendqry.Value + "<tr><td align=left>" + hf_sCity.Value + "</td></tr></br></table><br><br>";
            if (hf_ptc.Value == "")
            {
                hf_sendqry.Value = hf_sendqry.Value + "<table><tr><td align=left>Dear Sir / Madam</td></tr></table>";
            }
            else
            {
                hf_sendqry.Value = hf_sendqry.Value + "<table><tr><td align=left>Dear " + hf_ptc.Value + "</td></tr></table>";
            }

            hf_sendqry.Value = hf_sendqry.Value + "<table><tr><td align=left>MBL #          : " + hf_mbl.Value + "</td></tr><br>";
            hf_sendqry.Value = hf_sendqry.Value + "<tr><td align=left>Loaded At      : " + hf_pol.Value + "</td></tr><br>";
            hf_sendqry.Value = hf_sendqry.Value + "<tr><td align=left>Discharged Per : " + hf_pol.Value + "</td></tr><br>";
            hf_sendqry.Value = hf_sendqry.Value + "<tr><td align=left>Arrived On     : " + txt_eta.Text + "</td></tr><br>";
            hf_sendqry.Value = hf_sendqry.Value + "<tr><td align=left>H B/L #        : " + ddl_hblno.SelectedValue + "</td></tr><br>";
            hf_sendqry.Value = hf_sendqry.Value + "<tr><td align=left>Shipper        : " + hf_shipper.Value + "</td></tr><br>";
            hf_sendqry.Value = hf_sendqry.Value + "<tr><td align=left>Consignee      : " + hf_consignee.Value + "</td></tr></table><br>";


            hf_sendqry.Value = hf_sendqry.Value + "<table border=1><tr><td align=center>Container # </td><td align=center>Sizetype</td><td align=center>Seal #</td></tr><br>";
            obj_dt = obj_da_BL.GetContainerDetail(Convert.ToInt32(hf_jobno.Value), ddl_hblno.SelectedValue, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            if (obj_dt.Rows.Count > 0)
            {
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    hf_sendqry.Value = hf_sendqry.Value + "<tr><td align=left>" + obj_dt.Rows[i]["Item(0)"].ToString() + "</td><td align=left>" + obj_dt.Rows[i]["Item(1)"].ToString() + "</td><td align=left>" + obj_dt.Rows[i]["Item(2)"].ToString() + "</td></tr><br>";
                }
            }
            hf_sendqry.Value = hf_sendqry.Value + "</table><br>";
            hf_sendqry.Value = hf_sendqry.Value + "<table><tr><td align=left>Please be informed that we have issued  the Deliver Order to the consignee on doissuedon  after collecting the above ORGINAL/COPY BL.</td></tr></table><br><br>";
            hf_sendqry.Value = hf_sendqry.Value + "</table><table width=100% text=black><tr><td align=left>Thanks & Regards </td></tr></table><br><br><br>";
            hf_sendqry.Value = hf_sendqry.Value + "<table width=100% text=black><tr><td align=left>" + obj_da_employee.GetEmployeeName(obj_da_employee.GetEmpid(Session["LoginUserName"].ToString())) + " </td></tr></table></body></html>";
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            fn_print();
            UserRights();
        }
        public void fn_print()
        {
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            string bookingno;
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            //DataAccess.Corporate obj_da_corp = new DataAccess.Corporate();
            //DataAccess.Masters.MasterEmployee obj_da_employee = new DataAccess.Masters.MasterEmployee();
            //DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
            if (ddl_hblno.SelectedValue != "")
            {
                str_RptName = "FIDeliveryConfirm.rpt";
                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.blno}=\"" + ddl_hblno.SelectedValue + "\"";
                str_sp = "user=" + obj_da_employee.GetEmployeeName(obj_da_employee.GetEmpid(Session["LoginUserName"].ToString()));
                bookingno = obj_da_BL.GetBookinkNo(ddl_hblno.SelectedValue, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                obj_da_corp.UpdShipmentStatus(bookingno, "FI", Convert.ToInt32(Session["LoginBranchid"]), "DeliveryConfirm");
                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_Script = "window.open('../Reportasp/FIDeliveryConfirmRpt.aspx?bid=" + Convert.ToInt32(Session["LoginBranchid"]) + "&blno=" + ddl_hblno.SelectedValue + "&" + this.Page.ClientQueryString + "','','');";

                ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "FinalNotice", str_Script, true);
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 117, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_hblno.SelectedValue);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.Text=="Cancel")
           {
               txtClear();
           }
           else
           {
               //this.Response.End();

               //if (Session["StrTranType"].ToString() == "FI")
               //{
               //    // headerlable1.InnerText = "OceanImports";
               //    Response.Redirect("../Home/OICSHome.aspx");
               //}



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
        public void txtClear()
        {
            txt_vslvoy.Text = "";
            txt_agent.Text = "";
            txt_eta.Text = "";
            txt_etb.Text = "";
            txt_line.Text = ""; 
            btn_cancel.Text = "Back";
        }

        protected void grd_job_SelectedIndexChanged(object sender, EventArgs e)
        {
            hf_grdjob_index.Value = grd_job.SelectedRow.RowIndex.ToString();
            hf_jobno.Value = ((Label)grd_job.Rows[Convert.ToInt32(hf_grdjob_index.Value)].Cells[0].FindControl("Job")).Text;
            //grd_job.Rows[Convert.ToInt32(hf_grdjob_index.Value)].Cells[0].Text.ToString();
            fn_grdjob_Select();
            UserRights();
        }
        
        public void fn_grdjob_Select()
        {
            DataTable obj_dtDstatus = new DataTable();
            //DataAccess.ForwardingImports.ReminderNotice obj_da_reminder = new DataAccess.ForwardingImports.ReminderNotice();
            int index = Convert.ToInt32(hf_grdjob_index.Value);
            if (grd_job.Rows.Count > 0)
            {
                //txt_vslvoy.Text = grd_job.Rows[index].Cells[1].Text.ToString();
                //txt_agent.Text = grd_job.Rows[index].Cells[2].Text.ToString();
                //txt_line.Text = grd_job.Rows[index].Cells[3].Text.ToString();
                //txt_eta.Text = grd_job.Rows[index].Cells[4].Text.ToString(); ;
                //txt_etb.Text = grd_job.Rows[index].Cells[5].Text.ToString();

                txt_vslvoy.Text = ((Label)grd_job.Rows[index].Cells[1].FindControl("Vessel")).Text;
                txt_agent.Text = ((Label)grd_job.Rows[index].Cells[2].FindControl("Agent")).Text;
                txt_line.Text = ((Label)grd_job.Rows[index].Cells[3].FindControl("MLO")).Text;
                txt_eta.Text = ((Label)grd_job.Rows[index].Cells[4].FindControl("ETA")).Text;
                txt_etb.Text = ((Label)grd_job.Rows[index].Cells[5].FindControl("ETB")).Text;
                obj_dtDstatus = obj_da_reminder.GetBLJobNo(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtDstatus.Rows.Count > 0)
                {
                    ddl_hblno.DataSource = obj_dtDstatus;
                    ddl_hblno.DataTextField = "blno";
                    ddl_hblno.DataBind();
                }
                Mdl_dstaus.Show();
            }
        }

        protected void grd_job_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblVessel = (Label)e.Row.FindControl("Vessel");
                string tooltip = lblVessel.Text;
                e.Row.Cells[1].Attributes.Add("title", tooltip);

                Label lblAgent = (Label)e.Row.FindControl("Agent");
                string tooltip1 = lblAgent.Text;
                e.Row.Cells[2].Attributes.Add("title", tooltip1);

                Label lblMLO = (Label)e.Row.FindControl("MLO");
                string tooltip2 = lblMLO.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip2);

                Label lblPOL = (Label)e.Row.FindControl("POL");
                string tooltip3 = lblPOL.Text;
                e.Row.Cells[6].Attributes.Add("title", tooltip3);
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
            bind();
        }
    }
}