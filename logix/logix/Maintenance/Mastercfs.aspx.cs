using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Web.Services.Description;

namespace logix.Maintenance
{
    public partial class Mastercfs : System.Web.UI.Page
    {
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
        DataAccess.Accounts.Invoice invoiceobj = new DataAccess.Accounts.Invoice();
        Boolean blrr;
        int cfsid;
        DataTable dt_char = new DataTable();
        DataTable dt_cfs = new DataTable();
        DataTable dt_grd = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Logobj.GetDataBase(Ccode);
                chargeobj.GetDataBase(Ccode);
                invoiceobj.GetDataBase(Ccode);
               
            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
           
            //ddltype.SelectedValue = "1";
            if (!this.IsPostBack)
            {
                try
                {
                   
                   // ddltype.SelectedValue = "1";
                    txt_date.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                    txtvalidfrom.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                    txtValidTill.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                    txtCharges.Attributes.Add("onkeypress", "return CheckTextLength(this,100,'Charges')");
                    txtCurr.Attributes.Add("onkeypress", "return CheckTextLength(this,3,'curr')");
                    txtRate.Attributes.Add("onKeyUp", "return CheckTextLength(this,10,'Rate')");
                    txtRate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Rate')");
                    basefil();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
        }
        protected void  basefil()
        {
            int i;
            ddlBase.Items.Clear();
            ddlBase.Items.Add("");
            //DataAccess.Accounts.Invoice invoiceobj = new DataAccess.Accounts.Invoice();
            DataTable dt = invoiceobj.BaseFill();
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                ddlBase.Items.Add(dt.Rows[i]["conttype"].ToString());
                //ddlBase.DataSource = dt;
                //ddlBase.DataTextField = "conttype";
                //ddlBase.DataBind();
            }
            ddlBase.Items.Add("BL");
            ddlBase.Items.Add("CBM");
            ddlBase.Items.Add("W/M");
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

     
        [WebMethod]
        public static List<string> GetLikeCustomer(string prefix)
        {
            List<string> list_result = new List<string>();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
           
            DataTable dt = new DataTable();
            string custype = "C";
            dt = customerobj.GetLikeCustomer(prefix.ToUpper(), custype);
            list_result = Utility.Fn_DatatableToList_CustomerAddress2(dt, "Customer", "customername", "customerid");
            return list_result;
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
            //obj_dt = obj_da_customerobj.GetLikeIndianCustomer(prefix);Cusobj
            //cargo = Utility.Fn_DatatableToList_Customer(obj_dt, "customername", "customerid");
            customer = Utility.Fn_TableToList(obj_dt, "Customer", "customerid", "customername", "address");
            return customer;
        }
        [WebMethod]
        public static List<string> GetCharges(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            chargeobj.GetDataBase(Ccode);
          
            DataTable dtCharge = new DataTable();
            dtCharge = chargeobj.GetLikeChargesName(prefix.Trim());
            List_Result = Utility.Fn_TableToList(dtCharge, "chargename", "chargeid");
            return List_Result;
        }


        [WebMethod]
        public static List<string> GetLikeCurrency(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            chargeobj.GetDataBase(Ccode);
           
            DataTable dtCharge = new DataTable();
            dtCharge = chargeobj.GetLikeCurrency(prefix.Trim());
            List_Result = Utility.Fn_TableToList(dtCharge, "currency", "currency");
            return List_Result;
        }

        protected void txt_Cfs_TextChanged(object sender, EventArgs e)
        {
            if (ddltype.SelectedValue != "0")
            {

                if (txt_Cfs.Text != "")
                {
                    DataTable dt;
                //    dt = chargeobj.selCFSheaddtls(Convert.ToInt32(hdnCarrier.Value),ddltype.SelectedItem.Text);
                    //if ((dt.Rows.Count > 0) && (dt.Rows.Count ==1))
                    //{
                    //    txtvalidfrom.Text = Utility.fn_ConvertDate(dt.Rows[0]["validfrom"].ToString());
                    //    txt_date.Text = Utility.fn_ConvertDate(dt.Rows[0]["cfsdate"].ToString());
                    //    txtValidTill.Text = Utility.fn_ConvertDate(dt.Rows[0]["validto"].ToString());
                    //    txtRemarks.Text = dt.Rows[0]["remarks"].ToString();
                    //    hdncfsid.Value = (dt.Rows[0]["cfsid"].ToString());
                    //    txtcfsid.Text = hdncfsid.Value;
                    //    hdnCarrier.Value = (dt.Rows[0]["customerid"].ToString());
                    //    dt_cfs = chargeobj.SelCFSDetails(Convert.ToInt32(dt.Rows[0]["cfsid"].ToString()));
                    //    if (dt_cfs.Rows.Count > 0)
                    //    {
                    //        Session["Container"] = dt_cfs;
                    //        grd.DataSource = dt_cfs;
                    //        grd.DataBind();
                    //    }
                    //    btnAdd.ToolTip = "Add";
                    //    btn_add1.Attributes["class"] = "btn btn-add1";
                    //    btnsave.ToolTip = "Update";
                    //    btn_save.Attributes["class"] = "btn btn-update1";


                    //}
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid CFS.');", true);
                    txt_Cfs.Focus();
                    return;
                }
            }
           
            else
            {

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly select the Type');", true);
                return;
            }

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (ddltype.SelectedValue != "0")
            {
                if (txt_Cfs.Text != "")
                {

                    if (btnsave.ToolTip == "Save")
                    {

                        cfsid = chargeobj.Insmastercfschargehead(Convert.ToInt32(hdnCarrier.Value), txtaddress.Text, Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txtvalidfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text))
                               , txtRemarks.Text, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)), ddltype.SelectedItem.Text);

                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('CFS details saved.Kindly add CFS Charges');", true);


                        txtcfsid.Text = cfsid.ToString();
                        btnsave.ToolTip = "Update";
                        btn_save.Attributes["class"] = "btn btn-update1";

                        hdncfsid.Value = cfsid.ToString();
                        txtCharges.Focus();
                        btncancel.ToolTip = "Cancel";
                        btn_cancel.Attributes["class"] = "btn ico-cancel";
                    }
                    else
                    {
                        chargeobj.Updmastercfschargehead(Convert.ToInt32(hdncfsid.Value), Convert.ToDateTime(Utility.fn_ConvertDate(txtvalidfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txtValidTill.Text))
                                          , txtRemarks.Text, Convert.ToInt32(Session["LoginEmpId"]), ddltype.SelectedItem.Text);
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('CFS details Updated.');", true);
                        btnsave.ToolTip = "Update";
                        btn_save.Attributes["class"] = "btn btn-update1";
                    }
                }


                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly select the CFS.');", true);
                    txt_Cfs.Focus();
                    return;
                }
            }
            else
            {

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly select the Type');", true);
                return;
            }


        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            bottomValuesClear();
            btnsave.ToolTip = "Save";
            btn_save.Attributes["class"] = "btn ico-save";
            txt_Cfs.Text = "";
            txtaddress.Text = "";
            ddltype.SelectedValue = "0";
            txtRemarks.Text = "";
            txtcfsid.Text = "";
            txt_date.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
            txtvalidfrom.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
            txtValidTill.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
            grd.DataSource = null;
            grd.DataBind();
            basefil();

        }
        protected void txtCurr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                DataTable dtCharge = new DataTable();
                int currid = chargeobj.GetCurrID(txtCurr.Text.Trim().ToUpper());
                if (currid != 0 || hdnCurrid.Value != "0")
                {
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter  Valid Currency');", true);
                    txtCurr.Text = "";
                    txtCurr.Focus();
                    blrr = true;
                    return;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void txtCharges_TextChanged(object sender, EventArgs e)
        {
            try
            {
               // DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                DataTable dtCharge = new DataTable();

                int chargeid = chargeobj.GetChargeid(txtCharges.Text.Trim().ToUpper());
                if (chargeid != 0 && hdnChargeid.Value != "0")
                {

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter  Valid Charges');", true);
                    txtCharges.Text = "";
                    txtCharges.Focus();
                    blrr = true;
                    return;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        public void bottomValuesClear()
        {
            txtCharges.Text = "";
            txtCurr.Text = "";
            txtRate.Text = "";
            ddlBase.SelectedIndex = 0;
            btnAdd.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn btn-add1";
            hdnChargeid.Value = "";
            txtCharges.Enabled = true;
            ddlBase.Enabled = true;
            btnsave.Enabled = true;
            btnsave.ForeColor = System.Drawing.Color.White;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {


            try
            {
                if (txtCurr.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Currency Should Not Be Blank');", true);
                    txtCurr.Focus();
                    return;
                }
                else
                {
                  //  DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                    int cha = chargeobj.GetCurrID(txtCurr.Text);
                    if (cha == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Currency');", true);
                        txtCurr.Focus();
                        return;
                    }

                }
                txtCharges_TextChanged(sender, e);
                txtCurr_TextChanged(sender, e);
                if (blrr == true)
                {
                    return;
                }
                if (txtCharges.Text != "")
                {
                    if (ddlBase.SelectedIndex == 0 || ddlBase.SelectedItem.Text == "Base / Unit" || ddlBase.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(Page), "alert", "alertify.alert('Please select the Base / Units');", true);
                        ddlBase.Focus();
                        return;
                    }
                    txtCurr.Text = txtCurr.Text.ToUpper();
                    if (ddltype.SelectedValue != "0")
                    {
                        if (btnAdd.ToolTip == "Add")
                        {


                            int chargeid;
                            chargeid = chargeobj.GetChargeid(txtCharges.Text);
                            hdnChargeid.Value = chargeid.ToString();

                            if (hdnChargeid.Value == "")
                            {
                                hdnChargeid.Value = chargeid.ToString();
                            }
                            dt_char = chargeobj.CfsChargebaseExist(Convert.ToInt32(hdncfsid.Value), chargeid, ddlBase.Text,ddltype.SelectedItem.Text);
                            if (dt_char.Rows.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Charge Details Already Exists.');", true);
                                bottomValuesClear();
                                return;
                            }
                            else
                            {

                                chargeobj.Insmastercfschargedetails(Convert.ToInt32(hdncfsid.Value), Convert.ToInt32(chargeid), txtCurr.Text.ToUpper().Trim(), Convert.ToDouble(txtRate.Text), ddlBase.Text, ddltype.SelectedItem.Text);
                                dt_cfs = chargeobj.SelCFSDetails(Convert.ToInt32(hdncfsid.Value),ddltype.SelectedItem.Text);
                                if (dt_cfs.Rows.Count > 0)
                                {
                                    Session["Container"] = dt_cfs;
                                    grd.DataSource = dt_cfs;
                                    grd.DataBind();
                                }
                                bottomValuesClear();

                            }

                        }
                        else if (btnAdd.ToolTip == "Update")
                        {
                            int chargeid;
                            chargeid = chargeobj.GetChargeid(txtCharges.Text);
                            hdnChargeid.Value = chargeid.ToString();

                            chargeobj.UPdmastercfschargedetails(Convert.ToInt32(hdncfsid.Value), Convert.ToInt32(chargeid), txtCurr.Text.ToUpper().Trim(), Convert.ToDouble(txtRate.Text), ddlBase.Text, ddltype.SelectedItem.Text);
                            dt_cfs = chargeobj.SelCFSDetails(Convert.ToInt32(hdncfsid.Value), ddltype.SelectedItem.Text);
                            if (dt_cfs.Rows.Count > 0)
                            {
                                Session["Container"] = dt_cfs;
                                grd.DataSource = dt_cfs;
                                grd.DataBind();
                            }
                            bottomValuesClear();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly select the Type');", true);
                       
                        return;
                    }

                    Session["Container"] = dt_cfs;
                    btnAdd.ToolTip = "Add";
                    btn_add1.Attributes["class"] = "btn btn-add1";
                    txtCharges.Enabled = true;
                    ddlBase.Enabled = true;
                }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        protected void grd_PreRender(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                grd.UseAccessibleHeader = true;
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = grd.SelectedRow.RowIndex;
                txtCharges.Text = grd.Rows[index].Cells[0].Text.Replace("&amp;", "&");
                Session["chargename"] = txtCharges.Text;
                txtCurr.Text = grd.Rows[index].Cells[1].Text;
                txtRate.Text = grd.Rows[index].Cells[2].Text;
                ddlBase.SelectedValue = grd.Rows[index].Cells[3].Text;
                // btnAdd.Text = "Update";
                btnAdd.ToolTip = "Update";
                btn_add1.Attributes["class"] = "btn btn-UpdateAdd2";

                btnAdd.Enabled = true;
                txtCharges.Enabled = false;
                ddlBase.Enabled = false;
                //this.PopUpService.Show();
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
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    ImageButton Img_delete = (ImageButton)e.CommandSource;
                    GridViewRow gvRow = (GridViewRow)Img_delete.NamingContainer;
                    DataTable obj_dt = new DataTable();
                    DataTable objdel = new DataTable();
                    obj_dt = (DataTable)Session["Container"];
                    int RowIndex = gvRow.RowIndex;
                    int chargeid, currid;
                    chargeid = chargeobj.GetChargeid(grd.Rows[RowIndex].Cells[0].Text);
                    
                    //int index = grd.RowIndex;
                    txtCharges.Text = grd.Rows[RowIndex].Cells[0].Text.Replace("&amp;", "&");
                    
                    chargeid = chargeobj.GetChargeid(txtCharges.Text.Replace("&amp;", "&"));
                    hdnChargeid.Value = chargeid.ToString();

                    currid = chargeobj.GetCurrID(txtCurr.Text);
                    hdnCurrid.Value = currid.ToString();
               
                    string ddlbasevalue = grd.Rows[RowIndex].Cells[3].Text;
                    DataTable dts = new DataTable();
                    chargeobj.DelcfschargeDetail(Convert.ToInt32(hdncfsid.Value), chargeid, ddlbasevalue);

                    //dtbuying = buyingobj.SelBuyingDetails(Convert.ToInt32(txtRateid.Text));
                    dt_cfs = chargeobj.SelCFSDetails(Convert.ToInt32(hdncfsid.Value),ddltype.SelectedItem.Text);
                    grd.DataSource = null;
                    grd.DataBind();
                    if (dt_cfs.Rows.Count > 0)
                    {
                        Session["Container"] = dt_cfs;
                        grd.DataSource = dt_cfs;
                        grd.DataBind();
                    }
                    else
                    {
                        grd.DataSource = null;
                        grd.DataBind();
                    }
                   // Session["Container"] = dt_cfs;
                    bottomValuesClear();
                    ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "logix", "Details Deleted...", true);
                    
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddltype.SelectedValue != "0")
                {

                    Panel3.Visible = true;
                    grdmain.Visible = true;
                    dt_grd = chargeobj.Getcfschargesdtls4id(0,ddltype.SelectedItem.Text);
                    if (dt_grd.Rows.Count > 0)
                    {
                        this.popupBuying.Show();
                        grdmain.DataSource = dt_grd;
                        grdmain.DataBind();
                        ViewState["Rate"] = dt_grd;

                    }
                    //popBuying.Visible = true;

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "alert", "alertify.alert('Customer CFS Not Available');", true);
                    }
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly select the Type');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        protected void grdmain_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdmain, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }


        protected void cfsid_TextChanged(object sender, EventArgs e)
        {
            if (ddltype.SelectedValue != "0")
            {
                if (txtcfsid.Text != "")
                {
                    DataTable dt;
                    dt = chargeobj.selCFSheaddtls(Convert.ToInt32(txtcfsid.Text), ddltype.SelectedItem.Text);
                    if (dt.Rows.Count > 0)
                    {
                        txt_Cfs.Text = dt.Rows[0]["cfs"].ToString();
                        txtaddress.Text = dt.Rows[0]["address"].ToString();
                        txtvalidfrom.Text = Utility.fn_ConvertDate(dt.Rows[0]["validfrom"].ToString());
                        txt_date.Text = Utility.fn_ConvertDate(dt.Rows[0]["cfsdate"].ToString());
                        txtValidTill.Text = Utility.fn_ConvertDate(dt.Rows[0]["validto"].ToString());
                        txtRemarks.Text = dt.Rows[0]["remarks"].ToString();
                        hdncfsid.Value = (dt.Rows[0]["cfsid"].ToString());
                        txtcfsid.Text = hdncfsid.Value;
                        hdnCarrier.Value = (dt.Rows[0]["customerid"].ToString());
                        dt_cfs = chargeobj.SelCFSDetails(Convert.ToInt32(txtcfsid.Text), ddltype.SelectedItem.Text);
                        if (dt_cfs.Rows.Count > 0)
                        {
                            Session["Container"] = dt_cfs;
                            grd.DataSource = dt_cfs;
                            grd.DataBind();
                        }
                        btnAdd.ToolTip = "Add";
                        btn_add1.Attributes["class"] = "btn btn-add1";
                        btnsave.ToolTip = "Update";
                        btn_save.Attributes["class"] = "btn btn-update1";


                    }
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid CFS.');", true);
                    txt_Cfs.Focus();
                    return;
                }
            }
            else
            {

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly select the Type');", true);
                return;
            }

        }

        protected void grdmain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grdmain.Rows.Count > 0)
            {
                int index = grdmain.SelectedRow.RowIndex;
                txtcfsid.Text = grdmain.SelectedRow.Cells[0].Text;
                hdncfsid.Value = txtcfsid.Text;

                DataTable dt;
                dt = chargeobj.Getcfschargesdtls4id(Convert.ToInt32(txtcfsid.Text), ddltype.SelectedItem.Text);
                if ((dt.Rows.Count > 0))
                {
                    txt_Cfs.Text = dt.Rows[0]["customer"].ToString();
                    txtaddress.Text = dt.Rows[0]["address"].ToString();
                    txtvalidfrom.Text = Utility.fn_ConvertDate(dt.Rows[0]["validfrom"].ToString());
                    txt_date.Text = Utility.fn_ConvertDate(dt.Rows[0]["cfsdate"].ToString());
                    txtValidTill.Text = Utility.fn_ConvertDate(dt.Rows[0]["validto"].ToString());
                    txtRemarks.Text = dt.Rows[0]["remarks"].ToString();
                    hdncfsid.Value = (dt.Rows[0]["cfsid"].ToString());
                    txtcfsid.Text = hdncfsid.Value;
                    hdnCarrier.Value = (dt.Rows[0]["customerid"].ToString());
                    dt_cfs = chargeobj.SelCFSDetails(Convert.ToInt32(dt.Rows[0]["cfsid"].ToString()), ddltype.SelectedItem.Text);
                    if (dt_cfs.Rows.Count > 0)
                    {
                        Session["Container"] = dt_cfs;
                        grd.DataSource = dt_cfs;
                        grd.DataBind();
                    }
                    btnAdd.ToolTip = "Add";
                    btn_add1.Attributes["class"] = "btn btn-add1";
                    btnsave.ToolTip = "Update";
                    btn_save.Attributes["class"] = "btn btn-update1";


                }
            }
        }

       

       

    }
}
