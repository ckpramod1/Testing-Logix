using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Runtime.Remoting;
using DocumentFormat.OpenXml.Office.Word;
using DataAccess.BondedTrucking;


namespace logix.ShipmentDetails
{
    public partial class BLRelease : System.Web.UI.Page
    {
        //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        //DataAccess.Corporate Corpobj = new DataAccess.Corporate();
        //DataAccess.ForwardingExports.BLPrinting FEBLPrinti = new DataAccess.ForwardingExports.BLPrinting();
        //DataAccess.Accounts.OSDNCN osdcnobj = new DataAccess.Accounts.OSDNCN();
        //DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        //DataAccess.ForwardingExports.BLDetails FEBLobj = new DataAccess.ForwardingExports.BLDetails();
        //DataAccess.ForwardingExports.JobInfo FEJobObj = new DataAccess.ForwardingExports.JobInfo();
        //DataAccess.Masters.MasterCountry Countryobj = new DataAccess.Masters.MasterCountry();
        //DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();
        //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        //DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
        //--------------------------------------------Datatable-------------------------------------------------------------
        DataTable DtDetails = new DataTable();
        DataTable DtExist = new DataTable();
        DataTable Dt = new DataTable();

        int blid;
        int IntJobNo;
        DateTime bldate;
        int intagentid;
        string marks;
        string desc;
        int intPODCountryId;
        int intFDCountryId;
        string por;
        string counname;
        string pol;
        string pod;
        string fd;
        int intcustomerid;
        string des;
        string inco;
        string business;
        string sp;
        string sf;
        string str_FornName = "", str_Uiid = "";
        string annex = "N";
        string script4 = "";
        string blformat, ddl_HTS;

        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        DataAccess.Corporate Corpobj = new DataAccess.Corporate();
        DataAccess.ForwardingExports.BLPrinting FEBLPrinti = new DataAccess.ForwardingExports.BLPrinting();
        DataAccess.Accounts.OSDNCN osdcnobj = new DataAccess.Accounts.OSDNCN();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.ForwardingExports.BLDetails FEBLobj = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.ForwardingExports.JobInfo FEJobObj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.Masters.MasterCountry Countryobj = new DataAccess.Masters.MasterCountry();
        DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
        DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.CreditException Crexobj = new DataAccess.CreditException();
        DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
        DataAccess.Reportasp objRpt = new DataAccess.Reportasp();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                masterObj.GetDataBase(Ccode);
                Corpobj.GetDataBase(Ccode);
                FEBLPrinti.GetDataBase(Ccode);
                osdcnobj.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                FEBLobj.GetDataBase(Ccode);
                FEJobObj.GetDataBase(Ccode);
                Countryobj.GetDataBase(Ccode);
                FIBLobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);

