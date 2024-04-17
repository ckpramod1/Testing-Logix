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
using System.Text.RegularExpressions;

using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using logix.MIS;
namespace logix.CHA
{
    public partial class JobInfoCha : System.Web.UI.Page
    {


        string Jobtype, docno, mdono, docdate, vft, customername, shipper, consignee, notify, principal, pic, pol, pod, fd, cargo, documents, package, package1, volume, volume1, grossweight, netweight;

        string customerlog, shipperlog, consigneelog, principallog, notifylog;
        Boolean blr;
        int sgruop, cgroup, agroup, cargotype, agent, agentloc, por, vessel, jobno;
        string freight, status;

        int intcustomerid, intshipperid, intconsigneeid, intnotifyid, intprincipalid, polid, podid, fdid;
        DataTable dt = new DataTable();
        DataAccess.Masters.MasterPackages objPackages = new DataAccess.Masters.MasterPackages();

        DataAccess.CustomHousingAgent.JobInfo objJobType = new DataAccess.CustomHousingAgent.JobInfo();

        DataAccess.ForwardingImports.JobInfo da_obj_jobinfo = new DataAccess.ForwardingImports.JobInfo();


        DataAccess.Masters.MasterCustomer objMasCus = new DataAccess.Masters.MasterCustomer();

        DataAccess.Masters.MasterEmployee objMasterEmp = new DataAccess.Masters.MasterEmployee();

        DataAccess.Masters.MasterPort objPort = new DataAccess.Masters.MasterPort();

        DataAccess.LogDetails logDetails = new DataAccess.LogDetails();

        DataAccess.Accounts.Invoice objInvoice = new DataAccess.Accounts.Invoice();
        DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
        DataTable dataTable = new DataTable();

