using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Diagnostics;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;

namespace logix.ShipmentDetails
{
    public partial class ISFDetails : System.Web.UI.Page
    {
        Boolean blnerr = false;
        string strpor, strpol, strpod, strfd;
        string stradr, strphone, stremail, strptc, strfax;
        DataAccess.ForwardingExports.BLDetails FEBLobj = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.ForwardingExports.ISFDetails objisf = new DataAccess.ForwardingExports.ISFDetails();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataTable dtbl = new DataTable();
        DataTable dtjob = new DataTable();
        DataTable dtCust = new DataTable();
        DataTable dtbldet = new DataTable();
        DataTable Dtisfdtls = new DataTable();
        DataTable dtbook = new DataTable();
        DataTable dtcnf = new DataTable();
        DataTable dtcondt = new DataTable();
        DataTable dtbranch = new DataTable();
        public int importerid, intbuyer, intconsignee, supplierid, intshipper, intbranch, intstuff, intcha, intagentid, intmlo, intConsol, intShipTo, intmultishipadd;
        int jobno;
        string strmloname, strvslname, strvoyname, strmblno;
        string strmarks, strcarcgo, strcon, strsupplier, Blno;
        DataTable dtblbuy = new DataTable();
        string strcustype, strbuyer;
        string custype, strshipname, strchaname;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        DataTable newadd = new DataTable();
        DataTable Dt = new DataTable();
        DataTable dtimpwd = new DataTable();
        string stragentname, strimpname, straddr, eta, etd, strbooking;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                FEBLobj.GetDataBase(Ccode);
                objisf.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                //LogObj.GetDataBase(Ccode);
                //da_obj_AEJobobj.GetDataBase(Ccode);
                //LogObj.GetDataBase(Ccode);


            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnSave);
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnclose);
                if (!IsPostBack)
                {
                    try
                    {
                        
                        Ctrl_List = txtBlNo.ID + "~" + txtAmsHBL.ID + "~" + txtSCAc.ID + "~" + txtStuff.ID + "~" + txtConsolid.ID + "~" + txtShipTo.ID + "~" + txtImporter.ID
                            + "~" + txtImporterAdd.ID + "~" + txtBuyer.ID + "~" + txtBuyerAdd.ID + "~" + txtConsignee.ID + "~" + txtConsigneeAdd.ID + "~" + txtSupplier.ID
                           + "~" + txtSupplierAdd.ID + "~" + txtShipper.ID + "~" + txtShipperAdd.ID + "~" + txtExpFor.ID + "~" + txtExpForAdd.ID + "~" + txtCha.ID + "~" + txtChaAdd.ID + "~" + txtImpFor.ID + "~" + txtImpForAdd.ID;
                        Msg_List = "BL NO~AMS HBL #~SCAC #~ Stuff location Name~Consolidator Name~Ship To~Importer Name~Importer address~Buyer Name~Buyer Address~Consignee Name~Consignee Address ~Supplier Name~Supplier Address~Shipper Name~Shipper Address~Export Name~Export Address ~C H A Name~C H A Address~Import Name~Import Address";
                        Dtype_List = "String~String~String~String~String~String~String~String~String~String~String~String~String~string~string~string~string~string~string~string~string~string";
                        btnSave.Attributes.Add("onclick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                        Utility.Fn_CheckUserRights(str_Uiid, btnSave, null, null);
                        //btnclose.Text = "Cancel";
                        btnclose.ToolTip = "Cancel";
                        btnclose1.Attributes["class"] = "btn ico-cancel";
                        get_grd();

                        
                    }
                    catch (Exception ex)
                    {
                        //string message = ex.Message.ToString();
                        //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../FormMain.aspx','_top');", true);
                    }

                }
                Session["str_sfs"] = "";
                Session["str_sp"] = "";

             
              

            if(txtBlNo.Text !="")
            {
                btnDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete this Details?');"; 
            }
        }

        [WebMethod]
        public static List<string> GetBLNO(string prefix)
        {
            List<string> blno = new List<string>();
            DataTable dtblno = new DataTable();
            DataAccess.ForwardingExports.BLDetails FEBLobj = new DataAccess.ForwardingExports.BLDetails();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            FEBLobj.GetDataBase(Ccode);
            dtblno = FEBLobj.GetLikeOTHERBLDetails(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            blno = Utility.Fn_DatatableToList(dtblno, "blno", "blno");
            return blno;
        }
        [WebMethod]
        public static List<string> GetBuyer(string prefix)
        {
            List<string> blno = new List<string>();
            DataTable dtblbuy = new DataTable();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            string strcustype = "C";
            dtblbuy = customerobj.GetLikeCustomer(prefix, strcustype);
            blno = Utility.Fn_DatatableToList(dtblbuy, "customer", "customerid");
            return blno;
        }
        [WebMethod]
        public static List<string> GetImpForwarder(string prefix)
        {
            List<string> blno = new List<string>();
            DataTable dtblbuy = new DataTable();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            string strcustype = "P";
            dtblbuy = customerobj.GetLikeCustomer(prefix, strcustype);
            blno = Utility.Fn_DatatableToList(dtblbuy, "customer", "customerid");
            return blno;
        }
        [WebMethod]
        public static List<string> GetSupplier(string prefix)
        {
            List<string> blno = new List<string>();
            DataTable dtblbuy = new DataTable();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            string strcustype = "C";
            dtblbuy = customerobj.GetLikeCustomer(prefix, strcustype);
            blno = Utility.Fn_DatatableToList(dtblbuy, "customer", "customerid");
            return blno;
        }
        [WebMethod]
        public static List<string> GetShipto(string prefix)
        {
            List<string> blno = new List<string>();
            DataTable dtblbuy = new DataTable();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            string strcustype = "C";
            dtblbuy = customerobj.GetLikeCustomer(prefix, strcustype);
            blno = Utility.Fn_DatatableToList(dtblbuy, "customer", "customerid");
            return blno;
        }

        [WebMethod]
        public static List<string> Getconsolid(string prefix)
        {
            List<string> blno = new List<string>();
            DataTable dtblbuy = new DataTable();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            string strcustype = "C";
            dtblbuy = customerobj.GetLikeCustomer(prefix, strcustype);
            blno = Utility.Fn_DatatableToList(dtblbuy, "customername", "customerid");
            return blno;
        }
        [WebMethod]
        public static List<string> GetStuff(string prefix)
        {
            List<string> blno = new List<string>();
            DataTable dtblbuy = new DataTable();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            string strcustype = "C";
            dtblbuy = customerobj.GetLikeCustomer(prefix, strcustype);
            blno = Utility.Fn_DatatableToList(dtblbuy, "customer", "customerid");
            return blno;
        }
        [WebMethod]
        public static List<string> GetImporter(string prefix)
        {
            List<string> blno = new List<string>();
            DataTable dtblbuy = new DataTable();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            string strcustype = "C";
            dtblbuy = customerobj.GetLikeCustomer(prefix, strcustype);
            blno = Utility.Fn_DatatableToList(dtblbuy, "customer", "customerid");
            return blno;
        }



        [WebMethod]
        public static List<string> GetAddMuitimanufacturer(string prefix)
        {
            List<string> blno = new List<string>();
            DataTable dtblbuy = new DataTable();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            string strcustype = "C";
            dtblbuy = customerobj.GetLikeCustomer(prefix, strcustype);
            blno = Utility.Fn_DatatableToList(dtblbuy, "customer", "customerid");
            return blno;
        }





        private void get_grd()
        {
            //DataTable dt_nw = new DataTable();
            grd.DataSource = new DataTable();
            grd.DataBind();
        }
        protected void txtBlNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBlNo.Text != "")
                {
                   // btnclose.Text = "Cancel";

                    btnclose.ToolTip = "Cancel";
                    btnclose1.Attributes["class"] = "btn ico-cancel";
                }
                if (txtBlNo.Text != "")
                {
                    txtBlNo.Text = txtBlNo.Text.Trim().ToUpper();

                    Session["Blno"] = txtBlNo.Text;
                    dtbl = FEBLobj.GetBLDetails(txtBlNo.Text, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                    if (dtbl.Rows.Count > 0)
                    {
                        strpor = dtbl.Rows[0]["por"].ToString();
                        strpol = dtbl.Rows[0]["pol"].ToString();
                        strpod = dtbl.Rows[0]["pod"].ToString();
                        strfd = dtbl.Rows[0]["fd"].ToString();
                    }
                    if (dtbl.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtbl.Rows.Count - 1; i++)
                        {
                            if (dtbl.Rows[i][0].ToString() == txtBlNo.Text)
                            {
                                ScriptManager.RegisterStartupScript(txtBlNo, typeof(TextBox), "alert", "alertify.alert('Invalid BL #');", true);
                                txtBlNo.Focus();                                
                                clear();
                                continue;
                                    
                            }
                        }
                    }
                    clear();
                    DataTable dtget = new DataTable();
                    dtget = objisf.GetISFdtls(txtBlNo.Text);
                    if (dtget.Rows.Count > 0)
                    {
                        txtBookingNo.Text = dtget.Rows[0]["bookingno"].ToString();
                        txtMarks.Text = dtget.Rows[0]["marks"].ToString();
                        txtCargo.Text = dtget.Rows[0]["descn"].ToString();
                        importerid = Convert.ToInt32(dtget.Rows[0]["importerid"].ToString());
                        hdf_Importer.Value = dtget.Rows[0]["importerid"].ToString();
                        txtImporter.Text = dtget.Rows[0]["importername"].ToString();
                        txtImporterAdd.Text = dtget.Rows[0]["importerdtls"].ToString();

                        intbuyer = Convert.ToInt32(dtget.Rows[0]["buyerid"].ToString());
                        hdf_buyer.Value = dtget.Rows[0]["buyerid"].ToString();
                        txtBuyer.Text = dtget.Rows[0]["buyername"].ToString();
                        txtBuyerAdd.Text = dtget.Rows[0]["buyerdtls"].ToString();

                        intconsignee = Convert.ToInt32(dtget.Rows[0]["consigneeid"].ToString());
                        hdf_consignee.Value = dtget.Rows[0]["consigneeid"].ToString();
                        txtConsignee.Text = dtget.Rows[0]["consigneename"].ToString();
                        txtConsigneeAdd.Text = dtget.Rows[0]["consigneedtls"].ToString();

                        supplierid = Convert.ToInt32(dtget.Rows[0]["supplierid"].ToString());
                        hdf_Supplier.Value = dtget.Rows[0]["supplierid"].ToString();
                        txtSupplier.Text = dtget.Rows[0]["suppliername"].ToString();
                        txtSupplierAdd.Text = dtget.Rows[0]["supplierdtls"].ToString();

                        intshipper = Convert.ToInt32(dtget.Rows[0]["shipperid"].ToString());
                        hdf_shipper.Value = dtget.Rows[0]["shipperid"].ToString();
                        txtShipper.Text = dtget.Rows[0]["shippername"].ToString();
                        txtShipperAdd.Text = dtget.Rows[0]["shipperdtls"].ToString();

                        intbranch = Convert.ToInt32(dtget.Rows[0]["eforwarderid"].ToString());
                        hdf_eforwarder.Value = dtget.Rows[0]["eforwarderid"].ToString();
                        txtExpFor.Text = dtget.Rows[0]["branchname"].ToString();
                        txtExpForAdd.Text = dtget.Rows[0]["eforwarderdtls"].ToString();

                        intstuff = Convert.ToInt32(dtget.Rows[0]["stuffid"].ToString());
                        hdf_Stuff.Value = dtget.Rows[0]["stuffid"].ToString();
                        txtStuff.Text = dtget.Rows[0]["stuffname"].ToString();
                        txtStuffAdd.Text = dtget.Rows[0]["stuffloc"].ToString();

                        intcha = Convert.ToInt32(dtget.Rows[0]["chaid"].ToString());
                        hdf_cha.Value = Convert.ToString(intcha);
                        txtCha.Text = dtget.Rows[0]["chaname"].ToString();
                        txtChaAdd.Text = dtget.Rows[0]["chadtls"].ToString();

                        intagentid = Convert.ToInt32(dtget.Rows[0]["iforwarderid"].ToString());
                        hdf_ImpFor.Value = dtget.Rows[0]["iforwarderid"].ToString();
                        txtImpFor.Text = dtget.Rows[0]["iforwardername"].ToString();
                        txtImpForAdd.Text = dtget.Rows[0]["iforwarderdtls"].ToString();

                        intmlo = Convert.ToInt32(dtget.Rows[0]["carridid"].ToString());
                        hdf_Carrier.Value = dtget.Rows[0]["carridid"].ToString();

                        txtSCAc.Text = dtget.Rows[0]["carrscac"].ToString();
                        txtPoNo.Text = dtget.Rows[0]["pono"].ToString();
                        txtHTS.Text = dtget.Rows[0]["htscode"].ToString();
                        txtAmsHBL.Text = dtget.Rows[0]["amshbl"].ToString();

                        intConsol = Convert.ToInt32(dtget.Rows[0]["consolid"].ToString());
                        hdf_consolid.Value = dtget.Rows[0]["consolid"].ToString();
                        txtConsolid.Text = dtget.Rows[0]["consolname"].ToString();
                        txtConsolidAdd.Text = dtget.Rows[0]["consoldtls"].ToString();

                        intShipTo = Convert.ToInt32(dtget.Rows[0]["shiptoid"].ToString());
                        hdf_Shipto.Value = dtget.Rows[0]["shiptoid"].ToString();
                        txtShipTo.Text = dtget.Rows[0]["shiptoname"].ToString();
                        txtShipToAdd.Text = dtget.Rows[0]["shiptodtls"].ToString();


                        intmultishipadd = Convert.ToInt32(dtget.Rows[0]["manuid"].ToString());

                        //Session["intmultishipadd"] = intmultishipadd;
                        hid_multimanufacturer.Value = dtget.Rows[0]["manuid"].ToString();
                        txtmulti.Text = dtget.Rows[0]["manuname"].ToString();
                        txtmanufacturer.Text = dtget.Rows[0]["manudtls"].ToString();

                        if (txtBlNo.Text.Trim() == txtAmsHBL.Text.Trim())
                        {
                            chkHBL.Checked = true;
                        }
                        else
                        {
                            chkHBL.Checked = false;
                        }
                       // btnSave.Text = "Update";
                        btnSave.ToolTip = "Update";
                        btnSave1.Attributes["class"] = "btn btn-update1";
                        Button1.Enabled = true;
                        dtjob = objisf.GetJobDetails(txtBlNo.Text, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                        if (dtjob.Rows.Count > 0)
                        {
                            jobno = Convert.ToInt32(dtjob.Rows[0]["jobno"].ToString());
                            txtJobNo.Text = dtjob.Rows[0]["jobno"].ToString();
                            txtMblNo.Text = dtjob.Rows[0]["mblno"].ToString();
                            strmblno = dtjob.Rows[0]["mblno"].ToString();
                            txtCarrier.Text = dtjob.Rows[0]["mlo"].ToString();
                            strmloname = dtjob.Rows[0]["mlo"].ToString();
                            txtVessel.Text = dtjob.Rows[0]["vesselname"].ToString();
                            strvslname = dtjob.Rows[0]["vesselname"].ToString();
                            txtVoy.Text = dtjob.Rows[0]["voyage"].ToString();
                            strvoyname = dtjob.Rows[0]["voyage"].ToString();
                            intmlo = Convert.ToInt32(dtjob.Rows[0]["mloid"].ToString());
                            if (intmlo != 0)
                            {
                                if (txtSCAc.Text == "")
                                {
                                    dtCust = customerobj.SelMasterCust4MRCode(intmlo);
                                    if (dtCust.Rows.Count > 0)
                                    {
                                        txtSCAc.Text = dtCust.Rows[0]["mrscaccode"].ToString();
                                    }
                                    else
                                    {
                                        txtSCAc.Text = "";
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        dtbldet = FEBLobj.GetBLDetails(txtBlNo.Text, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                        clear();
                        if (dtbldet.Rows.Count > 0)
                        {
                            txtMarks.Text = dtbldet.Rows[0]["marks"].ToString();
                            strmarks = dtbldet.Rows[0]["marks"].ToString();
                            txtCargo.Text = dtbldet.Rows[0]["descn"].ToString();
                            strcarcgo = dtbldet.Rows[0]["descn"].ToString();
                            txtImporter.Text = dtbldet.Rows[0]["conname"].ToString();
                            strcon = dtbldet.Rows[0]["cadd"].ToString();
                            txtImporterAdd.Text = dtbldet.Rows[0]["cadd"].ToString();
                            txtBuyer.Text = dtbldet.Rows[0]["conname"].ToString();
                            txtBuyerAdd.Text = dtbldet.Rows[0]["cadd"].ToString();
                            txtConsignee.Text = dtbldet.Rows[0]["conname"].ToString();
                            txtConsigneeAdd.Text = dtbldet.Rows[0]["cadd"].ToString();
                            txtSupplier.Text = dtbldet.Rows[0]["sname"].ToString();
                            strsupplier = dtbldet.Rows[0]["sname"].ToString();
                            txtSupplierAdd.Text = dtbldet.Rows[0]["sadd"].ToString();
                            txtShipper.Text = dtbldet.Rows[0]["sname"].ToString();
                            txtShipperAdd.Text = dtbldet.Rows[0]["sadd"].ToString();
                            importerid = Convert.ToInt32(dtbldet.Rows[0]["consigneeid"].ToString());
                            intconsignee = Convert.ToInt32(dtbldet.Rows[0]["consigneeid"].ToString());
                            // hdf_consignee.Value =Convert.ToString ( intconsignee);
                            intbuyer = Convert.ToInt32(dtbldet.Rows[0]["consigneeid"].ToString());
                            intshipper = Convert.ToInt32(dtbldet.Rows[0]["shipperid"].ToString());
                            supplierid = Convert.ToInt32(dtbldet.Rows[0]["shipperid"].ToString());


                            hdf_Importer.Value = dtbldet.Rows[0]["consigneeid"].ToString();
                            hdf_buyer.Value = dtbldet.Rows[0]["consigneeid"].ToString();
                            hdf_consignee.Value = dtbldet.Rows[0]["consigneeid"].ToString();
                            hdf_Supplier.Value = dtbldet.Rows[0]["shipperid"].ToString();
                            hdf_shipper.Value = dtbldet.Rows[0]["shipperid"].ToString();
                            //hdf_eforwarder.Value = dtget.Rows[0]["eforwarderid"].ToString();
                            //hdf_Stuff.Value = dtget.Rows[0]["stuffid"].ToString();
                            //hdf_cha.Value = Convert.ToString(intcha);
                            //hdf_ImpFor.Value = dtget.Rows[0]["iforwarderid"].ToString();
                            //hdf_Carrier.Value = dtget.Rows[0]["carridid"].ToString();
                            //hdf_consolid.Value = dtget.Rows[0]["consolid"].ToString();
                            //hdf_Shipto.Value = dtget.Rows[0]["shiptoid"].ToString();

                           // btnSave.Text = "Save";

                            btnSave.ToolTip = "Save";
                            btnSave1.Attributes["class"] = "btn ico-save";
                            Button1.Enabled = false;

                        }
                        Dtisfdtls = objisf.GetISFDetails(txtBlNo.Text);
                        if (Dtisfdtls.Rows.Count > 0)
                        {
                            dtblbuy = customerobj.GetLikeCustomer(txtBuyer.Text, strcustype);
                            strbuyer = dtblbuy.Rows[0]["customername"].ToString();
                            txtBuyerAdd.Text = strbuyer;
                            txtBuyerAdd.Text = Dtisfdtls.Rows[0]["buyerdtls"].ToString();
                        }


                        Dtisfdtls = objisf.GetISFDetails(txtBlNo.Text);
                        if (Dtisfdtls.Rows.Count > 0)
                        {
                            Dt = customerobj.GetLikeCustomer(txtShipper.Text, custype);
                            if (Dt.Rows.Count > 0)
                            {
                                strshipname = Dt.Rows[0]["customername"].ToString();
                                txtShipper.Text = strshipname;
                                txtShipperAdd.Text = Dtisfdtls.Rows[0]["shipperdtls"].ToString();
                            }
                        }


                        dtcnf = objisf.GetCNFdtls(txtBlNo.Text);
                        if (dtcnf.Rows.Count > 0)
                        {
                            intcha = Convert.ToInt32(dtcnf.Rows[0]["cnf"].ToString());
                            hdf_cha.Value = dtcnf.Rows[0]["cnf"].ToString();
                            txtCha.Text = dtcnf.Rows[0]["customername"].ToString();
                            strchaname = dtcnf.Rows[0]["customername"].ToString();
                            txtChaAdd.Text = customerobj.GetCustomerAddress(intcha);
                        }


                        dtimpwd = objisf.GetImportDtls(txtBlNo.Text);
                        if (dtimpwd.Rows.Count > 0)
                        {
                            intagentid = Convert.ToInt32(dtimpwd.Rows[0]["deliveryagent"].ToString());
                            hdf_ImpFor.Value = dtimpwd.Rows[0]["deliveryagent"].ToString();
                            txtImpFor.Text = dtimpwd.Rows[0]["customername"].ToString();
                            stragentname = dtimpwd.Rows[0]["customername"].ToString();
                            strimpname = dtimpwd.Rows[0]["customername"].ToString();
                            straddr = dtimpwd.Rows[0]["address"].ToString();
                            txtImpForAdd.Text = strimpname + straddr;
                        }

                        dtjob = objisf.GetJobDetails(txtBlNo.Text, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                        if (dtjob.Rows.Count > 0)
                        {
                            jobno = Convert.ToInt32(dtjob.Rows[0]["jobno"].ToString());
                            txtJobNo.Text = dtjob.Rows[0]["jobno"].ToString();
                            txtMblNo.Text = dtjob.Rows[0]["mblno"].ToString();
                            strmblno = dtjob.Rows[0]["mblno"].ToString();
                            txtCarrier.Text = dtjob.Rows[0]["mlo"].ToString();
                            strmloname = dtjob.Rows[0]["mlo"].ToString();
                            txtVessel.Text = dtjob.Rows[0]["vesselname"].ToString();
                            strvslname = dtjob.Rows[0]["vesselname"].ToString();
                            txtVoy.Text = dtjob.Rows[0]["voyage"].ToString();
                            strvoyname = dtjob.Rows[0]["voyage"].ToString();
                            intmlo = Convert.ToInt32(dtjob.Rows[0]["mloid"].ToString());
                            hdf_Carrier.Value = dtjob.Rows[0]["mloid"].ToString();
                            eta = dtjob.Rows[0]["eta"].ToString();
                            etd = dtjob.Rows[0]["etd"].ToString();
                            if (intmlo != 0)
                            {
                                dtCust = customerobj.SelMasterCust4MRCode(intmlo);
                                if (dtCust.Rows.Count > 0)
                                {
                                    txtSCAc.Text = dtCust.Rows[0]["mrscaccode"].ToString();
                                }
                                else
                                {
                                    txtSCAc.Text = "";
                                }
                            }

                        }
                        else
                        {
                            clear();
                            ScriptManager.RegisterStartupScript(txtBlNo, typeof(TextBox), "alert", "alertify.alert('Invalid BL #');", true);
                            txtBlNo.Focus();
                            Button1.Enabled = false;
                        }
                        dtbook = objisf.GetBookingDet(txtBlNo.Text, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                        if (dtbook.Rows.Count > 0)
                        {
                            txtBookingNo.Text = dtbook.Rows[0]["shiprefno"].ToString();
                            strbooking = dtbook.Rows[0]["shiprefno"].ToString();
                        }
                    }
                    dtcondt = objisf.GetContainerDetails(txtBlNo.Text, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                    if (dtcondt.Rows.Count > 0)
                    {
                        grd.DataSource = dtcondt;
                        grd.DataBind();
                    }
                }
                dtbranch = objisf.GetBdtls(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()));
                if (dtbranch.Rows.Count > 0)
                {
                    txtExpFor.Text = dtbranch.Rows[0]["branchname"].ToString().Trim();
                    stradr = dtbranch.Rows[0]["address"].ToString();
                    strphone = dtbranch.Rows[0]["phone"].ToString();
                    stremail = dtbranch.Rows[0]["email"].ToString();
                    strptc = dtbranch.Rows[0]["ptc"].ToString();
                    strfax = dtbranch.Rows[0]["fax"].ToString();
                    //txtExpForAdd.Text = txtExpFor.Text + "<br/>" + stradr.Replace("<br/>", "").Trim() + "<br/>" + "Ph:" + strphone.Replace("<br/>", "").Trim() + " , Fax:" + strfax.Replace("<br/>", "").Trim() + " , Email:" + stremail.Replace("<br/>", "").Trim() + "<br/>" + "PTC : " + strptc.Replace("<br/>", "").Trim();
                    //txtExpForAdd.Text = txtExpForAdd.Text.Replace("<br/>" + "<br/>", "");
                    txtExpForAdd.Text = txtExpFor.Text + Environment.NewLine +
                        stradr.Replace("<br/>", "").Trim() +
                        Environment.NewLine + "Ph:" + strphone.Trim() + Environment.NewLine +
                        " , Fax:" + strfax.Trim() + Environment.NewLine +
                        " , Email:" + stremail.Trim() + Environment.NewLine +
                        "PTC : " + strptc.Trim();

                }
                txtReadOnly();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void Grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label lblCustomer = (Label)e.Row.FindControl("containerno");
                    string tooltip = lblCustomer.Text;
                    e.Row.Cells[0].Attributes.Add("title", tooltip);

                    Label lblCustomer1 = (Label)e.Row.FindControl("sealno");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[1].Attributes.Add("title", tooltip1);

                    Label lblCustomer2 = (Label)e.Row.FindControl("sizetype");
                    string tooltip2 = lblCustomer2.Text;
                    e.Row.Cells[2].Attributes.Add("title", tooltip2);


                    //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                   // e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                    //e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void txtReadOnly()
        {
            txtJobNo.ReadOnly = true;
            txtMblNo.ReadOnly = true;
            txtBookingNo.ReadOnly = true;
            txtVessel.ReadOnly = true;
            txtVoy.ReadOnly = true;
            txtCarrier.ReadOnly = true;
            txtMarks.ReadOnly = true;
            txtCargo.ReadOnly = true;
            txtConsignee.ReadOnly = true;
            txtConsigneeAdd.ReadOnly = true;
            txtShipper.ReadOnly = true;
            txtShipperAdd.ReadOnly = true;
            txtExpFor.ReadOnly = true;
            txtExpForAdd.ReadOnly = true;
            txtCha.ReadOnly = true;
            txtChaAdd.ReadOnly = true;
        }
        private void clear()
        {
            txtMarks.Text = "";
            txtCargo.Text = "";
            txtImporter.Text = "";
            txtImporterAdd.Text = "";
            txtBuyer.Text = "";
            txtBuyerAdd.Text = "";
            txtConsignee.Text = "";
            txtConsigneeAdd.Text = "";
            txtSupplier.Text = "";
            txtSupplierAdd.Text = "";
            txtShipper.Text = "";
            txtShipperAdd.Text = "";
            txtCha.Text = "";
            txtChaAdd.Text = "";
            txtImpFor.Text = "";
            txtImpForAdd.Text = "";
            txtJobNo.Text = "";
            txtMblNo.Text = "";
            txtCarrier.Text = "";
            txtVessel.Text = "";
            txtVoy.Text = "";
            txtBookingNo.Text = "";
            txtExpFor.Text = "";
            txtExpForAdd.Text = "";
            txtConsolid.Text = "";
            txtPoNo.Text = "";
            txtSCAc.Text = "";
            txtStuff.Text = "";
            txtHTS.Text = "";
            txtConsolidAdd.Text = "";
            txtAmsHBL.Text = "";
            chkHBL.Checked = false;
            txtStuff.Text = "";
            txtShipTo.Text = "";
            txtShipToAdd.Text = "";
            txtStuffAdd.Text = "";
            //TextBox1.Text = "";
            //TextBox2.Text = "";
            grd.DataSource = new DataTable();
            grd.DataSource = null;
            grd.DataBind();

            //grdadd.DataSource = new DataTable();
            //grdadd.DataSource = null;
            //grdadd.DataBind();
        }

   
        

        protected void btnclose_Click(object sender, EventArgs e)
        {
            if (btnclose.ToolTip == "Cancel")
            {
                JobInput.Text = "";
                clear();
                txtBlNo.Text = "";
                //btnclose.Text = "Back";
                //btnSave.Text = "Save";

                btnclose.ToolTip = "Back";
                btnclose1.Attributes["class"] = "btn ico-back";
                btnSave.ToolTip = "Save";
                btnSave1.Attributes["class"] = "btn ico-save";
                Button1.Enabled = false;
            }
            else
            {
               //this.Response.End();
                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "OPS&DOC")
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            // headerlable1.InnerText = "OceanExports";
                            Response.Redirect("../Home/OEOpsAndDocs.aspx");

                        }
                    }
                    else
                    {
                        this.Response.End();
                    }
                }
                else
                {
                    this.Response.End();
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBlNo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btnDelete, typeof(Button), "alert", "alertify.alert('BL Can't Be Empty');", true);
                }
                else
                {
                    objisf.DelBLnodtls(txtBlNo.Text);
                    ScriptManager.RegisterStartupScript(btnDelete, typeof(Button), "alert", "alertify.alert('Details Deleted');", true);
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1067, 4, Convert.ToInt32(Session["LoginBranchid"]), txtBlNo.Text + " - " + Logobj.GetDate());
                    clear();
                    txtBlNo.Text = "";
                    txtBlNo.Focus();
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
            try
            {
                txtImporter_TextChanged(sender, e);
                txtBuyer_TextChanged(sender, e);
                txtSupplier_TextChanged(sender, e);
                txtImpFor_TextChanged(sender, e);
                txtStuff_TextChanged(sender, e);
                txtConsolid_TextChanged(sender, e);
                txtShipTo_TextChanged(sender, e);
                if (blnerr==true)
                {
                    return;
                }
                //  txtBlNo_TextChanged(sender, e);
                intbuyer = Convert.ToInt32(hdf_buyer.Value);
                importerid = Convert.ToInt32(hdf_Importer.Value);
                supplierid = Convert.ToInt32(hdf_Supplier.Value);
                intagentid = Convert.ToInt32(hdf_ImpFor.Value);
                intstuff = Convert.ToInt32(hdf_Stuff.Value);
                intConsol = Convert.ToInt32(hdf_consolid.Value);
                intShipTo = Convert.ToInt32(hdf_Shipto.Value);
                intmultishipadd = Convert.ToInt32(hid_multimanufacturer.Value);

                intconsignee = Convert.ToInt32(hdf_consignee.Value);
                intshipper = Convert.ToInt32(hdf_shipper.Value);
                intcha = Convert.ToInt32(hdf_cha.Value);
                intmlo = Convert.ToInt32(hdf_Carrier.Value);
                //  return;
                if (btnSave.ToolTip == "Save")
                {
                    objisf.InsISFDetails(txtBookingNo.Text, txtBlNo.Text, importerid, txtImporterAdd.Text, intbuyer, txtBuyerAdd.Text, intconsignee, txtConsigneeAdd.Text, supplierid, txtSupplierAdd.Text, intshipper, txtShipperAdd.Text, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), txtExpForAdd.Text, txtStuffAdd.Text, intagentid, txtImpForAdd.Text, intcha, txtChaAdd.Text, intmlo, txtSCAc.Text, txtMblNo.Text, txtPoNo.Text, txtHTS.Text, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), intstuff, txtAmsHBL.Text, intConsol, txtConsolidAdd.Text, intShipTo, txtShipToAdd.Text, intmultishipadd,txtmanufacturer.Text);
                    ScriptManager.RegisterStartupScript(btnDelete, typeof(Button), "alert", "alertify.alert('Details Inserted');", true);
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1067, 1, Convert.ToInt32(Session["LoginBranchid"]), txtBlNo.Text + " - " + Logobj.GetDate());

                    clear();
                    txtBlNo.Text = "";
                  //  btnSave.Text = "Update";
                    btnSave.ToolTip = "Update";
                    btnSave1.Attributes["class"] = "btn btn-update1";

                    Button1.Enabled = true;
                }
                else if (btnSave.ToolTip == "Update")
                {
                    objisf.UpdISFDetails(txtBlNo.Text, txtBookingNo.Text, importerid, txtImporterAdd.Text, intbuyer, txtBuyerAdd.Text, intconsignee, txtConsigneeAdd.Text, supplierid, txtSupplierAdd.Text, intshipper, txtShipperAdd.Text, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), txtExpForAdd.Text, txtStuffAdd.Text, intagentid, txtImpForAdd.Text, intcha, txtChaAdd.Text, intmlo, txtSCAc.Text, txtMblNo.Text, txtPoNo.Text, txtHTS.Text, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), intstuff, txtAmsHBL.Text, intConsol, txtConsolidAdd.Text, intShipTo, txtShipToAdd.Text, intmultishipadd, txtmanufacturer.Text);
                    ScriptManager.RegisterStartupScript(btnDelete, typeof(Button), "alert", "alertify.alert('Details Updated');", true);
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1067, 2, Convert.ToInt32(Session["LoginBranchid"]), txtBlNo.Text + " - " + Logobj.GetDate());
                  //  btnSave.Text = "Update";
                    btnSave.ToolTip = "Update";
                    btnSave1.Attributes["class"] = "btn btn-update1";
                    Button1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void chkHBL_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkHBL.Checked == true)
                {
                    txtAmsHBL.Text = txtBlNo.Text;
                }
                else
                {
                    txtAmsHBL.Text = "";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnXML_Click(object sender, EventArgs e)
        {
            //   string   strFile ;
            //   string strTmp ;
            //strFile = Application.StartupPath & "\SeaShippingOrdersEDI.xml"
            //TW = System.IO.File.CreateText(strFile);
            //if(txtBlNo.Text !="")
            //{

            //}
            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1067, 3, Convert.ToInt32(Session["LoginBranchid"]), txtBlNo.Text + " - " + Logobj.GetDate() +" / XML");
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";
                if (txtBlNo.Text.Trim().Length > 0)
                {
                    string Ccode = Convert.ToString(Session["Ccode"]);
                    str_RptName = "ISFReport.rpt";
                    str_sf = "{FEBLDetails.blno}=\"" + txtBlNo.Text + "\" and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "&Ccode=" + Ccode + "','','');";
                    ScriptManager.RegisterStartupScript(btnView, typeof(Button), "ISF Details", str_Script, true);
                    //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1067, 3, Convert.ToInt32(Session["LoginBranchid"]), txtBlNo.Text + " - " + Logobj.GetDate());
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnView, typeof(Button), "ISF Details", "alertify.alert('Enter BL #')", true);
                    txtBlNo.Focus();
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

        protected void txtImporter_TextChanged(object sender, EventArgs e)
        {
            Dt = customerobj.GetexactCustomer(txtImporter.Text.ToUpper(), "C");
            if (Dt.Rows.Count == 0 || hdf_Importer.Value=="0")
            {
                ScriptManager.RegisterStartupScript(txtImporter, typeof(TextBox), "alert", "alertify.alert('Enter the Correct Importer Name');", true);
                txtImporter.Focus();
                txtImporter.Text = "";
                txtImporterAdd.Text = "";
                blnerr = true;
            }
        }

        protected void txtBuyer_TextChanged(object sender, EventArgs e)
        {
            Dt = customerobj.GetexactCustomer(txtBuyer.Text.ToUpper(), "C");
            if (Dt.Rows.Count == 0 || hdf_buyer.Value=="0")
            {
                ScriptManager.RegisterStartupScript(txtBuyer, typeof(TextBox), "alert", "alertify.alert('Enter the Correct Buyer Name');", true);
                txtBuyer.Focus();
                txtBuyer.Text = "";
                txtBuyerAdd.Text = "";
                blnerr = true;
            }
        }

        protected void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            Dt = customerobj.GetexactCustomer(txtSupplier.Text.ToUpper(), "C");
            if (Dt.Rows.Count == 0 || hdf_Supplier.Value=="0")
            {
                ScriptManager.RegisterStartupScript(txtSupplier, typeof(TextBox), "alert", "alertify.alert('Enter the Correct Supplier Name');", true);
                txtSupplier.Focus();
                txtSupplier.Text = "";
                txtSupplierAdd.Text = "";
                blnerr = true;
            }
        }

        protected void txtExpFor_TextChanged(object sender, EventArgs e)
        {
            Dt = customerobj.GetexactCustomer(txtExpFor.Text.ToUpper(), "P");
            if (Dt.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(txtExpFor, typeof(TextBox), "alert", "alertify.alert('Enter the Correct Exporter Forwarder Name');", true);
                txtExpFor.Focus();
                txtExpFor.Text = "";
                txtExpForAdd.Text = "";
                blnerr = true;
            }
        }

        protected void txtImpFor_TextChanged(object sender, EventArgs e)
        {
            Dt = customerobj.GetexactCustomer(txtImpFor.Text.ToUpper(), "P");
            if (Dt.Rows.Count == 0 || hdf_ImpFor.Value=="0")
            {
                ScriptManager.RegisterStartupScript(txtImpFor, typeof(TextBox), "alert", "alertify.alert('Enter the Correct Importer Forwarder Name');", true);
                txtImpFor.Focus();
                txtImpFor.Text = "";
                txtImpForAdd.Text = "";
                blnerr = true;
            } 
        }

        protected void txtStuff_TextChanged(object sender, EventArgs e)
        {
            Dt = customerobj.GetexactCustomer(txtStuff.Text.ToUpper(), "C");
            if (Dt.Rows.Count == 0 || hdf_Stuff.Value=="0")
            {
                ScriptManager.RegisterStartupScript(txtStuff, typeof(TextBox), "alert", "alertify.alert('Enter the Correct Importer Stuffing Location Name');", true);
                txtStuff.Focus();
                txtStuff.Text = "";
                txtStuffAdd.Text = "";
                blnerr = true;
            } 
        }

        protected void txtConsolid_TextChanged(object sender, EventArgs e)
        {
            Dt = customerobj.GetexactCustomer(txtConsolid.Text.ToUpper(), "C");
            if (Dt.Rows.Count == 0 || hdf_consolid.Value=="0")
            {
                ScriptManager.RegisterStartupScript(txtConsolid, typeof(TextBox), "alert", "alertify.alert('Enter the Correct Consolidator Name');", true);
                txtConsolid.Focus();
                txtConsolid.Text = "";
                txtConsolidAdd.Text = "";
                blnerr = true;
            } 
        }

        protected void txtShipTo_TextChanged(object sender, EventArgs e)
        {
            Dt = customerobj.GetexactCustomer(txtShipTo.Text.ToUpper(), "C");
            if (Dt.Rows.Count == 0 || hdf_Shipto.Value=="0")
            {
                ScriptManager.RegisterStartupScript(txtShipTo, typeof(TextBox), "alert", "alertify.alert('Enter the Correct ShipTo Name');", true);
                txtShipTo.Focus();
                txtShipTo.Text = "";
                txtShipToAdd.Text = "";
                blnerr = true;
            } 
        }

        protected void txtmulti_TextChanged(object sender, EventArgs e)
        {
            Dt = customerobj.GetexactCustomer(txtmulti.Text.ToUpper(), "C");
            if (Dt.Rows.Count == 0 || hid_multimanufacturer.Value == "0")
            {
                ScriptManager.RegisterStartupScript(txtmulti, typeof(TextBox), "alert", "alertify.alert('Enter the Correct Name');", true);
                txtmulti.Focus();
                txtmulti.Text = "";
                txtmanufacturer.Text = "";
                blnerr = true;
            } 
        }

        protected void txtaddmultiple_Click(object sender, EventArgs e)
        {
            if (Session["Blno"] != null)
            {
                string blno = Session["Blno"].ToString();
                //string intmultishipadd = Session["intmultishipadd"].ToString();
                ifrmaster.Attributes["src"] = "../ShipmentDetails/AddManufaturer.aspx?BLNO=" + blno;
                modal_view.Show();
                pnl_grd2.Visible = true;
            }
           // Response.Redirect("../ShipmentDetails/AddManufaturer.aspx");

            //newadd = objisf.SELISFManuf(txtBlNo.Text, Convert.ToInt32(Session["LoginBranchid"]));
            //grdadd.DataSource = newadd;
            //grdadd.DataBind();
            //this.popcancel.Show();
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
            Panel1.Visible = true;

            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1067, "IFS", txtBlNo.Text, txtBlNo.Text, "");  //"/Rate ID: " +
            if (txtBlNo.Text != "")
            {
                JobInput.Text = txtBlNo.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
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
    }
}