                empobj.GetDataBase(Ccode);
                obj_MasterPort.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);
                obj_da_FEBL.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);
                Crexobj.GetDataBase(Ccode);
                obj_da_Log1.GetDataBase(Ccode);
                objRpt.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
               
                //packobj.GetDataBase(Ccode);
                //STufobj.GetDataBase(Ccode);
                //quotobj.GetDataBase(Ccode);

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);
            //  
            divs.Visible = false;
            if (!IsPostBack)
            {
                divs.Visible = false;
                if (Request.QueryString.ToString().Contains("BLReleaseNO"))
                {
                    txtblno.Text = Request.QueryString["BLReleaseNO"].ToString();
                    txtblno_TextChanged(sender, e);

                }


                //DataTable dt = masterObj.Getdivnamerblrelease(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                DataTable dt = masterObj.Getblformtrpt(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (dt.Rows.Count > 0)
                {
                    cmbblformat.DataSource = dt;
                    cmbblformat.DataTextField = "blformtname";
                    cmbblformat.DataValueField = "blformtid";
                    cmbblformat.DataBind();
                }
                hid_formatname.Value = dt.Rows[0]["blformtname"].ToString().Trim();
                blformat = dt.Rows[0]["blformtaspx"].ToString();
                //  cmbblformat.Items.Add("DEMO COMPANY");
                //  cmbblformat.Items.Add("SWENLOG SUPPLY CHAIN SOLUTIONS");
                txtsob.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                cmbDoc.Items.Add("MTD");
                cmbDoc.Items.Add("MTD/Bill Of Lading");
                btnCancel.Text = "Cancel";
                btnCancel.ToolTip = "Cancel";
                btnCancel1.Attributes["class"] = "btn ico-cancel";
                UserRights();
                if (Request.QueryString.ToString().Contains("BLReleaseNO"))
                {
                    txtblno.Text = Request.QueryString["BLReleaseNO"].ToString();
                    ddl_HTS = Request.QueryString["ddl_HTS"].ToString();
                    txtblno_TextChanged(sender, e);

                }
                if (ddl_HTS == "R")
                {
                    btnseavis.Visible = false;
                    btnorgl.Visible = true;
                    btnsur.Visible = false;
                }
                else if (ddl_HTS == "S")
                {
                    btnseavis.Visible = false;
                    btnorgl.Visible = false;
                    btnsur.Visible = true;
                }
                else
                {
                    btnseavis.Visible = true;
                    btnorgl.Visible = false;
                    btnsur.Visible = false;
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
            if (cmbblformat.SelectedIndex != 0)
            {
                if (Convert.ToInt32(hid_intPODCountryId.Value) == 13)
                {
                    btnOriginal.Attributes["onClick"] = "return confirm('Confirm whether tare weight & Gross weight =  Nett Weight ( goods + packaging ) + container tare has mentioned on MBL & HBL?');";
                }
            }
        }

        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {
                    Boolean btn_delete;
                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    DataTable dtinv = new DataTable();
                    dtinv = FEBLPrinti.GetBLPrintInvDtCHK(txtblno.Text, "FE", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                    if (dtinv.Rows.Count > 0)
                    {
                        Utility.Fn_CheckUserRights(str_Uiid, btnOriginal, btnDraft, null);
                    }
                    else
                    {
                        Utility.Fn_CheckUserRights(str_Uiid, btnCancel, btnDraft, null);
                    }
                    // Utility.Fn_CheckUserRights(str_Uiid,btnOriginal, btnDraft, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    //btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
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
        public static List<string> getlikebl(string prefix)
        {
            //List<string> list_result = new List<string>();
            //int branchid = (int)HttpContext.Current.Session["LoginBranchid"];
            //int divisionid = (int)HttpContext.Current.Session["LoginDivisionId"];
            //DataAccess.ForwardingExports.BLDetails FEBLobj = new DataAccess.ForwardingExports.BLDetails();
            //DataTable dt = new DataTable();
            //dt = FEBLobj.GetLikeOTHERBLDetails(prefix, branchid, divisionid);
            //list_result = Utility.Fn_DatatableToList_Text(dt, "blno");
            //return list_result;

            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_BL.GetDataBase(Ccode);

            //if (HttpContext.Current.Session["FromName"].ToString() == "BILL OF LADING WOJ")
            //{
            //    obj_dt = obj_da_BLWojob.GetLikeBLDetailsWOJ(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            //}
            //else
            //{
            obj_dt = obj_da_BL.GetLikeOTHERBLDetails(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            //}
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "blno");
            return List_Result;
        }

        protected void txtblno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtblno.Text != "")
                {
                    DtDetails = FEBLobj.GetBLDetails(txtblno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"]));
                    if (DtDetails.Rows.Count > 0)
                    {
                        btnCancel.Text = "Cancel";

                        btnCancel.ToolTip = "Cancel";
                        btnCancel1.Attributes["class"] = "btn ico-cancel";
                        GetBLDetails();
                        //  cmbblformat.Text = "SWENLOG SUPPLY CHAIN SOLUTIONS";
                        cmbDoc.Text = "MTD/Bill Of Lading";
                        DataTable dt = masterObj.Getblformtrpt(Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                        cmbblformat.SelectedItem.Text = dt.Rows[0]["blformtname"].ToString().Trim();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL Release", "alert('Please Select Correct BL #');", true);
                        txtblno.Text = "";
                        txtblno.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        public void GetBLDetails()
        {
            try
            {
                if (DtDetails.Rows[0]["surrendered"].ToString() == "R")
                {
                    btnseavis.Visible = false;
                    btnorgl.Visible = true;
                    btnsur.Visible = false;
                }
                else if (DtDetails.Rows[0]["surrendered"].ToString() == "S")
                {
                    btnseavis.Visible = false;
                    btnorgl.Visible = false;
                    btnsur.Visible = true;
                }
                else
                {
                    btnseavis.Visible = true;
                    btnorgl.Visible = false;
                    btnsur.Visible = false;
                }
                IntJobNo = Convert.ToInt32(DtDetails.Rows[0]["jobno"].ToString());
                bldate = Convert.ToDateTime(DtDetails.Rows[0]["issuedon"].ToString());
                txtbldate.Text = bldate.ToString();
                if (DtDetails.Rows[0]["shippedonboard"].ToString() != "")
                {
                    DateTime sobdt = Convert.ToDateTime(DtDetails.Rows[0]["shippedonboard"].ToString());
                    txtsob.Text = sobdt.ToString("dd/MM/yyyy");
                }
                txt_descannex.Text = DtDetails.Rows[0]["descannex"].ToString();
                txtbldate.Text = Utility.fn_ConvertDate(txtbldate.Text);
                txtshipper.Text = DtDetails.Rows[0]["sname"].ToString();
                txtsaddress.Text = DtDetails.Rows[0]["sadd"].ToString();
                txtconsignee.Text = DtDetails.Rows[0]["conname"].ToString();
                txtcaddress.Text = DtDetails.Rows[0]["cadd"].ToString();
                txtnotify.Text = DtDetails.Rows[0]["nname"].ToString();
                txtnaddress.Text = DtDetails.Rows[0]["nadd"].ToString();
                txtagent.Text = DtDetails.Rows[0]["agent"].ToString();
                if (!string.IsNullOrEmpty(DtDetails.Rows[0]["agentaddress"].ToString()))
                {
                    txtaaddress.Text = DtDetails.Rows[0]["agentaddress"].ToString();
                }
                else
                {
                    intagentid = Convert.ToInt32(DtDetails.Rows[0]["deliveryagent"].ToString());
                    string cusadd = customerobj.GetCustomerAddress(intagentid);
                    txtaaddress.Text = cusadd + "P" + customerobj.GetCustlocation(intagentid).ToString();
                }
                marks = DtDetails.Rows[0]["marks"].ToString();
                desc = DtDetails.Rows[0]["descannex"].ToString();
                hid_marks.Value = marks;
                hid_desc.Value = desc;
                intPODCountryId = 0;
                intFDCountryId = 0;
                intPODCountryId = Convert.ToInt32(DtDetails.Rows[0]["podid"].ToString());
                hid_intPODCountryId.Value = intPODCountryId.ToString();
                intFDCountryId = Convert.ToInt32(DtDetails.Rows[0]["fdid"].ToString());

                DtExist = FEBLobj.selFEBLPrint(txtblno.Text.Trim(), Convert.ToInt32(Session["loginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (DtExist.Rows.Count > 0)
                {
                    txtgrossw.Text = DtExist.Rows[0]["blgrwt"].ToString();
                    txtnetw.Text = DtExist.Rows[0]["blntwt"].ToString();
                    txtcbm.Text = DtExist.Rows[0]["blcbm"].ToString();
                    txtpackage.Text = DtExist.Rows[0]["pkgdetails"].ToString();
                    txtreceipt.Text = DtExist.Rows[0]["pordetails"].ToString();

                    txtpol.Text = DtExist.Rows[0]["poldetails"].ToString();
                    txtpodis.Text = DtExist.Rows[0]["poddetails"].ToString();

                    txtfinaldes.Text = DtExist.Rows[0]["fddetails"].ToString();

                    DataTable dt;
                  //  DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                    dt = obj_MasterPort.SelPortName4typepadimg(txtfinaldes.Text.ToUpper(), Session["StrTranType"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        fdflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    }

                    dt = obj_MasterPort.SelPortName4typepadimg(txtreceipt.Text.ToUpper(), Session["StrTranType"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        porflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    }

                    dt = obj_MasterPort.SelPortName4typepadimg(txtpodis.Text.ToUpper(), Session["StrTranType"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        podflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    }

                    dt = obj_MasterPort.SelPortName4typepadimg(txtpol.Text.ToUpper(), Session["StrTranType"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        flagimg.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    }
                    txtContainer.Text = DtExist.Rows[0]["cntrdetails"].ToString();

                    if (txtContainer.Text.Trim() == "")
                    {
                        DtDetails = FEJobObj.GetContainerDetails(IntJobNo, txtblno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        txtContainer.Text = txtContainer.Text.Trim();
                        for (int i = 0; i < DtDetails.Rows.Count; i++)
                        {
                            txtContainer.Text = DtDetails.Rows[i]["containerno"].ToString() + "/" + DtDetails.Rows[i]["sizetype"].ToString() + "/" + DtDetails.Rows[i]["sealno"].ToString() + "/" + DtDetails.Rows[i]["pkgs"].ToString() + "/" + DtDetails.Rows[i]["wt"].ToString() + "\n" + txtContainer.Text;
                        }
                    }


                }
                else
                {
                    txtgrossw.Text = Convert.ToDouble(DtDetails.Rows[0]["grweight"]).ToString("#,0.000") + " KGS";
                    txtnetw.Text = Convert.ToDouble(DtDetails.Rows[0]["netw"]).ToString("#,0.000") + " KGS";
                    txtcbm.Text = Convert.ToDouble(DtDetails.Rows[0]["cbm"]).ToString("#,0.000");
                    txtpackage.Text = DtDetails.Rows[0]["noofpkgs"].ToString() + " " + DtDetails.Rows[0]["units"].ToString();
                    por = DtDetails.Rows[0]["por"].ToString();
                    counname = Countryobj.GetCountryName(por);
                    txtreceipt.Text = por + "," + counname;
                    pol = DtDetails.Rows[0]["pol"].ToString();
                    counname = Countryobj.GetCountryName(pol);
                    txtpol.Text = pol + "," + counname;
                    pod = DtDetails.Rows[0]["pod"].ToString();
                    counname = Countryobj.GetCountryName(pod);
                    txtpodis.Text = pod + "," + counname;
                    fd = DtDetails.Rows[0]["fd"].ToString();
                    counname = Countryobj.GetCountryName(fd);
                    txtfinaldes.Text = fd + "," + counname;
                    DtDetails = FEJobObj.GetContainerDetails(IntJobNo, txtblno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    txtContainer.Text = txtContainer.Text.Trim();
                    for (int i = 0; i < DtDetails.Rows.Count - 1; i++)
                    {
                        txtContainer.Text = DtDetails.Rows[i]["containerno"].ToString() + "/" + DtDetails.Rows[i]["sizetype"].ToString() + "/" + DtDetails.Rows[i]["sealno"].ToString() + "/" + DtDetails.Rows[i]["pkgs"].ToString() + "/" + DtDetails.Rows[i]["wt"].ToString() + "\n" + txtContainer.Text;
                    }
                    DataTable dt;
                  //  DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                    dt = obj_MasterPort.SelPortName4typepadimg(txtfinaldes.Text.ToUpper(), Session["StrTranType"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        fdflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    }

                    dt = obj_MasterPort.SelPortName4typepadimg(txtreceipt.Text.ToUpper(), Session["StrTranType"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        porflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    }

                    dt = obj_MasterPort.SelPortName4typepadimg(txtpodis.Text.ToUpper(), Session["StrTranType"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        podflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    }

                    dt = obj_MasterPort.SelPortName4typepadimg(txtpol.Text.ToUpper(), Session["StrTranType"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        flagimg.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    }
                }
                string bookingno; int quotno = 0;
                bookingno = "";
                bookingno = FIBLobj.GetBookinkNo(txtblno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                DtDetails = FEBLobj.GetBookingDt(bookingno, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                if (DtDetails.Rows.Count > 0)
                {
                    intcustomerid = Convert.ToInt32(DtDetails.Rows[0].ItemArray[13].ToString());
                    inco = DtDetails.Rows[0]["incocode"].ToString();
                    business = DtDetails.Rows[0]["business"].ToString();
                    // quotno = Convert.ToInt32(DtDetails.Rows[0]["quotno"]);
                }

                DataSet dsgsk;
                DataTable dtgsk1;
                DataTable dtgsk2;

                dsgsk = FEBLPrinti.Getgsk(intcustomerid, IntJobNo, "FE", Convert.ToInt32(Session["LoginBranchId"].ToString()));


                if (dsgsk.Tables.Count > 0)
                {
                    if (dsgsk.Tables[0].Rows.Count > 0)
                    {
                        if (dsgsk.Tables[1].Rows.Count > 0)
                        {
                            if (inco == "EXW")
                            {
                                btnDraft.Enabled = true;
                                btnOriginal.Enabled = true;
                                btnDraft.ForeColor = System.Drawing.Color.White;
                                btnOriginal.ForeColor = System.Drawing.Color.White;

                                return;
                            }
                        }
                        else
                        {

                        }

                    }

                }
                DataTable dtinv = new DataTable();
                if (business == "A" && inco == "EXW")
                {
                    btnDraft.Enabled = true;
                    btnOriginal.Enabled = true;
                    btnDraft.ForeColor = System.Drawing.Color.White;
                    btnOriginal.ForeColor = System.Drawing.Color.White;

                    return;
                }
                //if (Session["StrTranType"].ToString() == "AE")
                //{
                //    //int n = Corpobj.GetGroupID(intcustomerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                //    //if (n != 0)
                //    //{
                //    //    btnDraft.Enabled = true;
                //    //    btnOriginal.Enabled = true;
                //    //    btnDraft.ForeColor = System.Drawing.Color.White;
                //    //    btnOriginal.ForeColor = System.Drawing.Color.White;
                //    //    return;
                //    //}
                //}


                if (Session["StrTranType"].ToString() != "AE")
                {
                    dtinv = FEBLPrinti.GetBLPrintInvDtCHK(txtblno.Text, "FE", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                    if (dtinv.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        btnOriginal.Enabled = false;
                        btnsurrenderbl.Enabled = false;
                        btnOriginal.ForeColor = System.Drawing.Color.Gray;
                        btnsurrenderbl.Enabled = false;
                        // btnnon.Enabled = false;
                        btnnon.ForeColor = System.Drawing.Color.Gray;
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLRelease", "alert('There is No Invoice for this Shipment');", true);
                        return;
                    }
                    int status = 0;
                    double creditappamt = 0.00;
                    int creditappdays = 0; string creditstatus = "";
                    DataTable dtprod = new DataTable();
                  //  DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                    // need to check creditstatus
                    dtprod = obj_da_Customer.GetCreditAmount4product(intcustomerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchId"].ToString()), "FE", txtblno.Text);
                    if (dtprod.Rows.Count > 0)
                    {
                        status = Convert.ToInt32(dtprod.Rows[0]["status"].ToString());
                        creditstatus = dtprod.Rows[0]["creditstatus"].ToString();
                        creditappamt = Convert.ToDouble(dtprod.Rows[0]["appAmount"].ToString());
                        creditappdays = Convert.ToInt32(dtprod.Rows[0]["appdays"].ToString());
                    }
                    //if (quotno.ToString() != "")
                    //{
                    //    dtu = objbl.getcreditdaygroupname(quotno, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                    //    if (dtu.Rows.Count > 0)
                    //    {
                    //        //  txt_creditgroupcus.Text = dtu.Rows[0]["groupname"].ToString() + "/" + dtu.Rows[0]["creditdays"].ToString() + "/" + dtu.Rows[0]["creditamt"].ToString();

                    //        txt_creditgroupcus.Text = dtu.Rows[0]["groupname"].ToString() + " / App Days : " + creditappdays + " / App Amt : " + creditappamt + " / " + creditstatus;
                    //    }

                    //}

                    if (business == "A" && inco == "EXW")
                    {
                        btnDraft.Enabled = true;
                        btnOriginal.Enabled = true;
                        btnDraft.ForeColor = System.Drawing.Color.White;
                        btnOriginal.ForeColor = System.Drawing.Color.White;
                        return;
                    }
                    dtinv = FEBLPrinti.GetBLPrintInvDtCHK(txtblno.Text, "FE", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                    if (dtinv.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        btnOriginal.Enabled = false;
                        btnsurrenderbl.Enabled = false;
                        btnnon.Enabled = false;
                        btnOriginal.ForeColor = System.Drawing.Color.Gray;
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLRelease", "alert('There is No Invoice for this Shipment');", true);
                        return;
                    }
                    int a = Corpobj.GetGroupID(intcustomerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (a != 0)
                    {


                        if (status == 0)
                        {
                            string str_ErrMsg = dtprod.Rows[0]["creditstatus"].ToString();
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alert('" + str_ErrMsg + "');", true);
                            btnOriginal.Enabled = false;
                            btnsurrenderbl.Enabled = false;
                            btnOriginal.ForeColor = System.Drawing.Color.Gray;
                            CreatDetails(intcustomerid);
                            return;
                        }
                        else
                        {

                            string b = customerobj.CheckCreditException(txtblno.Text, "FE", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                            if (b == "")
                            {
                                //double f = customerobj.CheckCreditDays4Customer(intcustomerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                double f = customerobj.CheckCreditDays4Customer4product(intcustomerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchId"].ToString()), "FE", txtblno.Text);
                                double c = customerobj.CheckCreditAmount4product(intcustomerid, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), "FE", txtblno.Text);

                                //double c = customerobj.CheckCreditAmount(intcustomerid, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                if (c < 0)
                                {
                                    string cusname = customerobj.GetCustomername(intcustomerid);
                                    //double d = customerobj.GetCreditAmount(intcustomerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                    //int e = customerobj.GetCreditDays(intcustomerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                    double d = creditappamt;
                                    int e = creditappdays;
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLRelease", "alert('" + cusname + "   has already reached the credit limit Rs. " + d + " / " + e + " Days." + " This Shipment has blocked, Hence you cannot print Bill of Lading');", true);
                                    btnOriginal.Enabled = false;
                                    btnsurrenderbl.Enabled = false;
                                    btnnon.Enabled = false;
                                    //   hid_lblmsg.Value = "This Shipment has blocked, Hence you cannot print Bill of Lading";
                                    btnOriginal.ForeColor = System.Drawing.Color.Gray;
                                    txtreceipt.Focus();
                                    //Elengo
                                    CreatDetails(intcustomerid);
                                    hid_CustomerName.Value = cusname;
                                    return;
                                }
                                else
                                {
                                    if (f < 0)
                                    {
                                        string cusname = customerobj.GetCustomername(intcustomerid);
                                        //double d = customerobj.GetCreditAmount(intcustomerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                        //int e = customerobj.GetCreditDays(intcustomerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                        double d = creditappamt;
                                        int e = creditappdays;
                                        ScriptManager.RegisterStartupScript(this, typeof(Page), "BL Release", "alert('" + cusname + " has already reached the credit limit Rs. " + d + " / " + e + " Days." + "This Shipment has blocked, Hence you cannot print Bill of Lading');", true);
                                        btnOriginal.Enabled = false;
                                        btnsurrenderbl.Enabled = false;
                                        btnnon.Enabled = false;
                                        //   hid_lblmsg.Value = "This Shipment has blocked, Hence you cannot print Bill of Lading";
                                        btnOriginal.ForeColor = System.Drawing.Color.Gray;
                                        txtreceipt.Focus();
                                        //Elengo
                                        CreatDetails(intcustomerid);
                                        hid_CustomerName.Value = cusname;
                                        return;

                                    }
                                    else
                                    {
                                        btnOriginal.Enabled = true;
                                        btnnon.Enabled = true;
                                        btnOriginal.ForeColor = System.Drawing.Color.White;
                                    }
                                }

                            }
                            else
                            {
                                btnOriginal.Enabled = true;
                                btnnon.Enabled = true;
                                btnOriginal.ForeColor = System.Drawing.Color.White;
                            }
                        }
                    }

                    //if (a != 0)
                    //{

                    //    string b = customerobj.CheckCreditException(txtblno.Text, "FE", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                    //    if (b == "")
                    //    {
                    //        double f = customerobj.CheckCreditDays4Customer(intcustomerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    //        double c = customerobj.CheckCreditAmount(intcustomerid, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    //        if (c < 0)
                    //        {
                    //            string cusname = customerobj.GetCustomername(intcustomerid);
                    //            double d = customerobj.GetCreditAmount(intcustomerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    //            int e = customerobj.GetCreditDays(intcustomerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLRelease", "alert('" + cusname + "   has already reached the credit limit Rs. " + d + " / " + e + " Days." + " This Shipment has blocked, Hence you cannot print Bill of Lading');", true);
                    //            btnOriginal.Enabled = false;
                    //            btnOriginal.ForeColor = System.Drawing.Color.Gray;
                    //            //  btnnon.Enabled = false;
                    //            btnnon.ForeColor = System.Drawing.Color.Gray;
                    //            txtreceipt.Focus();
                    //            //Elengo
                    //            CreatDetails(intcustomerid);
                    //            hid_CustomerName.Value = cusname;
                    //            return;
                    //        }
                    //        else
                    //        {
                    //            if (f < 0)
                    //            {
                    //                string cusname = customerobj.GetCustomername(intcustomerid);
                    //                double d = customerobj.GetCreditAmount(intcustomerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    //                int e = customerobj.GetCreditDays(intcustomerid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    //                ScriptManager.RegisterStartupScript(this, typeof(Page), "BL Release", "alert('" + cusname + " has already reached the credit limit Rs. " + d + " / " + e + " Days." + "This Shipment has blocked, Hence you cannot print Bill of Lading');", true);
                    //                btnOriginal.Enabled = false;
                    //                btnOriginal.ForeColor = System.Drawing.Color.Gray;
                    //                //  btnnon.Enabled = false;
                    //                btnnon.ForeColor = System.Drawing.Color.Gray;
                    //                txtreceipt.Focus();
                    //                //Elengo
                    //                CreatDetails(intcustomerid);
                    //                hid_CustomerName.Value = cusname;
                    //                return;
                    //                // ScriptManager.RegisterStartupScript(this, typeof(Page), "logix", "alert('" + cusname + " has already reached the credit limit Rs. " + d + " / " + e + " Days." + "\n" + "This Shipment has been blocked, Hence you cannot print Bill of Lading');", true);

                    //            }
                    //            else
                    //            {
                    //                btnOriginal.Enabled = true;
                    //                btnOriginal.ForeColor = System.Drawing.Color.White;
                    //                btnnon.Enabled = true;
                    //                btnnon.ForeColor = System.Drawing.Color.White;
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        btnOriginal.Enabled = true;
                    //        btnOriginal.ForeColor = System.Drawing.Color.White;
                    //        btnnon.Enabled = true;
                    //        btnnon.ForeColor = System.Drawing.Color.White;
                    //    }


                    //}
                    else
                    {
                        string creditexcep = customerobj.CheckCreditException(txtblno.Text, "FE", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                        if (creditexcep == "")
                        {
                            // Dt = FEBLPrinti.GetBLPrintRcptDt(txtblno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                            Dt = FEBLPrinti.GetBLPrintRcptDtchk(txtblno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                            if (Dt.Rows.Count > 0)
                            {
                                btnOriginal.Enabled = true;
                                btnOriginal.ForeColor = System.Drawing.Color.White;
                                btnnon.Enabled = true;
                                btnnon.ForeColor = System.Drawing.Color.White;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLRelease", "alert('We have not received the Payment for this shipment. Please Check with Accounts Department');", true);
                                btnOriginal.Enabled = false;
                                btnsurrenderbl.Enabled = false;
                                btnOriginal.ForeColor = System.Drawing.Color.Gray;
                                //  btnnon.Enabled = false;
                                btnnon.ForeColor = System.Drawing.Color.Gray;
                                return;
                            }
                        }
                        else
                        {
                            btnOriginal.Enabled = true;
                            btnOriginal.ForeColor = System.Drawing.Color.White;

                            btnnon.Enabled = true;
                            btnnon.ForeColor = System.Drawing.Color.White;
                        }


                    }


                }
                else
                {
                    btnOriginal.Enabled = true;
                    btnDraft.Enabled = true;
                    btnOriginal.ForeColor = System.Drawing.Color.White;
                    btnDraft.ForeColor = System.Drawing.Color.White;
                    btnnon.Enabled = true;
                    btnnon.ForeColor = System.Drawing.Color.White;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }

        }

        //protected void btnnon_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Session["ViewBLRelease"] = "ViewBLRelease";
        //        if (txtblno.Text.Trim().Length > 0)
        //        {
        //            Session["str_sfs"] = null;
        //            Session["str_sp"] = null;
        //            if (cmbblformat.SelectedItem.Text.Trim() == "")
        //            {
        //                ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", "alert('Select BL Format');", true);
        //                cmbblformat.Focus();
        //                return;
        //            }

        //            if (cmbDoc.SelectedIndex == 0)
        //            {
        //                ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", "alert('Select Document');", true);
        //                cmbDoc.Focus();
        //                return;
        //            }
        //            DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
        //            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

        //            //txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
        //            //hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
        //            //hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");


        //            /*  txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim();
        //              hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim();
        //              hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim();*/


        //            string des = "";

        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((txtContainer.Text.Trim().Length) >= 3)
        //                {
        //                    des = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring(((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        txtContainer.Text = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring((((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
        //                    }
        //                }
        //            }
        //            des = "";
        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((hid_marks.Value.Trim().Length) >= 3)
        //                {
        //                    des = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        hid_marks.Value = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
        //                    }
        //                }
        //            }
        //            des = "";
        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((hid_desc.Value.Trim().Length) >= 3)
        //                {
        //                    des = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        hid_desc.Value = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
        //                    }
        //                }
        //            }

        //            string container = txtContainer.Text.Trim().Replace(System.Environment.NewLine, "  ");
        //            //txtContainer.Text = txtContainer.Text.Trim().Replace(System.Environment.NewLine, " ").Replace("\n"," ");
        //            hid_marks.Value = hid_marks.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");
        //            //  hid_desc.Value = hid_desc.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");



        //            obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txtreceipt.Text, txtpol.Text, txtpodis.Text, txtfinaldes.Text, txtpackage.Text, txtContainer.Text, txtgrossw.Text, txtnetw.Text, txtcbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

        //            //obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txt_por.Text, txt_pol.Text, txt_pod.Text, txt_fd.Text, txt_packages.Text, txtContainer.Text, txt_gwt.Text, txt_nwt.Text, txt_cbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

        //            //obj_da_FEBL.SPUpdFEhblreleasedon(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

        //            int int_containerlength = 0, int_marklength = 0, int_desclength = 0;


        //            /*int_containerlength = txtContainer.Text.ToString().Length;
        //            int_marklength = hid_marks.Value.ToString().Length;
        //            int_desclength = hid_desc.Value.ToString().Length;
        //            */

        //            if ((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()) != "")
        //            {
        //                int_containerlength = (((container.TrimStart()).TrimEnd()).Trim()).Length;
        //            }
        //            if ((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()) != "")
        //            {
        //                int_marklength = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_marks.Value.ToString().Length;
        //            }
        //            if ((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()) != "")
        //            {
        //                int_desclength = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_desc.Value.ToString().Length;
        //            }

        //            string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";

        //            if (int_containerlength > 290 && int_marklength > 250 && int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRAnex.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                //str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_containerlength > 290 && int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRContDesc.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                //str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();                        
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);

        //            }
        //            if (int_marklength > 250 && int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRMarksDesc.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                //str_sf  = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();                        
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_marklength > 250 && int_containerlength > 290)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRContMarks.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                //str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_containerlength > 290)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRContainer.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                //str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_marklength > 250)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRMarks.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                //str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRDesc.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                //str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (ChkwithoutAgt.Checked == true)
        //            {
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_RptName = "BL4PAN.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    //str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=NO" + "~non=NO" + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company2")
        //                {
        //                    str_RptName = "BL4SCS.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    //str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "draft=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company3")
        //                {
        //                    str_RptName = "Locher Evers.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    //str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=YES" + "~non=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }

        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company4")
        //                {
        //                    str_RptName = "BLFCR.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    //str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=YES" + "~non=NO" + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            else
        //            {
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_RptName = "BL4PAN.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    //str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=YES" + "~non=NO" + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company2")
        //                {
        //                    str_RptName = "BL4SCS.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    //str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "draft=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company3")
        //                {
        //                    str_RptName = "Locher Evers.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    //str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=YES" + "~non=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company4")
        //                {
        //                    str_RptName = "BLFCR.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    //str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=YES" + "~non=NO" + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            //Session["str_sfs"] = str_sf;
        //            //Session["str_sp"] = str_sp;
        //            obj_da_FEBL.InsBLPrintDetails(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), txtblno.Text, obj_da_Log.GetDate());
        //            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 463, 1, int.Parse(Session["LoginBranchid"].ToString()), txtblno.Text + "-original");
        //        }
        //        //UserRights();
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
        //    }
        //}


        protected void btnnon_Click(object sender, EventArgs e)
        {
            try
            {
                Session["ViewBLRelease"] = "ViewBLRelease";
                if (txtblno.Text.Trim().Length > 0)
                {
                    Session["str_sfs"] = null;
                    Session["str_sp"] = null;
                    if (cmbblformat.SelectedItem.Text.Trim() == "")
                    {
                        ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", "alert('Select BL Format');", true);
                        cmbblformat.Focus();
                        return;
                    }

                    if (cmbDoc.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", "alert('Select Document');", true);
                        cmbDoc.Focus();
                        return;
                    }
                    if (txtsob.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select Shipped On Board Date');", true);
                        txtsob.Focus();
                        return;
                    }
                    //DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                    //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                    //txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
                    //hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
                    //hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");


                    /*  txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim();
                      hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim();
                      hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim();*/
                    string str_Script1 = "";
                    string str_Script2 = "";

                    string des = "";

                    for (int i = 0; i < 3; i++)
                    {
                        if ((txtContainer.Text.Trim().Length) >= 3)
                        {
                            des = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring(((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                            if (des == " ")
                            {
                                txtContainer.Text = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring((((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                            }
                        }
                    }
                    des = "";
                    for (int i = 0; i < 3; i++)
                    {
                        if ((hid_marks.Value.Trim().Length) >= 3)
                        {
                            des = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                            if (des == " ")
                            {
                                hid_marks.Value = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                            }
                        }
                    }
                    des = "";
                    for (int i = 0; i < 3; i++)
                    {
                        if ((hid_desc.Value.Trim().Length) >= 3)
                        {
                            des = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                            if (des == " ")
                            {
                                hid_desc.Value = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                            }
                        }
                    }

                    string container = txtContainer.Text.Trim().Replace(System.Environment.NewLine, "  ");
                    //txtContainer.Text = txtContainer.Text.Trim().Replace(System.Environment.NewLine, " ").Replace("\n"," ");
                    hid_marks.Value = hid_marks.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");
                    //  hid_desc.Value = hid_desc.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");



                    obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txtreceipt.Text, txtpol.Text, txtpodis.Text, txtfinaldes.Text, txtpackage.Text, txtContainer.Text, txtgrossw.Text, txtnetw.Text, txtcbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_da_FEBL.InsSOBdate(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txtsob.Text)));
                    obj_da_FEBL.UpddescannexinFEBLdetails(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), txt_descannex.Text);

                    //obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txt_por.Text, txt_pol.Text, txt_pod.Text, txt_fd.Text, txt_packages.Text, txtContainer.Text, txt_gwt.Text, txt_nwt.Text, txt_cbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

                    //obj_da_FEBL.SPUpdFEhblreleasedon(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

                    int int_containerlength = 0, int_marklength = 0, int_desclength = 0;


                    /*int_containerlength = txtContainer.Text.ToString().Length;
                    int_marklength = hid_marks.Value.ToString().Length;
                    int_desclength = hid_desc.Value.ToString().Length;
                    */

                    if ((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()) != "")
                    {
                        int_containerlength = (((container.TrimStart()).TrimEnd()).Trim()).Length;
                    }
                    if ((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()) != "")
                    {
                        int_marklength = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_marks.Value.ToString().Length;
                    }
                    if ((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()) != "")
                    {
                        int_desclength = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_desc.Value.ToString().Length;
                    }

                    string str_sp = "", str_sf = "", str_RptName = "", str_Script = "", Annextype = "";
                    Label22.Text = int_desclength.ToString();
                    if (int_containerlength > 290 && int_marklength > 250 && txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "MCD";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MCD" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRAnex.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_containerlength > 290 && txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "CD";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "CD" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRContDesc.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_marklength > 250 && txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "MD";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MD" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRMarksDesc.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_marklength > 250 && int_containerlength > 290)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "MC";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MC" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRContMarks.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_containerlength > 290)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "C";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "C" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRContainer.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_marklength > 250)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "M";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "M" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRMarks.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "D";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            //  str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "D" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRDesc.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    //if (txt_descannex.Text != "")
                    //{
                    //    //if (Annextype != "")
                    //    //{
                    //    annex = "Y";
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/Annexure4blrelease.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "D" + "','','');";

                    //    }
                    //    // }
                    //}
                    //if (int_containerlength > 290 && int_marklength > 250 && int_desclength > 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MCD" + "','','');";

                    //    }
                    //    else
                    //    {

                    //        //str_RptName = "BlRAnex.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        ////str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }
                    //}
                    //if (int_containerlength > 290 && int_desclength > 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MD" + "','','');";

                    //    }
                    //    else
                    //    {

                    //        //str_RptName = "BlRContDesc.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        ////str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();                        
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }
                    //}
                    //if (int_marklength > 250 && int_desclength > 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MD" + "','','');";

                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRMarksDesc.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        ////str_sf  = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();                        
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }
                    //}
                    //if (int_marklength > 250 && int_containerlength > 290)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MC" + "','','');";

                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRContMarks.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        ////str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }
                    //}
                    //if (int_containerlength > 290)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "C" + "','','');";

                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRContainer.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        ////str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }
                    //}
                    //if (int_marklength > 250)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "M" + "','','');";

                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRMarks.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        ////str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }
                    //}
                    //if (int_desclength > 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "D" + "','','');";

                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRDesc.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        ////str_sf = "{FEBLDetails.blno}=" + txtblno.Text + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }
                    //}
                    blid = cmbblformat.SelectedIndex;
                    DataTable dt = masterObj.Getblformtrpt(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    blformat = dt.Rows[blid]["blformtaspx"].ToString();

                    if (ChkwithoutAgt.Checked == true)
                    {
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {// add 17/01/23
                            //str_Script2 = "window.open('../Reportasp/BL4FCLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "N" + "&type=" + "N" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            if (blformat == "../Reportasp/BL4MArpt.aspx")
                            {
                                str_Script2 = "window.open('../Reportasp/BL4MASURrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "N" + "&type=" + "N" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";

                            }
                            else
                            {
                                str_Script2 = "window.open('" + blformat + "?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "N" + "&type=" + "N" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            }
                            str_Script = str_Script1 + str_Script;
                            str_Script1 = "window.open('../Reportasp/BL4FCLterms.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "N" + "&type=" + "N" + "','','');";
                            if (txt_descannex.Text != "")
                            {
                                str_Script = str_Script + str_Script2 + str_Script1 + script4;
                            }
                            else
                            {
                                str_Script = str_Script + str_Script2 + str_Script1;
                            }
                        }

                        ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    }
                    else
                    {
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {// add 17/01/23 BL4FCLrpt.aspx 
                            //str_Script2 = "window.open('../Reportasp/BL4FCLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "Y" + "&type=" + "N" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            if (blformat == "../Reportasp/BL4MArpt.aspx")
                            {
                                str_Script2 = "window.open('../Reportasp/BL4MASURrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "Y" + "&type=" + "N" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";

                            }
                            else
                            {
                                str_Script2 = "window.open('" + blformat + "?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "Y" + "&type=" + "N" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            }
                            str_Script = str_Script1 + str_Script;
                            str_Script1 = "window.open('../Reportasp/BL4FCLterms.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "Y" + "&type=" + "N" + "','','');";
                            if (txt_descannex.Text != "")
                            {
                                str_Script = str_Script + str_Script2 + str_Script1 + script4;
                            }
                            else
                            {
                                str_Script = str_Script + str_Script2 + str_Script1;
                            }
                        }

                        ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    }
                    //Session["str_sfs"] = str_sf;
                    //Session["str_sp"] = str_sp;
                    obj_da_FEBL.InsBLPrintDetails(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), txtblno.Text, obj_da_Log.GetDate());
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 463, 1, int.Parse(Session["LoginBranchid"].ToString()), txtblno.Text + "-original");
                }
                //UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {

                if (btnCancel.ToolTip == "Cancel")
                {
                    JobInput.Text = "";
                    txtblno.Text = "";
                    txtbldate.Text = "";
                    txtshipper.Text = "";
                    txtconsignee.Text = "";
                    txtsaddress.Text = "";
                    txtcaddress.Text = "";
                    txtnotify.Text = "";
                    txtagent.Text = "";
                    txtnaddress.Text = "";
                    txtaaddress.Text = "";
                    txtreceipt.Text = "";
                    txtpol.Text = "";
                    txtpodis.Text = "";
                    txtfinaldes.Text = "";
                    txtgrossw.Text = "";
                    txtnetw.Text = "";
                    txtcbm.Text = "";
                    txtpackage.Text = "";
                    txtContainer.Text = "";
                    //cmbDoc.Text = "MTD";
                    btnCancel.Text = "Back";
                    txtsob.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                    btnCancel.ToolTip = "Back";
                    btnCancel1.Attributes["class"] = "btn ico-back";
                    btnDraft.Enabled = true;
                    btnDraft.ForeColor = System.Drawing.Color.White;
                    btnnon.Enabled = true;
                    btnnon.ForeColor = System.Drawing.Color.White;
                    btnOriginal.Enabled = true;
                    btnOriginal.ForeColor = System.Drawing.Color.White;
                    cmbblformat.SelectedIndex = 0;
                    cmbDoc.SelectedIndex = 0;
                    ChkwithAgt.Checked = false;
                    ChkwithoutAgt.Checked = false;
                    lnk_Creditdet.Visible = false;
                    hid_CustomerId.Value = "";
                    hid_CustomerName.Value = "";
                    txt_descannex.Text = "";
                    flagimg.ImageUrl = "";
                    porflag.ImageUrl = "";
                    podflag.ImageUrl = "";
                    fdflag.ImageUrl = "";
                }
                else
                {
                    if (Session["home"].ToString() == "CS")
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            // headerlable1.InnerText = "OceanExports";
                            Response.Redirect("../Home/OECSHome.aspx");

                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {
                            // headerlable1.InnerText = "OceanImports";
                            Response.Redirect("../Home/OICSHome.aspx");
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {
                            // headerlable1.InnerText = "AirExports";
                            Response.Redirect("../Home/AECSHome.aspx");
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {
                            //  headerlable1.InnerText = "AirImports";
                            Response.Redirect("../Home/AICSHome.aspx");
                        }
                    }
                    else if (Session["home"].ToString() == "OPS&DOC")
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            // headerlable1.InnerText = "OceanExports";
                            Response.Redirect("../Home/OEOpsAndDocs.aspx");

                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {
                            // headerlable1.InnerText = "OceanImports";
                            Response.Redirect("../Home/OEOpsAndDocs.aspx");
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {
                            // headerlable1.InnerText = "AirExports";
                            Response.Redirect("../Home/OEOpsAndDocs.aspx");
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {
                            //  headerlable1.InnerText = "AirImports";
                            Response.Redirect("../Home/OEOpsAndDocs.aspx");
                        }
                    }
                    else
                    {
                        this.Response.End();
                    }
                }

                if (Request.QueryString.ToString().Contains("blba"))
                {
                    string trantype_process = Session["StrTranType"].ToString();
                    DataTable dtuser = new DataTable();
                    //DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                    if (trantype_process == "FE")
                    {
                        dtuser = obj_UP.GetFormwiseuserRights(1014, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                        if (dtuser.Rows.Count > 0)
                        {


                            Response.Redirect("../ShipmentDetails/FEBLdetails.aspx");


                        }
                        else
                        {
                            string message = "No Rights";
                            ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alert('" + message + "');", true);

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        protected void txtsaddress_TextChanged(object sender, EventArgs e)
        {

        }

        //protected void btnDraft_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Session["ViewBLRelease"] = "ViewBLRelease";
        //        if (txtblno.Text.Trim().Length > 0)
        //        {
        //            Session["str_sfs"] = "";
        //            Session["str_sp"] = "";
        //            if (cmbblformat.SelectedItem.Text.Trim() == "")
        //            {
        //                ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select BL Format');", true);
        //                cmbblformat.Focus();
        //                return;
        //            }

        //            if (cmbDoc.SelectedIndex == 0)
        //            {
        //                ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select DOCUMENT');", true);
        //                cmbDoc.Focus();
        //                return;
        //            }
        //            DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
        //            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

        //            //txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
        //            //  hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
        //            //  hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");

        //            /*  txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim();
        //              // hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim();
        //              hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
        //              hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim();
        //             */

        //            //For i = 0 To 3
        //            //    If Trim(RTrim(LTrim(marks))).Length >= 3 Then
        //            //        des = Trim(RTrim(LTrim(marks))).Substring(Trim(RTrim(LTrim(marks))).Length - 2)
        //            //        If des = vbCrLf Then
        //            //            marks = Trim(RTrim(LTrim(marks))).Remove(Trim(RTrim(LTrim(marks))).Length - 2, 2)
        //            //        End If
        //            //    End If

        //            //Next i
        //            /*  des = "";
        //            for(int i=0;i<3;i++)
        //              {
        //                  if (hid_marks.Value.Trim().Length >= 3)
        //                  {
        //                      des=hid_marks.Value.Trim().Substring((hid_marks.Value.Trim().Length-2));
        //                      if(des==" ")
        //                      {
        //                          hid_marks.Value=hid_marks.Value.Trim().Remove((hid_marks.Value.Trim().Length-2),2);
        //                      }
        //                  }
        //              }*/


        //            //des = ""
        //            //For i = 0 To 3
        //            //    If Trim(RTrim(LTrim(desc))).Length >= 3 Then
        //            //        des = Trim(RTrim(LTrim(desc))).Substring(Trim(RTrim(LTrim(desc))).Length - 2)
        //            //        If des = vbCrLf Then
        //            //            desc = Trim(RTrim(LTrim(desc))).Remove(Trim(RTrim(LTrim(desc))).Length - 2, 2)
        //            //        End If
        //            //    End If

        //            //Next i

        //            /*des = "";
        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((hid_desc.Value.Trim().Length) >= 3)
        //                {
        //                    des = hid_desc.Value.Trim().Substring((hid_desc.Value.Trim().Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        hid_desc.Value = hid_desc.Value.Trim().Remove((hid_desc.Value.Trim().Length - 2), 2);
        //                    }
        //                }
        //            }*/




        //            /* int_containerlength = txtContainer.Text.ToString().Length;
        //             int_marklength = hid_marks.Value.ToString().Length;
        //             int_desclength = hid_desc.Value.ToString().Length;
        //             */

        //            /*   If Trim(RTrim(LTrim(txtContainer.Text))) <> "" Then
        //        lencont = Trim(RTrim(LTrim(txtContainer.Text))).Length
        //    End If

        //    If Trim(RTrim(LTrim(marks))) <> "" Then
        //        lenmarks = Trim(RTrim(LTrim(marks))).Length
        //    End If

        //    If Trim(RTrim(LTrim(desc))) <> "" Then
        //        lendescr = Trim(RTrim(LTrim(desc))).Length
        //    End If*/

        //            string des = "";

        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((txtContainer.Text.Trim().Length) >= 3)
        //                {
        //                    des = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring(((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        txtContainer.Text = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring((((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
        //                    }
        //                }
        //            }
        //            des = "";
        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((hid_marks.Value.Trim().Length) >= 3)
        //                {
        //                    des = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        hid_marks.Value = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
        //                    }
        //                }
        //            }
        //            des = "";
        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((hid_desc.Value.Trim().Length) >= 3)
        //                {
        //                    des = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        hid_desc.Value = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
        //                    }
        //                }
        //            }
        //            string container = txtContainer.Text.Trim().Replace(System.Environment.NewLine, "  ");
        //            //txtContainer.Text = txtContainer.Text.Trim().Replace(System.Environment.NewLine, " ").Replace("\n"," ");
        //            hid_marks.Value = hid_marks.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");
        //            // hid_desc.Value = hid_desc.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");

        //            obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txtreceipt.Text, txtpol.Text, txtpodis.Text, txtfinaldes.Text, txtpackage.Text, txtContainer.Text, txtgrossw.Text, txtnetw.Text, txtcbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));


        //            int int_containerlength = 0, int_marklength = 0, int_desclength = 0;


        //            if ((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()) != "")
        //            {
        //                int_containerlength = (((container.TrimStart()).TrimEnd()).Trim()).Length;
        //            }
        //            if ((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()) != "")
        //            {
        //                int_marklength = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_marks.Value.ToString().Length;
        //            }
        //            if ((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()) != "")
        //            {
        //                int_desclength = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_desc.Value.ToString().Length;
        //            }

        //            string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";

        //            if (int_containerlength > 290 && int_marklength > 250 && int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRAnex.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_containerlength > 290 && int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRContDesc.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);

        //            }
        //            if (int_marklength > 250 && int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRMarksDesc.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_marklength > 250 && int_containerlength > 290)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRContMarks.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_containerlength > 290)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRContainer.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_marklength > 250)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRMarks.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRDesc.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (ChkwithoutAgt.Checked == true)
        //            {
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_RptName = "BL4PAN.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'" + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();

        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=Yes" + "~agent=No" + "~non=NO" + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company2")
        //                {
        //                    str_RptName = "BL4SCS.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "draft=Yes";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company3")
        //                {
        //                    str_RptName = "Locher Evers.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=Yes" + "~agent=No" + "~non=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company4")
        //                {
        //                    str_RptName = "BLFCR.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=Yes" + "~non=NO" + "~agent=Yes" + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            else
        //            {
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_RptName = "BL4PAN.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'" + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=Yes" + "~agent=Yes" + "~non=NO " + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company2")
        //                {
        //                    str_RptName = "BL4SCS.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "draft=Yes";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company3")
        //                {
        //                    str_RptName = "Locher Evers.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=Yes" + "~agent=Yes" + "~non=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company4")
        //                {
        //                    str_RptName = "BLFCR.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=Yes" + "~agent=Yes" + "~agent=Yes" + "~non=NO" + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            obj_da_FEBL.InsBLPrintDetails(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), txtblno.Text, obj_da_Log.GetDate());
        //            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 463, 1, int.Parse(Session["LoginBranchid"].ToString()), txtblno.Text + "-Draft");
        //            //Session["str_sfs"] = str_sf;
        //            //Session["str_sp"] = str_sp;
        //        }
        //        //UserRights();
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
        //    }
        //}

        //protected void btnOriginal_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //  Session["ViewBLRelease"] = "ViewBLRelease";
        //        if (txtblno.Text.Trim().Length > 0)
        //        {
        //            Session["str_sfs"] = "";
        //            Session["str_sp"] = "";
        //            if (cmbblformat.SelectedItem.Text.Trim() == "")
        //            {
        //                ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", "alert('Select BL Format');", true);
        //                cmbblformat.Focus();
        //                return;
        //            }
        //            if (cmbDoc.SelectedIndex == 0)
        //            {
        //                ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select DOCUMENT');", true);
        //                cmbDoc.Focus();
        //                return;
        //            }
        //            if (cmbblformat.SelectedIndex != 0)
        //            {
        //                if (Convert.ToInt32(hid_intPODCountryId.Value) == 13)
        //                {
        //                    fn_Sendmail();
        //                }

        //            }
        //            DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
        //            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

        //            //txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
        //            //hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
        //            //hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");

        //            /*txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim();
        //            hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim();
        //            hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim();*/

        //            string des = "";

        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((txtContainer.Text.Trim().Length) >= 3)
        //                {
        //                    des = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring(((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        txtContainer.Text = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring((((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
        //                    }
        //                }
        //            }
        //            des = "";
        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((hid_marks.Value.Trim().Length) >= 3)
        //                {
        //                    des = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        hid_marks.Value = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
        //                    }
        //                }
        //            }
        //            des = "";
        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((hid_desc.Value.Trim().Length) >= 3)
        //                {
        //                    des = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        hid_desc.Value = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
        //                    }
        //                }
        //            }



        //            obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txtreceipt.Text, txtpol.Text, txtpodis.Text, txtfinaldes.Text, txtpackage.Text, txtContainer.Text, txtgrossw.Text, txtnetw.Text, txtcbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

        //            //obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txt_por.Text, txt_pol.Text, txt_pod.Text, txt_fd.Text, txt_packages.Text, txtContainer.Text, txt_gwt.Text, txt_nwt.Text, txt_cbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
        //            obj_da_FEBL.SPUpdFEhblreleasedon(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

        //            int int_containerlength = 0, int_marklength = 0, int_desclength = 0;


        //            /*int_containerlength = txtContainer.Text.ToString().Length;
        //            int_marklength = hid_marks.Value.ToString().Length;
        //            int_desclength = hid_desc.Value.ToString().Length;*/

        //            string container = txtContainer.Text.Trim().Replace(System.Environment.NewLine, "  ");
        //            //txtContainer.Text = txtContainer.Text.Trim().Replace(System.Environment.NewLine, " ").Replace("\n"," ");
        //            hid_marks.Value = hid_marks.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");
        //            //   hid_desc.Value = hid_desc.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", " ");

        //            obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txtreceipt.Text, txtpol.Text, txtpodis.Text, txtfinaldes.Text, txtpackage.Text, txtContainer.Text, txtgrossw.Text, txtnetw.Text, txtcbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));



        //            if ((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()) != "")
        //            {
        //                int_containerlength = (((container.TrimStart()).TrimEnd()).Trim()).Length;
        //            }
        //            if ((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()) != "")
        //            {
        //                int_marklength = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_marks.Value.ToString().Length;
        //            }
        //            if ((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()) != "")
        //            {
        //                int_desclength = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_desc.Value.ToString().Length;
        //                // int_desclength = (((hid_desc.Value)).Trim()).Length;//hid_desc.Value.ToString().Length;
        //            }

        //            string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";

        //            if (int_containerlength > 290 && int_marklength > 250 && int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRAnex.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_containerlength > 290 && int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRContDesc.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);

        //            }
        //            if (int_marklength > 250 && int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRMarksDesc.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_marklength > 250 && int_containerlength > 290)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRContMarks.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_containerlength > 290)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRContainer.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_marklength > 250)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRMarks.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_desclength >= 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                str_RptName = "BlRDesc.rpt";
        //                Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                str_sp = "descn=" + "";
        //                str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (ChkwithoutAgt.Checked == true)
        //            {
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_RptName = "BL4PAN.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();

        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=NO" + "~non=NO" + "~Doc=" + cmbDoc.Text; ;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company2")
        //                {
        //                    str_RptName = "BL4SCS.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "draft=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company3")
        //                {
        //                    str_RptName = "Locher Evers.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=YES" + "~non=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company4")
        //                {
        //                    str_RptName = "BLFCR.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=YES" + "~non=NO" + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }

        //                ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            else
        //            {
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_RptName = "BL4PAN.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();

        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=YES" + "~non=NO" + "~Doc=" + cmbDoc.Text; ;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company2")
        //                {
        //                    str_RptName = "BL4SCS.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "draft=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company3")
        //                {
        //                    str_RptName = "Locher Evers.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=YES" + "~non=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company4")
        //                {
        //                    str_RptName = "BLFCR.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=YES" + "~non=NO" + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            //Session["str_sfs"] = str_sf;
        //            //Session["str_sp"] = str_sp;
        //            obj_da_FEBL.InsBLPrintDetails(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), txtblno.Text, obj_da_Log.GetDate());
        //            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 463, 1, int.Parse(Session["LoginBranchid"].ToString()), txtblno.Text + "-original");
        //        }
        //        UserRights();
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
        //    }
        //}



        //protected void btnDraft_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Session["ViewBLRelease"] = "ViewBLRelease";
        //        if (txtblno.Text.Trim().Length > 0)
        //        {
        //            Session["str_sfs"] = "";
        //            Session["str_sp"] = "";
        //            if (cmbblformat.SelectedItem.Text.Trim() == "")
        //            {
        //                ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select BL Format');", true);
        //                cmbblformat.Focus();
        //                return;
        //            }

        //            if (cmbDoc.SelectedIndex == 0)
        //            {
        //                ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select DOCUMENT');", true);
        //                cmbDoc.Focus();
        //                return;
        //            }
        //            DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
        //            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

        //            //txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
        //            //  hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
        //            //  hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");

        //            /*  txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim();
        //              // hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim();
        //              hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
        //              hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim();
        //             */

        //            //For i = 0 To 3
        //            //    If Trim(RTrim(LTrim(marks))).Length >= 3 Then
        //            //        des = Trim(RTrim(LTrim(marks))).Substring(Trim(RTrim(LTrim(marks))).Length - 2)
        //            //        If des = vbCrLf Then
        //            //            marks = Trim(RTrim(LTrim(marks))).Remove(Trim(RTrim(LTrim(marks))).Length - 2, 2)
        //            //        End If
        //            //    End If

        //            //Next i
        //            /*  des = "";
        //            for(int i=0;i<3;i++)
        //              {
        //                  if (hid_marks.Value.Trim().Length >= 3)
        //                  {
        //                      des=hid_marks.Value.Trim().Substring((hid_marks.Value.Trim().Length-2));
        //                      if(des==" ")
        //                      {
        //                          hid_marks.Value=hid_marks.Value.Trim().Remove((hid_marks.Value.Trim().Length-2),2);
        //                      }
        //                  }
        //              }*/


        //            //des = ""
        //            //For i = 0 To 3
        //            //    If Trim(RTrim(LTrim(desc))).Length >= 3 Then
        //            //        des = Trim(RTrim(LTrim(desc))).Substring(Trim(RTrim(LTrim(desc))).Length - 2)
        //            //        If des = vbCrLf Then
        //            //            desc = Trim(RTrim(LTrim(desc))).Remove(Trim(RTrim(LTrim(desc))).Length - 2, 2)
        //            //        End If
        //            //    End If

        //            //Next i

        //            /*des = "";
        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((hid_desc.Value.Trim().Length) >= 3)
        //                {
        //                    des = hid_desc.Value.Trim().Substring((hid_desc.Value.Trim().Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        hid_desc.Value = hid_desc.Value.Trim().Remove((hid_desc.Value.Trim().Length - 2), 2);
        //                    }
        //                }
        //            }*/




        //            /* int_containerlength = txtContainer.Text.ToString().Length;
        //             int_marklength = hid_marks.Value.ToString().Length;
        //             int_desclength = hid_desc.Value.ToString().Length;
        //             */

        //            /*   If Trim(RTrim(LTrim(txtContainer.Text))) <> "" Then
        //        lencont = Trim(RTrim(LTrim(txtContainer.Text))).Length
        //    End If

        //    If Trim(RTrim(LTrim(marks))) <> "" Then
        //        lenmarks = Trim(RTrim(LTrim(marks))).Length
        //    End If

        //    If Trim(RTrim(LTrim(desc))) <> "" Then
        //        lendescr = Trim(RTrim(LTrim(desc))).Length
        //    End If*/

        //            string des = "";

        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((txtContainer.Text.Trim().Length) >= 3)
        //                {
        //                    des = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring(((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        txtContainer.Text = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring((((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
        //                    }
        //                }
        //            }
        //            des = "";
        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((hid_marks.Value.Trim().Length) >= 3)
        //                {
        //                    des = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        hid_marks.Value = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
        //                    }
        //                }
        //            }
        //            des = "";
        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((hid_desc.Value.Trim().Length) >= 3)
        //                {
        //                    des = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        hid_desc.Value = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
        //                    }
        //                }
        //            }
        //            string container = txtContainer.Text.Trim().Replace(System.Environment.NewLine, "  ");
        //            //txtContainer.Text = txtContainer.Text.Trim().Replace(System.Environment.NewLine, " ").Replace("\n"," ");
        //            hid_marks.Value = hid_marks.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");
        //            // hid_desc.Value = hid_desc.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");

        //            obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txtreceipt.Text, txtpol.Text, txtpodis.Text, txtfinaldes.Text, txtpackage.Text, txtContainer.Text, txtgrossw.Text, txtnetw.Text, txtcbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));


        //            int int_containerlength = 0, int_marklength = 0, int_desclength = 0;


        //            if ((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()) != "")
        //            {
        //                int_containerlength = (((container.TrimStart()).TrimEnd()).Trim()).Length;
        //            }
        //            if ((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()) != "")
        //            {
        //                int_marklength = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_marks.Value.ToString().Length;
        //            }
        //            if ((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()) != "")
        //            {
        //                int_desclength = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_desc.Value.ToString().Length;
        //            }

        //            string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";
        //            string str_Script1 = "";
        //            string str_Script2 = "";

        //            if (int_containerlength > 290 && int_marklength > 250 && int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MCD" + "','','');";

        //                }
        //                else
        //                {
        //                    str_RptName = "BlRAnex.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "descn=" + "";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //            }
        //            if (int_containerlength > 290 && int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "CD" + "','','');";

        //                }
        //                else
        //                {
        //                    str_RptName = "BlRContDesc.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "descn=" + "";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //            }
        //            if (int_marklength > 250 && int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MD" + "','','');";

        //                }
        //                else
        //                {
        //                    str_RptName = "BlRMarksDesc.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "descn=" + "";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //            }
        //            if (int_marklength > 250 && int_containerlength > 290)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MC" + "','','');";

        //                }
        //                else
        //                {
        //                    str_RptName = "BlRContMarks.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "descn=" + "";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //            }
        //            if (int_containerlength > 290)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "C" + "','','');";

        //                }
        //                else
        //                {
        //                    str_RptName = "BlRContainer.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "descn=" + "";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //            }
        //            if (int_marklength > 250)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "M" + "','','');";

        //                }
        //                else
        //                {
        //                    str_RptName = "BlRMarks.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "descn=" + "";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //            }
        //            if (int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "D" + "','','');";

        //                }
        //                else
        //                {
        //                    str_RptName = "BlRDesc.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "descn=" + "";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //            }
        //            if (ChkwithoutAgt.Checked == true)
        //            {
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script2 = "window.open('../newrpt/BL4FCLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "N" + "&type=" + "D" + "','','');";
        //                    str_Script = str_Script1 + str_Script;
        //                    str_Script1 = "window.open('../Reportasp/BL4FCLterms.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "N" + "&type=" + "D" + "','','');";
        //                    str_Script = str_Script + str_Script2 + str_Script1;
        //                }
        //                if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company1")
        //                {
        //                    str_RptName = "BL4PAN.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'" + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();

        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=Yes" + "~agent=No" + "~non=NO" + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company2")
        //                {
        //                    str_RptName = "BL4SCS.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "draft=Yes";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company3")
        //                {
        //                    str_RptName = "Locher Evers.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=Yes" + "~agent=No" + "~non=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company4")
        //                {
        //                    str_RptName = "BLFCR.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=Yes" + "~non=NO" + "~agent=Yes" + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            else
        //            {
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script2 = "window.open('../Reportasp/BL4FCLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "Y" + "&type=" + "D" + "','','');";
        //                    str_Script = str_Script1 + str_Script;
        //                    str_Script1 = "window.open('../Reportasp/BL4FCLterms.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "Y" + "&type=" + "D" + "','','');";
        //                    str_Script = str_Script + str_Script2 + str_Script1;
        //                }
        //                if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company1")
        //                {
        //                    str_RptName = "BL4PAN.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'" + "and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=Yes" + "~agent=Yes" + "~non=NO " + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company2")
        //                {
        //                    str_RptName = "BL4SCS.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "draft=Yes";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company3")
        //                {
        //                    str_RptName = "Locher Evers.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=Yes" + "~agent=Yes" + "~non=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company4")
        //                {
        //                    str_RptName = "BLFCR.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=Yes" + "~agent=Yes" + "~agent=Yes" + "~non=NO" + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            obj_da_FEBL.InsBLPrintDetails(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), txtblno.Text, obj_da_Log.GetDate());
        //            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 463, 1, int.Parse(Session["LoginBranchid"].ToString()), txtblno.Text + "-Draft");
        //            //Session["str_sfs"] = str_sf;
        //            //Session["str_sp"] = str_sp;
        //        }
        //        //UserRights();
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
        //    }
        //}

        //protected void btnOriginal_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //  Session["ViewBLRelease"] = "ViewBLRelease";
        //        if (txtblno.Text.Trim().Length > 0)
        //        {
        //            Session["str_sfs"] = "";
        //            Session["str_sp"] = "";
        //            if (cmbblformat.SelectedItem.Text.Trim() == "")
        //            {
        //                ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", "alert('Select BL Format');", true);
        //                cmbblformat.Focus();
        //                return;
        //            }
        //            if (cmbDoc.SelectedIndex == 0)
        //            {
        //                ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select DOCUMENT');", true);
        //                cmbDoc.Focus();
        //                return;
        //            }
        //            if (cmbblformat.SelectedIndex != 0)
        //            {
        //                if (Convert.ToInt32(hid_intPODCountryId.Value) == 13)
        //                {
        //                    fn_Sendmail();
        //                }

        //            }
        //            DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
        //            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

        //            //txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
        //            //hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
        //            //hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");

        //            /*txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim();
        //            hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim();
        //            hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim();*/

        //            string des = "";

        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((txtContainer.Text.Trim().Length) >= 3)
        //                {
        //                    des = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring(((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        txtContainer.Text = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring((((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
        //                    }
        //                }
        //            }
        //            des = "";
        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((hid_marks.Value.Trim().Length) >= 3)
        //                {
        //                    des = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        hid_marks.Value = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
        //                    }
        //                }
        //            }
        //            des = "";
        //            for (int i = 0; i < 3; i++)
        //            {
        //                if ((hid_desc.Value.Trim().Length) >= 3)
        //                {
        //                    des = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
        //                    if (des == " ")
        //                    {
        //                        hid_desc.Value = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
        //                    }
        //                }
        //            }



        //            obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txtreceipt.Text, txtpol.Text, txtpodis.Text, txtfinaldes.Text, txtpackage.Text, txtContainer.Text, txtgrossw.Text, txtnetw.Text, txtcbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

        //            //obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txt_por.Text, txt_pol.Text, txt_pod.Text, txt_fd.Text, txt_packages.Text, txtContainer.Text, txt_gwt.Text, txt_nwt.Text, txt_cbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
        //            obj_da_FEBL.SPUpdFEhblreleasedon(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

        //            int int_containerlength = 0, int_marklength = 0, int_desclength = 0;


        //            /*int_containerlength = txtContainer.Text.ToString().Length;
        //            int_marklength = hid_marks.Value.ToString().Length;
        //            int_desclength = hid_desc.Value.ToString().Length;*/

        //            string container = txtContainer.Text.Trim().Replace(System.Environment.NewLine, "  ");
        //            //txtContainer.Text = txtContainer.Text.Trim().Replace(System.Environment.NewLine, " ").Replace("\n"," ");
        //            hid_marks.Value = hid_marks.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");
        //            //   hid_desc.Value = hid_desc.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", " ");

        //            obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txtreceipt.Text, txtpol.Text, txtpodis.Text, txtfinaldes.Text, txtpackage.Text, txtContainer.Text, txtgrossw.Text, txtnetw.Text, txtcbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));



        //            if ((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()) != "")
        //            {
        //                int_containerlength = (((container.TrimStart()).TrimEnd()).Trim()).Length;
        //            }
        //            if ((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()) != "")
        //            {
        //                int_marklength = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_marks.Value.ToString().Length;
        //            }
        //            if ((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()) != "")
        //            {
        //                int_desclength = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_desc.Value.ToString().Length;
        //                // int_desclength = (((hid_desc.Value)).Trim()).Length;//hid_desc.Value.ToString().Length;
        //            }

        //            string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";
        //            string str_Script1 = "";
        //            string str_Script2 = "";


        //            if (int_containerlength > 290 && int_marklength > 250 && int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MCD" + "','','');";

        //                }
        //                else
        //                {

        //                    str_RptName = "BlRAnex.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "descn=" + "";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //            }
        //            if (int_containerlength > 290 && int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "CD" + "','','');";

        //                }
        //                else
        //                {

        //                    str_RptName = "BlRContDesc.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "descn=" + "";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //            }
        //            if (int_marklength > 250 && int_desclength > 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MD" + "','','');";

        //                }
        //                else
        //                {

        //                    str_RptName = "BlRMarksDesc.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "descn=" + "";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //            }
        //            if (int_marklength > 250 && int_containerlength > 290)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MC" + "','','');";

        //                }
        //                else
        //                {

        //                    str_RptName = "BlRContMarks.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "descn=" + "";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //            }
        //            if (int_containerlength > 290)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "C" + "','','');";

        //                }
        //                else
        //                {

        //                    str_RptName = "BlRContainer.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "descn=" + "";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //            }
        //            if (int_marklength > 250)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "M" + "','','');";

        //                }
        //                else
        //                {

        //                    str_RptName = "BlRMarks.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "descn=" + "";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

        //                }//ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            if (int_desclength >= 600)
        //            {
        //                int_containerlength = 0; int_marklength = 0; int_desclength = 0;
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "D" + "','','');";

        //                }
        //                else
        //                {

        //                    str_RptName = "BlRDesc.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "descn=" + "";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //            }
        //            if (ChkwithoutAgt.Checked == true)
        //            {
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script2 += "window.open('../Reportasp/BL4FCLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "N" + "&type=" + "O" + "','','');";
        //                    str_Script = str_Script1 + str_Script;
        //                    str_Script1 = "window.open('../Reportasp/BL4FCLterms.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "Y" + "&type=" + "O" + "','','');";
        //                    str_Script = str_Script + str_Script2 + str_Script1;
        //                }

        //                if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company1")
        //                {
        //                    str_RptName = "BL4PAN.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();

        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=NO" + "~non=NO" + "~Doc=" + cmbDoc.Text; ;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company2")
        //                {
        //                    str_RptName = "BL4SCS.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "draft=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company3")
        //                {
        //                    str_RptName = "Locher Evers.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=YES" + "~non=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company4")
        //                {
        //                    str_RptName = "BLFCR.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=YES" + "~non=NO" + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }

        //                ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            else
        //            {
        //                if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
        //                {
        //                    str_Script2 += "window.open('../Reportasp/BL4FCLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "Y" + "&type=" + "O" + "','','');";
        //                    str_Script = str_Script1 + str_Script;
        //                    str_Script1 = "window.open('../Reportasp/BL4FCLterms.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "Y" + "&type=" + "O" + "','','');";
        //                    str_Script = str_Script + str_Script2 + str_Script1;
        //                }
        //                if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company1")
        //                {
        //                    str_RptName = "BL4PAN.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();

        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=YES" + "~non=NO" + "~Doc=" + cmbDoc.Text; ;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company2")
        //                {
        //                    str_RptName = "BL4SCS.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "draft=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company3")
        //                {
        //                    str_RptName = "Locher Evers.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=YES" + "~non=NO";
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                else if (cmbblformat.SelectedItem.Text.Trim() ==  "Demo Company4")
        //                {
        //                    str_RptName = "BLFCR.rpt";
        //                    Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
        //                    str_sp = "location=" + Session["LoginBranchName"].ToString() + "~draft=NO~agent=YES" + "~non=NO" + "~Doc=" + cmbDoc.Text;
        //                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //                }
        //                ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
        //            }
        //            //Session["str_sfs"] = str_sf;
        //            //Session["str_sp"] = str_sp;
        //            obj_da_FEBL.InsBLPrintDetails(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), txtblno.Text, obj_da_Log.GetDate());
        //            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 463, 1, int.Parse(Session["LoginBranchid"].ToString()), txtblno.Text + "-original");
        //        }
        //        UserRights();
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
        //    }
        //}

        protected void ChkwithAgt_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkwithAgt.Checked == true)
            {
                ChkwithoutAgt.Checked = false;
            }
        }

        protected void ChkwithoutAgt_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkwithoutAgt.Checked == true)
            {
                ChkwithAgt.Checked = false;
            }
        }

        private void fn_Sendmail()
        {
            string sendqry = "";

            sendqry = Session["Companyaddress"].ToString();
            sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>Dear Sir / Madam ,</td></tr></font></table><br>";
            sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>BL #  " + txtblno.Text + "</td></tr></font></table>";
            sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>This is Australia shipment , Weight has confirmed by " + empobj.GetEmployeeName(Convert.ToInt32(Session["LoginEmpId"].ToString())) + "</td></tr></font></table>";

            sendqry = sendqry + "<FONT FACE=sans-serif SIZE=2><br>System generated mail, Do not reply</FONT><br>";
            //Utility.SendMail("", "", "Australia shipment - BL # : " + txtblno.Text + " - PoL : " + txtpol.Text + " - PoD : " + txtpodis.Text, sendqry, "", Session["usermailpwd"].ToString());
            Utility.SendMail(Session["usermailid"].ToString(), "", "Australia shipment - BL # : " + txtblno.Text + " - PoL : " + txtpol.Text + " - PoD : " + txtpodis.Text, sendqry, "", Session["usermailpwd"].ToString());
            //  sendmail.SendEmail("", "", "pandi", "Australia shipment - BL # : " & txtblno.Text & " - PoL : " & txtpol.Text & " - PoD : " & txtpodis.Text, sendqry, True, Login.MailServer, "", "", "PADMANABHAN.SUNDARAM@IN.MRSPEDAG.COM", "97pca1266", "")}
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
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        protected void loadgridlog()
        {
            GridViewlog.Visible = true;
            Panel1.Visible = true;

            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 463, "BLREL", txtblno.Text, txtblno.Text, "");  //"/Rate ID: " +
            if (txtblno.Text != "")
            {
                JobInput.Text = txtblno.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }


        //Elengo
        public void CreatDetails(int Customerid)
        {
            hid_CustomerId.Value = Customerid.ToString();
            lnk_Creditdet.Visible = true;
        }

        protected void lnk_Creditdet_Click(object sender, EventArgs e)
        {
            try
            {
                this.PopCreditdet.Show();
                CustomerLbl1.InnerText = hid_CustomerName.Value;
                grdCridtDet.DataSource = new DataTable();
                grdCridtDet.DataBind();
                //DataAccess.CreditException Crexobj = new DataAccess.CreditException();
                DataTable dtinv = Crexobj.GetCustInvOut(Convert.ToInt32(hid_CustomerId.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (dtinv.Rows.Count > 0)
                {
                    DataTable dtt = new DataTable();
                    DataRow dr;
                    dtt.Columns.Add("shortname");
                    dtt.Columns.Add("customername");
                    dtt.Columns.Add("invoiceno");
                    dtt.Columns.Add("invdate");
                    dtt.Columns.Add("days");
                    dtt.Columns.Add("osamount", typeof(Double));
                    dtt.Columns.Add("branchid");

                    for (int i = 0; i <= (dtinv.Rows.Count - 1); i++)
                    {
                        int invouno = Convert.ToInt32(dtinv.Rows[i]["vouno"].ToString());
                        DateTime invoudate = Convert.ToDateTime(dtinv.Rows[i]["voudate"].ToString());
                        int invodays = Convert.ToInt32(dtinv.Rows[i]["noofdays"].ToString());
                        string voutype = dtinv.Rows[i]["voutype"].ToString();
                        double invamount = Convert.ToDouble(dtinv.Rows[i]["osamount"].ToString());

                        dr = dtt.NewRow();
                        dr["shortname"] = dtinv.Rows[i]["shortname"].ToString();
                        dr["customername"] = dtinv.Rows[i]["customername"].ToString();
                        dr["invoiceno"] = voutype + " - " + invouno;
                        dr["invdate"] = invoudate.ToShortDateString();
                        dr["days"] = invodays.ToString();
                        dr["osamount"] = Math.Round(invamount, 2).ToString("#0.00");
                        dr["branchid"] = dtinv.Rows[i]["branchid"].ToString();
                        dtt.Rows.Add(dr);
                    }
                    //Total
                    DataRow dr1 = dtt.NewRow();
                    dr1[4] = "Total";
                    dr1[5] = dtt.Compute("Sum(osamount)", "");
                    dtt.Rows.Add(dr1);
                    DataView Dtview = dtt.DefaultView;
                    ////Branchwise filtering
                    //dt_check.RowFilter = "branchid = " + Convert.ToInt32(Session["LoginBranchid"]);
                    DataTable dtbrafil = Dtview.ToTable();
                    grdCridtDet.DataSource = dtbrafil;
                    grdCridtDet.DataBind();
                    grdCridtDet.Rows[grdCridtDet.Rows.Count - 1].Font.Bold = true;
                }
                else
                {
                    grdCridtDet.DataSource = new DataTable();
                    grdCridtDet.DataBind();
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        protected void grdCridtDet_RowDataBound(object sender, GridViewRowEventArgs e)
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
                        if (i == 5)
                        {
                            //double dbl_temp = 0;
                            //if (double.TryParse(e.Row.Cells[i].Text.ToString(), out dbl_temp))
                            //{
                            //    e.Row.Cells[i].Text = string.Format("{0:#,##0.00}", dbl_temp);
                            //    e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                            //}
                            double dbl_temp = Convert.ToDouble(e.Row.Cells[i].Text);
                            e.Row.Cells[i].Text = dbl_temp.ToString("#0.00");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        protected void grdCridtDet_PreRender(object sender, EventArgs e)
        {
            if (grdCridtDet.Rows.Count > 0)
            {
                grdCridtDet.UseAccessibleHeader = true;
                grdCridtDet.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btnDraft_Click(object sender, EventArgs e)
        {
            try
            {
                Session["ViewBLRelease"] = "ViewBLRelease";
                if (txtblno.Text.Trim().Length > 0)
                {
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    if (cmbblformat.SelectedItem.Text.Trim() == "")
                    {
                        ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select BL Format');", true);
                        cmbblformat.Focus();
                        return;
                    }

                    if (cmbDoc.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select DOCUMENT');", true);
                        cmbDoc.Focus();
                        return;
                    }
                    if (txtsob.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select Shipped On Board Date');", true);
                        txtsob.Focus();
                        return;
                    }
                    //DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                    //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                    DtDetails = FEBLobj.GetBLDetails(txtblno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"]));

                    hid_desc.Value = DtDetails.Rows[0]["descannex"].ToString();
                    //txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
                    //  hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
                    //  hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");

                    /*  txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim();
                      // hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim();
                      hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
                      hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim();
                     */

                    //For i = 0 To 3
                    //    If Trim(RTrim(LTrim(marks))).Length >= 3 Then
                    //        des = Trim(RTrim(LTrim(marks))).Substring(Trim(RTrim(LTrim(marks))).Length - 2)
                    //        If des = vbCrLf Then
                    //            marks = Trim(RTrim(LTrim(marks))).Remove(Trim(RTrim(LTrim(marks))).Length - 2, 2)
                    //        End If
                    //    End If

                    //Next i
                    /*  des = "";
                    for(int i=0;i<3;i++)
                      {
                          if (hid_marks.Value.Trim().Length >= 3)
                          {
                              des=hid_marks.Value.Trim().Substring((hid_marks.Value.Trim().Length-2));
                              if(des==" ")
                              {
                                  hid_marks.Value=hid_marks.Value.Trim().Remove((hid_marks.Value.Trim().Length-2),2);
                              }
                          }
                      }*/


                    //des = ""
                    //For i = 0 To 3
                    //    If Trim(RTrim(LTrim(desc))).Length >= 3 Then
                    //        des = Trim(RTrim(LTrim(desc))).Substring(Trim(RTrim(LTrim(desc))).Length - 2)
                    //        If des = vbCrLf Then
                    //            desc = Trim(RTrim(LTrim(desc))).Remove(Trim(RTrim(LTrim(desc))).Length - 2, 2)
                    //        End If
                    //    End If

                    //Next i

                    /*des = "";
                    for (int i = 0; i < 3; i++)
                    {
                        if ((hid_desc.Value.Trim().Length) >= 3)
                        {
                            des = hid_desc.Value.Trim().Substring((hid_desc.Value.Trim().Length) - 2);
                            if (des == " ")
                            {
                                hid_desc.Value = hid_desc.Value.Trim().Remove((hid_desc.Value.Trim().Length - 2), 2);
                            }
                        }
                    }*/




                    /* int_containerlength = txtContainer.Text.ToString().Length;
                     int_marklength = hid_marks.Value.ToString().Length;
                     int_desclength = hid_desc.Value.ToString().Length;
                     */

                    /*   If Trim(RTrim(LTrim(txtContainer.Text))) <> "" Then
                lencont = Trim(RTrim(LTrim(txtContainer.Text))).Length
            End If

            If Trim(RTrim(LTrim(marks))) <> "" Then
                lenmarks = Trim(RTrim(LTrim(marks))).Length
            End If

            If Trim(RTrim(LTrim(desc))) <> "" Then
                lendescr = Trim(RTrim(LTrim(desc))).Length
            End If*/

                    string des = "";

                    for (int i = 0; i < 3; i++)
                    {
                        if ((txtContainer.Text.Trim().Length) >= 3)
                        {
                            des = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring(((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                            if (des == " ")
                            {
                                txtContainer.Text = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring((((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                            }
                        }
                    }
                    des = "";
                    for (int i = 0; i < 3; i++)
                    {
                        if ((hid_marks.Value.Trim().Length) >= 3)
                        {
                            des = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                            if (des == " ")
                            {
                                hid_marks.Value = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                            }
                        }
                    }
                    des = "";
                    for (int i = 0; i < 3; i++)
                    {
                        if ((hid_desc.Value.Trim().Length) >= 3)
                        {
                            des = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                            if (des == " ")
                            {
                                hid_desc.Value = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                            }
                        }
                    }
                    string container = txtContainer.Text.Trim().Replace(System.Environment.NewLine, "  ");
                    //txtContainer.Text = txtContainer.Text.Trim().Replace(System.Environment.NewLine, " ").Replace("\n"," ");
                    hid_marks.Value = hid_marks.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");
                    // hid_desc.Value = hid_desc.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");

                    obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txtreceipt.Text, txtpol.Text, txtpodis.Text, txtfinaldes.Text, txtpackage.Text, txtContainer.Text, txtgrossw.Text, txtnetw.Text, txtcbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

                    obj_da_FEBL.UpddescannexinFEBLdetails(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), txt_descannex.Text);

                    obj_da_FEBL.InsSOBdate(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txtsob.Text)));
                    int int_containerlength = 0, int_marklength = 0, int_desclength = 0;


                    if ((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()) != "")
                    {
                        int_containerlength = (((container.TrimStart()).TrimEnd()).Trim()).Length;
                    }
                    if ((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()) != "")
                    {
                        int_marklength = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_marks.Value.ToString().Length;
                    }
                    if ((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()) != "")
                    {
                        int_desclength = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_desc.Value.ToString().Length;
                    }

                    string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";
                    string str_Script1 = "";
                    string str_Script2 = ""; string Annextype = "";
                    Label22.Text = int_desclength.ToString();
                    if (int_containerlength > 290 && int_marklength > 250 && txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "MCD";

                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MCD" + "','','');";

                        }

                    }
                    if (int_containerlength > 290 && txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "CD";


                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "CD" + "','','');";

                        }




                    }
                    if (int_marklength > 250 && txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "MD";


                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MD" + "','','');";

                        }



                    }
                    if (int_marklength > 250 && int_containerlength > 290)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "MC";



                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MC" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRContMarks.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_containerlength > 290)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "C";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "C" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRContainer.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_marklength > 250)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "M";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "M" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRMarks.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_desclength > 600)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "D";
                        if (txt_descannex.Text != "")
                        {
                            if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                            {
                                str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "D" + "','','');";

                            }
                        }


                    }
                    //if (txt_descannex.Text != "")
                    //{
                    //    //if (Annextype != "")
                    //    //{
                    //    annex = "Y";
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        script4 = "window.open('../Reportasp/Annexure4blrelease.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "D" + "','','');";

                    //    }
                    //    //}
                    //}
                    blid = cmbblformat.SelectedIndex;
                    DataTable dt = masterObj.Getblformtrpt(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    blformat = dt.Rows[blid]["blformtaspx"].ToString();
                    if (ChkwithoutAgt.Checked == true)
                    {
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {// add 17/01/23
                            //str_Script2 = "window.open('../Reportasp/BL4FCLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "N" + "&type=" + "D" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            str_Script2 = "window.open('"+ blformat + "?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "N" + "&type=" + "D" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            str_Script = str_Script1 + str_Script;
                            str_Script1 = "window.open('../Reportasp/BL4FCLterms.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "N" + "&type=" + "D" + "','','');";
                            if (txt_descannex.Text != "")
                            {
                                str_Script = str_Script + str_Script2 + str_Script1 + script4;
                            }
                            else
                            {
                                str_Script = str_Script + str_Script2 + str_Script1;
                            }
                        }

                        ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                    }
                    else
                    {
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {// add 17/01/23
                            //str_Script2 = "window.open('../Reportasp/BL4FCLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "Y" + "&type=" + "D" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            str_Script2 = "window.open('../Reportasp/BL4FCLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "Y" + "&type=" + "D" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            str_Script = str_Script1 + str_Script;
                            str_Script1 = "window.open('../Reportasp/BL4FCLterms.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "Y" + "&type=" + "D" + "','','');";
                            if (txt_descannex.Text != "")
                            {
                                str_Script = str_Script + str_Script2 + str_Script1 + script4;
                            }
                            else
                            {
                                str_Script = str_Script + str_Script2 + str_Script1;
                            }


                        }

                        ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                    }
                    obj_da_FEBL.InsBLPrintDetails(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), txtblno.Text, obj_da_Log.GetDate());
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 463, 1, int.Parse(Session["LoginBranchid"].ToString()), txtblno.Text + "-Draft");
                    //Session["str_sfs"] = str_sf;
                    //Session["str_sp"] = str_sp;
                }
                //UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        protected void btnOriginal_Click(object sender, EventArgs e)
        {
            try
            {
                //  Session["ViewBLRelease"] = "ViewBLRelease";
                if (txtblno.Text.Trim().Length > 0)
                {
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    if (cmbblformat.SelectedItem.Text.Trim() == "")
                    {
                        ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", "alert('Select BL Format');", true);
                        cmbblformat.Focus();
                        return;
                    }
                    if (cmbDoc.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select DOCUMENT');", true);
                        cmbDoc.Focus();
                        return;
                    }
                    if (cmbblformat.SelectedIndex != 0)
                    {
                        if (Convert.ToInt32(hid_intPODCountryId.Value) == 13)
                        {
                            fn_Sendmail();
                        }

                    }
                    if (txtsob.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select Shipped On Board Date');", true);
                        txtsob.Focus();
                        return;
                    }
                    //DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                    //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                    //txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
                    //hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
                    //hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");

                    /*txtContainer.Text = txtContainer.Text.TrimStart().TrimEnd().Trim();
                    hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim();
                    hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim();*/

                    string des = "";

                    for (int i = 0; i < 3; i++)
                    {
                        if ((txtContainer.Text.Trim().Length) >= 3)
                        {
                            des = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring(((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                            if (des == " ")
                            {
                                txtContainer.Text = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring((((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                            }
                        }
                    }
                    des = "";
                    for (int i = 0; i < 3; i++)
                    {
                        if ((hid_marks.Value.Trim().Length) >= 3)
                        {
                            des = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                            if (des == " ")
                            {
                                hid_marks.Value = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                            }
                        }
                    }
                    des = "";
                    for (int i = 0; i < 3; i++)
                    {
                        if ((hid_desc.Value.Trim().Length) >= 3)
                        {
                            des = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                            if (des == " ")
                            {
                                hid_desc.Value = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                            }
                        }
                    }



                    obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txtreceipt.Text, txtpol.Text, txtpodis.Text, txtfinaldes.Text, txtpackage.Text, txtContainer.Text, txtgrossw.Text, txtnetw.Text, txtcbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

                    //obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txt_por.Text, txt_pol.Text, txt_pod.Text, txt_fd.Text, txt_packages.Text, txtContainer.Text, txt_gwt.Text, txt_nwt.Text, txt_cbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_da_FEBL.SPUpdFEhblreleasedon(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_da_FEBL.InsSOBdate(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txtsob.Text)));
                    obj_da_FEBL.UpddescannexinFEBLdetails(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), txt_descannex.Text);

                    int int_containerlength = 0, int_marklength = 0, int_desclength = 0;


                    /*int_containerlength = txtContainer.Text.ToString().Length;
                    int_marklength = hid_marks.Value.ToString().Length;
                    int_desclength = hid_desc.Value.ToString().Length;*/

                    string container = txtContainer.Text.Trim().Replace(System.Environment.NewLine, "  ");
                    //txtContainer.Text = txtContainer.Text.Trim().Replace(System.Environment.NewLine, " ").Replace("\n"," ");
                    hid_marks.Value = hid_marks.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");
                    //   hid_desc.Value = hid_desc.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", " ");

                    obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txtreceipt.Text, txtpol.Text, txtpodis.Text, txtfinaldes.Text, txtpackage.Text, txtContainer.Text, txtgrossw.Text, txtnetw.Text, txtcbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));



                    if ((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()) != "")
                    {
                        int_containerlength = (((container.TrimStart()).TrimEnd()).Trim()).Length;
                    }
                    if ((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()) != "")
                    {
                        int_marklength = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_marks.Value.ToString().Length;
                    }
                    if ((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()) != "")
                    {
                        int_desclength = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_desc.Value.ToString().Length;
                        // int_desclength = (((hid_desc.Value)).Trim()).Length;//hid_desc.Value.ToString().Length;
                    }

                    string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";
                    string str_Script1 = "";
                    string str_Script2 = "";
                    Label22.Text = int_desclength.ToString();
                    string Annextype = "";

                    if (int_containerlength > 290 && int_marklength > 250 && txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "MCD";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MCD" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRAnex.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_containerlength > 290 && txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "CD";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "CD" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRContDesc.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_marklength > 250 && txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "MD";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MD" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRMarksDesc.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_marklength > 250 && int_containerlength > 290)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "MC";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MC" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRContMarks.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_containerlength > 290)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "C";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "C" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRContainer.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_marklength > 250)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "M";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "M" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRMarks.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "D";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            //str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "D" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRDesc.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    //if (txt_descannex.Text != "")
                    //{
                    //    // if (Annextype != "")
                    //    // {
                    //    annex = "Y";
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/Annexure4blrelease.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + Annextype + "','','');";

                    //    }
                    //    // }
                    //}


                    //if (int_containerlength > 290 && int_marklength > 250 && int_desclength > 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MCD" + "','','');";

                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRAnex.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    //if (int_containerlength > 290 && int_desclength > 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "CD" + "','','');";
                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRContDesc.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    //if (int_marklength > 250 && int_desclength > 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MD" + "','','');";
                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRMarksDesc.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    //if (int_marklength > 250 && int_containerlength > 290)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MC" + "','','');";
                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRContMarks.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    //if (int_containerlength > 290)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "C" + "','','');";
                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRContainer.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    //if (int_marklength > 250)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "M" + "','','');";
                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRMarks.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    //    }//ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);

                    //}
                    //if (int_desclength >= 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "D" + "','','');";

                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRDesc.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    blid = cmbblformat.SelectedIndex;
                    DataTable dt = masterObj.Getblformtrpt(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    blformat = dt.Rows[blid]["blformtaspx"].ToString();
                    if (ChkwithoutAgt.Checked == true)
                    {
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            //str_Script2 += "window.open('../Reportasp/BL4FCLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "N" + "&type=" + "O" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            if (blformat == "../Reportasp/BL4MArpt.aspx")
                            {
                                str_Script2 += "window.open('../Reportasp/BL4MAORLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "Y" + "&type=" + "O" + "&descn=" + Label22.Text + "&annex=" + annex + "&original=" + "Y" + "','','');";

                            }
                            else
                            {

                                str_Script2 += "window.open('" + blformat + "?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "N" + "&type=" + "O" + "&descn=" + Label22.Text + "&annex=" + annex + "&original=" + "Y" + "','','');";
                            }
                            str_Script = str_Script1 + str_Script;
                            str_Script1 = "window.open('../Reportasp/BL4FCLterms.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "Y" + "&type=" + "O" + "','','');";
                            if (txt_descannex.Text != "")
                            {
                                str_Script = str_Script + str_Script2 + str_Script1 + script4;
                            }
                            else
                            {
                                str_Script = str_Script + str_Script2 + str_Script1;
                            }
                        }


                        ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    }
                    else
                    {
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {// BL4FCLrpt.aspx add 17/01/23
                            //str_Script2 += "window.open('../Reportasp/BL4FCLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "Y" + "&type=" + "O" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            if (blformat == "../Reportasp/BL4MArpt.aspx")
                            {
                                str_Script2 += "window.open('../Reportasp/BL4MAORLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "Y" + "&type=" + "O" + "&descn=" + Label22.Text + "&annex=" + annex + "&original=" + "Y" + "','','');";

                            }
                            else
                            {

                                str_Script2 += "window.open('" + blformat + "?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "Y" + "&type=" + "O" + "&descn=" + Label22.Text + "&annex=" + annex + "&original=" + "Y" + "','','');";
                            }

                            str_Script = str_Script1 + str_Script;
                            str_Script1 = "window.open('../Reportasp/BL4FCLterms.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "Y" + "&type=" + "O" + "','','');";
                            if (txt_descannex.Text != "")
                            {
                                str_Script = str_Script + str_Script2 + str_Script1 + script4;
                            }
                            else
                            {
                                str_Script = str_Script + str_Script2 + str_Script1;
                            }
                        }

                        ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    }
                    ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
               
                    //Session["str_sfs"] = str_sf;
                    //Session["str_sp"] = str_sp;
                    //DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
                    string date = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                    //DataAccess.Reportasp objRpt = new DataAccess.Reportasp();

                    objRpt.InsOEeventdetailsTask(0, txtblno.Text.ToString(), "", "BL /AWB Release",
                   Convert.ToDateTime(Utility.fn_ConvertDate(date.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), 0, "", 14);
                    //Convert.ToInt32(txt_job.Text),txt_search.Text.ToString(),
                    obj_da_FEBL.InsBLPrintDetails(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), txtblno.Text, obj_da_Log.GetDate());
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 463, 1, int.Parse(Session["LoginBranchid"].ToString()), txtblno.Text + "-original");
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        protected void btnsea_Click(object sender, EventArgs e)
        {
            try
            {
                //  Session["ViewBLRelease"] = "ViewBLRelease";
                if (txtblno.Text.Trim().Length > 0)
                {
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    if (cmbblformat.SelectedItem.Text.Trim() == "")
                    {
                        ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", "alert('Select BL Format');", true);
                        cmbblformat.Focus();
                        return;
                    }
                    if (cmbDoc.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select DOCUMENT');", true);
                        cmbDoc.Focus();
                        return;
                    }
                    if (cmbblformat.SelectedIndex != 0)
                    {
                        if (Convert.ToInt32(hid_intPODCountryId.Value) == 13)
                        {
                            fn_Sendmail();
                        }

                    }
                    if (txtsob.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select Shipped On Board Date');", true);
                        txtsob.Focus();
                        return;
                    }
                    //DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                    //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                    string des = "";

                    for (int i = 0; i < 3; i++)
                    {
                        if ((txtContainer.Text.Trim().Length) >= 3)
                        {
                            des = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring(((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                            if (des == " ")
                            {
                                txtContainer.Text = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring((((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                            }
                        }
                    }
                    des = "";
                    for (int i = 0; i < 3; i++)
                    {
                        if ((hid_marks.Value.Trim().Length) >= 3)
                        {
                            des = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                            if (des == " ")
                            {
                                hid_marks.Value = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                            }
                        }
                    }
                    des = "";
                    for (int i = 0; i < 3; i++)
                    {
                        if ((hid_desc.Value.Trim().Length) >= 3)
                        {
                            des = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                            if (des == " ")
                            {
                                hid_desc.Value = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                            }
                        }
                    }



                    obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txtreceipt.Text, txtpol.Text, txtpodis.Text, txtfinaldes.Text, txtpackage.Text, txtContainer.Text, txtgrossw.Text, txtnetw.Text, txtcbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_da_FEBL.SPUpdFEhblreleasedon(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_da_FEBL.InsSOBdate(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txtsob.Text)));
                    obj_da_FEBL.UpddescannexinFEBLdetails(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), txt_descannex.Text);

                    int int_containerlength = 0, int_marklength = 0, int_desclength = 0;



                    string container = txtContainer.Text.Trim().Replace(System.Environment.NewLine, "  ");
                    hid_marks.Value = hid_marks.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");

                    obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txtreceipt.Text, txtpol.Text, txtpodis.Text, txtfinaldes.Text, txtpackage.Text, txtContainer.Text, txtgrossw.Text, txtnetw.Text, txtcbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));



                    if ((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()) != "")
                    {
                        int_containerlength = (((container.TrimStart()).TrimEnd()).Trim()).Length;
                    }
                    if ((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()) != "")
                    {
                        int_marklength = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_marks.Value.ToString().Length;
                    }
                    if ((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()) != "")
                    {
                        int_desclength = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_desc.Value.ToString().Length;
                    }

                    string str_sp = "", str_sf = "", str_RptName = "", str_Script = "", Annextype = "";
                    string str_Script1 = "";
                    string str_Script2 = "";
                    Label22.Text = int_desclength.ToString();
                    if (int_containerlength > 290 && int_marklength > 250 && txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "MCD";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MCD" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRAnex.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_containerlength > 290 && txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "CD";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "CD" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRContDesc.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_marklength > 250 && txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "MD";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MD" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRMarksDesc.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_marklength > 250 && int_containerlength > 290)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "MC";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MC" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRContMarks.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_containerlength > 290)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "C";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "C" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRContainer.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_marklength > 250)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "M";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "M" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRMarks.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "D";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "D" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRDesc.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    //if (txt_descannex.Text != "")
                    //{
                    //    //if (Annextype != "")
                    //    //{
                    //    annex = "Y";
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/Annexure4blrelease.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "D" + "','','');";

                    //    }
                    //    //}
                    //}
                    //if (int_containerlength > 290 && int_marklength > 250 && int_desclength > 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MCD" + "','','');";

                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRAnex.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    //if (int_containerlength > 290 && int_desclength > 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "CD" + "','','');";
                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRContDesc.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    //if (int_marklength > 250 && int_desclength > 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MD" + "','','');";
                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRMarksDesc.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    //if (int_marklength > 250 && int_containerlength > 290)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MC" + "','','');";
                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRContMarks.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    //if (int_containerlength > 290)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "C" + "','','');";
                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRContainer.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    //if (int_marklength > 250)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "M" + "','','');";
                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRMarks.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    //    } 
                    //}
                    //if (int_desclength >= 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "D" + "','','');";

                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRDesc.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    blid = cmbblformat.SelectedIndex;
                    DataTable dt = masterObj.Getblformtrpt(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    blformat = dt.Rows[blid]["blformtaspx"].ToString();
                    if (ChkwithoutAgt.Checked == true)
                    {
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            //str_Script2 += "window.open('../Reportasp/BL4FCLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "N" + "&type=" + "OS" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            str_Script2 += "window.open('" + blformat + "?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "N" + "&type=" + "OS" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            str_Script = str_Script1 + str_Script;
                            str_Script1 = "window.open('../Reportasp/BL4FCLterms.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "Y" + "&type=" + "OS" + "','','');";
                            if (txt_descannex.Text != "")
                            {
                                str_Script = str_Script + str_Script2 + str_Script1 + script4;
                            }
                            else
                            {
                                str_Script = str_Script + str_Script2 + str_Script1;
                            }
                        }


                        ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    }
                    else
                    {
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {// BL4FCLrpt.aspx add 17/01/23
                            //str_Script2 += "window.open('../Reportasp/BL4FCLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "Y" + "&type=" + "OS" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            str_Script2 += "window.open('" + blformat + "?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "Y" + "&type=" + "OS" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            str_Script = str_Script1 + str_Script;
                            str_Script1 = "window.open('../Reportasp/BL4FCLterms.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "Y" + "&type=" + "OS" + "','','');";
                            if (txt_descannex.Text != "")
                            {
                                str_Script = str_Script + str_Script2 + str_Script1 + script4;
                            }
                            else
                            {
                                str_Script = str_Script + str_Script2 + str_Script1;
                            }
                        }

                        ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    }
                    //Session["str_sfs"] = str_sf;
                    //Session["str_sp"] = str_sp;
                    obj_da_FEBL.InsBLPrintDetails(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), txtblno.Text, obj_da_Log.GetDate());
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 463, 1, int.Parse(Session["LoginBranchid"].ToString()), txtblno.Text + "-SeaWayBill");
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }

        }

        protected void btnsurrenderbl_Click(object sender, EventArgs e)
        {
            try
            {
                //  Session["ViewBLRelease"] = "ViewBLRelease";
                if (txtblno.Text.Trim().Length > 0)
                {
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    if (cmbblformat.SelectedItem.Text.Trim() == "")
                    {
                        ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", "alert('Select BL Format');", true);
                        cmbblformat.Focus();
                        return;
                    }
                    if (cmbDoc.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select DOCUMENT');", true);
                        cmbDoc.Focus();
                        return;
                    }
                    if (cmbblformat.SelectedIndex != 0)
                    {
                        if (Convert.ToInt32(hid_intPODCountryId.Value) == 13)
                        {
                            fn_Sendmail();
                        }

                    }
                    if (txtsob.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", "alert('Select Shipped On Board Date');", true);
                        txtsob.Focus();
                        return;
                    }
                    //DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                    //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                    string des = "";

                    for (int i = 0; i < 3; i++)
                    {
                        if ((txtContainer.Text.Trim().Length) >= 3)
                        {
                            des = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring(((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                            if (des == " ")
                            {
                                txtContainer.Text = (((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Substring((((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                            }
                        }
                    }
                    des = "";
                    for (int i = 0; i < 3; i++)
                    {
                        if ((hid_marks.Value.Trim().Length) >= 3)
                        {
                            des = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                            if (des == " ")
                            {
                                hid_marks.Value = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                            }
                        }
                    }
                    des = "";
                    for (int i = 0; i < 3; i++)
                    {
                        if ((hid_desc.Value.Trim().Length) >= 3)
                        {
                            des = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring(((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2);
                            if (des == " ")
                            {
                                hid_desc.Value = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Substring((((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length) - 2), 2);
                            }
                        }
                    }



                    obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txtreceipt.Text, txtpol.Text, txtpodis.Text, txtfinaldes.Text, txtpackage.Text, txtContainer.Text, txtgrossw.Text, txtnetw.Text, txtcbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_da_FEBL.SPUpdFEhblreleasedon(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                    obj_da_FEBL.InsSOBdate(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txtsob.Text)));
                    obj_da_FEBL.UpddescannexinFEBLdetails(txtblno.Text, int.Parse(Session["LoginBranchid"].ToString()), txt_descannex.Text);

                    int int_containerlength = 0, int_marklength = 0, int_desclength = 0;



                    string container = txtContainer.Text.Trim().Replace(System.Environment.NewLine, "  ");
                    hid_marks.Value = hid_marks.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");

                    obj_da_FEBL.UpdateBLDetails4BLPrint4blrealse(txtblno.Text, txtreceipt.Text, txtpol.Text, txtpodis.Text, txtfinaldes.Text, txtpackage.Text, txtContainer.Text, txtgrossw.Text, txtnetw.Text, txtcbm.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));



                    if ((((txtContainer.Text.TrimStart()).TrimEnd()).Trim()) != "")
                    {
                        int_containerlength = (((container.TrimStart()).TrimEnd()).Trim()).Length;
                    }
                    if ((((hid_marks.Value.TrimStart()).TrimEnd()).Trim()) != "")
                    {
                        int_marklength = (((hid_marks.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_marks.Value.ToString().Length;
                    }
                    if ((((hid_desc.Value.TrimStart()).TrimEnd()).Trim()) != "")
                    {
                        int_desclength = (((hid_desc.Value.TrimStart()).TrimEnd()).Trim()).Length;//hid_desc.Value.ToString().Length;
                    }

                    string str_sp = "", str_sf = "", str_RptName = "", str_Script = "", Annextype = "";
                    string str_Script1 = "";
                    string str_Script2 = "";
                    Label22.Text = int_desclength.ToString();
                    if (int_containerlength > 290 && int_marklength > 250 && txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "MCD";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MCD" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRAnex.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_containerlength > 290 && txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "CD";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "CD" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRContDesc.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_marklength > 250 && txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "MD";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MD" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRMarksDesc.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "' and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_marklength > 250 && int_containerlength > 290)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "MC";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MC" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRContMarks.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_containerlength > 290)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "C";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "C" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRContainer.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (int_marklength > 250)
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "M";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "M" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRMarks.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    if (txt_descannex.Text != "")
                    {
                        int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                        Annextype = "D";
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "D" + "','','');";

                        }
                        else
                        {
                            //str_RptName = "BlRDesc.rpt";
                            //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                            //str_sp = "descn=" + "";
                            //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                        }

                    }
                    //if (txt_descannex.Text != "")
                    //{
                    //    //if (Annextype != "")
                    //    //{
                    //    annex = "Y";
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/Annexure4blrelease.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "D" + "','','');";

                    //    }
                    //    //}
                    //}
                    //if (int_containerlength > 290 && int_marklength > 250 && int_desclength > 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MCD" + "','','');";

                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRAnex.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    //if (int_containerlength > 290 && int_desclength > 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "CD" + "','','');";
                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRContDesc.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    //if (int_marklength > 250 && int_desclength > 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MD" + "','','');";
                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRMarksDesc.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    //if (int_marklength > 250 && int_containerlength > 290)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "MC" + "','','');";
                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRContMarks.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    //if (int_containerlength > 290)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "C" + "','','');";
                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRContainer.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    //if (int_marklength > 250)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "M" + "','','');";
                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRMarks.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    //    } 
                    //}
                    //if (int_desclength >= 600)
                    //{
                    //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    //    if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                    //    {
                    //        str_Script += "window.open('../Reportasp/AnnexureDesc.aspx?Blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&Cid=" + Session["LoginDivisionid"].ToString() + "&Type=" + "D" + "','','');";

                    //    }
                    //    else
                    //    {
                    //        //str_RptName = "BlRDesc.rpt";
                    //        //Session["str_sfs"] = "{FEBLDetails.blno}='" + txtblno.Text + "'and {FEBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    //        //str_sp = "descn=" + "";
                    //        //str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //        //ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    //    }

                    //}
                    blid = cmbblformat.SelectedIndex;
                    DataTable dt = masterObj.Getblformtrpt(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    blformat = dt.Rows[blid]["blformtaspx"].ToString();
                    if (ChkwithoutAgt.Checked == true)
                    {
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {
                            //str_Script2 += "window.open('../Reportasp/BL4FCLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "N" + "&type=" + "OS" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            str_Script2 += "window.open('"+ blformat + "?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "N" + "&type=" + "OS" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            str_Script = str_Script1 + str_Script;
                            str_Script1 = "window.open('../Reportasp/BL4FCLterms.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "Y" + "&type=" + "OS" + "','','');";
                            if (txt_descannex.Text != "")
                            {
                                str_Script = str_Script + str_Script2 + str_Script1 + script4;
                            }
                            else
                            {
                                str_Script = str_Script + str_Script2 + str_Script1;
                            }
                        }


                        ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    }
                    else
                    {
                        if (cmbblformat.SelectedItem.Text.Trim() == hid_formatname.Value)
                        {// BL4FCLrpt.aspx add 17/01/23
                            //str_Script2 += "window.open('../Reportasp/BL4FCLrpt.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "Y" + "&type=" + "OS" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            str_Script2 += "window.open('"+ blformat + "?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Doc=" + cmbDoc.Text + "&Agent=" + "Y" + "&type=" + "OS" + "&descn=" + Label22.Text + "&annex=" + annex + "','','');";
                            str_Script = str_Script1 + str_Script;
                            str_Script1 = "window.open('../Reportasp/BL4FCLterms.aspx?blno=" + txtblno.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&cid=" + Session["LoginDivisionId"].ToString() + "&Agent=" + "Y" + "&type=" + "OS" + "','','');";
                            if (txt_descannex.Text != "")
                            {
                                str_Script = str_Script + str_Script2 + str_Script1 + script4;
                            }
                            else
                            {
                                str_Script = str_Script + str_Script2 + str_Script1;
                            }
                        }

                        ScriptManager.RegisterStartupScript(btnOriginal, typeof(Button), "BLRelease", str_Script, true);
                    }
                    //Session["str_sfs"] = str_sf;
                    //Session["str_sp"] = str_sp;
                    obj_da_FEBL.InsBLPrintDetails(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), txtblno.Text, obj_da_Log.GetDate());
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 463, 1, int.Parse(Session["LoginBranchid"].ToString()), txtblno.Text + "-original");
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        protected void cmbblformat_SelectedIndexChanged(object sender, EventArgs e)
        {
            hid_formatname.Value = cmbblformat.SelectedItem.Text.Trim();            
        }

    }
}