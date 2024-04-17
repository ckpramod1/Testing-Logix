using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using DataAccess.HR;
using DataAccess.Marketing;
using logix.CRMNew;
using System.ComponentModel;
using System.Web.Services.Description;


namespace logix.Sales
{
    public partial class BuyingRates : System.Web.UI.Page
    {
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.Invoice invoiceobj = new DataAccess.Accounts.Invoice();
        DataAccess.BuyingRate buyingobj = new DataAccess.BuyingRate();
        DataAccess.Masters.MasterCustomer Cusobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.Marketing.Quotation quotobj = new DataAccess.Marketing.Quotation();
        DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
        DataAccess.Masters.MasterCargo cargoobj = new DataAccess.Masters.MasterCargo();

        //DataAccess.Masters.InquiryDetails getbaseval =new DataAccess.Masters.InquiryDetails();

        DataTable dt = new DataTable();
        DataTable dt_quot = new DataTable();
        DataTable dt_chk = new DataTable();
        DataTable dtbuying = new DataTable();
        DataTable dt_cust = new DataTable();
        DataTable dt_port = new DataTable();
        DataTable dtrateid = new DataTable();
        DataTable dt_char = new DataTable();
        DataTable dt_grd = new DataTable();
        DataTable dtproduct=new DataTable();

        DataTable dtgetbase=new DataTable();

        DataTable dtgetrate = new DataTable();

        DateTime validity;
        Boolean ratevalid, blnexist, blndelete, blrr;
        int i, total, preparedby, empid;
        char freight;
        char shipment, dgcargo, bulkvolume;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string Ctrl_List1;
        string Msg_List1;
        string Dtype_List1;
        int Rateid;
        string str_Uiid = "";
        string inquiryid;

