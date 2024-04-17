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
    public partial class MasterBillType : System.Web.UI.Page
    {        
        DataAccess.Masters.MasterBank mabillobj = new DataAccess.Masters.MasterBank();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataTable dtbill = new DataTable();
        int billid;
        string billtype = "";
        Boolean blrr;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                mabillobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
               
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);
            
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if(!IsPostBack)
            {
                txt_billname.Focus();
                btnCancel.Text = "Cancel";

                btnCancel.ToolTip = "Cancel";
                btnCancel1.Attributes["class"] = "btn ico-cancel";
            }
            
        }

        [WebMethod]
        public static List<string> Getbillname(string prefix)
        {
            DataAccess.Masters.MasterBank mabillobj = new DataAccess.Masters.MasterBank();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            mabillobj.GetDataBase(Ccode);
            List<string> billname = new List<string>();
            DataTable dt_Billname = new DataTable();            
            dt_Billname = mabillobj.GetLikeBillName(prefix.ToUpper());
            billname = Utility.Fn_TableToList(dt_Billname, "billname", "billid");
            return billname;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbbillType.Text != "")
            {
                if (cmbbillType.Text == "SHIPPING BILL")
                {
                    billtype = "SB";
                }
                else
                {
                    billtype = "BE";
                }
            }

            checkdata();

            if(blrr==true)
            {
                return;
            }
            if(btnSave.ToolTip == "Save")
            {
               
                mabillobj.InsertMasterBill((txt_billname.Text.Trim().ToUpper()), billtype);
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1413, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_billname.Text + "/Sav");                               
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "MasterBillType", "alertify.alert('Details Saved')", true);                
            }
            else if (btnSave.ToolTip == "Update")
            {
               // checkdata();
                mabillobj.UpdMasterBill((txt_billname.Text.Trim().ToUpper()), billtype,Convert.ToInt32 (hf_billid.Value));
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1413, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_billname.Text + "/Upd");                               
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "MasterBillType", "alertify.alert('Details Updated')", true);
                txtclear();
               btnSave.Text = "Save";
                btnSave.ToolTip = "Save";
                btnSave1.Attributes["class"] = "btn ico-save";

            }
            txt_billname.Focus();
            btnCancel.Text = "Cancel";

            btnCancel.ToolTip = "Cancel";
            btnCancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sfs1"] = "";
                Session["str_sfs2"] = "";
                Session["str_sp"] = "";

                str_RptName = "MasterBill.rpt";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1413, 3, int.Parse(Session["LoginBranchid"].ToString()), txt_billname.Text + "/View");                               
                ScriptManager.RegisterStartupScript(btnView, typeof(Button), "MasterBillType", str_Script, true);

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
                txt_billname.Focus();
                txtclear();
                btnCancel.Text = "Back";

                btnCancel.ToolTip = "Back";
                btnCancel1.Attributes["class"] = "btn ico-back";
                btnCancel.Enabled = true;
            }
            else 
            {
                this.Response.End();
            }
        }

        protected void txt_billname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtbill = mabillobj.GetSelBillid(txt_billname.Text.ToUpper());
                if (dtbill.Rows.Count != 0)
                {
                    hf_billid.Value = dtbill.Rows[0]["billid"].ToString();
                    if (dtbill.Rows[0]["billtype"].ToString() == "SB")
                    {
                        cmbbillType.Text = "SHIPPING BILL";
                    }
                    else
                    {
                        cmbbillType.Text = "BILL OF ENTRY";
                    }
                   btnSave.Text = "Update";
                    btnSave.ToolTip = "Update";
                    btnSave1.Attributes["class"] = "btn ico-update";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "MasterBillType", "alertify.alert('Details Already Exists')", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txt_billname.Focus();
        }

        protected void cmbbillType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbbillType.Text != "")
            {
                if (cmbbillType.Text == "SHIPPING BILL")
                {
                    billtype = "SB";
                }
                else 
                {
                    billtype = "BE";
                }
            }
        }
        public void checkdata()
        {
            if (txt_billname.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "MasterBillType", "alertify.alert('BILL NAME CAN'T BE BLANK')", true);
                txt_billname.Focus();
                blrr = true;
                return;
                
            }
            if (cmbbillType.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "MasterBillType", "alertify.alert('Bill Type Cannot be Blank')", true);
                cmbbillType.Focus();
                blrr = true;
                return;
            }
        }
        public void txtclear()
        { 
        txt_billname.Text = "";
        cmbbillType.SelectedIndex = -1;
        txt_billname.Focus();
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

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1413, "MSbiitype", txt_billname.Text, txt_billname.Text, "");  //"/Rate ID: " +
            if (txt_billname.Text != "")
            {
                JobInput.Text = txt_billname.Text;


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