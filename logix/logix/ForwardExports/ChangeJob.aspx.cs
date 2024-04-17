using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Globalization;

using System.Drawing;
using Quartz;
using System.Web.Services.Description;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Web.UI.DataVisualization.Charting;


namespace logix.ForwardExports
{
    public partial class ChangeJob : System.Web.UI.Page
    {
        int bid, cid, vouyear, int_agentid;
        DataTable dt_changejob = new DataTable();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.ChangeJob.ChangeJob changejob = new DataAccess.ChangeJob.ChangeJob();
        DataAccess.ForwardingExports.JobInfo FEJobObj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingImports.JobInfo FIJobObj = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.AirImportExports.AIEJobInfo AIEJobObj = new DataAccess.AirImportExports.AIEJobInfo();
        DataAccess.Accounts.OSDNCN OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataTable dtchangejob = new DataTable();
        string strtrantype, intdnno, dnno, intcnno, cnno;
        DataTable Dt = new DataTable();
        string damount, camount;
        int DCjobno, CCjobno;
        double damt, camt, amount;
        string preparedby, strtype;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            try
            {

                strtrantype = Session["StrTranType"].ToString();
                cid = hrempobj.GetDivisionId(Convert.ToString(Session["LoginDivisionName"]));
                bid = hrempobj.GetBranchId(cid, Convert.ToString(Session["LoginBranchName"]));
                preparedby = Session["LoginUserName"].ToString();
                if (!this.IsPostBack)
                {
                    btnCancel.Text = "Cancel";
                    btnCancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        HeaderLabel1.InnerText = "OceanExports";
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        HeaderLabel1.InnerText = "OceanImports";
                    }
                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        HeaderLabel1.InnerText = "AirExports";
                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        HeaderLabel1.InnerText = "AirImports";
                    }

