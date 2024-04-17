using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Runtime.Remoting;

namespace logix.ForwardExports
{
    public partial class Query : System.Web.UI.Page
    {
        string blno;
        string str_trantype;
        DataTable dt_new = new DataTable();
        int int_consignee;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;

        string Ctrl_List1;
        string Msg_List1;
        string Dtype_List1;

        string Ctrl_List2;
        string Msg_List2;
        string Dtype_List2;

        string Ctrl_List3;
        string Msg_List3;
        string Dtype_List3;

        string Ctrl_List4;

        string Dtype_List4;

        double dbl_tot;
        double dbl_vol;
        double dbl_noof;
        string str_Uiid = "";
        string type;
        DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.ForwardingImports.BLDetails da_obj_blobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();
        DataAccess.AirImportExports.AIEBLDetails da_obj_blobj2 = new DataAccess.AirImportExports.AIEBLDetails();
        DataAccess.ForwardingExports.BLDetails da_obj_FEblobj = new DataAccess.ForwardingExports.BLDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_employeeobj.GetDataBase(Ccode);
                da_obj_blobj.GetDataBase(Ccode);
                da_obj_vesselobj.GetDataBase(Ccode);
                da_obj_blobj2.GetDataBase(Ccode);
                da_obj_FEblobj.GetDataBase(Ccode);
               
                Logobj.GetDataBase(Ccode);
            }

            //if (Session["LoginUserName"] == null || Session["LoginDivisionid"] == null || Session["LoginBranchid"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../Login.aspx','_top');", true);
            //}

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if (Session["Queriesnew"] != null)
            {
                Session["Queriesnew"] = null;
                
            }
            if (Request.QueryString.ToString().Contains("OECSHomeFEQuery"))
            {
                Btn_back.Visible = true;
                crumbslbl.Attributes["class"] = "crumbslbl";
            }

            else if (Request.QueryString.ToString().Contains("OECSHomeFIQuery"))
            {
                Btn_back.Visible = true;
                crumbslbl.Attributes["class"] = "crumbslbl";
            }

            else if (Request.QueryString.ToString().Contains("AECSHOMEQuery"))
            {
                Btn_back.Visible = true;
                crumbslbl.Attributes["class"] = "crumbslbl";
            }
            else if (Request.QueryString.ToString().Contains("AICSHOMEQuery"))
            {
                Btn_back.Visible = true;
                crumbslbl.Attributes["class"] = "crumbslbl";
            }

            else if (Request.QueryString.ToString().Contains("OEOPSDOCHomeFEQuery"))
            {
                Btn_back.Visible = true;
                crumbslbl.Attributes["class"] = "crumbslbl";
            }
            else if (Request.QueryString.ToString().Contains("OEOPSDOCHomeFIQuery"))    
            {
                Btn_back.Visible = true;
                crumbslbl.Attributes["class"] = "crumbslbl";
            }
             else if (Request.QueryString.ToString().Contains("OEOPSDOCHomeAEQuery"))      
            {
                Btn_back.Visible = true;
                crumbslbl.Attributes["class"] = "crumbslbl";
            }

             else if (Request.QueryString.ToString().Contains("OEOPSDOCHomeAIQuery"))      
            {
                Btn_back.Visible = true;
                crumbslbl.Attributes["class"] = "crumbslbl";
            }

