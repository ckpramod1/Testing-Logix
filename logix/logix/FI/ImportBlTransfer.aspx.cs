using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

namespace logix.FI
{
    public partial class ImportBlTransfer : System.Web.UI.Page
    {
        int portid, intjobno, vesselid, intpol;
        DataTable dt = new DataTable();
        DataTable dtjob = new DataTable();
        DataTable Dtbl = new DataTable();
        DataTable dt2 = new DataTable();
        int rjobno;
        int rbid;
        string[] strPMCArray1;
        DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
        string strPMCArray, strFD, strMailID, strqry, branchname, strQry, streta;
        DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.ForwardingImports.BLDetails fiblobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterVessel vesselobj = new DataAccess.Masters.MasterVessel();
        DataAccess.ForwardingImports.JobInfo fijobobj = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterBranch branchobj = new DataAccess.Masters.MasterBranch();
        DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
        public void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnBack);

            string Ccode = Convert.ToString(Session["Ccode"]);
            if (Ccode != "")
            {

                da_obj_logobj.GetDataBase(Ccode);
                hrempobj.GetDataBase(Ccode);
                empobj.GetDataBase(Ccode);
                fiblobj.GetDataBase(Ccode);
                portobj.GetDataBase(Ccode);
                vesselobj.GetDataBase(Ccode);
                fijobobj.GetDataBase(Ccode);
                branchobj.GetDataBase(Ccode);
                INVOICEobj.GetDataBase(Ccode);
            }
 
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
                grd.DataSource = Utility.Fn_GetEmptyDataTable();
                grd.DataBind();
                portid = hrempobj.GetBranchId(Session["LoginBranchName"].ToString());
                hf_portid.Value = portid.ToString();
                DataTable dtcmb = new DataTable();
                dtcmb = branchobj.GetBranchandDivision(Convert.ToInt32(Session["LoginDivisionId"]), portid);
                ddltransfer.Items.Add("---Select---");
                for (int i = 0; i <= dtcmb.Rows.Count - 1; i++)
                {
                    ddltransfer.Items.Add(dtcmb.Rows[i][0].ToString());
                   // hf_rbid.Value = rbid.ToString();
                }
            }
            txtJob.Attributes.Add("OnKeypress", "return IntegerCheck(event);");

        }

        public void lnkJob_Click(object sender, EventArgs e)
        {
            if (ddltransfer.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Branch cannot be blank');", true);
                ddltransfer.Focus();
            }
            dt = fijobobj.BindJobgrid(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            grdJob.Visible = true;
            grdJob.DataSource = dt;
            grdJob.DataBind();


            if (dt.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Job Not Available');", true);
                return;
            }
            this.popupBuying.Show();
        }

        public void FillGrid()
        {
            grd.DataSource = new DataTable();
            grd.DataBind();
            portid = Convert.ToInt32(hf_portid.Value);
            //intjobno = Convert.ToInt32(txtJob.Text);
            Dtbl = fiblobj.GetBLDetail4Jobno(intjobno, Convert.ToInt32(Session["LoginBranchid"]), portid);
            DataTable datatemp = new DataTable();
            datatemp.Columns.Add("blno");
            datatemp.Columns.Add("bldate");
            datatemp.Columns.Add("consignee");
            datatemp.Columns.Add("fd");
            datatemp.Columns.Add("Select");
            datatemp.Columns.Add("volume");
            datatemp.Columns.Add("bid");
            datatemp.Columns.Add("cid");
            DataRow dr = datatemp.NewRow();
            for (int i = 0; i <= Dtbl.Rows.Count - 1; i++)
            {
                
                dt2 = fiblobj.chkBLTransfer(intjobno, Convert.ToInt32(Session["LoginBranchid"]), Dtbl.Rows[i]["blno"].ToString());
                if (dt2.Rows.Count > 0)
                {
                    if (Dtbl.Rows[i]["blno"].ToString() != dt2.Rows[0]["blno"].ToString())
                    {
                        dr = datatemp.NewRow();
                        datatemp.Rows.Add(dr);
                        datatemp.Rows[datatemp.Rows.Count - 1][0] = Dtbl.Rows[i][0].ToString();
                        datatemp.Rows[datatemp.Rows.Count - 1][1] = Dtbl.Rows[i][1].ToString();
                        datatemp.Rows[datatemp.Rows.Count - 1][2] = Dtbl.Rows[i][2].ToString();
                        datatemp.Rows[datatemp.Rows.Count - 1][3] = Dtbl.Rows[i][3].ToString();
                        datatemp.Rows[datatemp.Rows.Count - 1][4] = false;
                        datatemp.Rows[datatemp.Rows.Count - 1][5] = Dtbl.Rows[i][6].ToString();
                        datatemp.Rows[datatemp.Rows.Count - 1][6] = Dtbl.Rows[i][4].ToString();
                        datatemp.Rows[datatemp.Rows.Count - 1][7] = Dtbl.Rows[i][5].ToString();
                    }
                    else
                    {

                    }
                }
                else
                {
                    dr = datatemp.NewRow();
                    datatemp.Rows.Add(dr);
                    datatemp.Rows[datatemp.Rows.Count - 1][0] = Dtbl.Rows[i][0].ToString();
                    datatemp.Rows[datatemp.Rows.Count - 1][1] = Dtbl.Rows[i][1].ToString();
                    datatemp.Rows[datatemp.Rows.Count - 1][2] = Dtbl.Rows[i][2].ToString();
                    datatemp.Rows[datatemp.Rows.Count - 1][3] = Dtbl.Rows[i][3].ToString();
                    datatemp.Rows[datatemp.Rows.Count - 1][4] = false;
                    datatemp.Rows[datatemp.Rows.Count - 1][5] = Dtbl.Rows[i][6].ToString();
                    datatemp.Rows[datatemp.Rows.Count - 1][6] = Dtbl.Rows[i][4].ToString();
                    datatemp.Rows[datatemp.Rows.Count - 1][7] = Dtbl.Rows[i][5].ToString();
                   
                }

                grd.DataSource = datatemp;
                grd.DataBind();
            }
        }

        public void txtJob_TextChanged(object sender, EventArgs e)
        {
            if (ddltransfer.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Branch cannot be blank');", true);
                ddltransfer.Focus();
            }

            if (txtJob.Text != "")
            {
                //DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();

                if (INVOICEobj.CheckClosedJobs("FI", Convert.ToInt32(txtJob.Text), Convert.ToInt32(Session["LoginBranchid"])) == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Job has Closed Already You Can not create a Voucher.');", true);
                    txtJob.Text = "";
                    txtJob.Focus();
                    return;
                }
                intjobno = Convert.ToInt32(txtJob.Text);
                dtjob = fijobobj.ShowJobDetails(intjobno, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (dtjob.Rows.Count > 0)
                {
                    vesselid = Convert.ToInt32(dtjob.Rows[0]["vesselid"].ToString());

                    intpol = Convert.ToInt32(dtjob.Rows[0]["pol"].ToString());

                    txtJobdetails.Text = vesselobj.GetVesselname(vesselid) + " V." + dtjob.Rows[0]["voyage"].ToString() + " / " + dtjob.Rows[0]["eta"].ToString() + " / " + portobj.GetPortname(intpol);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Invalid job');", true);
                    txtJob.Focus();
                    return;
                }
                FillGrid();
                btnBack.Text = "Cancel";
            }
        }

        public void grdJob_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdJob, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
        }

        public void grdJob_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        public void grdJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            intjobno = 0;
            if (grdJob.Rows.Count > 0)
            {
                int index = grdJob.SelectedRow.RowIndex;
        
                intjobno = Convert.ToInt32(grdJob.Rows[index].Cells[0].Text);
               
                txtJob.Text = intjobno.ToString();
                txtJobdetails.Text = grdJob.Rows[index].Cells[2].Text + " V." + grdJob.Rows[index].Cells[3].Text + " / " + grdJob.Rows[index].Cells[5].Text + " / " + grdJob.Rows[index].Cells[7].Text;
                FillGrid();
                btnBack.Text = "Cancel";
            }
        }

        public void BuildICDMailFI()
        {
            strQry = "";
            string strqry = "";
            if (txtJob.Text == "" || txtJob.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Enter the Job# ');", true);
                return;
            }
            intjobno = Convert.ToInt32(txtJob.Text);
            strQry = strQry + "<font size=2 face=sans-serif>Dear Sir,";
            strqry = strqry + "<table cellspacing=0 cellpadding=2><tr><td></td></tr>";
            strqry = strqry + "<tr><td><font size=2 face=sans-serif>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Below Shipment Details has transferred From PoL [" + Session["LoginBranchName"] + "].</td></tr>";
            strqry = strqry + "";

            strqry = strqry + "<tr><td></td></tr>";
            strqry = strqry + "<tr><td><font size=2 face=sans-serif><b>Job #:</b>" + rjobno + "</td></tr>";
            strqry = strqry + "<tr><td><font size=2 face=sans-serif>BL #(s):</td></tr>";
            dtjob = fijobobj.ShowJobDetails(intjobno, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            streta = Utility.fn_ConvertDate(dtjob.Rows[0]["eta"].ToString());
            for (int i = 0; i < grd.Rows.Count; i++)
            {
                CheckBox ckrowsval = (grd.Rows[i].Cells[4].FindControl("ChkStatus") as CheckBox);
                if (ckrowsval.Checked == true)
                {
                    strqry = strqry + "<tr><td align=right><font size=2 face=sans-serif>&nbsp;&nbsp;<b>BL :</b></td><td><font size=2 face=sans-serif>" + grd.Rows[i].Cells[0].Text + "</td><tr>";
                    strqry = strqry + "<tr><td align=right><font size=2 face=sans-serif>&nbsp;&nbsp;Consignee :</td><td><font size=2 face=sans-serif>" + grd.Rows[i].Cells[2].Text + "</td><tr>";
                    strqry = strqry + "<tr><td align=right><font size=2 face=sans-serif>&nbsp;&nbsp;P O L :</td><td><font size=2 face=sans-serif>" + Session["LoginBranchName"] + "</td><tr>";
                    strqry = strqry + "<tr><td align=right><font size=2 face=sans-serif>&nbsp;&nbsp;ETA:</td><td><font size=2 face=sans-serif>" + streta + "</td><tr>";
                    strqry = strqry + "<tr><td align=right><font size=2 face=sans-serif>&nbsp;&nbsp;CBM :</td><td><font size=2 face=sans-serif>" + grd.Rows[i].Cells[4].Text + "</td><tr><br><br>";
                }
            }
            strQry = strQry + "</table><br>";

            strQry = strQry + "<table cellspacing=0 cellpadding=2>";
            strqry = strqry + "<tr><td><font size=2 face=sans-serif>The Job# :" + rjobno + " has incorporated.</td></tr>";
            strQry = strQry + "</table><br>";

            strQry = strQry + "<font size=2 face=sans-serif>Thanks & Regards,<br>";
            strQry = strQry + "<font size=2 face=sans-serif> <br>";
        }

        public void BuildPOLMailFI(string FD)
        {
            strQry = "";
            string strqry = "";
            if (txtJob.Text == "" || txtJob.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Enter the Job# ');", true);
                return;
            }
            intjobno = Convert.ToInt32(txtJob.Text);
            strQry = strQry + "<font size=2 face=sans-serif>Dear Sir,";
            strQry = strQry + "<table cellspacing=0 cellpadding=2>";
            strqry = strqry + "<tr><td><font size=2 face=sans-serif>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Below Shipment Details has transferred To ICD [" + FD + "].</td></tr>";
            strQry = strQry + "</table><br>";

            strqry = strqry + "<table cellspacing=0 cellpadding=2>";
            strqry = strqry + "<tr><td><font size=2 face=sans-serif><b>Job #:</b>" + rjobno + "</td></tr>";
            strqry = strqry + "<tr><td><font size=2 face=sans-serif>BL #(s):</td></tr>";
            dtjob = fijobobj.ShowJobDetails(intjobno, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            streta = Utility.fn_ConvertDate(dtjob.Rows[0]["eta"].ToString());
            for (int i = 0; i < grd.Rows.Count; i++)
            {
                CheckBox ckrowsval = (grd.Rows[i].Cells[4].FindControl("ChkStatus") as CheckBox);
                {
                    strqry = strqry + "<tr><td align=right><font size=2 face=sans-serif>&nbsp;&nbsp;<b>BL :</b></td><td><font size=2 face=sans-serif>" + grd.Rows[i].Cells[0].Text + "</td><tr>";
                    strqry = strqry + "<tr><td align=right><font size=2 face=sans-serif>&nbsp;&nbsp;Consignee :</td><td><font size=2 face=sans-serif>" + grd.Rows[i].Cells[2].Text + "</td><tr>";
                    strqry = strqry + "<tr><td align=right><font size=2 face=sans-serif>&nbsp;&nbsp;P O L :</td><td><font size=2 face=sans-serif>" + Session["LoginBranchName"] + "</td><tr>";
                    strqry = strqry + "<tr><td align=right><font size=2 face=sans-serif>&nbsp;&nbsp;ETA:</td><td><font size=2 face=sans-serif>" + streta + "</td><tr>";
                    strqry = strqry + "<tr><td align=right><font size=2 face=sans-serif>&nbsp;&nbsp;CBM :</td><td><font size=2 face=sans-serif>" + grd.Rows[i].Cells[4].Text + "</td><tr><br><br>";
                }
            }
            for (int i = 0; i < grd.Rows.Count; i++)
            {
                CheckBox ckrowsval = (grd.Rows[i].Cells[4].FindControl("ChkStatus") as CheckBox);
                {
                    strqry = strqry + "<tr><td><font size=2 face=sans-serif>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + grd.Rows[i].Cells[0].Text + "</td><tr>";
                }
            }
            strQry = strQry + "</table><br>";

            strQry = strQry + "<table cellspacing=0 cellpadding=2>";
            strQry = strQry + "<tr><td><font size=2 face=sans-serif>A separate message about the same will go to " + FD + " from  <br> and request you to inform the same.</td></tr>";
            strQry = strQry + "</table><br>";

            strQry = strQry + "<font size=2 face=sans-serif>Thanks & Regards,<br>";
            strQry = strQry + "<font size=2 face=sans-serif><br>";
        }

        public void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                bool chk = false;
                if (ddltransfer.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Branch cannot be blank');", true);
                    ddltransfer.Focus();
                }
                rbid = Convert.ToInt32(hf_rbid.Value);
                if (txtJob.Text != "")
                {
                    if (grd.Rows.Count > 0)
                    {
                        for (int j = 0; j <= grd.Rows.Count - 1; j++)
                        {

                            CheckBox Chk1 = (CheckBox)grd.Rows[j].Cells[4].FindControl("ChkStatus");

                            if (Chk1.Checked == true)
                            {

                                //DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();

                                //if (INVOICEobj.CheckClosedJobs("FI", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"])) == 1)
                                if (INVOICEobj.CheckClosedJobsnew("FI", Convert.ToInt32(txtJob.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"])) == 1)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaInsFIJobOnTransferspx", "alertify.alert('Job has Closed Already You Can not create a Voucher.');", true);
                                    //txtJob.Text = "";
                                    //txtJob.Focus();
                                    return;
                                }
                                rjobno = fiblobj.InsFIJobOnTransfer(Convert.ToInt32(txtJob.Text), Convert.ToInt32(grd.Rows[j].Cells[6].Text), Convert.ToInt32(grd.Rows[j].Cells[7].Text), rbid, Convert.ToInt32(Session["LoginDivisionId"]));
                                fiblobj.InsFIBLOnTransfer(rjobno, rbid, Convert.ToInt32(Session["LoginDivisionId"]), grd.Rows[j].Cells[0].Text, Convert.ToInt32(txtJob.Text), Convert.ToInt32(grd.Rows[j].Cells[6].Text), Convert.ToInt32(grd.Rows[j].Cells[7].Text));
                                fiblobj.InsGRPFIBLTransfer(grd.Rows[j].Cells[0].Text, Convert.ToInt32(grd.Rows[j].Cells[6].Text), rjobno, rbid);
                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 661, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtJob.Text + "/T");
                                chk = true;
                            }

                        }
                        if (chk == false)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer FROM ICD", "alertify.alert('Select atleast One BL #');", true);
                            return;
                        }
                        string ss = ddltransfer.SelectedValue;
                        strPMCArray1 = ss.Split('-');
                        if (strPMCArray1.Length > 0)
                        {
                            strFD = strPMCArray1[1].ToString();
                        }
                        //rbid = hrempobj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), branchname);
                        //hf_rbid.Value = rbid.ToString();

                        BuildPOLMailFI(strFD);
                        strMailID = empobj.SelBranchHeadMailID(Convert.ToInt32(Session["LoginDivisionId"]), Session["LoginBranchName"].ToString());
                        Utility.SendMail(strMailID, "", "pandi", "Shipment transferred From PoL. Job # - " + rjobno.ToString(), strqry, "", "", "");
                        BuildICDMailFI();
                        //sendmail.SendEmail(strMailID, "", "pandi", "Shipment transferred From PoL. Job # - " + rjobno, strqry, true, Session["MailServer"], "", "", Session["usermailid"], Session["usermailpwd"], "");
                        strMailID = empobj.SelBranchHeadMailID(Convert.ToInt32(Session["LoginDivisionId"]), strFD);
                        Utility.SendMail(strMailID, "", "pandi", "Shipment transferred From PoL. Job # - " + rjobno.ToString(), strqry, "", "", "");
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('BL Transfered Successsfully');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('BL is not available');", true);
                        txtJob.Focus();
                        txtJob.Text = "";
                        txtJobdetails.Text = "";
                        btnBack.Text = "Cancel";
                        btnBack.ToolTip = "Cancel";
                        btnBack1.Attributes["class"] = "btn ico-cancel";
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Enter the Job#');", true);
                    txtJob.Focus();
                }
                FillGrid();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            
        }

        public void btnBack_Click(object sender, EventArgs e)
        {
            if (btnBack.Text == "Cancel")
            {
                txtJob.Text = "";
                txtJobdetails.Text = "";
                for (int i = 0; i <= grd.Rows.Count - 1; i++)
                {
                    grd.DataSource = Utility.Fn_GetEmptyDataTable();
                    grd.DataBind();
                }
                ddltransfer.SelectedIndex = -1;
                btnBack.Text = "Back";
                ddltransfer.Focus();
            }
            else
            {
                this.Response.End();
            }
        }

        public void ddltransfer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltransfer.SelectedIndex != -1)
            {

               string ss = ddltransfer.SelectedValue;
               strPMCArray1 = ss.Split('-');
               if (strPMCArray1.Length > 0)
                {
                    branchname = strPMCArray1[1].ToString();
                }
                rbid = hrempobj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), branchname);
                hf_rbid.Value = rbid.ToString();
                btnBack.Text = "Cancel";
            }
        }

        public void grd_PreRender(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                grd.UseAccessibleHeader = true;
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }


    }
}