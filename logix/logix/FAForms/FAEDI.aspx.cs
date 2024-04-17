using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.FAForm
{
    public partial class FAEDI : System.Web.UI.Page
    {
        DataAccess.FAVoucher da_obj_favoucher = new DataAccess.FAVoucher();
        DataAccess.Accounts.Invoice Obj_Invoice = new DataAccess.Accounts.Invoice();

        int bid, did, EmpId, Vouyear;
        string FADbname, Trantype, Status, str_Uiid;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);



            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_favoucher.GetDataBase(Ccode);
                Obj_Invoice.GetDataBase(Ccode);
               


            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_exportexcel);
           
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_head.Text = Request.QueryString["FormName"].ToString();
            }

            FADbname = Session["FADbname"].ToString();
            bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            EmpId = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            Vouyear = Convert.ToInt32(HttpContext.Current.Session["Vouyear"].ToString());
            str_Uiid = (Request.QueryString["uiid"].ToString());

            if (Session["StrTranType"].ToString() != null)
            {
                Trantype = Session["StrTranType"].ToString();
            }

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                if (Trantype == "CO")
                {
                    //ddl_voucher.Items.Add("");
                    ddl_voucher.Items.Add("Admin Purchase Invoice");
                    ddl_voucher.Items.Add("Admin Sales Invoice");
                    ddl_voucher.Items.Add("Contra");
                    ddl_voucher.Items.Add("Journal");
                    ddl_voucher.Items.Add("Bank Payment");
                    ddl_voucher.Items.Add("Cash Payment");
                    ddl_voucher.Items.Add("Bank Receipt");
                    ddl_voucher.Items.Add("Remittance-Payment");
                    ddl_voucher.Items.Add("Remittance-Receipt");
                    ddl_voucher.Items.Add("Receipt - Petty Cash");
                }
                else
                {
                    //ddl_voucher.Items.Add("");
                    ddl_voucher.Items.Add("Bank Deposit - Transfer To CO");
                    ddl_voucher.Items.Add("Sales Invoice");
                    ddl_voucher.Items.Add("Purchase Invoice");
                    ddl_voucher.Items.Add("OSSI");
                    ddl_voucher.Items.Add("OSPI");
                    ddl_voucher.Items.Add("Debit Note - Others");
                    ddl_voucher.Items.Add("Credit Note - Others");
                    ddl_voucher.Items.Add("Bank Receipt");
                    ddl_voucher.Items.Add("Cash Receipt");
                    ddl_voucher.Items.Add("Bank Payment");
                    ddl_voucher.Items.Add("Cash Payment");
                    ddl_voucher.Items.Add("Admin Purchase Invoice");
                    ddl_voucher.Items.Add("Admin Sales Invoice");
                    ddl_voucher.Items.Add("Contra");
                    ddl_voucher.Items.Add("Journal");
                    ddl_voucher.Items.Add("Receipt - Petty Cash");
                    ddl_voucher.Items.Add("BRG");
                }

                if (lbl_head.Text != "Admin Purchase Invoice" || lbl_head.Text != "Admin Sales Invoice")
                {
                    //ddl_narration.Items.Add("");
                    ddl_narration.Items.Add("LedgerNames");
                    ddl_narration.Items.Add("Vessel/Voyage/Container");
                    ddl_narration.Items.Add("Remarks");

                    //ddl_referen.Items.Add("");
                    ddl_referen.Items.Add("Voucher No");
                    ddl_referen.Items.Add("BL No");
                }
                else
                {
                    //ddl_narration.Items.Add("");
                    ddl_narration.Items.Add("Remarks");  

                    //ddl_referen.Items.Add("");
                    ddl_referen.Items.Add("Ref No");                                    
                }
                 btn_exportexcel.Text = "Cancel";
                btn_exportexcel.ToolTip = "Cancel";
                btn_exportexcel1.Attributes["class"] = "btn ico-cancel";             
            }
        }

        protected void btn_exportexcel_Click(object sender, EventArgs e)
        {
            if (btn_exportexcel.ToolTip == "Cancel")
            {
                ddl_voucher.SelectedIndex = -1;
                ddl_referen.SelectedIndex = -1;
                ddl_narration.SelectedIndex = -1;
                txt_from.Text = "";
                txt_month.Text = "";
                txt_to.Text = "";
                btn_exportexcel.Text = "Back";
                btn_exportexcel.ToolTip = "back";
                btn_exportexcel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
               // this.Response.End();
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                    else if (Session["StrTranType"].ToString() == "BR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");

                    }
                    else if (Session["StrTranType"].ToString() == "AC")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"] != null)
                    {
                        if (Session["home"].ToString() == "FABR")
                        {
                            Response.Redirect("../Home/Branch_home.aspx");
                        }
                        else if (Session["home"].ToString() == "FAFC")
                        {
                            Response.Redirect("../Home/CorporateHome.aspx");
                        }
                    }

                }
                else if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "FABR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"].ToString() == "FAFC")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                }
                else
                {
                    this.Response.End();
                }
                
            }
        }

        protected void btn_get_Click(object sender, EventArgs e)
        {
            string ddlnarration = "", ddlreference = "";
            int a = 0, b = 0, vouno, Vouyear;
            bool blrTDS = false;
            //DataAccess.Accounts.Invoice Obj_Invoice = new DataAccess.Accounts.Invoice();

            if (ddl_narration.SelectedIndex != -1)
            {
                ddlnarration = ddl_narration.SelectedItem.Text;
            }

            if (ddl_referen.SelectedIndex != -1)
            {
                ddlreference = ddl_referen.SelectedItem.Text;
            }

            if (ddl_voucher.SelectedItem.Text == "Bank Deposit - Transfer To CO" || ddl_voucher.SelectedItem.Text == "Cash Deposit - Transfer To CO")
            {
                logix.CommanClass.TallyEDIFA.Fn_FATransfer_Slip(ddl_voucher.SelectedItem.Text, txt_from.Text, 0, ddlnarration, ddlreference, "", 0, 0, "");
            }
            //if (ddl_voucher.SelectedItem.Text == "Debit Note - Others")
            //{
            //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), "Vessel/Voyage/Container", "BL No");
            //}
            //else if (ddl_voucher.SelectedItem.Text == "Admin Sales Invoice")
            //{
            //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Sales Invoice", Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), "Vessel/Voyage/Container", "BL No");
            //}
            //else if (ddl_voucher.SelectedItem.Text == "Cash Payment")
            //{
            //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Cash Payment", Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), "Vessel/Voyage/Container", "BL No");
            //}
            //else if (ddl_voucher.SelectedItem.Text == "Bank Payment")
            //{               
            //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Bank Payment", Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), "Vessel/Voyage/Container", "BL No", "", bid, 0, "");
            //}
            //else if (ddl_voucher.SelectedItem.Text == "Cash Receipt")
            //{
            //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Cash Receipt", Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), "Vessel/Voyage/Container", "BL No");
            //}
            //else if (ddl_voucher.SelectedItem.Text == "Bank Receipt")
            //{
            //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Bank Receipt", Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), "Vessel/Voyage/Container", "BL No");
            //}
            //else if (ddl_voucher.SelectedItem.Text == "Invoices")
            //{
            //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), "Vessel/Voyage/Container", "BL No");
            //}
            //else if (ddl_voucher.SelectedItem.Text == "OSSI")
            //{
            //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSSI", Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), "Vessel/Voyage/Container", "BL No");
            //}
            //else if (ddl_voucher.SelectedItem.Text == "OSPI")
            //{
            //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSPI", Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), "Vessel/Voyage/Container", "BL No");
            //}
            else if (ddl_voucher.SelectedItem.Text == "Bank Payment")
            {
                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Bank Payment", Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), "", "", bid, "", 0, 0, "");
            }
            else
            {
                if (txt_from.Text != "")
                {
                    a = Convert.ToInt32(txt_from.Text);
                }

                if (txt_to.Text != "")
                {
                    b = Convert.ToInt32(txt_to.Text);
                }
                Vouyear = Convert.ToInt32(Session["LogYear"].ToString());

                for (int i = a; i <= b; i++)
                {
                    if (ddl_voucher.SelectedItem.Text == "Purchase Invoice")
                    {
                        if (Obj_Invoice.CheckTDSApplyORNot("P", i, Vouyear, Convert.ToInt32(Session["LoginBranchid"].ToString())) == 0)
                        {
                            blrTDS = true;
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('TDS not yet applied for this vouno - " + i + "')", true);
                            return;
                        }
                    }
                    else if (ddl_voucher.SelectedItem.Text == "Admin Purchase Invoice")
                    {
                        if (Obj_Invoice.CheckTDSApplyORNot("S", i, Vouyear, Convert.ToInt32(Session["LoginBranchid"].ToString())) == 0)
                        {
                            blrTDS = true;
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('TDS not yet applied for this vouno - " + i + "')", true);
                            return;
                        }
                    }
                    else if (ddl_voucher.SelectedItem.Text == "Credit Note - Others")
                    {
                        if (Obj_Invoice.CheckTDSApplyORNot("E", i, Vouyear, Convert.ToInt32(Session["LoginBranchid"].ToString())) == 0)
                        {
                            blrTDS = true;
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('TDS not yet applied for this vouno - " + i + "')", true);
                            return;
                        }
                    }

                    logix.CommanClass.TallyEDIFA.Fn_FATransfer(ddl_voucher.SelectedItem.Text, a, b, ddlnarration, ddlreference, bid, "", 0, 0, "");
                }
            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Transferred Successfully...');", true);
            ddl_referen.SelectedIndex = -1;
            ddl_narration.SelectedIndex = -1;
            txt_from.Text = "";
            txt_month.Text = "";
            txt_to.Text = "";
        }            

        protected void ddl_voucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_voucher.SelectedItem.ToString() == "Admin Purchase Invoice" || ddl_voucher.SelectedItem.ToString() == "Admin Sales Invoice")
            {               
                ddl_narration.Items.Clear();
                ddl_narration.Items.Add("Remarks");              
                ddl_narration.Enabled = false;

                ddl_referen.Items.Clear();
                ddl_referen.Items.Add("Ref No");                
                ddl_referen.Enabled = false;
                txt_month.Enabled = false;
            }

            if (ddl_voucher.SelectedItem.ToString() == "Cash Receipt" || ddl_voucher.SelectedItem.ToString() == "Bank Receipt" || ddl_voucher.SelectedItem.ToString() == "Cash Payment" || ddl_voucher.SelectedItem.ToString() == "Bank Payment" || ddl_voucher.SelectedItem.ToString() == "Remittance-Receipt" || ddl_voucher.SelectedItem.ToString() == "Remittance-Payment" || ddl_voucher.SelectedItem.ToString() == "BRG")
            {
                ddl_referen.Items.Clear();
                ddl_narration.Items.Clear();
                ddl_narration.Enabled = false;
                ddl_referen.Enabled = false;
                txt_to.Enabled = true;
                txt_month.Enabled = false;
                lbl_from.Text = "From";
            }
            else if (ddl_voucher.SelectedItem.ToString() == "Bank Deposit - Transfer To CO" || ddl_voucher.SelectedItem.ToString() == "Cash Deposit - Transfer To CO")
            {
              
                ddl_referen.Items.Clear();
                ddl_narration.Items.Clear();
                ddl_narration.Enabled = false;
                ddl_referen.Enabled = false;
                txt_to.Enabled = false;              
                txt_month.Enabled = false;
                lbl_from.Text = "Slip #";
            }
            else if (ddl_voucher.SelectedItem.ToString() == "Journal")
            {
                txt_month.Enabled = true;
            }
            else
            {               
                ddl_narration.Enabled = true;
                ddl_referen.Enabled = true;
                lbl_from.Text = "From";
                txt_to.Enabled = true;
                txt_month.Enabled = false;
            }
        }
    }
}