        DataTable obj_dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Logobj.GetDataBase(Ccode);
                invoiceobj.GetDataBase(Ccode);
                buyingobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                Cusobj.GetDataBase(Ccode);
                portobj.GetDataBase(Ccode);
                empobj.GetDataBase(Ccode);
                quotobj.GetDataBase(Ccode);
                chargeobj.GetDataBase(Ccode);
                cargoobj.GetDataBase(Ccode);

      
            }


            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('http://logix.copperhawk.tech/','_top');", true);
            }
          

            if (Session["BuyRateid"] != null)
            {
                txtRateid.Text = Session["BuyRateid"].ToString();
                //txtRateid_TextChanged(sender, e);
                
                dtpValidity.Text = DateTime.Parse(Logobj.GetDate().AddDays(15).ToShortDateString()).ToString("dd/MM/yyyy");
                    dtdateval.StartDate = DateTime.Parse(Logobj.GetDate().ToShortDateString());
                dtdateval.EndDate = DateTime.Parse(Logobj.GetDate().ToShortDateString()).AddDays(15);
                return;
                //Session["BuyRateid"] = null;
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
            if (!this.IsPostBack)
            {
                try
                {
                    //grd_SelectedIndexChanged(sender, e);
                    Fill();
                    dtpValidity.Text = DateTime.Parse(Logobj.GetDate().AddDays(15).ToShortDateString()).ToString("dd/MM/yyyy");
                    dtdateval.StartDate = DateTime.Parse(Logobj.GetDate().ToShortDateString());
                    grd.DataSource = Utility.Fn_GetEmptyDataTable();
                    grd.DataBind();
                    //Ctrl_List = txtCarrier.ID + "~" + hdnCarrier.ID + "~" + txtPor.ID + "~" + hdnPORid.ID + "~" + txtPol.ID + "~" + hdnPOLid.ID + "~" + txtPod.ID + "~" + hdnPODid.ID + "~" + txtFd.ID + "~" + hdnFDid.ID + "~" + txtCommodity.ID + "~" + hdnCommodity.ID + "~" + ddlFreight.ID + "~" + ddlShipment.ID + "~" + txtBrokerage.ID + "~" + txtRateby.ID + "~" + HdnPreparedBy.ID;
                    //Msg_List = "Carrier~Carrier~Place of Receipt~Place of Receipt~Port of Loading~Port of Loading~Port of Discharge~Port of Discharge~Place of Delivery~Place of Delivery~Commodity~Commodity~Freight~Shipment~Brokerage~Rate Obtainedby";
                    //Dtype_List = "string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~Dropdownlist~Dropdownlist~int~string~Autocomplete";
      
                    string POR = Request.QueryString["POR"];
                    string POL = Request.QueryString["POL"];
                    string POD = Request.QueryString["POD"];
                    string FD = Request.QueryString["FD"];
                    string Frieght = Request.QueryString["Frieght"];
                    string Shipment = Request.QueryString["Shipment"];
                    string Commodity = Request.QueryString["Commodity"];
                    string Remarks = Request.QueryString["Remarks"];
                    string Preparedby = Request.QueryString["Preparedby"];

                    string rateid = Request.QueryString["Rateid"];

                    string carrierid = Request.QueryString["CustomerId"];

                    string validtill = Request.QueryString["validTill"];

                    string brokerage = Request.QueryString["Brokerage"];



                    //string inquiryid = Request.QueryString["quotid2"];

                    string buyingno = rateid;
                    //dtgetrate = buyingobj.SelRateIdTable(buyingno);
                    if (buyingno == "")
                    {
                        txtPor.Text = POR;
                        txtPol.Text = POL;
                        txtPod.Text = POD;
                        txtFd.Text = FD;
                        ddlFreight.SelectedItem.Text = Frieght;
                        ddlShipment.SelectedItem.Text = Shipment;
                        txtCommodity.Text = Commodity;
                        txtRemarks.Text = Remarks;
                        txtRateby.Text = Preparedby;
                        txtRateid.Text = rateid;
                        txtCarrier.Text = carrierid;
                        dtpValidity.Text = validtill;
                        txtBrokerage.Text = "0";

                        DataTable dtPort = new DataTable();
                        dtPort = portobj.GetLikePort(txtPor.Text);
                        hdnPORid.Value = dtPort.Rows[0]["portid"].ToString();

                        dtPort = portobj.GetLikePort(POL);
                        hdnPOLid.Value = dtPort.Rows[0]["portid"].ToString();

                        dtPort = portobj.GetLikePort(POD);
                        hdnPODid.Value = dtPort.Rows[0]["portid"].ToString();

                        dtPort = portobj.GetLikePort(txtFd.Text);
                        hdnFDid.Value = dtPort.Rows[0]["portid"].ToString();


                        dtPort = cargoobj.GetLikeCargo(txtCommodity.Text);
                        hdnCommodity.Value = dtPort.Rows[0]["cargoid"].ToString();

                        DataTable dtEmployee = new DataTable();
                        dtEmployee = empobj.GetLikeEmployee(txtRateby.Text);
                        HdnPreparedBy.Value = dtEmployee.Rows[0]["employeeid"].ToString();

                        DataTable obj_dt = new DataTable();
                        obj_dt = Cusobj.GetLikeCustomer(txtCarrier.Text);
                        hdnCarrier.Value = obj_dt.Rows[0]["customerid"].ToString();

                    }
                    else
                    {
                        txtRateid.Text = buyingno;
                        //int buyingno=Convert.ToInt32(txtRateid.Text);
                        // dtgetrate = buyingobj.SelRateIdTable(buyingno);
                        txtRateid_TextChanged(sender,e);
                    }
                    if (ddlShipment.Text != "")
                    {
                        ddl();
                    }


                    




                    Ctrl_List = txtCarrier.ID + "~" + hdnCarrier.ID + "~" + txtPor.ID + "~" + hdnPORid.ID + "~" + txtPol.ID + "~" + hdnPOLid.ID + "~" + txtPod.ID + "~" + hdnPODid.ID + "~" + txtFd.ID + "~" + hdnFDid.ID + "~" + txtCommodity.ID + "~" + hdnCommodity.ID + "~" + txtRateby.ID + "~" + HdnPreparedBy.ID;
                    Msg_List = "Carrier~Carrier~Place of Receipt~Place of Receipt~Port of Loading~Port of Loading~Port of Discharge~Port of Discharge~Place of Delivery~Place of Delivery~Commodity~Commodity~Rate Obtainedby";
                    Dtype_List = "string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete~string~Autocomplete";
                    
                    
                    btnsave.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "') && IsDate('dtpValidity')");
                    btnview.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "') && IsDate('dtpValidity')");
                    //btnsave.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "') ");

                    Ctrl_List1 = txtCharges.ID + "~" + txtCurr.ID + "~" + txtRate.ID;
                    Msg_List1 = "Charges~Curr~Rate";
                    Dtype_List1 = "string~string~int";
                    btnAdd.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List1 + "','" + Msg_List1 + "','" + Dtype_List1 + "');");


                    txtCarrier.Attributes.Add("onkeypress", "return CheckTextLength(this,100,'Carrier')");
                    txtPor.Attributes.Add("onkeypress", "return CheckTextLength(this,50,'POR')");
                    txtPol.Attributes.Add("onkeypress", "return CheckTextLength(this,50,'POL')");
                    txtPod.Attributes.Add("onkeypress", "return CheckTextLength(this,50,'POD')");
                    txtFd.Attributes.Add("onkeypress", "return CheckTextLength(this,50,'FD')");
                    txtCommodity.Attributes.Add("onkeypress", "return CheckTextLength(this,50,'Cargo')");
                    //txtBrokerage.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Brokerage')");
                    //txtBrokerage.Attributes.Add("onkeyup", "return validateFloatKeyPress(this,event,'Brokerage')");
                    txtRateby.Attributes.Add("onkeypress", "return CheckTextLength(this,50,'RateBy')");
                    txtRemarks.Attributes.Add("onkeypress", "return CheckTextLength(this,100,'Remarks')");
                    txtCharges.Attributes.Add("onkeypress", "return CheckTextLength(this,100,'Charges')");
                    txtCurr.Attributes.Add("onkeypress", "return CheckTextLength(this,3,'curr')");
                    txtRate.Attributes.Add("onKeyUp", "return CheckTextLength(this,10,'Rate')");
                    txtRate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Rate')");
                    //validateFloatKeyPress,isNumberKey

                    txtRateid.Attributes.Add("onkeypress", "return IntegerCheck(event,'Rate ID')");
                   // txtRate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Rate')");

                    txtBrokerage.Text = "0";
                    btnsave.Enabled = true;
                    //btnsave.Attributes["Class"] = "btn ico-save";
                    btnsave.ForeColor = System.Drawing.Color.White;
                    txtBrokerage.Visible = false;
                    btncancel.ToolTip = "Cancel";
                    btn_cancel.Attributes["class"] = "btn ico-cancel";
                    txtRateid.Focus();
                  

                    //if (Session["StrTranType"].ToString() == "FE")
                    //{
                    //    header1.InnerText = "OceanExports";
                    //}
                    //else if (Session["StrTranType"].ToString() == "FI")
                    //{
                    //    header1.InnerText = "OceanImports";
                    //}
                    //else if (Session["StrTranType"].ToString() == "AE")
                    //{
                    //    header1.InnerText = "AirExports";
                    //}
                    //else if (Session["StrTranType"].ToString() == "AI")
                    //{
                    //    header1.InnerText = "AirImports";
                    //} 
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

            string inquiryid = Request.QueryString["quotid2"];

            dtgetbase = buyingobj.GetBaseValue(Convert.ToInt32(inquiryid));

            if (shipment == 'F')
            {


                ddlBase.Items.Clear();
                ddlBase.Items.Add("");
                //ddlBase.Items.Add("Base/Unit");
                for (int i = 0; i < dtgetbase.Rows.Count; i++)
                {

                    ddlBase.DataSource = dtgetbase;
                    ddlBase.DataTextField = "Base";
                    //ddlBase.DataBind();
                    ddlBase.Items.Add("");
                    ddlBase.Items.Add(dtgetbase.Rows[i]["Base"].ToString());
                    //ddlBase.Items.Add("");
                    //ddlBase.Items.Add(dt.Rows[i].ToString());

                }

                ddlBase.Items.Add("BL");
            }

            else if (shipment == 'A')
            {


                ddlBase.Items.Clear();
                ddlBase.Items.Add("");
                //ddlBase.Items.Add("Base/Unit");
                for (int i = 0; i < dtgetbase.Rows.Count; i++)
                {

                    ddlBase.DataSource = dtgetbase;
                    ddlBase.DataTextField = "Base";
                    //ddlBase.DataBind();
                    ddlBase.Items.Add("");
                    ddlBase.Items.Add(dtgetbase.Rows[i]["Base"].ToString());
                    //ddlBase.Items.Add("");
                    //ddlBase.Items.Add(dt.Rows[i].ToString());

                }

                ddlBase.Items.Add("BL");
            }



            //string buyingno = Request.QueryString["Buyingno"];


            //dtbuying = buyingobj.SelBuyingDetails(Convert.ToInt32(txtRateid.Text));

            if (txtRateid.Text != "")
            {

                //string buyingno = Request.QueryString["Buyingno"];


                dtbuying = buyingobj.SelBuyingDetails(Convert.ToInt32(txtRateid.Text));
                if (dtbuying.Rows.Count > 0)
                {
                    Session["Container"] = dtbuying;
                    grd.DataSource = dtbuying;
                    grd.DataBind();
                    //ImageButton btndelete = new ImageButton();
                    //foreach (GridViewRow row in grd.Rows)
                    //{
                    //    btndelete = (ImageButton)row.FindControl("ImageButton2");
                    //    btndelete.Visible = true;
                    //}

                }
                else
                {

                    btncancel.ToolTip = "Cancel";
                    btn_cancel.Attributes["class"] = "btn ico-cancel";
                    btnsave.ToolTip = "Update";
                    btn_save.Attributes["class"] = "btn btn-update1";
                    btnsave.Enabled = true;
                    btnsave.ForeColor = System.Drawing.Color.White;
                    total = Convert.ToInt32(txtRateid.Text);
                    grd.DataSource = Utility.Fn_GetEmptyDataTable();
                    grd.DataBind();
                }

            }


            if (txtRateid.Text != "")
            {
                btnsave.Text = "Update";
                btnsave.ToolTip = "Update";
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
            obj_dt = obj_da_customerobj.GetLikeCustomer(prefix.Trim(),FType);
            //obj_dt = obj_da_customerobj.GetLikeIndianCustomer(prefix);Cusobj
            //cargo = iFACT.Utility.Fn_DatatableToList_Customer(obj_dt, "customername", "customerid");
            customer = Utility.Fn_DatatableToList(obj_dt, "customer", "customerid");
            return customer;
        }



        //[WebMethod]
        //public static List<string> GetLikeCustomer(string prefix)
        //{
        //    List<string> List_Result = new List<string>();
        //    DataAccess.Masters.MasterCustomer Cusobj = new DataAccess.Masters.MasterCustomer();
        //    DataTable dtCarrier = new DataTable();
        //    dtCarrier = Cusobj.GetLikeCustomer(prefix.ToUpper(), "L");
        //    // List_Result = Utility.Fn_DatatableToList_int16Display(dtCarrier, "addr", "customerid", "customername");
        //    List_Result = Utility.Fn_TableToList(dtCarrier, "customer", "customerid");
        //    return List_Result;
        //}

        [WebMethod]
        public static List<string> GetLikePort(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            portobj.GetDataBase(Ccode);
            DataTable dtPort = new DataTable();
            dtPort = portobj.GetLikePort(prefix.Trim());
            List_Result = Utility.Fn_TableToList(dtPort, "portname", "portid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetLikeCargo(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCargo cargoobj = new DataAccess.Masters.MasterCargo();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            cargoobj.GetDataBase(Ccode);
            DataTable dtPort = new DataTable();
            dtPort = cargoobj.GetLikeCargo(prefix.Trim());
            List_Result = Utility.Fn_TableToList(dtPort, "cargotype", "cargoid");
            return List_Result;
        }


        [WebMethod]
        public static List<string> GetLikeEmployee(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            empobj.GetDataBase(Ccode);
            DataTable dtEmployee = new DataTable();
            dtEmployee = empobj.GetLikeEmployee(prefix.Trim());
            List_Result = Utility.Fn_DatatableToList_int16Display(dtEmployee, "empnamecode", "employeeid", "empname");
            return List_Result;
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
        //private void ShowNoResultFound(DataTable source, GridView gv)
        //{
        //    if (source.Columns.Count == 0)
        //    {
        //        gv.DataSource = null;
        //        gv.DataBind();
        //        source.Columns.Add("chargename");
        //        source.Columns.Add("curr");
        //        source.Columns.Add("rate");
        //        source.Columns.Add("base");
        //        source.Rows.Add(source.NewRow());
        //        gv.DataSource = source;
        //        gv.DataBind();
        //        int columnsCount = gv.Columns.Count;
        //        gv.Rows[0].Cells.Clear();
        //        //gv.Rows[0].Cells.Add(new TableCell());
        //        //gv.Rows[0].Cells[0].ColumnSpan = columnsCount;
        //        //gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        //        //gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Black;
        //        //gv.Rows[0].Cells[0].Font.Bold = true;
        //        //gv.Rows[0].Cells[0].Text = "No Record Found.";
        //    }
        //}


        public void Fill()
        {
            //ddlFreight.Items.Add("Freight");
            ddlFreight.Items.Add("PrePaid");
            ddlFreight.Items.Add("Collect");
            //ddlShipment.Items.Add("Shipment");
            //ddlShipment.Items.Add("FCL");
            //ddlShipment.Items.Add("LCL");
            //ddlShipment.Items.Add("AIR");
            ddlBase.Items.Add("");
            //btnAdd.Enabled = false;
          //  btndelete.Enabled = false;
            btnsave.Enabled = false;
            
            // btndelete.Visible = false;
            btnsave.ForeColor = System.Drawing.Color.Gray;
            btnAdd.ForeColor = System.Drawing.Color.Gray;
            btndelete.ForeColor = System.Drawing.Color.Gray;

            

            dtpValidity.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
            btncancel.ToolTip = "Back";
            btn_cancel.Attributes["class"] = "btn ico-back";
            // dtpValidity.Text = Utility.fn_ConvertDate(dtpValidity.Text);


           
        }
        public void shipmenttype()
        {
            try
            {


                //if (shipment == 'F')
                //{
                //    ddlBase.Items.Clear();
                //    ddlBase.Items.Add("");


                //    //dtgetbase = buyingobj.GetBaseValue(Convert.ToInt32(inquiryid));
                //    dt = invoiceobj.BaseFill();
                //    for (i = 0; i < dt.Rows.Count - 1; i++)
                //    {
                //        ddlBase.DataSource = dtgetbase;
                //        ddlBase.DataTextField = "conttype";
                //        ddlBase.DataBind();
                //        ddlBase.Items.Add(dtgetbase.Rows[i]["conttype"].ToString());

                //    }
                //    ddlBase.Items.Add("BL");

                    //}
                    //else if (shipment == 'L')
                    //{
                    //    ddlBase.Items.Clear();
                    //    ddlBase.Items.Add("");
                    //    ddlBase.Items.Add("BL");
                    //    ddlBase.Items.Add("CBM");
                    //    ddlBase.Items.Add("MT");

                    //}

                    //else if (shipment == 'A')
                    //{
                    //    ddlBase.Items.Clear();
                    //    ddlBase.Items.Add("");
                    //    ddlBase.Items.Add("HAWB");
                    //    ddlBase.Items.Add("KGS");
                    //    ddlBase.Items.Add("PERTRUCK");
                    //    ddlBase.Items.Add("COTTON/PALLET");

                    //}


                    //dtgetbase = buyingobj.GetBaseValue(Convert.ToInt32(inquiryid));

                    //ddlBase.Items.Clear();

                    //for (int i = 0; i < dtgetbase.Rows.Count; i++)
                    //{
                    //    ddlBase.DataSource = dtgetbase;
                    //    ddlBase.DataTextField = "Base";
                    //    ddlBase.DataBind();
                    //    ddlBase.Items.Add(dt.Rows[i]["Base"].ToString());

                    //    //ddlBase.Items.Add("");
                    //    //ddlBase.Items.Add(dt.Rows[i].ToString());

                    //}

                    //ddlBase.Items.Add("BL");
                
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void topValuesClear()
        {
            txtCarrier.Text = "";
            txtRateid.Text = "";
            txtPor.Text = "";
            txtPol.Text = "";
            txtPod.Text = "";
            txtFd.Text = "";
            txtCommodity.Text = "";
            txtRemarks.Text = "";
            ddlFreight.SelectedIndex = 0;
            ddlShipment.SelectedIndex = 0;
            dtpValidity.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
            // dtpValidity.Text = Logobj.GetDate().ToShortDateString();
            chkDGCargo.Checked = false;
            chkBulk.Checked = false;
            //  txtBrokerage.Text = "";
            txtRateby.Text = "";
            hdnCarrier.Value = "";
            hdnPORid.Value = "";
            hdnPOLid.Value = "";
            hdnPODid.Value = "";
            hdnFDid.Value = "";
            hdnCommodity.Value = "";
            HdnPreparedBy.Value = "";

        }
        public void bottomValuesClear()
        {
            txtCharges.Text = "";
            txtCurr.Text = "";
            txtRate.Text = "";
            ddlBase.SelectedIndex = 0;
           // btnAdd.Text = "Add";
            btnAdd.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn ico-add";
            hdnChargeid.Value = "";
            txtCharges.Enabled = true;
            ddlBase.Enabled = true;
            //btnsave.Text = "Save";

            //btnsave.ToolTip = "Save";
            //btn_save.Attributes["class"] = "btn ico-save";
            btnsave.Enabled = true;
            btnsave.ForeColor = System.Drawing.Color.White;
        }
        public void collectdata()
        {
            if (ddlFreight.Text == "PrePaid")
            {
                freight = 'P';
            }
            else if (ddlFreight.Text == "Collect")
            {
                freight = 'C';
            }

            if (ddlShipment.Text == "LCL")
            {
                shipment = 'L';
            }
            else if (ddlShipment.Text == "FCL")
            {
                shipment = 'F';
            }
            else if (ddlShipment.Text == "AIR")
            {
                shipment = 'A';
            }
            if (chkDGCargo.Checked == true)
            {
                dgcargo = 'Y';
            }
            else
            {
                dgcargo = 'N';
            }
            if (chkBulk.Checked == true)
            {
                bulkvolume = 'Y';
            }
            else
            {
                bulkvolume = 'N';
            }
        }

        public void ddl()
        {
            if (ddlShipment.Text == "FCL")
            {
                shipment = 'F';
                ddlBase.Items.Clear();

                dt = invoiceobj.BaseFill();
                ddlBase.Items.Add("");
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    ddlBase.Items.Add(dt.Rows[i]["conttype"].ToString());
                    //ddlBase.DataSource = dt;
                    //ddlBase.DataTextField = "conttype";
                    //ddlBase.DataBind();
                }
                ddlBase.Items.Add("BL");

            }
            else if (ddlShipment.Text == "LCL")
            {
                shipment = 'L';
                ddlBase.Items.Clear();
                ddlBase.Items.Add("");
                ddlBase.Items.Add("BL");
                ddlBase.Items.Add("CBM");
                ddlBase.Items.Add("MT");

            }
            else if (ddlShipment.Text == "AIR")
            {
                shipment = 'A';
                ddlBase.Items.Clear();
                ddlBase.Items.Add("");
                ddlBase.Items.Add("HAWB");
                ddlBase.Items.Add("KGS");
                ddlBase.Items.Add("PERTRUCK");
                ddlBase.Items.Add("COTTON/PALLET");

            }

        }

        protected void ddlShipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddl();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        //protected void txtBrokerage_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtBrokerage.Text.Trim() != "")
        //        {

        //            collectdata();
        //            if (hdnCarrier.Value != "" && hdnPOLid.Value != "" && hdnPORid.Value != "" && hdnCommodity.Value != "")
        //            {
        //                int carrierid = Convert.ToInt32(hdnCarrier.Value.ToString());
        //                int polid = Convert.ToInt32(hdnPOLid.Value.ToString());
        //                int podid = Convert.ToInt32(hdnPORid.Value.ToString());
        //                int cargoid = Convert.ToInt16(hdnCommodity.Value.ToString());

        //                total = buyingobj.CheckDetailsExist(carrierid, cargoid, polid, podid, freight, shipment, dgcargo, bulkvolume);
        //                if (total > 0)
        //                {

        //                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "Buying Rate", "myFunction();", true);
        //                    if (hdnWasConfirmed.Value == "true")
        //                    {
        //                        btnsave.Text = "Save";
        //                        blnexist = false;
        //                    }
        //                    else
        //                    {
        //                        dt_chk = buyingobj.SelBuyingHead(total);
        //                        if (dt_chk.Rows.Count > 0)
        //                        {
        //                            try
        //                            {
        //                                dtpValidity.Text = dt_chk.Rows[0]["validtill"].ToString();
        //                                txtBrokerage.Text = dt_chk.Rows[0]["brokerage"].ToString();
        //                                txtRateby.Text = dt_chk.Rows[0]["optainedby"].ToString();
        //                                txtRemarks.Text = dt_chk.Rows[0]["remarks"].ToString();
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                string message = ex.Message.ToString();
        //                                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }
        //                        dtbuying = buyingobj.SelBuyingDetails(total);
        //                        grd.DataSource = dtbuying;
        //                        grd.DataBind();
        //                        btnsave.Text = "Update";
        //                        txtRateid.Text = Convert.ToString(total);
        //                    }
        //                }
        //            }
        //            btnsave.Enabled = true;

        //            btnAdd.Enabled = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}

        protected void txtCarrier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
               // dt_cust = Cusobj.GetLikeCustomer(txtCarrier.Text.Trim().ToUpper());
                //int txtcarrierid = da_obj_Customer.GetCustomerid((txtCarrier.Text.Trim().ToUpper()));
                obj_dt = Cusobj.GetexactCustomer(txtCarrier.Text.ToUpper(), "L");
                if (obj_dt.Rows.Count > 0 && hdnCarrier.Value!="0")
                {
                   
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Carrier');", true);
                    txtCarrier.Text = "";
                    txtCarrier.Focus();
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

        public void checkport(string port)
        {

        }

        protected void txtPor_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (portobj.GetNPortid(txtPor.Text.Trim().ToUpper()) != 0 && hdnPORid.Value!="0")
                {
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Place Of Receipt');", true);
                    txtPor.Text = "";
                    txtPor.Focus();
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

        protected void txtPol_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (portobj.GetNPortid(txtPol.Text.Trim().ToUpper()) != 0 && hdnPOLid.Value!="0")
                {

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Port Of Loading');", true);
                    txtPol.Text = "";
                    txtPol.Focus();
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

        protected void txtPod_TextChanged(object sender, EventArgs e)
        {
            try
            {
               // dt_port = portobj.GetLikePort(txtPod.Text);
                if (portobj.GetNPortid(txtPod.Text.Trim().ToUpper()) != 0 && hdnPODid.Value!="0")             
                {
                   
                }
                else
                { 
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Port Of Discharge');", true);
                    txtPod.Text = "";
                    txtPod.Focus();
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

        protected void txtFd_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (portobj.GetNPortid(txtFd.Text.Trim().ToUpper()) != 0&& hdnFDid.Value!="0")  
                {
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Place of Delivery');", true);
                    txtFd.Text = "";
                    txtFd.Focus();
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

        public int getvalidity()
        {
            try
            {
                int a, b;
                //validity = Convert.ToDateTime(dtpValidity.Text);
                validity = Convert.ToDateTime(Utility.fn_ConvertDatetime(dtpValidity.Text));
                DateTime validity1;
                //  validity1 = validity;
                // a = Logobj.GetDate().Day;
                // b = DateTime.DaysInMonth(Logobj.GetDate().Year, Logobj.GetDate().Month);
                /*if(b==31)
                {
                    b = b - 16;
                }
                else if (b == 30)
                {
                     b = b - 15;
                }
                else if (b == 28)
                {
                    b = b - 13;
                }
                else if (b == 29)
                {
                     b = b - 14;
                }*/

                // DateTime dvt = Convert.ToDateTime(Logobj.GetDate().ToString("dd/MM/yyyy"));
                DateTime dvt = Convert.ToDateTime(Logobj.GetDate().ToString("dd-MMM-yyyy"));
                //dtdateval.StartDate = DateTime.Parse(Logobj.GetDate().ToShortDateString());
                validity1 = dvt.AddDays(15);
                if (validity <= validity1)
                {
                    dtpValidity.Text = validity.ToString("dd/MM/yyyy");
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Date Again. Date format is wrong');", true);
                return 0;
            }
        }

        public void CheckEmp(string empname)
        {
            blnexist = false;
            empid = empobj.GetNEmpid(txtRateby.Text);
            if (empid == 0)
            {
                try
                {
                    txtRateby.Text = "";
                    txtRateby.Focus();
                    blnexist = true;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Select Correct Employee Name');", true);
                    return;
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        protected void checkdata()
        {
            //if (hdnCarrier.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Carrier');", true);
            //    txtCarrier.Text = "";
            //    txtCarrier.Focus();
            //    blnexist = true;
            //    return;
            //}
            //else if (hdnCommodity.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Commodity');", true);
            //    txtCommodity.Text = "";
            //    txtCommodity.Focus();
            //    blnexist = true;
            //    return;
            //}
            //else if (hdnFDid.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid FD');", true);
            //    txtFd.Text = "";
            //    txtFd.Focus();
            //    blnexist = true;
            //    return;
            //}
            //else if (hdnPODid.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid POD');", true);
            //    txtPod.Text = "";
            //    txtPod.Focus();
            //    blnexist = true;
            //    return;
            //}
            //else if (hdnPOLid.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid POL');", true);
            //    txtPol.Text = "";
            //    txtPol.Focus();
            //    blnexist = true;
            //    return;
            //}
            //else if (hdnPORid.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid POR');", true);
            //    txtPor.Text = "";
            //    txtPor.Focus();
            //    blnexist = true;
            //    return;
            //}
            //else if (HdnPreparedBy.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Employee Name');", true);
            //    txtRateby.Text = "";
            //    txtRateby.Focus();
            //    blnexist = true;
            //    return;
            //}
        

            if (ddlFreight.Text == "Freight")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Freight');", true);
                ddlFreight.Focus();
                blnexist = true;
                return;
            }
            if (ddlShipment.Text == "Shipment")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Shipment');", true);
                ddlShipment.Focus();
                blnexist = true;
                return;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPol.Text.ToUpper().Trim() == txtPod.Text.ToUpper().Trim())
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Both PoL And PoD Should not Same');", true);
                    txtPod.Text = "";
                    txtPod.Focus();
                    return;
                }
                if (ddlFreight.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Freight');", true);
                    ddlFreight.Focus();
                    return;
                }
                if (ddlShipment.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Shipment');", true);
                    ddlShipment.Focus();
                    return;
                }
                txtCarrier_TextChanged(sender, e);
                txtPor_TextChanged(sender, e);
                txtPol_TextChanged(sender, e);
                txtPod_TextChanged(sender, e);
                txtFd_TextChanged(sender, e);
                txtCommodity_TextChanged(sender, e);
                txtRateby_TextChanged(sender, e);
                
                

                if (blrr == true)
                {
                    return;
                }


                //string POR = Request.QueryString["POR"];
                //string POL = Request.QueryString["POL"];
                //string POD = Request.QueryString["POD"];
                //string FD = Request.QueryString["FD"];
                //string Frieght = Request.QueryString["Frieght"];
                //string Shipment = Request.QueryString["Shipment"];
                //string Commodity = Request.QueryString["Commodity"];
                //string Remarks = Request.QueryString["Remarks"];
                //string Preparedby = Request.QueryString["Preparedby"];



                //string empid = Session["LoginUserName"].ToString();
                //int employeeID = Convert.ToInt32(Session["LoginEmpId"]);
                //preparedby = empobj.GetEmpid(empid);
                //int custid = Convert.ToInt32(hdnCarrier.Value);
                //int cargoid = Convert.ToInt32(Commodity);
                //int polid = Convert.ToInt32(POL);
                //int podid = Convert.ToInt32(POD);
                //int porid = Convert.ToInt32(POR);
                //int fdid = Convert.ToInt32(FD);
                //int obtainedby = Convert.ToInt32(Preparedby);

                int preparedby=Convert.ToInt32(HdnPreparedBy.Value);

                //string empid = Session["LoginUserName"].ToString();
                //int employeeID = Convert.ToInt32(Session["LoginEmpId"]);
                //preparedby = empobj.GetEmpid(empid);
                int custid = Convert.ToInt32(hdnCarrier.Value);
                int cargoid = Convert.ToInt32(hdnCommodity.Value);
                int polid = Convert.ToInt32(hdnPOLid.Value);
                int podid = Convert.ToInt32(hdnPODid.Value);
                int porid = Convert.ToInt32(hdnPORid.Value);
                int fdid = Convert.ToInt32(hdnFDid.Value);
                int obtainedby = Convert.ToInt32(HdnPreparedBy.Value);


                string validtill = Request.QueryString["validTill"];
                //DateTime validity = dtpValidity.Text;

                dtpValidity.Text = validtill;



                //string empid = Session["LoginUserName"].ToString();
                //int employeeID = Convert.ToInt32(Session["LoginEmpId"]);
                //preparedby = empobj.GetEmpid(empid);
                //int custid = Convert.ToInt32(hdnCarrier.Value);
                //int cargoid = Convert.ToInt32(txtCommodity.Text);
                //int polid = Convert.ToInt32(txtPol.Text);
                //int podid = Convert.ToInt32(txtPod.Text);
                //int porid = Convert.ToInt32(txtPor.Text);
                //int fdid = Convert.ToInt32(txtFd.Text);
                //int obtainedby = Convert.ToInt32(txtRateby);
                int i;
                int count = 0;
                if (btnsave.ToolTip == "Save")
                {
                    collectdata();
                    //i = getvalidity();
                    //validity = Convert.ToDateTime(Utility.fn_ConvertDate(dtpValidity.Text));
                    CheckEmp(txtRateby.Text);
                    if(blnexist == true)
                    {
                        return;
                    }
                    checkdata();
                    if (blnexist == true)
                    {
                        return;
                    }
                    if (count == 0)
                    {
                        //if (i == 1)
                        //{
                            total = buyingobj.InsBuyingHead(custid, cargoid, polid, podid, freight, Convert.ToDateTime( dtpValidity.Text), shipment, dgcargo, bulkvolume, 0, obtainedby, preparedby, txtRemarks.Text.ToUpper().Trim(), porid, fdid);
                            txtRateid.Text = total.ToString();
                            btnsave.Enabled = false;
                            btnsave.ForeColor = System.Drawing.Color.Gray;
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Rate Id has generated as " + txtRateid.Text + ", please update charges');", true);
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 18, 1, Convert.ToInt32(Session["LoginBranchid"]), "/Rate ID: " + txtRateid.Text + "/CustID: " + custid + "/CargoID: " + cargoid + "/ V");
                            btnsave.ToolTip = "Update";
                            btn_save.Attributes["class"] = "btn btn-update1";




                            if (Request.QueryString.ToString().Contains("quotid"))
                            {
                                inquiryid = Request.QueryString["quotid"].ToString();
                                
                            }


                            buyingobj.InsertBuyingNo(Convert.ToInt32(inquiryid), Convert.ToInt32(txtRateid.Text));


                            txtCharges.Focus();
                            btncancel.ToolTip = "Cancel";
                            btn_cancel.Attributes["class"] = "btn ico-cancel";
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Date Again .Valid Till Date should not been exceed 15 days');", true);
                        //}
                        count=1;
                    }
                }

                else if (btnsave.ToolTip == "Update")
                {
                    btnsave.Enabled = true;
                    btnsave.ForeColor = System.Drawing.Color.White;
                    if (txtRateid.Text != "")
                    {
                        i = getvalidity();
                        checkdata();
                        collectdata();
                        total = Convert.ToInt32(txtRateid.Text);
                        int quotid = Convert.ToInt32( Request.QueryString["quotid"].ToString());
                        dtproduct = buyingobj.GetSelProductForRateId(total);
                        string product = dtproduct.Rows[0]["trantype"].ToString();
                        dt_quot = quotobj.CheckBuyrateForBookingFromRateId(Convert.ToInt32(txtRateid.Text), product, Convert.ToInt32(Session["LoginBranchid"].ToString()), "B");

                        if (dt_quot.Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Booking Already used this Buying .Create a New Buying.');", true);
                            return;
                        }

                        dt_quot = quotobj.CheckBuyrateForBookingFromRateId(Convert.ToInt32(txtRateid.Text), product, Convert.ToInt32(Session["LoginBranchid"].ToString()), "BB");
                        if (dt_quot.Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Inquiry Already used this Buying .Create a New Buying.');", true);
                            return;
                        }
                    }

                    if (ratevalid != true)
                    {
                        //i = getvalidity();
                         //validity = Convert.ToDateTime(Utility.fn_ConvertDate(dtpValidity.Text));
                        if (validtill == dtpValidity.Text)
                        {
                            buyingobj.UpdBuyingHead(total, custid, cargoid, polid, podid, freight, shipment, dgcargo, bulkvolume, validity, Convert.ToDouble(txtBrokerage.Text), obtainedby, preparedby, txtRemarks.Text, porid, fdid);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Date Again .Valid Till Date should not been exceed 15 days');", true);
                        }
                    }
                    else if (ratevalid == true)
                    {
                        i = getvalidity();
                        validity = Convert.ToDateTime(Utility.fn_ConvertDate(dtpValidity.Text));
                        if (i == 1)
                        {
                            buyingobj.UpdBuyingHead(Convert.ToInt32(txtRateid.Text), custid, cargoid, polid, podid, freight, shipment, dgcargo, bulkvolume, validity, Convert.ToDouble(txtBrokerage.Text), obtainedby, preparedby, txtRemarks.Text.ToUpper().Trim(), porid, fdid);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select the Date Again .Valid Till Date should not been exceed 15 days');", true);
                        }
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert(' Rate ID " + txtRateid.Text + " is updated..');", true);
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 18, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "/Rate ID: " + txtRateid.Text + "/CustID: " + custid + "/CargoID: " + cargoid + "/U");
                    btnsave.ToolTip = "Update";
                    btn_save.Attributes["class"] = "btn btn-update1";
                   
                }
                btnsave.Enabled = true;
                btnsave.ForeColor = System.Drawing.Color.White;
                btnAdd.Enabled = true;
                btnAdd.ForeColor = System.Drawing.Color.White;
              

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void txtRateid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Shipment = Request.QueryString["Shipment"];
                string rateid = Request.QueryString["Rateid"];
                string buyingno = rateid;

                if (txtRateid.Text != "" || buyingno !="")
                {
                    total = Convert.ToInt32(txtRateid.Text);
                    dtrateid = buyingobj.SelectBuyingHeadAll(Convert.ToInt32(txtRateid.Text));
                    ddlShipment.SelectedItem.Text = Shipment;

                    if (dtrateid.Rows.Count > 0)
                    {
                      
                        fillHeadWithDetails();
                        ratevalid = true;
                        Session["BuyRateid"] = null;

                    }

                    else
                    {
                        try
                        {
                            txtRateid.Text = "";
                            txtRateid.Focus();
                            if (Session["BuyRateid"] != null)
                            {
                                txtRateid.Text = Session["BuyRateid"].ToString();
                                Session["BuyRateid"] = null;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Rate ID...');", true);
                            }
                            return;
                        }
                        catch
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Rate ID...');", true);
                        }


                    }
                }


                dtbuying = buyingobj.SelBuyingDetails(Convert.ToInt32(txtRateid.Text));

                if (txtRateid.Text != "")
                {
                    if (dtbuying.Rows.Count > 0)
                    {
                        Session["Container"] = dtbuying;
                        grd.DataSource = dtbuying;
                        grd.DataBind();
                        //ImageButton btndelete = new ImageButton();
                        //foreach (GridViewRow row in grd.Rows)
                        //{
                        //    btndelete = (ImageButton)row.FindControl("ImageButton2");
                        //    btndelete.Visible = true;
                        //}

                    }
                    else
                    {

                        btncancel.ToolTip = "Cancel";
                        btn_cancel.Attributes["class"] = "btn ico-cancel";
                        btnsave.ToolTip = "Update";
                        btn_save.Attributes["class"] = "btn btn-update1";
                        btnsave.Enabled = true;
                        btnsave.ForeColor = System.Drawing.Color.White;
                        total = Convert.ToInt32(txtRateid.Text);
                        grd.DataSource = Utility.Fn_GetEmptyDataTable();
                        grd.DataBind();
                    }

                }

                
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRateid.Text != "")
                {
                    
                    try
                    {
                        dt_quot = quotobj.CheckInquiryForBookingFromQno(Convert.ToInt32(txtRateid.Text), "FE", Convert.ToInt32(Session["LoginBranchid"].ToString()), "B");
                        if (dt_quot.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Booking Already used this Buying .Create a New Buying.');", true);
                            return;
                        }

                        dt_quot = quotobj.CheckInquiryForBookingFromQno(Convert.ToInt32(txtRateid.Text), "FE", Convert.ToInt32(Session["LoginBranchid"].ToString()), "BB");
                        if (dt_quot.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Quotation Already used this Buying .Create a New Buying.');", true);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message.ToString();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                    }


                }


                if (txtCurr.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Currency Should Not Be Blank');", true);
                    txtCurr.Focus();
                    return;
                }
                else
                {  //chargeobj.GetLikeChargesName(prefix);
                  //  DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                    int cha = chargeobj.GetCurrID(txtCurr.Text);
                    if (cha == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Currency');", true);
                        txtCurr.Focus();
                        return;
                    }

                }
                txtCharges_TextChanged(sender,e);
                txtCurr_TextChanged(sender,e);
                if (blrr == true)
                {
                    return;
                }
                if (txtCharges.Text != "")
                {// || ddlBase.SelectedIndex==0

                   // if (ddlBase.Text == "Base / Unit")
                    if (ddlBase.SelectedIndex == 0 || ddlBase.SelectedItem.Text == "Base / Unit" || ddlBase.SelectedValue=="0")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(Page), "alert", "alertify.alert('Please select the Base / Units');", true);
                        ddlBase.Focus();
                        return;
                    }
                    total = Convert.ToInt32(txtRateid.Text);
                    txtCurr.Text = txtCurr.Text.ToUpper();
                    if (btnAdd.ToolTip == "Add")
                    {


                        int chargeid;
                        chargeid = chargeobj.GetChargeid(txtCharges.Text);
                        hdnChargeid.Value = chargeid.ToString();

                        if (hdnChargeid.Value == "")
                        {
                            hdnChargeid.Value = chargeid.ToString();
                        }
                        dt_char = buyingobj.BuyingChargebaseExist(total, chargeid, ddlBase.Text);
                        if (dt_char.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Charge Details Already Exists.');", true);
                            bottomValuesClear();
                            return;
                        }
                        else
                        {

                            buyingobj.InsBuyingDetails(total, chargeid, txtCurr.Text.ToUpper().Trim(), Convert.ToDouble(txtRate.Text), ddlBase.Text);
                            dtbuying = buyingobj.SelBuyingDetails(total);
                            Session["Container"] = dtbuying;
                            grd.DataSource = dtbuying;
                            grd.DataBind();
                            bottomValuesClear();
                            
                        }

                    }
                    else if (btnAdd.ToolTip == "Update")
                    {
                        int chargeid;
                        chargeid = chargeobj.GetChargeid(txtCharges.Text);
                        hdnChargeid.Value = chargeid.ToString();
                        if (blnexist == false)
                        {
                            if (ratevalid != true)
                            {
                                buyingobj.UpdBuyingDetails(total, chargeid, txtCurr.Text.ToUpper().Trim(), Convert.ToDouble(txtRate.Text), ddlBase.SelectedItem.Text);
                                dtbuying = buyingobj.SelBuyingDetails(total);
                                Session["Container"] = dtbuying;
                                grd.DataSource = dtbuying;
                                grd.DataBind();
                                bottomValuesClear();
                            }
                            else if (ratevalid == true)
                            {
                                buyingobj.UpdBuyingDetails(Convert.ToInt32(txtRateid.Text), chargeid, txtCurr.Text.ToUpper().Trim(), Convert.ToDouble(txtRate.Text), ddlBase.Text);
                                dtbuying = buyingobj.SelBuyingDetails(Convert.ToInt32(txtRateid.Text));
                                Session["Container"] = dtbuying;
                                grd.DataSource = dtbuying;
                                grd.DataBind();
                                bottomValuesClear();

                            }
                        }
                        else if (blnexist == true)
                        {
                            if (ratevalid != true)
                            {
                                buyingobj.UpdBuyingDetails(total, chargeid, txtCurr.Text.ToUpper().Trim(), Convert.ToDouble(txtRate.Text), ddlBase.Text);
                                dtbuying = buyingobj.SelBuyingDetails(total);
                                Session["Container"] = dtbuying;
                                grd.DataSource = dtbuying;
                                grd.DataBind();
                                bottomValuesClear();
                            }
                            else if (ratevalid == true)
                            {
                                buyingobj.UpdBuyingDetails(Convert.ToInt32(txtRateid.Text), chargeid, txtCurr.Text.ToUpper().Trim(), Convert.ToDouble(txtRate.Text), ddlBase.Text);
                                dtbuying = buyingobj.SelBuyingDetails(Convert.ToInt32(txtRateid.Text));
                                Session["Container"] = dtbuying;
                                grd.DataSource = dtbuying;
                                grd.DataBind();
                                bottomValuesClear();
                            }
                        }
                    }
                    Session["Container"] = dtbuying;
                    btnAdd.ToolTip = "Add";
                    btn_add1.Attributes["class"] = "btn ico-add";
                    txtCharges.Enabled = true;
                    ddlBase.Enabled = true;
                    //ImageButton btndelete = new ImageButton();
                    //foreach (GridViewRow row in grd.Rows)
                    //{

                    //    btndelete = (ImageButton)row.FindControl("ImageButton2");
                    //    btndelete.Visible = true;

                    //}

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string username = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "chargename"));
                //ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("ImageButton2");
                //lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox('" + username + "')");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        //protected void ImageButton2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtRateid.Text != "")
        //        {
        //            dt_quot = quotobj.CheckQuotForBookingFromQno(Convert.ToInt32(txtRateid.Text), "FE", Convert.ToInt32(Session["LoginBranchid"].ToString()), "B");
        //            if (dt_quot.Rows.Count > 0)
        //                try
        //                {

        //                    return;
        //                }
        //                catch (Exception ex)
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Booking Already used this Buying .Create a New Buying.');", true);

        //                }

        //            dt_quot = quotobj.CheckQuotForBookingFromQno(Convert.ToInt32(txtRateid.Text), "FE", Convert.ToInt32(Session["LoginBranchid"].ToString()), "BB");
        //            if (dt_quot.Rows.Count > 0)
        //                try
        //                {
        //                    return;
        //                }
        //                catch (Exception ex)
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Quotation Already used this Buying .Create a New Buying.');", true);

        //                }
        //        }

        //        ImageButton lb = (ImageButton)sender;
        //        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        //        int RowIndex = gvRow.RowIndex;
        //        int chargeid, currid;
        //        chargeid = chargeobj.GetChargeid(grd.Rows[RowIndex].Cells[0].Text);


        //        //int index = grd.SelectedRow.RowIndex;
        //        txtCharges.Text = grd.Rows[RowIndex].Cells[0].Text.Replace("&amp;", "&");
        //        Session["chargename"] = txtCharges.Text;
        //        txtCurr.Text = grd.Rows[RowIndex].Cells[1].Text;
        //        txtRate.Text = grd.Rows[RowIndex].Cells[2].Text;
        //        ddlBase.SelectedValue = grd.Rows[RowIndex].Cells[3].Text;
        //        ddlBase.Enabled = false;

        //        chargeid = chargeobj.GetChargeid(txtCharges.Text.Replace("&amp;", "&"));
        //        hdnChargeid.Value = chargeid.ToString();

        //        currid = chargeobj.GetCurrID(txtCurr.Text);
        //        hdnCurrid.Value = currid.ToString();


        //        if (hdnDelete.Value == "true")
        //        {
        //            blndelete = true;

        //            if (txtRateid.Text != "")
        //            {
        //                total = Convert.ToInt32(txtRateid.Text);
        //            }
        //            if (total != 0)
        //            {
        //                try
        //                {
        //                    DataTable dts = new DataTable();
        //                    buyingobj.DelBuyingDetail(total, chargeid);

        //                    dtbuying = buyingobj.SelBuyingDetails(Convert.ToInt32(txtRateid.Text));

        //                    grd.DataSource = dtbuying;
        //                    grd.DataBind();
        //                }
        //                catch (Exception ex)
        //                {
        //                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Details Deleted...", true);

        //                }

        //                //  txtRateid_TextChanged(sender, e);
        //                bottomValuesClear();
        //                btnAdd.Text = "Add";
        //                txtCharges.Enabled = true;
        //                if (grd.Rows.Count == 0)
        //                {

        //                    buyingobj.UpdBuyHeadDelYes(total);


        //                }
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Invalid Rate ID", true);
        //                return;
        //            }


        //        }
        //        else
        //        {
        //            btnAdd.Text = "Upd";
        //            btnAdd.Enabled = true;
        //            txtCharges.Enabled = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}


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

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (btncancel.ToolTip == "Cancel")
            {
                JobInput.Text = "";
                bottomValuesClear();
                topValuesClear();
                //grd.DataSource = null;
                //grd.DataBind();
                grd.DataSource = Utility.Fn_GetEmptyDataTable();
                grd.DataBind();
                ddlShipment.Enabled = true;
                btnsave.ToolTip = "Save";
                btn_save.Attributes["class"] = "btn ico-save";
                btncancel.ToolTip = "Back";
                btn_cancel.Attributes["class"] = "btn ico-back";
               
                //ddlBase.Items.Clear();
                //ddlBase.Items.Add("Base");
                ddlBase.SelectedIndex = 0;
                txtCharges.Enabled = true;
                ddlBase.Enabled = true;
            }
            else
            {
                //this.Response.End();
                if (Session["home"]!=null)
                {
                    if(Session["home"].ToString() == "SA")
                    {
                        Response.Redirect("../Home/SalesHome.aspx");
                    }
                }
                else
                {
                    this.Response.End();
                }
            }
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                shipmenttype();
                if (txtRateid.Text != "")
                {
                    int custid = Convert.ToInt32(hdnCarrier.Value);
                    int cargoid = Convert.ToInt32(hdnCommodity.Value);
                    hdnRateid.Value = txtRateid.Text;
                    int chargeid = chargeobj.GetChargeid(txtCharges.Text);


                    if (txtRateid.Text != "")
                    {
                        dt_quot = quotobj.CheckQuotForBookingFromQno(Convert.ToInt32(txtRateid.Text), "FE", Convert.ToInt32(Session["LoginBranchid"].ToString()), "B");
                        if (dt_quot.Rows.Count > 0)
                        {
                            bottomValuesClear();
                            //ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "logix", "alertify.alert('Booking Already used this Buying .Create a New Buying.');", true);
                            ScriptManager.RegisterStartupScript(btndelete, typeof(ImageButton), "logix", "alertify.alert('Booking Already used this Buying .Create a New Buying.');", true);
                            return;
                        }
                        dt_quot = quotobj.CheckQuotForBookingFromQno(Convert.ToInt32(txtRateid.Text), "FE", Convert.ToInt32(Session["LoginBranchid"].ToString()), "BB");
                        if (dt_quot.Rows.Count > 0)
                        {
                            bottomValuesClear();
                            ScriptManager.RegisterStartupScript(btndelete, typeof(ImageButton), "logix", "alertify.alert('Quotation Already used this Buying .Create a New Buying.');", true);

                            return;
                        }
                    }

                    buyingobj.DelBuyingDetail(Convert.ToInt32(hdnRateid.Value), chargeid);
                    dtbuying = buyingobj.SelBuyingDetails(Convert.ToInt32(hdnRateid.Value));
                    grd.DataSource = dtbuying;

                    if (grd.Rows.Count == 0)
                    {

                        buyingobj.UpdBuyHeadDelYes(Convert.ToInt32(hdnRateid.Value));
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Details Deleted...", true);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 18, 1, Convert.ToInt32(Session["LoginBranchid"]), "/CustID: " + custid + "/CargoID: " + cargoid + "/ D");

                        return;
                    }


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Invalid Rate ID..", true);
                    return;
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
                Panel4.Visible = false;

                Panel3.Visible = true;
                grdmain.Visible = true;
                dt_grd = buyingobj.GetRate();
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
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "alert", "alertify.alert('Buying Not Available');", true);
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

        protected void grdmain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = grdmain.SelectedRow.RowIndex;
                txtRateid.Text = grdmain.SelectedRow.Cells[0].Text;

                dtrateid = buyingobj.SelectBuyingHeadAll(Convert.ToInt32(txtRateid.Text));
                if (dtrateid.Rows.Count > 0)
                {

                    fillHeadWithDetails();
                    ratevalid = true;
                }

                else
                {
                    try
                    {
                        txtRateid.Text = "";
                        txtRateid.Focus();
                        return;
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Rate ID...');", true);
                    }


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        public void fillHeadWithDetails()
        {
            try
            {
                txtCarrier.Text = dtrateid.Rows[0]["customername"].ToString();
                txtPol.Text = dtrateid.Rows[0]["pol"].ToString();
                txtPod.Text = dtrateid.Rows[0]["pod"].ToString();
                txtCommodity.Text = dtrateid.Rows[0]["cargotype"].ToString();
                freight = Convert.ToChar(dtrateid.Rows[0]["freight"].ToString());
                shipment = Convert.ToChar(dtrateid.Rows[0]["shipment"].ToString());
                dgcargo = Convert.ToChar(dtrateid.Rows[0]["dgcargo"].ToString());
                bulkvolume = Convert.ToChar(dtrateid.Rows[0]["bulkvolume"].ToString());

              


                shipmenttype();

                if (freight == 'P')
                {
                    ddlFreight.SelectedValue = "PrePaid";
                }
                else if (freight == 'C')
                {
                    ddlFreight.SelectedValue = "Collect";
                }
                ddlShipment.Enabled = false;
                if (shipment == 'F')
                {
                    ddlShipment.SelectedValue = "FCL";
                }
                else if (shipment == 'L')
                {
                    ddlShipment.SelectedValue = "LCL";
                }
                else if (shipment == 'A')
                {
                    ddlShipment.SelectedValue = "AIR";
                }
                if (dgcargo == 'Y')
                {
                    chkDGCargo.Checked = true;
                }
                else
                {
                    chkDGCargo.Checked = false;
                }
                if (bulkvolume == 'Y')
                {
                    chkBulk.Checked = true;
                }
                else
                {
                    chkBulk.Checked = false;

                }
                txtBrokerage.Text = dtrateid.Rows[0]["brokerage"].ToString();
                txtRateby.Text = dtrateid.Rows[0]["obtainedby"].ToString();
                txtRemarks.Text = dtrateid.Rows[0]["remarks"].ToString();
                txtPor.Text = dtrateid.Rows[0]["por"].ToString();
                txtFd.Text = dtrateid.Rows[0]["fd"].ToString();
                dtpValidity.Text = Utility.fn_ConvertDate(dtrateid.Rows[0]["validtill"].ToString());
                hdnCarrier.Value = dtrateid.Rows[0]["linerid"].ToString();
                hdnPORid.Value = dtrateid.Rows[0]["porid"].ToString();
                hdnPOLid.Value = dtrateid.Rows[0]["polid"].ToString();
                hdnPODid.Value = dtrateid.Rows[0]["podid"].ToString();
                hdnFDid.Value = dtrateid.Rows[0]["fdid"].ToString();
                hdnRateid.Value = dtrateid.Rows[0]["linerid"].ToString();
                hdnCommodity.Value = dtrateid.Rows[0]["cargoid"].ToString();
                HdnPreparedBy.Value = dtrateid.Rows[0]["obtid"].ToString();
                bottomValuesClear();
                btncancel.ToolTip = "Cancel";
                btn_cancel.Attributes["class"] = "btn ico-cancel";
                btnsave.ToolTip = "Update";
                btn_save.Attributes["class"] = "btn btn-update1";
                btnsave.Enabled = true;
                btnsave.ForeColor = System.Drawing.Color.White;
                dtbuying = buyingobj.SelBuyingDetails(Convert.ToInt32(txtRateid.Text));
                if (dtbuying.Rows.Count > 0)
                {
                    Session["Container"] = dtbuying;
                    grd.DataSource = dtbuying;
                    grd.DataBind();
                    //ImageButton btndelete = new ImageButton();
                    //foreach (GridViewRow row in grd.Rows)
                    //{
                    //    btndelete = (ImageButton)row.FindControl("ImageButton2");
                    //    btndelete.Visible = true;
                    //}

                }
                else
                {

                    btncancel.ToolTip = "Cancel";
                    btn_cancel.Attributes["class"] = "btn ico-cancel";
                    btnsave.ToolTip = "Update";
                    btn_save.Attributes["class"] = "btn btn-update1";
                    btnsave.Enabled = true;
                    btnsave.ForeColor = System.Drawing.Color.White;
                    total = Convert.ToInt32(txtRateid.Text);
                    grd.DataSource = Utility.Fn_GetEmptyDataTable();
                    grd.DataBind();
                }

             //   btnAdd.Attributes["class"] = "btn btn-add1";
                btnAdd.ToolTip = "Add";
                btn_add1.Attributes["class"] = "btn ico-add";
                btnAdd.Enabled = true;
                btnAdd.ForeColor = System.Drawing.Color.White;
                btnsave.Enabled = true;
                btnsave.ForeColor = System.Drawing.Color.White;
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
              //  DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                DataTable dtCharge = new DataTable();            

                int chargeid = chargeobj.GetChargeid(txtCharges.Text.Trim().ToUpper());
                if (chargeid != 0 && hdnChargeid.Value!="0")                
                {
                    
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Charges');", true);
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

        protected void btnview_Click(object sender, EventArgs e)
        {
            //checkdata();
            int custid = Convert.ToInt32(hdnCarrier.Value);
            int cargoid = Convert.ToInt32(hdnCommodity.Value);
            string str_sf = "";
            string Str_P = "";
            string str_RptName = "";
            string str_frmname = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";

            if (txtCarrier.Text.ToString() == "")
            {
                try
                {
                    str_frmname = "Buying";
                    str_RptName = "BuyingReg.rpt";
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + Str_P + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "BuyingRates", str_Script, true);
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 18, 3, Convert.ToInt32(Session["LoginBranchid"]), "/CustID: " + custid + "/CargoID: " + cargoid + "/ V");
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                }
            }
            else if (txtCarrier.Text.ToString() != "")
            {
                try
                {
                    str_frmname = "Buying";
                    str_RptName = "Buying.rpt";
                    Session["str_sfs"] = "{BuyingHead.rateid}=" + txtRateid.Text;
                    str_sf = "{BuyingHead.rateid}=" + txtRateid.Text;
                    Session["str_sp"] = "";
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + Str_P + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                   // str_Script = "window.open('../Reportasp/Buying.aspx?SFormula=" + txtRateid.Text + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "BuyingRates", str_Script, true);
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 18, 3, Convert.ToInt32(Session["LoginBranchid"]), "/CustID: " + custid + "/CargoID: " + cargoid + "/ V");
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                }
            }
        }

        protected void btn_yes_Click(object sender, EventArgs e)
        {

        }

        protected void btn_no_Click(object sender, EventArgs e)
        {
            return;
        }



        protected void grdmain_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            grdmain.PageIndex = e.NewPageIndex;
            grdmain.Visible = true;
            grdmain.DataSource = (DataTable)ViewState["Rate"];
            grdmain.DataBind();
            //popBuying.Visible = true;
            this.popupBuying.Show();
            Panel3.Visible = true;
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
                    obj_dt = (DataTable)Session["Container"];
                    int RowIndex = gvRow.RowIndex;
                    int chargeid, currid;
                    chargeid = chargeobj.GetChargeid(grd.Rows[RowIndex].Cells[0].Text);
                    if (txtRateid.Text != "")
                    {
                        dt_quot = quotobj.CheckQuotForBookingFromQno(Convert.ToInt32(txtRateid.Text), "FE", Convert.ToInt32(Session["LoginBranchid"].ToString()), "B");
                        if (dt_quot.Rows.Count > 0)
                        {
                            bottomValuesClear();
                            //ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "logix", "alertify.alert('Booking Already used this Buying .Create a New Buying.');", true);
                            ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "logix", "alertify.alert('Booking Already used this Buying .Create a New Buying.');", true);
                            return;
                        }
                        dt_quot = quotobj.CheckQuotForBookingFromQno(Convert.ToInt32(txtRateid.Text), "FE", Convert.ToInt32(Session["LoginBranchid"].ToString()), "BB");
                        if (dt_quot.Rows.Count > 0)
                        {
                            bottomValuesClear();
                            ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "logix", "alertify.alert('Quotation Already used this Buying .Create a New Buying.');", true);

                            return;
                        }
                    }
                    //int index = grd.RowIndex;
                    txtCharges.Text = grd.Rows[RowIndex].Cells[0].Text.Replace("&amp;", "&");
                    //Session["chargename"] = txtCharges.Text;
                    //txtCurr.Text = grd.Rows[RowIndex].Cells[1].Text;
                    //txtRate.Text = grd.Rows[RowIndex].Cells[2].Text;
                    //ddlBase.SelectedValue = grd.Rows[RowIndex].Cells[3].Text;
                    //ddlBase.Enabled = false;

                    chargeid = chargeobj.GetChargeid(txtCharges.Text.Replace("&amp;", "&"));
                    hdnChargeid.Value = chargeid.ToString();

                    currid = chargeobj.GetCurrID(txtCurr.Text);
                    hdnCurrid.Value = currid.ToString();
                    total = Convert.ToInt32(txtRateid.Text);
                    string ddlbasevalue= grd.Rows[RowIndex].Cells[3].Text;
                    DataTable dts = new DataTable();
                    buyingobj.DelBuyingDetailnew(total, chargeid, ddlbasevalue);

                    //dtbuying = buyingobj.SelBuyingDetails(Convert.ToInt32(txtRateid.Text));
                    obj_dt.Rows[gvRow.RowIndex].Delete();
                    obj_dt.AcceptChanges();

                    grd.DataSource = obj_dt;
                    grd.DataBind();
                    Session["Container"] = obj_dt;
                    bottomValuesClear();
                    ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "logix", "Details Deleted...", true);
                    //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 18, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()),, "/CustID: " + intcustid + "/CargoID: " + cargoid + "/ D");
                    //if (hdnDelete.Value == "true")
                    //{
                    //    blndelete = true;

                    //    if (txtRateid.Text != "")
                    //    {
                    //        total = Convert.ToInt32(txtRateid.Text);
                    //    }
                    //    if (total != 0)
                    //    {
                    //        try
                    //        {
                    //            DataTable dts = new DataTable();
                    //            buyingobj.DelBuyingDetail(total, chargeid);

                    //            dtbuying = buyingobj.SelBuyingDetails(Convert.ToInt32(txtRateid.Text));

                    //            grd.DataSource = dtbuying;
                    //            grd.DataBind();
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "logix", "Details Deleted...", true);

                    //        }

                    //        //  txtRateid_TextChanged(sender, e);
                    //        bottomValuesClear();
                    //        btnAdd.Text = "Add";
                    //        txtCharges.Enabled = true;
                    //        if (grd.Rows.Count == 0)
                    //        {

                    //            buyingobj.UpdBuyHeadDelYes(total);


                    //        }
                    //    }
                    //    else
                    //    {
                    //        ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "logix", "Invalid Rate ID", true);
                    //        return;
                    //    }


                    //}
                    //else
                    //{
                    //    btnAdd.Text = "Update";
                    //    btnAdd.Enabled = true;
                    //    txtCharges.Enabled = false;
                    //}
                }
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

        protected void grd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void txtCommodity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPort = new DataTable();
              //  DataAccess.Masters.MasterCargo cargoobj = new DataAccess.Masters.MasterCargo();               
                int cargoid = cargoobj.GetCargoid(txtCommodity.Text.Trim().ToUpper());
                if (cargoid == 0 || hdnCommodity.Value=="0")               
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Commodity');", true);
                    txtCommodity.Text = "";
                    txtCommodity.Focus();
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

        protected void txtRateby_TextChanged(object sender, EventArgs e)
        {
            try
            {
              //  DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();              
                int empid = empobj.GetNEmpid(txtRateby.Text.Trim().ToUpper());

               

                if (empid != 0 && HdnPreparedBy.Value != "0")                
                {
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Rate Obtained By');", true);
                    txtRateby.Text = "";
                    txtRateby.Focus();
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

        protected void txtCurr_TextChanged(object sender, EventArgs e)
        {
            try
            {
               // DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                DataTable dtCharge = new DataTable();              
                int currid = chargeobj.GetCurrID(txtCurr.Text.Trim().ToUpper());
                if (currid != 0 || hdnCurrid.Value!="0")               
                {
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Currency');", true);
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
          
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 18, "Buying", txtRateid.Text, txtRateid.Text, "");  //"/Rate ID: " +
            if (txtRateid.Text != "")
            {
                JobInput.Text = txtRateid.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }


      


        //protected void Btn_reuse_Click(object sender, EventArgs e)
        //{
        //    //LinkButton1_Click(sender, e);
        //    try
        //    {
        //        Panel4.Visible = true;
        //        GrdResue.Visible = true;
        //        Panel3.Visible = false;
        //        grdmain.Visible = false;
        //        dt_grd = buyingobj.GetRate();
        //        if (dt_grd.Rows.Count > 0)
        //        {
        //            this.popupBuying.Show();
        //            GrdResue.DataSource = dt_grd;
        //            GrdResue.DataBind();
        //            ViewState["reuse"] = dt_grd;

        //        }
        //        //popBuying.Visible = true;

        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "alert", "alertify.alert('Buying Not Available');", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //    txtRateid.Text = "";
        //    btnsave.ToolTip = "Save";
        //    btn_save.Attributes["class"] = "btn ico-save";

        //}

        protected void GrdResue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdResue.PageIndex = e.NewPageIndex;
            GrdResue.Visible = true;
            GrdResue.DataSource = (DataTable)ViewState["reuse"];
            GrdResue.DataBind();
            //popBuying.Visible = true;
            this.popupBuying.Show();
            Panel4.Visible = true;
        }

        protected void GrdResue_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdResue, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GrdResue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = GrdResue.SelectedRow.RowIndex;
                txtRateid.Text = GrdResue.SelectedRow.Cells[0].Text;

                dtrateid = buyingobj.SelectBuyingHeadAll(Convert.ToInt32(txtRateid.Text));
                if (dtrateid.Rows.Count > 0)
                {

                    fillHeadWithDetailsreuse();
                    ratevalid = true;
                    txtRateid.Text = "";
                    txtRateid.Focus();
                }

                else
                {
                    try
                    {
                        txtRateid.Text = "";
                        txtRateid.Focus();
                        return;
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Rate ID...');", true);
                    }


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        public void fillHeadWithDetailsreuse()
        {
            try
            {
                txtCarrier.Text = dtrateid.Rows[0]["customername"].ToString();
                txtPol.Text = dtrateid.Rows[0]["pol"].ToString();
                txtPod.Text = dtrateid.Rows[0]["pod"].ToString();
                txtCommodity.Text = dtrateid.Rows[0]["cargotype"].ToString();
                freight = Convert.ToChar(dtrateid.Rows[0]["freight"].ToString());
                shipment = Convert.ToChar(dtrateid.Rows[0]["shipment"].ToString());
                dgcargo = Convert.ToChar(dtrateid.Rows[0]["dgcargo"].ToString());
                bulkvolume = Convert.ToChar(dtrateid.Rows[0]["bulkvolume"].ToString());
                shipmenttype();

                if (freight == 'P')
                {
                    ddlFreight.SelectedValue = "PrePaid";
                }
                else if (freight == 'C')
                {
                    ddlFreight.SelectedValue = "Collect";
                }
                ddlShipment.Enabled = true;
                if (shipment == 'F')
                {
                    ddlShipment.SelectedValue = "FCL";
                }
                else if (shipment == 'L')
                {
                    ddlShipment.SelectedValue = "LCL";
                }
                else if (shipment == 'A')
                {
                    ddlShipment.SelectedValue = "AIR";
                }
                if (dgcargo == 'Y')
                {
                    chkDGCargo.Checked = true;
                }
                else
                {
                    chkDGCargo.Checked = false;
                }
                if (bulkvolume == 'Y')
                {
                    chkBulk.Checked = true;
                }
                else
                {
                    chkBulk.Checked = false;

                }
                txtBrokerage.Text = dtrateid.Rows[0]["brokerage"].ToString();
                txtRateby.Text = dtrateid.Rows[0]["obtainedby"].ToString();
                txtRemarks.Text = dtrateid.Rows[0]["remarks"].ToString();
                txtPor.Text = dtrateid.Rows[0]["por"].ToString();
                txtFd.Text = dtrateid.Rows[0]["fd"].ToString();
                dtpValidity.Text = Utility.fn_ConvertDate(dtrateid.Rows[0]["validtill"].ToString());
                hdnCarrier.Value = dtrateid.Rows[0]["linerid"].ToString();
                hdnPORid.Value = dtrateid.Rows[0]["porid"].ToString();
                hdnPOLid.Value = dtrateid.Rows[0]["polid"].ToString();
                hdnPODid.Value = dtrateid.Rows[0]["podid"].ToString();
                hdnFDid.Value = dtrateid.Rows[0]["fdid"].ToString();
                hdnRateid.Value = dtrateid.Rows[0]["linerid"].ToString();
                hdnCommodity.Value = dtrateid.Rows[0]["cargoid"].ToString();
                HdnPreparedBy.Value = dtrateid.Rows[0]["obtid"].ToString();
                bottomValuesClear();
                btncancel.ToolTip = "Cancel";
                btn_cancel.Attributes["class"] = "btn ico-cancel";
                btnsave.ToolTip = "Save";
                btn_save.Attributes["class"] = "btn ico-save";
                btnsave.Enabled = true;
                btnsave.ForeColor = System.Drawing.Color.White;
                grd.DataSource = new DataTable();
                grd.DataBind();
                /*  dtbuying = buyingobj.SelBuyingDetails(Convert.ToInt32(txtRateid.Text));
                  if (dtbuying.Rows.Count > 0)
                  {
                      Session["Container"] = dtbuying;
                      grd.DataSource = dtbuying;
                      grd.DataBind();
                      //ImageButton btndelete = new ImageButton();
                      //foreach (GridViewRow row in grd.Rows)
                      //{
                      //    btndelete = (ImageButton)row.FindControl("ImageButton2");
                      //    btndelete.Visible = true;
                      //}

                  }
                  else
                  {

                      btncancel.ToolTip = "Cancel";
                      btn_cancel.Attributes["class"] = "btn ico-cancel";
                      btnsave.ToolTip = "save";
                      btn_save.Attributes["class"] = "btn ico-save";
                      btnsave.Enabled = true;
                      btnsave.ForeColor = System.Drawing.Color.White;
                      total = Convert.ToInt32(txtRateid.Text);
                      grd.DataSource = Utility.Fn_GetEmptyDataTable();
                      grd.DataBind();
                  }
                  */
                //   btnAdd.Attributes["class"] = "btn btn-add1";
                btnAdd.ToolTip = "Add";
                btn_add1.Attributes["class"] = "btn ico-add";
                btnAdd.Enabled = true;
                btnAdd.ForeColor = System.Drawing.Color.White;
                btnsave.Enabled = true;
                btnsave.ForeColor = System.Drawing.Color.White;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Btn_reuse_Click1(object sender, EventArgs e)
        {
            //LinkButton1_Click(sender, e);
            try
            {
                Panel4.Visible = true;
                GrdResue.Visible = true;
                Panel3.Visible = false;
                grdmain.Visible = false;
                dt_grd = buyingobj.GetRate();
                if (dt_grd.Rows.Count > 0)
                {
                    this.popupBuying.Show();
                    GrdResue.DataSource = dt_grd;
                    GrdResue.DataBind();
                    ViewState["reuse"] = dt_grd;

                }
                //popBuying.Visible = true;

                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "alert", "alertify.alert('Buying Not Available');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txtRateid.Text = "";
            btnsave.ToolTip = "Save";
            btn_save.Attributes["class"] = "btn ico-save";
        }

        protected void grd_PreRender(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                grd.UseAccessibleHeader = true;
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }


        
    }
}