using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.BT
{
    public partial class BtProInvoice : System.Web.UI.Page
    {
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.Accounts.ProfomaInvoice proinvobj = new DataAccess.Accounts.ProfomaInvoice();
        DataTable DtInfo = new DataTable();
        DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
        DataAccess.BondedTrucking.BTInvoice BTINVOICEobj = new DataAccess.BondedTrucking.BTInvoice();
        int divisionid, branchid, logempid, intcustid, custid, refno, cityid, approvedby;
        string strTranType, gbl, frmname, extype, blno, cust, fatransfer = "", billtype, strbase, strvolume, chargename, cbase, oldbase, city;
        DateTime dtdate, voudate;
        Boolean blnerr;
        double intrate, intexrate, famount, amount, oldamount, unit = 0;
        string str_Uiid = "", str_FornName;
        int chargeid; int checkcustid;
        DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        Boolean bolcuststat;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);

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
                lbl_Header.Text = Request.QueryString["type"].ToString();
                strTranType = Session["StrTranType"].ToString();
                header.InnerText = lbl_Header.Text;
                divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                branchid = int.Parse(Session["LoginBranchid"].ToString());
                if (!this.IsPostBack)
                {
                    txtdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());

                    //strTranType = gbl;

                    //cmbbill.Items.Clear();
                    //cmbbill.Items.Add("Cash/Cheque");
                    //cmbbill.Items.Add("Credit");
                    //cmbbill.Items.Add("Internal");




                    cmbbill.Items.Clear();
                    cmbbill.Items.Add("");
                    cmbbill.Items.Add("Cash/Cheque");
                    cmbbill.Items.Add("Credit");
                    cmbbill.Items.Add("Internal");
                    // cmbbill.Items.Add("Service Tax Exemption");



                    //if (Convert.ToDateTime(Logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                    //{

                    //    cmbbill.Items.Add("Cash/Cheque");
                    //    cmbbill.Items.Add("Credit");

                    //}
                    //else
                    //{

                    //    cmbbill.Items.Add("Cash/Cheque");
                    //    cmbbill.Items.Add("Credit");
                    //    cmbbill.Items.Add("Internal");
                    //}


                    cmbbase.Items.Clear();
                    cmbbase.Items.Add("");
                    cmbbase.Items.Add("CBM");
                    cmbbase.Items.Add("Kgs");
                    cmbbase.Items.Add("Truck");
                    dtdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtdate.Text));
                    btnadd.Enabled = false;
                    txtblno.Focus();
                    //btncancel.Text = "Back";

                    btncancel.ToolTip = "Back";
                    btn_back1.Attributes["class"] = "btn ico-back";

                    if (Logobj.GetDate().Month < 4)
                    {
                        txtvouyear.Text = (Logobj.GetDate().Year - 1).ToString();
                    }
                    else
                    {
                        txtvouyear.Text = Logobj.GetDate().Year.ToString();
                    }
                    if (lbl_Header.Text == "Profoma Invoice")
                    {
                        frmname = "Profoma Invoice";
                        extype = "R";
                        hid_Exrate.Value = extype;
                        pnlContlist.Attributes["class"] = "lst_contN3";
                    }
                    else
                    {
                        frmname = "Profoma Payment Advise";
                        extype = "C";
                        hid_Exrate.Value = extype;
                        txtVendorref.Visible = true;
                        pnlContlist.Attributes["class"] = "lst_contN2";
                        //pnlContlist.Attributes["class"] = "lst_contN2";
                    }
                    grd.DataSource = Utility.Fn_GetEmptyDataTable();
                    grd.DataBind();
                    txttruck.Focus();
                    UserRights();

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


        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {
                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btnsave, btnview, btndelete);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }


        public void CheckData()
        {
            if (txtblno.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job # cannot be blank');", true);
                txtblno.Focus();
                blnerr = true;
                return;
            }
            if (txtto.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Customer Name cannot be blank');", true);
                txtto.Focus();
                blnerr = true;
                return;
            }
            else
            {
                intcustid = customerobj.GetCustomerid(txtto.Text, portobj.GetPortname(Convert.ToInt32(hdncityid.Value)));
                //checkcustid = customerobj.GetCustomerid(txtto.Text);
                if (intcustid == 0)
                {
                    ScriptManager.RegisterStartupScript(txtto, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Select Correct Customer Name');", true);
                    txtto.Text = "";
                    txtto.Focus();
                    return;
                }
            }

        }

        [WebMethod]
        public static List<string> GetToCust(string prefix)
        {
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataTable Dt = new DataTable();
            List<string> custname = new List<string>();
            Dt = customerobj.GetLikeCustomer(prefix);
            custname = Utility.Fn_DatatableToList_int16DisplayNew(Dt, "customer", "customerid", "city", "address");
            return custname;
        }

        [WebMethod]
        public static List<string> Gettruck(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.BondedTrucking.BTJobInfo BTJobInfoobj = new DataAccess.BondedTrucking.BTJobInfo();
            DataTable Dt1 = new DataTable();
            Dt1 = BTJobInfoobj.GetLikeBTSBNo(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            List_Result = Utility.Fn_DatatableToList_Text(Dt1, "sbno");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetCharges(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
            DataTable dtCharge = new DataTable();
            dtCharge = chargeobj.GetLikeCharges(prefix);
            List_Result = Utility.Fn_TableToList(dtCharge, "chargename", "chargeid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetLikeCurrency(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
            DataTable dtCharge = new DataTable();
            dtCharge = chargeobj.GetLikeCurrency(prefix);
            List_Result = Utility.Fn_TableToList(dtCharge, "currency", "currency");
            return List_Result;
        }

        protected void txttruck_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.BondedTrucking.BTJobInfo BTJobInfoobj = new DataAccess.BondedTrucking.BTJobInfo();
                DataTable Dt2 = new DataTable();
                divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                branchid = int.Parse(Session["LoginBranchid"].ToString());

                if (txttruck.Text.Trim() != "")
                {
                    Dt2 = BTJobInfoobj.GetBTJobInfoFSBNo(txttruck.Text.Trim(), branchid, divisionid);
                    if (Dt2.Rows.Count > 0)
                    {
                        txtto.Text = Dt2.Rows[0]["customername"].ToString();
                        txtblno.Text = Dt2.Rows[0]["jobno"].ToString();
                        intcustid = int.Parse(Dt2.Rows[0]["customer"].ToString());
                        txtfromport.Text = Dt2.Rows[0]["fromport"].ToString();
                        txttoport.Text = Dt2.Rows[0]["toport"].ToString();
                        txtetd.Text = Dt2.Rows[0]["etd"].ToString();
                        txteta.Text = Dt2.Rows[0]["eta"].ToString();
                       // btncancel.Text = "Cancel";

                        btncancel.ToolTip = "Cancel";
                        btn_back1.Attributes["class"] = "btn ico-cancel";
                    }
                    else
                    {
                        txtclear();
                    }
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtto_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DataTable DtSHead = new DataTable();
                divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                branchid = int.Parse(Session["LoginBranchid"].ToString());
                int int_custid;
                DataTable dt_list = new DataTable();
                if (txtinv.Text == "")
                {
                    if (txtto.Text == "")
                    {
                    }
                    else
                    {

                        int_custid = Convert.ToInt32(hdncustid.Value);
                        if (int_custid != 0)
                        {
                            if (lbl_Header.Text == "Profoma Invoice")
                            {
                                dt_list = customerobj.GetIndianCustomergst(int_custid);
                                if (dt_list.Rows.Count > 0)
                                {
                                    if (string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()) || string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                                    {
                                        if (!string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                                        {
                                            // txtaddress.Text += System.Environment.NewLine + "GSTIN #:" + dt_list.Rows[0]["gstin"].ToString();

                                            ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alertify.alert('please  update  Uinno#  Master Customer);", true);
                                        }
                                        else if (!string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                                        {
                                            // txtaddress.Text += System.Environment.NewLine + "UIN #:" + dt_list.Rows[0]["uinno"].ToString();

                                            ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin# Master Customer');", true);
                                        }
                                        else if (dt_list.Rows[0]["UnRegistered"].ToString() == "N" && dt_list.Rows[0]["uinno"].ToString() == "" && dt_list.Rows[0]["gstin"].ToString() == "")
                                        {
                                            ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  OR  Select UnRegistered  Master Customer');", true);
                                        }

                                      //  ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                                    }
                                    else
                                    {
                                        // txtaddress.Text += System.Environment.NewLine + dt_list.Rows[0]["Column1"].ToString();
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                                    return;
                                }

                            }
                        }

                        intcustid = customerobj.GetCustomerid(txtto.Text, portobj.GetPortname(hdncityid.Value));
                        checkcustid = customerobj.GetCustomerid(txtto.Text);




                        if (checkcustid == 0)
                        {
                            ScriptManager.RegisterStartupScript(txtto, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Select Correct Customer Name');", true);
                            txtto.Text = "";
                            txtto.Focus();
                            return;
                        }
                        if (lbl_Header.Text == "Profoma Invoice")
                        {
                            DtSHead = proinvobj.CheckProinvCustblno(txttruck.Text, intcustid, strTranType, branchid, int.Parse(txtvouyear.Text), "Profoma Invoice");
                        }
                        else
                        {
                            DtSHead = proinvobj.CheckProinvCustblno(txttruck.Text, intcustid, strTranType, branchid, int.Parse(txtvouyear.Text), "Profoma Payment Advise");
                        }

                        txtcharge.Enabled = true;
                        cmbbase.Enabled = true;
                       // btncancel.Text = "Cancel";

                        btncancel.ToolTip = "Cancel";
                        btn_back1.Attributes["class"] = "btn ico-cancel";

                        //txtTotal.Text = 0;
                        for (int i = 0; i < grd.Rows.Count - 1; i++)
                        {
                            txtTotal.Text = string.Format((txtTotal.Text) + grd.Rows[i].Cells[5].Text, "0.00");
                        }
                        if (fatransfer != "")
                        {
                            ScriptManager.RegisterStartupScript(txtto, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Cannot Be Amend');", true);
                            btnsave.Enabled = false;
                            btnsave.Visible = false;
                            btnadd.Visible = false;
                            grd.Enabled = true;
                        }

                        if (DtSHead.Rows.Count != 0)
                        {
                            if (lbl_Header.Text == " Invoice")
                            {
                                blno = DtSHead.Rows[0][3].ToString();
                                custid = int.Parse(DtSHead.Rows[0][4].ToString());
                            }
                            else
                            {
                                blno = DtSHead.Rows[0][3].ToString();
                                custid = int.Parse(DtSHead.Rows[0][4].ToString());
                            }
                            cust = customerobj.GetCustomername(custid);
                            if (txtblno.Text == blno && txtto.Text == cust)
                            {
                                Session["DtSHead"] = DtSHead;
                                this.popupconfirm.Show();
                                return;
                            }
                            else
                            {
                              //  btnsave.Text = "Save";
                                btnsave.ToolTip = "Save";
                                btn_save1.Attributes["class"] = "btn ico-save";

                            }
                        }
                        else
                        {
                            grd.DataSource = new DataTable();
                            grd.DataBind();
                            txtinv.Text = "";
                            txtremarks.Text = "";
                        }
                    }
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void GrdLoad()
        {
            try
            {
                branchid = int.Parse(Session["LoginBranchid"].ToString());
                if (lbl_Header.Text == "Profoma Invoice")
                {
                    DtInfo = proinvobj.GetInvoiceDetailsforBT(int.Parse(txtinv.Text), "I", int.Parse(txtvouyear.Text), branchid);
                }
                else
                {
                    DtInfo = proinvobj.GetInvoiceDetailsforBT(int.Parse(txtinv.Text), "P", int.Parse(txtvouyear.Text), branchid);
                }
                grd.DataSource = DtInfo;
                grd.DataBind();
                grd.Enabled = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnok_Click(object sender, EventArgs e)
        {

            txtremarks.Text = "";
            txtinv.Text = "";
            grd.DataSource = new DataTable();
            grd.DataBind();
            btnsave.Visible = true;
            btnadd.Visible = true;
            grd.Enabled = true;
            UserRights();
            return;
        }

        protected void btncncl_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DtSHead = new DataTable();
                DtSHead = (DataTable)Session["DtSHead"];
                if (lbl_Header.Text == "Profoma Invoice")
                {
                    txtinv.Text = DtSHead.Rows[0][0].ToString();
                    txtremarks.Text = DtSHead.Rows[0][7].ToString();
                    billtype = DtSHead.Rows[0][9].ToString();
                    fatransfer = DtSHead.Rows[0][10].ToString();
                    voudate = DateTime.Parse(DtSHead.Rows[0][1].ToString());
                }
                else
                {
                    txtinv.Text = DtSHead.Rows[0][0].ToString();
                    txtremarks.Text = DtSHead.Rows[0][7].ToString();
                    billtype = DtSHead.Rows[0][9].ToString();
                    fatransfer = DtSHead.Rows[0][10].ToString();
                    cmbbill.Text = INVOICEobj.GetBillType(char.Parse(billtype));
                    voudate = DateTime.Parse(DtSHead.Rows[0][1].ToString());
                    txtVendorref.Text = DtSHead.Rows[0][11].ToString();
                }
                txtdate.Text = voudate.ToShortDateString();
                cmbbill.Text = INVOICEobj.GetBillType(char.Parse(billtype));
                GrdLoad();
               // btnsave.Text = "Update";

                btnsave.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";

                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (fatransfer != "")
                {
                    return;
                }
                if (grd.Rows.Count > 0)
                {
                    string strcharge;
                    double r;
                    int index;
                    index = grd.SelectedRow.RowIndex;
                    strcharge = grd.Rows[index].Cells[0].Text;
                    if (strcharge.Length >= 5)
                    {
                        if (strcharge.Substring(0, 5) == "ST on" || strcharge.Substring(0, 5) == "EduCe" || strcharge.Substring(0, 5) == "Highe")
                        {
                            ScriptManager.RegisterStartupScript(txtto, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Cannot Modified');", true);
                            return;
                        }
                    }
                    //btnadd.Text = "Upd";

                    btnadd.ToolTip = "Upd";
                    btn_add1.Attributes["class"] = "btn btn-UpdateAdd2";

                    txtcharge.Text = grd.Rows[index].Cells[0].Text;
                    txtcurr.Text = grd.Rows[index].Cells[1].Text;
                    r = double.Parse(grd.Rows[index].Cells[2].Text);
                    txtrate.Text = string.Format(r.ToString(), "0.00");
                    r = double.Parse(grd.Rows[index].Cells[3].Text);
                    txtex.Text = string.Format(r.ToString(), "0.00");
                    cmbbase.SelectedValue = grd.Rows[index].Cells[4].Text;
                    oldbase = grd.Rows[index].Cells[4].Text;
                    hid_oldbase.Value = oldbase;
                    r = double.Parse(grd.Rows[index].Cells[7].Text);
                    txtamount.Text = string.Format(r.ToString(), "0.00");
                    oldamount = double.Parse(txtamount.Text);
                    txtcharge.Enabled = false;
                    txtcharge.BackColor = System.Drawing.Color.White;
                    txtcharge.ForeColor = System.Drawing.Color.Black;
                    btnadd.Enabled = true;
                    txtcurr.Focus();
                    txtDisable();
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void cmbbill_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbl_Header.Text == "  Invoice")
                {
                    if (cmbbill.SelectedItem.Text == "Credit")
                    {
                        txtcreditapp.Text = "";
                        txtcreditapp.Enabled = true;
                        txtcreditapp.Text = "Not Updated";
                    }
                    else
                    {
                        txtcreditapp.Text = "";
                        txtcreditapp.Enabled = false;
                    }
                }
                else
                {
                    txtcreditapp.Text = "";
                    txtcreditapp.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void cmbbase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //checkCMBBase(cmbbase);
                if (cmbbase.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Any Of One of Base...');", true);
                    return;
                }
                if (cmbbase.SelectedIndex != 0 && txtcharge.Text != "" && txtcurr.Text != "" && txtrate.Text != "")
                {
                    intcustid = customerobj.GetCustomerid(txtto.Text);
                    strbase = cmbbase.Text;
                    intrate = Convert.ToDouble(txtrate.Text);
                    intexrate = Convert.ToDouble(txtex.Text);
                    famount = CheckBase(strbase, intrate, intexrate);
                    txtamount.Text = famount.ToString();
                    txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
                    btnadd.Focus();
                }
                if (fatransfer != "")
                {
                    grd.Enabled = true;
                    btnsave.Enabled = false;
                    btnadd.Enabled = false;
                } UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public double CheckBase(string strbase, double rate, double exrate)
        {
            try
            {
                divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                branchid = int.Parse(Session["LoginBranchid"].ToString());
                if (cmbbase.Text.ToUpper() == "Truck".ToUpper())
                {
                    amount = rate * exrate;
                    hdnUnit.Value = "1";
                }
                else if (cmbbase.Text.ToUpper() == "CBM".ToUpper() || cmbbase.Text.ToUpper() == "KGS".ToUpper())
                {
                    if (cmbbase.Text.ToUpper() == "CBM".ToUpper())
                    {
                        strvolume = BTINVOICEobj.GetVolumeFSBNo(txttruck.Text, intcustid, branchid, divisionid, int.Parse(txtblno.Text)).ToString();
                        amount = rate * exrate * double.Parse(strvolume);
                        hdnUnit.Value = strvolume;
                    }
                    else
                    {
                        strvolume = BTINVOICEobj.GetWeightFSBNo(txttruck.Text, intcustid, branchid, divisionid, int.Parse(txtblno.Text)).ToString();
                        if (double.Parse(strvolume) < 1)
                        {
                            amount = rate * exrate * 1;
                            hdnUnit.Value = "1";
                        }
                        else
                        {
                            amount = rate * exrate * double.Parse(strvolume);
                            hdnUnit.Value = strvolume;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            return amount;
        }

        protected void txtcharge_TextChanged(object sender, EventArgs e)
        {
            try
            {
                chargeid = int.Parse(chargeobj.GetChargeid(txtcharge.Text).ToString());
                hdnChargid.Value = chargeid.ToString();

                if (chargeid == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('INVALID CHARGE NAME');", true);
                    txtcharge.Focus();
                    txtcharge.Text = "";
                    blnerr = true;
                    return;
                }
                else
                {
                    btnadd.Enabled = true;
                }
                txtcurr.Focus();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
         //   btncancel.Text = "Cancel";

            btncancel.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtcurr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (chargeobj.GetCurrID(txtcurr.Text.Trim()) == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Currency');", true);
                    txtcurr.Focus();
                    blnerr = true;
                    return;
                }
                else
                {
                    txtcurr.Text = txtcurr.Text.ToUpper();
                    txtrate.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                logempid = int.Parse(Session["LoginEmpId"].ToString());
                divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                branchid = int.Parse(Session["LoginBranchid"].ToString());

                if (txtinv.Text != "")
                {
                    CheckChargeData();
                    if (blnerr == true)
                    {
                        blnerr = false;
                        return;
                    }

                    if (txtcharge.Text != "")
                    {
                        string strcharge;
                        strcharge = txtcharge.Text;
                        if (strcharge.Length >= 5)
                        {
                            if (strcharge.Substring(0, 5) == "ST on" || strcharge.Substring(0, 5) == "EduCe" || strcharge.Substring(0, 5) == "Highe")
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Cannot Access the Charge');", true);
                                txtcharge.Focus();
                                return;
                            }
                        }
                        DataTable dtchargeadd = new DataTable();
                        dtchargeadd = INVOICEobj.GetCheckApprovedProfoma(int.Parse(txtinv.Text), branchid, int.Parse(txtvouyear.Text), Session["StrTranType"].ToString(), lbl_Header.Text, "Charge");
                        if (dtchargeadd.Rows.Count > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Cant Change the Charges after Approved');", true);
                            return;
                        }
                        hdnChargid.Value = chargeobj.GetChargeid(txtcharge.Text).ToString();
                        int chargeid = int.Parse(hdnChargid.Value);
                        //int intcustid = int.Parse(hdncustid.Value);
                        if (lbl_Header.Text == "Profoma Invoice")
                        {
                            ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                            if (bolcuststat == true)
                            {
                                bolcuststat = false;
                                return;
                            }
                        }
                        else
                        {
                            if (txtsupplyto.Text == "")
                            {
                                hid_SupplyTo.Value = hdncustid.Value;

                                txtsupplyto.Text = txtto.Text;
                                txtsupplyto_TextChanged(sender, e);
                            }

                        }

                        if (btnadd.ToolTip == "Add")
                        {
                            CheckChargeBase();
                           // string servicetax = "";
                            if (int.Parse(chargename) > 0 && int.Parse(cbase) > 0)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Exist');", true);
                                txtcharge.Focus();
                                return;
                            }
                            else
                            {
                                if (lbl_Header.Text == "Profoma Invoice")
                                {
                                    if (cmbbill.Text != "Internal")
                                    {
                                        proinvobj.InsertBTProInvDetails(int.Parse(txtinv.Text), chargeid, txtcurr.Text, double.Parse(txtrate.Text), double.Parse(txtex.Text), cmbbase.Text, double.Parse(txtamount.Text), branchid, intcustid, int.Parse(txtvouyear.Text), "C", strTranType, "Profoma Invoice","Y", double.Parse(hdnUnit.Value));
                                    }
                                    else
                                    {
                                        proinvobj.InsertBTProInvDetails(int.Parse(txtinv.Text), chargeid, txtcurr.Text, double.Parse(txtrate.Text), double.Parse(txtex.Text), cmbbase.Text, double.Parse(txtamount.Text), branchid, intcustid, int.Parse(txtvouyear.Text), "I", strTranType, "Profoma Invoice", "Y", double.Parse(hdnUnit.Value));
                                    }
                                }
                                else
                                {
                                    if (cmbbill.Text != "Internal")
                                    {
                                        this.PopUpService.Show();
                                        return;
                                    }
                                    else
                                    {
                                        proinvobj.InsertBTProInvDetails(int.Parse(txtinv.Text), chargeid, txtcurr.Text, double.Parse(txtrate.Text), double.Parse(txtex.Text), cmbbase.Text, double.Parse(txtamount.Text), branchid, intcustid, int.Parse(txtvouyear.Text), "N", strTranType, "Profoma Payment Advise","Y",double.Parse(hdnUnit.Value));
                                    }
                                }
                            }
                            chargetxtclear();
                            GrdLoad();
                        }
                        else
                        {
                            if (hid_oldbase.Value != "")
                            {
                                oldbase = hid_oldbase.Value;
                            }
                            if (txtcharge.Text != "" && txtrate.Text != "" && txtex.Text != "" && txtcurr.Text != "" && cmbbase.Text != "" && txtamount.Text != "")
                            {
                              //  CheckBase(cmbbase.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text));
                                if (lbl_Header.Text == "Profoma Invoice")
                                {
                                    if (cmbbill.Text != "Internal")
                                    {
                                        proinvobj.UpdateDetailsforBT(Convert.ToInt32(txtinv.Text), chargeid, txtcurr.Text, double.Parse(txtrate.Text), double.Parse(txtex.Text), cmbbase.Text, double.Parse(txtamount.Text), "I", oldbase, Convert.ToInt32(txtvouyear.Text), branchid, strTranType, double.Parse(hdnUnit.Value), "Y", "Profoma Invoice");
                                    }
                                    else
                                    {
                                        proinvobj.UpdateDetailsforBT(Convert.ToInt32(txtinv.Text), chargeid, txtcurr.Text, double.Parse(txtrate.Text), double.Parse(txtex.Text), cmbbase.Text, double.Parse(txtamount.Text), "I", oldbase, Convert.ToInt32(txtvouyear.Text), branchid, strTranType, double.Parse(hdnUnit.Value), "Y", "Profoma Invoice");
                                    }
                                }
                                else
                                {
                                    if (cmbbill.Text != "Internal")
                                    {
                                        this.PopUpService.Show();
                                        return;
                                    }
                                    else
                                    {
                                        proinvobj.UpdateDetailsforBT(int.Parse(txtinv.Text), chargeid, txtcurr.Text, double.Parse(txtrate.Text), double.Parse(txtex.Text), cmbbase.Text, double.Parse(txtamount.Text), "P", oldbase, int.Parse(txtvouyear.Text), branchid, strTranType, double.Parse(hdnUnit.Value), "Y", "Profoma Payment Advise");
                                    }
                                }
                            }
                            chargetxtclear();
                            GrdLoad();
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Save the Voucher Head then add the charges');", true);
                    btnsave.Focus();
                    return;
                }

                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void CheckChargeData()
        {


            if (txtcharge.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Charge Name cannot be blank ');", true);
                txtcharge.Focus();
                txtcharge.Text = "";
                blnerr = true;
                return;
            }
            else
            {
                hdnChargid.Value = "0";
                chargeid = Convert.ToInt32(hdnChargid.Value);
                chargeid = Convert.ToInt32(chargeobj.GetChargeid(txtcharge.Text).ToString());
                hdnChargid.Value = chargeid.ToString();

                if (chargeid == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('INVALID CHARGE NAME');", true);
                    txtcharge.Focus();
                    txtcharge.Text = "";
                    blnerr = true;
                    return;
                }
            }
            if (txtcurr.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Currency cannot be blank');", true);
                txtcurr.Focus();
                blnerr = true;
                return;
            }
            else
            {
                if (chargeobj.GetCurrID(txtcurr.Text.Trim()) == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Currency');", true);
                    txtcurr.Focus();
                    blnerr = true;
                    return;
                }
            }
            if (txtrate.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Rate cannot be blank');", true);
                txtrate.Focus();
                blnerr = true;
                return;
            }
            if (cmbbase.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Base');", true);
                cmbbase.Focus();
                blnerr = true;
                return;
            }
        }

        protected void btn_yes_Click(object sender, EventArgs e)
        {
            try
            {
                int chargeid = int.Parse(hdnChargid.Value);
                //int intcustid = int.Parse(hdncustid.Value);
                oldbase = hid_oldbase.Value;
                intcustid = customerobj.GetCustomerid(txtto.Text);
                string servicetax = "Y";
                if (btnadd.ToolTip == "Add")
                {
                    proinvobj.InsertBTProInvDetails(int.Parse(txtinv.Text), chargeid, txtcurr.Text, double.Parse(txtrate.Text), double.Parse(txtex.Text), cmbbase.Text, double.Parse(txtamount.Text), branchid, intcustid, int.Parse(txtvouyear.Text), "S", strTranType, "Profoma Payment Advise", servicetax,double.Parse(hdnUnit.Value));
                    bind();
                }
                else
                {
                    proinvobj.UpdateDetailsforBT(int.Parse(txtinv.Text), chargeid, txtcurr.Text, double.Parse(txtrate.Text), double.Parse(txtex.Text), cmbbase.Text, double.Parse(txtamount.Text), "P", oldbase, int.Parse(txtvouyear.Text), branchid, strTranType, double.Parse(hdnUnit.Value), servicetax, "Profoma Invoice");
                    bind();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void bind()
        {
            try
            {
                chargetxtclear();
                GrdLoad();
            //    btnadd.Text = "Add";
                btnadd.ToolTip = "Add";
                btn_add1.Attributes["class"] = "btn btn-add1";

                btnadd.Enabled = false;
                grd.Focus();
                txtcharge.Focus();
                double amt = 0;
                txtTotal.Text = "0";
                for (int i = 0; i <= grd.Rows.Count - 1; i++)
                {


                    if (string.IsNullOrEmpty(grd.Rows[i].Cells[7].Text) != true)
                    {
                        amt = amt + Convert.ToDouble(grd.Rows[i].Cells[7].Text);
                    }
                    else
                    {
                        amt = amt + 0;
                    }


                }
                txtTotal.Text = amt.ToString("#0.00");

                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void CheckChargeBase()
        {
            try
            {
                //int chargeid = int.Parse(hdnChargid.Value);
                chargeid = int.Parse(chargeobj.GetChargeid(txtcharge.Text).ToString());
                divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                branchid = int.Parse(Session["LoginBranchid"].ToString());
                hdnChargid.Value = chargeid.ToString();

                if (txtcharge.Text == "")
                {
                }
                else
                {
                    if (lbl_Header.Text == "Profoma Invoice")
                    {
                        chargename = proinvobj.GetBTProBaseCharges(int.Parse(txtinv.Text), cmbbase.Text, chargeid, "Profoma Invoice", int.Parse(txtvouyear.Text), branchid, "Charges").ToString();
                        cbase = proinvobj.GetBTProBaseCharges(int.Parse(txtinv.Text), cmbbase.Text, chargeid, "Profoma Invoice", int.Parse(txtvouyear.Text), branchid, "Base").ToString();
                    }
                    else
                    {
                        chargename = proinvobj.GetBTProBaseCharges(int.Parse(txtinv.Text), cmbbase.Text, chargeid, "Profoma Payment Advise", int.Parse(txtvouyear.Text), branchid, "Charges").ToString();
                        cbase = proinvobj.GetBTProBaseCharges(int.Parse(txtinv.Text), cmbbase.Text, chargeid, "Profoma Payment Advise", int.Parse(txtvouyear.Text), branchid, "Base").ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_no_Click(object sender, EventArgs e)
        {
            try
            {
                int chargeid = int.Parse(hdnChargid.Value);
                //int intcustid = int.Parse(hdncustid.Value);
                intcustid = customerobj.GetCustomerid(txtto.Text);
                oldbase = hid_oldbase.Value;
                string servicetax = "N";
                if (btnadd.ToolTip == "Add")
                {
                    proinvobj.InsertBTProInvDetails(int.Parse(txtinv.Text), chargeid, txtcurr.Text, double.Parse(txtrate.Text), double.Parse(txtex.Text), cmbbase.Text, double.Parse(txtamount.Text), branchid, intcustid, int.Parse(txtvouyear.Text), "N", strTranType, "Profoma Payment Advise",servicetax,double.Parse(hdnUnit.Value));
                    bind();
                }
                else
                {
                    proinvobj.UpdateDetailsforBT(int.Parse(txtinv.Text), chargeid, txtcurr.Text, double.Parse(txtrate.Text), double.Parse(txtex.Text), cmbbase.Text, double.Parse(txtamount.Text), "P", oldbase, int.Parse(txtvouyear.Text), branchid, strTranType, double.Parse(hdnUnit.Value), servicetax, "Profoma Invoice");
                    bind();
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                logempid = int.Parse(Session["LoginEmpId"].ToString());
                divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                branchid = int.Parse(Session["LoginBranchid"].ToString());
                dtdate = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate.Text));
                if (lbl_Header.Text == "Profoma Invoice")
                {
                    if (txtsupplyto.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter Supply From ');", true);
                        bolcuststat = false;
                        return;
                    }
                    else
                    {
                        ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                        if (bolcuststat == true)
                        {
                            bolcuststat = false;
                            return;
                        }
                    }
                }

                else
                {
                    if (txtsupplyto.Text == "")
                    {
                        hid_SupplyTo.Value = hdncustid.Value;

                        txtsupplyto.Text = txtto.Text;
                        txtsupplyto_TextChanged(sender, e);
                    }

                }

                if (btnsave.ToolTip == "Save")
                {
                    if (txtinv.Text != "")
                    {
                        return;
                    }
                    CheckData();
                    if (blnerr == true)
                    {
                        blnerr = false;
                        return;
                    }
                    if (lbl_Header.Text == "Profoma Invoice")
                    {
                        refno = proinvobj.InsertBTProfomaHead(dtdate, strTranType, Convert.ToInt32(txtblno.Text), intcustid, txttruck.Text.ToUpper(), txtremarks.Text.ToUpper(), branchid, cmbbill.Text, logempid, Convert.ToInt32(txtvouyear.Text), "", "Profoma Invoice", Convert.ToInt32(hid_SupplyTo.Value));
                        txtinv.Text = refno.ToString();
                        Logobj.InsLogDetail(logempid, 1052, 1, branchid, txtinv.Text);
                        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Saved');", true);
                    }
                    else
                    {
                        refno = proinvobj.InsertBTProfomaHead(dtdate, strTranType, Convert.ToInt32(txtblno.Text), intcustid, txttruck.Text.ToUpper(), txtremarks.Text.ToUpper(), branchid, cmbbill.Text, logempid, Convert.ToInt32(txtvouyear.Text), txtVendorref.Text.ToUpper(), "Profoma Payment Advise", Convert.ToInt32(hid_SupplyTo.Value));
                        txtinv.Text = refno.ToString();
                        Logobj.InsLogDetail(logempid, 1053, 1, branchid, txtinv.Text);
                        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Saved');", true);
                    }
                }
                else
                {
                    CheckData();
                    if (blnerr == true)
                    {
                        blnerr = false;
                        return;
                    }
                    DataTable dtcheck = new DataTable();
                    dtcheck = INVOICEobj.GetCheckApprovedProfoma(Convert.ToInt32(txtinv.Text), branchid, Convert.ToInt32(txtvouyear.Text), strTranType, lbl_Header.Text, "HeadUpdate");
                    if (dtcheck.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Update Denied, Already Approved');", true);
                        return;
                    }
                    if (lbl_Header.Text == "Profoma Invoice")
                    {
                        proinvobj.UpdateBTProfomaHead(Convert.ToInt32(txtinv.Text), intcustid, txtremarks.Text.ToUpper(), cmbbill.Text, logempid, Convert.ToInt32(txtvouyear.Text), branchid, strTranType, "", "Profoma Invoice", Convert.ToInt32(hid_SupplyTo.Value));
                        if (hid_SupplyTonew.Value != hid_SupplyTo.Value)
                        {

                            proinvobj.UpdChargesGST4OldVou(Convert.ToInt32(txtinv.Text), branchid, Convert.ToInt32(txtvouyear.Text), "Profoma Invoice");
                            hid_SupplyTonew.Value = hid_SupplyTo.Value;


                        }
                        Logobj.InsLogDetail(logempid, 1052, 2, branchid, txtinv.Text);
                        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated');", true);
                    }
                    else
                    {
                        proinvobj.UpdateBTProfomaHead(int.Parse(txtinv.Text), intcustid, txtremarks.Text.ToUpper(), cmbbill.Text, logempid, Convert.ToInt32(txtvouyear.Text), branchid, strTranType, txtVendorref.Text.ToUpper(), "Profoma Payment Advise", Convert.ToInt32(hid_SupplyTo.Value));
                        if (hid_SupplyTonew.Value != hid_SupplyTo.Value)
                        {

                            proinvobj.UpdChargesGST4OldVou(Convert.ToInt32(txtinv.Text), branchid, Convert.ToInt32(txtvouyear.Text), "Profoma Payment Advise");
                            hid_SupplyTonew.Value = hid_SupplyTo.Value;


                        }
                        Logobj.InsLogDetail(logempid, 1053, 2, branchid, txtinv.Text);
                        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated');", true);
                    }
                }
                txtDisable();
                btnadd.Enabled = true;
                txtcharge.Focus();
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void txtDisable()
        {
            cmbbill.Enabled = false;
            txtblno.Enabled = false;
            txttruck.Enabled = false;
            txteta.Enabled = false;
            txtto.Enabled = false;
            txtinv.Enabled = false;
            txtvouyear.Enabled = false;
            txtetd.Enabled = false;
            txtfromport.Enabled = false;
            txttoport.Enabled = false;
            txtremarks.Enabled = false;
            lstcon.Enabled = false;
            UserRights();
        }

        public void txtEnable()
        {
            cmbbill.Enabled = true;
            txtblno.Enabled = true;
            txttruck.Enabled = true;
            txteta.Enabled = true;
            txtto.Enabled = true;
            txtinv.Enabled = true;
            txtvouyear.Enabled = true;
            txtetd.Enabled = true;
            txtfromport.Enabled = true;
            txttoport.Enabled = true;
            txtremarks.Enabled = true;
            lstcon.Enabled = true;
            UserRights();
        }

        public void txtclear()
        {
            cmbbill.SelectedIndex = 0;
            txtblno.Text = "";
            txttruck.Text = "";
            txteta.Text = "";
            txtto.Text = "";
            txtinv.Text = "";
            txtetd.Text = "";
            txtfromport.Text = "";
            txttoport.Text = "";
            txtremarks.Text = "";
            lstcon.Items.Clear();
            grd.DataSource = new DataTable();
            grd.DataBind();
            txttruck.Focus();
            btnsave.Visible = true;
            btnadd.Visible = true;
            grd.Enabled = true;
            txtdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
            if (Logobj.GetDate().Month < 4)
            {
                txtvouyear.Text = (Logobj.GetDate().Year - 1).ToString();
            }
            else
            {
                txtvouyear.Text = Logobj.GetDate().Year.ToString();
            }
            UserRights();
        }

        public void chargetxtclear()
        {
            txtcharge.Text = "";
            txtcurr.Text = "";
            txtrate.Text = "";
            txtex.Text = "";
            cmbbase.SelectedIndex = 0;
            txtamount.Text = "";
            //btnadd.Text = "Add";

            btnadd.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn btn-add1";
            txtcharge.Enabled = true;
            cmbbase.Enabled = true;
        }

        protected void txtinv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtinv.Text != "")
                {
                    string vtype = "";
                    divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                    branchid = int.Parse(Session["LoginBranchid"].ToString());
                    DataTable DtSHead, Dt = new DataTable();
                    DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
                    DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
                    DataAccess.BondedTrucking.BTJobInfo BTJobInfoobj = new DataAccess.BondedTrucking.BTJobInfo();

                    if (lbl_Header.Text == "Profoma Invoice")
                    {
                        vtype = "I";
                        DtSHead = proinvobj.SelProInvHead(int.Parse(txtinv.Text), strTranType, int.Parse(txtvouyear.Text), branchid, "Profoma Invoice");
                    }
                    else
                    {
                        vtype = "P";
                        DtSHead = proinvobj.SelProInvHead(int.Parse(txtinv.Text), strTranType, int.Parse(txtvouyear.Text), branchid, "Profoma Payment Advise");
                    }
                    if (DtSHead.Rows.Count > 0)
                    {
                        txtblno.Text = DtSHead.Rows[0][3].ToString();
                        custid = int.Parse(DtSHead.Rows[0][4].ToString());
                        intcustid = custid;
                        txtto.Text = customerobj.GetCustomername(custid);
                        city = customerobj.GetCustlocation(custid);
                        cityid = portobj.GetNPortid(city);
                        txttruck.Text = DtSHead.Rows[0][5].ToString();
                        approvedby = int.Parse(DtSHead.Rows[0][7].ToString());
                        txtremarks.Text = DtSHead.Rows[0][10].ToString();
                        //if (DtSHead.Rows[0]["billtype"].ToString()!="")
                        //{

                        //    cmbbill.SelectedValue = DtSHead.Rows[0]["billtype"].ToString();
                        //}
                        //else
                        //{
                        //    cmbbill.SelectedIndex = 0;
                        //}
                       
                        fatransfer = DtSHead.Rows[0][9].ToString();
                        //cmbbill.Text = INVOICEobj.GetBillType(char.Parse(billtype));
                        // txtdate.Text = Utility.fn_ConvertDate(DtSHead.Rows[0][1].ToString());
                        txtdate.Text = DtSHead.Rows[0][1].ToString();

                        if (!string.IsNullOrEmpty(DtSHead.Rows[0]["SupplyTo"].ToString()))
                        {
                            hid_SupplyTo.Value = DtSHead.Rows[0]["SupplyTo"].ToString();
                            hid_SupplyTonew.Value = DtSHead.Rows[0]["SupplyTo"].ToString();
                        }
                        if (!string.IsNullOrEmpty(DtSHead.Rows[0]["SupplyToName"].ToString()))
                        {
                            txtsupplyto.Text = DtSHead.Rows[0]["SupplyToName"].ToString();
                            // txtsupplytoAddress.Text = customerobj.GetCustomerAddress(Convert.ToInt32(hid_SupplyTo.Value));


                            string citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));

                        }

                        string bill = DtSHead.Rows[0]["billtype"].ToString();

                        if (bill == "Cash/Cheque")
                        {
                            cmbbill.SelectedIndex = 1;
                        }
                        else if (bill == "Credit")
                        {
                            cmbbill.SelectedIndex = 2;
                        }
                        else if (bill == "Internal")
                        {
                            cmbbill.SelectedIndex = 3;
                        }

                        else if (bill == "--BILLTYPE--")
                        {
                            cmbbill.SelectedIndex = 0;
                        }
                        //if (Convert.ToDateTime(Logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                        //{
                        //    if (bill == "Cash/Cheque")
                        //    {
                        //        cmbbill.SelectedIndex = 1;
                        //    }
                        //    else if (bill == "Credit")
                        //    {
                        //        cmbbill.SelectedIndex = 2;
                        //    }

                        //    else if (bill == "--BILLTYPE--")
                        //    {
                        //        cmbbill.SelectedIndex = 0;
                        //    }
                        //}
                        //else
                        //{
                        //    if (bill == "Cash/Cheque")
                        //    {
                        //        cmbbill.SelectedIndex = 1;
                        //    }
                        //    else if (bill == "Credit")
                        //    {
                        //        cmbbill.SelectedIndex = 2;
                        //    }
                        //    else if (bill == "Internal")
                        //    {
                        //        cmbbill.SelectedIndex = 3;
                        //    }

                        //    else if (bill == "--BILLTYPE--")
                        //    {
                        //        cmbbill.SelectedIndex = 0;
                        //    }
                        //}



                        if (lbl_Header.Text == "Profoma Payment Advise")
                        {
                            txtVendorref.Text = DtSHead.Rows[0]["vendorrefno"].ToString();
                        }
                        if (txtblno.Text != "0")
                        {
                            Dt = BTJobInfoobj.GetBTJobInfo(Convert.ToInt32(txtblno.Text), branchid, divisionid);
                            if (Dt.Rows.Count > 0)
                            {
                                txtfromport.Text = Dt.Rows[0]["fromport"].ToString();
                                txttoport.Text = Dt.Rows[0]["toport"].ToString();
                                txteta.Text = Utility.fn_ConvertDateonly(Dt.Rows[0]["eta"].ToString());
                                txtetd.Text = Utility.fn_ConvertDateonly(Dt.Rows[0]["etd"].ToString());
                            }
                        }
                      //  btnsave.Text = "Update";
                        btnsave.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn btn-update1";


                        GrdLoad();
                      //  btncancel.Text = "Cancel";
                        btncancel.ToolTip = "Cancel";
                        btn_back1.Attributes["class"] = "btn ico-cancel";

                        txtcharge.Focus();
                    }
                    else
                    {
                        DataTable dtref = new DataTable();
                        if (lbl_Header.Text == "Profoma Invoice")
                        {
                            dtref = INVOICEobj.Getrefid(int.Parse(txtinv.Text), int.Parse(txtvouyear.Text), branchid, "Profoma Invoice");
                        }
                        else
                        {
                            dtref = INVOICEobj.Getrefid(int.Parse(txtinv.Text), int.Parse(txtvouyear.Text), branchid, "Profoma Payment Advise");
                        }

                        if (dtref.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(txtinv, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Already Transferred');", true);
                            txtinv.Text = "";
                            txtinv.Focus();
                            txtclear();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(txtinv, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Invalid Refno');", true);
                            txtinv.Text = "";
                            txtinv.Focus();
                            txtclear();
                        }
                    }
                }
                txtcharge.Enabled = true;
                cmbbase.Enabled = true;
                double amt = 0;
                txtTotal.Text = "0";
                for (int i = 0; i <=grd.Rows.Count - 1; i++)
                {


                    if (string.IsNullOrEmpty(grd.Rows[i].Cells[7].Text) != true)
                    {
                        amt = amt + Convert.ToDouble(grd.Rows[i].Cells[7].Text);
                    }
                    else
                    {
                        amt = amt + 0;
                    }


                }
                txtTotal.Text = amt.ToString("#0.00");

                if (fatransfer != "")
                {
                    ScriptManager.RegisterStartupScript(txtinv, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Cannot Be Amended');", true);
                    grd.Enabled = true;
                    btnsave.Enabled = false;
                    btnsave.Visible = false;
                    btnadd.Visible = false;
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime get_date, GST_date;
                get_date = Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text));
                GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
                string str_sp = "", str_sf = "", str_RptName = "", str_Script = "", bltype = "", header = "";
                int divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());

                if (txtinv.Text != "")
                {
                    double total = 0;
                    if (grd.Rows.Count > 0)
                    {
                        for (int i = 0; i < grd.Rows.Count; i++)
                        {
                            total += Convert.ToDouble(grd.Rows[i].Cells[7].Text);
                        }
                        //txtTotal.Text = total.ToString();
                    }
                    if (lbl_Header.Text == "Profoma Invoice")
                    {
                        header = "Invoice";
                        str_RptName = "BTProInvoice.rpt";
                        str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.refno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + branchid + " and {ACInvoiceHead.vouyear}=" + txtvouyear.Text;
                        str_sp = "Lcurr=INR";
                        Logobj.InsLogDetail(logempid, 1052, 4, branchid, txtinv.Text);
                    }
                    else
                    {
                        header = "PA";
                        str_RptName = "BTProPA.rpt";
                        str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.refno}=" + txtinv.Text + " and {PAHead.branchid}=" + branchid + " and {PAHead.vouyear}=" + txtvouyear.Text;
                        str_sp = "Lcurr=INR";
                        Logobj.InsLogDetail(logempid, 1053, 4, branchid, txtinv.Text);
                    }
                    if (str_RptName.Length > 0)
                    {
                        if (get_date >= GST_date)
                        {
                            str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + total.ToString() + "&blno=" + txtblno.Text + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Invoice", str_Script, true);
                    }
                }
                /*else
                {
                    if (lbl_Header.Text == "Profoma Invoice")
                    {
                        str_RptName = "BTProInvoice.rpt";
                        str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.branchid}=" + branchid + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                        str_sp = "Lcurr=INR";
                        Logobj.InsLogDetail(logempid, 1052, 4, branchid, txtinv.Text);
                    }
                    else
                    {
                        str_RptName = "BTProPA.rpt";
                        str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.branchid}=" + branchid + " and {PAHead.vouyear}=" + txtvouyear.Text;
                        str_sp = "Lcurr=INR";
                        Logobj.InsLogDetail(logempid, 1053, 4, branchid, txtinv.Text);
                    }
                    if (str_RptName.Length > 0)
                    {
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Invoice", str_Script, true);
                    }
                }*/
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;

                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (btncancel.ToolTip == "Cancel")
                {
                    txtclear();
                    txtEnable();
                    btnadd.Enabled = false;
                   // btnsave.Text = "Save";
                   // btncancel.Text = "Back";
                  //  btnadd.Text = "Add";


                    btnsave.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                    btncancel.ToolTip = "Back";
                    btn_back1.Attributes["class"] = "btn ico-back";
                    btnadd.ToolTip = "Add";
                    btn_add1.Attributes["class"] = "btn btn-add1";


                    txtTotal.Text = "0";
                    txtdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
                    if (Logobj.GetDate().Month < 4)
                    {
                        txtvouyear.Text = (Logobj.GetDate().Year - 1).ToString();
                    }
                    else
                    {
                        txtvouyear.Text = Logobj.GetDate().Year.ToString();
                    }
                    grd.Enabled = true;
                    txtcreditapp.Text = "";
                    txtcreditapp.Enabled = true;
                    fatransfer = "";
                    txtcharge.Text = "";
                    txtcurr.Text = "";
                    txtex.Text = "";
                    txtrate.Text = "";
                    cmbbase.SelectedIndex = 0;
                    txtamount.Text = "";
                    cmbbill.SelectedIndex = 0;
                    hid_SupplyTo.Value = "0";
                    txtsupplyto.Text = "";
                    if (lbl_Header.Text == "Profoma Payment Advise")
                    {
                        txtVendorref.Text = "";
                    }
                    btnsave.Enabled = true;
                    UserRights();
                    txttruck.Focus();
                }
                else
                {
                    this.Response.End();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                branchid = int.Parse(Session["LoginBranchid"].ToString());
                CheckChargeData();
                if (blnerr == true)
                {
                    blnerr = false;
                    return;
                }
                DataTable dtchargedel = new DataTable();
                dtchargedel = INVOICEobj.GetCheckApprovedProfoma(int.Parse(txtinv.Text), branchid, int.Parse(txtvouyear.Text), "", lbl_Header.Text, "Charge");
                if (dtchargedel.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(txtinv, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Charges Cannot Delete After Approved');", true);
                    return;
                }
                UserRights();
                this.Popupdelete.Show();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_yes_1_Click(object sender, EventArgs e)
        {
            try
            {
                int chargeid = int.Parse(hdnChargid.Value);
                branchid = int.Parse(Session["LoginBranchid"].ToString());
                logempid = int.Parse(Session["LoginEmpId"].ToString());

                if (grd.Rows.Count > 0)
                {
                    intcustid = customerobj.GetCustomerid(txtto.Text);
                    if (txtcharge.Text == "" && txtcurr.Text == "" && cmbbase.Text == "" && txtrate.Text == "" && txtex.Text == "" && txtamount.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(txtinv, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Select The Charge');", true);
                        return;
                    }
                    if (lbl_Header.Text == "Profoma Invoice")
                    {
                        proinvobj.DelIPDetailsForBT(int.Parse(txtinv.Text), chargeid, cmbbase.Text, "I", intcustid, int.Parse(txtvouyear.Text), branchid, strTranType);
                        Logobj.InsLogDetail(logempid, 1052, 3, branchid, txtinv.Text + "/" + txtcharge.Text);
                    }
                    else
                    {
                        proinvobj.DelIPDetailsForBT(int.Parse(txtinv.Text), chargeid, cmbbase.Text, "P", intcustid, int.Parse(txtvouyear.Text), branchid, strTranType);
                        Logobj.InsLogDetail(logempid, 1053, 3, branchid, txtinv.Text + "/" + txtcharge.Text);
                    }
                    GrdLoad();
                    if (grd.Rows.Count < 1)
                    {
                        txtclear();
                    }
                    chargetxtclear();
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_no_1_Click(object sender, EventArgs e)
        {
            try
            {
                double amt = 0;
                chargetxtclear();
                txtTotal.Text = "0";
                for (int i = 0; i <=grd.Rows.Count - 1; i++)
                {

                    if(string.IsNullOrEmpty(grd.Rows[i].Cells[5].Text)!=true)
                    {
                        amt=amt+ Convert.ToDouble(grd.Rows[i].Cells[5].Text);
                    }
                    else{
                        amt=amt+0;

                    }
                    
                }
                txtTotal.Text = amt.ToString("#0.00");
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtrate_TextChanged(object sender, EventArgs e)
        {
            //int rate=

            dtdate = Convert.ToDateTime(Utility.fn_ConvertDatetime(txtdate.Text));
            if (txtrate.Text != "")
            {
                if (txtcharge.Text != "" && txtcurr.Text != "")
                {
                    txtex.Text = INVOICEobj.GetExRate(txtcurr.Text, dtdate, hid_Exrate.Value, Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                }
            }
            txtex.Focus();
        }


        protected void txtsupplyto_TextChanged(object sender, EventArgs e)
        {
            try
            {



                int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string str_TranType = Session["StrTranType"].ToString();
                string citysupplyid;
                int int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                if (txtsupplyto.Text != "")
                {
                    int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                    citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));
                    // txtsupplytoAddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                    DataTable dt_list = new DataTable();


                    if (int_custid != 0)
                    {
                        if (lbl_Header.Text == "Profoma Invoice")
                        {
                            dt_list = customerobj.GetIndianCustomergst(int_custid);
                            if (dt_list.Rows.Count > 0)
                            {
                                if (string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()) || string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                                {
                                    if (!string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                                    {
                                        //   txtsupplytoAddress.Text += System.Environment.NewLine + "GSTIN #:" + dt_list.Rows[0]["gstin"].ToString();

                                        ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update  Uinno#  Master Customer);", true);
                                    }
                                    else if (!string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                                    {
                                        // txtsupplytoAddress.Text += System.Environment.NewLine + "UIN #:" + dt_list.Rows[0]["uinno"].ToString();

                                        ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin# Master Customer');", true);
                                    }

                                    else if (dt_list.Rows[0]["UnRegistered"].ToString() == "N" && dt_list.Rows[0]["uinno"].ToString() == "" && dt_list.Rows[0]["gstin"].ToString() == "")
                                    {
                                        ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  OR  Select UnRegistered  Master Customer');", true);
                                    }
                                   // ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                                }
                                else
                                {
                                    //  txtsupplytoAddress.Text += System.Environment.NewLine + dt_list.Rows[0]["Column1"].ToString();
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                                return;
                            }

                        }
                    }
                    else if (int_custid == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "DataFound", "alertify.alert('Select Correct Customer Name');", true);
                        txtsupplyto.Text = "";
                        txtsupplyto.Focus();
                        return;
                    }


                }
                else
                {
                    if (txtsupplyto.Text == "")
                    {
                        hid_SupplyTo.Value = hdncustid.Value;

                        txtsupplyto.Text = txtto.Text;
                        txtsupplyto_TextChanged(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        public void ChkCustStateName(int custid, string custname)
        {
            if (Convert.ToDateTime(Logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
            {
                if (custname != "" && custid > 0)
                {

                    //int int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                    DataTable dt_list = new DataTable();
                    dt_list = customerobj.GetIndianCustomergstadd(custid);
                    if (dt_list.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('State Name not Updated in Master,Kindly update Master Customer " + custname + "');", true);
                        bolcuststat = true;
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Kindly update SUPPLY TO Name " + custname + "');", true);
                    bolcuststat = true;
                    return;
                }
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
            GridViewlog.Visible = true;
            Panel2.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();

            if (lbl_Header.Text == "Profoma Invoice")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1052, "ProInv", txtinv.Text, txtvouyear.Text, Session["StrTranType"].ToString());
                lbl_no.InnerText = "Profoma Invoice#:";
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1053, "Propa", txtinv.Text, txtvouyear.Text, Session["StrTranType"].ToString());
                lbl_no.InnerText = "Profoma Credit Note Ops #:";
            }


            if (txtinv.Text != "")
            {
                JobInput.Text = txtinv.Text;

              

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