        DataTable DtTable = new DataTable();
        string str_FornName, str_Uiid, str_status;
        DataTable dtcust = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);
            if (Ccode != "")
            {

                objPackages.GetDataBase(Ccode);
                objJobType.GetDataBase(Ccode);
                da_obj_jobinfo.GetDataBase(Ccode);
                objMasCus.GetDataBase(Ccode);
                objMasterEmp.GetDataBase(Ccode);
                objPort.GetDataBase(Ccode);
                logDetails.GetDataBase(Ccode);
                objInvoice.GetDataBase(Ccode);
                obj_da_BL.GetDataBase(Ccode);
                da_obj_Customer.GetDataBase(Ccode);
                da_obj_Port.GetDataBase(Ccode);

            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            try
            {
                if (!IsPostBack)
                {

                    //ddlPackages.DataValueField = "descn";
                    //ddlPackages.DataTextField = "descn";
                    //ddlPackages.DataSource = dt;
                    //ddlPackages.DataBind();
                    txtJob.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    ddlbind();

                    txtJob.Focus();
                    JobType();

               //     btnCancel.Text = "Cancel";
                    btnSave.Visible = true;
                    btnCancel.ToolTip = "Cancel";
                    btnCancel1.Attributes["class"] = "btn ico-cancel";
                    UserRights();
                }

                hid_Date.Value = Utility.fn_ConvertDate(logDetails.GetDate().ToShortDateString());

                txtJobDate.Text = hid_Date.Value;

                txtDocDate.Text = hid_Date.Value;

                txtVolume.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txtJob.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                // txtVolume1.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
                txtGrossWeight.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
                txtNetWeight.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
                txtPackages.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
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
                    Utility.Fn_CheckUserRights(str_Uiid, btnSave, btnView, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                    //if (btn_delete == true)
                    //{
                    //    Grd_container.Columns[6].Visible = true;
                    //}
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        [WebMethod]
        public static List<string> GetCustomer(string prefix, string FType)
        {
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_da_customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.Marketing.Quotation objQuotation = new DataAccess.Marketing.Quotation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_customerobj.GetDataBase(Ccode);
            objQuotation.GetDataBase(Ccode);
            obj_dt = obj_da_customerobj.GetLikeCustomer(prefix.Trim(), FType);
            customer = Utility.Fn_DatatableToList(obj_dt, "customer", "customerid");
            return customer;

        }

        [WebMethod]

        public static List<string> GetPic(string prefix)
        {
            List<string> list_Res = new List<string>();

            DataAccess.Masters.MasterEmployee objMasterEmp = new DataAccess.Masters.MasterEmployee();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objMasterEmp.GetDataBase(Ccode);
            DataTable dt = new DataTable();

            dt = objMasterEmp.GetLikeEmployee(prefix.Trim());

            list_Res = Utility.Fn_DatatableToList(dt, "empnamecode", "employeeid");

            return list_Res;

        }

        [WebMethod]
        public static List<string> GetPol(string prefix)
        {
            List<string> list_Res = new List<string>();

            DataAccess.Masters.MasterPort objPort = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objPort.GetDataBase(Ccode);
            DataTable dt = new DataTable();

            dt = objPort.GetLikePort(prefix.Trim());

            list_Res = Utility.Fn_DatatableToList(dt, "portname", "portid");

            return list_Res;

        }


        [WebMethod]
        public static List<string> GetPod(string prefix)
        {
            List<string> list_Res = new List<string>();

            DataAccess.Masters.MasterPort objPort = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objPort.GetDataBase(Ccode);
            DataTable dt = new DataTable();

            dt = objPort.GetLikePort(prefix.Trim());

            list_Res = Utility.Fn_DatatableToList(dt, "portname", "portid");

            return list_Res;

        }

        [WebMethod]
        public static List<string> GetFd(string prefix)
        {
            List<string> list_Res = new List<string>();

            DataAccess.Masters.MasterPort objPort = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objPort.GetDataBase(Ccode);
            DataTable dt = new DataTable();

            dt = objPort.GetLikePort(prefix.Trim());

            list_Res = Utility.Fn_DatatableToList(dt, "portname", "portid");

            return list_Res;

        }
        public void ddlbind()
        {
            ddlPackages.Items.Clear();
            ddlPackages.Items.Add("");
            dt = objPackages.GetPackagenames();
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                ddlPackages.Items.Add(dt.Rows[i]["descn"].ToString());

            }
        }

        public void JobType()
        {
            try
            {
                ddlJobType.Items.Add("");
                ddlJobType.Items.Add("Air Import");
                ddlJobType.Items.Add("Air Export");
                ddlJobType.Items.Add("Road Import");
                ddlJobType.Items.Add("Road Export");
                ddlJobType.Items.Add("Sea Import");
                ddlJobType.Items.Add("Sea Export");
                //ddlJobType.Items.Add("By Road");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void assign()
        {
            try
            {

                Jobtype = objJobType.GetJobtype(ddlJobType.Text);
                docno = txtDoc.Text.ToUpper();
                mdono = txtMDoc.Text.ToUpper();
                docdate = txtDocDate.Text;
                vft = txtVesselFlightTruck.Text.ToUpper();
                customername = txtCustomer.Text.ToUpper();
                shipper = txtShiper.Text.ToUpper();
                consignee = txtConsignee.Text.ToUpper();
                notify = txtNotifyParty.Text.ToUpper();
                principal = txtPrincipal.Text.ToUpper();
                pic = txtPic.Text.ToUpper();
                pol = txtPol.Text.ToUpper();
                pod = txtPod.Text.ToUpper();
                fd = txtFd.Text.ToUpper();
                cargo = txtCargo.Text.ToUpper();
                documents = txtDocuments.Text.ToUpper();
                package = txtPackages.Text.ToUpper();
                package1 = ddlPackages.Text;
                volume = txtVolume.Text;
                volume1 = txtVolume1.Text;
                grossweight = txtGrossWeight.Text;
                netweight = txtNetWeight.Text;

                if (CHk_DropAIR.Checked == false)
                {
                    str_status = "O";
                }
                else if (CHk_DropAIR.Checked == true)
                {
                    str_status = "P";
                }
                else
                {
                    str_status = "";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }


        public void Load1()
        {


            //for (int i = 0; i <= grdJob.Rows.Count - 1; i++)
            //{
            //    grdJob.DataSource = Utility.Fn_GetEmptyDataTable();

            //    grdJob.DataBind();
            //}
            try
            {
                dt = objJobType.GetAllCHJobInfo(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

                if (dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('Job Not Available');", true);

                    return;
                }

                grdJob.Visible = true;
                DataTable dtemp = new DataTable();
                dtemp.Columns.Add("Job#");
                dtemp.Columns.Add("JobType");
                dtemp.Columns.Add("Doc#");
                dtemp.Columns.Add("DocDate");
                dtemp.Columns.Add("Mode");
                //DataRow dr = dtemp.NewRow();
                //dr = dtemp.NewRow();

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dtemp.Rows.Add();
                    dtemp.Rows[i][0] = dt.Rows[i][0].ToString();
                    dtemp.Rows[i][2] = dt.Rows[i][2].ToString();
                    dtemp.Rows[i][3] = dt.Rows[i][3].ToString();
                    dtemp.Rows[i][4] = dt.Rows[i][4].ToString();

                    if (dt.Rows[i][1].ToString() == "SE")
                    {
                        dtemp.Rows[i][1] = "Sea Exports";
                    }

                    else if (dt.Rows[i][1].ToString() == "SI")
                    {
                        dtemp.Rows[i][1] = "Sea Imports";
                    }

                    else if (dt.Rows[i][1].ToString() == "AE")
                    {
                        dtemp.Rows[i][1] = "Air Exports";
                    }
                    else if (dt.Rows[i][1].ToString() == "AI")
                    {
                        dtemp.Rows[i][1] = "Air Imports";
                    }

                    else if (dt.Rows[i][1].ToString() == "RE")
                    {
                        dtemp.Rows[i][1] = "Road Exports";
                    }
                    else if (dt.Rows[i][1].ToString() == "RI")
                    {
                        dtemp.Rows[i][1] = "Road Imports";
                    }
                    else
                    {
                        dtemp.Rows[i][1] = "By Road";
                    }

                }
                grdJob.DataSource = dtemp;

                grdJob.DataBind();
                grdJob.Visible = true;

                popupBuying.Show();

             //   btnCancel.Text = "Cancel";

                btnCancel.ToolTip = "Cancel";
                btnCancel1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }





        public void Loadreuse()
        {

            try
            {
                dt = objJobType.GetAllCHJobInfo(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

                if (dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('Job Not Available');", true);

                    return;
                }

                Grd_reuse.Visible = true;
                DataTable dtemp = new DataTable();
                dtemp.Columns.Add("Job#");
                dtemp.Columns.Add("JobType");
                dtemp.Columns.Add("Doc#");
                dtemp.Columns.Add("DocDate");
                dtemp.Columns.Add("Mode");
                //DataRow dr = dtemp.NewRow();
                //dr = dtemp.NewRow();

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dtemp.Rows.Add();
                    dtemp.Rows[i][0] = dt.Rows[i][0].ToString();
                    dtemp.Rows[i][2] = dt.Rows[i][2].ToString();
                    dtemp.Rows[i][3] = dt.Rows[i][3].ToString();
                    dtemp.Rows[i][4] = dt.Rows[i][4].ToString();

                    if (dt.Rows[i][1].ToString() == "SE")
                    {
                        dtemp.Rows[i][1] = "Sea Exports";
                    }

                    else if (dt.Rows[i][1].ToString() == "SI")
                    {
                        dtemp.Rows[i][1] = "Sea Imports";
                    }

                    else if (dt.Rows[i][1].ToString() == "AE")
                    {
                        dtemp.Rows[i][1] = "Air Exports";
                    }
                    else if (dt.Rows[i][1].ToString() == "AI")
                    {
                        dtemp.Rows[i][1] = "Air Imports";
                    }

                    else if (dt.Rows[i][1].ToString() == "RE")
                    {
                        dtemp.Rows[i][1] = "Road Exports";
                    }
                    else if (dt.Rows[i][1].ToString() == "RI")
                    {
                        dtemp.Rows[i][1] = "Road Imports";
                    }
                    else
                    {
                        dtemp.Rows[i][1] = "By Road";
                    }

                }
                Grd_reuse.DataSource = dtemp;

                Grd_reuse.DataBind();
                Grd_reuse.Visible = true;
                grdJob.Visible = false;

                popupBuying.Show();

            //    btnCancel.Text = "Cancel";

                btnCancel.ToolTip = "Cancel";
                btnCancel1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void lnkJob_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            grdJob.Visible = true;
            Load1();
            //txtJob_TextChanged(sender, e);
           // grdJob_SelectedIndexChanged(sender, e);
        }

        protected void grdJob_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdJob.PageIndex = e.NewPageIndex;
                Load1();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            //btnCancel.Text = "Cancel";

            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtJob_TextChanged(object sender, EventArgs e)
        {
            try
            {


              /*  if (txtJob.Text == "")
                {
                  //  btnSave.Text = "Save";

                           //btnSave.ToolTip = "Save";
                           //btnSave1.Attributes["class"] = "btn ico-save";
                           
                    
                  
                }
                else
                {*/
                    //if (!System.Text.RegularExpressions.Regex.IsMatch("^[0-9]", textbox.Text))
                    //if (!Regex.IsMatch(txtJob.Text, @"(^([0-9]*|\d*\d{1}?\d*)$)"))
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('Enter Number Only');", true);
                    //    return;
                    //}

                    //else
                    //{
                        if (txtJob.Text != "")
                        {
                            dataTable = objJobType.GetCHJobInfo(Convert.ToInt32(txtJob.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('No Record Found');", true);
                            btnSave.ToolTip = "Save";
                            btnSave1.Attributes["class"] = "btn ico-save";
                            txtJob.Text = "";
                            txtJob.Focus();
                            txtClear();
                            return;
                        }
                        if (dataTable.Rows.Count != 0)
                        {
                            Jobtype = dataTable.Rows[0][1].ToString();

                            ddlJobType.SelectedValue = objJobType.SetJobtype(Jobtype);

                            txtDoc.Text = dataTable.Rows[0][2].ToString();

                            docdate = dataTable.Rows[0][3].ToString();

                            txtDocDate.Text = Utility.fn_ConvertDate(dataTable.Rows[0][3].ToString());

                            txtMDoc.Text = dataTable.Rows[0][4].ToString();

                            txtVesselFlightTruck.Text = dataTable.Rows[0][5].ToString();

                            txtCustomer.Text = dataTable.Rows[0][6].ToString();

                            txtShiper.Text = dataTable.Rows[0][7].ToString();


                            txtConsignee.Text = dataTable.Rows[0][8].ToString();

                            txtNotifyParty.Text = dataTable.Rows[0][9].ToString();

                            txtPrincipal.Text = dataTable.Rows[0][10].ToString();

                            txtPic.Text = dataTable.Rows[0][11].ToString();

                            txtCargo.Text = dataTable.Rows[0][12].ToString();

                            txtPackages.Text = dataTable.Rows[0][13].ToString();

                            ddlPackages.Text = dataTable.Rows[0][14].ToString();

                            txtGrossWeight.Text = dataTable.Rows[0][15].ToString();

                            txtNetWeight.Text = dataTable.Rows[0][16].ToString();

                            txtVolume.Text = dataTable.Rows[0][17].ToString();

                            txtVolume1.Text = dataTable.Rows[0][18].ToString();

                            txtDocuments.Text = dataTable.Rows[0][19].ToString();
                            txtPol.Text = dataTable.Rows[0][20].ToString();

                            txtPod.Text = dataTable.Rows[0][21].ToString();

                            txtFd.Text = dataTable.Rows[0][22].ToString();

                            customerlog = objMasCus.GetCustlocation(Convert.ToInt32(dataTable.Rows[0][23].ToString()));
                            shipperlog = objMasCus.GetCustlocation(Convert.ToInt32(dataTable.Rows[0][24].ToString()));
                            consigneelog = objMasCus.GetCustlocation(Convert.ToInt32(dataTable.Rows[0][25].ToString()));

                            notifylog = objMasCus.GetCustlocation(Convert.ToInt32(dataTable.Rows[0][26].ToString()));

                            principallog = objMasCus.GetCustlocation(Convert.ToInt32(dataTable.Rows[0][27].ToString()));

                            txtJobDate.Text = Utility.fn_ConvertDate(dataTable.Rows[0]["jobdate"].ToString());

                            hid_customer.Value = dataTable.Rows[0][23].ToString();

                            hid_shipper.Value = dataTable.Rows[0][24].ToString();

                            hid_consignee.Value = dataTable.Rows[0][25].ToString();

                            hid_Notify.Value = dataTable.Rows[0][26].ToString();

                            hid_Principal.Value = dataTable.Rows[0][27].ToString();

                            hid_pol.Value = dataTable.Rows[0]["polid"].ToString();

                            hid_pod.Value = dataTable.Rows[0]["podid"].ToString();

                            hid_Fd.Value = dataTable.Rows[0]["fdid"].ToString();

                            if (dataTable.Rows[0]["jobprofit"].ToString() == "P")
                            {
                                CHk_DropAIR.Checked = true;
                            }
                            else
                            {
                                CHk_DropAIR.Checked = false;
                            }




                           // btnSave.Text = "Update";

                          //  btnCancel.Text = "Cancel";

                            btnSave.ToolTip = "Update";
                            btnSave1.Attributes["class"] = "btn btn-update1";

                            btnCancel.ToolTip = "Cancel";
                            btnCancel1.Attributes["class"] = "btn ico-cancel";

                            for (int s = 0; s <= 6; s++)
                            {
                                dt = objInvoice.CheckIPDCWMBL(txtDoc.Text, "CH", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["Vouyear"]), s);
                              //  dt = objInvoice.CheckIPDCWBL(txtDoc.Text, "CH", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["Vouyear"]), s,);
                              //  dt = objInvoice.CheckIPDCWBL(txtDoc.Text, "CH", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["Vouyear"].ToString()), s, "CBM");
                                
                                if (dt.Rows.Count > 0)
                                {
                                    txtDoc.Enabled = false;

                                    txtGrossWeight.Enabled = false;

                                    txtVolume.Enabled = false;

                                    break;
                                }

                                else
                                {
                                    txtDoc.Enabled = true;

                                    txtGrossWeight.Enabled = true;

                                    txtVolume.Enabled = true;
                                }
                            }

                            for (int s = 0; s <= 6; s++)
                            {
                                dt = objInvoice.CheckIPDCWMBL(txtDoc.Text, "CH", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["Vouyear"]), s);
                              //  dt = objInvoice.CheckIPDCWBL(txtDoc.Text, "CH", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["Vouyear"]), s,);
                               // dt = objInvoice.CheckIPDCWBL(txtDoc.Text, "CH", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["Vouyear"].ToString()), s, "MT");

                                if (dt.Rows.Count > 0)
                                {
                                    txtDoc.Enabled = false;

                                    txtGrossWeight.Enabled = false;

                                    txtVolume.Enabled = false;

                                    break;
                                }

                                else
                                {
                                    txtDoc.Enabled = true;

                                    txtGrossWeight.Enabled = true;

                                    txtVolume.Enabled = true;
                                }
                            }

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('No Record Found');", true);
                            btnSave.ToolTip = "Save";
                            btnSave1.Attributes["class"] = "btn ico-save";
                            txtJob.Text = "";
                            txtJob.Focus();
                            txtClear();
                            return;
                        }
                    //}
                //}
                txtJob.Focus();
                btnCancel.Enabled = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txtJob.Text = "";
                txtJob.Focus();
            }
            txtJob.Focus();
           // btnCancel.Text = "Cancel";

            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

               
                sgruop = 0;
                cgroup = 0;
                agroup = 0;
                cargotype = 0;
                agent = 0;
                agentloc = 0;
                freight = "N";
                status = "N";
                por = 0;
                vessel = 0;
                txtCustomer_TextChanged(sender, e);
                txtShiper_TextChanged(sender, e);
                txtConsignee_TextChanged(sender, e);
                txtNotifyParty_TextChanged(sender, e);
                txtPrincipal_TextChanged(sender, e);
                txtPic_TextChanged(sender, e);
                txtPol_TextChanged(sender, e);
                txtPod_TextChanged(sender, e);
                txtFd_TextChanged(sender, e);
                CheckData();
                if (blr == true)
                {
                    return;
                }
                //if (ddl_DropCHA.SelectedIndex == 0)
                //{
                //    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "DataFound", "alertify.alert('Please Select JobProfitShare')", true);
                //    return;
                //}





                txtMDoc.Text = txtMDoc.Text.Trim();
                if (txtMDoc.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "JobInfo", "alertify.alert('Enter the correct MDoc # ');", true);
                    txtMDoc.Focus();
                    return;
                }

                txtDoc.Text = txtDoc.Text.Trim();
                if (txtDoc.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "JobInfo", "alertify.alert('Enter the correct Doc # ');", true);
                    txtDoc.Focus();
                    return;
                }

                if (txtDoc.Text.Trim().ToUpper() == txtMDoc.Text.Trim().ToUpper())
                {

                    ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "JobInfo", "alertify.alert('DOC # and MDoc # is Same,kindly change MDoc #');", true);
                    txtMDoc.Focus();
                    return;

                }

                if (txtJob.Text != "")
                {
                    if (objInvoice.CheckClosedJobs("CH", Convert.ToInt32(txtJob.Text), Convert.ToInt32(Session["LoginBranchid"])) == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('Job has Closed Already.You Can not Update the Job Details');", true);
                        return;
                    }
                }

                if (hid_customer.Value != "" || hid_customer.Value!="0")
                {
                    dtcust = obj_da_BL.GetCreditApprovalFromCustomer(Convert.ToInt32(hid_customer.Value));
                }
                if (dtcust.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                    btnSave.Visible = false;
                    return;

                }
                if (btnSave.ToolTip == "Save")
                {
                    assign();
                   

                    int doc=0;

                    doc = objJobType.GetJobNo(txtDoc.Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

                    if (doc != 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('Document # Already Exists');", true);
                        txtDoc.Text = "";
                        txtDoc.Focus();
                        return;
                    }
                    if (Jobtype == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('JOB TYPE CANNOT BE BLANK');", true);
                        ddlJobType.Focus();
                       
                        return;
                    }


                    jobno = objJobType.InsJobInfo(Jobtype, docno.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDate(txtDocDate.Text)), mdono.ToUpper(), vft.ToUpper(),
                    Convert.ToInt32(hid_customer.Value), Convert.ToInt32(hid_shipper.Value), Convert.ToInt32(hid_consignee.Value), Convert.ToInt32(hid_Notify.Value),
                    Convert.ToInt32(hid_Principal.Value), pic, cargo, Convert.ToInt32(package), package1, Convert.ToDouble(grossweight), Convert.ToDouble(netweight),
                    Convert.ToInt32(volume), volume1, Convert.ToInt32(hid_pol.Value), Convert.ToInt32(hid_pod.Value), Convert.ToInt32(hid_Fd.Value), documents,
                    Convert.ToDateTime(Utility.fn_ConvertDate(txtJobDate.Text)), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]),
                    Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                    txtJob.Text = jobno.ToString();
                    jobno = objJobType.GetJobNo(docno, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                    da_obj_jobinfo.updjobinfoprofit("CH", jobno, Convert.ToInt32(Session["LoginBranchid"]), str_status, 0);
                    logDetails.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 9, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), jobno + "/S");
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('Details Saved');", true);
                   // btnSave.Text = "Update";
                    btnSave.ToolTip = "Update";
                    btnSave1.Attributes["class"] = "btn btn-update1";

                }

                else
                {
                    assign();

                    jobno = Convert.ToInt32(txtJob.Text);

                    objJobType.UpdJobInfo(jobno, Jobtype, docno, Convert.ToDateTime(Utility.fn_ConvertDate(txtDocDate.Text)), mdono, vft, Convert.ToInt32(hid_customer.Value), Convert.ToInt32(hid_shipper.Value), Convert.ToInt32(hid_consignee.Value), Convert.ToInt32(hid_Notify.Value), Convert.ToInt32(hid_Principal.Value), pic, cargo, Convert.ToInt32(package), package1, Convert.ToDouble(grossweight), Convert.ToDouble(netweight), Convert.ToInt32(volume), volume1, Convert.ToInt32(hid_pol.Value), Convert.ToInt32(hid_pod.Value), Convert.ToInt32(hid_Fd.Value), documents, Convert.ToDateTime(Utility.fn_ConvertDate(txtJobDate.Text)), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                    da_obj_jobinfo.updjobinfoprofit("CH", jobno, Convert.ToInt32(Session["LoginBranchid"]), str_status, 0);
                    logDetails.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 9, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), jobno + "/U");
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('Details Updated');", true);

                    txtClear();
                 //   btnSave.Text = "Save";
                    btnSave.ToolTip = "Save";
                    btnSave1.Attributes["class"] = "btn ico-save";
                }



                txtJob.Focus();


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void CheckData()
        {
            if (txtDoc.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('DOCUMENT NUMBER CANNOT BE BLANK');", true);
                blr = true;
                txtJob.Focus();
                return;
            }

            if (txtMDoc.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('MASTER DOCUMENT NUMBER CANNOT BE BLANK');", true);
                txtMDoc.Focus();
                blr = true;
                return;
            }

            if (txtVesselFlightTruck.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('MODE CANNOT BE BLANK');", true);
                txtVesselFlightTruck.Focus();
                blr = true;
                return;
            }



            grdJob.Focus();


            if (txtCargo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('CARGO CANNOT BE BLANK');", true);
                txtCargo.Focus();
                blr = true;
                return;
            }

            if (txtDocuments.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('DOCUMENTS CANNOT BE BLANK');", true);
                txtDocuments.Focus();
                blr = true;
                return;
            }

            if (txtPackages.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('NUMBER OF PACKAGES CANNOT BE BLANK');", true);
                txtPackages.Focus();
                blr = true;
                return;
            }

            if (ddlPackages.Text == "" || ddlPackages.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('PACKAGES TYPE CANNOT BE BLANK');", true);
                ddlPackages.Focus();
                blr = true;
                return;
            }


            else
            {
                hd_pack.Value = objPackages.GetNPackageid(ddlPackages.Text).ToString();

                if (hd_pack.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('INVALID PACKAGE TYPE');", true);
                    ddlPackages.Focus();
                    blr = true;
                    return;
                }
            }

            if (txtVolume.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('VOLUME QTY CANNOT BE BLANK');", true);
                txtVolume.Focus();
                blr = true;
                return;
            }

            if (txtVolume1.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('VOLUME CANNOT BE BLANK');", true);
                txtVolume1.Focus();
                blr = true;
                return;
            }

            if (txtGrossWeight.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('GROSS WEIGHT CANNOT BE BLANK');", true);
                blr = true;
                txtGrossWeight.Focus();
                return;
            }
            else
            {
                if (txtGrossWeight.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('GROSS WEIGHT must greater than Zero');", true);
                    blr = true;
                    txtGrossWeight.Focus();
                    return;
                }
            }

            if (txtNetWeight.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('NET WEIGHT CANNOT BE BLANK');", true);
                txtNetWeight.Focus();
                blr = true;
                return;
            }


            if (ddlJobType.Text == "" || ddlJobType.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfoCha", "alertify.alert('JOB TYPE CANNOT BE BLANK');", true);
                ddlJobType.Focus();
                blr = true;
                return;
            }
          //  btnCancel.Text = "Cancel";
            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }


        public void txtClear()
        {
            txtJob.Text = "";
            ddlJobType.SelectedIndex = 0;
            txtDoc.Text = "";
            txtJobDate.Text = hid_Date.Value;

            txtDocDate.Text = hid_Date.Value;
            txtMDoc.Text = "";
            txtVesselFlightTruck.Text = "";
            txtCustomer.Text = "";
            txtShiper.Text = "";
            txtConsignee.Text = "";
            txtNotifyParty.Text = "";
            txtPrincipal.Text = "";
            txtPic.Text = "";
            txtPol.Text = "";
            txtPod.Text = "";
            txtFd.Text = "";
            txtCargo.Text = "";
            txtDocuments.Text = "";
            txtPackages.Text = "";
            CHk_DropAIR.Checked = false;
            txtVolume.Text = "";
            txtVolume1.Text = "";
            txtGrossWeight.Text = "";

            txtNetWeight.Text = "";
            txtDoc.Enabled = true;
            txtGrossWeight.Enabled = true;
            txtVolume.Enabled = true;
            lnkJob.Focus();

        }


        protected void grdJob_RowDataBound(object sender, GridViewRowEventArgs e)
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

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdJob, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdJob_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                popupBuying.Hide();
                int index = Convert.ToInt32(grdJob.SelectedRow.RowIndex);

                txtJob.Text = grdJob.Rows[index].Cells[0].Text;

                dataTable = objJobType.GetCHJobInfo(Convert.ToInt32((txtJob.Text)), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

                if (dataTable.Rows.Count != 0)
                {
                    Jobtype = dataTable.Rows[0][1].ToString();

                    ddlJobType.SelectedValue = objJobType.SetJobtype(Jobtype);

                    txtDoc.Text = dataTable.Rows[0][2].ToString();

                    docdate = dataTable.Rows[0][3].ToString();

                    txtDocDate.Text = Utility.fn_ConvertDate(dataTable.Rows[0][3].ToString());

                    txtMDoc.Text = dataTable.Rows[0][4].ToString();

                    txtVesselFlightTruck.Text = dataTable.Rows[0][5].ToString();

                    txtCustomer.Text = dataTable.Rows[0][6].ToString();

                    txtShiper.Text = dataTable.Rows[0][7].ToString();


                    txtConsignee.Text = dataTable.Rows[0][8].ToString();

                    txtNotifyParty.Text = dataTable.Rows[0][9].ToString();

                    txtPrincipal.Text = dataTable.Rows[0][10].ToString();

                    txtPic.Text = dataTable.Rows[0][11].ToString();

                    txtCargo.Text = dataTable.Rows[0][12].ToString();

                    txtPackages.Text = dataTable.Rows[0][13].ToString();

                    ddlPackages.Text = dataTable.Rows[0][14].ToString();

                    txtGrossWeight.Text = dataTable.Rows[0][15].ToString();

                    txtNetWeight.Text = dataTable.Rows[0][16].ToString();

                    txtVolume.Text = dataTable.Rows[0][17].ToString();

                    txtVolume1.Text = dataTable.Rows[0][18].ToString();

                    txtDocuments.Text = dataTable.Rows[0][19].ToString();
                    txtPol.Text = dataTable.Rows[0][20].ToString();

                    txtPod.Text = dataTable.Rows[0][21].ToString();

                    txtFd.Text = dataTable.Rows[0][22].ToString();

                    customerlog = objMasCus.GetCustlocation(Convert.ToInt32(dataTable.Rows[0][23].ToString()));
                    shipperlog = objMasCus.GetCustlocation(Convert.ToInt32(dataTable.Rows[0][24].ToString()));
                    consigneelog = objMasCus.GetCustlocation(Convert.ToInt32(dataTable.Rows[0][25].ToString()));

                    notifylog = objMasCus.GetCustlocation(Convert.ToInt32(dataTable.Rows[0][26].ToString()));

                    principallog = objMasCus.GetCustlocation(Convert.ToInt32(dataTable.Rows[0][27].ToString()));

                    txtJobDate.Text = Utility.fn_ConvertDate(dataTable.Rows[0]["jobdate"].ToString());

                    hid_customer.Value = dataTable.Rows[0][23].ToString();

                    hid_shipper.Value = dataTable.Rows[0][24].ToString();

                    hid_consignee.Value = dataTable.Rows[0][25].ToString();

                    hid_Notify.Value = dataTable.Rows[0][26].ToString();

                    hid_Principal.Value = dataTable.Rows[0][27].ToString();

                    hid_pol.Value = dataTable.Rows[0]["polid"].ToString();

                    hid_pod.Value = dataTable.Rows[0]["podid"].ToString();

                    hid_Fd.Value = dataTable.Rows[0]["fdid"].ToString();

                    if (dataTable.Rows[0]["jobprofit"].ToString() == "P")
                    {
                        CHk_DropAIR.Checked = true;
                    }
                    else
                    {
                        CHk_DropAIR.Checked = false;
                    }




                   // btnSave.Text = "Update";

                   // btnCancel.Text = "Cancel";

                    btnSave.ToolTip = "Update";
                    btnSave1.Attributes["class"] = "btn btn-update1";

                    btnCancel.ToolTip = "Cancel";
                    btnCancel1.Attributes["class"] = "btn ico-cancel";

                    for (int s = 0; s <= 6; s++)
                    {
                        dt = objInvoice.CheckIPDCWMBL(txtDoc.Text, "CH", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["Vouyear"]), s);

                        if (dt.Rows.Count > 0)
                        {
                            txtDoc.Enabled = false;

                            txtGrossWeight.Enabled = false;

                            txtVolume.Enabled = false;
                            break;
                        }

                        else
                        {
                            txtDoc.Enabled = true;

                            txtGrossWeight.Enabled = true;

                            txtVolume.Enabled = true;
                        }
                    }

                }
                else
                {
                    txtClear();

                    txtDoc.Enabled = true;

                    txtGrossWeight.Enabled = true;

                    txtVolume.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
         //   btnCancel.Text = "Cancel";

            

            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.ToolTip == "Cancel")
            {
                txtClear();
                btnCancel.Enabled = true;
               // btnSave.Text = "Save";
               // btnCancel.Text = "Back";

                btnSave.ToolTip = "Save";
                btnSave1.Attributes["class"] = "btn ico-save";

                btnCancel.ToolTip = "Back";
                btnCancel1.Attributes["class"] = "btn ico-back";
                txtJob.Focus();
                btnSave.Visible = true;
            }
            else
            {
                this.Response.End();
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                int bid = Convert.ToInt32(Session["LoginBranchid"]);
                int empid = Convert.ToInt32(Session["LoginEmpId"]);
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                str_RptName = "CHJobInfo.rpt";
                if (txtJob.Text == "")
                {
                    logDetails.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 9, 3, int.Parse(Session["LoginBranchid"].ToString()), " CH-JobRegView");
                }
                else
                {
                    str_sf = "{CHJobInfo.jobno}=" + txtJob.Text;
                    logDetails.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 9, 3, int.Parse(Session["LoginBranchid"].ToString()), " CH-JobView");
                }
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btnView, typeof(Button), "JobInfo", str_Script, true);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
                //DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                //int port = da_obj_Customer.GetCustomerid(txtCustomer.Text.ToUpper());

                obj_dt = da_obj_Customer.GetexactCustomer(txtCustomer.Text.ToUpper(), "C");
                if (obj_dt.Rows.Count > 0 && hid_customer.Value != "0")
                {
                    txtShiper.Focus();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Customer Name');", true);
                    txtCustomer.Focus();
                    txtCustomer.Text = "";
                    blr = true;
                    return;
                }

                if (hid_customer.Value != "" || hid_customer.Value != "0")
                {
                    dtcust = obj_da_BL.GetCreditApprovalFromCustomer(Convert.ToInt32(hid_customer.Value));
                }
                if (dtcust.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                    btnSave.Visible = false;
                    return;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

           // btnCancel.Text = "Cancel";
            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtShiper_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
              //  DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                //  int shipperid = da_obj_Customer.GetCustomerid(txtShiper.Text.ToUpper());
                // if (shipperid != 0)
                obj_dt = da_obj_Customer.GetexactCustomer(txtShiper.Text.ToUpper(), "C");
                if (obj_dt.Rows.Count > 0 && hid_shipper.Value != "0")
                {
                    txtConsignee.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Shiper');", true);
                    txtShiper.Focus();
                    txtShiper.Text = "";
                    blr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

           // btnCancel.Text = "Cancel";

            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtConsignee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
               // DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                //int Consigneeid = da_obj_Customer.GetCustomerid(txtConsignee.Text.ToUpper());
                //if (Consigneeid != 0)
                obj_dt = da_obj_Customer.GetexactCustomer(txtConsignee.Text.ToUpper(), "C");
                if (obj_dt.Rows.Count > 0 && hid_consignee.Value != "0")
                {
                    txtNotifyParty.Focus();
                    //hid_consignee.Value = Consigneeid.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Consignee');", true);
                    txtConsignee.Focus();
                    txtConsignee.Text = "";
                    blr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

          //  btnCancel.Text = "Cancel";

            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtNotifyParty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
               // DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                // int NotifyPartyid = da_obj_Customer.GetCustomerid(txtNotifyParty.Text.ToUpper());
                //if (NotifyPartyid != 0)
                obj_dt = da_obj_Customer.GetexactCustomer(txtNotifyParty.Text.ToUpper(), "C");
                if (obj_dt.Rows.Count > 0 && hid_Notify.Value != "0")
                {
                    txtPrincipal.Focus();
                    //hid_consignee.Value = NotifyPartyid.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid NotifyParty');", true);
                    txtNotifyParty.Focus();
                    txtNotifyParty.Text = "";
                    blr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

          //  btnCancel.Text = "Cancel";
            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtPrincipal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
               // DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                //int Principalid = da_obj_Customer.GetCustomerid(txtPrincipal.Text.ToUpper());
                //if (Principalid != 0)
                obj_dt = da_obj_Customer.GetexactCustomer(txtPrincipal.Text.ToUpper(), "P");
                if (obj_dt.Rows.Count > 0 && hid_Principal.Value != "0")
                {
                    txtPic.Focus();
                    //hid_Principal.Value = Principalid.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Principal');", true);
                    txtPrincipal.Focus();
                    txtPrincipal.Text = "";
                    blr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

           // btnCancel.Text = "Cancel";

            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtPic_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
               // DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                // int Picid = da_obj_Customer.GetCustomerid(txtPic.Text.ToUpper());
                int Picid = objMasterEmp.GetNEmpid(txtPic.Text.ToUpper());
                if (Picid != 0 && hid_pic.Value != "0")
                {
                    hid_pic.Value = Picid.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid PIC');", true);
                    txtPic.Focus();
                    txtPic.Text = "";
                    blr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txtPol.Focus();
          //  btnCancel.Text = "Cancel";
            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtPol_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
              //  DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
                int Polid = da_obj_Port.GetNPortid(txtPol.Text.ToUpper().Trim());
                if (Polid != 0 && hid_pol.Value != "0")
                {
                    hid_pol.Value = Polid.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid POL');", true);
                    txtPol.Focus();
                    txtPol.Text = "";
                    blr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txtPod.Focus();
            //btnCancel.Text = "Cancel";

            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtPod_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
              //  DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
                int Podid = da_obj_Port.GetNPortid(txtPod.Text.ToUpper().Trim());
                if (Podid != 0 && hid_pod.Value != "0")
                {
                    hid_pod.Value = Podid.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid POD');", true);
                    txtPod.Focus();
                    txtPod.Text = "";
                    blr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txtFd.Focus();
          //  btnCancel.Text = "Cancel";

            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtFd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
              //  DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
                int Podid = da_obj_Port.GetNPortid(txtFd.Text.ToUpper().Trim());
                if (Podid != 0 && hid_Fd.Value != "0")
                {
                    hid_Fd.Value = Podid.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid FD');", true);
                    txtFd.Focus();
                    txtFd.Text = "";
                    blr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txtCargo.Focus();
           // btnCancel.Text = "Cancel";

            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Grd_reuse_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grd_reuse.PageIndex = e.NewPageIndex;
                Loadreuse();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
           // btnCancel.Text = "Cancel";

            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Grd_reuse_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                popupBuying.Hide();
                int index = Convert.ToInt32(Grd_reuse.SelectedRow.RowIndex);

                txtJob.Text = Grd_reuse.Rows[index].Cells[0].Text;

                dataTable = objJobType.GetCHJobInfo(Convert.ToInt32((txtJob.Text)), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

                if (dataTable.Rows.Count != 0)
                {
                    Jobtype = dataTable.Rows[0][1].ToString();

                    ddlJobType.SelectedValue = objJobType.SetJobtype(Jobtype);

                    txtDoc.Text = dataTable.Rows[0][2].ToString();

                    docdate = dataTable.Rows[0][3].ToString();

                    txtDocDate.Text = Utility.fn_ConvertDate(dataTable.Rows[0][3].ToString());

                    txtMDoc.Text = dataTable.Rows[0][4].ToString();

                    txtVesselFlightTruck.Text = dataTable.Rows[0][5].ToString();

                    txtCustomer.Text = dataTable.Rows[0][6].ToString();

                    txtShiper.Text = dataTable.Rows[0][7].ToString();


                    txtConsignee.Text = dataTable.Rows[0][8].ToString();

                    txtNotifyParty.Text = dataTable.Rows[0][9].ToString();

                    txtPrincipal.Text = dataTable.Rows[0][10].ToString();

                    txtPic.Text = dataTable.Rows[0][11].ToString();

                    txtCargo.Text = dataTable.Rows[0][12].ToString();

                    txtPackages.Text = dataTable.Rows[0][13].ToString();

                    ddlPackages.Text = dataTable.Rows[0][14].ToString();

                    txtGrossWeight.Text = dataTable.Rows[0][15].ToString();

                    txtNetWeight.Text = dataTable.Rows[0][16].ToString();

                    txtVolume.Text = dataTable.Rows[0][17].ToString();

                    txtVolume1.Text = dataTable.Rows[0][18].ToString();

                    txtDocuments.Text = dataTable.Rows[0][19].ToString();
                    txtPol.Text = dataTable.Rows[0][20].ToString();

                    txtPod.Text = dataTable.Rows[0][21].ToString();

                    txtFd.Text = dataTable.Rows[0][22].ToString();

                    customerlog = objMasCus.GetCustlocation(Convert.ToInt32(dataTable.Rows[0][23].ToString()));
                    shipperlog = objMasCus.GetCustlocation(Convert.ToInt32(dataTable.Rows[0][24].ToString()));
                    consigneelog = objMasCus.GetCustlocation(Convert.ToInt32(dataTable.Rows[0][25].ToString()));

                    notifylog = objMasCus.GetCustlocation(Convert.ToInt32(dataTable.Rows[0][26].ToString()));

                    principallog = objMasCus.GetCustlocation(Convert.ToInt32(dataTable.Rows[0][27].ToString()));

                    txtJobDate.Text = Utility.fn_ConvertDate(dataTable.Rows[0]["jobdate"].ToString());

                    hid_customer.Value = dataTable.Rows[0][23].ToString();

                    hid_shipper.Value = dataTable.Rows[0][24].ToString();

                    hid_consignee.Value = dataTable.Rows[0][25].ToString();

                    hid_Notify.Value = dataTable.Rows[0][26].ToString();

                    hid_Principal.Value = dataTable.Rows[0][27].ToString();

                    hid_pol.Value = dataTable.Rows[0]["polid"].ToString();

                    hid_pod.Value = dataTable.Rows[0]["podid"].ToString();

                    hid_Fd.Value = dataTable.Rows[0]["fdid"].ToString();

                    if (dataTable.Rows[0]["jobprofit"].ToString() == "P")
                    {
                        CHk_DropAIR.Checked = true;
                    }
                    else
                    {
                        CHk_DropAIR.Checked = false;
                    }




                   // btnSave.Text = "Save";

                    //btnCancel.Text = "Cancel";


                    btnSave.ToolTip = "Save";
                    btnSave1.Attributes["class"] = "btn ico-save";

                    btnCancel.ToolTip = "Cancel";
                    btnCancel1.Attributes["class"] = "btn ico-cancel";

                    //for (int s = 0; s <= 6; s++)
                    //{
                    //    dt = objInvoice.CheckIPDCWMBL(txtDoc.Text, "CH", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["Vouyear"]), s);

                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        txtDoc.Enabled = false;

                    //        txtGrossWeight.Enabled = false;

                    //        txtVolume.Enabled = false;
                    //    }

                    //    else
                    //    {
                    //        txtDoc.Enabled = true;

                    //        txtGrossWeight.Enabled = true;

                    //        txtVolume.Enabled = true;
                    //    }
                    //}
                    txtJob.Text = "";

                }
                else
                {
                    txtClear();

                    txtDoc.Enabled = true;

                    txtGrossWeight.Enabled = true;

                    txtVolume.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
           // btnCancel.Text = "Cancel";

            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";

        }

        protected void Grd_reuse_RowDataBound(object sender, GridViewRowEventArgs e)
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

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_reuse, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Btn_reuse_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            Panel4.Visible = true;
            Loadreuse();

            
           
        }

        protected void logdetails1_Click(object sender, EventArgs e)
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

            obj_dtlogdetails = logDetails.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 9, "Job", txtJob.Text, txtJob.Text, Session["StrTranType"].ToString());
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


        protected void txtMDoc_TextChanged(object sender, EventArgs e)
        {
            if (txtDoc.Text.Trim().ToUpper() == txtMDoc.Text.Trim().ToUpper())
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "JobInfo", "alertify.alert('DOC # and MDoc # should not Same,kindly change MDoc #');", true);
                txtMDoc.Focus();
                return;

            }


        }
     
    }
}