using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.ShipmentDetails
{
    public partial class TransferFromFIBL : System.Web.UI.Page
    {
        int int_divisionid;
        int int_branchid;

        string str_Trantype;
        string str_filename="";
        string str_BLno;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            try
            {
                str_Trantype = Session["StrTranType"].ToString();
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());

                if (!IsPostBack == true)
                {



                    mdl_FIJob.Hide();
                    mdl_BTJob.Hide();
                    grd_fibl.DataSource = new DataTable();
                    grd_fibl.DataBind();
                    if (str_Trantype == "BT")
                    {
                        opslbl.Visible = false;
                        opslbli.Visible = false;

                        menu.InnerText = "Job Details";
                        HeaderLabel1.InnerText = "Bonded Trucking";
                        str_filename = "Transfer From Imports";
                        header.InnerText = str_filename;
                        lbl_Header.Text = str_filename;
                        grd_fibl.Columns[2].HeaderText = "Customer";
                        DataTable obj_dt_btjinfo = new DataTable();
                        DataAccess.BondedTrucking.BTJobInfo obj_da_btjinfo = new DataAccess.BondedTrucking.BTJobInfo();
                        obj_dt_btjinfo = obj_da_btjinfo.SelFIBT4Transfer(int_branchid, int_divisionid);
                        grd_fibl.DataSource = obj_dt_btjinfo;
                        grd_fibl.DataBind();

                    }
                    else if (str_Trantype == "FI")
                    {
                        str_filename = "Transfer To BT";
                        header.InnerText = str_filename;
                        lbl_Header.Text = str_filename;
                        //menu.InnerText = "Shipment Details";
                        HeaderLabel1.InnerText = "Ocean Imports";
                    }
                    else
                    {
                        menu.Visible = false;
                        opslbl.InnerHtml = "Ops & Docs";
                    }
                    //grd_FIJob.DataSource = new DataTable();
                    //grd_FIJob.DataBind();
                    //grd_BTJob.DataSource = new DataTable();
                    //grd_BTJob.DataBind();
                    
                    //bt.add();
                   btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    txt_job.Focus();


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
                LoadGrid();                
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void LoadGrid()
        {
            string str_Trantype = Session["StrTranType"].ToString();
            btn_cancel.Text = "Cancel";

            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();
            DataAccess.BondedTrucking.BTJobInfo obj_da_btjinfo = new DataAccess.BondedTrucking.BTJobInfo();
           
            DataTable obj_dt_jinfo = new DataTable();

            if (str_Trantype == "FI")
            {
                obj_dt_jinfo = obj_da_jinfo.BindJobgrid(int_branchid, int_divisionid);
                if (obj_dt_jinfo.Rows.Count <= 0)
                {
                    ScriptManager.RegisterStartupScript(btn_trans, typeof(Button), "DataFound", "alertify.alert('Job Not Available');", true);
                }
                else
                {
                    grd_FIJob.Visible = true;
                    grd_BTJob.Visible = false;
                    this.mdl_FIJob.Show();
                    grd_FIJob.DataSource = obj_dt_jinfo;
                    grd_FIJob.DataBind();
                    ViewState["FI"] = obj_dt_jinfo;

                }
                
            }
            else if (str_Trantype == "BT")
            {
                obj_dt_jinfo = obj_da_btjinfo.GetBTJobInfoALL(int_branchid, int_divisionid);
                if (obj_dt_jinfo.Rows.Count <= 0)
                {
                    ScriptManager.RegisterStartupScript(btn_trans, typeof(Button), "DataFound", "alertify.alert('Job Not Available');", true);
                }
                else
                {
                    grd_FIJob.Visible = false;
                    grd_BTJob.Visible = true;
                    this.mdl_BTJob.Show();
                    grd_BTJob.DataSource = obj_dt_jinfo;
                    grd_BTJob.DataBind();
                    ViewState["BT"] = obj_dt_jinfo;
                }

            }
        }
        protected void grd_FIJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index;
               btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                if (grd_FIJob.Rows.Count > 0)
                {
                    int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    index = Convert.ToInt32(grd_FIJob.SelectedRow.RowIndex.ToString());
                    DataTable obj_dt_bldet = new DataTable();
                    DataAccess.ForwardingImports.BLDetails obj_da_bldet = new DataAccess.ForwardingImports.BLDetails();
                    txt_job.Text = grd_FIJob.Rows[index].Cells[0].Text;
                    obj_dt_bldet = obj_da_bldet.GetFIBLTrans4BT(Convert.ToInt32(txt_job.Text), int_branchid, int_divisionid);
                    if (obj_dt_bldet.Rows.Count <= 0)
                    {
                        ScriptManager.RegisterStartupScript(btn_trans, typeof(Button), "DataFound", "alertify.alert('Booking Not Available');", true);
                        
                        
                    }
                    else
                    {
                        grd_fibl.Visible = true;
                        grd_fibl.DataSource = obj_dt_bldet;
                        grd_fibl.DataBind();
                    }
                }
                grd_FIJob.Visible = false;
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
                str_Trantype = "FI";
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                if (txt_job.Text != "")
                {
                    DataTable obj_dt_bldet = new DataTable();
                    if (str_Trantype == "FI")
                    {
                        DataAccess.ForwardingImports.BLDetails obj_da_bldet = new DataAccess.ForwardingImports.BLDetails();
                        obj_dt_bldet = obj_da_bldet.GetFIBLTrans4BT(Convert.ToInt32(txt_job.Text), int_branchid, int_divisionid);
                        grd_fibl.DataSource = obj_dt_bldet;
                        grd_fibl.DataBind();

                    }
                    else if (str_Trantype == "BT")
                    {
                        DataAccess.BondedTrucking.BTJobInfo obj_da_btjinfo = new DataAccess.BondedTrucking.BTJobInfo();
                        obj_dt_bldet = obj_da_btjinfo.GetBTJobInfo(Convert.ToInt32(txt_job.Text), int_branchid, int_divisionid);
                        if (obj_dt_bldet.Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_trans, typeof(Button), "DataFound", "alertify.alert('Invalid Job #');", true);
                            txt_job.Text = "";
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

        protected void btn_trans_Click(object sender, EventArgs e)
        {
            try
            {
                btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                //str_Trantype = "FI";
                bool chk = false;
                if (txt_job.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btn_trans, typeof(Button), "DataFound", "alertify.alert('Job # Should Not Be Blank');", true);
                    return;
                }
                DataAccess.ForwardingImports.BLDetails obj_da_bldet = new DataAccess.ForwardingImports.BLDetails();
                DataAccess.BondedTrucking.BTJobInfo obj_da_btjinfo = new DataAccess.BondedTrucking.BTJobInfo();
                DataTable obj_dt_bldet = new DataTable();
                if (str_Trantype == "FI")
                {
                    for (int i = 0; i < grd_fibl.Rows.Count; i++)
                    {
                        CheckBox check;
                        check = (CheckBox)(grd_fibl.Rows[i].FindControl("chk_select"));

                        if (check.Checked == true)
                        {
                            str_BLno = grd_fibl.Rows[i].Cells[0].Text;
                            obj_da_bldet.InsFI4BTTrans(Convert.ToInt32(txt_job.Text), str_BLno, int_branchid, int_divisionid);
                            chk = true;
                        }
                    }
                    if (chk == false)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer FROM ICD", "alertify.alert('Select atleast One BL #');", true);
                        return;
                    }
                    obj_dt_bldet = obj_da_bldet.GetFIBLTrans4BT(Convert.ToInt32(txt_job.Text), int_branchid, int_divisionid);
                    grd_fibl.DataSource = obj_dt_bldet;
                    grd_fibl.DataBind();
                    ScriptManager.RegisterStartupScript(btn_trans, typeof(Button), "DataFound", "alertify.alert('Transfered To BT');", true);
                    txt_job.Text = "";
                }
                else if (str_Trantype == "BT")
                {
                    for (int i = 0; i < grd_fibl.Rows.Count; i++)
                    {
                        CheckBox check;
                        check = (CheckBox)(grd_fibl.Rows[i].FindControl("chk_select"));

                        if (check.Checked == true)
                        {
                            str_BLno = grd_fibl.Rows[i].Cells[0].Text;
                            obj_da_btjinfo.InsBTSBDtls(Convert.ToInt32(txt_job.Text), str_BLno, int_branchid, int_divisionid);
                            chk = true;
                        }
                    }
                    if (chk == false)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer FROM ICD", "alertify.alert('Select atleast One BL #');", true);
                        return;
                    }
                    obj_dt_bldet = obj_da_btjinfo.SelFIBT4Transfer(int_branchid, int_divisionid);
                    grd_fibl.DataSource = obj_dt_bldet;
                    grd_fibl.DataBind();
                    ScriptManager.RegisterStartupScript(btn_trans, typeof(Button), "DataFound", "alertify.alert('Details Transfered');", true);
                    txt_job.Text = "";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void grd_BTJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (grd_BTJob.Rows.Count > 0)
                {
                    txt_job.Text = grd_BTJob.Rows[grd_BTJob.SelectedRow.RowIndex].Cells[0].Text;
                }
                grd_BTJob.Visible = false;
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
                txt_job.Text = "";
                //btnsave.Text = "Save";
                btn_cancel.Enabled = true;
                btn_cancel.Text = "Back";

                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                txt_job.Focus();
            }
            else
            {
                this.Response.End();
            }
        }

        protected void grd_BTJob_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_BTJob, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
          
        }

        protected void grd_FIJob_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblCustomer = (Label)e.Row.FindControl("vesselname");
                string tooltip = lblCustomer.Text;
                e.Row.Cells[1].Attributes.Add("title", tooltip);

                Label lblCustomer1 = (Label)e.Row.FindControl("voyage");
                string tooltip1 = lblCustomer1.Text;
                e.Row.Cells[2].Attributes.Add("title", tooltip1);

                Label lblCustomer2 = (Label)e.Row.FindControl("mblno");
                string tooltip2 = lblCustomer2.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip2);

                Label lblCustomer3 = (Label)e.Row.FindControl("etd");
                string tooltip3 = lblCustomer3.Text;
                e.Row.Cells[4].Attributes.Add("title", tooltip3);

                Label lblCustomer4 = (Label)e.Row.FindControl("eta");
                string tooltip4 = lblCustomer4.Text;
                e.Row.Cells[5].Attributes.Add("title", tooltip4);

                Label lblCustomer5 = (Label)e.Row.FindControl("POL");
                string tooltip5 = lblCustomer5.Text;
                e.Row.Cells[6].Attributes.Add("title", tooltip5);

                Label lblCustomer6 = (Label)e.Row.FindControl("agent");
                string tooltip6 = lblCustomer6.Text;
                e.Row.Cells[7].Attributes.Add("title", tooltip6);

                Label lblCustomer7 = (Label)e.Row.FindControl("MLO");
                string tooltip7 = lblCustomer7.Text;
                e.Row.Cells[8].Attributes.Add("title", tooltip7);
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_FIJob, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_fibl_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_fibl, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_FIJob_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grd_FIJob.PageIndex = e.NewPageIndex;
                this.mdl_FIJob.Show();
                //LoadGrid();
                grd_FIJob.DataSource = (DataTable)ViewState["FI"];
                grd_FIJob.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
           
        }

        protected void grd_BTJob_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grd_BTJob.PageIndex = e.NewPageIndex;
                //LoadGrid();
                this.mdl_BTJob.Show();
                grd_BTJob.DataSource = (DataTable)ViewState["BT"];
                grd_BTJob.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void grd_fibl_PreRender(object sender, EventArgs e)
        {
            if (grd_fibl.Rows.Count > 0)
            {
                grd_fibl.UseAccessibleHeader = true;
                grd_fibl.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}