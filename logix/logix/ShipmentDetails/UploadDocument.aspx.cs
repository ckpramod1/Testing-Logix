using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using Ionic.Zip;
using System.Text.RegularExpressions;


namespace logix.ShipmentDetails
{
    public partial class UploadDocument : System.Web.UI.Page
    {

        DataTable obj_dt = new DataTable();
        int bid, cid;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string Str_date = "", str_alltype = "", Str_type = "";
        string str_Uiid = "";
        string Str_Result = "";
        DateTime dtnow = new DateTime();
        DataAccess.Documents Dobj = new DataAccess.Documents();
        DataAccess.Documents objp = new DataAccess.Documents();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.UserPermission user_check = new DataAccess.UserPermission();
        DataAccess.ForwardingImports.JobInfo obj_da_FIJob = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.Documents obj_da_Document = new DataAccess.Documents();
        DataAccess.ForwardingExports.JobInfo obj_da_FEJob = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingImports.BLDetails obj_da_FIBL = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.AirImportExports.AIEJobInfo obj_da_AEJob = new DataAccess.AirImportExports.AIEJobInfo();
        DataAccess.CustomHousingAgent.JobInfo obj_da_CHAJob = new DataAccess.CustomHousingAgent.JobInfo();
        DataAccess.Masters.MasterDocument obj_da_Document2 = new DataAccess.Masters.MasterDocument();
        DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
        DataAccess.Payroll.Details obj_da_Pay = new DataAccess.Payroll.Details();
        DataAccess.Documents obj_da_Doc = new DataAccess.Documents();
        
        int uiid;
        string refno;
        string doctyp;
        int doccid;
        string voutype;
        string username = "";
        string password = "";
        int voutypeid;
        string docname;
        string ip = "";
        string dbname = "";

        protected string DBCS;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Dobj.GetDataBase(Ccode);
                objp.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                user_check.GetDataBase(Ccode);
                obj_da_FIJob.GetDataBase(Ccode);
                obj_da_Document.GetDataBase(Ccode);
                obj_da_FEJob.GetDataBase(Ccode);


                obj_da_FIBL.GetDataBase(Ccode);
                obj_da_AEJob.GetDataBase(Ccode);
                obj_da_CHAJob.GetDataBase(Ccode);
                obj_da_Document2.GetDataBase(Ccode);
                obj_da_Branch.GetDataBase(Ccode);


                obj_da_Pay.GetDataBase(Ccode);
                obj_da_Doc.GetDataBase(Ccode);
                obj_da_Branch.GetDataBase(Ccode);


            }


            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(grdbudget);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            //else if (Session["StrTranType"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            //}

