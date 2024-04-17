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
using System.Web.Services.Description;

namespace logix.Maintenance
{
    public partial class MasterCarrier : System.Web.UI.Page
    {


        bool blr;
        DataAccess.Masters.Carrier objCarrier = new DataAccess.Masters.Carrier();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                objCarrier.GetDataBase(Ccode);
               
            }

            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);

            if (!IsPostBack)
            {
                txtCarrierName.Focus();
                btnCancel.Text = "Cancel";
            }
        }

        [WebMethod]
        public static List<string> GetCarriername(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.Carrier objCarrier = new DataAccess.Masters.Carrier();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objCarrier.GetDataBase(Ccode);
            DataTable dtCarrier = new DataTable();
            dtCarrier = objCarrier.GetCarrierNameForNew(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(dtCarrier, "CarrierName", "CarrierID");

            return List_Result;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //check_data();
            if (txtCarrierName.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "MasterCarrier", "alertify.alert('Please Enter Carrier Name');", true);
                txtCarrierName.Text = "";
                txtCarrierName.Focus();
                blr = true;
                return;
            }
            //if (blr == true)
            //{
            //    blr = false;
            //    return;
            //}
        

            if (btnSave.Text == "Save")
            {
                hid_carrier.Value = objCarrier.InsertMasterCarrierNew(txtCarrieerCode.Text.ToUpper(), txtCarrierName.Text.ToUpper(), txtSCACcode.Text.ToUpper()).ToString();
                
                ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "MasterCarrier", "alertify.alert('Details Saved');", true);
                Clear();
                btnSave.Text = "Update";
            }

            else if (btnSave.Text == "Update")
            {
                if (hid_carrier.Value == "" || hid_carrier.Value == "0")
                {
                    hid_carrier.Value =hid_carrier_upd.Value ;
                }
                if (hid_carrier.Value == "" || hid_carrier.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "MasterCarrier", "alertify.alert('Enter Valid carrier Name');", true);
                    txtCarrierName.Focus();
                    return;
                }
                objCarrier.UpdateMasterCarriernew(Convert.ToInt32(hid_carrier.Value), txtCarrieerCode.Text.ToUpper(), txtCarrierName.Text.ToUpper(), txtSCACcode.Text.ToUpper());
                ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "MasterCarrier", "alertify.alert('Details Updated');", true);
                Clear();
                btnSave.Text = "Save";
            }
            btnCancel.Text = "Cancel";
        }

        public void Clear()
        {
            txtCarrieerCode.Text = "";
            txtCarrierName.Text = "";
            txtSCACcode.Text = "";
            hid_carrier.Value = "";
            hid_carrier_upd.Value = "";
        }

        public void check_data()
        {
            if (txtCarrieerCode.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "MasterCarrier", "alertify.alert('Please Enter Carrier');", true);
                txtCarrieerCode.Text = "";
                txtCarrieerCode.Focus();
                blr = true;
                return;
            }

            if (txtCarrierName.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "MasterCarrier", "alertify.alert('Please Enter Carrier Name');", true);
                txtCarrierName.Text = "";
                txtCarrierName.Focus();
                blr = true;
                return;
            }

            if (txtSCACcode.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "MasterCarrier", "alertify.alert('Please Enter SCACCode');", true);
                txtSCACcode.Text = "";
                txtSCACcode.Focus();
                blr = true;
                return;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "Cancel")
            {
                Clear();
                txtcarrierId.Text = "";
                txtCarrierName.Focus();
                btnCancel.Text = "Back";
                btnSave.Text = "Save";
            }
            else
            {
                this.Response.End();
            }

        }

        protected void txtCarrierName_TextChanged(object sender, EventArgs e)
        {
            if (txtCarrierName.Text!="")
            {
                if (hid_carrier.Value != "0" && hid_carrier.Value!="")
                {
                    hid_carrier_upd.Value = hid_carrier.Value;
                    dt = objCarrier.RetrivemastercarrierDetails(Convert.ToInt32(hid_carrier.Value));
                    if (dt.Rows.Count > 0)
                    {
                        txtCarrieerCode.Text = dt.Rows[0]["CarrierCode"].ToString();
                        txtSCACcode.Text = dt.Rows[0]["SCACcode"].ToString();
                        hid_carrier.Value = dt.Rows[0]["carrierid"].ToString();
                        btnSave.Text = "Update";
                        txtCarrierName.Focus();
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "MasterCarrier", "alertify.alert('Details already exists');", true);
                    }
                    else
                    {
                        btnSave.Text = "Save";
                    }
                
                }
                else
                {
                    txtCarrieerCode.Focus();
                }
                
            }
        }

        protected void txtCarrieerCode_TextChanged(object sender, EventArgs e)
        {
            txtSCACcode.Focus();
        }
    }
}