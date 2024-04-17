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
using System.Text;

namespace logix.BT
{
    public partial class BTJobInfoaspx : System.Web.UI.Page
    {

        DataAccess.LogDetails objLogDetails = new DataAccess.LogDetails();

        DataAccess.Masters.MasterPort objMasterPort = new DataAccess.Masters.MasterPort();

        DataTable dt = new DataTable();

        DataAccess.Masters.MasterCustomer objMasCus = new DataAccess.Masters.MasterCustomer();

        DataAccess.Masters.MasterPackages objMasPackages = new DataAccess.Masters.MasterPackages();

        // DataAccess.BondedTrucking.BTJobInfo objBoundedTrackng = new DataAccess.BondedTrucking.BTJobInfo();

        DataTable DTable = new DataTable();

        DataTable dtTable = new DataTable();

        int fromPort, toPort;
        bool blrr;

        int packageId;
        string str_Uiid = "", str_FornName;
        DataAccess.BondedTrucking.BTJobInfo objBoundTracking = new DataAccess.BondedTrucking.BTJobInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(grdView);
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

                GetEmptyGrid();
                LoadPackages();
                hid_date.Value = Utility.fn_ConvertDate(objLogDetails.GetDate().ToShortDateString());

                txtEta.Text = hid_date.Value;

                txtEtd.Text = hid_date.Value;

                txtWeight.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
                txtNoofPackages.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
                txtCBM.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
                txtJob.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
               // txtFromPort.Text = Session["LoginBranchName"].ToString();
                UserRights();
                txtJob.Focus();
                //btnCancel.Text = "Cancel";

                btnCancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void GetEmptyGrid()
        {
            try
            { 
            grdView.DataSource = Utility.Fn_GetEmptyDataTable();

            grdView.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        public void JobDetails()
        {
            try
            { 
            dt = objBoundTracking.GetBTJobInfo(Convert.ToInt32(txtJob.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

            if (dt.Rows.Count > 0)
            {
                txtTruck.Text = dt.Rows[0]["truckno"].ToString();
                txtFromPort.Text = dt.Rows[0]["fromport"].ToString();
                txtEtd.Text = Utility.fn_ConvertDate(dt.Rows[0]["etd"].ToString());
                txtEta.Text = Utility.fn_ConvertDate(dt.Rows[0]["eta"].ToString());
                txtToPort.Text = dt.Rows[0]["toport"].ToString();

              //  btnSave.Text = "Update";
              //  btnCancel.Text = "Cancel";

                btnSave.ToolTip = "Update";
                btn_cancel1.Attributes["class"] = "btn btn-update1";

                btnCancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Please Enter the Valid Jobno');", true);
                txtJob.Text = "";
                txtJob.Focus();
            }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            //btnCancel.Text = "Cancel";

            btnCancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        public void LoadPackages()
        {
            try
            { 
            DTable = objMasPackages.GetPackagenames();

            ddlPageType.DataValueField = "descn";

            ddlPageType.DataTextField = "descn";

            ddlPageType.DataSource = DTable;

            ddlPageType.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        public void GetGrdDetails()
        {

            try
            { 
            dtTable = objBoundTracking.GetBTJobDetails(Convert.ToInt32(txtJob.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

            if (dtTable.Rows.Count > 0)
            {
                DataTable dtemp = new DataTable();
                dtemp.Columns.Add("Grdsbno");
                dtemp.Columns.Add("CustomerName");
                dtemp.Columns.Add("NoOfPackages");
                dtemp.Columns.Add("PackageType");
                dtemp.Columns.Add("Weight");
                dtemp.Columns.Add("CBM");
                dtemp.Columns.Add("CustId");
                for (int i = 0; i <= dtTable.Rows.Count - 1; i++)
                {
                    dtemp.Rows.Add();
                    dtemp.Rows[i]["Grdsbno"] = dtTable.Rows[i]["sbno"].ToString();
                    dtemp.Rows[i]["CustomerName"] = dtTable.Rows[i]["customername"].ToString();
                    dtemp.Rows[i]["NoOfPackages"] = dtTable.Rows[i]["noofpkgs"].ToString();
                    dtemp.Rows[i]["PackageType"] = dtTable.Rows[i]["descn"].ToString();
                    dtemp.Rows[i]["Weight"] = dtTable.Rows[i]["weight"].ToString();
                    dtemp.Rows[i]["CBM"] = dtTable.Rows[i]["CBM"].ToString();
                    dtemp.Rows[i]["CustId"] = dtTable.Rows[i]["Customer"].ToString();
                }
                Session["Container"] = dtemp;
                grdView.DataSource = dtemp;
                grdView.DataBind();
                txtShippingBill.Focus();
            }
            else
            {
                grdView.DataSource = Utility.Fn_GetEmptyDataTable();
                grdView.DataBind();
                txtJob.Focus();
            }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
             
            }
           // btnCancel.Text = "Cancel";
            btnCancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

        }

        [WebMethod]

        public static List<string> GetToPort(string prefix)
        {
            List<string> list_result = new List<string>();

            DataAccess.Masters.MasterPort objMasterPort = new DataAccess.Masters.MasterPort();

            DataTable DTable = new DataTable();

            DTable = objMasterPort.GetLikePort(prefix);

            list_result = Utility.Fn_DatatableToList(DTable, "portname", "portid");

            return list_result;
        }

        [WebMethod]

        public static List<string> GetCustomer(string prefix)
        {
            List<string> list_result = new List<string>();

            DataAccess.Masters.MasterCustomer objMasCus = new DataAccess.Masters.MasterCustomer();

            DataTable DTable = new DataTable();

            DTable = objMasCus.GetLikeCustomer(prefix);

            list_result = Utility.Fn_DatatableToList(DTable, "customer", "customerid");

            return list_result;
        }

        protected void txtJob_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtJob.Text != "0")
                {
                    JobDetails();

                    GetGrdDetails();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txtJob.Text = "";
                txtJob.Focus();
            }
        }

        //public void Bindgrid()
        //{
        //    dt = objBoundTracking.GetBTJobInfoALL(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

        //    if(dt.Rows.Count==0)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Job Not Available');", true);

        //        return;
        //    }

        //    btnSave.Text = "Save";

        //    btnCancel.Text = "Cancel";

        //    grdJob.DataSource = dt;

        //    grdJob.DataBind();

        //    grdJob.Focus();
        //}

        public void GridBind()
        {

            try 
            { 
            dt = objBoundTracking.GetBTJobInfoALL(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
             
                        

            if (dt.Rows.Count > 0)
            {

                DataTable datatemp = new DataTable();
                datatemp.Columns.Add("Job #");
                datatemp.Columns.Add("Truck #");
                datatemp.Columns.Add("From");
                datatemp.Columns.Add("ETD");
                datatemp.Columns.Add("To");
                datatemp.Columns.Add("ETA");
                DataRow dr = datatemp.NewRow();
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dr = datatemp.NewRow();
                    datatemp.Rows.Add(dr);
                    dr["Job #"] = dt.Rows[i]["jobno"].ToString();
                    dr["Truck #"] = dt.Rows[i]["truckno"].ToString();
                    dr["From"] = dt.Rows[i]["fromport"].ToString();
                    dr["ETD"] = Utility.fn_ConvertDate(dt.Rows[i]["etd"].ToString());
                    dr["To"] = dt.Rows[i]["toport"].ToString();
                    dr["ETA"] = Utility.fn_ConvertDate(dt.Rows[i]["eta"].ToString());
                }
                this.popupBuying.Show();
                grdJob.DataSource = datatemp;
                grdJob.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Job Not Available');", true);
                return;
            }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txtShippingBill.Focus();
        }

        protected void lnkJob_Click(object sender, EventArgs e)
        {
            GridBind();
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            { 

            CheckData();
            if (blrr == false)
            {
                return;
            }
            //fromPort = objMasterPort.GetNPortid(txtFromPort.Text);

            //toPort = objMasterPort.GetNPortid(txtToPort.Text);

            if (btnSave.ToolTip == "Save")
            {
                txtJob.Text = objBoundTracking.InsBTJobInfo(txtTruck.Text.ToUpper(), fromPort, Convert.ToDateTime(Utility.fn_ConvertDatetime(txtEtd.Text)), toPort, Convert.ToDateTime(Utility.fn_ConvertDatetime(txtEta.Text)), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                objLogDetails.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 368, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtJob.Text);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Details Saved');", true);

               // btnSave.Text = "Update";

                btnSave.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";

                btnAdd.Enabled = true;
            }

            else
            {
                objBoundTracking.UpdBTJobInfo(txtTruck.Text.ToUpper(), fromPort, Convert.ToDateTime(Utility.fn_ConvertDatetime(txtEtd.Text)), toPort, Convert.ToDateTime(Utility.fn_ConvertDatetime(txtEta.Text)), Convert.ToInt32(txtJob.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                objLogDetails.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 368, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtJob.Text);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Details Updated');", true);

                btnSave.Enabled = false;

                btnAdd.Enabled = true;

                txtShippingBill.Enabled = true;

                if (btnAdd.ToolTip == "Upd")
                {
                   // btnAdd.Text = "Add";

                    btnAdd.ToolTip = "Add";
                    btn_add1.Attributes["class"] = "btn btn-add1";

                }

               // btnCancel.Text = "Cancel";

                btnCancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }

            txtShippingBill.Focus();
            btnSave.Enabled = false;
            UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

      

        public void btnAdd_Click(object sender, EventArgs e)
        {
            try
            { 
            CheckDataGrd();

            // packageId = objMasPackages.GetNPackageid(ddlPageType.Text);
            if (blrr == false)
            {
                return;
            }
            if (btnAdd.ToolTip == "Add")
            {
                DTable = objBoundTracking.GetBTJobInfoFSBNo(txtShippingBill.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

                if (DTable.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Already Exists Shipping Bill #');", true);

                    txtShippingBill.Focus();

                    return;
                }

                objBoundTracking.InsBTJobDetails(Convert.ToInt32(txtJob.Text), Convert.ToInt32(hid_Customer.Value), Convert.ToInt32(txtNoofPackages.Text), packageId, Convert.ToDouble(txtWeight.Text), Convert.ToDouble(txtCBM.Text), txtShippingBill.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                objLogDetails.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 368, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtJob.Text + "/" + Convert.ToInt32(hid_Customer.Value));
                GetGrdDetails();

                txtClear1();
                txtJob.Focus();
            }

            else
            {
                objBoundTracking.UpdBTJobDetails(Convert.ToInt32(txtJob.Text), Convert.ToInt32(hid_Customer.Value), Convert.ToInt32(txtNoofPackages.Text), packageId, Convert.ToDouble(txtWeight.Text), Convert.ToDouble(txtCBM.Text), txtShippingBill.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                objLogDetails.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 368, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtJob.Text + "/" + Convert.ToInt32(hid_Customer.Value));
                GetGrdDetails();

                txtClear1();

                txtShippingBill.Enabled = true;

               // btnAdd.Text = "Add";

                btnAdd.ToolTip = "Add";
                btn_add1.Attributes["class"] = "btn btn-add1";

                txtJob.Focus();
            }
            UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        internal void add()
        {
            
        }

        protected void txtTruck_TextChanged(object sender, EventArgs e)
        {
            try
            { 
            txtFromPort.Text = Session["LoginBranchName"].ToString();

         //   btnCancel.Text = "Cancel";
            btnCancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

            txtToPort.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtFromPort_TextChanged(object sender, EventArgs e)
        {
            fromPort = objMasterPort.GetNPortid(txtFromPort.Text);
        }

        protected void grdJob_RowDataBound(object sender, GridViewRowEventArgs e)
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



        protected void grdJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = grdJob.SelectedRow.RowIndex;
                txtJob.Text = grdJob.Rows[index].Cells[0].Text;
                JobDetails();
                GetGrdDetails();
               // btnSave.Text = "Update";
                btnSave.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";


                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text == "&nbsp;")
                {
                    e.Row.Cells[i].Text = "";
                }
                e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdView, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            { 

            if (e.CommandName == "Delete")
            {
                ImageButton Img_delete = (ImageButton)e.CommandSource;
                GridViewRow gvRow = (GridViewRow)Img_delete.NamingContainer;
                DataTable objdt = new DataTable();
                objdt = (DataTable)Session["Container"];
                //btnCancel.Text = "Back";
                DataAccess.BondedTrucking.BTJobInfo objBoundTracking = new DataAccess.BondedTrucking.BTJobInfo();
                objBoundTracking.DeleteBTJobCustomer(Convert.ToInt32(txtJob.Text), objdt.Rows[gvRow.RowIndex]["Grdsbno"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "grdView", "alertify.alert('Details Deleted');", true);
                objdt.Rows[gvRow.RowIndex].Delete();
                objdt.AcceptChanges();
                grdView.DataSource = objdt;
                grdView.DataBind();
                txtClear1();
               // GetGrdDetails();
                Session["Container"] = objdt;
                UserRights();
                txtJob.Focus();
            }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
            int index = grdView.SelectedRow.RowIndex;
            txtShippingBill.Text = grdView.Rows[index].Cells[0].Text;
            txtCustomerName.Text = HttpUtility.HtmlDecode( grdView.Rows[index].Cells[1].Text);
            txtNoofPackages.Text = grdView.Rows[index].Cells[2].Text;
            ddlPageType.SelectedValue = grdView.Rows[index].Cells[3].Text;
            txtWeight.Text = grdView.Rows[index].Cells[4].Text;
            txtCBM.Text = grdView.Rows[index].Cells[5].Text;
            hid_Customer.Value = grdView.Rows[index].Cells[6].Text;

           // btnAdd.Text = "Upd";

            btnAdd.ToolTip = "Upd";
            btn_add1.Attributes["class"] = "btn btn-UpdateAdd2";

            txtCustomerName.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        public void CheckData()
        {
            blrr = true;
            if(txtFromPort.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('From Port  Cannot be blank');", true);
                txtFromPort.Text = "";
                txtFromPort.Focus();
                blrr = false;
            }

            else
            {
                fromPort = objMasterPort.GetNPortid(txtFromPort.Text.Trim());

                if(fromPort==0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Invalid From Port');", true);
                    txtFromPort.Text = "";
                    txtFromPort.Focus();
                    blrr = false;
                }
                
            }

           if(txtToPort.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('To Port  Cannot be blank');", true);
                txtToPort.Text = "";
                txtToPort.Focus();
                blrr = false;
            }
           else
           {
               toPort = objMasterPort.GetNPortid(txtToPort.Text.Trim());

               if (toPort == 0)
               {
                   ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Invalid ToPort');", true);
                   txtToPort.Text = "";
                   txtToPort.Focus();
                   blrr = false;
               }
           }

            if(fromPort==toPort)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('From port and To port should not same');", true);
                blrr = false;
            }

            if(txtTruck.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Truck # Cannot be blank');", true);
                txtTruck.Focus();
                blrr = false;
            }
        }

        public void CheckDataGrd()
        {
            blrr = true;
            if(txtCustomerName.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Customername Cannot BE BLANK');", true);
                txtCustomerName.Focus();
                blrr = false;
            }
            else
            {
                hid_Customer.Value = objMasCus.GetCustomerid(txtCustomerName.Text).ToString();

                if (hid_Customer.Value=="0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('INVALID Customername NAME');", true);
                    txtCustomerName.Focus();
                    blrr = false;
                }
            }
            if(txtNoofPackages.Text=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('No.Of.Pakages Cannot BE BLANK');", true);
                txtNoofPackages.Focus();
                blrr = false;
            }
            packageId = objMasPackages.GetNPackageid(ddlPageType.Text);
            if (packageId==0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Invalid PackageType');", true);
                txtNoofPackages.Focus();
                blrr = false;
            }
            if(txtWeight.Text=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('Weight Cannot BE BLANK');", true);
                txtWeight.Focus();
                blrr = false;
            }
            if (txtCBM.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BTJobInfoaspx", "alertify.alert('CBM Cannot BE BLANK');", true);
                txtCBM.Focus();
                blrr = false;
            }
        }

        
        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {

                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btnSave, btnView, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    Boolean btn_delete;
                    btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }


        public void txtClear1()
        {
            txtCustomerName.Text = "";

            txtNoofPackages.Text = "";

            ddlPageType.SelectedIndex = 0;

            txtWeight.Text = "";

            txtCBM.Text = " ";

            txtShippingBill.Text = "";

            btnAdd.Visible = true;

            
        }

        public void txtcLear()
        {
            txtJob.Text = "";

            txtTruck.Text = "";

            txtFromPort.Text = "";

            txtToPort.Text = "";

            txtEta.Text = hid_date.Value;

            txtEtd.Text = hid_date.Value;

            btnSave.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if(btnCancel.ToolTip=="Back")
            {
                this.Response.End();
            }
            else
            {
                txtcLear();
                txtClear1();
               // btnCancel.Text = "Back";

                btnCancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";

                if(btnSave.ToolTip=="Update")
                {
                   // btnSave.Text = "Save";

                    btnSave.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                }
                //btnAdd.Enabled = false;
                txtEta.Text = hid_date.Value;
                txtEtd.Text = hid_date.Value;
                txtJob.Focus();
                GetEmptyGrid();
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
            str_RptName = "BTJobInfo.rpt";
            int jobno=0;
            if(txtJob.Text=="")
            {
                DTable = objBoundTracking.GetBTJobInfoALL(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

                if(DTable.Rows.Count == 0)
                {

                    str_sf = "{BTJobInfo.bid}=" + bid + " and {BTJobInfo.jobno}=" + jobno;
                   
                }else
                {
                    str_sf = "{BTJobInfo.bid}=" + bid;
                    
                }
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btnView, typeof(Button), "JobInfo", str_Script, true);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
            else
            {
                str_sf = "{BTJobInfo.bid}=" + bid + " and {BTJobInfo.jobno}=" + txtJob.Text;
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                objLogDetails.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 368, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtJob.Text);
                ScriptManager.RegisterStartupScript(btnView, typeof(Button), "JobInfo", str_Script, true);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnPendingTranper_Click(object sender, EventArgs e)
        {
            try
            { 
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";

            str_RptName = "BTStatus.rpt";

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

        protected void txtToPort_TextChanged(object sender, EventArgs e)
        {
            txtEtd.Focus();
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
            Panel3.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();           


                obj_dtlogdetails = objLogDetails.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 368, "Job", txtJob.Text, txtJob.Text, Session["StrTranType"].ToString());



                if (txtJob.Text != "")
                {
                    JobInput.Text = txtJob.Text;

                    lbl_no.InnerText = "Job #:";

                }
                if (obj_dtlogdetails.Rows.Count >= 0)
                {
                    ModalPopupExtenderlog.Show();
                    GridViewlog.DataSource = obj_dtlogdetails;
                    GridViewlog.DataBind();
                }
            
        }

        
    }
}