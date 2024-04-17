using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Runtime.Remoting;

namespace logix.ShipmentDetails
{
    public partial class Transfer_From_ICD : System.Web.UI.Page
    {
        DataAccess.ForwardingExports.BLDetails BLtrobj = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.Masters.MasterPort objport = new DataAccess.Masters.MasterPort();
        DataAccess.ForwardingExports.JobInfo FEJobobj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingImports.JobInfo FIJobobj = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.AirImportExports.AIEJobInfo da_obj_AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
        DataAccess.LogDetails LogObj = new DataAccess.LogDetails();

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        string StrTrantype;
        int branchid, divisionid;
        string blno;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                BLtrobj.GetDataBase(Ccode);
                objport.GetDataBase(Ccode);
                FEJobobj.GetDataBase(Ccode);
                FIJobobj.GetDataBase(Ccode);
                LogObj.GetDataBase(Ccode);
                da_obj_AEJobobj.GetDataBase(Ccode);
                LogObj.GetDataBase(Ccode);


            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
 
            
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnback);

                if (!IsPostBack)
                {
                    try
                    {
                    FillGridICD();
                    txtJob.Focus();
                   btnback.Text = "Cancel";

                    btnback.ToolTip = "Cancel";
                    btnback1.Attributes["class"] = "btn ico-cancel";

                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        string taskId = Request.QueryString["taskid"];
                        if (taskId != null)
                        {
                            lblMeText.Text = taskId.ToString();
                        }
                        else
                        {
                            lblMeText.Text = Request.QueryString["type"].ToString();
                        }
                        headerlable1.InnerText = "Ocean Exports";
                        menu.InnerText = "Copy From Other Office";
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        lblMeText.Text = Request.QueryString["type"].ToString();
                        headerlable1.InnerText = "Ocean Imports";
                        menu.InnerText = lblMeText.Text;
                    }
                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        lblMeText.Text = Request.QueryString["type"].ToString();
                        headerlable1.InnerText = "Air Exports";
                        menu.InnerText = "Copy From Other Office"; 
                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        lblMeText.Text = Request.QueryString["type"].ToString();
                        headerlable1.InnerText = "Air Imports";
                        menu.InnerText = "Copy To Other Office";
                    }
                     
                    

                   
                    
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message.ToString();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                    }

                  }
            
           }


        private void FillGridICD()
        {
            StrTrantype = Session["StrTranType"].ToString();
            branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            dt = BLtrobj.GETFEIBLTransICDPort(branchid, StrTrantype);

            if(dt.Rows.Count > 0)
            {
                GrdToPol.DataSource = dt;
                GrdToPol.DataBind();
            }
            else
            {
               // EmptyGridForPOL();
                GrdToPol.DataSource = new DataTable();
                GrdToPol.DataBind();
            }
        }

        protected void joblink_Click(object sender, EventArgs e)
        {
            try
            {
                loadgrid();               
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void loadgrid()
        {
            divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            StrTrantype = Session["StrTranType"].ToString();
            GrdFIJob.Visible = false;
            GrdJobICD.Visible = false;
            grd_airline.Visible = false;

            if (StrTrantype == "FE")
            {   
                dt1 = FEJobobj.GetJobNoList(branchid, divisionid);                
                GrdJobICD.Visible = true;
                GrdJobICD.DataSource = dt1;
                GrdJobICD.DataBind();
            }
            else if (StrTrantype == "FI")
            {
                dt1 = FIJobobj.BindJobgrid(branchid, divisionid);
                GrdFIJob.Visible = true;                
                GrdFIJob.DataSource = dt1;
                GrdFIJob.DataBind();
            }

            //change
            else if (StrTrantype == "AE" || StrTrantype == "AI")
            {
                dt1 = da_obj_AEJobobj.GetAIEAllDetails(StrTrantype, branchid, divisionid);
                grd_airline.Visible = true;
                grd_airline.DataSource = dt1;
                grd_airline.DataBind();
            }
            //change

            if (dt1.Rows.Count == 0)
            {
                if (StrTrantype == "FE")
                {
                    //EmptyGridFE();
                    //GrdJobICD.Visible = true;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer FROM ICD", "alertify.alert('Job Not Available');", true);
                    txtJob.Text = "";
                    txtJob.Focus();
                    return;
                }
                else if (StrTrantype == "FI") 
                {
                    // EmptyGridFI();
                    //GrdFIJob.Visible = true;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer FROM ICD", "alertify.alert('Job Not Available');", true);
                    txtJob.Text = "";
                    txtJob.Focus();
                    return;
                }
                else
                {
                    //EmptyGridAEAI();
                   // GrdFIJob.Visible = true;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer FROM ICD", "alertify.alert('Job Not Available');", true);
                    txtJob.Text = "";
                    txtJob.Focus();
                    return;
                }

            }
            ProgrammaticModalJobICD.Show();
        }
        private void EmptyGridFE()
        {
            DataTable dtempty1 = new DataTable();
            DataRow dr1;

            dtempty1.Columns.Add("jobno");
            dtempty1.Columns.Add("vessel");
            dtempty1.Columns.Add("voyage");
            dtempty1.Columns.Add("mblno");
            dtempty1.Columns.Add("etd");
            dtempty1.Columns.Add("sd");
            dtempty1.Columns.Add("eta");
            dtempty1.Columns.Add("mlo");

            dtempty1.Rows.Add(dtempty1.NewRow());

            GrdJobICD.DataSource = dtempty1;
            GrdJobICD.DataBind();
            //int totalcolums = GrdJobICD.Rows[0].Cells.Count;
            //GrdJobICD.Rows[0].Cells.Clear();
            //GrdJobICD.Rows[0].Cells.Add(new TableCell());
            //GrdJobICD.Rows[0].Cells[0].ColumnSpan = totalcolums;
        }

        private void EmptyGridFI()
        {
            DataTable dtempty2 = new DataTable();
            DataRow dr2;

            dtempty2.Columns.Add("jobno");
            dtempty2.Columns.Add("vessel");
            dtempty2.Columns.Add("voyage");
            dtempty2.Columns.Add("mblno");
            dtempty2.Columns.Add("eta");
            dtempty2.Columns.Add("etd");
            dtempty2.Columns.Add("POL");
            dtempty2.Columns.Add("agent");
            dtempty2.Columns.Add("mlo");

            dtempty2.Rows.Add(dtempty2.NewRow());

            GrdFIJob.DataSource = dtempty2;
            GrdFIJob.DataBind();
            //int totalcolums = GrdFIJob.Rows[0].Cells.Count;
            //GrdFIJob.Rows[0].Cells.Clear();
            //GrdFIJob.Rows[0].Cells.Add(new TableCell());
            //GrdFIJob.Rows[0].Cells[0].ColumnSpan = totalcolums;
        }


        private void EmptyGridAEAI()
        {
            DataTable dtempty2 = new DataTable();
            DataRow dr2;

            dtempty2.Columns.Add("jobno");
            dtempty2.Columns.Add("airline");
            dtempty2.Columns.Add("mawblno");
            dtempty2.Columns.Add("flightdate");
            dtempty2.Columns.Add("agentname");
           

            dtempty2.Rows.Add(dtempty2.NewRow());

            grd_airline.DataSource = dtempty2;
            grd_airline.DataBind();
            //int totalcolums = GrdFIJob.Rows[0].Cells.Count;
            //GrdFIJob.Rows[0].Cells.Clear();
            //GrdFIJob.Rows[0].Cells.Add(new TableCell());
            //GrdFIJob.Rows[0].Cells[0].ColumnSpan = totalcolums;
        }

        protected void GrdJobICD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = GrdJobICD.SelectedRow.RowIndex;
                txtJob.Text = GrdJobICD.SelectedRow.Cells[0].Text;
                txtJob_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void GrdJobICD_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label lblCustomer = (Label)e.Row.FindControl("mlo");
                    string tooltip = lblCustomer.Text;
                    e.Row.Cells[7].Attributes.Add("title", tooltip);

                    Label lblCustomer1 = (Label)e.Row.FindControl("vessel");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[1].Attributes.Add("title", tooltip1);

                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdJobICD, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void GrdFIJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int indexFI = GrdFIJob.SelectedRow.RowIndex;
                txtJob.Text = GrdFIJob.SelectedRow.Cells[0].Text;
                txtJob_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void GrdFIJob_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblCustomer = (Label)e.Row.FindControl("mlo");
                    string tooltip = lblCustomer.Text;
                    e.Row.Cells[8].Attributes.Add("title", tooltip);

                    Label lblCustomer1 = (Label)e.Row.FindControl("vesselname");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[1].Attributes.Add("title", tooltip1);

                    Label lblCustomer2 = (Label)e.Row.FindControl("agent");
                    string tooltip2 = lblCustomer2.Text;
                    e.Row.Cells[7].Attributes.Add("title", tooltip2);


                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdFIJob, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtJob_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int Divid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                StrTrantype = Session["StrTranType"].ToString();
                int Bid = Convert.ToInt32(Session["LoginBranchid"].ToString());

                if (txtJob.Text.ToUpper().Trim() != "")
                {
                    int txtjob = Convert.ToInt32(txtJob.Text.Trim().ToString());
                    dt2 = BLtrobj.CheckFEIJobno(txtjob, StrTrantype, Bid, Divid);
                    if (dt2.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer FROM ICD", "alertify.alert('Enter Valid (Unclosed) Job #');", true);
                        txtJob.Text = "";
                        txtJob.Focus();
                        btnback.Text = "Cancel";
                        btnback.ToolTip = "Cancel";
                        btnback1.Attributes["class"] = "btn ico-cancel";
                    }
                }

                //if (GrdToPol.Rows.Count==0)
                //{
                //    GrdToPol.DataSource = new DataTable();
                //    GrdToPol.DataBind();
                //}
                if (GrdToPol.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer FROM ICD", "alertify.alert('There is No BL To Transfer');", true);
                    txtJob.Text = "";
                    txtJob.Focus();
                    btnback.Text = "Cancel";

                    btnback.ToolTip = "Cancel";
                    btnback1.Attributes["class"] = "btn ico-cancel";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void EmptyGridForPOL()
        {
            DataTable dtempty = new DataTable();
            DataRow dr;

            dtempty.Columns.Add("blno");
            dtempty.Columns.Add("shipper");
            dtempty.Columns.Add("consignee");
            dtempty.Columns.Add("por");
            dtempty.Columns.Add("pol");
            dtempty.Columns.Add("pod");
            dtempty.Columns.Add("fd");
            dtempty.Columns.Add("shortname");
            dtempty.Columns.Add("branchid");

            dtempty.Rows.Add(dtempty.NewRow());
          
            GrdToPol.DataSource = dtempty;
            GrdToPol.DataBind();
            //int totalcolums = GrdToPol.Rows[0].Cells.Count;
            //GrdToPol.Rows[0].Cells.Clear();
            //GrdToPol.Rows[0].Cells.Add(new TableCell());
            //GrdToPol.Rows[0].Cells[0].ColumnSpan = totalcolums;

            //GrdToPol.Rows[0].Cells[0].Text = "No Data Found";
        }

        protected void btntranfer_Click(object sender, EventArgs e)
        {
            try
            {
                int frombranchid = 0;
                DataTable dttrns = new DataTable();
                divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                StrTrantype = Session["StrTranType"].ToString();
                branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                bool chk;
                //if (txtJob.Text.ToUpper().Trim() != "")
                //{
                //    dttrns = BLtrobj.CheckFEIJobno(Convert.ToInt32(txtJob.Text.Trim().ToUpper()), StrTrantype, branchid, divisionid);

                //    if (dttrns.Rows.Count > 0)
                //    {
                        chk = false;
                        for (int i = 0; i < GrdToPol.Rows.Count; i++)
                        {
                            CheckBox ckrowsval = (GrdToPol.Rows[i].Cells[9].FindControl("ChkStatus") as CheckBox);
                            if (ckrowsval.Checked == true)
                            {
                               // blno = GrdToPol.Rows[i].Cells[0].Text;
                                //blno = GrdToPol.Rows[i].Cells[0].FindControl("blno").ToString();
                                blno = ((Label)GrdToPol.Rows[i].Cells[0].FindControl("blno")).Text;
                                frombranchid = Convert.ToInt32(GrdToPol.Rows[i].Cells[8].Text);

                                BLtrobj.InsFEIBLFromFEIBLTransfer(blno, branchid, StrTrantype, frombranchid);
                                BLtrobj.UpdJobnoinFEIBL(blno, 0, StrTrantype, frombranchid, branchid);
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer FROM ICD", "alertify.alert('BL #:" + blno + " Transfer');", true);
                                LogObj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 542, 1, Convert.ToInt32(Session["LoginBranchid"]), txtJob.Text);
                                chk = true;
                            }
                        }
                        //if(chk==false)
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer FROM ICD", "alertify.alert('Select atleast One BL #');", true);
                        //    return;
                        //}
                        FillGridICD();
                        txtJob.Text = "";
                    //}
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer FROM ICD", "alertify.alert('Job# Should Not Be Blank');", true);
                //}
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            if (btnback.ToolTip == "Cancel")
            {
                JobInput.Text = "";
                txtJob.Text = "";
                btnback.Text = "Back";

                btnback.ToolTip = "Back";
                btnback1.Attributes["class"] = "btn ico-back";
            }
            else
            {
              //  this.Response.End();

                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "OPS&DOC")
                    {
                        if (Session["StrTranType"].ToString() == "FI")
                        {

                            Response.Redirect("../Home/OEOpsAndDocs.aspx");

                        }
                        else
                        {
                            this.Response.End();

                        }
                    }
                }
                else
                {
                    this.Response.End();

                }
            }
        }
        protected void Grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblCustomer = (Label)e.Row.FindControl("blno");
                    string tooltip = lblCustomer.Text;
                    e.Row.Cells[0].Attributes.Add("title", tooltip);

                    Label lblCustomer1 = (Label)e.Row.FindControl("shipper");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[1].Attributes.Add("title", tooltip1);

                    Label lblCustomer2 = (Label)e.Row.FindControl("consignee");
                    string tooltip2 = lblCustomer2.Text;
                    e.Row.Cells[2].Attributes.Add("title", tooltip2);

                    Label lblCustomer3 = (Label)e.Row.FindControl("por");
                    string tooltip3 = lblCustomer3.Text;
                    e.Row.Cells[3].Attributes.Add("title", tooltip3);

                    Label lblCustomer4 = (Label)e.Row.FindControl("pol");
                    string tooltip4 = lblCustomer4.Text;
                    e.Row.Cells[4].Attributes.Add("title", tooltip4);

                    Label lblCustomer5 = (Label)e.Row.FindControl("pod");
                    string tooltip5 = lblCustomer5.Text;
                    e.Row.Cells[5].Attributes.Add("title", tooltip5);


                    Label lblCustomer6 = (Label)e.Row.FindControl("fd");
                    string tooltip6 = lblCustomer6.Text;
                    e.Row.Cells[6].Attributes.Add("title", tooltip6);
                    Label lblCustomer7 = (Label)e.Row.FindControl("shortname");
                    string tooltip7 = lblCustomer7.Text;
                    e.Row.Cells[7].Attributes.Add("title", tooltip7); 
                    //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdToPol, "Select$" + e.Row.RowIndex);
                    //e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {


                GrdToPol.PageIndex = e.NewPageIndex;

                StrTrantype = Session["StrTranType"].ToString();
                branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                dt = BLtrobj.GETFEIBLTransICDPort(branchid, StrTrantype);

                if (dt.Rows.Count > 0)
                {
                    GrdToPol.DataSource = dt;
                    GrdToPol.DataBind();
                }
                else
                {
                    EmptyGridForPOL();
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void GrdFIJob_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdFIJob.PageIndex = e.NewPageIndex;
                loadgrid(); 
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void GrdJobICD_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdJobICD.PageIndex = e.NewPageIndex;
                loadgrid(); 
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        //change
        protected void grd_airline_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grd_airline.PageIndex = e.NewPageIndex;
                loadgrid();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_airline_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_airline, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_airline_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = grd_airline.SelectedRow.RowIndex;
                txtJob.Text = grd_airline.SelectedRow.Cells[0].Text;
                txtJob_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        //change

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

            obj_dtlogdetails = LogObj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 542, "TICD", txtJob.Text, txtJob.Text, "");  //"/Rate ID: " +
            if (txtJob.Text != "")
            {
                JobInput.Text = txtJob.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void GrdToPol_PreRender(object sender, EventArgs e)
        {
            if (GrdToPol.Rows.Count > 0)
            {
                GrdToPol.UseAccessibleHeader = true;
                GrdToPol.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}