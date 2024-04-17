using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Maintenance
{
    public partial class CustomerWithPanReq : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        string status = "";
        Boolean blr;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                customerobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
               
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                try
                {
                    cmbpanreq.Items.Clear();
                    cmbpanreq.Items.Add("---Select---");
                    cmbpanreq.Items.Add("YES");
                    cmbpanreq.Items.Add("NO");
                   btncancel.Text = "Cancel";

                    btncancel.ToolTip = "Cancel";
                    btncancel1.Attributes["class"] = "btn ico-cancel";
                    txtcustomer.Focus();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }

        [WebMethod]
        public static List<string> Getcusname(string prefix)
        {
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            List<string> cusname = new List<string>();
            DataTable Dt1 = new DataTable();
            Dt1 = customerobj.GetLikeCustomerNotAgent(prefix.ToUpper());
            cusname = Utility.Fn_TableToList(Dt1, "customername", "customerid");
            return cusname;
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                checkdetails();
                if( blr == true)
                {
                   
                    return;
                }
                if (cmbpanreq.Text == "YES")
                {
                    status = "Y";
                }
                else
                {
                    status = "N";
                }
                if (hf_cusid.Value != "0")
                {
                    customerobj.UpdPAnno(Convert.ToInt32(hf_cusid.Value), status);
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1691, 2, int.Parse(Session["LoginBranchid"].ToString()), hf_cusid.Value+"-Status-"+status);
                    ScriptManager.RegisterStartupScript(btnupdate, typeof(Button), "CustomerWithPanReq", "alertify.alert('Details has Updated')", true);
                    clear();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void checkdetails()
        {
            try
            {
                if (txtcustomer.Text.Trim().TrimStart().TrimEnd() == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "CustomerWithPanReq", "alertify.alert('Customer Name cannot be Blank')", true);
                    txtcustomer.Focus();
                    blr = true;
                    return;
                }
                else if (hf_cusid.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "CustomerWithPanReq", "alertify.alert('Invalid Customer')", true);
                    txtcustomer.Focus();
                    blr = true;
                    return;
                }
                if (cmbpanreq.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "CustomerWithPanReq", "alertify.alert('Required PAN# Details Cannot be Blank')", true);
                    cmbpanreq.Focus();
                    blr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void clear()
        {
           
                txtcustomer.Text = "";
                cmbpanreq.SelectedIndex = 0;
                btncancel.Text = "Back";

                btncancel.ToolTip = "Back";
                btncancel1.Attributes["class"] = "btn ico-back";

           
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (btncancel.ToolTip == "Cancel")
            {
                clear();
                txtcustomer.Focus();

               btncancel.Text="Back";
                btncancel.ToolTip = "Back";
                btncancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
        }

        protected void txtcustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt2 = new DataTable();
                if (hf_cusid.Value != "0" || hf_cusid.Value != "")
                {
                    dt2 = customerobj.GetAllCustDetails(Convert.ToInt32(hf_cusid.Value));
                    if (dt2.Rows.Count > 0)
                    {
                        txtcustomer.Text = dt2.Rows[0]["customername"].ToString();
                        status = dt2.Rows[0]["panreq"].ToString();
                        if (status == "Y")
                        {
                            cmbpanreq.Text = "YES";
                        }
                        else if (status == "N")
                        {
                            cmbpanreq.Text = "NO";
                        }
                        else
                        {
                            cmbpanreq.SelectedIndex = -1;
                        }
                        btncancel.Text = "Cancel";


                        btncancel.ToolTip = "Cancel";
                        btncancel1.Attributes["class"] = "btn ico-cancel";

                    }
                    else
                    {
                        clear();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
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
            PanelLog1.Visible = true;
            GridViewlog.Visible = true;
            Panel2.Visible = true;
           // DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1691, "MSPan", hf_cusid.Value, hf_cusid.Value, "");  //"/Rate ID: " +
            if (txtcustomer.Text != "")
            {
                JobInput.Text = txtcustomer.Text;
             }
            else
            {
                JobInput.Text = "";
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