            else if (Request.QueryString.ToString().Contains("OEOPSDOCHomeCHQuery"))
            {
                Btn_back.Visible = true;
                crumbslbl.Attributes["class"] = "crumbslbl";
            }
                // ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
                if (!this.IsPostBack)
                {
                    try
                    {

                        if (Request.QueryString.ToString().Contains("type"))
                        {
                              type = Request.QueryString["type"].ToString();
                              Session["Queries"] = type;
                              if (Request.QueryString.ToString().Contains("trantype"))
                              {
                                Session["StrTranType"] = Request.QueryString["trantype"].ToString();
                              }
                             
                        }
                      
                    
                        txt_cbm.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'CBM')");
                        txt_noofpkg.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'No.of Packages')");
                        /*txt_Sales.Text = da_obj_employeeobj.GetEmployeeName(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                        hf_salesid.Value = da_obj_employeeobj.GetNEmpid(Convert.ToString(txt_Sales.Text)).ToString();
                        dt_new = da_obj_blobj.ShowFIInfo(Convert.ToInt32(hf_salesid.Value), "SAMPLE", "SALE", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        grd.DataSource = dt_new;
                        grd.DataBind();*/
                        //Session["Query"] = "";
                       if (Session["StrTranType"].ToString() == "FI")
                        {
                            txt_Shipbill.Enabled = false;
                            txt_FBL.Enabled = true;
                            TextBox1.Enabled = true;
                            txt_Inv.Enabled = true;
                            txt_vessel.Enabled = true;
                            txt_voyage.Enabled = true;
                        }
                        else if (Session["StrTranType"].ToString() == "FE")
                        {
                            txt_Shipbill.Enabled = true;
                            txt_FBL.Enabled = false;
                            TextBox1.Enabled = false;
                            txt_vessel.Enabled = true;
                            txt_voyage.Enabled = true;
                            txt_consignee.Attributes.Add("placeholder", "Shipper");
                            txt_consignee.ToolTip = "Shipper";
                            txt_Port.Attributes.Add("placeholder", "POD");
                            txt_Port.ToolTip = "Port Of Discharge";

                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {
                            txt_Shipbill.Enabled = false;
                            txt_FBL.Enabled = false;
                            TextBox1.Enabled = false;
                            txt_Inv.Enabled = true;
                            txt_voyage.Enabled = false;
                            txt_Containerno.Enabled = false;
                            txt_vessel.Enabled = true;
                            txt_consignee.Attributes.Add("placeholder", "Shipper");
                            txt_consignee.ToolTip = "Shipper";
                            txt_cbm.Attributes.Add("placeholder", "Charge Wt.");
                            txt_cbm.ToolTip = "Charge Weight";
                            txt_vessel.Attributes.Add("placeholder", "Flight#");
                            txt_vessel.ToolTip = "Flight Number";
                            txt_MBLno.Attributes.Add("placeholder", "MAWBL#");
                            txt_MBLno.ToolTip = "MAWBL Number";
                            txt_Port.Attributes.Add("placeholder", "POD");
                            txt_Port.ToolTip = "Port Of Discharge";
                            txt_Sales.Text = "";

                        }

                        else if (Session["StrTranType"].ToString() == "AI")
                        {
                            txt_Shipbill.Enabled = false;
                            txt_FBL.Enabled = false;
                            TextBox1.Enabled = false;
                            txt_Inv.Enabled = true;
                            txt_voyage.Enabled = false;
                            txt_Containerno.Enabled = false;
                            txt_vessel.Enabled = true;
                          
                            txt_consignee.Attributes.Add("placeholder", "Consignee");
                            txt_consignee.ToolTip = "Consignee";
                            txt_cbm.Attributes.Add("placeholder", "Charge Wt.");
                            txt_cbm.ToolTip = "Charge Weight";
                            txt_vessel.Attributes.Add("placeholder", "Flight#");
                            txt_vessel.ToolTip = "Flight Number";
                            txt_MBLno.Attributes.Add("placeholder", "MAWBL#");
                            txt_MBLno.ToolTip = "MAWBL Number";
                            txt_Port.Attributes.Add("placeholder", "POL");
                            txt_Port.ToolTip = "Port Of Load";
                            txt_Sales.Text = "";
                        }
                       else if (Session["StrTranType"].ToString() == "CH")
                       {
                           txt_Shipbill.Enabled = false;
                           txt_FBL.Enabled = false;
                           TextBox1.Enabled = false;
                           txt_Inv.Enabled = true;
                           txt_voyage.Enabled = false;
                           txt_Containerno.Enabled = false;
                           txt_vessel.Enabled = false;
                           txt_Bookingno.Enabled = false;
                           txt_cbm.Enabled = false;
                           txt_Agent.Enabled = false;
                          
                           txt_consignee.Attributes.Add("placeholder", "Shipper");
                           txt_consignee.ToolTip = "Shipper";
                           txt_cbm.Attributes.Add("placeholder", "Charge Wt.");
                           txt_cbm.ToolTip = "Charge Weight";
                           txt_vessel.Attributes.Add("placeholder", "VESSEL #");
                           txt_vessel.ToolTip = "VESSEL Number";
                           txt_MBLno.Attributes.Add("placeholder", "MDOC#");
                           txt_MBLno.ToolTip = "MAWBL Number";

                           txt_bl.Attributes.Add("placeholder", "DOC#");
                           txt_bl.ToolTip = "DOC Number";
                           txt_Port.Attributes.Add("placeholder", "POD");
                           txt_Port.ToolTip = "Port Of Discharge";
                           txt_Sales.Text = "";
                       }
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            headerlable1.InnerText = "OceanExports";
                            if (Session["Queries"] != null)
                            {
                                if (Session["Queries"].ToString() == "Queries")
                                {
                                    headerlableid1.InnerText = "Utility";
                                }
                            }
                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {
                            headerlable1.InnerText = "OceanImports";
                            if (Session["Queries"] != null)
                            {
                                if (Session["Queries"].ToString() == "Queries")
                                {
                                    headerlableid1.InnerText = "Utility";
                                }
                            }
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {
                            headerlable1.InnerText = "AirExports";
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {
                            headerlable1.InnerText = "AirImports";
                        }
                        else if (Session["StrTranType"].ToString() == "CH")
                        {
                            headerlable1.InnerText = "CHA";
                        }
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
                //txt_Sales.Text = da_obj_employeeobj.GetEmployeeName(Convert.ToInt32(Session["LoginEmpId"].ToString()));
               
                
            
            
            
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
        public static List<string> GetVesselname(string prefix)
        {
            List<string> vesselname = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_vesselobj.GetDataBase(Ccode);
            if (HttpContext.Current.Session["StrTranType"].ToString() == "FE" || HttpContext.Current.Session["StrTranType"].ToString() == "FI")
            {
                obj_dt = da_obj_vesselobj.GetLikeVessel(prefix);
                //obj_dt = da_obj_vesselobj.GetLikeVessel(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()), Convert.ToString(HttpContext.Current.Session["StrTranType"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()));
                //obj_dt = da_obj_vesselobj.GetSalesLikeVessel(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()), "FE", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()));
                vesselname = Utility.Fn_DatatableToList(obj_dt, "vesselname", "vesselid");
               
            }

            return vesselname;
        }

        [WebMethod]
        public static List<string> Getmblname(string prefix)
        {
            List<string> mblno = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.JobInfo da_obj_FEJobObj = new DataAccess.ForwardingExports.JobInfo();
            DataAccess.ForwardingImports.JobInfo da_obj_FIJobObj = new DataAccess.ForwardingImports.JobInfo();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_FEJobObj.GetDataBase(Ccode);
            da_obj_FIJobObj.GetDataBase(Ccode);
            if (HttpContext.Current.Session["StrTranType"].ToString() != "CH")
            {
                if (HttpContext.Current.Session["StrTranType"].ToString() == "FE")
                {
                    obj_dt = da_obj_FEJobObj.GetFEJobInfoMBL(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                }
                else
                {
                    obj_dt = da_obj_FIJobObj.GetLikeMBLNo(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                }
            }
            else
            {
                obj_dt = da_obj_FIJobObj.GetLikechMBLNo(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            }
            mblno = Utility.Fn_DatatableToList_Text(obj_dt, "mblno");
            return mblno;
        }

        [WebMethod]
        public static List<string> Getcontainerno(string prefix)
        {
            List<string> containerno = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.BLPrinting da_obj_FEBLPrintObj = new DataAccess.ForwardingExports.BLPrinting();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_FEBLPrintObj.GetDataBase(Ccode);
           
            //obj_dt = da_obj_FEBLPrintObj.GetLikeSalesContno(prefix, Convert.ToString(HttpContext.Current.Session["StrTranType"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()));
            obj_dt = da_obj_FEBLPrintObj.GetLikeContno(prefix, HttpContext.Current.Session["StrTranType"].ToString(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            containerno = Utility.Fn_DatatableToList_Text(obj_dt, "containerno");
            return containerno;
        }

        [WebMethod]
        public static List<string> Getsbno(string prefix)
        {
            List<string> sbno = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.ShippingBill da_obj_ShippingBillobj = new DataAccess.ForwardingExports.ShippingBill();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_ShippingBillobj.GetDataBase(Ccode);
           
            obj_dt = da_obj_ShippingBillobj.GetLikeShipBill(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            sbno = Utility.Fn_DatatableToList_Text(obj_dt, "sbno");
            return sbno;
        }

        [WebMethod]
        public static List<string> Getcustomer(string prefix)
        {
            List<string> customername = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_customerobj.GetDataBase(Ccode);
       
            obj_dt = da_obj_customerobj.GetLikeCustomer(prefix.ToUpper(), "C");
            //  obj_dt = da_obj_customerobj.GetLikeCustomerForSales(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()));
            customername = Utility.Fn_TableToList(obj_dt, "customername", "customerid");
            return customername;
        }

        [WebMethod]
        public static List<string> Getshipref(string prefix)
        {
            List<string> shiprefno = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Marketing.Booking da_obj_bookobj = new DataAccess.Marketing.Booking();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_bookobj.GetDataBase(Ccode);
         
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            obj_dt = da_obj_bookobj.GetLikeBooking(HttpContext.Current.Session["StrTranType"].ToString(), prefix.ToUpper(), bid);

            //obj_dt = da_obj_bookobj.GetLikeBooking(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()));
            shiprefno = Utility.Fn_DatatableToListstring(obj_dt, "shiprefno", "blno");
            return shiprefno;
        }

        [WebMethod]
        public static List<string> Getportname(string prefix)
        {
            List<string> portname = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterPort da_obj_portobj = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_portobj.GetDataBase(Ccode);
            
            obj_dt = da_obj_portobj.GetLikePort(prefix.ToUpper());
            //obj_dt = da_obj_portobj.GetSalesLikePort(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()), "FE", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()));
            portname = Utility.Fn_DatatableToList(obj_dt, "portname", "portid");
            return portname;
        }

        [WebMethod]
        public static List<string> Getcustname(string prefix)
        {
            List<string> customername = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_customerobj.GetDataBase(Ccode);
           
            obj_dt = da_obj_customerobj.GetLikeCustomer(prefix.ToUpper(), "P");
            //obj_dt = da_obj_customerobj.GetLikeCustomerForSales(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()));
            customername = Utility.Fn_TableToList(obj_dt, "customername", "customerid");
            return customername;
        }


        [WebMethod]
        public static List<string> GetcustSales(string prefix)
        {
            List<string> custSales = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_employeeobj.GetDataBase(Ccode);
          
            //DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            // obj_dt = da_obj_customerobj.GetSalesLikeEmployeeFROMBooking(prefix.ToUpper(), "P");
            obj_dt = da_obj_employeeobj.GetSalesLikeEmployeeFROMBooking(prefix, HttpContext.Current.Session["StrTranType"].ToString(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()));
            custSales = Utility.Fn_TableToList(obj_dt, "empname", "empnamecode");
            return custSales;
        }

        [WebMethod]
        public static List<string> Getblno(string prefix)
        {
            List<string> blno = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingImports.BLDetails da_obj_blobj = new DataAccess.ForwardingImports.BLDetails();
            DataAccess.ForwardingExports.BLDetails da_obj_FEblobj = new DataAccess.ForwardingExports.BLDetails();
            DataAccess.AirImportExports.AIEBLDetails da_obj_blobj1 = new DataAccess.AirImportExports.AIEBLDetails();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_blobj.GetDataBase(Ccode);
            da_obj_FEblobj.GetDataBase(Ccode);
            da_obj_blobj1.GetDataBase(Ccode);
            if (HttpContext.Current.Session["StrTranType"].ToString() == "FE")
            {
                obj_dt = da_obj_FEblobj.GetLikeOTHERBLDetails(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            }
            else if (HttpContext.Current.Session["StrTranType"].ToString() == "CH")
            {
                obj_dt = da_obj_FEblobj.GetLikeOTHERCHBLDetails(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            }
            else if (HttpContext.Current.Session["StrTranType"].ToString() == "FI")
            {
                obj_dt = da_obj_blobj.GetLikeOTHERIBL(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            }
            else if (HttpContext.Current.Session["StrTranType"].ToString() == "AE" || HttpContext.Current.Session["StrTranType"].ToString() == "AI")
            {
                obj_dt = da_obj_blobj1.GetLikeOTHERAIEBLDetails(prefix.ToUpper(), HttpContext.Current.Session["StrTranType"].ToString(),Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            }
            if (obj_dt.Rows.Count > 0)
            {
                if (HttpContext.Current.Session["StrTranType"].ToString() == "AE" || HttpContext.Current.Session["StrTranType"].ToString() == "AI")
                {
                    blno = Utility.Fn_DatatableToList_Text(obj_dt, "hawblno");
                }
                else if (HttpContext.Current.Session["StrTranType"].ToString() == "FE" || HttpContext.Current.Session["StrTranType"].ToString() == "FI")
                {
                    blno = Utility.Fn_DatatableToList_Text(obj_dt, "blno");
                }

                else if (HttpContext.Current.Session["StrTranType"].ToString() == "CH")
                {
                    blno = Utility.Fn_DatatableToList_Text(obj_dt, "blno");
                }
            }
           
            return blno;
        }

        [WebMethod]
        public static List<string> Getbl(string prefix)
        {
            List<string> blno = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingImports.BLDetails da_obj_blobj = new DataAccess.ForwardingImports.BLDetails();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_blobj.GetDataBase(Ccode);
           
            obj_dt = da_obj_blobj.GetLikeFBLWOCJob(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));

            // obj_dt = da_obj_blobj.GetLikeFBLWOCJob(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()));
            blno = Utility.Fn_DatatableToList_Text(obj_dt, "blno");
            return blno;
        }

        [WebMethod]
        public static List<string> GetInvNo(string prefix)
        {
            List<string> blno = new List<string>();
            DataTable obj_dt = new DataTable();
            //DataAccess.ForwardingImports.BLDetails da_obj_blobj = new DataAccess.ForwardingImports.BLDetails();DataAccess.Accounts.Invoice
            DataAccess.Accounts.Invoice da_obj_blobj = new DataAccess.Accounts.Invoice();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_blobj.GetDataBase(Ccode);
            
            // obj_dt = da_obj_blobj.getLikeCusblon(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()), HttpContext.Current.Session["StrTranType"].ToString());
            obj_dt = da_obj_blobj.getLikeCusblon(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()), HttpContext.Current.Session["StrTranType"].ToString());



            // obj_dt = da_obj_blobj.GetLikeFBLWOCJob(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()));
            blno = Utility.Fn_DatatableToList_Text(obj_dt, "invoiceno");
            return blno;
        }

        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                dt_new.Reset();
                dt_new = new DataTable();

                if (btn_find.ToolTip == "Clear")
                {
                    Clearall();
                    btn_find.Text = "Find";
                    btn_find.ToolTip = "Find";
                    btn_find1.Attributes["class"] = "btn ico-find";
                }
                else
                {

                    if (Session["StrTranType"].ToString() == "AI")
                    {

                      
                        //DataAccess.AirImportExports.AIEBLDetails da_obj_blobj = new DataAccess.AirImportExports.AIEBLDetails();
                        //DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();


                        if (txt_jobno.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj2.ShowAIEInfoQuery(Convert.ToInt32(txt_jobno.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_bl.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj2.ShowAIEInfoQuery(0, Convert.ToString(txt_bl.Text), "BL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }

                        else if (txt_consignee.Text.ToString() != "")
                        {
                            if (hf_consigneeid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_consignee, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Consingee');", true);
                                return;
                            }

                            dt_new = da_obj_blobj2.ShowAIEInfoQuery(Convert.ToInt32(hf_consigneeid.Value), "SAMPLE", "CUST", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_vessel.Text.ToString() != "")
                        {
                            hf_vesselid.Value = da_obj_vesselobj.GetVesselid(Convert.ToString(txt_vessel.Text)).ToString();
                            if (hf_vesselid.Value.ToString() == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_vessel, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Vessel');", true);
                                return;
                            }
                            dt_new = da_obj_blobj2.ShowAIEInfoQuery(Convert.ToInt32(hf_vesselid.Value), "SAMPLE", "VESS", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }

                        else if (txt_cbm.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj2.ShowAIEInfoQuery(0, "SAMPLE", "CBM", Convert.ToDouble(txt_cbm.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_grwt.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj2.ShowAIEInfoQuery(0, "SAMPLE", "GWT", Convert.ToDouble(txt_grwt.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_noofpkg.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj2.ShowAIEInfoQuery(0, "SAMPLE", "NOP", Convert.ToDouble(txt_noofpkg.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_Port.Text.ToString() != "")
                        {
                            if (hf_portid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_Port, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Port');", true);
                                return;
                            }
                            dt_new = da_obj_blobj2.ShowAIEInfoQuery(Convert.ToInt32(hf_portid.Value), "SAMPLE", "POL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString(), Convert.ToInt32(Session["LoginEmpId"].ToString())), Session["StrTranType"].ToString());
                        }

                         //hf_salesid

                        else if (txt_Sales.Text.ToString() != "")
                        {
                           // hf_salesid.Value = da_obj_employeeobj.GetNEmpid(txt_Sales.Text).ToString();
                            if (hf_salesid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_Port, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Sales Person');", true);
                                return;
                            }
                            dt_new = da_obj_blobj2.ShowAIEInfoQuery(Convert.ToInt32(hf_salesid.Value), "SAMPLE", "SALE", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString(), Convert.ToInt32(Session["LoginEmpId"].ToString())), Session["StrTranType"].ToString());
                        }
                        else if (txt_MBLno.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj2.ShowAIEInfoQuery(0, Convert.ToString(txt_MBLno.Text), "MBL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_Bookingno.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj2.ShowAIEInfoQuery(0, Convert.ToString(txt_Bookingno.Text), "BKG", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_Customer.Text.ToString() != "")
                        {
                            if (hf_custid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_Customer, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Customer');", true);
                                return;
                            }
                            dt_new = da_obj_blobj2.ShowAIEInfoQuery(Convert.ToInt32(hf_custid.Value), "SAMPLE", "QCST", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                            txt_Customer.Focus();

                        }
                        else if (txt_Agent.Text.ToString() != "")
                        {
                            if (hf_custid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_Agent, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Shippier');", true);
                                return;
                            }
                            dt_new = da_obj_blobj2.ShowAIEInfoQuery(Convert.ToInt32(hf_custid.Value), "SAMPLE", "AGNT", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                            txt_Agent.Focus();

                        }
                        else if (txt_Inv.Text.ToString() != "")
                        {

                            //  dt_new = da_obj_FEblobj.ShowFEInfo(0, Convert.ToString(txt_Inv.Text), "Inv", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            dt_new = da_obj_blobj2.ShowAIEInfoQuery(0, Convert.ToString(txt_Inv.Text), "Inv", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());

                        }

                    }
                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        //DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
                        DataAccess.AirImportExports.AIEBLDetails da_obj_blobj = new DataAccess.AirImportExports.AIEBLDetails();
                        //DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();


                        if (txt_jobno.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowAIEInfoQuery(Convert.ToInt32(txt_jobno.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_bl.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowAIEInfoQuery(0, Convert.ToString(txt_bl.Text), "BL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }

                        else if (txt_consignee.Text.ToString() != "")
                        {
                            if (hf_consigneeid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_consignee, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Consingee');", true);
                                return;
                            }

                            dt_new = da_obj_blobj.ShowAIEInfoQuery(Convert.ToInt32(hf_consigneeid.Value), "SAMPLE", "CUST", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_vessel.Text.ToString() != "")
                        {
                            if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString()=="FI")
                           {
                            hf_vesselid.Value = da_obj_vesselobj.GetVesselid(Convert.ToString(txt_vessel.Text)).ToString();
                            if (hf_vesselid.Value.ToString() == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_vessel, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Vessel');", true);
                                return;
                            }
                            dt_new = da_obj_blobj.ShowAIEInfoQuery(Convert.ToInt32(hf_vesselid.Value), "SAMPLE", "VESS", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                           }
                           else
                           {
                               dt_new = da_obj_blobj.ShowAIEInfoQuery(0, txt_vessel.Text, "VESS", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                           }
                        }

                        else if (txt_cbm.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowAIEInfoQuery(0, "SAMPLE", "CBM", Convert.ToDouble(txt_cbm.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_grwt.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowAIEInfoQuery(0, "SAMPLE", "GWT", Convert.ToDouble(txt_grwt.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_noofpkg.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowAIEInfoQuery(0, "SAMPLE", "NOP", Convert.ToDouble(txt_noofpkg.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_Port.Text.ToString() != "")
                        {
                            if (hf_portid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_Port, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Port');", true);
                                return;
                            }
                            dt_new = da_obj_blobj.ShowAIEInfoQuery(Convert.ToInt32(hf_portid.Value), "SAMPLE", "POL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }

                         //hf_salesid

                        else if (txt_Sales.Text.ToString() != "")
                        {
                            hf_salesid.Value = da_obj_employeeobj.GetNEmpid(Convert.ToString(txt_Sales.Text)).ToString();
                            if (hf_salesid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_Port, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Sales Person');", true);
                                return;
                            }
                            dt_new = da_obj_blobj.ShowAIEInfoQuery(Convert.ToInt32(hf_salesid.Value), "SAMPLE", "SALE", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                            txt_Sales.Focus();
                        }
                        else if (txt_MBLno.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowAIEInfoQuery(0, Convert.ToString(txt_MBLno.Text), "MBL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_Bookingno.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowAIEInfoQuery(0, Convert.ToString(txt_Bookingno.Text), "BKG", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_Customer.Text.ToString() != "")
                        {
                            if (hf_custid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_Customer, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Customer');", true);
                                return;
                            }
                            dt_new = da_obj_blobj.ShowAIEInfoQuery(Convert.ToInt32(hf_custid.Value), "SAMPLE", "QCST", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                            txt_Customer.Focus();

                        }
                        else if (txt_Agent.Text.ToString() != "")
                        {
                            if (hf_custid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_Agent, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Shippier');", true);
                                return;
                            }
                            dt_new = da_obj_blobj.ShowAIEInfoQuery(Convert.ToInt32(hf_custid.Value), "SAMPLE", "AGNT", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                            txt_Agent.Focus();

                        }

                        else if (txt_Inv.Text.ToString() != "")
                        {

                            //  dt_new = da_obj_FEblobj.ShowFEInfo(0, Convert.ToString(txt_Inv.Text), "Inv", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            dt_new = da_obj_blobj.ShowAIEInfoQuery(0, Convert.ToString(txt_Inv.Text), "Inv", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());

                        }
                        else if (btn_find.ToolTip == "Clear")
                        {
                            //txt_Sales.Text = "";
                            btn_find.Text = "Find";
                            btn_find.ToolTip = "Find";
                            btn_find1.Attributes["class"] = "btn ico-find";
                            return;
                        }
                        

                    }

                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        //DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
                        //DataAccess.ForwardingImports.BLDetails da_obj_blobj = new DataAccess.ForwardingImports.BLDetails();
                        //DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();


                        if (txt_jobno.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowFIInfo(Convert.ToInt32(txt_jobno.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_bl.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowFIInfo(0, Convert.ToString(txt_bl.Text), "BL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_FBL.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowFIInfo(0, Convert.ToString(txt_FBL.Text), "FBL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_consignee.Text.ToString() != "")
                        {
                            if (hf_consigneeid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_consignee, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Consingee');", true);
                                return;
                            }

                            dt_new = da_obj_blobj.ShowFIInfo(Convert.ToInt32(hf_consigneeid.Value), "SAMPLE", "CUST", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_vessel.Text.ToString() != "")
                        {
                            hf_vesselid.Value = da_obj_vesselobj.GetVesselid(Convert.ToString(txt_vessel.Text)).ToString();
                            if (hf_vesselid.Value.ToString() == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_vessel, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Vessel');", true);
                                return;
                            }
                            dt_new = da_obj_blobj.ShowFIInfo(Convert.ToInt32(hf_vesselid.Value), "SAMPLE", "VESS", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_voyage.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowFIInfo(0, Convert.ToString(txt_voyage.Text), "VOY", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_cbm.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowFIInfo(0, "SAMPLE", "CBM", Convert.ToDouble(txt_cbm.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_grwt.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowFIInfo(0, "SAMPLE", "GWT", Convert.ToDouble(txt_grwt.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_noofpkg.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowFIInfo(0, "SAMPLE", "NOP", Convert.ToDouble(txt_noofpkg.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_Port.Text.ToString() != "")
                        {
                            if (hf_portid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_Port, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Port');", true);
                                return;
                            }
                            dt_new = da_obj_blobj.ShowFIInfo(Convert.ToInt32(hf_portid.Value), "SAMPLE", "POL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_MBLno.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowFIInfo(0, Convert.ToString(txt_MBLno.Text), "MBL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_Bookingno.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowFIInfo(0, Convert.ToString(txt_Bookingno.Text), "BKG", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_Containerno.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowFIInfo(0, Convert.ToString(txt_Containerno.Text), "CONT", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_Customer.Text.ToString() != "")
                        {
                            if (hf_custid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_Customer, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Customer');", true);
                                return;
                            }
                            dt_new = da_obj_blobj.ShowFIInfo(Convert.ToInt32(hf_custid.Value), "SAMPLE", "QCST", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            txt_Customer.Focus();

                        }
                        else if (txt_Agent.Text.ToString() != "")
                        {
                            if (hf_custid.Value != "0")
                            {
                                  dt_new = da_obj_blobj.ShowFIInfo(Convert.ToInt32(hf_custid.Value), "SAMPLE", "AGNT", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                           
                            }
                          
                            else
                            {                                
                                ScriptManager.RegisterStartupScript(txt_Agent, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Shippier');", true);
                                return;
                            }
                            txt_Agent.Focus();
                        }

                        else if (txt_Inv.Text.ToString() != "")
                        {

                            //  dt_new = da_obj_FEblobj.ShowFEInfo(0, Convert.ToString(txt_Inv.Text), "Inv", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            dt_new = da_obj_blobj.ShowFIInfo(0, Convert.ToString(txt_Inv.Text), "Inv", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                        }

                        else if (btn_find.ToolTip == "Clear")
                        {
                            //txt_Sales.Text = "";
                            btn_find.Text = "Find";
                            btn_find.ToolTip = "Find";
                            btn_find1.Attributes["class"] = "btn ico-find";
                            return;
                        }
                        else
                        {
                            hf_salesid.Value = da_obj_employeeobj.GetNEmpid(Convert.ToString(txt_Sales.Text)).ToString();
                            dt_new = da_obj_blobj.ShowFIInfo(Convert.ToInt32(hf_salesid.Value), "SAMPLE", "SALE", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }

                    }

                    else if (Session["StrTranType"].ToString() == "CH")
                    {

                        //DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();
                        DataAccess.AirImportExports.AIEBLDetails da_obj_blobj = new DataAccess.AirImportExports.AIEBLDetails();
                       // DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();


                        if (txt_jobno.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowchInfoQuery(Convert.ToInt32(txt_jobno.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_bl.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowchInfoQuery(0, Convert.ToString(txt_bl.Text), "BL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_MBLno.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowchInfoQuery(0, Convert.ToString(txt_MBLno.Text), "MBL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_Customer.Text.ToString() != "")
                        {
                            if (hf_custid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_Customer, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Customer');", true);
                                return;
                            }

                            dt_new = da_obj_blobj.ShowchInfoQuery(Convert.ToInt32(hf_custid.Value), "SAMPLE", "QCST", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                           // dt_new = da_obj_FEblobj.ShowFEInfo(Convert.ToInt32(hf_custid.Value), "SAMPLE", "QCST", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                        }

                        else if (txt_Port.Text.ToString() != "")
                        {
                            if (hf_portid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_Port, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Port');", true);
                                return;
                            }
                         //   dt_new = da_obj_blobj.ShowFIInfo(Convert.ToInt32(hf_portid.Value), "SAMPLE", "POL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                            dt_new = da_obj_blobj.ShowchInfoQuery(Convert.ToInt32(hf_portid.Value), "SAMPLE", "POL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_grwt.Text.ToString() != "")
                        {
                          //  dt_new = da_obj_blobj.ShowFIInfo(0, "SAMPLE", "GWT", Convert.ToDouble(txt_grwt.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            dt_new = da_obj_blobj.ShowchInfoQuery(0, "SAMPLE", "GWT", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }
                        else if (txt_consignee.Text.ToString() != "")
                        {
                            if (hf_consigneeid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_consignee, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Consingee');", true);
                                return;
                            }

                          //  dt_new = da_obj_blobj.ShowAIEInfoQuery(Convert.ToInt32(hf_consigneeid.Value), "SAMPLE", "CUST", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                            dt_new = da_obj_blobj.ShowchInfoQuery(Convert.ToInt32(hf_custid.Value), "SAMPLE", "CUST", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }

                        else if (txt_noofpkg.Text.ToString() != "")
                        {
                            dt_new = da_obj_blobj.ShowchInfoQuery(0, "SAMPLE", "NOP", Convert.ToDouble(txt_noofpkg.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());
                        }

                        else if (txt_Inv.Text.ToString() != "")
                        {

                          //  dt_new = da_obj_FEblobj.ShowFEInfo(0, Convert.ToString(txt_Inv.Text), "Inv", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            dt_new = da_obj_blobj.ShowchInfoQuery(0, Convert.ToString(txt_Inv.Text), "Inv", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["StrTranType"].ToString());

                        }

                        else if (btn_find.ToolTip == "Clear")
                        {
                            //txt_Sales.Text = "";
                            btn_find.Text = "Find";
                            btn_find.ToolTip = "Find";
                            btn_find1.Attributes["class"] = "btn ico-find";
                            return;
                        }


                    }
                    else
                    {
                    //    DataAccess.ForwardingExports.BLDetails da_obj_FEblobj = new DataAccess.ForwardingExports.BLDetails();
                    //    DataAccess.Masters.MasterEmployee da_obj_employeeobj = new DataAccess.Masters.MasterEmployee();

                        if (txt_jobno.Text.ToString() != "")
                        {
                            dt_new = da_obj_FEblobj.ShowFEInfo(Convert.ToInt32(txt_jobno.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_bl.Text.ToString() != "")
                        {
                            dt_new = da_obj_FEblobj.ShowFEInfo(0, Convert.ToString(txt_bl.Text), "BL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }

                        else if (txt_consignee.Text.ToString() != "")
                        {
                            if (hf_consigneeid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_consignee, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Consignee');", true);
                                return;
                            }
                            dt_new = da_obj_FEblobj.ShowFEInfo(Convert.ToInt32(hf_consigneeid.Value), "SAMPLE", "CUST", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                        }
                        else if (txt_vessel.Text.ToString() != "")
                        {
                            //DataAccess.Masters.MasterVessel da_obj_vesselobj = new DataAccess.Masters.MasterVessel();
                            hf_vesselid.Value = da_obj_vesselobj.GetVesselid(Convert.ToString(txt_vessel.Text)).ToString();
                            if (hf_vesselid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_vessel, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Vessel');", true);
                                return;
                            }
                            dt_new = da_obj_FEblobj.ShowFEInfo(Convert.ToInt32(hf_vesselid.Value), "SAMPLE", "VESS", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_voyage.Text.ToString() != "")
                        {
                            dt_new = da_obj_FEblobj.ShowFEInfo(0, Convert.ToString(txt_voyage.Text), "VOY", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_cbm.Text.ToString() != "")
                        {
                            dt_new = da_obj_FEblobj.ShowFEInfo(0, "SAMPLE", "CBM", Convert.ToDouble(txt_cbm.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_grwt.Text.ToString() != "")
                        {
                            dt_new = da_obj_FEblobj.ShowFEInfo(0, "SAMPLE", "GWT", Convert.ToDouble(txt_grwt.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_noofpkg.Text.ToString() != "")
                        {
                            dt_new = da_obj_FEblobj.ShowFEInfo(0, "SAMPLE", "NOP", Convert.ToDouble(txt_noofpkg.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_Shipbill.Text.ToString() != "")
                        {
                            dt_new = da_obj_FEblobj.ShowFEInfo(0, Convert.ToString(txt_Shipbill.Text), "SHIP", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_Port.Text.ToString() != "")
                        {
                            if (hf_portid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_Port, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Port');", true);
                                return;
                            }
                            dt_new = da_obj_FEblobj.ShowFEInfo(Convert.ToInt32(hf_portid.Value), "SAMPLE", "POD", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_MBLno.Text.ToString() != "")
                        {
                            if (hf_mblno.Value == "0")
                            {
                                dt_new = da_obj_FEblobj.ShowFEInfo(0, Convert.ToString(txt_MBLno.Text), "MBL", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            }
                        }
                        else if (txt_Bookingno.Text.ToString() != "")
                        {
                            dt_new = da_obj_FEblobj.ShowFEInfo(0, Convert.ToString(txt_Bookingno.Text), "BKG", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_Containerno.Text.ToString() != "")
                        {
                            dt_new = da_obj_FEblobj.ShowFEInfo(0, Convert.ToString(txt_Containerno.Text), "CONT", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        else if (txt_Customer.Text.ToString() != "")
                        {
                            if (hf_custid.Value == "0")
                            {
                                ScriptManager.RegisterStartupScript(txt_Customer, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Customer');", true);
                                return;
                            }
                            dt_new = da_obj_FEblobj.ShowFEInfo(Convert.ToInt32(hf_custid.Value), "SAMPLE", "QCST", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                        }
                        else if (txt_Agent.Text.ToString() != "")
                        {
                            if (hf_custid.Value != "0")
                            {
                                dt_new = da_obj_FEblobj.ShowFEInfo(Convert.ToInt32(hf_custid.Value), "SAMPLE", "AGNT", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(txt_Agent, typeof(TextBox), "Outstanding", "alertify.alert('Invalid Agent');", true);
                                return;
                            }
                            txt_Agent.Focus();
                        }

                        else if (txt_Inv.Text.ToString() != "")
                        {

                            dt_new = da_obj_FEblobj.ShowFEInfo(0, Convert.ToString(txt_Inv.Text), "Inv", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));


                        }
                        else if (btn_find.ToolTip == "Clear")
                        {
                            // txt_Sales.Text = "";
                            btn_find.Text = "Find";
                            btn_find.ToolTip = "Find";
                            Btn_back.Attributes["class"] = "btn ico-find";
                            return;
                        }
                        else
                        {
                            hf_salesid.Value = da_obj_employeeobj.GetNEmpid(txt_Sales.Text).ToString();
                            dt_new = da_obj_FEblobj.ShowFEInfo(Convert.ToInt32(hf_salesid.Value), "SAMPLE", "SALE", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                    }

                   // btn_find.Text = "Clear";

                   
                    if (txt_Shipbill.Text.ToString()!="")
                    {
                    if (dt_new.Rows.Count > 0)
                    {
                        dbl_tot = 0;
                        dbl_vol = 0;
                        dbl_noof = 0;
                                                
                        
                        DataRow dr_temp = dt_new.NewRow();
                        dr_temp["blno"] = "Total";
                      //  dr_temp["volume"] = dt_new.Compute("sum(volume)", "");
                        dr_temp["grosswt"] = dt_new.Compute("sum(grosswt)", "");
                        dr_temp["noofpkg"] = dt_new.Compute("sum(noofpkg)", "");


                        //dt_new.Rows.Add(dr_temp);

                        if (dr_temp["volume"].ToString().Length == 0)
                        {
                            dr_temp["volume"] = "0.00";
                        }
                        if (dr_temp["grosswt"].ToString().Length == 0)
                        {
                            dr_temp["grosswt"] = "0.00";
                        }
                        if (dr_temp["noofpkg"].ToString().Length == 0)
                        {
                            dr_temp["noofpkg"] = "0.00";
                        }
                        dt_new.Rows.Add(dr_temp);
                        Session["dt"] = dt_new;
                        grd.DataSource = dt_new;
                        grd.DataBind();
                        //grd.Rows[grd.Rows.Count - 1].Cells[6].Text = dbl_tot.ToString();
                        //grd.Rows[grd.Rows.Count - 1].Cells[5].Text = dbl_vol.ToString();
                        //grd.Rows[grd.Rows.Count - 1].Cells[7].Text = dbl_noof.ToString();

                        if (txt_Shipbill.Text.ToString() != "")
                        {
                            grd.HeaderRow.Cells[1].Text = "Booking #";
                        }
                        else
                        {
                            grd.HeaderRow.Cells[1].Text = "BL #";
                        }

                        if (grd.Rows.Count > 0)
                        {
                            grd.HeaderRow.Cells[0].Text = "Job #";
                            grd.HeaderRow.Cells[2].Text = "Shipper";
                            grd.HeaderRow.Cells[3].Text = "Consignee";
                            if (Session["StrTranType"].ToString() == "AI" || Session["StrTranType"].ToString() == "AE")
                            {
                                grd.HeaderRow.Cells[4].Text = "Flight #/Date";
                            }
                            else
                            {
                            grd.HeaderRow.Cells[4].Text = "Vessel/Voy";
                            }
                            grd.HeaderRow.Cells[5].Text = "CBM";
                            grd.HeaderRow.Cells[6].Text = "Gr.Wt.";
                            grd.HeaderRow.Cells[7].Text = "Pkgs";
                            grd.HeaderRow.Cells[8].Text = "";
                        }
                    }
                    else
                    {
                      ScriptManager.RegisterStartupScript(btn_find, typeof(LinkButton), "logix", "alertify.alert('No Data Found');", true);
                      return;
                    }
                  }
                    else
                    {
                        if (dt_new.Rows.Count > 0)
                        {
                            dbl_tot = 0;
                            dbl_vol = 0;
                            dbl_noof = 0;

                            //float n = dt_new.AsEnumerable()
                            //           .Sum(r => (float)r["grosswt"]);

                            //float s = dt_new.AsEnumerable()
                            //    .Sum(v => (float)v["volume"]);

                            ////Double m = dt_new.AsEnumerable()
                            ////   .Sum(y => (Double)y["noofpkgs"]);

                            //DataRow dr_temp = dt_new.NewRow();
                            ////dr_temp["jobno"] = Convert.ToInt16("");
                            //dr_temp["blno"] = "Total";
                            //dr_temp["shipper"] = "";
                            //dr_temp["consignee"] = "";
                            //dr_temp["vessel"] = "";

                            //dr_temp["volume"] = 0;
                            ////dt_new.Compute("sum(volume)", ""); //+ string.Format("{0.00}");
                            //dr_temp["grosswt"] = 0;
                            //dr_temp["noofpkgs"] = 0;
                            //Convert.ToInt16(dt_new.Compute("sum(noofpkgs)", ""));
                            DataRow dr_temp = dt_new.NewRow();
                            dr_temp["blno"] = "Total";
                            dr_temp["volume"] = dt_new.Compute("sum(volume)", "");
                            dr_temp["grosswt"] = dt_new.Compute("sum(grosswt)", "");
                            dr_temp["noofpkgs"] = dt_new.Compute("sum(noofpkgs)", "");


                            //dt_new.Rows.Add(dr_temp);

                            if (dr_temp["volume"].ToString().Length == 0)
                            {
                                dr_temp["volume"] = "0.00";
                            }
                            if (dr_temp["grosswt"].ToString().Length == 0)
                            {
                                dr_temp["grosswt"] = "0.00";
                            }
                            if (dr_temp["noofpkgs"].ToString().Length == 0)
                            {
                                dr_temp["noofpkgs"] = "0.00";
                            }
                            dt_new.Rows.Add(dr_temp);
                            Session["dt"] = dt_new;
                            grd.DataSource = dt_new;
                            grd.DataBind();
                            //grd.Rows[grd.Rows.Count - 1].Cells[6].Text = dbl_tot.ToString();
                            //grd.Rows[grd.Rows.Count - 1].Cells[5].Text = dbl_vol.ToString();
                            //grd.Rows[grd.Rows.Count - 1].Cells[7].Text = dbl_noof.ToString();

                            if (txt_Shipbill.Text.ToString() != "")
                            {
                                grd.HeaderRow.Cells[1].Text = "Booking #";
                            }
                            else
                            {
                                grd.HeaderRow.Cells[1].Text = "BL #";
                            }

                            if (grd.Rows.Count > 0)
                            {
                                grd.HeaderRow.Cells[0].Text = "Job #";
                                grd.HeaderRow.Cells[2].Text = "Shipper";
                                grd.HeaderRow.Cells[3].Text = "Consignee";
                               // grd.HeaderRow.Cells[4].Text = "Vessel/Voy";
                                if (Session["StrTranType"].ToString() == "AI" || Session["StrTranType"].ToString() == "AE")
                                {
                                    grd.HeaderRow.Cells[4].Text = "Flight #/Date";
                                }
                                else
                                {
                                    grd.HeaderRow.Cells[4].Text = "Vessel/Voy";
                                }
                                grd.HeaderRow.Cells[5].Text = "CBM";
                                grd.HeaderRow.Cells[6].Text = "Gr.Wt.";
                                grd.HeaderRow.Cells[7].Text = "Pkgs";
                                grd.HeaderRow.Cells[8].Text = "";
                            }
                            btn_find.Text = "Clear";
                            btn_find.ToolTip = "Clear";
                            btn_find1.Attributes["class"] = "btn ico-clear";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_find, typeof(LinkButton), "logix", "alertify.alert('No Data Found');", true);
                            return;
                        }
                    }
                }
                //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 452, 3, Convert.ToInt32(Session["LoginBranchid"]), " Trantype: " + Session["StrTranType"].ToString() + "/ Job #: " + txt_jobno.Text + "/ Find");

                switch (Session["StrTranType"].ToString())
                {
                    case "FE":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 533, 3, Convert.ToInt32(Session["LoginBranchid"]), " Trantype: " + Session["StrTranType"].ToString() + "/ Job #: " + grd.Rows[0].Cells[0].Text + "/ Find");
                        break;

                    case "FI":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 534, 3, Convert.ToInt32(Session["LoginBranchid"]), " Trantype: " + Session["StrTranType"].ToString() + "/ Job #: " + grd.Rows[0].Cells[0].Text + "/ Find");
                        break;

                    case "AE":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1641, 3, Convert.ToInt32(Session["LoginBranchid"]), " Trantype: " + Session["StrTranType"].ToString() + "/ Job #: " + grd.Rows[0].Cells[0].Text + "/ Find");
                        break;

                    case "AI":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1642, 3, Convert.ToInt32(Session["LoginBranchid"]), " Trantype: " + Session["StrTranType"].ToString() + "/ Job #: " + grd.Rows[0].Cells[0].Text + "/ Find");
                        break;
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
                    dbl_noof = dbl_noof + Convert.ToDouble((e.Row.Cells[7].Text.ToString()));
                    dbl_vol = dbl_vol + Convert.ToDouble((e.Row.Cells[5].Text.ToString()));
                    dbl_tot = dbl_tot + Convert.ToDouble((e.Row.Cells[6].Text.ToString()));

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";

                    if (e.Row.Cells[8].Text.ToString() != "noofpkgs")
                    {
                        e.Row.Cells[7].Text = Convert.ToDouble((e.Row.Cells[7].Text.ToString())) + (e.Row.Cells[8].Text.ToString());
                    }
                    //if (double.TryParse(e.Row.Cells[5].Text.ToString(), out dbl_vol))
                    //{
                    //    e.Row.Cells[5].Text = string.Format("{0:#,##0.00}", dbl_vol);
                    //}
                    grd.HeaderRow.Cells[8].Visible = false;
                    e.Row.Cells[8].Visible = false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

       public void Clearall()
        {
            if (btn_find.ToolTip == "Clear")
            {
                txt_bl.Text = "";
                txt_vessel.Text = "";
                txt_voyage.Text = "";
                txt_consignee.Text = "";
                txt_jobno.Text = "";
                txt_cbm.Text = "";
                txt_Shipbill.Text = "";
                txt_Port.Text = "";
                txt_grwt.Text = "";
                txt_noofpkg.Text = "";
                txt_FBL.Text = "";
                txt_MBLno.Text = "";
                txt_Bookingno.Text = "";
                txt_Containerno.Text = "";
                txt_Customer.Text = "";
                txt_Agent.Text = "";
                txt_Sales.Text = "";
                grd.DataSource = "";
                grd.DataBind();

            }
        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (grd.Rows.Count > 0)
                {
                    int index = grd.SelectedRow.RowIndex;
                    blno = grd.Rows[index].Cells[1].Text;
                    Session["blno"] = blno;
                    if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() =="AI")
                    {
                       // string lblname;
                        if (blno != null && Session["StrTranType"].ToString() == "AE" )
                        {
                           // lblname="BL Details";
                            modal_view.Show();
                            pnl_grd2.Visible = true;
                            iframe_BLPrint.Attributes["src"] = "../AI/BLPrintingAir.aspx?POPUP=yes";
                           // Response.Redirect("../AI/BLPrintingAir.aspx");
                            return;
                        }

                       else if (blno != null && Session["StrTranType"].ToString() == "AI" )
                        {
                         //  lblname="DO Details"; 
                            modal_view.Show();
                            pnl_grd2.Visible = true;
                            iframe_BLPrint.Attributes["src"] = "../AI/BLPrintingAir.aspx?POPUP=yes";
                         //  Response.Redirect("../AI/BLPrintingAir.aspx");
                            return;
                        }
                    }
                    else if (Session["StrTranType"].ToString() == "CH" )
                    {
                        return;
                    }

                    else
                    {
                        if (blno != null)
                        {

                            modal_view.Show();
                            pnl_grd2.Visible = true;
                            iframe_BLPrint.Attributes["src"] = "../ForwardExports/BL Print.aspx?POPUP=yes";
                            //Response.Redirect("../ForwardExports/BL Print.aspx");
                            return;
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        

        protected void Btn_back_Click(object sender, EventArgs e)
        {

            if (Session["home"] != null)
            {
                if (Session["home"].ToString() == "CS")
                {
                    if (Session["StrTranType"] != null)
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            Response.Redirect("../Home/OECSHome.aspx");
                        }
                       else if (Session["StrTranType"].ToString() == "FI")
                        {
                            Response.Redirect("../Home/OICSHome.aspx");
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {
                            Response.Redirect("../Home/AECSHome.aspx");
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {
                            Response.Redirect("../Home/AICSHome.aspx");
                        }
                    }
                }
            }
                   
            
            if (Request.QueryString.ToString().Contains("OECSHomeFEQuery"))
            {
                Response.Redirect("../Home/OECSHome.aspx");
            }
            else if (Request.QueryString.ToString().Contains("OECSHomeFIQuery"))
            {
                Response.Redirect("../Home/OICSHome.aspx");
            }
            else if (Request.QueryString.ToString().Contains("AECSHOMEQuery"))
            {
                Response.Redirect("../Home/AECSHome.aspx");

            }
            else if (Request.QueryString.ToString().Contains("AICSHOMEQuery"))
            {
                Response.Redirect("../Home/AICSHome.aspx");

            }
            else if (Request.QueryString.ToString().Contains("OEOPSDOCHomeFEQuery"))
            {
                Response.Redirect("../Home/OEOpsAndDocs.aspx");
            }
            else if (Request.QueryString.ToString().Contains("OEOPSDOCHomeFIQuery"))  
            {
                Response.Redirect("../Home/OEOpsAndDocs.aspx");
            }
            else if (Request.QueryString.ToString().Contains("OEOPSDOCHomeAEQuery"))
            {
                Response.Redirect("../Home/OEOpsAndDocs.aspx");
            }
            else if (Request.QueryString.ToString().Contains("OEOPSDOCHomeAIQuery"))
            {
                Response.Redirect("../Home/OEOpsAndDocs.aspx");
            }
            else if (Request.QueryString.ToString().Contains("OEOPSDOCHomeCHQuery"))
            {
                Response.Redirect("../Home/CHAHome.aspx");
            }
            else
            {
                this.Response.End();
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
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();

            //obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 762, "Job", txt_jobno.Text, txt_jobno.Text, Session["StrTranType"].ToString());

            switch (Session["StrTranType"].ToString())
            {
                case "FE":
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 533, "Job", txt_jobno.Text, txt_jobno.Text, Session["StrTranType"].ToString());
                    break;

                case "FI":
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 534, "Job", txt_jobno.Text, txt_jobno.Text, Session["StrTranType"].ToString());
                    break;

                case "AE":
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1641, "Job", txt_jobno.Text, txt_jobno.Text, Session["StrTranType"].ToString());
                    break;

                case "AI":
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1642, "Job", txt_jobno.Text, txt_jobno.Text, Session["StrTranType"].ToString());
                    break;
            }
            
            if (txt_jobno.Text != "")
            {
                JobInput.Text = txt_jobno.Text;
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