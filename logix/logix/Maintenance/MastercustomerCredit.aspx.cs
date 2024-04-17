using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;


namespace logix.Maintenance
{
    public partial class MastercustomerCredit : System.Web.UI.Page
    {
        int ownerID = 0;
        string panno = string.Empty;
        string customerpan = string.Empty;
        string gst = string.Empty;
        string hf_employeeid = string.Empty;

        DataAccess.Masters.MasterCustomerGroup obj_main = new DataAccess.Masters.MasterCustomerGroup();
        DataAccess.Masters.MasterCreditApproval obj_creditapp = new DataAccess.Masters.MasterCreditApproval();
        DataAccess.Masters.MasterCustomerGroup obj_group = new DataAccess.Masters.MasterCustomerGroup();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCreditApproval Appro_obj = new DataAccess.Masters.MasterCreditApproval();


        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "dropdownButton();SpanTagMoveInputBottom();MuiTextField();", true);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Grd_MAsterCredit);



            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {


                obj_main.GetDataBase(Ccode);
                obj_creditapp.GetDataBase(Ccode);
                obj_group.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                Appro_obj.GetDataBase(Ccode);
            
            }

            if (!IsPostBack)
            {
                Grd_MAsterCredit.DataSource = new DataTable();
                Grd_MAsterCredit.DataBind();
                panno = Session["pannocredit"].ToString();
                if (panno != "")
                {
                    lblpanno.Text = panno;
                    plblan.Visible = true;
                }
                else
                {
                    plblan.Visible = false;
                }
                customerpan = Session["pancustomercredit"].ToString();
                if (customerpan != "")
                {
                    lblcustomername.Text = customerpan.ToUpper();
                }
                gst = Session["gst"].ToString();
                hf_employeeid = Session["hf_employeeided"].ToString();
                FillVolumeType();
                fillcreditgrd();
                if (txt_exemptions.Text == "")
                {
                    txt_exemptions.Text = "3";
                }
                if (ddl_per.SelectedValue == "")
                {
                    ddl_per.SelectedValue = "2";
                }
                if (txt_overdue.Text == "")
                {
                    txt_overdue.Text = "50";
                }
                if (!string.IsNullOrEmpty(Session["hidpaninput"].ToString()))
                {
                    hidpaninput.Value = Session["hidpaninput"].ToString();
                    if (hidpaninput.Value == "Y")
                    {
                        plblan.Visible = false;
                    }
                }
            }
            else
            {
                panno = Session["pannocredit"].ToString();
                customerpan = Session["pancustomercredit"].ToString();
                gst = Session["gst"].ToString();
                hf_employeeid = Session["hf_employeeided"].ToString();
                lblcustomername.Text = customerpan.ToUpper();
            }
            //else if (Page.IsPostBack)
            //{
            //    //txtlocation_TextChanged1(sender, e);
            //    WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
            //    int indx = wcICausedPostBack.TabIndex;
            //    var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
            //               where control.TabIndex > indx
            //               select control;
            //    ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
            //}

        }


        private void FillVolumeType()
        {
            // ddlvolumetype.Items.Add("Select");
            ddlvolumetype.Items.Add("Teus");
            ddlvolumetype.Items.Add("CBM");
            ddlvolumetype.Items.Add("Kgs");
        }

        public void fillcreditgrd()
        {
            int groupid = 0;
            //DataAccess.Masters.MasterCustomerGroup obj_main = new DataAccess.Masters.MasterCustomerGroup();
            string data = string.Empty;
            DataTable dt = new DataTable();
            dt = obj_main.GetAllGrouppan(panno.ToUpper(), customerpan, "", 0);
            if (dt.Rows.Count > 0)
            {
                data = dt.Rows[0]["groupid"].ToString();
                groupid =  Convert.ToInt32(dt.Rows[0]["groupid"].ToString());
            }
            else
            {
                if (Session["groupid"] != null)
                {
                    groupid = Convert.ToInt32(Session["groupid"]);
                }
            }
            if (groupid != 0)
            {
                DataTable dts = new DataTable();
               // DataAccess.Masters.MasterCreditApproval obj_creditapp = new DataAccess.Masters.MasterCreditApproval();
                dts = obj_creditapp.selgridMasterCreditApp4Prod(groupid, Convert.ToInt32(Session["LoginDivisionId"]));
                DataRow dr = dts.NewRow();
                if (dts.Rows.Count > 0)
                {
                    //DataRow dr1 = dts.NewRow();
                    //dr1["VolumeType"] = "Total";
                    //dr1["Creditdays"] = Convert.ToDouble(dts.Compute("sum(Creditdays)", string.Empty)).ToString();
                    //dr1["CreditAmount"] = Convert.ToDouble(dts.Compute("sum(CreditAmount)", string.Empty)).ToString("0.00");
                    //dts.Rows.Add(dr1);

                    Grd_MAsterCredit.DataSource = dts;
                    Grd_MAsterCredit.DataBind();
                    //Grd_MAsterCredit.Columns[7].Visible = false;
                    //Grd_MAsterCredit.Columns[8].Visible = false;
                    //Grd_MAsterCredit.Columns[9].Visible = false;
                    //Grd_MAsterCredit.Columns[10].Visible = false;

                }
            }
        }
        protected void Imgsb_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dtSB = new DataTable();
            DataTable dtgrid1 = new DataTable();
            ImageButton lb = (ImageButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            DataTable dt = new DataTable();
          //  DataAccess.Masters.MasterCreditApproval obj_creditapp = new DataAccess.Masters.MasterCreditApproval();
            if (Grd_MAsterCredit.Rows.Count > 0)
            {
                int rowID = gvRow.RowIndex;
                hid_crid.Value = Grd_MAsterCredit.Rows[rowID].Cells[8].Text;
            }
            int groupid = 0;
            //DataAccess.Masters.MasterCustomerGroup obj_main = new DataAccess.Masters.MasterCustomerGroup();
            string data = string.Empty;
            dt = obj_main.GetAllGrouppan(panno.ToUpper(), customerpan.ToUpper(), "", 0);
            if (dt.Rows.Count > 0)
            {
                data = dt.Rows[0]["groupid"].ToString();
                groupid = Convert.ToInt32(dt.Rows[0]["groupid"].ToString());
            }
            else
            {
                if (!string.IsNullOrEmpty(Session["groupid"].ToString()))
                {
                    groupid = Convert.ToInt32(Session["groupid"]);
                }
            }
            if (groupid != 0)
            {
                // hid_crid.Value = Gridcreditreq.SelectedRow.Cells[8].Text;
                DataTable dtgrid = new DataTable();
                if (hid_crid.Value != "")
                {
                    dtgrid = obj_creditapp.delgridMasterCreditApp4Prod(groupid, Convert.ToInt32(hid_crid.Value));
                    dtgrid1 = obj_creditapp.selgridMasterCreditApp4Prod(groupid, Convert.ToInt32(Session["LoginDivisionId"]));
                    DataRow dr = dtgrid1.NewRow();
                    if (dtgrid1.Rows.Count > 0)
                    {
                        DataRow dr1 = dtgrid1.NewRow();
                        dr1["VolumeType"] = "Total";
                        dr1["Creditdays"] = Convert.ToDouble(dtgrid1.Compute("sum(Creditdays)", string.Empty)).ToString();
                        dr1["CreditAmount"] = Convert.ToDouble(dtgrid1.Compute("sum(CreditAmount)", string.Empty)).ToString("0.00");
                        dtgrid1.Rows.Add(dr1);
                        Grd_MAsterCredit.DataSource = dtgrid1;
                        Grd_MAsterCredit.DataBind();
                        pnlcreditreq.Visible = true;
                    }
                    else
                    {
                        Grd_MAsterCredit.DataSource = dtgrid1;
                        Grd_MAsterCredit.DataBind();
                        pnlcreditreq.Visible = true;

                    }
                    ScriptManager.RegisterStartupScript(btnCreditRequestAdd, typeof(Button), "DataFound", "alertify.alert('Product Details Deleted');", true);
                    btnCreditRequestAdd.ToolTip = "ADD";
                    //  btn_add1.Attributes["class"] = "btn btn-add1 MCtrl MT10";
                }
            }
        }


        protected void btnCreditRequestAdd_Click(object sender, EventArgs e)
        {
           // DataAccess.Masters.MasterCreditApproval obj_creditapp = new DataAccess.Masters.MasterCreditApproval();
            DataTable dtss = new DataTable();
            dtss = obj_creditapp.sp_getdetailcustomerpan(customerpan.ToUpper());
            if (dtss.Rows.Count > 0)
            {
                panno = dtss.Rows[0]["CustomerPANno"].ToString();
            }


            if (panno != "" && customerpan != "")
            {
                int prod;
                prod = Convert.ToInt32(ddlProductType.SelectedValue);
                string str_usermailid = Session["usermailid"].ToString();
                string str_mailpwd = Session["usermailpwd"].ToString();
                string strDate, strDate1;
                // DataAccess.Masters.MasterCreditApproval obj_creditapp = new DataAccess.Masters.MasterCreditApproval();
                //DataAccess.Masters.MasterCustomerGroup obj_group = new DataAccess.Masters.MasterCustomerGroup();
                //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                int groupid = 0;
               // DataAccess.Masters.MasterCustomerGroup obj_main = new DataAccess.Masters.MasterCustomerGroup();
                string data = string.Empty;
                DataTable dt = new DataTable();
                dt = obj_main.GetAllGrouppan(panno.ToUpper(), customerpan, "", 0);
                if (dt.Rows.Count > 0)
                {
                    data = dt.Rows[0]["groupid"].ToString();
                    groupid = Convert.ToInt32(dt.Rows[0]["groupid"].ToString());
                }
                else
                {
                    if (!string.IsNullOrEmpty(Session["groupid"].ToString()))
                    {
                        groupid = Convert.ToInt32(Session["groupid"]);
                    }
                }
                if (groupid != 0)
                {
                    int Div_ID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    // groupid = Convert.ToInt32(hdn_cusid.Value.ToString());
                    string vtype = ddlvolumetype.SelectedValue.ToString();
                    DateTime now = DateTime.Now;
                    DateTime RegDtae = DateTime.Now;
                    DateTime INDate = DateTime.Now;
                    if (ddlvolumetype.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnCreditRequestAdd, typeof(Button), "DataFound", "alertify.alert('Select Volume type');", true);
                        ddlvolumetype.Focus();
                        return;
                    }
                    if (txt_vol.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnCreditRequestAdd, typeof(Button), "DataFound", "alertify.alert('Kindly Enter the Volume');", true);
                        txt_vol.Focus();

                        return;
                    }
                    if (txt_creditdays.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnCreditRequestAdd, typeof(Button), "DataFound", "alertify.alert('Kindly Enter the Credit days');", true);
                        txt_creditdays.Focus();

                        return;
                    }
                    if (txtCreditAboveamt.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnCreditRequestAdd, typeof(Button), "DataFound", "alertify.alert('Kindly Enter the Credit amount');", true);
                        txtCreditAboveamt.Focus();

                        return;
                    }
                    if (txt_revenue.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnCreditRequestAdd, typeof(Button), "DataFound", "alertify.alert('Kindly Enter the Revenue');", true);
                        txt_revenue.Focus();

                        return;
                    }
                    if (ddlProductType.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(btnCreditRequestAdd, typeof(Button), "DataFound", "alertify.alert('Select Product');", true);
                        return;
                    }

                    int salesname = 0;
                    if (hf_employeeid != "")
                    {
                        salesname = Convert.ToInt32(hf_employeeid.ToString());
                    }
                    int clienttypeval = 1;
                    string remarks = "";
                    int cridtype = 1;
                    string txt_AboutCust = "";
                    int categoryval = 2;
                    string txt_DocReceived = "";
                    string ptc = "";
                    ownerID = 2;
                    int apptype = 1;
                    int EmpId = Convert.ToInt32(Session["LoginEmpId"].ToString());
                    //DataAccess.Masters.MasterCreditApproval Appro_obj = new DataAccess.Masters.MasterCreditApproval();
                    DateTime date = Convert.ToDateTime(now);
                    string datapo = "";
                    string canno = "";
                    // string txt_vol = "1";
                    DataTable dts = new DataTable();
                    dts = obj_creditapp.Getdetailscreditapproval(groupid, Div_ID);
                    string txtlandline = "";
                    string txtMobile = "";
                    string txt_email = "";
                    if (dts.Rows.Count == 0)
                    {
                        obj_creditapp.InsertMasterCreditApp(groupid, categoryval, panno.ToUpper(), gst.ToUpper(), RegDtae, INDate,
                            txt_DocReceived, datapo, txtlandline, txtMobile, txt_email, clienttypeval, txt_vol.Text.ToString(), vtype, Convert.ToDouble(txt_revenue.Text),
                            txt_AboutCust, Convert.ToInt16(txt_creditdays.Text.Trim()),
                            Convert.ToDouble(txtCreditAboveamt.Text.ToUpper().Trim()), cridtype, ownerID, Convert.ToInt32(Session["LoginEmpId"]), remarks, Div_ID);
                        string approdata = Appro_obj.UpdMasterCAppNew(groupid, canno, date, 0, 0, 0, ' ', 0, 0, 0, ' ', 0, 0, 0, ' ', EmpId, Convert.ToDouble(txtCreditAboveamt.Text.Trim()), Convert.ToInt32(txt_creditdays.Text.Trim()), apptype, Div_ID);
                        int exp = 3;
                        int due = 50;
                        int intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                        string exmode = "";
                        if (ddl_per.Text == "Annual")
                        {
                            exmode = "A";
                        }
                        else if (ddl_per.Text == "Month")
                        {
                            exmode = "M";
                        }
                        else
                        {
                            exmode = "M";
                        }
                        Appro_obj.UpdMasterCreditApprovalCUSTLIMITS(groupid, intBranchID, Div_ID, exp, due, exmode);
                        obj_creditapp.UpdMasterCreditApp(groupid, categoryval, panno.ToUpper().Trim(), gst.ToUpper(), RegDtae, INDate, txt_DocReceived, ptc, txtlandline, txtMobile, txt_email.ToUpper(), clienttypeval, txt_vol.Text.ToUpper(), vtype, Convert.ToDouble(txt_revenue.Text.ToUpper()), txt_AboutCust.ToUpper().Trim(), Convert.ToInt32(txt_creditdays.Text.ToUpper().Trim()), Convert.ToDouble(txtCreditAboveamt.Text.Trim()), cridtype, ownerID, salesname, remarks.ToUpper(), Div_ID, prod);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 288, 1, Convert.ToInt32(Session["LoginBranchid"]), "groupid for " + groupid);
                    }
                    else
                    {
                        obj_creditapp.UpdMasterCreditApp(groupid, categoryval, panno.ToUpper().Trim(), gst.ToUpper(), RegDtae, INDate, txt_DocReceived, ptc, txtlandline, txtMobile, txt_email.ToUpper(), clienttypeval, txt_vol.Text.ToUpper(), vtype, Convert.ToDouble(txt_revenue.Text.ToUpper()), txt_AboutCust.ToUpper().Trim(), Convert.ToInt32(txt_creditdays.Text.ToUpper().Trim()), Convert.ToDouble(txtCreditAboveamt.Text.Trim()), cridtype, ownerID, salesname, remarks.ToUpper(), Div_ID, prod);
                    }

                    // update 19/12/2022
                    obj_creditapp.updateCreditapprovalproduct(groupid, prod, Convert.ToInt32(txt_creditdays.Text), Convert.ToInt32(txt_creditdays.Text), Convert.ToDouble(txtCreditAboveamt.Text), INDate, EmpId);
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 288, 2, Convert.ToInt32(Session["LoginBranchid"]), "groupid for " + groupid);

                    if (btnCreditRequestAdd.ToolTip == "ADD")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Product Details Saved')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Product Details Updated')", true);
                    }
                    btnCreditRequestAdd.ToolTip = "ADD";
                    btnCreditRequestAdd.Attributes["class"] = "btn btn-add1 MCtrl MT10";
                    //   dtgrid = obj_creditapp.selgridMasterCreditApp4Prod(groupid, Convert.ToInt32(Session["LoginDivisionId"]));
                    DataTable dtgrid = new DataTable();
                    dtgrid = obj_creditapp.selgridMasterCreditApp4Prod(groupid, Convert.ToInt32(Session["LoginDivisionId"]));
                    DataRow dr = dtgrid.NewRow();
                    if (dtgrid.Rows.Count > 0)
                    {
                        DataRow dr1 = dtgrid.NewRow();
                        dr1["VolumeType"] = "Total";
                        dr1["Creditdays"] = Convert.ToDouble(dtgrid.Compute("sum(Creditdays)", string.Empty)).ToString();
                        dr1["CreditAmount"] = Convert.ToDouble(dtgrid.Compute("sum(CreditAmount)", string.Empty)).ToString("0.00");
                        dtgrid.Rows.Add(dr1);
                        Grd_MAsterCredit.DataSource = dtgrid;
                        Grd_MAsterCredit.DataBind();
                        pnlcreditreq.Visible = true;
                    }
                    ddlvolumetype.SelectedIndex = 0;
                    txt_vol.Text = "";
                    txt_creditdays.Text = "";
                    txtCreditAboveamt.Text = "";
                    txt_revenue.Text = "";
                    ddlProductType.SelectedIndex = 0;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Correct Customer name')", true);
                    return;
                }
            }
        }

        protected void txt_overdue_TextChanged(object sender, EventArgs e)
        {
            int due = Convert.ToInt32(txt_overdue.Text);
            if (due >= 100 && due != 100)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master Approval", "alertify.alert('Overdue is Less Then 100');", true);
                txt_overdue.Text = "";
                txt_overdue.Focus();
            }
        }

        protected void Grd_MAsterCredit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtgrid1 = new DataTable();
            DataTable dtgrid = new DataTable();
            int index = Grd_MAsterCredit.SelectedIndex;
            string prod = Grd_MAsterCredit.SelectedRow.Cells[1].Text;
            if (prod == "All")
            {
                ddlProductType.SelectedValue = "1";
            }
            if (prod == "OceanExport-FCL")
            {
                ddlProductType.SelectedValue = "2";
            }
            if (prod == "OceanExport-LCL")
            {
                ddlProductType.SelectedValue = "3";
            }
            if (prod == "OceanImport-FCL")
            {
                ddlProductType.SelectedValue = "4";
            }
            if (prod == "OceanImport-LCL")
            {
                ddlProductType.SelectedValue = "5";
            }
            if (prod == "AirExport")
            {
                ddlProductType.SelectedValue = "6";
            }
            if (prod == "AirImport")
            {
                ddlProductType.SelectedValue = "7";
            }
            //  ddlProductType.= Gridcreditreq.SelectedRow.Cells[1].Text;
            string datata = Grd_MAsterCredit.SelectedRow.Cells[1].Text;
            if (datata != "&nbsp;")
            {
                txt_vol.Text = Grd_MAsterCredit.SelectedRow.Cells[2].Text;
                ddlvolumetype.SelectedValue = Grd_MAsterCredit.SelectedRow.Cells[3].Text;
                txt_revenue.Text = Grd_MAsterCredit.SelectedRow.Cells[4].Text;
                txt_creditdays.Text = Grd_MAsterCredit.SelectedRow.Cells[5].Text;
                txtCreditAboveamt.Text = Grd_MAsterCredit.SelectedRow.Cells[6].Text;
                txtCreditAboveamt.Text = Convert.ToDecimal(txtCreditAboveamt.Text).ToString("#,##0");
                hid_crid.Value = Grd_MAsterCredit.SelectedRow.Cells[8].Text;
                ddl_per.SelectedValue = Grd_MAsterCredit.SelectedRow.Cells[9].Text;
                if (txt_exemptions.Text == "")
                {
                    txt_exemptions.Text = "3";
                }
                if (ddl_per.SelectedValue == "")
                {
                    ddl_per.SelectedValue = "2";
                }
                if (txt_overdue.Text == "")
                {
                    txt_overdue.Text = "50";
                }
                btnCreditRequestAdd.ToolTip = "Update";
                Grd_MAsterCredit.Attributes["class"] = "btn btn-UpdateAdd2";
            }
            else
            {
                ddlProductType.SelectedValue = "0";
                txt_revenue.Text = "";
                ddlvolumetype.SelectedValue = "0";
                txt_creditdays.Text = "";
                txtCreditAboveamt.Text = "";
                txt_vol.Text = "";
                btnCreditRequestAdd.ToolTip = "ADD";
                //  btn_add1.Attributes["class"] = "btn btn-add1 MCtrl MT10";
            }
        }

        protected void Grd_MAsterCredit_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_MAsterCredit, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ddlProductType.SelectedValue = "0";
            txt_vol.Text = "";
            ddlvolumetype.SelectedValue = "0";
            txt_revenue.Text = "";
            txt_creditdays.Text = "";
            txtCreditAboveamt.Text = "";
            btnCreditRequestAdd.ToolTip = "ADD";
            ddl_per.SelectedIndex = 2;
        }

    }
}