                    load();
                    if (Request.QueryString.ToString().Contains("jobno"))
                    {
                        fn_getjobdtls(Convert.ToInt32(Request.QueryString["jobno"].ToString()));

                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void emptygrid(DataTable source, GridView gv)
        {
            try
            {
                if (source.Rows.Count == 0)
                {
                    source.Rows.Add(source.NewRow());
                    gv.DataSource = source;
                    gv.DataBind();
                    int totalcolums = gv.Rows[0].Cells.Count;
                    gv.Rows[0].Cells.Clear();
                    gv.Rows[0].Cells.Add(new TableCell());
                    gv.Rows[0].Cells[0].ColumnSpan = totalcolums;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void load()
        {
            try
            {
                strtrantype = Session["StrTranType"].ToString();
                cid = hrempobj.GetDivisionId(Convert.ToString(Session["LoginDivisionName"]));
                bid = hrempobj.GetBranchId(cid, Convert.ToString(Session["LoginBranchName"]));
                preparedby = Session["LoginUserName"].ToString();
                btnDestJob.Enabled = false;
                btnDestJob.ForeColor = System.Drawing.Color.Gray;
                grdBL.Visible = false;
                grdjobno.Visible = false;
                grdAIEJob.Visible = false;
                if (strtrantype == "FE" || strtrantype == "FI")
                {
                    grdjobno.Visible = true;
                    dtchangejob = changejob.GetJobDetails(strtrantype, Convert.ToInt32(Session["LoginBranchid"]));
                    if (dtchangejob.Rows.Count > 0)
                    {
                        grdjobno.DataSource = dtchangejob;
                        grdjobno.DataBind();
                    }
                    else
                    {
                        emptygrid(dtchangejob, grdjobno);
                    }
                }
                else
                {
                    grdAIEJob.Visible = true;
                    dtchangejob = changejob.GetJobDetails(strtrantype, Convert.ToInt32(Session["LoginBranchid"]));
                    if (dtchangejob.Rows.Count > 0)
                    {
                        grdAIEJob.DataSource = dtchangejob; ;
                        grdAIEJob.DataBind();
                    }
                    else
                    {
                        emptygrid(dtchangejob, grdAIEJob);
                    }
                }
                if (Logobj.GetDate().Month < 4)
                {
                    vouyear = Convert.ToInt32(Logobj.GetDate().AddYears(-1).Year.ToString());
                }
                else
                {
                    vouyear = Convert.ToInt32(Logobj.GetDate().Year.ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdjobno_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdjobno.PageIndex = e.NewPageIndex;
                dtchangejob = changejob.GetJobDetails(strtrantype, Convert.ToInt32(Session["LoginBranchid"]));
                if (dtchangejob.Rows.Count > 0)
                {
                    grdjobno.DataSource = dtchangejob;
                    grdjobno.DataBind();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdjobno_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (grdjobno.Rows.Count > 0)
            //    {
            //        int int_index;

            //        int_index = grdjobno.SelectedRow.RowIndex;
            //        grdjobno.Rows[int_index].BackColor = System.Drawing.Color.Blue ;
            //        hfdisjobno.Value = grdjobno.Rows[int_index].Cells[0].Text.ToString();
            //        //if (hfsourcejobno.Value == hfdisjobno.Value)
            //        //{
            //            //ScriptManager.RegisterStartupScript(btnDestJob, typeof(TextBox), "ChangeJob", "Confirm('Do you want to change the job');", true);
            //            //grdjobno.Visible = true;
            //            //grdBL.Visible = false;
            //            //int_index = grdjobno.SelectedRow.RowIndex;
            //            //hfdisjobno.Value = grdjobno.Rows[int_index].Cells[0].Text.ToString();
            //        //}

            //        if(hfblndest.Value == "true")
            //        {
            //            this.PopUpService.Show();
            //        }

            //        else
            //        {
            //            grdjobno.Visible = true;
            //            grdBL.Visible = false;
            //            int intindex = grdjobno.SelectedRow.RowIndex;
            //            string disjobno = grdjobno.SelectedRow.Cells[0].Text;
            //            hfsourcejobno.Value = grdjobno.SelectedRow.Cells[0].Text;
            //            grdjobno.Visible = false;
            //            grdBL.Visible = true;
            //            btnDestJob.Enabled = true;
            //            btnDestJob.ForeColor = System.Drawing.Color.White;
            //            dt_changejob = changejob.GetBLDetails(Convert.ToInt32(hfsourcejobno.Value), strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()));
            //            grdBL.DataSource = dt_changejob;
            //            grdBL.DataBind();
            //            //btnCancel.Text = "Cancel";
            //            btnCancel.ToolTip = "Cancel";
            //            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}


            try
            {

                DataSet dscheck = new DataSet();
                int int_OScount = 0;
                if (grdjobno.Rows.Count > 0)
                {
                    int int_index;

                    int_index = grdjobno.SelectedRow.RowIndex;
                    grdjobno.Rows[int_index].BackColor = System.Drawing.Color.Blue;
                    hfdisjobno.Value = grdjobno.Rows[int_index].Cells[0].Text.ToString();
                    //if (hfsourcejobno.Value == hfdisjobno.Value)
                    //{
                    //ScriptManager.RegisterStartupScript(btnDestJob, typeof(TextBox), "ChangeJob", "Confirm('Do you want to change the job');", true);
                    //grdjobno.Visible = true;
                    //grdBL.Visible = false;
                    //int_index = grdjobno.SelectedRow.RowIndex;
                    //hfdisjobno.Value = grdjobno.Rows[int_index].Cells[0].Text.ToString();
                    //}

                    dscheck = FEJobObj.CheckChangeJobforOSDNCN(Convert.ToInt32(hfdisjobno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), strtrantype);

                    if (dscheck.Tables.Count > 0)
                    {
                        int_OScount = Convert.ToInt32(dscheck.Tables[0].Rows[0][0].ToString());
                    }

                    if (int_OScount == 0)
                    {
                        if (hfblndest.Value == "true")
                        {
                            this.PopUpService.Show();
                        }

                        else
                        {
                            grdjobno.Visible = true;
                            grdBL.Visible = false;
                            int intindex = grdjobno.SelectedRow.RowIndex;
                            string disjobno = grdjobno.SelectedRow.Cells[0].Text;
                            hfsourcejobno.Value = grdjobno.SelectedRow.Cells[0].Text;
                            grdjobno.Visible = false;
                            grdBL.Visible = true;
                            btnDestJob.Enabled = true;
                            btnDestJob.ForeColor = System.Drawing.Color.White;
                            dt_changejob = changejob.GetBLDetails(Convert.ToInt32(hfsourcejobno.Value), strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                            grdBL.DataSource = dt_changejob;
                            grdBL.DataBind();
                            btnCancel.Text = "Cancel";
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly delete the OSDN/CN Voucher for the selected Job before Change');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
     
        protected void fn_getjobdtls(int job)
        {
            try
            {

                DataSet dscheck = new DataSet();
                int int_OScount = 0;
                strtrantype = Session["StrTranType"].ToString();
                if (strtrantype == "FE" || strtrantype == "FI")
                {
                    //if (grdjobno.Rows.Count > 0)
                    //{
                    //int int_index;

                    //int_index = grdjobno.SelectedRow.RowIndex;
                    //grdjobno.Rows[int_index].BackColor = System.Drawing.Color.Blue;
                    hfdisjobno.Value = job.ToString();

                    dscheck = FEJobObj.CheckChangeJobforOSDNCN(Convert.ToInt32(hfdisjobno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), strtrantype);

                    if (dscheck.Tables.Count > 0)
                    {
                        int_OScount = Convert.ToInt32(dscheck.Tables[0].Rows[0][0].ToString());
                    }

                    if (int_OScount == 0)
                    {
                        if (hfblndest.Value == "true")
                        {
                            this.PopUpService.Show();
                        }

                        else
                        {
                            grdjobno.Visible = true;
                            grdBL.Visible = false;
                            //int intindex = grdjobno.SelectedRow.RowIndex;
                            //string disjobno = grdjobno.SelectedRow.Cells[0].Text;
                            hfsourcejobno.Value = job.ToString();
                            grdjobno.Visible = false;
                            grdBL.Visible = true;
                            btnDestJob.Enabled = true;
                            btnDestJob.ForeColor = System.Drawing.Color.White;
                            dt_changejob = changejob.GetBLDetails(Convert.ToInt32(hfsourcejobno.Value), strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                            grdBL.DataSource = dt_changejob;
                            grdBL.DataBind();
                            btnCancel.Text = "Cancel";
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly delete the OSDN/CN Voucher for the selected Job before Change');", true);
                    }
                }
                else
                {
                    hfdisjobno.Value = job.ToString();
                    //if (hfsourcejobno.Value == hfdisjobno.Value)
                    //{
                    if (hfblndest.Value == "true")
                    {
                        this.PopUpService.Show();
                    }
                    else
                    {
                        grdAIEJob.Visible = false;
                        grdBL.Visible = true;
                        btnDestJob.Enabled = true;
                        btnDestJob.ForeColor = System.Drawing.Color.White;
                        //int_index = grdAIEJob.SelectedRow.RowIndex;
                        //string disjobno = grdAIEJob.SelectedRow.Cells[0].Text;
                        hfsourcejobno.Value = job.ToString();

                        grdAIEJob.Visible = false;
                        grdBL.Visible = true;
                        btnDestJob.Enabled = true;
                        dt_changejob = changejob.GetBLDetails(Convert.ToInt32(hfsourcejobno.Value), Convert.ToString(strtrantype), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        grdBL.DataSource = dt_changejob;
                        Session["grd_BL"] = dt_changejob;
                        grdBL.DataBind();
                        btnCancel.Text = "Cancel";
                        btnCancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                }
               // }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void grdjobno_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblCustomer1 = (Label)e.Row.FindControl("jobtype");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[1].Attributes.Add("title", tooltip1);

                    Label lblCustomer2 = (Label)e.Row.FindControl("vessel");
                    string tooltip2 = lblCustomer2.Text;
                    e.Row.Cells[2].Attributes.Add("title", tooltip2);

                    Label lblCustomer3 = (Label)e.Row.FindControl("agent");
                    string tooltip3 = lblCustomer3.Text;
                    e.Row.Cells[6].Attributes.Add("title", tooltip3);

                    Label lblCustomer4 = (Label)e.Row.FindControl("mlo");
                    string tooltip4 = lblCustomer4.Text;
                    e.Row.Cells[7].Attributes.Add("title", tooltip4);

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdjobno, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_yes1_Click(object sender, EventArgs e)
        {
            btnCancel.Text = "Cancel";
            btnCancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            hid_confirm.Value = Convert.ToString(true);
        }

        protected void btn_no1_Click(object sender, EventArgs e)
        {
            btnCancel.Text = "Cancel";
            btnCancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            hid_confirm.Value = Convert.ToString(false);
        }

        protected void grdBL_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdBL.Rows)
            {
                CheckBox Chk = (CheckBox)row.FindControl("cbSelect");
                if (Chk.Checked == true)
                {
                    hfblndest.Value = "true";
                }
            }
        }

        protected void btnDestJob_Click(object sender, EventArgs e)
        {            
            try
            {
                int jobno=0;
                foreach (GridViewRow row in grdBL.Rows)
                {
                    CheckBox Chk = (CheckBox)row.FindControl("cbSelect");
                    if (Chk.Checked == true)
                    {
                        hfblndest.Value = "true";
                    }
                }
                
                if (strtrantype == "FE" || strtrantype == "FI")
                {
                    if (Request.QueryString.ToString().Contains("jobno"))
                    {
                        jobno = Convert.ToInt32(Request.QueryString["jobno"].ToString());

                    }
                    else
                    {
                        int int_index2;
                        int_index2 = grdjobno.SelectedRow.RowIndex;
                        jobno = Convert.ToInt32(grdjobno.Rows[int_index2].Cells[0].Text.ToString());
                    }                                      
                    dtchangejob = changejob.GetJobDetails(strtrantype, bid);                   
                    grdjobno.DataSource = dtchangejob;
                    grdjobno.DataBind();
                    grdjobno.Visible = true;
                    grdAIEJob.Visible = false;
                }
                else
                {
                   
                    grdAIEJob.Visible = true;
                    if (Request.QueryString.ToString().Contains("jobno"))
                    {
                        jobno = Convert.ToInt32(Request.QueryString["jobno"].ToString());

                    }
                    else
                    {
                        int int_index1;
                        int_index1 = grdAIEJob.SelectedRow.RowIndex;
                        jobno = Convert.ToInt32(grdjobno.Rows[int_index1].Cells[0].Text.ToString());
                    }
                    dtchangejob = changejob.GetJobDetails(strtrantype, bid);
                    grdAIEJob.DataSource = dtchangejob;
                    grdAIEJob.DataBind();
                    grdjobno.Visible = false;
                }
                if (strtrantype == "FE")
                {
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 88, 3, Convert.ToInt32(Session["LoginBranchid"]), strtrantype + "/ Dest Job " + jobno);
                }
                else if (strtrantype == "FI")
                {
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 89, 3, Convert.ToInt32(Session["LoginBranchid"]), strtrantype + "/ Dest Job " + jobno);
                }
                else if (strtrantype == "AE")
                {
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 90, 3, Convert.ToInt32(Session["LoginBranchid"]), strtrantype + "/ Dest Job " + jobno);
                }
                else if (strtrantype == "AI")
                {
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 91, 3, Convert.ToInt32(Session["LoginBranchid"]), strtrantype + "/ Dest Job " + jobno);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        //private void SetOSDCN()
        //{
        //    try
        //    {
        //        Getagentid();
        //        DateTime dtdate = Logobj.GetDate();
        //        Dt = OSDNCN.GetDCAmount(Convert.ToInt32(hfdisjobno.Value), strtrantype, "OSSI", bid);
        //        if (Dt.Rows.Count != 0)
        //        {
        //            damount = Dt.Rows[0][0].ToString();
        //            if (string.IsNullOrEmpty(damount))
        //            {
        //                damount = "0";
        //            }
        //        }
        //        Dt = OSDNCN.GetDCAmount(Convert.ToInt32(hfdisjobno.Value), strtrantype, "OSPI", bid);
        //        if (Dt.Rows.Count != 0)
        //        {
        //            camount = Dt.Rows[0][0].ToString();
        //            if (string.IsNullOrEmpty(camount))
        //            {
        //                camount = "0";
        //            }
        //        }
        //        DCjobno = OSDNCN.GetDCNJobcount(Convert.ToInt32(hfdisjobno.Value), strtrantype, "OSSI", bid);
        //        CCjobno = OSDNCN.GetDCNJobcount(Convert.ToInt32(hfdisjobno.Value), strtrantype, "OSPI", bid);
        //        if (damount == "0" && camount == "0")
        //        {

        //        }
        //        else
        //        {
        //            damt = Convert.ToDouble(damount);
        //            camt = Convert.ToDouble(camount);
        //            if (damt > camt)
        //            {
        //                amount = damt - camt;
        //                if (DCjobno > 0)
        //                {
        //                    intdnno = Convert.ToString(OSDNCN.GetOSDCNnumber(Convert.ToInt32(hfdisjobno.Value), strtrantype, "OSSI", bid));
        //                    OSDNCN.UpdateOSDCN(Convert.ToInt32(hfdisjobno.Value), amount, dtdate, bid, strtrantype, "OSSI", vouyear);
        //                    OSDNCN.DelOSDCN(Convert.ToInt32(hfsourcejobno.Value), strtrantype, "OSSI", vouyear, bid);
        //                }
        //                else
        //                {
        //                    dnno = Convert.ToString(OSDNCN.GetOSDCNno("OSSI", bid));
        //                    OSDNCN.InsertOSDN(Convert.ToInt32(dnno), dtdate, strtrantype, amount, Convert.ToInt32(hfdisjobno.Value), bid, int_agentid, Convert.ToInt32(preparedby), vouyear);
        //                    intdnno = Convert.ToString(OSDNCN.GetOSDCNnumber(Convert.ToInt32(hfdisjobno.Value), strtrantype, "OSSI", bid));
        //                    OSDNCN.DelOSDCN(Convert.ToInt32(hfsourcejobno.Value), strtrantype, "OSSI", vouyear, bid);
        //                }
        //                if (CCjobno > 0)
        //                {
        //                    strtype = "OSPI";
        //                    OSDNCN.DelOSDCN(Convert.ToInt32(hfdisjobno.Value), strtrantype, "OSPI", vouyear, bid);
        //                }
        //            }
        //            else
        //            {
        //                amount = camt - damt;
        //                if (CCjobno > 0)
        //                {
        //                    intcnno = Convert.ToString(OSDNCN.GetOSDCNnumber(Convert.ToInt32(hfdisjobno.Value), strtrantype, "OSPI", bid));
        //                    OSDNCN.UpdateOSDCN(Convert.ToInt32(hfdisjobno.Value), amount, dtdate, bid, strtrantype, "OSPI", vouyear);
        //                    OSDNCN.DelOSDCN(Convert.ToInt32(hfsourcejobno.Value), strtrantype, "OSPI", vouyear, bid);
        //                }
        //                else
        //                {
        //                    cnno = Convert.ToString(OSDNCN.GetOSDCNno("OSPI", bid));
        //                    OSDNCN.InsertOSCN(Convert.ToInt32(cnno), dtdate, strtrantype, amount, Convert.ToInt32(hfdisjobno.Value), bid, int_agentid, Convert.ToInt32(preparedby), vouyear);
        //                    intcnno = Convert.ToString(OSDNCN.GetOSDCNnumber(Convert.ToInt32(hfdisjobno.Value), strtrantype, "OSPI", bid));
        //                    OSDNCN.DelOSDCN(Convert.ToInt32(hfsourcejobno.Value), strtrantype, "OSPI", vouyear, bid);
        //                }
        //                if (DCjobno > 0)
        //                {
        //                    strtype = "OSSI";
        //                    OSDNCN.DelOSDCN(Convert.ToInt32(hfdisjobno.Value), strtrantype, "OSSI", vouyear, bid);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}

        public void Getagentid()
        {
            try
            {
                DataTable Dt = new DataTable();
                if (strtrantype == "FE" || strtrantype == "FI")
                {
                    if (strtrantype == "FE")
                    {
                        Dt = FEJobObj.GetFEJobInfo(Convert.ToInt32(hfdisjobno.Value), bid, cid);
                        if (Dt.Rows.Count > 0)
                        {
                            int_agentid = Convert.ToInt32(Dt.Rows[0][14].ToString());
                        }
                    }
                    if (strtrantype == "FI")
                    {
                        Dt = FIJobObj.ShowJobDetails(Convert.ToInt32(hfdisjobno.Value), bid, cid);
                        if (Dt.Rows.Count > 0)
                        {
                            int_agentid = Convert.ToInt32(Dt.Rows[0][4].ToString());
                        }
                    }
                }

                if (strtrantype == "AE" || strtrantype == "AI")
                {
                    if (strtrantype == "AE")
                    {
                        Dt = AIEJobObj.GetAIEDetail(Convert.ToInt32(hfdisjobno.Value), strtrantype, bid, cid);
                        if (Dt.Rows.Count > 0)
                        {
                            int_agentid = Convert.ToInt32(Dt.Rows[0][8].ToString());
                        }
                    }
                    if (strtrantype == "AI")
                    {
                        Dt = AIEJobObj.GetAIEDetail(Convert.ToInt32(hfdisjobno.Value), strtrantype, bid, cid);
                        if (Dt.Rows.Count > 0)
                        {
                            int_agentid = Convert.ToInt32(Dt.Rows[0][8].ToString());
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

        protected void grdAIEJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            int int_index;
            int_index = grdAIEJob.SelectedRow.RowIndex;
            try
            {
                if (grdAIEJob.Rows.Count > 0)
                {
                   
                   
                    hfdisjobno.Value = grdAIEJob.Rows[int_index].Cells[0].Text.ToString();
                    //if (hfsourcejobno.Value == hfdisjobno.Value)
                    //{
                    if (hfblndest.Value == "true")
                    {
                        this.PopUpService.Show();
                    }
                    else
                    {
                        grdAIEJob.Visible = false;
                        grdBL.Visible = true;
                        btnDestJob.Enabled = true;
                        btnDestJob.ForeColor = System.Drawing.Color.White;
                        int_index = grdAIEJob.SelectedRow.RowIndex;
                        string disjobno = grdAIEJob.SelectedRow.Cells[0].Text;
                        hfsourcejobno.Value = grdAIEJob.Rows[int_index].Cells[0].Text.ToString();

                        grdAIEJob.Visible = false;
                        grdBL.Visible = true;
                        btnDestJob.Enabled = true;
                        dt_changejob = changejob.GetBLDetails(Convert.ToInt32(hfsourcejobno.Value), Convert.ToString(strtrantype), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        grdBL.DataSource = dt_changejob;
                        Session["grd_BL"] = dt_changejob;
                        grdBL.DataBind();
                        btnCancel.Text = "Cancel";
                        btnCancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            //grdAIEJob.Rows[int_index].Cells[0].ForeColor = System.Drawing.Color.White;
        }

        protected void grdAIEJob_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label airline = (Label)e.Row.FindControl("airline");
                    string tooltip1 = airline.Text;
                    e.Row.Cells[4].Attributes.Add("title", tooltip1);

                    Label agent = (Label)e.Row.FindControl("agent");
                    string tooltip2 = agent.Text;
                    e.Row.Cells[5].Attributes.Add("title", tooltip2);

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdAIEJob, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.ToolTip == "Cancel")
            {
                emptygrid(dtchangejob, grdAIEJob);
                btnCancel.Text = "Back";
                btnCancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
               // this.Response.End();
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        // headerlable1.InnerText = "OceanExports";
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
        }

        protected void Grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBL.PageIndex = e.NewPageIndex;
            load();
            Panel1.Visible = true;
        }

        protected void grdAIEJob_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdAIEJob.PageIndex = e.NewPageIndex;
                load();
                Panel1.Visible = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_GRD_Click(object sender, EventArgs e)
        {



           /* try
            {
                string Bl = "";
                this.PopUpService.Hide();
                bid = hrempobj.GetBranchId(cid, Convert.ToString(Session["LoginBranchName"]));
                //Panel_Service.Visible = false;
                if (grdAIEJob.Visible == true)
                {
                    grdAIEJob.Visible = true;
                    grdBL.Visible = false;
                    int int_index;
                    int_index = grdAIEJob.SelectedRow.RowIndex;
                    hfdisjobno.Value = grdAIEJob.Rows[int_index].Cells[0].Text.ToString();
                    for (int i = 0; i < grdBL.Rows.Count; i++)
                    {
                        CheckBox check;
                        check = (CheckBox)(grdBL.Rows[i].FindControl("cbSelect"));
                        Bl = grdBL.Rows[i].Cells[1].Text;

                        if (check.Checked == true)
                        {
                            changejob.UpdChangeJob(Convert.ToInt32(hfdisjobno.Value), Bl, strtrantype, bid);
                           // SetOSDCN();
                        }
                    }
                    hfsourcejobno.Value = "";
                    hfblndest.Value = "false";
                }
                else if (grdjobno.Visible == true)
                {
                    grdjobno.Visible = true;
                    grdBL.Visible = false;
                    int int_index;
                    int_index = grdjobno.SelectedRow.RowIndex;
                    hfdisjobno.Value = grdjobno.Rows[int_index].Cells[0].Text.ToString();
                    for (int i = 0; i < grdBL.Rows.Count; i++)
                    {
                        CheckBox check;
                        check = (CheckBox)(grdBL.Rows[i].FindControl("cbSelect"));
                        Bl = grdBL.Rows[i].Cells[1].Text;

                        if (check.Checked == true)
                        {
                            changejob.UpdChangeJob(Convert.ToInt32(hfdisjobno.Value), Bl, strtrantype, bid);
                           // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 88, 2, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hfdisjobno.Value) + "/" + Bl);

                            if (strtrantype == "FE")
                            {
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 88, 2, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hfdisjobno.Value) + "/" + Bl);
                            }
                            else if (strtrantype == "FI")
                            {
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 89, 2, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hfdisjobno.Value) + "/" + Bl);
                            }
                            else if (strtrantype == "AE")
                            {
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 90, 2, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hfdisjobno.Value) + "/" + Bl);
                            }
                            else if (strtrantype == "AI")
                            {
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 91, 2, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hfdisjobno.Value) + "/" + Bl);
                            }
                            
                            // SetOSDCN();
                        }
                    }
                    hfsourcejobno.Value = "";
                    hfblndest.Value = "false";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            */





            try
            {
                string Bl = "";
                this.PopUpService.Hide();
                bid = hrempobj.GetBranchId(cid, Convert.ToString(Session["LoginBranchName"]));
                //Panel_Service.Visible = false;
                DataSet dscheck = new DataSet();
                int int_OScount = 0;
                if (grdAIEJob.Visible == true)
                {

                     dscheck = FEJobObj.CheckChangeJobforOSDNCN(Convert.ToInt32(hfdisjobno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), strtrantype);

                    if (dscheck.Tables.Count > 0)
                    {
                        int_OScount = Convert.ToInt32(dscheck.Tables[0].Rows[0][0].ToString());
                    }

                    if (int_OScount == 0)
                    {
                        if (hfblndest.Value == "true")
                        {
                            grdAIEJob.Visible = true;
                            grdBL.Visible = false;
                            int int_index;
                            int_index = grdAIEJob.SelectedRow.RowIndex;
                            hfdisjobno.Value = grdAIEJob.Rows[int_index].Cells[0].Text.ToString();
                            for (int i = 0; i < grdBL.Rows.Count; i++)
                            {
                                CheckBox check;
                                check = (CheckBox)(grdBL.Rows[i].FindControl("cbSelect"));
                                Bl = grdBL.Rows[i].Cells[1].Text;

                                if (check.Checked == true)
                                {
                                    changejob.UpdChangeJob(Convert.ToInt32(hfdisjobno.Value), Bl, strtrantype, bid);
                                    // SetOSDCN();
                                }
                            }
                            hfsourcejobno.Value = "";
                            hfblndest.Value = "false";
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly delete the OSDN/CN Voucher for the selected Job before Change');", true);
                    }
                }
                else if (grdjobno.Visible == true)
                {
                     dscheck = FEJobObj.CheckChangeJobforOSDNCN(Convert.ToInt32(hfdisjobno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), strtrantype);

                    if (dscheck.Tables.Count > 0)
                    {
                        int_OScount = Convert.ToInt32(dscheck.Tables[0].Rows[0][0].ToString());
                    }

                    if (int_OScount == 0)
                    {

                        grdjobno.Visible = true;
                        grdBL.Visible = false;
                        int int_index;
                        int_index = grdjobno.SelectedRow.RowIndex;
                        hfdisjobno.Value = grdjobno.Rows[int_index].Cells[0].Text.ToString();
                        for (int i = 0; i < grdBL.Rows.Count; i++)
                        {
                            CheckBox check;
                            check = (CheckBox)(grdBL.Rows[i].FindControl("cbSelect"));
                            Bl = grdBL.Rows[i].Cells[1].Text;

                            if (check.Checked == true)
                            {
                                changejob.UpdChangeJob(Convert.ToInt32(hfdisjobno.Value), Bl, strtrantype, bid);
                                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job Changed Successfully.');", true);

                                // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 88, 2, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hfdisjobno.Value) + "/" + Bl);

                                if (strtrantype == "FE")
                                {
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 88, 2, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hfdisjobno.Value) + "/" + Bl + "DEST JOBNO:"+hfdisjobno.Value);
                                }
                                else if (strtrantype == "FI")
                                {
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 89, 2, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hfdisjobno.Value) + "/" + Bl + "DEST JOBNO:" + hfdisjobno.Value);
                                }
                                else if (strtrantype == "AE")
                                {
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 90, 2, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hfdisjobno.Value) + "/" + Bl + "DEST JOBNO:" + hfdisjobno.Value);
                                }
                                else if (strtrantype == "AI")
                                {
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 91, 2, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hfdisjobno.Value) + "/" + Bl + "DEST JOBNO:" + hfdisjobno.Value);
                                }

                                // SetOSDCN();
                            }
                        }
                        hfsourcejobno.Value = "";
                        hfblndest.Value = "false";
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly delete the OSDN/CN Voucher for the selected Job before Change');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }









        }

        protected void btn_GRD_No_Click(object sender, EventArgs e)
        {
            hfblndest.Value = "false";
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

            if (strtrantype == "FE")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 88, "job", "", "", Session["StrTranType"].ToString());
            }
            else if (strtrantype == "FI")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 89, "job", "", "", Session["StrTranType"].ToString());
            }
            else if (strtrantype == "AE")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 90, "job", "", "", Session["StrTranType"].ToString());
                
            }
            else if (strtrantype == "AI")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 91, "job", "", "", Session["StrTranType"].ToString());
               
            }


           

            //if (txt_book.Text != "")
            //{
            //    JobInput.Text = txt_book.Text;
            //}

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }
    }
}