            try
            {
                dtnow = DateTime.Now;
                bid = Convert.ToInt32(Session["LoginBranchid"]);
                cid = Convert.ToInt32(Session["LoginDivisionId"]);
                // ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(linkjob);
                // Str_type, Str_date, str_DataType;
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnSave);
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnclose);
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btndown);
                if (!IsPostBack)
                {

                    Session["dt"] = "";
                    Ctrl_List = txtjob.ID + "~" + txtVsl.ID + "~" + txtRemarks.ID;
                    Msg_List = "Job~Vessel~Remarks";
                    Dtype_List = "String~String~String";
                    btnSave.Attributes.Add("onclick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    Utility.Fn_CheckUserRights(str_Uiid, btnSave, null, null);
                    emptygrdbind();
                    Fn_LoadDocType();
                    btnclose.Text = "Cancel";
                    btnclose.ToolTip = "Cancel";
                    btn_close1.Attributes["class"] = "btn ico-cancel";
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        headerlable1.InnerText = "Ocean Exports";
                        A1.InnerText = "Documentation";
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        headerlable1.InnerText = "Ocean Imports";
                        A1.InnerText = "Documentation";
                    }
                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        headerlable1.InnerText = "Air Exports";
                        A1.InnerText = "Documentation";
                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        headerlable1.InnerText = "Air Imports";
                        A1.InnerText = "Documentation";
                    }
                    else if (Session["StrTranType"].ToString() == "CH")
                    {
                        headerlable1.InnerText = "Shipment Details";
                        A1.InnerText = "Custom House Agent";
                    }
                    else if (Session["StrTranType"].ToString() == "CO")
                    {
                        headerlable1.InnerText = "Vouchers-Proforma";
                        A1.InnerText = "Accounts and Finanace";
                        //A1.InnerText = "Operating Accounts";
                    }
                    else if (Session["StrTranType"].ToString() == "FA")
                    {
                        headerlable1.InnerText = "Vouchers";
                        A1.InnerText = "Financial Accounts";
                        //A1.InnerText = "Operating Accounts";
                    }
                    else if (Session["StrTranType"].ToString() == "FC")
                    {
                        headerlable1.InnerText = "Vouchers";
                        A1.InnerText = "Financial Accounts";
                        //A1.InnerText = "Operating Accounts";
                    }
                    if (Request.QueryString.ToString().Contains("updoc"))
                    {
                        up_doc.Visible = true;
                        try
                        {
                            //if (Session["UploadDocument"].ToString() == null)
                            if (Session["txtjobno"] != null)
                            {

                                txtjob.Text = Session["txtjobno"].ToString();
                                //hid_doc.Value = Session["hf_txtrefno"].ToString();

                                try
                                {
                                    if (Session["vouno"] != null)
                                    {
                                        txtDoc.Text = Session["vouno"].ToString();
                                    }
                                    else
                                    {
                                        txtDoc.Text = Session["hf_txtrefno"].ToString();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    string message = ex.Message.ToString();
                                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                                }

                            }
                            else
                            {

                                txtjob.Text = Session["hf_txtrefno"].ToString();
                                //hid_doc.Value = Session["hf_txtrefno"].ToString();

                                try
                                {
                                    if (Session["vouno"] != null)
                                    {
                                        txtDoc.Text = Session["vouno"].ToString();
                                    }
                                    else
                                    {
                                        txtDoc.Text = Session["hf_txtrefno"].ToString();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    string message = ex.Message.ToString();
                                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

                                }
                            }
                            hid_doc.Value = Session["hf_txtrefno"].ToString();
                            Fn_FillVoyage();
                            Fn_FillGrid();
                            if (Session["StrTranType"].ToString() == "FE")
                            {

                                Session["UploadDocument"] = 10069;
                            }
                            else if (Session["StrTranType"].ToString() == "FI")
                            {
                                Session["UploadDocument"] = 10073;
                            }
                            else if (Session["StrTranType"].ToString() == "AE")
                            {
                                Session["UploadDocument"] = 10058;
                            }
                            else if (Session["StrTranType"].ToString() == "AI")
                            {
                                Session["UploadDocument"] = 10062;
                            }
                            else if (Session["StrTranType"].ToString() == "FC")
                            {
                                if(Session["ddltype"].ToString() == "Proforma CN-Admin")
                                {
                                    Session["UploadDocument"] = 1181;
                                }
                                else
                                {
                                    Session["UploadDocument"] = 1180;
                                }
                                
                            }
                            else if (Session["StrTranType"].ToString() == "OC")
                            {
                                if (Session["ddltype"].ToString() == "Proforma CN-Admin")
                                {
                                    Session["UploadDocument"] = 1138;
                                }
                                else
                                {
                                    Session["UploadDocument"] = 1137;
                                }
                            }

                            //else if (Session["hf_txtrefno"] != null)
                            //{
                            //    DataTable dt2 = new DataTable();
                            //    dt2 = objp.ddl_doctype(Session["StrTranType"].ToString());
                            //    ViewState["dt2"] = dt2;
                            //    if (ViewState["dt2"] != null)
                            //    {
                            //        DataTable dt3 = (DataTable)ViewState["dt2"];
                            //        for (int i = 0; i < dt3.Rows.Count; i++)
                            //        {
                            //            docname = dt3.Rows[i]["docname"].ToString();
                            //        }
                            //    }
                            //    ddlDoc.SelectedItem.Text = docname;

                            //}
                        }
                        catch (Exception ex)
                        {
                            string message = ex.Message.ToString();
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

                        }



                    }

                    else
                    {

                        //if (Session["StrTranType"].ToString() == "FE")
                        //{

                        //    Session["UploadDocument"] = 10069;
                        //}
                        //else if (Session["StrTranType"].ToString() == "FI")
                        //{
                        //    Session["UploadDocument"] = 10073;
                        //}
                        //else if (Session["StrTranType"].ToString() == "AE")
                        //{
                        //    Session["UploadDocument"] = 10058;
                        //}
                        //else if (Session["StrTranType"].ToString() == "AI")
                        //{
                        //    Session["UploadDocument"] = 10062;
                        //}
                        //else if (Session["StrTranType"].ToString() == "CH")
                        //{
                        //    Session["UploadDocument"] = 520;
                        //}
                        //Fn_FillGrid();
                    }

                }
                else if (Page.IsPostBack)
                {
                    WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                    int indx = wcICausedPostBack.TabIndex;
                    var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                               where control.TabIndex > indx
                               select control;
                    ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected Control GetControlThatCausedPostBack(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button || c is System.Web.UI.WebControls.ImageButton)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;

        }
        public void emptygrdbind()
        {
            //  Grd_Doc.Visible = true;

            grdbudget.Visible = true;
            DataTable dt = new DataTable();
            if (dt.Rows.Count > 0)
            {
                //Grd_Doc.DataSource = dt;
                //Grd_Doc.DataBind();
                grdbudget.DataSource = dt;
                grdbudget.DataBind();

            }
            else
            {
                // Grd_Doc.DataSource = dt;
                // Grd_Doc.DataBind();

                grdbudget.DataSource = dt;
                grdbudget.DataBind();

            }
        }
        private void Fn_LoadDocType()
        {
            try
            {
                //ddlDoc.Items.Clear();
                //ddlDoc.Items.Add("--DOC TYPE--");


               //. DataAccess.ForwardingImports.JobInfo obj_da_FIJob = new DataAccess.ForwardingImports.JobInfo();
                obj_dt = obj_da_FIJob.GetGuruTypenew();
                //   obj_dt = obj_da_FIJob.GetGuruType("FE");


                ddlDoc.DataSource = obj_dt;
                ddlDoc.DataTextField = "docname";
                ddlDoc.DataValueField = "docid";
                ddlDoc.DataBind();
                //ddlDoc.Items.Insert(0, new ListItem("--DOC TYPE---", "0"));
                if (Session["ddltype"] != null)
                {
                    docname = objp.ddldoctypename(Session["ddltype"].ToString());
                    ddlDoc.SelectedItem.Text = docname;
                }

                //ddlDocNum.Enabled = true;
                LoadDoc();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }




        protected void linkjob_Click(object sender, EventArgs e)
        {
            try
            {
                Loadjob();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Loadjob()
        {
            try
            {
                Grd_FE.Visible = false;
                Grd_FI.Visible = false;
                Grd_AE.Visible = false;
                Grd_CHA.Visible = false;
                //Grd_Doc.Visible = false;
                //DataAccess.Documents obj_da_Document = new //DataAccess.Documents();
                DataTable obj_dt = new DataTable();

                obj_dt = obj_da_Document.GetJobDtls4CODocUP(int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());
                //  obj_dt = obj_da_Document.GetJobDtls4CODocUP(1,"FE");
                if (obj_dt.Rows.Count > 0)
                {
                    this.ModalPopup.Show();
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        Grd_FE.Visible = true;
                        Grd_FE.DataSource = obj_dt;
                        Grd_FE.DataBind();
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        Grd_FI.Visible = true;
                        Grd_FI.DataSource = obj_dt;
                        Grd_FI.DataBind();
                    }
                    else if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                    {
                        Grd_AE.Visible = true;
                        Grd_AE.DataSource = obj_dt;
                        Grd_AE.DataBind();
                    }
                    else if (Session["StrTranType"].ToString() == "CH")
                    {
                        Grd_CHA.Visible = true;
                        Grd_CHA.DataSource = obj_dt;
                        Grd_CHA.DataBind();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(linkjob, typeof(LinkButton), "BLRelease", "alertify.alert('Job# Not Available');", true);
                    return;
                }
                btnclose.Text = "Cancel";
                btnclose.ToolTip = "Cancel";
                btn_close1.Attributes["class"] = "btn ico-cancel";
                LoadDoc();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Fn_FillGrid()
        {
            try
            {
                //DataAccess.Documents obj_da_Document = new //DataAccess.Documents();
                DataTable obj_dt = new DataTable();
                if(hid_doc.Value == "")
                {

                    obj_dt = obj_da_Document.SPGetDocRefNo(int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), int.Parse(txtjob.Text));
                    if (obj_dt.Rows.Count > 0)
                    {
                        hid_doc.Value = obj_dt.Rows[0]["refno"].ToString();
                        txtDoc.Text = obj_dt.Rows[0]["refno"].ToString();
                    }
                    else
                    {
                        hid_doc.Value = "0";
                    }

                }
                obj_dt = obj_da_Document.GetDocDtls4RecGurunew(int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), int.Parse(txtjob.Text),hid_doc.Value.ToString());
                if (obj_dt.Rows.Count > 0)
                {
                    //Grd_Doc.DataSource = obj_dt;
                    //Grd_Doc.DataBind();

                    grdbudget.DataSource = obj_dt;
                    grdbudget.DataBind();


                    Session["dt"] = obj_dt;


                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 621, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtjob.Text) + "&View");
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 625, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtjob.Text) + "&View");
                    }
                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 622, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtjob.Text) + "&View");
                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 623, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtjob.Text) + "&View");
                    }
                    else if (Session["StrTranType"].ToString() == "CH")
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 624, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtjob.Text) + "&View");
                    }
                    else
                    {
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 522, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtjob.Text) + "&View");
                    }
                }
                else
                {
                    //Grd_Doc.DataSource = new DataTable();
                    //Grd_Doc.DataBind();

                    grdbudget.DataSource = new DataTable();
                    grdbudget.DataBind();
                    Session["dt"] = new DataTable();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Fn_FillVoyage()
        {
            try
            {
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());

                DataTable obj_dt = new DataTable();
                if (Session["StrTranType"].ToString() == "FE")
                {
                    //DataAccess.ForwardingExports.JobInfo obj_da_FEJob = new //DataAccess.ForwardingExports.JobInfo();
                    obj_dt = obj_da_FEJob.GetFEJobInfo(int.Parse(txtjob.Text), int_bid, int_divisionid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        txtVsl.Text = obj_dt.Rows[0]["vessel"].ToString().Trim() + " V " + obj_dt.Rows[0]["voyage"].ToString();
                        txtRemarks.Text = obj_dt.Rows[0]["agent"].ToString().Trim();
                    }
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    //DataAccess.ForwardingImports.BLDetails obj_da_FIBL = new //DataAccess.ForwardingImports.BLDetails();
                    //txtVsl.Text = obj_da_FIBL.GetJobDetails(int.Parse(txtjob.Text), int_bid, int_divisionid);
                    // obj_dt = obj_da_FIBL.GetJobDetails(int.Parse(txtjob.Text), int_bid, int_divisionid);
                    //txtRemarks.Text = obj_dt.Rows[0]["agent"].ToString().Trim();
                    obj_dt = obj_da_FIBL.GetJobDetails4Upld(int.Parse(txtjob.Text), int_bid, int_divisionid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        txtVsl.Text = obj_dt.Rows[0]["vessel"].ToString().Trim();
                        txtRemarks.Text = obj_dt.Rows[0]["agent"].ToString().Trim();
                    }

                }
                else if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                {
                    //DataAccess.AirImportExports.AIEJobInfo obj_da_AEJob = new //DataAccess.AirImportExports.AIEJobInfo();
                    obj_dt = obj_da_AEJob.GetAIEDetail(int.Parse(txtjob.Text), Session["StrTranType"].ToString(), int_bid, int_divisionid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        txtVsl.Text = obj_dt.Rows[0]["flightno"].ToString().Trim() + " V " + obj_dt.Rows[0]["flightdate"].ToString();
                        txtRemarks.Text = obj_dt.Rows[0]["agentname"].ToString().Trim();
                    }
                }
                else if (Session["StrTranType"].ToString() == "CH")
                {
                    //DataAccess.CustomHousingAgent.JobInfo obj_da_CHAJob = new //DataAccess.CustomHousingAgent.JobInfo();
                    obj_dt = obj_da_CHAJob.GetCHJobInfo(int.Parse(txtjob.Text), int_bid, int_divisionid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        txtVsl.Text = obj_dt.Rows[0]["mode"].ToString().Trim();
                        txtRemarks.Text = obj_dt.Rows[0]["customer"].ToString().Trim();
                    }
                }
                else if (Session["StrTranType"].ToString() == "AC" || Session["StrTranType"].ToString() == "CO")
                {
                    //DataAccess.ForwardingImports.BLDetails obj_da_FIBL = new //DataAccess.ForwardingImports.BLDetails();
                    //txtVsl.Text = obj_da_FIBL.GetJobDetails(int.Parse(txtjob.Text), int_bid, int_divisionid);
                    // obj_dt = obj_da_FIBL.GetJobDetails(int.Parse(txtjob.Text), int_bid, int_divisionid);
                    // txtRemarks.Text = obj_dt.Rows[0]["agent"].ToString().Trim();
                    if (txtjob.Text != "")
                    {
                        obj_dt = obj_da_FIBL.GetJobDetails4Upld(int.Parse(txtjob.Text), int_bid, int_divisionid);
                        if (obj_dt.Rows.Count > 0)
                        {
                            txtVsl.Text = obj_dt.Rows[0]["vessel"].ToString().Trim();
                            txtRemarks.Text = obj_dt.Rows[0]["agent"].ToString().Trim();
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

        protected void Grd_FE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ModalPopup.Hide();
                txtDoc.Text = "";
                ddlDoc.SelectedItem.Text = "Sales Invoice";


                txtjob.Text = Grd_FE.SelectedRow.Cells[0].Text;
                txtVsl.Text = ((Label)Grd_FE.SelectedRow.Cells[1].FindControl("vessel")).Text + " V " + ((Label)Grd_FE.SelectedRow.Cells[1].FindControl("voyage")).Text;
                //txtRemarks.Text = ((Label)Grd_FE.SelectedRow.Cells[8].FindControl("agent")).Text;   // obj_dt.Rows[0]["agent"].ToString().Trim();
                Fn_FillVoyage();
                Fn_FillGrid();
                LoadDoc();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_FI_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ModalPopup.Hide();
                txtjob.Text = Grd_FI.SelectedRow.Cells[0].Text;
                // txtVsl.Text = Grd_FI.SelectedRow.Cells[1].Text + " V " + Grd_FI.SelectedRow.Cells[2].Text;
                txtVsl.Text = ((Label)Grd_FI.SelectedRow.Cells[1].FindControl("vesselname")).Text + " V " + ((Label)Grd_FI.SelectedRow.Cells[1].FindControl("voyage")).Text;
                Fn_FillVoyage();
                Fn_FillGrid();
                LoadDoc();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_AE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ModalPopup.Hide();
                txtjob.Text = Grd_AE.SelectedRow.Cells[0].Text;
                txtVsl.Text = ((Label)Grd_AE.SelectedRow.Cells[1].FindControl("airline")).Text;
                Fn_FillVoyage();
                Fn_FillGrid();

                LoadDoc();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_CHA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ModalPopup.Hide();
                txtjob.Text = Grd_CHA.SelectedRow.Cells[0].Text;
                // txtVsl.Text = Grd_CHA.SelectedRow.Cells[4].Text;
                //  txtVsl.Text = ((Label)Grd_CHA.SelectedRow.Cells[1].FindControl("jobtype")).Text;
                txtVsl.Text = ((Label)Grd_CHA.SelectedRow.Cells[1].FindControl("jobtype")).Text + " V " + ((Label)Grd_CHA.SelectedRow.Cells[2].FindControl("docno")).Text;
                Fn_FillVoyage();
                Fn_FillGrid();
                LoadDoc();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        //protected void ddlDocNum_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ddlDocNum.SelectedItem.Text == "Others")
        //        {
        //            txtDoc.Enabled = true;
        //            txtDoc.Focus();
        //        }
        //        else
        //        {
        //            txtDoc.Enabled = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}

        protected void ddlDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDoc();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void LoadDoc()
        {
            try
            {
                hid_date.Value = Str_date;
                hid_type.Value = Str_type;
                if (txtjob.Text.Trim().Length > 0 && ddlDoc.SelectedItem.Text.Length > 0)
                {
                //    ddlDocNum.Items.Clear();
                //    ddlDocNum.Items.Add("");
                //    ddlDocNum.SelectedIndex = 0;
                //DataAccess.ForwardingImports.JobInfo obj_da_FIJob = new //DataAccess.ForwardingImports.JobInfo();
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_FIJob.GetPathTypeDetailsOnly(int.Parse(txtjob.Text), Session["StrTranType"].ToString(), ddlDoc.SelectedItem.Text, int.Parse(Session["LoginBranchid"].ToString()));
                if (obj_dt.Rows.Count > 0)
                {
                    Session["Dt"] = obj_dt;
                    //ddlDocNum.Items.Add(new ListItem("ALL"));
                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        //ddlDocNum.Items.Add(obj_dt.Rows[i].ItemArray[0].ToString());

                        Str_type = Str_type + obj_dt.Rows[i].ItemArray[0].ToString() + " ";
                        if (obj_dt.Columns.Count > 4)
                        {
                            str_alltype = str_alltype + obj_dt.Rows[i].ItemArray[0].ToString() + " ";
                            Str_date = Str_date + obj_dt.Rows[i].ItemArray[2].ToString() + " ";
                            hid_str_alltype.Value = str_alltype;
                        }
                        else
                        {
                            str_alltype = str_alltype + obj_dt.Rows[i].ItemArray[0].ToString() + " ";
                            Str_date = Str_date + obj_dt.Rows[i]["PathDate"].ToString() + " ";
                            hid_str_alltype.Value = str_alltype;
                        }

                    }
                    hid_date.Value = Str_date;
                    hid_type.Value = Str_type;
                }
                //    ddlDocNum.Items.Add("Others");
                //DataAccess.Masters.MasterDocument obj_da_Document = new DataAccess.Masters.MasterDocument();
                hid_docid.Value = obj_da_Document2.GetDocTypeID(ddlDoc.SelectedItem.Text).ToString();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (upd_document.HasFile || upd_document.PostedFile != null)

            //string filePath = upd_document.PostedFile.FileName;          // getting the file path of uploaded file
            //string filename1 = Path.GetFileName(filePath);               // getting the file name of uploaded file
            //string ext = Path.GetExtension(filename1);                      // getting the file extension of uploaded file
            //string type = String.Empty;
            //DataAccess.Masters.MasterBranch obj_da_Branch = new //DataAccess.Masters.MasterBranch();
            string filePath = "";
            string filename = "";
            string[] filename1;

            string[] branchname;
            string branchnameshortname = "";

            if (!upd_document.HasFile)
            {
                // Label2.Text = "Please Select File";                          //if file uploader has no file selected
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Select Document Path');", true);
                upd_document.Focus();
            }
            if (ddlDoc.SelectedItem.Text == "")
            {
                // Label2.Text = "Please Select File";                          //if file uploader has no file selected
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Select Doc Type ');", true);
                ddlDoc.Focus();
            }
            if (txtDoc.Text == "")
            {
                // Label2.Text = "Please Select File";                          //if file uploader has no file selected
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Enter Doc # ');", true);
                ddlDoc.Focus();
            }
            else
            {
                if (upd_document.HasFile)
                {

                    try
                    {
                        if (Path.GetExtension(upd_document.PostedFile.FileName).ToLower() != ".pdf")
                        {
                            ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Upload PDF Document');", true);
                            return;
                        }
                        string[] str_Item = new string[9];
                        str_Item[0] = obj_da_Branch.GetShortName(int.Parse(Session["LoginBranchid"].ToString()));
                        str_Item[1] = ddlDoc.SelectedItem.Text;
                        str_Item[2] = ddlDoc.SelectedItem.Text;

                        filename = upd_document.PostedFile.FileName.ToString();
                        branchname = str_Item[0].Split('-');
                        branchnameshortname = branchname[1].ToString();
                        filename1 = filename.Split('.');

                        string str = filename1[0].ToString().Trim();


                        if (IsValidEmailId(str) == true)
                        {
                            string withoutspecialcharacters = RemoveSpecialChars(str);
                            filename = branchnameshortname + "-" + Session["StrTranType"].ToString() + "-" + txtjob.Text + "-" + withoutspecialcharacters + ".pdf";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Filename not accept sepical characters. Accept only A-Zor0-9or_ or-');", true);
                            return;
                        }

                        /*if (ddlDocNum.SelectedItem.Text == "Others" && hid_doc.Value.Trim().Length == 0)
                        {
                            ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Document Path CANT BE BLANK');", true);
                            return;
                        }*/


                        //  Uploading.Uploading obj_webservices = new Uploading.Uploading();


                        // Uploading.Uploading obj = new Uploading.Uploading();
                        //DataAccess.Payroll.Details obj_da_Pay = new //DataAccess.Payroll.Details();

                        //DataAccess.Masters.MasterDocument obj_da_Document = new //DataAccess.Masters.MasterDocument();
                        //DataAccess.Documents obj_da_Doc = new DataAccess.Documents();

                        DataTable obj_dt = new DataTable();

                        if (btnSave.ToolTip == "Upload")
                        {
                            //if (ddlDocNum.SelectedItem.Text != "Others")
                            //{
                            //obj_dt = obj_da_Document.GetUplodDtls(int.Parse(txtjob.Text), Session["StrTranType"].ToString(), bid, Convert.ToInt32(hid_docid.Value));
                            hid_docid.Value = obj_da_Document2.GetDocTypeID(ddlDoc.SelectedItem.Text).ToString();

                            //if (obj_dt.Rows.Count > 0)
                            //{
                            //    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Already Document Uploaded For This');", true);
                            //    return;
                            //}


                            //}

                            if (grdbudget.Rows.Count > 0)
                            {
                                for (int i = 0; i < grdbudget.Rows.Count; i++)
                                {
                                    if (grdbudget.Rows[i].Cells[4].Text == filename)
                                    {
                                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Already Document Uploaded For This');", true);
                                        return;
                                    }
                                }
                            }

                            upd_document.PostedFile.SaveAs(Server.MapPath("~/UploadFTP/" + filename));

                            //if (ddlDocNum.SelectedItem.Text == "ALL")
                            //{
                            //    str_Item[2] = hid_type.Value.ToString();
                            //    str_Item[3] = hid_date.Value.ToString();
                            //}
                            //else if (ddlDocNum.SelectedItem.Text == "Others")
                            //{
                            //    str_Item[2] = hid_doc.Value;
                            //    str_Item[3] = "";
                            //}
                            //else
                            //{
                            //    str_Item[2] = ddlDocNum.SelectedItem.Text;
                            //    obj_dt = (DataTable)Session["Dt"];
                            //    str_Item[3] = obj_dt.Rows[ddlDocNum.SelectedIndex - 2]["PathDate"].ToString();
                            //}
                            str_Item[3] = "";
                            str_Item[4] = txtjob.Text;
                            str_Item[5] = "";
                            obj_dt = obj_da_Pay.GetEmpDetails(int.Parse(Session["LoginEmpId"].ToString()));
                            if (obj_dt.Rows.Count > 0)
                            {
                                str_Item[5] = obj_dt.Rows[0]["username"].ToString();
                            }
                            //str_Item[6] = Session["StrTranType"].ToString();
                            //str_Item[7] = "";

                            str_Item[6] = Utility.fn_ConvertDate(dtnow.ToShortDateString()) + " " + dtnow.ToShortTimeString();
                            str_Item[7] = Session["StrTranType"].ToString();
                            str_Item[8] = txtRemarks.Text.Trim();
                            byte[] File_Byte = null;
                            File_Byte = File.ReadAllBytes(Server.MapPath("~/UploadFTP/" + filename));

                            int up1 = upd_document.PostedFile.ContentLength / 1024;



                            filePath = Server.MapPath("~/UploadFTP/" + filename);
                            try
                            {
                                UploadFileToFTP(filename, filePath);
                                int int_Documentid = 0;
                                uiid = Convert.ToInt32(Session["UploadDocument"]);
                                voutype = ddlDoc.SelectedItem.Text;
                                if(Session["ddltypeid"] == null)
                                {
                                    voutypeid = Convert.ToInt32(ddlDoc.SelectedValue);
                                }
                                else
                                {
                                    voutypeid = Convert.ToInt32(Session["ddltypeid"]);
                                }
                                                               
                                int_Documentid = Convert.ToInt32(obj_da_Doc.InsDocumentsnew(Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), Convert.ToInt32(txtjob.Text), Convert.ToInt32(hid_docid.Value.ToString()), txtRemarks.Text, ddlDocNum.Text, filename, Convert.ToInt32(Session["LoginEmpId"].ToString()), Str_Result, hid_date.Value.ToString(), hid_str_alltype.Value, Convert.ToString(dtnow), uiid, txtDoc.Text, voutype, voutypeid));//str_alltype

                                //if (Str_Result.Trim().Length > 0)
                                //{
                                obj_da_Doc.UpdShortNameRecGuru(int_Documentid, filename);
                                hid_doc.Value = txtDoc.Text;
                                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Document Uploaded');", true);
                            }
                            catch (Exception ex)
                            {
                                lbl_DispMsg.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                            }
                            finally
                            {
                                // System.IO.File.Delete(upd_document.PostedFile.FileName.ToString());
                                System.IO.File.Delete(filePath);
                            }



                            //Btn_save.Attributes.Add("OnClick", "confirm confirm('Do You Want to Print?')");

                            //}
                            //else
                            //{

                            //    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Error Critical -" + Str_Result + "');", true);
                            //    return;
                            //}
                            switch (Session["StrTranType"].ToString())
                            {
                                case "FE":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 516, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + hid_doc.Value);
                                    break;
                                case "FI":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 517, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + hid_doc.Value);
                                    break;
                                case "AE":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 518, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + hid_doc.Value);
                                    break;
                                case "AI":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 519, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + hid_doc.Value);
                                    break;
                                case "CH":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 520, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + hid_doc.Value);
                                    break;
                            }

                            Fn_FillGrid();

                        }

                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message.ToString();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                    }
                }
            }
            btnclose.Text = "Cancel";
            btnclose.ToolTip = "Cancel";
            btn_close1.Attributes["class"] = "btn ico-cancel";
        }

        private void UploadFileToFTP(string source, string path)
        {
            try
            {
                string Ccode = Convert.ToString(Session["Ccode"]);
                string DBName = "Demo";
                if (Ccode == "CH01")
                {
                    DBName = "SL";
                    using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                    {
                        DBCS = reader.ReadLine();
                    }
                }
                else if (Ccode == "CH02")
                {
                    DBName = "MarinAir";
                    using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                    {
                        DBCS = reader.ReadLine();
                    }
                }
                if (Ccode == "CH03")
                {
                    DBName = "OceanKare";
                    using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                    {
                        DBCS = reader.ReadLine();
                    }
                }


                ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
                dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
                username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
                password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();

                // added on 25Mar2023 
                username = "vmadmin";
                password = "VMWeb20Mar@)@#";

                String sourcefilepath = source; // e.g. "d:/test.docx"
                String ftpurl = "ftp://20.235.30.214/SL/" + sourcefilepath; // e.g. ftp://serverip/foldername/foldername
                String ftpusername = username;//"ifrtAdmin"; // e.g. username
                String ftppassword = password; //"05Jun!(&%"; // e.g. password



                string filename = Path.GetFileName(source);
                string ftpfullpath = ftpurl;
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);

                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                FileStream fs = File.OpenRead(path); //File.OpenRead(source);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();
                Stream ftpstream = ftp.GetRequestStream();
                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();

                //// get file bytes
                //byte[] fileBytes = File.ReadAllBytes(source);
                //ftp.ContentLength = fileBytes.Length;

                //Stream ftpstream = ftp.GetRequestStream();
                //ftpstream.Write(fileBytes, 0, fileBytes.Length);
                //ftpstream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        /*if (upd_document.HasFile || upd_document.PostedFile != null)
       {
            if (Path.GetExtension(upd_document.PostedFile.FileName).ToLower() != ".pdf")
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Upload PDF Document');", true);
                return;
            }
            upd_document.PostedFile.SaveAs(Server.MapPath("~/UploadDocument/" + upd_document.PostedFile.FileName.ToString()));
            if (ddlDocNum.SelectedItem.Text == "Others" && hid_doc.Value.Trim().Length == 0)
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Document Path CANT BE BLANK');", true);
                return;
            }

            //  RGServices.Uploading obj_webservices = new RGServices.Uploading();
            //DataAccess.Payroll.Details obj_da_Pay = new //DataAccess.Payroll.Details();
            //DataAccess.Masters.MasterBranch obj_da_Branch = new //DataAccess.Masters.MasterBranch();
            //DataAccess.Masters.MasterDocument obj_da_Document = new //DataAccess.Masters.MasterDocument();
            //DataAccess.Documents obj_da_Doc = new //DataAccess.Documents();

            DataTable obj_dt = new DataTable();

            if (btnSave.Text == "Save")
            {
                obj_dt = obj_da_Document.GetUplodDtls(int.Parse(txtjob.Text), Session["StrTranType"].ToString(), bid, Convert.ToInt32(hid_docid.Value));
                if (obj_dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Already Document Uploaded For This');", true);
                    return;
                }
                string[] str_Item = new string[8];
                str_Item[0] = obj_da_Branch.GetShortName(int.Parse(Session["LoginBranchid"].ToString()));
                str_Item[1] = ddlDoc.SelectedItem.Text;
                str_Item[2] = ddlDoc.SelectedItem.Text;

                if (ddlDocNum.SelectedItem.Text == "ALL")
                {
                    str_Item[2] = hid_type.Value.ToString();
                    str_Item[3] = hid_date.Value.ToString();
                }
                else if (ddlDocNum.SelectedItem.Text == "Others")
                {
                    str_Item[2] = hid_doc.Value;
                    str_Item[3] = "";
                }
                else
                {
                    str_Item[2] = ddlDocNum.SelectedItem.Text;
                    obj_dt = (DataTable)Session["Dt"];
                    str_Item[3] = obj_dt.Rows[ddlDocNum.SelectedIndex - 2]["PathDate"].ToString();
                }
                str_Item[4] = txtjob.Text;
                str_Item[5] = "";
                obj_dt = obj_da_Pay.GetEmpDetails(int.Parse(Session["LoginEmpId"].ToString()));
                if (obj_dt.Rows.Count > 0)
                {
                    str_Item[5] = obj_dt.Rows[0]["username"].ToString();
                }
                str_Item[6] = Session["StrTranType"].ToString();
                byte[] File_Byte = null;
                File_Byte = File.ReadAllBytes(Server.MapPath("~/UploadDocument/" + upd_document.PostedFile.FileName.ToString()));
                string Str_Result = "";

                //   Str_Result = obj_webservices.UploadFile("M + R", "WebService", "WebService", Fn_TypeName(), ddlDocNum .SelectedItem.Text, upd_document.PostedFile.FileName.ToString(), upd_document.PostedFile.ContentLength, str_Item, File_Byte, "Digital");

                double temp;
                if (!double.TryParse(Str_Result.Substring(0, 8), out temp))
                {

                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('File Not Uploaded  Due To :" + Str_Result.Replace("'", "") + "');", true);
                    return;
                }

                int int_Documentid = 0;
                int_Documentid = int.Parse(obj_da_Doc.InsDocuments(int.Parse(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), int.Parse(txtjob.Text), int.Parse(hid_docid.Value.ToString()), txtRemarks.Text, ddlDocNum.SelectedItem.Text, upd_document.PostedFile.FileName, int.Parse(Session["LoginEmpId"].ToString()), Str_Result, str_Item[3].ToString(), str_alltype, Convert.ToString(dtnow)));

                if (Str_Result.Trim().Length > 0)
                {
                    obj_da_Doc.UpdShortNameRecGuru(int_Documentid, Str_Result + " & " + upd_document.PostedFile.FileName);
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Document Uploaded');", true);
                    //Btn_save.Attributes.Add("OnClick", "confirm confirm('Do You Want to Print?')");

                }
                else
                {

                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Error Critical -" + Str_Result + "');", true);
                    return;
                }
                //DataAccess.LogDetails obj_da_Log = new //DataAccess.LogDetails();

                Fn_FillGrid();

            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "UploadDocument", "alertify.alert('Select Document Path');", true);
            upd_document.Focus();
        }
       
         */

        /*NOT Included becz Webservice methods not added */

        private String Fn_TypeName()
        {
            string Str_name = "";
            try
            {

                if (Session["StrTranType"].ToString() == "FE")
                {
                    Str_name = "OCEAN EXPORTS";
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    Str_name = "OCEAN IMPORTS";
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    Str_name = "AIR EXPORTS";
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    Str_name = "AIR IMPORTS";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            return Str_name;
        }

        protected void txtjob_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Fn_FillVoyage();
                Fn_FillGrid();
                LoadDoc();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            if (btnclose.ToolTip == "Cancel")
            {
                JobInput.Text = "";
                // Grd_Doc.Visible = true;
                grdbudget.Visible = true;
                Fn_Clear();
                Fn_LoadDocType();
            }
            else
            {

                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "CS")
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {

                            Response.Redirect("../Home/OECSHome.aspx");

                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {

                            Response.Redirect("../Home/OICSHome.aspx");
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {

                            Response.Redirect("../Home/AECSHome.aspx");
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {

                            Response.Redirect("../Home/AICSHome.aspx");
                        }
                    }
                    else if (Session["home"].ToString() == "OPS&DOC")
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {

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
                else
                {
                    this.Response.End();
                }
            }
        }

        private void Fn_Clear()
        {
            txtjob.Text = "";
            txtVsl.Text = "";
            txtRemarks.Text = "";
            hid_doc.Value = "";
            //ddlDoc.Items.Clear();
            //ddlDocNum.Items.Clear();
            // ddlDoc.SelectedIndex = 0; 15 mar 2022
            ddlDoc.SelectedIndex = 0;
            txtDoc.Text = "";
            ddlDocNum.Text = "";
            btnclose.Text = "Back";
            btnclose.ToolTip = "Back";
            btn_close1.Attributes["class"] = "btn ico-back";
            //Grd_Doc.DataSource = new DataTable();
            //Grd_Doc.DataBind();
            grdbudget.DataSource = new DataTable();
            grdbudget.DataBind();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                string strvew = "VIEW";
                int doid = 0;
                string js = "";
                //DataAccess.LogDetails Logobj = new //DataAccess.LogDetails();
                string strTranType = Session["StrTranType"].ToString();
                int bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int job1 = Convert.ToInt32(txtjob.Text);
                obj_dt = Dobj.GetDocDtls4RecGuru(bid, strTranType, job1);
                if (txtjob.Text == "")
                {
                    //obj_dt=Dobj.GetDocDtls4RecGuru(Convert.ToInt32(Session["LoginBranchid"].ToString()),strTranType,Convert.ToInt32(txtjob.Text));
                    obj_dt = Dobj.GetDocDtls4RecGuru(bid, strTranType, job1);
                    if (obj_dt.Rows.Count > 0)
                    {
                        //doid=obj_dt.Rows[0]["docid"].ToString();    
                        doid = Convert.ToInt32(obj_dt.Rows[0]["docid"].ToString());
                    }
                    else
                    {
                        doid = 0;
                    }
                    //doid = dtdocs.Rows(0).Item("docid").ToString()

                }
                else
                {
                    js = (txtjob.Text).ToString();
                }
                if (js == "")
                {
                    str_RptName = "Payroll\\" + "rpt4RGGuru.rpt";
                    str_sp = "Trantype=" + Session["StrTranType"].ToString() + "~strcmn=" + strvew + "~docid=" + doid + "~jobno=" + txtjob.Text;
                    //str_sp = "Trantype=" + Session["StrTranType"].ToString() + "~docid=" + str_docid + "~jobno=" + str_jobno + "~strcmn=" + str_temp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "UploadDocument", str_Script, true);
                    ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Agent Debit Note", str_Script, true);
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                    switch (Session["StrTranType"].ToString())
                    {
                        case "FE":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 516, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + hid_doc.Value + " /V");
                            break;
                        case "FI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 517, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + hid_doc.Value + " /V");
                            break;
                        case "AE":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 518, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + hid_doc.Value + " /V");
                            break;
                        case "AI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 519, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + hid_doc.Value + " /V");
                            break;
                        case "CH":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 520, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + hid_doc.Value + " /V");
                            break;
                    }

                }
                else
                {
                    str_RptName = "Payroll\\" + "\\rpt4RGGuru.rpt";
                    string str_docid = "0";
                    string str_jobno = txtjob.Text;
                    string str_temp = "VIEW";
                    string str_sp1 = "";
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    str_sp1 = "Trantype=" + Session["StrTranType"].ToString() + "~strcmn=" + str_temp + "~docid=" + str_docid + "~jobno=" + str_jobno;



                    str_sf = "{DOCDocuments.jobno}=" + str_jobno + " and{DOCDocuments.branchid}=" + Session["LoginBranchid"].ToString() + " and{DOCDocuments.trantype}= " + strTranType + "";
                    Session["str_sfs"] = "{DOCDocuments.jobno}=" + str_jobno + " and{DOCDocuments.branchid}=" + Session["LoginBranchid"].ToString() + " and{DOCDocuments.trantype}= '" + strTranType + "'";
                    Session["str_sp"] = str_sp1;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";


                    ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Agent Debit Note", str_Script, true);

                    switch (Session["StrTranType"].ToString())
                    {
                        case "FE":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 516, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + hid_doc.Value + " /V");
                            break;
                        case "FI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 517, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + hid_doc.Value + " /V");
                            break;
                        case "AE":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 518, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + hid_doc.Value + " /V");
                            break;
                        case "AI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 519, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + hid_doc.Value + " /V");
                            break;
                        case "CH":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 520, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + hid_doc.Value + " /V");
                            break;
                    }
                }

                if (hid_job.Value.ToString().Length > 0)
                {
                    Fn_Print(hid_job.Value.ToString(), "0", "view");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Fn_Print(string str_jobno, string str_docid, string str_temp)
        {
            try
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                str_RptName = "Payroll\\" + "\\rpt4RGGuruSep.rpt";
                str_sp = "Trantype=" + Session["StrTranType"].ToString() + "~docid=" + str_docid + "~jobno=" + str_jobno + "~strcmn=" + str_temp;
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "UploadDocument", str_Script, true);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_CHA_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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

                    Label lbljobtype = (Label)e.Row.FindControl("jobtype");
                    string tooltip = lbljobtype.Text;
                    e.Row.Cells[1].Attributes.Add("title", tooltip);

                    Label lbldocno = (Label)e.Row.FindControl("docno");
                    string tooltip1 = lbldocno.Text;
                    e.Row.Cells[2].Attributes.Add("title", tooltip1);

                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_CHA, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_AE_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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

                    Label lblairline = (Label)e.Row.FindControl("airline");
                    string tooltip = lblairline.Text;
                    e.Row.Cells[1].Attributes.Add("title", tooltip);

                    Label lblagentname = (Label)e.Row.FindControl("agentname");
                    string tooltip1 = lblagentname.Text;
                    e.Row.Cells[4].Attributes.Add("title", tooltip1);

                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_AE, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_FI_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_FI, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_FE_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblCustomer = (Label)e.Row.FindControl("vessel");
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

                    Label lblCustomer4 = (Label)e.Row.FindControl("sd");
                    string tooltip4 = lblCustomer4.Text;
                    e.Row.Cells[5].Attributes.Add("title", tooltip4);

                    Label lblCustomer5 = (Label)e.Row.FindControl("eta");
                    string tooltip5 = lblCustomer5.Text;
                    e.Row.Cells[6].Attributes.Add("title", tooltip5);

                    Label lblCustomer6 = (Label)e.Row.FindControl("mlo");
                    string tooltip6 = lblCustomer6.Text;
                    e.Row.Cells[7].Attributes.Add("title", tooltip6);


                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_FE, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_FE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grd_FE.PageIndex = e.NewPageIndex;
                Loadjob();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_FI_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grd_FI.PageIndex = e.NewPageIndex;
                Loadjob();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_AE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grd_AE.PageIndex = e.NewPageIndex;
                Loadjob();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_CHA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grd_CHA.PageIndex = e.NewPageIndex;
                Loadjob();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        /*  protected void Grd_Doc_RowCommand(object sender, GridViewCommandEventArgs e)
          {
              if (e.CommandName == "print")
              {
                  int doccid;
                  string str_sp = "";
                  string str_sf = "";
                  string str_RptName = "";
                  string str_Script = "";
                  Session["str_sfs"] = "";
                  Session["str_sp"] = "";
                  LinkButton img = (LinkButton)e.CommandSource;
                  GridViewRow grd = (GridViewRow)img.NamingContainer;
                  if (Grd_Doc.Rows.Count > 0)
                  {
                        doccid =Convert.ToInt32(grd.Cells[2].Text);
                        doctyp = grd.Cells[0].Text;



                        str_RptName = "Payroll\\" + "\\rpt4RGGuru4Grid.rpt";
                        Session["str_sfs"] = "{DOCDocuments.jobno}=" + txtjob.Text + " and{DOCDocuments.doctype}=" + doccid + " and{DOCDocuments.branchid}=" + Session["LoginBranchid"].ToString() + " and{DOCDocuments.trantype}= '" + Session["StrTranType"].ToString() + "'";
                        str_sp = "";
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                        ScriptManager.RegisterStartupScript(Grd_Doc, typeof(GridView), "JobInfo", str_Script, true);                    

                        Session["str_sp"] = str_sp;

                  }
              }
          }

          protected void Grd_Doc_RowDataBound(object sender, GridViewRowEventArgs e)
          {
              if (e.Row.RowType == DataControlRowType.DataRow)
              {
                  e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                  e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                  LinkButton lnkbtnresult = (LinkButton)e.Row.FindControl("Lnk_Print");
                  lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                 // e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Doc, "Select$" + e.Row.RowIndex);
                  e.Row.Attributes["style"] = "cursor:pointer";

                  for (int i = 0; i < e.Row.Cells.Count; i++)
                  {
                      if (e.Row.Cells[i].Text == "&nbsp;")
                      {
                          e.Row.Cells[i].Text = "";
                      }
                      e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                  }
              }
          }
          */
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

            if (Session["StrTranType"].ToString() == "FE")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 516, "Upload", txtjob.Text, txtjob.Text, Session["StrTranType"].ToString());
            }
            else if (Session["StrTranType"].ToString() == "FI")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 517, "Upload", txtjob.Text, txtjob.Text, Session["StrTranType"].ToString());
            }
            else if (Session["StrTranType"].ToString() == "AE")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 518, "Upload", txtjob.Text, txtjob.Text, Session["StrTranType"].ToString());
            }
            else if (Session["StrTranType"].ToString() == "AI")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 519, "Upload", txtjob.Text, txtjob.Text, Session["StrTranType"].ToString());
            }
            else if (Session["StrTranType"].ToString() == "CH")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 520, "Upload", txtjob.Text, txtjob.Text, Session["StrTranType"].ToString());
            }
            if (txtjob.Text != "")
            {
                JobInput.Text = txtjob.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void btndown_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            if (txtjob.Text != "")
            {

                //int jobno = Convert.ToInt32((txt_job.Text).ToString());

                dt = Dobj.GetDocDtls(Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), Convert.ToInt32(txtjob.Text));
                hid_poddownload.Value = dt.Rows[0].ItemArray[4].ToString();

                //LinkButton btn_Temp = (LinkButton)sender;
                //string str_Arg = btn_Temp.CommandArgument;
                //string[] str_arry = str_Arg.Split('-');
                //string str_Type = str_arry[0].ToString().Trim();
                //string str_FileId = str_arry[1].ToString().Trim();
                //if (str_FileId != "")
                //{
                if (hid_poddownload.Value != "")
                {
                    //hid_poddownload.Value = str_FileId;
                    //string[] arrfilelength = str_FileId.Split(',');

                    //if (arrfilelength.Length > 2)
                    //{
                    //  //  ftp_download();
                    //}
                    //else
                    //{
                    // //   fttnormaldwd();
                    //}
                    fttnormaldwd();

                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Warehouse", "alertify.alert('Kindly update the podproof')", true);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('PoD not yet updated for this pickslip #');", true);
                    return;
                }


            }
            else
            {
                ScriptManager.RegisterStartupScript(btndown, typeof(Button), "EDI", "alertify.alert('Please Enter the Booking #');", true);
                txtjob.Focus();
            }
        }





        protected void fttnormaldwd()
        {

            string Ccode = Convert.ToString(Session["Ccode"]);
            string DBName = "Demo";
            if (Ccode == "CH01")
            {
                DBName = "SL";
                using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                {
                    DBCS = reader.ReadLine();
                }
            }
            else if (Ccode == "CH02")
            {
                DBName = "MarinAir";
                using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                {
                    DBCS = reader.ReadLine();
                }
            }
            if (Ccode == "CH03")
            {
                DBName = "OceanKare";
                using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                {
                    DBCS = reader.ReadLine();
                }
            }


            ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
            dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
            //username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
            //password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();

            // added on 25Mar2023 
            username = "vmadmin";
            password = "VMWeb20Mar@)@#";


            string str_path = "";
            string str_paths = "";
            string str_FileId, str_filename;
            str_filename = hid_poddownload.Value.Replace("&", "");
            //str_FileId = "201711070726393477";
            DataTable dt = new DataTable();

            //dt = DriverObj.searhpodprooftodownload(str_FileId);


            //str_filename = dt.Rows[0]["podproof"].ToString();
            //// str_filename = str_filename.Substring(str_filename.LastIndexOf('.') + 1, str_filename.Length - str_filename.LastIndexOf('.') - 1);

            //string[] dwndile = new string[0];

            //dwndile = str_filename.Split(',');

            //str_filename = dwndile[0];
            //string filePath = Server.MapPath("~/W-TMS/Upload/" + fileName);




            str_path = Server.MapPath("~/W-FTP/Upload");

            string path = Server.MapPath("~/W-FTP/Upload/" + str_filename);


            string ftp = "ftp://20.235.30.214/";

            //FTP Folder name. Leave blank if you want to Download file from root folder.
            string ftpFolder = "SL/";
            //try
            //{
            //Create FTP Request.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + str_filename);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            //Enter FTP Server credentials.
            //request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
            request.Credentials = new NetworkCredential(username, password);


            request.UsePassive = true;
            request.UseBinary = true;
            request.EnableSsl = false;

            //Fetch the Response and read it into a MemoryStream object.
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using (FileStream outputStream = new FileStream(path, FileMode.OpenOrCreate))
            using (Stream ftpStream = response.GetResponseStream())
            {
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
            }


            WebClient client = new WebClient();
            Byte[] buffer1 = client.DownloadData(path);
            if (buffer1 != null)
            {
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(path));
                Response.WriteFile(path);
                Response.Flush();



            }


            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            Response.End();






        }


        protected void grdbudget_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        //if (e.Row.Cells[i].Text != "fileloc")
                        //{
                        e.Row.Cells[i].Text = "";
                        //}
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdbudget, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdbudget, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdbudget_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = grdbudget.SelectedRow.RowIndex;
                int docid, i, dcmtid;
                string Remarks, filenameloc;
                if (grdbudget.Rows.Count > 0)
                {

                    DataTable dt = new DataTable();
                    if (txtjob.Text != "")
                    {

                        docid = Convert.ToInt32(grdbudget.Rows[index].Cells[2].Text);

                        Remarks = grdbudget.Rows[index].Cells[1].Text;

                        dcmtid = Convert.ToInt32(grdbudget.Rows[index].Cells[3].Text);

                        filenameloc = grdbudget.Rows[index].Cells[4].Text;

                        hid_poddownload.Value = grdbudget.Rows[index].Cells[4].Text;




                        int jobno = Convert.ToInt32((txtjob.Text).ToString());

                        dt = Dobj.GetDocDtls(Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), Convert.ToInt32(txtjob.Text));


                        //LinkButton btn_Temp = (LinkButton)sender;
                        //string str_Arg = btn_Temp.CommandArgument;
                        //string[] str_arry = str_Arg.Split('-');
                        //string str_Type = str_arry[0].ToString().Trim();
                        //string str_FileId = str_arry[1].ToString().Trim();
                        //if (str_FileId != "")
                        //{
                            if (hid_poddownload.Value != "")
                            {
                                //hid_poddownload.Value = str_FileId;
                                //string[] arrfilelength = str_FileId.Split(',');

                                //if (arrfilelength.Length > 2)
                                //{
                                //    //ftp_download();
                                //}
                                //else
                                //{
                                //    fttnormaldwd();
                                //}
                                fttnormaldwd();

                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Warehouse", "alertify.alert('Kindly update the podproof')", true);
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('PoD not yet updated for this pickslip #');", true);
                                return;
                            }


                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "EDI", "alertify.alert('Please Enter the Booking #');", true);
                        //    txtjob.Focus();
                        //}

                        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "window.open('http://192.168.0.218/" + filenameloc + "','_top');", true);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //protected void fttnormaldwd()
        //{



        //    string str_path = "";
        //    string str_paths = "";
        //    string str_FileId, str_filename;
        //    str_filename = hid_poddownload.Value.Replace("&", "");
        //    //str_FileId = "201711070726393477";
        //    DataTable dt = new DataTable();

        //    //dt = DriverObj.searhpodprooftodownload(str_FileId);


        //    //str_filename = dt.Rows[0]["podproof"].ToString();
        //    //// str_filename = str_filename.Substring(str_filename.LastIndexOf('.') + 1, str_filename.Length - str_filename.LastIndexOf('.') - 1);

        //    //string[] dwndile = new string[0];

        //    //dwndile = str_filename.Split(',');

        //    //str_filename = dwndile[0];
        //    //string filePath = Server.MapPath("~/W-TMS/Upload/" + fileName);




        //    str_path = Server.MapPath("~/W-FTP/Upload");

        //    string path = Server.MapPath("~/W-FTP/Upload/" + str_filename);


        //    string ftp = "ftp://20.235.30.214/";

        //    //FTP Folder name. Leave blank if you want to Download file from root folder.
        //    string ftpFolder = "alpl/";
        //    //try
        //    //{
        //    //Create FTP Request.
        //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + str_filename);
        //    request.Method = WebRequestMethods.Ftp.DownloadFile;

        //    //Enter FTP Server credentials.
        //    request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
        //    request.UsePassive = true;
        //    request.UseBinary = true;
        //    request.EnableSsl = false;

        //    //Fetch the Response and read it into a MemoryStream object.
        //    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        //    using (FileStream outputStream = new FileStream(path, FileMode.OpenOrCreate))
        //    using (Stream ftpStream = response.GetResponseStream())
        //    {
        //        int bufferSize = 2048;
        //        int readCount;
        //        byte[] buffer = new byte[bufferSize];
        //        readCount = ftpStream.Read(buffer, 0, bufferSize);
        //        while (readCount > 0)
        //        {
        //            outputStream.Write(buffer, 0, readCount);
        //            readCount = ftpStream.Read(buffer, 0, bufferSize);
        //        }
        //    }


        //    WebClient client = new WebClient();
        //    Byte[] buffer1 = client.DownloadData(path);
        //    if (buffer1 != null)
        //    {
        //        Response.ContentType = ContentType;
        //        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(path));
        //        Response.WriteFile(path);
        //        Response.Flush();



        //    }


        //    FileInfo file = new FileInfo(path);
        //    if (file.Exists)
        //    {
        //        file.Delete();
        //    }
        //    Response.End();






        //}

        protected void grdbudget_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                DataTable dt_checkamend = new DataTable();
                if (Session["LoginEmpId"] != null)
                {


                    dt_checkamend = user_check.Get_downdocdeleterightsrights(Convert.ToInt32(Session["LoginEmpId"]), "");
                    if (dt_checkamend.Rows.Count > 0)
                    {


                        if (e.CommandName == "Delete")
                        {
                            ImageButton Img_delete = (ImageButton)e.CommandSource;
                            GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
                            DataTable obj_dt = new DataTable();
                            string filename = "";

                            obj_dt = (DataTable)Session["dt"];
                            //DataAccess.LogDetails obj_da_Log = new //DataAccess.LogDetails();

                            Dobj.Getdeleteftpdile(Convert.ToInt32(grdbudget.Rows[grd.RowIndex].Cells[3].Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtjob.Text));


                            ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('File has been deleted');", true);


                            switch (Session["StrTranType"].ToString())
                            {
                                case "FE":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 516, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + hid_doc.Value + Convert.ToInt32(grdbudget.Rows[grd.RowIndex].Cells[3].Text) + "/Del");
                                    break;
                                case "FI":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 517, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + hid_doc.Value + Convert.ToInt32(grdbudget.Rows[grd.RowIndex].Cells[3].Text) + "/Del");
                                    break;
                                case "AE":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 518, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + hid_doc.Value + Convert.ToInt32(grdbudget.Rows[grd.RowIndex].Cells[3].Text) + "/Del");
                                    break;
                                case "AI":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 519, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + hid_doc.Value + Convert.ToInt32(grdbudget.Rows[grd.RowIndex].Cells[3].Text) + "/Del");
                                    break;
                                case "CH":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 520, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + hid_doc.Value + Convert.ToInt32(grdbudget.Rows[grd.RowIndex].Cells[3].Text) + "/Del");
                                    break;
                            }

                            obj_dt.Rows[grd.RowIndex].Delete();
                            obj_dt.AcceptChanges();
                            filename = grdbudget.Rows[grd.RowIndex].Cells[4].Text;
                            //Fillgrid();
                            Fn_FillGrid();
                            //ftpdeleted(filename);


                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(ImageButton), "JobInfo", "alertify.alert('No rights for Delete options');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(ImageButton), "JobInfo", "alertify.alert('No rights for Delete options');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdbudget_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }




        protected void ftpdeleted(string filename)
        {

            try
            {

                string Ccode = Convert.ToString(Session["Ccode"]);
                string DBName = "Demo";
                if (Ccode == "CH01")
                {
                    DBName = "SL";
                    using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                    {
                        DBCS = reader.ReadLine();
                    }
                }
                else if (Ccode == "CH02")
                {
                    DBName = "MarinAir";
                    using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                    {
                        DBCS = reader.ReadLine();
                    }
                }
                if (Ccode == "CH03")
                {
                    DBName = "OceanKare";
                    using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                    {
                        DBCS = reader.ReadLine();
                    }
                }


                ip = DBCS.Split(new string[] { "=" }, 0)[1].Split(';')[0].Trim();
                dbname = DBCS.Split(new string[] { "=" }, 0)[2].Split(';')[0].Trim();
                //username = DBCS.Split(new string[] { "=" }, 0)[3].Split(';')[0].Trim();
                //password = DBCS.Split(new string[] { "=" }, 0)[4].Split(';')[0].Trim();
                // added on 25Mar2023 
                username = "vmadmin";
                password = "VMWeb20Mar@)@#";

                /*  String ftpurl = "ftp://20.235.30.214/alpl/"; // e.g. ftp://serverip/foldername/foldername
                  String ftpusername = "ifrtAdmin"; // e.g. username
                  String ftppassword = "05Jun!(&%"; // e.g. password



                  string filename1 = Path.GetFileName(filename);

                  string ftpfullpath = ftpurl + filename1;
                  FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                  ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);
                  ftp.Method = WebRequestMethods.Ftp.DeleteFile;

                  FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
               
                  response.Close();*/

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://20.235.30.214/SL/" + filename);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                // request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
                request.Credentials = new NetworkCredential(username, password);

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    //  return response.StatusDescription;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Img_Delete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                DataTable dt_checkamend = new DataTable();
                if (Session["LoginEmpId"] != null)
                {


                    dt_checkamend = user_check.Get_downdocdeleterightsrights(Convert.ToInt32(Session["LoginEmpId"]), "");
                    if (dt_checkamend.Rows.Count > 0)
                    {


                        //if (e.CommandName == "Delete")
                        //{
                            ImageButton Img_delete = (ImageButton)sender;
                            GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
                            DataTable obj_dt = new DataTable();
                            string filename = "";

                            obj_dt = (DataTable)Session["dt"];
                            //DataAccess.LogDetails obj_da_Log = new //DataAccess.LogDetails();

                            Dobj.Getdeleteftpdile(Convert.ToInt32(grdbudget.Rows[grd.RowIndex].Cells[3].Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtjob.Text));


                            ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "JobInfo", "alertify.alert('File has been deleted');", true);


                            switch (Session["StrTranType"].ToString())
                            {
                                case "FE":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 516, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + hid_doc.Value + Convert.ToInt32(grdbudget.Rows[grd.RowIndex].Cells[3].Text) + "/Del");
                                    break;
                                case "FI":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 517, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + hid_doc.Value + Convert.ToInt32(grdbudget.Rows[grd.RowIndex].Cells[3].Text) + "/Del");
                                    break;
                                case "AE":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 518, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + hid_doc.Value + Convert.ToInt32(grdbudget.Rows[grd.RowIndex].Cells[3].Text) + "/Del");
                                    break;
                                case "AI":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 519, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + hid_doc.Value + Convert.ToInt32(grdbudget.Rows[grd.RowIndex].Cells[3].Text) + "/Del");
                                    break;
                                case "CH":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 520, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + hid_doc.Value + Convert.ToInt32(grdbudget.Rows[grd.RowIndex].Cells[3].Text) + "/Del");
                                    break;
                            }

                            obj_dt.Rows[grd.RowIndex].Delete();
                            obj_dt.AcceptChanges();
                            filename = grdbudget.Rows[grd.RowIndex].Cells[4].Text;
                            // Fillgrid();
                            Fn_FillGrid();
                            //ftpdeleted(filename);


                        //}
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(ImageButton), "JobInfo", "alertify.alert('No rights for Delete options');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(ImageButton), "JobInfo", "alertify.alert('No rights for Delete options');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }








        //private void ftp_download()
        //{
        //    int i;

        //    using (ZipFile zip = new ZipFile())
        //    {
        //        zip.AlternateEncodingUsage = ZipOption.AsNecessary;
        //        zip.AddDirectoryByName("Files");


        //        string str_path = "";
        //        string str_paths = "";
        //        string str_FileId, str_filename;
        //        str_FileId = hid_poddownload.Value;
        //        //str_FileId = "201711070726393477";
        //        DataTable dt = new DataTable();

        //        dt = DriverObj.searhpodprooftodownload(str_FileId);


        //        str_filename = dt.Rows[0]["podproof"].ToString();
        //        // str_filename = str_filename.Substring(str_filename.LastIndexOf('.') + 1, str_filename.Length - str_filename.LastIndexOf('.') - 1);

        //        string[] dwndile = new string[0];

        //        dwndile = str_filename.Split(',');
        //        for (i = 0; i < dwndile.Length - 1; i++)
        //        {
        //            str_filename = dwndile[i];
        //            //string filePath = Server.MapPath("~/W-TMS/Upload/" + fileName);




        //            str_path = Server.MapPath("~/W-FTP/Upload");

        //            string path = Server.MapPath("~/W-FTP/Upload/" + str_filename);


        //            string ftp = "ftp://20.235.30.214/";

        //            //FTP Folder name. Leave blank if you want to Download file from root folder.
        //            string ftpFolder = "SL/";
        //            //try
        //            //{
        //            //Create FTP Request.
        //            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + str_filename);
        //            request.Method = WebRequestMethods.Ftp.DownloadFile;

        //            //Enter FTP Server credentials.
        //            request.Credentials = new NetworkCredential("ifrtAdmin", "05Jun!(&%");
        //            request.UsePassive = true;
        //            request.UseBinary = true;
        //            request.EnableSsl = false;

        //            //Fetch the Response and read it into a MemoryStream object.
        //            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        //            using (FileStream outputStream = new FileStream(path, FileMode.OpenOrCreate))
        //            using (Stream ftpStream = response.GetResponseStream())
        //            {
        //                int bufferSize = 2048;
        //                int readCount;
        //                byte[] buffer = new byte[bufferSize];
        //                readCount = ftpStream.Read(buffer, 0, bufferSize);
        //                while (readCount > 0)
        //                {
        //                    outputStream.Write(buffer, 0, readCount);
        //                    readCount = ftpStream.Read(buffer, 0, bufferSize);
        //                }
        //            }


        //            WebClient client = new WebClient();
        //            Byte[] buffer1 = client.DownloadData(path);
        //            if (buffer1 != null)
        //            {
        //                zip.AddFile(path, "files");

        //            }

        //        }
        //        Response.Clear();
        //        string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("dd-MMM-yyyy"));
        //        Response.AddHeader("Content-Disposition", "attachment; filename=" + zipName);
        //        Response.ContentType = "application/zip";

        //        zip.Save(Response.OutputStream);

        //        Response.End();
        //        //string filePath = (sender as LinkButton).CommandArgument;



        //        //HttpContext.Current.Response.ContentType = ContentType;
        //        //HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(path));
        //        //HttpContext.Current.Response.WriteFile(path);


        //        //Response.ContentType = ContentType;
        //        //Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(path));
        //        //Response.WriteFile(path);
        //        //Response.Flush();
        //        //FileInfo file = new FileInfo(path);
        //        //if (file.Exists)
        //        //{
        //        //    file.Delete();
        //        //}
        //        //Response.End();

        //        //}



        //        //}
        //        //catch (WebException ex)
        //        //{
        //        //    throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
        //        //}

        //    }
        //    return;

        //}




        public string RemoveSpecialChars(string str)
        {
            // Create  a string array and add the special characters you want to remove
            string[] chars = new string[] { " ", "-", ",", ".", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(", ")", ":", "|", "[", "]" };
            //Iterate the number of times based on the String array length.
            for (int i = 0; i < chars.Length; i++)
            {
                if (str.Contains(chars[i]))
                {
                    str = str.Replace(chars[i], "");
                }
            }
            return str;
        }

        public bool IsValidEmailId(string str)
        {
            //Regex To validate Email Address
            //            Regex regex = new Regex(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            //     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
            //               [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
            //     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
            //               [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            //     + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$");

            Regex regex = new Regex(@"^[a-zA-Z0-9 _-]+$");

            Match match = regex.Match(str);
            if (match.Success)
                return true;
            else
                return false;
        }

        protected void grdbudget_PreRender(object sender, EventArgs e)
        {
            if (grdbudget.Rows.Count > 0)
            {
                grdbudget.UseAccessibleHeader = true;
                grdbudget.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }

}